Option Strict Off
Option Explicit On
Friend Class ClsComn
	'//*****************************************************************************************
	'//*
	'//*�����́�
	'//*    ClsComn.cls
	'//*
	'//*���o�[�W������
	'//*    1.00
	'//*���쐬�ҁ�
	'//*    RISE
	'//*��������
	'//*    ���ʊ֐��N���X
	'//*****************************************************************************************
	'//* CHANGE HISTORY
	'//* Version  |YYYYMMDD|Programmer     |Description
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.00     |20060705|RISE)          |�V�K�쐬
	'//*****************************************************************************************
	'//-----------------------------------------------------------------------------------------
	'// �G���[���b�Z�[�W�p
	'//-----------------------------------------------------------------------------------------
	Private Const cst_�ُ� As String = "���s���G���[�ł��B�V�X�e���S���҂ɘA�����ĉ������B"
	Private Const cst_�ڍ� As String = vbCrLf & vbCrLf & "[ �ڍ� ]" & vbCrLf
	Private Const cst_�Q�l As String = vbCrLf & vbCrLf & "[ �Q�l ]" & vbCrLf
	
	'//-----------------------------------------------------------------------------------------
	'// �G���[�������̊i�[�ϐ�
	'//-----------------------------------------------------------------------------------------
	Private gstrPROCEDURE As String '��ۼ��ެ��
	Private lngLastErrorNo As Integer '�ŏI�װ��
	Private strLastErrorDesc As String '�ŏI�װDescription
	
	'//-----------------------------------------------------------------------------------------
	'// �`�o�h�g�p�錾
	'//-----------------------------------------------------------------------------------------
	'//�v���C�x�[�g�v���O�����t�@�C���̎w��Z�N�V�����̓���̃L�[�̕�����l��ǎ��
	'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    '2019/04/11 CHG START
    'Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    '2019/04/11 CHG E N D

	'//�w�肳�ꂽINI�t�@�C���i�ݒ�t�@�C���A�������t�@�C���j�̎w�肳�ꂽ�L�[�ɒl���������ށi�܂��́A�폜����j
	'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
	'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    '2019/04/11 CHG START
    'Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpString As Any, ByVal lpFileName As String) As Integer
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    '2019/04/11 CHG E N D

	'//�R���s���[�^���擾
	Private Declare Function GetComputerName Lib "kernel32"  Alias "GetComputerNameA"(ByVal Buffer As String, ByRef SIZE As Integer) As Integer
	
	'//�w�肳�ꂽ�N���X���ƃE�B���h�E�������g�b�v���x���E�B���h�E (�e�������Ȃ��E�B���h�E) ��T���܂��B�q�E�B���h�E�͒T���܂���B
	Private Declare Function FindWindow Lib "user32"  Alias "FindWindowA"(ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
	
	'//�ʏ�g���v�����^�ύX
	Private Declare Function SetDefaultPrinter Lib "winspool.drv"  Alias "SetDefaultPrinterA"(ByVal pszPrinter As String) As Integer
	
	'//�r�g�d�k�k�N���֘A�̐錾
	Private Structure STARTUPINFO
		Dim cb As Integer
		Dim lpReserved As String
		Dim lpDesktop As String
		Dim lpTitle As String
		Dim dwX As Integer
		Dim dwY As Integer
		Dim dwXSize As Integer
		Dim dwYSize As Integer
		Dim dwXCountChars As Integer
		Dim dwYCountChars As Integer
		Dim dwFillAttribute As Integer
		Dim dwFlags As Integer
		Dim wShowWindow As Short
		Dim cbReserved2 As Short
		Dim lpReserved2 As Integer
		Dim hStdInput As Integer
		Dim hStdOutput As Integer
		Dim hStdError As Integer
	End Structure
	
	Private Structure PROCESS_INFORMATION
		Dim hProcess As Integer
		Dim hThread As Integer
		Dim dwProcessID As Integer
		Dim dwThreadID As Integer
	End Structure
	
	'UPGRADE_WARNING: �\���� PROCESS_INFORMATION �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	'UPGRADE_WARNING: �\���� STARTUPINFO �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Private Declare Function CreateProcessA Lib "kernel32" (ByVal lpApplicationName As Integer, ByVal lpCommandLine As String, ByVal lpProcessAttributes As Integer, ByVal lpThreadAttributes As Integer, ByVal bInheritHandles As Integer, ByVal dwCreationFlags As Integer, ByVal lpEnvironment As Integer, ByVal lpCurrentDirectory As Integer, ByRef lpStartupInfo As STARTUPINFO, ByRef lpProcessInformation As PROCESS_INFORMATION) As Integer
	
	Private Const NORMAL_PRIORITY_CLASS As Integer = &H20
	Private Const GC_INFINITE2 As Short = -1
	
	Private Declare Function WaitForInputIdle Lib "user32" (ByVal hProcess As Integer, ByVal dwMilliseconds As Integer) As Integer
	
	'//�J���Ă���I�u�W�F�N�g�n���h������܂�
	Private Declare Function CloseHandle Lib "kernel32" (ByVal hObject As Integer) As Integer
	
	'//�A�v���P�[�V�������I���܂őҋ@���܂�
	Private Declare Function WaitForSingleObject Lib "kernel32" (ByVal hHandle As Integer, ByVal dwMilliseconds As Integer) As Integer
	
	'//���̃A�v���P�[�V�����̏I���R�[�h���擾����
	Private Declare Function GetExitCodeProcess Lib "kernel32" (ByVal hProcess As Integer, ByRef lpExitCode As Integer) As Integer
	
	'//�E�B���h�E���A�N�e�B�u�ɂ��܂��B
	Private Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As Integer) As Integer
	
	'//PeekMessage API �֘A
	Private Const WM_KEYFIRST As Short = &H100s
	Private Const WM_KEYLAST As Short = &H108s
	Private Const WM_MOUSEFIRST As Short = &H200s
	Private Const WM_MOUSELAST As Short = &H209s
	Private Const PM_REMOVE As Short = &H1s
	
	Private Structure POINTAPI
		Dim X As Integer
		Dim Y As Integer
	End Structure
	Private Structure MSG
		Dim hwnd As Integer
		Dim message As Integer
		Dim wParam As Integer
		Dim lParam As Integer
		Dim time As Integer
		Dim pt As POINTAPI
	End Structure
	
	'//�X���b�h�̃��b�Z�[�W�L���[�Ƀ��b�Z�[�W�����邩�ǂ������`�F�b�N���A��������΁A�w�肳�ꂽ�\���̂ɂ��̃��b�Z�[�W���i�[���܂��B
	'UPGRADE_WARNING: �\���� MSG �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Private Declare Function PeekMessage Lib "user32"  Alias "PeekMessageA"(ByRef lpmsg As MSG, ByVal hwnd As Integer, ByVal wMsgFilterMin As Integer, ByVal wMsgFilterMax As Integer, ByVal wRemoveMsg As Integer) As Integer
	
	'//���݂̃X���b�h�̎��s���A�w�肳�ꂽ���Ԃ������f���܂�
	Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
	
	Private Const LVM_FIRST As Short = &H1000s
	Private Const LVM_SETCOLUMNORDERARRAY As Integer = (LVM_FIRST + 58)
	Private Const LVM_GETCOLUMNORDERARRAY As Integer = (LVM_FIRST + 59)
	
	'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    '2019/04/11 CHG START
    'Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByRef lParam As Any) As Integer
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByRef lParam As Integer) As Integer
    '2019/04/11 CHG E N D
    '//****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Set_Default_Printer
	'//*
	'//* <�߂�l>     �^                ����
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_InString       String          I             �Ώےl
	'//*
	'//* <��  ��>
	'//*    �ʏ�g���v�����^��ύX����
	'//*****************************************************************************************
	Function Set_Default_Printer(ByVal pm_InString As String) As Object
		
		SetDefaultPrinter(pm_InString)
		
	End Function
	
	'-----------------------------------------------------------
	'�@�֐����@GetIniString
	'�@�@�\�@�@Ini�t�@�C����ǂݍ���
	'�@�����@�@strSection  �F �Z�b�V������
	'�@�@�@�@�@strKey      �F �L�[��
	'�@�@�@�@�@strFileName �F INI�t�@�C����
	'�@�Ԓl�@�@�擾����������
	'�@���l�@�@�Ȃ�
	'-----------------------------------------------------------
	Public Function GetIniString(ByVal strSection As String, ByVal strKey As String, ByVal strFileName As String) As String
		
		Dim lngRet As Integer
