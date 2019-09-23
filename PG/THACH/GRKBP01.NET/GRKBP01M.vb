Option Strict Off
Option Explicit On
Module GRKBP01M
	'//*****************************************************************************************
	'//*
	'//*�����́�
	'//*    GRKBP01M.BAS
	'//*
	'//*���o�[�W������
	'//*    1.00
	'//*���쐬�ҁ�
	'//*    Rise
	'//*��������
	'//*    �X�g�A�h�N�� ���W���[��
	'//*****************************************************************************************
	'//* CHANGE HISTORY
	'//* Version  |YYYYMMDD|Programmer     |Description
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.00     |20060710|Rise)          |�V�K
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.01     |20071026|Rise)          |�r���������������~���ُ�I��
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.02     |20071203|Rise)          |�r���������ҋ@�������b�Z�[�W�o��
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.03     |20071207|Rise)          |�r���������I�����̃X�e�[�^�X��"HT"
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.10     |20080514|Rise)          |�Ǎ��񂾃t�@�C��������ёւ���(�t�@�C������)
	'//*          |20080515|Rise)          |���M�t�@�C�������ɑ��݂��Ă���ꍇ�̓t�@�C������
	'//*          |        |               |���Ԏ����Ɂ{�P���t�@�C�����쐬����
	'//* 1.11     |20090128|Rise)          |1.10�Ή���RETRY�񐔂�INI̧�ق��擾����l�ɕύX
	'//* 1.20     |20091015|Rise)          |�e�L�X�g�o�́��q�c�a�X�V�̃v���O�����̃��J�o���[�΍�
	'//*****************************************************************************************
	'//----------------------------------------------
	'//�X���[�v
	'//----------------------------------------------
	Private Declare Function Sleep Lib "kernel32.dll" (ByVal mstime As Integer) As Integer
	
	' -- ADD -- 2008/05/15 START (1.10)
	'//�t�@�C�����R�s�[���܂��B
	Private Declare Function CopyFile Lib "kernel32"  Alias "CopyFileA"(ByVal lpExistingFileName As String, ByVal lpNewFileName As String, ByVal bFailIfExists As Integer) As Integer
	' -- ADD -- 2008/05/15 END   (1.10)
	
	'//*****************************************************************************************
	'// �v���O�������
	'//*****************************************************************************************
	'//�W���u�h�c�E�W���u����
	Public Const gvcstJOB_ID As String = "GRKBP01"
	Public Const gvcstJOB_Titl As String = "GRKBP01SQL"
	
	'//���b�Z�[�W�{�b�N�X�\���t���O
	Public Const gvcstDspMsg As Boolean = False
	
	'//*****************************************************************************************
	'// �C���X�^���X��`
	'//*****************************************************************************************
	'UPGRADE_ISSUE: ClsComn �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	Public D0 As ClsComn '//System �֐�
	'UPGRADE_ISSUE: ClsMessage �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	Public ClsMessage As ClsMessage '//Message
	'UPGRADE_ISSUE: ClsOraDB �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	Public clsOra As ClsOraDB
	
	'//*****************************************************************************************
	'// �ϐ���`
	'//*****************************************************************************************
	'UPGRADE_ISSUE: gvtypIniFile �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	Public gvINIInformation As gvtypIniFile '//�h�m�h�t�@�C���\����
	
	'//*****************************************************************************************
	'// �\���̒�`
	'//*****************************************************************************************
	Public Structure typFileInfo
		Dim strFilePath As String
		Dim strFileName1 As String
		Dim strFileExtn1 As String
		Dim strFileName2 As String
		Dim strFileExtn2 As String
		Dim strFileTimeStampAddFlg As String
	End Structure
	
	Public Structure typFileName
		Dim strFileName() As Object
	End Structure
	
	'//*****************************************************************************************
	'// �o�f�ʕϐ���`
	'//*****************************************************************************************
	Public gvstrJOBID As String '//�p�����[�^���擾�����W���uID
	Public gvstrPLSQLPACKAGE As String '//�N��PLSQL�p�b�P�[�W
	Public gvstrPLSQLFUNCTION As String '//�N��PLSQL�t�@���N�V����
	
	Public gvaryPARAMETER() As String '//�ǉ�PARAMETER
	Public gvintInFileCount As Short '//IN �t�@�C����
	Public gvaryInFileInfo() As typFileInfo '//IN �t�@�C�����
	Public gvintOtFileCount As Short '//OUT�t�@�C����
	Public gvaryOtFileInfo() As typFileInfo '//OUT�t�@�C�����
	Public gvaryInGetFile() As typFileName '//�t�H���_���t�@�C���ꗗ
	Public gvaryOtGetFile() As typFileName '//�t�H���_���t�@�C���ꗗ
	
	' -- ADD -- 2007/02/08 START
	Public Const pc_strIni_LOGPATH As String = "LOG_PATH"
	Public Const pc_strIni_LOGNAME As String = "LOG_NAME"
	Public Const pc_strIni_RETRY_INTERVAL As String = "RETRY_INTERVAL"
	Public Const pc_strIni_RETRY_TIMES As String = "RETRY_TIMES"
	Public pv_curRETRY_INTERVAL As Decimal '���g���C�Ԋu
	Public pv_curRETRY_TIMES As Decimal '���g���C��
	Public pv_strLOG_PATH As String '�G���[���O�t�@�C���p�X
	Public pv_strLOG_NAME As String '�G���[���O�t�@�C����
	Public gv_Int_OraErr As Short '//ORACLE�G���[�ԍ�
	Public gv_Str_OraErrText As String '//ORACLE�G���[�e�L�X�g
	' -- ADD -- 2007/02/08 END
	
	' -- ADD -- 2008/05/15 START (1.10)
	Public gvstrPLSqlWkFileName As String '//�X�g�A�h�֓n�����[�N�t�@�C���̖��O�iJOBID + "WK")
	' -- ADD -- 2008/05/15 END   (1.10)
	
	' -- ADD -- 2009/01/28 START (1.11)
	Public Const pc_strIni_RETRY_TIMESTAMP As String = "RETRY_TIMESTAMP"
	Public gvintRETRY_TIMESTAMP As Short '//�^�C���X�^���v���O�ύXRETRY��
	' -- ADD -- 2009/01/28 END   (1.11)
	
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Main
	'//*
	'//* <�߂�l>
	'//*
	'//* <��  ��>     ���ږ�                  I/O           ���e
	'//*
	'//* <��  ��>
	'//*    �V�X�e���N�����̎��s�v���V�W���[
	'//*****************************************************************************************
	Public Sub Main()
		Dim GetIniFile As Object
		Dim gvcst_TmpFilePath As Object
		Dim GetFullPath As Object
		Dim Put_TextFile As Object
		Dim Get_CommandLineByPosition As Object
		Dim Get_CommandLine As Object
		
		On Error GoTo ONERR_STEP
		
		'//���ʃI�u�W�F�N�g�̃C���X�^���X�쐬
		If Not Ctr_Object(True) Then
			'        GoTo EXIT_STEP     2007.10.26
			GoTo EXIT_STEP2
		End If
		
		'//�v���O�����Q�d�N���`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.ChkDuplicateInstance �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Not D0.ChkDuplicateInstance(gvcstJOB_Titl) Then
			If gvcstDspMsg Then
				MsgBox("�y" & Trim(gvcstJOB_Titl) & "�z�͊��ɋN�����ł��B�d�����ċN�����鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, gvcstJOB_Titl)
			End If
			AppActivate(gvcstJOB_Titl)
			'        GoTo EXIT_STEP    2007.10.26
			GoTo EXIT_STEP2
		End If
		
		'//�p�����[�^�̎擾
		If Not Get_CommandLine() Then
			'        GoTo EXIT_STEP    2007.10.26
			GoTo EXIT_STEP2
		End If
		
		'//�ŗL�p�����[�^�̎擾
		If Not Get_CommandLineByPosition(2, gvstrJOBID) Then
			'        GoTo EXIT_STEP    2007.10.26
			GoTo EXIT_STEP2
		End If
		
		'//�N���X�g�A�h���̐���
		gvstrPLSQLPACKAGE = Mid(gvstrJOBID, 1, 7)
		gvstrPLSQLFUNCTION = Mid(gvstrJOBID, 1, 7) & "B"
		
		'//�X�e�[�^�X�t�@�C���Ɉُ�I����������
		'UPGRADE_WARNING: �I�u�W�F�N�g GetFullPath() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call Put_TextFile(GetFullPath(gvcst_TmpFilePath) & "\" & gvstrJOBID & "_Status.TXT", "NG", True)
		
		'//�h�m�h�t�@�C���̎擾(����)
		If Not GetIniFile(gvINIInformation) Then
			'        GoTo EXIT_STEP    2007.10.26
			GoTo EXIT_STEP2
		End If
		
		'//�h�m�h�t�@�C���̎擾(��)
		If Not GetIndividualIniFile() Then
			'        GoTo EXIT_STEP    2007.10.26
			GoTo EXIT_STEP2
		End If
		
		'//�f�[�^�x�[�X�ڑ�(ORACLE���ް)
		'UPGRADE_WARNING: �I�u�W�F�N�g gvINIInformation.strSQLPWD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g gvINIInformation.strSQLUID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g gvINIInformation.strSQLDATABASE �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraConnect �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Not clsOra.OraConnect(gvINIInformation.strSQLDATABASE, gvINIInformation.strSQLUID, gvINIInformation.strSQLPWD, gvcstDspMsg) Then
			'        GoTo EXIT_STEP    2007.10.26
			GoTo EXIT_STEP2
		End If
		
		'//���b�Z�[�W�N���X��OraDatabase�v���p�e�B���Z�b�g����
		'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClsMessage.OraDatabase = clsOra.OraDatabase
		
		' -- UPD -- 2007/10/26 START --------------------------
		' -- ADD -- 2007/02/08 START
		'//�r������n�m
		'   Call Ctr_HaitaOn
		If Not Ctr_HaitaOn() Then
			' -- ADD -- 2007/12/07 START
			'//�X�e�[�^�X�t�@�C���ɐ���I����������
			'UPGRADE_WARNING: �I�u�W�F�N�g GetFullPath() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call Put_TextFile(GetFullPath(gvcst_TmpFilePath) & "\" & gvstrJOBID & "_Status.TXT", "HT", True)
			' -- ADD -- 2007/12/07 END
			GoTo EXIT_STEP2
		End If
		' -- ADD -- 2007/02/08 END
		' -- UPD -- 2007/10/26 END ----------------------------
		
		'//�X�g�A�h�N������
		If Not Ctr_StoredProcedure Then
			GoTo EXIT_STEP
		End If
		
		'//�X�e�[�^�X�t�@�C���ɐ���I����������
		'UPGRADE_WARNING: �I�u�W�F�N�g GetFullPath() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call Put_TextFile(GetFullPath(gvcst_TmpFilePath) & "\" & gvstrJOBID & "_Status.TXT", "OK", True)
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		''''    '//���ʃI�u�W�F�N�g�̉��
		''''    Call Ctr_Object(False)
		
		' -- ADD -- 2007/02/08 START
		'//�r������n�e�e
		Call Ctr_HaitaOff()
		' -- ADD -- 2007/02/08 END
		
		' -- ADD -- 2007/10/26 START
EXIT_STEP2: 
		' -- ADD -- 2007/10/26 END
		'//�I������
		Call Ctr_END()
		
		On Error GoTo 0
		
		End
		
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		If gvcstDspMsg Then
			MsgBox("<Sub_Main> " & vbCrLf & "���s���G���[�ł��B�����𒆎~���܂��B" & vbCrLf & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		End If
		Resume EXIT_STEP
		
	End Sub
	
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Ctr_END
	'//*
	'//* <�߂�l>     �^          ����
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*
	'//* <��  ��>
	'//*    �v���O�����̏I������
	'//*****************************************************************************************
	Public Sub Ctr_END()
		
		'//�f�[�^�x�[�X�ڑ�����(ORACLE���ް)
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDisConnect �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call clsOra.OraDisConnect()
		'//���ʃI�u�W�F�N�g�̉��
		Call Ctr_Object(False)
		'//�v���O�����I��
		End
		
	End Sub
	
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Ctr_Object
	'//*
	'//* <�߂�l>     �^          ����
	'//*              Boolean     True    :�ݒ�ł���
	'//*                          False   :�ݒ�ł��Ȃ�����
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pmf_Set          Boolean          I             True:�쐬 False:���
	'//* <��  ��>
	'//*    �I�u�W�F�N�g�C���X�^���X�̍쐬�^���
	'//*****************************************************************************************
	Function Ctr_Object(ByRef pmf_Set As Boolean) As Boolean
		
		Const PROCEDURE As String = "Ctr_Object"
		
		On Error GoTo ONERR_STEP
		
		Ctr_Object = False
		
		If pmf_Set Then
			'//���ʃI�u�W�F�N�g�̃C���X�^���X�쐬
			D0 = New ClsComn '//���ʸ׽
			clsOra = New ClsOraDB '//Oracle
			ClsMessage = New ClsMessage '//Message
		Else
			'//���ʃI�u�W�F�N�g�̃C���X�^���X���
			If Not (ClsMessage Is Nothing) Then '//Message
				'UPGRADE_NOTE: �I�u�W�F�N�g ClsMessage ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
				ClsMessage = Nothing
			End If
			If Not (clsOra Is Nothing) Then '//Oracle
				'UPGRADE_NOTE: �I�u�W�F�N�g clsOra ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
				clsOra = Nothing
			End If
			If Not (D0 Is Nothing) Then '//���ʸ׽
				'UPGRADE_NOTE: �I�u�W�F�N�g D0 ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
				D0 = Nothing
			End If
		End If
		
		Ctr_Object = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		If gvcstDspMsg Then
			'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		End If
		Resume EXIT_STEP
		
	End Function
	
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    GetIndividualIniFile
	'//*
	'//* <�߂�l>
	'//*              True    :�Ǎ��݂n�j
	'//*              False   :�Ǎ��݂d�q�q
	'//*
	'//* <��  ��>     ���ږ�             I/O      ���e
	'//*
	'//* <��  ��>
	'//*    �V�X�e�����ʏ����ݒ�t�@�C��(INI̧��)�̓Ǎ��ݏ���
	'//*****************************************************************************************
	Public Function GetIndividualIniFile() As Boolean
		Dim gvcst_IniFilePath As Object
		Dim GetFullPath As Object
		
		Const PROCEDURE As String = "GetIndividualIniFile"
		
		'//INI̧�َ擾��
		Const cstInFileCountKey As String = "INFILECOUNT"
		Const cstOtFileCountKey As String = "OTFILECOUNT"
		Const cstInFilePathKey As String = "INFILEPATH"
		Const cstOtFilePathKey As String = "OTFILEPATH"
		Const cstInFileNAMEKey As String = "INFILENAME"
		Const cstOtFileNAMEKey As String = "OTFILENAME"
		Const cstInFileCopyKey As String = "INFILECPNM"
		Const cstOtFileTimeKey As String = "OTFILETMSP"
		Const cstPARAMETERKey As String = "PARAMETER"
		
		Dim wk_String As String
		Dim str_Key As String
		Dim str_Path As String
		Dim int_Idx As Short
		Dim i As Short
		
		' -- ADD -- 2007/02/08 START
		Dim intRet As Short
		Dim strWK As String
		' -- ADD -- 2007/02/08 END
		
		On Error GoTo ONERR_STEP
		
		GetIndividualIniFile = False
		
		'��PATH�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g GetFullPath() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		str_Path = GetFullPath(gvcst_IniFilePath)
		
		'//-------------------------------------------------------------
		'//�ǉ��p�����[�^�擾
		'//-------------------------------------------------------------
		ReDim gvaryPARAMETER(0)
		i = 0
		Do 
			i = i + 1
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wk_String = D0.GetIniString(gvstrJOBID, cstPARAMETERKey & CStr(i), str_Path)
			If Trim(wk_String) = "" Then
				Exit Do
			End If
			ReDim Preserve gvaryPARAMETER(i)
			gvaryPARAMETER(i) = Trim(wk_String)
		Loop 
		
		'//-------------------------------------------------------------
		'//IN ̧�ُ��擾
		'//-------------------------------------------------------------
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wk_String = D0.GetIniString(gvstrJOBID, cstInFileCountKey, str_Path)
		If Trim(wk_String) = "" Then
			GoTo ERROR_STEP
		End If
		gvintInFileCount = Val(wk_String)
		
		ReDim gvaryInFileInfo(gvintInFileCount)
		For i = 1 To gvintInFileCount
			
			'//--�t�@�C���p�X �擾--
			str_Key = cstInFilePathKey & CStr(i)
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wk_String = D0.GetIniString(gvstrJOBID, str_Key, str_Path)
			If Trim(wk_String) = "" Then
				GoTo ERROR_STEP
			End If
			gvaryInFileInfo(i).strFilePath = wk_String
			
			'//--�t�@�C����   �擾--
			str_Key = cstInFileNAMEKey & CStr(i)
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wk_String = D0.GetIniString(gvstrJOBID, str_Key, str_Path)
			If Trim(wk_String) = "" Then
				GoTo ERROR_STEP
			End If
			
			int_Idx = InStr(1, wk_String, ".")
			gvaryInFileInfo(i).strFileName1 = Mid(wk_String, 1, int_Idx - 1)
			gvaryInFileInfo(i).strFileExtn1 = Mid(wk_String, int_Idx)
			
			'//--�O��t�@�C����   �擾--
			str_Key = cstInFileCopyKey & CStr(i)
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wk_String = D0.GetIniString(gvstrJOBID, str_Key, str_Path)
			If Trim(wk_String) = "" Then
				gvaryInFileInfo(i).strFileName2 = ""
				gvaryInFileInfo(i).strFileExtn2 = ""
			Else
				int_Idx = InStr(1, wk_String, ".")
				gvaryInFileInfo(i).strFileName2 = Mid(wk_String, 1, int_Idx - 1)
				gvaryInFileInfo(i).strFileExtn2 = Mid(wk_String, int_Idx)
			End If
			
		Next i
		
		'//-------------------------------------------------------------
		'//OUŢ�ُ��擾
		'//-------------------------------------------------------------
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wk_String = D0.GetIniString(gvstrJOBID, cstOtFileCountKey, str_Path)
		If Trim(wk_String) = "" Then
			GoTo ERROR_STEP
		End If
		gvintOtFileCount = Val(wk_String)
		
		ReDim gvaryOtFileInfo(gvintOtFileCount)
		For i = 1 To gvintOtFileCount
			
			'//--�t�@�C���p�X �擾--
			str_Key = cstOtFilePathKey & CStr(i)
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wk_String = D0.GetIniString(gvstrJOBID, str_Key, str_Path)
			If Trim(wk_String) = "" Then
				GoTo ERROR_STEP
			End If
			gvaryOtFileInfo(i).strFilePath = wk_String
			
			'//--�t�@�C����   �擾--
			str_Key = cstOtFileNAMEKey & CStr(i)
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wk_String = D0.GetIniString(gvstrJOBID, str_Key, str_Path)
			If Trim(wk_String) = "" Then
				GoTo ERROR_STEP
			End If
			
			int_Idx = InStr(1, wk_String, ".")
			gvaryOtFileInfo(i).strFileName1 = Mid(wk_String, 1, int_Idx - 1)
			gvaryOtFileInfo(i).strFileExtn1 = Mid(wk_String, int_Idx)
			
			'//--�^�C���X�^���v�t���t���O �擾 (0:�t�����Ȃ� 1:�t������) --
			str_Key = cstOtFileTimeKey & CStr(i)
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wk_String = D0.GetIniString(gvstrJOBID, str_Key, str_Path)
			If Trim(wk_String) = "" Then
				GoTo ERROR_STEP
			End If
			
			gvaryOtFileInfo(i).strFileTimeStampAddFlg = wk_String
			
		Next i
		
		' -- ADD -- 2007/02/08 START
		'//-------------------------------------------------------------
		'//�e�v���O�����ɑΉ��������g���C�����擾����
		'//-------------------------------------------------------------
		'���g���C�Ԋu
		pv_curRETRY_INTERVAL = 1000
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wk_String = D0.GetIniString(gvstrJOBID, pc_strIni_RETRY_INTERVAL, str_Path)
		strWK = wk_String
		If IsNumeric(strWK) = True Then
			pv_curRETRY_INTERVAL = CDec(strWK)
		End If
		
		'���g���C��
		pv_curRETRY_TIMES = 5
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wk_String = D0.GetIniString(gvstrJOBID, pc_strIni_RETRY_TIMES, str_Path)
		strWK = wk_String
		If IsNumeric(strWK) = True Then
			pv_curRETRY_TIMES = CDec(strWK)
		End If
		'//-------------------------------------------------------------
		'//�r������p��INI�擾
		'//-------------------------------------------------------------
		'���O�t�@�C���p�X
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wk_String = D0.GetIniString(gvcstJOB_ID, pc_strIni_LOGPATH, str_Path)
		If Trim(wk_String) = "" Then
			GoTo ERROR_STEP
		End If
		pv_strLOG_PATH = wk_String
		
		'���O�t�@�C����
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wk_String = D0.GetIniString(gvcstJOB_ID, pc_strIni_LOGNAME, str_Path)
		If Trim(wk_String) = "" Then
			GoTo ERROR_STEP
		End If
		pv_strLOG_NAME = wk_String
		
		' -- ADD -- 2007/02/08 END
		
		' -- ADD -- 2009/01/28 START (1.11)
		'//-------------------------------------------------------------
		'//�^�C���X�^���v�̖��O�ύX������RETRY�񐔂̎擾
		'//-------------------------------------------------------------
		'RETRY��
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wk_String = D0.GetIniString(gvcstJOB_ID, pc_strIni_RETRY_TIMESTAMP, str_Path)
		If Trim(wk_String) = "" Then
			GoTo ERROR_STEP
		End If
		If IsNumeric(wk_String) = True Then
			gvintRETRY_TIMESTAMP = CShort(wk_String)
		End If
		' -- ADD -- 2009/01/28 END   (1.11)
		
		GetIndividualIniFile = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ERROR_STEP: 
		If gvcstDspMsg Then
			MsgBox("�y" & Trim(gvcstJOB_Titl) & "�z�͂h�m�h�t�@�C���̎擾�Ɏ��s���܂����B�����𒆎~���܂��B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, My.Application.Info.Title)
		End If
		GoTo EXIT_STEP
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		If gvcstDspMsg Then
			'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		End If
		Resume EXIT_STEP
	End Function
	
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Ctr_StoredProcedure
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    �X�g�A�h�����̋N��
	'//*****************************************************************************************
	Public Function Ctr_StoredProcedure() As Boolean
		Dim Put_TextFile As Object
		Dim gvcst_BakFilePath As Object
		Dim gvcst_TmpFilePath As Object
		Dim GetFullPath As Object
		
		Const PROCEDURE As String = "Ctr_StoredProcedure"
		
		Dim i As Short
		Dim vntArray As Object
		Dim strNewTimeStamp As String
		Dim strOldTimeStamp As String
		Dim strNewFileName As String
		Dim strOldFileName As String
		Dim strFrFileName As String
		Dim strToFileName As String
		Dim strZnFileName As String
		Dim int_LoopCnt As Short
		Dim int_LoopMax As Short
		
		On Error Resume Next
		'UPGRADE_WARNING: �I�u�W�F�N�g GetFullPath() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Kill(GetFullPath(gvcst_TmpFilePath) & "\" & gvstrJOBID & "_DelLst.TXT")
		On Error GoTo 0
		
		On Error GoTo ONERR_STEP
		
		Ctr_StoredProcedure = False
		
		int_LoopMax = 1
		int_LoopCnt = 1
		
		' -- ADD -- 2008/05/15 START (1.10)
		gvstrPLSqlWkFileName = gvstrJOBID & "_WK"
		' -- ADD -- 2008/05/15 END   (1.10)
		
		'// IN ̧�وꗗ���擾
		ReDim gvaryInGetFile(0)
		For i = 1 To gvintInFileCount
			ReDim Preserve gvaryInGetFile(i)
			Call Get_FileList(gvaryInFileInfo(i).strFilePath, gvaryInFileInfo(i).strFileName1 & "*" & gvaryInFileInfo(i).strFileExtn1, vntArray, int_LoopMax)
			'UPGRADE_WARNING: �I�u�W�F�N�g vntArray �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			gvaryInGetFile(i).strFileName = vntArray
		Next i
		
		'// IN ̧�وꗗ�̔z��̎��������킹��
		For i = 1 To gvintInFileCount
			ReDim Preserve gvaryInGetFile(i).strFileName(int_LoopMax)
		Next i
		
		'//�X�g�A�h�N��
		Do Until int_LoopCnt > int_LoopMax
			
			'// �^�C���X�^���v�擾
			Do 
				'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraGetNowTm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraGetNowDt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strNewTimeStamp = clsOra.OraGetNowDt(1) & clsOra.OraGetNowTm
				If strOldTimeStamp <> strNewTimeStamp Then
					Exit Do
				End If
				'UPGRADE_WARNING: �I�u�W�F�N�g D0.Ctr_WaitTime �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				D0.Ctr_WaitTime(1)
			Loop 
			strOldTimeStamp = strNewTimeStamp
			
			'// OUŢ�وꗗ�𐶐�
			ReDim gvaryOtGetFile(0)
			For i = 1 To gvintOtFileCount
				ReDim Preserve gvaryOtGetFile(i)
				ReDim Preserve gvaryOtGetFile(i).strFileName(1)
				'// ��ѽ���ߕt������
				If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) = 1 Then
					'UPGRADE_WARNING: �I�u�W�F�N�g gvaryOtGetFile().strFileName(1) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					gvaryOtGetFile(i).strFileName(1) = gvaryOtFileInfo(i).strFileName1 & strNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g gvaryOtGetFile().strFileName(1) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					gvaryOtGetFile(i).strFileName(1) = gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
				End If
			Next i
			
			' -- ADD -- 2007/01/14 START
			'// ���M�t�@�C���̃o�b�N�A�b�v�Ƒ��M�t�@�C���̖��O��ύX
			On Error Resume Next
			For i = 1 To gvintOtFileCount
				'//���O�ύX
				If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) <> 1 Then
					' -- UPD -- 2008/05/15 START (1.10)
					'                strOldFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
					''                             "WK" & gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
					strOldFileName = gvaryOtFileInfo(i).strFilePath & "\" & gvstrPLSqlWkFileName & gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
					' -- UPD -- 2008/05/15 END   (1.10)
					strNewFileName = gvaryOtFileInfo(i).strFilePath & "\" & gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
					'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
					If Dir(strOldFileName) <> "" Then
						Kill(strOldFileName)
					End If
					'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
					If Dir(strNewFileName) <> "" Then
						' -- UPD -- 2009/10/15 START (1.20)
						'                    Name strNewFileName As strOldFileName
						'//�R�s�[����
						Call CopyFile(strNewFileName, strOldFileName, 0)
						' -- UPD -- 2009/10/15 END   (1.20)
					End If
				End If
			Next i
			On Error GoTo 0
			On Error GoTo ONERR_STEP
			' -- ADD -- 2007/01/14 END
			
			'// �X�g�A�h�����̎��s����
			If Not RunStoredProcedure(int_LoopCnt) Then
				GoTo EXIT_STEP
			End If
			
			' -- UPD -- 2009/01/28 START (1.11)
			' -- UPD -- 2006/12/15 START
			'// ���M�t�@�C���̃o�b�N�A�b�v�Ƒ��M�t�@�C���̖��O��ύX
			If Not Snd_FileCopy(strNewTimeStamp) Then
				GoTo EXIT_STEP
			End If
			
			'        '// ���M�t�@�C���̃o�b�N�A�b�v�Ƒ��M�t�@�C���̖��O��ύX
			'        On Error Resume Next
			'        For i = 1 To gvintOtFileCount
			'
			'            '//�o�b�N�A�b�v
			'            If UCase(Right(gvaryOtFileInfo(i).strFilePath, 3)) <> "TMP" Then
			'                '// ��ѽ���ߕt������
			'                If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) = 1 Then
			'                    strFrFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
			''                                 "WK" & gvaryOtFileInfo(i).strFileName1 & strNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
			'                    strToFileName = GetFullPath(gvcst_BakFilePath) & "\DAT\SND\" & _
			''                                        gvaryOtFileInfo(i).strFileName1 & strNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
			'                Else
			'                    strFrFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
			''                                 "WK" & gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
			'                    strToFileName = GetFullPath(gvcst_BakFilePath) & "\DAT\SND\" & _
			''                                        gvaryOtFileInfo(i).strFileName1 & strNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
			'                End If
			'                FileCopy strFrFileName, strToFileName
			'            End If
			'
			'            '//���O�ύX
			'            '// ��ѽ���ߕt������
			'            If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) = 1 Then
			'                strOldFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
			''                             "WK" & gvaryOtFileInfo(i).strFileName1 & strNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
			'                strNewFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
			''                                    gvaryOtFileInfo(i).strFileName1 & strNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
			'            Else
			'                strOldFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
			''                             "WK" & gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
			'                strNewFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
			''                                    gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
			'            End If
			'            If Dir(strNewFileName) <> "" Then
			'                Kill strNewFileName
			'            End If
			'            Name strOldFileName As strNewFileName
			'
			'        Next i
			'        On Error GoTo 0
			' -- UPD -- 2006/12/15 END
			' -- UPD -- 2009/01/28 END   (1.11)
			
			'// ��M�t�@�C���̃o�b�N�A�b�v�ƍ폜���X�g���쐬
			On Error GoTo ONERR_STEP
			For i = 1 To gvintInFileCount
				
				'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
				If Not IsNothing(gvaryInGetFile(i).strFileName(int_LoopCnt)) Then
					'//�o�b�N�A�b�v
					'UPGRADE_WARNING: �I�u�W�F�N�g gvaryInGetFile(i).strFileName(int_LoopCnt) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strFrFileName = gvaryInFileInfo(i).strFilePath & "\" & gvaryInGetFile(i).strFileName(int_LoopCnt)
					' -- UPD -- 2006/12/15 START
					'                strToFileName = GetFullPath(gvcst_BakFilePath) & "\DAT\RCV\" & gvaryInGetFile(i).strFileName(int_LoopCnt)
					'UPGRADE_WARNING: �I�u�W�F�N�g gvaryInGetFile().strFileName() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g GetFullPath() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strToFileName = GetFullPath(gvcst_BakFilePath) & "\DAT\RCV\" & AddTimeStampFileName(gvaryInGetFile(i).strFileName(int_LoopCnt))
					' -- UPD -- 2006/12/15 END
					If UCase(Right(gvaryInFileInfo(i).strFilePath, 3)) <> "TMP" Then
						FileCopy(strFrFileName, strToFileName)
					End If
					
					If gvaryInFileInfo(i).strFileName2 = "" Then
						If UCase(Right(gvaryInFileInfo(i).strFileName1, 3)) <> "ZEN" Then
							'//�t�@�C���폜
							Kill(strFrFileName)
						End If
					Else
						'//�O�񕪂֕ۑ�
						strZnFileName = Replace(UCase(strFrFileName), UCase(gvaryInFileInfo(i).strFileName1), UCase(gvaryInFileInfo(i).strFileName2))
						strZnFileName = Replace(UCase(strZnFileName), UCase(gvaryInFileInfo(i).strFileExtn1), UCase(gvaryInFileInfo(i).strFileExtn2))
						'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
						If Dir(strZnFileName) <> "" Then
							Kill(strZnFileName)
						End If
						Rename(strFrFileName, strZnFileName)
					End If
					
					'//�폜���X�g�쐬
					If UCase(Right(gvaryInFileInfo(i).strFilePath, 3)) <> "TMP" Then
						'UPGRADE_WARNING: �I�u�W�F�N�g GetFullPath() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call Put_TextFile(GetFullPath(gvcst_TmpFilePath) & "\" & gvstrJOBID & "_DelLst.TXT", gvaryInGetFile(i).strFileName(int_LoopCnt), False)
					End If
				End If
				
			Next i
			
			int_LoopCnt = int_LoopCnt + 1
			
		Loop 
		
		Ctr_StoredProcedure = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		If gvcstDspMsg Then
			'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		End If
		Resume EXIT_STEP
		
	End Function
	
	' -- ADD -- 2008/05/15 START (1.10)
	'//****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Snd_FileCopy
	'//*
	'//* <�߂�l>     �^          ����
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*
	'//* <��  ��>
	'//*    ���M�t�@�C���̃o�b�N�A�b�v�Ɩ��O�̕ύX���s��
	'//****************************************************************************************
	Function Snd_FileCopy(ByRef pstrNewTimeStamp As String) As Boolean
		Dim gvcst_BakFilePath As Object
		Dim GetFullPath As Object
		
		Const PROCEDURE As String = "Snd_FileCopy"
		
		Dim str_FromFileName As String
		Dim str_BackToFileName As String
		Dim str_SendToFileName As String
		Dim dtaNewTimeStamp As Date
		Dim i As Short
		Dim intLoopCnt As Short
		
		On Error GoTo ONERR_STEP
		
		Snd_FileCopy = False
		
		For i = 1 To gvintOtFileCount
			'//�o�b�`�ō쐬����Ă���t�@�C�����𐶐�
			If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) = 1 Then
				str_FromFileName = gvaryOtFileInfo(i).strFilePath & "\" & gvstrPLSqlWkFileName & gvaryOtFileInfo(i).strFileName1 & pstrNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
			Else
				str_FromFileName = gvaryOtFileInfo(i).strFilePath & "\" & gvstrPLSqlWkFileName & gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
			End If
			
			'//-------------- ���M        �t�H���_�̃t�@�C������ ---------------
			
			dtaNewTimeStamp = CDate(VB6.Format(pstrNewTimeStamp, "0000/00/00 00:00:00"))
			
			'// �R�s�[����
			intLoopCnt = 0
			Do 
				'//�����Ώۂ̃t�@�C�������݂��Ȃ��ꍇ�̓��[�v�𔲂���
				'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
				If Dir(str_FromFileName) = "" Then
					Exit Do
				End If
				
				'//���[�v�ُ�I��(99�񃋁[�v���Ă��ʖڂ�������I������)
				' -- UPD -- 2009/01/28 START (1.11)
				'            intLoopCnt = intLoopCnt + 1
				'            If intLoopCnt > 99 Then
				'                Call F_Edit_ErrLog(0, "�X�X�񃊃g���C���܂������A�t�@�C���R�s�[���ł��܂���ł����B", "Snd_FileCopy")
				'                GoTo EXIT_STEP
				'            End If
				If intLoopCnt > gvintRETRY_TIMESTAMP Then
					Call F_Edit_ErrLog(0, CStr(gvintRETRY_TIMESTAMP) & " �񃊃g���C���܂������A�t�@�C���R�s�[���ł��܂���ł����B�y���M�t�H���_�����z" & str_FromFileName, "Snd_FileCopy")
					GoTo EXIT_STEP
				End If
				intLoopCnt = intLoopCnt + 1
				' -- UPD -- 2009/01/28 END   (1.11)
				
				'//���M�t�@�C���R�s�[
				If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) = 1 Then
					
					'//�t�H���_�֒u���t�@�C�����̐���
					str_SendToFileName = gvaryOtFileInfo(i).strFilePath & "\" & gvaryOtFileInfo(i).strFileName1 & VB6.Format(dtaNewTimeStamp, "YYYYMMDDHHMMSS") & gvaryOtFileInfo(i).strFileExtn1
					
					'//�R�s�[����
					If CopyFile(str_FromFileName, str_SendToFileName, 1) <> 0 Then
						'//�R�s�[������ɍs��ꂽ�i�R�s�[��̃t�@�C�������݂��Ă��Ȃ����[�h�j
						Exit Do
					End If
					
				Else
					
					'//�t�H���_�֒u���t�@�C�����̐���
					str_SendToFileName = gvaryOtFileInfo(i).strFilePath & "\" & gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
					
					' -- UPD -- 2009/10/15 START (1.20)
					'                '//�R�s�[����
					'                If CopyFile(str_FromFileName, str_SendToFileName, 1) <> 0 Then
					'                    '//�R�s�[������ɍs��ꂽ�i�R�s�[��̃t�@�C�������݂��Ă��Ȃ����[�h�j
					'                    Exit Do
					'                End If
					'                '//�R�s�[������ɍs���Ȃ������B
					'                Call F_Edit_ErrLog(0, "���Ƀt�@�C�������݂��邽�߁A�t�@�C���R�s�[���ł��܂���ł����B", "Snd_FileCopy")
					'                GoTo EXIT_STEP
					'//�R�s�[����
					If CopyFile(str_FromFileName, str_SendToFileName, 0) <> 0 Then
						'//�R�s�[������ɍs��ꂽ�i����t�@�C��������Ƃ��㏑�����郂�[�h�j
						Exit Do
					End If
					'//�R�s�[������ɍs���Ȃ������B
					Call F_Edit_ErrLog(0, "�t�@�C���R�s�[���ł��܂���ł����B", "Snd_FileCopy")
					GoTo EXIT_STEP
					' -- UPD -- 2009/10/15 END   (1.20)
					
				End If
				
				'// �R�s�[������ɂł��Ȃ����߃^�C���X�^���v�ɂP���Z
				dtaNewTimeStamp = DateAdd(Microsoft.VisualBasic.DateInterval.Second, 1, dtaNewTimeStamp)
			Loop 
			
			'//-------------- �o�b�N�A�b�v�t�H���_�̃t�@�C������ ---------------
			
			'// ���o�b�N�A�b�v�t�H���_�Ƀt�@�C�����R�s�[����ꍇ�́A
			'//   �^�C���X�^���v�t���敪�̗L���Ɋւ�炸�^�C���X�^���v������B
			
			'//�o�b�N�A�b�v
			If UCase(Right(gvaryOtFileInfo(i).strFilePath, 3)) <> "TMP" Then
				
				dtaNewTimeStamp = CDate(VB6.Format(pstrNewTimeStamp, "0000/00/00 00:00:00"))
				
				'// �R�s�[����
				intLoopCnt = 0
				Do 
					'//�����Ώۂ̃t�@�C�������݂��Ȃ��ꍇ�̓��[�v�𔲂���
					'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
					If Dir(str_FromFileName) = "" Then
						Exit Do
					End If
					
					'//���[�v�ُ�I��(99�񃋁[�v���Ă��ʖڂ�������I������)
					' -- UPD -- 2009/01/28 START (1.11)
					'                intLoopCnt = intLoopCnt + 1
					'                If intLoopCnt > 99 Then
					'                    Call F_Edit_ErrLog(0, "�X�X�񃊃g���C���܂������A�t�@�C���R�s�[���ł��܂���ł����B", "Snd_FileCopy")
					'                    GoTo EXIT_STEP
					'                End If
					If intLoopCnt > gvintRETRY_TIMESTAMP Then
						Call F_Edit_ErrLog(0, CStr(gvintRETRY_TIMESTAMP) & " �񃊃g���C���܂������A�t�@�C���R�s�[���ł��܂���ł����B�y���M�t�H���_�i�o�b�N�A�b�v�j�����z" & str_FromFileName, "Snd_FileCopy")
						GoTo EXIT_STEP
					End If
					intLoopCnt = intLoopCnt + 1
					' -- UPD -- 2009/01/28 END   (1.11)
					
					'//���M�t�@�C���R�s�[
					If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) = 1 Then
						
						'//�t�H���_�֒u���t�@�C�����̐���
						'UPGRADE_WARNING: �I�u�W�F�N�g GetFullPath() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						str_BackToFileName = GetFullPath(gvcst_BakFilePath) & "\DAT\SND\" & gvaryOtFileInfo(i).strFileName1 & VB6.Format(dtaNewTimeStamp, "YYYYMMDDHHMMSS") & gvaryOtFileInfo(i).strFileExtn1
					Else
						
						'//�t�H���_�֒u���t�@�C�����̐���
						'UPGRADE_WARNING: �I�u�W�F�N�g GetFullPath() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						str_BackToFileName = GetFullPath(gvcst_BakFilePath) & "\DAT\SND\" & gvaryOtFileInfo(i).strFileName1 & VB6.Format(dtaNewTimeStamp, "YYYYMMDDHHMMSS") & gvaryOtFileInfo(i).strFileExtn1
						
					End If
					
					'//�o�b�N�A�b�v�t�H���_�̃t�@�C������
					If CopyFile(str_FromFileName, str_BackToFileName, 1) <> 0 Then
						'//�R�s�[������ɍs��ꂽ�i�R�s�[��̃t�@�C�������݂��Ă��Ȃ����[�h�j
						Exit Do
					End If
					
					'// �R�s�[������ɂł��Ȃ����߃^�C���X�^���v�ɂP���Z
					dtaNewTimeStamp = DateAdd(Microsoft.VisualBasic.DateInterval.Second, 1, dtaNewTimeStamp)
				Loop 
				
			End If
			
			'//�o�b�`�ō쐬����Ă���t�@�C�����폜
			'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			If Dir(str_FromFileName) <> "" Then
				Kill(str_FromFileName)
			End If
			
		Next i
		
		Snd_FileCopy = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		If gvcstDspMsg Then
			'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		End If
		Resume EXIT_STEP
		
	End Function
	' -- ADD -- 2008/05/15 END   (1.10)
	
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Get_FileList
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    �w�肳�ꂽ�t�H���_�[�̃t�@�C���ꗗ��Ԃ��i�w�肳�ꂽ�����Łj
	'//*****************************************************************************************
	Public Function Get_FileList(ByVal pmsGetFilePath As String, ByVal pmsGetFileName As String, ByRef pmvArray As Object, ByRef pmiLoopMax As Short) As Boolean
		
		Const PROCEDURE As String = "Get_FileList"
		
		Dim i As Short
		Dim strFileNmae As String
		
		On Error GoTo ONERR_STEP
		
		Get_FileList = False
		
		i = 0
		ReDim pmvArray(i)
		
		'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		strFileNmae = Dir(pmsGetFilePath & "\" & pmsGetFileName, FileAttribute.Normal) ' �ŏ��̃t�H���_����Ԃ��܂��B
		Do While strFileNmae <> "" ' ���[�v���J�n���܂��B
			
			i = i + 1
			ReDim Preserve pmvArray(i)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g pmvArray() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pmvArray(i) = strFileNmae ' �t�@�C�����̊i�[
			
			'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			strFileNmae = Dir() ' ���̃t�@�C������Ԃ��܂��B
		Loop 
		
		If pmiLoopMax <= i Then
			pmiLoopMax = i
		End If
		
		' -- ADD -- 2008/05/14 START (1.10)
		Dim int_i As Short
		Dim int_j As Short
		Dim vnt_Work As Object
		
		For int_i = 1 To UBound(pmvArray)
			For int_j = int_i + 1 To UBound(pmvArray)
				'UPGRADE_WARNING: �I�u�W�F�N�g pmvArray(int_j) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g pmvArray(int_i) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If pmvArray(int_i) >= pmvArray(int_j) Then
					'UPGRADE_WARNING: �I�u�W�F�N�g pmvArray() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g vnt_Work �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					vnt_Work = pmvArray(int_i)
					'UPGRADE_WARNING: �I�u�W�F�N�g pmvArray() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pmvArray(int_i) = pmvArray(int_j)
					'UPGRADE_WARNING: �I�u�W�F�N�g vnt_Work �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g pmvArray() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pmvArray(int_j) = vnt_Work
				End If
			Next int_j
		Next int_i
		' -- ADD -- 2008/05/14 END   (1.10)
		
		Get_FileList = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		If gvcstDspMsg Then
			'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		End If
		Resume EXIT_STEP
		
	End Function
	
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    RunStoredProcedure
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*
	'//* <��  ��>
	'//*    �X�g�A�h�����̎��s����
	'//*****************************************************************************************
	Public Function RunStoredProcedure(ByVal pmiIndex As Short) As Boolean
		Dim ORATYPE_NUMBER As Object
		Dim ORAPARM_OUTPUT As Object
		Dim ORATYPE_VARCHAR2 As Object
		Dim gvstrCLTID As Object
		Dim ORATYPE_CHAR As Object
		Dim ORAPARM_INPUT As Object
		Dim gvstrOPEID As Object
		
		Const PROCEDURE As String = "RunStoredProcedure"
		
		Dim i As Short
		Dim intRtnCd As Short '�߂�l
		Dim strEXECUTE As String
		
		RunStoredProcedure = False
		
		On Error GoTo ONERR_STEP
		
		'// ��ݻ޸��ݐ���́A�I���N�����Ŏ��{����̂ŃR�����g�ɂ���
		''''    '//��ݻ޸��ݐ���J�n
		''''    clsOra.OraBeginTrans
		
		'//PL/SQL���Ăԁi�O�����j
		
		'// -- ���Ұ��̸ر --
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Remove("RTNCD")
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Remove("PARA_OPEID")
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Remove("PARA_CLTID")
		For i = 1 To UBound(gvaryPARAMETER)
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Remove("PARA_ADDPARA" & CStr(i))
		Next i
		For i = 1 To gvintInFileCount
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Remove("PARA_INPATH" & CStr(i))
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Remove("PARA_INFILE" & CStr(i))
		Next i
		For i = 1 To gvintOtFileCount
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Remove("PARA_OTPATH" & CStr(i))
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Remove("PARA_OTFILE" & CStr(i))
		Next i
		
		'// -- ���Ұ��̐ݒ� --
		
		'//���O�C�����[�U�[�h�c
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Add("PARA_OPEID", gvstrOPEID, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters("PARA_OPEID").serverType = ORATYPE_CHAR
		
		'//�[���ԍ�
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Add("PARA_CLTID", gvstrCLTID, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters("PARA_CLTID").serverType = ORATYPE_CHAR
		
		'//�ǉ��p�����[�^
		For i = 1 To UBound(gvaryPARAMETER)
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Add("PARA_ADDPARA" & CStr(i), gvaryPARAMETER(i), ORAPARM_INPUT)
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters("PARA_ADDPARA" & CStr(i)).serverType = ORATYPE_CHAR
		Next i
		
		'//IN �t�@�C���p�X�E�t�@�C����
		For i = 1 To gvintInFileCount
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Add("PARA_INPATH" & CStr(i), D0.Chk_Null(gvaryInFileInfo(i).strFilePath), ORAPARM_INPUT)
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_VARCHAR2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters("PARA_INPATH" & CStr(i)).serverType = ORATYPE_VARCHAR2
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Add("PARA_INFILE" & CStr(i), D0.Chk_Null(gvaryInGetFile(i).strFileName(pmiIndex)), ORAPARM_INPUT)
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_VARCHAR2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters("PARA_INFILE" & CStr(i)).serverType = ORATYPE_VARCHAR2
		Next i
		
		'//OUT�t�@�C���p�X�E�t�@�C����
		For i = 1 To gvintOtFileCount
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Add("PARA_OTPATH" & CStr(i), D0.Chk_Null(gvaryOtFileInfo(i).strFilePath), ORAPARM_INPUT)
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_VARCHAR2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters("PARA_OTPATH" & CStr(i)).serverType = ORATYPE_VARCHAR2
			' -- UPD -- 2008/05/15 START (1.10)
			'        clsOra.OraDatabase.Parameters.Add "PARA_OTFILE" & CStr(i), "WK" & D0.Chk_Null(gvaryOtGetFile(i).strFileName(1)), ORAPARM_INPUT
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Add("PARA_OTFILE" & CStr(i), gvstrPLSqlWkFileName & D0.Chk_Null(gvaryOtGetFile(i).strFileName(1)), ORAPARM_INPUT)
			' -- UPD -- 2008/05/15 END   (1.10)
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_VARCHAR2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters("PARA_OTFILE" & CStr(i)).serverType = ORATYPE_VARCHAR2
		Next i
		
		'//�߂�l
		intRtnCd = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Add("RTNCD", intRtnCd, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_NUMBER �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters("RTNCD").serverType = ORATYPE_NUMBER
		
		'//PL/SQL���ĂԁiMAIN�j
		strEXECUTE = ""
		strEXECUTE = strEXECUTE & "BEGIN"
		strEXECUTE = strEXECUTE & ":RTNCD := " & gvstrPLSQLPACKAGE & "." & gvstrPLSQLFUNCTION & "("
		strEXECUTE = strEXECUTE & " :PARA_OPEID"
		strEXECUTE = strEXECUTE & ",:PARA_CLTID"
		For i = 1 To UBound(gvaryPARAMETER)
			strEXECUTE = strEXECUTE & ",:PARA_ADDPARA" & CStr(i)
		Next i
		For i = 1 To gvintInFileCount
			strEXECUTE = strEXECUTE & ",:PARA_INPATH" & CStr(i)
			strEXECUTE = strEXECUTE & ",:PARA_INFILE" & CStr(i)
		Next i
		For i = 1 To gvintOtFileCount
			strEXECUTE = strEXECUTE & ",:PARA_OTPATH" & CStr(i)
			strEXECUTE = strEXECUTE & ",:PARA_OTFILE" & CStr(i)
		Next i
		strEXECUTE = strEXECUTE & ");"
		strEXECUTE = strEXECUTE & "END;"
		
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraExecute �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Not clsOra.OraExecute(strEXECUTE,  , PROCEDURE, gvcstDspMsg) Then
			'//���Ұ��̸ر
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Remove("RTNCD")
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Remove("PARA_OPEID")
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Remove("PARA_CLTID")
			For i = 1 To gvintInFileCount
				'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				clsOra.OraDatabase.Parameters.Remove("PARA_INPATH" & CStr(i))
				'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				clsOra.OraDatabase.Parameters.Remove("PARA_INFILE" & CStr(i))
			Next i
			For i = 1 To gvintOtFileCount
				'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				clsOra.OraDatabase.Parameters.Remove("PARA_OTPATH" & CStr(i))
				'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				clsOra.OraDatabase.Parameters.Remove("PARA_OTFILE" & CStr(i))
			Next i
			GoTo EXIT_STEP
		End If
		
		'//�߂�l�m�F
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If clsOra.OraDatabase.Parameters("RTNCD").Value <> 0 Then
			'//(�ُ�)
			'//���Ұ��̸ر
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Remove("RTNCD")
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Remove("PARA_OPEID")
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Remove("PARA_CLTID")
			For i = 1 To UBound(gvaryPARAMETER)
				'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				clsOra.OraDatabase.Parameters.Remove("PARA_ADDPARA" & CStr(i))
			Next i
			For i = 1 To gvintInFileCount
				'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				clsOra.OraDatabase.Parameters.Remove("PARA_INPATH" & CStr(i))
				'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				clsOra.OraDatabase.Parameters.Remove("PARA_INFILE" & CStr(i))
			Next i
			For i = 1 To gvintOtFileCount
				'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				clsOra.OraDatabase.Parameters.Remove("PARA_OTPATH" & CStr(i))
				'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				clsOra.OraDatabase.Parameters.Remove("PARA_OTFILE" & CStr(i))
			Next i
			'// ��ݻ޸��ݐ���́A�I���N�����Ŏ��{����̂ŃR�����g�ɂ���
			''''        '//��ݻ޸���(۰��ޯ�)
			''''        clsOra.OraRollback
			GoTo EXIT_STEP
		End If
		
		'//PL/SQL���Ăԁi�㏈���j
		'//���Ұ��̸ر
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Remove("RTNCD")
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Remove("PARA_OPEID")
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Remove("PARA_CLTID")
		For i = 1 To UBound(gvaryPARAMETER)
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Remove("PARA_ADDPARA" & CStr(i))
		Next i
		For i = 1 To gvintInFileCount
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Remove("PARA_INPATH" & CStr(i))
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Remove("PARA_INFILE" & CStr(i))
		Next i
		For i = 1 To gvintOtFileCount
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Remove("PARA_OTPATH" & CStr(i))
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraDatabase.Parameters.Remove("PARA_OTFILE" & CStr(i))
		Next i
		
		'// ��ݻ޸��ݐ���́A�I���N�����Ŏ��{����̂ŃR�����g�ɂ���
		''''    '//��ݻ޸���(�Я�)
		''''    clsOra.OraCommitTrans
		
		RunStoredProcedure = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		If gvcstDspMsg Then
			'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		End If
		Resume EXIT_STEP
		
	End Function
	
	' -- ADD -- 2006/12/15 START
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    AddTimeStampFileName
	'//*
	'//* <�߂�l>   �^                  ����
	'//*            String              �^�C���X�^���v�t�����ꂽ�t�@�C����
	'//*
	'//* <��  ��>   ���ږ�              �^              I/O     ���e
	'//*            strFilePathName     String          I       �t�@�C����
	'//*
	'//* <��  ��>
	'//*    �t�@�C�����Ƀ^�C���X�^���v��t�������t�@�C������Ԃ�
	'//*****************************************************************************************
	Function AddTimeStampFileName(ByVal strFilePathName As String) As String
		
		Dim int_Idx As Short
		Dim strFileName As String
		Dim strFileExtn As String
		
		'�t�@�C�����Ƀ^�C���X�^���v��t������ׂ̔��f������
		Const intLength As Short = 19
		
		If Len(strFilePathName) <= intLength Then
			'�t�@�C�������ݒ蕶���ȉ��Ȃ̂Ń^�C���X�^���v��t������
			int_Idx = InStr(1, strFilePathName, ".")
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraGetNowTm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraGetNowDt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strFileName = Mid(strFilePathName, 1, int_Idx - 1) & clsOra.OraGetNowDt(1) & clsOra.OraGetNowTm
			strFileExtn = Mid(strFilePathName, int_Idx)
			
			'�t�@�C��������
			AddTimeStampFileName = strFileName & strFileExtn
		Else
			'�t�@�C�������ݒ蕶�����傫���̂Ń^�C���X�^���v��t������
			
			'�t�@�C��������
			AddTimeStampFileName = strFilePathName
		End If
		
	End Function
	' -- ADD -- 2006/12/15 END
	
	' -- ADD -- 2007/02/08 START
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function ctr_HaitaOn
	'   �T�v�F�@�r�����䏈��
	'   �����F�@����
	'   �ߒl�F�@True : ���� False : �ُ�
	'   ���l�F  �r������n�m
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function Ctr_HaitaOn() As Boolean
		
		Dim strMsg As String
		Dim IntCnt As Short
		
		Ctr_HaitaOn = False
		
		IntCnt = 0
		Do Until IntCnt > pv_curRETRY_TIMES
			
			IntCnt = IntCnt + 1
			
			'�r���`�F�b�N���s��
			Select Case CF_Chk_Lock_EXCTBZ(strMsg)
				'����
				Case 0
					Exit Do
					
					'�r��������
				Case 1
					If IntCnt > pv_curRETRY_TIMES Then
						'�G���[���O�o��
						Call F_Edit_ErrLog(0, Trim(strMsg) & "�����s���̂��ߏ����𒆎~���܂����B", "Ctr_HaitaOn")
						Exit Function
					Else
						' -- ADD -- 2007/12/03 START
						Call F_Edit_ErrLog(0, Trim(strMsg) & "�����s���̂��ߑҋ@���܂�", "Ctr_HaitaOn")
						' -- ADD -- 2007/12/03 END
						Sleep(pv_curRETRY_INTERVAL)
					End If
					
					'�ُ�I��
				Case 9
					'�G���[���O�o��
					Call F_Edit_ErrLog(0, "�Ɩ��r�������ɂĂc�a�G���[���������܂����B", "Ctr_HaitaOn")
					Exit Function
					
			End Select
		Loop 
		
		Ctr_HaitaOn = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctr_HaitaOff
	'   �T�v�F�@�r�����䏈��
	'   �����F�@����
	'   �ߒl�F�@True : ���� False : �ُ�
	'   ���l�F  �r������n�e�e
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function Ctr_HaitaOff() As Boolean
		
		Dim strMsg As String
		
		'�r����������
		Call CF_Unlock_EXCTBZ(strMsg)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_Lock_EXCTBZ
	'   �T�v�F�@�r�����䏈��
	'   �����F�@Pot_strMsg       : �G���[���e
	'   �ߒl�F�@0 : ���� 1 : �r���Ɩ����� 9 : �ُ�
	'   ���l�F  �r������i�r���`�F�b�N���r���e�[�u���ւ̏������݁j���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_Lock_EXCTBZ(ByRef Pot_strMsg As String) As Short
		
		Dim intRet As Short
		Dim strMsg As String
		Dim bolTrn As Boolean
		
		On Error GoTo CF_Chk_Lock_EXCTBZ_Err
		
		CF_Chk_Lock_EXCTBZ = 9
		Pot_strMsg = ""
		bolTrn = False
		
		'�r���`�F�b�N
		intRet = AE_Execute_PLSQL_EXCTBZ("C", strMsg)
		If intRet <> 0 Then
			'�r���G���[
			Pot_strMsg = strMsg
			CF_Chk_Lock_EXCTBZ = intRet
			GoTo CF_Chk_Lock_EXCTBZ_Err
		End If
		
		'//��ݻ޸��ݐ���J�n
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraBeginTrans �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraBeginTrans()
		bolTrn = True
		
		'�r������
		intRet = AE_Execute_PLSQL_EXCTBZ("W", strMsg)
		If intRet <> 0 Then
			'�r���G���[
			Pot_strMsg = strMsg
			CF_Chk_Lock_EXCTBZ = intRet
			GoTo CF_Chk_Lock_EXCTBZ_Err
		End If
		
		'//��ݻ޸���(�Я�)
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCommitTrans �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraCommitTrans()
		bolTrn = False
		
		CF_Chk_Lock_EXCTBZ = 0
		
		Exit Function
		
CF_Chk_Lock_EXCTBZ_Err: 
		
		'���[���o�b�N
		If bolTrn = True Then
			'//��ݻ޸���(۰��ޯ�)
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraRollback �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraRollback()
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Unlock_EXCTBZ
	'   �T�v�F�@�r�������������
	'   �����F�@Pot_strMsg       : �G���[���e
	'   �ߒl�F�@0 : ����  9 : �ُ�
	'   ���l�F  �r������i�r���e�[�u������̍폜�j���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Unlock_EXCTBZ(ByRef Pot_strMsg As String) As Short
		
		Dim intRet As Short
		Dim strMsg As String
		Dim bolTrn As Boolean
		
		On Error GoTo CF_Unlock_EXCTBZ_Err
		
		CF_Unlock_EXCTBZ = 9
		Pot_strMsg = ""
		bolTrn = False
		
		'//��ݻ޸��ݐ���J�n
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraBeginTrans �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraBeginTrans()
		bolTrn = True
		
		'�r���������
		intRet = AE_Execute_PLSQL_EXCTBZ("D", strMsg)
		If intRet <> 0 Then
			'�r���G���[
			Pot_strMsg = strMsg
			CF_Unlock_EXCTBZ = intRet
			GoTo CF_Unlock_EXCTBZ_Err
		End If
		
		'//��ݻ޸���(�Я�)
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCommitTrans �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraCommitTrans()
		bolTrn = False
		
		CF_Unlock_EXCTBZ = 0
		
		Exit Function
		
CF_Unlock_EXCTBZ_Err: 
		
		'���[���o�b�N
		If bolTrn = True Then
			'//��ݻ޸���(۰��ޯ�)
			'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraRollback �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			clsOra.OraRollback()
		End If
		
	End Function
	' === 20061105 === INSERT E -
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Execute_PLSQL_EXCTBZ
	'   �T�v�F  PL/SQL���s����(�r�����䏈��)
	'   �����F�@Pin_strPRCCASE   : �����P�[�X(C:�`�F�b�N W:�������� D:�폜����)
	'           Pot_strMsg       : �G���[���e
	'   �ߒl�F�@0 : ���� 1 : �r���Ɩ����� 9 : �ُ�
	'   ���l�F  �r������pPL/SQL(PRC_EXCTBZ)�����s����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Execute_PLSQL_EXCTBZ(ByVal Pin_strPRCCASE As String, ByRef Pot_strMsg As String) As Short
		Dim ORATYPE_VARCHAR2 As Object
		Dim ORATYPE_NUMBER As Object
		Dim ORATYPE_CHAR As Object
		Dim ORAPARM_OUTPUT As Object
		Dim ORAPARM_INPUT As Object
		Dim gvstrCLTID As Object
		Dim gvstrOPEID As Object
		
		Dim strSQL As String 'SQL��
		Dim strPara1 As String '���Ұ�1(�S���҃R�[�h)
		Dim strPara2 As String '���Ұ�2(�N���C�A���gID)
		Dim strPara3 As String '���Ұ�3(�����P�[�X)
		Dim strPara4 As String '���Ұ�4(�Ɩ��R�[�h(PGID))
		Dim lngPara5 As Integer '���Ұ�5(���A����)
		Dim lngPara6 As Integer '���Ұ�6(�װ����)
		Dim strPara7 As String '���Ұ�7(�װ���e)
		'UPGRADE_ISSUE: OraParameter �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim param(7) As OraParameter 'PL/SQL�̃o�C���h�ϐ�
		Dim bolRet As Boolean
		
		AE_Execute_PLSQL_EXCTBZ = 9
		
		'��n���ϐ������ݒ�
		'    strPara1 = Inp_Inf.InpTanCd
		'    strPara2 = SSS_CLTID
		'    strPara3 = Pin_strPRCCASE
		'    strPara4 = SSS_PrgId
		'    lngPara5 = 0
		'    lngPara6 = 0
		'    strPara7 = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g gvstrOPEID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strPara1 = gvstrOPEID
		'UPGRADE_WARNING: �I�u�W�F�N�g gvstrCLTID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strPara2 = gvstrCLTID
		strPara3 = Pin_strPRCCASE
		strPara4 = gvstrJOBID
		lngPara5 = 0
		lngPara6 = 0
		strPara7 = ""
		
		Pot_strMsg = ""
		
		'�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Add("P5", lngPara5, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Add("P6", lngPara6, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Add("P7", strPara7, ORAPARM_OUTPUT)
		
		'�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1) = clsOra.OraDatabase.Parameters("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2) = clsOra.OraDatabase.Parameters("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3) = clsOra.OraDatabase.Parameters("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4) = clsOra.OraDatabase.Parameters("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5) = clsOra.OraDatabase.Parameters("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6) = clsOra.OraDatabase.Parameters("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7) = clsOra.OraDatabase.Parameters("P7")
		
		'�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_NUMBER �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_NUMBER �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_VARCHAR2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7).serverType = ORATYPE_VARCHAR2
		
		'PL/SQL�Ăяo��SQL
		strSQL = "BEGIN PRC_EXCTBZ(:P1,:P2,:P3,:P4,:P5,:P6,:P7); End;"
		
		'DB�A�N�Z�X
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraExecute �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Not clsOra.OraExecute(strSQL,  , "AE_Execute_PLSQL_EXCTBZ", gvcstDspMsg) Then
			GoTo AE_Execute_PLSQL_EXCTBZ_END
		End If
		
		'** �߂�l�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara5 = param(5).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara6 = param(6).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(param(7).Value) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strPara7 = param(7).Value
			Pot_strMsg = strPara7
		End If
		
		'�G���[���ݒ�
		gv_Int_OraErr = lngPara6
		gv_Str_OraErrText = strPara7
		
		AE_Execute_PLSQL_EXCTBZ = lngPara5
		
AE_Execute_PLSQL_EXCTBZ_END: 
		'** �p�����^����
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Remove("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Remove("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Remove("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Remove("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Remove("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Remove("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		clsOra.OraDatabase.Parameters.Remove("P7")
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Edit_ErrLog
	'   �T�v�F  �G���[���O�o�͏���
	'   �����F  pin_intErrCd       : �G���[�R�[�h�i�I���N���G���[���ȊO�̓[���j
	'           pin_strErrMsg      : �G���[���b�Z�[�W
	'           pin_strErrLocation : �����ӏ��i�t�@���N�V�������j
	'   �ߒl�F  0 : ���� 9 : �ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Edit_ErrLog(ByVal pin_intErrCd As Short, ByVal pin_strErrMsg As String, ByVal pin_strErrLocation As String) As Short
		
		Dim intRet As Short
		Dim strTime As String
		Dim strDate As String
		
		F_Edit_ErrLog = 9
		
		strTime = ""
		strDate = ""
		
		'�V�X�e�����t�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraGetNowDt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strDate = clsOra.OraGetNowDt(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraGetNowTm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strTime = clsOra.OraGetNowTm()
		
		'�G���[���O��������
		Call CF_Edit_ErrLog(pv_strLOG_PATH, pv_strLOG_NAME, gvstrJOBID, pin_intErrCd, pin_strErrMsg, pin_strErrLocation, strTime, strDate)
		
		F_Edit_ErrLog = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Edit_ErrLog
	'   �T�v�F  �G���[���O�o�͏���
	'   �����F  pin_strLOG_PATH    : �o�̓��O�t�@�C���p�X
	'           pin_strLOG_NAME    : �o�̓��O�t�@�C����
	'           pin_strPrgId       : �o�̓v���O������
	'           pin_intErrCd       : �G���[�R�[�h
	'           pin_strErrMsg      : �G���[���b�Z�[�W
	'           pin_strErrLocation : �����ӏ��i�t�@���N�V�������j
	'           pin_strTime        : ��������
	'           pin_strDate        : �������t
	'   �ߒl�F  0 : ���� 9 : �ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Edit_ErrLog(ByVal pin_strLOG_PATH As String, ByVal pin_strLOG_NAME As String, ByVal pin_strPrgId As String, ByVal pin_intErrCd As Short, ByVal pin_strErrMsg As String, ByVal pin_strErrLocation As String, ByVal pin_strTime As String, ByVal pin_strDate As String) As Short
		
		Dim intFNo As Short
		Dim strCSV As String
		Dim bolOpen As Boolean
		
		On Error GoTo CF_Edit_ErrLog_End
		
		CF_Edit_ErrLog = 9
		bolOpen = False
		
		intFNo = FreeFile
		
		If Right(Trim(pin_strLOG_PATH), 1) <> "\" Then
			pin_strLOG_PATH = Trim(pin_strLOG_PATH) & "\"
		End If
		
		'�t�@�C���I�[�v��
		FileOpen(intFNo, Trim(pin_strLOG_PATH) & Trim(pin_strLOG_NAME), OpenMode.Append)
		bolOpen = True
		
		strCSV = ""
		'�v���O����ID
		strCSV = strCSV & pin_strPrgId & ","
		'�G���[�ԍ�
		strCSV = strCSV & Trim(CStr(pin_intErrCd)) & ","
		'�G���[���e
		strCSV = strCSV & pin_strErrMsg & ","
		'�����ꏊ�i�t�@���N�V���������j
		strCSV = strCSV & pin_strErrLocation & ","
		'������
		strCSV = strCSV & pin_strDate & ","
		'��������
		strCSV = strCSV & pin_strTime
		
		PrintLine(intFNo, strCSV)
		
		CF_Edit_ErrLog = 0
		
CF_Edit_ErrLog_End: 
		
		If bolOpen = True Then
			'�N���[�Y
			FileClose(intFNo)
		End If
		
	End Function
	
	' -- ADD -- 2007/02/08 END
End Module