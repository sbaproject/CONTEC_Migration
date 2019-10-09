Option Strict Off
Option Explicit On
Module FIXMT51_E01
	'
	' �X���b�g��        : ��ʏ����X���b�g
	' ���j�b�g��        : FIXMT51.E01
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/10
	' �g�p�v���O������  : FIXMT51
	'
	Public WG_UNYDT As String '�^�p��
	Function DSPMST() As Short
		Dim I As Short
		Dim wkTOKCD As String
		'
		I = 0
		Call FIXMTA_RClear()
		SSS_FASTKEY.Value = SSS_LASTKEY.Value
		Call DB_GetGrEq(DBN_FIXMTA, 1, SSS_LASTKEY.Value, BtrNormal)
		
		' === 20081002 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
		''2007/12/18 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		'    ReDim M_MOTO_A_inf(14)
		''2007/12/18 add-end T.KAWAMUKAI
		ReDim M_FIXMT_A_inf(14)
		' === 20081002 === UPDATE E - RISE)Izumi
		
		If DBSTAT = 0 Then
			Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC + 1))
				Call SCR_FromMfil(I)
				If DB_FIXMTA.DATKB = "9" Then
					Call DP_SSSMAIN_UPDKB(I, "�폜")
				Else
					Call DP_SSSMAIN_UPDKB(I, "�X�V")
				End If
				
				I = I + 1
				Call DB_GetNext(DBN_FIXMTA, BtrNormal)
			Loop 
		End If
		If DBSTAT = 0 Then
			SSS_LASTKEY.Value = DB_FIXMTA.CTLCD
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSS_LASTKEY.Value = HighValue(LenWid(DB_FIXMTA.CTLCD))
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
			' CL_SSSMAIN(2 + (lngI * 9)) = 1
			' CL_SSSMAIN(4 + (lngI * 9)) = 1
			' CL_SSSMAIN(6 + (lngI * 9)) = 1
			CL_SSSMAIN(2 + (lngI * 5)) = 1
		Next

        '�^�p���擾
        '2019/10/07 CHG START
        'Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
        Call GetRowsCommon("UNYMTA", "")
        If DB_UNYMTA.UNYKBA Is Nothing Then
            DBSTAT = 1
        Else
            DBSTAT = 0
        End If
        '2019/10/07 CHG E N D
        If DBSTAT = 0 Then
			WG_UNYDT = DB_UNYMTA.UNYDT
		Else
			WG_UNYDT = ""
		End If
		'---�����擾---
		Dim wkDATE As String
		Dim wkCRW As System.Windows.Forms.Control
		wkDATE = VB6.Format(Now, "YYYYMMDD")
		gs_userid = Left(SSS_OPEID.Value, 6) '���[�UID
		gs_pgid = "FIXMT51" '�v���O����ID
		
		If CDbl(Get_Authority(wkDATE, wkCRW)) = 9 Then
			Call MsgBox("���s����������܂���B", MsgBoxStyle.OKOnly)
			End
		End If
	End Sub
	
	Function MFIL_RelCheck(ByVal CTLCD As Object, ByVal De_Index As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g MFIL_RelCheck �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		MFIL_RelCheck = 0
		Call FIXMTA_RClear()
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CTLCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(CTLCD) = "" Then
			Exit Function
		Else
			
			Call DB_GetEq(DBN_FIXMTA, 1, CTLCD, BtrNormal)
			
			If DBSTAT = 0 Then
				If DB_FIXMTA.DATKB = "9" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_UPDKB(De_Index, "�폜")
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_UPDKB(De_Index, "�X�V")
				End If
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call DP_SSSMAIN_UPDKB(De_Index, "�V�K")
			End If
			
		End If
	End Function
	
	Function MST_NEXT() As Short
		Dim Rtn As Short
		'
		Call DB_GetGrEq(DBN_FIXMTA, 1, SSS_LASTKEY.Value, BtrNormal)
		If DBSTAT = 0 Then
			MST_NEXT = DSPMST()
		Else
			SSS_LASTKEY.Value = SSS_FASTKEY.Value
			MST_NEXT = DSPMST()
		End If
	End Function
	
	Function MST_PREV() As Object
		Dim I As Short
		'
		I = SET_GAMEN_KEY()
		I = 0
		Call DB_GetLs(DBN_FIXMTA, 1, SSS_FASTKEY.Value, BtrNormal)
		Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC))
			I = I + 1
			Call DB_GetPre(DBN_FIXMTA, BtrNormal)
		Loop
        If DBSTAT <> 0 And I = 0 Then
            Call DB_GetFirst(DBN_FIXMTA, 1, BtrNormal)
        End If
        '2019/10/08 CHG START
        'SSS_LASTKEY.Value = DB_PARA(DBN_FIXMTA).KeyBuf
        SSS_LASTKEY.Value = DB_PARA(4).KeyBuf
        '2019/10/08 CHG E N D
        Call SCR_FromMfil(I)
		I = DSPMST()
		'UPGRADE_WARNING: �I�u�W�F�N�g MST_PREV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		MST_PREV = I
	End Function
	
	Function SET_GAMEN_KEY() As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_CTLCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_FIXMTA.CTLCD = RD_SSSMAIN_CTLCD(0)
		
		SSS_LASTKEY.Value = DB_FIXMTA.CTLCD
		
		SET_GAMEN_KEY = 4
	End Function
End Module