#Disable Warning BC40000 ' Type or member is obsolete
		Dim strValue As New VB6.FixedLengthString(255)
#Enable Warning BC40000 ' Type or member is obsolete
		
		' �f�[�^�擾
		'// 2007/08/29 REP STT
		lngRet = GetPrivateProfileString(strSection, strKey, "", strValue.Value, 256, strFileName)
		'   lngRet = GetPrivateProfileString(strSection, strKey, "", strValue, 256, ByVal App.Path & "\" & gvcstJOB_ID & ".ini")
		'// 2007/08/29 REP END
		GetIniString = Left(strValue.Value, InStr(strValue.Value, vbNullChar) - 1)
		
	End Function
	
	'-----------------------------------------------------------
	'�@�֐����@WrtIniString
	'�@�@�\�@�@Ini�t�@�C���ɏ�������
	'�@�����@�@strSection  �F �Z�b�V������
	'�@�@�@�@�@strKey      �F �L�[��
	'�@�@�@�@�@strFileName �F INI�t�@�C����
	'�@�@�@�@�@strValue    �F �l
	'�@�Ԓl�@�@�擾����������
	'�@���l�@�@�Ȃ�
	'-----------------------------------------------------------
	Public Function WrtIniString(ByVal strSection As String, ByVal strKey As String, ByVal strFileName As String, ByVal strValue As String) As Boolean
		
		Dim lngRet As Integer
		
		' �f�[�^������
		lngRet = WritePrivateProfileString(strSection, strKey, strValue, strFileName)
		
		If lngRet = 1 Then
			WrtIniString = True
		Else
			WrtIniString = False
		End If
		
	End Function
	
	'-----------------------------------------------------------
	'  �֐���   GetCurrentMachineName
	'  �@�\�@   ϼݖ��擾
	'  �����@   �Ȃ�
	'  �Ԓl�@   String�^   ϼݖ�
	'  ���l�@   �Ȃ�
	'-----------------------------------------------------------
	Public Function GetCurrentMachineName() As String
		
		Const PROCEDURE As String = "GetCurrentMachineName"
		
