Option Strict Off
Option Explicit On
Module HINCD_F53
	'
	'�X���b�g��      :���i�R�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :HINCD.FM53
	'�L�q��          :Standard Library
	'�쐬���t        :2006/06/20
	'�g�p�v���O����  :TOKMT54
	'
	
	Function HINCD_CheckC(ByRef HINCD As Object, ByVal TOKCD As Object, ByVal URITKDT As Object, ByVal TUKKB As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
        Dim strSQL As String

        '2019/10/18 DEL START
        'Call HINMTA_RClear()
        'Call TOKMTA_RClear()
        '2019/10/18 DEL E N D

        Call TOKMTC_RClear()
		'Call SCR_FromMfil(De_Index)
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		HINCD_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(HINCD) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g HINCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			HINCD_CheckC = -1
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g TOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(HINCD) <> "" And Trim(TOKCD) <> "" And Trim(URITKDT) <> "" And Trim(TUKKB) <> "" Then
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
				
				'           Call DB_GetSQL2(DBN_TOKMTC, "select * from TOKMTC where HINCD ='" & Trim(HINCD) & "' and TOKCD ='" & Trim(TOKCD) & "' and URITKDT ='" & Format(URITKDT, "YYYYMMDD") & "' and TUKKB ='" & Trim(TUKKB))
				Call DB_GetSQL2(DBN_TOKMTC, strSQL)
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g TOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call DB_GetEq(DBN_TOKMTC, 1, Trim(HINCD) & Trim(TOKCD) & Trim(URITKDT) & Trim(TUKKB), BtrNormal)
			End If
			If DBSTAT = 0 Then
				'Do While DBSTAT = 0 And (De_Index < (PP_SSSMAIN.MaxDspC + 1))
				Do While DBSTAT = 0
					'
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
						If DB_HINMTA.DATKB = "9" Then
							Call Dsp_Prompt("RNOTFOUND", 1) ' �폜�σ��R�[�h�ł��B
							'UPGRADE_WARNING: �I�u�W�F�N�g HINCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							HINCD_CheckC = 1
						Else
							If DB_HINMTA.KHNKB = "9" Then
								Rtn = DSP_MsgBox(SSS_ERROR, "HINCD", 0) '���f�[�^�̈׃G���[
								'UPGRADE_WARNING: �I�u�W�F�N�g HINCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								HINCD_CheckC = -1
							Else
								'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Call HINCD_Move(HINCD, De_Index)
							End If
						End If
					Else
						Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 3)
						'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call DP_SSSMAIN_HINNMA(De_Index, "�@")
						'UPGRADE_WARNING: �I�u�W�F�N�g HINCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						HINCD_CheckC = -1
					End If
					'De_Index = De_Index + 1
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
				'
				Call DB_GetEq(DBN_HINMTA, 1, HINCD, BtrNormal)
				'HINMTA�̑�������
				If DBSTAT = 0 Then
					If DB_HINMTA.DATKB = "9" Then
						Call Dsp_Prompt("RNOTFOUND", 1) ' �폜�σ��R�[�h�ł��B
						'UPGRADE_WARNING: �I�u�W�F�N�g HINCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						HINCD_CheckC = 1
					Else
						If DB_HINMTA.KHNKB = "9" Then
							Rtn = DSP_MsgBox(SSS_ERROR, "HINCD", 0) '���f�[�^�̈׃G���[
							'UPGRADE_WARNING: �I�u�W�F�N�g HINCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							HINCD_CheckC = -1
						Else
							'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Call HINCD_Move(HINCD, De_Index)
						End If
					End If
				Else
					Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 3)
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_HINNMA(De_Index, "�@")
					'UPGRADE_WARNING: �I�u�W�F�N�g HINCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					HINCD_CheckC = -1
				End If
			End If
		End If
	End Function
	
	Function HINCD_Slist(ByRef PP As clsPP, ByVal HINCD As Object) As Object
		'
		WLSHIN.Text = "���i�ꗗ"
		DB_PARA(DBN_HINMTA).KeyNo = 1
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_PARA(DBN_HINMTA).KeyBuf = HINCD
		WLSHIN.ShowDialog()
		WLSHIN.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		HINCD_Slist = PP.SlistCom
		
	End Function
	Sub HINCD_Move(ByVal HINCD As Object, ByVal De As Short)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(HINCD) <> "" Then
			Call DP_SSSMAIN_HINCD(De, DB_HINMTA.HINCD)
			Call DP_SSSMAIN_HINNMA(De, DB_HINMTA.HINNMA)
		Else
			Call DP_SSSMAIN_HINCD(De, " ")
			Call DP_SSSMAIN_HINNMA(De, " ")
		End If
		'    If Trim$(DB_TOKMTC.URITK) = "" Then
		'       Call DP_SSSMAIN_URITK(De, "")
		'    Else
		'       Call DP_SSSMAIN_URITK(De, DB_TOKMTC.URITK)
		'    End If
		'    If Trim$(DB_TOKMTC.ULTTKKB) <> "" Then
		'        Call DP_SSSMAIN_ULTTKKB(De, DB_TOKMTC.ULTTKKB)
		'    End If
		
		
	End Sub
End Module