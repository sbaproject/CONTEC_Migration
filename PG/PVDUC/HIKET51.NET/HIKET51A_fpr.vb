Option Strict Off
Option Explicit On
Module SSSMAIN0003
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	
	'�P�v���W�F�N�g���Ƃ̋��ʃ��C�u����
	'Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(1242 + 40 + 0 + 1) As clsCP
	Public CQ_SSSMAIN(82) As String
	
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� Start ��������������������������������
	
	Public Structure HIKET51A_DSP_DATA
		Dim Mode As Short '���[�h�i1:���Ϗ��A2:�󒍏��j
		Dim DENSBT As String '�`�[���
		Dim JDNNO As String '�`�[�ԍ�
		Dim LINNO As String '�s�ԍ�
		Dim TANNM As String '�c�ƒS���Җ�
		Dim HINCD As String '���i�R�[�h
		Dim HINNMA As String '�^��
		Dim HINNMB As String '���i��
		Dim UODSU As Decimal '����
		' === 20070205 === INSERT S - ACE)Yano
		Dim MNSU As Decimal '�蓮�ϐ�
		' === 20070205 === INSERT E -
		Dim ZUMISU As Decimal '�����ϐ�
		Dim HIKSUKEI As Decimal '�����ϐ��i���׍��v�j
	End Structure
	
	'20080725 ADD START RISE)Tanimura '�r������
	Public Structure TYPE_DTLTRA_EXEC
		Dim HINCD As String ' ���i�R�[�h
		Dim INPYTDT As String ' ���ɗ\���
		Dim LOTNO As String ' ���b�g�ԍ�
		Dim SOUCD As String ' �q�ɃR�[�h
		Dim TRANO As String ' �g�����ԍ�
		Dim MITNOV As String ' �Ő�
		Dim LINNO As String ' �s�ԍ�
		Dim SUB_TRAKB As String ' �g�������
		Dim SUB_TRANO As String ' �g�����ԍ�
		Dim SUB_MITNOV As String ' �Ő�
		Dim SUB_LINNO As String ' �s�ԍ�
		Dim SUB_PUDLNO As String ' ���o�ɔԍ�
		Dim SUB_TRADT As String ' �g�������t
		Dim SUB_HIKNO As String ' �����ԍ�
		Dim SUB_HINCD As String ' ���i�R�[�h
		Dim SUB_OPEID As String ' �ŏI��Ǝ҃R�[�h
		Dim SUB_CLTID As String ' �N���C�A���g�h�c
		Dim SUB_WRTTM As String ' �^�C���X�^���v�i�o�b�`���ԁj
		Dim SUB_WRTDT As String ' �^�C���X�^���v�i�o�b�`���j
	End Structure
	
	Public TYPE_DTLTRA_EXEC_BEF() As TYPE_DTLTRA_EXEC ' �X�V�O�f�[�^�擾�ϐ�
	'20080725 ADD END   RISE)Tanimura
	
	'��ʕҏW���ޔ�p
	Public HIKET51A_DSP_DATA_Inf As HIKET51A_DSP_DATA
	Public HIKET51A_DSP_DATA_Clr As HIKET51A_DSP_DATA
	
	'��������t�@�C�����ޔ�
	Private mv_strDTLTRA_UMKB As String '�f�[�^�L���敪
	Private mv_strDTLTRA_TRAKB As String '�g�������
	Private mv_strDTLTRA_TRANO As String '�g�����ԍ�
	Private mv_strDTLTRA_MITNOV As String '�Ő�
	Private mv_strDTLTRA_LINNO As String '�s�ԍ�
	Private mv_strDTLTRA_PUDLNO As String '���o�ɔԍ�
	Private mv_strDTLTRA_TRADT As String '�g�������t
	Private mv_strDTLTRA_HIKNO As String '�����ԍ�
	Private mv_strDTLTRA_HINCD As String '���i�R�[�h
	' === 20070208 === INSERT S - ACE)Yano
	Private mv_strDTLTRA_ATMNKB As String '�����蓮�敪
	Private mv_strDTLTRA_INPYTDT As String '���ח\���
	Private mv_strDTLTRA_LOTNO As String '���b�g�ԍ�
	Private mv_strDTLTRA_SOUCD As String '�q�ɃR�[�h
	Private mv_strDTLTRA_SISNKB As String '���Y���敪
	Private mv_strDTLTRA_SOUTRICD As String '�����R�[�h
	Private mv_strDTLTRA_SOUKOKB As String '�q�ɋ敪
	Private mv_curDTLTRA_HIKSU As Decimal '������
	Private mv_curDTLTRA_UPD_HIKSU As Decimal '������(�X�V�p)
	Private mv_curDTLTRA_HIKSU_SA As Decimal '�������i�����j
	' === 20070208 === INSERT E -
	' === 20080715 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
	Private mv_curDTLTRA_FRDSU As Decimal '�o�׎w����
	Private mv_curFRDSU_AT As Decimal '�o�׎w����(������)
	Private mv_curFRDSU_MN As Decimal '�o�׎w����(�蓮��)
	Private mv_curFRDSU_AT_WK As Decimal '�o�׎w����(�������v�Z�pWK)
	Private mv_curFRDSU_MN_WK As Decimal '�o�׎w����(�蓮���v�Z�pWK)
	' === 20080715 === INSERT E -
	
	' === 20070208 === INSERT S - ACE)Yano
	'�����Ώۃf�[�^�L�[���ޔ�
	Private mv_strKEY_TRAKB As String '�g�������
	Private mv_strKEY_TRANO As String '�g�����ԍ�
	Private mv_strKEY_MITNOV As String '�Ő�
	Private mv_strKEY_LINNO As String '�s�ԍ�
	Private mv_strKEY_PUDLNO As String '���o�ɔԍ�
	Private mv_strKEY_TRADT As String '�g�������t
	Private mv_strKEY_HINCD As String '���i�R�[�h
	Private mv_strKEY_INPYTDT As String '���ɗ\���
	Private mv_strKEY_LOTNO As String '���b�g�ԍ�
	Private mv_strKEY_SOUCD As String '�q�ɃR�[�h
	' === 20070208 === INSERT E -
	
	'���ח�ԍ��ޔ�̈�
	Private mv_intSOUNM_Col As Short '�q�ɖ��̗�
	Private mv_intLOTNO_Col As Short '���b�g�ԍ��̗�
	Private mv_intINPYTDT_Col As Short '���ɗ\����̗�
	Private mv_intRELZAISU_Col As Short '���݌ɐ��̗�
	Private mv_intZUMISU_Col As Short '�����ϐ��̗�
	Private mv_intHIKSU_Col As Short '�����\���̗�
	' === 20070205 === INSERT S - ACE)Yano
	Private mv_intMNSU_Col As Short '�蓮�������̗�
	' === 20070205 === INSERT E -
	Private mv_intINPHIKSU_Col As Short '�������̗�
	
	' === 20070208 === INSERT S - ACE)Yano
	Private mv_curATZHIKSU_SA As Short '�����݌Ɉ������̍�
	Private mv_curATNHIKSU_SA As Short '�������ɗ\��������̍�
	Private mv_curMNZHIKSU_SA As Short '�蓮�݌Ɉ������̍�
	Private mv_curMNNHIKSU_SA As Short '�蓮���ɗ\��������̍�
	' === 20070208 === INSERT E -
	
	'��ʏ������t���O
	Public gv_bolHIKET51_INIT As Boolean 'True:�ύX����
	' === 20060905 === INSERT S - ACE)Hashiri  �G���^�[�L�[�A�łɂ��s��C��2
	Public gv_bolUpdFlg As Boolean
	' === 20060905 === INSERT E
	
	'�T�u��ʃf�[�^����
	Public gv_bolHIKET51A_CNT As Integer '���׌���
	
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
                '2019/09/20 CHG START
                'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
                Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
                Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
                Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
                '2019/09/20 CHG END
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
			'̫������󂯎��Ȃ��ꍇ
			'@'        '���̍��ڂ�̫����ړ�
			'@'        If TypeOf pm_Dsp_Sub_Inf.Ctl Is SSCommand5 Then
			'@'            Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, Move_Flg, pm_All)
			'@'        Else
			'@'        '���̍��ڂ�̫����ړ�
			'@'            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Cursor_Idx), pm_All)
			'@'        End If
			
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
			' === 20060804 === UPDATE S - ACE)Nagasawa
			'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
			Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
			' === 20060804 === UPDATE E -
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
            '2019/06/12 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '2019/06/12 CHG END
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
                    ' === 20060823 === UPDATE S - ACE)Nagasawa �S�I�����A�Q�����ȏ���͂���ƂP�����ڂ����͂���Ȃ����ۂւ̑Ή�
                    '                pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/09/20 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart + 1
                    ' === 20060823 === UPDATE E -
                    '�ҏW���SelLength������
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart + 1, Wk_SelLength)
                    '2019/09/20 CHG END

                    ' === 20060823 === INSERT S - ACE)Nagasawa �P�����ڂœ��͌�Ƀt�H�[�J�X�ړ����Ȃ����Ƃւ̑Ή�
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
                            '2019/09/20 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                            '�ҏW���SelLength������
                            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(Wk_DspMoji), 0)
                            '2019/09/20 CHG END
                            '����̫����ʒu����E�ֈړ�
                            Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						End If
					End If
					' === 20060823 === INSERT E
					
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
                                    '2019/09/20 CHG START
                                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                    '�ҏW���SelLength������
                                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                                    '2019/06/12 CHG END
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
                        '2019/09/20 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        '�ҏW���SelLength������
                        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '2019/09/20 CHG END
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
                                '2019/09/20 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                                '�ҏW���SelLength������
                                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(Wk_DspMoji), 1)
                                '2019/09/20 CHG END
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
                        '2019/09/20 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        '�ҏW���SelLength������
                        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '2019/09/20 CHG END
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
						' === 20061228 === INSERT S - ACE)Nagasawa BackSpace�L�[�������̓���C��
						Input_Flg = True
						' === 20061228 === INSERT E -
						
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
                                '2019/09/20 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                '�ҏW���SelLength������
                                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                                '2019/09/20 CHG END

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
                        '2019/09/20 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart                        
                        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '2019/09/20 CHG END

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
		' === 20060907 === INSERT S - ACE)Sejima
		Dim bolSameCtl As Boolean
		' === 20060907 === INSERT E
		
		If pm_Button = VB6.MouseButtonConstants.RightButton Then
			'�E�N���b�N
			
			' === 20060907 === INSERT S - ACE)Sejima
			bolSameCtl = False
			' === 20060907 === INSERT E
			If CShort(pm_Trg_Dsp_Sub_Inf.Ctl.Tag) = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
				'�E�N���b�N�����R���g���[�����A�N�e�B�u�ȃR���g���[���ƈ�v
				'�J�[�\������p�e�L�X�g�Ƀt�H�[�J�X���ꎞ�I�ɑޔ�
				Wk_Index = CShort(FR_SSSSUB01.TX_CursorRest.Tag)
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
				' === 20060907 === INSERT S - ACE)Sejima
				bolSameCtl = True
				' === 20060907 === INSERT E
			End If
			
			'����ړ��e�R�s�[�����
			FR_SSSSUB01.SM_AllCopy.Enabled = CF_Jge_Enabled_SM_AllCopy(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
			
			'����ړ��e�ɓ\��t�������
			FR_SSSSUB01.SM_FullPast.Enabled = CF_Jge_Enabled_SM_FullPast(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
			
			'�ΏۃR���g���[���̎g�p�s��
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = False
			
			'��߯�߱����ƭ������
			If CF_Jge_Enabled_PopupMenu(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All) = True Then
				'۽�̫�������Ă̗}��
				pm_All.Dsp_Base.LostFocus_Flg = True
                '�߯�߱����ƭ��\��
                'UPGRADE_ISSUE: �萔 vbPopupMenuLeftButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
                'UPGRADE_ISSUE: Form ���\�b�h FR_SSSSUB01.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
                '2019/09/20 CHG START
                'FR_SSSSUB01.PopupMenu(FR_SSSSUB01.SM_ShortCut, vbPopupMenuLeftButton)
                FR_SSSSUB01.SM_ShortCut.Show()
                '2019/09/20 CHG END
                '۽�̫�������Ă̗}������
                pm_All.Dsp_Base.LostFocus_Flg = False
				System.Windows.Forms.Application.DoEvents()
			End If
			
			' === 20060907 === INSERT S - ACE)Sejima
			'�߯�߱����ƭ��\����Ԃŉ�ʂ̏I�������ɓ����Ă��܂����ꍇ�́A
			'�ȍ~�̏����͍s��Ȃ��B
			If pm_All.Dsp_Base.IsUnload = True Then
				Exit Function
			End If
			' === 20060907 === INSERT E
			
			'�ΏۃR���g���[���̎g�p��
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = True
			'�t�H�[�J�X���ړ������ɖ߂�
			' === 20060907 === INSERT S - ACE)Sejima
			If bolSameCtl = True Then
				' === 20060907 === INSERT E
				Call CF_Set_Item_SetFocus(pm_Trg_Dsp_Sub_Inf, pm_All)
				' === 20060907 === INSERT S - ACE)Sejima
			End If
			' === 20060907 === INSERT E
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_VS_Scrl_CHANGE
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
		' === 20060804 === INSERT S - ACE)Nagasawa
		'���׃J���[�t��
		Call CF_Set_BD_Color(pm_All)
		' === 20060804 === INSERT E -
		'�R���g���[������
		Call F_Set_Body_Enable(pm_All)
		'�`�F�b�N�ς݂Ƃ���
		Call F_Set_Body_Bef_Chk_Value(pm_All)
		
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
					' === 20060920 === INSERT S - ACE)Sejima
					'���͉\�ȍ��ڂ��ǂ����̔��f���s��
					If CF_Set_Focus_Ctl(pm_Act_Dsp_Sub_Inf, pm_All) = True Then
						' === 20060920 === INSERT E
						'�I����Ԃ̐ݒ�i�����I���j
						Call CF_Set_Sel_Ini(pm_Act_Dsp_Sub_Inf, SEL_INI_MODE_2)
						'���ڐF�ݒ�
						Call CF_Set_Item_Color(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
						' === 20060920 === INSERT S - ACE)Sejima
					Else
						'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
					End If
					' === 20060920 === INSERT E
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
	'   ���́F  Function Init_Clr_Dsp_Body
	'   �T�v�F  �w�肳�ꂽ���ׂ̏����l��ݒ肷��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		
		''�r���������������������������������������������������������r
		''�d���������������������������������������������������������d
		
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
		
		
		'���׍č쐬������Ɩ��׍s��������׏������s��Ȃ�
		''''    '���ׂ̍č쐬���s��
		''''     Call CF_Re_Crt_Body_Inf(pm_Dsp_Sub_Inf, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)
		
		''�r���������������������������������������������������������r
		''�d���������������������������������������������������������d
		
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
        '2019/06/12 CHG START
        'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
        Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
        Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
        Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
        '2019/06/12 CHG END

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
        '2019/09/20 CHG START
        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
        '�ҏW���SelLength������
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
        '2019/09/20 CHG END

        ' === 20061228 === INSERT S - ACE)Nagasawa
        '���͌�̌㏈��
        Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		' === 20061228 === INSERT E -
		
		' === 20060912 === DELETE S - ACE)Nagasawa
		'    '���ד��͌�̌㏈��
		'    Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		' === 20060912 === DELETE E -
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Upd_Process
	'   �T�v�F  �X�V���C�����[�`��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@0 :�X�V�I���@9:�X�V�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Upd_Process(ByRef pm_All As Cls_All) As Short
		
		Dim intRet As Short
		
		'20080725 ADD START RISE)Tanimura '�r������
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim ls_sql As String
		Dim strSOUCD As String
		Dim strHinCd As String
		Dim strInpYtDt As String
		Dim strLotNo As String
		Dim intMeiCnt As Short
		Dim intCnt As Short
		Dim intLoop As Short
		Dim strKEY_HINCD As String
		Dim strKEY_INPYTDT As String
		Dim strKEY_LOTNO As String
		Dim strKEY_SOUCD As String
		Dim strKEY_TRANO As String
		Dim strKEY_MITNOV As String
		Dim strKEY_LINNO As String
		Dim bolTran As Boolean
		
		bolTran = False
		'20080725 ADD END   RISE)Tanimura
		
		F_Ctl_Upd_Process = 9
		
		' === 20060905 === INSERT S - ACE)Hashiri  �G���^�[�L�[�A�łɂ��s��C��2
		If gv_bolUpdFlg = True Then
			Exit Function
		End If
		
		gv_bolUpdFlg = True
		' === 20060905 === INSERT E -
		
		'�����v�ɂ���
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		
		'�w�b�_���̃`�F�b�N
		intRet = F_Ctl_Head_Chk(pm_All)
		If intRet <> CHK_OK Then
			'�`�F�b�N�m�f�̏ꍇ
			GoTo End_F_Ctl_Upd_Process
		End If
		
		'�{�f�B���̃`�F�b�N
		intRet = F_Ctl_Body_Chk(pm_All)
		If intRet <> CHK_OK Then
			'�`�F�b�N�m�f�̏ꍇ
			GoTo End_F_Ctl_Upd_Process
		End If

        '�e�C�����̃`�F�b�N
        ''    intRet = F_Ctl_Tail_Chk(pm_All)
        ''    If intRet <> CHK_OK Then
        ''    '�`�F�b�N�m�f�̏ꍇ
        ''        GoTo End_F_Ctl_Upd_Process
        ''    End If

        '20080725 ADD START RISE)Tanimura '�r������
        '�g�����U�N�V�����̊J�n
        '2019/09/20 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/09/20 CHG END
        bolTran = True

        '2019/10/01 ADD START
        Dim dt As DataTable = New DataTable
        '2019/10/01 ADD END

        ' ���σg�����̏ꍇ
        If HIKET51_Interface.Mode = CDbl("1") Then
			' ���σg�������猻�݂̍X�V�������擾����
			ls_sql = ""
			ls_sql = ls_sql & "SELECT"
			ls_sql = ls_sql & "  TRA.OPEID  OPEID "
			ls_sql = ls_sql & ", TRA.CLTID  CLTID "
			ls_sql = ls_sql & ", TRA.WRTTM  WRTTM "
			ls_sql = ls_sql & ", TRA.WRTDT  WRTDT "
			ls_sql = ls_sql & ", TRA.UOPEID UOPEID "
			ls_sql = ls_sql & ", TRA.UCLTID UCLTID "
			ls_sql = ls_sql & ", TRA.UWRTTM UWRTTM "
			ls_sql = ls_sql & ", TRA.UWRTDT UWRTDT "
			ls_sql = ls_sql & "FROM"
			ls_sql = ls_sql & "  MITTRA TRA "
			ls_sql = ls_sql & "WHERE"
			ls_sql = ls_sql & "  TRA.DATKB  =  '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
			ls_sql = ls_sql & "AND"
			ls_sql = ls_sql & "  TRA.MITNO  =  '" & CF_Ora_String(HIKET51_Interface.DENNO1, 10) & "' "
            'ls_sql = ls_sql & "AND"
            'ls_sql = ls_sql & "  TRA.MITNOV =  '" & CF_Ora_String(HIKET51_Interface.DENNO2, 2) & "' "
            'ls_sql = ls_sql & "AND"
            'ls_sql = ls_sql & "  TRA.LINNO  =  '" & CF_Ora_String(HIKET51_Interface.LINNO, 3) & "' "

            ls_sql = ls_sql & "FOR UPDATE"

            ' DB�A�N�Z�X
            '2019/10/01 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)
            dt = DB_GetTable(ls_sql)
            '2019/10/01 CHG END
            If DBSTAT <> 0 Then
				' �f�[�^�Ȃ��̏ꍇ
				intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_901, pm_All) ' MSG���e:���̃v���O�����ōX�V���ꂽ���߁A�X�V�ł��܂���B
				GoTo Err_F_Ctl_Upd_Process
				
			Else
                ' �X�V�O�f�[�^�ƈقȂ�f�[�^�����݂����ꍇ�̓G���[�Ƃ���B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UCLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UOPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, CLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, OPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/01 CHG START
                'If HIKET51_Interface.OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or HIKET51_Interface.CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or HIKET51_Interface.WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or HIKET51_Interface.WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or HIKET51_Interface.UOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or HIKET51_Interface.UCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or HIKET51_Interface.UWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or HIKET51_Interface.UWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
                If HIKET51_Interface.OPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or HIKET51_Interface.CLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or HIKET51_Interface.WRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or HIKET51_Interface.WRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Or HIKET51_Interface.UOPEID <> DB_NullReplace(dt.Rows(0)("UOPEID"), "") Or HIKET51_Interface.UCLTID <> DB_NullReplace(dt.Rows(0)("UCLTID"), "") Or HIKET51_Interface.UWRTTM <> DB_NullReplace(dt.Rows(0)("UWRTTM"), "") Or HIKET51_Interface.UWRTDT <> DB_NullReplace(dt.Rows(0)("UWRTDT"), "") Then
                    '2019/10/01 CHG END
                    intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_901, pm_All) ' MSG���e:���̃v���O�����ōX�V���ꂽ���߁A�X�V�ł��܂���B
                    GoTo Err_F_Ctl_Upd_Process
                    End If

                End If
			
			' �󒍃g�����̏ꍇ
		Else
			' �󒍃g�������猻�݂̍X�V�������擾����
			ls_sql = ""
			ls_sql = ls_sql & "SELECT"
			ls_sql = ls_sql & "  TRA.OPEID  OPEID "
			ls_sql = ls_sql & ", TRA.CLTID  CLTID "
			ls_sql = ls_sql & ", TRA.WRTTM  WRTTM "
			ls_sql = ls_sql & ", TRA.WRTDT  WRTDT "
			ls_sql = ls_sql & ", TRA.UOPEID UOPEID "
			ls_sql = ls_sql & ", TRA.UCLTID UCLTID "
			ls_sql = ls_sql & ", TRA.UWRTTM UWRTTM "
			ls_sql = ls_sql & ", TRA.UWRTDT UWRTDT "
			ls_sql = ls_sql & "FROM"
			ls_sql = ls_sql & "  JDNTRA TRA "
			ls_sql = ls_sql & "WHERE"
			ls_sql = ls_sql & "  TRA.DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
			ls_sql = ls_sql & "AND"
			ls_sql = ls_sql & "  TRA.JDNNO    = '" & CF_Ora_String(HIKET51_Interface.DENNO1, 10) & "' "
			ls_sql = ls_sql & "AND"
			ls_sql = ls_sql & "  TRA.LINNO    = '" & CF_Ora_String(HIKET51_Interface.LINNO, 3) & "' "
			ls_sql = ls_sql & "AND"
			ls_sql = ls_sql & "  TRA.AKAKROKB = '1' "
			ls_sql = ls_sql & "AND"
			ls_sql = ls_sql & "  TRA.DATNO    = ("
			ls_sql = ls_sql & "                  SELECT"
			ls_sql = ls_sql & "                    MAX(TRB.DATNO) DATNO"
			ls_sql = ls_sql & "                  FROM"
			ls_sql = ls_sql & "                    JDNTRA TRB"
			ls_sql = ls_sql & "                  WHERE"
			ls_sql = ls_sql & "                    TRB.DATKB  = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
			ls_sql = ls_sql & "                  AND"
			ls_sql = ls_sql & "                    TRB.JDNNO  = '" & CF_Ora_String(HIKET51_Interface.DENNO1, 10) & "'"
			ls_sql = ls_sql & "                  AND"
			ls_sql = ls_sql & "                    TRB.LINNO  = '" & CF_Ora_String(HIKET51_Interface.LINNO, 3) & "'"
			ls_sql = ls_sql & "                  AND"
			ls_sql = ls_sql & "                    TRB.JDNNO = TRA.JDNNO"
			ls_sql = ls_sql & "                  AND"
			ls_sql = ls_sql & "                    TRB.LINNO = TRA.LINNO"
			ls_sql = ls_sql & "                  GROUP BY"
			ls_sql = ls_sql & "                    TRB.JDNNO"
			ls_sql = ls_sql & "                  , TRB.LINNO"
			ls_sql = ls_sql & "                 ) "
			
			ls_sql = ls_sql & "FOR UPDATE"

            ' DB�A�N�Z�X
            '2019/10/01 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)
            dt = DB_GetTable(ls_sql)
            '2019/10/01 CHG END

            If DBSTAT <> 0 Then
				' �f�[�^�Ȃ��̏ꍇ
				intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_901, pm_All) ' MSG���e:���̃v���O�����ōX�V���ꂽ���߁A�X�V�ł��܂���B
				GoTo Err_F_Ctl_Upd_Process
				
			Else
                ' �X�V�O�f�[�^�ƈقȂ�f�[�^�����݂����ꍇ�̓G���[�Ƃ���B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UCLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UOPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, CLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, OPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/01 CHG START
                'If HIKET51_Interface.OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or HIKET51_Interface.CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or HIKET51_Interface.WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or HIKET51_Interface.WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or HIKET51_Interface.UOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or HIKET51_Interface.UCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or HIKET51_Interface.UWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or HIKET51_Interface.UWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
                If HIKET51_Interface.OPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or HIKET51_Interface.CLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or HIKET51_Interface.WRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or HIKET51_Interface.WRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Or HIKET51_Interface.UOPEID <> DB_NullReplace(dt.Rows(0)("UOPEID"), "") Or HIKET51_Interface.UCLTID <> DB_NullReplace(dt.Rows(0)("UCLTID"), "") Or HIKET51_Interface.UWRTTM <> DB_NullReplace(dt.Rows(0)("UWRTTM"), "") Or HIKET51_Interface.UWRTDT <> DB_NullReplace(dt.Rows(0)("UWRTDT"), "") Then
                    '2019/10/01 CHG END
                    intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_901, pm_All) ' MSG���e:���̃v���O�����ōX�V���ꂽ���߁A�X�V�ł��܂���B
                    GoTo Err_F_Ctl_Upd_Process
                End If
            End If
		End If
		
		mv_intINPHIKSU_Col = CShort(FR_SSSSUB01.BD_INP_HIKSU(1).Tag) - CShort(FR_SSSSUB01.BD_SOUNM(1).Tag) + 1 ' ������
		
		intMeiCnt = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		
		For intCnt = 1 To intMeiCnt
			With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
				' ���וҏW���ꂽ�s�̂ݏ������s��
				If .Bus_Inf.SUB_IsDataRow = True Then
					' ��ʂ̒l�Ə������וҏW���ɑޔ������l���`�F�b�N���A�l���ς���Ă���Ώ����𑱍s
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(mv_intINPHIKSU_Col).Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If .Item_Detail(mv_intINPHIKSU_Col).Dsp_Value <> .Bus_Inf.SUB_MOTO_HIKSU Then
						' SUB_KB = "1"(�q�ɕʍ݌Ƀf�[�^)�̏ꍇ�͏������s��
						If .Bus_Inf.SUB_KB = "1" Then
							' �q�ɃR�[�h
							strSOUCD = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_SOUCD
							
							' ���i�R�[�h
							strHinCd = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_HINCD
							
							' �q�ɕʍ݌Ƀ}�X�^���猻�݂̍X�V�������擾����
							ls_sql = ""
							ls_sql = ls_sql & "SELECT"
							ls_sql = ls_sql & "  HIN.OPEID  OPEID "
							ls_sql = ls_sql & ", HIN.CLTID  CLTID "
							ls_sql = ls_sql & ", HIN.WRTTM  WRTTM "
							ls_sql = ls_sql & ", HIN.WRTDT  WRTDT "
							ls_sql = ls_sql & ", HIN.UOPEID UOPEID "
							ls_sql = ls_sql & ", HIN.UCLTID UCLTID "
							ls_sql = ls_sql & ", HIN.UWRTTM UWRTTM "
							ls_sql = ls_sql & ", HIN.UWRTDT UWRTDT "
							ls_sql = ls_sql & "FROM"
							ls_sql = ls_sql & "  HINMTB HIN "
							ls_sql = ls_sql & "WHERE"
							ls_sql = ls_sql & "  HIN.DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
							ls_sql = ls_sql & "AND"
							ls_sql = ls_sql & "  HIN.SOUCD = '" & CF_Ora_String(strSOUCD, 3) & "' "
							ls_sql = ls_sql & "AND"
							ls_sql = ls_sql & "  HIN.HINCD = '" & CF_Ora_String(strHinCd, 10) & "' "
							
							ls_sql = ls_sql & "FOR UPDATE"

                            ' DB�A�N�Z�X
                            '2019/10/01 CHG START
                            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)
                            dt = DB_GetTable(ls_sql)
                            '2019/10/01 CHG END

                            If DBSTAT <> 0 Then
								' �f�[�^�Ȃ��̏ꍇ
								intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_901, pm_All) ' MSG���e:���̃v���O�����ōX�V���ꂽ���߁A�X�V�ł��܂���B
								GoTo Err_F_Ctl_Upd_Process
								
							Else
                                ' �X�V�O�f�[�^�ƈقȂ�f�[�^�����݂����ꍇ�̓G���[�Ƃ���B
                                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UCLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UOPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, CLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, OPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '2019/10/01 CHG START
                                'If pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_UOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_UCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_UWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_UWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
                                If pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_OPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_CLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_WRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_WRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_UOPEID <> DB_NullReplace(dt.Rows(0)("UOPEID"), "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_UCLTID <> DB_NullReplace(dt.Rows(0)("UCLTID"), "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_UWRTTM <> DB_NullReplace(dt.Rows(0)("UWRTTM"), "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_UWRTDT <> DB_NullReplace(dt.Rows(0)("UWRTDT"), "") Then
                                    '2019/10/01 CHG END
                                    intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_901, pm_All) ' MSG���e:���̃v���O�����ōX�V���ꂽ���߁A�X�V�ł��܂���B
                                    GoTo Err_F_Ctl_Upd_Process
                                End If

                            End If
						End If
						
						'SUB_KB = "2"(���ח\��t�@�C��)�̏ꍇ�͏������s��
						If .Bus_Inf.SUB_KB = "2" Then
							' ���i�R�[�h
							strHinCd = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_HINCD
							
							' ���ח\���
							strInpYtDt = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_NYUYTDT
							
							' ���b�g�ԍ�
							strLotNo = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_LOTNO
							
							' ���ח\��t�@�C�����猻�݂̍X�V�������擾����
							ls_sql = ""
							ls_sql = ls_sql & "SELECT"
							ls_sql = ls_sql & "  INP.OPEID  OPEID "
							ls_sql = ls_sql & ", INP.CLTID  CLTID "
							ls_sql = ls_sql & ", INP.WRTTM  WRTTM "
							ls_sql = ls_sql & ", INP.WRTDT  WRTDT "
							ls_sql = ls_sql & ", INP.UOPEID UOPEID "
							ls_sql = ls_sql & ", INP.UCLTID UCLTID "
							ls_sql = ls_sql & ", INP.UWRTTM UWRTTM "
							ls_sql = ls_sql & ", INP.UWRTDT UWRTDT "
							ls_sql = ls_sql & "FROM"
							ls_sql = ls_sql & "  INPTRA INP "
							ls_sql = ls_sql & "WHERE"
							ls_sql = ls_sql & "  INP.DATKB   =  '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
							ls_sql = ls_sql & "AND"
							ls_sql = ls_sql & "  INP.HINCD   =  '" & CF_Ora_String(strHinCd, 10) & "' "
							ls_sql = ls_sql & "AND"
							ls_sql = ls_sql & "  INP.INPYTDT =  '" & CF_Ora_String(strInpYtDt, 8) & "' "
							ls_sql = ls_sql & "AND"
							ls_sql = ls_sql & "  INP.LOTNO   =  '" & CF_Ora_String(strLotNo, 12) & "' "
							
							ls_sql = ls_sql & "FOR UPDATE"

                            ' DB�A�N�Z�X                            
                            '2019/10/01 CHG START
                            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)
                            dt = DB_GetTable(ls_sql)
                            '2019/10/01 CHG END

                            If DBSTAT <> 0 Then
								' �f�[�^�Ȃ��̏ꍇ
								intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_901, pm_All) ' MSG���e:���̃v���O�����ōX�V���ꂽ���߁A�X�V�ł��܂���B
								GoTo Err_F_Ctl_Upd_Process
								
							Else
                                ' �X�V�O�f�[�^�ƈقȂ�f�[�^�����݂����ꍇ�̓G���[�Ƃ���B
                                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UCLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UOPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, CLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, OPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'If pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_UOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_UCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_UWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_UWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
                                If pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_OPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_CLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_WRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_WRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_UOPEID <> DB_NullReplace(dt.Rows(0)("UOPEID"), "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_UCLTID <> DB_NullReplace(dt.Rows(0)("UCLTID"), "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_UWRTTM <> DB_NullReplace(dt.Rows(0)("UWRTTM"), "") Or pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SUB_UWRTDT <> DB_NullReplace(dt.Rows(0)("UWRTDT"), "") Then
                                    '2019/10/01 CHG END
                                    intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_901, pm_All) ' MSG���e:���̃v���O�����ōX�V���ꂽ���߁A�X�V�ł��܂���B
									GoTo Err_F_Ctl_Upd_Process
								End If
							End If
						End If
						
						' ��������t�@�C���̌������������s��
						For intLoop = 1 To UBound(TYPE_DTLTRA_EXEC_BEF)
							With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
								'�q�ɕʍ݌ɂ̏ꍇ
								If .Bus_Inf.SUB_KB = "1" Then
									'���i�R�[�h
									strKEY_HINCD = .Bus_Inf.SUB_HINCD
									'���ח\���
									strKEY_INPYTDT = "        "
									'���b�g�ԍ�
									strKEY_LOTNO = "                    "
									'�q�ɃR�[�h
									strKEY_SOUCD = .Bus_Inf.SUB_SOUCD
									'���ϔԍ�,�󒍔ԍ�
									strKEY_TRANO = HIKET51_Interface.DENNO1
									'�Ő�
									strKEY_MITNOV = HIKET51_Interface.DENNO2
									'�s�ԍ�
									strKEY_LINNO = HIKET51_Interface.LINNO
								Else
									'���i�R�[�h
									strKEY_HINCD = .Bus_Inf.SUB_HINCD
									'���ח\���
									strKEY_INPYTDT = .Bus_Inf.SUB_NYUYTDT
									'���b�g�ԍ�
									strKEY_LOTNO = .Bus_Inf.SUB_LOTNO
									'�q�ɃR�[�h
									strKEY_SOUCD = .Bus_Inf.SUB_SOUCD
									'���ϔԍ�,�󒍔ԍ�
									strKEY_TRANO = HIKET51_Interface.DENNO1
									'�Ő�
									strKEY_MITNOV = HIKET51_Interface.DENNO2
									'�s�ԍ�
									strKEY_LINNO = HIKET51_Interface.LINNO
								End If
							End With
							
							With TYPE_DTLTRA_EXEC_BEF(intLoop)
								' ��������v����ꍇ
								If strKEY_HINCD = .HINCD And strKEY_INPYTDT = .INPYTDT And strKEY_LOTNO = .LOTNO And strKEY_SOUCD = .SOUCD And strKEY_TRANO = .TRANO And strKEY_MITNOV = .MITNOV And strKEY_LINNO = .LINNO Then
									' ��������t�@�C�����猻�݂̍X�V�������擾����
									ls_sql = ""
									ls_sql = ls_sql & "SELECT"
									ls_sql = ls_sql & "  DTL.OPEID OPEID "
									ls_sql = ls_sql & ", DTL.CLTID CLTID "
									ls_sql = ls_sql & ", DTL.WRTTM WRTTM "
									ls_sql = ls_sql & ", DTL.WRTDT WRTDT "
									ls_sql = ls_sql & "FROM"
									ls_sql = ls_sql & "  DTLTRA DTL "
									ls_sql = ls_sql & "WHERE"
									ls_sql = ls_sql & "  TRAKB   =  '" & CF_Ora_String(.SUB_TRAKB, 1) & "' "
									ls_sql = ls_sql & "AND"
									ls_sql = ls_sql & "  TRANO   =  '" & CF_Ora_String(.SUB_TRANO, 20) & "' "
									ls_sql = ls_sql & "AND"
									ls_sql = ls_sql & "  MITNOV  =  '" & CF_Ora_String(.SUB_MITNOV, 2) & "' "
									ls_sql = ls_sql & "AND"
									ls_sql = ls_sql & "  LINNO   =  '" & CF_Ora_String(.SUB_LINNO, 3) & "' "
									ls_sql = ls_sql & "AND"
									ls_sql = ls_sql & "  PUDLNO  =  '" & CF_Ora_String(.SUB_PUDLNO, 10) & "' "
									ls_sql = ls_sql & "AND"
									ls_sql = ls_sql & "  TRADT   =  '" & CF_Ora_String(.SUB_TRADT, 8) & "' "
									ls_sql = ls_sql & "AND"
									ls_sql = ls_sql & "  HIKNO   =  '" & CF_Ora_String(.SUB_HIKNO, 5) & "' "
									ls_sql = ls_sql & "AND"
									ls_sql = ls_sql & "  HINCD   =  '" & CF_Ora_String(.SUB_HINCD, 10) & "' "
									
									ls_sql = ls_sql & "FOR UPDATE"

                                    ' DB�A�N�Z�X
                                    '2019/10/01 CHG START
                                    'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)
                                    dt = DB_GetTable(ls_sql)
                                    '2019/10/01 CHG END

                                    If DBSTAT <> 0 Then
										' �f�[�^�Ȃ��̏ꍇ
										intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_901, pm_All) ' MSG���e:���̃v���O�����ōX�V���ꂽ���߁A�X�V�ł��܂���B
										GoTo Err_F_Ctl_Upd_Process
										
									Else
                                        ' �X�V�O�f�[�^�ƈقȂ�f�[�^�����݂����ꍇ�̓G���[�Ƃ���B
                                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, CLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, OPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/10/01 CHG START
                                        'If TYPE_DTLTRA_EXEC_BEF(intLoop).SUB_OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or TYPE_DTLTRA_EXEC_BEF(intLoop).SUB_CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or TYPE_DTLTRA_EXEC_BEF(intLoop).SUB_WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or TYPE_DTLTRA_EXEC_BEF(intLoop).SUB_WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Then
                                        If TYPE_DTLTRA_EXEC_BEF(intLoop).SUB_OPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or TYPE_DTLTRA_EXEC_BEF(intLoop).SUB_CLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or TYPE_DTLTRA_EXEC_BEF(intLoop).SUB_WRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or TYPE_DTLTRA_EXEC_BEF(intLoop).SUB_WRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Then
                                            '2019/10/01 CHG END
                                            intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_901, pm_All) ' MSG���e:���̃v���O�����ōX�V���ꂽ���߁A�X�V�ł��܂���B
                                            GoTo Err_F_Ctl_Upd_Process
                                        End If

                                    End If
								End If
							End With
						Next intLoop
					End If
				End If
			End With
		Next intCnt
		'20080725 ADD END   RISE)Tanimura
		
		'�}�E�X�|�C���^��߂�
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'�o�^�m�F
		If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_A_014, pm_All) = MsgBoxResult.No Then
			GoTo End_F_Ctl_Upd_Process
		End If
		
		' === 20061129 === INSERT S - ACE)Nagasawa �X�V�����`�F�b�N��ύX����
		'�X�V�������Ȃ��ꍇ�͏������s��Ȃ�
		If Inp_Inf.InpJDNUPDKB <> gc_strJDNUPDKB_OK Then
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_019, pm_All)
			GoTo End_F_Ctl_Upd_Process
		End If
		' === 20061129 === INSERT E -
		
		'�{�^����\��
		FR_SSSSUB01.CM_Execute.Visible = False
		
		'�o�^����
		intRet = F_Update_Main(pm_All)
		If intRet <> 0 Then
			GoTo Err_F_Ctl_Upd_Process
		End If
		
		'20080725 ADD START RISE)Tanimura '�r������
		'�R�~�b�g
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		For intLoop = 1 To UBound(HIKET51_UPDATE_FLAG_Inf)
			' �`�[�Ǘ�No.�ƍs�ԍ�����v�����ꍇ
			If HIKET51_UPDATE_FLAG_Inf(intLoop).DATNO = HIKET51_Interface.DATNO And HIKET51_UPDATE_FLAG_Inf(intLoop).LINNO = HIKET51_Interface.LINNO Then
				' �^�C���X�^���v�����i�[����
				HIKET51_UPDATE_FLAG_Inf(intLoop).UOPEID = HIKET51_Interface.UOPEID
				HIKET51_UPDATE_FLAG_Inf(intLoop).UCLTID = HIKET51_Interface.UCLTID
				HIKET51_UPDATE_FLAG_Inf(intLoop).UWRTDT = HIKET51_Interface.UWRTDT
				HIKET51_UPDATE_FLAG_Inf(intLoop).UWRTTM = HIKET51_Interface.UWRTTM
			End If
		Next intLoop
		'20080725 ADD END   RISE)Tanimura
		
		' === 20060926 === INSERT S - ACE)Nagasawa �����I�����b�Z�[�W�ǉ�
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_A_017, pm_All)
		' === 20060926 === INSERT E -
		
		F_Ctl_Upd_Process = 0
		
