Option Strict Off
Option Explicit On
Module STTNHSNM_F51
	'
	' �X���b�g��        : �[���於�́E��ʍ��ڃX���b�g
	' ���j�b�g��        : NHSNM.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/17
	' �g�p�v���O������  : NYKPR52
	'
	
	Function STTNHSNM_Derived(ByVal STTNHSNM As Object, ByVal STTNHSCD As Object, ByVal De_Index As Object) As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g STTNHSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(STTNHSCD) = "" Then
			DB_NHSMTA.NHSRN = " "
		Else
			Call DB_GetEq(DBN_NHSMTA, 1, STTNHSCD, BtrNormal)
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g STTNHSNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTNHSNM_Derived = DB_NHSMTA.NHSRN
		
	End Function
	Function STTNHSNM_InitVal(ByVal STTNHSNM As Object, ByVal STTNHSCD As Object, ByVal De_Index As Object) As Object
		'If Trim(DB_NHSMTA.NHSCD) = "" Then
		'UPGRADE_WARNING: �I�u�W�F�N�g STTNHSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(STTNHSCD) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g FillVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			STTNHSNM_InitVal = FillVal(" ", LenWid(DB_NHSMTA.NHSRN))
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g STTNHSNM_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			STTNHSNM_InitVal = DB_NHSMTA.NHSRN
		End If
	End Function
End Module