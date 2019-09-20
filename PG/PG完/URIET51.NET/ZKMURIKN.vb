Option Strict Off
Option Explicit On
Module ZKMURIKN_F01
	'
	' �X���b�g��        : ������z(�ō�)�E��ʍ��ڃX���b�g
	' ���j�b�g��        : ZKMURIKN.F01
	' �L�q��            : Standard Library
	' �쐬���t          : 1995/10/01
	' �g�p�v���O������  : URIET01
	'
	
	'�󒍒P�����󒍐���
	Function ZKMURIKN_Derived(ByVal URIKN As Object, ByVal HINZEIKB As Object, ByVal TOKZEIKB As Object) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g ZKMURIKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ZKMURIKN_Derived = 0
		'    If Trim$(HINZEIKB) = "" Or Not IsNumeric(HINZEIKB) Then Exit Function
		'    If Trim$(TOKZEIKB) = "" Or Not IsNumeric(TOKZEIKB) Then Exit Function
		'UPGRADE_WARNING: �I�u�W�F�N�g HINZEIKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(HINZEIKB) = "" Then Exit Function
		'UPGRADE_WARNING: �I�u�W�F�N�g TOKZEIKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(TOKZEIKB) = "" Then Exit Function
		'UPGRADE_WARNING: �I�u�W�F�N�g URIKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If URIKN = 0 Then Exit Function
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(TOKZEIKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(TOKZEIKB) = 9 Then Exit Function
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(HINZEIKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(HINZEIKB) = 2 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g URIKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g ZKMURIKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ZKMURIKN_Derived = URIKN
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(TOKZEIKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(HINZEIKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ElseIf SSSVal(HINZEIKB) = 0 And SSSVal(TOKZEIKB) = 2 Then 
			'UPGRADE_WARNING: �I�u�W�F�N�g URIKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g ZKMURIKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ZKMURIKN_Derived = URIKN
		End If
	End Function
End Module