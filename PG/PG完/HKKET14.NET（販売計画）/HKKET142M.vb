Option Strict Off
Option Explicit On

'2019/04/10 ADD START
Imports PronesDbAccess
'2019/04/10 ADD E N D

'2019/04/02 ADD START
Imports Oracle.DataAccess.Client
'2019/04/02 ADD E N D

Module HKKET142M
	'//*****************************************************************************************
	'//* CHANGE HISTORY
	'//* Version  |YYYYMMDD|Programmer     |Description
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 2.00     |20080627|Rise)          |�ύX�@���͎w�������͂��ꂽ��A���Ɍv��(�A�g)���ڂ����b�N����B
	'//* 2.10     |20080627|Rise)          |�ύX�@�N���v��̎捞�������ɖ{�e�[�u��(HKKTRA)���X�V����B
	'//*          |        |               |      �܂��A�捞�������A�X�V�{�^���������͖������ɍX�V����B
	'//* 2.20     |20080701|Rise)          |�ύX�@�V���Y�Ή��i�D��t���O���ڂ̒ǉ��j
	'//* 2.30     |20081222|Rise)          |�̔��v���ʂł̓��̓��O���o�͂���
	'//*****************************************************************************************

    '2019/04/11 ADD START
    Private ClsMessage As New ClsMessage
    '2019/04/11 ADD E N D

	'//*****************************************************************************************
	'// �o�f�ʕϐ���`
	'//*****************************************************************************************
	Public gvlngNowPage As Integer '//���ݕ\���Ő�
	Public gvlngDefaultPage As Integer '//�����\���Ő�
	Public gvlngMAXPage As Integer '//�ő�\���Ő�
	Public gvlngMINPage As Integer '//�ŏ��\���Ő�
	Public gvstrNowItem As String '//���ݕ\�����i
	Public gvblnLMAHMS As Boolean '//�ύX�׸�
	Public gvblnLMZNOS As Boolean '//�ύX�׸�
	Public gvintNowItem As Short '//���ݕ\�����i
	Public gvstrCalcDate As String '//�ʎZ��
	Public gvstrCalcDate2 As String '//�v�Z���t
	Public gvstrCalcDate3 As String '//�v�Z���t
	'// 2006/10/27 �� ADD STR
	Public gvstrHINKB As String '//���ݕ\���̐��i�敪
	'// 2006/10/27 �� ADD END
	'// 2007/01/09 �� ADD STR
	Public gvlngSyukaYoteiHikaku As Integer '//�o�ח\���r����
	Public gvstrHINGRP As String '//���ݕ\�����̏��i�S
	'// 2007/01/09 �� ADD END
	
	Public Structure mtypHKKTRA '//�ޔ����
        '2019/04/10 CHG START
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim strLMAHKS() As String*10 '//�N���v��
        'Dim blnLMAHKS() As Boolean '//�N���v��(���͐���)
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim strLMAHKS_ORG() As String*10 '//�N���v��(����l)
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim strLMAHMS() As String*10 '//�����v��
        'Dim blnLMAHMS() As Boolean '//�����v��(���͐���)
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim strLMAHMS_ORG() As String*10 '//�����v��(����l)
        ''// 2006/11/13 �� ADD STR
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim strLMZPNO() As String*12 '//���Y�v��ԍ�
        ''// 2006/11/13 �� ADD END
        ''// 2007/01/09 �� ADD STR
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim strLMAPDT() As String*8 '//�v��N����
        'Dim intLTKBN() As Short '//LT���ԋ敪(2:���BLT/1:����LT/0:�ʏ�)
        '      '// 2007/01/09 �� ADD END
        Dim strLMAHKS() As String       '//�N���v��
        Dim blnLMAHKS() As Boolean      '//�N���v��(���͐���)
        Dim strLMAHKS_ORG() As String   '//�N���v��(����l)
        Dim strLMAHMS() As String       '//�����v��
        Dim blnLMAHMS() As Boolean      '//�����v��(���͐���)
        Dim strLMAHMS_ORG() As String   '//�����v��(����l)
        Dim strLMZPNO() As String       '//���Y�v��ԍ�
        Dim strLMAPDT() As String       '//�v��N����
        Dim intLTKBN() As Short         '//LT���ԋ敪(2:���BLT/1:����LT/0:�ʏ�)
         '2019/04/10 CHG E N D
	End Structure
	
	Public Structure mtypHKKZTRA '//�ޔ����
		Dim strDSPMONTH() As String '//�\���N��
		Dim dblLAST_JDNTR() As Double '//�O�N�󒍎���
		Dim dblLAST_ODNTRA() As Double '//�O�N�o�Ɏ���
		Dim dblLAST_HDNTRA() As Double '//�O�N��������
		Dim dblINPTRA() As Double '//���ɗ\��
		Dim dblOUTTRA() As Double '//�o�ɗ\��
		Dim dblSKYOUT() As Double '//�x���i�o��
		Dim dblLAST_STOCK() As Double '//�����݌�
		Dim strLMZLDT() As String '//�������E��
		Dim strLMZHDT() As String '//������
		Dim strLMZZKM() As String '//�݌ɐ؂�}�[�N
		Dim strLMZAZM() As String '//���S�݌ɐ؂�}�[�N
		Dim strLMZMZKM() As String '//�����݌ɐ؂�}�[�N
		Dim strLMZMAZM() As String '//�������S�݌ɐ؂�}�[�N
		Dim dblLMZZKT() As Double '//�݌Ɍ���
		Dim dblLMZMZKT() As Double '//�����݌Ɍ���
		Dim dblLMAVZS() As Double '//���Ϗo�ɐ�
		'// 2007/01/09 �� ADD STR
		Dim dblLAST_NDNTRA() As Double '//�O�N�o�Ɏ���
		Dim dblYOSLST() As Double '//�\�������݌�
		Dim dblMYOSLST() As Double '//�����\�������݌�
		'// 2007/01/09 �� ADD END
	End Structure
	
	Public Structure mtypMKMTRA '//�ޔ����
		Dim dblMKMAK() As Double '//�����Č�
		Dim dblMKMMT() As Double '//��������
		Dim dblMKMOUTTRA() As Double '//�����o�ɗ\��
		Dim dblMKMLST() As Double '//���������݌�
	End Structure
	
    Public Structure mtypODINTRA '//�ޔ����
        '2019/04/10 CHG START
        'Dim dblLMAODSSA() As Double '//�����ϐ�
        'Dim dblLMAKODSA() As Double '//�ً}������
        'Dim dblLMZNOSSA() As Double '//���Ɏw���ϐ�
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim strINPPLAN() As String*10 '//�i���́j���Ɍv�搔
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim strINPPLAN_ORG() As String*10 '//�i���́j���Ɍv�搔(�����l)
        'Dim dblDspINPPLAN() As Double '//�i�\���j���Ɍv�搔
        'Dim dblDspINPPLAN_ORG() As Double '//�i�\���j���Ɍv�搔(�����l)
        'Dim dblDspINPPLAN_ZEN() As Double '//�i�\���j���Ɍv�搔(���������l)
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim strLMZNOSS() As String*10 '//���Ɏw����
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim strLMZNOSS_ORG() As String*10 '//���Ɏw����(����l)
        ''// V2.20�� ADD
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim strLMZNPF() As String*4 '//�D��t���O
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim strLMZNPF_ORG() As String*4 '//�D��t���O(�ǂݍ��ݎ�)
        ''// V2.20�� ADD

        Dim dblLMAODSSA() As Double         '//�����ϐ�
        Dim dblLMAKODSA() As Double         '//�ً}������
        Dim dblLMZNOSSA() As Double         '//���Ɏw���ϐ�
        Dim strINPPLAN() As String          '//�i���́j���Ɍv�搔
        Dim strINPPLAN_ORG() As String      '//�i���́j���Ɍv�搔(�����l)
        Dim dblDspINPPLAN() As Double       '//�i�\���j���Ɍv�搔
        Dim dblDspINPPLAN_ORG() As Double   '//�i�\���j���Ɍv�搔(�����l)
        Dim dblDspINPPLAN_ZEN() As Double   '//�i�\���j���Ɍv�搔(���������l)
        Dim strLMZNOSS() As String          '//���Ɏw����
        Dim strLMZNOSS_ORG() As String      '//���Ɏw����(����l)
        Dim strLMZNPF() As String           '//�D��t���O
        Dim strLMZNPF_ORG() As String       '//�D��t���O(�ǂݍ��ݎ�)
        '2019/04/10 CHG E N D
    End Structure
	
	'UPGRADE_WARNING: �\���� musrHKKTRA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Public musrHKKTRA As mtypHKKTRA
	'UPGRADE_WARNING: �\���� musrHKKZTRA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Public musrHKKZTRA As mtypHKKZTRA
	'UPGRADE_WARNING: �\���� musrMKMTRA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Public musrMKMTRA As mtypMKMTRA
	'UPGRADE_WARNING: �\���� musrODINTRA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Public musrODINTRA As mtypODINTRA
	
	'// 2007/02/24 �� ADD STR
	Public Const gvcst_COLOR_MIDORIIRO As Integer = &H80FF80 '//�ΐF
	'// 2007/02/24 �� ADD END
	Public Const gvcst_COLOR_SIRO As Integer = &HFFFFFF '//���F
	Public Const gvcst_COLOR_HAIIRO As Integer = &H8000000F '//�D�F
	Public Const gvcst_COLOR_MIZURO As Integer = &HE2D4A4 '//���F
	Public Const gvcst_COLOR_MOMOIRO As Integer = &H8988EA '//���F
	Public Const gvcst_COLOR_AKAIRO As Integer = &HFF '//�ԐF
	Public Const gvcst_COLOR_KAKIIRO As Integer = &H3657E6 '//�`�F
	Public Const gvcst_COLOR_DAIDAIIRO As Short = &H6DE0s '//��F
	
	'// 2007/02/24 �� ADD STR
	Public strHKKTRA_DAY As String '//���t����
	Public strODINTRA_DAY As String '//���t����
	'// 2007/02/24 �� ADD END
	
	'// V2.10�� ADD
	Public intNensyoImportMode As Short '//�N���v��捞�����t���O(1:�捞���[�h 0:�ʏ����)
	'// V2.10�� ADD
	
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Ctr_PagePrevNext
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    �R�}���h�{�^���̑O�ŁE���ł̕\������
	'//*****************************************************************************************
	Public Function Ctr_PagePrevNext(ByVal pmsMode As String) As Boolean
		
		Const PROCEDURE As String = "Ctr_PagePrevNext"
		
		Dim lngNowPage As Integer
		
		Ctr_PagePrevNext = False
		
		On Error GoTo ONERR_STEP
		
		
		'//�ŃJ�E���g�̉��Z�E���Y
		Select Case pmsMode
			Case "P"
				If gvlngNowPage <= 0 Then
					'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "215")
					GoTo EXIT_STEP
				End If
				gvlngNowPage = gvlngNowPage - 1
			Case "N"
				If gvlngNowPage + 1 > 23 Then
					'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "214")
					GoTo EXIT_STEP
				End If
				gvlngNowPage = gvlngNowPage + 1
		End Select
		
		HKKET142F.txtTERM_PRE.Visible = False
		HKKET142F.txtTERM.Visible = False
		HKKET142F.txtTERM_NEXT.Visible = False
		If gvlngNowPage >= -1 And gvlngNowPage <= 11 Then
			HKKET142F.txtTERM_PRE.Left = VB6.TwipsToPixelsX(1680)
			HKKET142F.txtTERM_PRE.Width = VB6.TwipsToPixelsX((840 * ((13 - gvlngNowPage) - 1)) - 105)
			
			HKKET142F.txtTERM.Left = VB6.TwipsToPixelsX((840 * (14 - gvlngNowPage)))
			HKKET142F.txtTERM.Width = VB6.TwipsToPixelsX((840 * ((12 + gvlngNowPage) - 11)) - 105)
			
			HKKET142F.txtTERM_PRE.Visible = True
			HKKET142F.txtTERM.Visible = True
			HKKET142F.txtTERM_NEXT.Visible = False
		End If
		
		If gvlngNowPage >= 12 And gvlngNowPage <= 23 Then
			HKKET142F.txtTERM.Left = VB6.TwipsToPixelsX(1680)
			HKKET142F.txtTERM.Width = VB6.TwipsToPixelsX((840 * ((13 - gvlngNowPage) + 11)) - 105)
			
			HKKET142F.txtTERM_NEXT.Left = VB6.TwipsToPixelsX((840 * ((13 - gvlngNowPage) + 13)))
			HKKET142F.txtTERM_NEXT.Width = VB6.TwipsToPixelsX((840 * (gvlngNowPage - 11)) - 105)
			
			HKKET142F.txtTERM.Visible = True
			HKKET142F.txtTERM_NEXT.Visible = True
			HKKET142F.txtTERM_PRE.Visible = False
		End If
		
		'//��ʕ\���ɕK�v�ȃf�[�^���擾���\������
		If Not Set_DisplayData(gvlngNowPage) Then
			GoTo EXIT_STEP
		End If
		
		Ctr_PagePrevNext = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Set_Initialize
	'//*
	'//* <�߂�l>
	'//*
	'//* <��  ��>     ���ږ�                  I/O           ���e
	'//*
	'//* <��  ��>
	'//*    ��������
	'//*****************************************************************************************
	Function Set_Initialize() As Boolean
		
		Const PROCEDURE As String = "Set_Initialize"
		Dim i As Short
		
		Set_Initialize = False
		
		On Error GoTo ONERR_STEP
		
		'// �e�n�q�l�L���v�V�����Z�b�g
		'HKKET142F.Caption = gvcstJOB_Titl
		
		'//�e�n�q�l�����Z�b�g
		Call SetFormInitOrg(HKKET142F, 1)
		
		'// ��ʃN���A�[
		Call Clr_Display()
		
		gvstrNowItem = musrHKKZTR.strHINCD(gvintNowItem)
		HKKET142F.txtNOWPAGE.Text = CStr(gvintNowItem)
		HKKET142F.txtMAXPAGE.Text = CStr(UBound(musrHKKZTR.strHINCD))
		HKKET142F.txtHINCD.Text = gvstrNowItem
		
		HKKET142F.txtHINCD.Text = gvstrNowItem
		
		HKKET142F.txtHINCD2.Text = HKKET141F.txtHINCD.Text
		HKKET142F.txtHINGRP2(0).Text = HKKET141F.txtHINGRP(0).Text
		HKKET142F.txtHINGRP2(1).Text = HKKET141F.txtHINGRP(1).Text
		HKKET142F.txtHINGRP2(2).Text = HKKET141F.txtHINGRP(2).Text
		HKKET142F.txtHINGRP2(3).Text = HKKET141F.txtHINGRP(3).Text
		HKKET142F.txtHINGRP2(4).Text = HKKET141F.txtHINGRP(4).Text
		HKKET142F.txtHINGRP2(5).Text = HKKET141F.txtHINGRP(5).Text
		
		HKKET142F.txtHINNMA2.Text = HKKET141F.txtHINNMA.Text
		
		HKKET142F.txtZAIRNK2(0).Text = HKKET141F.txtZAIRNK(0).Text
		HKKET142F.txtZAIRNK2(1).Text = HKKET141F.txtZAIRNK(1).Text
		HKKET142F.txtZAIRNK2(2).Text = HKKET141F.txtZAIRNK(2).Text
		HKKET142F.txtZAIRNK2(3).Text = HKKET141F.txtZAIRNK(3).Text
		HKKET142F.txtZAIRNK2(4).Text = HKKET141F.txtZAIRNK(4).Text
		HKKET142F.txtZAIRNK2(5).Text = HKKET141F.txtZAIRNK(5).Text
		HKKET142F.txtZAIRNK2(6).Text = HKKET141F.txtZAIRNK(6).Text
		HKKET142F.txtZAIRNK2(7).Text = HKKET141F.txtZAIRNK(7).Text
		
		HKKET142F.txtTODAY.Text = VB6.Format(gvstrUNYDT, "@@@@/@@/@@")
		HKKET142F.txtTERM.Text = gvstrTERMNO & "��"
		HKKET142F.txtTERM_PRE.Text = CDbl(gvstrTERMNO) - 1 & "��"
		HKKET142F.txtTERM_NEXT.Text = CDbl(gvstrTERMNO) + 1 & "��"
		
		
		
		HKKET142F.txtTERM.Left = VB6.TwipsToPixelsX(1680)
		HKKET142F.txtTERM.Width = VB6.TwipsToPixelsX((840 * ((13 - gvlngDefaultPage + 1) + 10)) - 105)
		
		HKKET142F.txtTERM_NEXT.Left = VB6.TwipsToPixelsX((840 * ((13 - gvlngDefaultPage + 1) + 12)))
		HKKET142F.txtTERM_NEXT.Width = VB6.TwipsToPixelsX((840 * (gvlngDefaultPage - 11)) - 105)
		
		HKKET142F.txtTERM.Visible = True
		HKKET142F.txtTERM_PRE.Visible = False
		HKKET142F.txtTERM_NEXT.Visible = True
		
		HKKET142F.txtWARNING.Text = IIf(HKKET141F.optCARRIES_ON.Checked, "����", "���Ȃ�")
		If HKKET141F.optCARRIES_ON.Checked Then
			Select Case True
				Case HKKET141F.optSAFTY_STOCK.Checked
					HKKET142F.txtSTOCKNM.Text = HKKET141F.optSAFTY_STOCK.Text
					HKKET142F.txtSTOCK.Text = HKKET141F.txtSAFTY_STOCK.Text
				Case HKKET141F.optSTOCK.Checked
					HKKET142F.txtSTOCKNM.Text = HKKET141F.optSTOCK.Text
					HKKET142F.txtSTOCK.Text = HKKET141F.txtSTOCK.Text
				Case HKKET141F.optSTOCK_MONTH.Checked
					HKKET142F.txtSTOCKNM.Text = HKKET141F.optSTOCK_MONTH.Text
					HKKET142F.txtSTOCK.Text = HKKET141F.txtSTOCK_MONTH.Text
				Case HKKET141F.optORDER_OMISSION.Checked
					HKKET142F.txtSTOCKNM.Text = HKKET141F.optORDER_OMISSION.Text
					HKKET142F.txtSTOCK.Text = HKKET141F.txtORDER_OMISSION.Text
			End Select
		End If
		HKKET142F.txtJDMKM.Text = IIf(HKKET141F.optORDER_ON.Checked, "�܂�", "�܂܂Ȃ�")
		HKKET142F.txtGROUP.Text = IIf(HKKET141F.optONLY.Checked, "��", "�ް�ޮݏW�v")
		
		ReDim musrHKKTRA.strLMAHKS(0)
		ReDim musrHKKTRA.blnLMAHKS(0)
		ReDim musrHKKTRA.strLMAHKS_ORG(0)
		ReDim musrHKKTRA.strLMAHMS(0)
		ReDim musrHKKTRA.blnLMAHMS(0)
		ReDim musrHKKTRA.strLMAHMS_ORG(0)
		
		ReDim musrHKKZTRA.strDSPMONTH(0)
		ReDim musrHKKZTRA.dblLAST_JDNTR(0)
		ReDim musrHKKZTRA.dblLAST_ODNTRA(0)
		ReDim musrHKKZTRA.dblLAST_HDNTRA(0)
		'// 2007/01/09 �� ADD STR
		ReDim musrHKKZTRA.dblLAST_NDNTRA(0)
		'// 2007/01/09 �� ADD END
		ReDim musrHKKZTRA.dblINPTRA(0)
		ReDim musrHKKZTRA.dblOUTTRA(0)
		ReDim musrHKKZTRA.dblSKYOUT(0)
		ReDim musrHKKZTRA.dblLAST_STOCK(0)
		ReDim musrHKKZTRA.strLMZLDT(0)
		ReDim musrHKKZTRA.strLMZHDT(0)
		ReDim musrHKKZTRA.strLMZZKM(0)
		ReDim musrHKKZTRA.strLMZAZM(0)
		ReDim musrHKKZTRA.strLMZMZKM(0)
		ReDim musrHKKZTRA.strLMZMAZM(0)
		ReDim musrHKKZTRA.dblLMZZKT(0)
		ReDim musrHKKZTRA.dblLMZMZKT(0)
		ReDim musrHKKZTRA.dblLMAVZS(0)
		'// 2007/01/09 �� ADD STR
		ReDim musrHKKZTRA.dblYOSLST(0)
		ReDim musrHKKZTRA.dblMYOSLST(0)
		'// 2007/01/09 �� ADD END
		
		ReDim musrMKMTRA.dblMKMAK(0)
		ReDim musrMKMTRA.dblMKMAK(0)
		ReDim musrMKMTRA.dblMKMMT(0)
		ReDim musrMKMTRA.dblMKMOUTTRA(0)
		ReDim musrMKMTRA.dblMKMLST(0)
		
		ReDim musrODINTRA.dblLMAODSSA(0)
		ReDim musrODINTRA.dblLMAKODSA(0)
		ReDim musrODINTRA.dblLMZNOSSA(0)
		ReDim musrODINTRA.strINPPLAN(0)
		ReDim musrODINTRA.strINPPLAN_ORG(0)
		ReDim musrODINTRA.dblDspINPPLAN(0)
		ReDim musrODINTRA.dblDspINPPLAN_ORG(0)
		ReDim musrODINTRA.dblDspINPPLAN_ZEN(0)
		ReDim musrODINTRA.strLMZNOSS(0)
		ReDim musrODINTRA.strLMZNOSS_ORG(0)
		'// V2.20�� ADD
		ReDim musrODINTRA.strLMZNPF(0)
		ReDim musrODINTRA.strLMZNPF_ORG(0)
		'// V2.20�� ADD
		
		'//��ʕ\���ɕK�v�ȃf�[�^���擾���\������
		If Not Get_DisplayData Then
			GoTo EXIT_STEP
		End If
		
		If Not Set_DisplayData(gvlngDefaultPage) Then
			GoTo EXIT_STEP
		End If
		
		Set_Initialize = True
		
		'--------------------------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'--------------------------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Clr_Display
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*            pm_lng_ProcCLS      Long             I      0:��ʑS��, 1:�w�b�_��, 2:���ו�
	'//*
	'//* <��  ��>
	'//*    ��ʃN���A����
	'//*****************************************************************************************
	Sub Clr_Display()
		
		Const PROCEDURE As String = "Clr_Display"
		
		Dim i As Short
		
		On Error GoTo ONERR_STEP
		
		'UPGRADE_WARNING: Controls ���\�b�h Controls.Count �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		For i = 0 To HKKET142F.Controls.Count() - 1
			'UPGRADE_WARNING: TypeName �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			Select Case TypeName(CType(HKKET142F.Controls(i), Object))
				'//�I�u�W�F�N�g���Ώ�
				Case "TextBox" '//÷���ޯ��
					CType(HKKET142F.Controls(i), Object).Text = vbNullString
				Case Else
			End Select
		Next i
		
		For i = 0 To HKKET142F.cmdMONTH.UBound
			HKKET142F.cmdMONTH(i).Text = vbNullString
		Next i
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Sub
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Sub
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Get_DisplayData
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*
	'//*****************************************************************************************
	Public Function Get_DisplayData() As Boolean
		
		Const PROCEDURE As String = "Get_DisplayData"
		
		'UPGRADE_ISSUE: ListItem �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/04/11 DEL START
        'Dim objLitem As ListItem
        '2019/04/11 DEL E N D

		Get_DisplayData = False
		
		If Not HKKET142M.Get_HKKTRA Then '//�̔��v��e�擾
			GoTo EXIT_STEP
		End If
		
		If Not HKKET142M.Get_HINMTA Then '//���i�}�X�^�擾
			GoTo EXIT_STEP
		End If
		
		'// 2007/01/09 �� ADD STR
		If Not HKKET142M.Get_FIXMTA Then '//�Œ�l�}�X�^�擾
			GoTo EXIT_STEP
		End If
		'// 2007/01/09 �� ADD END
		
		If Not HKKET142M.Get_HKKZTRA Then '//�̔��v��O���e�擾
			GoTo EXIT_STEP
		End If
		
		
		If Not HKKET142M.Get_HKKZTRA_M Then '//�̔��v��O���e�擾
			GoTo EXIT_STEP
		End If
		
		'// 2007/01/09 �� ADD STR
		If Not HKKET142M.Get_LTKIKAN Then '//LT���ԋ敪�̎擾
			GoTo EXIT_STEP
		End If
		'// 2007/01/09 �� ADD END
		
		On Error GoTo ONERR_STEP
		
		Get_DisplayData = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Set_DisplayData
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*            pm_gvlngNowPage     Long             I      ���݂̕�
	'//*
	'//* <��  ��>
	'//*
	'//*****************************************************************************************
	Public Function Set_DisplayData(ByRef pm_gvlngNowPage As Integer) As Boolean
		
		
		Const PROCEDURE As String = "Set_DisplayData"
		
		Dim i As Short
		Dim j As Short
		Dim strDate As String
		
		Set_DisplayData = False
		
		On Error GoTo ONERR_STEP
		
		i = pm_gvlngNowPage
		j = 0
		''//�O�N�󒍎���
		HKKET142F.txtLAST_JDNTR.Text = vbNullString
		''//�O�N�o�Ɏ���
		HKKET142F.txtLAST_ODNTRA.Text = vbNullString
		''//�O�N��������
		HKKET142F.txtLAST_HDNTRA.Text = vbNullString
		''//���ɗ\��
		HKKET142F.txtINPTRA.Text = vbNullString
		''//�o�ɗ\��
		HKKET142F.txtOUTTRA.Text = vbNullString
		''//�x���i�o��
		HKKET142F.txtSKYOUT.Text = vbNullString
		''//�����Č�
		HKKET142F.txtMKMAK.Text = vbNullString
		''//��������
		HKKET142F.txtMKMMT.Text = vbNullString
		''//�����o�ɗ\��
		HKKET142F.txtMKMOUTTRA.Text = vbNullString
		'// 2007/01/09 �� ADD STR
		''//�\�������݌�
		HKKET142F.txtYOSLST.Text = vbNullString
		'// 2007/01/09 �� ADD END
		''//�����όv
		HKKET142F.txtLMAODSSA.Text = vbNullString
		''//�ً}�����όv
		HKKET142F.txtLMAKODSA.Text = vbNullString
		''//���Ɏw���ϐ�
		HKKET142F.txtLMZNOSSA.Text = vbNullString
		''//���Ɍv�搔
		HKKET142F.txtDspINPPLAN.Text = vbNullString
		
		Do 
			'//�\����
			If musrHKKZTRA.strDSPMONTH(i) <> "" Then
				If CInt(Right(musrHKKZTRA.strDSPMONTH(i), 2)) > 9 Then
					HKKET142F.cmdMONTH(j).Text = Right(musrHKKZTRA.strDSPMONTH(i), 2) & "��"
				Else
					HKKET142F.cmdMONTH(j).Text = StrConv(Right(musrHKKZTRA.strDSPMONTH(i), 1), VbStrConv.Wide) & "��"
				End If
			Else
				HKKET142F.cmdMONTH(j).Text = ""
			End If
			HKKET142F.cmdMONTH(j).Tag = musrHKKZTRA.strDSPMONTH(i)
			
			'// 2007/02/24 �� ADD STR
			''//�\�����̃{�^���\�ʂ̐F�������o�ɗ\�肪�����Ă����Ƃ��͗΂ɂ���
			If musrMKMTRA.dblMKMOUTTRA(i) <> 0 Then
				HKKET142F.cmdMONTH(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_MIDORIIRO) ' �ΐF
			Else
				HKKET142F.cmdMONTH(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO) ' �D�F
			End If
			'// 2007/02/24 �� ADD END
			
			'//�N���v��
			If Trim(musrHKKTRA.strLMAHKS(i)) = "" Then
				HKKET142F.txtLMAHKS(j).Text = ""
			Else
				HKKET142F.txtLMAHKS(j).Text = VB6.Format(Trim(musrHKKTRA.strLMAHKS(i)), "####0")
			End If
			'//�����v��
			If Trim(musrHKKTRA.strLMAHMS(i)) = "" Then
				HKKET142F.txtLMAHMS(j).Text = ""
			Else
				HKKET142F.txtLMAHMS(j).Text = VB6.Format(Trim(musrHKKTRA.strLMAHMS(i)), "####0")
			End If
			
			'// 2007/02/03 �� ADD STR
			''//���Ɍv�搔
			'        If Trim(musrODINTRA.strINPPLAN(i)) = "" Then
			'            HKKET142F.txtINPPLAN(j).Text = ""
			'        Else
			HKKET142F.txtINPPLAN(j).Text = VB6.Format(Val(Trim(musrODINTRA.strINPPLAN(i))), "####0")
			'        End If
			'// 2007/02/03 �� ADD END
			'// V2.20�� ADD
			If HKKET141F.optVERSION.Checked = True Then
				HKKET142F.txtLMZNPF(j).Text = "-"
			Else
				HKKET142F.txtLMZNPF(j).Text = musrODINTRA.strLMZNPF(i)
			End If
			'// V2.20�� ADD
			
			If HKKET142F.cmdMONTH(j).Text <> "" Then
				''//�O�N�󒍎���
				HKKET142F.txtLAST_JDNTR.Text = HKKET142F.txtLAST_JDNTR.Text & Right("      " & VB6.Format(musrHKKZTRA.dblLAST_JDNTR(i), "####0"), 6) & "  "
				''//�O�N�o�Ɏ���
				HKKET142F.txtLAST_ODNTRA.Text = HKKET142F.txtLAST_ODNTRA.Text & Right("      " & VB6.Format(musrHKKZTRA.dblLAST_ODNTRA(i), "####0"), 6) & "  "
				''//�O�N��������
				HKKET142F.txtLAST_HDNTRA.Text = HKKET142F.txtLAST_HDNTRA.Text & Right("      " & VB6.Format(musrHKKZTRA.dblLAST_HDNTRA(i), "####0"), 6) & "  "
				''//���ɗ\��
				HKKET142F.txtINPTRA.Text = HKKET142F.txtINPTRA.Text & Right("      " & VB6.Format(musrHKKZTRA.dblINPTRA(i), "####0"), 6) & "  "
				''//�o�ɗ\��
				HKKET142F.txtOUTTRA.Text = HKKET142F.txtOUTTRA.Text & Right("      " & VB6.Format(musrHKKZTRA.dblOUTTRA(i), "####0"), 6) & "  "
				''//�x���i�o��
				HKKET142F.txtSKYOUT.Text = HKKET142F.txtSKYOUT.Text & Right("      " & VB6.Format(musrHKKZTRA.dblSKYOUT(i), "####0"), 6) & "  "
				''//�����݌�
				HKKET142F.txtLAST_STOCK(j).Text = CStr(musrHKKZTRA.dblLAST_STOCK(i))
				''//�����Č�
				HKKET142F.txtMKMAK.Text = HKKET142F.txtMKMAK.Text & Right("      " & VB6.Format(musrMKMTRA.dblMKMAK(i), "####0"), 6) & "  "
				''//��������
				HKKET142F.txtMKMMT.Text = HKKET142F.txtMKMMT.Text & Right("      " & VB6.Format(musrMKMTRA.dblMKMMT(i), "####0"), 6) & "  "
				''//�����o�ɗ\��
				HKKET142F.txtMKMOUTTRA.Text = HKKET142F.txtMKMOUTTRA.Text & Right("      " & VB6.Format(musrMKMTRA.dblMKMOUTTRA(i), "####0"), 6) & "  "
				''//���������݌�
				HKKET142F.txtMKMLST(j).Text = CStr(musrMKMTRA.dblMKMLST(i))
				'// 2007/01/09 �� ADD STR
				''//�\�������݌�
				If HKKET141F.optORDER_ON.Checked Then
					HKKET142F.txtYOSLST.Text = HKKET142F.txtYOSLST.Text & Right("      " & VB6.Format(musrHKKZTRA.dblMYOSLST(i), "####0"), 6) & "  "
				Else
					HKKET142F.txtYOSLST.Text = HKKET142F.txtYOSLST.Text & Right("      " & VB6.Format(musrHKKZTRA.dblYOSLST(i), "####0"), 6) & "  "
				End If
				'// 2007/01/09 �� ADD END
				''//�����όv
				HKKET142F.txtLMAODSSA.Text = HKKET142F.txtLMAODSSA.Text & Right("      " & VB6.Format(musrODINTRA.dblLMAODSSA(i), "####0"), 6) & "  "
				''//�ً}�����όv
				HKKET142F.txtLMAKODSA.Text = HKKET142F.txtLMAKODSA.Text & Right("      " & VB6.Format(musrODINTRA.dblLMAKODSA(i), "####0"), 6) & "  "
				''//���Ɏw���ϐ�
				HKKET142F.txtLMZNOSSA.Text = HKKET142F.txtLMZNOSSA.Text & Right("      " & VB6.Format(musrODINTRA.dblLMZNOSSA(i), "####0"), 6) & "  "
				''//���Ɍv�搔
				HKKET142F.txtDspINPPLAN.Text = HKKET142F.txtDspINPPLAN.Text & Right("      " & VB6.Format(musrODINTRA.dblDspINPPLAN(i), "####0"), 6) & "  "
				''//���Ɏw����
				HKKET142F.txtLMZNOSS(j).Text = Trim(musrODINTRA.strLMZNOSS(i))
			Else
				''//�O�N�󒍎���
				HKKET142F.txtLAST_JDNTR.Text = HKKET142F.txtLAST_JDNTR.Text & Right("      " & VB6.Format(musrHKKZTRA.dblLAST_JDNTR(i), "#####"), 6) & "  "
				''//�O�N�o�Ɏ���
				HKKET142F.txtLAST_ODNTRA.Text = HKKET142F.txtLAST_ODNTRA.Text & Right("      " & VB6.Format(musrHKKZTRA.dblLAST_ODNTRA(i), "#####"), 6) & "  "
				''//�O�N��������
				HKKET142F.txtLAST_HDNTRA.Text = HKKET142F.txtLAST_HDNTRA.Text & Right("      " & VB6.Format(musrHKKZTRA.dblLAST_HDNTRA(i), "#####"), 6) & "  "
				''//���ɗ\��
				HKKET142F.txtINPTRA.Text = HKKET142F.txtINPTRA.Text & Right("      " & VB6.Format(musrHKKZTRA.dblINPTRA(i), "#####"), 6) & "  "
				''//�o�ɗ\��
				HKKET142F.txtOUTTRA.Text = HKKET142F.txtOUTTRA.Text & Right("      " & VB6.Format(musrHKKZTRA.dblOUTTRA(i), "#####"), 6) & "  "
				''//�x���i�o��
				HKKET142F.txtSKYOUT.Text = HKKET142F.txtSKYOUT.Text & Right("      " & VB6.Format(musrHKKZTRA.dblSKYOUT(i), "#####"), 6) & "  "
				''//�����݌�
				HKKET142F.txtLAST_STOCK(j).Text = ""
				''//�����Č�
				HKKET142F.txtMKMAK.Text = HKKET142F.txtMKMAK.Text & Right("      " & VB6.Format(musrMKMTRA.dblMKMAK(i), "#####"), 6) & "  "
				''//��������
				HKKET142F.txtMKMMT.Text = HKKET142F.txtMKMMT.Text & Right("      " & VB6.Format(musrMKMTRA.dblMKMMT(i), "#####"), 6) & "  "
				''//�����o�ɗ\��
				HKKET142F.txtMKMOUTTRA.Text = HKKET142F.txtMKMOUTTRA.Text & Right("      " & VB6.Format(musrMKMTRA.dblMKMOUTTRA(i), "#####"), 6) & "  "
				''//���������݌�
				HKKET142F.txtMKMLST(j).Text = ""
				'// 2007/01/09 �� ADD STR
				''//�\�������݌�
				If HKKET141F.optORDER_ON.Checked Then
					HKKET142F.txtYOSLST.Text = HKKET142F.txtYOSLST.Text & Right("      " & VB6.Format(musrHKKZTRA.dblMYOSLST(i), "#####"), 6) & "  "
				Else
					HKKET142F.txtYOSLST.Text = HKKET142F.txtYOSLST.Text & Right("      " & VB6.Format(musrHKKZTRA.dblYOSLST(i), "#####"), 6) & "  "
				End If
				'// 2007/01/09 �� ADD END
				''//�����όv
				HKKET142F.txtLMAODSSA.Text = HKKET142F.txtLMAODSSA.Text & Right("      " & VB6.Format(musrODINTRA.dblLMAODSSA(i), "#####"), 6) & "  "
				''//�ً}�����όv
				HKKET142F.txtLMAKODSA.Text = HKKET142F.txtLMAKODSA.Text & Right("      " & VB6.Format(musrODINTRA.dblLMAKODSA(i), "#####"), 6) & "  "
				''//���Ɏw���ϐ�
				HKKET142F.txtLMZNOSSA.Text = HKKET142F.txtLMZNOSSA.Text & Right("      " & VB6.Format(musrODINTRA.dblLMZNOSSA(i), "#####"), 6) & "  "
				''//���Ɍv�搔
				HKKET142F.txtDspINPPLAN.Text = HKKET142F.txtDspINPPLAN.Text & Right("      " & VB6.Format(musrODINTRA.dblDspINPPLAN(i), "#####"), 6) & "  "
				''//���Ɏw����
				HKKET142F.txtLMZNOSS(j).Text = ""
			End If
			
			HKKET142F.txtMKMLST(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_SIRO)
			HKKET142F.txtLAST_STOCK(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_SIRO)
			HKKET142F.txtLMZNOSS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_SIRO)
			
			'//�����݌�
			If musrHKKZTRA.strLMZAZM(i) = "0" And musrHKKZTRA.strLMZZKM(i) = "0" Then
				HKKET142F.txtLAST_STOCK(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_MIZURO)
			ElseIf musrHKKZTRA.strLMZZKM(i) = "1" Then 
				HKKET142F.txtLAST_STOCK(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_AKAIRO)
			ElseIf musrHKKZTRA.strLMZAZM(i) = "1" Then 
				HKKET142F.txtLAST_STOCK(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_MOMOIRO)
			End If
			
			If HKKET141F.optCARRIES_ON.Checked And HKKET141F.optSTOCK_MONTH.Checked Then
				If musrHKKZTRA.dblLMZZKT(i) >= CDbl(HKKET141F.txtSTOCK_MONTH.Text) Then
					HKKET142F.txtLAST_STOCK(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_KAKIIRO)
				End If
			End If
			'//���������݌�
			If musrHKKZTRA.strLMZMAZM(i) = "0" And musrHKKZTRA.strLMZMZKM(i) = "0" Then
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_MIZURO)
			ElseIf musrHKKZTRA.strLMZMZKM(i) = "1" Then 
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_AKAIRO)
			ElseIf musrHKKZTRA.strLMZMAZM(i) = "1" Then 
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_MOMOIRO)
			End If
			
			If HKKET141F.optCARRIES_ON.Checked And HKKET141F.optSTOCK_MONTH.Checked Then
				If musrHKKZTRA.dblLMZMZKT(i) >= CDbl(HKKET141F.txtSTOCK_MONTH.Text) Then
					HKKET142F.txtMKMLST(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_KAKIIRO)
				End If
			End If
			
			'//������
			'        If Trim(musrHKKZTRA.strLMZHDT(i)) <> "" Then                         2007/08/16 DEL
			'            HKKET142F.txtLMZNOSS(j).BackColor = gvcst_COLOR_AKAIRO           2007/08/16 DEL
			'        End If                                                               2007/08/16 DEL
			
			If HKKET142F.cmdMONTH(j).Text = "" Then
				HKKET142F.cmdMONTH(j).Enabled = False
				HKKET142F.txtLMAHKS(j).ReadOnly = True
				HKKET142F.txtLMAHMS(j).ReadOnly = True
				HKKET142F.txtLMZNOSS(j).ReadOnly = True
				HKKET142F.txtINPPLAN(j).ReadOnly = True
				'// V2.20�� ADD
				HKKET142F.txtLMZNPF(j).ReadOnly = True
				'// V2.20�� ADD
			Else
				HKKET142F.cmdMONTH(j).Enabled = True
				HKKET142F.txtLMAHKS(j).ReadOnly = False
				HKKET142F.txtLMAHMS(j).ReadOnly = False
				HKKET142F.txtLMZNOSS(j).ReadOnly = False
				HKKET142F.txtINPPLAN(j).ReadOnly = False
				'// V2.20�� ADD
				HKKET142F.txtLMZNPF(j).ReadOnly = False
				'// V2.20�� ADD
			End If
			
			If Not HKKET141F.optVERSION.Checked Or gvblnInputFlg Then
				If HKKET142F.cmdMONTH(j).Tag >= Mid(gvstrUNYDT, 1, 6) Then
					'//��������/�N���v�搔
					gvstrCalcDate = CStr(CDbl(Get_CLDMTA(1)) + ((CDbl(HKKET142F.txtPRCCD.Text) + CDbl(HKKET142F.txtMNFDD.Text)) * 5))
					gvstrCalcDate2 = VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, CDate(Get_CLDMTA(2))), "yyyymmdd")
					If HKKET142F.cmdMONTH(j).Tag < Mid(gvstrCalcDate2, 1, 6) Then
						HKKET142F.txtLMAHKS(j).ReadOnly = True
						'// 2006/11/17 �� DEL STR ���������͉^�p���t�ȍ~�͓��͉\�Ƃ���B
						'                   HKKET142F.txtLMAHMS(j).Locked = True
						'// 2006/11/17 �� DEL END
					Else
						HKKET142F.txtLMAHKS(j).ReadOnly = False
						HKKET142F.txtLMAHMS(j).ReadOnly = False
						HKKET142F.txtINPPLAN(j).ReadOnly = False
						'// V2.20�� ADD
						HKKET142F.txtLMZNPF(j).ReadOnly = False
						'// V2.20�� ADD
					End If
					'//���Ɏw����
					gvstrCalcDate = CStr(CDbl(Get_CLDMTA(1)) + (CDbl(HKKET142F.txtMNFDD.Text) * 5))
					gvstrCalcDate3 = VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, CDate(Get_CLDMTA(2))), "yyyymmdd")
					If HKKET142F.cmdMONTH(j).Tag < Mid(gvstrCalcDate3, 1, 6) Then
						HKKET142F.txtLMZNOSS(j).ReadOnly = True
					End If
					'//////////////////////////////////////////////////////////////////////////////////
					'//               If Trim(musrODINTRA.strLMZNOSS(j)) <> "" Then   '// @TT
					'//                   HKKET142F.txtLMZNOSS(j).Locked = True
					'//               End If
					'//////////////////////////////////////////////////////////////////////////////////
				Else
					HKKET142F.txtLMAHKS(j).ReadOnly = True
					HKKET142F.txtLMAHMS(j).ReadOnly = True
					HKKET142F.txtLMZNOSS(j).ReadOnly = True
					HKKET142F.txtINPPLAN(j).ReadOnly = True
					'// V2.20�� ADD
					HKKET142F.txtLMZNPF(j).ReadOnly = True
					'// V2.20�� ADD
				End If
				HKKET142F.cmdCALC.Enabled = True
				HKKET142F.cmdUPD.Enabled = True
			Else
				HKKET142F.txtLMAHKS(j).ReadOnly = True
				HKKET142F.txtLMAHMS(j).ReadOnly = True
				HKKET142F.txtLAST_STOCK(j).ReadOnly = True
				HKKET142F.txtMKMLST(j).ReadOnly = True
				HKKET142F.txtLMZNOSS(j).ReadOnly = True
				HKKET142F.cmdCALC.Enabled = False
				HKKET142F.txtINPPLAN(j).ReadOnly = True
				'// V2.20�� ADD
				HKKET142F.txtLMZNPF(j).ReadOnly = True
				'// V2.20�� ADD
				'HKKET142F.cmdUPD.Enabled = False
			End If
			
			If Trim(musrHKKTRA.strLMAHMS_ORG(i)) <> "" Then
				HKKET142F.txtLMAHKS(j).ReadOnly = True
			End If
			
			If HKKET142F.txtLMAHKS(j).ReadOnly Then
				HKKET142F.txtLMAHKS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
			Else
				HKKET142F.txtLMAHKS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_SIRO)
			End If
			
			If HKKET142F.txtLMAHMS(j).ReadOnly Then
				HKKET142F.txtLMAHMS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
			Else
				HKKET142F.txtLMAHMS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_SIRO)
			End If
			
			If HKKET142F.txtINPPLAN(j).ReadOnly Then
				HKKET142F.txtINPPLAN(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
			Else
				HKKET142F.txtINPPLAN(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_SIRO)
			End If
			
			'// V2.20�� ADD
			If HKKET142F.txtLMZNPF(j).ReadOnly Then
				HKKET142F.txtLMZNPF(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
			Else
				HKKET142F.txtLMZNPF(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_SIRO)
			End If
			'// V2.20�� ADD
			
			If HKKET142F.txtLMZNOSS(j).ReadOnly Then
				HKKET142F.txtLMZNOSS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
			Else
				If System.Drawing.ColorTranslator.ToOle(HKKET142F.txtLMAHMS(j).BackColor) = gvcst_COLOR_HAIIRO Then
					HKKET142F.txtLMZNOSS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_DAIDAIIRO)
				Else
					HKKET142F.txtLMZNOSS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_SIRO)
				End If
				If HKKET142F.cmdMONTH(j).Tag < Mid(gvstrCalcDate2, 1, 6) And HKKET142F.cmdMONTH(j).Tag >= Mid(gvstrCalcDate3, 1, 6) Then
					HKKET142F.txtLMZNOSS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_DAIDAIIRO)
				End If
			End If
			'// 2006/11/17 �� ADD STR ���i�̓��Ɏw�����͓��͉\�Ƃ���
			'// 2006/11/14 �� ADD STR
			'''     If Trim(musrHKKTRA.strLMZPNO(i)) = "" Then
			'''         HKKET142F.txtLMZNOSS(j).Locked = True
			'''         HKKET142F.txtLMZNOSS(j).BackColor = gvcst_COLOR_HAIIRO
			'''     End If
			'// 2006/11/14 �� ADD END
			If gvstrHINKB = "3" Or gvstrHINKB = "4" Or gvstrHINKB = "5" Then
			Else
				If Trim(musrHKKTRA.strLMZPNO(i)) = "" Then
					HKKET142F.txtLMZNOSS(j).ReadOnly = True
					HKKET142F.txtLMZNOSS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
				End If
			End If
			'// 2006/11/17 �� ADD END
			'// 2007/02/12 �� ADD STR
			Select Case musrHKKTRA.intLTKBN(i)
				Case 0
					If System.Drawing.ColorTranslator.ToOle(HKKET142F.txtLMAHMS(j).BackColor) <> gvcst_COLOR_HAIIRO Then
						HKKET142F.txtINPPLAN(j).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFC0) ' �����O���[��
						'// V2.20�� ADD
						HKKET142F.txtLMZNPF(j).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFC0) ' �����O���[��
						'// V2.20�� ADD
					End If
				Case 1
					HKKET142F.txtINPPLAN(j).BackColor = System.Drawing.ColorTranslator.FromOle(&H80C0FF) ' �I�����W
					'// V2.20�� ADD
					HKKET142F.txtLMZNPF(j).BackColor = System.Drawing.ColorTranslator.FromOle(&H80C0FF) ' �I�����W
					'// V2.20�� ADD
				Case 2
					HKKET142F.txtINPPLAN(j).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFFF) ' �������F
					'// V2.20�� ADD
					HKKET142F.txtLMZNPF(j).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFFF) ' �������F
					'// V2.20�� ADD
			End Select
			'// 2007/02/12 �� ADD STR
			
			'// V2.00�� ADD
			If Trim(HKKET142F.txtLMZNOSS(j).Text) <> "" And Val(Trim(HKKET142F.txtLMZNOSS(j).Text)) <> 0 Then
				HKKET142F.txtINPPLAN(j).ReadOnly = True
				HKKET142F.txtINPPLAN(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
				'// V2.20�� ADD
				HKKET142F.txtLMZNPF(j).ReadOnly = True
				HKKET142F.txtLMZNPF(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
				'// V2.20�� ADD
			End If
			'// V2.00�� ADD
			
			j = j + 1
			i = i + 1
			If j = 13 Then
				Exit Do
			End If
		Loop 
		
		''//�O�N�󒍎���
		HKKET142F.txtLAST_JDNTR.Text = RTrim(HKKET142F.txtLAST_JDNTR.Text)
		''//�O�N�o�Ɏ���
		HKKET142F.txtLAST_ODNTRA.Text = RTrim(HKKET142F.txtLAST_ODNTRA.Text)
		''//�O�N��������
		HKKET142F.txtLAST_HDNTRA.Text = RTrim(HKKET142F.txtLAST_HDNTRA.Text)
		''//���ɗ\��
		HKKET142F.txtINPTRA.Text = RTrim(HKKET142F.txtINPTRA.Text)
		''//�o�ɗ\��
		HKKET142F.txtOUTTRA.Text = RTrim(HKKET142F.txtOUTTRA.Text)
		''//�x���i�o��
		HKKET142F.txtSKYOUT.Text = RTrim(HKKET142F.txtSKYOUT.Text)
		''//�����Č�
		HKKET142F.txtMKMAK.Text = RTrim(HKKET142F.txtMKMAK.Text)
		''//��������
		HKKET142F.txtMKMMT.Text = RTrim(HKKET142F.txtMKMMT.Text)
		''//�����o�ɗ\��
		HKKET142F.txtMKMOUTTRA.Text = RTrim(HKKET142F.txtMKMOUTTRA.Text)
		'// 2007/01/09 �� ADD STR
		''//�\�������݌�
		HKKET142F.txtYOSLST.Text = RTrim(HKKET142F.txtYOSLST.Text)
		'// 2007/01/09 �� ADD END
		''//�����όv
		HKKET142F.txtLMAODSSA.Text = RTrim(HKKET142F.txtLMAODSSA.Text)
		''//�ً}�����όv
		HKKET142F.txtLMAKODSA.Text = RTrim(HKKET142F.txtLMAKODSA.Text)
		''//���Ɏw���ϐ�
		HKKET142F.txtLMZNOSSA.Text = RTrim(HKKET142F.txtLMZNOSSA.Text)
		''//���Ɍv�搔
		HKKET142F.txtDspINPPLAN.Text = RTrim(HKKET142F.txtDspINPPLAN.Text)
		
		'// 2007/02/09 �� ADD STR
		Call Dsp_ItemColor()
		'// 2007/02/09 �� ADD END
		
		'//�S���Ҍ����ɂ���ʐ���
		Call Set_TantoControl(HKKET142F)
		
		Set_DisplayData = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Set_CalcData
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*
	'//*****************************************************************************************
	Public Function Set_CalcData() As Boolean
		
		Const PROCEDURE As String = "Set_CalcData"
		
		Dim i As Short
		Dim j As Short
		Dim k As Short
		Dim strDate As String
		Dim dblCalc As Double
		Dim dblCalc2 As Double
		Dim dblDspINPPLAN As Double
		
		Set_CalcData = False
		
		On Error GoTo ONERR_STEP
		
		'// 2007/02/20 �� ADD STR
		If Val(HKKET142F.txtMINSODSU.Text) = 0 Or Val(HKKET142F.txtSODADDSU.Text) = 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "225")
		End If
		'// 2007/02/20 �� ADD STR
		
		'// 2007/01/09 �� ADD STR
		
		'//�\�������݌ɂ̎Z�o
		Call Set_YosokuGetumatu()
		
		'//���Ɍv�搔�̎Z�o
		Call Set_NyukoKeikakuSu()
		
		'//���Ɍv�搔�̓��̓`�F�b�N
		If Not Chk_NyukoKeikakuSu Then
			GoTo EXIT_STEP
		End If
		
		'//�����݌ɁE���������݌ɂ̎Z�o
		Call Set_Getumatuzaiko()
		
		i = 0
		Do 
			
			If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
				
				'// 2007/02/24 �� UPD STR
				'            '//���S�݌ɐ؂�}�[�N(�\�������݌ɂ��O�ȉ��̏ꍇ�͂P�F�݌ɐ؂�)
				'            If musrHKKZTRA.dblYOSLST(i) <= 0 Then
				'//���S�݌ɐ؂�}�[�N(�\�������݌ɂ��O�����̏ꍇ�͂P�F�݌ɐ؂�)
				If musrHKKZTRA.dblYOSLST(i) < 0 Then
					'// 2007/02/24 �� UPD STR
					musrHKKZTRA.strLMZAZM(i) = "1"
				Else
					musrHKKZTRA.strLMZAZM(i) = "0"
				End If
				
				'// 2007/02/24 �� UPD STR
				'            '//�݌ɐ؂�}�[�N(�\�������݌ɂ��|���S�݌ɐ��ȉ��̏ꍇ�͂P�F�݌ɐ؂�)
				'            If musrHKKZTRA.dblYOSLST(i) <= CDbl(HKKET142F.txtANZZAISU.Text) * -1 Then
				'//�݌ɐ؂�}�[�N(�\�������݌ɂ��|���S�݌ɐ��ȉ��̏ꍇ�͂P�F�݌ɐ؂�)
				If musrHKKZTRA.dblYOSLST(i) < CDbl(HKKET142F.txtANZZAISU.Text) * -1 Then
					'// 2007/02/24 �� UPD STR
					musrHKKZTRA.strLMZZKM(i) = "1"
				Else
					musrHKKZTRA.strLMZZKM(i) = "0"
				End If
				
				'// 2007/02/24 �� UPD STR
				'            '//�������S�݌ɐ؂�}�[�N(�����\�������݌ɂ��O�ȉ��̏ꍇ�͂P�F�݌ɐ؂�)
				'            If musrHKKZTRA.dblMYOSLST(i) <= 0 Then
				'//�������S�݌ɐ؂�}�[�N(�����\�������݌ɂ��O�����̏ꍇ�͂P�F�݌ɐ؂�)
				If musrHKKZTRA.dblMYOSLST(i) < 0 Then
					'// 2007/02/24 �� UPD STR
					musrHKKZTRA.strLMZMAZM(i) = "1"
				Else
					musrHKKZTRA.strLMZMAZM(i) = "0"
				End If
				
				'// 2007/02/24 �� UPD STR
				'            '//�����݌ɐ؂�}�[�N(�����\�������݌ɂ��|���S�݌ɐ��ȉ��̏ꍇ�͂P�F�݌ɐ؂�)
				'            If musrHKKZTRA.dblMYOSLST(i) <= CDbl(HKKET142F.txtANZZAISU.Text) * -1 Then
				'//�����݌ɐ؂�}�[�N(�����\�������݌ɂ��|���S�݌ɐ��ȉ��̏ꍇ�͂P�F�݌ɐ؂�)
				If musrHKKZTRA.dblMYOSLST(i) < CDbl(HKKET142F.txtANZZAISU.Text) * -1 Then
					'// 2007/02/24 �� UPD STR
					musrHKKZTRA.strLMZMZKM(i) = "1"
				Else
					musrHKKZTRA.strLMZMZKM(i) = "0"
				End If
				
			End If
			
			i = i + 1
			If i = 36 Then
				Exit Do
			End If
		Loop 
		
		'//�@���ڂɐF��t����
		Call Dsp_ItemColor()
		
		Set_CalcData = True
		'// 2007/01/09 �� ADD END
		
		'// 2007/01/09 �� DEL STR
		''''    Const PROCEDURE         As String = "Set_CalcData"
		''''
		''''    Dim i           As Integer
		''''    Dim j           As Integer
		''''    Dim k           As Integer
		''''    Dim strDate     As String
		''''    Dim dblCalc     As Double
		''''    Dim dblCalc2    As Double
		''''    Dim dblDspINPPLAN  As Double
		''''
		''''    Set_CalcData = False
		''''
		''''    On Error GoTo ONERR_STEP
		''''
		''''    i = 0
		''''    'j = gvlngNowPage
		''''    Do
		''''        If i = 0 Then
		''''            If Trim(musrODINTRA.strLMZNOSS(i)) = "" Then
		''''                '//�����݌�:                   ���ɗ\��                   �o�ɗ\��@�@�@�@�@�@�@�@�@�@�x���i�o��
		''''                musrHKKZTRA.dblLAST_STOCK(i) = musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i))
		''''                '//���������݌�:          ���ɗ\��                    �o�ɗ\��@�@�@�@�@�@�@�@�@  �x���i�o��                 '//�����o�ɗ\��
		''''                musrMKMTRA.dblMKMLST(i) = musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + musrMKMTRA.dblMKMOUTTRA(i))
		''''            Else
		''''                '//�����݌�:                   ���ɗ\��                   ���Ɏw����                  �o�ɗ\��@�@�@�@�@�@�@�@�@�@�x���i�o��
		''''                musrHKKZTRA.dblLAST_STOCK(i) = musrHKKZTRA.dblINPTRA(i) + musrODINTRA.strLMZNOSS(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i))
		''''                '//���������݌�:          ���ɗ\��                   ���Ɏw����                  �o�ɗ\��@�@�@�@�@�@�@�@�@  �x���i�o��                 '//�����o�ɗ\��
		''''                musrMKMTRA.dblMKMLST(i) = musrHKKZTRA.dblINPTRA(i) + musrODINTRA.strLMZNOSS(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + musrMKMTRA.dblMKMOUTTRA(i))
		''''            End If
		''''        Else
		''''            If Trim(musrODINTRA.strLMZNOSS(i)) = "" Then
		''''                '//�����݌�:                   �����݌�(�O��)                     ���ɗ\��                   �o�ɗ\��@�@�@�@�@�@�@�@�@�@�x���i�o��
		''''                musrHKKZTRA.dblLAST_STOCK(i) = musrHKKZTRA.dblLAST_STOCK(i - 1) + musrHKKZTRA.dblINPTRA(i) + (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i))
		''''                '//���������݌�:          ���������݌�(�O��)            ���ɗ\��                   �o�ɗ\��@�@�@�@�@�@�@�@�@  �x���i�o��                 '//�����o�ɗ\��
		''''                musrMKMTRA.dblMKMLST(i) = musrMKMTRA.dblMKMLST(i - 1) + musrHKKZTRA.dblINPTRA(i) + (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + musrMKMTRA.dblMKMOUTTRA(i))
		''''            Else
		''''                '//�����݌�:                   �����݌�(�O��)                     ���ɗ\��                   ���Ɏw����                  �o�ɗ\��@�@�@�@�@�@�@�@�@�@�x���i�o��
		''''                musrHKKZTRA.dblLAST_STOCK(i) = musrHKKZTRA.dblLAST_STOCK(i - 1) + musrHKKZTRA.dblINPTRA(i) + musrODINTRA.strLMZNOSS(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i))
		''''                '//���������݌�:          ���������݌�(�O��)            ���ɗ\��                   ���Ɏw����                  �o�ɗ\��@�@�@�@�@�@�@�@�@  �x���i�o��                 '//�����o�ɗ\��
		''''                musrMKMTRA.dblMKMLST(i) = musrMKMTRA.dblMKMLST(i - 1) + musrHKKZTRA.dblINPTRA(i) + musrODINTRA.strLMZNOSS(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + musrMKMTRA.dblMKMOUTTRA(i))
		''''            End If
		''''        End If
		''''        If musrMKMTRA.dblMKMLST(i) < 0 Then
		''''            musrMKMTRA.dblMKMLST(i) = 0
		''''        End If
		''''        If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
		''''            '//���S�݌ɐ؂�}�[�N(�����݌ɂ����S�݌ɐ���菭�Ȃ��ꍇ�͂P�F�݌ɐ؂�)
		''''            If CDbl(HKKET142F.txtANZZAISU.Text) > musrHKKZTRA.dblLAST_STOCK(i) Then
		''''                musrHKKZTRA.strLMZAZM(i) = "1"
		''''            Else
		''''                musrHKKZTRA.strLMZAZM(i) = "0"
		''''            End If
		''''
		''''            '//�݌ɐ؂�}�[�N(�����݌ɂ��O�ȉ��̏ꍇ�͂P�F�݌ɐ؂�)
		''''            If musrHKKZTRA.dblLAST_STOCK(i) <= 0 Then
		''''                musrHKKZTRA.strLMZZKM(i) = "1"
		''''            Else
		''''                musrHKKZTRA.strLMZZKM(i) = "0"
		''''            End If
		''''
		''''            '//�������S�݌ɐ؂�}�[�N(���������݌ɂ����S�݌ɐ���菭�Ȃ��ꍇ�͂P�F�݌ɐ؂�)
		''''            If CDbl(HKKET142F.txtANZZAISU.Text) > musrMKMTRA.dblMKMLST(i) Then
		''''                musrHKKZTRA.strLMZMAZM(i) = "1"
		''''            Else
		''''                musrHKKZTRA.strLMZMAZM(i) = "0"
		''''            End If
		''''
		''''            '//�����݌ɐ؂�}�[�N(���������݌ɂ��O�ȉ��̏ꍇ�͂P�F�݌ɐ؂�)
		''''            If musrMKMTRA.dblMKMLST(i) <= 0 Then
		''''                musrHKKZTRA.strLMZMZKM(i) = "1"
		''''            Else
		''''                musrHKKZTRA.strLMZMZKM(i) = "0"
		''''            End If
		''''            '//���Ɍv�搔(�Z�o)
		''''            If Trim(musrODINTRA.strLMZNOSS(i)) = "" Then
		''''                If IsNumeric(musrHKKTRA.strLMAHMS(i)) Or _
		'''''                    IsNumeric(musrHKKTRA.strLMAHKS(i)) Then
		''''                    If musrHKKTRA.strLMAHMS(i) = "" Then
		''''                        dblCalc = Val(musrHKKTRA.strLMAHKS(i))
		''''                    Else
		''''                        dblCalc = Val(musrHKKTRA.strLMAHMS(i))
		''''                    End If
		''''                End If
		''''                dblDspINPPLAN = CDbl(HKKET142F.txtANZZAISU.Text) + dblCalc + musrMKMTRA.dblMKMLST(i - 1)
		''''                'If dblDspINPPLAN - CDbl(HKKET142F.txtANZZAISU.Text) <= 0 Then
		''''                '    musrODINTRA.dblDspINPPLAN(i) = CDbl(HKKET142F.txtMINSODSU.Text)
		''''                'End If
		''''                'If dblDspINPPLAN - CDbl(HKKET142F.txtANZZAISU.Text) > 0 Then
		''''                '    If CDbl(HKKET142F.txtSODADDSU.Text) = 0 Then
		''''                '        dblCalc2 = Round((dblDspINPPLAN - CDbl(HKKET142F.txtANZZAISU.Text)) / 1)
		''''                '    Else
		''''                '        dblCalc2 = Round((dblDspINPPLAN - CDbl(HKKET142F.txtANZZAISU.Text)) / CDbl(HKKET142F.txtSODADDSU.Text))
		''''                '    End If
		''''                '    musrODINTRA.dblDspINPPLAN(i) = CDbl(HKKET142F.txtMINSODSU) + (CDbl(HKKET142F.txtSODADDSU.Text) * dblCalc2)
		''''                'End If
		''''                If CDbl(HKKET142F.txtSODADDSU.Text) <> 0 Then
		''''                    dblCalc2 = Round((dblDspINPPLAN - CDbl(HKKET142F.txtMINSODSU)) / CDbl(HKKET142F.txtSODADDSU.Text) + 0.9) * CDbl(HKKET142F.txtSODADDSU.Text) + CDbl(HKKET142F.txtMINSODSU)
		''''                Else
		''''                    dblCalc2 = 0
		''''                End If
		''''                musrODINTRA.dblDspINPPLAN(i) = dblCalc2
		''''            Else
		''''                musrODINTRA.dblDspINPPLAN(i) = musrODINTRA.dblDspINPPLAN_ORG(i)
		''''            End If
		''''        End If
		''''
		''''        If gvlngNowPage <= i Then
		''''            If j < 13 Then
		''''                ''//�����݌�
		''''                HKKET142F.txtLAST_STOCK(j).Text = musrHKKZTRA.dblLAST_STOCK(i)
		''''                ''//���������݌�
		''''                HKKET142F.txtMKMLST(j).Text = musrMKMTRA.dblMKMLST(i)
		'''''                HKKET142F.txtMKMLST(j).BackColor = gvcst_COLOR_SIRO
		'''''                HKKET142F.txtLAST_STOCK(j).BackColor = gvcst_COLOR_SIRO
		'''''                HKKET142F.txtLMZNOSS(j).BackColor = gvcst_COLOR_SIRO
		''''
		''''                '//�����݌�
		''''                If musrHKKZTRA.strLMZAZM(i) = "0" And _
		'''''                    musrHKKZTRA.strLMZZKM(i) = "0" Then
		''''                    HKKET142F.txtLAST_STOCK(j).BackColor = gvcst_COLOR_MIZURO
		''''                ElseIf musrHKKZTRA.strLMZZKM(i) = "1" Then
		''''                    HKKET142F.txtLAST_STOCK(j).BackColor = gvcst_COLOR_AKAIRO
		''''                ElseIf musrHKKZTRA.strLMZAZM(i) = "1" Then
		''''                    HKKET142F.txtLAST_STOCK(j).BackColor = gvcst_COLOR_MOMOIRO
		''''                End If
		''''                If HKKET141F.optCARRIES_ON.Value And HKKET141F.optSTOCK_MONTH.Value Then
		''''                    If musrHKKZTRA.dblLMZZKT(i) >= CDbl(HKKET141F.txtSTOCK_MONTH.Text) Then
		''''                        HKKET142F.txtLAST_STOCK(j).BackColor = gvcst_COLOR_KAKIIRO
		''''                    End If
		''''                End If
		''''                '//���������݌�
		''''                If musrHKKZTRA.strLMZMAZM(i) = "0" And _
		'''''                    musrHKKZTRA.strLMZMZKM(i) = "0" Then
		''''                    HKKET142F.txtMKMLST(j).BackColor = gvcst_COLOR_MIZURO
		''''                ElseIf musrHKKZTRA.strLMZMZKM(i) = "1" Then
		''''                    HKKET142F.txtMKMLST(j).BackColor = gvcst_COLOR_AKAIRO
		''''                ElseIf musrHKKZTRA.strLMZMAZM(i) = "1" Then
		''''                    HKKET142F.txtMKMLST(j).BackColor = gvcst_COLOR_MOMOIRO
		''''                End If
		''''
		''''                If HKKET141F.optCARRIES_ON.Value And HKKET141F.optSTOCK_MONTH.Value Then
		''''                    If musrHKKZTRA.dblLMZMZKT(i) >= CDbl(HKKET141F.txtSTOCK_MONTH.Text) Then
		''''                        HKKET142F.txtMKMLST(j).BackColor = gvcst_COLOR_KAKIIRO
		''''                    End If
		''''                End If
		''''
		''''                '//������
		''''                If Trim(musrHKKZTRA.strLMZHDT(i)) <> "" Then
		''''                    HKKET142F.txtLMZNOSS(j).BackColor = gvcst_COLOR_AKAIRO
		''''                End If
		''''                j = j + 1
		''''            End If
		''''        End If
		''''        i = i + 1
		''''        If i = 36 Then
		''''            Exit Do
		''''        End If
		''''    Loop
		''''
		''''    ''//���Ɍv�搔
		''''    HKKET142F.txtINPPLAN.Text = vbNullString
		''''    i = gvlngNowPage
		''''    j = 0
		''''    Do
		''''        ''//���Ɍv�搔
		''''        HKKET142F.txtINPPLAN.Text = HKKET142F.txtINPPLAN.Text & Right("      " & Format(musrODINTRA.dblDspINPPLAN(i), "####0"), 6) & "  "
		''''        i = i + 1
		''''        j = j + 1
		''''        If j = 13 Then
		''''            Exit Do
		''''        End If
		''''    Loop
		''''    ''//���Ɍv�搔
		''''    HKKET142F.txtINPPLAN.Text = RTrim(HKKET142F.txtINPPLAN.Text)
		''''
		''''    Set_CalcData = True
		'// 2007/01/09 �� DEL END
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Dsp_ItemColor
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*
	'//*****************************************************************************************
	Public Function Dsp_ItemColor() As Boolean
		
		Const PROCEDURE As String = "Dsp_ItemColor"
		
		Dim i As Short
		Dim j As Short
		Dim k As Short
		Dim strDate As String
		Dim dblCalc As Double
		Dim dblCalc2 As Double
		Dim dblDspINPPLAN As Double
		
		Dsp_ItemColor = False
		
		On Error GoTo ONERR_STEP
		
		i = 0
		Do 
			If gvlngNowPage <= i Then
				If j < 13 Then
					''//�����݌�
					HKKET142F.txtLAST_STOCK(j).Text = CStr(musrHKKZTRA.dblLAST_STOCK(i))
					''//���������݌�
					HKKET142F.txtMKMLST(j).Text = CStr(musrMKMTRA.dblMKMLST(i))
					'                HKKET142F.txtMKMLST(j).BackColor = gvcst_COLOR_SIRO
					'                HKKET142F.txtLAST_STOCK(j).BackColor = gvcst_COLOR_SIRO
					'                HKKET142F.txtLMZNOSS(j).BackColor = gvcst_COLOR_SIRO
					
					'//�����݌�
					If musrHKKZTRA.strLMZAZM(i) = "0" And musrHKKZTRA.strLMZZKM(i) = "0" Then
						HKKET142F.txtLAST_STOCK(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_MIZURO)
					ElseIf musrHKKZTRA.strLMZZKM(i) = "1" Then 
						HKKET142F.txtLAST_STOCK(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_AKAIRO)
					ElseIf musrHKKZTRA.strLMZAZM(i) = "1" Then 
						HKKET142F.txtLAST_STOCK(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_MOMOIRO)
					End If
					If HKKET141F.optCARRIES_ON.Checked And HKKET141F.optSTOCK_MONTH.Checked Then
						If musrHKKZTRA.dblLMZZKT(i) >= CDbl(HKKET141F.txtSTOCK_MONTH.Text) Then
							HKKET142F.txtLAST_STOCK(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_KAKIIRO)
						End If
					End If
					'//���������݌�
					If musrHKKZTRA.strLMZMAZM(i) = "0" And musrHKKZTRA.strLMZMZKM(i) = "0" Then
						HKKET142F.txtMKMLST(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_MIZURO)
					ElseIf musrHKKZTRA.strLMZMZKM(i) = "1" Then 
						HKKET142F.txtMKMLST(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_AKAIRO)
					ElseIf musrHKKZTRA.strLMZMAZM(i) = "1" Then 
						HKKET142F.txtMKMLST(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_MOMOIRO)
					End If
					
					If HKKET141F.optCARRIES_ON.Checked And HKKET141F.optSTOCK_MONTH.Checked Then
						If musrHKKZTRA.dblLMZMZKT(i) >= CDbl(HKKET141F.txtSTOCK_MONTH.Text) Then
							HKKET142F.txtMKMLST(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_KAKIIRO)
						End If
					End If
					
					'//������
					'           If Trim(musrHKKZTRA.strLMZHDT(i)) <> "" Then                     2007/08/16 DEL
					'               HKKET142F.txtLMZNOSS(j).BackColor = gvcst_COLOR_AKAIRO       2007/08/16 DEL
					'            End If                                                          2007/08/16 DEL
					
					j = j + 1
				End If
				
			End If
			i = i + 1
			If i = 36 Then
				Exit Do
			End If
		Loop 
		
		Dsp_ItemColor = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	
	'// 2007/01/09 �� ADD STR
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Cra_GraphCSV
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    ���Ɍv�搔���J�z�������ȏ�͎����ɉ��Z�ł��Ȃ�
	'//*****************************************************************************************
	Public Function Cra_GraphCSV(ByVal strFilePath As String, ByVal str_FileName As String) As Boolean
		
		Const PROCEDURE As String = "Cra_GraphCSV"
		
		Dim i As Integer
		Dim intFileNo As Short
		Dim strBuff As String

        Dim int_Idx As Short
        Dim str_DialogFilePath As String
        Dim str_DialogFileName_1 As String
        Dim str_DialogFileName_2 As String
		Dim str_FileName_1 As String
		Dim str_FileName_2 As String
        'add test start 20190930 kuwa CSV
        str_DialogFilePath = "C:\Users\CIS03\Desktop\HKKET14CSV"
        'add end 20190930 kuwa

        Cra_GraphCSV = False
		
		On Error GoTo ONERR_STEP
		
		'//���ʗp�t�@�C�������쐬����
		str_FileName_1 = str_FileName
		
		'//�ʗp�t�@�C�������쐬����
		int_Idx = InStr(1, str_FileName, ".")
		str_FileName_2 = Mid(str_FileName, 1, int_Idx - 1) & "_2" & Mid(str_FileName, int_Idx)
		
		'//�_�C�A���O�{�b�N�X�N��
		str_DialogFileName_1 = str_FileName_1
		If Not Run_DialogBox((HKKET142F.cdl_SAVE2), str_DialogFilePath, str_DialogFileName_1) Then
			GoTo EXIT_STEP
		End If
		
		'//�ʗp�t�@�C�������쐬����
		int_Idx = InStr(1, str_DialogFileName_1, ".")
		str_DialogFileName_2 = Mid(str_DialogFileName_1, 1, int_Idx - 1) & "_2" & Mid(str_DialogFileName_1, int_Idx)
		
		'//�������ʂb�r�u����(���ʍ���)
		intFileNo = FreeFile()
		FileOpen(intFileNo, strFilePath & "\" & str_FileName_1, OpenMode.Output)
		
		'//�P�s��
		strBuff = ""
		strBuff = strBuff & "�R�[�h" & ","
		strBuff = strBuff & "����" & ","
		For i = 0 To 35
			strBuff = strBuff & musrHKKZTRA.strDSPMONTH(i) '//�\���N��
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//�Q�s��
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "�N���v��,"
		For i = 0 To 35
			strBuff = strBuff & musrHKKTRA.strLMAHKS(i) '//�N���v��
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//�R�s��
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "�����v��,"
		For i = 0 To 35
			strBuff = strBuff & musrHKKTRA.strLMAHMS(i) '//�����v��
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//�S�s��
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "�O�N�󒍎���,"
		For i = 0 To 35
			strBuff = strBuff & musrHKKZTRA.dblLAST_JDNTR(i) '//�O�N�󒍎���
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//�T�s��
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "���ɗ\��,"
		For i = 0 To 35
			strBuff = strBuff & musrHKKZTRA.dblINPTRA(i) '//���ɗ\��
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//�U�s��
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "�o�ɗ\��,"
		For i = 0 To 35
			strBuff = strBuff & musrHKKZTRA.dblOUTTRA(i) '//�o�ɗ\��
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//�V�s��
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "�x���i�o��,"
		For i = 0 To 35
			strBuff = strBuff & musrHKKZTRA.dblSKYOUT(i) '//�x���i�o��
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//�W�s��
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "�����݌�,"
		For i = 0 To 35
			strBuff = strBuff & musrHKKZTRA.dblLAST_STOCK(i) '//�����݌�
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//�X�s��
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "�����Č�,"
		For i = 0 To 35
			strBuff = strBuff & musrMKMTRA.dblMKMAK(i) '//�����Č�
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//10�s��
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "��������,"
		For i = 0 To 35
			strBuff = strBuff & musrMKMTRA.dblMKMMT(i) '//��������
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//11�s��
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "�����o�ɗ\��,"
		For i = 0 To 35
			strBuff = strBuff & musrMKMTRA.dblMKMOUTTRA(i) '//�����o�ɗ\��
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//12�s��
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "���������݌�,"
		For i = 0 To 35
			strBuff = strBuff & musrMKMTRA.dblMKMLST(i) '//���������݌�
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//13�s��
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "�\�������݌�,"
		For i = 0 To 35
			strBuff = strBuff & musrHKKZTRA.dblYOSLST(i) '//�\�������݌�
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//14�s��
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "�����\�������݌�,"
		For i = 0 To 35
			strBuff = strBuff & musrHKKZTRA.dblMYOSLST(i) '//�����\�������݌�
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//15�s��
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "�����ϐ�,"
		For i = 0 To 35
			strBuff = strBuff & musrODINTRA.dblLMAODSSA(i) '//�����ϐ�
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//16�s��
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "�ً}������,"
		For i = 0 To 35
			strBuff = strBuff & musrODINTRA.dblLMAKODSA(i) '//�ً}������
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//17�s��
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "���Ɏw���ϐ�,"
		For i = 0 To 35
			strBuff = strBuff & musrODINTRA.dblLMZNOSSA(i) '//���Ɏw���ϐ�
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//18�s��
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "���Ɍv�搔,"
		For i = 0 To 35
			strBuff = strBuff & musrODINTRA.strINPPLAN(i) '//���Ɍv�搔
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//19�s��
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "���Ɏw����,"
		For i = 0 To 35
			strBuff = strBuff & musrODINTRA.strLMZNOSS(i) '//���Ɏw����
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		FileClose(intFileNo)
		
		'//�������ʂb�r�u����(�ʍ���)
		intFileNo = FreeFile()
		FileOpen(intFileNo, strFilePath & "\" & str_FileName_2, OpenMode.Output)
		
		'//�P�s��
		strBuff = ""
		strBuff = strBuff & "����" & ","
		strBuff = strBuff & "�^��" & ","
		strBuff = strBuff & "�݌��ݸ" & ","
		strBuff = strBuff & "���i�S" & ","
		strBuff = strBuff & "�ŏ�������" & ","
		strBuff = strBuff & "����������" & ","
		strBuff = strBuff & "���S�݌ɐ�" & ","
		strBuff = strBuff & "���S�݌Ɋ����" & ","
		strBuff = strBuff & "�݌Ɍ���" & ","
		strBuff = strBuff & "���Ϗo�ɐ�" & ","
		strBuff = strBuff & "�o�וω���" & ","
		strBuff = strBuff & "���BL/T" & ","
		strBuff = strBuff & "���YL/T" & ","
		strBuff = strBuff & "�������Ɏ���" & ","
		strBuff = strBuff & "�����o�Ɏ���" & ","
		strBuff = strBuff & "���݌�" & ","
		strBuff = strBuff & "���l����" & ","
		strBuff = strBuff & "�Ӻ���"
		PrintLine(intFileNo, strBuff)
		
		'//�Q�s��
		strBuff = ""
		strBuff = strBuff & HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & HKKET142F.txtHINNMA.Text & ","
		strBuff = strBuff & HKKET142F.txtZAIRNK.Text & ","
		strBuff = strBuff & gvstrHINGRP & ","
		strBuff = strBuff & HKKET142F.txtMINSODSU.Text & ","
		strBuff = strBuff & HKKET142F.txtSODADDSU.Text & ","
		strBuff = strBuff & HKKET142F.txtANZZAISU.Text & ","
		strBuff = strBuff & HKKET142F.txtLMAMSAVTS.Text & ","
		strBuff = strBuff & HKKET142F.txtLMAAVTS.Text & ","
		strBuff = strBuff & HKKET142F.txtLMZAVTSA.Text & ","
		strBuff = strBuff & HKKET142F.txtCHGRATE.Text & ","
		strBuff = strBuff & HKKET142F.txtPRCCD.Text & ","
		strBuff = strBuff & HKKET142F.txtMNFDD.Text & ","
		strBuff = strBuff & HKKET142F.txtTOUNYUKO.Text & ","
		strBuff = strBuff & HKKET142F.txtTOUSYUKO.Text & ","
		strBuff = strBuff & HKKET142F.txtTOUZAISU.Text & ","
		strBuff = strBuff & HKKET142F.txtHINCM.Text & ","
		strBuff = strBuff & HKKET142F.txtMEMO.Text
		PrintLine(intFileNo, strBuff)
		
		FileClose(intFileNo)
		
		'//�I�����ꂽ�t�@�C���̈ړ�
		On Error Resume Next
		Kill(str_DialogFilePath & str_DialogFileName_1)
		FileCopy(strFilePath & "\" & str_FileName_1, str_DialogFilePath & str_DialogFileName_1)
		Kill(strFilePath & "\" & str_FileName_1)
		On Error GoTo 0
		
		'//�I�����ꂽ�t�@�C���̈ړ�
		On Error Resume Next
		Kill(str_DialogFilePath & str_DialogFileName_2)
		FileCopy(strFilePath & "\" & str_FileName_2, str_DialogFilePath & str_DialogFileName_2)
		Kill(strFilePath & "\" & str_FileName_2)
		On Error GoTo 0
		
		Cra_GraphCSV = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'// 2007/01/09 �� ADD END
	
	'// 2007/01/09 �� ADD STR
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Chk_NyukoKeikakuSu
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    ���Ɍv�搔���J�z�������ȏ�͎����ɉ��Z�ł��Ȃ�
	'//*****************************************************************************************
	Public Function Chk_NyukoKeikakuSu() As Boolean
		
		Const PROCEDURE As String = "Chk_NyukoKeikakuSu"
		
		Dim dblNyukoKeiSu_CAL As Double
		Dim dblNyukoKeiSu_ORG As Double
		Dim i As Short
		Dim j As Short
		
		Chk_NyukoKeikakuSu = False
		
		On Error GoTo ONERR_STEP
		
		i = 0
		Do 
			
			'//�����ȍ~�̂ݏ�������
			If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
				
				'//����LT���ԓ��݂̂Ń`�F�b�N����
				If musrHKKTRA.intLTKBN(i) = 1 Then
					If Val(Trim(musrODINTRA.strINPPLAN(i))) > musrODINTRA.dblDspINPPLAN_ZEN(i) Then
						'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "219")
						GoTo EXIT_STEP
					End If
				End If
				
				'//���BLT���ԓ��݂̂Ń`�F�b�N����
				If musrHKKTRA.intLTKBN(i) = 2 Then
					dblNyukoKeiSu_CAL = dblNyukoKeiSu_CAL + Val(Trim(musrODINTRA.strINPPLAN(i)))
					dblNyukoKeiSu_ORG = dblNyukoKeiSu_ORG + musrODINTRA.dblDspINPPLAN_ZEN(i)
					
					If dblNyukoKeiSu_CAL > dblNyukoKeiSu_ORG Then
						'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "219")
						GoTo EXIT_STEP
					End If
					
				End If
			End If
			
			i = i + 1
			If i = 36 Then
				Exit Do
			End If
		Loop 
		
		Chk_NyukoKeikakuSu = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'// 2007/01/09 �� ADD END
	
	'// 2007/01/09 �� ADD STR
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Set_NyukoKeikakuSu
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    ���Ɍv�搔�����߂�
	'//*****************************************************************************************
	Public Function Set_NyukoKeikakuSu() As Boolean
		
		Const PROCEDURE As String = "Set_NyukoKeikakuSu"
		
		''  Dim dblMokuhyoChi   As Double
		Dim dblNyukoKeiSu As Double
		''  Dim dblKeisanMinus  As Double
		''  Dim dblKeisanPlus   As Double
		
		'//2007/12/18 ADD START
		Dim dblKomiyosoku As Double '�A�h�o�C�X���݂̗\�������݌�
		Dim dblKurikosi As Double '�J�z
		'//200712/18 ADD END
		
		Dim i As Short
		Dim j As Short
		Dim dblWork As Double
		
		
		Set_NyukoKeikakuSu = False
		
		On Error GoTo ONERR_STEP
		'//2007/12/18 ADD START
		dblKomiyosoku = 0
		dblKurikosi = 0
		'//2007/12/18 ADD END
		i = 0
		Do 
			'// 2007/11/27 REP START ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			'//
			'//        '//�����ȍ~�̂ݏ�������
			'//        If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
			'//
			'//            musrODINTRA.dblDspINPPLAN(i) = 0
			'//            dblMokuhyoChi = 0
			'//            dblNyukoKeiSu = 0
			'//
			'//'// 2007/02/17 �� DLL STR
			'//'            If musrHKKZTRA.dblYOSLST(i) < 0 Then
			'//'// 2007/02/17 �� DLL END
			'//
			'//                '//�ڕW�l�̎擾�i�����v��܂��͔N���v��(�������D��)�j
			'//                If Trim(musrHKKTRA.strLMAHMS(i)) = "" Then
			'//                    dblMokuhyoChi = Val(musrHKKTRA.strLMAHKS(i))
			'//                Else
			'//                    dblMokuhyoChi = Val(musrHKKTRA.strLMAHMS(i))
			'//                End If
			'//
			'//                '//���Ɍv�搔�̌v�Z
			'//                If Val(Trim(musrODINTRA.strINPPLAN(i))) = 0 Then
			'//'                    dblNyukoKeiSu = dblMokuhyoChi - musrHKKZTRA.dblYOSLST(i)
			'//                    dblNyukoKeiSu = dblMokuhyoChi - musrHKKZTRA.dblYOSLST(i - 1)
			'//'                Else
			'//'                    dblNyukoKeiSu = Val(Trim(musrODINTRA.strINPPLAN(i)))
			'//                End If
			'//
			'//                '//�J�z�v�Z
			'//                If Val(Trim(musrODINTRA.strINPPLAN(i))) = 0 Then
			'//                    If musrHKKTRA.intLTKBN(i) <> 0 Then
			'//                        If musrODINTRA.dblDspINPPLAN_ZEN(i) > dblNyukoKeiSu Then
			'//                            dblKeisanMinus = dblKeisanMinus + (dblNyukoKeiSu - musrODINTRA.dblDspINPPLAN_ZEN(i))
			'//                        Else
			'//                            dblKeisanPlus = dblKeisanPlus + (dblNyukoKeiSu - musrODINTRA.dblDspINPPLAN_ZEN(i))
			'//                        End If
			'//                    End If
			'//                End If
			'//
			'//                '//�J�z�v�Z���ʔ��f�Ɠ��Ɍv�搔�ݒ�
			'//                Select Case musrHKKTRA.intLTKBN(i)
			'//
			'//                    Case 0              '//�ʏ�
			'//'// 2007/02/12 �� ADD START
			'//                        '//�\�������݌ɂ��|�P�ȉ��̂Ƃ��Ɍv�Z����
			'//                        If musrHKKZTRA.dblYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi < 0 Then
			'//'                            dblWork = Get_Hacyusu(musrHKKZTRA.dblYOSLST(i))
			'//                            dblWork = Get_Hacyusu(musrHKKZTRA.dblYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi)
			'//                            musrHKKZTRA.dblYOSLST(i) = musrHKKZTRA.dblYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi + dblWork
			'//                            musrHKKZTRA.dblMYOSLST(i) = musrHKKZTRA.dblMYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi + dblWork
			'//                            dblNyukoKeiSu = dblWork
			'//                            musrODINTRA.dblDspINPPLAN(i) = Get_Hacyusu(dblNyukoKeiSu)
			'//                        Else
			'//'                            musrHKKZTRA.dblYOSLST(i) = musrHKKZTRA.dblYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi + dblKeisanPlus + dblKeisanMinus
			'//'                            musrHKKZTRA.dblMYOSLST(i) = musrHKKZTRA.dblMYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi + dblKeisanPlus + dblKeisanMinus
			'//                            musrHKKZTRA.dblYOSLST(i) = musrHKKZTRA.dblYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi
			'//'// 2007/06/29 �� UPD START @T
			'//'                           musrHKKZTRA.dblMYOSLST(i) = musrHKKZTRA.dblMYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi
			'//                           '//�\�������݌�:            �O���\�������݌�                ���ɗ\��                    �����o�ɗ\��                 �ڕW�l
			'//                            musrHKKZTRA.dblMYOSLST(i) = musrHKKZTRA.dblMYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - musrMKMTRA.dblMKMOUTTRA(i) - dblMokuhyoChi
			'//'// 2007/06/29 �� UPD END   @T
			'//                            dblNyukoKeiSu = 0
			'//                        End If
			'//'// 2007/02/12 �� ADD END
			'//
			'//'                        If musrHKKZTRA.dblYOSLST(i) + dblKeisanPlus + dblKeisanMinus <> 0 Then
			'//'                            musrODINTRA.dblDspINPPLAN(i) = Get_Hacyusu(musrHKKZTRA.dblYOSLST(i) + dblKeisanPlus + dblKeisanMinus)
			'//'                        If dblNyukoKeiSu <> 0 Then
			'//'                            musrODINTRA.dblDspINPPLAN(i) = Get_Hacyusu(dblNyukoKeiSu)
			'//'                        Else
			'//'                            musrODINTRA.dblDspINPPLAN(i) = dblNyukoKeiSu
			'//'                        End If
			'//                        dblKeisanPlus = 0
			'//                        dblKeisanMinus = 0
			'//                    Case 1              '//����LT
			'//                        If musrHKKZTRA.dblYOSLST(i) < 0 Then
			'//                            If musrODINTRA.dblDspINPPLAN_ZEN(i) <= 0 Then
			'//                                musrODINTRA.dblDspINPPLAN(i) = musrODINTRA.dblDspINPPLAN_ZEN(i)
			'//                            Else
			'//                                musrODINTRA.dblDspINPPLAN(i) = Get_Hacyusu(musrODINTRA.dblDspINPPLAN_ZEN(i))
			'//                            End If
			'//                        Else
			'//                            dblKeisanPlus = 0
			'//                            dblKeisanMinus = 0
			'//                        End If
			'//                    Case 2              '//���BLT
			'//                        If musrHKKZTRA.dblYOSLST(i) < 0 Then
			'//                            If musrODINTRA.dblDspINPPLAN_ZEN(i) <= 0 Then
			'//                                musrODINTRA.dblDspINPPLAN(i) = musrODINTRA.dblDspINPPLAN_ZEN(i)
			'//                            Else
			'//                                musrODINTRA.dblDspINPPLAN(i) = Get_Hacyusu(musrODINTRA.dblDspINPPLAN_ZEN(i) + dblKeisanMinus)
			'//                                dblKeisanMinus = 0
			'//                            End If
			'//                        Else
			'//                            dblKeisanPlus = 0
			'//                            dblKeisanMinus = 0
			'//                        End If
			'//
			'//                End Select
			'//
			'// 2007/02/12 �� ADD STR
			'//            End If
			'// 2007/02/12 �� ADD END
			'//
			'//        End If
			'////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			
			
			'//�����ȍ~�̂ݏ�������
			If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
				
				musrODINTRA.dblDspINPPLAN(i) = 0 '//�A�h�o�C�X�����N���A
				dblNyukoKeiSu = 0
				
				dblKomiyosoku = dblKurikosi + musrHKKZTRA.dblMYOSLST(i) '//�O���܂ł̃A�h�o�C�X���݂̗\�������݌�
				
				'// 2008/05/21 �� ADD STR ���Ɏw�����ɃX�y�[�X���[���������Ă�ꍇ�́A�A�h�o�C�X�l�͌J��z��
				If Val(Trim(musrODINTRA.strLMZNOSS(i))) <> 0 Then
					musrODINTRA.dblDspINPPLAN(i) = 0
				Else
					'// 2008/05/21 �� ADD STR
					
					'//�J�z�v�Z���ʔ��f�Ɠ��Ɍv�搔�ݒ�
					Select Case musrHKKTRA.intLTKBN(i)
						Case 0 '//�ʏ� ������
							If dblKomiyosoku < 0 Then '//�݌ɕs��  ���Ɍv��̒ǉ����A�h�o�C�X
								musrODINTRA.dblDspINPPLAN(i) = Get_Hacyusu(0 - dblKomiyosoku)
							Else
								'// 2008/05/27 �� UPD STR ���Ɍv��(�A�g)�ɃX�y�[�X�����͂����ƃG���[����������
								'                                If Get_Hacyusu(dblKomiyosoku) > musrODINTRA.strINPPLAN(i) Then  '//�݌ɉߑ�  ���Ɍv��̎�����A�h�o�C�X
								'                                    musrODINTRA.dblDspINPPLAN(i) = 0 - musrODINTRA.strINPPLAN(i)
								If Get_Hacyusu(dblKomiyosoku) > Val(musrODINTRA.strINPPLAN(i)) Then '//�݌ɉߑ�  ���Ɍv��̎�����A�h�o�C�X
									musrODINTRA.dblDspINPPLAN(i) = 0 - Val(musrODINTRA.strINPPLAN(i))
									'// 2008/05/27 �� UPD STR
								Else '//�݌ɉߑ�  ���Ɍv��̌��Z���A�h�o�C�X
									'// 2008/05/27 �� UPD STR ���Ɍv��(�A�g)�ɃX�y�[�X�����͂����ƃG���[����������
									'                                    If Get_Hacyusu(dblKomiyosoku) < musrODINTRA.strINPPLAN(i) Then
									If Get_Hacyusu(dblKomiyosoku) < Val(musrODINTRA.strINPPLAN(i)) Then
										'// 2008/05/27 �� UPD STR
										'// 2008/05/27 �� UPD STR ���Ɍv��(�A�g)�����޲��ʂ���͂��Ă����޲��l���O�ɂȂ�Ȃ��Ή�
										'                                         musrODINTRA.dblDspINPPLAN(i) = 0 - Get_Hacyusu(dblKomiyosoku)
										If dblKomiyosoku <> 0 Then
											musrODINTRA.dblDspINPPLAN(i) = 0 - Get_Hacyusu(dblKomiyosoku)
										Else
											musrODINTRA.dblDspINPPLAN(i) = 0
										End If
										'// 2008/05/27 �� UPD STR
									Else
										musrODINTRA.dblDspINPPLAN(i) = 0
									End If
								End If
							End If
						Case 1 '//����LT�@�����s��
							musrODINTRA.dblDspINPPLAN(i) = 0
						Case 2 '//���BLT�@���̂݉�
							If dblKomiyosoku < 0 Then
								musrODINTRA.dblDspINPPLAN(i) = 0 '//�݌ɕs��  �����փA�h�o�C�X���J�z
							Else
								'// 2008/05/27 �� UPD STR ���Ɍv��(�A�g)�ɃX�y�[�X�����͂����ƃG���[����������
								'                                If Get_Hacyusu(dblKomiyosoku) > musrODINTRA.strINPPLAN(i) Then        '//�݌ɉߑ�  ���Ɍv��̎�����A�h�o�C�X
								'                                     musrODINTRA.dblDspINPPLAN(i) = 0 - musrODINTRA.strINPPLAN(i)
								If Get_Hacyusu(dblKomiyosoku) > Val(musrODINTRA.strINPPLAN(i)) Then '//�݌ɉߑ�  ���Ɍv��̎�����A�h�o�C�X
									musrODINTRA.dblDspINPPLAN(i) = 0 - Val(musrODINTRA.strINPPLAN(i))
									'// 2008/05/27 �� UPD STR
								Else '//�݌ɉߑ�  ���Ɍv��̌��Z���A�h�o�C�X
									'// 2008/05/27 �� UPD STR ���Ɍv��(�A�g)�ɃX�y�[�X�����͂����ƃG���[����������
									'                                    If Get_Hacyusu(dblKomiyosoku) < musrODINTRA.strINPPLAN(i) Then
									If Get_Hacyusu(dblKomiyosoku) < Val(musrODINTRA.strINPPLAN(i)) Then
										'// 2008/05/27 �� UPD STR
										'// 2008/05/27 �� UPD STR ���Ɍv��(�A�g)�����޲��ʂ���͂��Ă����޲��l���O�ɂȂ�Ȃ��Ή�
										'                                         musrODINTRA.dblDspINPPLAN(i) = 0 - Get_Hacyusu(dblKomiyosoku)
										If dblKomiyosoku <> 0 Then
											musrODINTRA.dblDspINPPLAN(i) = 0 - Get_Hacyusu(dblKomiyosoku)
										Else
											musrODINTRA.dblDspINPPLAN(i) = 0
										End If
										'// 2008/05/27 �� UPD STR
									Else
										musrODINTRA.dblDspINPPLAN(i) = 0
									End If
								End If
							End If
					End Select
					
					'// 2008/05/21 �� ADD STR ���Ɏw�����ɃX�y�[�X���[���������Ă�ꍇ�́A�A�h�o�C�X�l�͌J��z��
				End If
				'// 2008/05/21 �� ADD STR
				
				'//�����J�z�A�h�o�C�X�i�A�h�o�C�X�̗݌v�j
				dblKurikosi = dblKurikosi + musrODINTRA.dblDspINPPLAN(i)
			End If

            i = i + 1
            If i = 36 Then
                Exit Do
            End If
        Loop 
		
		''//�\�������݌�
		HKKET142F.txtYOSLST.Text = vbNullString
		i = gvlngNowPage
		j = 0
		Do 
			''//�\�������݌�
			If musrHKKZTRA.strDSPMONTH(i) = "" Then
				If HKKET141F.optORDER_ON.Checked Then
					HKKET142F.txtYOSLST.Text = HKKET142F.txtYOSLST.Text & Right("      " & VB6.Format(musrHKKZTRA.dblMYOSLST(i), "#####"), 6) & "  "
				Else
					HKKET142F.txtYOSLST.Text = HKKET142F.txtYOSLST.Text & Right("      " & VB6.Format(musrHKKZTRA.dblYOSLST(i), "#####"), 6) & "  "
				End If
			Else
				If HKKET141F.optORDER_ON.Checked Then
					HKKET142F.txtYOSLST.Text = HKKET142F.txtYOSLST.Text & Right("      " & VB6.Format(musrHKKZTRA.dblMYOSLST(i), "####0"), 6) & "  "
				Else
					HKKET142F.txtYOSLST.Text = HKKET142F.txtYOSLST.Text & Right("      " & VB6.Format(musrHKKZTRA.dblYOSLST(i), "####0"), 6) & "  "
				End If
			End If
			
			i = i + 1
			j = j + 1
			If j = 13 Then
				Exit Do
			End If
		Loop 
		''//�\�������݌�
		HKKET142F.txtYOSLST.Text = RTrim(HKKET142F.txtYOSLST.Text)
		
		''//���Ɍv�搔
		HKKET142F.txtDspINPPLAN.Text = vbNullString
		i = gvlngNowPage
		j = 0
		Do 
			''//���Ɍv�搔
			If musrHKKZTRA.strDSPMONTH(i) = "" Then
				HKKET142F.txtDspINPPLAN.Text = HKKET142F.txtDspINPPLAN.Text & Right("      " & VB6.Format(musrODINTRA.dblDspINPPLAN(i), "#####"), 6) & "  "
			Else
				HKKET142F.txtDspINPPLAN.Text = HKKET142F.txtDspINPPLAN.Text & Right("      " & VB6.Format(musrODINTRA.dblDspINPPLAN(i), "####0"), 6) & "  "
			End If
			
			i = i + 1
			j = j + 1
			If j = 13 Then
				Exit Do
			End If
		Loop 
		''//���Ɍv�搔
		HKKET142F.txtDspINPPLAN.Text = RTrim(HKKET142F.txtDspINPPLAN.Text)
		
		Set_NyukoKeikakuSu = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'// 2007/01/09 �� ADD END
	
	'// 2007/02/02 �� ADD STR
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Chk_Hacyusu
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    �������b�g�P�ʂɓ��͂���Ă��邩�m�F����
	'//*****************************************************************************************
	Public Function Chk_Hacyusu() As Boolean
		
		Const PROCEDURE As String = "Chk_Hacyusu"
		
		Dim i As Double
		
		On Error GoTo ONERR_STEP
		
		Chk_Hacyusu = False

        '2019/04/19 CHG START
        'For i = 1 To UBound(musrODINTRA.strINPPLAN)
        For i = 0 To musrODINTRA.strINPPLAN.Length - 1
            '2019/04/19 CHG E N D

            '// 2007/02/24 �� ADD
            '//�����ȍ~�̂ݏ�������
            If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
                '// 2007/02/24 �� ADD

                If Val(Trim(musrODINTRA.strINPPLAN(i))) <> 0 Then
                    '// �ŏ��������Ɣ�r
                    If Val(Trim(musrODINTRA.strINPPLAN(i))) < Val(HKKET142F.txtMINSODSU.Text) Then
                        Exit For
                    End If
                    '// �������b�g�P�ʂ��m�F
                    If Val(HKKET142F.txtSODADDSU.Text) <> 0 Then
                        If Val(Trim(musrODINTRA.strINPPLAN(i))) - Val(HKKET142F.txtMINSODSU.Text) <> 0 Then
                            'UPGRADE_WARNING: Mod �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
                            If ((Val(Trim(musrODINTRA.strINPPLAN(i))) - Val(HKKET142F.txtMINSODSU.Text)) Mod Val(HKKET142F.txtSODADDSU.Text)) <> 0 Then
                                Exit For
                            End If
                        End If
                    End If
                End If


                '// 2007/02/24 �� ADD
            End If
            '// 2007/02/24 �� ADD

        Next i

        '2019/04/19 CHG START
        'If i < UBound(musrODINTRA.strINPPLAN) Then
        If i < musrODINTRA.strINPPLAN.Length - 1 Then
            '2019/04/19 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "224", vbCrLf & Mid(musrHKKZTRA.strDSPMONTH(i), 1, 4) & "/" & Mid(musrHKKZTRA.strDSPMONTH(i), 5, 2) & "��" & "�ŏ���������菬�������A�����������P�ʂɓ��͂���Ă��܂���B")
            '// 2007/02/24 �� DEL
            ''''        GoTo EXIT_STEP
            '// 2007/02/24 �� DEL
        End If

        Chk_Hacyusu = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
	'// 2007/02/02 �� ADD END
	
	'// 2007/01/09 �� ADD STR
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Set_NyukoKeikakuSu
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    �����݌ɁE���������݌ɂ����߂�
	'//*****************************************************************************************
	Public Function Set_Getumatuzaiko() As Boolean
		
		Const PROCEDURE As String = "Set_Getumatuzaiko"
		
		Dim dblMokuhyoChi As Double
		Dim dblNyukoKeiSu As Double
		''' Dim dblKeisanMinus  As Double
		''' Dim dblKeisanPlus   As Double
		Dim i As Short
		Dim j As Short
		
		Set_Getumatuzaiko = False
		
		On Error GoTo ONERR_STEP
		
		i = 0
		Do 
			
			'//�����ȍ~�̂ݏ�������
			If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
				
				If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
					
					'// << ��    �� >>
					
					'                '//�����݌�:                   ���ݍ݌ɐ�                        ���ɗ\��                   �o�ɗ\��@�@�@�@�@�@�@�@�@�@�x���i�o��
					musrHKKZTRA.dblLAST_STOCK(i) = Val(HKKET142F.txtTOUZAISU.Text) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i))
					'//�����݌�:                   ���ݍ݌ɐ�                        ���ɗ\��                   �o�ɗ\��@�@�@�@�@�@�@�@�@�@�x���i�o��
					'                musrHKKZTRA.dblLAST_STOCK(i) = musrHKKZTRA.dblLAST_STOCK(i - 1) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i))
					'//���������݌�:          �����݌�                       '//�����o�ɗ\��
					musrMKMTRA.dblMKMLST(i) = musrHKKZTRA.dblLAST_STOCK(i) - musrMKMTRA.dblMKMOUTTRA(i)
				Else
					
					'// << �����ȍ~ >>
					
					'//�����݌�:                   �����݌�(�O��)                     ���ɗ\��                   �o�ɗ\��@�@�@�@�@�@�@�@�@�@�x���i�o��
					musrHKKZTRA.dblLAST_STOCK(i) = musrHKKZTRA.dblLAST_STOCK(i - 1) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i))
					'//���������݌�:          ���������݌�(�O��)            ���ɗ\��                   �o�ɗ\��@�@�@�@�@�@�@�@�@  �x���i�o��                 '//�����o�ɗ\��
					musrMKMTRA.dblMKMLST(i) = musrMKMTRA.dblMKMLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i)) - musrMKMTRA.dblMKMOUTTRA(i)
				End If
			End If
			
			i = i + 1
			If i = 36 Then
				Exit Do
			End If
		Loop 
		
		Set_Getumatuzaiko = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'// 2007/01/09 �� ADD END
	
	'// 2007/01/09 �� ADD STR
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Get_Hacyusu
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    �ŏ��������������ꍇ�͍ŏ����������A������ꍇ�͔��������P�ʂɊۂ߂Ĕ����������߂�
	'//*****************************************************************************************
	Public Function Get_Hacyusu(ByVal dblNyukoKeiSu As Double) As Double
		
		Const PROCEDURE As String = "Get_Hacyusu"
		
		Dim dblZoukaCnt As Double
		Dim dblZoukaSu As Double
		
		On Error GoTo ONERR_STEP
		
		'// 2007/02/20 �� UPD
		Get_Hacyusu = 0
		
		If Val(HKKET142F.txtMINSODSU.Text) = 0 And dblNyukoKeiSu < 0 Then
			'//�ŏ������������݂��Ȃ��̂ł��̂܂ܕԂ�
			Get_Hacyusu = System.Math.Abs(dblNyukoKeiSu) ' HKKET142F.txtMINSODSU
			Exit Function
		End If
		
		If dblNyukoKeiSu < Val(HKKET142F.txtMINSODSU.Text) Then
			'//�ŏ���������菬�����̂ōŏ��������ɂ���
			'        Get_Hacyusu = Val(HKKET142F.txtMINSODSU)
			dblZoukaSu = Val(HKKET142F.txtMINSODSU.Text)
			dblNyukoKeiSu = dblNyukoKeiSu + Val(HKKET142F.txtMINSODSU.Text)
			Do 
				If dblNyukoKeiSu > 0 Or Val(HKKET142F.txtSODADDSU.Text) = 0 Then
					Exit Do
				End If
				dblZoukaSu = dblZoukaSu + Val(HKKET142F.txtSODADDSU.Text)
				dblNyukoKeiSu = dblNyukoKeiSu + Val(HKKET142F.txtSODADDSU.Text)
			Loop 
			dblNyukoKeiSu = dblZoukaSu
			
		End If
		
		'//�ŏ��������Ɣ������������l���ɓ���ē��Ɍv�搔���v�Z����
		If Val(HKKET142F.txtSODADDSU.Text) = 0 Then
			'//�������������O�̏ꍇ
			dblZoukaCnt = 0
			
			'//�����P�ʂ����݂��Ȃ��̂ł��̂܂ܕԂ�
			Get_Hacyusu = dblNyukoKeiSu
		Else
			'//�������������O�Ŗ����ꍇ
			dblZoukaCnt = Int((dblNyukoKeiSu - Val(HKKET142F.txtMINSODSU.Text)) / Val(HKKET142F.txtSODADDSU.Text))
			
			'//�����P�ʐ؂�グ��
			'UPGRADE_WARNING: Mod �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			If (dblNyukoKeiSu - Val(HKKET142F.txtMINSODSU.Text)) Mod Val(HKKET142F.txtSODADDSU.Text) <> 0 Then
				dblZoukaCnt = dblZoukaCnt + 1
			End If
			
			'���Ɍv�搔      �ŏ������P��                  ������        ���������P�ʐ�
			Get_Hacyusu = Val(HKKET142F.txtMINSODSU.Text) + (dblZoukaCnt * Val(HKKET142F.txtSODADDSU.Text))
		End If
		
		''''    Get_Hacyusu = 0
		''''
		''''    If Val(HKKET142F.txtMINSODSU) = 0 Then
		''''        '//�ŏ������������݂��Ȃ��̂ł��̂܂ܕԂ�
		''''        Get_Hacyusu = dblNyukoKeiSu
		''''    End If
		''''
		''''    If dblNyukoKeiSu < Val(HKKET142F.txtMINSODSU) Then
		''''        '//�ŏ���������菬�����̂ōŏ��������ɂ���
		'''''        Get_Hacyusu = Val(HKKET142F.txtMINSODSU)
		''''        dblZoukaSu = Val(HKKET142F.txtMINSODSU)
		''''        dblNyukoKeiSu = dblNyukoKeiSu + Val(HKKET142F.txtMINSODSU)
		''''        Do
		''''            If dblNyukoKeiSu > 0 Then
		''''                Exit Do
		''''            End If
		''''            dblZoukaSu = dblZoukaSu + Val(HKKET142F.txtSODADDSU)
		''''            dblNyukoKeiSu = dblNyukoKeiSu + Val(HKKET142F.txtSODADDSU)
		''''        Loop
		''''        dblNyukoKeiSu = dblZoukaSu
		''''
		''''    End If
		''''
		''''    '//�ŏ��������Ɣ������������l���ɓ���ē��Ɍv�搔���v�Z����
		''''    If Val(HKKET142F.txtSODADDSU) = 0 Then
		''''        '//�������������O�̏ꍇ
		''''        dblZoukaCnt = 0
		''''
		''''        '//�����P�ʂ����݂��Ȃ��̂ł��̂܂ܕԂ�
		''''        Get_Hacyusu = dblNyukoKeiSu
		''''    Else
		''''        '//�������������O�Ŗ����ꍇ
		''''        dblZoukaCnt = Int((dblNyukoKeiSu - Val(HKKET142F.txtMINSODSU)) / Val(HKKET142F.txtSODADDSU))
		''''
		''''        '//�����P�ʐ؂�グ��
		''''        If (dblNyukoKeiSu - Val(HKKET142F.txtMINSODSU)) Mod Val(HKKET142F.txtSODADDSU) <> 0 Then
		''''            dblZoukaCnt = dblZoukaCnt + 1
		''''        End If
		''''
		''''        '���Ɍv�搔      �ŏ������P��                  ������        ���������P�ʐ�
		''''        Get_Hacyusu = Val(HKKET142F.txtMINSODSU) + (dblZoukaCnt * Val(HKKET142F.txtSODADDSU))
		''''    End If
		'// 2007/02/20 �� UPD
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'// 2007/01/09 �� ADD END
	
	'// 2007/01/09 �� ADD STR
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Set_YosokuGetumatu
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    �\�������݌ɂ����߂�
	'//*****************************************************************************************
	Public Function Set_YosokuGetumatu() As Boolean
		
		Const PROCEDURE As String = "Set_YosokuGetumatu"
		
		Dim lngZanEigyoHi As Integer
		Dim lngTouEigyoHi As Integer
		Dim dblMokuhyoChi As Double
		Dim dblZanHiAnbun As Double
		Dim dblSyukoYotei As Double
		Dim i As Short
		Dim j As Short
		
		Set_YosokuGetumatu = False
		
		On Error GoTo ONERR_STEP
		
		i = 0
		Do 
			'// 2007/11/27 REP START ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			'//        '//�����ȍ~�̂ݏ�������
			'//        If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
			'//
			'//           '//�ڕW�l�̎擾�i�����v��܂��͔N���v��(�������D��)�jtxtLMAHMS
			'//            If Trim(musrHKKTRA.strLMAHMS(i)) = "" Then
			'//                dblMokuhyoChi = Val(musrHKKTRA.strLMAHKS(i))
			'//            Else
			'//                dblMokuhyoChi = Val(musrHKKTRA.strLMAHMS(i))
			'//            End If
			'//
			'//            If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
			'//
			'//                '// << ��    �� >>
			'//
			'//                '//�o�ɗ\��
			'//                dblSyukoYotei = musrHKKZTRA.dblOUTTRA(i)
			'//
			'//                '//�c�c�Ɠ��̎擾
			'//                lngZanEigyoHi = Get_EigyoNisu(gvstrUNYDT, Mid(gvstrUNYDT, 1, 6) & "31")
			'//
			'//                '//�����c�Ɠ��̎擾
			'//                lngTouEigyoHi = Get_EigyoNisu(Mid(gvstrUNYDT, 1, 6) & "01", Mid(gvstrUNYDT, 1, 6) & "31")
			'//
			'//                '//�c�������l
			'//                If lngZanEigyoHi <= gvlngSyukaYoteiHikaku Then
			'//                    '//�c�������S���ȉ��̏ꍇ
			'//                    dblZanHiAnbun = 0
			'//                Else
			'//                    '//�o�ח\���r����������l�����߂�
			'//                    If dblSyukoYotei < Round(dblMokuhyoChi * gvlngSyukaYoteiHikaku / lngTouEigyoHi) Then
			'//                        '//�o�ɗ\�肪�ڕW�l�̂S�����𒴂��Ȃ��ꍇ
			'//                        dblZanHiAnbun = Round(dblMokuhyoChi * lngZanEigyoHi / lngTouEigyoHi)
			'//                    Else
			'//                        '//�o�ɗ\�肪�ڕW�l�̂S�����𒴂����ꍇ
			'//                        dblZanHiAnbun = Round(dblMokuhyoChi * (lngZanEigyoHi - gvlngSyukaYoteiHikaku) / lngTouEigyoHi)
			'//                    End If
			'//             End If
			'//
			'//'// 2007/01/28 �� ADD START
			'//                HKKET142F.txtZanHiAnbun = CStr(dblZanHiAnbun)
			'//                HKKET142F.txtZanDeAnbun = CStr(Round(dblMokuhyoChi * lngZanEigyoHi / lngTouEigyoHi))
			'//                HKKET142F.txtZAN = CStr(lngZanEigyoHi)
			'//                HKKET142F.txtZEN = CStr(lngTouEigyoHi)
			'//'// 2007/01/28 �� ADD END
			'//
			'//                '//�v�Z�F�\�������݌�(�����܂܂Ȃ�)
			'//                '//�\�������݌�:           ���ݍ݌ɐ�                        ���ɗ\��                    �o�ɗ\��@�@�@�@�@�@�@�@ �@�x���i�o��                 ���S�݌�                            �c�������l
			'//                musrHKKZTRA.dblYOSLST(i) = Val(HKKET142F.txtTOUZAISU.Text) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + CDbl(HKKET142F.txtANZZAISU.Text)) - dblZanHiAnbun
			'//
			'//                '//�v�Z�F�\�������݌�(�����܂�)
			'//                '//�\�������݌�:           ���ݍ݌ɐ�                         ���ɗ\��                   �o�ɗ\��@�@�@�@�@�@�@�@�@  �x���i�o��                 �����o�ɗ\��                 ���S�݌�                            �c�������l
			'//                musrHKKZTRA.dblMYOSLST(i) = Val(HKKET142F.txtTOUZAISU.Text) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + musrMKMTRA.dblMKMOUTTRA(i) + CDbl(HKKET142F.txtANZZAISU.Text)) - dblZanHiAnbun
			'//
			'//            Else
			'//
			'//                '// << �����ȍ~ >>
			'//
			'//                '// �v�Z�F�\�������݌�(�����܂܂Ȃ�)
			'//
			'//'// 2007/01/28 �� UPD START
			'//'                '//�\�������݌�:           �O���\�������݌�               ���ɗ\��                    ���S�݌�                            �ڕW�l
			'//'                musrHKKZTRA.dblYOSLST(i) = musrHKKZTRA.dblYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - (CDbl(HKKET142F.txtANZZAISU.Text)) - dblMokuhyoChi
			'//                '//�\�������݌�:           �O���\�������݌�               ���ɗ\��                   �ڕW�l
			'//                musrHKKZTRA.dblYOSLST(i) = musrHKKZTRA.dblYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi
			'//'// 2007/01/28 �� UPD END
			'//
			'//                '//�v�Z�F�\�������݌�(�����܂�)
			'//
			'//'// 2007/01/28 �� UPD START
			'//'                '//�\�������݌�:            �O���\�������݌�                ���ɗ\��                    �����o�ɗ\��                 ���S�݌�                            �ڕW�l
			'//'                musrHKKZTRA.dblMYOSLST(i) = musrHKKZTRA.dblMYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - (musrMKMTRA.dblMKMOUTTRA(i) + CDbl(HKKET142F.txtANZZAISU.Text)) - dblMokuhyoChi
			'//                '//�\�������݌�:            �O���\�������݌�                ���ɗ\��                    �����o�ɗ\��                 �ڕW�l
			'//                musrHKKZTRA.dblMYOSLST(i) = musrHKKZTRA.dblMYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - musrMKMTRA.dblMKMOUTTRA(i) - dblMokuhyoChi
			'//'// 2007/01/28 �� UPD END
			'//
			'//            End If
			'//
			'//        End If
			'// 2007/11/27 REP END ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			
			'//�����ȍ~�̂ݏ�������
			If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
				'//�ڕW�l�̎擾�i�����v��܂��͔N���v��(�������D��)�jtxtLMAHMS
				If Trim(musrHKKTRA.strLMAHMS(i)) = "" Then
					dblMokuhyoChi = Val(musrHKKTRA.strLMAHKS(i))
				Else
					dblMokuhyoChi = Val(musrHKKTRA.strLMAHMS(i))
				End If
				
				If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
					'//�y�����z
					dblSyukoYotei = musrHKKZTRA.dblOUTTRA(i) '//�o�ɗ\��
					lngZanEigyoHi = Get_EigyoNisu(gvstrUNYDT, Mid(gvstrUNYDT, 1, 6) & "31") '//�c�c�Ɠ��̎擾
					lngTouEigyoHi = Get_EigyoNisu(Mid(gvstrUNYDT, 1, 6) & "01", Mid(gvstrUNYDT, 1, 6) & "31") '//�����c�Ɠ��̎擾
					If lngZanEigyoHi <= gvlngSyukaYoteiHikaku Then '//�c�������l
						dblZanHiAnbun = 0 '//�c�������S���ȉ��̏ꍇ
					Else
						'//�o�ח\���r����������l�����߂�
						If dblSyukoYotei < System.Math.Round(dblMokuhyoChi * gvlngSyukaYoteiHikaku / lngTouEigyoHi) Then '//�o�ɗ\�肪�ڕW�l�̂S�����𒴂��Ȃ��ꍇ
							dblZanHiAnbun = System.Math.Round(dblMokuhyoChi * lngZanEigyoHi / lngTouEigyoHi)
						Else
							dblZanHiAnbun = System.Math.Round(dblMokuhyoChi * (lngZanEigyoHi - gvlngSyukaYoteiHikaku) / lngTouEigyoHi) '//�o�ɗ\�肪�ڕW�l�̂S�����𒴂����ꍇ
						End If
					End If
					
					HKKET142F.txtZanHiAnbun.Text = CStr(dblZanHiAnbun)
					HKKET142F.txtZanDeAnbun.Text = CStr(System.Math.Round(dblMokuhyoChi * lngZanEigyoHi / lngTouEigyoHi))
					HKKET142F.txtZAN.Text = CStr(lngZanEigyoHi)
					HKKET142F.txtZEN.Text = CStr(lngTouEigyoHi)
					
					'������͕�����ɗ\��Ƃ��Čv�Z����B
					
					'//�v�Z�F�\�������݌�(�����܂܂Ȃ�)
					'//�\�������݌�:           ���ݍ݌ɐ�                        ���ɗ\��                    �o�ɗ\��@�@�@�@�@ �@�@ �@ �x���i�o��                 ���S�݌�                            �c�������l    (���͓��Ɍv�� �| �O�����͓��Ɍv��)
					'// 2008/05/27 �� UPD STR ���Ɍv��(�A�g)�ɃX�y�[�X�����͂����ƃG���[����������
					'                musrHKKZTRA.dblYOSLST(i) = Val(HKKET142F.txtTOUZAISU.Text) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + CDbl(HKKET142F.txtANZZAISU.Text)) - dblZanHiAnbun + (musrODINTRA.strINPPLAN(i) - musrODINTRA.dblDspINPPLAN_ZEN(i))
					musrHKKZTRA.dblYOSLST(i) = Val(HKKET142F.txtTOUZAISU.Text) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + CDbl(HKKET142F.txtANZZAISU.Text)) - dblZanHiAnbun + (Val(musrODINTRA.strINPPLAN(i)) - musrODINTRA.dblDspINPPLAN_ZEN(i))
					'// 2008/05/27 �� UPD STR
					
					'//�v�Z�F�\�������݌�(�����܂�)
					'//�\�������݌�:           ���ݍ݌ɐ�                        ���ɗ\��                    �o�ɗ\��@�@�@�@�@�@�@�@�@  �x���i�o��                 �����o�ɗ\��                 ���S�݌�                            �c�������l    (���͓��Ɍv�� �| �O�����͓��Ɍv��)
					'// 2008/05/27 �� UPD STR ���Ɍv��(�A�g)�ɃX�y�[�X�����͂����ƃG���[����������
					'                musrHKKZTRA.dblMYOSLST(i) = Val(HKKET142F.txtTOUZAISU.Text) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + musrMKMTRA.dblMKMOUTTRA(i) + CDbl(HKKET142F.txtANZZAISU.Text)) - dblZanHiAnbun + (musrODINTRA.strINPPLAN(i) - musrODINTRA.dblDspINPPLAN_ZEN(i))
					musrHKKZTRA.dblMYOSLST(i) = Val(HKKET142F.txtTOUZAISU.Text) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + musrMKMTRA.dblMKMOUTTRA(i) + CDbl(HKKET142F.txtANZZAISU.Text)) - dblZanHiAnbun + (Val(musrODINTRA.strINPPLAN(i)) - musrODINTRA.dblDspINPPLAN_ZEN(i))
					'// 2008/05/27 �� UPD STR
				Else
					'// �y�����ȍ~�z
					'// �v�Z�F�\�������݌�(�����܂܂Ȃ�)
					
					'//�\�������݌�:           �O���\�������݌�               ���ɗ\��                   �ڕW�l         (���͓��Ɍv�� �| �O�����͓��Ɍv��)
					'// 2008/05/27 �� UPD STR ���Ɍv��(�A�g)�ɃX�y�[�X�����͂����ƃG���[����������
					'                musrHKKZTRA.dblYOSLST(i) = musrHKKZTRA.dblYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi + (musrODINTRA.strINPPLAN(i) - musrODINTRA.dblDspINPPLAN_ZEN(i))
					musrHKKZTRA.dblYOSLST(i) = musrHKKZTRA.dblYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi + (Val(musrODINTRA.strINPPLAN(i)) - musrODINTRA.dblDspINPPLAN_ZEN(i))
					'// 2008/05/27 �� UPD STR
					
					'//�v�Z�F�\�������݌�(�����܂�)
					
					'//�\�������݌�:            �O���\�������݌�                ���ɗ\��                    �����o�ɗ\��                 �ڕW�l          (���͓��Ɍv�� �| �O�����͓��Ɍv��)
					'// 2008/05/27 �� UPD STR ���Ɍv��(�A�g)�ɃX�y�[�X�����͂����ƃG���[����������
					'                musrHKKZTRA.dblMYOSLST(i) = musrHKKZTRA.dblMYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - musrMKMTRA.dblMKMOUTTRA(i) - dblMokuhyoChi + (musrODINTRA.strINPPLAN(i) - musrODINTRA.dblDspINPPLAN_ZEN(i))
					musrHKKZTRA.dblMYOSLST(i) = musrHKKZTRA.dblMYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - musrMKMTRA.dblMKMOUTTRA(i) - dblMokuhyoChi + (Val(musrODINTRA.strINPPLAN(i)) - musrODINTRA.dblDspINPPLAN_ZEN(i))
					'// 2008/05/27 �� UPD STR
				End If
			End If
			
			i = i + 1
			If i = 36 Then
				Exit Do
			End If
		Loop 
		
		Set_YosokuGetumatu = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'// 2007/01/09 �� ADD END
	
	'// 2007/01/09 �� ADD STR
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Get_EigyoNisu
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    �w�肳�ꂽ���Ԃ̉c�Ɠ������擾����
	'//*****************************************************************************************
	Public Function Get_EigyoNisu(ByVal strStart As String, ByVal strEnd As String) As Integer
		
		Const PROCEDURE As String = "Get_EigyoNisu"
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/04/15 DEL START
        'Dim objRec As OraDynaset
        '2019/04/15 DEL E N D

		On Error GoTo ONERR_STEP
		
		Get_EigyoNisu = 0
		
		' SQL���̍쐬
		strSQL = ""
		strSQL = strSQL & " SELECT COUNT(V1.SLSMDD) AS SLSMDD FROM " & vbCrLf
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & " (SELECT SLSMDD FROM CLDMTA WHERE CLDDT BETWEEN " & D0.Edt_SQL("S", strStart) & " AND " & D0.Edt_SQL("S", strEnd) & vbCrLf
		strSQL = strSQL & " GROUP BY SLSMDD) V1" & vbCrLf
		
		' �f�[�^�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'Get_EigyoNisu = D0.Chk_NullN(objRec("SLSMDD"))
        Get_EigyoNisu = D0.Chk_NullN(dt.Rows(0)("SLSMDD"))
        '2019/04/15 CHG E N D

		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCloseDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 DEL START
        'clsOra.OraCloseDyn(objRec)
        '2019/04/15 DEL E N D

		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'// 2007/01/09 �� ADD END
	
	'// 2007/01/09 �� ADD STR
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Get_FIXMTA
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    �\�������݌ɂ��v�Z����
	'//*****************************************************************************************
	Public Function Get_FIXMTA() As Boolean
		
		Const PROCEDURE As String = "Get_FIXMTA"
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim objRec As OraDynaset
		
		Get_FIXMTA = False
		
		On Error GoTo ONERR_STEP
		
		' SQL���̍쐬
		strSQL = ""
		strSQL = strSQL & "SELECT FIXVAL " & vbCrLf
		strSQL = strSQL & "FROM   FIXMTA " & vbCrLf
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "WHERE  CTLCD = " & D0.Edt_SQL("S", "402") & vbCrLf
		
		' �f�[�^�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'gvlngSyukaYoteiHikaku = D0.Chk_NullN(objRec("FIXVAL"))
        gvlngSyukaYoteiHikaku = D0.Chk_NullN(dt.Rows(0)("FIXVAL"))
        '2019/04/15 CHG E N D

		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCloseDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 DEL START
        'clsOra.OraCloseDyn(objRec)
        '2019/04/15 DEL E N D

		Get_FIXMTA = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'// 2007/01/09 �� ADD END
	
	'// 2007/01/09 �� ADD STR
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Get_LTKIKAN
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    ���[�h�^�C�����Ԃ̎Z�o���s��
	'//*****************************************************************************************
	Public Function Get_LTKIKAN() As Boolean
		
		Const PROCEDURE As String = "Get_LTKIKAN"
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/04/15 DEL START
        'Dim objRec As OraDynaset
        '2019/04/15 DEL E N D
        Dim dblSLSMDD As Double
		Dim i As Short
		
		Get_LTKIKAN = False
		
		On Error GoTo ONERR_STEP
		
		'// 2007/03/10 �� ADD ���BLT/����LT �� 0 �̎� �͉������Ȃ�
		If Val(HKKET142F.txtMNFDD.Text) = 0 And Val(HKKET142F.txtPRCCD.Text) = 0 Then
			Get_LTKIKAN = True
			GoTo EXIT_STEP
		End If
		'// 2007/03/10 �� ADD
		
		i = 0
		Do 
			If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
				
				'// 2007/12/20 �� LT����͗����P���Œ�
				'        If Trim(musrHKKTRA.strLMAPDT(i)) = "" Then
				'            musrHKKTRA.strLMAPDT(i) = musrHKKZTRA.strDSPMONTH(i) & "01"
				'        End If
				If Mid(musrHKKZTRA.strDSPMONTH(i), 5, 2) = "12" Then
					musrHKKTRA.strLMAPDT(i) = CDbl(musrHKKZTRA.strDSPMONTH(i)) + 89 & "01" '12�������N1��
				Else
					musrHKKTRA.strLMAPDT(i) = CDbl(musrHKKZTRA.strDSPMONTH(i)) + 1 & "01"
				End If
				'// 2007/12/20 �� LT����͗����P���Œ�
				
				'//SQL���̍쐬
				strSQL = ""
				strSQL = strSQL & "SELECT SLSMDD  " & vbCrLf
				strSQL = strSQL & "FROM   CLDMTA " & vbCrLf
				'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & "WHERE  CLDDT = " & D0.Edt_SQL("S", musrHKKTRA.strLMAPDT(i)) & vbCrLf
				
				'//�f�[�^�擾
				'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/15 CHG START
                'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
                '    GoTo EXIT_STEP
                'End If
                Dim dt As DataTable = DB_GetTable(strSQL)
                '2019/04/15 CHG E N D

				'//�k������Z�o(����LT)
				If Val(HKKET142F.txtMNFDD.Text) - 1 < 0 Then
					'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/15 CHG START
                    'dblSLSMDD = D0.Chk_NullN(objRec("SLSMDD"))
                    dblSLSMDD = D0.Chk_NullN(dt.Rows(0)("SLSMDD"))
                    '2019/04/15 CHG E N D
                Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/15 CHG START
                    'dblSLSMDD = D0.Chk_NullN(objRec("SLSMDD")) - (Val(HKKET142F.txtMNFDD.Text) * 5 - 1)
                    dblSLSMDD = D0.Chk_NullN(dt.Rows(0)("SLSMDD")) - (Val(HKKET142F.txtMNFDD.Text) * 5 - 1)
                    '2019/04/15 CHG E N D
                End If
				
				'//SQL���̍쐬
				strSQL = ""
				strSQL = strSQL & "SELECT CLDDT  " & vbCrLf
				strSQL = strSQL & "FROM   CLDMTA " & vbCrLf
				'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & "WHERE  SLSMDD = " & D0.Edt_SQL("N", dblSLSMDD) & vbCrLf
				strSQL = strSQL & " ORDER BY CLDWKKB DESC "
				
				'//�f�[�^�擾
				'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/15 CHG START
                'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
                '    GoTo EXIT_STEP
                'End If
                dt = Nothing
                dt = DB_GetTable(strSQL)
                '2019/04/15 CHG E N D

				'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'If D0.Chk_Null(objRec("CLDDT")) < gvstrUNYDT Then
                If D0.Chk_Null(dt.Rows(0)("CLDDT")) < gvstrUNYDT Then
                    musrHKKTRA.intLTKBN(i) = 1
                Else

                    '//�k������Z�o(���BLT)
                    If Val(HKKET142F.txtPRCCD.Text) - 1 < 0 Then
                        dblSLSMDD = dblSLSMDD
                    Else
                        dblSLSMDD = dblSLSMDD - (Val(HKKET142F.txtPRCCD.Text) * 5 - 1)
                    End If

                    '//SQL���̍쐬
                    strSQL = ""
                    strSQL = strSQL & "SELECT CLDDT  " & vbCrLf
                    strSQL = strSQL & "FROM   CLDMTA " & vbCrLf
                    'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strSQL = strSQL & "WHERE  SLSMDD = " & D0.Edt_SQL("N", dblSLSMDD) & vbCrLf
                    strSQL = strSQL & " ORDER BY CLDWKKB DESC "

                    '//�f�[�^�擾
                    'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/15 CHG START
                    'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
                    '    GoTo EXIT_STEP
                    'End If
                    dt = Nothing
                    dt = DB_GetTable(strSQL)
                    '2019/04/15 CHG E N D

                    'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/15 CHG START
                    'If D0.Chk_Null(objRec("CLDDT")) < gvstrUNYDT Then
                    If D0.Chk_Null(dt.Rows(0)("CLDDT")) < gvstrUNYDT Then
                        '2019/04/15 CHG E N D
                        musrHKKTRA.intLTKBN(i) = 2
                    End If

                End If

                '// 2007/02/12 �� ADD STR
                If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
                    If musrHKKTRA.intLTKBN(i) = 0 Then
                        musrHKKTRA.intLTKBN(i) = 1
                    End If
                End If
                '// 2007/02/12 �� ADD END

                '// 2008/05/21 �� ADD STR
                '// ����LT�E���BLT���ԂłȂ��������������̂ňȍ~�̌��͏������Ȃ�
                If musrHKKTRA.intLTKBN(i) = 0 Then
                    Exit Do
                End If
                '// 2008/05/21 �� ADD END

            End If

            i = i + 1
            If i = 36 Then
                Exit Do
            End If
        Loop
		
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCloseDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 DEL START
        'clsOra.OraCloseDyn(objRec)
        '2019/04/15 DEL E N D

		Get_LTKIKAN = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'// 2007/01/09 �� ADD END
	
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Get_HINMTA
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    ���i�}�X�^���擾����
	'//*****************************************************************************************
	Public Function Get_HINMTA() As Boolean
		
		Const PROCEDURE As String = "Get_HINMTA"
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim objRec As OraDynaset
		
		Get_HINMTA = False
		
		On Error GoTo ONERR_STEP
		
		' SQL���̍쐬
		strSQL = ""
		strSQL = strSQL & "SELECT *  " & vbCrLf
		strSQL = strSQL & "FROM   HINMTA " & vbCrLf
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD.Text) & vbCrLf
		
		' �f�[�^�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

		'//���i�}�X�^����ʂɕ\������
        '2019/04/15 CHG START
        'If Not Set_HINMTA(objRec) Then
        If Not Set_HINMTA(dt) Then
            '2019/04/15 CHG E N D
            GoTo EXIT_STEP
        End If

        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCloseDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 DEL START
        'clsOra.OraCloseDyn(objRec)
        '2019/04/15 DEL E N D

        Get_HINMTA = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Get_CLDMTA
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            String              �擾�l
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*            Index               Integer          I
	'//*
	'//* <��  ��>
	'//*    �J�����_�}�X�^���擾����
	'//*****************************************************************************************
	Public Function Get_CLDMTA(ByRef Index As Short) As String
		
		Const PROCEDURE As String = "Get_CLDMTA"
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/04/15 DEL START
        'Dim objRec As OraDynaset
        '2019/04/15 DEL E N D

		On Error GoTo ONERR_STEP
		
		' SQL���̍쐬
		strSQL = ""
		If Index = 1 Then
			strSQL = strSQL & "SELECT SLSMDD" & vbCrLf
			strSQL = strSQL & "FROM   CLDMTA " & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "WHERE  CLDDT = " & D0.Edt_SQL("S", gvstrUNYDT) & vbCrLf
		Else
			strSQL = strSQL & "SELECT NVL(TRIM(TO_CHAR(TO_DATE(MIN(CLDDT),'YYYY/MM/DD'),'YYYY/MM/DD')),'" & VB6.Format(gvstrUNYDT, "@@@@/@@/@@") & "')" & vbCrLf
			strSQL = strSQL & "FROM   CLDMTA " & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "WHERE  SLSMDD = " & D0.Edt_SQL("S", gvstrCalcDate) & vbCrLf
		End If
		
		' �f�[�^�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraEOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '2019/04/15 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/15 CHG START
            'Get_CLDMTA = D0.Chk_Null(objRec(0))
            Get_CLDMTA = D0.Chk_Null(dt.Rows(0)(0))
            '2019/04/15 CHG E N D
        End If

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Get_HKKZTRA_M
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    �̔��v��O���e���擾����
	'//*****************************************************************************************
	Public Function Get_HKKZTRA_M() As Boolean
		
		Const PROCEDURE As String = "Get_HKKZTRA_M"
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim objRec As OraDynaset
		Dim i As Short
		Dim j As Short
		
		Get_HKKZTRA_M = False
		
		On Error GoTo ONERR_STEP
		
		' SQL���̍쐬
		strSQL = ""
		strSQL = strSQL & "SELECT HINKTA, HINNMB, ZAIRNK,TOUZAISU ,MINSODSU ,SODADDSU ,ANZZAISU ,PRCDD, MNFDD ,LMAAVTS ,HINCM ,MEMO" & vbCrLf
		strSQL = strSQL & "FROM   HKKZTRA " & vbCrLf
		strSQL = strSQL & ",      HKKZTRB " & vbCrLf
		strSQL = strSQL & "WHERE HKKZTRA.HINCD = HKKZTRB.HINCD "
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'strSQL = strSQL & "  AND HKKZTRA.HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD) & vbCrLf
        strSQL = strSQL & "  AND HKKZTRA.HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD.Text) & vbCrLf
        '2019/04/12 CHG E N D

		' �f�[�^�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

		'//�̔��v��O���e����ʂɕ\������
        '2019/04/15 CHG START
        'If Not Set_HKKZTRA_M(objRec) Then
        If Not Set_HKKZTRA_M(dt) Then
            '2019/04/15 CHG E N D
            GoTo EXIT_STEP
        End If

        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCloseDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 DEL START
        'clsOra.OraCloseDyn(objRec)
        '2019/04/15 DEL E N D

        Get_HKKZTRA_M = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Get_HKKZTRA
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    �̔��v��O���e���擾����
	'//*****************************************************************************************
	Public Function Get_HKKZTRA() As Boolean
		
		Const PROCEDURE As String = "Get_HKKZTRA"
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/04/15 DEL START
        'Dim objRecA As OraDynaset
        '2019/04/15 DEL E N D
        'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/04/15 DEL START
        'Dim objRecB As OraDynaset
        '2019/04/15 DEL E N D
        'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/04/15 DEL START
        'Dim objRecC As OraDynaset
        '2019/04/15 DEL E N D
        Dim i As Short
		Dim j As Short
		
		Get_HKKZTRA = False
		
		On Error GoTo ONERR_STEP
		
		' SQL���̍쐬
		strSQL = ""
		strSQL = strSQL & "SELECT " & vbCrLf
		'//�O�N�\���N��(0�`11)
		strSQL = strSQL & "  LMZYMA, LMZYMB, LMZYMC, LMZYMD, LMZYME, LMZYMF, LMZYMG, LMZYMH, LMZYMI, LMZYMJ, LMZYMK, LMZYML" & vbCrLf
		'//���N�\���N��(11�`23)
		strSQL = strSQL & ", LMAYMA, LMAYMB, LMAYMC, LMAYMD, LMAYME, LMAYMF, LMAYMG, LMAYMH, LMAYMI, LMAYMJ, LMAYMK, LMAYML" & vbCrLf
		'//���N�\���N��(24�`35)
		strSQL = strSQL & ", LMBYMA, LMBYMB, LMBYMC, LMBYMD, LMBYME, LMBYMF, LMBYMG, LMBYMH, LMBYMI, LMBYMJ, LMBYMK, LMBYML" & vbCrLf
		'//�O�N���ɗ\�萔(36�`47)
		strSQL = strSQL & ", LMZNKYSA, LMZNKYSB, LMZNKYSC, LMZNKYSD, LMZNKYSE, LMZNKYSF, LMZNKYSG, LMZNKYSH, LMZNKYSI, LMZNKYSJ, LMZNKYSK, LMZNKYSL" & vbCrLf
		'//���N���ɗ\�萔(48�`59)
		strSQL = strSQL & ", LMANKYSA, LMANKYSB, LMANKYSC, LMANKYSD, LMANKYSE, LMANKYSF, LMANKYSG, LMANKYSH, LMANKYSI, LMANKYSJ, LMANKYSK, LMANKYSL" & vbCrLf
		'//���N���ɗ\�萔(60�`71)
		strSQL = strSQL & ", LMBNKYSA, LMBNKYSB, LMBNKYSC, LMBNKYSD, LMBNKYSE, LMBNKYSF, LMBNKYSG, LMBNKYSH, LMBNKYSI, LMBNKYSJ, LMBNKYSK, LMBNKYSL" & vbCrLf
		'//�O�N�o�ɗ\�萔(72�`83)
		strSQL = strSQL & ", LMZSKYSA, LMZSKYSB, LMZSKYSC, LMZSKYSD, LMZSKYSE, LMZSKYSF, LMZSKYSG, LMZSKYSH, LMZSKYSI, LMZSKYSJ, LMZSKYSK, LMZSKYSL" & vbCrLf
		'//���N�o�ɗ\�萔(84�`95)
		strSQL = strSQL & ", LMASKYSA, LMASKYSB, LMASKYSC, LMASKYSD, LMASKYSE, LMASKYSF, LMASKYSG, LMASKYSH, LMASKYSI, LMASKYSJ, LMASKYSK, LMASKYSL" & vbCrLf
		'//���N�o�ɗ\�萔(96�`107)
		strSQL = strSQL & ", LMBSKYSA, LMBSKYSB, LMBSKYSC, LMBSKYSD, LMBSKYSE, LMBSKYSF, LMBSKYSG, LMBSKYSH, LMBSKYSI, LMBSKYSJ, LMBSKYSK, LMBSKYSL" & vbCrLf
		'//�O�N�������E��(108�`119)
		strSQL = strSQL & ", LMZLDTA, LMZLDTB, LMZLDTC, LMZLDTD, LMZLDTE, LMZLDTF, LMZLDTG, LMZLDTH, LMZLDTI, LMZLDTJ, LMZLDTK, LMZLDTL" & vbCrLf
		'//���N�������E��(120�`131)
		strSQL = strSQL & ", LMALDTA, LMALDTB, LMALDTC, LMALDTD, LMALDTE, LMALDTF, LMALDTG, LMALDTH, LMALDTI, LMALDTJ, LMALDTK, LMALDTL" & vbCrLf
		'//���N�������E��(132�`143)
		strSQL = strSQL & ", LMBLDTA, LMBLDTB, LMBLDTC, LMBLDTD, LMBLDTE, LMBLDTF, LMBLDTG, LMBLDTH, LMBLDTI, LMBLDTJ, LMBLDTK, LMBLDTL" & vbCrLf
		'//�O�N�x���i�o�ɐ�(144�`155)
		strSQL = strSQL & ", LMZSKSSA, LMZSKSSB, LMZSKSSC, LMZSKSSD, LMZSKSSE, LMZSKSSF, LMZSKSSG, LMZSKSSH, LMZSKSSI, LMZSKSSJ, LMZSKSSK, LMZSKSSL" & vbCrLf
		'//���N�x���i�o�ɐ�(156�`167)
		strSQL = strSQL & ", LMASKSSA, LMASKSSB, LMASKSSC, LMASKSSD, LMASKSSE, LMASKSSF, LMASKSSG, LMASKSSH, LMASKSSI, LMASKSSJ, LMASKSSK, LMASKSSL" & vbCrLf
		'//���N�x���i�o�ɐ�(168�`179)
		strSQL = strSQL & ", LMBSKSSA, LMBSKSSB, LMBSKSSC, LMBSKSSD, LMBSKSSE, LMBSKSSF, LMBSKSSG, LMBSKSSH, LMBSKSSI, LMBSKSSJ, LMBSKSSK, LMBSKSSL" & vbCrLf
		'//�O�N�ً}�����ϐ�(180�`191)
		strSQL = strSQL & ", LMZKODSA, LMZKODSB, LMZKODSC, LMZKODSD, LMZKODSE, LMZKODSF, LMZKODSG, LMZKODSH, LMZKODSI, LMZKODSJ, LMZKODSK, LMZKODSL" & vbCrLf
		'//���N�ً}�����ϐ�(192�`203)
		strSQL = strSQL & ", LMAKODSA, LMAKODSB, LMAKODSC, LMAKODSD, LMAKODSE, LMAKODSF, LMAKODSG, LMAKODSH, LMAKODSI, LMAKODSJ, LMAKODSK, LMAKODSL" & vbCrLf
		'//���N�ً}�����ϐ�(204�`215)
		strSQL = strSQL & ", LMBKODSA, LMBKODSB, LMBKODSC, LMBKODSD, LMBKODSE, LMBKODSF, LMBKODSG, LMBKODSH, LMBKODSI, LMBKODSJ, LMBKODSK, LMBKODSL" & vbCrLf
		'//�O�N���Ɏw���ϐ�(216�`227)
		strSQL = strSQL & ", LMZNOSSA, LMZNOSSB, LMZNOSSC, LMZNOSSD, LMZNOSSE, LMZNOSSF, LMZNOSSG, LMZNOSSH, LMZNOSSI, LMZNOSSJ, LMZNOSSK, LMZNOSSL" & vbCrLf
		'//���N���Ɏw���ϐ�(228�`239)
		strSQL = strSQL & ", LMANOSSA, LMANOSSB, LMANOSSC, LMANOSSD, LMANOSSE, LMANOSSF, LMANOSSG, LMANOSSH, LMANOSSI, LMANOSSJ, LMANOSSK, LMANOSSL" & vbCrLf
		'//���N���Ɏw���ϐ�(240�`251)
		strSQL = strSQL & ", LMBNOSSA, LMBNOSSB, LMBNOSSC, LMBNOSSD, LMBNOSSE, LMBNOSSF, LMBNOSSG, LMBNOSSH, LMBNOSSI, LMBNOSSJ, LMBNOSSK, LMBNOSSL" & vbCrLf
		'//�O�N�����ϐ�(252�`263)
		strSQL = strSQL & ", LMZODSSA, LMZODSSB, LMZODSSC, LMZODSSD, LMZODSSE, LMZODSSF, LMZODSSG, LMZODSSH, LMZODSSI, LMZODSSJ, LMZODSSK, LMZODSSL" & vbCrLf
		'//���N�����ϐ�(264�`275)
		strSQL = strSQL & ", LMAODSSA, LMAODSSB, LMAODSSC, LMAODSSD, LMAODSSE, LMAODSSF, LMAODSSG, LMAODSSH, LMAODSSI, LMAODSSJ, LMAODSSK, LMAODSSL" & vbCrLf
		'//���N�����ϐ�(276�`287)
		strSQL = strSQL & ", LMBODSSA, LMBODSSB, LMBODSSC, LMBODSSD, LMBODSSE, LMBODSSF, LMBODSSG, LMBODSSH, LMBODSSI, LMBODSSJ, LMBODSSK, LMBODSSL" & vbCrLf
		'//�O�N�󒍐�(288�`299)
		strSQL = strSQL & ", LMZJYSA, LMZJYSB, LMZJYSC, LMZJYSD, LMZJYSE, LMZJYSF, LMZJYSG, LMZJYSH, LMZJYSI, LMZJYSJ, LMZJYSK, LMZJYSL" & vbCrLf
		'//���N�󒍐�(300�`311)
		strSQL = strSQL & ", LMAJYSA, LMAJYSB, LMAJYSC, LMAJYSD, LMAJYSE, LMAJYSF, LMAJYSG, LMAJYSH, LMAJYSI, LMAJYSJ, LMAJYSK, LMAJYSL" & vbCrLf
		'//���N�󒍐�(312�`323)
		strSQL = strSQL & ", LMBJYSA, LMBJYSB, LMBJYSC, LMBJYSD, LMBJYSE, LMBJYSF, LMBJYSG, LMBJYSH, LMBJYSI, LMBJYSJ, LMBJYSK, LMBJYSL" & vbCrLf
		'//�O�N���㐔(324�`335)
		strSQL = strSQL & ", LMZURSA, LMZURSB, LMZURSC, LMZURSD, LMZURSE, LMZURSF, LMZURSG, LMZURSH, LMZURSI, LMZURSJ, LMZURSK, LMZURSL" & vbCrLf
		'//���N���㐔(336�`347)
		strSQL = strSQL & ", LMAURSA, LMAURSB, LMAURSC, LMAURSD, LMAURSE, LMAURSF, LMAURSG, LMAURSH, LMAURSI, LMAURSJ, LMAURSK, LMAURSL" & vbCrLf
		'//���N���㐔(348�`359)
		strSQL = strSQL & ", LMBURSA, LMBURSB, LMBURSC, LMBURSD, LMBURSE, LMBURSF, LMBURSG, LMBURSH, LMBURSI, LMBURSJ, LMBURSK, LMBURSL" & vbCrLf
		'//�O�N���Ɏ��ѐ�(360�`371)
		strSQL = strSQL & ", LMZNKJSA, LMZNKJSB, LMZNKJSC, LMZNKJSD, LMZNKJSE, LMZNKJSF, LMZNKJSG, LMZNKJSH, LMZNKJSI, LMZNKJSJ, LMZNKJSK, LMZNKJSL" & vbCrLf
		'//���N���Ɏ��ѐ�(372�`383)
		strSQL = strSQL & ", LMANKJSA, LMANKJSB, LMANKJSC, LMANKJSD, LMANKJSE, LMANKJSF, LMANKJSG, LMANKJSH, LMANKJSI, LMANKJSJ, LMANKJSK, LMANKJSL" & vbCrLf
		'//���N���Ɏ��ѐ�(384�`395)
		strSQL = strSQL & ", LMBNKJSA, LMBNKJSB, LMBNKJSC, LMBNKJSD, LMBNKJSE, LMBNKJSF, LMBNKJSG, LMBNKJSH, LMBNKJSI, LMBNKJSJ, LMBNKJSK, LMBNKJSL" & vbCrLf
		'//�O�N�o�Ɏ��ѐ�(396�`407)
		strSQL = strSQL & ", LMZSKJSA, LMZSKJSB, LMZSKJSC, LMZSKJSD, LMZSKJSE, LMZSKJSF, LMZSKJSG, LMZSKJSH, LMZSKJSI, LMZSKJSJ, LMZSKJSK, LMZSKJSL" & vbCrLf
		'//���N�o�Ɏ��ѐ�(408�`419)
		strSQL = strSQL & ", LMASKJSA, LMASKJSB, LMASKJSC, LMASKJSD, LMASKJSE, LMASKJSF, LMASKJSG, LMASKJSH, LMASKJSI, LMASKJSJ, LMASKJSK, LMASKJSL" & vbCrLf
		'//���N�o�Ɏ��ѐ�(420�`431)
		strSQL = strSQL & ", LMBSKJSA, LMBSKJSB, LMBSKJSC, LMBSKJSD, LMBSKJSE, LMBSKJSF, LMBSKJSG, LMBSKJSH, LMBSKJSI, LMBSKJSJ, LMBSKJSK, LMBSKJSL" & vbCrLf
		'//�O�N�������ѐ�(432�`443)
		strSQL = strSQL & ", LMZODJSA, LMZODJSB, LMZODJSC, LMZODJSD, LMZODJSE, LMZODJSF, LMZODJSG, LMZODJSH, LMZODJSI, LMZODJSJ, LMZODJSK, LMZODJSL" & vbCrLf
		'//���N�������ѐ�(444�`455)
		strSQL = strSQL & ", LMAODJSA, LMAODJSB, LMAODJSC, LMAODJSD, LMAODJSE, LMAODJSF, LMAODJSG, LMAODJSH, LMAODJSI, LMAODJSJ, LMAODJSK, LMAODJSL" & vbCrLf
		'//���N�������ѐ�(456�`467)
		strSQL = strSQL & ", LMBODJSA, LMBODJSB, LMBODJSC, LMBODJSD, LMBODJSE, LMBODJSF, LMBODJSG, LMBODJSH, LMBODJSI, LMBODJSJ, LMBODJSK, LMBODJSL" & vbCrLf
		'//�O�N�����݌ɐ�(468�`479)
		strSQL = strSQL & ", LMZZAISA, LMZZAISB, LMZZAISC, LMZZAISD, LMZZAISE, LMZZAISF, LMZZAISG, LMZZAISH, LMZZAISI, LMZZAISJ, LMZZAISK, LMZZAISL" & vbCrLf
		'//���N�����݌ɐ�(480�`491)
		strSQL = strSQL & ", LMAZAISA, LMAZAISB, LMAZAISC, LMAZAISD, LMAZAISE, LMAZAISF, LMAZAISG, LMAZAISH, LMAZAISI, LMAZAISJ, LMAZAISK, LMAZAISL" & vbCrLf
		'//���N�����݌ɐ�(492�`503)
		strSQL = strSQL & ", LMBZAISA, LMBZAISB, LMBZAISC, LMBZAISD, LMBZAISE, LMBZAISF, LMBZAISG, LMBZAISH, LMBZAISI, LMBZAISJ, LMBZAISK, LMBZAISL" & vbCrLf
		'//�O�N���������݌ɐ�(504�`515)
		strSQL = strSQL & ", LMZMKZSA, LMZMKZSB, LMZMKZSC, LMZMKZSD, LMZMKZSE, LMZMKZSF, LMZMKZSG, LMZMKZSH, LMZMKZSI, LMZMKZSJ, LMZMKZSK, LMZMKZSL" & vbCrLf
		'//���N���������݌ɐ�(516�`527)
		strSQL = strSQL & ", LMAMKZSA, LMAMKZSB, LMAMKZSC, LMAMKZSD, LMAMKZSE, LMAMKZSF, LMAMKZSG, LMAMKZSH, LMAMKZSI, LMAMKZSJ, LMAMKZSK, LMAMKZSL" & vbCrLf
		'//���N���������݌ɐ�(528�`539)
		strSQL = strSQL & ", LMBMKZSA, LMBMKZSB, LMBMKZSC, LMBMKZSD, LMBMKZSE, LMBMKZSF, LMBMKZSG, LMBMKZSH, LMBMKZSI, LMBMKZSJ, LMBMKZSK, LMBMKZSL" & vbCrLf
		'//�O�N�������ϐ�(540�`551)
		strSQL = strSQL & ", LMZMMSA, LMZMMSB, LMZMMSC, LMZMMSD, LMZMMSE, LMZMMSF, LMZMMSG, LMZMMSH, LMZMMSI, LMZMMSJ, LMZMMSK, LMZMMSL" & vbCrLf
		'//���N�������ϐ�(552�`563)
		strSQL = strSQL & ", LMAMMSA, LMAMMSB, LMAMMSC, LMAMMSD, LMAMMSE, LMAMMSF, LMAMMSG, LMAMMSH, LMAMMSI, LMAMMSJ, LMAMMSK, LMAMMSL" & vbCrLf
		'//���N�������ϐ�(564�`575)
		strSQL = strSQL & ", LMBMMSA, LMBMMSB, LMBMMSC, LMBMMSD, LMBMMSE, LMBMMSF, LMBMMSG, LMBMMSH, LMBMMSI, LMBMMSJ, LMBMMSK, LMBMMSL" & vbCrLf
		'//�O�N�����o�ɗ\�萔(576�`587)
		strSQL = strSQL & ", LMZMSSA, LMZMSSB, LMZMSSC, LMZMSSD, LMZMSSE, LMZMSSF, LMZMSSG, LMZMSSH, LMZMSSI, LMZMSSJ, LMZMSSK, LMZMSSL" & vbCrLf
		'//���N�����o�ɗ\�萔(588�`599)
		strSQL = strSQL & ", LMAMSSA, LMAMSSB, LMAMSSC, LMAMSSD, LMAMSSE, LMAMSSF, LMAMSSG, LMAMSSH, LMAMSSI, LMAMSSJ, LMAMSSK, LMAMSSL" & vbCrLf
		'//���N�����o�ɗ\�萔(600�`611)
		strSQL = strSQL & ", LMBMSSA, LMBMSSB, LMBMSSC, LMBMSSD, LMBMSSE, LMBMSSF, LMBMSSG, LMBMSSH, LMBMSSI, LMBMSSJ, LMBMSSK, LMBMSSL" & vbCrLf
		'//�O�N�o�ɗ\��v�搔(612�`623)
		strSQL = strSQL & ", LMZSKKSA, LMZSKKSB, LMZSKKSC, LMZSKKSD, LMZSKKSE, LMZSKKSF, LMZSKKSG, LMZSKKSH, LMZSKKSI, LMZSKKSJ, LMZSKKSK, LMZSKKSL" & vbCrLf
		'//���N�o�ɗ\��v�搔(624�`635)
		strSQL = strSQL & ", LMASKKSA, LMASKKSB, LMASKKSC, LMASKKSD, LMASKKSE, LMASKKSF, LMASKKSG, LMASKKSH, LMASKKSI, LMASKKSJ, LMASKKSK, LMASKKSL" & vbCrLf
		'//���N�o�ɗ\��v�搔(636�`647)
		strSQL = strSQL & ", LMBSKKSA, LMBSKKSB, LMBSKKSC, LMBSKKSD, LMBSKKSE, LMBSKKSF, LMBSKKSG, LMBSKKSH, LMBSKKSI, LMBSKKSJ, LMBSKKSK, LMBSKKSL" & vbCrLf
		strSQL = strSQL & "FROM   HKKZTRA " & vbCrLf
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD) & vbCrLf
        strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD.Text) & vbCrLf
        '2019/04/12 CHG E N D

		' �f�[�^�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRecA, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dtHKKZTRA As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

		' SQL���̍쐬
		strSQL = ""
		strSQL = strSQL & "SELECT " & vbCrLf
		'//�O�N�݌ɐ؂�}�[�N(0�`11)
		strSQL = strSQL & "  LMZZKMA, LMZZKMB, LMZZKMC, LMZZKMD, LMZZKME, LMZZKMF, LMZZKMG, LMZZKMH, LMZZKMI, LMZZKMJ, LMZZKMK, LMZZKML" & vbCrLf
		'//���N�݌ɐ؂�}�[�N(12�`23)
		strSQL = strSQL & ", LMAZKMA, LMAZKMB, LMAZKMC, LMAZKMD, LMAZKME, LMAZKMF, LMAZKMG, LMAZKMH, LMAZKMI, LMAZKMJ, LMAZKMK, LMAZKML" & vbCrLf
		'//���N�݌ɐ؂�}�[�N(24�`35)
		strSQL = strSQL & ", LMBZKMA, LMBZKMB, LMBZKMC, LMBZKMD, LMBZKME, LMBZKMF, LMBZKMG, LMBZKMH, LMBZKMI, LMBZKMJ, LMBZKMK, LMBZKML" & vbCrLf
		'//�O�N���S�݌ɐ؂�}�[�N(36�`47)
		strSQL = strSQL & ", LMZAZMA, LMZAZMB, LMZAZMC, LMZAZMD, LMZAZME, LMZAZMF, LMZAZMG, LMZAZMH, LMZAZMI, LMZAZMJ, LMZAZMK, LMZAZML" & vbCrLf
		'//���N���S�݌ɐ؂�}�[�N(48�`59)
		strSQL = strSQL & ", LMAAZMA, LMAAZMB, LMAAZMC, LMAAZMD, LMAAZME, LMAAZMF, LMAAZMG, LMAAZMH, LMAAZMI, LMAAZMJ, LMAAZMK, LMAAZML" & vbCrLf
		'//���N���S�݌ɐ؂�}�[�N(60�`71)
		strSQL = strSQL & ", LMBAZMA, LMBAZMB, LMBAZMC, LMBAZMD, LMBAZME, LMBAZMF, LMBAZMG, LMBAZMH, LMBAZMI, LMBAZMJ, LMBAZMK, LMBAZML" & vbCrLf
		'//�O�N�����݌ɐ؂�}�[�N(72�`83)
		strSQL = strSQL & ", LMZMZKMA, LMZMZKMB, LMZMZKMC, LMZMZKMD, LMZMZKME, LMZMZKMF, LMZMZKMG, LMZMZKMH, LMZMZKMI, LMZMZKMJ, LMZMZKMK, LMZMZKML" & vbCrLf
		'//���N�����݌ɐ؂�}�[�N(84�`95)
		strSQL = strSQL & ", LMAMZKMA, LMAMZKMB, LMAMZKMC, LMAMZKMD, LMAMZKME, LMAMZKMF, LMAMZKMG, LMAMZKMH, LMAMZKMI, LMAMZKMJ, LMAMZKMK, LMAMZKML" & vbCrLf
		'//���N�����݌ɐ؂�}�[�N(96�`107)
		strSQL = strSQL & ", LMBMZKMA, LMBMZKMB, LMBMZKMC, LMBMZKMD, LMBMZKME, LMBMZKMF, LMBMZKMG, LMBMZKMH, LMBMZKMI, LMBMZKMJ, LMBMZKMK, LMBMZKML" & vbCrLf
		'//�O�N�������S�݌ɐ؂�}�[�N(108�`119)
		strSQL = strSQL & ", LMZMAZMA, LMZMAZMB, LMZMAZMC, LMZMAZMD, LMZMAZME, LMZMAZMF, LMZMAZMG, LMZMAZMH, LMZMAZMI, LMZMAZMJ, LMZMAZMK, LMZMAZML" & vbCrLf
		'//���N�������S�݌ɐ؂�}�[�N(120�`131)
		strSQL = strSQL & ", LMAMAZMA, LMAMAZMB, LMAMAZMC, LMAMAZMD, LMAMAZME, LMAMAZMF, LMAMAZMG, LMAMAZMH, LMAMAZMI, LMAMAZMJ, LMAMAZMK, LMAMAZML" & vbCrLf
		'//���N�������S�݌ɐ؂�}�[�N(132�`143)
		strSQL = strSQL & ", LMBMAZMA, LMBMAZMB, LMBMAZMC, LMBMAZMD, LMBMAZME, LMBMAZMF, LMBMAZMG, LMBMAZMH, LMBMAZMI, LMBMAZMJ, LMBMAZMK, LMBMAZML" & vbCrLf
		'//�O�N�݌ɐ؂ꐔ(144�`155)
		strSQL = strSQL & ", LMZZKSA, LMZZKSB, LMZZKSC, LMZZKSD, LMZZKSE, LMZZKSF, LMZZKSG, LMZZKSH, LMZZKSI, LMZZKSJ, LMZZKSK, LMZZKSL" & vbCrLf
		'//���N�݌ɐ؂ꐔ(156�`167)
		strSQL = strSQL & ", LMAZKSA, LMAZKSB, LMAZKSC, LMAZKSD, LMAZKSE, LMAZKSF, LMAZKSG, LMAZKSH, LMAZKSI, LMAZKSJ, LMAZKSK, LMAZKSL" & vbCrLf
		'//���N�݌ɐ؂ꐔ(168�`179)
		strSQL = strSQL & ", LMBZKSA, LMBZKSB, LMBZKSC, LMBZKSD, LMBZKSE, LMBZKSF, LMBZKSG, LMBZKSH, LMBZKSI, LMBZKSJ, LMBZKSK, LMBZKSL" & vbCrLf
		'//�O�N���S�݌ɐ؂ꐔ(180�`191)
		strSQL = strSQL & ", LMZAZSA, LMZAZSB, LMZAZSC, LMZAZSD, LMZAZSE, LMZAZSF, LMZAZSG, LMZAZSH, LMZAZSI, LMZAZSJ, LMZAZSK, LMZAZSL" & vbCrLf
		'//���N���S�݌ɐ؂ꐔ(192�`203)
		strSQL = strSQL & ", LMAAZSA, LMAAZSB, LMAAZSC, LMAAZSD, LMAAZSE, LMAAZSF, LMAAZSG, LMAAZSH, LMAAZSI, LMAAZSJ, LMAAZSK, LMAAZSL" & vbCrLf
		'//���N���S�݌ɐ؂ꐔ(204�`215)
		strSQL = strSQL & ", LMBAZSA, LMBAZSB, LMBAZSC, LMBAZSD, LMBAZSE, LMBAZSF, LMBAZSG, LMBAZSH, LMBAZSI, LMBAZSJ, LMBAZSK, LMBAZSL" & vbCrLf
		'//�O�N�����݌ɐ؂ꐔ(216�`227)
		strSQL = strSQL & ", LMZMZKSA, LMZMZKSB, LMZMZKSC, LMZMZKSD, LMZMZKSE, LMZMZKSF, LMZMZKSG, LMZMZKSH, LMZMZKSI, LMZMZKSJ, LMZMZKSK, LMZMZKSL" & vbCrLf
		'//���N�����݌ɐ؂ꐔ(228�`239)
		strSQL = strSQL & ", LMAMZKSA, LMAMZKSB, LMAMZKSC, LMAMZKSD, LMAMZKSE, LMAMZKSF, LMAMZKSG, LMAMZKSH, LMAMZKSI, LMAMZKSJ, LMAMZKSK, LMAMZKSL" & vbCrLf
		'//���N�����݌ɐ؂ꐔ(240�`251)
		strSQL = strSQL & ", LMBMZKSA, LMBMZKSB, LMBMZKSC, LMBMZKSD, LMBMZKSE, LMBMZKSF, LMBMZKSG, LMBMZKSH, LMBMZKSI, LMBMZKSJ, LMBMZKSK, LMBMZKSL" & vbCrLf
		'//�O�N�������S�݌ɐ؂ꐔ(252�`263)
		strSQL = strSQL & ", LMZMAZSA, LMZMAZSB, LMZMAZSC, LMZMAZSD, LMZMAZSE, LMZMAZSF, LMZMAZSG, LMZMAZSH, LMZMAZSI, LMZMAZSJ, LMZMAZSK, LMZMAZSL" & vbCrLf
		'//���N�������S�݌ɐ؂ꐔ(264�`275)
		strSQL = strSQL & ", LMAMAZSA, LMAMAZSB, LMAMAZSC, LMAMAZSD, LMAMAZSE, LMAMAZSF, LMAMAZSG, LMAMAZSH, LMAMAZSI, LMAMAZSJ, LMAMAZSK, LMAMAZSL" & vbCrLf
		'//���N�������S�݌ɐ؂ꐔ(276�`287)
		strSQL = strSQL & ", LMBMAZSA, LMBMAZSB, LMBMAZSC, LMBMAZSD, LMBMAZSE, LMBMAZSF, LMBMAZSG, LMBMAZSH, LMBMAZSI, LMBMAZSJ, LMBMAZSK, LMBMAZSL" & vbCrLf
		'//�O�N������(288�`299)
		strSQL = strSQL & ", LMZHDTA, LMZHDTB, LMZHDTC, LMZHDTD, LMZHDTE, LMZHDTF, LMZHDTG, LMZHDTH, LMZHDTI, LMZHDTJ, LMZHDTK, LMZHDTL" & vbCrLf
		'//���N������(300�`311)
		strSQL = strSQL & ", LMAHDTA, LMAHDTB, LMAHDTC, LMAHDTD, LMAHDTE, LMAHDTF, LMAHDTG, LMAHDTH, LMAHDTI, LMAHDTJ, LMAHDTK, LMAHDTL" & vbCrLf
		'//���N������(312�`323)
		strSQL = strSQL & ", LMBHDTA, LMBHDTB, LMBHDTC, LMBHDTD, LMBHDTE, LMBHDTF, LMBHDTG, LMBHDTH, LMBHDTI, LMBHDTJ, LMBHDTK, LMBHDTL" & vbCrLf
		'//�O�N�݌Ɍ���(324�`335)
		strSQL = strSQL & ", LMZZKTA, LMZZKTB, LMZZKTC, LMZZKTD, LMZZKTE, LMZZKTF, LMZZKTG, LMZZKTH, LMZZKTI, LMZZKTJ, LMZZKTK, LMZZKTL" & vbCrLf
		'//���N�݌Ɍ���(336�`347)
		strSQL = strSQL & ", LMAZKTA, LMAZKTB, LMAZKTC, LMAZKTD, LMAZKTE, LMAZKTF, LMAZKTG, LMAZKTH, LMAZKTI, LMAZKTJ, LMAZKTK, LMAZKTL" & vbCrLf
		'//���N�݌Ɍ���(348�`359)
		strSQL = strSQL & ", LMBZKTA, LMBZKTB, LMBZKTC, LMBZKTD, LMBZKTE, LMBZKTF, LMBZKTG, LMBZKTH, LMBZKTI, LMBZKTJ, LMBZKTK, LMBZKTL" & vbCrLf
		'//�O�N�����݌Ɍ���(360�`371)
		strSQL = strSQL & ", LMZMZKTA, LMZMZKTB, LMZMZKTC, LMZMZKTD, LMZMZKTE, LMZMZKTF, LMZMZKTG, LMZMZKTH, LMZMZKTI, LMZMZKTJ, LMZMZKTK, LMZMZKTL" & vbCrLf
		'//���N�����݌Ɍ���(372�`383)
		strSQL = strSQL & ", LMAMZKTA, LMAMZKTB, LMAMZKTC, LMAMZKTD, LMAMZKTE, LMAMZKTF, LMAMZKTG, LMAMZKTH, LMAMZKTI, LMAMZKTJ, LMAMZKTK, LMAMZKTL" & vbCrLf
		'//���N�����݌Ɍ���(384�`395)
		strSQL = strSQL & ", LMBMZKTA, LMBMZKTB, LMBMZKTC, LMBMZKTD, LMBMZKTE, LMBMZKTF, LMBMZKTG, LMBMZKTH, LMBMZKTI, LMBMZKTJ, LMBMZKTK, LMBMZKTL" & vbCrLf
		'//�O�N���Ϗo�ɐ�(�O��)(396�`407)
		strSQL = strSQL & ", LMZAVZSA, LMZAVZSB, LMZAVZSC, LMZAVZSD, LMZAVZSE, LMZAVZSF, LMZAVZSG, LMZAVZSH, LMZAVZSI, LMZAVZSJ, LMZAVZSK, LMZAVZSL" & vbCrLf
		'//���N���Ϗo�ɐ�(�O��)(408�`419)
		strSQL = strSQL & ", LMAAVZSA, LMAAVZSB, LMAAVZSC, LMAAVZSD, LMAAVZSE, LMAAVZSF, LMAAVZSG, LMAAVZSH, LMAAVZSI, LMAAVZSJ, LMAAVZSK, LMAAVZSL" & vbCrLf
		'//���N���Ϗo�ɐ�(�O��)(420�`431)
		strSQL = strSQL & ", LMBAVZSA, LMBAVZSB, LMBAVZSC, LMBAVZSD, LMBAVZSE, LMBAVZSF, LMBAVZSG, LMBAVZSH, LMBAVZSI, LMBAVZSJ, LMBAVZSK, LMBAVZSL" & vbCrLf
		'//�O�N�����Č���(432�`443)
		strSQL = strSQL & ", LMZMASA, LMZMASB, LMZMASC, LMZMASD, LMZMASE, LMZMASF, LMZMASG, LMZMASH, LMZMASI, LMZMASJ, LMZMASK, LMZMASL" & vbCrLf
		'//���N�����Č���(444�`455)
		strSQL = strSQL & ", LMAMASA, LMAMASB, LMAMASC, LMAMASD, LMAMASE, LMAMASF, LMAMASG, LMAMASH, LMAMASI, LMAMASJ, LMAMASK, LMAMASL" & vbCrLf
		'//���N�����Č���(456�`467)
		strSQL = strSQL & ", LMBMASA, LMBMASB, LMBMASC, LMBMASD, LMBMASE, LMBMASF, LMBMASG, LMBMASH, LMBMASI, LMBMASJ, LMBMASK, LMBMASL" & vbCrLf
		'//�O�N�����o�ɗ\�萔(468�`479)
		strSQL = strSQL & ", LMZMASSA, LMZMASSB, LMZMASSC, LMZMASSD, LMZMASSE, LMZMASSF, LMZMASSG, LMZMASSH, LMZMASSI, LMZMASSJ, LMZMASSK, LMZMASSL" & vbCrLf
		'//���N�����o�ɗ\�萔(480�`491)
		strSQL = strSQL & ", LMAMASSA, LMAMASSB, LMAMASSC, LMAMASSD, LMAMASSE, LMAMASSF, LMAMASSG, LMAMASSH, LMAMASSI, LMAMASSJ, LMAMASSK, LMAMASSL" & vbCrLf
		'//���N�����o�ɗ\�萔(492�`503)
		strSQL = strSQL & ", LMBMASSA, LMBMASSB, LMBMASSC, LMBMASSD, LMBMASSE, LMBMASSF, LMBMASSG, LMBMASSH, LMBMASSI, LMBMASSJ, LMBMASSK, LMBMASSL" & vbCrLf
		'// 2007/01/09 �� ADD STR
		'//�O�N�\�������݌ɐ���(504�`515)
		strSQL = strSQL & ", LMZYGZSA, LMZYGZSB, LMZYGZSC, LMZYGZSD, LMZYGZSE, LMZYGZSF, LMZYGZSG, LMZYGZSH, LMZYGZSI, LMZYGZSJ, LMZYGZSK, LMZYGZSL" & vbCrLf
		'//���N�\�������݌ɐ���(516�`527)
		strSQL = strSQL & ", LMAYGZSA, LMAYGZSB, LMAYGZSC, LMAYGZSD, LMAYGZSE, LMAYGZSF, LMAYGZSG, LMAYGZSH, LMAYGZSI, LMAYGZSJ, LMAYGZSK, LMAYGZSL" & vbCrLf
		'//���N�\�������݌ɐ���(516�`539)
		strSQL = strSQL & ", LMBYGZSA, LMBYGZSB, LMBYGZSC, LMBYGZSD, LMBYGZSE, LMBYGZSF, LMBYGZSG, LMBYGZSH, LMBYGZSI, LMBYGZSJ, LMBYGZSK, LMBYGZSL" & vbCrLf
		'//�O�N�����\�������݌ɐ���(540�`551)
		strSQL = strSQL & ", LMZMYGZA, LMZMYGZB, LMZMYGZC, LMZMYGZD, LMZMYGZE, LMZMYGZF, LMZMYGZG, LMZMYGZH, LMZMYGZI, LMZMYGZJ, LMZMYGZK, LMZMYGZL" & vbCrLf
		'//���N�����\�������݌ɐ���(552�`563)
		strSQL = strSQL & ", LMAMYGZA, LMAMYGZB, LMAMYGZC, LMAMYGZD, LMAMYGZE, LMAMYGZF, LMAMYGZG, LMAMYGZH, LMAMYGZI, LMAMYGZJ, LMAMYGZK, LMAMYGZL" & vbCrLf
		'//���N�����\�������݌ɐ���(564�`575)
		strSQL = strSQL & ", LMBMYGZA, LMBMYGZB, LMBMYGZC, LMBMYGZD, LMBMYGZE, LMBMYGZF, LMBMYGZG, LMBMYGZH, LMBMYGZI, LMBMYGZJ, LMBMYGZK, LMBMYGZL" & vbCrLf
		'// 2007/01/09 �� ADD END
		strSQL = strSQL & "FROM   HKKZTRB " & vbCrLf
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD) & vbCrLf
        strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD.Text) & vbCrLf
        '2019/04/12 CHG E N D

		' �f�[�^�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRecB, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dtHKKZTRB As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

		' SQL���̍쐬
		strSQL = ""
		strSQL = strSQL & "SELECT " & vbCrLf
		'//�O�N���Ɏw����(0�`11)
		strSQL = strSQL & "  LMZNOSA, LMZNOSB, LMZNOSC, LMZNOSD, LMZNOSE, LMZNOSF, LMZNOSG, LMZNOSH, LMZNOSI, LMZNOSJ, LMZNOSK, LMZNOSL "
		'//���N���Ɏw����(12�`23)
		strSQL = strSQL & ", LMANOSA, LMANOSB, LMANOSC, LMANOSD, LMANOSE, LMANOSF, LMANOSG, LMANOSH, LMANOSI, LMANOSJ, LMANOSK, LMANOSL "
		'//���N���Ɏw����(24�`35)
		strSQL = strSQL & ", LMBNOSA, LMBNOSB, LMBNOSC, LMBNOSD, LMBNOSE, LMBNOSF, LMBNOSG, LMBNOSH, LMBNOSI, LMBNOSJ, LMBNOSK, LMBNOSL "
		'//�O�N���Ɍv�搔(36�`47)
		strSQL = strSQL & ", LMZNPSA, LMZNPSB, LMZNPSC, LMZNPSD, LMZNPSE, LMZNPSF, LMZNPSG, LMZNPSH, LMZNPSI, LMZNPSJ, LMZNPSK, LMZNPSL "
		'//���N���Ɍv�搔(48�`59)
		strSQL = strSQL & ", LMANPSA, LMANPSB, LMANPSC, LMANPSD, LMANPSE, LMANPSF, LMANPSG, LMANPSH, LMANPSI, LMANPSJ, LMANPSK, LMANPSL "
		'//���N���Ɍv�搔(60�`71)
		strSQL = strSQL & ", LMBNPSA, LMBNPSB, LMBNPSC, LMBNPSD, LMBNPSE, LMBNPSF, LMBNPSG, LMBNPSH, LMBNPSI, LMBNPSJ, LMBNPSK, LMBNPSL "
		'// 2007/01/09 �� ADD STR
		'//�O�N�O�����Ɍv�搔(72�`83)
		strSQL = strSQL & ", LMZZNPA, LMZZNPB, LMZZNPC, LMZZNPD, LMZZNPE, LMZZNPF, LMZZNPG, LMZZNPH, LMZZNPI, LMZZNPJ, LMZZNPK, LMZZNPL "
		'//���N�O�����Ɍv�搔(84�`95)
		strSQL = strSQL & ", LMAZNPA, LMAZNPB, LMAZNPC, LMAZNPD, LMAZNPE, LMAZNPF, LMAZNPG, LMAZNPH, LMAZNPI, LMAZNPJ, LMAZNPK, LMAZNPL "
		'//���N�O�����Ɍv�搔(96�`107)
		strSQL = strSQL & ", LMBZNPA, LMBZNPB, LMBZNPC, LMBZNPD, LMBZNPE, LMBZNPF, LMBZNPG, LMBZNPH, LMBZNPI, LMBZNPJ, LMBZNPK, LMBZNPL "
		'// 2007/01/09 �� ADD END
		'// 2007/02/02 �� ADD STR
		'//�O�N���ɓ��͌v�搔��(108�`119)
		strSQL = strSQL & ", LMZIPKA, LMZIPKB, LMZIPKC, LMZIPKD, LMZIPKE, LMZIPKF, LMZIPKG, LMZIPKH, LMZIPKI, LMZIPKJ, LMZIPKK, LMZIPKL "
		'//���N���ɓ��͌v�搔��(120�`131)
		strSQL = strSQL & ", LMAIPKA, LMAIPKB, LMAIPKC, LMAIPKD, LMAIPKE, LMAIPKF, LMAIPKG, LMAIPKH, LMAIPKI, LMAIPKJ, LMAIPKK, LMAIPKL "
		'//���N���ɓ��͌v�搔��(132�`143)
		strSQL = strSQL & ", LMBIPKA, LMBIPKB, LMBIPKC, LMBIPKD, LMBIPKE, LMBIPKF, LMBIPKG, LMBIPKH, LMBIPKI, LMBIPKJ, LMBIPKK, LMBIPKL "
		'// 2007/02/02 �� ADD END
		'// 2007/02/24 �� ADD END
		strSQL = strSQL & ", WRTDT,WRTTM" & vbCrLf '144-145
		'// 2007/02/24 �� ADD END
		'// V2.20�� ADD
		'//�O�N���Ɍv��D���׸�(146�`157)
		strSQL = strSQL & ", LMZNPFA, LMZNPFB, LMZNPFC, LMZNPFD, LMZNPFE, LMZNPFF, LMZNPFG, LMZNPFH, LMZNPFI, LMZNPFJ, LMZNPFK, LMZNPFL "
		'//���N���Ɍv��D���׸�(158�`169)
		strSQL = strSQL & ", LMANPFA, LMANPFB, LMANPFC, LMANPFD, LMANPFE, LMANPFF, LMANPFG, LMANPFH, LMANPFI, LMANPFJ, LMANPFK, LMANPFL "
		'//���N���Ɍv��D���׸�(170�`181)
		strSQL = strSQL & ", LMBNPFA, LMBNPFB, LMBNPFC, LMBNPFD, LMBNPFE, LMBNPFF, LMBNPFG, LMBNPFH, LMBNPFI, LMBNPFJ, LMBNPFK, LMBNPFL "
		'// V2.20�� ADD
		strSQL = strSQL & " FROM   ODINTRA " & vbCrLf
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'strSQL = strSQL & " WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD) & vbCrLf
        strSQL = strSQL & " WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD.Text) & vbCrLf
        '2019/04/12 CHG E N D

		' �f�[�^�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRecC, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dtODINTRA As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

		'//�̔��v��O���e����ʂɕ\������
        If Not Set_HKKZTRA(dtHKKZTRA, dtHKKZTRB, dtODINTRA) Then
            GoTo EXIT_STEP
        End If
		
        '2019/04/15 DEL START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCloseDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraCloseDyn(objRecA)
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCloseDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraCloseDyn(objRecB)
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCloseDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraCloseDyn(objRecC)
        '2019/04/15 DEL E N D

		Get_HKKZTRA = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Get_HKKTRA
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    �̔��v��e���擾����
	'//*****************************************************************************************
	Public Function Get_HKKTRA() As Boolean
        '2019/04/15 DEL START
        'Dim ORADYN_READONLY As Object
        'Dim gvstrOPEID As Object
        '2019/04/15 DEL E N D

		Const PROCEDURE As String = "Get_HKKTRA"
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim objRec As OraDynaset
		
		Get_HKKTRA = False
		
		On Error GoTo ONERR_STEP
		
		' SQL���̍쐬
		strSQL = ""
		strSQL = strSQL & "SELECT * " & vbCrLf
		strSQL = strSQL & "FROM   HKKWTA " & vbCrLf
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD) & vbCrLf
        strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD.Text) & vbCrLf
        '2019/04/12 CHG E N D
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "AND    OPEID = " & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
		' �f�[�^�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, ORADYN_READONLY, PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraEOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '2019/04/15 CHG E N D
            gvblnInputFlg = True
        Else
            gvblnInputFlg = False
        End If

        ' SQL���̍쐬
        strSQL = ""
        strSQL = strSQL & "SELECT " & vbCrLf
        ''�O�N�v�搔��
        strSQL = strSQL & "  LMZHKSA, LMZHKSB, LMZHKSC, LMZHKSD, LMZHKSE, LMZHKSF, LMZHKSG, LMZHKSH, LMZHKSI, LMZHKSJ, LMZHKSK, LMZHKSL" & vbCrLf ' 1-12
        ''���N�v�搔��
        strSQL = strSQL & ", LMAHKSA, LMAHKSB, LMAHKSC, LMAHKSD, LMAHKSE, LMAHKSF, LMAHKSG, LMAHKSH, LMAHKSI, LMAHKSJ, LMAHKSK, LMAHKSL" & vbCrLf '13-24
        ''���N�v�搔��
        strSQL = strSQL & ", LMBHKSA, LMBHKSB, LMBHKSC, LMBHKSD, LMBHKSE, LMBHKSF, LMBHKSG, LMBHKSH, LMBHKSI, LMBHKSJ, LMBHKSK, LMBHKSL" & vbCrLf '25-36
        '//�O�N��������(
        strSQL = strSQL & ", LMZHMSA, LMZHMSB, LMZHMSC, LMZHMSD, LMZHMSE, LMZHMSF, LMZHMSG, LMZHMSH, LMZHMSI, LMZHMSJ, LMZHMSK, LMZHMSL" & vbCrLf '37-48
        '//���N��������(
        strSQL = strSQL & ", LMAHMSA, LMAHMSB, LMAHMSC, LMAHMSD, LMAHMSE, LMAHMSF, LMAHMSG, LMAHMSH, LMAHMSI, LMAHMSJ, LMAHMSK, LMAHMSL" & vbCrLf '49-60
        '//���N��������(
        strSQL = strSQL & ", LMBHMSA, LMBHMSB, LMBHMSC, LMBHMSD, LMBHMSE, LMBHMSF, LMBHMSG, LMBHMSH, LMBHMSI, LMBHMSJ, LMBHMSK, LMBHMSL" & vbCrLf '61-72
        ''//�N���v��CSV�捞�ݎ��̓��[�N�t�@�C������
        If gvblnInputFlg Then
            '// 2006/11/13 �� ADD STR
            '//�O�N���Y�v��ԍ�
            strSQL = strSQL & ", NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL" & vbCrLf '73-84
            '//���N���Y�v��ԍ�
            strSQL = strSQL & ", NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL" & vbCrLf '85-96
            '//���N���Y�v��ԍ�
            strSQL = strSQL & ", NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL" & vbCrLf '97-108
            '// 2006/11/13 �� ADD END
            '// 2007/01/09 �� ADD STR
            '//�O�N�v��N����
            strSQL = strSQL & ", NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL" & vbCrLf '109-120
            '//���N�v��N����
            strSQL = strSQL & ", NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL" & vbCrLf '121-132
            '//���N�v��N����
            strSQL = strSQL & ", NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL" & vbCrLf '133-144
            '// 2007/01/09 �� ADD END
            '// 2007/02/24 �� ADD STR
            strSQL = strSQL & ", NULL,NULL" & vbCrLf '145-146
            '// 2007/02/24 �� ADD END
            strSQL = strSQL & "FROM   HKKWTA " & vbCrLf
        Else
            '// 2006/11/13 �� ADD STR
            '//�O�N���Y�v��ԍ�
            strSQL = strSQL & ", LMZPNOA, LMZPNOB, LMZPNOC, LMZPNOD, LMZPNOE, LMZPNOF, LMZPNOG, LMZPNOH, LMZPNOI, LMZPNOJ, LMZPNOK, LMZPNOL" & vbCrLf '73-84
            '//���N���Y�v��ԍ�
            strSQL = strSQL & ", LMAPNOA, LMAPNOB, LMAPNOC, LMAPNOD, LMAPNOE, LMAPNOF, LMAPNOG, LMAPNOH, LMAPNOI, LMAPNOJ, LMAPNOK, LMAPNOL" & vbCrLf '85-96
            '//���N���Y�v��ԍ�
            strSQL = strSQL & ", LMBPNOA, LMBPNOB, LMBPNOC, LMBPNOD, LMBPNOE, LMBPNOF, LMBPNOG, LMBPNOH, LMBPNOI, LMBPNOJ, LMBPNOK, LMBPNOL" & vbCrLf '97-108
            '// 2006/11/13 �� ADD END
            '// 2007/01/09 �� ADD STR
            '//�O�N�v��N����
            strSQL = strSQL & ", LMZPDTA, LMZPDTB, LMZPDTC, LMZPDTD, LMZPDTE, LMZPDTF, LMZPDTG, LMZPDTH, LMZPDTI, LMZPDTJ, LMZPDTK, LMZPDTL" & vbCrLf '109-120
            '//���N�v��N����
            strSQL = strSQL & ", LMAPDTA, LMAPDTB, LMAPDTC, LMAPDTD, LMAPDTE, LMAPDTF, LMAPDTG, LMAPDTH, LMAPDTI, LMAPDTJ, LMAPDTK, LMAPDTL" & vbCrLf '121-132
            '//���N�v��N����
            strSQL = strSQL & ", LMBPDTA, LMBPDTB, LMBPDTC, LMBPDTD, LMBPDTE, LMBPDTF, LMBPDTG, LMBPDTH, LMBPDTI, LMBPDTJ, LMBPDTK, LMBPDTL" & vbCrLf '133-144
            '// 2007/01/09 �� ADD END
            '// 2007/02/24 �� ADD STR
            strSQL = strSQL & ", WRTDT,WRTTM" & vbCrLf '145-146
            '// 2007/02/24 �� ADD END
            strSQL = strSQL & "FROM   HKKTRA " & vbCrLf
        End If
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD) & vbCrLf
        strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD.Text) & vbCrLf
        '2019/04/12 CHG E N D
        ' �f�[�^�擾
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, ORADYN_READONLY, PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        dt = Nothing
        dt = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

        '//�̔��v��e����ʂɕ\������
        '2019/04/15 CHG START
        'If Not Set_HKKTRA(objRec) Then
        If Not Set_HKKTRA(dt) Then
            '2019/04/15 CHG E N D
            GoTo EXIT_STEP
        End If

        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCloseDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 DEL START
        'clsOra.OraCloseDyn(objRec)
        '2019/04/15 DEL E N D

        Get_HKKTRA = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Set_HINMTA
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*            objRec              OraDynaset       I
	'//*
	'//* <��  ��>
	'//*    ���i�}�X�^�\��
	'//*****************************************************************************************
    '2019/04/15 CHG START
    'Public Function Set_HINMTA(ByRef objRec As OraDynaset) As Boolean
    Public Function Set_HINMTA(ByRef pDT As DataTable) As Boolean
        '2019/04/15 CHG E N D

        Const PROCEDURE As String = "Set_HINMTA"

        Set_HINMTA = False

        On Error GoTo ONERR_STEP

        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraEOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If pDT IsNot Nothing AndAlso pDT.Rows.Count > 0 Then
            '2019/04/15 CHG E N D
            '2019/04/15 CHG START
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET142F.txtHINNMA.Text = D0.Chk_Null(objRec("HINNMA"))
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET142F.txtHINNMB.Text = D0.Chk_Null(objRec("HINNMB"))
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET142F.txtZAIRNK.Text = D0.Chk_Null(objRec("ZAIRNK"))
            ''// 2007/03/10 �� ADD STR
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET142F.txtPRCCD.Text = D0.Chk_NullN(objRec("PRCDD"))
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET142F.txtMNFDD.Text = D0.Chk_NullN(objRec("MNFDD"))
            ''// 2007/03/10 �� ADD STR
            ''// 2006/10/27 �� ADD STR
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gvstrHINKB = D0.Chk_Null(objRec("HINKB"))
            ''// 2006/10/27 �� ADD END
            ''// 2007/01/09 �� ADD STR
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gvstrHINGRP = D0.Chk_Null(objRec("HINGRP"))
            ''// 2007/01/09 �� ADD END
            ''// 2007/02/17 �� ADD STR
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET142F.txtPRDENDKB.Text = IIf(D0.Chk_Null(objRec("PRDENDKB")) = "1", "��z��", "��z�I��") '//���Y���~
            ''// 2007/02/17 �� ADD END
            ''// 2007/02/24 �� ADD STR
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET142F.txtPRDENDKB.BackColor = System.Drawing.ColorTranslator.FromOle(IIf(D0.Chk_Null(objRec("PRDENDKB")) = "1", gvcst_COLOR_HAIIRO, gvcst_COLOR_AKAIRO)) '//���Y���~
            ''// 2007/02/24 �� ADD END
            ''// 2007/07/04 �� ADD STR
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET142F.txtPLANTK.Text = D0.Chk_Null(objRec("PLANTK"))
            ''// 2007/07/04 �� ADD END
            HKKET142F.txtHINNMA.Text = D0.Chk_Null(pDT.Rows(0)("HINNMA"))
            HKKET142F.txtHINNMB.Text = D0.Chk_Null(pDT.Rows(0)("HINNMB"))
            HKKET142F.txtZAIRNK.Text = D0.Chk_Null(pDT.Rows(0)("ZAIRNK"))
            HKKET142F.txtPRCCD.Text = D0.Chk_NullN(pDT.Rows(0)("PRCDD"))
            HKKET142F.txtMNFDD.Text = D0.Chk_NullN(pDT.Rows(0)("MNFDD"))
            gvstrHINKB = D0.Chk_Null(pDT.Rows(0)("HINKB"))
            gvstrHINGRP = D0.Chk_Null(pDT.Rows(0)("HINGRP"))
            HKKET142F.txtPRDENDKB.Text = IIf(D0.Chk_Null(pDT.Rows(0)("PRDENDKB")) = "1", "��z��", "��z�I��") '//���Y���~
            HKKET142F.txtPRDENDKB.BackColor = System.Drawing.ColorTranslator.FromOle(IIf(D0.Chk_Null(pDT.Rows(0)("PRDENDKB")) = "1", gvcst_COLOR_HAIIRO, gvcst_COLOR_AKAIRO)) '//���Y���~
            HKKET142F.txtPLANTK.Text = D0.Chk_Null(pDT.Rows(0)("PLANTK"))
            '2019/04/15 CHG E N D
        Else
            HKKET142F.txtHINNMA.Text = vbNullString
            HKKET142F.txtHINNMB.Text = vbNullString
            HKKET142F.txtZAIRNK.Text = vbNullString
            '// 2007/03/10 �� ADD STR
            HKKET142F.txtPRCCD.Text = CStr(0)
            HKKET142F.txtMNFDD.Text = CStr(0)
            '// 2007/03/10 �� ADD END
            '// 2006/10/27 �� ADD STR
            gvstrHINKB = ""
            '// 2006/10/27 �� ADD END
            '// 2007/01/09 �� ADD STR
            gvstrHINGRP = ""
            '// 2007/01/09 �� ADD END
            '// 2007/07/04 �� ADD STR
            HKKET142F.txtPLANTK.Text = CStr(0)
            '// 2007/07/04 �� ADD END
        End If

        '// 2008/05/27 �� UPD END

        '// 2008/04/30 �� ADD STR (�o�[�W�����W�v���́A�v��P���́A���̐��i�ް�ޮ݂̍ŐV���i�̏���\������)
        If HKKET141F.optVERSION.Checked = True Then
            Call Get_KEIKAKUTANKA()
        End If
        '// 2008/05/27 �� ADD END

        Set_HINMTA = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Set_HKKZTRA
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*            objRec              OraDynaset       I
	'//*            objRecB             OraDynaset       I
	'//*            objRecC             OraDynaset       I
	'//*
	'//* <��  ��>
	'//*    �̔��v��O���\��
	'//*****************************************************************************************
    '2019/04/15 CHG START
    'Public Function Set_HKKZTRA(ByRef objRec As OraDynaset, ByRef objRecB As OraDynaset, ByRef objRecC As OraDynaset) As Boolean
    Public Function Set_HKKZTRA(ByRef pDT_HKKZTRA As DataTable, ByRef pDT_HKKZTRB As DataTable, ByRef pDT_ODINTRA As DataTable) As Boolean
        '2019/04/15 CHG E N D

        Const PROCEDURE As String = "Set_HKKZTRA"

        Dim i As Short
        Dim j As Short
        Dim strDate As String
        Dim strDispMnth As String

        Set_HKKZTRA = False

        On Error GoTo ONERR_STEP
        strDispMnth = Mid(CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Year, -1, CDate(VB6.Format(gvstrUNYDT, "@@@@/@@/@@")))), 1, 4) & "0401"

        i = 0

        Do
            '//�N���v��
            ReDim musrHKKTRA.blnLMAHKS(i)
            '//�����v��
            ReDim musrHKKTRA.blnLMAHMS(i)
            ''//�\����
            ReDim Preserve musrHKKZTRA.strDSPMONTH(i)
            ''//�O�N�󒍎���
            ReDim Preserve musrHKKZTRA.dblLAST_JDNTR(i)
            ''//�O�N�o�Ɏ���
            ReDim Preserve musrHKKZTRA.dblLAST_ODNTRA(i)
            ''//�O�N��������
            ReDim Preserve musrHKKZTRA.dblLAST_HDNTRA(i)
            '// 2007/01/09 �� ADD STR
            ''//�O�N���Ɏ���
            ReDim Preserve musrHKKZTRA.dblLAST_NDNTRA(i)
            '// 2007/01/09 �� ADD END
            ''//���ɗ\��
            ReDim Preserve musrHKKZTRA.dblINPTRA(i)
            ''//�o�ɗ\��
            ReDim Preserve musrHKKZTRA.dblOUTTRA(i)
            ''//�x���i�o��
            ReDim Preserve musrHKKZTRA.dblSKYOUT(i)
            ''//�����݌�
            ReDim Preserve musrHKKZTRA.dblLAST_STOCK(i)
            '//�������E��
            ReDim Preserve musrHKKZTRA.strLMZLDT(i)
            '//������
            ReDim Preserve musrHKKZTRA.strLMZHDT(i)
            '//�݌ɐ؂�}�[�N
            ReDim Preserve musrHKKZTRA.strLMZZKM(i)
            '//���S�݌ɐ؂�}�[�N
            ReDim Preserve musrHKKZTRA.strLMZAZM(i)
            '//�����݌ɐ؂�}�[�N
            ReDim Preserve musrHKKZTRA.strLMZMZKM(i)
            '//�������S�݌ɐ؂�}�[�N
            ReDim Preserve musrHKKZTRA.strLMZMAZM(i)
            '//�݌Ɍ���
            ReDim Preserve musrHKKZTRA.dblLMZZKT(i)
            '//�����݌Ɍ���
            ReDim Preserve musrHKKZTRA.dblLMZMZKT(i)
            '//���Ϗo�ɐ�
            ReDim Preserve musrHKKZTRA.dblLMAVZS(i)
            '// 2007/01/09 �� ADD STR
            '//�\�������݌�
            ReDim Preserve musrHKKZTRA.dblYOSLST(i)
            '//�����\�������݌�
            ReDim Preserve musrHKKZTRA.dblMYOSLST(i)
            '// 2007/01/09 �� ADD END
            ''//�����Č�
            ReDim Preserve musrMKMTRA.dblMKMAK(i)
            ''//��������
            ReDim Preserve musrMKMTRA.dblMKMMT(i)
            ''//�����o�ɗ\��
            ReDim Preserve musrMKMTRA.dblMKMOUTTRA(i)
            ''//���������݌�
            ReDim Preserve musrMKMTRA.dblMKMLST(i)
            ''//�����όv
            ReDim Preserve musrODINTRA.dblLMAODSSA(i)
            ''//�ً}�����όv
            ReDim Preserve musrODINTRA.dblLMAKODSA(i)
            ''//���Ɏw���ϐ�
            ReDim Preserve musrODINTRA.dblLMZNOSSA(i)
            '// 2007/01/09 �� ADD STR
            ''//�i���́j���Ɍv�搔
            ReDim Preserve musrODINTRA.strINPPLAN(i)
            ''//�i���́j���Ɍv�搔
            ReDim Preserve musrODINTRA.strINPPLAN_ORG(i)
            ''//�i�\���j���Ɍv�搔
            ReDim Preserve musrODINTRA.dblDspINPPLAN(i)
            ''//�i�\���j���Ɍv�搔
            ReDim Preserve musrODINTRA.dblDspINPPLAN_ORG(i)
            ''//�i�\���j���Ɍv�搔(��������)
            ReDim Preserve musrODINTRA.dblDspINPPLAN_ZEN(i)
            '// 2007/01/09 �� ADD END
            ''//���Ɏw����
            ReDim Preserve musrODINTRA.strLMZNOSS(i)
            ''//���Ɏw����(����l)
            ReDim Preserve musrODINTRA.strLMZNOSS_ORG(i)
            '// V2.20�� ADD
            '//���Ɍv��D���׸�
            ReDim Preserve musrODINTRA.strLMZNPF(i)
            '//���Ɍv��D���׸�(�ǂݍ��ݎ�)
            ReDim Preserve musrODINTRA.strLMZNPF_ORG(i)
            '// V2.20�� ADD

            'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraEOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/15 CHG START
            'If Not clsOra.OraEOF(objRec) Then
            If pDT_HKKZTRA IsNot Nothing AndAlso pDT_HKKZTRA.Rows.Count > 0 Then
                '2019/04/15 CHG E N D

                '2019/04/15 ADD START
                Dim drHKKZTRA As DataRow = pDT_HKKZTRA.Rows(0)
                Dim drHKKZTRB As DataRow = pDT_HKKZTRB.Rows(0)
                Dim drODINTRA As DataRow = pDT_ODINTRA.Rows(0)
                '2019/04/15 ADD E N D

                '2019/04/15 CHG START
                ' ''//�\����
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.strDSPMONTH(i) = D0.Chk_Null(objRec(i))
                ''// 2006/10/26 �� UPD STR
                ''            If i > 11 Then
                ''                ''//�O�N�󒍎���
                ''                musrHKKZTRA.dblLAST_JDNTR(i) = D0.Chk_NullN(objRec(i + 288))
                ''                ''//�O�N�o�Ɏ���
                ''                musrHKKZTRA.dblLAST_ODNTRA(i) = D0.Chk_NullN(objRec(i + 396))
                ''                ''//�O�N��������
                ''                musrHKKZTRA.dblLAST_HDNTRA(i) = D0.Chk_NullN(objRec(i + 432))
                ''            Else
                ''                ''//�O�N�󒍎���
                ''                musrHKKZTRA.dblLAST_JDNTR(i) = 0
                ''                ''//�O�N�o�Ɏ���
                ''                musrHKKZTRA.dblLAST_ODNTRA(i) = 0
                ''                ''//�O�N��������
                ''                musrHKKZTRA.dblLAST_HDNTRA(i) = 0
                ''            End If
                ' ''//�O�N�󒍎���
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.dblLAST_JDNTR(i) = D0.Chk_NullN(objRec(i + 288))
                ' ''//�O�N�o�Ɏ���
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.dblLAST_ODNTRA(i) = D0.Chk_NullN(objRec(i + 396))
                ' ''//�O�N��������
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.dblLAST_HDNTRA(i) = D0.Chk_NullN(objRec(i + 432))
                ''// 2006/10/26 �� UPD END
                ''// 2007/01/09 �� ADD STR
                ' ''//�O�N���Ɏ���
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.dblLAST_NDNTRA(i) = D0.Chk_NullN(objRec(i + 360))
                ''// 2007/01/09 �� ADD END
                ' ''//���ɗ\��
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.dblINPTRA(i) = D0.Chk_NullN(objRec(i + 36))
                ' ''//�o�ɗ\��
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.dblOUTTRA(i) = D0.Chk_NullN(objRec(i + 72))
                ' ''//�x���i�o��
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.dblSKYOUT(i) = D0.Chk_NullN(objRec(i + 144))
                ' ''//�����݌�
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.dblLAST_STOCK(i) = D0.Chk_NullN(objRec(i + 468))
                ''//�������E��
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.strLMZLDT(i) = D0.Chk_Null(objRec(i + 108))
                ''//������
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.strLMZHDT(i) = D0.Chk_Null(objRecB(i + 288))
                ''//�݌ɐ؂�}�[�N
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.strLMZZKM(i) = D0.Chk_Null(objRecB(i))
                ''//���S�݌ɐ؂�}�[�N
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.strLMZAZM(i) = D0.Chk_Null(objRecB(i + 36))
                ''//�����݌ɐ؂�}�[�N
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.strLMZMZKM(i) = D0.Chk_Null(objRecB(i + 72))
                ''//�������S�݌ɐ؂�}�[�N
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.strLMZMAZM(i) = D0.Chk_Null(objRecB(i + 108))
                ''//�݌Ɍ���
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.dblLMZZKT(i) = D0.Chk_NullN(objRecB(i + 324))
                ''//�����݌Ɍ���
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.dblLMZMZKT(i) = D0.Chk_NullN(objRecB(i + 360))
                ''//���Ϗo�ɐ�
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.dblLMAVZS(i) = D0.Chk_NullN(objRecB(i + 396))
                ''// 2007/01/09 �� ADD STR
                ''//�\�������݌�
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.dblYOSLST(i) = D0.Chk_NullN(objRecB(i + 504))
                ''//�����\�������݌�
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKZTRA.dblMYOSLST(i) = D0.Chk_NullN(objRecB(i + 540))
                ''// 2007/01/09 �� ADD END
                ' ''//�����Č�
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrMKMTRA.dblMKMAK(i) = D0.Chk_NullN(objRecB(i + 432))
                ' ''//��������
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrMKMTRA.dblMKMMT(i) = D0.Chk_NullN(objRec(i + 540))
                ''// 2007/01/09 �� UPD STR
                ''            ''//�����o�ɗ\��
                ''            musrMKMTRA.dblMKMOUTTRA(i) = D0.Chk_NullN(objRec(i + 576)) + D0.Chk_NullN(objRecB(i + 468)) + D0.Chk_NullN(objRec(i + 612))
                ' ''//�����o�ɗ\��
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrMKMTRA.dblMKMOUTTRA(i) = D0.Chk_NullN(objRecB(i + 468)) + D0.Chk_NullN(objRec(i + 576))
                ''// 2007/01/09 �� UPD END
                ' ''//���������݌�
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrMKMTRA.dblMKMLST(i) = D0.Chk_NullN(objRec(i + 504))
                ' ''//�����όv
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrODINTRA.dblLMAODSSA(i) = D0.Chk_NullN(objRec(i + 252))
                ' ''//�ً}�����όv
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrODINTRA.dblLMAKODSA(i) = D0.Chk_NullN(objRec(i + 180))
                ' ''//���Ɏw���ϐ�
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrODINTRA.dblLMZNOSSA(i) = D0.Chk_NullN(objRec(i + 216))
                ''// 2007/01/09 �� ADD STR
                ' ''//�i���́j���Ɍv�搔
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrODINTRA.strINPPLAN(i) = CStr(Val(D0.Chk_Null(objRecC(i + 108))))
                ' ''//�i���́j���Ɍv�搔
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrODINTRA.strINPPLAN_ORG(i) = CStr(Val(D0.Chk_Null(objRecC(i + 108))))
                ' ''//�i�\���j���Ɍv�搔
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrODINTRA.dblDspINPPLAN(i) = D0.Chk_NullN(objRecC(i + 36))
                ' ''//�i�\���j���Ɍv�搔
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrODINTRA.dblDspINPPLAN_ORG(i) = D0.Chk_NullN(objRecC(i + 36))
                ' ''//�i�\���j���Ɍv�搔(��������)
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrODINTRA.dblDspINPPLAN_ZEN(i) = D0.Chk_NullN(objRecC(i + 72))
                ''// 2007/01/09 �� ADD END
                ''            If IsNumeric(musrHKKTRA.strLMAHMS(i)) Then
                ''                If HKKET141F.optORDER_ON.Value Then
                ''                    musrODINTRA.dblDspINPPLAN(i) = CDbl(musrHKKTRA.strLMAHMS(i)) + CDbl(D0.Chk_Null(objRec(i + 515)))
                ''                Else
                ''                    musrODINTRA.dblDspINPPLAN(i) = CDbl(musrHKKTRA.strLMAHMS(i)) + CDbl(D0.Chk_Null(objRec(i + 479)))
                ''                End If
                ''            Else
                ''                If HKKET141F.optORDER_ON.Value Then
                ''                    musrODINTRA.dblDspINPPLAN(i) = CDbl(Val(musrHKKTRA.strLMAHKS(i))) + CDbl(D0.Chk_Null(objRec(i + 515)))
                ''                Else
                ''                    musrODINTRA.dblDspINPPLAN(i) = CDbl(Val(musrHKKTRA.strLMAHKS(i))) + CDbl(D0.Chk_Null(objRec(i + 479)))
                ''                End If
                ''            End If
                ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraEOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'If Not clsOra.OraEOF(objRecC) Then
                '    '//���Ɏw����
                '    'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    If IsNumeric(D0.Chk_Null(objRecC(i))) Then
                '        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '        musrODINTRA.strLMZNOSS(i) = CStr(CDbl(D0.Chk_Null(objRecC(i))))
                '        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '        musrODINTRA.strLMZNOSS_ORG(i) = CStr(CDbl(D0.Chk_Null(objRecC(i))))
                '    Else
                '        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '        musrODINTRA.strLMZNOSS(i) = D0.Chk_Null(objRecC(i))
                '        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '        musrODINTRA.strLMZNOSS_ORG(i) = D0.Chk_Null(objRecC(i))
                '    End If
                '    '// 2007/02/24 �� ADD END
                '    'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    strODINTRA_DAY = Mid(Right(Space(8) & D0.Chk_Null(objRecC(144)), 8), 1, 4) & "/" & Mid(Right(Space(8) & D0.Chk_Null(objRecC(144)), 8), 5, 2) & "/" & Mid(Right(Space(8) & D0.Chk_Null(objRecC(144)), 8), 7, 2) & " " & Mid(Right(Space(6) & D0.Chk_Null(objRecC(145)), 6), 1, 2) & ":" & Mid(Right(Space(6) & D0.Chk_Null(objRecC(145)), 6), 3, 2) & ":" & Mid(Right(Space(6) & D0.Chk_Null(objRecC(145)), 6), 5, 2)
                '    '// 2007/02/24 �� ADD END
                '    '// V2.20�� ADD
                '    '//�D��t���O
                '    'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    musrODINTRA.strLMZNPF(i) = IIf(D0.Chk_Null(objRecC(i + 146)) = "", "0   ", objRecC(i + 146))
                '    musrODINTRA.strLMZNPF_ORG(i) = musrODINTRA.strLMZNPF(i)
                '    '// V2.20�� ADD
                'Else
                '    '//���Ɏw����
                '    musrODINTRA.strLMZNOSS(i) = " "
                '    musrODINTRA.strLMZNOSS_ORG(i) = " "
                '    '// 2007/02/24 �� ADD END
                '    strODINTRA_DAY = Space(19)
                '    '// 2007/02/24 �� ADD END
                '    '// V2.20�� ADD
                '    '//�D��t���O
                '    musrODINTRA.strLMZNPF(i) = "0   "
                '    musrODINTRA.strLMZNPF_ORG(i) = musrODINTRA.strLMZNPF(i)
                '    '// V2.20�� ADD
                'End If

                ''//�\����
                musrHKKZTRA.strDSPMONTH(i) = D0.Chk_Null(drHKKZTRA(i))
                ''//�O�N�󒍎���
                musrHKKZTRA.dblLAST_JDNTR(i) = D0.Chk_NullN(drHKKZTRA(i + 288))
                ''//�O�N�o�Ɏ���
                musrHKKZTRA.dblLAST_ODNTRA(i) = D0.Chk_NullN(drHKKZTRA(i + 396))
                ''//�O�N��������
                musrHKKZTRA.dblLAST_HDNTRA(i) = D0.Chk_NullN(drHKKZTRA(i + 432))
                ''//�O�N���Ɏ���
                musrHKKZTRA.dblLAST_NDNTRA(i) = D0.Chk_NullN(drHKKZTRA(i + 360))
                ''//���ɗ\��
                musrHKKZTRA.dblINPTRA(i) = D0.Chk_NullN(drHKKZTRA(i + 36))
                ''//�o�ɗ\��
                musrHKKZTRA.dblOUTTRA(i) = D0.Chk_NullN(drHKKZTRA(i + 72))
                ''//�x���i�o��
                musrHKKZTRA.dblSKYOUT(i) = D0.Chk_NullN(drHKKZTRA(i + 144))
                ''//�����݌�
                musrHKKZTRA.dblLAST_STOCK(i) = D0.Chk_NullN(drHKKZTRA(i + 468))
                '//�������E��
                musrHKKZTRA.strLMZLDT(i) = D0.Chk_Null(drHKKZTRA(i + 108))
                '//������
                musrHKKZTRA.strLMZHDT(i) = D0.Chk_Null(drHKKZTRB(i + 288))
                '//�݌ɐ؂�}�[�N
                musrHKKZTRA.strLMZZKM(i) = D0.Chk_Null(drHKKZTRB(i))
                '//���S�݌ɐ؂�}�[�N
                musrHKKZTRA.strLMZAZM(i) = D0.Chk_Null(drHKKZTRB(i + 36))
                '//�����݌ɐ؂�}�[�N
                musrHKKZTRA.strLMZMZKM(i) = D0.Chk_Null(drHKKZTRB(i + 72))
                '//�������S�݌ɐ؂�}�[�N
                musrHKKZTRA.strLMZMAZM(i) = D0.Chk_Null(drHKKZTRB(i + 108))
                '//�݌Ɍ���
                musrHKKZTRA.dblLMZZKT(i) = D0.Chk_NullN(drHKKZTRB(i + 324))
                '//�����݌Ɍ���
                musrHKKZTRA.dblLMZMZKT(i) = D0.Chk_NullN(drHKKZTRB(i + 360))
                '//���Ϗo�ɐ�
                musrHKKZTRA.dblLMAVZS(i) = D0.Chk_NullN(drHKKZTRB(i + 396))
                '//�\�������݌�
                musrHKKZTRA.dblYOSLST(i) = D0.Chk_NullN(drHKKZTRB(i + 504))
                '//�����\�������݌�
                musrHKKZTRA.dblMYOSLST(i) = D0.Chk_NullN(drHKKZTRB(i + 540))
                ''//�����Č�
                musrMKMTRA.dblMKMAK(i) = D0.Chk_NullN(drHKKZTRB(i + 432))
                ''//��������
                musrMKMTRA.dblMKMMT(i) = D0.Chk_NullN(drHKKZTRA(i + 540))
                ''//�����o�ɗ\��
                musrMKMTRA.dblMKMOUTTRA(i) = D0.Chk_NullN(drHKKZTRB(i + 468)) + D0.Chk_NullN(drHKKZTRA(i + 576))
                ''//���������݌�
                musrMKMTRA.dblMKMLST(i) = D0.Chk_NullN(drHKKZTRA(i + 504))
                ''//�����όv
                musrODINTRA.dblLMAODSSA(i) = D0.Chk_NullN(drHKKZTRA(i + 252))
                ''//�ً}�����όv
                musrODINTRA.dblLMAKODSA(i) = D0.Chk_NullN(drHKKZTRA(i + 180))
                ''//���Ɏw���ϐ�
                musrODINTRA.dblLMZNOSSA(i) = D0.Chk_NullN(drHKKZTRA(i + 216))
                ''//�i���́j���Ɍv�搔
                musrODINTRA.strINPPLAN(i) = CStr(Val(D0.Chk_Null(drODINTRA(i + 108))))
                ''//�i���́j���Ɍv�搔
                musrODINTRA.strINPPLAN_ORG(i) = CStr(Val(D0.Chk_Null(drODINTRA(i + 108))))
                ''//�i�\���j���Ɍv�搔
                musrODINTRA.dblDspINPPLAN(i) = D0.Chk_NullN(drODINTRA(i + 36))
                ''//�i�\���j���Ɍv�搔
                musrODINTRA.dblDspINPPLAN_ORG(i) = D0.Chk_NullN(drODINTRA(i + 36))
                ''//�i�\���j���Ɍv�搔(��������)
                musrODINTRA.dblDspINPPLAN_ZEN(i) = D0.Chk_NullN(drODINTRA(i + 72))
                '2019/04/15�@��
                If pDT_ODINTRA IsNot Nothing AndAlso pDT_ODINTRA.Rows.Count > 0 Then
                    '2019/04/15�@��
                    '//���Ɏw����
                    If IsNumeric(D0.Chk_Null(drODINTRA(i))) Then
                        musrODINTRA.strLMZNOSS(i) = CStr(CDbl(D0.Chk_Null(drODINTRA(i))))
                        musrODINTRA.strLMZNOSS_ORG(i) = CStr(CDbl(D0.Chk_Null(drODINTRA(i))))
                    Else
                        musrODINTRA.strLMZNOSS(i) = D0.Chk_Null(drODINTRA(i))
                        musrODINTRA.strLMZNOSS_ORG(i) = D0.Chk_Null(drODINTRA(i))
                    End If
                    strODINTRA_DAY = Mid(Right(Space(8) & D0.Chk_Null(drODINTRA(144)), 8), 1, 4) _
                                  & "/" & Mid(Right(Space(8) & D0.Chk_Null(drODINTRA(144)), 8), 5, 2) _
                                  & "/" & Mid(Right(Space(8) & D0.Chk_Null(drODINTRA(144)), 8), 7, 2) _
                                  & " " & Mid(Right(Space(6) & D0.Chk_Null(drODINTRA(145)), 6), 1, 2) _
                                  & ":" & Mid(Right(Space(6) & D0.Chk_Null(drODINTRA(145)), 6), 3, 2) _
                                  & ":" & Mid(Right(Space(6) & D0.Chk_Null(drODINTRA(145)), 6), 5, 2)
                    '//�D��t���O
                    musrODINTRA.strLMZNPF(i) = IIf(D0.Chk_Null(drODINTRA(i + 146)) = "", "0   ", drODINTRA(i + 146))
                    musrODINTRA.strLMZNPF_ORG(i) = musrODINTRA.strLMZNPF(i)
                Else
                    '//���Ɏw����
                    musrODINTRA.strLMZNOSS(i) = " "
                    musrODINTRA.strLMZNOSS_ORG(i) = " "
                    strODINTRA_DAY = Space(19)
                    '//�D��t���O
                    musrODINTRA.strLMZNPF(i) = "0   "
                    musrODINTRA.strLMZNPF_ORG(i) = musrODINTRA.strLMZNPF(i)
                End If
                '2019/04/15 CHG E N D
            Else
                strDate = Mid(VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Month, i, CDate(VB6.Format(strDispMnth, "@@@@/@@/@@"))), "YYYYMMDD"), 1, 6)
                ''//�\����
                musrHKKZTRA.strDSPMONTH(i) = strDate
                ''//�O�N�󒍎���
                musrHKKZTRA.dblLAST_JDNTR(i) = 0
                '// 2007/01/09 �� ADD STR
                ''//�O�N���Ɏ���
                musrHKKZTRA.dblLAST_NDNTRA(i) = 0
                '// 2007/01/09 �� ADD END
                ''//�O�N�o�Ɏ���
                musrHKKZTRA.dblLAST_ODNTRA(i) = 0
                ''//�O�N��������
                musrHKKZTRA.dblLAST_HDNTRA(i) = 0
                ''//���ɗ\��
                musrHKKZTRA.dblINPTRA(i) = 0
                ''//�o�ɗ\��
                musrHKKZTRA.dblOUTTRA(i) = 0
                ''//�x���i�o��
                musrHKKZTRA.dblSKYOUT(i) = 0
                '//�݌ɐ؂�}�[�N
                musrHKKZTRA.strLMZZKM(i) = ""
                '//���S�݌ɐ؂�}�[�N
                musrHKKZTRA.strLMZAZM(i) = ""
                '//�����݌ɐ؂�}�[�N
                musrHKKZTRA.strLMZMZKM(i) = ""
                '//�������S�݌ɐ؂�}�[�N
                musrHKKZTRA.strLMZMAZM(i) = ""
                '//�������E��
                musrHKKZTRA.strLMZLDT(i) = ""
                '//������
                musrHKKZTRA.strLMZHDT(i) = ""
                '//�݌Ɍ���
                musrHKKZTRA.dblLMZZKT(i) = 0
                '//�����݌Ɍ���
                musrHKKZTRA.dblLMZMZKT(i) = 0
                ''//�����݌�
                musrHKKZTRA.dblLAST_STOCK(i) = 0
                ''//���Ϗo�ɐ�
                musrHKKZTRA.dblLMAVZS(i) = 0
                '// 2007/01/09 �� ADD STR
                ''//�\�������݌�
                musrHKKZTRA.dblYOSLST(i) = 0
                ''//�����\�������݌�
                musrHKKZTRA.dblMYOSLST(i) = 0
                '// 2007/01/09 �� ADD END
                ''//�����Č�
                musrMKMTRA.dblMKMAK(i) = 0
                ''//��������
                musrMKMTRA.dblMKMMT(i) = 0
                ''//�����o�ɗ\��
                musrMKMTRA.dblMKMOUTTRA(i) = 0
                ''//���������݌�
                musrMKMTRA.dblMKMLST(i) = 0
                ''//�����όv
                musrODINTRA.dblLMAODSSA(i) = 0
                ''//�ً}�����όv
                musrODINTRA.dblLMAKODSA(i) = 0
                ''//���Ɏw���ϐ�
                musrODINTRA.dblLMZNOSSA(i) = 0
                '// 2007/01/09 �� ADD STR
                ''//�i���́j���Ɍv�搔
                musrODINTRA.strINPPLAN(i) = " "
                ''//�i���́j���Ɍv�搔
                musrODINTRA.strINPPLAN_ORG(i) = " "
                ''//�i�\���j���Ɍv�搔
                musrODINTRA.dblDspINPPLAN(i) = 0
                ''//�i�\���j���Ɍv�搔(����l)
                musrODINTRA.dblDspINPPLAN_ORG(i) = 0
                ''//�i�\���j���Ɍv�搔(��������)
                musrODINTRA.dblDspINPPLAN_ZEN(i) = 0
                '// 2007/01/09 �� ADD END
                '//���Ɏw����
                musrODINTRA.strLMZNOSS(i) = " "
                '//���Ɏw����(����l)
                musrODINTRA.strLMZNOSS_ORG(i) = " "
                '// 2007/02/24 �� ADD END
                strHKKTRA_DAY = Space(19)
                '// 2007/02/24 �� ADD END
                '// V2.20�� ADD
                '//�D��t���O
                musrODINTRA.strLMZNPF(i) = "0   "
                musrODINTRA.strLMZNPF_ORG(i) = musrODINTRA.strLMZNPF(i)
                '// V2.20�� ADD
            End If
            If Trim(musrODINTRA.strLMZNOSS(i)) = "" Then
                '//�N���v��
                musrHKKTRA.blnLMAHKS(i) = True
                '//�����v��
                musrHKKTRA.blnLMAHMS(i) = True
            Else
                '//�N���v��
                musrHKKTRA.blnLMAHKS(i) = False
                '//�����v��
                musrHKKTRA.blnLMAHMS(i) = False
            End If
            i = i + 1
            If i = 36 Then
                Exit Do
            End If
        Loop

        Set_HKKZTRA = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Set_HKKZTRB
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*            objRec              OraDynaset       I
	'//*
	'//* <��  ��>
	'//*    �̔��v��O���\��
	'//*****************************************************************************************
	Public Function Set_HKKZTRB(ByRef objRec As OraDynaset) As Boolean
		
		Const PROCEDURE As String = "Set_HKKZTRB"
		
		Dim i As Short
		Dim j As Short
		
		Set_HKKZTRB = False
		
		On Error GoTo ONERR_STEP
		
		i = gvlngNowPage
		j = 0
		
		Do 
			
			'//�����݌�
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If D0.Chk_Null(objRec(i + 48)) = "0" And D0.Chk_Null(objRec(i + 12)) = "0" Then
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.Color.FromARGB(128, 255, 255)
				'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ElseIf D0.Chk_Null(objRec(i + 48)) = "1" And D0.Chk_Null(objRec(i + 12)) = "0" Then 
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.Color.FromARGB(255, 128, 255)
				'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ElseIf D0.Chk_Null(objRec(i + 48)) = "0" And D0.Chk_Null(objRec(i + 12)) = "1" Then 
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.Color.Red
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If D0.Chk_Null(objRec(i + 336)) >= HKKET141F.txtSTOCK_MONTH.Text Then
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.Color.FromARGB(255, 128, 0)
			End If
			
			'//���������݌�
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If D0.Chk_Null(objRec(i + 120)) = "0" And D0.Chk_Null(objRec(i + 228)) = "0" Then
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.Color.FromARGB(128, 255, 255)
				'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ElseIf D0.Chk_Null(objRec(i + 120)) = "1" And D0.Chk_Null(objRec(i + 228)) = "0" Then 
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.Color.FromARGB(255, 128, 255)
				'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ElseIf D0.Chk_Null(objRec(i + 120)) = "0" And D0.Chk_Null(objRec(i + 228)) = "1" Then 
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.Color.Red
			End If
			
			i = i + 1
			j = j + 1
			If j = 13 Then
				Exit Do
			End If
		Loop 
		
		Set_HKKZTRB = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Set_HKKZTRA_M
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*            objRec              OraDynaset       I
	'//*
	'//* <��  ��>
	'//*    �̔��v��O���\��
	'//*****************************************************************************************
    '2019/04/15 CHG START
    'Public Function Set_HKKZTRA_M(ByRef objRec As OraDynaset) As Boolean
    Public Function Set_HKKZTRA_M(ByRef pDT As DataTable) As Boolean
        '2019/04/15 CHG E N D

        Const PROCEDURE As String = "Set_HKKZTRA_M"
        Dim i As Short

        Dim lngZanEigyoHi As Integer
        Dim lngTouEigyoHi As Integer
        Dim dblMokuhyoChi As Double
        Dim dblZanHiAnbun As Double
        Dim dblSyukoYotei As Double

        Set_HKKZTRA_M = False

        On Error GoTo ONERR_STEP

        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraEOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If pDT IsNot Nothing AndAlso pDT.Rows.Count > 0 Then
            '2019/04/15 CHG E N D
            '2019/04/15 CHG START
            ''//�i��
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET142F.txtHINNMB.Text = D0.Chk_Null(objRec("HINNMB"))
            ''//�^��
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET142F.txtHINNMA.Text = D0.Chk_Null(objRec("HINKTA"))
            ''//�݌��ݸ
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET142F.txtZAIRNK.Text = D0.Chk_Null(objRec("ZAIRNK"))
            ''//�ŏ�������
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET142F.txtMINSODSU.Text = D0.Chk_NullN(objRec("MINSODSU"))
            ''//����������
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET142F.txtSODADDSU.Text = D0.Chk_NullN(objRec("SODADDSU"))
            ''//���S�݌ɐ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET142F.txtANZZAISU.Text = D0.Chk_NullN(objRec("ANZZAISU"))
            ''//���S�݌Ɋ����
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'If D0.Chk_NullN(objRec("LMAAVTS")) = 0 Then
            '    HKKET142F.txtLMAMSAVTS.Text = CStr(0)
            'Else
            '    'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chg_NumericRound �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    HKKET142F.txtLMAMSAVTS.Text = D0.Chg_NumericRound(D0.Chk_NullN(objRec("ANZZAISU")) / D0.Chk_NullN(objRec("LMAAVTS")), 3, 3)
            'End If
            ''//�݌Ɍ���
            'For i = 0 To 35
            '    If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
            '        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        If D0.Chk_NullN(objRec("LMAAVTS")) = 0 Then
            '            HKKET142F.txtLMAAVTS.Text = CStr(0)
            '        Else
            '            '// 2007/01/09 �� UPD STR
            '            '                    HKKET142F.txtLMAAVTS.Text = D0.Chg_NumericRound((musrHKKZTRA.dblLAST_STOCK(i) - D0.Chk_NullN(objRec("ANZZAISU"))) / D0.Chk_NullN(objRec("LMAAVTS")), 3, 3)
            '            If HKKET141F.optORDER_ON.Checked Then
            '                'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '                'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chg_NumericRound �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '                HKKET142F.txtLMAAVTS.Text = D0.Chg_NumericRound((musrHKKZTRA.dblMYOSLST(i) - D0.Chk_NullN(objRec("ANZZAISU"))) / D0.Chk_NullN(objRec("LMAAVTS")), 3, 3)
            '            Else
            '                'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '                'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chg_NumericRound �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '                HKKET142F.txtLMAAVTS.Text = D0.Chg_NumericRound((musrHKKZTRA.dblYOSLST(i) - D0.Chk_NullN(objRec("ANZZAISU"))) / D0.Chk_NullN(objRec("LMAAVTS")), 3, 3)
            '            End If
            '            '// 2007/01/09 �� UPD END
            '        End If
            '        Exit For
            '    End If
            'Next i
            ''//���Ϗo�ɐ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET142F.txtLMZAVTSA.Text = D0.Chk_NullN(objRec("LMAAVTS"))

            ''//�o�ɕω���
            'For i = 0 To 35
            '    If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
            '        If musrHKKZTRA.dblLMAVZS(i) = 0 Then
            '            HKKET142F.txtCHGRATE.Text = CStr(0)
            '        Else
            '            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chg_NumericRound �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '            HKKET142F.txtCHGRATE.Text = D0.Chg_NumericRound(musrHKKZTRA.dblLMAVZS(i - 1) / musrHKKZTRA.dblLMAVZS(i), 3, 3)
            '        End If
            '        Exit For
            '    End If
            'Next i
            ''
            ''// 2007/07/02 �� ADD START @@@@@@���񂩂������\������@@@@@@@@@@@@@@@@@@@@@@@@@tohjo
            ''//�ڕW�l�̎擾�i�����v��܂��͔N���v��(�������D��)�j
            'If Trim(musrHKKTRA.strLMAHMS(i)) = "" Then
            '    dblMokuhyoChi = Val(musrHKKTRA.strLMAHKS(i))
            'Else
            '    dblMokuhyoChi = Val(musrHKKTRA.strLMAHMS(i))
            'End If
            ''//�o�ɗ\��
            'dblSyukoYotei = musrHKKZTRA.dblOUTTRA(i)

            ''//�c�c�Ɠ��̎擾
            'lngZanEigyoHi = Get_EigyoNisu(gvstrUNYDT, Mid(gvstrUNYDT, 1, 6) & "31")

            ''//�����c�Ɠ��̎擾
            'lngTouEigyoHi = Get_EigyoNisu(Mid(gvstrUNYDT, 1, 6) & "01", Mid(gvstrUNYDT, 1, 6) & "31")

            ''//�c�������l
            'If lngZanEigyoHi <= gvlngSyukaYoteiHikaku Then
            '    '//�c�������S���ȉ��̏ꍇ
            '    dblZanHiAnbun = 0
            'Else
            '    '//�o�ח\���r����������l�����߂�
            '    If dblSyukoYotei < System.Math.Round(dblMokuhyoChi * gvlngSyukaYoteiHikaku / lngTouEigyoHi) Then
            '        '//�o�ɗ\�肪�ڕW�l�̂S�����𒴂��Ȃ��ꍇ
            '        dblZanHiAnbun = System.Math.Round(dblMokuhyoChi * lngZanEigyoHi / lngTouEigyoHi)
            '    Else
            '        '//�o�ɗ\�肪�ڕW�l�̂S�����𒴂����ꍇ
            '        dblZanHiAnbun = System.Math.Round(dblMokuhyoChi * (lngZanEigyoHi - gvlngSyukaYoteiHikaku) / lngTouEigyoHi)
            '    End If
            'End If

            'HKKET142F.txtZanHiAnbun.Text = CStr(dblZanHiAnbun)
            'HKKET142F.txtZanDeAnbun.Text = CStr(System.Math.Round(dblMokuhyoChi * lngZanEigyoHi / lngTouEigyoHi))
            'HKKET142F.txtZAN.Text = CStr(lngZanEigyoHi)
            'HKKET142F.txtZEN.Text = CStr(lngTouEigyoHi)
            ''// 2007/07/02 �� ADD END @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

            ''// 2008/04/30 �� ADD STR (�o�[�W�����W�v���́AHKKTRA�̒l��\������)
            'If HKKET141F.optVERSION.Checked = True Then
            '    '//���B�k�s
            '    'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    HKKET142F.txtPRCCD.Text = D0.Chk_NullN(objRec("PRCDD"))
            '    '//���Y�k�s
            '    'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    HKKET142F.txtMNFDD.Text = D0.Chk_NullN(objRec("MNFDD"))
            'End If
            ''// 2008/04/30 �� ADD END

            ''// 2007/03/10 �� DEL STR
            ''        '//���B�k�s
            ''        HKKET142F.txtPRCCD.Text = D0.Chk_NullN(objRec("PRCDD"))
            ''        '//���Y�k�s
            ''        HKKET142F.txtMNFDD.Text = D0.Chk_NullN(objRec("MNFDD"))
            ''// 2007/03/10 �� DEL END

            ''// 2007/01/09 �� ADD STR
            ''//�������Ɏ���
            'HKKET142F.txtTOUNYUKO.Text = CStr(0)
            'For i = 0 To 35
            '    If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
            '        If i + 12 <= 35 Then
            '            HKKET142F.txtTOUNYUKO.Text = CStr(musrHKKZTRA.dblLAST_NDNTRA(i + 12))
            '            Exit For
            '        End If
            '    End If
            'Next i
            ''//�����o�Ɏ���
            'HKKET142F.txtTOUSYUKO.Text = CStr(0)
            'For i = 0 To 35
            '    If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
            '        If i + 12 <= 35 Then
            '            HKKET142F.txtTOUSYUKO.Text = CStr(musrHKKZTRA.dblLAST_ODNTRA(i + 12))
            '            Exit For
            '        End If
            '    End If
            'Next i
            ''// 2007/01/09 �� ADD END

            ''//���݌ɐ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET142F.txtTOUZAISU.Text = D0.Chk_NullN(objRec("TOUZAISU"))
            ''//���l
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET142F.txtHINCM.Text = D0.Chk_Null(objRec("HINCM"))
            ''//����
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET142F.txtMEMO.Text = D0.Chk_Null(objRec("MEMO"))

            '//�i��
            HKKET142F.txtHINNMB.Text = D0.Chk_Null(pDT.Rows(0)("HINNMB"))
            '//�^��
             HKKET142F.txtHINNMA.Text = D0.Chk_Null(pDT.Rows(0)("HINKTA"))
            '//�݌��ݸ
            HKKET142F.txtZAIRNK.Text = D0.Chk_Null(pDT.Rows(0)("ZAIRNK"))
            '//�ŏ�������
            HKKET142F.txtMINSODSU.Text = D0.Chk_NullN(pDT.Rows(0)("MINSODSU"))
            '//����������
            HKKET142F.txtSODADDSU.Text = D0.Chk_NullN(pDT.Rows(0)("SODADDSU"))
            '//���S�݌ɐ�
            HKKET142F.txtANZZAISU.Text = D0.Chk_NullN(pDT.Rows(0)("ANZZAISU"))
            '//���S�݌Ɋ����
            If D0.Chk_NullN(pDT.Rows(0)("LMAAVTS")) = 0 Then
                HKKET142F.txtLMAMSAVTS.Text = CStr(0)
            Else
                HKKET142F.txtLMAMSAVTS.Text = D0.Chg_NumericRound(D0.Chk_NullN(pDT.Rows(0)("ANZZAISU")) / D0.Chk_NullN(pDT.Rows(0)("LMAAVTS")), 3, 3)
            End If
            '//�݌Ɍ���
            For i = 0 To 35
                If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
                    If D0.Chk_NullN(pDT.Rows(0)("LMAAVTS")) = 0 Then
                        HKKET142F.txtLMAAVTS.Text = CStr(0)
                    Else
                         If HKKET141F.optORDER_ON.Checked Then
                            HKKET142F.txtLMAAVTS.Text = D0.Chg_NumericRound((musrHKKZTRA.dblMYOSLST(i) - D0.Chk_NullN(pDT.Rows(0)("ANZZAISU"))) / D0.Chk_NullN(pDT.Rows(0)("LMAAVTS")), 3, 3)
                        Else
                            HKKET142F.txtLMAAVTS.Text = D0.Chg_NumericRound((musrHKKZTRA.dblYOSLST(i) - D0.Chk_NullN(pDT.Rows(0)("ANZZAISU"))) / D0.Chk_NullN(pDT.Rows(0)("LMAAVTS")), 3, 3)
                        End If
                      End If
                    Exit For
                End If
            Next i
            '//���Ϗo�ɐ�
            HKKET142F.txtLMZAVTSA.Text = D0.Chk_NullN(pDT.Rows(0)("LMAAVTS"))
            '//�o�ɕω���
            For i = 0 To 35
                If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
                    If musrHKKZTRA.dblLMAVZS(i) = 0 Then
                        HKKET142F.txtCHGRATE.Text = CStr(0)
                    Else
                         HKKET142F.txtCHGRATE.Text = D0.Chg_NumericRound(musrHKKZTRA.dblLMAVZS(i - 1) / musrHKKZTRA.dblLMAVZS(i), 3, 3)
                    End If
                    Exit For
                End If
            Next i
            '//�ڕW�l�̎擾�i�����v��܂��͔N���v��(�������D��)�j
            If Trim(musrHKKTRA.strLMAHMS(i)) = "" Then
                dblMokuhyoChi = Val(musrHKKTRA.strLMAHKS(i))
            Else
                dblMokuhyoChi = Val(musrHKKTRA.strLMAHMS(i))
            End If
            '//�o�ɗ\��
            dblSyukoYotei = musrHKKZTRA.dblOUTTRA(i)

            '//�c�c�Ɠ��̎擾
            lngZanEigyoHi = Get_EigyoNisu(gvstrUNYDT, Mid(gvstrUNYDT, 1, 6) & "31")

            '//�����c�Ɠ��̎擾
            lngTouEigyoHi = Get_EigyoNisu(Mid(gvstrUNYDT, 1, 6) & "01", Mid(gvstrUNYDT, 1, 6) & "31")

            '//�c�������l
            If lngZanEigyoHi <= gvlngSyukaYoteiHikaku Then
                '//�c�������S���ȉ��̏ꍇ
                dblZanHiAnbun = 0
            Else
                '//�o�ח\���r����������l�����߂�
                If dblSyukoYotei < System.Math.Round(dblMokuhyoChi * gvlngSyukaYoteiHikaku / lngTouEigyoHi) Then
                    '//�o�ɗ\�肪�ڕW�l�̂S�����𒴂��Ȃ��ꍇ
                    dblZanHiAnbun = System.Math.Round(dblMokuhyoChi * lngZanEigyoHi / lngTouEigyoHi)
                Else
                    '//�o�ɗ\�肪�ڕW�l�̂S�����𒴂����ꍇ
                    dblZanHiAnbun = System.Math.Round(dblMokuhyoChi * (lngZanEigyoHi - gvlngSyukaYoteiHikaku) / lngTouEigyoHi)
                End If
            End If

            HKKET142F.txtZanHiAnbun.Text = CStr(dblZanHiAnbun)
            HKKET142F.txtZanDeAnbun.Text = CStr(System.Math.Round(dblMokuhyoChi * lngZanEigyoHi / lngTouEigyoHi))
            HKKET142F.txtZAN.Text = CStr(lngZanEigyoHi)
            HKKET142F.txtZEN.Text = CStr(lngTouEigyoHi)

            If HKKET141F.optVERSION.Checked = True Then
                '//���B�k�s
                HKKET142F.txtPRCCD.Text = D0.Chk_NullN(pDT.Rows(0)("PRCDD"))
                '//���Y�k�s
                HKKET142F.txtMNFDD.Text = D0.Chk_NullN(pDT.Rows(0)("MNFDD"))
            End If
            '//�������Ɏ���
            HKKET142F.txtTOUNYUKO.Text = CStr(0)
            For i = 0 To 35
                If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
                    If i + 12 <= 35 Then
                        HKKET142F.txtTOUNYUKO.Text = CStr(musrHKKZTRA.dblLAST_NDNTRA(i + 12))
                        Exit For
                    End If
                End If
            Next i
            '//�����o�Ɏ���
            HKKET142F.txtTOUSYUKO.Text = CStr(0)
            For i = 0 To 35
                If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
                    If i + 12 <= 35 Then
                        HKKET142F.txtTOUSYUKO.Text = CStr(musrHKKZTRA.dblLAST_ODNTRA(i + 12))
                        Exit For
                    End If
                End If
            Next i
           
            '//���݌ɐ�
            HKKET142F.txtTOUZAISU.Text = D0.Chk_NullN(pDT.Rows(0)("TOUZAISU"))
            '//���l
            HKKET142F.txtHINCM.Text = D0.Chk_Null(pDT.Rows(0)("HINCM"))
            '//����
            HKKET142F.txtMEMO.Text = D0.Chk_Null(pDT.Rows(0)("MEMO"))
            '2019/04/15 CHG E N D
        Else
            '//�ŏ�������
            HKKET142F.txtMINSODSU.Text = CStr(0)
            '//����������
            HKKET142F.txtSODADDSU.Text = CStr(0)
            '//���S�݌ɐ�
            HKKET142F.txtANZZAISU.Text = CStr(0)
            '//���S�݌Ɋ����
            HKKET142F.txtLMAMSAVTS.Text = CStr(0)
            '//�݌Ɍ���
            HKKET142F.txtLMAAVTS.Text = CStr(0)
            '//���Ϗo�ɐ�
            HKKET142F.txtLMZAVTSA.Text = CStr(0)
            '//�o�ɕω���
            HKKET142F.txtCHGRATE.Text = CStr(0)
            '//���B�k�s
            HKKET142F.txtPRCCD.Text = CStr(0)
            '//���Y�k�s
            HKKET142F.txtMNFDD.Text = CStr(0)
            '//���݌ɐ�
            HKKET142F.txtTOUZAISU.Text = CStr(0)
            '//���l
            HKKET142F.txtHINCM.Text = vbNullString
            '//����
            HKKET142F.txtMEMO.Text = vbNullString

            '// 2008/04/30 �� ADD STR (�o�[�W�����W�v���́AHKKTRA�̒l��\������)
            If HKKET141F.optVERSION.Checked = True Then
                '//���B�k�s
                HKKET142F.txtPRCCD.Text = CStr(0)
                '//���Y�k�s
                HKKET142F.txtMNFDD.Text = CStr(0)
            End If
            '// 2008/04/30 �� ADD END

        End If

        '// 2007/02/24 �� ADD END
        If strHKKTRA_DAY > strODINTRA_DAY Then
            HKKET142F.txtWRTDTTM.Text = strHKKTRA_DAY
        Else
            HKKET142F.txtWRTDTTM.Text = strODINTRA_DAY
        End If
        '// 2007/02/24 �� ADD END

        Set_HKKZTRA_M = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Set_HKKTRA
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*            objRec              OraDynaset       I
	'//*
	'//* <��  ��>
	'//*    �̔��v��e�\��
	'//*****************************************************************************************
    '2019/04/15 CHG START
    'Public Function Set_HKKTRA(ByRef objRec As OraDynaset) As Boolean
    Public Function Set_HKKTRA(ByRef pDT As DataTable) As Boolean
        '2019/04/15 CHG E N D

        Const PROCEDURE As String = "Set_HKKTRA"

        Dim i As Short
        Dim j As Short

        Set_HKKTRA = False

        On Error GoTo ONERR_STEP

        '//�N���v��/�����v��
        i = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraEOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If pDT IsNot Nothing AndAlso pDT.Rows.Count > 0 Then
            '2019/04/15 CHG E N D

            '2019/04/15 ADD START
            Dim row As DataRow = pDT.Rows(0)
            '2019/04/15 ADD E N D
            Do
                ReDim Preserve musrHKKTRA.strLMAHKS(i)
                ReDim Preserve musrHKKTRA.strLMAHKS_ORG(i)
                ReDim Preserve musrHKKTRA.strLMAHMS(i)
                ReDim Preserve musrHKKTRA.strLMAHMS_ORG(i)
                ReDim Preserve musrHKKTRA.strLMZPNO(i)
                '// 2007/01/09 �� ADD STR
                ReDim Preserve musrHKKTRA.strLMAPDT(i)
                ReDim Preserve musrHKKTRA.intLTKBN(i)
                '// 2007/01/09 �� ADD END
                '2019/04/15 CHG START
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKTRA.strLMAHKS(i) = D0.Chk_Null(objRec(i))
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKTRA.strLMAHKS_ORG(i) = D0.Chk_Null(objRec(i))
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKTRA.strLMAHMS(i) = D0.Chk_Null(objRec(i + 36))
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKTRA.strLMAHMS_ORG(i) = D0.Chk_Null(objRec(i + 36))
                ''// 2006/11/13 �� ADD STR
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKTRA.strLMZPNO(i) = D0.Chk_Null(objRec(i + 72))
                ''// 2006/11/13 �� ADD END
                ''// 2007/01/09 �� ADD STR
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'musrHKKTRA.strLMAPDT(i) = D0.Chk_Null(objRec(i + 108))
                'musrHKKTRA.intLTKBN(i) = 0
                ''// 2007/01/09 �� ADD END
                musrHKKTRA.strLMAHKS(i) = D0.Chk_Null(row(i))
                musrHKKTRA.strLMAHKS_ORG(i) = D0.Chk_Null(row(i))
                musrHKKTRA.strLMAHMS(i) = D0.Chk_Null(row(i + 36))
                musrHKKTRA.strLMAHMS_ORG(i) = D0.Chk_Null(row(i + 36))
                musrHKKTRA.strLMZPNO(i) = D0.Chk_Null(row(i + 72))
                musrHKKTRA.strLMAPDT(i) = D0.Chk_Null(row(i + 108))
                musrHKKTRA.intLTKBN(i) = 0
                '2019/04/15 CHG E N D
                i = i + 1
                If i = 36 Then
                    Exit Do
                End If
            Loop
            '// 2007/02/24 �� ADD END
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/15 CHG START
            'strHKKTRA_DAY = Mid(Right(Space(8) & D0.Chk_Null(objRec(145 - 1)), 8), 1, 4) & "/" & Mid(Right(Space(8) & D0.Chk_Null(objRec(145 - 1)), 8), 5, 2) & "/" & Mid(Right(Space(8) & D0.Chk_Null(objRec(145 - 1)), 8), 7, 2) & " " & Mid(Right(Space(6) & D0.Chk_Null(objRec(146 - 1)), 6), 1, 2) & ":" & Mid(Right(Space(6) & D0.Chk_Null(objRec(146 - 1)), 6), 3, 2) & ":" & Mid(Right(Space(6) & D0.Chk_Null(objRec(146 - 1)), 6), 5, 2)
            strHKKTRA_DAY = Mid(Right(Space(8) & D0.Chk_Null(row(145 - 1)), 8), 1, 4) _
                          & "/" & Mid(Right(Space(8) & D0.Chk_Null(row(145 - 1)), 8), 5, 2) _
                          & "/" & Mid(Right(Space(8) & D0.Chk_Null(row(145 - 1)), 8), 7, 2) _
                          & " " & Mid(Right(Space(6) & D0.Chk_Null(row(146 - 1)), 6), 1, 2) _
                          & ":" & Mid(Right(Space(6) & D0.Chk_Null(row(146 - 1)), 6), 3, 2) _
                          & ":" & Mid(Right(Space(6) & D0.Chk_Null(row(146 - 1)), 6), 5, 2)
            '2019/04/15 CHG E N D
            '// 2007/02/24 �� ADD END
        Else
            Do
                ReDim Preserve musrHKKTRA.strLMAHKS(i)
                ReDim Preserve musrHKKTRA.strLMAHKS_ORG(i)
                ReDim Preserve musrHKKTRA.strLMAHMS(i)
                ReDim Preserve musrHKKTRA.strLMAHMS_ORG(i)
                ReDim Preserve musrHKKTRA.strLMZPNO(i)
                '// 2007/01/09 �� ADD STR
                ReDim Preserve musrHKKTRA.strLMAPDT(i)
                ReDim Preserve musrHKKTRA.intLTKBN(i)
                '// 2007/01/09 �� ADD END
                musrHKKTRA.strLMAHKS(i) = " "
                musrHKKTRA.strLMAHKS_ORG(i) = " "
                musrHKKTRA.strLMAHMS(i) = " "
                musrHKKTRA.strLMAHMS_ORG(i) = " "
                '// 2006/11/13 �� ADD STR
                musrHKKTRA.strLMZPNO(i) = " "
                '// 2006/11/13 �� ADD END
                '// 2007/01/09 �� ADD STR
                musrHKKTRA.strLMAPDT(i) = " "
                musrHKKTRA.intLTKBN(i) = 0
                '// 2007/01/09 �� ADD END
                i = i + 1
                If i = 36 Then
                    Exit Do
                End If
            Loop
            '// 2007/02/24 �� ADD END
            strHKKTRA_DAY = Space(19)
            '// 2007/02/24 �� ADD END
        End If
        Set_HKKTRA = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Set_ODINTRA
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*            objRec              OraDynaset       I
	'//*
	'//* <��  ��>
	'//*    ���Ɏw�����\��
	'//*****************************************************************************************
	Public Function Set_ODINTRA(ByRef objRec As OraDynaset) As Boolean
		
		Const PROCEDURE As String = "Set_ODINTRA"
		
		Dim i As Short
		Dim j As Short
		
		Set_ODINTRA = False
		
		On Error GoTo ONERR_STEP
		
		i = gvlngNowPage
		Do 
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			HKKET142F.txtLMZNOSS(j).Text = D0.Chk_Null(objRec(i + 1))
			i = i + 1
			j = j + 1
			If j = 13 Then
				Exit Do
			End If
		Loop 
		
		Set_ODINTRA = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Upd_Main
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    �X�V����
	'//*****************************************************************************************
    Public Function Upd_Main(Optional ByRef pstr_FileName As String = "") As Boolean
        '2019/04/19 DEL START
        'Dim ORAPARM_OUTPUT As Object
        'Dim ORATYPE_NUMBER As Object
        'Dim gvstrCLTID As Object
        'Dim ORATYPE_CHAR As Object
        'Dim ORAPARM_INPUT As Object
        'Dim gvstrOPEID As Object
        '2019/04/19 DEL E N D

        Const PROCEDURE As String = "Upd_Main"

        '2019/04/19 DEL START
        'Dim wCNT As Integer
        '2019/04/19 DEL E N D
        '2019/04/19 DEL START
        'Dim i As Integer
        '2019/04/19 DEL E N D
        Dim intRtnCd As Short
        '2019/04/19 DEL START
        'Dim OraPArray1 As Object
        'Dim OraPArray2 As Object
        'Dim OraPArray3 As Object
        'Dim OraPArray4 As Object
        ''// 2007/01/09 �� ADD STR
        'Dim OraPArray5 As Object
        'Dim OraPArray6 As Object
        'Dim OraPArray7 As Object
        'Dim OraPArray8 As Object
        ''// 2007/01/09 �� ADD END
        ''// V2.20�� ADD
        'Dim OraPArray9 As Object '//�D��t���O�p
        ''// V2.20�� ADD
        '2019/04/19 DEL E N D

        Upd_Main = False

        On Error GoTo ONERR_STEP

        '2019/04/19 ADD START
        Dim cmd As New OracleCommand
        cmd.Connection = CON
        cmd.CommandType = CommandType.StoredProcedure
        'cmd.CommandText = "BEGIN :RTNCD  := HKKET14.HKKET14B( " _
        '                & " :P_OPEID       " _
        '                & ",:P_CLTID       " _
        '                & ",:P_HINCD       " _
        '                & ",:P_VERFL       " _
        '                & ",:P_YM          " _
        '                & ",:P_HKKTRA      " _
        '                & ",:P_HKS         " _
        '                & ",:P_HMS         " _
        '                & ",:P_LMZNOS      " _
        '                & ",:P_NOS         " _
        '                & ",:P_YZS         " _
        '                & ",:P_MZS         " _
        '                & ",:P_INPS        " _
        '                & ",:P_NPS         " _
        '                & ",:P_NPF         " _
        '                & ",:P_HKKET_PATH  " _
        '                & ",:P_HKKET_FILE  " _
        '                & ",:P_ORDER_PATH  " _
        '                & ",:P_ORDER_FILE  " _
        '                & ",:P_MEMO        " _
        '                & ",:P_JNL_PATH    " _
        '                & ",:P_JNL_FILE    " _
        '                & ");              " _
        '                & "END;"
        cmd.CommandText = "HKKET14.HKKET14B"
        '2019/04/19 ADD E N D

        '2019/04/19 DEL START
        'wCNT = 37
        '2019/04/19 DEL E N D
 
        '//��ƒS����
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Add("P_OPEID", gvstrOPEID, ORAPARM_INPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("P_OPEID").serverType = ORATYPE_CHAR
        Dim inP_OPEID As OracleParameter = New OracleParameter("P_OPEID", OracleDbType.Char, ParameterDirection.Input)
        inP_OPEID.Value = gvstrOPEID
        cmd.Parameters.Add(inP_OPEID)
        '2019/04/19 CHG E N D

        '//�[��ID
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Add("P_CLTID", gvstrCLTID, ORAPARM_INPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("P_CLTID").serverType = ORATYPE_CHAR
        Dim inP_CLTID As OracleParameter = New OracleParameter("P_CLTID", OracleDbType.Char, ParameterDirection.Input)
        inP_CLTID.Value = gvstrCLTID
        cmd.Parameters.Add(inP_CLTID)
        '2019/04/19 CHG E N D

        '//���i�R�[�h
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Add("P_HINCD", HKKET142F.txtHINCD, ORAPARM_INPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("P_HINCD").serverType = ORATYPE_CHAR
        Dim inP_HINCD As OracleParameter = New OracleParameter("P_HINCD", OracleDbType.Char, ParameterDirection.Input)
        inP_HINCD.Value = HKKET142F.txtHINCD.Text
        cmd.Parameters.Add(inP_HINCD)
        '2019/04/19 CHG E N D

        '//�ް�ޮݏW�v:1����0�Ȃ�
        '2019/04/19 CHG START
        'If Not HKKET141F.optVERSION.Checked Or gvblnInputFlg Then
        '    'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    clsOra.OraDatabase.Parameters.Add("P_VERFL", "0", ORAPARM_INPUT)
        'Else
        '    'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    clsOra.OraDatabase.Parameters.Add("P_VERFL", "1", ORAPARM_INPUT)
        'End If
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("P_VERFL").serverType = ORATYPE_CHAR
        Dim inP_VERFL As OracleParameter = New OracleParameter("P_VERFL", OracleDbType.Char, ParameterDirection.Input)
        If Not HKKET141F.optVERSION.Checked Or gvblnInputFlg Then
            inP_VERFL.Value = "0"
        Else
            inP_VERFL.Value = "1"
        End If
        cmd.Parameters.Add(inP_VERFL)
        '2019/04/19 CHG E N D

        '//�\���N��
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.AddTable("P_YM", ORAPARM_INPUT, ORATYPE_CHAR, wCNT, 6)
        Dim inP_YM As OracleParameter = New OracleParameter("P_YM", OracleDbType.Char, ParameterDirection.Input)
        inP_YM.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inP_YM.Size = musrHKKZTRA.strDSPMONTH.Length
        inP_YM.ArrayBindSize = New Integer(inP_YM.Size - 1) {}
        For cnt As Integer = 0 To inP_YM.Size - 1
            inP_YM.ArrayBindSize(cnt) = 6
        Next
        inP_YM.Value = musrHKKZTRA.strDSPMONTH
        cmd.Parameters.Add(inP_YM)
        '2019/04/19 CHG E N D

        '//�N���v��ύX:1����0�Ȃ� 
        '2019/04/19 CHG START
        'If intNensyoImportMode = 1 Then
        '    'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    clsOra.OraDatabase.Parameters.Add("P_HKKTRA", "1", ORAPARM_INPUT)
        'Else
        '    If gvblnLMAHMS Then
        '        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        clsOra.OraDatabase.Parameters.Add("P_HKKTRA", "1", ORAPARM_INPUT)
        '    Else
        '        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        clsOra.OraDatabase.Parameters.Add("P_HKKTRA", "0", ORAPARM_INPUT)
        '    End If
        'End If
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("P_HKKTRA").serverType = ORATYPE_CHAR
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Dim inP_HKKTRA As OracleParameter = New OracleParameter("P_HKKTRA", OracleDbType.Char, ParameterDirection.Input)
        If intNensyoImportMode = 1 Then
            inP_HKKTRA.Value = "1"
        Else
            If gvblnLMAHMS Then
                inP_HKKTRA.Value = "1"
            Else
                inP_HKKTRA.Value = "0"
            End If
        End If
        cmd.Parameters.Add(inP_HKKTRA)
        '2019/04/19 CHG E N D

        '//�N���v��ύX
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.AddTable("P_HKS", ORAPARM_INPUT, ORATYPE_CHAR, wCNT, 10)
        Dim inP_HKS As OracleParameter = New OracleParameter("P_HKS", OracleDbType.Char, ParameterDirection.Input)
        inP_HKS.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inP_HKS.Size = musrHKKTRA.strLMAHKS.Length
        inP_HKS.ArrayBindSize = New Integer(inP_HKS.Size - 1) {}
        For cnt As Integer = 0 To inP_HKS.Size - 1
            inP_HKS.ArrayBindSize(cnt) = 10
            ReDim Preserve inP_HKS.Value(cnt)
            If musrHKKTRA.strLMAHKS(cnt) = "" Then
                inP_HKS.Value(cnt) = Space(10)
            Else
                inP_HKS.Value(cnt) = musrHKKTRA.strLMAHKS(cnt)
            End If
        Next
        cmd.Parameters.Add(inP_HKS)
        '2019/04/19 CHG E N D

        '//�������v�搔
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.AddTable("P_HMS", ORAPARM_INPUT, ORATYPE_CHAR, wCNT, 10)
        Dim inP_HMS As OracleParameter = New OracleParameter("P_HMS", OracleDbType.Char, ParameterDirection.Input)
        inP_HMS.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inP_HMS.Size = musrHKKTRA.strLMAHMS.Length
        inP_HMS.ArrayBindSize = New Integer(inP_HMS.Size - 1) {}
        For cnt As Integer = 0 To inP_HMS.Size - 1
            inP_HMS.ArrayBindSize(cnt) = 10
            ReDim Preserve inP_HMS.Value(cnt)
            If musrHKKTRA.strLMAHMS(cnt) = "" Then
                inP_HMS.Value(cnt) = Space(10)
            Else
                inP_HMS.Value(cnt) = musrHKKTRA.strLMAHMS(cnt)
            End If
        Next
        cmd.Parameters.Add(inP_HMS)
        '2019/04/19 CHG E N D

        '//���Ɏw�����ύX:1����0�Ȃ� 
        '2019/04/19 CHG START
        'If intNensyoImportMode = 1 Then
        '    'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    clsOra.OraDatabase.Parameters.Add("P_LMZNOS", "1", ORAPARM_INPUT)
        'Else
        '    If gvblnLMZNOS Then
        '        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        clsOra.OraDatabase.Parameters.Add("P_LMZNOS", "1", ORAPARM_INPUT)
        '    Else
        '        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        clsOra.OraDatabase.Parameters.Add("P_LMZNOS", "0", ORAPARM_INPUT)
        '    End If
        'End If
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("P_LMZNOS").serverType = ORATYPE_CHAR
        Dim inP_LMZNOS As OracleParameter = New OracleParameter("P_LMZNOS", OracleDbType.Char, ParameterDirection.Input)
        If intNensyoImportMode = 1 Then
            inP_LMZNOS.Value = "1"

        Else
            If gvblnLMZNOS Then
                inP_LMZNOS.Value = "1"

            Else
                inP_LMZNOS.Value = "0"

            End If
        End If
        cmd.Parameters.Add(inP_LMZNOS)
        '2019/04/19 CHG E N D

        '//���Ɏw����
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.AddTable("P_NOS", ORAPARM_INPUT, ORATYPE_CHAR, wCNT, 10)
        Dim inP_NOS As OracleParameter = New OracleParameter("P_NOS", OracleDbType.Char, ParameterDirection.Input)
        inP_NOS.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inP_NOS.Size = musrODINTRA.strLMZNOSS.Length
        inP_NOS.ArrayBindSize = New Integer(inP_NOS.Size - 1) {}
        For cnt As Integer = 0 To inP_NOS.Size - 1
            inP_NOS.ArrayBindSize(cnt) = 10
            ReDim Preserve inP_NOS.Value(cnt)
            If musrODINTRA.strLMZNOSS(cnt) = "" Then
                inP_NOS.Value(cnt) = Space(10)
            Else
                inP_NOS.Value(cnt) = musrODINTRA.strLMZNOSS(cnt)
            End If
        Next
        cmd.Parameters.Add(inP_NOS)
        '2019/04/19 CHG E N D

        '//�\�������݌�
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.AddTable("P_YZS", ORAPARM_INPUT, ORATYPE_NUMBER, wCNT, 10)
        Dim inP_YZS As OracleParameter = New OracleParameter("P_YZS", OracleDbType.Decimal, ParameterDirection.Input)
        inP_YZS.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inP_YZS.Size = musrHKKZTRA.dblYOSLST.Length
        inP_YZS.ArrayBindSize = New Integer(inP_YZS.Size - 1) {}
        For cnt As Integer = 0 To inP_YZS.Size - 1
            inP_YZS.ArrayBindSize(cnt) = 10
        Next
        inP_YZS.Value = musrHKKZTRA.dblYOSLST
        cmd.Parameters.Add(inP_YZS)
        '2019/04/19 CHG E N D

        '//�����\�������݌�
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.AddTable("P_MZS", ORAPARM_INPUT, ORATYPE_NUMBER, wCNT, 10)
        Dim inP_MZS As OracleParameter = New OracleParameter("P_MZS", OracleDbType.Decimal, ParameterDirection.Input)
        inP_MZS.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inP_MZS.Size = musrHKKZTRA.dblMYOSLST.Length
        inP_MZS.ArrayBindSize = New Integer(inP_MZS.Size - 1) {}
        For cnt As Integer = 0 To inP_MZS.Size - 1
            inP_MZS.ArrayBindSize(cnt) = 10
        Next
        inP_MZS.Value = musrHKKZTRA.dblMYOSLST
        cmd.Parameters.Add(inP_MZS)

        '//���Ɍv�搔�i���́j
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.AddTable("P_INPS", ORAPARM_INPUT, ORATYPE_CHAR, wCNT, 10)
        Dim inP_INPS As OracleParameter = New OracleParameter("P_INPS", OracleDbType.Char, ParameterDirection.Input)
        inP_INPS.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inP_INPS.Size = musrODINTRA.strINPPLAN.Length
        inP_INPS.ArrayBindSize = New Integer(inP_INPS.Size - 1) {}
        For cnt As Integer = 0 To inP_INPS.Size - 1
            inP_INPS.ArrayBindSize(cnt) = 10
        Next
        inP_INPS.Value = musrODINTRA.strINPPLAN
        cmd.Parameters.Add(inP_INPS)
        '2019/04/19 CHG E N D

        '//���Ɍv�搔�i�\���j
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.AddTable("P_NPS", ORAPARM_INPUT, ORATYPE_NUMBER, wCNT, 10)
        Dim inP_NPS As OracleParameter = New OracleParameter("P_NPS", OracleDbType.Decimal, ParameterDirection.Input)
        inP_NPS.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inP_NPS.Size = musrODINTRA.dblDspINPPLAN.Length
        inP_NPS.ArrayBindSize = New Integer(inP_NPS.Size - 1) {}
        For cnt As Integer = 0 To inP_NPS.Size - 1
            inP_NPS.ArrayBindSize(cnt) = 10
        Next
        inP_NPS.Value = musrODINTRA.dblDspINPPLAN
        cmd.Parameters.Add(inP_NPS)
        '2019/04/19 CHG E N D

        '//�D��t���O
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.AddTable("P_NPF", ORAPARM_INPUT, ORATYPE_CHAR, wCNT, 4)
        Dim inP_NPF As OracleParameter = New OracleParameter("P_NPF", OracleDbType.Char, ParameterDirection.Input)
        inP_NPF.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inP_NPF.Size = musrODINTRA.strLMZNPF.Length
        inP_NPF.ArrayBindSize = New Integer(inP_NPF.Size - 1) {}
        For cnt As Integer = 0 To inP_NPF.Size - 1
            inP_NPF.ArrayBindSize(cnt) = 4
            ReDim Preserve inP_NPF.Value(cnt)
            inP_NPF.Value(cnt) = Mid(Trim(musrODINTRA.strLMZNPF(cnt)) & "    ", 1, 4)
        Next
        cmd.Parameters.Add(inP_NPF)
        '2019/04/19 CHG E N D

        '//�t�@�C���p�X
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Add("P_HKKET_PATH", gvstrFilePath5, ORAPARM_INPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("P_HKKET_PATH").serverType = ORATYPE_CHAR
        Dim inP_HKKET_PATH As OracleParameter = New OracleParameter("P_HKKET_PATH", OracleDbType.Varchar2, ParameterDirection.Input)
        inP_HKKET_PATH.Value = gvstrFilePath5
        cmd.Parameters.Add(inP_HKKET_PATH)
        '2019/04/19 CHG E N D

        '//�t�@�C���h�c
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Add("P_HKKET_FILE", gvstrFileName5 & VB6.Format(Now, "YYYYMMDD") & ".CSV", ORAPARM_INPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("P_HKKET_FILE").serverType = ORATYPE_CHAR
        Dim inP_HKKET_FILE As OracleParameter = New OracleParameter("P_HKKET_FILE", OracleDbType.Varchar2, ParameterDirection.Input)
        inP_HKKET_FILE.Value = gvstrFileName5 & VB6.Format(Now, "YYYYMMDD") & ".CSV"
        cmd.Parameters.Add(inP_HKKET_FILE)
        '2019/04/19 CHG E N D

        '//�t�@�C���p�X
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Add("P_ORDER_PATH", gvstrFilePath6, ORAPARM_INPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("P_ORDER_PATH").serverType = ORATYPE_CHAR
        Dim inP_ORDER_PATH As OracleParameter = New OracleParameter("P_ORDER_PATH", OracleDbType.Varchar2, ParameterDirection.Input)
        inP_ORDER_PATH.Value = gvstrFilePath6
        cmd.Parameters.Add(inP_ORDER_PATH)
        '2019/04/19 CHG E N D

        '//�t�@�C���h�c
        pstr_FileName = gvstrFileName6 & "_" & HKKET142F.txtHINCD.Text & "_" & VB6.Format(Now, "YYYYMMDD") & "_" & VB6.Format(Now, "HHMMSS") & ".CSV"
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Add("P_ORDER_FILE", pstr_FileName, ORAPARM_INPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("P_ORDER_FILE").serverType = ORATYPE_CHAR
        Dim inP_ORDER_FILE As OracleParameter = New OracleParameter("P_ORDER_FILE", OracleDbType.Varchar2, ParameterDirection.Input)
        inP_ORDER_FILE.Value = pstr_FileName
        cmd.Parameters.Add(inP_ORDER_FILE)
        '2019/04/19 CHG E N D

        '//����
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Add("P_MEMO", HKKET142F.txtMEMO.Text, ORAPARM_INPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("P_MEMO").serverType = ORATYPE_CHAR
        Dim inP_MEMO As OracleParameter = New OracleParameter("P_MEMO", OracleDbType.Char, ParameterDirection.Input)
        inP_MEMO.Value = HKKET142F.txtMEMO.Text
        cmd.Parameters.Add(inP_MEMO)
        '2019/04/19 CHG E N D

        '//�t�@�C���p�X
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Add("P_JNL_PATH", gvstrFilePath7, ORAPARM_INPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("P_JNL_PATH").serverType = ORATYPE_CHAR
        Dim inP_JNL_PATH As OracleParameter = New OracleParameter("P_JNL_PATH", OracleDbType.Varchar2, ParameterDirection.Input)
        inP_JNL_PATH.Value = gvstrFilePath7
        cmd.Parameters.Add(inP_JNL_PATH)
        '2019/04/19 CHG E N D

        '//�t�@�C���h�c
        pstr_FileName = gvstrFileName7 & "_" & VB6.Format(Now, "YYYYMM") & ".CSV"
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Add("P_JNL_FILE", pstr_FileName, ORAPARM_INPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("P_JNL_FILE").serverType = ORATYPE_CHAR
        Dim inP_JNL_FILE As OracleParameter = New OracleParameter("P_JNL_FILE", OracleDbType.Varchar2, ParameterDirection.Input)
        inP_JNL_FILE.Value = pstr_FileName
        cmd.Parameters.Add(inP_JNL_FILE)
        '2019/04/19 CHG E N D

        '//�߂�l
        intRtnCd = 0
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Add("RTNCD", intRtnCd, ORAPARM_OUTPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_NUMBER �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("RTNCD").serverType = ORATYPE_NUMBER
        'change start 20190925 kuwa test
        'Dim outRTNCD As OracleParameter = New OracleParameter("RTNCD", OracleDbType.Decimal, ParameterDirection.Output)
        Dim outRTNCD As OracleParameter = New OracleParameter("RTNCD", OracleDbType.Decimal, ParameterDirection.ReturnValue)
        'change end 20190925 kuwa
        'add test start 20190925 kuwa
        outRTNCD.Value = 0
        'add end 20190925 kuwa
        cmd.Parameters.Add(outRTNCD)
        '2019/04/19 CHG E N D 

        '2019/04/19 DEL START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'OraPArray1 = clsOra.OraDatabase.Parameters("P_YM")
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'OraPArray2 = clsOra.OraDatabase.Parameters("P_HKS")
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'OraPArray3 = clsOra.OraDatabase.Parameters("P_HMS")
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'OraPArray4 = clsOra.OraDatabase.Parameters("P_NOS")
        ''// 2007/01/09 �� ADD STR
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'OraPArray5 = clsOra.OraDatabase.Parameters("P_YZS")
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'OraPArray6 = clsOra.OraDatabase.Parameters("P_MZS")
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'OraPArray7 = clsOra.OraDatabase.Parameters("P_INPS")
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'OraPArray8 = clsOra.OraDatabase.Parameters("P_NPS")
        ''// 2007/01/09 �� ADD END
        ''// V2.20�� ADD
        ''//�D��t���O
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'OraPArray9 = clsOra.OraDatabase.Parameters("P_NPF")
        ''// V2.20�� ADD
        '2019/04/19 DEL E N D

        '2019/04/19 DEL START
        'For i = LBound(musrHKKZTRA.strDSPMONTH) To UBound(musrHKKZTRA.strDSPMONTH)
        '    '//�\���N��
        '    'UPGRADE_WARNING: �I�u�W�F�N�g OraPArray1.put_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    OraPArray1.put_Value(musrHKKZTRA.strDSPMONTH(i), i)
        '    '//�N���v��
        '    'UPGRADE_WARNING: �I�u�W�F�N�g OraPArray2.put_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    OraPArray2.put_Value(musrHKKTRA.strLMAHKS(i), i)
        '    '//�����v��
        '    'UPGRADE_WARNING: �I�u�W�F�N�g OraPArray3.put_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    OraPArray3.put_Value(musrHKKTRA.strLMAHMS(i), i)
        '    '//���Ɏw����
        '    'UPGRADE_WARNING: �I�u�W�F�N�g OraPArray4.put_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    OraPArray4.put_Value(musrODINTRA.strLMZNOSS(i), i)
        '    '// 2007/01/09 �� ADD STR
        '    '//�\�������݌�
        '    'UPGRADE_WARNING: �I�u�W�F�N�g OraPArray5.put_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    OraPArray5.put_Value(musrHKKZTRA.dblYOSLST(i), i)
        '    '//�O���\�������݌�
        '    'UPGRADE_WARNING: �I�u�W�F�N�g OraPArray6.put_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    OraPArray6.put_Value(musrHKKZTRA.dblMYOSLST(i), i)
        '    '//���Ɍv�搔
        '    'UPGRADE_WARNING: �I�u�W�F�N�g OraPArray7.put_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    OraPArray7.put_Value(musrODINTRA.strINPPLAN(i), i)
        '    '//���Ɍv�搔
        '    'UPGRADE_WARNING: �I�u�W�F�N�g OraPArray8.put_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    OraPArray8.put_Value(musrODINTRA.dblDspINPPLAN(i), i)
        '    '// 2007/01/09 �� ADD END
        '    '// V2.20�� ADD
        '    '//�D��t���O
        '    'UPGRADE_WARNING: �I�u�W�F�N�g OraPArray9.put_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    OraPArray9.put_Value(Mid(Trim(musrODINTRA.strLMZNPF(i)) & "    ", 1, 4), i)
        '    '// V2.20�� ADD
        'Next i
        '2019/04/19 DEL E N D

        '//PL/SQL���ĂԁiMAIN�j
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraExecute �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'If Not clsOra.OraExecute("BEGIN :RTNCD  := HKKET14.HKKET14B( " & " :P_OPEID ,:P_CLTID ,:P_HINCD ,:P_VERFL " & ",:P_YM          " & ",:P_HKKTRA      " & ",:P_HKS         " & ",:P_HMS         " & ",:P_LMZNOS      " & ",:P_NOS         " & ",:P_YZS         " & ",:P_MZS         " & ",:P_INPS        " & ",:P_NPS         " & ",:P_NPF         " & ",:P_HKKET_PATH  " & ",:P_HKKET_FILE  " & ",:P_ORDER_PATH  " & ",:P_ORDER_FILE  " & ",:P_MEMO        " & ",:P_JNL_PATH    " & ",:P_JNL_FILE    " & ");              " & "END;", , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        cmd.ExecuteNonQuery()
        '2019/04/19 CHG E N D
 
        '//�߂�l�ُ�
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'If clsOra.OraDatabase.Parameters("RTNCD").Value <> 0 Then
        '    GoTo EXIT_STEP
        'End If
        If outRTNCD.Value.ToString <> 0 Then
            GoTo EXIT_STEP
        End If
        '2019/04/19 CHG E N D 

        Upd_Main = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        '//���Ұ��̸ر
        '2019/04/19 CHG START
        ''//�߂�l
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("RTNCD")
        ''//��ƒS����
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_OPEID")
        ''//�[��ID
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_CLTID")
        ''//���i�R�[�h
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_HINCD")
        ''//�ް�ޮݏW�v:1����0�Ȃ�
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_VERFL")
        ''//�\���N��
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_YM")
        ''//�N���v��ύX:1����0�Ȃ�
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_HKKTRA")
        ''//�N���v��
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_HKS")
        ''//�����v��
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_HMS")
        ''//���Ɏw�����ύX:1����0�Ȃ�
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_LMZNOS")
        ''//���Ɏw����
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_NOS")
        ''// 2007/01/09 �� ADD STR
        ''//�\�������݌ɐ�
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_YZS")
        ''//�����\�������݌ɐ�
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_MZS")
        ''//���Ɍv�搔�i���́j
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_INPS")
        ''//���Ɍv�搔�i�\���j
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_NPS")
        ''// 2007/01/09 �� ADD END
        ''// V2.20�� ADD
        ''//�D��t���O
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_NPF")
        ''// V2.20�� ADD
        ''//�t�@�C���p�X
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_HKKET_PATH")
        ''//�t�@�C���h�c
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_HKKET_FILE")
        ''//�t�@�C���p�X
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_ORDER_PATH")
        ''//�t�@�C���h�c
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_ORDER_FILE")
        ''//�t�@�C���h�c
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_MEMO")
        ''// V2.30�� ADD
        ''//�t�@�C���p�X
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_JNL_PATH")
        ''//�t�@�C���h�c
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("P_JNL_FILE")
        ''// V2.30�� ADD
        ''//�߂�l
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("RTNCD")
        cmd.Parameters.Clear()
        '2019/04/19 CHG E N D

        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
	
	'// 2008/05/27 �� ADD END �v��P���̎擾
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Get_KEIKAKUTANKA
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    �ް�ޮݏW�v���Ɍv��P�����擾����
	'//*****************************************************************************************
	Public Function Get_KEIKAKUTANKA() As Boolean
		
		Const PROCEDURE As String = "Get_KEIKAKUTANKA"
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim objRec As OraDynaset
		
		Get_KEIKAKUTANKA = False
		
		On Error GoTo ONERR_STEP
		
		' SQL���̍쐬
		strSQL = ""
		strSQL = strSQL & " SELECT HINMTA.PLANTK PLANTK" & vbCrLf
		strSQL = strSQL & " FROM   ( " & vbCrLf
		strSQL = strSQL & "         SELECT * " & vbCrLf
		strSQL = strSQL & "         FROM   ( " & vbCrLf
		strSQL = strSQL & "                 SELECT * " & vbCrLf
		strSQL = strSQL & "                 FROM   HKKZTRA " & vbCrLf
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "                 WHERE  HINCD LIKE " & D0.Edt_SQL("S", Trim(Mid(HKKET142F.txtHINCD.Text, 1, 6)) & "%") & vbCrLf
		strSQL = strSQL & "                   AND  VERFL = 0" & vbCrLf
		strSQL = strSQL & "                 ORDER BY HINCD DESC" & vbCrLf
		strSQL = strSQL & "                ) V1" & vbCrLf
		strSQL = strSQL & "         WHERE  ROWNUM = 1" & vbCrLf
		strSQL = strSQL & "        ) V2" & vbCrLf
		strSQL = strSQL & "        ,HINMTA " & vbCrLf
		strSQL = strSQL & " WHERE  HINMTA.HINCD (+) = V2.HINCD" & vbCrLf

        ' �f�[�^�擾
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190927 kuwa
        '      If Not clsOra.OraCreateDyn(strSQL, objRec,  , PROCEDURE) Then
        '	GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190927 kuwa
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190927 kuwa
        'HKKET142F.txtPLANTK.Text = D0.Chk_Null(objRec("PLANTK"))
        HKKET142F.txtPLANTK.Text = D0.Chk_Null(dt.Rows(0)("PLANTK"))
        'change end 20190927 kuwa

        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCloseDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'delete start 20190927 kuwa
        'clsOra.OraCloseDyn(objRec)
        'delete end 20190927 kuwa

        Get_KEIKAKUTANKA = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'// 2008/05/27 �� ADD END
	
	'// V2.20�� ADD
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Chk_YuusenFlg
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    �D��t���O�̓��͏󋵂��m�F����
	'//*****************************************************************************************
	Public Function Chk_YuusenFlg() As Boolean
		
		Const PROCEDURE As String = "Chk_YuusenFlg"
		
		Dim i As Short
		Dim intErrFlg As Short
		Dim intErrIdx As Short
		
		Chk_YuusenFlg = False
		
		On Error GoTo ONERR_STEP
		
		intErrFlg = 0
		
		For i = 0 To UBound(musrODINTRA.strINPPLAN)
			
			'//����Check
			If Val(Trim(musrODINTRA.strINPPLAN(i))) = 0 And Val(Trim(musrODINTRA.strLMZNPF(i))) = 1 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "226", vbCrLf & "���Ɍv��(�A�g)�� 0(�[��) �̂��߁A�D��� 1 �ɂ��邱�Ƃ��ł��܂���B [" & VB6.Format(musrHKKZTRA.strDSPMONTH(i), "0000�N00��") & "]")
				intErrFlg = 1
				intErrIdx = i
				Exit For
			End If
			
			'//����Check
			If Val(Trim(musrODINTRA.strLMZNPF(i))) <> 1 And Val(Trim(musrODINTRA.strLMZNPF(i))) <> 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "226", vbCrLf & "���Ɍv��(�D��)�� 0(�[��) ���� 1 �̓��͂ł��B[" & VB6.Format(musrHKKZTRA.strDSPMONTH(i), "0000�N00��") & "]")
				intErrFlg = 1
				intErrIdx = i
				Exit For
			End If
			
		Next i
		
		If intErrFlg = 0 Then
			Chk_YuusenFlg = True
		Else
			Chk_YuusenFlg = False
		End If
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	'// V2.20�� ADD
End Module