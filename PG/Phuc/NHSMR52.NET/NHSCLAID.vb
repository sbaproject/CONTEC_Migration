Option Strict Off
Option Explicit On
Module NHSCLAID_FM1
	'
	' �X���b�g��        : �[�i�敪�ދ敪�`�E��ʍ��ڃX���b�g
	' ���j�b�g��        : NHSCLAID.FM1
	' �L�q��            : Standard Library
	' �쐬���t          : 1998/10/02
	' �g�p�v���O������  : NHSMR01
	'
	
	Function NHSCLAID_Check(ByVal NHSCLAID As Object, ByVal EX_NHSCLAID As Object, ByVal De_Index As Object) As Object
		'Function NHSCLAID_Check(ByVal NHSCLAID, ByVal De_Index)
		Dim Rtn As Short
		Dim keyVal As String
		'
		Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLAID_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		NHSCLAID_Check = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLAID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(NHSCLAID) = "" Then
            '2019/09/25 DEL START
            'Call CLSMTA_RClear()
            '2019/09/25 DEL END
            'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Call NHSCLAID_Move(De_Index)
            '98/09/26 2�s�ǉ�
            'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Call NHSCLBID_Move(De_Index)
            'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Call NHSCLCID_Move(De_Index)
            'Else 98/09/26 1�s�C��
            'UPGRADE_WARNING: �I�u�W�F�N�g EX_NHSCLAID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLAID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ElseIf NHSCLAID <> EX_NHSCLAID Then
            'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLAID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(RTrim$(NHSCLAID)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            keyVal = RTrim(NHSCLAID) & Space(LenWid(DB_NHSMTA.NHSCLAID) - LenWid(RTrim(NHSCLAID)))
			Call DB_GetEq(DBN_CLSMTA, 1, DB_SYSTBF.CLAKB & keyVal, BtrNormal)
			'98/10/02 1�s�ǉ�
			If DBSTAT = 0 Then Call DB_GetEq(DBN_CLSMTB, 1, SSS_MSTKB.Value & "1" & keyVal, BtrNormal)
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call NHSCLAID_Move(De_Index)
                '98/09/26 3�s�ǉ�
                '2019/09/25 DEL START
                'Call CLSMTA_RClear()
                '2019/09/25 DEL END
                'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Call NHSCLBID_Move(De_Index)
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call NHSCLCID_Move(De_Index)
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLAID_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				NHSCLAID_Check = -1
			End If
		End If
	End Function
	
	Function NHSCLAID_InitVal() As Object
		'
		If SSS_MSTKB.Value <> DB_SYSTBF.MSTKB Then Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(DB_SYSTBF.CLAKB)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(Trim(DB_SYSTBF.CLAKB)) = 0 Then
			Call AE_InOutModeN_SSSMAIN("NHSCLAID", "0000")
		Else
			Call AE_InOutModeN_SSSMAIN("NHSCLAID", "3303")
		End If
	End Function
	
	Sub NHSCLAID_Move(ByVal De As Short)
		'
		Call DP_SSSMAIN_NHSCLAID(De, DB_CLSMTA.CLSID)
		Call DP_SSSMAIN_NHSCLANM(De, DB_CLSMTA.CLSNM)
	End Sub
	
	Function NHSCLAID_Slist(ByRef PP As clsPP) As Object
		'
		Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		WLS_LIST.Text = "���ވꗗ"
		CType(WLS_LIST.Controls("LST"), Object).Items.Clear()
		Call DB_GetGrEq(DBN_CLSMTB, 1, SSS_MSTKB.Value & "1", BtrNormal)
		Do While DBSTAT = 0 And DB_CLSMTB.MSTKB = DB_SYSTBF.MSTKB And DB_CLSMTB.CLSKEYKB = "1"
			Call DB_GetEq(DBN_CLSMTA, 1, DB_SYSTBF.CLAKB & DB_CLSMTB.CLAID, BtrNormal)
			If DBSTAT = 0 Then
				CType(WLS_LIST.Controls("LST"), Object).Items.Add(DB_CLSMTA.CLSID & " " & DB_CLSMTA.CLSNM)
			End If
			Call DB_GetNext(DBN_CLSMTB, BtrNormal)
		Loop 
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSS_WLSLIST_KETA = LenWid(DB_CLSMTA.CLSID)
		WLS_LIST.ShowDialog()
		WLS_LIST.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSCLAID_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		NHSCLAID_Slist = PP.SlistCom
	End Function
End Module