Option Strict Off
Option Explicit On
Module EIGYOCD_F51
	'
	' �X���b�g��        : �c�Ə��R�[�h�E��ʍ��ڃX���b�g
	' ���j�b�g��        : EIGYOCD.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/05/30
	' �g�p�v���O������  : BMNMT51
	'
	Function EIGYOCD_CheckC(ByRef EIGYOCD As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		Dim wkEIGYOCD As String
		'2008/12/16 RISE)izumi ADD START  �A���[��:643
		Dim strSQL As String
		Dim wkSTTTKDT As String
		Dim wkENDTKDT As String
		Dim wkBMNCD As String
		'2008/12/16 RISE)izumi ADD END
		
		'UPGRADE_WARNING: �I�u�W�F�N�g EIGYOCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		EIGYOCD_CheckC = 0
		'2008/12/16 RISE)izumi ADD START  �A���[��:643
		'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wkBMNCD = RD_SSSMAIN_BMNCD(De_Index)
		'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STTTKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wkSTTTKDT = RD_SSSMAIN_STTTKDT(De_Index)
		'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ENDTKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wkENDTKDT = RD_SSSMAIN_ENDTKDT(De_Index)
		'����R�[�h�����͂���Ă��Ȃ��ꍇ�A�G���[�Ƃ���
		If Trim(wkBMNCD) = "" Then
			rtn = DSP_MsgBox(SSS_ERROR, "BMNMT51_1", 8)
			'UPGRADE_WARNING: �I�u�W�F�N�g EIGYOCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			EIGYOCD_CheckC = -1
			Exit Function
		End If
		'�K�p�J�n���E�K�p�I���������͂���Ă��Ȃ��ꍇ�A�G���[�Ƃ���
		If Trim(wkSTTTKDT) = "" Or Trim(wkENDTKDT) = "" Then
			rtn = DSP_MsgBox(SSS_ERROR, "BMNMT51_1", 9)
			'UPGRADE_WARNING: �I�u�W�F�N�g EIGYOCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			EIGYOCD_CheckC = -1
			Exit Function
		End If
		'2008/12/16 RISE)izumi ADD END
		'UPGRADE_WARNING: �I�u�W�F�N�g EIGYOCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(EIGYOCD)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(Trim(EIGYOCD)) = 0 Then
			Call AE_InOutModeN_SSSMAIN("TIKKB", "0000")
		Else
			'2008/12/16 RISE)izumi CHG START  �A���[��:643
			'        wkEIGYOCD = EIGYOCD & Space(Len(DB_MEIMTA.MEICDA) - Len(EIGYOCD))
			'        Call DB_GetEq(DBN_MEIMTA, 2, "058" & wkEIGYOCD, BtrNormal)
			'UPGRADE_WARNING: �I�u�W�F�N�g EIGYOCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkEIGYOCD = EIGYOCD & Space(Len(DB_MEIMTC.MEICDA) - Len(EIGYOCD))
			'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STTTKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkSTTTKDT = RD_SSSMAIN_STTTKDT(De_Index)
			'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ENDTKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkENDTKDT = RD_SSSMAIN_ENDTKDT(De_Index)
			
			strSQL = ""
			strSQL = strSQL & "SELECT "
			strSQL = strSQL & " * "
			strSQL = strSQL & "FROM "
			strSQL = strSQL & " MEIMTC "
			strSQL = strSQL & "WHERE "
			strSQL = strSQL & " KEYCD = '058' "
			strSQL = strSQL & "AND "
			'''' UPD 2010/07/14  FKS) T.Yamamoto    Start    �A���[��FC10071401
			'        strSQL = strSQL & " MEICDA = '" & wkEIGYOCD & "' "
			strSQL = strSQL & " MEICDA = '" & AE_EditSQLText(wkEIGYOCD) & "' "
			'''' UPD 2010/07/14  FKS) T.Yamamoto    End
			If Trim(wkSTTTKDT) <> "" Then
				strSQL = strSQL & "AND "
				strSQL = strSQL & " STTTKDT <= '" & wkSTTTKDT & "' "
			End If
			If Trim(wkENDTKDT) <> "" Then
				strSQL = strSQL & "AND "
				strSQL = strSQL & " ENDTKDT >= '" & wkENDTKDT & "' "
			End If
			
			Call DB_GetSQL2(DBN_MEIMTC, strSQL)
			' RISE)izumi CHG END
			If DBSTAT = 0 Then
				'2008/12/16 RISE)izumi CHG START  �A���[��:643
				'            If DB_MEIMTA.DATKB = "9" Then
				If DB_MEIMTC.DATKB = "9" Then
					'2008/12/16 RISE)izumi CHG END
					Call Dsp_Prompt("RNOTFOUND", 1) ' �폜�σ��R�[�h�ł��B
					'UPGRADE_WARNING: �I�u�W�F�N�g EIGYOCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					EIGYOCD_CheckC = 1
				End If
			Else
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g EIGYOCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				EIGYOCD_CheckC = -1
			End If
			Call AE_InOutModeN_SSSMAIN("TIKKB", "3303")
		End If
		
	End Function
End Module