Option Strict Off
Option Explicit On
Module THSCD_F61
	'
	' �X���b�g��        : ����敪�ށE��ʍ��ڃX���b�g
	' ���j�b�g��        : THSCD.F61
	' �L�q��            : Standard Library
	' �쐬���t          : 2011/02/21
	' �g�p�v���O������  : THSFP61
	'
	
	Function THSCD_Check(ByRef THSCD As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g THSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(THSCD) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g THSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			THSCD = "0"
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g THSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If THSCD = "0" Or THSCD = "1" Or THSCD = "2" Or THSCD = "3" Or THSCD = "9" Then
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g THSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			THSCD = "9"
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g THSCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		THSCD_Check = 0
		
	End Function
	
	Function THSCD_InitVal() As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g THSCD_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		THSCD_InitVal = "9"
	End Function
	
	Public Function FRNKB_Check(ByRef FRNKB As Object) As Short
		'UPGRADE_WARNING: �I�u�W�F�N�g FRNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(FRNKB) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g FRNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			FRNKB = "0"
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g FRNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If FRNKB = "0" Or FRNKB = "1" Or FRNKB = "9" Then
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g FRNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			FRNKB = "9"
		End If
		
		FRNKB_Check = 0
		
	End Function
	
	Function FRNKB_InitVal() As String
		'
		FRNKB_InitVal = "9"
	End Function
End Module