Option Strict Off
Option Explicit On
Module FRNKB_F71
	'
	' �X���b�g��        : �C�O����敪��ʍ��ڃX���b�g
	' ���j�b�g��        : FRNKB.F71
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/09/22
	' �g�p�v���O������  : NHSMR51
	'
	' ���l              : 0:����
	'                     1:�C�O
	
	Function FRNKB_CheckC(ByRef FRNKB As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g FRNKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		FRNKB_CheckC = 0
		Select Case FRNKB
			Case "0", "1"
			Case Else
				'UPGRADE_WARNING: �I�u�W�F�N�g FRNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				FRNKB = "0"
		End Select
	End Function
	
	Function FRNKB_Derived(ByVal NHSCD As Object) As Object
		
		If FR_SSSMAIN.HD_FRNKB.Text = " " Then
			Call DP_SSSMAIN_FRNKB(0, "0")
			Call AE_InOutModeN_SSSMAIN("FRNKB", "2202")
		End If
		
	End Function
	
	Function FRNKB_InitVal() As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g FRNKB_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		FRNKB_InitVal = "0"
	End Function
End Module