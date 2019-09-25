Option Strict Off
Option Explicit On
Module STTHINCD_F55
	'
	' �X���b�g��        : �J�n���i�R�[�h�E��ʍ��ڃX���b�g
	' ���j�b�g��        : STTHINCD.F01
	' �L�q��            : Standard Library
	' �쐬���t          : 1995/10/01
	' �g�p�v���O������  : UODPR02 / SODPR02 / SODPR04 / SYKPR15
	'                     NYKPR15
	'                     TNAPR01 / TNAPR02 / TNAPR03 / TNAPR04 / TNAPR05 / TNAPR06
	'                     CSVPR01 / CSVPR02
	'
	
	Function STTHINCD_Check(ByVal STTHINCD As Object) As Object
		Dim LenWid As Object
		Dim rtn As Short
		Dim wkHINCD As String
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g STTHINCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTHINCD_Check = 0
		Call HINMTA_RClear()
		'UPGRADE_WARNING: �I�u�W�F�N�g STTHINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(STTHINCD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(STTHINCD) = 0 Or Trim(STTHINCD) = "" Then
		Else
			Call DB_GetEq(DBN_HINMTA, 1, STTHINCD, BtrNormal)
			''''''''If DBSTAT = 0 Then
			''''''''    If DB_HINMTA.DATKB = "9" Then
			''''''''        Call Dsp_Prompt("RNOTFOUND", 1)         ' �폜�σ��R�[�h�ł��B
			''''''''        STTHINCD_Check = 1
			''''''''    End If
			''''''''Else
			''''''''    rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
			''''''''    STTHINCD_Check = -1
			''''''''End If
			
		End If
		'Call SCR_FromHINMTA(De_Index)
	End Function
	
	Function STTHINCD_InitVal() As Object
		Dim LenWid As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g FillVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTHINCD_InitVal = FillVal(" ", LenWid(DB_HINMTA.HINCD))
	End Function
	
	Function STTHINCD_Slist(ByRef PP As clsPP, ByVal STTHINCD As Object) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g STTHINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_PARA(DBN_HINMTA).KeyBuf = STTHINCD
		WLSHIN.ShowDialog()
		WLSHIN.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g STTHINCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTHINCD_Slist = PP.SlistCom
	End Function
End Module