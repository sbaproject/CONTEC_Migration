Option Strict Off
Option Explicit On
Module SRSCNKB_F51
	'
	' �X���b�g��         : �رٽ��ݗv�ۑI���E��ʍ��ڃX���b�g
	' ���j�b�g��         : SRSCNKB.F01
	' �L�q��             : Standard Library
	' �쐬���t           : 2006/05/29
	' �g�p�v���O������   : SOUMT51
	'
	'
	
	Function SRSCNKB_CheckC(ByRef SRSCNKB As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g SRSCNKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SRSCNKB_CheckC = 0
		Select Case SRSCNKB
			Case "1", "9"
			Case Else
				'UPGRADE_WARNING: �I�u�W�F�N�g SRSCNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				SRSCNKB = "1"
		End Select
	End Function
	'
	'Function SRSCNKB_InitVal(ByVal SOUCD, ByVal De_Index As Integer)
	'    If Trim$(SOUCD) = "" Then
	'     SRSCNKB_InitVal = " "
	'    Else
	'     SRSCNKB_InitVal = "1"
	'    End If
	'End Function
	Function SRSCNKB_DerivedC(ByVal SRSCNKB As Object, ByVal SOUCD As Object, ByVal De_Index As Short) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g SOUCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(SOUCD) <> "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g SRSCNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(SRSCNKB) = "" Then
				
				'UPGRADE_WARNING: �I�u�W�F�N�g SRSCNKB_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				SRSCNKB_DerivedC = "1"
			End If
		End If
	End Function
End Module