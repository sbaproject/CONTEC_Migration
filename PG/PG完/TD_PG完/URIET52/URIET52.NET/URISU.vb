Option Strict Off
Option Explicit On
Module URISU_F53
	'
	' �X���b�g��        : ���㐔�ʁE��ʍ��ڃX���b�g
	' ���j�b�g��        : URISU.F53
	' �L�q��            :
	' �쐬���t          : 2006/09/22
	' �g�p�v���O������  : URIET52
	'
	
	Function URISU_CHECK(ByVal BKTHKKB As Object, ByVal URISU As Object, ByVal UODSU As Object, ByVal ATZHIKSU As Object, ByVal MNZHIKSU As Object, ByVal HINCD As Object, ByVal HINID As Object, ByVal SBNNO As Object, ByVal SERIKB As Object, ByVal DE_INDEX As Object) As Object
		Dim Rtn As Short
		Dim strSQL As String
		'''' ADD 2008/11/28  FKS) S.Nakajima    Start
		Dim intDe As Short
		Dim strJdnLinno As String
		Dim strJdnDatno As String
		Dim strJdnNo As String
		Dim strLinno As String
		Dim strDatNo As String
		'''' ADD 2008/11/28  FKS) S.Nakajima    End
		
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call DP_SSSMAIN_SBNSU(DE_INDEX, URISU)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g URISU_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		URISU_CHECK = 0
		
		'2008/2/5 FKS)ichihara ADD START
		'���͑O���ʂƓ��͌�̐��ʂ��قȂ�ꍇ�ŏo�׊�̂Ƃ��A���ʕύX��s�Ƃ���
		'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g MNZHIKSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If MNZHIKSU <> URISU Then
			'���͂������ʂ����͑O�ƈقȂ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URIKJN(-1) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If RD_SSSMAIN_URIKJN(-1) = "01" Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52_1", 6) '�o�׊�̂��߁A���ʂ͕ύX�ł��܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g URISU_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				URISU_CHECK = -1
				Exit Function
			End If
		End If
		'2008/2/5 FKS)ichihara ADD END
		
		' �����s�敪�i1�F���͉A9�F�s�j���s�@����
		' �󒍐��ʂƈقȂ���͔��㐔�ʂ���͂����ꍇ�G���[
		'2008/2/5 FKS)ichihara CHG START
		'������A�H��������̎��͕����敪�Ɋ֌W�Ȃ����ʒ������\�Ƃ���
		'    If Trim$(BKTHKKB) = "9" And (UODSU - ATZHIKSU + MNZHIKSU) <> URISU Then
		'        Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 3)  '�����s�̂��߁A��������͂ł��܂���B
		'        URISU_CHECK = -1
		'        Exit Function
		'    End If
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URIKJN(-1) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If RD_SSSMAIN_URIKJN(-1) <> "02" And RD_SSSMAIN_URIKJN(-1) <> "04" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g MNZHIKSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g ATZHIKSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g UODSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g BKTHKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(BKTHKKB) = "9" And (UODSU - ATZHIKSU + MNZHIKSU) <> URISU Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 3) '�����s�̂��߁A��������͂ł��܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g URISU_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				URISU_CHECK = -1
				Exit Function
			End If
		End If
		'2008/2/5 FKS)ichihara CHG END
		
		'�ʔ̎��A��������s��
		If Trim(WG_JDNINKB) = "2" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g MNZHIKSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g ATZHIKSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g UODSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If (UODSU - ATZHIKSU + MNZHIKSU) <> URISU Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52_1", 3) '�ʔ̃f�[�^�ׁ̈A��������͂ł��܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g URISU_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				URISU_CHECK = -1
				Exit Function
			End If
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g HINID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(WG_SYSTEM) = "M" And Trim(HINID) = "06" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g MNZHIKSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g ATZHIKSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g UODSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If (UODSU - ATZHIKSU + MNZHIKSU) <> URISU Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52_1", 4) '�V�X�e���󒍂̏������i�ׁ̈A��������͂ł��܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g URISU_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				URISU_CHECK = -1
				Exit Function
			End If
		End If
		
		' �󒍐��A���͎󒍎c���𒴂��鐔�ʓ��͕s��
		' ATZHIKSU�˔���ςݐ�
		' MNZHIKSU�˒����O���㐔
		'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g MNZHIKSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ATZHIKSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g UODSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If UODSU - ATZHIKSU + MNZHIKSU - URISU < 0 Then
			Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 4) '�󒍐��A���͎󒍎c���𒴂��鐔�ʂ͓��͂ł��܂���B
			'UPGRADE_WARNING: �I�u�W�F�N�g URISU_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URISU_CHECK = -1
			Exit Function
		End If
		
		' ���ʂO�͓��͕s��
		'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If URISU = 0 Then
			Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 5) '���ʃ[���͓��͂ł��܂���B
			'UPGRADE_WARNING: �I�u�W�F�N�g URISU_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URISU_CHECK = -1
			Exit Function
		End If
		
		'''' ADD 2008/11/28  FKS) S.Nakajima    Start
		
		'�o�א��s��v�G���[
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		intDe = CShort(DE_INDEX)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_JDNLINNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strJdnLinno = Trim(CStr(RD_SSSMAIN_JDNLINNO(intDe)))
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_JDNNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strJdnNo = Trim(CStr(RD_SSSMAIN_JDNNO(intDe)))
		strSQL = ""
		strSQL = strSQL & "SELECT MAX(DATNO) FROM JDNTHA"
		strSQL = strSQL & " WHERE JDNNO = '" & strJdnNo & "'"
		Call DB_GetSQL2(DBN_JDNTHA, strSQL)
		strJdnDatno = VB6.Format(DB_ExtNum.ExtNum(0), "0000000000")
		
		strSQL = ""
		strSQL = strSQL & "SELECT * FROM JDNTRA "
		strSQL = strSQL & " WHERE DATNO = '" & strJdnDatno & "'"
		strSQL = strSQL & "   AND LINNO = " & "'" & strJdnLinno & "'"
		Call DB_GetSQL2(DBN_JDNTRA, strSQL)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_DATNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strDatNo = Trim(CStr(RD_SSSMAIN_DATNO(-1)))
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_LINNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strLinno = "0" & Trim(CStr(RD_SSSMAIN_LINNO(intDe)))
		strSQL = ""
		strSQL = strSQL & "SELECT * FROM UDNTRA "
		strSQL = strSQL & " WHERE DATNO = '" & strDatNo & "'"
		strSQL = strSQL & "   AND LINNO = " & "'" & strLinno & "'"
		Call DB_GetSQL2(DBN_UDNTRA, strSQL)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If DB_JDNTRA.OTPSU - DB_JDNTRA.URISU + DB_UDNTRA.URISU < CDec(URISU) And DB_JDNTRA.ZAIKB = "1" Then
			Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52_1", 7) '�o�א��s��v�̂��߁A����o�^�o���܂���B
			'UPGRADE_WARNING: �I�u�W�F�N�g URISU_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URISU_CHECK = -1
			Exit Function
		End If
		
		
		'''' ADD 2008/11/28  FKS) S.Nakajima    End
		
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g SERIKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SERIKB = "1" Then
			strSQL = ""
			strSQL = strSQL & "SELECT COUNT(*) FROM SRAET53"
			strSQL = strSQL & " WHERE RPTCLTID = " & "'" & SSS_CLTID.Value & "'"
			strSQL = strSQL & "   AND PRGID    = " & "'" & SSS_PrgId & "'"
			'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "   AND HINCD    = " & "'" & HINCD & "'"
			'2008/1/22 FKS)ichihara CHG START
			'FJCL�C�����̔��f�i377�Č����j
			''''''''strSQL = strSQL & "   AND SBNNO    = " & "'" & SBNNO & "'"
			'UPGRADE_WARNING: �I�u�W�F�N�g SBNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "   AND SBNNO    = " & "'" & SBNNO & "'" '2008/01/17 ����
			'2008/1/22 FKS)ichihara CHG START
			
			strSQL = strSQL & "   AND CHKFLG   = '1'"
			Call DB_GetSQL2(DBN_SRAET53, strSQL)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If URISU < DB_ExtNum.ExtNum(0) Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 4) '�ԕi���ȏ�̼رق��o�^
				'UPGRADE_WARNING: �I�u�W�F�N�g URISU_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				URISU_CHECK = -1
			End If
		End If
		
	End Function
	
	Function URISU_Slist(ByRef PP As clsPP, ByVal SBNSU As Object, ByVal UDNDT As Object, ByVal HINCD As Object, ByVal SBNNO As Object, ByVal SERIKB As Object, ByVal BKTHKKB As Object, ByVal UODSU As Object, ByVal ATZHIKSU As Object, ByVal MNZHIKSU As Object, ByVal DE_INDEX As Object) As Object
		Dim I As Short
		Dim EXEPATH As String
		Dim strSQL As String
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call DP_SSSMAIN_URISU(DE_INDEX, RD_SSSMAIN_SBNSU(DE_INDEX))
		
		'2008/2/5 FKS)ichihara CHG START
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URIKJN(-1) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If RD_SSSMAIN_URIKJN(-1) = "02" Or RD_SSSMAIN_URIKJN(-1) = "04" Then
			'������A�H��������̎��̓V���A�����o�^��ʂ͕\�����Ȃ�
			'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISU() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
			Exit Function
		End If
		'2008/2/5 FKS)ichihara CHG END
		
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SERIKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(RD_SSSMAIN_URISU(DE_INDEX)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If (SSSVal(RD_SSSMAIN_URISU(DE_INDEX)) = 0) Or (SERIKB = "9") Or Trim(HINCD) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISU() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
			Exit Function
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(RD_SSSMAIN_URISU(DE_INDEX)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(RD_SSSMAIN_URISU(DE_INDEX)) = 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISU() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
			Exit Function
		End If
		' �����s�敪�i1�F���͉A9�F�s�j���s�@����
		' �󒍐��ʂƈقȂ���͔��㐔�ʂ���͂����ꍇ�G���[
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g MNZHIKSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ATZHIKSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g UODSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g BKTHKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(BKTHKKB) = "9" And (UODSU - ATZHIKSU + MNZHIKSU) <> RD_SSSMAIN_URISU(DE_INDEX) Then
			Exit Function
		End If
		
		' �󒍐��A���͎󒍎c���𒴂��鐔�ʓ��͕s��
		' ATZHIKSU�˔���ςݐ�
		' MNZHIKSU�˒����O���㐔
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISU(DE_INDEX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g MNZHIKSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ATZHIKSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g UODSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If UODSU - ATZHIKSU + MNZHIKSU - RD_SSSMAIN_URISU(DE_INDEX) < 0 Then
			Exit Function
		End If
		
		'    Link_Index = Index
		'    mm_OPT2 = True
		'    FR_SSSMAIN.BD_URISU(Index).MousePointer = 11
		'    Call Link_Shell("BMNMT51")
		'    Shell (AE_AppPath$ & "\SRAET51.EXE /RPTCLTID:" & SSS_CLTID _
		''                & " /JDNNO:" & Trim(JDNNO) & " /JDNLINNO:" & JDNLINNO & " /HINCD:" & Trim(HINCD) & " /URISU:" & URISU)
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISU(DE_INDEX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SBNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		EXEPATH = AE_AppPath & "SRAET53.EXE /RPTCLTID:" & SSS_CLTID.Value & " /PRGID:" & SSS_PrgId & " /HINCD:" & Trim(HINCD) & " /SBNNO:" & Trim(SBNNO) & " /URISU:" & RD_SSSMAIN_URISU(DE_INDEX)
		I = VBEXEC1(FR_SSSMAIN.Handle.ToInt32, 1, EXEPATH)
		'    FR_SSSMAIN.BD_URISU(Index).MousePointer = 2
		'    mm_OPT2 = False
		'
		strSQL = ""
		strSQL = strSQL & "SELECT COUNT(*) FROM SRAET53"
		strSQL = strSQL & " WHERE RPTCLTID = " & "'" & SSS_CLTID.Value & "'"
		strSQL = strSQL & "   AND PRGID    = " & "'" & SSS_PrgId & "'"
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "   AND HINCD    = " & "'" & HINCD & "'"
		
		'2008/1/22 FKS)ichihara CHG START
		'FJCL�C�����̔��f�i377�Č����j
		''''strSQL = strSQL & "   AND SBNNO    = " & "'" & SBNNO & "'"
		'UPGRADE_WARNING: �I�u�W�F�N�g SBNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "   AND SBNNO    = " & "'" & SBNNO & "'" '2008/01/17 ����
		'2008/1/22 FKS)ichihara CHG END
		
		Call DB_GetSQL2(DBN_SRAET53, strSQL)
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call DP_SSSMAIN_SBNSU(DE_INDEX, DB_ExtNum.ExtNum(0))
		
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISU() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
		
	End Function
End Module