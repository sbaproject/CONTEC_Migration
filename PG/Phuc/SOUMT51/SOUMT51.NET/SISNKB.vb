Option Strict Off
Option Explicit On
Module SISNKB_F51
	'
	' �X���b�g��        : ���Y���敪�E��ʍ��ڃX���b�g
	' ���j�b�g��        : SISNKB.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/06/13
	' �g�p�v���O������  : SOUMT51
	'
	
	Function SISNKB_CheckC(ByRef SISNKB As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g SISNKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SISNKB_CheckC = 0
		'
		Select Case SISNKB
			Case "0", "1"
			Case Else
				'UPGRADE_WARNING: �I�u�W�F�N�g SISNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				SISNKB = "0"
		End Select
		'UPGRADE_WARNING: �I�u�W�F�N�g SISNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SISNKB = "1" Then '����
			Call AE_InOutModeN_SSSMAIN("SOUTRICD", "3303")
		Else
			Call AE_InOutModeN_SSSMAIN("SOUTRICD", "2202")
		End If
	End Function
	'
	'Function SISNKB_InitVal(ByVal SOUCD, ByVal De_Index As Integer)
	'    If Trim$(SOUCD) = "" Then
	'     SISNKB_InitVal = " "
	'    Else
	'     SISNKB_InitVal = "0"
	'    End If
	'End Function
	Function SISNKB_DerivedC(ByVal SISNKB As Object, ByVal SOUCD As Object, ByVal De_Index As Short) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g SOUCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(SOUCD) <> "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g SISNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(SISNKB) = "" Then
				
				'UPGRADE_WARNING: �I�u�W�F�N�g SISNKB_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				SISNKB_DerivedC = "0"
			End If
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g SISNKB_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SISNKB_DerivedC = ""
		End If
	End Function
End Module