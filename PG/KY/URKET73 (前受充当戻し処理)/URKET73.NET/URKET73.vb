Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
	'//* All Right Reserved Copy Right (C)  ������Еx�m�ʊ֐��V�X�e���Y
	'//***************************************************************************************
	'//*
	'//*�����́�
	'//* URKET73 �O��[���߂�
	'//*
	'//*���o�[�W������
	'//* 1.00
	'//*
	'//*���쐬�ҁ�
	'//* FKS)
	'//*
	'//*��������
	'//* �O��[���̖߂��������
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t    | �X�V��        |���e
	'//* ---------|----------|---------------|-----------------------------------------------
	'//* 1.00     |2009/06/13|FKS)���c       |�V�K�쐬(URKET53 ����������藬�p�쐬)
	'//* 1.01     |2009/07/06|FKS)���c       |�����\���z�擾���W�b�N�̒ǉ�
	'//* 1.02     |2009/08/28|FKS)���c       |�����\���z�擾���W�b�N�̕ύX(getUdntraNyukn)
	'//* 1.03     |2009/09/03|FKS)���c       |�U�������Ɋւ��鏈����ύX(�߂���ʂ���̓��͂��ł��Ȃ�����)
	'//*          |          |               |�@�U������(cmd_fridt/txt_fridt)��Visible��
	'//* �@�@�@�@ |          |               |�@�uTure�v����uFalse�v�֕ύX
	'//* �@�@�@�@ |          |               |�@�U������(txt_fridt)��TabStop���uTure�v����uFalse�v�֕ύX
	'//* 1.04     |2009/09/07|FKS)���c       |���������ȑO�̓��t����͕s�Ƃ���B
	'//* �@�@�@�@ |          |               |������̒S���҂��c�ƒS���Ŗ����ꍇ�A�G���[�Ƃ���B
	'//* 2.00     |2009/09/16|FKS)���c       |�E���������T�}���[�̖{�������ڂɑ΂��ĉ����X�V���Ȃ��悤�ɂ���
	'//*          |          |               |�E�O���������̓��������T�}���[�̖߂���ύX�i�����������j
	'//*          |          |               |�E�萔���E����͎��g�̎����Ă�������敪�ɂď����g�������쐬����
	'//*          |          |               |�E���[�Ή��̂��߁A���z�`�F�b�N�E�`�[�P�ʃ`�F�b�N���O��
	'//**************************************************************************************
	
	
	
	Private Declare Function ReleaseTabCapture Lib "TabCap.DLL" (ByVal hwnd As Integer) As Integer
	Private Declare Function SetTabCapture Lib "TabCap.DLL" (ByVal hwnd As Integer) As Integer
	
	Dim intUrigoukei As Decimal '������z�̍��v���i�[�i���ו\�����ɃZ�b�g�j
	Dim intBfkesiknkei As Decimal '�����ϊz(�����O)�̍��v�z���i�[�i���ו\�����ɃZ�b�g�j
	
	
	Dim blnFriEnabled As Boolean '�U����������͂ł��邩�ǂ����̃t���O(����́u��`�v�u�U�������i�t�@�N�^�����O�j�v�����݂��鎞�j
	
	Dim blnUsableSpread As Boolean '���گ�ނ̲���Ă����s���邩�ǂ������׸�
	Dim intMaxRow As Short '���گ�ނ̕\���ő�s�����i�[
	
	Dim blnUsableButton As Boolean '�萔���A����ō��z�A�S�����A�S�����A�ĕ\���A�U������(���ו�)�̲���Ă����s���邩�ǂ������׸�
	Dim intChkKb As Short '�`�F�b�N�敪(1:�`�F�b�N 2:�`�F�b�N(�O�񂩂�ύX���̂�)
	Dim blnUsableEvent As Boolean '����Ă����s���邩�ǂ������׸�(�ėp)
	Dim blnINIT_FLG As Boolean
	
	
	Dim intInputMode As Short '���͏��(1:�w�b�_�[ 2:���� 9:��ʃN���A�[����)
	
	
	''�ԍ��`�F�b�N�p�\����
	Private Structure TYPE_AKAKRO_CHK
		Dim idx As Integer '�s�ԍ�
		Dim CHKMK As Short '�`�F�b�N�}�[�N
		Dim UDNDT As String '�����
		Dim JDNNO As String '�󒍇�
		Dim KESIKN As Decimal '�������z
	End Structure
	
	Private AKAKRO_CHK() As TYPE_AKAKRO_CHK
	
	
	''�`�[�P�ʃ`�F�b�N�p�\����
	Private Structure TYPE_JDNTRKB_CHK
		Dim idx As Integer '�s�ԍ�
		Dim JDNNO As String '�󒍇�
		Dim HYJDNNO As String '�\���p�󒍔ԍ�
		Dim KOMIKN As Decimal '�ō�������z
	End Structure
	
	Private JDNTRKB_CHK() As TYPE_JDNTRKB_CHK
	
	
	
	'�t�H�[�����[�h�C�x���g
	Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'WINDOW �ʒu�ݒ�
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		'���[�J���ϐ�������
		intUrigoukei = 0
		intBfkesiknkei = 0
		intMaxRow = 0
		intChkKb = 2
		
		blnFriEnabled = False
		blnUsableSpread = False
		blnUsableButton = False
		blnUsableEvent = True
		
		'��DB�ւ̐ڑ�
		If CF_Ora_USR1_Open = False Then
			MsgBox("DB�̐ڑ��Ɏ��s���܂����B", MsgBoxStyle.Critical, "�ڑ��G���[")
		End If
		
		'PG������
		Call CF_Init()
		
		'��ʏ�����
		initForm()
		initCondition()
		initHead()
		initBody()
		
		
		intInputMode = 1
		
		'�V�X�e�����ʏ���
		Call CF_System_Process(Me)
		
		
		'�����O�̏����o��
		Call SSSWIN_LOGWRT("�v���O�����N��")
	End Sub
	
	'�t�H�[���A�����[�h�C�x���g
	Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		'���I���m�F��MSG
		
		If ChkInputChange() = True Then
			If showMsg("0", "_ENDCK", CStr(0)) = MsgBoxResult.No Then
				Cancel = MsgBoxResult.Cancel
				Exit Sub
			End If
		Else
			If showMsg("0", "_ENDCM", CStr(0)) = MsgBoxResult.No Then
				Cancel = MsgBoxResult.Cancel
				Exit Sub
			End If
		End If
		
		
		'�r���e�[�u���폜
		Call SSSEXC_EXCTBZ_CLOSE()
		
		' === 20130708 === INSERT S - FWEST)Koroyasu �r������̉���
		Call SSSWIN_Unlock_EXCTBZ()
		' === 20130708 === INSERT E -
		
		'DB�̐ڑ���ؒf
		Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
		
		Call CF_Ora_DisConnect(gv_Oss_USR_SAIBAN, gv_Oss_USR_SAIBAN)
		
		
		'�����O�̏����o��
		Call SSSWIN_LOGWRT("�v���O�����I��")
		
		End '��PG�I��
		eventArgs.Cancel = Cancel
	End Sub
	
	'�t�H�[���̏�����
	Private Sub initForm()
		Dim ssBevelNone As Object
		Dim i As Short
		'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    �A���[��702
		Dim strRet As String
		'''' ADD 2009/11/26  FKS) T.Yamamoto    End
		
		'�t�H�[���L���v�V�����Z�b�g
		Me.Text = SSS_PrgNm
		
		'�^�p���̎擾
		gstrUnydt.Value = getUnydt
		'�O��o�������s���̎擾
		Call getSYSTBA()
		'''' UPD 2009/11/26  FKS) T.Yamamoto    Start    �A���[��702
		'    '�����̎擾
		'    Call Get_Authority(gstrUnydt)
		'�����̎擾
		strRet = Get_Authority(gstrUnydt.Value)
		If strRet = "9" Then
			'�N�������Ȃ��̏ꍇ�A�����I��
			Call showMsg("2", "RUNAUTH", CStr(0))
			End
		End If
		'''' UPD 2009/11/26  FKS) T.Yamamoto    End
		
		'��ʉE��̍��ڂɉ^�p�����Z�b�g
		'UPGRADE_WARNING: �I�u�W�F�N�g pnl_unydt.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pnl_unydt.Caption = CNV_DATE(gstrUnydt.Value)
		
		'���͒S���҂��Z�b�g
		txt_opeid.Text = SSS_OPEID.Value
		txt_openm.Text = getTannm(SSS_OPEID.Value)
		
		txt_message.Text = ""
		
		'�����Œ�p�p�l�����B��
		'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition1.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pnl_condition1.Caption = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition1.BevelOuter �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ssBevelNone �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pnl_condition1.BevelOuter = ssBevelNone
		'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition2.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pnl_condition2.Caption = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition2.BevelOuter �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ssBevelNone �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pnl_condition2.BevelOuter = ssBevelNone
		
		'�\������e�L�X�g�{�b�N�X�ݒ�p�p�l�����B��
		'UPGRADE_WARNING: �I�u�W�F�N�g pnl_hihyoji.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pnl_hihyoji.Caption = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g pnl_hihyoji.BevelOuter �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ssBevelNone �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pnl_hihyoji.BevelOuter = ssBevelNone
		
		
		'���گ�މB�����ڂ��\���ɂ���
		If SHOW_HIDE_COLUMN_FLAG = False Then
			With spd_body
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.Row = -1
				For i = COL_BFKESIKN To COL_HENPI
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = i
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.ColHidden �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.ColHidden = True
				Next i
			End With
		End If
		
		
	End Sub
	
	'���͏����̏�����
	Private Sub initCondition()
		
		Call initVal() '��۰��ٕϐ��̏�����
		
		txt_kesidt.Text = CNV_DATE(gstrUnydt.Value) '�^�p�����Z�b�g
		txt_kesidt.ForeColor = System.Drawing.Color.Black
		txt_kesidt.BackColor = System.Drawing.Color.White
		
		txt_tokseicd.Text = Space(5) '5byte space
		txt_tokseicd.ForeColor = System.Drawing.Color.Black
		txt_tokseicd.BackColor = System.Drawing.Color.White
		
		txt_tokseinma.Text = ""
		
		txt_kaidt_From.Text = Space(10) '10byte space
		txt_kaidt_From.ForeColor = System.Drawing.Color.Black
		txt_kaidt_From.BackColor = System.Drawing.Color.White
		
		txt_kaidt_To.Text = CNV_DATE(gstrUnydt.Value) '�^�p�����Z�b�g
		txt_kaidt_To.ForeColor = System.Drawing.Color.Black
		txt_kaidt_To.BackColor = System.Drawing.Color.White
		
		
		
		'�O��[���͏����l���u�X�v�Ƃ���B
		'txt_kesikb.Text = 1
		txt_kesikb.Text = CStr(9)
		
		blnFriEnabled = False
		txt_fridt.Text = Space(10) '10byte space
		txt_fridt.ForeColor = System.Drawing.Color.Black
		txt_fridt.BackColor = System.Drawing.Color.White
		txt_fridt.Enabled = blnFriEnabled
		
		blnUsableButton = False
		blnUsableEvent = True
		
		'�I�v�V�������ڂ̐���
		frm_opt1.Visible = OPTION_SHOW_FLAG
		opt_sort(0).Checked = True
		lbl_shakbnm(0).Visible = OPTION_SHOW_FLAG
		lbl_shakbnm(1).Visible = OPTION_SHOW_FLAG
		lbl_shakbnm(1).Text = ""
		lbl_hytokkesdd(0).Visible = OPTION_SHOW_FLAG
		lbl_hytokkesdd(1).Visible = OPTION_SHOW_FLAG
		lbl_hytokkesdd(1).Text = ""
		bar21.Visible = OPTION_SHOW_FLAG
		mnu_zenkesi.Visible = OPTION_SHOW_FLAG
		mnu_zenkaijo.Visible = OPTION_SHOW_FLAG
		mnu_zenkesi.Enabled = blnUsableButton
		mnu_zenkaijo.Enabled = blnUsableButton
	End Sub
	
	'�w�b�_��(�������)�̏�����
	Private Sub initHead()
		txt_urigoukei.Text = CStr(0)
		txt_nyukin.Text = CStr(0)
		txt_tesuryo.Text = CStr(0)
		txt_syohi.Text = CStr(0)
		txt_nyugoukei.Text = CStr(0)
		txt_kesizan.Text = CStr(0)
		intUrigoukei = 0
		intBfkesiknkei = 0
	End Sub
	
	'���ו��̏�����
	Private Sub initBody()
		Dim ActionSelectBlock As Object
		Dim ActionClearText As Object
		'�������ͽ��گ�޲���Ă����s�����Ȃ�
		blnUsableSpread = False
		
		With spd_body
			'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.ReDraw = False
			
			'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Col = -1
			'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Row = -1
			'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Action �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g ActionClearText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Action = ActionClearText
			
			'�J�[�\���ʒu��擪�ɖ߂�
			'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Col = 1
			'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Row = 1
			'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Action �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g ActionSelectBlock �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Action = ActionSelectBlock
			
			'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.MaxRows = 9999
			'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.ReDraw = True
		End With
		
		intMaxRow = 0
		
		'���گ�޲���Ă̋���
		blnUsableSpread = True
	End Sub
	
	'���ו��̏���\��
	Private Sub showBody()
		Dim strSql As Object
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim tmp As Object
		Dim intRet As Short
		Dim lw_sort As Short
		Dim bleNextFlg As Boolean
		Dim idxRow As Integer
		Dim strHyjdnno As String
		Dim strTEGDT As String
		
		' === 20130708 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
		Dim rResult As Short ' �����`�F�b�N�֐��߂�l
		Dim strUDNDT As String
		' === 20130708 === INSERT E
		
		' === 20130708 === INSERT S - FWEST)Koroyasu �r������̉���
		Call SSSWIN_Unlock_EXCTBZ()
		' === 20130708 === INSERT E -
		
		'�������ͽ��گ�޲���Ă����s�����Ȃ�
		blnUsableSpread = False
		
		'�r���p�z��̏�����
		ReDim ARY_UDNTRA_HAITA(0)
		ReDim ARY_JDNTRA_HAITA(0)
		ReDim ARY_UDNTRA_NYU_HAITA(0)
		
		ReDim ARY_NYUKN_KS(0)
		
		ARY_NYUKN_KS_CNT = 0
		
		'�}�E�X�J�[�\���������v�ɂ���
		Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
		
		'���׃f�[�^�擾�pSQL���쐬
		Select Case True
			Case opt_sort(0).Checked
				lw_sort = 0
			Case opt_sort(1).Checked
				lw_sort = 1
			Case opt_sort(2).Checked
				lw_sort = 2
		End Select
		
		
		'���ו��\���f�[�^�擾SQL���쐬����
		'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSql = getSQLforBody(DB_SYSTBA.SMAUPDDT, gstrTokseicd.Value, gstrKaidt_Fr.Value, gstrKaidt_To.Value, (txt_kesikb.Text), lw_sort)
		'�ް��擾
		'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		'�\�����ڏ�����
		initHead()
		initBody()
		
		
		'�������ͽ��گ�޲���Ă����s�����Ȃ�
		blnUsableSpread = False
		
		
		With spd_body
			'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.ReDraw = False
			
			Do While CF_Ora_EOF(Usr_Ody) = False
				
				'�\��t����f�[�^���ԕi�f�[�^�̏ꍇ����f�[�^������
				bleNextFlg = True
				
				'�ԕi�̐ԍ��`�F�b�N
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If chkHenpin(Trim(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "RECNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTDT", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTTM", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "URITK", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) = False Then
					
					
					'�f�[�^�̕\�����s��Ȃ�
					bleNextFlg = False
				Else
					bleNextFlg = True
				End If
				
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Trim(CF_Ora_GetDyn(Usr_Ody, "HENRSNCD", "")) = "" Then
					'�ԕi��A�󒍒��������̐ԍ��`�F�b�N
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If chkHenpinTeisei(Trim(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "LINNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTDT", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTTM", ""))) = False Then
						
						'�f�[�^�̕\�����s��Ȃ�
						bleNextFlg = False
					Else
						bleNextFlg = True
					End If
				End If
				
				
				''���͂��ꂽ�������ȍ~�̔���f�[�^���o���Ȃ�
				If bleNextFlg = False Then
					bleNextFlg = False
					
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Trim(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")) > DeCNV_DATE(Trim(txt_kesidt.Text)) And CDbl(Trim(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) > 0 Then
						
						'���f�[�^�œ��͂��ꂽ����������̔���͕\�����Ȃ�
						bleNextFlg = False
						
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ElseIf Trim(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")) > DeCNV_DATE(Trim(txt_kesidt.Text)) And CDbl(Trim(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) < 0 Then 
						'�ԕi�̏ꍇ�́A���ɉ�ʏ�ɓ����󒍔ԍ������݂��邩���m�F����B
						With spd_body
							For idxRow = intMaxRow To 1 Step -1
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Call .GetText(COL_HYJDNNO, idxRow, tmp)
								'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								strHyjdnno = CStr(tmp)
								
								'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If Trim(strHyjdnno) = Trim(CF_Ora_GetDyn(Usr_Ody, "HY_JDNNO", "")) Then
									'��ʏ�ɍ�������Ώo��
									bleNextFlg = True
									Exit For
								Else
									bleNextFlg = False
								End If
							Next idxRow
						End With
					Else
						bleNextFlg = True
						
					End If
				End If
				
				
				
				'//�\�����f�`�F�b�N
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If chkHenpin2(Trim(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNDT", ""))) = False Then
					bleNextFlg = False
				End If
				
				
				If bleNextFlg = True Then
					
					intMaxRow = intMaxRow + 1
					
					'�X�v���b�h�Ɏ擾�����f�[�^��\��
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Row = intMaxRow
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_NO 'No.
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = intMaxRow
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_NXTKB '���[
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "nxtkb", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_HYUDNDT '�����
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "hy_udndt", "")
					' === 20130708 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strUDNDT = .Text
					' === 20130708 === INSERT E -
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_HYJDNNO '�󒍔ԍ�
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "hy_jdnno", "")
					' === 20130708 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If .Text <> "" Then
						'�r���`�F�b�N
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						rResult = SSSWIN_EXCTBZ_CHECK2(VB.Left(.Text, 6))
						Select Case rResult
							'����
							Case 0
								
								'�r��������
							Case 1
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								MsgBox("���̃v���O�����ōX�V���̂��߁A�o�^�ł��܂���B" & vbCrLf & vbCrLf & "�sNo:" & vbTab & intMaxRow & vbCrLf & "�����: " & vbTab & strUDNDT & vbCrLf & "�󒍔ԍ�: " & vbTab & .Text)
								Call SSSWIN_Unlock_EXCTBZ()
								initBody()
								GoTo STEP10_ShowBody
								
								'�ُ�I��
							Case 9
								Call showMsg("2", "URKET73_034", CStr(0)) '�X�V�ُ�
								Call SSSWIN_Unlock_EXCTBZ()
								initBody()
								GoTo STEP10_ShowBody
						End Select
					End If
					' === 20130708 === INSERT E -
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_HYKAIDT '����\���
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "hy_kaidt", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_TOKJDNNO '�q�撍���ԍ�
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "tokjdnno", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_TANNM '�c�ƒS����
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "tannm", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_URIKN '�Ŕ�������z
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "urikn", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_UZEKN '����Ŋz
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "uzekn", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_KOMIKN '�ō�������z
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "komikn", "")
					'���v���z���v�Z
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					intUrigoukei = intUrigoukei + SSSVal(.Text)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_KESIKN '�����ϊz
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "kesikn", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_MINYUKN '�������z(��\��)
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "kesikn", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_HYFRIDT '�U������
					strTEGDT = Get_NKSTRA_TEGDT(CF_Ora_GetDyn(Usr_Ody, "datno", ""), CF_Ora_GetDyn(Usr_Ody, "linno", ""))
					If Trim(strTEGDT) <> "" Then
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Text = CNV_DATE(strTEGDT)
					Else
						'*** 2009/09/03 ADD START FKS)NAKATA V1.03
						'�������R�[�h���U���������擾����
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, jdnlinno, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						strTEGDT = Get_NYUKN_TEGDT(CF_Ora_GetDyn(Usr_Ody, "jdnno", ""), CF_Ora_GetDyn(Usr_Ody, "jdnlinno", ""))
						'*** 2009/09/03 ADD E.N.D FKS)NAKATA
						If Trim(strTEGDT) <> "" Then
							'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							.Text = CNV_DATE(strTEGDT)
						End If
					End If
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_BFHYFRIDT '�U������(�ύX�O)
					If Trim(strTEGDT) <> "" Then
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Text = CNV_DATE(strTEGDT)
						
						'*** 2009/09/03 DEL START FKS)NAKATA V1.03
						'        Else
						'            .Text = CNV_DATE(gstrFridt)                 'ͯ�ނŎw�肵���U�������������\��
						'*** 2009/09/03 DEL START FKS)NAKATA V1.03
					End If
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_HYFRIDT '�U������
					
					'�w�b�_���Ɠ������A���ו��̓��͂�����
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Lock �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Lock = Not blnFriEnabled
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_BFKESIKN '�����ϊz(�����O)
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "bfkesikn", "")
					'���v���z���v�Z
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					intBfkesiknkei = intBfkesiknkei + SSSVal(.Text)
					
					'�������ϊz(KESIKN) - �����ϊz(�����O) > 0 �̂Ƃ������ޯ����������t����
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.GetText(COL_KESIKN, .Row, tmp)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(tmp) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If SSSVal(tmp) <> 0 Then
						
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Col = COL_CHK
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Value = 1
						
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Col = COL_BFCHECK
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Value = 1
						
					End If
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_AFKESIKN '�����ϊz(������)
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "afkesikn", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_JDNNO '�󒍔ԍ�(6��)
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "jdnno", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_JDNLINNO '�󒍍s�ԍ�
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "jdnlinno", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_UDNDT '�����(�X���b�V���Ȃ�)
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "udndt", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_KESDT '����\���(�X���b�V���Ȃ��j
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "kesdt", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_TOKCD '���Ӑ溰��
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "tokcd", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_TOKSEICD '�����溰��
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "tokseicd", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_TANCD '�S���Һ���
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "tancd", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_JDNDT '�󒍓�
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "jdndt", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_TUKKB '�ʉ݋敪
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "tukkb", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_INVNO '���޲��ԍ�
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "invno", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_FURIKN '�C�O������z
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "furikn", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_FRNKB '�C�O����敪
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "frnkb", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_UDNDATNO '����DATNO
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "datno", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_UDNLINNO '����s�ԍ�
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "linno", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_MAEUKKB '�O��敪
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "maeukkb", "")
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_JDNDATNO '��DATNO
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = CF_Ora_GetDyn(Usr_Ody, "jdndatno", "")
					
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_KESIKN_MAE '�������z�O
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(CF_Ora_GetDyn(Usr_Ody, afkesikn, )) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = SSSVal(CF_Ora_GetDyn(Usr_Ody, "bfkesikn", "")) + SSSVal(CF_Ora_GetDyn(Usr_Ody, "afkesikn", ""))
					
					
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(CF_Ora_GetDyn(Usr_Ody, kesikn, )) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(CF_Ora_GetDyn(Usr_Ody, komikn, )) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If SSSVal(CF_Ora_GetDyn(Usr_Ody, "komikn", "")) - SSSVal(CF_Ora_GetDyn(Usr_Ody, "kesikn", "")) < 0 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Col = COL_HENPI
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Text = "1"
					End If
					
					
					'����g�����̔r�����擾
					ReDim Preserve ARY_UDNTRA_HAITA(intMaxRow)
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_UDNTRA_HAITA(intMaxRow).DATNO = CStr(CF_Ora_GetDyn(Usr_Ody, "DATNO", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_UDNTRA_HAITA(intMaxRow).LINNO = CStr(CF_Ora_GetDyn(Usr_Ody, "LINNO", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_UDNTRA_HAITA(intMaxRow).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNOPEID", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_UDNTRA_HAITA(intMaxRow).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNCLTID", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_UDNTRA_HAITA(intMaxRow).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNWRTDT", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_UDNTRA_HAITA(intMaxRow).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNWRTTM", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_UDNTRA_HAITA(intMaxRow).UOPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUOPEID", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_UDNTRA_HAITA(intMaxRow).UCLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUCLTID", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_UDNTRA_HAITA(intMaxRow).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUWRTDT", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_UDNTRA_HAITA(intMaxRow).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUWRTTM", ""))
					
					'�󒍃g�����̔r�����擾
					ReDim Preserve ARY_JDNTRA_HAITA(intMaxRow)
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_JDNTRA_HAITA(intMaxRow).DATNO = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNDATNO", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_JDNTRA_HAITA(intMaxRow).JDNNO = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNNO", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_JDNTRA_HAITA(intMaxRow).LINNO = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_JDNTRA_HAITA(intMaxRow).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNOPEID", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_JDNTRA_HAITA(intMaxRow).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNCLTID", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_JDNTRA_HAITA(intMaxRow).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNWRTDT", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_JDNTRA_HAITA(intMaxRow).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNWRTTM", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_JDNTRA_HAITA(intMaxRow).UOPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUOPEID", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_JDNTRA_HAITA(intMaxRow).UCLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUCLTID", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_JDNTRA_HAITA(intMaxRow).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUWRTDT", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_JDNTRA_HAITA(intMaxRow).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUWRTTM", ""))
					
					
					'����g�����������R�[�h�̔r�����擾
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call getUdntraNyukn(CStr(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), CStr(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")))
					
				End If
				
				'UPGRADE_WARNING: �I�u�W�F�N�g Usr_Ody.Obj_Ody.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Usr_Ody.Obj_Ody.MoveNext()
			Loop 
			
		End With
		
		Call CF_Ora_CloseDyn(Usr_Ody) '�ް���ĸ۰��
		
		'�����Ώۂ��Ȃ���΃��b�Z�[�W��\��
		If intMaxRow = 0 Then
			Call showMsg("2", "RNOTFOUND", "0") '���Y���f�[�^�Ȃ�
			txt_kesidt.Focus()
			
			'�Ώۂ����鎞
		Else
			
			'���������g�����̔r�����擾
			Call Get_NKSTRA_HAITA_INF()
			
			'�\���s����16�s�ȏ�̂Ƃ��A���گ�ލs����ݒ�
			If intMaxRow > 16 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				spd_body.MaxRows = intMaxRow
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				spd_body.MaxRows = 16
			End If
			
			showHead() 'ͯ�ޕ��̕\��
			
			'spd_body.SetFocus
			blnUsableButton = True '�����ݎg�p�̋���
			mnu_zenkesi.Enabled = blnUsableButton
			mnu_zenkaijo.Enabled = blnUsableButton
			'�����p�l���̃��b�N
			'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition1.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pnl_condition1.Enabled = False
			'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition2.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pnl_condition2.Enabled = False
			
			
			'*** 2009/09/16 ADD START FKS)NAKATA
			'�ԕi���z�̍l��
			getHenpinKingaku()
			'*** 2009/09/16 ADD E.N.D FKS)NAKATA
			
			
		End If
		' === 20130708 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
STEP10_ShowBody: 
		' === 20130708 === INSERT E
		
		
		
		'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		spd_body.ReDraw = True
		
		
		'���گ�޲���Ă̋���
		blnUsableSpread = True
		
		'�}�E�X�J�[�\����W���ɖ߂�
		'UPGRADE_ISSUE: vbNormal ���A�b�v�O���[�h����萔������ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: Form �v���p�e�B FR_SSSMAIN.MousePointer �̓J�X�^�� �}�E�X�|�C���^���T�|�[�g���܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' ���N���b�N���Ă��������B
		Me.Cursor = vbNormal
	End Sub
	
	'�w�b�_��(�������)�̕\��
	Public Sub showHead()
		
		Dim intZankn As Decimal '���������x�܂ł̏����c�z�v
		Dim intKesikn As Decimal '�o�������ȍ~�̏����z
		Dim intTesuryo As Decimal '���������x�̎萔���z���i�[
		Dim intSyohi As Decimal '���������x�̏���Ŋz���i�[
		
		Dim tmp As Decimal
		Dim i As Short
		
		
		intZankn = 0
		intKesikn = 0
		intTesuryo = 0
		intSyohi = 0
		
		
		'�r�����Ə������z�����擾
		Call getHaitaAndKnSum(DB_TOKMTA.TOKSEICD, Get_Acedt(gstrKesidt.Value), DB_TOKMTA.SHAKB)
		
		
		'���������x�܂ł̏����c�z�v
		For i = 0 To 9
			intZankn = intZankn + ARY_NKSSMB_KS(i).KSKZANKN
		Next i
		
		'�o�������ȍ~�̏����z
		For i = 0 To 9
			intKesikn = intKesikn + ARY_NKSSMB_KS(i).SSANYUKN - ARY_NKSSMB_KS(i).KSKNYKKN
		Next i
		
		'���������x�̎萔���E����Ŋz���i�[
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		i = SSSVal(TesuryoID)
		intTesuryo = ARY_NKSSMB_KS(i).KSKZANKN + ARY_NKSSMB_KS(i).SSANYUKN - ARY_NKSSMB_KS(i).KSKNYKKN 'SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & TesuryoID, ""))
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		i = SSSVal(SyohiID)
		intSyohi = ARY_NKSSMB_KS(i).KSKZANKN + ARY_NKSSMB_KS(i).SSANYUKN - ARY_NKSSMB_KS(i).KSKNYKKN 'SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & TesuryoID, ""))
		
		
		'���㍇�v���z�̕\��
		txt_urigoukei.Text = VB6.Format(intUrigoukei, "###,###,##0")
		
		'�����z�E�萔���z�E����Ŋz�̕\��
		tmp = intZankn + intKesikn
		If tmp - (intTesuryo + intSyohi) > 0 Then
			txt_nyukin.Text = VB6.Format(tmp - (intTesuryo + intSyohi), "#,###,##0")
			txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
			txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
			'�c���v���X�̂Ƃ�
		ElseIf tmp > 0 Then 
			If intTesuryo > 0 Then
				If intSyohi > 0 Then
					'�c�z���v���X�ŁA�萔�����A����ō��z���v���X�̎�
					If tmp - intTesuryo > 0 Then
						txt_nyukin.Text = VB6.Format(0, "#,###,##0")
						txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
						txt_syohi.Text = VB6.Format(tmp - intTesuryo, "#,###,##0")
					Else
						txt_nyukin.Text = VB6.Format(0, "#,###,##0")
						txt_tesuryo.Text = VB6.Format(tmp, "#,###,##0")
						txt_syohi.Text = VB6.Format(0, "#,###,##0")
					End If
					
				ElseIf intSyohi <= 0 Then 
					'�c�z���v���X�ŁA�萔�����v���X�A����ō��z���}�C�i�X�̎�
					txt_nyukin.Text = VB6.Format(0, "#,###,##0")
					txt_tesuryo.Text = VB6.Format(tmp - intSyohi, "#,###,##0")
					txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
				End If
				
			ElseIf intTesuryo <= 0 Then 
				If intSyohi > 0 Then
					'�c�z���v���X�ŁA�萔�ʂ��}�C�i�X�A����ō��z���v���X�̎�
					txt_nyukin.Text = VB6.Format(0, "#,###,##0")
					txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
					txt_syohi.Text = VB6.Format(tmp - intTesuryo, "#,###,##0")
				ElseIf intSyohi <= 0 Then 
					'�c�z���v���X�ŁA�萔�����A����ō��z���}�C�i�X�̎�
					'tmp - (intTesuryo + intSyohi) �͐�΂ɐ��Ȃ̂ŁA�����ɏ����͕s�v
				End If
			End If
			
			'�c�����̎�
		ElseIf tmp <= 0 Then 
			If intTesuryo > 0 Then
				If intSyohi > 0 Then
					'�c�z���}�C�i�X�ŁA�萔�����A����ō��z���v���X�̎�
					txt_nyukin.Text = VB6.Format(tmp, "#,###,##0")
					txt_tesuryo.Text = VB6.Format(0, "#,###,##0")
					txt_syohi.Text = VB6.Format(0, "#,###,##0")
				ElseIf intSyohi <= 0 Then 
					'�c�z���}�C�i�X�ŁA�萔�����v���X�A����ō��z���}�C�i�X�̎�
					If tmp + intTesuryo + intSyohi > 0 Then
						txt_nyukin.Text = VB6.Format(0, "#,###,##0")
						txt_tesuryo.Text = VB6.Format(tmp - intSyohi, "#,###,##0")
						txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
					Else
						txt_nyukin.Text = VB6.Format(tmp - intSyohi, "#,###,##0")
						txt_tesuryo.Text = VB6.Format(0, "#,###,##0")
						txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
					End If
				End If
			ElseIf intTesuryo <= 0 Then 
				If intSyohi > 0 Then
					'�c�z���}�C�i�X�ŁA�萔�ʂ��}�C�i�X�A����ō��z���v���X�̎�
					If tmp + intTesuryo + intSyohi > 0 Then
						txt_nyukin.Text = VB6.Format(0, "#,###,##0")
						txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
						txt_syohi.Text = VB6.Format(tmp - intTesuryo, "#,###,##0")
					Else
						txt_nyukin.Text = VB6.Format(tmp - intTesuryo, "#,###,##0")
						txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
						txt_syohi.Text = VB6.Format(0, "#,###,##0")
					End If
				ElseIf intSyohi <= 0 Then 
					'�c�z���}�C�i�X�ŁA�萔�����A����ō��z���}�C�i�X�̎�
					txt_nyukin.Text = VB6.Format(tmp - (intTesuryo + intSyohi), "#,###,##0")
					txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
					txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
				End If
			End If
		End If
		
		'�������v�z�̕\��
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(txt_syohi.Text) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(txt_tesuryo.Text) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		tmp = SSSVal((txt_nyukin.Text)) + SSSVal((txt_tesuryo.Text)) + SSSVal((txt_syohi.Text))
		txt_nyugoukei.Text = VB6.Format(tmp, "###,###,##0")
		
		'�����c�z�̕\��
		txt_kesizan.Text = VB6.Format(intZankn + intKesikn, "###,###,##0")
		
	End Sub
	
	'���ו����v���z�̎擾
	Private Function getBodyKesikei(ByRef strColName As String) As Decimal
		Dim i As Short
		Dim intKesikei As Decimal
		Dim tmp As Object
		
		intKesikei = 0
		blnUsableSpread = False
		With spd_body
			For i = 1 To intMaxRow
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.GetText(strColName, i, tmp)
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				intKesikei = intKesikei + SSSVal(tmp)
			Next i
		End With
		blnUsableSpread = True
		
		getBodyKesikei = intKesikei
	End Function
	
	
	'�r�����Ə������z�����擾�A�O���[�o���ϐ��Ɋi�[
	Private Sub getHaitaAndKnSum(ByVal pin_strTOKCD As String, ByVal pin_strSMADT As String, ByVal pin_strSHAKB As String)
		Dim strSql As Object
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim i As Short
		
		'���������x�̏�����Ԃ��擾
		
		'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSql = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSql = strSql & " SELECT * "
		'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSql = strSql & "   FROM NKSSMB "
		'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSql = strSql & "  WHERE TOKCD = '" & CF_Ora_Sgl(pin_strTOKCD) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSql = strSql & "    AND SMADT = '" & CF_Ora_Sgl(DeCNV_DATE(pin_strSMADT)) & "' "
		
		'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		'���������T�}���[�̔r�����擾
		ReDim ARY_NKSSMB_HAITA(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ARY_NKSSMB_HAITA(1).TOKCD = CStr(CF_Ora_GetDyn(Usr_Ody, "TOKCD", ""))
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ARY_NKSSMB_HAITA(1).SMADT = CStr(CF_Ora_GetDyn(Usr_Ody, "SMADT", ""))
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ARY_NKSSMB_HAITA(1).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "OPEID", ""))
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ARY_NKSSMB_HAITA(1).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "CLTID", ""))
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ARY_NKSSMB_HAITA(1).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ARY_NKSSMB_HAITA(1).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))
		
		'���������T�}���̏����\���̔z��֎擾
		ReDim ARY_NKSSMB_KS(9)
		For i = 0 To 9
			With ARY_NKSSMB_KS(i)
				.UPDID = VB6.Format(i, "00")
				
				If i <> 8 Then
					If CF_Ora_EOF(Usr_Ody) = False Then
						'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.SSANYUKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & .UPDID, ""))
						'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.KSKNYKKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN" & .UPDID, ""))
						'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.KSKZANKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN" & .UPDID, ""))
					End If
				Else
					'09�F�{���� �́A����ɂ��Ȃ�
					.SSANYUKN = 0
					.KSKNYKKN = 0
					.KSKZANKN = 0
				End If
				
				'����敪�̐ݒ�
				Select Case i
					Case 0 : .DATKB = "01" '01�F����
					Case 1 : .DATKB = "02" '02�F�U��
					Case 2 : .DATKB = "03" '03�F��`
					Case 3 : .DATKB = "04" '04�F���E
					Case 4 : .DATKB = "05" '05�F�l��
					Case 5 : .DATKB = "06" '06�F�萔
					Case 6 : .DATKB = "07" '07�F��
					Case 7 : .DATKB = "08" '08�F�U����
					Case 8 : .DATKB = "09" '09�F�{����
					Case 9 : .DATKB = "99" '99�F����
				End Select
				
				
				'���������̐ݒ�i-1 �͏����Ȃ��j
				' �@���E���A����Ł��B�萔�����C�������D�U�����E��`���F�U�������G�l�������H��
				Select Case i
					Case 0 : .SEQ = 4 '����敪��01�F����
					Case 1 : .SEQ = 5 '����敪��02�F�U��
					Case 2 : .SEQ = 6 '����敪��03�F��`
					Case 3 : .SEQ = 1 '����敪��04�F���E
					Case 4 : .SEQ = 8 '����敪��05�F�l��
					Case 5 : .SEQ = 3 '����敪��06�F�萔
					Case 6 : .SEQ = 9 '����敪��07�F��
					Case 7 : .SEQ = 7 '����敪��08�F�U����
					Case 8 : .SEQ = -1 '����敪��09�F�{����
					Case 9 : .SEQ = 2 '����敪��99�F����
				End Select
				
			End With
		Next i
		
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		
		For i = 0 To 9
			'�c�����v�Z����
			With ARY_NKSSMB_KS(i)
				.ZAN_KIN = .SSANYUKN - .KSKNYKKN + .KSKZANKN
			End With
		Next i
	End Sub
	
	
	'�S�������j���[�N���b�N��
	Public Sub mnu_zenkaijo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_zenkaijo.Click
		cmd_zenkaijo_Click()
	End Sub
	
	'�S�I�����j���[�N���b�N��
	Public Sub mnu_zenkesi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_zenkesi.Click
		cmd_zenkesi_Click()
	End Sub
	
	Private Sub opt_sort_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles opt_sort.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = opt_sort.GetIndex(eventSender)
		
		
		'�t�@���N�V�����L�[������
		If KeyCode >= System.Windows.Forms.Keys.F1 And KeyCode <= System.Windows.Forms.Keys.F12 Then
			'�t�@���N�V�����L�[���ʏ���
			Call CF_FuncKey_Execute(KeyCode, Shift)
		End If
		
		
	End Sub
	
	'�w�b�_�p�l���}�E�X���[�u��
	Private Sub pnl_head_MouseMove(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		'�q���g�̕\��������������
		img_light.Image = img_bklight(0).Image
		txt_message.Text = ""
	End Sub
	
	'�A�C�R��[�I��]�N���b�N��
	Private Sub img_exit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles img_exit.Click
		Me.Close()
	End Sub
	'�A�C�R��[�I��]�}�E�X�_�E����
	Private Sub img_exit_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_exit.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_exit.Image = img_bkexit(1).Image
	End Sub
	'�A�C�R��[�I��]�}�E�X���[�u��
	Private Sub img_exit_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_exit.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_light.Image = img_bklight(1).Image
		txt_message.Text = "���j���[�ɖ߂�܂��B"
	End Sub
	'�A�C�R��[�I��]�}�E�X�A�b�v��
	Private Sub img_exit_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_exit.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_exit.Image = img_bkexit(0).Image
	End Sub
	
	'�A�C�R��[�o�^]�N���b�N��
	Private Sub img_resist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles img_resist.Click
		mnu_regist_Click(mnu_regist, New System.EventArgs())
	End Sub
	'�A�C�R��[�o�^]�}�E�X�_�E����
	Private Sub img_resist_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_resist.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_resist.Image = img_bkresist(1).Image
	End Sub
	'�A�C�R��[�o�^]�}�E�X���[�u��
	Private Sub img_resist_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_resist.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_light.Image = img_bklight(1).Image
		txt_message.Text = "�o�^���܂��B"
	End Sub
	'�A�C�R��[�o�^]�}�E�X�A�b�v��
	Private Sub img_resist_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_resist.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_resist.Image = img_bkresist(0).Image
	End Sub
	
	'�A�C�R��[����]�N���b�N��
	Private Sub img_showwnd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles img_showwnd.Click
		mnu_showwnd_Click(mnu_showwnd, New System.EventArgs())
	End Sub
	'�A�C�R��[����]�}�E�X�_�E����
	Private Sub img_showwnd_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_showwnd.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_showwnd.Image = img_bkshowwnd(1).Image
	End Sub
	'�A�C�R��[����]�}�E�X���[�u��
	Private Sub img_showwnd_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_showwnd.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_light.Image = img_bklight(1).Image
		txt_message.Text = "�E�B���h�E��\�����܂��B"
	End Sub
	'�A�C�R��[����]�}�E�X�A�b�v��
	Private Sub img_showwnd_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_showwnd.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_showwnd.Image = img_bkshowwnd(0).Image
	End Sub
	
	'�A�C�R��[����]�N���b�N��
	Private Sub img_unlock_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles img_unlock.Click
		
		If blnUsableButton = True Then
			blnUsableButton = False
			'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition1.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pnl_condition1.Enabled = True
			'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition2.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pnl_condition2.Enabled = True
			initHead()
			initBody()
			txt_kesidt.Focus()
			intInputMode = 1
			' === 20130708 === INSERT S - FWEST)Koroyasu �r������̉���
			Call SSSWIN_Unlock_EXCTBZ()
			' === 20130708 === INSERT E -
		End If
		
	End Sub
	'�A�C�R��[����]�}�E�X�_�E����
	Private Sub img_unlock_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_unlock.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_unlock.Image = img_bkunlock(1).Image
	End Sub
	'�A�C�R��[����]�}�E�X���[�u��
	Private Sub img_unlock_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_unlock.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_light.Image = img_bklight(1).Image
		txt_message.Text = "��ʂ��N���A���ăR�[�h�̓��͂�҂��܂��B"
	End Sub
	'�A�C�R��[����]�}�E�X�A�b�v��
	Private Sub img_unlock_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_unlock.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_unlock.Image = img_bkunlock(0).Image
	End Sub
	
	'���j���[[����]�|[�I��]�I����
	Public Sub mnu_exit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_exit.Click
		Me.Close()
	End Sub
	
	'���j���[[����]�|[�o�^]�I����
	Public Sub mnu_regist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_regist.Click
		
		Dim intRtn As Short
		
		
		'�w�b�_���̓��̓`�F�b�N
		If chkCondition = False Then Exit Sub
		'���ו��̓��̓`�F�b�N
		If blnUsableButton = False Then
			showMsg("0", "_UPDATE", "2") '�����ו������͂�MSG
			Exit Sub
		End If
		
		
		'�ԕi�����̂Ȃ�������`�F�b�N
		If chkAkaKro = False Then
			Exit Sub
		End If
		
		'**** 2009/09/16 DEL START FKS)NAKATA
		'���[�Ή��̂��߃`�F�b�N���O��
		''    '������z�Ə[�����z�̃`�F�b�N
		''    If chkUrikn = False Then
		''        Exit Sub
		''    End If
		''
		''
		''    '�`�[�P�ʂł̏[���`�F�b�N
		''    If chkJdntrkb = False Then
		''        Exit Sub
		''    End If
		'**** 2009/09/16 DEL E.N.D FKS)NAKATA
		
		
		'�������o�^����Ă��邩�̃`�F�b�N
		If chkNyukn = False Then
			Exit Sub
		End If
		
		
		'��`�������Ă���ꍇ�͐U�������̓��̓`�F�b�N
		If chkFurikomiDT = False Then
			Exit Sub
		End If
		
		
		
		'���o�^�m�F��MSG
		If showMsg("0", "_UPDATE", CStr(0)) = MsgBoxResult.Yes Then
			'�������̔��f
			If gs_UPDAUTH = "9" And AUTHORITY_ENABLE = True Then
				showMsg("2", "UPDAUTH", "0")
				Exit Sub
			End If
			
			'�r���`�F�b�N
			If VB.Left(SSSEXC_EXCTBZ_CHECK, 1) = "9" Then
				MsgBox("�y" & Trim(Mid(SSSEXC_EXCTBZ_CHECK, 2, 30)) & "�z���N�����ł��B" & Trim(SSS_PrgNm) & "����͂��鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
				'            Call HD_CLEAR
				'            Call P_vaData_Init
				Exit Sub
			Else
				Call SSSEXC_EXCTBZ_OPEN()
			End If
			
			
			Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
			
			'�X�V����
			'UPGRADE_WARNING: mnu_regist_Click �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
			
			Me.Cursor = System.Windows.Forms.Cursors.Default
			
			
		End If
		
	End Sub
	
	'���j���[[�ҏW]�|[��ʏ�����]�I����
	Public Sub mnu_initdsp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_initdsp.Click
		
		intInputMode = 9
		'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition1.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pnl_condition1.Enabled = True
		'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition2.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pnl_condition2.Enabled = True
		'��ʂ̏�����
		initCondition()
		initHead()
		initBody()
		'�������Ƀt�H�[�J�X���ړ�
		txt_kesidt.Focus()
		txt_kesidt.BackColor = System.Drawing.Color.Yellow
		blnINIT_FLG = True
		' === 20130708 === INSERT S - FWEST)Koroyasu �r������̉���
		Call SSSWIN_Unlock_EXCTBZ()
		' === 20130708 === INSERT E -
		
	End Sub
	
	
	'���j���[[����]�|[���̈ꗗ]
	Public Sub mnu_showwnd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_showwnd.Click
		'�������Ƀt�H�[�J�X������Ƃ�
		'UPGRADE_ISSUE: Control Name �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		If Me.ActiveControl.Name = txt_kesidt.Name Then
			cmd_kesidt_Click()
			
			'�����溰�ނɃt�H�[�J�X������Ƃ�
			'UPGRADE_ISSUE: Control Name �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		ElseIf Me.ActiveControl.Name = txt_tokseicd.Name Then 
			cmd_tokseicd_Click()
			
			
			'����\����Ƀt�H�[�J�X������Ƃ�
			'UPGRADE_ISSUE: Control Name �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		ElseIf Me.ActiveControl.Name = txt_kaidt_From.Name Then 
			Call cmd_kaidt_From_Click()
			
			'����\����Ƀt�H�[�J�X������Ƃ�
			'UPGRADE_ISSUE: Control Name �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		ElseIf Me.ActiveControl.Name = txt_kaidt_To.Name Then 
			Call cmd_kaidt_To_Click()
			
			
			'�U�������Ƀt�H�[�J�X������Ƃ�
			'UPGRADE_ISSUE: Control Name �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		ElseIf Me.ActiveControl.Name = txt_fridt.Name Then 
			cmd_fridt_Click()
		End If
	End Sub
	
	
	
	Private Sub spd_body_Change(ByVal Col As Integer, ByVal Row As Integer)
		Dim spd_fridt As String
		Dim spd_fridt_val As Object
		Dim ret As Boolean
		Dim lw_col As Integer
		Dim lw_row As Integer
		
		If Col = 14 Then '�����U�����̃`�F�b�N
			
			lw_col = Col
			lw_row = Row
			'�o�������ȑO�̓��t�̎��̓G���[
			'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ret = spd_body.GetText(Col, Row, spd_fridt_val)
			If ret = True Then
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_fridt_val �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				spd_fridt = VB6.Format(spd_fridt_val, "yyyy/mm/dd")
				If Trim(spd_fridt) = "" Then
					blnUsableButton = True
				End If
				If DeCNV_DATE(spd_fridt) <= DB_SYSTBA.SMAUPDDT Then
					Call showMsg("1", "URKET73_010", CStr(0)) '���o�����ߍς݂�MSG
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					spd_body.Col = lw_col
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					spd_body.Row = lw_row
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.ForeColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					spd_body.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Action �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					spd_body.Action = 0
					blnUsableButton = False
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					spd_body.Col = Col
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					spd_body.Row = Row
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.ForeColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					spd_body.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					spd_body.Row = Row + 1
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Action �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					spd_body.Action = 0
					blnUsableButton = True
				End If
			End If
		End If
	End Sub
	
	Private Sub spd_body_KeyDown(ByRef KeyCode As Short, ByRef Shift As Short)
		
		
		'�t�@���N�V�����L�[������
		If KeyCode >= System.Windows.Forms.Keys.F1 And KeyCode <= System.Windows.Forms.Keys.F12 Then
			'�t�@���N�V�����L�[���ʏ���
			Call CF_FuncKey_Execute(KeyCode, Shift)
		End If
		
		
	End Sub
	
	Private Sub txt_fridt_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txt_fridt.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'���̓`�F�b�N
		chkFridt()
		
		'�w�i�F�𔒂ɖ߂�
		txt_fridt.BackColor = System.Drawing.Color.White
		
		eventArgs.Cancel = Cancel
	End Sub
	
	
	'�����溰�ލ��ڂ�ύX������
	'UPGRADE_WARNING: �C�x���g txt_tokseicd.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txt_tokseicd_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_tokseicd.TextChanged
		Dim p As Short
		
		'�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
		If blnUsableEvent = False Then Exit Sub
		
		blnUsableEvent = False
		p = txt_tokseicd.SelectionStart
		
		'�S�p���폜����
		txt_tokseicd.Text = delZenkaku((txt_tokseicd.Text))
		'���͒l��5byte�Ŗ������͋󔒖���
		txt_tokseicd.Text = txt_tokseicd.Text & Space(5 - Len(txt_tokseicd.Text))
		
		txt_tokseicd.SelectionStart = p
		blnUsableEvent = True
		
		'�J�[�\�����E�[�Ɉړ��������́A���̍��ڂֈړ�
		If txt_tokseicd.SelectionStart = 5 Then
			intChkKb = 1 '�������溰�ނ̓��̓`�F�b�N
			
			'���̓`�F�b�N
			If chkTokseicd = True Then
				'������
				txt_kaidt_From.Focus()
			End If
			
		End If
		txt_tokseicd.SelectionLength = 1
		
	End Sub
	
	'�����溰�ލ��ڂɃt�H�[�J�X���ڂ�����
	Private Sub txt_tokseicd_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_tokseicd.Enter
		'�擪�ʒu��I����Ԃɂ���
		txt_tokseicd.SelectionStart = 0
		txt_tokseicd.SelectionLength = 1
		'�w�i�F�����F�ɂ���
		txt_tokseicd.BackColor = System.Drawing.Color.Yellow
		'�������������s�\�Ƃ���
		mnu_showwnd.Enabled = True
	End Sub
	
	
	'�����溰�ލ��ڂŃL�[����������
	Private Sub txt_tokseicd_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_tokseicd.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		'�L�[���͐���
		Select Case Ctl_tokseicd_KeyDown(KeyCode, Shift, txt_tokseicd)
			Case 0
				'�������Ȃ�
			Case 1
				'���̓`�F�b�N
				If chkTokseicd = True Then
					'������
					txt_kaidt_From.Focus()
				End If
			Case 2
				'���̓`�F�b�N
				If chkTokseicd = True Then
					'�O����
					txt_kesidt.Focus()
				End If
		End Select
		
		KeyCode = 0
		
	End Sub
	
	
	'�����溰�ލ��ڂŃL�[����������
	Private Sub txt_tokseicd_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_tokseicd.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'�A���t�@�x�b�g��������啶���ɕϊ�����
		If Chr(KeyAscii) Like "[a-z]" Then
			KeyAscii = KeyAscii - 32
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'�����溰�ލ��ڂ���t�H�[�J�X���ڂ�����
	Private Sub txt_tokseicd_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_tokseicd.Leave
		
		'�w�i�F�𔒂ɖ߂�
		txt_tokseicd.BackColor = System.Drawing.Color.White
		
	End Sub
	
	
	'�����ς��ް��\�����ڂ�ύX������
	'UPGRADE_WARNING: �C�x���g txt_kesikb.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txt_kesikb_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesikb.TextChanged
		If CDbl(txt_kesikb.Text) <> 9 Then
			txt_kesikb.Text = CStr(1)
		End If
		txt_kesikb.SelectionStart = 0
		txt_kesikb.SelectionLength = 1
		
		If CDbl(txt_kesikb.Text) = 1 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g cmd_kaidt_From.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			cmd_kaidt_From.Caption = " �����(�J�n)"
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g cmd_kaidt_From.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			cmd_kaidt_From.Caption = " *�����(�J�n)"
		End If
		
	End Sub
	
	'�����ς��ް��\�����ڂɃt�H�[�J�X���ڂ�����
	Private Sub txt_kesikb_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesikb.Enter
		'�I����Ԃɂ���
		txt_kesikb.SelectionStart = 0
		txt_kesikb.SelectionLength = 1
		'�w�i�F�����F�ɂ���
		txt_kesikb.BackColor = System.Drawing.Color.Yellow
		'�������������s�s�Ƃ���
		mnu_showwnd.Enabled = False
	End Sub
	
	'�����ς��ް��\�����ڂŃL�[����������
	Private Sub txt_kesikb_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_kesikb.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		'�t�@���N�V�����L�[������
		If KeyCode >= System.Windows.Forms.Keys.F1 And KeyCode <= System.Windows.Forms.Keys.F12 Then
			'�t�@���N�V�����L�[���ʏ���
			Call CF_FuncKey_Execute(KeyCode, Shift)
		End If
		
		
		'���� or ����󉟉���
		If KeyCode = System.Windows.Forms.Keys.Up Or KeyCode = System.Windows.Forms.Keys.Left Then
			txt_kaidt_To.Focus()
			
			'Enter or ����� or �E��󉟉���
		ElseIf KeyCode = System.Windows.Forms.Keys.Return Or KeyCode = System.Windows.Forms.Keys.Down Or KeyCode = System.Windows.Forms.Keys.Right Then 
			'������̎x���������U�������A̧���ݸނ̎��͐U�������ɍ��ڈړ�
			'����ȊO�͏����Ώۂ�����
			If blnFriEnabled = True Then
				txt_fridt.Focus()
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetFocus �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				spd_body.SetFocus()
			End If
			
			'TAB��
		ElseIf KeyCode = System.Windows.Forms.Keys.F16 Then 
			'������̎x���������U�������A̧���ݸނ̎��͐U�������ɍ��ڈړ�
			'����ȊO�͏����Ώۂ�����
			If blnFriEnabled = True Then
				txt_fridt.Focus()
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetFocus �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				spd_body.SetFocus()
			End If
			
			
			
			'TAB��
		ElseIf KeyCode = System.Windows.Forms.Keys.F15 Then 
			txt_kaidt_To.Focus()
			
			
		End If
		
		KeyCode = 0
	End Sub
	
	'�����ς��ް��\�����ڂŃL�[����������
	Private Sub txt_kesikb_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_kesikb.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'���l�̂ݓ��͉Ƃ���
		If Not Chr(KeyAscii) Like "[0-9]" Then
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'�����ς��ް��\�����ڂ���t�H�[�J�X���ڂ�����
	Private Sub txt_kesikb_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesikb.Leave
		'�w�i�F�𔒂ɖ߂�
		txt_kesikb.BackColor = System.Drawing.Color.White
	End Sub
	
	'=======================================================���ו�(�X�v���b�h)=======================================================
	
	'�t�H�[�J�X�擾��
	Private Sub spd_body_GotFocus()
		
		If intInputMode <> 1 Then
			Exit Sub
		End If
		
		'���݂��g�p�\(�����ް�����)�̎��͎��s���Ȃ�
		If blnUsableButton = True Then Exit Sub
		
		'�w�b�_�����͂���Ă�����f�[�^�������E�\������
		If chkCondition = True Then
			
			intInputMode = 2
			
			showBody() '���ް��\��
			
			'�ԕi���������A���b�N
			'�O��ł́A�����`�F�b�N�@�\���g�p���Ȃ��B(�L���ɂ���ꍇ�̓R�����g���O���Ă�������)
			'lockHenpin
			
		End If
	End Sub
	
	'�������ݸد���
	Private Sub spd_body_ButtonClicked(ByVal Col As Integer, ByVal Row As Integer, ByVal ButtonDown As Short)
		
		Dim intKesizan As Decimal '�w�b�_�������c�z
		Dim intKomikn As Decimal '�ō�����z
		Dim intKesikn As Decimal '�����z
		Dim intBfKesikn As Decimal '�����z(�����O)
		Dim tmp As Object
		
		Dim LS_HYFRIDT As Object
		Dim sumHenpin As Decimal
		Dim intJDNNOKesikn As Decimal
		Dim intHenkn As Decimal
		Dim strHyjdnno As String
		Dim str_theHYJDNNO As String
		Dim intchk As Short
		Dim idxRowJDNNO As Integer
		
		'*** 2009/09/03 ADD START FKS)NAKATA V1.03
		Dim strBfHYFRIDT As String
		'*** 2009/09/03 ADD E.N.D FKS)NAKATA
		
		
		
		'�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
		If blnUsableSpread = False Then
			Exit Sub
		End If
		
		
		On Error Resume Next
		
		With spd_body
			'�����ޯ���د����A���ׂ̋��z�A�w�b�_�̎c���z�ɉ����ă`�F�b�N��ON�AOFF���s��
			If Col = 1 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.Col = Col
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.Row = Row
				
				'�\���s�ȏ�̍s���N���b�N�������̓`�F�b�N�͂��Ȃ�
				If Row > intMaxRow Then
					'�����������Ȃ�
					blnUsableSpread = False
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Value = 0
					blnUsableSpread = True
					Exit Sub
				End If
				
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				intKesizan = SSSVal((txt_kesizan.Text))
				
				'�ō�����z���擾
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call .GetText(COL_KOMIKN, .Row, tmp)
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				intKomikn = SSSVal(tmp)
				
				'���ו������z
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call .GetText(COL_KESIKN, .Row, tmp)
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				intKesikn = SSSVal(tmp)
				
				'�������t���Ă��āA����������
				If ButtonDown = 0 Then
					
					'�����z���v���X�ł���΁A�������Ƀw�b�_���ɉ��Z
					If intKesikn - intBfKesikn > 0 Then
						txt_kesizan.Text = VB6.Format(intKesizan + (intKesikn - intBfKesikn), "###,###,##0")
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.SetText(COL_KESIKN, .Row, intBfKesikn)
						
						
						If DB_TOKMTA.SHAKB Like "[256]" Then
							'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							.GetText(COL_HYFRIDT, .Row, LS_HYFRIDT)
							'UPGRADE_WARNING: �I�u�W�F�N�g LS_HYFRIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If Trim(LS_HYFRIDT) <> "" Then
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.SetText(COL_HYFRIDT, .Row, "")
							End If
						End If
						
						
					ElseIf intKesizan >= intBfKesikn - intKesikn Then 
						txt_kesizan.Text = VB6.Format(intKesizan + (intKesikn - intBfKesikn), "###,###,##0")
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.SetText(COL_KESIKN, .Row, intBfKesikn)
						
						
						If DB_TOKMTA.SHAKB Like "[256]" Then
							'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							.GetText(COL_HYFRIDT, .Row, LS_HYFRIDT)
							'UPGRADE_WARNING: �I�u�W�F�N�g LS_HYFRIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If Trim(LS_HYFRIDT) <> "" Then
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.SetText(COL_HYFRIDT, .Row, "")
							End If
						End If
						
					Else
						'�����������Ȃ�
						blnUsableSpread = False
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Value = 1
						blnUsableSpread = True
					End If
					
					
					'�������t���Ă��Ȃ��āA�`�F�b�N����ꂽ��
				ElseIf ButtonDown = 1 Then 
					
					'�����z���}�C�i�X�ł���Τ�������Ƀw�b�_���ɉ��Z
					If intKomikn - intKesikn < 0 Then
						txt_kesizan.Text = VB6.Format(intKesizan - (intKomikn - intKesikn), "###,###,##0")
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.SetText(COL_KESIKN, .Row, intKomikn)
						
						If DB_TOKMTA.SHAKB Like "[256]" Then
							'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							.GetText(COL_HYFRIDT, .Row, LS_HYFRIDT)
							
							'UPGRADE_WARNING: �I�u�W�F�N�g LS_HYFRIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If Trim(LS_HYFRIDT) = "" Then
								'*** 2009/09/03 CHG START FKS)NAKATA V1.03
								'.SetText COL_HYFRIDT, .Row, txt_fridt.Text
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Call .GetText(COL_BFHYFRIDT, .Row, tmp)
								'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								strBfHYFRIDT = tmp
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.SetText(COL_HYFRIDT, .Row, strBfHYFRIDT)
								'*** 2009/09/03 CHG START FKS)NAKATA
							End If
						End If
						'�w�b�_�����c�����̎��̓`�F�b�N�����Ȃ�
					ElseIf intKesizan <= 0 Then 
						
						
						blnUsableSpread = False
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Value = 0
						blnUsableSpread = True
						
					ElseIf intKesizan >= intKomikn - intKesikn Then 
						txt_kesizan.Text = VB6.Format(intKesizan - (intKomikn - intKesikn), "###,###,##0")
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.SetText(COL_KESIKN, .Row, intKomikn)
						
						If DB_TOKMTA.SHAKB Like "[256]" Then
							'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							.GetText(COL_HYFRIDT, .Row, LS_HYFRIDT)
							'UPGRADE_WARNING: �I�u�W�F�N�g LS_HYFRIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If Trim(LS_HYFRIDT) = "" Then
								'*** 2009/09/03 CHG START FKS)NAKATA V1.03
								'.SetText COL_HYFRIDT, .Row, txt_fridt.Text
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Call .GetText(COL_BFHYFRIDT, .Row, tmp)
								'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								strBfHYFRIDT = tmp
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.SetText(COL_HYFRIDT, .Row, strBfHYFRIDT)
								'*** 2009/09/03 CHG START FKS)NAKATA
							End If
						End If
					Else
						
						'�ꕔ�[���̋֎~ (�ō�������z <> �[�����z�̏ꍇ)
						Call showMsg("1", "URKET73_041", CStr(0)) '�ꕔ�[���͂ł��܂���B
						blnUsableSpread = False
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Value = 0
						blnUsableSpread = True
						
						''�ꕔ�[���������ꍇ�́A�ȉ��̃R�����g���O��
						''DEL START (��)
						'                        txt_kesizan.Text = Format(0, "###,###,##0")
						''                        .SetText COL_KESIKN, .Row, intKesikn + intKesizan
						''
						''                        If DB_TOKMTA.SHAKB Like "[256]" Then
						''                            .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
						''                            If Trim$(LS_HYFRIDT) = "" Then
						''                                .SetText COL_HYFRIDT, .Row, txt_fridt.Text
						''                            End If
						''                        End If
						''DEL START (��)
						
					End If
				End If
			End If
		End With
	End Sub
	
	'================================================================
	'2009/06/12 DEL START FKS)NAKATA
	
	'�萔�p�E����Ŋz�̓o�^�́A�{�����ł͍s��Ȃ��B
	'�{�������g�p����ꍇ�́A�R�����g�A�E�g���O��
	'�upnl_tesuryo�v�upnl_syohizei�v���t�H�[������폜���Ă��������B
	'�p�l���̉��Ƀ{�^�����B���Ă��܂��B
	
	
	''�萔�����ݎ��s��
	'Private Sub cmd_tesuryo_Click()
	'
	'    Dim tmp             As Variant
	'    Dim intchk          As Long
	'    Dim idxRow          As Long
	'    Dim idxRowJDNNO     As Long
	'
	'    Dim kesizan         As Currency '�w�b�_�������c�z
	'    Dim kesikn          As Currency '���׍s�̓����ϊz
	'
	'
	'    '�׸ނ������Ă��Ȃ���Ύ��s���Ȃ�
	'    If blnUsableButton = False Then Exit Sub
	'
	'    '�����z������ʂ̕\��
	''    FR_SSSSUB.Show (vbModal)
	'
	'
	'    '�w�b�_���̍ĕ\��
	'    showHead
	
	'    '�w�b�_�������c�z�̑ޔ�
	'    kesizan = txt_kesizan.Text
	'
	'    With spd_body
	'        For idxRow = 1 To intMaxRow
	'            '�`�F�b�N�������Ă��邩���m�F
	'            .GetText COL_CHK, idxRow, tmp
	'            intchk = SSSVal(tmp)
	'
	'            '�`�F�b�N�������Ă���ꍇ
	'            If intchk = 1 Then
	'                '�����z�̎擾
	'                Call .GetText(COL_KESIKN, idxRow, tmp)
	'                kesikn = kesikn + CCur(tmp)
	'            End If
	'
	'       Next idxRow
	'    End With
	'
	'    txt_kesizan.Text = Format(kesizan - kesikn, "###,###,##0")
	'
	'End Sub
	'
	''����Ŋz���ݎ��s��
	'Private Sub cmd_syohi_Click()
	'
	'
	'    Dim tmp             As Variant
	'    Dim intchk          As Long
	'    Dim idxRow          As Long
	'    Dim idxRowJDNNO     As Long
	'
	'    Dim kesizan         As Currency '�w�b�_�������c�z
	'    Dim kesikn          As Currency '���׍s�̓����ϊz
	'
	'
	'    '�׸ނ������Ă��Ȃ���Ύ��s���Ȃ�
	'    If blnUsableButton = False Then Exit Sub
	'
	'    '�����z������ʂ̕\��
	'    FR_SSSSUB.Show (vbModal)
	'
	'
	'    '�w�b�_���̍ĕ\��
	'    showHead
	'
	'    '�w�b�_�������c�z�̑ޔ�
	'    kesizan = txt_kesizan.Text
	'
	'    With spd_body
	'        For idxRow = 1 To intMaxRow
	'            '�`�F�b�N�������Ă��邩���m�F
	'            .GetText COL_CHK, idxRow, tmp
	'            intchk = SSSVal(tmp)
	'
	'            '�`�F�b�N�������Ă���ꍇ
	'            If intchk = 1 Then
	'                '�����z�̎擾
	'                Call .GetText(COL_KESIKN, idxRow, tmp)
	'                kesikn = kesikn + CCur(tmp)
	'            End If
	'
	'       Next idxRow
	'    End With
	'
	'    txt_kesizan.Text = Format(kesizan - kesikn, "###,###,##0")
	'
	'
	'End Sub
	'2009/06/12 DEL E.N.D FKS)NAKATA
	'================================================================
	
	
	'�S�������ݎ��s��
	Private Sub cmd_zenkesi_Click()
		Dim i As Short
		Dim varKesikn As Object
		
		'�׸ނ������Ă��Ȃ���Ύ��s���Ȃ�
		If blnUsableButton = False Then Exit Sub
		
		
		'�S�����{�^�����������́A�����\�����Ɠ��������ΏۂɃ`�F�b�N������B
		'�O��ł́A�����`�F�b�N�@�\���g�p���Ȃ��B(�L���ɂ���ꍇ�̓R�����g���O���Ă�������)
		'    lockHenpin
		
		
		'�S�s�ɑ΂��A�����ޯ��������
		For i = 1 To intMaxRow
			With spd_body
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.Col = COL_CHK
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.Row = i
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If .Value = 0 Then
					'�S�������Ƀ`�F�b�N������Ȃ��s����C�� 2007/02/28 Saito
					spd_body_ButtonClicked(COL_CHK, i, 1)
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.GetText(COL_KESIKN, i, varKesikn)
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(varKesikn) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If SSSVal(varKesikn) <> 0 Then
						blnUsableSpread = False
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Value = 1
						blnUsableSpread = True
					End If
				End If
			End With
		Next i
		
	End Sub
	
	'�S�������ݎ��s��
	Private Sub cmd_zenkaijo_Click()
		Dim i As Short
		Dim varKesikn As Object
		Dim varBfKesikn As Object
		
		'�׸ނ������Ă��Ȃ���Ύ��s���Ȃ�
		If blnUsableButton = False Then Exit Sub
		
		'�S�s�ɑ΂��A�����ޯ���̉���
		For i = 1 To intMaxRow
			With spd_body
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.Col = COL_CHK
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.Row = i
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If .Value = 1 Then
					'�������Ƀ`�F�b�N���O��Ȃ��s����C�� 2007/02/28 Saito
					spd_body_ButtonClicked(COL_CHK, i, 0)
					
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.GetText(COL_KESIKN, i, varKesikn)
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.GetText(COL_BFKESIKN, i, varBfKesikn)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(varKesikn) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If SSSVal(varKesikn) = 0 Then
						
						blnUsableSpread = False
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Value = 0
						blnUsableSpread = True
					End If
					
				End If
			End With
		Next i
	End Sub
	
	'�ĕ\�����ݎ��s��
	Private Sub cmd_saihyoji_Click()
		'�׸ނ������Ă��Ȃ���Ύ��s���Ȃ�
		If blnUsableButton = False Then Exit Sub
		
		
		If ChkInputChange() = True Then
			If showMsg("1", "URKET73_040", CStr(0)) = MsgBoxResult.No Then
				Exit Sub
			End If
		End If
		
		
		'�w�b�_�����͂���Ă�����f�[�^�������E�\������
		If chkCondition = True Then
			
			intInputMode = 2
			
			showBody() '���ް��\��
			
			'�O��ł́A�����`�F�b�N�@�\���g�p���Ȃ��B(�L���ɂ���ꍇ�̓R�����g���O���Ă�������)
			'�ԕi���������A���b�N
			'lockHenpin
			
		End If
		
	End Sub
	
	'���������ݸد���
	Private Sub cmd_kesidt_Click()
		If txt_kesidt.Enabled = False Then Exit Sub
		
		If Trim(txt_kesidt.Text) <> "" Then
			Set_date.Value = txt_kesidt.Text
		Else
			Set_date.Value = CNV_DATE(gstrUnydt.Value)
		End If
		
		WLSDATE_RTNCODE = ""
		
		'�J�����_�[�E�B���h�E��\��
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		
		txt_kesidt.Focus()
		If WLSDATE_RTNCODE <> "" Then
			txt_kesidt.Text = WLSDATE_RTNCODE
			intChkKb = 1 '�����t�̓��̓`�F�b�N
			txt_tokseicd.Focus()
		End If
	End Sub
	
	'�����溰�����ݸد���
	Private Sub cmd_tokseicd_Click()
		If txt_tokseicd.Enabled = False Then Exit Sub
		WLS_TOK1.ShowDialog()
		WLS_TOK1.Close()
		
		txt_tokseicd.Focus()
		If WLSTOKSUB_RTNCODE <> "" Then
			txt_tokseicd.Text = WLSTOKSUB_RTNCODE
			intChkKb = 1
			chkTokseicd()
			txt_kaidt_From.Focus()
			
		End If
	End Sub
	
	'��������ݸد���
	Private Sub cmd_kaidt_From_Click()
		
		If txt_kaidt_From.Enabled = False Then Exit Sub
		
		If Trim(txt_kaidt_From.Text) <> "" Then
			Set_date.Value = txt_kaidt_From.Text
		Else
			Set_date.Value = CNV_DATE(gstrUnydt.Value)
		End If
		
		WLSDATE_RTNCODE = ""
		
		'�J�����_�[�E�B���h�E��\��
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		
		txt_kaidt_From.Focus()
		If WLSDATE_RTNCODE <> "" Then
			txt_kaidt_From.Text = WLSDATE_RTNCODE
			intChkKb = 1 '�����t�̓��̓`�F�b�N
			txt_kaidt_To.Focus()
		End If
		
	End Sub
	
	
	'��������ݸد���
	Private Sub cmd_kaidt_To_Click()
		If txt_kaidt_To.Enabled = False Then Exit Sub
		
		If Trim(txt_kaidt_To.Text) <> "" Then
			Set_date.Value = txt_kaidt_To.Text
		Else
			Set_date.Value = CNV_DATE(gstrUnydt.Value)
		End If
		
		WLSDATE_RTNCODE = ""
		
		'�J�����_�[�E�B���h�E��\��
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		
		txt_kaidt_To.Focus()
		If WLSDATE_RTNCODE <> "" Then
			txt_kaidt_To.Text = WLSDATE_RTNCODE
			intChkKb = 1 '�����t�̓��̓`�F�b�N
			txt_kesikb.Focus()
		End If
	End Sub
	
	
	'�U���������ݸد���
	Private Sub cmd_fridt_Click()
		'�U�����������͂ł��Ȃ����Ͳ���Ă͎��s���Ȃ�
		If blnFriEnabled = False Then Exit Sub
		If txt_fridt.Enabled = False Then Exit Sub
		
		If Trim(txt_fridt.Text) <> "" Then
			If IsDate(txt_fridt.Text) = True Then
				Set_date.Value = txt_fridt.Text
			Else
				Set_date.Value = CNV_DATE(gstrUnydt.Value)
				txt_fridt.Text = ""
			End If
		Else
			Set_date.Value = CNV_DATE(gstrUnydt.Value)
		End If
		
		WLSDATE_RTNCODE = ""
		
		'�J�����_�[�E�B���h�E��\��
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		
		txt_fridt.Focus()
		If WLSDATE_RTNCODE <> "" Then
			txt_fridt.Text = WLSDATE_RTNCODE
			intChkKb = 1 '�����t�̓��̓`�F�b�N
			'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetFocus �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			spd_body.SetFocus()
		End If
	End Sub
	
	'**** 2009/09/19 ADD START FKS)NAKATA
	'���[�Ή�
	Private Sub getHenpinKingaku()
		
		
		Dim idxRow As Integer
		Dim tmp As Object
		
		
		Dim i As Integer
		Dim strHenpin As String
		Dim strJdnno As String
		Dim strJdnlinno As String
		Dim strOkrjono As String
		Dim curKomikn As Decimal
		Dim maxSeq As Short
		
		On Error Resume Next
		
		With spd_body
			
			For idxRow = 1 To intMaxRow
				
				strHenpin = ""
				
				'�ԕi�t���O�̎擾
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call .GetText(COL_HENPI, idxRow, tmp)
				'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strHenpin = CStr(tmp)
				
				
				'�ԕi�ł���΁A���z�������s��
				If strHenpin = "1" Then
					
					'�󒍔ԍ��̎擾
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call .GetText(COL_JDNNO, idxRow, tmp)
					'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strJdnno = CStr(tmp)
					
					'�󒍍s�ԍ��̎擾
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call .GetText(COL_JDNLINNO, idxRow, tmp)
					'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strJdnlinno = CStr(tmp)
					
					'�ō�������z�̎擾
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call .GetText(COL_KOMIKN, idxRow, tmp)
					'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					curKomikn = CDec(tmp)
					
					'����󇂂̎擾
					strOkrjono = getOKRJONO(strJdnno, strJdnlinno)
					
					
					For i = 0 To UBound(ARY_NYUKN_KS)
						
						'�󒍔ԍ�
						If ARY_NYUKN_KS(i).OKRJONO = strOkrjono Then
							maxSeq = i
						End If
						
					Next i
					
					'�ԕi�̋��z���c���։��Z����
					ARY_NYUKN_KS(maxSeq).ZANKN = ARY_NYUKN_KS(maxSeq).ZANKN + curKomikn * (-1)
					
				End If
				
			Next idxRow
			
		End With
		
	End Sub
	'**** 2009/09/19 ADD E.N.D FKS)NAKATA
	
	
	'�ԕi����
	Private Sub lockHenpin()
		Dim intKesizan As Decimal '�w�b�_�������c�z
		Dim intKomikn As Decimal '�ō�����z
		Dim intKesikn As Decimal '�����z
		Dim intBfKesikn As Decimal '�����z(�����O)
		Dim tmp As Object
		Dim LS_HYFRIDT As Object
		Dim idxRow As Integer
		Dim idxRowJDNNO As Integer
		Dim strFRIDT As String
		Dim strHyjdnno As String
		Dim str_theHYJDNNO As String
		Dim intchk As Short
		
		On Error Resume Next
		'�U���������擾
		
		strFRIDT = txt_fridt.Text
		'�����c�z���擾
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		intKesizan = SSSVal((txt_kesizan.Text))
		'�ԕi������
		
		With spd_body
			
			For idxRow = 1 To intMaxRow
				'�ō�����z���擾
				
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call .GetText(COL_KOMIKN, idxRow, tmp)
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				intKomikn = SSSVal(tmp)
				'�����ϊz���擾
				
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call .GetText(COL_KESIKN, idxRow, tmp)
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				intKesikn = SSSVal(tmp)
				'�����ȑO�����z
				
				
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				intBfKesikn = SSSVal(tmp)
				
				
				'�����z���}�C�i�X�ł���Γ���󒍔ԍ��ő��E
				If intKomikn - intKesikn < 0 Then
					
					'�����z�������c�z�֒ǉ�
					intKesizan = intKesizan - (intKomikn - intKesikn)
					
					'�����ϊz�ݒ�
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.SetText(COL_KESIKN, idxRow, intKomikn)
					
					'�`�F�b�N�{�b�N�X�ݒ�
					blnUsableSpread = False
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Row = idxRow
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Col = COL_CHK
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Value = 1
					blnUsableSpread = True
					
					
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call .SetText(COL_HENPI, idxRow, "1")
					
					
					'�󒍔ԍ��擾
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call .GetText(COL_HYJDNNO, idxRow, tmp)
					'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strHyjdnno = CStr(tmp)
					
					'����󒍔ԍ�������
					For idxRowJDNNO = intMaxRow To 1 Step -1
						'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.GetText(COL_HYJDNNO, idxRowJDNNO, tmp)
						'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						str_theHYJDNNO = CStr(tmp)
						
						'�󒍔ԍ���v����Α��E
						If strHyjdnno <> str_theHYJDNNO Then
						Else
							'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							.GetText(COL_CHK, idxRowJDNNO, tmp)
							'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							intchk = SSSVal(tmp)
							
							'�������g�łȂ��A�܂��̓`�F�b�N����Ă��Ȃ�
							If idxRowJDNNO <> idxRow And intchk = 1 Then
							Else
								
								'�ō�����z���擾
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Call .GetText(COL_KOMIKN, idxRowJDNNO, tmp)
								'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								intKomikn = SSSVal(tmp)
								
								'�����ϊz���擾
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Call .GetText(COL_KESIKN, idxRowJDNNO, tmp)
								'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								intKesikn = SSSVal(tmp)
								
								'�����ȑO�����z
								
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
								'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								intBfKesikn = SSSVal(tmp)
								
								'�ō�������z�S�z���E
								If intKesizan >= intKomikn - intKesikn Then
									
									'�����ϊz�ݒ�
									'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									.SetText(COL_KESIKN, idxRowJDNNO, intKomikn)
									
									'�`�F�b�N�{�b�N�X�ݒ�
									blnUsableSpread = False
									'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									.Row = idxRowJDNNO
									'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									.Col = COL_CHK
									'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									.Value = 1
									blnUsableSpread = True
									
									'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									Call .SetText(COL_HENPI, idxRowJDNNO, "1")
									
									'�����c�z�ݒ�
									intKesizan = intKesizan - (intKomikn - intKesikn)
									
									'�U�������ݒ�
									If DB_TOKMTA.SHAKB Like "[256]" Then
										'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										.GetText(COL_HYFRIDT, idxRowJDNNO, LS_HYFRIDT)
										'UPGRADE_WARNING: �I�u�W�F�N�g LS_HYFRIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										If Trim(LS_HYFRIDT) = "" Then
											'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
											.SetText(COL_HYFRIDT, idxRowJDNNO, strFRIDT)
										End If
									End If
									'�ō�������z�ꕔ���E
									'�����ϊz�ݒ�
									
								Else
									
									'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									.SetText(COL_KESIKN, idxRowJDNNO, intKesikn + intKesizan)
									'�`�F�b�N�{�b�N�X�ݒ�
									
									
									''�����c�z���[���̏ꍇ�A�`�F�b�N�����Ȃ�
									If intKesizan > 0 Then
										
										
										blnUsableSpread = False
										'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										.Row = idxRowJDNNO
										'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										.Col = COL_CHK
										'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										.Value = 1
										blnUsableSpread = True
										
										
										'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										Call .SetText(COL_HENPI, idxRowJDNNO, "1")
										
										
									End If
									
									'�����c�z�[��
									intKesizan = 0
									
									'�U�������ݒ�
									If DB_TOKMTA.SHAKB Like "[256]" Then
										'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										.GetText(COL_HYFRIDT, idxRowJDNNO, LS_HYFRIDT)
										'UPGRADE_WARNING: �I�u�W�F�N�g LS_HYFRIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										If Trim(LS_HYFRIDT) = "" Then
											'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
											.SetText(COL_HYFRIDT, idxRowJDNNO, strFRIDT)
											'�����c�z��ݒ�
											
										End If
									End If
								End If
							End If
						End If
					Next idxRowJDNNO
				End If
			Next idxRow
		End With
		
		txt_kesizan.Text = VB6.Format(intKesizan, "###,###,##0")
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F Function chk_HENPIN
	'   �T�v�F �������܂����ŕԕi�o�^�A�󒍒������s������
	'          �ԍ��ɂđ��E�����󒍂�\�����Ȃ�
	'   �����F strJdnNo   : �󒍓`�[�ԍ�
	'   �@�@�F strJdnlinNo: �󒍓`�[�s�ԍ�
	'       :  strUrikn   : ������z
	'   �ߒl�F �`�F�b�N����
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Function chkHenpin(ByVal strJdnno As String, ByVal strJdnlinno As String, ByVal strRECNO As String, ByVal strWrtFstDt As String, ByVal strWrtFstTm As String, ByVal strUritk As String, ByVal strUrikn As String) As Boolean
		
		
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		'UPGRADE_WARNING: �\���� Usr_Ody2 �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody2 As U_Ody
		Dim strSql As String
		
		On Error GoTo ERR_chkHENPIN
		
		chkHenpin = False
		
		strSql = " "
		strSql = " SELECT *"
		strSql = strSql & " FROM    UDNTRA"
		strSql = strSql & " WHERE   JDNNO    =  '" & Trim(strJdnno) & "'"
		strSql = strSql & " AND     JDNLINNO =  '" & Trim(strJdnlinno) & "'"
		strSql = strSql & " AND     DATKB =  '1'"
		strSql = strSql & " AND     AKAKROKB =  '9'"
		strSql = strSql & " AND     DKBID    =  '01'"
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		'�f�[�^�����݂����ꍇ
		Do While CF_Ora_EOF(Usr_Ody) = False
			
			'��������Ă��Ȃ��ꍇ�A�������s��
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) <> "1" Then
				
				'�ԕi���R�ɒl���i�[����Ă��锄���ΏۂƂ���
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, DKBID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Trim(CF_Ora_GetDyn(Usr_Ody, "HENRSNCD", "")) <> "" And CF_Ora_GetDyn(Usr_Ody, "DKBID", "") = "01" Then
					
					
					'���ƐԂ�URIKN�̍��z���u0�v�ɂȂ�̂Ȃ�\�����Ȃ�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If CInt(strUrikn) = CInt(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")) * (-1) Then
						chkHenpin = False
						GoTo END_chkHENPIN
					Else
						
						
						'�ԕi�o�^���s�����󒍂ɑ΂��P���������s�����ꍇ�A���P���Ƃ��̎��̕ԕi���R�[�h���o�͂��Ȃ��悤�C��
						
						strSql = " "
						strSql = " SELECT COUNT(*) AS CNT"
						strSql = strSql & " FROM    UDNTRA"
						strSql = strSql & " WHERE   JDNNO       =  '" & Trim(strJdnno) & "'"
						strSql = strSql & " AND     JDNLINNO    =  '" & Trim(strJdnlinno) & "'"
						strSql = strSql & " AND     DATKB       =  '1'"
						strSql = strSql & " AND     AKAKROKB    =  '1'"
						strSql = strSql & " AND     DKBID       =  '01'"
						strSql = strSql & " AND     RECNO       =  '" & Trim(strRECNO) & "'"
						strSql = strSql & " AND     URITK       !=   " & strUritk & " "
						strSql = strSql & " AND     (WRTFSTDT || WRTFSTTM)  >  '" & strWrtFstDt & strWrtFstTm & "'"
						
						'DB�A�N�Z�X
						Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody2, strSql)
						
						'�f�[�^�����݂����ꍇ
						Do While CF_Ora_EOF(Usr_Ody2) = False
							
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If CInt(CF_Ora_GetDyn(Usr_Ody2, "CNT", 0)) >= 1 Then
								chkHenpin = False
								Call CF_Ora_CloseDyn(Usr_Ody2)
								GoTo END_chkHENPIN
							Else
								chkHenpin = True
								Call CF_Ora_CloseDyn(Usr_Ody2)
								GoTo END_chkHENPIN
							End If
							'UPGRADE_WARNING: �I�u�W�F�N�g Usr_Ody2.Obj_Ody.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Usr_Ody2.Obj_Ody.MoveNext()
						Loop 
						
					End If
				End If
				
			End If
			
			'UPGRADE_WARNING: �I�u�W�F�N�g Usr_Ody.Obj_Ody.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Usr_Ody.Obj_Ody.MoveNext()
		Loop 
		
		chkHenpin = True
		
END_chkHENPIN: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_chkHENPIN: 
		GoTo END_chkHENPIN
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F Function chkHenpinTeisei
	'   �T�v�F �������܂����ŕԕi�o�^�A�󒍒������s������
	'          �ԍ��ɂđ��E�����󒍂�\�����Ȃ�
	'   �����F strJdnNo   : �󒍓`�[�ԍ�
	'   �@�@�F strJdnlinNo: �󒍓`�[�s�ԍ�
	'   �@�@�F strUrikn   : ������z
	'   �@�@�F strUdnno   : ����`�[�ԍ�
	'   �@�@�F strLinno   : �s�ԍ�
	'   �@�@�F strUriDt   : �����
	'   �ߒl�F �`�F�b�N����
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function chkHenpinTeisei(ByVal strJdnno As String, ByVal strJdnlinno As String, ByVal strUrikn As String, ByVal strUDNNO As String, ByVal strLINNO As String, ByVal strURIDT As String, ByVal strWrtFstDt As String, ByVal strWrtFstTm As String) As Boolean
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo ERR_chkHenpinTeisei
		
		chkHenpinTeisei = False
		
		strSql = " "
		
		strSql = " SELECT *"
		strSql = strSql & " FROM    UDNTRA"
		strSql = strSql & " WHERE   JDNNO    =  '" & strJdnno & "'"
		strSql = strSql & " AND     JDNLINNO =  '" & strJdnlinno & "'"
		strSql = strSql & " AND     DATKB =  '1'"
		strSql = strSql & " AND     AKAKROKB =  '9'"
		strSql = strSql & " AND     DKBID =  '01'"
		strSql = strSql & " AND     UDNNO  <>  '" & strUDNNO & "'"
		strSql = strSql & " AND     LINNO  =  '" & strLINNO & "'"
		'  strSql = strSql & " AND     UDNDT <>  '" & strURIDT & "'"
		strSql = strSql & " AND     (WRTFSTDT || WRTFSTTM)  <>  '" & strWrtFstDt & strWrtFstTm & "'"
		
		
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		'�f�[�^�����݂����ꍇ
		Do While CF_Ora_EOF(Usr_Ody) = False
			
			'��������Ă��Ȃ��ꍇ�A�������s��
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) <> "1" Then
				
				'���ƐԂ�URIKN�̍��z���u0�v�ɂȂ�̂Ȃ�\�����Ȃ�
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If (CInt(strUrikn) + CInt(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) = 0 Then
					chkHenpinTeisei = False
					GoTo END_chkHenpinTeisei
				Else
					chkHenpinTeisei = True
					GoTo END_chkHenpinTeisei
				End If
				
			End If
			
			'UPGRADE_WARNING: �I�u�W�F�N�g Usr_Ody.Obj_Ody.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Usr_Ody.Obj_Ody.MoveNext()
		Loop 
		
		chkHenpinTeisei = True
		
END_chkHenpinTeisei: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_chkHenpinTeisei: 
		GoTo END_chkHenpinTeisei
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F Sub chkAkaKro
	'   �T�v�F �ꕔ�ԕi�����݂��锄�����������ہA�Ԃƍ�������o��
	'�@�@�@�@  �Ԃ̂ݏ��������ꍇ�́A�G���[���b�Z�[�W���o���B
	'          ���̂ݏ��������ꍇ�́A�Ԃ̑��݂����邱�Ƃ����b�Z�[�W����B
	'
	'   ���l�F 2008/08/13 ���[���ꂽ����ɑ΂��Ă̐ԍ��`�F�b�N�̒ǉ��E�C��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function chkAkaKro() As Object
		
		Dim intKesizan As Decimal '�w�b�_�������c�z
		Dim intKomikn As Decimal '�ō�����z
		Dim intKesikn As Decimal '�����z
		Dim intBfKesikn As Decimal '�����z(�����O)
		Dim intAfKesikn As Decimal
		
		Dim intUrikn As Decimal '������z
		Dim wkKesikn As Decimal '�ԍ��`�F�b�N�p���������[�N�ϐ�
		Dim sumKesikn As Decimal '�ԍ��`�F�b�N�p�������ϐ�
		Dim Cnt As Short '�ԍ��`�F�b�N�p�J�E���g�ϐ�
		Dim i As Short '�ԍ��`�F�b�N�p
		Dim wkRow As Integer '�ԍ��`�F�b�N�p�s�ԍ�
		
		Dim tmp As Object
		Dim LS_HYFRIDT As Object
		Dim idxRow As Integer
		Dim idxRowJDNNO As Integer
		Dim strFRIDT As String
		Dim strHyjdnno As String
		Dim str_theHYJDNNO As String
		Dim intchk As Short
		Dim strUDNDT As String
		
		
		'UPGRADE_WARNING: �I�u�W�F�N�g chkAkaKro �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		chkAkaKro = True
		
		'�ԕi������
		With spd_body
			For idxRow = 1 To intMaxRow
				
				'�`�F�b�N�������Ă��邩���m�F
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.GetText(COL_CHK, idxRow, tmp)
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				intchk = SSSVal(tmp)
				
				
				'�`�F�b�N�������Ă���ꍇ
				If intchk = 1 Then
					
					''�ԍ��`�F�b�N�z��̏�����
					ReDim Preserve AKAKRO_CHK(0)
					Cnt = 1
					
					'��ʓ��͒l�̏������ȍ~�̓��t����Ă���ꍇ�G���[�Ƃ���B
					'������̎擾
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call .GetText(COL_UDNDT, idxRow, tmp)
					'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strUDNDT = CStr(tmp)
					
					If strUDNDT > DeCNV_DATE(Trim(txt_kesidt.Text)) Then
						MsgBox("���͂��ꂽ�������ȍ~�̔��オ���݂��܂��B")
						'UPGRADE_WARNING: �I�u�W�F�N�g chkAkaKro �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						chkAkaKro = False
						Exit Function
					End If
					
					'�����ϊz(�����O)
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call .GetText(COL_BFKESIKN, idxRow, tmp)
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					intBfKesikn = SSSVal(tmp)
					
					'�����ϊz(������)
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call .GetText(COL_AFKESIKN, idxRow, tmp)
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					intAfKesikn = SSSVal(tmp)
					
					
					'�����ϊz���擾
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call .GetText(COL_KESIKN, idxRow, tmp)
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					intKesikn = SSSVal(tmp)
					
					'�ȑO�ɏ�������Ă�����̈ȊO
					If intBfKesikn + intAfKesikn = 0 Then
						
						'�����z���}�C�i�X�ł���Γ���󒍔ԍ��̍�������
						If intKesikn < 0 Then
							
							'�󒍔ԍ��擾
							'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Call .GetText(COL_HYJDNNO, idxRow, tmp)
							'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							strHyjdnno = CStr(tmp)
							
							
							'�Ԃ̃f�[�^��z��Ɋi�[
							AKAKRO_CHK(0).idx = idxRow
							AKAKRO_CHK(0).CHKMK = intchk
							AKAKRO_CHK(0).UDNDT = strUDNDT
							AKAKRO_CHK(0).JDNNO = strHyjdnno
							AKAKRO_CHK(0).KESIKN = intKesikn
							
							
							'����󒍔ԍ�������
							For idxRowJDNNO = intMaxRow To 1 Step -1
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.GetText(COL_HYJDNNO, idxRowJDNNO, tmp)
								'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								str_theHYJDNNO = CStr(tmp)
								
								'�󒍔ԍ���v����Α��E
								If strHyjdnno <> str_theHYJDNNO Then
								Else
									'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									.GetText(COL_CHK, idxRowJDNNO, tmp)
									'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									intchk = SSSVal(tmp)
									
									
									
									If idxRowJDNNO <> idxRow Then
										
										''����󒍔ԍ��̍��̏������z���擾
										'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										.GetText(COL_KESIKN, idxRowJDNNO, tmp)
										'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										wkKesikn = SSSVal(tmp)
										
										
										'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										.GetText(COL_UDNDT, idxRowJDNNO, tmp)
										'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										strUDNDT = CStr(tmp)
										
										''����󒍔ԍ��̍���z��Ɋi�[
										ReDim Preserve AKAKRO_CHK(Cnt)
										
										AKAKRO_CHK(Cnt).idx = idxRowJDNNO
										AKAKRO_CHK(Cnt).CHKMK = intchk
										AKAKRO_CHK(Cnt).JDNNO = strHyjdnno
										AKAKRO_CHK(Cnt).UDNDT = strUDNDT
										AKAKRO_CHK(Cnt).KESIKN = wkKesikn
										
										Cnt = Cnt + 1
									End If
									
								End If
							Next idxRowJDNNO
							
							
							''�ԕi�̐ԍ��`�F�b�N
							'�T�}���̏�����
							sumKesikn = AKAKRO_CHK(0).KESIKN
							
							For i = 1 To Cnt - 1
								
								'�`�F�b�N�������Ă��Ȃ��ꍇ
								If AKAKRO_CHK(i).CHKMK = 0 Then
									
									wkRow = AKAKRO_CHK(i).idx
									strUDNDT = AKAKRO_CHK(i).UDNDT
									
									'�����Ă���ꍇ
								Else
									'�Ԃ̃}�C�i�X�̏������ȏ�ɍ��̏���������Ă���
									If sumKesikn + AKAKRO_CHK(i).KESIKN >= 0 Then
										sumKesikn = 0
										Exit For
									Else
										'
										wkRow = AKAKRO_CHK(i).idx
										sumKesikn = sumKesikn + AKAKRO_CHK(i).KESIKN
									End If
									
								End If
							Next i
							
							'�T�}�����}�C�i�X�ɂȂ��Ă���ꍇ�̓G���[���b�Z�[�W��\��
							If Cnt - 1 >= 1 And sumKesikn < 0 Then
								MsgBox("�[�����K�v�Ȕ��オ����܂��B" & vbCrLf & vbCrLf & "�sNo:" & vbTab & wkRow & vbCrLf & "�����: " & vbTab & strUDNDT & vbCrLf & "�󒍔ԍ�: " & vbTab & strHyjdnno)
								'UPGRADE_WARNING: �I�u�W�F�N�g chkAkaKro �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								chkAkaKro = False
								Exit Function
							End If
							
						Else
							'���f�[�^����̌���
							
							'�󒍔ԍ��擾
							'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Call .GetText(COL_HYJDNNO, idxRow, tmp)
							'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							strHyjdnno = CStr(tmp)
							
							'����󒍔ԍ�������
							For idxRowJDNNO = intMaxRow To 1 Step -1
								'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.GetText(COL_HYJDNNO, idxRowJDNNO, tmp)
								'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								str_theHYJDNNO = CStr(tmp)
								
								'�󒍔ԍ���v����Α��E
								If strHyjdnno <> str_theHYJDNNO Then
								Else
									
									'�`�F�b�N
									'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									.GetText(COL_CHK, idxRowJDNNO, tmp)
									'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									intchk = SSSVal(tmp)
									
									'������z
									'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									.GetText(COL_URIKN, idxRowJDNNO, tmp)
									'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									intUrikn = SSSVal(tmp)
									
									
									
									''���[����Ă��鍕�f�[�^�����o���Ȃ��悤�C��
									'�������g�łȂ��A���`�F�b�N����Ă��Ȃ��A�����f�[�^�łȂ�
									If idxRowJDNNO <> idxRow And intchk = 0 And intUrikn < 0 Then
										
										
										'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										.GetText(COL_UDNDT, idxRowJDNNO, tmp)
										'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										strUDNDT = CStr(tmp)
										
										If MsgBox("�[�����K�v�Ȕ��オ����܂��B" & vbCrLf & "�X�V���܂����H" & vbCrLf & vbCrLf & "�sNo:" & vbTab & idxRowJDNNO & vbCrLf & "�����: " & vbTab & strUDNDT & vbCrLf & "�󒍔ԍ�: " & vbTab & strHyjdnno, MsgBoxStyle.OKCancel) = MsgBoxResult.OK Then
											
											'UPGRADE_WARNING: �I�u�W�F�N�g chkAkaKro �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
											chkAkaKro = True
											
										Else
											'UPGRADE_WARNING: �I�u�W�F�N�g chkAkaKro �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
											chkAkaKro = False
											Exit Function
										End If
										
									End If
								End If
							Next idxRowJDNNO
							
						End If
					End If
				End If
			Next idxRow
		End With
		
	End Function
	
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   ���́F Function chkNyukn
	''   �T�v�F ��������Ă��邩�̃`�F�b�N
	''   ���l�F
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function chkNyukn() As Object
		
		
		Dim tmp As Object
		Dim idxRow As Integer
		Dim intchk As Short
		Dim i As Short
		Dim BlnFlg As Boolean
		
		'*** 2009/10/09 ADD START FKS)NAKATA
		Dim BlnFlgDay As Boolean
		'*** 2009/10/09 ADD E.N.D FKS)NAKATA
		
		Dim strJdnno As String '�󒍔ԍ�
		Dim strJdnlinno As String '�󒍍s�ԍ�
		Dim strHyjdnno As String
		Dim strOkrjono As String '�����
		Dim curKesikn As Decimal
		Dim curKesiknMae As Decimal
		
		
		On Error GoTo ERR_chkNYUKN
		
		'UPGRADE_WARNING: �I�u�W�F�N�g chkNyukn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		chkNyukn = True
		
		
		
		With spd_body
			For idxRow = 1 To intMaxRow
				
				'�`�F�b�N�������Ă��邩���m�F
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.GetText(COL_CHK, idxRow, tmp)
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				intchk = SSSVal(tmp)
				
				
				'�`�F�b�N�������Ă���ꍇ
				If intchk = 1 Then
					
					BlnFlg = False
					'*** 2009/10/09 ADD START FKS)NAKATA
					BlnFlgDay = False
					'*** 2009/10/09 ADD E.N.D FKS)NAKATA
					
					
					'�󒍔ԍ����擾
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call .GetText(COL_JDNNO, idxRow, tmp)
					'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strJdnno = CStr(tmp)
					
					'�󒍍s�ԍ����擾
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call .GetText(COL_JDNLINNO, idxRow, tmp)
					'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strJdnlinno = CStr(tmp)
					
					'�\���p�󒍔ԍ����擾
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call .GetText(COL_HYJDNNO, idxRow, tmp)
					'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strHyjdnno = CStr(tmp)
					
					'����󇂂̎擾
					strOkrjono = getOKRJONO(strJdnno, strJdnlinno)
					
					'�����z
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call .GetText(COL_KESIKN, idxRow, tmp)
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					curKesikn = SSSVal(tmp)
					
					'�����z
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					curKesiknMae = SSSVal(tmp)
					
					
					If System.Math.Abs(curKesikn) > System.Math.Abs(curKesiknMae) Then
						
						For i = 0 To UBound(ARY_NYUKN_KS)
							
							'��������Ă��邩�̊m�F
							If strOkrjono = ARY_NYUKN_KS(i).OKRJONO Then
								
								BlnFlg = True
								
								'�������Ə[�����̃`�F�b�N
								If ARY_NYUKN_KS(i).UDNDT <= gstrKesidt.Value Then
									BlnFlgDay = True
								Else
									Exit For
								End If
								
								Exit For
								
							End If
						Next i
						
						
						'�������s���Ă��Ȃ��ꍇ�A�G���[�Ƃ���B
						If BlnFlg = False Then
							If MsgBox("�������o�^����Ă��܂���B" & vbCrLf & vbCrLf & "�sNo:" & vbTab & idxRow & vbCrLf & "�󒍔ԍ�: " & vbTab & strHyjdnno, MsgBoxStyle.OKOnly, "�O��[���߂�����") = MsgBoxResult.OK Then
								'UPGRADE_WARNING: �I�u�W�F�N�g chkNyukn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								chkNyukn = False
								GoTo END_chkNyukn
							End If
						End If
						
						'*** 2009/10/09 ADD START FKS)NAKATA
						'�[���������������ȑO�̏ꍇ�A�G���[�Ƃ���B
						If BlnFlgDay = False Then
							If MsgBox("�������ȑO�ł͏[���ł��܂���B" & vbCrLf & vbCrLf & "�sNo:" & vbTab & idxRow & vbCrLf & "�󒍔ԍ�: " & vbTab & strHyjdnno, MsgBoxStyle.OKOnly, "�O��[���߂�����") = MsgBoxResult.OK Then
								'UPGRADE_WARNING: �I�u�W�F�N�g chkNyukn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								chkNyukn = False
								GoTo END_chkNyukn
							End If
						End If
						'*** 2009/10/09 ADD E.N.D FKS)NAKATA
						
						
						
					End If
					
				End If
				
			Next idxRow
		End With
		
		
END_chkNyukn: 
		
		Exit Function
		
ERR_chkNYUKN: 
		GoTo END_chkNyukn
		
	End Function
	
	'**** 2009/09/16 DEL START FKS)NAKATA
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   ���́F Function chkURIKN
	''   �T�v�F ������z�Ə[�����z�̃`�F�b�N
	''   ���l�F
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Private Function chkUrikn()
	'
	'    Dim tmp             As Variant
	'    Dim idxRow          As Long
	'    Dim intchk          As Integer
	'
	'    Dim strJdnno        As String    '�󒍔ԍ�
	'    Dim strJdnlinno     As String    '�󒍍s�ԍ�
	'    Dim strHyjdnno      As String    '�\���p�󒍔ԍ�
	'    Dim strOkrjono      As String    '�����
	'    Dim strJdntrkb      As String    '�󒍎���敪
	'
	'    Dim curBfKesikn     As Currency  '�����z(�����O)
	'    Dim curAfKesikn     As Currency  '�����z(������)
	'
	'    Dim curNYUKN        As Currency  '�������R�[�h�����z
	'    Dim curUrikn        As Currency  '���ヌ�R�[�h������z + �ŋ�
	'
	'    Dim Usr_Ody         As U_Ody
	'    Dim strSql          As String
	'
	'    On Error GoTo ERR_chkUrikn
	'
	'
	'
	'    chkUrikn = True
	'
	'    '�ԕi������
	'    With spd_body
	'        For idxRow = 1 To intMaxRow
	'
	'            '�`�F�b�N�������Ă��邩���m�F
	'            .GetText COL_CHK, idxRow, tmp
	'            intchk = SSSVal(tmp)
	'
	'
	'            '�`�F�b�N�������Ă���ꍇ
	'            If intchk = 1 Then
	'
	'
	'                '�󒍔ԍ����擾
	'                Call .GetText(COL_JDNNO, idxRow, tmp)
	'                strJdnno = CStr(tmp)
	'
	'
	'                '�󒍍s�ԍ����擾
	'                Call .GetText(COL_JDNLINNO, idxRow, tmp)
	'                strJdnlinno = CStr(tmp)
	'
	'
	'                '�\���p�󒍔ԍ����擾
	'                Call .GetText(COL_HYJDNNO, idxRow, tmp)
	'                strHyjdnno = CStr(tmp)
	'
	'
	'                '�����ϊz(�����O)
	'                Call .GetText(COL_BFKESIKN, idxRow, tmp)
	'                curBfKesikn = SSSVal(tmp)
	'
	'
	'                '�����ϊz(������)
	'                Call .GetText(COL_AFKESIKN, idxRow, tmp)
	'                curAfKesikn = SSSVal(tmp)
	'
	'
	'                    '�ȑO�ɏ�������Ă�����̈ȊO��ΏۂƂ���
	'                    If curBfKesikn + curAfKesikn = 0 Then
	'
	'
	'                            ''�󒍔ԍ����󒍎���敪���擾����B
	'                            strSql = " "
	'                            strSql = strSql & " SELECT  JDNTRKB"
	'                            strSql = strSql & "  FROM   JDNTHA"
	'                            strSql = strSql & " WHERE   DATNO IN"
	'                            strSql = strSql & " ("
	'                            strSql = strSql & "  SELECT  MAX(DATNO)"
	'                            strSql = strSql & "   FROM   JDNTHA"
	'                            strSql = strSql & "  WHERE   DATKB = '1'"
	'                            strSql = strSql & "    AND   JDNNO = '" & strJdnno & "'"
	'                            strSql = strSql & " )"
	'                            strSql = strSql & "    AND DATKB = '1'"
	'
	'
	'                            'DB�A�N�Z�X
	'                            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
	'
	'                            If CF_Ora_EOF(Usr_Ody) = False Then
	'                                strJdntrkb = SSSVal(CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")) '�󒍎���敪
	'                            End If
	'
	'                            Call CF_Ora_CloseDyn(Usr_Ody)   '�ް���ĸ۰��
	'
	'
	'
	'                            ''�󒍔ԍ��E�s�ԍ���蔄����z���擾����
	'                            strSql = ""
	'                            strSql = strSql & "SELECT SUM(URIKN) + SUM(UZEKN)   URIKN"
	'                            strSql = strSql & "  FROM UDNTRA"
	'                            strSql = strSql & " WHERE JDNNO     = '" & strJdnno & "'"
	'
	'                            '�Z�b�g�A�b�v�E�V�X�e���ȊO�̎󒍂͖��׍s�S�̂ŋ��z���T�}������B
	'                            If strJdntrkb = "11" Or strJdntrkb = "21" Then
	'                            Else
	'                                strSql = strSql & "   AND JDNLINNO  = '" & strJdnlinno & "'"
	'                            End If
	'
	'                            strSql = strSql & "   AND IRISU     <> 9"
	'                            strSql = strSql & "   AND DATKB     = '1'"
	'
	'
	'                            'DB�A�N�Z�X
	'                            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
	'
	'                            If CF_Ora_EOF(Usr_Ody) = False Then
	'                                curUrikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")) '������z
	'                            End If
	'
	'                            Call CF_Ora_CloseDyn(Usr_Ody)   '�ް���ĸ۰��
	'
	'
	'
	'                            '�󒍔ԍ� + �s�ԍ����u����󇂁v�֕ύX
	'                            '�Z�b�g�A�b�v�E�V�X�e���́A�s�ԍ����u001�v�Œ�
	'                            If strJdntrkb = "11" Or strJdntrkb = "21" Then
	'                                strOkrjono = Trim$(strJdnno) & "001"
	'                            Else
	'                                strOkrjono = Trim$(strJdnno) & Trim$(strJdnlinno)
	'                            End If
	'
	'
	'
	'                            ''�������R�[�h�������z���擾����B
	'                            strSql = " "
	'                            strSql = strSql & " SELECT  SUM(TRA.NYUKN) AS NYUKN"
	'                            strSql = strSql & "  FROM    UDNTRA TRA ,"
	'                            strSql = strSql & "          UDNTHA THA"
	'                            strSql = strSql & " WHERE    TRA.DATNO = THA.DATNO"
	'                            strSql = strSql & "  AND     TRA.DATKB = '1'"
	'                            strSql = strSql & "  AND     TRA.DENKB = '8'"
	'                            strSql = strSql & "  AND     THA.NYUCD = '2'"
	'                            strSql = strSql & "  AND     THA.FRNKB = '0'"
	'                            strSql = strSql & "  AND     TRA.OKRJONO = '" & strOkrjono & "'"
	'
	'
	'
	'                            'DB�A�N�Z�X
	'                            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
	'
	'                            If CF_Ora_EOF(Usr_Ody) = False Then
	'                                curNYUKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "NYUKN", "")) '������z
	'                            End If
	'
	'                            Call CF_Ora_CloseDyn(Usr_Ody)   '�ް���ĸ۰��
	'
	'
	'                            '������z�Ɠ����z����v���Ă��Ȃ��ꍇ�A�G���[
	'                            If curUrikn <> curNYUKN Then
	'                                If MsgBox("������z�Ɠ����z���قȂ�܂��B" & vbCrLf & vbCrLf _
	''                                            & "�sNo:" & vbTab & idxRow & vbCrLf _
	''                                            & "�󒍔ԍ�: " & vbTab & strHyjdnno, vbOKOnly, "�O��[���߂�����") = vbOK Then
	'                                    chkUrikn = False
	'                                    GoTo END_chkUrikn
	'                                End If
	'                            End If
	'
	'                    End If
	'            End If
	'       Next idxRow
	'    End With
	'
	'
	'END_chkUrikn:
	'    '�N���[�Y
	'    Call CF_Ora_CloseDyn(Usr_Ody)
	'    Exit Function
	'
	'ERR_chkUrikn:
	'    GoTo END_chkUrikn
	'
	'
	'End Function
	'**** 2009/09/16 DEL E.N.D FKS)NAKATA
	
	'**** 2009/09/16 DEL START FKS)NAKATA
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   ���́F Function chkJdntrkb
	''   �T�v�F �`�[�P�ʂł̏[���`�F�b�N
	''   ���l�F
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Private Function chkJdntrkb()
	'
	'    Dim tmp             As Variant
	'    Dim idxRow          As Long
	'    Dim intchk          As Integer
	'
	'    Dim i               As Integer
	'    Dim Cnt             As Long
	'
	'    '�X�v���b�h�i�[�ϐ�
	'    Dim strJdnno        As String    '�󒍔ԍ�
	'    Dim strJdnlinno     As String    '�󒍍s�ԍ�
	'    Dim strHyjdnno      As String    '�\���p�󒍔ԍ�
	'    Dim curKomikn       As Currency  '������z�{�ŋ�
	'
	'    '�󒍎���敪
	'    Dim strOkrjono      As String    '�����
	'    Dim strJdntrkb      As String    '�󒍎���敪
	'
	'
	'    '�`�F�b�N�p�ϐ�
	'    Dim wkIdx           As Integer
	'    Dim wkJdnno         As String
	'    Dim wkHyjdnno       As String
	'    Dim wkKomikn        As Currency
	'    Dim curUrikn        As Currency  '���ヌ�R�[�h������z + �ŋ�
	'
	'
	'    Dim Usr_Ody         As U_Ody
	'    Dim strSql          As String
	'
	'    On Error GoTo ERR_chkJdntrkb
	'
	'
	'    chkJdntrkb = True
	'
	'
	'    '�z��̏�����
	'    ReDim Preserve JDNTRKB_CHK(0)
	'    Cnt = 0
	'
	'
	'        With spd_body
	'            For idxRow = 1 To intMaxRow
	'
	'                '�`�F�b�N�������Ă��邩���m�F
	'                .GetText COL_CHK, idxRow, tmp
	'                intchk = SSSVal(tmp)
	'
	'
	'                '�`�F�b�N�������Ă���ꍇ
	'                If intchk = 1 Then
	'
	'
	'                    '�󒍔ԍ����擾
	'                    Call .GetText(COL_JDNNO, idxRow, tmp)
	'                    strJdnno = CStr(tmp)
	'
	'
	'                    '�󒍍s�ԍ����擾
	'                    Call .GetText(COL_JDNLINNO, idxRow, tmp)
	'                    strJdnlinno = CStr(tmp)
	'
	'
	'                    '�\���p�󒍔ԍ����擾
	'                    Call .GetText(COL_HYJDNNO, idxRow, tmp)
	'                    strHyjdnno = CStr(tmp)
	'
	'
	'                    '�ō�������z���擾
	'                    Call .GetText(COL_KOMIKN, idxRow, tmp)
	'                    curKomikn = CCur(tmp)
	'
	'
	'                    '�󒍔ԍ����󒍎���敪���擾����B
	'                    strSql = " "
	'                    strSql = strSql & " SELECT  JDNTRKB"
	'                    strSql = strSql & "  FROM   JDNTHA"
	'                    strSql = strSql & " WHERE   DATNO IN"
	'                    strSql = strSql & " ("
	'                    strSql = strSql & "  SELECT  MAX(DATNO)"
	'                    strSql = strSql & "   FROM   JDNTHA"
	'                    strSql = strSql & "  WHERE   DATKB = '1'"
	'                    strSql = strSql & "    AND   JDNNO = '" & strJdnno & "'"
	'                    strSql = strSql & " )"
	'                    strSql = strSql & "    AND DATKB = '1'"
	'
	'
	'                    'DB�A�N�Z�X
	'                    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
	'
	'                    If CF_Ora_EOF(Usr_Ody) = False Then
	'                        strJdntrkb = SSSVal(CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")) '�󒍎���敪
	'                    End If
	'
	'                    Call CF_Ora_CloseDyn(Usr_Ody)   '�ް���ĸ۰��
	'
	'
	'                    '�󒍎���敪���Z�b�g�A�b�v�ƃV�X�e���̎��̂ݔz��Ɋi�[����
	'                    If strJdntrkb = "11" Or strJdntrkb = "21" Then
	'
	'                        ReDim Preserve JDNTRKB_CHK(Cnt)
	'                        With JDNTRKB_CHK(Cnt)
	'                            .idx = idxRow
	'                            .JDNNO = strJdnno
	'                            .HYJDNNO = strHyjdnno
	'                            .KOMIKN = curKomikn
	'                        End With
	'
	'                        Cnt = Cnt + 1
	'
	'                    End If
	'
	'                End If
	'            Next idxRow
	'        End With
	'
	'
	'        '�z��1�Ԗڂ̎󒍔ԍ����J�n�_�Ƃ��ăZ�b�g
	'        wkIdx = JDNTRKB_CHK(0).idx
	'        wkJdnno = JDNTRKB_CHK(0).JDNNO
	'        wkHyjdnno = JDNTRKB_CHK(0).HYJDNNO
	'
	'            For i = 0 To UBound(JDNTRKB_CHK)
	'
	'
	'            If wkJdnno = JDNTRKB_CHK(i).JDNNO Then
	'
	'                '�󒍔ԍ��������ꍇ�́A�ō�������z�����Z����B
	'                wkIdx = JDNTRKB_CHK(i).idx
	'                wkHyjdnno = JDNTRKB_CHK(i).HYJDNNO
	'                wkKomikn = wkKomikn + JDNTRKB_CHK(i).KOMIKN
	'
	'            Else
	'
	'                ''�󒍔ԍ��E�s�ԍ���蔄����z���擾����
	'                strSql = ""
	'                strSql = strSql & "SELECT SUM(URIKN) + SUM(UZEKN)   URIKN"
	'                strSql = strSql & "  FROM UDNTRA"
	'                strSql = strSql & " WHERE JDNNO     = '" & wkJdnno & "'"
	'                strSql = strSql & "   AND IRISU     <> 9"
	'                strSql = strSql & "   AND DATKB     = '1'"
	'
	'
	'                'DB�A�N�Z�X
	'                Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
	'
	'                If CF_Ora_EOF(Usr_Ody) = False Then
	'                    curUrikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")) '������z
	'                End If
	'
	'                Call CF_Ora_CloseDyn(Usr_Ody)   '�ް���ĸ۰��
	'
	'
	'                '�擾����������z�Ɖ�ʂŃ`�F�b�N����Ă��锄����z���r����B
	'                If wkKomikn <> curUrikn Then
	'
	'                    If MsgBox("�`�[�P�ʂŏ[��/�[���������s���Ă��������B" & vbCrLf & vbCrLf _
	''                                & "�sNo:" & vbTab & wkIdx & vbCrLf _
	''                                & "�󒍔ԍ�: " & vbTab & wkHyjdnno, vbOKOnly, "�O��[���߂�����") = vbOK Then
	'                        chkJdntrkb = False
	'                        GoTo END_chkJdntrkb
	'                    End If
	'
	'                End If
	'
	'                '�󒍔ԍ����Z�b�g
	'                wkIdx = JDNTRKB_CHK(i).idx
	'                wkJdnno = JDNTRKB_CHK(i).JDNNO
	'                wkKomikn = JDNTRKB_CHK(i).KOMIKN
	'
	'            End If
	'        Next i
	'
	'
	'
	'END_chkJdntrkb:
	'    '�N���[�Y
	'    Call CF_Ora_CloseDyn(Usr_Ody)
	'    Exit Function
	'
	'ERR_chkJdntrkb:
	'    GoTo END_chkJdntrkb
	'
	'
	'End Function
	'**** 2009/09/16 DEL E.N.D FKS)NAKATA
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub ChkInputChange
	'   �T�v�F  ���ׂ̓��͓��e�̕ύX�m�F
	'   �����F  ����
	'   �ߒl�F�@True:�ύX�L��  False:�ύX����
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function ChkInputChange() As Boolean
		
		Dim i As Short
		Dim vnt_AFCHK As Object
		Dim vnt_BFCHK As Object
		
		ChkInputChange = False
		
		With spd_body
			'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			For i = 1 To .MaxRows
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call .GetText(COL_CHK, i, vnt_AFCHK)
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call .GetText(COL_BFCHECK, i, vnt_BFCHK)
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(vnt_BFCHK) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(vnt_AFCHK) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If SSSVal(vnt_AFCHK) <> SSSVal(vnt_BFCHK) Then
					ChkInputChange = True
					Exit For
				End If
			Next i
		End With
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Get_NKSTRA_HAITA_INF
	'   �T�v�F  ���������g�����̔r�����擾
	'   �����F  ����
	'   �ߒl�F�@True:����  False:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Get_NKSTRA_HAITA_INF() As Boolean
		
		Dim strSql As Object
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		'UPGRADE_WARNING: �\���� Usr_Ody_1 �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_1 As U_Ody
		Dim i As Integer
		Dim Lng_Cnt As Integer
		
		Get_NKSTRA_HAITA_INF = False
		
		ReDim ARY_NKSTRA_HAITA(0)
		
		For i = 1 To UBound(ARY_UDNTRA_HAITA)
			'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSql = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSql = strSql & "SELECT " & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSql = strSql & "       KDNNO  " & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSql = strSql & "      ,OPEID  " & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSql = strSql & "      ,CLTID  " & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSql = strSql & "      ,WRTDT  " & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSql = strSql & "      ,WRTTM  " & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSql = strSql & "      ,UOPEID " & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSql = strSql & "      ,UCLTID " & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSql = strSql & "      ,UWRTDT " & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSql = strSql & "      ,UWRTTM " & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSql = strSql & "FROM " & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSql = strSql & "       NKSTRA " & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSql = strSql & "WHERE " & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSql = strSql & "       UDNDATNO = '" & ARY_UDNTRA_HAITA(i).DATNO & "' " & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSql = strSql & "AND    UDNLINNO = '" & ARY_UDNTRA_HAITA(i).LINNO & "' " & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSql = strSql & "AND    DATKB    = '1' " & vbCrLf
			
			'DB�A�N�Z�X
			'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
			
			Do While CF_Ora_EOF(Usr_Ody) = False
				
				'����f�[�^�����݂��邩�m�F���A���Ȃ��ꍇ�͎���������Ă��Ȃ��̂ŁA���������R�[�h���������{����
				'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSql = ""
				'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSql = strSql & "SELECT " & vbCrLf
				'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSql = strSql & "       KDNNO " & vbCrLf
				'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSql = strSql & "FROM " & vbCrLf
				'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSql = strSql & "       NKSTRA " & vbCrLf
				'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSql = strSql & "WHERE " & vbCrLf
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSql = strSql & "       MOTKDNNO = '" & CF_Ora_GetDyn(Usr_Ody, "KDNNO", "") & "' " & vbCrLf
				
				'DB�A�N�Z�X
				'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_1, strSql)
				
				If CF_Ora_EOF(Usr_Ody_1) Then
					Lng_Cnt = Lng_Cnt + 1
					ReDim Preserve ARY_NKSTRA_HAITA(Lng_Cnt)
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_NKSTRA_HAITA(Lng_Cnt).KDNNO = CStr(CF_Ora_GetDyn(Usr_Ody, "KDNNO", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_NKSTRA_HAITA(Lng_Cnt).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "OPEID", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_NKSTRA_HAITA(Lng_Cnt).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "CLTID", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_NKSTRA_HAITA(Lng_Cnt).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_NKSTRA_HAITA(Lng_Cnt).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_NKSTRA_HAITA(Lng_Cnt).UOPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "UOPEID", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_NKSTRA_HAITA(Lng_Cnt).UCLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "UCLTID", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_NKSTRA_HAITA(Lng_Cnt).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTDT", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ARY_NKSTRA_HAITA(Lng_Cnt).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTTM", ""))
				End If
				
				Call CF_Ora_CloseDyn(Usr_Ody_1) '�ް���ĸ۰��
				'UPGRADE_WARNING: �I�u�W�F�N�g Usr_Ody.Obj_Ody.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Usr_Ody.Obj_Ody.MoveNext()
			Loop 
			Call CF_Ora_CloseDyn(Usr_Ody) '�ް���ĸ۰��
		Next i
		
		Get_NKSTRA_HAITA_INF = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Get_NKSTRA_TEGDT
	'   �T�v�F  ���������g�����̊����U�����̎擾
	'   �����F  ����
	'   �ߒl�F�@True:����  False:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Get_NKSTRA_TEGDT(ByRef vnt_UDNDATNO As Object, ByRef vnt_UDNLINNO As Object) As String
		
		Dim strSql As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		'UPGRADE_WARNING: �\���� Usr_Ody_1 �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_1 As U_Ody
		Dim strTEGDT As String
		Dim blnExist As Boolean
		
		strTEGDT = ""
		
		blnExist = False
		
		
		strSql = ""
		strSql = strSql & "SELECT " & vbCrLf
		strSql = strSql & "       MAX(TEGDT) TEGDT " & vbCrLf
		strSql = strSql & "FROM " & vbCrLf
		strSql = strSql & "       NKSTRA " & vbCrLf
		strSql = strSql & "WHERE " & vbCrLf
		'UPGRADE_WARNING: �I�u�W�F�N�g vnt_UDNDATNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSql = strSql & "       UDNDATNO = '" & vnt_UDNDATNO & "' " & vbCrLf
		'UPGRADE_WARNING: �I�u�W�F�N�g vnt_UDNLINNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSql = strSql & "AND    UDNLINNO = '" & vnt_UDNLINNO & "' " & vbCrLf
		strSql = strSql & "AND    DATKB    = '1' " & vbCrLf
		strSql = strSql & "AND    AKAKROKB = '1' " & vbCrLf
		strSql = strSql & "AND    KDNNO NOT IN ( " & vbCrLf
		strSql = strSql & "       SELECT " & vbCrLf
		strSql = strSql & "              MOTKDNNO " & vbCrLf
		strSql = strSql & "       FROM " & vbCrLf
		strSql = strSql & "              NKSTRA " & vbCrLf
		strSql = strSql & "       WHERE " & vbCrLf
		'UPGRADE_WARNING: �I�u�W�F�N�g vnt_UDNDATNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSql = strSql & "              UDNDATNO = '" & vnt_UDNDATNO & "' " & vbCrLf
		'UPGRADE_WARNING: �I�u�W�F�N�g vnt_UDNLINNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSql = strSql & "       AND    UDNLINNO = '" & vnt_UDNLINNO & "' " & vbCrLf
		strSql = strSql & "       AND    TRIM(MOTKDNNO) IS NOT NULL " & vbCrLf
		strSql = strSql & "       ) " & vbCrLf
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		If Not CF_Ora_EOF(Usr_Ody) Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strTEGDT = CF_Ora_GetDyn(Usr_Ody, "TEGDT", "")
		End If
		
		Get_NKSTRA_TEGDT = strTEGDT
		
	End Function
	'*** 2009/09/03 ADD START FKS)NAKATA V1.03
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Get_NYUKN_TEGDT
	'   �T�v�F  ����g����.�������R�[�h�̊����U�����̎擾
	'   �����F  ����
	'   �ߒl�F�@True:����  False:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Get_NYUKN_TEGDT(ByRef vnt_JDNNO As String, ByRef vnt_JDNLINNO As String) As String
		
		Dim strSql As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		'UPGRADE_WARNING: �\���� Usr_Ody_1 �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_1 As U_Ody
		Dim strTEGDT As String
		Dim strOkrjono As String
		Dim blnExist As Boolean
		
		strTEGDT = ""
		
		blnExist = False
		
		strOkrjono = getOKRJONO(vnt_JDNNO, vnt_JDNLINNO)
		
		
		strSql = " "
		strSql = strSql & " SELECT  " & vbCrLf
		strSql = strSql & "   MAX(TEGDT) AS TEGDT" & vbCrLf
		strSql = strSql & "  FROM  UDNTRA TRA" & vbCrLf
		strSql = strSql & " WHERE  TRA.DENKB     =   '8'" & vbCrLf
		strSql = strSql & "   AND  TRA.DATKB     =   '1'" & vbCrLf
		strSql = strSql & "   AND  TRA.AKAKROKB  =   '1'" & vbCrLf
		strSql = strSql & "   AND  TRA.KESIKB    =   '9'" & vbCrLf
		strSql = strSql & "   AND  TRA.OKRJONO   =   '" & strOkrjono & "'" & vbCrLf
		strSql = strSql & "   AND  TRA.DATNO IN" & vbCrLf
		strSql = strSql & "            ( SELECT MAX(DATNO)" & vbCrLf
		strSql = strSql & "                FROM  UDNTRA" & vbCrLf
		strSql = strSql & "               WHERE  DENKB    =  '8'" & vbCrLf
		strSql = strSql & "                 AND  DATKB    =  '1'" & vbCrLf
		strSql = strSql & "                 AND  DKBID   !=  '09'" & vbCrLf
		strSql = strSql & "                 AND  OKRJONO  =  '" & strOkrjono & "'" & vbCrLf
		strSql = strSql & "            )" & vbCrLf
		
		
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		If Not CF_Ora_EOF(Usr_Ody) Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strTEGDT = CF_Ora_GetDyn(Usr_Ody, "TEGDT", "")
		End If
		
		Get_NYUKN_TEGDT = strTEGDT
		
	End Function
	'*** 2009/09/03 ADD E.N.D FKS)NAKATA V1.03
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function chkCondition
	'   �T�v�F  �w�b�_���̓��̓`�F�b�N
	'   �����F  ����
	'   �ߒl�F�@True:����  False:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function chkCondition() As Boolean
		chkCondition = False
		
		'�`�F�b�N�F������
		With txt_kesidt
			If Trim(.Text) = "" Then
				'�K�{���̓`�F�b�N
				Call showMsg("0", "_HEADCOMPLETEC", "0") '�����o�����ʹװMSG
				.ForeColor = System.Drawing.Color.Red
				.Focus()
				Exit Function
			Else
				intChkKb = 1
				'�`�F�b�N����
				If chkKesidt(True) = False Then '�`�F�b�N�����������I�ɑ��点��
					'�G���[
					Call .Focus()
					Exit Function
				End If
			End If
		End With
		
		'�`�F�b�N�F������R�[�h
		With txt_tokseicd
			If Trim(.Text) = "" Then
				'�K�{���̓`�F�b�N
				Call showMsg("0", "_HEADCOMPLETEC", "0") '�����o�����ʹװMSG
				.ForeColor = System.Drawing.Color.Red
				.Focus()
				Exit Function
			Else
				intChkKb = 1
				'�`�F�b�N����
				If chkTokseicd(True) = False Then '�`�F�b�N�����������I�ɑ��点��
					'�G���[
					Call .Focus()
					Exit Function
				End If
			End If
		End With
		
		'�`�F�b�N�F�����(�J�n)
		With txt_kaidt_From
			If Trim(.Text) = "" Then
				If Trim(txt_kesikb.Text) = "9" Then
					'�K�{���̓`�F�b�N
					Call showMsg("0", "_HEADCOMPLETEC", "0") '�����o�����ʹװMSG
					.ForeColor = System.Drawing.Color.Red
					.Focus()
					Exit Function
				End If
			Else
				intChkKb = 1
				If chkKaidt_From(True) = False Then '�`�F�b�N�����������I�ɑ��点��
					'�G���[
					.Focus()
					Exit Function
				End If
			End If
		End With
		
		'�`�F�b�N�F�����(�I��)
		With txt_kaidt_To
			If Trim(.Text) = "" Then
				'�K�{���̓`�F�b�N
				Call showMsg("0", "_HEADCOMPLETEC", "0") '�����o�����ʹװMSG
				.ForeColor = System.Drawing.Color.Red
				.Focus()
				Exit Function
			Else
				intChkKb = 1
				'�`�F�b�N����
				If chkKaidt_To(True) = False Then '�`�F�b�N�����������I�ɑ��点��
					'�G���[
					.Focus()
					Exit Function
				End If
			End If
		End With
		
		With txt_fridt
			If Trim(.Text) = "" Then
				If blnFriEnabled = True Then
					'�K�{���̓`�F�b�N
					Call showMsg("0", "_HEADCOMPLETEC", "0") '�����o�����ʹװMSG
					
					.Enabled = True
					
					.ForeColor = System.Drawing.Color.Red
					.Focus()
					Exit Function
				End If
			Else
				intChkKb = 1
				'�`�F�b�N����
				If chkFridt(True) = False Then '�`�F�b�N�����������I�ɑ��点��
					'�G���[
					.Focus()
					Exit Function
				End If
			End If
		End With
		
		chkCondition = True
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function chkKesidt
	'   �T�v�F  �������t�̃`�F�b�N
	'   �����F  pin_blnChk : True=�����I�Ƀ`�F�b�N�����ׂđ��点��
	'   �ߒl�F�@True:����  False:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function chkKesidt(Optional ByVal pin_blnChk As Boolean = False) As Boolean
		Dim date1 As String
		Dim date2 As String
		Dim date3 As String
		
		chkKesidt = False
		
		With txt_kesidt
			If pin_blnChk = False Then
				'�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
				If intChkKb <> 1 Then
					chkKesidt = True
					GoTo END_STEP
				End If
				If .Text = CNV_DATE(gstrKesidt.Value) Then
					chkKesidt = True
					GoTo END_STEP
				End If
			End If
			
			'�󔒓��͎��̓`�F�b�N���Ȃ��ichkCondition�Ń`�F�b�N�j
			If Trim(.Text) = "" Then
				chkKesidt = True
				Exit Function
			End If
			
			'���t�`���̃`�F�b�N
			If IsDate(.Text) = False Then
				Call showMsg("2", "DATE", CStr(0)) '�����t����MSG
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			
			'2009/09/03 ADD START RISE)MIYAJIMA
			'�������̃`�F�b�N���A�O�񌎎��X�V���s�������łȂ��A�O�񐿋������Ƃ̃`�F�b�N���K�v
			If Trim(txt_tokseicd.Text) <> "" Then
				If DeCNV_DATE(.Text) <= DB_TOKMTA.TOKSMEDT Then
					Call showMsg("2", "URKET73_042", CStr(0)) '�����������ȑO�ł��B���̓��t�ł͓��͂ł��܂���BMSG
					.ForeColor = System.Drawing.Color.Red
					GoTo END_STEP
				End If
			End If
			'2009/09/03 ADD E.N.D RISE)MIYAJIMA
			
			
			'�o�������ȑO�̓��t�̎��̓G���[
			If DeCNV_DATE(.Text) <= DB_SYSTBA.SMAUPDDT Then
				'If DeCNV_DATE(.Text) <= DB_SYSTBA.MONUPDDT Then '�����{�����̏����P�p
				Call showMsg("1", "URKET73_010", CStr(0)) '���o�����ߍς݂�MSG
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			'�^�p��������t�̎��̓G���[
			If DeCNV_DATE(.Text) > gstrUnydt.Value Then
				Call showMsg("2", "DATE_1", CStr(3)) '���^�p������t�G���[
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			'���߂��ׂ��ł̓��t�̓G���[
			date1 = VB6.Format(CNV_DATE(VB.Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")
			date2 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 2, CDate(date1)))
			date3 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, CDate(date2)))
			If DeCNV_DATE(.Text) > DeCNV_DATE(date3) Then
				Call showMsg("1", "URKET73_038", CStr(0)) '�����߂��ׂ��ł̓��t�͓��͂ł��܂���
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			.ForeColor = System.Drawing.Color.Black
		End With
		
		chkKesidt = True
		
END_STEP: 
		
		gstrKesidt.Value = DeCNV_DATE((txt_kesidt.Text))
		intChkKb = 2 '����{�͕ύX���Ƀ`�F�b�N
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function chkTokseicd
	'   �T�v�F  �����溰�ނ̃`�F�b�N
	'   �����F  pin_blnChk : True=�����I�Ƀ`�F�b�N�����ׂđ��点��
	'   �ߒl�F�@True:����  False:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function chkTokseicd(Optional ByVal pin_blnChk As Boolean = False) As Boolean
		
		
		'2009/09/07 ADD START FKS)NAKATA
		Dim strTANCLAKB As String
		'2009/09/07 ADD E.N.D FKS)NAKATA
		
		
		chkTokseicd = False
		
		With txt_tokseicd
			If pin_blnChk = False Then
				'�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
				If intChkKb <> 1 Then
					chkTokseicd = True
					GoTo END_STEP
				End If
				If .Text = gstrTokseicd.Value Then
					chkTokseicd = True
					GoTo END_STEP
				End If
			End If
			
			'�ύX����Ă����獀�ڃN���A
			If .Text <> gstrTokseicd.Value Then
				txt_tokseinma.Text = ""
				txt_fridt.Text = Space(8)
				txt_fridt.Enabled = False
				
				lbl_shakbnm(1).Text = ""
				lbl_hytokkesdd(1).Text = ""
				gstrFridt.Value = Space(8)
			End If
			
			'�󔒓��͎��̓`�F�b�N���Ȃ��ichkCondition�Ń`�F�b�N�j
			If Trim(.Text) = "" Then
				chkTokseicd = True
				Exit Function
			End If
			
			blnFriEnabled = False
			
			'���Ӑ�Ͻ����琿���於�̂��擾
			Select Case getTokseinm(DeCNV_DATE((txt_kesidt.Text)), .Text)
				'����������̂Ƃ�
				Case 0
					.ForeColor = System.Drawing.Color.Black
					txt_tokseinma.Text = DB_TOKMTA.TOKRN
					lbl_shakbnm(1).Text = DB_TOKMTA.SHAKBNM
					lbl_hytokkesdd(1).Text = DB_TOKMTA.HYTOKKESDD
					
					
					'2009/09/07 ADD START FKS)NAKATA V1.04
					'�������̃`�F�b�N���A�O�񌎎��X�V���s�������łȂ��A�O�񐿋������Ƃ̃`�F�b�N���K�v
					If DeCNV_DATE((txt_kesidt.Text)) <= DB_TOKMTA.TOKSMEDT Then
						Call showMsg("2", "URKET73_042", CStr(0)) '�����������ȑO�ł��B���̓��t�ł͓��͂ł��܂���BMSG
						txt_kesidt.ForeColor = System.Drawing.Color.Red
						txt_kesidt.Focus()
						GoTo END_STEP
					End If
					'2009/09/07 ADD E.N.D FKS)NAKATA
					'2009/09/07 ADD START FKS)NAKATA V1.04
					Call F_Util_GET_TANMTA_TANCLAKB(DB_TOKMTA.TANCD, strTANCLAKB)
					If strTANCLAKB <> "1" Then
						Call showMsg("2", "URKET73_043", CStr(0)) '��������S���҂��c�Ƃł���܂���B
						.ForeColor = System.Drawing.Color.Red
						GoTo END_STEP
					End If
					'2009/09/07 ADD E.N.D FKS)NAKATA
					
					
					
					'*** 2009/09/03 CHG START FKS)NAKATA V1.03
					'�U�������́A�����g�������͔���g����.�������R�[�h���擾���邽��
					''                Call getInputHYFRIDT(DB_TOKMTA.TOKSEICD _
					'''                                    , Get_Acedt(DeCNV_DATE(txt_kesidt.Text)) _
					'''                                    , DB_TOKMTA.SHAKB)
					''
					''                txt_fridt.Enabled = blnFriEnabled
					blnFriEnabled = False
					'*** 2009/09/03 CHG E.N.D FKS)NAKATA V1.03
					
					chkTokseicd = True
					
					'�C�O������̂Ƃ�
				Case 1
					Call showMsg("1", "URKET73_013", CStr(0)) '�������̓��Ӑ�ł͂���܂���B
					.ForeColor = System.Drawing.Color.Red
					GoTo END_STEP
					
					'������łȂ����Ӑ�̂Ƃ�
				Case 8
					Call showMsg("2", "DONTSELECT", "2") '��������ł͂Ȃ�
					.ForeColor = System.Drawing.Color.Red
					GoTo END_STEP
					
					'�����悪���݂��Ȃ���
				Case 9
					Call showMsg("2", "RNOTFOUND", "0") '���Y���f�[�^�Ȃ�
					.ForeColor = System.Drawing.Color.Red
					GoTo END_STEP
			End Select
			
			.ForeColor = System.Drawing.Color.Black
		End With
		
		chkTokseicd = True
		
END_STEP: 
		
		gstrTokseicd.Value = txt_tokseicd.Text
		intChkKb = 2 '����{�͕ύX���Ƀ`�F�b�N
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function chkKaidt_From
	'   �T�v�F  ����\����t�i�J�n�j�̃`�F�b�N
	'   �����F  pin_blnChk : True=�����I�Ƀ`�F�b�N�����ׂđ��点��
	'   �ߒl�F�@True:����  False:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function chkKaidt_From(Optional ByVal pin_blnChk As Boolean = False) As Boolean
		Dim date1 As String
		Dim date2 As String
		Dim date3 As String
		
		chkKaidt_From = False
		
		With txt_kaidt_From
			If pin_blnChk = False Then
				'�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
				If intChkKb <> 1 Then
					chkKaidt_From = True
					GoTo END_STEP
				End If
				If .Text = CNV_DATE(gstrKaidt_Fr.Value) Then
					chkKaidt_From = True
					GoTo END_STEP
				End If
			End If
			
			'�󔒓��͎��̓`�F�b�N���Ȃ��ichkCondition�Ń`�F�b�N�j
			If Trim(.Text) = "" Then
				gstrKaidt_Fr.Value = ""
				chkKaidt_From = True
				Exit Function
			End If
			
			'���t�`���̃`�F�b�N
			If IsDate(.Text) = False Then
				Call showMsg("2", "DATE", CStr(0)) '�����t����MSG
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			'���߂��ׂ��ł̓��t�̓G���[
			date1 = VB6.Format(CNV_DATE(VB.Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")
			date2 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 2, CDate(date1)))
			date3 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, CDate(date2)))
			If DeCNV_DATE(.Text) > DeCNV_DATE(date3) Then
				Call showMsg("1", "URKET73_038", CStr(0)) '�����߂��ׂ��ł̓��t�͓��͂ł��܂���
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			'����������ʂŎ󒍓�(�����)�������������̓G���[
			If IsDate(.Text) And IsDate(txt_kesidt.Text) Then
				If VB6.Format(.Text, "0000/00/00") > VB6.Format(txt_kesidt.Text, "0000/00/00") Then
					Call showMsg("2", "DATE", CStr(0)) '�����t����MSG
					.ForeColor = System.Drawing.Color.Red
					GoTo END_STEP
				End If
			End If
			
			.ForeColor = System.Drawing.Color.Black
		End With
		
		chkKaidt_From = True
		
END_STEP: 
		
		gstrKaidt_Fr.Value = DeCNV_DATE((txt_kaidt_From.Text))
		intChkKb = 2 '����{�͕ύX���Ƀ`�F�b�N
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function chkKaidt_To
	'   �T�v�F  ����\����t�i�I���j�̃`�F�b�N
	'   �����F  pin_blnChk : True=�����I�Ƀ`�F�b�N�����ׂđ��点��
	'   �ߒl�F�@True:����  False:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function chkKaidt_To(Optional ByVal pin_blnChk As Boolean = False) As Boolean
		Dim date1 As String
		Dim date2 As String
		Dim date3 As String
		
		chkKaidt_To = False
		
		With txt_kaidt_To
			If pin_blnChk = False Then
				'�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
				If intChkKb <> 1 Then
					chkKaidt_To = True
					GoTo END_STEP
				End If
				If .Text = CNV_DATE(gstrKaidt_To.Value) Then
					chkKaidt_To = True
					GoTo END_STEP
				End If
			End If
			
			'�󔒓��͎��̓`�F�b�N���Ȃ��ichkCondition�Ń`�F�b�N�j
			If Trim(.Text) = "" Then
				chkKaidt_To = True
				Exit Function
			End If
			
			'���t�`���̃`�F�b�N
			If IsDate(.Text) = False Then
				Call showMsg("2", "DATE", CStr(0)) '�����t����MSG
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			'���߂��ׂ��ł̓��t�̓G���[
			date1 = VB6.Format(CNV_DATE(VB.Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")
			date2 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 2, CDate(date1)))
			date3 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, CDate(date2)))
			If DeCNV_DATE(.Text) > DeCNV_DATE(date3) Then
				Call showMsg("1", "URKET73_038", CStr(0)) '�����߂��ׂ��ł̓��t�͓��͂ł��܂���
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			'����������ʂŎ󒍓�(�����)�������������̓G���[
			If IsDate(.Text) And IsDate(txt_kesidt.Text) Then
				If VB6.Format(.Text, "0000/00/00") > VB6.Format(txt_kesidt.Text, "0000/00/00") Then
					Call showMsg("2", "DATE", CStr(0)) '�����t����MSG
					.ForeColor = System.Drawing.Color.Red
					GoTo END_STEP
				End If
			End If
			
			'���t�̑召��r
			If IsDate(txt_kaidt_From.Text) And IsDate(.Text) Then
				If VB6.Format(txt_kaidt_From.Text, "0000/00/00") > VB6.Format(.Text, "0000/00/00") Then
					Call showMsg("2", "DATE", CStr(0)) '�����t����MSG
					.ForeColor = System.Drawing.Color.Red
					txt_kaidt_From.ForeColor = System.Drawing.Color.Red
					GoTo END_STEP
				Else
					'�`�F�b�N�G���[�Ȃ�
					txt_kaidt_From.ForeColor = System.Drawing.Color.Black
				End If
			End If
			
			.ForeColor = System.Drawing.Color.Black
		End With
		
		chkKaidt_To = True
		
END_STEP: 
		
		gstrKaidt_To.Value = DeCNV_DATE((txt_kaidt_To.Text))
		intChkKb = 2 '����{�͕ύX���Ƀ`�F�b�N
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function chkFridt
	'   �T�v�F  �U�������̃`�F�b�N
	'   �����F  pin_blnChk : True=�����I�Ƀ`�F�b�N�����ׂđ��点��
	'   �ߒl�F�@True:����  False:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function chkFridt(Optional ByVal pin_blnChk As Boolean = False) As Boolean
		chkFridt = False
		
		With txt_fridt
			If pin_blnChk = False Then
				'�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
				If intChkKb <> 1 Then
					chkFridt = True
					GoTo END_STEP
				End If
				If .Text = CNV_DATE(gstrFridt.Value) Then
					chkFridt = True
					GoTo END_STEP
				End If
			End If
			
			'�󔒓��͎��̓`�F�b�N���Ȃ��ichkCondition�Ń`�F�b�N�j
			If Trim(.Text) = "" Then
				chkFridt = True
				Exit Function
			End If
			
			'���t�`���̃`�F�b�N
			If IsDate(.Text) = False Then
				Call showMsg("2", "DATE", CStr(0)) '�����t����MSG
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			'�o�������ȑO�̓��t�̎��̓G���[
			If DeCNV_DATE(.Text) <= DB_SYSTBA.SMAUPDDT Then
				'If DeCNV_DATE(.Text) <= DB_SYSTBA.MONUPDDT Then '�����{�����̏����P�p
				Call showMsg("1", "URKET73_010", CStr(0)) '���o�����ߍς݂�MSG
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			.ForeColor = System.Drawing.Color.Black
		End With
		
		chkFridt = True
		
END_STEP: 
		
		gstrFridt.Value = DeCNV_DATE((txt_fridt.Text))
		intChkKb = 2 '����{�͕ύX���Ƀ`�F�b�N
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub Ctl_DTItem_Change
	'   �T�v�F  ���t���ړ��t�ϊ�
	'   �����F  pm_objDt      : ���t���ڵ�޼ު��
	'   �ߒl�F�@����
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub Ctl_DTItem_Change(ByRef pm_objDt As Object)
		
		With pm_objDt
			'�X���b�V�������݂��Ă���Ƃ��́A�X���b�V�����΂��Ď��̍��ڂ�
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Mid(.Text, .SelStart + 1, 1) = "/" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.SelStart = .SelStart + 1
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SelLength = 1
			
			'���͂��ꂽ�l���W���ɓ��B�����̂ŃX���b�V���ҏW����
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Len(Trim(.Text)) = 8 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.Text = VB6.Format(.Text, "0000/00/00")
				'���t�̓��̕�����I����Ԃɂ���
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.SelStart = 8
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.SelLength = 1
			End If
		End With
		
	End Sub
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub Ctl_DTItem_GotFocus
	'   �T�v�F  ���t���ڂ̃J�[�\���ʒu�t��
	'   �����F  pm_objDt      : ���t���ڵ�޼ު��
	'   �ߒl�F�@����
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub Ctl_DTItem_GotFocus(ByRef pm_objDt As Object)
		
		With pm_objDt
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.ForeColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(.Text) = "" Or pm_objDt.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red) Then
				'�Ȃɂ������Ă��Ȃ��܂��̓G���[�̎��ɐ擪�ֈʒu�Â�
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.SelStart = 0
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.SelLength = 1
			Else
				'�Ȃɂ������Ă�������t�̏\�̈ʂ�I����Ԃɂ���
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.SelStart = 8
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.SelLength = 1
			End If
			'�w�i�F�����F�ɂ���
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.BackColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
		End With
		
	End Sub
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub Ctl_DTItem_KeyDown
	'   �T�v�F  �����溰�ރL�[���͐���
	'   �����F  pm_KeyCode    : �L�[�R�[�h
	'           pm_Shift      : �V�t�g�������
	'           pm_objDt      : �����溰�޵�޼ު��
	'   �ߒl�F�@0:�ړ����� 1:������ 2:�O����
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_tokseicd_KeyDown(ByRef pm_KeyCode As Short, ByRef pm_Shift As Short, ByRef pm_objCD As Object) As Short
		
		Ctl_tokseicd_KeyDown = 0
		
		With pm_objCD
			
			Select Case pm_KeyCode
				
				'�t�@���N�V�����L�[������
				Case System.Windows.Forms.Keys.F1 To System.Windows.Forms.Keys.F12
					'�t�@���N�V�����L�[���ʏ���
					Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
					
					'�E��󉟉���
				Case System.Windows.Forms.Keys.Right
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_objCD.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If .SelStart < 4 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_objCD.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.SelStart = .SelStart + 1
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_objCD.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.SelLength = 1
					Else
						intChkKb = 2 '�������溰�ނ̓��̓`�F�b�N�i�ύX���̂݁j
						Ctl_tokseicd_KeyDown = 1
					End If
					
					'Backspace or ����󉟉���
				Case System.Windows.Forms.Keys.Back, System.Windows.Forms.Keys.Left
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_objCD.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If .SelStart > 0 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_objCD.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.SelStart = .SelStart - 1
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_objCD.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.SelLength = 1
					Else
						'Backspace�̎��́A���͒l���󔒂̎��A�O���ڂֈړ�
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_objCD.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If Trim(.Text) <> "" And pm_KeyCode = System.Windows.Forms.Keys.Back Then
							Exit Function
						End If
						intChkKb = 2 '�������溰�ނ̓��̓`�F�b�N�i�ύX���̂݁j
						Ctl_tokseicd_KeyDown = 2
					End If
					
					'���󉟉���
				Case System.Windows.Forms.Keys.Up
					intChkKb = 2 '�������溰�ނ̓��̓`�F�b�N�i�ύX���̂݁j
					Ctl_tokseicd_KeyDown = 2
					
					'����󉟉���
				Case System.Windows.Forms.Keys.Down
					intChkKb = 2 '�������溰�ނ̓��̓`�F�b�N�i�ύX���̂݁j
					Ctl_tokseicd_KeyDown = 1
					
					'Enter������
				Case System.Windows.Forms.Keys.Return
					intChkKb = 1 '�������溰�ނ̓��̓`�F�b�N
					Ctl_tokseicd_KeyDown = 1
					
					'Delete������
				Case System.Windows.Forms.Keys.Delete
					Exit Function
					
					'TAB��
				Case System.Windows.Forms.Keys.F16
					intChkKb = 1 '�������溰�ނ̓��̓`�F�b�N
					Ctl_tokseicd_KeyDown = 1
					
					'SHIFT+TAB��
				Case System.Windows.Forms.Keys.F15
					intChkKb = 2 '�������溰�ނ̓��̓`�F�b�N
					Ctl_tokseicd_KeyDown = 2
					
				Case Else
					Exit Function
					
			End Select
			
		End With
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub Ctl_DTItem_KeyDown
	'   �T�v�F  ���t���ڃL�[���͐���
	'   �����F  pm_KeyCode    : �L�[�R�[�h
	'           pm_Shift      : �V�t�g�������
	'           pm_objDt      : ���t���ڵ�޼ު��
	'   �ߒl�F�@0:�ړ����� 1:������ 2:�O����
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_DTItem_KeyDown(ByRef pm_KeyCode As Short, ByRef pm_Shift As Short, ByRef pm_objDt As Object) As Short
		
		Ctl_DTItem_KeyDown = 0
		
		'UPGRADE_NOTE: str �� str_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
		Dim str_Renamed As String
		With pm_objDt
			
			Select Case pm_KeyCode
				
				'�t�@���N�V�����L�[������
				Case System.Windows.Forms.Keys.F1 To System.Windows.Forms.Keys.F12
					'�t�@���N�V�����L�[���ʏ���
					Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
					
					'�E��� or Space������
				Case System.Windows.Forms.Keys.Right, System.Windows.Forms.Keys.Space
					
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If .SelStart < 9 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.SelStart = .SelStart + 1
						'�X���b�V���ɃJ�[�\���������玟�̕����ɃJ�[�\�����ړ�
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If .SelStart = 4 And Mid(.Text, .SelStart + 1, 1) = "/" Or .SelStart = 7 And Mid(.Text, .SelStart + 1, 1) = "/" Then
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							.SelStart = .SelStart + 1
						End If
						'�J�[�\�����E�[�ɗ����玟�̍��ڂֈړ�
					Else
						intChkKb = 2 '�����t�̓��̓`�F�b�N�i�ύX���̂�)
						Ctl_DTItem_KeyDown = 1
					End If
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.SelLength = 1
					
					'Backspace or ����󉟉���
				Case System.Windows.Forms.Keys.Back, System.Windows.Forms.Keys.Left
					
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If .SelStart > 0 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.SelStart = .SelStart - 1
						'�X���b�V���ɃJ�[�\����������O�̕����ɃJ�[�\�����ړ�
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If .SelStart = 4 And Mid(.Text, .SelStart + 1, 1) = "/" Or .SelStart = 7 And Mid(.Text, .SelStart + 1, 1) = "/" Then
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							.SelStart = .SelStart - 1
						End If
						
						'�J�[�\�������[�ɗ�����O�̍��ڂֈړ�
					Else
						intChkKb = 2 '�����t�̓��̓`�F�b�N�i�ύX���̂�)
						Ctl_DTItem_KeyDown = 2
					End If
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.SelLength = 1
					
					'���󉟉���
				Case System.Windows.Forms.Keys.Up
					intChkKb = 2 '�����t�̓��̓`�F�b�N�i�ύX���̂�)
					Ctl_DTItem_KeyDown = 2
					
					'����󉟉���
				Case System.Windows.Forms.Keys.Down
					intChkKb = 2 '�����t�̓��̓`�F�b�N�i�ύX���̂�)
					Ctl_DTItem_KeyDown = 1
					
					'Enter������
				Case System.Windows.Forms.Keys.Return
					intChkKb = 1 '�����t�̓��̓`�F�b�N
					Ctl_DTItem_KeyDown = 1
					
					'TAB��
				Case System.Windows.Forms.Keys.F16
					intChkKb = 1 '�����t�̓��̓`�F�b�N
					Ctl_DTItem_KeyDown = 1
					
					'Shift+TAB��
				Case System.Windows.Forms.Keys.F15
					intChkKb = 2 '�����t�̓��̓`�F�b�N�i�ύX���̂�)
					Ctl_DTItem_KeyDown = 2
					
					'Shift+DELETE��
				Case System.Windows.Forms.Keys.Delete And pm_Shift = 1
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					str_Renamed = .Text
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Len(str_Renamed) > 0 And .SelStart < Len(str_Renamed) Then
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						str_Renamed = Mid(str_Renamed, 1, .SelStart) & Mid(str_Renamed, .SelStart + 2)
						str_Renamed = Replace(str_Renamed, "/", "")
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.SelStart = 0
						If Len(str_Renamed) > 0 Then
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							.SelLength = 1
						End If
					End If
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = str_Renamed
					
			End Select
			
		End With
		
	End Function
	
	
	'=======================================================����\���(�J�n)=======================================================
	
	'����\����N���b�N��
	Private Sub txt_kaidt_From_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_From.Click
		
		txt_kaidt_From.SelectionStart = 0
		txt_kaidt_From.SelectionLength = 1
		
	End Sub
	
	'����\������ڂ�ύX������
	'UPGRADE_WARNING: �C�x���g txt_kaidt_From.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txt_kaidt_From_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_From.TextChanged
		
		'���t�ϊ�����
		Call Ctl_DTItem_Change(txt_kaidt_From)
		
	End Sub
	
	'����\������ڂɃt�H�[�J�X���ڂ�����
	Private Sub txt_kaidt_From_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_From.Enter
		
		'�J�[�\���ʒu�t��
		Call Ctl_DTItem_GotFocus(txt_kaidt_From)
		
		'�������������s�\�Ƃ���
		mnu_showwnd.Enabled = True
		
	End Sub
	
	'����\������ڂŃL�[����������
	Private Sub txt_kaidt_From_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_kaidt_From.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		'�L�[���͐���
		Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_kaidt_From)
			Case 0
				'�������Ȃ�
			Case 1
				'���̓`�F�b�N
				If chkKaidt_From = True Then
					'������
					txt_kaidt_To.Focus()
				End If
			Case 2
				'���̓`�F�b�N
				If chkKaidt_From = True Then
					'�O����
					txt_tokseicd.Focus()
				End If
		End Select
		
		KeyCode = 0
		
	End Sub
	
	'����\������ڂŃL�[����������
	Private Sub txt_kaidt_From_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_kaidt_From.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		'���l�̂ݓ��͉Ƃ���
		If Not Chr(KeyAscii) Like "[0-9]" Then
			KeyAscii = 0
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'����\������ڂ���t�H�[�J�X���ڂ�����
	Private Sub txt_kaidt_From_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_From.Leave
		
		'�w�i�F�𔒂ɖ߂�
		txt_kaidt_From.BackColor = System.Drawing.Color.White
		
	End Sub
	
	'=======================================================����\���(�I��)=======================================================
	
	'����\����N���b�N��
	Private Sub txt_kaidt_To_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_To.Click
		
		txt_kaidt_To.SelectionStart = 0
		txt_kaidt_To.SelectionLength = 1
		
	End Sub
	
	'����\������ڂ�ύX������
	'UPGRADE_WARNING: �C�x���g txt_kaidt_To.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txt_kaidt_To_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_To.TextChanged
		
		'���t�ϊ�����
		Call Ctl_DTItem_Change(txt_kaidt_To)
		
	End Sub
	
	'����\������ڂɃt�H�[�J�X���ڂ�����
	Private Sub txt_kaidt_To_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_To.Enter
		
		'�J�[�\���ʒu�t��
		Call Ctl_DTItem_GotFocus(txt_kaidt_To)
		
		'�������������s�\�Ƃ���
		mnu_showwnd.Enabled = True
		
	End Sub
	
	'����\������ڂŃL�[����������
	Private Sub txt_kaidt_To_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_kaidt_To.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		'�L�[���͐���
		Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_kaidt_To)
			Case 0
				'�������Ȃ�
			Case 1
				'���̓`�F�b�N
				If chkKaidt_To = True Then
					'������
					txt_kesikb.Focus()
				End If
			Case 2
				'���̓`�F�b�N
				If chkKaidt_To = True Then
					'�O����
					txt_kaidt_From.Focus()
				End If
		End Select
		
		KeyCode = 0
		
	End Sub
	
	'����\������ڂŃL�[����������
	Private Sub txt_kaidt_To_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_kaidt_To.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		'���l�̂ݓ��͉Ƃ���
		If Not Chr(KeyAscii) Like "[0-9]" Then
			KeyAscii = 0
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'����\������ڂ���t�H�[�J�X���ڂ�����
	Private Sub txt_kaidt_To_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_To.Leave
		
		'�w�i�F�𔒂ɖ߂�
		txt_kaidt_To.BackColor = System.Drawing.Color.White
		
	End Sub
	
	'=======================================================������=======================================================
	
	'���������ڃN���b�N��
	Private Sub txt_kesidt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesidt.Click
		
		txt_kesidt.SelectionStart = 0
		txt_kesidt.SelectionLength = 1
		
	End Sub
	
	'���������ڂ�ύX������
	'UPGRADE_WARNING: �C�x���g txt_kesidt.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txt_kesidt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesidt.TextChanged
		
		'���t�ϊ�����
		Call Ctl_DTItem_Change(txt_kesidt)
		
	End Sub
	
	'���������ڂɃt�H�[�J�X���ڂ�����
	Private Sub txt_kesidt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesidt.Enter
		
		intInputMode = 1
		
		'�J�[�\���ʒu�t��
		Call Ctl_DTItem_GotFocus(txt_kesidt)
		
		'�������������s�\�Ƃ���
		mnu_showwnd.Enabled = True
		
	End Sub
	
	'���������ڂŃL�[����������
	Private Sub txt_kesidt_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_kesidt.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		intChkKb = 0
		
		'�L�[���͐���
		Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_kesidt)
			Case 0
				'�������Ȃ�
			Case 1
				'���̓`�F�b�N
				If chkKesidt = True Then
					'������
					txt_tokseicd.Focus()
				End If
			Case 2
				'���̓`�F�b�N
				If chkKesidt = True Then
					'�O����
					txt_kesidt.Focus()
				End If
		End Select
		
		KeyCode = 0
		
	End Sub
	
	'���������ڂŃL�[����������
	Private Sub txt_kesidt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_kesidt.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		'���l�̂ݓ��͉Ƃ���
		If Not Chr(KeyAscii) Like "[0-9]" Then
			KeyAscii = 0
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'���������ڂ���t�H�[�J�X���ڂ�����
	Private Sub txt_kesidt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesidt.Leave
		
		'�w�i�F�𔒂ɖ߂�
		txt_kesidt.BackColor = System.Drawing.Color.White
		
	End Sub
	
	'=======================================================�U������=======================================================
	
	'�U���������ڂ�ύX������
	'UPGRADE_WARNING: �C�x���g txt_fridt.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txt_fridt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_fridt.TextChanged
		
		'�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
		If blnUsableEvent = False Then
			Exit Sub
		End If
		
		'���t�ϊ�����
		Call Ctl_DTItem_Change(txt_fridt)
		
		blnUsableEvent = True
		
	End Sub
	
	'�U���������ڂɃt�H�[�J�X���ڂ�����
	Private Sub txt_fridt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_fridt.Enter
		
		'�J�[�\���ʒu�t��
		Call Ctl_DTItem_GotFocus(txt_fridt)
		
		'�������������s�\�Ƃ���
		mnu_showwnd.Enabled = True
		
	End Sub
	
	'�U���������ڂŃL�[����������
	Private Sub txt_fridt_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_fridt.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		'�L�[���͐���
		Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_fridt)
			Case 0
				'�������Ȃ�
			Case 1
				'���̓`�F�b�N
				If chkFridt = True Then
					'������
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetFocus �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					spd_body.SetFocus()
				End If
			Case 2
				'���̓`�F�b�N
				If chkFridt = True Then
					'�O����
					txt_kesikb.Focus()
				End If
		End Select
		
		KeyCode = 0
		
	End Sub
	
	'�U���������ڂŃL�[����������
	Private Sub txt_fridt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_fridt.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		'���l�̂ݓ��͉Ƃ���
		If Not Chr(KeyAscii) Like "[0-9]" Then
			KeyAscii = 0
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'�U���������ڂ���t�H�[�J�X���ڂ�����
	Private Sub txt_fridt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_fridt.Leave
		
		'�w�i�F�𔒂ɖ߂�
		txt_fridt.BackColor = System.Drawing.Color.White
		
	End Sub
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_FuncKey_Execute
	'   �T�v�F  �V�X�e�����ʏ���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function CF_FuncKey_Execute(ByVal pm_KeyCode As Short, ByVal pm_Shift As Short) As Short
		
		CF_FuncKey_Execute = 0
		
		Select Case True
			'F1�L�[����
			Case pm_KeyCode = System.Windows.Forms.Keys.F1 And pm_Shift = 0
				System.Windows.Forms.SendKeys.Send("%1")
				
				'F2�L�[����
			Case pm_KeyCode = System.Windows.Forms.Keys.F2 And pm_Shift = 0
				System.Windows.Forms.SendKeys.Send("%2")
				
				'F3�L�[����
			Case pm_KeyCode = System.Windows.Forms.Keys.F3 And pm_Shift = 0
				System.Windows.Forms.SendKeys.Send("%3")
		End Select
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_System_Process
	'   �T�v�F  �V�X�e�����ʏ���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function CF_System_Process(ByRef pm_Form As System.Windows.Forms.Form) As Short
		
		
		'�p�b�P�[�W���̂c�k�k�ɂ�
		'��s�`�a�����s�`�a�{�r�g�h�e�s������ꂼ�ꢂe�P�U�����e�P�T��Ɋ���
		ReleaseTabCapture(0)
		SetTabCapture(pm_Form.Handle.ToInt32)
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F Sub chkFurikomiDT
	'   �T�v�F TOKMTA.SHAKB�i�x�������j�Ɏ�`�������Ă���ꍇ�͐U���������K�{
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function chkFurikomiDT() As Boolean
		
		Dim idxRow As Integer
		Dim tmp As Object
		Dim intchk As Short
		Dim strHYFRIDT As String
		
		chkFurikomiDT = False
		
		If blnFriEnabled = False Then
			chkFurikomiDT = True
			Exit Function
		End If
		
		'�ԕi������
		With spd_body
			For idxRow = 1 To intMaxRow
				'�`�F�b�N�������Ă��邩���m�F
				'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.GetText(COL_CHK, idxRow, tmp)
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				intchk = SSSVal(tmp)
				
				'�`�F�b�N�������Ă���ꍇ
				If intchk = 1 Then
					'������̎擾
					'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call .GetText(COL_HYFRIDT, idxRow, tmp)
					'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strHYFRIDT = CStr(tmp)
					
					If Trim(strHYFRIDT) = "" Then
						Call showMsg("0", "_COMPLETEC", CStr(0)) '�����͂���Ă��Ȃ����ڂ�����܂��B���͂��Ă��������B
						Exit Function
					End If
				End If
			Next idxRow
		End With
		
		chkFurikomiDT = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F Function chk_HENPIN
	'   �T�v�F �����ɕԕi���������Ă��邩�`�F�b�N����
	'   �����F strJdnNo   : �󒍓`�[�ԍ�
	'   �@�@�F strJdnlinNo: �󒍓`�[�s�ԍ�
	'       :  strUrikn   : ������z
	'   �ߒl�F �`�F�b�N����
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function chkHenpin2(ByVal strJdnno As String, ByVal strJdnlinno As String, ByVal strUDNDT As String) As Boolean
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo ERR_chkHENPIN2
		
		'//�\�����܂�
		chkHenpin2 = True
		
		If Trim(gstrKaidt_Fr.Value) = "" Then
			'//�\�����܂�
			GoTo END_chkHENPIN2
		End If
		
		'//�����ɕԕi�f�[�^�����݂��Ă��邩�m�F����
		strSql = " "
		strSql = " SELECT *"
		strSql = strSql & " FROM    UDNTRA"
		strSql = strSql & " WHERE   JDNNO    =  '" & strJdnno & "'"
		strSql = strSql & " AND     JDNLINNO =  '" & strJdnlinno & "'"
		strSql = strSql & " AND     DATKB =  '1'"
		strSql = strSql & " AND     AKAKROKB =  '9'"
		strSql = strSql & " AND     DKBID    =  '02'"
		strSql = strSql & " AND     UDNDT    >= '" & gstrKaidt_Fr.Value & "'"
		strSql = strSql & " AND     UDNDT    <= '" & gstrKaidt_To.Value & "'"
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		'�f�[�^�����݂����ꍇ
		If CF_Ora_EOF(Usr_Ody) = False Then
			
			Select Case txt_kesikb.Text
				Case CStr(1)
					'��������Ă��Ȃ��ꍇ�A�������s��
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Trim(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) = "9" Then
						'//�\�����܂�
						GoTo END_chkHENPIN2
					Else
						'//�\�����܂���
						chkHenpin2 = False
						GoTo END_chkHENPIN2
					End If
				Case CStr(9)
					'��������Ă��Ȃ��ꍇ�A�������s��
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Trim(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) = "1" Then
						'//�\�����܂�
						GoTo END_chkHENPIN2
					Else
						'//�\�����܂���
						chkHenpin2 = False
						GoTo END_chkHENPIN2
					End If
			End Select
			
			'//�\�����܂�
			GoTo END_chkHENPIN2
			
		End If
		
		'�f�[�^�����݂��Ȃ������ꍇ
		If Trim(strUDNDT) < Trim(gstrKaidt_Fr.Value) Then
			'//�\�����܂���
			chkHenpin2 = False
			GoTo END_chkHENPIN2
		End If
		
END_chkHENPIN2: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_chkHENPIN2: 
		GoTo END_chkHENPIN2
		
	End Function
	
	
	'�U�������̓��͉\���f
	Private Sub getInputHYFRIDT(ByVal pin_strTOKCD As String, ByVal pin_strSMADT As String, ByVal pin_strSHAKB As String)
		
		Dim strSql As Object
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		
		Dim curNYUKIN1 As Short
		Dim curNYUKIN2 As Short
		
		'���������x�̏�����Ԃ��擾
		'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSql = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSql = strSql & " SELECT * "
		'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSql = strSql & "   FROM NKSSMB "
		'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSql = strSql & "  WHERE TOKCD = '" & CF_Ora_Sgl(pin_strTOKCD) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSql = strSql & "    AND SMADT = '" & CF_Ora_Sgl(DeCNV_DATE(pin_strSMADT)) & "' "
		
		'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		'�U����������͂ł��邩�ǂ����̃t���O��ݒ肷��
		blnFriEnabled = False
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(CF_Ora_GetDyn(Usr_Ody, KSKZANKN02, )) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN02", "")) <> 0 Then
				blnFriEnabled = True
				GoTo END_getInputHYFRIDT
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(CF_Ora_GetDyn(Usr_Ody, SSANYUKN02, )) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN02", "")) <> 0 Then
				blnFriEnabled = True
				GoTo END_getInputHYFRIDT
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(CF_Ora_GetDyn(Usr_Ody, KSKNYKKN02, )) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN02", "")) <> 0 Then
				blnFriEnabled = True
				GoTo END_getInputHYFRIDT
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(CF_Ora_GetDyn(Usr_Ody, KSKZANKN07, )) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN07", "")) <> 0 Then
				blnFriEnabled = True
				GoTo END_getInputHYFRIDT
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(CF_Ora_GetDyn(Usr_Ody, SSANYUKN07, )) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN07", "")) <> 0 Then
				blnFriEnabled = True
				GoTo END_getInputHYFRIDT
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(CF_Ora_GetDyn(Usr_Ody, KSKNYKKN07, )) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN07", "")) <> 0 Then
				blnFriEnabled = True
				GoTo END_getInputHYFRIDT
			End If
		End If
		
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		
END_getInputHYFRIDT: 
		
		Call CF_Ora_CloseDyn(Usr_Ody)
		
	End Sub
	
	'����g�����E�������R�[�h(DENKB=8)�̔r���p�f�[�^�擾
	Private Sub getUdntraNyukn(ByVal strJdnno As String, ByVal strJdnlinno As String)
		
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		Dim intCnt As Short
		
		Dim strJdntrkb As String
		Dim strOkrjono As String '�����
		
		'*** 2009/08/26 ADD START FKS)NAKATA v1.02
		Dim i As Short
		Dim BlnFlg As Boolean '2�x�ǂݗp�t���O
		'*** 2009/08/26 ADD E.N.D FKS)NAKATA v1.02
		
		
		On Error GoTo ERR_UdntraNyukn
		
		
		'��x�ǂݗp�t���O������
		BlnFlg = False
		
		
		''�󒍔ԍ���著��󇂂��擾����B
		strOkrjono = getOKRJONO(strJdnno, strJdnlinno)
		
		
		'����g�����̍ŐV�̓������R�[�h���擾
		strSql = " "
		strSql = strSql & " SELECT   DATNO"
		strSql = strSql & "         ,LINNO"
		strSql = strSql & "         ,UDNNO"
		strSql = strSql & "         ,OKRJONO"
		strSql = strSql & "         ,NYUKN"
		strSql = strSql & "         ,DKBID"
		strSql = strSql & "         ,UPDID"
		strSql = strSql & "         ,OPEID"
		strSql = strSql & "         ,OPEID"
		strSql = strSql & "         ,CLTID"
		strSql = strSql & "         ,WRTDT"
		strSql = strSql & "         ,WRTTM"
		strSql = strSql & "         ,UOPEID"
		strSql = strSql & "         ,UCLTID"
		strSql = strSql & "         ,UWRTDT"
		strSql = strSql & "         ,UWRTTM"
		strSql = strSql & " FROM UDNTRA"
		strSql = strSql & "  WHERE (DATNO , UDNNO , UPDID) IN"
		strSql = strSql & " (   SELECT  MAX(DATNO)"
		strSql = strSql & "             ,UDNNO"
		strSql = strSql & "             ,UPDID"
		strSql = strSql & "      FROM   UDNTRA"
		strSql = strSql & "      WHERE  DATKB = '1'"
		strSql = strSql & "       AND   DENKB = '8'"
		strSql = strSql & "       AND   OKRJONO = '" & strOkrjono & "'"
		strSql = strSql & "      GROUP BY UDNNO, UPDID"
		strSql = strSql & " )"
		strSql = strSql & "   AND   DATKB   =   '1'"
		strSql = strSql & "   AND   AKAKROKB =   '1'"
		strSql = strSql & "   AND   DENKB = '8'"
		strSql = strSql & "   AND   OKRJONO = '" & strOkrjono & "'"
		
		
		'�ް��擾
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		Do While CF_Ora_EOF(Usr_Ody) = False
			
			ReDim Preserve ARY_UDNTRA_NYU_HAITA(ARY_UDNTRA_NYU_CNT)
			
			With ARY_UDNTRA_NYU_HAITA(ARY_UDNTRA_NYU_CNT)
				
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.DATNO = CStr(CF_Ora_GetDyn(Usr_Ody, "DATNO", ""))
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.LINNO = CStr(CF_Ora_GetDyn(Usr_Ody, "LINNO", ""))
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.UDNNO = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNNO", ""))
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.OKRJONO = CStr(CF_Ora_GetDyn(Usr_Ody, "OKRJONO", ""))
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "OPEID", ""))
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "CLTID", ""))
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.UOPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "UOPEID", ""))
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.UCLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "UCLTID", ""))
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTDT", ""))
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTTM", ""))
				
			End With
			
			ARY_UDNTRA_NYU_CNT = ARY_UDNTRA_NYU_CNT + 1
			
			'UPGRADE_WARNING: �I�u�W�F�N�g Usr_Ody.Obj_Ody.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Usr_Ody.Obj_Ody.MoveNext()
			
		Loop 
		Call CF_Ora_CloseDyn(Usr_Ody) '�ް���ĸ۰��
		
		
		
		For i = 0 To UBound(ARY_NYUKN_KS)
			'��x�ǂ݉��ϐ��Ƒ���󇂂������ꍇ�́A�f�[�^�̎擾���s��Ȃ��B
			If strOkrjono = ARY_NYUKN_KS(i).OKRJONO Then
				BlnFlg = True
				Exit For
			End If
		Next i
		
		If BlnFlg = False Then
			
			
			'���������g�����E����g�����D�������R�[�h���A�����z�̎c�z���擾����B
			
			strSql = " " & vbCrLf
			strSql = strSql & " SELECT UDN.SEQ  AS SEQ" & vbCrLf
			strSql = strSql & "      , UDN.NYUKN - NVL(NKS.JKESIKN,0) AS ZANKN" & vbCrLf
			strSql = strSql & "      , UDN.DKBID AS DKBID" & vbCrLf
			strSql = strSql & "      , UDN.UPDID AS UPDID" & vbCrLf
			strSql = strSql & "      , UDN.NYUKB AS NYUKB" & vbCrLf
			'*** 2009/10/09 ADD START FKS)NAKATA
			strSql = strSql & "      , UDN.UDNDT AS UDNDT" & vbCrLf
			'*** 2009/10/09 ADD E.N.D FKS)NAKATA
			strSql = strSql & " FROM" & vbCrLf
			strSql = strSql & "    (" & vbCrLf
			strSql = strSql & "         SELECT  SUM(JKESIKN) AS JKESIKN" & vbCrLf
			strSql = strSql & "             ,   DKBID AS DKBID" & vbCrLf
			strSql = strSql & "             ,   UPDID AS UPDID" & vbCrLf
			strSql = strSql & "           FROM   NKSTRA" & vbCrLf
			strSql = strSql & "          WHERE   DATKB     = '1'" & vbCrLf
			strSql = strSql & "            AND   AKAKROKB  = '1'" & vbCrLf
			strSql = strSql & "            AND   JDNNO     = '" & Trim(strJdnno) & "'" & vbCrLf
			strSql = strSql & "            AND   JDNLINNO  = '" & Trim(strJdnlinno) & "'" & vbCrLf
			strSql = strSql & "            AND KDNNO NOT IN" & vbCrLf
			strSql = strSql & "                (" & vbCrLf
			strSql = strSql & "                 SELECT  MOTKDNNO" & vbCrLf
			strSql = strSql & "                   FROM  NKSTRA" & vbCrLf
			strSql = strSql & "                  WHERE  JDNNO     = '" & Trim(strJdnno) & "'" & vbCrLf
			strSql = strSql & "                    AND  JDNLINNO  = '" & Trim(strJdnlinno) & "'" & vbCrLf
			strSql = strSql & "                    AND  TRIM(MOTKDNNO) IS NOT NULL" & vbCrLf
			strSql = strSql & "                 )" & vbCrLf
			strSql = strSql & "         GROUP BY DKBID , UPDID" & vbCrLf
			strSql = strSql & "    ) NKS" & vbCrLf
			strSql = strSql & "    ," & vbCrLf
			strSql = strSql & "    (" & vbCrLf
			strSql = strSql & "          SELECT  SUM(NYUKN) AS NYUKN" & vbCrLf
			strSql = strSql & "          ,   CASE    WHEN   DKBID = '01' THEN  '4'" & vbCrLf
			strSql = strSql & "                      WHEN   DKBID = '02' THEN  '5'" & vbCrLf
			strSql = strSql & "                      WHEN   DKBID = '03' THEN  '6'" & vbCrLf
			strSql = strSql & "                      WHEN   DKBID = '04' THEN  '1'" & vbCrLf
			strSql = strSql & "                      WHEN   DKBID = '05' THEN  '8'" & vbCrLf
			strSql = strSql & "                      WHEN   DKBID = '06' THEN  '3'" & vbCrLf
			strSql = strSql & "                      WHEN   DKBID = '07' THEN  '9'" & vbCrLf
			strSql = strSql & "                      WHEN   DKBID = '08' THEN  '7'" & vbCrLf
			strSql = strSql & "                      WHEN   DKBID = '09' THEN  '-1'" & vbCrLf
			strSql = strSql & "                      WHEN   DKBID = '99' THEN  '2'" & vbCrLf
			strSql = strSql & "              END AS SEQ" & vbCrLf
			strSql = strSql & "          ,   DKBID" & vbCrLf
			strSql = strSql & "          ,   UPDID" & vbCrLf
			strSql = strSql & "          ,   MAX(TEGDT) AS TEGDT" & vbCrLf
			strSql = strSql & "          ,   NYUKB" & vbCrLf
			'*** 2009/10/09 ADD START FKS)NAKATA
			strSql = strSql & "          ,   MAX(TRA.UDNDT) AS UDNDT" & vbCrLf
			'*** 2009/10/09 ADD E.N.D FKS)NAKATA
			strSql = strSql & "        FROM  UDNTRA TRA" & vbCrLf
			strSql = strSql & "             ,UDNTHA THA" & vbCrLf
			strSql = strSql & "       WHERE  TRA.DENKB    =   '8'" & vbCrLf
			strSql = strSql & "         AND  TRA.DATKB    =   '1'" & vbCrLf
			strSql = strSql & "         AND  TRA.AKAKROKB =   '1'" & vbCrLf
			strSql = strSql & "         AND  TRA.KESIKB   =   '9'" & vbCrLf
			strSql = strSql & "         AND  TRA.DKBID   !=  '09'" & vbCrLf
			strSql = strSql & "         AND  TRA.OKRJONO  =   '" & strOkrjono & "'" & vbCrLf
			strSql = strSql & "         AND  TRA.DATNO    =   THA.DATNO" & vbCrLf
			strSql = strSql & "         AND  THA.NYUCD    = '2'" & vbCrLf
			strSql = strSql & "         AND  THA.FRNKB    = '0'" & vbCrLf
			strSql = strSql & "         AND  TRA.DATNO IN" & vbCrLf
			strSql = strSql & "            ( SELECT MAX(DATNO)" & vbCrLf
			strSql = strSql & "                FROM  UDNTRA" & vbCrLf
			strSql = strSql & "               WHERE  DENKB    =  '8'" & vbCrLf
			strSql = strSql & "                 AND  DATKB    =  '1'" & vbCrLf
			strSql = strSql & "                 AND  DKBID   !=  '09'" & vbCrLf
			strSql = strSql & "                 AND  OKRJONO  =  '" & strOkrjono & "'" & vbCrLf
			strSql = strSql & "            )" & vbCrLf
			strSql = strSql & "       GROUP BY DKBID ,UPDID ,TEGDT ,NYUKB" & vbCrLf
			strSql = strSql & "       ORDER BY SEQ" & vbCrLf
			strSql = strSql & "    )UDN" & vbCrLf
			strSql = strSql & " WHERE  NKS.UPDID(+) = UDN.UPDID" & vbCrLf
			strSql = strSql & "   AND    NKS.DKBID(+) = UDN.DKBID" & vbCrLf
			strSql = strSql & " ORDER BY UDN.SEQ"
			
			
			'�ް��擾
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
			
			Do While CF_Ora_EOF(Usr_Ody) = False
				
				
				ReDim Preserve ARY_NYUKN_KS(ARY_NYUKN_KS_CNT)
				
				With ARY_NYUKN_KS(ARY_NYUKN_KS_CNT)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.SEQ = SSSVal(CF_Ora_GetDyn(Usr_Ody, "SEQ", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.ZANKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "ZANKN", ""))
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.DKBID = VB6.Format(CStr(CF_Ora_GetDyn(Usr_Ody, "DKBID", "")), "00")
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.UPDID = VB6.Format(CStr(CF_Ora_GetDyn(Usr_Ody, "UPDID", "")), "00")
					'**** 2009/09/16 ADD START FKS)NAKATA
					'�����敪
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.NYUKB = CF_Ora_GetDyn(Usr_Ody, "NYUKB", "")
					'**** 2009/09/16 ADD E.N.D FKS)NAKATA
					'**** 2009/10/09 ADD START FKS)NAKATA
					'�����(������)
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.UDNDT = CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")
					'**** 2009/10/09 ADD E.N.D FKS)NAKATA
					.OKRJONO = strOkrjono
					
				End With
				
				ARY_NYUKN_KS_CNT = ARY_NYUKN_KS_CNT + 1
				
				'UPGRADE_WARNING: �I�u�W�F�N�g Usr_Ody.Obj_Ody.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Usr_Ody.Obj_Ody.MoveNext()
				
			Loop 
			Call CF_Ora_CloseDyn(Usr_Ody) '�ް���ĸ۰��
			
		End If
		
		
END_UdntraNyukn: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Sub
		
ERR_UdntraNyukn: 
		Call SSSWIN_LOGWRT("getUdntraNyukn_ERROR")
		GoTo END_UdntraNyukn
		
	End Sub
	
	'2009/09/07 ADD START FKS)NAKATA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Util_GET_TANMTA_TANCLAKB
	'   �T�v�F  �c�ƒS���t���O���擾
	'   �����F�@pot_strTANCD       : �S���҃R�[�h
	'       �F�@pot_strKEIBMNCD    : �c�ƒS���t���O
	'   �ߒl�F�@0:����I�� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Util_GET_TANMTA_TANCLAKB(ByRef pot_strTANCD As String, ByRef pot_strTANCLAKB As String) As Short
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo ERR_F_Util_GET_TANMTA_TANCLAKB
		
		F_Util_GET_TANMTA_TANCLAKB = 9
		
		pot_strTANCLAKB = ""
		
		'�S���҂l
		strSql = ""
		strSql = strSql & " SELECT TANCLAKB "
		strSql = strSql & " FROM TANMTA "
		strSql = strSql & " WHERE TANCD = '" & pot_strTANCD & "' "
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pot_strTANCLAKB = CF_Ora_GetDyn(Usr_Ody, "TANCLAKB", "")
		Else
			GoTo END_F_Util_GET_TANMTA_TANCLAKB
		End If
		
		F_Util_GET_TANMTA_TANCLAKB = 0
		
END_F_Util_GET_TANMTA_TANCLAKB: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_F_Util_GET_TANMTA_TANCLAKB: 
		GoTo END_F_Util_GET_TANMTA_TANCLAKB
		
	End Function
	'2009/09/07 ADD E.N.D FKS)NAKATA
End Class