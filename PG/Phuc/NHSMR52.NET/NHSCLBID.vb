Option Strict Off
Option Explicit On
Module NHSCLBID_FM1
	'
	' �X���b�g��        : �[�i�敪�ދ敪�a�E��ʍ��ڃX���b�g
	' ���j�b�g��        : NHSCLBID.FM1
	' �L�q��            : Standard Library
	' �쐬���t          : 1998/09/26
	' �g�p�v���O������  : NHSMT01
	'
	
	Function NHSCLBID_Check(ByVal NHSCLAID As Object, ByVal NHSCLBID As Object, ByVal EX_NHSCLBID As Object, ByVal De_Index As Object) As Object
		'Function NHSCLBID_Check(ByVal NHSCLAID, ByVal NHSCLBID, ByVal De_Index)
		Dim rtn, keyLen As Short
		Dim keyVal As String
		'
		Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLBID_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		NHSCLBID_Check = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		keyLen = LenWid(DB_CLSMTA.CLSID)
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(NHSCLBID) = "" Then
			Call CLSMTA_RClear()
			'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call NHSCLBID_Move(De_Index)
			'98/09/26 1�s�ǉ�
			'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call NHSCLCID_Move(De_Index)
			'Else 98/09/26 1�s�C��
			'UPGRADE_WARNING: �I�u�W�F�N�g EX_NHSCLBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ElseIf NHSCLBID <> EX_NHSCLBID Then 
			If DB_SYSTBF.OYAKBB = "1" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLAID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				keyVal = CStr(NHSCLAID) & Space(keyLen - LenWid(CStr(NHSCLAID)))
			Else
				keyVal = Space(keyLen)
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DB_GetEq(DBN_CLSMTB, 1, SSS_MSTKB.Value & "2" & keyVal & NHSCLBID, BtrNormal)
			'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DB_GetEq(DBN_CLSMTA, 1, DB_SYSTBF.CLBKB & NHSCLBID, BtrNormal)
			If DB_PARA(DBN_CLSMTA).Status = 0 And DB_PARA(DBN_CLSMTB).Status = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call NHSCLBID_Move(De_Index)
				'98/09/26 2�s�ǉ�
				Call CLSMTA_RClear()
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call NHSCLCID_Move(De_Index)
			Else
				rtn = DSP_MsgBox(SSS_ERROR, "DONTSELECT", 0) ' ���̃R�[�h�͑I���ł��܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLBID_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				NHSCLBID_Check = -1
			End If
		End If
	End Function
	
	Function NHSCLBID_InitVal() As Object
		'
		If SSS_MSTKB.Value <> DB_SYSTBF.MSTKB Then Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(DB_SYSTBF.CLBKB)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(Trim(DB_SYSTBF.CLBKB)) = 0 Then
			Call AE_InOutModeN_SSSMAIN("NHSCLBID", "0000")
		Else
			Call AE_InOutModeN_SSSMAIN("NHSCLBID", "3303")
		End If
	End Function
	
	Sub NHSCLBID_Move(ByVal De As Short)
		'
		Call DP_SSSMAIN_NHSCLBID(De, DB_CLSMTA.CLSID)
		Call DP_SSSMAIN_NHSCLBNM(De, DB_CLSMTA.CLSNM)
	End Sub
	
	Function NHSCLBID_Slist(ByRef PP As clsPP, ByVal NHSCLAID As Object) As Object
		'
		Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		WLS_LIST.Text = "���ވꗗ"
		CType(WLS_LIST.Controls("LST"), Object).Items.Clear()
		Call DB_GetGrEq(DBN_CLSMTB, 1, SSS_MSTKB.Value & "2", BtrNormal)
		If DB_SYSTBF.OYAKBB = "1" Then
			Do While DBSTAT = 0 And DB_CLSMTB.MSTKB = DB_SYSTBF.MSTKB And DB_CLSMTB.CLSKEYKB = "2"
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLAID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If DB_CLSMTB.CLAID = NHSCLAID Then
					'UPGRADE_ISSUE: GoSub �X�e�[�g�����g�̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' ���N���b�N���Ă��������B
					GoSub ReadCLSMTA
				End If
				Call DB_GetNext(DBN_CLSMTB, BtrNormal)
			Loop 
		Else
			Do While DBSTAT = 0 And DB_CLSMTB.MSTKB = DB_SYSTBF.MSTKB And DB_CLSMTB.CLSKEYKB = "2"
				'UPGRADE_ISSUE: GoSub �X�e�[�g�����g�̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' ���N���b�N���Ă��������B
				GoSub ReadCLSMTA
				Call DB_GetNext(DBN_CLSMTB, BtrNormal)
			Loop 
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSS_WLSLIST_KETA = LenWid(DB_CLSMTA.CLSID)
		WLS_LIST.ShowDialog()
		WLS_LIST.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLBID_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		NHSCLBID_Slist = PP.SlistCom
		Exit Function
ReadCLSMTA: 
		Call DB_GetEq(DBN_CLSMTA, 1, DB_SYSTBF.CLBKB & DB_CLSMTB.CLBID, BtrNormal)
		If DBSTAT = 0 Then
			CType(WLS_LIST.Controls("LST"), Object).Items.Add(DB_CLSMTA.CLSID & "  " & DB_CLSMTA.CLSNM)
		End If
		'UPGRADE_WARNING: Return �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		Return 
	End Function
End Module