Option Strict Off
Option Explicit On
Module TUKKB_F53
	'
	' �X���b�g��        : �ʉ݋敪�E��ʍ��ڃX���b�g
	' ���j�b�g��        : TUKKB.F52
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/25
	' �g�p�v���O������  : TOKMT53
	'
	
	Function TUKKB_Check(ByVal TUKKB As Object, ByVal URITKDT As Object, ByVal HINCD As Object, ByVal TOKCD As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		Dim keyVal As String
		Dim wkTUKKB As String
		Dim wkHINCD As String
		Dim wkTOKCD As String
		Dim strSQL As String
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		TUKKB_Check = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(TUKKB) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			TUKKB_Check = -1
			Exit Function
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkTUKKB = TUKKB & Space(Len(DB_MEIMTA.MEICDA) - Len(TUKKB))
			Call DB_GetEq(DBN_MEIMTA, 2, "001" & wkTUKKB, BtrNormal)
			If DBSTAT = 0 Then
				If DB_MEIMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' �폜���R�[�h�ł��B
					'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					TUKKB_Check = -1
				End If
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' �Y�����R�[�h�͂���܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				TUKKB_Check = -1
			End If
		End If
		'�ŐV�f�[�^���������
		'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If TUKKB_Check = 0 Then
			''''        If CLng(Format(URITKDT, "YYYYMMDD")) < CLng(DB_UNYMTA.UNYDT) Then
			'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkHINCD = HINCD & Space(Len(DB_TOKMTC.HINCD) - Len(HINCD))
			'UPGRADE_WARNING: �I�u�W�F�N�g TOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkTOKCD = TOKCD & Space(Len(DB_TOKMTC.TOKCD) - Len(TOKCD))
			'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DB_GetGrEq(DBN_TOKMTC, 2, wkHINCD & wkTOKCD & TUKKB & VB6.Format(URITKDT, "YYYYMMDD"), BtrNormal)
			'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If (DBSTAT = 0) And (DB_TOKMTC.HINCD = wkHINCD) And (DB_TOKMTC.TOKCD = wkTOKCD) And (DB_TOKMTC.TUKKB = TUKKB) And (DB_TOKMTC.URITKDT > VB6.Format(URITKDT, "YYYYMMDD")) Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "TOKMT52", 0) '���ɐV�������t�œo�^�ς̈׃G���[
				'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				TUKKB_Check = -1
			End If
			''''        End If
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If TUKKB_Check <> 0 Then Exit Function
		
		'�K�p���Ƀf�[�^����������A���Y�f�[�^������
		'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g TOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(HINCD) <> "" And Trim(TOKCD) <> "" And Trim(URITKDT) <> "" Then
			'Call DB_GetEq(DBN_TOKMTC, 1, Trim(HINCD) & Trim(TOKCD) & Format(URITKDT, "YYYYMMDD"), BtrNormal)
			'Call DB_GetSQL2(DBN_TOKMTC, "select * from TOKMTC where HINCD ='" & Trim(HINCD) & "' and TOKCD ='" & Trim(TOKCD) & "' and URITKDT ='" & Format(URITKDT, "YYYYMMDD") & "'")
			strSQL = ""
			strSQL = strSQL & "select * from TOKMTC"
			'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & " where HINCD ='" & Trim(HINCD) & "'"
			'UPGRADE_WARNING: �I�u�W�F�N�g TOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "   and TOKCD ='" & Trim(TOKCD) & "'"
			'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "   and URITKDT ='" & VB6.Format(URITKDT, "YYYYMMDD") & "'"
			'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "   and TUKKB ='" & Trim(TUKKB) & "'"
			
			Call DB_GetSQL2(DBN_TOKMTC, strSQL)
			
			If DBSTAT = 0 Then
				Do While DBSTAT = 0
					If DB_TOKMTC.DATKB = "9" Then
						'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call DP_SSSMAIN_UPDKB(De_Index, "�폜")
					Else
						'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call DP_SSSMAIN_UPDKB(De_Index, "�X�V")
					End If
					Call DB_GetEq(DBN_HINMTA, 1, HINCD, BtrNormal)
					'HINMTA�̑�������
					If DBSTAT = 0 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call HINCD_Move(HINCD, De_Index)
					Else
						'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call DP_SSSMAIN_HINNMA(De_Index, "�@")
					End If
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_TOKMTC.URITK) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Trim(CStr(DB_TOKMTC.URITK)) = "" Or SSSVal(DB_TOKMTC.URITK) = 0 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call DP_SSSMAIN_URITK(De_Index, "")
					Else
						'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call DP_SSSMAIN_URITK(De_Index, DB_TOKMTC.URITK)
					End If
					If Trim(DB_TOKMTC.ULTTKKB) <> "" Then
						'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call DP_SSSMAIN_ULTTKKB(De_Index, DB_TOKMTC.ULTTKKB)
					End If
					
					Call DB_GetNext(DBN_TOKMTC, BtrNormal)
				Loop 
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call DP_SSSMAIN_UPDKB(De_Index, "�ǉ�")
				Call DB_GetEq(DBN_HINMTA, 1, HINCD, BtrNormal)
				If DBSTAT = 0 Then '���iϽ��ɓ��Y���ڂ��݂鎞
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call HINCD_Move(HINCD, De_Index)
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_HINNMA(De_Index, "�@")
				End If
			End If
		End If
		
	End Function
	
	Function TUKKB_Slist(ByRef PP As clsPP) As Object
		WLS_MEI1.Text = "�ʉ݋敪�ꗗ"
		CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
		Call DB_GetGrEq(DBN_MEIMTA, 3, "001", BtrNormal)
		Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "001"
			CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & DB_MEIMTA.MEINMA)
			Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		Loop 
		SSS_WLSLIST_KETA = 3
		WLS_MEI1.ShowDialog()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		TUKKB_Slist = PP.SlistCom
		
	End Function
End Module