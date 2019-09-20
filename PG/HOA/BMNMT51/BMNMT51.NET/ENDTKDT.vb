Option Strict Off
Option Explicit On
Module ENDTKDT_F51
	'
	' �X���b�g��        : �K�p�J�n���E��ʍ��ڃX���b�g
	' ���j�b�g��        : ENDTKDT.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/30
	' �g�p�v���O������  : BMNMT51
	'
	
	Function ENDTKDT_CheckC(ByVal ENDTKDT As Object, ByVal BMNCD As Object, ByVal STTTKDT As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		'''' ADD 2009/07/22  FKS) T.Yamamoto    Start    �A���[��:283
		Dim wk_PxBase As Short
		'''' ADD 2009/07/22  FKS) T.Yamamoto    End
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDTKDT_CheckC = 0
		rtn = CHECK_DATE(ENDTKDT)
		If rtn Then
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g BMNCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DB_GetGrEq(DBN_BMNMTA, 3, BMNCD & VB6.Format(ENDTKDT, "YYYYMMDD"), BtrNormal)
			'UPGRADE_WARNING: �I�u�W�F�N�g BMNCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If (DBSTAT = 0) And (DB_BMNMTA.BMNCD = BMNCD) Then
				rtn = DSP_MsgBox(SSS_CONFRM, "BMNMT51", 0) '���ɐV�������t�œo�^�ς̈׃G���[
				'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ENDTKDT_CheckC = -1
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If ENDTKDT_CheckC = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Trim(VB6.Format(STTTKDT, "YYYYMMDD")) <> "" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g STTTKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If STTTKDT > ENDTKDT Then
						rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
						'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						ENDTKDT_CheckC = -1
					End If
				End If
			End If
			'''' ADD 2009/07/22  FKS) T.Yamamoto    Start    �A���[��:283
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If ENDTKDT_CheckC = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				wk_PxBase = 42 * De_Index
				'�����S�������͂���Ă���ꍇ�A���ڃ`�F�b�N���s��
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val2(CP_SSSMAIN(11 + wk_PxBase)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If AE_Val2(CP_SSSMAIN(11 + wk_PxBase)) <> "" Then
					Call AE_Check_SSSMAIN_HTANCD(AE_Val2(CP_SSSMAIN(11 + wk_PxBase)), CP_SSSMAIN(11 + wk_PxBase).StatusF, False, False)
					'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Ck_Error <> 0 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						ENDTKDT_CheckC = -1
						Exit Function
					End If
				End If
				'�c�Ə��R�[�h�����͂���Ă���ꍇ�A���ڃ`�F�b�N���s��
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val2(CP_SSSMAIN(13 + wk_PxBase)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If AE_Val2(CP_SSSMAIN(13 + wk_PxBase)) <> "" Then
					Call AE_Check_SSSMAIN_EIGYOCD(AE_Val2(CP_SSSMAIN(13 + wk_PxBase)), CP_SSSMAIN(13 + wk_PxBase).StatusF, False, False)
					'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Ck_Error <> 0 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						ENDTKDT_CheckC = -1
						Exit Function
					End If
				End If
				'�n��敪�����͂���Ă���ꍇ�A���ڃ`�F�b�N���s��
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val2(CP_SSSMAIN(14 + wk_PxBase)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If AE_Val2(CP_SSSMAIN(14 + wk_PxBase)) <> "" Then
					Call AE_Check_SSSMAIN_TIKKB(AE_Val2(CP_SSSMAIN(14 + wk_PxBase)), CP_SSSMAIN(14 + wk_PxBase).StatusF, False, False)
					'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Ck_Error <> 0 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						ENDTKDT_CheckC = -1
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
						'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						ENDTKDT_CheckC = -1
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
						'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						ENDTKDT_CheckC = -1
						Exit Function
					End If
				End If
				'''' ADD 2011/09/22  FKS) T.Yamamoto    End
			End If
			'''' ADD 2009/07/22  FKS) T.Yamamoto    End
		Else
			rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ENDTKDT_CheckC = -1
		End If
	End Function
	
	Function ENDTKDT_Skip(ByRef CT_ENDTKDT As System.Windows.Forms.Control, ByVal ENDTKDT As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(ENDTKDT) <> "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CT_ENDTKDT.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CT_ENDTKDT.SelStart = 8 'yyyy-mm-dd �� dd �ɃJ�[�\�����ړ�����B
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDTKDT_Skip = False
	End Function
	
	Function ENDTKDT_Slist(ByRef PP As clsPP, ByVal ENDTKDT As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Set_date.Value = ENDTKDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDTKDT_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDTKDT_Slist = Set_date.Value
	End Function
End Module