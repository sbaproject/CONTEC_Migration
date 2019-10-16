Option Strict Off
Option Explicit On
'2019/09/27 ADD START
Imports Oracle.DataAccess.Client
Imports PronesDbAccess
'2019/09/27 ADD END
Module SSSMAIN0001
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	
	'�P�v���W�F�N�g���Ƃ̋��ʃ��C�u����
	Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(1242 + 40 + 0 + 1) As clsCP
	Public CQ_SSSMAIN(82) As String
	
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� Start ��������������������������������
	Public Structure HIKET54_DSP_DATA
		Dim SBNNO As String '����
		Dim HINCD As String '���i�R�[�h
		Dim HINNMA As String '�^��
		Dim HINNMB As String '�i��
	End Structure
	
	'��ʕҏW���ޔ�p
	Public HIKET54_DSP_DATA_Inf As HIKET54_DSP_DATA
	Public HIKET54_DSP_DATA_Clr As HIKET54_DSP_DATA
	
	'���i�}�X�^���
	Public Structure HIKET54_TYPE_HINMTA
		Dim DATKB As String '�폜�敪
		Dim HINCD As String '���i�R�[�h
		Dim HINNMA As String '�^��
		Dim HINNMB As String '���i���P
	End Structure
	
	Public HIKET54_HINMTA_Inf As HIKET54_TYPE_HINMTA
	
	'�I���s���ޯ���ޔ�p
	Public HIKET54_Bd_Sel_Index As Short
	'�I���I�v�V�����{�^���摜
	Public HIKET54_Bd_Sel_Img As Cls_Img_Inf
	
	Public gv_bolHIKET54_LF_Enable As Boolean 'LF�������s�t���O(False�F���s���Ȃ�)
	
	Public gv_bolKeyFlg As Boolean
	
	' === 20080729 === INSERT S - RISE)Izumi
	Public Structure HIKET51_UPDATE_FLAG
		Dim DATNO As String ' �`�[�Ǘ���
		Dim SPRRENNO As String ' �s�ԍ�
		Dim OPEID As String ' �ŏI��Ǝ҃R�[�h
		Dim CLTID As String ' �N���C�A���g�h�c
		Dim WRTTM As String ' �^�C���X�^���v�i�o�b�`���ԁj
		Dim WRTDT As String ' �^�C���X�^���v�i�o�b�`���j
		Dim UOPEID As String ' �ŏI��Ǝ҃R�[�h
		Dim UCLTID As String ' �N���C�A���g�h�c
		Dim UWRTTM As String ' �^�C���X�^���v�i�o�b�`���ԁj
		Dim UWRTDT As String ' �^�C���X�^���v�i�o�b�`���j
	End Structure
	
	Public HIKET54_UPDATE_FLAG_Inf() As HIKET51_UPDATE_FLAG
	' === 20080729 === INSERT E -
	
	'**�����֐��֘A Start **
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
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/09/26 CHG START
                'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
                Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
                Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
                Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
                '2019/09/26 CHG E N D
                Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
				
				'���݂̒l���擾
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
				
				Wk_EditMoji = ""
				
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
			
			'���̍��ڂ�̫����ړ�
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Cursor_Idx), pm_All)
		Else
			
			If pm_All.Dsp_Base.Head_Ok_Flg = True Then
                '���̍��ڂ�̫����ړ�
                'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.CS_HIK.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/09 CHG START
                'Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.CS_HIK.Tag)), pm_All)
                Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.btnF6.Tag)), pm_All)
                '2019/10/09 CHG END
                Exit Function
			End If
			
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
			Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
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
            '2019/09/26 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '2019/09/26 CHG E N D
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			'���݂̒l���擾
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
			
			All_Sel_Flg = False
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
				All_Sel_Flg = True
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
					
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'�l���������l�̏ꍇ
						Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & wk_Moji
						
					Else
						'�l���������l�ȊO�̏ꍇ
						Wk_EditMoji = wk_Moji & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
						
					End If
					
					'�ҏW��̕�����\���`���ɕϊ�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
					
					'�ҏW���SelStart������
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
                    '2019/09/26 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart + 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart + 1
                    '2019/09/26 CHG E N D
                    '�ҏW���SelLength������
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/09/26 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                    '2019/09/26 CHG E N D
                    '���l���ړ��ʏ���
                    If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
						
						'�����������菬�������Ɛݒ�l�������ꍇ
						If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
							'����̫����ʒu����E�ֈړ�
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						Else
							If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
								'�ҏW��̕�����MAX�̏ꍇ
								'����̫����ʒu����E�ֈړ�
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
						
					Else
						'���l���ڈȊO
						If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                            '�ҏW��̕�����MAX�̏ꍇ
                            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/09/26 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(Wk_DspMoji)
                            '2019/09/26 CHG E N D
                            '�ҏW���SelLength������
                            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/09/26 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 0
                            '2019/09/26 CHG E N D
                            '����̫����ʒu����E�ֈړ�
                            Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						End If
					End If
					
				Else
					'�����I���������́A�I���Ȃ�
					
					If Act_SelLength = 0 Then
						'�I���Ȃ��̏ꍇ(�}�����)
						'�}�������̑O�̕������擾
						Wk_BefMoji = Left(Wk_CurMoji, Act_SelStart)
						'���l���ړ��ʏ���
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
						
						If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
							'�󔒏�����̌��݂̕�����MAX�̏ꍇ�A�I�[�o�[�t���[
							
							'���l���ړ��ʏ���
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
                                    '2019/09/26 CHG START
                                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                                    '2019/09/26 CHG E N D
                                    '�ҏW���SelLength������
                                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    '2019/09/26 CHG START
                                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                                    '2019/09/26 CHG E N D

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
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'�������Ő���������葽�����͂���Ă���ꍇ
							If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
								'���͕s��
								pm_KeyAscii = 0
								Exit Function
							End If
							
							'�����������菬�������Ɛݒ�l�������ꍇ
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
                        '2019/09/26 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        '2019/09/26 CHG E N D
                        '�ҏW���SelLength������
                        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/09/26 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        '2019/09/26 CHG E N D
                        '�ҏW��̈ړ���𔻒�
                        If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'�l���������l�̏ꍇ
							
							If Wk_SelStart >= Len(Wk_DspMoji) Then
								'�ҏW��̊J�n�ʒu����ԉE�̏ꍇ
								'���l���ړ��ʏ���
								If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
									'�����������菬�������Ɛݒ�l�������ꍇ
									If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
										'����̫����ʒu����E�ֈړ�
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									Else
										If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
											'�ҏW��̕�����MAX�̏ꍇ
											'����̫����ʒu����E�ֈړ�
											Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
										End If
									End If
								Else
									'���l���ڈȊO
									If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
										'�ҏW��̕�����MAX�̏ꍇ
										'����̫����ʒu����E�ֈړ�
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									End If
								End If
							End If
						Else
							'�l���������l�ȊO�̏ꍇ
							If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                                '�ҏW��̕�����MAX�̏ꍇ

                                '�ҏW���SelStart������
                                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '2019/09/26 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(Wk_DspMoji)
                                '2019/09/26 CHG E N D
                                '�ҏW���SelLength������
                                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '2019/09/26 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 1
                                '2019/09/26 CHG E N D
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
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'�����������̏ꍇ
							'����������Ő���������葽�����͂���Ă���ꍇ
							If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
								'���͕s��
								pm_KeyAscii = 0
								Exit Function
							End If
							
							'�����������菬�������Ɛݒ�l�������ꍇ
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
                        '2019/09/26 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        '2019/09/26 CHG E N D
                        '�ҏW���SelLength������
                        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/09/26 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        '2019/09/26 CHG E N D
                        '�ҏW��̈ړ���𔻒�
                        If Wk_SelStart >= Len(Wk_DspMoji) - 1 Then
							'�ҏW��̊J�n�ʒu���Ō�̕����ȍ~�̏ꍇ
							'���l���ړ��ʏ���
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								
								'�����������菬�������Ɛݒ�l�������ꍇ
								If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
									'����̫����ʒu����E�ֈړ�
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								Else
									If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
										'�ҏW��̕�����MAX�̏ꍇ
										'����̫����ʒu����E�ֈړ�
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									End If
								End If
								
							Else
								'���l���ڈȊO
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
                                '2019/09/26 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                                '2019/09/26 CHG E N D
                                '�ҏW���SelLength������
                                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '2019/09/26 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                                '2019/09/26 CHG E N D
                                '�폜�s��
                                Exit Function
							Case Else
								
						End Select
						
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
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								If Wk_DelMoji = "." Then
									'�폜�Ώۂ̕����������_�̏ꍇ
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
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1)
								Else
									'�폜�Ώۂ��Ȃ��ׁA�󔒂�ҏW
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
									Wk_EditMoji = Right(Wk_CurMoji, Len(Wk_CurMoji) - 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								Else
									'�폜�Ώۂ��Ȃ��ׁA�󔒂�ҏW
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
								
								'�폜���SelStart������
								Wk_SelStart = Act_SelStart
							Else
								'�����ҏW
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
                        '2019/09/26 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        '2019/09/26 CHG E N D
                        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/09/26 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        '2019/09/26 CHG E N D
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
                '2019/09/26 DEL START
                'FR_SSSMAIN.PopupMenu(FR_SSSMAIN.SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26 DEL E N D
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
	'   ���́F  Function CF_Ctl_VS_Scrl_CHANGE
	'   �T�v�F  VS_Scrl��MOUSEDOWN�̐���
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
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			
			'���݂̍s���擾
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
					Call CF_Set_Item_Color_MEISAI(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
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
	'   ���́F  Function CF_Ctl_MN_UnDoDe
	'   �T�v�F  ���j���[�̖��ו����̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_UnDoDe(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
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
        '2019/09/26 CHG START
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
        Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
        Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
        Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
        '2019/09/26 CHG E N D
        Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
		'���݂̒l���擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Wk_CurMoji = CF_Get_Input_Ok_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf)
		
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
        '2019/09/26 CHG START
        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart

        '2019/09/26 CHG E N D
        '�ҏW���SelLength������
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelLength
        '���͌�̌㏈��
        Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
		'���ד��͌�̌㏈��
		Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Init_Clr_Dsp_Body
	'   �T�v�F  �w�肳�ꂽ���ׂ̏����l��ݒ肷��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		
		'�r���������������������������������������������������������r
		'�d���������������������������������������������������������d
		
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
		
		''�r���������������������������������������������������������r
		'    '�s��ǉ����ꂽ���
		'    '�����l��ǉ������s�ɑ΂��ă��[�v���łP�s���s��
		'    '�����ł̍s�́ADsp_Body_Inf�̍s�I�I
		'    For Bd_Index = Row_Inf_Max_S To Row_Inf_Max_E
		'        Call F_Init_Dsp_Body(Bd_Index, pm_All)
		'    Next
		''�d���������������������������������������������������������d
		
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
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_TL And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'�t�b�^������{�f�B���ֈړ�����ꍇ
				'���͉\�ȍŏ��̃C���f�b�N�X���擾
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					Index_Wk = Focus_Ctl_Ok_Fst_Idx
				End If
				
			End If
			
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
		Dim bolDsp As Boolean
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'�{�f�B��
			'Dsp_Body_Inf�̍s�m�n���擾
			Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
			
			If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW Then
				'�ŏI�����s�̏ꍇ
				'���͉\�ȍŏ��̃C���f�b�N�X���擾
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
				If pm_Dsp_Sub_Inf.Detail.Body_Index = pm_All.Dsp_Base.Dsp_Body_Cnt Then
					'�\������Ă���ŏI�s�̏ꍇ
					'���͉\�ȍŌ�̃C���f�b�N�X���擾
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
		
		bolDsp = False
		'���̍��ڂ�����
		For Index_Wk = Sta_Index To pm_All.Dsp_Base.Item_Cnt
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'�w�b�_������{�f�B���ֈړ�����ꍇ
				'ͯ�ޕ�����
				Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				
				If Rtn_Chk <> CHK_OK Then
					'�`�F�b�N�m�f�̏ꍇ
					'�L�[�t���O�����ɖ߂�
					gv_bolKeyFlg = False
					Exit For
				End If
				
				If Rtn_Chk = CHK_OK Then
					'�`�F�b�N�n�j�̏ꍇ
					If bolDsp = False Then
						'��ʕҏW
						Call F_DSP_BD_Inf(pm_Dsp_Sub_Inf, DSP_SET, pm_All)
						'�y�����Ӂ��z�����ɁA���ޯ�����t�b�^���̓��ɃW�����v�����Ă���B
						'���[�v�񐔌��̂��߁B���ׂɓ��͍��ڂ��Ȃ�����\�B
						Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx
						'�L�[�t���O�����ɖ߂�
						gv_bolKeyFlg = False
                        bolDsp = True
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
		
		'�ŏI���ڂ܂Ō����I����
		If Index_Wk > pm_All.Dsp_Base.Item_Cnt Then
			'���[�h�ɂ�茟���I����̏���������
			Select Case pm_Mode
				Case NEXT_FOCUS_MODE_KEYRETURN
					'KEYRETURN�̏ꍇ
					'�r���������������������������������������������������������r
					'�ړ��悪�����s�̏ꍇ
					'�X�V�O�`�F�b�N�˂c�a�X�V�ˏ�����
					Call F_Ctl_Upd_Process(pm_All)
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
            '2019/09/26 CHG START
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
            '2019/09/26 CHG E N D
            If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '�l���������l�̏ꍇ
                    '�P�����ڂ�I������
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/09/06 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 0
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = 0
                    '2019/09/06 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/09/06 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 1
                    '2019/09/06 CHG E N D
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
                        '2019/09/26 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        '2019/09/26 CHG E N D
                        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/09/26 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        '2019/09/26 CHG E N D
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
            '2019/09/26 CHG START
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '2019/09/26 CHG E N D
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
            If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '�l���������l�̏ꍇ
                    '�ŏI������I������
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/09/26 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
                    '2019/09/26 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/09/26 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 1
                    '2019/09/26 CHG E N D

                Else
                    '�l���������l�ȊO�̏ꍇ
                    '�P���ڂ�I������
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/09/26 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = 1
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 1
                    '2019/09/26 CHG E N D
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
						If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                            '�l���������l�̏ꍇ
                            '��ԉE�ֈړ����I���Ȃ���Ԃ�
                            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/09/26 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 0
                            '2019/09/26 CHG E N D
                        Else
							'�l���������l�ȊO�̏ꍇ
							If Act_SelLength = 0 Then
                                '�ړ��O�̑I�𕶎������Ȃ��ꍇ
                                '��ԉE�ֈړ����I���Ȃ���Ԃ�
                                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '2019/09/26 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 0
                                '2019/09/26 CHG E N D
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
                            '2019/09/26 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Next_SelStart
                            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                            '2019/09/26 CHG E N D
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
						'��ʃ{�f�B���̔z����Đݒ�
						Call CF_Dell_Refresh_Body_Inf(pm_All)
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
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						Else
							'���͉\�ȍŏ��̃C���f�b�N�X���擾
							Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
							If Focus_Ctl_Ok_Fst_Idx > 0 Then
								'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
								Exit Do
							Else
								'�t�b�^���̍ŏ��̍��ڂ̂P�O����
								'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						End If
						
					Else
						'����ړ������ꍇ�A̫����ړ��\�ȍs���Ȃ���ꍇ
						'�t�b�^���̍ŏ��̍��ڂ̂P�O����
						'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
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
		
		Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
			Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'�O��Ɠ����`�F�b�N���e�̏ꍇ
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
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'�O��Ɠ����`�F�b�N���e�̏ꍇ
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
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'�O��Ɠ����`�F�b�N���e�̏ꍇ
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
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'�O��Ɠ����`�F�b�N���e�̏ꍇ
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
			pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
		Else
			
			Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
				Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'�K�{���͂Ŗ�����
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'�P�x�������͈ȊO�`�F�b�N�����Ă��Ȃ��ꍇ
								'�`�F�b�N�n�j�Ƃ���
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							Else
								'�P�x�ł������̓`�F�b�N�����Ă���ꍇ
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
									'�O��Ɠ����`�F�b�N���e�̏ꍇ
									'�`�F�b�N�G���[�Ƃ���
									pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
									'���b�Z�[�W�o�͂Ȃ�
									pm_Msg_Flg = False
									'�ړ��n�j
									pm_Move = True
								Else
									'�O��ƈقȂ�`�F�b�N���e�̏ꍇ
									'�`�F�b�N�G���[�Ƃ���
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
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
								'�O��Ɠ����`�F�b�N���e�̏ꍇ
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							Else
								'�O��ƈقȂ�`�F�b�N���e�̏ꍇ
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
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'�P�x�������͈ȊO�`�F�b�N�����Ă��Ȃ��ꍇ
								'�`�F�b�N�n�j�Ƃ���
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							Else
								'�P�x�ł������̓`�F�b�N�����Ă���ꍇ
								'�`�F�b�N�G���[�Ƃ���
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							End If
						Case CHK_ERR_ELSE
							'���̑��G���[��
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
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'�P�x�������͈ȊO�`�F�b�N�����Ă��Ȃ��ꍇ
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							Else
								'�P�x�ł������̓`�F�b�N�����Ă���ꍇ
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
								'���b�Z�[�W�o�͂���
								pm_Msg_Flg = True
								'�ړ��m�f
								pm_Move = False
							End If
							
						Case CHK_ERR_ELSE
							'���̑��G���[��
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
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
							'���b�Z�[�W�o�͂���
							pm_Msg_Flg = True
							'�ړ��m�f
							pm_Move = False
							
						Case CHK_ERR_ELSE
							'���̑��G���[��
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'���b�Z�[�W�o�͂���
							pm_Msg_Flg = True
							'�ړ��m�f
							pm_Move = False
							
					End Select
					
			End Select
			
		End If
		
		'�`�F�b�N�֐��ďo���������N���A
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
		
		'�r���������������������������������������������������������r
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			Case FR_SSSMAIN.HD_SBNNO.Name
				'���Ԃɂ���ʕ\��
				Call F_Dsp_HD_SBNNO_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.HD_HINCD.Name
				'���i�R�[�h�ɂ���ʕ\��
				Call F_Dsp_HD_HINCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
		End Select
		'�d���������������������������������������������������������d
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_HD_SBNNO_Inf
	'   �T�v�F  ���Ԃɂ���ʕ\��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_SBNNO_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���Ԃ��ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_HD_HINCD_Inf
	'   �T�v�F  ���i�R�[�h�ɂ���ʕ\��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_HINCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���i�R�[�h���ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				'�r���������������������������������������������������������r
				'�y�^���z
				Trg_Index = CShort(FR_SSSMAIN.HD_HINNMA.Tag)
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(HIKET54_HINMTA_Inf.HINNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'�y�i���z
				Trg_Index = CShort(FR_SSSMAIN.HD_HINNMB.Tag)
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(HIKET54_HINMTA_Inf.HINNMB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				'�d���������������������������������������������������������d
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
			End If
		Else
			'�N���A
			'�r���������������������������������������������������������r
			'�y�^���z
			Trg_Index = CShort(FR_SSSMAIN.HD_HINNMA.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			'�y�i���z
			Trg_Index = CShort(FR_SSSMAIN.HD_HINNMB.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			'�d���������������������������������������������������������d
		End If
		
		'�O��`�F�b�N���e�ɑޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
			Case FR_SSSMAIN.HD_SBNNO.Name
				'�����O����(KEYRETURN��ݒ�)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'�Ώی��ϔԍ�������
				Rtn_Chk = F_Chk_HD_SBNNO(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.HD_HINCD.Name
				'�����O����(KEYRETURN��ݒ�)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'�Ő�������
				Rtn_Chk = F_Chk_HD_HINCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
		End Select
		
		F_Ctl_Item_Chk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_HD_SBNNO
	'   �T�v�F  ���Ԃ�����
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_SBNNO(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_HD_SBNNO = Retn_Code
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
			'   Retn_Code = CHK_ERR_NOT_INPUT
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgHIKET54_E_010
			Else
			End If
		End If
		'�d���������������������������������������������������������d
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'�r���������������������������������������������������������r
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		'�d���������������������������������������������������������d
		
		F_Chk_HD_SBNNO = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_BD_HINCD
	'   �T�v�F  ���i�R�[�h������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_HINCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf As TYPE_DB_HINMTA
		Dim Mst_Inf_Clr As TYPE_DB_HINMTA
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_HD_HINCD = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
        '2019/09/26 CHG START
        'Call DB_HINMTA_Clear(Mst_Inf)
        Call InitDataCommon("HINMTA")
        '2019/09/26 CHG E N D
        '�����̓`�F�b�N
        If CF_Trim_Item((pm_Chk_Dsp_Sub_Inf.Ctl.Text), pm_Chk_Dsp_Sub_Inf) = "" Then
			'        Retn_Code = CHK_ERR_NOT_INPUT
			
			HIKET54_HINMTA_Inf.DATKB = Mst_Inf_Clr.DATKB
			HIKET54_HINMTA_Inf.HINCD = Mst_Inf_Clr.HINCD '���i�R�[�h
			HIKET54_HINMTA_Inf.HINNMA = Mst_Inf_Clr.HINNMA '�^��
			HIKET54_HINMTA_Inf.HINNMB = Mst_Inf_Clr.HINNMB '�i��
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base((pm_Chk_Dsp_Sub_Inf.Ctl.Text), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgHIKET54_E_010
			Else
				'�}�X�^�`�F�b�N
				If DSPHINCD_SEARCH(Input_Value, Mst_Inf) = 0 Then
					'�_���폜�`�F�b�N
					If Mst_Inf.DATKB = gc_strDATKB_DEL Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgHIKET54_E_004
						GoTo F_Chk_HD_HINCD_End
					End If
					
					'�݌ɊǗ��敪�`�F�b�N
					If Mst_Inf.ZAIKB = gc_strZAIKB_NG Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgHIKET54_E_005
						GoTo F_Chk_HD_HINCD_End
					End If
					
					'�`�F�b�N�n�j
					Retn_Code = CHK_OK
					pm_Chk_Move = True
					
					HIKET54_HINMTA_Inf.DATKB = Mst_Inf.DATKB
					HIKET54_HINMTA_Inf.HINCD = Mst_Inf.HINCD '���i�R�[�h
					HIKET54_HINMTA_Inf.HINNMA = Mst_Inf.HINNMA '�^��
					HIKET54_HINMTA_Inf.HINNMB = Mst_Inf.HINNMB '�i��
					
				Else
					'�Y���f�[�^����
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgHIKET54_E_003
					
				End If
			End If
		End If
		
F_Chk_HD_HINCD_End: 
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_HINCD = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_HINCD
	'   �T�v�F  �Ώۍ��ڂ̐��i�������݂̐���
	'   �����F�@pm_All        : �S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_HINCD(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		
		'�������ޯ���擾
		Trg_Index = CShort(FR_SSSMAIN.HD_HINCD.Tag)
		
		'̫����𐻕i�R�[�h�ֈړ�
		If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
			'̫����ړ�
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'�I����Ԃ̐ݒ�i�����I���j
			Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
			'���ڐF�ݒ�
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
			
			gv_bolHIKET54_LF_Enable = False
			
			WLSHIN_KHNSEARCH = gc_strKHNKB_HON
			
			'Windows�ɏ�����Ԃ�
			System.Windows.Forms.Application.DoEvents()
			
			'���i������ʂ��Ăяo��
			WLSHIN.ShowDialog()
			WLSHIN.Close()
			
			gv_bolHIKET54_LF_Enable = True
			
			If WLSHIN_RTNCODE <> "" Then
				'�����n�j
				'��ʂɕҏW
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(WLSHIN_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'�`�F�b�N
				'�e���ڂ�����ٰ��
				Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)
				
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
				Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)
				
			End If
		End If
		
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
		
		'�{�f�B���̍ŏI���ڂ܂Ŋe���ڂ��������s��
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
				
				'������ړ��Ȃ�
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				
				F_Ctl_Head_Chk = Rtn_Chk
				Exit Function
			End If
		Next 
		
		'�֘A����
		If Rtn_Chk = CHK_OK Then
			'�֘A�`�F�b�N
			Rtn_Chk = F_Ctl_Head_RelChk(pm_All, intMoveFocus)
			'�`�F�b�N�m�f
			If Rtn_Chk <> CHK_OK Then
				
				'������ړ��Ȃ�
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(intMoveFocus), pm_All)
				
				F_Ctl_Head_Chk = Rtn_Chk
				Exit Function
			End If
		End If
		
		If Rtn_Chk = CHK_OK And pm_All.Dsp_Base.Head_Ok_Flg = False Then
			'�`�F�b�N�n�j�ł���
			'�w�b�_���̃`�F�b�N�����߂Ă̏ꍇ
			'�P�s�ڂ̃{�f�B���������ŏI�s�Ƃ��ĊJ������
			pm_All.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW
			'�t�b�^�����J������
			Call F_Foot_In_Ready(pm_All)
		End If
		
		F_Ctl_Head_Chk = Rtn_Chk
		
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
		Dim Wk_Mode As Short
		Dim Now_Dt As Date
		
		Now_Dt = Now
		
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
			
			'�ʏ������i���t���ڂɏ����l�E�V�X�e�����t���Z�b�g����A���j
			
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
		
		Dim Index_Bd_Wk As Short
		Dim Wk_Bd_Index_S As Short
		Dim Wk_Bd_Index_E As Short
		Dim Wk_Mode As Short
		Dim Wk_Index As Short
		Dim Wk_Row As Short
		
		If pm_Bd_Index = -1 Then
			Wk_Bd_Index_S = 1
			Wk_Bd_Index_E = pm_All.Dsp_Base.Dsp_Body_Cnt
			
			'��ʃ{�f�B���
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
			
			'�r���������������������������������������������������������r
			'�X�N���[��������
			'�ő�l
			Call CF_Set_VScrl_Max(1, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'�ŏ��l
			Call CF_Set_VScrl_Min(1, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'�ő彸۰ٗ�
			Call CF_Set_VScrl_LargeChange(pm_All.Dsp_Base.Dsp_Body_Move_Qty, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'�ŏ���۰ٗ�
			Call CF_Set_VScrl_SmallChange(1, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'�����l
			Call CF_Set_Item_Direct(1, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'�d���������������������������������������������������������d
			Wk_Mode = BODY_ALL_CLR
		Else
			Wk_Bd_Index_S = pm_Bd_Index
			Wk_Bd_Index_E = pm_Bd_Index
			Wk_Mode = BODY_ALL_ONLY
		End If
		
		For Index_Bd_Wk = Wk_Bd_Index_S To Wk_Bd_Index_E
			
			'���ʏ�����
			Call CF_Init_Clr_Dsp_Body(Index_Bd_Wk, Wk_Mode, pm_All)
			
			'�z��O�̏�������Ώۍs�ɃR�s�[
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk))
			
			'�S�̏������̏ꍇ
			If Wk_Mode = BODY_ALL_CLR Then
				'�S�s�������
				pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk).Status = BODY_ROW_STATE_DEFAULT
			End If
			
			'�ʏ�����
			
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Init_Cursor_Set
	'   �T�v�F  ��ʏ�����Ԏ��̃t�H�[�J�X�ʒu�ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Cursor_Set(ByRef pm_All As Cls_All) As Short
		
		Dim Act_Index As Short
		
		'�e��ʌʐݒ�(�K��DSP_SUB_INF.Detail.Focus_Ctl=True�̍��ځI�I)
		'�Č��h�c�Ƀt�H�[�J�X�ݒ�
		'�������ޯ���擾
		Act_Index = CShort(FR_SSSMAIN.HD_SBNNO.Tag)
		
		'̫����ړ�
		Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Act_Index), pm_All)
		'�I����Ԃ̐ݒ�i�����I���j
		Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Act_Index), SEL_INI_MODE_2)
		'���ڐF�ݒ�
		Call CF_Set_Item_Color_MEISAI(pm_All.Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS, pm_All)
		
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Upd_Process
	'   �T�v�F  �X�V���C�����[�`��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Ctl_Upd_Process(ByRef pm_All As Cls_All) As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Head_RelChk
	'   �T�v�F  �w�b�_���֘A�`�F�b�N
	'   �����F�@pm_ErrIdx : �G���[�������̃t�H�[�J�X�ړ��Ώ�
	'   �ߒl�F�@CHK_OK:�`�F�b�NOK�@CHK_ERR_ELSE:���̑��G���[
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Ctl_Head_RelChk(ByRef pm_All As Cls_All, ByRef pm_ErrIdx As Short) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim strCode1 As String
		Dim strCode2 As String
		Dim intRet As Short
		Dim Err_Cd As String
		
		'������
		Retn_Code = CHK_OK
		Msg_Flg = False
		Err_Cd = ""
		
		If Trim(FR_SSSMAIN.HD_SBNNO.Text) = "" Or Trim(FR_SSSMAIN.HD_HINCD.Text) = "" Then
			'������������͂̏ꍇ�̓G���[
			Retn_Code = CHK_ERR_NOT_INPUT
			If Trim(FR_SSSMAIN.HD_SBNNO.Text) = "" And Trim(FR_SSSMAIN.HD_HINCD.Text) = "" Then
				Err_Cd = gc_strMsgHIKET54_E_002
			Else
				Err_Cd = gc_strMsgHIKET54_E_011
			End If
			If Trim(FR_SSSMAIN.HD_SBNNO.Text) = "" Then
				pm_ErrIdx = CShort(FR_SSSMAIN.HD_SBNNO.Tag)
			Else
				pm_ErrIdx = CShort(FR_SSSMAIN.HD_HINCD.Tag)
			End If
		End If
		
		If Retn_Code = CHK_OK Then
			strCode1 = Trim(FR_SSSMAIN.HD_SBNNO.Text)
			strCode2 = Trim(FR_SSSMAIN.HD_HINCD.Text)
			'�Ώۃ��R�[�h���݃`�F�b�N
			intRet = F_CHK_DSPCD(strCode1, strCode2)
			If intRet <> CHK_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgHIKET54_E_003
				pm_ErrIdx = CShort(FR_SSSMAIN.HD_SBNNO.Tag)
			End If
		End If
		
		Msg_Flg = True
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Ctl_Head_RelChk = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_CHK_DSPCD
	'   �T�v�F  �����Ώۃf�[�^�L��
	'   �����F�@pm_strCode1           :���ނP
	'           pm_strCode2�@�@�@�@�@ :���ނQ
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_CHK_DSPCD(ByVal pm_strCode1 As String, Optional ByVal pm_strCode2 As String = "") As Short
		
		Dim intRet As Short
		Dim Retn_Code As Short
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		
		Retn_Code = CHK_OK
		intRet = 0
		
		'/////////////////////////////////////////////////////////////
		' �x���i�̌���
		'/////////////////////////////////////////////////////////////
		
		'����SQL
		strSQL = ""
		strSQL = strSQL & " SELECT    '3' SYBT"
		strSQL = strSQL & "         , SKYTBL.OUTSOUCD"
		strSQL = strSQL & "         , ' ' OUTKB"
		strSQL = strSQL & "         , SKYTBL.HINCD"
		strSQL = strSQL & "         , SKYTBL.SPRNOKDT OUTYTDT"
		strSQL = strSQL & "         , SKYTBL.WRTFSTDT"
		strSQL = strSQL & "         , SKYTBL.WRTFSTTM"
		strSQL = strSQL & "         , SKYTBL.SBNNO"
		strSQL = strSQL & "         , SKYTBL.SPRRENNO"
		strSQL = strSQL & "         , SKYTBL.PUDLNO"
		strSQL = strSQL & "         , SKYTBL.TOKCD"
		strSQL = strSQL & "         , SKYTBL.OUTYOTSU OUTYTSU"
		strSQL = strSQL & "         , SKYTBL.FRDSU    FRDSU"
		strSQL = strSQL & "         , SKYTBL.OUTZMISU OTPSU"
		strSQL = strSQL & " From SKYTBL"
		strSQL = strSQL & " WHERE     SKYTBL.DATKB    =  '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & "   AND     SKYTBL.SBNNO = '" & CF_Ora_Sgl(pm_strCode1) & "'"
		strSQL = strSQL & "   AND     SKYTBL.HINCD = '" & CF_Ora_Sgl(pm_strCode2) & "'"
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			'�擾�f�[�^�Ȃ��i�܂�A���ׂđΏۊO�j
			intRet = -1
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'/////////////////////////////////////////////////////////////
		' ���ԏo�ɂ̌���
		'/////////////////////////////////////////////////////////////
		If intRet <> 0 Then
			
			intRet = 0
			
			'����SQL
			strSQL = ""
			strSQL = strSQL & " SELECT    '4' SYBT"
			strSQL = strSQL & "         , SBNTRA.OUTSOUCD"
			strSQL = strSQL & "         , SBNTRA.OUTKB"
			strSQL = strSQL & "         , SBNTRA.HINCD"
			strSQL = strSQL & "         , SBNTRA.OUTYTDT"
			strSQL = strSQL & "         , SBNTRA.WRTFSTDT"
			strSQL = strSQL & "         , SBNTRA.WRTFSTTM"
			strSQL = strSQL & "         , SBNTRA.SBNNO"
			strSQL = strSQL & "         , '0' SPRRENNO"
			strSQL = strSQL & "         , SBNTRA.PUDLNO"
			strSQL = strSQL & "         , SBNTRA.TOKCD"
			strSQL = strSQL & "         , SBNTRA.FRDYTSU OUTYTSU"
			strSQL = strSQL & "         , SBNTRA.FRDSU   FRDSU"
			strSQL = strSQL & "         , SBNTRA.OUTSMSU OTPSU"
			strSQL = strSQL & " From SBNTRA"
			strSQL = strSQL & " WHERE     SBNTRA.DATKB    =  '" & gc_strDATKB_USE & "'"
			strSQL = strSQL & "   AND     SBNTRA.SBNNO = '" & CF_Ora_Sgl(pm_strCode1) & "'"
			strSQL = strSQL & "   AND     SBNTRA.HINCD = '" & CF_Ora_Sgl(pm_strCode2) & "'"
			
			'DB�A�N�Z�X
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
			
			If CF_Ora_EOF(Usr_Ody) = True Then
				'�擾�f�[�^�Ȃ��i�܂�A���ׂđΏۊO�j
				intRet = -1
			End If
			
			'�N���[�Y
			Call CF_Ora_CloseDyn(Usr_Ody)
			
		End If
		
		If intRet <> 0 Then
			'�Ώۃf�[�^�����i�G���[�R�[�h��ς���ׂ��H�j
			Retn_Code = CHK_ERR_ELSE
		End If
		
		F_CHK_DSPCD = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_DSP_BD_Inf
	'   �T�v�F  �{�f�B���ҏW���C��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�����X�e�[�^�X
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_DSP_BD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim strCode1 As String
		Dim strCode2 As String
		Dim intCnt As Short
		Dim intRet As Short
		
		Dim Trg_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			
			'�ϐ��̐ݒ�
			strCode1 = Trim(FR_SSSMAIN.HD_SBNNO.Text)
			strCode2 = Trim(FR_SSSMAIN.HD_HINCD.Text)
			
			' === 20080729 === INSERT S - RISE)Izumi
			'�r����񂪏�����������t���O��OFF�ɂ���(���ׂĂ̍s)
			Erase HIKET54_UPDATE_FLAG_Inf
			' === 20080729 === INSERT E -
			
			'�f�[�^�擾
			intCnt = F_GET_BD_DATA(strCode1, strCode2, HIKET54_DSP_DATA_Inf, pm_All)
			
			If intCnt > 0 Then
				'�`�F�b�NOK
				pm_All.Dsp_Base.Head_Ok_Flg = True
				
				'�f�[�^�ҏW
				intRet = F_SET_BD_DATA(HIKET54_DSP_DATA_Inf, pm_All, intCnt)
                '�w�b�_�����͉ې���
                Call F_Set_Inp_Item_Focus_Ctl(False, pm_All)
            End If
			
			'�������e�A�O����e��ޔ�
			Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
			
			
			
		Else
			'�N���A
			'�r���������������������������������������������������������r
			'�d���������������������������������������������������������d
			
		End If
		
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_BD_DATA
	'   �T�v�F  �{�f�B���f�[�^�擾
	'   �����F�@pm_strCode1           :����1
	'           pm_strCode2           :����2
	'           pm_All                :�S�\����
	'   �ߒl�F�@�擾�s��
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_BD_DATA(ByRef pm_strCode1 As String, ByRef pm_strCode2 As String, ByRef pm_HIKET54_DSP_DATA As HIKET54_DSP_DATA, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim intMode As Short
		Dim intCnt As Short
		Dim intIdx As Short
		Dim Wk_Index As Short
		Dim HIKET54_DSP_DATA_Clr As HIKET54_DSP_DATA
		
		On Error GoTo ERR_F_GET_BD_DATA
		
		F_GET_BD_DATA = -1
		
		'������
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_HIKET54_DSP_DATA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_HIKET54_DSP_DATA = HIKET54_DSP_DATA_Clr
		
		'�����r�p�k����
		strSQL = F_GET_BD_SQL(pm_strCode1, pm_strCode2)

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        If CF_Ora_EOF(Usr_Ody) = True Then
			'�擾�f�[�^�Ȃ��i�܂�A���ׂđΏۊO�j
			F_GET_BD_DATA = 0
			'���b�Z�[�W�\��
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_020, pm_All)
			Exit Function
		End If
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			
			intCnt = 0
			'�擾�S���R�[�h���{�f�B���ޔ�
			Do Until CF_Ora_EOF(Usr_Ody) = True
				intCnt = intCnt + 1
				
				'�s�ǉ�
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
				
				' === 20080725 === INSERT S - RISE)Izumi
				ReDim Preserve HIKET54_UPDATE_FLAG_Inf(intCnt)
				' === 20080725 === INSERT E -
				
				'�s���ڏ��R�s�[
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intCnt))
				
				With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
					'(6.)
					.Bus_Inf.IsDataRow = True
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.SYBT = CF_Ora_GetDyn(Usr_Ody, "SYBT", "") '���
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.SBNNO = CF_Ora_GetDyn(Usr_Ody, "SBNNO", "") '����
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "") '���i�R�[�h
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.HINNMA = CF_Ora_GetDyn(Usr_Ody, "HINNMA", "") '�^��
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.HINNMB = CF_Ora_GetDyn(Usr_Ody, "HINNMB", "") '�i��
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.ODNYTDT = CF_Ora_GetDyn(Usr_Ody, "ODNYTDT", "") '�o�ח\���
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, OTPSU, 0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, FRDSU, 0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.OUTYTSU = CF_Ora_GetDyn(Usr_Ody, "OUTYTSU", 0) - CF_Ora_GetDyn(Usr_Ody, "FRDSU", 0) - CF_Ora_GetDyn(Usr_Ody, "OTPSU", 0) '����
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.ORGSBNNO = CF_Ora_GetDyn(Usr_Ody, "ORGSBNNO", "") '������
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.OUTRSNCD = CF_Ora_GetDyn(Usr_Ody, "OUTRSNCD", "") '�o�ɗ��R�R�[�h
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.OUTRSNNM = CF_Ora_GetDyn(Usr_Ody, "OUTRSNNM", "") '�o�ɗ��R��
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "") '���Ӑ�R�[�h
					' === 20080725 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.OUTBMCD = CF_Ora_GetDyn(Usr_Ody, "OUTBMCD", "") '����敔��R�[�h
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.OUTTANCD = CF_Ora_GetDyn(Usr_Ody, "OUTTANCD", "") '�����S���҃R�[�h
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSCD", "") '�[����R�[�h
					' === 20080725 === INSERT E -
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "") '���Ӑ旪��
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.SIRCD = CF_Ora_GetDyn(Usr_Ody, "SIRCD", "") '�d����R�[�h
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.SIRRN = CF_Ora_GetDyn(Usr_Ody, "SIRRN", "") '�d���旪��
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") '�o�^��
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") '�o�^����
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "") '�q�ɃR�[�h
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM", "") '�q�ɖ���
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "") '�`�[�Ǘ���
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.SPRRENNO = CF_Ora_GetDyn(Usr_Ody, "SPRRENNO", "") '�����A��
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.PUDLNO = CF_Ora_GetDyn(Usr_Ody, "PUDLNO", "") '���o�ɔԍ�
					' === 20080725 === INSERT S - RISE)Izumi
					'                .Bus_Inf.SUB_OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    ' �ŏI��Ǝ҃R�[�h
					'                .Bus_Inf.SUB_CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    ' �N���C�A���g�h�c
					'                .Bus_Inf.SUB_WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    ' �^�C���X�^���v�i���ԁj
					'                .Bus_Inf.SUB_WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    ' �^�C���X�^���v�i���t�j
					'                .Bus_Inf.SUB_UOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "")                  ' �ŏI��Ǝ҃R�[�h
					'                .Bus_Inf.SUB_UCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "")                  ' �N���C�A���g�h�c
					'                .Bus_Inf.SUB_UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "")                  ' �^�C���X�^���v�i�o�b�`���ԁj
					'                .Bus_Inf.SUB_UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "")                  ' �^�C���X�^���v�i�o�b�`���j
					With HIKET54_UPDATE_FLAG_Inf(intCnt)
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "") '�`�[�Ǘ���
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.SPRRENNO = CF_Ora_GetDyn(Usr_Ody, "SPRRENNO", "") '�s�ԍ�
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") ' �ŏI��Ǝ҃R�[�h
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") ' �N���C�A���g�h�c
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") ' �^�C���X�^���v�i�o�b�`���ԁj
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") ' �^�C���X�^���v�i�o�b�`���j
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.UOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") ' �ŏI��Ǝ҃R�[�h
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.UCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") ' �N���C�A���g�h�c
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") ' �^�C���X�^���v�i�o�b�`���ԁj
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") ' �^�C���X�^���v�i�o�b�`���j
					End With
					' === 20080725 === INSERT E -
					
					
					'(7.)
					'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
					'�o�ח\���
					Wk_Index = CShort(FR_SSSMAIN.BD_OUTYTDT(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.ODNYTDT, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
					'����
					Wk_Index = CShort(FR_SSSMAIN.BD_OUTYTSU(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.OUTYTSU, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
					'�󒍐���
					Wk_Index = CShort(FR_SSSMAIN.BD_ORGSBNNO(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.ORGSBNNO, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
					'�o�ɗ��R
					Wk_Index = CShort(FR_SSSMAIN.BD_OUTRSNNM(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.OUTRSNNM, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
					'���Ӑ�
					Wk_Index = CShort(FR_SSSMAIN.BD_TOKRN(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.TOKRN, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
					'�d����
					Wk_Index = CShort(FR_SSSMAIN.BD_SIRRN(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SIRRN, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
					'�o�^��
					Wk_Index = CShort(FR_SSSMAIN.BD_WRTFSTDT(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.WRTFSTDT, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
					'�q��
					Wk_Index = CShort(FR_SSSMAIN.BD_SOUNM(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SOUNM, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
					
				End With
				
				'�����R�[�h
				Call CF_Ora_MoveNext(Usr_Ody)
			Loop 
			
			'�s���̔z��́A�Œ�A��ʕ\�����א����K�v
			'�i�����Ȃ��ꍇ�ACF_Body_Dsp �ɂăG���[����������j
			'�Ȃ̂ŁA�����Ŕz��� Redim ���s���@�@�������ꋤ�ʉ��H�H
			If intCnt < pm_All.Dsp_Base.Dsp_Body_Cnt Then
				'�s�ǉ�
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
				For intIdx = intCnt + 1 To pm_All.Dsp_Base.Dsp_Body_Cnt
					'�s���ڏ��R�s�[
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intIdx))
					pm_All.Dsp_Body_Inf.Row_Inf(intIdx).Bus_Inf.IsDataRow = False
				Next intIdx
			End If
			
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		
		F_GET_BD_DATA = intCnt
		
		Exit Function
		
ERR_F_GET_BD_DATA: 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_SET_BD_DATA
	'   �T�v�F  �{�f�B���f�[�^�ҏW
	'   �����F�@pm_All                :�S�\����
	'   �ߒl�F�@�����X�e�[�^�X
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SET_BD_DATA(ByRef pm_HIKET54_DSP_DATA As HIKET54_DSP_DATA, ByRef pm_All As Cls_All, ByRef pm_intCnt As Short) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		F_SET_BD_DATA = 9

        '���{�f�B��
        '�X�N���[���o�[�l�ݒ�
        '�ő�l
        '2019/10/09 CHG START
        'Call CF_Set_VScrl_Max(F_Get_VScrl_Max(pm_intCnt, pm_All.Dsp_Base.Dsp_Body_Cnt), pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
        pm_intCnt = IIf(pm_intCnt = 1, pm_intCnt, pm_intCnt - 1)
        Call CF_Set_VScrl_Max(pm_intCnt, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
        '2019/10/09 CHG END

        '�ŏ�s�ݒ�i��������Ȃ̂łP�j
        pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
		
		'���וҏW���C��
		Call CF_Body_Dsp(pm_All)
		'���בI������
		Trg_Index = CShort(FR_SSSMAIN.BD_SELECTB(1).Tag)
		Call F_Set_BD_Sel_Index(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, HIKET54_Bd_Sel_Index)
		Call F_Ctl_BD_Select(HIKET54_Bd_Sel_Index, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		
		F_SET_BD_DATA = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_BD_SQL
	'   �T�v�F  ���׏��f�[�^�擾�r�p�k����
	'   �����F�@pm_strCode1           :����1
	'           pm_strCode2           :����2
	'   �ߒl�F�@����SQL
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_BD_SQL(ByRef pm_strCode1 As String, ByRef pm_strCode2 As String) As String
		
		Dim strSQL As String
		
		'�����r�p�k���s
		strSQL = ""
		strSQL = strSQL & " ("
		strSQL = strSQL & " SELECT    '3' SYBT"
		strSQL = strSQL & "         , SKYTBL.SBNNO"
		strSQL = strSQL & "         , SKYTBL.HINCD"
		strSQL = strSQL & "         , HINMTA.HINNMA"
		strSQL = strSQL & "         , HINMTA.HINNMB"
		strSQL = strSQL & "         , SKYTBL.SPRNOKDT ODNYTDT"
		strSQL = strSQL & "         , SKYTBL.OUTYOTSU OUTYTSU"
		strSQL = strSQL & "         , SKYTBL.FRDSU    FRDSU"
		strSQL = strSQL & "         , SKYTBL.OUTZMISU OTPSU"
		strSQL = strSQL & "         , ' '    ORGSBNNO"
		strSQL = strSQL & "         , ' '    OUTRSNCD"
		strSQL = strSQL & "         , ' '    OUTRSNNM"
		strSQL = strSQL & "         , SKYTBL.TOKCD"
		' === 20080725 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
		strSQL = strSQL & "         , ' '    OUTBMCD"
		strSQL = strSQL & "         , ' '    OUTTANCD"
		strSQL = strSQL & "         , ' '    NHSCD"
		' === 20080725 === INSERT E -
		strSQL = strSQL & "         , TOKMTA.TOKRN"
		strSQL = strSQL & "         , SKYTBL.SIRCD"
		strSQL = strSQL & "         , SIRMTA.SIRRN"
		strSQL = strSQL & "         , SKYTBL.WRTFSTDT"
		strSQL = strSQL & "         , SKYTBL.WRTFSTTM"
		strSQL = strSQL & "         , SUBSTR(HINMTA.TNACM,1,3) SOUCD"
		strSQL = strSQL & "         , SOUMTA.SOUNM"
		strSQL = strSQL & "         , ' '    DATNO"
		strSQL = strSQL & "         , SKYTBL.SPRRENNO"
		strSQL = strSQL & "         , SKYTBL.PUDLNO"
		' === 20080725 === INSERT S - RISE)Izumi
		strSQL = strSQL & "         , SKYTBL.OPEID    As OPEID" '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "         , SKYTBL.CLTID    As CLTID" '�N���C�A���g�h�c
		strSQL = strSQL & "         , SKYTBL.WRTTM    As WRTTM" '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "         , SKYTBL.WRTDT    As WRTDT" '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "         , ' '    UOPEID" '�ŏI��Ǝ҃R�[�h�i�x���i�t�@�C���ɖ����׋�Ƃ���j
		strSQL = strSQL & "         , ' '    UCLTID" '�N���C�A���g�h�c�i�x���i�t�@�C���ɖ����׋�Ƃ���j
		strSQL = strSQL & "         , ' '    UWRTTM" '�^�C���X�^���v�i�o�b�`���ԁj�i�x���i�t�@�C���ɖ����׋�Ƃ���j
		strSQL = strSQL & "         , ' '    UWRTDT" '�^�C���X�^���v�i�o�b�`���j�i�x���i�t�@�C���ɖ����׋�Ƃ���j
		' === 20080725 === INSERT E -
		strSQL = strSQL & " From SKYTBL"
		strSQL = strSQL & "         , HINMTA"
		strSQL = strSQL & "         , TOKMTA"
		strSQL = strSQL & "         , SIRMTA"
		strSQL = strSQL & "         , SOUMTA"
		strSQL = strSQL & " WHERE     SKYTBL.DATKB             =  '1'"
		strSQL = strSQL & "   AND     SKYTBL.SBNNO             =  '" & CF_Ora_Sgl(pm_strCode1) & "'"
		strSQL = strSQL & "   AND     SKYTBL.HINCD             =  '" & CF_Ora_Sgl(pm_strCode2) & "'"
		strSQL = strSQL & "   AND     SKYTBL.PLANKB            =  ' '"
		strSQL = strSQL & "   AND     HINMTA.DATKB             =  '1'"
		strSQL = strSQL & "   AND     SKYTBL.HINCD             =  HINMTA.HINCD"
		strSQL = strSQL & "   AND     SKYTBL.OUTYOTSU          >  SKYTBL.FRDSU + SKYTBL.OUTZMISU"
		strSQL = strSQL & "   AND     HINMTA.ZAIKB             =  '1'"
		strSQL = strSQL & "   AND     HINMTA.JODHIKKB          =  '1'"
		strSQL = strSQL & "   AND     HINMTA.ORTSTPKB          =  '1'"
		strSQL = strSQL & "   AND     SKYTBL.TOKCD             =  TOKMTA.TOKCD(+)"
		strSQL = strSQL & "   AND     SKYTBL.SIRCD             =  SIRMTA.SIRCD(+)"
		strSQL = strSQL & "   AND     SUBSTR(HINMTA.TNACM,1,3) =  SOUMTA.SOUCD(+)"
		strSQL = strSQL & " )"
		strSQL = strSQL & " Union All"
		strSQL = strSQL & " ("
		strSQL = strSQL & " SELECT    '4' SYBT"
		strSQL = strSQL & "         , SBNTRA.SBNNO"
		strSQL = strSQL & "         , SBNTRA.HINCD"
		strSQL = strSQL & "         , HINMTA.HINNMA"
		strSQL = strSQL & "         , HINMTA.HINNMB"
		strSQL = strSQL & "         , SBNTRA.OUTYTDT"
		strSQL = strSQL & "         , SBNTRA.FRDYTSU ODNYTSU"
		strSQL = strSQL & "         , SBNTRA.FRDSU   FRDSU"
		strSQL = strSQL & "         , SBNTRA.OUTSMSU OTPSU"
		strSQL = strSQL & "         , SBNTRA.ORGSBNNO"
		strSQL = strSQL & "         , SBNTRA.OUTRSNCD"
		strSQL = strSQL & "         , MEIMTA.MEINMA OUTRSNNM"
		strSQL = strSQL & "         , SBNTRA.TOKCD"
		' === 20080725 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
		strSQL = strSQL & "         , SBNTRA.OUTBMCD"
		strSQL = strSQL & "         , SBNTRA.OUTTANCD"
		strSQL = strSQL & "         , SBNTRA.NHSCD"
		' === 20080725 === INSERT E -
		strSQL = strSQL & "         , TOKMTA.TOKRN"
		strSQL = strSQL & "         , ' '    SIRCD"
		strSQL = strSQL & "         , ' '    SIRRN"
		strSQL = strSQL & "         , SBNTRA.WRTFSTDT"
		strSQL = strSQL & "         , SBNTRA.WRTFSTTM"
		strSQL = strSQL & "         , SBNTRA.OUTSOUCD SOUCD"
		strSQL = strSQL & "         , SOUMTA.SOUNM"
		strSQL = strSQL & "         , SBNTRA.DATNO"
		strSQL = strSQL & "         , ' ' SPRRENNO"
		strSQL = strSQL & "         , SBNTRA.PUDLNO"
		' === 20080725 === INSERT S - RISE)Izumi
		strSQL = strSQL & "         , SBNTRA.OPEID     As OPEID" '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "         , SBNTRA.CLTID     As CLTID" '�N���C�A���g�h�c
		strSQL = strSQL & "         , SBNTRA.WRTTM     As WRTTM" '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "         , SBNTRA.WRTDT     As WRTDT" '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "         , SBNTRA.UOPEID    As UOPEID" '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "         , SBNTRA.UCLTID    As UCLTID" '�N���C�A���g�h�c
		strSQL = strSQL & "         , SBNTRA.UWRTTM    As UWRTTM" '�^�C���X�^���v�i�o�b�`���ԁj
		strSQL = strSQL & "         , SBNTRA.UWRTDT    As UWRTDT" '�^�C���X�^���v�i�o�b�`���j
		' === 20080725 === INSERT E -
		strSQL = strSQL & " From SBNTRA"
		strSQL = strSQL & "         , HINMTA"
		strSQL = strSQL & "         , TOKMTA"
		strSQL = strSQL & "         , MEIMTA"
		strSQL = strSQL & "         , SOUMTA"
		strSQL = strSQL & " WHERE     SBNTRA.DATKB    =  '1'"
		strSQL = strSQL & "   AND     SBNTRA.SBNNO    =  '" & CF_Ora_Sgl(pm_strCode1) & "'"
		strSQL = strSQL & "   AND     SBNTRA.HINCD    =  '" & CF_Ora_Sgl(pm_strCode2) & "'"
		strSQL = strSQL & "   AND     HINMTA.DATKB    =  '1'"
		strSQL = strSQL & "   AND     SBNTRA.HINCD    =  HINMTA.HINCD"
		strSQL = strSQL & "   AND     SBNTRA.FRDYTSU  >  SBNTRA.FRDSU + SBNTRA.OUTSMSU"
		strSQL = strSQL & "   AND     HINMTA.ZAIKB    =  '1'"
		strSQL = strSQL & "   AND     HINMTA.JODHIKKB =  '1'"
		strSQL = strSQL & "   AND     HINMTA.ORTSTPKB =  '1'"
		strSQL = strSQL & "   AND     SBNTRA.TOKCD    =  TOKMTA.TOKCD(+)"
		strSQL = strSQL & "   AND     '066'           =  MEIMTA.KEYCD(+)"
		strSQL = strSQL & "   AND     SBNTRA.OUTRSNCD =  MEIMTA.MEICDA(+)"
		strSQL = strSQL & "   AND     SBNTRA.OUTSOUCD =  SOUMTA.SOUCD(+)"
		strSQL = strSQL & " )"
		strSQL = strSQL & " ORDER BY  ODNYTDT"
		strSQL = strSQL & "         , WRTFSTDT"
		strSQL = strSQL & "         , WRTFSTTM"
		
		F_GET_BD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_BD_Sel_Index
	'   �T�v�F  �I���s���ޯ���ޔ�
	'   �����F�@pm_Dsp_Sub_Inf        :�ΏۃR���g���[��
	'           pm_Sel_Index          :�I���s���ޯ���ޔ�ϐ�
	'   �ߒl�F�@�ݒ�l
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_BD_Sel_Index(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef pm_Sel_Index As Short) As Short
		
		Dim Row_Index As Short
		
		F_Set_BD_Sel_Index = 9
		
		'�ΏۃR���g���[���́iDsp_Body_Inf�́j���ޯ�����擾
		Row_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		If pm_All.Dsp_Body_Inf.Row_Inf(Row_Index).Bus_Inf.IsDataRow = True Then
			'�I���\�s�ł���΁A�ޔ�
			pm_Sel_Index = Row_Index
		End If
		
		F_Set_BD_Sel_Index = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_BD_Select
	'   �T�v�F  ���בI������
	'   �����F�@pm_Dsp_Sub_Inf        :
	'   �ߒl�F�@��������
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_BD_Select(ByRef pm_Sel_Index As Short, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Row_Index As Short
		Dim intIdx As Short
		
		F_Ctl_BD_Select = 9
		
		'�\�����א������[�v
		For intIdx = 1 To pm_All.Dsp_Base.Dsp_Body_Cnt
			'�ΏۃR���g���[���́iDsp_Sub_Inf�́j���ޯ�����擾
			Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, intIdx, pm_All)
			'�ΏۃR���g���[���́iDsp_Body_Inf�́j���ޯ�����擾
			Row_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'�Ώۂ̖��ׂ��I���s�ł���΁A�I����Ԃ�
			If Row_Index = pm_Sel_Index Then
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Ctl.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/09/26 CHAG START
                'pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Value = True
                If TypeOf pm_All.Dsp_Sub_Inf(Trg_Index).Ctl Is CheckBox Then
                    DirectCast(pm_All.Dsp_Sub_Inf(Trg_Index).Ctl, CheckBox).Checked = True
                ElseIf TypeOf pm_All.Dsp_Sub_Inf(Trg_Index).Ctl Is RadioButton Then
                    DirectCast(pm_All.Dsp_Sub_Inf(Trg_Index).Ctl, RadioButton).Checked = True
                End If
                '2019/09/26 CHAG E N D
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Ctl.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/09/26 CHAG START
                'pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Value = False
                If TypeOf pm_All.Dsp_Sub_Inf(Trg_Index).Ctl Is CheckBox Then
                    DirectCast(pm_All.Dsp_Sub_Inf(Trg_Index).Ctl, CheckBox).Checked = False
                ElseIf TypeOf pm_All.Dsp_Sub_Inf(Trg_Index).Ctl Is RadioButton Then
                    DirectCast(pm_All.Dsp_Sub_Inf(Trg_Index).Ctl, RadioButton).Checked = False
                End If
                '2019/09/26 CHAG E N D
            End If
			
		Next intIdx
		
		F_Ctl_BD_Select = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_VScrl_Max
	'   �T�v�F  �X�N���[���o�[��max�v���p�e�B�ւ̐ݒ�l�擾
	'   �����F�@pm_Dsp_Data_Cnt       :�擾�f�[�^���iUBound(Row_Inf)�j
	'           pm_Dsp_Body_Cnt       :�ő�\�����א��iDsp_Base�ݒ�l�j
	'   �ߒl�F�@�ݒ�l
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Get_VScrl_Max(ByRef pm_Dsp_Data_Cnt As Short, ByRef pm_Dsp_Body_Cnt As Short) As Short
		
		Dim Ret_Value As Short
		Dim Wk_Value As Short
		
		'�Ƃ肠�����P��ݒ�
		Ret_Value = 1
		'�擾�������ő�\������������ꍇ�A�I�[�o�[�������Z
		Wk_Value = pm_Dsp_Data_Cnt - pm_Dsp_Body_Cnt
		If Wk_Value > 0 Then
			Ret_Value = Ret_Value + Wk_Value
		End If
		
		F_Get_VScrl_Max = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Item_Focus_Ctl_FromTo
	'   �T�v�F  �R���g���[���̎g�p�ې���i�͈͎w��j
	'   �����F�@pm_Value              :�ݒ�l
	'           pm_All                :�S�\����
	'           pm_Fst_Index          :�͈͎��iDsp_Sub_Inf�̲��ޯ���j
	'           pm_Lst_Index          :�͈͎��iDsp_Sub_Inf�̲��ޯ���j
	'   �ߒl�F�@��������
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Item_Focus_Ctl_FromTo(ByRef pm_Value As Boolean, ByRef pm_All As Cls_All, ByRef pm_Fst_Index As Short, ByRef pm_Lst_Index As Short) As Short
		
		Dim intIdx As Short
		
		F_Set_Item_Focus_Ctl_FromTo = 9
		
		'�͈͓��̑S�R���g���[�������[�v
		For intIdx = pm_Fst_Index To pm_Lst_Index Step 1
			Call CF_Set_Item_Focus_Ctl(pm_Value, pm_All.Dsp_Sub_Inf(intIdx))
		Next intIdx
		
		F_Set_Item_Focus_Ctl_FromTo = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Inp_Item_Focus_Ctl
	'   �T�v�F  ���̓R���g���[���̎g�p�ې���
	'   �����F�@pm_Value              :�ݒ�l
	'           pm_All                :�S�\����
	'   �ߒl�F�@��������
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Inp_Item_Focus_Ctl(ByRef pm_Value As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		F_Set_Inp_Item_Focus_Ctl = 9

        '����/�����{�^��
        'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.CS_HIK.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/10/09 CHG START
        'Trg_Index = CShort(FR_SSSMAIN.CS_HIK.Tag)
        Trg_Index = CShort(FR_SSSMAIN.btnF6.Tag)
        '2019/10/09 CHG END
        Call CF_Set_Item_Focus_Ctl(Not pm_Value, pm_All.Dsp_Sub_Inf(Trg_Index))
		
		F_Set_Inp_Item_Focus_Ctl = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Interface
	'   �T�v�F  �C���^�[�t�F�[�X�i�[
	'   �����F�@pm_Row_Inf             :�s���\����
	'           pm_HIKET54_DSP_DATA    :��ʋƖ����\����
	'           pm_HIKET54_Interface   :�C���^�[�t�F�[�X
	'           pm_Bd_Sel_Index        :�I���s���ޯ��
	'   �ߒl�F  ��������
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'''' UPD 2012/03/13  FKS) T.Yamamoto    Start    �A���[��FC12031301
	'Public Function F_Set_Interface(pm_Row_Inf As Cls_Dsp_Body_Row_Inf, _
	''                                pm_HIKET54_DSP_DATA As HIKET54_DSP_DATA, _
	''                                pm_HIKET54_Interface As Cls_HIKET54_Interface) As Integer
	Public Function F_Set_Interface(ByRef pm_Row_Inf As Cls_Dsp_Body_Row_Inf, ByRef pm_HIKET54_DSP_DATA As HIKET54_DSP_DATA, ByRef pm_HIKET54_Interface As Cls_HIKET54_Interface, ByRef pm_Bd_Sel_Index As Short) As Short
		'''' UPD 2012/03/13  FKS) T.Yamamoto    End
		
		F_Set_Interface = 9
		
		'�C���^�[�t�F�[�X�ɒl���i�[
		With pm_HIKET54_Interface
			'�`�[��ʁi3:�x���i���/4:���ԏo�ɏ��j
			.Mode = pm_Row_Inf.Bus_Inf.SYBT
			'�`�[�Ǘ���
			.DATNO = pm_Row_Inf.Bus_Inf.DATNO
			'�o�ɗ\���
			.ODNYTDT = pm_Row_Inf.Bus_Inf.ODNYTDT
			'�����A��
			.SPRRENNO = pm_Row_Inf.Bus_Inf.SPRRENNO
			'����
			.SBNNO = pm_Row_Inf.Bus_Inf.SBNNO
			'���i�R�[�h
			.HINCD = pm_Row_Inf.Bus_Inf.HINCD
			'�^��
			.HINNMA = pm_Row_Inf.Bus_Inf.HINNMA
			'���i���P
			.HINNMB = pm_Row_Inf.Bus_Inf.HINNMB
			'�󒍐���
			.UODSU = pm_Row_Inf.Bus_Inf.OUTYTSU
			'���Ӑ�R�[�h
			.TOKCD = pm_Row_Inf.Bus_Inf.TOKCD
			' === 20080725 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
			'����敔��R�[�h
			.OUTBMCD = pm_Row_Inf.Bus_Inf.OUTBMCD
			'�����S���҃R�[�h
			.OUTTANCD = pm_Row_Inf.Bus_Inf.OUTTANCD
			'�[����R�[�h
			.NHSCD = pm_Row_Inf.Bus_Inf.NHSCD
			' === 20080725 === INSERT E -
			'�q�ɃR�[�h
			.SOUCD = pm_Row_Inf.Bus_Inf.SOUCD
			'���o�ɔԍ�
			.PUDLNO = pm_Row_Inf.Bus_Inf.PUDLNO
			'''' UPD 2012/03/13  FKS) T.Yamamoto    Start    �A���[��FC12031301
			'' === 20080725 === INSERT S - RISE)Izumi
			'' === 20080729 === UPDATE S - RISE)Izumi
			''        '�r����񂪏���������Ă���ꍇ�͏����Z�b�g���Ȃ�
			''        If gv_bolInterfaceFlg = False Then
			''            ' �ŏI��Ǝ҃R�[�h
			''            .OPEID = pm_Row_Inf.Bus_Inf.SUB_OPEID
			''            '�N���C�A���g�h�c
			''            .CLTID = pm_Row_Inf.Bus_Inf.SUB_CLTID
			''            '�^�C���X�^���v�i���ԁj
			''            .WRTTM = pm_Row_Inf.Bus_Inf.SUB_WRTTM
			''            '�^�C���X�^���v�i���t�j
			''            .WRTDT = pm_Row_Inf.Bus_Inf.SUB_WRTDT
			''            ' �ŏI��Ǝ҃R�[�h
			''            .UOPEID = pm_Row_Inf.Bus_Inf.SUB_UOPEID
			''            '�N���C�A���g�h�c
			''            .UCLTID = pm_Row_Inf.Bus_Inf.SUB_UCLTID
			''            '�^�C���X�^���v�i�o�b�`���ԁj
			''            .UWRTTM = pm_Row_Inf.Bus_Inf.SUB_UWRTTM
			''            '�^�C���X�^���v�i�o�b�`���j
			''            .UWRTDT = pm_Row_Inf.Bus_Inf.SUB_UWRTDT
			''        End If
			'        Dim intLoop     As Integer
			'
			'        For intLoop = 1 To UBound(HIKET54_UPDATE_FLAG_Inf)
			'            ' �`�[�Ǘ�No.�ƍs�ԍ�����v�����ꍇ
			'            If HIKET54_UPDATE_FLAG_Inf(intLoop).DATNO = pm_Row_Inf.Bus_Inf.DATNO _
			''                    And HIKET54_UPDATE_FLAG_Inf(intLoop).SPRRENNO = pm_Row_Inf.Bus_Inf.SPRRENNO Then
			'                ' �ŏI��Ǝ҃R�[�h
			'                .OPEID = HIKET54_UPDATE_FLAG_Inf(intLoop).OPEID
			'                ' �N���C�A���g�h�c
			'                .CLTID = HIKET54_UPDATE_FLAG_Inf(intLoop).CLTID
			'                ' �^�C���X�^���v�i�o�b�`���ԁj
			'                .WRTTM = HIKET54_UPDATE_FLAG_Inf(intLoop).WRTTM
			'                ' �^�C���X�^���v�i�o�b�`���j
			'                .WRTDT = HIKET54_UPDATE_FLAG_Inf(intLoop).WRTDT
			'                ' �ŏI��Ǝ҃R�[�h
			'                .UOPEID = HIKET54_UPDATE_FLAG_Inf(intLoop).UOPEID
			'                ' �N���C�A���g�h�c
			'                .UCLTID = HIKET54_UPDATE_FLAG_Inf(intLoop).UCLTID
			'                ' �^�C���X�^���v�i�o�b�`���ԁj
			'                .UWRTTM = HIKET54_UPDATE_FLAG_Inf(intLoop).UWRTTM
			'                ' �^�C���X�^���v�i�o�b�`���j
			'                .UWRTDT = HIKET54_UPDATE_FLAG_Inf(intLoop).UWRTDT
			'                Exit For
			'            End If
			'        Next intLoop
			''20080725 ADD END   RISE)Tanimura
			'' === 20080729 === UPDATE E -
			'' === 20080725 === INSERT E -
			' �ŏI��Ǝ҃R�[�h
			.OPEID = HIKET54_UPDATE_FLAG_Inf(pm_Bd_Sel_Index).OPEID
			' �N���C�A���g�h�c
			.CLTID = HIKET54_UPDATE_FLAG_Inf(pm_Bd_Sel_Index).CLTID
			' �^�C���X�^���v�i�o�b�`���ԁj
			.WRTTM = HIKET54_UPDATE_FLAG_Inf(pm_Bd_Sel_Index).WRTTM
			' �^�C���X�^���v�i�o�b�`���j
			.WRTDT = HIKET54_UPDATE_FLAG_Inf(pm_Bd_Sel_Index).WRTDT
			' �ŏI��Ǝ҃R�[�h
			.UOPEID = HIKET54_UPDATE_FLAG_Inf(pm_Bd_Sel_Index).UOPEID
			' �N���C�A���g�h�c
			.UCLTID = HIKET54_UPDATE_FLAG_Inf(pm_Bd_Sel_Index).UCLTID
			' �^�C���X�^���v�i�o�b�`���ԁj
			.UWRTTM = HIKET54_UPDATE_FLAG_Inf(pm_Bd_Sel_Index).UWRTTM
			' �^�C���X�^���v�i�o�b�`���j
			.UWRTDT = HIKET54_UPDATE_FLAG_Inf(pm_Bd_Sel_Index).UWRTDT
			'''' UPD 2012/03/13  FKS) T.Yamamoto    End
		End With
		
		F_Set_Interface = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Clr_Dsp_Out
	'   �T�v�F  �o�͏���������
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Clr_Dsp_Out(ByRef pm_Sel_Index As Short, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Wk_Index_S As Short
		Dim Wk_Index_E As Short
		Dim Wk_Mode As Short
		
		Wk_Index_S = pm_All.Dsp_Base.Head_Lst_Idx + 1
		Wk_Index_E = pm_All.Dsp_Base.Item_Cnt
		pm_All.Dsp_Base.Head_Ok_Flg = False
		Wk_Mode = ITM_ALL_CLR
		
		For Index_Wk = Wk_Index_S To Wk_Index_E
			'���ʏ�����
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Index_Wk), Wk_Mode, pm_All)
		Next 
		
		'����������
		'���בI���Ȃ��ɂ���
		pm_Sel_Index = 0
		Call F_Ctl_BD_Select(pm_Sel_Index, pm_Dsp_Sub_Inf, pm_All)
		'����������
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_TANNM
	'   �T�v�F  �S���Җ��̎擾
	'   �����F�@pm_Def_LineNo
	'           pm_HIKET54_DSP_DATA    :��ʋƖ����\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_TANNM(ByRef pm_TANCD As String) As String
		
		Dim Ret_Value As String
		Dim DB_TANMTA As TYPE_DB_TANMTA
		Dim intRet As Short
		
		Ret_Value = ""

        '�S���҃}�X�^����
        '2019/09/26 CHG START
        'Call DB_TANMTA_Clear(DB_TANMTA)
        Call InitDataCommon("TANMTA")
        '2019/09/26 CHG E N D
        intRet = DSPTANCD_SEARCH(pm_TANCD, DB_TANMTA)
		If intRet = 0 Then
			Ret_Value = DB_TANMTA.TANNM
		End If
		
		CF_Get_TANNM = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_WLS_Close
	'   �T�v�F  �e������ʃN���[�Y����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_WLS_Close() As Short
		
		F_Ctl_WLS_Close = 9
		
		F_Ctl_WLS_Close = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_MN_Enabled
	'   �T�v�F  ���j���[�g�p�ې���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_MN_Enabled(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Wk_Index As Short
		
		F_Ctl_MN_Enabled = 9
		
		'���݂̃t�H�[�J�X�ʒu�ɉ����āA�e���۰ق̎g�p�ۂ𐧌�
		'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.CS_HIK.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Select Case pm_All.Dsp_Base.Cursor_Idx
			Case CShort(FR_SSSMAIN.HD_HINCD.Tag)
				'���s
				Trg_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'��ʈ��
				Trg_Index = CShort(FR_SSSMAIN.MN_HARDCOPY.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'�I��
				Trg_Index = CShort(FR_SSSMAIN.MN_EndCm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				
				'���ڏ�����
				Trg_Index = CShort(FR_SSSMAIN.MN_ClearItm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'���ڕ���
				Trg_Index = CShort(FR_SSSMAIN.MN_UnDoItem.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'�؂���
				Trg_Index = CShort(FR_SSSMAIN.MN_Cut.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'�R�s�[
				Trg_Index = CShort(FR_SSSMAIN.MN_Copy.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'�\��t��
				Trg_Index = CShort(FR_SSSMAIN.MN_Paste.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				
				'�I��
				Trg_Index = CShort(FR_SSSMAIN.MN_SELECTCM.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'�O��
				Trg_Index = CShort(FR_SSSMAIN.MN_PREV.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'����
				Trg_Index = CShort(FR_SSSMAIN.MN_NEXTCM.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'���̈ꗗ
				Trg_Index = CShort(FR_SSSMAIN.MN_Slist.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				
			Case CShort(FR_SSSMAIN.CS_HIK.Tag)
				'���s
				Trg_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'��ʈ��
				Trg_Index = CShort(FR_SSSMAIN.MN_HARDCOPY.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'�I��
				Trg_Index = CShort(FR_SSSMAIN.MN_EndCm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				
				'���ڏ�����
				Trg_Index = CShort(FR_SSSMAIN.MN_ClearItm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'���ڕ���
				Trg_Index = CShort(FR_SSSMAIN.MN_UnDoItem.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'�؂���
				Trg_Index = CShort(FR_SSSMAIN.MN_Cut.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'�R�s�[
				Trg_Index = CShort(FR_SSSMAIN.MN_Copy.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'�\��t��
				Trg_Index = CShort(FR_SSSMAIN.MN_Paste.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				
				'�I��
				Trg_Index = CShort(FR_SSSMAIN.MN_SELECTCM.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'�O��
				Trg_Index = CShort(FR_SSSMAIN.MN_PREV.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'����
				Trg_Index = CShort(FR_SSSMAIN.MN_NEXTCM.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'���̈ꗗ
				Trg_Index = CShort(FR_SSSMAIN.MN_Slist.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				
			Case Else
				'���s
				Trg_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'��ʈ��
				Trg_Index = CShort(FR_SSSMAIN.MN_HARDCOPY.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'�I��
				Trg_Index = CShort(FR_SSSMAIN.MN_EndCm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				
				'���ڏ�����
				Trg_Index = CShort(FR_SSSMAIN.MN_ClearItm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'���ڕ���
				Trg_Index = CShort(FR_SSSMAIN.MN_UnDoItem.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'�؂���
				Trg_Index = CShort(FR_SSSMAIN.MN_Cut.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'�R�s�[
				Trg_Index = CShort(FR_SSSMAIN.MN_Copy.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'�\��t��
				Trg_Index = CShort(FR_SSSMAIN.MN_Paste.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				
				'�I��
				Trg_Index = CShort(FR_SSSMAIN.MN_SELECTCM.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'�O��
				Trg_Index = CShort(FR_SSSMAIN.MN_PREV.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'����
				Trg_Index = CShort(FR_SSSMAIN.MN_NEXTCM.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'���̈ꗗ
				Trg_Index = CShort(FR_SSSMAIN.MN_Slist.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				
		End Select
		
		'���j���[�{�^���C���[�W�̉�����
		'�I���{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_EndCm.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_EndCm.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'���s�{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_Execute.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'������ʕ\���{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_SLIST.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_Slist.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'���ו��N���A�{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_SELECTCM.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_SELECTCM.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		
		F_Ctl_MN_Enabled = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Hardcopy_SSSMAIN
	'   �T�v�F  �n�[�h�R�s�[��ʌďo���㏈��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Hardcopy_SSSMAIN() As Short 'Generated.
		If AE_MsgLibrary(PP_SSSMAIN, "Hardcopy") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
		On Error Resume Next
		System.Windows.Forms.Application.DoEvents()
		FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PrintForm �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
        '2019/09/26 DEL START
        'FR_SSSMAIN.PrintForm()
        '2019/09/26 DEL E N D
        FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.Arrow
		If Err.Number <> 0 Then
			If AE_MsgLibrary(PP_SSSMAIN, "HardcopyError") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
		End If
		On Error GoTo 0
		AE_Hardcopy_SSSMAIN = Cn_CuCurrent
	End Function
	
	' add 20170616 start
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Execute_PLSQL_EXCTBZ_2
	'   �T�v�F  PL/SQL���s����(�r�����䏈��)
	'   �����F�@Pin_strPRCCASE   : �����P�[�X(C:�`�F�b�N W:�������� D:�폜����)
	'           Pot_strMsg       : �G���[���e
	'   �ߒl�F�@0 : ���� 1 : �r���Ɩ����� 9 : �ُ�
	'   ���l�F  �r������pPL/SQL(PRC_EXCTBZ_2)�����s����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Execute_PLSQL_EXCTBZ_2(ByVal Pin_strPRCCASE As String, ByRef pot_strMsg As String) As Short
		
		Dim strSQL As String 'SQL��
		Dim strPara1 As String '���Ұ�1(�S���҃R�[�h)
		Dim strPara2 As String '���Ұ�2(�N���C�A���gID)
		Dim strPara3 As String '���Ұ�3(�����P�[�X)
		Dim strPara4 As String '���Ұ�4(�Ɩ��R�[�h(PGID))
		Dim strPara5 As String '���Ұ�5(����)
		Dim strPara6 As String '���Ұ�6(�i��)
		Dim lngPara7 As Integer '���Ұ�7(���A����)
		Dim lngPara8 As Integer '���Ұ�8(�װ����)
		Dim strPara9 As String '���Ұ�9(�װ���e)
		'UPGRADE_ISSUE: OraParameter �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim param(9) As OraParameter 'PL/SQL�̃o�C���h�ϐ�
		Dim bolRet As Boolean
		
		AE_Execute_PLSQL_EXCTBZ_2 = 9

        '2019/10/09 ADD START
        Try
            '2019/10/09 ADD END


            '��n���ϐ������ݒ�
            strPara1 = Inp_Inf.InpTanCd
            strPara2 = SSS_CLTID.Value
            strPara3 = Pin_strPRCCASE
            strPara4 = SSS_PrgId
            strPara5 = FR_SSSMAIN.HD_SBNNO.Text
            strPara6 = FR_SSSMAIN.HD_HINCD.Text
            lngPara7 = 0
            lngPara8 = 0
            strPara9 = ""

            pot_strMsg = ""

            '2019/10/09 ADD START

            Dim cmd As New OracleCommand

            cmd.Connection = CON

            cmd.CommandType = CommandType.StoredProcedure

            '2019/10/09 ADD END

            '2019/10/09 CHG START

            '      '�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
            '      'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '      gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P5", strPara5, ORAPARM_INPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P6", strPara6, ORAPARM_INPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P7", lngPara7, ORAPARM_OUTPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P8", lngPara8, ORAPARM_OUTPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P9", strPara9, ORAPARM_OUTPUT)

            ''�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(1) = gv_Odb_USR1.Parameters("P1")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(2) = gv_Odb_USR1.Parameters("P2")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(3) = gv_Odb_USR1.Parameters("P3")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(4) = gv_Odb_USR1.Parameters("P4")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(5) = gv_Odb_USR1.Parameters("P5")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(6) = gv_Odb_USR1.Parameters("P6")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(7) = gv_Odb_USR1.Parameters("P7")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(8) = gv_Odb_USR1.Parameters("P8")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(9) = gv_Odb_USR1.Parameters("P9")

            ''�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(1).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(2).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(3).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(4).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(5).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(6).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(7).serverType = ORATYPE_NUMBER
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(8).serverType = ORATYPE_NUMBER
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(9).serverType = ORATYPE_VARCHAR2

            '      'PL/SQL�Ăяo��SQL
            '      strSQL = "BEGIN PRC_EXCTBZ_2(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9); End;"

            Dim inP1 As OracleParameter = New OracleParameter
            inP1.ParameterName = "P1"
            inP1.Direction = ParameterDirection.Input
            inP1.Value = strPara1
            cmd.Parameters.Add(inP1)

            Dim inP2 As OracleParameter = New OracleParameter
            inP2.ParameterName = "P2"
            inP2.Direction = ParameterDirection.Input
            inP2.Value = strPara2
            cmd.Parameters.Add(inP2)

            Dim inP3 As OracleParameter = New OracleParameter
            inP3.ParameterName = "P3"
            inP3.Direction = ParameterDirection.Input
            inP3.Value = strPara3
            cmd.Parameters.Add(inP3)

            Dim inP4 As OracleParameter = New OracleParameter
            inP4.ParameterName = "P4"
            inP4.Direction = ParameterDirection.Input
            inP4.Value = strPara4
            cmd.Parameters.Add(inP4)

            Dim inP5 As OracleParameter = New OracleParameter
            inP5.ParameterName = "P5"
            inP5.Direction = ParameterDirection.Input
            inP5.Value = strPara5
            cmd.Parameters.Add(inP5)

            Dim inP6 As OracleParameter = New OracleParameter
            inP6.ParameterName = "P6"
            inP6.Direction = ParameterDirection.Input
            inP6.Value = strPara6
            cmd.Parameters.Add(inP6)

            Dim outP7 As OracleParameter = New OracleParameter
            outP7.ParameterName = "P7"
            outP7.Direction = ParameterDirection.Output
            outP7.Value = lngPara7
            cmd.Parameters.Add(outP7)

            Dim outP8 As OracleParameter = New OracleParameter
            outP8.ParameterName = "P8"
            outP8.Direction = ParameterDirection.Output
            outP8.Value = lngPara8
            cmd.Parameters.Add(outP8)

            Dim outP9 As OracleParameter = New OracleParameter
            outP9.ParameterName = "P9"
            outP9.Direction = ParameterDirection.Output
            outP9.Value = strPara9
            cmd.Parameters.Add(outP9)

            inP1.OracleDbType = OracleDbType.Char
            inP2.OracleDbType = OracleDbType.Char
            inP3.OracleDbType = OracleDbType.Char
            inP4.OracleDbType = OracleDbType.Char
            inP5.OracleDbType = OracleDbType.Char
            inP6.OracleDbType = OracleDbType.Char
            outP7.OracleDbType = OracleDbType.Decimal
            outP8.OracleDbType = OracleDbType.Decimal
            outP9.OracleDbType = OracleDbType.Varchar2

            'PL/SQL�Ăяo��SQL
            cmd.CommandText = "CNT_USR1.PRC_EXCTBZ_2"

            '2019/10/09 CHG END

            'DB�A�N�Z�X
            '2019/10/09 CHG START
            'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
            'If bolRet = False Then
            '    GoTo AE_Execute_PLSQL_EXCTBZ_2_END
            'End If
            cmd.ExecuteNonQuery()
            '2019/10/09 CHG END

            '** �߂�l�擾
            '2019/10/09 CHG START
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'lngPara7 = param(7).Value
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'lngPara8 = param(8).Value
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'If IsDbNull(param(9).Value) = False Then
            '    'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    strPara9 = param(9).Value
            '    pot_strMsg = strPara9
            'End If

            lngPara7 = outP7.Value.ToString

            lngPara8 = outP8.Value.ToString

            If IsDBNull(outP9.Value.ToString) = False Then
                strPara9 = outP9.Value.ToString
                pot_strMsg = strPara9
            End If

            '2019/10/09 CHG END

            '�G���[���ݒ�
            gv_Int_OraErr = lngPara8
            gv_Str_OraErrText = strPara9

            AE_Execute_PLSQL_EXCTBZ_2 = lngPara7

            '2019/10/09 CHG START
            'AE_Execute_PLSQL_EXCTBZ_2_END: 
            ''** �p�����^����
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Remove("P1")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Remove("P2")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Remove("P3")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Remove("P4")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Remove("P5")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Remove("P6")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Remove("P7")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Remove("P8")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Remove("P9")

            cmd.Parameters.Clear()

            '2019/10/09 CHG END

            '2019/10/09 ADD START
        Catch ex As Exception
            MsgBox("AE_Execute_PLSQL_EXCTBZ_2" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
        '2019/10/09 ADD END

    End Function
	' add 20170616 end
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
End Module