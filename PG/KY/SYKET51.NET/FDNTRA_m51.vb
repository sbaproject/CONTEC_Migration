Option Strict Off
Option Explicit On
Module FDNTRA_M51
    '
    ' �X���b�g��        : �o�׎w���g�����E���C���t�@�C���X�V�X���b�g(PL/SQL�Ή�)
    ' ���j�b�g��        : FDNTRA.M51
    ' �L�q��            : Standard Library
    ' �쐬���t          : 2006/07/15
    ' �g�p�v���O������  : SYKET51
    '
    '2019/10/28 DEL START
    'Function DELTRN() As Short
    'End Function
    '2019/10/28 DEL E N D
    '2019/10/28 DEL START
    'Function WRTTRN() As Short
    '    Dim I As Short
    '    Dim PlStat As Integer
    '    Dim EXEPATH As String

    '    Dim FILE1_PATH As String
    '    Dim lngFileNo1 As Integer

    '    '
    '    FR_SSSMAIN.Enabled = False

    '    If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
    '        MsgBox("�y" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "�z���N�����ł��B" & Trim(SSS_PrgNm) & "����͂��鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
    '        WRTTRN = False
    '        PlStat = DB_PlFree
    '        FR_SSSMAIN.Enabled = True
    '        Exit Function
    '    Else
    '        Call SSSWIN_EXCTBZ_OPEN()
    '    End If

    '    ' PL/SQL �Ή����Ұ� G_PlCnd.nJobMode �� SSSMAIN.ET1 �Őݒ肳���

    '    G_PlCnd.nJobMode = 0
    '    For I = 0 To MAX_CNDARR - 1
    '        G_PlCnd.sCndStr(I) = New String(Chr(Asc("A") + I), 20)
    '        G_PlCnd.nCndNum(I) = I + 1
    '    Next I

    '    G_PlCnd.sOpeID = SSS_OPEID.Value
    '    G_PlCnd.sCltID = SSS_CLTID.Value
    '    '2008/05/19 FKS)HONDA ADD START
    '    G_PlCnd2.sErrMsg = ""
    '    '2008/05/19 FKS)HONDA ADD END

    '    G_PlInfo.FCnt = 2
    '    G_PlInfo.Fno(1) = DBN_FDNTHA
    '    G_PlInfo.RCnt(1) = 1
    '    G_PlInfo.ArrayFlg(1) = 0
    '    G_PlInfo.Fno(0) = DBN_FDNTRA
    '    G_PlInfo.RCnt(0) = PP_SSSMAIN.LastDe
    '    G_PlInfo.ArrayFlg(0) = 1
    '    '
    '    'Call FDNTHA_RClear()
    '    Call FDNTHA_FromSCR(-1)
    '    '
    '    PlStat = DB_PlStart
    '    PlStat = DB_PlCndSet
    '    PlStat = DB_PlSet(DBN_FDNTHA, 0)
    '    I = 0
    '    Do While I < PP_SSSMAIN.LastDe
    '        Call FDNTRA_RClear()
    '        Call Mfil_FromSCR(I)
    '        PlStat = DB_PlSet(DBN_FDNTRA, I)
    '        I = I + 1
    '    Loop

    '    Call DB_BeginTransaction(CStr(BTR_Exclude))
    '    PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_FDNTRA")
    '    If PlStat <> 0 And PlStat <> 1485 Then
    '        MsgBox("PL/SQL Error�F" & PlStat)
    '        WRTTRN = False
    '        Call DB_AbortTransaction()
    '    Else
    '        '2008/06/24 START ADD FKS)HAYASHI �A���[���FFC08062403
    '        If Trim(G_PlCnd2.sErrMsg) <> "" Then
    '            'PL/SQL�ɂăf�[�^�ύX�ɂ�鏈���X�L�b�v���L��
    '            MsgBox(Trim(G_PlCnd2.sErrMsg))
    '            Call DB_AbortTransaction()
    '            PlStat = DB_PlFree
    '            Exit Function
    '        End If
    '        '2008/06/24 E.N.D ADD FKS)HAYASHI �A���[���FFC08062403
    '        WRTTRN = True
    '        Call DB_EndTransaction()
    '        '2008/05/19 FKS)HONDA ADD START
    '        '2008/06/24 START DEL FKS)HAYASHI �A���[���FFC08062403
    '        '''    If Trim(G_PlCnd2.sErrMsg) <> 0 Then
    '        '''        'PL/SQL�ɂăf�[�^�ύX�ɂ�鏈���X�L�b�v���L��
    '        '''        MsgBox Trim(G_PlCnd2.sErrMsg)
    '        '''    End If
    '        '2008/06/24 E.N.D DEL FKS)HAYASHI �A���[���FFC08062403
    '        '2008/05/19 FKS)HONDA ADD END

    '    End If

    '    PlStat = DB_PlFree

    '    FR_SSSMAIN.Enabled = True

    '    '�o�ɗ\��t�@�C���̍폜
    '    ''''Call DB_GetGrEq(DBN_SYKTRA, 3, SSS_CLTID & SSS_PrgId, BtrNormal)
    '    ''''Do While (DBSTAT = 0) And (Trim$(DB_SYKTRA.CLTID) = Trim$(SSS_CLTID)) _
    '    '''''                      And (Trim$(DB_SYKTRA.PGID) = Trim$(SSS_PrgId))
    '    ''''    Call DB_Delete(DBN_SYKTRA)
    '    ''''    Call DB_GetNext(DBN_SYKTRA, BtrNormal)
    '    ''''Loop


    '    '�o�ɗ\��t�@�C���쐬���s
    '    EXEPATH = AE_AppPath & "\SYKFP70.EXE /CLTID:" & SSS_CLTID.Value & " /PGID:" & SSS_PrgId & " /PGNM:" & SSS_PrgNm
    '    I = VBEXEC1(FR_SSSMAIN.Handle.ToInt32, 1, EXEPATH)

    '    'INI�t�@�C���擾�p�֐�
    '    FILE1_PATH = GP_GetIni(AE_AppPath & "SYKFP51.ini", "FILEPATH", "FILE1")
    '    lngFileNo1 = FreeFile
    '    FileOpen(lngFileNo1, FILE1_PATH, OpenMode.Output)
    '    FileClose(lngFileNo1)

    'End Function
    '2019/10/28 DEL E N D

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
        '2019/10/28 CHG START
        'lngInstr = InStrB(strData, ";")
        lngInstr = InStr(strData, ";")
        '2019/10/28 CHG START
        If lngInstr <> 0 Then
            'UPGRADE_ISSUE: InStrB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
            'UPGRADE_ISSUE: MidB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
            '2019/10/28 CHG START
            'strWK = MidB(strData, 1, InStrB(strData, ";") - 1)
            strWK = MidB(strData, 1, InStr(strData, ";") - 1)
            '2019/10/28 CHG E N D
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
        '2019/10/28 CHG START
        'AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
        AnsiLeftB = LeftB(StrArg, arg1)
        '2019/10/28 CHG E N D
    End Function
	
	Function AnsiLenB(ByVal StrArg As String) As Integer
        '�T�v�F����������
        '�����FStrArg,Input,String,�Ώە�����
        '�����FAnsi���ނ��޲ĵ��ނŕ�������޲Đ���Ԃ�
#If Win32 Then
        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/10/28 CHG START
        'AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
        AnsiLenB = LenB(StrArg)
        '2019/10/28 CHG E N D
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