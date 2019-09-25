Option Strict Off
Option Explicit On
Module BINCD_F71
	'
	'�X���b�g��      :���i�R�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :BINCD.F01
	'�L�q��          :Standard Library
	'�쐬���t        :2006/07/23
	'�g�p�v���O����  :NHSFR52
	'
	
	Function BINCD_Check(ByVal BINCD As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		Dim MEINMA As String
		Dim wkBINCD As String ' 2006.7.18 AZU Add
		
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g BINCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		BINCD_Check = 0
		
		'UPGRADE_WARNING: �I�u�W�F�N�g BINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(BINCD) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g BINCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			BINCD_Check = -1
			Exit Function
		End If
		
		Call MEIMTA_RClear()
		'UPGRADE_WARNING: �I�u�W�F�N�g BINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(BINCD) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DP_SSSMAIN_BINCD(De_Index, "")
			'        Call UnLock_Fields
			' BINCD_Check = -1
			'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DP_SSSMAIN_BINRN(De_Index, " ")
			
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g BINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkBINCD = BINCD & Space(Len(DB_MEIMTA.MEICDA) - Len(BINCD)) & Space(Len(DB_MEIMTA.MEICDB)) ' 2006.7.18 AZU Add
			'Call DB_GetGrEq(DBN_MEIMTA, 2, "1" & "002" & BINCD, BtrNormal)
			Call DB_GetGrEq(DBN_MEIMTA, 1, "002" & wkBINCD, BtrNormal) ' 2006.7.18 AZU Add
			If DBSTAT = 0 Then
				If DB_MEIMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' �폜�σ��R�[�h�ł��B
					'UPGRADE_WARNING: �I�u�W�F�N�g BINCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					BINCD_Check = 1
				End If
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g BINCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				BINCD_Check = -1
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g BINCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If BINCD_Check = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g BINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Trim(BINCD) = Trim(DB_MEIMTA.MEICDA) Then
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_BINCD(De_Index, Trim(DB_MEIMTA.MEICDA))
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_BINRN(De_Index, Trim(DB_MEIMTA.MEINMA))
				Else
					Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
					'UPGRADE_WARNING: �I�u�W�F�N�g BINCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					BINCD_Check = -1
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_BINRN(De_Index, " ")
				End If
			End If
		End If
		
	End Function
	
	Function BINCD_Slist(ByRef PP As clsPP, ByVal BINCD As Object) As Object
		'
		'WLS_LIST.Caption = "�֋敪�ꗗ"
		WLS_MEI1.Text = "�֋敪�ꗗ"
		'WLS_LIST!LST.Clear
		CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
		'Call DB_GetGrEq(DBN_MEIMTA, 2, "1" & "002" & "   ", BtrNormal)
		Call DB_GetGrEq(DBN_MEIMTA, 1, "002", BtrNormal)
		
		Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "002"
			If DB_MEIMTA.DATKB <> "9" Then
				CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
			End If
			Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		Loop 
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.KEYCD)
		'WLS_LIST.Show 1
		WLS_MEI1.ShowDialog()
		'Unload WLS_LIST
		WLS_MEI1.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g BINCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		BINCD_Slist = PP.SlistCom
		
	End Function
	Function BINCD_InitVal() As Object
		'    BINCD_InitVal = "00"
	End Function
End Module