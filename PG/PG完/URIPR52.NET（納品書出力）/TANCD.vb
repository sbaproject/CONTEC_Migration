Option Strict Off
Option Explicit On
Module TANCD_F55
	'
	' �X���b�g��        : �J�n�E�S���҃R�[�h�E��ʍ��ڃX���b�g
	' ���j�b�g��        : TANCD.F55
	' �L�q��            : DVP_NT40
	' �쐬���t          : 2007/01/11
	' �g�p�v���O������  : URIPR52
	'
	
	Function STTTANCD_InitVal() As Object
		''    '
		''    STTTANCD_InitVal = FillVal("0", LenWid(DB_TANMTA.TANCD))
	End Function
	
	Function TANCD_CheckC(ByVal TANCD As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g TANCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		TANCD_CheckC = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g TANCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(TANCD) = "" Then
            'delete start 20190808 kuwahara
            'Call TANMTA_RClear()
            'delete end 20190808 kuwahara
            '2019.04.18 add start
            DB_TANMTA = Nothing
            '2019.04.18 add end
            Call DP_SSSMAIN_TANNM(-1, DB_TANMTA.TANNM)
            Exit Function
        End If
        'delete start 20190808 kuwahara
        'Call TANMTA_RClear()
        'delete end 20190808 kuwahara
        'UPGRADE_WARNING: �I�u�W�F�N�g TANCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190809 kuwahara
        'Call DB_GetEq(DBN_TANMTA, 1, TANCD & Space(6 - Len(TANCD)), BtrNormal)
        GetRowsCommon("TANMTA", "where TANCD = '" & TANCD & "'")
        'change end 20190809 kuwahara
        If DBSTAT <> 0 Then
            'delete start 20190808 kuwahara
            'Call TANMTA_RClear()
            'delete end 20190808 kuwahara
            Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' ���R�[�h������܂���B
            'UPGRADE_WARNING: �I�u�W�F�N�g TANCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            TANCD_CheckC = -1
            Exit Function
        Else
            If DB_TANMTA.DATKB = "9" Then
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 4) ' �폜�σ��R�[�h�ł��B
				'UPGRADE_WARNING: �I�u�W�F�N�g TANCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				TANCD_CheckC = -1
				Exit Function
			End If
		End If
		Call DP_SSSMAIN_TANNM(-1, DB_TANMTA.TANNM)
		
	End Function
	
	Function TANCD_Slist(ByRef PP As clsPP, ByVal TANCD As Object) As Object
        '
        'UPGRADE_WARNING: �I�u�W�F�N�g TANCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'delete start 20190809 kuwahara
        'DB_PARA(DBN_TANMTA).KeyBuf = TANCD
        'delete end 20190809 kuwahara
        WLSTAN1.ShowDialog()
		WLSTAN1.Close()
        'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g TANCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190809 kuwahara
        'TANCD_Slist = PP.SlistCom
        TANCD_Slist = WLSTAN_RTNCODE
        'change end 20190809 kuwahara
    End Function
End Module