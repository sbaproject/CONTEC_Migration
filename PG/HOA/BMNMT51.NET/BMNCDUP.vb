Option Strict Off
Option Explicit On
Module BMNCDUP_F51
	'
	'�X���b�g��      :��ʕ���R�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :BMNCDUP.F01
	'�L�q��          :Standard Library
	'�쐬���t        :2006/06/07
	'�g�p�v���O����  :BMNMT51
	'
	
	Function BMNCDUP_CheckC(ByVal BMNCDUP As Object, ByVal De_Index As Object, ByVal BMNCD As Object, ByVal Ex_BMNCDUP As Object) As Object
		Dim rtn As Short
		'
		
		'UPGRADE_WARNING: �I�u�W�F�N�g BMNCDUP_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		BMNCDUP_CheckC = 0
		' �����͂̏ꍇ�ɂ�, �G���[���������ɖ��̓����N���A����
		Call BMNMTA_RClear()
		'UPGRADE_WARNING: �I�u�W�F�N�g BMNCDUP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(BMNCDUP)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(Trim(BMNCDUP)) <> 0 Then
			'���庰�ނƏ�ʕ�������
			'UPGRADE_WARNING: �I�u�W�F�N�g BMNCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g BMNCDUP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(BMNCDUP) = Trim(BMNCD) Then
				rtn = DSP_MsgBox(SSS_ERROR, "CANTSELECT ", 1)
				'UPGRADE_WARNING: �I�u�W�F�N�g BMNCDUP_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				BMNCDUP_CheckC = -1
				Exit Function
				''        Else
				''            Call BMNCDUP_Move(BMNCDUP, De_Index)
				''            BMNCDUP_CheckC = 0
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g BMNCDUP_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			BMNCDUP_CheckC = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DP_SSSMAIN_BMNNMUP(De_Index, "")
			'UPGRADE_WARNING: �I�u�W�F�N�g BMNCDUP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DB_GetGrEq(DBN_BMNMTA, 5, "1" & BMNCDUP & "        ", BtrNormal)
			'UPGRADE_WARNING: �I�u�W�F�N�g BMNCDUP_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Do While (DBSTAT = 0) And (BMNCDUP_CheckC = "")
				'''' UPD 2009/08/25  FKS) T.Yamamoto    Start    �A���[��:FC09082501
				'            If (DB_BMNMTA.BMNCD = BMNCDUP) And _
				''               (DB_UNYMTA.UNYDT >= DB_BMNMTA.STTTKDT) And _
				''               (DB_UNYMTA.UNYDT <= DB_BMNMTA.ENDTKDT) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ENDTKDT(De_Index) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STTTKDT(De_Index) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g BMNCDUP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If (DB_BMNMTA.BMNCD = BMNCDUP) And (DB_BMNMTA.STTTKDT <= RD_SSSMAIN_STTTKDT(De_Index)) And (DB_BMNMTA.ENDTKDT >= RD_SSSMAIN_ENDTKDT(De_Index)) Then
					'''' UPD 2009/08/25  FKS) T.Yamamoto    End
					If DB_BMNMTA.DATKB = "9" Then
						Call Dsp_Prompt("RNOTFOUND", 1) ' �폜�σ��R�[�h�ł��B
						'UPGRADE_WARNING: �I�u�W�F�N�g BMNCDUP_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						BMNCDUP_CheckC = 1
						'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call BMNCDUP_Move(BMNCDUP, De_Index)
					Else
						'UPGRADE_WARNING: �I�u�W�F�N�g BMNCDUP_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						BMNCDUP_CheckC = 0
						'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call BMNCDUP_Move(BMNCDUP, De_Index)
					End If
				End If
				Call DB_GetNext(DBN_BMNMTA, BtrNormal)
			Loop 
			'UPGRADE_WARNING: �I�u�W�F�N�g BMNCDUP_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If BMNCDUP_CheckC = "" Then
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' �Y�����R�[�h�͂���܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g BMNCDUP_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				BMNCDUP_CheckC = -1
			End If
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g BMNCDUP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(BMNCDUP) = "" Then
				Call BMNMTA_RClear()
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call BMNCDUP_Move(BMNCDUP, De_Index)
			End If
		End If
	End Function
	
	Function BMNCDUP_Slist(ByRef PP As clsPP, ByVal BMNCDUP As Object) As Object
		
		'    WLSBMN.Caption = "��ʕ�����"
		'    DB_PARA(DBN_BMNMTA).KeyNo = 1
		'    DB_PARA(DBN_BMNMTA).KeyBuf = BMNCDUP
		'    WLSBMN.Show 1
		'    Unload WLSBMN
		'    BMNCDUP_Slist = PP.SlistCom
		
		CType(WLS_BMN1.Controls("LST"), Object).Items.Clear()
		Call DB_GetFirst(DBN_BMNMTA, 1, BtrNormal)
		Do While (DBSTAT = 0)
			If (DB_BMNMTA.DATKB = "1") And (DB_BMNMTA.STTTKDT <= DB_UNYMTA.UNYDT) And (DB_BMNMTA.ENDTKDT >= DB_UNYMTA.UNYDT) Then
				CType(WLS_BMN1.Controls("LST"), Object).Items.Add(DB_BMNMTA.BMNCD & "   " & LeftWid(DB_BMNMTA.BMNNM, 40) & " " & CNV_DATE(DB_BMNMTA.STTTKDT) & " " & CNV_DATE(DB_BMNMTA.ENDTKDT))
			End If
			Call DB_GetNext(DBN_BMNMTA, BtrNormal)
		Loop 
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSS_WLSLIST_KETA = LenWid(DB_BMNMTA.BMNCD)
		WLS_BMN1.ShowDialog()
		WLS_BMN1.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		BMNCDUP_Slist = Left(PP.SlistCom, 6)
		
	End Function
	Sub BMNCDUP_Move(ByVal BMNCDUP As Object, ByVal De_Index As Short)
		'UPGRADE_WARNING: �I�u�W�F�N�g BMNCDUP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(BMNCDUP) <> "" Then
			Call DP_SSSMAIN_BMNCDUP(De_Index, DB_BMNMTA.BMNCD)
			Call DP_SSSMAIN_BMNNMUP(De_Index, DB_BMNMTA.BMNNM)
		Else
			Call DP_SSSMAIN_BMNCDUP(De_Index, "")
			Call DP_SSSMAIN_BMNNMUP(De_Index, "")
		End If
	End Sub
	
	Function BMNCDUP_DerivedC(ByVal BMNCDUP As Object, ByVal BMNCD As Object, ByVal De_Index As Object) As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g BMNCDUP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g BMNCDUP_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		BMNCDUP_DerivedC = BMNCDUP
		Call BMNMTA_RClear()
		Call DB_GetEq(DBN_BMNMTA, 1, BMNCDUP, BtrNormal)
		If DBSTAT = 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call BMNCDUP_Move(BMNCDUP, De_Index)
		End If
	End Function
End Module