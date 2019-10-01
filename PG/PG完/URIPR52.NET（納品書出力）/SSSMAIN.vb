Option Strict Off
Option Explicit On
Module SSSMAIN_PR3

    Public SSS_DonePrintFlg As Short '����ς݃t���O�@1:����ς݁@0:����ς݂łȂ�
    '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'for �m�����q�q�q �u�`�O�R                                                             '
    '                                                                             --2002.3 '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Sub CNT_GAUGE()
        '
        '�Q�[�W�̕\��
        If SSS_MFILCNT > 0 And SSS_MFILTCNT > 0 Then
            'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!GAUGE.FloodPercent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            CType(FR_SSSMAIN.Controls("GAUGE"), Object).FloodPercent = SSS_MFILCNT * 100 / SSS_MFILTCNT
            'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!GAUGE.FloodPercent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If CType(FR_SSSMAIN.Controls("GAUGE"), Object).FloodPercent > 45 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!GAUGE.ForeColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                CType(FR_SSSMAIN.Controls("GAUGE"), Object).ForeColor = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_WHITE)
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!GAUGE.ForeColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                CType(FR_SSSMAIN.Controls("GAUGE"), Object).ForeColor = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_BLACK)
            End If
        End If
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Function FSTART_GetEvent() As Short
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

        'ADD 2007/02/19 IMAI-----------------------------------------------------------------------------
        '����ς݃t���O�𗧂Ă�
        If (SSS_PrgId = "SODPR53") Or (SSS_PrgId = "URIPR52") Or (SSS_PrgId = "SEIPR51") Or (SSS_PrgId = "SEIPR53") Or (SSS_PrgId = "SEIPR54") Then
            SSS_DonePrintFlg = 1
        End If
        'ADD 2007/02/19 IMAI-----------------------------------------------------------------------------

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
        '2019.04.18 del start
        'Call CRW_CLOSE()
        'Call CRW_END()
        '2019.04.18 del end
        '
        Call DB_RESET()
        Call DB_End()
        '
        System.Windows.Forms.Application.DoEvents()
        '
        On Error Resume Next
    End Sub

    Sub SSS_Export()
        Dim rtn As Short
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
        '
        ' �Q�[�W�\���p�������Z�o
        Call DB_Stat(SSS_MFIL)
        If DBSTAT = 0 Then
            SSS_MFILTCNT = StatFileBuffer.RecTot
        End If
        '
        SSS_LFILCNT = 0
        '
        If SSS_ExportFileKB Then GoTo Next_Proc
        '
        'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.AppStarting '���ƍ����v��\��
        '
        Dim sSQL As String
        '2019.04.18 chg start
        'sSQL = "Delete From " & SSS_PrgId & " Where Rptcltid = " & "'" & SSS_CLTID.Value & "'"
        'Call DB_Execute(SSS_LSTMFIL, sSQL)
        sSQL = "Delete From NT_USR9." & SSS_PrgId & " Where Rptcltid = " & "'" & SSS_CLTID.Value & "'"
        Call DB_Execute(sSQL)
        '2019.04.18 end
        '
        Call Loop_Mfil()
        '
        Call DB_Execute(SSS_LSTMFIL, "COMMIT")

        '2019.04.22 add start
        Application.DoEvents()
        '2019.04.22 add end
        '
        ' �L�����Z������
        If SSS_LSTOP = True Then
            '2019.04.22 del start
            'Call WORKING_VIEW(False)
            ''
            'Call CRW_CLOSE()
            '2019.04.22 del end
            '
            Exit Sub
        End If
        '
        'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!GAUGE.FloodPercent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CType(FR_SSSMAIN.Controls("GAUGE"), Object).FloodPercent = 100
        '
        '�Q�Ɛ��؂�ւ���
        rtn = Crw_ChgLoc()

        If rtn = 0 Then
            MsgBox("CRW_PRINT.CRW_STATUS : " & rtn & Chr(13) & CRW_GETERRMSG(HCRW))
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
                rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
                Call WORKING_VIEW(False)
                Call CRW_CLOSE()
                Exit Sub
            End If
        Else
            'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor '�����v
            Call WORKING_VIEW(False)
            If rtn = False Then
                Error_Exit(("ERROR SSS_LIST �o�͐�I�� RTN=[" & Str(rtn) & "]"))
            Else
                On Error Resume Next
                Kill(SSS_CRWOPATH & SSS_PrgId & ".TXT")
                On Error GoTo 0
                FR_SSSMAIN.Enabled = False
                System.Windows.Forms.Application.DoEvents()
                rtn = PEDiscardSavedData(HCRW)
                If SSS_ExportFileName = vbNullString Then SSS_ExportFileName = SSS_PrgId '(1998/11/19 �ǉ��j
                If reportExportX(HCRW, SSS_CRWOPATH & SSS_ExportFileName & "." & SSS_ExportFileEXT & Chr(0), SSS_ExportFileType, 0, SSS_ExportSep & Chr(0), SSS_ExportQuat & Chr(0)) <> 1 Then
                    rtn = DSP_MsgBox(SSS_ERROR, "CANTDELFILE", 0)
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
                '2019.04.08 CHG START
                'Call Sleep(200)
                System.Threading.Thread.Sleep(200)
                '2019.04.08 CHG END
                System.Windows.Forms.Application.DoEvents()
            Loop
            FR_SSSMAIN.Enabled = True
            System.Windows.Forms.Application.DoEvents()

        End If
        '
Next_Proc:
        Call WORKING_VIEW(False)
        Call CRW_CLOSE()
        Call Chain_Proc()
    End Sub

    Sub SSS_LIST(ByRef LSTKB As Short)
        Dim rtn As Short
        Dim wkRptId As String
        Dim wkWindowOption As T_PEWindowOptions
        Dim wkPrintOption As T_PEPrintOptions
        Dim wkWidth, wkTop, wkLeft, wkHeight As Short
        Dim wkStr As New VB6.FixedLengthString(128)
        'Dim StartTime, PointTime, Time1, Time2, Time3      '�v���p
        'Dim msg1$     
        '�v���p

        '2019.04.18 add start
        '����ς݃t���O�𗧂Ă�
        If (SSS_PrgId = "SODPR53") Or (SSS_PrgId = "URIPR52") Or (SSS_PrgId = "SEIPR51") Or (SSS_PrgId = "SEIPR53") Or (SSS_PrgId = "SEIPR54") Then
            SSS_DonePrintFlg = 1
        End If

        '���~�{�^���L��
        CType(FR_SSSMAIN.Controls("CM_LCANCEL"), Object).Visible = True
        CType(FR_SSSMAIN.Controls("CM_LCANCEL"), Object).Enabled = True
        '2019.04.18 add end

        '�o�͏������ɍēx�o�͏������ĂԂƃG���[�ɂȂ邽�߃{�^�����\���ɂ���
        '2019.04.15 del start
        'CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = False
        'CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = False
        'CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
        '2019.04.15 del end
        'StartTime = Timer
        'PointTime = Timer'2019.04.15 del start
        'Call WORKING_VIEW(True)
        '' �N���X�^�����|�[�g�̃I�[�v��
        'If CRW_INIT() = False Then
        '	Call Error_Exit("ERROR CRW_INIT")
        'Else
        '	'�`�[��ʂɂ��RPT�t�@�C���̑I��(�I�v�V�������j�b�g�Ȃǂ�SYSTBI��ǂ�ł���)
        '	If Trim(SSS_RPTID) = "" Then
        '		wkRptId = SSS_PrgId
        '	Else
        '		wkRptId = SSS_RPTID
        '	End If
        '	If CRW_OPEN(SSS_INIDAT(2) & "RPT\" & wkRptId & ".RPT") = False Then
        '		Call Error_Exit("ERROR CRW_OPEN")
        '	End If
        'End If
        '2019.04.15 del end

        '�o�͏�Ԃ̃`�F�b�N�̂��߂̋敪���N���A
        SSS_OUTKB = 0
        '
        Call Set_Value()
        '
        '2019.04.15 del start
        'If CRW_DOCHECK() = False Then
        '    MsgBox("���ň�����ׁ̈A���s�ł��܂���B", MB_ICONEXCLAMATION)
        '    '
        '    '�o�͏������ɍēx�o�͏������ĂԂƃG���[�ɂȂ邽�ߔ�\���ɂ��Ă����{�^����\���ɂ���
        '    'CHG START FKS)INABA 2006/11/15******************************************************************
        '    '��Ɏ擾���������ɂ��APreview��ʂ̈���{�^���A�v�����^�ݒ�{�^���A�t�@�C���o�̓{�^���𐧌䂷��
        '    If gs_PRTAUTH = "1" Then '��������L��
        '        CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = True
        '        CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '    Else
        '        CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = False
        '        CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '    End If
        '    If gs_FILEAUTH = "1" Then '�t�@�C���o�͌����L��
        '        CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '        CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = True
        '    Else
        '        CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '        CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
        '    End If
        '    '        FR_SSSMAIN!CM_LSTART.Visible = True
        '    '        FR_SSSMAIN!CM_VSTART.Visible = True
        '    '        FR_SSSMAIN!CM_FSTART.Visible = True

        '    'CHG  END  FKS)INABA 2006/11/15******************************************************************

        '    Call CRW_CLOSE()
        '    '
        '    Call WORKING_VIEW(False)
        '    Exit Sub
        'End If
        '2019.04.15 del end

        SSS_LSTOP = False
        SSS_MFILCNT = 0
        '
        ' �Q�[�W�\���p�������Z�o
        Call DB_Stat(SSS_MFIL)
        If DBSTAT = 0 Then
            SSS_MFILTCNT = StatFileBuffer.RecTot
        End If
        '
        SSS_LFILCNT = 0
        '
        'Debug.Print "    ����f�[�^�� SQL �ւ̏o�͂��J�n����܂ł̎���:" & Str$(Timer - PointTime)
        'Time1 = Timer - PointTime
        'PointTime = Timer
        '

        '2019.04.18 add start
        '�g�����U�N�V�����J�n
        DB_BeginTrans(CON)
        '2019.04.18 add end

        Dim sSQL As String
        '2019.04.18 chg start
        'sSQL = "Delete From " & SSS_PrgId & " Where Rptcltid = " & "'" & SSS_CLTID.Value & "'"
        'Call DB_Execute(SSS_LSTMFIL, sSQL)
        'Call Loop_Mfil()
        'Call DB_Execute(SSS_LSTMFIL, "COMMIT")
        sSQL = "Delete From CNT_USR9." & SSS_PrgId & " Where Rptcltid = " & "'" & SSS_CLTID.Value & "'"
        Call DB_Execute(sSQL)
        Dim result As Integer = 9
        Call Loop_Mfil(result)
        If result = 0 Then
            '�R�~�b�g
            DB_Commit()
        Else
            '���[���o�b�N
            DB_Rollback()
            If SSS_LSTOP = True Then
                MsgBox("���~���܂���")
            End If
            Exit Sub
        End If

        '2019.04.18 chg end
        '
        'Debug.Print "    ����f�[�^�� SQL �ɏo�͂���̂ɗv��������" & chr(9) & ": " & Str$(Timer - PointTime)
        'Time2 = Timer - PointTime
        'PointTime = Timer

        '2019.04.22 add start
        Application.DoEvents()
        '2019.04.22 add end

        '2019.04.18 add start
        '���~�{�^��������
        CType(FR_SSSMAIN.Controls("CM_LCANCEL"), Object).Visible = False
        CType(FR_SSSMAIN.Controls("CM_LCANCEL"), Object).Enabled = False
        '2019.04.18 add end

        '�L�����Z������
        If SSS_LSTOP = True Then
            '2019.04.16 del start
            'Call WORKING_VIEW(False)
            ''
            ''�o�͏������ɍēx�o�͏������ĂԂƃG���[�ɂȂ邽�ߔ�\���ɂ��Ă����{�^����\���ɂ���
            ''CHG START FKS)INABA 2006/11/15******************************************************************
            ''��Ɏ擾���������ɂ��APreview��ʂ̈���{�^���A�v�����^�ݒ�{�^���A�t�@�C���o�̓{�^���𐧌䂷��
            'If gs_PRTAUTH = "1" Then '��������L��
            '    CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = True
            '    CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
            'Else
            '    CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = False
            '    CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
            'End If
            'If gs_FILEAUTH = "1" Then '�t�@�C���o�͌����L��
            '    CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
            '    CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = True
            'Else
            '    CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
            '    CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
            'End If
            ''        FR_SSSMAIN!CM_LSTART.Visible = True
            ''        FR_SSSMAIN!CM_VSTART.Visible = True
            ''        FR_SSSMAIN!CM_FSTART.Visible = True

            ''CHG  END  FKS)INABA 2006/11/15******************************************************************

            'Call CRW_CLOSE()
            '
            '2019.04.16 del end
            '2019.04.18 add start
            MsgBox("���~���܂���")
            '2019.04.18 add end
            Exit Sub
        End If
        '
        'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!GAUGE.FloodPercent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019.04.15 del start
        'CType(FR_SSSMAIN.Controls("GAUGE"), Object).FloodPercent = 100
        '2019.04.15 del end

        If SSS_LFILCNT = 0 Then
            '���b�Z�[�W�i�[�ϐ��ɕ����������Ă���΂����\���B
            If Trim(SSS_Message) <> "" Then
                Call MsgBox(SSS_Message, MsgBoxStyle.Information)
                '2019.04.18 del start
                Call WORKING_VIEW(False)
                '2019.04.18 del end
            Else
                rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
                '2019.04.18 del start
                'Call WORKING_VIEW(False)
                '2019.04.18 del end
            End If
        Else
            '�_�C�A���O�ɂ��v�����^�ؑւ������ꂽ���̂��Đݒ肷��B
            '��p���[�̏ꍇ�N���X�^�����|�[�g�̃��[�U�[��`��D�悷��B
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            '2019.04.18 del start�y���z
            'If IsDBNull(SSS_Lconfig) Then SSS_Lconfig = ""
            'If SSS_Lconfig <> "USR" Then Call CRW_SET_PRINTER()
            '2019.04.18 del end

            Select Case LSTKB
                Case SSS_PRINTER
                    rtn = CRW_PUTPRINTER()
                    '��������̎w��
                    wkPrintOption.StructSize = PE_SIZEOF_PRINT_OPTIONS
                    rtn = PEGetPrintOptions(HCRW, wkPrintOption)
                    wkPrintOption.StartPageN = SSS_StartPageNo
                    wkPrintOption.stopPageN = SSS_StopPageNo
                    wkPrintOption.nReportCopies = SSS_Copies
                    If SSS_Copies > 1 Then
                        wkPrintOption.collation = IIf((SSS_Collation = 1), PE_COLLATED, PE_UNCOLLATED)
                    End If
                    rtn = PESetPrintOptions(HCRW, wkPrintOption)
                Case SSS_VIEW
                    '2019.04.18 add start
                    Try

                        Dim CR As New CrstlRpt
                        Dim Report = CR.NewCRReport()
                        Dim EmpQuery As String
                        Dim FmlaText As String

                        Report.Load(VB6.GetPath & "\" & SSS_PrgId & ".rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByDefault)

                        FmlaText = ""
                        FmlaText = FmlaText & "{" & SSS_PrgId & ".RPTCLTID}='" & SSS_CLTID.ToString & "'"
                        Report.RecordSelectionFormula = FmlaText
                        EmpQuery = "SELECT * FROM " & SSS_PrgId
                        EmpQuery = EmpQuery & " WHERE RPTCLTID = '" & SSS_CLTID.ToString & "'"

                        CR.SetDatabase("CNJ_ODBC", "CNT_USR9P", "CNT_USR9", EmpQuery, "URIPR52", Report)

                        '�v���r���[
                        CR.ReportPreview(Report, EmpQuery, "00")

                    Catch ex As Exception
                        MsgBox(ex.ToString)
                        Exit Sub
                    End Try
                    '2019.04.19 add end

                    '2019.04.18 del start �y���z
                    '�v���r���[��ʂ̃f�t�H���g�T�C�Y���w��
                    'rtn = GetPrivateProfileString("REPORT", "CRW_LEFT", "", wkStr.Value, 128, "SSSWIN.INI")
                    'If rtn > 0 Then wkLeft = Int(CDbl(Left(wkStr.Value, rtn)))
                    'rtn = GetPrivateProfileString("REPORT", "CRW_TOP", "", wkStr.Value, 128, "SSSWIN.INI")
                    'If rtn > 0 Then wkTop = Int(CDbl(Left(wkStr.Value, rtn)))
                    'rtn = GetPrivateProfileString("REPORT", "CRW_HEIGHT", "", wkStr.Value, 128, "SSSWIN.INI")
                    'If rtn > 0 Then wkHeight = Int(CDbl(Left(wkStr.Value, rtn)))
                    'rtn = GetPrivateProfileString("REPORT", "CRW_WIDTH", "", wkStr.Value, 128, "SSSWIN.INI")
                    'If rtn > 0 Then wkWidth = Int(CDbl(Left(wkStr.Value, rtn)))

                    ''���m���`�F�b�N
                    'If wkTop <= 0 Or wkTop >= VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15 Then wkTop = 0
                    'If wkLeft <= 0 Or wkLeft >= VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15 Then wkLeft = 0
                    'If wkWidth <= 0 Or wkWidth >= VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15 Then wkWidth = VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15
                    'If wkHeight <= 0 Or wkHeight >= VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15 Then wkHeight = VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15
                    'If wkLeft + wkWidth > VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15 Then wkWidth = VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15 - wkLeft
                    'If wkTop + wkHeight > VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15 Then wkHeight = VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15 - wkHeight
                    ''
                    'rtn = CRW_PUTWINDOW(CStr(FR_SSSMAIN.Text) & "���߰�", wkLeft, wkTop, wkWidth, wkHeight)
                    ''�v���r���[��ʂł̃{�^���\���^��\��
                    'wkWindowOption.StructSize = PE_SIZEOF_WINDOW_OPTIONS
                    'rtn = PEGetWindowOptions(HCRW, wkWindowOption)

                    ''CHG START FKS)INABA 2006/11/15******************************************************************
                    ''��Ɏ擾���������ɂ��APreview��ʂ̈���{�^���A�v�����^�ݒ�{�^���A�t�@�C���o�̓{�^���𐧌䂷��
                    'If gs_PRTAUTH = "1" Then '��������L��
                    '    wkWindowOption.hasPrintButton = 1
                    '    wkWindowOption.hasPrintSetupButton = 1
                    'Else
                    '    wkWindowOption.hasPrintButton = 0
                    '    wkWindowOption.hasPrintSetupButton = 0
                    'End If
                    'If gs_FILEAUTH = "1" Then '�t�@�C���o�͌����L��
                    '    wkWindowOption.hasExportButton = 1
                    'Else
                    '    wkWindowOption.hasExportButton = 0
                    'End If

                    ''wkWindowOption.hasPrintButton = IIf((SSS_Hide_Prnbutton), 0, 1)
                    ''wkWindowOption.hasExportButton = IIf((SSS_Hide_Expbutton), 0, 1)
                    ''wkWindowOption.hasPrintSetupButton = IIf((SSS_Hide_Prnset), 0, 1)
                    ''CHG  END  FKS)INABA 2006/11/15******************************************************************

                    ''CHG START FKS)INABA 2007/07/10 *********************************************************
                    ''SODPR53�ɂ��Ă̓v���r���[��ʂɈ���E����ݒ�A�G�N�X�|�[�g�{�^����\������悤�ɕύX

                    ''SODPR53,URIPR52,SEIPR51,SEIPR53,SEIPR54�̓v���r���[��ʂɈ���E����ݒ�E�G�N�X�|�[�g�{�^�����\��
                    'If (SSS_PrgId = "URIPR52") Or (SSS_PrgId = "SEIPR51") Or (SSS_PrgId = "SEIPR53") Or (SSS_PrgId = "SEIPR54") Then
                    '    wkWindowOption.hasPrintButton = 0
                    '    wkWindowOption.hasPrintSetupButton = 0
                    '    wkWindowOption.hasExportButton = 0
                    'End If
                    ''                If (SSS_PrgId = "SODPR53") Or (SSS_PrgId = "URIPR52") Or (SSS_PrgId = "SEIPR51") Or (SSS_PrgId = "SEIPR53") _
                    '''                Or (SSS_PrgId = "SEIPR54") Then
                    ''                    wkWindowOption.hasPrintButton = 0
                    ''                    wkWindowOption.hasPrintSetupButton = 0
                    ''                    wkWindowOption.hasExportButton = 0
                    ''                End If
                    ''ADD 2007/02/19 IMAI-----------------------------------------------------------------------------
                    ''CHG START FKS)INABA 2007/07/10 *********************************************************


                    'rtn = PESetWindowOptions(HCRW, wkWindowOption)
                    '2019.04.18 del end
                Case SSS_FILE
                    rtn = CRW_SETEXPATR()
            End Select

            '2019.04.18 del start �y���z
            'If rtn = False Then
            '    Error_Exit(("ERROR SSS_LIST �o�͐�I�� RTN=[" & Str(rtn) & "]"))
            'End If
            'If rtn = True Or rtn = 1 Then
            '    FR_SSSMAIN.Enabled = False
            '    System.Windows.Forms.Application.DoEvents()
            '    'If CRW_PRINT2() = False Then Error_Exit ("ERROR SSS_LIST CRW_PRINT")
            '    If CRW_PRINT() = False Then Error_Exit(("ERROR SSS_LIST CRW_PRINT"))
            '    '�o�͏�Ԃ̃`�F�b�N�̂��߂̋敪���Z�b�g
            '    SSS_OUTKB = LSTKB
            '    '
            'ElseIf rtn <> PE_ERR_USERCANCELLED Then
            '    'CRW�ŃG���[�����������ꍇ
            '    rtn = MsgBox("SSS_LIST��CRW�G���[���������܂����F[" & Str(rtn) & "]")
            '    Error_Exit(("ERROR SSS_LIST �o�͐�I�� RTN=[" & Str(rtn) & "]"))
            'End If
            'Call WORKING_VIEW(False)
            ''Debug.Print "    �N���X�^�����|�[�g���o�͂ɗv��������" & chr(9) & chr(9) & ": " & Str$(Timer - PointTime)
            ''Time3 = Timer - PointTime
            ''Debug.Print "�g�[�^���ŉ�ʕ\���ɗv��������" & Chr(9) & Chr(9) & ": " & Str$(Timer - StartTime)
            ''Debug.Print ""
            ''msg1$ = "����f�[�^�� Jet �ւ̏o�͂��J�n����܂ł̎���" & Chr(9) & ": " & Str$(Time1) & Chr(13)
            ''msg1$ = msg1$ + "����f�[�^�� Jet �ɏo�͂���̂ɗv��������" & Chr(9) & ": " & Str$(Time2) & Chr(13)
            ''msg1$ = msg1$ + "�N���X�^�����|�[�g���o�͂ɗv��������" & Chr(9) & Chr(9) & ": " & Str$(Time3) & Chr(13)
            ''msg1$ = msg1$ + "��ʕ\���ɗv��������" & Chr(9) & Chr(9) & Chr(9) & ": " & Str$(Timer - StartTime)
            ''MsgBox msg1$
            'Do While CRW_VIEWCHECK()
            '    '2019.04.08 CHG START
            '    'Call Sleep(200)
            '    System.Threading.Thread.Sleep(200)
            '    '2019.04.08 CHG END
            '    System.Windows.Forms.Application.DoEvents()
            'Loop
            'FR_SSSMAIN.Enabled = True
            'System.Windows.Forms.Application.DoEvents()
            '2019.04.18 del end
        End If
        '
        '�o�͏������ɍēx�o�͏������ĂԂƃG���[�ɂȂ邽�ߔ�\���ɂ��Ă����{�^����\���ɂ���
        'CHG START FKS)INABA 2006/11/15******************************************************************
        '��Ɏ擾���������ɂ��APreview��ʂ̈���{�^���A�v�����^�ݒ�{�^���A�t�@�C���o�̓{�^���𐧌䂷��

        '2019.04.18 del start
        'If gs_PRTAUTH = "1" Then '��������L��
        '	CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = True
        '	CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        'Else
        '	CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = False
        '	CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        'End If
        'If gs_FILEAUTH = "1" Then '�t�@�C���o�͌����L��
        '	CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '	CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = True
        'Else
        '	CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '	CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
        'End If
        '      '        FR_SSSMAIN!CM_LSTART.Visible = True
        '      '        FR_SSSMAIN!CM_VSTART.Visible = True
        '      '        FR_SSSMAIN!CM_FSTART.Visible = True

        '      'CHG  END  FKS)INABA 2006/11/15******************************************************************

        '      '
        'Call CRW_CLOSE()

        '2019.04.18 del end
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
        '2019.03.26 CHG START
        'If App.PrevInstance Then
        If PrevInstance() Then
            '2019.03.26 CHG END
            MsgBox("�y" & Trim(SSS_PrgNm) & "�z�͊��ɋN�����ł��B�d�����ċN�����鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
            End
        End If
        ' "���΂炭���҂���������" �E�B���h�E�\��
        'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
        '2019.03.26 chg START
        'Load(ICN_ICON)
        ICN_ICON.Show()
        '2019.03.26 CHG END
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
        '2019.04.05 ADD START
        CType(FR_SSSMAIN.Controls("CM_LCANCEL"), Object).Visible = False
        '2019.04.05 ADD END
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
    End Function

    Function SSSMAIN_Update() As Object
        '�t�@�C���̒��̃J�����g���R�[�h�̍X�V���s���B
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
        'ADD START FKS)INABA 2007/07/12 ******************
        '����ς݃t���O�𗧂Ă�
        If SSS_PrgId = "SODPR53" Then
            SSS_DonePrintFlg = 1
        End If
        'ADD  END  FKS)INABA 2007/07/12 ******************
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
        '2019.04.18 del start
        ''�Q�[�W�̕\�� etc...
        ''UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!GAUGE.FloodPercent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'CType(FR_SSSMAIN.Controls("GAUGE"), Object).FloodPercent = 0
        'If Sw Then
        '    'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        '    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor '�����v
        '    '2019.04.08 DEL START
        '    'Call AE_StatusOut(PP_SSSMAIN, "��ƒ��I�@���΂炭���҂����������B", System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_BLUE))
        '    '2019.04.08 DEL END
        '    'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!GAUGE.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    CType(FR_SSSMAIN.Controls("GAUGE"), Object).Visible = True
        '    'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!CM_LCANCEL.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    CType(FR_SSSMAIN.Controls("CM_LCANCEL"), Object).Visible = True
        'Else
        '    'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        '    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default '����l
        '    CType(FR_SSSMAIN.Controls("TX_Message"), Object).Text = ""
        '    'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!GAUGE.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    CType(FR_SSSMAIN.Controls("GAUGE"), Object).Visible = False
        '    'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!CM_LCANCEL.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    CType(FR_SSSMAIN.Controls("CM_LCANCEL"), Object).Visible = False
        'End If
        'System.Windows.Forms.Application.DoEvents()
        '2019.04.18 del end
    End Sub

    '2019.04.08 ADD START
    Public Function PrevInstance() As Boolean
        If Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName).Length > 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    '2019.04.08 ADD END
End Module