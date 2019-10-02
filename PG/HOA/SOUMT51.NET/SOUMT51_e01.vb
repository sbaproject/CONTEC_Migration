Option Strict Off
Option Explicit On
Module SOUMT51_E01
	'
	' �X���b�g��        : ��ʏ����X���b�g
	' ���j�b�g��        : SOUMT51.E01
	' �L�q��            : Standard Library
	' �쐬���t          : 1998/03/10
	' �g�p�v���O������  : SOUMT51
	'
	Public Len506 As Short
	Public Len508 As Short
	Public Len509 As Short
	Public Len507 As Short
	Public Len511 As Short
	
	Function DSPMST() As Short
		Dim I As Short
		Dim wkSOUBSCD As String
		Dim wkSOUKOKB As String
		'
		I = 0
		SSS_FASTKEY.Value = SSS_LASTKEY.Value
		Call DB_GetGrEq(DBN_SOUMTA, 1, SSS_LASTKEY.Value, BtrNormal)
		
		'2007/12/18 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		ReDim M_MOTO_A_inf(4)
		'2007/12/18 add-end T.KAWAMUKAI
		
		If DBSTAT = 0 Then
			Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC + 1))
				Call SCR_FromMfil(I)
				Call DP_SSSMAIN_V_DATKB(I, DB_SOUMTA.DATKB) '2006.11.07
				Call DP_SSSMAIN_V_SOUNM(I, DB_SOUMTA.SOUNM) '2006.11.07
				Call DP_SSSMAIN_V_SOUZP(I, DB_SOUMTA.SOUZP) '2006.11.07
				Call DP_SSSMAIN_V_SOUADA(I, DB_SOUMTA.SOUADA) '2006.11.07
				Call DP_SSSMAIN_V_SOUADB(I, DB_SOUMTA.SOUADB) '2006.11.07
				Call DP_SSSMAIN_V_SOUADC(I, DB_SOUMTA.SOUADC) '2006.11.07
				Call DP_SSSMAIN_V_SOUTL(I, DB_SOUMTA.SOUTL) '2006.11.07
				Call DP_SSSMAIN_V_SOUFX(I, DB_SOUMTA.SOUFX) '2006.11.07
				Call DP_SSSMAIN_V_SOUBSC(I, DB_SOUMTA.SOUBSCD) '2006.11.07
				Call DP_SSSMAIN_V_SOUKB(I, DB_SOUMTA.SOUKB) '2006.11.07
				Call DP_SSSMAIN_V_SRSCNK(I, DB_SOUMTA.SRSCNKB) '2006.11.07
				Call DP_SSSMAIN_V_SISNKB(I, DB_SOUMTA.SISNKB) '2006.11.07
				Call DP_SSSMAIN_V_SOUTRI(I, DB_SOUMTA.SOUTRICD) '2006.11.07
				Call DP_SSSMAIN_V_SOUKOK(I, DB_SOUMTA.SOUKOKB) '2006.11.07
				Call DP_SSSMAIN_V_HIKKB(I, DB_SOUMTA.HIKKB) '2006.11.07
				Call DP_SSSMAIN_V_SALPAL(I, DB_SOUMTA.SALPALKB) '2006.11.07
				If DB_SOUMTA.DATKB = "9" Then
					Call DP_SSSMAIN_UPDKB(I, "�폜")
				Else
					Call DP_SSSMAIN_UPDKB(I, "�X�V")
				End If
                '2019/09/25 DEL START
                'Call MEIMTA_RClear()
                '2019/09/25 DEL END
                wkSOUBSCD = DB_SOUMTA.SOUBSCD & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_SOUMTA.SOUBSCD))
				Call DB_GetEq(DBN_MEIMTA, 2, "015" & wkSOUBSCD, BtrNormal)
				Call DP_SSSMAIN_SOUBSNM(I, Trim(DB_MEIMTA.MEINMA))
                '2019/09/25 DEL START
                'Call MEIMTA_RClear()
                '2019/09/25 DEL END
                wkSOUKOKB = DB_SOUMTA.SOUKOKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_SOUMTA.SOUKOKB))
				Call DB_GetEq(DBN_MEIMTA, 2, "026" & wkSOUKOKB, BtrNormal)
				Call DP_SSSMAIN_SOUKONM(I, Trim(DB_MEIMTA.MEINMA))
                '2019/09/25 DEL START
                'Call TOKMTA_RClear()
                '2019/09/25 DEL END
                Call DB_GetEq(DBN_TOKMTA, 1, DB_SOUMTA.SOUTRICD, BtrNormal)
				Call SCR_FromTOKMTA(I)
				I = I + 1
				Call DB_GetNext(DBN_SOUMTA, BtrNormal)
			Loop 
		End If
		If DBSTAT = 0 Then
			SSS_LASTKEY.Value = DB_SOUMTA.SOUCD
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSS_LASTKEY.Value = HighValue(LenWid(DB_SOUMTA.SOUCD))
		End If
		DSPMST = I
	End Function
	
	Sub INITDSP()
		Dim lngI As Integer
		Dim wkCRW As System.Windows.Forms.Control
		
		'�w�i�F�̐ݒ�
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(0) = 1 '���͒S���҃R�[�h
		CL_SSSMAIN(1) = 1 '���͒S����
		
		For lngI = 0 To PP_SSSMAIN.MaxDe
			CL_SSSMAIN(2 + (lngI * 36)) = 1 '�X�V�敪
			CL_SSSMAIN(6 + (lngI * 36)) = 1 '�ꏊ��
			CL_SSSMAIN(8 + (lngI * 36)) = 1 '�q�ɋ敪��
			CL_SSSMAIN(10 + (lngI * 36)) = 1 '����於
		Next 
		
		'���s�����`�F�b�N
		gs_userid = Left(SSS_OPEID.Value, 6) '���[�UID
		gs_pgid = SSS_PrgId '�v���O����ID
		Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
		If CDbl(Get_Authority(DB_UNYMTA.UNYDT, wkCRW)) = 9 Then
			Call MsgBox("���s����������܂���B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			End
		End If
		
		'�}�X�^�l�擾�i�Œ�l�}�X�^�j
		Call DB_GetEq(DBN_FIXMTA, 1, "506", BtrNormal) '14
		If DBSTAT = 0 Then Len506 = CShort(DB_FIXMTA.FIXVAL)
		
		Call DB_GetEq(DBN_FIXMTA, 1, "507", BtrNormal) '2
		If DBSTAT = 0 Then Len507 = CShort(DB_FIXMTA.FIXVAL)
		
		Call DB_GetEq(DBN_FIXMTA, 1, "508", BtrNormal) '8
		If DBSTAT = 0 Then Len508 = CShort(DB_FIXMTA.FIXVAL)
		
		Call DB_GetEq(DBN_FIXMTA, 1, "509", BtrNormal) '4
		If DBSTAT = 0 Then Len509 = CShort(DB_FIXMTA.FIXVAL)
		
		Call DB_GetEq(DBN_FIXMTA, 1, "511", BtrNormal) '4
		If DBSTAT = 0 Then Len511 = CShort(DB_FIXMTA.FIXVAL)
		
	End Sub
	
	Function MST_NEXT() As Short
		Dim Rtn As Short
		'
		Call DB_GetGrEq(DBN_SOUMTA, 1, SSS_LASTKEY.Value, BtrNormal)
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
		Call DB_GetLs(DBN_SOUMTA, 1, SSS_FASTKEY.Value, BtrNormal)
		Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC))
			I = I + 1
			Call DB_GetPre(DBN_SOUMTA, BtrNormal)
		Loop 
		If DBSTAT <> 0 And I = 0 Then
			Call DB_GetFirst(DBN_SOUMTA, 1, BtrNormal)
		End If
		SSS_LASTKEY.Value = DB_PARA(DBN_SOUMTA).KeyBuf
		I = DSPMST()
		MST_PREV = I
	End Function
	
	Function SET_GAMEN_KEY() As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SOUMTA.SOUCD = RD_SSSMAIN_SOUCD(0)
		SSS_LASTKEY.Value = DB_SOUMTA.SOUCD
		SET_GAMEN_KEY = 4
	End Function
	
	Function Execute_GetEvent() As Object
		
		Dim Rtn As Short
		
		'UPGRADE_WARNING: �I�u�W�F�N�g Execute_GetEvent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Execute_GetEvent = True
		If PP_SSSMAIN.LastDe = 0 Then
			''''''''Rtn = DSP_MsgBox(0, "NO_ENTRY", 0)  '�f�[�^����͂��ĉ�����
			Rtn = DSP_MsgBox(CStr(0), "_COMPLETEC", 0) '�f�[�^����͂��ĉ�����
			'UPGRADE_WARNING: �I�u�W�F�N�g Execute_GetEvent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Execute_GetEvent = False
			Exit Function
		End If
		
	End Function
End Module