Option Strict Off
Option Explicit On
Module HINKB_F51
	'
	' �X���b�g��        : ���i�敪�敪�E��ʍ��ڃX���b�g
	' ���j�b�g��        : HINJUNKB.FM1
	' �L�q��            : Standard Library
	' �쐬���t          : 1995/10/01
	' �g�p�v���O������  : HINMR01
	'
	' ���l              : 1:���i
	'                     2:���i
	'                     3:���i
	'
	
	Function HINKB_CheckC(ByRef HINKB As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g HINKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(HINKB) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g HINKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			HINKB = "1"
		End If
		Select Case HINKB
			Case "1", "2", "3", "4", "5", "9"
			Case Else
				'UPGRADE_WARNING: �I�u�W�F�N�g HINKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				HINKB = "1"
		End Select
		'UPGRADE_WARNING: �I�u�W�F�N�g HINKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		HINKB_CheckC = 0
	End Function
	
	Function HINKB_InitVal() As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g HINKB_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		HINKB_InitVal = "1"
	End Function
End Module