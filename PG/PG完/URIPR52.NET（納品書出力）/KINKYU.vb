Option Strict Off
Option Explicit On
Module KINKYU_F51
	'
	' �X���b�g��        : �ً}�o�ׁE��ʍ��ڃX���b�g
	' ���j�b�g��        : KINKYU.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/07/26
	' �g�p�v���O������  : URIPR52
	'
	
	Function KINKYU_Check(ByRef KINKYU As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g KINKYU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(KINKYU) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g KINKYU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			KINKYU = "1"
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g KINKYU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If KINKYU = "1" Or KINKYU = "2" Then
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g KINKYU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			KINKYU = "1"
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g KINKYU_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		KINKYU_Check = 0
		
	End Function
	
	Function KINKYU_InitVal() As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g KINKYU_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		KINKYU_InitVal = 1
	End Function
End Module