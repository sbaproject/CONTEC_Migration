Option Strict Off
Option Explicit On
Module UDNNO_F51
	'
	' �X���b�g��        : ��No(����ԍ��j�E��ʍ��ڃX���b�g
	' ���j�b�g��        : UDNNO.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/09/09
	' �g�p�v���O������  : URIET54
	'
	
	'�`�[No�����͂��ꂽ�ꍇ�ɁA���̃`�F�b�N���s���B
	Function UDNNO_CheckC(ByRef UDNNO As Object, ByRef PP As clsPP, ByRef CP_UDNNO As clsCP) As Object
		Dim Rtn As Object
		
		'20090115 ADD START RISE)Tanimura '�A���[No.523
		Dim strSQL As String
		Dim wkDATNO As String
		'20090115 ADD END   RISE)Tanimura
		
		SetFirst = True
		
		'�V���A�����o�^���[�N�̍폜
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		Call DB_GetGrEq(DBN_SRAET52, 1, SSS_CLTID.Value, BtrNormal)
		Do While (DBSTAT = 0) And (Trim(DB_SRAET52.RPTCLTID) = Trim(SSS_CLTID.Value))
			Call DB_Delete(DBN_SRAET52)
			Call DB_GetNext(DBN_SRAET52, BtrNormal)
		Loop 
		Call DB_EndTransaction()
		
		'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		UDNNO_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(UDNNO) = "" Then
			'�ԍ�����(or 0)�ɕύX���ꂽ����, ����������ꍇ
			'�P�Ȃ�G���[�ł悯��΂��� If�u���b�N�͕s�v
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			UDNNO_CheckC = -1
			SSS_LASTKEY.Value = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Rtn = AE_ChOprtLater(PP, 15) '�\����ǉ����[�h�Ɉڍs
			Exit Function
		End If
		'20090115 ADD START RISE)Tanimura '�A���[No.523
		' ����ς̏ꍇ
		If g_strURIKB = "1" Then
			'20090115 ADD END   RISE)Tanimura
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DB_GetEq(DBN_UDNTHA, 1, Left(UDNNO, 10), BtrNormal)
			If DBSTAT = 0 Then
				'2008/1/22 FKS)ichihara CHG START
				'������̔���̕ԕi���Ƃ���
				''2007/08/23 ADD-START   ������̔���͕ԕi�s�`�F�b�N
				'        If DB_UDNTHA.URIKJN = "02" Then
				'            '2007/12/06 FKS)minamoto CHG START
				'            'Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 8)  '������̔���̈׃G���[
				'            Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54_002", 0)  '������̔���̈׃G���[
				'            '2007/12/06 FKS)minamoto CHG END
				'            UDNNO_CheckC = -1
				'            Exit Function
				'        End If
				''2007/08/23 ADD-END�@   ������̔���͕ԕi�s�`�F�b�N
				'2008/1/22 FKS)ichihara CHG END
				'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call DB_GetEq(DBN_UDNTRA, 1, Left(UDNNO, 13), BtrNormal)
				If DBSTAT <> 0 Then
					'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '�Y�����R�[�h����
					'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					UDNNO_CheckC = -1
				Else
					'2007/03/21 UPD-START
					'            If Trim$(DB_UDNTRA.HENRSNCD) <> "" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_UDNTRA.CASSU) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Trim(DB_UDNTRA.HENRSNCD) <> "" And SSSVal(DB_UDNTRA.CASSU) = 0 Then
						'2007/03/21 UPD-END
						'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 6) '���ɕԕi�ς݂̈׃G���[
						'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						UDNNO_CheckC = -1
						Exit Function
					End If
					
					If DB_UDNTRA.ZAIKB = "9" Then
						'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 0) '�݌ɊǗ��Ȃ��̈׃G���[
						'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						UDNNO_CheckC = -1
						Exit Function
					End If
					''''2007.03.14 DEL
					''''        If (DB_UDNTRA.JKESIKN = 0) And (DB_UDNTRA.FKESIKN = 0) Then
					''''        Else
					''''            Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 2)  '�����ς݂̈׃G���[
					''''            UDNNO_CheckC = -1
					''''            Exit Function
					''''        End If
					''''2007.03.14 DEL
					
					'20090527 DEL START FKS)NAKATA
					'''20090413 ADD START FKS)NAKATA �A���[��FC09041401
					'''������������Ă���ꍇ�A�ԕi�s��
					''            If (DB_UDNTRA.JKESIKN = 0) And (DB_UDNTRA.FKESIKN = 0) Then
					''            Else
					''                Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 2)  '�����ς݂̈׃G���[
					''                UDNNO_CheckC = -1
					''                Exit Function
					''            End If
					'''20090527 DEL E.N.D FKS)NAKATA
					
					'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					SSS_LASTKEY.Value = Left(UDNNO, Len(DB_UDNTRA.DATNO) + Len(DB_UDNTRA.LINNO))
					'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Rtn = AE_ChOprtLater(PP, 15) '�\����ǉ����[�h�Ɉڍs
					WG_DSPKB = 1
					
				End If
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '�Y�����R�[�h����
				'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				UDNNO_CheckC = -1
			End If
			'20090115 ADD START RISE)Tanimura '�A���[No.523
			' ������̏ꍇ
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DB_GetEq(DBN_ODNTHA, 1, Left(UDNNO, 10), BtrNormal)
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call DB_GetEq(DBN_ODNTRA, 1, Left(UDNNO, 13), BtrNormal)
				If DBSTAT <> 0 Then
					'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '�Y�����R�[�h����
					'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					UDNNO_CheckC = -1
				Else
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
						'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						UDNNO_CheckC = -1
						Exit Function
					End If
					
					'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					SSS_LASTKEY.Value = Left(UDNNO, Len(DB_ODNTRA.DATNO) + Len(DB_ODNTRA.LINNO))
					'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Rtn = AE_ChOprtLater(PP, 15) '�\����ǉ����[�h�Ɉڍs
					WG_DSPKB = 1
				End If
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '�Y�����R�[�h����
				'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				UDNNO_CheckC = -1
			End If
		End If
		'20090115 ADD END   RISE)Tanimura
	End Function
	
	Function UDNNO_Skip(ByRef PP As clsPP, ByRef CP_UDNDT As clsCP, ByVal SRANO As Object, ByRef CT_UDNNO As System.Windows.Forms.Control) As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SRANO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If (SetFirst = False) And (Trim(SRANO) <> "") Then
			SetFirst = True
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			UDNNO_Skip = True
			Call AE_SetFocus(PP, CP_UDNDT.CpPx)
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CT_UDNNO.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CT_UDNNO.SelStart = 23
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			UDNNO_Skip = False
		End If
	End Function
	
	Function UDNNO_Slist(ByRef PP As clsPP, ByVal UDNNO As Object) As Object
		
		DB_PARA(DBN_UDNTRA).KeyNo = 10
		DB_PARA(DBN_UDNTRA).KeyBuf = "1" & "1"
		'20090115 ADD START RISE)Tanimura '�A���[No.523
		DB_PARA(DBN_ODNTRA).KeyNo = 2
		DB_PARA(DBN_ODNTRA).KeyBuf = "1" & "1"
		'20090115 ADD END   RISE)Tanimura
		WLSUDN.ShowDialog()
		WLSUDN.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g UDNNO_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		UDNNO_Slist = PP.SlistCom
		
	End Function
End Module