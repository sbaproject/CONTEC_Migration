Option Strict Off
Option Explicit On
Module WRKKB_F51
	'
	' �X���b�g��        : �����敪�E��ʍ��ڃX���b�g
	' ���j�b�g��        : WRKKB.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/07/16
	' �g�p�v���O������  : SYKET51
	'
	Dim NotFirst As Short
	
	Function WRKKB_CheckC(ByRef WRKKB As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g WRKKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WRKKB_CheckC = 0
		'
		Select Case WRKKB
			Case "1"
				'UPGRADE_WARNING: �I�u�W�F�N�g WRKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WRKKB = "1"
			Case "2"
				'UPGRADE_WARNING: �I�u�W�F�N�g WRKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WRKKB = "2"
			Case "3"
				'UPGRADE_WARNING: �I�u�W�F�N�g WRKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WRKKB = "3"
			Case "4"
				'UPGRADE_WARNING: �I�u�W�F�N�g WRKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WRKKB = "4"
			Case "5"
				'UPGRADE_WARNING: �I�u�W�F�N�g WRKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WRKKB = "5"
			Case "6"
				'UPGRADE_WARNING: �I�u�W�F�N�g WRKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WRKKB = "6"
			Case Else
				'UPGRADE_WARNING: �I�u�W�F�N�g WRKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WRKKB = "1"
		End Select
		'UPGRADE_WARNING: �I�u�W�F�N�g WRKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WG_WRKKB = WRKKB
	End Function
	
	Function WRKKB_InitVal(ByVal WRKKB As Object) As Object
		'
		If NotFirst = False Then
			NotFirst = True
			'UPGRADE_WARNING: �I�u�W�F�N�g WRKKB_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WRKKB_InitVal = "1"
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g WRKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g WRKKB_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WRKKB_InitVal = WRKKB
		End If
		
	End Function
End Module