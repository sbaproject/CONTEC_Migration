Option Strict Off
Option Explicit On
Module SRANO_F51
	'
	' �X���b�g��        : �V���A��No�E��ʍ��ڃX���b�g
	' ���j�b�g��        : SRANO.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/09/08
	' �g�p�v���O������  : URIET54
	
	'�V���A��No�����͂��ꂽ�ꍇ�ɁA���̃`�F�b�N���s���B
	Function SRANO_CheckC(ByRef SRANO As Object, ByRef PP As clsPP, ByRef CP_SRANO As clsCP, ByVal CX_SOUCD As Object) As Object
		Dim Rtn As Object
		
		'20090115 ADD START RISE)Tanimura '�A���[No.523
		Dim strSQL As String
		Dim wkDATNO As String
		'20090115 ADD END   RISE)Tanimura
		
		' === 20141216 === INSERT S - FWEST)Koroyasu �A���[HAN20141010-01
		Dim wkLINNO As String
		' === 20141216 === INSERT E -
		
		'�V���A�����o�^���[�N�̍폜
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		Call DB_GetGrEq(DBN_SRAET52, 1, SSS_CLTID.Value, BtrNormal)
		Do While (DBSTAT = 0) And (Trim(DB_SRAET52.RPTCLTID) = Trim(SSS_CLTID.Value))
			Call DB_Delete(DBN_SRAET52)
			Call DB_GetNext(DBN_SRAET52, BtrNormal)
		Loop 
		Call DB_EndTransaction()
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SRANO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SRANO_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g SRANO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(SRANO) = "" Then
			'�ԍ�����(or 0)�ɕύX���ꂽ����, ����������ꍇ
			'�P�Ȃ�G���[�ł悯��΂��� If�u���b�N�͕s�v
			SSS_LASTKEY.Value = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Rtn = AE_ChOprtLater(PP, 15) '�\����ǉ����[�h�Ɉڍs
			Exit Function
		End If
		
		'�V���A���Ǘ��e�[�u���擾
		Call DB_GetEq(DBN_SRACNTTB, 1, SRANO, BtrNormal)
		If DBSTAT = 0 Then
			'������擾
			Call DB_GetLsEq(DBN_UDNTRA, 11, "1" & "1" & DB_SRACNTTB.RSTDT & DB_SRACNTTB.HINCD & DB_SRACNTTB.SBNNO & "9999999999", BtrNormal)
			If (DBSTAT = 0) And (DB_UDNTRA.DATKB = "1") And (DB_UDNTRA.AKAKROKB = "1") And (DB_UDNTRA.UDNDT = DB_SRACNTTB.RSTDT) And (DB_UDNTRA.HINCD = DB_SRACNTTB.HINCD) And (DB_UDNTRA.SBNNO = DB_SRACNTTB.SBNNO) Then
				
				' === 20141216 === INSERT S - FWEST)Koroyasu �A���[HAN20141010-01
				strSQL = ""
				strSQL = strSQL & "SELECT"
				strSQL = strSQL & "  MAX(DATNO) "
				strSQL = strSQL & "FROM"
				strSQL = strSQL & "  UDNTRA A "
				strSQL = strSQL & "   , ("
				strSQL = strSQL & "      SELECT"
				strSQL = strSQL & "        MAX(UWRTDT) UWRTDT "
				strSQL = strSQL & "      FROM"
				strSQL = strSQL & "        UDNTRA"
				strSQL = strSQL & "      WHERE"
				strSQL = strSQL & "        DATKB = '1' "
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        AKAKROKB = '1' "
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        UDNNO = '" & DB_UDNTRA.UDNNO & "' "
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        LINNO = '" & DB_UDNTRA.LINNO & "' "
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        HINCD = '" & DB_UDNTRA.HINCD & "' "
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        SBNNO = '" & DB_UDNTRA.SBNNO & "' "
				strSQL = strSQL & "     ) B "
				strSQL = strSQL & "WHERE"
				strSQL = strSQL & "  A.DATKB = '1' "
				strSQL = strSQL & "AND"
				strSQL = strSQL & "  A.AKAKROKB = '1' "
				strSQL = strSQL & "AND"
				strSQL = strSQL & "  A.UDNNO = '" & DB_UDNTRA.UDNNO & "' "
				strSQL = strSQL & "AND"
				strSQL = strSQL & "  A.LINNO = '" & DB_UDNTRA.LINNO & "' "
				strSQL = strSQL & "AND"
				strSQL = strSQL & "  A.HINCD = '" & DB_UDNTRA.HINCD & "' "
				strSQL = strSQL & "AND"
				strSQL = strSQL & "  A.SBNNO = '" & DB_UDNTRA.SBNNO & "' "
				strSQL = strSQL & "AND"
				strSQL = strSQL & "  A.UWRTDT = B.UWRTDT "
				strSQL = strSQL & "AND"
				strSQL = strSQL & "  A.UWRTTM = ( SELECT "
				strSQL = strSQL & "                 MAX(UWRTTM) "
				strSQL = strSQL & "               FROM"
				strSQL = strSQL & "                 UDNTRA"
				strSQL = strSQL & "               WHERE"
				strSQL = strSQL & "                 DATKB = '1' "
				strSQL = strSQL & "               AND"
				strSQL = strSQL & "                 AKAKROKB = '1' "
				strSQL = strSQL & "               AND"
				strSQL = strSQL & "                 UDNNO = '" & DB_UDNTRA.UDNNO & "' "
				strSQL = strSQL & "               AND"
				strSQL = strSQL & "                 LINNO = '" & DB_UDNTRA.LINNO & "' "
				strSQL = strSQL & "               AND"
				strSQL = strSQL & "                 HINCD = '" & DB_UDNTRA.HINCD & "' "
				strSQL = strSQL & "               AND"
				strSQL = strSQL & "                 SBNNO = '" & DB_UDNTRA.SBNNO & "' "
				strSQL = strSQL & "               AND"
				strSQL = strSQL & "                 UWRTDT = B.UWRTDT "
				strSQL = strSQL & "             ) "
				
				Call DB_GetSQL2(DBN_UDNTRA, strSQL)
				
				wkDATNO = VB6.Format(DB_ExtNum.ExtNum(0), "0000000000")
				
				wkLINNO = DB_UDNTRA.LINNO
				
				Call UDNTRA_RClear()
				
				Call DB_GetLsEq(DBN_UDNTRA, 1, wkDATNO & wkLINNO, BtrNormal)
				' === 20141216 === INSERT E -
				
				'2007/03/21 UPD-START
				'            If Trim$(DB_UDNTRA.HENRSNCD) <> "" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_UDNTRA.CASSU) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Trim(DB_UDNTRA.HENRSNCD) <> "" And SSSVal(DB_UDNTRA.CASSU) = 0 Then
					'2007/03/21 UPD-END
					'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 6) '���ɕԕi�ς݂̈׃G���[
					'UPGRADE_WARNING: �I�u�W�F�N�g SRANO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					SRANO_CheckC = -1
					Exit Function
				End If
				
				If DB_UDNTRA.ZAIKB = "9" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 0) '�݌ɊǗ��Ȃ��̈׃G���[
					'UPGRADE_WARNING: �I�u�W�F�N�g SRANO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					SRANO_CheckC = -1
					Exit Function
				End If
				''''2007.03.14 DEL
				''''        If (DB_UDNTRA.JKESIKN = 0) And (DB_UDNTRA.FKESIKN = 0) Then
				''''        Else
				''''            Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 2)  '�����ς݂̈׃G���[
				''''            SRANO_CheckC = -1
				''''            Exit Function
				''''        End If
				''''2007.03.14 DEL
				
				''20090527 DEL START FKS)NAKATA
				''20090413 ADD START FKS)NAKATA �A���[��FC09041401
				''������������Ă���ꍇ�A�ԕi�s��
				'            If (DB_UDNTRA.JKESIKN = 0) And (DB_UDNTRA.FKESIKN = 0) Then
				'            Else
				'                Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 2)  '�����ς݂̈׃G���[
				'                SRANO_CheckC = -1
				'                Exit Function
				'            End If
				''20090413 ADD E.N.D FKS)NAKATA
				''20090527 DEL E.N.D FKS)NAKATA
				
				'2008/1/22 FKS)ichihara CHG START
				'������̔���̕ԕi���Ƃ���
				''2007/08/23 ADD-START   ������̔���͕ԕi�s�`�F�b�N
				'            Call DB_GetEq(DBN_UDNTHA, 1, DB_UDNTRA.DATNO, BtrNormal)
				'            If DBSTAT = 0 Then
				'                If DB_UDNTHA.URIKJN = "02" Then
				'                    '2007/12/06 FKS)minamoto CHG START
				'                    'Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 8)  '������̔���̈׃G���[
				'                    Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54_002", 0)  '������̔���̈׃G���[
				'                    '2007/12/06 FKS)minamoto CHG START
				'                    SRANO_CheckC = -1
				'                    Exit Function
				'                End If
				'            Else
				'                Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 1)  '�Y������f�[�^�Ȃ��̈׃G���[
				'                SRANO_CheckC = -1
				'                Exit Function
				'            End If
				''2007/08/23 ADD-END�@   ������̔���͕ԕi�s�`�F�b�N
				'2008/1/22 FKS)ichihara CHG END
				
				'20090115 ADD START RISE)Tanimura '�A���[No.523
				g_strURIKB = "1"
				'20090115 ADD END   RISE)Tanimura
				
				SSS_LASTKEY.Value = DB_UDNTRA.DATNO & DB_UDNTRA.LINNO
				'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Rtn = AE_ChOprtLater(PP, 15) '�\����ǉ����[�h�Ɉڍs
				WG_DSPKB = 1
			Else
				'20090115 ADD START RISE)Tanimura '�A���[No.523
				' �o�׎��ю擾
				strSQL = ""
				strSQL = strSQL & "SELECT"
				strSQL = strSQL & "  * "
				strSQL = strSQL & "FROM"
				strSQL = strSQL & "  ("
				strSQL = strSQL & "   SELECT"
				strSQL = strSQL & "     A.*"
				strSQL = strSQL & "   FROM"
				strSQL = strSQL & "     ODNTRA A"
				strSQL = strSQL & "   , ("
				strSQL = strSQL & "      SELECT"
				strSQL = strSQL & "        B2.*"
				strSQL = strSQL & "      FROM"
				strSQL = strSQL & "        JDNTHA B1"
				strSQL = strSQL & "      , JDNTRA B2"
				strSQL = strSQL & "      WHERE"
				strSQL = strSQL & "        B1.DATNO = B2.DATNO"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
				strSQL = strSQL & "                                 SELECT"
				strSQL = strSQL & "                                   MAX(DATNO) DATNO"
				strSQL = strSQL & "                                 , LINNO      LINNO"
				strSQL = strSQL & "                                 FROM"
				strSQL = strSQL & "                                   JDNTRA"
				strSQL = strSQL & "                                 GROUP BY"
				strSQL = strSQL & "                                   JDNNO"
				strSQL = strSQL & "                                 , LINNO"
				strSQL = strSQL & "                                )"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B2.OTPSU > B2.URISU"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
				strSQL = strSQL & "      AND"
				' === 20110305 === UPDATE S TOM)Morimoto �C�O�V�X�e���K�p
				'            strSQL = strSQL & "        B1.FRNKB = '0'"
				strSQL = strSQL & "       (B1.FRNKB = '0'"
				strSQL = strSQL & "        OR ("
				strSQL = strSQL & "                  B1.FRNKB   = '1' "
				strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
				strSQL = strSQL & "           )"
				strSQL = strSQL & "       )"
				' === 20110305 === UPDATE E TOM)Morimoto
				strSQL = strSQL & "     ) B "
				strSQL = strSQL & "   WHERE"
				strSQL = strSQL & "     A.JDNNO = B.JDNNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DATKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DENKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.OTPSU > 0"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.SBNNO = '" & DB_SRACNTTB.SBNNO & "'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.HINCD = '" & DB_SRACNTTB.HINCD & "'"
				strSQL = strSQL & "  ) "
				
				Call DB_GetSQL2(DBN_ODNTRA, strSQL)
				If (DBSTAT = 0) And (DB_ODNTRA.DATKB = "1") And (DB_ODNTRA.DENKB = "1") And (DB_SRACNTTB.ZAISYOBN = "02") And (DB_ODNTRA.HINCD = DB_SRACNTTB.HINCD) And (DB_ODNTRA.SBNNO = DB_SRACNTTB.SBNNO) Then
					Call JDNTRA_RClear()
					
					strSQL = ""
					strSQL = strSQL & "SELECT"
					strSQL = strSQL & "  MAX(DATNO) "
					strSQL = strSQL & "FROM"
					strSQL = strSQL & "  JDNTRA "
					strSQL = strSQL & "WHERE"
					strSQL = strSQL & "  JDNNO = '" & DB_ODNTRA.JDNNO & "' "
					strSQL = strSQL & "AND"
					strSQL = strSQL & "  LINNO = '" & DB_ODNTRA.JDNLINNO & "' "
					
					Call DB_GetSQL2(DBN_JDNTRA, strSQL)
					
					wkDATNO = VB6.Format(DB_ExtNum.ExtNum(0), "0000000000")
					
					Call JDNTRA_RClear()
					
					Call DB_GetEq(DBN_JDNTRA, 1, wkDATNO & DB_ODNTRA.JDNLINNO, BtrNormal)
					
					If DB_JDNTRA.ZAIKB = "9" Then
						'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 0) '�݌ɊǗ��Ȃ��̈׃G���[
						'UPGRADE_WARNING: �I�u�W�F�N�g SRANO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						SRANO_CheckC = -1
						Exit Function
					End If
					
					g_strURIKB = "2"
					
					SSS_LASTKEY.Value = DB_ODNTRA.DATNO & DB_ODNTRA.LINNO
					'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Rtn = AE_ChOprtLater(PP, 15) '�\����ǉ����[�h�Ɉڍs
					WG_DSPKB = 1
				Else
					'20090115 ADD END   RISE)Tanimura
					'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 1) '�Y������f�[�^�Ȃ��̈׃G���[
					'UPGRADE_WARNING: �I�u�W�F�N�g SRANO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					SRANO_CheckC = -1
					Exit Function
					'20090115 ADD START RISE)Tanimura '�A���[No.523
				End If
				'20090115 ADD END   RISE)Tanimura
			End If
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '�Y�����R�[�h����
			'UPGRADE_WARNING: �I�u�W�F�N�g SRANO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SRANO_CheckC = -1
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SRANO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SRANO_CheckC = 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g SRANO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			svSRANO = SRANO
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If PP.SlistCom Is System.DBNull.Value Then
				SetFirst = True
			Else
				SetFirst = False
			End If
		End If
		
	End Function
	
	Function SRANO_InitVal(ByVal SRANO As Object, ByRef PP As clsPP, ByRef CP_SRANO As clsCP) As Object
		
		'    SRANO_InitVal = SRANO
		
	End Function
End Module