Option Strict Off
Option Explicit On
Module STTBNKNM_F51
	'
	' �X���b�g��        : �q�ɖ��́E��ʍ��ڃX���b�g
	' ���j�b�g��        : SOUNM.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/17
	' �g�p�v���O������  : NYKPR52
	'
	
	Function STTBNKNM_Derived(ByVal STTBNKNM As Object, ByVal STTBNKCD As Object, ByVal De_Index As Object) As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g STTBNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(STTBNKCD) = "" Then
			DB_BNKMTA.BNKNM = " "
		Else
			Call DB_GetEq(DBN_BNKMTA, 1, STTBNKCD, BtrNormal)
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g STTBNKNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTBNKNM_Derived = Trim(AnsiTrimStringByByteCount(DB_BNKMTA.BNKNM, 30)) & " " & Trim(AnsiTrimStringByByteCount(DB_BNKMTA.STNNM, 20))
		
	End Function
	Function STTBNKNM_InitVal(ByVal STTBNKNM As Object, ByVal STTBNKCD As Object, ByVal De_Index As Object) As Object
		'If Trim(DB_SOUMTA.BNKCD) = "" Then
		'UPGRADE_WARNING: �I�u�W�F�N�g STTBNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(STTBNKCD) = "" Then
			''''''''STTBNKNM_InitVal = FillVal(" ", LenWid(DB_BNKMTA.BNKNM))
			STTBNKNM_InitVal = Space(50)
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g STTBNKNM_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			STTBNKNM_InitVal = Trim(AnsiTrimStringByByteCount(DB_BNKMTA.BNKNM, 30)) & " " & Trim(AnsiTrimStringByByteCount(DB_BNKMTA.STNNM, 20))
		End If
	End Function
End Module