Option Strict Off
Option Explicit On

'2019/04/10 ADD START
Imports PronesDbAccess
'2019/04/10 ADD E N D

Friend Class ClsOraDB
	'//*****************************************************************************************
	'//*
	'//*�����́�
	'//*    ClsOraDB
	'//*
	'//*���o�[�W������
	'//*    1.00
	'//*���쐬�ҁ�
	'//*    RISE
	'//*��������
	'//*    �f�[�^�x�[�X�֘A�E���ʃN���X
	'//*****************************************************************************************
	'//* CHANGE HISTORY
	'//* Version  |YYYYMMDD|Programmer     |Description
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.00     |20060705|Rise)          |�V�K
	'//*****************************************************************************************
	'//-----------------------------------------------------------------------------------------
	'// �G���[���b�Z�[�W�p
	'//-----------------------------------------------------------------------------------------
	Private Const cst_�ُ� As String = "���s���G���[�ł��B�V�X�e���S���҂ɘA�����ĉ������B"
	Private Const cst_�ڍ� As String = vbCrLf & vbCrLf & "[ �ڍ� ]" & vbCrLf
	Private Const cst_�Q�l As String = vbCrLf & vbCrLf & "[ �Q�l ]" & vbCrLf
	
	'//-----------------------------------------------------------------------------------------
	'// �I���N���I�u�W�F�N�g
	'//-----------------------------------------------------------------------------------------
	Private mv_OracleSession As Object 'Oracle�Z�b�V����
	'UPGRADE_ISSUE: OraDatabase �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	Private mv_OraDatabase As OraDatabase 'Oracle�f�[�^�x�[�X
	'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	Private mv_OraDynaset As OraDynaset 'Oracle�_�C�i�Z�b�g
	Private mv_strUser As String '�ڑ����[�U
	Private mv_strPassword As String '�p�X���[�h
	Private mv_strDBName As String '�T�[�r�X��
	
	'//****************************************************************************************
	'//�C�j�V�����C�Y
	'//****************************************************************************************
	'UPGRADE_NOTE: Class_Initialize �� Class_Initialize_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	Private Sub Class_Initialize_Renamed()
		
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	'//****************************************************************************************
	'//�^�[�~�l�C�g
	'//****************************************************************************************
	'UPGRADE_NOTE: Class_Terminate �� Class_Terminate_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	Private Sub Class_Terminate_Renamed()
		Call OraDisConnect()
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
	
	'//****************************************************************************************
	'//* <�v���p�e�B>
	'//*     Msg_Conn
	'//* <��  ��>
	'//*    �R�l�N�V�����̎擾
	'//****************************************************************************************
	Public ReadOnly Property OraDatabase() As Object
		Get
			OraDatabase = mv_OraDatabase
		End Get
	End Property
	
	'----------------------------------------------------------------------------------------
	'�@�֐����@OraConnect
	'�@�@�\�@�@Oracle�ɑ΂�oo4o�ɂĐڑ����s��
	'�@�����@�@�Ȃ�
	'�@�Ԓl�@�@�u�[���l(Boolean)
	'�@���l�@�@�ڑ��ɐ��������ꍇ�A�Ԓl��True��ԋp
	'�@�@�@�@�@�ڑ��Ɏ��s�����ꍇ�A�Ԓl��False��ԋp
	'----------------------------------------------------------------------------------------
	Public Function OraConnect(ByRef pDBNAME As Object, ByRef pLOGINID As Object, ByRef pPASSWORD As Object, Optional ByVal pMsgDsp As Boolean = True) As Boolean
		Dim ORADYN_DEFAULT As Object
		
		Const PROCEDURE As String = "OraConnect"
		
		On Error GoTo ONERR_STEP
		
		OraConnect = False
		
		' �ڑ��������ݒ�
		'UPGRADE_WARNING: �I�u�W�F�N�g pDBNAME �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		mv_strDBName = pDBNAME
		'UPGRADE_WARNING: �I�u�W�F�N�g pLOGINID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		mv_strUser = pLOGINID
		'UPGRADE_WARNING: �I�u�W�F�N�g pPASSWORD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		mv_strPassword = pPASSWORD
		
		' Oracle�Z�b�V�����̍쐬
		mv_OracleSession = CreateObject("OracleInProcServer.XOraSession")
		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OracleSession.OpenDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		mv_OraDatabase = mv_OracleSession.OpenDatabase(Trim(mv_strDBName), Trim(mv_strUser) & "/" & Trim(mv_strPassword), ORADYN_DEFAULT)
		
		OraConnect = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		If pMsgDsp Then
			MsgBox("<" & PROCEDURE & "> " & vbCrLf & "�f�[�^�x�[�X�̐ڑ��Ɏ��s���܂����B�����𒆎~���܂��B" & cst_�ڍ� & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		End If
		Resume EXIT_STEP
	End Function
	
	'----------------------------------------------------------------------------------------
	'�@�֐����@OraDisConnect
	'�@�@�\�@�@Oracle�̐ڑ���ؒf����
	'�@�����@�@�Ȃ�
	'�@�Ԓl�@�@�u�[���l(Boolean)
	'�@���l�@�@�ڑ��ɐ��������ꍇ�A�Ԓl��True��ԋp
	'�@�@�@�@�@�ڑ��Ɏ��s�����ꍇ�A�Ԓl��False��ԋp
	'----------------------------------------------------------------------------------------
	Public Function OraDisConnect(Optional ByVal pMsgDsp As Boolean = True) As Boolean
		
		Const PROCEDURE As String = "OraDisConnect"
		
		On Error GoTo ONERR_STEP
		
		OraDisConnect = False
		
		' �ڑ���ؒf����
		
		If Not mv_OraDynaset Is Nothing Then
			'UPGRADE_NOTE: �I�u�W�F�N�g mv_OraDynaset ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
			mv_OraDynaset = Nothing
		End If
		
		If Not mv_OraDatabase Is Nothing Then
			'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Close �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			mv_OraDatabase.Close()
			'UPGRADE_NOTE: �I�u�W�F�N�g mv_OraDatabase ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
			mv_OraDatabase = Nothing
		End If
		
		If Not mv_OracleSession Is Nothing Then
			'UPGRADE_NOTE: �I�u�W�F�N�g mv_OracleSession ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
			mv_OracleSession = Nothing
		End If
		
		OraDisConnect = True
		
		On Error GoTo 0
		Exit Function
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		If pMsgDsp Then
			MsgBox("<" & PROCEDURE & "> " & vbCrLf & "�f�[�^�x�[�X�̐ؒf�Ɏ��s���܂����B�����𒆎~���܂��B" & cst_�ڍ� & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		End If
		Resume EXIT_STEP
	End Function
	
	'----------------------------------------------------------------------------------------
	'�@�֐����@OraCreateDyn
	'�@�@�\�@�@���R�[�h�Z�b�g���擾���܂�
	'�@�����@�@SQL��(String)
	'          ���R�[�h(Object)
	'          ���R�[�h�Z�b�g�I�v�V����(Variant)
	'�@�Ԓl�@�@�u�[���l(Boolean)
	'�@���l�@�@�擾�����̏ꍇ�A�Ԓl��True��ԋp
	'�@�@�@�@�@�擾���s�̏ꍇ�A�Ԓl��False��ԋp
	'----------------------------------------------------------------------------------------
	Public Function OraCreateDyn(ByVal pSQL As String, ByRef pOBJ As OraDynaset, Optional ByVal pOption As Object = Nothing, Optional ByVal pCallProcedure As String = "", Optional ByVal pMsgDsp As Boolean = True) As Boolean

        '2019/04/11 DEL START
        '       Dim ORATYPE_VARCHAR2 As Object
        '		Dim ORAPARM_INPUT As Object
        '		Dim ORADYN_NO_BLANKSTRIP As Object
        '		Dim ORADYN_NO_REFETCH As Object
        '		Dim ORADYN_NOCACHE As Object
        '		Dim ORADYN_READONLY As Object

        '		Const PROCEDURE As String = "OraCreateDyn"

        '		Dim IntCnt As Integer '//�t�B�[���h�J�E���^
        '		Dim LngOption As Integer '//���Ұ��iORADYN_READONLY Or ORADYN_NOCACHE�Ȃǁj
        '		Dim vlStrERRMsg As String

        '		On Error GoTo ERR_HANDLE

        '		'// ���Ұ��̐ݒ�
        '		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
        '		If IsNothing(pOption) = False Then
        '			'UPGRADE_WARNING: �I�u�W�F�N�g pOption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			LngOption = CInt(pOption)
        '		Else
        '			'UPGRADE_WARNING: �I�u�W�F�N�g ORADYN_NO_BLANKSTRIP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g ORADYN_NO_REFETCH �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g ORADYN_NOCACHE �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g ORADYN_READONLY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			LngOption = ORADYN_READONLY + ORADYN_NOCACHE + ORADYN_NO_REFETCH + ORADYN_NO_BLANKSTRIP
        '		End If

        '		'// SQL�ð���Ă̎��s
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.CreateDynaset �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		pOBJ = mv_OraDatabase.CreateDynaset(pSQL, LngOption)

        '		'//����I��
        '		OraCreateDyn = True

        'EXIT_HANDLE: 
        '		On Error GoTo 0
        '		Exit Function

        'ERR_HANDLE: 

        '		If pMsgDsp Then
        '			'�װү���ޕ\��
        '			'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.LastServerErrText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			MsgBox("<" & PROCEDURE & "> " & vbCrLf & cst_�ُ� & cst_�ڍ� & CStr(mv_OraDatabase.LastServerErrText), MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
        '		End If

        '		'���Ұ��̸ر
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Remove("PARA_ID")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Remove("PARA_CODE")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Remove("PARA_MSG")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Remove("PARA_POINT")

        '		'PL/SQL���Ă�
        '		'�v���O����ID
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Add("PARA_ID", My.Application.Info.Title, ORAPARM_INPUT)
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_VARCHAR2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters("PARA_ID").serverType = ORATYPE_VARCHAR2

        '		'�G���[�ԍ�
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.LastServerErr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Add("PARA_CODE", mv_OraDatabase.LastServerErr, ORAPARM_INPUT)
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_VARCHAR2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters("PARA_CODE").serverType = ORATYPE_VARCHAR2

        '		'�G���[���e
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.LastServerErrText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Add("PARA_MSG", mv_OraDatabase.LastServerErrText, ORAPARM_INPUT)
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_VARCHAR2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters("PARA_MSG").serverType = ORATYPE_VARCHAR2

        '		'�����ꏊ
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Add("PARA_POINT", pCallProcedure, ORAPARM_INPUT)
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_VARCHAR2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters("PARA_POINT").serverType = ORATYPE_VARCHAR2

        '		clsOra.OraExecute("BEGIN PTERRLOG(:PARA_ID,:PARA_CODE,:PARA_MSG,:PARA_POINT); END;")

        '		'���Ұ��̸ر
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Remove("PARA_ID")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Remove("PARA_CODE")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Remove("PARA_MSG")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Remove("PARA_POINT")

        '        GoTo EXIT_HANDLE
        '2019/04/11 DEL E N D
		
	End Function
	
	'----------------------------------------------------------------------------------------
	'�@�֐����@OraCloseDyn
	'�@�@�\�@�@�����̃��R�[�h�Z�b�g���N���[�Y�y�щ�����܂��B
	'�@�����@�@���R�[�h�Z�b�g���(Object)
	'�@�Ԓl�@�@�u�[���l(Boolean)
	'�@���l�@�@�J�������̏ꍇ�A�Ԓl��True��ԋp
	'�@�@�@�@�@�J�����s�̏ꍇ�A�Ԓl��False��ԋp
	'----------------------------------------------------------------------------------------
	Public Function OraCloseDyn(ByRef pOBJ As OraDynaset) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		OraCloseDyn = False
		
		If (pOBJ Is Nothing) = False Then
			'UPGRADE_NOTE: �I�u�W�F�N�g pOBJ ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
			pOBJ = Nothing
		End If
		
		OraCloseDyn = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	'----------------------------------------------------------------------------------------
	'�@�֐����@OraBeginTrans
	'�@�@�\�@�@�g�����U�N�V��������̊J�n
	'�@�����@�@�f�[�^�x�[�X�ڑ����(Object)
	'�@�Ԓl�@�@�u�[���l(Boolean)
	'�@���l�@�@�ڑ��ɐ��������ꍇ�A�Ԓl��True��ԋp
	'�@�@�@�@�@�ڑ��Ɏ��s�����ꍇ�A�Ԓl��False��ԋp
	'----------------------------------------------------------------------------------------
	Public Function OraBeginTrans() As Boolean
		
		Const PROCEDURE As String = "OraBeginTrans"
		
		On Error GoTo ONERR_STEP
		
		OraBeginTrans = False
		
		'//��ݻ޸��݊J�n
		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.DbBeginTrans �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		mv_OraDatabase.DbBeginTrans()
		
		'//����I��
		OraBeginTrans = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'// 2007/01/17 �� DEL STR
		''''    MsgBox "<" & PROCEDURE & "> " & vbCrLf & cst_�ُ� & _
		'''''                            cst_�ڍ� & Err.Description, _
		'''''                            vbOKOnly + vbCritical, App.Title
		'// 2007/01/17 �� DEL END
	End Function
	
	'----------------------------------------------------------------------------------------
	'�@�֐����@OraCommitTrans
	'�@�@�\�@�@�g�����U�N�V�����̃R�~�b�g
	'�@�����@�@�f�[�^�x�[�X�ڑ����(Object)
	'�@�Ԓl�@�@�u�[���l(Boolean)
	'�@���l�@�@�R�~�b�g�ɐ��������ꍇ�A�Ԓl��True��ԋp
	'�@�@�@�@�@�R�~�b�g�Ɏ��s�����ꍇ�A�Ԓl��False��ԋp
	'----------------------------------------------------------------------------------------
	Public Function OraCommitTrans() As Boolean
		
		Const PROCEDURE As String = "OraCommitTrans"
		
		On Error GoTo ONERR_STEP
		
		OraCommitTrans = False
		
		'//�Я�
		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.DbCommitTrans �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		mv_OraDatabase.DbCommitTrans()
		
		'//����I��
		OraCommitTrans = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'// 2007/01/17 �� DEL STR
		''''        MsgBox "<" & PROCEDURE & "> " & vbCrLf & cst_�ُ� & _
		'''''                                cst_�ڍ� & Err.Description, _
		'''''                                vbOKOnly + vbCritical, App.Title
		'// 2007/01/17 �� DEL END
	End Function
	
	'----------------------------------------------------------------------------------------
	'�@�֐����@OraRollback
	'�@�@�\�@�@�g�����U�N�V�����̃��[���o�b�N
	'�@�����@�@�f�[�^�x�[�X�ڑ����(Object)
	'�@�Ԓl�@�@�u�[���l(Boolean)
	'�@���l�@�@���[���o�b�N�ɐ��������ꍇ�A�Ԓl��True��ԋp
	'�@�@�@�@�@���[���o�b�N�Ɏ��s�����ꍇ�A�Ԓl��False��ԋp
	'----------------------------------------------------------------------------------------
	Public Function OraRollback() As Boolean
		
		Const PROCEDURE As String = "OraRollback"
		
		On Error GoTo ONERR_STEP
		
		OraRollback = False
		
		'//�Я�
		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.DbRollback �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		mv_OraDatabase.DbRollback()
		
		'//����I��
		OraRollback = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'// 2007/01/17 �� DEL STR
		''''    MsgBox "<" & PROCEDURE & "> " & vbCrLf & cst_�ُ� & _
		'''''                            cst_�ڍ� & Err.Description, _
		'''''                            vbOKOnly + vbCritical, App.Title
		'// 2007/01/17 �� DEL END
	End Function
	
	'----------------------------------------------------------------------------------------
	'�@�֐����@OraExecute
	'�@�@�\�@�@�X�V�n(INSERT UPDATE DELETE)��SQL�ð���Ă����s
	'�@�����@�@�f�[�^�x�[�X�ڑ����(Object)
	'          SQL������(String)
	'          ���s���R�[�h��(Long)
	'          ���b�Z�[�W�\���E��\��(Boolean)
	'�@�Ԓl�@�@�u�[���l(Boolean)
	'�@���l�@�@���s�ɐ��������ꍇ�A�Ԓl��True��ԋp
	'�@�@�@�@�@���s�Ɏ��s�����ꍇ�A�Ԓl��False��ԋp
	'----------------------------------------------------------------------------------------
	Public Function OraExecute(ByVal pSQL As String, Optional ByRef pRowCnt As Integer = 0, Optional ByVal pCallProcedure As String = "", Optional ByVal pMsgDsp As Boolean = True) As Boolean

        '2019/04/11 DEL START
        '       Dim ORATYPE_VARCHAR2 As Object
        '		Dim ORAPARM_INPUT As Object

        '		Dim LngRowCnt As Integer '//���s�̖߂�l
        '		Dim vlStrERRMsg As String

        '		Const PROCEDURE As String = "OraExecute"

        '		On Error GoTo RUNTIME_ERROR

        '		OraExecute = False

        '		'// SQL�ð���Ă̎��s
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.ExecuteSQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		LngRowCnt = mv_OraDatabase.ExecuteSQL(pSQL)

        '		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
        '		If Not IsNothing(pRowCnt) Then
        '			pRowCnt = LngRowCnt
        '		End If

        '		'//����I��
        '		OraExecute = True

        'EXIT_HANDLE: 
        '		On Error GoTo 0
        '		Exit Function

        'RUNTIME_ERROR: 

        '		If pMsgDsp Then
        '			'�װү���ޕ\��
        '			'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.LastServerErrText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			MsgBox("<" & PROCEDURE & "> " & vbCrLf & cst_�ُ� & cst_�ڍ� & CStr(mv_OraDatabase.LastServerErrText), MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
        '		End If

        '		'���Ұ��̸ر
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Remove("PARA_ID")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Remove("PARA_CODE")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Remove("PARA_MSG")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Remove("PARA_POINT")

        '		'PL/SQL���Ă�
        '		'�v���O����ID
        '		'UPGRADE_WARNING: App �v���p�e�B App.EXEName �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Add("PARA_ID", My.Application.Info.AssemblyName, ORAPARM_INPUT)
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_VARCHAR2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters("PARA_ID").serverType = ORATYPE_VARCHAR2

        '		'�G���[�ԍ�
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.LastServerErr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Add("PARA_CODE", mv_OraDatabase.LastServerErr, ORAPARM_INPUT)
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_VARCHAR2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters("PARA_CODE").serverType = ORATYPE_VARCHAR2

        '		'�G���[���e
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.LastServerErrText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Add("PARA_MSG", mv_OraDatabase.LastServerErrText, ORAPARM_INPUT)
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_VARCHAR2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters("PARA_MSG").serverType = ORATYPE_VARCHAR2

        '		'�����ꏊ
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Add("PARA_POINT", pCallProcedure, ORAPARM_INPUT)
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_VARCHAR2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters("PARA_POINT").serverType = ORATYPE_VARCHAR2

        '		clsOra.OraExecute("BEGIN PTERRLOG(:PARA_ID,:PARA_CODE,:PARA_MSG,:PARA_POINT); END;")

        '		'���Ұ��̸ر
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Remove("PARA_ID")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Remove("PARA_CODE")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Remove("PARA_MSG")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g mv_OraDatabase.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		mv_OraDatabase.Parameters.Remove("PARA_POINT")

        '        GoTo EXIT_HANDLE
        '2019/04/11 DEL E N D
		
	End Function
	
	'-----------------------------------------------------------
	'�@�֐����@OraBOF
	'�@�@�\�@�@BOF�`�F�b�N���s���܂�
	'�@�����@�@�e�[�u�����(Object)
	'�@�Ԓl�@�@�u�[���l(Boolean)
	'�@���l�@�@�a�n�e�̏ꍇ�A�Ԓl��True��ԋp
	'�@�@�@�@�@�a�n�e�ȊO�̏ꍇ�A�Ԓl��False��ԋp
	'-----------------------------------------------------------
	Public Function OraBOF(ByRef pOBJ As OraDynaset) As Boolean
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pOBJ.BOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		OraBOF = pOBJ.BOF
		
	End Function
	
	'-----------------------------------------------------------
	'�@�֐����@OraEOF
	'�@�@�\�@�@EOF�`�F�b�N���s���܂�
	'�@�����@�@�e�[�u�����(Object)
	'�@�Ԓl�@�@�u�[���l(Boolean)
	'�@���l�@�@�d�n�e�̏ꍇ�A�Ԓl��True��ԋp
	'�@�@�@�@�@�d�n�e�ȊO�̏ꍇ�A�Ԓl��False��ԋp
	'-----------------------------------------------------------
	Public Function OraEOF(ByRef pOBJ As OraDynaset) As Boolean
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pOBJ.EOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		OraEOF = pOBJ.EOF
		
	End Function
	
	'-----------------------------------------------------------
	'�@�֐����@OraMoveFirst
	'�@�@�\�@�@���R�[�h�Z�b�g�̐擪�ֈړ����܂�
	'�@�����@�@�e�[�u�����(Object)
	'�@�Ԓl�@�@�u�[���l(Boolean)
	'�@���l�@�@�ړ������̏ꍇ�A�Ԓl��True��ԋp
	'�@�@�@�@�@�ړ����s�̏ꍇ�A�Ԓl��False��ԋp
	'-----------------------------------------------------------
	Public Function OraMoveFirst(ByRef pOBJ As OraDynaset) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		OraMoveFirst = False
		
		'//�擪���R�[�h�ֈړ�
		'UPGRADE_WARNING: �I�u�W�F�N�g pOBJ.MoveFirst �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pOBJ.MoveFirst()
		
		'//����I��
		OraMoveFirst = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'-----------------------------------------------------------
	'�@�֐����@OraMoveLast
	'�@�@�\�@�@���R�[�h�Z�b�g�̖����ֈړ����܂�
	'�@�����@�@�e�[�u�����(Object)
	'�@�Ԓl�@�@�u�[���l(Boolean)
	'�@���l�@�@�ړ������̏ꍇ�A�Ԓl��True��ԋp
	'�@�@�@�@�@�ړ����s�̏ꍇ�A�Ԓl��False��ԋp
	'-----------------------------------------------------------
	Public Function OraMoveLast(ByRef pOBJ As OraDynaset) As Boolean

        '2019/04/11 DEL START
        '		On Error GoTo ERR_HANDLE

        '		OraMoveLast = False

        '		'//�擪���R�[�h�ֈړ�
        '		'UPGRADE_WARNING: �I�u�W�F�N�g pOBJ.OraMoveLast �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		pOBJ.OraMoveLast()

        '		'//����I��
        '		OraMoveLast = True

        'EXIT_HANDLE: 
        '		On Error GoTo 0
        '		Exit Function

        'ERR_HANDLE: 
        '        GoTo EXIT_HANDLE
        '2019/04/11 DEL E N D
		
	End Function
	
	'-----------------------------------------------------------
	'�@�֐����@OraMovePrev
	'�@�@�\�@�@���R�[�h�Z�b�g�̈�O�ֈړ����܂�
	'�@�����@�@�e�[�u�����(Object)
	'�@�Ԓl�@�@�u�[���l(Boolean)
	'�@���l�@�@�ړ������̏ꍇ�A�Ԓl��True��ԋp
	'�@�@�@�@�@�ړ����s�̏ꍇ�A�Ԓl��False��ԋp
	'-----------------------------------------------------------
	Public Function OraMovePrev(ByRef pOBJ As OraDynaset) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		OraMovePrev = False
		
		'//�O���R�[�h�Ɉړ�
		'UPGRADE_WARNING: �I�u�W�F�N�g pOBJ.MovePrevious �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pOBJ.MovePrevious()
		
		'//����I��
		OraMovePrev = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'-----------------------------------------------------------
	'�@�֐����@OraMoveNext
	'�@�@�\�@�@���R�[�h�Z�b�g�̎��̃��R�[�h�ֈړ����܂�
	'�@�����@�@�e�[�u�����(Object)
	'�@�Ԓl�@�@�u�[���l(Boolean)
	'�@���l�@�@�ړ������̏ꍇ�A�Ԓl��True��ԋp
	'�@�@�@�@�@�ړ����s�̏ꍇ�A�Ԓl��False��ԋp
	'-----------------------------------------------------------
	Public Function OraMoveNext(ByRef pOBJ As OraDynaset) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		OraMoveNext = False
		
		'//�����R�[�h�Ɉړ�
		'UPGRADE_WARNING: �I�u�W�F�N�g pOBJ.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pOBJ.MoveNext()
		
		'//����I��
		OraMoveNext = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'-----------------------------------------------------------
	'�@�֐����@OraMovePrevN
	'�@�@�\�@�@�w��s�������R�[�h�Z�b�g�̑O�̃��R�[�h�ֈړ����܂�
	'�@�����@�@�e�[�u�����(Object)
	'�@�@�@�@�@�ړ����R�[�h��(Long)
	'�@�Ԓl�@�@�u�[���l(Boolean)
	'�@���l�@�@�ړ������̏ꍇ�A�Ԓl��True��ԋp
	'�@�@�@�@�@�ړ����s�̏ꍇ�A�Ԓl��False��ԋp
	'-----------------------------------------------------------
	Public Function OraMovePrevN(ByRef pOBJ As OraDynaset, ByVal pRow As Integer) As Boolean

        '2019/04/11 DEL START
        '		On Error GoTo ERR_HANDLE

        '		OraMovePrevN = False

        '		'//�m�s���O���R�[�h�Ɉړ�
        '		'UPGRADE_WARNING: �I�u�W�F�N�g pOBJ.MovePreviousn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		pOBJ.MovePreviousn(pRow)

        '		'//����I��
        '		OraMovePrevN = True

        'EXIT_HANDLE: 
        '		On Error GoTo 0
        '		Exit Function

        'ERR_HANDLE: 
        '        GoTo EXIT_HANDLE
        '2019/04/11 DEL E N D
		
	End Function
	
	'-----------------------------------------------------------
	'�@�֐����@OraMoveNextN
	'�@�@�\�@�@�w��s�������R�[�h�Z�b�g�̎��̃��R�[�h�ֈړ����܂�
	'�@�����@�@�e�[�u�����(Object)
	'�@�@�@�@�@�ړ����R�[�h��(Long)
	'�@�Ԓl�@�@�u�[���l(Boolean)
	'�@���l�@�@�ړ������̏ꍇ�A�Ԓl��True��ԋp
	'�@�@�@�@�@�ړ����s�̏ꍇ�A�Ԓl��False��ԋp
	'-----------------------------------------------------------
	Public Function OraMoveNextN(ByRef pOBJ As OraDynaset, ByVal pm_Row As Integer) As Boolean

        '2019/04/11 DEL START
        '		On Error GoTo ERR_HANDLE

        '		OraMoveNextN = False

        '		'//�m�s�������R�[�h�Ɉړ�
        '		'UPGRADE_WARNING: �I�u�W�F�N�g pOBJ.MoveNextn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		pOBJ.MoveNextn(pm_Row)

        '		'//����I��
        '		OraMoveNextN = True

        'EXIT_HANDLE: 
        '		On Error GoTo 0
        '		Exit Function

        'ERR_HANDLE: 
        '        GoTo EXIT_HANDLE
        '2019/04/11 DEL E N D
		
	End Function

    '2019/04/12 DEL START
    '    '-----------------------------------------------------------
    '    '�@�֐����@GetNowDt
    '    '�@�@�\�@�@�T�[�o�̌��ݓ��t�擾
    '    '�@�����@�@�߂�l�̏����敪(0:yymmdd 1:yyyymmdd) (�ȗ���=0)
    '    '�@�Ԓl�@�@���ݓ��t(YYYYMMDD)
    '    '�@���l�@�@�Ȃ�
    '    '-----------------------------------------------------------
    '	Public Function OraGetNowDt(Optional ByVal pmiKBN As Short = 0) As String

    '		Const PROCEDURE As String = "OraGetNowDt"

    '		On Error GoTo ONERR_STEP

    '		Dim strSQL As String
    '		'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
    '		Dim objRec As OraDynaset
    '		Dim lngDate As Integer

    '		' SQL���̍쐬
    '		strSQL = ""
    '		strSQL = strSQL & "SELECT TO_CHAR(SYSDATE, 'YYYYMMDD') NDATE " & vbCrLf
    '		strSQL = strSQL & "FROM   DUAL " & vbCrLf

    '		'UPGRADE_WARNING: OraGetNowDt �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B

    '        '2019/04/12 ADD START
    '        Dim dt As DataTable = DB_GetTable(strSQL)
    '        '2019/04/12 ADD E N D

    '		'UPGRADE_WARNING: OraGetNowDt �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B

    '        '2019/04/12 ADD START
    '        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then 
    '            lngDate = dt.Rows(0)("NDATE")
    '        Else
    '            lngDate = Format(Now, "YYYYMMDD")
    '        End If 
    '        '2019/04/12 ADD E N D

    '        Select Case pmiKBN
    '            Case 0
    '                OraGetNowDt = Mid(CStr(lngDate), 3)
    '            Case 1
    '                OraGetNowDt = CStr(lngDate)
    '        End Select

    '        'UPGRADE_WARNING: OraGetNowDt �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B

    '        '----------------------------------------------------------------------------------------
    'EXIT_STEP:
    '        On Error GoTo 0
    '        Exit Function
    '        '----------------------------------------------------------------------------------------
    'ONERR_STEP:
    '        '// 2007/01/17 �� DEL STR
    '        ''''    MsgBox "<" & PROCEDURE & "> " & vbCrLf & cst_�ُ� & _
    '        '''''                            cst_�ڍ� & Err.Description, _
    '        '''''                            vbOKOnly + vbCritical, App.Title
    '        '// 2007/01/17 �� DEL END
    '        Resume EXIT_STEP
    '	End Function
    '2019/04/12 DEL E N D

    '2019/04/12 DEL START
    '    '-----------------------------------------------------------
    '	'�@�֐����@GetNowTm
    '	'�@�@�\�@�@�T�[�o�̌��ݎ����擾
    '	'�@�����@�@�Ȃ�
    '	'�@�Ԓl�@�@���ݎ���(HHMMSS)
    '	'�@���l�@�@�Ȃ�
    '	'-----------------------------------------------------------
    '	Public Function OraGetNowTm() As String

    '		Const PROCEDURE As String = "OraGetNowTm"

    '		On Error GoTo ONERR_STEP

    '		Dim strSQL As String
    '		'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
    '		Dim objRec As OraDynaset

    '		' SQL���̍쐬
    '		strSQL = ""
    '		strSQL = strSQL & "SELECT TO_CHAR(SYSDATE, 'HH24MISS') NTIME " & vbCrLf
    '		strSQL = strSQL & "FROM   DUAL " & vbCrLf

    '		' �f�[�^�擾
    '		'UPGRADE_WARNING: OraGetNowTm �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B

    '        '2019/04/12 ADD START
    '        Dim dt As DataTable = DB_GetTable(strSQL)
    '        '2019/04/12 ADD E N D

    '		'UPGRADE_WARNING: OraGetNowTm �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B

    '        '2019/04/12 ADD START
    '        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '            OraGetNowTm = dt.Rows(0)("NTIME")
    '        Else
    '            OraGetNowTm = Format(Now, "HHMMSS")
    '        End If
    '        '2019/04/12 ADD E N D

    '		'UPGRADE_WARNING: OraGetNowTm �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B

    '		'----------------------------------------------------------------------------------------
    'EXIT_STEP: 
    '		On Error GoTo 0
    '		Exit Function
    '		'----------------------------------------------------------------------------------------
    'ONERR_STEP: 
    '		'// 2007/01/17 �� DEL STR
    '		''''    MsgBox "<" & PROCEDURE & "> " & vbCrLf & cst_�ُ� & _
    '		'''''                            cst_�ڍ� & Err.Description, _
    '		'''''                            vbOKOnly + vbCritical, App.Title
    '		'// 2007/01/17 �� DEL END
    '		Resume EXIT_STEP
    '	End Function
    '2019/04/12 DEL E N D
End Class