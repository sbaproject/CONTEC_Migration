Option Strict Off
Option Explicit On
Module MEIMT52_E51
	'
	' �X���b�g��        : ��ʏ����X���b�g
	' ���j�b�g��        : MEIMT52.E01
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/07/12
	' �g�p�v���O������  : MEIMT52
	'
	'
	Public Const WG_KEYCD As String = "0"
	Dim FRKEYCD As Object
	Dim FRMEINM As Object

    '20190903 ADD START
    Function DSPMST_PREV() As Short
        Dim I As Short

        SSS_FASTKEY.Value = SSS_LASTKEY.Value

        FRKEYCD = DB_MEIMTB.KEYCD

        If Trim(FRKEYCD) = "" Then
            DSPMST_PREV = 0
            Exit Function
        End If

        Dim strSQL As String
        strSQL = ""
        strSQL = strSQL & " SELECT * "
        strSQL = strSQL & " FROM " & DBN_MEIMTA

        If Len(SSS_LASTKEY.Value) >= 28 Then
            strSQL = strSQL & " WHERE KEYCD  = '" & SSS_LASTKEY.Value.Substring(0, 3) & "'"
            strSQL = strSQL & " AND   MEICDA <= '" & SSS_LASTKEY.Value.Substring(3, 20) & "'"
            strSQL = strSQL & " AND   MEICDB = '" & SSS_LASTKEY.Value.Substring(23, 5) & "'"
        ElseIf Len(SSS_LASTKEY.Value) >= 23 Then
            strSQL = strSQL & " WHERE KEYCD  = '" & SSS_LASTKEY.Value.Substring(0, 3) & "'"
            strSQL = strSQL & " AND   MEICDA <= '" & SSS_LASTKEY.Value.Substring(3, 20) & "'"

        ElseIf Len(SSS_LASTKEY.Value) >= 3 Then
            strSQL = strSQL & " WHERE KEYCD = '" & SSS_LASTKEY.Value.Substring(0, 3) & "'"
        End If

        strSQL = strSQL & " ORDER BY MEICDA"

        DBSTAT = 0

        Dim dt As DataTable = DB_GetTable(strSQL)

        Call DP_SSSMAIN_FRKEYCD(-1, DB_MEIMTB.KEYCD)
        Call DP_SSSMAIN_FRMEINM(-1, DB_MEIMTB.MEIKMKNM)

        ReDim M_MEIMT_A_inf(4)

        I = 0
        If DBSTAT <> 0 Then
            Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "�ǉ�")
            Call Dsp_Prompt("RNOTFOUND", 0) '�V�K���R�[�h�ł��B
            For I = 0 To PP_SSSMAIN.MaxDspC
                Call SCR_FromMEIMTB(-1)
                Call SCR_FromMfil(I)
                If I <> 0 Then Call DP_SSSMAIN_UPDKB(I, " ")
            Next I
        Else
            If dt.Rows.Count = 5 Then
                For j As Integer = 0 To dt.Rows.Count - 1
                    Call SCR_FromMfil(I)
                    Call DP_SSSMAIN_V_DATKB(I, dt.Rows(j)("DATKB")) '2006.11.07
                    Call DP_SSSMAIN_V_MEINMA(I, dt.Rows(j)("MEINMA")) '2006.11.07
                    Call DP_SSSMAIN_V_MEINMB(I, dt.Rows(j)("MEINMB")) '2006.11.07
                    Call DP_SSSMAIN_V_MEINMC(I, dt.Rows(j)("MEINMC")) '2006.11.07
                    Call DP_SSSMAIN_V_MEISUA(I, dt.Rows(j)("MEISUA")) '2006.11.07
                    Call DP_SSSMAIN_V_MEISUB(I, dt.Rows(j)("MEISUB")) '2006.11.07
                    Call DP_SSSMAIN_V_MEISUC(I, dt.Rows(j)("MEISUC")) '2006.11.07
                    Call DP_SSSMAIN_V_MEIKBA(I, dt.Rows(j)("MEIKBA")) '2006.11.07
                    Call DP_SSSMAIN_V_MEIKBB(I, dt.Rows(j)("MEIKBB")) '2006.11.07
                    Call DP_SSSMAIN_V_MEIKBC(I, dt.Rows(j)("MEIKBC")) '2006.11.07
                    Call DP_SSSMAIN_V_DSPORD(I, dt.Rows(j)("DSPORD")) '2006.11.07
                    If dt.Rows(j)("DATKB") = "9" Then
                        Call DP_SSSMAIN_UPDKB(I, "�폜")
                    Else
                        Call DP_SSSMAIN_UPDKB(I, "�X�V")
                    End If
                    '20���݂�̂Ō�������
                    If Trim(dt.Rows(I)("MEICDA")) <> "" Then
                        Call DP_SSSMAIN_MEICDA(I, Trim(dt.Rows(j)("MEICDA")))
                    End If
                    If Trim(dt.Rows(I)("MEICDB")) <> "" Then
                        Call DP_SSSMAIN_MEICDB(I, Trim(dt.Rows(j)("MEICDB")))
                    End If

                    '��O����(��ʏ�ɂ��݂��c��̂Łj
                    If I > 0 And Trim(FR_SSSMAIN.BD_MEICDA(0).Text) = Trim(dt.Rows(j)("MEICDA")) And Trim(FR_SSSMAIN.BD_MEICDB(0).Text) = Trim(dt.Rows(j)("MEICDB")) Then
                        Exit For
                    End If

                    I = I + 1

                    DB_MEIMTA.KEYCD = dt.Rows(dt.Rows.Count - 1)("KEYCD")
                    DB_MEIMTA.MEICDA = dt.Rows(dt.Rows.Count - 1)("MEICDA")
                    DB_MEIMTA.MEICDB = dt.Rows(dt.Rows.Count - 1)("MEICDB")
                Next
            ElseIf dt.Rows.Count > 5 Then
                For j As Integer = dt.Rows.Count - 6 To dt.Rows.Count - 2
                    Call SCR_FromMfil(I)
                    Call DP_SSSMAIN_V_DATKB(I, dt.Rows(j)("DATKB")) '2006.11.07
                    Call DP_SSSMAIN_V_MEINMA(I, dt.Rows(j)("MEINMA")) '2006.11.07
                    Call DP_SSSMAIN_V_MEINMB(I, dt.Rows(j)("MEINMB")) '2006.11.07
                    Call DP_SSSMAIN_V_MEINMC(I, dt.Rows(j)("MEINMC")) '2006.11.07
                    Call DP_SSSMAIN_V_MEISUA(I, dt.Rows(j)("MEISUA")) '2006.11.07
                    Call DP_SSSMAIN_V_MEISUB(I, dt.Rows(j)("MEISUB")) '2006.11.07
                    Call DP_SSSMAIN_V_MEISUC(I, dt.Rows(j)("MEISUC")) '2006.11.07
                    Call DP_SSSMAIN_V_MEIKBA(I, dt.Rows(j)("MEIKBA")) '2006.11.07
                    Call DP_SSSMAIN_V_MEIKBB(I, dt.Rows(j)("MEIKBB")) '2006.11.07
                    Call DP_SSSMAIN_V_MEIKBC(I, dt.Rows(j)("MEIKBC")) '2006.11.07
                    Call DP_SSSMAIN_V_DSPORD(I, dt.Rows(j)("DSPORD")) '2006.11.07
                    If dt.Rows(j)("DATKB") = "9" Then
                        Call DP_SSSMAIN_UPDKB(I, "�폜")
                    Else
                        Call DP_SSSMAIN_UPDKB(I, "�X�V")
                    End If
                    '20���݂�̂Ō�������
                    If Trim(dt.Rows(I)("MEICDA")) <> "" Then
                        Call DP_SSSMAIN_MEICDA(I, Trim(dt.Rows(j)("MEICDA")))
                    End If
                    If Trim(dt.Rows(I)("MEICDB")) <> "" Then
                        Call DP_SSSMAIN_MEICDB(I, Trim(dt.Rows(j)("MEICDB")))
                    End If

                    '��O����(��ʏ�ɂ��݂��c��̂Łj
                    If I > 0 And Trim(FR_SSSMAIN.BD_MEICDA(0).Text) = Trim(dt.Rows(j)("MEICDA")) And Trim(FR_SSSMAIN.BD_MEICDB(0).Text) = Trim(dt.Rows(j)("MEICDB")) Then
                        Exit For
                    End If

                    I = I + 1

                    DB_MEIMTA.KEYCD = dt.Rows(dt.Rows.Count - 6)("KEYCD")
                    DB_MEIMTA.MEICDA = dt.Rows(dt.Rows.Count - 6)("MEICDA")
                    DB_MEIMTA.MEICDB = dt.Rows(dt.Rows.Count - 6)("MEICDB")
                Next
            Else
                I = DSPMST()
            End If
        End If

        If DBSTAT = 0 Then
            SSS_FASTKEY.Value = DB_MEIMTA.KEYCD & DB_MEIMTA.MEICDA & DB_MEIMTA.MEICDB
        Else
            SSS_FASTKEY.Value = HighValue(LenWid(DB_MEIMTA.KEYCD)) & HighValue(LenWid(DB_MEIMTA.MEICDA)) & HighValue(LenWid(DB_MEIMTA.MEICDB))
        End If

        DSPMST_PREV = I
    End Function
    '20190903 ADD END


    Function DSPMST() As Short
		Dim I As Short
        '20190826 DEL START
        'Call MEIMTA_RClear()
        '20190826 DEL END

        SSS_FASTKEY.Value = SSS_LASTKEY.Value
		'FRKEYCD = Mid$(SSS_LASTKEY, 1, 3)
		'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		FRKEYCD = DB_MEIMTB.KEYCD
        'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(FRKEYCD) = "" Then
            DSPMST = 0
            Exit Function
        End If
        '20190830 CHG START
        'Call DB_GetGrEq(DBN_MEIMTA, 1, SSS_LASTKEY.Value, BtrNormal)
        Dim strSQL As String
        strSQL = ""
        strSQL = strSQL & " SELECT * "
        strSQL = strSQL & " FROM " & DBN_MEIMTA

        If Len(SSS_LASTKEY.Value) >= 28 Then
            strSQL = strSQL & " WHERE KEYCD  = '" & SSS_LASTKEY.Value.Substring(0, 3) & "'"
            strSQL = strSQL & " AND   MEICDA >= '" & SSS_LASTKEY.Value.Substring(3, 20) & "'"
            strSQL = strSQL & " AND   MEICDB >= '" & SSS_LASTKEY.Value.Substring(23, 5) & "'"
        ElseIf Len(SSS_LASTKEY.Value) >= 23 Then
            strSQL = strSQL & " WHERE KEYCD  = '" & SSS_LASTKEY.Value.Substring(0, 3) & "'"
            strSQL = strSQL & " AND   MEICDA >= '" & SSS_LASTKEY.Value.Substring(3, 20) & "'"

        ElseIf Len(SSS_LASTKEY.Value) >= 3 Then
            strSQL = strSQL & " WHERE KEYCD = '" & SSS_LASTKEY.Value.Substring(0, 3) & "'"
        End If

        strSQL = strSQL & " ORDER BY MEICDA"

        DBSTAT = 0

        Dim dt As DataTable = DB_GetTable(strSQL)
        '20190830 CHG END

        Call DP_SSSMAIN_FRKEYCD(-1, DB_MEIMTB.KEYCD)
		Call DP_SSSMAIN_FRMEINM(-1, DB_MEIMTB.MEIKMKNM)
		
		' === 20080916 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
		''2007/12/18 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		'    ReDim M_MOTO_A_inf(4)
		''2007/12/18 add-end T.KAWAMUKAI
		ReDim M_MEIMT_A_inf(4)
		' === 20080916 === UPDATE E - RISE)Izumi
		
		I = 0
		If DBSTAT <> 0 Then
			'DB��Ɏw��L�[�̂��̂����݂��Ȃ��Ƃ�
			Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "�ǉ�")
			Call Dsp_Prompt("RNOTFOUND", 0) '�V�K���R�[�h�ł��B
			For I = 0 To PP_SSSMAIN.MaxDspC
				Call SCR_FromMEIMTB(-1)
				Call SCR_FromMfil(I)
				If I <> 0 Then Call DP_SSSMAIN_UPDKB(I, " ")
			Next I
		Else
            'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '20190830 CHG START
            'Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC + 1)) And DB_MEIMTA.KEYCD = FRKEYCD
            '    Call SCR_FromMfil(I)
            '    Call DP_SSSMAIN_V_DATKB(I, DB_MEIMTA.DATKB) '2006.11.07
            '    Call DP_SSSMAIN_V_MEINMA(I, DB_MEIMTA.MEINMA) '2006.11.07
            '    Call DP_SSSMAIN_V_MEINMB(I, DB_MEIMTA.MEINMB) '2006.11.07
            '    Call DP_SSSMAIN_V_MEINMC(I, DB_MEIMTA.MEINMC) '2006.11.07
            '    Call DP_SSSMAIN_V_MEISUA(I, DB_MEIMTA.MEISUA) '2006.11.07
            '    Call DP_SSSMAIN_V_MEISUB(I, DB_MEIMTA.MEISUB) '2006.11.07
            '    Call DP_SSSMAIN_V_MEISUC(I, DB_MEIMTA.MEISUC) '2006.11.07
            '    Call DP_SSSMAIN_V_MEIKBA(I, DB_MEIMTA.MEIKBA) '2006.11.07
            '    Call DP_SSSMAIN_V_MEIKBB(I, DB_MEIMTA.MEIKBB) '2006.11.07
            '    Call DP_SSSMAIN_V_MEIKBC(I, DB_MEIMTA.MEIKBC) '2006.11.07
            '    Call DP_SSSMAIN_V_DSPORD(I, DB_MEIMTA.DSPORD) '2006.11.07
            '    If DB_MEIMTA.DATKB = "9" Then
            '        Call DP_SSSMAIN_UPDKB(I, "�폜")
            '    Else
            '        Call DP_SSSMAIN_UPDKB(I, "�X�V")
            '    End If
            '    '20���݂�̂Ō�������
            '    If Trim(DB_MEIMTA.MEICDA) <> "" Then
            '        'Call DP_SSSMAIN_MEICDA(I, Trim$(Space(LenWid(DB_MEIMTA.MEICDA) - LenWid(Trim$(DB_MEIMTA.MEICDA))) & Trim$(DB_MEIMTA.MEICDA)))
            '        Call DP_SSSMAIN_MEICDA(I, Trim(DB_MEIMTA.MEICDA))
            '    End If
            '    If Trim(DB_MEIMTA.MEICDB) <> "" Then
            '        Call DP_SSSMAIN_MEICDB(I, Trim(DB_MEIMTA.MEICDB))
            '    End If
            '    I = I + 1
            '    Call DB_GetNext(DBN_MEIMTA, BtrNormal)
            '    '��O����(��ʏ�ɂ��݂��c��̂Łj
            '    If I > 0 And Trim(FR_SSSMAIN.BD_MEICDA(0).Text) = Trim(DB_MEIMTA.MEICDA) And Trim(FR_SSSMAIN.BD_MEICDB(0).Text) = Trim(DB_MEIMTA.MEICDB) Then
            '        Exit Do
            '    End If
            'Loop

            Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC + 1))
                If I < dt.Rows.Count Then
                    Call SCR_FromMfil(I)
                    Call DP_SSSMAIN_V_DATKB(I, dt.Rows(I)("DATKB")) '2006.11.07
                    Call DP_SSSMAIN_V_MEINMA(I, dt.Rows(I)("MEINMA")) '2006.11.07
                    Call DP_SSSMAIN_V_MEINMB(I, dt.Rows(I)("MEINMB")) '2006.11.07
                    Call DP_SSSMAIN_V_MEINMC(I, dt.Rows(I)("MEINMC")) '2006.11.07
                    Call DP_SSSMAIN_V_MEISUA(I, dt.Rows(I)("MEISUA")) '2006.11.07
                    Call DP_SSSMAIN_V_MEISUB(I, dt.Rows(I)("MEISUB")) '2006.11.07
                    Call DP_SSSMAIN_V_MEISUC(I, dt.Rows(I)("MEISUC")) '2006.11.07
                    Call DP_SSSMAIN_V_MEIKBA(I, dt.Rows(I)("MEIKBA")) '2006.11.07
                    Call DP_SSSMAIN_V_MEIKBB(I, dt.Rows(I)("MEIKBB")) '2006.11.07
                    Call DP_SSSMAIN_V_MEIKBC(I, dt.Rows(I)("MEIKBC")) '2006.11.07
                    Call DP_SSSMAIN_V_DSPORD(I, dt.Rows(I)("DSPORD")) '2006.11.07
                    If dt.Rows(I)("DATKB") = "9" Then
                        Call DP_SSSMAIN_UPDKB(I, "�폜")
                    Else
                        Call DP_SSSMAIN_UPDKB(I, "�X�V")
                    End If
                    '20���݂�̂Ō�������
                    If Trim(dt.Rows(I)("MEICDA")) <> "" Then
                        Call DP_SSSMAIN_MEICDA(I, Trim(dt.Rows(I)("MEICDA")))
                    End If
                    If Trim(dt.Rows(I)("MEICDB")) <> "" Then
                        Call DP_SSSMAIN_MEICDB(I, Trim(dt.Rows(I)("MEICDB")))
                    End If

                    '��O����(��ʏ�ɂ��݂��c��̂Łj
                    If I > 0 And Trim(FR_SSSMAIN.BD_MEICDA(0).Text) = Trim(dt.Rows(I)("MEICDA")) And Trim(FR_SSSMAIN.BD_MEICDB(0).Text) = Trim(dt.Rows(I)("MEICDB")) Then
                        Exit Do
                    End If

                    I = I + 1

                    If I <= dt.Rows.Count - 1 Then
                        DB_MEIMTA.KEYCD = dt.Rows(I)("KEYCD")
                        DB_MEIMTA.MEICDA = dt.Rows(I)("MEICDA")
                        DB_MEIMTA.MEICDB = dt.Rows(I)("MEICDB")
                    Else
                        DBSTAT = 1
                    End If
                Else
                    Exit Do
                End If
            Loop
            '20190830 CHG END

        End If
		If DBSTAT = 0 Then
			SSS_LASTKEY.Value = DB_MEIMTA.KEYCD & DB_MEIMTA.MEICDA & DB_MEIMTA.MEICDB
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSS_LASTKEY.Value = HighValue(LenWid(DB_MEIMTA.KEYCD)) & HighValue(LenWid(DB_MEIMTA.MEICDA)) & HighValue(LenWid(DB_MEIMTA.MEICDB))
		End If
        DSPMST = I

    End Function
	
	Sub INITDSP()
		Dim lngI As Integer
		
		'�w�i�F�̐ݒ�
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(1) = 1
		CL_SSSMAIN(2) = 1
		CL_SSSMAIN(3) = 1
		
		For lngI = 0 To PP_SSSMAIN.MaxDe
			''''    CL_SSSMAIN(4 + (lngI * 15)) = 1                 '2006.11.07
			CL_SSSMAIN(4 + (lngI * 26)) = 1
		Next 
		
		'���s�����`�F�b�N
		Dim wkDATE As String
		Dim wkCRW As System.Windows.Forms.Control
		gs_userid = Left(SSS_OPEID.Value, 6) '���[�UID
		gs_pgid = SSS_PrgId '�v���O����ID

        '20190827 CHG START
        'Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
        Call GetRowsCommon("UNYMTA", "")
        '20190827 CHG END

        '���s�����̎擾
        If CDbl(Get_Authority(DB_UNYMTA.UNYDT, wkCRW)) = 9 Then
			Call MsgBox("���s����������܂���B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			End
		End If
		
	End Sub
	
	Function MFIL_RelCheck(ByVal FRKEYCD As Object, ByVal MEICDA As Object, ByVal MEICDB As Object, ByVal DE_INDEX As Object) As Object
		Dim OPEID As String
		Dim OKFL As Boolean
		Dim wkMEICDA As String
		'�ڍ�����
		'UPGRADE_WARNING: �I�u�W�F�N�g MFIL_RelCheck �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		MFIL_RelCheck = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(FRKEYCD) = "" Or Trim(MEICDA) = "" Then
            '20190826 DEL START
            'Call MEIMTA_RClear()
            '20190826 DEL END

            Exit Function
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(DB_MEIMTA.MEICDA) > "" And Trim(MEICDA) > "" Then OKFL = True
		'UPGRADE_WARNING: �I�u�W�F�N�g MEICDB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(DB_MEIMTA.MEICDB) > "" And Trim(MEICDB) > "" Then OKFL = True
		'Call MEIMTA_RClear
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_FRKEYCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		FRKEYCD = RD_SSSMAIN_FRKEYCD(-1)
		Call DB_GetEq(DBN_MEIMTB, 1, FRKEYCD, BtrNormal)
		If DBSTAT <> 0 Or OKFL = False Then Exit Function
		''''Call DB_GetEq(DBN_MEIMTA, 1, FRKEYCD & MEICDA & MEICDB, BtrNormal)
		'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wkMEICDA = MEICDA & Space(Len(DB_MEIMTA.MEICDA) - Len(Trim(MEICDA)))
		'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call DB_GetEq(DBN_MEIMTA, 2, FRKEYCD & MEICDA, BtrNormal)
		If DBSTAT = 0 Then
			If DB_MEIMTA.DATKB <> "9" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call DP_SSSMAIN_UPDKB(DE_INDEX, "�X�V")
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call DP_SSSMAIN_UPDKB(DE_INDEX, "�폜")
			End If
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DP_SSSMAIN_UPDKB(DE_INDEX, "�ǉ�")
		End If
		
	End Function
	
	Function MST_NEXT() As Short
		Dim Rtn As Short
		Dim FRKEYCD, OPEID As String
        '
        FRKEYCD = DB_MEIMTB.KEYCD
        '20190902 CHG START
        'Call DB_GetGrEq(DBN_MEIMTA, 1, SSS_LASTKEY.Value, BtrNormal)
        Dim strSQL As String

        If Len(SSS_LASTKEY.Value) >= 28 Then
            strSQL = strSQL & " WHERE KEYCD  = '" & SSS_LASTKEY.Value.Substring(0, 3) & "'"
            strSQL = strSQL & " AND   MEICDA >= '" & SSS_LASTKEY.Value.Substring(3, 20) & "'"
            strSQL = strSQL & " AND   MEICDB >= '" & SSS_LASTKEY.Value.Substring(23, 5) & "'"
        ElseIf Len(SSS_LASTKEY.Value) >= 23 Then
            strSQL = strSQL & " WHERE KEYCD  = '" & SSS_LASTKEY.Value.Substring(0, 3) & "'"
            strSQL = strSQL & " AND   MEICDA >= '" & SSS_LASTKEY.Value.Substring(3, 20) & "'"

        ElseIf Len(SSS_LASTKEY.Value) >= 3 Then
            strSQL = strSQL & " WHERE KEYCD = '" & SSS_LASTKEY.Value.Substring(0, 3) & "'"
        End If

        strSQL = strSQL & " ORDER BY MEICDA"

        GetRowsCommon(DBN_MEIMTA, strSQL)
        '20190902 CHG END

        If DBSTAT = 0 And DB_MEIMTA.KEYCD = FRKEYCD Then '
			MST_NEXT = DSPMST()
		Else
			SSS_LASTKEY.Value = SSS_FASTKEY.Value
			MST_NEXT = DSPMST()
		End If
	End Function
	
	Function MST_PREV() As Short
		Dim I, Rtn As Short
		'
		'FRKEYCD = Mid$(SSS_LASTKEY, 1, 3)
		'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		FRKEYCD = DB_MEIMTB.KEYCD
		'UPGRADE_WARNING: �I�u�W�F�N�g SET_GAMEN_KEY() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Rtn = SET_GAMEN_KEY()
		I = 0
		
		Call DB_GetLs(DBN_MEIMTA, 1, SSS_FASTKEY.Value, BtrNormal)
		' Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC) + 1) And DB_MEIMTA.KEYCD = FRKEYCD
		Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC)) And DB_MEIMTA.KEYCD = DB_MEIMTB.KEYCD
			Call DB_GetPre(DBN_MEIMTA, BtrNormal)
			I = I + 1
		Loop 
		I = 0
		If DBSTAT <> 0 Or DB_MEIMTA.KEYCD <> DB_MEIMTB.KEYCD Then '
			'If DBSTAT <> 0 Then '
			'Call DB_GetGrEq(DBN_MEIMTA, 1, FRKEYCD & DB_MEIMTA.MEICDA & DB_MEIMTA.MEICDB, BtrNormal)
			Call DB_GetGrEq(DBN_MEIMTA, 1, SSS_FASTKEY.Value, BtrNormal)
		End If
        I = 0
        '20190902 CHG START
        'SSS_LASTKEY.Value = DB_PARA(DBN_MEIMTA).KeyBuf
        SSS_LASTKEY.Value = SSS_FASTKEY.Value
        '20190902 CHG END

        '20190903 CHG START
        'MST_PREV = DSPMST()
        MST_PREV = DSPMST_PREV()
        '20190903 CHG END

    End Function
	
	Function SET_GAMEN_KEY() As Object
		Dim De As Short
		'UPGRADE_WARNING: �I�u�W�F�N�g SET_GAMEN_KEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SET_GAMEN_KEY = 0
		'FRKEYCD = FR_SSSMAIN.HD_FRKEYCD.Text
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_FRKEYCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		FRKEYCD = RD_SSSMAIN_FRKEYCD(-1)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_FRMEINM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g FRMEINM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		FRMEINM = RD_SSSMAIN_FRMEINM(-1)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.KEYCD = FRKEYCD
		'UPGRADE_WARNING: �I�u�W�F�N�g FRMEINM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.MEIKMKNM = FRMEINM
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEICDA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.MEICDA = RD_SSSMAIN_MEICDA(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEICDB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.MEICDB = RD_SSSMAIN_MEICDB(0)
		If Trim(FR_SSSMAIN.HD_FRKEYCD.Text) = "" Then DB_MEIMTA.KEYCD = " " : Exit Function
		
		If Len(DB_MEIMTB.KEYCD) < 1 Then Exit Function
		If Len(DB_MEIMTA.KEYCD) < 1 Then Exit Function
		SSS_LASTKEY.Value = DB_MEIMTA.KEYCD & DB_MEIMTA.MEICDA & DB_MEIMTA.MEICDB
		'UPGRADE_WARNING: �I�u�W�F�N�g SET_GAMEN_KEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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