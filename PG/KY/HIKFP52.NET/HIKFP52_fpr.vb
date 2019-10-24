Option Strict Off
Option Explicit On
Module SSSMAIN0001
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	
	'�P�v���W�F�N�g���Ƃ̋��ʃ��C�u����
	Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(1242 + 40 + 0 + 1) As clsCP
	Public CQ_SSSMAIN(82) As String
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� Start ��������������������������������
	'�r���������������������������������������������������������r
	'���i�}�X�^���
	Public Structure UODDL52_TYPE_HINMTA
		Dim DATKB As String '�폜�敪
		Dim HINCD As String '���i�R�[�h
		Dim HINNMA As String '�^��
		Dim HINNMB As String '���i���P
	End Structure
	
	Public UODDL52_HINMTA_Inf As UODDL52_TYPE_HINMTA
	
	'�d���������������������������������������������������������d
	
	' === 20060802 === INSERT S - ACE)Nagasawa  �G���^�[�L�[�A�łɂ��s��C��
	Public gv_bolKeyFlg As Boolean
	Public gv_bolHIKFP52_LF_Enable As Boolean 'LF�������s�t���O(False�F���s���Ȃ�)
	' === 20060802 === INSERT E -
	
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
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_Item_Change
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
				Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
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
	
	'ADD START FKS)INABA 2009/09/30 **********************************************************************************************
	'�A���[��FC09100103
	'�폜�ł����������t�@�C�����ǂ����`�F�b�N���s��
	'�����F
	'
	'�߂�l�F0  �폜OK
	'�@�@�@�F1  �폜NG
	'�@�@�@�F-1 �G���[����
	Function F_DEL_DTLTRA_CHK(ByRef ps_TRAKB As String, ByRef ps_TRANO As String, ByRef ps_MITNOV As String, ByRef ps_LINNO As String, ByRef ps_TRADT As String, ByRef ps_HIKNO As String, ByRef ps_ATMNKB As String, ByRef ps_HINCD As String, ByRef ps_PUDLNO As String) As Short
		Dim ls_sql As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim lb_Ret As Boolean
		Dim lw_cnt As Short
		On Error GoTo F_DEL_DTLTRA_CHK_ERR
		F_DEL_DTLTRA_CHK = -1
		ls_sql = " SELECT COUNT(*) CNT "
		Select Case ps_TRAKB
			Case "2" '��
				ls_sql = ls_sql & "  FROM JDNTRA "
				ls_sql = ls_sql & " WHERE (DATNO ,LINNO) IN "
				ls_sql = ls_sql & "                      (SELECT MAX(DATNO),LINNO "
				ls_sql = ls_sql & "                         FROM JDNTRA"
				ls_sql = ls_sql & "                        WHERE JDNNO = '" & Trim(ps_TRANO) & "'"
				ls_sql = ls_sql & "                          AND LINNO = '" & Trim(ps_LINNO) & "'"
				ls_sql = ls_sql & "                     GROUP BY JDNNO,LINNO) "
				ls_sql = ls_sql & "                      "
				ls_sql = ls_sql & "   AND DATKB  = '1' "
				ls_sql = ls_sql & "   AND FRDSU  <> 0 "
				ls_sql = ls_sql & "   AND PUDLNO = '" & Trim(ps_PUDLNO) & "'"
			Case "3" '�x��
				ls_sql = ls_sql & "  FROM SKYTBL"
				ls_sql = ls_sql & " WHERE DATKB  = '1' "
				ls_sql = ls_sql & "   AND SPRNOKDT  = '" & Trim(ps_TRADT) & "'"
				ls_sql = ls_sql & "   AND HINCD  = '" & Trim(ps_HINCD) & "'"
				ls_sql = ls_sql & "   AND SBNNO  = '" & Trim(ps_TRANO) & "'"
				ls_sql = ls_sql & "   AND PUDLNO = '" & Trim(ps_PUDLNO) & "'"
				ls_sql = ls_sql & "   AND SPRRENNO  = '" & Trim(ps_LINNO) & "'"
				ls_sql = ls_sql & "   AND PLANKB = '" & ps_MITNOV & "'"
				ls_sql = ls_sql & "   AND FRDSU  <> 0 "
				
			Case "4" '���ԏo��
				ls_sql = ls_sql & "  FROM SBNTRA "
				ls_sql = ls_sql & " WHERE SBNNO  = '" & Trim(ps_TRANO) & "'"
				ls_sql = ls_sql & "   AND HINCD  = '" & Trim(ps_HINCD) & "'"
				ls_sql = ls_sql & "   AND PUDLNO = '" & Trim(ps_PUDLNO) & "'"
				ls_sql = ls_sql & "   AND FRDSU  <> 0 "
				ls_sql = ls_sql & "   AND DATKB  = '1' "
				
			Case Else '���ϓ�
				'�폜�����Ȃ�(�S�폜)
				F_DEL_DTLTRA_CHK = 0
				Exit Function
				
		End Select
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lw_cnt = CF_Ora_GetDyn(Usr_Ody, "CNT", 0)
		'����
		
		If lw_cnt = 0 Then
			F_DEL_DTLTRA_CHK = 0
		Else
			F_DEL_DTLTRA_CHK = 1
		End If
		
F_DEL_DTLTRA_CHK_END: 
		On Error GoTo 0
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		Exit Function
		
