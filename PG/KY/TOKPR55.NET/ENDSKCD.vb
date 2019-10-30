Option Strict Off
Option Explicit On
Module ENDSKCD_F51
	'
	'�X���b�g��      :�d�ؗp���i�Q�R�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :SKCD.F55
	'�L�q��          :Standard Library
	'�쐬���t        :2006/08/11
	'�g�p�v���O����  :nykpr52
	'
	'
	
	Function ENDSKCD_Check(ByVal ENDSKCD As Object, ByVal STTSKCD As Object) As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDSKCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDSKCD_Check = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g STTSKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDSKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If ENDSKCD < STTSKCD Then
			rtn = DSP_MsgBox(SSS_ERROR, "ENDCHECK", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDSKCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ENDSKCD_Check = -1
			Exit Function
		End If

        'Call RNKMTA_RClear()
        'UPGRADE_WARNING: �I�u�W�F�N�g ENDSKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(ENDSKCD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If LenWid(ENDSKCD) = 0 Or Trim(ENDSKCD) = "" Then
		Else
			Call DB_GetEq(DBN_RNKMTA, 1, ENDSKCD, BtrNormal)
			''''''''If DBSTAT = 0 Then
			''''''''    If DB_RNKMTA.DATKB = "9" Then
			''''''''        Call Dsp_Prompt("RNOTFOUND", 1)         ' �폜�σ��R�[�h�ł��B
			''''''''        ENDSKCD_Check = 1
			''''''''    End If
			''''''''Else
			''''''''    rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
			''''''''    ENDSKCD_Check = -1
			''''''''End If
		End If
		'Call SCR_FromRNKMTA(De_Index)
	End Function
	
	Function ENDSKCD_Slist(ByRef PP As clsPP, ByVal ENDSKCD As Object) As Object
		'
		DB_PARA(DBN_RNKMTA).KeyNo = 1
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDSKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_PARA(DBN_RNKMTA).KeyBuf = ENDSKCD
        ''''WLS_MEI1.Show 1
        ''''Unload WLS_MEI1
        ''''ENDSKCD_Slist = PP.SlistCom

        WLS_MEI.Text = "�����N�ꗗ"
        CType(WLS_MEI.Controls("LST"), Object).Items.Clear()
        Call DB_GetGrEq(DBN_MEIMTA, 3, "043", BtrNormal)
		Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "043"
			If DB_MEIMTA.DATKB <> "9" Then
                CType(WLS_MEI.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
            End If
			Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		Loop 
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.MEICDA)
        WLS_MEI.ShowDialog()
        WLS_MEI.Close()
        'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g ENDSKCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ENDSKCD_Slist = PP.SlistCom
		
	End Function
	Function ENDSKCD_InitVal(ByVal ENDSKCD As Object) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDSKCD_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDSKCD_InitVal = "ZZZZ"
		
	End Function
End Module