End_F_Ctl_Upd_Process: 
		'20080725 ADD START RISE)Tanimura '�r������
		If bolTran Then
			'���[���o�b�N
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		'20080725 ADD END   RISE)Tanimura
		
		'�}�E�X�|�C���^��߂�
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		'�{�^���\��
		FR_SSSSUB01.CM_Execute.Visible = True
		
		' === 20060905 === INSERT S - ACE)Hashiri  �G���^�[�L�[�A�łɂ��s��C��2
		gv_bolUpdFlg = False
		
		'�L�[�t���O�����ɖ߂�
		gv_bolKeyFlg = False
		' === 20060905 === INSERT E
		
		Exit Function
		
Err_F_Ctl_Upd_Process: 
		GoTo End_F_Ctl_Upd_Process
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Update_Main
	'   �T�v�F  �X�V���C������
	'   �����F  pm_All        : ��ʏ��
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Update_Main(ByRef pm_All As Cls_All) As Short
		
		Dim bolRet As Boolean
		Dim intRet As Short
		Dim intCnt As Short
		Dim bolTran As Boolean
		Dim intMeiCnt As Short
		
		On Error GoTo F_Update_Main_err
		
		'�����v�ɂ���
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		F_Update_Main = 9
		bolTran = False
		
		'��ԍ��擾
		mv_intSOUNM_Col = 1 '�q�ɖ��̗�
		mv_intLOTNO_Col = CShort(FR_SSSSUB01.BD_LOTNO(1).Tag) - CShort(FR_SSSSUB01.BD_SOUNM(1).Tag) + 1 '���b�g�ԍ�
		mv_intINPYTDT_Col = CShort(FR_SSSSUB01.BD_NYUYTDT(1).Tag) - CShort(FR_SSSSUB01.BD_SOUNM(1).Tag) + 1 '���ɗ\���
		mv_intRELZAISU_Col = CShort(FR_SSSSUB01.BD_RELZAISU(1).Tag) - CShort(FR_SSSSUB01.BD_SOUNM(1).Tag) + 1 '���݌ɐ�
		mv_intZUMISU_Col = CShort(FR_SSSSUB01.BD_ZUMISU(1).Tag) - CShort(FR_SSSSUB01.BD_SOUNM(1).Tag) + 1 '�����ϐ�
		mv_intHIKSU_Col = CShort(FR_SSSSUB01.BD_HIKSU(1).Tag) - CShort(FR_SSSSUB01.BD_SOUNM(1).Tag) + 1 '�����\��
		' === 20070205 === INSERT S - ACE)Yano
		mv_intMNSU_Col = CShort(FR_SSSSUB01.BD_MNSU(1).Tag) - CShort(FR_SSSSUB01.BD_SOUNM(1).Tag) + 1 '�����\��
		' === 20070205 === INSERT E -
		mv_intINPHIKSU_Col = CShort(FR_SSSSUB01.BD_INP_HIKSU(1).Tag) - CShort(FR_SSSSUB01.BD_SOUNM(1).Tag) + 1 '������
		
		intMeiCnt = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		
		'�X�V�����擾
		Call CF_Get_SysDt()
		
		'20080725 DEL START RISE)Tanimura '�r������
		'   '�g�����U�N�V�����̊J�n
		'    Call CF_Ora_BeginTrans(gv_Oss_USR1)
		'    bolTran = True
		'20080725 DEL END   RISE)Tanimura
		' === 20080715 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
		'�o�׎w�������v�Z�pWK�֑ޔ�
		mv_curFRDSU_AT_WK = mv_curFRDSU_AT '����
		mv_curFRDSU_MN_WK = mv_curFRDSU_MN '�蓮
		' === 20080715 === INSERT E -
		
		For intCnt = 1 To intMeiCnt Step 1
			
			With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
				'���וҏW���ꂽ�s�̂ݏ������s��
				If .Bus_Inf.SUB_IsDataRow = True Then
					'��ʂ̒l�Ə������וҏW���ɑޔ������l���`�F�b�N���A�l���ς���Ă���Ώ����𑱍s
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(mv_intINPHIKSU_Col).Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If .Item_Detail(mv_intINPHIKSU_Col).Dsp_Value <> .Bus_Inf.SUB_MOTO_HIKSU Then
						
						'SUB_KB = "1"(�q�ɕʍ݌Ƀf�[�^)�̏ꍇ�͏������s��
						If .Bus_Inf.SUB_KB = "1" Then
							'�q�ɕʍ݌Ƀ}�X�^�X�V
							intRet = F_HINMTB_Update(intCnt, pm_All)
							If intRet <> 0 Then
								GoTo F_Update_Main_err
							End If
						End If
						
						'SUB_KB = "2"(���ח\��t�@�C��)�̏ꍇ�͏������s��
						If .Bus_Inf.SUB_KB = "2" Then
							'���ח\��t�@�C���X�V
							intRet = F_INPTRA_Update(intCnt, pm_All)
							If intRet <> 0 Then
								GoTo F_Update_Main_err
							End If
						End If
						
						'�������󃁃C������
						intRet = F_DTLTRA_Main(intCnt, pm_All)
						If intRet <> 0 Then
							GoTo F_Update_Main_err
						End If
						
						' === 20070207 === UPDATE S - ACE)Yano
						'SUB_KB = "2"(���ח\��t�@�C��)�̏ꍇ�͏������s��Ȃ�
						'���i�t�@�C���̍쐬�͍s���Ă��Ȃ�
						'If .Bus_Inf.SUB_KB = "1" Then
						'    '���i�t�@�C���X�V
						'    intRet = F_STOTRA_Update(intCnt, pm_All)
						'    If intRet <> 0 Then
						'        GoTo F_Update_Main_err
						'    End If
						'End If
						' === 20070207 === UPDATE E
						
					End If
				End If
				
			End With
			
		Next intCnt
		
		'20080725 DEL START RISE)Tanimura '�r������
		'    '�R�~�b�g
		'    Call CF_Ora_CommitTrans(gv_Oss_USR1)
		'    bolTran = False
		'20080725 DEL END   RISE)Tanimura
		
		F_Update_Main = 0
		
F_Update_Main_End: 
		'�����v��߂�
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		Exit Function
		
F_Update_Main_err: 
		'20080725 DEL START RISE)Tanimura '�r������
		'    If bolTran = True Then
		'        '���[���o�b�N
		'        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		'    End If
		'20080725 DEL END   RISE)Tanimura
		
		GoTo F_Update_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_HINMTB_Update
	'   �T�v�F  �q�ɕʍ݌Ƀ}�X�^�X�V����
	'   �����F  pin_intRow    : �s�ԍ�
	'           pm_All        : ��ʏ��
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_HINMTB_Update(ByVal pin_intRow As Short, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim curHIKSU As Decimal '������
		Dim curMotoHikSu As Decimal '��������
		Dim curUpdHikSu As Decimal '�X�V�p������
		Dim strSOUCD As String '�q�ɃR�[�h
		Dim strHinCd As String '���i�R�[�h
		Dim bolRet As Boolean
		
		On Error GoTo F_HINMTB_Update_err
		
		F_HINMTB_Update = 9
		
		curHIKSU = 0
		curMotoHikSu = 0
		curUpdHikSu = 0
		
		'������
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		curHIKSU = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Item_Detail(mv_intINPHIKSU_Col).Dsp_Value)
		'��������
		curMotoHikSu = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_MOTO_HIKSU)
		'�X�V�p������
		curUpdHikSu = curMotoHikSu - curHIKSU
		'�q�ɃR�[�h
		strSOUCD = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_SOUCD
		'���i�R�[�h
		strHinCd = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_HINCD
		
		strSQL = ""
		strSQL = strSQL & " UPDATE HINMTB "
		strSQL = strSQL & " SET "
		strSQL = strSQL & "     HIKSU = HIKSU - " & CF_Ora_Number(CStr(curUpdHikSu))
		' === 20061119 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "   , CLTID = '" & CF_Ora_String(SSS_CLTID, 5) & "' "
		'   strSQL = strSQL & "   , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' "
		'   strSQL = strSQL & "   , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & "   , UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSQL = strSQL & "   , UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "   , UWRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' "
		strSQL = strSQL & "   , UWRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & "   , PGID   = '" & CF_Ora_String(SSS_PrgId, 7) & "'"
		' === 20061119 === UPDATE E -
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     DATKB =  '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
		strSQL = strSQL & " AND SOUCD =  '" & CF_Ora_String(strSOUCD, 3) & "'"
		strSQL = strSQL & " AND HINCD =  '" & CF_Ora_String(strHinCd, 10) & "'"
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_HINMTB_Update_err
		End If
		
		F_HINMTB_Update = 0
		
F_HINMTB_Update_End: 
		Exit Function
		
F_HINMTB_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_012, pm_All, "F_HINMTB_Update")
		GoTo F_HINMTB_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_INPTRA_Update
	'   �T�v�F  ���ח\��t�@�C���X�V����
	'   �����F  pin_intRow    : �s�ԍ�
	'           pm_All        : ��ʏ��
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_INPTRA_Update(ByVal pin_intRow As Short, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim curHIKSU As Decimal '������
		Dim curMotoHikSu As Decimal '��������
		Dim curUpdHikSu As Decimal '�X�V�p������
		Dim strHinCd As String '���i�R�[�h
		Dim strInpYtDt As String '���ח\���
		Dim strLotNo As String '���b�g�ԍ�
		Dim bolRet As Boolean
		
		On Error GoTo F_INPTRA_Update_err
		
		F_INPTRA_Update = 9
		
		curHIKSU = 0
		curMotoHikSu = 0
		curUpdHikSu = 0
		
		'������
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		curHIKSU = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Item_Detail(mv_intINPHIKSU_Col).Dsp_Value)
		'��������
		curMotoHikSu = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_MOTO_HIKSU)
		'�X�V�p������
		curUpdHikSu = curMotoHikSu - curHIKSU
		'���i�R�[�h
		strHinCd = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_HINCD
		'���ח\���
		strInpYtDt = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_NYUYTDT
		'���b�g�ԍ�
		strLotNo = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_LOTNO
		
		strSQL = ""
		strSQL = strSQL & " UPDATE INPTRA "
		strSQL = strSQL & " SET "
		strSQL = strSQL & "     INHIKSU = INHIKSU - " & CF_Ora_Number(CStr(curUpdHikSu))
		' === 20061119 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "   , CLTID   = '" & CF_Ora_String(SSS_CLTID, 5) & "' "
		'   strSQL = strSQL & "   , WRTTM   = '" & CF_Ora_String(GV_SysTime, 6) & "' "
		'   strSQL = strSQL & "   , WRTDT   = '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & "   , UOPEID  = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSQL = strSQL & "   , UCLTID  = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "   , UWRTTM  = '" & CF_Ora_String(GV_SysTime, 6) & "' "
		strSQL = strSQL & "   , UWRTDT  = '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & "   , PGID    = '" & CF_Ora_String(SSS_PrgId, 7) & "'"
		' === 20061119 === UPDATE E -
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     DATKB   =  '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
		strSQL = strSQL & " AND HINCD   =  '" & CF_Ora_String(strHinCd, 10) & "'"
		strSQL = strSQL & " AND INPYTDT =  '" & CF_Ora_String(strInpYtDt, 8) & "'"
		strSQL = strSQL & " AND LOTNO   =  '" & CF_Ora_String(strLotNo, 12) & "'"
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_INPTRA_Update_err
		End If
		
		F_INPTRA_Update = 0
		
