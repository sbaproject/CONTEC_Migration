Option Strict Off
Option Explicit On
Module UDNTRA_M82
    '
    ' �X���b�g��        : ����g�����E���C���t�@�C���X�V�X���b�g(PL/SQL�Ή�)
    ' ���j�b�g��        : UDNTRA.M82
    ' �L�q��            : Standard Library
    ' �쐬���t          : 2006/09/20
    ' �g�p�v���O������  : URKET52
    '

    'Function DELTRN() As Short
    'Dim PlStat  As Long
    'Dim i%
    'Dim Rtn     As Integer
    'Dim wkTOKCD As String
    'Dim curCHECKKIN     As Currency
    'Dim curNYUKNZAN     As Currency
    '
    '    ' PL/SQL �Ή����Ұ� G_PlCnd.nJobMode �� SSSMAIN.ET1 �Őݒ肳���
    '    If G_PlCnd.nJobMode <> 2 Then Exit Function  'Delete�ȊO
    '
    '    '�����`�F�b�N
    '    If gs_UPDAUTH = "9" Then
    '        Rtn = DSP_MsgBox(SSS_ERROR, "UPDAUTH", 0) '�X�V�����Ȃ�
    '        DELTRN = False
    '        Exit Function
    '    End If
    '
    '    If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
    '        MsgBox "�y" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "�z���N�����ł��B" & Trim(SSS_PrgNm) & "����͂��鎖�͂ł��܂���B", vbExclamation Or vbOKOnly, SSS_PrgNm
    '        DELTRN = True
    '        PlStat = DB_PlFree
    '        FR_SSSMAIN.Enabled = True
    '        Exit Function
    '    Else
    '        Call SSSWIN_EXCTBZ_OPEN
    '    End If
    '
    '    '2007.02.28 �`�F�b�N�d�l�ύX
    '''''If RD_SSSMAIN_NYUDT(-1) <= DB_SYSTBA.UKSMEDT Then
    '''''    Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 0) '�������������߂��Ă��܂��B
    '''''    DELTRN = False
    '''''    Exit Function
    '''''End If
    '    If RD_SSSMAIN_NYUDT(-1) <= DB_SYSTBA.MONUPDDT Then
    '        Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 1)      '�����X�V�ς݂ł��B���̓��t�ł͓��͂ł��܂���B
    '        DELTRN = False
    '        Exit Function
    '    End If
    '    '
    '    '2007.02.28 �`�F�b�N�d�l�ύX
    '    wkTOKCD = RD_SSSMAIN_TOKCD(-1) & Space(Len(DB_TOKMTA.TOKSEICD) - Len(RD_SSSMAIN_TOKCD(-1)))
    '    Call DB_GetEq(DBN_TOKMTA, 1, wkTOKCD, BtrNormal)
    '    If DBSTAT = 0 Then
    '''''    If RD_SSSMAIN_NYUDT(-1) <= DB_TOKMTA.TOKSMEDT Then
    '''''        Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 1) '�o�^���ꂽ���Ӑ�̐����������߂��Ă��܂��B
    '''''        DELTRN = False
    '''''        Exit Function
    '''''    End If
    '    End If
    '
    '    '������z�`�F�b�N               '2007.02.09
    '    If DB_UDNTHA.FRNKB = "0" Then
    '        curCHECKKIN = DB_UDNTHA.SBANYUKN - 0
    '    Else
    '        curCHECKKIN = DB_UDNTHA.SBAFRNKN - 0
    '    End If
    '
    '    '���������z�c���擾
    '    Call GET_KESIZAN(RD_SSSMAIN_TOKCD(0), _
    ''                     DB_UDNTHA.FRNKB, _
    ''                     DB_UDNTHA.NYUCD, _
    ''                     RD_SSSMAIN_TUKKB(0), _
    ''                     curNYUKNZAN)
    '
    '    If curCHECKKIN > curNYUKNZAN Then
    '        Rtn = DSP_MsgBox(SSS_CONFRM, SSS_PrgId, 3)  '�u�ύX���z�������z�𒴂��Ă��܂��B�v
    '        DELTRN = False
    '        Exit Function
    '    End If
    '
    '    FR_SSSMAIN.Enabled = False
    '    For i = 0 To MAX_CNDARR - 1
    '        G_PlCnd.sCndStr(i) = String$(20, Chr$(Asc("A") + i))
    '        G_PlCnd.nCndNum(i) = i + 1
    '    Next i
    '
    '    G_PlCnd.sOpeID = SSS_OPEID
    '    G_PlCnd.sCltID = SSS_CLTID
    '
    '    '2007.02.28 �`�F�b�N�d�l�ύX
    '''''If (RD_SSSMAIN_SMADT(-1) > DB_SYSTBA.UKSMEDT) And _
    ''''''   (RD_SSSMAIN_SSADT(-1) > DB_TOKMTA.TOKSMEDT) Then  '����͐ԓ`���쐬
    '''''    G_PlCnd.sCndStr(0) = "1"        '�����x��
    '''''Else
    '''''    G_PlCnd.sCndStr(0) = "0"        '�O���x
    '''''End If
    '    If RD_SSSMAIN_SMADT(-1) > DB_SYSTBA.MONUPDDT Then   '����͐ԓ`���쐬
    '        G_PlCnd.sCndStr(0) = "1"        '�����x��
    '    Else
    '        G_PlCnd.sCndStr(0) = "0"        '�O���x
    '    End If
    '
    '    G_PlCnd.sCndStr(1) = RD_SSSMAIN_DATNO(-1)
    '    G_PlCnd.sCndStr(2) = RD_SSSMAIN_NYUDT(-1)
    '    G_PlCnd.sCndStr(3) = SSS_SMADT
    '    G_PlCnd.sCndStr(4) = SSS_SSADT
    '    G_PlCnd.sCndStr(5) = SSS_KESDT
    '
    '    G_PlInfo.FCnt = 2
    '    G_PlInfo.Fno(0) = DBN_UDNTRA
    '    G_PlInfo.RCnt(0) = 1
    '    G_PlInfo.ArrayFlg(0) = 1
    '    G_PlInfo.Fno(1) = DBN_UDNTHA
    '    G_PlInfo.RCnt(1) = 1
    '    G_PlInfo.ArrayFlg(1) = 0
    '
    '    DB_UDNTHA.UDNNO = RD_SSSMAIN_NDNNO(-1)
    '
    '    PlStat = DB_PlStart
    '    PlStat = DB_PlCndSet
    '    PlStat = DB_PlSet(DBN_UDNTHA, 0)
    '    PlStat = DB_PlSet(DBN_UDNTRA, 0)
    '
    '    Call DB_BeginTransaction(BTR_Exclude)
    '    PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_UDNTRA")
    '    If PlStat <> 0 And PlStat <> 1485 Then
    '        MsgBox "PL/SQL Error�F" & PlStat
    '        DELTRN = False
    '        Call DB_AbortTransaction
    '    Else
    '        DELTRN = True
    '        Call DB_EndTransaction
    '    End If
    '
    '    PlStat = DB_PlFree
    '
    '    FR_SSSMAIN.Enabled = True
    '
    'End Function

    Function WRTTRN() As Short
		'Dim i As Integer
		'Dim PlStat As Long
		'Dim wkTOKCD As String
		'
		'    '
		'    FR_SSSMAIN.Enabled = False
		'
		'    ' PL/SQL �Ή����Ұ� G_PlCnd.nJobMode �� SSSMAIN.ET1 �Őݒ肳���
		'
		'    If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
		'        MsgBox "�y" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "�z���N�����ł��B" & Trim(SSS_PrgNm) & "����͂��鎖�͂ł��܂���B", vbExclamation Or vbOKOnly, SSS_PrgNm
		'        WRTTRN = False
		'        PlStat = DB_PlFree
		'        FR_SSSMAIN.Enabled = True
		'        Exit Function
		'    Else
		'        Call SSSWIN_EXCTBZ_OPEN
		'    End If
		'
		'    For i = 0 To MAX_CNDARR - 1
		'        G_PlCnd.sCndStr(i) = String$(20, Chr$(Asc("A") + i))
		'        G_PlCnd.nCndNum(i) = i + 1
		'    Next i
		'
		'    G_PlCnd.sOpeID = SSS_OPEID
		'    G_PlCnd.sCltID = SSS_CLTID
		'    G_PlCnd.nCndNum(9) = -9999  'PL/SQL�ŃR�~�b�g���Ȃ�
		'
		'    G_PlInfo.FCnt = 2
		'    G_PlInfo.Fno(0) = DBN_UDNTRA
		'    G_PlInfo.RCnt(0) = PP_SSSMAIN.LastDe
		'    G_PlInfo.ArrayFlg(0) = 1
		'    G_PlInfo.Fno(1) = DBN_UDNTHA
		'    G_PlInfo.RCnt(1) = 1
		'    G_PlInfo.ArrayFlg(1) = 0
		'    '
		'    Call TOKMTA_RClear
		'    wkTOKCD = RD_SSSMAIN_TOKCD(-1) & Space(Len(DB_TOKMTA.TOKCD) - Len(RD_SSSMAIN_TOKCD(-1)))
		'    Call DB_GetEq(DBN_TOKMTA, 1, wkTOKCD, BtrNormal)
		'
		'    '2007.02.28 �`�F�b�N�d�l�ύX
		'''''If (RD_SSSMAIN_SMADT(-1) > DB_SYSTBA.UKSMEDT) And _
		''''''   (RD_SSSMAIN_SSADT(-1) > DB_TOKMTA.TOKSMEDT) Then
		'''''    G_PlCnd.sCndStr(0) = "1"                '�����x��
		'''''Else
		'''''    G_PlCnd.sCndStr(0) = "0"                '�O���x
		'''''End If
		'    If RD_SSSMAIN_SMADT(-1) > DB_SYSTBA.MONUPDDT Then
		'        G_PlCnd.sCndStr(0) = "1"                '�����x��
		'    Else
		'        G_PlCnd.sCndStr(0) = "0"                '�O���x
		'    End If
		'
		'    G_PlCnd.sCndStr(1) = RD_SSSMAIN_DATNO(-1)
		'    G_PlCnd.sCndStr(2) = RD_SSSMAIN_NYUDT(-1)
		'    G_PlCnd.sCndStr(3) = SSS_SMADT
		'    G_PlCnd.sCndStr(4) = SSS_SSADT
		'    G_PlCnd.sCndStr(5) = SSS_KESDT
		'
		'    Call UDNTHA_RClear
		'    Call UDNTHA_FromSCR(-1)
		'    DB_UDNTHA.AKAKROKB = "1"
		'    DB_UDNTHA.DATKB = "1"
		'    DB_UDNTHA.DENKB = WG_DENKB
		'    DB_UDNTHA.DENDT = DB_UNYMTA.UNYDT
		'    DB_UDNTHA.SMADT = SSS_SMADT
		'    DB_UDNTHA.SSADT = SSS_SSADT
		'    DB_UDNTHA.KESDT = SSS_KESDT
		'    DB_UDNTHA.UPFKB = "1"
		'    '
		'    PlStat = DB_PlStart
		'    PlStat = DB_PlCndSet
		'    PlStat = DB_PlSet(DBN_UDNTHA, 0)
		'    i = 0
		'    Do While i < PP_SSSMAIN.LastDe
		'        Call UDNTRA_RClear
		'        Call Mfil_FromSCR(i)
		'        DB_UDNTRA.AKAKROKB = "1"
		'        DB_UDNTRA.DATKB = "1"
		'        DB_UDNTRA.DENKB = WG_DENKB
		'        DB_UDNTRA.SMADT = SSS_SMADT
		'        DB_UDNTRA.SSADT = SSS_SSADT
		'        DB_UDNTRA.KESDT = SSS_KESDT
		'        DB_UDNTRA.DKBSB = WG_DKBSB
		'        PlStat = DB_PlSet(DBN_UDNTRA, i)
		'        i = i + 1
		'    Loop
		'
		'    Call DB_BeginTransaction(BTR_Exclude)
		'    PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_UDNTRA")
		'    If PlStat <> 0 And PlStat <> 1485 Then
		'        MsgBox "PL/SQL Error�F" & PlStat
		'        WRTTRN = False
		'        Call DB_AbortTransaction
		'    Else
		'        WRTTRN = True
		'        Call DB_EndTransaction
		'    End If
		'
		'    PlStat = DB_PlFree
		'
		'    FR_SSSMAIN.Enabled = True
		'
	End Function
End Module