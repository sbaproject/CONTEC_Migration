Option Strict Off
Option Explicit On
Module HIKKB_F51
	'
	' �X���b�g��         : �����Ώۋ敪�E��ʍ��ڃX���b�g
	' ���j�b�g��         : HIKKB.F51
	' �L�q��             : Standard Library
	' �쐬���t           : 2006/08/28
	' �g�p�v���O������   : SOUMT51
	'
	
	Function HIKKB_CheckC(ByRef HIKKB As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g HIKKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		HIKKB_CheckC = 0
		Select Case HIKKB
			Case "1", "9"
			Case Else
				'UPGRADE_WARNING: �I�u�W�F�N�g HIKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				HIKKB = "1"
		End Select
		
	End Function
	'
	'Function HIKKB_InitVal(ByVal SOUCD, ByVal De_Index As Integer)
	'    If Trim$(SOUCD) = "" Then
	'     HIKKB_InitVal = " "
	'    Else
	'     HIKKB_InitVal = "1"
	'    End If
	'
	'End Function
	Function HIKKB_DerivedC(ByVal HIKKB As Object, ByVal SOUCD As Object, ByVal De_Index As Short) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g SOUCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(SOUCD) <> "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g HIKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(HIKKB) = "" Then
				
				'UPGRADE_WARNING: �I�u�W�F�N�g HIKKB_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				HIKKB_DerivedC = "1"
			End If
		End If
	End Function
End Module