F_INPTRA_Update_End: 
		Exit Function
		
F_INPTRA_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_012, pm_All, "F_INPTRA_Update")
		GoTo F_INPTRA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_DTLTRA_Main
	'   �T�v�F  �������󃁃C������
	'   �����F  pin_intRow    : �s�ԍ�
	'           pm_All        : ��ʏ��
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_DTLTRA_Main(ByVal pin_intRow As Short, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim intRet As Short
		' === 20070312 === INSERT S - ACE)Yano
		Dim intCnt As Short
		' === 20070312 === INSERT E -
		
		On Error GoTo F_DTLTRA_Main_err
		
		F_DTLTRA_Main = 9
		
		' === 20070208 === UPDATE S - ACE)Yano
		'   '��������t�@�C���擾
		'   intRet = F_DTLTRA_SELECT(pin_intRow, pm_All)
		'   If intRet <> 0 Then
		'       GoTo F_DTLTRA_Main_err
		'   End If
		' === 20070208 === UPDATE E -
		
		' === 20070208 === INSERT S - ACE)Yano
		
		'������
		mv_strKEY_TRAKB = ""
		mv_strKEY_TRANO = ""
		mv_strKEY_MITNOV = ""
		mv_strKEY_LINNO = ""
		mv_strKEY_PUDLNO = ""
		mv_strKEY_TRADT = ""
		mv_strKEY_HINCD = ""
		mv_strKEY_INPYTDT = ""
		mv_strKEY_LOTNO = ""
		mv_strKEY_SOUCD = ""
		
		With pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow)
			
			'�q�ɕʍ݌ɂ̏ꍇ
			If .Bus_Inf.SUB_KB = "1" Then
				'���i�R�[�h
				mv_strKEY_HINCD = .Bus_Inf.SUB_HINCD
				'���ח\���
				mv_strKEY_INPYTDT = "        "
				'���b�g�ԍ�
				mv_strKEY_LOTNO = "                    "
				'�q�ɃR�[�h
				mv_strKEY_SOUCD = .Bus_Inf.SUB_SOUCD
				'���
				mv_strKEY_TRAKB = CStr(HIKET51_Interface.Mode)
				'���ϔԍ�,�󒍔ԍ�
				mv_strKEY_TRANO = HIKET51_Interface.DENNO1
				'�Ő�
				mv_strKEY_MITNOV = HIKET51_Interface.DENNO2
				'�s�ԍ�
				mv_strKEY_LINNO = HIKET51_Interface.LINNO
				' === 20080715 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
				'�o�׎w����
				mv_curDTLTRA_FRDSU = .Bus_Inf.SUB_FRDSU
				' === 20080715 === INSERT E -
			Else
				'���i�R�[�h
				mv_strKEY_HINCD = .Bus_Inf.SUB_HINCD
				'���ח\���
				mv_strKEY_INPYTDT = .Bus_Inf.SUB_NYUYTDT
				'���b�g�ԍ�
				mv_strKEY_LOTNO = .Bus_Inf.SUB_LOTNO
				'�q�ɃR�[�h
				mv_strKEY_SOUCD = .Bus_Inf.SUB_SOUCD
				'���
				mv_strKEY_TRAKB = CStr(HIKET51_Interface.Mode)
				'���ϔԍ�,�󒍔ԍ�
				mv_strKEY_TRANO = HIKET51_Interface.DENNO1
				'�Ő�
				mv_strKEY_MITNOV = HIKET51_Interface.DENNO2
				'�s�ԍ�
				mv_strKEY_LINNO = HIKET51_Interface.LINNO
				' === 20080715 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
				'�o�׎w����
				mv_curDTLTRA_FRDSU = 0
				' === 20080715 === INSERT E -
			End If
			
		End With
		
		' === 20070208 === INSERT E -
		
		' === 20070312 === UPDATE S - ACE)Yano
		
		For intCnt = 1 To 2
			'�P���:���̈����� �� 0
			'�Q���:0 �� ���͈�����
			
			If mv_strKEY_TRAKB = "1" Then
				'���σg�����X�V
				intRet = F_MITTRA_Update(pin_intRow, pm_All, intCnt)
				If intRet <> 0 Then
					GoTo F_DTLTRA_Main_err
				End If
			Else
				'�󒍃g�����X�V
				intRet = F_JDNTRA_Update(pin_intRow, pm_All, intCnt)
				If intRet <> 0 Then
					GoTo F_DTLTRA_Main_err
				End If
			End If
			
			' === 20070208 === UPDATE S - ACE)Yano
			'   If mv_strDTLTRA_UMKB = "1" Then
			'       '��������t�@�C���X�V
			'       intRet = F_DTLTRA_Update(pin_intRow, pm_All)
			'       If intRet <> 0 Then
			'           GoTo F_DTLTRA_Main_err
			'       End If
			'   Else
			'       '��������t�@�C���ǉ�
			'       intRet = F_DTLTRA_Insert(pin_intRow, pm_All)
			'       If intRet <> 0 Then
			'           GoTo F_DTLTRA_Main_err
			'       End If
			'   End If
			
			' === 20080715 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
			'�o�׎w����(�Q��ڂ̓}�C�i�X�l�ɕύX)
			If intCnt = 2 Then
				mv_curDTLTRA_FRDSU = mv_curDTLTRA_FRDSU * (-1)
			End If
			' === 20080715 === INSERT E -
			
			'��������t�@�C������
			intRet = F_DTLTRA_Prc(pm_All)
			If intRet <> 0 Then
				GoTo F_DTLTRA_Main_err
			End If
			
		Next intCnt
		
		' === 20070312 === UPDATE E -
		' === 20070208 === UPDATE E -
		
		F_DTLTRA_Main = 0
		
F_DTLTRA_Main_End: 
		Exit Function
		
