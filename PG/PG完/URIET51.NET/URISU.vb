Option Strict Off
Option Explicit On
Module URISU_F61
	'
	' �X���b�g��        : ���㐔�ʁE��ʍ��ڃX���b�g
	' ���j�b�g��        : URISU.F61
	' �L�q��            : Muratani
	' �쐬���t          : 2006/07/25
	' �g�p�v���O������  : URIET51
	'
	
	Function URISU_CHECKC(ByVal BKTHKKB As Object, ByVal URISU As Object, ByVal UODSU As Object, ByVal ATZHIKSU As Object, ByVal HINID As Object, ByVal HINCD As Object) As Object
		Dim Rtn As Short
		Dim strSQL As String
		'''' ADD 2008/11/21  FKS) S.Nakajima    Start
		Dim intDe As Short
		Dim strJdnLinno As String
		'''' ADD 2008/11/21  FKS) S.Nakajima    End
		
		'
		' �����s�敪�i1�F���͉A9�F�s�j���s�@����
		' �󒍐��ʂƈقȂ���͔��㐔�ʂ���͂����ꍇ�G���[
		'UPGRADE_WARNING: �I�u�W�F�N�g ATZHIKSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g UODSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g UODSU - ATZHIKSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g BKTHKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(BKTHKKB) = "9" And (UODSU - ATZHIKSU) <> URISU Then
			'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '�����s�̂��߁A��������͂ł��܂���B
			MsgBox("�����s�̂��߁A��������͂ł��܂���B", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
			'UPGRADE_WARNING: �I�u�W�F�N�g URISU_CHECKC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URISU_CHECKC = -1
			Exit Function
		End If
		
		'�ʔ̎��A��������s��
		'UPGRADE_WARNING: �I�u�W�F�N�g HINID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If (Trim(WG_JDNINKB) = "2") Or (Trim(WG_SYSTEM) = "M" And Trim(HINID) = "06") Then
			'UPGRADE_WARNING: �I�u�W�F�N�g ATZHIKSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g UODSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g UODSU - ATZHIKSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If (UODSU - ATZHIKSU) <> URISU Then
				'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '�����s�̂��߁A��������͂ł��܂���B
				'2008/2/27 FKS)ichihara CHG START
				'            MsgBox "�ʔ̃f�[�^�ׁ̈A��������͂ł��܂���B", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm)
				MsgBox("�����R�[�h�܂��͒ʔ̃f�[�^�ׁ̈A��������͂ł��܂���B", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
				'2008/2/27 FKS)ichihara CHG END
				'UPGRADE_WARNING: �I�u�W�F�N�g URISU_CHECKC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				URISU_CHECKC = -1
				Exit Function
			End If
		End If
		
		' �󒍐��A���͎󒍐��𒴂��鐔�ʂ͓��͕s��
		' ATZHIKSU�˔���ςݐ�
		'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ATZHIKSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g UODSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If UODSU - ATZHIKSU - URISU < 0 Then
			'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '�󒍐��A���͎󒍐��𒴂��鐔�ʂ͓��͂ł��܂���B
			MsgBox("�󒍐��A���͎󒍐��𒴂��鐔�ʂ͓��͂ł��܂���B", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
			'UPGRADE_WARNING: �I�u�W�F�N�g URISU_CHECKC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URISU_CHECKC = -1
			Exit Function
		End If
		
		' ���ʂO�͓��͕s��
		'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If URISU = 0 Then
			'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '���ʂO�͓��͂ł��܂���B
			MsgBox("���ʃ[���͓��͂ł��܂���B", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
			'UPGRADE_WARNING: �I�u�W�F�N�g URISU_CHECKC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URISU_CHECKC = -1
			Exit Function
		End If
		
		'''' ADD 2008/11/21  FKS) S.Nakajima    Start
		
		intDe = PP_SSSMAIN.De
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_JDNLINNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strJdnLinno = Trim(CStr(RD_SSSMAIN_JDNLINNO(intDe)))
		strSQL = ""
		strSQL = strSQL & "SELECT * FROM JDNTRA "
		strSQL = strSQL & " WHERE DATNO = '" & WG_JDNDATNO & "'"
		strSQL = strSQL & "   AND LINNO = " & "'" & strJdnLinno & "'"
		Call DB_GetSQL2(DBN_JDNTRA, strSQL)
		'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If DB_JDNTRA.OTPSU - DB_JDNTRA.URISU < CDec(URISU) And DB_JDNTRA.ZAIKB = "1" Then
			'''' UPD 2009/02/23  FKS) S.Nakajima    Start
			'        MsgBox "�o�א��s��v�̂��߁A����o�^�o���܂���B", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm)
			Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52_1", 7) '���o�ׂ���̂��߁A����o�^�o���܂���B
			'''' UPD 2009/02/23  FKS) S.Nakajima    End
			'UPGRADE_WARNING: �I�u�W�F�N�g URISU_CHECKC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URISU_CHECKC = -1
			Exit Function
		End If
		
		'''' ADD 2008/11/21  FKS) S.Nakajima    End
		
		strSQL = ""
		strSQL = strSQL & "SELECT COUNT(*) FROM USRET51"
		strSQL = strSQL & " WHERE RPTCLTID = " & "'" & SSS_CLTID.Value & "'"
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "   AND HINCD    = " & "'" & HINCD & "'"
        'change 20190807 START hou
        'Call DB_GetSQL2(DBN_USRET51, strSQL)
        CON_USR9 = DB_START_USR9()
        DB_GetTable(strSQL, CON_USR9)
        'change 20190807 END hou


        'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_ExtNum.ExtNum(0)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change 20190807 START hou
        'If SSSVal(DB_ExtNum.ExtNum(0)) <> 0 Then
        If SSSVal(1) <> 0 Then
            'change 20190807 END hou

            'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'change 20190807 START hou
            'If URISU < DB_ExtNum.ExtNum(0) Then
            If URISU < 1 Then
                'change 20190807 END hou

                Rtn = DSP_MsgBox(SSS_CONFRM, "URIET51", 2) '���㐔�ȏ�̼رق��o�^
                'UPGRADE_WARNING: �I�u�W�F�N�g URISU_CHECKC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                URISU_CHECKC = -1
                Exit Function
            End If
        End If

        'UPGRADE_WARNING: �I�u�W�F�N�g URISU_CHECKC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        URISU_CHECKC = 0
		'
	End Function
	
	Function URISU_Slist(ByRef PP As clsPP, ByVal UDNDT As Object, ByVal HINCD As Object, ByVal SBNNO As Object, ByVal SOUCD As Object, ByVal DE_INDEX As Object) As Object
		Dim I As Short
		Dim EXEPATH As String
		Dim strSQL As String
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_JDNTRKB(0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If RD_SSSMAIN_JDNTRKB(0) <> "51" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISU() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
			Exit Function
		End If
		
		Call DB_GetEq(DBN_HINMTA, 1, HINCD, BtrNormal)
		If DBSTAT = 0 Then
			If DB_HINMTA.SERIKB = "9" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISU() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
				Exit Function
			End If
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISU() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
			Exit Function
		End If
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g SOUCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISU(DE_INDEX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SBNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		EXEPATH = AE_AppPath & "USRET51.EXE /RPTCLTID:" & SSS_CLTID.Value & " /RSTDT:" & VB6.Format(UDNDT, "YYYYMMDD") & " /HINCD:" & Trim(HINCD) & " /SBNNO:" & Trim(SBNNO) & " /URISU:" & RD_SSSMAIN_URISU(DE_INDEX) & " /SOUCD:" & Trim(SOUCD)
		I = VBEXEC1(FR_SSSMAIN.Handle.ToInt32, 1, EXEPATH)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISU() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
	End Function
End Module