Option Strict Off
Option Explicit On
Module Functions
	' @(h) Common Module
	
	' @(s)
	'
	
	' �E�B���h�E�Ƀ��b�Z�[�W�𑗂�֐��̐錾
	'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
	Declare Function SendMessage Lib "user32.dll"  Alias "SendMessageA"(ByVal hWnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, ByRef lParam As Any) As Integer
	
	'API�֐��̐錾
	Private Const WM_KEYDOWN As Short = &H100s
	Private Declare Function PostMessage Lib "user32"  Alias "PostMessageA"(ByVal hWnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
	
	'�R���s���[�^���̒����������萔�̐錾
	Private Const MAX_COMPUTERNAME_LENGTH As Short = 15 + 1
	
	' �R���s���[�^�����擾����֐��̐錾
	Declare Function GetComputerName Lib "kernel32.dll"  Alias "GetComputerNameA"(ByVal lpBuffer As String, ByRef nSize As Integer) As Integer
	
	'***Win32 API��SHFileOperation()�֐��B�t�@�C���V�X�e���I�u�W�F�N�g���R�s�[���܂��B
	'�v���O���X�o�[�t�B
	'�t�@�C������Ɋւ�������`����\����
	Structure SHFILEOPSTRUCT
		Dim hWnd As Integer
		Dim wFunc As Integer
		Dim pFrom As String
		Dim pTo As String
		Dim fFlags As Short
		Dim fAnyOperationsAborted As Integer
		Dim hNameMappings As Integer
		Dim lpszProgressTitle As String
	End Structure
	
	'�ǂ̑�����s�����������萔�̐錾
	Public Const FO_COPY As Integer = &H2
	Public Const FOF_SIMPLEPROGRESS As Integer = &H100
	Public Const FOF_NOCONFIRMATION As Short = &H10s
	
	' ����ʒu����ʂ̈ʒu�Ƀ������u���b�N���ړ�����֐��̐錾
	'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
	'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
	Declare Sub MoveMemory Lib "kernel32.dll"  Alias "RtlMoveMemory"(ByRef Destination As Any, ByRef Source As Any, ByVal Length As Integer)
	
	' SHFILEOPSTRUCT��lpszProgressTitle�܂ł̃T�C�Y
	Public Const FILEOP_SIZE_ABORTED_TO_PROGRESSTITLE As Short = 12
	
	' �t�@�C���𑀍삷��֐��̐錾
	'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
	Declare Function SHFileOperation Lib "shell32.dll"  Alias "SHFileOperationA"(ByRef lpFileOp As Any) As Integer
	
	'API�֐���ShowCursor=�}�E�X�|�C���^������
	Public Declare Function ShowCursor Lib "user32" (ByVal bShow As Integer) As Integer
	'***
	
	' AnsiInstrB �� 2�̕���������� Ansi ������ƁAAnsi �޲Ĉʒu��n���܂��B
	Function AnsiInstrB(ByRef arg1 As Object, ByRef arg2 As Object, Optional ByRef arg3 As Object = Nothing) As Short
		Dim pos As Object
		If IsNumeric(arg1) Then
			'UPGRADE_WARNING: �I�u�W�F�N�g arg1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g arg2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g pos �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pos = AnsiLenB(AnsiLeftB(arg2, arg1))
			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			AnsiInstrB = AnsiInstrB(arg1, AnsiStrConv(arg2, vbFromUnicode), AnsiStrConv(arg3, vbFromUnicode))
		Else
			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			AnsiInstrB = AnsiInstrB(AnsiStrConv(arg1, vbFromUnicode), AnsiStrConv(arg2, vbFromUnicode))
		End If
	End Function
	' AnsiLeftB�ŏ�������O�ɁAANSI ������֕ϊ����A�������ʂ� Unicode �ɖ߂��܂��B
	
	' MidB �ŏ�������O�ɁAANSI ������֕ϊ����A�������ʂ� Unicode �ɖ߂��܂��B
	
	' �ȗ��\�Ȉ������������Ă��������ݒ肵�܂��B
	Function AnsiMidB(ByVal StrArg As String, ByVal arg1 As Integer, Optional ByRef arg2 As Object = Nothing) As String
		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
		If IsNothing(arg2) Then
			'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: MidB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g AnsiStrConv() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AnsiMidB = AnsiStrConv(MidB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
		Else
			'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: MidB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g AnsiStrConv() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AnsiMidB = AnsiStrConv(MidB(AnsiStrConv(StrArg, vbFromUnicode), arg1, arg2), vbUnicode)
		End If
	End Function
	' 16 �ޯĊ��ł́AUnicode <-> Ansi �ϊ��͕s�K�v�Ȃ̂ŁA32 �ޯĂ̎�����
	
	Function AnsiLeftB(ByVal StrArg As String, ByVal arg1 As Integer) As String
		'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: LeftB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g AnsiStrConv() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
	End Function
	
	' AnsiLenB �ŏ�������O�ɁAANSI ������֕ϊ����A�������ʂ� Unicode �ɖ߂��܂��B
	Function AnsiLenB(ByVal StrArg As String) As Integer
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
	End Function
	
	' AnsiRightB�ŏ�������O�ɁAANSI ������֕ϊ����A�������ʂ� Unicode �ɖ߂��܂��B
	Function AnsiRightB(ByVal StrArg As String, ByVal arg1 As Integer) As String
		'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: RightB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g AnsiStrConv() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AnsiRightB = AnsiStrConv(RightB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
	End Function
	
	' StrConv ���Ăяo���܂��B
	Function AnsiStrConv(ByRef StrArg As Object, ByRef flag As Object) As Object
#If Win32 Then
		'UPGRADE_WARNING: �I�u�W�F�N�g flag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g StrArg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AnsiStrConv = StrConv(StrArg, flag)
#Else
		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
		AnsiStrConv = StrArg
#End If
		
	End Function
	
	Public Function AnsiTrimStringByByteCount(ByRef SrcStr As String, ByRef DstCount As Integer, Optional ByRef strRemainString As String = "") As String
		'�T�v�F�S�p���p�܂����Unicode��������A����������Ȃ��悤�Ɏw�肳�ꂽ
		'    : �������Ɋۂ߂��������Ԃ�
		'�����FSrcStr,Input,String,���̕�����
		'�@�@�FDstCount,Input,Long,�ۂ߂�o�C�g��
		'�����F�S�p���p�܂����Unicode��������A����������Ȃ��悤�Ɏw�肳�ꂽ
		'    : �������Ɋۂ߂��������Ԃ�
		Dim DstStr As String
		Dim TmpStr As String
		Dim SrcStrCount As Integer
		Dim i As Integer
		Dim CalcCount As Integer
		Dim TmpCount As Integer
		Dim fmt As String
		
		DstStr = ""
		SrcStrCount = Len(SrcStr)
		CalcCount = 0
		For i = 1 To SrcStrCount
			TmpStr = Mid(SrcStr, i, 1)
			TmpCount = AnsiLenB(TmpStr)
			If CalcCount + TmpCount > DstCount Then
				GoTo AnsiTrimStringByByteCount_End
			Else
				CalcCount = CalcCount + TmpCount
				DstStr = DstStr & TmpStr
			End If
		Next i
AnsiTrimStringByByteCount_End: 
		fmt = "!"
		For i = 1 To DstCount
			fmt = fmt & "@"
		Next 
		DstStr = VB6.Format(DstStr, fmt)
		AnsiTrimStringByByteCount = Trim(DstStr)
		strRemainString = AnsiMidB(SrcStr, CalcCount + 1)
		
	End Function
	
	' Api�֐����g�p���R���s���[�^�����擾����B
	Public Function GP_GetCmpName() As String
		
		Dim strComputerNameBuffer As New VB6.FixedLengthString(MAX_COMPUTERNAME_LENGTH)
		Dim lngComputerNameLength As Integer
		Dim lngResult As Integer
		
		' �R���s���[�^���̒�����ݒ�
		lngComputerNameLength = Len(strComputerNameBuffer.Value)
		' �R���s���[�^�����擾
		lngResult = GetComputerName(strComputerNameBuffer.Value, lngComputerNameLength)
		' �R���s���[�^����\��
		GP_GetCmpName = Left(strComputerNameBuffer.Value, InStr(strComputerNameBuffer.Value, vbNullChar) - 1)
		
	End Function
	
	'********************'********************'********************'
	'***  �z��̏����\�[�g�i�N�C�b�N�\�[�g�j                      ***
	'********************'********************'********************'
	'*�y�֐����z
	'*   SortAsc
	'*�y�����z
	'*   ByRef varData() As Variant = �y���o�́z�z��
	'*   ByVal lngSort_S As Long   = �\�[�g�J�n�Y��
	'*   ByVal lngSort_E As Long   = �\�[�g�I���Y��
	'*�y�߂�l�z
	'*  �Ȃ�
	'*�y�����z
	'*  �N�C�b�N�\�[�g����B
	'********************'********************'********************'
	Public Sub SortAsc(ByRef varData() As Object, ByVal lngSort_S As Integer, ByVal lngSort_E As Integer)
		Dim lngI As Integer
		Dim lngJ As Integer
		Dim varX As Object
		Dim varW As Object
		
		'** �N�C�b�N�\�[�g
		'UPGRADE_WARNING: �I�u�W�F�N�g varData(lngSort_S + lngSort_E \ 2) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g varX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		varX = varData((lngSort_S + lngSort_E) \ 2)
		lngI = lngSort_S
		lngJ = lngSort_E
		
		Do 
			'UPGRADE_WARNING: �I�u�W�F�N�g varX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g varData(lngI) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Do While varData(lngI) < varX
				lngI = lngI + 1
			Loop 
			'UPGRADE_WARNING: �I�u�W�F�N�g varX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g varData(lngJ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Do While varData(lngJ) > varX
				lngJ = lngJ - 1
			Loop 
			If lngI >= lngJ Then
				Exit Do
			End If
			
			'UPGRADE_WARNING: �I�u�W�F�N�g varData(lngI) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g varW �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			varW = varData(lngI)
			'UPGRADE_WARNING: �I�u�W�F�N�g varData(lngJ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g varData(lngI) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			varData(lngI) = varData(lngJ)
			'UPGRADE_WARNING: �I�u�W�F�N�g varW �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g varData(lngJ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			varData(lngJ) = varW
			
			lngI = lngI + 1
			lngJ = lngJ - 1
		Loop 
		If (lngSort_S < lngI - 1) Then
			Call SortAsc(varData, lngSort_S, lngI - 1)
		End If
		If (lngSort_E > lngJ + 1) Then
			Call SortAsc(varData, lngJ + 1, lngSort_E)
		End If
		
	End Sub
	
	'********************'********************'********************'
	'***  �z��̍~���\�[�g�i�N�C�b�N�\�[�g�j                      ***
	'********************'********************'********************'
	'*�y�֐����z
	'*   SortAsc
	'*�y�����z
	'*   ByRef varData() As Variant = �y���o�́z�z��
	'*   ByVal lngSort_S As Long   = �\�[�g�J�n�Y��
	'*   ByVal lngSort_E As Long   = �\�[�g�I���Y��
	'*�y�߂�l�z
	'*  �Ȃ�
	'*�y�����z
	'*  �N�C�b�N�\�[�g����B
	'********************'********************'********************'
	Public Sub SortDesc(ByRef varData() As Object, ByVal lngSort_S As Integer, ByVal lngSort_E As Integer)
		Dim lngI As Integer
		Dim lngJ As Integer
		Dim varX As Object
		Dim varW As Object
		
		'** �N�C�b�N�\�[�g
		'UPGRADE_WARNING: �I�u�W�F�N�g varData(lngSort_S + lngSort_E \ 2) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g varX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		varX = varData((lngSort_S + lngSort_E) \ 2)
		lngI = lngSort_S
		lngJ = lngSort_E
		
		Do 
			'UPGRADE_WARNING: �I�u�W�F�N�g varX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g varData(lngI) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Do While varData(lngI) > varX
				lngI = lngI + 1
			Loop 
			'UPGRADE_WARNING: �I�u�W�F�N�g varX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g varData(lngJ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Do While varData(lngJ) < varX
				lngJ = lngJ - 1
			Loop 
			If lngI >= lngJ Then
				Exit Do
			End If
			
			'UPGRADE_WARNING: �I�u�W�F�N�g varData(lngI) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g varW �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			varW = varData(lngI)
			'UPGRADE_WARNING: �I�u�W�F�N�g varData(lngJ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g varData(lngI) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			varData(lngI) = varData(lngJ)
			'UPGRADE_WARNING: �I�u�W�F�N�g varW �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g varData(lngJ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			varData(lngJ) = varW
			
			lngI = lngI + 1
			lngJ = lngJ - 1
		Loop 
		
		If (lngSort_S < lngI - 1) Then
			Call SortDesc(varData, lngSort_S, lngI - 1)
		End If
		If (lngSort_E > lngJ + 1) Then
			Call SortDesc(varData, lngJ + 1, lngSort_E)
		End If
		
	End Sub
	
	'UPGRADE_NOTE: str �� str_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	Public Function Nz(ByVal var As Object, Optional ByVal str_Renamed As String = "") As Object
		
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(var) = True Then
			If str_Renamed = "" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g Nz �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Nz = ""
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g Nz �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Nz = str_Renamed
			End If
			
		ElseIf Len(var) < 1 Then 
			If str_Renamed = "" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g Nz �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Nz = ""
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g Nz �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Nz = str_Renamed
			End If
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g var �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Nz �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Nz = var
		End If
		
	End Function
	
	Public Function StChk(ByVal strVar As String) As String
		
		Dim strWK As String
		Dim strWk2 As String
		Dim lngIndex As Integer
		Const C_strQut As String = "'"
		
		'�V���O���R�[�e�[�V����1��2�ɒu��������B
		'�I���N����INSERT�y�сAUPDATE���Ɏg�p���Ă��������B
		strWK = vbNullString
		If Len(strVar) > 0 Then
			
			'VB5�ȉ��Ŏg�p����B
			'        For lngIndex = 1 To Len(strVar)
			'            strWk2 = Mid(strVar, lngIndex, 1)
			'            If strWk2 = C_strQut Then
			'                strWK = strWK & strWk2 & C_strQut
			'            Else
			'                strWK = strWK & strWk2
			'            End If
			'        Next lngIndex
			
			'VB6�ȏ�Ŏg�p����B
			strWK = Replace(strVar, "'", "''")
		End If
		
		StChk = strWK
		
	End Function
	
	Public Function DblCChk(ByVal strVar As String) As String
		
		Dim strWK As String
		
		'�_�u���R�[�e�[�V����1��2�ɒu��������B
		'CSV�t�@�C���o�͎��Ɏg�p���Ă��������B
		strWK = vbNullString
		If Len(strVar) > 0 Then
			strWK = Replace(strVar, """", """""")
		End If
		
		DblCChk = strWK
		
	End Function
	
	Public Function NumNull(ByVal strVar As String) As String
		
		'strVar=Null�̏ꍇ�A''��Ԃ��B
		If Trim(strVar) = vbNullString Then
			NumNull = "''"
		Else
			NumNull = strVar
		End If
		
	End Function
	
	'�Ώۓ��̌����̓��t�����߂�
	Public Function MonthEnd(ByVal datDate As Date) As Date
		
		Dim datWK As Date
		
		'�Ώۓ��̍ŏ��̓������߂�B
		datWK = CDate(VB6.Format(datDate, "yyyy/mm") & "/01")
		'�Ώی��̍ŏI�������߂�B
		MonthEnd = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, datWK))
		
	End Function
	
	Public Function GP_AddZero(ByVal dblData As Double, ByVal lngKETA As Integer) As String
		
		Dim strResult As String
		
		'����0��t���Ďw�茅���f�[�^��Ԃ��B
		strResult = Right(New String("0", lngKETA) & dblData, lngKETA)
		
		GP_AddZero = CStr(strResult)
		
	End Function
	
	Public Function GP_AddSpace(ByVal strData As String, ByVal lngKETA As Integer) As String
		
		Dim strResult As String
		
		'���ɃX�y�[�X��t���Ďw�茅���f�[�^��Ԃ��B
		strResult = AnsiRightB(Space(lngKETA) & strData, lngKETA)
		
		GP_AddSpace = strResult
		
	End Function
	
	Public Function GP_�ׂ���(ByVal dblData As Double, ByRef lngKETA As Integer) As String
		
		Dim dblWK As Double
		Dim lnbResult As Integer
		
		'�ׂ���v�Z�B
		dblWK = 10 ^ (lngKETA)
		lnbResult = dblData * dblWK
		
		GP_�ׂ��� = CStr(lnbResult)
		
	End Function
	
	'********************************************************************************
	' @(f)      : Ctrl_send
	'
	' �@�\      : �R���g���[���ړ����ړ�����B
	'
	' �Ԃ�l    :
	'
	' ������    : KeyAscii As Integer
	'
	' ���l      :
	
	Function GP_CtrlSend(ByRef KeyAscii As Short, ByRef frm As System.Windows.Forms.Form) As Object
		If KeyAscii = System.Windows.Forms.Keys.Return Then
			PostMessage(frm.Handle.ToInt32, WM_KEYDOWN, System.Windows.Forms.Keys.Tab, &HF021s)
			KeyAscii = 0
		End If
	End Function
	
	'********************************************************************************
	' @(f)      : CtrlHanten
	'
	' �@�\      : �R���g���[���𔽓]�\������B
	'
	' �Ԃ�l    :
	'
	' ������    : Txt As TextBox : �e�L�X�g�{�b�N�X
	'
	' ���l      :
	
	Public Sub GP_CtrlHanten(ByRef Txt As System.Windows.Forms.TextBox)
		Txt.SelectionStart = 0
		'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		Txt.SelectionLength = LenB(Txt)
	End Sub
	
	Public Function GP_StrLengthTrim(ByVal strValue As String, ByVal lngLen As Integer) As Collection
		Dim lngMOJI As Integer
		Dim lngKETA As Integer
		Dim colWK As Collection
		Dim strValue_WK As String
		
		'���i���̂̕���
		
		strValue_WK = strValue
		colWK = New Collection
		
		lngMOJI = 0
		lngKETA = 0
		
		Do Until lngKETA >= lngLen
			lngMOJI = lngMOJI + 1
			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
			lngKETA = lngKETA + LenB(StrConv(Mid(strValue_WK, lngMOJI, 1), vbFromUnicode))
		Loop 
		
		If lngKETA > lngLen Then
			colWK.Add(Left(strValue_WK, lngMOJI - 1))
			colWK.Add(Mid(strValue_WK, lngMOJI, AnsiLenB(strValue_WK) - (lngMOJI - 1)))
		Else
			colWK.Add(Left(strValue_WK, lngMOJI))
			colWK.Add(Mid(strValue_WK, lngMOJI + 1, AnsiLenB(strValue_WK) - lngMOJI))
		End If
		
	End Function
End Module