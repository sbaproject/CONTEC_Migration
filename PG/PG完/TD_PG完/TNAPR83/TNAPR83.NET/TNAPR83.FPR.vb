Option Strict Off
Option Explicit On
'2019/06/20 ADD START
Imports Oracle.DataAccess.Client
Imports PronesDbAccess
'2019/06/20 ADD END
Module SSSMAIN0001
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	'
	'�P�v���W�F�N�g���Ƃ̋��ʃ��C�u����
	Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(6 + 0 + 0 + 1) As clsCP
	Public CQ_SSSMAIN(6) As String
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� Start ��������������������������������
	'�����������`�F�b�N���s�t���O
	Public gv_bolInit As Boolean '������������True(�`�F�b�N�Ȃ��j�@����ȊO��False
	'��ʏ������t���O
	Public gv_bolTNAPR83_INIT As Boolean 'True:�ύX����
	Public gv_bolTNAPR83_LF_Enable As Boolean 'LF�������s�t���O(True�F���s����j
	Public gv_bolKeyFlg As Boolean
	'�r���������������������������������������������������������r
	Public Structure TNAPR83_TYPE_INPUT
		Dim SOUCD As String '�q�ɺ���
		Dim SOUNM As String '�q�ɖ�
		Dim ZAIOUT As String
	End Structure
	'��ʏ��
	Public TNAPR83_InputData As TNAPR83_TYPE_INPUT
	
	'**********Private�萔**********
	
	'�o�͒��[�h�c
	Private Const mc_strLIST_ID As String = "TNAPR83"
	'������t���O
	Public gv_bolNowPrinting As Boolean
	
	'�O����������s���̗���
	Public gv_strInitYM As String
	'�d���������������������������������������������������������d
	
	''**�����֐��֘A Start **
	'//�ߒl
	Public Const CHK_OK As Short = 0 '����
	Public Const CHK_WARN As Short = 1 '�x��
	Public Const CHK_ERR_NOT_INPUT As Short = 10 '�����̓G���[
	Public Const CHK_ERR_ELSE As Short = 11 '���̑��G���[
	
	'F_Chk_Jge_Action�֐��p
	Public Const CHK_KEEP As Short = 0 '�`�F�b�N���s
	Public Const CHK_STOP As Short = 1 '�`�F�b�N���f
	
	'**�����֐��֘A End  **
	
	'//F_Set_Next_Focus�������[�h
	Public Const NEXT_FOCUS_MODE_KEYRETURN As Short = 1 'KEYRETURN�Ɠ��l�̐���
	Public Const NEXT_FOCUS_MODE_KEYRIGHT As Short = 2 'KEYRIGHT�Ɠ��l�̐���
	Public Const NEXT_FOCUS_MODE_KEYDOWN As Short = 3 'KEYDOWN�Ɠ��l�̐���
	'//F_Dsp_Item_Detail�������[�h
	Public Const DSP_SET As Short = 0 '�\��
    Public Const DSP_CLR As Short = 1 '�N���A

    '20190625 ADD START
    Public D0 As ClsComn = New ClsComn
    Public LV_Col_Order() As Integer
    '20190625 ADD END

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Chk_HD_SOUCD
    '   �T�v�F  �S���҃R�[�h������
    '   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
    '           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
    '           pm_All                :��ʏ��
    '   �ߒl�F�@�`�F�b�N����
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_SOUCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf As TYPE_DB_SOUMTA
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_HD_SOUCD = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
        '20190625 CHG START
        'Call DB_SOUMTA_Clear(Mst_Inf)
        Call InitDataCommon("SOUMTA")
        '20190625 CHG END

        '�����̓`�F�b�N
        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			'        Retn_Code = CHK_ERR_NOT_INPUT
			TNAPR83_InputData.SOUCD = ""
			TNAPR83_InputData.SOUNM = ""
		Else
			'�����͈ȊO�̃`�F�b�N��
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgTNAPR83_E_005 '���͔͈͊O
			Else
				'�}�X�^�`�F�b�N
				If DSPSOUCD_SEARCH(Input_Value, Mst_Inf) = 0 Then
                    '                '�_���폜�`�F�b�N
                    '                If Mst_Inf.DATKB = gc_strDATKB_DEL Then
                    '                    Retn_Code = CHK_ERR_ELSE
                    '                    Err_Cd = gc_strMsgTNAPR83_E_015       '�폜�ς݃f�[�^
                    '                Else
                    '�n�j
                    Retn_Code = CHK_OK
                    pm_Chk_Move = True
					
					'�擾���ڊi�[
					TNAPR83_InputData.SOUCD = Trim(Mst_Inf.SOUCD)
					TNAPR83_InputData.SOUNM = Trim(Mst_Inf.SOUNM)
					'                End If
				Else
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgTNAPR83_E_006 '�Y���f�[�^�Ȃ�
				End If
			End If
			
		End If
		'�d���������������������������������������������������������d
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_SOUCD = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_HD_ZAIOUT
	'   �T�v�F  �݌ɏo�̓t���O������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_ZAIOUT(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_HD_ZAIOUT = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			TNAPR83_InputData.ZAIOUT = ""
			Retn_Code = CHK_ERR_ELSE
			Err_Cd = gc_strMsgTNAPR83_E_005 '���͔͈͊O
		Else
			'�����͈ȊO�̃`�F�b�N��
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgTNAPR83_E_005 '���͔͈͊O
			Else
				
				Select Case Input_Value
					Case CStr(1), CStr(9)
						TNAPR83_InputData.ZAIOUT = Input_Value
						Retn_Code = CHK_OK
						pm_Chk_Move = True
					Case Else
						TNAPR83_InputData.ZAIOUT = ""
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgTNAPR83_E_005 '���͔͈͊O
				End Select
			End If
			
		End If
		'�d���������������������������������������������������������d
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_ZAIOUT = Retn_Code
		
	End Function
	
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_Change
	'   �T�v�F  �Ώۍ��ڂ�CHANGE�̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_Change(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Wk_CurMoji As String
		Dim Wk_Cnt As Short
		Dim Wk_EditMoji As String
		Dim Wk_DspMoji As String
		Dim Move_Flg As Boolean
		
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		Select Case True
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
                '÷���ޯ���̏ꍇ
                '���݂�÷�ď�̑I����Ԃ��擾
                '20190627 CHG START
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '            Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
                ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
                '            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '            Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
                Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
                Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
                Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
                '20190627 CHG END
                Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
				
				'���݂̒l���擾
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
				
				Wk_EditMoji = ""
				
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
					Case IN_TYP_NUM
						'���l���ڂ̏ꍇ
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
					Case IN_TYP_DATE
						'���t���ڂ̏ꍇ
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
					Case IN_TYP_CODE, IN_TYP_STR
						'�R�[�h�A��������
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Select Case pm_Dsp_Sub_Inf.Detail.In_Str_Typ
							'�ύX��̒l�ϊ�
							Case IN_STR_TYP_N
								'�S�p�̏ꍇ
								'���p�󔒁ˑS�p��
								For Wk_Cnt = 1 To Len(Wk_CurMoji)
									If Mid(Wk_CurMoji, Wk_Cnt, 1) = Space(1) Then
										Wk_EditMoji = Wk_EditMoji & "�@"
									Else
										Wk_EditMoji = Wk_EditMoji & Mid(Wk_CurMoji, Wk_Cnt, 1)
									End If
								Next 
								
							Case Else
								'�S�p�ȊO
								'���p�󔒁ˑS�p��
								For Wk_Cnt = 1 To Len(Wk_CurMoji)
									If Mid(Wk_CurMoji, Wk_Cnt, 1) = "�@" Then
										Wk_EditMoji = Wk_EditMoji & Space(2)
									Else
										Wk_EditMoji = Wk_EditMoji & Mid(Wk_CurMoji, Wk_Cnt, 1)
									End If
								Next 
								
						End Select
					Case IN_TYP_YYYYMM
						'�N�����ڂ̏ꍇ
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
						
					Case IN_TYP_HHMM
						'�������ڂ̏ꍇ
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
						
					Case Else
				End Select
				
				'�ҏW��̕�����\���`���ɕϊ�
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, False)
				
				'�I�𕶎��Ɠ��͕����̒u������
				'�����ݒ�
				Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
				
				'����̫����ʒu����E�ֈړ�
				Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, pm_All, True)
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.CheckBox
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.RadioButton
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.PictureBox
				
		End Select
		
		'���͌㏈��
		Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
		'���ד��͌�̌㏈��
		Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_Item_GotFocus
	'   �T�v�F  �Ώۍ��ڂ�GOTFOCUS�̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_GotFocus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Move_Flg As Boolean
		
		If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = False Then
			'̫������󂯎��Ȃ��ꍇ
			'���̍��ڂ�̫����ړ�
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Cursor_Idx), pm_All)
		Else
			
			'�ړ��O�ƈقȂ�ꍇ�̂ݑޔ�
			If pm_All.Dsp_Base.Cursor_Idx <> CShort(pm_Dsp_Sub_Inf.Ctl.Tag) Then
				'�O̫����̲��ޯ����ޔ�
				pm_All.Dsp_Base.Bef_Cursor_Idx = pm_All.Dsp_Base.Cursor_Idx
				'�ړ���̲��ޯ����ޔ�
				pm_All.Dsp_Base.Cursor_Idx = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
			End If
			
			'�I����Ԃ̐ݒ�i�����I���j
			Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
			'���ڐF�ݒ�
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_KeyPress
	'   �T�v�F  �Ώۍ��ڂ�KEYPRESS�̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_KeyPress(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_KeyAscii As Short, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, ByRef pm_Run_Flg As Boolean) As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim All_Sel_Flg As Boolean
		Dim wk_Moji As String
		Dim Wk_SelMoji As String
		Dim Wk_BefMoji As String
		Dim Wk_DelMoji As String
		Dim Wk_EditMoji As String
		Dim Wk_DspMoji As String
		Dim Wk_Cnt As Short
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		Dim Wk_CurMoji As String
		Dim Input_Flg As Boolean
		Dim Re_Body_Crt As Boolean
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		'���̓t���O������
		Input_Flg = False
		'���ו��č쐬�t���O������
		Re_Body_Crt = False
		
		'�ȉ��̓��͂̏ꍇ�A��������
		Select Case pm_KeyAscii
			Case 1 To 7, 9 To 12, 14 To 29, 127
				Beep()
				pm_KeyAscii = 0
				Exit Function
		End Select
		
		'���͕����擾
		wk_Moji = Chr(pm_KeyAscii)
		
		'÷���ޯ���̂ݑΏ�
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then

            '���݂�÷�ď�̑I����Ԃ��擾
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '20190627 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '20190627 CHG END
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			'���݂̒l���擾
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
			
			All_Sel_Flg = False
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
				All_Sel_Flg = True
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB And pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB = 1 Then
					All_Sel_Flg = False
				End If
			End If
			
			'���̓R�[�h����
			If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji) = 1 Then
				'���͉\�����̏ꍇ
				
				'���͉\�ȕ����̏ꍇ�A���͌㏈���A���ו��č쐬���s��
				Input_Flg = True
				Re_Body_Crt = True
				
				'CF_Jge_Input_Str�֐��̕����ύX���l��
				pm_KeyAscii = Asc(wk_Moji)
				
				'���t/�N��/�����ł��I����Ԃ��P�ȊO�̏ꍇ�A���͕s��
				'�\���`�������܂��Ă��邽�߈�����͂�����
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
					Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
						If Act_SelLength <> 1 Then
							Beep()
							pm_KeyAscii = 0
							Exit Function
						End If
				End Select
				
				If All_Sel_Flg = True Then
					'�S�I����
					
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'�l���������l�̏ꍇ
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & wk_Moji
						
					Else
						'�l���������l�ȊO�̏ꍇ
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_EditMoji = wk_Moji & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
						
					End If
					
					'�ҏW��̕�����\���`���ɕϊ�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
					
					'�ҏW���SelStart������
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'�l���������l�̏ꍇ
						'�E�[�ֈړ�
						Wk_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
						Wk_SelLength = 0
					Else
						'�l���������l�ȊO�̏ꍇ
						Wk_SelStart = 0
						Wk_SelLength = 1
					End If
					
					'�폜��̕����u������
					'�����ݒ�
					Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
					pm_KeyAscii = 0

                    '�ҏW���SelStart������
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '20190627 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart + 1
                    ''�ҏW���SelLength������
                    ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart + 1, Wk_SelLength)
                    '20190627 CHG END
                Else
					'�����I���������́A�I���Ȃ�
					
					If Act_SelLength = 0 Then
						'�I���Ȃ��̏ꍇ(�}�����)
						'�}�������̑O�̕������擾
						Wk_BefMoji = Left(Wk_CurMoji, Act_SelStart)
						'���l���ړ��ʏ���
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							Select Case wk_Moji
								Case "+"
									'��{����͎�
									If Trim(Wk_BefMoji) <> "" Then
										'�O��������L�̕����ȊO�͑}���ł��Ȃ�
										'���͕s��
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "-"
									'��|����͎�
									If Trim(Wk_BefMoji) <> "" Then
										'�O��������L�̕����ȊO�͑}���ł��Ȃ�
										'���͕s��
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "."
									'��D����͎�
									If InStr(Wk_CurMoji, ".") > 1 Then
										'���łɢ�D������͂��ꂢ��ꍇ
										'���͕s��
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
							End Select
						End If
						
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
							'�󔒏�����̌��݂̕�����MAX�̏ꍇ�A�I�[�o�[�t���[
							
							'���l���ړ��ʏ���
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								'��ԉE�ŃI�[�o�[�t���[�����ꍇ�A���̍��ڂ�
								If Act_SelStart >= Len(Wk_CurMoji) Then
									'�ҏW�O�̊J�n�ʒu����ԉE�̏ꍇ
									'����̫����ʒu����E�ֈړ�
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								Else
									'���͕s��
									Beep()
								End If
							Else
								
								'�ҏW��̈ړ���𔻒�
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
									'�l���������l�̏ꍇ
								Else
									'�ҏW���SelStart������
									If Act_SelStart + 1 > Len(Wk_CurMoji) Then
										'�P�E�̈ʒu���E�[�̏ꍇ
										Wk_SelStart = Len(Wk_CurMoji)
									Else
										'�P�E��
										Wk_SelStart = Act_SelStart + 1
									End If
									'�ҏW���SelLength������
									Wk_SelLength = 0

                                    '�ҏW���SelStart������
                                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    '20190627 CHG START
                                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                    ''�ҏW���SelLength������
                                    ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                                    '20190627 CHG END
                                End If
								
								'���͕s��
								Beep()
							End If
							
							'���͕s��
							pm_KeyAscii = 0
							Exit Function
						End If
						
						'�����ҏW
						Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Chr(pm_KeyAscii) & Mid(Wk_CurMoji, Act_SelStart + 1)
						
						'�ҏW��̕�����\���`���ɕϊ�
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						
						'���l���ړ��ʏ���
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'�������Ő���������葽�����͂���Ă���ꍇ
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
								'���͕s��
								pm_KeyAscii = 0
								Exit Function
							End If
							
							'�����������菬�������Ɛݒ�l�������ꍇ
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
								'����̫����ʒu����E�ֈړ�
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								'���͕s��
								pm_KeyAscii = 0
								Exit Function
							End If
						End If
						
						'�ҏW���SelStart������
						If Act_SelStart + 1 > Len(Wk_DspMoji) Then
							'�P�E�̈ʒu���E�[�̏ꍇ
							Wk_SelStart = Len(Wk_DspMoji)
						Else
							'�P�E��
							Wk_SelStart = Act_SelStart + 1
						End If
						'�ҏW���SelLength������
						Wk_SelLength = 0
						
						'�폜��̕����u������
						'�����ݒ�
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						pm_KeyAscii = 0

                        '�ҏW���SelStart������
                        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '20190627 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''�ҏW���SelLength������
                        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '20190627 CHG END
                        '�ҏW��̈ړ���𔻒�
                        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'�l���������l�̏ꍇ
							
							If Wk_SelStart >= Len(Wk_DspMoji) Then
								'�ҏW��̊J�n�ʒu����ԉE�̏ꍇ
								'���l���ړ��ʏ���
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
									'�����������菬�������Ɛݒ�l�������ꍇ
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
										'����̫����ʒu����E�ֈړ�
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									Else
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
											'�ҏW��̕�����MAX�̏ꍇ
											'����̫����ʒu����E�ֈړ�
											Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
										End If
									End If
								Else
									'���l���ڈȊO
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
										'�ҏW��̕�����MAX�̏ꍇ
										'����̫����ʒu����E�ֈړ�
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									End If
								End If
							End If
						Else
							'�l���������l�ȊO�̏ꍇ
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                                '�ҏW��̕�����MAX�̏ꍇ

                                '�ҏW���SelStart������
                                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '20190627 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                                ''�ҏW���SelLength������
                                ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(Wk_DspMoji), 1)
                                '20190627 CHG END
                                '����̫����ʒu����E�ֈړ�
                                Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
					Else
						'�ꕔ�I��
						'���ݑI������Ă��镶���̂P�����擾
						Wk_SelMoji = Mid(Wk_CurMoji, Act_SelStart + 1, 1)
						
						If Trim(Wk_SelMoji) <> "" And CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_SelMoji) <> 1 Then
							'�I�𕶎����󕶎��ȊO�ł����͑Ώۂ̕����ȊO�̏ꍇ
							
							'���͕s��
							Beep()
							pm_KeyAscii = 0
							Exit Function
						End If
						
						'���l���ړ��ʏ���
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							Select Case wk_Moji
								Case "+"
									'��{����͎�
									If Wk_SelMoji <> "-" And Wk_SelMoji <> "." And Wk_SelMoji <> "%" And Trim(Wk_SelMoji) <> "" Then
										'�I�𕶎�����L�̕����ȊO�͒u���������Ȃ�
										'���͕s��
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "-"
									'��|����͎�
									If Wk_SelMoji <> "+" And Wk_SelMoji <> "." And Wk_SelMoji <> "%" And Trim(Wk_SelMoji) <> "" Then
										'�I�𕶎�����L�̕����ȊO�͒u���������Ȃ�
										'���͕s��
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "."
									'��D����͎�
									If InStr(Wk_CurMoji, ".") > 0 Then
										'���łɢ�D������͂��ꂢ��ꍇ
										'���͕s��
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
							End Select
						End If
						
						'�����ҏW
						Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Chr(pm_KeyAscii) & Mid(Wk_CurMoji, Act_SelStart + Act_SelLength + 1)
						
						'�ҏW��̕�����\���`���ɕϊ�
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						
						'���l���ړ��ʏ���
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'�����������̏ꍇ
							'����������Ő���������葽�����͂���Ă���ꍇ
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
								'���͕s��
								pm_KeyAscii = 0
								Exit Function
							End If
							
							'�����������菬�������Ɛݒ�l�������ꍇ
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
								'����̫����ʒu����E�ֈړ�
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								'���͕s��
								pm_KeyAscii = 0
								Exit Function
							End If
						End If
						
						If Act_SelStart >= Len(Wk_DspMoji) - 1 Then
							'�ҏW�O�̊J�n�ʒu���Ō�̕����ȍ~�̏ꍇ
							'�ҏW���SelStart������
							Wk_SelStart = Len(Wk_DspMoji)
							'�ҏW���SelLength������
							Wk_SelLength = 0
						Else
							'�ҏW���SelStart������
							Wk_SelStart = Act_SelStart
							'�ҏW���SelLength������
							Wk_SelLength = 1
						End If
						
						'���l���ړ��ʏ���
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							If Len(CF_Get_Input_Ok_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) = 1 Then
								'���͉\�ȕ������P���̏ꍇ
								'�J�n�ʒu����ԉE�ɐݒ�
								'�ҏW���SelStart������
								Wk_SelStart = Len(Wk_DspMoji)
								'�ҏW���SelLength������
								Wk_SelLength = 0
							End If
							
						End If
						
						'�ҏW��̕����u������
						'�����ݒ�
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						pm_KeyAscii = 0

                        '�ҏW���SelStart������
                        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '20190627 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''�ҏW���SelLength������
                        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '20190627 CHG END
                        '�ҏW��̈ړ���𔻒�
                        If Wk_SelStart >= Len(Wk_DspMoji) - 1 Then
							'�ҏW��̊J�n�ʒu���Ō�̕����ȍ~�̏ꍇ
							'���l���ړ��ʏ���
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								
								'�����������菬�������Ɛݒ�l�������ꍇ
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
									'����̫����ʒu����E�ֈړ�
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								Else
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
										'�ҏW��̕�����MAX�̏ꍇ
										'����̫����ʒu����E�ֈړ�
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									End If
								End If
								
							Else
								'���l���ڈȊO
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
									'�ҏW��̕�����MAX�̏ꍇ
									'����̫����ʒu����E�ֈړ�
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								End If
							End If
						Else
							'����̫����ʒu����E�ֈړ�
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						End If
						
					End If
				End If
				
			Else
				'���̓R�[�h�ȊO
				Select Case pm_KeyAscii
					Case System.Windows.Forms.Keys.Back
						'BackSpace�L�[
						pm_KeyAscii = 0
						Input_Flg = True
						
						'���t/�N��/�����̏ꍇ
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
							Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
								'�폜���SelStart������
								Wk_SelStart = Act_SelStart
								For Wk_Cnt = Act_SelStart - 1 To 0 Step -1
									'�팻�݂̊J�n�ʒu���獶�ֈړ������������͑Ώۂ��𔻒�
									If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Mid(Wk_CurMoji, Wk_Cnt + 1, 1)) = 1 Then
										'���͕����łȂ��ꍇ
										Wk_SelStart = Wk_Cnt
										Exit For
									End If
									
								Next 
								'�ҏW���SelLength������
								Wk_SelLength = Act_SelLength

                                '�ҏW���SelStart������
                                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '20190627 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                ''�ҏW���SelLength������
                                ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                                '20190627 CHG END
                                '�폜�s��
                                Exit Function
							Case Else
								
						End Select
						
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'�l���������l�̏ꍇ
							'�J�n�ʒu�����̏ꍇ�A�I��
							If Act_SelStart = 0 Then
								'�폜�s��
								Exit Function
							End If
							
							'�폜�Ώۂ̕����P�����擾
							Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart, 1)
							
							'���l���ړ��ʏ���
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								If Wk_DelMoji = "." Then
									'�폜�Ώۂ̕����������_�̏ꍇ
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									If Len(CF_Get_Num_Int_Part(Wk_CurMoji)) + Len(CF_Get_Num_Fra_Part(Wk_CurMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
										'�폜��̌����I�[�o�[�̏ꍇ
										'�폜�s��
										Exit Function
									End If
								End If
							End If
							
							'�폜�����̔���
							If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_DelMoji) = 1 Then
								'�폜���������͑Ώۂ̕����̏ꍇ
								If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
									'�����ҏW
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1)
								Else
									'�폜�Ώۂ��Ȃ��ׁA�󔒂�ҏW
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
							Else
								'�폜���������͑Ώۂ̕����̈ȊO�ꍇ
								'���̂܂�
								Wk_EditMoji = Wk_CurMoji
							End If
							
							'�폜��̕�����\���`���ɕϊ�
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
							
							'�폜���SelStart������
							Wk_SelStart = Act_SelStart
							For Wk_Cnt = Act_SelStart To Len(Wk_CurMoji) - 1
								'�폜��Ɍ��݂̊J�n�ʒu����̕��������͑Ώۂ��𔻒�
								If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Mid(Wk_DspMoji, Wk_Cnt + 1, 1)) = 1 Then
									Exit For
								End If
								'���͕����łȂ��ꍇ�A�E�ֈړ�
								Wk_SelStart = Wk_SelStart + 1
							Next 
							'�ҏW���SelLength������
							Wk_SelLength = Act_SelLength
							
							'���l���ړ��ʏ���
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								'���l���ڂŖ����͂̏ꍇ�́A��ԉE���J�n�ʒu�ɐݒ�
								If CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf) = "" Then
									Wk_SelStart = Len(Wk_DspMoji)
									'�ҏW���SelLength������
									Wk_SelLength = 0
								End If
							End If
						Else
							'�l���������l�ȊO�̏ꍇ
							If Act_SelStart = 0 Then
								'�J�n�ʒu����ԍ��̏ꍇ
								If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
									'�����ҏW
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									Wk_EditMoji = Right(Wk_CurMoji, Len(Wk_CurMoji) - 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								Else
									'�폜�Ώۂ��Ȃ��ׁA�󔒂�ҏW
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
								
								'�폜���SelStart������
								Wk_SelStart = Act_SelStart
							Else
								'�����ҏW
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								
								'�폜���SelStart������
								Wk_SelStart = Act_SelStart - 1
							End If
							'�ҏW���SelLength������
							Wk_SelLength = Act_SelLength
							
							'�ҏW��̕�����\���`���ɕϊ�
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						End If
						
						'�폜��̕����u������
						'�����ݒ�
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)

                        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '20190627 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '20190627 CHG END
                    Case Else
						pm_KeyAscii = 0
						
				End Select
			End If
		End If
		
		If Input_Flg = True Then
			'���͌㏈��
			Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		End If
		
		If Re_Body_Crt = True Then
			'���ד��͌�̌㏈��
			Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_Item_MouseDown
	'   �T�v�F  �Ώۍ��ڂ�MOUSEDOWN�̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_MouseDown(ByRef pm_Trg_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef pm_Button As Short, ByRef pm_Shift As Short, ByRef pm_X As Single, ByRef pm_Y As Single) As Short
		Dim Wk_Index As Short
		Dim bolSameCtl As Boolean
		
		If pm_Button = VB6.MouseButtonConstants.RightButton Then
			'�E�N���b�N
			
			bolSameCtl = False
			If CShort(pm_Trg_Dsp_Sub_Inf.Ctl.Tag) = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
				'�E�N���b�N�����R���g���[�����A�N�e�B�u�ȃR���g���[���ƈ�v
				'�J�[�\������p�e�L�X�g�Ƀt�H�[�J�X���ꎞ�I�ɑޔ�
				Wk_Index = CShort(FR_SSSMAIN.TX_CursorRest.Tag)
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
				bolSameCtl = True
			End If
			
			'����ړ��e�R�s�[�����
			FR_SSSMAIN.SM_AllCopy.Enabled = CF_Jge_Enabled_SM_AllCopy(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
			
			'����ړ��e�ɓ\��t�������
			FR_SSSMAIN.SM_FullPast.Enabled = CF_Jge_Enabled_SM_FullPast(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
			
			'�ΏۃR���g���[���̎g�p�s��
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = False
			
			'��߯�߱����ƭ������
			If CF_Jge_Enabled_PopupMenu(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All) = True Then
				'۽�̫�������Ă̗}��
				pm_All.Dsp_Base.LostFocus_Flg = True
                '�߯�߱����ƭ��\��
                'UPGRADE_ISSUE: �萔 vbPopupMenuLeftButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
                'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
                '20190625 CHG START
                'FR_SSSMAIN.PopupMenu(FR_SSSMAIN.SM_ShortCut, vbPopupMenuLeftButton)
                FR_SSSMAIN.SM_ShortCut.Show()
                '20190625 CHG END
                '۽�̫�������Ă̗}������
                pm_All.Dsp_Base.LostFocus_Flg = False
				System.Windows.Forms.Application.DoEvents()
			End If
			
			'�߯�߱����ƭ��\����Ԃŉ�ʂ̏I�������ɓ����Ă��܂����ꍇ�́A
			'�ȍ~�̏����͍s��Ȃ��B
			If pm_All.Dsp_Base.IsUnload = True Then
				Exit Function
			End If
			
			'�ΏۃR���g���[���̎g�p��
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = True
			'�t�H�[�J�X���ړ������ɖ߂�
			If bolSameCtl = True Then
				Call CF_Set_Item_SetFocus(pm_Trg_Dsp_Sub_Inf, pm_All)
			End If
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_VS_Scrl_Change
	'   �T�v�F  VS_Scrl��CHANGE�̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_VS_Scrl_Change(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Move_Flg As Boolean
		Dim Row_Move_Value As Short
		Dim Cur_Row As Short
		Dim Next_Row As Short
		Dim Next_Index As Short
		
		'�ŏ㖾�ײ��ޯ����ޔ�
		Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		'�c�X�N���[���o�[�̒l���ŏ㖾�ײ��ޯ���ɐݒ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_All.Dsp_Body_Inf.Cur_Top_Index = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
		'��ʃ{�f�B���̔z����Đݒ�
		Call CF_Dell_Refresh_Body_Inf(pm_All)
		
		'��ʕ\��
		Call CF_Body_Dsp(pm_All)
		
		'��è�޺��۰ق����ו��̂ݐ���
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Act_Dsp_Sub_Inf.Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Act_Dsp_Sub_Inf.Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			
			'���݂̍s���擾
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Act_Dsp_Sub_Inf.Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Cur_Row = pm_Act_Dsp_Sub_Inf.Detail.Body_Index
			'̫�������
			'�ړ���
			Row_Move_Value = Cur_Top_Index - pm_All.Dsp_Body_Inf.Cur_Top_Index
			
			'�ړ���̍s
			Next_Row = Cur_Row + Row_Move_Value
			If Next_Row <= 0 Then
				Next_Row = 1
			End If
			If Next_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
				Next_Row = pm_All.Dsp_Base.Dsp_Body_Cnt
			End If
			
			'�ړ���̍s�̂̓��ꍀ�ڂ̲��ޯ�����擾
			Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Act_Dsp_Sub_Inf, Next_Row, pm_All)
			If Next_Index > 0 Then
				If Next_Index = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
					'������۰ق̏ꍇ
					'�I����Ԃ̐ݒ�i�����I���j
					Call CF_Set_Sel_Ini(pm_Act_Dsp_Sub_Inf, SEL_INI_MODE_2)
					'���ڐF�ݒ�
					Call CF_Set_Item_Color(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
				Else
					'������۰قłȂ��ꍇ
					'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				End If
			Else
				'���͉\�ȍŏ��̃C���f�b�N�X���擾
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Next_Row, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					
					If Row_Move_Value > 0 Then
						'��ֈړ�
						'�w�b�_���̍Ō�̍��ڂ̂P��납��
						'�P�O�̍��ڂ�
						Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), Move_Flg, pm_All)
					Else
						'���ֈړ�
						'�t�b�^���̍ŏ��̍��ڂ̂P�O����
						'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
					End If
				End If
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_Dsp_Body_Page
	'   �T�v�F  ���ו����̃y�[�W����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Dsp_Body_Page(ByRef pm_Page_Value As Short, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Move_Flg As Boolean
		Dim Row_Move_Value As Short
		Dim Cur_Row As Short
		Dim Next_Row As Short
		Dim Next_Index As Short
		
		'�ŏ㖾�ײ��ޯ����ޔ�
		Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		'�ŏ㖾�ײ��ޯ���ɐݒ�
		'�i��ʕ\�����א��|�P�j�~�i�y�[�W���|�P�j�{�P�@�@�˂P�A�U�A�P�P�A�P�U�ƂȂ�
		pm_All.Dsp_Body_Inf.Cur_Top_Index = (pm_All.Dsp_Base.Dsp_Body_Cnt - 1) * (pm_Page_Value - 1) + 1
		'��ʕ\��
		Call CF_Body_Dsp(pm_All)
		
		'��è�޺��۰ق����ו��̂ݐ���
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Act_Dsp_Sub_Inf.Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Act_Dsp_Sub_Inf.Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			
			'���݂̍s���擾
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Act_Dsp_Sub_Inf.Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Cur_Row = pm_Act_Dsp_Sub_Inf.Detail.Body_Index
			'̫�������
			'�ړ���
			Row_Move_Value = Cur_Top_Index - pm_All.Dsp_Body_Inf.Cur_Top_Index
			
			'�ړ���̍s
			Next_Row = Cur_Row + Row_Move_Value
			If Next_Row <= 0 Then
				Next_Row = 1
			End If
			If Next_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
				Next_Row = pm_All.Dsp_Base.Dsp_Body_Cnt
			End If
			
			'�ړ���̍s�̂̓��ꍀ�ڂ̲��ޯ�����擾
			Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Act_Dsp_Sub_Inf, Next_Row, pm_All)
			If Next_Index > 0 Then
				If Next_Index = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
					'������۰ق̏ꍇ
					'�I����Ԃ̐ݒ�i�����I���j
					Call CF_Set_Sel_Ini(pm_Act_Dsp_Sub_Inf, SEL_INI_MODE_2)
					'���ڐF�ݒ�
					Call CF_Set_Item_Color(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
				Else
					'������۰قłȂ��ꍇ
					'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				End If
			Else
				'���͉\�ȍŏ��̃C���f�b�N�X���擾
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Next_Row, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					
					If Row_Move_Value > 0 Then
						'��ֈړ�
						'�w�b�_���̍Ō�̍��ڂ̂P��납��
						'�P�O�̍��ڂ�
						Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), Move_Flg, pm_All)
					Else
						'���ֈړ�
						'�t�b�^���̍ŏ��̍��ڂ̂P�O����
						'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
					End If
				End If
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_MN_Cmn_DE_Focus
	'   �T�v�F  ���j���[�̖��׏������^���׍폜�^���ו������̃t�H�[�J�X����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_Cmn_DE_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Row As Short, ByRef pm_All As Cls_All) As Boolean
		
		Dim Trg_Index As Short
		Dim Move_Flg As Boolean
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		
		'��ʖ��ׂ̍s�Ɠ���̖��ׂ��C���f�b�N�X���擾
		Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_Row, pm_All)
		
		If Trg_Index > 0 Then
			If Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) Then
				'�ړ��悪�����ꍇ
				'�I����Ԃ̐ݒ�i�����I���j
				Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
				'���ڐF�ݒ�
				Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
				
			Else
				'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
				Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Trg_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			End If
			
		Else
			'���͉\�ȍŏ��̃C���f�b�N�X���擾
			Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Row, pm_All)
			If Focus_Ctl_Ok_Fst_Idx > 0 Then
				'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
				Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_MN_Paste
	'   �T�v�F  �\��t��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_Paste(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Clip_Value As String
		Dim Paste_Value As String
		
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		Dim Wk_EditMoji As String
		Dim Wk_CurMoji As String
		Dim Wk_DspMoji As String
		
		'�د���ް�ނ�����e�擾
		'UPGRADE_ISSUE: Clipboard ���\�b�h Clipboard.GetText �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
		Clip_Value = My.Computer.Clipboard.GetText()
		'���͕����\�����o��
		Paste_Value = CF_Get_Input_Ok_Item(Clip_Value, pm_Dsp_Sub_Inf)
		
		'�\��t�����e���Ȃ��ꍇ�A�������f
		If Paste_Value = "" Then
			Exit Function
		End If

        '���݂�÷�ď�̑I����Ԃ��擾
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '20190627 CHG START
        'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
        Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
        Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
        Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
        '20190627 CHG END
        Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
		'���݂̒l���擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Wk_CurMoji = CF_Get_Input_Ok_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
			'�l���������l�̏ꍇ
			
			'�����ҏW
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Wk_EditMoji = CF_Cnv_Dsp_Item(Paste_Value, pm_Dsp_Sub_Inf, False)
			
			'�ҏW���SelStart������
			'�E�[�ֈړ�
			Wk_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
			Wk_SelLength = 0
		Else
			'�l���������l�ȊO�̏ꍇ
			
			If Act_SelLength = 0 Then
				'�I���Ȃ��̏ꍇ(�}�����)
				'�����ҏW
				Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value & Mid(Wk_CurMoji, Act_SelStart + 1)
			Else
				'�ꕔ�I��
				If Act_SelLength >= 2 Then
					'�Q�����ȏ�I�����Ă���ꍇ��
					'�I�𕶎������̕���������
					'�����ҏW
					Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value & Mid(Wk_CurMoji, Act_SelStart + Act_SelLength + 1)
				Else
					'�P�����ȉ��I�����Ă���ꍇ��
					'�I�𕶎��ȍ~�͓��ꊷ��
					'�����ҏW
					Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value
					
				End If
				
			End If
			
			'�ҏW���SelStart������
			'���[�ֈړ�
			Wk_SelStart = 0
			Wk_SelLength = 1
			
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
			Case IN_TYP_DATE
				'���t�̏ꍇ�A���͌`�������܂��Ă���ꍇ
				'���t���͌`���̌��������擾
				Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_DATE))
			Case IN_TYP_YYYYMM
				'�N���̏ꍇ�A���͌`�������܂��Ă���ꍇ
				'���t���͌`���̌��������擾
				Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_YYYMM))
			Case IN_TYP_HHMM
				'�����̏ꍇ�A���͌`�������܂��Ă���ꍇ
				'���t���͌`���̌��������擾
				Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_HHMM))
			Case Else
				
		End Select
		
		'�ҏW��̕�����\���`���ɕϊ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, False)
		
		'��ݼ޲���Ă��N�������ɕҏW
		Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)

        '�ҏW���SelStart������
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '20190627 CHG START
        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
        ''�ҏW���SelLength������
        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
        '2019/06/27 CHG END
        '���͌�̌㏈��
        Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
		'���ד��͌�̌㏈��
		Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Init_Dsp_Body
	'   �T�v�F  �w�肳�ꂽ���ׂ̏����l��ݒ肷��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Item_Input_Aft
	'   �T�v�F  ��ʂō��ړ��͂��ꂽ�ꍇ�̌㏈�����s���܂�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Item_Input_Aft(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		
		Dim Row_Inf_Max_S As Short
		Dim Row_Inf_Max_E As Short
		Dim Bd_Index As Short
		
		'���ׂ̍č쐬���s��
		Call CF_Re_Crt_Body_Inf(pm_Dsp_Sub_Inf, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Befe_Focus
	'   �T�v�F  �O�̃t�H�[�J�X�ʒu�ݒ�(LEFT�Ȃ�)
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Befe_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Lst_Idx As Short
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		'���̍��ڂ�����
		For Index_Wk = Trg_Index - 1 To 1 Step -1
			
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_TL And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'�t�b�^������{�f�B���ֈړ�����ꍇ
				'���͉\�ȍŏ��̃C���f�b�N�X���擾
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					Index_Wk = Focus_Ctl_Ok_Fst_Idx
				End If
				
			End If
			
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD Then
				'�{�f�B������w�b�_���ֈړ�����ꍇ
				If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
					'���ړ������ꍇ�A̫����ړ��\�ȍs�����飏ꍇ
					
					'��ʂ̓��e��ޔ�
					Call CF_Body_Bkup(pm_All)
					'�ړ��\�s����ԏ�ɕ\�������ꍇ�̍ŏ㖾�׃C���f�b�N�X��ݒ�
					pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
					If pm_All.Bd_Vs_Scrl Is Nothing = False Then
						'�c�X�N���[���o�[��ݒ�
						Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
					End If
					'��ʃ{�f�B���̔z����Đݒ�
					Call CF_Dell_Refresh_Body_Inf(pm_All)
					'��ʕ\��
					Call CF_Body_Dsp(pm_All)
					
					'���͉\�ȍŌ�̃C���f�b�N�X���擾
					Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(1, pm_All)
					If Focus_Ctl_Ok_Lst_Idx > 0 Then
						Index_Wk = Focus_Ctl_Ok_Lst_Idx
					End If
					
				End If
			End If
			
			'̫����ړ���OK
			If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
				If pm_Run_Flg = True Then
					'���s�w�肪����ꍇ(��{����)
					'̫����ړ�
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				End If
				'�ړ��t���O����
				pm_Move_Flg = True
				Exit For
			End If
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Next_Focus
	'   �T�v�F  ���̃t�H�[�J�X�ʒu�ݒ�(ENT�ARIGHT�Ȃ�)
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
		Dim Sta_Index As Short
		Dim Index_Wk As Short
		Dim Rtn_Chk As Short
		Dim Bd_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Focus_Ctl_Ok_Lst_Idx As Short
		Dim Focus_Ctl_Ok_Fst_Idx_Wk As Short
		Dim Cur_Top_Index As Short
		Dim intRet As Short
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'�{�f�B��
			'Dsp_Body_Inf�̍s�m�n���擾
			Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
			
			If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW Then
				'�ŏI�����s�̏ꍇ
				'���͉\�ȍŏ��̃C���f�b�N�X���擾
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
				
				If CShort(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Fst_Idx Then
					'���͉\�ȍŏ��̍��ڂ̏ꍇ
					'���[�h�ɂ�茟���J�n�ʒu������
					Select Case pm_Mode
						Case NEXT_FOCUS_MODE_KEYRETURN, NEXT_FOCUS_MODE_KEYDOWN
							'KEYRETURN�AKEYDOWN�̏ꍇ
							'�����J�n�̓t�b�^���̍ŏ��̍��ڂ���
							Sta_Index = pm_All.Dsp_Base.Foot_Fst_Idx
							
						Case NEXT_FOCUS_MODE_KEYRIGHT
							'KEYRIGHT�̏ꍇ
							'�������ޯ���擾
							'�����J�n�͑Ώۂ̍��ڂ̎�
							Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
							
					End Select
				Else
					'�����J�n�͑Ώۂ̍��ڂ̎�
					Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
				End If
				
			Else
				'�ŏI�����s�ȊO�̏ꍇ
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If pm_Dsp_Sub_Inf.Detail.Body_Index = pm_All.Dsp_Base.Dsp_Body_Cnt Then
					'�\������Ă���ŏI�s�̏ꍇ
					'���͉\�ȍŌ�̃C���f�b�N�X���擾
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
					
					If CShort(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Lst_Idx Then
						'���͉\�ȍŌ�̍��ڂ̏ꍇ
						If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
							'�ŏI�����s�ȊO����ʏ�̍ŏI�s���ŏI����
							'����ړ������ꍇ�A̫����ړ��\�ȍs�����飏ꍇ
							
							'��ʂ̓��e��ޔ�
							Call CF_Body_Bkup(pm_All)
							'�ړ��\�s����ԉ��ɕ\�������ꍇ�̍ŏ㖾�׃C���f�b�N�X��ݒ�
							pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
							If pm_All.Bd_Vs_Scrl Is Nothing = False Then
								'�c�X�N���[���o�[��ݒ�
								Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
							End If
							'��ʃ{�f�B���̔z����Đݒ�
							Call CF_Dell_Refresh_Body_Inf(pm_All)
							'��ʕ\��
							Call CF_Body_Dsp(pm_All)
							
							'���ׂP�ԉ��s�̓��͉\�ȍŏ��̃C���f�b�N�X���擾
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Focus_Ctl_Ok_Fst_Idx_Wk = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
							If Focus_Ctl_Ok_Fst_Idx_Wk > 0 Then
								'���ׂP�ԉ��s�̍ŏ��̍��ڂ̈�O���猟��
								Sta_Index = Focus_Ctl_Ok_Fst_Idx_Wk - 1
							Else
								'�����J�n�͑Ώۂ̍��ڂ̎�
								Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
							End If
							
						Else
							'����ړ������ꍇ�A̫����ړ��\�ȍs���Ȃ���ꍇ
							'�����J�n�͑Ώۂ̍��ڂ̎�
							Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
						End If
					Else
						'���͉\�ȍŌ�̍��ڈȊO�̏ꍇ
						'�����J�n�͑Ώۂ̍��ڂ̎�
						Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
					End If
					
				Else
					'�ŏI�s�ȊO�ꍇ
					'�����J�n�͑Ώۂ̍��ڂ̎�
					Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
				End If
			End If
			
		Else
			'�{�f�B���ȊO
			'�����J�n�͑Ώۂ̍��ڂ̎�
			Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
		End If
		
		'���̍��ڂ�����
		For Index_Wk = Sta_Index To pm_All.Dsp_Base.Item_Cnt
			
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'�w�b�_������{�f�B���ֈړ�����ꍇ
				'�r���������������������������������������������������������r
				'ͯ�ޕ�����
				If gv_bolInit = False Then
					Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				Else
					Rtn_Chk = CHK_OK
				End If
				'�d���������������������������������������������������������d
				If Rtn_Chk <> CHK_OK Then
					'�`�F�b�N�m�f�̏ꍇ
					'�L�[�t���O�����ɖ߂�
					gv_bolKeyFlg = False
					Exit For
				End If
			End If
			
			'̫����ړ���OK
			If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
				If pm_Run_Flg = True Then
					'���s�w�肪����ꍇ(��{����)
					'̫����ړ�
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				End If
				'�ړ��t���O����
				pm_Move_Flg = True
				Exit For
			End If
			
		Next 
		
		'�ŏI���ڂ܂Ō����I����
		If Index_Wk > pm_All.Dsp_Base.Item_Cnt Then
			'���[�h�ɂ�茟���I����̏���������
			Select Case pm_Mode
				Case NEXT_FOCUS_MODE_KEYRETURN
					'KEYRETURN�̏ꍇ
					'�r���������������������������������������������������������r
					Call PrintTNAPR83_Main(pm_All, -1)
					'�L�[�t���O�����ɖ߂�
					gv_bolKeyFlg = False
					On Error Resume Next
					FR_SSSMAIN.HD_SOUCD.Focus()
					'�d���������������������������������������������������������d
					pm_Move_Flg = True
				Case NEXT_FOCUS_MODE_KEYRIGHT
					'KEYRIGHT�̏ꍇ
					'�����J�n���ڂőI����Ԃ��ړ�����
					'�I����Ԃ̐ݒ�i�����I���j
					Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_1)
				Case NEXT_FOCUS_MODE_KEYDOWN
					'KEYDOWN�̏ꍇ
					
			End Select
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Left_Next_Focus
	'   �T�v�F  Left�������̃t�H�[�J�X�ʒu�ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Left_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
		Dim Index_Wk As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Str_Wk As String
		Dim Wk_Point As Short
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		'���݂̺��۰ق�÷���ޯ���̏ꍇ
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
            '���݂�÷�ď�̑I����Ԃ��擾
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/06/27 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '2019/06/27 CHG END
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '�l���������l�̏ꍇ
                    '�P�����ڂ�I������
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '20190627 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 0
                    ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(0, 1)
                    '20190627 CHG END
                Else
					'�l���������l�ȊO�̏ꍇ
					'�P�O�̍��ڂ�
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
					
				End If
			Else
				If Act_SelStart = 0 Then
					'�J�n�ʒu����ԍ��̏ꍇ
					'�P�O�̍��ڂ�
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
				Else
					
					'���ɂP�������炵���͉\�ȕ���������
					Wk_SelStart = -1
					For Wk_Point = Act_SelStart - 1 To 0 Step -1
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Wk_Point + 1, 1)
						If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Then
							Wk_SelStart = Wk_Point
							Exit For
						End If
					Next 
					
					If Wk_SelStart = -1 Then
						'�I���\�ȕ������Ȃ��ꍇ
						'�P�O�̍��ڂ�
						Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
					Else
						'�I���\�ȕ���������ꍇ
						If Act_SelStart < Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) And Act_SelLength = 0 Then
							'�ړ��O�̑I���J�n�ʒu����ԉE�ȊO�ł���
							'�I�𕶎������Ȃ��ꍇ�̂݁A
							'�������ڂňړ�����ꍇ�ɑI�𕶎����͌p������
							Wk_SelLength = 0
						Else
							Wk_SelLength = 1
						End If

                        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '20190627 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '20190627 CHG END
                    End If
					
				End If
			End If
		Else
			'���݂̺��۰ق�÷���ޯ���̈ȊO�ꍇ
			'�P�O�̍��ڂ�
			Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Right_Next_Focus
	'   �T�v�F  Right�������̃t�H�[�J�X�ʒu�ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Right_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, ByRef pm_Run_Flg As Boolean) As Short
		Dim Index_Wk As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Str_Wk As String
		Dim Next_SelStart As Short
		Dim Wk_Point As Short
		Dim Wk_SelLength As Short
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		'���݂̺��۰ق�÷���ޯ���̏ꍇ
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
            '���݂�÷�ď�̑I����Ԃ��擾
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '20190627 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            '20190627 CHG END 
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '�l���������l�̏ꍇ
                    '�ŏI������I������
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '20190627 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
                    ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1, 1)
                    '20190627 CHG END
                Else
                    '�l���������l�ȊO�̏ꍇ
                    '�P���ڂ�I������
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '20190627 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 1
                    ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(1, 1)
                    '20190627 CHG END
                End If
			Else
				If Act_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Then
					'�I���J�n�ʒu����ԉE�̏ꍇ
					'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
					Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
				Else
					'�I���J�n�ʒu����ԉE�łȂ��ꍇ
					
					'�P�E�̂P�����擾
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Act_SelStart + 1 + 1, 1)
					
					If Str_Wk = "" Then
						'���̂P�����Ȃ��ꍇ
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                            '�l���������l�̏ꍇ
                            '��ԉE�ֈړ����I���Ȃ���Ԃ�
                            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '20190627 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)), 0)
                            '20190627 CHG END
                        Else
							'�l���������l�ȊO�̏ꍇ
							If Act_SelLength = 0 Then
                                '�ړ��O�̑I�𕶎������Ȃ��ꍇ
                                '��ԉE�ֈړ����I���Ȃ���Ԃ�
                                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '2019/06/27 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                                ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)), 0)
                                '2019/06/27 CHG END
                            Else
								'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
								Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
					Else
						
						'�E�ɂP�������炵���͉\�ȕ���������
						Next_SelStart = -1
						For Wk_Point = Act_SelStart + 1 To Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Step 1
							
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Wk_Point + 1, 1)
							
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
								Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
									'���t/�N��/�������ڂ̏ꍇ
									'���͉\�������Ƌ󔒂��ړ��\
									If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Or Str_Wk = Space(1) Then
										Next_SelStart = Wk_Point
										Exit For
									End If
								Case Else
									'���t/�N��/�������ڈȊO�̏ꍇ
									If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Then
										Next_SelStart = Wk_Point
										Exit For
									End If
									
							End Select
						Next 
						
						If Next_SelStart = -1 Then
							'�I���\�ȕ������Ȃ��ꍇ
							'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
							Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
						Else
							'�I���\�ȕ���������ꍇ
							
							If Act_SelLength = 0 Then
								'�ړ��O�̑I�𕶎������Ȃ��ꍇ
								'�������ڂňړ�����ꍇ�ɑI�𕶎����͌p������
								Wk_SelLength = 0
							Else
								Wk_SelLength = 1
							End If

                            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '20190627 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
                            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Next_SelStart, Wk_SelLength)
                            '20190627 CHG END
                        End If
					End If
				End If
				
			End If
		Else
			'���݂̺��۰ق�÷���ޯ���̈ȊO�ꍇ
			'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
			Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Down_Next_Focus
	'   �T�v�F  Down�������̃t�H�[�J�X�ʒu�ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Down_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Next_Index As Short
		Dim Wk_Cnt As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'���ו��̏ꍇ
			Wk_Cnt = 0
			Do 
				Wk_Cnt = Wk_Cnt + 1
				'���݂̍��ڂɗ񕪂������Ɉړ��������ޯ�������߂�
				Next_Index = Trg_Index + (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)
				
				If Next_Index > pm_All.Dsp_Base.Item_Cnt Then
					'���ڐ��𒴂����ꍇ
					'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
					Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
					Exit Do
				End If
				
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Next_Index).Ctl.Name = pm_Dsp_Sub_Inf.Ctl.Name Then
					'�ړ��悪���ו��ł��ړ��O�Ɠ������۰ٖ��̏ꍇ
					If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
						'̫������n�j
						'�����Ɉړ�
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Next_Index), pm_All)
						pm_Move_Flg = True
						Exit Do
					End If
				Else
					'���̍��ږ������ו��łȂ��ꍇ
					If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
						'����ړ������ꍇ�A̫����ړ��\�ȍs�����飏ꍇ
						'��ʂ̓��e��ޔ�
						Call CF_Body_Bkup(pm_All)
						'�ړ��\�s����ԉ��ɕ\�������ꍇ�̍ŏ㖾�׃C���f�b�N�X��ݒ�
						pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
						If pm_All.Bd_Vs_Scrl Is Nothing = False Then
							'�c�X�N���[���o�[��ݒ�
							Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
						End If
						'��ʕ\��
						Call CF_Body_Dsp(pm_All)
						'���ׂ̈�ԉ��̓��ꍀ�ڂ̲��ޯ�����擾
						Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
						If Next_Index > 0 Then
							If Next_Index = Trg_Index Then
								'������۰ق̏ꍇ
								'�ړ������ŏI��
								pm_Move_Flg = False
								Exit Do
							Else
								'������۰قłȂ��ꍇ
								'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						Else
							'���͉\�ȍŏ��̃C���f�b�N�X���擾
							Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
							If Focus_Ctl_Ok_Fst_Idx > 0 Then
								'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
								Exit Do
							Else
								'�t�b�^���̍ŏ��̍��ڂ̂P�O����
								'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						End If
						
					Else
						'����ړ������ꍇ�A̫����ړ��\�ȍs���Ȃ���ꍇ
						'�t�b�^���̍ŏ��̍��ڂ̂P�O����
						'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
						Exit Do
					End If
				End If
			Loop 
			
		Else
			'���ו��ȊO�̏ꍇ
			'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
			Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Up_Next_Focus
	'   �T�v�F  Up�������̃t�H�[�J�X�ʒu�ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Up_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Next_Index As Short
		Dim Wk_Cnt As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'���ו��̏ꍇ
			Wk_Cnt = 0
			Do 
				Wk_Cnt = Wk_Cnt + 1
				'���݂̍��ڂɗ񕪂�����Ɉړ��������ޯ�������߂�
				Next_Index = Trg_Index - (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)
				
				If Next_Index < 0 Then
					'�}�C�i�X�̏ꍇ
					'�P�O�̍��ڂ�
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
					Exit Do
				End If
				
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Next_Index).Ctl.Name = pm_Dsp_Sub_Inf.Ctl.Name Then
					'�ړ��悪���ו��ł��ړ��O�Ɠ������۰ٖ��̏ꍇ
					If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
						'̫������n�j
						'�����Ɉړ�
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Next_Index), pm_All)
						pm_Move_Flg = True
						Exit Do
					End If
				Else
					'���̍��ږ������ו��łȂ��ꍇ
					If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
						'���ړ������ꍇ�A̫����ړ��\�ȍs�����飏ꍇ
						'��ʂ̓��e��ޔ�
						Call CF_Body_Bkup(pm_All)
						'�ړ��\�s����ԏ�ɕ\�������ꍇ�̍ŏ㖾�׃C���f�b�N�X��ݒ�
						pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
						If pm_All.Bd_Vs_Scrl Is Nothing = False Then
							'�c�X�N���[���o�[��ݒ�
							Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
						End If
						'��ʃ{�f�B���̔z����Đݒ�
						Call CF_Dell_Refresh_Body_Inf(pm_All)
						'��ʕ\��
						Call CF_Body_Dsp(pm_All)
						'���ׂ̈�ԏ�̓��ꍀ�ڂ̲��ޯ�����擾
						Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, 1, pm_All)
						If Next_Index > 0 Then
							If Next_Index = Trg_Index Then
								'������۰ق̏ꍇ
								'�ړ������ŏI��
								pm_Move_Flg = False
								Exit Do
							Else
								'������۰قłȂ��ꍇ
								'���ꍀ�ڂ̂P��납��
								'�P�O�̍��ڂ�
								Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Next_Index + 1), pm_Move_Flg, pm_All)
								Exit Do
							End If
						Else
							'���͉\�ȍŏ��̃C���f�b�N�X���擾
							Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
							If Focus_Ctl_Ok_Fst_Idx > 0 Then
								'���͉\�ȍŏ��̍��ڂ̂P��납��
								'�P�O�̍��ڂ�
								Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx + 1), pm_Move_Flg, pm_All)
								Exit Do
							Else
								'�w�b�_���̍Ō�̍��ڂ̂P��납��
								'�P�O�̍��ڂ�
								Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
								Exit Do
								
							End If
						End If
					Else
						'�w�b�_���̍Ō�̍��ڂ̂P��납��
						'�P�O�̍��ڂ�
						Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
						Exit Do
					End If
					
				End If
			Loop 
		Else
			'���ו��ȊO�̏ꍇ
			'�P�O�̍��ڂ�
			Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Init_Clr_Dsp
	'   �T�v�F  �e��ʂ̍��ڂ�������
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Clr_Dsp(ByRef pm_Index As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Wk_Index_S As Short
		Dim Wk_Index_E As Short
		Dim Now_Dt As Date
		Dim Wk_Mode As Short
		
		'�r���������������������������������������������������������r
		Now_Dt = Now
		'�d���������������������������������������������������������d
		
		If pm_Index = -1 Then
			Wk_Index_S = 1
			Wk_Index_E = pm_All.Dsp_Base.Item_Cnt
			pm_All.Dsp_Base.Head_Ok_Flg = False
			Wk_Mode = ITM_ALL_CLR
		Else
			Wk_Index_S = pm_Index
			Wk_Index_E = pm_Index
			Wk_Mode = ITM_ALL_ONLY
		End If
		
		For Index_Wk = Wk_Index_S To Wk_Index_E
			
			'���ʏ�����
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Index_Wk), Wk_Mode, pm_All)
			
			'�S�̏������̏ꍇ
			If Wk_Mode = ITM_ALL_CLR Then
				'�t�b�^���ȍ~�̍��ڂ�S̫����Ȃ��Ƃ���
				If Index_Wk > pm_All.Dsp_Base.Foot_Fst_Idx Then
					Call CF_Set_Item_Focus_Ctl(False, pm_All.Dsp_Sub_Inf(Index_Wk))
				End If
			End If
			
			'�r���������������������������������������������������������r
			'�ʏ�����
			Select Case Index_Wk
				Case CShort(FR_SSSMAIN.HD_SOUCD.Tag)
					'�q��
					'������ʕҏW���A�l�������Ă��Ȃ����ߕҏW��
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Len(Trim(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value)) = 0 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value = "" 'gv_strInitYM
					End If
					Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item("", pm_All.Dsp_Sub_Inf(Index_Wk), False), pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				Case CShort(FR_SSSMAIN.HD_ZAIOUT.Tag)
					'������ʕҏW���A�l�������Ă��Ȃ����ߕҏW��
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Len(Trim(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value)) = 0 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value = "1" 'gv_strInitYM
					End If
					Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item("1", pm_All.Dsp_Sub_Inf(Index_Wk), False), pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
			End Select
			'�d���������������������������������������������������������d
			
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Init_Clr_Dsp_Body
	'   �T�v�F  �e��ʂ̃{�f�B���ڂ�������
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Clr_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		'
		'    Dim Index_Bd_Wk         As Integer
		'    Dim Wk_Bd_Index_S       As Integer
		'    Dim Wk_Bd_Index_E       As Integer
		'    Dim Wk_Mode             As Integer
		'    Dim Wk_Index            As Integer
		'    Dim Wk_Row              As Integer
		'
		'    If pm_Bd_Index = -1 Then
		'        Wk_Bd_Index_S = 1
		'        Wk_Bd_Index_E = pm_All.Dsp_Base.Dsp_Body_Cnt
		'
		'        '��ʃ{�f�B���
		'        ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
		'
		''�r���������������������������������������������������������r
		'        '�X�N���[��������
		'        '�ő�l
		'        Call CF_Set_VScrl_Max(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		'        '�ŏ��l
		'        Call CF_Set_VScrl_Min(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		'        '�ő彸۰ٗ�
		'        Call CF_Set_VScrl_LargeChange(pm_All.Dsp_Base.Dsp_Body_Move_Qty, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		'        '�ŏ���۰ٗ�
		'        Call CF_Set_VScrl_SmallChange(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		'        '�����l
		'        Call CF_Set_Item_Direct(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		''�d���������������������������������������������������������d
		'        Wk_Mode = BODY_ALL_CLR
		'    Else
		'        Wk_Bd_Index_S = pm_Bd_Index
		'        Wk_Bd_Index_E = pm_Bd_Index
		'        Wk_Mode = BODY_ALL_ONLY
		'    End If
		'
		'    For Index_Bd_Wk = Wk_Bd_Index_S To Wk_Bd_Index_E
		'
		'        '���ʏ�����
		'        Call CF_Init_Clr_Dsp_Body(Index_Bd_Wk, Wk_Mode, pm_All)
		'
		'        '�z��O�̏�������Ώۍs�ɃR�s�[
		'        Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk))
		'
		'        '�S�̏������̏ꍇ
		'        If Wk_Mode = BODY_ALL_CLR Then
		'            '�S�s�������
		'            pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk).Status = BODY_ROW_STATE_DEFAULT
		'        End If
		'
		'        '�ʏ�����
		''�r���������������������������������������������������������r
		'        '�ȉ��̺��۰ق͖��ו����̺��۰قł���΂Ȃ�ł��n�j�ł�
		'        '(�Ώۂ̖��ׂ̔ԍ���񂾂����K�v�A)
		'        Wk_Index = CInt(FR_SSSMAIN.BD_LINNO(Index_Bd_Wk).Tag)
		''�d���������������������������������������������������������d
		'        'Dsp_Body_Inf�̍s�m�n�ɕϊ�
		'        Wk_Row = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
		''�r���������������������������������������������������������r
		'        'Dsp_Body_Inf�ɒl�������l��ݒ�
		'        Call F_Init_Dsp_Body(Wk_Row, pm_All)
		''�d���������������������������������������������������������d
		'
		'    Next
		'
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Init_Cursor_Set
	'   �T�v�F  ��ʏ�����Ԏ��̃t�H�[�J�X�ʒu�ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Cursor_Set(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		'�r���������������������������������������������������������r
		'�e��ʌʐݒ�(�K��DSP_SUB_INF.Detail.Focus_Ctl=True�̍��ځI�I)
		'���͒S���҃R�[�h�i�����j�Ƀt�H�[�J�X�ݒ�
		'�������ޯ���擾
		Trg_Index = CShort(FR_SSSMAIN.HD_SOUCD.Tag)
		
		'̫����ړ�
		Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		'�I����Ԃ̐ݒ�i�����I���j
		Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
		'���ڐF�ݒ�
		Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
		
		'�d���������������������������������������������������������d
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_Jge_Action
	'   �T�v�F  �e�`�F�b�N�֐��̃`�F�b�N�O��
	'�@�@�@�@�@ �`�F�b�N���s�𔻒�
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_From_Process�@�@�@ :�ďo������
	'           pm_Err_Rtn�@�@     �@ :�G���[�ߒl
	'           pm_Msg_Flg�@�@     �@ :���b�Z�[�W�t���O
	'           pm_Move�@�@�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_Jge_Action(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Err_Rtn As Short, ByRef pm_Msg_Flg As Boolean, ByRef pm_Move As Boolean) As Short
		Dim Rtn_Cd As Short
		
		'���s
		Rtn_Cd = CHK_KEEP
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
			Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'�O��Ɠ����`�F�b�N���e�̏ꍇ
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
						'���ڂ̃X�e�[�^�X���G���[�Ȃ�
						'���f
						Rtn_Cd = CHK_STOP
						'���b�Z�[�W��\��
						pm_Msg_Flg = False
						'�ړ���
						pm_Move = True
						'�`�F�b�N�n�j
						pm_Err_Rtn = CHK_OK
					End If
				End If
				
			Case CHK_FROM_KEYPRESS
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'�O��Ɠ����`�F�b�N���e�̏ꍇ
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
						'���ڂ̃X�e�[�^�X���G���[�Ȃ�
						'���f
						Rtn_Cd = CHK_STOP
						'���b�Z�[�W��\��
						pm_Msg_Flg = False
						'�ړ���
						pm_Move = True
						'�`�F�b�N�n�j
						pm_Err_Rtn = CHK_OK
					End If
					
				End If
				
			Case CHK_FROM_KEYRETURN
				'�KEYRETURN�
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'�O��Ɠ����`�F�b�N���e�̏ꍇ
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
						'���ڂ̃X�e�[�^�X���G���[�Ȃ�
						'���f
						Rtn_Cd = CHK_STOP
						'���b�Z�[�W��\��
						pm_Msg_Flg = False
						'�ړ���
						pm_Move = True
						'�`�F�b�N�n�j
						pm_Err_Rtn = CHK_OK
					End If
					
				End If
				
			Case CHK_FROM_ALL_CHK
				'�ꊇ�`�F�b�N�Ȃǣ
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'�O��Ɠ����`�F�b�N���e�̏ꍇ
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT And pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True Then
						'���ڂ̃X�e�[�^�X���G���[�Ȃ��ł������͈ȊO�̃`�F�b�N���s���Ă���ꍇ
						'���f
						Rtn_Cd = CHK_STOP
						'���b�Z�[�W��\��
						pm_Msg_Flg = False
						'�ړ���
						pm_Move = True
						'�`�F�b�N�n�j
						pm_Err_Rtn = CHK_OK
					End If
					
				End If
				
		End Select
		
		If Rtn_Cd = CHK_STOP Then
			'�`�F�b�N�𒆒f
			'�`�F�b�N�֐��ďo���������N���A
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
		End If
		
		F_Chk_Jge_Action = Rtn_Cd
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_Jge_Msg_Move
	'   �T�v�F  �e�`�F�b�N�֐��̃`�F�b�N���
	'�@�@�@�@�@ ���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_From_Process�@�@�@ :�ďo������
	'           pm_Err_Rtn�@�@     �@ :�G���[�ߒl
	'           pm_Msg_Flg�@�@     �@ :���b�Z�[�W�t���O
	'           pm_Move�@�@�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_Jge_Msg_Move(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Err_Rtn As Short, ByRef pm_Msg_Flg As Boolean, ByRef pm_Move As Boolean) As Short
		
		'���b�Z�[�W�\���Ȃ�
		pm_Msg_Flg = False
		'�ړ���
		pm_Move = True
		
		If pm_Err_Rtn = CHK_OK Then
			'�`�F�b�N�n�j
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
		Else
			
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
				Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'�K�{���͂Ŗ�����
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'�P�x�������͈ȊO�`�F�b�N�����Ă��Ȃ��ꍇ
								'�`�F�b�N�n�j�Ƃ���
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							Else
								'�P�x�ł������̓`�F�b�N�����Ă���ꍇ
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
									'�O��Ɠ����`�F�b�N���e�̏ꍇ
									'�`�F�b�N�G���[�Ƃ���
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
									'���b�Z�[�W�o�͂Ȃ�
									pm_Msg_Flg = False
									'�ړ��n�j
									pm_Move = True
								Else
									'�O��ƈقȂ�`�F�b�N���e�̏ꍇ
									'�`�F�b�N�G���[�Ƃ���
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
									'���b�Z�[�W�o�͂Ȃ�
									pm_Msg_Flg = False
									'�ړ��n�j
									pm_Move = False
								End If
								
							End If
						Case CHK_ERR_ELSE
							'���̑��G���[��
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
								'�O��Ɠ����`�F�b�N���e�̏ꍇ
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							Else
								'�O��ƈقȂ�`�F�b�N���e�̏ꍇ
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
								'���b�Z�[�W�o�͂���
								pm_Msg_Flg = True
								'�ړ��n�j
								pm_Move = False
							End If
							
					End Select
					
				Case CHK_FROM_KEYPRESS
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'�K�{���͂Ŗ�����
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'�P�x�������͈ȊO�`�F�b�N�����Ă��Ȃ��ꍇ
								'�`�F�b�N�n�j�Ƃ���
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							Else
								'�P�x�ł������̓`�F�b�N�����Ă���ꍇ
								'�`�F�b�N�G���[�Ƃ���
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							End If
						Case CHK_ERR_ELSE
							'���̑��G���[��
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'���b�Z�[�W�o�͂���
							pm_Msg_Flg = True
							'�ړ��m�f
							pm_Move = False
							
					End Select
					
				Case CHK_FROM_KEYRETURN
					'�KEYRETURN�
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'�K�{���͂Ŗ�����
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'�P�x�������͈ȊO�`�F�b�N�����Ă��Ȃ��ꍇ
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							Else
								'�P�x�ł������̓`�F�b�N�����Ă���ꍇ
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
								'���b�Z�[�W�o�͂���
								pm_Msg_Flg = True
								'�ړ��m�f
								pm_Move = False
							End If
							
						Case CHK_ERR_ELSE
							'���̑��G���[��
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'���b�Z�[�W�o�͂���
							pm_Msg_Flg = True
							'�ړ��m�f
							pm_Move = False
							
					End Select
				Case CHK_FROM_ALL_CHK
					
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'�K�{���͂Ŗ�����
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
							'���b�Z�[�W�o�͂���
							pm_Msg_Flg = True
							'�ړ��m�f
							pm_Move = False
							
						Case CHK_ERR_ELSE
							'���̑��G���[��
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'���b�Z�[�W�o�͂���
							pm_Msg_Flg = True
							'�ړ��m�f
							pm_Move = False
							
					End Select
					
			End Select
			
		End If
		
		'�`�F�b�N�֐��ďo���������N���A
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_Item_Detail
	'   �T�v�F  �e���ڂ̉�ʕ\��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_Item_Detail(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			'�r���������������������������������������������������������r
			Case FR_SSSMAIN.HD_SOUCD.Name
				'�S���҃R�[�h�ɂ���ʕ\��
				Call F_Dsp_HD_SOUCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				'�d���������������������������������������������������������d
				
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_HD_SOUCD_Inf
	'   �T�v�F  �S���҃R�[�h�ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   : ��ʍ��ڏ��
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_SOUCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'�r���������������������������������������������������������r
				'�y�S���Җ��z
				Trg_Index = CShort(FR_SSSMAIN.HD_SOUNM.Tag)
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(TNAPR83_InputData.SOUNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'�d���������������������������������������������������������d
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'�N���A
			'�r���������������������������������������������������������r
			'�y�S���Җ��z
			Trg_Index = CShort(FR_SSSMAIN.HD_SOUNM.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'�d���������������������������������������������������������d
		End If
		
		'�O��`�F�b�N���e�ɑޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Item_Chk
	'   �T�v�F  �e���ڂ�����ٰ�ݐ���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Item_Chk(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Process As String, ByRef pm_Chk_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Rtn_Chk As Short
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_OK
		pm_Chk_Move_Flg = True
		
		'�@��{���͓��e�̃`�F�b�N
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			'�r���������������������������������������������������������r
			
			Case FR_SSSMAIN.HD_SOUCD.Name
				'�S���҃R�[�h
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'����
				Rtn_Chk = F_Chk_HD_SOUCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
			Case FR_SSSMAIN.HD_ZAIOUT.Name
				'�݌ɏo�̓t���O
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'����
				Rtn_Chk = F_Chk_HD_ZAIOUT(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
		End Select
		'�d���������������������������������������������������������d
		
		F_Ctl_Item_Chk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Head_Chk
	'   �T�v�F  ͯ�ޕ�������ٰ�ݐ���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Head_Chk(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		Dim intMoveFocus As Short
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_OK
		
		'�w�b�_���̍ŏI���ڂ܂Ŋe���ڂ��������s��
		For Index_Wk = 1 To pm_All.Dsp_Base.Head_Lst_Idx
			
			'�e����������S�������Ƃ��Čďo
			Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Index_Wk), CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
			
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
			Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Index_Wk), Dsp_Mode, pm_All)
			
			'�`�F�b�N�m�f
			If Rtn_Chk <> CHK_OK Then
				
				'�����̓��b�Z�[�W
				'            If Rtn_Chk = CHK_ERR_NOT_INPUT Then
				'                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgMITET51_E_011, pm_All)
				'            End If
				
				'������ړ��Ȃ�
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				
				F_Ctl_Head_Chk = Rtn_Chk
				Exit Function
			End If
		Next 
		
		'�֘A����
		'�r���������������������������������������������������������r
		Rtn_Chk = F_Ctl_Head_RelChk(pm_All, intMoveFocus)
		'�`�F�b�N�m�f
		If Rtn_Chk <> CHK_OK Then
			
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(intMoveFocus), pm_All)
			
			F_Ctl_Head_Chk = Rtn_Chk
			Exit Function
		End If
		'�d���������������������������������������������������������d
		
		If Rtn_Chk = CHK_OK And pm_All.Dsp_Base.Head_Ok_Flg = False Then
			'�`�F�b�N�n�j�ł���
			'�w�b�_���̃`�F�b�N�����߂Ă̏ꍇ
			'        '�P�s�ڂ̃{�f�B���������ŏI�s�Ƃ��ĊJ������
			'        pm_All.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW
			'�t�b�^�����J������
			Call F_Foot_In_Ready(pm_All)
			'�`�F�b�N�n�j
			pm_All.Dsp_Base.Head_Ok_Flg = True
		End If
		
		F_Ctl_Head_Chk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Head_RelChk
	'   �T�v�F  ͯ�ޕ��̊֘A����
	'   �����F�@pm_ErrIdx : �G���[�������̃t�H�[�J�X�ړ��Ώہi�[��:�Č�ID�ֈړ��j
	'   �ߒl�F�@CHK_OK:�`�F�b�NOK�@CHK_ERR_ELSE:���̑��G���[
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Head_RelChk(ByRef pm_All As Cls_All, ByRef pm_ErrIdx As Short) As Short
		
		Dim Index_Wk As Short
		Dim Rtn_Chk As Short
		Dim Trg_IndexStt As Short
		Dim ValueStt As String
		Dim ValueEnd As String
		Dim Err_Cd As String '�G���[�R�[�h
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_ERR_ELSE
		Err_Cd = ""
		pm_ErrIdx = CShort(FR_SSSMAIN.HD_SOUCD.Tag)
		
		Rtn_Chk = CHK_OK
		
F_Ctl_Head_RelChk_END: 
		
		If Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Ctl_Head_RelChk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Body_Chk
	'   �T�v�F  ���ި��������ٰ�ݐ���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Body_Chk(ByRef pm_All As Cls_All) As Short
		'
		'    Dim Index_Wk_Col    As Integer
		'    Dim Index_Wk_Row    As Integer
		'    Dim Trg_Index       As Integer
		'    Dim Rtn_Chk         As Integer
		'    Dim Chk_Move_Flg    As Boolean
		'    Dim Dsp_Sub_Inf_Wk  As Cls_Dsp_Sub_Inf
		'    Dim Dsp_Mode        As Integer
		'
		'    Dim Err_Row         As Integer
		'    Dim Err_Dsp_Sub_Inf_Wk  As Cls_Dsp_Sub_Inf
		'    Dim Bd_Idx          As Integer
		'    Dim Err_Index       As Integer
		'    Dim Move_Flg        As Boolean
		'    Dim Focus_Ctl_Ok_Fst_Idx As Integer
		'
		'
		'    '�e�����֐��Ɠ����ߒl
		'    Rtn_Chk = CHK_OK
		'
		'    '�{�f�B���̍ŏI���ڂ܂Ŋe���ڂ��������s��
		'    For Index_Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		'
		'        Select Case pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Status
		'            Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT
		'                '���͑ҏ�ԁA���͍Ϗ�ԏ�Ԃ�Ώ�
		'
		'                For Index_Wk_Col = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail)
		'
		'                    '��ʖ��ׂ̉B�s�̍��ڂ̲��ޯ�����擾
		'                    Trg_Index = CF_Get_Idex_Same_Bd_Ctl_Hide_Row( _
		''                                  pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Item_Nm _
		''                                , pm_All)
		'
		'                    '���[�N�̢��ʍ��ڏ��ɉB�s���۰ق�����
		'                    Set Dsp_Sub_Inf_Wk.Ctl = pm_All.Dsp_Sub_Inf(Trg_Index).Ctl
		'
		'                    '���[�N�̢��ʍ��ڏ��ɢ��ʃ{�f�B����ҏW
		'                    Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Dsp_Value _
		''                                          , Dsp_Sub_Inf_Wk _
		''                                          , pm_All)
		'                    '��ʍ��ڏڍ׏���ݒ�
		'                    Dsp_Sub_Inf_Wk.Detail = pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col)
		'
		'                    '�e����������S�������Ƃ��Čďo
		'                    Rtn_Chk = F_Ctl_Item_Chk(Dsp_Sub_Inf_Wk, CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
		'
		'                    If Rtn_Chk = CHK_OK Then
		'                    '�`�F�b�N�n�j��
		'                        '�擾���e�\��
		'                        Dsp_Mode = DSP_SET
		'                    Else
		'                    '�`�F�b�N�m�f��
		'                        '�擾���e�N���A
		'                        Dsp_Mode = DSP_CLR
		'                    End If
		'                    '�擾���e�\��/�N���A
		'                    Call F_Dsp_Item_Detail(Dsp_Sub_Inf_Wk, Dsp_Mode, pm_All)
		'
		'                    '���ʃ{�f�B���Ƀ��[�N�̢��ʍ��ڏ���ҏW
		'                    '��ʍ��ڏڍ׏���ݒ�
		'                    '�����ɂ���ĕύX����鍀�ڂ̂�
		'                    Call CF_Dsp_Sub_Inf_To_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col) _
		''                                                      , Dsp_Sub_Inf_Wk.Detail)
		'
		'                    '�`�F�b�N�m�f
		'                    If Rtn_Chk <> CHK_OK Then
		'
		'                        '�G���[�̏ꍇ�A�Ώۍs��\����̫����ړ�����
		'                        '�G���[�p�ϐ��i�[
		'                        '�s���
		'                        Err_Row = Index_Wk_Row
		'                        '�Ώۺ��۰ُ��
		'                        Set Err_Dsp_Sub_Inf_Wk.Ctl = Dsp_Sub_Inf_Wk.Ctl
		'                        '��ʍ��ڏڍ׏���ݒ�
		'                        Err_Dsp_Sub_Inf_Wk.Detail = Dsp_Sub_Inf_Wk.Detail
		'
		'                        GoTo ERR_EXIT
		'                    End If
		'
		'                Next
		'        End Select
		'    Next
		'
		'
		''    '�֘A����
		''    Rtn_Chk = F_Ctl_Body_RelChk(pm_All)
		'    '�`�F�b�N�m�f
		'    If Rtn_Chk <> CHK_OK Then
		'
		'        '������ړ��Ȃ�
		''            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
		'
		'        F_Ctl_Body_Chk = Rtn_Chk
		'        Exit Function
		'    End If
		'
		'
		'    F_Ctl_Body_Chk = Rtn_Chk
		'
		'    Exit Function
		'
		'ERR_EXIT:
		''�G���[���A̫����ړ�
		'    '�Ώۍs����ʂɕ\��
		'    Call CF_Body_Dsp_Trg_Row(pm_All, Err_Row)
		'    '�Ώۍs�����ʖ��ׂ̍s���擾
		'    Bd_Idx = CF_Idx_To_Bd_Idx(Err_Row, pm_All)
		'    '��ʖ��ׂ̍s�Ɠ���̖��ׂ��C���f�b�N�X���擾
		'    Err_Index = CF_Get_Idex_Same_Bd_Ctl(Err_Dsp_Sub_Inf_Wk, Bd_Idx, pm_All)
		'
		'     If Err_Index > 0 Then
		'        '���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
		'        Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Err_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
		''        '�I����Ԃ̐ݒ�i�����I���j
		''        Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Err_Index - 1), SEL_INI_MODE_2)
		''        '���ڐF�ݒ�
		''        Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Err_Index - 1), ITEM_NORMAL_STATUS, pm_All)
		'
		'    Else
		'        '���͉\�ȍŏ��̃C���f�b�N�X���擾
		'        Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Err_Row, pm_All)
		'        If Focus_Ctl_Ok_Fst_Idx > 0 Then
		'            '���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
		'            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
		'        End If
		'    End If
		'
		'    F_Ctl_Body_Chk = Rtn_Chk
		'    Exit Function
		'
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Foot_In_Ready
	'   �T�v�F  �t�b�^���̓��͏���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Foot_In_Ready(ByRef pm_All As Cls_All) As Short
		'
		'    Dim Index_Wk        As Integer
		'
		'    '�t�b�^�����ŏ���
		'    For Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx To pm_All.Dsp_Base.Item_Cnt
		'        Select Case pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.NAME
		''�r���������������������������������������������������������r
		'            Case FR_SSSMAIN.TL_NHSCD.NAME _
		''               , FR_SSSMAIN.TL_NOKDTPRT.NAME _
		''               , FR_SSSMAIN.TL_YUKODT.NAME _
		''               , FR_SSSMAIN.TL_DENCMA.NAME _
		''               , FR_SSSMAIN.TL_TFPATH.NAME _
		''               , FR_SSSMAIN.TL_SBAMITKN.NAME
		''�d���������������������������������������������������������d
		'            '������Ԃœ��͉\�Ⱥ��۰�
		'                '���͉\
		'                Call CF_Set_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Index_Wk))
		'        End Select
		'    Next
		'
	End Function
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_MitList_PrtMain
	'   �T�v�F  �I�������\�o�͏o�͏���
	'   �����F�@pm_TNAPR83Data      ��ʓ��̓f�[�^
	'           pm_intMode          1:�v�����^�o��  2:��ʕ\��  3:�t�@�C���o��
	'   �ߒl�F�@0:����I��  1:���ň����  3:�Y���f�[�^���� 5:���f 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function PrintTNAPR83_Main(ByRef pm_All As Cls_All, ByRef pm_intMode As Short) As Short
		
		Dim intRet As Short
		Dim intRet2 As Short
		Dim intMode As Short
		Dim bolRet As Boolean
		Dim bolTrans As Boolean
		Dim strPrtSeq As String
		Dim strSQL As String
		Dim strMsgCd As String
		Dim bolOraErr As Boolean
        '20190625 CHG START
        'Dim intCursor As Short
        Dim intCursor As Cursor
        '20190625 CHG END
        Dim strLIST_ID As String

        bolTrans = False
		
		'���łɈ�����J�n���Ă���ꍇ�͏������s���Ȃ�
		If gv_bolNowPrinting = True Then
			Exit Function
		End If
		
		'������t���O�Z�b�g
		gv_bolNowPrinting = True
		
		PrintTNAPR83_Main = 9
		
		SSS_LSTOP = False
		strMsgCd = ""
		bolOraErr = False

        '�{�^���̎g�p�^�s��
        '20190628 DEL START
        'FR_SSSMAIN.MN_LSTART.Enabled = False
        'FR_SSSMAIN.MN_VSTART.Enabled = False
        'FR_SSSMAIN.CM_LSTART.Visible = False
        'FR_SSSMAIN.CM_VSTART.Visible = False
        '20190628 DEL END
        'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.CM_LCANCEL.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        FR_SSSMAIN.CM_LCANCEL.Enabled = True
		
		'�J�[�\���ޔ�
		intCursor = FR_SSSMAIN.Cursor
		FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.WaitCursor
		
		'�w�b�_���̃`�F�b�N
		intRet = F_Ctl_Head_Chk(pm_All)
		If intRet <> CHK_OK Then
			'�`�F�b�N�m�f�̏ꍇ
			GoTo Error_Handler
		End If
		
		'���[�h�Ȃ��̏ꍇ�A�I����ʕ\��
		If pm_intMode = -1 Then
			
			gv_bolTNAPR83_LF_Enable = False
			
			System.Windows.Forms.Application.DoEvents()
			
			DLGLST02_ACE.ShowDialog()
			'UPGRADE_WARNING: �I�u�W�F�N�g SSS_RTNWIN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			intMode = SSS_RTNWIN + 1
			
			gv_bolTNAPR83_LF_Enable = True
		Else
			intMode = pm_intMode
		End If
		
		If intMode <> SSS_PRINTER And intMode <> SSS_VIEW And intMode <> SSS_FILE Then
			'���f
			PrintTNAPR83_Main = 0
			GoTo Exit_Handler
		End If
		
		'***�X�V����***
		
		'�Q�[�W�̏�����
		Call InitGauge()
		Call ShowGauge(True)

        'USR9�Ńg�����U�N�V�����J�n
        '20190627 CHG START
        '      bolRet = CF_Ora_BeginTrans(gv_Oss_USR1)
        'If Not bolRet Then
        '	strMsgCd = gc_strMsgTNAPR83_E_010
        '	bolOraErr = True
        '	GoTo Error_Handler
        'End If
        bolRet = DB_BeginTrans(CON)
        If bolRet = False Then
            strMsgCd = gc_strMsgTNAPR83_E_010
            bolOraErr = True
            GoTo Error_Handler
        End If
        '20190627 CHG END
        bolTrans = True
		
		'�r�d�p�̎擾
		'    strPrtSeq = GetPrtSeq()
		'    If strPrtSeq = "" Then
		'        strMsgCd = gc_strMsgTNAPR83_E_007
		'        bolOraErr = True
		'        Exit Function
		'    End If
		strLIST_ID = "TNAPR83"
		'���[�p���[�N�쐬�����̌Ăяo���iPLSQL�j
		Call F_Execute_PLSQL()
		If Not bolRet Then
			strMsgCd = gc_strMsgTNAPR83_E_008
			bolOraErr = True
			GoTo Error_Handler
		End If
		
		'�Q�[�W�̍X�V
		Call RefreshGauge(1, 1)
		
		If SSS_LSTOP = False Then
			'�R�~�b�g
			bolRet = CF_Ora_CommitTrans(gv_Oss_USR1)
			If Not bolRet Then
				strMsgCd = gc_strMsgTNAPR83_E_010
				bolOraErr = True
				GoTo Error_Handler
			End If
			bolTrans = False
			
			'���[�o��
			intRet = OutPutList_Main(intMode, strLIST_ID, "", strPrtSeq)
			If intRet <> 0 Then
				PrintTNAPR83_Main = intRet
				Select Case intRet
					Case 1 '���ň����
						'���b�Z�[�W�o�͍ς�
					Case 2 '�L�����Z��
						strMsgCd = gc_strMsgTNAPR83_I_004
					Case 3 '�f�[�^�Ȃ�
						strMsgCd = gc_strMsgTNAPR83_E_006
					Case Else '����ȊO
						strMsgCd = gc_strMsgTNAPR83_E_011
				End Select
				GoTo Error_Handler
			End If
			
		Else
			'�������f
			'���[���o�b�N
			If bolTrans Then
				Call CF_Ora_RollbackTrans(gv_Oss_USR1)
			End If
			bolTrans = False
		End If
		
		PrintTNAPR83_Main = 0
		
Exit_Handler: 
		'���b�Z�[�W�̕\��
		If strMsgCd <> "" Then
			If bolOraErr Then
				Call AE_CmnMsgLibrary(SSS_PrgNm, strMsgCd, pm_All, "PrintTNAPR83_Main")
			Else
				Call AE_CmnMsgLibrary(SSS_PrgNm, strMsgCd, pm_All)
			End If
		End If

        '�{�^���̎g�p�^�s��
        'FR_SSSMAIN.MN_LSTART.Enabled = True
        'FR_SSSMAIN.MN_VSTART.Enabled = True
        'FR_SSSMAIN.CM_LSTART.Visible = True
        'FR_SSSMAIN.CM_VSTART.Visible = True
        'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.CM_LCANCEL.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        FR_SSSMAIN.CM_LCANCEL.Enabled = False
		
		'�J�[�\����߂�
		'UPGRADE_ISSUE: Form �v���p�e�B FR_SSSMAIN.MousePointer �̓J�X�^�� �}�E�X�|�C���^���T�|�[�g���܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' ���N���b�N���Ă��������B
		FR_SSSMAIN.Cursor = intCursor
		
		'�Q�[�W�̏�����
		Call InitGauge()
		Call ShowGauge(False)
		
		'������t���O�Z�b�g
		gv_bolNowPrinting = False
		
		Exit Function
		
Error_Handler: 
		
		'���[���o�b�N
		If bolTrans Then
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		bolTrans = False
		
		GoTo Exit_Handler
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Execute_PLSQL
	'   �T�v�F  SQL���s����
	'   �����F  �Ȃ�
	'   �ߒl�F  0 : ���� 9: �ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Execute_PLSQL() As Short
		
		
		Dim strSQL As String 'SQL��
		
		Dim strPara1 As String '���Ұ�1(�S���Һ���)
		Dim strPara2 As String '���Ұ�2(�ײ���ID)
		Dim strPara3 As String '���Ұ�4(�q�ɺ���)
		Dim strPara4 As String '���Ұ�4(�݌ɐ��o��)
		Dim lngPara5 As Integer '���Ұ�3(���ݺ���)
		Dim lngPara6 As Integer '���Ұ�5(�װ����)
		Dim strPara7 As String '���Ұ�6(�װ���e)
		Dim lngPara8 As Integer '���Ұ�7(�Ǎ�����)
		Dim lngPara9 As Integer '���Ұ�8(�o�^����)
		'UPGRADE_ISSUE: OraParameter �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim param(9) As OraParameter 'PL/SQL�̃o�C���h�ϐ�
		Dim bolRet As Boolean
		On Error GoTo F_Execute_PLSQL_END
		F_Execute_PLSQL = 9
		
		'��n���ϐ������ݒ�
		strPara1 = SSS_OPEID.Value
		strPara2 = SSS_CLTID.Value
		strPara3 = TNAPR83_InputData.SOUCD
		strPara4 = TNAPR83_InputData.ZAIOUT
		
		lngPara5 = 0
		lngPara6 = 0
		strPara7 = ""
		lngPara8 = 0
		lngPara9 = 0
		
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P7")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P8")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P9")
		
		'�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P5", lngPara5, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P6", lngPara6, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P7", strPara7, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P8", lngPara8, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P9", lngPara9, ORAPARM_OUTPUT)
		
		'�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3) = gv_Odb_USR1.Parameters("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4) = gv_Odb_USR1.Parameters("P4")
		
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5) = gv_Odb_USR1.Parameters("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6) = gv_Odb_USR1.Parameters("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7) = gv_Odb_USR1.Parameters("P7")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(8) = gv_Odb_USR1.Parameters("P8")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(9) = gv_Odb_USR1.Parameters("P9")
		
		'�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4).serverType = ORATYPE_CHAR
		
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7).serverType = ORATYPE_VARCHAR2
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(8).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(9).serverType = ORATYPE_NUMBER
		
		'PL/SQL�Ăяo��SQL
		strSQL = "BEGIN PRC_TNAPR83_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9); End;"
		
		'DB�A�N�Z�X
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_Execute_PLSQL_END
		End If
		
		'** �߂�l�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara5 = param(5).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(param(7).Value) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strPara7 = param(7).Value
		End If
		
		'�G���[���ݒ�
		gv_Str_OraErrText = strPara7
		
		F_Execute_PLSQL = lngPara5
		
