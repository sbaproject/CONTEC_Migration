Option Strict Off
Option Explicit On
Module JDNNO_F61
	'
	' �X���b�g��        : �󒍓`�[�ԍ��E��ʍ��ڃX���b�g
	' ���j�b�g��        : JDNNO.F61
	' �L�q��            : Muratani
	' �쐬���t          : 2006/07/25
	' �g�p�v���O������  : URIET51
	
	'�`�[No�����͂��ꂽ�ꍇ�ɁA���̃`�F�b�N���s���B
	Function JDNNO_CheckC(ByRef JDNNO As Object, ByRef PP As clsPP, ByRef CP_JDNNO As clsCP, ByVal FRNKB As Object, ByVal JDNTRKB As Object, ByVal URIKJN As Object) As Object
		Dim Rtn As Object
		Dim rResult As Short ' �����`�F�b�N�֐��߂�l
		Dim rCHECK_HIKSU As Object
		Dim rCHECK_FRDSU As Short
		Dim wkJDNTRKB As String
		Dim rCHECK_URISU As Short
		Dim wkJDNNO As String
		
		Dim strSQL As String
		
		'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		JDNNO_CheckC = 0
		
		' === 20130416 === INSERT S - FWEST)Koroyasu �r������̉���
		Call SSSWIN_Unlock_EXCTBZ()
		' === 20130416 === INSERT E -
		
		'    If SSSVal(JDNNO) = 0 Then
		'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(JDNNO) = "" Then
			
			'�ԍ�����(or 0)�ɕύX���ꂽ����, ����������ꍇ
			'�P�Ȃ�G���[�ł悯��΂��� If�u���b�N�͕s�v
			SSS_LASTKEY.Value = ""
			WG_DSPKB = 2
			'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Rtn = AE_ChOprtLater(PP, 15) '�\����ǉ����[�h�Ɉڍs
			Exit Function
		End If
		
		'Call DB_GetEq(DBN_JDNTHA, 2, "1" & "1" & JDNNO, BtrNormal)
		'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/03/29 CHG START
        'wkJDNNO = Left(JDNNO, 6) & Space(Len(DB_JDNTHA.JDNNO) - 6)
        If DB_JDNTHA.JDNNO Is Nothing OrElse Len(DB_JDNTHA.JDNNO) <= 6 Then
            wkJDNNO = Left(JDNNO, 6)
        Else
            wkJDNNO = Left(JDNNO, 6) & Space(Len(DB_JDNTHA.JDNNO) - 6)
        End If
        '2019/03/29 CHG E N D
		
		strSQL = ""
		strSQL = strSQL & "SELECT MAX(DATNO) FROM JDNTHA"
        strSQL = strSQL & " WHERE JDNNO = '" & wkJDNNO & "'"
        '2019/03/29 CHG START
        'Call DB_GetSQL2(DBN_JDNTHA, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/03/29 CHG E N D
        '2019/03/29 CHG START
        'WG_JDNDATNO = VB6.Format(DB_ExtNum.ExtNum(0), "0000000000")
        WG_JDNDATNO = VB6.Format(dt.Rows(0)("MAX(DATNO)"), "0000000000")
        '2019/03/29 CHG E N D
        '2019/03/29 CHG START
        'Call DB_GetEq(DBN_JDNTHA, 1, WG_JDNDATNO, BtrNormal)
        'Call JDNTHA_GetFirstRecByDATNO(WG_JDNDATNO)
        Dim sqlWhereStr As String = ""
        sqlWhereStr = " WHERE DATNO = '" & WG_JDNDATNO & "'"
        Call GetRowsCommon("JDNTHA", sqlWhereStr)
        '2019/03/29 CHG E N D

        '2006/10/12 [DEL-START] ZKTKB = "2"�i�����j�̃`�F�b�N�����ɂ���i�[�i���͏o�͂���ׁj
        ''''If DBSTAT = 0 And DB_JDNTHA.ZKTKB <> "2" Then
        'If DBSTAT = 0 Then 
        If (DBSTAT = 0) And (DB_JDNTHA.DATKB = "1") And (DB_JDNTHA.DENKB = "1") And (DB_JDNTHA.AKAKROKB = "1") Then 

            ' �󒍎���敪�i���̂R�őΏۃ`�F�b�N�j
            '2019/03/29 CHG START
            'wkJDNTRKB = DB_JDNTHA.JDNTRKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_JDNTHA.JDNTRKB))
            If DB_MEIMTA.MEICDA Is Nothing Then
                wkJDNTRKB = DB_JDNTHA.JDNTRKB
            Else
                wkJDNTRKB = DB_JDNTHA.JDNTRKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_JDNTHA.JDNTRKB))
            End If
            '2019/03/29 CHG E N D
            '20190709 DEL START
            'Call MEIMTA_RClear()
            '20190709 DEL END

            '2019/03/29 CHG START
            'Call DB_GetEq(DBN_MEIMTA, 2, "006" & wkJDNTRKB, BtrNormal)
            'Call MEIMTA_GetFirstRecByKEYCDAndMEICDA("006", wkJDNTRKB)
            sqlWhereStr = "WHERE KEYCD = '006' AND MEICDA = '" & wkJDNTRKB & "'"
            Call GetRowsCommon("MEIMTA", sqlWhereStr)

            '2019/03/29 CHG E N D
            '2017/04/03 CHG START CIS <�ۋ��V�X�e���Ή�>
            '        If Left(DB_MEIMTA.MEINMC, 2) <> "02" Then
            'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If Left(DB_MEIMTA.MEINMC, 2) <> "02" And Left(JDNNO, 2) <> "RU" Then
                '2017/04/03 CHG E N D CIS <�ۋ��V�X�e���Ή�>
                '            Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)   '�Y�����R�[�h����
                'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Rtn = DSP_MsgBox(SSS_CONFRM, "URIET51", 0) '�����ΏۊO�̎󒍎���敪�ׁ̈A�G���[�B
                'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                JDNNO_CheckC = -1
            Else
                '2019/03/29 CHG START
                'Call DB_GetGrEq(DBN_JDNTRA, 1, DB_JDNTHA.DATNO, BtrNormal)
                strSQL = ""
                strSQL &= " SELECT * "
                strSQL &= " FROM JDNTRA "
                strSQL &= " WHERE DATNO = '" & CF_Ora_Sgl(DB_JDNTHA.DATNO) & "' "
 
                Dim dtJDNTRA As DataTable = DB_GetTable(strSQL)
                '2019/03/29 CHG E N D

                '2019/03/29 CHG START
                'If (DBSTAT <> 0) Or (DB_JDNTRA.DATNO <> DB_JDNTHA.DATNO) Then
                If (dtJDNTRA Is Nothing OrElse dt.Rows.Count <= 0) Or (dtJDNTRA.Rows(0)("DATNO") <> DB_JDNTHA.DATNO) Then
                    '2019/03/29 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '�Y�����R�[�h����
                    'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    JDNNO_CheckC = -1
                Else
                    rCHECK_URISU = 0
                    '2019/03/29 CHG START
                    'Do While (DBSTAT = 0) And (DB_JDNTRA.DATNO = DB_JDNTHA.DATNO) And (rCHECK_URISU = 0)
                    '    If DB_JDNTRA.UODSU <> DB_JDNTRA.URISU Then
                    '        rCHECK_URISU = 1
                    '    End If
                    '    Call DB_GetNext(DBN_JDNTRA, BtrNormal)
                    'Loop
                    For Each row As DataRow In dtJDNTRA.Rows
                        If DB_NullReplace(row("UODSU"), 0) <> DB_NullReplace(row("URISU"), 0) Then
                            rCHECK_URISU = 1
                            Exit For
                        End If
                    Next
                    '2019/03/29 CHG E N D
                    If rCHECK_URISU = 0 Then
                        'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        Rtn = DSP_MsgBox(SSS_CONFRM, "URIET51", 1) '���ɔ���ςׁ݂̈A�G���[�B
                        'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        JDNNO_CheckC = -1
                        Exit Function
                    End If

                    ' === 20130416 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
                    '�r���`�F�b�N
                    ' === 20130530 === UPDATE S - FWEST)Koroyasu
                    '                rResult = SSSWIN_EXCTBZ_CHECK2
                    rResult = SSSWIN_EXCTBZ_CHECK2(JDNNO)
                    ' === 20130530 === UPDATE E
                    Select Case rResult
                        '����
                        Case 0

                            '�r��������
                        Case 1
                            'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            Rtn = DSP_MsgBox(SSS_ERROR, "_EXCADD", 0) '���̃v���O�����ōX�V���̂��߁A�o�^�ł��܂���B
                            'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            JDNNO_CheckC = -1
                            Exit Function

                            '�ُ�I��
                        Case 9
                            'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            Rtn = DSP_MsgBox(SSS_ERROR, "URKET51_004 ", 0) '�X�V�ُ�
                            'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            JDNNO_CheckC = -1
                            Exit Function

                    End Select
                    ' === 20130416 === INSERT E -

                    SSS_LASTKEY.Value = DB_JDNTHA.DATNO
                    WG_DSPKB = 2
                    'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    Rtn = AE_ChOprtLater(PP, 15) '�\����ǉ����[�h�Ɉڍs

                    '            ' �X�V�p�^�[���̃`�F�b�N�E�G���[�`�F�b�N���s��
                    '            rResult = checkUpdatePattern(DB_JDNTHA.FRNKB, DB_JDNTHA.JDNTRKB, DB_JDNTHA.URIKJN, FR_SSSMAIN.CHECK_EMGODNKB.Value, " ")
                    '            If rResult = -1 Or rResult > 900 Then
                    '                '�G���[�`�[�Ăяo���A�܂��͑��݂��Ȃ����ׂ���
                    '                'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '�w�肵���`�[�͌Ăяo���ł��܂���B
                    '                MsgBox "�w�肵���`�[�͌Ăяo���ł��܂���B", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm)
                    '                JDNNO_CheckC = -1
                    '            End If

                    ' �S�`�[���ׂ̎蓮���������[�����ǂ������`�F�b�N����
                    '            rCHECK_HIKSU = check_HIKSU(SSS_LASTKEY)
                    '            If rCHECK_HIKSU = 0 Then
                    '���ׂĂ̖��ׂ̎蓮���������[��
                    'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '�����������ł��B�蓮�����o�^�ɂ������������s���Ă��������B
                    '                MsgBox "�����������ł��B�蓮�����o�^�ɂ������������s���Ă��������B", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm)
                    '            End If

                    '
                    rCHECK_FRDSU = check_FRDSU(SSS_LASTKEY.Value)
                    If rCHECK_FRDSU = 0 Then
                        '���ׂĂ̖��ׂ̏o�׎w�������[���ł͂Ȃ�
                        'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '�o�׎w������������ł��B�o�׎w��������s���Ă��������B
                        MsgBox("�o�׎w������������ł��B�o�׎w��������s���Ă��������B", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
                    End If
                End If

            End If
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '�Y�����R�[�h����
            'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            JDNNO_CheckC = -1
        End If
        '2006/10/12 [DEL-E N D] ZKTJB = "2"�i�����j�̃`�F�b�N�����ɂ���i�[�i���͏o�͂���ׁj

        from_JDNNO_Unit = True


        '    Call DB_GetEq(DBN_JDNTHA, 2, "1" & "1" & JDNNO, BtrNormal)
        '    If DBSTAT = 0 And DB_JDNTHA.ZKTKB <> "2" Then
        '        If SSSVal(DB_JDNTHA.JDNENDKB) = 8 Then
        '            Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 2) '�����ς݁i�����j
        '            JDNNO_CheckC = -1
        '        ElseIf SSSVal(DB_JDNTHA.JDNENDKB) = 6 Then
        '            Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 5) '�����F
        '            JDNNO_CheckC = -1
        '        Else
        '            Call DB_GetGrEq(DBN_JDNTRA, 1, DB_JDNTHA.DATNO, BtrNormal)
        '            If (DBSTAT <> 0) Or (DB_JDNTRA.DATNO <> DB_JDNTHA.DATNO) Then
        '                Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)   '�Y�����R�[�h����
        '                JDNNO_CheckC = -1
        '            Else
        '                SSS_LASTKEY = DB_JDNTHA.DATNO
        '                WG_DSPKB = 2
        '                Rtn = AE_ChOprtLater(PP, 15)    '�\����ǉ����[�h�Ɉڍs
        '            End If
        '        End If
        '    Else
        '        Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)   '�Y�����R�[�h����
        '        JDNNO_CheckC = -1
        '    End If
    End Function
	
	Function JDNNO_Slist(ByRef PP As clsPP, ByVal JDNNO As Object) As Object

        '20190730 CHG START
        'DB_PARA(DBN_JDNTHA).KeyNo = 6
        'DB_PARA(DBN_JDNTHA).KeyBuf = "1" & "0"
        WLSJDN1.JDN1_PARA1 = "1" & "0"
        '20190730 CHG END

        '2019/03/25 CHG START
        'WLSJDN.ShowDialog()
        'WLSJDN.Close()
        WLSJDN1.ShowDialog()
        WLSJDN1.Close()
        '2019/03/25 CHG E N D
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		JDNNO_Slist = PP.SlistCom
	End Function
	
	
	'�X�V�p�^�[���̃`�F�b�N�E�G���[�`�F�b�N���s��
	Function checkUpdatePattern(ByRef putFRNKB As String, ByRef putJDNTRB As String, ByRef putURIKJN As String, ByRef putEMGODNKB As Short, ByRef putZAIKB As String) As Short
		'����    �FputFRNKB as String �i�C�O����敪�j
		'����    �FputJDNTRB as String �i�󒍎���敪�j
		'����    �FputURIKJN as String �i�����j
		'����    �FputEMGODNKB as String �i�ً}�o�׃`�F�b�N 1:�ً}�o�� 9:����ȊO�j
		'����    �FputZAIKB as String �i�݌ɊǗ��敪�j
		'�߂�l�@�F�X�V�i�֐���`���@�\ 1 1�@�����ꗗ���Q�� ���֐������ɓ]�L�j
		'        �F����ȊO�G���[�i�֐���`���@�\ 1 2�@ �G���[�ԍ��ꗗ���Q�Ɓ@���֐������ɓ]�L�j
		'
		
		Dim pFRNKB As String
		Dim pJDNTRKB As String
		Dim pURIKJN As String
		Dim pEMGODNKB As Short
		Dim pZAIKB As String
		
		pFRNKB = Trim(putFRNKB)
		pJDNTRKB = Trim(putJDNTRB)
		pURIKJN = Trim(putURIKJN)
		pEMGODNKB = putEMGODNKB
		pZAIKB = Trim(putZAIKB)
		
		checkUpdatePattern = 0
		
		
		If pFRNKB = "" Then
			checkUpdatePattern = 0
			Exit Function
		End If
		
		' �C�O
		If pFRNKB = "1" Then
			checkUpdatePattern = 901
			Exit Function
		End If
		
		' ����
		If pFRNKB = "0" Then
			If pJDNTRKB = "" Then Exit Function
			
			checkUpdatePattern = 0
			
			'        ' �P�i
			'        If pJDNTRKB = "01" Then
			'            If pURIKJN = "" Then Exit Function
			'
			'            ' �o�׊
			'            If pURIKJN = "1" Then
			'
			'                ' �ً}�o�׃`�F�b�N����
			'                If pEMGODNKB = 1 Then
			'                    If pZAIKB = "" Then Exit Function
			'
			'                    ' �݌ɊǗ��Ώ�
			'                    If pZAIKB = "1" Then
			'                        checkUpdatePattern = 2
			'                        Exit Function
			'
			'                    ' �݌ɊǗ��ΏۊO
			'                    ElseIf pZAIKB = "9" Then
			'                        checkUpdatePattern = -1
			'                        Exit Function
			'                    End If
			'
			'                ' �ً}�o�׃`�F�b�N�Ȃ�
			'                ElseIf pEMGODNKB = 0 Then
			'                    checkUpdatePattern = 902
			'                    Exit Function
			'                End If
			'
			'            ' �o�׊�ȊO
			'            Else
			'                checkUpdatePattern = -1
			'                Exit Function
			'            End If
			'
			'        ' �Z�b�g�A�b�v
			'        ElseIf pJDNTRKB = "21" Then
			'            If pURIKJN = "" Then Exit Function
			'
			'            ' �o�׊
			'            If pURIKJN = "1" Then
			'
			'                ' �ً}�o�׃`�F�b�N����
			'                If pEMGODNKB = 1 Then
			'                    If pZAIKB = "" Then Exit Function
			'
			'                    ' �݌ɊǗ��Ώ�
			'                    If pZAIKB = "1" Then
			'                        checkUpdatePattern = 2
			'                        Exit Function
			'
			'                    ' �݌ɊǗ��ΏۊO
			'                    ElseIf pZAIKB = "9" Then
			'                        checkUpdatePattern = 1
			'                        Exit Function
			'                    End If
			'
			'                ' �ً}�o�׃`�F�b�N�Ȃ�
			'                ElseIf pEMGODNKB = 0 Then
			'                    checkUpdatePattern = 903
			'                    Exit Function
			'                End If
			'
			'            ' �o�׊�ȊO
			'            Else
			'                checkUpdatePattern = -1
			'                Exit Function
			'            End If
			'
			'        ' �V�X�e��
			'        ElseIf pJDNTRKB = "31" Then
			'            If pURIKJN = "" Then Exit Function
			'
			'            ' �o�׊
			'            If pURIKJN = "1" Then
			'
			'                ' �ً}�o�׃`�F�b�N����
			'                If pEMGODNKB = 1 Then
			'                    If pZAIKB = "" Then Exit Function
			'
			'                    ' �݌ɊǗ��Ώ�
			'                    If pZAIKB = "1" Then
			'                        checkUpdatePattern = 2
			'                        Exit Function
			'
			'                    ' �݌ɊǗ��ΏۊO
			'                    ElseIf pZAIKB = "9" Then
			'                        checkUpdatePattern = 1
			'                        Exit Function
			'                    End If
			'
			'                ' �ً}�o�׃`�F�b�N�Ȃ�
			'                ElseIf pEMGODNKB = 0 Then
			'                    checkUpdatePattern = 904
			'                    Exit Function
			'                End If
			'
			'            ' �o�׊�ȊO
			'            Else
			'                ' �ً}�o�׃`�F�b�N����
			'                If pEMGODNKB = 1 Then
			'                    checkUpdatePattern = 905
			'                    Exit Function
			'
			'                ' �ً}�o�׃`�F�b�N�Ȃ�
			'                ElseIf pEMGODNKB = 0 Then
			'                    If pZAIKB = "" Then Exit Function
			'
			'                    ' �݌ɊǗ��Ώ�
			'                    If pZAIKB = "1" Then
			'                        checkUpdatePattern = -1
			'                        Exit Function
			'
			'                    ' �݌ɊǗ��ΏۊO
			'                    ElseIf pZAIKB = "9" Then
			'                        checkUpdatePattern = 1
			'                        Exit Function
			'                    End If
			'                End If
			'            End If
			'
			'        ' �C��
			'        ElseIf pJDNTRKB = "41" Then
			'            If pURIKJN = "" Then Exit Function
			'
			'            ' �o�׊
			'            If pURIKJN = "1" Then
			'                checkUpdatePattern = -1
			'                Exit Function
			'
			'            ' �o�׊�ȊO
			'            Else
			'                ' �ً}�o�׃`�F�b�N����
			'                If pEMGODNKB = 1 Then
			'                    checkUpdatePattern = 906
			'                    Exit Function
			'
			'                ' �ً}�o�׃`�F�b�N�Ȃ�
			'                ElseIf pEMGODNKB = 0 Then
			'                    If pZAIKB = "" Then Exit Function
			'
			'                    ' �݌ɊǗ��Ώ�
			'                    If pZAIKB = "1" Then
			'                        checkUpdatePattern = -1
			'                        Exit Function
			'
			'                    ' �݌ɊǗ��ΏۊO
			'                    ElseIf pZAIKB = "9" Then
			'                        checkUpdatePattern = 1
			'                        Exit Function
			'                    End If
			'                End If
			'            End If
			'
			'        ' �ێ�
			'        ElseIf pJDNTRKB = "51" Then
			'            checkUpdatePattern = 907
			'            Exit Function
			'
			'        ' �ݏo
			'        ElseIf pJDNTRKB = "61" Then
			'            If pURIKJN = "" Then Exit Function
			'
			'            ' �o�׊
			'            If pURIKJN = "1" Then
			'
			'                ' �ً}�o�׃`�F�b�N����
			'                If pEMGODNKB = 1 Then
			'                    checkUpdatePattern = 908
			'                    Exit Function
			'
			'                ' �ً}�o�׃`�F�b�N�Ȃ�
			'                ElseIf pEMGODNKB = 0 Then
			'                    If pZAIKB = "" Then Exit Function
			'
			'                    ' �݌ɊǗ��Ώ�
			'                    If pZAIKB = "1" Then
			'                        checkUpdatePattern = 3
			'                        Exit Function
			'
			'                    ' �݌ɊǗ��ΏۊO
			'                    ElseIf pZAIKB = "9" Then
			'                        checkUpdatePattern = -1
			'                        Exit Function
			'                    End If
			'                End If
			'
			'            ' �o�׊�ȊO
			'            Else
			'                ' �ً}�o�׃`�F�b�N����
			'                If pEMGODNKB = 1 Then
			'                    checkUpdatePattern = 909
			'
			'                ' �ً}�o�׃`�F�b�N�Ȃ�
			'                ElseIf pEMGODNKB = 0 Then
			'                    If pZAIKB = "" Then Exit Function
			'
			'                    ' �݌ɊǗ��Ώ�
			'                    If pZAIKB = "1" Then
			'                        checkUpdatePattern = 3
			'                        Exit Function
			'
			'                    ' �݌ɊǗ��ΏۊO
			'                    ElseIf pZAIKB = "9" Then
			'                        checkUpdatePattern = -1
			'                        Exit Function
			'                    End If
			'                End If
			'            End If
			'
			'        ' ���̑�
			'        ElseIf pJDNTRKB = "99" Then
			'            checkUpdatePattern = 910
			'            Exit Function
			'        End If
			
		End If
		
		'�\ 1 1�@�����ꗗ
		'�ԍ�   ���P    ���Q            ���R            ���S    ���T
		'2      ����    �P�i            �o�׊        ����    �Ώ�
		'2      ����    �Z�b�g�A�b�v    �o�׊        ����    �Ώ�
		'1      ����    �Z�b�g�A�b�v    �o�׊        ����    ��Ώ�
		'2      ����    �V�X�e��        �o�׊        ����    �Ώ�
		'1      ����    �V�X�e��        �o�׊        ����    ��Ώ�
		'1      ����    �V�X�e��        �o�׊�ȊO    �Ȃ�    ��Ώ�
		'1      ����    �C��            �o�׊�ȊO    �Ȃ�    ��Ώ�
		'3      ����    �ݏo            �o�׊        �Ȃ�    �Ώ�
		'3      ����    �ݏo            �o�׊�ȊO    �Ȃ�    �Ώ�
		'0      �G���[�ȊO�Ť��L�̏����ɊY�����Ȃ����������̏ꍇ (���m��)
		'
		'�\ 1 2�@ �G���[�ԍ��ꗗ
		'�ԍ�   ���P    ���Q            ���R            ���S    ���T
		'901    �C�O
		'-1     ����    �P�i            �o�׊�ȊO
		'902    ����    �P�i            �o�׊        �Ȃ�
		'-1     ����    �P�i            �o�׊        ����    ��Ώ�
		'-1     ����    �Z�b�g�A�b�v    �o�׊�ȊO
		'903    ����    �Z�b�g�A�b�v    �o�׊        �Ȃ�
		'904    ����    �V�X�e��        �o�׊        �Ȃ�
		'905    ����    �V�X�e��        �o�׊�ȊO    ����
		'-1     ����    �V�X�e��        �o�׊�ȊO    �Ȃ�    �Ώ�
		'-1     ����    �C��            �o�׊
		'906    ����    �C��            �o�׊�ȊO    ����
		'-1     ����    �C��            �o�׊�ȊO    �Ȃ�    �Ώ�
		'907    ����    �ێ�
		'908    ����    �ݏo            �o�׊        ����
		'-1     ����    �ݏo            �o�׊        �Ȃ�    ��Ώ�
		'909    ����    �ݏo            �o�׊�ȊO    ����
		'-1     ����    �ݏo            �o�׊�ȊO    �Ȃ�    ��Ώ�
		'910    ����    ���̑�
		'
		'��1:  �C�O����敪
		'��2:  �󒍎���敪
		'��3:  ����
		'��4:  �ً}�o�׃`�F�b�N
		'��5:  �݌ɊǗ��敪
		'
		'��1:  �ԍ�1�˔�����̂ݓo�^
		'      �ԍ�2�ˏo�׎w�����쐬
		'      �ԍ�3�ˑq�Ƀ}�X�^���X�V
		'���Q�F�G���[�ԍ� = -1�́A���݂��Ȃ��f�[�^�i��O�G���[�j
		'���R�F�G���[�ԍ� > 900�́A�Y���������I���������A�G���[���b�Z�[�W��\������
		
	End Function
End Module