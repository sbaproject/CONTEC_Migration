Option Strict Off
Option Explicit On
Module URIET51_E81
	'
	' �X���b�g��        : ��ʓ��������E��ʏ����X���b�g
	' ���j�b�g��        : URIET51.E81
	' �L�q��            : Muratani
	' �쐬���t          : 2006/08/28
	' �g�p�v���O������  : URIET51
	'
	Public Const WG_DKBSB As String = "040"
	
	Public WG_DSPKB As Short '1:����`�[ 2:�󒍓`�[
	Public WG_BILFL As Short
	Public WG_JDNINKB As String '1:����2:�ʔ�3:VAN4:WEB
	Public WG_SYSTEM As String 'M:MEIKBA(�󒍎���敪�p�j�V�X�e��
	Public WG_JDNDATNO As String '�󒍍ŐV����DATNO
	'2007/12/05 FKS)minamoto ADD START
	Structure TYPE_HAITA_UPDDT
		Dim DATNO As String '�`�[�Ǘ�NO.
		Dim LINNO As String '�s�ԍ�
		Dim WRTTM As String '��ѽ����(����)
		Dim WRTDT As String '��ѽ����(���t)
		Dim UWRTTM As String '��ѽ����(����)
		Dim UWRTDT As String '��ѽ����(���t)
	End Structure
	Private HAITA_JDNTRA() As TYPE_HAITA_UPDDT
	'2007/12/05 FKS)minamoto ADD END
	
	Function DSPTRN() As Object
		Dim I As Short
		Dim WL_DATNO As String
		Dim WL_CASSU As Decimal
		Dim WL_URISU As Decimal
		Dim Rtn As Short
		Dim rResult As Short ' �����`�F�b�N�֐��߂�l
		Dim wkTNKKB As String
		Dim wkJDNTRKB As String

        '2019/04/01 ADD START
        Dim sqlStr As String
        '2019/04/01 ADD E N D
        '2019/06/26 ADD START
        Dim sqlWhereStr As String = ""
        '2019/06/26 ADD E N D
        '�V���A�����o�^���[�N�̍폜
        '2019/04/01 CHG START
        'Call DB_BeginTransaction(CStr(BTR_Exclude))
        Call DB_BeginTrans(CON)
        '2019/04/01 CHG E N D
        '2019/04/02 CHG START
        'Call DB_GetGrEq(DBN_USRET51, 3, SSS_CLTID.Value, BtrNormal)
        sqlStr = ""
        sqlStr &= " SELECT "
        sqlStr &= "  * "
        sqlStr &= " FROM CNT_USR9.USRET51 "
        sqlStr &= " WHERE RPTCLTID = '" & SSS_CLTID.Value & "'"

        Dim dtUSRET51 As DataTable = DB_GetTable(sqlStr)
        '2019/04/02 CHG E N D
        '2019/04/02 CHG START
        'Do While (DBSTAT = 0) And (Trim(DB_USRET51.RPTCLTID) = Trim(SSS_CLTID.Value))
        '    Call DB_Delete(DBN_USRET51)
        '    Call DB_GetNext(DBN_USRET51, BtrNormal)
        'Loop
        For Each row As DataRow In dtUSRET51.Rows
            sqlStr = ""
            sqlStr &= " DELETE "
            sqlStr &= " FROM CNT_USR9.USRET51 "
            sqlStr &= " WHERE RPTCLTID = '" & row("RPTCLTID") & "'"

            Call DB_Execute(sqlStr)
        Next
        '2019/04/02 CHG E N D
        '2019/04/01 CHG START
        'Call DB_EndTransaction()
        Call DB_Commit()
        '2019/04/01 CHG E N D

        I = 0
        WL_DATNO = Trim(SSS_LASTKEY.Value)
        If WG_DSPKB = 1 Then '����`�[
            '2019/04/01 CHG START
            'Call DB_GetEq(DBN_UDNTHA, 1, SSS_LASTKEY.Value, BtrNormal)
            'Call UDNTHA_GetFirstRecByDATNO(SSS_LASTKEY.Value)
            sqlWhereStr = ""
            sqlWhereStr = "WHERE DATNO = '" & SSS_LASTKEY.Value & "'"
            Call GetRowsCommon(DBN_UDNTHA, sqlWhereStr)
            '2019/04/01 CHG E N D
            If DBSTAT = 0 Then
                If DB_UDNTHA.UDNDT <= DB_SYSTBA.MONUPDDT Then
                    SSS_UPDATEFL = False
                End If
                Call SCR_FromUDNTHA(-1)
                Call DB_GetGrEq(DBN_UDNTRA, 1, SSS_LASTKEY.Value, BtrNormal)
                If (DBSTAT = 0) And (WL_DATNO = DB_UDNTRA.DATNO) Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_UDNTRA.LINNO) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    Do While (DBSTAT = 0) And (WL_DATNO = DB_UDNTRA.DATNO) And (SSSVal(DB_UDNTRA.LINNO) < 990)
                        Call SCR_FromMfil(I)
                        Call DB_GetNext(DBN_UDNTRA, BtrNormal)
                        I = I + 1
                    Loop
                End If
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_JDNNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(RD_SSSMAIN_JDNNO(-1))) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If LenWid(Trim(RD_SSSMAIN_JDNNO(-1))) <> 0 Then
                    Call AE_InOutModeN_SSSMAIN("TOKCD", "0000")
                    Call AE_InOutModeN_SSSMAIN("TOKRN", "0000")
                End If
            End If
        ElseIf WG_DSPKB = 2 Then  '�󒍓`�[

            '2019/04/01 CHG START
            'Call DB_GetEq(DBN_JDNTHA, 1, SSS_LASTKEY.Value, BtrNormal)
            'Call JDNTHA_GetFirstRecByDATNO(SSS_LASTKEY.Value)
            sqlWhereStr = " WHERE DATNO = '" & SSS_LASTKEY.Value & "'"
            Call GetRowsCommon("JDNTHA", sqlWhereStr)
            If DB_JDNTHA.JDNINKB Is Nothing Then
                DBSTAT = 1
            Else
                DBSTAT = 0
            End If
            '2019/06/26 CHG E N D 
            '2019/04/01 CHG E N D
            If DBSTAT = 0 Then
                Call SCR_FromJDNTHA(-1)
                WG_JDNINKB = DB_JDNTHA.JDNINKB

                '20190709 DEL START
                'Call MEIMTA_RClear()
                '20190709 DEL END

                wkJDNTRKB = DB_JDNTHA.JDNTRKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_JDNTHA.JDNTRKB))
                '2019/04/01 CHG START
                'Call DB_GetEq(DBN_MEIMTA, 2, "006" & wkJDNTRKB, BtrNormal)
                'Call MEIMTA_GetFirstRecByKEYCDAndMEICDA("006", wkJDNTRKB)

                sqlWhereStr = "WHERE KEYCD = '006' AND MEICDA = '" & wkJDNTRKB & "'"
                Call GetRowsCommon("MEIMTA", sqlWhereStr)
                '2019/04/01 CHG E N D
                WG_SYSTEM = DB_MEIMTA.MEIKBA

                ' ���Ӑ�}�X�^���[�i��Z���P�E�Q�E�R��]��
                '''            Call DB_GetEq(DBN_TOKMTA, 1, DB_JDNTHA.NHSCD, BtrNormal)
                '''            If DBSTAT = 0 Then
                '''                Call SCR_FromTOKMTA(-1)
                '''            End If
                '2019/04/01 CHG START
                'Call DB_GetEq(DBN_NHSMTA, 1, DB_JDNTHA.NHSCD, BtrNormal)
                'If DBSTAT = 0 Then
                '    Call SCR_FromNHSMTA(-1)
                'End If
                Call DSPNHSCD_SEARCH(DB_JDNTHA.NHSCD, DB_NHSMTA)
                Call SCR_FromNHSMTA(-1)
                '2019/04/01 CHG E N D

                '2019/04/01 CHG START
                'Call DB_GetGrEq(DBN_JDNTRA, 1, SSS_LASTKEY.Value, BtrNormal)
                sqlStr = ""
                sqlStr &= " SELECT * "
                sqlStr &= " FROM JDNTRA "
                sqlStr &= " WHERE DATNO = '" & CF_Ora_Sgl(SSS_LASTKEY.Value) & "' "

                Dim dtJDNTRA As DataTable = DB_GetTable(sqlStr)
                '2019/04/01 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_JDNTRA.LINNO) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/01 CHG START
                'Do While (DBSTAT = 0) And (DB_JDNTRA.DATKB = "1") And (WL_DATNO = DB_JDNTRA.DATNO) And (SSSVal(DB_JDNTRA.LINNO) < 990)
                '    WL_URISU = 0
                '    WL_URISU = DB_JDNTRA.UODSU - DB_JDNTRA.URISU

                '    ' �X�V�p�^�[���̃`�F�b�N�E�G���[�`�F�b�N���s��
                '    rResult = checkUpdatePattern(DB_JDNTHA.FRNKB, DB_JDNTHA.JDNTRKB, DB_JDNTHA.URIKJN, (FR_SSSMAIN.CHECK_EMGODNKB.CheckState), DB_JDNTRA.ZAIKB)
                '    If rResult = -1 Or rResult > 900 Then
                '        '�G���[�`�[�Ăяo���A�܂��͑��݂��Ȃ����ׂ���
                '        'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '�w�肵���`�[�͌Ăяo���ł��܂���B
                '        MsgBox("�w�肵���`�[�͌Ăяo���ł��܂���B", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
                '        I = 0
                '        Exit Do
                '    End If

                '    '                If (WL_URISU > 0) And (DB_JDNTRA.MNZHIKSU <> 0) And (DB_JDNTRA.FRDSU = 0) Then
                '    If (WL_URISU > 0) Then

                '        ' �����_�ȉ���P���ۂߏ���
                '        WL_URISU = DCMFRC(WL_URISU, 1, 0)

                '        Call SCR_FromJDNTRA(I)
                '        '2007/12/05 FKS)minamoto ADD START
                '        '�󒍃g�����F�r���X�V�����擾

                '        Call Haita_fromJDN(I)
                '        '2007/12/05 FKS)minamoto ADD END
                '        Call MEIMTA_RClear()
                '        wkTNKKB = DB_JDNTRA.TNKKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_JDNTRA.TNKKB))
                '        Call DB_GetEq(DBN_MEIMTA, 2, "008" & wkTNKKB, BtrNormal)
                '        Call DP_SSSMAIN_TNKNM(I, DB_MEIMTA.MEINMA)

                '        Call HINMTA_RClear()
                '        Call DB_GetEq(DBN_HINMTA, 1, DB_JDNTRA.HINCD, BtrNormal)
                '        Call DP_SSSMAIN_HINID(I, DB_HINMTA.HINID)

                '        Call DP_SSSMAIN_URITK(I, DCMFRC(DB_JDNTRA.UODTK, 1, 0))
                '        Call DP_SSSMAIN_SIKTK(I, DCMFRC(DB_JDNTRA.SIKTK, 1, 0))
                '        Call DP_SSSMAIN_TEIKATK(I, DCMFRC(DB_JDNTRA.TEIKATK, 1, 0))

                '        Call DP_SSSMAIN_URISU(I, WL_URISU)
                '        '�y�ʔ́z�y�сy�V�X�e���ŏ������i�z���A���[����
                '        If Trim(WG_JDNINKB) = "2" Or (Trim(WG_SYSTEM) = "M" And DB_HINMTA.HINID = "06") Then
                '            Call AE_InOutModeN_SSSMAIN("URISU", "0000")
                '        End If
                '        I = I + 1
                '    End If
                '    Call DB_GetNext(DBN_JDNTRA, BtrNormal)
                'Loop
                For Each row As DataRow In dtJDNTRA.Rows
                    If Not ((row("DATKB") = "1") And (WL_DATNO = row("DATNO")) And (SSSVal(row("LINNO")) < 990)) Then
                        Exit For
                    End If

                    WL_URISU = 0
                    WL_URISU = DB_NullReplace(row("UODSU"), 0) - DB_NullReplace(row("URISU"), 0)

                    ' �X�V�p�^�[���̃`�F�b�N�E�G���[�`�F�b�N���s��
                    rResult = checkUpdatePattern(DB_JDNTHA.FRNKB, DB_JDNTHA.JDNTRKB, DB_JDNTHA.URIKJN, (FR_SSSMAIN.CHECK_EMGODNKB.CheckState), row("ZAIKB"))
                    If rResult = -1 Or rResult > 900 Then
                        '�G���[�`�[�Ăяo���A�܂��͑��݂��Ȃ����ׂ���
                        'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '�w�肵���`�[�͌Ăяo���ł��܂���B
                        MsgBox("�w�肵���`�[�͌Ăяo���ł��܂���B", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
                        I = 0
                        Exit For
                    End If

                    If (WL_URISU > 0) Then

                        ' �����_�ȉ���P���ۂߏ���
                        WL_URISU = DCMFRC(WL_URISU, 1, 0)

                        '2019/04/02 CHG START
                        Call SCR_FromJDNTRA(I, row)
                        '2019/04/02 CHG E N D

                        '�󒍃g�����F�r���X�V�����擾

                        Call Haita_fromJDN(I, row)

                        '20190709 DEL START
                        'Call MEIMTA_RClear()
                        '20190709 DEL END

                        '2019/04/01 CHG START
                        'wkTNKKB = row("TNKKB") & Space(Len(DB_MEIMTA.MEICDA) - Len(row("TNKKB")))
                        wkTNKKB = row("TNKKB") & Space(Len(DB_NullReplace(DB_MEIMTA.MEICDA, " ")) - Len(row("TNKKB")))
                        '2019/04/01 CHG E N D
                        '2019/04/01 CHG START
                        'Call DB_GetEq(DBN_MEIMTA, 2, "008" & wkTNKKB, BtrNormal)
                        'Call MEIMTA_GetFirstRecByKEYCDAndMEICDA("008", wkTNKKB)

                        sqlWhereStr = "WHERE KEYCD = '008' AND MEICDA = '" & wkTNKKB & "'"
                        Call GetRowsCommon("MEIMTA", sqlWhereStr)

                        '2019/04/01 CHG E N D
                        Call DP_SSSMAIN_TNKNM(I, DB_MEIMTA.MEINMA)

                        '20190709 DEL START
                        'Call HINMTA_RClear()
                        '20190709 DEL END

                        '2019/04/01 CHG START
                        'Call DB_GetEq(DBN_HINMTA, 1, row("HINCD"), BtrNormal)
                        '2019/06/26 CHG START
                        'Call HINMTA_GetFirstRecByHINCD(row("HINCD"))

                        sqlWhereStr = "WHERE HINCD = '" & row("HINCD") & "'"
                        Call GetRowsCommon("HINMTA", sqlWhereStr)
                        If DB_HINMTA.HINCD Is Nothing Then
                            DBSTAT = 1
                        Else
                            DBSTAT = 0
                        End If
                        '2019/06/26 CHG E N D
                        '2019/04/01 CHG E N D
                        Call DP_SSSMAIN_HINID(I, DB_HINMTA.HINID)

                        Call DP_SSSMAIN_URITK(I, DCMFRC(row("UODTK"), 1, 0))
                        Call DP_SSSMAIN_SIKTK(I, DCMFRC(row("SIKTK"), 1, 0))
                        Call DP_SSSMAIN_TEIKATK(I, DCMFRC(row("TEIKATK"), 1, 0))

                        Call DP_SSSMAIN_URISU(I, WL_URISU)
                        '�y�ʔ́z�y�сy�V�X�e���ŏ������i�z���A���[����
                        If Trim(WG_JDNINKB) = "2" Or (Trim(WG_SYSTEM) = "M" And DB_HINMTA.HINID = "06") Then
                            Call AE_InOutModeN_SSSMAIN("URISU", "0000")
                        End If
                        I = I + 1
                    End If
                Next
                '2019/04/01 CHG E N D
                ' �����No.���ڕK�{�A�C�Ӑ؂�ւ�
                Call must_Put_EMGODNKB()
            End If
        End If
        'UPGRADE_WARNING: �I�u�W�F�N�g DSPTRN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DSPTRN = I
	End Function
	
	Sub INITDSP()
		Dim Px As Short
		Dim I As Short

        '2019/03/27 CHG START
        'Call DB_GetEq(DBN_SYSTBA, 1, "001", BtrNormal)
        If SYSTBA_SEARCH(DB_SYSTBA) <> 0 Then
            Exit Sub
        End If
        '2019/03/27 CHG E N D

		' ���͒S���ҁE�c�ƕ���͖��l���B��
		AE_BackColor(1) = &H8000000F
		AE_BackColor(2) = &HFFFFFF
		
		' �w�b�_
		CL_SSSMAIN(2) = 11
		CL_SSSMAIN(3) = 11
		CL_SSSMAIN(5) = 11
		CL_SSSMAIN(6) = 11
		CL_SSSMAIN(7) = 11
		CL_SSSMAIN(8) = 11
		CL_SSSMAIN(9) = 11
		CL_SSSMAIN(10) = 11
		CL_SSSMAIN(11) = 11
		CL_SSSMAIN(12) = 11
		CL_SSSMAIN(13) = 11
		CL_SSSMAIN(14) = 11
		CL_SSSMAIN(16) = 11
		CL_SSSMAIN(17) = 11
		CL_SSSMAIN(18) = 11
		'
		' �{�f�B
		For Px = PP_SSSMAIN.BodyPx To PP_SSSMAIN.EBodyPx - 1
			CL_SSSMAIN(Px) = 11
		Next Px
		
		For I = 0 To 98
			CL_SSSMAIN(PP_SSSMAIN.BodyPx + (I * PP_SSSMAIN.BodyV) + 6) = 12
			CL_SSSMAIN(PP_SSSMAIN.BodyPx + (I * PP_SSSMAIN.BodyV) + 13) = 12
			CL_SSSMAIN(PP_SSSMAIN.BodyPx + (I * PP_SSSMAIN.BodyV) + 14) = 12
		Next I
		
		' �e�C��
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 2) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 3) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 4) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 5) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 6) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 7) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 8) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 9) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 11) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 13) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 14) = 11
		
	End Sub
	
	Function INQ_CheckC() As Short
		Dim Rtn As Short
		Dim I As Short
		'''' ADD 2008/11/21  FKS) S.Nakajima    Start
		Dim intDe As Short
		Dim strJdnLinno As String
		Dim strSQL As String
		'''' ADD 2008/11/21  FKS) S.Nakajima    End
		
		INQ_CheckC = SSS_BILFL
		
		' �V�X�e����̐Ŕ������z�ƁA����͐Ŕ������z����v����ꍇ�A�ŋ��E�ō����z��\���B
		' ����ȊO�̓G���[���b�Z�[�W��\��
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SBAUZEKN(0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SBAURIKN(0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If (RD_SSSMAIN_SBAURIKN(0) + RD_SSSMAIN_SBAUZEKN(0)) <> RD_SSSMAIN_SBADENKN(0) Then
			'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '���׍��v�l�Ɠ��͒l���قȂ�܂��B
			MsgBox("���׍��v�l�Ɠ��͒l���قȂ�܂��B", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
			INQ_CheckC = 4
			Exit Function
		End If
		'2007/11/01 FKS)minamoto ADD START
		'2007/11/26 FKS)minamoto CHG START
		'If RD_SSSMAIN_UDNDT(0) < CNV_DATE(DB_JDNTHA.JDNDT) Then
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UDNDT(0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If RD_SSSMAIN_UDNDT(0) < CNV_DATE(DB_JDNTHA.REGDT) Then
			'2007/11/26 FKS)minamoto CHG END
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 6) '�󒍓����O�̓��ׁ̈A���͂ł��܂���B
			INQ_CheckC = 4
			Exit Function
		End If
		'2007/11/01 FKS)minamoto ADD END
		'2007/12/05 FKS)minamoto ADD START
		'�r���X�V�����`�F�b�N
		
		'''' ADD 2008/11/21  FKS) S.Nakajima    Start
		
		For intDe = 0 To PP_SSSMAIN.MaxDe Step 1
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_JDNLINNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strJdnLinno = Trim(CStr(RD_SSSMAIN_JDNLINNO(intDe)))
			If strJdnLinno = "" Then Exit For
			strSQL = ""
			strSQL = strSQL & "SELECT * FROM JDNTRA "
			strSQL = strSQL & " WHERE DATNO = '" & WG_JDNDATNO & "'"
            strSQL = strSQL & "   AND LINNO = " & "'" & strJdnLinno & "'"
            '2019/04/02 CHG START
            'Call DB_GetSQL2(DBN_JDNTRA, strSQL)
            Dim dtJDNTRA As DataTable = DB_GetTable(strSQL)
            '2019/04/02 CHG E N D
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISU() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/02 CHG START
            'If DB_JDNTRA.OTPSU - DB_JDNTRA.URISU < CDec(RD_SSSMAIN_URISU(intDe)) And DB_JDNTRA.ZAIKB = "1" Then
            If dtJDNTRA.Rows(0)("OTPSU") - dtJDNTRA.Rows(0)("URISU") < CDec(RD_SSSMAIN_URISU(intDe)) And dtJDNTRA.Rows(0)("ZAIKB") = "1" Then
                '2019/04/02 CHG E N D
                '''' UPD 2009/02/23  FKS) S.Nakajima    Start
                '            MsgBox CStr(intDe + 1) & " �s�ڂ��o�א��s��v�̂��߁A����o�^�o���܂���B", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm)
                MsgBox(CStr(intDe + 1) & " �s�ڂ����o�ׂ���̂��߁A����o�^�o���܂���B", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
                '''' UPD 2009/02/23  FKS) S.Nakajima    End
                INQ_CheckC = -1
                Exit Function
            End If
        Next intDe
		
		'''' ADD 2008/11/21  FKS) S.Nakajima    End
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CHK_HAITA_UPD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Rtn = CHK_HAITA_UPD
		If Rtn = 0 Then
			'�G���[
			'2008/2/27 FKS)ichihara ADD START
			'�^�C���X�^���v�`�F�b�N�ŃG���[�̏ꍇ���b�N����
			Call DB_Execute(DBN_JDNTRA, "ROLLBACK")
			'2008/2/27 FKS)ichihara ADD END
			Rtn = DSP_MsgBox(SSS_ERROR, "URIET51_001", 0) '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
			INQ_CheckC = 4
			Exit Function
		End If
		'2007/12/05 FKS)minamoto ADD END
		'ADD START FKS)INABA 2009/07/03 **************************
		'�A���[��739
		Dim lw_ret As Short
		'UPGRADE_WARNING: �I�u�W�F�N�g CHK_UNYDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lw_ret = CHK_UNYDT(DB_UNYMTA.UNYDT)
		If lw_ret <> 0 Then
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE_2", 0) '�^�p�����ύX����܂����B���j���[�ɖ߂��Ă��������B�B
			INQ_CheckC = 4
			Exit Function
		End If
		'ADD  END  FKS)INABA 2009/07/03 **************************
		
		
	End Function
	
	Function INQ_UPDATE() As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g INQ_UPDATE �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		INQ_UPDATE = 5
		'
		WG_BILFL = INQ_CheckC()
		'    Select Case SSS_BILFL
		Select Case WG_BILFL
			
			Case 1 ' �`�[���s�L��
				' �`�[���s�̏ꍇ�̓��b�Z�[�W�m�F�����Ȃ��̂ł����ŃE�B���h�E��\������
				DLGLST3.ShowDialog()
				Select Case SSSVal(SSS_RTNWIN)
					Case 0 ' �v��{���s
                        Rtn = DELTRN()
                        '20190731 CHG START
                        'Rtn = WRTTRN()
                        Rtn = WRTTRN2()
                        '20190731 CHG END

                        '1999/12/01 �X�V�G���[�̏ꍇ�ɂ͓`�[���s���Ȃ�
                        '            If Rtn = True Then Call PRNBIL
                        'Call PRNBIL
                    Case 1 ' �v��̂�
						Rtn = DELTRN()
                        '20190731 CHG START
                        'Rtn = WRTTRN()
                        Rtn = WRTTRN2()
                        '20190731 CHG END

                    Case 2 ' ���s�̂�
						'            Call PRNBIL
					Case Else ' �߂�
						'UPGRADE_WARNING: �I�u�W�F�N�g INQ_UPDATE �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						INQ_UPDATE = 0
				End Select
			Case 9 ' �v��̂�
				Rtn = DELTRN()
                '20190731 CHG START
                'Rtn = WRTTRN()
                Rtn = WRTTRN2()
                '20190731 CHG END

            Case Else
				'UPGRADE_WARNING: �I�u�W�F�N�g INQ_UPDATE �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				INQ_UPDATE = 0
		End Select
	End Function
	
	' �v�����^�؂�ւ��@�\��L���ɂ���ꍇ�͈ȉ��̃R�����g�A�E�g������L���ɂ���B
	' ���ɂr�e�c�܂��͂o�c�a�ŉ�ʂ́hCM_LCONFIG�h�C���[�W���\������\���֕ύX����B
	Function LCONFIG_GetEvent() As Short
		'   ' �v�����^�[�ݒ�
		'    LCONFIG_GetEvent = True
		'    DB_SYSTBI.PRGID = SSS_PrgId
		'    DB_SYSTBI.LSTID = RD_SSSMAIN_LSTID(0)
		'    Call DB_GetEq(DBN_SYSTBI, 1, DB_SYSTBI.PRGID & DB_SYSTBI.LSTID, BtrNormal)
		'    If DBSTAT = 0 Then
		'        SSS_RPTID = Trim$(DB_SYSTBI.RPTID)
		'    Else
		'        SSS_RPTID = ""
		'    End If
		'    WLS_PRN.Show 1
	End Function
	
	' �ً}�o�׃`�F�b�N�{�b�N�X�ύX������
	Sub change_Check_Emgodnkb()
		Dim wk_Cursor As Short
		
		' ��ʏ�����
		Call MN_AppendC_Click()
		Call must_Put_EMGODNKB()
		
	End Sub
	
	' ��ʏ�����
	Private Sub MN_AppendC_Click() 'Generated.
		Dim wk_Cursor As Short
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Cursor = AE_AppendC_SSSMAIN(PP_SSSMAIN.Mode)
		If wk_Cursor = Cn_CuInit Then Call AE_CursorInit_SSSMAIN()
	End Sub
	
	' �����No.���ڕK�{�A�C�Ӑ؂�ւ�
	Private Sub must_Put_EMGODNKB()
		' �`�F�b�N�Ȃ�
		If FR_SSSMAIN.CHECK_EMGODNKB.CheckState = 0 Then
			Call AE_InOutModeN_SSSMAIN("OKRJONO", "0000")
			
			' �`�F�b�N����
		ElseIf FR_SSSMAIN.CHECK_EMGODNKB.CheckState = 1 Then 
			Call AE_InOutModeN_SSSMAIN("OKRJONO", "3303")
		End If
		
	End Sub
	
	' �����������`�F�b�N
	Function check_HIKSU(ByRef pDATNO As String) As Short
		'pDATNO�̑S�`�[���ׂ̎蓮���������[�����ǂ������`�F�b�N����
		'����    �FputDATNO as String �iDATNO�j
		'�߂�l�@�F1�E�X�V�\
		'�@�@�@�@�@0�E�X�V�s��
		'          -1�E�G���[
		
		Dim HIKSU_flg As Short ' 0:�蓮�������[���@1:�蓮����������
		Dim WL_DATNO As String
		WL_DATNO = Trim(pDATNO)
		
		HIKSU_flg = 0
		
		Call DB_GetEq(DBN_JDNTHA, 1, pDATNO, BtrNormal)
		If DBSTAT = 0 Then
			Call SCR_FromJDNTHA(-1)
			Call DB_GetGrEq(DBN_JDNTRA, 1, pDATNO, BtrNormal)
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_JDNTRA.LINNO) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Do While (DBSTAT = 0) And (DB_JDNTRA.DATKB = "1") And (WL_DATNO = DB_JDNTRA.DATNO) And (SSSVal(DB_JDNTRA.LINNO) < 990)
				If DB_JDNTRA.MNZHIKSU <> 0 Then
					HIKSU_flg = 1
					Exit Do
				End If
				Call DB_GetNext(DBN_JDNTRA, BtrNormal)
			Loop 
			
			If HIKSU_flg = 1 Then
				check_HIKSU = 1
				
			Else
				check_HIKSU = 0
			End If
		Else
			check_HIKSU = -1
		End If
	End Function
	
	' �o�׎w������������`�F�b�N
	Function check_FRDSU(ByRef pDATNO As String) As Short
		'pDATNO�̑S�`�[���ׂ̏o�׎w�������O���ǂ������`�F�b�N����
		'����    �FputDATNO as String �iDATNO�j
		'�߂�l�@�F1�E�X�V�\
		'�@�@�@�@�@0�E�X�V�s��
		'          -1�E�G���[

        '2019/04/01 ADD START
        Dim strSQL As String
        '2019/04/01 ADD E N D

		Dim FRDSU_flg As Short ' 0:�o�׎w�������O�@1:�o�׎w�������O
		Dim WL_DATNO As String
		WL_DATNO = Trim(pDATNO)
		
		FRDSU_flg = 0

        '2019/03/29 CHG START
        'Call DB_GetEq(DBN_JDNTHA, 1, pDATNO, BtrNormal)
        'Call JDNTHA_GetFirstRecByDATNO(pDATNO)
        Dim sqlWhereStr As String = ""
        sqlWhereStr = " WHERE DATNO = '" & pDATNO & "'"
        Call GetRowsCommon("JDNTHA", sqlWhereStr)
        '2019/03/29 CHG E N D
        If DBSTAT = 0 Then
            Call SCR_FromJDNTHA(-1)
            '2019/04/01 CHG START
            'Call DB_GetGrEq(DBN_JDNTRA, 1, pDATNO, BtrNormal)
            strSQL = ""
            strSQL &= " SELECT * "
            strSQL &= " FROM JDNTRA "
            strSQL &= " WHERE DATNO = '" & CF_Ora_Sgl(DB_JDNTHA.DATNO) & "' "

            Dim dtJDNTRA As DataTable = DB_GetTable(strSQL)
            '2019/04/01 CHG E N D

			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_JDNTRA.LINNO) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/01 CHG START
            'Do While (DBSTAT = 0) And (DB_JDNTRA.DATKB = "1") And (WL_DATNO = DB_JDNTRA.DATNO) And (SSSVal(DB_JDNTRA.LINNO) < 990)
            '    If DB_JDNTRA.FRDSU = 0 Then
            '        FRDSU_flg = 1
            '        Exit Do
            '    End If
            '    Call DB_GetNext(DBN_JDNTRA, BtrNormal)
            'Loop
            For Each row As DataRow In dtJDNTRA.Rows
                If Not ((row("DATKB") = "1") And (WL_DATNO = row("DATNO")) And (SSSVal(row("LINNO")) < 990)) Then
                    Exit For
                End If
                If row("FRDSU") = 0 Then
                    FRDSU_flg = 1
                    Exit For
                End If
            Next
            '2019/04/01 CHG E N D
			
			If FRDSU_flg = 1 Then
				check_FRDSU = 1
				
			Else
				check_FRDSU = 0
			End If
		Else
			check_FRDSU = -1
		End If
	End Function
    '2007/12/05 FKS)minamoto ADD START
    '2019/04/01 CHG START
    'Private Sub Haita_fromJDN(ByRef pIndex As Short)
    Private Sub Haita_fromJDN(ByRef pIndex As Short, ByVal pRowJDNTRA As DataRow)
        '2019/04/01 CHG E N D

        ReDim Preserve HAITA_JDNTRA(pIndex)

        '2019/04/01 CHG STAR
        'HAITA_JDNTRA(pIndex).DATNO = DB_JDNTRA.DATNO
        'HAITA_JDNTRA(pIndex).LINNO = DB_JDNTRA.LINNO
        'HAITA_JDNTRA(pIndex).WRTDT = DB_JDNTRA.WRTDT
        'HAITA_JDNTRA(pIndex).WRTTM = DB_JDNTRA.WRTTM
        'HAITA_JDNTRA(pIndex).UWRTDT = DB_JDNTRA.UWRTDT
        'HAITA_JDNTRA(pIndex).UWRTTM = DB_JDNTRA.UWRTTM
        HAITA_JDNTRA(pIndex).DATNO = pRowJDNTRA("DATNO")
        HAITA_JDNTRA(pIndex).LINNO = pRowJDNTRA("LINNO")
        HAITA_JDNTRA(pIndex).WRTDT = pRowJDNTRA("WRTDT")
        HAITA_JDNTRA(pIndex).WRTTM = pRowJDNTRA("WRTTM")
        HAITA_JDNTRA(pIndex).UWRTDT = pRowJDNTRA("UWRTDT")
        HAITA_JDNTRA(pIndex).UWRTTM = pRowJDNTRA("UWRTTM")
        '2019/04/01 CHG E N D
    End Sub
	Function CHK_HAITA_UPD() As Object
		Dim I As Short
		Dim strSQL As String
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CHK_HAITA_UPD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CHK_HAITA_UPD = 1
		'�󒍓`�[
		
		I = 0
		Do While I < PP_SSSMAIN.LastDe
			'�󒍃g����
			
			strSQL = ""
			'2008/2/27 FKS)ichihara ADD START
			'        strSQL = "SELECT MAX(WRTDT),MAX(WRTTM),MAX(UWRTDT),MAX(UWRTTM) FROM JDNTRA"
			strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM JDNTRA"
			'2008/2/27 FKS)ichihara ADD END
			strSQL = strSQL & " WHERE DATNO = '" & HAITA_JDNTRA(I).DATNO & "'"
			strSQL = strSQL & "  AND LINNO = '" & HAITA_JDNTRA(I).LINNO & "'"
			'2008/2/27 FKS)ichihara ADD START
			'���b�N����
			strSQL = strSQL & "          FOR UPDATE"
            '2008/2/27 FKS)ichihara ADD END
            '2019/04/02 CHG START
            'Call DB_GetSQL2(DBN_JDNTRA, strSQL)
            Dim dtJDNTRA As DataTable = DB_GetTable(strSQL)
            '2019/04/02 CHG E N D
			'2008/2/27 FKS)ichihara ADD START
			'        If Val(HAITA_JDNTRA(I).WRTDT) <> Val(CStr(DB_ExtNum.ExtNum(0))) Or Val(HAITA_JDNTRA(I).WRTTM) <> Val(CStr(DB_ExtNum.ExtNum(1))) Or _
			''            Val(HAITA_JDNTRA(I).UWRTDT) <> Val(CStr(DB_ExtNum.ExtNum(2))) Or Val(HAITA_JDNTRA(I).UWRTTM) <> Val(CStr(DB_ExtNum.ExtNum(3))) Then
            '2019/04/02 CHG START
            'If Val(HAITA_JDNTRA(I).WRTDT) <> Val(CStr(DB_JDNTRA.WRTDT)) Or Val(HAITA_JDNTRA(I).WRTTM) <> Val(CStr(DB_JDNTRA.WRTTM)) Or Val(HAITA_JDNTRA(I).UWRTDT) <> Val(CStr(DB_JDNTRA.UWRTDT)) Or Val(HAITA_JDNTRA(I).UWRTTM) <> Val(CStr(DB_JDNTRA.UWRTTM)) Then
            If Val(HAITA_JDNTRA(I).WRTDT) <> Val(CStr(dtJDNTRA.Rows(0)("WRTDT"))) _
             Or Val(HAITA_JDNTRA(I).WRTTM) <> Val(CStr(dtJDNTRA.Rows(0)("WRTTM"))) _
             Or Val(HAITA_JDNTRA(I).UWRTDT) <> Val(CStr(dtJDNTRA.Rows(0)("UWRTDT"))) _
             Or Val(HAITA_JDNTRA(I).UWRTTM) <> Val(CStr(dtJDNTRA.Rows(0)("UWRTTM"))) Then
                '2019/04/02 CHG E N D
                '2008/2/27 FKS)ichihara ADD END
                '�G���[

                'UPGRADE_WARNING: �I�u�W�F�N�g CHK_HAITA_UPD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                CHK_HAITA_UPD = 0
                Exit Function
            End If

            I = I + 1
        Loop
		
	End Function
	'2007/12/05 FKS)minamoto ADD END
End Module