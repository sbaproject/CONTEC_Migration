Option Strict Off
Option Explicit On
Module CHIIKI_F71
	'
	'�X���b�g��      :���i�R�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :CHIIKI.F71
	'�L�q��          :Standard Library
	'�쐬���t        :1996/07/03
	'�g�p�v���O����  :NHSMR52
	'
	
	Function CHIIKI_Check(ByVal CHIIKI As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		Dim MEINMA As String ' 2006.7.17 AZU Add
		Dim wkCHIIKI As String ' 2006.7.18 AZU Add
		
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g CHIIKI_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CHIIKI_Check = 0
		' 2006.7.17 AZU Del Start
		'    If Trim$(CHIIKI) = "" Then CHIIKI = ""
		'    Call MEIMTA_RClear
		'    If Trim$(CHIIKI) = "" Then
		'  CHIIKI_Check = -1
		' 2006.7.17 AZU Del End
		' 2006.7.17 AZU Add Start
		Call MEIMTA_RClear()
		'UPGRADE_WARNING: �I�u�W�F�N�g CHIIKI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(CHIIKI) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DP_SSSMAIN_CHIIKI(De_Index, "")
			'        Call UnLock_Fields
			' GYOSHU_Check = -1
			'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DP_SSSMAIN_CHIIKIRN(De_Index, "")
			' 2006.7.17 AZU Add End
			'UPGRADE_WARNING: �I�u�W�F�N�g CHIIKI_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CHIIKI_Check = -1 '2006.12.26
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CHIIKI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkCHIIKI = CHIIKI & Space(Len(DB_MEIMTA.MEICDA) - Len(CHIIKI)) & Space(Len(DB_MEIMTA.MEICDB)) ' 2006.7.18 AZU Add
			'Call DB_GetEq(DBN_MEIMTA, 1, CHIIKI, BtrNormal)
			'Call DB_GetGrEq(DBN_MEIMTA, 2, "1" & "004" & CHIIKI, BtrNormal)    ' 2006.7.17 AZU Add
			Call DB_GetGrEq(DBN_MEIMTA, 1, "004" & wkCHIIKI, BtrNormal) ' 2006.7.18 AZU Add
			If DBSTAT = 0 Then
				If DB_MEIMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' �폜�σ��R�[�h�ł��B
					'UPGRADE_WARNING: �I�u�W�F�N�g CHIIKI_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					CHIIKI_Check = 1
				End If
			Else
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g CHIIKI_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CHIIKI_Check = -1
			End If
			' 2006.7.17 AZU Add Start
			'UPGRADE_WARNING: �I�u�W�F�N�g CHIIKI_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CHIIKI_Check = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g CHIIKI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Trim(CHIIKI) = Trim(DB_MEIMTA.MEICDA) Then
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_CHIIKI(De_Index, Trim(DB_MEIMTA.MEICDA))
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_CHIIKIRN(De_Index, Trim(DB_MEIMTA.MEINMA))
				Else
					rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
					'UPGRADE_WARNING: �I�u�W�F�N�g CHIIKI_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					CHIIKI_Check = -1
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_CHIIKIRN(De_Index, " ")
				End If
			End If
			' 2006.7.17 AZU Add End
		End If
		'Call SCR_FromMEIMTA(De_Index)
	End Function
	
	Function CHIIKI_Slist(ByRef PP As clsPP, ByVal CHIIKI As Object) As Object
		'
		'WLS_LIST.Caption = "�n��ꗗ"
		WLS_MEI1.Text = "�n��ꗗ"
		'WLS_LIST!LST.Clear
		CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
		Call DB_GetGrEq(DBN_MEIMTA, 1, "004", BtrNormal)
		Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "004"
			If DB_MEIMTA.DATKB <> "9" Then
				CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
			End If
			Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		Loop 
		' 2006.7.17 AZU Mod Start
		'    SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.KEYCD)
		SSS_WLSLIST_KETA = 5
		' 2006.7.17 AZU Mod End
		'DB_PARA(DBN_MEIMTA).KeyNo = 1
		'DB_PARA(DBN_MEIMTA).KeyBuf = CHIIKI
		'WLS_LIST.Show 1
		WLS_MEI1.ShowDialog()
		'Unload WLS_LIST
		WLS_MEI1.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CHIIKI_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CHIIKI_Slist = PP.SlistCom
	End Function
End Module