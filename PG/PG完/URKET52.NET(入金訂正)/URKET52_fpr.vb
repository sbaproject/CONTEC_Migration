Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module SSSMAIN0001
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t    | �X�V��        |���e
	'//* ---------|----------|---------------|-----------------------------------------------
	'//* 1.00     |          |RISE)          |�V�K�쐬
	'//* 1.10     |2009/01/22|RISE)�{��      |���ϓ��Ɖ^�p�����r�����ϓ����^�p���𒴂��Ă���ꍇ�́A���b�Z�[�W��\������B
	'//* 1.20     |2009/03/18|RISE)�{��      |�E��s�R�[�h�̓��͓͂�����ʂ��u��`�v�̏ꍇ�̂ݓ��͉\�Ƃ���B(���X)
	'//* 1.20     |2009/03/18|RISE)�{��      |�E�ȉ��A�`�F�b�N���e���s��Ȃ��B
	'//*          |          |               |�@�@���Ӑ�}�X�^�̎�`�x�����z���O���A���ׂɎ�`���Ȃ��ꍇ�A
	'//*          |          |               |     �G���[� ���d�l��2�s�ڂ̃`�F�b�N�
	'//*          |          |               |  �A������� = ��`���¤���Ӑ�}�X�^�̎�`�x�����z > ���͋��z
	'//*          |          |               |     �̏ꍇ��G���[� ���d�l��7�s�ڂ̃`�F�b�N�
	'//*          |          |               |  �B�A�Ɠ����e�̊C�O�Ń`�F�b�N ���d�l��8�s�ڂ̃`�F�b�N�
	'//*          |          |               |  �C������� = �U������¤��s�R�[�h�������͂̏ꍇ�̓G���[�
	'//*          |          |               |      ���d�l��3�s�ڂ̃`�F�b�N�
	'//* 1.20     |2009/03/18|RISE)�{��      |�E�Ώۂ̎󒍃f�[�^�i�󒍌��o���g�����j�̑O��敪���u�Q�D�O��v��
	'//*          |          |               |  �Ȃ���΃G���[�Ƃ���B
	'//* 1.20     |2009/03/18|RISE)�{��      |�E�󒍃f�[�^�i�󒍌��o���g�����j���r���`�F�b�N�̑ΏۂƂ��ĕK�v�B
	'//*          |          |               |�@�������A�r���`�F�b�N�̓��e�Ƃ��ẮA�f�[�^�̑��݃`�F�b�N�i��������
	'//*          |          |               |�@���Ȃ����̊m�F�j�A�O��敪���u�Q�D�O��v���̃`�F�b�N�̂ݎ��{����B
	'//*          |2009/05/27|FKS)���c       |�E�����敪���u�Q�D�O��v�̏ꍇ�ŁA�����U���̏ꍇ�A���ϓ�����͉\�Ƃ���B
	'//*          |2009/06/05|FKS)���c       |�E�O��������A�󒍔ԍ����i�[����ꏊ���u����g����.�󒍔ԍ��v���u����g����.����󇂁v�֕ύX�B
	'//*          |          |               |�E����g����.�����敪�ɑO��������g�p���ꂽ���ǂ����𔻒f�����邽�߁u�X�v���i�[
	'//*          |2009/06/08|FKS)���c       |�E�����敪���u�Q�D�O��v�̏ꍇ�A�󒍔ԍ��̖����̓`�F�b�N�̒ǉ��B
	'//*          |          |               |�E�O��������́u�󒍋��z=�����z�v�̃`�F�b�N(�A���[�g)��ǉ��B
	'//*          |          |               |�@�@�󒍋��z�������z�̏ꍇ�A�u�󒍋��z�������Ă��܂��B�v
	'//*          |          |               |�@�@�󒍋��z�������z�̏ꍇ�A�u�󒍋��z��������Ă��܂��B�v
	'//*          |          |               |�E�O��������A�Ώۂ̎󒍃f�[�^�i�󒍌��o���g�����j�̐����悪
	'//*          |          |               |�@��ʓ��͂̐�����ƈقȂ��Ă���ꍇ�̓G���[
	'//*          |2009/06/10|FKS)���c       |�E�����T�}���O��(TOKSSB)�E�����T�}��(�O��)�̍X�V�����C��
	'//*          |�@�@�@�@�@|�@�@�@�@�@�@�@ |   ��INSERT���ATOKSSB.DATNO �y�� TOKSSC.DATNO���󔒂ɂčX�V�B
	'//*          |�@�@�@�@�@|�@�@�@�@�@�@�@ |   ��UPDATE���ATOKSSB.DATNO �y�� TOKSSC.DATNO�͍X�V���s��Ȃ��B
	'//*          |2009/09/03|RISE)�{��      |�E������ʓ��͎��A���ϓ������i�������ρj���ɂ��āA�����ȊO�̓��͂̓G���[�Ƃ���
	'//*          |�@�@�@�@�@|�@�@�@�@�@�@�@ |�E�������̃`�F�b�N���A�O�񌎎��X�V���s�������łȂ��A�O�񐿋������Ƃ̃`�F�b�N���K�v
	'//*          |�@�@�@�@�@|�@�@�@�@�@�@�@ |�E���ϓ��̃`�F�b�N���A�O�񌎎��X�V���s�������łȂ��A�������ƃ`�F�b�N���K�v
	'//*          |�@�@�@�@�@|�@�@�@�@�@�@�@ |�E�����o�^���A�S���҂��c�ƒS���ł��邱�Ƃ̃`�F�b�N���K�v
	'//*          |�@�@�@�@�@|�@�@�@�@�@�@�@ |�E�O��敪�ɂ���āA����Ȗڂ̃`�F�b�N�����{
	'//*          |2009/09/05|RISE)�{��      |�E�ύX���z�`�F�b�N�̃`�F�b�N���@�̕ύX�@���������z=0 and �ύX�O�����z<>0 �̎��ɃG���[��\������
	'//*          |2009/09/07|FKS)���c       |�E�O��������́u�󒍋��z=�����z�v�̃`�F�b�N(�A���[�g)���G���[�ɕύX
	'//*          |          |               |�@�i�t�d��͏����j
	'//*          |2009/09/18|RISE)�{��      |�E�萔���A����ł̎�舵���ύX�Ή�
	'//*          |2009/09/23|RISE)�{��      |�E���Ӑ�}�X�^�E�x���敪��'5':�����U�� or '6':�t�@�N�^�����O�̏ꍇ
	'//*          |          |               |  ��ʂ̓�����ʁ�'08'(���U��)�́A�u�g�p�ł��Ȃ�������ʂł��v�̃G���[���b�Z�[�W��\��
	'//*          |2009/09/23|RISE)�{��      |�E���������f�[�^�ǂݍ��ݎ��������̃G���[�`�F�b�N��������Ȃ�
	'//*          |2009/09/24|RISE)�{��      |�E���z���z���@�̕ύX�i�����T�}����������T�}���̋���P�ʂցj
	'//*          |2009/09/24|RISE)�{��      |�E�O��̖{�������̓T�}���n�e�[�u���ɍX�V���Ȃ�
	'//*          |2009/09/24|RISE)�{��      |�E����g�����E�����T�}���̌��x����̕ύX
	'//*          |2009/09/27|RISE)�{��      |�EUDNTRA.RATERT �� TUKMTA.RATERT ��ݒ肷��
	'//*          |2009/09/29|RISE)�{��      |�E���z���z�̃`�F�b�N���A����g�����ɕێ����Ă���o�������t�ł͂Ȃ��A��ʁw�������x���
	'//*          |          |               |  �o�������t���Z�o���ŐV���x�̓��������T�}���𑊎�ɂ���B
	'//*          |2009/09/30|RISE)�{��      |�E�������������Ă������̐ԍ��쐬
	'//*          |2009/10/05|RISE)�{��      |�E�O�݂̎��ɍ��z�`�F�b�N���������s���Ȃ�
	'//*          |2009/10/05|RISE)�{��      |�E�O�󎞁A�󒍌��o���E�󒍃g�����̉��L���ڂ��X�V����
	'//*          |          |               |  �@���[�UID (�o�b�`), �N���C�A���gID(�o�b�`), �^�C���X�^���v(�o�b�`����), �^�C���X�^���v(�o�b�`��), �X�VPGID
	'//*          |          |               |  ����ʕύX�O�ƕύX�㗼���̎󒍃f�[�^�ɑ΂��čs��
	'//*          |2009/10/05|RISE)�{��      |�EEXP�Ɉړ������󒍂̓G���[�ɂ���
	'//*          |2009/10/07|RISE)�{��      |�E�O������ŐU�������������ׂ��X�V���鎞�Ɍ��ϓ��ɉ^�p����ݒ肵�Ă��������������f�t�H���g�Őݒ肷��
	'//*          |          |               |�E�������������Ă������̐ԍ��쐬�̔��f������^�p������������ɕύX����
	'//*          |2009/11/10|FKS)�R�{       |�E�O��������A�󒍃f�[�^�̎󒍓`�[���t�����.�������̏ꍇ�G���[
	'//*          |2009/12/28|FKS)�R�{       |�E������ʂƊ���������Ƃ��Ɏ�`�A�������́A�Ƃ��Ɏ�`�ȊO�łȂ���΃G���[
	'//*          |2011/01/14|FKS)�R�{       |�E�����{�����̏����P�p
	'//*          |          |               |�E�������������߂̏ꍇ�̓G���[
	'//*          |2011/06/14|FKS)�R�{       |�E�ʏ�����������U���̏ꍇ�͌��ϓ�����͉Ƃ���
	'//*          |2011/11/15|FKS)�R�{       |�E������̎x���敪��5(�����U��)�A6(̧���ݸ�)�ŁA���.������ʁ�07(��)�̏ꍇ��
	'//*          |          |               |  ����g����.������ʂ��Q(������)�Ƃ���Ώۂ��珜�O
	'//**************************************************************************************
	
	
	
	
	'�P�v���W�F�N�g���Ƃ̋��ʃ��C�u����
	Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(169 + 23 + 0 + 1) As clsCP
	Public CL_SSSMAIN(169) As Short
    Public CQ_SSSMAIN(54) As String


    '���������������� �v���O�����P�ʂ̋��ʏ��� Start ��������������������������������
    '�r���������������������������������������������������������r
    '�����������`�F�b�N���s�t���O
    Public gv_bolInit As Boolean '������������True(�`�F�b�N�Ȃ��j�@����ȊO��False
	Public gv_bolURKET52_INIT As Boolean '��ʏ������t���O�iTrue:�ύX����j
	Public gv_bolURKET52_LF_Enable As Boolean 'LF�������s�t���O(True�F���s����j
	Public gv_bolKeyFlg As Boolean
	Public gv_bolUpdFlg As Boolean
	Public gv_bolDelFlg As Boolean
	Private intInput_Bef_RowNo As Short '�󔒍s�̐擪�s��
	
	Private Structure URKET52_TYPE_HEAD
		Dim DATNO As String '�`�[�Ǘ��ԍ�
		Dim UDNTHA As TYPE_DB_UDNTHA '�`�[�Ǘ��ԍ��ɕR�Â�����g����(�ŏ��Ɏ擾���Ă���ύX���Ȃ�)
		Dim UDNTRA() As TYPE_DB_UDNTRA '�`�[�Ǘ��ԍ��ɕR�Â����㌩�o�g����(�ŏ��Ɏ擾���Ă���ύX���Ȃ�)
		Dim NYUKB As String '�����敪
		Dim NYUDT As String '������
		Dim TOKCD As String '������R�[�h
		Dim TOKMTA As TYPE_DB_TOKMTA '������R�[�h�ɕR�Â����Ӑ�f�[�^
		Dim KNJKOZ As String '�������
		'2009/09/30 ADD START RISE)MIYAJIMA
		Dim TEGKB() As Short '��������(0:�������Ă��Ȃ� 1:�������Ă���)
		Dim DKBID() As String '����敪(��ʂœ��͂���Ď���敪)
		'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	End Structure
	'���o���
	'UPGRADE_WARNING: �\���� URKET52_HEAD_Inf �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Private URKET52_HEAD_Inf As URKET52_TYPE_HEAD
	
	Private pv_bolMEISAI_INPUT As Boolean '���ד��̓t���O(True:���͂���j
	Private pv_bolMEISAI_TEG_INPUT As Boolean '���׎�`���̓t���O(True:���͂���j
	Private pv_intMeisaiCnt As Short '���͖��א��i�X�V���g�p�j
	
	'�N�����Ɏ擾����l(F_GET_SYSTBA)
	Private pv_strYERUPDDT As String '�O��N���X�V���s��
	'''' UPD 2011/01/14  FKS) T.Yamamoto    Start    �A���[��FC11011401
	'�����{�����̏����P�p
	'Private pv_strMONUPDDT              As String               '�O�񌎎��X�V���s��
	Private pv_strSMAUPDDT As String '�O��o�������s��
	'''' UPD 2011/01/14  FKS) T.Yamamoto    End
	Private pv_strSMADD As String '���Z��
	
	'�X�V���g�p
	Private pv_strSMADT As String '�o�������t
	Private pv_strSSADT As String '�����t
	Private pv_strKESDT As String '���ϓ��t
	Private pv_curNYUKN_SUM As Decimal '���v(�~)
	Private pv_dblFNYUKN_SUM As Double '���v(���v)

    '���������߂�l
    'Public WLSNDN_RTNCODE As String '�`�[�Ǘ��ԍ�

    '�d���������������������������������������������������������d

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
	
	'�t�H�[�}�b�g
	Public Const gc_DSP_FMT_KIN_GAI_1 As String = "#,##0.0000" '���z(�O��)
	
	'�`�[����敪���
	Private Const pc_strDKBSB_URK As String = "050" '
	
	'���̃}�X�^�i�L�[�R�[�h�j
	Private Const pc_strKEYCD_KNJKOZ As String = "062" '�������
	'2009/09/03 ADD START RISE)MIYAJIMA
	Private Const pc_strKEYCD_KNJKOZ_MAE As String = "111" '�������(�O��)
	'2009/09/03 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/24 ADD START RISE)MIYAJIMA
	Private Structure TYPE_NKSSMX
		<VBFixedArray(9)> Dim curSSANYUKN() As Decimal '�����W�v���z
		<VBFixedArray(9)> Dim curKSKNYKKN() As Decimal '���������W�v���z
		<VBFixedArray(9)> Dim curKSKZANKN() As Decimal '�O�����������c�z
		<VBFixedArray(9)> Dim curZAN() As Decimal '�c�z�i�����W�v���z�|���������W�v���z�{�O�����������c�z�j
		Dim curTOTAL As Decimal '���z���v�i0�`9�܂ł̎c�z�v8:�{�������̂����j
		Dim strOPEID As String '�r���p
		Dim strCLTID As String '�r���p
		Dim strWRTTM As String '�r���p
		Dim strWRTDT As String '�r���p
		
		'UPGRADE_TODO: ���̍\���̂̃C���X�^���X������������ɂ́A"Initialize" ���Ăяo���Ȃ���΂Ȃ�܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' ���N���b�N���Ă��������B
		Public Sub Initialize()
			ReDim curSSANYUKN(9)
			ReDim curKSKNYKKN(9)
			ReDim curKSKZANKN(9)
			ReDim curZAN(9)
		End Sub
	End Structure
	'UPGRADE_WARNING: �\���� gc_NKSSMX_Inf �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Private gc_NKSSMX_Inf As TYPE_NKSSMX
	'2009/09/24 ADD E.N.D RISE)MIYAJIMA
	
	'2009/10/05 ADD START RISE)MIYAJIMA
	Structure TYPE_DB_JDNTHA_HAITA
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public JDNNO() As Char '�󒍔ԍ�              0000000000
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public DATNO() As Char '�`�[�Ǘ�NO.           0000000000  (��ײ�ط�)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public FOPEID() As Char '����o�^հ�ްID       !@@@@@@@@
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public FCLTID() As Char '����o�^�ײ���ID      !@@@@@
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTFSTTM() As Char '��ѽ����(�o�^����)    9(06)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTFSTDT() As Char '��ѽ����(�o�^��)      YYYY/MM/DD
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '�ŏI��Ǝ҃R�[�h      !@@@@@@@@
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char '�N���C�A���g�h�c      !@@@@@
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char '��ѽ����(����)        9(06)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char '��ѽ����(���t)        YYYY/MM/DD
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UOPEID() As Char '���[�UID(�ޯ�)        !@@@@@@@@
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public UCLTID() As Char '�ײ���ID(�ޯ�)        !@@@@@
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public UWRTTM() As Char '��ѽ����(����)        9(06)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UWRTDT() As Char '��ѽ����(���t)        YYYY/MM/DD
	End Structure
	Structure TYPE_DB_JDNTRA_HAITA
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public JDNNO() As Char '�󒍔ԍ�              0000000000
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public DATNO() As Char '�`�[�Ǘ�NO.           0000000000    (��ײ�ط�)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public LINNO() As Char '�s�ԍ�                000           (��ײ�ط�)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public FOPEID() As Char '����o�^հ�ްID       !@@@@@@@@
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public FCLTID() As Char '����o�^�ײ���ID      !@@@@@
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTFSTTM() As Char '��ѽ����(�o�^����)    9(06)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTFSTDT() As Char '��ѽ����(�o�^��)      YYYY/MM/DD
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '�ŏI��Ǝ҃R�[�h      !@@@@@@@@
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char '�N���C�A���g�h�c      !@@@@@
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char '��ѽ����(����)        9(06)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char '��ѽ����(���t)        YYYY/MM/DD
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UOPEID() As Char '���[�UID(�ޯ�)        !@@@@@@@@
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public UCLTID() As Char '�ײ���ID(�ޯ�)        !@@@@@
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public UWRTTM() As Char '��ѽ����(����)        9(06)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UWRTDT() As Char '��ѽ����(���t)        YYYY/MM/DD
	End Structure
	Private gc_JDNTHA_HAITA_Inf() As TYPE_DB_JDNTHA_HAITA
	Private gc_JDNTRA_HAITA_Inf() As TYPE_DB_JDNTRA_HAITA
	'2009/10/05 ADD E.N.D RISE)MIYAJIMA
	
	'// V1.20�� ADD
	'�O��敪
	Private Const pc_strMAEUKKB As String = "2" '�O��敪�i1�F�ʏ�A2�F�O��j
	'// V1.20�� ADD
	
	'�x���敪
	Private Const pc_strSHAKB_HURI As String = "1" '�U��
	Private Const pc_strSHAKB_TEG As String = "2" '��`
	Private Const pc_strSHAKB_HURI_OR_TEG As String = "3" '�U���܂��͎�`
	Private Const pc_strSHAKB_HURI_AND_TEG As String = "4" '�U����`���p
	Private Const pc_strSHAKB_KIJZITU As String = "5" '�����U��
	Private Const pc_strSHAKB_FACTERING As String = "6" '�t�@�N�^�����O
	
	'����敪�R�[�h(pc_strDKBSB_URK �ƃ����N)
	Private Const pc_strDKBID_URK_GENKN As String = "01" '����
	Private Const pc_strDKBID_URK_HURI As String = "02" '�U��
	Private Const pc_strDKBID_URK_TEG As String = "03" '��`
	Private Const pc_strDKBID_URK_SOSAI As String = "04" '���E
	Private Const pc_strDKBID_URK_NEBIK As String = "05" '�l��
	Private Const pc_strDKBID_URK_TESU As String = "06" '�萔
	Private Const pc_strDKBID_URK_HOKA As String = "07" '��
	Private Const pc_strDKBID_URK_HURIK As String = "08" '�U����
	Private Const pc_strDKBID_URK_HNYU As String = "09" '�{����
	Private Const pc_strDKBID_URK_SYOH As String = "99" '����
	
	'�@�\ �F ���ݎ��ԁi�~���b�܂ށj�̎擾
	Public Structure SYSTEMTIME
		Dim wYear As Short
		Dim wMonth As Short
		Dim wDayOfWeek As Short
		Dim wDay As Short
		Dim wHour As Short
		Dim wMinute As Short
		Dim wSecond As Short
		Dim wMilliseconds As Short
	End Structure
	
	'UPGRADE_WARNING: �\���� SYSTEMTIME �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Private Declare Sub GetLocalTime Lib "kernel32" (ByRef lpSystemTime As SYSTEMTIME)
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	Public pv_intTouraiKbn As Short '���������f�[�^���̋敪(0:���Ă��Ȃ� 1:��`�ł��Ă��� 2:�U�����ł��Ă���)
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'''' ADD 2009/12/28  FKS) T.Yamamoto    Start    �A���[��767
	Private Const pc_strKNJKOZ_TEG As String = "D" '��`
    '''' ADD 2009/12/28  FKS) T.Yamamoto    End

    '�S���҃}�X�^�����߂�l
    'Public WLSTAN_RTNCODE As String     '�S���҃R�[�h
    '2019/05/23  ADD START
    Public D0 = New ClsComn
    ' Public WLSTAN_TANTKDT As String
    'Public WLSTAN_TANCLAKB As String
    Public LV_Col_Order() As Integer
    '2019/05/23 ADD END

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
                '2019/05/21 CHG START
                'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
                Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
                Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
                Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
                '2019/05/21 CHG END
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
			'���̍��ڂ�̫����ړ�
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Cursor_Idx), pm_All)
		Else
			
			If pm_All.Dsp_Base.Head_Ok_Flg = False And pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_TL Then
				'���̍��ڂ�̫����ړ�
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Cursor_Idx), pm_All)
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
            '2019/05/21 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '2019/05/21 CHG END
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
					'                pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/05/21 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart + 1
					'�ҏW���SelLength������
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart + 1, Wk_SelLength)
                    '2019/05/21 CHG END
					
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
                            '2019/05/21 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
							'�ҏW���SelLength������
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(Wk_DspMoji), 0)
                            '2019/05/21 CHG END
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
                                    '2019/05/21 CHG START
                                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
									'�ҏW���SelLength������
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                                    '2019/05/21 CHG END

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
                        '2019/05/21 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'�ҏW���SelLength������
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '2019/05/21 CHG END
						
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
                                '2019/05/21 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
								'�ҏW���SelLength������
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(Wk_DspMoji), 1)
                                '2019/05/21 CHG END
								
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
                        '2019/05/21 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'�ҏW���SelLength������
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '2019/05/21 CHG END
						
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
                                '2019/05/21 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
								'�ҏW���SelLength������
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                                '2019/05/21 CHG END
								
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
                        '2019/05/21 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '2019/05/21 CHG END

                        'add start 20190826 kuwa
                    Case System.Windows.Forms.Keys.Return
                        pm_Move_Flg = True
                        pm_KeyAscii = 0
                        'add end 20190826 kuwa

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
                '2019/05/23 CHG START
                'FR_SSSMAIN.PopupMenu(FR_SSSMAIN.SM_ShortCut, vbPopupMenuLeftButton)
                '2019/05/23 CHG END
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
					'���͉\�ȍ��ڂ��ǂ����̔��f���s��
					If CF_Set_Focus_Ctl(pm_Act_Dsp_Sub_Inf, pm_All) = True Then
						'�I����Ԃ̐ݒ�i�����I���j
						Call CF_Set_Sel_Ini(pm_Act_Dsp_Sub_Inf, SEL_INI_MODE_2)
						'���ڐF�ݒ�
						Call CF_Set_Item_Color(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
					Else
						'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
					End If
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
				If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = True Then
					'�I����Ԃ̐ݒ�i�����I���j
					Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
					'���ڐF�ݒ�
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
				Else
					'���̃R���g���[����T��
					Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				End If
				
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
	'   ���́F  Function CF_Ctl_MN_ClearDE
	'   �T�v�F  ���j���[�̖��׏������̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_ClearDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Row_Wk As Short
		
		'���X�g�t�H�[�J�X����
		Call CF_Ctl_Item_LostFocus_Dummy(pm_All)
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'���ʂ̖��׏�����
		If CF_Cmn_Ctl_MN_ClearDE(Bd_Index, pm_All) = True Then
            ' === 20130711 === INSERT S - FWEST)Koroyasu �r������
            '2019/05/23 CHG START
            'Call CF_EXCTBZ_Unlock(pm_All)
            '2019/05/23 CHG END
            ' === 20130711 === INSERT E -
            '�r���������������������������������������������������������r
            '�Ɩ��̏����l��ҏW
            Call F_Init_Dsp_Body(Bd_Index, pm_All)
			
			'�s�m���̔ԏ���
			Call F_Edi_Saiban_No(pm_All)
			'�d���������������������������������������������������������d
			
			'��ʕ\��
			Call CF_Body_Dsp(pm_All)
			'���׍��ڐ���
			Call F_Set_Body_Enable(pm_All)
			
			'���̉�ʂ̍s�Ɉړ�
			Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
			
			'�t�H�[�J�X����
			Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_MN_DeleteDE
	'   �T�v�F  ���j���[�̖��׍폜�̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_DeleteDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Row_Inf_Max_S As Short
		Dim Row_Inf_Max_E As Short
		Dim Bd_Index_Wk As Short
		Dim Row_Wk As Short
		
		'���X�g�t�H�[�J�X����
		Call CF_Ctl_Item_LostFocus_Dummy(pm_All)
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'���ʂ̖��׍폜
		Call CF_Cmn_Ctl_MN_DeleteDE(Bd_Index, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)
        ' === 20130711 === INSERT S - FWEST)Koroyasu �r������̉���
        '2019/05/23 CHG START
        'Call CF_EXCTBZ_Unlock(pm_All)
        '2019/05/23 CHG END
        ' === 20130711 === INSERT E -
        '�r���������������������������������������������������������r
        '�s��ǉ����ꂽ���
        '�����l��ǉ������s�ɑ΂��ă��[�v���łP�s���s��
        '�����ł̍s�́ADsp_Body_Inf�̍s�I�I
        For Bd_Index_Wk = Row_Inf_Max_S To Row_Inf_Max_E
			Call F_Init_Dsp_Body(Bd_Index_Wk, pm_All)
		Next 
		
		'�s�m���̔ԏ���
		Call F_Edi_Saiban_No(pm_All)
		'�d���������������������������������������������������������d
		
		'��ʕ\��
		Call CF_Body_Dsp(pm_All)
		'���׍��ڐ���
		Call F_Set_Body_Enable(pm_All)
		
		'���̉�ʂ̍s�Ɉړ�
		Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
		
		'�t�H�[�J�X����
		Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_MN_InsertDE
	'   �T�v�F  ���j���[�̖��ב}���̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_InsertDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Bd_Index_Wk As Short
		Dim Ins_Bd_Index As Short
		Dim Row_Wk As Short
		
		'���X�g�t�H�[�J�X����
		Call CF_Ctl_Item_LostFocus_Dummy(pm_All)
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'���ʂ̖��ב}��
		If CF_Cmn_Ctl_MN_InsertDE(Bd_Index, Ins_Bd_Index, pm_All) = True Then
			'�r���������������������������������������������������������r
			'�Ɩ��̏����l��ҏW
			Call F_Init_Dsp_Body(Ins_Bd_Index, pm_All)
			
			'�s�m���̔ԏ���
			Call F_Edi_Saiban_No(pm_All)
			'�d���������������������������������������������������������d
			
			'�Ώۍs����ʂɕ\��
			Call CF_Body_Dsp_Trg_Row(pm_All, Ins_Bd_Index)
			'���׍��ڐ���
			Call F_Set_Body_Enable(pm_All)
			
			'�ǉ��s�Ɉړ�
			Row_Wk = CF_Idx_To_Bd_Idx(Ins_Bd_Index, pm_All)
			
			'�t�H�[�J�X����
			Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			
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
		
		Dim Bd_Index As Short
		Dim Row_Inf_Max_S As Short
		Dim Row_Inf_Max_E As Short
		Dim Bd_Index_Wk As Short
		Dim Row_Wk As Short
		' === 20130716 === INSERT S - FWEST)Koroyasu �r������
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		Dim Row_Wk2 As Short
		' === 20130716 === INSERT E
		
		'���X�g�t�H�[�J�X����
		Call CF_Ctl_Item_LostFocus_Dummy(pm_All)
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		' === 20130716 === INSERT S - FWEST)Koroyasu �r������
		Row_Wk2 = pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row
		' === 20130716 === INSERT E
		
		'���ʂ̖��ו���
		If CF_Cmn_Ctl_MN_UnDoDe(pm_All, Row_Inf_Max_S, Row_Inf_Max_E) = True Then
			'�r���������������������������������������������������������r
			'�s��ǉ����ꂽ���
			'�����l��ǉ������s�ɑ΂��ă��[�v���łP�s���s��
			'�����ł̍s�́ADsp_Body_Inf�̍s�I�I
			For Bd_Index_Wk = Row_Inf_Max_S To Row_Inf_Max_E
				Call F_Init_Dsp_Body(Bd_Index_Wk, pm_All)
			Next 
			
			'�s�m���̔ԏ���
			Call F_Edi_Saiban_No(pm_All)
			'�d���������������������������������������������������������d
			
			'��ʕ\��
			Call CF_Body_Dsp(pm_All)
			'���׍��ڐ���
			Call F_Set_Body_Enable(pm_All)
			
			' === 20130716 === UPDATE S - FWEST)Koroyasu �r������
			'        '���̉�ʂ̍s�Ɉړ�
			'        Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
			'
			'        '�t�H�[�J�X����
			'        Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			
			Chk_Move_Flg = True
			
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_JDNNO(Row_Wk2).Tag)).Detail.Bef_Chk_Value = ""
			
			'�e���ڂ�����ٰ��
			Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_JDNNO(Row_Wk2).Tag)), CHK_FROM_BACK_PROCESS, Chk_Move_Flg, pm_All)
			If Rtn_Chk = CHK_OK Then
				'�`�F�b�N�n�j��
				'�擾���e�\��
				Dsp_Mode = DSP_SET
				
				'���̉�ʂ̍s�Ɉړ�
				Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
				
				'�t�H�[�J�X����
				Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			Else
				'�`�F�b�N�m�f��
				'�擾���e�N���A
				Dsp_Mode = DSP_CLR
				'�t�H�[�J�X����
				Call CF_Ctl_MN_Cmn_DE_Focus(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_JDNNO(Row_Wk2).Tag)), Row_Wk, pm_All)
			End If
			' === 20130716 === UPDATE E
			
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
        '2019/05/21 CHG START
        'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
        Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
        Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
        Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
        '2019/05/21 CHG END
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
        '2019/05/21 CHG START
        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
		'�ҏW���SelLength������
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
        '2019/05/21 CHG END
		'���͌�̌㏈��
		Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
		'���ד��͌�̌㏈��
		Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Edi_Saiban_No
	'   �T�v�F  �S���ׂ̍s�m�n��ݒ肷��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̏���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Edi_Saiban_No(ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		Dim Bd_Index As Short
		
		Wk_Index = CShort(FR_SSSMAIN.BD_LINNO(0).Tag)
		For Bd_Index = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			'�y�m�n�z�P�E�Q�`��ҏW
			'��ʃ{�f�B���(pm_All.Dsp_Body_Inf)�ɕҏW
			Call CF_Edi_Dsp_Body_Inf(Bd_Index, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DEF)
		Next 
		
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
		'�ʏ�����
		'�y�m�n�z�P�E�Q�`��ҏW
		Wk_Index = CShort(FR_SSSMAIN.BD_LINNO(0).Tag)
		'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
		Call CF_Edi_Dsp_Body_Inf(pm_Bd_Index, pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		'�y������ʁz
		Wk_Index = CShort(FR_SSSMAIN.BD_DKBID(0).Tag)
		'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'�y��������z
		Wk_Index = CShort(FR_SSSMAIN.BD_KANKOZ(0).Tag)
		'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'�y�����z(�~)�z
		Wk_Index = CShort(FR_SSSMAIN.BD_NYUKN(0).Tag)
		'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'�y�����z(�O��)�z
		Wk_Index = CShort(FR_SSSMAIN.BD_FNYUKN(0).Tag)
		'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'�y��s�R�[�h�z
		Wk_Index = CShort(FR_SSSMAIN.BD_BNKCD(0).Tag)
		'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'�y��s���́z
		Wk_Index = CShort(FR_SSSMAIN.BD_BNKNM(0).Tag)
		'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'�y�󒍔ԍ��z
		Wk_Index = CShort(FR_SSSMAIN.BD_JDNNO(0).Tag)
		'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'�y�x�X���́z
		Wk_Index = CShort(FR_SSSMAIN.BD_STNNM(0).Tag)
		'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'�y���ϓ��z
		Wk_Index = CShort(FR_SSSMAIN.BD_TEGDT(0).Tag)
		'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'�y��`�ԍ��z
		Wk_Index = CShort(FR_SSSMAIN.BD_TEGNO(0).Tag)
		'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'�y���l�P�z
		Wk_Index = CShort(FR_SSSMAIN.BD_LINCMA(0).Tag)
		'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'�y���l�Q�z
		Wk_Index = CShort(FR_SSSMAIN.BD_LINCMB(0).Tag)
		'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
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
		'�s��ǉ����ꂽ���
		'�����l��ǉ������s�ɑ΂��ă��[�v���łP�s���s��
		'�����ł̍s�́ADsp_Body_Inf�̍s�I�I
		For Bd_Index = Row_Inf_Max_S To Row_Inf_Max_E
			Call F_Init_Dsp_Body(Bd_Index, pm_All)
		Next 
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
		Dim bolDspLstRow As Boolean
		
		bolDspLstRow = False
		
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
							'�R���g���[������
							Call F_Set_Body_Enable(pm_All)
							
							'���ׂP�ԉ��s�̓��͉\�ȍŏ��̃C���f�b�N�X���擾
							Focus_Ctl_Ok_Fst_Idx_Wk = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
							If Focus_Ctl_Ok_Fst_Idx_Wk > 0 Then
								'���ׂP�ԉ��s�̍ŏ��̍��ڂ̈�O���猟��
								Sta_Index = Focus_Ctl_Ok_Fst_Idx_Wk - 1
								'��ʏ�̍ŏI�\�����ׂ̍ŏI���͍��ڂ���
								'���̍��ڂֈړ�����ꍇ�I�I
								bolDspLstRow = True
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
			
			'�r���������������������������������������������������������r
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'�w�b�_������{�f�B���ֈړ�����ꍇ
				'ͯ�ޕ�����
				If gv_bolInit = False Then
					Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				Else
					Rtn_Chk = CHK_OK
				End If
				If Rtn_Chk <> CHK_OK Then
					'�`�F�b�N�m�f�̏ꍇ
					'�L�[�t���O�����ɖ߂�
					gv_bolKeyFlg = False
					Exit For
				End If
			End If
			'�d���������������������������������������������������������d
			
			'̫����ړ���OK
			If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
				If pm_Run_Flg = True Or bolDspLstRow = True Then
					'�ȉ��̂����ꂩ�𖞂����ꍇ�A�t�H�[�J�X�ړ����s���B
					'
					'�@�@���s�w�肪����ꍇ(��{����)�B
					'�@�A��ʏ�̍ŏI�\�����ׂ̍ŏI���͍��ڂ��玟�̍��ڂֈړ�����ꍇ�B
					'
					'̫����ړ�
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				End If
				'�ړ��t���O����
				pm_Move_Flg = True
				'��ʏ�̍ŏI�\�����ׂ̍ŏI���͍��ڂ��玟�̍��ڂֈړ�����ꍇ�́A
				'�ړ��t���O�𗧂ĂȂ��B
				'�iCtl_Item_KeyPress����ēx�{�֐����Ă΂��̂�������邽�߁j
				If bolDspLstRow = True Then
					pm_Move_Flg = False
				End If
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
					intRet = F_Ctl_Upd_Process(pm_All)
					If intRet = 0 Then
						'��ʏ�����
						Call F_Ctl_MN_APPENDC_Click(pm_All)
					End If
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
            '2019/05/21 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '2019/05/21 CHG END
			Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
					'�l���������l�̏ꍇ
					'�P�����ڂ�I������
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/05/21 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 0
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(0, 1)
                    '2019/05/21 CHG END
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
                        '2019/05/21 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '2019/05/21 CHG END
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
            '2019/05/21 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '2019/05/21 CHG END
			Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
					'�l���������l�̏ꍇ
					'�ŏI������I������
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/05/21 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1, 1)
                    '2019/05/21 CHG END
				Else
					'�l���������l�ȊO�̏ꍇ
					'�P���ڂ�I������
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/05/21 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 1
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(1, 1)
                    '2019/05/21 CHG END
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
                            '2019/05/21 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)), 0)
                            '2019/05/21 CHG END
						Else
							'�l���������l�ȊO�̏ꍇ
							If Act_SelLength = 0 Then
								'�ړ��O�̑I�𕶎������Ȃ��ꍇ
								'��ԉE�ֈړ����I���Ȃ���Ԃ�
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '2019/05/21 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)), 0)
                                '2019/05/21 CHG END
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
                            '2019/05/21 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Next_SelStart, Wk_SelLength)
                            '2019/05/21 CHG END
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
						'���׍��ڐ���
						Call F_Set_Body_Enable(pm_All)
						'���ׂ̈�ԉ��̓��ꍀ�ڂ̲��ޯ�����擾
						Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
						If Next_Index > 0 Then
							If Next_Index = Trg_Index Then
								'������۰ق̏ꍇ
								'���͉\�ȍ��ڂ��ǂ����̔��f���s��
								If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
									'�ړ������ŏI��
									pm_Move_Flg = False
									Exit Do
								Else
									'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
									Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
									Exit Do
								End If
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
						'���׍��ڐ���
						Call F_Set_Body_Enable(pm_All)
						'���ׂ̈�ԏ�̓��ꍀ�ڂ̲��ޯ�����擾
						Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, 1, pm_All)
						If Next_Index > 0 Then
							If Next_Index = Trg_Index Then
								'������۰ق̏ꍇ
								'�ړ������ŏI��
								'���͉\�ȍ��ڂ��ǂ����̔��f���s��
								If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
									pm_Move_Flg = False
									Exit Do
								Else
									'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
									Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Next_Index + 1), pm_Move_Flg, pm_All)
									Exit Do
								End If
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
		'UPGRADE_WARNING: �\���� Init_WK �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Init_WK As URKET52_TYPE_HEAD
		
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
			
			'�r���������������������������������������������������������r
			'�ʏ�����
			Select Case Index_Wk
				Case CShort(FR_SSSMAIN.HD_NYUDT.Tag)
					'������
					Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(GV_UNYDate, pm_All.Dsp_Sub_Inf(Index_Wk), False), pm_All.Dsp_Sub_Inf(Index_Wk), pm_All,  , True)
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Chk_Value = CF_Cnv_Dsp_Item(GV_UNYDate, pm_All.Dsp_Sub_Inf(Index_Wk), False)
			End Select
			'�d���������������������������������������������������������d
			
		Next 
		
		'�S�������̏ꍇ�A��ʏ��ێ��p�̍\���̂��N���A����
		If Wk_Mode = ITM_ALL_CLR Then
			Init_WK.NYUDT = GV_UNYDate
			'UPGRADE_WARNING: �I�u�W�F�N�g URKET52_HEAD_Inf �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URKET52_HEAD_Inf = Init_WK
		End If
		
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
			Call CF_Set_Item_Direct(1, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All, SET_FLG_DEF)
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
			Wk_Index = CShort(FR_SSSMAIN.BD_LINNO(Index_Bd_Wk).Tag)
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
		'���������ΏۂɃt�H�[�J�X�ݒ�
		'�������ޯ���擾
		Trg_Index = CShort(FR_SSSMAIN.HD_DATNO.Tag)
		
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
						Case CHK_WARN
							'�x����
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
							'���b�Z�[�W�o�͂���
							pm_Msg_Flg = True
							'�ړ��m�f
							pm_Move = True
							'��ʕ\���̓N���A�ł͂Ȃ��A�Z�b�g�����悤�ɂ���
							pm_Err_Rtn = CHK_OK
							
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
						Case CHK_WARN
							'�x����
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
							'���b�Z�[�W�o�͂���
							pm_Msg_Flg = True
							'�ړ��m�f
							pm_Move = True
							'��ʕ\���̓N���A�ł͂Ȃ��A�Z�b�g�����悤�ɂ���
							pm_Err_Rtn = CHK_OK
							
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
	'   ���́F  Function F_Chk_HD_DATNO
	'   �T�v�F  ���o�F���������Ώۂ�����
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_DATNO(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Tbl_Inf_UDNTHA As TYPE_DB_UDNTHA
		Dim Tbl_Inf_UDNTRA() As TYPE_DB_UDNTRA
		Dim Mst_Inf_TOKMTA As TYPE_DB_TOKMTA
		Dim Mst_Inf_SYSTBD As TYPE_DB_SYSTBD
		Dim Mst_Inf_BNKMTA As TYPE_DB_BNKMTA
		Dim strDATNO As String
		Dim intCnt As Short
		' === 20130711 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
		Dim rResult As Short ' �����`�F�b�N�֐��߂�l
		' === 20130711 === INSERT E
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_HD_DATNO = Retn_Code
			Exit Function
		End If
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '���͔͈͊O
			Else
				strDATNO = Input_Value
				
				'���㌩�o�g���� �}�X�^�`�F�b�N
				If DSPUDNTHA_SEARCH(strDATNO, Tbl_Inf_UDNTHA) <> 0 Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_011 '�Y���f�[�^�Ȃ�
					GoTo F_Chk_HD_DATNO_End
				End If
				
				If Tbl_Inf_UDNTHA.DATKB = gc_strDATKB_DEL Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_009 '�폜�ς݃f�[�^
					GoTo F_Chk_HD_DATNO_End
				End If
				
				'����g���� �}�X�^�`�F�b�N
				If DSPUDNTRA_SEARCH(strDATNO, Tbl_Inf_UDNTRA) <> 0 Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_011 '�Y���f�[�^�Ȃ�
					GoTo F_Chk_HD_DATNO_End
				End If
				
				For intCnt = 1 To UBound(Tbl_Inf_UDNTRA)
					If Tbl_Inf_UDNTRA(intCnt).DATKB = gc_strDATKB_DEL Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgURKET52_E_009 '�폜�ς݃f�[�^
						GoTo F_Chk_HD_DATNO_End
					End If
				Next intCnt
				
				'�f�[�^�𒊏o���o�b�t�@�ɐݒ�
				With URKET52_HEAD_Inf
					'�ǂݍ��񂾔��㌩�o�g�����A����g������ێ�
					'UPGRADE_WARNING: �I�u�W�F�N�g URKET52_HEAD_Inf.UDNTHA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.UDNTHA = Tbl_Inf_UDNTHA
					.UDNTRA = VB6.CopyArray(Tbl_Inf_UDNTRA)
					
					'�`�[�Ǘ��ԍ�
					.DATNO = Input_Value
					
					'�����敪
					.NYUKB = Tbl_Inf_UDNTHA.NYUCD
					
					'������
					.NYUDT = Tbl_Inf_UDNTHA.UDNDT
					
					'������
					.TOKCD = Tbl_Inf_UDNTHA.TOKSEICD
					If DSPTOKCD_SEARCH(.TOKCD, Mst_Inf_TOKMTA) = 0 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g URKET52_HEAD_Inf.TOKMTA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.TOKMTA = Mst_Inf_TOKMTA
					Else
                        'Call DB_TOKMTA_Clear(.TOKMTA)
                    End If
					
					'�ʉ�
					.TOKMTA.TUKKB = Tbl_Inf_UDNTHA.TUKKB
					'2009/09/30 ADD START RISE)MIYAJIMA
					ReDim .DKBID(UBound(Tbl_Inf_UDNTRA))
					ReDim .TEGKB(UBound(Tbl_Inf_UDNTRA))
					'2009/09/30 ADD E.N.D RISE)MIYAJIMA
				End With

                ' === 20130711 === INSERT S - FWEST)Koroyasu �r������̉���
                '�r������
                '2019/05/23 CHG START
                'Call CF_Del_EXCTBZ2()
                CF_Unlock_EXCTBZ2()
                '2019/05/23 CHG END
                ' === 20130711 === INSERT E -

                '���׍��ڂ��擾
                For intCnt = 1 To UBound(Tbl_Inf_UDNTRA)
					With pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf
						.DKBID = Tbl_Inf_UDNTRA(intCnt).DKBID
						.DKBNM = Tbl_Inf_UDNTRA(intCnt).DKBNM
						
						'�}�X�^�`�F�b�N
						If SYSTBD_SEARCH(pc_strDKBSB_URK, .DKBID, Mst_Inf_SYSTBD) = 0 Then
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Bus_Inf.SYSTBD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							.SYSTBD = Mst_Inf_SYSTBD
						Else
							Call DB_SYSTBD_Clear(.SYSTBD)
						End If
						
						.KANKOZ = Tbl_Inf_UDNTRA(intCnt).HINSIRCD
						
						.NYUKN = Tbl_Inf_UDNTRA(intCnt).NYUKN
						.FNYUKN = Tbl_Inf_UDNTRA(intCnt).FNYUKN
						
						'�Q�F�U�� �������́A�R�F��` �̏ꍇ�́A��s��ǂݍ���
						If .DKBID = pc_strDKBID_URK_HURI Or .DKBID = pc_strDKBID_URK_TEG Then
							.BNKCD = Tbl_Inf_UDNTRA(intCnt).BNKCD
							If DSPBANK_SEARCH(.BNKCD, Mst_Inf_BNKMTA) = 0 Then
								.BNKNM = Mst_Inf_BNKMTA.BNKNM
								.STNNM = Mst_Inf_BNKMTA.STNNM
							Else
								.BNKNM = ""
								.STNNM = ""
							End If
						Else
							.BNKCD = ""
							.BNKNM = ""
							.STNNM = ""
						End If
						
						'2009/06/05 DEL START FKS)NAKATA
						'.JDNNO = Tbl_Inf_UDNTRA(intCnt).JDNNO
						'.JDNLINNO = Tbl_Inf_UDNTRA(intCnt).JDNLINNO
						'2009/06/05 DEL E.N.E FKS)NAKATA
						
						
						'2009/06/05 ADD START FKS)NAKATA
						.JDNNO = Left(Tbl_Inf_UDNTRA(intCnt).OKRJONO, 6)
						.JDNLINNO = Mid(Tbl_Inf_UDNTRA(intCnt).OKRJONO, 7, 3)
						' === 20130711 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
						'�r���`�F�b�N
						If Trim(.JDNNO) <> "" Then
                            '2019/05/23 CHG START
                            'rResult = CF_Chk_EXCTBZ(.JDNNO)
                            '2019/05/23 CHG END
                            Select Case rResult
								'����
								Case 0
									
									'�r��������
								Case 1
									Retn_Code = CHK_ERR_ELSE
									Err_Cd = "2_EXCUPD" '���̃v���O�����ōX�V���̂��߁A�����ł��܂���B
									GoTo F_Chk_HD_DATNO_End
									
									'�ُ�I��
								Case 9
									Retn_Code = CHK_ERR_ELSE
									Err_Cd = gc_strMsgURKET52_E_004 '�X�V�ُ�
									GoTo F_Chk_HD_DATNO_End
							End Select
						End If
						' === 20130711 === INSERT E -
						
						.OKRJONO = Tbl_Inf_UDNTRA(intCnt).OKRJONO
						'2009/06/05 ADD E.N.D FKS)NAKATA
						
						'2009/09/30 ADD START RISE)MIYAJIMA
						.DATNO = Tbl_Inf_UDNTRA(intCnt).DATNO
						.LINNO = Tbl_Inf_UDNTRA(intCnt).LINNO
						'2009/09/30 ADD E.N.D RISE)MIYAJIMA
						
						'2009/09/24 DEL START RISE)MIYAJIMA
						''2009/09/18 UPD START RISE)MIYAJIMA
						''                    .TEGDT = Tbl_Inf_UDNTRA(intCnt).TEGDT
						'                    If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML Then
						'                        .TEGDT = Tbl_Inf_UDNTRA(intCnt).TEGDT
						'                    Else
						'                        If .DKBID = pc_strDKBID_URK_SOSAI Or _
						''                           .DKBID = pc_strDKBID_URK_NEBIK Or _
						''                           .DKBID = pc_strDKBID_URK_TESU Or _
						''                           .DKBID = pc_strDKBID_URK_HOKA Or _
						''                           .DKBID = pc_strDKBID_URK_SYOH Then
						'                            .TEGDT = "        "
						'                        Else
						'                            .TEGDT = Tbl_Inf_UDNTRA(intCnt).TEGDT
						'                        End If
						'                    End If
						''2009/09/18 UPD E.N.D RISE)MIYAJIMA
						'2009/09/24 DEL E.N.D RISE)MIYAJIMA
						'2009/09/24 ADD START RISE)MIYAJIMA
						.TEGDT = Tbl_Inf_UDNTRA(intCnt).TEGDT
						'2009/09/24 ADD E.N.D RISE)MIYAJIMA
						.TEGNO = Tbl_Inf_UDNTRA(intCnt).TEGNO
						
						.LINCMA = Tbl_Inf_UDNTRA(intCnt).LINCMA
						.LINCMB = Tbl_Inf_UDNTRA(intCnt).LINCMB
					End With
				Next intCnt
				
				'�n�j
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
			End If
		End If
		
F_Chk_HD_DATNO_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_DATNO = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_HD_DATNO_Inf
	'   �T�v�F  ���o�F���������Ώۂɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_DATNO_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		Dim Wk_Row As Short
		Dim Bd_Index As Short
		Dim intCnt As Short
		
		Dim blnUpd As Boolean
		Dim blnInputRow As Boolean
		'// V1.10�� ADD
		Dim blnTEGDTERR As Boolean
		'// V1.10�� ADD
		
		blnUpd = False
		
		'// V1.10�� ADD
		blnTEGDTERR = False
		'// V1.10�� ADD
		
		'2009/09/24 ADD START RISE)MIYAJIMA
		Dim strTEGDT As String
		'2009/09/24 ADD E.N.D RISE)MIYAJIMA
		
		Dim strJdnNo As String
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'�r���������������������������������������������������������r
				
				'�y���������Ώہz
				Trg_Index = CShort(FR_SSSMAIN.HD_DATNO.Tag)
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(URKET52_HEAD_Inf.DATNO, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'�y�����敪�z
				Trg_Index = CShort(FR_SSSMAIN.HD_NYUKB.Tag)
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(URKET52_HEAD_Inf.NYUKB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'�y�������z
				Trg_Index = CShort(FR_SSSMAIN.HD_NYUDT.Tag)
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(URKET52_HEAD_Inf.NYUDT, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'�y������R�[�h�z
				Trg_Index = CShort(FR_SSSMAIN.HD_TOKCD.Tag)
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(URKET52_HEAD_Inf.TOKCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'�y�����於�z
				Trg_Index = CShort(FR_SSSMAIN.HD_TOKRN.Tag)
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(URKET52_HEAD_Inf.TOKMTA.TOKRN, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'�y�ʉ݁z
				Trg_Index = CShort(FR_SSSMAIN.HD_TUKKB.Tag)
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(URKET52_HEAD_Inf.TOKMTA.TUKKB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
					
					'��ʂ̍s
					Bd_Index = intCnt
					'pm_All.Dsp_Body_Inf�̍s�m�n���擾
					Wk_Row = intCnt
					
					blnInputRow = False
					
					'�s�̏�Ԃ�ݒ�
					If UBound(URKET52_HEAD_Inf.UDNTRA) >= Bd_Index Then
						'�f�[�^�̂���s����͍ςݏ�Ԃɂ���
						pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_INPUT
						blnInputRow = True
					ElseIf (UBound(URKET52_HEAD_Inf.UDNTRA) + 1) = Bd_Index Then 
						'�Ō�̍s��ݒ�
						pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW
					Else
						'�󔒍s��ݒ�
						pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_DEFAULT
					End If
					
					If blnInputRow = True Then
						'�y�������(�R�[�h)�z
						Wk_Index = CShort(FR_SSSMAIN.BD_DKBID(0).Tag)
						
						'��ʂɕҏW
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'�y�������(����)�z
						Wk_Index = CShort(FR_SSSMAIN.BD_DKBNM(0).Tag)
						
						'��ʂɕҏW
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBNM, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'�y��������z
						Wk_Index = CShort(FR_SSSMAIN.BD_KANKOZ(0).Tag)
						
						'��ʂɕҏW
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.KANKOZ, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.KANKOZ, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)

                        '�y�����z(�~)�z
                        Wk_Index = CShort(FR_SSSMAIN.BD_NYUKN(0).Tag)

                        '��ʂɕҏW
                        Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.NYUKN, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.NYUKN, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'�y�����z(�O��)�z
						Wk_Index = CShort(FR_SSSMAIN.BD_FNYUKN(0).Tag)
						
						'��ʂɕҏW
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.FNYUKN, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.FNYUKN, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'�y��s�R�[�h�z
						Wk_Index = CShort(FR_SSSMAIN.BD_BNKCD(0).Tag)
						
						'��ʂɕҏW
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKCD, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKCD, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'�y��s���́z
						Wk_Index = CShort(FR_SSSMAIN.BD_BNKNM(0).Tag)
						
						'��ʂɕҏW
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKNM, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'�y�󒍔ԍ��z
						Wk_Index = CShort(FR_SSSMAIN.BD_JDNNO(0).Tag)
						
						strJdnNo = Left(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.JDNNO, 6) & Mid(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.JDNLINNO, 2, 2)
						
						'2009/06/05 ADD START FKS)NAKATA
						'                    strJdnNo = Left$(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.OKRJONO, 6) _
						''                             & Mid$(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.OKRJONO, 8, 2)
						'2009/06/05 ADD E.N.D FKS)NAKATA
						
						
						'��ʂɕҏW
						Call CF_Edi_Dsp_Body_Item(strJdnNo, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
						Call CF_Edi_Dsp_Body_Inf(strJdnNo, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'�y�x�X���́z
						Wk_Index = CShort(FR_SSSMAIN.BD_STNNM(0).Tag)
						
						'��ʂɕҏW
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.STNNM, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.STNNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'�y���ϓ��z
						Wk_Index = CShort(FR_SSSMAIN.BD_TEGDT(0).Tag)
						
						'2009/09/24 ADD START RISE)MIYAJIMA
						If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML Then
							strTEGDT = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT
						Else
							If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID = pc_strDKBID_URK_SOSAI Or pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID = pc_strDKBID_URK_NEBIK Or pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID = pc_strDKBID_URK_TESU Or pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID = pc_strDKBID_URK_HOKA Or pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID = pc_strDKBID_URK_SYOH Then
								strTEGDT = "        "
							Else
								strTEGDT = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT
							End If
						End If
						'2009/09/24 ADD E.N.D RISE)MIYAJIMA
						
						'2009/09/24 UPD START RISE)MIYAJIMA
						'                    '��ʂɕҏW
						'                    Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT _
						''                                            , pm_All.Dsp_Sub_Inf(Wk_Index) _
						''                                            , Wk_Row _
						''                                            , pm_All _
						''                                            , SET_FLG_DB)
						'
						'                    '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
						'                    Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT _
						''                                            , pm_All.Dsp_Sub_Inf(Wk_Index) _
						''                                            , Bd_Index _
						''                                            , pm_All _
						''                                            , SET_FLG_DB)
						'��ʂɕҏW
						Call CF_Edi_Dsp_Body_Item(strTEGDT, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
						Call CF_Edi_Dsp_Body_Inf(strTEGDT, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						'2009/09/24 UPD E.N.D RISE)MIYAJIMA
						
						'�y��`�ԍ��z
						Wk_Index = CShort(FR_SSSMAIN.BD_TEGNO(0).Tag)
						
						'��ʂɕҏW
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGNO, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGNO, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'�y���l�P�z
						Wk_Index = CShort(FR_SSSMAIN.BD_LINCMA(0).Tag)
						
						'��ʂɕҏW
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.LINCMA, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.LINCMA, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'�y���l�Q�z
						Wk_Index = CShort(FR_SSSMAIN.BD_LINCMB(0).Tag)
						
						'��ʂɕҏW
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.LINCMB, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.LINCMB, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						'// V1.10�� ADD
						If Trim(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT) <> "" Then
							If GV_UNYDate > pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT Then
								blnTEGDTERR = True
							End If
						End If
						'// V1.10�� ADD
					Else
						'�y�������(�R�[�h)�z
						Wk_Index = CShort(FR_SSSMAIN.BD_DKBID(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
						
						'�y�������(����)�z
						Wk_Index = CShort(FR_SSSMAIN.BD_DKBNM(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
						
						'�y��������z
						Wk_Index = CShort(FR_SSSMAIN.BD_KANKOZ(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
						
						'�y�����z(�~)�z
						Wk_Index = CShort(FR_SSSMAIN.BD_NYUKN(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
						
						'�y�����z(�O��)�z
						Wk_Index = CShort(FR_SSSMAIN.BD_FNYUKN(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
						
						'�y��s�R�[�h�z
						Wk_Index = CShort(FR_SSSMAIN.BD_BNKCD(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
						
						'�y��s���́z
						Wk_Index = CShort(FR_SSSMAIN.BD_BNKNM(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
						
						'�y�󒍔ԍ��z
						Wk_Index = CShort(FR_SSSMAIN.BD_JDNNO(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
						
						'�y�x�X���́z
						Wk_Index = CShort(FR_SSSMAIN.BD_STNNM(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
						
						'�y���ϓ��z
						Wk_Index = CShort(FR_SSSMAIN.BD_TEGDT(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
						
						'�y��`�ԍ��z
						Wk_Index = CShort(FR_SSSMAIN.BD_TEGNO(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
						
						'�y���l�P�z
						Wk_Index = CShort(FR_SSSMAIN.BD_LINCMA(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
						
						'�y���l�Q�z
						Wk_Index = CShort(FR_SSSMAIN.BD_LINCMB(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
						
						'���̏�����
						With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf '�P�s�ڂ̃f�[�^
							.DKBID = ""
							.DKBNM = ""
							.KANKOZ = ""
							.NYUKN = 0
							.FNYUKN = 0
							.BNKCD = ""
							.BNKNM = ""
							.JDNNO = ""
							.JDNLINNO = ""
							.STNNM = ""
							.TEGDT = ""
							.TEGNO = ""
							.LINCMA = ""
							.LINCMB = ""
							'2009/06/05 ADD START FKS)NAKATA
							.OKRJONO = ""
							'2009/06/05 ADD E.N.D FKS)NAKATA
							Call DB_SYSTBD_Clear(.SYSTBD)
						End With
					End If
				Next intCnt
				
				blnUpd = True
				'// V1.10�� ADD
				If blnTEGDTERR = True Then
					'2009/09/24 UPD START RISE)MIYAJIMA
					'                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_030, pm_All)
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_035, pm_All)
					'2009/09/24 UPD E.N.D RISE)MIYAJIMA
				End If
				'// V1.10�� ADD
				'�d���������������������������������������������������������d
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'�N���A
			'�r���������������������������������������������������������r
			'�y���������Ώہz
			Trg_Index = CShort(FR_SSSMAIN.HD_DATNO.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'�y�����敪�z
			Trg_Index = CShort(FR_SSSMAIN.HD_NYUKB.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'�y�������z
			Trg_Index = CShort(FR_SSSMAIN.HD_NYUDT.Tag)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Dsp_Value = CF_Cnv_Dsp_Item(GV_UNYDate, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
			
			'�y������R�[�h�z
			Trg_Index = CShort(FR_SSSMAIN.HD_TOKCD.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'�y�����於�z
			Trg_Index = CShort(FR_SSSMAIN.HD_TOKRN.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'�y�ʉ݋敪�z
			Trg_Index = CShort(FR_SSSMAIN.HD_TUKKB.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'���̏�����
			URKET52_HEAD_Inf.DATNO = ""
			URKET52_HEAD_Inf.NYUKB = ""
			URKET52_HEAD_Inf.NYUDT = GV_UNYDate
			URKET52_HEAD_Inf.TOKCD = ""
            'Call DB_TOKMTA_Clear(URKET52_HEAD_Inf.TOKMTA)

            '���ׂ����ׂč폜����
            For Wk_Row = pm_All.Dsp_Base.Max_Body_Cnt To 1 Step -1
				If Wk_Row = 1 Then
					'�P�s�ڂ́A���ڂ��N���A
					
					'�y�������(�R�[�h)�z
					Wk_Index = CShort(FR_SSSMAIN.BD_DKBID(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
					
					'�y�������(����)�z
					Wk_Index = CShort(FR_SSSMAIN.BD_DKBNM(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
					
					'�y��������z
					Wk_Index = CShort(FR_SSSMAIN.BD_KANKOZ(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
					
					'�y�����z(�~)�z
					Wk_Index = CShort(FR_SSSMAIN.BD_NYUKN(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
					
					'�y�����z(�O��)�z
					Wk_Index = CShort(FR_SSSMAIN.BD_FNYUKN(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
					
					'�y��s�R�[�h�z
					Wk_Index = CShort(FR_SSSMAIN.BD_BNKCD(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
					
					'�y��s���́z
					Wk_Index = CShort(FR_SSSMAIN.BD_BNKNM(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
					
					'�y�󒍔ԍ��z
					Wk_Index = CShort(FR_SSSMAIN.BD_JDNNO(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
					
					'�y�x�X���́z
					Wk_Index = CShort(FR_SSSMAIN.BD_STNNM(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
					
					'�y���ϓ��z
					Wk_Index = CShort(FR_SSSMAIN.BD_TEGDT(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
					
					'�y��`�ԍ��z
					Wk_Index = CShort(FR_SSSMAIN.BD_TEGNO(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
					
					'�y���l�P�z
					Wk_Index = CShort(FR_SSSMAIN.BD_LINCMA(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
					
					'�y���l�Q�z
					Wk_Index = CShort(FR_SSSMAIN.BD_LINCMB(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '��ʃN���A
					
					Bd_Index = Wk_Row
					
					'���̏�����
					With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf '�P�s�ڂ̃f�[�^
						.DKBID = ""
						.DKBNM = ""
						.KANKOZ = ""
						.NYUKN = 0
						.FNYUKN = 0
						.BNKCD = ""
						.BNKNM = ""
						.JDNNO = ""
						.JDNLINNO = ""
						.STNNM = ""
						.TEGDT = ""
						.TEGNO = ""
						.LINCMA = ""
						.LINCMB = ""
						'2009/06/05 ADD START FKS)NAKATA
						.OKRJONO = ""
						'2009/06/05 ADD E.N.D FKS)NAKATA
						Call DB_SYSTBD_Clear(.SYSTBD)
					End With
					
					'�s����ԕύX
					pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW
				Else
					'�P�s�ڈȊO�́A�s�폜����
					Wk_Index = CShort(FR_SSSMAIN.BD_DKBID(Wk_Row).Tag)
					If CF_Jge_Enabled_MN_DeleteDE(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All) = True Then
						Call CF_Ctl_MN_DeleteDE(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
					End If
					
					'�F���c���Ă��܂��ꍇ������̂ŁA�Ώ�
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Wk_Index), ITEM_NORMAL_STATUS, pm_All)
					
					'�s����ԕύX
					pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_DEFAULT
				End If
			Next 
			
			'�d���������������������������������������������������������d
		End If
		
		If blnUpd = True Then
			'** ���۰ِ��� **
			'�y�󒍔ԍ��z
			If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
				'�O�����
				Call F_Util_JDNNO_SetOnOff(True, pm_All)
			Else
				'����
				Call F_Util_JDNNO_SetOnOff(False, pm_All)
				Call F_Util_JDNNO_Clear(pm_All)
			End If
			
			'�y�����z(�O��)�z
			If URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN Then
				Call F_Util_FNYUKN_SetOnOff(True, pm_All) '�C�O
			Else
				Call F_Util_FNYUKN_SetOnOff(False, pm_All) '�������A�G���[
				Call F_Util_FNYUKN_Clear(pm_All)
			End If
			Call F_Util_FNYUKN_Sum(pm_All)
			
			'�y�����z(�~)�z
			Call F_Util_NYUKN_Sum(pm_All)
			
			'������ʂɉ����čs�̗L���E������ύX����
			Call F_Util_DKBID_SwitchOnOff(1, pm_All)
			Call F_Util_DKBID_SwitchOnOff(2, pm_All)
			Call F_Util_DKBID_SwitchOnOff(3, pm_All)
			Call F_Util_DKBID_SwitchOnOff(4, pm_All)
			Call F_Util_DKBID_SwitchOnOff(5, pm_All)
			Call F_Util_DKBID_SwitchOnOff(6, pm_All)
		End If
		
		'�O��`�F�b�N���e�ɑޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_HD_NYUKB
	'   �T�v�F  ���o�F�����敪������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_NYUKB(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_HD_NYUKB = Retn_Code
			Exit Function
		End If
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'���̏�����
		URKET52_HEAD_Inf.NYUKB = ""

        '�����̓`�F�b�N
        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            '2019/06/06 ADD START
            Retn_Code = CHK_ERR_NOT_INPUT
            Err_Cd = ""
            '2019/06/06 ADD END
        Else
            '�����͈ȊO�̃`�F�b�N��
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '��b�`�F�b�N
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgURKET52_E_007 '���͔͈͊O
            Else
                '2019/06/06 ADD START
                Select Case CShort(Input_Value)
                    Case 1, 2 '�P�F�����A�Q�F�O�����
                        '2019/06/06 ADD END
                        '�n�j
                        Retn_Code = CHK_OK
                        pm_Chk_Move = True

                        URKET52_HEAD_Inf.NYUKB = Input_Value
                        '2019/06/06 ADD START
                    Case Else
                        Retn_Code = CHK_ERR_ELSE
                        'Err_Cd = gc_strMsgURKET51_E_011 '�Y���f�[�^�Ȃ�
                        pm_Chk_Move = True
                End Select
                '2019/06/06 ADD END
            End If
		End If
		
F_Chk_HD_NYUKB_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_NYUKB = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_HD_NYUKB_Inf
	'   �T�v�F  ���o�F�����敪�ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_NYUKB_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
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
	'   ���́F  Function F_Chk_HD_NYUDT
	'   �T�v�F  ���o�F������������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_NYUDT(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'2009/09/23 DEL START RISE)MIYAJIMA
		'    '�`�F�b�N���s����
		'    Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		'    If Rtn_Cd = CHK_STOP Then
		'        '���f�̏ꍇ
		'        F_Chk_HD_NYUDT = Retn_Code
		'        Exit Function
		'    End If
		'2009/09/23 DEL E.N.D RISE)MIYAJIMA
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'���̏�����
		URKET52_HEAD_Inf.NYUDT = ""
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Dim date1 As String
		Dim date2 As String
		Dim date3 As String
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_NOT_INPUT
			Err_Cd = ""
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_008 '���͔͈͊O
			Else
				'�V�X�e�����t��薢���̓G���[
				If Input_Value > GV_UNYDate Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_015
				Else
					'''' UPD 2011/01/14  FKS) T.Yamamoto    Start    �A���[��FC11011401
					'�����{�����̏����P�p
					'                '�O�񌎎��X�V���s�����ߋ��̓G���[
					'                If Trim(Input_Value) <= Trim(pv_strMONUPDDT) Then
					'�O��o�������s�����ߋ��̓G���[
					If Trim(Input_Value) <= Trim(pv_strSMAUPDDT) Then
						'''' UPD 2011/01/14  FKS) T.Yamamoto    End
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgURKET52_E_016
                        GoTo F_Chk_HD_NYUDT_End
                    End If
					'2009/09/03 ADD START RISE)MIYAJIMA
					'���.������ <= �O�񐿋����̏ꍇ�̓G���[��\������
					If Trim(Input_Value) <= Trim(URKET52_HEAD_Inf.TOKMTA.TOKSMEDT) Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgURKET52_E_033
						GoTo F_Chk_HD_NYUDT_End
					End If
					'2009/09/03 ADD E.N.D RISE)MIYAJIMA
					
					'''' ADD 2011/01/14  FKS) T.Yamamoto    Start    �A���[��FC11011401
					'���߂��ׂ��ł̓��t�̓G���[
					date1 = VB6.Format(CNV_DATE(Left(pv_strSMAUPDDT, 6) & "01"), "YYYY/MM/DD")
					date2 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 2, CDate(date1)))
					date3 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, CDate(date2)))
					If Trim(Input_Value) > DeCNV_DATE(date3) Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgURKET52_E_042
						GoTo F_Chk_HD_NYUDT_End
					End If
					'''' ADD 2011/01/14  FKS) T.Yamamoto    End
					
					'�n�j
					Retn_Code = CHK_OK
					pm_Chk_Move = True
					
					URKET52_HEAD_Inf.NYUDT = Input_Value
				End If
			End If
		End If
		
F_Chk_HD_NYUDT_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_NYUDT = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_HD_NYUDT_Inf
	'   �T�v�F  ���o�F�������ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_NYUDT_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
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
	'   ���́F  Function F_Chk_HD_TOKCD
	'   �T�v�F  ���o�F������R�[�h������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_TOKCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		'2009/09/03 ADD START RISE)MIYAJIMA
		Dim strTANCLAKB As String
		'2009/09/03 ADD E.N.D RISE)MIYAJIMA
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_HD_TOKCD = Retn_Code
			Exit Function
		End If
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'���̏�����
		URKET52_HEAD_Inf.TOKCD = ""
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '���͔͈͊O
			Else
				'2009/09/03 ADD START RISE)MIYAJIMA
				'�c�ƒS���t���O���擾
				Call F_Util_GET_TANMTA_TANCLAKB(URKET52_HEAD_Inf.TOKMTA.TANCD, strTANCLAKB)
				If strTANCLAKB <> "1" Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_034 '������S���҂��c�Ƃł���܂���
					GoTo F_Chk_HD_TOKCD_End
				End If
				'���.������ <= �O�񐿋����̏ꍇ�̓G���[��\������
				If Trim(URKET52_HEAD_Inf.NYUDT) <= Trim(URKET52_HEAD_Inf.TOKMTA.TOKSMEDT) Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_033
					GoTo F_Chk_HD_TOKCD_End
				End If
				'2009/09/03 ADD E.N.D RISE)MIYAJIMA
				
				'�n�j
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				URKET52_HEAD_Inf.TOKCD = Input_Value
			End If
		End If
		
F_Chk_HD_TOKCD_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_TOKCD = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_HD_TOKCD_Inf
	'   �T�v�F  ���o�F������R�[�h�ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_TOKCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
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
	'   ���́F  Function F_Chk_HD_TOKRN
	'   �T�v�F  ���o�F�����於�̂�����
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_TOKRN(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_HD_TOKRN = Retn_Code
			Exit Function
		End If
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'���̏�����
		URKET52_HEAD_Inf.TOKMTA.TOKRN = ""
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '���͔͈͊O
			Else
				'�n�j
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				URKET52_HEAD_Inf.TOKMTA.TOKRN = Input_Value
			End If
		End If
		
F_Chk_HD_TOKRN_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_TOKRN = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_HD_TOKRN_Inf
	'   �T�v�F  ���o�F�����於�̂ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_TOKRN_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
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
	'   ���́F  Function F_Chk_HD_TUKKB
	'   �T�v�F  ���o�F�ʉ݂�����
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_TUKKB(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_HD_TUKKB = Retn_Code
			Exit Function
		End If
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'���̏�����
		URKET52_HEAD_Inf.TOKMTA.TUKKB = ""
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '���͔͈͊O
			Else
				'�n�j
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				URKET52_HEAD_Inf.TOKMTA.TUKKB = Input_Value
			End If
		End If
		
F_Chk_HD_TUKKB_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_TUKKB = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_HD_TUKKB_Inf
	'   �T�v�F  ���o�F�ʉ݂ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_TUKKB_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
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
	'   ���́F  Function F_Chk_HD_KNJKOZ
	'   �T�v�F  ���o�F�������������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_KNJKOZ(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Mst_Inf As TYPE_DB_MEIMTA
		
		'2009/09/03 DEL START RISE)MIYAJIMA
		'    '�`�F�b�N���s����
		'    Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		'    If Rtn_Cd = CHK_STOP Then
		'        '���f�̏ꍇ
		'        F_Chk_HD_KNJKOZ = Retn_Code
		'        Exit Function
		'    End If
		'2009/09/03 DEL E.N.D RISE)MIYAJIMA
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'���̏�����
		URKET52_HEAD_Inf.KNJKOZ = ""
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '���͔͈͊O
			Else
				'�}�X�^�`�F�b�N
				If F_Util_KNJKOZ_Search(Input_Value, Mst_Inf) = 0 Then
					'�_���폜�`�F�b�N
					Select Case True
						Case Mst_Inf.DATKB = gc_strDATKB_DEL
							Retn_Code = CHK_ERR_ELSE
							Err_Cd = gc_strMsgURKET52_E_009 '�폜�ς݃f�[�^
						Case Else
							'�n�j
							Retn_Code = CHK_OK
							pm_Chk_Move = True
							
							URKET52_HEAD_Inf.KNJKOZ = Input_Value
					End Select
				Else
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_011 '�Y���f�[�^�Ȃ�
				End If
			End If
		End If
		
F_Chk_HD_KNJKOZ_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_KNJKOZ = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_HD_KNJKOZ_Inf
	'   �T�v�F  ���o�F��������ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_KNJKOZ_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		Dim Bd_Index As Short
		Dim Wk_Row As Short
		Dim intCnt As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'�r���������������������������������������������������������r
				
				If Trim(URKET52_HEAD_Inf.KNJKOZ) <> "" Then
					For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
						'���łɓ��͂���Ă��閾�ׁF�������������������
						
						'�y��������z
						Wk_Index = CShort(FR_SSSMAIN.BD_KANKOZ(intCnt).Tag)
						
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Wk_Index))) <> "" Then
							'If Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.KANKOZ) <> "" Then
							pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.KANKOZ = URKET52_HEAD_Inf.KNJKOZ
							
							'��ʂ̍s
							Wk_Row = intCnt
							
							'pm_All.Dsp_Body_Inf�̍s�m�n���擾
							Bd_Index = intCnt
							
							'��ʂɕҏW
							Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.KANKOZ, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
							'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
							Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.KANKOZ, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						End If
					Next intCnt
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
	'   ���́F  Function F_Chk_BD_DKBID
	'   �T�v�F  ���ׁF������ʃR�[�h������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_DKBID(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Wk_Row As Short
		Dim Bd_Index As Short
		Dim Mst_Inf_SYSTBD As TYPE_DB_SYSTBD
		Dim Mst_Inf_BNKMTA As TYPE_DB_BNKMTA
		Dim strTOKCD As String
		Dim dteNYUDT As Date
		
		'''' ADD 2009/12/28  FKS) T.Yamamoto    Start    �A���[��767
		Dim strKNJKOZ As String
		Dim Mst_Inf_MEIMTA As TYPE_DB_MEIMTA
		'''' ADD 2009/12/28  FKS) T.Yamamoto    End
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_DKBID = Retn_Code
			Exit Function
		End If
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		'''' ADD 2009/12/28  FKS) T.Yamamoto    Start    �A���[��767
		strKNJKOZ = ""
		'''' ADD 2009/12/28  FKS) T.Yamamoto    End
		
		'��ʂ̍s
		Wk_Row = pm_Chk_Dsp_Sub_Inf.Detail.Body_Index
		'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'���̏�����
		With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
			.DKBID = ""
			.DKBNM = ""
			.BNKCD = ""
			.BNKNM = ""
			.STNNM = ""
			.TEGDT = ""
			.TEGNO = ""
			Call DB_SYSTBD_Clear(.SYSTBD)
		End With
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '���͔͈͊O
			Else
				'�}�X�^�`�F�b�N
				If SYSTBD_SEARCH(pc_strDKBSB_URK, Input_Value, Mst_Inf_SYSTBD) = 0 Then
					'''' ADD 2009/12/28  FKS) T.Yamamoto    Start    �A���[��767
					'����������w�肳��Ă���ꍇ�A���̃}�X�^������
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strKNJKOZ = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.BD_KANKOZ(Bd_Index).Tag))))
					If strKNJKOZ <> "" Then
						If F_Util_KNJKOZ_Search(strKNJKOZ, Mst_Inf_MEIMTA) = 0 Then
							'��`�̊���������w�肳��Ă���ꍇ
							If Trim(Mst_Inf_MEIMTA.MEINMC) = pc_strKNJKOZ_TEG Then
								'�R�F��`�ȊO�̏ꍇ�A�G���[
								If Input_Value <> pc_strDKBID_URK_TEG Then
									Retn_Code = CHK_ERR_ELSE
									Err_Cd = gc_strMsgURKET52_E_041 '��`�̊���������w�肳��Ă��܂��B
									GoTo F_Chk_BD_DKBID_End
								End If
								'��`�̊�������ȊO���w�肳��Ă���ꍇ
							Else
								'�R�F��`�̏ꍇ�A�G���[
								If Input_Value = pc_strDKBID_URK_TEG Then
									Retn_Code = CHK_ERR_ELSE
									Err_Cd = gc_strMsgURKET52_E_040 '��������̎�ʂ���`�ł͂���܂���B
									GoTo F_Chk_BD_DKBID_End
								End If
							End If
						Else
							Retn_Code = CHK_ERR_ELSE
							Err_Cd = gc_strMsgURKET52_E_011 '�Y���f�[�^�Ȃ�
							GoTo F_Chk_BD_DKBID_End
						End If
					End If
					'''' ADD 2009/12/28  FKS) T.Yamamoto    End
					
					'�n�j
					Retn_Code = CHK_OK
					pm_Chk_Move = True
					
					With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
						.DKBID = Input_Value
						.DKBNM = Mst_Inf_SYSTBD.DKBNM
						If Trim(URKET52_HEAD_Inf.KNJKOZ) <> "" Then
							.KANKOZ = URKET52_HEAD_Inf.KNJKOZ
						End If
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Bus_Inf.SYSTBD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.SYSTBD = Mst_Inf_SYSTBD
					End With
					
					'// V1.20�� UPD
					'                '�Q�F�U�� �������́A�R�F��` �̏ꍇ�́A��s��ǂݍ���
					'                If Input_Value = pc_strDKBID_URK_HURI Or Input_Value = pc_strDKBID_URK_TEG Then
					'�Q�F�U�� �̏ꍇ�́A��s��ǂݍ���
					If Input_Value = pc_strDKBID_URK_HURI Then
						'// V1.20�� UPD
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						strTOKCD = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.HD_TOKCD.Tag)))
						
						With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
							.BNKCD = URKET52_HEAD_Inf.TOKMTA.BNKCD
						End With
						
						'��s���������A���̂��擾
						If DSPBANK_SEARCH_ALL(URKET52_HEAD_Inf.TOKMTA.BNKCD, Mst_Inf_BNKMTA) = 0 Then
							With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
								.BNKNM = Mst_Inf_BNKMTA.BNKNM
								.STNNM = Mst_Inf_BNKMTA.STNNM
							End With
						End If
					End If
					
					'�R�F��` �̏ꍇ�́A���ϓ���ǂݍ���
					If Input_Value = pc_strDKBID_URK_TEG Then
						'���͂��ꂽ�������{���Ӑ�D�T�C�g�̓������Z�������t
						dteNYUDT = CDate(VB6.Format(URKET52_HEAD_Inf.NYUDT, "@@@@/@@/@@"))
						
						dteNYUDT = DateSerial(Year(dteNYUDT), Month(dteNYUDT), VB.Day(dteNYUDT) + URKET52_HEAD_Inf.TOKMTA.NYUDD)
						
						With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
							.TEGDT = VB6.Format(dteNYUDT, "yyyymmdd")
						End With
					End If
					
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Or pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_DEF Then
						'�ύX����Ă��Ȃ��ꍇ�́A�������s��Ȃ�
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
							GoTo F_Chk_BD_DKBID_End
						End If
					End If
					
					'������ʂ̃_�~�[�t���O�P�Ɠ��Ӑ�}�X�^(��������)�D�x���敪�̊֘A
					Select Case URKET52_HEAD_Inf.TOKMTA.SHAKB
						Case pc_strSHAKB_HURI, pc_strSHAKB_TEG, pc_strSHAKB_HURI_OR_TEG, pc_strSHAKB_HURI_AND_TEG
							'2009/09/18 ADD START RISE)MIYAJIMA
							If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID = pc_strDKBID_URK_HURIK Then
								Retn_Code = CHK_ERR_ELSE '�G���[
								'2009/09/23 UPD START RISE)MIYAJIMA
								'                            Err_Cd = gc_strMsgURKET52_E_017
								Err_Cd = gc_strMsgURKET52_E_037
								'2009/09/23 UPD E.N.D RISE)MIYAJIMA
								GoTo F_Chk_BD_DKBID_End
							End If
							'2009/09/18 ADD E.N.D RISE)MIYAJIMA
							'���Ӑ�}�X�^�D�x���敪���P�F�U�� or �Q�F��` or �R�F�U���܂��͎�` or �S�F�U����`���p
							If Trim(Mst_Inf_SYSTBD.DKBFLA) <> "" Then
								'�G���[
								'2018/11/08 ADD START <C2-20170130-01> CIS)�R��
								'                            Retn_Code = CHK_ERR_ELSE
								Retn_Code = CHK_WARN '���[�j���O
								'2018/11/08 ADD END <C2-20170130-01> CIS)�R��
								Err_Cd = gc_strMsgURKET52_E_017
								GoTo F_Chk_BD_DKBID_End
							End If
							
						Case pc_strSHAKB_KIJZITU, pc_strSHAKB_FACTERING
							'���Ӑ�}�X�^�D�x���敪���T�F�����U�� or �U�F�t�@�N�^�����O
							
							'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(Mst_Inf_SYSTBD.DKBFLA) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If SSSVal(Mst_Inf_SYSTBD.DKBFLA) < 1 Then
								'�G���[
								Retn_Code = CHK_WARN '���[�j���O
								Err_Cd = gc_strMsgURKET52_E_017
								GoTo F_Chk_BD_DKBID_End
							End If
							
					End Select
				Else
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_011 '�Y���f�[�^�Ȃ�
				End If
			End If
		End If
		
F_Chk_BD_DKBID_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_DKBID = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_BD_DKBID_Inf
	'   �T�v�F  ���ׁF������ʃR�[�h�ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_DKBID_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
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
				
				'�y�������(����)�z
				Wk_Index = CShort(FR_SSSMAIN.BD_DKBNM(0).Tag)
				
				'��ʂɕҏW
				Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBNM, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
				
				'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
				Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
				
				'�y��������z
				Wk_Index = CShort(FR_SSSMAIN.BD_KANKOZ(0).Tag)
				
				'��ʂɕҏW
				Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.KANKOZ, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
				
				'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
				Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.KANKOZ, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
				
				'�y��s�R�[�h�z
				Wk_Index = CShort(FR_SSSMAIN.BD_BNKCD(0).Tag)
				
				'��ʂɕҏW
				Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKCD, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
				
				'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
				Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKCD, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
				
				'�y��s���́z
				Wk_Index = CShort(FR_SSSMAIN.BD_BNKNM(0).Tag)
				
				'��ʂɕҏW
				Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKNM, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
				
				'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
				Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
				
				'�y�x�X���́z
				Wk_Index = CShort(FR_SSSMAIN.BD_STNNM(0).Tag)
				
				'��ʂɕҏW
				Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.STNNM, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
				
				'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
				Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.STNNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
				
				'�y���ϓ��z
				Wk_Index = CShort(FR_SSSMAIN.BD_TEGDT(0).Tag)
				
				'��ʂɕҏW
				Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
				
				'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
				Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
				
				'�y��`�ԍ��z
				Wk_Index = CShort(FR_SSSMAIN.BD_TEGNO(0).Tag)
				
				'��ʂɕҏW
				Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGNO, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
				
				'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
				Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGNO, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
				
				'** ���۰ِ��� **
				Call F_Util_DKBID_SwitchOnOff(Wk_Row, pm_All)
				
				'�d���������������������������������������������������������d
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'�N���A
			'�r���������������������������������������������������������r
			
			'�y�������(����)�z
			Wk_Index = CShort(FR_SSSMAIN.BD_DKBNM(0).Tag)
			
			'��ʃN���A
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'�y��s�R�[�h�z
			Wk_Index = CShort(FR_SSSMAIN.BD_BNKCD(0).Tag)
			
			'��ʃN���A
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'�y��s���́z
			Wk_Index = CShort(FR_SSSMAIN.BD_BNKNM(0).Tag)
			
			'��ʃN���A
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'�y�x�X���́z
			Wk_Index = CShort(FR_SSSMAIN.BD_STNNM(0).Tag)
			
			'��ʃN���A
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'�y���ϓ��z
			Wk_Index = CShort(FR_SSSMAIN.BD_TEGDT(0).Tag)
			
			'��ʃN���A
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'�y��`�ԍ��z
			Wk_Index = CShort(FR_SSSMAIN.BD_TEGNO(0).Tag)
			
			'��ʃN���A
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'** ���۰ِ��� **
			Call F_Util_DKBID_SwitchOnOff(Wk_Row, pm_All)
			
			'�d���������������������������������������������������������d
		End If
		
		'�O��`�F�b�N���e�ɑޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_BD_DKBNM
	'   �T�v�F  ���ׁF������ʖ��̂�����
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_DKBNM(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_DKBNM = Retn_Code
			Exit Function
		End If
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'���̏�����
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBNM = ""
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '���͔͈͊O
			Else
				'�n�j
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBNM = Input_Value
			End If
		End If
		
F_Chk_BD_DKBNM_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_DKBNM = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_BD_DKBNM_Inf
	'   �T�v�F  ���ׁF������ʖ��̂ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_DKBNM_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
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
	'   ���́F  Function F_Chk_BD_KANKOZ
	'   �T�v�F  ���ׁF�������������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_KANKOZ(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		Dim Mst_Inf As TYPE_DB_MEIMTA
		
		'''' ADD 2009/12/28  FKS) T.Yamamoto    Start    �A���[��767
		Dim strDKBID As String
		'''' ADD 2009/12/28  FKS) T.Yamamoto    End
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_KANKOZ = Retn_Code
			Exit Function
		End If
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		'''' ADD 2009/12/28  FKS) T.Yamamoto    Start    �A���[��767
		strDKBID = ""
		'''' ADD 2009/12/28  FKS) T.Yamamoto    End
		
		'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'���̏�����
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.KANKOZ = ""
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '���͔͈͊O
			Else
				'�}�X�^�`�F�b�N
				If F_Util_KNJKOZ_Search(Input_Value, Mst_Inf) = 0 Then
					'�_���폜�`�F�b�N
					Select Case True
						Case Mst_Inf.DATKB = gc_strDATKB_DEL
							Retn_Code = CHK_ERR_ELSE
							Err_Cd = gc_strMsgURKET52_E_009 '�폜�ς݃f�[�^
						Case Else
							'''' ADD 2009/12/28  FKS) T.Yamamoto    Start    �A���[��767
							'������ʂ��w�肳��Ă���ꍇ
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							strDKBID = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.BD_DKBID(Bd_Index).Tag))))
							If strDKBID <> "" Then
								'������ʁ��R�F��`�̏ꍇ
								If strDKBID = pc_strDKBID_URK_TEG Then
									'��`�̊�������ȊO�̏ꍇ�G���[
									If Trim(Mst_Inf.MEINMC) <> pc_strKNJKOZ_TEG Then
										Retn_Code = CHK_ERR_ELSE
										Err_Cd = gc_strMsgURKET52_E_040 '��������̎�ʂ���`�ł͂���܂���B
										GoTo F_Chk_BD_KANKOZ_End
									End If
									'�������<>�R�F��`�̏ꍇ
								Else
									'��`�̊�������̏ꍇ�G���[
									If Trim(Mst_Inf.MEINMC) = pc_strKNJKOZ_TEG Then
										Retn_Code = CHK_ERR_ELSE
										Err_Cd = gc_strMsgURKET52_E_041 '��`�̊���������w�肳��Ă��܂��B
										GoTo F_Chk_BD_KANKOZ_End
									End If
								End If
							End If
							'''' ADD 2009/12/28  FKS) T.Yamamoto    End
							
							'�n�j
							Retn_Code = CHK_OK
							pm_Chk_Move = True
							
							pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.KANKOZ = Input_Value
					End Select
				Else
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_011 '�Y���f�[�^�Ȃ�
				End If
			End If
		End If
		
F_Chk_BD_KANKOZ_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_KANKOZ = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_BD_KANKOZ_Inf
	'   �T�v�F  ���ׁF��������ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_KANKOZ_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
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
	'   ���́F  Function F_Chk_BD_NYUKN
	'   �T�v�F  ���ׁF�����z(�~)������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_NYUKN(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_NYUKN = Retn_Code
			Exit Function
		End If
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'���̏�����
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.NYUKN = 0
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '���͔͈͊O
			Else
				'�n�j
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.NYUKN = CDec(Input_Value)
			End If
		End If
		
F_Chk_BD_NYUKN_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_NYUKN = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_BD_NYUKN_Inf
	'   �T�v�F  ���ׁF�����z(�~)�ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_NYUKN_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'�r���������������������������������������������������������r
				Call F_Util_NYUKN_Sum(pm_All)
				'�d���������������������������������������������������������d
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'�N���A
			'�r���������������������������������������������������������r
			Call F_Util_NYUKN_Sum(pm_All)
			'�d���������������������������������������������������������d
		End If
		
		'�O��`�F�b�N���e�ɑޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_BD_FNYUKN
	'   �T�v�F  ���ׁF�����z(�O��)������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_FNYUKN(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_FNYUKN = Retn_Code
			Exit Function
		End If
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'���̏�����
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.FNYUKN = 0
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '���͔͈͊O
			Else
				'�n�j
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.FNYUKN = CDbl(Input_Value)
			End If
		End If
		
F_Chk_BD_FNYUKN_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_FNYUKN = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_BD_FNYUKN_Inf
	'   �T�v�F  ���ׁF�����z(�O��)�ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_FNYUKN_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'�r���������������������������������������������������������r
				Call F_Util_FNYUKN_Sum(pm_All)
				'�d���������������������������������������������������������d
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'�N���A
			'�r���������������������������������������������������������r
			Call F_Util_FNYUKN_Sum(pm_All)
			'�d���������������������������������������������������������d
		End If
		
		'�O��`�F�b�N���e�ɑޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_BD_BNKCD
	'   �T�v�F  ���ׁF��s�R�[�h������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_BNKCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Wk_Row As Short
		Dim Bd_Index As Short
		Dim strBNKCD As String
		Dim Mst_Inf As TYPE_DB_BNKMTA
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_BNKCD = Retn_Code
			Exit Function
		End If
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'��ʂ̍s
		Wk_Row = pm_Chk_Dsp_Sub_Inf.Detail.Body_Index
		'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'���̏�����
		With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
			.BNKCD = ""
			.BNKNM = ""
			.STNNM = ""
		End With
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '���͔͈͊O
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strBNKCD = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.BD_BNKCD(Wk_Row).Tag)))
				
				'�}�X�^�`�F�b�N
				If DSPBANK_SEARCH_ALL(strBNKCD, Mst_Inf) = 0 Then
					'�_���폜�`�F�b�N
					Select Case True
						Case Mst_Inf.DATKB = gc_strDATKB_DEL
							Retn_Code = CHK_ERR_ELSE
							Err_Cd = gc_strMsgURKET52_E_009 '�폜�ς݃f�[�^
						Case Else
							'�n�j
							Retn_Code = CHK_OK
							pm_Chk_Move = True
							
							With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
								.BNKCD = Mst_Inf.BNKCD
								.BNKNM = Mst_Inf.BNKNM
								.STNNM = Mst_Inf.STNNM
							End With
					End Select
				Else
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_011 '�Y���f�[�^�Ȃ�
				End If
			End If
		End If
		
F_Chk_BD_BNKCD_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_BNKCD = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_BD_BNKCD_Inf
	'   �T�v�F  ���ׁF��s�R�[�h�ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_BNKCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
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
				
				'�y��s���́z
				Wk_Index = CShort(FR_SSSMAIN.BD_BNKNM(0).Tag)
				
				'��ʂɕҏW
				Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKNM, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
				
				'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
				Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
				
				'�y�x�X���́z
				Wk_Index = CShort(FR_SSSMAIN.BD_STNNM(0).Tag)
				
				'��ʂɕҏW
				Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.STNNM, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
				
				'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
				Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.STNNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
				
				'�d���������������������������������������������������������d
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'�N���A
			'�r���������������������������������������������������������r
			
			'�y��s���́z
			Wk_Index = CShort(FR_SSSMAIN.BD_BNKNM(0).Tag)
			
			'��ʃN���A
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'�y�x�X���́z
			Wk_Index = CShort(FR_SSSMAIN.BD_STNNM(0).Tag)
			
			'��ʃN���A
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'�d���������������������������������������������������������d
		End If
		
		'�O��`�F�b�N���e�ɑޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_BD_BNKNM
	'   �T�v�F  ���ׁF��s���̂�����
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_BNKNM(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_BNKNM = Retn_Code
			Exit Function
		End If
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'���̏�����
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKNM = ""
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '���͔͈͊O
			Else
				'�n�j
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKNM = Input_Value
			End If
		End If
		
F_Chk_BD_BNKNM_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_BNKNM = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_BD_BNKNM_Inf
	'   �T�v�F  ���ׁF��s���̂ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_BNKNM_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
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
	'   ���́F  Function F_Chk_BD_JDNNO
	'   �T�v�F  ���ׁF�󒍔ԍ�������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_JDNNO(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		Dim strJdnNo As String
		Dim strJDNLINNO As String
		'''' ADD 2009/11/10  FKS) T.Yamamoto    Start    �A���[��757
		Dim intRet As Short
		'''' ADD 2009/11/10  FKS) T.Yamamoto    End
		' === 20130711 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
		Dim rResult As Short ' �����`�F�b�N�֐��߂�l
		' === 20130711 === INSERT E
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_JDNNO = Retn_Code
			Exit Function
		End If
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'���̏�����
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.JDNNO = ""
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.JDNLINNO = ""
		
		'2009/06/05 ADD START FKS)NAKATA
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.OKRJONO = ""
		'2009/06/05 ADD E.N.D FKS)NAKATA
		
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '���͔͈͊O
			Else
				'���͂��ꂽ�󒍔ԍ����󒍔ԍ��Ǝ󒍍s�ԍ��ɕ���
				strJdnNo = Left(Input_Value, 6) '���͂̂U�����擾
				strJDNLINNO = Mid(Input_Value, 7, 2) '���͂̂U�{�P���ڂ���Q�����擾
				strJDNLINNO = "0" & strJDNLINNO '�R���ɂ��낦��i�R���[�����߃f�[�^�̂��߁j
				
				'''' UPD 2009/11/10  FKS) T.Yamamoto    Start    �A���[��757
				'            If F_Util_CheckJDNNO(strJdnNo, strJDNLINNO) <> 0 Then
				'                Retn_Code = CHK_ERR_ELSE
				'                Err_Cd = gc_strMsgURKET52_E_011          '�Y���f�[�^�Ȃ�
				'                GoTo F_Chk_BD_JDNNO_End
				'            End If
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				intRet = F_Util_CheckJDNNO(strJdnNo, strJDNLINNO, CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_NYUDT.Tag))))
				If intRet <> 0 Then
					Retn_Code = CHK_ERR_ELSE
					Select Case intRet
						Case 1
							Err_Cd = gc_strMsgURKET52_E_011 '�Y���f�[�^�Ȃ�
						Case 2
							Err_Cd = gc_strMsgURKET52_E_039 '�󒍓`�[���t�̔N�������.�������̔N��
					End Select
					GoTo F_Chk_BD_JDNNO_End
				End If
                '''' UPD 2009/11/10  FKS) T.Yamamoto    End

                ' === 20130711 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
                '�r���`�F�b�N
                '2019/05/23 CHG START
                'rResult = CF_Chk_EXCTBZ(strJdnNo)
                '2019/05/23 CHG END
                Select Case rResult
					'����
					Case 0
						
						'�r��������
					Case 1
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = "2_EXCADD" '���̃v���O�����ōX�V���̂��߁A�o�^�ł��܂���B
						GoTo F_Chk_BD_JDNNO_End
						
						'�ُ�I��
					Case 9
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgURKET52_E_004 '�X�V�ُ�
						GoTo F_Chk_BD_JDNNO_End
				End Select
				' === 20130711 === INSERT E -
				
				'�n�j
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.JDNNO = strJdnNo
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.JDNLINNO = strJDNLINNO
				
				'2009/06/05 ADD START FKS)NAKATA
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.OKRJONO = Trim(strJdnNo) & Trim(strJDNLINNO)
				'2009/06/05 ADD E.N.D FKS)NAKATA
				
				
			End If
		End If

F_Chk_BD_JDNNO_End:
        ' === 20130716 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
        '2019/05/23 CHG START
        'Call CF_EXCTBZ_Unlock(pm_All)
        '2019/05/23 CHG END
        ' === 20130716 === INSERT E

        '�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_JDNNO = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_BD_JDNNO_Inf
	'   �T�v�F  ���ׁF�󒍔ԍ��ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_JDNNO_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
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
	'   ���́F  Function F_Chk_BD_STNNM
	'   �T�v�F  ���ׁF�x�X���̂�����
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_STNNM(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_STNNM = Retn_Code
			Exit Function
		End If
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'���̏�����
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.STNNM = ""
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '���͔͈͊O
			Else
				'�n�j
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.STNNM = Input_Value
			End If
		End If
		
F_Chk_BD_STNNM_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_STNNM = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_BD_STNNM_Inf
	'   �T�v�F  ���ׁF�x�X���̂ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_STNNM_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
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
	'   ���́F  Function F_Chk_BD_TEGDT
	'   �T�v�F  ���ׁF���ϓ�������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_TEGDT(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_TEGDT = Retn_Code
			Exit Function
		End If
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'���̏�����
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT = ""
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_008 '���͔͈͊O
			Else
				'''' UPD 2011/01/14  FKS) T.Yamamoto    Start    �A���[��FC11011401
				'�����{�����̏����P�p
				'            '�O�񌎎��X�V���s�����ߋ��̓G���[
				'            If Trim(Input_Value) <= Trim(pv_strMONUPDDT) Then
				'�O��o�������s�����ߋ��̓G���[
				If Trim(Input_Value) <= Trim(pv_strSMAUPDDT) Then
					'''' UPD 2011/01/14  FKS) T.Yamamoto    End
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_016
					GoTo F_Chk_BD_TEGDT_End
				End If
				'2009/09/03 ADD START RISE)MIYAJIMA
				'���.������ > ���.���ϓ��̏ꍇ�̓G���[��\������
				If Trim(URKET52_HEAD_Inf.NYUDT) > Trim(Input_Value) Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_008
					GoTo F_Chk_BD_TEGDT_End
				End If
				'�^�p���e�[�u��.�^�p���t�iUNYMTA�j> ���.���ϓ��̏ꍇ
				If Trim(GV_UNYDate) > Trim(Input_Value) Then
					'��ʂ͌����ȊO�̓G���[�\������
					'2009/09/18 ADD START RISE)MIYAJIMA
					'                If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID = pc_strDKBID_URK_TEG Then
					If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID <> pc_strDKBID_URK_GENKN Then
						'2009/09/18 ADD E.N.D RISE)MIYAJIMA
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgURKET52_E_035
						GoTo F_Chk_BD_TEGDT_End
					End If
				End If
				'2009/09/03 ADD E.N.D RISE)MIYAJIMA
				
				'�n�j
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT = Input_Value
			End If
		End If
		
F_Chk_BD_TEGDT_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_TEGDT = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_BD_TEGDT_Inf
	'   �T�v�F  ���ׁF���ϓ��ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_TEGDT_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
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
	'   ���́F  Function F_Chk_BD_TEGNO
	'   �T�v�F  ���ׁF��`�ԍ�������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_TEGNO(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_TEGNO = Retn_Code
			Exit Function
		End If
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'���̏�����
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGNO = ""
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '���͔͈͊O
			Else
				'�n�j
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGNO = Input_Value
			End If
		End If
		
F_Chk_BD_TEGNO_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_TEGNO = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_BD_TEGNO_Inf
	'   �T�v�F  ���ׁF��`�ԍ��ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_TEGNO_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
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
	'   ���́F  Function F_Chk_BD_LINCMA
	'   �T�v�F  ���ׁF���l�P������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_LINCMA(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_LINCMA = Retn_Code
			Exit Function
		End If
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'���̏�����
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.LINCMA = ""
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '���͔͈͊O
			Else
				'�n�j
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.LINCMA = Input_Value
			End If
		End If
		
F_Chk_BD_LINCMA_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_LINCMA = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_BD_LINCMA_Inf
	'   �T�v�F  ���ׁF���l�P�ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_LINCMA_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
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
	'   ���́F  Function F_Chk_BD_LINCMB
	'   �T�v�F  ���ׁF���l�Q������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_LINCMB(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_LINCMB = Retn_Code
			Exit Function
		End If
		
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'���̏�����
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.LINCMB = ""
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '���͔͈͊O
			Else
				'�n�j
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.LINCMB = Input_Value
			End If
		End If
		
F_Chk_BD_LINCMB_End: 
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_LINCMB = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_BD_LINCMB_Inf
	'   �T�v�F  ���ׁF���l�Q�ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_LINCMB_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���ړ��e���ύX���ꂽ�ꍇ
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
			Case FR_SSSMAIN.HD_DATNO.Name
				'���������Ώۂɂ���ʕ\��
				Call F_Dsp_HD_DATNO_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.HD_NYUKB.Name
				'�����敪�ɂ���ʕ\��
				Call F_Dsp_HD_NYUKB_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.HD_NYUDT.Name
				'�������ɂ���ʕ\��
				Call F_Dsp_HD_NYUDT_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.HD_TOKCD.Name
				'������R�[�h�ɂ���ʕ\��
				Call F_Dsp_HD_TOKCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.HD_TOKRN.Name
				'�����於�̂ɂ���ʕ\��
				Call F_Dsp_HD_TOKRN_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.HD_TUKKB.Name
				'�ʉ݂ɂ���ʕ\��
				Call F_Dsp_HD_TUKKB_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.HD_KNJKOZ.Name
				'��������ɂ���ʕ\��
				Call F_Dsp_HD_KNJKOZ_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_DKBID(1).Name
				'������ʃR�[�h�ɂ���ʕ\��
				Call F_Dsp_BD_DKBID_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_DKBNM(1).Name
				'������ʖ��̂ɂ���ʕ\��
				Call F_Dsp_BD_DKBNM_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_KANKOZ(1).Name
				'��������ɂ���ʕ\��
				Call F_Dsp_BD_KANKOZ_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_NYUKN(1).Name
				'�����z(�~)�ɂ���ʕ\��
				Call F_Dsp_BD_NYUKN_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_FNYUKN(1).Name
				'�����z(�O��)�ɂ���ʕ\��
				Call F_Dsp_BD_FNYUKN_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_BNKCD(1).Name
				'��s�R�[�h�ɂ���ʕ\��
				Call F_Dsp_BD_BNKCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_BNKNM(1).Name
				'��s���̂ɂ���ʕ\��
				Call F_Dsp_BD_BNKNM_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_JDNNO(1).Name
				'�󒍔ԍ��ɂ���ʕ\��
				Call F_Dsp_BD_JDNNO_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_STNNM(1).Name
				'�x�X���̂ɂ���ʕ\��
				Call F_Dsp_BD_STNNM_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_TEGDT(1).Name
				'���ϓ��ɂ���ʕ\��
				Call F_Dsp_BD_TEGDT_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_TEGNO(1).Name
				'��`�ԍ��ɂ���ʕ\��
				Call F_Dsp_BD_TEGNO_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_LINCMA(1).Name
				'���l�P�ɂ���ʕ\��
				Call F_Dsp_BD_LINCMA_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_LINCMB(1).Name
				'���l�Q�ɂ���ʕ\��
				Call F_Dsp_BD_LINCMB_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
				'�d���������������������������������������������������������d
		End Select
		
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
			Case FR_SSSMAIN.HD_DATNO.Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���o�F���������Ώۂ�����
				Rtn_Chk = F_Chk_HD_DATNO(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.HD_NYUKB.Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���o�F�����敪������
				Rtn_Chk = F_Chk_HD_NYUKB(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.HD_NYUDT.Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���o�F������������
				Rtn_Chk = F_Chk_HD_NYUDT(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.HD_TOKCD.Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���o�F������R�[�h������
				Rtn_Chk = F_Chk_HD_TOKCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.HD_TOKRN.Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���o�F�����於�̂�����
				Rtn_Chk = F_Chk_HD_TOKRN(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.HD_TUKKB.Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���o�F�ʉ݂�����
				Rtn_Chk = F_Chk_HD_TUKKB(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.HD_KNJKOZ.Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���o�F�������������
				Rtn_Chk = F_Chk_HD_KNJKOZ(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_DKBID(1).Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���ׁF������ʃR�[�h������
				Rtn_Chk = F_Chk_BD_DKBID(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_DKBNM(1).Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���ׁF������ʖ��̂�����
				Rtn_Chk = F_Chk_BD_DKBNM(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_KANKOZ(1).Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���ׁF�������������
				Rtn_Chk = F_Chk_BD_KANKOZ(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_NYUKN(1).Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���ׁF�����z(�~)������
				Rtn_Chk = F_Chk_BD_NYUKN(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_FNYUKN(1).Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���ׁF�����z(�O��)������
				Rtn_Chk = F_Chk_BD_FNYUKN(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_BNKCD(1).Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���ׁF��s�R�[�h������
				Rtn_Chk = F_Chk_BD_BNKCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_BNKNM(1).Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���ׁF��s���̂�����
				Rtn_Chk = F_Chk_BD_BNKNM(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_JDNNO(1).Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���ׁF�󒍔ԍ�������
				Rtn_Chk = F_Chk_BD_JDNNO(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_STNNM(1).Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���ׁF�x�X���̂�����
				Rtn_Chk = F_Chk_BD_STNNM(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_TEGDT(1).Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���ׁF���ϓ�������
				Rtn_Chk = F_Chk_BD_TEGDT(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_TEGNO(1).Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���ׁF��`�ԍ�������
				Rtn_Chk = F_Chk_BD_TEGNO(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_LINCMA(1).Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���ׁF���l�P������
				Rtn_Chk = F_Chk_BD_LINCMA(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_LINCMB(1).Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���ׁF���l�Q������
				Rtn_Chk = F_Chk_BD_LINCMB(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
		End Select
		
		'�d���������������������������������������������������������d
		
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		Select Case True
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Trim(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) <> Trim(pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value) Then
					'��ʕҏW����Ƃ���
					gv_bolURKET52_INIT = True
				End If
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.CheckBox
				If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> System.Windows.Forms.CheckState.Unchecked Then
					'��ʕҏW����Ƃ���
					gv_bolURKET52_INIT = True
				End If
				
			Case Else
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
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_014, pm_All)
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
			'�P�s�ڂ̃{�f�B���������ŏI�s�Ƃ��ĊJ������
			'pm_All.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW
			'�`�F�b�N�n�j
			pm_All.Dsp_Base.Head_Ok_Flg = True
		End If
		
		F_Ctl_Head_Chk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Head_RelChk
	'   �T�v�F  ͯ�ޕ��̊֘A����
	'   �����F�@pm_ErrIdx : �G���[�������̃t�H�[�J�X�ړ��Ώہi�[��:�����敪�ֈړ��j
	'   �ߒl�F�@CHK_OK:�`�F�b�NOK�@CHK_ERR_ELSE:���̑��G���[
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Head_RelChk(ByRef pm_All As Cls_All, ByRef pm_ErrIdx As Short) As Short
		Dim Rtn_Chk As Short
		Dim Err_Cd As String '�G���[�R�[�h

        '2009/09/03 ADD START RISE)MIYAJIMA
        Dim strTANCLAKB As String
        '2009/09/03 ADD E.N.D RISE)MIYAJIMA

        '�e�����֐��Ɠ����ߒl
        Rtn_Chk = CHK_ERR_ELSE
		Err_Cd = ""
		pm_ErrIdx = CShort(FR_SSSMAIN.HD_NYUDT.Tag)
		
		'���������Ώۂ̃`�F�b�N
		If Trim(URKET52_HEAD_Inf.DATNO) = "" Then
			Err_Cd = gc_strMsgURKET52_E_024
			pm_ErrIdx = CShort(FR_SSSMAIN.HD_DATNO.Tag)
			GoTo F_Ctl_Head_RelChk_END
		End If
		
		'�������̃`�F�b�N(�ǂݍ��񂾒���͕ҏW�Ȃ��ƌ��Ȃ��Ă���̂ł����P��`�F�b�N)
		If URKET52_HEAD_Inf.NYUDT > GV_UNYDate Then
			Err_Cd = gc_strMsgURKET52_E_015
			pm_ErrIdx = CShort(FR_SSSMAIN.HD_NYUDT.Tag)
			GoTo F_Ctl_Head_RelChk_END
		Else
			'''' UPD 2011/01/14  FKS) T.Yamamoto    Start    �A���[��FC11011401
			'�����{�����̏����P�p
			'        '�O�񌎎��X�V���s�����ߋ��̓G���[
			'        If Trim(URKET52_HEAD_Inf.NYUDT) <= Trim(pv_strMONUPDDT) Then
			'�O��o�������s�����ߋ��̓G���[
			If Trim(URKET52_HEAD_Inf.NYUDT) <= Trim(pv_strSMAUPDDT) Then
				'''' UPD 2011/01/14  FKS) T.Yamamoto    End
				Err_Cd = gc_strMsgURKET52_E_016
				pm_ErrIdx = CShort(FR_SSSMAIN.HD_NYUDT.Tag)
				GoTo F_Ctl_Head_RelChk_END
			End If
		End If
		
		'2009/09/03 ADD START RISE)MIYAJIMA
		'�c�ƒS���t���O���擾
		Call F_Util_GET_TANMTA_TANCLAKB(URKET52_HEAD_Inf.TOKMTA.TANCD, strTANCLAKB)
		If CDbl(strTANCLAKB) <> 1 Then
			Err_Cd = gc_strMsgURKET52_E_034
			pm_ErrIdx = CShort(FR_SSSMAIN.HD_NYUDT.Tag)
			GoTo F_Ctl_Head_RelChk_END
		End If
		'2009/09/03 ADD E.N.D RISE)MIYAJIMA
		
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
		Dim intMoveFocus As Short
		Dim curMitKn As Decimal
		Dim curZeiKn As Decimal
		Dim intErrRow As Short
		Dim bolSKCH As Boolean '�\���i�`�F�b�N(True�F�����̂�(�w���i����))
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_OK
		
		pv_bolMEISAI_INPUT = False
		pv_bolMEISAI_TEG_INPUT = False
		pv_intMeisaiCnt = 0
		
		'�{�f�B���̍ŏI���ڂ܂Ŋe���ڂ��������s��
		For Index_Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			
			Select Case pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Status
				Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT, BODY_ROW_STATE_LST_ROW
					'���͑ҏ�ԁA���͍Ϗ�ԁA�ŏI�����s��Ώ�
					
					'�B�s�ɉ�ʖ��ׂ̑Ώۍs���R�s�[
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(0))
					
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
						
						'�G���[��Ԃ�������ԂɁi�P�����������s�킹�邽�߁j
						Call F_Reset_ErrStatus(Dsp_Sub_Inf_Wk)
						
						'�e����������S�������Ƃ��Čďo
						Rtn_Chk = F_Ctl_Item_Chk(Dsp_Sub_Inf_Wk, CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
						
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
						
						If Index_Wk_Row = 1 And Index_Wk_Col = 7 Then
							Index_Wk_Col = Index_Wk_Col
						End If
						
						'���ʃ{�f�B���Ƀ��[�N�̢��ʍ��ڏ���ҏW
						'��ʍ��ڏڍ׏���ݒ�
						'�����ɂ���ĕύX����鍀�ڂ̂�
						Call CF_Dsp_Sub_Inf_To_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col), Dsp_Sub_Inf_Wk.Detail)
						
						'�`�F�b�N�m�f
						Select Case Rtn_Chk
							'OK�̏ꍇ
							Case CHK_OK
								
								'������
							Case CHK_ERR_NOT_INPUT
								
							Case Else
								
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
						End Select
						
					Next 
					
					'�֘A����
					Rtn_Chk = F_Ctl_Body_RelChk(Index_Wk_Row, pm_All, intMoveFocus, intErrRow)
					'�`�F�b�N�m�f
					If Rtn_Chk <> CHK_OK Then
						
						'�G���[�̏ꍇ�A�Ώۍs��\����̫����ړ�����
						'�G���[�p�ϐ��i�[
						'�s���
						Err_Row = intErrRow
						'�Ώۺ��۰ُ��
						Err_Dsp_Sub_Inf_Wk.Ctl = pm_All.Dsp_Sub_Inf(intMoveFocus).Ctl
						
						'��ʍ��ڏڍ׏���ݒ�
						'UPGRADE_WARNING: �I�u�W�F�N�g Err_Dsp_Sub_Inf_Wk.Detail �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Err_Dsp_Sub_Inf_Wk.Detail = pm_All.Dsp_Sub_Inf(intMoveFocus).Detail
						
						If pm_All.Dsp_Base.Body_Fst_Idx <= intMoveFocus And pm_All.Dsp_Base.Foot_Fst_Idx > intMoveFocus Then
							GoTo ERR_EXIT
						Else
							'������ړ�
							Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(intMoveFocus), pm_All)
							
							F_Ctl_Body_Chk = CHK_ERR_ELSE
							GoTo END_EXIT
						End If
					End If
					
					'��ʖ��ׂ̑Ώۍs�ɉB�s���R�s�[(���ɖ߂�)
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row))
					
			End Select
		Next 
		
		'���׍s�ɓ��͂��Ȃ��ꍇ�A�G���[
		If pv_bolMEISAI_INPUT = False Then
			
			'�G���[���b�Z�[�W�\��
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_012, pm_All)
			
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_DKBID(1).Tag)), pm_All)
			
			F_Ctl_Body_Chk = CHK_ERR_ELSE
			GoTo END_EXIT
			
		End If
		
		'// V1.20�� DEL
		'    '���׍s�Ɏ�`�̓��͂��Ȃ��ꍇ�A�G���[
		'    If pv_bolMEISAI_TEG_INPUT = False Then
		'        '���Ӑ�}�X�^�D��`�x�����z���O �̂�
		'        If URKET52_HEAD_Inf.TOKMTA.TEGSHKN > 0 Then
		'            '�G���[���b�Z�[�W�\��
		'            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_018, pm_All)
		'
		'            '������ړ��Ȃ�
		'            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(FR_SSSMAIN.BD_DKBID(1).Tag), pm_All)
		'
		'            F_Ctl_Body_Chk = CHK_ERR_ELSE
		'            GoTo END_EXIT
		'        End If
		'    End If
		'// V1.20�� DEL
		
		F_Ctl_Body_Chk = Rtn_Chk
		
END_EXIT: 
		
		Exit Function
		
ERR_EXIT: 
		'�G���[���A̫����ړ�
		'�Ώۍs����ʂɕ\��
		Call CF_Body_Dsp_Trg_Row(pm_All, Err_Row)
		'�R���g���[������
		Call F_Set_Body_Enable(pm_All)
		'�Ώۍs�����ʖ��ׂ̍s���擾
		Bd_Idx = CF_Idx_To_Bd_Idx(Err_Row, pm_All)
		'��ʖ��ׂ̍s�Ɠ���̖��ׂ��C���f�b�N�X���擾
		Err_Index = CF_Get_Idex_Same_Bd_Ctl(Err_Dsp_Sub_Inf_Wk, Bd_Idx, pm_All)
		
		If Err_Index > 0 Then
			'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
			Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Err_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			'�I����Ԃ̐ݒ�i�����I���j
			Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Err_Index - 1), SEL_INI_MODE_2)
			'���ڐF�ݒ�
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Err_Index - 1), ITEM_NORMAL_STATUS, pm_All)
			
		Else
			'���͉\�ȍŏ��̃C���f�b�N�X���擾
			Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Err_Row, pm_All)
			If Focus_Ctl_Ok_Fst_Idx > 0 Then
				'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
				Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			End If
		End If
		
		F_Ctl_Body_Chk = Rtn_Chk
		GoTo END_EXIT
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Body_RelChk
	'   �T�v�F  ���ި���̊֘A����
	'   �����F�@pm_intRow : �`�F�b�N�Ώۖ��׍s
	'         �@pm_all    : ��ʏ��
	'   �ߒl�F�@CHK_OK:�`�F�b�NOK�@CHK_ERR_ELSE:���̑��G���[
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Body_RelChk(ByRef pm_intRow As Short, ByRef pm_All As Cls_All, ByRef pm_ErrIdx As Short, ByRef pm_ErrRow As Short) As Short
		Dim Rtn_Chk As Short
		Dim Err_Cd As String '�G���[�R�[�h
		
		Dim intDKBID As Short
		Dim intDKBNM As Short
		Dim intKANKOZ As Short
		Dim intNYUKN As Short
		Dim intFNYUKN As Short
		Dim intBNKCD As Short
		Dim intBNKNM As Short
		Dim intJDNNO As Short
		Dim intSTNNM As Short
		Dim intTEGDT As Short
		Dim intTEGNO As Short
		Dim intLINCMA As Short
		Dim intLINCMB As Short
		Dim bolCheck As Boolean
		Dim strDKBID As String
		
		'2009/09/03 ADD START RISE)MIYAJIMA
		Dim Mst_Inf As TYPE_DB_MEIMTA
		'2009/09/03 ADD E.N.D RISE)MIYAJIMA
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_ERR_ELSE
		Err_Cd = ""
		pm_ErrIdx = CShort(FR_SSSMAIN.BD_DKBID(1).Tag)
		pm_ErrRow = pm_intRow
		
		'�P�s�`�F�b�N
		intDKBID = CShort(FR_SSSMAIN.BD_DKBID(0).Tag)
		intDKBNM = CShort(FR_SSSMAIN.BD_DKBNM(0).Tag)
		intKANKOZ = CShort(FR_SSSMAIN.BD_KANKOZ(0).Tag)
		intNYUKN = CShort(FR_SSSMAIN.BD_NYUKN(0).Tag)
		intFNYUKN = CShort(FR_SSSMAIN.BD_FNYUKN(0).Tag)
		intBNKCD = CShort(FR_SSSMAIN.BD_BNKCD(0).Tag)
		intBNKNM = CShort(FR_SSSMAIN.BD_BNKNM(0).Tag)
		intJDNNO = CShort(FR_SSSMAIN.BD_JDNNO(0).Tag)
		intSTNNM = CShort(FR_SSSMAIN.BD_STNNM(0).Tag)
		intTEGDT = CShort(FR_SSSMAIN.BD_TEGDT(0).Tag)
		intTEGNO = CShort(FR_SSSMAIN.BD_TEGNO(0).Tag)
		intLINCMA = CShort(FR_SSSMAIN.BD_LINCMA(0).Tag)
		intLINCMB = CShort(FR_SSSMAIN.BD_LINCMB(0).Tag)
		bolCheck = False
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strDKBID = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intDKBID)))
		
		'�P�s�ɕK�v�ȏ�񂪓��͂���Ă���ꍇ�AOK
		If strDKBID <> "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intFNYUKN)))) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intNYUKN)))) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Select Case True
				'��������́A�K�{����
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intKANKOZ))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_KANKOZ(1).Tag)
					
					'2009/09/03 ADD START RISE)MIYAJIMA
				Case F_Util_KNJKOZ_Search(Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intKANKOZ))), Mst_Inf) = 1
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_KANKOZ(1).Tag)
					Err_Cd = gc_strMsgURKET52_E_011
					'2009/09/03 ADD E.N.D RISE)MIYAJIMA
					
					'�����z(�~)�́A�K�{����
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intNYUKN))) = "" Or SSSVal(Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intNYUKN)))) = 0
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_NYUKN(1).Tag)
					
					'�����z(�O��)�́A�K�{���́i�������A�C�O�̂݁j
				Case URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN And (Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intFNYUKN))) = "" Or SSSVal(Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intFNYUKN)))) = 0)
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_FNYUKN(1).Tag)
					
					'2009/06/08 ADD START FKS)NAKATA
					'�󒍔ԍ��́A�K�{���́i�������A�O��̂݁j
				Case URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intJDNNO))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_JDNNO(1).Tag)
					'2009/06/08 ADD E.N.D FKS)NAKATA
					
					
					'// V1.20�� DEL
					'            '������ʁ��U���̏ꍇ
					'            '��s�R�[�h�́A�K�{����
					'            Case strDKBID = pc_strDKBID_URK_HURI _
					''             And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intBNKCD))) = ""
					'                pm_ErrIdx = CInt(FR_SSSMAIN.BD_BNKCD(1).Tag)
					'                Err_Cd = gc_strMsgURKET52_E_019
					'// V1.20�� DEL
					
					'������ʁ���`�̏ꍇ
					'��s�R�[�h�́A�K�{����
				Case strDKBID = pc_strDKBID_URK_TEG And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intBNKCD))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_BNKCD(1).Tag)
					Err_Cd = gc_strMsgURKET52_E_020
					
					'������ʁ���`�̏ꍇ
					'���ϓ��́A�K�{����
				Case strDKBID = pc_strDKBID_URK_TEG And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGDT))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_TEGDT(1).Tag)
					Err_Cd = gc_strMsgURKET52_E_021
					
					'������ʁ���`�̏ꍇ
					'''' UPD 2011/01/14  FKS) T.Yamamoto    Start    �A���[��FC11011401
					'�����{�����̏����P�p
					'            '���ϓ��́A�O�񌎎��X�V���s�����ߋ��̓G���[
					'            '(�ǂݍ��񂾒���͕ҏW�Ȃ��ƌ��Ȃ��Ă���̂ł����P��`�F�b�N)
					'            Case strDKBID = pc_strDKBID_URK_TEG _
					''             And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGDT))) <> "" _
					''             And Replace(Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGDT))), "/", "") <= Trim(pv_strMONUPDDT)
					'���ϓ��́A�O��o�������s�����ߋ��̓G���[
					'(�ǂݍ��񂾒���͕ҏW�Ȃ��ƌ��Ȃ��Ă���̂ł����P��`�F�b�N)
				Case strDKBID = pc_strDKBID_URK_TEG And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGDT))) <> "" And Replace(Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGDT))), "/", "") <= Trim(pv_strSMAUPDDT)
					'''' UPD 2011/01/14  FKS) T.Yamamoto    End
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_TEGDT(1).Tag)
					Err_Cd = gc_strMsgURKET52_E_016
					
					'������ʁ���`�̏ꍇ
					'��`�ԍ��́A�K�{����
				Case strDKBID = pc_strDKBID_URK_TEG And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGNO))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_TEGNO(1).Tag)
					Err_Cd = gc_strMsgURKET52_E_022
					
					
					'2009/06/08 ADD START FKS)NAKATA
					'���ϓ��́A�K�{���́i�������A�O��̂݁j
				Case URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE And strDKBID = pc_strDKBID_URK_HURIK And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGDT))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_TEGDT(1).Tag)
					'2009/06/08 ADD E.N.D FKS)NAKATA
					
					'2009/09/03 ADD START RISE)MIYAJIMA
				Case strDKBID = pc_strDKBID_URK_TEG And Trim(URKET52_HEAD_Inf.NYUDT) > VB6.Format(Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGDT))), "YYYYMMDD")
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_TEGDT(1).Tag)
					Err_Cd = gc_strMsgURKET52_E_008
					
					'�^�p���e�[�u��.�^�p���t�iUNYMTA�j> ���.���ϓ��̏ꍇ
				Case strDKBID = pc_strDKBID_URK_TEG And Trim(GV_UNYDate) > VB6.Format(Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGDT))), "YYYYMMDD")
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_TEGDT(1).Tag)
					Err_Cd = gc_strMsgURKET52_E_035
					'2009/09/03 ADD E.N.D RISE)MIYAJIMA
					
					'// V1.20�� DEL
					'            '������ʁ���`�̏ꍇ
					'            '���Ӑ�}�X�^�D��`�x�����z���O
					'            ' ���� ���Ӑ�}�X�^�D��`�x�����z����ʁD�����z(�~)
					'            Case strDKBID = pc_strDKBID_URK_TEG _
					''             And URKET52_HEAD_Inf.TOKMTA.TEGSHKN > 0 _
					''             And URKET52_HEAD_Inf.TOKMTA.TEGSHKN > SSSVal(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intNYUKN)))
					'                pm_ErrIdx = CInt(FR_SSSMAIN.BD_NYUKN(1).Tag)
					'                Err_Cd = gc_strMsgURKET52_E_023
					'// V1.20�� DEL
					
					'// V1.20�� DEL
					'            '������ʁ���`�̏ꍇ
					'            '���Ӑ�}�X�^�D��`�x�����z���O
					'            ' ���� ���Ӑ�}�X�^�D��`�x�����z����ʁD�����z(�O��)
					'            Case strDKBID = pc_strDKBID_URK_TEG _
					''             And URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN _
					''             And URKET52_HEAD_Inf.TOKMTA.TEGSHKN > 0 _
					''             And URKET52_HEAD_Inf.TOKMTA.TEGSHKN > SSSVal(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intFNYUKN)))
					'                pm_ErrIdx = CInt(FR_SSSMAIN.BD_FNYUKN(1).Tag)
					'                Err_Cd = gc_strMsgURKET52_E_023
					'// V1.20�� DEL
					
					'�K�v�ȏ�񂪓��͂���Ă���ꍇOK
				Case Else
					bolCheck = True
					pv_bolMEISAI_INPUT = True
					pv_intMeisaiCnt = pv_intMeisaiCnt + 1
					
			End Select
			
			'// V1.20�� DEL
			'        '��`�̓��͂��P���ׂ��Ȃ��ꍇ�̓G���[
			'        If strDKBID = pc_strDKBID_URK_TEG Then
			'            pv_bolMEISAI_TEG_INPUT = True
			'        End If
			'// V1.20�� DEL
		End If
		
		'�P�s�S�������͂̏ꍇOK
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If bolCheck = False And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intDKBID))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intDKBNM))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intKANKOZ))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intNYUKN))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intFNYUKN))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intBNKCD))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intBNKNM))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intJDNNO))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSTNNM))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGDT))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGNO))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intLINCMA))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intLINCMB))) = "" Then
			bolCheck = True
		End If
		
		If bolCheck = False Then
			If Err_Cd = "" Then
				'�ʂŃ��b�Z�[�W����`����Ă��Ȃ��ꍇ�́A�ėp�I�ȃ��b�Z�[�W���o��
				Err_Cd = gc_strMsgURKET52_E_013
			End If
			GoTo F_Ctl_Body_RelChk_END
		End If
		
		Rtn_Chk = CHK_OK
		
F_Ctl_Body_RelChk_END: 
		
		If Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Ctl_Body_RelChk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Tail_Chk
	'   �T�v�F  òٕ�������ٰ�ݐ���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Tail_Chk(ByRef pm_All As Cls_All) As Short
		Dim Rtn_Chk As Short
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_OK
		
		'�`�F�b�N�Ȃ�
		
		F_Ctl_Tail_Chk = Rtn_Chk
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_ALL_RelChk
	'   �T�v�F  ����ٰ�ݐ���i�S�֘A�`�F�b�N�j
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_ALL_RelChk(ByRef pm_All As Cls_All) As Short
		Dim Rtn_Chk As Short
		Dim Err_Cd As String
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_OK
		Err_Cd = ""
		
		'2009/09/24 DEL START RISE)MIYAJIMA
		'    '�ύX���z����`�F�b�N
		'    If F_Util_CheckSumOver(pm_All) <> 0 Then
		'        Rtn_Chk = CHK_ERR_ELSE
		'
		'        '���b�Z�[�W�o��
		'        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_029, pm_All)
		'
		'        '������ړ��Ȃ�
		'        Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(FR_SSSMAIN.BD_NYUKN(1).Tag), pm_All)
		'    End If
		'2009/09/24 DEL E.N.D RISE)MIYAJIMA
		
		F_Ctl_ALL_RelChk = Rtn_Chk
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_DATNO
	'   �T�v�F  �Ώۍ��ڂ̓��������Ώۃ{�^���̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_DATNO(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		Dim Next_Focus As Short
		
		'�������ޯ���擾
		Trg_Index = CShort(FR_SSSMAIN.HD_DATNO.Tag)
		Next_Focus = Trg_Index + 1
		
		'̫������R�[�h�ֈړ�
		If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
			'���݂�Active�R���g���[���̑I����ԉ���
			'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
			'̫����ړ�
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'�I����Ԃ̐ݒ�i�����I���j
			Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
			'���ڐF�ݒ�
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
			
			gv_bolURKET52_LF_Enable = False
			
			WLSNDN_RTNCODE = ""
			
			'Windows�ɏ�����Ԃ�
			System.Windows.Forms.Application.DoEvents()
			
			'���������Ώۉ�ʂ��Ăяo��
			WLSNDN.ShowDialog()
			WLSNDN.Close()
			
			gv_bolURKET52_LF_Enable = True
			
			If WLSNDN_RTNCODE <> "" Then
				'�����n�j
				'��ʂɕҏW
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(WLSNDN_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
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
				
				If Chk_Move_Flg = True Then
					'������ړ�����
					Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					'̫����ړ�
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
					'���ڐF�ݒ�
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
				End If
			End If
		Else
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
			'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_NYUDT
	'   �T�v�F  �Ώۍ��ڂ̌��o�F�������{�^���̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_NYUDT(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		Dim Next_Focus As Short
		Dim Trg_Index As Short
		
		Trg_Index = CShort(FR_SSSMAIN.HD_NYUDT.Tag)
		Next_Focus = Trg_Index + 1
		
		'̫������e���ڂֈړ�
		If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
			'���݂�Active�R���g���[���̑I����ԉ���
			'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
			'̫����ړ�
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'�I����Ԃ̐ݒ�i�����I���j
			Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
			'���ڐF�ݒ�
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
			
			gv_bolURKET52_LF_Enable = False
			
			WLSDATE_RTNCODE = ""
			
			'Windows�ɏ�����Ԃ�
			System.Windows.Forms.Application.DoEvents()
			
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Set_date.Value = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index)))
			'�J�����_������ʂ��Ăяo��
			WLS_DATE.ShowDialog()
			WLS_DATE.Close()
			
			gv_bolURKET52_LF_Enable = True
			
			If WLSDATE_RTNCODE <> "" Then
				'�����n�j
				'��ʂɕҏW
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(WLSDATE_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
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
				
				If Chk_Move_Flg = True Then
					'������ړ�����
					Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					'̫����ړ�
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
					'���ڐF�ݒ�
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
				End If
				
			End If
		Else
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
			'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_KNJKOZ
	'   �T�v�F  �Ώۍ��ڂ̌��o�F��������{�^���̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_KNJKOZ(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		Dim Next_Focus As Short
		
		Dim Mst_Inf_MEI() As TYPE_DB_MEIMTA
		Dim intCnt As Short
		
		'�������ޯ���擾
		Trg_Index = CShort(FR_SSSMAIN.HD_KNJKOZ.Tag)
		Next_Focus = Trg_Index
		
		'̫������󒍎���敪�ֈړ�
		Dim strItem As String
		If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
			'���݂�Active�R���g���[���̑I����ԉ���
			'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
			'̫����ړ�
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'�I����Ԃ̐ݒ�i�����I���j
			Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
			'���ڐF�ݒ�
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

            '���X�g�I����ʂ̏���ݒ�
            '2009/09/03 UPD START RISE)MIYAJIMA
            '        Call DSPMEIMTA_SEARCH_SORTUSE(pc_strKEYCD_KNJKOZ, Mst_Inf_MEI, "KEYCD, MEICDB, MEICDA")

            '2009/09/03 UPD E.N.D RISE)MIYAJIMA
            If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
                Call DSPMEIMTA_SEARCH_SORTUSE(pc_strKEYCD_KNJKOZ_MAE, Mst_Inf_MEI, "KEYCD, MEICDB, MEICDA")
            Else
                Call DSPMEIMTA_SEARCH_SORTUSE(pc_strKEYCD_KNJKOZ, Mst_Inf_MEI, "KEYCD, MEICDB, MEICDA")
            End If

            WLS_LIST.Text = "��������ꗗ"
            CType(WLS_LIST.Controls("LST"), Object).Items.Clear()

            For intCnt = 1 To UBound(Mst_Inf_MEI)
                If Mst_Inf_MEI(intCnt).DATKB <> "9" Then
                    strItem = LeftWid(Mst_Inf_MEI(intCnt).MEICDB, 1) & LeftWid(Mst_Inf_MEI(intCnt).MEICDA, 9) & " " & LeftWid(Mst_Inf_MEI(intCnt).MEINMA, 40)
                    CType(WLS_LIST.Controls("LST"), Object).Items.Add(strItem)
                End If
            Next
            Erase Mst_Inf_MEI

            'For i As Integer = 0 To dt.Rows.Count - 1
            '    Call DB_MEIMTA_SetData(dt, pot_DB_MEIMTA(intData))
            '    intData = intData + 1
            'Next

            '�����ݒ�
            SSS_WLSLIST_KETA = pm_All.Dsp_Sub_Inf(Trg_Index).Detail.MaxLengthB
			
			gv_bolURKET52_LF_Enable = False
			
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SlistCom = ""
			
			'Windows�ɏ�����Ԃ�
			System.Windows.Forms.Application.DoEvents()
			
			'���X�g�I����ʂ��Ăяo��
			WLS_LIST.ShowDialog()
			WLS_LIST.Close()
			
			gv_bolURKET52_LF_Enable = True
			
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If PP_SSSMAIN.SlistCom <> "" Then
				'�����n�j
				'��ʂɕҏW
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(PP_SSSMAIN.SlistCom, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'�`�F�b�N
				'�e���ڂ�����ٰ��
				Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CStr(NEXT_FOCUS_MODE_KEYRIGHT), Chk_Move_Flg, pm_All)
				
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
				
				If Chk_Move_Flg = True Then
					'������ړ�����
					Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					'̫����ړ�
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
					'���ڐF�ݒ�
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
				End If
			End If
		Else
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_DKBID
	'   �T�v�F  �Ώۍ��ڂ̌��o�F������ʃ{�^���̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_DKBID(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		Dim Trg_Index As Short
		Dim Focus_Flg As Boolean
		
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		Dim Next_Focus As Short
		
		Dim Mst_Inf_TBD() As TYPE_DB_SYSTBD
		Dim intCnt As Short
		
		'���ޯ���擾
		Wk_Index = CShort(FR_SSSMAIN.BD_DKBID(0).Tag)
		
		'̫����ړ��������
		Focus_Flg = False
		Trg_Index = 0
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			'���ח̈�
			'�Ώۍs�̐��i�R�[�h�ֈړ�
			Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
		Else
			'���׈ȊO�̈�
			If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD Or (pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index = 0) Then
				'�w�b�^���̏ꍇ
				'ͯ�ޕ�����
				Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				If Rtn_Chk = CHK_OK Then
					'�`�F�b�N�n�j�̏ꍇ
					'���ׂ̂P�s�ڂɈړ�
					Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), 1, pm_All)
				End If
			End If
		End If
		
		Next_Focus = Trg_Index
		
		If Trg_Index > 0 Then
			'̫������ړ�
			If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
				'���݂�Active�R���g���[���̑I����ԉ���
				'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
				Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
				'̫����ړ�
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				'�I����Ԃ̐ݒ�i�����I���j
				Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
				'���ڐF�ݒ�
				Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
				'̫����ړ�
				Focus_Flg = True
			End If
		End If
		
		Dim strItem As String
		If Focus_Flg = True Then
			'���X�g�I����ʂ̏���ݒ�
			Call SYSTBD_SEARCH_ALL(pc_strDKBSB_URK, Mst_Inf_TBD)
			WLS_LIST.Text = "�������"
			CType(WLS_LIST.Controls("LST"), Object).Items.Clear()
			For intCnt = 1 To UBound(Mst_Inf_TBD)
				strItem = Mst_Inf_TBD(intCnt).DKBID & " " & Mst_Inf_TBD(intCnt).DKBNM
				CType(WLS_LIST.Controls("LST"), Object).Items.Add(strItem)
			Next intCnt
			Erase Mst_Inf_TBD
			
			'�����ݒ�
			SSS_WLSLIST_KETA = pm_All.Dsp_Sub_Inf(Trg_Index).Detail.MaxLengthB
			
			gv_bolURKET52_LF_Enable = False
			
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SlistCom = ""
			
			'Windows�ɏ�����Ԃ�
			System.Windows.Forms.Application.DoEvents()
			
			'���X�g�I����ʂ��Ăяo��
			WLS_LIST.ShowDialog()
			WLS_LIST.Close()
			
			gv_bolURKET52_LF_Enable = True
			
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If PP_SSSMAIN.SlistCom <> "" Then
				'�����n�j
				'��ʂɕҏW
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(PP_SSSMAIN.SlistCom, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				
				'��ݼ޲���Ă��N�������ɕҏW
				Call CF_Set_Item_Not_Change(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'���ד��͌�̌㏈��
				Call F_Ctl_Item_Input_Aft(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
				
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
				
				'�Ώۍs�̎����ڂֈړ��iwk_index�͊Y���̃e�L�X�g�z��[�����w�肵�Ă����j
				Wk_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
				If Chk_Move_Flg = True Then
					'������ړ�����
					Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Wk_Index), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					'������ړ��Ȃ�
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
					'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Wk_Index), ITEM_NORMAL_STATUS, pm_All)
				End If
			End If
		Else
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
			'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_KANKOZ
	'   �T�v�F  �Ώۍ��ڂ̖��ׁF��������{�^���̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_KANKOZ(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		Dim Trg_Index As Short
		Dim Focus_Flg As Boolean
		
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		Dim Next_Focus As Short
		
		Dim Mst_Inf_MEI() As TYPE_DB_MEIMTA
		Dim intCnt As Short
		
		'���ޯ���擾
		Wk_Index = CShort(FR_SSSMAIN.BD_KANKOZ(0).Tag)
		
		'̫����ړ��������
		Focus_Flg = False
		Trg_Index = 0
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			'���ח̈�
			'�Ώۍs�̐��i�R�[�h�ֈړ�
			Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
		Else
			'���׈ȊO�̈�
			If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD Or (pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index = 0) Then
				'�w�b�^���̏ꍇ
				'ͯ�ޕ�����
				Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				If Rtn_Chk = CHK_OK Then
					'�`�F�b�N�n�j�̏ꍇ
					'���ׂ̂P�s�ڂɈړ�
					Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), 1, pm_All)
				End If
			End If
		End If
		
		Next_Focus = Trg_Index
		
		If Trg_Index > 0 Then
			'̫������ړ�
			If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
				'���݂�Active�R���g���[���̑I����ԉ���
				'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
				Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
				'̫����ړ�
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				'�I����Ԃ̐ݒ�i�����I���j
				Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
				'���ڐF�ݒ�
				Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
				'̫����ړ�
				Focus_Flg = True
			End If
		End If
		
		Dim strItem As String
		If Focus_Flg = True Then
			'���X�g�I����ʂ̏���ݒ�
			'2009/09/03 UPD START RISE)MIYAJIMA
			'        Call DSPMEIMTA_SEARCH_SORTUSE(pc_strKEYCD_KNJKOZ, Mst_Inf_MEI, "KEYCD, MEICDB, MEICDA")
			If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
				Call DSPMEIMTA_SEARCH_SORTUSE(pc_strKEYCD_KNJKOZ_MAE, Mst_Inf_MEI, "KEYCD, MEICDB, MEICDA")
			Else
				Call DSPMEIMTA_SEARCH_SORTUSE(pc_strKEYCD_KNJKOZ, Mst_Inf_MEI, "KEYCD, MEICDB, MEICDA")
			End If
			'2009/09/03 UPD E.N.D RISE)MIYAJIMA
			WLS_LIST.Text = "��������ꗗ"
			CType(WLS_LIST.Controls("LST"), Object).Items.Clear()
			For intCnt = 1 To UBound(Mst_Inf_MEI)
				If Mst_Inf_MEI(intCnt).DATKB <> "9" Then
					strItem = LeftWid(Mst_Inf_MEI(intCnt).MEICDB, 1) & LeftWid(Mst_Inf_MEI(intCnt).MEICDA, 9) & " " & LeftWid(Mst_Inf_MEI(intCnt).MEINMA, 40)
					CType(WLS_LIST.Controls("LST"), Object).Items.Add(strItem)
				End If
			Next intCnt
			Erase Mst_Inf_MEI
			
			'�����ݒ�
			SSS_WLSLIST_KETA = pm_All.Dsp_Sub_Inf(Trg_Index).Detail.MaxLengthB
			
			gv_bolURKET52_LF_Enable = False
			
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SlistCom = ""
			
			'Windows�ɏ�����Ԃ�
			System.Windows.Forms.Application.DoEvents()
			
			'���X�g�I����ʂ��Ăяo��
			WLS_LIST.ShowDialog()
			WLS_LIST.Close()
			
			gv_bolURKET52_LF_Enable = True
			
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If PP_SSSMAIN.SlistCom <> "" Then
				'�����n�j
				'��ʂɕҏW
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(PP_SSSMAIN.SlistCom, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				
				'��ݼ޲���Ă��N�������ɕҏW
				Call CF_Set_Item_Not_Change(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'���ד��͌�̌㏈��
				Call F_Ctl_Item_Input_Aft(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
				
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
				
				'�Ώۍs�̎����ڂֈړ��iwk_index�͊Y���̃e�L�X�g�z��[�����w�肵�Ă����j
				Wk_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
				If Chk_Move_Flg = True Then
					'������ړ�����
					Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Wk_Index), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					'������ړ��Ȃ�
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
					'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Wk_Index), ITEM_NORMAL_STATUS, pm_All)
				End If
			End If
		Else
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
			'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_BNKCD
	'   �T�v�F  �Ώۍ��ڂ̖��ׁF��s�R�[�h�{�^���̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_BNKCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		Dim Trg_Index As Short
		Dim Focus_Flg As Boolean
		
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		Dim Next_Focus As Short
		
		'���ޯ���擾
		Wk_Index = CShort(FR_SSSMAIN.BD_BNKCD(0).Tag)
		
		'̫����ړ��������
		Focus_Flg = False
		Trg_Index = 0
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			'���ח̈�
			'�Ώۍs�̐��i�R�[�h�ֈړ�
			Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
		Else
			'���׈ȊO�̈�
			If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD Or (pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index = 0) Then
				'�w�b�^���̏ꍇ
				'ͯ�ޕ�����
				Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				If Rtn_Chk = CHK_OK Then
					'�`�F�b�N�n�j�̏ꍇ
					'���ׂ̂P�s�ڂɈړ�
					Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), 1, pm_All)
				End If
			End If
		End If
		
		Next_Focus = Trg_Index
		
		If Trg_Index > 0 Then
            '̫������ړ�
            If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
                '���݂�Active�R���g���[���̑I����ԉ���
                'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
                '̫����ړ�
                Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                '�I����Ԃ̐ݒ�i�����I���j
                Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
                '���ڐF�ݒ�
                Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
                '̫����ړ�
                Focus_Flg = True
            End If
        End If
		
		If Focus_Flg = True Then
			gv_bolURKET52_LF_Enable = False
			
			WLSBNKMTA2_RTNCODE = ""
			
			'Windows�ɏ�����Ԃ�
			System.Windows.Forms.Application.DoEvents()
			
			'��s������ʂ��Ăяo��
			WLSBNK2.ShowDialog()
			WLSBNK2.Close()
			
			gv_bolURKET52_LF_Enable = True
			
			If WLSBNKMTA2_RTNCODE <> "" Then
				'�����n�j
				'��ʂɕҏW
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(WLSBNKMTA2_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				
				'��ݼ޲���Ă��N�������ɕҏW
				Call CF_Set_Item_Not_Change(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'���ד��͌�̌㏈��
				Call F_Ctl_Item_Input_Aft(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
				
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
				
				'�Ώۍs�̎����ڂֈړ��iwk_index�͊Y���̃e�L�X�g�z��[�����w�肵�Ă����j
				Wk_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
				If Chk_Move_Flg = True Then
					'������ړ�����
					Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Wk_Index), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					'������ړ��Ȃ�
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
					'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Wk_Index), ITEM_NORMAL_STATUS, pm_All)
				End If
			End If
		Else
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
			'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_TEGDT
	'   �T�v�F  �Ώۍ��ڂ̖��ׁF���ϓ��{�^���̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_TEGDT(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		Dim Trg_Index As Short
		Dim Focus_Flg As Boolean
		
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		Dim Next_Focus As Short
		
		'���ޯ���擾
		Wk_Index = CShort(FR_SSSMAIN.BD_TEGDT(0).Tag)
		
		'̫����ړ��������
		Focus_Flg = False
		Trg_Index = 0
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			'���ח̈�
			'�Ώۍs�̐��i�R�[�h�ֈړ�
			Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
		Else
			'���׈ȊO�̈�
			If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD Or (pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index = 0) Then
				'�w�b�^���̏ꍇ
				'ͯ�ޕ�����
				Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				If Rtn_Chk = CHK_OK Then
					'�`�F�b�N�n�j�̏ꍇ
					'���ׂ̂P�s�ڂɈړ�
					Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), 1, pm_All)
				End If
			End If
		End If
		
		Next_Focus = Trg_Index
		
		If Trg_Index > 0 Then
			'̫������ړ�
			If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
				'���݂�Active�R���g���[���̑I����ԉ���
				'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
				Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
				'̫����ړ�
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				'�I����Ԃ̐ݒ�i�����I���j
				Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
				'���ڐF�ݒ�
				Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
				'̫����ړ�
				Focus_Flg = True
			End If
		End If
		
		If Focus_Flg = True Then
			gv_bolURKET52_LF_Enable = False
			
			WLSDATE_RTNCODE = ""
			
			'Windows�ɏ�����Ԃ�
			System.Windows.Forms.Application.DoEvents()
			
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Set_date.Value = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index)))
			'�J�����_������ʂ��Ăяo��
			WLS_DATE.ShowDialog()
			WLS_DATE.Close()
			
			gv_bolURKET52_LF_Enable = True
			
			If WLSDATE_RTNCODE <> "" Then
				'�����n�j
				'��ʂɕҏW
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(WLSDATE_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				
				'��ݼ޲���Ă��N�������ɕҏW
				Call CF_Set_Item_Not_Change(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'���ד��͌�̌㏈��
				Call F_Ctl_Item_Input_Aft(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
				
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
				
				'�Ώۍs�̎����ڂֈړ��iwk_index�͊Y���̃e�L�X�g�z��[�����w�肵�Ă����j
				Wk_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
				If Chk_Move_Flg = True Then
					'������ړ�����
					Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Wk_Index), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					'������ړ��Ȃ�
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
					'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Wk_Index), ITEM_NORMAL_STATUS, pm_All)
				End If
			End If
		Else
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
			'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub F_Util_FNYUKN_Clear
	'   �T�v�F  ���ׂĂ̍s�̓����z(�O��)���N���A����
	'   �����F
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub F_Util_FNYUKN_Clear(ByRef pm_All As Cls_All)
		Dim Wk_Index As Short
		Dim intCnt As Short
		Dim Wk_Row As Short
		Dim Bd_Index As Short
		
		For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			'�y�����z(�O��)�z
			Wk_Index = CShort(FR_SSSMAIN.BD_FNYUKN(intCnt).Tag)
			
			'��ʂ̍s
			Wk_Row = intCnt
			
			'pm_All.Dsp_Body_Inf�̍s�m�n���擾
			Bd_Index = intCnt
			
			'��ʃN���A
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'���̏�����
			With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
				.FNYUKN = 0
			End With
		Next intCnt
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub F_Util_FNYUKN_SetOnOff
	'   �T�v�F  ���ׂĂ̍s�̓����z(�O��)�̗L���E������ύX����
	'   �����F
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub F_Util_FNYUKN_SetOnOff(ByVal pin_Value As Boolean, ByRef pm_All As Cls_All)
		Dim Wk_Index As Short
		Dim intCnt As Short
		
		For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			'�y�����z(�O��)�z
			Wk_Index = CShort(FR_SSSMAIN.BD_FNYUKN(intCnt).Tag)
			
			'�L���E������ύX����
			Call CF_Set_Item_Focus_Ctl(pin_Value, pm_All.Dsp_Sub_Inf(Wk_Index))
		Next intCnt
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub F_Util_JDNNO_Clear
	'   �T�v�F  ���ׂĂ̍s�̎󒍔ԍ����N���A����
	'   �����F
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub F_Util_JDNNO_Clear(ByRef pm_All As Cls_All)
		Dim Wk_Index As Short
		Dim intCnt As Short
		Dim Wk_Row As Short
		Dim Bd_Index As Short
		
		For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			'�y�󒍔ԍ��z
			Wk_Index = CShort(FR_SSSMAIN.BD_JDNNO(intCnt).Tag)
			
			'��ʂ̍s
			Wk_Row = intCnt
			
			'pm_All.Dsp_Body_Inf�̍s�m�n���擾
			Bd_Index = intCnt
			
			'��ʃN���A
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'���̏�����
			With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
				.JDNNO = ""
				.JDNLINNO = ""
			End With
		Next intCnt
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub F_Util_JDNNO_SetOnOff
	'   �T�v�F  ���ׂĂ̍s�̎󒍔ԍ��̗L���E������ύX����
	'   �����F
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub F_Util_JDNNO_SetOnOff(ByVal pin_Value As Boolean, ByRef pm_All As Cls_All)
		Dim Wk_Index As Short
		Dim intCnt As Short
		
		For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			'�y�󒍔ԍ��z
			Wk_Index = CShort(FR_SSSMAIN.BD_JDNNO(intCnt).Tag)
			
			'�L���E������ύX����
			Call CF_Set_Item_Focus_Ctl(pin_Value, pm_All.Dsp_Sub_Inf(Wk_Index))
		Next intCnt
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub F_Util_DKBID_SwitchOnOff
	'   �T�v�F  ������ʂɉ����čs�̗L���E������ύX����
	'   �����F
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub F_Util_DKBID_SwitchOnOff(ByVal pin_intRow As Short, ByRef pm_All As Cls_All)
		Dim strDKBID As String
		Dim Trg_Index As Short
		Dim blnBNKCD As Boolean
		Dim blnTEGDT As Boolean
		Dim blnTEGNO As Boolean
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strDKBID = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.BD_DKBID(pin_intRow).Tag)))
		blnBNKCD = False
		blnTEGDT = False
		blnTEGNO = False
		
		Select Case Trim(strDKBID)
			Case pc_strDKBID_URK_HURI
				'�U��
				'blnBNKCD = True
			Case pc_strDKBID_URK_TEG
				'��`
				blnBNKCD = True
				blnTEGDT = True
				blnTEGNO = True
				'2009/05/27 ADD START FKS)NAKATA
			Case pc_strDKBID_URK_HURIK
				'''' DEL 2011/06/14  FKS) T.Yamamoto    Start    �������P
				'���U���̏ꍇ�͌��ϓ�����͉Ƃ���
				'            '�����敪���u�O��v�ŁA�����U��
				'            If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
				'''' DEL 2011/06/14  FKS) T.Yamamoto    End
				blnTEGDT = True
				'''' DEL 2011/06/14  FKS) T.Yamamoto    Start    �������P
				'            End If
				'''' DEL 2011/06/14  FKS) T.Yamamoto    End
				'2009/05/27 ADD START FKS)NAKATA
		End Select
		
		Trg_Index = CShort(FR_SSSMAIN.BD_BNKCD(pin_intRow).Tag)
		Call CF_Set_Item_Focus_Ctl(blnBNKCD, pm_All.Dsp_Sub_Inf(Trg_Index))
		
		Trg_Index = CShort(FR_SSSMAIN.BD_TEGDT(pin_intRow).Tag)
		Call CF_Set_Item_Focus_Ctl(blnTEGDT, pm_All.Dsp_Sub_Inf(Trg_Index))
		
		Trg_Index = CShort(FR_SSSMAIN.BD_TEGNO(pin_intRow).Tag)
		Call CF_Set_Item_Focus_Ctl(blnTEGNO, pm_All.Dsp_Sub_Inf(Trg_Index))
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub F_Util_KNJKOZ_Search
	'   �T�v�F  �����������������
	'   �����F
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Util_KNJKOZ_Search(ByVal pin_strInputValue As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA) As Short
		Const c_LenMEICDB As Short = 1
		Const c_LenMEICDA As Short = 9
		
		Dim Retn_Code As Short
		Dim strMEICDA As String
		Dim strMEICDB As String
		
		pin_strInputValue = pin_strInputValue & Space(c_LenMEICDB + c_LenMEICDA)
		
		strMEICDB = LeftWid(pin_strInputValue, c_LenMEICDB)
		strMEICDA = MidWid(pin_strInputValue, c_LenMEICDB + 1, c_LenMEICDA)
		
		'2009/09/03 UPD START RISE)MIYAJIMA
		'    F_Util_KNJKOZ_Search = DSPMEIM_SEARCH(pc_strKEYCD_KNJKOZ, strMEICDA, pot_DB_MEIMTA, strMEICDB)
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			F_Util_KNJKOZ_Search = DSPMEIM_SEARCH(pc_strKEYCD_KNJKOZ_MAE, strMEICDA, pot_DB_MEIMTA, strMEICDB)
		Else
			F_Util_KNJKOZ_Search = DSPMEIM_SEARCH(pc_strKEYCD_KNJKOZ, strMEICDA, pot_DB_MEIMTA, strMEICDB)
		End If
		'2009/09/03 UPD E.N.D RISE)MIYAJIMA
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Util_Get_Simebi
	'   �T�v�F
	'   �����F  pin_strNYUDT
	'           pin_strTOKCD
	'           pot_strSMADT ���s���ʁF�o�������t
	'           pot_strSSADT ���s���ʁF�����t
	'           pot_strKESDT ���s���ʁF���ϓ��t
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Util_Get_Simebi(ByVal pin_strNYUDT As String, ByVal pin_strTOKCD As String, ByRef Pot_strSMADT As String, ByRef pot_strSSADT As String, ByRef Pot_strKESDT As String) As Short
		Dim strSMADT As String
		Dim strSSADT As String
		Dim strKESDT As String
		Dim intNXTKB As Short
		'// V1.10�� ADD
		Dim strSSAKBN As String
		'// V1.10�� ADD
		
		F_Util_Get_Simebi = 9
		
		If Trim(pin_strNYUDT) = "" Then Exit Function
		If Trim(pin_strTOKCD) = "" Then Exit Function
		intNXTKB = 0
		
		'--- �o�����ߓ��t�擾 ---
		strSMADT = F_Util_Get_Acedt(VB6.Format(pin_strNYUDT, "@@@@/@@/@@"), pv_strSMADD)
		
		'=== �������ߓ��t�擾 ===
		With URKET52_HEAD_Inf.TOKMTA
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(URKET52_HEAD_Inf.TOKMTA.TOKSMEKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If SSSVal(.TOKSMEKB) = 1 Then
				'--- ��X����� ---
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(URKET52_HEAD_Inf.TOKMTA.TOKSMECC) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSSADT = Get_SMEDT1(SSSVal(.TOKSMEDD), SSSVal(.TOKSMECC), VB6.Format(pin_strNYUDT, "@@@@/@@/@@"), intNXTKB)
				
				'// V1.20�� DEL
				'            strKESDT = Get_KESDT1(SSSVal(.TOKSMEDD) _
				''                                , SSSVal(.TOKSMECC) _
				''                                , SSSVal(.TOKKESCC) _
				''                                , SSSVal(.TOKKESDD) _
				''                                , Format(pin_strNYUDT, "@@@@/@@/@@"))
				'// V1.20�� DEL
			Else
				'--- �T���� ---
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSSADT = Get_SMEDT2(SSSVal(.TOKSDWKB), VB6.Format(pin_strNYUDT, "@@@@/@@/@@"), intNXTKB)
				
				'// V1.20�� DEL
				'            strKESDT = Get_KESDT2(SSSVal(.TOKSDWKB) _
				''                                , SSSVal(.TOKKESCC) _
				''                                , SSSVal(.TOKKDWKB) _
				''                                , Format(pin_strNYUDT, "@@@@/@@/@@"))
				'// V1.20�� DEL
			End If
			'// V1.10�� ADD
			Call F_Get_FIXMTA(strSSAKBN)
			Call AE_GetKESDT(strSSADT, .TOKSMEKB, .TOKKESCC, .TOKKESDD, .TOKKDWKB, strSSAKBN, strKESDT)
			'// V1.10�� ADD
		End With
		
		Pot_strSMADT = VB6.Format(strSMADT, "YYYYMMDD")
		pot_strSSADT = VB6.Format(strSSADT, "YYYYMMDD")
		'// V1.10�� UPD
		'    Pot_strKESDT = Format$(strKESDT, "YYYYMMDD")
		Pot_strKESDT = strKESDT
		'// V1.10�� UPD
		
		F_Util_Get_Simebi = 0
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Util_Get_Acedt
	'   �T�v�F  �Y���o�������t
	'   �����F
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Util_Get_Acedt(ByVal pin_wdate As String, ByVal pin_SMADD As String) As String
		If Not CHECK_DATE(pin_wdate) Then
			Call Error_Exit("���t�G���[(Get_Acedt): " & pin_wdate)
		End If
		
		If pin_SMADD > "27" Then
			F_Util_Get_Acedt = CStr(DateSerial(Year(CDate(pin_wdate)), Month(CDate(pin_wdate)) + 1, 0))
		ElseIf Right(pin_wdate, 2) <= pin_SMADD Then 
			F_Util_Get_Acedt = Left(pin_wdate, 8) & pin_SMADD
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(pin_SMADD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			F_Util_Get_Acedt = CStr(DateSerial(Year(CDate(pin_wdate)), Month(CDate(pin_wdate)) + 1, SSSVal(pin_SMADD)))
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Util_CheckJDNNO
	'   �T�v�F  �󒍔ԍ��`�F�b�N
	'   �����F  pin_strJDNNO
	'           pin_strJDNLINNO
	'           pin_strNYUDT
	'   �ߒl�F�@0:����I�� 9:�ُ�I��
	'           1:�Y���f�[�^�Ȃ�
	'           2:�󒍓`�[���t�̔N�������.�������̔N��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'''' UPD 2009/11/10  FKS) T.Yamamoto    Start    �A���[��757
	'Private Function F_Util_CheckJDNNO(ByVal pin_strJDNNO As String _
	''                                 , ByVal pin_strJDNLINNO As String) As Integer
	Private Function F_Util_CheckJDNNO(ByVal pin_strJDNNO As String, ByVal pin_strJDNLINNO As String, Optional ByVal pin_strNYUDT As String = "") As Short
		'''' UPD 2009/11/10  FKS) T.Yamamoto    End
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		Dim strDATNO As String
		'**** 2009/09/07 CHG START FKS)NAKATA
		Dim strJDNTRKB As String
		'**** 2009/09/07 CHG E.N.D FKS)NAKATA
		'''' ADD 2009/11/10  FKS) T.Yamamoto    Start    �A���[��757
		Dim strNYUYM As String
		Dim strJDNYM As String
		'''' ADD 2009/11/10  FKS) T.Yamamoto    End
		
		On Error GoTo F_Util_CheckJDNNO_err
		
		F_Util_CheckJDNNO = 9
		
		'SQL
		strSQL = ""
		'**** 2009/09/07 CHG START FKS)NAKATA
		'strSQL = strSQL & " SELECT DATNO "
		strSQL = strSQL & " SELECT DATNO , JDNTRKB "
		'**** 2009/09/07 CHG E.N.D FKS)NAKATA
		strSQL = strSQL & "   FROM JDNTHA "
		strSQL = strSQL & "      , (SELECT MAX(DATNO) AS MAX_DATNO "
		strSQL = strSQL & "           FROM JDNTHA "
		strSQL = strSQL & "          WHERE JDNNO = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
		strSQL = strSQL & "            AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "        ) SUB "
		strSQL = strSQL & "  WHERE JDNNO        = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
		strSQL = strSQL & "    AND DATKB        = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "    AND AKAKROKB     = '" & CF_Ora_String(gc_strAKAKROKB_KURO, 1) & "' "
		strSQL = strSQL & "    AND JDNTHA.DATNO = SUB.MAX_DATNO "

        'DB�A�N�Z�X
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        '�擾�f�[�^�ޔ�
        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            F_Util_CheckJDNNO = 1
            GoTo F_Util_CheckJDNNO_end
        Else
            'change start 20190827 kuwa
            '         'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '         strDATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")
            ''**** 2009/09/07 ADD START FKS)NAKATA
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'strJDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")
            ''**** 2009/09/07 ADD E.N.D FKS)NAKATA

            strDATNO = DB_NullReplace(dt.Rows(0)("DATNO"), "")
            strJDNTRKB = DB_NullReplace(dt.Rows(0)("JDNTRKB"), "")
            'change end 20190827 kuwa

        End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "   FROM JDNTHA "
		strSQL = strSQL & "  WHERE DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "    AND DATNO = '" & CF_Ora_String(strDATNO, 10) & "' "
		strSQL = strSQL & "    AND JDNNO = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
		'// V1.20�� ADD
		strSQL = strSQL & "    AND AKAKROKB = '" & CF_Ora_String(gc_strAKAKROKB_KURO, 1) & "' "
		strSQL = strSQL & "    AND MAEUKKB  = '" & CF_Ora_String(pc_strMAEUKKB, 1) & "' "
		'// V1.20�� ADD
		'2009/06/08 ADD START FKS)NAKATA
		'������
		strSQL = strSQL & "    AND TOKSEICD = '" & URKET52_HEAD_Inf.TOKCD & "' "
        '2009/06/08 ADD E.N.D FKS)NAKATA


        'DB�A�N�Z�X
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        dt = DB_GetTable(strSQL)

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            F_Util_CheckJDNNO = 1
            GoTo F_Util_CheckJDNNO_end
            '''' ADD 2009/11/10  FKS) T.Yamamoto    Start    �A���[��757
        Else
            If pin_strNYUDT <> "" Then
				strNYUYM = Left(Replace(pin_strNYUDT, "/", ""), 6)
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'change start 20190827 kuwa '�v�m�F(���͈������O�̏ꍇ�������BOptional�Ȃ̂łȂ��Ƃ����v���Ǝv����)
                'strJDNYM = Left(CF_Ora_GetDyn(Usr_Ody, "JDNDT"), 6)
                strJDNYM = Left(DB_NullReplace(dt.Rows(0)("JDNDT"), ""), 6)
                'change end 20190827 kuwa
                If strNYUYM < strJDNYM Then
					F_Util_CheckJDNNO = 2
					GoTo F_Util_CheckJDNNO_end
				End If
			End If
			'''' ADD 2009/11/10  FKS) T.Yamamoto    End
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		
		'**** 2009/09/07 CHG START FKS)NAKATA
		'�V�X�e���E�Z�b�g�A�b�v�󒍂ɂāu001�v�ȊO�̎󒍍s�ԍ�����͂���ƃG���[�Ƃ���
		If (strJDNTRKB = "11" Or strJDNTRKB = "21") And Trim(pin_strJDNLINNO) <> "001" Then
			F_Util_CheckJDNNO = 1
			GoTo F_Util_CheckJDNNO_end
		End If
		'**** 2009/09/07 CHG E.N.D FKS)NAKATA
		
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "   FROM JDNTRA "
		strSQL = strSQL & "  WHERE DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "    AND DATNO = '" & CF_Ora_String(strDATNO, 10) & "' "
		strSQL = strSQL & "    AND JDNNO = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
		'**** 2009/09/07 CHG START FKS)NAKATA
		'�V�X�e���E�Z�b�g�A�b�v�ȊO�́A�s�P�ʂɂĎ󒍃g�����̊m�F���s���B
		'strSQL = strSQL & "    AND LINNO = '" & CF_Ora_String(pin_strJDNLINNO, 3) & "' "
		If (strJDNTRKB = "11" Or strJDNTRKB = "21") Then
		Else
			strSQL = strSQL & "    AND LINNO = '" & CF_Ora_String(pin_strJDNLINNO, 3) & "' "
		End If
        '**** 2009/09/07 CHG E.N.D FKS)NAKATA

        'DB�A�N�Z�X
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        dt = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            F_Util_CheckJDNNO = 1
            GoTo F_Util_CheckJDNNO_end
        End If

        F_Util_CheckJDNNO = 0
		
F_Util_CheckJDNNO_end: 
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
F_Util_CheckJDNNO_err: 
		GoTo F_Util_CheckJDNNO_end
		
	End Function
	
	'2009/06/08 ADD START FKS)NAKATA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Util_Get_UODKN
	'   �T�v�F  �󒍋��z�̎擾
	'   �����F
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Util_Get_UODKN(ByVal pin_strJDNNO As String, ByVal pin_strJDNLINNO As String) As Decimal
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		Dim strDATNO As String
		Dim strJDNTRKB As String
		
		Dim curUODKN As Decimal
		Dim curNYUKN As Decimal
		
		
		On Error GoTo F_Util_Get_UODKN_err
		
		curUODKN = 0
		curNYUKN = 0
		
		F_Util_Get_UODKN = curUODKN - curNYUKN
		
		
		'�ߋ��̓����z�̎擾(�������g�ȊO���Q�Ƃ���)
		strSQL = ""
		strSQL = strSQL & " SELECT   NVL(SUM(TRA.NYUKN),0) AS NYUKN "
		strSQL = strSQL & "   FROM �@UDNTRA TRA"
		strSQL = strSQL & "  �@�@,   UDNTHA THA"
		strSQL = strSQL & "  WHERE   TRA.DATNO   =  THA.DATNO"
		strSQL = strSQL & "    AND   TRA.DATKB   =  '1'"
		strSQL = strSQL & "  �@AND   TRA.DENKB   =  '8'"
		'strSQL = strSQL & "  �@AND   TRA.KESIKB  =  '9'"
		strSQL = strSQL & "  �@AND   TRA.DKBID   != '09'" '�{�����͑���ɂ��Ȃ�
		strSQL = strSQL & "  �@AND   TRA.OKRJONO = '" & Trim(pin_strJDNNO) & Trim(pin_strJDNLINNO) & "' "
		strSQL = strSQL & "  �@AND   TRA.UDNDT  <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "    AND   TRA.DATNO <> '" & WLSNDN_RTNCODE & "' "
		strSQL = strSQL & "  �@AND   THA.NYUCD   =  '2'"
		strSQL = strSQL & "  �@AND   THA.FRNKB   =  '0'"


        'DB�A�N�Z�X
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        '�擾�f�[�^�ޔ�
        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            F_Util_Get_UODKN = curUODKN - curNYUKN
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'change start 20190827 kuwa
            'curNYUKN = CF_Ora_GetDyn(Usr_Ody, "NYUKN", "")
            curNYUKN = DB_NullReplace(dt.Rows(0)("NYUKN"), "")
            'change end 20190827 kuwa
        End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		
		'�ŐV�̓`�[�Ǘ����E�󒍎���敪�̎擾
		strSQL = ""
		strSQL = strSQL & " SELECT DATNO "
		strSQL = strSQL & " ,      JDNTRKB"
		strSQL = strSQL & "   FROM JDNTHA "
		strSQL = strSQL & "      , (SELECT MAX(DATNO) AS MAX_DATNO "
		strSQL = strSQL & "           FROM JDNTHA "
		strSQL = strSQL & "          WHERE JDNNO = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
		strSQL = strSQL & "            AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "            AND MAEUKKB  = '" & CF_Ora_String(pc_strMAEUKKB, 1) & "' "
		strSQL = strSQL & "        ) SUB "
		strSQL = strSQL & "  WHERE JDNNO        = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
		strSQL = strSQL & "    AND DATKB        = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "    AND AKAKROKB     = '" & CF_Ora_String(gc_strAKAKROKB_KURO, 1) & "' "
		strSQL = strSQL & "    AND TOKSEICD     = '" & URKET52_HEAD_Inf.TOKCD & "' "
		strSQL = strSQL & "    AND MAEUKKB      = '" & CF_Ora_String(pc_strMAEUKKB, 1) & "' "
		strSQL = strSQL & "    AND JDNTHA.DATNO = SUB.MAX_DATNO "

        'DB�A�N�Z�X
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        dt = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        '�擾�f�[�^�ޔ�
        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            F_Util_Get_UODKN = curUODKN - curNYUKN
            GoTo F_Util_Get_UODKN_end
        Else
            'change start 20190827 kuwa
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'strDATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'strJDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")
            strDATNO = DB_NullReplace(dt.Rows(0)("DATNO"), "")
            strJDNTRKB = DB_NullReplace(dt.Rows(0)("JDNTRKB"), "")
            'change end 20190827 kuwa

        End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		
		
		Select Case Trim(strJDNTRKB)
			'�Z�b�g�A�b�v(�󒍃g����.�󒍓`�[�敪=�u1�F�ʏ�A2�F��ı���ͯ�ށv)
			'�`�[�P�ʂɂĎ󒍋��z���擾����
			Case "11"
				strSQL = ""
				strSQL = strSQL & " SELECT NVL(SUM(UODKN) + SUM(UZEKN),0) AS UODKN "
				strSQL = strSQL & "   FROM JDNTRA "
				strSQL = strSQL & "  WHERE DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
				strSQL = strSQL & "    AND DATNO = '" & CF_Ora_String(strDATNO, 10) & "' "
				strSQL = strSQL & "    AND JDNNO = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
				strSQL = strSQL & "    AND JDNKB IN ('1','2') "
				
				
				'�V�X�e��(�󒍌��o���g�������擾)
				'�`�[�P�ʂɂĎ󒍋��z���擾����
			Case "21"
				strSQL = ""
				strSQL = strSQL & " SELECT NVL(SUM(SBAUODKN) + SUM(SBAUZEKN),0) AS UODKN�@"
				strSQL = strSQL & "   FROM JDNTHA "
				strSQL = strSQL & "  WHERE DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
				strSQL = strSQL & "    AND DATNO = '" & CF_Ora_String(strDATNO, 10) & "' "
				strSQL = strSQL & "    AND JDNNO = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
				
				
				'��L�ȊO
				'���׍s�P�ʂɂĎ󒍋��z���擾����
			Case Else
				
				strSQL = ""
				strSQL = strSQL & " SELECT NVL(SUM(UODKN) + SUM(UZEKN),0) AS UODKN "
				strSQL = strSQL & "   FROM JDNTRA "
				strSQL = strSQL & "  WHERE DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
				strSQL = strSQL & "    AND DATNO = '" & CF_Ora_String(strDATNO, 10) & "' "
				strSQL = strSQL & "    AND JDNNO = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
				strSQL = strSQL & "    AND LINNO = '" & CF_Ora_String(pin_strJDNLINNO, 3) & "' "
				
		End Select


        'DB�A�N�Z�X
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        dt = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        '�擾�f�[�^�ޔ�
        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            F_Util_Get_UODKN = curUODKN - curNYUKN
            GoTo F_Util_Get_UODKN_end
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'change start 20190827 kuwa
            'curUODKN = CF_Ora_GetDyn(Usr_Ody, "UODKN", "")
            curUODKN = DB_NullReplace(dt.Rows(0)("UODKN"), "")
            'change end 20190827 kuwa
        End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		
		F_Util_Get_UODKN = curUODKN - curNYUKN
		
		
		
F_Util_Get_UODKN_end: 
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
F_Util_Get_UODKN_err: 
		GoTo F_Util_Get_UODKN_end
		
	End Function
	'2009/06/08 ADD E.N.D FKS)NAKATA
	
	'2009/09/24 DEL START RISE)MIYAJIMA
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   ���́F  Function F_Util_CheckSumOver
	''   �T�v�F  �ύX���z����`�F�b�N
	''   �����F
	''   �ߒl�F
	''   ���l�F �����z�ύX���E����������ɁA�����T�}���̏��������z�c�݌v���A�ύX���z�E����z���傫�����̓G���[�Ƃ��A�ē��͂𑣂��B
	''          Ex.) ���������z�c��100���̎��A150���̓����`�[��40���ɕύX�E�܂��͎�����邱�Ƃ͂ł��Ȃ��B�����z��100���ȏ�̂��߁B50���ȏ�Ȃ�ύX�B
	''          ���C�O���Ӑ�̎��́A�����T�}���O�݂̏��������c�z�݌v�𔻒f��ɂ���B
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Private Function F_Util_CheckSumOver(pm_All As Cls_All) As Integer
	'    Dim strSQL      As String
	'    Dim curMOTKN    As Currency '�ύX�O�̋��z
	'    Dim curCHGKN    As Currency '�ύX��̋��z
	'    Dim curZANKN    As Currency 'SQL ��DB����擾���鐿���T�}���D���������z�c
	'    Dim intCnt      As Integer
	'    Dim intRet      As Integer
	'
	'    F_Util_CheckSumOver = 9
	'
	'    '�����T�}���D���������z�c ���擾
	'    intRet = F_Util_CheckSumOver_GetZANKN(pm_All, curZANKN)
	'    If intRet <> 0 Then
	'        F_Util_CheckSumOver = intRet
	'        Exit Function
	'    End If
	'
	'    '�c�z���[���̏ꍇ �ȊO �`�F�b�N���s��
	''2009/09/05 DEL START RISE)MIYAJIMA
	''    If curZANKN <> 0 Then
	''2009/09/05 DEL E.N.D RISE)MIYAJIMA
	'        With URKET52_HEAD_Inf
	'            If .TOKMTA.FRNKB = gc_strFRNKB_FRN Then
	'                '�C�O
	'
	'                '�ύX�O�̋��z���擾
	'                curMOTKN = .UDNTHA.SBAFRNKN
	'
	'                '�ύX��̋��z���擾
	'                curCHGKN = pv_dblFNYUKN_SUM
	'            Else
	'                '����
	'
	'                If .NYUKB = gc_strMAEUKKB_NML Then
	'                    '����
	'
	'                    '�ύX�O�̋��z���擾 (�����T�}���X�V���̏������l�����ďW�v)
	'                    curMOTKN = 0
	'                    For intCnt = 1 To UBound(.UDNTRA)
	'                        '�f�t�H���g�R�[�h���R
	'                        If Trim(.UDNTRA(intCnt).DFLDKBCD) <> "3" Then
	'                            curMOTKN = curMOTKN + .UDNTRA(intCnt).NYUKN
	'                        End If
	'                    Next intCnt
	'
	'                    '�ύX��̋��z���擾 (�����T�}���X�V���̏������l�����ďW�v)
	'                    curCHGKN = 0
	'                    For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
	'                        '�f�t�H���g�R�[�h���R
	'                        If Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SYSTBD.DFLDKBCD) <> "3" Then
	'                            curCHGKN = curCHGKN + pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.NYUKN
	'                        End If
	'                    Next intCnt
	'                 Else
	'                    '�O�����
	'
	'                    '�ύX�O�̋��z���擾
	'                    curMOTKN = .UDNTHA.SBANYUKN
	'
	'                    '�ύX��̋��z���擾
	'                    curCHGKN = pv_curNYUKN_SUM
	'                End If
	'            End If
	'        End With
	'
	'
	''2009/09/05 ADD START RISE)MIYAJIMA
	'    If curZANKN <> 0 Then
	''2009/09/05 ADD E.N.D RISE)MIYAJIMA
	'        '�`�F�b�N
	'        '�ύX�O�̋��z�@�|�@�ύX��̋��z�@���@�����T�}���D���������z�c
	'        If curMOTKN < 0 Or curCHGKN < 0 Then
	'            If Abs(curMOTKN - curCHGKN) > Abs(curZANKN) Then
	'                F_Util_CheckSumOver = 2
	'                Exit Function
	'            End If
	'        Else
	'            If Abs(curMOTKN) - Abs(curCHGKN) > Abs(curZANKN) Then
	'                F_Util_CheckSumOver = 2
	'                Exit Function
	'            End If
	'        End If
	'    End If
	'
	''2009/09/05 ADD START RISE)MIYAJIMA
	'    If curZANKN = 0 And curMOTKN <> 0 And curMOTKN > curCHGKN Then
	'        F_Util_CheckSumOver = 2
	'        Exit Function
	'    End If
	''2009/09/05 ADD E.N.D RISE)MIYAJIMA
	'
	'    F_Util_CheckSumOver = 0
	'End Function
	'2009/09/24 DEL E.N.D RISE)MIYAJIMA
	
	'2009/09/24 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Util_CheckSumOver
	'   �T�v�F  �ύX���z����`�F�b�N
	'   �����F
	'   �ߒl�F
	'   ���l�F �����z�ύX���E����������ɁA�����T�}���̏��������z�c�݌v���A�ύX���z�E����z���傫�����̓G���[�Ƃ��A�ē��͂𑣂��B
	'          Ex.) ���������z�c��100���̎��A150���̓����`�[��40���ɕύX�E�܂��͎�����邱�Ƃ͂ł��Ȃ��B�����z��100���ȏ�̂��߁B50���ȏ�Ȃ�ύX�B
	'          ���C�O���Ӑ�̎��́A�����T�}���O�݂̏��������c�z�݌v�𔻒f��ɂ���B
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Util_CheckSumOver(ByRef pm_All As Cls_All, ByRef pm_Mode As Short) As Short
		
		Dim curAryMOTKN(9) As Decimal '�ύX�O�̋��z
		Dim curAryCHGKN(9) As Decimal '�ύX��̋��z
		Dim curMOTKN As Decimal '�ύX�O�̋��z
		Dim curCHGKN As Decimal '�ύX��̋��z
		Dim curZANKN As Decimal 'SQL ��DB����擾���鐿���T�}���D���������z�c
		Dim I As Short
		Dim intCnt As Short
		Dim intRet As Short
		
		F_Util_CheckSumOver = 9
		
		'�ύX��̋��z���擾 (�����T�}���X�V���̏������l�����ďW�v)
		'UPGRADE_NOTE: Erase �� System.Array.Clear �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
		System.Array.Clear(curAryCHGKN, 0, curAryCHGKN.Length)
		For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			'�f�t�H���g�R�[�h���R
			If Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.DKBID) <> "" Then
				If Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SYSTBD.DFLDKBCD) <> "3" Then
					'2009/10/05 UPD START RISE)MIYAJIMA
					'        curAryCHGKN(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SYSTBD.UPDID) = _
					''        curAryCHGKN(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SYSTBD.UPDID) + _
					''        pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.NYUKN
					If URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN Then
						curAryCHGKN(CInt(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SYSTBD.UPDID)) = curAryCHGKN(CInt(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SYSTBD.UPDID)) + pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.FNYUKN
					Else
						curAryCHGKN(CInt(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SYSTBD.UPDID)) = curAryCHGKN(CInt(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SYSTBD.UPDID)) + pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.NYUKN
					End If
					'2009/10/05 UPD E.N.D RISE)MIYAJIMA
				End If
			End If
		Next intCnt
		
		'�ύX�O�̋��z���擾 (�����T�}���X�V���̏������l�����ďW�v)
		With URKET52_HEAD_Inf
			'UPGRADE_NOTE: Erase �� System.Array.Clear �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
			System.Array.Clear(curAryMOTKN, 0, curAryMOTKN.Length)
			For intCnt = 1 To UBound(.UDNTRA)
				'�f�t�H���g�R�[�h���R
				If Trim(.UDNTRA(intCnt).DFLDKBCD) <> "3" Then
					'2009/10/05 UPD START RISE)MIYAJIMA
					'                curAryMOTKN(.UDNTRA(intCnt).UPDID) = _
					''                curAryMOTKN(.UDNTRA(intCnt).UPDID) + _
					''                .UDNTRA(intCnt).NYUKN
					If URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN Then
						curAryMOTKN(CInt(.UDNTRA(intCnt).UPDID)) = curAryMOTKN(CInt(.UDNTRA(intCnt).UPDID)) + .UDNTRA(intCnt).FNYUKN
					Else
						curAryMOTKN(CInt(.UDNTRA(intCnt).UPDID)) = curAryMOTKN(CInt(.UDNTRA(intCnt).UPDID)) + .UDNTRA(intCnt).NYUKN
					End If
					'2009/10/05 UPD E.N.D RISE)MIYAJIMA
				End If
			Next intCnt
		End With
		
		'2009/09/30 UPD START RISE)MIYAJIMA
		'���z�`�F�b�N
		
		For I = 0 To 9
			Select Case URKET52_HEAD_Inf.TOKMTA.SHAKB
				Case pc_strSHAKB_HURI, pc_strSHAKB_TEG, pc_strSHAKB_HURI_OR_TEG, pc_strSHAKB_HURI_AND_TEG
					If I <> 7 Then '�U����(UPDID = 7)
						curMOTKN = curMOTKN + curAryMOTKN(I)
						curCHGKN = curCHGKN + curAryCHGKN(I)
						curZANKN = curZANKN + gc_NKSSMX_Inf.curZAN(I)
					End If
				Case pc_strSHAKB_KIJZITU, pc_strSHAKB_FACTERING
					curMOTKN = curMOTKN + curAryMOTKN(I)
					curCHGKN = curCHGKN + curAryCHGKN(I)
					curZANKN = curZANKN + gc_NKSSMX_Inf.curZAN(I)
			End Select
		Next I
		
		'������
		If pm_Mode = 1 Then
			If curMOTKN <> 0 Or curCHGKN <> 0 Then
				If curZANKN - (curMOTKN - curCHGKN) < 0 Then
					F_Util_CheckSumOver = 2
					Exit Function
				End If
			End If
		End If
		
		'�폜��
		If pm_Mode = 9 Then
			If curMOTKN <> 0 Then
				If curZANKN - curMOTKN < 0 Then
					F_Util_CheckSumOver = 2
					Exit Function
				End If
			End If
		End If
		
		'    '����P�ʂ̎c�z�`�F�b�N
		'    For I = 0 To 9
		'
		'        '������
		'        If pm_Mode = 1 Then
		'            If curAryMOTKN(I) <> 0 Or curAryCHGKN(I) <> 0 Then
		'                If gc_NKSSMX_Inf.curZAN(I) - (curAryMOTKN(I) - curAryCHGKN(I)) < 0 Then
		'                    F_Util_CheckSumOver = 2
		'                    Exit Function
		'                End If
		'            End If
		'        End If
		'
		'        '�폜��
		'        If pm_Mode = 9 Then
		'            If curAryMOTKN(I) <> 0 Then
		'                If gc_NKSSMX_Inf.curZAN(I) - curAryMOTKN(I) < 0 Then
		'                    F_Util_CheckSumOver = 2
		'                    Exit Function
		'                End If
		'            End If
		'        End If
		'
		'    Next I
		'
		'    '�O���X�̎c�z�`�F�b�N
		'    If curZANKN <> 0 Then
		'        '�`�F�b�N
		'        '�ύX�O�̋��z�@�|�@�ύX��̋��z�@���@�����T�}���D���������z�c
		'        If curMOTKN < 0 Or curCHGKN < 0 Then
		'            If Abs(curMOTKN - curCHGKN) > Abs(curZANKN) Then
		'                F_Util_CheckSumOver = 2
		'                Exit Function
		'            End If
		'        Else
		'            If Abs(curMOTKN) - Abs(curCHGKN) > Abs(curZANKN) Then
		'                F_Util_CheckSumOver = 2
		'                Exit Function
		'            End If
		'        End If
		'    End If
		'
		'    If curZANKN = 0 And curMOTKN <> 0 And curMOTKN > curCHGKN Then
		'        F_Util_CheckSumOver = 2
		'        Exit Function
		'    End If
		'2009/09/30 UPD E.N.D RISE)MIYAJIMA
		
		F_Util_CheckSumOver = 0
	End Function
	'2009/09/24 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/24 DEL START RISE)MIYAJIMA
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   ���́F  Function F_Util_CheckSumOver_GetZANKN
	''   �T�v�F  �ύX���z����`�F�b�N�p
	''           �`�F�b�N�Ɏg�������T�}���D���������z�c���擾����
	''   �����F  pot_curZANKN�F�����T�}���D���������z�c
	''   �ߒl�F
	''   ���l�F
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Private Function F_Util_CheckSumOver_GetZANKN(pm_All As Cls_All _
	''                                            , ByRef pot_curZANKN As Currency) As Integer
	'    Dim strSQL          As String
	'    Dim Usr_Ody_LC      As U_Ody
	'
	'On Error GoTo ERR_F_Util_CheckSumOver_GetZANKN
	'
	'    F_Util_CheckSumOver_GetZANKN = 9
	'
	'    With URKET52_HEAD_Inf
	'        If .TOKMTA.FRNKB = gc_strFRNKB_FRN Then
	'            '�C�O
	'            strSQL = ""
	'            strSQL = strSQL & " SELECT SUM(FKSZANKN) AS SUMDATA "
	'            strSQL = strSQL & " FROM TOKSSC "
	'            strSQL = strSQL & " WHERE TOKCD = '" & CF_Ora_String(.TOKCD, 10) & "' "
	'            strSQL = strSQL & "   AND TUKKB = '" & CF_Ora_String(.TOKMTA.TUKKB, 3) & "' "
	'            strSQL = strSQL & "   AND SSADT = '" & CF_Ora_String(.UDNTHA.SSADT, 8) & "' "
	'        Else
	'            '����
	'            strSQL = ""
	'            strSQL = strSQL & " SELECT SUM(KSKZANKN) AS SUMDATA "
	'            If .NYUKB = gc_strMAEUKKB_NML Then  '����
	'                strSQL = strSQL & " FROM TOKSSA "
	'            Else                                '�O�����
	'                strSQL = strSQL & " FROM TOKSSB "
	'            End If
	'            strSQL = strSQL & " WHERE TOKCD = '" & CF_Ora_String(.TOKCD, 10) & "' "
	'            strSQL = strSQL & "   AND SSADT = '" & CF_Ora_String(.UDNTHA.SSADT, 8) & "' "
	'        End If
	'    End With
	'
	'    'DB�A�N�Z�X
	'    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
	'
	'    If CF_Ora_EOF(Usr_Ody_LC) = True Then
	'        '�擾�f�[�^�Ȃ�
	'        pot_curZANKN = 0
	'    Else
	'        '�擾�f�[�^����
	'        pot_curZANKN = CF_Ora_GetDyn(Usr_Ody_LC, "SUMDATA", 0)
	'    End If
	'
	'    F_Util_CheckSumOver_GetZANKN = 0
	'
	'END_F_Util_CheckSumOver_GetZANKN:
	'
	'    '�N���[�Y
	'    Call CF_Ora_CloseDyn(Usr_Ody_LC)
	'
	'    Exit Function
	'
	'ERR_F_Util_CheckSumOver_GetZANKN:
	'    GoTo END_F_Util_CheckSumOver_GetZANKN
	'
	'End Function
	'2009/09/24 DEL E.N.D RISE)MIYAJIMA
	
	'2009/09/24 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Util_CheckSumOver_GetZANKN
	'   �T�v�F  �ύX���z����`�F�b�N�p
	'           �`�F�b�N�Ɏg�������T�}���D���������z�c���擾����
	'   �����F  pot_curZANKN�F�����T�}���D���������z�c�\����
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Util_CheckSumOver_GetZANKN(ByRef pm_All As Cls_All) As Short
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		Dim I As Short
		'UPGRADE_WARNING: �\���� UsrNKSSMX_Inf �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim UsrNKSSMX_Inf As TYPE_NKSSMX
		
		On Error GoTo ERR_F_Util_CheckSumOver_GetZANKN
		
		F_Util_CheckSumOver_GetZANKN = 9
		
		With URKET52_HEAD_Inf
			If .TOKMTA.FRNKB = gc_strFRNKB_FRN Then
				'�C�O
				strSQL = ""
				strSQL = strSQL & " SELECT * "
				strSQL = strSQL & " FROM NKSSMC "
				strSQL = strSQL & " WHERE TOKCD = '" & CF_Ora_String(.TOKCD, 10) & "' "
				strSQL = strSQL & "   AND TUKKB = '" & CF_Ora_String(.TOKMTA.TUKKB, 3) & "' "
				'2009/09/29 UPD START RISE)MIYAJIMA
				'            strSQL = strSQL & "   AND SMADT = '" & CF_Ora_String(.UDNTHA.SMADT, 8) & "' "
				strSQL = strSQL & "   AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' "
				'2009/09/29 UPD E.N.D RISE)MIYAJIMA
			Else
				'����
				strSQL = ""
				strSQL = strSQL & " SELECT * "
				If .NYUKB = gc_strMAEUKKB_NML Then '����
					strSQL = strSQL & " FROM NKSSMA "
				Else '�O�����
					strSQL = strSQL & " FROM NKSSMB "
				End If
				strSQL = strSQL & " WHERE TOKCD = '" & CF_Ora_String(.TOKCD, 10) & "' "
				'2009/09/29 UPD START RISE)MIYAJIMA
				'            strSQL = strSQL & "   AND SMADT = '" & CF_Ora_String(.UDNTHA.SMADT, 8) & "' "
				strSQL = strSQL & "   AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' "
				'2009/09/29 UPD E.N.D RISE)MIYAJIMA
			End If
		End With

        'DB�A�N�Z�X
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody_LC) <> True Then
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            'change end 20190826 kuwa
            '�擾�f�[�^����
            With UsrNKSSMX_Inf
                For I = 0 To 9
                    'change start 20190826 kuwa
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.curSSANYUKN(I) = CF_Ora_GetDyn(Usr_Ody_LC, "SSANYUKN" & VB6.Format(I, "00"), 0)
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.curKSKNYKKN(I) = CF_Ora_GetDyn(Usr_Ody_LC, "KSKNYKKN" & VB6.Format(I, "00"), 0)
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.curKSKZANKN(I) = CF_Ora_GetDyn(Usr_Ody_LC, "KSKZANKN" & VB6.Format(I, "00"), 0)

                    'add start 20190826 kuwa
                    ReDim Preserve .curSSANYUKN(I)
                    ReDim Preserve .curKSKNYKKN(I)
                    ReDim Preserve .curKSKZANKN(I)
                    ReDim Preserve .curZAN(I)
                    'add end 20190826 
                    .curSSANYUKN(I) = DB_NullReplace(dt.Rows(0)("SSANYUKN" & VB6.Format(I, "00")), 0)
                    .curKSKNYKKN(I) = DB_NullReplace(dt.Rows(0)("KSKNYKKN" & VB6.Format(I, "00")), 0)
                    .curKSKZANKN(I) = DB_NullReplace(dt.Rows(0)("KSKZANKN" & VB6.Format(I, "00")), 0)
                    'change end 20190826 kuwa
                    .curZAN(I) = .curSSANYUKN(I) - .curKSKNYKKN(I) + .curKSKZANKN(I)
                    If I <> 8 Then '�{�����͑���ɂ��Ȃ�
                        .curTOTAL = .curTOTAL + .curZAN(I)
                    End If
                Next I
                'change start 20190826 kuwa
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.strOPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.strCLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.strWRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.strWRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")

                .strOPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "")
                .strCLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "")
                .strWRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "")
                .strWRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "")
                'change end 20190826 kuwa
            End With
        End If

        'UPGRADE_WARNING: �I�u�W�F�N�g gc_NKSSMX_Inf �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gc_NKSSMX_Inf = UsrNKSSMX_Inf
		
		F_Util_CheckSumOver_GetZANKN = 0
		
END_F_Util_CheckSumOver_GetZANKN: 
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_F_Util_CheckSumOver_GetZANKN: 
		GoTo END_F_Util_CheckSumOver_GetZANKN
		
	End Function
	'2009/09/24 ADD E.N.D RISE)MIYAJIMA
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub F_Util_NYUKN_Sum
	'   �T�v�F  �����z�E���v(�~)�̏W�v����
	'   �����F
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub F_Util_NYUKN_Sum(ByRef pm_All As Cls_All)
		Dim intCnt As Short
		Dim Trg_Index As Short
		Dim blnEmpty As Boolean 'True=���ׂĖ�����
		Dim Dsp_Value As Object
		Dim curNYUKN As Decimal
		
		blnEmpty = True
		curNYUKN = 0
		For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			'�y�����z(�~)�z
			Trg_Index = CShort(FR_SSSMAIN.BD_NYUKN(intCnt).Tag)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))) <> "" Then
				blnEmpty = False
				curNYUKN = curNYUKN + pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.NYUKN
			End If
		Next intCnt
		
		pv_curNYUKN_SUM = curNYUKN
		Trg_Index = CShort(FR_SSSMAIN.TL_SBANYUKN.Tag)
		If blnEmpty = True Then
			'���ׂĖ����͂�������A�󔒕\��
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Dsp_Value = CF_Cnv_Dsp_Item(pv_curNYUKN_SUM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		End If
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub F_Util_FNYUKN_Sum
	'   �T�v�F  �����z�E���v(�O��)�̏W�v����
	'   �����F
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub F_Util_FNYUKN_Sum(ByRef pm_All As Cls_All)
		Dim intCnt As Short
		Dim Trg_Index As Short
		Dim blnEmpty As Boolean 'True=���ׂĖ�����
		Dim Dsp_Value As Object
		Dim dblFNYUKN As Double
		
		blnEmpty = True
		dblFNYUKN = 0
		For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			'�y�����z(�O��)�z
			Trg_Index = CShort(FR_SSSMAIN.BD_FNYUKN(intCnt).Tag)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))) <> "" Then
				blnEmpty = False
				dblFNYUKN = dblFNYUKN + pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.FNYUKN
			End If
		Next intCnt
		
		pv_dblFNYUKN_SUM = dblFNYUKN
		Trg_Index = CShort(FR_SSSMAIN.TL_SBAFRNKN.Tag)
		If blnEmpty = True Then
			'���ׂĖ����͂�������A�󔒕\��
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Dsp_Value = CF_Cnv_Dsp_Item(pv_dblFNYUKN_SUM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		End If
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Util_GET_TANMTA_KEIBMNCD
	'   �T�v�F  �o������R�[�h���擾
	'   �����F�@pot_strTANCD       : �S���҃R�[�h
	'       �F�@pot_strKEIBMNCD    : �o������R�[�h
	'   �ߒl�F�@0:����I�� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Util_GET_TANMTA_KEIBMNCD(ByRef pot_strTANCD As String, ByRef pot_strKEIBMNCD As String) As Short
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		Dim strTANBMNCD As String '��������R�[�h
		Dim strOLDBMNCD As String '����������R�[�h
		Dim strTANTKDT As String '�K�p��
		Dim strZMBMNCD As String '��v����R�[�h
		Dim strTKDT As String
		
		On Error GoTo ERR_F_Util_GET_TANMTA_KEIBMNCD
		
		F_Util_GET_TANMTA_KEIBMNCD = 9
		
		strTKDT = Replace(URKET52_HEAD_Inf.NYUDT, "/", "")
		
		'�S���҂l
		strSQL = ""
		strSQL = strSQL & " SELECT TANBMNCD, OLDBMNCD, TANTKDT "
		strSQL = strSQL & " FROM TANMTA "
		strSQL = strSQL & " WHERE TANCD = '" & pot_strTANCD & "' "

        'DB�A�N�Z�X
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = False Then
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            'change end 20190826 kuwa
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'change start 20190826 kuwa
            'strTANBMNCD = CF_Ora_GetDyn(Usr_Ody, "TANBMNCD", "")
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'strOLDBMNCD = CF_Ora_GetDyn(Usr_Ody, "OLDBMNCD", "")
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'strTANTKDT = CF_Ora_GetDyn(Usr_Ody, "TANTKDT", "")

            strTANBMNCD = DB_NullReplace(dt.Rows(0)("TANBMNCD"), "")
            strOLDBMNCD = DB_NullReplace(dt.Rows(0)("OLDBMNCD"), "")
            strTANTKDT = DB_NullReplace(dt.Rows(0)("TANTKDT"), "")
            'change end 20190826 kuwa
        Else
            GoTo END_F_Util_GET_TANMTA_KEIBMNCD
		End If
		
		'����l
		strSQL = ""
		strSQL = strSQL & " SELECT ZMBMNCD "
		strSQL = strSQL & " FROM BMNMTA "
		strSQL = strSQL & " WHERE "
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(strTANTKDT) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(strTKDT) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(strTKDT) >= SSSVal(strTANTKDT) Then
			strSQL = strSQL & " BMNCD = '" & strTANBMNCD & "' "
		Else
			strSQL = strSQL & " BMNCD = '" & strOLDBMNCD & "' "
		End If
		strSQL = strSQL & " AND '" & strTKDT & "' BETWEEN STTTKDT AND ENDTKDT "

        'DB�A�N�Z�X
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        dt = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = False Then
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            'change end 20190826 kuwa
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'change start 20190827 kuwa
            'strZMBMNCD = CF_Ora_GetDyn(Usr_Ody, "ZMBMNCD", "")
            strZMBMNCD = DB_NullReplace(dt.Rows(0)("ZMBMNCD"), "")
            'change end 20190827 kuwa
        Else
            GoTo END_F_Util_GET_TANMTA_KEIBMNCD
		End If
		
		'�o������R�[�h�������֐ݒ肷��
		pot_strKEIBMNCD = strZMBMNCD
		
		F_Util_GET_TANMTA_KEIBMNCD = 0
		
END_F_Util_GET_TANMTA_KEIBMNCD: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_F_Util_GET_TANMTA_KEIBMNCD: 
		GoTo END_F_Util_GET_TANMTA_KEIBMNCD
		
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

        On Error GoTo Err_F_Ctl_Upd_Process

        F_Ctl_Upd_Process = 9

        If gv_bolUpdFlg = True Then
            Exit Function
        End If

        gv_bolUpdFlg = True

        '�����v�ɂ���
        'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        '�A�N�e�B�u�R���g���[���̂k�e����
        If CF_Ctl_Item_LostFocus_Dummy(pm_All) <> CHK_OK Then
            '�`�F�b�NNG�̏ꍇ
            GoTo End_F_Ctl_Upd_Process
        End If

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
        intRet = F_Ctl_Tail_Chk(pm_All)
        If intRet <> CHK_OK Then
            '�`�F�b�N�m�f�̏ꍇ
            GoTo End_F_Ctl_Upd_Process
        End If

        '�S�̃`�F�b�N
        intRet = F_Ctl_ALL_RelChk(pm_All)
        If intRet <> CHK_OK Then
            '�`�F�b�N�m�f�̏ꍇ
            GoTo End_F_Ctl_Upd_Process
        End If

        '2009/10/05 ADD START RISE)MIYAJIMA
        '�󒍂̔r�����擾�@�i�������A�O��̂݁j
        If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
            Call F_Get_JDN_HAITA(pm_All)
        End If
        '2009/10/05 ADD E.N.D RISE)MIYAJIMA

        '2009/06/08 ADD START FKS)NAKATA
        '�u�󒍋��z=�����z�v�̃`�F�b�N�@�i�������A�O��̂݁j
        If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then

            intRet = F_Chk_UODKN_JDNNO(pm_All)
            If intRet <> CHK_OK Then
                '�`�F�b�N�m�f�̏ꍇ
                GoTo End_F_Ctl_Upd_Process
            End If

        End If
        '2009/06/08 ADD E.N.D FKS)NAKATA
        '*** 2009/09/07 ADD START FKS)NAKATA
        ''�����̃`�F�b�N�@�i�������A�O��̂݁j
        If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then

            intRet = F_Chk_KESIZUMI(pm_All)
            If intRet <> CHK_OK Then
                '�`�F�b�N�m�f�̏ꍇ
                GoTo End_F_Ctl_Upd_Process
            End If
        End If
        '*** 2009/09/07 ADD E.N.D FKS)NAKATA

        '2009/09/18 ADD START RISE)MIYAJIMA
        '���������`�F�b�N
        intRet = F_Chk_AllKESAIBI(pm_All)
        If intRet <> CHK_OK Then
            '�`�F�b�N�m�f�̏ꍇ
            GoTo End_F_Ctl_Upd_Process
        End If
        '2009/09/18 ADD E.N.D RISE)MIYAJIMA

        '2009/09/29 DEL START RISE)MIYAJIMA
        ''2009/09/24 ADD START RISE)MIYAJIMA
        '    '�ύX���z����`�F�b�N
        '    If F_Util_CheckSumOver(pm_All, 1) <> 0 Then
        '        '���b�Z�[�W�o��
        '        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_029, pm_All)
        '        '�`�F�b�N�m�f�̏ꍇ
        '        GoTo End_F_Ctl_Upd_Process
        '    End If
        ''2009/09/24 ADD E.N.D RISE)MIYAJIMA
        '2009/09/29 DEL E.N.D RISE)MIYAJIMA

        '2009/10/05 ADD START RISE)MIYAJIMA
        If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
            intRet = F_Chk_EXIST_MotoJDNNO(pm_All)
            If intRet <> 0 Then
                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_038, pm_All) ' MSG���e:�֘A�����󒍂��������Ă���ׁA�X�V�ł��܂���B
                GoTo End_F_Ctl_Upd_Process
            End If
        End If
        '2009/10/05 ADD E.N.D RISE)MIYAJIMA

        '�}�E�X�|�C���^��߂�
        'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        gv_bolURKET52_LF_Enable = False

        'Windows�ɏ�����Ԃ�
        System.Windows.Forms.Application.DoEvents()

        gv_bolURKET52_LF_Enable = True

        '�󒍓o�^�̌������Ȃ��ꍇ�͏������s��Ȃ�
        If Inp_Inf.InpJDNUPDKB <> gc_strJDNUPDKB_OK Then
            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_003, pm_All)
            GoTo End_F_Ctl_Upd_Process
        End If

        '�o�������t�A�����t�A���ϓ��t �擾
        intRet = F_Util_Get_Simebi(URKET52_HEAD_Inf.NYUDT, URKET52_HEAD_Inf.TOKCD, pv_strSMADT, pv_strSSADT, pv_strKESDT)
        If intRet <> 0 Then
            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_027, pm_All)
            GoTo End_F_Ctl_Upd_Process
        End If

        '2009/09/30 ADD START RISE)MIYAJIMA
        '�����T�}���D���������z�c ���擾
        intRet = F_Util_CheckSumOver_GetZANKN(pm_All)
        If intRet <> 0 Then
            GoTo End_F_Ctl_Upd_Process
        End If
        '2009/09/30 ADD E.N.D RISE)MIYAJIMA

        '2009/09/29 ADD START RISE)MIYAJIMA
        '�ύX���z����`�F�b�N
        If F_Util_CheckSumOver(pm_All, 1) <> 0 Then
            '���b�Z�[�W�o��
            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_029, pm_All)
            '�`�F�b�N�m�f�̏ꍇ
            GoTo End_F_Ctl_Upd_Process
        End If
        '2009/09/29 ADD E.N.D RISE)MIYAJIMA

        '''' ADD 2009/11/10  FKS) T.Yamamoto    Start    �A���[��757
        '���.�������̔N�� < �󒍓`�[���t�̔N���̏ꍇ�̓G���[
        If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then

            intRet = F_Chk_NYUDT_JDNDT(pm_All)
            If intRet <> CHK_OK Then
                '�`�F�b�N�m�f�̏ꍇ
                GoTo End_F_Ctl_Upd_Process
            End If

        End If
        '''' ADD 2009/11/10  FKS) T.Yamamoto    End

        '�o�^�m�F
        If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_A_005, pm_All) = MsgBoxResult.No Then
            GoTo End_F_Ctl_Upd_Process
        End If

        '����̫����ʒu�ݒ�
        Call F_Init_Cursor_Set(pm_All)

        '�{�^����\��
        'delete start 20190826 kuwa
        'FR_SSSMAIN.CM_Execute.Visible = False
        'delete end 20190826 kuwa

        '�o�^����
        intRet = F_Update_Main(pm_All)
        If intRet <> 0 Then
            F_Ctl_Upd_Process = intRet
            GoTo Err_F_Ctl_Upd_Process
        End If

        '�o�^����
        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_A_006, pm_All)

        F_Ctl_Upd_Process = 0

End_F_Ctl_Upd_Process:
        '�}�E�X�|�C���^��߂�
        'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '�{�^���\��
        '2019/06/06 DEL START
        'FR_SSSMAIN.CM_Execute.Visible = True
        '2019/06/06 DEL END
        gv_bolUpdFlg = False

        '�L�[�t���O�����ɖ߂�
        gv_bolKeyFlg = False
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
		Dim intRet As Short
		Dim strDATNO As String '�`�[�Ǘ���
		Dim strDenNo As String '�`�[��
		Dim strRecNo As String '���R�[�h�Ǘ���
		Dim intCnt As Short
		Dim bolTran As Boolean
		
		Dim Tbl_Inf_UDNTHA As TYPE_DB_UDNTHA
		Dim Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA
		
		'2009/09/24 ADD START RISE)MIYAJIMA
		Dim bolAKAKRO As Boolean
		Dim strSMADT_Rec As String
		Dim strSSADT_Rec As String
		Dim strKESDT_Rec As String
		'2009/09/24 ADD E.N.D RISE)MIYAJIMA
		
		'2009/09/30 ADD START RISE)MIYAJIMA
		Dim int_DspIndex As Short
		'2009/09/30 ADD E.N.D RISE)MIYAJIMA
		
		On Error GoTo F_Update_Main_err
		
		'�����v�ɂ���
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		F_Update_Main = 9
		bolTran = False
		
		'�X�V���� �擾
		Call CF_Get_SysDt()

        '�g�����U�N�V�����̊J�n
        '2019/05/23 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/05/23 CHG END
        bolTran = True
		
		'���㌩�o�g�����̔r������
		With URKET52_HEAD_Inf.UDNTHA
			intRet = F_UDNTHA_Exicz(.DATNO, .FOPEID, .FCLTID, .WRTFSTTM, .WRTFSTDT, .OPEID, .CLTID, .WRTTM, .WRTDT, .UOPEID, .UCLTID, .UWRTTM, .UWRTDT)
			If intRet <> 0 Then
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG���e:���[���ōX�V���ł��B
				F_Update_Main = intRet
				GoTo F_Update_Main_err
			End If
		End With
		
		'����g�����̔r������
		For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
			With URKET52_HEAD_Inf.UDNTRA(intCnt)
				intRet = F_UDNTRA_Exicz(.DATNO, CShort(.LINNO), .FOPEID, .FCLTID, .WRTFSTTM, .WRTFSTDT, .OPEID, .CLTID, .WRTTM, .WRTDT, .UOPEID, .UCLTID, .UWRTTM, .UWRTDT)
				If intRet <> 0 Then
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG���e:���[���ōX�V���ł��B
					F_Update_Main = intRet
					GoTo F_Update_Main_err
				End If
			End With
		Next 
		
		'// V1.20�� ADD
		intRet = F_Chk_HAITA_JDNNO(pm_All)
		If intRet <> 0 Then
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG���e:���[���ōX�V���ł��B
			F_Update_Main = intRet
			GoTo F_Update_Main_err
		End If
		'// V1.20�� ADD
		
		'2009/10/05 ADD START RISE)MIYAJIMA
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			'�󒍌��o�g�����̔r������
			intRet = F_JDNTHA_Exicz()
			If intRet <> 0 Then
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG���e:���[���ōX�V���ł��B
				F_Update_Main = intRet
				GoTo F_Update_Main_err
			End If
			
			'�󒍃g�����̔r������
			intRet = F_JDNTRA_Exicz()
			If intRet <> 0 Then
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG���e:���[���ōX�V���ł��B
				F_Update_Main = intRet
				GoTo F_Update_Main_err
			End If
		End If
		'2009/10/05 ADD E.N.D RISE)MIYAJIMA
		
		'2009/09/30 ADD START RISE)MIYAJIMA
		'���������T�}���̔r������
		intRet = F_Chk_HAITA_NKSSMX(pm_All)
		If intRet <> 0 Then
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG���e:���[���ōX�V���ł��B
			F_Update_Main = intRet
			GoTo F_Update_Main_err
		End If
		'2009/09/30 ADD E.N.D RISE)MIYAJIMA
		
		'2009/09/24 ADD START RISE)MIYAJIMA
		'���܂������ǂ������f����
		intRet = AE_UpdateURI_Chk_AkaKro(URKET52_HEAD_Inf.NYUDT, URKET52_HEAD_Inf.UDNTHA.SMADT, URKET52_HEAD_Inf.UDNTHA.SSADT)
		If intRet = 0 Then
			bolAKAKRO = False
		Else
			bolAKAKRO = True
		End If
		'2009/09/24 ADD E.N.D RISE)MIYAJIMA
		
		'--------------------------------------------------------------------------------
		
		'2009/09/30 ADD START RISE)MIYAJIMA
		'���ϓ��������������Ă��邩���f����i�ύX�O�f�[�^�Ŕ��f�j
		Call F_Util_Tourai(pm_All)
		
		Select Case pv_intTouraiKbn
			Case 0
				
				If bolAKAKRO = False Then
					
					' --- �����x�� ---
					
					'���㌩�o�g���� �_���폜
					'UPGRADE_WARNING: �I�u�W�F�N�g F_UDNTHA_Update_DelF() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					intRet = F_UDNTHA_Update_DelF(pm_All, URKET52_HEAD_Inf.UDNTHA.DATNO, False)
					If intRet <> 0 Then
						F_Update_Main = intRet
						GoTo F_Update_Main_err
					End If
					
					'����g���� �_���폜
					'UPGRADE_WARNING: �I�u�W�F�N�g F_UDNTRA_Update_DelF() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					intRet = F_UDNTRA_Update_DelF(pm_All, URKET52_HEAD_Inf.UDNTHA.DATNO, False)
					If intRet <> 0 Then
						F_Update_Main = intRet
						GoTo F_Update_Main_err
					End If
					
					For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
						'���������Ώۃ{�^���Ŏ擾�����f�[�^���R�s�[
						'UPGRADE_WARNING: �I�u�W�F�N�g Tbl_Inf_UDNTRA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
						Tbl_Inf_UDNTRA.DATKB = gc_strDATKB_DEL
						
						'�T�}���t�@�C���Q�X�V
						intRet = F_UPDSMF(pm_All, intCnt, -1, Tbl_Inf_UDNTRA)
						If intRet <> 0 Then
							F_Update_Main = intRet
							GoTo F_Update_Main_err
						End If
					Next 
					
				Else
					
					' --- �O���x�ȑO ---
					
					'�V�����`�[�Ǘ������擾
					intRet = F_SYSTBA_SaibanDATNO(pm_All, strDATNO)
					If intRet <> 0 Then
						F_Update_Main = intRet
						GoTo F_Update_Main_err
					End If
					
					'�ԓ`�[�f�[�^��V�K�o�^����
					
					'���������Ώۃ{�^���Ŏ擾�����f�[�^���R�s�[���ĕύX���Ă���
					'UPGRADE_WARNING: �I�u�W�F�N�g Tbl_Inf_UDNTHA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Tbl_Inf_UDNTHA = URKET52_HEAD_Inf.UDNTHA
					With Tbl_Inf_UDNTHA
						.DATNO = strDATNO
						.AKAKROKB = gc_strAKAKROKB_AKA '�ԓ`�[
						.SBANYUKN = .SBANYUKN * -1 '�}�C�i�X�l
						.SBAFRNKN = .SBAFRNKN * -1 '�}�C�i�X�l
						.MOTDATNO = URKET52_HEAD_Inf.DATNO
						.UDNDT = URKET52_HEAD_Inf.NYUDT
						.SMADT = pv_strSMADT
						.SSADT = pv_strSSADT
						.KESDT = pv_strKESDT
						.FOPEID = SSS_OPEID.Value '����o�^���[�UID
						.FCLTID = SSS_CLTID.Value '����o�^�N���C�A���gID
						.WRTFSTTM = GV_SysTime '�^�C���X�^���v�i�o�^���ԁj
						.WRTFSTDT = GV_SysDate '�^�C���X�^���v�i�o�^���j
						.OPEID = SSS_OPEID.Value '�ŏI��Ǝ҃R�[�h
						.CLTID = SSS_CLTID.Value '�N���C�A���g�h�c
						.WRTTM = GV_SysTime '�^�C���X�^���v�i���ԁj
						.WRTDT = GV_SysDate '�^�C���X�^���v�i���t�j
						.UOPEID = SSS_OPEID.Value '���[�UID�i�o�b�`�j
						.UCLTID = SSS_CLTID.Value '�N���C�A���gID�i�o�b�`�j
						.UWRTTM = GV_SysTime '�^�C���X�^���v�i�o�b�`���ԁj
						.UWRTDT = GV_SysDate '�^�C���X�^���v�i�o�b�`���t�j
						.PGID = SSS_PrgId '�X�VPGID
						.DLFLG = gc_strDLFLG_UPD
					End With
					
					'���㌩�o�g�����V�K�o�^ (�ԓ`�[)
					intRet = F_UDNTHA_Insert(pm_All, Tbl_Inf_UDNTHA)
					If intRet <> 0 Then
						F_Update_Main = intRet
						GoTo F_Update_Main_err
					End If
					
					For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
						
						'�V�������R�[�h�Ǘ������擾
						intRet = F_SYSTBA_SaibanRECNO(pm_All, strRecNo)
						If intRet <> 0 Then
							F_Update_Main = intRet
							GoTo F_Update_Main_err
						End If
						
						'�ԓ`�[�f�[�^��V�K�o�^����
						
						'���������Ώۃ{�^���Ŏ擾�����f�[�^���R�s�[���ĕύX���Ă���
						'UPGRADE_WARNING: �I�u�W�F�N�g Tbl_Inf_UDNTRA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
						With Tbl_Inf_UDNTRA
							.DATNO = strDATNO
							.AKAKROKB = gc_strAKAKROKB_AKA '�ԓ`�[
							.RECNO = strRecNo
							.NYUKN = .NYUKN * -1 '�}�C�i�X�l
							.FNYUKN = .FNYUKN * -1 '�}�C�i�X�l
							
							'2009/06/05 ADD START FKS)NAKATA
							.OKRJONO = .OKRJONO
							'2009/06/05 ADD START FKS)NAKATA
							
							.MOTDATNO = URKET52_HEAD_Inf.DATNO
							.UDNDT = URKET52_HEAD_Inf.NYUDT
							.SMADT = pv_strSMADT
							.SSADT = pv_strSSADT
							.KESDT = pv_strKESDT
							.FOPEID = SSS_OPEID.Value '����o�^���[�UID
							.FCLTID = SSS_CLTID.Value '����o�^�N���C�A���gID
							.WRTFSTTM = GV_SysTime '�^�C���X�^���v�i�o�^���ԁj
							.WRTFSTDT = GV_SysDate '�^�C���X�^���v�i�o�^���j
							.OPEID = SSS_OPEID.Value '�ŏI��Ǝ҃R�[�h
							.CLTID = SSS_CLTID.Value '�N���C�A���g�h�c
							.WRTTM = GV_SysTime '�^�C���X�^���v�i���ԁj
							.WRTDT = GV_SysDate '�^�C���X�^���v�i���t�j
							.UOPEID = SSS_OPEID.Value '���[�UID�i�o�b�`�j
							.UCLTID = SSS_CLTID.Value '�N���C�A���gID�i�o�b�`�j
							.UWRTTM = GV_SysTime '�^�C���X�^���v�i�o�b�`���ԁj
							.UWRTDT = GV_SysDate '�^�C���X�^���v�i�o�b�`���t�j
							.PGID = SSS_PrgId '�X�VPGID
							.DLFLG = gc_strDLFLG_UPD
						End With
						
						'����g�����V�K�o�^ (�ԓ`�[)
						intRet = F_UDNTRA_Insert(pm_All, Tbl_Inf_UDNTRA)
						If intRet <> 0 Then
							F_Update_Main = intRet
							GoTo F_Update_Main_err
						End If
						
						With Tbl_Inf_UDNTRA '�T�}���X�V�����ōX�V�p�ϐ����g�p���Ă���ׁA���z���̕����𔽓]
							.NYUKN = .NYUKN * -1
							.FNYUKN = .FNYUKN * -1
						End With
						
						'�T�}���t�@�C���Q�X�V
						intRet = F_UPDSMF(pm_All, intCnt, -1, Tbl_Inf_UDNTRA)
						If intRet <> 0 Then
							F_Update_Main = intRet
							GoTo F_Update_Main_err
						End If
					Next 
				End If
				
			Case Else
				
				' --- �������� ---
				
				'�V�����`�[�Ǘ������擾
				intRet = F_SYSTBA_SaibanDATNO(pm_All, strDATNO)
				If intRet <> 0 Then
					F_Update_Main = intRet
					GoTo F_Update_Main_err
				End If
				
				'�ԓ`�[�f�[�^��V�K�o�^����
				
				'���������Ώۃ{�^���Ŏ擾�����f�[�^���R�s�[���ĕύX���Ă���
				'UPGRADE_WARNING: �I�u�W�F�N�g Tbl_Inf_UDNTHA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Tbl_Inf_UDNTHA = URKET52_HEAD_Inf.UDNTHA
				With Tbl_Inf_UDNTHA
					.DATNO = strDATNO
					.AKAKROKB = gc_strAKAKROKB_AKA '�ԓ`�[
					.SBANYUKN = .SBANYUKN * -1 '�}�C�i�X�l
					.SBAFRNKN = .SBAFRNKN * -1 '�}�C�i�X�l
					.MOTDATNO = URKET52_HEAD_Inf.DATNO
					.UDNDT = URKET52_HEAD_Inf.NYUDT
					.SMADT = pv_strSMADT
					.SSADT = pv_strSSADT
					.KESDT = pv_strKESDT
					.FOPEID = SSS_OPEID.Value '����o�^���[�UID
					.FCLTID = SSS_CLTID.Value '����o�^�N���C�A���gID
					.WRTFSTTM = GV_SysTime '�^�C���X�^���v�i�o�^���ԁj
					.WRTFSTDT = GV_SysDate '�^�C���X�^���v�i�o�^���j
					.OPEID = SSS_OPEID.Value '�ŏI��Ǝ҃R�[�h
					.CLTID = SSS_CLTID.Value '�N���C�A���g�h�c
					.WRTTM = GV_SysTime '�^�C���X�^���v�i���ԁj
					.WRTDT = GV_SysDate '�^�C���X�^���v�i���t�j
					.UOPEID = SSS_OPEID.Value '���[�UID�i�o�b�`�j
					.UCLTID = SSS_CLTID.Value '�N���C�A���gID�i�o�b�`�j
					.UWRTTM = GV_SysTime '�^�C���X�^���v�i�o�b�`���ԁj
					.UWRTDT = GV_SysDate '�^�C���X�^���v�i�o�b�`���t�j
					.PGID = SSS_PrgId '�X�VPGID
					.DLFLG = gc_strDLFLG_UPD
				End With
				
				'���㌩�o�g�����V�K�o�^ (�ԓ`�[)
				intRet = F_UDNTHA_Insert(pm_All, Tbl_Inf_UDNTHA)
				If intRet <> 0 Then
					F_Update_Main = intRet
					GoTo F_Update_Main_err
				End If
				
				For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
					
					'�V�������R�[�h�Ǘ������擾
					intRet = F_SYSTBA_SaibanRECNO(pm_All, strRecNo)
					If intRet <> 0 Then
						F_Update_Main = intRet
						GoTo F_Update_Main_err
					End If
					
					'�ԓ`�[�f�[�^��V�K�o�^����
					
					If URKET52_HEAD_Inf.TEGKB(intCnt) = 0 Then
						
						'���������Ώۃ{�^���Ŏ擾�����f�[�^���R�s�[���ĕύX���Ă���
						'UPGRADE_WARNING: �I�u�W�F�N�g Tbl_Inf_UDNTRA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
						With Tbl_Inf_UDNTRA
							.DATNO = strDATNO
							.AKAKROKB = gc_strAKAKROKB_AKA '�ԓ`�[
							.RECNO = strRecNo
							.NYUKN = .NYUKN * -1 '�}�C�i�X�l
							.FNYUKN = .FNYUKN * -1 '�}�C�i�X�l
							
							'2009/06/05 ADD START FKS)NAKATA
							.OKRJONO = .OKRJONO
							'2009/06/05 ADD START FKS)NAKATA
							
							.MOTDATNO = URKET52_HEAD_Inf.DATNO
							.UDNDT = URKET52_HEAD_Inf.NYUDT
							.SMADT = pv_strSMADT
							.SSADT = pv_strSSADT
							.KESDT = pv_strKESDT
							.FOPEID = SSS_OPEID.Value '����o�^���[�UID
							.FCLTID = SSS_CLTID.Value '����o�^�N���C�A���gID
							.WRTFSTTM = GV_SysTime '�^�C���X�^���v�i�o�^���ԁj
							.WRTFSTDT = GV_SysDate '�^�C���X�^���v�i�o�^���j
							.OPEID = SSS_OPEID.Value '�ŏI��Ǝ҃R�[�h
							.CLTID = SSS_CLTID.Value '�N���C�A���g�h�c
							.WRTTM = GV_SysTime '�^�C���X�^���v�i���ԁj
							.WRTDT = GV_SysDate '�^�C���X�^���v�i���t�j
							.UOPEID = SSS_OPEID.Value '���[�UID�i�o�b�`�j
							.UCLTID = SSS_CLTID.Value '�N���C�A���gID�i�o�b�`�j
							.UWRTTM = GV_SysTime '�^�C���X�^���v�i�o�b�`���ԁj
							.UWRTDT = GV_SysDate '�^�C���X�^���v�i�o�b�`���t�j
							.PGID = SSS_PrgId '�X�VPGID
							.DLFLG = gc_strDLFLG_UPD
						End With
						
						'����g�����V�K�o�^ (�ԓ`�[)
						intRet = F_UDNTRA_Insert(pm_All, Tbl_Inf_UDNTRA)
						If intRet <> 0 Then
							F_Update_Main = intRet
							GoTo F_Update_Main_err
						End If
						
						With Tbl_Inf_UDNTRA '�T�}���X�V�����ōX�V�p�ϐ����g�p���Ă���ׁA���z���̕����𔽓]
							.NYUKN = .NYUKN * -1
							.FNYUKN = .FNYUKN * -1
						End With
						
						'�T�}���t�@�C���Q�X�V
						intRet = F_UPDSMF(pm_All, intCnt, -1, Tbl_Inf_UDNTRA)
						If intRet <> 0 Then
							F_Update_Main = intRet
							GoTo F_Update_Main_err
						End If
						
					Else
						
						'UPGRADE_WARNING: �I�u�W�F�N�g Tbl_Inf_UDNTRA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
						With Tbl_Inf_UDNTRA
							.NYUKN = .NYUKN * -1 '�}�C�i�X�l
							.FNYUKN = .FNYUKN * -1 '�}�C�i�X�l
						End With
						
						'��ʂɊi�[����Ă���ꏊ������
						'UPGRADE_WARNING: �I�u�W�F�N�g F_Get_DspIndex() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						int_DspIndex = F_Get_DspIndex(pm_All, Tbl_Inf_UDNTRA.DATNO, Tbl_Inf_UDNTRA.LINNO)
						
						'�`�[���́A�o�^�ς݂̂��̂��g��
						strDenNo = URKET52_HEAD_Inf.UDNTHA.UDNNO
						
						'����g�����o�^�f�[�^�쐬
						intRet = F_UDNTRA_MakeInf_Tourai(pm_All, int_DspIndex, strDATNO, strDenNo, strRecNo, Tbl_Inf_UDNTRA)
						If intRet <> 0 Then
							F_Update_Main = intRet
							GoTo F_Update_Main_err
						End If
						
						'����g�����V�K�o�^ (�ԓ`�[)
						intRet = F_UDNTRA_Insert(pm_All, Tbl_Inf_UDNTRA)
						If intRet <> 0 Then
							F_Update_Main = intRet
							GoTo F_Update_Main_err
						End If
						
						With Tbl_Inf_UDNTRA '�T�}���X�V�����ōX�V�p�ϐ����g�p���Ă���ׁA���z���̕����𔽓]
							.NYUKN = .NYUKN * -1
							.FNYUKN = .FNYUKN * -1
						End With
						
						'�T�}���t�@�C���Q�X�V
						intRet = F_UPDSMF2(pm_All, intCnt, -1, Tbl_Inf_UDNTRA, URKET52_HEAD_Inf.UDNTRA(intCnt).DKBID, URKET52_HEAD_Inf.DKBID(intCnt), URKET52_HEAD_Inf.TEGKB(intCnt))
						If intRet <> 0 Then
							F_Update_Main = intRet
							GoTo F_Update_Main_err
						End If
						
					End If
					
				Next 
				
		End Select
		'2009/09/30 ADD E.N.D RISE)MIYAJIMA
		
		'2009/09/30 DEL START RISE)MIYAJIMA
		''2009/09/24 UPD START RISE)MIYAJIMA
		''    If URKET52_HEAD_Inf.UDNTHA.SMADT > pv_strMONUPDDT Then
		'    If bolAKAKRO = False Then
		'        '�����x��
		''2009/09/24 UPD E.N.D RISE)MIYAJIMA
		'
		'        '���㌩�o�g���� �_���폜
		'        intRet = F_UDNTHA_Update_DelF(pm_All, URKET52_HEAD_Inf.UDNTHA.DATNO, False)
		'        If intRet <> 0 Then
		'            F_Update_Main = intRet
		'            GoTo F_Update_Main_err
		'        End If
		'
		'        '����g���� �_���폜
		'        intRet = F_UDNTRA_Update_DelF(pm_All, URKET52_HEAD_Inf.UDNTHA.DATNO, False)
		'        If intRet <> 0 Then
		'            F_Update_Main = intRet
		'            GoTo F_Update_Main_err
		'        End If
		'
		'        For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
		'            '���������Ώۃ{�^���Ŏ擾�����f�[�^���R�s�[
		'            Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
		'            Tbl_Inf_UDNTRA.DATKB = gc_strDATKB_DEL
		'
		'            '�T�}���t�@�C���Q�X�V
		'            intRet = F_UPDSMF(pm_All, intCnt, -1, Tbl_Inf_UDNTRA)
		'            If intRet <> 0 Then
		'                F_Update_Main = intRet
		'                GoTo F_Update_Main_err
		'            End If
		'        Next
		'    Else
		'
		'        '�O���x
		'
		'        '�V�����`�[�Ǘ������擾
		'        intRet = F_SYSTBA_SaibanDATNO(pm_All, strDATNO)
		'        If intRet <> 0 Then
		'            F_Update_Main = intRet
		'            GoTo F_Update_Main_err
		'        End If
		'
		'        '�ԓ`�[�f�[�^��V�K�o�^����
		'
		'        '���������Ώۃ{�^���Ŏ擾�����f�[�^���R�s�[���ĕύX���Ă���
		'        Tbl_Inf_UDNTHA = URKET52_HEAD_Inf.UDNTHA
		'        With Tbl_Inf_UDNTHA
		'            .DATNO = strDATNO
		'            .AKAKROKB = gc_strAKAKROKB_AKA      '�ԓ`�[
		'            .SBANYUKN = .SBANYUKN * -1          '�}�C�i�X�l
		'            .SBAFRNKN = .SBAFRNKN * -1          '�}�C�i�X�l
		'            .MOTDATNO = URKET52_HEAD_Inf.DATNO
		'            .UDNDT = URKET52_HEAD_Inf.NYUDT
		'            .SMADT = pv_strSMADT
		'            .SSADT = pv_strSSADT
		'            .KESDT = pv_strKESDT
		'            .FOPEID = SSS_OPEID         '����o�^���[�UID
		'            .FCLTID = SSS_CLTID         '����o�^�N���C�A���gID
		'            .WRTFSTTM = GV_SysTime      '�^�C���X�^���v�i�o�^���ԁj
		'            .WRTFSTDT = GV_SysDate      '�^�C���X�^���v�i�o�^���j
		'            .OPEID = SSS_OPEID          '�ŏI��Ǝ҃R�[�h
		'            .CLTID = SSS_CLTID          '�N���C�A���g�h�c
		'            .WRTTM = GV_SysTime         '�^�C���X�^���v�i���ԁj
		'            .WRTDT = GV_SysDate         '�^�C���X�^���v�i���t�j
		'            .UOPEID = SSS_OPEID         '���[�UID�i�o�b�`�j
		'            .UCLTID = SSS_CLTID         '�N���C�A���gID�i�o�b�`�j
		'            .UWRTTM = GV_SysTime        '�^�C���X�^���v�i�o�b�`���ԁj
		'            .UWRTDT = GV_SysDate        '�^�C���X�^���v�i�o�b�`���t�j
		'            .PGID = SSS_PrgId           '�X�VPGID
		'            .DLFLG = gc_strDLFLG_UPD
		'        End With
		'
		'        '���㌩�o�g�����V�K�o�^ (�ԓ`�[)
		'        intRet = F_UDNTHA_Insert(pm_All, Tbl_Inf_UDNTHA)
		'        If intRet <> 0 Then
		'            F_Update_Main = intRet
		'            GoTo F_Update_Main_err
		'        End If
		'
		'        For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
		'
		'            '�V�������R�[�h�Ǘ������擾
		'            intRet = F_SYSTBA_SaibanRECNO(pm_All, strRecNo)
		'            If intRet <> 0 Then
		'                F_Update_Main = intRet
		'                GoTo F_Update_Main_err
		'            End If
		'
		'            '�ԓ`�[�f�[�^��V�K�o�^����
		'
		'            '���������Ώۃ{�^���Ŏ擾�����f�[�^���R�s�[���ĕύX���Ă���
		'            Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
		'            With Tbl_Inf_UDNTRA
		'                .DATNO = strDATNO
		'                .AKAKROKB = gc_strAKAKROKB_AKA      '�ԓ`�[
		'                .RECNO = strRecNo
		'                .NYUKN = .NYUKN * -1                '�}�C�i�X�l
		'                .FNYUKN = .FNYUKN * -1              '�}�C�i�X�l
		'
		'                '2009/06/05 ADD START FKS)NAKATA
		'                .OKRJONO = .OKRJONO
		'                '2009/06/05 ADD START FKS)NAKATA
		'
		'                .MOTDATNO = URKET52_HEAD_Inf.DATNO
		'                .UDNDT = URKET52_HEAD_Inf.NYUDT
		'                .SMADT = pv_strSMADT
		'                .SSADT = pv_strSSADT
		'                .KESDT = pv_strKESDT
		'                .FOPEID = SSS_OPEID         '����o�^���[�UID
		'                .FCLTID = SSS_CLTID         '����o�^�N���C�A���gID
		'                .WRTFSTTM = GV_SysTime      '�^�C���X�^���v�i�o�^���ԁj
		'                .WRTFSTDT = GV_SysDate      '�^�C���X�^���v�i�o�^���j
		'                .OPEID = SSS_OPEID          '�ŏI��Ǝ҃R�[�h
		'                .CLTID = SSS_CLTID          '�N���C�A���g�h�c
		'                .WRTTM = GV_SysTime         '�^�C���X�^���v�i���ԁj
		'                .WRTDT = GV_SysDate         '�^�C���X�^���v�i���t�j
		'                .UOPEID = SSS_OPEID         '���[�UID�i�o�b�`�j
		'                .UCLTID = SSS_CLTID         '�N���C�A���gID�i�o�b�`�j
		'                .UWRTTM = GV_SysTime        '�^�C���X�^���v�i�o�b�`���ԁj
		'                .UWRTDT = GV_SysDate        '�^�C���X�^���v�i�o�b�`���t�j
		'                .PGID = SSS_PrgId           '�X�VPGID
		'                .DLFLG = gc_strDLFLG_UPD
		'            End With
		'
		'            '����g�����V�K�o�^ (�ԓ`�[)
		'            intRet = F_UDNTRA_Insert(pm_All, Tbl_Inf_UDNTRA)
		'            If intRet <> 0 Then
		'                F_Update_Main = intRet
		'                GoTo F_Update_Main_err
		'            End If
		'
		'            With Tbl_Inf_UDNTRA '�T�}���X�V�����ōX�V�p�ϐ����g�p���Ă���ׁA���z���̕����𔽓]
		'                .NYUKN = .NYUKN * -1
		'                .FNYUKN = .FNYUKN * -1
		'            End With
		'
		'            '�T�}���t�@�C���Q�X�V
		'            intRet = F_UPDSMF(pm_All, intCnt, -1, Tbl_Inf_UDNTRA)
		'            If intRet <> 0 Then
		'                F_Update_Main = intRet
		'                GoTo F_Update_Main_err
		'            End If
		'        Next
		'    End If
		'2009/09/30 DEL E.N.D RISE)MIYAJIMA
		
		'--------------------------------------------------------------------------------
		
		'�V�����`�[�Ǘ������擾
		intRet = F_SYSTBA_SaibanDATNO(pm_All, strDATNO)
		If intRet <> 0 Then
			F_Update_Main = intRet
			GoTo F_Update_Main_err
		End If
		
		'�`�[���́A�o�^�ς݂̂��̂��g��
		strDenNo = URKET52_HEAD_Inf.UDNTHA.UDNNO
		
		
		'���㌩�o�g�����o�^�f�[�^�쐬
		intRet = F_UDNTHA_MakeInf(pm_All, strDATNO, strDenNo, Tbl_Inf_UDNTHA)
		If intRet <> 0 Then
			F_Update_Main = intRet
			GoTo F_Update_Main_err
		End If
		
		'���㌩�o�g�����V�K�o�^
		intRet = F_UDNTHA_Insert(pm_All, Tbl_Inf_UDNTHA)
		If intRet <> 0 Then
			F_Update_Main = intRet
			GoTo F_Update_Main_err
		End If
		
		'����`�폜 (�T�}���t�@�C���Q�X�V���ɓo�^)
		intRet = F_UTGTRA_Delete(pm_All, strDenNo)
		If intRet <> 0 Then
			F_Update_Main = intRet
			GoTo F_Update_Main_err
		End If
		
		For intCnt = 1 To pv_intMeisaiCnt
			
			'�V�������R�[�h�Ǘ������擾
			intRet = F_SYSTBA_SaibanRECNO(pm_All, strRecNo)
			If intRet <> 0 Then
				F_Update_Main = intRet
				GoTo F_Update_Main_err
			End If
			
			'����g�����o�^�f�[�^�쐬
			intRet = F_UDNTRA_MakeInf(pm_All, intCnt, strDATNO, strDenNo, strRecNo, Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_Update_Main = intRet
				GoTo F_Update_Main_err
			End If
			
			'����g�����V�K�o�^
			intRet = F_UDNTRA_Insert(pm_All, Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_Update_Main = intRet
				GoTo F_Update_Main_err
			End If
			
			'�T�}���t�@�C���Q�X�V
			intRet = F_UPDSMF(pm_All, intCnt, 1, Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_Update_Main = intRet
				GoTo F_Update_Main_err
			End If
			
			'�X�V�����F�`�[�敪���W ���� ��`�����t���O���P
			If Tbl_Inf_UDNTRA.DENKB = "8" And Tbl_Inf_UDNTRA.DKBTEGFL = "1" Then
				'����`�g�����̍X�V
				intRet = F_UTGTRA(pm_All, Tbl_Inf_UDNTRA)
				If intRet <> 0 Then
					F_Update_Main = intRet
					GoTo F_Update_Main_err
				End If
			End If
		Next intCnt
		
		'2009/10/05 ADD START RISE)MIYAJIMA
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			'�󒍌��o�g���� �^�C���X�^���v�X�V
			'UPGRADE_WARNING: �I�u�W�F�N�g F_JDNTHA_Upd_TimeStamp() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			intRet = F_JDNTHA_Upd_TimeStamp(pm_All)
			If intRet <> 0 Then
				F_Update_Main = intRet
				GoTo F_Update_Main_err
			End If
			
			'�󒍃g���� �@�@�^�C���X�^���v�X�V
			'UPGRADE_WARNING: �I�u�W�F�N�g F_JDNTRA_Upd_TimeStamp() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			intRet = F_JDNTRA_Upd_TimeStamp(pm_All)
			If intRet <> 0 Then
				F_Update_Main = intRet
				GoTo F_Update_Main_err
			End If
		End If
        '2009/10/05 ADD E.N.D RISE)MIYAJIMA

        '�R�~�b�g
        '2019/05/23 CHG START
        'Call CF_Ora_CommitTrans(gv_Oss_USR1)
        Call DB_Commit()
        '2019/05/23 CHG END
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
            '2019/05/23 CHG START
            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
            Call DB_Rollback()
            '2019/05/23 CHG END
        End If
		
		GoTo F_Update_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_UpdDel_Process
	'   �T�v�F  �폜���C�����[�`��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@0 :�X�V�I���@9:�X�V�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_UpdDel_Process(ByRef pm_All As Cls_All) As Short
		Dim intRet As Short
		Dim Index_Wk As Short
		
		On Error GoTo Err_F_Ctl_UpdDel_Process
		
		F_Ctl_UpdDel_Process = 9
		
		If gv_bolDelFlg = True Then
			Exit Function
		End If
		
		gv_bolDelFlg = True
		
		'�����v�ɂ���
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'�A�N�e�B�u�R���g���[���̂k�e����
		If CF_Ctl_Item_LostFocus_Dummy(pm_All) <> CHK_OK Then
			'�`�F�b�NNG�̏ꍇ
			GoTo End_F_Ctl_UpdDel_Process
		End If
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		
		'���������Ώۂ̃`�F�b�N
		If Trim(URKET52_HEAD_Inf.DATNO) = "" Then
			'�`�F�b�N�m�f�̏ꍇ
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_024, pm_All)
			
			Index_Wk = CShort(FR_SSSMAIN.HD_DATNO.Tag)
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
			
			GoTo End_F_Ctl_UpdDel_Process
		End If
		
		'�������̃`�F�b�N
		If URKET52_HEAD_Inf.NYUDT > GV_UNYDate Then
			'�`�F�b�N�m�f�̏ꍇ
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_015, pm_All)
			
			Index_Wk = CShort(FR_SSSMAIN.HD_NYUDT.Tag)
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
			
			GoTo End_F_Ctl_UpdDel_Process
		Else
			'''' UPD 2011/01/14  FKS) T.Yamamoto    Start    �A���[��FC11011401
			'�����{�����̏����P�p
			'        '�O�񌎎��X�V���s�����ߋ��̓G���[
			'        If Trim(URKET52_HEAD_Inf.NYUDT) <= Trim(pv_strMONUPDDT) Then
			'�O��o�������s�����ߋ��̓G���[
			If Trim(URKET52_HEAD_Inf.NYUDT) <= Trim(pv_strSMAUPDDT) Then
				'''' UPD 2011/01/14  FKS) T.Yamamoto    End
				'�`�F�b�N�m�f�̏ꍇ
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_016, pm_All)
				
				Index_Wk = CShort(FR_SSSMAIN.HD_NYUDT.Tag)
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				
				GoTo End_F_Ctl_UpdDel_Process
			End If
		End If
		
		'2009/10/05 ADD START RISE)MIYAJIMA
		'�󒍂̔r�����擾�@�i�������A�O��̂݁j
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			Call F_Get_JDN_HAITA(pm_All)
		End If
		'2009/10/05 ADD E.N.D RISE)MIYAJIMA
		
		'*** 2009/09/07 ADD START FKS)NAKATA
		'�����̃`�F�b�N�@�i�������A�O��̂݁j
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			
			intRet = F_Chk_KESIZUMI(pm_All)
			If intRet <> CHK_OK Then
				'�`�F�b�N�m�f�̏ꍇ
				GoTo End_F_Ctl_UpdDel_Process
			End If
		End If
		'*** 2009/09/07 ADD E.N.D FKS)NAKATA
		
		'2009/09/29 DEL START RISE)MIYAJIMA
		''2009/09/24 ADD START RISE)MIYAJIMA
		'    '�ύX���z����`�F�b�N
		'    If F_Util_CheckSumOver(pm_All, 9) <> 0 Then
		'        '���b�Z�[�W�o��
		'        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_029, pm_All)
		'        '�`�F�b�N�m�f�̏ꍇ
		'        GoTo End_F_Ctl_UpdDel_Process
		'    End If
		''2009/09/24 ADD E.N.D RISE)MIYAJIMA
		'2009/09/29 DEL E.N.D RISE)MIYAJIMA
		
		'2009/10/05 ADD START RISE)MIYAJIMA
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			intRet = F_Chk_EXIST_MotoJDNNO(pm_All)
			If intRet <> 0 Then
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_038, pm_All) ' MSG���e:�֘A�����󒍂��������Ă���ׁA�X�V�ł��܂���B
				GoTo End_F_Ctl_UpdDel_Process
			End If
		End If
		'2009/10/05 ADD E.N.D RISE)MIYAJIMA
		
		'�}�E�X�|�C���^��߂�
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		gv_bolURKET52_LF_Enable = False
		
		'Windows�ɏ�����Ԃ�
		System.Windows.Forms.Application.DoEvents()
		
		gv_bolURKET52_LF_Enable = True
		
		'�󒍓o�^�̌������Ȃ��ꍇ�͏������s��Ȃ�
		If Inp_Inf.InpJDNUPDKB <> gc_strJDNUPDKB_OK Then
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_003, pm_All)
			GoTo End_F_Ctl_UpdDel_Process
		End If
		
		'�o�������t�A�����t�A���ϓ��t �擾
		intRet = F_Util_Get_Simebi(URKET52_HEAD_Inf.NYUDT, URKET52_HEAD_Inf.TOKCD, pv_strSMADT, pv_strSSADT, pv_strKESDT)
		If intRet <> 0 Then
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_027, pm_All)
			GoTo End_F_Ctl_UpdDel_Process
		End If
		
		'2009/09/30 ADD START RISE)MIYAJIMA
		'�����T�}���D���������z�c ���擾
		intRet = F_Util_CheckSumOver_GetZANKN(pm_All)
		If intRet <> 0 Then
			GoTo End_F_Ctl_UpdDel_Process
		End If
		'2009/09/30 ADD E.N.D RISE)MIYAJIMA
		
		'2009/09/29 ADD START RISE)MIYAJIMA
		'�ύX���z����`�F�b�N
		If F_Util_CheckSumOver(pm_All, 9) <> 0 Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_029, pm_All)
			'�`�F�b�N�m�f�̏ꍇ
			GoTo End_F_Ctl_UpdDel_Process
		End If
		'2009/09/29 ADD E.N.D RISE)MIYAJIMA
		
		'�폜�m�F
		If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_A_028, pm_All) = MsgBoxResult.No Then
			GoTo End_F_Ctl_UpdDel_Process
		End If
		
		'����̫����ʒu�ݒ�
		Call F_Init_Cursor_Set(pm_All)

        '�{�^����\��
        'delete start 20190828 kuwa
        'FR_SSSMAIN.CM_Execute.Visible = False
        'delete end 20190828 kuwa

        '�폜����
        intRet = F_UpdateDel_Main(pm_All)
		If intRet <> 0 Then
			F_Ctl_UpdDel_Process = intRet
			GoTo Err_F_Ctl_UpdDel_Process
		End If
		
		'�폜����
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_A_006, pm_All)
		
		F_Ctl_UpdDel_Process = 0
		
End_F_Ctl_UpdDel_Process: 
		'�}�E�X�|�C���^��߂�
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '�{�^���\��
        'delete start 20190828 kuwa
        'FR_SSSMAIN.CM_Execute.Visible = True
        'delete end 20190828 kuwa
        gv_bolDelFlg = False
		
		'�L�[�t���O�����ɖ߂�
		gv_bolKeyFlg = False
		Exit Function
		
Err_F_Ctl_UpdDel_Process: 
		GoTo End_F_Ctl_UpdDel_Process
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_UpdateDel_Main
	'   �T�v�F  �폜���C������
	'   �����F  pm_All        : ��ʏ��
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_UpdateDel_Main(ByRef pm_All As Cls_All) As Short
		Dim intRet As Short
		Dim strDATNO As String '�`�[�Ǘ���
		Dim strDenNo As String '�`�[��
		Dim strRecNo As String '���R�[�h�Ǘ���
		Dim intCnt As Short
		Dim bolTran As Boolean
		
		Dim Tbl_Inf_UDNTHA As TYPE_DB_UDNTHA
		Dim Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA
		
		'2009/09/24 ADD START RISE)MIYAJIMA
		Dim bolAKAKRO As Boolean
		Dim strSMADT_Rec As String
		Dim strSSADT_Rec As String
		Dim strKESDT_Rec As String
		'2009/09/24 ADD E.N.D RISE)MIYAJIMA
		
		On Error GoTo F_UpdateDel_Main_err
		
		'�����v�ɂ���
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		F_UpdateDel_Main = 9
		bolTran = False
		
		'�X�V���� �擾
		Call CF_Get_SysDt()

        '�g�����U�N�V�����̊J�n
        '2019/05/23 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/05/23 CHG END
        bolTran = True
		
		'���㌩�o�g�����̔r������
		With URKET52_HEAD_Inf.UDNTHA
			intRet = F_UDNTHA_Exicz(.DATNO, .FOPEID, .FCLTID, .WRTFSTTM, .WRTFSTDT, .OPEID, .CLTID, .WRTTM, .WRTDT, .UOPEID, .UCLTID, .UWRTTM, .UWRTDT)
			If intRet <> 0 Then
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG���e:���[���ōX�V���ł��B
				F_UpdateDel_Main = intRet
				GoTo F_UpdateDel_Main_err
			End If
		End With
		
		'����g�����̔r������
		For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
			With URKET52_HEAD_Inf.UDNTRA(intCnt)
				intRet = F_UDNTRA_Exicz(.DATNO, CShort(.LINNO), .FOPEID, .FCLTID, .WRTFSTTM, .WRTFSTDT, .OPEID, .CLTID, .WRTTM, .WRTDT, .UOPEID, .UCLTID, .UWRTTM, .UWRTDT)
				If intRet <> 0 Then
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG���e:���[���ōX�V���ł��B
					F_UpdateDel_Main = intRet
					GoTo F_UpdateDel_Main_err
				End If
			End With
		Next 
		
		'2009/10/05 ADD START RISE)MIYAJIMA
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			'�󒍌��o�g�����̔r������
			intRet = F_JDNTHA_Exicz()
			If intRet <> 0 Then
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG���e:���[���ōX�V���ł��B
				F_UpdateDel_Main = intRet
				GoTo F_UpdateDel_Main_err
			End If
			
			'�󒍃g�����̔r������
			intRet = F_JDNTRA_Exicz()
			If intRet <> 0 Then
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG���e:���[���ōX�V���ł��B
				F_UpdateDel_Main = intRet
				GoTo F_UpdateDel_Main_err
			End If
		End If
		'2009/10/05 ADD E.N.D RISE)MIYAJIMA
		
		'2009/09/24 ADD START RISE)MIYAJIMA
		'���܂������ǂ������f����
		intRet = AE_UpdateURI_Chk_AkaKro(URKET52_HEAD_Inf.NYUDT, URKET52_HEAD_Inf.UDNTHA.SMADT, URKET52_HEAD_Inf.UDNTHA.SSADT)
		If intRet = 0 Then
			bolAKAKRO = False
		Else
			bolAKAKRO = True
		End If
		'2009/09/24 ADD E.N.D RISE)MIYAJIMA
		
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    If URKET52_HEAD_Inf.UDNTHA.SMADT > pv_strMONUPDDT Then
		If bolAKAKRO = False Then
			'2009/09/24 UPD E.N.D RISE)MIYAJIMA
			'�����x��
			
			'���㌩�o�g���� �_���폜
			'UPGRADE_WARNING: �I�u�W�F�N�g F_UDNTHA_Update_DelF() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			intRet = F_UDNTHA_Update_DelF(pm_All, URKET52_HEAD_Inf.UDNTHA.DATNO, True)
			If intRet <> 0 Then
				F_UpdateDel_Main = intRet
				GoTo F_UpdateDel_Main_err
			End If
			
			'����g���� �_���폜
			'UPGRADE_WARNING: �I�u�W�F�N�g F_UDNTRA_Update_DelF() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			intRet = F_UDNTRA_Update_DelF(pm_All, URKET52_HEAD_Inf.UDNTHA.DATNO, True)
			If intRet <> 0 Then
				F_UpdateDel_Main = intRet
				GoTo F_UpdateDel_Main_err
			End If
			
			For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
				'���������Ώۃ{�^���Ŏ擾�����f�[�^���R�s�[
				'UPGRADE_WARNING: �I�u�W�F�N�g Tbl_Inf_UDNTRA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
				Tbl_Inf_UDNTRA.DATKB = gc_strDATKB_DEL
				
				'�T�}���t�@�C���Q�X�V
				intRet = F_UPDSMF(pm_All, intCnt, -1, Tbl_Inf_UDNTRA)
				If intRet <> 0 Then
					F_UpdateDel_Main = intRet
					GoTo F_UpdateDel_Main_err
				End If
			Next 
		Else
			'�O���x
			
			'�V�����`�[�Ǘ������擾
			intRet = F_SYSTBA_SaibanDATNO(pm_All, strDATNO)
			If intRet <> 0 Then
				F_UpdateDel_Main = intRet
				GoTo F_UpdateDel_Main_err
			End If
			
			'�ԓ`�[�f�[�^��V�K�o�^����
			
			'���������Ώۃ{�^���Ŏ擾�����f�[�^���R�s�[���ĕύX���Ă���
			'UPGRADE_WARNING: �I�u�W�F�N�g Tbl_Inf_UDNTHA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Tbl_Inf_UDNTHA = URKET52_HEAD_Inf.UDNTHA
			With Tbl_Inf_UDNTHA
				.DATNO = strDATNO
				.AKAKROKB = gc_strAKAKROKB_AKA '�ԓ`�[
				.SBANYUKN = .SBANYUKN * -1 '�}�C�i�X�l
				.SBAFRNKN = .SBAFRNKN * -1 '�}�C�i�X�l
				.MOTDATNO = URKET52_HEAD_Inf.DATNO
				.UDNDT = URKET52_HEAD_Inf.NYUDT
				.SMADT = pv_strSMADT
				.SSADT = pv_strSSADT
				.KESDT = pv_strKESDT
				.FOPEID = SSS_OPEID.Value '����o�^���[�UID
				.FCLTID = SSS_CLTID.Value '����o�^�N���C�A���gID
				.WRTFSTTM = GV_SysTime '�^�C���X�^���v�i�o�^���ԁj
				.WRTFSTDT = GV_SysDate '�^�C���X�^���v�i�o�^���j
				.OPEID = SSS_OPEID.Value '�ŏI��Ǝ҃R�[�h
				.CLTID = SSS_CLTID.Value '�N���C�A���g�h�c
				.WRTTM = GV_SysTime '�^�C���X�^���v�i���ԁj
				.WRTDT = GV_SysDate '�^�C���X�^���v�i���t�j
				.UOPEID = SSS_OPEID.Value '���[�UID�i�o�b�`�j
				.UCLTID = SSS_CLTID.Value '�N���C�A���gID�i�o�b�`�j
				.UWRTTM = GV_SysTime '�^�C���X�^���v�i�o�b�`���ԁj
				.UWRTDT = GV_SysDate '�^�C���X�^���v�i�o�b�`���t�j
				.PGID = SSS_PrgId '�X�VPGID
				.DLFLG = gc_strDLFLG_UPD
			End With
			
			'���㌩�o�g�����V�K�o�^ (�ԓ`�[)
			intRet = F_UDNTHA_Insert(pm_All, Tbl_Inf_UDNTHA)
			If intRet <> 0 Then
				F_UpdateDel_Main = intRet
				GoTo F_UpdateDel_Main_err
			End If
			
			For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
				
				'�V�������R�[�h�Ǘ������擾
				intRet = F_SYSTBA_SaibanRECNO(pm_All, strRecNo)
				If intRet <> 0 Then
					F_UpdateDel_Main = intRet
					GoTo F_UpdateDel_Main_err
				End If
				
				'�ԓ`�[�f�[�^��V�K�o�^����
				
				'���������Ώۃ{�^���Ŏ擾�����f�[�^���R�s�[���ĕύX���Ă���
				'UPGRADE_WARNING: �I�u�W�F�N�g Tbl_Inf_UDNTRA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
				With Tbl_Inf_UDNTRA
					.DATNO = strDATNO
					.AKAKROKB = gc_strAKAKROKB_AKA '�ԓ`�[
					.RECNO = strRecNo
					.NYUKN = .NYUKN * -1 '�}�C�i�X�l
					.FNYUKN = .FNYUKN * -1 '�}�C�i�X�l
					
					'2009/06/05 ADD START FKS)NAKATA
					.OKRJONO = .OKRJONO
					'2009/06/05 ADD E.N.D FKS)NAKATA
					
					.MOTDATNO = URKET52_HEAD_Inf.DATNO
					.UDNDT = URKET52_HEAD_Inf.NYUDT
					.SMADT = pv_strSMADT
					.SSADT = pv_strSSADT
					.KESDT = pv_strKESDT
					.FOPEID = SSS_OPEID.Value '����o�^���[�UID
					.FCLTID = SSS_CLTID.Value '����o�^�N���C�A���gID
					.WRTFSTTM = GV_SysTime '�^�C���X�^���v�i�o�^���ԁj
					.WRTFSTDT = GV_SysDate '�^�C���X�^���v�i�o�^���j
					.OPEID = SSS_OPEID.Value '�ŏI��Ǝ҃R�[�h
					.CLTID = SSS_CLTID.Value '�N���C�A���g�h�c
					.WRTTM = GV_SysTime '�^�C���X�^���v�i���ԁj
					.WRTDT = GV_SysDate '�^�C���X�^���v�i���t�j
					.UOPEID = SSS_OPEID.Value '���[�UID�i�o�b�`�j
					.UCLTID = SSS_CLTID.Value '�N���C�A���gID�i�o�b�`�j
					.UWRTTM = GV_SysTime '�^�C���X�^���v�i�o�b�`���ԁj
					.UWRTDT = GV_SysDate '�^�C���X�^���v�i�o�b�`���t�j
					.PGID = SSS_PrgId '�X�VPGID
					.DLFLG = gc_strDLFLG_UPD
				End With
				
				'����g�����V�K�o�^ (�ԓ`�[)
				intRet = F_UDNTRA_Insert(pm_All, Tbl_Inf_UDNTRA)
				If intRet <> 0 Then
					F_UpdateDel_Main = intRet
					GoTo F_UpdateDel_Main_err
				End If
				
				With Tbl_Inf_UDNTRA '�T�}���X�V�����ōX�V�p�ϐ����g�p���Ă���ׁA���z���̕����𔽓]
					.NYUKN = .NYUKN * -1
					.FNYUKN = .FNYUKN * -1
				End With
				
				'�T�}���t�@�C���Q�X�V
				intRet = F_UPDSMF(pm_All, intCnt, -1, Tbl_Inf_UDNTRA)
				If intRet <> 0 Then
					F_UpdateDel_Main = intRet
					GoTo F_UpdateDel_Main_err
				End If
			Next 
		End If
		
		'����`�폜
		intRet = F_UTGTRA_Delete(pm_All, URKET52_HEAD_Inf.UDNTHA.UDNNO)
		If intRet <> 0 Then
			F_UpdateDel_Main = intRet
			GoTo F_UpdateDel_Main_err
		End If
		
		'2009/10/05 ADD START RISE)MIYAJIMA
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			'�󒍌��o�g���� �^�C���X�^���v�X�V
			'UPGRADE_WARNING: �I�u�W�F�N�g F_JDNTHA_Upd_TimeStamp() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			intRet = F_JDNTHA_Upd_TimeStamp(pm_All)
			If intRet <> 0 Then
				F_UpdateDel_Main = intRet
				GoTo F_UpdateDel_Main_err
			End If
			
			'�󒍃g���� �@�@�^�C���X�^���v�X�V
			'UPGRADE_WARNING: �I�u�W�F�N�g F_JDNTRA_Upd_TimeStamp() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			intRet = F_JDNTRA_Upd_TimeStamp(pm_All)
			If intRet <> 0 Then
				F_UpdateDel_Main = intRet
				GoTo F_UpdateDel_Main_err
			End If
		End If
        '2009/10/05 ADD E.N.D RISE)MIYAJIMA

        '�R�~�b�g
        '2019/05/23 CHG START
        'Call CF_Ora_CommitTrans(gv_Oss_USR1)
        Call DB_Commit()
        '2019/05/23 CHG END
        bolTran = False
		
		F_UpdateDel_Main = 0
		
F_UpdateDel_Main_End: 
		'�����v��߂�
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		Exit Function
		
F_UpdateDel_Main_err: 
		
		If bolTran = True Then
            '���[���o�b�N
            '2019/05/23 CHG START
            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
            Call DB_Rollback()
            '2019/05/23 CHG END
        End If
		
		GoTo F_UpdateDel_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_SYSTBA_SaibanDATNO
	'   �T�v�F  �`�[�Ǘ�NO�̔ԏ���
	'   �����F  pm_All        : ��ʏ��
	'           pot_strDATNO  : �`�[�Ǘ�No
	'   �ߒl�F  0:����  1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SYSTBA_SaibanDATNO(ByRef pm_All As Cls_All, ByRef pot_strDatNo As String) As Short
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy As U_Ody
		Dim curDatNo As Decimal
		Dim curSTTDATNO As Decimal
		Dim curENDDATNO As Decimal
		Dim bolRet As Boolean
		
		On Error GoTo F_SYSTBA_SaibanDATNO_err
		
		F_SYSTBA_SaibanDATNO = 9
		
		'SQL�F�f�[�^�擾�����b�N
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "   FROM SYSTBA "
		strSQL = strSQL & "    FOR UPDATE " '���b�N

        'change start 20190826 kuwa
        'bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
        'If bolRet = False Then
        'GoTo F_SYSTBA_SaibanDATNO_err
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'EOF����
        'change start 20190826 kuwa
        'If CF_Ora_EOF(usrOdy) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            F_SYSTBA_SaibanDATNO = 1
            GoTo F_SYSTBA_SaibanDATNO_err
        End If

        '�f�[�^�擾
        'change start 20190826 kuwa
        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '      curDatNo = CDec(CF_Ora_GetDyn(usrOdy, "DATNO", "0"))
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'curSTTDATNO = CDec(CF_Ora_GetDyn(usrOdy, "STTDATNO", "0"))
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'curENDDATNO = CDec(CF_Ora_GetDyn(usrOdy, "ENDDATNO", "0"))
        curDatNo = CDec(DB_NullReplace(dt.Rows(0)("DATNO"), 0))
        curSTTDATNO = CDec(DB_NullReplace(dt.Rows(0)("STTDATNO"), 0))
        curENDDATNO = CDec(DB_NullReplace(dt.Rows(0)("ENDDATNO"), 0))
        'change end 20190826 kuwa
        curDatNo = curDatNo + 1
		
		'�J�n�E�I���ԍ��͈̔͂łȂ��Ȃ烊�Z�b�g
		If curDatNo < curSTTDATNO Or curDatNo > curENDDATNO Then
			curDatNo = curSTTDATNO
		End If
		
		pot_strDatNo = VB6.Format(CStr(curDatNo), "0000000000")
		
		'SQL�F�X�V����
		strSQL = ""
		strSQL = strSQL & " UPDATE SYSTBA "
		strSQL = strSQL & "    SET DATNO = '" & CF_Ora_String(pot_strDatNo, 10) & "' "
		strSQL = strSQL & "      , OPEID    = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "      , CLTID    = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c
		strSQL = strSQL & "      , WRTTM    = '" & CF_Ora_String(GV_SysTime, 6) & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , WRTDT    = '" & CF_Ora_String(GV_SysDate, 8) & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "      , WRTFSTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "      , WRTFSTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " '�^�C���X�^���v�i�o�^���j
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_SYSTBA_SaibanDATNO_err
		End If
		
		'����I��
		F_SYSTBA_SaibanDATNO = 0
		
F_SYSTBA_SaibanDATNO_end: 
		Exit Function
		
F_SYSTBA_SaibanDATNO_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_SYSTBA_SaibanDATNO")
		
		GoTo F_SYSTBA_SaibanDATNO_end
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_SYSTBA_SaibanRECNO
	'   �T�v�F  ���R�[�h�Ǘ�NO�̔ԏ���
	'   �����F  pm_All        : ��ʏ��
	'           pot_strRECNO  : ���R�[�h�Ǘ�No
	'   �ߒl�F  0:����  1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SYSTBA_SaibanRECNO(ByRef pm_All As Cls_All, ByRef pot_strRECNO As String) As Short
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy As U_Ody
		Dim curRecNo As Decimal
		Dim curSTTRECNO As Decimal
		Dim curENDRECNO As Decimal
		Dim bolRet As Boolean
		
		On Error GoTo F_SYSTBA_SaibanRECNO_err
		
		F_SYSTBA_SaibanRECNO = 9
		
		'SQL�F�f�[�^�擾�����b�N
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "   FROM SYSTBA "
		strSQL = strSQL & "    FOR UPDATE " '���b�N

        'change start 20190827 kuwa
        'bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
        'If bolRet = False Then
        'GoTo F_SYSTBA_SaibanRECNO_err
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190827 kuwa

        'EOF����
        'change start 20190827 kuwa
        'If CF_Ora_EOF(usrOdy) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190827 kuwa
            F_SYSTBA_SaibanRECNO = 1
            GoTo F_SYSTBA_SaibanRECNO_err
        End If

        '�f�[�^�擾
        'change start 20190827 kuwa
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '      curRecNo = CDec(CF_Ora_GetDyn(usrOdy, "RECNO", "0"))
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'curSTTRECNO = CDec(CF_Ora_GetDyn(usrOdy, "STTRECNO", "0"))
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'curENDRECNO = CDec(CF_Ora_GetDyn(usrOdy, "ENDRECNO", "0"))
        curRecNo = CDec(DB_NullReplace(dt.Rows(0)("RECNO"), "0"))
        curSTTRECNO = CDec(DB_NullReplace(dt.Rows(0)("STTRECNO"), "0"))
        curENDRECNO = CDec(DB_NullReplace(dt.Rows(0)("ENDRECNO"), "0"))
        'change end 20190827 kuwa
        curRecNo = curRecNo + 1
		
		'�J�n�E�I���ԍ��͈̔͂łȂ��Ȃ烊�Z�b�g
		If curRecNo < curSTTRECNO Or curRecNo > curENDRECNO Then
			curRecNo = curSTTRECNO
		End If
		
		pot_strRECNO = VB6.Format(CStr(curRecNo), "0000000000")
		
		'SQL�F�X�V����
		strSQL = ""
		strSQL = strSQL & " UPDATE SYSTBA "
		strSQL = strSQL & "    SET RECNO = '" & CF_Ora_String(pot_strRECNO, 10) & "' "
		strSQL = strSQL & "      , OPEID    = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "      , CLTID    = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c
		strSQL = strSQL & "      , WRTTM    = '" & CF_Ora_String(GV_SysTime, 6) & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , WRTDT    = '" & CF_Ora_String(GV_SysDate, 8) & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "      , WRTFSTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "      , WRTFSTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " '�^�C���X�^���v�i�o�^���j
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_SYSTBA_SaibanRECNO_err
		End If
		
		'����I��
		F_SYSTBA_SaibanRECNO = 0
		
F_SYSTBA_SaibanRECNO_end: 
		Exit Function
		
F_SYSTBA_SaibanRECNO_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_SYSTBA_SaibanRECNO")
		
		GoTo F_SYSTBA_SaibanRECNO_end
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_SYSTBC_SaibanDENNO
	'   �T�v�F  �`�[�Ǘ�NO�̔ԏ���
	'   �����F  pm_All        : ��ʏ��
	'           pot_strDENNO  : �`�[�Ǘ�No
	'   �ߒl�F  0:����  1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SYSTBC_SaibanDENNO(ByRef pm_All As Cls_All, ByRef Pot_strDENNO As String) As Short
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy As U_Ody
		Dim curDENNO As Decimal
		Dim curSTTDENNO As Decimal
		Dim curENDDENNO As Decimal
		Dim bolRet As Boolean
		
		On Error GoTo F_SYSTBC_SaibanDENNO_err
		
		F_SYSTBC_SaibanDENNO = 9
		
		'SQL�F�f�[�^�擾�����b�N
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "   FROM SYSTBC "
		strSQL = strSQL & "  WHERE DKBSB = '" & CF_Ora_String(pc_strDKBSB_URK, 3) & "' "
		strSQL = strSQL & "    AND ADDDENCD IS NOT NULL "
		strSQL = strSQL & "    FOR UPDATE " '���b�N

        'change start 20190827 kuwa
        'bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
        'If bolRet = False Then
        'GoTo F_SYSTBC_SaibanDENNO_err
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190827 kuwa

        'EOF����
        'If CF_Ora_EOF(usrOdy) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190827 kuwa
            F_SYSTBC_SaibanDENNO = 1
            GoTo F_SYSTBC_SaibanDENNO_err
        End If

        '�f�[�^�擾
        'change start 20190827 kuwa
        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '      curDENNO = CDec(CF_Ora_GetDyn(usrOdy, "DENNO", "0"))
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'curSTTDENNO = CDec(CF_Ora_GetDyn(usrOdy, "STTNO", "0"))
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'curENDDENNO = CDec(CF_Ora_GetDyn(usrOdy, "ENDNO", "0"))
        curDENNO = CDec(DB_NullReplace(dt.Rows(0)("DENNO"), "0"))
        curSTTDENNO = CDec(DB_NullReplace(dt.Rows(0)("STTNO"), "0"))
        curENDDENNO = CDec(DB_NullReplace(dt.Rows(0)("ENDNO"), "0"))
        'change end 20190827 kuwa

        curDENNO = curDENNO + 1
		
		'�J�n�E�I���ԍ��͈̔͂łȂ��Ȃ烊�Z�b�g
		If curDENNO < curSTTDENNO Or curDENNO > curENDDENNO Then
			curDENNO = curSTTDENNO
		End If
		
		Pot_strDENNO = VB6.Format(CStr(curDENNO), "00000000")
		
		'SQL�F�X�V����
		strSQL = ""
		strSQL = strSQL & " UPDATE SYSTBC "
		strSQL = strSQL & "    SET DENNO = '" & CF_Ora_String(Pot_strDENNO, 8) & "' "
		strSQL = strSQL & "      , OPEID    = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "      , CLTID    = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c
		strSQL = strSQL & "      , WRTTM    = '" & CF_Ora_String(GV_SysTime, 6) & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , WRTDT    = '" & CF_Ora_String(GV_SysDate, 8) & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "      , WRTFSTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "      , WRTFSTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "  WHERE DKBSB = '" & CF_Ora_String(pc_strDKBSB_URK, 3) & "' "
		strSQL = strSQL & "    AND ADDDENCD IS NOT NULL "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_SYSTBC_SaibanDENNO_err
		End If
		
		'����I��
		F_SYSTBC_SaibanDENNO = 0
		
F_SYSTBC_SaibanDENNO_end: 
		Exit Function
		
F_SYSTBC_SaibanDENNO_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_SYSTBC_SaibanDENNO")
		
		GoTo F_SYSTBC_SaibanDENNO_end
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_UDNTHA_MakeInf
	'   �T�v�F  ���㌩�o�g�����o�^�f�[�^�쐬
	'   �����F  pm_All             : ��ʏ��
	'           pin_strDATNO       : �`�[�Ǘ�NO.
	'           pin_strDENNO       : �`�[�ԍ�
	'           pot_Tbl_Inf_UDNTHA : ���㌩�o�g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UDNTHA_MakeInf(ByRef pm_All As Cls_All, ByVal pin_strDATNO As String, ByVal pin_strDENNO As String, ByRef pot_Tbl_Inf_UDNTHA As TYPE_DB_UDNTHA) As Short
		Dim strBUMCD As String
		Dim Tbl_Inf_UDNTHA As TYPE_DB_UDNTHA
		
		On Error GoTo F_UDNTHA_MakeInf_err
		
		F_UDNTHA_MakeInf = 9
		
		'�o������R�[�h���擾
		Call F_Util_GET_TANMTA_KEIBMNCD(URKET52_HEAD_Inf.TOKMTA.TANCD, strBUMCD)
		
		With Tbl_Inf_UDNTHA
			.DATNO = pin_strDATNO '�`�[�Ǘ�NO.
			.DATKB = gc_strDATKB_USE '�`�[�폜�敪  �P�F�g�p��
			.AKAKROKB = gc_strAKAKROKB_KURO '�ԍ��敪      �P�F���`�[
			.DENKB = "8" '�`�[�敪      �W�F����
			.UDNNO = pin_strDENNO '����`�[�ԍ�
			.FDNNO = "" '�[�i����
			.JDNNO = "" '�󒍓`�[�ԍ�
			.USDNO = "" '�����`�[NO
			.UDNDT = URKET52_HEAD_Inf.NYUDT '����`�[���t
			.DENDT = GV_UNYDate '������t
			.REGDT = URKET52_HEAD_Inf.NYUDT '����`�[���t
			.TOKCD = URKET52_HEAD_Inf.TOKCD '���Ӑ�R�[�h
			.TOKRN = URKET52_HEAD_Inf.TOKMTA.TOKRN '���Ӑ旪��
			.NHSCD = "" '�[����R�[�h
			.NHSRN = "" '�[���旪��
			.NHSNMA = "" '�[���於�̂P
			.NHSNMB = "" '�[���於�̂Q
			.TANCD = "" '�S���҃R�[�h
			.TANNM = "" '�S���Җ�
			.BUMCD = "" '����R�[�h
			.BUMNM = "" '���喼
			.TOKSEICD = URKET52_HEAD_Inf.TOKCD '������R�[�h
			.SOUCD = "" '�q�ɃR�[�h
			.SOUNM = "" '�q�ɖ�
			.NXTKB = "" '���[�敪
			.NXTNM = "" '���[����
			.EMGODNKB = "" '�ً}�o�׋敪
			.OKRJONO = "" '�����
			.INVNO = "" '�C���{�C�X��
			.SMADT = pv_strSMADT '�o�������t
			.SSADT = pv_strSSADT '�����t
			.KESDT = pv_strKESDT '���ϓ��t
			.NYUCD = URKET52_HEAD_Inf.NYUKB '�����敪
			.ZKTKB = "" '����敪
			.ZKTNM = "" '����敪��
			.KENNMA = "" '�����P
			.KENNMB = "" '�����Q
			.NHSADA = "" '�[����Z���P
			.NHSADB = "" '�[����Z���Q
			.NHSADC = "" '�[����Z���R
			.MAEUKNM = "" '�O��敪����
			.KEIBUMCD = strBUMCD '�o������R�[�h
			.UPFKB = "1" '���㓯���o�׋敪
			.SBAURIKN = 0 '������z(�{�̍��v)
			.SBAUZEKN = 0 '������z(����Ŋz)
			.SBAUZKKN = 0 '������z(�`�[�v)
			.SBAFRUKN = 0 '�O�ݔ�����z(�`�[�v)
			.SBANYUKN = pv_curNYUKN_SUM '�������z(�`�[�v)
			.SBAFRNKN = pv_dblFNYUKN_SUM '�O�ݓ����z(�`�[�v)
			.DENCM = "" '���l
			.DENCMIN = "" '�Г����l
			.TOKSMEKB = URKET52_HEAD_Inf.TOKMTA.TOKSMEKB '���敪
			.TOKSMEDD = URKET52_HEAD_Inf.TOKMTA.TOKSMEDD '���������t(����)
			.TOKSMECC = URKET52_HEAD_Inf.TOKMTA.TOKSMECC '���T�C�N��(����)
			.TOKSDWKB = URKET52_HEAD_Inf.TOKMTA.TOKSDWKB '���ߗj��
			.TOKKESCC = URKET52_HEAD_Inf.TOKMTA.TOKKESCC '����T�C�N��
			.TOKKESDD = URKET52_HEAD_Inf.TOKMTA.TOKKESDD '������t
			.TOKKDWKB = URKET52_HEAD_Inf.TOKMTA.TOKKDWKB '����j��
			.LSTID = URKET52_HEAD_Inf.TOKMTA.LSTID '�`�[���
			.TOKJUNKB = URKET52_HEAD_Inf.TOKMTA.TOKJUNKB '���ʕ\�o�͋敪
			.TOKMSTKB = URKET52_HEAD_Inf.TOKMTA.TOKMSTKB '�}�X�^�敪(���Ӑ�)
			.TKNRPSKB = URKET52_HEAD_Inf.TOKMTA.TKNRPSKB '���z�[����������
			.TKNZRNKB = URKET52_HEAD_Inf.TOKMTA.TKNZRNKB '���z�[�������敪
			.TOKZEIKB = URKET52_HEAD_Inf.TOKMTA.TOKZEIKB '����ŋ敪
			.TOKZCLKB = URKET52_HEAD_Inf.TOKMTA.TOKZCLKB '����ŎZ�o�敪
			.TOKRPSKB = URKET52_HEAD_Inf.TOKMTA.TOKRPSKB '����Œ[����������
			.TOKZRNKB = URKET52_HEAD_Inf.TOKMTA.TOKZRNKB '����Œ[�������敪
			.TOKNMMKB = URKET52_HEAD_Inf.TOKMTA.TOKNMMKB '�����ƭ�ً敪
			.NHSMSTKB = "" '�}�X�^�敪(�[����)
			.NHSNMMKB = "" '�����ƭ�ً敪
			.TANMSTKB = "" '�}�X�^�敪(�S����)
			.URIKJN = "" '����
			.MAEUKKB = "" '�O��敪
			.SEIKB = "" '�����敪
			.JDNTRKB = "" '�󒍎���敪
			.TUKKB = URKET52_HEAD_Inf.TOKMTA.TUKKB '�ʉ݋敪
			.FRNKB = URKET52_HEAD_Inf.TOKMTA.FRNKB '�C�O����敪
			.UDNPRAKB = "" '�[�i�����s�敪
			.UDNPRBKB = "" '�ʐ������s�敪
			.MOTDATNO = URKET52_HEAD_Inf.UDNTHA.DATNO '���`�[�Ǘ��ԍ�
			.FOPEID = SSS_OPEID.Value '����o�^���[�UID
			.FCLTID = SSS_CLTID.Value '����o�^�N���C�A���gID
			.WRTFSTTM = GV_SysTime '�^�C���X�^���v�i�o�^���ԁj
			.WRTFSTDT = GV_SysDate '�^�C���X�^���v�i�o�^���j
			.OPEID = SSS_OPEID.Value '�ŏI��Ǝ҃R�[�h
			.CLTID = SSS_CLTID.Value '�N���C�A���g�h�c
			.WRTTM = GV_SysTime '�^�C���X�^���v�i���ԁj
			.WRTDT = GV_SysDate '�^�C���X�^���v�i���t�j
			.UOPEID = SSS_OPEID.Value '���[�UID�i�o�b�`�j
			.UCLTID = SSS_CLTID.Value '�N���C�A���gID�i�o�b�`�j
			.UWRTTM = GV_SysTime '�^�C���X�^���v�i�o�b�`���ԁj
			.UWRTDT = GV_SysDate '�^�C���X�^���v�i�o�b�`���t�j
			.PGID = SSS_PrgId '�X�VPGID
			.DLFLG = gc_strDLFLG_UPD '�폜�t���O
		End With
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pot_Tbl_Inf_UDNTHA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pot_Tbl_Inf_UDNTHA = Tbl_Inf_UDNTHA
		
		F_UDNTHA_MakeInf = 0
		
F_UDNTHA_MakeInf_end: 
		Exit Function
		
F_UDNTHA_MakeInf_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UDNTHA_MakeInf")
		GoTo F_UDNTHA_MakeInf_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_UDNTHA_Insert
	'   �T�v�F  ���㌩�o�g�����V�K�o�^
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTHA : ���㌩�o�g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UDNTHA_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTHA As TYPE_DB_UDNTHA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_UDNTHA_Insert_err
		
		F_UDNTHA_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO UDNTHA "
		strSQL = strSQL & "        ( DATNO " '�`�[�Ǘ�NO.
		strSQL = strSQL & "        , DATKB " '�`�[�폜�敪
		strSQL = strSQL & "        , AKAKROKB " '�ԍ��敪
		strSQL = strSQL & "        , DENKB " '�`�[�敪
		strSQL = strSQL & "        , UDNNO " '����`�[�ԍ�
		strSQL = strSQL & "        , FDNNO " '�[�i����
		strSQL = strSQL & "        , JDNNO " '�󒍓`�[�ԍ�
		strSQL = strSQL & "        , USDNO " '�����`�[NO
		strSQL = strSQL & "        , UDNDT " '����`�[���t
		strSQL = strSQL & "        , DENDT " '������t
		strSQL = strSQL & "        , REGDT " '����`�[���t
		strSQL = strSQL & "        , TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "        , TOKRN " '���Ӑ旪��
		strSQL = strSQL & "        , NHSCD " '�[����R�[�h
		strSQL = strSQL & "        , NHSRN " '�[���旪��
		strSQL = strSQL & "        , NHSNMA " '�[���於�̂P
		strSQL = strSQL & "        , NHSNMB " '�[���於�̂Q
		strSQL = strSQL & "        , TANCD " '�S���҃R�[�h
		strSQL = strSQL & "        , TANNM " '�S���Җ�
		strSQL = strSQL & "        , BUMCD " '����R�[�h
		strSQL = strSQL & "        , BUMNM " '���喼
		strSQL = strSQL & "        , TOKSEICD " '������R�[�h
		strSQL = strSQL & "        , SOUCD " '�q�ɃR�[�h
		strSQL = strSQL & "        , SOUNM " '�q�ɖ�
		strSQL = strSQL & "        , NXTKB " '���[�敪
		strSQL = strSQL & "        , NXTNM " '���[����
		strSQL = strSQL & "        , EMGODNKB " '�ً}�o�׋敪
		strSQL = strSQL & "        , OKRJONO " '�����
		strSQL = strSQL & "        , INVNO " '�C���{�C�X��
		strSQL = strSQL & "        , SMADT " '�o�������t
		strSQL = strSQL & "        , SSADT " '�����t
		strSQL = strSQL & "        , KESDT " '���ϓ��t
		strSQL = strSQL & "        , NYUCD " '�����敪
		strSQL = strSQL & "        , ZKTKB " '����敪
		strSQL = strSQL & "        , ZKTNM " '����敪��
		strSQL = strSQL & "        , KENNMA " '�����P
		strSQL = strSQL & "        , KENNMB " '�����Q
		strSQL = strSQL & "        , NHSADA " '�[����Z���P
		strSQL = strSQL & "        , NHSADB " '�[����Z���Q
		strSQL = strSQL & "        , NHSADC " '�[����Z���R
		strSQL = strSQL & "        , MAEUKNM " '�O��敪����
		strSQL = strSQL & "        , KEIBUMCD " '�o������R�[�h
		strSQL = strSQL & "        , UPFKB " '���㓯���o�׋敪
		strSQL = strSQL & "        , SBAURIKN " '������z(�{�̍��v)
		strSQL = strSQL & "        , SBAUZEKN " '������z(����Ŋz)
		strSQL = strSQL & "        , SBAUZKKN " '������z(�`�[�v)
		strSQL = strSQL & "        , SBAFRUKN " '�O�ݔ�����z(�`�[�v)
		strSQL = strSQL & "        , SBANYUKN " '�������z(�`�[�v)
		strSQL = strSQL & "        , SBAFRNKN " '�O�ݓ����z(�`�[�v)
		strSQL = strSQL & "        , DENCM " '���l
		strSQL = strSQL & "        , DENCMIN " '�Г����l
		strSQL = strSQL & "        , TOKSMEKB " '���敪
		strSQL = strSQL & "        , TOKSMEDD " '���������t(����)
		strSQL = strSQL & "        , TOKSMECC " '���T�C�N��(����)
		strSQL = strSQL & "        , TOKSDWKB " '���ߗj��
		strSQL = strSQL & "        , TOKKESCC " '����T�C�N��
		strSQL = strSQL & "        , TOKKESDD " '������t
		strSQL = strSQL & "        , TOKKDWKB " '����j��
		strSQL = strSQL & "        , LSTID " '�`�[���
		strSQL = strSQL & "        , TOKJUNKB " '���ʕ\�o�͋敪
		strSQL = strSQL & "        , TOKMSTKB " '�}�X�^�敪(���Ӑ�)
		strSQL = strSQL & "        , TKNRPSKB " '���z�[����������
		strSQL = strSQL & "        , TKNZRNKB " '���z�[�������敪
		strSQL = strSQL & "        , TOKZEIKB " '����ŋ敪
		strSQL = strSQL & "        , TOKZCLKB " '����ŎZ�o�敪
		strSQL = strSQL & "        , TOKRPSKB " '����Œ[����������
		strSQL = strSQL & "        , TOKZRNKB " '����Œ[�������敪
		strSQL = strSQL & "        , TOKNMMKB " '�����ƭ�ً敪
		strSQL = strSQL & "        , NHSMSTKB " '�}�X�^�敪(�[����)
		strSQL = strSQL & "        , NHSNMMKB " '�����ƭ�ً敪
		strSQL = strSQL & "        , TANMSTKB " '�}�X�^�敪(�S����)
		strSQL = strSQL & "        , URIKJN " '����
		strSQL = strSQL & "        , MAEUKKB " '�O��敪
		strSQL = strSQL & "        , SEIKB " '�����敪
		strSQL = strSQL & "        , JDNTRKB " '�󒍎���敪
		strSQL = strSQL & "        , TUKKB " '�ʉ݋敪
		strSQL = strSQL & "        , FRNKB " '�C�O����敪
		strSQL = strSQL & "        , UDNPRAKB " '�[�i�����s�敪
		strSQL = strSQL & "        , UDNPRBKB " '�ʐ������s�敪
		strSQL = strSQL & "        , MOTDATNO " '���`�[�Ǘ��ԍ�
		strSQL = strSQL & "        , FOPEID " '����o�^���[�UID
		strSQL = strSQL & "        , FCLTID " '����o�^�N���C�A���gID
		strSQL = strSQL & "        , WRTFSTTM " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "        , WRTFSTDT " '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "        , OPEID " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "        , CLTID " '�N���C�A���g�h�c
		strSQL = strSQL & "        , WRTTM " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "        , WRTDT " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "        , UOPEID " '���[�UID�i�o�b�`�j
		strSQL = strSQL & "        , UCLTID " '�N���C�A���gID�i�o�b�`�j
		strSQL = strSQL & "        , UWRTTM " '�^�C���X�^���v�i�o�b�`���ԁj
		strSQL = strSQL & "        , UWRTDT " '�^�C���X�^���v�i�o�b�`���t�j
		strSQL = strSQL & "        , PGID " '�X�VPGID
		strSQL = strSQL & "        , DLFLG " '�폜�t���O
		strSQL = strSQL & "        ) "
		With pin_Tbl_Inf_UDNTHA
			strSQL = strSQL & " VALUES "
			strSQL = strSQL & "        ( '" & CF_Ora_String(.DATNO, 10) & "' " '�`�[�Ǘ�NO.
			strSQL = strSQL & "        , '" & CF_Ora_String(.DATKB, 1) & "' " '�`�[�폜�敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.AKAKROKB, 1) & "' " '�ԍ��敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.DENKB, 1) & "' " '�`�[�敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.UDNNO, 8) & "' " '����`�[�ԍ�
			strSQL = strSQL & "        , '" & CF_Ora_String(.FDNNO, 8) & "' " '�[�i����
			strSQL = strSQL & "        , '" & CF_Ora_String(.JDNNO, 10) & "' " '�󒍓`�[�ԍ�
			strSQL = strSQL & "        , '" & CF_Ora_String(.USDNO, 8) & "' " '�����`�[NO
			strSQL = strSQL & "        , '" & CF_Ora_String(.UDNDT, 8) & "' " '����`�[���t
			strSQL = strSQL & "        , '" & CF_Ora_String(.DENDT, 8) & "' " '������t
			strSQL = strSQL & "        , '" & CF_Ora_String(.REGDT, 8) & "' " '����`�[���t
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKCD, 10) & "' " '���Ӑ�R�[�h
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKRN, 40) & "' " '���Ӑ旪��
			strSQL = strSQL & "        , '" & CF_Ora_String(.NHSCD, 10) & "' " '�[����R�[�h
			strSQL = strSQL & "        , '" & CF_Ora_String(.NHSRN, 40) & "' " '�[���旪��
			strSQL = strSQL & "        , '" & CF_Ora_String(.NHSNMA, 60) & "' " '�[���於�̂P
			strSQL = strSQL & "        , '" & CF_Ora_String(.NHSNMB, 60) & "' " '�[���於�̂Q
			strSQL = strSQL & "        , '" & CF_Ora_String(.TANCD, 6) & "' " '�S���҃R�[�h
			strSQL = strSQL & "        , '" & CF_Ora_String(.TANNM, 40) & "' " '�S���Җ�
			strSQL = strSQL & "        , '" & CF_Ora_String(.BUMCD, 6) & "' " '����R�[�h
			strSQL = strSQL & "        , '" & CF_Ora_String(.BUMNM, 40) & "' " '���喼
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKSEICD, 10) & "' " '������R�[�h
			strSQL = strSQL & "        , '" & CF_Ora_String(.SOUCD, 3) & "' " '�q�ɃR�[�h
			strSQL = strSQL & "        , '" & CF_Ora_String(.SOUNM, 20) & "' " '�q�ɖ�
			strSQL = strSQL & "        , '" & CF_Ora_String(.NXTKB, 1) & "' " '���[�敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.NXTNM, 10) & "' " '���[����
			strSQL = strSQL & "        , '" & CF_Ora_String(.EMGODNKB, 1) & "' " '�ً}�o�׋敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.OKRJONO, 15) & "' " '�����
			strSQL = strSQL & "        , '" & CF_Ora_String(.INVNO, 8) & "' " '�C���{�C�X��
			strSQL = strSQL & "        , '" & CF_Ora_String(.SMADT, 8) & "' " '�o�������t
			strSQL = strSQL & "        , '" & CF_Ora_String(.SSADT, 8) & "' " '�����t
			strSQL = strSQL & "        , '" & CF_Ora_String(.KESDT, 8) & "' " '���ϓ��t
			strSQL = strSQL & "        , '" & CF_Ora_String(.NYUCD, 1) & "' " '�����敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.ZKTKB, 1) & "' " '����敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.ZKTNM, 4) & "' " '����敪��
			strSQL = strSQL & "        , '" & CF_Ora_String(.KENNMA, 40) & "' " '�����P
			strSQL = strSQL & "        , '" & CF_Ora_String(.KENNMB, 40) & "' " '�����Q
			strSQL = strSQL & "        , '" & CF_Ora_String(.NHSADA, 60) & "' " '�[����Z���P
			strSQL = strSQL & "        , '" & CF_Ora_String(.NHSADB, 60) & "' " '�[����Z���Q
			strSQL = strSQL & "        , '" & CF_Ora_String(.NHSADC, 60) & "' " '�[����Z���R
			strSQL = strSQL & "        , '" & CF_Ora_String(.MAEUKNM, 10) & "' " '�O��敪����
			strSQL = strSQL & "        , '" & CF_Ora_String(.KEIBUMCD, 6) & "' " '�o������R�[�h
			strSQL = strSQL & "        , '" & CF_Ora_String(.UPFKB, 1) & "' " '���㓯���o�׋敪
			strSQL = strSQL & "        ,  " & CStr(.SBAURIKN) '������z(�{�̍��v)
			strSQL = strSQL & "        ,  " & CStr(.SBAUZEKN) '������z(����Ŋz)
			strSQL = strSQL & "        ,  " & CStr(.SBAUZKKN) '������z(�`�[�v)
			strSQL = strSQL & "        ,  " & CStr(.SBAFRUKN) '�O�ݔ�����z(�`�[�v)
			strSQL = strSQL & "        ,  " & CStr(.SBANYUKN) '�������z(�`�[�v)
			strSQL = strSQL & "        ,  " & CStr(.SBAFRNKN) '�O�ݓ����z(�`�[�v)
			strSQL = strSQL & "        , '" & CF_Ora_String(.DENCM, 40) & "' " '���l
			strSQL = strSQL & "        , '" & CF_Ora_String(.DENCMIN, 40) & "' " '�Г����l
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKSMEKB, 1) & "' " '���敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKSMEDD, 2) & "' " '���������t(����)
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKSMECC, 2) & "' " '���T�C�N��(����)
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKSDWKB, 1) & "' " '���ߗj��
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKKESCC, 2) & "' " '����T�C�N��
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKKESDD, 2) & "' " '������t
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKKDWKB, 1) & "' " '����j��
			strSQL = strSQL & "        , '" & CF_Ora_String(.LSTID, 7) & "' " '�`�[���
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKJUNKB, 1) & "' " '���ʕ\�o�͋敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKMSTKB, 1) & "' " '�}�X�^�敪(���Ӑ�)
			strSQL = strSQL & "        , '" & CF_Ora_String(.TKNRPSKB, 1) & "' " '���z�[����������
			strSQL = strSQL & "        , '" & CF_Ora_String(.TKNZRNKB, 1) & "' " '���z�[�������敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKZEIKB, 1) & "' " '����ŋ敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKZCLKB, 1) & "' " '����ŎZ�o�敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKRPSKB, 1) & "' " '����Œ[����������
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKZRNKB, 1) & "' " '����Œ[�������敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKNMMKB, 1) & "' " '�����ƭ�ً敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.NHSMSTKB, 1) & "' " '�}�X�^�敪(�[����)
			strSQL = strSQL & "        , '" & CF_Ora_String(.NHSNMMKB, 1) & "' " '�����ƭ�ً敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.TANMSTKB, 1) & "' " '�}�X�^�敪(�S����)
			strSQL = strSQL & "        , '" & CF_Ora_String(.URIKJN, 2) & "' " '����
			strSQL = strSQL & "        , '" & CF_Ora_String(.MAEUKKB, 1) & "' " '�O��敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.SEIKB, 1) & "' " '�����敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.JDNTRKB, 2) & "' " '�󒍎���敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.TUKKB, 3) & "' " '�ʉ݋敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.FRNKB, 1) & "' " '�C�O����敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.UDNPRAKB, 1) & "' " '�[�i�����s�敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.UDNPRBKB, 1) & "' " '�ʐ������s�敪
			strSQL = strSQL & "        , '" & CF_Ora_String(.MOTDATNO, 10) & "' " '���`�[�Ǘ��ԍ�
			strSQL = strSQL & "        , '" & CF_Ora_String(.FOPEID, 8) & "' " '����o�^���[�UID
			strSQL = strSQL & "        , '" & CF_Ora_String(.FCLTID, 5) & "' " '����o�^�N���C�A���gID
			strSQL = strSQL & "        , '" & CF_Ora_String(.WRTFSTTM, 6) & "' " '�^�C���X�^���v�i�o�^���ԁj
			strSQL = strSQL & "        , '" & CF_Ora_String(.WRTFSTDT, 8) & "' " '�^�C���X�^���v�i�o�^���j
			strSQL = strSQL & "        , '" & CF_Ora_String(.OPEID, 8) & "' " '�ŏI��Ǝ҃R�[�h
			strSQL = strSQL & "        , '" & CF_Ora_String(.CLTID, 5) & "' " '�N���C�A���g�h�c
			strSQL = strSQL & "        , '" & CF_Ora_String(.WRTTM, 6) & "' " '�^�C���X�^���v�i���ԁj
			strSQL = strSQL & "        , '" & CF_Ora_String(.WRTDT, 8) & "' " '�^�C���X�^���v�i���t�j
			strSQL = strSQL & "        , '" & CF_Ora_String(.UOPEID, 8) & "' " '���[�UID�i�o�b�`�j
			strSQL = strSQL & "        , '" & CF_Ora_String(.UCLTID, 5) & "' " '�N���C�A���gID�i�o�b�`�j
			strSQL = strSQL & "        , '" & CF_Ora_String(.UWRTTM, 6) & "' " '�^�C���X�^���v�i�o�b�`���ԁj
			strSQL = strSQL & "        , '" & CF_Ora_String(.UWRTDT, 8) & "' " '�^�C���X�^���v�i�o�b�`���t�j
			strSQL = strSQL & "        , '" & CF_Ora_String(.PGID, 7) & "' " '�X�VPGID
			strSQL = strSQL & "        , '" & CF_Ora_String(.DLFLG, 1) & "' " '�폜�t���O
			strSQL = strSQL & "        ) "
		End With
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_UDNTHA_Insert_err
		End If
		
		F_UDNTHA_Insert = 0
		
F_UDNTHA_Insert_end: 
		Exit Function
		
F_UDNTHA_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UDNTHA_Insert")
		GoTo F_UDNTHA_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_UDNTHA_Update_DelF
	'   �T�v�F  ���㌩�o�g�����_���폜����
	'   �����F  pm_All             : ��ʏ��
	'           pin_strDATNO       : �`�[�Ǘ��ԍ�
	'           pin_blnUpdDLFLG    : True = DLFLG ���X�V
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UDNTHA_Update_DelF(ByRef pm_All As Cls_All, ByVal pin_strDATNO As String, ByVal pin_blnUpdDLFLG As Boolean) As Object
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_UDNTHA_Update_DelF_err
		
		'UPGRADE_WARNING: �I�u�W�F�N�g F_UDNTHA_Update_DelF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		F_UDNTHA_Update_DelF = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE UDNTHA "
		strSQL = strSQL & "    SET DATKB  = '" & CF_Ora_String(gc_strDATKB_DEL, 1) & "' " '�`�[�폜�敪
		strSQL = strSQL & "      , OPEID  = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "      , CLTID  = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c
		strSQL = strSQL & "      , WRTTM  = '" & CF_Ora_String(GV_SysTime, 6) & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , WRTDT  = '" & CF_Ora_String(GV_SysDate, 8) & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "      , UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�UID�i�o�b�`�j
		strSQL = strSQL & "      , UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���gID�i�o�b�`�j
		strSQL = strSQL & "      , UWRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " '�^�C���X�^���v�i�o�b�`���ԁj
		strSQL = strSQL & "      , UWRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " '�^�C���X�^���v�i�o�b�`���t�j
		strSQL = strSQL & "      , PGID   = '" & CF_Ora_String(SSS_PrgId, 7) & "' " '�X�VPGID
		If pin_blnUpdDLFLG = True Then
			strSQL = strSQL & "  , DLFLG  = '" & CF_Ora_String(gc_strDLFLG_DEL, 1) & "' " '�폜�t���O
		End If
		strSQL = strSQL & "  WHERE DATNO = '" & CF_Ora_String(pin_strDATNO, 10) & "' " '�`�[�Ǘ�NO.
		strSQL = strSQL & "    AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' " '�`�[�폜�敪

        'SQL���s
        bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
        If bolRet = False Then
			GoTo F_UDNTHA_Update_DelF_err
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g F_UDNTHA_Update_DelF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		F_UDNTHA_Update_DelF = 0
		
F_UDNTHA_Update_DelF_end: 
		Exit Function
		
F_UDNTHA_Update_DelF_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UDNTHA_Update_DelF")
		GoTo F_UDNTHA_Update_DelF_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_UDNTRA_MakeInf
	'   �T�v�F  ����g�����o�^�f�[�^�쐬
	'   �����F  pm_All             : ��ʏ��
	'           pin_intRow         : �s�ԍ�
	'           pin_strDATNO       : �`�[�Ǘ�NO.
	'           pin_strDENNO       : �`�[�ԍ�
	'           pin_strRECNO       : ���R�[�h�Ǘ�NO.
	'           pot_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UDNTRA_MakeInf(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_strDATNO As String, ByVal pin_strDENNO As String, ByVal pin_strRECNO As String, ByRef pot_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		Dim strJdnNo As String
		Dim strJDNLINNO As String
		
		Dim strDKBSB As String
		Dim strDKBID As String
		Dim strDKBNM As String
		
		Dim curNYUKN As Decimal
		Dim dblFNYUKN As Double
		
		Dim strNYUKB As String
		
		Dim strLINCMA As String
		Dim strLINCMB As String
		Dim strBNKCD As String
		Dim strBNKNM As String
		Dim strTEGNO As String
		Dim strTEGDT As String
		Dim strUPDID As String
		Dim strDFLDKBCD As String
		Dim strDKBZAIFL As String
		Dim strDKBTEGFL As String
		Dim strDKBFLA As String
		Dim strDKBFLB As String
		Dim strDKBFLC As String
		
		'2009/06/05 ADD START FKS)NAKATA
		Dim strOKRJONO As String
		'2009/06/05 ADD E.N.D FKS)NAKATA
		
		Dim Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA
		Dim strKANKOZ As String
		
		On Error GoTo F_UDNTRA_MakeInf_err
		
		F_UDNTRA_MakeInf = 9
		
		'�󒍔ԍ�
		strJdnNo = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.JDNNO
		strJDNLINNO = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.JDNLINNO
		
		'2009/06/05 ADD START FKS)NAKATA
		strOKRJONO = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.OKRJONO
		'2009/06/05 ADD E.N.D FKS)NAKATA
		
		
		'����敪
		strDKBSB = pc_strDKBSB_URK
		strDKBID = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.DKBID
		strDKBNM = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.DKBNM
		
		'�����z
		curNYUKN = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.NYUKN
		dblFNYUKN = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.FNYUKN
		
		'�������
		'2009/09/18 UPD START RISE)MIYAJIMA
		'    Select Case Trim(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DFLDKBCD)
		'        Case "3":  strNYUKB = "4"
		'        Case "2":  strNYUKB = "2"
		'        Case Else: strNYUKB = "1"
		'    End Select
		Select Case Trim(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DFLDKBCD)
			Case "3" : strNYUKB = "4"
			Case "2" : strNYUKB = "2"
			Case Else : strNYUKB = "1"
		End Select
		If URKET52_HEAD_Inf.TOKMTA.SHAKB = pc_strSHAKB_KIJZITU Or URKET52_HEAD_Inf.TOKMTA.SHAKB = pc_strSHAKB_FACTERING Then
			Select Case Trim(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBID)
				'''' UPD 2011/11/15  FKS) T.Yamamoto    Start    �A���[��FC11110201
				'��������
				'            Case pc_strDKBID_URK_SOSAI _
				''               , pc_strDKBID_URK_NEBIK _
				''               , pc_strDKBID_URK_TESU _
				''               , pc_strDKBID_URK_HOKA _
				''               , pc_strDKBID_URK_SYOH
				Case pc_strDKBID_URK_SOSAI, pc_strDKBID_URK_NEBIK, pc_strDKBID_URK_TESU, pc_strDKBID_URK_SYOH
					'''' UPD 2011/11/15  FKS) T.Yamamoto    End
					strNYUKB = "2"
			End Select
		End If
		'2009/09/18 UPD E.N.D RISE)MIYAJIMA
		
		strLINCMA = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.LINCMA
		strLINCMB = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.LINCMB
		strBNKCD = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.BNKCD
		strBNKNM = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.BNKNM
		strTEGNO = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.TEGNO
		strTEGDT = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.TEGDT
		strUPDID = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.UPDID
		strDFLDKBCD = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DFLDKBCD
		strDKBZAIFL = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBZAIFL
		strDKBTEGFL = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBTEGFL
		strDKBFLA = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBFLA
		strDKBFLB = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBFLB
		strDKBFLC = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBFLC
		strKANKOZ = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.KANKOZ
		
		With Tbl_Inf_UDNTRA
			.DATNO = pin_strDATNO '�`�[�Ǘ�NO.
			.DATKB = gc_strDATKB_USE '�`�[�폜�敪
			.AKAKROKB = gc_strAKAKROKB_KURO '�ԍ��敪
			.DENKB = "8" '�`�[�敪
			.UDNNO = pin_strDENNO '����`�[�ԍ�
			.LINNO = VB6.Format(pin_intRow, "000") '�s�ԍ�
			.ZKTKB = "" '����敪
			.ODNNO = "" '�o�ד`�[�ԍ�
			.ODNLINNO = "" '�s�ԍ�
			
			'2009/06/05 CHG START FKS)NAKATA
			'.JDNNO = strJdnNo                                   '�󒍓`�[�ԍ�
			'.JDNLINNO = strJDNLINNO                             '�󒍓`�[�s�ԍ�
			.JDNNO = "" '�󒍓`�[�ԍ�
			.JDNLINNO = "" '�󒍓`�[�s�ԍ�
			'2009/06/05 CHG E.N.D FKS)NAKATA
			
			.RECNO = pin_strRECNO '���R�[�h�Ǘ�NO.
			.USDNO = "" '�����`�[NO
			.UDNDT = URKET52_HEAD_Inf.NYUDT '����`�[���t
			.DKBSB = strDKBSB '�`�[����敪���
			.DKBID = strDKBID '����敪�R�[�h
			.DKBNM = strDKBNM '����敪����
			.HENRSNCD = "" '�ԕi���R
			.HENSTTCD = "" '�ԕi���
			.SMADT = pv_strSMADT '�o�������t
			.SSADT = pv_strSSADT '�����t
			.KESDT = pv_strKESDT '���ϓ��t
			.TOKCD = URKET52_HEAD_Inf.TOKCD '���Ӑ�R�[�h
			.TANCD = "" '�S���҃R�[�h
			.NHSCD = "" '�[����R�[�h
			.TOKSEICD = URKET52_HEAD_Inf.TOKCD '������R�[�h
			.SOUCD = "" '�q�ɃR�[�h
			.SBNNO = "" '����
			.HINCD = "" '���i�R�[�h
			.TOKJDNNO = "" '�q�撍���ԍ�
			.HINNMA = "" '�^��
			.HINNMB = "" '���i���P
			.UNTCD = "" '�P�ʃR�[�h
			.UNTNM = "" '�P�ʖ�
			.IRISU = 0 '����
			.CASSU = 0 '�P�[�X��
			.URISU = 0 '���㐔��
			.URITK = 0 '�P��
			.GNKTK = 0 '�����P��
			.SIKTK = 0 '�c�Ǝd�ؒP��
			.FURITK = 0 '�O�ݒP��
			.URIKN = 0 '������z
			.FURIKN = 0 '�O�ݔ�����z
			.SIKKN = 0 '�c�Ǝd�؋��z
			.UZEKN = 0 '����ŋ��z
			.NYUDT = "" '������
			.NYUKN = curNYUKN '�����z
			.FNYUKN = dblFNYUKN '�O�ݓ����z
			.GNKKN = 0 '�������z
			.JKESIKN = 0 '�������z
			.FKESIKN = 0 '�O�ݏ������z
			
			'2009/06/05 ADD START FKS)NAKATA
			'.KESIKB = ""                                        '�����敪
			.KESIKB = CStr(9)
			'2009/06/05 ADD E.N.D FKS)NAKATA
			
			.NYUKB = strNYUKB '�������
			.TNKID = "" '���
			.TUKKB = URKET52_HEAD_Inf.TOKMTA.TUKKB '�ʉ݋敪
			'2009/09/27 UPD START RISE)MIYAJIMA
			'        .RATERT = 0                                         '�בփ��[�g
			'UPGRADE_WARNING: �I�u�W�F�N�g F_Get_RATERT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.RATERT = F_Get_RATERT(URKET52_HEAD_Inf.TOKMTA.TUKKB, URKET52_HEAD_Inf.NYUDT) '�בփ��[�g
			'2009/09/27 UPD E.N.D RISE)MIYAJIMA
			.EMGODNKB = "" '�ً}�o�׋敪
			
			'2009/06/05 CHG START FKS)NAKATA
			'.OKRJONO = ""                                       '�����
			.OKRJONO = strOKRJONO
			'2009/06/05 CHG E.N.D FKS)NAKATA
			
			.INVNO = "" '�C���{�C�X��
			.LINCMA = strLINCMA '���ה��l�P
			.LINCMB = strLINCMB '���ה��l�Q
			.BNKCD = strBNKCD '��s�R�[�h
			.BNKNM = strBNKNM '��s����
			.TEGNO = strTEGNO '��`�ԍ�
			'2009/09/18 UPD START RISE)MIYAJIMA
			.TEGDT = strTEGDT '��`����
			If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML Then
				.TEGDT = strTEGDT '��`����
			Else
				If URKET52_HEAD_Inf.TOKMTA.SHAKB = pc_strSHAKB_KIJZITU Or URKET52_HEAD_Inf.TOKMTA.SHAKB = pc_strSHAKB_FACTERING Then
					If .DKBID <> pc_strDKBID_URK_GENKN And .DKBID <> pc_strDKBID_URK_HURI And .DKBID <> pc_strDKBID_URK_TEG And .DKBID <> pc_strDKBID_URK_HNYU And .DKBID <> pc_strDKBID_URK_HURIK Then
						.TEGDT = F_GET_MaeukeTEGDT(pm_All, Trim(strOKRJONO), strTEGDT) '��`����
					Else
						.TEGDT = strTEGDT '��`����
					End If
				End If
			End If
			'2009/09/18 UPD E.N.D RISE)MIYAJIMA
			.UPDID = strUPDID '�X�V�p���ޯ��(ACNT)
			.DFLDKBCD = strDFLDKBCD '�f�t�H���g�R�[�h
			.DKBZAIFL = strDKBZAIFL '�݌Ɋ֘A�t���O
			.DKBTEGFL = strDKBTEGFL '��`�����t���O
			.DKBFLA = strDKBFLA '�_�~�[�t���O�P
			.DKBFLB = strDKBFLB '�_�~�[�t���O�Q
			.DKBFLC = strDKBFLC '�_�~�[�t���O�R
			.LSTID = "" '�`�[���
			.HINZEIKB = "" '���i����ŋ敪
			.HINMSTKB = "" '�}�X�^�敪(���i)
			.TOKMSTKB = "" '�}�X�^�敪(���Ӑ�)
			.NHSMSTKB = "" '�}�X�^�敪(�[����)
			.TANMSTKB = "" '�}�X�^�敪(�S����)
			.ZEIRNKKB = "" '����Ń����N
			.HINKB = "" '���i�敪
			.ZEIRT = 0 '����ŗ�
			.ZAIKB = "" '�݌ɊǗ��敪
			.MRPKB = "" '�W�J�敪
			.HINJUNKB = "" '���ʕ\�o�͋敪
			.MAKCD = "" '���[�J�[�R�[�h
			.HINSIRCD = strKANKOZ '���i�d����R�[�h
			.HINNMMKB = "" '�����ƭ�ً敪(���i)
			.HRTDD = "" '�������[�h�^�C��
			.ORTDD = "" '�o�׃��[�h�^�C��
			.ZNKURIKN = 0 '�Ŕ��ېőΏۊz
			.ZKMURIKN = 0 '�ō��ېőΏۊz
			.ZKMUZEKN = 0 '�ō������
			.MOTDATNO = URKET52_HEAD_Inf.UDNTHA.DATNO '���`�[�Ǘ��ԍ�
			.FOPEID = SSS_OPEID.Value '����o�^���[�UID
			.FCLTID = SSS_CLTID.Value '����o�^�N���C�A���gID
			.WRTFSTTM = GV_SysTime '�^�C���X�^���v�i�o�^���ԁj
			.WRTFSTDT = GV_SysDate '�^�C���X�^���v�i�o�^���j
			.OPEID = SSS_OPEID.Value '�ŏI��Ǝ҃R�[�h
			.CLTID = SSS_CLTID.Value '�N���C�A���g�h�c
			.WRTTM = GV_SysTime '�^�C���X�^���v�i���ԁj
			.WRTDT = GV_SysDate '�^�C���X�^���v�i���t�j
			.UOPEID = SSS_OPEID.Value '���[�UID�i�o�b�`�j
			.UCLTID = SSS_CLTID.Value '�N���C�A���gID�i�o�b�`�j
			.UWRTTM = GV_SysTime '�^�C���X�^���v�i�o�b�`���ԁj
			.UWRTDT = GV_SysDate '�^�C���X�^���v�i�o�b�`���t�j
			.PGID = SSS_PrgId '�X�VPGID
			.DLFLG = gc_strDLFLG_UPD '�폜�t���O
		End With
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pot_Tbl_Inf_UDNTRA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pot_Tbl_Inf_UDNTRA = Tbl_Inf_UDNTRA
		
		F_UDNTRA_MakeInf = 0
		
F_UDNTRA_MakeInf_end: 
		Exit Function
		
F_UDNTRA_MakeInf_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UDNTRA_MakeInf")
		GoTo F_UDNTRA_MakeInf_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_UDNTRA_Insert
	'   �T�v�F  ����g�����V�K�o�^
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UDNTRA_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_UDNTRA_Insert_err
		
		F_UDNTRA_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO UDNTRA " & vbCrLf
		strSQL = strSQL & " ( DATNO " & vbCrLf '�`�[�Ǘ�NO.
		strSQL = strSQL & " , DATKB " & vbCrLf '�`�[�폜�敪
		strSQL = strSQL & " , AKAKROKB " & vbCrLf '�ԍ��敪
		strSQL = strSQL & " , DENKB " & vbCrLf '�`�[�敪
		strSQL = strSQL & " , UDNNO " & vbCrLf '����`�[�ԍ�
		strSQL = strSQL & " , LINNO " & vbCrLf '�s�ԍ�
		strSQL = strSQL & " , ZKTKB " & vbCrLf '����敪
		strSQL = strSQL & " , ODNNO " & vbCrLf '�o�ד`�[�ԍ�
		strSQL = strSQL & " , ODNLINNO " & vbCrLf '�s�ԍ�
		strSQL = strSQL & " , JDNNO " & vbCrLf '�󒍓`�[�ԍ�
		strSQL = strSQL & " , JDNLINNO " & vbCrLf '�󒍓`�[�s�ԍ�
		strSQL = strSQL & " , RECNO " & vbCrLf '���R�[�h�Ǘ�NO.
		strSQL = strSQL & " , USDNO " & vbCrLf '�����`�[NO
		strSQL = strSQL & " , UDNDT " & vbCrLf '����`�[���t
		strSQL = strSQL & " , DKBSB " & vbCrLf '�`�[����敪���
		strSQL = strSQL & " , DKBID " & vbCrLf '����敪�R�[�h
		strSQL = strSQL & " , DKBNM " & vbCrLf '����敪����
		strSQL = strSQL & " , HENRSNCD " & vbCrLf '�ԕi���R
		strSQL = strSQL & " , HENSTTCD " & vbCrLf '�ԕi���
		strSQL = strSQL & " , SMADT " & vbCrLf '�o�������t
		strSQL = strSQL & " , SSADT " & vbCrLf '�����t
		strSQL = strSQL & " , KESDT " & vbCrLf '���ϓ��t
		strSQL = strSQL & " , TOKCD " & vbCrLf '���Ӑ�R�[�h
		strSQL = strSQL & " , TANCD " & vbCrLf '�S���҃R�[�h
		strSQL = strSQL & " , NHSCD " & vbCrLf '�[����R�[�h
		strSQL = strSQL & " , TOKSEICD " & vbCrLf '������R�[�h
		strSQL = strSQL & " , SOUCD " & vbCrLf '�q�ɃR�[�h
		strSQL = strSQL & " , SBNNO " & vbCrLf '����
		strSQL = strSQL & " , HINCD " & vbCrLf '���i�R�[�h
		strSQL = strSQL & " , TOKJDNNO " & vbCrLf '�q�撍���ԍ�
		strSQL = strSQL & " , HINNMA " & vbCrLf '�^��
		strSQL = strSQL & " , HINNMB " & vbCrLf '���i���P
		strSQL = strSQL & " , UNTCD " & vbCrLf '�P�ʃR�[�h
		strSQL = strSQL & " , UNTNM " & vbCrLf '�P�ʖ�
		strSQL = strSQL & " , IRISU " & vbCrLf '����
		strSQL = strSQL & " , CASSU " & vbCrLf '�P�[�X��
		strSQL = strSQL & " , URISU " & vbCrLf '���㐔��
		strSQL = strSQL & " , URITK " & vbCrLf '�P��
		strSQL = strSQL & " , GNKTK " & vbCrLf '�����P��
		strSQL = strSQL & " , SIKTK " & vbCrLf '�c�Ǝd�ؒP��
		strSQL = strSQL & " , FURITK " & vbCrLf '�O�ݒP��
		strSQL = strSQL & " , URIKN " & vbCrLf '������z
		strSQL = strSQL & " , FURIKN " & vbCrLf '�O�ݔ�����z
		strSQL = strSQL & " , SIKKN " & vbCrLf '�c�Ǝd�؋��z
		strSQL = strSQL & " , UZEKN " & vbCrLf '����ŋ��z
		strSQL = strSQL & " , NYUDT " & vbCrLf '������
		strSQL = strSQL & " , NYUKN " & vbCrLf '�����z
		strSQL = strSQL & " , FNYUKN " & vbCrLf '�O�ݓ����z
		strSQL = strSQL & " , GNKKN " & vbCrLf '�������z
		strSQL = strSQL & " , JKESIKN " & vbCrLf '�������z
		strSQL = strSQL & " , FKESIKN " & vbCrLf '�O�ݏ������z
		strSQL = strSQL & " , KESIKB " & vbCrLf '�����敪
		strSQL = strSQL & " , NYUKB " & vbCrLf '�������
		strSQL = strSQL & " , TNKID " & vbCrLf '���
		strSQL = strSQL & " , TUKKB " & vbCrLf '�ʉ݋敪
		strSQL = strSQL & " , RATERT " & vbCrLf '�בփ��[�g
		strSQL = strSQL & " , EMGODNKB " & vbCrLf '�ً}�o�׋敪
		strSQL = strSQL & " , OKRJONO " & vbCrLf '�����
		strSQL = strSQL & " , INVNO " & vbCrLf '�C���{�C�X��
		strSQL = strSQL & " , LINCMA " & vbCrLf '���ה��l�P
		strSQL = strSQL & " , LINCMB " & vbCrLf '���ה��l�Q
		strSQL = strSQL & " , BNKCD " & vbCrLf '��s�R�[�h
		strSQL = strSQL & " , BNKNM " & vbCrLf '��s����
		strSQL = strSQL & " , TEGNO " & vbCrLf '��`�ԍ�
		strSQL = strSQL & " , TEGDT " & vbCrLf '��`����
		strSQL = strSQL & " , UPDID " & vbCrLf '�X�V�p���ޯ��(ACNT)
		strSQL = strSQL & " , DFLDKBCD " & vbCrLf '�f�t�H���g�R�[�h
		strSQL = strSQL & " , DKBZAIFL " & vbCrLf '�݌Ɋ֘A�t���O
		strSQL = strSQL & " , DKBTEGFL " & vbCrLf '��`�����t���O
		strSQL = strSQL & " , DKBFLA " & vbCrLf '�_�~�[�t���O�P
		strSQL = strSQL & " , DKBFLB " & vbCrLf '�_�~�[�t���O�Q
		strSQL = strSQL & " , DKBFLC " & vbCrLf '�_�~�[�t���O�R
		strSQL = strSQL & " , LSTID " & vbCrLf '�`�[���
		strSQL = strSQL & " , HINZEIKB " & vbCrLf '���i����ŋ敪
		strSQL = strSQL & " , HINMSTKB " & vbCrLf '�}�X�^�敪(���i)
		strSQL = strSQL & " , TOKMSTKB " & vbCrLf '�}�X�^�敪(���Ӑ�)
		strSQL = strSQL & " , NHSMSTKB " & vbCrLf '�}�X�^�敪(�[����)
		strSQL = strSQL & " , TANMSTKB " & vbCrLf '�}�X�^�敪(�S����)
		strSQL = strSQL & " , ZEIRNKKB " & vbCrLf '����Ń����N
		strSQL = strSQL & " , HINKB " & vbCrLf '���i�敪
		strSQL = strSQL & " , ZEIRT " & vbCrLf '����ŗ�
		strSQL = strSQL & " , ZAIKB " & vbCrLf '�݌ɊǗ��敪
		strSQL = strSQL & " , MRPKB " & vbCrLf '�W�J�敪
		strSQL = strSQL & " , HINJUNKB " & vbCrLf '���ʕ\�o�͋敪
		strSQL = strSQL & " , MAKCD " & vbCrLf '���[�J�[�R�[�h
		strSQL = strSQL & " , HINSIRCD " & vbCrLf '���i�d����R�[�h
		strSQL = strSQL & " , HINNMMKB " & vbCrLf '�����ƭ�ً敪(���i)
		strSQL = strSQL & " , HRTDD " & vbCrLf '�������[�h�^�C��
		strSQL = strSQL & " , ORTDD " & vbCrLf '�o�׃��[�h�^�C��
		strSQL = strSQL & " , ZNKURIKN " & vbCrLf '�Ŕ��ېőΏۊz
		strSQL = strSQL & " , ZKMURIKN " & vbCrLf '�ō��ېőΏۊz
		strSQL = strSQL & " , ZKMUZEKN " & vbCrLf '�ō������
		strSQL = strSQL & " , MOTDATNO " & vbCrLf '���`�[�Ǘ��ԍ�
		strSQL = strSQL & " , FOPEID " & vbCrLf '����o�^���[�UID
		strSQL = strSQL & " , FCLTID " & vbCrLf '����o�^�N���C�A���gID
		strSQL = strSQL & " , WRTFSTTM " & vbCrLf '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & " , WRTFSTDT " & vbCrLf '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & " , OPEID " & vbCrLf '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & " , CLTID " & vbCrLf '�N���C�A���g�h�c
		strSQL = strSQL & " , WRTTM " & vbCrLf '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & " , WRTDT " & vbCrLf '�^�C���X�^���v�i���t�j
		strSQL = strSQL & " , UOPEID " & vbCrLf '���[�UID�i�o�b�`�j
		strSQL = strSQL & " , UCLTID " & vbCrLf '�N���C�A���gID�i�o�b�`�j
		strSQL = strSQL & " , UWRTTM " & vbCrLf '�^�C���X�^���v�i�o�b�`���ԁj
		strSQL = strSQL & " , UWRTDT " & vbCrLf '�^�C���X�^���v�i�o�b�`���t�j
		strSQL = strSQL & " , PGID " & vbCrLf '�X�VPGID
		strSQL = strSQL & " , DLFLG " & vbCrLf '�폜�t���O
		strSQL = strSQL & " ) " & vbCrLf
		With pin_Tbl_Inf_UDNTRA
			strSQL = strSQL & " VALUES " & vbCrLf
			strSQL = strSQL & " ( '" & CF_Ora_String(.DATNO, 10) & "' " & vbCrLf '�`�[�Ǘ�NO.
			strSQL = strSQL & " , '" & CF_Ora_String(.DATKB, 1) & "' " & vbCrLf '�`�[�폜�敪
			strSQL = strSQL & " , '" & CF_Ora_String(.AKAKROKB, 1) & "' " & vbCrLf '�ԍ��敪
			strSQL = strSQL & " , '" & CF_Ora_String(.DENKB, 1) & "' " & vbCrLf '�`�[�敪
			strSQL = strSQL & " , '" & CF_Ora_String(.UDNNO, 8) & "' " & vbCrLf '����`�[�ԍ�
			strSQL = strSQL & " , '" & CF_Ora_String(.LINNO, 3) & "' " & vbCrLf '�s�ԍ�
			strSQL = strSQL & " , '" & CF_Ora_String(.ZKTKB, 1) & "' " & vbCrLf '����敪
			strSQL = strSQL & " , '" & CF_Ora_String(.ODNNO, 8) & "' " & vbCrLf '�o�ד`�[�ԍ�
			strSQL = strSQL & " , '" & CF_Ora_String(.ODNLINNO, 3) & "' " & vbCrLf '�s�ԍ�
			strSQL = strSQL & " , '" & CF_Ora_String(.JDNNO, 10) & "' " & vbCrLf '�󒍓`�[�ԍ�
			strSQL = strSQL & " , '" & CF_Ora_String(.JDNLINNO, 3) & "' " & vbCrLf '�󒍓`�[�s�ԍ�
			strSQL = strSQL & " , '" & CF_Ora_String(.RECNO, 10) & "' " & vbCrLf '���R�[�h�Ǘ�NO.
			strSQL = strSQL & " , '" & CF_Ora_String(.USDNO, 8) & "' " & vbCrLf '�����`�[NO
			strSQL = strSQL & " , '" & CF_Ora_String(.UDNDT, 8) & "' " & vbCrLf '����`�[���t
			strSQL = strSQL & " , '" & CF_Ora_String(.DKBSB, 3) & "' " & vbCrLf '�`�[����敪���
			strSQL = strSQL & " , '" & CF_Ora_String(.DKBID, 2) & "' " & vbCrLf '����敪�R�[�h
			strSQL = strSQL & " , '" & CF_Ora_String(.DKBNM, 6) & "' " & vbCrLf '����敪����
			strSQL = strSQL & " , '" & CF_Ora_String(.HENRSNCD, 2) & "' " & vbCrLf '�ԕi���R
			strSQL = strSQL & " , '" & CF_Ora_String(.HENSTTCD, 2) & "' " & vbCrLf '�ԕi���
			strSQL = strSQL & " , '" & CF_Ora_String(.SMADT, 8) & "' " & vbCrLf '�o�������t
			strSQL = strSQL & " , '" & CF_Ora_String(.SSADT, 8) & "' " & vbCrLf '�����t
			strSQL = strSQL & " , '" & CF_Ora_String(.KESDT, 8) & "' " & vbCrLf '���ϓ��t
			strSQL = strSQL & " , '" & CF_Ora_String(.TOKCD, 10) & "' " & vbCrLf '���Ӑ�R�[�h
			strSQL = strSQL & " , '" & CF_Ora_String(.TANCD, 6) & "' " & vbCrLf '�S���҃R�[�h
			strSQL = strSQL & " , '" & CF_Ora_String(.NHSCD, 10) & "' " & vbCrLf '�[����R�[�h
			strSQL = strSQL & " , '" & CF_Ora_String(.TOKSEICD, 10) & "' " & vbCrLf '������R�[�h
			strSQL = strSQL & " , '" & CF_Ora_String(.SOUCD, 3) & "' " & vbCrLf '�q�ɃR�[�h
			strSQL = strSQL & " , '" & CF_Ora_String(.SBNNO, 20) & "' " & vbCrLf '����
			strSQL = strSQL & " , '" & CF_Ora_String(.HINCD, 10) & "' " & vbCrLf '���i�R�[�h
			strSQL = strSQL & " , '" & CF_Ora_String(.TOKJDNNO, 23) & "' " & vbCrLf '�q�撍���ԍ�
			strSQL = strSQL & " , '" & CF_Ora_String(.HINNMA, 50) & "' " & vbCrLf '�^��
			strSQL = strSQL & " , '" & CF_Ora_String(.HINNMB, 50) & "' " & vbCrLf '���i���P
			strSQL = strSQL & " , '" & CF_Ora_String(.UNTCD, 2) & "' " & vbCrLf '�P�ʃR�[�h
			strSQL = strSQL & " , '" & CF_Ora_String(.UNTNM, 4) & "' " & vbCrLf '�P�ʖ�
			strSQL = strSQL & " ,  " & CStr(.IRISU) & vbCrLf '����
			strSQL = strSQL & " ,  " & CStr(.CASSU) & vbCrLf '�P�[�X��
			strSQL = strSQL & " ,  " & CStr(.URISU) & vbCrLf '���㐔��
			strSQL = strSQL & " ,  " & CStr(.URITK) & vbCrLf '�P��
			strSQL = strSQL & " ,  " & CStr(.GNKTK) & vbCrLf '�����P��
			strSQL = strSQL & " ,  " & CStr(.SIKTK) & vbCrLf '�c�Ǝd�ؒP��
			strSQL = strSQL & " ,  " & CStr(.FURITK) & vbCrLf '�O�ݒP��
			strSQL = strSQL & " ,  " & CStr(.URIKN) & vbCrLf '������z
			strSQL = strSQL & " ,  " & CStr(.FURIKN) & vbCrLf '�O�ݔ�����z
			strSQL = strSQL & " ,  " & CStr(.SIKKN) & vbCrLf '�c�Ǝd�؋��z
			strSQL = strSQL & " ,  " & CStr(.UZEKN) & vbCrLf '����ŋ��z
			strSQL = strSQL & " , '" & CF_Ora_String(.NYUDT, 8) & "' " & vbCrLf '������
			strSQL = strSQL & " ,  " & CStr(.NYUKN) & vbCrLf '�����z
			strSQL = strSQL & " ,  " & CStr(.FNYUKN) & vbCrLf '�O�ݓ����z
			strSQL = strSQL & " ,  " & CStr(.GNKKN) & vbCrLf '�������z
			strSQL = strSQL & " ,  " & CStr(.JKESIKN) & vbCrLf '�������z
			strSQL = strSQL & " ,  " & CStr(.FKESIKN) & vbCrLf '�O�ݏ������z
			strSQL = strSQL & " , '" & CF_Ora_String(.KESIKB, 1) & "' " & vbCrLf '�����敪
			strSQL = strSQL & " , '" & CF_Ora_String(.NYUKB, 1) & "' " & vbCrLf '�������
			strSQL = strSQL & " , '" & CF_Ora_String(.TNKID, 2) & "' " & vbCrLf '���
			strSQL = strSQL & " , '" & CF_Ora_String(.TUKKB, 3) & "' " & vbCrLf '�ʉ݋敪
			strSQL = strSQL & " ,  " & CStr(.RATERT) & vbCrLf '�בփ��[�g
			strSQL = strSQL & " , '" & CF_Ora_String(.EMGODNKB, 1) & "' " & vbCrLf '�ً}�o�׋敪
			strSQL = strSQL & " , '" & CF_Ora_String(.OKRJONO, 15) & "' " & vbCrLf '�����
			strSQL = strSQL & " , '" & CF_Ora_String(.INVNO, 8) & "' " & vbCrLf '�C���{�C�X��
			strSQL = strSQL & " , '" & CF_Ora_String(.LINCMA, 20) & "' " & vbCrLf '���ה��l�P
			strSQL = strSQL & " , '" & CF_Ora_String(.LINCMB, 20) & "' " & vbCrLf '���ה��l�Q
			strSQL = strSQL & " , '" & CF_Ora_String(.BNKCD, 7) & "' " & vbCrLf '��s�R�[�h
			strSQL = strSQL & " , '" & CF_Ora_String(.BNKNM, 50) & "' " & vbCrLf '��s����
			strSQL = strSQL & " , '" & CF_Ora_String(.TEGNO, 10) & "' " & vbCrLf '��`�ԍ�
			strSQL = strSQL & " , '" & CF_Ora_String(.TEGDT, 8) & "' " & vbCrLf '��`����
			strSQL = strSQL & " , '" & CF_Ora_String(.UPDID, 2) & "' " & vbCrLf '�X�V�p���ޯ��(ACNT)
			strSQL = strSQL & " , '" & CF_Ora_String(.DFLDKBCD, 13) & "' " & vbCrLf '�f�t�H���g�R�[�h
			strSQL = strSQL & " , '" & CF_Ora_String(.DKBZAIFL, 1) & "' " & vbCrLf '�݌Ɋ֘A�t���O
			strSQL = strSQL & " , '" & CF_Ora_String(.DKBTEGFL, 1) & "' " & vbCrLf '��`�����t���O
			strSQL = strSQL & " , '" & CF_Ora_String(.DKBFLA, 1) & "' " & vbCrLf '�_�~�[�t���O�P
			strSQL = strSQL & " , '" & CF_Ora_String(.DKBFLB, 1) & "' " & vbCrLf '�_�~�[�t���O�Q
			strSQL = strSQL & " , '" & CF_Ora_String(.DKBFLC, 1) & "' " & vbCrLf '�_�~�[�t���O�R
			strSQL = strSQL & " , '" & CF_Ora_String(.LSTID, 7) & "' " & vbCrLf '�`�[���
			strSQL = strSQL & " , '" & CF_Ora_String(.HINZEIKB, 1) & "' " & vbCrLf '���i����ŋ敪
			strSQL = strSQL & " , '" & CF_Ora_String(.HINMSTKB, 1) & "' " & vbCrLf '�}�X�^�敪(���i)
			strSQL = strSQL & " , '" & CF_Ora_String(.TOKMSTKB, 1) & "' " & vbCrLf '�}�X�^�敪(���Ӑ�)
			strSQL = strSQL & " , '" & CF_Ora_String(.NHSMSTKB, 1) & "' " & vbCrLf '�}�X�^�敪(�[����)
			strSQL = strSQL & " , '" & CF_Ora_String(.TANMSTKB, 1) & "' " & vbCrLf '�}�X�^�敪(�S����)
			strSQL = strSQL & " , '" & CF_Ora_String(.ZEIRNKKB, 1) & "' " & vbCrLf '����Ń����N
			strSQL = strSQL & " , '" & CF_Ora_String(.HINKB, 1) & "' " & vbCrLf '���i�敪
			strSQL = strSQL & " ,  " & CStr(.ZEIRT) & vbCrLf '����ŗ�
			strSQL = strSQL & " , '" & CF_Ora_String(.ZAIKB, 1) & "' " & vbCrLf '�݌ɊǗ��敪
			strSQL = strSQL & " , '" & CF_Ora_String(.MRPKB, 1) & "' " & vbCrLf '�W�J�敪
			strSQL = strSQL & " , '" & CF_Ora_String(.HINJUNKB, 1) & "' " & vbCrLf '���ʕ\�o�͋敪
			strSQL = strSQL & " , '" & CF_Ora_String(.MAKCD, 6) & "' " & vbCrLf '���[�J�[�R�[�h
			strSQL = strSQL & " , '" & CF_Ora_String(.HINSIRCD, 10) & "' " & vbCrLf '���i�d����R�[�h
			strSQL = strSQL & " , '" & CF_Ora_String(.HINNMMKB, 1) & "' " & vbCrLf '�����ƭ�ً敪(���i)
			strSQL = strSQL & " , '" & CF_Ora_String(.HRTDD, 2) & "' " & vbCrLf '�������[�h�^�C��
			strSQL = strSQL & " , '" & CF_Ora_String(.ORTDD, 2) & "' " & vbCrLf '�o�׃��[�h�^�C��
			strSQL = strSQL & " ,  " & CStr(.ZNKURIKN) & vbCrLf '�Ŕ��ېőΏۊz
			strSQL = strSQL & " ,  " & CStr(.ZKMURIKN) & vbCrLf '�ō��ېőΏۊz
			strSQL = strSQL & " ,  " & CStr(.ZKMUZEKN) & vbCrLf '�ō������
			strSQL = strSQL & " , '" & CF_Ora_String(.MOTDATNO, 10) & "' " & vbCrLf '���`�[�Ǘ��ԍ�
			strSQL = strSQL & " , '" & CF_Ora_String(.FOPEID, 8) & "' " & vbCrLf '����o�^���[�UID
			strSQL = strSQL & " , '" & CF_Ora_String(.FCLTID, 5) & "' " & vbCrLf '����o�^�N���C�A���gID
			strSQL = strSQL & " , '" & CF_Ora_String(.WRTFSTTM, 6) & "' " & vbCrLf '�^�C���X�^���v�i�o�^���ԁj
			strSQL = strSQL & " , '" & CF_Ora_String(.WRTFSTDT, 8) & "' " & vbCrLf '�^�C���X�^���v�i�o�^���j
			strSQL = strSQL & " , '" & CF_Ora_String(.OPEID, 8) & "' " & vbCrLf '�ŏI��Ǝ҃R�[�h
			strSQL = strSQL & " , '" & CF_Ora_String(.CLTID, 5) & "' " & vbCrLf '�N���C�A���g�h�c
			strSQL = strSQL & " , '" & CF_Ora_String(.WRTTM, 6) & "' " & vbCrLf '�^�C���X�^���v�i���ԁj
			strSQL = strSQL & " , '" & CF_Ora_String(.WRTDT, 8) & "' " & vbCrLf '�^�C���X�^���v�i���t�j
			strSQL = strSQL & " , '" & CF_Ora_String(.UOPEID, 8) & "' " & vbCrLf '���[�UID�i�o�b�`�j
			strSQL = strSQL & " , '" & CF_Ora_String(.UCLTID, 5) & "' " & vbCrLf '�N���C�A���gID�i�o�b�`�j
			strSQL = strSQL & " , '" & CF_Ora_String(.UWRTTM, 6) & "' " & vbCrLf '�^�C���X�^���v�i�o�b�`���ԁj
			strSQL = strSQL & " , '" & CF_Ora_String(.UWRTDT, 8) & "' " & vbCrLf '�^�C���X�^���v�i�o�b�`���t�j
			strSQL = strSQL & " , '" & CF_Ora_String(.PGID, 7) & "' " & vbCrLf '�X�VPGID
			strSQL = strSQL & " , '" & CF_Ora_String(.DLFLG, 1) & "' " & vbCrLf '�폜�t���O
			strSQL = strSQL & "   ) "
		End With
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_UDNTRA_Insert_err
		End If
		
		F_UDNTRA_Insert = 0
		
F_UDNTRA_Insert_end: 
		Exit Function
		
F_UDNTRA_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UDNTRA_Insert")
		GoTo F_UDNTRA_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_UDNTRA_Update_DelF
	'   �T�v�F  ����g�����_���폜����
	'   �����F  pm_All             : ��ʏ��
	'           pin_strDATNO       : �`�[�Ǘ��ԍ�
	'           pin_blnUpdDLFLG    : True = DLFLG ���X�V
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UDNTRA_Update_DelF(ByRef pm_All As Cls_All, ByVal pin_strDATNO As String, ByVal pin_blnUpdDLFLG As Boolean) As Object
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_UDNTRA_Update_DelF_err
		
		'UPGRADE_WARNING: �I�u�W�F�N�g F_UDNTRA_Update_DelF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		F_UDNTRA_Update_DelF = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE UDNTRA "
		strSQL = strSQL & "    SET DATKB  = '" & CF_Ora_String(gc_strDATKB_DEL, 1) & "' " '�`�[�폜�敪
		strSQL = strSQL & "      , OPEID  = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "      , CLTID  = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c
		strSQL = strSQL & "      , WRTTM  = '" & CF_Ora_String(GV_SysTime, 6) & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , WRTDT  = '" & CF_Ora_String(GV_SysDate, 8) & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "      , UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�UID�i�o�b�`�j
		strSQL = strSQL & "      , UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���gID�i�o�b�`�j
		strSQL = strSQL & "      , UWRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " '�^�C���X�^���v�i�o�b�`���ԁj
		strSQL = strSQL & "      , UWRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " '�^�C���X�^���v�i�o�b�`���t�j
		strSQL = strSQL & "      , PGID   = '" & CF_Ora_String(SSS_PrgId, 7) & "' " '�X�VPGID
		If pin_blnUpdDLFLG = True Then
			strSQL = strSQL & "  , DLFLG  = '" & CF_Ora_String(gc_strDLFLG_DEL, 1) & "' " '�폜�t���O
		End If
		strSQL = strSQL & "  WHERE DATNO = '" & CF_Ora_String(pin_strDATNO, 10) & "' " '�`�[�Ǘ�NO.
		strSQL = strSQL & "    AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' " '�`�[�폜�敪
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_UDNTRA_Update_DelF_err
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g F_UDNTRA_Update_DelF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		F_UDNTRA_Update_DelF = 0
		
F_UDNTRA_Update_DelF_end: 
		Exit Function
		
F_UDNTRA_Update_DelF_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UDNTRA_Update_DelF")
		GoTo F_UDNTRA_Update_DelF_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_UPDSMF
	'   �T�v�F  �T�}���t�@�C���Q�̍X�V
	'   �����F  pm_All             : ��ʏ��
	'           pin_intRow         : �s�ԍ�
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�����f�[�^
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UPDSMF(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim intRet As Short
		
		On Error GoTo F_UPDSMF_err
		
		F_UPDSMF = 9
		
		'�X�V�����F�����敪���P�F���� ���� �f�t�H���g�R�[�h���R
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML And Trim(pin_Tbl_Inf_UDNTRA.DFLDKBCD) <> "3" Then
			'�����T�}���X�V
			intRet = F_TOKSSA(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF = intRet
				GoTo F_UPDSMF_err
			End If
			
			'���������T�}���̍X�V
			intRet = F_NKSSMA(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF = intRet
				GoTo F_UPDSMF_err
			End If
			
		End If
		
		'�X�V�����F�����敪���Q�F�O�����
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE And Trim(pin_Tbl_Inf_UDNTRA.DFLDKBCD) <> "3" Then
			'2009/09/24 UPD E.N.D RISE)MIYAJIMA
			'�O�󐿋��T�}���X�V
			intRet = F_TOKSSB(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF = intRet
				GoTo F_UPDSMF_err
			End If
			
			'���������T�}���O��̍X�V
			intRet = F_NKSSMB(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF = intRet
				GoTo F_UPDSMF_err
			End If
		End If
		
		'�X�V�����F�����敪���P�F���� ���� �C�O����敪���P�F�C�O
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML And URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN Then
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML And URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN And Trim(pin_Tbl_Inf_UDNTRA.DFLDKBCD) <> "3" Then
			'2009/09/24 UPD E.N.D RISE)MIYAJIMA
			'�����T�}���O�݂̍X�V
			intRet = F_TOKSSC(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF = intRet
				GoTo F_UPDSMF_err
			End If
			
			'���������T�}���O�݂̍X�V
			intRet = F_NKSSMC(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF = intRet
				GoTo F_UPDSMF_err
			End If
		End If
		
		'�X�V�����F�����敪���P�F���� ���� �f�t�H���g�R�[�h���Q
		'�X�V�����F�����敪���Q�F�O�����
		If (URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML And Trim(pin_Tbl_Inf_UDNTRA.DFLDKBCD) <> "2") Or URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			'���|�T�}�������̍X�V
			intRet = F_TOKSME(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF = intRet
				GoTo F_UPDSMF_err
			End If
		End If
		
		F_UPDSMF = 0
		
F_UPDSMF_end: 
		Exit Function
		
F_UPDSMF_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UPDSMF")
		GoTo F_UPDSMF_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSSA
	'   �T�v�F  �����T�}������
	'   �����F  pm_All             : ��ʏ��
	'           pin_intRow         : �s�ԍ�
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSA(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim lngRowCnt As Integer
		
		Dim curSSAURIKN(9) As Decimal '����W�v���z
		Dim curSSAUZEKN As Decimal '�������ŋ��z
		Dim curSSANYUKN(9) As Decimal '�����W�v���z
		Dim curKSKZANKN As Decimal '���������z�c
		
		On Error GoTo F_TOKSSA_err
		
		F_TOKSSA = 9
		
		'����W�v���z
		curSSAURIKN(0) = 0
		curSSAURIKN(1) = 0
		curSSAURIKN(2) = 0
		curSSAURIKN(3) = 0
		curSSAURIKN(4) = 0
		curSSAURIKN(5) = 0
		curSSAURIKN(6) = 0
		curSSAURIKN(7) = 0
		curSSAURIKN(8) = 0
		curSSAURIKN(9) = 0
		curSSAURIKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSSAURIKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.URIKN * pin_intSMFKB
		
		'�������ŋ��z
		curSSAUZEKN = pin_Tbl_Inf_UDNTRA.UZEKN * pin_intSMFKB
		
		'�����W�v���z
		curSSANYUKN(0) = 0
		curSSANYUKN(1) = 0
		curSSANYUKN(2) = 0
		curSSANYUKN(3) = 0
		curSSANYUKN(4) = 0
		curSSANYUKN(5) = 0
		curSSANYUKN(6) = 0
		curSSANYUKN(7) = 0
		curSSANYUKN(8) = 0
		curSSANYUKN(9) = 0
		curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.NYUKN * pin_intSMFKB
		
		'���������z�c
		curKSKZANKN = pin_Tbl_Inf_UDNTRA.NYUKN * pin_intSMFKB
		
		'�v�Z���ʂ��X�V����
		If F_TOKSSA_Update(pm_All, pin_Tbl_Inf_UDNTRA, curSSAURIKN, curSSAUZEKN, curSSANYUKN, curKSKZANKN, lngRowCnt) <> 0 Then
			GoTo F_TOKSSA_err
		End If
		
		'�X�V�Ώۂ��Ȃ�������A�V�K�o�^����
		If lngRowCnt <= 0 Then
			If F_TOKSSA_Insert(pm_All, pin_Tbl_Inf_UDNTRA, curSSAURIKN, curSSAUZEKN, curSSANYUKN, curKSKZANKN) <> 0 Then
				GoTo F_TOKSSA_err
			End If
		End If
		
		'�����N�ʏ���
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) > 0 Then
			If F_TOKSSA_UpdateRANK(pm_All, pin_intSMFKB, pin_Tbl_Inf_UDNTRA) <> 0 Then
				GoTo F_TOKSSA_err
			End If
		End If
		
		'�`�[�������J�E���g�A�b�v
		If pin_intRow = 1 And pin_Tbl_Inf_UDNTRA.DENKB = "1" Then
			If F_TOKSSA_UpdateDENSU(pm_All, pin_intSMFKB, pin_Tbl_Inf_UDNTRA) <> 0 Then
				GoTo F_TOKSSA_err
			End If
		End If
		
		F_TOKSSA = 0
		
F_TOKSSA_end: 
		Exit Function
		
F_TOKSSA_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSA")
		GoTo F_TOKSSA_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSSA_Update
	'   �T�v�F  �����T�}���X�V
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'           pin_curSSAURIKN    : ����W�v���z
	'           pin_curSSAUZEKN    : �������ŋ��z
	'           pin_curSSANYUKN    : �����W�v���z
	'           pin_curKSKZANKN    : ���������z�c
	'           pot_lngRowCnt      : �X�V����
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSA_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSAURIKN() As Decimal, ByVal pin_curSSAUZEKN As Decimal, ByRef pin_curSSANYUKN() As Decimal, ByVal pin_curKSKZANKN As Decimal, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSSA_Update_err
		
		F_TOKSSA_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSA "
		strSQL = strSQL & "    SET KESDT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.KESDT, 8) & "' " '���ϓ��t
		strSQL = strSQL & "      , SSAURIKN00 = SSAURIKN00 + " & CStr(pin_curSSAURIKN(0)) '����W�v���z00
		strSQL = strSQL & "      , SSAURIKN01 = SSAURIKN01 + " & CStr(pin_curSSAURIKN(1)) '����W�v���z01
		strSQL = strSQL & "      , SSAURIKN02 = SSAURIKN02 + " & CStr(pin_curSSAURIKN(2)) '����W�v���z02
		strSQL = strSQL & "      , SSAURIKN03 = SSAURIKN03 + " & CStr(pin_curSSAURIKN(3)) '����W�v���z03
		strSQL = strSQL & "      , SSAURIKN04 = SSAURIKN04 + " & CStr(pin_curSSAURIKN(4)) '����W�v���z04
		strSQL = strSQL & "      , SSAURIKN05 = SSAURIKN05 + " & CStr(pin_curSSAURIKN(5)) '����W�v���z05
		strSQL = strSQL & "      , SSAURIKN06 = SSAURIKN06 + " & CStr(pin_curSSAURIKN(6)) '����W�v���z06
		strSQL = strSQL & "      , SSAURIKN07 = SSAURIKN07 + " & CStr(pin_curSSAURIKN(7)) '����W�v���z07
		strSQL = strSQL & "      , SSAURIKN08 = SSAURIKN08 + " & CStr(pin_curSSAURIKN(8)) '����W�v���z08
		strSQL = strSQL & "      , SSAURIKN09 = SSAURIKN09 + " & CStr(pin_curSSAURIKN(9)) '����W�v���z09
		strSQL = strSQL & "      , SSAUZEKN   = SSAUZEKN   + " & CStr(pin_curSSAUZEKN) '�������ŋ��z
		strSQL = strSQL & "      , SSANYUKN00 = SSANYUKN00 + " & CStr(pin_curSSANYUKN(0)) '�����W�v���z00
		strSQL = strSQL & "      , SSANYUKN01 = SSANYUKN01 + " & CStr(pin_curSSANYUKN(1)) '�����W�v���z01
		strSQL = strSQL & "      , SSANYUKN02 = SSANYUKN02 + " & CStr(pin_curSSANYUKN(2)) '�����W�v���z02
		strSQL = strSQL & "      , SSANYUKN03 = SSANYUKN03 + " & CStr(pin_curSSANYUKN(3)) '�����W�v���z03
		strSQL = strSQL & "      , SSANYUKN04 = SSANYUKN04 + " & CStr(pin_curSSANYUKN(4)) '�����W�v���z04
		strSQL = strSQL & "      , SSANYUKN05 = SSANYUKN05 + " & CStr(pin_curSSANYUKN(5)) '�����W�v���z05
		strSQL = strSQL & "      , SSANYUKN06 = SSANYUKN06 + " & CStr(pin_curSSANYUKN(6)) '�����W�v���z06
		strSQL = strSQL & "      , SSANYUKN07 = SSANYUKN07 + " & CStr(pin_curSSANYUKN(7)) '�����W�v���z07
		strSQL = strSQL & "      , SSANYUKN08 = SSANYUKN08 + " & CStr(pin_curSSANYUKN(8)) '�����W�v���z08
		strSQL = strSQL & "      , SSANYUKN09 = SSANYUKN09 + " & CStr(pin_curSSANYUKN(9)) '�����W�v���z09
		strSQL = strSQL & "      , KSKZANKN   = KSKZANKN   + " & CStr(pin_curKSKZANKN) '���������z�c
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SSADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '�����t
		strSQL = strSQL & "    AND SSADT = '" & pv_strSSADT & "' " '�����t
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_TOKSSA_Update_err
		End If
		
		F_TOKSSA_Update = 0
		
F_TOKSSA_Update_end: 
		Exit Function
		
F_TOKSSA_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSA_Update")
		GoTo F_TOKSSA_Update_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSSA_Insert
	'   �T�v�F  �����T�}���V�K�o�^
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'           pin_curSSAURIKN    : ����W�v���z
	'           pin_curSSAUZEKN    : �������ŋ��z
	'           pin_curSSANYUKN    : �����W�v���z
	'           pin_curKSKZANKN    : ���������z�c
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSA_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSAURIKN() As Decimal, ByVal pin_curSSAUZEKN As Decimal, ByRef pin_curSSANYUKN() As Decimal, ByVal pin_curKSKZANKN As Decimal) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSSA_Insert_err
		
		F_TOKSSA_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSSA "
		strSQL = strSQL & "        ( TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "        , SSADT " '�����t
		strSQL = strSQL & "        , KESDT " '���ϓ��t
		strSQL = strSQL & "        , SSAURIKN00 " '����W�v���z00
		strSQL = strSQL & "        , SSAURIKN01 " '����W�v���z01
		strSQL = strSQL & "        , SSAURIKN02 " '����W�v���z02
		strSQL = strSQL & "        , SSAURIKN03 " '����W�v���z03
		strSQL = strSQL & "        , SSAURIKN04 " '����W�v���z04
		strSQL = strSQL & "        , SSAURIKN05 " '����W�v���z05
		strSQL = strSQL & "        , SSAURIKN06 " '����W�v���z06
		strSQL = strSQL & "        , SSAURIKN07 " '����W�v���z07
		strSQL = strSQL & "        , SSAURIKN08 " '����W�v���z08
		strSQL = strSQL & "        , SSAURIKN09 " '����W�v���z09
		strSQL = strSQL & "        , SSAUZEKN " '�������ŋ��z
		strSQL = strSQL & "        , SZAKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "        , SZAKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "        , SZAKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "        , SZAKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "        , SZAKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "        , SZAKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "        , SZBKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "        , SZBKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "        , SZBKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "        , SZBKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "        , SZBKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "        , SZBKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "        , SSANYUKN00 " '�����W�v���z00
		strSQL = strSQL & "        , SSANYUKN01 " '�����W�v���z01
		strSQL = strSQL & "        , SSANYUKN02 " '�����W�v���z02
		strSQL = strSQL & "        , SSANYUKN03 " '�����W�v���z03
		strSQL = strSQL & "        , SSANYUKN04 " '�����W�v���z04
		strSQL = strSQL & "        , SSANYUKN05 " '�����W�v���z05
		strSQL = strSQL & "        , SSANYUKN06 " '�����W�v���z06
		strSQL = strSQL & "        , SSANYUKN07 " '�����W�v���z07
		strSQL = strSQL & "        , SSANYUKN08 " '�����W�v���z08
		strSQL = strSQL & "        , SSANYUKN09 " '�����W�v���z09
		strSQL = strSQL & "        , KSKNYKKN " '���������z
		strSQL = strSQL & "        , KSKZANKN " '���������z�c
		strSQL = strSQL & "        , SSADENSU " '�`�[����
		strSQL = strSQL & "        , DATNO " '�`�[�Ǘ�NO.
		strSQL = strSQL & "        , WRTTM " '��ѽ����(����)
		strSQL = strSQL & "        , WRTDT " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '�����t
		strSQL = strSQL & "        , '" & pv_strSSADT & "' " '�����t
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.KESDT, 8) & "' " '���ϓ��t
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(0)) '����W�v���z00
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(1)) '����W�v���z01
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(2)) '����W�v���z02
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(3)) '����W�v���z03
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(4)) '����W�v���z04
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(5)) '����W�v���z05
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(6)) '����W�v���z06
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(7)) '����W�v���z07
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(8)) '����W�v���z08
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(9)) '����W�v���z09
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAUZEKN) '�������ŋ��z
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(0)) '�����W�v���z00
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(1)) '�����W�v���z01
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(2)) '�����W�v���z02
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(3)) '�����W�v���z03
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(4)) '�����W�v���z04
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(5)) '�����W�v���z05
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(6)) '�����W�v���z06
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(7)) '�����W�v���z07
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(8)) '�����W�v���z08
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(9)) '�����W�v���z09
		strSQL = strSQL & "        , 0 " '���������z
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN) '���������z�c
		strSQL = strSQL & "        , 0 " '�`�[����
		strSQL = strSQL & "        , '" & Space(10) & "' " '�`�[�Ǘ�NO.
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "        ) "

        'SQL���s
        bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
        If bolRet = False Then
			GoTo F_TOKSSA_Insert_err
		End If
		
		F_TOKSSA_Insert = 0
		
F_TOKSSA_Insert_end: 
		Exit Function
		
F_TOKSSA_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSA_Insert")
		GoTo F_TOKSSA_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSSA_UpdateRANK
	'   �T�v�F  �����T�}���X�V�i�����N�ʏ����j
	'   �����F  pm_All             : ��ʏ��
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSA_UpdateRANK(ByRef pm_All As Cls_All, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		Dim dblSZAKZIKN(2) As Double '�����N�ʐō��ېŋ��z
		Dim dblSZAKZOKN(2) As Double '�����N�ʐŔ��ېŋ��z
		Dim intZEIRNKKB As Short
		
		On Error GoTo F_TOKSSA_UpdateRANK_err
		
		F_TOKSSA_UpdateRANK = 9
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		intZEIRNKKB = SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) - 1
		
		'�����N�ʐō��ېŋ��z
		dblSZAKZIKN(0) = 0
		dblSZAKZIKN(1) = 0
		dblSZAKZIKN(2) = 0
		dblSZAKZIKN(intZEIRNKKB) = dblSZAKZIKN(intZEIRNKKB) + pin_Tbl_Inf_UDNTRA.ZKMURIKN * pin_intSMFKB
		
		'�����N�ʐŔ��ېŋ��z
		dblSZAKZOKN(0) = 0
		dblSZAKZOKN(1) = 0
		dblSZAKZOKN(2) = 0
		dblSZAKZOKN(intZEIRNKKB) = dblSZAKZOKN(intZEIRNKKB) + pin_Tbl_Inf_UDNTRA.ZNKURIKN * pin_intSMFKB
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSA "
		strSQL = strSQL & "    SET SSAURIKN09 = SSAURIKN09 - " & CStr(pin_Tbl_Inf_UDNTRA.ZKMUZEKN) '����W�v���z09
		strSQL = strSQL & "      , SZAKZIKN00 = SZAKZIKN00 + " & CStr(dblSZAKZIKN(0)) '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , SZAKZIKN01 = SZAKZIKN01 + " & CStr(dblSZAKZIKN(1)) '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , SZAKZIKN02 = SZAKZIKN02 + " & CStr(dblSZAKZIKN(2)) '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , SZAKZOKN00 = SZAKZOKN00 + " & CStr(dblSZAKZOKN(0)) '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , SZAKZOKN01 = SZAKZOKN01 + " & CStr(dblSZAKZOKN(1)) '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , SZAKZOKN02 = SZAKZOKN02 + " & CStr(dblSZAKZOKN(2)) '�����N�ʐŔ��ېŋ��z02
		'strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' "                 '��ѽ����(����)
		'strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' "                 '��ѽ����(���t)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SSADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '�����t
		strSQL = strSQL & "    AND SSADT = '" & pv_strSSADT & "' " '�����t
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSSA_UpdateRANK_err
		End If
		
		F_TOKSSA_UpdateRANK = 0
		
F_TOKSSA_UpdateRANK_end: 
		Exit Function
		
F_TOKSSA_UpdateRANK_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSA_UpdateRANK")
		GoTo F_TOKSSA_UpdateRANK_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSSA_UpdateDENSU
	'   �T�v�F  �����T�}���X�V�i�`�[�������J�E���g�A�b�v�j
	'   �����F  pm_All             : ��ʏ��
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSA_UpdateDENSU(ByRef pm_All As Cls_All, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSSA_UpdateDENSU_err
		
		F_TOKSSA_UpdateDENSU = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSA "
		strSQL = strSQL & "    SET SSADENSU = SSADENSU + " & CStr(pin_intSMFKB) '�`�[����
		'strSQL = strSQL & "      , WRTTM = '" & GCF_Ora_String(GV_SysTime, 6) & "' "                '��ѽ����(����)
		'strSQL = strSQL & "      , WRTDT = '" & GCF_Ora_String(GV_SysDate, 8) & "' "                '��ѽ����(���t)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SSADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '�����t
		strSQL = strSQL & "    AND SSADT = '" & pv_strSSADT & "' " '�����t
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSSA_UpdateDENSU_err
		End If
		
		F_TOKSSA_UpdateDENSU = 0
		
F_TOKSSA_UpdateDENSU_end: 
		Exit Function
		
F_TOKSSA_UpdateDENSU_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSA_UpdateDENSU")
		GoTo F_TOKSSA_UpdateDENSU_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSSB
	'   �T�v�F  �O�󐿋��T�}������
	'   �����F  pm_All             : ��ʏ��
	'           pin_intRow         : �s�ԍ�
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSB(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim lngRowCnt As Integer
		
		Dim curSSAURIKN(9) As Decimal '����W�v���z
		Dim curSSAUZEKN As Decimal '�������ŋ��z
		Dim curSSANYUKN(9) As Decimal '�����W�v���z
		Dim curKSKZANKN As Decimal '���������z�c
		
		On Error GoTo F_TOKSSB_err
		
		F_TOKSSB = 9
		
		'����W�v���z
		curSSAURIKN(0) = 0
		curSSAURIKN(1) = 0
		curSSAURIKN(2) = 0
		curSSAURIKN(3) = 0
		curSSAURIKN(4) = 0
		curSSAURIKN(5) = 0
		curSSAURIKN(6) = 0
		curSSAURIKN(7) = 0
		curSSAURIKN(8) = 0
		curSSAURIKN(9) = 0
		curSSAURIKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSSAURIKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.URIKN * pin_intSMFKB
		
		'�������ŋ��z
		curSSAUZEKN = pin_Tbl_Inf_UDNTRA.UZEKN * pin_intSMFKB
		
		'�����W�v���z
		curSSANYUKN(0) = 0
		curSSANYUKN(1) = 0
		curSSANYUKN(2) = 0
		curSSANYUKN(3) = 0
		curSSANYUKN(4) = 0
		curSSANYUKN(5) = 0
		curSSANYUKN(6) = 0
		curSSANYUKN(7) = 0
		curSSANYUKN(8) = 0
		curSSANYUKN(9) = 0
		curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.NYUKN * pin_intSMFKB
		
		'���������z�c
		curKSKZANKN = pin_Tbl_Inf_UDNTRA.NYUKN * pin_intSMFKB
		
		'�v�Z���ʂ��X�V����
		If F_TOKSSB_Update(pm_All, pin_Tbl_Inf_UDNTRA, curSSAURIKN, curSSAUZEKN, curSSANYUKN, curKSKZANKN, lngRowCnt) <> 0 Then
			GoTo F_TOKSSB_err
		End If
		
		'�X�V�Ώۂ��Ȃ�������A�V�K�o�^����
		If lngRowCnt <= 0 Then
			If F_TOKSSB_Insert(pm_All, pin_Tbl_Inf_UDNTRA, curSSAURIKN, curSSAUZEKN, curSSANYUKN, curKSKZANKN) <> 0 Then
				GoTo F_TOKSSB_err
			End If
		End If
		
		'�����N�ʏ���
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) > 0 Then
			If F_TOKSSB_UpdateRANK(pm_All, pin_intSMFKB, pin_Tbl_Inf_UDNTRA) <> 0 Then
				GoTo F_TOKSSB_err
			End If
		End If
		
		'�`�[�������J�E���g�A�b�v
		If pin_intRow = 1 And pin_Tbl_Inf_UDNTRA.DENKB = "1" Then
			If F_TOKSSB_UpdateDENSU(pm_All, pin_intSMFKB, pin_Tbl_Inf_UDNTRA) <> 0 Then
				GoTo F_TOKSSB_err
			End If
		End If
		
		F_TOKSSB = 0
		
F_TOKSSB_end: 
		Exit Function
		
F_TOKSSB_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSB")
		GoTo F_TOKSSB_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSSB_Update
	'   �T�v�F  �O�󐿋��T�}���X�V
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'           pin_curSSAURIKN    : ����W�v���z
	'           pin_curSSAUZEKN    : �������ŋ��z
	'           pin_curSSANYUKN    : �����W�v���z
	'           pin_curKSKZANKN    : ���������z�c
	'           pot_lngRowCnt      : �X�V����
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSB_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSAURIKN() As Decimal, ByVal pin_curSSAUZEKN As Decimal, ByRef pin_curSSANYUKN() As Decimal, ByVal pin_curKSKZANKN As Decimal, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSSB_Update_err
		
		F_TOKSSB_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSB "
		strSQL = strSQL & "    SET TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKSEICD, 8) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "      , KESDT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.KESDT, 8) & "' " '���ϓ��t
		strSQL = strSQL & "      , SSAURIKN00 = SSAURIKN00 + " & CStr(pin_curSSAURIKN(0)) '����W�v���z00
		strSQL = strSQL & "      , SSAURIKN01 = SSAURIKN01 + " & CStr(pin_curSSAURIKN(1)) '����W�v���z01
		strSQL = strSQL & "      , SSAURIKN02 = SSAURIKN02 + " & CStr(pin_curSSAURIKN(2)) '����W�v���z02
		strSQL = strSQL & "      , SSAURIKN03 = SSAURIKN03 + " & CStr(pin_curSSAURIKN(3)) '����W�v���z03
		strSQL = strSQL & "      , SSAURIKN04 = SSAURIKN04 + " & CStr(pin_curSSAURIKN(4)) '����W�v���z04
		strSQL = strSQL & "      , SSAURIKN05 = SSAURIKN05 + " & CStr(pin_curSSAURIKN(5)) '����W�v���z05
		strSQL = strSQL & "      , SSAURIKN06 = SSAURIKN06 + " & CStr(pin_curSSAURIKN(6)) '����W�v���z06
		strSQL = strSQL & "      , SSAURIKN07 = SSAURIKN07 + " & CStr(pin_curSSAURIKN(7)) '����W�v���z07
		strSQL = strSQL & "      , SSAURIKN08 = SSAURIKN08 + " & CStr(pin_curSSAURIKN(8)) '����W�v���z08
		strSQL = strSQL & "      , SSAURIKN09 = SSAURIKN09 + " & CStr(pin_curSSAURIKN(9)) '����W�v���z09
		strSQL = strSQL & "      , SSAUZEKN   = SSAUZEKN   + " & CStr(pin_curSSAUZEKN) '�������ŋ��z
		strSQL = strSQL & "      , SSANYUKN00 = SSANYUKN00 + " & CStr(pin_curSSANYUKN(0)) '�����W�v���z00
		strSQL = strSQL & "      , SSANYUKN01 = SSANYUKN01 + " & CStr(pin_curSSANYUKN(1)) '�����W�v���z01
		strSQL = strSQL & "      , SSANYUKN02 = SSANYUKN02 + " & CStr(pin_curSSANYUKN(2)) '�����W�v���z02
		strSQL = strSQL & "      , SSANYUKN03 = SSANYUKN03 + " & CStr(pin_curSSANYUKN(3)) '�����W�v���z03
		strSQL = strSQL & "      , SSANYUKN04 = SSANYUKN04 + " & CStr(pin_curSSANYUKN(4)) '�����W�v���z04
		strSQL = strSQL & "      , SSANYUKN05 = SSANYUKN05 + " & CStr(pin_curSSANYUKN(5)) '�����W�v���z05
		strSQL = strSQL & "      , SSANYUKN06 = SSANYUKN06 + " & CStr(pin_curSSANYUKN(6)) '�����W�v���z06
		strSQL = strSQL & "      , SSANYUKN07 = SSANYUKN07 + " & CStr(pin_curSSANYUKN(7)) '�����W�v���z07
		strSQL = strSQL & "      , SSANYUKN08 = SSANYUKN08 + " & CStr(pin_curSSANYUKN(8)) '�����W�v���z08
		strSQL = strSQL & "      , SSANYUKN09 = SSANYUKN09 + " & CStr(pin_curSSANYUKN(9)) '�����W�v���z09
		strSQL = strSQL & "      , KSKZANKN   = KSKZANKN   + " & CStr(pin_curKSKZANKN) '���������z�c
		'2009/06/10 DEL START FKS)NAKATA
		'strSQL = strSQL & "      , DATNO      = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.DATNO, 10) & "' "  '�`�[�Ǘ�NO.
		'2009/06/10 DEL E.N.D FKS)NAKATA
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SSADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "        '�����t
		strSQL = strSQL & "    AND SSADT = '" & pv_strSSADT & "' " '�����t
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_TOKSSB_Update_err
		End If
		
		F_TOKSSB_Update = 0
		
F_TOKSSB_Update_end: 
		Exit Function
		
F_TOKSSB_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSB_Update")
		GoTo F_TOKSSB_Update_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSSB_Insert
	'   �T�v�F  �O�󐿋��T�}���V�K�o�^
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'           pin_curSSAURIKN    : ����W�v���z
	'           pin_curSSAUZEKN    : �������ŋ��z
	'           pin_curSSANYUKN    : �����W�v���z
	'           pin_curKSKZANKN    : ���������z�c
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSB_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSAURIKN() As Decimal, ByVal pin_curSSAUZEKN As Decimal, ByRef pin_curSSANYUKN() As Decimal, ByVal pin_curKSKZANKN As Decimal) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSSB_Insert_err
		
		F_TOKSSB_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSSB "
		strSQL = strSQL & "        ( TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "        , SSADT " '�����t
		strSQL = strSQL & "        , KESDT " '���ϓ��t
		strSQL = strSQL & "        , SSAURIKN00 " '����W�v���z00
		strSQL = strSQL & "        , SSAURIKN01 " '����W�v���z01
		strSQL = strSQL & "        , SSAURIKN02 " '����W�v���z02
		strSQL = strSQL & "        , SSAURIKN03 " '����W�v���z03
		strSQL = strSQL & "        , SSAURIKN04 " '����W�v���z04
		strSQL = strSQL & "        , SSAURIKN05 " '����W�v���z05
		strSQL = strSQL & "        , SSAURIKN06 " '����W�v���z06
		strSQL = strSQL & "        , SSAURIKN07 " '����W�v���z07
		strSQL = strSQL & "        , SSAURIKN08 " '����W�v���z08
		strSQL = strSQL & "        , SSAURIKN09 " '����W�v���z09
		strSQL = strSQL & "        , SSAUZEKN " '�������ŋ��z
		strSQL = strSQL & "        , SZAKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "        , SZAKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "        , SZAKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "        , SZAKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "        , SZAKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "        , SZAKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "        , SZBKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "        , SZBKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "        , SZBKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "        , SZBKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "        , SZBKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "        , SZBKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "        , SSANYUKN00 " '�����W�v���z00
		strSQL = strSQL & "        , SSANYUKN01 " '�����W�v���z01
		strSQL = strSQL & "        , SSANYUKN02 " '�����W�v���z02
		strSQL = strSQL & "        , SSANYUKN03 " '�����W�v���z03
		strSQL = strSQL & "        , SSANYUKN04 " '�����W�v���z04
		strSQL = strSQL & "        , SSANYUKN05 " '�����W�v���z05
		strSQL = strSQL & "        , SSANYUKN06 " '�����W�v���z06
		strSQL = strSQL & "        , SSANYUKN07 " '�����W�v���z07
		strSQL = strSQL & "        , SSANYUKN08 " '�����W�v���z08
		strSQL = strSQL & "        , SSANYUKN09 " '�����W�v���z09
		strSQL = strSQL & "        , KSKNYKKN " '���������z
		strSQL = strSQL & "        , KSKZANKN " '���������z�c
		strSQL = strSQL & "        , SSADENSU " '�`�[����
		strSQL = strSQL & "        , DATNO " '�`�[�Ǘ�NO.
		strSQL = strSQL & "        , WRTTM " '��ѽ����(����)
		strSQL = strSQL & "        , WRTDT " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKSEICD, 10) & "' " '���Ӑ�R�[�h
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '�����t
		strSQL = strSQL & "        , '" & pv_strSSADT & "' " '�����t
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.KESDT, 8) & "' " '���ϓ��t
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(0)) '����W�v���z00
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(1)) '����W�v���z01
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(2)) '����W�v���z02
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(3)) '����W�v���z03
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(4)) '����W�v���z04
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(5)) '����W�v���z05
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(6)) '����W�v���z06
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(7)) '����W�v���z07
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(8)) '����W�v���z08
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(9)) '����W�v���z09
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAUZEKN) '�������ŋ��z
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(0)) '�����W�v���z00
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(1)) '�����W�v���z01
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(2)) '�����W�v���z02
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(3)) '�����W�v���z03
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(4)) '�����W�v���z04
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(5)) '�����W�v���z05
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(6)) '�����W�v���z06
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(7)) '�����W�v���z07
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(8)) '�����W�v���z08
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(9)) '�����W�v���z09
		strSQL = strSQL & "        , 0 " '���������z
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN) '���������z�c
		strSQL = strSQL & "        , 0 " '�`�[����
		'2009/06/10 CHG START FKS)NAKATA
		'strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.DATNO, 10) & "' "  '�`�[�Ǘ�NO.
		strSQL = strSQL & "        , '" & Space(10) & "' " '�`�[�Ǘ�NO.
		'2009/06/10 CHG E.N.D FKS)NAKATA
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSSB_Insert_err
		End If
		
		F_TOKSSB_Insert = 0
		
F_TOKSSB_Insert_end: 
		Exit Function
		
F_TOKSSB_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSB_Insert")
		GoTo F_TOKSSB_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSSB_UpdateRANK
	'   �T�v�F  �O�󐿋��T�}���X�V�i�����N�ʏ����j
	'   �����F  pm_All             : ��ʏ��
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSB_UpdateRANK(ByRef pm_All As Cls_All, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		Dim dblSZAKZIKN(2) As Double '�����N�ʐō��ېŋ��z
		Dim dblSZAKZOKN(2) As Double '�����N�ʐŔ��ېŋ��z
		Dim intZEIRNKKB As Short
		
		On Error GoTo F_TOKSSB_UpdateRANK_err
		
		F_TOKSSB_UpdateRANK = 9
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		intZEIRNKKB = SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) - 1
		
		'�����N�ʐō��ېŋ��z
		dblSZAKZIKN(0) = 0
		dblSZAKZIKN(1) = 0
		dblSZAKZIKN(2) = 0
		dblSZAKZIKN(intZEIRNKKB) = dblSZAKZIKN(intZEIRNKKB) + pin_Tbl_Inf_UDNTRA.ZKMURIKN * pin_intSMFKB
		
		'�����N�ʐŔ��ېŋ��z
		dblSZAKZOKN(0) = 0
		dblSZAKZOKN(1) = 0
		dblSZAKZOKN(2) = 0
		dblSZAKZOKN(intZEIRNKKB) = dblSZAKZOKN(intZEIRNKKB) + pin_Tbl_Inf_UDNTRA.ZNKURIKN * pin_intSMFKB
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSB "
		strSQL = strSQL & "    SET SSAURIKN09 = SSAURIKN09 - " & CStr(pin_Tbl_Inf_UDNTRA.ZKMUZEKN) '����W�v���z09
		strSQL = strSQL & "      , SZAKZIKN00 = SZAKZIKN00 + " & CStr(dblSZAKZIKN(0)) '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , SZAKZIKN01 = SZAKZIKN01 + " & CStr(dblSZAKZIKN(1)) '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , SZAKZIKN02 = SZAKZIKN02 + " & CStr(dblSZAKZIKN(2)) '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , SZAKZOKN00 = SZAKZOKN00 + " & CStr(dblSZAKZOKN(0)) '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , SZAKZOKN01 = SZAKZOKN01 + " & CStr(dblSZAKZOKN(1)) '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , SZAKZOKN02 = SZAKZOKN02 + " & CStr(dblSZAKZOKN(2)) '�����N�ʐŔ��ېŋ��z02
		'strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' "                 '��ѽ����(����)
		'strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' "                 '��ѽ����(���t)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SSADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '�����t
		strSQL = strSQL & "    AND SSADT = '" & pv_strSSADT & "' " '�����t
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSSB_UpdateRANK_err
		End If
		
		F_TOKSSB_UpdateRANK = 0
		
F_TOKSSB_UpdateRANK_end: 
		Exit Function
		
F_TOKSSB_UpdateRANK_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSB_UpdateRANK")
		GoTo F_TOKSSB_UpdateRANK_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSSB_UpdateDENSU
	'   �T�v�F  �O�󐿋��T�}���X�V�i�`�[�������J�E���g�A�b�v�j
	'   �����F  pm_All             : ��ʏ��
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSB_UpdateDENSU(ByRef pm_All As Cls_All, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSSB_UpdateDENSU_err
		
		F_TOKSSB_UpdateDENSU = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSB "
		strSQL = strSQL & "    SET SSADENSU = SSADENSU + " & CStr(pin_intSMFKB) '�`�[����
		'strSQL = strSQL & "      , WRTTM = '" & GCF_Ora_String(GV_SysTime, 6) & "' "                '��ѽ����(����)
		'strSQL = strSQL & "      , WRTDT = '" & GCF_Ora_String(GV_SysDate, 8) & "' "                '��ѽ����(���t)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SSADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '�����t
		strSQL = strSQL & "    AND SSADT = '" & pv_strSSADT & "' " '�����t
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSSB_UpdateDENSU_err
		End If
		
		F_TOKSSB_UpdateDENSU = 0
		
F_TOKSSB_UpdateDENSU_end: 
		Exit Function
		
F_TOKSSB_UpdateDENSU_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSB_UpdateDensu")
		GoTo F_TOKSSB_UpdateDENSU_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSSC
	'   �T�v�F  �����T�}���O�ݏ���
	'   �����F  pm_All             : ��ʏ��
	'           pin_intRow         : �s�ԍ�
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSC(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim lngRowCnt As Integer
		
		Dim dblSSCURIKN(9) As Double '����W�v���z
		Dim dblSSCUZEKN As Double '�������ŋ��z
		Dim dblSSCNYUKN(9) As Double '�����W�v���z
		Dim dblFKSZANKN As Double '���������z�c
		
		On Error GoTo F_TOKSSC_err
		
		F_TOKSSC = 9
		
		'����W�v���z
		dblSSCURIKN(0) = 0
		dblSSCURIKN(1) = 0
		dblSSCURIKN(2) = 0
		dblSSCURIKN(3) = 0
		dblSSCURIKN(4) = 0
		dblSSCURIKN(5) = 0
		dblSSCURIKN(6) = 0
		dblSSCURIKN(7) = 0
		dblSSCURIKN(8) = 0
		dblSSCURIKN(9) = 0
		dblSSCURIKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = dblSSCURIKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.FURIKN * pin_intSMFKB
		
		'�������ŋ��z
		dblSSCUZEKN = pin_Tbl_Inf_UDNTRA.UZEKN * pin_intSMFKB
		
		'�����W�v���z
		dblSSCNYUKN(0) = 0
		dblSSCNYUKN(1) = 0
		dblSSCNYUKN(2) = 0
		dblSSCNYUKN(3) = 0
		dblSSCNYUKN(4) = 0
		dblSSCNYUKN(5) = 0
		dblSSCNYUKN(6) = 0
		dblSSCNYUKN(7) = 0
		dblSSCNYUKN(8) = 0
		dblSSCNYUKN(9) = 0
		dblSSCNYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = dblSSCNYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.FNYUKN * pin_intSMFKB
		
		'���������z�c
		dblFKSZANKN = pin_Tbl_Inf_UDNTRA.FNYUKN * pin_intSMFKB
		
		'�v�Z���ʂ��X�V����
		If F_TOKSSC_Update(pm_All, pin_Tbl_Inf_UDNTRA, dblSSCURIKN, dblSSCUZEKN, dblSSCNYUKN, dblFKSZANKN, lngRowCnt) <> 0 Then
			GoTo F_TOKSSC_err
		End If
		
		'�X�V�Ώۂ��Ȃ�������A�V�K�o�^����
		If lngRowCnt <= 0 Then
			If F_TOKSSC_Insert(pm_All, pin_Tbl_Inf_UDNTRA, dblSSCURIKN, dblSSCUZEKN, dblSSCNYUKN, dblFKSZANKN) <> 0 Then
				GoTo F_TOKSSC_err
			End If
		End If
		
		'�����N�ʏ���
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) > 0 Then
			If F_TOKSSC_UpdateRANK(pm_All, pin_intSMFKB, pin_Tbl_Inf_UDNTRA) <> 0 Then
				GoTo F_TOKSSC_err
			End If
		End If
		
		'�`�[�������J�E���g�A�b�v
		If pin_intRow = 1 And pin_Tbl_Inf_UDNTRA.DENKB = "1" Then
			If F_TOKSSC_UpdateDENSU(pm_All, pin_intSMFKB, pin_Tbl_Inf_UDNTRA) <> 0 Then
				GoTo F_TOKSSC_err
			End If
		End If
		
		F_TOKSSC = 0
		
F_TOKSSC_end: 
		Exit Function
		
F_TOKSSC_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSC")
		GoTo F_TOKSSC_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSSC_Update
	'   �T�v�F  �����T�}���O�ݍX�V
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'           pin_dblSSCURIKN    : ����W�v���z
	'           pin_dblSSCUZEKN    : �������ŋ��z
	'           pin_dblSSCNYUKN    : �����W�v���z
	'           pin_dblFKSZANKN    : ���������z�c
	'           pot_lngRowCnt      : �X�V����
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSC_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_dblSSCURIKN() As Double, ByVal pin_dblSSCUZEKN As Double, ByRef pin_dblSSCNYUKN() As Double, ByVal pin_dblFKSZANKN As Double, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSSC_Update_err
		
		F_TOKSSC_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSC "
		strSQL = strSQL & "    SET KESDT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.KESDT, 8) & "' " '���ϓ��t
		strSQL = strSQL & "      , SSCURIKN00 = SSCURIKN00 + " & CStr(pin_dblSSCURIKN(0)) '����W�v���z00
		strSQL = strSQL & "      , SSCURIKN01 = SSCURIKN01 + " & CStr(pin_dblSSCURIKN(1)) '����W�v���z01
		strSQL = strSQL & "      , SSCURIKN02 = SSCURIKN02 + " & CStr(pin_dblSSCURIKN(2)) '����W�v���z02
		strSQL = strSQL & "      , SSCURIKN03 = SSCURIKN03 + " & CStr(pin_dblSSCURIKN(3)) '����W�v���z03
		strSQL = strSQL & "      , SSCURIKN04 = SSCURIKN04 + " & CStr(pin_dblSSCURIKN(4)) '����W�v���z04
		strSQL = strSQL & "      , SSCURIKN05 = SSCURIKN05 + " & CStr(pin_dblSSCURIKN(5)) '����W�v���z05
		strSQL = strSQL & "      , SSCURIKN06 = SSCURIKN06 + " & CStr(pin_dblSSCURIKN(6)) '����W�v���z06
		strSQL = strSQL & "      , SSCURIKN07 = SSCURIKN07 + " & CStr(pin_dblSSCURIKN(7)) '����W�v���z07
		strSQL = strSQL & "      , SSCURIKN08 = SSCURIKN08 + " & CStr(pin_dblSSCURIKN(8)) '����W�v���z08
		strSQL = strSQL & "      , SSCURIKN09 = SSCURIKN09 + " & CStr(pin_dblSSCURIKN(9)) '����W�v���z09
		strSQL = strSQL & "      , SSCUZEKN   = SSCUZEKN   + " & CStr(pin_dblSSCUZEKN) '�������ŋ��z
		strSQL = strSQL & "      , SSCNYUKN00 = SSCNYUKN00 + " & CStr(pin_dblSSCNYUKN(0)) '�����W�v���z00
		strSQL = strSQL & "      , SSCNYUKN01 = SSCNYUKN01 + " & CStr(pin_dblSSCNYUKN(1)) '�����W�v���z01
		strSQL = strSQL & "      , SSCNYUKN02 = SSCNYUKN02 + " & CStr(pin_dblSSCNYUKN(2)) '�����W�v���z02
		strSQL = strSQL & "      , SSCNYUKN03 = SSCNYUKN03 + " & CStr(pin_dblSSCNYUKN(3)) '�����W�v���z03
		strSQL = strSQL & "      , SSCNYUKN04 = SSCNYUKN04 + " & CStr(pin_dblSSCNYUKN(4)) '�����W�v���z04
		strSQL = strSQL & "      , SSCNYUKN05 = SSCNYUKN05 + " & CStr(pin_dblSSCNYUKN(5)) '�����W�v���z05
		strSQL = strSQL & "      , SSCNYUKN06 = SSCNYUKN06 + " & CStr(pin_dblSSCNYUKN(6)) '�����W�v���z06
		strSQL = strSQL & "      , SSCNYUKN07 = SSCNYUKN07 + " & CStr(pin_dblSSCNYUKN(7)) '�����W�v���z07
		strSQL = strSQL & "      , SSCNYUKN08 = SSCNYUKN08 + " & CStr(pin_dblSSCNYUKN(8)) '�����W�v���z08
		strSQL = strSQL & "      , SSCNYUKN09 = SSCNYUKN09 + " & CStr(pin_dblSSCNYUKN(9)) '�����W�v���z09
		strSQL = strSQL & "      , FKSZANKN   = FKSZANKN   + " & CStr(pin_dblFKSZANKN) '���������z�c
		'2009/06/10 DEL START FKS)NAKATA
		'strSQL = strSQL & "      , DATNO      = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.DATNO, 10) & "' "  '�`�[�Ǘ�NO.
		'2009/06/10 DEL E.N.D FKS)NAKATA
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "    AND TUKKB = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TUKKB, 3) & "' " '�ʉ݋敪
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SSADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "        '�����t
		strSQL = strSQL & "    AND SSADT = '" & pv_strSSADT & "' " '�����t
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_TOKSSC_Update_err
		End If
		
		F_TOKSSC_Update = 0
		
F_TOKSSC_Update_end: 
		Exit Function
		
F_TOKSSC_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSC_Update")
		GoTo F_TOKSSC_Update_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSSC_Insert
	'   �T�v�F  �����T�}���O�ݐV�K�o�^
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'           pin_dblSSCURIKN    : ����W�v���z
	'           pin_dblSSCUZEKN    : �������ŋ��z
	'           pin_dblSSCNYUKN    : �����W�v���z
	'           pin_dblFKSZANKN    : ���������z�c
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSC_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_dblSSCURIKN() As Double, ByVal pin_dblSSCUZEKN As Double, ByRef pin_dblSSCNYUKN() As Double, ByVal pin_dblFKSZANKN As Double) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSSC_Insert_err
		
		F_TOKSSC_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSSC "
		strSQL = strSQL & "        ( TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "        , TUKKB " '�ʉ݋敪
		strSQL = strSQL & "        , SSADT " '�����t
		strSQL = strSQL & "        , KESDT " '���ϓ��t
		strSQL = strSQL & "        , SSCURIKN00 " '����W�v���z00
		strSQL = strSQL & "        , SSCURIKN01 " '����W�v���z01
		strSQL = strSQL & "        , SSCURIKN02 " '����W�v���z02
		strSQL = strSQL & "        , SSCURIKN03 " '����W�v���z03
		strSQL = strSQL & "        , SSCURIKN04 " '����W�v���z04
		strSQL = strSQL & "        , SSCURIKN05 " '����W�v���z05
		strSQL = strSQL & "        , SSCURIKN06 " '����W�v���z06
		strSQL = strSQL & "        , SSCURIKN07 " '����W�v���z07
		strSQL = strSQL & "        , SSCURIKN08 " '����W�v���z08
		strSQL = strSQL & "        , SSCURIKN09 " '����W�v���z09
		strSQL = strSQL & "        , SSCUZEKN " '�������ŋ��z
		strSQL = strSQL & "        , FAKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "        , FAKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "        , FAKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "        , FAKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "        , FAKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "        , FAKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "        , FBKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "        , FBKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "        , FBKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "        , FBKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "        , FBKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "        , FBKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "        , SSCNYUKN00 " '�����W�v���z00
		strSQL = strSQL & "        , SSCNYUKN01 " '�����W�v���z01
		strSQL = strSQL & "        , SSCNYUKN02 " '�����W�v���z02
		strSQL = strSQL & "        , SSCNYUKN03 " '�����W�v���z03
		strSQL = strSQL & "        , SSCNYUKN04 " '�����W�v���z04
		strSQL = strSQL & "        , SSCNYUKN05 " '�����W�v���z05
		strSQL = strSQL & "        , SSCNYUKN06 " '�����W�v���z06
		strSQL = strSQL & "        , SSCNYUKN07 " '�����W�v���z07
		strSQL = strSQL & "        , SSCNYUKN08 " '�����W�v���z08
		strSQL = strSQL & "        , SSCNYUKN09 " '�����W�v���z09
		strSQL = strSQL & "        , FKSNYKKN " '���������z
		strSQL = strSQL & "        , FKSZANKN " '���������z�c
		strSQL = strSQL & "        , SSCDENSU " '�`�[����
		strSQL = strSQL & "        , DATNO " '�`�[�Ǘ�NO.
		strSQL = strSQL & "        , WRTTM " '��ѽ����(����)
		strSQL = strSQL & "        , WRTDT " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TUKKB, 3) & "' " '�ʉ݋敪
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '�����t
		strSQL = strSQL & "        , '" & pv_strSSADT & "' " '�����t
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.KESDT, 8) & "' " '���ϓ��t
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(0)) '����W�v���z00
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(1)) '����W�v���z01
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(2)) '����W�v���z02
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(3)) '����W�v���z03
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(4)) '����W�v���z04
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(5)) '����W�v���z05
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(6)) '����W�v���z06
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(7)) '����W�v���z07
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(8)) '����W�v���z08
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(9)) '����W�v���z09
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCUZEKN) '�������ŋ��z
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(0)) '�����W�v���z00
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(1)) '�����W�v���z01
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(2)) '�����W�v���z02
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(3)) '�����W�v���z03
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(4)) '�����W�v���z04
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(5)) '�����W�v���z05
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(6)) '�����W�v���z06
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(7)) '�����W�v���z07
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(8)) '�����W�v���z08
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(9)) '�����W�v���z09
		strSQL = strSQL & "        , 0 " '���������z
		strSQL = strSQL & "        ,  " & CStr(pin_dblFKSZANKN) '���������z�c
		strSQL = strSQL & "        , 0 " '�`�[����
		'2009/06/10 CHG START FKS)NAKATA
		'strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.DATNO, 10) & "' "  '�`�[�Ǘ�NO.
		strSQL = strSQL & "        , '" & Space(10) & "' " '�`�[�Ǘ�NO.
		'2009/06/10 CHG E.N.D FKS)NAKATA
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSSC_Insert_err
		End If
		
		F_TOKSSC_Insert = 0
		
F_TOKSSC_Insert_end: 
		Exit Function
		
F_TOKSSC_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSC_Insert")
		GoTo F_TOKSSC_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSSC_UpdateRANK
	'   �T�v�F  �����T�}���O�ݍX�V�i�����N�ʏ����j
	'   �����F  pm_All             : ��ʏ��
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSC_UpdateRANK(ByRef pm_All As Cls_All, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		Dim dblFAKZIKN(2) As Double '�����N�ʐō��ېŋ��z
		Dim dblFAKZOKN(2) As Double '�����N�ʐŔ��ېŋ��z
		Dim intZEIRNKKB As Short
		
		On Error GoTo F_TOKSSC_UpdateRANK_err
		
		F_TOKSSC_UpdateRANK = 9
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		intZEIRNKKB = SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) - 1
		
		'�����N�ʐō��ېŋ��z
		dblFAKZIKN(0) = 0
		dblFAKZIKN(1) = 0
		dblFAKZIKN(2) = 0
		dblFAKZIKN(intZEIRNKKB) = dblFAKZIKN(intZEIRNKKB) + pin_Tbl_Inf_UDNTRA.ZKMURIKN * pin_intSMFKB
		
		'�����N�ʐŔ��ېŋ��z
		dblFAKZOKN(0) = 0
		dblFAKZOKN(1) = 0
		dblFAKZOKN(2) = 0
		dblFAKZOKN(intZEIRNKKB) = dblFAKZOKN(intZEIRNKKB) + pin_Tbl_Inf_UDNTRA.ZNKURIKN * pin_intSMFKB
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSC "
		strSQL = strSQL & "    SET SSCURIKN09 = SSCURIKN09 - " & CStr(pin_Tbl_Inf_UDNTRA.ZKMUZEKN) '����W�v���z09
		strSQL = strSQL & "      , FAKZIKN00  = FAKZIKN00  + " & CStr(dblFAKZIKN(0)) '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , FAKZIKN01  = FAKZIKN01  + " & CStr(dblFAKZIKN(1)) '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , FAKZIKN02  = FAKZIKN02  + " & CStr(dblFAKZIKN(2)) '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , FAKZOKN00  = FAKZOKN00  + " & CStr(dblFAKZOKN(0)) '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , FAKZOKN01  = FAKZOKN01  + " & CStr(dblFAKZOKN(1)) '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , FAKZOKN02  = FAKZOKN02  + " & CStr(dblFAKZOKN(2)) '�����N�ʐŔ��ېŋ��z02
		'strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' "                 '��ѽ����(����)
		'strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' "                 '��ѽ����(���t)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "    AND TUKKB = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TUKKB, 3) & "' " '�ʉ݋敪
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SSADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '�����t
		strSQL = strSQL & "    AND SSADT = '" & pv_strSSADT & "' " '�����t
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSSC_UpdateRANK_err
		End If
		
		F_TOKSSC_UpdateRANK = 0
		
F_TOKSSC_UpdateRANK_end: 
		Exit Function
		
F_TOKSSC_UpdateRANK_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSC_UpdateRANK")
		GoTo F_TOKSSC_UpdateRANK_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSSC_UpdateDENSU
	'   �T�v�F  �����T�}���O�ݍX�V�i�`�[�������J�E���g�A�b�v�j
	'   �����F  pm_All             : ��ʏ��
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSC_UpdateDENSU(ByRef pm_All As Cls_All, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSSC_UpdateDENSU_err
		
		F_TOKSSC_UpdateDENSU = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSC "
		strSQL = strSQL & "    SET SSCDENSU = SSCDENSU + " & CStr(pin_intSMFKB) '�`�[����
		'strSQL = strSQL & "      , WRTTM = '" & GCF_Ora_String(GV_SysTime, 6) & "' "                '��ѽ����(����)
		'strSQL = strSQL & "      , WRTDT = '" & GCF_Ora_String(GV_SysDate, 8) & "' "                '��ѽ����(���t)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "    AND TUKKB = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TUKKB, 3) & "' " '�ʉ݋敪
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SSADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '�����t
		strSQL = strSQL & "    AND SSADT = '" & pv_strSSADT & "' " '�����t
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSSC_UpdateDENSU_err
		End If
		
		F_TOKSSC_UpdateDENSU = 0
		
F_TOKSSC_UpdateDENSU_end: 
		Exit Function
		
F_TOKSSC_UpdateDENSU_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSC_UpdateDENSU")
		GoTo F_TOKSSC_UpdateDENSU_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSME
	'   �T�v�F  ���|�T�}����������
	'   �����F  pm_All             : ��ʏ��
	'           pin_intRow         : �s�ԍ�
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSME(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim lngRowCnt As Integer
		
		Dim curSMAURIKN(9) As Decimal '����W�v���z
		Dim curSMAUZEKN As Decimal '�������ŋ��z
		Dim curSMAGNKKN(9) As Decimal '�����W�v���z
		Dim curSMANYUKN(9) As Decimal '�����W�v���z
		
		On Error GoTo F_TOKSME_err
		
		F_TOKSME = 9
		
		'����W�v���z
		curSMAURIKN(0) = 0
		curSMAURIKN(1) = 0
		curSMAURIKN(2) = 0
		curSMAURIKN(3) = 0
		curSMAURIKN(4) = 0
		curSMAURIKN(5) = 0
		curSMAURIKN(6) = 0
		curSMAURIKN(7) = 0
		curSMAURIKN(8) = 0
		curSMAURIKN(9) = 0
		curSMAURIKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSMAURIKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.URIKN * pin_intSMFKB
		
		'�������ŋ��z
		curSMAUZEKN = pin_Tbl_Inf_UDNTRA.UZEKN * pin_intSMFKB
		
		'�����W�v���z
		curSMAGNKKN(0) = 0
		curSMAGNKKN(1) = 0
		curSMAGNKKN(2) = 0
		curSMAGNKKN(3) = 0
		curSMAGNKKN(4) = 0
		curSMAGNKKN(5) = 0
		curSMAGNKKN(6) = 0
		curSMAGNKKN(7) = 0
		curSMAGNKKN(8) = 0
		curSMAGNKKN(9) = 0
		curSMAGNKKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSMAGNKKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.GNKKN * pin_intSMFKB
		
		'�����W�v���z
		curSMANYUKN(0) = 0
		curSMANYUKN(1) = 0
		curSMANYUKN(2) = 0
		curSMANYUKN(3) = 0
		curSMANYUKN(4) = 0
		curSMANYUKN(5) = 0
		curSMANYUKN(6) = 0
		curSMANYUKN(7) = 0
		curSMANYUKN(8) = 0
		curSMANYUKN(9) = 0
		curSMANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSMANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.NYUKN * pin_intSMFKB
		
		'�v�Z���ʂ��X�V����
		If F_TOKSME_Update(pm_All, pin_Tbl_Inf_UDNTRA, curSMAURIKN, curSMAUZEKN, curSMAGNKKN, curSMANYUKN, lngRowCnt) <> 0 Then
			GoTo F_TOKSME_err
		End If
		
		'�X�V�Ώۂ��Ȃ�������A�V�K�o�^����
		If lngRowCnt <= 0 Then
			If F_TOKSME_Insert(pm_All, pin_Tbl_Inf_UDNTRA, curSMAURIKN, curSMAUZEKN, curSMAGNKKN, curSMANYUKN) <> 0 Then
				GoTo F_TOKSME_err
			End If
		End If
		
		'�����N�ʏ���
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) > 0 Then
			If F_TOKSME_UpdateRANK(pm_All, pin_intSMFKB, pin_Tbl_Inf_UDNTRA) <> 0 Then
				GoTo F_TOKSME_err
			End If
		End If
		
		F_TOKSME = 0
		
F_TOKSME_end: 
		Exit Function
		
F_TOKSME_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSME")
		GoTo F_TOKSME_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSME_Update
	'   �T�v�F  ���|�T�}�������X�V
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'           pin_curSMAURIKN    : ����W�v���z
	'           pin_curSMAUZEKN    : �������ŋ��z
	'           pin_curSMAGNKKN    : �����W�v���z
	'           pin_curSMANYUKN    : �����W�v���z
	'           pot_lngRowCnt      : �X�V����
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSME_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSMAURIKN() As Decimal, ByVal pin_curSMAUZEKN As Decimal, ByRef pin_curSMAGNKKN() As Decimal, ByRef pin_curSMANYUKN() As Decimal, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSME_Update_err
		
		F_TOKSME_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSME "
		strSQL = strSQL & "    SET SMAURIKN00 = SMAURIKN00 + " & CStr(pin_curSMAURIKN(0)) '����W�v���z00
		strSQL = strSQL & "      , SMAURIKN01 = SMAURIKN01 + " & CStr(pin_curSMAURIKN(1)) '����W�v���z01
		strSQL = strSQL & "      , SMAURIKN02 = SMAURIKN02 + " & CStr(pin_curSMAURIKN(2)) '����W�v���z02
		strSQL = strSQL & "      , SMAURIKN03 = SMAURIKN03 + " & CStr(pin_curSMAURIKN(3)) '����W�v���z03
		strSQL = strSQL & "      , SMAURIKN04 = SMAURIKN04 + " & CStr(pin_curSMAURIKN(4)) '����W�v���z04
		strSQL = strSQL & "      , SMAURIKN05 = SMAURIKN05 + " & CStr(pin_curSMAURIKN(5)) '����W�v���z05
		strSQL = strSQL & "      , SMAURIKN06 = SMAURIKN06 + " & CStr(pin_curSMAURIKN(6)) '����W�v���z06
		strSQL = strSQL & "      , SMAURIKN07 = SMAURIKN07 + " & CStr(pin_curSMAURIKN(7)) '����W�v���z07
		strSQL = strSQL & "      , SMAURIKN08 = SMAURIKN08 + " & CStr(pin_curSMAURIKN(8)) '����W�v���z08
		strSQL = strSQL & "      , SMAURIKN09 = SMAURIKN09 + " & CStr(pin_curSMAURIKN(9)) '����W�v���z09
		strSQL = strSQL & "      , SMAUZEKN   = SMAUZEKN   + " & CStr(pin_curSMAUZEKN) '�������ŋ��z
		strSQL = strSQL & "      , SMAGNKKN00 = SMAGNKKN00 + " & CStr(pin_curSMAGNKKN(0)) '�����W�v���z00
		strSQL = strSQL & "      , SMAGNKKN01 = SMAGNKKN01 + " & CStr(pin_curSMAGNKKN(1)) '�����W�v���z01
		strSQL = strSQL & "      , SMAGNKKN02 = SMAGNKKN02 + " & CStr(pin_curSMAGNKKN(2)) '�����W�v���z02
		strSQL = strSQL & "      , SMAGNKKN03 = SMAGNKKN03 + " & CStr(pin_curSMAGNKKN(3)) '�����W�v���z03
		strSQL = strSQL & "      , SMAGNKKN04 = SMAGNKKN04 + " & CStr(pin_curSMAGNKKN(4)) '�����W�v���z04
		strSQL = strSQL & "      , SMAGNKKN05 = SMAGNKKN05 + " & CStr(pin_curSMAGNKKN(5)) '�����W�v���z05
		strSQL = strSQL & "      , SMAGNKKN06 = SMAGNKKN06 + " & CStr(pin_curSMAGNKKN(6)) '�����W�v���z06
		strSQL = strSQL & "      , SMAGNKKN07 = SMAGNKKN07 + " & CStr(pin_curSMAGNKKN(7)) '�����W�v���z07
		strSQL = strSQL & "      , SMAGNKKN08 = SMAGNKKN08 + " & CStr(pin_curSMAGNKKN(8)) '�����W�v���z08
		strSQL = strSQL & "      , SMAGNKKN09 = SMAGNKKN09 + " & CStr(pin_curSMAGNKKN(9)) '�����W�v���z09
		strSQL = strSQL & "      , SMANYUKN00 = SMANYUKN00 + " & CStr(pin_curSMANYUKN(0)) '�����W�v���z00
		strSQL = strSQL & "      , SMANYUKN01 = SMANYUKN01 + " & CStr(pin_curSMANYUKN(1)) '�����W�v���z01
		strSQL = strSQL & "      , SMANYUKN02 = SMANYUKN02 + " & CStr(pin_curSMANYUKN(2)) '�����W�v���z02
		strSQL = strSQL & "      , SMANYUKN03 = SMANYUKN03 + " & CStr(pin_curSMANYUKN(3)) '�����W�v���z03
		strSQL = strSQL & "      , SMANYUKN04 = SMANYUKN04 + " & CStr(pin_curSMANYUKN(4)) '�����W�v���z04
		strSQL = strSQL & "      , SMANYUKN05 = SMANYUKN05 + " & CStr(pin_curSMANYUKN(5)) '�����W�v���z05
		strSQL = strSQL & "      , SMANYUKN06 = SMANYUKN06 + " & CStr(pin_curSMANYUKN(6)) '�����W�v���z06
		strSQL = strSQL & "      , SMANYUKN07 = SMANYUKN07 + " & CStr(pin_curSMANYUKN(7)) '�����W�v���z07
		strSQL = strSQL & "      , SMANYUKN08 = SMANYUKN08 + " & CStr(pin_curSMANYUKN(8)) '�����W�v���z08
		strSQL = strSQL & "      , SMANYUKN09 = SMANYUKN09 + " & CStr(pin_curSMANYUKN(9)) '�����W�v���z09
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SMADT, 8) & "' " '�o�������t
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_TOKSME_Update_err
		End If
		
		F_TOKSME_Update = 0
		
F_TOKSME_Update_end: 
		Exit Function
		
F_TOKSME_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSME_Update")
		GoTo F_TOKSME_Update_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSME_Insert
	'   �T�v�F  ���|�T�}�������V�K�o�^
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'           pin_curSMAURIKN    : ����W�v���z
	'           pin_curSMAUZEKN    : �������ŋ��z
	'           pin_curSMAGNKKN    : �����W�v���z
	'           pin_curSMANYUKN    : �����W�v���z
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSME_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSMAURIKN() As Decimal, ByVal pin_curSMAUZEKN As Decimal, ByRef pin_curSMAGNKKN() As Decimal, ByRef pin_curSMANYUKN() As Decimal) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSME_Insert_err
		
		F_TOKSME_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSME "
		strSQL = strSQL & "        ( TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "        , SMADT " '�o�������t
		strSQL = strSQL & "        , SMAURIKN00 " '����W�v���z00
		strSQL = strSQL & "        , SMAURIKN01 " '����W�v���z01
		strSQL = strSQL & "        , SMAURIKN02 " '����W�v���z02
		strSQL = strSQL & "        , SMAURIKN03 " '����W�v���z03
		strSQL = strSQL & "        , SMAURIKN04 " '����W�v���z04
		strSQL = strSQL & "        , SMAURIKN05 " '����W�v���z05
		strSQL = strSQL & "        , SMAURIKN06 " '����W�v���z06
		strSQL = strSQL & "        , SMAURIKN07 " '����W�v���z07
		strSQL = strSQL & "        , SMAURIKN08 " '����W�v���z08
		strSQL = strSQL & "        , SMAURIKN09 " '����W�v���z09
		strSQL = strSQL & "        , SMAUZEKN " '�������ŋ��z
		strSQL = strSQL & "        , SZAKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "        , SZAKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "        , SZAKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "        , SZAKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "        , SZAKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "        , SZAKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "        , SZBKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "        , SZBKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "        , SZBKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "        , SZBKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "        , SZBKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "        , SZBKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "        , SMAGNKKN00 " '�����W�v���z00
		strSQL = strSQL & "        , SMAGNKKN01 " '�����W�v���z01
		strSQL = strSQL & "        , SMAGNKKN02 " '�����W�v���z02
		strSQL = strSQL & "        , SMAGNKKN03 " '�����W�v���z03
		strSQL = strSQL & "        , SMAGNKKN04 " '�����W�v���z04
		strSQL = strSQL & "        , SMAGNKKN05 " '�����W�v���z05
		strSQL = strSQL & "        , SMAGNKKN06 " '�����W�v���z06
		strSQL = strSQL & "        , SMAGNKKN07 " '�����W�v���z07
		strSQL = strSQL & "        , SMAGNKKN08 " '�����W�v���z08
		strSQL = strSQL & "        , SMAGNKKN09 " '�����W�v���z09
		strSQL = strSQL & "        , SMANYUKN00 " '�����W�v���z00
		strSQL = strSQL & "        , SMANYUKN01 " '�����W�v���z01
		strSQL = strSQL & "        , SMANYUKN02 " '�����W�v���z02
		strSQL = strSQL & "        , SMANYUKN03 " '�����W�v���z03
		strSQL = strSQL & "        , SMANYUKN04 " '�����W�v���z04
		strSQL = strSQL & "        , SMANYUKN05 " '�����W�v���z05
		strSQL = strSQL & "        , SMANYUKN06 " '�����W�v���z06
		strSQL = strSQL & "        , SMANYUKN07 " '�����W�v���z07
		strSQL = strSQL & "        , SMANYUKN08 " '�����W�v���z08
		strSQL = strSQL & "        , SMANYUKN09 " '�����W�v���z09
		strSQL = strSQL & "        , DATNO " '�`�[�Ǘ�NO.
		strSQL = strSQL & "        , WRTTM " '��ѽ����(����)
		strSQL = strSQL & "        , WRTDT " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SMADT, 8) & "' " '�o�������t
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(0)) '����W�v���z00
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(1)) '����W�v���z01
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(2)) '����W�v���z02
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(3)) '����W�v���z03
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(4)) '����W�v���z04
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(5)) '����W�v���z05
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(6)) '����W�v���z06
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(7)) '����W�v���z07
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(8)) '����W�v���z08
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(9)) '����W�v���z09
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAUZEKN) '�������ŋ��z
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "        ,  0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "        ,  0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(0)) '�����W�v���z00
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(1)) '�����W�v���z01
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(2)) '�����W�v���z02
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(3)) '�����W�v���z03
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(4)) '�����W�v���z04
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(5)) '�����W�v���z05
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(6)) '�����W�v���z06
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(7)) '�����W�v���z07
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(8)) '�����W�v���z08
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(9)) '�����W�v���z09
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(0)) '�����W�v���z00
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(1)) '�����W�v���z01
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(2)) '�����W�v���z02
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(3)) '�����W�v���z03
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(4)) '�����W�v���z04
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(5)) '�����W�v���z05
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(6)) '�����W�v���z06
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(7)) '�����W�v���z07
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(8)) '�����W�v���z08
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(9)) '�����W�v���z09
		strSQL = strSQL & "        , '" & Space(10) & "' " '�`�[�Ǘ�NO.
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSME_Insert_err
		End If
		
		F_TOKSME_Insert = 0
		
F_TOKSME_Insert_end: 
		Exit Function
		
F_TOKSME_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSME_Insert")
		GoTo F_TOKSME_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TOKSME_UpdateRANK
	'   �T�v�F  ���|�T�}�������X�V�i�����N�ʏ����j
	'   �����F  pm_All             : ��ʏ��
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSME_UpdateRANK(ByRef pm_All As Cls_All, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		Dim dblSZAKZIKN(2) As Double '�����N�ʐō��ېŋ��z
		Dim dblSZAKZOKN(2) As Double '�����N�ʐŔ��ېŋ��z
		Dim intZEIRNKKB As Short
		
		On Error GoTo F_TOKSME_UpdateRANK_err
		
		F_TOKSME_UpdateRANK = 9
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		intZEIRNKKB = SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) - 1
		
		'�����N�ʐō��ېŋ��z
		dblSZAKZIKN(0) = 0
		dblSZAKZIKN(1) = 0
		dblSZAKZIKN(2) = 0
		dblSZAKZIKN(intZEIRNKKB) = dblSZAKZIKN(intZEIRNKKB) + pin_Tbl_Inf_UDNTRA.ZKMURIKN * pin_intSMFKB
		
		'�����N�ʐŔ��ېŋ��z
		dblSZAKZOKN(0) = 0
		dblSZAKZOKN(1) = 0
		dblSZAKZOKN(2) = 0
		dblSZAKZOKN(intZEIRNKKB) = dblSZAKZOKN(intZEIRNKKB) + pin_Tbl_Inf_UDNTRA.ZNKURIKN * pin_intSMFKB
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSME "
		strSQL = strSQL & "    SET SMAURIKN09 = SMAURIKN09 - " & CStr(pin_Tbl_Inf_UDNTRA.ZKMUZEKN) '����W�v���z09
		strSQL = strSQL & "      , SZAKZIKN00 = SZAKZIKN00 + " & CStr(dblSZAKZIKN(0)) '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , SZAKZIKN01 = SZAKZIKN01 + " & CStr(dblSZAKZIKN(1)) '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , SZAKZIKN02 = SZAKZIKN02 + " & CStr(dblSZAKZIKN(2)) '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , SZAKZOKN00 = SZAKZOKN00 + " & CStr(dblSZAKZOKN(0)) '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , SZAKZOKN01 = SZAKZOKN01 + " & CStr(dblSZAKZOKN(1)) '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , SZAKZOKN02 = SZAKZOKN02 + " & CStr(dblSZAKZOKN(2)) '�����N�ʐŔ��ېŋ��z02
		'strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' "       '��ѽ����(����)
		'strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' "       '��ѽ����(���t)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SMADT, 8) & "' " '�o�������t
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSME_UpdateRANK_err
		End If
		
		F_TOKSME_UpdateRANK = 0
		
F_TOKSME_UpdateRANK_end: 
		Exit Function
		
F_TOKSME_UpdateRANK_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSME_UpdateRANK")
		GoTo F_TOKSME_UpdateRANK_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_UTGTRA
	'   �T�v�F  ����`�g����
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UTGTRA(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		Dim intRet As Short
		Dim lngRowCnt As Integer
		
		On Error GoTo F_UTGTRA_err
		
		F_UTGTRA = 9
		
		'�g�p�\�����`�[�̃��R�[�h�����쐬
		If pin_Tbl_Inf_UDNTRA.DATKB = gc_strDATKB_USE And pin_Tbl_Inf_UDNTRA.AKAKROKB = gc_strAKAKROKB_KURO Then
			'�X�V
			intRet = F_UTGTRA_Update(pm_All, pin_Tbl_Inf_UDNTRA, lngRowCnt)
			If intRet <> 0 Then
				GoTo F_UTGTRA_err
			End If
			
			If lngRowCnt <= 0 Then
				'�V�K�쐬
				intRet = F_UTGTRA_Insert(pm_All, pin_Tbl_Inf_UDNTRA)
				If intRet <> 0 Then
					GoTo F_UTGTRA_err
				End If
			End If
		End If
		
		'    If pin_Tbl_Inf_UDNTRA.DATKB = gc_strDATKB_DEL Then
		'        '�폜
		'        intRet = F_UTGTRA_Delete(pm_All, pin_Tbl_Inf_UDNTRA)
		'        If intRet <> 0 Then
		'            GoTo F_UTGTRA_err
		'        End If
		'    Else
		'        '�X�V
		'        intRet = F_UTGTRA_Update(pm_All, pin_Tbl_Inf_UDNTRA, lngRowCnt)
		'        If intRet <> 0 Then
		'            GoTo F_UTGTRA_err
		'        End If
		'
		'        If lngRowCnt <= 0 Then
		'            '�V�K�쐬
		'            intRet = F_UTGTRA_Insert(pm_All, pin_Tbl_Inf_UDNTRA)
		'            If intRet <> 0 Then
		'                GoTo F_UTGTRA_err
		'            End If
		'        End If
		'    End If
		
		F_UTGTRA = 0
		
F_UTGTRA_end: 
		Exit Function
		
F_UTGTRA_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UTGTRA")
		GoTo F_UTGTRA_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_UTGTRA_Delete
	'   �T�v�F  ����`�g�����폜
	'   �����F  pm_All             : ��ʏ��
	'           pin_strUDNNO       : ����`�[�ԍ�
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UTGTRA_Delete(ByRef pm_All As Cls_All, ByVal pin_strUDNNO As String) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_UTGTRA_Delete_err
		
		F_UTGTRA_Delete = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " DELETE UTGTRA "
		strSQL = strSQL & "  WHERE NDNNO = '" & CF_Ora_String(pin_strUDNNO, 8) & "' " '����`�[�ԍ�
		
		'    'SQL
		'    strSQL = ""
		'    strSQL = strSQL & " DELETE UTGTRA "
		'    strSQL = strSQL & "  WHERE NDNNO = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.UDNNO, 8) & "' "  '����`�[�ԍ�
		'    strSQL = strSQL & "    AND LINNO = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.LINNO, 3) & "' "  '�s�ԍ�
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_UTGTRA_Delete_err
		End If
		
		F_UTGTRA_Delete = 0
		
F_UTGTRA_Delete_end: 
		Exit Function
		
F_UTGTRA_Delete_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UTGTRA_Delete")
		GoTo F_UTGTRA_Delete_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_UTGTRA_Update
	'   �T�v�F  ����`�g�����X�V
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'           pot_lngRowCnt      : �X�V����
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UTGTRA_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_UTGTRA_Update_err
		
		F_UTGTRA_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE UTGTRA "
		strSQL = strSQL & "    SET DATNO  = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.DATNO, 10) & "' " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , NDNNO  = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.UDNNO, 8) & "' " '�����`�[�ԍ�
		strSQL = strSQL & "      , LINNO  = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.LINNO, 3) & "' " '�s�ԍ�
		strSQL = strSQL & "      , NDNDT  = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.UDNDT, 8) & "' " '�����`�[���t
		strSQL = strSQL & "      , TOKCD  = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKSEICD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "      , BNKCD  = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.BNKCD, 7) & "' " '��s�R�[�h
		strSQL = strSQL & "      , TEGDT  = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TEGDT, 8) & "' " '��`����
		strSQL = strSQL & "      , TEGNO  = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TEGNO, 10) & "' " '��`�ԍ�
		strSQL = strSQL & "      , TEGKN  = " & CStr(pin_Tbl_Inf_UDNTRA.NYUKN) '��`���z
		strSQL = strSQL & "      , LINCMA = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.LINCMA, 20) & "' " '���ה��l�P
		strSQL = strSQL & "      , LINCMB = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.LINCMB, 20) & "' " '���ה��l�Q
		strSQL = strSQL & "      , UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�UID(�ޯ�)
		strSQL = strSQL & "      , UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�ײ���ID(�ޯ�)
		strSQL = strSQL & "      , UWRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "      , UWRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "      , PGID   = '" & CF_Ora_String(SSS_PrgId, 7) & "' " '�X�VPGID
		strSQL = strSQL & "      , DLFLG  = '" & CF_Ora_String(gc_strDLFLG_UPD, 1) & "' " '�폜�t���O
		strSQL = strSQL & "  WHERE NDNNO = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.UDNNO, 8) & "' " '����`�[�ԍ�
		strSQL = strSQL & "    AND LINNO = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.LINNO, 3) & "' " '�s�ԍ�
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_UTGTRA_Update_err
		End If
		
		F_UTGTRA_Update = 0
		
F_UTGTRA_Update_end: 
		Exit Function
		
F_UTGTRA_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UTGTRA_Update")
		GoTo F_UTGTRA_Update_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_UTGTRA_Insert
	'   �T�v�F  ����`�g�����V�K�o�^
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UTGTRA_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_UTGTRA_Insert_err
		
		F_UTGTRA_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO UTGTRA "
		strSQL = strSQL & "        ( DATNO " '�`�[�Ǘ�NO.
		strSQL = strSQL & "        , NDNNO " '�����`�[�ԍ�
		strSQL = strSQL & "        , LINNO " '�s�ԍ�
		strSQL = strSQL & "        , NDNDT " '�����`�[���t
		strSQL = strSQL & "        , TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "        , BNKCD " '��s�R�[�h
		strSQL = strSQL & "        , TEGDT " '��`����
		strSQL = strSQL & "        , TEGNO " '��`�ԍ�
		strSQL = strSQL & "        , TEGKN " '��`���z
		strSQL = strSQL & "        , LINCMA " '���ה��l�P
		strSQL = strSQL & "        , LINCMB " '���ה��l�Q
		strSQL = strSQL & "        , FOPEID " '����o�^���[�UID
		strSQL = strSQL & "        , FCLTID " '����o�^�N���C�A���gID
		strSQL = strSQL & "        , WRTFSTTM " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "        , WRTFSTDT " '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "        , OPEID " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "        , CLTID " '�N���C�A���g�h�c
		strSQL = strSQL & "        , WRTTM " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "        , WRTDT " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "        , UOPEID " '���[�UID�i�o�b�`�j
		strSQL = strSQL & "        , UCLTID " '�N���C�A���gID�i�o�b�`�j
		strSQL = strSQL & "        , UWRTTM " '�^�C���X�^���v�i�o�b�`���ԁj
		strSQL = strSQL & "        , UWRTDT " '�^�C���X�^���v�i�o�b�`���t�j
		strSQL = strSQL & "        , PGID " '�X�VPGID
		strSQL = strSQL & "        , DLFLG " '�폜�t���O
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.DATNO, 10) & "' " '�`�[�Ǘ�NO.
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.UDNNO, 8) & "' " '�����`�[�ԍ�
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.LINNO, 3) & "' " '�s�ԍ�
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.UDNDT, 8) & "' " '�����`�[���t
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKSEICD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.BNKCD, 7) & "' " '��s�R�[�h
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TEGDT, 8) & "' " '��`����
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TEGNO, 10) & "' " '��`�ԍ�
		strSQL = strSQL & "        ,  " & CStr(pin_Tbl_Inf_UDNTRA.NYUKN) '��`���z
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.LINCMA, 20) & "' " '���ה��l�P
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.LINCMB, 20) & "' " '���ה��l�Q
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '����o�^���[�UID
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '����o�^�N���C�A���gID
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�UID�i�o�b�`�j
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���gID�i�o�b�`�j
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " '�^�C���X�^���v�i�o�b�`���ԁj
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " '�^�C���X�^���v�i�o�b�`���t�j
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_PrgId, 7) & "' " '�X�VPGID
		strSQL = strSQL & "        , '" & CF_Ora_String(gc_strDLFLG_INS, 1) & "' " '�폜�t���O
		strSQL = strSQL & "        ) "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_UTGTRA_Insert_err
		End If
		
		F_UTGTRA_Insert = 0
		
F_UTGTRA_Insert_end: 
		Exit Function
		
F_UTGTRA_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UTGTRA_Insert")
		GoTo F_UTGTRA_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_NKSSMA
	'   �T�v�F  ���������T�}������
	'   �����F  pm_All             : ��ʏ��
	'           pin_intRow         : �s�ԍ�
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMA(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim lngRowCnt As Integer
		
		Dim curSSANYUKN(9) As Decimal '�����W�v���z
		
		On Error GoTo F_NKSSMA_err
		
		F_NKSSMA = 9
		
		'�����W�v���z
		curSSANYUKN(0) = 0
		curSSANYUKN(1) = 0
		curSSANYUKN(2) = 0
		curSSANYUKN(3) = 0
		curSSANYUKN(4) = 0
		curSSANYUKN(5) = 0
		curSSANYUKN(6) = 0
		curSSANYUKN(7) = 0
		curSSANYUKN(8) = 0
		curSSANYUKN(9) = 0
		curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.NYUKN * pin_intSMFKB
		
		'�v�Z���ʂ��X�V����
		If F_NKSSMA_Update(pm_All, pin_Tbl_Inf_UDNTRA, curSSANYUKN, lngRowCnt) <> 0 Then
			GoTo F_NKSSMA_err
		End If
		
		'�X�V�Ώۂ��Ȃ�������A�V�K�o�^����
		If lngRowCnt <= 0 Then
			If F_NKSSMA_Insert(pm_All, pin_Tbl_Inf_UDNTRA, curSSANYUKN) <> 0 Then
				GoTo F_NKSSMA_err
			End If
		End If
		
		F_NKSSMA = 0
		
F_NKSSMA_end: 
		Exit Function
		
F_NKSSMA_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMA")
		GoTo F_NKSSMA_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_NKSSMA_Update
	'   �T�v�F  ���������T�}���X�V
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'           pin_curSSANYUKN    : �����W�v���z
	'           pot_lngRowCnt      : �X�V����
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMA_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSANYUKN() As Decimal, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMA_Update_err
		
		F_NKSSMA_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE NKSSMA "
		strSQL = strSQL & "    SET SSANYUKN00 = SSANYUKN00 + " & CStr(pin_curSSANYUKN(0)) '�����W�v���z00
		strSQL = strSQL & "      , SSANYUKN01 = SSANYUKN01 + " & CStr(pin_curSSANYUKN(1)) '�����W�v���z01
		strSQL = strSQL & "      , SSANYUKN02 = SSANYUKN02 + " & CStr(pin_curSSANYUKN(2)) '�����W�v���z02
		strSQL = strSQL & "      , SSANYUKN03 = SSANYUKN03 + " & CStr(pin_curSSANYUKN(3)) '�����W�v���z03
		strSQL = strSQL & "      , SSANYUKN04 = SSANYUKN04 + " & CStr(pin_curSSANYUKN(4)) '�����W�v���z04
		strSQL = strSQL & "      , SSANYUKN05 = SSANYUKN05 + " & CStr(pin_curSSANYUKN(5)) '�����W�v���z05
		strSQL = strSQL & "      , SSANYUKN06 = SSANYUKN06 + " & CStr(pin_curSSANYUKN(6)) '�����W�v���z06
		strSQL = strSQL & "      , SSANYUKN07 = SSANYUKN07 + " & CStr(pin_curSSANYUKN(7)) '�����W�v���z07
		strSQL = strSQL & "      , SSANYUKN08 = SSANYUKN08 + " & CStr(pin_curSSANYUKN(8)) '�����W�v���z08
		strSQL = strSQL & "      , SSANYUKN09 = SSANYUKN09 + " & CStr(pin_curSSANYUKN(9)) '�����W�v���z09
		strSQL = strSQL & "      , OPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "      , CLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���gID
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		'2009/09/30 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SMADT, 8) & "' "   '�o�������t
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' " '�o�������t
		'2009/09/30 UPD E.N.D RISE)MIYAJIMA
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_NKSSMA_Update_err
		End If
		
		F_NKSSMA_Update = 0
		
F_NKSSMA_Update_end: 
		Exit Function
		
F_NKSSMA_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMA_Update")
		GoTo F_NKSSMA_Update_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_NKSSMA_Insert
	'   �T�v�F  ���������T�}���V�K�o�^
	'   �����F
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMA_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSANYUKN() As Decimal) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMA_Insert_err
		
		F_NKSSMA_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO NKSSMA "
		strSQL = strSQL & "        ( TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "        , SMADT " '�o�������t
		strSQL = strSQL & "        , SSANYUKN00 " '�����W�v���z00
		strSQL = strSQL & "        , SSANYUKN01 " '�����W�v���z01
		strSQL = strSQL & "        , SSANYUKN02 " '�����W�v���z02
		strSQL = strSQL & "        , SSANYUKN03 " '�����W�v���z03
		strSQL = strSQL & "        , SSANYUKN04 " '�����W�v���z04
		strSQL = strSQL & "        , SSANYUKN05 " '�����W�v���z05
		strSQL = strSQL & "        , SSANYUKN06 " '�����W�v���z06
		strSQL = strSQL & "        , SSANYUKN07 " '�����W�v���z07
		strSQL = strSQL & "        , SSANYUKN08 " '�����W�v���z08
		strSQL = strSQL & "        , SSANYUKN09 " '�����W�v���z09
		strSQL = strSQL & "        , KSKNYKKN00 " '���������W�v���z00
		strSQL = strSQL & "        , KSKNYKKN01 " '���������W�v���z01
		strSQL = strSQL & "        , KSKNYKKN02 " '���������W�v���z02
		strSQL = strSQL & "        , KSKNYKKN03 " '���������W�v���z03
		strSQL = strSQL & "        , KSKNYKKN04 " '���������W�v���z04
		strSQL = strSQL & "        , KSKNYKKN05 " '���������W�v���z05
		strSQL = strSQL & "        , KSKNYKKN06 " '���������W�v���z06
		strSQL = strSQL & "        , KSKNYKKN07 " '���������W�v���z07
		strSQL = strSQL & "        , KSKNYKKN08 " '���������W�v���z08
		strSQL = strSQL & "        , KSKNYKKN09 " '���������W�v���z09
		strSQL = strSQL & "        , KSKZANKN00 " '�O�������������z00
		strSQL = strSQL & "        , KSKZANKN01 " '�O�������������z01
		strSQL = strSQL & "        , KSKZANKN02 " '�O�������������z02
		strSQL = strSQL & "        , KSKZANKN03 " '�O�������������z03
		strSQL = strSQL & "        , KSKZANKN04 " '�O�������������z04
		strSQL = strSQL & "        , KSKZANKN05 " '�O�������������z05
		strSQL = strSQL & "        , KSKZANKN06 " '�O�������������z06
		strSQL = strSQL & "        , KSKZANKN07 " '�O�������������z07
		strSQL = strSQL & "        , KSKZANKN08 " '�O�������������z08
		strSQL = strSQL & "        , KSKZANKN09 " '�O�������������z09
		strSQL = strSQL & "        , OPEID " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "        , CLTID " '�N���C�A���gID
		strSQL = strSQL & "        , WRTTM " '��ѽ����(����)
		strSQL = strSQL & "        , WRTDT " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		'2009/09/30 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SMADT, 8) & "' "   '�o�������t
		strSQL = strSQL & "        , '" & CF_Ora_String(pv_strSMADT, 8) & "' " '�o�������t
		'2009/09/30 UPD E.N.D RISE)MIYAJIMA
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(0)) '�����W�v���z00
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(1)) '�����W�v���z01
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(2)) '�����W�v���z02
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(3)) '�����W�v���z03
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(4)) '�����W�v���z04
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(5)) '�����W�v���z05
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(6)) '�����W�v���z06
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(7)) '�����W�v���z07
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(8)) '�����W�v���z08
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(9)) '�����W�v���z09
		strSQL = strSQL & "        ,  0 " '���������W�v���z00
		strSQL = strSQL & "        ,  0 " '���������W�v���z01
		strSQL = strSQL & "        ,  0 " '���������W�v���z02
		strSQL = strSQL & "        ,  0 " '���������W�v���z03
		strSQL = strSQL & "        ,  0 " '���������W�v���z04
		strSQL = strSQL & "        ,  0 " '���������W�v���z05
		strSQL = strSQL & "        ,  0 " '���������W�v���z06
		strSQL = strSQL & "        ,  0 " '���������W�v���z07
		strSQL = strSQL & "        ,  0 " '���������W�v���z08
		strSQL = strSQL & "        ,  0 " '���������W�v���z09
		strSQL = strSQL & "        ,  0 " '�O�������������z00
		strSQL = strSQL & "        ,  0 " '�O�������������z01
		strSQL = strSQL & "        ,  0 " '�O�������������z02
		strSQL = strSQL & "        ,  0 " '�O�������������z03
		strSQL = strSQL & "        ,  0 " '�O�������������z04
		strSQL = strSQL & "        ,  0 " '�O�������������z05
		strSQL = strSQL & "        ,  0 " '�O�������������z06
		strSQL = strSQL & "        ,  0 " '�O�������������z07
		strSQL = strSQL & "        ,  0 " '�O�������������z08
		strSQL = strSQL & "        ,  0 " '�O�������������z09
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���gID
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_NKSSMA_Insert_err
		End If
		
		F_NKSSMA_Insert = 0
		
F_NKSSMA_Insert_end: 
		Exit Function
		
F_NKSSMA_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMA_Insert")
		GoTo F_NKSSMA_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_NKSSMB
	'   �T�v�F  ���������T�}���O�󏈗�
	'   �����F  pm_All             : ��ʏ��
	'           pin_intRow         : �s�ԍ�
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMB(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim lngRowCnt As Integer
		
		Dim curSSANYUKN(9) As Decimal '�����W�v���z
		
		On Error GoTo F_NKSSMB_err
		
		F_NKSSMB = 9
		
		'�����W�v���z
		curSSANYUKN(0) = 0
		curSSANYUKN(1) = 0
		curSSANYUKN(2) = 0
		curSSANYUKN(3) = 0
		curSSANYUKN(4) = 0
		curSSANYUKN(5) = 0
		curSSANYUKN(6) = 0
		curSSANYUKN(7) = 0
		curSSANYUKN(8) = 0
		curSSANYUKN(9) = 0
		curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.NYUKN * pin_intSMFKB
		
		'�v�Z���ʂ��X�V����
		If F_NKSSMB_Update(pm_All, pin_Tbl_Inf_UDNTRA, curSSANYUKN, lngRowCnt) <> 0 Then
			GoTo F_NKSSMB_err
		End If
		
		'�X�V�Ώۂ��Ȃ�������A�V�K�o�^����
		If lngRowCnt <= 0 Then
			If F_NKSSMB_Insert(pm_All, pin_Tbl_Inf_UDNTRA, curSSANYUKN) <> 0 Then
				GoTo F_NKSSMB_err
			End If
		End If
		
		F_NKSSMB = 0
		
F_NKSSMB_end: 
		Exit Function
		
F_NKSSMB_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMB")
		GoTo F_NKSSMB_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_NKSSMB_Update
	'   �T�v�F  ���������T�}���O��X�V
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'           pin_curSSANYUKN    : �����W�v���z
	'           pot_lngRowCnt      : �X�V����
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMB_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSANYUKN() As Decimal, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMB_Update_err
		
		F_NKSSMB_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE NKSSMB "
		strSQL = strSQL & "    SET SSANYUKN00 = SSANYUKN00 + " & CStr(pin_curSSANYUKN(0)) '�����W�v���z00
		strSQL = strSQL & "      , SSANYUKN01 = SSANYUKN01 + " & CStr(pin_curSSANYUKN(1)) '�����W�v���z01
		strSQL = strSQL & "      , SSANYUKN02 = SSANYUKN02 + " & CStr(pin_curSSANYUKN(2)) '�����W�v���z02
		strSQL = strSQL & "      , SSANYUKN03 = SSANYUKN03 + " & CStr(pin_curSSANYUKN(3)) '�����W�v���z03
		strSQL = strSQL & "      , SSANYUKN04 = SSANYUKN04 + " & CStr(pin_curSSANYUKN(4)) '�����W�v���z04
		strSQL = strSQL & "      , SSANYUKN05 = SSANYUKN05 + " & CStr(pin_curSSANYUKN(5)) '�����W�v���z05
		strSQL = strSQL & "      , SSANYUKN06 = SSANYUKN06 + " & CStr(pin_curSSANYUKN(6)) '�����W�v���z06
		strSQL = strSQL & "      , SSANYUKN07 = SSANYUKN07 + " & CStr(pin_curSSANYUKN(7)) '�����W�v���z07
		strSQL = strSQL & "      , SSANYUKN08 = SSANYUKN08 + " & CStr(pin_curSSANYUKN(8)) '�����W�v���z08
		strSQL = strSQL & "      , SSANYUKN09 = SSANYUKN09 + " & CStr(pin_curSSANYUKN(9)) '�����W�v���z09
		strSQL = strSQL & "      , OPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "      , CLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���gID
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		'2009/09/30 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SMADT, 8) & "' "   '�o�������t
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' " '�o�������t
		'2009/09/30 UPD E.N.D RISE)MIYAJIMA
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_NKSSMB_Update_err
		End If
		
		F_NKSSMB_Update = 0
		
F_NKSSMB_Update_end: 
		Exit Function
		
F_NKSSMB_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMB_Update")
		GoTo F_NKSSMB_Update_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_NKSSMB_Insert
	'   �T�v�F  ���������T�}���O��V�K�o�^
	'   �����F
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMB_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSANYUKN() As Decimal) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMB_Insert_err
		
		F_NKSSMB_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO NKSSMB "
		strSQL = strSQL & "        ( TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "        , SMADT " '�o�������t
		strSQL = strSQL & "        , SSANYUKN00 " '�����W�v���z00
		strSQL = strSQL & "        , SSANYUKN01 " '�����W�v���z01
		strSQL = strSQL & "        , SSANYUKN02 " '�����W�v���z02
		strSQL = strSQL & "        , SSANYUKN03 " '�����W�v���z03
		strSQL = strSQL & "        , SSANYUKN04 " '�����W�v���z04
		strSQL = strSQL & "        , SSANYUKN05 " '�����W�v���z05
		strSQL = strSQL & "        , SSANYUKN06 " '�����W�v���z06
		strSQL = strSQL & "        , SSANYUKN07 " '�����W�v���z07
		strSQL = strSQL & "        , SSANYUKN08 " '�����W�v���z08
		strSQL = strSQL & "        , SSANYUKN09 " '�����W�v���z09
		strSQL = strSQL & "        , KSKNYKKN00 " '���������W�v���z00
		strSQL = strSQL & "        , KSKNYKKN01 " '���������W�v���z01
		strSQL = strSQL & "        , KSKNYKKN02 " '���������W�v���z02
		strSQL = strSQL & "        , KSKNYKKN03 " '���������W�v���z03
		strSQL = strSQL & "        , KSKNYKKN04 " '���������W�v���z04
		strSQL = strSQL & "        , KSKNYKKN05 " '���������W�v���z05
		strSQL = strSQL & "        , KSKNYKKN06 " '���������W�v���z06
		strSQL = strSQL & "        , KSKNYKKN07 " '���������W�v���z07
		strSQL = strSQL & "        , KSKNYKKN08 " '���������W�v���z08
		strSQL = strSQL & "        , KSKNYKKN09 " '���������W�v���z09
		strSQL = strSQL & "        , KSKZANKN00 " '�O�������������z00
		strSQL = strSQL & "        , KSKZANKN01 " '�O�������������z01
		strSQL = strSQL & "        , KSKZANKN02 " '�O�������������z02
		strSQL = strSQL & "        , KSKZANKN03 " '�O�������������z03
		strSQL = strSQL & "        , KSKZANKN04 " '�O�������������z04
		strSQL = strSQL & "        , KSKZANKN05 " '�O�������������z05
		strSQL = strSQL & "        , KSKZANKN06 " '�O�������������z06
		strSQL = strSQL & "        , KSKZANKN07 " '�O�������������z07
		strSQL = strSQL & "        , KSKZANKN08 " '�O�������������z08
		strSQL = strSQL & "        , KSKZANKN09 " '�O�������������z09
		strSQL = strSQL & "        , OPEID " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "        , CLTID " '�N���C�A���gID
		strSQL = strSQL & "        , WRTTM " '��ѽ����(����)
		strSQL = strSQL & "        , WRTDT " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		'2009/09/30 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SMADT, 8) & "' "   '�o�������t
		strSQL = strSQL & "        , '" & CF_Ora_String(pv_strSMADT, 8) & "' " '�o�������t
		'2009/09/30 UPD E.N.D RISE)MIYAJIMA
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(0)) '�����W�v���z00
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(1)) '�����W�v���z01
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(2)) '�����W�v���z02
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(3)) '�����W�v���z03
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(4)) '�����W�v���z04
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(5)) '�����W�v���z05
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(6)) '�����W�v���z06
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(7)) '�����W�v���z07
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(8)) '�����W�v���z08
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(9)) '�����W�v���z09
		strSQL = strSQL & "        ,  0 " '���������W�v���z00
		strSQL = strSQL & "        ,  0 " '���������W�v���z01
		strSQL = strSQL & "        ,  0 " '���������W�v���z02
		strSQL = strSQL & "        ,  0 " '���������W�v���z03
		strSQL = strSQL & "        ,  0 " '���������W�v���z04
		strSQL = strSQL & "        ,  0 " '���������W�v���z05
		strSQL = strSQL & "        ,  0 " '���������W�v���z06
		strSQL = strSQL & "        ,  0 " '���������W�v���z07
		strSQL = strSQL & "        ,  0 " '���������W�v���z08
		strSQL = strSQL & "        ,  0 " '���������W�v���z09
		strSQL = strSQL & "        ,  0 " '�O�������������z00
		strSQL = strSQL & "        ,  0 " '�O�������������z01
		strSQL = strSQL & "        ,  0 " '�O�������������z02
		strSQL = strSQL & "        ,  0 " '�O�������������z03
		strSQL = strSQL & "        ,  0 " '�O�������������z04
		strSQL = strSQL & "        ,  0 " '�O�������������z05
		strSQL = strSQL & "        ,  0 " '�O�������������z06
		strSQL = strSQL & "        ,  0 " '�O�������������z07
		strSQL = strSQL & "        ,  0 " '�O�������������z08
		strSQL = strSQL & "        ,  0 " '�O�������������z09
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���gID
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_NKSSMB_Insert_err
		End If
		
		F_NKSSMB_Insert = 0
		
F_NKSSMB_Insert_end: 
		Exit Function
		
F_NKSSMB_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMB_Insert")
		GoTo F_NKSSMB_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_NKSSMC
	'   �T�v�F  ���������T�}���O�ݏ���
	'   �����F  pm_All             : ��ʏ��
	'           pin_intRow         : �s�ԍ�
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMC(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim lngRowCnt As Integer
		
		Dim curSSANYUKN(9) As Decimal '�����W�v���z
		
		On Error GoTo F_NKSSMC_err
		
		F_NKSSMC = 9
		
		'�����W�v���z
		curSSANYUKN(0) = 0
		curSSANYUKN(1) = 0
		curSSANYUKN(2) = 0
		curSSANYUKN(3) = 0
		curSSANYUKN(4) = 0
		curSSANYUKN(5) = 0
		curSSANYUKN(6) = 0
		curSSANYUKN(7) = 0
		curSSANYUKN(8) = 0
		curSSANYUKN(9) = 0
		curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.FNYUKN * pin_intSMFKB
		
		'�v�Z���ʂ��X�V����
		If F_NKSSMC_Update(pm_All, pin_Tbl_Inf_UDNTRA, curSSANYUKN, lngRowCnt) <> 0 Then
			GoTo F_NKSSMC_err
		End If
		
		'�X�V�Ώۂ��Ȃ�������A�V�K�o�^����
		If lngRowCnt <= 0 Then
			If F_NKSSMC_Insert(pm_All, pin_Tbl_Inf_UDNTRA, curSSANYUKN) <> 0 Then
				GoTo F_NKSSMC_err
			End If
		End If
		
		F_NKSSMC = 0
		
F_NKSSMC_end: 
		Exit Function
		
F_NKSSMC_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMC")
		GoTo F_NKSSMC_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_NKSSMC_Update
	'   �T�v�F  ���������T�}���O�ݍX�V
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'           pin_curSSANYUKN    : �����W�v���z
	'           pot_lngRowCnt      : �X�V����
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMC_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSANYUKN() As Decimal, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMC_Update_err
		
		F_NKSSMC_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE NKSSMC "
		strSQL = strSQL & "    SET SSANYUKN00 = SSANYUKN00 + " & CStr(pin_curSSANYUKN(0)) '�����W�v���z00
		strSQL = strSQL & "      , SSANYUKN01 = SSANYUKN01 + " & CStr(pin_curSSANYUKN(1)) '�����W�v���z01
		strSQL = strSQL & "      , SSANYUKN02 = SSANYUKN02 + " & CStr(pin_curSSANYUKN(2)) '�����W�v���z02
		strSQL = strSQL & "      , SSANYUKN03 = SSANYUKN03 + " & CStr(pin_curSSANYUKN(3)) '�����W�v���z03
		strSQL = strSQL & "      , SSANYUKN04 = SSANYUKN04 + " & CStr(pin_curSSANYUKN(4)) '�����W�v���z04
		strSQL = strSQL & "      , SSANYUKN05 = SSANYUKN05 + " & CStr(pin_curSSANYUKN(5)) '�����W�v���z05
		strSQL = strSQL & "      , SSANYUKN06 = SSANYUKN06 + " & CStr(pin_curSSANYUKN(6)) '�����W�v���z06
		strSQL = strSQL & "      , SSANYUKN07 = SSANYUKN07 + " & CStr(pin_curSSANYUKN(7)) '�����W�v���z07
		strSQL = strSQL & "      , SSANYUKN08 = SSANYUKN08 + " & CStr(pin_curSSANYUKN(8)) '�����W�v���z08
		strSQL = strSQL & "      , SSANYUKN09 = SSANYUKN09 + " & CStr(pin_curSSANYUKN(9)) '�����W�v���z09
		strSQL = strSQL & "      , OPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "      , CLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���gID
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "    AND TUKKB = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TUKKB, 3) & "' " '�ʉ݋敪
		'2009/09/30 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SMADT, 8) & "' "   '�o�������t
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' " '�o�������t
		'2009/09/30 UPD E.N.D RISE)MIYAJIMA
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_NKSSMC_Update_err
		End If
		
		F_NKSSMC_Update = 0
		
F_NKSSMC_Update_end: 
		Exit Function
		
F_NKSSMC_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMC_Update")
		GoTo F_NKSSMC_Update_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_NKSSMC_Insert
	'   �T�v�F  ���������T�}���O�ݐV�K�o�^
	'   �����F
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMC_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSANYUKN() As Decimal) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMC_Insert_err
		
		F_NKSSMC_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO NKSSMC "
		strSQL = strSQL & "        ( TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "        , TUKKB " '�ʉ݋敪
		strSQL = strSQL & "        , SMADT " '�o�������t
		strSQL = strSQL & "        , SSANYUKN00 " '�����W�v���z00
		strSQL = strSQL & "        , SSANYUKN01 " '�����W�v���z01
		strSQL = strSQL & "        , SSANYUKN02 " '�����W�v���z02
		strSQL = strSQL & "        , SSANYUKN03 " '�����W�v���z03
		strSQL = strSQL & "        , SSANYUKN04 " '�����W�v���z04
		strSQL = strSQL & "        , SSANYUKN05 " '�����W�v���z05
		strSQL = strSQL & "        , SSANYUKN06 " '�����W�v���z06
		strSQL = strSQL & "        , SSANYUKN07 " '�����W�v���z07
		strSQL = strSQL & "        , SSANYUKN08 " '�����W�v���z08
		strSQL = strSQL & "        , SSANYUKN09 " '�����W�v���z09
		strSQL = strSQL & "        , KSKNYKKN00 " '���������W�v���z00
		strSQL = strSQL & "        , KSKNYKKN01 " '���������W�v���z01
		strSQL = strSQL & "        , KSKNYKKN02 " '���������W�v���z02
		strSQL = strSQL & "        , KSKNYKKN03 " '���������W�v���z03
		strSQL = strSQL & "        , KSKNYKKN04 " '���������W�v���z04
		strSQL = strSQL & "        , KSKNYKKN05 " '���������W�v���z05
		strSQL = strSQL & "        , KSKNYKKN06 " '���������W�v���z06
		strSQL = strSQL & "        , KSKNYKKN07 " '���������W�v���z07
		strSQL = strSQL & "        , KSKNYKKN08 " '���������W�v���z08
		strSQL = strSQL & "        , KSKNYKKN09 " '���������W�v���z09
		strSQL = strSQL & "        , KSKZANKN00 " '�O�������������z00
		strSQL = strSQL & "        , KSKZANKN01 " '�O�������������z01
		strSQL = strSQL & "        , KSKZANKN02 " '�O�������������z02
		strSQL = strSQL & "        , KSKZANKN03 " '�O�������������z03
		strSQL = strSQL & "        , KSKZANKN04 " '�O�������������z04
		strSQL = strSQL & "        , KSKZANKN05 " '�O�������������z05
		strSQL = strSQL & "        , KSKZANKN06 " '�O�������������z06
		strSQL = strSQL & "        , KSKZANKN07 " '�O�������������z07
		strSQL = strSQL & "        , KSKZANKN08 " '�O�������������z08
		strSQL = strSQL & "        , KSKZANKN09 " '�O�������������z09
		strSQL = strSQL & "        , OPEID " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "        , CLTID " '�N���C�A���gID
		strSQL = strSQL & "        , WRTTM " '��ѽ����(����)
		strSQL = strSQL & "        , WRTDT " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TUKKB, 3) & "' " '�ʉ݋敪
		'2009/09/30 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SMADT, 8) & "' "   '�o�������t
		strSQL = strSQL & "        , '" & CF_Ora_String(pv_strSMADT, 8) & "' " '�o�������t
		'2009/09/30 UPD E.N.D RISE)MIYAJIMA
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(0)) '�����W�v���z00
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(1)) '�����W�v���z01
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(2)) '�����W�v���z02
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(3)) '�����W�v���z03
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(4)) '�����W�v���z04
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(5)) '�����W�v���z05
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(6)) '�����W�v���z06
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(7)) '�����W�v���z07
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(8)) '�����W�v���z08
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(9)) '�����W�v���z09
		strSQL = strSQL & "        ,  0 " '���������W�v���z00
		strSQL = strSQL & "        ,  0 " '���������W�v���z01
		strSQL = strSQL & "        ,  0 " '���������W�v���z02
		strSQL = strSQL & "        ,  0 " '���������W�v���z03
		strSQL = strSQL & "        ,  0 " '���������W�v���z04
		strSQL = strSQL & "        ,  0 " '���������W�v���z05
		strSQL = strSQL & "        ,  0 " '���������W�v���z06
		strSQL = strSQL & "        ,  0 " '���������W�v���z07
		strSQL = strSQL & "        ,  0 " '���������W�v���z08
		strSQL = strSQL & "        ,  0 " '���������W�v���z09
		strSQL = strSQL & "        ,  0 " '�O�������������z00
		strSQL = strSQL & "        ,  0 " '�O�������������z01
		strSQL = strSQL & "        ,  0 " '�O�������������z02
		strSQL = strSQL & "        ,  0 " '�O�������������z03
		strSQL = strSQL & "        ,  0 " '�O�������������z04
		strSQL = strSQL & "        ,  0 " '�O�������������z05
		strSQL = strSQL & "        ,  0 " '�O�������������z06
		strSQL = strSQL & "        ,  0 " '�O�������������z07
		strSQL = strSQL & "        ,  0 " '�O�������������z08
		strSQL = strSQL & "        ,  0 " '�O�������������z09
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���gID
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_NKSSMC_Insert_err
		End If
		
		F_NKSSMC_Insert = 0
		
F_NKSSMC_Insert_end: 
		Exit Function
		
F_NKSSMC_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMC_Insert")
		GoTo F_NKSSMC_Insert_end
		
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
		Dim Wk_ColHINCD As Short
		Dim strJDNTRKB As String
		
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
					
					Select Case pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name
						Case FR_SSSMAIN.BD_DKBID(1).Text, FR_SSSMAIN.BD_DKBID(2).Text, FR_SSSMAIN.BD_DKBID(3).Text, FR_SSSMAIN.BD_DKBID(4).Text, FR_SSSMAIN.BD_DKBID(5).Text, FR_SSSMAIN.BD_DKBID(6).Text
							Wk_Index = CShort(FR_SSSMAIN.BD_DKBID(Wk_Row).Tag)
							Call F_Dsp_BD_DKBID_Inf(pm_All.Dsp_Sub_Inf(Wk_Index), DSP_SET, pm_All)
							
						Case FR_SSSMAIN.BD_BNKCD(1).Text, FR_SSSMAIN.BD_BNKCD(2).Text, FR_SSSMAIN.BD_BNKCD(3).Text, FR_SSSMAIN.BD_BNKCD(4).Text, FR_SSSMAIN.BD_BNKCD(5).Text, FR_SSSMAIN.BD_BNKCD(6).Text
							Wk_Index = CShort(FR_SSSMAIN.BD_BNKCD(Wk_Row).Tag)
							Call F_Dsp_BD_BNKCD_Inf(pm_All.Dsp_Sub_Inf(Wk_Index), DSP_SET, pm_All)
							
						Case FR_SSSMAIN.BD_NYUKN(0).Name
							'�w�i�F�ݒ�
							Call F_Set_Body_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.BD_NYUKN(Wk_Row).Tag)), pm_All)
							
						Case FR_SSSMAIN.BD_FNYUKN(0).Name
							'�w�i�F�ݒ�
							Call F_Set_Body_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.BD_FNYUKN(Wk_Row).Tag)), pm_All)
							
						Case Else
							'�w�i�F�ݒ�
							Call F_Set_Body_Item_Color(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					End Select
				End If
			Next 
		End If
		
		'** ���۰ِ��� **
		
		'�y�󒍔ԍ��z
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			'�O�����
			Call F_Util_JDNNO_SetOnOff(True, pm_All)
		Else
			'����
			Call F_Util_JDNNO_SetOnOff(False, pm_All)
			Call F_Util_JDNNO_Clear(pm_All)
		End If
		
		'�y�����z(�O��)�z
		If URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN Then
			Call F_Util_FNYUKN_SetOnOff(True, pm_All) '�C�O
		Else
			Call F_Util_FNYUKN_SetOnOff(False, pm_All) '�������A�G���[
			Call F_Util_FNYUKN_Clear(pm_All)
		End If
		
		'�����z
		Call F_Util_NYUKN_Sum(pm_All)
		Call F_Util_FNYUKN_Sum(pm_All)
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
        '2019/05/22 CHG START
        'FR_SSSMAIN.PrintForm()
        '2019/05/22 CHG END
        FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.Arrow
        If Err.Number <> 0 Then
            If AE_MsgLibrary(PP_SSSMAIN, "HardcopyError") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
        End If
        On Error GoTo 0
        AE_Hardcopy_SSSMAIN = Cn_CuCurrent
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Ctl_MN_APPENDC_Click
    '   �T�v�F  ��ʏ���������
    '   �����F�@pm_All : ��ʏ��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_MN_APPENDC_Click(ByRef pm_All As Cls_All) As Short
		
		Dim strKJNDT As String

        ' === 20130711 === INSERT S - FWEST)Koroyasu �r������̉���
        '�r������
        '2019/05/23 CHG START
        'Call CF_Del_EXCTBZ2()
        CF_Unlock_EXCTBZ2()
        '2019/05/23 CHG END
        ' === 20130711 === INSERT E -

        '��ʖ��׏��ݒ�
        Call F_Init_Def_Body_Inf(pm_All)
		
		'��ʓ��e������
		Call F_Init_Clr_Dsp(-1, pm_All)

        '���͒S���ҕҏW
        '2019/05/23 CHG START
        'Call CF_Set_Frm_IN_TANCD(FR_SSSMAIN, pm_All)
        Call CF_Set_Frm_IN_TANCD_URKET52(FR_SSSMAIN, pm_All)
        '2019/05/23 CHG END

        '��ʃ{�f�B��������
        Call F_Init_Clr_Dsp_Body(-1, pm_All)
		
		'�����\���ҏW
		Call F_Edi_Dsp_Def(pm_All)
		
		'��ʖ��ו\��
		Call CF_Body_Dsp(pm_All)
		
		'���͒S���҂̌������Đݒ�
		Call F_Chg_INPTANCD_KNG(Inp_Inf, pm_All, GV_UNYDate)
		
		gv_bolInit = True
		
		'����̫����ʒu�ݒ�
		Call SSSMAIN0001.F_Init_Cursor_Set(pm_All)
		
		gv_bolInit = False
		
		'��ʕύX�Ȃ��Ƃ���
		gv_bolURKET52_INIT = False
		gv_bolURKET52_LF_Enable = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Init_Def_Body_Inf
	'   �T�v�F  ��ʃ{�f�B���ݒ�
	'   �����F�@pm_All : ��ʏ��
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Init_Def_Body_Inf(ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Col_Index As Short
		Dim Index_Wk As Short
		
		'������ʃ{�f�B���ݒ�
		Call CF_Init_Set_Body_Inf(pm_All)
		
		If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
			'���׍s�����݂���ꍇ
			
			'��ʃ{�f�B�̗񕪂̔z���`
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail(pm_All.Dsp_Base.Body_Col_Cnt)
			'�������
			pm_All.Dsp_Body_Inf.Row_Inf(0).Status = BODY_ROW_STATE_DEFAULT
			
			'�������p�ݒ�
			'��ʃ{�f�B�̗񕪂̔z���`
			ReDim Preserve pm_All.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(pm_All.Dsp_Base.Body_Col_Cnt)
			'�������
			pm_All.Dsp_Body_Inf.Init_Row_Inf.Status = BODY_ROW_STATE_DEFAULT
			
			'�������ݒ�
			'�񕪂̕����s�̔z���`
			ReDim Preserve pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(pm_All.Dsp_Base.Body_Col_Cnt)
			'�������
			pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Status = BODY_ROW_STATE_DEFAULT
			
			'��ʃ{�f�B���̔z��O�Ԗڂɗ�����`����
			For Bd_Col_Index = 1 To pm_All.Dsp_Base.Body_Col_Cnt
				'��ʃ{�f�B���
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail(Bd_Col_Index) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index) = pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Body_Fst_Idx + Bd_Col_Index - 1).Detail
				
				'�������p���
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Bd_Col_Index) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				pm_All.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Bd_Col_Index) = pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index)
				
				'�������
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Bd_Col_Index) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Bd_Col_Index) = pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index)
			Next 
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Edi_Dsp_Def
	'   �T�v�F  �������̉�ʕҏW
	'   �����F�@pm_All : ��ʏ��
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Edi_Dsp_Def(ByRef pm_All As Cls_All) As Short
		Dim Index_Wk As Short
		
		'�r���������������������������������������������������������r
		'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.SYSDT.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Index_Wk = CShort(FR_SSSMAIN.SYSDT.Tag)
		'��ʓ��t
		Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(VB6.Format(GV_UNYDate, "@@@@/@@/@@"), pm_All.Dsp_Sub_Inf(Index_Wk), False), pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
		'�d���������������������������������������������������������d
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Reset_ErrStatus
	'   �T�v�F  �G���[��ԏ�����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@0:����  11:�ُ�
	'   ���l�F  �ΏۊO�̃R���g���[���ɂ��Ă͏��������s��Ȃ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Reset_ErrStatus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Short
		
		Dim Ret_Value As Short
		F_Reset_ErrStatus = 9
		Ret_Value = CHK_OK
		
		'    With FR_SSSMAIN
		'        Select Case pm_Dsp_Sub_Inf.Ctl.NAME
		'            '���������A�w�b�_���A�{�f�B���A�e�C�����͕����Ă���
		'            Case .HD_SOUCD.NAME
		'            Case .BD_ODNYTDT(0).NAME
		'                '�o�ח\���
		'                pm_Dsp_Sub_Inf.Detail.Err_Status = ERR_DEF
		'
		'            Case Else
		'                '�Ώۂ��u�������v�̏ꍇ
		'
		'        End Select
		'    End With
		
		F_Reset_ErrStatus = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chg_INPTANCD_KNG
	'   �T�v�F  ���͒S���Ҍ����ύX
	'   �����F�@�Ȃ�
	'   �ߒl�F�@0:����  11:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chg_INPTANCD_KNG(ByRef pot_Inp_Inf As Cmn_Inp_Inf, ByRef pm_All As Cls_All, Optional ByVal pin_strKJNDT As String = "") As Short
		
		F_Chg_INPTANCD_KNG = 9
		
		'�����Ď擾
		Call F_Get_INPTANCD_Inf(pot_Inp_Inf.InpTanCd, pot_Inp_Inf, pin_strKJNDT)
		'���׎g�p�ېݒ�
		Call F_Set_Body_Enable(pm_All)
		
		F_Chg_INPTANCD_KNG = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Body_Item_Color
	'   �T�v�F  ���ׂ̍��ڐF�ݒ�
	'   �����F  pm_Dsp_Sub_Inf : ��ʍ��ڏ��
	'           pm_all         : ��ʏ��
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Body_Item_Color(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		'    Dim intRow          As Integer
		'    Dim intDspRow       As Integer
		'
		'    intRow = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)           '���׍s�ԍ�
		'    intDspRow = pm_Dsp_Sub_Inf.Detail.Body_Index                '��ʕ\���s�ԍ�
		'
		'    Select Case pm_Dsp_Sub_Inf.Ctl.NAME
		'        '���ׁF�����z(�~)
		'        Case FR_SSSMAIN.BD_NYUKN(0).NAME
		'            '�I�[�o�[�t���[���������Ă���ꍇ�͔w�i�F�͐ԂɕύX
		'            If pm_All.Dsp_Body_Inf.Row_Inf(intRow).Bus_Inf.bolOver = True Then
		'                '�w�i�F�ݒ�
		'                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.BD_NYUKN(intDspRow).Tag).Ctl.BackColor = COLOR_RED
		'            End If
		'
		'        '���ׁF�����z(�O��)
		'        Case FR_SSSMAIN.BD_FNYUKN(0).NAME
		'            '�I�[�o�[�t���[���������Ă���ꍇ�͔w�i�F�͐ԂɕύX
		'            If pm_All.Dsp_Body_Inf.Row_Inf(intRow).Bus_Inf.bolOver = True Then
		'                '�w�i�F�ݒ�
		'                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.BD_FNYUKN(intDspRow).Tag).Ctl.BackColor = COLOR_RED
		'            End If
		'
		'        '�e�C���F���v(�~)
		'        Case FR_SSSMAIN.TL_SBANYUKN.NAME
		'            '�I�[�o�[�t���[���������Ă���ꍇ�͔w�i�F�͐ԂɕύX
		'            If pm_All.Dsp_Body_Inf.Row_Inf(intRow).Bus_Inf.bolOver = True Then
		'                '�w�i�F�ݒ�
		'                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.TL_SBANYUKN.Tag).Ctl.BackColor = COLOR_RED
		'            End If
		'
		'        '�e�C���F���v(�O��)
		'        Case FR_SSSMAIN.TL_SBAFRNKN.NAME
		'            '�I�[�o�[�t���[���������Ă���ꍇ�͔w�i�F�͐ԂɕύX
		'            If pm_All.Dsp_Body_Inf.Row_Inf(intRow).Bus_Inf.bolOver = True Then
		'                '�w�i�F�ݒ�
		'                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.TL_SBAFRNKN.Tag).Ctl.BackColor = COLOR_RED
		'            End If
		'
		'        Case Else
		'    End Select
		'
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_SYSTBA
	'   �T�v�F  ���[�U���擾
	'   �����F
	'   �ߒl�F�@0:����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_SYSTBA() As Short
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		
		On Error GoTo F_GET_SYSTBA_Err
		
		F_GET_SYSTBA = 9
		
		'�ϐ�������
		pv_strYERUPDDT = ""
		'''' UPD 2011/01/14  FKS) T.Yamamoto    Start    �A���[��FC11011401
		'�����{�����̏����P�p
		'    pv_strMONUPDDT = ""
		pv_strSMAUPDDT = ""
		'''' UPD 2011/01/14  FKS) T.Yamamoto    End
		pv_strSMADD = ""
		
		'SQL�ҏW
		strSQL = ""
		strSQL = strSQL & " SELECT YERUPDDT " '�N���X�V���s��
		'''' UPD 2011/01/14  FKS) T.Yamamoto    Start    �A���[��FC11011401
		'�����{�����̏����P�p
		'    strSQL = strSQL & "      , MONUPDDT " '�����X�V���s��
		strSQL = strSQL & "      , SMAUPDDT " '�O��o�������s��
		'''' UPD 2011/01/14  FKS) T.Yamamoto    End
		strSQL = strSQL & "      , SMADD " '���Z��
		strSQL = strSQL & "   FROM SYSTBA "

        'SQL���s
        'change 20190726 START hou
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        '      If CF_Ora_EOF(Usr_Ody) = False Then
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	pv_strYERUPDDT = Trim(CF_Ora_GetDyn(Usr_Ody, "YERUPDDT", ""))
        '	'''' UPD 2011/01/14  FKS) T.Yamamoto    Start    �A���[��FC11011401
        '	'�����{�����̏����P�p
        '	'        pv_strMONUPDDT = Trim(CF_Ora_GetDyn(Usr_Ody, "MONUPDDT", ""))
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	pv_strSMAUPDDT = Trim(CF_Ora_GetDyn(Usr_Ody, "SMAUPDDT", ""))
        '	'''' UPD 2011/01/14  FKS) T.Yamamoto    End
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	pv_strSMADD = Trim(CF_Ora_GetDyn(Usr_Ody, "SMADD", ""))
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)

        If dt Is Nothing OrElse dt.Rows.Count >= 1 Then
            'Dim intcnt As Short = 0
            For Each row As DataRow In dt.Rows
                '    intcnt = intcnt + 1
                pv_strYERUPDDT = Trim(DB_NullReplace(row("YERUPDDT"), ""))
                pv_strSMAUPDDT = Trim(DB_NullReplace(row("SMAUPDDT"), ""))
                pv_strSMADD = Trim(DB_NullReplace(row("SMADD"), ""))
            Next
        End If
        'change 20190726 END hou

        F_GET_SYSTBA = 0
		
F_GET_SYSTBA_End: 
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
F_GET_SYSTBA_Err: 
		
		GoTo F_GET_SYSTBA_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_Item_LostFocus_Dummy
	'   �T�v�F  �Ώۍ��ڂ�LOSTFOCUS�_�~�[����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F�@ActiveControl�ɑ΂���LOSTFOCUS���Ɠ��l�̃`�F�b�N�A��ʐ�����s���B
	'          �i�������t�H�[�J�X�ړ��͍s��Ȃ��j
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_LostFocus_Dummy(ByRef pm_All As Cls_All) As Short
		
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		Dim Wk_Row As Short
		Dim LF_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf
		
		On Error GoTo CF_Ctl_Item_LostFocus_Dummy_End
		
		CF_Ctl_Item_LostFocus_Dummy = CHK_OK
		
		If gv_bolURKET52_LF_Enable = False Then
			Exit Function
		End If
		
		If FR_SSSMAIN.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		If IsNumeric(FR_SSSMAIN.ActiveControl.Tag) = False Then
			Exit Function
		End If
		
		'۽�̫������s����
		If pm_All.Dsp_Base.LostFocus_Flg = True Then
			pm_All.Dsp_Base.LostFocus_Flg = False
			Exit Function
		End If
		
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LF_Dsp_Sub_Inf �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		LF_Dsp_Sub_Inf = pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag))
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'�e���ڂ�����ٰ��
		Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(LF_Dsp_Sub_Inf, CHK_FROM_LOSTFOCUS, Chk_Move_Flg, pm_All)
		
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
		Call SSSMAIN0001.F_Dsp_Item_Detail(LF_Dsp_Sub_Inf, Dsp_Mode, pm_All)
		
		If Chk_Move_Flg = True Then
			'������ړ�����
			Call CF_Set_Item_Color(LF_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
			'���הw�i�F�ݒ�
			Call F_Set_Body_Item_Color(LF_Dsp_Sub_Inf, pm_All)
		Else
			'������ړ��Ȃ�
		End If
		
		Wk_Row = LF_Dsp_Sub_Inf.Detail.Body_Index
		
		'�`�F�b�N���ʂ���ʏ��ɖ߂�
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.ActiveControl.Tag)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)) = LF_Dsp_Sub_Inf
		
		CF_Ctl_Item_LostFocus_Dummy = Rtn_Chk
		
CF_Ctl_Item_LostFocus_Dummy_End: 
		
	End Function
	
	Public Function GetLocalTimeText() As String
		Dim t As SYSTEMTIME
		Dim r As String
		
		On Error GoTo Err_GetLocalTimeText
		Call GetLocalTime(t)
		
		r = VB6.Format(t.wHour, "00") & ":" & VB6.Format(t.wMinute, "00") & ":" & VB6.Format(t.wSecond, "00") & "." & VB6.Format(t.wMilliseconds, "000")
		
		GetLocalTimeText = r
		
End_GetLocalTimeText: 
		Exit Function
		
Err_GetLocalTimeText: 
		Call MsgBox(Err.Description & " : " & Err.Number & " : " & Err.Source)
	End Function
	
	'// V1.20�� ADD
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_HAITA_JDNNO
	'   �T�v�F  ���ׁF�󒍔ԍ��̔r������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HAITA_JDNNO(ByRef pm_All As Cls_All) As Short
		Dim Retn_Code As Short
		
		Dim intCnt As Short
		Dim strJdnNo As String
		Dim strJDNLINNO As String
		
		Retn_Code = CHK_OK
		
		For intCnt = 1 To pv_intMeisaiCnt
			
			'�󒍔ԍ�
			strJdnNo = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.JDNNO
			strJDNLINNO = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.JDNLINNO
			
			
			If strJdnNo <> "" Or strJDNLINNO <> "" Then
				If F_Util_CheckJDNNO(strJdnNo, strJDNLINNO) <> 0 Then
					Retn_Code = CHK_ERR_ELSE
					GoTo F_Chk_HAITA_JDNNO_End
				End If
			End If
			
		Next intCnt
		
F_Chk_HAITA_JDNNO_End: 
		
		F_Chk_HAITA_JDNNO = Retn_Code
	End Function
	'// V1.20�� ADD
	
	'2009/06/08 ADD START FKS)NAKATA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_UODKN_JDNNO
	'   �T�v�F  ���ׁF�󒍋��z=�����z�`�F�b�N
	'   �����F  pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_UODKN_JDNNO(ByRef pm_All As Cls_All) As Short
		
		Dim Retn_Code As Short
		Dim Err_Cd As String
		Dim Msg_Flg As Boolean
		
		Dim intCnt As Short
		Dim intCnt2 As Short
		Dim strJdnNo As String
		Dim strJDNLINNO As String
		
		Dim curNYUKN As Decimal
		Dim curUODKN As Decimal
		
		'*** 2009/09/07 ADD START FKS)NAKATA
		Dim strDKBID As String '�������
		'*** 2009/09/07 ADD E.N.D FKS)NAKATA
		
		
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		
		
		For intCnt = 1 To pv_intMeisaiCnt
			
			'������
			strJdnNo = ""
			strJDNLINNO = ""
			curNYUKN = 0
			'*** 2009/09/07 ADD START FKS)NAKATA
			strDKBID = ""
			'*** 2009/09/07 ADD E.N.D FKS)NAKATA
			
			'*** 2009/09/07 ADD START FKS)NAKATA
			'�������
			
			strDKBID = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.DKBID
			'*** 2009/09/07 ADD E.N.D FKS)NAKATA
			
			'*** 2009/09/07 ADD START FKS)NAKATA
			'�{�����͏������s��Ȃ�
			If Trim(strDKBID) <> "09" Then
				'*** 2009/09/07 ADD E.N.D FKS)NAKATA
				
				'�󒍔ԍ�
				strJdnNo = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.JDNNO
				strJDNLINNO = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.JDNLINNO
				
				
				'�����z
				curNYUKN = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.NYUKN
				
				
				For intCnt2 = 1 To pv_intMeisaiCnt
					
					'�������g�ȊO�̖��׍s��ΏۂƂ���
					If intCnt <> intCnt2 Then
						
						'*** 2009/09/07 CHG START FKS)NAKATA
						'If Trim(strJdnNo) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt2).Bus_Inf.JDNNO) _
						'' And Trim(strJDNLINNO) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt2).Bus_Inf.JDNLINNO) Then
						
						'�{�����͑���ɂ��Ȃ�
						If Trim(strJdnNo) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt2).Bus_Inf.JDNNO) And Trim(strJDNLINNO) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt2).Bus_Inf.JDNLINNO) And Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt2).Bus_Inf.DKBID) <> "09" Then
							'*** 2009/09/07 CHG E.N.D FKS)NAKATA
							
							curNYUKN = curNYUKN + pm_All.Dsp_Body_Inf.Row_Inf(intCnt2).Bus_Inf.NYUKN
							
						End If
					End If
				Next intCnt2
				
				If strJdnNo <> "" Or strJDNLINNO <> "" Then
					
					'�󒍋��z�̎擾
					curUODKN = F_Util_Get_UODKN(strJdnNo, strJDNLINNO)
					
					'�󒍋��z > �����z
					If curNYUKN > curUODKN Then
						
						Msg_Flg = True
						Err_Cd = gc_strMsgURKET52_E_031 '�󒍋��z�������Ă��܂��B
						GoTo F_Chk_UODKN_JDNNO_End
						
						'�󒍋��z < �����z
					ElseIf curNYUKN < curUODKN Then 
						
						Msg_Flg = True
						Err_Cd = gc_strMsgURKET52_E_032 '�󒍋��z��������Ă��܂��B
						GoTo F_Chk_UODKN_JDNNO_End
						
					End If
					
				End If
				'*** 2009/09/07 ADD START FKS)NAKATA
			End If
			'*** 2009/09/07 ADD E.N.D FKS)NAKATA
		Next intCnt
		
F_Chk_UODKN_JDNNO_End: 
		
		'*** 2009/09/07 CHG START FKS)NAKATA
		'�A���[�g���b�Z�[�W����G���[���b�Z�[�W�ɕύX
		'''    If Msg_Flg = True And Trim(Err_Cd) <> "" Then
		'''        '���b�Z�[�W�o��
		'''        If AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All) = vbNo Then
		'''            Retn_Code = CHK_WARN '���[�j���O
		'''        Else
		'''            Retn_Code = CHK_OK
		'''        End If
		'''
		'''    End If
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			Retn_Code = CHK_ERR_ELSE
		End If
		'*** 2009/09/07 CHG E.N.D FKS)NAKATA
		
		F_Chk_UODKN_JDNNO = Retn_Code
		
	End Function
	'2009/06/08 ADD E.N.D FKS)NAKATA
	
	'*** 2009/09/07 ADD START FKS)NAKATA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_UODKN_JDNNO
	'   �T�v�F  ���ׁF�󒍋��z=�����z�`�F�b�N
	'   �����F  pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Function F_Chk_KESIZUMI(ByRef pm_All As Cls_All) As Short
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		
		Dim Retn_Code As Short
		Dim Err_Cd As String
		Dim Msg_Flg As Boolean
		
		Dim intCnt As Short
		Dim strOKRJONO As String
		Dim strDKBID As String
		Dim strJdnNo As String
		Dim strJDNLINNO As String
		Dim strJDNTRKB As String
		Dim intKESI As Short
		
		On Error GoTo F_Chk_KESIZUMI_err
		
		
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		
		
		
		For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			
			
			strDKBID = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.DKBID)
			
			'�{�����ւ̐U�ւ͖�������
			If strDKBID <> "09" Then
				
				'����󇂂̊i�[
				strOKRJONO = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.OKRJONO)
				
				strJdnNo = Left(Trim(strOKRJONO), 6)
				strJDNLINNO = Right(Trim(strOKRJONO), 3)
				
				'�󒍎���敪�̎擾
				strSQL = ""
				strSQL = strSQL & " SELECT DATNO "
				strSQL = strSQL & " ,      JDNTRKB"
				strSQL = strSQL & "   FROM JDNTHA "
				strSQL = strSQL & "      , (SELECT MAX(DATNO) AS MAX_DATNO "
				strSQL = strSQL & "           FROM JDNTHA "
				strSQL = strSQL & "          WHERE JDNNO = '" & strJdnNo & "'"
				strSQL = strSQL & "            AND DATKB = '1' "
				strSQL = strSQL & "            AND MAEUKKB  = '2' "
				strSQL = strSQL & "        ) SUB "
				strSQL = strSQL & "  WHERE JDNNO        = '" & strJdnNo & "'"
				strSQL = strSQL & "    AND DATKB        = '1'"
				strSQL = strSQL & "    AND AKAKROKB     = '1'"
				strSQL = strSQL & "    AND TOKSEICD     = '" & URKET52_HEAD_Inf.TOKCD & "' "
				strSQL = strSQL & "    AND MAEUKKB      = '2'"
				strSQL = strSQL & "    AND JDNTHA.DATNO = SUB.MAX_DATNO "

                'DB�A�N�Z�X
                'change start 20190826 kuwa
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                Dim dt As DataTable = DB_GetTable(strSQL)
                'change end 20190826 kuwa

                '�擾�f�[�^�ޔ�
                'change start 20190826 kuwa
                'If CF_Ora_EOF(Usr_Ody) = False Then
                If dt Is Nothing OrElse dt.Rows.Count > 0 Then
                    'change end 20190826 kuwa
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'change start 20190827 kuwa
                    'strJDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")
                    strJDNTRKB = DB_NullReplace(dt.Rows(0)("JDNTRKB"), "")
                    'change end 20190827 kuwa
                End If


                '��������Ă��邩�̊m�F
                strSQL = "" & vbCrLf
				strSQL = strSQL & "SELECT  COUNT(*) AS CNT"
				strSQL = strSQL & "  FROM   NKSTRA"
				strSQL = strSQL & " WHERE   DATKB     = '1'"
				strSQL = strSQL & "  AND    AKAKROKB  = '1'"
				strSQL = strSQL & "  AND    JDNNO     = '" & strJdnNo & "'"
				
				'�V�X�e���E�Z�b�g�A�b�v�͓`�[�P�ʂɂĊm�F
				If strJDNTRKB = "11" Or strJDNTRKB = "21" Then
				Else
					strSQL = strSQL & "  AND   JDNLINNO  = '" & strJDNLINNO & "'"
				End If
				
				strSQL = strSQL & "  AND    KDNNO NOT IN "
				strSQL = strSQL & "     ("
				strSQL = strSQL & "     SELECT  MOTKDNNO"
				strSQL = strSQL & "       FROM  NKSTRA"
				strSQL = strSQL & "         WHERE   JDNNO   =   '" & strJdnNo & "'"
				
				'�V�X�e���E�Z�b�g�A�b�v�͓`�[�P�ʂɂĊm�F
				If strJDNTRKB = "11" Or strJDNTRKB = "21" Then
				Else
					strSQL = strSQL & "       AND   JDNLINNO  = '" & strJDNLINNO & "'"
				End If
				strSQL = strSQL & "           AND  TRIM(MOTKDNNO) IS NOT NULL"
				strSQL = strSQL & "       )"


                'DB�A�N�Z�X
                'change start 20190826 kuwa
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                dt = DB_GetTable(strSQL)
                'change end 20190826 kuwa

                '�擾�f�[�^�ޔ�
                'change start 20190826 kuwa
                'If CF_Ora_EOF(Usr_Ody) = False Then
                If dt Is Nothing OrElse dt.Rows.Count > 0 Then
                    'change end 20190826 kuwa
                    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'change start 20190827 kuwa
                    'intKESI = SSSVal(CF_Ora_GetDyn(Usr_Ody, "CNT", ""))
                    intKESI = SSSVal(DB_NullReplace(dt.Rows(0)("CNT"), ""))
                    'change end 20190827 kuwa
                Else
                    GoTo F_Chk_KESIZUMI_end
				End If
				
				'�N���[�Y
				Call CF_Ora_CloseDyn(Usr_Ody)
				
				'�����ς̏ꍇ
				If intKESI > 0 Then
					
					Msg_Flg = True
					Err_Cd = gc_strMsgURKET52_E_036 '�[���ς݂ł��B�X�V�ł��܂���B
					GoTo F_Chk_KESIZUMI_end
					
				End If
			End If
			
		Next intCnt
		
		
F_Chk_KESIZUMI_end: 
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			Retn_Code = CHK_ERR_ELSE
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		F_Chk_KESIZUMI = Retn_Code
		
		Exit Function
		
F_Chk_KESIZUMI_err: 
		GoTo F_Chk_KESIZUMI_end
		
	End Function
	'*** 2009/09/07 ADD E.N.D FKS)NAKATA
	
	
	'// V1.20�� ADD
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_FIXMTA
	'   �T�v�F  �Œ�l�}�X�^�擾
	'   �����F
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_FIXMTA(ByRef pin_strFIXVAL As String) As Short
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		
		On Error GoTo F_Get_FIXMTA_err
		
		F_Get_FIXMTA = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " SELECT FIXVAL "
		strSQL = strSQL & "   FROM FIXMTA "
		strSQL = strSQL & "  WHERE CTLCD        = '" & CF_Ora_String(gc_strCTLCD_SSAKB, 10) & "' "

        'DB�A�N�Z�X
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        '�擾�f�[�^
        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            pin_strFIXVAL = ""
            GoTo F_Get_FIXMTA_end
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'change start 20190826 kuwa
            'pin_strFIXVAL = CF_Ora_GetDyn(Usr_Ody, "FIXVAL", "")
            pin_strFIXVAL = DB_NullReplace(dt.Rows(0)("FIXVAL"), "")
            'change end 20190826 kuwa
        End If
		
		F_Get_FIXMTA = 0
		
F_Get_FIXMTA_end: 
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
F_Get_FIXMTA_err: 
		GoTo F_Get_FIXMTA_end
		
	End Function
	'// V1.20�� ADD
	
	'2009/09/03 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Util_GET_TANMTA_TANCLAKB
	'   �T�v�F  �c�ƒS���t���O���擾
	'   �����F�@pot_strTANCD       : �S���҃R�[�h
	'       �F�@pot_strKEIBMNCD    : �c�ƒS���t���O
	'   �ߒl�F�@0:����I�� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Util_GET_TANMTA_TANCLAKB(ByRef pot_strTANCD As String, ByRef pot_strTANCLAKB As String) As Short
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		
		On Error GoTo ERR_F_Util_GET_TANMTA_TANCLAKB
		
		F_Util_GET_TANMTA_TANCLAKB = 9
		
		pot_strTANCLAKB = ""
		
		'�S���҂l
		strSQL = ""
		strSQL = strSQL & " SELECT TANCLAKB "
		strSQL = strSQL & " FROM TANMTA "
		strSQL = strSQL & " WHERE TANCD = '" & pot_strTANCD & "' "

        'DB�A�N�Z�X
        'changr 20190729 START hou
        '      Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	pot_strTANCLAKB = CF_Ora_GetDyn(Usr_Ody, "TANCLAKB", "")
        Dim dt As DataTable = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            pot_strTANCLAKB = DB_NullReplace(dt.Rows(0)("TANCLAKB"), "")
            'change 20190729 END hou
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
	'2009/09/03 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/18 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_AllKESAIBI
	'   �T�v�F  ���ׁF��������������
	'   �����F  pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Function F_Chk_AllKESAIBI(ByRef pm_All As Cls_All) As Short
		
		Dim Retn_Code As Short
		Dim Err_Cd As String
		Dim Msg_Flg As Boolean
		
		Dim intCnt As Short
		Dim strDKBID As String
		Dim strOKRJONO As String
		Dim strTEGDT As String
		
		On Error GoTo F_Chk_AllKESAIBI_err
		
		
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		
		For intCnt = 1 To pv_intMeisaiCnt
			
			strDKBID = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.DKBID)
			
			'�{�����ւ̐U�ւ͖�������
			If strDKBID <> pc_strDKBID_URK_HNYU Then
				
				If Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.TEGDT) <> "" Then
					strTEGDT = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.TEGDT)
				Else
					strTEGDT = ""
				End If
				
				If Trim(strTEGDT) <> "" Then
					'�^�p���e�[�u��.�^�p���t�iUNYMTA�j> ���.���ϓ��̏ꍇ
					If Trim(GV_UNYDate) > Trim(strTEGDT) Then
						If pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.DKBID <> pc_strDKBID_URK_GENKN Then
							Msg_Flg = True
							Err_Cd = gc_strMsgURKET52_E_035
							GoTo F_Chk_AllKESAIBI_end
						End If
					End If
				End If
				
			End If
		Next intCnt
		
F_Chk_AllKESAIBI_end: 
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			Retn_Code = CHK_ERR_ELSE
		End If
		
		F_Chk_AllKESAIBI = Retn_Code
		
		Exit Function
		
F_Chk_AllKESAIBI_err: 
		GoTo F_Chk_AllKESAIBI_end
		
	End Function
	'2009/09/18 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/18 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_MaeukeTEGDT
	'   �T�v�F  ���ׁF��������������
	'   �����F  pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Function F_GET_MaeukeTEGDT(ByRef pm_All As Cls_All, ByRef pmstrOKRJONO As String, ByRef pstrTEGDT As String) As String
		
		Dim Retn_Code As Short
		
		Dim intCnt As Short
		Dim strDKBID As String
		Dim strOKRJONO As String
		Dim strDSPTEGDT As String
		Dim strMAXTEGDT As String
		
		Dim I As Short
		
		On Error GoTo F_GET_MaeukeTEGDT_err
		
		F_GET_MaeukeTEGDT = ""
		
		strDSPTEGDT = ""
		strMAXTEGDT = ""
		
		For intCnt = 1 To pv_intMeisaiCnt
			
			'����敪�擾
			strDKBID = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.DKBID)
			
			'�󒍔ԍ��̎���敪���i08�F�U�����j�̂��̂���������
			If strDKBID = pc_strDKBID_URK_HURIK Then
				'����󇂂̊i�[
				strOKRJONO = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.OKRJONO)
				'�󒍔ԍ����r�i����̂��̂�T���j
				If pmstrOKRJONO = strOKRJONO Then
					'���ϓ������
					strDSPTEGDT = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.TEGDT)
					'���ϓ��̍ő�����߂邽�߂ɔ�r
					If strMAXTEGDT <= strDSPTEGDT Then
						strMAXTEGDT = strDSPTEGDT
					End If
				End If
			End If
		Next intCnt
		
		'������敪��08�F�U�����̖��ׂ����݂��Ȃ��ꍇ�́A�^�p�����ő匈�ϓ��Ƃ��Đݒ肷��
		If strMAXTEGDT = "" Then
			If Trim(pstrTEGDT) <> "" Then
				strMAXTEGDT = Trim(pstrTEGDT)
			Else
				'2009/10/07 UPD START RISE)MIYAJIMA
				'            strMAXTEGDT = Trim(GV_UNYDate)
				strMAXTEGDT = Trim(URKET52_HEAD_Inf.NYUDT)
				'2009/10/07 UPD E.N.D RISE)MIYAJIMA
			End If
		End If
		
		F_GET_MaeukeTEGDT = strMAXTEGDT
		
F_GET_MaeukeTEGDT_end: 
		
		Exit Function
		
F_GET_MaeukeTEGDT_err: 
		GoTo F_GET_MaeukeTEGDT_end
		
	End Function
	'2009/09/18 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/27 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_RATERT
	'   �T�v�F  �ʉ݂ɑ΂��郌�[�g���擾����
	'   �����F  pstrTUKKB�F�ʉ݋敪,pstrUDNDT�F�������
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_RATERT(ByVal pstrTUKKB As String, ByVal pstrUDNDT As String) As Object
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_F_Get_RATERT
		
		'UPGRADE_WARNING: �I�u�W�F�N�g F_Get_RATERT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		F_Get_RATERT = 0
		
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & " FROM TUKMTA "
		strSQL = strSQL & " WHERE TUKKB  =  '" & CF_Ora_String(pstrTUKKB, 3) & "' "
		strSQL = strSQL & "   AND TEKIDT <= '" & CF_Ora_String(pstrUDNDT, 8) & "' "
		strSQL = strSQL & " ORDER BY TEKIDT DESC "

        'DB�A�N�Z�X
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'If CF_Ora_EOF(Usr_Ody_LC) = False Then
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            'change end 20190826 kuwa
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'change start 20190826 kuwa
            'F_Get_RATERT = CF_Ora_GetDyn(Usr_Ody_LC, "RATERT", 0)
            F_Get_RATERT = DB_NullReplace(dt.Rows(0)("RATERT"), 0)
            'change end 20190826 kuwa
        End If

END_F_Get_RATERT: 
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_F_Get_RATERT: 
		GoTo END_F_Get_RATERT
		
	End Function
	'2009/09/27 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Util_Tourai
	'   �T�v�F  �����������Ă��邩�̔��f���s��
	'   �����F  pm_All             : ��ʏ��
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Util_Tourai(ByRef pm_All As Cls_All) As Object
		
		Dim I As Short
		Dim J As Short
		Dim Tbl_Inf_UDNTHA As TYPE_DB_UDNTHA
		Dim Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA
		
		On Error GoTo F_Util_Tourai_err
		
		'UPGRADE_WARNING: �I�u�W�F�N�g F_Util_Tourai �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		F_Util_Tourai = 9
		
		pv_intTouraiKbn = 0
		
		For I = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			
			If Trim(pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.DKBID) <> "" Then
				
				If URKET52_HEAD_Inf.UDNTHA.NYUCD <> "2" Then
					'�ʏ�
					'                For J = I To UBound(URKET52_HEAD_Inf.UDNTRA)
					For J = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
						'�ύX�O�̏����\���̂ɃR�s�[
						'UPGRADE_WARNING: �I�u�W�F�N�g Tbl_Inf_UDNTRA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(J)
						If Trim(Tbl_Inf_UDNTRA.DATNO) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.DATNO) And Trim(Tbl_Inf_UDNTRA.LINNO) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.LINNO) Then
							'����敪�]��
							URKET52_HEAD_Inf.DKBID(J) = pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.DKBID
							'����敪���قȂ��Ă��邩�̔��f
							If Trim(Tbl_Inf_UDNTRA.DKBID) <> Trim(pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.DKBID) Then
								If Trim(Tbl_Inf_UDNTRA.TEGDT) <> "" Then
									'2009/10/07 UPD START RISE)MIYAJIMA
									'                                If Trim(Tbl_Inf_UDNTRA.TEGDT) <= Trim(GV_UNYDate) Then
									If Trim(Tbl_Inf_UDNTRA.TEGDT) <= Trim(GV_UNYDate) Or Trim(Tbl_Inf_UDNTRA.TEGDT) <= Trim(URKET52_HEAD_Inf.NYUDT) Then
										'2009/10/07 UPD E.N.D RISE)MIYAJIMA
										'�������������Ă���̂Ńt���OON
										URKET52_HEAD_Inf.TEGKB(J) = 1
										pv_intTouraiKbn = 1
									End If
								End If
							End If
						End If
					Next J
				Else
					'�O��
					'                For J = I To UBound(URKET52_HEAD_Inf.UDNTRA)
					For J = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
						'�ύX�O�̏����\���̂ɃR�s�[
						'UPGRADE_WARNING: �I�u�W�F�N�g Tbl_Inf_UDNTRA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(J)
						If Trim(Tbl_Inf_UDNTRA.DATNO) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.DATNO) And Trim(Tbl_Inf_UDNTRA.LINNO) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.LINNO) Then
							'����敪�]��
							URKET52_HEAD_Inf.DKBID(J) = pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.DKBID
							If Trim(Tbl_Inf_UDNTRA.NYUKB) = "2" Then
								'����敪���قȂ��Ă��邩�̔��f
								If Trim(Tbl_Inf_UDNTRA.DKBID) <> Trim(pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.DKBID) Then
									If Trim(Tbl_Inf_UDNTRA.TEGDT) <> "" Then
										'2009/10/07 UPD START RISE)MIYAJIMA
										'                                    If Trim(Tbl_Inf_UDNTRA.TEGDT) <= Trim(GV_UNYDate) Then
										If Trim(Tbl_Inf_UDNTRA.TEGDT) <= Trim(GV_UNYDate) Or Trim(Tbl_Inf_UDNTRA.TEGDT) <= Trim(URKET52_HEAD_Inf.NYUDT) Then
											'2009/10/07 UPD E.N.D RISE)MIYAJIMA
											'�������������Ă���̂Ńt���OON
											URKET52_HEAD_Inf.TEGKB(J) = 1
											pv_intTouraiKbn = 1
										End If
									End If
								End If
							End If
						End If
					Next J
				End If
				
			End If
		Next I
		
		'UPGRADE_WARNING: �I�u�W�F�N�g F_Util_Tourai �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		F_Util_Tourai = 0
		
F_Util_Tourai_end: 
		Exit Function
		
F_Util_Tourai_err: 
		GoTo F_Util_Tourai_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_HAITA_NKSSMX
	'   �T�v�F  ���������T�}���r������
	'   �����F  pm_All             : ��ʏ��
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HAITA_NKSSMX(ByRef pm_All As Cls_All) As Short
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		
		On Error GoTo F_Chk_HAITA_NKSSMX_err
		
		F_Chk_HAITA_NKSSMX = 9
		
		With URKET52_HEAD_Inf
			If .TOKMTA.FRNKB = gc_strFRNKB_FRN Then
				'�C�O
				strSQL = ""
				strSQL = strSQL & " SELECT * "
				strSQL = strSQL & " FROM NKSSMC "
				strSQL = strSQL & " WHERE TOKCD = '" & CF_Ora_String(.TOKCD, 10) & "' "
				strSQL = strSQL & "   AND TUKKB = '" & CF_Ora_String(.TOKMTA.TUKKB, 3) & "' "
				strSQL = strSQL & "   AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' "
				strSQL = strSQL & " FOR UPDATE "
			Else
				'����
				strSQL = ""
				strSQL = strSQL & " SELECT * "
				If .NYUKB = gc_strMAEUKKB_NML Then '����
					strSQL = strSQL & " FROM NKSSMA "
				Else '�O�����
					strSQL = strSQL & " FROM NKSSMB "
				End If
				strSQL = strSQL & " WHERE TOKCD = '" & CF_Ora_String(.TOKCD, 10) & "' "
				strSQL = strSQL & "   AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' "
				strSQL = strSQL & " FOR UPDATE "
			End If
		End With

        'DB�A�N�Z�X
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            ' �f�[�^�Ȃ��̏ꍇ
            F_Chk_HAITA_NKSSMX = 1
            GoTo F_Chk_HAITA_NKSSMX_end
        Else
            ' �X�V�O�f�[�^�ƈقȂ�f�[�^�����݂����ꍇ�̓G���[�Ƃ���B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, CLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, OPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'change start 20190826 kuwa
            'If gc_NKSSMX_Inf.strOPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or gc_NKSSMX_Inf.strCLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or gc_NKSSMX_Inf.strWRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or gc_NKSSMX_Inf.strWRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Then
            If gc_NKSSMX_Inf.strOPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or gc_NKSSMX_Inf.strCLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or gc_NKSSMX_Inf.strWRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or gc_NKSSMX_Inf.strWRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Then
                'change end 20190826 kuwa
                GoTo F_Chk_HAITA_NKSSMX_end
            End If
        End If
		
		F_Chk_HAITA_NKSSMX = 0
		
F_Chk_HAITA_NKSSMX_end: 
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
F_Chk_HAITA_NKSSMX_err: 
		GoTo F_Chk_HAITA_NKSSMX_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_DspIndex
	'   �T�v�F  ��ʂ̂ǂ��Ɋi�[����Ă��邩��������
	'   �����F  pm_All             : ��ʏ��
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_DspIndex(ByRef pm_All As Cls_All, ByRef strDATNO As String, ByRef strLINNO As String) As Object
		
		Dim I As Short
		
		On Error GoTo F_Get_DspIndex_err
		
		'UPGRADE_WARNING: �I�u�W�F�N�g F_Get_DspIndex �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		F_Get_DspIndex = 0
		
		For I = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			If Trim(strDATNO) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.DATNO) And Trim(strLINNO) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.LINNO) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g F_Get_DspIndex �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				F_Get_DspIndex = I
			End If
		Next I
		
F_Get_DspIndex_end: 
		Exit Function
		
F_Get_DspIndex_err: 
		GoTo F_Get_DspIndex_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_UDNTRA_MakeInf_Tourai
	'   �T�v�F  ����g�����o�^�f�[�^�쐬
	'   �����F  pm_All             : ��ʏ��
	'           pin_intRow         : �s�ԍ�
	'           pin_strDATNO       : �`�[�Ǘ�NO.
	'           pin_strDENNO       : �`�[�ԍ�
	'           pin_strRECNO       : ���R�[�h�Ǘ�NO.
	'           pot_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UDNTRA_MakeInf_Tourai(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_strDATNO As String, ByVal pin_strDENNO As String, ByVal pin_strRECNO As String, ByRef pot_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		Dim strJdnNo As String
		Dim strJDNLINNO As String
		
		Dim strDKBSB As String
		Dim strDKBID As String
		Dim strDKBNM As String
		
		Dim curNYUKN As Decimal
		Dim dblFNYUKN As Double
		
		Dim strNYUKB As String
		
		Dim strLINCMA As String
		Dim strLINCMB As String
		Dim strBNKCD As String
		Dim strBNKNM As String
		Dim strTEGNO As String
		Dim strTEGDT As String
		Dim strUPDID As String
		Dim strDFLDKBCD As String
		Dim strDKBZAIFL As String
		Dim strDKBTEGFL As String
		Dim strDKBFLA As String
		Dim strDKBFLB As String
		Dim strDKBFLC As String
		
		'2009/06/05 ADD START FKS)NAKATA
		Dim strOKRJONO As String
		'2009/06/05 ADD E.N.D FKS)NAKATA
		
		Dim Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA
		Dim strKANKOZ As String
		
		On Error GoTo F_UDNTRA_MakeInf_Tourai_err
		
		F_UDNTRA_MakeInf_Tourai = 9
		
		'�󒍔ԍ�
		strJdnNo = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.JDNNO
		strJDNLINNO = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.JDNLINNO
		
		'2009/06/05 ADD START FKS)NAKATA
		strOKRJONO = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.OKRJONO
		'2009/06/05 ADD E.N.D FKS)NAKATA
		
		
		'����敪
		strDKBSB = pc_strDKBSB_URK
		strDKBID = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.DKBID
		strDKBNM = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.DKBNM
		
		'�����z
		curNYUKN = pot_Tbl_Inf_UDNTRA.NYUKN
		dblFNYUKN = pot_Tbl_Inf_UDNTRA.FNYUKN
		
		'�������
		'2009/09/18 UPD START RISE)MIYAJIMA
		'    Select Case Trim(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DFLDKBCD)
		'        Case "3":  strNYUKB = "4"
		'        Case "2":  strNYUKB = "2"
		'        Case Else: strNYUKB = "1"
		'    End Select
		Select Case Trim(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DFLDKBCD)
			Case "3" : strNYUKB = "4"
			Case "2" : strNYUKB = "2"
			Case Else : strNYUKB = "1"
		End Select
		If URKET52_HEAD_Inf.TOKMTA.SHAKB = pc_strSHAKB_KIJZITU Or URKET52_HEAD_Inf.TOKMTA.SHAKB = pc_strSHAKB_FACTERING Then
			Select Case Trim(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBID)
				Case pc_strDKBID_URK_SOSAI, pc_strDKBID_URK_NEBIK, pc_strDKBID_URK_TESU, pc_strDKBID_URK_HOKA, pc_strDKBID_URK_SYOH
					strNYUKB = "2"
			End Select
		End If
		'2009/09/18 UPD E.N.D RISE)MIYAJIMA
		
		strLINCMA = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.LINCMA
		strLINCMB = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.LINCMB
		strBNKCD = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.BNKCD
		strBNKNM = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.BNKNM
		strTEGNO = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.TEGNO
		strTEGDT = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.TEGDT
		strUPDID = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.UPDID
		strDFLDKBCD = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DFLDKBCD
		strDKBZAIFL = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBZAIFL
		strDKBTEGFL = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBTEGFL
		strDKBFLA = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBFLA
		strDKBFLB = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBFLB
		strDKBFLC = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBFLC
		strKANKOZ = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.KANKOZ
		
		With Tbl_Inf_UDNTRA
			.DATNO = pin_strDATNO '�`�[�Ǘ�NO.
			.DATKB = gc_strDATKB_USE '�`�[�폜�敪
			.AKAKROKB = gc_strAKAKROKB_AKA '�ԍ��敪
			.DENKB = "8" '�`�[�敪
			.UDNNO = pin_strDENNO '����`�[�ԍ�
			.LINNO = VB6.Format(pin_intRow, "000") '�s�ԍ�
			.ZKTKB = "" '����敪
			.ODNNO = "" '�o�ד`�[�ԍ�
			.ODNLINNO = "" '�s�ԍ�
			
			'2009/06/05 CHG START FKS)NAKATA
			'.JDNNO = strJdnNo                                   '�󒍓`�[�ԍ�
			'.JDNLINNO = strJDNLINNO                             '�󒍓`�[�s�ԍ�
			.JDNNO = "" '�󒍓`�[�ԍ�
			.JDNLINNO = "" '�󒍓`�[�s�ԍ�
			'2009/06/05 CHG E.N.D FKS)NAKATA
			
			.RECNO = pin_strRECNO '���R�[�h�Ǘ�NO.
			.USDNO = "" '�����`�[NO
			.UDNDT = URKET52_HEAD_Inf.NYUDT '����`�[���t
			.DKBSB = strDKBSB '�`�[����敪���
			.DKBID = strDKBID '����敪�R�[�h
			.DKBNM = strDKBNM '����敪����
			.HENRSNCD = "" '�ԕi���R
			.HENSTTCD = "" '�ԕi���
			.SMADT = pv_strSMADT '�o�������t
			.SSADT = pv_strSSADT '�����t
			.KESDT = pv_strKESDT '���ϓ��t
			.TOKCD = URKET52_HEAD_Inf.TOKCD '���Ӑ�R�[�h
			.TANCD = "" '�S���҃R�[�h
			.NHSCD = "" '�[����R�[�h
			.TOKSEICD = URKET52_HEAD_Inf.TOKCD '������R�[�h
			.SOUCD = "" '�q�ɃR�[�h
			.SBNNO = "" '����
			.HINCD = "" '���i�R�[�h
			.TOKJDNNO = "" '�q�撍���ԍ�
			.HINNMA = "" '�^��
			.HINNMB = "" '���i���P
			.UNTCD = "" '�P�ʃR�[�h
			.UNTNM = "" '�P�ʖ�
			.IRISU = 0 '����
			.CASSU = 0 '�P�[�X��
			.URISU = 0 '���㐔��
			.URITK = 0 '�P��
			.GNKTK = 0 '�����P��
			.SIKTK = 0 '�c�Ǝd�ؒP��
			.FURITK = 0 '�O�ݒP��
			.URIKN = 0 '������z
			.FURIKN = 0 '�O�ݔ�����z
			.SIKKN = 0 '�c�Ǝd�؋��z
			.UZEKN = 0 '����ŋ��z
			.NYUDT = "" '������
			.NYUKN = curNYUKN '�����z
			.FNYUKN = dblFNYUKN '�O�ݓ����z
			.GNKKN = 0 '�������z
			.JKESIKN = 0 '�������z
			.FKESIKN = 0 '�O�ݏ������z
			
			'2009/06/05 ADD START FKS)NAKATA
			'.KESIKB = ""                                        '�����敪
			.KESIKB = CStr(9)
			'2009/06/05 ADD E.N.D FKS)NAKATA
			
			.NYUKB = strNYUKB '�������
			.TNKID = "" '���
			.TUKKB = URKET52_HEAD_Inf.TOKMTA.TUKKB '�ʉ݋敪
			'2009/09/27 UPD START RISE)MIYAJIMA
			'        .RATERT = 0                                         '�בփ��[�g
			'UPGRADE_WARNING: �I�u�W�F�N�g F_Get_RATERT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.RATERT = F_Get_RATERT(URKET52_HEAD_Inf.TOKMTA.TUKKB, URKET52_HEAD_Inf.NYUDT) '�בփ��[�g
			'2009/09/27 UPD E.N.D RISE)MIYAJIMA
			.EMGODNKB = "" '�ً}�o�׋敪
			
			'2009/06/05 CHG START FKS)NAKATA
			'.OKRJONO = ""                                       '�����
			.OKRJONO = strOKRJONO
			'2009/06/05 CHG E.N.D FKS)NAKATA
			
			.INVNO = "" '�C���{�C�X��
			.LINCMA = strLINCMA '���ה��l�P
			.LINCMB = strLINCMB '���ה��l�Q
			.BNKCD = strBNKCD '��s�R�[�h
			.BNKNM = strBNKNM '��s����
			.TEGNO = strTEGNO '��`�ԍ�
			'2009/09/18 UPD START RISE)MIYAJIMA
			.TEGDT = strTEGDT '��`����
			If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML Then
				.TEGDT = strTEGDT '��`����
			Else
				If URKET52_HEAD_Inf.TOKMTA.SHAKB = pc_strSHAKB_KIJZITU Or URKET52_HEAD_Inf.TOKMTA.SHAKB = pc_strSHAKB_FACTERING Then
					If .DKBID <> pc_strDKBID_URK_GENKN And .DKBID <> pc_strDKBID_URK_HURI And .DKBID <> pc_strDKBID_URK_TEG And .DKBID <> pc_strDKBID_URK_HNYU And .DKBID <> pc_strDKBID_URK_HURIK Then
						.TEGDT = F_GET_MaeukeTEGDT(pm_All, Trim(strOKRJONO), strTEGDT) '��`����
					Else
						.TEGDT = strTEGDT '��`����
					End If
				End If
			End If
			'2009/09/18 UPD E.N.D RISE)MIYAJIMA
			.UPDID = strUPDID '�X�V�p���ޯ��(ACNT)
			.DFLDKBCD = strDFLDKBCD '�f�t�H���g�R�[�h
			.DKBZAIFL = strDKBZAIFL '�݌Ɋ֘A�t���O
			.DKBTEGFL = strDKBTEGFL '��`�����t���O
			.DKBFLA = strDKBFLA '�_�~�[�t���O�P
			.DKBFLB = strDKBFLB '�_�~�[�t���O�Q
			.DKBFLC = strDKBFLC '�_�~�[�t���O�R
			.LSTID = "" '�`�[���
			.HINZEIKB = "" '���i����ŋ敪
			.HINMSTKB = "" '�}�X�^�敪(���i)
			.TOKMSTKB = "" '�}�X�^�敪(���Ӑ�)
			.NHSMSTKB = "" '�}�X�^�敪(�[����)
			.TANMSTKB = "" '�}�X�^�敪(�S����)
			.ZEIRNKKB = "" '����Ń����N
			.HINKB = "" '���i�敪
			.ZEIRT = 0 '����ŗ�
			.ZAIKB = "" '�݌ɊǗ��敪
			.MRPKB = "" '�W�J�敪
			.HINJUNKB = "" '���ʕ\�o�͋敪
			.MAKCD = "" '���[�J�[�R�[�h
			.HINSIRCD = strKANKOZ '���i�d����R�[�h
			.HINNMMKB = "" '�����ƭ�ً敪(���i)
			.HRTDD = "" '�������[�h�^�C��
			.ORTDD = "" '�o�׃��[�h�^�C��
			.ZNKURIKN = 0 '�Ŕ��ېőΏۊz
			.ZKMURIKN = 0 '�ō��ېőΏۊz
			.ZKMUZEKN = 0 '�ō������
			.MOTDATNO = URKET52_HEAD_Inf.UDNTHA.DATNO '���`�[�Ǘ��ԍ�
			.FOPEID = SSS_OPEID.Value '����o�^���[�UID
			.FCLTID = SSS_CLTID.Value '����o�^�N���C�A���gID
			.WRTFSTTM = GV_SysTime '�^�C���X�^���v�i�o�^���ԁj
			.WRTFSTDT = GV_SysDate '�^�C���X�^���v�i�o�^���j
			.OPEID = SSS_OPEID.Value '�ŏI��Ǝ҃R�[�h
			.CLTID = SSS_CLTID.Value '�N���C�A���g�h�c
			.WRTTM = GV_SysTime '�^�C���X�^���v�i���ԁj
			.WRTDT = GV_SysDate '�^�C���X�^���v�i���t�j
			.UOPEID = SSS_OPEID.Value '���[�UID�i�o�b�`�j
			.UCLTID = SSS_CLTID.Value '�N���C�A���gID�i�o�b�`�j
			.UWRTTM = GV_SysTime '�^�C���X�^���v�i�o�b�`���ԁj
			.UWRTDT = GV_SysDate '�^�C���X�^���v�i�o�b�`���t�j
			.PGID = SSS_PrgId '�X�VPGID
			.DLFLG = gc_strDLFLG_UPD '�폜�t���O
		End With
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pot_Tbl_Inf_UDNTRA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pot_Tbl_Inf_UDNTRA = Tbl_Inf_UDNTRA
		
		F_UDNTRA_MakeInf_Tourai = 0
		
F_UDNTRA_MakeInf_Tourai_end: 
		Exit Function
		
F_UDNTRA_MakeInf_Tourai_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UDNTRA_MakeInf_Tourai")
		GoTo F_UDNTRA_MakeInf_Tourai_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_UPDSMF
	'   �T�v�F  �T�}���t�@�C���Q�̍X�V
	'   �����F  pm_All             : ��ʏ��
	'           pin_intRow         : �s�ԍ�
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�����f�[�^
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UPDSMF2(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByVal pin_strOLDDKBID As String, ByVal pin_strNEWDKBID As String, ByVal pin_intTEGKB As Short) As Short
		
		Dim intRet As Short
		
		On Error GoTo F_UPDSMF2_err
		
		F_UPDSMF2 = 9
		
		'�X�V�����F�����敪���P�F���� ���� �f�t�H���g�R�[�h���R
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML And Trim(pin_Tbl_Inf_UDNTRA.DFLDKBCD) <> "3" Then
			'�����T�}���X�V
			intRet = F_TOKSSA(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF2 = intRet
				GoTo F_UPDSMF2_err
			End If
			
			'���������T�}���̍X�V
			intRet = F_NKSSMA2(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA, pin_strOLDDKBID, pin_strNEWDKBID, pin_intTEGKB)
			If intRet <> 0 Then
				F_UPDSMF2 = intRet
				GoTo F_UPDSMF2_err
			End If
			
		End If
		
		'�X�V�����F�����敪���Q�F�O�����
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE And Trim(pin_Tbl_Inf_UDNTRA.DFLDKBCD) <> "3" Then
			'2009/09/24 UPD E.N.D RISE)MIYAJIMA
			'�O�󐿋��T�}���X�V
			intRet = F_TOKSSB(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF2 = intRet
				GoTo F_UPDSMF2_err
			End If
			
			'���������T�}���O��̍X�V
			intRet = F_NKSSMB2(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA, pin_strOLDDKBID, pin_strNEWDKBID, pin_intTEGKB)
			If intRet <> 0 Then
				F_UPDSMF2 = intRet
				GoTo F_UPDSMF2_err
			End If
		End If
		
		'�X�V�����F�����敪���P�F���� ���� �C�O����敪���P�F�C�O
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML And URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN Then
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML And URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN And Trim(pin_Tbl_Inf_UDNTRA.DFLDKBCD) <> "3" Then
			'2009/09/24 UPD E.N.D RISE)MIYAJIMA
			'�����T�}���O�݂̍X�V
			intRet = F_TOKSSC(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF2 = intRet
				GoTo F_UPDSMF2_err
			End If
			
			'���������T�}���O�݂̍X�V
			intRet = F_NKSSMC2(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA, pin_strOLDDKBID, pin_strNEWDKBID, pin_intTEGKB)
			If intRet <> 0 Then
				F_UPDSMF2 = intRet
				GoTo F_UPDSMF2_err
			End If
		End If
		
		'�X�V�����F�����敪���P�F���� ���� �f�t�H���g�R�[�h���Q
		'�X�V�����F�����敪���Q�F�O�����
		If (URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML And Trim(pin_Tbl_Inf_UDNTRA.DFLDKBCD) <> "2") Or URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			'���|�T�}�������̍X�V
			intRet = F_TOKSME(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF2 = intRet
				GoTo F_UPDSMF2_err
			End If
		End If
		
		F_UPDSMF2 = 0
		
F_UPDSMF2_end: 
		Exit Function
		
F_UPDSMF2_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UPDSMF")
		GoTo F_UPDSMF2_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_NKSSMA2
	'   �T�v�F  ���������T�}������
	'   �����F  pm_All             : ��ʏ��
	'           pin_intRow         : �s�ԍ�
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMA2(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByVal pin_strOLDDKBID As String, ByVal pin_strNEWDKBID As String, ByVal pin_intTEGKB As Short) As Short
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim I As Short
		
		Dim Mst_Inf_SYSTBD As TYPE_DB_SYSTBD
		Dim curKSKZANKN(9) As Decimal '�����W�v���z
		Dim durKSKZANKN_WK As Decimal
		Dim durNYUKINKN_WK As Decimal
		Dim intOLDUPDID As Decimal
		Dim intNEWUPDID As Decimal
		Dim lngRowCnt As Integer
		
		On Error GoTo F_NKSSMA2_err
		
		F_NKSSMA2 = 9
		
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & " FROM NKSSMA "
		strSQL = strSQL & " WHERE TOKCD = '" & CF_Ora_String(URKET52_HEAD_Inf.TOKCD, 10) & "' "
		strSQL = strSQL & "   AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' "

        'DB�A�N�Z�X
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) <> True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            '�擾�f�[�^����
            For I = 0 To 9
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'change start 20190826 kuwa
                'curKSKZANKN(I) = CF_Ora_GetDyn(Usr_Ody, "KSKZANKN" & VB6.Format(I, "00"), 0)
                curKSKZANKN(I) = DB_NullReplace(dt.Rows(0)("KSKZANKN" & VB6.Format(I, "00")), 0)
                'change end 20190826 kuwa
            Next I
        End If

        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)
		
		'UPDID�擾
		Call SYSTBD_SEARCH(pc_strDKBSB_URK, pin_strOLDDKBID, Mst_Inf_SYSTBD)
		intOLDUPDID = CDec(Mst_Inf_SYSTBD.UPDID)
		Call SYSTBD_SEARCH(pc_strDKBSB_URK, pin_strNEWDKBID, Mst_Inf_SYSTBD)
		intNEWUPDID = CDec(Mst_Inf_SYSTBD.UPDID)
		
		durNYUKINKN_WK = pin_Tbl_Inf_UDNTRA.NYUKN * pin_intSMFKB
		durKSKZANKN_WK = curKSKZANKN(intOLDUPDID) + durNYUKINKN_WK
		If curKSKZANKN(intOLDUPDID) > 0 Then
			If durKSKZANKN_WK >= 0 Then
				curKSKZANKN(intOLDUPDID) = durKSKZANKN_WK
				durKSKZANKN_WK = 0
			Else
				curKSKZANKN(intOLDUPDID) = curKSKZANKN(intOLDUPDID) + (durNYUKINKN_WK - durKSKZANKN_WK)
			End If
		End If
		
		If durKSKZANKN_WK < 0 Then
			curKSKZANKN(intNEWUPDID) = curKSKZANKN(intNEWUPDID) + durKSKZANKN_WK
		End If
		
		'�v�Z���ʂ��X�V����
		If F_NKSSMA2_Update(pm_All, pin_Tbl_Inf_UDNTRA, curKSKZANKN, lngRowCnt) <> 0 Then
			GoTo F_NKSSMA2_err
		End If
		
		'�X�V�Ώۂ��Ȃ�������A�V�K�o�^����
		If lngRowCnt <= 0 Then
			If F_NKSSMA2_Insert(pm_All, pin_Tbl_Inf_UDNTRA, curKSKZANKN) <> 0 Then
				GoTo F_NKSSMA2_err
			End If
		End If
		
		F_NKSSMA2 = 0
		
F_NKSSMA2_end: 
		Exit Function
		
F_NKSSMA2_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMA2")
		GoTo F_NKSSMA2_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_NKSSMB2
	'   �T�v�F  ���������T�}���O�󏈗�
	'   �����F  pm_All             : ��ʏ��
	'           pin_intRow         : �s�ԍ�
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMB2(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByVal pin_strOLDDKBID As String, ByVal pin_strNEWDKBID As String, ByVal pin_intTEGKB As Short) As Short
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim I As Short
		
		Dim Mst_Inf_SYSTBD As TYPE_DB_SYSTBD
		Dim curKSKZANKN(9) As Decimal '�����W�v���z
		Dim durKSKZANKN_WK As Decimal
		Dim durNYUKINKN_WK As Decimal
		Dim intOLDUPDID As Decimal
		Dim intNEWUPDID As Decimal
		Dim lngRowCnt As Integer
		
		On Error GoTo F_NKSSMB2_err
		
		F_NKSSMB2 = 9
		
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & " FROM NKSSMB "
		strSQL = strSQL & " WHERE TOKCD = '" & CF_Ora_String(URKET52_HEAD_Inf.TOKCD, 10) & "' "
		strSQL = strSQL & "   AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' "

        'DB�A�N�Z�X
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) <> True Then
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            'change end 20190826 kuwa
            '�擾�f�[�^����
            For I = 0 To 9
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'change start 20190826 kuwa
                'curKSKZANKN(I) = CF_Ora_GetDyn(Usr_Ody, "KSKZANKN" & VB6.Format(I, "00"), 0)
                curKSKZANKN(I) = DB_NullReplace(dt.Rows(0)("KSKZANKN" & VB6.Format(I, "00")), 0)
                'change end 20190826 kuwa
            Next I
        End If

        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)
		
		'UPDID�擾
		Call SYSTBD_SEARCH(pc_strDKBSB_URK, pin_strOLDDKBID, Mst_Inf_SYSTBD)
		intOLDUPDID = CDec(Mst_Inf_SYSTBD.UPDID)
		Call SYSTBD_SEARCH(pc_strDKBSB_URK, pin_strNEWDKBID, Mst_Inf_SYSTBD)
		intNEWUPDID = CDec(Mst_Inf_SYSTBD.UPDID)
		
		durNYUKINKN_WK = pin_Tbl_Inf_UDNTRA.NYUKN * pin_intSMFKB
		durKSKZANKN_WK = curKSKZANKN(intOLDUPDID) + durNYUKINKN_WK
		If curKSKZANKN(intOLDUPDID) > 0 Then
			If durKSKZANKN_WK >= 0 Then
				curKSKZANKN(intOLDUPDID) = durKSKZANKN_WK
				durKSKZANKN_WK = 0
			Else
				curKSKZANKN(intOLDUPDID) = curKSKZANKN(intOLDUPDID) + (durNYUKINKN_WK - durKSKZANKN_WK)
			End If
			
			If durKSKZANKN_WK < 0 Then
				curKSKZANKN(intNEWUPDID) = curKSKZANKN(intNEWUPDID) + durKSKZANKN_WK
			End If
		End If
		
		'�v�Z���ʂ��X�V����
		If F_NKSSMB2_Update(pm_All, pin_Tbl_Inf_UDNTRA, curKSKZANKN, lngRowCnt) <> 0 Then
			GoTo F_NKSSMB2_err
		End If
		
		'�X�V�Ώۂ��Ȃ�������A�V�K�o�^����
		If lngRowCnt <= 0 Then
			If F_NKSSMB2_Insert(pm_All, pin_Tbl_Inf_UDNTRA, curKSKZANKN) <> 0 Then
				GoTo F_NKSSMB2_err
			End If
		End If
		
		F_NKSSMB2 = 0
		
F_NKSSMB2_end: 
		Exit Function
		
F_NKSSMB2_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMB2")
		GoTo F_NKSSMB2_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_NKSSMC2
	'   �T�v�F  ���������T�}���O�ݏ���
	'   �����F  pm_All             : ��ʏ��
	'           pin_intRow         : �s�ԍ�
	'           pin_intSMFKB       : ����(���`�[�̏ꍇ��+1�A�ԓ`�[�̏ꍇ��-1)
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMC2(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByVal pin_strOLDDKBID As String, ByVal pin_strNEWDKBID As String, ByVal pin_intTEGKB As Short) As Short
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim I As Short
		
		Dim Mst_Inf_SYSTBD As TYPE_DB_SYSTBD
		Dim curKSKZANKN(9) As Decimal '�����W�v���z
		Dim durKSKZANKN_WK As Decimal
		Dim durNYUKINKN_WK As Decimal
		Dim intOLDUPDID As Decimal
		Dim intNEWUPDID As Decimal
		Dim lngRowCnt As Integer
		
		On Error GoTo F_NKSSMC2_err
		
		F_NKSSMC2 = 9
		
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & " FROM NKSSMC "
		strSQL = strSQL & " WHERE TOKCD = '" & CF_Ora_String(URKET52_HEAD_Inf.TOKCD, 10) & "' "
		strSQL = strSQL & "   AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' "
		strSQL = strSQL & "   AND TUKKB = '" & CF_Ora_String(URKET52_HEAD_Inf.TOKMTA.TUKKB, 3) & "' "

        'DB�A�N�Z�X
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) <> True Then
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            'change end 20190826 kuwa
            '�擾�f�[�^����
            For I = 0 To 9
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'change start 20190826 kuwa
                'curKSKZANKN(I) = CF_Ora_GetDyn(Usr_Ody, "KSKZANKN" & VB6.Format(I, "00"), 0)
                curKSKZANKN(I) = DB_NullReplace(dt.Rows(0)("KSKZANKN" & VB6.Format(I, "00")), 0)
                'change end 20190826 kuwa
            Next I
        End If

        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)
		
		'UPDID�擾
		Call SYSTBD_SEARCH(pc_strDKBSB_URK, pin_strOLDDKBID, Mst_Inf_SYSTBD)
		intOLDUPDID = CDec(Mst_Inf_SYSTBD.UPDID)
		Call SYSTBD_SEARCH(pc_strDKBSB_URK, pin_strNEWDKBID, Mst_Inf_SYSTBD)
		intNEWUPDID = CDec(Mst_Inf_SYSTBD.UPDID)
		
		durNYUKINKN_WK = pin_Tbl_Inf_UDNTRA.FNYUKN * pin_intSMFKB
		durKSKZANKN_WK = curKSKZANKN(intOLDUPDID) + durNYUKINKN_WK
		If curKSKZANKN(intOLDUPDID) > 0 Then
			If durKSKZANKN_WK >= 0 Then
				curKSKZANKN(intOLDUPDID) = durKSKZANKN_WK
				durKSKZANKN_WK = 0
			Else
				curKSKZANKN(intOLDUPDID) = curKSKZANKN(intOLDUPDID) + (durNYUKINKN_WK - durKSKZANKN_WK)
			End If
			
			If durKSKZANKN_WK < 0 Then
				curKSKZANKN(intNEWUPDID) = curKSKZANKN(intNEWUPDID) + durKSKZANKN_WK
			End If
		End If
		
		'�v�Z���ʂ��X�V����
		If F_NKSSMC2_Update(pm_All, pin_Tbl_Inf_UDNTRA, curKSKZANKN, lngRowCnt) <> 0 Then
			GoTo F_NKSSMC2_err
		End If
		
		'�X�V�Ώۂ��Ȃ�������A�V�K�o�^����
		If lngRowCnt <= 0 Then
			If F_NKSSMC2_Insert(pm_All, pin_Tbl_Inf_UDNTRA, curKSKZANKN) <> 0 Then
				GoTo F_NKSSMC2_err
			End If
		End If
		
		F_NKSSMC2 = 0
		
F_NKSSMC2_end: 
		Exit Function
		
F_NKSSMC2_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMC2")
		GoTo F_NKSSMC2_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_NKSSMA2_Update
	'   �T�v�F  ���������T�}���X�V
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'           pin_curKSKZANKN    : �����W�v���z
	'           pot_lngRowCnt      : �X�V����
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMA2_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curKSKZANKN() As Decimal, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMA2_Update_err
		
		F_NKSSMA2_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE NKSSMA "
		strSQL = strSQL & "    SET KSKZANKN00 = " & CStr(pin_curKSKZANKN(0)) '�O�������������z00
		strSQL = strSQL & "      , KSKZANKN01 = " & CStr(pin_curKSKZANKN(1)) '�O�������������z01
		strSQL = strSQL & "      , KSKZANKN02 = " & CStr(pin_curKSKZANKN(2)) '�O�������������z02
		strSQL = strSQL & "      , KSKZANKN03 = " & CStr(pin_curKSKZANKN(3)) '�O�������������z03
		strSQL = strSQL & "      , KSKZANKN04 = " & CStr(pin_curKSKZANKN(4)) '�O�������������z04
		strSQL = strSQL & "      , KSKZANKN05 = " & CStr(pin_curKSKZANKN(5)) '�O�������������z05
		strSQL = strSQL & "      , KSKZANKN06 = " & CStr(pin_curKSKZANKN(6)) '�O�������������z06
		strSQL = strSQL & "      , KSKZANKN07 = " & CStr(pin_curKSKZANKN(7)) '�O�������������z07
		strSQL = strSQL & "      , KSKZANKN08 = " & CStr(pin_curKSKZANKN(8)) '�O�������������z08
		strSQL = strSQL & "      , KSKZANKN09 = " & CStr(pin_curKSKZANKN(9)) '�O�������������z09
		strSQL = strSQL & "      , OPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "      , CLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���gID
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' " '�o�������t
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_NKSSMA2_Update_err
		End If
		
		F_NKSSMA2_Update = 0
		
F_NKSSMA2_Update_end: 
		Exit Function
		
F_NKSSMA2_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMA2_Update")
		GoTo F_NKSSMA2_Update_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_NKSSMA2_Insert
	'   �T�v�F  ���������T�}���V�K�o�^
	'   �����F
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMA2_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curKSKZANKN() As Decimal) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMA2_Insert_err
		
		F_NKSSMA2_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO NKSSMA "
		strSQL = strSQL & "        ( TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "        , SMADT " '�o�������t
		strSQL = strSQL & "        , SSANYUKN00 " '�����W�v���z00
		strSQL = strSQL & "        , SSANYUKN01 " '�����W�v���z01
		strSQL = strSQL & "        , SSANYUKN02 " '�����W�v���z02
		strSQL = strSQL & "        , SSANYUKN03 " '�����W�v���z03
		strSQL = strSQL & "        , SSANYUKN04 " '�����W�v���z04
		strSQL = strSQL & "        , SSANYUKN05 " '�����W�v���z05
		strSQL = strSQL & "        , SSANYUKN06 " '�����W�v���z06
		strSQL = strSQL & "        , SSANYUKN07 " '�����W�v���z07
		strSQL = strSQL & "        , SSANYUKN08 " '�����W�v���z08
		strSQL = strSQL & "        , SSANYUKN09 " '�����W�v���z09
		strSQL = strSQL & "        , KSKNYKKN00 " '���������W�v���z00
		strSQL = strSQL & "        , KSKNYKKN01 " '���������W�v���z01
		strSQL = strSQL & "        , KSKNYKKN02 " '���������W�v���z02
		strSQL = strSQL & "        , KSKNYKKN03 " '���������W�v���z03
		strSQL = strSQL & "        , KSKNYKKN04 " '���������W�v���z04
		strSQL = strSQL & "        , KSKNYKKN05 " '���������W�v���z05
		strSQL = strSQL & "        , KSKNYKKN06 " '���������W�v���z06
		strSQL = strSQL & "        , KSKNYKKN07 " '���������W�v���z07
		strSQL = strSQL & "        , KSKNYKKN08 " '���������W�v���z08
		strSQL = strSQL & "        , KSKNYKKN09 " '���������W�v���z09
		strSQL = strSQL & "        , KSKZANKN00 " '�O�������������z00
		strSQL = strSQL & "        , KSKZANKN01 " '�O�������������z01
		strSQL = strSQL & "        , KSKZANKN02 " '�O�������������z02
		strSQL = strSQL & "        , KSKZANKN03 " '�O�������������z03
		strSQL = strSQL & "        , KSKZANKN04 " '�O�������������z04
		strSQL = strSQL & "        , KSKZANKN05 " '�O�������������z05
		strSQL = strSQL & "        , KSKZANKN06 " '�O�������������z06
		strSQL = strSQL & "        , KSKZANKN07 " '�O�������������z07
		strSQL = strSQL & "        , KSKZANKN08 " '�O�������������z08
		strSQL = strSQL & "        , KSKZANKN09 " '�O�������������z09
		strSQL = strSQL & "        , OPEID " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "        , CLTID " '�N���C�A���gID
		strSQL = strSQL & "        , WRTTM " '��ѽ����(����)
		strSQL = strSQL & "        , WRTDT " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "        , '" & CF_Ora_String(pv_strSMADT, 8) & "' " '�o�������t
		strSQL = strSQL & "        ,  0 " '�����W�v���z00
		strSQL = strSQL & "        ,  0 " '�����W�v���z01
		strSQL = strSQL & "        ,  0 " '�����W�v���z02
		strSQL = strSQL & "        ,  0 " '�����W�v���z03
		strSQL = strSQL & "        ,  0 " '�����W�v���z04
		strSQL = strSQL & "        ,  0 " '�����W�v���z05
		strSQL = strSQL & "        ,  0 " '�����W�v���z06
		strSQL = strSQL & "        ,  0 " '�����W�v���z07
		strSQL = strSQL & "        ,  0 " '�����W�v���z08
		strSQL = strSQL & "        ,  0 " '�����W�v���z09
		strSQL = strSQL & "        ,  0 " '���������W�v���z00
		strSQL = strSQL & "        ,  0 " '���������W�v���z01
		strSQL = strSQL & "        ,  0 " '���������W�v���z02
		strSQL = strSQL & "        ,  0 " '���������W�v���z03
		strSQL = strSQL & "        ,  0 " '���������W�v���z04
		strSQL = strSQL & "        ,  0 " '���������W�v���z05
		strSQL = strSQL & "        ,  0 " '���������W�v���z06
		strSQL = strSQL & "        ,  0 " '���������W�v���z07
		strSQL = strSQL & "        ,  0 " '���������W�v���z08
		strSQL = strSQL & "        ,  0 " '���������W�v���z09
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(0)) '�O�������������z00
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(1)) '�O�������������z01
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(2)) '�O�������������z02
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(3)) '�O�������������z03
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(4)) '�O�������������z04
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(5)) '�O�������������z05
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(6)) '�O�������������z06
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(7)) '�O�������������z07
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(8)) '�O�������������z08
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(9)) '�O�������������z09
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���gID
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_NKSSMA2_Insert_err
		End If
		
		F_NKSSMA2_Insert = 0
		
F_NKSSMA2_Insert_end: 
		Exit Function
		
F_NKSSMA2_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMA2_Insert")
		GoTo F_NKSSMA2_Insert_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_NKSSMB2_Update
	'   �T�v�F  ���������T�}���O��X�V
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'           pin_curSSANYUKN    : �����W�v���z
	'           pot_lngRowCnt      : �X�V����
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMB2_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curKSKZANKN() As Decimal, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMB2_Update_err
		
		F_NKSSMB2_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE NKSSMB "
		strSQL = strSQL & "    SET KSKZANKN00 = " & CStr(pin_curKSKZANKN(0)) '�O�������������z00
		strSQL = strSQL & "      , KSKZANKN01 = " & CStr(pin_curKSKZANKN(1)) '�O�������������z01
		strSQL = strSQL & "      , KSKZANKN02 = " & CStr(pin_curKSKZANKN(2)) '�O�������������z02
		strSQL = strSQL & "      , KSKZANKN03 = " & CStr(pin_curKSKZANKN(3)) '�O�������������z03
		strSQL = strSQL & "      , KSKZANKN04 = " & CStr(pin_curKSKZANKN(4)) '�O�������������z04
		strSQL = strSQL & "      , KSKZANKN05 = " & CStr(pin_curKSKZANKN(5)) '�O�������������z05
		strSQL = strSQL & "      , KSKZANKN06 = " & CStr(pin_curKSKZANKN(6)) '�O�������������z06
		strSQL = strSQL & "      , KSKZANKN07 = " & CStr(pin_curKSKZANKN(7)) '�O�������������z07
		strSQL = strSQL & "      , KSKZANKN08 = " & CStr(pin_curKSKZANKN(8)) '�O�������������z08
		strSQL = strSQL & "      , KSKZANKN09 = " & CStr(pin_curKSKZANKN(9)) '�O�������������z09
		strSQL = strSQL & "      , OPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "      , CLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���gID
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' " '�o�������t
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_NKSSMB2_Update_err
		End If
		
		F_NKSSMB2_Update = 0
		
F_NKSSMB2_Update_end: 
		Exit Function
		
F_NKSSMB2_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMB2_Update")
		GoTo F_NKSSMB2_Update_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_NKSSMB2_Insert
	'   �T�v�F  ���������T�}���O��V�K�o�^
	'   �����F
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMB2_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curKSKZANKN() As Decimal) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMB2_Insert_err
		
		F_NKSSMB2_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO NKSSMB "
		strSQL = strSQL & "        ( TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "        , SMADT " '�o�������t
		strSQL = strSQL & "        , SSANYUKN00 " '�����W�v���z00
		strSQL = strSQL & "        , SSANYUKN01 " '�����W�v���z01
		strSQL = strSQL & "        , SSANYUKN02 " '�����W�v���z02
		strSQL = strSQL & "        , SSANYUKN03 " '�����W�v���z03
		strSQL = strSQL & "        , SSANYUKN04 " '�����W�v���z04
		strSQL = strSQL & "        , SSANYUKN05 " '�����W�v���z05
		strSQL = strSQL & "        , SSANYUKN06 " '�����W�v���z06
		strSQL = strSQL & "        , SSANYUKN07 " '�����W�v���z07
		strSQL = strSQL & "        , SSANYUKN08 " '�����W�v���z08
		strSQL = strSQL & "        , SSANYUKN09 " '�����W�v���z09
		strSQL = strSQL & "        , KSKNYKKN00 " '���������W�v���z00
		strSQL = strSQL & "        , KSKNYKKN01 " '���������W�v���z01
		strSQL = strSQL & "        , KSKNYKKN02 " '���������W�v���z02
		strSQL = strSQL & "        , KSKNYKKN03 " '���������W�v���z03
		strSQL = strSQL & "        , KSKNYKKN04 " '���������W�v���z04
		strSQL = strSQL & "        , KSKNYKKN05 " '���������W�v���z05
		strSQL = strSQL & "        , KSKNYKKN06 " '���������W�v���z06
		strSQL = strSQL & "        , KSKNYKKN07 " '���������W�v���z07
		strSQL = strSQL & "        , KSKNYKKN08 " '���������W�v���z08
		strSQL = strSQL & "        , KSKNYKKN09 " '���������W�v���z09
		strSQL = strSQL & "        , KSKZANKN00 " '�O�������������z00
		strSQL = strSQL & "        , KSKZANKN01 " '�O�������������z01
		strSQL = strSQL & "        , KSKZANKN02 " '�O�������������z02
		strSQL = strSQL & "        , KSKZANKN03 " '�O�������������z03
		strSQL = strSQL & "        , KSKZANKN04 " '�O�������������z04
		strSQL = strSQL & "        , KSKZANKN05 " '�O�������������z05
		strSQL = strSQL & "        , KSKZANKN06 " '�O�������������z06
		strSQL = strSQL & "        , KSKZANKN07 " '�O�������������z07
		strSQL = strSQL & "        , KSKZANKN08 " '�O�������������z08
		strSQL = strSQL & "        , KSKZANKN09 " '�O�������������z09
		strSQL = strSQL & "        , OPEID " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "        , CLTID " '�N���C�A���gID
		strSQL = strSQL & "        , WRTTM " '��ѽ����(����)
		strSQL = strSQL & "        , WRTDT " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "        , '" & CF_Ora_String(pv_strSMADT, 8) & "' " '�o�������t
		strSQL = strSQL & "        ,  0 " '�����W�v���z00
		strSQL = strSQL & "        ,  0 " '�����W�v���z01
		strSQL = strSQL & "        ,  0 " '�����W�v���z02
		strSQL = strSQL & "        ,  0 " '�����W�v���z03
		strSQL = strSQL & "        ,  0 " '�����W�v���z04
		strSQL = strSQL & "        ,  0 " '�����W�v���z05
		strSQL = strSQL & "        ,  0 " '�����W�v���z06
		strSQL = strSQL & "        ,  0 " '�����W�v���z07
		strSQL = strSQL & "        ,  0 " '�����W�v���z08
		strSQL = strSQL & "        ,  0 " '�����W�v���z09
		strSQL = strSQL & "        ,  0 " '���������W�v���z00
		strSQL = strSQL & "        ,  0 " '���������W�v���z01
		strSQL = strSQL & "        ,  0 " '���������W�v���z02
		strSQL = strSQL & "        ,  0 " '���������W�v���z03
		strSQL = strSQL & "        ,  0 " '���������W�v���z04
		strSQL = strSQL & "        ,  0 " '���������W�v���z05
		strSQL = strSQL & "        ,  0 " '���������W�v���z06
		strSQL = strSQL & "        ,  0 " '���������W�v���z07
		strSQL = strSQL & "        ,  0 " '���������W�v���z08
		strSQL = strSQL & "        ,  0 " '���������W�v���z09
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(0)) '�O�������������z00
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(1)) '�O�������������z01
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(2)) '�O�������������z02
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(3)) '�O�������������z03
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(4)) '�O�������������z04
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(5)) '�O�������������z05
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(6)) '�O�������������z06
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(7)) '�O�������������z07
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(8)) '�O�������������z08
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(9)) '�O�������������z09
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���gID
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_NKSSMB2_Insert_err
		End If
		
		F_NKSSMB2_Insert = 0
		
F_NKSSMB2_Insert_end: 
		Exit Function
		
F_NKSSMB2_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMB2_Insert")
		GoTo F_NKSSMB2_Insert_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_NKSSMC2_Update
	'   �T�v�F  ���������T�}���O�ݍX�V
	'   �����F  pm_All             : ��ʏ��
	'           pin_Tbl_Inf_UDNTRA : ����g�������
	'           pin_curSSANYUKN    : �����W�v���z
	'           pot_lngRowCnt      : �X�V����
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMC2_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curKSKZANKN() As Decimal, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMC2_Update_err
		
		F_NKSSMC2_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE NKSSMC "
		strSQL = strSQL & "    SET KSKZANKN00 = " & CStr(pin_curKSKZANKN(0)) '�O�������������z00
		strSQL = strSQL & "      , KSKZANKN01 = " & CStr(pin_curKSKZANKN(1)) '�O�������������z01
		strSQL = strSQL & "      , KSKZANKN02 = " & CStr(pin_curKSKZANKN(2)) '�O�������������z02
		strSQL = strSQL & "      , KSKZANKN03 = " & CStr(pin_curKSKZANKN(3)) '�O�������������z03
		strSQL = strSQL & "      , KSKZANKN04 = " & CStr(pin_curKSKZANKN(4)) '�O�������������z04
		strSQL = strSQL & "      , KSKZANKN05 = " & CStr(pin_curKSKZANKN(5)) '�O�������������z05
		strSQL = strSQL & "      , KSKZANKN06 = " & CStr(pin_curKSKZANKN(6)) '�O�������������z06
		strSQL = strSQL & "      , KSKZANKN07 = " & CStr(pin_curKSKZANKN(7)) '�O�������������z07
		strSQL = strSQL & "      , KSKZANKN08 = " & CStr(pin_curKSKZANKN(8)) '�O�������������z08
		strSQL = strSQL & "      , KSKZANKN09 = " & CStr(pin_curKSKZANKN(9)) '�O�������������z09
		strSQL = strSQL & "      , OPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "      , CLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���gID
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "    AND TUKKB = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TUKKB, 3) & "' " '�ʉ݋敪
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' " '�o�������t
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_NKSSMC2_Update_err
		End If
		
		F_NKSSMC2_Update = 0
		
F_NKSSMC2_Update_end: 
		Exit Function
		
F_NKSSMC2_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMC2_Update")
		GoTo F_NKSSMC2_Update_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_NKSSMC2_Insert
	'   �T�v�F  ���������T�}���O�ݐV�K�o�^
	'   �����F
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMC2_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curKSKZANKN() As Decimal) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMC2_Insert_err
		
		F_NKSSMC2_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO NKSSMC "
		strSQL = strSQL & "        ( TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "        , TUKKB " '�ʉ݋敪
		strSQL = strSQL & "        , SMADT " '�o�������t
		strSQL = strSQL & "        , SSANYUKN00 " '�����W�v���z00
		strSQL = strSQL & "        , SSANYUKN01 " '�����W�v���z01
		strSQL = strSQL & "        , SSANYUKN02 " '�����W�v���z02
		strSQL = strSQL & "        , SSANYUKN03 " '�����W�v���z03
		strSQL = strSQL & "        , SSANYUKN04 " '�����W�v���z04
		strSQL = strSQL & "        , SSANYUKN05 " '�����W�v���z05
		strSQL = strSQL & "        , SSANYUKN06 " '�����W�v���z06
		strSQL = strSQL & "        , SSANYUKN07 " '�����W�v���z07
		strSQL = strSQL & "        , SSANYUKN08 " '�����W�v���z08
		strSQL = strSQL & "        , SSANYUKN09 " '�����W�v���z09
		strSQL = strSQL & "        , KSKNYKKN00 " '���������W�v���z00
		strSQL = strSQL & "        , KSKNYKKN01 " '���������W�v���z01
		strSQL = strSQL & "        , KSKNYKKN02 " '���������W�v���z02
		strSQL = strSQL & "        , KSKNYKKN03 " '���������W�v���z03
		strSQL = strSQL & "        , KSKNYKKN04 " '���������W�v���z04
		strSQL = strSQL & "        , KSKNYKKN05 " '���������W�v���z05
		strSQL = strSQL & "        , KSKNYKKN06 " '���������W�v���z06
		strSQL = strSQL & "        , KSKNYKKN07 " '���������W�v���z07
		strSQL = strSQL & "        , KSKNYKKN08 " '���������W�v���z08
		strSQL = strSQL & "        , KSKNYKKN09 " '���������W�v���z09
		strSQL = strSQL & "        , KSKZANKN00 " '�O�������������z00
		strSQL = strSQL & "        , KSKZANKN01 " '�O�������������z01
		strSQL = strSQL & "        , KSKZANKN02 " '�O�������������z02
		strSQL = strSQL & "        , KSKZANKN03 " '�O�������������z03
		strSQL = strSQL & "        , KSKZANKN04 " '�O�������������z04
		strSQL = strSQL & "        , KSKZANKN05 " '�O�������������z05
		strSQL = strSQL & "        , KSKZANKN06 " '�O�������������z06
		strSQL = strSQL & "        , KSKZANKN07 " '�O�������������z07
		strSQL = strSQL & "        , KSKZANKN08 " '�O�������������z08
		strSQL = strSQL & "        , KSKZANKN09 " '�O�������������z09
		strSQL = strSQL & "        , OPEID " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "        , CLTID " '�N���C�A���gID
		strSQL = strSQL & "        , WRTTM " '��ѽ����(����)
		strSQL = strSQL & "        , WRTDT " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TUKKB, 3) & "' " '�ʉ݋敪
		strSQL = strSQL & "        , '" & CF_Ora_String(pv_strSMADT, 8) & "' " '�o�������t
		strSQL = strSQL & "        ,  0 " '�����W�v���z00
		strSQL = strSQL & "        ,  0 " '�����W�v���z01
		strSQL = strSQL & "        ,  0 " '�����W�v���z02
		strSQL = strSQL & "        ,  0 " '�����W�v���z03
		strSQL = strSQL & "        ,  0 " '�����W�v���z04
		strSQL = strSQL & "        ,  0 " '�����W�v���z05
		strSQL = strSQL & "        ,  0 " '�����W�v���z06
		strSQL = strSQL & "        ,  0 " '�����W�v���z07
		strSQL = strSQL & "        ,  0 " '�����W�v���z08
		strSQL = strSQL & "        ,  0 " '�����W�v���z09
		strSQL = strSQL & "        ,  0 " '���������W�v���z00
		strSQL = strSQL & "        ,  0 " '���������W�v���z01
		strSQL = strSQL & "        ,  0 " '���������W�v���z02
		strSQL = strSQL & "        ,  0 " '���������W�v���z03
		strSQL = strSQL & "        ,  0 " '���������W�v���z04
		strSQL = strSQL & "        ,  0 " '���������W�v���z05
		strSQL = strSQL & "        ,  0 " '���������W�v���z06
		strSQL = strSQL & "        ,  0 " '���������W�v���z07
		strSQL = strSQL & "        ,  0 " '���������W�v���z08
		strSQL = strSQL & "        ,  0 " '���������W�v���z09
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(0)) '�O�������������z00
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(1)) '�O�������������z01
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(2)) '�O�������������z02
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(3)) '�O�������������z03
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(4)) '�O�������������z04
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(5)) '�O�������������z05
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(6)) '�O�������������z06
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(7)) '�O�������������z07
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(8)) '�O�������������z08
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(9)) '�O�������������z09
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���gID
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " '��ѽ����(����)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " '��ѽ����(���t)
		strSQL = strSQL & "        ) "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_NKSSMC2_Insert_err
		End If
		
		F_NKSSMC2_Insert = 0
		
F_NKSSMC2_Insert_end: 
		Exit Function
		
F_NKSSMC2_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMC2_Insert")
		GoTo F_NKSSMC2_Insert_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/10/05 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_UODKN_JDNNO
	'   �T�v�F  �󒍌��o�E�󒍃g�����̔r�����擾
	'   �����F  pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Get_JDN_HAITA(ByRef pm_All As Cls_All) As Short
		
		Dim Tbl_Inf_UDNTHA As TYPE_DB_UDNTHA
		Dim Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA
		Dim intCnt As Short
		Dim strJdnNo As String
		Dim strJDNLINNO As String
		
		On Error GoTo F_Get_JDN_HAITA_err
		
		F_Get_JDN_HAITA = 9
		
		'������
		ReDim gc_JDNTHA_HAITA_Inf(0)
		ReDim gc_JDNTRA_HAITA_Inf(0)
		
		'�ύX�O���擾
		For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g Tbl_Inf_UDNTRA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
			
			'�󒍔ԍ�
			strJdnNo = Mid(Tbl_Inf_UDNTRA.OKRJONO, 1, 6)
			strJDNLINNO = Mid(Tbl_Inf_UDNTRA.OKRJONO, 7, 3)
			
			If Trim(strJdnNo) <> "" Then
				'�r�����擾
				Call F_Get_JDN_HAITA_Inf(strJdnNo)
			End If
			
		Next intCnt
		
		'�ύX����
		For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			
			'�󒍔ԍ�
			strJdnNo = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.JDNNO
			strJDNLINNO = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.JDNLINNO
			
			If Trim(strJdnNo) <> "" Then
				'�r�����擾
				Call F_Get_JDN_HAITA_Inf(strJdnNo)
			End If
			
		Next intCnt
		
		F_Get_JDN_HAITA = 0
		
F_Get_JDN_HAITA_end: 
		
		Exit Function
		
F_Get_JDN_HAITA_err: 
		GoTo F_Get_JDN_HAITA_end
		
	End Function
	'2009/10/05 ADD E.N.D RISE)MIYAJIMA
	
	'2009/10/05 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Util_Get_UODKN
	'   �T�v�F  �󒍃f�[�^�̔r�����擾
	'   �����F
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_JDN_HAITA_Inf(ByVal pin_strJDNNO As String) As Boolean
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		Dim strDATNO As String
		Dim strLINNO As String
		Dim intJDNTHAIndex As Short
		Dim intJDNTRAIndex As Short
		Dim I As Short
		
		On Error GoTo F_Get_JDN_HAITA_Inf_err
		
		F_Get_JDN_HAITA_Inf = False
		
		'�ŐV�̎󒍃f�[�^�̎擾
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "   FROM JDNTHA "
		strSQL = strSQL & "      , (SELECT MAX(DATNO) AS MAX_DATNO "
		strSQL = strSQL & "           FROM JDNTHA "
		strSQL = strSQL & "          WHERE JDNNO = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
		strSQL = strSQL & "            AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "            AND MAEUKKB  = '" & CF_Ora_String(pc_strMAEUKKB, 1) & "' "
		strSQL = strSQL & "        ) SUB "
		strSQL = strSQL & "  WHERE JDNNO        = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
		strSQL = strSQL & "    AND DATKB        = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "    AND AKAKROKB     = '" & CF_Ora_String(gc_strAKAKROKB_KURO, 1) & "' "
		strSQL = strSQL & "    AND TOKSEICD     = '" & URKET52_HEAD_Inf.TOKCD & "' "
		strSQL = strSQL & "    AND MAEUKKB      = '" & CF_Ora_String(pc_strMAEUKKB, 1) & "' "
		strSQL = strSQL & "    AND JDNTHA.DATNO = SUB.MAX_DATNO "

        'DB�A�N�Z�X
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            GoTo F_Get_JDN_HAITA_Inf_end
        End If

        '�`�[�Ǘ�NO�̎擾
        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190826 kuwa
        'strDATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")
        strDATNO = DB_NullReplace(dt.Rows(0)("DATNO"), "")
        'change end 20190826 kuwa

        intJDNTHAIndex = 0
		For I = 1 To UBound(gc_JDNTHA_HAITA_Inf)
			If Trim(gc_JDNTHA_HAITA_Inf(I).DATNO) = Trim(strDATNO) Then
				intJDNTHAIndex = I
				Exit For
			End If
		Next I
		If intJDNTHAIndex = 0 Then
			intJDNTHAIndex = UBound(gc_JDNTHA_HAITA_Inf) + 1
			ReDim Preserve gc_JDNTHA_HAITA_Inf(intJDNTHAIndex)

            With gc_JDNTHA_HAITA_Inf(intJDNTHAIndex)
                'change start 20190826 kuwa
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.JDNNO = CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.FOPEID = CF_Ora_GetDyn(Usr_Ody, "FOPEID", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.FCLTID = CF_Ora_GetDyn(Usr_Ody, "FCLTID", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.UOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.UCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "")

                .DATNO = DB_NullReplace(dt.Rows(0)("DATNO"), "")
                .JDNNO = DB_NullReplace(dt.Rows(0)("JDNNO"), "")
                .FOPEID = DB_NullReplace(dt.Rows(0)("FOPEID"), "")
                .FCLTID = DB_NullReplace(dt.Rows(0)("FCLTID"), "")
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "")
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "")
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "")
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "")
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "")
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "")
                .UOPEID = DB_NullReplace(dt.Rows(0)("UOPEID"), "")
                .UCLTID = DB_NullReplace(dt.Rows(0)("UCLTID"), "")
                .UWRTTM = DB_NullReplace(dt.Rows(0)("UWRTTM"), "")
                .UWRTDT = DB_NullReplace(dt.Rows(0)("UWRTDT"), "")
                'change end 20190826 kuwa
            End With
        End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'�ŐV�̎󒍃f�[�^�̎擾
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "   FROM JDNTRA "
		strSQL = strSQL & " WHERE DATNO    = '" & CF_Ora_String(strDATNO, 10) & "' " '�`�[�Ǘ�NO.

        'DB�A�N�Z�X
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        dt = DB_GetTable(strSQL)

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            GoTo F_Get_JDN_HAITA_Inf_end
        End If

        '�擾�f�[�^�ޔ�
        'change start 20190826 kuwa
        'Do Until CF_Ora_EOF(Usr_Ody)

        '    '�`�[�Ǘ�NO�̎擾
        '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    strDATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")
        '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    strLINNO = CF_Ora_GetDyn(Usr_Ody, "LINNO", "")

        '    intJDNTRAIndex = 0
        '    For I = 1 To UBound(gc_JDNTRA_HAITA_Inf)
        '        If Trim(gc_JDNTRA_HAITA_Inf(I).DATNO) = Trim(strDATNO) And Trim(gc_JDNTRA_HAITA_Inf(I).LINNO) = Trim(strLINNO) Then
        '            intJDNTRAIndex = I
        '            Exit For
        '        End If
        '    Next I
        '    If intJDNTRAIndex = 0 Then
        '        intJDNTRAIndex = UBound(gc_JDNTRA_HAITA_Inf) + 1
        '        ReDim Preserve gc_JDNTRA_HAITA_Inf(intJDNTRAIndex)

        '        With gc_JDNTRA_HAITA_Inf(intJDNTRAIndex)
        '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            .DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")
        '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            .JDNNO = CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")
        '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            .LINNO = CF_Ora_GetDyn(Usr_Ody, "LINNO", "")
        '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            .FOPEID = CF_Ora_GetDyn(Usr_Ody, "FOPEID", "")
        '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            .FCLTID = CF_Ora_GetDyn(Usr_Ody, "FCLTID", "")
        '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")
        '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")
        '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")
        '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")
        '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")
        '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")
        '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            .UOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "")
        '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            .UCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "")
        '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            .UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "")
        '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            .UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "")
        '        End With
        '    End If

        '    Call CF_Ora_MoveNext(Usr_Ody)
        'Loop

        For Each row As DataRow In dt.Rows
            '�`�[�Ǘ�NO�̎擾
            strDATNO = DB_NullReplace(row("DATNO"), "")
            strLINNO = DB_NullReplace(row("LINNO"), "")

            intJDNTRAIndex = 0
            For I = 1 To UBound(gc_JDNTRA_HAITA_Inf)
                If Trim(gc_JDNTRA_HAITA_Inf(I).DATNO) = Trim(strDATNO) And Trim(gc_JDNTRA_HAITA_Inf(I).LINNO) = Trim(strLINNO) Then
                    intJDNTRAIndex = I
                    Exit For
                End If
            Next I
            If intJDNTRAIndex = 0 Then
                intJDNTRAIndex = UBound(gc_JDNTRA_HAITA_Inf) + 1
                ReDim Preserve gc_JDNTRA_HAITA_Inf(intJDNTRAIndex)

                With gc_JDNTRA_HAITA_Inf(intJDNTRAIndex)
                    .DATNO = DB_NullReplace(row("DATNO"), "")
                    .JDNNO = DB_NullReplace(row("JDNNO"), "")
                    .LINNO = DB_NullReplace(row("LINNO"), "")
                    .FOPEID = DB_NullReplace(row("FOPEID"), "")
                    .FCLTID = DB_NullReplace(row("FCLTID"), "")
                    .WRTFSTTM = DB_NullReplace(row("WRTFSTTM"), "")
                    .WRTFSTDT = DB_NullReplace(row("WRTFSTDT"), "")
                    .OPEID = DB_NullReplace(row("OPEID"), "")
                    .CLTID = DB_NullReplace(row("CLTID"), "")
                    .WRTTM = DB_NullReplace(row("WRTTM"), "")
                    .WRTDT = DB_NullReplace(row("WRTDT"), "")
                    .UOPEID = DB_NullReplace(row("UOPEID"), "")
                    .UCLTID = DB_NullReplace(row("UCLTID"), "")
                    .UWRTTM = DB_NullReplace(row("UWRTTM"), "")
                    .UWRTDT = DB_NullReplace(row("UWRTDT"), "")
                End With
            End If

            Call CF_Ora_MoveNext(Usr_Ody)
        Next
        'change end 20190826 kuwa


        F_Get_JDN_HAITA_Inf = True
		
F_Get_JDN_HAITA_Inf_end: 
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
F_Get_JDN_HAITA_Inf_err: 
		GoTo F_Get_JDN_HAITA_Inf_end
		
	End Function
	'2009/10/05 ADD E.N.D RISE)MIYAJIMA
	
	'2009/10/05 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_JDNTHA_Exicz
	'   �T�v�F  �󒍌��o���r������
	'   �����F
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_JDNTHA_Exicz() As Short
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		Dim I As Short
		
		On Error GoTo F_JDNTHA_Exicz_err
		
		F_JDNTHA_Exicz = 9
		
		For I = 1 To UBound(gc_JDNTHA_HAITA_Inf)
			
			With gc_JDNTHA_HAITA_Inf(I)
				'SQL
				strSQL = ""
				strSQL = strSQL & " SELECT * "
				strSQL = strSQL & " FROM JDNTHA "
				strSQL = strSQL & " WHERE DATNO    = '" & CF_Ora_String(.DATNO, 10) & "' " '�`�[�Ǘ�NO.
				strSQL = strSQL & " FOR UPDATE "

                ' DB�A�N�Z�X
                'change start 20190826 kuwa
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                Dim dt As DataTable = DB_GetTable(strSQL)
                'change end 20190826 kuwa

                'change start 20190826 kuwa
                'If CF_Ora_EOF(Usr_Ody) = True Then
                If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                    'change end 20190826 kuwa
                    ' �f�[�^�Ȃ��̏ꍇ
                    F_JDNTHA_Exicz = 1
                    GoTo F_JDNTHA_Exicz_end
                End If

                ' �X�V�O�f�[�^�ƈقȂ�f�[�^�����݂����ꍇ�̓G���[�Ƃ���B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UCLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UOPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, CLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, OPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTFSTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTFSTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, FCLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, FOPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'change start 20190826 kuwa
                'If .FOPEID <> CF_Ora_GetDyn(Usr_Ody, "FOPEID", "") Or .FCLTID <> CF_Ora_GetDyn(Usr_Ody, "FCLTID", "") Or .WRTFSTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") Or .WRTFSTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") Or .OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or .CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or .WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or .WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or .UOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or .UCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or .UWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or .UWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
                If .FOPEID <> DB_NullReplace(dt.Rows(0)("FOPEID"), "") Or .FCLTID <> DB_NullReplace(dt.Rows(0)("FCLTID"), "") Or .WRTFSTTM <> DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") Or .WRTFSTDT <> DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") Or .OPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or .CLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or .WRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or .WRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Or .UOPEID <> DB_NullReplace(dt.Rows(0)("UOPEID"), "") Or .UCLTID <> DB_NullReplace(dt.Rows(0)("UCLTID"), "") Or .UWRTTM <> DB_NullReplace(dt.Rows(0)("UWRTTM"), "") Or .UWRTDT <> DB_NullReplace(dt.Rows(0)("UWRTDT"), "") Then
                    'change end 20190826 kuwa
                    GoTo F_JDNTHA_Exicz_end
                End If
            End With
			
		Next I
		
		F_JDNTHA_Exicz = 0
		
F_JDNTHA_Exicz_end: 
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
F_JDNTHA_Exicz_err: 
		GoTo F_JDNTHA_Exicz_end
		
	End Function
	'2009/10/05 ADD E.N.D RISE)MIYAJIMA
	
	'2009/10/05 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_JDNTRA_Exicz
	'   �T�v�F  �󒍃g�����r������
	'   �����F
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_JDNTRA_Exicz() As Short
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		Dim I As Short
		
		On Error GoTo F_JDNTRA_Exicz_err
		
		F_JDNTRA_Exicz = 9
		
		For I = 1 To UBound(gc_JDNTRA_HAITA_Inf)
			
			With gc_JDNTRA_HAITA_Inf(I)
				'SQL
				strSQL = ""
				strSQL = strSQL & " SELECT * "
				strSQL = strSQL & " FROM JDNTRA "
				strSQL = strSQL & " WHERE DATNO    = '" & CF_Ora_String(.DATNO, 10) & "' " '�`�[�Ǘ�NO.
				strSQL = strSQL & " AND   LINNO    = '" & CF_Ora_String(.LINNO, 3) & "' " '�s�ԍ�.
				strSQL = strSQL & " FOR UPDATE "

                ' DB�A�N�Z�X
                'change start 20190826 kuwa
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                Dim dt As DataTable = DB_GetTable(strSQL)
                'change end 20190826 kuwa

                'change start 20190826 kuwa
                'If CF_Ora_EOF(Usr_Ody) = True Then
                If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                    'change end 20190826 kuwa
                    ' �f�[�^�Ȃ��̏ꍇ
                    F_JDNTRA_Exicz = 1
                    GoTo F_JDNTRA_Exicz_end
                End If

                ' �X�V�O�f�[�^�ƈقȂ�f�[�^�����݂����ꍇ�̓G���[�Ƃ���B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UCLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UOPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, CLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, OPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTFSTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTFSTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, FCLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, FOPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'change start 20190826 kuwa
                'If .FOPEID <> CF_Ora_GetDyn(Usr_Ody, "FOPEID", "") Or .FCLTID <> CF_Ora_GetDyn(Usr_Ody, "FCLTID", "") Or .WRTFSTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") Or .WRTFSTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") Or .OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or .CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or .WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or .WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or .UOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or .UCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or .UWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or .UWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
                If .FOPEID <> DB_NullReplace(dt.Rows(0)("FOPEID"), "") Or .FCLTID <> DB_NullReplace(dt.Rows(0)("FCLTID"), "") Or .WRTFSTTM <> DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") Or .WRTFSTDT <> DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") Or .OPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or .CLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or .WRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or .WRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Or .UOPEID <> DB_NullReplace(dt.Rows(0)("UOPEID"), "") Or .UCLTID <> DB_NullReplace(dt.Rows(0)("UCLTID"), "") Or .UWRTTM <> DB_NullReplace(dt.Rows(0)("UWRTTM"), "") Or .UWRTDT <> DB_NullReplace(dt.Rows(0)("UWRTDT"), "") Then
                    'change end 20190826 kuwa
                    GoTo F_JDNTRA_Exicz_end
                End If
            End With
			
		Next I
		
		F_JDNTRA_Exicz = 0
		
F_JDNTRA_Exicz_end: 
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
F_JDNTRA_Exicz_err: 
		GoTo F_JDNTRA_Exicz_end
		
	End Function
	'2009/10/05 ADD E.N.D RISE)MIYAJIMA
	
	'2009/10/05 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_JDNTHA_Upd_TimeStamp
	'   �T�v�F  �󒍌��o���g��������
	'   �����F  pm_All             : ��ʏ��
	'           pin_strDATNO       : �`�[�Ǘ��ԍ�
	'           pin_blnUpdDLFLG    : True = DLFLG ���X�V
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_JDNTHA_Upd_TimeStamp(ByRef pm_All As Cls_All) As Object
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim I As Short
		
		On Error GoTo F_JDNTHA_Upd_TimeStamp_err
		
		'UPGRADE_WARNING: �I�u�W�F�N�g F_JDNTHA_Upd_TimeStamp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		F_JDNTHA_Upd_TimeStamp = 9
		
		For I = 1 To UBound(gc_JDNTHA_HAITA_Inf)
			
			With gc_JDNTHA_HAITA_Inf(I)
				'SQL
				strSQL = ""
				strSQL = strSQL & " UPDATE JDNTHA "
				strSQL = strSQL & "    SET UOPEID  = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�UID�i�o�b�`�j
				strSQL = strSQL & "      , UCLTID  = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���gID�i�o�b�`�j
				strSQL = strSQL & "      , UWRTTM  = '" & CF_Ora_String(GV_SysTime, 6) & "' " '�^�C���X�^���v�i�o�b�`���ԁj
				strSQL = strSQL & "      , UWRTDT  = '" & CF_Ora_String(GV_SysDate, 8) & "' " '�^�C���X�^���v�i�o�b�`���t�j
				strSQL = strSQL & "      , PGID    = '" & CF_Ora_String(SSS_PrgId, 7) & "' " '�X�VPGID
				strSQL = strSQL & " WHERE DATNO    = '" & CF_Ora_String(.DATNO, 10) & "' " '�`�[�Ǘ�NO.
				
				'SQL���s
				bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
				If bolRet = False Then
					GoTo F_JDNTHA_Upd_TimeStamp_err
				End If
			End With
		Next I
		
		'UPGRADE_WARNING: �I�u�W�F�N�g F_JDNTHA_Upd_TimeStamp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		F_JDNTHA_Upd_TimeStamp = 0
		
F_JDNTHA_Upd_TimeStamp_end: 
		Exit Function
		
F_JDNTHA_Upd_TimeStamp_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_JDNTHA_Upd_TimeStamp")
		GoTo F_JDNTHA_Upd_TimeStamp_end
		
	End Function
	'2009/10/05 ADD E.N.D RISE)MIYAJIMA
	
	'2009/10/05 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_JDNTRA_Upd_TimeStamp
	'   �T�v�F  �󒍌��o���g��������
	'   �����F  pm_All             : ��ʏ��
	'           pin_strDATNO       : �`�[�Ǘ��ԍ�
	'           pin_blnUpdDLFLG    : True = DLFLG ���X�V
	'   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_JDNTRA_Upd_TimeStamp(ByRef pm_All As Cls_All) As Object
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim I As Short
		
		On Error GoTo F_JDNTRA_Upd_TimeStamp_err
		
		'UPGRADE_WARNING: �I�u�W�F�N�g F_JDNTRA_Upd_TimeStamp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		F_JDNTRA_Upd_TimeStamp = 9
		
		For I = 1 To UBound(gc_JDNTRA_HAITA_Inf)
			
			With gc_JDNTRA_HAITA_Inf(I)
				'SQL
				strSQL = ""
				strSQL = strSQL & " UPDATE JDNTRA "
				strSQL = strSQL & "    SET UOPEID  = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�UID�i�o�b�`�j
				strSQL = strSQL & "      , UCLTID  = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���gID�i�o�b�`�j
				strSQL = strSQL & "      , UWRTTM  = '" & CF_Ora_String(GV_SysTime, 6) & "' " '�^�C���X�^���v�i�o�b�`���ԁj
				strSQL = strSQL & "      , UWRTDT  = '" & CF_Ora_String(GV_SysDate, 8) & "' " '�^�C���X�^���v�i�o�b�`���t�j
				strSQL = strSQL & "      , PGID    = '" & CF_Ora_String(SSS_PrgId, 7) & "' " '�X�VPGID
				strSQL = strSQL & " WHERE DATNO    = '" & CF_Ora_String(.DATNO, 10) & "' " '�`�[�Ǘ�NO.
				strSQL = strSQL & " AND   LINNO    = '" & CF_Ora_String(.LINNO, 3) & "' " '�s�ԍ�.
				
				'SQL���s
				bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
				If bolRet = False Then
					GoTo F_JDNTRA_Upd_TimeStamp_err
				End If
			End With
		Next I
		
		'UPGRADE_WARNING: �I�u�W�F�N�g F_JDNTRA_Upd_TimeStamp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		F_JDNTRA_Upd_TimeStamp = 0
		
F_JDNTRA_Upd_TimeStamp_end: 
		Exit Function
		
F_JDNTRA_Upd_TimeStamp_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_JDNTRA_Upd_TimeStamp")
		GoTo F_JDNTRA_Upd_TimeStamp_end
		
	End Function
	'2009/10/05 ADD E.N.D RISE)MIYAJIMA
	
	'2009/10/05 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_EXIST_MotoJDNNO
	'   �T�v�F  ���ׁF�󒍔ԍ��̑��݃`�F�b�N(�ύX�O�̃f�[�^���Ώ�)
	'   �����F�@pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_EXIST_MotoJDNNO(ByRef pm_All As Cls_All) As Short
		Dim Retn_Code As Short
		
		Dim intCnt As Short
		Dim strJdnNo As String
		Dim strJDNLINNO As String
		Dim Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA
		
		Retn_Code = CHK_OK
		
		'�ύX�O���擾
		For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g Tbl_Inf_UDNTRA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
			
			'�󒍔ԍ�
			strJdnNo = Mid(Tbl_Inf_UDNTRA.OKRJONO, 1, 6)
			strJDNLINNO = Mid(Tbl_Inf_UDNTRA.OKRJONO, 7, 3)
			
			If Trim(strJdnNo) <> "" Then
				If F_Util_CheckJDNNO(strJdnNo, strJDNLINNO) <> 0 Then
					Retn_Code = CHK_ERR_ELSE
					GoTo F_Chk_EXIST_MotoJDNNO_End
				End If
			End If
			
		Next intCnt
		
F_Chk_EXIST_MotoJDNNO_End: 
		
		F_Chk_EXIST_MotoJDNNO = Retn_Code
	End Function
	'2009/10/05 ADD E.N.D RISE)MIYAJIMA
	
	'''' ADD 2009/11/10  FKS) T.Yamamoto    Start    �A���[��757
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_NYUDT_JDNDT
	'   �T�v�F  �󒍓`�[���t�̔N�������.�������̔N���`�F�b�N
	'   �����F�@pm_All                :��ʏ��
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_NYUDT_JDNDT(ByRef pm_All As Cls_All) As Short
		
		Dim Retn_Code As Short
		Dim Err_Cd As String
		Dim Msg_Flg As Boolean
		
		Dim intCnt As Short
		Dim intRet As Short
		Dim strJdnNo As String
		Dim strJDNLINNO As String
		
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		
		strJdnNo = ""
		strJDNLINNO = ""
		
		For intCnt = 1 To pv_intMeisaiCnt
			
			'�󒍔ԍ�
			strJdnNo = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.JDNNO
			strJDNLINNO = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.JDNLINNO
			
			If strJdnNo <> "" Or strJDNLINNO <> "" Then
				intRet = F_Util_CheckJDNNO(strJdnNo, strJDNLINNO, URKET52_HEAD_Inf.NYUDT)
				If intRet <> 0 Then
					Retn_Code = CHK_ERR_ELSE
					Select Case intRet
						Case 1
							Err_Cd = gc_strMsgURKET52_E_011 '�Y���f�[�^�Ȃ�
						Case 2
							Err_Cd = gc_strMsgURKET52_E_039 '�󒍓`�[���t�̔N�������.�������̔N��
					End Select
					Msg_Flg = True
					GoTo F_Chk_NYUDT_JDNDT_End
				End If
			End If
			
		Next intCnt
		
F_Chk_NYUDT_JDNDT_End: 
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_NYUDT_JDNDT = Retn_Code
		
	End Function
    '''' ADD 2009/11/10  FKS) T.Yamamoto    End

    '���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������

    '2019/05/23 ADD START
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_Set_Frm_IN_TANCD
    '   �T�v�F  ���͒S���ҕҏW
    '   �����F�@pm_Form        :�t�H�[��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Set_Frm_IN_TANCD_URKET52(ByRef pm_Form As FR_SSSMAIN, ByRef pm_All As Cls_All) As Short

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

End Module