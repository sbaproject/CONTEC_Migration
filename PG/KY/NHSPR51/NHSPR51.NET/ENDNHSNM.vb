Option Strict Off
Option Explicit On
Module ENDNHSNM_F51
	'
	' �X���b�g��        : �[���於�́E��ʍ��ڃX���b�g
	' ���j�b�g��        : NHSNM.F51
	' �L�q��            : SNHSdard Library
	' �쐬���t          : 2006/08/17
	' �g�p�v���O������  : NYKPR52
	'
	
	Function ENDNHSNM_Derived(ByVal ENDNHSNM As Object, ByVal ENDNHSCD As Object, ByVal De_Index As Object) As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDNHSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(ENDNHSCD) = "" Or ENDNHSCD = "���������" Then
			DB_NHSMTA.NHSRN = " "
		Else
			Call DB_GetEq(DBN_NHSMTA, 1, ENDNHSCD, BtrNormal)
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDNHSNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDNHSNM_Derived = DB_NHSMTA.NHSRN
		
	End Function
	Function ENDNHSNM_InitVal(ByVal ENDNHSNM As Object, ByVal ENDNHSCD As Object, ByVal De_Index As Object) As Object
		'If Trim(DB_NHSMTA.NHSCD) = "" Then
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDNHSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(ENDNHSCD) = "" Or ENDNHSCD = "���������" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g FillVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ENDNHSNM_InitVal = FillVal(" ", LenWid(DB_NHSMTA.NHSRN))
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDNHSNM_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ENDNHSNM_InitVal = DB_NHSMTA.NHSRN
		End If
	End Function
End Module