Option Strict Off
Option Explicit On
Module STTTANCD_F81
	'
	' �X���b�g��        : �J�n�E�S���҃R�[�h�E��ʍ��ڃX���b�g
	' ���j�b�g��        : STTTANCD.F81
	' �L�q��            : DVP_NT40
	' �쐬���t          : 2007/01/11
	' �g�p�v���O������  : URKPR52 / URKPR62 / UODPR55
	'
	
	Function STTTANCD_InitVal() As Object
		''    '
		''    STTTANCD_InitVal = FillVal("0", LenWid(DB_TANMTA.TANCD))
	End Function
	
	Function STTTANCD_CheckC(ByVal STTTANCD As Object) As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTANCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTTANCD_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTANCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(STTTANCD) = "" Then
            'Call TANMTA_RClear()
            Call DP_SSSMAIN_STTTANNM(-1, DB_TANMTA.TANNM)
			Exit Function
		End If
        '
        'Call TANMTA_RClear()
        'UPGRADE_WARNING: �I�u�W�F�N�g STTTANCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call DB_GetEq(DBN_TANMTA, 1, STTTANCD & Space(6 - Len(STTTANCD)), BtrNormal)
		If DBSTAT <> 0 Then
            'Call TANMTA_RClear()
            rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' ���R�[�h������܂���B
			'UPGRADE_WARNING: �I�u�W�F�N�g STTTANCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			STTTANCD_CheckC = -1
			Exit Function
		Else
			If DB_TANMTA.DATKB = "9" Then
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 4) ' �폜�σ��R�[�h�ł��B
				'UPGRADE_WARNING: �I�u�W�F�N�g STTTANCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				STTTANCD_CheckC = -1
				Exit Function
			End If
		End If
		Call DP_SSSMAIN_STTTANNM(-1, DB_TANMTA.TANNM)
		
	End Function
	
	Function STTTANCD_Slist(ByRef PP As clsPP, ByVal STTTANCD As Object) As Object
		'
		'    If IsNull(STTTANCD) Then
		'        DB_PARA(DBN_TANMTA).KeyBuf = ""
		'     Else
		'        DB_PARA(DBN_TANMTA).KeyBuf = STTTANCD
		'    End If
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTANCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_PARA(DBN_TANMTA).KeyBuf = STTTANCD
		''''WLSTAN.Show 1                               '2007.01.11
		''''Unload WLSTAN                               '2007.01.11
		WLSTAN1.ShowDialog()
		WLSTAN1.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTANCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTTANCD_Slist = PP.SlistCom
	End Function
End Module