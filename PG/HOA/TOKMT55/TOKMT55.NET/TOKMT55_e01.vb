Option Strict Off
Option Explicit On
Module TOKMT55_E01
	'
	' �X���b�g��        : ��ʏ����X���b�g
	' ���j�b�g��        : TOKMT55.E01
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/06/14
	' �g�p�v���O������  : TOKMT55
	'
	Public WG_UNYDT As String '�^�p��
	
	Function DSPMST() As Short
		Dim i As Short
		Dim strSQL As String
		Dim wkSKHINGRP As String
		'
		i = 0
		Call MEIMTA_RClear()
		
		wkSKHINGRP = Left(SSS_LASTKEY.Value, Len(DB_RNKMTA.SKHINGRP)) & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_RNKMTA.SKHINGRP))
		Call DB_GetEq(DBN_MEIMTA, 2, "043" & wkSKHINGRP, BtrNormal)
		If DBSTAT = 0 Then
			Call SCR_FromMEIMTA(i)
		End If
		
		SSS_FASTKEY.Value = SSS_LASTKEY.Value
		''''Call DB_GetGrEq(DBN_RNKMTA, 1, SSS_LASTKEY, BtrNormal)
		strSQL = ""
		strSQL = strSQL & "SELECT *"
		strSQL = strSQL & "  FROM   ("
		strSQL = strSQL & "             SELECT RNK.DATKB, RNK.SKHINGRP, RNK.RNKCD,RNK.URISETDT,RNK.SIKRT,RNK.RELFL"
		strSQL = strSQL & "                  , RNK.FOPEID, RNK.FCLTID, RNK.WRTFSTTM, (99999999 - TO_NUMBER(RNK.URISETDT)) as WRTFSTDT"
		strSQL = strSQL & "                  , RNK.OPEID, RNK.CLTID, RNK.WRTTM, RNK.WRTDT"
		strSQL = strSQL & "                  , RNK.UOPEID, RNK.UCLTID, RNK.UWRTTM, RNK.UWRTDT"
		strSQL = strSQL & "                  , RNK.PGID "
		strSQL = strSQL & "             FROM RNKMTA RNK"
		strSQL = strSQL & "             ) TBL"
		strSQL = strSQL & " WHERE   TBL.SKHINGRP || TBL.RNKCD || TBL.WRTFSTDT >= " & "'" & RTrim(SSS_FASTKEY.Value) & "'"
		strSQL = strSQL & "   AND   TBL.SKHINGRP = " & "'" & Left(SSS_FASTKEY.Value, Len(DB_RNKMTA.SKHINGRP)) & "'"
		strSQL = strSQL & " ORDER BY TBL.SKHINGRP,TBL.RNKCD,TBL.WRTFSTDT"
		
		Call DB_GetSQL2(DBN_RNKMTA, strSQL)
		
		' === 20080908 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
		''2007/12/18 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		'    ReDim M_MOTO_A_inf(14)
		''2007/12/18 add-end T.KAWAMUKAI
		ReDim M_RNKMT_A_inf(14)
		' === 20080908 === UPDATE E - RISE)Izumi
		
		If DBSTAT = 0 Then
			Do While (DBSTAT = 0) And (i < (PP_SSSMAIN.MaxDspC + 1))
				Call SCR_FromMfil(i)
				Call DP_SSSMAIN_V_DATKB(i, DB_RNKMTA.DATKB) '2006.11.07
				Call DP_SSSMAIN_V_SIKRT(i, DB_RNKMTA.SIKRT) '2006.11.07
				If DB_RNKMTA.DATKB = "9" Then
					Call DP_SSSMAIN_UPDKB(i, "�폜")
				Else
					Call DP_SSSMAIN_UPDKB(i, "�X�V")
				End If
				i = i + 1
				Call DB_GetNext(DBN_RNKMTA, BtrNormal)
			Loop 
		Else
			'DB��Ɏw��L�[�̂��̂����݂��Ȃ��Ƃ�
			Call Dsp_Prompt("RNOTFOUND", 0) '�V�K���R�[�h�ł��B
			i = i + 1
			'        For i = 0 To PP_SSSMAIN.MaxDspC
			'            Call DP_SSSMAIN_RNKCD(i, " ")
			'            Call DP_SSSMAIN_SIKRT(i, " ")
			'            Call DP_SSSMAIN_URISETDT(i, " ")
			'            Call DP_SSSMAIN_UPDKB(i, " ")
			'
			'            If i <> 0 Then Call DP_SSSMAIN_UPDKB(i, " ")
			'        Next i
		End If
		'
		If DBSTAT = 0 Then
			SSS_LASTKEY.Value = DB_RNKMTA.SKHINGRP & DB_RNKMTA.RNKCD & DB_RNKMTA.WRTFSTDT
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSS_LASTKEY.Value = Left(SSS_FASTKEY.Value, Len(DB_RNKMTA.SKHINGRP)) & HighValue(LenWid(DB_RNKMTA.RNKCD)) & HighValue(LenWid(DB_RNKMTA.WRTFSTDT))
		End If
		DSPMST = i
	End Function
	
	Sub INITDSP()
		Dim lngI As Integer
		
		'�w�i�F�̐ݒ�
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(0) = 1
		CL_SSSMAIN(1) = 1
		CL_SSSMAIN(3) = 1
		
		For lngI = 0 To PP_SSSMAIN.MaxDe
			''''    CL_SSSMAIN(4 + (lngI * 4)) = 1                  '2006.11.07
			CL_SSSMAIN(4 + (lngI * 6)) = 1
		Next 
		
		'�^�p���擾
		Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
		If DBSTAT = 0 Then
			WG_UNYDT = DB_UNYMTA.UNYDT
		Else
			WG_UNYDT = ""
		End If
		
		'���s�����`�F�b�N
		Dim wkDATE As String
		Dim wkCRW As System.Windows.Forms.Control
		gs_userid = Left(SSS_OPEID.Value, 6) '���[�UID
		gs_pgid = SSS_PrgId '�v���O����ID
		
		If CDbl(Get_Authority(DB_UNYMTA.UNYDT, wkCRW)) = 9 Then
			Call MsgBox("���s����������܂���B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			End
		End If
		
	End Sub
	
	Function MST_NEXT() As Short
		Dim rtn As Short
		Dim strSQL As String
		'
		''''Call DB_GetGrEq(DBN_RNKMTA, 1, SSS_LASTKEY, BtrNormal)
		strSQL = ""
		strSQL = strSQL & "SELECT *"
		strSQL = strSQL & "  FROM   ("
		strSQL = strSQL & "             SELECT RNK.DATKB, RNK.SKHINGRP, RNK.RNKCD,RNK.URISETDT,RNK.SIKRT,RNK.RELFL"
		strSQL = strSQL & "                  , RNK.FOPEID, RNK.FCLTID, RNK.WRTFSTTM, (99999999 - TO_NUMBER(RNK.URISETDT)) as WRTFSTDT"
		strSQL = strSQL & "                  , RNK.OPEID, RNK.CLTID, RNK.WRTTM, RNK.WRTDT"
		strSQL = strSQL & "                  , RNK.UOPEID, RNK.UCLTID, RNK.UWRTTM, RNK.UWRTDT"
		strSQL = strSQL & "                  , RNK.PGID "
		strSQL = strSQL & "             FROM RNKMTA RNK"
		strSQL = strSQL & "             ) TBL"
		strSQL = strSQL & " WHERE   TBL.SKHINGRP || TBL.RNKCD || TBL.WRTFSTDT >= " & "'" & RTrim(SSS_LASTKEY.Value) & "'"
		strSQL = strSQL & "   AND   TBL.SKHINGRP = " & "'" & Left(SSS_FASTKEY.Value, Len(DB_RNKMTA.SKHINGRP)) & "'"
		strSQL = strSQL & " ORDER BY TBL.SKHINGRP,TBL.RNKCD,TBL.WRTFSTDT"
		
		Call DB_GetSQL2(DBN_RNKMTA, strSQL)
		
		If DBSTAT = 0 Then
			MST_NEXT = DSPMST()
		Else
			SSS_LASTKEY.Value = SSS_FASTKEY.Value
			MST_NEXT = DSPMST()
		End If
	End Function
	
	Function MST_PREV() As Short
		Dim i As Short
		Dim strSQL As String
		'
		i = SET_GAMEN_KEY()
		i = 0
		''''Call DB_GetLs(DBN_RNKMTA, 1, SSS_FASTKEY, BtrNormal)
		strSQL = ""
		strSQL = strSQL & "SELECT *"
		strSQL = strSQL & "  FROM   ("
		strSQL = strSQL & "             SELECT RNK.DATKB, RNK.SKHINGRP, RNK.RNKCD,RNK.URISETDT,RNK.SIKRT,RNK.RELFL"
		strSQL = strSQL & "                  , RNK.FOPEID, RNK.FCLTID, RNK.WRTFSTTM, (99999999 - TO_NUMBER(RNK.URISETDT)) as WRTFSTDT"
		strSQL = strSQL & "                  , RNK.OPEID, RNK.CLTID, RNK.WRTTM, RNK.WRTDT"
		strSQL = strSQL & "                  , RNK.UOPEID, RNK.UCLTID, RNK.UWRTTM, RNK.UWRTDT"
		strSQL = strSQL & "                  , RNK.PGID "
		strSQL = strSQL & "             FROM RNKMTA RNK"
		strSQL = strSQL & "             ) TBL"
		strSQL = strSQL & " WHERE   TBL.SKHINGRP || TBL.RNKCD || TBL.WRTFSTDT < " & "'" & RTrim(SSS_FASTKEY.Value) & "'"
		strSQL = strSQL & "   AND   TBL.SKHINGRP = " & "'" & Left(SSS_FASTKEY.Value, Len(DB_RNKMTA.SKHINGRP)) & "'"
		strSQL = strSQL & " ORDER BY TBL.SKHINGRP DESC, TBL.RNKCD DESC, TBL.WRTFSTDT DESC"
		
		Call DB_GetSQL2(DBN_RNKMTA, strSQL)
		
		Do While (DBSTAT = 0) And (i < (PP_SSSMAIN.MaxDspC))
			i = i + 1
			DB_PARA(DBN_RNKMTA).nDirection = 2
			Call DB_GetPre(DBN_RNKMTA, BtrNormal)
		Loop 
		If DBSTAT <> 0 And i = 0 Then
			'        Call DB_GetFirst(DBN_RNKMTA, 1, BtrNormal)
			SSS_LASTKEY.Value = Left(SSS_FASTKEY.Value, Len(DB_RNKMTA.SKHINGRP)) & Space(Len(DB_RNKMTA.RNKCD)) & VB6.Format(DB_RNKMTA.WRTFSTDT, "00000000")
		Else
			SSS_LASTKEY.Value = Left(SSS_FASTKEY.Value, Len(DB_RNKMTA.SKHINGRP)) & DB_RNKMTA.RNKCD & DB_RNKMTA.WRTFSTDT
		End If
		i = DSPMST()
		MST_PREV = i
	End Function
	
	Function SET_GAMEN_KEY() As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SKHINGRP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_RNKMTA.SKHINGRP = RD_SSSMAIN_SKHINGRP(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_RNKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_RNKMTA.RNKCD = RD_SSSMAIN_RNKCD(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISETDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(RD_SSSMAIN_URISETDT(0)) = "" Then
			DB_RNKMTA.URISETDT = "00000000"
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISETDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_RNKMTA.URISETDT = VB6.Format(99999999 - Val(RD_SSSMAIN_URISETDT(0)), "00000000")
		End If
		SSS_LASTKEY.Value = DB_RNKMTA.SKHINGRP & DB_RNKMTA.RNKCD & DB_RNKMTA.URISETDT
		
		SET_GAMEN_KEY = 4
	End Function
	
	Function Execute_GetEvent() As Object
		
		Dim rtn As Short
		
		'UPGRADE_WARNING: �I�u�W�F�N�g Execute_GetEvent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Execute_GetEvent = True
		If PP_SSSMAIN.LastDe = 0 Then
			rtn = DSP_MsgBox(CStr(0), "NO_ENTRY", 0) '�f�[�^����͂��ĉ�����
			'UPGRADE_WARNING: �I�u�W�F�N�g Execute_GetEvent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Execute_GetEvent = False
			Exit Function
		End If
		
	End Function
End Module