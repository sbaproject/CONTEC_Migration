Option Strict Off
Option Explicit On
Module NHSNMMKB_FM1
	'
	' �X���b�g��        : ���̃}�j���A���敪�E��ʍ��ڃX���b�g
	' ���j�b�g��        : NHSNMMKB.FM1
	' �L�q��            : Standard Library
	' �쐬���t          : 1995/10/01
	' �g�p�v���O������  : NHSMR01
	'
	' ���l              : 1:����͂���
	'                     9:����͂Ȃ�
	'
	
	Function NHSNMMKB_CheckC(ByRef NHSNMMKB As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSNMMKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(NHSNMMKB) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g NHSNMMKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			NHSNMMKB = "9"
		End If
		Select Case NHSNMMKB
			Case "1", "9"
			Case Else
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSNMMKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				NHSNMMKB = "9"
		End Select
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSNMMKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		NHSNMMKB_CheckC = 0
	End Function
	
	Function NHSNMMKB_InitVal() As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSNMMKB_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		NHSNMMKB_InitVal = "9"
	End Function
End Module