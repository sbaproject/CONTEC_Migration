Option Strict Off
Option Explicit On
Module KHNKB_F51
	'
	' �X���b�g��        : ���{�敪�E��ʍ��ڃX���b�g
	' ���j�b�g��        : KHNKB.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/22
	' �g�p�v���O������  : URIPR52
	'
	
	Function KHNKB_Check(ByRef KHNKB As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g KHNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(KHNKB) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g KHNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			KHNKB = "1"
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g KHNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If KHNKB = "1" Or KHNKB = "9" Then
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g KHNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			KHNKB = "1"
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g KHNKB_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		KHNKB_Check = 0
		
	End Function
	
	Function KHNKB_InitVal() As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g KHNKB_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		KHNKB_InitVal = "1"
	End Function
End Module