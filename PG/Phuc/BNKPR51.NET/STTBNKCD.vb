Option Strict Off
Option Explicit On
Module STTBNKCD_F52
	'
	'�X���b�g��      :�q�ɃR�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :SOUCD.F55
	'�L�q��          :Standard Library
	'�쐬���t        :2006/08/11
	'�g�p�v���O����  :nykpr52
	'
	'
	
	Function STTBNKCD_Check(ByVal STTBNKCD As Object) As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g STTBNKCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTBNKCD_Check = 0
        '2019/09/20 DEL START
        'Call BNKMTA_RClear()
        '2019/09/20 DEL START
        'UPGRADE_WARNING: �I�u�W�F�N�g STTBNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(STTBNKCD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If LenWid(STTBNKCD) = 0 Or Trim(STTBNKCD) = "" Then
		Else
			Call DB_GetEq(DBN_BNKMTA, 1, STTBNKCD, BtrNormal)
			''''''''If DBSTAT = 0 Then
			''''''''    If DB_BNKMTA.DATKB = "9" Then
			''''''''        Call Dsp_Prompt("RNOTFOUND", 1)         ' �폜�σ��R�[�h�ł��B
			''''''''        STTBNKCD_Check = 1
			''''''''    End If
			''''''''Else
			''''''''    rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
			''''''''    STTBNKCD_Check = -1
			''''''''End If
		End If
		'Call SCR_FromBNKMTA(De_Index)
	End Function
	
	Function STTBNKCD_Slist(ByRef PP As clsPP, ByVal STTBNKCD As Object) As Object
		'
		DB_PARA(DBN_BNKMTA).KeyNo = 1
		'UPGRADE_WARNING: �I�u�W�F�N�g STTBNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_PARA(DBN_BNKMTA).KeyBuf = STTBNKCD
		WLSBNK.ShowDialog()
		WLSBNK.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g STTBNKCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTBNKCD_Slist = PP.SlistCom
	End Function
	Function STTBNKCD_InitVal(ByVal STTBNKCD As Object) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g STTBNKCD_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTBNKCD_InitVal = " "
		
	End Function
End Module