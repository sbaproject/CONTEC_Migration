Option Strict Off
Option Explicit On
Module PRTSB_F51
	'
	' �X���b�g��        : �o�͋敪�E��ʍ��ڃX���b�g
	' ���j�b�g��        : PRTSB.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/22
	' �g�p�v���O������  : URIPR52
	'
	
	Function PRTSB_Check(ByRef PRTSB As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g PRTSB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(PRTSB) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g PRTSB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PRTSB = "1"
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g PRTSB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If PRTSB = "1" Or PRTSB = "2" Then
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g PRTSB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PRTSB = "1"
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g PRTSB_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PRTSB_Check = 0
		
	End Function
	
	Function PRTSB_InitVal() As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g PRTSB_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PRTSB_InitVal = "1"
	End Function
End Module