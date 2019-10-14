Option Strict Off
Option Explicit On
Module HTANCD_F51
	'
	'�X���b�g��      :�����S���E��ʍ��ڃX���b�g
	'���j�b�g��      :HTANCD.F51
	'�L�q��          :Standard Library
	'�쐬���t        :2006/06/15
	'�g�p�v���O����  :BMNMTA51
	
	Function HTANCD_CheckC(ByRef HTANCD As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		Dim wkHTANCD As String
		'2008/12/16 RISE)izumi ADD START  �A���[��:643
		Dim strSQL As String
		Dim wkSTTTKDT As String
		Dim wkENDTKDT As String
		Dim wkBMNCD As String
		'2008/12/16 RISE)izumi ADD END
		
		'UPGRADE_WARNING: �I�u�W�F�N�g HTANCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		HTANCD_CheckC = 0
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
			'UPGRADE_WARNING: �I�u�W�F�N�g HTANCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			HTANCD_CheckC = -1
			Exit Function
		End If
		'�K�p�J�n���E�K�p�I���������͂���Ă��Ȃ��ꍇ�A�G���[�Ƃ���
		If Trim(wkSTTTKDT) = "" Or Trim(wkENDTKDT) = "" Then
			rtn = DSP_MsgBox(SSS_ERROR, "BMNMT51_1", 9)
			'UPGRADE_WARNING: �I�u�W�F�N�g HTANCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			HTANCD_CheckC = -1
			Exit Function
		End If
		'2008/12/16 RISE)izumi ADD END
		'UPGRADE_WARNING: �I�u�W�F�N�g HTANCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(HTANCD)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(Trim(HTANCD)) = 0 Then
		Else
            '2008/12/16 RISE)izumi CHG START  �A���[��:643
            '        wkHTANCD = HTANCD & Space(Len(DB_MEIMTA.MEICDA) - Len(HTANCD))
            '        Call DB_GetEq(DBN_MEIMTA, 2, "024" & wkHTANCD, BtrNormal)
            'UPGRADE_WARNING: �I�u�W�F�N�g HTANCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B

            '2019/10/04 CHG START
            'wkHTANCD = HTANCD & Space(Len(DB_MEIMTC.MEICDA) - Len(HTANCD))
            If DB_MEIMTA.MEICDA Is Nothing OrElse Len(DB_MEIMTA.MEICDA) - Len(HTANCD) Then
                wkHTANCD = (HTANCD)
            Else
                wkHTANCD = (HTANCD) & Space(Len(DB_MEIMTA.MEICDA) - Len(HTANCD))
            End If
            '2019/10/04 CHG E N D

            strSQL = ""
			strSQL = strSQL & "SELECT "
			strSQL = strSQL & " * "
			strSQL = strSQL & "FROM "
			strSQL = strSQL & " MEIMTC "
			strSQL = strSQL & "WHERE "
			strSQL = strSQL & " KEYCD = '024' "
			strSQL = strSQL & "AND "
			strSQL = strSQL & " MEICDA = '" & wkHTANCD & "' "
			If Trim(wkSTTTKDT) <> "" Then
				strSQL = strSQL & "AND "
				strSQL = strSQL & " STTTKDT <= '" & wkSTTTKDT & "' "
			End If
			If Trim(wkENDTKDT) <> "" Then
				strSQL = strSQL & "AND "
				strSQL = strSQL & " ENDTKDT >= '" & wkENDTKDT & "' "
			End If
			
			Call DB_GetSQL2(DBN_MEIMTC, strSQL)
			'2008/12/16 RISE)izumi CHG END
			If DBSTAT = 0 Then
				'2008/12/16 RISE)izumi CHG START  �A���[��:643
				'            If DB_MEIMTA.DATKB = "9" Then
				If DB_MEIMTC.DATKB = "9" Then
					'2008/12/16 RISE)izumi CHG END
					Call Dsp_Prompt("RNOTFOUND", 1) ' �폜�σ��R�[�h�ł��B
					'UPGRADE_WARNING: �I�u�W�F�N�g HTANCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					HTANCD_CheckC = 1
				End If
			Else
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g HTANCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				HTANCD_CheckC = -1
			End If
		End If
		
	End Function
End Module