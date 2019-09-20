Option Strict Off
Option Explicit On
Module STTTKDT_F51
	'
	' �X���b�g��        : �K�p�J�n���E��ʍ��ڃX���b�g
	' ���j�b�g��        : STTTKDT.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/30
	' �g�p�v���O������  : BMNMT51
	'
	
	Function STTTKDT_CheckC(ByVal STTTKDT As Object, ByVal BMNCD As Object, ByVal ENDTKDT As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		'''' ADD 2009/07/22  FKS) T.Yamamoto    Start    �A���[��:283
		Dim wk_PxBase As Short
		'''' ADD 2009/07/22  FKS) T.Yamamoto    End
		'
		
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTTKDT_CheckC = 0
		rtn = CHECK_DATE(STTTKDT)
		If rtn Then
			'�K�p���Ƀf�[�^����������A���Y�f�[�^������
			Call BMNMTA_RClear()
			'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g BMNCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DB_GetEq(DBN_BMNMTA, 1, BMNCD & VB6.Format(STTTKDT, "YYYYMMDD"), BtrNormal)
			If DBSTAT = 0 Then
				If DB_BMNMTA.DATKB = "9" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_UPDKB(De_Index, "�폜")
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_UPDKB(De_Index, "�X�V")
				End If
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call SCR_FromMfil(De_Index)
				Call DB_GetGrEq(DBN_BMNMTA, 1, DB_BMNMTA.BMNCDUP & "        ", BtrNormal)
				'''' UPD 2009/08/25  FKS) T.Yamamoto    Start    �A���[��:FC09082501
				'            If (DBSTAT = 0) And (DB_BMNMTA.BMNCD = RD_SSSMAIN_BMNCDUP(De_Index)) Then
				'                Call DP_SSSMAIN_BMNNMUP(De_Index, DB_BMNMTA.BMNNM)
				'            Else
				'                Call DP_SSSMAIN_BMNNMUP(De_Index, "")
				'            End If
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call DP_SSSMAIN_BMNNMUP(De_Index, "")
				Do While (DBSTAT = 0)
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ENDTKDT(De_Index) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STTTKDT(De_Index) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNCDUP(De_Index) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If (DB_BMNMTA.BMNCD = RD_SSSMAIN_BMNCDUP(De_Index)) And (DB_BMNMTA.STTTKDT <= RD_SSSMAIN_STTTKDT(De_Index)) And (DB_BMNMTA.ENDTKDT >= RD_SSSMAIN_ENDTKDT(De_Index)) Then
						'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call DP_SSSMAIN_BMNNMUP(De_Index, DB_BMNMTA.BMNNM)
						Exit Do
					End If
					Call DB_GetNext(DBN_BMNMTA, BtrNormal)
				Loop 
				'''' UPD 2009/08/25  FKS) T.Yamamoto    End
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call DP_SSSMAIN_UPDKB(De_Index, "�ǉ�")
				Call BMNMTA_RClear()
				'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g BMNCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call DB_GetGrEq(DBN_BMNMTA, 3, BMNCD & VB6.Format(STTTKDT, "YYYYMMDD"), BtrNormal)
				'UPGRADE_WARNING: �I�u�W�F�N�g BMNCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If (DBSTAT = 0) And (DB_BMNMTA.BMNCD = BMNCD) Then
					rtn = DSP_MsgBox(SSS_CONFRM, "BMNMT51", 0) '���ɐV�������t�œo�^�ς̈׃G���[
					'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					STTTKDT_CheckC = -1
				End If
				'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Trim(VB6.Format(ENDTKDT, "YYYYMMDD")) <> "" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If STTTKDT > ENDTKDT Then
						rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
						'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						STTTKDT_CheckC = -1
					End If
				End If
			End If
			'''' ADD 2009/07/22  FKS) T.Yamamoto    Start    �A���[��:283
			'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If STTTKDT_CheckC = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				wk_PxBase = 42 * De_Index
				'�����S�������͂���Ă���ꍇ�A���ڃ`�F�b�N���s��
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val2(CP_SSSMAIN(11 + wk_PxBase)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If AE_Val2(CP_SSSMAIN(11 + wk_PxBase)) <> "" Then
					Call AE_Check_SSSMAIN_HTANCD(AE_Val2(CP_SSSMAIN(11 + wk_PxBase)), CP_SSSMAIN(11 + wk_PxBase).StatusF, False, False)
					'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Ck_Error <> 0 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						STTTKDT_CheckC = -1
						Exit Function
					End If
				End If
				'�c�Ə��R�[�h�����͂���Ă���ꍇ�A���ڃ`�F�b�N���s��
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val2(CP_SSSMAIN(13 + wk_PxBase)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If AE_Val2(CP_SSSMAIN(13 + wk_PxBase)) <> "" Then
					Call AE_Check_SSSMAIN_EIGYOCD(AE_Val2(CP_SSSMAIN(13 + wk_PxBase)), CP_SSSMAIN(13 + wk_PxBase).StatusF, False, False)
					'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Ck_Error <> 0 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						STTTKDT_CheckC = -1
						Exit Function
					End If
				End If
				'�n��敪�����͂���Ă���ꍇ�A���ڃ`�F�b�N���s��
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val2(CP_SSSMAIN(14 + wk_PxBase)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If AE_Val2(CP_SSSMAIN(14 + wk_PxBase)) <> "" Then
					Call AE_Check_SSSMAIN_TIKKB(AE_Val2(CP_SSSMAIN(14 + wk_PxBase)), CP_SSSMAIN(14 + wk_PxBase).StatusF, False, False)
					'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Ck_Error <> 0 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						STTTKDT_CheckC = -1
						Exit Function
					End If
				End If
				'''' ADD 2009/08/25  FKS) T.Yamamoto    Start    �A���[��:FC09082501
				'��ʕ���R�[�h�����͂���Ă���ꍇ�A���ڃ`�F�b�N���s��
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val2(CP_SSSMAIN(22 + wk_PxBase)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If AE_Val2(CP_SSSMAIN(22 + wk_PxBase)) <> "" Then
					Call AE_Check_SSSMAIN_BMNCDUP(AE_Val2(CP_SSSMAIN(22 + wk_PxBase)), CP_SSSMAIN(22 + wk_PxBase).StatusF, False, False)
					'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Ck_Error <> 0 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						STTTKDT_CheckC = -1
						Exit Function
					End If
				End If
				'''' ADD 2009/08/25  FKS) T.Yamamoto    End
				'''' ADD 2011/09/22  FKS) T.Yamamoto    Start    �A���[��FC11092201
				'��v���傪���͂���Ă���ꍇ�A���ڃ`�F�b�N���s��
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val2(CP_SSSMAIN(10 + wk_PxBase)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If AE_Val2(CP_SSSMAIN(10 + wk_PxBase)) <> "" Then
					Call AE_Check_SSSMAIN_ZMBMNCD(AE_Val2(CP_SSSMAIN(10 + wk_PxBase)), CP_SSSMAIN(10 + wk_PxBase).StatusF, False, False)
					'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Ck_Error <> 0 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						STTTKDT_CheckC = -1
						Exit Function
					End If
				End If
				'''' ADD 2011/09/22  FKS) T.Yamamoto    End
			End If
			'''' ADD 2009/07/22  FKS) T.Yamamoto    End
		Else
			rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			STTTKDT_CheckC = -1
		End If
		
	End Function
	
	Function STTTKDT_Skip(ByRef CT_STTTKDT As System.Windows.Forms.Control, ByVal STTTKDT As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(STTTKDT) <> "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CT_STTTKDT.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CT_STTTKDT.SelStart = 8 'yyyy-mm-dd �� dd �ɃJ�[�\�����ړ�����B
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTTKDT_Skip = False
	End Function
	
	Function STTTKDT_Slist(ByRef PP As clsPP, ByVal STTTKDT As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Set_date.Value = STTTKDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTTKDT_Slist = Set_date.Value
	End Function
End Module