F_DTLTRA_Main_err: 
		GoTo F_DTLTRA_Main_End
		
	End Function
	
	' === 20070208 === INSERT S - ACE)Yano
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_DTLTRA_Prc
	'   �T�v�F  ��������t�@�C������
	'   �����F  pm_All        : ��ʏ��
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_DTLTRA_Prc(ByRef pm_All As Cls_All) As Short
		
		' �q�ɕʂɍ݌ɂ̎c���𒲂ׂĈ����Ă�悤�ɕύX����
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim intRet As Short
		
		On Error GoTo ERR_F_DTLTRA_Prc
		
		F_DTLTRA_Prc = 9
		
		'������
		mv_strDTLTRA_UMKB = "0"
		mv_strDTLTRA_TRAKB = ""
		mv_strDTLTRA_TRANO = ""
		mv_strDTLTRA_MITNOV = ""
		mv_strDTLTRA_LINNO = ""
		mv_strDTLTRA_PUDLNO = ""
		mv_strDTLTRA_TRADT = ""
		mv_strDTLTRA_ATMNKB = ""
		mv_strDTLTRA_HIKNO = ""
		mv_strDTLTRA_HINCD = ""
		mv_strDTLTRA_INPYTDT = ""
		mv_strDTLTRA_LOTNO = ""
		mv_strDTLTRA_SOUCD = ""
		mv_strDTLTRA_SISNKB = ""
		mv_strDTLTRA_SOUTRICD = ""
		mv_strDTLTRA_SOUKOKB = ""
		mv_curDTLTRA_HIKSU = 0
		'���������������Z�b�g
		mv_curDTLTRA_HIKSU_SA = mv_curATZHIKSU_SA + mv_curATNHIKSU_SA + mv_curMNZHIKSU_SA + mv_curMNNHIKSU_SA
		' === 20080715 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
		mv_curDTLTRA_HIKSU_SA = mv_curDTLTRA_HIKSU_SA + mv_curDTLTRA_FRDSU
		' === 20080715 === INSERT E -
		
		'��������t�@�C���擾SQL
		strSQL = F_GET_DTLTRA_SQL
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If mv_curDTLTRA_HIKSU_SA > 0 Then
			
			'///////////////////////////////////////////////
			'/ �����������炵��
			'///////////////////////////////////////////////
			
			'�擾���R�[�h��or�����������ɒB����܂ŏ������s��
			If CF_Ora_EOF(Usr_Ody) = False Then
				Do 
					mv_strDTLTRA_UMKB = "1" '�f�[�^�L��
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_TRAKB = CF_Ora_GetDyn(Usr_Ody, "TRAKB", "") '�g�������
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_TRANO = CF_Ora_GetDyn(Usr_Ody, "TRANO", "") '�g�����ԍ�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_MITNOV = CF_Ora_GetDyn(Usr_Ody, "MITNOV", "") '�Ő�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_LINNO = CF_Ora_GetDyn(Usr_Ody, "LINNO", "") '�s�ԍ�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_PUDLNO = CF_Ora_GetDyn(Usr_Ody, "PUDLNO", "") '���o�ɔԍ�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_TRADT = CF_Ora_GetDyn(Usr_Ody, "TRADT", "") '�g�������t
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_ATMNKB = CF_Ora_GetDyn(Usr_Ody, "ATMNKB", "") '�����蓮�敪
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_HIKNO = CF_Ora_GetDyn(Usr_Ody, "HIKNO", "") '�����ԍ�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "") '���i�R�[�h
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_INPYTDT = CF_Ora_GetDyn(Usr_Ody, "INPYTDT", "") '���ח\���
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_LOTNO = CF_Ora_GetDyn(Usr_Ody, "LOTNO", "") '���b�g�ԍ�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "") '�q�ɃR�[�h
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_SISNKB = CF_Ora_GetDyn(Usr_Ody, "SISNKB", "") '���Y���敪
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_SOUTRICD = CF_Ora_GetDyn(Usr_Ody, "SOUTRICD", "") '�����R�[�h
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_SOUKOKB = CF_Ora_GetDyn(Usr_Ody, "SOUKOKB", "") '�q�ɋ敪
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_curDTLTRA_HIKSU = CF_Ora_GetDyn(Usr_Ody, "HIKSU", 0) '������
					
					'�X�V�p�������̍쐬
					mv_curDTLTRA_UPD_HIKSU = 0
					'�X�V�p������>�擾����f�[�^(1����)�̈������̏ꍇ
					'�����f�[�^�����炵�AZERO�ōX�V
					If mv_curDTLTRA_HIKSU_SA > mv_curDTLTRA_HIKSU Then
						mv_curDTLTRA_HIKSU_SA = mv_curDTLTRA_HIKSU_SA - mv_curDTLTRA_HIKSU
						'�O�̂��ߌ���������������בΏۂ̃f�[�^���Z�b�g
						mv_curDTLTRA_UPD_HIKSU = mv_curDTLTRA_HIKSU
						'��������t�@�C���X�V�p�f�[�^�̃Z�b�g
						mv_curDTLTRA_HIKSU = 0
					Else
						'�X�V�p������<�擾����f�[�^(1����)�̈������̏ꍇ
						'�Ώۃf�[�^�ň����͊����ƂȂ�ׁA���������X�V
						'�O�̂��ߌ���������������׍������Z�b�g
						mv_curDTLTRA_UPD_HIKSU = mv_curDTLTRA_HIKSU_SA
						'��������t�@�C���X�V�p�f�[�^�̃Z�b�g
						mv_curDTLTRA_HIKSU = mv_curDTLTRA_HIKSU - mv_curDTLTRA_HIKSU_SA
						mv_curDTLTRA_HIKSU_SA = 0
					End If
					
					'��������t�@�C���X�V
					intRet = F_DTLTRA_Update(pm_All)
					If intRet <> 0 Then
						GoTo ERR_F_DTLTRA_Prc
					End If
					
					'�����R�[�h
					Call CF_Ora_MoveNext(Usr_Ody)
				Loop Until CF_Ora_EOF(Usr_Ody) = True Or mv_curDTLTRA_HIKSU_SA <= 0
				
			End If
			
		Else
			
			'///////////////////////////////////////////////
			'/ �������𑝂₵��
			'///////////////////////////////////////////////
			
			'�擾���R�[�h��or�����������ɒB����܂ŏ������s��
			If CF_Ora_EOF(Usr_Ody) = False Then
				Do 
					mv_strDTLTRA_UMKB = "1" '�f�[�^�L��
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_TRAKB = CF_Ora_GetDyn(Usr_Ody, "TRAKB", "") '�g�������
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_TRANO = CF_Ora_GetDyn(Usr_Ody, "TRANO", "") '�g�����ԍ�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_MITNOV = CF_Ora_GetDyn(Usr_Ody, "MITNOV", "") '�Ő�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_LINNO = CF_Ora_GetDyn(Usr_Ody, "LINNO", "") '�s�ԍ�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_PUDLNO = CF_Ora_GetDyn(Usr_Ody, "PUDLNO", "") '���o�ɔԍ�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_TRADT = CF_Ora_GetDyn(Usr_Ody, "TRADT", "") '�g�������t
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_ATMNKB = CF_Ora_GetDyn(Usr_Ody, "ATMNKB", "") '�����蓮�敪
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_HIKNO = CF_Ora_GetDyn(Usr_Ody, "HIKNO", "") '�����ԍ�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "") '���i�R�[�h
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_INPYTDT = CF_Ora_GetDyn(Usr_Ody, "INPYTDT", "") '���ח\���
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_LOTNO = CF_Ora_GetDyn(Usr_Ody, "LOTNO", "") '���b�g�ԍ�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "") '�q�ɃR�[�h
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_SISNKB = CF_Ora_GetDyn(Usr_Ody, "SISNKB", "") '���Y���敪
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_SOUTRICD = CF_Ora_GetDyn(Usr_Ody, "SOUTRICD", "") '�����R�[�h
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_strDTLTRA_SOUKOKB = CF_Ora_GetDyn(Usr_Ody, "SOUKOKB", "") '�q�ɋ敪
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					mv_curDTLTRA_HIKSU = CF_Ora_GetDyn(Usr_Ody, "HIKSU", 0) '������
					
					If mv_strDTLTRA_ATMNKB = "M" Then
						
						'�X�V�p�������̍쐬
						mv_curDTLTRA_UPD_HIKSU = 0
						
						'�����f�[�^�̑S�Ă������čX�V
						mv_curDTLTRA_UPD_HIKSU = mv_curDTLTRA_HIKSU_SA
						mv_curDTLTRA_HIKSU_SA = 0
						
						'��������t�@�C���X�V
						intRet = F_DTLTRA_Update(pm_All)
						If intRet <> 0 Then
							GoTo ERR_F_DTLTRA_Prc
						End If
						
					End If
					
					'�����R�[�h
					Call CF_Ora_MoveNext(Usr_Ody)
				Loop Until CF_Ora_EOF(Usr_Ody) = True Or mv_curDTLTRA_HIKSU_SA = 0
				
			End If
			
			If mv_curDTLTRA_HIKSU_SA <> 0 Then
				
				'��������t�@�C���ǉ�
				intRet = F_DTLTRA_Insert(pm_All)
				If intRet <> 0 Then
					GoTo ERR_F_DTLTRA_Prc
				End If
				
			End If
			
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		F_DTLTRA_Prc = 0
		
		Exit Function
		
ERR_F_DTLTRA_Prc: 
		
	End Function
	' === 20070208 === INSERT E -
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_DTLTRA_SQL
	'   �T�v�F  ��������t�@�C���擾�r�p�k����
	'   �����F  �Ȃ�
	'       �F�@pm_All               :��ʏ��
	'   �ߒl�F�@����SQL
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_DTLTRA_SQL() As String
		
		Dim strSQL As String
		
		'�����r�p�k���s
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     TRAKB "
		strSQL = strSQL & "   , TRANO "
		strSQL = strSQL & "   , MITNOV "
		strSQL = strSQL & "   , LINNO "
		strSQL = strSQL & "   , PUDLNO "
		strSQL = strSQL & "   , TRADT "
		strSQL = strSQL & "   , ATMNKB "
		strSQL = strSQL & "   , HIKNO "
		strSQL = strSQL & "   , HINCD "
		strSQL = strSQL & "   , INPYTDT "
		strSQL = strSQL & "   , LOTNO "
		strSQL = strSQL & "   , SOUCD "
		strSQL = strSQL & "   , SISNKB "
		strSQL = strSQL & "   , SOUTRICD "
		strSQL = strSQL & "   , SOUKOKB "
		strSQL = strSQL & "   , HIKSU "
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     HINCD = '" & CF_Ora_String(mv_strKEY_HINCD, 10) & "' "
		strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String(mv_strKEY_INPYTDT, 8) & "' "
		strSQL = strSQL & " And LOTNO    = '" & CF_Ora_String(mv_strKEY_LOTNO, 20) & "' "
		strSQL = strSQL & " And SOUCD    = '" & CF_Ora_String(mv_strKEY_SOUCD, 3) & "' "
		'����
		If HIKET51_Interface.Mode = CDbl("1") Then
			strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "' "
			strSQL = strSQL & " And MITNOV = '" & CF_Ora_String(mv_strKEY_MITNOV, 2) & "' "
			strSQL = strSQL & " And LINNO  = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "' "
		Else
			strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "' "
			strSQL = strSQL & " And LINNO  = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "' "
		End If
		strSQL = strSQL & " Order By "
		strSQL = strSQL & "     ATMNKB DESC "
		
		F_GET_DTLTRA_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_DTLTRA_SAIBAN
	'   �T�v�F  ��������t�@�C�������ԍ��̔ԏ���
	'   �����F�@pin_intRow           :�s�ԍ�
	'       �F�@pm_All               :��ʏ��
	'   �ߒl�F�@�����ԍ��i�̔Ԓl�j
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_DTLTRA_SAIBAN() As String
		
		Dim strSQL As String
		Dim strHikNo As String
		Dim curHikNo As Decimal
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		
		'������
		strHikNo = ""
		curHikNo = 0
		
		'�����r�p�k���s
		strSQL = ""
		strSQL = strSQL & " SELECT"
		strSQL = strSQL & "     NVL(MAX(TO_NUMBER(HIKNO)), 0)  HIKNO "
		strSQL = strSQL & " FROM"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " WHERE"
		strSQL = strSQL & "     TRAKB  = '" & CF_Ora_String(mv_strDTLTRA_TRAKB, 1) & "' "
		strSQL = strSQL & " AND TRANO  = '" & CF_Ora_String(mv_strDTLTRA_TRANO, 20) & "' "
		strSQL = strSQL & " AND MITNOV = '" & CF_Ora_String(mv_strDTLTRA_MITNOV, 2) & "' "
		strSQL = strSQL & " AND LINNO  = '" & CF_Ora_String(mv_strDTLTRA_LINNO, 3) & "' "
		strSQL = strSQL & " AND PUDLNO = '" & CF_Ora_String(mv_strDTLTRA_PUDLNO, 10) & "' "
		strSQL = strSQL & " AND TRADT  = '" & CF_Ora_String(mv_strDTLTRA_TRADT, 8) & "' "
		strSQL = strSQL & " AND HINCD  = '" & CF_Ora_String(mv_strDTLTRA_HINCD, 10) & "' "
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			curHikNo = 1
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curHikNo = CF_Ora_GetDyn(Usr_Ody, "HIKNO", 0)
			'���ı���
			curHikNo = curHikNo + 1
		End If
		
		strHikNo = CStr(curHikNo)
		F_GET_DTLTRA_SAIBAN = CF_ZeroLenFormat(strHikNo, 5)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_MITTRA_Update
	'   �T�v�F  ���σg�����X�V����
	'   �����F  pin_intRow    : �s�ԍ�
	'           pm_All        : ��ʏ��
	'           pin_Cnt       : ��(1or2)
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_MITTRA_Update(ByVal pin_intRow As Short, ByRef pm_All As Cls_All, ByVal pin_Cnt As Short) As Short
		
		Dim strSQL As String
		Dim curHIKSU As Decimal '������
		Dim curMotoHikSu As Decimal '��������
		Dim curUpdHikSu As Decimal '�X�V�p������
		Dim strHinCd As String '���i�R�[�h
		Dim strInpYtDt As String '���ח\���
		Dim strLotNo As String '���b�g�ԍ�
		Dim bolRet As Boolean
		' === 20070208 === INSERT S - ACE)Yano
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		' === 20070208 === INSERT E -
		
		On Error GoTo F_MITTRA_Update_err
		
		F_MITTRA_Update = 9
		
		' === 20070208 === INSERT S - ACE)Yano
		
		'���݂̌�����݌���SQL
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     ODNYTDT" '�o�ח\���
		strSQL = strSQL & " From"
		strSQL = strSQL & "     MITTRA "
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     DATKB   =  '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
		strSQL = strSQL & " AND MITNO   =  '" & CF_Ora_String(mv_strKEY_TRANO, 10) & "'"
		strSQL = strSQL & " AND MITNOV  =  '" & CF_Ora_String(mv_strKEY_MITNOV, 2) & "'"
		strSQL = strSQL & " AND LINNO   =  '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "'"
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			mv_strKEY_TRADT = CF_Ora_GetDyn(Usr_Ody, "ODNYTDT", "")
		End If
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		' === 20070208 === INSERT E -
		
		curHIKSU = 0
		curMotoHikSu = 0
		curUpdHikSu = 0
		strHinCd = ""
		strInpYtDt = ""
		strLotNo = ""
		
		' === 20070312 === UPDATE S - ACE)Yano
		'������
		'curHIKSU = CCur(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Item_Detail(mv_intINPHIKSU_Col).Dsp_Value)
		If pin_Cnt = 1 Then
			curHIKSU = 0
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curHIKSU = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Item_Detail(mv_intINPHIKSU_Col).Dsp_Value)
		End If
		'��������
		'curMotoHikSu = CCur(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_MOTO_HIKSU)
		If pin_Cnt = 1 Then
			curMotoHikSu = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_MOTO_HIKSU)
		Else
			curMotoHikSu = 0
		End If
		' === 20070312 === UPDATE E -
		'�X�V�p������
		curUpdHikSu = curMotoHikSu - curHIKSU
		
		' === 20070208 === INSERT S - ACE)Yano
		mv_curATZHIKSU_SA = 0
		mv_curATNHIKSU_SA = 0
		If pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_KB = "1" Then
			mv_curMNZHIKSU_SA = curUpdHikSu
			mv_curMNNHIKSU_SA = 0
		Else
			mv_curMNZHIKSU_SA = 0
			mv_curMNNHIKSU_SA = curUpdHikSu
		End If
		' === 20070208 === INSERT E -
		
		'���i�R�[�h
		strHinCd = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_HINCD
		'���ח\���
		strInpYtDt = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_NYUYTDT
		'���b�g�ԍ�
		strLotNo = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_LOTNO
		
		strSQL = ""
		strSQL = strSQL & " UPDATE MITTRA "
		strSQL = strSQL & " SET "
		'(����������ύX�����}�C�i�X�B���������̓v���X�B)
		'�q�ɕʍ݌ɂ̏ꍇ(���݌ɂ̍X�V)
		If pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_KB = "1" Then
			strSQL = strSQL & "     ZAIHIKSU = ZAIHIKSU  - " & CF_Ora_Number(CStr(curUpdHikSu))
		Else
			strSQL = strSQL & "     NYTHIKSU = NYTHIKSU  - " & CF_Ora_Number(CStr(curUpdHikSu))
		End If
		' === 20061119 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "   , CLTID   = '" & CF_Ora_String(SSS_CLTID, 5) & "' "
		'   strSQL = strSQL & "   , WRTTM   = '" & CF_Ora_String(GV_SysTime, 6) & "' "
		'   strSQL = strSQL & "   , WRTDT   = '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & "   , UOPEID  = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSQL = strSQL & "   , UCLTID  = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "   , UWRTTM  = '" & CF_Ora_String(GV_SysTime, 6) & "' "
		strSQL = strSQL & "   , UWRTDT  = '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & "   , PGID    = '" & CF_Ora_String(SSS_PrgId, 7) & "'"
		' === 20061119 === UPDATE E -
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     DATKB   =  '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
		' === 20070208 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & " AND MITNO   =  '" & CF_Ora_String(mv_strDTLTRA_TRANO, 10) & "'"
		'   strSQL = strSQL & " AND MITNOV  =  '" & CF_Ora_String(mv_strDTLTRA_MITNOV, 2) & "'"
		'   strSQL = strSQL & " AND LINNO   =  '" & CF_Ora_String(mv_strDTLTRA_LINNO, 3) & "'"
		strSQL = strSQL & " AND MITNO   =  '" & CF_Ora_String(mv_strKEY_TRANO, 10) & "'"
		strSQL = strSQL & " AND MITNOV  =  '" & CF_Ora_String(mv_strKEY_MITNOV, 2) & "'"
		strSQL = strSQL & " AND LINNO   =  '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "'"
		' === 20070208 === UPDATE E -
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_MITTRA_Update_err
		End If
		
		'20080729 ADD START RISE)Tanimura '�r������
		HIKET51_Interface.UOPEID = CF_Ora_String(SSS_OPEID.Value, 8)
		HIKET51_Interface.UCLTID = CF_Ora_String(SSS_CLTID.Value, 5)
		HIKET51_Interface.UWRTTM = CF_Ora_String(GV_SysTime, 6)
		HIKET51_Interface.UWRTDT = CF_Ora_String(GV_SysDate, 8)
		'20080729 ADD END   RISE)Tanimura
		
		F_MITTRA_Update = 0
		
F_MITTRA_Update_End: 
		Exit Function
		
F_MITTRA_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_012, pm_All, "F_MITTRA_Update")
		GoTo F_MITTRA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_JDNTRA_Update
	'   �T�v�F  �󒍃g�����X�V����
	'   �����F  pin_intRow    : �s�ԍ�
	'           pm_All        : ��ʏ��
	'           pin_Cnt       : ��(1or2)
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_JDNTRA_Update(ByVal pin_intRow As Short, ByRef pm_All As Cls_All, ByVal pin_Cnt As Short) As Short
		
		Dim strSQL As String
		Dim curHIKSU As Decimal '������
		Dim curMotoHikSu As Decimal '��������
		Dim curUpdHikSu As Decimal '�X�V�p������
		Dim strHinCd As String '���i�R�[�h
		Dim strInpYtDt As String '���ח\���
		Dim strLotNo As String '���b�g�ԍ�
		Dim bolRet As Boolean
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim curAtzHikSu As Decimal '�����݌Ɉ�����
		Dim curAtnHikSu As Decimal '�������ɗ\�������
		Dim curMnzHikSu As Decimal '�蓮�݌Ɉ�����
		Dim curMnnHikSu As Decimal '�蓮���ɗ\�������
		Dim curUpdAtzHikSu As Decimal '�����݌Ɉ�����(�X�V�p)
		Dim curUpdAtnHikSu As Decimal '�������ɗ\�������(�X�V�p)
		Dim curUpdMnzHikSu As Decimal '�蓮�݌Ɉ�����(�X�V�p)
		Dim curUpdMnnHikSu As Decimal '�蓮���ɗ\�������(�X�V�p)
		' === 20080715 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
		Dim curFRDSU_WK As Decimal '�o�׎w�����i�v�Z�p)
		' === 20080715 === INSERT E -
		
		On Error GoTo F_JDNTRA_Update_err
		
		F_JDNTRA_Update = 9
		
		' === 20080715 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
		curFRDSU_WK = mv_curDTLTRA_FRDSU
		' === 20080715 === INSERT E -
		
		'���݂̎���݌���SQL
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     ATZHIKSU" '�����݌Ɉ�����
		strSQL = strSQL & "    ,ATNHIKSU" '�������ɗ\�������
		strSQL = strSQL & "    ,MNZHIKSU" '�蓮�݌Ɉ�����
		strSQL = strSQL & "    ,MNNHIKSU" '�蓮���ɗ\�������
		' === 20070208 === INSERT S - ACE)Yano
		strSQL = strSQL & "    ,PUDLNO" '���o�ɔԍ�
		strSQL = strSQL & "    ,ODNYTDT" '�o�ח\���
		' === 20070208 === INSERT E -
		strSQL = strSQL & " From"
		' === 20060907 === UPDATE S - ACE)Hashiri �ԍ��Ή�(JDNTRV�ɕύX)
		' === 20061107 === UPDATE S - ACE)Yano     View���ð��ق���̎擾�ɍĕύX
		''strSQL = strSQL & "     JDNTRA"
		''strSQL = strSQL & "     JDNTRV "
		strSQL = strSQL & "     JDNTRA TRA"
		strSQL = strSQL & "    ,( SELECT MAX(DATNO) As DATNO"
		strSQL = strSQL & "             ,JDNNO"
		strSQL = strSQL & "             ,LINNO"
		strSQL = strSQL & "       FROM   JDNTRA"
		strSQL = strSQL & "       WHERE "
		strSQL = strSQL & "              DATKB  = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
		' === 20070208 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "       AND    JDNNO  = '" & CF_Ora_String(mv_strDTLTRA_TRANO, 10) & "'"
		'   strSQL = strSQL & "       AND    LINNO  = '" & CF_Ora_String(mv_strDTLTRA_LINNO, 3) & "'"
		strSQL = strSQL & "       AND    JDNNO  = '" & CF_Ora_String(mv_strKEY_TRANO, 10) & "'"
		strSQL = strSQL & "       AND    LINNO  = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "'"
		' === 20070208 === UPDATE E -
		strSQL = strSQL & "       GROUP BY JDNNO"
		strSQL = strSQL & "               ,LINNO"
		strSQL = strSQL & "     ) TRB"
		' === 20060907 === UPDATE E -
		''strSQL = strSQL & " WHERE "
		''strSQL = strSQL & "     DATKB   = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
		''strSQL = strSQL & " AND JDNNO   = '" & CF_Ora_String(mv_strDTLTRA_TRANO, 10) & "'"
		''strSQL = strSQL & " AND LINNO   = '" & CF_Ora_String(mv_strDTLTRA_LINNO, 3) & "'"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     TRA.DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
		strSQL = strSQL & " And TRA.AKAKROKB = '1'"
		strSQL = strSQL & " And TRA.DATNO    = TRB.DATNO"
		strSQL = strSQL & " And TRA.JDNNO    = TRB.JDNNO"
		strSQL = strSQL & " And TRA.LINNO    = TRB.LINNO"
		' === 20070208 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & " AND TRA.JDNNO    = '" & CF_Ora_String(mv_strDTLTRA_TRANO, 10) & "'"
		'   strSQL = strSQL & " AND TRA.LINNO    = '" & CF_Ora_String(mv_strDTLTRA_LINNO, 3) & "'"
		strSQL = strSQL & " AND TRA.JDNNO    = '" & CF_Ora_String(mv_strKEY_TRANO, 10) & "'"
		strSQL = strSQL & " AND TRA.LINNO    = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "'"
		' === 20070208 === UPDATE E -
		' === 20061107 === UPDATE E -
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If CF_Ora_EOF(Usr_Ody) = True Then
			curAtzHikSu = 0
			curAtnHikSu = 0
			curMnzHikSu = 0
			curMnnHikSu = 0
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curAtzHikSu = CF_Ora_GetDyn(Usr_Ody, "ATZHIKSU", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curAtnHikSu = CF_Ora_GetDyn(Usr_Ody, "ATNHIKSU", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curMnzHikSu = CF_Ora_GetDyn(Usr_Ody, "MNZHIKSU", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curMnnHikSu = CF_Ora_GetDyn(Usr_Ody, "MNNHIKSU", 0)
			' === 20070208 === INSERT S - ACE)Yano
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			mv_strKEY_PUDLNO = CF_Ora_GetDyn(Usr_Ody, "PUDLNO", "")
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			mv_strKEY_TRADT = CF_Ora_GetDyn(Usr_Ody, "ODNYTDT", "")
			' === 20070208 === INSERT E -
		End If
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		' === 20070208 === INSERT S - ACE)Yano
		
		'����̧�ٌ���SQL�i�����݌Ɉ������j
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     Sum(HIKSU)  As ATZHIKSU" '�����݌Ɉ�����
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     HINCD = '" & CF_Ora_String(mv_strKEY_HINCD, 10) & "' "
		If mv_strKEY_INPYTDT = "        " Then
			strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String(mv_strKEY_INPYTDT, 8) & "' "
		Else
			strSQL = strSQL & " And INPYTDT = '99999999' "
		End If
		strSQL = strSQL & " And SOUCD    = '" & CF_Ora_String(mv_strKEY_SOUCD, 3) & "' "
		strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "' "
		strSQL = strSQL & " And LINNO  = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "' "
		strSQL = strSQL & " And ATMNKB = 'A' "
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If CF_Ora_EOF(Usr_Ody) = True Then
			curAtzHikSu = 0
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curAtzHikSu = CF_Ora_GetDyn(Usr_Ody, "ATZHIKSU", 0)
		End If
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'����̧�ٌ���SQL�i�������ɗ\��������j
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     Sum(HIKSU)  As ATNHIKSU" '�������ɗ\�������
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     HINCD = '" & CF_Ora_String(mv_strKEY_HINCD, 10) & "' "
		If mv_strKEY_INPYTDT <> "        " Then
			strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String(mv_strKEY_INPYTDT, 8) & "' "
		Else
			strSQL = strSQL & " And INPYTDT = '99999999' "
		End If
		strSQL = strSQL & " And LOTNO    = '" & CF_Ora_String(mv_strKEY_LOTNO, 20) & "' "
		strSQL = strSQL & " And SOUCD    = '" & CF_Ora_String(mv_strKEY_SOUCD, 3) & "' "
		strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "' "
		strSQL = strSQL & " And LINNO  = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "' "
		strSQL = strSQL & " And ATMNKB = 'A' "
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If CF_Ora_EOF(Usr_Ody) = True Then
			curAtnHikSu = 0
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curAtnHikSu = CF_Ora_GetDyn(Usr_Ody, "ATNHIKSU", 0)
		End If
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'����̧�ٌ���SQL�i�蓮�݌Ɉ������j
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     Sum(HIKSU)  As MNZHIKSU" '�蓮�݌Ɉ�����
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     HINCD = '" & CF_Ora_String(mv_strKEY_HINCD, 10) & "' "
		If mv_strKEY_INPYTDT = "        " Then
			strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String(mv_strKEY_INPYTDT, 8) & "' "
		Else
			strSQL = strSQL & " And INPYTDT = '99999999' "
		End If
		strSQL = strSQL & " And SOUCD    = '" & CF_Ora_String(mv_strKEY_SOUCD, 3) & "' "
		strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "' "
		strSQL = strSQL & " And LINNO  = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "' "
		strSQL = strSQL & " And ATMNKB = 'M' "
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If CF_Ora_EOF(Usr_Ody) = True Then
			curMnzHikSu = 0
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curMnzHikSu = CF_Ora_GetDyn(Usr_Ody, "MNZHIKSU", 0)
		End If
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'����̧�ٌ���SQL�i�蓮���ɗ\��������j
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     Sum(HIKSU)  As MNNHIKSU" '�蓮���ɗ\�������
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     HINCD = '" & CF_Ora_String(mv_strKEY_HINCD, 10) & "' "
		If mv_strKEY_INPYTDT <> "        " Then
			strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String(mv_strKEY_INPYTDT, 8) & "' "
		Else
			strSQL = strSQL & " And INPYTDT = '99999999' "
		End If
		strSQL = strSQL & " And LOTNO    = '" & CF_Ora_String(mv_strKEY_LOTNO, 20) & "' "
		strSQL = strSQL & " And SOUCD    = '" & CF_Ora_String(mv_strKEY_SOUCD, 3) & "' "
		strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "' "
		strSQL = strSQL & " And LINNO  = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "' "
		strSQL = strSQL & " And ATMNKB = 'M' "
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If CF_Ora_EOF(Usr_Ody) = True Then
			curMnnHikSu = 0
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curMnnHikSu = CF_Ora_GetDyn(Usr_Ody, "MNNHIKSU", 0)
		End If
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		' === 20070208 === INSERT E -
		
		' === 20080715 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
		'�������݌Ɉ��������v�Z�i�o�׎w�������}�C�i�X)
		If mv_curFRDSU_AT_WK > 0 Then
			If curFRDSU_WK > 0 Then
				If mv_curFRDSU_AT_WK >= curFRDSU_WK Then
					If curAtzHikSu - curFRDSU_WK >= 0 Then
						curAtzHikSu = curAtzHikSu - curFRDSU_WK
						If pin_Cnt = 2 Then
							mv_curFRDSU_AT_WK = mv_curFRDSU_AT_WK - curFRDSU_WK
						End If
						curFRDSU_WK = 0
					Else
						If pin_Cnt = 2 Then
							mv_curFRDSU_AT_WK = mv_curFRDSU_AT_WK - curAtzHikSu
						End If
						curFRDSU_WK = curFRDSU_WK - curAtzHikSu
						curAtzHikSu = 0
					End If
				Else
					If curAtzHikSu - mv_curFRDSU_AT_WK >= 0 Then
						curAtzHikSu = curAtzHikSu - mv_curFRDSU_AT_WK
						curFRDSU_WK = curFRDSU_WK - mv_curFRDSU_AT_WK
						If pin_Cnt = 2 Then
							mv_curFRDSU_AT_WK = 0
						End If
					Else
						If pin_Cnt = 2 Then
							mv_curFRDSU_AT_WK = mv_curFRDSU_AT_WK - curAtzHikSu
						End If
						curFRDSU_WK = curFRDSU_WK - curAtzHikSu
						curAtzHikSu = 0
					End If
				End If
			End If
		End If
		
		'�蓮���݌Ɉ��������v�Z�i�o�׎w�������}�C�i�X)
		If mv_curFRDSU_MN_WK > 0 Then
			If curFRDSU_WK > 0 Then
				If mv_curFRDSU_MN_WK >= curFRDSU_WK Then
					If curMnzHikSu - curFRDSU_WK >= 0 Then
						curMnzHikSu = curMnzHikSu - curFRDSU_WK
						If pin_Cnt = 2 Then
							mv_curFRDSU_MN_WK = mv_curFRDSU_MN_WK - curFRDSU_WK
						End If
						curFRDSU_WK = 0
					Else
						'������̃��W�b�N�͒ʂ�Ȃ��͂�(�O�̂��߁B�B)
						If pin_Cnt = 2 Then
							mv_curFRDSU_MN_WK = mv_curFRDSU_MN_WK - curMnzHikSu
						End If
						curFRDSU_WK = curFRDSU_WK - curMnzHikSu
						curMnzHikSu = 0
					End If
				Else
					If curMnzHikSu - mv_curFRDSU_MN_WK >= 0 Then
						curMnzHikSu = curMnzHikSu - mv_curFRDSU_MN_WK
						curFRDSU_WK = curFRDSU_WK - mv_curFRDSU_MN_WK
						If pin_Cnt = 2 Then
							mv_curFRDSU_MN_WK = 0
						End If
					Else
						'������̃��W�b�N�͒ʂ�Ȃ��͂�(�O�̂��߁B�B)
						If pin_Cnt = 2 Then
							mv_curFRDSU_MN_WK = mv_curFRDSU_MN_WK - curMnzHikSu
						End If
						curFRDSU_WK = curFRDSU_WK - curMnzHikSu
						curMnzHikSu = 0
					End If
				End If
			End If
		End If
		
		' === 20080715 === INSERT E -
		
		curHIKSU = 0
		curMotoHikSu = 0
		curUpdHikSu = 0
		strHinCd = ""
		strInpYtDt = ""
		strLotNo = ""
		curUpdAtzHikSu = curAtzHikSu
		curUpdAtnHikSu = curAtnHikSu
		curUpdMnzHikSu = curMnzHikSu
		curUpdMnnHikSu = curMnnHikSu
		
		' === 20070312 === UPDATE S - ACE)Yano
		'������
		'curHIKSU = CCur(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Item_Detail(mv_intINPHIKSU_Col).Dsp_Value)
		If pin_Cnt = 1 Then
			curHIKSU = 0
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curHIKSU = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Item_Detail(mv_intINPHIKSU_Col).Dsp_Value)
		End If
		'��������
		'curMotoHikSu = CCur(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_MOTO_HIKSU)
		If pin_Cnt = 1 Then
			curMotoHikSu = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_MOTO_HIKSU)
		Else
			curMotoHikSu = 0
		End If
		' === 20070312 === UPDATE E -
		'�X�V�p������
		curUpdHikSu = curMotoHikSu - curHIKSU
		
		'(����������ύX�����}�C�i�X�B���������̓v���X�B)
		If pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_KB = "1" Then
			'�q�ɕʍ݌ɂ̏ꍇ(���݌ɂ̍X�V)
			If curMnzHikSu > curUpdHikSu Then
				curUpdMnzHikSu = curMnzHikSu - curUpdHikSu
			Else
				curUpdMnzHikSu = 0
				curUpdAtzHikSu = curAtzHikSu - (curUpdHikSu - curMnzHikSu)
			End If
		Else
			'���ח\��̏ꍇ(���ח\��̍X�V)
			If curMnnHikSu > curUpdHikSu Then
				curUpdMnnHikSu = curMnnHikSu - curUpdHikSu
			Else
				curUpdMnnHikSu = 0
				curUpdAtnHikSu = curAtnHikSu - (curUpdHikSu - curMnnHikSu)
			End If
		End If
		
		' === 20070208 === INSERT S - ACE)Yano
		mv_curATZHIKSU_SA = curAtzHikSu - curUpdAtzHikSu
		mv_curATNHIKSU_SA = curAtnHikSu - curUpdAtnHikSu
		mv_curMNZHIKSU_SA = curMnzHikSu - curUpdMnzHikSu
		mv_curMNNHIKSU_SA = curMnnHikSu - curUpdMnnHikSu
		' === 20070208 === INSERT E -
		
		'���i�R�[�h
		strHinCd = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_HINCD
		'���ח\���
		strInpYtDt = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_NYUYTDT
		'���b�g�ԍ�
		strLotNo = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_LOTNO
		
		strSQL = ""
		' === 20060907 === UPDATE S - ACE)Hashiri �ԍ��Ή�(JDNTRV�ɕύX)
		' === 20061107 === UPDATE S - ACE)Yano    View���ð��ق���̍X�V�ɖ߂�
		''strSQL = strSQL & " UPDATE JDNTRA"
		''strSQL = strSQL & " UPDATE JDNTRV"
		strSQL = strSQL & " UPDATE JDNTRA TRA"
		' === 20061107 === UPDATE E -
		' === 20060907 === UPDATE E -
		strSQL = strSQL & " SET "
		strSQL = strSQL & "     ATZHIKSU = ATZHIKSU - " & CF_Ora_Number(CStr(mv_curATZHIKSU_SA))
		strSQL = strSQL & "   , ATNHIKSU = ATNHIKSU - " & CF_Ora_Number(CStr(mv_curATNHIKSU_SA))
		strSQL = strSQL & "   , MNZHIKSU = MNZHIKSU - " & CF_Ora_Number(CStr(mv_curMNZHIKSU_SA))
		strSQL = strSQL & "   , MNNHIKSU = MNNHIKSU - " & CF_Ora_Number(CStr(mv_curMNNHIKSU_SA))
		' === 20061119 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "   , CLTID   = '" & CF_Ora_String(SSS_CLTID, 5) & "' "
		'   strSQL = strSQL & "   , WRTTM   = '" & CF_Ora_String(GV_SysTime, 6) & "' "
		'   strSQL = strSQL & "   , WRTDT   = '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & "   , UOPEID  = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSQL = strSQL & "   , UCLTID  = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "   , UWRTTM  = '" & CF_Ora_String(GV_SysTime, 6) & "' "
		strSQL = strSQL & "   , UWRTDT  = '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & "   , PGID    = '" & CF_Ora_String(SSS_PrgId, 7) & "'"
		' === 20061119 === UPDATE E -
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     DATKB   = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
		' === 20070208 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & " AND JDNNO   = '" & CF_Ora_String(mv_strDTLTRA_TRANO, 10) & "'"
		'   strSQL = strSQL & " AND LINNO   = '" & CF_Ora_String(mv_strDTLTRA_LINNO, 3) & "'"
		strSQL = strSQL & " AND JDNNO   = '" & CF_Ora_String(mv_strKEY_TRANO, 10) & "'"
		strSQL = strSQL & " AND LINNO   = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "'"
		' === 20070208 === UPDATE E -
		' === 20061107 === UPDATE S - ACE)Yano    View���ð��ق���̍X�V�ɖ߂�
		strSQL = strSQL & " AND AKAKROKB = '1' "
		strSQL = strSQL & " AND DATNO    = ( SELECT MAX(DATNO) DATNO "
		strSQL = strSQL & "                    FROM JDNTRA TRB "
		strSQL = strSQL & "                   WHERE TRB.DATKB  = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
		' === 20070208 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "                     AND TRB.JDNNO  = '" & CF_Ora_String(mv_strDTLTRA_TRANO, 10) & "'"
		'   strSQL = strSQL & "                     AND TRB.LINNO  = '" & CF_Ora_String(mv_strDTLTRA_LINNO, 3) & "'"
		strSQL = strSQL & "                     AND TRB.JDNNO  = '" & CF_Ora_String(mv_strKEY_TRANO, 10) & "'"
		strSQL = strSQL & "                     AND TRB.LINNO  = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "'"
		' === 20070208 === UPDATE E -
		strSQL = strSQL & "                     AND TRB.JDNNO = TRA.JDNNO "
		strSQL = strSQL & "                     AND TRB.LINNO = TRA.LINNO "
		strSQL = strSQL & "                GROUP BY JDNNO "
		strSQL = strSQL & "                       , LINNO "
		strSQL = strSQL & "                ) "
		' === 20061107 === UPDATE E -
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_JDNTRA_Update_err
		End If
		
		'20080729 ADD START RISE)Tanimura '�r������
		HIKET51_Interface.UOPEID = CF_Ora_String(SSS_OPEID.Value, 8)
		HIKET51_Interface.UCLTID = CF_Ora_String(SSS_CLTID.Value, 5)
		HIKET51_Interface.UWRTTM = CF_Ora_String(GV_SysTime, 6)
		HIKET51_Interface.UWRTDT = CF_Ora_String(GV_SysDate, 8)
		'20080729 ADD END   RISE)Tanimura
		
		F_JDNTRA_Update = 0
		
F_JDNTRA_Update_End: 
		Exit Function
		
F_JDNTRA_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_012, pm_All, "F_JDNTRA_Update")
		GoTo F_JDNTRA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_DTLTRA_Update
	'   �T�v�F  ��������t�@�C���X�V����
	'   �����F  pm_All        : ��ʏ��
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_DTLTRA_Update(ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim curHIKSU As Decimal '������
		Dim bolRet As Boolean
		
		On Error GoTo F_DTLTRA_Update_err
		
		F_DTLTRA_Update = 9
		
		strSQL = ""
		strSQL = strSQL & " UPDATE DTLTRA "
		strSQL = strSQL & " SET "
		strSQL = strSQL & "     HIKSU   = HIKSU - " & CF_Ora_Number(CStr(mv_curDTLTRA_UPD_HIKSU))
		strSQL = strSQL & "   , CLTID   = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' "
		strSQL = strSQL & "   , WRTTM   = '" & CF_Ora_String(GV_SysTime, 6) & "' "
		strSQL = strSQL & "   , WRTDT   = '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     TRAKB   =  '" & CF_Ora_String(mv_strDTLTRA_TRAKB, 1) & "'"
		strSQL = strSQL & " AND TRANO   =  '" & CF_Ora_String(mv_strDTLTRA_TRANO, 20) & "'"
		strSQL = strSQL & " AND MITNOV  =  '" & CF_Ora_String(mv_strDTLTRA_MITNOV, 2) & "'"
		strSQL = strSQL & " AND LINNO   =  '" & CF_Ora_String(mv_strDTLTRA_LINNO, 3) & "'"
		strSQL = strSQL & " AND PUDLNO  =  '" & CF_Ora_String(mv_strDTLTRA_PUDLNO, 10) & "'"
		strSQL = strSQL & " AND TRADT   =  '" & CF_Ora_String(mv_strDTLTRA_TRADT, 8) & "'"
		strSQL = strSQL & " AND HIKNO   =  '" & CF_Ora_String(mv_strDTLTRA_HIKNO, 5) & "'"
		strSQL = strSQL & " AND HINCD   =  '" & CF_Ora_String(mv_strDTLTRA_HINCD, 10) & "'"
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_DTLTRA_Update_err
		End If
		
		'///////////////// 2006.08.11 ACE MENTE START ////////////////////////
		' ������=0�Ȃ�΁A�폜����
		strSQL = ""
		strSQL = strSQL & " DELETE FROM DTLTRA "
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     TRAKB   = '" & CF_Ora_String(mv_strDTLTRA_TRAKB, 1) & "'"
		strSQL = strSQL & " AND TRANO   = '" & CF_Ora_String(mv_strDTLTRA_TRANO, 20) & "'"
		strSQL = strSQL & " AND MITNOV  = '" & CF_Ora_String(mv_strDTLTRA_MITNOV, 2) & "'"
		strSQL = strSQL & " AND LINNO   = '" & CF_Ora_String(mv_strDTLTRA_LINNO, 3) & "'"
		strSQL = strSQL & " AND PUDLNO  = '" & CF_Ora_String(mv_strDTLTRA_PUDLNO, 10) & "'"
		strSQL = strSQL & " AND TRADT   = '" & CF_Ora_String(mv_strDTLTRA_TRADT, 8) & "' "
		strSQL = strSQL & " AND HIKNO   = '" & CF_Ora_String(mv_strDTLTRA_HIKNO, 5) & "'"
		strSQL = strSQL & " AND HINCD   = '" & CF_Ora_String(mv_strDTLTRA_HINCD, 10) & "' "
		strSQL = strSQL & " AND HIKSU   = 0 "
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_DTLTRA_Update_err
		End If
		'///////////////// 2006.08.11 ACE MENTE E N D ////////////////////////
		
		F_DTLTRA_Update = 0
		
F_DTLTRA_Update_End: 
		Exit Function
		
F_DTLTRA_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_012, pm_All, "F_DTLTRA_Update")
		GoTo F_DTLTRA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_DTLTRA_Insert
	'   �T�v�F  ��������t�@�C���ǉ�����
	'   �����F  pm_All        : ��ʏ��
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_DTLTRA_Insert(ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_DTLTRA_Insert_err
		
		F_DTLTRA_Insert = 9
		
		'���݌ɂ��������Ă�ׁA�����R�[�h�̃f�[�^���Z�b�g
		mv_strDTLTRA_TRAKB = mv_strKEY_TRAKB '�g�������
		mv_strDTLTRA_TRANO = mv_strKEY_TRANO '�g�����ԍ�
		mv_strDTLTRA_MITNOV = mv_strKEY_MITNOV '�Ő�
		mv_strDTLTRA_LINNO = mv_strKEY_LINNO '�s�ԍ�
		mv_strDTLTRA_PUDLNO = mv_strKEY_PUDLNO '���o�ɔԍ�
		mv_strDTLTRA_TRADT = mv_strKEY_TRADT '�g�������t
		mv_strDTLTRA_ATMNKB = "M" '�����蓮�敪
		mv_strDTLTRA_HINCD = mv_strKEY_HINCD '���i�R�[�h
		mv_strDTLTRA_SOUCD = mv_strKEY_SOUCD '���i�R�[�h
		
		mv_strDTLTRA_HIKNO = F_GET_DTLTRA_SAIBAN '�����ԍ�(�̔ԏ���)
		
		mv_strDTLTRA_INPYTDT = mv_strKEY_INPYTDT '���ח\���
		mv_strDTLTRA_LOTNO = mv_strKEY_LOTNO '���b�g�ԍ�
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO DTLTRA "
		strSQL = strSQL & "  SELECT "
		strSQL = strSQL & "     '" & CF_Ora_String(mv_strDTLTRA_TRAKB, 1) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_TRANO, 20) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_MITNOV, 2) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_LINNO, 3) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_PUDLNO, 10) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_TRADT, 8) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_HIKNO, 5) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_ATMNKB, 1) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_HINCD, 10) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_INPYTDT, 8) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_LOTNO, 20) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_SOUCD, 3) & "' "
		strSQL = strSQL & "   , SOUMTA.SISNKB "
		strSQL = strSQL & "   , SOUMTA.SOUTRICD "
		strSQL = strSQL & "   , SOUMTA.SOUKOKB "
		strSQL = strSQL & "   ,  " & CF_Ora_Number(CStr(System.Math.Abs(mv_curDTLTRA_HIKSU_SA)))
		strSQL = strSQL & "   , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(GV_SysTime, 6) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(GV_SysTime, 6) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & "  FROM "
		strSQL = strSQL & "        SOUMTA "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        SOUCD = '" & CF_Ora_String(mv_strDTLTRA_SOUCD, 3) & "' "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_DTLTRA_Insert_err
		End If
		
		F_DTLTRA_Insert = 0
		
