Option Strict Off
Option Explicit On
Module DATNO_F52
	'
	' �X���b�g��        : ����`�[No�E��ʍ��ڃX���b�g
	' ���j�b�g��        : DATNO.F52
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/09/22
	' �g�p�v���O������  : URIET52
	'
	
	'�`�[No�����͂��ꂽ�ꍇ�ɁA���̃`�F�b�N���s���B
	Function DATNO_CheckC(ByRef DATNO As Object, ByRef PP As clsPP, ByRef CP_DATNO As clsCP) As Object
		Dim Rtn As Object
		Dim Rtn1 As Short
		Dim strSQL As String
		Dim WK_UDNNO As String
		Dim WK_DATNO As String
		Dim WK_CNT As Integer
		' === 20130523 === INSERT S - FWEST)Koroyasu
		Dim WK_JDNNO As String
		Dim rResult As Short ' �����`�F�b�N�֐��߂�l
		' === 20130523 === INSERT E -
		' === 20130523 === INSERT S - FWEST)Koroyasu �r������̉���
		Call SSSWIN_Unlock_EXCTBZ()
		' === 20130523 === INSERT E -
		
		SetFirst = True
		
		'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DATNO_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g DATNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(DATNO) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DATNO_CheckC = -1
			Exit Function
		End If
		
		If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
			MsgBox("�y" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "�z���N�����ł��B" & Trim(SSS_PrgNm) & "����͂��鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
			'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DATNO_CheckC = -1
			Exit Function
		Else
			Call SSSWIN_EXCTBZ_OPEN()
		End If
        '2019/06/11 CHG START
        'Call DB_GetEq(DBN_UDNTHA, 1, DATNO, BtrNormal)
        '20190726 CHG START
        'Call UDNTHA_GetFirstRecByDATNO(DATNO)
        Dim sqlWhereStr As String = ""
        sqlWhereStr = " WHERE DATNO = '" & DATNO & "'"
        Call GetRowsCommon("UDNTHA", sqlWhereStr)
        '20190726 CHG END
        '2019/06/11 CHG END
        If DBSTAT <> 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 0) '�Y���f�[�^�Ȃ�
			'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DATNO_CheckC = -1
			Exit Function
		Else
			WK_UDNNO = DB_UDNTHA.UDNNO
			WK_DATNO = DB_UDNTHA.DATNO
			' === 20130523 === INSERT S - FWEST)Koroyasu
			WK_JDNNO = DB_UDNTHA.JDNNO
            ' === 20130523 === INSERT E -
            '�ԕi�`�[����
            'UPGRADE_WARNING: �I�u�W�F�N�g DATNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Call DB_GetEq(DBN_UDNTRA, 1, DATNO & "001", BtrNormal)
            If DB_UDNTRA.DKBID = "02" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52_1", 0) '�ԕi�`�[�ׁ̈A�����ł��܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				DATNO_CheckC = -1
				Exit Function
			End If
			'�����ς݂�����
			'2007/11/29 UPD-START
			''''    strSQL = ""
			''''    strSQL = strSQL & "SELECT COUNT(*) FROM UDNTRA"
			''''    strSQL = strSQL & " WHERE DATNO = '" & DATNO & "'"
			''''    strSQL = strSQL & "   AND JKESIKN <> 0 "
			''''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			''''    WK_CNT = DB_ExtNum.ExtNum(0)
			''''    If WK_CNT <> 0 Then
			''''        Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 7)  '�����ςׁ݂̈A�����ł��܂���B
			''''        DATNO_CheckC = -1
			''''        Exit Function
			''''    End If
			strSQL = ""
			strSQL = strSQL & "SELECT COUNT(*) FROM UDNTRA"
			'UPGRADE_WARNING: �I�u�W�F�N�g DATNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & " WHERE DATNO = '" & DATNO & "'"
            strSQL = strSQL & "   AND JKESIKN = 0 "
            '2019/06/13 CHG START
            'Call DB_GetSQL2(DBN_UDNTRA, strSQL)
            'change start 20190730 kuwahara
            'Call DB_GetTable(strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)
            'change end 20190730 kuwahara
            '2019/06/13 CHG END
            'change start 20190730 kuwahara
            'WK_CNT = DB_ExtNum.ExtNum(0)
            WK_CNT = dt.Rows(0)("COUNT(*)")
            'change end 20190730 kuwahara
            If WK_CNT = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 7) '�����ςׁ݂̈A�����ł��܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				DATNO_CheckC = -1
				Exit Function
			End If
			'2007/11/29 UPD-END
			'�o�׍ς݂�����
			If DB_UDNTHA.EMGODNKB = "1" Then
				strSQL = ""
				strSQL = strSQL & "SELECT COUNT(*) FROM FDNTRA"
				strSQL = strSQL & " WHERE FDNNO = '" & DB_UDNTHA.FDNNO & "'"
                strSQL = strSQL & "   AND FDNZMIFL = '9' "

                'change start 20190730 kuwahara
                'Call DB_GetSQL2(DBN_FDNTRA, strSQL)
                'WK_CNT = DB_ExtNum.ExtNum(0)
                dt = DB_GetTable(strSQL)
                WK_CNT = dt.Rows(0)("COUNT(*)")
                'change end 20190730 kuwahara

                If WK_CNT <> 0 Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 8) '�o�׍ςׁ݂̈A�����ł��܂���B
                    'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    DATNO_CheckC = -1
                    Exit Function
                End If
            End If
			''''''''If DB_UDNTHA.SMADT < DB_SYSTBA.MONUPDDT Then
			''''''''    Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 1) '�O���x�ȑO�̓`�[�͒����ł��܂���B
			''''''''    DATNO_CheckC = -1
			''''''''    Exit Function
			''''''''End If
			'�������o�׊�́A�O�����̒����s��
			If DB_UDNTHA.URIKJN = "01" And DB_UDNTHA.SMADT <= DB_SYSTBA.UKSMEDT Then
				'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 9) '�o�׊�ׁ̈A�O���x�̓`�[�͒����ł��܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				DATNO_CheckC = -1
				Exit Function
			End If
			If DB_UDNTHA.AKAKROKB = "9" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 2) '�ԍ������ς̓`�[�͒����ł��܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				DATNO_CheckC = -1
				Exit Function
			End If
			strSQL = "SELECT * FROM UDNTHA WHERE UDNNO = '" & WK_UDNNO & "'"
            strSQL = strSQL & "          AND DATNO > '" & WK_DATNO & "'"
            strSQL = strSQL & "          AND DATNO <= '" & DB_SYSTBA.ENDDATNO & "'"
            strSQL = strSQL & "          AND DENKB = '1'"
            'change start 20190730 kuwahara
            'Call DB_GetSQL2(DBN_UDNTHA, strSQL)
            dt = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                DBSTAT = 1
            Else
                DBSTAT = 0
            End If
            'change end 20190730 kuwahara
            If DBSTAT = 0 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 2) '�ԍ������ς̓`�[�͒����ł��܂���B
                'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                DATNO_CheckC = -1
                Exit Function
            End If
            ' === 20130523 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
            Call DP_SSSMAIN_JDNNO(0, WK_JDNNO)
			' === 20140311 === INSERT S - FWEST)Koroyasu ����Ŗ@�����Ή�
			strSQL = ""
			strSQL = strSQL & "SELECT"
			strSQL = strSQL & "  COUNT(C_JYUCYU_NO) "
			strSQL = strSQL & "FROM"
			strSQL = strSQL & "  JDN_LOCK "
			strSQL = strSQL & "WHERE"
			strSQL = strSQL & "  C_FAC_CD    = 'CONTEC' "
			strSQL = strSQL & "AND"
			strSQL = strSQL & "  C_JYUCYU_NO = '" & Trim(WK_JDNNO) & "' "
            'change start 20190730 kuwahara
            'Call DB_GetSQL2(DBN_UDNTHA, strSQL)
            dt = DB_GetTable(strSQL)
            'change end 20190730 kuwahara

            'change start 20190730 kuwahara
            'WK_CNT = DB_ExtNum.ExtNum(0)
            WK_CNT = dt.Rows(0)("COUNT(C_JYUCYU_NO)")
            If WK_CNT <> 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Rtn = DSP_MsgBox(SSS_ERROR, "_NEBIKI", 0) '�l�����ŋ��z�ɍ��ق��o�Ă��邽�߁A�����ł��܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				DATNO_CheckC = -1
				Exit Function
			End If
			' === 20140311 === INSERT E
			'�r���`�F�b�N
			' === 20130530 === UPDATE S - FWEST)Koroyasu
			'        rResult = SSSWIN_EXCTBZ_CHECK2
			rResult = SSSWIN_EXCTBZ_CHECK2(WK_JDNNO)
			' === 20130530 === UPDATE E
			Select Case rResult
				'����
				Case 0
					
					'�r��������
				Case 1
					'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Rtn = DSP_MsgBox(SSS_ERROR, "_EXCUPD", 0) '���̃v���O�����ōX�V���̂��߁A�����ł��܂���B
					'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					DATNO_CheckC = -1
					Exit Function
					
					'�ُ�I��
				Case 9
					'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Rtn = DSP_MsgBox(SSS_ERROR, "URKET51_004 ", 0) '�X�V�ُ�
					'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					DATNO_CheckC = -1
					Exit Function
					
			End Select
			' === 20130523 === INSERT E -
			SSS_LASTKEY.Value = DB_UDNTHA.DATNO
			'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Rtn = AE_ChOprtLater(PP, 4) '�\����ǉ����[�h�Ɉڍs
			
			'�O�����`�[�I�����A�x�����b�Z�[�W
			''''''''If DB_UDNTHA.SMADT = DB_SYSTBA.MONUPDDT Or _
			'''''''''   Mid$(DB_UDNTHA.SMADT, 1, 6) < Mid$(DB_UNYMTA.UNYDT, 1, 6) Then
			''''''''    Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52_1", 1) '�O���x�̓`�[�������s���܂��B
			''''''''End If
			
			'        If DB_UDNTHA.UDNDT <= DB_SYSTBA.UKSMEDT Then
			'            Rtn1 = DSP_MsgBox(SSS_ERROR, "DATE_1", 0) '�����������@�x���I
			'        Else
			'            Call DB_GetEq(DBN_TOKMTA, 1, DB_UDNTHA.TOKCD, BtrNormal)
			'            If DBSTAT = 0 Then
			'                If DB_UDNTHA.UDNDT <= DB_TOKMTA.TOKSMEDT Then
			'                    Rtn1 = DSP_MsgBox(SSS_ERROR, "DATE_1", 1) '���Ӑ搿�������@�x���I
			'                    Exit Function
			'                End If
			'            End If
			'        End If
			
			'2007/02/13 ADD ������01�i�o�׊�j�͍폜�s�Ƃ���B
			If DB_UDNTHA.URIKJN = "01" Then
				
			End If
			
		End If
	End Function
	
	Function DATNO_Slist(ByRef PP As clsPP, ByVal DATNO As Object, ByVal JDNNO As Object) As Object
        'DB_PARA(DBN_UDNTHA).KeyNo = 10
        'DB_PARA(DBN_UDNTHA).KeyBuf = "11" & JDNNO
        'change start 20190729 kuwahara
        'DB_PARA(DBN_UDNTHA).KeyBuf = "11"
        WLSUDN.UDN2_PARA1 = "11"
        'change end 20190729 kuwahara
        WLSUDN.ShowDialog() '0:���͌��ꗗ�͓��͌�Ɏc���w��B
        WLSUDN.Close()
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDbNull(PP.SlistCom) = True Then
			'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DATNO_Slist = PP.SlistCom
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DATNO_Slist = Left(PP.SlistCom, 10)
		End If
		
	End Function
	
	Function DATNO_Skip(ByRef CT_DATNO As System.Windows.Forms.Control) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DATNO_Skip = True
		'UPGRADE_WARNING: �I�u�W�F�N�g CT_DATNO.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/06/04 CHG START
        'CT_DATNO.SelStart = 10
        DirectCast(CT_DATNO, TextBox).SelectionStart = 10
        '2019/06/04 CHG END
		'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DATNO_Skip = False
	End Function
	
	' === 20160302 === INSERT S - FWEST)Koroyasu
	'����(1)�폜���I�����ꂽ�ꍇ�ɁA���̃`�F�b�N���s���B
	Function DATNO_CheckDeleteCm(ByRef DATNO As Object) As Object
		Dim Rtn As Object
		Dim strSQL As String
		Dim WK_CNT As Integer
		
		'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_CheckDeleteCm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DATNO_CheckDeleteCm = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g DATNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(DATNO) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_CheckDeleteCm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DATNO_CheckDeleteCm = -1
			Exit Function
		End If
		
		'�����ς݂�����
		strSQL = ""
		strSQL = strSQL & "SELECT COUNT(*) FROM UDNTRA"
		'UPGRADE_WARNING: �I�u�W�F�N�g DATNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & " WHERE DATNO = '" & DATNO & "'"
        strSQL = strSQL & "   AND JKESIKN <> 0 "
        'change start 20190830 kuwa
        'Call DB_GetSQL2(DBN_UDNTRA, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190830 kuwa
        'change start 20190830 kuwa �v�m�F
        'WK_CNT = DB_ExtNum.ExtNum(0)
        WK_CNT = dt.Rows(0)("COUNT(*)")
        'chnage end 20190830 kuwa
        If WK_CNT <> 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 7) '�����ςׁ݂̈A�����ł��܂���B
			'UPGRADE_WARNING: �I�u�W�F�N�g DATNO_CheckDeleteCm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DATNO_CheckDeleteCm = -1
			Exit Function
		End If
	End Function
	' === 20160302 === INSERT E -
End Module