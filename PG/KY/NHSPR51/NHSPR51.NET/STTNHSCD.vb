Option Strict Off
Option Explicit On
Module STTNHSCD_F53
	'
	'�X���b�g��      :�[����R�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :NYUCD.F55
	'�L�q��          :Standard Library
	'�쐬���t        :2006/08/11
	'�g�p�v���O����  :nykpr52
	'
	'
	
	Function STTNHSCD_Check(ByVal STTNHSCD As Object) As Object
		Dim rtn As Short
		Dim wkNHSCD As String
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g STTNHSCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTNHSCD_Check = 0
		Call NHSMTA_RClear()
		'UPGRADE_WARNING: �I�u�W�F�N�g STTNHSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(STTNHSCD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(STTNHSCD) = 0 Or Trim(STTNHSCD) = "" Then
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g STTNHSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkNHSCD = STTNHSCD & Space(Len(DB_NHSMTA.NHSCD) - Len(STTNHSCD))
			Call DB_GetEq(DBN_NHSMTA, 1, wkNHSCD, BtrNormal)
			''''''''If DBSTAT = 0 Then
			''''''''    If DB_NHSMTA.DATKB = "9" Then
			''''''''        Call Dsp_Prompt("RNOTFOUND", 1)         ' �폜�σ��R�[�h�ł��B
			''''''''        STTNHSCD_Check = 1
			''''''''    End If
			''''''''Else
			''''''''    rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
			''''''''    STTNHSCD_Check = -1
			''''''''End If
		End If
		'Call SCR_FromNHSMTA(De_Index)
	End Function
	
	Function STTNHSCD_Slist(ByRef PP As clsPP, ByVal STTNHSCD As Object) As Object
		'
		DB_PARA(DBN_NHSMTA).KeyNo = 1
		'UPGRADE_WARNING: �I�u�W�F�N�g STTNHSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_PARA(DBN_NHSMTA).KeyBuf = STTNHSCD
		WLSNHS.ShowDialog()
		WLSNHS.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g STTNHSCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTNHSCD_Slist = PP.SlistCom
	End Function
	Function STTNHSCD_InitVal(ByVal STTNHSCD As Object) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g STTNHSCD_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTNHSCD_InitVal = " "
		
	End Function
End Module