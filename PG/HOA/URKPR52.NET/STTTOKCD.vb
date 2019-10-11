Option Strict Off
Option Explicit On
Module STTTOKCD_F81
	'
	' �X���b�g��        : �J�n���Ӑ�R�[�h�E��ʍ��ڃX���b�g
	' ���j�b�g��        : STTTOKCD.F81
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/31
	' �g�p�v���O������  : URKPR52
	'
	
	Function STTTOKCD_InitVal() As Object
		''    '
		''    STTTOKCD_InitVal = FillVal("0", LenWid(DB_TOKMTA.TOKCD))
	End Function
	
	Function STTTOKCD_CheckC(ByVal STTTOKCD As Object) As Object
		Dim Rtn As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTTOKCD_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(STTTOKCD) = "" Then
			Call TOKMTA_RClear()
			Call DP_SSSMAIN_STTTOKRN(-1, DB_TOKMTA.TOKRN)
			Exit Function
		End If
		'
		Call TOKMTA_RClear()
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call DB_GetEq(DBN_TOKMTA, 1, STTTOKCD & Space(10 - Len(STTTOKCD)), BtrNormal)
		If DBSTAT <> 0 Then
			Call TOKMTA_RClear()
			'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' ���R�[�h������܂���B
			'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			STTTOKCD_CheckC = -1
			Exit Function
		Else
			If DB_TOKMTA.DATKB = "9" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 4) ' �폜�σ��R�[�h�ł��B
				'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				STTTOKCD_CheckC = -1
				Exit Function
			End If
		End If
		Call DP_SSSMAIN_STTTOKRN(-1, DB_TOKMTA.TOKRN)
	End Function
	
	Function STTTOKCD_Slist(ByRef PP As clsPP, ByVal STTTOKCD As Object) As Object
		'
		'    If IsNull(STTTOKCD) Then
		'        DB_PARA(DBN_TOKMTA).KeyBuf = ""
		'     Else
		'        DB_PARA(DBN_TOKMTA).KeyBuf = STTTOKCD
		'    End If
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_PARA(DBN_TOKMTA).KeyBuf = STTTOKCD
		WLSTOK4.ShowDialog()
		WLSTOK4.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTTOKCD_Slist = PP.SlistCom
	End Function
End Module