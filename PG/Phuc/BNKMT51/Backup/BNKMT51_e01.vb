Option Strict Off
Option Explicit On
Module BNKMT51_E01
	'
	' �X���b�g��        : ��ʏ����X���b�g
	' ���j�b�g��        : BNKMT51.E01
	' �L�q��            : Standard Library
	' �쐬���t          : 1997/08/04
	' �g�p�v���O������  : BNKMT51
	'
	
	Function DSPMST() As Short
		Dim I As Short
		'
		I = 0
		SSS_FASTKEY.Value = SSS_LASTKEY.Value
		Call DB_GetGrEq(DBN_BNKMTA, 1, SSS_FASTKEY.Value, BtrNormal)
		
		' === 20080930 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
		''2007/12/18 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		'    ReDim M_MOTO_A_inf(14)
		''2007/12/18 add-end T.KAWAMUKAI
		ReDim M_BNKMT_A_inf(14)
		' === 20080930 === UPDATE E - RISE)Izumi
		
		If DBSTAT = 0 Then
			Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC + 1))
				Call SCR_FromMfil(I)
				Call DP_SSSMAIN_V_DATKB(I, DB_BNKMTA.DATKB) '2006.11.07
				Call DP_SSSMAIN_V_BNKNM(I, DB_BNKMTA.BNKNM) '2006.11.07
				Call DP_SSSMAIN_V_STNNM(I, DB_BNKMTA.STNNM) '2006.11.07
				Call DP_SSSMAIN_V_BNKNK(I, DB_BNKMTA.BNKNK) '2006.11.07
				Call DP_SSSMAIN_V_STNNK(I, DB_BNKMTA.STNNK) '2006.11.07
				If DB_BNKMTA.DATKB = "9" Then
					Call DP_SSSMAIN_UPDKB(I, "�폜")
				Else
					Call DP_SSSMAIN_UPDKB(I, "�X�V")
				End If
				I = I + 1
				Call DB_GetNext(DBN_BNKMTA, BtrNormal)
			Loop 
		End If
		If DBSTAT = 0 Then
			SSS_LASTKEY.Value = DB_BNKMTA.BNKCD
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSS_LASTKEY.Value = HighValue(LenWid(DB_BNKMTA.BNKCD))
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
			''''    CL_SSSMAIN(2 + (lngI * 6)) = 1              '2006.11.07
			CL_SSSMAIN(2 + (lngI * 11)) = 1
		Next 
		
		'���s�����`�F�b�N
		Dim wkDATE As String
		Dim wkCRW As System.Windows.Forms.Control
		gs_userid = Left(SSS_OPEID.Value, 6) '���[�UID
		gs_pgid = SSS_PrgId '�v���O����ID
		
		Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
		If CDbl(Get_Authority(DB_UNYMTA.UNYDT, wkCRW)) = 9 Then
			Call MsgBox("���s����������܂���B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			End
		End If
		
	End Sub
	
	Function MST_NEXT() As Short
		Dim rtn As Short
		'
		Call DB_GetGrEq(DBN_BNKMTA, 1, SSS_LASTKEY.Value, BtrNormal)
		If DBSTAT = 0 Then
			MST_NEXT = DSPMST()
		Else
			SSS_LASTKEY.Value = SSS_FASTKEY.Value
			MST_NEXT = DSPMST()
		End If
	End Function
	
	Function MST_PREV() As Short
		Dim I As Short
		'
		I = SET_GAMEN_KEY()
		I = 0
		Call DB_GetLs(DBN_BNKMTA, 1, SSS_FASTKEY.Value, BtrNormal)
		Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC))
			I = I + 1
			Call DB_GetPre(DBN_BNKMTA, BtrNormal)
		Loop 
		If DBSTAT <> 0 And I = 0 Then
			Call DB_GetFirst(DBN_BNKMTA, 1, BtrNormal)
		End If
		SSS_LASTKEY.Value = DB_PARA(DBN_BNKMTA).KeyBuf
		I = DSPMST()
		MST_PREV = I
	End Function
	
	Function SET_GAMEN_KEY() As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BNKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_BNKMTA.BNKCD = RD_SSSMAIN_BNKCD(0)
		SSS_LASTKEY.Value = DB_BNKMTA.BNKCD
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