Option Strict Off
Option Explicit On
Module UDNTRA_M53
    '
    ' �X���b�g��        : ����g�����E���C���t�@�C���X�V�X���b�g(PL/SQL�Ή�)
    ' ���j�b�g��        : UDNTRA.M53
    ' �L�q��            : Standard Library
    ' �쐬���t          : 2006/09/22
    ' �g�p�v���O������  : URIET52
    '
    '20190726 DELL START
    'Function WRTTRN() As Short
    '    '2019/06/05 DELL START
    '    'Dim I As Short
    '    'Dim PlStat As Integer
    '    'Dim wkTOKCD As String

    '    'Dim EXEPATH As String
    '    'Dim FILE1_PATH As String
    '    'Dim lngFileNo1 As Integer
    '    ''
    '    'FR_SSSMAIN.Enabled = False

    '    '' PL/SQL �Ή����Ұ� G_PlCnd.nJobMode �� SSSMAIN.ET1 �Őݒ肳���

    '    ''''    If WG_DSPKB = 2 Then
    '    ''''        G_PlCnd.nJobMode = 0
    '    ''''    End If

    '    'If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
    '    '    MsgBox("�y" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "�z���N�����ł��B" & Trim(SSS_PrgNm) & "����͂��鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
    '    '    WRTTRN = False
    '    '    PlStat = DB_PlFree()
    '    '    FR_SSSMAIN.Enabled = True

    '    '    '�V���A�����o�^���[�N�̍폜
    '    '    Call DB_BeginTransaction(CStr(BTR_Exclude))
    '    '    Call DB_GetGrEq(DBN_SRAET53, 1, SSS_CLTID.Value & SSS_PrgId, BtrNormal)
    '    '    Do While (DBSTAT = 0) And (Trim(DB_SRAET53.RPTCLTID) = Trim(SSS_CLTID.Value)) And (Trim(DB_SRAET53.PRGID) = Trim(SSS_PrgId))
    '    '        Call DB_Delete(DBN_SRAET53)
    '    '        Call DB_GetNext(DBN_SRAET53, BtrNormal)
    '    '    Loop
    '    '    Call DB_EndTransaction()

    '    '    Exit Function
    '    'Else
    '    '    Call SSSWIN_EXCTBZ_OPEN()
    '    'End If

    '    'For I = 0 To MAX_CNDARR - 1
    '    '    G_PlCnd.sCndStr(I) = New String(Chr(Asc("A") + I), 20)
    '    '    G_PlCnd.nCndNum(I) = I + 1
    '    'Next I

    '    'G_PlCnd.sOpeID = SSS_OPEID.Value
    '    'G_PlCnd.sCltID = SSS_CLTID.Value
    '    'G_PlCnd.nCndNum(9) = -9999 'PL/SQL�ŃR�~�b�g���Ȃ�

    '    'G_PlInfo.FCnt = 4
    '    'G_PlInfo.Fno(0) = DBN_UDNTRA
    '    'G_PlInfo.RCnt(0) = PP_SSSMAIN.LastDe
    '    'G_PlInfo.ArrayFlg(0) = 1
    '    'G_PlInfo.Fno(1) = DBN_UDNTHA
    '    'G_PlInfo.RCnt(1) = 1
    '    'G_PlInfo.ArrayFlg(1) = 0
    '    'G_PlInfo.Fno(2) = DBN_FDNTRA
    '    'G_PlInfo.RCnt(2) = PP_SSSMAIN.LastDe
    '    'G_PlInfo.ArrayFlg(2) = 1
    '    'G_PlInfo.Fno(3) = DBN_FDNTHA
    '    'G_PlInfo.RCnt(3) = 1
    '    'G_PlInfo.ArrayFlg(3) = 0
    '    ''
    '    ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    'G_PlCnd.sCndStr(0) = RD_SSSMAIN_TOKCD(-1)
    '    ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_NHSCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    'G_PlCnd.sCndStr(1) = RD_SSSMAIN_NHSCD(-1)
    '    ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TANCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    'G_PlCnd.sCndStr(2) = RD_SSSMAIN_TANCD(-1)

    '    'Call TOKMTA_RClear()
    '    ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    'wkTOKCD = RD_SSSMAIN_TOKCD(-1) & Space(Len(DB_TOKMTA.TOKCD) - Len(RD_SSSMAIN_TOKCD(-1)))
    '    'Call DB_GetEq(DBN_TOKMTA, 1, wkTOKCD, BtrNormal)
    '    ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SSADT(-1) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SMADT(-1) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    'If RD_SSSMAIN_SMADT(-1) > DB_SYSTBA.UKSMEDT And (RD_SSSMAIN_SSADT(-1) > DB_TOKMTA.TOKSMEDT) Then
    '    '    G_PlCnd.sCndStr(3) = "1" '�����x��
    '    'Else
    '    '    G_PlCnd.sCndStr(3) = "0" '�O���x
    '    'End If
    '    ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_DATNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    'G_PlCnd.sCndStr(4) = RD_SSSMAIN_DATNO(-1)
    '    ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UDNDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    'G_PlCnd.sCndStr(5) = RD_SSSMAIN_UDNDT(-1)
    '    ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_DENDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    'G_PlCnd.sCndStr(6) = RD_SSSMAIN_DENDT(-1)
    '    'G_PlCnd.sCndStr(7) = SSS_SMADT.Value
    '    'G_PlCnd.sCndStr(8) = SSS_SSADT.Value
    '    'G_PlCnd.sCndStr(9) = SSS_KESDT.Value
    '    ''
    '    'Call UDNTHA_RClear()
    '    'Call UDNTHA_FromSCR(-1)
    '    'DB_UDNTHA.DATKB = "1"
    '    'DB_UDNTHA.DENKB = "1"
    '    'DB_UDNTHA.UDNPRAKB = "9"
    '    'DB_UDNTHA.UDNPRBKB = "9"
    '    'DB_UDNTHA.SMADT = SSS_SMADT.Value
    '    'DB_UDNTHA.SSADT = SSS_SSADT.Value
    '    'DB_UDNTHA.KESDT = SSS_KESDT.Value
    '    'Dim WK_FDNNO As String
    '    ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_FDNNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    'WK_FDNNO = RD_SSSMAIN_FDNNO(-1)


    '    '' �ً}�o�׊
    '    'If FR_SSSMAIN.HD_EMGODNKB.CheckState = 0 Then
    '    '    DB_UDNTHA.EMGODNKB = "9"
    '    'Else
    '    '    DB_UDNTHA.EMGODNKB = "1"
    '    'End If
    '    ''
    '    'PlStat = DB_PlStart()
    '    'PlStat = DB_PlCndSet()
    '    'PlStat = DB_PlSet(DBN_UDNTHA, 0)

    '    'If DB_UDNTHA.EMGODNKB = "1" Then
    '    '    '�o�׎w�����o���g����
    '    '    Call FDNTHA_RClear()
    '    '    Call FDNTHA_FromSCR(-1)
    '    '    DB_FDNTHA.DATKB = "1"
    '    '    DB_FDNTHA.DENKB = "1"
    '    '    DB_FDNTHA.FDNDT = DB_UNYMTA.UNYDT
    '    '    DB_FDNTHA.CANKB = "0"
    '    '    DB_FDNTHA.WRKKB = "5"
    '    '    DB_FDNTHA.RELFL = "0"
    '    '    PlStat = DB_PlSet(DBN_FDNTHA, 0)
    '    'Else
    '    '    Call FDNTHA_RClear()
    '    '    PlStat = DB_PlSet(DBN_FDNTHA, 0)
    '    'End If
    '    'I = 0
    '    'Do While I < PP_SSSMAIN.LastDe
    '    '    Call UDNTRA_RClear()
    '    '    Call Mfil_FromSCR(I)
    '    '    DB_UDNTRA.DATKB = "1"
    '    '    DB_UDNTRA.DENKB = "1"
    '    '    DB_UDNTRA.SMADT = SSS_SMADT.Value
    '    '    DB_UDNTRA.SSADT = SSS_SSADT.Value
    '    '    DB_UDNTRA.KESDT = SSS_KESDT.Value
    '    '    DB_UDNTRA.DKBSB = WG_DKBSB
    '    '    DB_UDNTRA.LINNO = VB6.Format(I + 1, "000")

    '    '    ' �ً}�o�׊
    '    '    If FR_SSSMAIN.HD_EMGODNKB.CheckState = 0 Then
    '    '        DB_UDNTRA.EMGODNKB = "9"
    '    '    Else
    '    '        DB_UDNTRA.EMGODNKB = "1"
    '    '    End If

    '    '    PlStat = DB_PlSet(DBN_UDNTRA, I)

    '    '    If DB_UDNTRA.EMGODNKB = "1" Then
    '    '        '�o�׎w���g����
    '    '        Call FDNTRA_RClear()
    '    '        Call FDNTRA_FromSCR(I)
    '    '        DB_FDNTRA.DATKB = "1"
    '    '        DB_FDNTRA.DENKB = "1"
    '    '        DB_FDNTRA.FDNDT = DB_UNYMTA.UNYDT
    '    '        DB_FDNTRA.CANKB = "0"
    '    '        DB_FDNTRA.WRKKB = "5"
    '    '        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MNZHIKSU(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    '        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ATZHIKSU() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    '        DB_FDNTRA.HIKSU = RD_SSSMAIN_ATZHIKSU(I) + RD_SSSMAIN_MNZHIKSU(I)
    '    '        DB_FDNTRA.FDNZMIFL = "1"
    '    '        PlStat = DB_PlSet(DBN_FDNTRA, I)
    '    '    Else
    '    '        Call FDNTRA_RClear()
    '    '        PlStat = DB_PlSet(DBN_FDNTRA, I)
    '    '    End If
    '    '    I = I + 1
    '    'Loop

    '    'Call DB_BeginTransaction(CStr(BTR_Exclude))

    '    'PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_UDNTRA")
    '    'If PlStat <> 0 And PlStat <> 1485 Then
    '    '    MsgBox("PL/SQL Error�F" & PlStat)
    '    '    WRTTRN = False
    '    '    DB_AbortTransaction()
    '    '    '''    ElseIf Trim$(G_PlCnd2.sCndStr(2)) <> "" Then
    '    '    '''        MsgBox Error
    '    '    '''        WRTTRN = False
    '    '    '''        DB_AbortTransaction
    '    'Else
    '    '    WRTTRN = True
    '    '    Call DB_EndTransaction()
    '    '    '1998/05/12  �P�s�ǉ�
    '    '    Call DP_SSSMAIN_UDNNO(-1, G_PlCnd2.sCndStr(1))
    '    '    ' === 20130523 === INSERT S - FWEST)Koroyasu �r������̉���
    '    '    Call SSSWIN_Unlock_EXCTBZ()
    '    '    ' === 20130523 === INSERT E -
    '    'End If
    '    'PlStat = DB_PlFree()

    '    'FR_SSSMAIN.Enabled = True

    '    ''�V���A�����o�^���[�N�̍폜
    '    'Call DB_BeginTransaction(CStr(BTR_Exclude))
    '    'Call DB_GetGrEq(DBN_SRAET53, 1, SSS_CLTID.Value & SSS_PrgId, BtrNormal)
    '    'Do While (DBSTAT = 0) And (Trim(DB_SRAET53.RPTCLTID) = Trim(SSS_CLTID.Value)) And (Trim(DB_SRAET53.PRGID) = Trim(SSS_PrgId))
    '    '    Call DB_Delete(DBN_SRAET53)
    '    '    Call DB_GetNext(DBN_SRAET53, BtrNormal)
    '    'Loop
    '    'Call DB_EndTransaction()

    '    ''�ً}�o�׎��̂݁A�����A�g�ւ̃e�L�X�g�o��
    '    'If DB_UDNTHA.EMGODNKB = "1" Then
    '    '    'INI�t�@�C���擾�p�֐�
    '    '    FILE1_PATH = GP_GetIni(AE_AppPath & "SYKFP51.ini", "FILEPATH", "FILE1")
    '    '    lngFileNo1 = FreeFile()
    '    '    FileOpen(lngFileNo1, FILE1_PATH, OpenMode.Output)
    '    '    FileClose(lngFileNo1)
    '    'End If
    '    '2019/06/05 DELL END

    'End Function
    '20190726 DELL END
    '20190726 DELL START
    '   Function DELTRN() As Short

    '	Dim PlStat As Integer
    '	Dim I As Short
    '	Dim Rtn As Short
    '	Dim wkTOKCD As String

    '	Dim EXEPATH As String
    '	Dim FILE1_PATH As String
    '	Dim lngFileNo1 As Integer


    '	'     PL/SQL �Ή����Ұ� G_PlCnd.nJobMode �� SSSMAIN.ET1 �Őݒ肳���
    '	If G_PlCnd.nJobMode <> 2 Then Exit Function 'Delete�ȊO
    '	FR_SSSMAIN.Enabled = False

    '	'�����`�F�b�N
    '	If gs_UPDAUTH = "9" Then
    '		Rtn = DSP_MsgBox(SSS_ERROR, "UPDAUTH", 0) '�X�V�����Ȃ�
    '		DELTRN = False
    '		Exit Function
    '	End If

    '	If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
    '		MsgBox("�y" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "�z���N�����ł��B" & Trim(SSS_PrgNm) & "����͂��鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
    '		DELTRN = True
    '		PlStat = DB_PlFree
    '		FR_SSSMAIN.Enabled = True

    '		'�V���A�����o�^���[�N�̍폜
    '		Call DB_BeginTransaction(CStr(BTR_Exclude))
    '		Call DB_GetGrEq(DBN_SRAET53, 1, SSS_CLTID.Value & SSS_PrgId, BtrNormal)
    '		Do While (DBSTAT = 0) And (Trim(DB_SRAET53.RPTCLTID) = Trim(SSS_CLTID.Value)) And (Trim(DB_SRAET53.PRGID) = Trim(SSS_PrgId))
    '			Call DB_Delete(DBN_SRAET53)
    '			Call DB_GetNext(DBN_SRAET53, BtrNormal)
    '		Loop 
    '		Call DB_EndTransaction()

    '		Exit Function
    '	Else
    '		Call SSSWIN_EXCTBZ_OPEN()
    '	End If

    '	'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UDNDT(-1) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	If RD_SSSMAIN_UDNDT(-1) <= DB_SYSTBA.UKSMEDT Then
    '		Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 0) '�������������߂��Ă��܂��B
    '		DELTRN = False
    '		Exit Function
    '	End If
    '	'
    '	'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	wkTOKCD = RD_SSSMAIN_TOKCD(-1) & Space(Len(DB_TOKMTA.TOKSEICD) - Len(RD_SSSMAIN_TOKCD(-1)))
    '	Call DB_GetEq(DBN_TOKMTA, 1, wkTOKCD, BtrNormal)
    '	If DBSTAT = 0 Then
    '		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UDNDT(-1) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		If RD_SSSMAIN_UDNDT(-1) <= DB_TOKMTA.TOKSMEDT Then
    '			Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 1) '�o�^���ꂽ���Ӑ�̐����������߂��Ă��܂��B
    '			DELTRN = False
    '			Exit Function
    '		End If
    '	End If

    '	'2008/1/22 FKS)ichihara CHG START
    '	'FJCL�C�����̔��f�i377�Č����j
    '	'    ' ADD 2007/02/13 ������01(�o�׊)�͍폜�s�Ƃ���
    '	'    If RD_SSSMAIN_URIKJN(-1) = "01" Then
    '	'        Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52_2", 0) '�Y���`�[�͏o�׊�ׁ̈A�폜�ł��܂���B
    '	'        DELTRN = False
    '	'        Exit Function
    '	'    End If
    '	' ADD 2007/02/13 ������01(�o�׊)�͍폜�s�Ƃ��� (2007/12/29 ����)
    '	'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URIKJN(-1) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	If RD_SSSMAIN_URIKJN(-1) = "01" Then
    '		Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52_1", 5) '�Y���`�[�͏o�׊�ׁ̈A�폜�ł��܂���B
    '		DELTRN = False
    '		Exit Function
    '	End If
    '	'2008/1/22 FKS)ichihara CHG END

    '	For I = 0 To MAX_CNDARR - 1
    '		G_PlCnd.sCndStr(I) = New String(Chr(Asc("A") + I), 20)
    '		G_PlCnd.nCndNum(I) = I + 1
    '	Next I

    '	G_PlCnd.sOpeID = SSS_OPEID.Value
    '	G_PlCnd.sCltID = SSS_CLTID.Value

    '	G_PlInfo.FCnt = 4
    '	G_PlInfo.Fno(0) = DBN_UDNTRA
    '	G_PlInfo.RCnt(0) = PP_SSSMAIN.LastDe
    '	G_PlInfo.ArrayFlg(0) = 1
    '	G_PlInfo.Fno(1) = DBN_UDNTHA
    '	G_PlInfo.RCnt(1) = 1
    '	G_PlInfo.ArrayFlg(1) = 0
    '	G_PlInfo.Fno(2) = DBN_FDNTRA
    '	G_PlInfo.RCnt(2) = PP_SSSMAIN.LastDe
    '	G_PlInfo.ArrayFlg(2) = 1
    '	G_PlInfo.Fno(3) = DBN_FDNTHA
    '	G_PlInfo.RCnt(3) = 1
    '	G_PlInfo.ArrayFlg(3) = 0
    '	'
    '	'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	G_PlCnd.sCndStr(0) = RD_SSSMAIN_TOKCD(-1)
    '	'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_NHSCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	G_PlCnd.sCndStr(1) = RD_SSSMAIN_NHSCD(-1)
    '	'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TANCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	G_PlCnd.sCndStr(2) = RD_SSSMAIN_TANCD(-1)
    '	'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SSADT(-1) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SMADT(-1) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	If RD_SSSMAIN_SMADT(-1) > DB_SYSTBA.UKSMEDT And (RD_SSSMAIN_SSADT(-1) > DB_TOKMTA.TOKSMEDT) Then
    '		G_PlCnd.sCndStr(3) = "1" '�����x��
    '	Else
    '		G_PlCnd.sCndStr(3) = "0" '�O���x
    '	End If
    '	'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_DATNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	G_PlCnd.sCndStr(4) = RD_SSSMAIN_DATNO(-1)
    '	'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UDNDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	G_PlCnd.sCndStr(5) = RD_SSSMAIN_UDNDT(-1)
    '	'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_DENDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	G_PlCnd.sCndStr(6) = RD_SSSMAIN_DENDT(-1)
    '	G_PlCnd.sCndStr(7) = SSS_SMADT.Value
    '	G_PlCnd.sCndStr(8) = SSS_SSADT.Value
    '	G_PlCnd.sCndStr(9) = SSS_KESDT.Value
    '	'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UDNNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	DB_UDNTHA.UDNNO = RD_SSSMAIN_UDNNO(-1)

    '	PlStat = DB_PlStart
    '	PlStat = DB_PlCndSet
    '	PlStat = DB_PlSet(DBN_UDNTHA, 0)
    '	PlStat = DB_PlSet(DBN_UDNTRA, 0)
    '       '20190726 DELL START
    '       'Call UDNTHA_RClear()
    '       '20190726 DELL END
    '       Call UDNTHA_FromSCR(-1)
    '	DB_UDNTHA.DATKB = "1"
    '	DB_UDNTHA.DENKB = "1"
    '	DB_UDNTHA.UDNPRAKB = "9"
    '	DB_UDNTHA.UDNPRBKB = "9"
    '	DB_UDNTHA.SMADT = SSS_SMADT.Value
    '	DB_UDNTHA.SSADT = SSS_SSADT.Value
    '	DB_UDNTHA.KESDT = SSS_KESDT.Value
    '	Dim WK_FDNNO As String
    '	'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_FDNNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	WK_FDNNO = RD_SSSMAIN_FDNNO(-1)


    '	' �ً}�o�׊
    '	If FR_SSSMAIN.HD_EMGODNKB.CheckState = 0 Then
    '		DB_UDNTHA.EMGODNKB = "9"
    '	Else
    '		DB_UDNTHA.EMGODNKB = "1"
    '	End If
    '	'
    '	PlStat = DB_PlStart
    '	PlStat = DB_PlCndSet
    '	PlStat = DB_PlSet(DBN_UDNTHA, 0)

    '       If DB_UDNTHA.EMGODNKB = "1" Then
    '           '�o�׎w�����o���g����
    '           '20190726 DELL START
    '           'Call FDNTHA_RClear()
    '           '20190726 DELL END
    '           Call FDNTHA_FromSCR(-1)
    '           DB_FDNTHA.DATKB = "1"
    '           DB_FDNTHA.DENKB = "1"
    '           DB_FDNTHA.FDNDT = DB_UNYMTA.UNYDT
    '           DB_FDNTHA.CANKB = "0"
    '           DB_FDNTHA.WRKKB = "5"
    '           DB_FDNTHA.RELFL = "0"
    '           PlStat = DB_PlSet(DBN_FDNTHA, 0)
    '       Else
    '           '20190726 DELL END
    '           'Call FDNTHA_RClear()
    '           '20190726 DLEL END
    '           PlStat = DB_PlSet(DBN_FDNTHA, 0)
    '	End If
    '	I = 0
    '       Do While I < PP_SSSMAIN.LastDe
    '           '20190726 DELL START
    '           'Call UDNTRA_RClear()
    '           '20190726 DLL END
    '           Call Mfil_FromSCR(I)
    '           DB_UDNTRA.DATKB = "1"
    '           DB_UDNTRA.DENKB = "1"
    '           DB_UDNTRA.SMADT = SSS_SMADT.Value
    '           DB_UDNTRA.SSADT = SSS_SSADT.Value
    '           DB_UDNTRA.KESDT = SSS_KESDT.Value
    '           DB_UDNTRA.DKBSB = WG_DKBSB
    '           DB_UDNTRA.LINNO = VB6.Format(I + 1, "000")

    '           ' �ً}�o�׊
    '           If FR_SSSMAIN.HD_EMGODNKB.CheckState = 0 Then
    '               DB_UDNTRA.EMGODNKB = "9"
    '           Else
    '               DB_UDNTRA.EMGODNKB = "1"
    '           End If

    '           PlStat = DB_PlSet(DBN_UDNTRA, I)

    '           If DB_UDNTRA.EMGODNKB = "1" Then
    '               '�o�׎w���g����
    '               '20910726 DELL START
    '               'Call FDNTRA_RClear()
    '               '20190726 DELL END
    '               Call FDNTRA_FromSCR(I)
    '               DB_FDNTRA.DATKB = "1"
    '               DB_FDNTRA.DENKB = "1"
    '               DB_FDNTRA.FDNDT = DB_UNYMTA.UNYDT
    '               DB_FDNTRA.CANKB = "0"
    '               DB_FDNTRA.WRKKB = "5"
    '               'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MNZHIKSU(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '               'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ATZHIKSU() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '               DB_FDNTRA.HIKSU = RD_SSSMAIN_ATZHIKSU(I) + RD_SSSMAIN_MNZHIKSU(I)
    '               DB_FDNTRA.FDNZMIFL = "1"
    '               PlStat = DB_PlSet(DBN_FDNTRA, I)
    '           Else
    '               '20190726 DELL START
    '               'Call FDNTRA_RClear()
    '               '20190726 DELL END
    '               PlStat = DB_PlSet(DBN_FDNTRA, I)
    '           End If
    '           I = I + 1
    '       Loop

    '       Call DB_BeginTransaction(CStr(BTR_Exclude))
    '	PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_UDNTRA")
    '	If PlStat <> 0 And PlStat <> 1485 Then
    '		MsgBox("PL/SQL Error�F" & PlStat)
    '		DELTRN = False
    '		DB_AbortTransaction()
    '	Else
    '		DELTRN = True
    '		Call DB_EndTransaction()
    '		' === 20130523 === INSERT S - FWEST)Koroyasu �r������̉���
    '		Call SSSWIN_Unlock_EXCTBZ()
    '		' === 20130523 === INSERT E -
    '	End If

    '	PlStat = DB_PlFree

    '	FR_SSSMAIN.Enabled = True

    '	'�V���A�����o�^���[�N�̍폜
    '	Call DB_BeginTransaction(CStr(BTR_Exclude))
    '	Call DB_GetGrEq(DBN_SRAET53, 1, SSS_CLTID.Value & SSS_PrgId, BtrNormal)
    '	Do While (DBSTAT = 0) And (Trim(DB_SRAET53.RPTCLTID) = Trim(SSS_CLTID.Value)) And (Trim(DB_SRAET53.PRGID) = Trim(SSS_PrgId))
    '		Call DB_Delete(DBN_SRAET53)
    '		Call DB_GetNext(DBN_SRAET53, BtrNormal)
    '	Loop 
    '	Call DB_EndTransaction()

    '	'�ً}�o�׎��̂݁A�����A�g�ւ̃e�L�X�g�o��
    '	If DB_UDNTHA.EMGODNKB = "1" Then
    '		'INI�t�@�C���擾�p�֐�
    '		FILE1_PATH = GP_GetIni(AE_AppPath & "SYKFP51.ini", "FILEPATH", "FILE1")
    '		lngFileNo1 = FreeFile
    '		FileOpen(lngFileNo1, FILE1_PATH, OpenMode.Output)
    '		FileClose(lngFileNo1)
    '	End If

    'End Function
    '20910726 DELL END

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
        '2019/06/04 CHG START
        'lngInstr = InStrB(strData, ";")
        lngInstr = InStr(strData, ";")
        '2019/06/04 CHG END
        If lngInstr <> 0 Then
            'UPGRADE_ISSUE: InStrB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
            'UPGRADE_ISSUE: MidB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
            '2019/06/04 CHG START
            strWK = MidB(strData, 1, InStr(strData, ";") - 1)
            'strWK = MidB(strData, 1, InStrB(strData, ";") - 1)
            '2019/06/04 CHG END
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
        '2019/06/04 CHG START
        'AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
        AnsiLeftB = LeftB(StrArg, arg1)
        '2019/06/04 CHG END
    End Function
	
	Function AnsiLenB(ByVal StrArg As String) As Integer
        '�T�v�F����������
        '�����FStrArg,Input,String,�Ώە�����
        '�����FAnsi���ނ��޲ĵ��ނŕ�������޲Đ���Ԃ�
#If Win32 Then
        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/06/04 CHG START
        'AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
        AnsiLenB = LenB(StrArg)
        '2019/06/04 CHG END
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