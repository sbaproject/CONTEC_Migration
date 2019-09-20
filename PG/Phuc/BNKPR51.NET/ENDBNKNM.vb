Option Strict Off
Option Explicit On
Module ENDBNKNM_F51
	'
	' �X���b�g��        : �q�ɖ��́E��ʍ��ڃX���b�g
	' ���j�b�g��        : SOUNM.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/17
	' �g�p�v���O������  : NYKPR52
	'
	
	Function ENDBNKNM_Derived(ByVal ENDBNKNM As Object, ByVal ENDBNKCD As Object, ByVal De_Index As Object) As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDBNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(ENDBNKCD) = "" Then
			DB_BNKMTA.BNKNM = " "
		Else
			Call DB_GetEq(DBN_BNKMTA, 1, ENDBNKCD, BtrNormal)
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDBNKNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDBNKNM_Derived = Trim(AnsiTrimStringByByteCount(DB_BNKMTA.BNKNM, 30)) & " " & Trim(AnsiTrimStringByByteCount(DB_BNKMTA.STNNM, 20))
		
	End Function
	Function ENDBNKNM_InitVal(ByVal ENDBNKNM As Object, ByVal ENDBNKCD As Object, ByVal De_Index As Object) As Object
		'If Trim(DB_BNKMTA.BNKCD) = "" Then
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDBNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(ENDBNKCD) = "" Then
			''''''''ENDBNKNM_InitVal = FillVal(" ", LenWid(DB_BNKMTA.BNKNM))
			ENDBNKNM_InitVal = Space(50)
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDBNKNM_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ENDBNKNM_InitVal = Trim(AnsiTrimStringByByteCount(DB_BNKMTA.BNKNM, 30)) & " " & Trim(AnsiTrimStringByByteCount(DB_BNKMTA.STNNM, 20))
		End If
	End Function
End Module