#Disable Warning BC40000 ' Type or member is obsolete
		Dim bufMachineName As New VB6.FixedLengthString(128)
#Enable Warning BC40000 ' Type or member is obsolete
		Dim lResult As Integer
		
		On Error GoTo RUNTIME_ERROR
		
		lResult = GetComputerName(bufMachineName.Value, Len(bufMachineName.Value))
		
		GetCurrentMachineName = Ctr_AnsiLeftB(Left(bufMachineName.Value, InStr(bufMachineName.Value, vbNullChar) - 1), 5)
		
		GoTo END_SECTION
		
RUNTIME_ERROR: 
		lngLastErrorNo = Err.Number : strLastErrorDesc = Err.Description
		gstrPROCEDURE = IIf(gstrPROCEDURE = "", PROCEDURE, gstrPROCEDURE)
		Err.Raise(lngLastErrorNo,  , strLastErrorDesc)
		
		Exit Function
		
END_SECTION: 
		Exit Function
		
	End Function
	
	'-----------------------------------------------------------
	'  �֐���   ChkDuplicateInstance
	'  �@�\�@   �d���N�����`�F�b�N����
	'  �����@   strCheckInstanceString (IN) �F �����Ώ�Instance
	'  �Ԓl�@   Boolean   ����(True:�N��exe�Ȃ� False:�N��exe����)
	'  ���l�@   �Ȃ�
	'-----------------------------------------------------------
	Function ChkDuplicateInstance(ByVal strCheckInstanceString As String) As Boolean
		
		On Error GoTo ONERR_STEP
		
		If (FindWindow(vbNullString, strCheckInstanceString) = 0) Then
			ChkDuplicateInstance = True
		Else
			ChkDuplicateInstance = False
		End If
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		Call MsgBox("<Chk_DuplicateInstance> " & vbCrLf & cst_�ُ� & cst_�ڍ� & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		Resume EXIT_STEP
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Ctr_AnsiLeftB
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
	Public Function Ctr_AnsiLeftB(ByVal pm_Value As String, ByVal pm_Len As Integer) As String
		
		'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: LeftB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'Ctr_AnsiLeftB = StrConv(LeftB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)
        Ctr_AnsiLeftB = LeftB(pm_Value, pm_Len)
        '2019/04/11 CHG E N D

		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Ctr_AnsiRightB
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
	Public Function Ctr_AnsiRightB(ByVal pm_Value As String, ByVal pm_Len As Integer) As Object
		
		'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: RightB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'Ctr_AnsiRightB = StrConv(RightB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)
        Ctr_AnsiRightB = RightB(pm_Value, pm_Len)
        '2019/04/11 CHG E N D

		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Ctr_AnsiMidB
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
	Public Function Ctr_AnsiMidB(ByVal pm_Value As String, ByVal pm_Start As Integer, Optional ByVal pm_Len As Integer = 0) As String
		
		Dim Str_Value As String
		
		If pm_Len < 1 Then
			'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: MidB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
            '2019/04/11 CHG START
            'Str_Value = StrConv(MidB(StrConv(pm_Value, vbFromUnicode), pm_Start), vbUnicode)
            Str_Value = MidB(pm_Value, pm_Start)
            '2019/04/11 CHG E N D
        Else
            'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
            'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
            'UPGRADE_ISSUE: MidB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
            '2019/04/11 CHG START
            'Str_Value = StrConv(MidB(StrConv(pm_Value, vbFromUnicode), pm_Start, pm_Len), vbUnicode)
            Str_Value = MidB(pm_Value, pm_Start, pm_Len)
            '2019/04/11 CHG E N D

            '//�S�p�������r���œr�؂��ꍇ�P�������߂ɃJ�b�g����B
            'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
            'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
            '2019/04/11 CHG START
            'If LenB(StrConv(Str_Value, vbFromUnicode)) > pm_Len Then
            If LenB(Str_Value) > pm_Len Then
                '2019/04/11 CHG E N D
                Str_Value = Mid(Str_Value, Len(Str_Value) - 1, 1)
            End If
        End If

        Ctr_AnsiMidB = Str_Value

        Exit Function

    End Function
	
	'//****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Chk_Null
	'//*
	'//* <�߂�l>     �^          ����
	'//*             String      ���ڂ�NULL�`�F�b�N�����Ė߂��ANULL��""�ɂ���
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_InString       Variant          I            Null�����̑Ώےl
	'//*
	'//* <��  ��>
	'//*    �m�t�k�k�l���`�F�b�N���f�[�^(String�^)��߂�
	'//*****************************************************************************************
	Public Function Chk_Null(ByVal pm_InString As Object) As String
		
		On Error GoTo ONERR_STEP
		
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(pm_InString) Then
			Chk_Null = " "
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_InString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Chk_Null = Trim(CStr(pm_InString))
		End If
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		Call MsgBox("<Chk_Null> " & vbCrLf & cst_�ُ� & cst_�ڍ� & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		Resume EXIT_STEP
	End Function
	'//****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Chk_NullN
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Double      ���ڂ�NULL�`�F�b�N�����Ė߂��ANULL��0�ɂ���
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_InString       Variant           I            Null�����̑Ώےl
	'//*
	'//* <��  ��>
	'//*    �m�t�k�k�l���`�F�b�N���f�[�^(String�^)��߂�
	'//*****************************************************************************************
    '2019/04/11 CHG START
    'Public Function Chk_NullN(ByVal pm_InString As Object) As Double
    Public Function Chk_NullN(ByVal pm_InString As Object) As Decimal
        '2019/04/11 CHG E N D

        On Error GoTo ONERR_STEP

        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(pm_InString) Then
            Chk_NullN = 0
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_InString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/11 CHG START
            'Chk_NullN = CDbl(Val(pm_InString))
            Chk_NullN = CDec(Val(pm_InString))
            '2019/04/11 CHG E N D
        End If

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        Call MsgBox("<Chk_NullN> " & vbCrLf & cst_�ُ� & cst_�ڍ� & Err.Description, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
        Resume EXIT_STEP
    End Function
	
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Edt_SQL
	'//*
	'//* <�߂�l>       �^          ����
	'//*                Variant     �ҏW�㕶��
	'//*
	'//* <��  ��>       ���ږ�          �^          I/O     ���e
	'//*                pm_Str_Type     String      I       �����敪
	'//*                                                    (N:���l ,S:����, D0:���t, D6:���t, D8:���t)
	'//*                pm_Val_Char     Variant     I       �Ώە�����
	'//*                pm_bln_TrimMode Boolean     I       �ϊ��Ώە�����Trim���邩�A���Ȃ����̃t���O�i�����l�͂���j
	'//*                pm_bln_Null     Boolean     I       True :"" �̎��́A�߂�l��" " �ɂ���i�����l�j
	'//*                                                    False:"" �̎��́A�߂�l��Null�ɂ���
	'//*
	'//* <��  ��>
	'//*    �n���ꂽ�l���r�p�k���ő���ł��镶���ɕҏW����
	'//*    ��SQL���̃V���O���R�[�e�[�V�����i'�j���i''�j�ɒu�������������Ԃ�
	'//*     �i�၄�u��'��'���v���u��''��''���v�j
	'//*****************************************************************************************
    '2019/04/12 CHG START
    'Function Edt_SQL(ByVal pm_Str_Type As String, ByVal pm_Val_Char As Object, Optional ByVal pm_bln_TrimMode As Boolean = True, Optional ByVal pm_bln_Null As Boolean = True) As Object
    Function Edt_SQL(ByVal pm_Str_Type As String, ByVal pm_Val_Char As String, Optional ByVal pm_bln_TrimMode As Boolean = True, Optional ByVal pm_bln_Null As Boolean = True) As Object
        '2019/04/12 CHG E N D


        Dim Int_Year As Short
        Dim int_Month As Short
        Dim int_Day As Short
        Dim Var_Char As Object

        On Error GoTo ONERR_STEP

        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Val_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If (Trim(pm_Val_Char) = "") Or IsDBNull(pm_Val_Char) Then
            If StrConv(pm_Str_Type, VbStrConv.Uppercase) = "S" Then
                If Not pm_bln_Null Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    Edt_SQL = "Null"
                Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    Edt_SQL = "' '"
                End If
            End If
            GoTo EXIT_STEP
        End If

        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Val_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'If StrConv(pm_Str_Type, VbStrConv.Uppercase) = "N" And pm_Val_Char = 0 Then
        If StrConv(pm_Str_Type, VbStrConv.Uppercase) = "N" And pm_Val_Char = "0" Then
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Edt_SQL = 0
            GoTo EXIT_STEP
        End If

        If pm_bln_TrimMode Then
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Val_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            pm_Val_Char = Trim(pm_Val_Char)
        End If

        Select Case StrConv(pm_Str_Type, VbStrConv.Uppercase)
            Case "S"
                'UPGRADE_ISSUE: GoSub �X�e�[�g�����g�̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' ���N���b�N���Ă��������B
                '2019/04/11 CHG START
                'GoSub Edt_SQL
                pm_Val_Char = GoSubEdtSQL(pm_Val_Char)
                '2019/04/11 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Val_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Var_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Var_Char = Chr(39) & pm_Val_Char & Chr(39)
            Case "N"
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Val_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Var_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Var_Char = CDec(pm_Val_Char)
            Case "D"
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Val_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Var_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Var_Char = Chr(39) & pm_Val_Char & Chr(39)
            Case "D0"
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Val_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Var_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
#Disable Warning BC40000 ' Type or member is obsolete
                Var_Char = Chr(39) & VB6.Format(pm_Val_Char, "yyyy/mm/dd") & Chr(39)
#Enable Warning BC40000 ' Type or member is obsolete
            Case "D6"
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Val_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Int_Year = CShort(Mid(pm_Val_Char, 1, 2))
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Val_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                int_Month = CShort(Mid(pm_Val_Char, 3, 2))
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Val_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                int_Day = CShort(Mid(pm_Val_Char, 5, 2))
                'UPGRADE_WARNING: �I�u�W�F�N�g Var_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
#Disable Warning BC40000 ' Type or member is obsolete
                Var_Char = Chr(39) & VB6.Format(DateSerial(Int_Year, int_Month, int_Day), "yyyy/mm/dd") & Chr(39)
#Enable Warning BC40000 ' Type or member is obsolete
            Case "D8"
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Val_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Int_Year = CShort(Mid(pm_Val_Char, 1, 4))
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Val_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                int_Month = CShort(Mid(pm_Val_Char, 5, 2))
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Val_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                int_Day = CShort(Mid(pm_Val_Char, 7, 2))
                'UPGRADE_WARNING: �I�u�W�F�N�g Var_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
#Disable Warning BC40000 ' Type or member is obsolete
                Var_Char = Chr(39) & VB6.Format(DateSerial(Int_Year, int_Month, int_Day), "yyyy/mm/dd") & Chr(39)
#Enable Warning BC40000 ' Type or member is obsolete
        End Select

        'UPGRADE_WARNING: �I�u�W�F�N�g Var_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Edt_SQL = Var_Char

        GoTo EXIT_STEP
        '-------------------------------------------------------------------------------------------------------
        '2019/04/12 DEL START
        'Edt_SQL:
        '        '//�������
        '        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Val_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        str_Temp = pm_Val_Char
        '        Str_Edit = ""
        '        Int_Start = 1
        '        Int_Find = 0

        '        Int_Find = InStr(str_Temp, LC_SingQuat)
        '        If Int_Find = 0 Then
        '            'UPGRADE_WARNING: Return �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
        '            Return
        '        End If

        '        Do
        '            '//�n���ꂽ�����񂩂�ݸ�ٸ��ð��݂��������A���݂��Ȃ���Δ�����
        '            Int_Find = InStr(str_Temp, LC_SingQuat)
        '            If Int_Find = 0 Then
        '                '//�c��̕�������
        '                Str_Edit = Str_Edit & str_Temp
        '                Exit Do
        '            End If

        '            '//�ݸ�ٸ��ð��݂�t������
        '            Str_Edit = Str_Edit & Left(str_Temp, Int_Find) & LC_SingQuat

        '            '//�����J�n�ʒu���
        '            Int_Start = Int_Find + 1

        '            '//�����J�n�ʒu�ȍ~�̕�������
        '            str_Temp = Mid(str_Temp, Int_Start)
        '        Loop


        '        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Val_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        pm_Val_Char = Str_Edit

        '        'UPGRADE_WARNING: Return �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
        '        Return
        '2019/04/12 DEL E N D
        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        Call MsgBox("<Edt_SQL> " & vbCrLf & cst_�ُ� & cst_�ڍ� & Err.Description, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
        Resume EXIT_STEP
    End Function

    '2019/04/12 ADD START
    Private Function GoSubEdtSQL(ByVal pm_Val_Char As String) As String
        Dim str_Temp As String
        Dim Str_Edit As String
        Dim Int_Start As Short
        Dim Int_Find As Short
        Const LC_SingQuat As String = "'"

        '//�������
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Val_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        str_Temp = pm_Val_Char
        Str_Edit = ""
        Int_Start = 1
        Int_Find = 0

        Int_Find = InStr(str_Temp, LC_SingQuat)
        If Int_Find = 0 Then
            'UPGRADE_WARNING: Return �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
            '2019/04/11 CHG START
            'Return
            Return pm_Val_Char
            '2019/04/11 CHG E N D
        End If

        Do
            '//�n���ꂽ�����񂩂�ݸ�ٸ��ð��݂��������A���݂��Ȃ���Δ�����
            Int_Find = InStr(str_Temp, LC_SingQuat)
            If Int_Find = 0 Then
                '//�c��̕�������
                Str_Edit = Str_Edit & str_Temp
                Exit Do
            End If

            '//�ݸ�ٸ��ð��݂�t������
            Str_Edit = Str_Edit & Left(str_Temp, Int_Find) & LC_SingQuat

            '//�����J�n�ʒu���
            Int_Start = Int_Find + 1

            '//�����J�n�ʒu�ȍ~�̕�������
            str_Temp = Mid(str_Temp, Int_Start)
        Loop


        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Val_Char �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        pm_Val_Char = Str_Edit

        'UPGRADE_WARNING: Return �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'Return
        Return pm_Val_Char
        '2019/04/11 CHG E N D
    End Function
    '2019/04/12 ADD E N D

    '//****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Cnv_DateToNumeric
    '//*
    '//* <�߂�l>     �^          ����
    '//*              Long       ���t��YYYYMMDD�̐��l�^�ŕԂ��i�G���[���F0�j
    '//*
    '//* <��  ��>     ���ږ�             �^              I/O           ���e
    '//*              pm_DDate          Date              I          �ϊ�������t
    '//*
    '//* <��  ��>
    '//*    ���t�^�����l�^�ւ̕ϊ�
    '//*****************************************************************************************
	Function Cnv_DateToNumeric(ByVal pm_DDate As Date) As Integer
		
		On Error GoTo ONERR_STEP
		
		Cnv_DateToNumeric = 0
		
#Disable Warning BC40000 ' Type or member is obsolete
		Cnv_DateToNumeric = CInt(VB6.Format(pm_DDate, "YYYYMMDD"))
#Enable Warning BC40000 ' Type or member is obsolete
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		Call MsgBox("<Cnv_DateToNumeric> " & vbCrLf & cst_�ُ� & cst_�ڍ� & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		Resume EXIT_STEP
	End Function
	
	'//****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Cnv_NumericToDate
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Date        ���t��YYYY/MM/DD�ŕԂ�(�G���[���F�Â����t��"1800/01/01"��Ԃ�)
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*           pm_LonDate           Long              I          �ϊ����鐔�l
	'//*
	'//* <��  ��>
	'//*    ���l�^�����t�^�ւ̕ϊ�
	'//*****************************************************************************************
	Function Cnv_NumericToDate(ByVal pm_LonDate As Integer) As Date
		
		Dim strDate As String '//���t�ҏW�p
		
		On Error GoTo ONERR_STEP
		
#Disable Warning BC40000 ' Type or member is obsolete
		strDate = VB6.Format(pm_LonDate, "00/00/00")
#Enable Warning BC40000 ' Type or member is obsolete
		
		If Not IsDate(strDate) Then
			Cnv_NumericToDate = CDate("1800/01/01") '//�Â����t��Ԃ�
		Else
#Disable Warning BC40000 ' Type or member is obsolete
			Cnv_NumericToDate = CDate(VB6.Format(strDate, "YYYY/MM/DD"))
#Enable Warning BC40000 ' Type or member is obsolete
		End If
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		Call MsgBox("<Cnv_NumericToDate> " & vbCrLf & cst_�ُ� & cst_�ڍ� & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		Resume EXIT_STEP
	End Function
	
	'//****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Ctr_Shell
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Long        0:�����@-1:�N�����s �@1<=:���s�t�@�C�����ʒm���ꂽ�G���[���x��
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_CMD            String            I            ���s�t�@�C����
	'//*              pm_vntFromObj     Variant           I            �t�H�[���I�u�W�F�N�g�i�ȗ��j
	'//*              pm_vntMode        Variant           I            �t�H�[���I�u�W�F�N�g���w�肳�ꂽ�ꍇ�̃t�H�[���̈���
	'//*                                                      (Default) 1:Visible = True  �� Enabled = False
	'//*                                                                2:Visible = True  �� Enabled = True
	'//*                                                                3:Visible = False
	'//*
	'//* <��  ��>
	'//*    �A�v���P�[�V���������s����
	'//*****************************************************************************************
	'//* CHANGE HISTORY
	'//* Version  |YYYYMMDD|Programmer     |Description
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.00     |20021001|RISE)          |�V�K�쐬
	'//*****************************************************************************************
	Public Function Ctr_Shell(ByVal pm_CMD As String, Optional ByRef pm_vntFromObj As Object = Nothing, Optional ByRef pm_vntFormDispMode As Object = 1) As Integer
		
		Dim wkProc As PROCESS_INFORMATION '//PROCESS_INFORMATION�\����
		Dim wkStart As STARTUPINFO '//STARTUPINFO�\����
		Dim wkRet As Integer '//SHELL�̊����̖߂�l
		Dim wkEstr As String '//�G���[����
		Dim wK_I As Short '//�G���[�����̌Œ蕔�̒���
		Dim Wk_Str As String '//�G���[�����ҏW���[�N
		Dim lpmsg As MSG '//MSG �\����
		
		On Error GoTo Ctr_Shell_Error_Handler
		
		'//�����l�ݒ�
		Ctr_Shell = -1
		
		'//STARTUPINFO�\���̂̃N���A
		wkStart.cb = Len(wkStart)
		
		'//SHELL�̎��s
		wkRet = CreateProcessA(0, pm_CMD, 0, 0, 1, NORMAL_PRIORITY_CLASS, 0, 0, wkStart, wkProc)
		
		Call WaitForInputIdle(wkProc.hProcess, GC_INFINITE2)
		Call CloseHandle(wkProc.hThread)
		
		'//�w�肳�ꂽ��ʂ𐧌䂷��
		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
		If Not IsNothing(pm_vntFromObj) Then
			Select Case pm_vntFormDispMode
				
				'//1:Visible = True  �� Enabled = False
				Case 1
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_vntFromObj.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_vntFromObj.Visible = True
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_vntFromObj.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_vntFromObj.Enabled = False
					
					'//2:Visible = True  �� Enabled = true
				Case 2
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_vntFromObj.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_vntFromObj.Visible = True
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_vntFromObj.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_vntFromObj.Enabled = True
					
					'//3:Visible = False
				Case 3
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_vntFromObj.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_vntFromObj.Visible = False
					
					'//��
				Case Else
					'//�������Ȃ�
					
			End Select
		End If
		
		'//SHELL�̊�����҂����킹���A�G���[�R�[�h���擾
		Do 
			'//�^�C���A�E�g�b����1�b�ɂđ҂����킹
			wkRet = WaitForSingleObject(wkProc.hProcess, 1000)
			
			'//�^�C���A�E�g�𔻒肵�A�^�C���A�E�g�łȂ���΃��[�v�E�o
			If wkRet <> 258 Then
				Exit Do
			End If
			
			'//�^�C���A�E�g���A�w�肳�ꂽ��ʂ����t���b�V������B
			'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
			If Not IsNothing(pm_vntFromObj) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_vntFormDispMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If pm_vntFormDispMode = 1 Or pm_vntFormDispMode = 2 Then
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_vntFromObj.Refresh �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_vntFromObj.Refresh()
				End If
			End If
			
		Loop 
		Call GetExitCodeProcess(wkProc.hProcess, wkRet)
		Call CloseHandle(wkProc.hProcess)
		
		'//����
		If wkRet = 0 Then '//����
			Ctr_Shell = 0
			GoTo EXIT_STEP
		End If
		
		If wkRet = -1 Then '//�Ăяo���G���[
			Ctr_Shell = -1
			GoTo EXIT_STEP
		End If
		
		If wkRet > 0 Then '//�G���[
			Ctr_Shell = wkRet
			GoTo EXIT_STEP
		End If
		
EXIT_STEP: 
		
		'//�w�肳�ꂽ��ʂ𐧌䂷��
		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
		If Not IsNothing(pm_vntFromObj) Then
			Select Case pm_vntFormDispMode
				
				'//1:Visible = True  �� Enabled = False
				Case 1
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_vntFromObj.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_vntFromObj.Enabled = True
					
					'//2:Visible = True  �� Enabled = true
				Case 2
					'//�������Ȃ�
					
					'//3:Visible = False
				Case 3
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_vntFromObj.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_vntFromObj.Visible = True
					
					'//��
				Case Else
					'//�������Ȃ�
					
			End Select
			
			'//�L�[�{�[�h�ƃ}�E�X�̃L�[�o�b�t�@���N���A�[����
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_vntFromObj.hwnd �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Do Until 0 = PeekMessage(lpmsg, pm_vntFromObj.hwnd, WM_KEYFIRST, WM_KEYLAST, PM_REMOVE)
			Loop 
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_vntFromObj.hwnd �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Do Until 0 = PeekMessage(lpmsg, pm_vntFromObj.hwnd, WM_MOUSEFIRST, WM_MOUSELAST, PM_REMOVE)
			Loop 
			
			'//�E�C���h�E���A�N�e�B�u�ɂ���
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_vntFromObj.hwnd �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SetForegroundWindow(pm_vntFromObj.hwnd)
			
		End If
		
		On Error GoTo 0
		Exit Function
		
Ctr_Shell_Error_Handler: 
		
		Ctr_Shell = -1
		Resume EXIT_STEP
		
	End Function
	
	'//****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Get_TextLength
	'//*
	'//* <�߂�l>     �^                ����
	'//*              Integer           �o�C�g��
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_InString       String          I             �Ώےl
	'//*
	'//* <��  ��>
	'//*    �e�L�X�g���ڂ̃o�C�g�����v�Z����
	'//*****************************************************************************************
	Function Get_TextLength(ByVal pm_InString As String) As Short
		
		'//�������t�m�h�b�n�c�d����ϊ�������A�o�C�g�v�Z
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'Get_TextLength = LenB(StrConv(pm_InString, vbFromUnicode))
        Get_TextLength = LenB(pm_InString)
        '2019/04/11 CHG E N D

	End Function
	
	'//****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Ctr_WaitTime
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean     False�F���s�ATrue�F����I��
	'//*
	'//* <��  ��>     ���ږ�             �^          I/O    ���e
	'//*              pm_Wsec           Integer     I      �����Ŏw�肵�����ԁi�b�j�����҂�
	'//*
	'//* <��  ��>
	'//*    ���ԑ҂����[�`���i�b�j
	'//*****************************************************************************************
	Function Ctr_WaitTime(ByVal pm_Wsec As Short) As Boolean
		
		Dim LonMin As Integer '//�w��b��
		
		Ctr_WaitTime = False
		
		LonMin = pm_Wsec * 1000 '//Sleep�̓~���b�P�ʂȂ̂ŕϊ�����
		Sleep((LonMin))
		
		Ctr_WaitTime = True
		
	End Function
	
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Chg_NumericRound
	'//*
	'//* <�߂�l>       �^          ����
	'//*                Currency   �[����������
	'//*
	'//* <��  ��>       ���ږ�          �^          I/O     ���e
	'//*                pmd_INNUM       Currency    I       �Ώۃf�[�^
	'//*                pmi_DISIT       Integer     I       �Ώۏ����_�ʒu�@1:��P�ʁ@  2:��Q�ʁ@  3:��R�ʁ@  4:��S��
	'//*                pmi_SYORIKBN    Integer     I       �����敪�@�@�@  1:�؂�グ  2:�؂�̂�  3:�l�̌ܓ�
	'//*
	'//* <��  ��>
	'//*    ���l�[���������s��
	'//*****************************************************************************************
	Function Chg_NumericRound(ByVal pmd_INNUM As Decimal, ByVal pmi_DISIT As Short, ByVal pmi_SYORIKBN As Short) As Decimal
		
		Dim s_INNUM As String '//������ɕϊ��������l
		Dim i_POSITION As Short '//�����_�̐擪����̈ʒu
		Dim i_LENGTH As Short '//������̕�����
		Dim d_KIRIAGE As Decimal '//�؂�グ�����Z��
		
		'//�������鐔�l�𕶎���ɕϊ�����
#Disable Warning BC40000 ' Type or member is obsolete
		s_INNUM = VB6.Format(Trim(Str(pmd_INNUM)), "0.0000")
#Enable Warning BC40000 ' Type or member is obsolete
		
		'//�����_�̐擪����̈ʒu���擾
		i_POSITION = InStr(1, s_INNUM, ".", 0)
		
		'//���l(������)���p�����[�^�Ŏw�肳�ꂽ���ʒu�܂Ő؂�Ƃ�
		Select Case pmi_DISIT
			'//�����_��P��
			Case 1
				s_INNUM = Mid(s_INNUM, 1, i_POSITION + 1)
				d_KIRIAGE = 1
				
				'//�����_��Q��
			Case 2
				s_INNUM = Mid(s_INNUM, 1, i_POSITION + 2)
				d_KIRIAGE = 0.1
				
				'//�����_��R��
			Case 3
				s_INNUM = Mid(s_INNUM, 1, i_POSITION + 3)
				d_KIRIAGE = 0.01
				
				'//�����_��S��
			Case 4
				s_INNUM = Mid(s_INNUM, 1, i_POSITION + 4)
				d_KIRIAGE = 0.001
		End Select
		
		'//�������擾
		i_LENGTH = Len(s_INNUM)
		
		'//�p�����[�^�̏����敪��,���l�̉E�[�̂P������������
		Select Case pmi_SYORIKBN
			'//�؂�グ
			Case 1
				If Val(Right(s_INNUM, 1)) > 0 Then
					If Left(s_INNUM, 1) = "-" Then
						Chg_NumericRound = CDec(Left(s_INNUM, i_LENGTH - 1)) - d_KIRIAGE
					Else
						Chg_NumericRound = CDec(Left(s_INNUM, i_LENGTH - 1)) + d_KIRIAGE
					End If
				Else
					Chg_NumericRound = CDec(Left(s_INNUM, i_LENGTH - 1))
				End If
				
				'//�؂�̂�
			Case 2
				Chg_NumericRound = CDec(Left(s_INNUM, i_LENGTH - 1))
				
				'//�l�̌ܓ�
			Case 3
				If Val(Right(s_INNUM, 1)) > 4 Then
					If Left(s_INNUM, 1) = "-" Then
						Chg_NumericRound = CDec(Left(s_INNUM, i_LENGTH - 1)) - d_KIRIAGE
					Else
						Chg_NumericRound = CDec(Left(s_INNUM, i_LENGTH - 1)) + d_KIRIAGE
					End If
				Else
					Chg_NumericRound = CDec(Left(s_INNUM, i_LENGTH - 1))
				End If
		End Select
		
	End Function

    '2019/04/11 CHG START
    'Public Sub SetCol_Order(ByVal parLV As System.Windows.Forms.Control)
    Public Sub SetCol_Order(ByVal parLV As ListView)
        '2019/04/11 CHG E N D
        Dim wCNT As Integer

        'UPGRADE_WARNING: �I�u�W�F�N�g parLV.ColumnHeaders �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'wCNT = parLV.ColumnHeaders.Count
        wCNT = parLV.Columns.Count
        '2019/04/11 CHG E N D

        Call SendMessage(parLV.Handle.ToInt32, LVM_SETCOLUMNORDERARRAY, wCNT, LV_Col_Order(0))

    End Sub
    '2019/04/11 CHG START
    'Public Sub GetCol_Order(ByVal parLV As System.Windows.Forms.Control)
    Public Sub GetCol_Order(ByVal parLV As ListView)
        '2019/04/11 CHG E N D
        Dim wCNT As Integer

        'UPGRADE_WARNING: �I�u�W�F�N�g parLV.ColumnHeaders �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'wCNT = parLV.ColumnHeaders.Count
        wCNT = parLV.Columns.Count
        '2019/04/11 CHG E N D

        ReDim LV_Col_Order(wCNT - 1)

        Call SendMessage(parLV.Handle.ToInt32, LVM_GETCOLUMNORDERARRAY, wCNT, LV_Col_Order(0))

    End Sub
	Public Sub Mouse_ON()
		'REMARK
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
	End Sub
	Public Sub Mouse_OFF()
		'REMARK
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
	End Sub
End Class