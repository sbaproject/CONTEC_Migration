Option Strict Off
Option Explicit On
Module SYSTBA_M52
	'
	'�X���b�g��      :���C��̧�ٍX�V(�����X�V)�E���C���t�@�C���X�V�X���b�g
	'���j�b�g��      :SYSTBA.M31
	'�L�q��          :Standard Library
	'�쐬���t        :1997/01/28
	'
	Dim WM_CNT As Integer
	Dim WM_GCNT As Decimal
	
	Public WG_MONSMADT As String '�������|�i���|�j�c���ݒ��
	Public WG_MONSSADT As String '���������i�x���j�c���ݒ��
	Public WG_YERSMADT As String '�������|�i���|�j�c���ݒ��
	Public WG_YERSSADT As String '���������i�x���j�c���ݒ��
	Public WG_ZYERSMADT As String '�O�����|�i���|�j�c���ݒ��
	Public WG_ZYERSSADT As String '�O�������i�x���j�c���ݒ��
	Public WG_TRNDELDT As String '�g�����폜���
	Public WG_SUMDELDT As String '�T�}���폜���
	Public WG_ZENSMADT As String '�O�����|�i���|�j�c���ݒ��
	Public WG_YEREXCDT As String '�N���X�V���s�����
	Public WG_ZZYERSMADT As String '�O�O�����|�i���|�j�c���ݒ��
	Public WG_ZZYERSSADT As String '�O�O�������i�x���j�c���ݒ��
	
	
	Sub BATMAN()
		'
		Call BATMFIL()
	End Sub
	
	Sub BATMFIL()
		Dim i As Short
		Dim PlStat As Integer
		'
		If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
			MsgBox("�y" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "�z���N�����ł��B" & Trim(SSS_PrgNm) & "����͂��鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
			PlStat = DB_PlFree
			FR_SSSMAIN.Enabled = True
		Else
			Call SSSWIN_EXCTBZ_OPEN()
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CHKDATE() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CHKDATE() = False Then
			Exit Sub
		End If
		' �����ݒ�
		G_PlCnd.nJobMode = 0
		For i = 0 To MAX_CNDARR - 1
			G_PlCnd.sCndStr(i) = New String(Chr(Asc("A") + i), 20)
			G_PlCnd.nCndNum(i) = i + 1
		Next i
		G_PlCnd.sCndStr(0) = WG_MONSMADT
		G_PlCnd.sCndStr(1) = WG_MONSSADT
		G_PlCnd.sCndStr(2) = WG_YERSMADT
		G_PlCnd.sCndStr(3) = WG_YERSSADT
		G_PlCnd.sCndStr(4) = WG_ZYERSMADT
		G_PlCnd.sCndStr(5) = WG_ZYERSSADT
		G_PlCnd.sCndStr(6) = WG_TRNDELDT
		G_PlCnd.sCndStr(7) = WG_SUMDELDT
		G_PlCnd.sCndStr(8) = WG_ZENSMADT
		G_PlCnd.sOpeID = SSS_OPEID.Value
		G_PlCnd.sCltID = SSS_CLTID.Value
		'
		G_PlInfo.FCnt = 0
		'
		PlStat = DB_PlStart
		PlStat = DB_PlCndSet
		
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_SYSTBA")
		If PlStat <> 0 And PlStat <> 1485 Then
			MsgBox("PL/SQL Error�F" & PlStat)
			Call DB_AbortTransaction()
		Else
			Call DB_EndTransaction()
			'''' ADD 2009/05/18  FKS) T.Yamamoto    Start
			'�������[�f�[�^�쐬�t���O�쐬����
			Call funcWrtFlgFile()
			'''' ADD 2009/05/18  FKS) T.Yamamoto    End
			'''' ADD 2010/10/22  FKS) T.Yamamoto    Start    �A���[��824
			'�������|�I���t���O�폜����
			Call funcDelFlgFile()
			'''' ADD 2010/10/22  FKS) T.Yamamoto    End
		End If
		PlStat = DB_PlFree
	End Sub
	'===========================================================
	Function CHKDATE() As Object
		Dim SMAMM, SMAYY, SMADD As Integer
		Dim mm, yy, dd As Integer
		Dim W_dt As Integer
		Dim WL_WRKBUF As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g CHKDATE �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CHKDATE = True
		Dim W_YerEXCcc As Short '�N���X�V���s���ݸ�
		W_YerEXCcc = 6 '�N���X�V���s���ݸ�(6������A���s)
		
		WG_MONSMADT = "" '�������|�i���|�j�c���ݒ��
		WG_MONSSADT = "" '���������i�x���j�c���ݒ��
		WG_YERSMADT = "" '�������|�i���|�j�c���ݒ��
		WG_YERSSADT = "" '���������i�x���j�c���ݒ��
		WG_ZYERSMADT = "" '�O�����|�i���|�j�c���ݒ��
		WG_ZYERSSADT = "" '�O�������i�x���j�c���ݒ��
		WG_TRNDELDT = "" '�g�����폜���
		WG_SUMDELDT = "" '�T�}���폜���
		WG_ZENSMADT = "" '�O���������|�i���|�j�c���ݒ��
		WG_YEREXCDT = "" '�N���X�V���s�����
		WG_ZZYERSMADT = "" '�O�O�����|�i���|�j�c���ݒ��
		WG_ZZYERSSADT = "" '�O�O�������i�x���j�c���ݒ��
		
		
		'
		' ���������Z�b�g
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MONUPDYM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WG_MONUPDYM = RD_SSSMAIN_MONUPDYM(0)
		SSS_SMADT.Value = VB6.Format(Get_TouAcedt(CShort(LeftWid(WG_MONUPDYM, 4)), CShort(MidWid(WG_MONUPDYM, 5, 2))), "YYYYMMDD")
		SMAYY = CInt(LeftWid(SSS_SMADT.Value, 4))
		SMAMM = CInt(MidWid(SSS_SMADT.Value, 5, 2))
		SMADD = CInt(MidWid(SSS_SMADT.Value, 7, 2))
		'
		' �������|�i���|�j�c���ݒ��
		WG_MONSMADT = SSS_SMADT.Value
		If WG_MONSMADT <= DB_SYSTBA.MONUPDDT Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CHKDATE �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CHKDATE = False
			Exit Function
		End If
		'
		' ���������i�x���j�c���ݒ��
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MONUPDYM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WG_MONUPDYM = RD_SSSMAIN_MONUPDYM(0)
		SSS_SMADT.Value = VB6.Format(Get_TouAcedt(CShort(LeftWid(WG_MONUPDYM, 4)), CShort(MidWid(WG_MONUPDYM, 5, 2))), "YYYYMMDD")
		SMAYY = CInt(LeftWid(SSS_SMADT.Value, 4))
		SMAMM = CInt(MidWid(SSS_SMADT.Value, 5, 2))
		SMADD = CInt(MidWid(SSS_SMADT.Value, 7, 2))
		If SMADD > CDbl("27") Then
			WG_MONSSADT = VB6.Format(DateSerial(SMAYY, SMAMM, 0), "YYYYMMDD")
		Else
			WG_MONSSADT = VB6.Format(DateSerial(SMAYY, SMAMM - 1, SMADD), "YYYYMMDD")
		End If
		'
		' �������|�i���|�j�c���ݒ��
		SSS_SMADT.Value = VB6.Format(Get_BGNAcedt(CShort(LeftWid(WG_MONUPDYM, 4)), CShort(MidWid(WG_MONUPDYM, 5, 2))), "YYYYMMDD")
		SMAYY = CInt(LeftWid(SSS_SMADT.Value, 4))
		SMAMM = CInt(MidWid(SSS_SMADT.Value, 5, 2))
		SMADD = CInt(MidWid(SSS_SMADT.Value, 7, 2))
		If DB_SYSTBA.SMADD > "27" Then
			WG_YERSMADT = VB6.Format(DateSerial(SMAYY, SMAMM + 12, SMADD - 1), "YYYYMMDD")
			WG_ZYERSMADT = VB6.Format(DateSerial(SMAYY, SMAMM, SMADD - 1), "YYYYMMDD")
			WG_ZZYERSMADT = VB6.Format(DateSerial(SMAYY, SMAMM - 12, SMADD - 1), "YYYYMMDD")
		Else
			WG_YERSMADT = VB6.Format(DateSerial(SMAYY, SMAMM + 12, SMADD - 1), "YYYYMMDD")
			WG_ZYERSMADT = VB6.Format(DateSerial(SMAYY, SMAMM, SMADD - 1), "YYYYMMDD")
			WG_ZZYERSMADT = VB6.Format(DateSerial(SMAYY, SMAMM - 12, SMADD - 1), "YYYYMMDD")
		End If
		'
		' ���������i�x���j�c���ݒ��
		SSS_SMADT.Value = VB6.Format(Get_BGNAcedt(CShort(LeftWid(WG_MONUPDYM, 4)), CShort(MidWid(WG_MONUPDYM, 5, 2))), "YYYYMMDD")
		SMAYY = CInt(LeftWid(SSS_SMADT.Value, 4))
		SMAMM = CInt(MidWid(SSS_SMADT.Value, 5, 2))
		SMADD = CInt(MidWid(SSS_SMADT.Value, 7, 2))
		If DB_SYSTBA.SMADD > "27" Then
			WG_YERSSADT = VB6.Format(DateSerial(SMAYY, SMAMM + 11, 0), "YYYYMMDD")
			WG_ZYERSSADT = VB6.Format(DateSerial(SMAYY, SMAMM - 1, 0), "YYYYMMDD")
			WG_ZZYERSSADT = VB6.Format(DateSerial(SMAYY, SMAMM - 13, 0), "YYYYMMDD")
		Else
			WG_YERSSADT = VB6.Format(DateSerial(SMAYY, SMAMM + 11, SMADD - 1), "YYYYMMDD")
			WG_ZYERSSADT = VB6.Format(DateSerial(SMAYY, SMAMM - 1, SMADD - 1), "YYYYMMDD")
			WG_ZZYERSSADT = VB6.Format(DateSerial(SMAYY, SMAMM - 13, SMADD - 1), "YYYYMMDD")
		End If
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(MidWid(WG_MONSMADT, 5, 2)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WG_YEREXCDT = CStr(DateSerial(SSSVal(LeftWid(WG_MONSMADT, 4)), SSSVal(MidWid(WG_MONSMADT, 5, 2)) - W_YerEXCcc, 1))
		WG_YEREXCDT = Get_TouAcedt(CShort(LeftWid(WG_YEREXCDT, 4)), CShort(MidWid(WG_YEREXCDT, 6, 2)))
		
		WG_YEREXCDT = DeCNV_DATE(WG_YEREXCDT)
		
		'
		If WG_ZYERSMADT > WG_YEREXCDT Then
			If WG_ZZYERSMADT <= DB_SYSTBA.YERUPDDT Then
				WG_YERSMADT = ""
			Else
				WG_YERSMADT = WG_ZZYERSMADT
				WG_YERSSADT = WG_ZZYERSSADT
				'�N���X�V���s
			End If
		ElseIf WG_ZYERSMADT < WG_YEREXCDT Then 
			If WG_ZYERSMADT <= DB_SYSTBA.YERUPDDT Then
				WG_YERSMADT = ""
			Else
				WG_YERSMADT = WG_ZYERSMADT
				WG_YERSSADT = WG_ZYERSSADT
				'�N���X�V���s
			End If
		Else
			WG_YERSMADT = WG_ZYERSMADT
			WG_YERSSADT = WG_ZYERSSADT
			'�N���X�V���s
		End If
		'
		'�g�����폜���
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MONUPDYM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WG_MONUPDYM = RD_SSSMAIN_MONUPDYM(0)
		SSS_SMADT.Value = VB6.Format(Get_TouAcedt(CShort(LeftWid(WG_MONUPDYM, 4)), CShort(MidWid(WG_MONUPDYM, 5, 2))), "YYYYMMDD")
		SMAYY = CInt(LeftWid(SSS_SMADT.Value, 4))
		SMAMM = CInt(MidWid(SSS_SMADT.Value, 5, 2))
		SMADD = CInt(MidWid(SSS_SMADT.Value, 7, 2))
		If SMADD > CDbl("27") Then
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WG_TRNDELDT = VB6.Format(DateSerial(SMAYY, SMAMM - SSSVal(DB_SYSTBA.MONUPDSC), 0), "YYYYMMDD")
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WG_TRNDELDT = VB6.Format(DateSerial(SMAYY, SMAMM - SSSVal(DB_SYSTBA.MONUPDSC) - 1, SMADD), "YYYYMMDD")
		End If
		'
		' �T�}���폜���
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MONUPDYM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WG_MONUPDYM = RD_SSSMAIN_MONUPDYM(0)
		SSS_SMADT.Value = VB6.Format(Get_TouAcedt(CShort(LeftWid(WG_MONUPDYM, 4)), CShort(MidWid(WG_MONUPDYM, 5, 2))), "YYYYMMDD")
		SMAYY = CInt(LeftWid(SSS_SMADT.Value, 4))
		SMAMM = CInt(MidWid(SSS_SMADT.Value, 5, 2))
		SMADD = CInt(MidWid(SSS_SMADT.Value, 7, 2))
		If SMADD > CDbl("27") Then
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WG_SUMDELDT = VB6.Format(DateSerial(SMAYY, SMAMM - SSSVal(DB_SYSTBA.YERUPDSC), 0), "YYYYMMDD")
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WG_SUMDELDT = VB6.Format(DateSerial(SMAYY, SMAMM - SSSVal(DB_SYSTBA.YERUPDSC) - 1, SMADD), "YYYYMMDD")
		End If
		'�O���O���������|�i���|�j�c���ݒ��
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(MidWid(SSS_SMADT, 5, 2)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WG_ZENSMADT = CStr(DateSerial(SSSVal(LeftWid(SSS_SMADT.Value, 4)), SSSVal(MidWid(SSS_SMADT.Value, 5, 2)) - 1, 1))
		WG_ZENSMADT = Get_TouAcedt(CShort(LeftWid(WG_ZENSMADT, 4)), CShort(MidWid(WG_ZENSMADT, 6, 2)))
		WG_ZENSMADT = DeCNV_DATE(WG_ZENSMADT)
		
	End Function
	
	'''' ADD 2009/05/18  FKS) T.Yamamoto    Start
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub funcWrtFlgFile
	'   �T�v�F  �������[�f�[�^�쐬�t���O�쐬�i�㏑���j����
	'   �����F  �Ȃ�
	'   �ߒl�F  True : ����     False : �ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub funcWrtFlgFile()
		
		Dim intFileNo As Short
		Dim strFilePath As String
		
		On Error GoTo Err_Run
		
		intFileNo = FreeFile
		strFilePath = GP_GetIni(AE_AppPath & "ENDFP51.ini", "FILEPATH", "FILE")
		
		'''' UPD 2009/07/01  FKS) T.Yamamoto    Start
		'    Open strFilePath For Output As #intFileNo
		'    Close #intFileNo
		If strFilePath = "" Then
			MsgBox("INI�t�@�C���̓Ǎ��Ɏ��s���܂����B" & vbCrLf & "[" & AE_AppPath & "ENDFP51.ini]", MsgBoxStyle.Critical, "INI�t�@�C���Ǎ��G���[")
			Exit Sub
		Else
			FileOpen(intFileNo, strFilePath, OpenMode.Output)
			FileClose(intFileNo)
		End If
		
		MsgBox("�������[�f�[�^�쐬�t���O���쐬���܂����B" & vbCrLf & "[" & strFilePath & "]", MB_OK, Trim(SSS_PrgNm))
		'''' UPD 2009/07/01  FKS) T.Yamamoto    End
		
		Exit Sub
		
Err_Run: 
		
		'''' ADD 2009/07/01  FKS) T.Yamamoto    Start
		MsgBox("�������[�f�[�^�쐬�t���O�̍쐬�Ɏ��s���܂����B" & vbCrLf & "[" & strFilePath & "]", MsgBoxStyle.Critical, "�t���O�t�@�C���쐬�G���[")
		'''' ADD 2009/07/01  FKS) T.Yamamoto    End
		
	End Sub

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
    '2019/10/31 ADD START
    Function AnsiLeftB(ByVal StrArg As String, ByVal arg1 As Integer) As String
        'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: LeftB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g AnsiStrConv() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/06/12 CHG START
        'AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
        AnsiLeftB = LeftB(StrArg, arg1)
        '2019/06/12 CHG END
    End Function
    '2019/10/31 ADD E N D
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
		
		Dim strWk As String
		Dim strDummy As String
		Dim lngInstr As Integer
		Dim lngInstrRev As Integer
		
		lngInstr = 0

        '�C�j�t�@�C����";"�ȍ~�̓R�����g�Ȃ̂ŁA�R�����g���Ȃ��B
        'UPGRADE_ISSUE: InStrB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/10/31 CHG START
        'lngInstr = InStrB(strData, ";")
        lngInstr = InStr(strData, ";")
        '2019/10/31 CHG E N D
        If lngInstr <> 0 Then
            'UPGRADE_ISSUE: InStrB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
            'UPGRADE_ISSUE: MidB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
            'strWk = MidB(strData, 1, InStrB(strData, ";") - 1)
            strWk = MidB(strData, 1, InStr(strData, ";") - 1)
        Else
			strWk = strData
		End If
		
		lngInstr = 0
		lngInstrRev = 0
		
		'strWK=""�y�сAstrWK=""""�̏ꍇ�̓R�����g�s�B
		If strWk <> "" And strWk <> """" Then
			'�V���O���R�[�e�[�V�����ň͂񂾒��̕����̂ݎ擾�������̂ŁA
			'�V���O���R�[�e�[�V�����̕����ʒu���擾����B
			lngInstr = InStr(strWk, """")
			lngInstrRev = InStrRev(strWk, """")
			'strWk�̒��ɃV���O���R�[�e�[�V�������܂܂�Ă��邩���f����B
			If lngInstr <> lngInstrRev Then
				'�V���O���R�[�e�[�V�������܂܂�Ă����ꍇ�B
				'�V���O���R�[�e�[�V�����ň͂񂾒��̕����̂ݎ擾����B
				strDummy = Mid(strWk, lngInstr + 1, lngInstrRev - lngInstr - 1)
				
				If strDummy <> "" Then
					'�߂�l�̃Z�b�g�B
					P_GetIniItem = Trim(strDummy)
				End If
			Else
				'�V���O���R�[�e�[�V�������܂܂�Ă��Ȃ��ꍇ�B
				If Trim(strWk) <> "" Then
					'�߂�l�̃Z�b�g
					P_GetIniItem = Trim(strWk)
				End If
			End If
		Else
			P_GetIniItem = ""
		End If
		
	End Function
    '2019/10/31 DEL START
    '   Function AnsiLeftB(ByVal StrArg As String, ByVal arg1 As Integer) As String
    '	'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '	'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '	'UPGRADE_ISSUE: LeftB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '	'UPGRADE_WARNING: �I�u�W�F�N�g AnsiStrConv() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
    'End Function
    '2019/10/31 DEL E N D
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
	'''' ADD 2009/05/18  FKS) T.Yamamoto    End
	
	'''' ADD 2010/10/22  FKS) T.Yamamoto    Start    �A���[��824
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub funcDelFlgFile
	'   �T�v�F  �������|�I���t���O�폜����
	'   �����F  �Ȃ�
	'   �ߒl�F  True : ����     False : �ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub funcDelFlgFile()
		
		Dim intFileNo As Short
		Dim strFilePath As String
		
		On Error GoTo Err_Run
		
		intFileNo = FreeFile
		strFilePath = GP_GetIni(AE_AppPath & "ENDFP51.ini", "FILEPATH2", "FILE")
		
		If strFilePath = "" Then
			MsgBox("INI�t�@�C���̓Ǎ��Ɏ��s���܂����B" & vbCrLf & "[" & AE_AppPath & "ENDFP51.ini]", MsgBoxStyle.Critical, "INI�t�@�C���Ǎ��G���[")
			Exit Sub
		Else
			'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			If Dir(strFilePath) <> "" Then
				Kill((strFilePath))
			End If
		End If
		
		MsgBox("�������|�I���t���O���폜���܂����B" & vbCrLf & "[" & strFilePath & "]", MB_OK, Trim(SSS_PrgNm))
		
		Exit Sub
		
Err_Run: 
		
		MsgBox("�������|�I���t���O�̍폜�Ɏ��s���܂����B" & vbCrLf & "[" & strFilePath & "]", MsgBoxStyle.Critical, "�t���O�t�@�C���폜�G���[")
		
	End Sub
	'''' ADD 2010/10/22  FKS) T.Yamamoto    End
End Module