Option Strict Off
Option Explicit On
Module ENDHINNM_F51
	'
	' �X���b�g��        : �q�ɖ��́E��ʍ��ڃX���b�g
	' ���j�b�g��        : ENDHINNM.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/17
	' �g�p�v���O������  : NYKPR52
	'
	
	Function ENDHINNM_Derived(ByVal ENDHINNM As Object, ByVal ENDHINCD As Object, ByVal De_Index As Object) As Object
		
		Call HINMTA_RClear()
		Call DB_GetEq(DBN_HINMTA, 1, ENDHINCD, BtrNormal)
		
		'    If Trim(ENDHINCD) = "" Then
		'       DB_HINMTA.HINNMA = " "
		'    End If
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDHINNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDHINNM_Derived = DB_HINMTA.HINNMA
		
	End Function
	Function ENDHINNM_InitVal(ByVal ENDHINNM As Object, ByVal ENDHINCD As Object, ByVal De_Index As Object) As Object
		'If Trim(DB_HINMTA.ENDHINCD) = "" Then
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDHINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(ENDHINCD) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g FillVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ENDHINNM_InitVal = FillVal(" ", LenWid(DB_HINMTA.HINNMA))
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDHINNM_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ENDHINNM_InitVal = DB_HINMTA.HINNMA
		End If
	End Function
End Module