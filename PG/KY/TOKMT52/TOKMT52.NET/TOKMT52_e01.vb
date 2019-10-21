Option Strict Off
Option Explicit On
Module TOKMT52_E01
	'
	' �X���b�g��        : ��ʏ����X���b�g
	' ���j�b�g��        : TOKMT52.E01
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/05/30
	' �g�p�v���O������  : TOKMT52
	'
	Public WG_UNYDT As String '�^�p��
	
	Function DSPMST() As Short
		Dim I As Short
		Dim strSQL As String
		'
		I = 0
		SSS_FASTKEY.Value = SSS_LASTKEY.Value
		''''Call DB_GetGrEq(DBN_TOKMTC, 1, SSS_LASTKEY, BtrNormal)
		strSQL = ""
		strSQL = strSQL & "SELECT *"
		strSQL = strSQL & "  FROM   ("
		strSQL = strSQL & "             SELECT TOK.DATKB, TOK.HINCD, TOK.TOKCD, TOK.TUKKB"
		strSQL = strSQL & "                  , TOK.URITKDT, TOK.URITK, TOK.ULTTKKB, TOK.RELFL"
		strSQL = strSQL & "                  , TOK.FOPEID,TOK.FCLTID"
		strSQL = strSQL & "                  , MEI.DSPORD || TOK.TUKKB as WRTFSTTM"
		strSQL = strSQL & "                  ,(99999999 - TO_NUMBER(TOK.URITKDT)) as WRTFSTDT "
		strSQL = strSQL & "                  , TOK.OPEID,TOK.CLTID,TOK.WRTTM,TOK.WRTDT"
		strSQL = strSQL & "                  , TOK.UOPEID,TOK.UCLTID,TOK.UWRTTM,TOK.UWRTDT"
		strSQL = strSQL & "                  , TOK.PGID "
		strSQL = strSQL & "             FROM TOKMTC TOK LEFT JOIN MEIMTA MEI ON MEI.KEYCD = '001' AND MEI.MEICDA = TOK.TUKKB AND MEI.MEICDB = ' '"
		strSQL = strSQL & "             ) TBL"
		strSQL = strSQL & " WHERE   TBL.HINCD || TBL.TOKCD || TBL.WRTFSTTM || TBL.WRTFSTDT >= " & "'" & RTrim(SSS_FASTKEY.Value) & "'"
		strSQL = strSQL & " ORDER BY TBL.HINCD,TBL.TOKCD,TBL.WRTFSTTM,TBL.WRTFSTDT"
		
		Call DB_GetSQL2(DBN_TOKMTC, strSQL)
		
		' === 20080903 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
		''2007/12/18 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		'    ReDim M_MOTO_A_inf(14)
		''2007/12/18 add-end T.KAWAMUKAI
		ReDim M_TOKMT_A_inf(14)
		' === 20080903 === UPDATE E - RISE)Izumi
		
		If DBSTAT = 0 Then
			Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC + 1))
				Call SCR_FromMfil(I)
				Call DP_SSSMAIN_V_DATKB(I, DB_TOKMTC.DATKB) '2006.11.07
				Call DP_SSSMAIN_V_URITK(I, DB_TOKMTC.URITK) '2006.11.07
				Call DP_SSSMAIN_V_ULTTKK(I, DB_TOKMTC.ULTTKKB) '2006.11.07
				If DB_TOKMTC.DATKB = "9" Then
					Call DP_SSSMAIN_UPDKB(I, "�폜")
				Else
					Call DP_SSSMAIN_UPDKB(I, "�X�V")
				End If
				'�`���f�[�^�\��
				Call DB_GetEq(DBN_HINMTA, 1, DB_TOKMTC.HINCD, BtrNormal)
				'HINMTA�̑�������
				If DBSTAT = 0 Then
					Call HINCD_Move(DB_TOKMTC.HINCD, I)
				Else
					Call DP_SSSMAIN_HINNMA(I, "�@")
					Call DP_SSSMAIN_HINNMA(I, "�@")
				End If
				
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_TOKMTC.URITK) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Trim(CStr(DB_TOKMTC.URITK)) = "" Or SSSVal(DB_TOKMTC.URITK) = 0 Then
					Call DP_SSSMAIN_URITK(I, "")
				End If
				
				I = I + 1
				Call DB_GetNext(DBN_TOKMTC, BtrNormal)
			Loop 
		End If
		If DBSTAT = 0 Then
			SSS_LASTKEY.Value = DB_TOKMTC.HINCD & DB_TOKMTC.TOKCD & DB_TOKMTC.WRTFSTTM & DB_TOKMTC.WRTFSTDT
			
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSS_LASTKEY.Value = HighValue(LenWid(DB_TOKMTC.HINCD)) & HighValue(LenWid(DB_TOKMTC.TOKCD)) & HighValue(LenWid(DB_TOKMTC.WRTFSTTM)) & HighValue(LenWid(DB_TOKMTC.WRTFSTDT))
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
			''''    CL_SSSMAIN(2 + (lngI * 9)) = 1                  '2006.11.07
			''''    CL_SSSMAIN(4 + (lngI * 9)) = 1                  '2006.11.07
			''''    CL_SSSMAIN(6 + (lngI * 9)) = 1                  '2006.11.07
			CL_SSSMAIN(2 + (lngI * 12)) = 1
			CL_SSSMAIN(4 + (lngI * 12)) = 1
			CL_SSSMAIN(6 + (lngI * 12)) = 1
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
		''''Call DB_GetGrEq(DBN_TOKMTC, 1, SSS_LASTKEY, BtrNormal)
		strSQL = ""
		strSQL = strSQL & "SELECT *"
		strSQL = strSQL & "  FROM   ("
		strSQL = strSQL & "             SELECT TOK.DATKB, TOK.HINCD, TOK.TOKCD, TOK.TUKKB"
		strSQL = strSQL & "                  , TOK.URITKDT, TOK.URITK, TOK.ULTTKKB, TOK.RELFL"
		strSQL = strSQL & "                  , TOK.FOPEID,TOK.FCLTID"
		strSQL = strSQL & "                  , MEI.DSPORD || TOK.TUKKB as WRTFSTTM"
		strSQL = strSQL & "                  ,(99999999 - TO_NUMBER(TOK.URITKDT)) as WRTFSTDT "
		strSQL = strSQL & "                  , TOK.OPEID,TOK.CLTID,TOK.WRTTM,TOK.WRTDT"
		strSQL = strSQL & "                  , TOK.UOPEID,TOK.UCLTID,TOK.UWRTTM,TOK.UWRTDT"
		strSQL = strSQL & "                  , TOK.PGID "
		strSQL = strSQL & "             FROM TOKMTC TOK LEFT JOIN MEIMTA MEI ON MEI.KEYCD = '001' AND MEI.MEICDA = TOK.TUKKB AND MEI.MEICDB = ' '"
		strSQL = strSQL & "             ) TBL"
		strSQL = strSQL & " WHERE   TBL.HINCD || TBL.TOKCD || TBL.WRTFSTTM || TBL.WRTFSTDT >= " & "'" & RTrim(SSS_LASTKEY.Value) & "'"
		strSQL = strSQL & " ORDER BY TBL.HINCD,TBL.TOKCD,TBL.WRTFSTTM,TBL.WRTFSTDT"
		
		Call DB_GetSQL2(DBN_TOKMTC, strSQL)
		If DBSTAT = 0 Then
			MST_NEXT = DSPMST()
		Else
			SSS_LASTKEY.Value = SSS_FASTKEY.Value
			MST_NEXT = DSPMST()
		End If
	End Function
	
	Function MST_PREV() As Object
		Dim I As Short
		Dim strSQL As String
		'
		I = SET_GAMEN_KEY()
		I = 0
		''''Call DB_GetLs(DBN_TOKMTC, 1, SSS_FASTKEY, BtrNormal)
		strSQL = ""
		strSQL = strSQL & "SELECT *"
		strSQL = strSQL & "  FROM   ("
		strSQL = strSQL & "             SELECT TOK.DATKB, TOK.HINCD, TOK.TOKCD, TOK.TUKKB"
		strSQL = strSQL & "                  , TOK.URITKDT, TOK.URITK, TOK.ULTTKKB, TOK.RELFL"
		strSQL = strSQL & "                  , TOK.FOPEID,TOK.FCLTID"
		strSQL = strSQL & "                  , MEI.DSPORD || TOK.TUKKB as WRTFSTTM"
		strSQL = strSQL & "                  ,(99999999 - TO_NUMBER(TOK.URITKDT)) as WRTFSTDT "
		strSQL = strSQL & "                  , TOK.OPEID,TOK.CLTID,TOK.WRTTM,TOK.WRTDT"
		strSQL = strSQL & "                  , TOK.UOPEID,TOK.UCLTID,TOK.UWRTTM,TOK.UWRTDT"
		strSQL = strSQL & "                  , TOK.PGID "
		strSQL = strSQL & "             FROM TOKMTC TOK LEFT JOIN MEIMTA MEI ON MEI.KEYCD = '001' AND MEI.MEICDA = TOK.TUKKB AND MEI.MEICDB = ' '"
		strSQL = strSQL & "             ) TBL"
		strSQL = strSQL & " WHERE   TBL.HINCD || TBL.TOKCD || TBL.WRTFSTTM || TBL.WRTFSTDT < " & "'" & RTrim(SSS_FASTKEY.Value) & "'"
		strSQL = strSQL & " ORDER BY TBL.HINCD desc, TBL.TOKCD desc, TBL.WRTFSTTM desc,TBL.WRTFSTDT desc"
		Call DB_GetSQL2(DBN_TOKMTC, strSQL)
		
		Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC))
			I = I + 1
			DB_PARA(DBN_TOKMTC).nDirection = 2
			Call DB_GetPre(DBN_TOKMTC, BtrNormal)
		Loop 
		If DBSTAT <> 0 And I = 0 Then
			'        Call DB_GetFirst(DBN_TOKMTC, 2, BtrNormal)
			SSS_LASTKEY.Value = Space(Len(DB_TOKMTC.HINCD)) & Space(Len(DB_TOKMTC.TOKCD)) & Space(Len(DB_TOKMTC.WRTFSTTM)) & VB6.Format(DB_TOKMTC.WRTFSTDT, "00000000")
		Else
			SSS_LASTKEY.Value = DB_TOKMTC.HINCD & DB_TOKMTC.TOKCD & DB_TOKMTC.WRTFSTTM & DB_TOKMTC.WRTFSTDT
		End If
		
		I = DSPMST()
		'UPGRADE_WARNING: �I�u�W�F�N�g MST_PREV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		MST_PREV = I
	End Function
	
	Function SET_GAMEN_KEY() As Short
		Dim wkDSPORD As String
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_TOKMTC.TOKCD = RD_SSSMAIN_TOKCD(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HINCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_TOKMTC.HINCD = RD_SSSMAIN_HINCD(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URITKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(RD_SSSMAIN_URITKDT(0)) = "" Then
			DB_TOKMTC.URITKDT = "00000000"
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URITKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTC.URITKDT = VB6.Format(99999999 - Val(RD_SSSMAIN_URITKDT(0)), "00000000")
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TUKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_TOKMTC.TUKKB = RD_SSSMAIN_TUKKB(0)
		If Trim(DB_TOKMTC.TUKKB) = "" Then
			DB_MEIMTA.DSPORD = "000"
		Else
			wkDSPORD = Trim(DB_TOKMTC.TUKKB) & Space(Len(DB_MEIMTA.MEICDA) - Len(Trim(DB_TOKMTC.TUKKB)))
			Call DB_GetEq(DBN_MEIMTA, 2, "001" & wkDSPORD, BtrNormal)
			If DBSTAT <> 0 Then
				DB_MEIMTA.DSPORD = "000"
			End If
		End If
		
		SSS_LASTKEY.Value = DB_TOKMTC.HINCD & DB_TOKMTC.TOKCD & DB_MEIMTA.DSPORD & DB_TOKMTC.TUKKB & DB_TOKMTC.URITKDT
		
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