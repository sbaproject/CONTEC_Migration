Option Strict Off
Option Explicit On
Module SOUKB_F51
	'
	' �X���b�g��         : �q�Ɏ�ʑI���E��ʍ��ڃX���b�g
	' ���j�b�g��         : SOUKB.F51
	' �L�q��             : Standard Library
	' �쐬���t           : 2006/05/29
	' �g�p�v���O������   : SOUMT51
	'
	
	Function SOUKB_CheckC(ByRef SOUKB As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g SOUKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SOUKB_CheckC = 0
		Select Case SOUKB
			Case "1", "2"
			Case Else
				'UPGRADE_WARNING: �I�u�W�F�N�g SOUKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				SOUKB = "1"
		End Select
		
	End Function
	'
	'Function SOUKB_InitVal(ByVal SOUCD, ByVal De_Index As Integer)
	'    If Trim$(SOUCD) = "" Then
	'     SOUKB_InitVal = " "
	'    Else
	'     SOUKB_InitVal = "1"
	'    End If
	'
	'End Function
	Function SOUKB_DerivedC(ByVal SOUKB As Object, ByVal SOUCD As Object, ByVal De_Index As Short) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g SOUCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(SOUCD) <> "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g SOUKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(SOUKB) = "" Then
				
				'UPGRADE_WARNING: �I�u�W�F�N�g SOUKB_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				SOUKB_DerivedC = "1"
			End If
		End If
	End Function
End Module