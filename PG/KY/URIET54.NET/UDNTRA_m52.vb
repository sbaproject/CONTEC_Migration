Option Strict Off
Option Explicit On
Module UDNTRA_M52
	'
	' �X���b�g��        : ����g�����E���C���t�@�C���X�V�X���b�g(PL/SQL�Ή�)
	' ���j�b�g��        : UDNTRA.M52
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/09/11
	' �g�p�v���O������  : URIET54
	'
	
	Function DELTRN() As Short
	End Function
    '2019/09/219 DELL START
    'Function WRTTRN() As Short
    '    Dim I As Short
    '    Dim PlStat As Integer

    '     Dim FILE1_PATH As String
    '     Dim lngFileNo1 As Integer
    '
    '    FR_SSSMAIN.Enabled = False

    'ADD START FKS)INABA 2009/11/19 *********************
    '�A���[��758
    '    If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
    '        MsgBox("�y" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "�z���N�����ł��B" & Trim(SSS_PrgNm) & "����͂��鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
    '        WRTTRN = False
    '        PlStat = DB_PlFree()
    '        FR_SSSMAIN.Enabled = True
    '       Exit Function
    '    Else
    '        Call SSSWIN_EXCTBZ_OPEN()
    '    End If
    '   'ADD  END  FKS)INABA 2009/11/19 *********************
    '   ' PL/SQL �Ή����Ұ� G_PlCnd.nJobMode �� SSSMAIN.ET1 �Őݒ肳���

    '   G_PlCnd.nJobMode = 0

    '    '20080910 ADD START RISE)Tanimura '�r������
    '    Call DB_BeginTransaction(CStr(BTR_Exclude))

    '    ' �r���X�V���ԃ`�F�b�N
    '   'UPGRADE_WARNING: �I�u�W�F�N�g CHK_HAITA_UPD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    If CHK_HAITA_UPD() = 0 Then
    '        ' �G���[
    '        Call DSP_MsgBox(SSS_ERROR, "URIET54_001", 0) '���̃v���O�����ōX�V���ꂽ���߁A�o�^�ł��܂���B
    '        WRTTRN = False
    '        DB_AbortTransaction()
    '        Exit Function
    '    End If
    '    '20080910 ADD END   RISE)Tanimura
    '       'ADD START FKS)INABA 2009/07/03 **************************
    '       '�A���[��739
    '    Dim lw_ret As Short
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CHK_UNYDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    lw_ret = CHK_UNYDT(DB_UNYMTA.UNYDT)
    '   If lw_ret <> 0 Then
    '        Call DSP_MsgBox(SSS_ERROR, "DATE_2", 0) '�^�p�����ύX����܂����B���j���[�ɖ߂��Ă��������B�B
    '        WRTTRN = False
    '        DB_AbortTransaction()
    '        Exit Function
    '   End If
    '    'ADD  END  FKS)INABA 2009/07/03 **************************
    '    For I = 0 To MAX_CNDARR - 1
    '        G_PlCnd.sCndStr(I) = New String(Chr(Asc("A") + I), 20)
    '        G_PlCnd.nCndNum(I) = I + 1
    '    Next I

    '    G_PlCnd.sOpeID = SSS_OPEID.Value
    '    G_PlCnd.sCltID = SSS_CLTID.Value

    '    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_DATNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    G_PlCnd.sCndStr(0) = RD_SSSMAIN_DATNO(0)
    '    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEIKBA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    G_PlCnd.sCndStr(1) = RD_SSSMAIN_MEIKBA(0)
    '    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEIKBB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    G_PlCnd.sCndStr(2) = RD_SSSMAIN_MEIKBB(0)
    '    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEIKBC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    G_PlCnd.sCndStr(3) = RD_SSSMAIN_MEIKBC(0)
    '    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SRANO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    G_PlCnd.sCndStr(4) = RD_SSSMAIN_SRANO(0)
    '    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    G_PlCnd.sCndStr(5) = RD_SSSMAIN_SOUCD(0)
    '    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_OUTSOUCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    G_PlCnd.sCndStr(6) = RD_SSSMAIN_OUTSOUCD(0)
    '    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HENRSNCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    G_PlCnd.sCndStr(7) = RD_SSSMAIN_HENRSNCD(0)
    '    '20090115 ADD START RISE)Tanimura '�A���[No.523
    '    G_PlCnd.sCndStr(8) = g_strURIKB
    '    '20090115 ADD END   RISE)Tanimura

    '    G_PlInfo.FCnt = 2
    '    G_PlInfo.Fno(0) = DBN_UDNTRA
    '   G_PlInfo.RCnt(0) = PP_SSSMAIN.LastDe
    '    G_PlInfo.ArrayFlg(0) = 1
    '    G_PlInfo.Fno(1) = DBN_UDNTHA
    '    G_PlInfo.RCnt(1) = 1
    '    G_PlInfo.ArrayFlg(1) = 0
    '
    '   '���㌩�o���g����
    '    Call UDNTHA_RClear()
    '    Call UDNTHA_FromSCR(-1)
    '    DB_UDNTHA.DATKB = "1"
    '    DB_UDNTHA.DENKB = "1"
    '    DB_UDNTHA.AKAKROKB = "9"
    '    DB_UDNTHA.SMADT = SSS_SMADT.Value
    '    DB_UDNTHA.SSADT = SSS_SSADT.Value
    '    DB_UDNTHA.KESDT = SSS_KESDT.Value
    '    DB_UDNTHA.UDNPRBKB = "9"
    '    '''' ADD 2009/04/27  FKS) S.Nakajima    Start
    '   'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_DATNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    DB_UDNTHA.MOTDATNO = RD_SSSMAIN_DATNO(-1)
    '    '''' ADD 2009/04/27  FKS) S.Nakajima    End
    '
    '    PlStat = DB_PlStart()
    '    PlStat = DB_PlCndSet()
    '    PlStat = DB_PlSet(DBN_UDNTHA, 0)

    '    I = 0
    '    Do While I < PP_SSSMAIN.LastDe
    '        '����g����
    '       '2019/09/19 DEL START
    '       'Call UDNTRA_RClear()
    '       '2019/09/19 DEL E N D
    '        Call Mfil_FromSCR(I)
    '        DB_UDNTRA.DATKB = "1"
    '        DB_UDNTRA.DENKB = "1"
    '        DB_UDNTRA.AKAKROKB = "9"
    '        DB_UDNTRA.SMADT = SSS_SMADT.Value
    '        DB_UDNTRA.SSADT = SSS_SSADT.Value
    '        DB_UDNTRA.KESDT = SSS_KESDT.Value
    '        DB_UDNTRA.DKBSB = WG_DKBSB
    '        '2007/03/21 ADD-START
    '       'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HENRSNCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        DB_UDNTRA.HENRSNCD = RD_SSSMAIN_HENRSNCD(0)
    '        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HENSTTCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        DB_UDNTRA.HENSTTCD = RD_SSSMAIN_HENSTTCD(0)
    '        '2007/03/21 ADD-END

    '       ''' ADD 2009/04/27  FKS) S.Nakajima    Start
    '       'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_DATNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        DB_UDNTRA.MOTDATNO = RD_SSSMAIN_DATNO(I)
    '        '''' ADD 2009/04/27  FKS) S.Nakajima    End
    '        PlStat = DB_PlSet(DBN_UDNTRA, I)

    '        I = I + 1
    '   Loop

    '   '20080910 DEL START RISE)Tanimura '�r������
    '    Call DB_BeginTransaction(BTR_Exclude)
    '   '20080910 DEL END   RISE)Tanimura
    '    PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_UDNTRA")
    '    If PlStat <> 0 And PlStat <> 1485 Then
    '        MsgBox("PL/SQL Error�F" & PlStat)
    '        WRTTRN = False
    '        DB_AbortTransaction()
    '    Else
    '        WRTTRN = True
    '        Call DB_EndTransaction()
    '        ' === 20130708 === INSERT S - FWEST)Koroyasu �r������̉���
    '        Call SSSWIN_Unlock_EXCTBZ()
    '        ' === 20130708 === INSERT E -
    '   End If
    '    PlStat = DB_PlFree()

    '    '�V���A�����o�^���[�N�̍폜
    '    Call DB_BeginTransaction(CStr(BTR_Exclude))
    '    Call DB_GetGrEq(DBN_SRAET52, 1, SSS_CLTID.Value, BtrNormal)
    '    Do While (DBSTAT = 0) And (Trim(DB_SRAET52.RPTCLTID) = Trim(SSS_CLTID.Value))
    '        Call DB_Delete(DBN_SRAET52)
    '        Call DB_GetNext(DBN_SRAET52, BtrNormal)
    '    Loop
    '    Call DB_EndTransaction()

    '    '20080910 ADD START RISE)Tanimura '�r������
    '   ' �N���A
    '    Erase M_SRACNTTB_MOTO_inf

    '    ReDim M_SRACNTTB_MOTO_inf(0)
    '    '20080910 ADD END   RISE)Tanimura

    '   'INI�t�@�C���擾�p�֐�
    '    FILE1_PATH = GP_GetIni(AE_AppPath & "URIET54.ini", "FILEPATH", "FILE1")
    '    lngFileNo1 = FreeFile()
    '    FileOpen(lngFileNo1, FILE1_PATH, OpenMode.Output)
    '    FileClose(lngFileNo1)

    '    FR_SSSMAIN.Enabled = True

    'End Function
    '2019/09/219 DELL E N D

    ' @(f) GP_GetIni
    '
    ' �@�\      :�ėpINI�t�@�C�������T�u���[�`��
    '
    ' �Ԃ�l    : String
    '
    ' ������    :strIniName INI�t�@�C���̖��O�i�g���q�͕s�v�j
    '            strAppName INI�t�@�C�����̃A�v���P�[�V������
    '�@�@�@�@�@�@keyname�@�@INI�t�@�C�����̃L�[��
    '
    Function GP_GetIni(ByVal strIniName As String, ByVal strAppName As String, ByVal strKeyName As String) As String
		
		Dim strTxt As New VB6.FixedLengthString(255)
		Dim lngLen As Integer
		
		GP_GetIni = ""
		
		'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If Dir(strIniName) = "" Then
			MsgBox("�Ώۂ�INI�t�@�C�������݂��܂���B" & vbCrLf & "[" & strIniName & "]", MsgBoxStyle.Critical, "INI�t�@�C���Ǎ��G���[")
			Exit Function
		End If
		
		'<< �f�[�^PATH���擾 >>
		lngLen = GetPrivateProfileString(strAppName, strKeyName, "", strTxt.Value, 255, strIniName)
		
		On Error GoTo Error_Routine
		
		GP_GetIni = P_GetIniItem(AnsiLeftB(strTxt.Value, lngLen))
		
		Exit Function
		
