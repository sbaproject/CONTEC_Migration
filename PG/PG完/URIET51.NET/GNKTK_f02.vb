Option Strict Off
Option Explicit On
Module GNKTK_F02
	'
	' �X���b�g��        : �����P���E��ʍ��ڃX���b�g
	' ���j�b�g��        : GNKTK.F02
	' �L�q��            : Standard Library
	' �쐬���t          : 1998/08/23
	' �g�p�v���O������  : URIET01
	'
	
	Function GNKTK_Derived(ByVal GNKTK As Object, ByRef PP As clsPP, ByVal ENTDT As Object, ByVal HINCD As Object) As Object
		Dim pHINCD As String
		'UPGRADE_WARNING: �I�u�W�F�N�g GNKTK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g GNKTK_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		GNKTK_Derived = GNKTK
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ENTDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(ENTDT) = "" Or Trim(HINCD) = "" Then Exit Function
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pHINCD = CStr(HINCD)
		
		If PP.RecalcMode = True And WG_DSPKB = 1 Then Exit Function
		
		If DB_SYSTBA.GNKHYKKB = "1" Then
			GNKTK_Derived = CALC_GNKTK(pHINCD)
		Else
			If DB_SYSTBA.ZAIHYKKB = "2" Then
				GNKTK_Derived = CALC_GNKTK2(pHINCD, SSS_SMADT.Value)
			ElseIf DB_SYSTBA.ZAIHYKKB = "3" Then 
				GNKTK_Derived = CALC_GNKTK3(pHINCD, SSS_SMADT.Value)
			Else
				GNKTK_Derived = CALC_GNKTK(pHINCD)
			End If
		End If
		
	End Function
End Module