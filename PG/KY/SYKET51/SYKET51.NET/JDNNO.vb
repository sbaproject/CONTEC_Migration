Option Strict Off
Option Explicit On
Module JDNNO_F52
	'
	' �X���b�g��        : �o�׎w���Ώ�No�E��ʍ��ڃX���b�g
	' ���j�b�g��        : JDNNO.F52
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/07/16
	' �g�p�v���O������  : SYKET51
	'
	Dim NotFirst As Short
	
	'�`�[No�����͂��ꂽ�ꍇ�ɁA���̃`�F�b�N���s���B
	Function JDNNO_Check(ByVal JDNNO As Object, ByVal WRKKB As Object, ByVal FDNDT As Object, ByRef PP As clsPP, ByRef CP_JDNNO As clsCP) As Object
		Dim rtn As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		JDNNO_Check = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(JDNNO) = "" Then
			'�ԍ�����(or 0)�ɕύX���ꂽ����, ����������ꍇ
			'�P�Ȃ�G���[�ł悯��΂��� If�u���b�N�͕s�v
			SSS_LASTKEY.Value = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			rtn = AE_ChOprtLater(PP, 15) '�\����ǉ����[�h�Ɉڍs
			Exit Function
		End If
		DB_SQLBUFF = "Select count(*) From SYKTRA"
		DB_SQLBUFF = DB_SQLBUFF & "               Where SYKTRA.CLTID = '" & SSS_CLTID.Value & "'"
		DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.PGID  = '" & SSS_PrgId & "'"
		DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.DATKB = '1'"
		'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.JDNNO = '" & JDNNO & "'"
		'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.ODNYTDT <= '" & DeCNV_DATE(CStr(FDNDT)) & "'"
		
		Select Case WRKKB
			Case "2"
				DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.WRKKB = '4'"
			Case "3"
				DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.WRKKB = '6'"
			Case "4"
				DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.WRKKB = '7'"
			Case "5"
				DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.WRKKB = '8'"
			Case "6"
				DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.WRKKB IN('2','3')"
			Case Else
				''''''''''''''''DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.WRKKB IN('1','2','3','5')"
				DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.WRKKB IN('1','5')"
		End Select
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(RD_SSSMAIN_SOUCD(0)) <> "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.OUTSOUCD = '" & RD_SSSMAIN_SOUCD(0) & "'"
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(RD_SSSMAIN_TOKCD(0)) <> "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.TOKCD = '" & RD_SSSMAIN_TOKCD(0) & "'"
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WG_SOUCD = RD_SSSMAIN_SOUCD(0)
		'''' UPD 2008/08/30  FKS) S.Nakajima    Start
		''''2007/12/10 UPD-START
		''''WG_TOKCD = RD_SSSMAIN_TOKCD(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WG_TOKCD = RD_SSSMAIN_TOKCD(0) & Space(Len(DB_SYKTRA.TOKCD) - Len(Trim(RD_SSSMAIN_TOKCD(0))))
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WG_TOKCD = Trim(RD_SSSMAIN_TOKCD(0)) & Space(Len(DB_SYKTRA.TOKCD) - Len(Trim(RD_SSSMAIN_TOKCD(0))))
		''''2007/12/10 UPD-START
		'''' UPD 2008/08/30  FKS) S.Nakajima    End
		
		Call DB_GetSQL2(DBN_SYKTRA, DB_SQLBUFF)
		If DB_ExtNum.ExtNum(0) <> 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DB_GetGrEq(DBN_SYKTRA, 2, SSS_CLTID.Value & SSS_PrgId & "1" & JDNNO, BtrNormal)
			If (DBSTAT <> 0) Or (DB_SYKTRA.CLTID <> SSS_CLTID.Value) Or (DB_SYKTRA.PGID <> SSS_PrgId) Or (DB_SYKTRA.DATKB = "9") Then
				'UPGRADE_WARNING: �I�u�W�F�N�g rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '�Y�����R�[�h����
				'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				JDNNO_Check = -1
			Else
				SSS_LASTKEY.Value = DB_SYKTRA.JDNNO
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Trim(RD_SSSMAIN_SOUCD(0)) = "" And Trim(RD_SSSMAIN_TOKCD(0)) = "" Then
					Call DP_SSSMAIN_SOUCD(-1, DB_SYKTRA.OUTSOUCD)
					Call DP_SSSMAIN_TOKCD(-1, DB_SYKTRA.TOKCD)
					WG_SOUCD = DB_SYKTRA.OUTSOUCD
					WG_TOKCD = DB_SYKTRA.TOKCD
				End If
				'UPGRADE_WARNING: �I�u�W�F�N�g rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				rtn = AE_ChOprtLater(PP, 15) '�\����ǉ����[�h�Ɉڍs
			End If
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '�Y�����R�[�h����
			'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			JDNNO_Check = -1
		End If
	End Function
	
	Function JDNNO_DerivedC(ByVal JDNNO As Object, ByVal WRKKB As Object, ByVal FDNDT As Object, ByRef PP As clsPP, ByRef CP_JDNNO As clsCP) As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		JDNNO_DerivedC = JDNNO
		'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(JDNNO) = "" Then
			'�ԍ�����(or 0)�ɕύX���ꂽ����, ����������ꍇ
			'�P�Ȃ�G���[�ł悯��΂��� If�u���b�N�͕s�v
			SSS_LASTKEY.Value = ""
			'''''        Rtn = AE_ChOprtLater(PP, 15)    '�\����ǉ����[�h�Ɉڍs
			Exit Function
		End If
		DB_SQLBUFF = "Select count(*) From SYKTRA"
		DB_SQLBUFF = DB_SQLBUFF & "               Where SYKTRA.CLTID = '" & SSS_CLTID.Value & "'"
		DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.PGID  = '" & SSS_PrgId & "'"
		DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.DATKB = '1'"
		'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.JDNNO = '" & JDNNO & "'"
		'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.ODNYTDT <= '" & DeCNV_DATE(CStr(FDNDT)) & "'"
		Select Case WRKKB
			Case "2"
				DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.WRKKB = '4'"
			Case "3"
				DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.WRKKB = '6'"
			Case "4"
				DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.WRKKB = '7'"
			Case "5"
				DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.WRKKB = '8'"
			Case "6"
				DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.WRKKB IN('2','3')"
			Case Else
				''''''''''''''''DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.WRKKB IN('1','2','3','5')"
				DB_SQLBUFF = DB_SQLBUFF & "                 AND SYKTRA.WRKKB IN('1','5')"
		End Select
		Call DB_GetSQL2(DBN_SYKTRA, DB_SQLBUFF)
		If DB_ExtNum.ExtNum(0) <> 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DB_GetGrEq(DBN_SYKTRA, 2, SSS_CLTID.Value & SSS_PrgId & "1" & JDNNO, BtrNormal)
			If (DBSTAT <> 0) Or (DB_SYKTRA.CLTID <> SSS_CLTID.Value) Or (DB_SYKTRA.PGID <> SSS_PrgId) Or (DB_SYKTRA.DATKB = "9") Then
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '�Y�����R�[�h����
			Else
				SSS_LASTKEY.Value = DB_SYKTRA.JDNNO
				rtn = AE_ChOprtLater(PP, 15) '�\����ǉ����[�h�Ɉڍs
			End If
		Else
			rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '�Y�����R�[�h����
			'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			JDNNO_DerivedC = ""
		End If
	End Function
	
	Function JDNNO_InitVal(ByVal JDNNO As Object) As Object
		'
		If NotFirst = False Then
			NotFirst = True
			'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			JDNNO_InitVal = ""
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			JDNNO_InitVal = JDNNO
		End If
		
	End Function
	
	Function JDNNO_Slist(ByRef PP As clsPP, ByVal JDNNO As Object, ByVal WRKKB As Object, ByVal FDNDT As Object) As Object
		DB_PARA(DBN_SYKTRA).KeyNo = 2
		'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g WRKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_PARA(DBN_SYKTRA).KeyBuf = SSS_CLTID.Value & SSS_PrgId & "1" & WRKKB & FDNDT
		WLSFDN.ShowDialog()
		WLSFDN.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		JDNNO_Slist = PP.SlistCom
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(PP.SlistCom) Then
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			JDNNO_Slist = System.DBNull.Value
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			JDNNO_Slist = Left(PP.SlistCom, Len(DB_SYKTRA.JDNNO))
			'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DP_SSSMAIN_SOUCD(-1, Mid(PP.SlistCom, 11, Len(DB_SYKTRA.OUTSOUCD)))
			'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DP_SSSMAIN_TOKCD(-1, Mid(PP.SlistCom, 14, Len(DB_SYKTRA.TOKCD)))
		End If
		
	End Function
End Module