F_DEL_DTLTRA_CHK_ERR: 
		F_DEL_DTLTRA_CHK = -1
		GoTo F_DEL_DTLTRA_CHK_END
		
	End Function
	'ADD  END  FKS)INABA 2009/09/30 **********************************************************************************************
	
	'======================= �ύX���� 2006.06.12 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Init_Clr_Dsp
	'   �T�v�F  �e��ʂ̍��ڂ�������
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
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
			If Wk_Mode = 0 Then
				'�{�f�B���ȍ~�̍��ڂ�S̫����Ȃ��Ƃ���
				If Index_Wk > pm_All.Dsp_Base.Head_Lst_Idx Then
					Call CF_Set_Item_Focus_Ctl(False, pm_All.Dsp_Sub_Inf(Index_Wk))
				End If
			End If
			
			'�r���������������������������������������������������������r
			'�ʏ�����
			Select Case Index_Wk
				Case Else
			End Select
			
			'�d���������������������������������������������������������d
			
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Init_Clr_Dsp_Body
	'   �T�v�F  �e��ʂ̃{�f�B���ڂ�������
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Clr_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		
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
		''        '�X�N���[��������
		''        '�ő�l
		''        Call CF_Set_VScrl_Max(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		''        '�ŏ��l
		''        Call CF_Set_VScrl_Min(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		''        '�ő彸۰ٗ�
		''        Call CF_Set_VScrl_LargeChange(pm_All.Dsp_Base.Dsp_Body_Cnt - 1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		''        '�ŏ���۰ٗ�
		''        Call CF_Set_VScrl_SmallChange(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		''        '�����l
		''        Call CF_Set_Item_Direct(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
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
		'        Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk))
		'
		'        '�S�̏������̏ꍇ
		'        If Wk_Mode = BODY_ALL_CLR Then
		'            '�S�s�������
		'            pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk).Status = BODY_ROW_STATE_DEFAULT
		'        End If
		'
		'        '�ʏ�����
		'''�r���������������������������������������������������������r
		''        '�ȉ��̺��۰ق͖��ו����̺��۰قł���΂Ȃ�ł��n�j�ł�
		''        '(�Ώۂ̖��ׂ̔ԍ���񂾂����K�v�A)
		''        Wk_Index = CInt(BD_LINNO(Index_Bd_Wk).Tag)
		'''�d���������������������������������������������������������d
		''        'Dsp_Body_Inf�̍s�m�n�ɕϊ�
		''        Wk_Row = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
		'''�r���������������������������������������������������������r
		''        'Dsp_Body_Inf�ɒl�������l��ݒ�
		''        Call F_Init_Dsp_Body(Wk_Row, pm_All)
		'''�d���������������������������������������������������������d
		'
		'    Next
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Init_Cursor_Set
	'   �T�v�F  ��ʏ�����Ԏ��̃t�H�[�J�X�ʒu�ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Cursor_Set(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		'�r���������������������������������������������������������r
		'�e��ʌʐݒ�(�K��DSP_SUB_INF.Detail.Focus_Ctl=True�̍��ځI�I)
		'�Č��h�c�Ƀt�H�[�J�X�ݒ�
		'�������ޯ���擾
		Trg_Index = CShort(FR_SSSMAIN.HD_HINCD.Tag)
		
		'̫����ړ�
		Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		'�I����Ԃ̐ݒ�i�����I���j
		Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
		'���ڐF�ݒ�
		Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
		
		'�d���������������������������������������������������������d
		
	End Function
	'======================= �ύX���� 2006.06.12 End =================================
	
	'======================= �ύX���� 2006.06.12 Start =================================
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
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
		End If
		
	End Function
	'======================= �ύX���� 2006.06.12 End =================================
	
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
					pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart + 1
					' === 20060823 === UPDATE E -
					'�ҏW���SelLength������
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
					
					' === 20060731 === INSERT S - ACE)Nagasawa �P�����ڂœ��͌�Ƀt�H�[�J�X�ړ����Ȃ����Ƃւ̑Ή�
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
							pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
							'�ҏW���SelLength������
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Dsp_Sub_Inf.Ctl.SelLength = 0
							'����̫����ʒu����E�ֈړ�
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						End If
					End If
					' === 20060731 === INSERT E
					
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
									pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
									'�ҏW���SelLength������
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
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
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'�ҏW���SelLength������
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						
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
								pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
								'�ҏW���SelLength������
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelLength = 1
								
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
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'�ҏW���SelLength������
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						
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
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
								'�ҏW���SelLength������
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
								
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
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						
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
				Wk_Index = CShort(FR_SSSMAIN.TX_CursorRest.Tag)
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
				' === 20060907 === INSERT S - ACE)Sejima
				bolSameCtl = True
				' === 20060907 === INSERT E
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
				FR_SSSMAIN.PopupMenu(FR_SSSMAIN.SM_ShortCut, vbPopupMenuLeftButton)
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
	'   ���́F  Function F_Init_Dsp_Body
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
		
		'�r���������������������������������������������������������r
		'�d���������������������������������������������������������d
		
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
	
	'�����̓R���g���[�����P�̂��߁A�s�v
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Next_Focus
	'   �T�v�F  ���̃t�H�[�J�X�ʒu�ݒ�(ENT�ARIGHT�Ȃ�)
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function F_Set_Next_Focus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Mode As Integer, ByRef pm_Move_Flg As Boolean, pm_All As Cls_All, Optional pm_Run_Flg As Boolean = True) As Integer
	'    Dim Sta_Index           As Integer
	'    Dim Index_Wk            As Integer
	'    Dim Rtn_Chk             As Integer
	'    Dim Bd_Index            As Integer
	'    Dim Focus_Ctl_Ok_Fst_Idx    As Integer
	'    Dim Focus_Ctl_Ok_Lst_Idx    As Integer
	'    Dim Focus_Ctl_Ok_Fst_Idx_Wk As Integer
	'    Dim Cur_Top_Index       As Integer
	'    Dim bolDsp              As Boolean
	'
	'    '�ړ��t���O������
	'    pm_Move_Flg = False
	'
	'    If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CInt(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
	'    '�{�f�B��
	'        'Dsp_Body_Inf�̍s�m�n���擾
	'        Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
	'
	'        If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW Then
	'        '�ŏI�����s�̏ꍇ
	'            '���͉\�ȍŏ��̃C���f�b�N�X���擾
	'            Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
	'
	'            If CInt(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Fst_Idx Then
	'            '���͉\�ȍŏ��̍��ڂ̏ꍇ
	'                '���[�h�ɂ�茟���J�n�ʒu������
	'                Select Case pm_Mode
	'                    Case NEXT_FOCUS_MODE_KEYRETURN
	'                    'KEYRETURN�̏ꍇ
	'                        '�����J�n�̓t�b�^���̍ŏ��̍��ڂ���
	'                        Sta_Index = pm_All.Dsp_Base.Foot_Fst_Idx
	'
	'                    Case NEXT_FOCUS_MODE_KEYRIGHT
	'                    'KEYRIGHT�̏ꍇ
	'                        '�������ޯ���擾
	'                        '�����J�n�͑Ώۂ̍��ڂ̎�
	'                        Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
	'
	'                End Select
	'            Else
	'                '�����J�n�͑Ώۂ̍��ڂ̎�
	'                Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
	'            End If
	'
	'        Else
	'        '�ŏI�����s�ȊO�̏ꍇ
	'            If pm_Dsp_Sub_Inf.Detail.Body_Index = pm_All.Dsp_Base.Dsp_Body_Cnt Then
	'            '�\������Ă���ŏI�s�̏ꍇ
	'                '���͉\�ȍŌ�̃C���f�b�N�X���擾
	'                Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
	'
	'                If CInt(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Lst_Idx Then
	'                '���͉\�ȍŌ�̍��ڂ̏ꍇ
	'                    If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
	'                    '�ŏI�����s�ȊO����ʏ�̍ŏI�s���ŏI����
	'                    '����ړ������ꍇ�A̫����ړ��\�ȍs�����飏ꍇ
	'
	'                        '��ʂ̓��e��ޔ�
	'                        Call CF_Body_Bkup(pm_All)
	'                        '�ړ��\�s����ԉ��ɕ\�������ꍇ�̍ŏ㖾�׃C���f�b�N�X��ݒ�
	'                        pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
	'                        If pm_All.Bd_Vs_Scrl Is Nothing = False Then
	'                            '�c�X�N���[���o�[��ݒ�
	'                            Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
	'                        End If
	'                        '��ʕ\��
	'                        Call CF_Body_Dsp(pm_All)
	'
	'                        '���ׂP�ԉ��s�̓��͉\�ȍŏ��̃C���f�b�N�X���擾
	'                        Focus_Ctl_Ok_Fst_Idx_Wk = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
	'                        If Focus_Ctl_Ok_Fst_Idx_Wk > 0 Then
	'                            '���ׂP�ԉ��s�̍ŏ��̍��ڂ̈�O���猟��
	'                            Sta_Index = Focus_Ctl_Ok_Fst_Idx_Wk - 1
	'                        Else
	'                            '�����J�n�͑Ώۂ̍��ڂ̎�
	'                            Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
	'                        End If
	'
	'                     Else
	'                    '����ړ������ꍇ�A̫����ړ��\�ȍs���Ȃ���ꍇ
	'                        '�����J�n�͑Ώۂ̍��ڂ̎�
	'                        Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
	'                     End If
	'                Else
	'                '���͉\�ȍŌ�̍��ڈȊO�̏ꍇ
	'                    '�����J�n�͑Ώۂ̍��ڂ̎�
	'                    Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
	'                End If
	'
	'            Else
	'            '�ŏI�s�ȊO�ꍇ
	'                '�����J�n�͑Ώۂ̍��ڂ̎�
	'                Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
	'            End If
	'        End If
	'
	'    Else
	'    '�{�f�B���ȊO
	'        '�����J�n�͑Ώۂ̍��ڂ̎�
	'        Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
	'    End If
	'
	'    bolDsp = False
	'    '���̍��ڂ�����
	'    For Index_Wk = Sta_Index To pm_All.Dsp_Base.Item_Cnt
	'
	'        If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD _
	''        And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
	'            'ͯ�ޕ�����
	'            Rtn_Chk = F_Ctl_Head_Chk(pm_All)
	'            If Rtn_Chk = CHK_OK Then
	'                '�`�F�b�NOK�̏ꍇ
	''                If bolDsp = False Then
	''                    '�X�V����
	''                    Rtn_Chk = F_DSP_BD_Inf(pm_Dsp_Sub_Inf, DSP_SET, pm_All)
	''                    If Rtn_Chk <> CHK_OK Then
	''                        '�f�[�^�Ȃ��̏ꍇ
	''                        Exit For
	''                    End If
	''                    '�y�����Ӂ��z�����ɁA���ޯ�����t�b�^���̓��ɃW�����v�����Ă���B
	''                    '���[�v�񐔌��̂��߁B���ׂɓ��͍��ڂ��Ȃ�����\�B
	''                    Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx
	''
	''                    bolDsp = True
	''                End If
	'
	'            Else
	'                '�`�F�b�N�m�f�̏ꍇ
	'                Exit For
	'            End If
	'        End If
	'
	'        '̫����ړ���OK
	'        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
	'            If pm_Run_Flg = True Then
	'            '���s�w�肪����ꍇ(��{����)
	'                '̫����ړ�
	'                Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
	'            End If
	'            '�ړ��t���O����
	'            pm_Move_Flg = True
	'            Exit For
	'        End If
	'
	'    Next
	'
	'    '�ŏI���ڂ܂Ō����I����
	'    If Index_Wk > pm_All.Dsp_Base.Item_Cnt Then
	'        '���[�h�ɂ�茟���I����̏���������
	'        Select Case pm_Mode
	'            Case NEXT_FOCUS_MODE_KEYRETURN
	'            'KEYRETURN�̏ꍇ
	''�r���������������������������������������������������������r
	'                '�ړ��悪�����s�̏ꍇ
	'                '�X�V�O�`�F�b�N�˂c�a�X�V�ˏ�����
	'                Call F_Ctl_Upd_Process(pm_All)
	''�d���������������������������������������������������������d
	'                pm_Move_Flg = True
	'            Case NEXT_FOCUS_MODE_KEYRIGHT
	'            'KEYRIGHT�̏ꍇ
	'        End Select
	'    End If
	'
	'End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Left_Next_Focus
	'   �T�v�F  Left�������̃t�H�[�J�X�ʒu�ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Left_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
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
			Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
			Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
					'�l���������l�̏ꍇ
					'�P�����ڂ�I������
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.SelStart = 0
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.SelLength = 1
				Else
					'�l���������l�ȊO�̏ꍇ
					'�P�O�̍��ڂ�
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
					
				End If
			Else
				If Act_SelStart = 0 Then
					'�J�n�ʒu����ԍ��̏ꍇ
					'�P�O�̍��ڂ�
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
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
						Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
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
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
					End If
					
				End If
			End If
		Else
			'���݂̺��۰ق�÷���ޯ���̈ȊO�ꍇ
			'�P�O�̍��ڂ�
			Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
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
			Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
			Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
					'�l���������l�̏ꍇ
					'�ŏI������I������
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.SelLength = 1
				Else
					'�l���������l�ȊO�̏ꍇ
					'�P���ڂ�I������
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.SelStart = 1
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.SelLength = 1
				End If
			Else
				If Act_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Then
					'�I���J�n�ʒu����ԉE�̏ꍇ
					'�����̓R���g���[�����P�̂��߁A�s�v
					'                'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
					'                Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
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
							pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Dsp_Sub_Inf.Ctl.SelLength = 0
						Else
							'�l���������l�ȊO�̏ꍇ
							If Act_SelLength = 0 Then
								'�ړ��O�̑I�𕶎������Ȃ��ꍇ
								'��ԉE�ֈړ����I���Ȃ���Ԃ�
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelLength = 0
							Else
								'�����̓R���g���[�����P�̂��߁A�s�v
								'                            'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
								'                            Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
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
							'�����̓R���g���[�����P�̂��߁A�s�v
							'                        'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
							'                        Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
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
							pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						End If
					End If
				End If
				
			End If
		Else
			'���݂̺��۰ق�÷���ޯ���̈ȊO�ꍇ
			'�����̓R���g���[�����P�̂��߁A�s�v
			'        'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
			'        Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
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
					'�����̓R���g���[�����P�̂��߁A�s�v
					'                'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
					'                Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
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
								'�����̓R���g���[�����P�̂��߁A�s�v
								'                            '���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
								'                            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						Else
							'���͉\�ȍŏ��̃C���f�b�N�X���擾
							Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
							If Focus_Ctl_Ok_Fst_Idx > 0 Then
								'�����̓R���g���[�����P�̂��߁A�s�v
								'                            '���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
								'                            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
								Exit Do
							Else
								'�t�b�^���̍ŏ��̍��ڂ̂P�O����
								'�����̓R���g���[�����P�̂��߁A�s�v
								'                            'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
								'                            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						End If
						
					Else
						'����ړ������ꍇ�A̫����ړ��\�ȍs���Ȃ���ꍇ
						'�t�b�^���̍ŏ��̍��ڂ̂P�O����
						'�����̓R���g���[�����P�̂��߁A�s�v
						'                    'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
						'                    Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
						Exit Do
					End If
				End If
			Loop 
			
		Else
			'���ו��ȊO�̏ꍇ
			'�����̓R���g���[�����P�̂��߁A�s�v
			'        'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
			'        Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
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
	
	'======================= �ύX���� 2006.06.12 Start =================================
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
			Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP
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
	'======================= �ύX���� 2006.06.12 End =================================
	
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
				Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP
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
		
		Call DB_HINMTA_Clear(Mst_Inf)
		
		'�����̓`�F�b�N
		If CF_Trim_Item((pm_Chk_Dsp_Sub_Inf.Ctl.Text), pm_Chk_Dsp_Sub_Inf) = "" Then
			'�����͈ȊO�̃`�F�b�N�ς��ǂ����̍l���͍���s�v
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			Retn_Code = CHK_ERR_NOT_INPUT
			Err_Cd = gc_strMsgHIKFP52_A_COMPLETEC
			UODDL52_HINMTA_Inf.DATKB = Mst_Inf_Clr.DATKB
			UODDL52_HINMTA_Inf.HINCD = Mst_Inf_Clr.HINCD '���i�R�[�h0          000000
			UODDL52_HINMTA_Inf.HINNMA = Mst_Inf_Clr.HINNMA '�^��
			UODDL52_HINMTA_Inf.HINNMB = Mst_Inf_Clr.HINNMB '�i��
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base((pm_Chk_Dsp_Sub_Inf.Ctl.Text), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgHIKFP52_E_INPUTERR
			Else
				'�}�X�^�`�F�b�N
				If DSPHINCD_SEARCH(Input_Value, Mst_Inf) = 0 Then
					'�_���폜�`�F�b�N
					' === 20060921 === UPDATE S - ACE)Nagasawa �����s�ł��G���[�Ƃ��Ȃ�
					'                If Mst_Inf.DATKB = gc_strDATKB_DEL Or Mst_Inf.DSPKB = gc_strDSPKB_NG Then
					If Mst_Inf.DATKB = gc_strDATKB_DEL Then
						' === 20060921 === UPDATE E -
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgHIKFP52_E_DELDATA
					End If
					
					' === 20060921 === DELETE S - ACE)Nagasawa �����s�ł��G���[�Ƃ��Ȃ�
					'                '�����s�f�[�^�`�F�b�N
					'                If Mst_Inf.DSPKB = gc_strDSPKB_NG Then
					'                    Retn_Code = CHK_ERR_ELSE
					'                    Err_Cd = gc_strMsgHIKFP52_E_011
					'                End If
					' === 20060921 === DELETE E -
					
					'�݌ɊǗ��敪�`�F�b�N
					If Err_Cd = "" And Mst_Inf.ZAIKB = gc_strZAIKB_NG Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgHIKFP52_Q_ZAIKBNG
					End If
					
					'���i��ʃ`�F�b�N
					If Err_Cd = "" And Mst_Inf.HINID > gc_strHINID_SETUP Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgHIKFP52_E_NOTSEIHIN
					End If
					
					'�`�F�b�N�n�j
					If Err_Cd = "" Then
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						UODDL52_HINMTA_Inf.DATKB = Mst_Inf.DATKB
						UODDL52_HINMTA_Inf.HINCD = Mst_Inf.HINCD '���i�R�[�h0          000000
						UODDL52_HINMTA_Inf.HINNMA = Mst_Inf.HINNMA '�^��
						UODDL52_HINMTA_Inf.HINNMB = Mst_Inf.HINNMB '�i��
					End If
					
				Else
					'�Y���f�[�^����
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgHIKFP52_E_NODATA01
					
				End If
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
		
		F_Chk_HD_HINCD = Retn_Code
		
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
			Case FR_SSSMAIN.HD_HINCD.Name
				'���i�R�[�h�ɂ���ʕ\��
				Call F_Dsp_HD_HINCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
				'�d���������������������������������������������������������d
				
		End Select
		
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
			If pm_Dsp_Sub_Inf.Ctl.Text <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'�r���������������������������������������������������������r
				'�y�^���z
				Trg_Index = CShort(FR_SSSMAIN.HD_HINNMA.Tag)
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(UODDL52_HINMTA_Inf.HINNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'�y�i���z
				Trg_Index = CShort(FR_SSSMAIN.HD_HINNMB.Tag)
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(UODDL52_HINMTA_Inf.HINNMB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
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
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = pm_Dsp_Sub_Inf.Ctl.Text
		
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
			Case FR_SSSMAIN.HD_HINCD.Name
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���i�R�[�h������
				Rtn_Chk = F_Chk_HD_HINCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
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
		'======================= �ύX���� 2006.06.12 Start =================================
		Dim Dsp_Mode As Short
		'======================= �ύX���� 2006.06.12 End =================================
		Dim strUDNYTDTFM As String
		Dim strUDNYTDTTO As String
		Dim strDEFNOKDTFM As String
		Dim strDEFNOKDTTO As String
		Dim strJDNTRKB As String
		Dim intHSYYT As Short
		Dim Err_Cd As String
		Dim Err_Index As Short
		Dim Chk_Move As Boolean
		Dim Msg_Flg As Boolean
		Dim Trg_Index As Short
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_OK
		
		'�{�f�B���̍ŏI���ڂ܂Ŋe���ڂ��������s��
		For Index_Wk = 1 To pm_All.Dsp_Base.Head_Lst_Idx
			
			'�e����������S�������Ƃ��Čďo
			Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Index_Wk), CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
			
			'======================= �ύX���� 2006.06.12 Start =================================
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
			'======================= �ύX���� 2006.06.12 End =================================
			
			'�`�F�b�N�m�f
			If Rtn_Chk <> CHK_OK Then
				'�i�W���̓����j
				'            '������ړ��Ȃ�
				'            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				
				'�i�����ă{�c�j
				''            If Rtn_Chk <> CHK_OK _
				'''            Or pm_All.Dsp_Base.Head_Ok_Flg <> False Then
				''                '�`�F�b�N�n�j�łȂ��A����
				''                '�w�b�_���̃`�F�b�N�����߂ĂłȂ��ꍇ
				''                '�t�b�^�����J������
				''                '�i���R���g���[�����ЂƂ����Ȃ��{��ʂ̂悤�ȏꍇ�̓��ʂȑ[�u�j
				''                Call F_Foot_In_Ready(pm_All)
				''                '�`�F�b�N�n�j
				''                pm_All.Dsp_Base.Head_Ok_Flg = True
				''            End If
				'�_�~�[�R���g���[���ֈړ�
				Trg_Index = CShort(FR_SSSMAIN.TX_Dummy.Tag)
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				F_Ctl_Head_Chk = Rtn_Chk
				Exit Function
			End If
			
		Next 
		
		'�֘A����
		'�r���������������������������������������������������������r
		Err_Cd = ""
		Err_Index = 0
		
		'�֘A�`�F�b�N�G���[����
		If Err_Cd <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			'�t�H�[�J�X�ړ�
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Err_Index), pm_All)
			
			'�������ʂ́u�G���[�v
			Rtn_Chk = CHK_ERR_ELSE
		End If
		
		'�d���������������������������������������������������������d
		
		'    If Rtn_Chk = CHK_OK _
		''    And pm_All.Dsp_Base.Head_Ok_Flg = False Then
		'        '�`�F�b�N�n�j�ł���
		'        '�w�b�_���̃`�F�b�N�����߂Ă̏ꍇ
		'        '�P�s�ڂ̃{�f�B���������ŏI�s�Ƃ��ĊJ������
		'        pm_All.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW
		'        '�t�b�^�����J������
		'        Call F_Foot_In_Ready(pm_All)
		'        '�`�F�b�N�n�j
		'        pm_All.Dsp_Base.Head_Ok_Flg = True
		'    End If
		
		F_Ctl_Head_Chk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Foot_In_Ready
	'   �T�v�F  �t�b�^���̓��͏���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Foot_In_Ready(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		
		'�t�b�^�����ŏ���
		For Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx To pm_All.Dsp_Base.Item_Cnt
			Select Case pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name
				'�r���������������������������������������������������������r
				Case FR_SSSMAIN.TX_Dummy.Name
					'�d���������������������������������������������������������d
					'������Ԃœ��͉\�Ⱥ��۰�
					'���͉\
					Call CF_Set_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Index_Wk))
			End Select
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_First_Day
	'   �T�v�F  �������擾
	'   �����F�@pm_strYYYYMM          :�N���iYYYYMM�j
	'   �ߒl�F�@�������iYYYYMMDD�j
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_First_Day(ByRef pm_strYYYYMM As String) As String
		
		Dim Ret_Value As String
		Dim strWk As String
		Dim strWk2 As String
		
		Ret_Value = ""
		
		strWk = pm_strYYYYMM & "01"
		strWk2 = VB6.Format(strWk, "@@@@/@@/@@")
		
		'���t�Ƃ��Đ�������΁A�l��Ԃ�
		If IsDate(strWk2) = True Then
			Ret_Value = strWk
		End If
		
		CF_Get_First_Day = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_Last_Day
	'   �T�v�F  �������擾
	'   �����F�@pm_strYYYYMM          :�N���iYYYYMM�j
	'   �ߒl�F�@�������iYYYYMMDD�j
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_Last_Day(ByRef pm_strYYYYMM As String) As String
		
		Dim Ret_Value As String
		Dim strWk As String
		Dim strWk2 As String
		
		Ret_Value = ""
		
		strWk = pm_strYYYYMM & "01"
		strWk2 = VB6.Format(strWk, "@@@@/@@/@@")
		
		'���t�Ƃ��Đ�������΁A���������Z�o�A�l��Ԃ�
		If IsDate(strWk2) = True Then
			'���������́A�P������́A�P���O
			strWk = VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, CDate(strWk2))), "yyyymmdd")
			Ret_Value = strWk
		End If
		
		CF_Get_Last_Day = Ret_Value
		
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
		
		F_Set_Inp_Item_Focus_Ctl = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS
	'   �T�v�F  ������ʕ\��
	'   �����F�@pm_All          :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  ������ʕ\���C���[�W���N���b�N�����ۂ̏���
	'           �t�H�[�J�X�͓��̓R���g���[���ɂ���܂܂̏��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS(ByRef pm_All As Cls_All) As Short
		
		Dim Cursor_Index As Short
		Dim Trg_Index As Short
		
		'���݂̃t�H�[�J�X�擾�R���g���[���̃C���f�b�N�X
		Cursor_Index = pm_All.Dsp_Base.Cursor_Idx
		
		Select Case Cursor_Index
			Case CShort(FR_SSSMAIN.HD_HINCD.Tag)
				'���i
				'            Trg_Index = CInt(FR_SSSMAIN.CS_HINCD.Tag)
				'            Call F_Ctl_CS_HINCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				Call F_Ctl_CS_HINCD(pm_All)
				
		End Select
		
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
			
			' === 20060802 === INSERT S - ACE)Nagasawa
			gv_bolHIKFP52_LF_Enable = False
			' === 20060802 === INSERT E -
			
			' === 20060907 === INSERT S - ACE)Hashiri �����i���܂߂Č���
			WLSHIN_KHNSEARCH = "1"
			' === 20060907 === INSERT E -
			
			'======================= �ύX���� 2006.06.12 Start =================================
			'Windows�ɏ�����Ԃ�
			System.Windows.Forms.Application.DoEvents()
			'======================= �ύX���� 2006.06.12 End =================================
			
			'���i������ʂ��Ăяo��
			WLSHIN.ShowDialog()
			' === 20060802 === INSERT S - ACE)Nagasawa
			WLSHIN.Close()
			
			gv_bolHIKFP52_LF_Enable = True
			' === 20060802 === INSERT E -
			
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
	'   ���́F  Function F_Ctl_WLS_Close
	'   �T�v�F  �e������ʃN���[�Y����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_WLS_Close() As Short
		
		F_Ctl_WLS_Close = 9
		
		'���i
		WLSHIN.Close()
		'UPGRADE_NOTE: �I�u�W�F�N�g WLSHIN ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		WLSHIN = Nothing
		
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
		Select Case pm_All.Dsp_Base.Cursor_Idx
			Case CShort(FR_SSSMAIN.HD_HINCD.Tag)
				'�o�^
				Trg_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'�폜�i�g�p�s�I�I�j
				Trg_Index = CShort(FR_SSSMAIN.MN_DeleteCM.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'��ʈ��
				Trg_Index = CShort(FR_SSSMAIN.MN_HARDCOPY.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'�I��
				Trg_Index = CShort(FR_SSSMAIN.MN_EndCm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				
				'��ʏ�����
				Trg_Index = CShort(FR_SSSMAIN.MN_APPENDC.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'���ڏ�����
				Trg_Index = CShort(FR_SSSMAIN.MN_ClearItm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'���ڕ���
				Trg_Index = CShort(FR_SSSMAIN.MN_UnDoItem.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'���׍s������
				Trg_Index = CShort(FR_SSSMAIN.MN_ClearDE.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'���׍s�폜
				Trg_Index = CShort(FR_SSSMAIN.MN_DeleteDE.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'���׍s�}��
				Trg_Index = CShort(FR_SSSMAIN.MN_InsertDE.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'���׍s����
				Trg_Index = CShort(FR_SSSMAIN.MN_UnDoDe.Tag)
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
				
				'���̈ꗗ
				Trg_Index = CShort(FR_SSSMAIN.MN_Slist.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				
			Case Else
				'�o�^
				Trg_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'�폜�i�g�p�s�I�I�j
				Trg_Index = CShort(FR_SSSMAIN.MN_DeleteCM.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'��ʈ��
				Trg_Index = CShort(FR_SSSMAIN.MN_HARDCOPY.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'�I��
				Trg_Index = CShort(FR_SSSMAIN.MN_EndCm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				
				'��ʏ�����
				Trg_Index = CShort(FR_SSSMAIN.MN_APPENDC.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'���ڏ�����
				Trg_Index = CShort(FR_SSSMAIN.MN_ClearItm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'���ڕ���
				Trg_Index = CShort(FR_SSSMAIN.MN_UnDoItem.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'���׍s������
				Trg_Index = CShort(FR_SSSMAIN.MN_ClearDE.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'���׍s�폜
				Trg_Index = CShort(FR_SSSMAIN.MN_DeleteDE.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'���׍s�}��
				Trg_Index = CShort(FR_SSSMAIN.MN_InsertDE.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'���׍s����
				Trg_Index = CShort(FR_SSSMAIN.MN_UnDoDe.Tag)
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
				
				'���̈ꗗ
				Trg_Index = CShort(FR_SSSMAIN.MN_Slist.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				
		End Select
		
		'���j���[�{�^���C���[�W�̉�����
		'�I���{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_EndCm.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_EndCm.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'�o�^�{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_Execute.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'������ʕ\���{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_Slist.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_Slist.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		
		F_Ctl_MN_Enabled = 0
		
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
		Dim Trg_Index As Short
		Dim strHINCD As String
		' === 20061105 === INSERT S - ACE)Nagasawa �r������̒ǉ�
		Dim strMsg As String
		' === 20061105 === INSERT E -
		
		F_Ctl_Upd_Process = 9
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		
		'�w�b�_���̃`�F�b�N
		intRet = F_Ctl_Head_Chk(pm_All)
		If intRet <> CHK_OK Then
			'�`�F�b�N�m�f�̏ꍇ
			' === 20060915 === UPDATE S - ACE)Nagasawa
			'        Exit Function
			GoTo End_F_Ctl_Upd_Process
			' === 20060915 === UPDATE E -
		End If
		
		'    '�{�f�B���̃`�F�b�N
		'    intRet = F_Ctl_Body_Chk(pm_All)
		'    If intRet <> CHK_OK Then
		'    '�`�F�b�N�m�f�̏ꍇ
		'        Exit Function
		'    End If
		'
		'    '�e�C�����̃`�F�b�N
		'    intRet = F_Ctl_Tail_Chk(pm_All)
		'    If intRet <> CHK_OK Then
		'    '�`�F�b�N�m�f�̏ꍇ
		'        Exit Function
		'    End If
		
		'Windows�ɏ�����Ԃ�
		System.Windows.Forms.Application.DoEvents()
		
		If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_Q_RUN, pm_All) = MsgBoxResult.Yes Then
			
			' === 20061129 === INSERT S - ACE)Nagasawa �X�V�����`�F�b�N��ύX����
			'�X�V�������Ȃ��ꍇ�͏������s��Ȃ�
			If Inp_Inf.InpJDNUPDKB <> gc_strJDNUPDKB_OK Then
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_013, pm_All)
				GoTo End_F_Ctl_Upd_Process
			End If
			' === 20061129 === INSERT E -
			
			' === 20061105 === INSERT S - ACE)Nagasawa
			'�r���`�F�b�N���s��
			Select Case CF_Chk_Lock_EXCTBZ(strMsg)
				'����
				Case 0
					
					'�r��������
				Case 1
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_012, pm_All, "", strMsg)
					GoTo End_F_Ctl_Upd_Process
					
					'�ُ�I��
				Case 9
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All)
					GoTo End_F_Ctl_Upd_Process
					
			End Select
			' === 20061105 === INSERT E -
			
			'����̫����ʒu�ݒ�
			Call F_Init_Cursor_Set(pm_All)
			
			'�{�^����\��
			FR_SSSMAIN.CM_Execute.Visible = False
			
			'�o�^����
			Trg_Index = CShort(FR_SSSMAIN.HD_HINCD.Tag)
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strHINCD = CStr(pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Dsp_Value)
			intRet = F_Update_Main(strHINCD, pm_All)
			If intRet <> 0 Then
				GoTo Err_F_Ctl_Upd_Process
				
			Else
				' === 20061105 === INSERT S - ACE)Nagasawa �r������̒ǉ�
				'�r������
				Call CF_Unlock_EXCTBZ(strMsg)
				' === 20061105 === INSERT E -
				
				'�X�V�������b�Z�[�W�\��
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_A_UPDATEOK, pm_All)
				
			End If
			
		End If
		
		F_Ctl_Upd_Process = 0
		
End_F_Ctl_Upd_Process: 
		' === 20061105 === INSERT S - ACE)Nagasawa �r������̒ǉ�
		'�r������
		Call CF_Unlock_EXCTBZ(strMsg)
		' === 20061105 === INSERT E -
		'�{�^���\��
		FR_SSSMAIN.CM_Execute.Visible = True
		' === 20060915 === INSERT S - ACE)Nagasawa  �G���^�[�L�[�A�łɂ��s��C��
		'�L�[�t���O�����ɖ߂�
		gv_bolKeyFlg = False
		' === 20060915 === INSERT E -
		Exit Function
		
Err_F_Ctl_Upd_Process: 
		GoTo End_F_Ctl_Upd_Process
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Update_Main
	'   �T�v�F  �X�V���C������
	'   �����F  pm_HINCD      : ���i�R�[�h
	'           pm_All        : ��ʏ��
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Update_Main(ByRef pm_HINCD As String, ByRef pm_All As Cls_All) As Short
		
		Dim bolRet As Boolean
		Dim intRet As Short
		Dim bolTran As Boolean
		Dim strDate As String
		Dim strTime As String
		
		On Error GoTo F_Update_Main_err
		
		'�����v�ɂ���
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		F_Update_Main = 9
		bolTran = False
		
		'�r�����������������ۗ�����������
		
		'�g�����U�N�V�����̊J�n
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		'���t�E�������擾
		strDate = VB6.Format(Now, "yyyyMMdd")
		strTime = VB6.Format(Now, "hhmmss")
		
		'���σg�����X�V
		intRet = F_MITTRA_Update(pm_HINCD, strDate, strTime, pm_All)
		If intRet <> 0 Then
			GoTo F_Update_Main_err
		End If
		
		'�󒍃g�����X�V
		intRet = F_JDNTRA_Update(pm_HINCD, strDate, strTime, pm_All)
		If intRet <> 0 Then
			GoTo F_Update_Main_err
		End If
		
		'���ԏo�Ƀt�@�C���X�V
		intRet = F_SBNTRA_Update(pm_HINCD, strDate, strTime, pm_All)
		If intRet <> 0 Then
			GoTo F_Update_Main_err
		End If
		
		'�q�ɕʍ݌Ƀ}�X�^�X�V
		intRet = F_HINMTB_Update(pm_HINCD, strDate, strTime, pm_All)
		If intRet <> 0 Then
			GoTo F_Update_Main_err
		End If
		
		'���ɗ\��t�@�C���X�V
		intRet = F_INPTRA_Update(pm_HINCD, strDate, strTime, pm_All)
		If intRet <> 0 Then
			GoTo F_Update_Main_err
		End If
		
		'�x���i�\��t�@�C���X�V
		intRet = F_SKYTBL_Update(pm_HINCD, strDate, strTime, pm_All)
		If intRet <> 0 Then
			GoTo F_Update_Main_err
		End If
		
		'���i�t�@�C���X�V
		intRet = F_STOTRA_Update(pm_HINCD, strDate, strTime, pm_All)
		If intRet <> 0 Then
			GoTo F_Update_Main_err
		End If
		
		'��������t�@�C���X�V
		intRet = F_DTLTRA_Update(pm_HINCD, strDate, strTime, pm_All)
		If intRet <> 0 Then
			GoTo F_Update_Main_err
		End If
		
		'�R�~�b�g
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		F_Update_Main = 0
		
F_Update_Main_End: 
		'�����v��߂�
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		Exit Function
		
F_Update_Main_err: 
		
		If bolTran = True Then
			'���[���o�b�N
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo F_Update_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_MITTRA_Update
	'   �T�v�F  ���σg�����X�V����
	'   �����F  pm_HINCD      : ���i�R�[�h
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_MITTRA_Update(ByRef pm_HINCD As String, ByRef pm_Date As String, ByRef pm_Time As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		F_MITTRA_Update = 9
		
		On Error GoTo F_MITTRA_Update_err
		
		strSQL = ""
		strSQL = strSQL & " Update MITTRA"
		strSQL = strSQL & " Set"
		strSQL = strSQL & "     ZAIHIKSU = 0"
		strSQL = strSQL & "    ,NYTHIKSU = 0"
		' === 20061119 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "    ,CLTID = '" & CF_Ora_String(SSS_CLTID, 5) & "'"
		'   strSQL = strSQL & "    ,WRTTM = '" & pm_Time & "'"
		'   strSQL = strSQL & "    ,WRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSQL = strSQL & "    ,UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "    ,UWRTTM = '" & pm_Time & "'"
		strSQL = strSQL & "    ,UWRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,PGID   = '" & CF_Ora_String(SSS_PrgId, 7) & "'"
		' === 20061119 === UPDATE E -
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     DATKB = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " And KHIKKB = '1'"
		strSQL = strSQL & " And HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_MITTRA_Update_err
		End If
		
		F_MITTRA_Update = 0
		
F_MITTRA_Update_End: 
		Exit Function
		
F_MITTRA_Update_err: 
		'�G���[���b�Z�[�W
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All, "F_MITTRA_Update")
		
		GoTo F_MITTRA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_JDNTRA_Update
	'   �T�v�F  �󒍃g�����X�V����
	'   �����F  pm_HINCD      : ���i�R�[�h
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_JDNTRA_Update(ByRef pm_HINCD As String, ByRef pm_Date As String, ByRef pm_Time As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		F_JDNTRA_Update = 9
		
		On Error GoTo F_JDNTRA_Update_err
		
		strSQL = ""
		' === 20060907 === UPDATE S - ACE)Hashiri �ԍ��Ή�(JDNTRV�ɕύX)
		' === 20061107 === UPDATE S - ACE)Yano    View���ð��ق���̍X�V�ɖ߂�
		''strSQL = strSQL & " Update JDNTRA"
		''strSQL = strSQL & " Update JDNTRV"
		strSQL = strSQL & " Update JDNTRA TRA"
		' === 20061107 === UPDATE E -
		' === 20060907 === UPDATE E -
		strSQL = strSQL & " Set"
		strSQL = strSQL & "     ATZHIKSU = 0"
		strSQL = strSQL & "    ,ATNHIKSU = 0"
		strSQL = strSQL & "    ,MNZHIKSU = 0"
		strSQL = strSQL & "    ,MNNHIKSU = 0"
		' === 20061119 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "    ,CLTID = '" & CF_Ora_String(SSS_CLTID, 5) & "'"
		'   strSQL = strSQL & "    ,WRTTM = '" & pm_Time & "'"
		'   strSQL = strSQL & "    ,WRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSQL = strSQL & "    ,UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "    ,UWRTTM = '" & pm_Time & "'"
		strSQL = strSQL & "    ,UWRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,PGID   = '" & CF_Ora_String(SSS_PrgId, 7) & "'"
		' === 20061119 === UPDATE E -
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     DATKB    = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " And HINCD    = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		
		' === 20061107 === UPDATE S - ACE)Yano    View���ð��ق���̍X�V�ɖ߂�
		strSQL = strSQL & " And AKAKROKB = '1' "
		strSQL = strSQL & " And DATNO    = ( Select Max(DATNO) DATNO "
		strSQL = strSQL & "                    From JDNTRA TRB "
		strSQL = strSQL & "                 Where   TRB.DATKB = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & "                   And   TRB.HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		strSQL = strSQL & "                   And   TRB.JDNNO = TRA.JDNNO "
		strSQL = strSQL & "                   And   TRB.LINNO = TRA.LINNO "
		strSQL = strSQL & "                Group By JDNNO "
		strSQL = strSQL & "                       , LINNO "
		strSQL = strSQL & "                ) "
		' === 20061107 === UPDATE E -
		
		'���ׂďo�ɍς݂̏ꍇ�͑ΏۂƂ��Ȃ�
		strSQL = strSQL & " And UODSU > OTPSU"
		'ADD START FKS)INABA 2009/09/30 ***************************************
		'�A���[��FC09100103
		strSQL = strSQL & " And FRDSU = 0"
		'ADD  END  FKS)IABA  2009/09/30 ***************************************
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_JDNTRA_Update_err
		End If
		
		F_JDNTRA_Update = 0
		
F_JDNTRA_Update_End: 
		Exit Function
		
F_JDNTRA_Update_err: 
		'�G���[���b�Z�[�W
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All, "F_JDNTRA_Update")
		
		GoTo F_JDNTRA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_SBNTRA_Update
	'   �T�v�F  ���ԏo�Ƀt�@�C���X�V����
	'   �����F  pm_HINCD      : ���i�R�[�h
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SBNTRA_Update(ByRef pm_HINCD As String, ByRef pm_Date As String, ByRef pm_Time As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		F_SBNTRA_Update = 9
		
		On Error GoTo F_SBNTRA_Update_err
		
		strSQL = ""
		strSQL = strSQL & " Update SBNTRA"
		strSQL = strSQL & " Set"
		strSQL = strSQL & "     HIKSMSU = 0"
		' === 20061119 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "    ,CLTID = '" & CF_Ora_String(SSS_CLTID, 5) & "'"
		'   strSQL = strSQL & "    ,WRTTM = '" & pm_Time & "'"
		'   strSQL = strSQL & "    ,WRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSQL = strSQL & "    ,UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "    ,UWRTTM = '" & pm_Time & "'"
		strSQL = strSQL & "    ,UWRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,PGID   = '" & CF_Ora_String(SSS_PrgId, 7) & "'"
		' === 20061119 === UPDATE E -
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     DATKB = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " And HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		strSQL = strSQL & " And FRDYTSU > OUTSMSU"
		'ADD START FKS)INABA 2009/09/30 ************************************
		'�A���[��FC09100103
		strSQL = strSQL & " And FRDSU = 0"
		'ADD  END  FKS)INABA 2009/09/30 ************************************
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_SBNTRA_Update_err
		End If
		
		F_SBNTRA_Update = 0
		
F_SBNTRA_Update_End: 
		Exit Function
		
F_SBNTRA_Update_err: 
		'�G���[���b�Z�[�W
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All, "F_SBNTRA_Update")
		
		GoTo F_SBNTRA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_HINMTB_Update
	'   �T�v�F  �q�ɕʍ݌Ƀ}�X�^�X�V����
	'   �����F  pm_HINCD      : ���i�R�[�h
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_HINMTB_Update(ByRef pm_HINCD As String, ByRef pm_Date As String, ByRef pm_Time As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		F_HINMTB_Update = 9
		
		On Error GoTo F_HINMTB_Update_err
		
		strSQL = ""
		strSQL = strSQL & " Update HINMTB"
		strSQL = strSQL & " Set"
		' === 20070919 === UPDATE S - ACE)Nagasawa �q�ɕʍ݌Ƀ}�X�^�̈������N���A���A�o�׎w���������L�[�v����
		'strSQL = strSQL & "     HIKSU = 0"
		strSQL = strSQL & "     HIKSU = (SELECT NVL(FRDSU, 0) "
		strSQL = strSQL & "                FROM (" & F_FRDSU_Select(pm_HINCD, pm_All) & ") SUB_FRDSU "
		strSQL = strSQL & "               WHERE HINMTB.SOUCD = SUB_FRDSU.SOUCD (+) "
		strSQL = strSQL & "                 AND HINMTB.HINCD = SUB_FRDSU.HINCD (+) )"
		' === 20070919 === UPDATE E -
		' === 20061119 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "    ,CLTID = '" & CF_Ora_String(SSS_CLTID, 5) & "'"
		'   strSQL = strSQL & "    ,WRTTM = '" & pm_Time & "'"
		'   strSQL = strSQL & "    ,WRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSQL = strSQL & "    ,UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "    ,UWRTTM = '" & pm_Time & "'"
		strSQL = strSQL & "    ,UWRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,PGID   = '" & CF_Ora_String(SSS_PrgId, 7) & "'"
		' === 20061119 === UPDATE E -
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     DATKB = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " And HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		' === 20070919 === INSERT S - ACE)Nagasawa �����Ώۂ������Ώۋ敪="1"�i�Ώ�)�̑q�ɂ݂̂Ƃ���
		strSQL = strSQL & " And HIKKB = '" & CF_Ora_Sgl(gc_strHIKKB_OK) & "'"
		' === 20070919 === INSERT E -
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_HINMTB_Update_err
		End If
		
		F_HINMTB_Update = 0
		
F_HINMTB_Update_End: 
		Exit Function
		
F_HINMTB_Update_err: 
		'�G���[���b�Z�[�W
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All, "F_HINMTB_Update")
		
		GoTo F_HINMTB_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_INPTRA_Update
	'   �T�v�F  ���ɗ\��t�@�C���X�V����
	'   �����F  pm_HINCD      : ���i�R�[�h
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_INPTRA_Update(ByRef pm_HINCD As String, ByRef pm_Date As String, ByRef pm_Time As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		F_INPTRA_Update = 9
		
		On Error GoTo F_INPTRA_Update_err
		
		strSQL = ""
		strSQL = strSQL & " Update INPTRA"
		strSQL = strSQL & " Set"
		strSQL = strSQL & "     INHIKSU = 0"
		' === 20061119 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "    ,CLTID = '" & CF_Ora_String(SSS_CLTID, 5) & "'"
		'   strSQL = strSQL & "    ,WRTTM = '" & pm_Time & "'"
		'   strSQL = strSQL & "    ,WRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSQL = strSQL & "    ,UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "    ,UWRTTM = '" & pm_Time & "'"
		strSQL = strSQL & "    ,UWRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,PGID   = '" & CF_Ora_String(SSS_PrgId, 7) & "'"
		' === 20061119 === UPDATE E -
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     DATKB = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " And HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		strSQL = strSQL & " And INPSU > INPSMSU"
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_INPTRA_Update_err
		End If
		
		F_INPTRA_Update = 0
		
F_INPTRA_Update_End: 
		Exit Function
		
F_INPTRA_Update_err: 
		'�G���[���b�Z�[�W
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All, "F_INPTRA_Update")
		
		GoTo F_INPTRA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_DTLTRA_Update
	'   �T�v�F  ��������t�@�C���X�V����
	'   �����F  pm_HINCD      : ���i�R�[�h
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_DTLTRA_Update(ByRef pm_HINCD As String, ByRef pm_Date As String, ByRef pm_Time As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		F_DTLTRA_Update = 9
		
		On Error GoTo F_DTLTRA_Update_err
		'CHG START FKS)INABA 2009/09/30 *********************
		'�A���[��FC09100103
		Dim lw_ret As Short
		Dim ls_sql As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim ls_TRAKB As String
		Dim ls_TRANO As String
		Dim ls_MITNOV As String
		Dim ls_LINNO As String
		Dim ls_TRADT As String
		Dim ls_HIKNO As String
		Dim ls_ATMNKB As String
		Dim ls_HINCD As String
		Dim ls_PUDLNO As String
		Dim ls_ROWID As String
		ls_sql = ""
		ls_sql = ls_sql & " SELECT TRAKB,TRANO,MITNOV,LINNO,TRADT,HIKNO,ATMNKB,HINCD,PUDLNO,ROWID "
		ls_sql = ls_sql & "   FROM DTLTRA"
		ls_sql = ls_sql & "  WHERE HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		ls_sql = ls_sql & "  ORDER BY TRAKB,TRANO,MITNOV,LINNO,TRADT"
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)
		lw_ret = 0
		Do Until CF_Ora_EOF(Usr_Ody) = True
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ls_TRAKB = CF_Ora_GetDyn(Usr_Ody, "TRAKB", "")
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ls_TRANO = CF_Ora_GetDyn(Usr_Ody, "TRANO", "")
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ls_MITNOV = CF_Ora_GetDyn(Usr_Ody, "MITNOV", "")
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ls_LINNO = CF_Ora_GetDyn(Usr_Ody, "LINNO", "")
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ls_TRADT = CF_Ora_GetDyn(Usr_Ody, "TRADT", "")
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ls_HIKNO = CF_Ora_GetDyn(Usr_Ody, "HIKNO", "")
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ls_ATMNKB = CF_Ora_GetDyn(Usr_Ody, "ATMNKB", "")
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ls_HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "")
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ls_PUDLNO = CF_Ora_GetDyn(Usr_Ody, "PUDLNO", "")
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ls_ROWID = CF_Ora_GetDyn(Usr_Ody, "ROWID", "")
			lw_ret = F_DEL_DTLTRA_CHK(ls_TRAKB, ls_TRANO, ls_MITNOV, ls_LINNO, ls_TRADT, ls_HIKNO, ls_ATMNKB, ls_HINCD, ls_PUDLNO)
			If lw_ret = 0 Then
				strSQL = ""
				strSQL = strSQL & " DELETE FROM DTLTRA"
				strSQL = strSQL & " WHERE ROWID = '" & Trim(ls_ROWID) & "'"
				'SQL���s
				bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
				If bolRet = False Then
					GoTo F_DTLTRA_Update_err
				End If
			ElseIf lw_ret = -1 Then 
				GoTo F_DTLTRA_Update_err
			End If
			Call CF_Ora_MoveNext(Usr_Ody)
		Loop 
		'    strSQL = ""
		''///////////////// 2006.08.28 ACE MENTE START ////////////////////////
		'' ������=0�Ȃ�΁A�폜����
		''   strSQL = strSQL & " Update DTLTRA"
		''   strSQL = strSQL & " Set"
		''   strSQL = strSQL & "     HIKSU = 0"
		''   strSQL = strSQL & "    ,CLTID = '" & CF_Ora_String(SSS_CLTID, 5) & "'"
		''   strSQL = strSQL & "    ,WRTTM = '" & pm_Time & "'"
		''   strSQL = strSQL & "    ,WRTDT = '" & pm_Date & "'"
		'    strSQL = strSQL & " Delete From DTLTRA"
		'    strSQL = strSQL & " Where"
		'    strSQL = strSQL & "     HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		''///////////////// 2006.08.28 ACE MENTE E N D ////////////////////////
		'
		'    'SQL���s
		'    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		'    If bolRet = False Then
		'        GoTo F_DTLTRA_Update_err
		'    End If
		'
		'        Call CF_Ora_MoveNext(Usr_Ody)
		'    Loop
		'CHG  END  FKS)INABA 2009/09/30 *********************
		F_DTLTRA_Update = 0
		
F_DTLTRA_Update_End: 
		'ADD START FKS)INABA 2009/09/30 *********************
		'�A���[��FC09100103
		Call CF_Ora_CloseDyn(Usr_Ody)
		'ADD  END  FKS)INABA 2009/09/30 *********************
		Exit Function
		
F_DTLTRA_Update_err: 
		'�G���[���b�Z�[�W
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All, "F_DTLTRA_Update")
		
		GoTo F_DTLTRA_Update_End
		
	End Function
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_SKYTBL_Update
	'   �T�v�F  �x���i�e�[�u���X�V����
	'   �����F  pm_HINCD      : ���i�R�[�h
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SKYTBL_Update(ByRef pm_HINCD As String, ByRef pm_Date As String, ByRef pm_Time As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		F_SKYTBL_Update = 9
		
		On Error GoTo F_SKYTBL_Update_err
		
		strSQL = ""
		strSQL = strSQL & " Update SKYTBL"
		strSQL = strSQL & " Set"
		strSQL = strSQL & "     ATZHIKSU = 0"
		strSQL = strSQL & "    ,ATNHIKSU = 0"
		strSQL = strSQL & "    ,MNZHIKSU = 0"
		strSQL = strSQL & "    ,MNNHIKSU = 0"
		strSQL = strSQL & "    ,CLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "    ,WRTTM = '" & pm_Time & "'"
		strSQL = strSQL & "    ,WRTDT = '" & pm_Date & "'"
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     DATKB = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " And HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		strSQL = strSQL & " And OUTYOTSU > OUTZMISU"
		'ADD START FKS)INABA 2009/09/30 ************************************************
		'�A���[��FC09100103
		strSQL = strSQL & " And FRDSU = 0 "
		'ADD  END  FKS)INABA 2009/09/30 ************************************************
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_SKYTBL_Update_err
		End If
		
		F_SKYTBL_Update = 0
		
F_SKYTBL_Update_End: 
		Exit Function
		
F_SKYTBL_Update_err: 
		'�G���[���b�Z�[�W
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All, "F_SKYTBL_Update")
		
		GoTo F_SKYTBL_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_STOTRA_Update
	'   �T�v�F  ���i�t�@�C���X�V����
	'   �����F  pm_HINCD      : ���i�R�[�h
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_STOTRA_Update(ByRef pm_HINCD As String, ByRef pm_Date As String, ByRef pm_Time As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_STOTRA_Update_err
		
		F_STOTRA_Update = 9
		
		strSQL = ""
		'///////////////// 2006.09.14 ACE MENTE START ////////////////////////
		' ������=0�Ȃ�΁A�폜����
		'   strSQL = strSQL & " Update STOTRA"
		'   strSQL = strSQL & " Set"
		'   strSQL = strSQL & "     HIKSU = 0"
		'   strSQL = strSQL & "    ,CLTID = '" & CF_Ora_String(SSS_CLTID, 5) & "'"
		'   strSQL = strSQL & "    ,WRTTM = '" & pm_Time & "'"
		'   strSQL = strSQL & "    ,WRTDT = '" & pm_Date & "'"
		strSQL = strSQL & " Delete From STOTRA"
		'///////////////// 2006.09.14 ACE MENTE E N D ////////////////////////
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     DATKB = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " And HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_STOTRA_Update_err
		End If
		
		F_STOTRA_Update = 0
		
F_STOTRA_Update_End: 
		Exit Function
		
F_STOTRA_Update_err: 
		'�G���[���b�Z�[�W
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All, "F_STOTRA_Update")
		
		GoTo F_STOTRA_Update_End
		
	End Function
	
	' === 20070919 === INSERT S - ACE)Nagasawa �q�ɕʍ݌Ƀ}�X�^�̈������N���A���A�o�׎w���������L�[�v����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_FRDSU_Select
	'   �T�v�F  �o�׎w���ϐ��ʎ擾SQL�쐬
	'   �����F  pm_HINCD      : ���i�R�[�h
	'   �ߒl�F�@�쐬SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_FRDSU_Select(ByRef pm_HINCD As String, ByRef pm_All As Cls_All) As String
		
		Dim strSQL As String
		
		On Error GoTo F_FRDSU_Select_err
		
		F_FRDSU_Select = ""
		
		strSQL = ""
		strSQL = strSQL & " SELECT HINMTB.SOUCD "
		strSQL = strSQL & "      , HINMTB.HINCD "
		strSQL = strSQL & "      , NVL(JDNTRA.FRDSU, 0) + NVL(JDNTRT.FRDSU, 0) +"
		strSQL = strSQL & "        NVL(SKYTBL.FRDSU, 0) +"
		strSQL = strSQL & "        NVL(SBNTRA.FRDSU, 0) + NVL(SYKTRI.FRDSU, 0) FRDSU"
		strSQL = strSQL & "   FROM HINMTB ,"
		
		'��(�ʔ̈ȊO)
		'CHG START FKS)INABA 2009/09/30 *************************************************************
		'�A���[��FC09100103
		strSQL = strSQL & "        (SELECT FDNTRA.SOUCD"
		strSQL = strSQL & "              , JDNTRA.HINCD"
		strSQL = strSQL & "              , SUM(FDNTRA.FRDSU) FRDSU"
		'    strSQL = strSQL & "        (SELECT SUBSTR(HINMTA.TNACM,1,3) SOUCD"
		'    strSQL = strSQL & "              , JDNTRA.HINCD"
		'    strSQL = strSQL & "              , SUM(JDNTRA.FRDSU) FRDSU"
		'CHG  END  FKS)INABA 2009/09/30 *************************************************************
		
		strSQL = strSQL & "           FROM JDNTRA "
		strSQL = strSQL & "              , ( "
		strSQL = strSQL & "                  SELECT MAX(DATNO) DATNO "
		strSQL = strSQL & "                       , JDNNO "
		strSQL = strSQL & "                       , LINNO "
		strSQL = strSQL & "                    FROM JDNTRA "
		strSQL = strSQL & "                   WHERE DATKB   = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "                   GROUP BY DATKB "
		strSQL = strSQL & "                          , JDNNO "
		strSQL = strSQL & "                          , LINNO "
		strSQL = strSQL & "                   ORDER BY DATKB "
		strSQL = strSQL & "                          , JDNNO "
		strSQL = strSQL & "                          , LINNO "
		strSQL = strSQL & "                ) JDNTRB "
		strSQL = strSQL & "              , HINMTA "
		strSQL = strSQL & "              , JDNTHA "
		'ADD START FKS)INABA 2009/09/30 *************************************************************
		'�A���[��FC09100103
		strSQL = strSQL & "              , (SELECT DATKB,JDNNO,JDNLINNO,PUDLNO,HINCD,OUTSOUCD SOUCD,SUM(FRDSU-OTPSU) FRDSU "
		strSQL = strSQL & "                  FROM FDNTRA "
		strSQL = strSQL & "                 WHERE DATKB = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "                   AND FRDSU > OTPSU "
		strSQL = strSQL & "                 GROUP BY DATKB,JDNNO,JDNLINNO,PUDLNO,HINCD,OUTSOUCD) FDNTRA "
		'ADD  END  FKS)INABA 2009/09/30 *************************************************************
		strSQL = strSQL & "          WHERE JDNTHA.DATKB    = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "            AND JDNTHA.AKAKROKB = '" & gc_strAKAKROKB_KURO & "' "
		strSQL = strSQL & "            AND JDNTHA.JDNINKB  <> '" & gc_strJDNINKB_ML & "' "
		strSQL = strSQL & "            AND JDNTHA.DATNO    = JDNTRA.DATNO "
		strSQL = strSQL & "            AND JDNTRA.DATKB    = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "            AND JDNTRA.AKAKROKB = '" & gc_strAKAKROKB_KURO & "' "
		strSQL = strSQL & "            AND JDNTRA.DATNO    = JDNTRB.DATNO"
		strSQL = strSQL & "            AND JDNTRA.JDNNO    = JDNTRB.JDNNO"
		strSQL = strSQL & "            AND JDNTRA.LINNO    = JDNTRB.LINNO"
		strSQL = strSQL & "            AND JDNTRA.HINCD    = HINMTA.HINCD"
		strSQL = strSQL & "            AND JDNTRA.HINCD    = '" & CF_Ora_Sgl(pm_HINCD) & "' "
		'ADD START FKS)INABA 2009/09/30 *************************************************************
		'�A���[��FC09100103
		strSQL = strSQL & "            AND FDNTRA.JDNNO    = JDNTRA.JDNNO"
		strSQL = strSQL & "            AND FDNTRA.JDNLINNO = JDNTRA.LINNO"
		strSQL = strSQL & "            AND FDNTRA.PUDLNO   = JDNTRA.PUDLNO"
		strSQL = strSQL & "            AND FDNTRA.HINCD    = JDNTRA.HINCD"
		'ADD  END  FKS)INABA 2009/09/30 *************************************************************
		'CHG START FKS)INABA 2009/09/30 *************************************************************
		'�A���[��FC09100103
		strSQL = strSQL & "           GROUP BY JDNTRA.DATKB"
		strSQL = strSQL & "                  , JDNTRA.AKAKROKB"
		strSQL = strSQL & "                  , FDNTRA.SOUCD"
		strSQL = strSQL & "                  , JDNTRA.HINCD ) JDNTRA, "
		'    strSQL = strSQL & "           GROUP BY JDNTRA.DATKB"
		'    strSQL = strSQL & "                  , JDNTRA.AKAKROKB"
		'    strSQL = strSQL & "                  , HINMTA.TNACM"
		'    strSQL = strSQL & "                  , JDNTRA.HINCD ) JDNTRA, "
		'CHG  END  FKS)INABA 2009/09/30 *************************************************************
		
		'��(�ʔ�)
		strSQL = strSQL & "        (SELECT JDNTRA.SOUCD"
		strSQL = strSQL & "              , JDNTRA.HINCD"
		strSQL = strSQL & "              , SUM(JDNTRA.FRDSU) FRDSU"
		strSQL = strSQL & "           FROM JDNTRA"
		strSQL = strSQL & "              , (SELECT MAX(DATNO) DATNO"
		strSQL = strSQL & "                      , JDNNO"
		strSQL = strSQL & "                      , LINNO"
		strSQL = strSQL & "                   FROM JDNTRA "
		strSQL = strSQL & "                  WHERE DATKB   = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "                  GROUP BY DATKB"
		strSQL = strSQL & "                         , JDNNO"
		strSQL = strSQL & "                         , LINNO"
		strSQL = strSQL & "                  ORDER BY DATKB"
		strSQL = strSQL & "                         , JDNNO"
		strSQL = strSQL & "                         , LINNO"
		strSQL = strSQL & "                ) JDNTRB"
		strSQL = strSQL & "              , JDNTHA"
		strSQL = strSQL & "          WHERE JDNTHA.DATKB    = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "            AND JDNTHA.AKAKROKB = '" & gc_strAKAKROKB_KURO & "' "
		strSQL = strSQL & "            AND JDNTHA.JDNINKB  = '" & gc_strJDNINKB_ML & "' "
		strSQL = strSQL & "            AND JDNTHA.DATNO    = JDNTRA.DATNO"
		strSQL = strSQL & "            AND JDNTRA.DATKB    = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "            AND JDNTRA.AKAKROKB = '" & gc_strAKAKROKB_KURO & "' "
		strSQL = strSQL & "            AND JDNTRA.DATNO    = JDNTRB.DATNO"
		strSQL = strSQL & "            AND JDNTRA.JDNNO    = JDNTRB.JDNNO"
		strSQL = strSQL & "            AND JDNTRA.LINNO    = JDNTRB.LINNO"
		strSQL = strSQL & "            AND JDNTRA.HINCD    = '" & CF_Ora_Sgl(pm_HINCD) & "' "
		strSQL = strSQL & "            GROUP BY JDNTRA.DATKB"
		strSQL = strSQL & "                   , JDNTRA.AKAKROKB"
		strSQL = strSQL & "                   , JDNTRA.SOUCD"
		strSQL = strSQL & "                   , JDNTRA.HINCD) JDNTRT, "
		
		'�x���i�t�@�C��
		'CHG START FKS)INABA 2009/09/30 *************************************************************
		'�A���[��FC09100103
		strSQL = strSQL & "        (SELECT FDNTRA.SOUCD"
		strSQL = strSQL & "         �@   , SKYTBL.HINCD"
		strSQL = strSQL & "         �@   , SUM(FDNTRA.FRDSU) FRDSU"
		'    strSQL = strSQL & "        (SELECT SUBSTR(HINMTA.TNACM,1,3) SOUCD"
		'    strSQL = strSQL & "         �@   , SKYTBL.HINCD"
		'    strSQL = strSQL & "         �@   , SUM(SKYTBL.FRDSU) FRDSU"
		'CHG  END  FKS)INABA 2009/09/30 *************************************************************
		strSQL = strSQL & "          FROM SKYTBL"
		strSQL = strSQL & "             , HINMTA"
		'ADD START FKS)INABA 2009/09/30 *************************************************************
		'�A���[��FC09100103
		strSQL = strSQL & "             ,(SELECT DATKB,SBNNO,PUDLNO,HINCD,OUTSOUCD SOUCD,SUM(FRDSU - OTPSU) FRDSU"
		strSQL = strSQL & "                 FROM FDNTRA"
		strSQL = strSQL & "                WHERE DATKB  = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "                  AND FRDSU > OTPSU"
		strSQL = strSQL & "               GROUP BY DATKB,SBNNO,PUDLNO,HINCD,OUTSOUCD ) FDNTRA"
		'ADD  END  FKS)INABA 2009/09/30 *************************************************************
		strSQL = strSQL & "         WHERE SKYTBL.DATKB  = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "           AND SKYTBL.PLANKB = ' '"
		strSQL = strSQL & "           AND SKYTBL.HINCD  = HINMTA.HINCD"
		strSQL = strSQL & "           AND SKYTBL.HINCD  = '" & CF_Ora_Sgl(pm_HINCD) & "' "
		'ADD START FKS)INABA 2009/09/30 *************************************************************
		'�A���[��FC09100103
		strSQL = strSQL & "           AND SKYTBL.SBNNO  = FDNTRA.SBNNO  "
		strSQL = strSQL & "           AND SKYTBL.PUDLNO = FDNTRA.PUDLNO "
		strSQL = strSQL & "           AND SKYTBL.HINCD  = FDNTRA.HINCD  "
		'ADD  END  FKS)INABA 2009/09/30 *************************************************************
		'CHG START FKS)INABA 2009/09/30 *************************************************************
		'�A���[��FC09100103
		strSQL = strSQL & "         GROUP BY SKYTBL.DATKB"
		strSQL = strSQL & "                , SKYTBL.PLANKB"
		strSQL = strSQL & "                , FDNTRA.SOUCD "
		strSQL = strSQL & "                , SKYTBL.HINCD) SKYTBL, "
		'    strSQL = strSQL & "         GROUP BY SKYTBL.DATKB"
		'    strSQL = strSQL & "                , SKYTBL.PLANKB"
		'    strSQL = strSQL & "                , HINMTA.TNACM"
		'    strSQL = strSQL & "                , SKYTBL.HINCD) SKYTBL, "
		'CHG  END  FKS)INABA 2009/09/30 *************************************************************
		
		'���ԏo�Ƀt�@�C��
		strSQL = strSQL & "        (SELECT SBNTRA.OUTSOUCD SOUCD"
		strSQL = strSQL & "              , SBNTRA.HINCD"
		strSQL = strSQL & "              , SUM(SBNTRA.FRDSU) FRDSU"
		strSQL = strSQL & "          FROM SBNTRA"
		strSQL = strSQL & "         WHERE SBNTRA.DATKB  = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "           AND SBNTRA.HINCD  = '" & CF_Ora_Sgl(pm_HINCD) & "' "
		strSQL = strSQL & "         GROUP BY SBNTRA.DATKB"
		strSQL = strSQL & "                , SBNTRA.OUTSOUCD"
		strSQL = strSQL & "                , SBNTRA.HINCD) SBNTRA, "
		
		'�o�ח\��t�@�C���ړ�
		strSQL = strSQL & "        (SELECT SYKTRI.OUTSOUCD SOUCD"
		strSQL = strSQL & "              , SYKTRI.HINCD"
		strSQL = strSQL & "              , SUM(SYKTRI.HIKSU) + SUM(SYKTRI.FRDSU) FRDSU"
		strSQL = strSQL & "           FROM SYKTRI"
		strSQL = strSQL & "          WHERE SYKTRI.DATKB = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "            AND SYKTRI.HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "' "
		strSQL = strSQL & "          GROUP BY SYKTRI.DATKB"
		strSQL = strSQL & "                 , SYKTRI.OUTSOUCD"
		strSQL = strSQL & "                 , SYKTRI.HINCD) SYKTRI"
		strSQL = strSQL & "  WHERE HINMTB.DATKB = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "    AND HINMTB.HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "' "
		strSQL = strSQL & "    AND HINMTB.SOUCD  =  JDNTRA.SOUCD (+)"
		strSQL = strSQL & "    AND HINMTB.HINCD  =  JDNTRA.HINCD (+)"
		strSQL = strSQL & "    AND HINMTB.SOUCD  =  JDNTRT.SOUCD (+)"
		strSQL = strSQL & "    AND HINMTB.HINCD  =  JDNTRT.HINCD (+)"
		strSQL = strSQL & "    AND HINMTB.SOUCD  =  SKYTBL.SOUCD (+)"
		strSQL = strSQL & "    AND HINMTB.HINCD  =  SKYTBL.HINCD (+)"
		strSQL = strSQL & "    AND HINMTB.SOUCD  =  SBNTRA.SOUCD (+)"
		strSQL = strSQL & "    AND HINMTB.HINCD  =  SBNTRA.HINCD (+)"
		strSQL = strSQL & "    AND HINMTB.SOUCD  =  SYKTRI.SOUCD (+)"
		strSQL = strSQL & "    AND HINMTB.HINCD  =  SYKTRI.HINCD (+)"
		
		F_FRDSU_Select = strSQL
		
F_FRDSU_Select_End: 
		
		Exit Function
		
F_FRDSU_Select_err: 
		'�G���[���b�Z�[�W
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All, "F_FRDSU_Select")
		
		GoTo F_FRDSU_Select_End
		
	End Function
	' === 20070919 === INSERT E -
	
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
		Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
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
		pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
		'�ҏW���SelLength������
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
		
		' === 20061228 === INSERT S - ACE)Nagasawa
		'���͌�̌㏈��
		Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		' === 20061228 === INSERT E -
		
		'���ד��͌�̌㏈��
		Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
End Module