Error_Routine: 
		'*MsgBox "�w�肵���L�[�̃G���g�������݂��܂���B" & vbCrLf & "[" & strIniName & "]" & vbCrLf & "�A�v���P�[�V�����F" & strAppName & vbCrLf & "�L�[�F" & strKeyName, vbCritical, "INI�t�@�C���Ǎ��G���["
	End Function
	
	Function P_GetIniItem(ByVal strData As String) As String
		
		Dim strWK As String
		Dim strDummy As String
		Dim lngInstr As Integer
		Dim lngInstrRev As Integer
		
		lngInstr = 0

        '�C�j�t�@�C����";"�ȍ~�̓R�����g�Ȃ̂ŁA�R�����g���Ȃ��B
        'UPGRADE_ISSUE: InStrB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/09/19 CHG START
        'lngInstr = InStrB(strData, ";")
        lngInstr = InStr(strData, ";")
        '2019/09/19 CHG E N D
        If lngInstr <> 0 Then
            'UPGRADE_ISSUE: InStrB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
            'UPGRADE_ISSUE: MidB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
            '2019/09/19 CHG START
            strWK = MidB(strData, 1, InStr(strData, ";") - 1)
            'strWK = MidB(strData, 1, InStrB(strData, ";") - 1)
            '2019/09/19  CHG E N D
        Else
			strWK = strData
		End If
		
		lngInstr = 0
		lngInstrRev = 0
		
		'strWK=""�y�сAstrWK=""""�̏ꍇ�̓R�����g�s�B
		If strWK <> "" And strWK <> """" Then
			'�V���O���R�[�e�[�V�����ň͂񂾒��̕����̂ݎ擾�������̂ŁA
			'�V���O���R�[�e�[�V�����̕����ʒu���擾����B
			lngInstr = InStr(strWK, """")
			lngInstrRev = InStrRev(strWK, """")
			'strWk�̒��ɃV���O���R�[�e�[�V�������܂܂�Ă��邩���f����B
			If lngInstr <> lngInstrRev Then
				'�V���O���R�[�e�[�V�������܂܂�Ă����ꍇ�B
				'�V���O���R�[�e�[�V�����ň͂񂾒��̕����̂ݎ擾����B
				strDummy = Mid(strWK, lngInstr + 1, lngInstrRev - lngInstr - 1)
				
				If strDummy <> "" Then
					'�߂�l�̃Z�b�g�B
					P_GetIniItem = Trim(strDummy)
				End If
			Else
				'�V���O���R�[�e�[�V�������܂܂�Ă��Ȃ��ꍇ�B
				If Trim(strWK) <> "" Then
					'�߂�l�̃Z�b�g
					P_GetIniItem = Trim(strWK)
				End If
			End If
		Else
			P_GetIniItem = ""
		End If
		
	End Function
	
	Function AnsiLeftB(ByVal StrArg As String, ByVal arg1 As Integer) As String
        'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: LeftB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g AnsiStrConv() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/09/19 CHG START
        'AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
        AnsiLeftB = LeftB(StrArg, arg1)
        '2019/09/19 CHG E N D
    End Function
	
	Function AnsiLenB(ByVal StrArg As String) As Integer
        '�T�v�F����������
        '�����FStrArg,Input,String,�Ώە�����
        '�����FAnsi���ނ��޲ĵ��ނŕ�������޲Đ���Ԃ�
#If Win32 Then
        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/09/19 CHG START
        'AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
        AnsiLenB = LenB(StrArg)
        '2019/09/19 CHG E N D
#Else
		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
		AnsiLenB = LenB(StrArg)
#End If
    End Function
	
	' StrConv ���Ăяo���܂��B
	Function AnsiStrConv(ByRef StrArg As Object, ByRef flag As Object) As Object
#If Win32 Then
		'UPGRADE_WARNING: �I�u�W�F�N�g flag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g StrArg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AnsiStrConv = StrConv(StrArg, flag)
#Else
		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
		AnsiStrConv = StrArg
#End If
		
	End Function
End Module