F_DTLTRA_Insert_End: 
		Exit Function
		
F_DTLTRA_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_012, pm_All, "F_DTLTRA_Insert")
		GoTo F_DTLTRA_Insert_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_STOTRA_Update
	'   �T�v�F  ���i�t�@�C���X�V����
	'   �����F  pin_intRow    : �s�ԍ�
	'           pm_All        : ��ʏ��
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_STOTRA_Update(ByVal pin_intRow As Short, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim curHIKSU As Decimal '������
		Dim curMotoHikSu As Decimal '��������
		Dim curUpdHikSu As Decimal '�X�V������
		Dim strSOUCD As String '�q�ɃR�[�h
		Dim strOdnYtDt As String '�o�ח\���
		Dim strHinCd As String '���i�R�[�h
		Dim bolRet As Boolean
		
		On Error GoTo F_STOTRA_Update_err
		
		F_STOTRA_Update = 9
		
		curHIKSU = 0
		curMotoHikSu = 0
		curUpdHikSu = 0
		strSOUCD = ""
		strOdnYtDt = ""
		strHinCd = ""
		
		'������
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		curHIKSU = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Item_Detail(mv_intINPHIKSU_Col).Dsp_Value)
		'��������
		curMotoHikSu = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_MOTO_HIKSU)
		'�X�V�������̌v�Z
		curUpdHikSu = curMotoHikSu - curHIKSU
		
		'�q�ɃR�[�h
		strSOUCD = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_SOUCD
		'�o�ח\���
		'   strOdnYtDt = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_ODNYTDT
		strOdnYtDt = GV_UNYDate
		'���i�R�[�h
		strHinCd = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_HINCD
		
		strSQL = ""
		strSQL = strSQL & " UPDATE STOTRA "
		strSQL = strSQL & " SET "
		strSQL = strSQL & "     HIKSU   =  HIKSU  - " & CF_Ora_Number(CStr(curUpdHikSu))
		strSQL = strSQL & "   , CLTID   = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' "
		strSQL = strSQL & "   , WRTTM   = '" & CF_Ora_String(GV_SysTime, 6) & "' "
		strSQL = strSQL & "   , WRTDT   = '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     DATKB   = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
		strSQL = strSQL & " And SOUCD   = '" & CF_Ora_String(strSOUCD, 3) & "' "
		strSQL = strSQL & " And ODNYTDT = '" & CF_Ora_String(strOdnYtDt, 8) & "' "
		strSQL = strSQL & " And HINCD   = '" & CF_Ora_String(strHinCd, 10) & "' "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_STOTRA_Update_err
		End If
		
		F_STOTRA_Update = 0
		
F_STOTRA_Update_End: 
		Exit Function
		
