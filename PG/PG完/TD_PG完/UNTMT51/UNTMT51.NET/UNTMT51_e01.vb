Option Strict Off
Option Explicit On
Module UNTMT51_E01
	'
	' �X���b�g��        : ��ʏ����X���b�g
	' ���j�b�g��        : UNTMT51.E01
	' �L�q��            : Standard Library
	' �쐬���t          : 1998/03/10
	' �g�p�v���O������  : UNTMT51
	'
	
	Function DSPMST() As Short
		Dim I As Short
        '
        I = 0
        '20190805 CHG START
        ' SSS_FASTKEY.Value = SSS_LASTKEY.Value
        If String.IsNullOrWhiteSpace(SSS_LASTKEY.Value) Then
            SSS_FASTKEY.Value = "00"
            SSS_LASTKEY.Value = "00"
        Else
            SSS_FASTKEY.Value = SSS_LASTKEY.Value

        End If
        '20190805 CHG END
        Call DB_GetGrEq(DBN_UNTMTA, 1, SSS_LASTKEY.Value, BtrNormal)


        '20080929 CHG START RISE)Tanimura '�r������
        ''2007/12/18 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
        '    ReDim M_MOTO_A_inf(14)
        ''2007/12/18 add-end T.KAWAMUKAI

        ReDim M_UNTMT_A_inf(14)
        '20080929 CHG END   RISE)Tanimura

        If DBSTAT = 0 Then
            Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC + 1))
                Call SCR_FromMfil(I)
                Call DP_SSSMAIN_V_DATKB(I, DB_UNTMTA.DATKB) '2006.11.07
                Call DP_SSSMAIN_V_UNTNM(I, DB_UNTMTA.UNTNM) '2006.11.07
                If DB_UNTMTA.DATKB = "9" Then
                    Call DP_SSSMAIN_UPDKB(I, "�폜")
                Else
                    Call DP_SSSMAIN_UPDKB(I, "�X�V")
                End If
                I = I + 1
                Call DB_GetNext(DBN_UNTMTA, BtrNormal)
            Loop
        End If
        If DBSTAT = 0 Then
            SSS_LASTKEY.Value = DB_UNTMTA.UNTCD
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            SSS_LASTKEY.Value = HighValue(LenWid(DB_UNTMTA.UNTCD))
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
			''''    CL_SSSMAIN(4 + (lngI * 3)) = 1              '2006.11.07
			CL_SSSMAIN(4 + (lngI * 5)) = 1
		Next 
		
		'���s�����`�F�b�N
		Dim wkDATE As String
		Dim wkCRW As System.Windows.Forms.Control
		gs_userid = Left(SSS_OPEID.Value, 6) '���[�UID
		gs_pgid = SSS_PrgId '�v���O����ID

        '20190729 CHG START
        'Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
        Call GetRowsCommon("UNYMTA", "")
        If DB_UNYMTA.UNYKBA Is Nothing Then
            DBSTAT = 1
        Else
            DBSTAT = 0
        End If
        '20190729 CHG END
        If CDbl(Get_Authority(DB_UNYMTA.UNYDT, wkCRW)) = 9 Then
			Call MsgBox("���s����������܂���B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			End
		End If
		
	End Sub
	
	Function MST_NEXT() As Short
		Dim rtn As Short
		'
		Call DB_GetGrEq(DBN_UNTMTA, 1, SSS_LASTKEY.Value, BtrNormal)
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
		Call DB_GetLs(DBN_UNTMTA, 1, SSS_FASTKEY.Value, BtrNormal)
		Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC))
			I = I + 1
			Call DB_GetPre(DBN_UNTMTA, BtrNormal)
		Loop
        If DBSTAT <> 0 And I = 0 Then
            '20190730 CHG START
            ' Call DB_GetFirst(DBN_UNTMTA, 1, BtrNormal)
            Call GetRowsCommon("UNTMTA", "")
            '20190730 CHG END
        End If
        '20190730 CHG START
        'SSS_LASTKEY.Value = DB_PARA(DBN_UNTMTA).KeyBuf
        'SSS_LASTKEY.Value = DB_UNTMTA.UNTCD
        If DBSTAT = 0 Then
            SSS_LASTKEY.Value = DB_UNTMTA.UNTCD
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            SSS_LASTKEY.Value = HighValue(LenWid(DB_UNTMTA.UNTCD))
        End If
        '20190730 CHG END
        I = DSPMST()
		MST_PREV = I
	End Function
	
	Function SET_GAMEN_KEY() As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UNTCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_UNTMTA.UNTCD = RD_SSSMAIN_UNTCD(0)
		SSS_LASTKEY.Value = DB_UNTMTA.UNTCD
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