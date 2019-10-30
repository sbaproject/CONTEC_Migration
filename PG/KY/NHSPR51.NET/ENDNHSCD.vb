Option Strict Off
Option Explicit On
Module ENDNHSCD_F51
	'
	'�X���b�g��      :�[����R�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :NHSCD.F55
	'�L�q��          :Standard Library
	'�쐬���t        :2006/08/11
	'�g�p�v���O����  :nykpr52
	'
	'
	
	Function ENDNHSCD_Check(ByVal ENDNHSCD As Object, ByVal STTNHSCD As Object) As Object
		Dim rtn As Short
		Dim wkNHSCD As String
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDNHSCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDNHSCD_Check = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g STTNHSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDNHSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If ENDNHSCD < STTNHSCD Then
			rtn = DSP_MsgBox(SSS_ERROR, "ENDCHECK", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDNHSCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ENDNHSCD_Check = -1
			Exit Function
		End If


        '2019/10/14 DEL START
        'Call NHSMTA_RClear()
        '2019/10/14 DEL E N D

        'UPGRADE_WARNING: �I�u�W�F�N�g ENDNHSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(ENDNHSCD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If LenWid(ENDNHSCD) = 0 Or Trim(ENDNHSCD) = "" Or ENDNHSCD = "���������" Then
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDNHSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkNHSCD = ENDNHSCD & Space(Len(DB_NHSMTA.NHSCD) - Len(ENDNHSCD))
			Call DB_GetEq(DBN_NHSMTA, 1, wkNHSCD, BtrNormal)
			''''''''If DBSTAT = 0 Then
			''''''''    If DB_NHSMTA.DATKB = "9" Then
			''''''''        Call Dsp_Prompt("RNOTFOUND", 1)         ' �폜�σ��R�[�h�ł��B
			''''''''        ENDNHSCD_Check = 1
			''''''''    End If
			''''''''Else
			''''''''    rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
			''''''''    ENDNHSCD_Check = -1
			''''''''End If
			
		End If
		'Call SCR_FromNHSMTA(De_Index)
	End Function
	
	Function ENDNHSCD_Slist(ByRef PP As clsPP, ByVal ENDNHSCD As Object) As Object
		'
		DB_PARA(DBN_NHSMTA).KeyNo = 1
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDNHSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_PARA(DBN_NHSMTA).KeyBuf = ENDNHSCD
        '2019/10/14 CHG START
        'WLSNHS.ShowDialog()
        'WLSNHS.Close()
        WLSNHS2.ShowDialog()
        WLSNHS2.Close()
        '2019/10/14 CHG E N D
        'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g ENDNHSCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ENDNHSCD_Slist = PP.SlistCom
	End Function
	Function ENDNHSCD_InitVal(ByVal ENDNHSCD As Object) As Object
		''''ENDNHSCD_InitVal = " "
		''''ENDNHSCD_InitVal = "ZZZZZZZZZ"
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDNHSCD_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDNHSCD_InitVal = "���������"
	End Function
End Module