F_Execute_PLSQL_END: 
		'** �p�����^����
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P7")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P8")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P9")
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_GATUDO
	'   �T�v�F  ���t�A�������猎�x���Z�o
	'   �����F�@pm_DT   ���t(YYYYMMDD)
	'   �ߒl�F�@���x(YYYYMM)
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Get_GATUDO(ByRef pm_DT As String, ByRef pm_SMEDD As String) As String
		
		Dim bolRet As Boolean
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strYM As String
		
		On Error GoTo ERR_HANDLE
		F_Get_GATUDO = Mid(pm_DT, 1, 6)
		
		'�O��o�������s���̌��x���Z�o
		strSQL = " select GET_GATUDO("
		strSQL = strSQL & "  '" & pm_DT & "'"
		strSQL = strSQL & " ,'" & pm_SMEDD & "'"
		strSQL = strSQL & " ) from dual "
		
		'DB�A�N�Z�X
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If bolRet = False Then
			GoTo ERR_HANDLE
		End If
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strYM = CF_Ora_GetDyn(Usr_Ody, CStr(0))
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		F_Get_GATUDO = strYM
		
EXIT_HANDLE: 
		Call CF_Ora_CloseDyn(Usr_Ody)
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_InitYM
	'   �T�v�F  �����\���p�̌��x���擾
	'   �����F�@����
	'   �ߒl�F�@���x(YYYYMM)
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Get_InitYM() As String
		
		Dim strYM As String
		Dim datDT As Date
		'UPGRADE_WARNING: �\���� Mst_Inf_SYSTBA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Mst_Inf_SYSTBA As TYPE_DB_SYSTBA
		
		'������
		F_Get_InitYM = ""
        '20190625 CHG START
        'Call DB_SYSTBA_Clear(Mst_Inf_SYSTBA)
        Call InitDataCommon("SYSTBA")
        '20190625 CHG END

        '���[�U�[���Ǘ��e�[�u������
        If SYSTBA_SEARCH(Mst_Inf_SYSTBA) <> 0 Then
			Exit Function
		End If
		
		'�O��o�������s���̌��x���Z�o
		strYM = F_Get_GATUDO(Mst_Inf_SYSTBA.SMAUPDDT, Mst_Inf_SYSTBA.SMEDD)
		
		''���x�{�P��
		datDT = CDate(VB6.Format(VB6.Format(strYM & "01", "@@@@/@@/@@"), "YYYY/MM/DD"))
		datDT = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, datDT)
		
		F_Get_InitYM = VB6.Format(datDT, "YYYYMM")
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_HD_TEISYOYM_Inf
	'   �T�v�F  ����ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   : ��ʍ��ڏ��
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_TEISYOYM_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'�r���������������������������������������������������������r
				'�d���������������������������������������������������������d
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'�N���A
			'�r���������������������������������������������������������r
			'�d���������������������������������������������������������d
		End If
		
		'�O��`�F�b�N���e�ɑޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub RefreshGauge
	'   �T�v�F  �Q�[�W�̃J�E���g�A�b�v
	'   �����F�@pin_intAllLine      : �S�̌���
	'           pin_intNowCnt       : �����ό���
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �Ȃ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub InitGauge()
        'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.GAUGE.FloodPercent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '20190627 DEL START
        'FR_SSSMAIN.GAUGE.FloodPercent = 0
        ''UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.GAUGE.ForeColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'FR_SSSMAIN.GAUGE.ForeColor = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_BLACK)
        '20190627 DEL END
    End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub RefreshGauge
	'   �T�v�F  �Q�[�W�̃J�E���g�A�b�v
	'   �����F�@pin_intAllLine      : �S�̌���
	'           pin_intNowCnt       : �����ό���
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �Ȃ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub RefreshGauge(ByRef pin_intAllLine As Short, ByRef pin_intNowCnt As Short)
		'
		'�Q�[�W�̕\��
		If pin_intAllLine > 0 And pin_intNowCnt > 0 Then
            'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.GAUGE.FloodPercent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '20190627 DEL START
            'FR_SSSMAIN.GAUGE.FloodPercent = pin_intNowCnt / pin_intAllLine * 100
            ''UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.GAUGE.FloodPercent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'If FR_SSSMAIN.GAUGE.FloodPercent > 45 Then
            '    'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.GAUGE.ForeColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    FR_SSSMAIN.GAUGE.ForeColor = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_WHITE)
            'Else
            '    'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.GAUGE.ForeColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    FR_SSSMAIN.GAUGE.ForeColor = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_BLACK)
            'End If
            '20190627 DEL END
        End If
		System.Windows.Forms.Application.DoEvents()
	End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub ShowGauge
    '   �T�v�F  �Q�[�W�̃J�E���g�A�b�v
    '   �����F�@pin_intAllLine      : �S�̌���
    '           pin_intNowCnt       : �����ό���
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �Ȃ�
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Sub ShowGauge(ByRef pin_bolVisible As Boolean)

        '�Q�[�W�̕\���E��\����ݒ�
        'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.GAUGE.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        FR_SSSMAIN.GAUGE.Visible = pin_bolVisible
        'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.CM_LCANCEL.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        FR_SSSMAIN.CM_LCANCEL.Visible = pin_bolVisible

    End Sub

    '2019/06/25 ADD START
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_Set_Frm_IN_TANCD
    '   �T�v�F  ���͒S���ҕҏW
    '   �����F�@pm_Form        :�t�H�[��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Set_Frm_IN_TANCD(ByRef pm_Form As FR_SSSMAIN, ByRef pm_All As Cls_All) As Short

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
    '2091/06/25 ADD END
End Module