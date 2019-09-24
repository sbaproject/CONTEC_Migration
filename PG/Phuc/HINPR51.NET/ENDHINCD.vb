Option Strict Off
Option Explicit On
Module ENDHINCD_F53
	'
	' �X���b�g��        : �I���E���i�R�[�h�E��ʍ��ڃX���b�g
	' ���j�b�g��        : ENDHINCD.F01
	' �L�q��            : Standard Library
	' �쐬���t          : 1998/05/01
	' �g�p�v���O������  : UODPR02 / SODPR02 / SODPR04 / SYKPR15
	'                     NYKPR15
	'                     TNAPR01 / TNAPR02 / TNAPR03 / TNAPR04 / TNAPR05 / TNAPR06
	'                     CSVPR01 / CSVPR02
	'
	
	Function ENDHINCD_Check(ByVal ENDHINCD As Object, ByVal STTHINCD As Object) As Object
		Dim LenWid As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDHINCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDHINCD_Check = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g STTHINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDHINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If ENDHINCD < STTHINCD Then
			rtn = DSP_MsgBox(SSS_ERROR, "ENDCHECK", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDHINCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ENDHINCD_Check = -1
			Exit Function
		End If
		
		Call HINMTA_RClear()
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDHINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(ENDHINCD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(ENDHINCD) = 0 Or Trim(ENDHINCD) = "" Or ENDHINCD = "ZZZZZZZZ" Then
		Else
			Call DB_GetEq(DBN_HINMTA, 1, ENDHINCD, BtrNormal)
			''''''''If DBSTAT = 0 Then
			''''''''    If DB_HINMTA.DATKB = "9" Then
			''''''''        Call Dsp_Prompt("RNOTFOUND", 1)         ' �폜�σ��R�[�h�ł��B
			''''''''        ENDHINCD_Check = -1
			''''''''    End If
			''''''''Else
			''''''''    rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
			''''''''    ENDHINCD_Check = -1
			''''''''End If
		End If
		
	End Function
	
	Function ENDHINCD_InitVal(ByVal ENDHINCD As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDHINCD_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDHINCD_InitVal = "ZZZZZZZZ"
	End Function
	
	
	Function ENDHINCD_Slist(ByRef PP As clsPP, ByVal STTHINCD As Object) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g STTHINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_PARA(DBN_HINMTA).KeyBuf = STTHINCD
		WLSHIN.ShowDialog()
		WLSHIN.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDHINCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDHINCD_Slist = PP.SlistCom
	End Function
End Module