Option Strict Off
Option Explicit On
Module STTHINNM_F51
	'
	' �X���b�g��        : �q�ɖ��́E��ʍ��ڃX���b�g
	' ���j�b�g��        : STTHINNM.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/17
	' �g�p�v���O������  : NYKPR52
	'
	
	Function STTHINNM_Derived(ByVal STTHINNM As Object, ByVal STTHINCD As Object, ByVal De_Index As Object) As Object
		
		Call HINMTA_RClear()
		Call DB_GetEq(DBN_HINMTA, 1, STTHINCD, BtrNormal)
		
		'    If Trim(STTHINCD) = "" Then
		'       DB_HINMTA.HINNMA = " "
		'    End If
		'UPGRADE_WARNING: �I�u�W�F�N�g STTHINNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTHINNM_Derived = DB_HINMTA.HINNMA
		
	End Function
	Function STTHINNM_InitVal(ByVal STTHINNM As Object, ByVal STTHINCD As Object, ByVal De_Index As Object) As Object
		'If Trim(DB_HINMTA.STTHINCD) = "" Then
		'UPGRADE_WARNING: �I�u�W�F�N�g STTHINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(STTHINCD) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g FillVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			STTHINNM_InitVal = FillVal(" ", LenWid(DB_HINMTA.HINNMA))
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g STTHINNM_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			STTHINNM_InitVal = DB_HINMTA.HINNMA
		End If
	End Function
End Module