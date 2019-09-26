Option Strict Off
Option Explicit On
Module GYOSHU_F72
	'
	'�X���b�g��      :���i�R�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :GYOSHU.F72
	'�L�q��          :Standard Library
	'�쐬���t        :1996/07/03
	'�g�p�v���O����  :NHSPR52
	'
	
	Function GYOSHU_Check(ByVal GYOSHU As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		Dim MEINMA As String ' 2006.7.17 AZU Add
		Dim wkGYOSHU As String ' 2006.7.18 AZU Add
		
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g GYOSHU_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		GYOSHU_Check = 0
        ' 2006.7.17 AZU Del Start
        '    If Trim$(GYOSHU) = "" Then GYOSHU = ""
        '    Call MEIMTA_RClear
        '    If Trim$(GYOSHU) = "" Then
        '   GYOSHU_Check = -1
        ' 2006.7.17 AZU Del End
        ' 2006.7.17 AZU Add Start
        '2019/09/25 DEL START
        'Call MEIMTA_RClear()
        '2019/09/25 DEL END
        'UPGRADE_WARNING: �I�u�W�F�N�g GYOSHU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(GYOSHU) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DP_SSSMAIN_GYOSHU(De_Index, "")
			'        Call UnLock_Fields
			' GYOSHU_Check = -1
			'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DP_SSSMAIN_GYOSHURN(De_Index, "")
			' 2006.7.17 AZU Add End
			'UPGRADE_WARNING: �I�u�W�F�N�g GYOSHU_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			GYOSHU_Check = -1 '2006.12.26
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g GYOSHU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkGYOSHU = GYOSHU & Space(Len(DB_MEIMTA.MEICDA) - Len(GYOSHU)) & Space(Len(DB_MEIMTA.MEICDB)) ' 2006.7.18 AZU Add
			' Call DB_GetEq(DBN_MEIMTA, 1, GYOSHU, BtrNormal)
			'Call DB_GetEq(DBN_MEIMTA, 2, "1" & "003" & GYOSHU, BtrNormal)   ' 2006.7.17 AZU Add
			Call DB_GetEq(DBN_MEIMTA, 2, "003" & wkGYOSHU, BtrNormal) ' 2006.7.18 AZU Add
			If DBSTAT = 0 Then
				If DB_MEIMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' �폜�σ��R�[�h�ł��B
					'UPGRADE_WARNING: �I�u�W�F�N�g GYOSHU_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					GYOSHU_Check = 1
					'***add-S-tom***
				Else
					If Trim(DB_MEIMTA.MEINMB) = "" Then
						Call Dsp_Prompt("RNOTFOUND", 1) ' �폜���R�[�h�ł��B
						'UPGRADE_WARNING: �I�u�W�F�N�g GYOSHU_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						GYOSHU_Check = -1
					End If
					'***add-E-tom***
				End If
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g GYOSHU_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				GYOSHU_Check = -1
			End If
			' 2006.7.17 AZU Add Start
			'UPGRADE_WARNING: �I�u�W�F�N�g GYOSHU_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If GYOSHU_Check = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g GYOSHU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Trim(GYOSHU) = Trim(DB_MEIMTA.MEICDA) Then
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_GYOSHU(De_Index, Trim(DB_MEIMTA.MEICDA))
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_GYOSHURN(De_Index, Trim(DB_MEIMTA.MEINMA))
				Else
					Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
					'UPGRADE_WARNING: �I�u�W�F�N�g GYOSHU_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					GYOSHU_Check = -1
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_GYOSHURN(De_Index, " ")
				End If
			End If
			' 2006.7.17 AZU Add End
		End If
		' Call SCR_FromMEIMTA(De_Index)
	End Function
	
	Function GYOSHU_Slist(ByRef PP As clsPP, ByVal GYOSHU As Object) As Object
		'
		'WLS_LIST.Caption = "�Ǝ�ꗗ"
		WLS_MEI1.Text = "�Ǝ�ꗗ"
		'WLS_LIST!LST.Clear
		CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
		Call DB_GetGrEq(DBN_MEIMTA, 1, "003", BtrNormal) ' 2006.7.14 FJCL AZU Start
		Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "003"
			If DB_MEIMTA.DATKB <> "9" Then
				'***chg-S-tom***
				'        WLS_MEI1!LST.AddItem LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40)
				If Trim(DB_MEIMTA.MEINMB) <> "" Then
					CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
				End If
				'***chg-S-tom***
			End If
			Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		Loop 
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.KEYCD)
		'DB_PARA(DBN_MEIMTA).KeyNo = 1
		'DB_PARA(DBN_MEIMTA).KeyBuf = GYOSHU
		'WLS_LIST.Show 1
		WLS_MEI1.ShowDialog()
		'Unload WLS_LIST
		WLS_MEI1.Close() ' 2006.7.14 FJCL AZU End
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g GYOSHU_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		GYOSHU_Slist = PP.SlistCom
	End Function
End Module