Option Strict Off
Option Explicit On
Friend Class HKKET142F
	Inherits System.Windows.Forms.Form

    '2019/04/11 ADD START
    Private ClsMessage As New ClsMessage
    '2019/04/11 ADD E N D

	Private Sub cmdCALC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCALC.Click
		
		'// 2007/01/28 �� ADD START
		cmdCALC.Enabled = False
		'// 2007/01/28 �� ADD END
		
		If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "206") = MsgBoxResult.No Then
			GoTo EXIT_STEP
		End If
		
		Call D0.Mouse_ON()
		
		If Not Set_CalcData Then
			GoTo EXIT_STEP
		End If
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		'// 2007/01/28 �� ADD START
		cmdCALC.Enabled = True
		Call Ctr_Setfocus(cmdCALC)
		'    cmdCALC.SetFocus
		'// 2007/01/28 �� ADD END
		Call D0.Mouse_OFF()
		On Error GoTo 0
		Exit Sub
		'----------------------------------------------------------------------------------------
	End Sub
	
	Private Sub cmdCSVOUT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCSVOUT.Click
		Dim str_FileName As Object
		
		Dim str_FileName_1 As String
		Dim str_FileName_2 As String
		
		
		'//�������ʂb�r�u�o�̓��b�Z�[�W
		If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "207") = MsgBoxResult.Yes Then
            'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
            'add start 20190930 kuwa test CSV
            gvstrFilePath4 = "C:\Users\CIS03\Desktop\HKKET14CSV"
            'add end 20190930 kuwa
            If Dir(gvstrFilePath4, FileAttribute.Directory) = "" Then
                ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "124")
                Exit Sub
            End If

            '//�쐬�t�@�C��������
            'UPGRADE_WARNING: �I�u�W�F�N�g str_FileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            str_FileName = gvstrFileName4 & "_" & Me.txtHINCD.Text & "_" & VB6.Format(Now, "YYYYMMDD") & "_" & VB6.Format(Now, "HHMMSS") & ".CSV"
			
			'//�O���t�b�r�u�쐬
			'UPGRADE_WARNING: �I�u�W�F�N�g str_FileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call Cra_GraphCSV(gvstrFilePath4, str_FileName)
			
			ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "208")
		End If
		
		'//V1.10 2006/10/17  ADD START  RISE)
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		Call D0.Mouse_OFF()
		Exit Sub
		'----------------------------------------------------------------------------------------
		'//V1.10 2006/10/17  ADD END  RISE)
		
		''''    '//V1.10 2006/10/17  ADD START  RISE)
		''''    Dim str_DialogFilePath As String
		''''    Dim str_DialogFileName As String
		''''    Dim str_FileName       As String
		''''    '//V1.10 2006/10/17  ADD END    RISE)
		''''
		''''    '//�������ʂb�r�u�o�̓��b�Z�[�W
		''''    If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "207") = vbYes Then
		''''        If Dir(gvstrFilePath4, vbDirectory) = "" Then
		''''            ClsMessage.MsgLibrary gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "124"
		''''            Exit Sub
		''''        End If
		''''
		''''    '//V1.10 2006/10/17  ADD START  RISE)
		''''        '//�쐬�t�@�C��������
		''''        str_FileName = gvstrFileName4 & "_" & HKKET142F.txtHINCD.Text & "_" & Format(Now, "YYYYMMDD") & "_" & Format(Now, "HHMMSS") & ".CSV"
		''''
		''''        '//�_�C�A���O�{�b�N�X�N��
		''''        str_DialogFileName = str_FileName
		''''        If Not Run_DialogBox(cdl_SAVE2, str_DialogFilePath, str_DialogFileName) Then
		''''            GoTo EXIT_STEP
		''''        End If
		''''    '//V1.10 2006/10/17  ADD END    RISE)
		''''
		''''        '//�������ʂb�r�u����
		''''        intFileNo = FreeFile(0)
		''''    '//V1.10 2006/10/17  CHG START  RISE)
		''''''''        Open gvstrFilePath4 & "\" & gvstrFileName4 & "_" & HKKET142F.txtHINCD.Text & "_" & Format(Now, "YYYYMMDD") & "_" & Format(Now, "HHMMSS") & ".CSV" For Output As intFileNo
		''''        Open gvstrFilePath4 & "\" & str_FileName For Output As intFileNo
		''''    '//V1.10 2006/10/17  CHG END    RISE)
		''''        strBuff = ""
		''''        strBuff = strBuff & HKKET142F.txtHINCD.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtHINNMA.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtHINNMB.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtZAIRNK.Text
		''''        Print #intFileNo, strBuff
		''''        strBuff = ""
		''''        strBuff = strBuff & HKKET142F.txtMINSODSU.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtSODADDSU.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtANZZAISU.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtLMAMSAVTS.Text
		''''        strBuff = strBuff & HKKET142F.txtLMAAVTS.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtLMZAVTSA.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtCHGRATE.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtPRCCD.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtMNFDD.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtTOUZAISU.Text
		''''        Print #intFileNo, strBuff
		''''        strBuff = "�\���N��,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKZTRA.strDSPMONTH(i)       '//�\���N��
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "�N���v��,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKTRA.strLMAHKS(i)          '//�N���v��
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "�����v��,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKTRA.strLMAHMS(i)          '//�����v��
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "�O�N�󒍎���,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKZTRA.dblLAST_JDNTR(i)     '//�O�N�󒍎���
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "�O�N�o�Ɏ���,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKZTRA.dblLAST_ODNTRA(i)    '//�O�N�o�Ɏ���
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "�O�N��������,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKZTRA.dblLAST_HDNTRA(i)    '//�O�N��������
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "���ɗ\��,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKZTRA.dblINPTRA(i)         '//���ɗ\��
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "�o�ɗ\��,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKZTRA.dblOUTTRA(i)         '//�o�ɗ\��
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "�x���i�o��,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKZTRA.dblSKYOUT(i)         '//�x���i�o��
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "�����݌�,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKZTRA.dblLAST_STOCK(i)      '//�����݌�
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		'''''        strBuff = ""
		'''''        For i = 0 To 35
		'''''            strBuff = strBuff & musrHKKZTRA.strLMZZKM(i)          '//�݌ɐ؂�}�[�N
		'''''            If i < 35 Then
		'''''                strBuff = strBuff & ","
		'''''            End If
		'''''        Next i
		'''''        Print #intFileNo, strBuff
		'''''        strBuff = ""
		'''''        For i = 0 To 35
		'''''            strBuff = strBuff & musrHKKZTRA.strLMZAZM(i)          '//���S�݌ɐ؂�}�[�N
		'''''            If i < 35 Then
		'''''                strBuff = strBuff & ","
		'''''            End If
		'''''        Next i
		'''''        Print #intFileNo, strBuff
		'''''        strBuff = ""
		'''''        For i = 0 To 35
		'''''            strBuff = strBuff & musrHKKZTRA.strLMZMZKM(i)         '//�����݌ɐ؂�}�[�N
		'''''            If i < 35 Then
		'''''                strBuff = strBuff & ","
		'''''            End If
		'''''        Next i
		'''''        Print #intFileNo, strBuff
		'''''        strBuff = ""
		'''''        For i = 0 To 35
		'''''            strBuff = strBuff & musrHKKZTRA.strLMZMAZM(i)         '//�������S�݌ɐ؂�}�[�N
		'''''            If i < 35 Then
		'''''                strBuff = strBuff & ","
		'''''            End If
		'''''        Next i
		'''''        Print #intFileNo, strBuff
		'''''        strBuff = ""
		'''''        For i = 0 To 35
		'''''            strBuff = strBuff & musrHKKZTRA.dblLMZZKT(i)          '//�݌Ɍ���
		'''''            If i < 35 Then
		'''''                strBuff = strBuff & ","
		'''''            End If
		'''''        Next i
		'''''        Print #intFileNo, strBuff
		''''        strBuff = "�����Č�,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrMKMTRA.dblMKMAK(i)            '//�����Č�
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "��������,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrMKMTRA.dblMKMMT(i)            '//��������
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "�����o�ɗ\��,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrMKMTRA.dblMKMOUTTRA(i)        '//�����o�ɗ\��
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "���������݌�,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrMKMTRA.dblMKMLST(i)           '//���������݌�
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "�����ϐ�,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrODINTRA.dblLMAODSSA(i)        '//�����ϐ�
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "�ً}������,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrODINTRA.dblLMAKODSA(i)        '//�ً}������
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "���Ɏw���ϐ�,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrODINTRA.dblLMZNOSSA(i)        '//���Ɏw���ϐ�
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "���Ɍv�搔,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrODINTRA.dblDspINPPLAN(i)         '//���Ɍv�搔
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "���Ɏw����,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrODINTRA.strLMZNOSS(i)         '//���Ɏw����
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        Close intFileNo
		''''
		''''    '//V1.10 2006/10/17  ADD START  RISE)
		''''        '//�I�����ꂽ�t�@�C���̈ړ�
		''''        On Error Resume Next
		''''        Kill str_DialogFilePath & str_DialogFileName
		''''        FileCopy gvstrFilePath4 & "\" & str_FileName, str_DialogFilePath & str_DialogFileName
		''''        Kill gvstrFilePath4 & "\" & str_FileName
		''''        On Error GoTo 0
		''''    '//V1.10 2006/10/17  ADD END  RISE)
		''''
		''''        ClsMessage.MsgLibrary gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "208"
		''''    End If
		''''
		''''    '//V1.10 2006/10/17  ADD START  RISE)
		'''''----------------------------------------------------------------------------------------
		''''EXIT_STEP:
		''''    Call D0.Mouse_OFF
		''''    Exit Sub
		'''''----------------------------------------------------------------------------------------
		''''    '//V1.10 2006/10/17  ADD END  RISE)
	End Sub
	
    Private Sub cmdMONTH_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMONTH.Click
        Dim Index As Short = cmdMONTH.GetIndex(eventSender)

        '// 2007/02/24 �� ADD STR
        'UPGRADE_WARNING: �I�u�W�F�N�g gvvntTop �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gvvntTop = VB6.PixelsToTwipsY(Me.Top)
        'UPGRADE_WARNING: �I�u�W�F�N�g gvvntLeft �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
        '// 2007/02/24 �� ADD STR

        '//�ڍ׏��\�����b�Z�[�W
        If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "204") = MsgBoxResult.Yes Then
            gvintIndex = Index
            '//V1.10 2006/09/20  CHG START  RISE)
            'HKKET143F.Show vbModal
            'Unload HKKET143F
            Me.Visible = False
            '2019/04/15 CHG START
            'HKKET143F.Show()
            HKKET143F.ShowDialog()
            '2019/04/15 CHG E N D
            '//V1.10 2006/09/20  CHG E N D  RISE)
        End If

    End Sub

	Private Sub cmdNEXTHINCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNEXTHINCD.Click
		
		'// 2007/02/24 �� ADD STR
		'UPGRADE_WARNING: �I�u�W�F�N�g gvvntTop �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gvvntTop = VB6.PixelsToTwipsY(Me.Top)
		'UPGRADE_WARNING: �I�u�W�F�N�g gvvntLeft �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
		'// 2007/02/24 �� ADD STR
		
		If gvintNowItem + 1 > UBound(musrHKKZTR.strHINCD) Then
			ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "214")
			GoTo EXIT_STEP
		End If
		
		If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "211") = MsgBoxResult.No Then
			GoTo EXIT_STEP
		End If
		
		gvstrDisplayID = "E02"
		
		gvlngNowPage = gvlngDefaultPage
		gvintNowItem = gvintNowItem + 1
		
		'// 2008/05/26 �� DEL STR �N���v��捞�Ή�
		'    If gvblnInputFlg Then
		'        gvblnLMAHMS = True
		'        gvblnLMZNOS = True
		'    Else
		'        gvblnLMAHMS = False
		'        gvblnLMZNOS = False
		'    End If
		'// 2008/05/26 �� DEL STR
		
		Me.txtNOWPAGE.Text = CStr(gvintNowItem)
		
		'//��ʏ�����
		If Not HKKET142M.Set_Initialize Then
			'//�I������
			Call Ctr_END()
		End If
		
		'// 2008/05/26 �� ADD STR �N���v��捞�Ή�
		If gvblnInputFlg Then
			gvblnLMAHMS = True
			gvblnLMZNOS = True
		Else
			gvblnLMAHMS = False
			gvblnLMZNOS = False
		End If
		'// 2008/05/26 �� DEL STR
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Sub
		'----------------------------------------------------------------------------------------
	End Sub
	
	Private Sub cmdNEXTMONTH_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNEXTMONTH.Click
		
		'//�O��ʁE����ʏ���
		Call Ctr_PagePrevNext("N")
		
	End Sub
	
	Private Sub cmdPREMONTH_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPREMONTH.Click
		
		'//�O��ʁE����ʏ���
		Call Ctr_PagePrevNext("P")
		
	End Sub
	
	Private Sub cmdPREVHINCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPREVHINCD.Click
		
		'// 2007/02/24 �� ADD STR
		'UPGRADE_WARNING: �I�u�W�F�N�g gvvntTop �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gvvntTop = VB6.PixelsToTwipsY(Me.Top)
		'UPGRADE_WARNING: �I�u�W�F�N�g gvvntLeft �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
		'// 2007/02/24 �� ADD STR
		
		If gvintNowItem - 1 < 1 Then
			ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "215")
			GoTo EXIT_STEP
		End If
		
		If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "210") = MsgBoxResult.No Then
			GoTo EXIT_STEP
		End If
		
		gvstrDisplayID = "E02"
		
		gvlngNowPage = gvlngDefaultPage
		gvintNowItem = gvintNowItem - 1
		
		'// 2008/05/26 �� DEL STR �N���v��捞�Ή�
		'    If gvblnInputFlg Then
		'        gvblnLMAHMS = True
		'        gvblnLMZNOS = True
		'    Else
		'        gvblnLMAHMS = False
		'        gvblnLMZNOS = False
		'    End If
		'// 2008/05/26 �� DEL STR
		
		Me.txtNOWPAGE.Text = CStr(gvintNowItem)
		
		'//��ʏ�����
		If Not HKKET142M.Set_Initialize Then
			'//�I������
			Call Ctr_END()
		End If
		
		'// 2008/05/26 �� ADD STR �N���v��捞�Ή�
		If gvblnInputFlg Then
			gvblnLMAHMS = True
			gvblnLMZNOS = True
		Else
			gvblnLMAHMS = False
			gvblnLMZNOS = False
		End If
		'// 2008/05/26 �� ADD STR
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Sub
		'----------------------------------------------------------------------------------------
	End Sub
	
	
	Private Sub cmdRETURN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRETURN.Click
		
		'// 2007/02/24 �� ADD STR
		'UPGRADE_WARNING: �I�u�W�F�N�g gvvntTop �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gvvntTop = VB6.PixelsToTwipsY(Me.Top)
		'UPGRADE_WARNING: �I�u�W�F�N�g gvvntLeft �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
		'// 2007/02/24 �� ADD STR
		
		gvstrDisplayID = "E01"
		Me.Close()
	End Sub
	
	Private Sub cmdUPD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUPD.Click
		
		'//V1.10 2006/10/17  ADD START  RISE)
		Dim str_DialogFilePath As String
        Dim str_DialogFileName As String
        '2019/04/19 CHG START
        'Dim str_FileName As String
        Dim str_FileName As String = ""
        '2019/04/19 CHG E N D
        '//V1.10 2006/10/17  ADD END    RISE)
		
		'// 2007/01/28 �� ADD START
		cmdUPD.Enabled = False
		'// 2007/01/28 �� ADD END
		
		'// V2.20�� ADD
		If Chk_YuusenFlg = False Then
			GoTo EXIT_STEP
		End If
		'// V2.20�� ADD
		
		'// 2007/01/09 �� ADD STR
		If Not Set_CalcData Then
			GoTo EXIT_STEP
		End If
		'// 2007/01/09 �� ADD END
		
		'// 2007/01/09 �� ADD STR
		If Not Chk_Hacyusu Then
			GoTo EXIT_STEP
		End If
		'// 2007/01/09 �� ADD END
		
		If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "217") = MsgBoxResult.No Then
			GoTo EXIT_STEP
		End If
		
        '//��ݻ޸��ݐ���J�n
        '2019/04/19 CHG START
        'clsOra.OraBeginTrans()
        Call DB_BeginTrans(CON)
        '2019/04/19 CHG E N D

		Call D0.Mouse_ON()
		If Not Upd_Main(str_FileName) Then
			ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "222")
            Call D0.Mouse_OFF()
            '2019/04/19 CHG START
            'clsOra.OraRollback()
            Call DB_Rollback()
            '2019/04/19 CHG E N D
            GoTo EXIT_STEP
		End If
		Call D0.Mouse_OFF()
		
        '//��ݻ޸��ݐ���J�n
        '2019/04/22 CHG START
        'clsOra.OraCommitTrans()
        Call DB_Commit()
        '2019/04/22 CHG E N D

		'// 2007/01/09 �� ADD STR
		If gvblnLMZNOS = True And gvstrHINKB = "3" Or gvstrHINKB = "4" Or gvstrHINKB = "5" Then
			
			'//�O���t�b�r�u�쐬
			Call Cra_GraphCSV(gvstrFilePath6, str_FileName)
			
		End If
		'// 2007/01/09 �� ADD END
		
		'// 2007/01/09 �� DEL STR
		'''''// 2006/10/27 �� ADD STR
		'''''// 2006/11/07 �� ADD STR
		''''    If gvblnLMZNOS = True And gvstrHINKB = "3" Or _
		'''''                              gvstrHINKB = "4" Or _
		'''''                              gvstrHINKB = "5" Then
		''''        '//�_�C�A���O�{�b�N�X�N��
		''''        str_DialogFileName = str_FileName
		''''        If Not Run_DialogBox(cdl_SAVE2, str_DialogFilePath, str_DialogFileName) Then
		''''            GoTo EXIT_STEP
		''''        End If
		''''
		''''        '//�I�����ꂽ�t�@�C���̈ړ�
		''''        On Error Resume Next
		''''        Kill str_DialogFilePath & str_DialogFileName
		''''        FileCopy gvstrFilePath6 & "\" & str_FileName, str_DialogFilePath & str_DialogFileName
		''''        Kill gvstrFilePath6 & "\" & str_FileName
		''''        On Error GoTo 0
		''''    End If
		'''''// 2006/11/06 �� REP,END
		'// 2007/01/09 �� DEL END
		
		ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "221")
		
		ReDim musrHKKTRA.strLMAHKS(0)
		ReDim musrHKKTRA.blnLMAHKS(0)
		ReDim musrHKKTRA.strLMAHMS(0)
		ReDim musrHKKTRA.blnLMAHMS(0)
		
		ReDim musrHKKZTRA.strDSPMONTH(0)
		ReDim musrHKKZTRA.dblLAST_JDNTR(0)
		ReDim musrHKKZTRA.dblLAST_ODNTRA(0)
		ReDim musrHKKZTRA.dblLAST_HDNTRA(0)
		ReDim musrHKKZTRA.dblINPTRA(0)
		ReDim musrHKKZTRA.dblOUTTRA(0)
		ReDim musrHKKZTRA.dblSKYOUT(0)
		ReDim musrHKKZTRA.dblLAST_STOCK(0)
		ReDim musrHKKZTRA.strLMZLDT(0)
		ReDim musrHKKZTRA.strLMZHDT(0)
		ReDim musrHKKZTRA.strLMZZKM(0)
		ReDim musrHKKZTRA.strLMZAZM(0)
		ReDim musrHKKZTRA.strLMZMZKM(0)
		ReDim musrHKKZTRA.strLMZMAZM(0)
		ReDim musrHKKZTRA.dblLMZZKT(0)
		ReDim musrHKKZTRA.dblLMAVZS(0)
		
		ReDim musrMKMTRA.dblMKMAK(0)
		ReDim musrMKMTRA.dblMKMAK(0)
		ReDim musrMKMTRA.dblMKMMT(0)
		ReDim musrMKMTRA.dblMKMOUTTRA(0)
		ReDim musrMKMTRA.dblMKMLST(0)
		
		ReDim musrODINTRA.dblLMAODSSA(0)
		ReDim musrODINTRA.dblLMAKODSA(0)
		ReDim musrODINTRA.dblLMZNOSSA(0)
		ReDim musrODINTRA.strINPPLAN(0)
		ReDim musrODINTRA.dblDspINPPLAN(0)
		ReDim musrODINTRA.strLMZNOSS(0)
		'// V2.20�� ADD
		ReDim musrODINTRA.strLMZNPF(0)
		ReDim musrODINTRA.strLMZNPF_ORG(0)
		'// V2.20�� ADD
		
		'//��ʕ\���ɕK�v�ȃf�[�^���擾���\������
		If Not HKKET142M.Get_DisplayData Then
			GoTo EXIT_STEP
		End If
		
		If Not HKKET142M.Set_DisplayData(gvlngNowPage) Then
			GoTo EXIT_STEP
		End If
		
		gvblnLMAHMS = False
		gvblnLMZNOS = False
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		'// 2007/01/28 �� ADD START
		cmdUPD.Enabled = True
		Call Ctr_Setfocus(cmdUPD)
		'    cmdUPD.SetFocus
		'// 2007/01/28 �� ADD END
		On Error GoTo 0
		Exit Sub
		'----------------------------------------------------------------------------------------
	End Sub
	
	
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    Form
	'//*
	'//* <�߂�l>
	'//*
	'//* <��  ��>     ���ږ�              I/O      ���e
	'//*
	'//* <��  ��>
	'//*    Form EVENT
	'//*****************************************************************************************
	'UPGRADE_WARNING: Form �C�x���g HKKET142F.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub HKKET142F_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		'// 2007/02/24 �� ADD STR
		Call SetFormInitOrg(Me, 1)
        '// 2007/02/24 �� ADD STR
        '//�t�H�[�J�X�R���g���[��
        'change start 20190930 kuwa
        'ClsFocus.SetFocusCtrl(Me)
        ClsFocus.SetFocusCtrl2(Me)
        'change end 20190930 kuwa
    End Sub

    Private Sub HKKET142F_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        '// V2.01 �� ADD
        Dim ShiftTest As Short
        '// V2.01 �� ADD

        '//Enter�L�[�Ŏ����ڂֈړ�
        Select Case ClsFocus.GetKeyDown(KeyCode)
            Case System.Windows.Forms.Keys.Return
                'change start 20190930 kuwa
                'ClsFocus.EnterNext()
                ClsFocus.EnterNext(False, DirectCast(eventSender, System.Windows.Forms.ContainerControl).ActiveControl.Name)
                'change end 20190930 kuwa
                '// 2007/02/28 �� ADD STR
            Case System.Windows.Forms.Keys.F1
                'add start 20190927 �t�H�[�J�X���ڂ��Ȃ���΁AValidate�̏�����ʂ�Ȃ����ߒǉ�
                cmdCALC.Focus()
                'add end 20190927 kuwa
                Call cmdCALC_Click(cmdCALC, New System.EventArgs())
                'C2-20170418-02 CHG START 2017/04/18 �x�m�ʁj���{
                '�r�����䂪�������Ă���ꍇ��F5�𖳌������鏈���ǉ�
                'Case vbKeyF5
                '   Call cmdUPD_Click
            Case System.Windows.Forms.Keys.F5
                If gvintPGHaita = 9 Then
                Else
                    Call cmdUPD_Click(cmdUPD, New System.EventArgs())
                End If
                'C2-20170418-02 CHG START 2017/04/18 �x�m�ʁj���{
                '// 2007/02/28 �� ADD END
                '// 2007/08/18 �� ADD STR
            Case System.Windows.Forms.Keys.F3
                Call cmdPREVHINCD_Click(cmdPREVHINCD, New System.EventArgs())
            Case System.Windows.Forms.Keys.F4
                '// V2.01 �� ADD
                ShiftTest = Shift And 7
                Select Case ShiftTest
                    Case 4 ' Alt �L�[��������܂����B
                        Exit Sub
                    Case 5 ' Shift �� Alt �L�[��������܂����B
                        Exit Sub
                End Select
                '// V2.01 �� ADD
                Call cmdNEXTHINCD_Click(cmdNEXTHINCD, New System.EventArgs())
                '// 2007/08/18 �� ADD END
                '// 2007/09/10 �� ADD STR
            Case System.Windows.Forms.Keys.F12
                Call cmdRETURN_Click(cmdRETURN, New System.EventArgs())
                '// 2007/09/10 �� ADD END
                '// 2008/11/17 �� ADD STR
            Case System.Windows.Forms.Keys.F6 '//F6:�N���v��ֶ��وړ�
                KeyCode = 0
                txtLMAHKS(0).Focus()
            Case System.Windows.Forms.Keys.F7 '//F7:�����v��ֶ��وړ�
                KeyCode = 0
                txtLMAHMS(0).Focus()
            Case System.Windows.Forms.Keys.F8 '//F8:�A�g�ֶ��وړ�
                KeyCode = 0
                txtINPPLAN(0).Focus()
            Case System.Windows.Forms.Keys.F9 '//F9:�D��ֶ��وړ�
                KeyCode = 0
                txtLMZNPF(0).Focus()
            Case System.Windows.Forms.Keys.F10 '//F10:���Ɏw���ֶ��وړ�
                KeyCode = 0
                txtLMZNOSS(0).Focus()
                '// 2008/11/17 �� ADD end

        End Select
    End Sub
    Private Sub HKKET142F_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'// 2007/02/24 �� ADD STR
		'UPGRADE_WARNING: �I�u�W�F�N�g gvvntTop �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Me.Top = VB6.TwipsToPixelsY(gvvntTop)
		'UPGRADE_WARNING: �I�u�W�F�N�g gvvntLeft �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Me.Left = VB6.TwipsToPixelsX(gvvntLeft)
		'// 2007/02/24 �� ADD STR
		
		gvstrDisplayID = "E02"
		
		If gvblnInputFlg Then
			gvblnLMAHMS = True
			gvblnLMZNOS = True
		Else
			gvblnLMAHMS = False
			gvblnLMZNOS = False
		End If
		
		If Mid(gvstrUNYDT, 5, 2) = "01" Or Mid(gvstrUNYDT, 5, 2) = "02" Or Mid(gvstrUNYDT, 5, 2) = "03" Then
			gvlngNowPage = CDbl(Mid(gvstrUNYDT, 5, 2)) + 20
		Else
			gvlngNowPage = CDbl(Mid(gvstrUNYDT, 5, 2)) + 8
		End If
		
		gvlngDefaultPage = gvlngNowPage
		
		'//��ʏ�����
		If Not HKKET142M.Set_Initialize Then
			'//�I������
			Call Ctr_END()
		End If

        '2019/04/24 ADD START
        Call SetBar(Me)
        '2019/04/24 ADD E N D

    End Sub
	
	'// 2007/02/24 �� ADD STR
	Private Sub HKKET142F_Paint(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
		'UPGRADE_WARNING: �I�u�W�F�N�g gvvntLeft �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
		'UPGRADE_WARNING: �I�u�W�F�N�g gvvntTop �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gvvntTop = VB6.PixelsToTwipsY(Me.Top)
	End Sub
	'// 2007/02/24 �� ADD STR
	
	Private Sub HKKET142F_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '2019/04/15 DEL START
        'Dim Cancel As Boolean = eventArgs.Cancel
        '2019/04/15 DEL E N D
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		
		'// 2007/02/24 �� ADD STR
		'UPGRADE_WARNING: �I�u�W�F�N�g gvvntTop �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gvvntTop = VB6.PixelsToTwipsY(Me.Top)
		'UPGRADE_WARNING: �I�u�W�F�N�g gvvntLeft �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
		'// 2007/02/24 �� ADD STR
		
		'//�I�����b�Z�[�W
		If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "213") = MsgBoxResult.No Then
            '2019/04/15 CHG START
            'Cancel = True
            eventArgs.Cancel = True
            '2019/04/15 CHG E N D
            Exit Sub
		End If
		'//V1.10 2006/09/20  ADD START  RISE)
		HKKET141F.Visible = True
		'//V1.10 2006/09/20  ADD E N D  RISE)
        '2019/04/15 CHG START
        'eventArgs.Cancel = Cancel
        eventArgs.Cancel = False
        '2019/04/15 CHG E N D
    End Sub
	
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    txtINPPLAN
	'//*
	'//* <�߂�l>
	'//*
	'//* <��  ��>     ���ږ�              I/O      ���e
	'//*
	'//* <��  ��>
	'//*    txtINPPLAN EVENT
	'//*****************************************************************************************
	Private Sub txtINPPLAN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtINPPLAN.Enter
		Dim Index As Short = txtINPPLAN.GetIndex(eventSender)
		
		'//GotFocus����
		Call Set_ObjectGotFocus(txtINPPLAN(Index), Index)
		
	End Sub
	Private Sub txtINPPLAN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtINPPLAN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtINPPLAN.GetIndex(eventSender)
		'//���͉\�L�[�̐ݒ�
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
			Case System.Windows.Forms.Keys.Back
            Case System.Windows.Forms.Keys.Return
                '2019/04/11 CHG START
                'Call txtINPPLAN_Validating(txtINPPLAN.Item(Index), New System.ComponentModel.CancelEventArgs(Index, False))
                Call txtINPPLAN_Validating(eventSender, New System.ComponentModel.CancelEventArgs())
                '2019/04/11 CHG E N D
            Case 1 To 26
            Case Else
                KeyAscii = 0
        End Select
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Sub txtINPPLAN_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtINPPLAN.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim Index As Short = txtINPPLAN.GetIndex(eventSender)
		
		'//���Ɍv��
		musrODINTRA.strINPPLAN(gvlngNowPage + Index) = Me.txtINPPLAN(Index).Text
		
		If Trim(musrODINTRA.strINPPLAN_ORG(gvlngNowPage + Index)) <> Trim(musrODINTRA.strINPPLAN(gvlngNowPage + Index)) Then
			gvblnLMZNOS = True
		End If
		
		eventArgs.Cancel = Cancel
	End Sub
	
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    txtLMAHKS
	'//*
	'//* <�߂�l>
	'//*
	'//* <��  ��>     ���ږ�              I/O      ���e
	'//*
	'//* <��  ��>
	'//*    txtLMAHKS EVENT
	'//*****************************************************************************************
	Private Sub txtLMAHKS_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtLMAHKS.Enter
		Dim Index As Short = txtLMAHKS.GetIndex(eventSender)
		
		'//GotFocus����
		Call Set_ObjectGotFocus(txtLMAHKS(Index), Index)
		
	End Sub
	Private Sub txtLMAHKS_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtLMAHKS.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtLMAHKS.GetIndex(eventSender)
		'//���͉\�L�[�̐ݒ�
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
			Case System.Windows.Forms.Keys.Back
            Case System.Windows.Forms.Keys.Return
                '2019/04/11 CHG START
                'Call txtLMAHKS_Validating(txtLMAHKS.Item(Index), New System.ComponentModel.CancelEventArgs(Index, False))
                Call txtLMAHKS_Validating(eventSender, New System.ComponentModel.CancelEventArgs())
                '2019/04/11 CHG E N D
            Case 1 To 26
            Case Else
                KeyAscii = 0
        End Select
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtLMAHKS_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtLMAHKS.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim Index As Short = txtLMAHKS.GetIndex(eventSender)
		
		'//�N���v��
		'If Not musrHKKTRA.blnLMAHKS(gvlngNowPage + Index) Then
		If Trim(musrODINTRA.strLMZNOSS(gvlngNowPage + Index)) <> "" Then
			If Trim(Me.txtLMAHKS(Index).Text) <> "" And Trim(musrHKKTRA.strLMAHKS_ORG(gvlngNowPage + Index)) = "" Then
				Me.txtLMAHKS(Index).Text = Trim(musrHKKTRA.strLMAHKS(gvlngNowPage + Index))
				ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "202")
				GoTo EventExitSub
			End If
		End If
		
		'//�N���v��
		musrHKKTRA.strLMAHKS(gvlngNowPage + Index) = Me.txtLMAHKS(Index).Text
		If Trim(musrHKKTRA.strLMAHKS_ORG(gvlngNowPage + Index)) <> Trim(musrHKKTRA.strLMAHKS(gvlngNowPage + Index)) Then
			gvblnLMAHMS = True
		End If
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    txtLMAHMS
	'//*
	'//* <�߂�l>
	'//*
	'//* <��  ��>     ���ږ�              I/O      ���e
	'//*
	'//* <��  ��>
	'//*    txtLMAHMS EVENT
	'//*****************************************************************************************
	Private Sub txtLMAHMS_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtLMAHMS.Enter
		Dim Index As Short = txtLMAHMS.GetIndex(eventSender)
		
		'//GotFocus����
		Call Set_ObjectGotFocus(txtLMAHMS(Index), Index)
		
	End Sub
	
	Private Sub txtLMAHMS_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtLMAHMS.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtLMAHMS.GetIndex(eventSender)
		'//���͉\�L�[�̐ݒ�
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
			Case System.Windows.Forms.Keys.Back
            Case System.Windows.Forms.Keys.Return
                '2019/04/11 CHG START
                'Call txtLMAHMS_Validating(txtLMAHMS.Item(Index), New System.ComponentModel.CancelEventArgs(Index, False))
                Call txtLMAHMS_Validating(eventSender, New System.ComponentModel.CancelEventArgs())
                '2019/04/11 CHG E N D
			Case 1 To 26
			Case Else
				KeyAscii = 0
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtLMAHMS_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtLMAHMS.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim Index As Short = txtLMAHMS.GetIndex(eventSender)
		
		'// 2007/02/21 �� DEL STR
		''''    '//�����v��
		''''    'If Not musrHKKTRA.blnLMAHMS(gvlngNowPage + Index) Then
		'''''// 2006/11/14 �� UPD STR�@�R�����g�A�E�g�ɂȂ��Ă��������𕜊�
		''''    If Trim(musrODINTRA.strLMZNOSS(gvlngNowPage + Index)) <> "" Then
		'''''    If Trim(musrHKKTRA.strLMAHMS(gvlngNowPage + Index)) <> "" Then
		'''''// 2006/11/14 �� UPD END
		''''        If Trim(HKKET142F.txtLMAHMS(Index).Text) <> "" And Trim(musrHKKTRA.strLMAHMS_ORG(gvlngNowPage + Index)) = "" Then
		''''            HKKET142F.txtLMAHMS(Index).Text = Trim(musrHKKTRA.strLMAHMS(gvlngNowPage + Index))
		''''            ClsMessage.MsgLibrary gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "202"
		''''            Exit Sub
		''''        End If
		''''    End If
		'// 2007/02/21 �� DEL END
		
		'//�����v��
		musrHKKTRA.strLMAHMS(gvlngNowPage + Index) = Me.txtLMAHMS(Index).Text
		If Trim(musrHKKTRA.strLMAHMS_ORG(gvlngNowPage + Index)) <> Trim(musrHKKTRA.strLMAHMS(gvlngNowPage + Index)) Then
			gvblnLMAHMS = True
		End If
		
		eventArgs.Cancel = Cancel
	End Sub
	
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    txtLMZNOSS
	'//*
	'//* <�߂�l>
	'//*
	'//* <��  ��>     ���ږ�              I/O      ���e
	'//*
	'//* <��  ��>
	'//*    txtLMZNOSS EVENT
	'//*****************************************************************************************
    Private Sub txtLMZNOSS_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtLMZNOSS.Enter
        Dim Index As Short = txtLMZNOSS.GetIndex(eventSender)
        '//GotFocus����
        Call Set_ObjectGotFocus(txtLMZNOSS(Index), Index)

    End Sub
	
    Private Sub txtLMZNOSS_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtLMZNOSS.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = txtLMZNOSS.GetIndex(eventSender)
        '//���͉\�L�[�̐ݒ�
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
            Case System.Windows.Forms.Keys.Back
            Case System.Windows.Forms.Keys.Return
                '2019/04/11 CHG START
                'Call txtLMZNOSS_Validating(txtLMZNOSS.Item(Index), New System.ComponentModel.CancelEventArgs(Index, False))
                Call txtLMZNOSS_Validating(eventSender, New System.ComponentModel.CancelEventArgs())
                '2019/04/11 CHG E N D
            Case 1 To 26
            Case Else
                KeyAscii = 0
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtLMZNOSS_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtLMZNOSS.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim Index As Short = txtLMZNOSS.GetIndex(eventSender)

        Dim strDate As String

        '//���Ɏw��
        If System.Drawing.ColorTranslator.ToOle(Me.txtLMZNOSS(Index).BackColor) = gvcst_COLOR_DAIDAIIRO Then
            If Trim(musrODINTRA.strLMZNOSS_ORG(gvlngNowPage + Index)) <> "" Then
                If Val(musrODINTRA.strLMZNOSS_ORG(gvlngNowPage + Index)) < Val(Me.txtLMZNOSS(Index).Text) Then
                    Me.txtLMZNOSS(Index).Text = Trim(musrODINTRA.strLMZNOSS(gvlngNowPage + Index))
                    ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "220")
                    GoTo EventExitSub
                End If
            End If
        End If

        '//���Ɏw��
        musrODINTRA.strLMZNOSS(gvlngNowPage + Index) = Me.txtLMZNOSS(Index).Text

        If Trim(musrODINTRA.strLMZNOSS_ORG(gvlngNowPage + Index)) <> Trim(musrODINTRA.strLMZNOSS(gvlngNowPage + Index)) Then
            gvblnLMZNOS = True
        End If

        If Trim(Me.txtLMZNOSS(Index).Text) = "" Then
            '//�N���v��
            musrHKKTRA.blnLMAHKS(gvlngNowPage + Index) = True
            '//�����v��
            musrHKKTRA.blnLMAHMS(gvlngNowPage + Index) = True
        Else
            '//�N���v��
            musrHKKTRA.blnLMAHKS(gvlngNowPage + Index) = False
            '//�����v��
            musrHKKTRA.blnLMAHMS(gvlngNowPage + Index) = False
        End If

        '// V2.00�� ADD
        If Trim(Me.txtLMZNOSS(Index).Text) <> "" And Val(Trim(Me.txtLMZNOSS(Index).Text)) <> 0 Then
            '//���Ɏw�������͂��ꂽ�̂Ń��b�N����
            Me.txtINPPLAN(Index).ReadOnly = True
            Me.txtINPPLAN(Index).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
            '// V2.20�� ADD
            Me.txtLMZNPF(Index).ReadOnly = True
            Me.txtLMZNPF(Index).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
            '// V2.20�� ADD
        Else
            '//���Ɏw���������͏�Ԃɂ��ꂽ�̂Ń��b�N����
            Select Case musrHKKTRA.intLTKBN(gvlngNowPage + Index)
                Case 0
                    Me.txtINPPLAN(Index).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFC0) ' �����O���[��
                    '// V2.20�� ADD
                    Me.txtLMZNPF(Index).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFC0) ' �����O���[��
                    '// V2.20�� ADD
                Case 1
                    Me.txtINPPLAN(Index).BackColor = System.Drawing.ColorTranslator.FromOle(&H80C0FF) ' �I�����W
                    '// V2.20�� ADD
                    Me.txtLMZNPF(Index).BackColor = System.Drawing.ColorTranslator.FromOle(&H80C0FF) ' �I�����W
                    '// V2.20�� ADD
                Case 2
                    Me.txtINPPLAN(Index).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFFF) ' �������F
                    '// V2.20�� ADD
                    Me.txtLMZNPF(Index).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFFF) ' �������F
                    '// V2.20�� ADD
            End Select
        End If
        '// V2.00�� ADD

EventExitSub:
        eventArgs.Cancel = Cancel
    End Sub
	
	'// V2.20�� ADD
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    txtLMZNPF
	'//*
	'//* <�߂�l>
	'//*
	'//* <��  ��>     ���ږ�              I/O      ���e
	'//*
	'//* <��  ��>
	'//*    txtLMZNPF EVENT
	'//*****************************************************************************************
	Private Sub txtLMZNPF_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtLMZNPF.Enter
		Dim Index As Short = txtLMZNPF.GetIndex(eventSender)
		'//GotFocus����
		Call Set_ObjectGotFocus(txtLMZNPF(Index), Index)
		
	End Sub
	
	Private Sub txtLMZNPF_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtLMZNPF.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtLMZNPF.GetIndex(eventSender)
		'//���͉\�L�[�̐ݒ�
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
			Case System.Windows.Forms.Keys.Back
            Case System.Windows.Forms.Keys.Return
                '2019/04/11 CHG START
                'Call txtLMZNPF_Validating(txtLMZNPF.Item(Index), New System.ComponentModel.CancelEventArgs(Index, False))
                Call txtLMZNPF_Validating(eventSender, New System.ComponentModel.CancelEventArgs())
                '2019/04/11 CHG E N D
			Case 1 To 26
			Case Else
				KeyAscii = 0
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtLMZNPF_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtLMZNPF.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim Index As Short = txtLMZNPF.GetIndex(eventSender)
		
		'//�����ҏW
		If Trim(Me.txtLMZNPF(Index).Text) = "" Then
			Me.txtLMZNPF(Index).Text = "0   "
		Else
			Me.txtLMZNPF(Index).Text = Mid(Trim(Me.txtLMZNPF(Index).Text) & "    ", 1, 4)
		End If
		
		'//�D��t���O�Z�b�g
		musrODINTRA.strLMZNPF(gvlngNowPage + Index) = Me.txtLMZNPF(Index).Text
		
		'//�ύX�����邩�m�F������ꍇ�� gvblnLMZNOS �� True �ɂ���
		If musrODINTRA.strLMZNPF_ORG(gvlngNowPage + Index) <> musrODINTRA.strLMZNPF(gvlngNowPage + Index) Then
			gvblnLMZNOS = True
		End If
		
		eventArgs.Cancel = Cancel
	End Sub
	'// V2.20�� ADD
	
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    txtMEMO
	'//*
	'//* <�߂�l>
	'//*
	'//* <��  ��>     ���ږ�              I/O      ���e
	'//*
	'//* <��  ��>
	'//*    txtMEMO EVENT
	'//*****************************************************************************************
	Private Sub txtMEMO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMEMO.Enter
		
		'//GotFocus����
		Call Set_ObjectGotFocus(txtMEMO)
		
	End Sub
	
	Private Sub txtMEMO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtMEMO.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'//���͉\�L�[�̐ݒ�
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Back
			Case System.Windows.Forms.Keys.Return
			Case 1 To 26
			Case Else
				If D0.Get_TextLength(txtMEMO.Text) >= 100 Then
					KeyAscii = 0
				End If
		End Select
		
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class