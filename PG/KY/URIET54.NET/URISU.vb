Option Strict Off
Option Explicit On
Module URISU_F52
	'
	' �X���b�g��        : �ԕi���ʁE��ʍ��ڃX���b�g
	' ���j�b�g��        : URISU.F52
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/09/11
	' �g�p�v���O������  : URIET54
	'
	Function URISU_Check(ByVal URISU As Object, ByVal SURYO As Object, ByVal SBNSU As Object, ByVal CASSU As Object, ByVal ODNDT As Object, ByVal HINCD As Object, ByVal HINID As Object, ByVal SBNNO As Object, ByVal SERIKB As Object, ByVal DE_INDEX As Object) As Object
		
		Dim Rtn As Short
		Dim strSQL As String
		'2007/11/28 FKS)minamoto ADD START
		Dim strJDNNO As String
		'2007/11/28 FKS)minamoto ADD END
		'2007/12/04 FKS)minamoto ADD START
		Dim lngOUTSMSU As Integer
		Dim lngHenpinSU As Integer
		'2007/12/04 FKS)minamoto ADD END
		'2007/12/20 FKS)minamoto ADD START
		Dim lngChgHINCD As Integer
		'2007/12/20 FKS)minamoto ADD END
		
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call DP_SSSMAIN_SBNSU(DE_INDEX, URISU)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g URISU_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		URISU_Check = 0
		
		''''2007/03/21 UPD-START
		''''If URISU > RD_SSSMAIN_SURYO(DE_INDEX) Then
		''''    Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 3)  '�ԕi���ȏ�̈׃G���[
		''''    URISU_Check = -1
		''''    Exit Function
		''''End If
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(RD_SSSMAIN_CASSU(DE_INDEX)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(RD_SSSMAIN_CASSU(DE_INDEX)) = 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SURYO(DE_INDEX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If URISU > RD_SSSMAIN_SURYO(DE_INDEX) Then
				'20090115 ADD START RISE)Tanimura '�A���[No.523
				' ����ς̏ꍇ
				If g_strURIKB = "1" Then
					'20090115 ADD END   RISE)Tanimura
					Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 8) '���㐔�ȏ�̈׃G���[
					'20090115 ADD START RISE)Tanimura '�A���[No.523
				Else
					Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54_006", 0) '�o�א��ȏ�̕ԕi���͓��͂ł��܂���
				End If
				'20090115 ADD END   RISE)Tanimura
				'UPGRADE_WARNING: �I�u�W�F�N�g URISU_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				URISU_Check = -1
				Exit Function
			End If
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_CASSU(DE_INDEX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If URISU > RD_SSSMAIN_CASSU(DE_INDEX) Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 8) '���㐔�ȏ�̈׃G���[
				'UPGRADE_WARNING: �I�u�W�F�N�g URISU_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				URISU_Check = -1
				Exit Function
			End If
		End If
		''''2007/03/21 UPD-END
		
		'�y�ʔ́z�y�сy�V�X�e���ŏ������i�z���A�Z�o�������
		'''' UPD 2012/06/05  FWEST) T.Yamamoto    Start    �A���[��FC12060501
		'    If (Trim(WG_JDNINKB) = "2") Or (Trim(WG_SYSTEM) = "M" And Trim(HINID) = "06") Then
		'�ʔ̂ŁA�����s�ǂ̏ꍇ�͈ꕔ�ԕi�Ƃ���
		'UPGRADE_WARNING: �I�u�W�F�N�g HINID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HENRSNCD(DE_INDEX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If (Trim(WG_JDNINKB) = "2" And RD_SSSMAIN_HENRSNCD(DE_INDEX) <> "15") Or (Trim(WG_SYSTEM) = "M" And Trim(HINID) = "06") Then
			'''' UPD 2012/06/05  FWEST) T.Yamamoto    End
			'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If URISU <> 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SURYO(DE_INDEX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If URISU <> RD_SSSMAIN_SURYO(DE_INDEX) Then
					Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 7) '�ԕi���ȏ�̈׃G���[
					'UPGRADE_WARNING: �I�u�W�F�N�g URISU_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					URISU_Check = -1
					Exit Function
				End If
			End If
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SERIKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SERIKB = "1" Then
			strSQL = ""
			strSQL = strSQL & "SELECT COUNT(*) FROM SRAET52"
			strSQL = strSQL & " WHERE RPTCLTID = " & "'" & SSS_CLTID.Value & "'"
			'UPGRADE_WARNING: �I�u�W�F�N�g ODNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "   AND RSTDT    = " & "'" & VB6.Format(ODNDT, "YYYYMMDD") & "'"
			'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "   AND HINCD    = " & "'" & HINCD & "'"
			'UPGRADE_WARNING: �I�u�W�F�N�g SBNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "   AND SBNNO    = " & "'" & SBNNO & "'"
			Call DB_GetSQL2(DBN_SRAET52, strSQL)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If URISU < DB_ExtNum.ExtNum(0) Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 4) '�ԕi���ȏ�̼رق��o�^
				'UPGRADE_WARNING: �I�u�W�F�N�g URISU_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				URISU_Check = -1
			End If
		End If
		
		'20090115 ADD START RISE)Tanimura '�A���[No.523
		' ����ς̏ꍇ
		If g_strURIKB = "1" Then
			'20090115 ADD END   RISE)Tanimura
			'2007/11/28 FKS)minamoto ADD START
			'�����s�ǂȂ��֏o�ɍϐ��𒴂��Ȃ�
			
			'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HENRSNCD(DE_INDEX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If RD_SSSMAIN_HENRSNCD(DE_INDEX) = "15" Then
				'�󒍔ԍ�����
				
				'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_JDNNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strJDNNO = RD_SSSMAIN_JDNNO(DE_INDEX)
				'2007/12/20 FKS)minamoto ADD START
				' ���ԏo�Ƀt�@�C���̕i�ԈႢ�����擾
				strSQL = ""
				strSQL = strSQL & "SELECT COUNT(*) FROM SBNTRA"
				strSQL = strSQL & " WHERE ORGSBNNO    = " & "'" & strJDNNO & "'"
				'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & "   AND HINCD    <> " & "'" & HINCD & "'"
				strSQL = strSQL & "   AND DATKB = '1'"
				Call DB_GetSQL2(DBN_SRAET52, strSQL)
				lngChgHINCD = DB_ExtNum.ExtNum(0)
				If lngChgHINCD > 0 Then
					Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54_003", 0) '���i�R�[�h���قȂ�܂����A��낵���ł����H
					If Rtn <> MsgBoxResult.Yes Then
						'UPGRADE_WARNING: �I�u�W�F�N�g URISU_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						URISU_Check = -1
						Exit Function
					End If
				End If
				'2007/12/20 FKS)minamoto ADD END
				' ���ԏo�Ƀt�@�C������o�ɍϐ����擾
				
				strSQL = ""
				strSQL = strSQL & "SELECT SUM(OUTSMSU) FROM SBNTRA"
				'2007/12/17 FKS)minamoto CHG START
				'strSQL = strSQL & " WHERE HINCD    = " & "'" & HINCD & "'"
				'2007/12/20 FKS)minamoto DEL START
				'strSQL = strSQL & " WHERE TOKCD    = " & "'" & RD_SSSMAIN_TOKCD(DE_INDEX) & "'"
				'2007/12/20 FKS)minamoto DEL END
				'2007/12/17 FKS)minamoto CHG END
				'2007/12/20 FKS)minamoto CHG START
				'strSQL = strSQL & "   AND ORGSBNNO    = " & "'" & strJDNNO & "'"
				strSQL = strSQL & " WHERE ORGSBNNO    = " & "'" & strJDNNO & "'"
				'2007/12/20 FKS)minamoto CHG END
				strSQL = strSQL & "   AND DATKB = '1'"
				Call DB_GetSQL2(DBN_SRAET52, strSQL)
				lngOUTSMSU = DB_ExtNum.ExtNum(0)
				'2007/12/04 FKS)minamoto ADD START
				' �����s�ǃe�[�u������ԕi�����擾
				
				strSQL = ""
				strSQL = strSQL & "SELECT SUM(ABS(URISU)) FROM SKFTRA"
				'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & " WHERE HINCD    = " & "'" & HINCD & "'"
				strSQL = strSQL & "   AND SBNNO    = " & "'" & strJDNNO & "'"
				strSQL = strSQL & "   AND DATKB = '1'"
				Call DB_GetSQL2(DBN_SRAET52, strSQL)
				lngHenpinSU = DB_ExtNum.ExtNum(0)
				'2007/12/04 FKS)minamoto ADD END
				
				'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If URISU > lngOUTSMSU - lngHenpinSU Then
					Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 9) '��֏o�ɍϐ��𒴂��Ă��܂��B
					'UPGRADE_WARNING: �I�u�W�F�N�g URISU_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					URISU_Check = -1
				End If
			End If
			'2007/11/28 FKS)minamoto ADD END
			'20090115 ADD START RISE)Tanimura '�A���[No.523
		End If
		'20090115 ADD END   RISE)Tanimura
	End Function
	
	Function URISU_Slist(ByRef PP As clsPP, ByVal SBNSU As Object, ByVal ODNDT As Object, ByVal HINCD As Object, ByVal SBNNO As Object, ByVal SERIKB As Object, ByVal DE_INDEX As Object) As Object
		Dim I As Short
		Dim EXEPATH As String
		Dim strSQL As String
		
		
		'2008/08/06 ADD START FKS)NAKATA
		''�V���A���������ւ̃p�����[�^(�󒍔ԍ�)
		Dim strJDNNO As String
		
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_JDNLINNO(DE_INDEX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_JDNNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strJDNNO = Left(RD_SSSMAIN_JDNNO(DE_INDEX), 6) & RD_SSSMAIN_JDNLINNO(DE_INDEX)
		
		'2008/08/06 ADD E.N.D FKS)NAKATA
		
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g SERIKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SERIKB = "9" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISU() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
			Exit Function
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call DP_SSSMAIN_URISU(DE_INDEX, RD_SSSMAIN_SBNSU(DE_INDEX))
		
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(RD_SSSMAIN_URISU(DE_INDEX)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(RD_SSSMAIN_URISU(DE_INDEX)) = 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISU() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
			Exit Function
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SURYO(DE_INDEX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISU(DE_INDEX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If RD_SSSMAIN_URISU(DE_INDEX) > RD_SSSMAIN_SURYO(DE_INDEX) Then
			Exit Function
		End If
		
		'    Link_Index = Index
		'    mm_OPT2 = True
		'    FR_SSSMAIN.BD_URISU(Index).MousePointer = 11
		'    Call Link_Shell("BMNMT51")
		'    Shell (AE_AppPath$ & "\SRAET51.EXE /RPTCLTID:" & SSS_CLTID _
		''                & " /JDNNO:" & Trim(JDNNO) & " /JDNLINNO:" & JDNLINNO & " /HINCD:" & Trim(HINCD) & " /URISU:" & URISU)
		
		
		'2008/08/06 CHG START FKS)NAKATA
		''�V���A��������ʂɓn���p�����[�^���󒍔ԍ��ɕύX
		
		''    EXEPATH = AE_AppPath$ & "SRAET52.EXE /RPTCLTID:" & SSS_CLTID _
		'''            & " /RSTDT:" & Format(ODNDT, "YYYYMMDD") & " /HINCD:" & Trim(HINCD) _
		'''            & " /SBNNO:" & Trim(SBNNO) & " /URISU:" & RD_SSSMAIN_URISU(DE_INDEX)
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISU(DE_INDEX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SBNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		EXEPATH = AE_AppPath & "SRAET52.EXE /RPTCLTID:" & SSS_CLTID.Value & " /JDNNO:" & Trim(strJDNNO) & " /HINCD:" & Trim(HINCD) & " /SBNNO:" & Trim(SBNNO) & " /URISU:" & RD_SSSMAIN_URISU(DE_INDEX)
		'2008/08/06 CHG E.N.D FKS)NAKATA
		
		
		I = VBEXEC1(FR_SSSMAIN.Handle.ToInt32, 1, EXEPATH)
		'    FR_SSSMAIN.BD_URISU(Index).MousePointer = 2
		'    mm_OPT2 = False
		'
		
		'20080910 ADD START RISE)Tanimura '�r������
		Dim M_SRAET52_inf() As M_TYPE_SRAET52_MOTO
		Dim intIndex As Short
		
		Erase M_SRAET52_inf
		
		strSQL = ""
		strSQL = strSQL & "SELECT"
		strSQL = strSQL & "  SRANO "
		strSQL = strSQL & "FROM"
		strSQL = strSQL & "  SRAET52 "
		strSQL = strSQL & "WHERE"
		strSQL = strSQL & "  RPTCLTID = " & "'" & SSS_CLTID.Value & "' "
		strSQL = strSQL & "AND"
		'UPGRADE_WARNING: �I�u�W�F�N�g ODNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "  RSTDT    = " & "'" & VB6.Format(ODNDT, "YYYYMMDD") & "' "
		strSQL = strSQL & "AND"
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "  HINCD    = " & "'" & HINCD & "' "
		strSQL = strSQL & "AND"
		'UPGRADE_WARNING: �I�u�W�F�N�g SBNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "  SBNNO    = " & "'" & SBNNO & "' "
		strSQL = strSQL & "ORDER BY"
		strSQL = strSQL & "  SRANO    ASC "
		
		Call DB_GetSQL2(DBN_SRAET52, strSQL)
		
		intIndex = 0
		
		' �_�~�[�쐬
		ReDim Preserve M_SRAET52_inf(intIndex)
		
		Do While (DBSTAT = 0)
			intIndex = intIndex + 1
			
			ReDim Preserve M_SRAET52_inf(intIndex)
			
			With M_SRAET52_inf(intIndex)
				.SRANO = DB_SRAET52.SRANO
			End With
			
			Call DB_GetNext(DBN_SRAET52, BtrNormal)
		Loop 
		
		
		intIndex = 0
		
		' �ޔ����Ă���V���A���Ǘ��e�[�u���̓��e���폜����
		Erase M_SRACNTTB_MOTO_inf
		
		' �_�~�[�쐬
		ReDim Preserve M_SRACNTTB_MOTO_inf(intIndex)
		
		For I = 1 To UBound(M_SRAET52_inf)
			strSQL = ""
			strSQL = strSQL & "SELECT"
			strSQL = strSQL & "  SRANO "
			strSQL = strSQL & ", OPEID "
			strSQL = strSQL & ", CLTID "
			strSQL = strSQL & ", WRTTM "
			strSQL = strSQL & ", WRTDT "
			strSQL = strSQL & ", UOPEID "
			strSQL = strSQL & ", UCLTID "
			strSQL = strSQL & ", UWRTTM "
			strSQL = strSQL & ", UWRTDT "
			strSQL = strSQL & "FROM"
			strSQL = strSQL & "  SRACNTTB "
			strSQL = strSQL & "WHERE"
			strSQL = strSQL & "  SRANO = " & "'" & M_SRAET52_inf(I).SRANO & "' "
			
			Call DB_GetSQL2(DBN_SRACNTTB, strSQL)
			
			intIndex = intIndex + 1
			
			ReDim Preserve M_SRACNTTB_MOTO_inf(intIndex)
			
			With M_SRACNTTB_MOTO_inf(intIndex)
				.SRANO = M_SRAET52_inf(I).SRANO
				.OPEID = DB_SRACNTTB.OPEID
				.CLTID = DB_SRACNTTB.CLTID
				.WRTTM = DB_SRACNTTB.WRTTM
				.WRTDT = DB_SRACNTTB.WRTDT
				.UOPEID = DB_SRACNTTB.UOPEID
				.UCLTID = DB_SRACNTTB.UCLTID
				.UWRTTM = DB_SRACNTTB.UWRTTM
				.UWRTDT = DB_SRACNTTB.UWRTDT
			End With
		Next I
		'20080910 ADD END   RISE)Tanimura
		
		strSQL = ""
		strSQL = strSQL & "SELECT COUNT(*) FROM SRAET52"
		strSQL = strSQL & " WHERE RPTCLTID = " & "'" & SSS_CLTID.Value & "'"
		'UPGRADE_WARNING: �I�u�W�F�N�g ODNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "   AND RSTDT    = " & "'" & VB6.Format(ODNDT, "YYYYMMDD") & "'"
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "   AND HINCD    = " & "'" & HINCD & "'"
		'UPGRADE_WARNING: �I�u�W�F�N�g SBNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "   AND SBNNO    = " & "'" & SBNNO & "'"
		Call DB_GetSQL2(DBN_SRAET52, strSQL)
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call DP_SSSMAIN_SBNSU(DE_INDEX, DB_ExtNum.ExtNum(0))
		
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISU() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
		
	End Function
End Module