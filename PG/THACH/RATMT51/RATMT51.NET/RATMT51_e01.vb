Option Strict Off
Option Explicit On
Module RATMT51_E01
	'
	' �X���b�g��        : ��ʏ����X���b�g
	' ���j�b�g��        : RATMT51.E01
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/06/02
	' �g�p�v���O������  : RATMT51
	'
	Public WG_UNYDT As String '�^�p��
	
	Function DSPMST() As Short
		Dim I As Short
		Dim wkTUKKB As String
		Dim strSQL As String
		'
		I = 0
		Call TUKMTA_RClear()
		
		SSS_FASTKEY.Value = SSS_LASTKEY.Value
		''''Call DB_GetGrEq(DBN_TUKMTA, 1, SSS_LASTKEY, BtrNormal)
		strSQL = ""
		strSQL = strSQL & "SELECT *"
		strSQL = strSQL & "  FROM   ("
		strSQL = strSQL & "             SELECT TUK.DATKB, TUK.TUKKB, TUK.TUKNM, TUK.TEKIDT"
		strSQL = strSQL & "                  , TUK.RATERT, TUK.RELFL"
		strSQL = strSQL & "                  , TUK.FOPEID,TUK.FCLTID"
		strSQL = strSQL & "                  , MEI.DSPORD || TUK.TUKKB  as WRTFSTTM"
		strSQL = strSQL & "                  ,(99999999 - TO_NUMBER(TUK.TEKIDT)) as WRTFSTDT"
		strSQL = strSQL & "                  , TUK.OPEID,TUK.CLTID, TUK.WRTTM,TUK.WRTDT"
		strSQL = strSQL & "                  , TUK.UOPEID,TUK.UCLTID, TUK.UWRTTM,TUK.UWRTDT"
		strSQL = strSQL & "                  , TUK.PGID "
		strSQL = strSQL & "             FROM TUKMTA TUK LEFT JOIN MEIMTA MEI ON MEI.KEYCD = '001' "
		strSQL = strSQL & "                                                 AND MEI.MEICDA = TUK.TUKKB "
		strSQL = strSQL & "                                                 AND MEI.MEICDB = ' '"
		strSQL = strSQL & "             ) TBL"
		strSQL = strSQL & " WHERE    TBL.WRTFSTTM || TBL.WRTFSTDT >= " & "'" & RTrim(SSS_FASTKEY.Value) & "'"
		strSQL = strSQL & " ORDER BY TBL.WRTFSTTM,TBL.WRTFSTDT"
		
		Call DB_GetSQL2(DBN_TUKMTA, strSQL)
		
		'20081002 CHG START RISE)Tanimura '�r������
		''2007/12/18 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		'    ReDim M_MOTO_A_inf(14)
		''2007/12/18 add-end T.KAWAMUKAI
		
		ReDim M_RATMT_A_inf(14)
		
		Call RATMT51_MF_All_Clear_UWRTDTTM()
		'20081002 CHG END   RISE)Tanimura
		
		If DBSTAT = 0 Then
			Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC + 1))
				
				Call SCR_FromMfil(I)
				Call DP_SSSMAIN_V_DATKB(I, DB_TUKMTA.DATKB) '2006.11.07
				Call DP_SSSMAIN_V_RATERT(I, DB_TUKMTA.RATERT) '2006.11.07
				
				Call MEIMTA_RClear()
				wkTUKKB = DB_TUKMTA.TUKKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_TUKMTA.TUKKB))
				Call DB_GetEq(DBN_MEIMTA, 2, "001" & wkTUKKB, BtrNormal)
				If DBSTAT = 0 Then '����Ͻ��ɓ��Y���ڂ��݂鎞
					Call SCR_FromMEIMTA(I)
				End If
				
				If DB_TUKMTA.DATKB = "9" Then
					Call DP_SSSMAIN_UPDKB(I, "�폜")
				Else
					Call DP_SSSMAIN_UPDKB(I, "�X�V")
				End If
				I = I + 1
				Call DB_GetNext(DBN_TUKMTA, BtrNormal)
			Loop 
		End If
		If DBSTAT = 0 Then
			SSS_LASTKEY.Value = DB_TUKMTA.WRTFSTTM & DB_TUKMTA.WRTFSTDT
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSS_LASTKEY.Value = HighValue(LenWid(DB_TUKMTA.WRTFSTTM)) & HighValue(LenWid(DB_TUKMTA.WRTFSTDT))
		End If
		
		DSPMST = I
	End Function
	
	Sub INITDSP()
		Dim lngI As Integer
		
		'�w�i�F�̐ݒ�
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(0) = 1
		CL_SSSMAIN(1) = 1
		
		For lngI = 0 To PP_SSSMAIN.MaxDe
			''''    CL_SSSMAIN(2 + (lngI * 5)) = 1              '2006.11.07
			''''    CL_SSSMAIN(4 + (lngI * 5)) = 1              '2006.11.07
			CL_SSSMAIN(2 + (lngI * 7)) = 1
			CL_SSSMAIN(4 + (lngI * 7)) = 1
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
		Dim Rtn As Short
		Dim strSQL As String
		'
		''''Call DB_GetGrEq(DBN_TUKMTA, 1, SSS_LASTKEY, BtrNormal)
		strSQL = ""
		strSQL = strSQL & "SELECT *"
		strSQL = strSQL & "  FROM   ("
		strSQL = strSQL & "             SELECT TUK.DATKB, TUK.TUKKB, TUK.TUKNM, TUK.TEKIDT"
		strSQL = strSQL & "                  , TUK.RATERT, TUK.RELFL"
		strSQL = strSQL & "                  , TUK.FOPEID,TUK.FCLTID"
		strSQL = strSQL & "                  , MEI.DSPORD || TUK.TUKKB  as WRTFSTTM"
		strSQL = strSQL & "                  ,(99999999 - TO_NUMBER(TUK.TEKIDT)) as WRTFSTDT"
		strSQL = strSQL & "                  , TUK.OPEID,TUK.CLTID, TUK.WRTTM,TUK.WRTDT"
		strSQL = strSQL & "                  , TUK.UOPEID,TUK.UCLTID, TUK.UWRTTM,TUK.UWRTDT"
		strSQL = strSQL & "                  , TUK.PGID "
		strSQL = strSQL & "             FROM TUKMTA TUK LEFT JOIN MEIMTA MEI ON MEI.KEYCD = '001' "
		strSQL = strSQL & "                                                 AND MEI.MEICDA = TUK.TUKKB "
		strSQL = strSQL & "                                                 AND MEI.MEICDB = ' '"
		strSQL = strSQL & "             ) TBL"
		strSQL = strSQL & " WHERE    TBL.WRTFSTTM || TBL.WRTFSTDT >= " & "'" & RTrim(SSS_LASTKEY.Value) & "'"
		strSQL = strSQL & " ORDER BY TBL.WRTFSTTM,TBL.WRTFSTDT"
		
		Call DB_GetSQL2(DBN_TUKMTA, strSQL)
		
		If DBSTAT = 0 Then
			MST_NEXT = DSPMST()
		Else
			SSS_LASTKEY.Value = SSS_FASTKEY.Value
			MST_NEXT = DSPMST()
		End If
	End Function
	
	Function MST_PREV() As Short
		Dim I As Short
		Dim strSQL As String
		'
		I = SET_GAMEN_KEY()
		I = 0
		''''Call DB_GetLs(DBN_TUKMTA, 1, SSS_FASTKEY, BtrNormal)
		strSQL = ""
		strSQL = strSQL & "SELECT *"
		strSQL = strSQL & "  FROM   ("
		strSQL = strSQL & "             SELECT TUK.DATKB, TUK.TUKKB, TUK.TUKNM, TUK.TEKIDT"
		strSQL = strSQL & "                  , TUK.RATERT, TUK.RELFL"
		strSQL = strSQL & "                  , TUK.FOPEID,TUK.FCLTID"
		strSQL = strSQL & "                  , MEI.DSPORD || TUK.TUKKB  as WRTFSTTM"
		strSQL = strSQL & "                  ,(99999999 - TO_NUMBER(TUK.TEKIDT)) as WRTFSTDT"
		strSQL = strSQL & "                  , TUK.OPEID,TUK.CLTID, TUK.WRTTM,TUK.WRTDT"
		strSQL = strSQL & "                  , TUK.UOPEID,TUK.UCLTID, TUK.UWRTTM,TUK.UWRTDT"
		strSQL = strSQL & "                  , TUK.PGID "
		strSQL = strSQL & "             FROM TUKMTA TUK LEFT JOIN MEIMTA MEI ON MEI.KEYCD = '001' "
		strSQL = strSQL & "                                                 AND MEI.MEICDA = TUK.TUKKB "
		strSQL = strSQL & "                                                 AND MEI.MEICDB = ' '"
		strSQL = strSQL & "             ) TBL"
		strSQL = strSQL & " WHERE    TBL.WRTFSTTM || TBL.WRTFSTDT < " & "'" & RTrim(SSS_FASTKEY.Value) & "'"
		strSQL = strSQL & " ORDER BY TBL.WRTFSTTM desc,TBL.WRTFSTDT desc"
		
		Call DB_GetSQL2(DBN_TUKMTA, strSQL)
		
		Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC))
			I = I + 1
			DB_PARA(DBN_TUKMTA).nDirection = 2
			Call DB_GetPre(DBN_TUKMTA, BtrNormal)
		Loop 
		If DBSTAT <> 0 And I = 0 Then
			SSS_LASTKEY.Value = Space(Len(DB_TUKMTA.WRTFSTTM)) & VB6.Format(DB_TUKMTA.WRTFSTDT, "0")
			''''''''Call DB_GetFirst(DBN_TUKMTA, 2, BtrNormal)
		Else
			SSS_LASTKEY.Value = DB_TUKMTA.WRTFSTTM & DB_TUKMTA.WRTFSTDT
		End If
		I = DSPMST()
		MST_PREV = I
		
	End Function
	
	Function SET_GAMEN_KEY() As Short
		Dim wkDSPORD As String
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TEKIDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(RD_SSSMAIN_TEKIDT(0)) = "" Then
			DB_TUKMTA.TEKIDT = "00000000"
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TEKIDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TUKMTA.TEKIDT = VB6.Format(99999999 - Val(RD_SSSMAIN_TEKIDT(0)), "00000000")
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TUKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_TUKMTA.TUKKB = RD_SSSMAIN_TUKKB(0)
		If Trim(DB_TUKMTA.TUKKB) = "" Then
			DB_MEIMTA.DSPORD = "   "
		Else
			wkDSPORD = Trim(DB_TUKMTA.TUKKB) & Space(Len(DB_MEIMTA.MEICDA) - Len(Trim(DB_TUKMTA.TUKKB)))
			Call DB_GetEq(DBN_MEIMTA, 2, "001" & wkDSPORD, BtrNormal)
			If DBSTAT <> 0 Then
				DB_MEIMTA.DSPORD = "   "
			End If
		End If
		
		SSS_LASTKEY.Value = DB_MEIMTA.DSPORD & DB_TUKMTA.TUKKB & DB_TUKMTA.TEKIDT
		
		SET_GAMEN_KEY = 4
		
	End Function
	
	Function Execute_GetEvent() As Object
		
		Dim Rtn As Short
		
		'UPGRADE_WARNING: �I�u�W�F�N�g Execute_GetEvent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Execute_GetEvent = True
		If PP_SSSMAIN.LastDe = 0 Then
			Rtn = DSP_MsgBox(CStr(0), "NO_ENTRY", 0) '�f�[�^����͂��ĉ�����
			'UPGRADE_WARNING: �I�u�W�F�N�g Execute_GetEvent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Execute_GetEvent = False
			Exit Function
		End If
		
	End Function
End Module