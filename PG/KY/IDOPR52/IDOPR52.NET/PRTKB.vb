Option Strict Off
Option Explicit On
Module PRTKB_F51
	'
	' �X���b�g��        : �o�̓t���O�E��ʍ��ڃX���b�g
	' ���j�b�g��        : PRTKB.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/22
	' �g�p�v���O������  : URIPR52
	'
	
	Function PRTKB_Check(ByRef PRTKB As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g PRTKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(PRTKB) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g PRTKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PRTKB = "0"
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g PRTKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If PRTKB = "0" Or PRTKB = "1" Or PRTKB = "9" Then
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g PRTKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PRTKB = "0"
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g PRTKB_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PRTKB_Check = 0
		
	End Function
	
	Function PRTKB_InitVal() As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g PRTKB_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PRTKB_InitVal = 0
	End Function
End Module