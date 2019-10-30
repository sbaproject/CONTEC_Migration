Option Strict Off
Option Explicit On
Module SSSMAIN_PR2
	
	
	'
	''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	'for �m�����q�q�q �u�`�O�R                                                             '
	'                                                                             --2001.10 '
	''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	Sub CNT_GAUGE()
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!GAUGE.ForeColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CType(FR_SSSMAIN.Controls("GAUGE"), Object).ForeColor = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_WHITE)
		'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!GAUGE.FloodPercent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CType(FR_SSSMAIN.Controls("GAUGE"), Object).FloodPercent = 100
		System.Windows.Forms.Application.DoEvents()
	End Sub
	
	Function FSTART_GetEvent() As Short
		'
		'#Start/2002.1.23
		If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
			Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
		End If
		Call AE_RecalcAll_SSSMAIN()
		If AE_CompleteCheck_SSSMAIN(0) <> 0 Then
			Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
			PP_SSSMAIN.CursorSet = True
			FSTART_GetEvent = False
			Exit Function
		End If
		'#End/2002.1.23
		SSS_Makkb = SSS_FILE
		If SSS_ExportFLG Then
			Call SSS_Export()
		Else
			Call SSS_LIST(SSS_FILE)
		End If
	End Function
	
	Function LCANCEL_GetEvent() As Object
		SSS_LSTOP = True
		'UPGRADE_WARNING: �I�u�W�F�N�g LCANCEL_GetEvent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		LCANCEL_GetEvent = True
	End Function
	
	Function LCONFIG_GetEvent() As Short
		' �v�����^�[�ݒ�
		LCONFIG_GetEvent = True
		WLS_PRN.ShowDialog()
	End Function
	
	Function LSTART_GetEvent() As Short
		'#Start/2001.11.28
		If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
			Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
		End If
		Call AE_RecalcAll_SSSMAIN()
		If AE_CompleteCheck_SSSMAIN(0) <> 0 Then
			Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
			PP_SSSMAIN.CursorSet = True
			LSTART_GetEvent = False
			Exit Function
		End If
		'#End/2001.11.28
		LSTART_GetEvent = True
		SSS_Makkb = SSS_PRINTER
		Call SSS_LIST(SSS_PRINTER)
	End Function
	
	Function MNSTART_GetEvent() As Short
		MNSTART_GetEvent = True
		Call INQ_LIST()
	End Function
	
	Sub SSS_CLOSE()
		'
		Call CRW_CLOSE()
		Call CRW_END()
		'
		Call DB_RESET()
		Call DB_End()
		'
		System.Windows.Forms.Application.DoEvents()
		'
		On Error Resume Next
	End Sub
	
	Sub SSS_Export()
		Dim Rtn As Short
		Dim wkRptId As String
		'
		Call WORKING_VIEW(True)
		' �N���X�^�����|�[�g�̃I�[�v��
		If CRW_INIT() = False Then
			Call Error_Exit("ERROR CRW_INIT")
		Else
			'�`�[��ʂɂ��RPT�t�@�C���̑I��(�I�v�V�������j�b�g�Ȃǂ�SYSTBI��ǂ�ł���)
			If Trim(SSS_RPTID) = "" Then
				wkRptId = SSS_PrgId
			Else
				wkRptId = SSS_RPTID
			End If
			If CRW_OPEN(SSS_INIDAT(2) & "RPT\" & wkRptId & ".RPT") = False Then
				Call Error_Exit("ERROR CRW_OPEN")
			End If
		End If
		
		'�o�͏�Ԃ̃`�F�b�N�̂��߂̋敪���N���A
		SSS_OUTKB = 0
		
		'
		Call Set_Value()
		'
		If CRW_DOCHECK() = False Then
			MsgBox("���Ŏ��s���ׁ̈A���s�ł��܂���B", MB_ICONEXCLAMATION)
			'
			Call CRW_CLOSE()
			'
			Call WORKING_VIEW(False)
			Exit Sub
		End If
		'
		SSS_LSTOP = False
		SSS_MFILCNT = 0
		SSS_LFILCNT = 0
		'
		If SSS_ExportFileKB Then GoTo Next_Proc
		'
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.AppStarting '���ƍ����v��\��
		
		Call Loop_Mfil()
		'
		' �L�����Z������
		If SSS_LSTOP = True Then
			Call WORKING_VIEW(False)
			'
			Call CRW_CLOSE()
			'
			Exit Sub
		End If
        '
        '�Q�Ɛ��؂�ւ���
        'Rtn = Crw_ChgLoc
        If Rtn = 0 Then
			MsgBox("CRW_PRINT.CRW_STATUS : " & Rtn & Chr(13) & CRW_GETERRMSG(HCRW))
			Exit Sub
		End If
		
		If SSS_LFILCNT = 0 Then
			'���b�Z�[�W�i�[�ϐ��ɕ����������Ă���΂����\���B
			If Trim(SSS_Message) <> "" Then
				Call MsgBox(SSS_Message, MsgBoxStyle.Information)
				Call WORKING_VIEW(False)
				Call CRW_CLOSE()
				Exit Sub
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				Call WORKING_VIEW(False)
				Call CRW_CLOSE()
				Exit Sub
			End If
		Else
			'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor '�����v
			Call WORKING_VIEW(False)
			If Rtn = False Then
				Error_Exit(("ERROR SSS_LIST �o�͐�I�� RTN=[" & Str(Rtn) & "]"))
			Else
				On Error Resume Next
				Kill(SSS_CRWOPATH & SSS_PrgId & ".TXT")
				On Error GoTo 0
				FR_SSSMAIN.Enabled = False
				System.Windows.Forms.Application.DoEvents()
				Rtn = PEDiscardSavedData(HCRW)
				If SSS_ExportFileName = vbNullString Then SSS_ExportFileName = SSS_PrgId '(1998/11/19 �ǉ��j
				If reportExportX(HCRW, SSS_CRWOPATH & SSS_ExportFileName & "." & SSS_ExportFileEXT & Chr(0), SSS_ExportFileType, 0, SSS_ExportSep & Chr(0), SSS_ExportQuat & Chr(0)) <> 1 Then
					Rtn = DSP_MsgBox(SSS_ERROR, "CANTDELFILE", 0)
					Call WORKING_VIEW(False)
					Error_Exit(("ERROR SSS_LIST CRW_PRINT"))
				End If
				
				'�o�͏�Ԃ̃`�F�b�N�̂��߂̋敪���Z�b�g
				SSS_OUTKB = SSS_FILE
				'
			End If
			Call WORKING_VIEW(False)
			'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor '�����v
			Do While CRW_VIEWCHECK()
                '2019/10/23 CHG START
                'Call Sleep(200)
                Call System.Threading.Thread.Sleep(200)
                '2019/10/23 CHG E N D
                System.Windows.Forms.Application.DoEvents()
			Loop 
			FR_SSSMAIN.Enabled = True
			System.Windows.Forms.Application.DoEvents()
			
		End If
		'
Next_Proc: 
		Call WORKING_VIEW(False)
		''
		If SSS_DYNASQL Then
			'PR2�n���[�Ń_�C�i�~�b�N��SQL�����g���ꍇ
			Call DB_Execute(SSS_LSTMFIL, "DROP TABLE " & Get_DBHEAD() & "_" & Trim(DB_PARA(SSS_LSTMFIL).DBID) & "." & SSS_PrgId & "_" & SSS_CLTID.Value)
		End If
		''
		Call CRW_CLOSE()
		Call Chain_Proc()
	End Sub
	
	Sub SSS_LIST(ByRef LSTKB As Short)
		Dim Rtn As Short
		Dim wkRptId As String
		Dim wkWindowOption As T_PEWindowOptions
		Dim wkPrintOption As T_PEPrintOptions
		Dim wkWidth, wkTop, wkLeft, wkHeight As Short
		Dim wkStr As New VB6.FixedLengthString(128)
		'Dim StartTime, PointTime, Time1, Time2, Time3      '�v���p
		'Dim msg1$                                          '�v���p
		
		'�o�͏������ɍēx�o�͏������ĂԂƃG���[�ɂȂ邽�߃{�^�����\���ɂ���
		CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = False
		CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = False
		CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
		'StartTime = Timer
		'PointTime = Timer
		Call WORKING_VIEW(True)
		' �N���X�^�����|�[�g�̃I�[�v��
		If CRW_INIT() = False Then
			Call Error_Exit("ERROR CRW_INIT")
		Else
			'�`�[��ʂɂ��RPT�t�@�C���̑I��(�I�v�V�������j�b�g�Ȃǂ�SYSTBI��ǂ�ł���)
			If Trim(SSS_RPTID) = "" Then
				wkRptId = SSS_PrgId
			Else
				wkRptId = SSS_RPTID
			End If
			If CRW_OPEN(SSS_INIDAT(2) & "RPT\" & wkRptId & ".RPT") = False Then
				Call Error_Exit("ERROR CRW_OPEN")
			End If
		End If
		
		'�o�͏�Ԃ̃`�F�b�N�̂��߂̋敪���N���A
		SSS_OUTKB = 0
		'
		Call Set_Value()
		'
		If CRW_DOCHECK() = False Then
			MsgBox("���ň�����ׁ̈A���s�ł��܂���B", MB_ICONEXCLAMATION)
			'
			'�o�͏������ɍēx�o�͏������ĂԂƃG���[�ɂȂ邽�ߔ�\���ɂ��Ă����{�^����\���ɂ���
			'CHG START FKS)INABA 2006/11/15******************************************************************
			'��Ɏ擾���������ɂ��APreview��ʂ̈���{�^���A�v�����^�ݒ�{�^���A�t�@�C���o�̓{�^���𐧌䂷��
			If gs_PRTAUTH = "1" Then '��������L��
				CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = True
				CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			Else
				CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = False
				CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			End If
			If gs_FILEAUTH = "1" Then '�t�@�C���o�͌����L��
				CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
				CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = True
			Else
				CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
				CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
			End If
			'        FR_SSSMAIN!CM_LSTART.Visible = True
			'        FR_SSSMAIN!CM_VSTART.Visible = True
			'        FR_SSSMAIN!CM_FSTART.Visible = True
			
			'CHG  END  FKS)INABA 2006/11/15******************************************************************
			Call CRW_CLOSE()
			'
			Call WORKING_VIEW(False)
			Exit Sub
		End If
		SSS_LSTOP = False
		SSS_MFILCNT = 0
		SSS_LFILCNT = 0
		'
		'Debug.Print "    ����f�[�^�� SQL �ւ̏o�͂��J�n����܂ł̎���:" & Str$(Timer - PointTime)
		'Time1 = Timer - PointTime
		'PointTime = Timer
		Call Loop_Mfil()
		
		'Debug.Print "    ����f�[�^�� SQL �ɏo�͂���̂ɗv��������" & chr(9) & ": " & Str$(Timer - PointTime)
		'Time2 = Timer - PointTime
		'PointTime = Timer
		'�L�����Z������
		If SSS_LSTOP = True Then
			Call WORKING_VIEW(False)
			'
			'�o�͏������ɍēx�o�͏������ĂԂƃG���[�ɂȂ邽�ߔ�\���ɂ��Ă����{�^����\���ɂ���
			'CHG START FKS)INABA 2006/11/15******************************************************************
			'��Ɏ擾���������ɂ��APreview��ʂ̈���{�^���A�v�����^�ݒ�{�^���A�t�@�C���o�̓{�^���𐧌䂷��
			If gs_PRTAUTH = "1" Then '��������L��
				CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = True
				CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			Else
				CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = False
				CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			End If
			If gs_FILEAUTH = "1" Then '�t�@�C���o�͌����L��
				CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
				CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = True
			Else
				CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
				CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
			End If
			'        FR_SSSMAIN!CM_LSTART.Visible = True
			'        FR_SSSMAIN!CM_VSTART.Visible = True
			'        FR_SSSMAIN!CM_FSTART.Visible = True
			
			'CHG  END  FKS)INABA 2006/11/15******************************************************************
			Call CRW_CLOSE()
			'
			Exit Sub
		End If
		'
		If SSS_LFILCNT = 0 Then
			'���b�Z�[�W�i�[�ϐ��ɕ����������Ă���΂����\���B
			If Trim(SSS_Message) <> "" Then
				Call MsgBox(SSS_Message, MsgBoxStyle.Information)
				Call WORKING_VIEW(False)
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				Call WORKING_VIEW(False)
			End If
		Else
			'�_�C�A���O�ɂ��v�����^�ؑւ������ꂽ���̂��Đݒ肷��B
			'��p���[�̏ꍇ�N���X�^�����|�[�g�̃��[�U�[��`��D�悷��B
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If IsDbNull(SSS_Lconfig) Then SSS_Lconfig = ""
            'If SSS_Lconfig <> "USR" Then Call CRW_SET_PRINTER()
            Select Case LSTKB
				Case SSS_PRINTER
					
					Rtn = CRW_PUTPRINTER()
					'��������̎w��
					wkPrintOption.StructSize = PE_SIZEOF_PRINT_OPTIONS
					Rtn = PEGetPrintOptions(HCRW, wkPrintOption)
					wkPrintOption.StartPageN = SSS_StartPageNo
					wkPrintOption.stopPageN = SSS_StopPageNo
					wkPrintOption.nReportCopies = SSS_Copies
					If SSS_Copies > 1 Then
						wkPrintOption.collation = IIf((SSS_Collation = 1), PE_COLLATED, PE_UNCOLLATED)
					End If
					Rtn = PESetPrintOptions(HCRW, wkPrintOption)
				Case SSS_VIEW
					'�v���r���[��ʂ̃f�t�H���g�T�C�Y���w��
					Rtn = GetPrivateProfileString("REPORT", "CRW_LEFT", "", wkStr.Value, 128, "SSSWIN.INI")
					If Rtn > 0 Then wkLeft = Int(CDbl(Left(wkStr.Value, Rtn)))
					Rtn = GetPrivateProfileString("REPORT", "CRW_TOP", "", wkStr.Value, 128, "SSSWIN.INI")
					If Rtn > 0 Then wkTop = Int(CDbl(Left(wkStr.Value, Rtn)))
					Rtn = GetPrivateProfileString("REPORT", "CRW_HEIGHT", "", wkStr.Value, 128, "SSSWIN.INI")
					If Rtn > 0 Then wkHeight = Int(CDbl(Left(wkStr.Value, Rtn)))
					Rtn = GetPrivateProfileString("REPORT", "CRW_WIDTH", "", wkStr.Value, 128, "SSSWIN.INI")
					If Rtn > 0 Then wkWidth = Int(CDbl(Left(wkStr.Value, Rtn)))
					
					'���m���`�F�b�N
					If wkTop <= 0 Or wkTop >= VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15 Then wkTop = 0
					If wkLeft <= 0 Or wkLeft >= VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15 Then wkLeft = 0
					If wkWidth <= 0 Or wkWidth >= VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15 Then wkWidth = VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15
					If wkHeight <= 0 Or wkHeight >= VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15 Then wkHeight = VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15
					If wkLeft + wkWidth > VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15 Then wkWidth = VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15 - wkLeft
					If wkTop + wkHeight > VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15 Then wkHeight = VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15 - wkHeight
					'
					Rtn = CRW_PUTWINDOW(CStr(FR_SSSMAIN.Text) & "���߰�", wkLeft, wkTop, wkWidth, wkHeight)
					'�v���r���[��ʂł̃{�^���\���^��\��
					wkWindowOption.StructSize = PE_SIZEOF_WINDOW_OPTIONS
					Rtn = PEGetWindowOptions(HCRW, wkWindowOption)
					'CHG START FKS)INABA 2006/11/15******************************************************************
					'��Ɏ擾���������ɂ��APreview��ʂ̈���{�^���A�v�����^�ݒ�{�^���A�t�@�C���o�̓{�^���𐧌䂷��
					If gs_PRTAUTH = "1" Then '��������L��
						wkWindowOption.hasPrintButton = 1
						wkWindowOption.hasPrintSetupButton = 1
					Else
						wkWindowOption.hasPrintButton = 0
						wkWindowOption.hasPrintSetupButton = 0
					End If
					If gs_FILEAUTH = "1" Then '�t�@�C���o�͌����L��
						wkWindowOption.hasExportButton = 1
					Else
						wkWindowOption.hasExportButton = 0
					End If
					
					'wkWindowOption.hasPrintButton = IIf((SSS_Hide_Prnbutton), 0, 1)
					'wkWindowOption.hasExportButton = IIf((SSS_Hide_Expbutton), 0, 1)
					'wkWindowOption.hasPrintSetupButton = IIf((SSS_Hide_Prnset), 0, 1)
					'CHG  END  FKS)INABA 2006/11/15******************************************************************
					
					Rtn = PESetWindowOptions(HCRW, wkWindowOption)
				Case SSS_FILE
					Rtn = CRW_SETEXPATR()
			End Select
			If Rtn = False Then
				Error_Exit(("ERROR SSS_LIST �o�͐�I�� RTN=[" & Str(Rtn) & "]"))
			End If
			If Rtn = True Or Rtn = 1 Then
				FR_SSSMAIN.Enabled = False
				System.Windows.Forms.Application.DoEvents()
                'If CRW_PRINT() = False Then Error_Exit(("ERROR SSS_LIST CRW_PRINT"))
                '�o�͏�Ԃ̃`�F�b�N�̂��߂̋敪���Z�b�g
                SSS_OUTKB = LSTKB
				'
			ElseIf Rtn <> PE_ERR_USERCANCELLED Then 
				'CRW�ŃG���[�����������ꍇ
				Rtn = MsgBox("SSS_LIST��CRW�G���[���������܂����F[" & Str(Rtn) & "]")
				Error_Exit(("ERROR SSS_LIST �o�͐�I�� RTN=[" & Str(Rtn) & "]"))
			End If
			Call WORKING_VIEW(False)
            'Debug.Print "    �N���X�^�����|�[�g���o�͂ɗv��������" & chr(9) & chr(9) & ": " & Str$(Timer - PointTime)
            'Time3 = Timer - PointTime
            'Debug.Print "�g�[�^���ŉ�ʕ\���ɗv��������" & Chr(9) & Chr(9) & ": " & Str$(Timer - StartTime)
            'Debug.Print ""
            'msg1$ = "����f�[�^�� Jet �ւ̏o�͂��J�n����܂ł̎���" & Chr(9) & ": " & Str$(Time1) & Chr(13)
            'msg1$ = msg1$ + "����f�[�^�� Jet �ɏo�͂���̂ɗv��������" & Chr(9) & ": " & Str$(Time2) & Chr(13)
            'msg1$ = msg1$ + "�N���X�^�����|�[�g���o�͂ɗv��������" & Chr(9) & Chr(9) & ": " & Str$(Time3) & Chr(13)
            'msg1$ = msg1$ + "��ʕ\���ɗv��������" & Chr(9) & Chr(9) & Chr(9) & ": " & Str$(Timer - StartTime)
            'MsgBox msg1$
            Do While CRW_VIEWCHECK()
                '2019/10/23 CHG START
                'Call Sleep(200)
                Call System.Threading.Thread.Sleep(200)
                '2019/10/23 CHG E N D
                System.Windows.Forms.Application.DoEvents()
            Loop
            FR_SSSMAIN.Enabled = True
			System.Windows.Forms.Application.DoEvents()
		End If
		'
		'�o�͏������ɍēx�o�͏������ĂԂƃG���[�ɂȂ邽�ߔ�\���ɂ��Ă����{�^����\���ɂ���
		'CHG START FKS)INABA 2006/11/15******************************************************************
		'��Ɏ擾���������ɂ��APreview��ʂ̈���{�^���A�v�����^�ݒ�{�^���A�t�@�C���o�̓{�^���𐧌䂷��
		If gs_PRTAUTH = "1" Then '��������L��
			CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = True
			CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
		Else
			CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = False
			CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
		End If
		If gs_FILEAUTH = "1" Then '�t�@�C���o�͌����L��
			CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = True
		Else
			CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
		End If
		'        FR_SSSMAIN!CM_LSTART.Visible = True
		'        FR_SSSMAIN!CM_VSTART.Visible = True
		'        FR_SSSMAIN!CM_FSTART.Visible = True
		
		'CHG  END  FKS)INABA 2006/11/15******************************************************************
		''
		If SSS_DYNASQL Then
			'PR2�n���[�Ń_�C�i�~�b�N��SQL�����g���ꍇ
			Call DB_Execute(SSS_LSTMFIL, "DROP TABLE " & Get_DBHEAD() & "_" & Trim(DB_PARA(SSS_LSTMFIL).DBID) & "." & SSS_PrgId & "_" & SSS_CLTID.Value)
		End If
		''
		Call CRW_CLOSE()
		
	End Sub
	
	Function SSSMAIN_Append() As Object
		'�t�@�C���ɃJ�����g���R�[�h�̒ǉ��������s���B
		Call INQ_LIST()
		'�󎚏�����ر���Ȃ�
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Append �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Append = 1
	End Function
	
	Function SSSMAIN_BeginPrg() As Object
        '��ʕ\���O�̏����ݒ菈�����s���B
        'UPGRADE_ISSUE: App �v���p�e�B App.PrevInstance �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
        '2019/10/23 CHG START
        'If App.PrevInstance Then
        '    MsgBox("�y" & Trim(SSS_PrgNm) & "�z�͊��ɋN�����ł��B�d�����ċN�����鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
        '    End
        'End If
        '2019/10/23 CHG E N D
        ' "���΂炭���҂���������" �E�B���h�E�\��
        'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
        '2019/10/23 CHG START
        'Load(ICN_ICON)
        ICN_ICON.Show()
        '2019/10/23 CHG E N D
        'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_BeginPrg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        SSSMAIN_BeginPrg = True
		SSS_ExportFLG = False '�����l�F�������
		'----------------------------------
		'   SSSWIN �v���O�����N���`�F�b�N
		'----------------------------------
		Call SSSWIN_INIT()
		Call SSSWIN_OPEN()
		'
		'�f�t�H���g�p���T�C�Y�ƈ���̌�����ǂݎ��
		Call Set_defaultPrintInfo()
		
		Call InitDsp()
		' "���΂炭���҂���������" �E�B���h�E����
		ICN_ICON.Close()
	End Function
	
	Function SSSMAIN_Close() As Object
		'�I�����̌㏈�����s���B
		Call SSSWIN_CLOSE()
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Close �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Close = True
	End Function
	
	Function SSSMAIN_Current() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Current �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Current = 0
	End Function
	
	Function SSSMAIN_Init() As Object
		'
		Call WORKING_VIEW(False)
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Init �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Init = True
	End Function
	
	Function SSSMAIN_Last() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Last �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Last = 0
	End Function
	
	Function SSSMAIN_Next() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Next �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Next = 0
	End Function
	
	Function SSSMAIN_Select() As Object
		'�����Ώۂ̃f�[�^�͈̔͂�ݒ肷��B
		'SSSMAIN_Select = SET_GAMEN_KEY()
	End Function
	
	Function SSSMAIN_Update() As Object
		'�t�@�C���̒��̃J�����g���R�[�h�̍X�V���s���B
		Dim Wk As Object
		'MsgBox "�f�[�^���X�V���܂����B"
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Update �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Update = 9
	End Function
	
	Function VSTART_GetEvent() As Short
		'
		VSTART_GetEvent = True
		'
		'#Start/2002.1.23
		If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
			Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
		End If
		Call AE_RecalcAll_SSSMAIN()
		If AE_CompleteCheck_SSSMAIN(0) <> 0 Then
			Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
			PP_SSSMAIN.CursorSet = True
			VSTART_GetEvent = False
			Exit Function
		End If
		'#End/2002.1.23
		SSS_Makkb = SSS_VIEW
		Call SSS_LIST(SSS_VIEW)
		'
	End Function
	
	Sub WLS_SLIST_MOVE(ByVal SlistCom As Object, ByVal LENGTH As Short)
		'UPGRADE_WARNING: �I�u�W�F�N�g SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP_SSSMAIN.SlistCom = LeftWid(SlistCom, LENGTH)
	End Sub
	
	Sub WORKING_VIEW(ByRef Sw As Short)
		'�Q�[�W�̕\�� etc...
		'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!GAUGE.FloodPercent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CType(FR_SSSMAIN.Controls("GAUGE"), Object).FloodPercent = 0
		If Sw Then
			'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor '�����v
            '2019/10/23 DEL START
            'Call AE_StatusOut(PP_SSSMAIN, "��ƒ��I ���΂炭���҂����������B", System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_BLUE))
            '2019/10/23 DEL E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!GAUGE.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            CType(FR_SSSMAIN.Controls("GAUGE"), Object).Visible = True
			'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!CM_LCANCEL.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(FR_SSSMAIN.Controls("CM_LCANCEL"), Object).Visible = True
		Else
			'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default '����l
			CType(FR_SSSMAIN.Controls("TX_Message"), Object).Text = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!GAUGE.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(FR_SSSMAIN.Controls("GAUGE"), Object).Visible = False
			'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!CM_LCANCEL.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(FR_SSSMAIN.Controls("CM_LCANCEL"), Object).Visible = False
		End If
		System.Windows.Forms.Application.DoEvents()
	End Sub
End Module