Option Strict Off
Option Explicit On
Module NHSCLCID_FM1
	'
	' �X���b�g��        : �[�i�敪�ދ敪�b�E��ʍ��ڃX���b�g
	' ���j�b�g��        : NHSCLCID.FM1
	' �L�q��            : SNHSdard Library
	' �쐬���t          : 1997/05/28
	' �g�p�v���O������  : NHSMR01
	'
	
	Function NHSCLCID_CheckC(ByVal NHSCLAID As Object, ByVal NHSCLBID As Object, ByVal NHSCLCID As Object, ByVal De_Index As Object) As Object
		Dim rtn, keyLen As Short
		Dim keyVal As String
		'
		Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLCID_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		NHSCLCID_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		keyLen = LenWid(DB_CLSMTA.CLSID)
        '
        'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLCID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(NHSCLCID) = "" Then
            '20190821 CHG START
            'Call CLSMTA_RClear()
            '20190821 CHG END
            'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Call NHSCLCID_Move(De_Index)
        Else
            If DB_SYSTBF.OYAKBC = "1" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				keyVal = CStr(NHSCLBID) & Space(keyLen - LenWid(CStr(NHSCLBID)))
				If DB_SYSTBF.OYAKBB = "1" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLAID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					keyVal = CStr(NHSCLAID) & Space(keyLen - LenWid(CStr(NHSCLAID))) & keyVal
				Else
					keyVal = Space(keyLen) & keyVal
				End If
			Else
				keyVal = Space(keyLen) & Space(keyLen)
			End If
			''
			''2001/05/10 ���ނb��L���ɂ���
			''Call DB_GetEq(DBN_CLSMTB, 1, SSS_MSTKB & "3" & keyVal & NHSCLAID, BtrNormal)
			'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLCID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DB_GetEq(DBN_CLSMTB, 1, SSS_MSTKB.Value & "3" & keyVal & NHSCLCID, BtrNormal)
			'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLCID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DB_GetEq(DBN_CLSMTA, 1, DB_SYSTBF.CLCKB & NHSCLCID, BtrNormal)
			If DB_PARA(DBN_CLSMTB).Status = 0 And DB_PARA(DBN_CLSMTA).Status = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call NHSCLCID_Move(De_Index)
			Else
				rtn = DSP_MsgBox(SSS_ERROR, "DONTSELECT", 0) ' ���̃R�[�h�͑I���ł��܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLCID_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				NHSCLCID_CheckC = -1
			End If
		End If
	End Function
	
	Function NHSCLCID_InitVal() As Object
		'
		If SSS_MSTKB.Value <> DB_SYSTBF.MSTKB Then Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(DB_SYSTBF.CLCKB)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(Trim(DB_SYSTBF.CLCKB)) = 0 Then
			Call AE_InOutModeN_SSSMAIN("NHSCLCID", "0000")
		Else
			Call AE_InOutModeN_SSSMAIN("NHSCLCID", "3303")
		End If
	End Function
	
	Sub NHSCLCID_Move(ByVal De As Short)
		'
		Call DP_SSSMAIN_NHSCLCID(De, DB_CLSMTA.CLSID)
		Call DP_SSSMAIN_NHSCLCNM(De, DB_CLSMTA.CLSNM)
	End Sub
	
	Function NHSCLCID_Slist(ByRef PP As clsPP, ByVal NHSCLAID As Object, ByVal NHSCLBID As Object) As Object
		'
		Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		WLS_LIST.Text = "���ވꗗ"
		CType(WLS_LIST.Controls("LST"), Object).Items.Clear()
		Call DB_GetGrEq(DBN_CLSMTB, 1, SSS_MSTKB.Value & "3", BtrNormal)
		If DB_SYSTBF.OYAKBB = "1" And DB_SYSTBF.OYAKBC = "1" Then
			Do While DBSTAT = 0 And DB_CLSMTB.MSTKB = DB_SYSTBF.MSTKB And DB_CLSMTB.CLSKEYKB = "3"
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLAID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If DB_CLSMTB.CLBID = NHSCLBID And DB_CLSMTB.CLAID = NHSCLAID Then
                    'UPGRADE_ISSUE: GoSub �X�e�[�g�����g�̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' ���N���b�N���Ă��������B
                    '20190821 CHG START
                    'GoSub ReadCLSMTA
                    GoTo ReadCLSMTA
                    '20190821 CHG END
                End If
				Call DB_GetNext(DBN_CLSMTB, BtrNormal)
			Loop 
		ElseIf DB_SYSTBF.OYAKBC = "1" Then  'Update 1996 / 5 / 22
			Do While DBSTAT = 0 And DB_CLSMTB.MSTKB = DB_SYSTBF.MSTKB And DB_CLSMTB.CLSKEYKB = "3"
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If DB_CLSMTB.CLBID = NHSCLBID Then
                    'UPGRADE_ISSUE: GoSub �X�e�[�g�����g�̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' ���N���b�N���Ă��������B
                    '20190821 CHG START
                    'GoSub ReadCLSMTA
                    GoTo ReadCLSMTA
                    '20190821 CHG END
                End If
				Call DB_GetNext(DBN_CLSMTB, BtrNormal)
			Loop 
		Else
			Do While DBSTAT = 0 And DB_CLSMTB.MSTKB = DB_SYSTBF.MSTKB And DB_CLSMTB.CLSKEYKB = "3"
                'UPGRADE_ISSUE: GoSub �X�e�[�g�����g�̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' ���N���b�N���Ă��������B
                '20190821 CHG START
                'GoSub ReadCLSMTA
                GoTo ReadCLSMTA
                '20190821 CHG END
                Call DB_GetNext(DBN_CLSMTB, BtrNormal)
			Loop 
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSS_WLSLIST_KETA = LenWid(DB_CLSMTA.CLSID)
		WLS_LIST.ShowDialog()
		WLS_LIST.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLCID_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		NHSCLCID_Slist = PP.SlistCom
		Exit Function
ReadCLSMTA: 
		Call DB_GetEq(DBN_CLSMTA, 1, DB_SYSTBF.CLCKB & DB_CLSMTB.CLCID, BtrNormal)
		If DBSTAT = 0 Then
			CType(WLS_LIST.Controls("LST"), Object).Items.Add(DB_CLSMTA.CLSID & "  " & DB_CLSMTA.CLSNM)
		End If
        'UPGRADE_WARNING: Return �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
        'Return 
    End Function
End Module