F_STOTRA_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_012, pm_All, "F_STOTRA_Update")
		GoTo F_STOTRA_Update_End
		
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
					' === 20060804 === INSERT S - ACE)Nagasawa
					'���׃J���[�t��
					Call CF_Set_BD_Color(pm_All)
					' === 20060804 === INSERT E -
					'�R���g���[������
					Call F_Set_Body_Enable(pm_All)
					
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
							' === 20060804 === INSERT S - ACE)Nagasawa
							'���׃J���[�t��
							Call CF_Set_BD_Color(pm_All)
							' === 20060804 === INSERT E -
							'�R���g���[������
							Call F_Set_Body_Enable(pm_All)
							
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
		
		'���̍��ڂ�����
		For Index_Wk = Sta_Index To pm_All.Dsp_Base.Item_Cnt
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'�w�b�_������{�f�B���ֈړ�����ꍇ
				Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				If Rtn_Chk <> CHK_OK Then
					'�`�F�b�N�m�f�̏ꍇ
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
					'�ړ��悪�����s�̏ꍇ
					'�X�V�O�`�F�b�N�˂c�a�X�V�ˏ�����
					Call FR_SSSSUB01.Ctl_MN_Execute_Click()
					'''''''            Call F_Ctl_Upd_Process(pm_All)
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
            '2019/06/12 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '2019/06/12 CHG END        
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '�l���������l�̏ꍇ
                    '�P�����ڂ�I������
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/09/20 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 0
                    ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(0, 1)
                    '2019/09/20 CHG END
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
                        '2019/09/20 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        '�ҏW���SelLength������
                        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '2019/09/20 CHG END
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
            '2019/06/12 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '2019/06/12 CHG END
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '�l���������l�̏ꍇ
                    '�ŏI������I������
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/06/12 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1, 1)
                    '2019/06/12 CHG END
                Else
                    '�l���������l�ȊO�̏ꍇ
                    '�P���ڂ�I������
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/06/12 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 1
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(1, 1)
                    '2019/06/12 CHG END
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
                            '2019/06/12 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)), 0)
                            '2019/06/12 CHG END
                        Else
							'�l���������l�ȊO�̏ꍇ
							If Act_SelLength = 0 Then
                                '�ړ��O�̑I�𕶎������Ȃ��ꍇ
                                '��ԉE�ֈړ����I���Ȃ���Ԃ�
                                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '2019/06/12 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)), 0)
                                '2019/06/12 CHG END
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
                            '2019/09/20 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
                            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Next_SelStart, Wk_SelLength)
                            '2019/09/20 CHG END
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
						' === 20060804 === INSERT S - ACE)Nagasawa
						'���׃J���[�t��
						Call CF_Set_BD_Color(pm_All)
						' === 20060804 === INSERT E -
						'�R���g���[������
						Call F_Set_Body_Enable(pm_All)
						
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
						' === 20060804 === INSERT S - ACE)Nagasawa
						'���׃J���[�t��
						Call CF_Set_BD_Color(pm_All)
						' === 20060804 === INSERT E -
						'�R���g���[������
						Call F_Set_Body_Enable(pm_All)
						
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
			'�r���������������������������������������������������������r
			'�ȉ��̺��۰ق͖��ו����̺��۰قł���΂Ȃ�ł��n�j�ł�
			'(�Ώۂ̖��ׂ̔ԍ���񂾂����K�v�A)
			Wk_Index = CShort(FR_SSSSUB01.BD_SOUNM(Index_Bd_Wk).Tag)
			'�d���������������������������������������������������������d
			'Dsp_Body_Inf�̍s�m�n�ɕϊ�
			Wk_Row = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
			'�r���������������������������������������������������������r
			'Dsp_Body_Inf�ɒl�������l��ݒ�
			Call F_Init_Dsp_Body(Wk_Row, pm_All)
			'�d���������������������������������������������������������d
			
		Next 
		
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
		'�Č��h�c�Ƀt�H�[�J�X�ݒ�
		'�������ޯ���擾
		Trg_Index = CShort(FR_SSSSUB01.BD_INP_HIKSU(1).Tag)
		
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
	'   ���́F  Function F_Dsp_BD_INP_HIKSU_Inf
	'   �T�v�F  ����������ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_INP_HIKSU_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		Dim Wk_Row As Short
		Dim Bd_Index As Short
		
		'��ʂ̍s
		Wk_Row = pm_Dsp_Sub_Inf.Detail.Body_Index
		'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'�r���������������������������������������������������������r
				'�O��`�F�b�N���e�ł͂Ȃ��A�O����e�Ɣ�r���A�ύX����Ă���΃t���O���Ă�
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Trim(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) <> Trim(pm_Dsp_Sub_Inf.Detail.Bef_Value) Then
					'��ʕҏW����Ƃ���
					gv_bolHIKET51_INIT = True
				End If
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
	'   ���́F  Function F_Chk_BD_INP_HIKSU
	'   �T�v�F  ������������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'         �@pm_Row_Cnt            :�s�ԍ�(���������p)
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_INP_HIKSU(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All, ByRef pm_Row_Cnt As Short) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		' === 20060109 === INSERT S - ACE)Nagasawa
		Dim Bd_Index As Short
		' === 20060109 === INSERT E -
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_INP_HIKSU = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		' === 20060109 === INSERT S - ACE)Nagasawa
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		' === 20060109 === INSERT E -
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_NOT_INPUT
			Err_Cd = gc_strMsgHIKET51_E_011 '�����̓G���[
			'�����͈ȊO�̃`�F�b�N��
			'(�����l�������Ă���ꍇ�A������OK�Ƃ����Ȃ��ׁA�t���O�𗧂Ă�)
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgHIKET51_E_010 '���͔͈͊O
			Else
				'�n�j
				Retn_Code = CHK_OK
				pm_Chk_Move = True
			End If
			
			'�ʃ`�F�b�N
			If Retn_Code = CHK_OK Then
				If CInt(Input_Value) < 0 Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgHIKET51_E_006 '�}�C�i�X�G���[
				End If
			End If
			
			'�ʃ`�F�b�N
			If Retn_Code = CHK_OK Then
				'�����\���I�[�o�[�`�F�b�N
				Retn_Code = F_Chk_BD_INP_HIKSU_Over(pm_Chk_Dsp_Sub_Inf, Err_Cd, pm_All, pm_Row_Cnt)
			End If
			
			'�ʃ`�F�b�N
			If Retn_Code = CHK_OK Then
				' === 20060818 === INSERT S - ACE)Nagasawa �������v�����󒍐��̃`�F�b�N�͍s��Ȃ�
				'            '�����ϐ����v�I�[�o�[�`�F�b�N
				'            Retn_Code = F_Chk_BD_INP_HIKSUKEI_Over(pm_Chk_Dsp_Sub_Inf, Err_Cd, pm_All)
				
				'���͈��������󒍐��̏ꍇ�G���[
				If HIKET51A_DSP_DATA_Inf.UODSU < CF_Get_CCurString(Input_Value) Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgHIKET51_E_015
				End If
				' === 20060818 === INSERT E -
				
			End If
			
			'2014/02/26 START ADD FWEST)Koroyasu ����Ŗ@�����Ή�
			'�ʃ`�F�b�N
			If Retn_Code = CHK_OK Then
				If HIKET51A_DSP_DATA_Inf.Mode = 2 And CInt(Input_Value) > 0 Then
					'�K�p�ŗ��A�o�ߑ[�u�̃`�F�b�N
					Retn_Code = F_Chk_ZEIRT(pm_Chk_Dsp_Sub_Inf, Err_Cd, pm_All)
				End If
			End If
			'2014/02/26 END ADD FWEST)Koroyasu ����Ŗ@�����Ή�
			
			'���׍��v�̑ޔ�
			If Retn_Code = CHK_OK Then
				' === 20060109 === UPDATE S - ACE)Nagasawa
				'            '�O��̓��e���}�C�i�X
				'            HIKET51A_DSP_DATA_Inf.HIKSUKEI = HIKET51A_DSP_DATA_Inf.HIKSUKEI - CCur(pm_Chk_Dsp_Sub_Inf.Detail.Bef_Value)
				'            '����̓��e���v���X
				'            HIKET51A_DSP_DATA_Inf.HIKSUKEI = HIKET51A_DSP_DATA_Inf.HIKSUKEI + CCur(pm_Chk_Dsp_Sub_Inf.Detail.Dsp_Value)
				'�O��̓��e���}�C�i�X
				HIKET51A_DSP_DATA_Inf.HIKSUKEI = HIKET51A_DSP_DATA_Inf.HIKSUKEI - CF_Get_CcurVariant(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.SUB_HIKSU_BEF)
				'����̓��e���v���X
				HIKET51A_DSP_DATA_Inf.HIKSUKEI = HIKET51A_DSP_DATA_Inf.HIKSUKEI + CF_Get_CcurVariant(pm_Chk_Dsp_Sub_Inf.Detail.Dsp_Value)
				
				'�O����͈����ϐ����i�[
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.SUB_HIKSU_BEF = CF_Get_CcurVariant(Input_Value)
				' === 20060109 === UPDATE E -
			End If
		End If
		'�d���������������������������������������������������������d
		
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_INP_HIKSU = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_BD_INP_HIKSU_Over
	'   �T�v�F  �������������\�����z���Ă��邩�`�F�b�N���s��
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_ErrCd   �@�@�@�@�@ :�G���[�R�[�h
	'           pm_All                :��ʏ��
	'         �@pm_Row_Cnt            :�s�ԍ�(���������p)
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_INP_HIKSU_Over(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_ErrCd As String, ByRef pm_All As Cls_All, ByRef pm_Row_Cnt As Short) As Short
		
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim curHIKSU As Decimal
		Dim curHikKnSu As Decimal
		Dim curMotoHikSu As Decimal
		
		Rtn_Cd = CHK_OK
		pm_ErrCd = ""
		
		'�S�̃`�F�b�N�ȊO�̏ꍇ�͍s�ԍ���ҏW
		If pm_Row_Cnt = 0 Then
			'pm_All.Dsp_Body_Inf�̍s�m�n���擾
			Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		Else
			'�����p�s�ԍ����g�p����
			Bd_Index = pm_Row_Cnt
		End If
		
		'�B���s�̏ꍇ�̓`�F�b�N���Ȃ�
		If Bd_Index <> 0 Then
			'�������̑ޔ�
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curHIKSU = pm_Chk_Dsp_Sub_Inf.Detail.Dsp_Value
			'�����\���̑ޔ�
			curHikKnSu = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.SUB_HIKSU
			'���������̑ޔ�
			curMotoHikSu = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.SUB_MOTO_HIKSU
			
			'�����\���`�F�b�N
			If curHIKSU > curHikKnSu + curMotoHikSu Then
				Rtn_Cd = CHK_ERR_ELSE
				pm_ErrCd = gc_strMsgHIKET51_E_007
			End If
		End If
		
		F_Chk_BD_INP_HIKSU_Over = Rtn_Cd
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_BD_INP_HIKSUKEI_Over
	'   �T�v�F  �������̍��v�������ϐ����z���Ă��邩�`�F�b�N���s��
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_ErrCd   �@�@�@�@�@ :�G���[�R�[�h
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_INP_HIKSUKEI_Over(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_ErrCd As String, ByRef pm_All As Cls_All) As Short
		
		Dim Rtn_Cd As Short
		Dim curHikSuKei As Decimal
		Dim curZumiSu As Decimal
		
		Rtn_Cd = CHK_OK
		pm_ErrCd = ""
		curHikSuKei = 0
		curZumiSu = 0
		
		'�����ϐ��̑ޔ�
		curZumiSu = HIKET51A_DSP_DATA_Inf.UODSU
		
		'���׍��v
		curHikSuKei = HIKET51A_DSP_DATA_Inf.HIKSUKEI
		'�O��̓��e���}�C�i�X
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		curHikSuKei = curHikSuKei - CDec(pm_Chk_Dsp_Sub_Inf.Detail.Bef_Value)
		'����̓��e���v���X
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		curHikSuKei = curHikSuKei + CDec(pm_Chk_Dsp_Sub_Inf.Detail.Dsp_Value)
		
		'���ׂ̈������̍��v�������ύ��v�̏ꍇ�̓G���[
		If curHikSuKei > curZumiSu Then
			Rtn_Cd = CHK_ERR_ELSE
			pm_ErrCd = gc_strMsgHIKET51_E_008
		End If
		
		F_Chk_BD_INP_HIKSUKEI_Over = Rtn_Cd
		
	End Function
	
	'2014/02/26 START ADD FWEST)Koroyasu ����Ŗ@�����Ή�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_ZEIRT
	'   �T�v�F  �K�p�ŗ��A�o�ߑ[�u�̃`�F�b�N
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_ErrCd   �@�@�@�@�@ :�G���[�R�[�h
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_ZEIRT(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_ErrCd As String, ByRef pm_All As Cls_All) As Short
		
		Dim Rtn_Cd As Short
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim intZEIRT As Short
		Dim strZEIRNKKB As String
		'UPGRADE_WARNING: �\���� Usr_Ody2 �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody2 As U_Ody
		Dim Mst_Inf_SYSTBB As TYPE_DB_SYSTBB
		
		On Error GoTo ERR_F_Chk_ZEIRT
		
		Rtn_Cd = CHK_OK
		pm_ErrCd = ""
		
		strSQL = ""
		strSQL = strSQL & " Select TRA.ZEIRT,TRA.ZEIRNKKB "
		strSQL = strSQL & "   from JDNTRA TRA "
		strSQL = strSQL & "       ,JDNTHC THC "
		strSQL = strSQL & "  Where TRA.DATNO = THC.DATNO "
		strSQL = strSQL & "  And   TRA.JDNNO = THC.JDNNO "
		strSQL = strSQL & "  And   TRA.JDNNO = '" & Trim(HIKET51A_DSP_DATA_Inf.JDNNO) & "' "
		strSQL = strSQL & "  And   TRA.LINNO = '" & Trim(HIKET51A_DSP_DATA_Inf.LINNO) & "' "
		strSQL = strSQL & "  And   TRA.DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "  And   TRA.AKAKROKB = '" & CF_Ora_String(gc_strAKAKROKB_KURO, 1) & "' "
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			'�擾�f�[�^�Ȃ�
			Rtn_Cd = CHK_ERR_ELSE
			F_Chk_ZEIRT = Rtn_Cd
			pm_ErrCd = gc_strMsgHIKET51_E_012
			Exit Function
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		intZEIRT = CF_Ora_GetDyn(Usr_Ody, "ZEIRT", "")
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strZEIRNKKB = CF_Ora_GetDyn(Usr_Ody, "ZEIRNKKB", "")
		
		If DSPZEIRT_SEARCH(GV_UNYDate, strZEIRNKKB, Mst_Inf_SYSTBB) = 0 And intZEIRT <> 0 Then
			'�K�p�ŗ��Ǝ󒍂̐ŗ����قȂ�ꍇ�A�o�ߑ[�u�ɓo�^����Ă��邩�`�F�b�N
			If Mst_Inf_SYSTBB.ZEIRT <> intZEIRT Then
				
				strSQL = ""
				strSQL = strSQL & " Select * "
				strSQL = strSQL & "   from JDN_KEIKA KEI"
				strSQL = strSQL & "  Where KEI.C_JYUCYU_NO = '" & Trim(HIKET51A_DSP_DATA_Inf.JDNNO) & "' "
				strSQL = strSQL & "  And   KEI.C_SET_ZEI_RATE = '" & intZEIRT & "' "
				strSQL = strSQL & "  And   KEI.C_SYORI_CLS = '0' "
				strSQL = strSQL & "  And   KEI.C_SYORI_ZUMI_FLG = '1' "
				strSQL = strSQL & "  And   KEI.C_CREATE_CNT = ( Select MAX(KEI2.C_CREATE_CNT)"
				strSQL = strSQL & "                               from JDN_KEIKA KEI2"
				strSQL = strSQL & "                              Where KEI2.C_JYUCYU_NO = '" & Trim(HIKET51A_DSP_DATA_Inf.JDNNO) & "' "
				strSQL = strSQL & "                           )"
				
				'DB�A�N�Z�X
				Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody2, strSQL)
				
				If CF_Ora_EOF(Usr_Ody2) = True Then
					'�擾�f�[�^�Ȃ�
					Rtn_Cd = CHK_ERR_ELSE
					pm_ErrCd = gc_strMsgHIKET51_E_021
				End If
				
			End If
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		F_Chk_ZEIRT = Rtn_Cd
		
		Exit Function
		
ERR_F_Chk_ZEIRT: 
		
		Rtn_Cd = CHK_ERR_ELSE
		F_Chk_ZEIRT = Rtn_Cd
		pm_ErrCd = gc_strMsgHIKET51_E_012
		
	End Function
	'2014/02/26 END ADD FWEST)Koroyasu ����Ŗ@�����Ή�
	
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
			Case FR_SSSSUB01.BD_INP_HIKSU(1).Name
				'�������ɂ���ʕ\��
				Call F_Dsp_BD_INP_HIKSU_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
				'�d���������������������������������������������������������d
				
		End Select
		
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Item_Chk
	'   �T�v�F  �e���ڂ�����ٰ�ݐ���
	'   �����F�@pm_Dsp_Sub_Inf   :��ʏ��
	'         �@pm_Process       :�����֐��ďo��
	'         �@pm_Chk_Move_Flg  :�ړ��t���O
	'         �@pm_All           :��ʏ��
	'         �@pm_Row_Cnt       :�s�ԍ�(���������p)
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Item_Chk(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Process As String, ByRef pm_Chk_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Row_Cnt As Short = 0) As Short
		
		Dim Rtn_Chk As Short
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_OK
		pm_Chk_Move_Flg = True
		
		'�@��{���͓��e�̃`�F�b�N
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			'�r���������������������������������������������������������r
			Case FR_SSSSUB01.BD_INP_HIKSU(1).Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'������������
				Rtn_Chk = F_Chk_BD_INP_HIKSU(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All, pm_Row_Cnt)
				
				'�d���������������������������������������������������������d
				
		End Select
		
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
				
				'�����̓��b�Z�[�W
				If Rtn_Chk = CHK_ERR_NOT_INPUT Then
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_011, pm_All)
				End If
				
				'������ړ��Ȃ�
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				
				F_Ctl_Head_Chk = Rtn_Chk
				Exit Function
			End If
		Next 
		
		'�֘A����
		Rtn_Chk = F_Ctl_Head_RelChk(pm_All, intMoveFocus)
		'�`�F�b�N�m�f
		If Rtn_Chk <> CHK_OK Then
			
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(intMoveFocus), pm_All)
			
			F_Ctl_Head_Chk = Rtn_Chk
			Exit Function
		End If
		
		If Rtn_Chk = CHK_OK And pm_All.Dsp_Base.Head_Ok_Flg = False Then
			'�`�F�b�N�n�j�ł���
			'�w�b�_���̃`�F�b�N�����߂Ă̏ꍇ
			''        '�P�s�ڂ̃{�f�B���������ŏI�s�Ƃ��ĊJ������
			''        pm_All.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW
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
		Dim Chk_Move_Flg As Boolean
		Dim Trg_Index As Short
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_ERR_ELSE
		
		Rtn_Chk = CHK_OK
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Body_Chk
	'   �T�v�F  ���ި��������ٰ�ݐ���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Body_Chk(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk_Col As Short
		Dim Index_Wk_Row As Short
		Dim Trg_Index As Short
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Sub_Inf_Wk As Cls_Dsp_Sub_Inf
		Dim Dsp_Mode As Short
		
		Dim Err_Row As Short
		Dim Err_Dsp_Sub_Inf_Wk As Cls_Dsp_Sub_Inf
		Dim Bd_Idx As Short
		Dim Err_Index As Short
		Dim Move_Flg As Boolean
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_OK
		
		'�{�f�B���̍ŏI���ڂ܂Ŋe���ڂ��������s��
		For Index_Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			
			Select Case pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Status
				Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT
					'���͑ҏ�ԁA���͍Ϗ�ԏ�Ԃ�Ώ�
					
					' === 20070320 === INSERT S - ACE)Nagasawa
					'�B�s�ɉ�ʖ��ׂ̑Ώۍs���R�s�[
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(0))
					' === 20070320 === INSERT E -
					
					For Index_Wk_Col = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail)
						
						'��ʖ��ׂ̉B�s�̍��ڂ̲��ޯ�����擾
						Trg_Index = CF_Get_Idex_Same_Bd_Ctl_Hide_Row(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Item_Nm, pm_All)
						
						'���[�N�̢��ʍ��ڏ��ɉB�s���۰ق�����
						Dsp_Sub_Inf_Wk.Ctl = pm_All.Dsp_Sub_Inf(Trg_Index).Ctl
						
						'���[�N�̢��ʍ��ڏ��ɢ��ʃ{�f�B����ҏW
						Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Dsp_Value, Dsp_Sub_Inf_Wk, pm_All)
						'��ʍ��ڏڍ׏���ݒ�
						'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Sub_Inf_Wk.Detail �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Dsp_Sub_Inf_Wk.Detail = pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col)
						
						'�e����������S�������Ƃ��Čďo
						Rtn_Chk = F_Ctl_Item_Chk(Dsp_Sub_Inf_Wk, CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All, Index_Wk_Row)
						
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
						Call F_Dsp_Item_Detail(Dsp_Sub_Inf_Wk, Dsp_Mode, pm_All)
						
						'���ʃ{�f�B���Ƀ��[�N�̢��ʍ��ڏ���ҏW
						'��ʍ��ڏڍ׏���ݒ�
						'�����ɂ���ĕύX����鍀�ڂ̂�
						Call CF_Dsp_Sub_Inf_To_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col), Dsp_Sub_Inf_Wk.Detail)
						' === 20070320 === INSERT S - ACE)Nagasawa
						'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Sub_Inf_Wk.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Index_Wk_Col).Bef_Chk_Value = Dsp_Sub_Inf_Wk.Detail.Bef_Chk_Value
						'��ʖ��ׂ̑Ώۍs�ɉB�s���R�s�[
						Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row))
						' === 20070320 === INSERT E -
						
						'�`�F�b�N�m�f
						If Rtn_Chk <> CHK_OK Then
							
							'�G���[�̏ꍇ�A�Ώۍs��\����̫����ړ�����
							'�G���[�p�ϐ��i�[
							'�s���
							Err_Row = Index_Wk_Row
							'�Ώۺ��۰ُ��
							Err_Dsp_Sub_Inf_Wk.Ctl = Dsp_Sub_Inf_Wk.Ctl
							'��ʍ��ڏڍ׏���ݒ�
							'UPGRADE_WARNING: �I�u�W�F�N�g Err_Dsp_Sub_Inf_Wk.Detail �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Err_Dsp_Sub_Inf_Wk.Detail = Dsp_Sub_Inf_Wk.Detail
							
							GoTo ERR_EXIT
						End If
						
					Next 
			End Select
			
		Next 
		
		
		'    '�֘A����
		'    Rtn_Chk = F_Ctl_Body_RelChk(pm_All)
		'    '�`�F�b�N�m�f
		'    If Rtn_Chk <> CHK_OK Then
		'
		'        '������ړ��Ȃ�
		'            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
		'
		'        F_Ctl_Body_Chk = Rtn_Chk
		'        Exit Function
		'    End If
		
		' === 20060818 === INSERT S - ACE)Nagasawa
		'�֘A����
		If HIKET51A_DSP_DATA_Inf.HIKSUKEI > HIKET51A_DSP_DATA_Inf.UODSU Then
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_008, pm_All)
			Rtn_Chk = CHK_ERR_ELSE
		End If
		' === 20060818 === INSERT E -
		
		F_Ctl_Body_Chk = Rtn_Chk
		
		Exit Function
		
ERR_EXIT: 
		'�G���[���A̫����ړ�
		'�Ώۍs����ʂɕ\��
		Call CF_Body_Dsp_Trg_Row(pm_All, Err_Row)
		'�Ώۍs�����ʖ��ׂ̍s���擾
		Bd_Idx = CF_Idx_To_Bd_Idx(Err_Row, pm_All)
		'��ʖ��ׂ̍s�Ɠ���̖��ׂ��C���f�b�N�X���擾
		Err_Index = CF_Get_Idex_Same_Bd_Ctl(Err_Dsp_Sub_Inf_Wk, Bd_Idx, pm_All)
		' === 20060804 === INSERT S - ACE)Nagasawa
		'���ڂ̐F�ݒ�
		Call CF_Set_BD_Color(pm_All)
		' === 20060804 === INSERT E -
		
		If Err_Index > 0 Then
			'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
			Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Err_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			'======================= �ύX���� 2006.06.26 Start =================================
			'        '�I����Ԃ̐ݒ�i�����I���j
			'        Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Err_Index - 1), SEL_INI_MODE_2)
			'        '���ڐF�ݒ�
			'        Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Err_Index - 1), ITEM_NORMAL_STATUS, pm_All)
			'======================= �ύX���� 2006.06.26 End =================================
			
		Else
			'���͉\�ȍŏ��̃C���f�b�N�X���擾
			Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Err_Row, pm_All)
			If Focus_Ctl_Ok_Fst_Idx > 0 Then
				'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
				Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			End If
		End If
		
		F_Ctl_Body_Chk = Rtn_Chk
		Exit Function
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Foot_In_Ready
	'   �T�v�F  �t�b�^���̓��͏���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Foot_In_Ready(ByRef pm_All As Cls_All) As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Body_Enable
	'   �T�v�F  �ŏ㖾�ײ��ޯ��(pm_All.Dsp_Body_Inf.Cur_Top_Index)�����
	'   �@�@�@�@���׍s�̺��۰ِ�����s��
	'   �����F�@pm_All�@: ��ʏ��
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Body_Enable(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Bd_Index As Short
		Dim Bd_Index_Bk As Short
		Dim Bd_Col_Index As Short
		Dim Bd_Row_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Wk_Row As Short
		Dim Wk_Index As Short
		Dim InpRow As Short
		
		Bd_Row_Index = 0
		
		If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
			'���ו\���̉��
			
			'�{�f�B�����ŏ���
			Bd_Index = 0
			Bd_Index_Bk = 0
			
			For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				
				If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > 0 Then
					
					Wk_Row = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index
					'pm_All.Dsp_Body_Inf�̍s�m�n���擾
					Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					
					If Bd_Index_Bk <> Bd_Index Then
						'���׍s�u���C�N
						Bd_Col_Index = 1
						Bd_Index_Bk = Bd_Index
						Bd_Row_Index = Bd_Row_Index + 1
					Else
						Bd_Col_Index = Bd_Col_Index + 1
					End If
					
					'** ���۰ِ��� **
					Select Case Index_Wk
						'������
						Case CShort(FR_SSSSUB01.BD_INP_HIKSU(1).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(2).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(3).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(4).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(5).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(6).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(7).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(8).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(9).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(10).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(11).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(12).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(13).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(14).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(15).Tag)
							
							'�y�������z
							Wk_Index = CShort(FR_SSSSUB01.BD_INP_HIKSU(1).Tag)
							Call CF_Set_Dsp_Body_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
							
					End Select
					
				End If
			Next 
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Body_Bef_Chk_Value
	'   �T�v�F  ���ו\�����Ƀ`�F�b�N�ςݍ��ڂƂ���
	'   �����F�@pm_All�@: ��ʏ��
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Body_Bef_Chk_Value(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Bd_Index As Short
		Dim Bd_Index_Bk As Short
		Dim Bd_Col_Index As Short
		Dim Bd_Row_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Wk_Row As Short
		Dim Wk_Index As Short
		
		Bd_Row_Index = 0
		
		If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
			'���ו\���̉��
			
			'�{�f�B�����ŏ���
			Bd_Index = 0
			Bd_Index_Bk = 0
			
			For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				
				If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > 0 Then
					
					Wk_Row = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index
					'pm_All.Dsp_Body_Inf�̍s�m�n���擾
					Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					
					If Bd_Index_Bk <> Bd_Index Then
						'���׍s�u���C�N
						Bd_Col_Index = 1
						Bd_Index_Bk = Bd_Index
						Bd_Row_Index = Bd_Row_Index + 1
					Else
						Bd_Col_Index = Bd_Col_Index + 1
					End If
					
					'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
					Select Case True
						Case TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is System.Windows.Forms.TextBox
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk))) <> "" Then
								'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk))
								pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Not_Input_Chk_Fin_Flg = True
							End If
						Case TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is System.Windows.Forms.CheckBox
							If CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk)) <> System.Windows.Forms.CheckState.Unchecked Then
								'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk))
								pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Not_Input_Chk_Fin_Flg = True
							End If
					End Select
					
				End If
			Next 
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_DSP_BD_Inf_SUB
	'   �T�v�F  �{�f�B���ҏW_�T�u�Ɖ��ʗp
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�����X�e�[�^�X
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_DSP_BD_Inf_SUB(ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim intCnt As Short
		Dim intRet As Short
		
		Dim Trg_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'�w�b�_�f�[�^�擾
			intCnt = F_GET_HD_DATA(HIKET51A_DSP_DATA_Inf, pm_All)
			
			'�f�[�^�擾
			intCnt = F_GET_BD_DATA(HIKET51A_DSP_DATA_Inf, pm_All)
			
			If intCnt > 0 Then
				'�f�[�^�ҏW
				intRet = F_SET_BD_DATA(HIKET51A_DSP_DATA_Inf, pm_All, intCnt)
			End If
			
		End If
		
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_HD_DATA
	'   �T�v�F  �w�b�_���f�[�^�擾
	'   �����F�@pm_All                :�S�\����
	'   �ߒl�F�@�擾�s��
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_HD_DATA(ByRef pm_HIKET51A_DSP_DATA As HIKET51A_DSP_DATA, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim intMode As Short
		Dim intCnt As Short
		Dim intIdx As Short
		Dim Wk_Index As Short
		Dim strCode1 As String
		Dim strCode2 As String
		Dim strCode3 As String
		Dim HIKET51A_DSP_DATA_Clr As HIKET51A_DSP_DATA
		
		On Error GoTo ERR_F_GET_HD_DATA
		
		F_GET_HD_DATA = -1
		
		'������
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_HIKET51A_DSP_DATA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_HIKET51A_DSP_DATA = HIKET51A_DSP_DATA_Clr
		
		strCode1 = Trim(HIKET51_Interface.DENNO1)
		strCode2 = Trim(HIKET51_Interface.DENNO2)
		strCode3 = Trim(HIKET51_Interface.LINNO)
		
		'�����r�p�k����
		If strCode2 <> "" Then
			'��Q�������󔒂łȂ��ꍇ�i���Ő����n���ꂽ�ꍇ�j�A���Ϗ��Ƃ݂Ȃ�
			strSQL = F_GET_MIT_HD_SQL(strCode1, strCode2, strCode3)
			intMode = 1
		Else
			'��Q�������󔒂̏ꍇ�i���Ő����n����ĂȂ��ꍇ�j�A�󒍏��Ƃ݂Ȃ�
			strSQL = F_GET_JDN_HD_SQL(strCode1, strCode3)
			intMode = 2
		End If

        'DB�A�N�Z�X
        '2019/10/01 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        'If CF_Ora_EOF(Usr_Ody) = True Then
        Dim dt As DataTable = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/10/01 CHG END
            '�擾�f�[�^�Ȃ��i�܂�A���ׂđΏۊO�j
            F_GET_HD_DATA = 0
            '���b�Z�[�W�\��
            Call AE_CmnMsgLibrary(SSS_PrgId, gc_strMsgHIKET51_E_009, pm_All)

            Exit Function
        End If
        '2019/10/01 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            '2019/10/01 CHG END
            '���[�h
            pm_HIKET51A_DSP_DATA.Mode = intMode
            ' === 20070127 === INSERT S - ACE)Yano
            '����(�w�b�_)
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/01 CHG START
            'pm_HIKET51A_DSP_DATA.UODSU = CF_Ora_GetDyn(Usr_Ody, "UODSU", 0)
            pm_HIKET51A_DSP_DATA.UODSU = DB_NullReplace(dt.Rows(0)("UODSU"), 0)
            '2019/10/01 CHG END
            ' === 20070127 === INSERT E -
            '�����ϐ�(�w�b�_)
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/01 CHG START
            'pm_HIKET51A_DSP_DATA.ZUMISU = CF_Ora_GetDyn(Usr_Ody, "ZUMISU", 0)
            pm_HIKET51A_DSP_DATA.ZUMISU = DB_NullReplace(dt.Rows(0)("ZUMISU"), 0)
            '2019/10/01 CHG END
        End If

        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)
		
		' === 20080715 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
		'����/�蓮�o�׎w�����擾
		If F_GET_FRDSU_ATMN(pm_All) <> 9 Then
			Exit Function
		End If
		' === 20080715 === INSERT E -
		
		F_GET_HD_DATA = intCnt
		
		Exit Function
		
ERR_F_GET_HD_DATA: 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_BD_DATA
	'   �T�v�F  �{�f�B���f�[�^�擾
	'   �����F�@pm_All                :�S�\����
	'   �ߒl�F�@�擾�s��
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_BD_DATA(ByRef pm_HIKET51A_DSP_DATA As HIKET51A_DSP_DATA, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim intMode As Short
		Dim intCnt As Short
		Dim intIdx As Short
		Dim Wk_Index As Short
		Dim HIKET51A_DSP_DATA_Clr As HIKET51A_DSP_DATA
		
		On Error GoTo ERR_F_GET_BD_DATA
		
		F_GET_BD_DATA = -1
		
		'������
		gv_bolHIKET51A_CNT = 0
		''''''    pm_HIKET51A_DSP_DATA = HIKET51A_DSP_DATA_Clr
		
		'���ח\��t�@�C���擾
		strSQL = F_GET_INP_SQL()

        'DB�A�N�Z�X
        '2019/10/01 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/10/01 CHG END
            '�擾�f�[�^�Ȃ��i�܂�A���ׂđΏۊO�j
            F_GET_BD_DATA = 0
			'���b�Z�[�W�\��
			'''Call AE_CmnMsgLibrary(SSS_PrgId, gc_strMsgHIKET51_E_009, pm_All)
			
			Exit Function
		End If
		
		Dim intLoop As Short
		Dim intIndex As Short
		Dim strKEY_HINCD As String
		Dim strKEY_INPYTDT As String
		Dim strKEY_LOTNO As String
		Dim strKEY_SOUCD As String
		Dim strKEY_TRANO As String
		Dim strKEY_MITNOV As String
		Dim strKEY_LINNO As String
        '2019/10/01 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            '2019/10/01 CHG END
            With pm_HIKET51A_DSP_DATA
                    '�P���R�[�h�ڂ�茩�o�����ޔ�
                    '�󒍃f�[�^�A���σf�[�^���ʕ���
                    .LINNO = HIKET51_Interface.LINNO '�s�ԍ�
                    .TANNM = HIKET51_Interface.TANNM '�c�ƒS����
                    .HINCD = HIKET51_Interface.HINCD '���i�R�[�h
                    .HINNMA = HIKET51_Interface.HINNMA '�^��
                    .HINNMB = HIKET51_Interface.HINNMB '�i��
                    ' === 20070127 === UPDATE S - ACE)Yano
                    '           .UODSU = HIKET51_Interface.UODSU                            '����
                    ' === 20070127 === UPDATE E -
                    '���σf�[�^�̏ꍇ
                    If .Mode = 1 Then
                        .DENSBT = "���@��" '�`�[���
                        .JDNNO = HIKET51_Interface.DENNO1 & "-" & HIKET51_Interface.DENNO2 '�`�[�ԍ�
                        '�󒍃f�[�^�̏ꍇ
                    Else
                        .DENSBT = "��@��" '�`�[���
                        .JDNNO = HIKET51_Interface.DENNO1 '�`�[�ԍ�
                    End If
                End With

                intCnt = 0
            '�擾�S���R�[�h���{�f�B���ޔ�
            '2019/10/01 CHG START
            'Do Until CF_Ora_EOF(Usr_Ody) = True
            For Each row As DataRow In dt.Rows
                '2019/10/01 CHG END            
                intCnt = intCnt + 1
                '�f�[�^�����ޔ�
                gv_bolHIKET51A_CNT = intCnt

                '�s�ǉ�
                ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
                '�s���ڏ��R�s�[
                Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intCnt))

                With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
                    '2019/10/01 CHG START
                    ''(6.)
                    '.Bus_Inf.SUB_IsDataRow = True
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_KB = CF_Ora_GetDyn(Usr_Ody, "KB", "") '�敪
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "") '�q�ɃR�[�h
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "") '���i�R�[�h
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_SISNKB = CF_Ora_GetDyn(Usr_Ody, "SISNKB", "") '���Y���敪
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_SOUTRICD = CF_Ora_GetDyn(Usr_Ody, "SOUTRICD", "") '�����R�[�h
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_SOUKOKB = CF_Ora_GetDyn(Usr_Ody, "SOUKOKB", "") '�q�ɋ敪
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM", "") '�q�ɖ�
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_LOTNO = CF_Ora_GetDyn(Usr_Ody, "LOTNO", "") '���b�g�ԍ�
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_NYUYTDT = CF_Ora_GetDyn(Usr_Ody, "INPYTDT", "") '���ɗ\���
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_RELZAISU = CF_Ora_GetDyn(Usr_Ody, "RELZAISU", 0) '���݌ɐ�
                    '' === 20080715 === UPDATE S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
                    ''                .Bus_Inf.SUB_ZUMISU = CF_Ora_GetDyn(Usr_Ody, "ZUMISU", 0)               '�����ϐ�
                    ''                .Bus_Inf.SUB_HIKSU = CF_Ora_GetDyn(Usr_Ody, "HIKSU", 0)                 '�����\��
                    ''                .Bus_Inf.SUB_INP_HIKSU = CF_Ora_GetDyn(Usr_Ody, "INP_HIKSU", 0)         '������
                    ''                .Bus_Inf.SUB_MOTO_HIKSU = CF_Ora_GetDyn(Usr_Ody, "INP_HIKSU", 0)        '������
                    ''' === 20070109 === INSERT S - ACE)Nagasawa
                    ''                .Bus_Inf.SUB_HIKSU_BEF = CF_Ora_GetDyn(Usr_Ody, "INP_HIKSU", 0)         '�O����͈����ϐ�
                    ''' === 20070109 === INSERT E -
                    ''' === 20070205 === INSERT S - ACE)Yano
                    ''                .Bus_Inf.SUB_MNSU = CF_Ora_GetDyn(Usr_Ody, "MNSU", 0)                   '�蓮������
                    ''' === 20070205 === INSERT E -

                    ''�o�׎w����
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_FRDSU = CF_Ora_GetDyn(Usr_Ody, "FRDSU", 0)
                    ''�����ϐ�
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_ZUMISU = CF_Ora_GetDyn(Usr_Ody, "ZUMISU", 0) - .Bus_Inf.SUB_FRDSU
                    ''�����\��
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_HIKSU = CF_Ora_GetDyn(Usr_Ody, "HIKSU", 0)
                    ''������
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_INP_HIKSU = CF_Ora_GetDyn(Usr_Ody, "INP_HIKSU", 0) - .Bus_Inf.SUB_FRDSU
                    ''��������
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_MOTO_HIKSU = CF_Ora_GetDyn(Usr_Ody, "INP_HIKSU", 0) - .Bus_Inf.SUB_FRDSU
                    ''�O����͈����ϐ�
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_HIKSU_BEF = CF_Ora_GetDyn(Usr_Ody, "INP_HIKSU", 0) - .Bus_Inf.SUB_FRDSU
                    ''�蓮������
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, MNSU, 0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'If CF_Ora_GetDyn(Usr_Ody, "MNSU", 0) - .Bus_Inf.SUB_FRDSU >= 0 Then
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    .Bus_Inf.SUB_MNSU = CF_Ora_GetDyn(Usr_Ody, "MNSU", 0) - .Bus_Inf.SUB_FRDSU
                    'Else
                    '    .Bus_Inf.SUB_MNSU = 0
                    'End If
                    '' === 20080715 === UPDATE E -
                    ''20080725 ADD START RISE)Tanimura '�r������
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") ' �ŏI��Ǝ҃R�[�h
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") ' �N���C�A���g�h�c
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") ' �^�C���X�^���v�i�o�b�`���ԁj
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") ' �^�C���X�^���v�i�o�b�`���j
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_UOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") ' �ŏI��Ǝ҃R�[�h
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_UCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") ' �N���C�A���g�h�c
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") ' �^�C���X�^���v�i�o�b�`���ԁj
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SUB_UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") ' �^�C���X�^���v�i�o�b�`���j
                    ''20080725 ADD END   RISE)Tanimura

                    .Bus_Inf.SUB_IsDataRow = True

                    .Bus_Inf.SUB_KB = DB_NullReplace(row("KB"), "") '�敪

                    .Bus_Inf.SUB_SOUCD = DB_NullReplace(row("SOUCD"), "") '�q�ɃR�[�h

                    .Bus_Inf.SUB_HINCD = DB_NullReplace(row("HINCD"), "") '���i�R�[�h

                    .Bus_Inf.SUB_SISNKB = DB_NullReplace(row("SISNKB"), "") '���Y���敪

                    .Bus_Inf.SUB_SOUTRICD = DB_NullReplace(row("SOUTRICD"), "") '�����R�[�h

                    .Bus_Inf.SUB_SOUKOKB = DB_NullReplace(row("SOUKOKB"), "") '�q�ɋ敪

                    .Bus_Inf.SUB_SOUNM = DB_NullReplace(row("SOUNM"), "") '�q�ɖ�

                    .Bus_Inf.SUB_LOTNO = DB_NullReplace(row("LOTNO"), "") '���b�g�ԍ�

                    .Bus_Inf.SUB_NYUYTDT = DB_NullReplace(row("INPYTDT"), "") '���ɗ\���

                    .Bus_Inf.SUB_RELZAISU = DB_NullReplace(row("RELZAISU"), 0) '���݌ɐ�
                    '�o�׎w����
                    .Bus_Inf.SUB_FRDSU = DB_NullReplace(row("FRDSU"), 0)
                    '�����ϐ�
                    .Bus_Inf.SUB_ZUMISU = DB_NullReplace(row("ZUMISU"), 0) - .Bus_Inf.SUB_FRDSU
                    '�����\��
                    .Bus_Inf.SUB_HIKSU = DB_NullReplace(row("HIKSU"), 0)
                    '������
                    .Bus_Inf.SUB_INP_HIKSU = DB_NullReplace(row("INP_HIKSU"), 0) - .Bus_Inf.SUB_FRDSU
                    '��������
                    .Bus_Inf.SUB_MOTO_HIKSU = DB_NullReplace(row("INP_HIKSU"), 0) - .Bus_Inf.SUB_FRDSU
                    '�O����͈����ϐ�
                    .Bus_Inf.SUB_HIKSU_BEF = DB_NullReplace(row("INP_HIKSU"), 0) - .Bus_Inf.SUB_FRDSU
                    '�蓮������

                    If DB_NullReplace(row("MNSU"), 0) - .Bus_Inf.SUB_FRDSU >= 0 Then
                        .Bus_Inf.SUB_MNSU = DB_NullReplace(row("MNSU"), 0) - .Bus_Inf.SUB_FRDSU
                    Else
                        .Bus_Inf.SUB_MNSU = 0
                    End If

                    .Bus_Inf.SUB_OPEID = DB_NullReplace(row("OPEID"), "") ' �ŏI��Ǝ҃R�[�h

                    .Bus_Inf.SUB_CLTID = DB_NullReplace(row("CLTID"), "") ' �N���C�A���g�h�c

                    .Bus_Inf.SUB_WRTTM = DB_NullReplace(row("WRTTM"), "") ' �^�C���X�^���v�i�o�b�`���ԁj

                    .Bus_Inf.SUB_WRTDT = DB_NullReplace(row("WRTDT"), "") ' �^�C���X�^���v�i�o�b�`���j

                    .Bus_Inf.SUB_UOPEID = DB_NullReplace(row("UOPEID"), "") ' �ŏI��Ǝ҃R�[�h

                    .Bus_Inf.SUB_UCLTID = DB_NullReplace(row("UCLTID"), "") ' �N���C�A���g�h�c

                    .Bus_Inf.SUB_UWRTTM = DB_NullReplace(row("UWRTTM"), "") ' �^�C���X�^���v�i�o�b�`���ԁj

                    .Bus_Inf.SUB_UWRTDT = DB_NullReplace(row("UWRTDT"), "") ' �^�C���X�^���v�i�o�b�`���j

                    '2019/10/01 CHG END

                    '�w�b�_���ɖ��ׂ̍��v��ޔ�
                    HIKET51A_DSP_DATA_Inf.HIKSUKEI = HIKET51A_DSP_DATA_Inf.HIKSUKEI + CDec(.Bus_Inf.SUB_INP_HIKSU)
                    ' === 20070205 === INSERT S - ACE)Yano
                    HIKET51A_DSP_DATA_Inf.MNSU = HIKET51A_DSP_DATA_Inf.MNSU + CDec(.Bus_Inf.SUB_MNSU)
                    ' === 20070205 === INSERT E -
                    '(7.)
                    '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                    Wk_Index = CShort(FR_SSSSUB01.BD_SOUNM(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB_SOUNM, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DEF)
                    Wk_Index = CShort(FR_SSSSUB01.BD_LOTNO(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB_LOTNO, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DEF)
                    Wk_Index = CShort(FR_SSSSUB01.BD_NYUYTDT(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB_NYUYTDT, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DEF)
                    Wk_Index = CShort(FR_SSSSUB01.BD_RELZAISU(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB_RELZAISU, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DEF)
                    Wk_Index = CShort(FR_SSSSUB01.BD_ZUMISU(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB_ZUMISU, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DEF)
                    Wk_Index = CShort(FR_SSSSUB01.BD_HIKSU(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB_HIKSU, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DEF)
                    ' === 20070205 === INSERT S - ACE)Yano
                    Wk_Index = CShort(FR_SSSSUB01.BD_MNSU(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB_MNSU, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DEF)
                    ' === 20070205 === INSERT E -
                    Wk_Index = CShort(FR_SSSSUB01.BD_INP_HIKSU(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB_INP_HIKSU, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DEF)

                End With

                '�{�f�B������͍ς݂ɐݒ�
                pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Status = BODY_ROW_STATE_INPUT
                '�����R�[�h
                '2019/10/01 DEL START
                'Call CF_Ora_MoveNext(Usr_Ody)
                '2019/10/01 DEL END
            Next

            '�s���̔z��́A�Œ�A��ʕ\�����א����K�v
            '�i�����Ȃ��ꍇ�ACF_Body_Dsp �ɂăG���[����������j
            '�Ȃ̂ŁA�����Ŕz��� Redim ���s���@�@�������ꋤ�ʉ��H�H
            If intCnt < pm_All.Dsp_Base.Dsp_Body_Cnt Then
                    '�s�ǉ�
                    ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
                    For intIdx = intCnt + 1 To pm_All.Dsp_Base.Dsp_Body_Cnt
                        '�s���ڏ��R�s�[
                        Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intIdx))
                        pm_All.Dsp_Body_Inf.Row_Inf(intIdx).Bus_Inf.SUB_IsDataRow = False
                    Next intIdx
                End If

                With pm_HIKET51A_DSP_DATA
                    '�����ϐ�
                    .ZUMISU = HIKET51A_DSP_DATA_Inf.HIKSUKEI
                End With

                '20080725 ADD START RISE)Tanimura '�r������

                intIndex = 0

                ' �_�~�[�쐬
                ReDim Preserve TYPE_DTLTRA_EXEC_BEF(intIndex)

                For intLoop = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
                    '������
                    strKEY_HINCD = ""
                    strKEY_INPYTDT = ""
                    strKEY_LOTNO = ""
                    strKEY_SOUCD = ""
                    strKEY_TRANO = ""
                    strKEY_MITNOV = ""
                    strKEY_LINNO = ""

                    With pm_All.Dsp_Body_Inf.Row_Inf(intLoop)
                        '�q�ɕʍ݌ɂ̏ꍇ
                        If .Bus_Inf.SUB_KB = "1" Then
                            '���i�R�[�h
                            strKEY_HINCD = .Bus_Inf.SUB_HINCD
                            '���ח\���
                            strKEY_INPYTDT = "        "
                            '���b�g�ԍ�
                            strKEY_LOTNO = "                    "
                            '�q�ɃR�[�h
                            strKEY_SOUCD = .Bus_Inf.SUB_SOUCD
                            '���ϔԍ�,�󒍔ԍ�
                            strKEY_TRANO = HIKET51_Interface.DENNO1
                            '�Ő�
                            strKEY_MITNOV = HIKET51_Interface.DENNO2
                            '�s�ԍ�
                            strKEY_LINNO = HIKET51_Interface.LINNO
                        Else
                            '���i�R�[�h
                            strKEY_HINCD = .Bus_Inf.SUB_HINCD
                            '���ח\���
                            strKEY_INPYTDT = .Bus_Inf.SUB_NYUYTDT
                            '���b�g�ԍ�
                            strKEY_LOTNO = .Bus_Inf.SUB_LOTNO
                            '�q�ɃR�[�h
                            strKEY_SOUCD = .Bus_Inf.SUB_SOUCD
                            '���ϔԍ�,�󒍔ԍ�
                            strKEY_TRANO = HIKET51_Interface.DENNO1
                            '�Ő�
                            strKEY_MITNOV = HIKET51_Interface.DENNO2
                            '�s�ԍ�
                            strKEY_LINNO = HIKET51_Interface.LINNO
                        End If

                        '��������t�@�C���擾SQL
                        strSQL = ""
                        strSQL = strSQL & " Select"
                        strSQL = strSQL & "     TRAKB "
                        strSQL = strSQL & "   , TRANO "
                        strSQL = strSQL & "   , MITNOV "
                        strSQL = strSQL & "   , LINNO "
                        strSQL = strSQL & "   , PUDLNO "
                        strSQL = strSQL & "   , TRADT "
                        strSQL = strSQL & "   , ATMNKB "
                        strSQL = strSQL & "   , HIKNO "
                        strSQL = strSQL & "   , HINCD "
                        strSQL = strSQL & "   , INPYTDT "
                        strSQL = strSQL & "   , LOTNO "
                        strSQL = strSQL & "   , SOUCD "
                        strSQL = strSQL & "   , SISNKB "
                        strSQL = strSQL & "   , SOUTRICD "
                        strSQL = strSQL & "   , SOUKOKB "
                        strSQL = strSQL & "   , HIKSU "
                        strSQL = strSQL & "   , OPEID "
                        strSQL = strSQL & "   , CLTID "
                        strSQL = strSQL & "   , WRTTM "
                        strSQL = strSQL & "   , WRTDT "
                        strSQL = strSQL & " From"
                        strSQL = strSQL & "     DTLTRA"
                        strSQL = strSQL & " Where"
                        strSQL = strSQL & "     HINCD = '" & CF_Ora_String(strKEY_HINCD, 10) & "' "
                        strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String(strKEY_INPYTDT, 8) & "' "
                        strSQL = strSQL & " And LOTNO    = '" & CF_Ora_String(strKEY_LOTNO, 20) & "' "
                        strSQL = strSQL & " And SOUCD    = '" & CF_Ora_String(strKEY_SOUCD, 3) & "' "

                        '����
                        If HIKET51_Interface.Mode = CDbl("1") Then
                            strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(strKEY_TRANO, 20) & "' "
                            strSQL = strSQL & " And MITNOV = '" & CF_Ora_String(strKEY_MITNOV, 2) & "' "
                            strSQL = strSQL & " And LINNO  = '" & CF_Ora_String(strKEY_LINNO, 3) & "' "
                        Else
                            strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(strKEY_TRANO, 20) & "' "
                            strSQL = strSQL & " And LINNO  = '" & CF_Ora_String(strKEY_LINNO, 3) & "' "
                        End If

                        strSQL = strSQL & " Order By "
                        strSQL = strSQL & "     ATMNKB DESC "

                    'DB�A�N�Z�X
                    '2019/10/01 CHG START
                    'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

                    'Do Until CF_Ora_EOF(Usr_Ody)
                    dt = DB_GetTable(strSQL)
                    For Each row As DataRow In dt.Rows

                        '2019/10/01 CHG END
                        intIndex = intIndex + 1

                        ReDim Preserve TYPE_DTLTRA_EXEC_BEF(intIndex)

                        With TYPE_DTLTRA_EXEC_BEF(intIndex)
                            .HINCD = strKEY_HINCD ' ���i�R�[�h
                            .INPYTDT = strKEY_INPYTDT ' ���ɗ\���
                            .LOTNO = strKEY_LOTNO ' ���b�g�ԍ�
                            .SOUCD = strKEY_SOUCD ' �q�ɃR�[�h
                            .TRANO = strKEY_TRANO ' �g�����ԍ�
                            .MITNOV = strKEY_MITNOV ' �Ő�
                            .LINNO = strKEY_LINNO ' �s�ԍ�

                            '2019/10/01 CHG START

                            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '.SUB_TRAKB = CF_Ora_GetDyn(Usr_Ody, "TRAKB", "") ' �g�������
                            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '.SUB_TRANO = CF_Ora_GetDyn(Usr_Ody, "TRANO", "") ' �g�����ԍ�
                            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '.SUB_MITNOV = CF_Ora_GetDyn(Usr_Ody, "MITNOV", "") ' �Ő�
                            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '.SUB_LINNO = CF_Ora_GetDyn(Usr_Ody, "LINNO", "") ' �s�ԍ�
                            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '.SUB_PUDLNO = CF_Ora_GetDyn(Usr_Ody, "PUDLNO", "") ' ���o�ɔԍ�
                            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '.SUB_TRADT = CF_Ora_GetDyn(Usr_Ody, "TRADT", "") ' �g�������t
                            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '.SUB_HIKNO = CF_Ora_GetDyn(Usr_Ody, "HIKNO", "") ' �����ԍ�
                            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '.SUB_HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "") ' ���i�R�[�h
                            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '.SUB_OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") ' �ŏI��Ǝ҃R�[�h
                            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '.SUB_CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") ' �N���C�A���g�h�c
                            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '.SUB_WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") ' �^�C���X�^���v�i�o�b�`���ԁj
                            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '.SUB_WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") ' �^�C���X�^���v�i�o�b�`���j

                            .SUB_TRAKB = DB_NullReplace(row("TRAKB"), "") ' �g�������

                            .SUB_TRANO = DB_NullReplace(row("TRANO"), "") ' �g�����ԍ�

                            .SUB_MITNOV = DB_NullReplace(row("MITNOV"), "")  ' �Ő�

                            .SUB_LINNO = DB_NullReplace(row("LINNO"), "") ' �s�ԍ�

                            .SUB_PUDLNO = DB_NullReplace(row("PUDLNO"), "") ' ���o�ɔԍ�

                            .SUB_TRADT = DB_NullReplace(row("TRADT"), "") ' �g�������t

                            .SUB_HIKNO = DB_NullReplace(row("HIKNO"), "") ' �����ԍ�

                            .SUB_HINCD = DB_NullReplace(row("HINCD"), "") ' ���i�R�[�h

                            .SUB_OPEID = DB_NullReplace(row("OPEID"), "") ' �ŏI��Ǝ҃R�[�h

                            .SUB_CLTID = DB_NullReplace(row("CLTID"), "") ' �N���C�A���g�h�c

                            .SUB_WRTTM = DB_NullReplace(row("WRTTM"), "") ' �^�C���X�^���v�i�o�b�`���ԁj

                            .SUB_WRTDT = DB_NullReplace(row("WRTDT"), "") ' �^�C���X�^���v�i�o�b�`���j

                            '2019/10/01 CHG END

                        End With

                        '�����R�[�h
                        '2019/10/01 DEL START
                        'Call CF_Ora_MoveNext(Usr_Ody)
                        '2019/10/01 DEL END
                    Next
                End With
                Next intLoop
                '20080725 ADD END   RISE)Tanimura
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
	Private Function F_SET_BD_DATA(ByRef pm_HIKET51A_DSP_DATA As HIKET51A_DSP_DATA, ByRef pm_All As Cls_All, ByRef pm_intCnt As Short) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		F_SET_BD_DATA = 9
		
		'���w�b�_��
		With pm_HIKET51A_DSP_DATA
			'�y�`�[���z
			Trg_Index = CShort(FR_SSSSUB01.HD_DEN_SBT.Tag)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Dsp_Value = CF_Cnv_Dsp_Item(.DENSBT, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'�y�`�[�ԍ��z
			Trg_Index = CShort(FR_SSSSUB01.HD_JDNNO.Tag)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Dsp_Value = CF_Cnv_Dsp_Item(.JDNNO, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'�y�s�ԍ��z
			Trg_Index = CShort(FR_SSSSUB01.HD_LINNO.Tag)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Dsp_Value = CF_Cnv_Dsp_Item(F_Get_DspLineNo(.LINNO, HIKET51_Interface.JDNTRKB), pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'�y�c�ƒS���ҁz
			Trg_Index = CShort(FR_SSSSUB01.HD_TANNM.Tag)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Dsp_Value = CF_Cnv_Dsp_Item(.TANNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'�y���i�R�[�h�z
			Trg_Index = CShort(FR_SSSSUB01.HD_HINCD.Tag)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Dsp_Value = CF_Cnv_Dsp_Item(.HINCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'�y�^���z
			Trg_Index = CShort(FR_SSSSUB01.HD_HINNMA.Tag)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Dsp_Value = CF_Cnv_Dsp_Item(.HINNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'�y�i���z
			Trg_Index = CShort(FR_SSSSUB01.HD_HINNMB.Tag)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Dsp_Value = CF_Cnv_Dsp_Item(.HINNMB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'�y���ʁz
			Trg_Index = CShort(FR_SSSSUB01.HD_UODSU.Tag)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Dsp_Value = CF_Cnv_Dsp_Item(.UODSU, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			' === 20070205 === INSERT S - ACE)Yano
			'�y�蓮�ϐ��z
			Trg_Index = CShort(FR_SSSSUB01.HD_MNSU.Tag)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Dsp_Value = CF_Cnv_Dsp_Item(.MNSU, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			' === 20070205 === INSERT E -
			'�y�����ϐ��z
			Trg_Index = CShort(FR_SSSSUB01.HD_ZUMISU.Tag)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Dsp_Value = CF_Cnv_Dsp_Item(.ZUMISU, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			
		End With

        '���{�f�B��
        '�X�N���[���o�[�l�ݒ�
        '�ő�l
        '2019/10/01 CHG START
        'Call CF_Set_VScrl_Max(F_Get_VScrl_Max(pm_intCnt, pm_All.Dsp_Base.Dsp_Body_Cnt), pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
        pm_intCnt = IIf(pm_intCnt = 1, pm_intCnt, pm_intCnt - 1)
        Call CF_Set_VScrl_Max(pm_intCnt, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
        '2019/10/01 CHG END

        '�ŏ�s�ݒ�i��������Ȃ̂łP�j
        pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
		
		'���וҏW���C��
		Call CF_Body_Dsp(pm_All)
		
		' === 20060804 === INSERT S - ACE)Nagasawa
		'���׃J���[�t��
		Call CF_Set_BD_Color(pm_All)
		' === 20060804 === INSERT E -
		
		'���t�b�^��
		
		F_SET_BD_DATA = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_INP_SQL
	'   �T�v�F  ���ח\����f�[�^�擾�r�p�k����
	'   �����F�@pm_strCode1           :����1
	'   �ߒl�F�@����SQL
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_INP_SQL() As String
		
		Dim strSQL As String
		
		'�T�[�o�V�X�e�����t�擾
		Call CF_Get_SysDt()
		
		'�����r�p�k���s
		strSQL = ""
		
		'//////////////////////////////////////////////////////////////////////
		'�q�ɕʍ݌Ƀ}�X�^���(���i�q��)
		'//////////////////////////////////////////////////////////////////////
		strSQL = " ( "
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     0               As SORTNO" '�\�[�g�p
		strSQL = strSQL & "    ,1               As KB" '�f�[�^�敪
		strSQL = strSQL & "    ,HIN.SOUCD       As SOUCD" '�q�ɃR�[�h
		strSQL = strSQL & "    ,HIN.HINCD       As HINCD" '���i�R�[�h
		strSQL = strSQL & "    ,HIN.SISNKB      As SISNKB" '���Y���敪
		strSQL = strSQL & "    ,HIN.SOUTRICD    As SOUTRICD" '�����R�[�h
		strSQL = strSQL & "    ,HIN.SOUKOKB     As SOUKOKB" '�q�ɋ敪
		strSQL = strSQL & "    ,SOU.SOUNM       As SOUNM" '�q�ɖ�
		strSQL = strSQL & "    ,NULL            As LOTNO" '���b�g�ԍ�
		strSQL = strSQL & "    ,NULL            As INPYTDT" '���ɗ\���
		strSQL = strSQL & "    ,HIN.RELZAISU    As RELZAISU" '���ݍ݌ɐ�
		strSQL = strSQL & "    ,HIN.HIKSU       As ZUMISU" '�����ϐ�
		strSQL = strSQL & "    ,HIN.RELZAISU - HIN.HIKSU As HIKSU" '�����\��
		strSQL = strSQL & "    ,DTL.HIKSU       As INP_HIKSU" '������
		' === 20070205 === INSERT S - ACE)Yano
		strSQL = strSQL & "    ,DTL.MNSU        As MNSU" '������
		' === 20070205 === INSERT E -
		' === 20080715 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
		'���ψȊO�̏ꍇ
		If HIKET51_Interface.Mode <> CDbl("1") Then
			strSQL = strSQL & "    ,FDN.FRDSU   As FRDSU" '�o�׎w����
		Else
			strSQL = strSQL & "    ,0           As FRDSU" '�o�׎w����
		End If
		' === 20080715 === INSERT E -
		'20080725 ADD START RISE)Tanimura '�r������
		strSQL = strSQL & "    ,HIN.OPEID       As OPEID" '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "    ,HIN.CLTID       As CLTID" '�N���C�A���g�h�c
		strSQL = strSQL & "    ,HIN.WRTTM       As WRTTM" '�^�C���X�^���v�i�o�b�`���ԁj
		strSQL = strSQL & "    ,HIN.WRTDT       As WRTDT" '�^�C���X�^���v�i�o�b�`���j
		strSQL = strSQL & "    ,HIN.UOPEID      As UOPEID" '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "    ,HIN.UCLTID      As UCLTID" '�N���C�A���g�h�c
		strSQL = strSQL & "    ,HIN.UWRTTM      As UWRTTM" '�^�C���X�^���v�i�o�b�`���ԁj
		strSQL = strSQL & "    ,HIN.UWRTDT      As UWRTDT" '�^�C���X�^���v�i�o�b�`���j
		'20080725 ADD END   RISE)Tanimura
		strSQL = strSQL & " From"
		strSQL = strSQL & "     HINMTB HIN"
		strSQL = strSQL & "    ,SOUMTA SOU"
		' === 20070207 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "    ,DTLTRA DTL"
		strSQL = strSQL & "    ,( SELECT  TRAKB"
		strSQL = strSQL & "              ,TRANO"
		strSQL = strSQL & "              ,MITNOV"
		strSQL = strSQL & "              ,LINNO"
		strSQL = strSQL & "              ,PUDLNO"
		strSQL = strSQL & "              ,HINCD"
		strSQL = strSQL & "              ,INPYTDT"
		strSQL = strSQL & "              ,SOUCD"
		strSQL = strSQL & "              ,SUM(HIKSU) As HIKSU"
		strSQL = strSQL & "              ,SUM(DECODE(ATMNKB , 'M', HIKSU, 0)) As MNSU"
		strSQL = strSQL & "         FROM  DTLTRA"
		strSQL = strSQL & "        WHERE  HINCD = '" & CF_Ora_String(HIKET51_Interface.HINCD, 10) & "' "
		strSQL = strSQL & "        GROUP BY"
		strSQL = strSQL & "               TRAKB"
		strSQL = strSQL & "              ,TRANO"
		strSQL = strSQL & "              ,MITNOV"
		strSQL = strSQL & "              ,LINNO"
		strSQL = strSQL & "              ,PUDLNO"
		strSQL = strSQL & "              ,HINCD"
		strSQL = strSQL & "              ,INPYTDT"
		strSQL = strSQL & "              ,SOUCD"
		strSQL = strSQL & "     ) DTL"
		' === 20070207 === UPDATE E
		' === 20080715 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
		'���ψȊO�̏ꍇ
		If HIKET51_Interface.Mode <> CDbl("1") Then
			strSQL = strSQL & "    ,( SELECT  OUTSOUCD AS SOUCD"
			' === 20081229 === UPDATE S - ACE)Nagasawa �o�׎w�����͏o�׎w���g�����̏o�׎w�����̍��v�Ƃ���
			'D        strSQL = strSQL & "              ,SUM(FRDSU - OTPSU) AS FRDSU"
			strSQL = strSQL & "              ,SUM(FRDSU)          AS FRDSU"
			' === 20081229 === UPDATE E -
			strSQL = strSQL & "         FROM  FDNTRA"
			strSQL = strSQL & "        WHERE  JDNNO    = '" & CF_Ora_String(HIKET51_Interface.DENNO1, 10) & "' "
			strSQL = strSQL & "          AND  JDNLINNO = '" & CF_Ora_String(HIKET51_Interface.LINNO, 3) & "' "
			strSQL = strSQL & "          AND  HINCD    = '" & CF_Ora_String(HIKET51_Interface.HINCD, 10) & "' "
			strSQL = strSQL & "          AND  PUDLNO   = '" & CF_Ora_String(HIKET51_Interface.PUDLNO, 10) & "' "
			strSQL = strSQL & "          AND  DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
			strSQL = strSQL & "        GROUP BY"
			strSQL = strSQL & "               OUTSOUCD"
			strSQL = strSQL & "     ) FDN"
		End If
		' === 20080715 === INSERT E -
		' === 20070118 === INSERT S - ACE)Yano �󒍎��̑q�ɂ���W���q�ɂ֕ύX
		' === 20071230 === UPDATE S - ACE)Yano �S�Ă̐��i�R�[�h�𒊏o
		'    strSQL = strSQL & "    ,( SELECT  HINCD"
		'    strSQL = strSQL & "              ,SUBSTR(TNACM, 1, 3) SOUCD"
		'    strSQL = strSQL & "         FROM  HINMTA"
		'    strSQL = strSQL & "        WHERE  HINCD = '" & CF_Ora_String(HIKET51_Interface.HINCD, 10) & "' "
		'    strSQL = strSQL & "     ) HIA"
		' === 20071230 === UPDATE E - ACE)Yano
		' === 20070118 === INSERT E
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     HIN.DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & " And HIN.HINCD = '" & CF_Ora_String(HIKET51_Interface.HINCD, 10) & "' "
		' === 20070118 === UPDATE S - ACE)Yano �󒍎��̑q�ɂ���W���q�ɂ֕ύX
		''    strSQL = strSQL & " And HIN.SOUCD = '" & CF_Ora_String(HIKET51_Interface.SOUCD, 3) & "' "
		' === 20071230 === UPDATE S - ACE)Yano �S�Ă̐��i�R�[�h�𒊏o
		'    strSQL = strSQL & " And HIN.SOUCD = HIA.SOUCD"
		If HIKET51_Interface.JDNINKB = "1" Or HIKET51_Interface.JDNINKB = "3" Or HIKET51_Interface.JDNINKB = "4" Then
			strSQL = strSQL & " And HIN.SOUKOKB = '01' "
		Else
			strSQL = strSQL & " And HIN.SOUKOKB = '02' "
		End If
		' === 20071230 === UPDATE E - ACE)Yano
		' === 20070118 === UPDATE E -
		''    strSQL = strSQL & " And HIN.SISNKB = '" & CF_Ora_String(gc_strSISNKB_JI, 1) & "' "
		''    strSQL = strSQL & " And HIN.SOUTRICD = '" & CF_Ora_String(HIKET51_Interface.TOKCD, 10) & "' "
		''    strSQL = strSQL & " And HIN.SOUKOKB = '" & CF_Ora_String(gc_strSOUKOKB_TORIOKI, 2) & "' "
		strSQL = strSQL & " And HIN.SOUCD = SOU.SOUCD(+)"
		strSQL = strSQL & " And HIN.SOUCD = DTL.SOUCD(+)"
		strSQL = strSQL & " And HIN.HINCD = DTL.HINCD(+)"
		' === 20070207 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & " And HIN.SISNKB = DTL.SISNKB(+)"
		'   strSQL = strSQL & " And HIN.SOUTRICD = DTL.SOUTRICD(+)"
		'   strSQL = strSQL & " And HIN.SOUKOKB = DTL.SOUKOKB(+)"
		' === 20070207 === UPDATE E
		strSQL = strSQL & " And DTL.INPYTDT(+) = '        ' " 'SPACE�͑q�ɕʍ݌�
		'���ς̏ꍇ
		If HIKET51_Interface.Mode = CDbl("1") Then
			strSQL = strSQL & " And DTL.TRANO(+) = '" & CF_Ora_String(HIKET51_Interface.DENNO1, 20) & "' "
			strSQL = strSQL & " And DTL.MITNOV(+) = '" & CF_Ora_String(HIKET51_Interface.DENNO2, 2) & "' "
			strSQL = strSQL & " And DTL.LINNO(+) = '" & CF_Ora_String(HIKET51_Interface.LINNO, 3) & "' "
		Else
			strSQL = strSQL & " And DTL.TRANO(+) = '" & CF_Ora_String(HIKET51_Interface.DENNO1, 20) & "' "
			strSQL = strSQL & " And DTL.LINNO(+) = '" & CF_Ora_String(HIKET51_Interface.LINNO, 3) & "' "
			' === 20080715 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
			strSQL = strSQL & " And HIN.SOUCD    = FDN.SOUCD(+)"
			' === 20080715 === INSERT E -
		End If
		strSQL = strSQL & " ) "
		
		'//////////////////////////////////////////////////////////////////////
		'�q�ɕʍ݌Ƀ}�X�^���(������u�q�ɕ�)
		'//////////////////////////////////////////////////////////////////////
		strSQL = strSQL & "UNION ALL( "
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     1               As SORTNO" '�\�[�g�p
		strSQL = strSQL & "    ,1               As KB" '�f�[�^�敪
		strSQL = strSQL & "    ,HIN.SOUCD       As SOUCD" '�q�ɃR�[�h
		strSQL = strSQL & "    ,HIN.HINCD       As HINCD" '���i�R�[�h
		strSQL = strSQL & "    ,HIN.SISNKB      As SISNKB" '���Y���敪
		strSQL = strSQL & "    ,HIN.SOUTRICD    As SOUTRICD" '�����R�[�h
		strSQL = strSQL & "    ,HIN.SOUKOKB     As SOUKOKB" '�q�ɋ敪
		strSQL = strSQL & "    ,'��p�q��'      As SOUNM" '�q�ɖ�
		strSQL = strSQL & "    ,NULL            As LOTNO" '���b�g�ԍ�
		strSQL = strSQL & "    ,NULL            As INPYTDT" '���ɗ\���
		strSQL = strSQL & "    ,HIN.RELZAISU    As RELZAISU" '���ݍ݌ɐ�
		strSQL = strSQL & "    ,HIN.HIKSU       As ZUMISU" '�����ϐ�
		strSQL = strSQL & "    ,HIN.RELZAISU - HIN.HIKSU As HIKSU" '�����\��
		strSQL = strSQL & "    ,DTL.HIKSU       As INP_HIKSU" '������
		' === 20070205 === INSERT S - ACE)Yano
		strSQL = strSQL & "    ,DTL.MNSU        As MNSU" '������
		' === 20070205 === INSERT E -
		' === 20080715 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
		'���ψȊO�̏ꍇ
		If HIKET51_Interface.Mode <> CDbl("1") Then
			strSQL = strSQL & "    ,FDN.FRDSU   As FRDSU" '�o�׎w����
		Else
			strSQL = strSQL & "    ,0           As FRDSU" '�o�׎w����
		End If
		' === 20080715 === INSERT E -
		'20080725 ADD START RISE)Tanimura '�r������
		strSQL = strSQL & "    ,HIN.OPEID       As OPEID" '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "    ,HIN.CLTID       As CLTID" '�N���C�A���g�h�c
		strSQL = strSQL & "    ,HIN.WRTTM       As WRTTM" '�^�C���X�^���v�i�o�b�`���ԁj
		strSQL = strSQL & "    ,HIN.WRTDT       As WRTDT" '�^�C���X�^���v�i�o�b�`���j
		strSQL = strSQL & "    ,HIN.UOPEID      As UOPEID" '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "    ,HIN.UCLTID      As UCLTID" '�N���C�A���g�h�c
		strSQL = strSQL & "    ,HIN.UWRTTM      As UWRTTM" '�^�C���X�^���v�i�o�b�`���ԁj
		strSQL = strSQL & "    ,HIN.UWRTDT      As UWRTDT" '�^�C���X�^���v�i�o�b�`���j
		'20080725 ADD END   RISE)Tanimura
		strSQL = strSQL & " From"
		strSQL = strSQL & "     HINMTB HIN"
		strSQL = strSQL & "    ,( SELECT  TRAKB"
		strSQL = strSQL & "              ,TRANO"
		strSQL = strSQL & "              ,MITNOV"
		strSQL = strSQL & "              ,LINNO"
		strSQL = strSQL & "              ,PUDLNO"
		strSQL = strSQL & "              ,HINCD"
		strSQL = strSQL & "              ,INPYTDT"
		strSQL = strSQL & "              ,SOUCD"
		strSQL = strSQL & "              ,SUM(HIKSU) As HIKSU"
		strSQL = strSQL & "              ,SUM(DECODE(ATMNKB , 'M', HIKSU, 0)) As MNSU"
		strSQL = strSQL & "         FROM  DTLTRA"
		strSQL = strSQL & "        WHERE  HINCD = '" & CF_Ora_String(HIKET51_Interface.HINCD, 10) & "' "
		strSQL = strSQL & "        GROUP BY"
		strSQL = strSQL & "               TRAKB"
		strSQL = strSQL & "              ,TRANO"
		strSQL = strSQL & "              ,MITNOV"
		strSQL = strSQL & "              ,LINNO"
		strSQL = strSQL & "              ,PUDLNO"
		strSQL = strSQL & "              ,HINCD"
		strSQL = strSQL & "              ,INPYTDT"
		strSQL = strSQL & "              ,SOUCD"
		strSQL = strSQL & "     ) DTL"
		' === 20080715 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
		'���ψȊO�̏ꍇ
		If HIKET51_Interface.Mode <> CDbl("1") Then
			strSQL = strSQL & "    ,( SELECT  OUTSOUCD AS SOUCD"
			strSQL = strSQL & "              ,SUM(FRDSU - OTPSU) AS FRDSU"
			strSQL = strSQL & "         FROM  FDNTRA"
			strSQL = strSQL & "        WHERE  JDNNO    = '" & CF_Ora_String(HIKET51_Interface.DENNO1, 10) & "' "
			strSQL = strSQL & "          AND  JDNLINNO = '" & CF_Ora_String(HIKET51_Interface.LINNO, 3) & "' "
			strSQL = strSQL & "          AND  HINCD    = '" & CF_Ora_String(HIKET51_Interface.HINCD, 10) & "' "
			strSQL = strSQL & "          AND  PUDLNO   = '" & CF_Ora_String(HIKET51_Interface.PUDLNO, 10) & "' "
			strSQL = strSQL & "          AND  DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
			strSQL = strSQL & "        GROUP BY"
			strSQL = strSQL & "               OUTSOUCD"
			strSQL = strSQL & "     ) FDN"
		End If
		' === 20080715 === INSERT E -
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     HIN.DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & " And HIN.HINCD = '" & CF_Ora_String(HIKET51_Interface.HINCD, 10) & "' "
		strSQL = strSQL & " And HIN.SISNKB = '" & CF_Ora_String(gc_strSISNKB_JI, 1) & "' "
		strSQL = strSQL & " And HIN.SOUTRICD = '" & CF_Ora_String(HIKET51_Interface.TOKCD, 10) & "' "
		strSQL = strSQL & " And HIN.SOUKOKB = '" & CF_Ora_String(gc_strSOUKOKB_TORIOKI, 2) & "' "
		strSQL = strSQL & " And HIN.SOUCD = DTL.SOUCD(+)"
		strSQL = strSQL & " And HIN.HINCD = DTL.HINCD(+)"
		strSQL = strSQL & " And DTL.INPYTDT(+) = '        '"
		'���ς̏ꍇ
		If HIKET51_Interface.Mode = CDbl("1") Then
			strSQL = strSQL & " And DTL.TRANO(+) = '" & CF_Ora_String(HIKET51_Interface.DENNO1, 20) & "' "
			strSQL = strSQL & " And DTL.MITNOV(+) = '" & CF_Ora_String(HIKET51_Interface.DENNO2, 2) & "' "
			strSQL = strSQL & " And DTL.LINNO(+) = '" & CF_Ora_String(HIKET51_Interface.LINNO, 3) & "' "
		Else
			strSQL = strSQL & " And DTL.TRANO(+) = '" & CF_Ora_String(HIKET51_Interface.DENNO1, 20) & "' "
			strSQL = strSQL & " And DTL.LINNO(+) = '" & CF_Ora_String(HIKET51_Interface.LINNO, 3) & "' "
			' === 20080715 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
			strSQL = strSQL & " And HIN.SOUCD    = FDN.SOUCD(+)"
			' === 20080715 === INSERT E -
		End If
		strSQL = strSQL & " ) "
		
		'//////////////////////////////////////////////////////////////////////
		'���ח\����
		'//////////////////////////////////////////////////////////////////////
		strSQL = strSQL & "UNION ALL( "
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     2               As SORTNO" '�\�[�g�p
		strSQL = strSQL & "    ,2               As KB" '�f�[�^�敪
		strSQL = strSQL & "    ,INP.INPSOUCD    As SOUCD" '�q�ɃR�[�h
		strSQL = strSQL & "    ,INP.HINCD       As HINCD" '���i�R�[�h
		strSQL = strSQL & "    ,SOU.SISNKB      As SISNKB" '���Y���敪
		strSQL = strSQL & "    ,SOU.SOUTRICD    As SOUTRICD" '�����R�[�h
		strSQL = strSQL & "    ,SOU.SOUKOKB     As SOUKOKB" '�q�ɋ敪
		strSQL = strSQL & "    ,SOU.SOUNM       As SOUNM" '�q�ɖ�
		strSQL = strSQL & "    ,INP.LOTNO       As LOTNO" '���b�g�ԍ�
		strSQL = strSQL & "    ,INP.INPYTDT     As INPYTDT" '���ɗ\���
		' === 20070222 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "    ,INP.INPSU       As RELZAISU"        '���ݍ݌ɐ�
		strSQL = strSQL & "    ,INP.INPSU - INP.INPSMSU As RELZAISU" '���ݍ݌ɐ�
		' === 20070222 === UPDATE E -
		strSQL = strSQL & "    ,INP.INHIKSU     As ZUMISU" '�����ϐ�
		' === 20060929 === UPDATE S - ACE)Nagasawa �����\���͓��ɍϐ�������
		'    strSQL = strSQL & "    ,INP.INPSU - INP.INHIKSU As HIKSU"   '�����\��
		strSQL = strSQL & "    ,INP.INPSU - INP.INHIKSU - INP.INPSMSU As HIKSU" '�����\��
		' === 20060929 === UPDATE E -
		strSQL = strSQL & "    ,DTL.HIKSU       As INP_HIKSU" '������
		' === 20070205 === INSERT S - ACE)Yano
		strSQL = strSQL & "    ,DTL.MNSU        As MNSU" '�蓮������
		' === 20070205 === INSERT E -
		' === 20080715 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
		strSQL = strSQL & "    ,0           As FRDSU" '�o�׎w����
		' === 20080715 === INSERT E -
		'20080725 ADD START RISE)Tanimura '�r������
		strSQL = strSQL & "    ,INP.OPEID       As OPEID" '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "    ,INP.CLTID       As CLTID" '�N���C�A���g�h�c
		strSQL = strSQL & "    ,INP.WRTTM       As WRTTM" '�^�C���X�^���v�i�o�b�`���ԁj
		strSQL = strSQL & "    ,INP.WRTDT       As WRTDT" '�^�C���X�^���v�i�o�b�`���j
		strSQL = strSQL & "    ,INP.UOPEID      As UOPEID" '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "    ,INP.UCLTID      As UCLTID" '�N���C�A���g�h�c
		strSQL = strSQL & "    ,INP.UWRTTM      As UWRTTM" '�^�C���X�^���v�i�o�b�`���ԁj
		strSQL = strSQL & "    ,INP.UWRTDT      As UWRTDT" '�^�C���X�^���v�i�o�b�`���j
		'20080725 ADD END   RISE)Tanimura
		strSQL = strSQL & " From"
		strSQL = strSQL & "     INPTRA INP"
		strSQL = strSQL & "    ,SOUMTA SOU"
		' === 20070207 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "    ,DTLTRA DTL"
		strSQL = strSQL & "    ,( SELECT  TRAKB"
		strSQL = strSQL & "              ,TRANO"
		strSQL = strSQL & "              ,MITNOV"
		strSQL = strSQL & "              ,LINNO"
		strSQL = strSQL & "              ,PUDLNO"
		strSQL = strSQL & "              ,HINCD"
		strSQL = strSQL & "              ,INPYTDT"
		strSQL = strSQL & "              ,LOTNO"
		strSQL = strSQL & "              ,SOUCD"
		strSQL = strSQL & "              ,SUM(HIKSU) As HIKSU"
		strSQL = strSQL & "              ,SUM(DECODE(ATMNKB , 'M', HIKSU, 0)) As MNSU"
		strSQL = strSQL & "         FROM  DTLTRA"
		strSQL = strSQL & "        WHERE  HINCD = '" & CF_Ora_String(HIKET51_Interface.HINCD, 10) & "' "
		strSQL = strSQL & "        GROUP BY"
		strSQL = strSQL & "               TRAKB"
		strSQL = strSQL & "              ,TRANO"
		strSQL = strSQL & "              ,MITNOV"
		strSQL = strSQL & "              ,LINNO"
		strSQL = strSQL & "              ,PUDLNO"
		strSQL = strSQL & "              ,HINCD"
		strSQL = strSQL & "              ,INPYTDT"
		strSQL = strSQL & "              ,LOTNO"
		strSQL = strSQL & "              ,SOUCD"
		strSQL = strSQL & "     ) DTL"
		' === 20070207 === UPDATE E
		' === 20070118 === INSERT S - ACE)Yano �󒍎��̑q�ɂ���W���q�ɂ֕ύX
		strSQL = strSQL & "    ,( SELECT  HINCD"
		strSQL = strSQL & "              ,SUBSTR(TNACM, 1, 3) SOUCD"
		strSQL = strSQL & "         FROM  HINMTA"
		strSQL = strSQL & "        WHERE  HINCD = '" & CF_Ora_String(HIKET51_Interface.HINCD, 10) & "' "
		strSQL = strSQL & "     ) HIA"
		' === 20070118 === INSERT E
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     INP.DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & " And INP.HINCD = '" & CF_Ora_String(HIKET51_Interface.HINCD, 10) & "' "
		'    strSQL = strSQL & " And INP.INPYTDT >= '" & CF_Ora_String(GV_UNYDate, 8) & "' "
		' === 20070118 === INSERT S - ACE)Yano �󒍎��̑q�ɂ���W���q�ɂ֕ύX
		strSQL = strSQL & " And INP.INPSOUCD = HIA.SOUCD"
		' === 20070118 === INSERT E
		' === 20070210 === INSERT S - ACE)Yano
		strSQL = strSQL & " And INP.PLANKB = ' '"
		' === 20070210 === INSERT E -
		strSQL = strSQL & " And INP.INPSOUCD = SOU.SOUCD(+)"
		strSQL = strSQL & " And INP.HINCD = DTL.HINCD(+)"
		strSQL = strSQL & " And INP.INPYTDT = DTL.INPYTDT(+)"
		strSQL = strSQL & " And INP.LOTNO = DTL.LOTNO(+)"
		strSQL = strSQL & " And INP.INPSU > INP.INPSMSU "
		' === 20060929 === INSERT S - ACE)Nagasawa ���ɍς̃f�[�^�͕\�����Ȃ�
		strSQL = strSQL & " And INP.INPSOUCD = DTL.SOUCD(+)"
		' === 20060929 === INSERT E -
		'���ς̏ꍇ
		If HIKET51_Interface.Mode = CDbl("1") Then
			strSQL = strSQL & " And DTL.TRANO(+) = '" & CF_Ora_String(HIKET51_Interface.DENNO1, 20) & "' "
			strSQL = strSQL & " And DTL.MITNOV(+) = '" & CF_Ora_String(HIKET51_Interface.DENNO2, 2) & "' "
			strSQL = strSQL & " And DTL.LINNO(+) = '" & CF_Ora_String(HIKET51_Interface.LINNO, 3) & "' "
		Else
			strSQL = strSQL & " And DTL.TRANO(+) = '" & CF_Ora_String(HIKET51_Interface.DENNO1, 20) & "' "
			strSQL = strSQL & " And DTL.LINNO(+) = '" & CF_Ora_String(HIKET51_Interface.LINNO, 3) & "' "
		End If
		strSQL = strSQL & " ) "
		
		'//////////////////////////////////////////////////////////////////////
		'ORDER BY��
		'//////////////////////////////////////////////////////////////////////
		strSQL = strSQL & " Order By"
		strSQL = strSQL & "     SORTNO"
		strSQL = strSQL & "    ,INPYTDT"
		strSQL = strSQL & "    ,SOUCD"
		strSQL = strSQL & "    ,LOTNO"
		
		F_GET_INP_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_MIT_HD_SQL
	'   �T�v�F  ���Ϗ��w�b�_�f�[�^�擾�r�p�k����
	'   �����F�@pm_strCode1           :���ϔԍ�
	'       �F�@pm_strCode2           :�Ő�
	'       �F�@pm_strCode3           :�s�ԍ�
	'   �ߒl�F�@����SQL
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_MIT_HD_SQL(ByRef pm_strCode1 As String, ByRef pm_strCode2 As String, ByRef pm_strCode3 As String) As String
		
		Dim strSQL As String
		
		'�����r�p�k���s
		strSQL = ""
		strSQL = strSQL & " Select"
		' === 20070127 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "     SUM(ZAIHIKSU) "
		'   strSQL = strSQL & "   + SUM(NYTHIKSU) ZUMISU"       '�����ϐ�
		strSQL = strSQL & "     SUM(MITSU) UODSU" '����
		strSQL = strSQL & "   , SUM(ZAIHIKSU) "
		strSQL = strSQL & "   + SUM(NYTHIKSU) ZUMISU" '�����ϐ�
		' === 20070127 === UPDATE E -
		strSQL = strSQL & " From"
		strSQL = strSQL & "     MITTRA"
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     DATKB = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & " And MITNO = '" & pm_strCode1 & "' "
		strSQL = strSQL & " And MITNOV = '" & pm_strCode2 & "' "
		strSQL = strSQL & " And LINNO = '" & pm_strCode3 & "' "
		
		F_GET_MIT_HD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_JDN_HD_SQL
	'   �T�v�F  �󒍏��w�b�_�f�[�^�擾�r�p�k����
	'   �����F�@pm_strCode1           :�󒍔ԍ�
	'   �����F�@pm_strCode2           :�s�ԍ�
	'   �ߒl�F�@����SQL
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_JDN_HD_SQL(ByRef pm_strCode1 As String, ByRef pm_strCode2 As String) As String
		
		Dim strSQL As String
		
		'�����r�p�k���s
		strSQL = ""
		strSQL = strSQL & " Select"
		' === 20070127 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "     SUM(ATZHIKSU) "
		'   strSQL = strSQL & "   + SUM(ATNHIKSU) "
		'   strSQL = strSQL & "   + SUM(MNZHIKSU) "
		'   strSQL = strSQL & "   + SUM(MNNHIKSU) "
		'   strSQL = strSQL & "   - SUM(OTPSU) ZUMISU"          '�����ϐ�
		strSQL = strSQL & "     SUM(UODSU) "
		strSQL = strSQL & "   - SUM(FRDSU) "
		strSQL = strSQL & "   - SUM(OTPSU) UODSU" '����
		strSQL = strSQL & "   , SUM(ATZHIKSU) "
		strSQL = strSQL & "   + SUM(ATNHIKSU) "
		strSQL = strSQL & "   + SUM(MNZHIKSU) "
		strSQL = strSQL & "   + SUM(MNNHIKSU) ZUMISU" '�����ϐ�
		' === 20070127 === UPDATE E -
		strSQL = strSQL & " From"
		' === 20060907 === UPDATE S - ACE)Hashiri �ԍ��Ή�(JDNTRV�ɕύX)
		' === 20061107 === UPDATE S - ACE)Yano     View���ð��ق���̎擾�ɍĕύX
		'strSQL = strSQL & "     JDNTRA"
		' === 20070127 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "    ,JDNTRA TRA "
		strSQL = strSQL & "     JDNTRA TRA "
		' === 20070127 === UPDATE E -
		strSQL = strSQL & "    ,( SELECT MAX(DATNO) As DATNO "
		strSQL = strSQL & "             ,JDNNO "
		strSQL = strSQL & "             ,LINNO "
		strSQL = strSQL & "       FROM   JDNTRA "
		strSQL = strSQL & "       WHERE  DATKB  = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "       AND    JDNNO  = '" & pm_strCode1 & "' "
		strSQL = strSQL & "       AND    LINNO  = '" & pm_strCode2 & "' "
		strSQL = strSQL & "       GROUP BY JDNNO "
		strSQL = strSQL & "               ,LINNO "
		strSQL = strSQL & "     ) TRB "
		' === 20060907 === UPDATE E -
		'strSQL = strSQL & " Where"
		'strSQL = strSQL & "     DATKB    = '" & gc_strDATKB_USE & "' "
		'strSQL = strSQL & " And JDNNO    = '" & pm_strCode1 & "' "
		'strSQL = strSQL & " And LINNO    = '" & pm_strCode2 & "' "
		strSQL = strSQL & " Where "
		strSQL = strSQL & "     TRA.DATKB    = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & " And TRA.AKAKROKB = '1' "
		strSQL = strSQL & " And TRA.DATNO    = TRB.DATNO "
		strSQL = strSQL & " And TRA.JDNNO    = TRB.JDNNO "
		strSQL = strSQL & " And TRA.LINNO    = TRB.LINNO "
		strSQL = strSQL & " And TRA.JDNNO    = '" & pm_strCode1 & "' "
		strSQL = strSQL & " And TRA.LINNO    = '" & pm_strCode2 & "' "
		' === 20061107 === UPDATE E -
		
		F_GET_JDN_HD_SQL = strSQL
		
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
		FR_SSSSUB01.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'UPGRADE_ISSUE: Form ���\�b�h FR_SSSSUB01.PrintForm �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
        '2019/09/20 DEL START
        'FR_SSSSUB01.PrintForm()
        '2019/09/20 DEL END
        FR_SSSSUB01.Cursor = System.Windows.Forms.Cursors.Arrow
		If Err.Number <> 0 Then
			If AE_MsgLibrary(PP_SSSMAIN, "HardcopyError") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
		End If
		On Error GoTo 0
		AE_Hardcopy_SSSMAIN = Cn_CuCurrent
	End Function
	
	' === 20060804 === UPDATE S - ACE)Nagasawa
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_BD_Color
	'   �T�v�F  �O�i/�w�i�F�ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_BD_Color(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Bd_Index As Short
		Dim Bd_Index_Bk As Short
		Dim Bd_Col_Index As Short
		Dim Cur_Top_Index As Short
		
		'�{�f�B�����ŏ���
		Bd_Index = 0
		Bd_Index_Bk = 0
		
		For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
			
			If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > 0 Then
				
				'pm_All.Dsp_Body_Inf�̍s�m�n���擾
				Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				
				If Bd_Index_Bk <> Bd_Index Then
					'���׍s�u���C�N
					Bd_Col_Index = 1
					Bd_Index_Bk = Bd_Index
				Else
					Bd_Col_Index = Bd_Col_Index + 1
				End If
				
				'���ɗ\��͐F
				If pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name <> FR_SSSSUB01.BD_SOUNM(1).Name And pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name <> FR_SSSSUB01.BD_INP_HIKSU(1).Name Then
					If Trim(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.SUB_NYUYTDT) <> "" Then
						pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.ForeColor = AE_CONST.COLOR_NAVY
					End If
				End If
			End If
			
		Next 
		
	End Function
	' === 20060804 === UPDATE E -
	
	' === 20080715 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_FRDSU_ATMN
	'   �T�v�F  �o�׎w�������������Ǝ蓮���ɕ�����
	'   �����F  pm_All        : ��ʏ��
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_FRDSU_ATMN(ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim curAtzHikSu_JDN As Decimal '�����݌Ɉ������i�󒍁j
		Dim curMnzHikSu_JDN As Decimal '�蓮�݌Ɉ������i�󒍁j
		Dim curAtzHikSu_DTL As Decimal '�����݌Ɉ������i��������j
		Dim curMnzHikSu_DTL As Decimal '�蓮�݌Ɉ������i��������j
		
		On Error GoTo F_GET_FRDSU_ATMN_err
		
		F_GET_FRDSU_ATMN = 9
		
		'������
		mv_curFRDSU_AT = 0 '�����������o�׎w����
		mv_curFRDSU_MN = 0 '�蓮�������o�׎w����
		
		'���݂̎���݌���SQL
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     ATZHIKSU" '�����݌Ɉ�����
		strSQL = strSQL & "    ,MNZHIKSU" '�蓮�݌Ɉ�����
		strSQL = strSQL & " From"
		strSQL = strSQL & "     JDNTRA TRA"
		strSQL = strSQL & "    ,( SELECT MAX(DATNO) As DATNO"
		strSQL = strSQL & "             ,JDNNO"
		strSQL = strSQL & "             ,LINNO"
		strSQL = strSQL & "       FROM   JDNTRA"
		strSQL = strSQL & "       WHERE "
		strSQL = strSQL & "              DATKB  = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
		strSQL = strSQL & "       AND    JDNNO  = '" & CF_Ora_String(Trim(HIKET51_Interface.DENNO1), 10) & "'"
		strSQL = strSQL & "       AND    LINNO  = '" & CF_Ora_String(Trim(HIKET51_Interface.LINNO), 3) & "'"
		strSQL = strSQL & "       GROUP BY JDNNO"
		strSQL = strSQL & "               ,LINNO"
		strSQL = strSQL & "     ) TRB"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     TRA.DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
		strSQL = strSQL & " And TRA.AKAKROKB = '1'"
		strSQL = strSQL & " And TRA.DATNO    = TRB.DATNO"
		strSQL = strSQL & " And TRA.JDNNO    = TRB.JDNNO"
		strSQL = strSQL & " And TRA.LINNO    = TRB.LINNO"

        'DB�A�N�Z�X
        '2019/10/01 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        'If CF_Ora_EOF(Usr_Ody) = True Then
        Dim dt As DataTable = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/10/01 CHG END
            curAtzHikSu_JDN = 0
            curMnzHikSu_JDN = 0
        Else
            '2019/10/01 CHG START
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'curAtzHikSu_JDN = CF_Ora_GetDyn(Usr_Ody, "ATZHIKSU", 0)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'curMnzHikSu_JDN = CF_Ora_GetDyn(Usr_Ody, "MNZHIKSU", 0)

            curAtzHikSu_JDN = DB_NullReplace(dt.Rows(0)("ATZHIKSU"), 0)
            curMnzHikSu_JDN = DB_NullReplace(dt.Rows(0)("MNZHIKSU"), 0)
            '2019/10/01 CHG END
        End If
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'����̧�ٌ���SQL�i�����݌Ɉ������j
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     Sum(HIKSU)  As ATZHIKSU" '�����݌Ɉ�����
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     HINCD = '" & CF_Ora_String(Trim(HIKET51_Interface.HINCD), 10) & "' "
		strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String("", 8) & "' "
		strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(Trim(HIKET51_Interface.DENNO1), 20) & "' "
		strSQL = strSQL & " And LINNO  = '" & CF_Ora_String(Trim(HIKET51_Interface.LINNO), 3) & "' "
		strSQL = strSQL & " And ATMNKB = 'A' "
        'DB�A�N�Z�X
        '2019/10/01 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        'If CF_Ora_EOF(Usr_Ody) = True Then
        dt = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/10/01 CHG END
            curAtzHikSu_DTL = 0
		Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/01 CHG START
            'curAtzHikSu_DTL = CF_Ora_GetDyn(Usr_Ody, "ATZHIKSU", 0)
            curAtzHikSu_DTL = DB_NullReplace(dt.Rows(0)("ATZHIKSU"), 0)
            '2019/10/01 CHG END
        End If
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'����̧�ٌ���SQL�i�蓮�݌Ɉ������j
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     Sum(HIKSU)  As MNZHIKSU" '�蓮�݌Ɉ�����
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     HINCD = '" & CF_Ora_String(Trim(HIKET51_Interface.HINCD), 10) & "' "
		strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String("", 8) & "' "
		strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(Trim(HIKET51_Interface.DENNO1), 20) & "' "
		strSQL = strSQL & " And LINNO  = '" & CF_Ora_String(Trim(HIKET51_Interface.LINNO), 3) & "' "
		strSQL = strSQL & " And ATMNKB = 'M' "
        'DB�A�N�Z�X
        '2019/10/01 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        'If CF_Ora_EOF(Usr_Ody) = True Then
        dt = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/10/01 CHG END
            curMnzHikSu_DTL = 0
		Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/01 CHG START
            'curMnzHikSu_DTL = CF_Ora_GetDyn(Usr_Ody, "MNZHIKSU", 0)
            curMnzHikSu_DTL = DB_NullReplace(dt.Rows(0)("MNZHIKSU"), 0)
            '2019/10/01 CHG END
        End If
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		' �����������o�׎w����
		mv_curFRDSU_AT = curAtzHikSu_DTL - curAtzHikSu_JDN
		
		' �蓮�������o�׎w����
		mv_curFRDSU_MN = curMnzHikSu_DTL - curMnzHikSu_JDN
		
		F_GET_FRDSU_ATMN = 0
		
F_GET_FRDSU_ATMN_End: 
		Exit Function
		
F_GET_FRDSU_ATMN_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_012, pm_All, "F_GET_FRDSU_ATMN")
		GoTo F_GET_FRDSU_ATMN_End
		
	End Function
	' === 20080715 === INSERT E -
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
End Module