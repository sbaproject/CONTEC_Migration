Option Strict Off
Option Explicit On
Module HAKKOU_F51
	'
	' �X���b�g��        : ���s�敪�E��ʍ��ڃX���b�g
	' ���j�b�g��        : HAKKOU.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/07/26
	' �g�p�v���O������  : URIPR52
	'
	
	Function HAKKOU_Check(ByRef HAKKOU As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g HAKKOU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(HAKKOU) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g HAKKOU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			HAKKOU = "1"
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g HAKKOU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If HAKKOU = "0" Or HAKKOU = "1" Then
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g HAKKOU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			HAKKOU = "1"
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g HAKKOU_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		HAKKOU_Check = 0
		
	End Function
	
	Function HAKKOU_InitVal() As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g HAKKOU_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		HAKKOU_InitVal = "1"
	End Function
End Module