Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class HKKET141F
	Inherits System.Windows.Forms.Form

    '2019/04/11 ADD START
    Private ClsMessage As New ClsMessage
    '2019/04/11 ADD E N D

    '2019/04/16 ADD START
    'ListViewItemSorter�Ɏw�肷��t�B�[���h
    Public LvSorter141F As ListViewItemComparer
    '2019/04/16 ADD E N D

	Private Sub cmdALL_RELEASE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdALL_RELEASE.Click
		
		Dim i As Integer
		'UPGRADE_ISSUE: ListItem �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'Dim objLitem As ListItem
        Dim objLitem As ListViewItem
        '2019/04/11 CHG E N D

		'UPGRADE_WARNING: �I�u�W�F�N�g lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'If lvwMEISAI.ListItems.Count = 0 Then
        If lvwMEISAI.Items.Count = 0 Then
            '2019/04/11 CHG E N D
            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "108")
            'delete start 20190927 kuwa
            'End If

            'change start 20190927 kuwa
            '//�S�������b�Z�[�W
            'If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "109") = MsgBoxResult.Yes Then
        ElseIf ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "109") = MsgBoxResult.Yes Then
            'change end 20190927 kuwa
            'delete start 20190927 kuwa
            'End If
            'delete end 20190927 kuwa
            '//���ׂ��I����Ԃɂ���B
            'UPGRADE_WARNING: �I�u�W�F�N�g lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/11 CHG START
            'For i = 1 To lvwMEISAI.ListItems.Count
            For i = 0 To lvwMEISAI.Items.Count - 1
                '2019/04/11 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/11 CHG START
                'objLitem = Me.lvwMEISAI.ListItems.Item(i)
                objLitem = Me.lvwMEISAI.Items.Item(i)
                '2019/04/11 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.Checked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                objLitem.Checked = False
            Next i
        End If

    End Sub

    Private Sub cmdALL_SELECT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdALL_SELECT.Click

        Dim i As Integer
        'UPGRADE_ISSUE: ListItem �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'Dim objLitem As ListItem
        Dim objLitem As ListViewItem
        '2019/04/11 CHG E N D

        'UPGRADE_WARNING: �I�u�W�F�N�g lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'If lvwMEISAI.ListItems.Count = 0 Then
        If lvwMEISAI.Items.Count = 0 Then
            '2019/04/11 CHG E N D
            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "106")
            'delete start 20190927 kuwa
            'End If
            'delete end 20190927 kuwa
            'change start 20190927 kuwa
            '//�S�I�����b�Z�[�W
            'If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "107") = MsgBoxResult.Yes Then
        ElseIf ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "107") = MsgBoxResult.Yes Then
            'change end 20190927 kuwa
            '//���ׂ�I����Ԃɂ���B
            'UPGRADE_WARNING: �I�u�W�F�N�g lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/11 CHG START
            'For i = 1 To lvwMEISAI.ListItems.Count
            For i = 0 To lvwMEISAI.Items.Count - 1
                '2019/04/11 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/11 CHG START
                'objLitem = Me.lvwMEISAI.ListItems.Item(i)
                objLitem = Me.lvwMEISAI.Items.Item(i)
                '2019/04/11 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.Checked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                objLitem.Checked = True
            Next i
        End If

    End Sub

    Private Sub cmdCSVOUT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCSVOUT.Click

        Dim i As Integer
        Dim j As Integer
        'UPGRADE_ISSUE: ListItem �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'Dim objLitem As ListItem
        Dim objLitem As ListViewItem
        '2019/04/11 CHG E N D
        Dim intFileNo As Short
        Dim strBuff As String

        '//V1.10 2006/10/17  ADD START  RISE)
        Dim str_DialogFilePath As String
        Dim str_DialogFileName As String
        Dim str_FileName As String
        '//V1.10 2006/10/17  ADD END    RISE)

        'UPGRADE_WARNING: �I�u�W�F�N�g lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'If lvwMEISAI.ListItems.Count = 0 Then
        If lvwMEISAI.Items.Count = 0 Then
            '2019/04/11 CHG E N D
            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "110")
            GoTo EXIT_STEP
        End If

        '//V1.10 2006/10/17  CHG START  RISE)
        '//�������ʂb�r�u�o�̓��b�Z�[�W
        If Not (ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "111") = MsgBoxResult.Yes) Then
            GoTo EXIT_STEP
        End If

        '//�t�H���_�̑��݊m�F
        intFileNo = FreeFile()
        'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
        'add test start 20190930 kuwa CSV
        gvstrFilePath3 = "C:\Users\CIS03\Desktop\HKKET14CSV"
        str_DialogFilePath = "C:\Users\CIS03\Desktop\HKKET14CSV"
        'add end 20190930 kuwa
        If Dir(gvstrFilePath3, FileAttribute.Directory) = "" Then
            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "124")
            GoTo EXIT_STEP
        End If

        '//�쐬�t�@�C��������
        str_FileName = gvstrFileName3 & "_" & VB6.Format(Now, "YYYYMMDDHHMMSS") & ".csv"

        '//�_�C�A���O�{�b�N�X�N��
        str_DialogFileName = str_FileName
        If Not Run_DialogBox(cdl_SAVE1, str_DialogFilePath, str_DialogFileName) Then
            GoTo EXIT_STEP
        End If

        '//�b�r�u�o�͏���
        FileOpen(intFileNo, gvstrFilePath3 & "\" & str_FileName, OpenMode.Output)
        strBuff = ""
        'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ColumnHeaders �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'For j = 2 To Me.lvwMEISAI.ColumnHeaders.Count
        For j = 1 To Me.lvwMEISAI.Columns.Count - 1
            '2019/04/11 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ColumnHeaders �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/11 CHG START
            'strBuff = strBuff & Replace(Replace(Me.lvwMEISAI.ColumnHeaders(j).Text, "��", ""), "��", "") & ","
            strBuff = strBuff & Replace(Replace(Me.lvwMEISAI.Columns(j).Text, CON_ARROW_DOWN, ""), CON_ARROW_UP, "") & ","
            '2019/04/11 CHG E N D
        Next j
        PrintLine(intFileNo, Mid(strBuff, 1, Len(strBuff) - 1))
        'UPGRADE_WARNING: �I�u�W�F�N�g lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'For i = 1 To lvwMEISAI.ListItems.Count
        For i = 0 To lvwMEISAI.Items.Count - 1
            '2019/04/11 CHG E N D
            strBuff = ""
            'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/11 CHG START
            'objLitem = Me.lvwMEISAI.ListItems.Item(i)
            objLitem = Me.lvwMEISAI.Items.Item(i)
            '2019/04/11 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ColumnHeaders �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/11 CHG START
            'For j = 1 To Me.lvwMEISAI.ColumnHeaders.Count - 1
            'change start 20190930 kuwa '�A�C�e���ł͂Ȃ��J�����̃J�E���g���������Ă���
            'For j = 0 To Me.lvwMEISAI.Items.Count - 2
            For j = 0 To Me.lvwMEISAI.Columns.Count - 2
                'change end 20190930 kuwa
                '2019/04/11 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/11 CHG START
                'strBuff = strBuff & Me.lvwMEISAI.ListItems(i).SubItems(j) & ","
                strBuff = strBuff & Me.lvwMEISAI.Items(i).SubItems(j).Text & ","
                '2019/04/11 CHG E N D
            Next j
            PrintLine(intFileNo, Mid(strBuff, 1, Len(strBuff) - 1))
        Next i
        FileClose(intFileNo)

        '//�I�����ꂽ�t�@�C���̈ړ�
        On Error Resume Next
        Kill(str_DialogFilePath & str_DialogFileName)
        FileCopy(gvstrFilePath3 & "\" & str_FileName, str_DialogFilePath & str_DialogFileName)
        Kill(gvstrFilePath3 & "\" & str_FileName)
        On Error GoTo 0

        '//�������ʃ��b�Z�[�W
        ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "112")

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        '//V1.10 2006/10/17  DEL START  RISE)
        ''''    On Error GoTo 0
        '//V1.10 2006/10/17  DEL END    RISE)
        Exit Sub
        '----------------------------------------------------------------------------------------

    End Sub
    Private Sub cmdDISPLAY_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDISPLAY.Click

        Dim i As Integer
        Dim j As Integer
        'UPGRADE_ISSUE: ListItem �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'Dim objLitem As ListItem
        Dim objLitem As ListViewItem
        '2019/04/11 CHG E N D
        Dim blnEOF As Boolean

        '// 2007/02/24 �� ADD STR
        'UPGRADE_WARNING: �I�u�W�F�N�g gvvntTop �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gvvntTop = VB6.PixelsToTwipsY(Me.Top)
        'UPGRADE_WARNING: �I�u�W�F�N�g gvvntLeft �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
        '// 2007/02/24 �� ADD STR

        blnEOF = False
        ReDim musrHKKZTR.strHINCD(0)

        '//���ׂ�I����Ԃɂ���B
        j = 1
        'UPGRADE_WARNING: �I�u�W�F�N�g lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'For i = 1 To lvwMEISAI.ListItems.Count
        For i = 0 To lvwMEISAI.Items.Count - 1
            '2019/04/11 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/11 CHG START
            'objLitem = Me.lvwMEISAI.ListItems.Item(i)
            objLitem = Me.lvwMEISAI.Items.Item(i)
            '2019/04/11 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.Checked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If objLitem.Checked Then
                blnEOF = True
                ReDim Preserve musrHKKZTR.strHINCD(j)
                'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/11 CHG START
                'musrHKKZTR.strHINCD(j) = Me.lvwMEISAI.ListItems(i).SubItems(2)
                musrHKKZTR.strHINCD(j) = Me.lvwMEISAI.Items(i).SubItems(2).Text
                '2019/04/11 CHG E N D
                j = j + 1
            End If
        Next i

        If blnEOF Then
            '//�ڍ׏��\�����b�Z�[�W
            If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "119") = MsgBoxResult.Yes Then
                gvintNowItem = 1
                '//V1.10 2006/09/20  CHG START  RISE)
                'HKKET142F.Show vbModal
                'Unload HKKET142F
                Me.Visible = False
                '2019/04/15 CHG START
                'HKKET142F.Show()
                HKKET142F.ShowDialog()
                '2019/04/15 CHG E N D
                '//V1.10 2006/09/20  CHG E N D  RISE)
            End If
        Else
            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "118")
        End If
    End Sub

    Private Sub cmdEND_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEND.Click
        Me.Close()
    End Sub

    Private Sub cmdOUTPUT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOUTPUT.Click

        Dim i As Integer
        Dim j As Integer
        'UPGRADE_ISSUE: ListItem �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'Dim objLitem As ListItem
        Dim objLitem As ListViewItem
        '2019/04/11 CHG E N D
        Dim blnEOF As Boolean
        Dim intFileNo As Short
        Dim strBuff As String
        Dim dblLMAHKSQ As Double
        Dim dblLMAHKSA As Double

        '//V1.10 2006/10/17  ADD START  RISE)
        Dim str_DialogFilePath As String
        Dim str_DialogFileName As String
        Dim str_FileName As String
        '//V1.10 2006/10/17  ADD END    RISE)

        blnEOF = False

        '//�I�𖾍ׂ����݂��邩�H
        'UPGRADE_WARNING: �I�u�W�F�N�g lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'For i = 1 To lvwMEISAI.ListItems.Count
        For i = 0 To lvwMEISAI.Items.Count - 1
            '2019/04/11 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/11 CHG START
            'objLitem = Me.lvwMEISAI.ListItems.Item(i)
            objLitem = Me.lvwMEISAI.Items.Item(i)
            '2019/04/11 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.Checked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If objLitem.Checked Then
                blnEOF = True
            End If
        Next i

        If blnEOF Then
            '//�N���b�r�u�o�̓��b�Z�[�W
            If optVERSION.Checked Then
                If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "121") = MsgBoxResult.No Then
                    GoTo EXIT_STEP
                End If
            Else
                '//�N���b�r�u�o�̓��b�Z�[�W
                If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "114") = MsgBoxResult.No Then
                    GoTo EXIT_STEP
                End If
            End If
            'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
            'add start 20190930 kuwa test CSV
            str_DialogFilePath = "C:\Users\CIS03\Desktop\HKKET14CSV"
            gvstrFilePath2 = "C:\Users\CIS03\Desktop\HKKET14CSV"
            'add end 20190930 kuwa
            If Dir(gvstrFilePath2, FileAttribute.Directory) = "" Then
                ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "124")
                GoTo EXIT_STEP
            End If

            '//V1.10 2006/10/17  CHG START  RISE)
            '//�쐬�t�@�C��������
            str_FileName = gvstrFileName2 & ".CSV"

            '//�_�C�A���O�{�b�N�X�N��
            str_DialogFileName = str_FileName
            If Not Run_DialogBox(cdl_SAVE1, str_DialogFilePath, str_DialogFileName) Then
                GoTo EXIT_STEP
            End If

            '//�N���b�r�u����
            intFileNo = FreeFile()
            FileOpen(intFileNo, gvstrFilePath2 & "\" & str_FileName, OpenMode.Output)
            'UPGRADE_WARNING: �I�u�W�F�N�g lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/11 CHG START
            'For i = 1 To lvwMEISAI.ListItems.Count
            For i = 0 To lvwMEISAI.Items.Count - 1
                '2019/04/11 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/11 CHG START
                'objLitem = Me.lvwMEISAI.ListItems.Item(i)
                objLitem = Me.lvwMEISAI.Items.Item(i)
                '2019/04/11 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.Checked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If objLitem.Checked Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/11 CHG START
                    'Call HKKET141M.Get_HKKTRA(Me.lvwMEISAI.ListItems(i).SubItems(2))
                    Call HKKET141M.Get_HKKTRA(Me.lvwMEISAI.Items(i).SubItems(2).Text)
                    '2019/04/11 CHG E N D
                    strBuff = ""
                    'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/11 CHG START
                    'strBuff = strBuff & VB.Left(Me.lvwMEISAI.ListItems(i).SubItems(2) & Space(10), 10) & ","
                    strBuff = strBuff & VB.Left(Me.lvwMEISAI.Items(i).SubItems(2).Text & Space(10), 10) & ","
                    '2019/04/11 CHG E N D
                    strBuff = strBuff & gvstrACCYY & ","
                    For j = 1 To 12
                        '2019/04/19 CHG START
                        'strBuff = strBuff & VB.Left(D0.Chk_Null(gvobjdyn("LMAHKS" & Chr(64 + j))) & Space(7), 7) & ","
                        'dblLMAHKSQ = dblLMAHKSQ + CDbl(D0.Chk_NullN(gvobjdyn("LMAHKS" & Chr(64 + j))))
                        strBuff = strBuff & VB.Left(D0.Chk_Null(gvobjdyn.Rows(0)("LMAHKS" & Chr(64 + j))) & Space(7), 7) & ","
                        dblLMAHKSQ = dblLMAHKSQ + CDbl(D0.Chk_NullN(gvobjdyn.Rows(0)("LMAHKS" & Chr(64 + j))))
                        '2019/04/19 CHG E N D
                    Next j
                    strBuff = strBuff & VB.Left(dblLMAHKSQ & Space(7), 7) & ","
                    dblLMAHKSQ = 0
                    For j = 1 To 12
                        '2019/04/19 CHG START
                        'strBuff = strBuff & VB.Left(D0.Chk_NullN(gvobjdyn("LMAHKS" & Chr(64 + j))) * D0.Chk_NullN(gvobjdyn("ZNKSRETK")) & Space(7), 7) & ","
                        'dblLMAHKSA = dblLMAHKSA + D0.Chk_NullN(gvobjdyn("LMAHKS" & Chr(64 + j))) * D0.Chk_NullN(gvobjdyn("ZNKSRETK"))
                        strBuff = strBuff & VB.Left(D0.Chk_NullN(gvobjdyn.Rows(0)("LMAHKS" & Chr(64 + j))) * D0.Chk_NullN(gvobjdyn.Rows(0)("ZNKSRETK")) & Space(7), 7) & ","
                        dblLMAHKSA = dblLMAHKSA + D0.Chk_NullN(gvobjdyn.Rows(0)("LMAHKS" & Chr(64 + j))) * D0.Chk_NullN(gvobjdyn.Rows(0)("ZNKSRETK"))
                        '2019/04/19 CHG E N D
                    Next j
                    strBuff = strBuff & VB.Left(dblLMAHKSA & Space(7), 7) & ","
                    '2019/04/19 CHG START
                    'strBuff = strBuff & VB.Left(D0.Chk_NullN(gvobjdyn("ZNKURITK")) & Space(7), 7) & ","
                    'strBuff = strBuff & VB.Left(D0.Chk_NullN(gvobjdyn("ZNKSRETK")) & Space(7), 7)
                    strBuff = strBuff & VB.Left(D0.Chk_NullN(gvobjdyn.Rows(0)("ZNKURITK")) & Space(7), 7) & ","
                    strBuff = strBuff & VB.Left(D0.Chk_NullN(gvobjdyn.Rows(0)("ZNKSRETK")) & Space(7), 7)
                    '2019/04/19 CHG E N D
                    PrintLine(intFileNo, strBuff)
                End If
            Next i
            FileClose(intFileNo)
 
            '//�I�����ꂽ�t�@�C���̈ړ�
            On Error Resume Next
            Kill(str_DialogFilePath & str_DialogFileName)
            FileCopy(gvstrFilePath2 & "\" & str_FileName, str_DialogFilePath & str_DialogFileName)
            Kill(gvstrFilePath2 & "\" & str_FileName)
            On Error GoTo 0

            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "115")
        Else
            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "113")
        End If

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        '//V1.10 2006/10/17  DEL START  RISE)
        ''''    On Error GoTo 0
        '//V1.10 2006/10/17  DEL END    RISE)
        Exit Sub
        '----------------------------------------------------------------------------------------
    End Sub

    Private Sub cmdINPUT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdINPUT.Click

        '//V1.10 2006/10/17  ADD START  RISE)
        Dim str_DialogFilePath As String
        Dim str_DialogFileName As String
        '//V1.10 2006/10/17  ADD END    RISE)

        '//V1.10 2006/10/17  CHG START  RISE)
        '// 2007/11/05  DEL START  RISE)
        '    '//�捞�J�n���b�Z�[�W
        '    If Not (ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "116") = vbYes) Then
        '        GoTo EXIT_STEP
        '    End If
        '// 2007/11/05  DEL END    RISE)

        '//�_�C�A���O�{�b�N�X�N��
        str_DialogFileName = gvstrFileName1 & ".CSV"
        'add test start 20190930 kuwa CSV
        str_DialogFileName = "HKKET14CSVHNENSYO_OT.CSV"
        gvstrFileName1 = "HKKET14CSVHNENSYO_OT.CSV"
        str_DialogFilePath = "C:\Users\CIS03\Desktop"
        gvstrFilePath1 = "C:\Users\CIS03\Desktop"

        'add end 20190930 kuwa
        If Not Run_DialogBox(cdl_SAVE1, str_DialogFilePath, str_DialogFileName, 2) Then
            GoTo EXIT_STEP
        End If

        '// 2007/11/05  ADD START  RISE)
        '//�捞�J�n���b�Z�[�W
        If Not (ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "116", str_DialogFilePath & str_DialogFileName & " ���g�p���܂��B") = MsgBoxResult.Yes) Then
            GoTo EXIT_STEP
        End If
        '// 2007/11/05  ADD END    RISE)

        '// 2007/11/05  ADD START  RISE)
        lbl������.Visible = True
        System.Windows.Forms.Application.DoEvents()
        '// 2007/11/05  ADD END    RISE)

        '//�I�����ꂽ�t�@�C���̃R�s�[
        On Error Resume Next
        Kill(gvstrFilePath1 & "\" & gvstrFileName1 & ".CSV")
        Kill(gvstrFilePath1 & "\" & gvstrFileName1 & "_ERR.CSV")
        Kill(str_DialogFilePath & Mid(str_DialogFileName, 1, Len(str_DialogFileName) - 4) & "_ERR.CSV")
        FileCopy(str_DialogFilePath & str_DialogFileName, gvstrFilePath1 & "\" & gvstrFileName1 & ".CSV")
        On Error GoTo 0

        '//�捞����
        '//��ݻ޸��ݐ���J�n
        '2019/04/19 CHG START
        'clsOra.OraBeginTrans()
        'delete start 20190930 kuwa test BeginTrans���񏈗����邽�߁A���񕪂��f���[�g
        'Call DB_BeginTrans(CON)
        'delete end 20190930 kuwa
        '2019/04/19 CHG E N D
        '//�X�V����
        Call D0.Mouse_ON()
        gvblnInputFlg = True
        '//�̔��v��v�폜
        Call DelHKKWTA()
        '    If Not HKKET141M.Upd_IMPORT() Then
        If Not HKKET141M.Upd_IMPORT(str_DialogFilePath & Mid(str_DialogFileName, 1, Len(str_DialogFileName) - 4) & "_ERR.CSV") Then
            gvblnInputFlg = False
            '2019/04/19 CHG START
            'clsOra.OraRollback()
            Call DB_Rollback()
            '2019/04/19 CHG E N D
            FileCopy(gvstrFilePath1 & "\" & gvstrFileName1 & "_ERR.CSV", str_DialogFilePath & Mid(str_DialogFileName, 1, Len(str_DialogFileName) - 4) & "_ERR.CSV")
            GoTo EXIT_STEP
        End If
        '//��ݻ޸��ݐ���J�n
        '2019/04/19 CHG START
        'clsOra.OraCommitTrans()
        Call DB_Commit()
        '2019/04/19 CHG E N D

        '// V2.10�� ADD
        intNensyoImportMode = 1 '//�捞���[�h
        '// V2.10�� ADD

        ''''    '//�捞�J�n���b�Z�[�W
        ''''    If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "116") = vbYes Then
        ''''        '//��ݻ޸��ݐ���J�n
        ''''        clsOra.OraBeginTrans
        ''''        '//�X�V����
        ''''        Call D0.Mouse_ON
        ''''        gvblnInputFlg = True
        ''''        '//�̔��v��v�폜
        ''''        Call DelHKKWTA
        ''''        If Not HKKET141M.Upd_IMPORT Then
        ''''            gvblnInputFlg = False
        ''''            clsOra.OraRollback
        ''''            GoTo EXIT_STEP
        ''''        End If
        ''''        '//��ݻ޸��ݐ���J�n
        ''''        clsOra.OraCommitTrans
        ''''    End If
        '//V1.10 2006/10/17  CHG END    RISE)
        '----------------------------------------------------------------------------------------
EXIT_STEP:

        '// 2007/11/05  ADD START  RISE)
        lbl������.Visible = False
        '// 2007/11/05  ADD END    RISE)

        '//V1.10 2006/10/17  ADD START  RISE)
        '//�I�����ꂽ�t�@�C���̍폜
        On Error Resume Next
        '//V1.10 2007/10/29  ADD START  RISE)
        FileCopy(gvstrFilePath1 & "\" & gvstrFileName1 & "_ERR.CSV", str_DialogFilePath & Mid(str_DialogFileName, 1, Len(str_DialogFileName) - 4) & "_ERR.CSV")
        Kill(gvstrFilePath1 & "\" & gvstrFileName1 & ".CSV")
        Kill(gvstrFilePath1 & "\" & gvstrFileName1 & "_ERR.CSV")
        '//V1.10 2007/10/29  ADD END  RISE)
        On Error GoTo 0
        '//V1.10 2006/10/17  ADD END  RISE)

        Call D0.Mouse_OFF()
        '//V1.10 2006/10/17  DEL START  RISE)
        ''''    On Error GoTo 0
        '//V1.10 2006/10/17  DEL END  RISE)
        Exit Sub
        '----------------------------------------------------------------------------------------
    End Sub

    Private Sub cmdSERCH_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSERCH.Click

        '// 2008/05/26 �� ADD STR �N���v��捞�Ή�
        '//�̔��v��v�폜
        Call DelHKKWTA()
        '// 2008/05/26 �� ADD STR

        '//��ʕ\�����X�V
        Call SavDspFormat()

        If Not Chk_InputDetail() Then
            GoTo EXIT_STEP
        End If
        '// �������̓��[�h
        gvintInputCls = HKKCom.gvcstInputCls.Detail1
        '//���ړ��͐���ݒ�
        Call HKKET141M.Set_InputControl(gvintInputCls)
        gvblnInputFlg = False

        '// V2.10�� ADD
        intNensyoImportMode = 0 '//�ʏ탂�[�h
        '// V2.10�� ADD

        '----------------------------------------------------------------------------------------
EXIT_STEP:
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
    'UPGRADE_WARNING: Form �C�x���g HKKET141F.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
    Private Sub HKKET141F_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        '// 2007/02/24 �� ADD STR
        Call SetFormInitOrg(Me, 1)
        '// 2007/02/24 �� ADD STR
        'delete test start 20190930 kuwa EnterKeyDown�Ɉړ��B
        '//�t�H�[�J�X�R���g���[��
        'ClsFocus.SetFocusCtrl(Me)
        'delete end test 20190930 kuwa
    End Sub

    Private Sub HKKET141F_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        '// V2.01 �� ADD
        Dim ShiftTest As Short
        '// V2.01 �� ADD

        '//Enter�L�[�Ŏ����ڂֈړ�
        Select Case ClsFocus.GetKeyDown(KeyCode)
            Case System.Windows.Forms.Keys.Return
                'add start test 20190930 kuwa Activated�ɂ��������̂��ړ�
                '//�t�H�[�J�X�R���g���[��
                ClsFocus.SetFocusCtrl2(Me)
                'add end 20190930 kuwa
                'change start 20190930 kuwa
                'ClsFocus.EnterNext()
                ClsFocus.EnterNext(False, DirectCast(eventSender, System.Windows.Forms.ContainerControl).ActiveControl.Name)
                'change end 20190930 kuwa
                '// 2007/08/18 �� ADD STR
            Case System.Windows.Forms.Keys.F4 '//F4:�����J�n���ݏ���
                '// V2.01 �� ADD
                ShiftTest = Shift And 7
                Select Case ShiftTest
                    Case 4 ' Alt �L�[��������܂����B
                        Exit Sub
                    Case 5 ' Shift �� Alt �L�[��������܂����B
                        Exit Sub
                End Select
                '// V2.01 �� ADD
                Call cmdSERCH_Click(cmdSERCH, New System.EventArgs())
            Case System.Windows.Forms.Keys.F5 '//F5:�\�����ݏ���
                Call cmdDISPLAY_Click(cmdDISPLAY, New System.EventArgs())
                '// 2007/08/18 �� ADD END
                '// 2007/09/10 �� ADD STR
            Case System.Windows.Forms.Keys.F1 '//F1:�S�I�����ݏ���
                Call cmdALL_SELECT_Click(cmdALL_SELECT, New System.EventArgs())
            Case System.Windows.Forms.Keys.F2 '//F2:�S�������ݏ���
                Call cmdALL_RELEASE_Click(cmdALL_RELEASE, New System.EventArgs())
            Case System.Windows.Forms.Keys.F12 '//F12:�I�����ݏ���
                Call cmdEND_Click(cmdEND, New System.EventArgs())
                '// 2007/09/10 �� ADD END
                '// 2008/11/06 �� ADD STR
            Case System.Windows.Forms.Keys.F6 '//F6:���i���ނֶ��وړ�
                KeyCode = 0
                txtHINCD.Focus()
            Case System.Windows.Forms.Keys.F7 '//F7:���i�Q�ֶ��وړ�
                KeyCode = 0
                txtHINGRP(0).Focus()
            Case System.Windows.Forms.Keys.F8 '//F8:�^���ֶ��وړ�
                KeyCode = 0
                txtHINNMA.Focus()
            Case System.Windows.Forms.Keys.F9 '//F9:�݌��ݸ���وړ�
                KeyCode = 0
                txtZAIRNK(0).Focus()
            Case System.Windows.Forms.Keys.F10 '//F0:����LT���وړ�
                KeyCode = 0
                txtMNFDD.Focus()
                '// 2008/11/06 �� ADD end
        End Select
    End Sub

    Private Sub HKKET141F_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        gvstrDisplayID = "E01"
        '2019/04/16 ADD START
        'ListViewItemComparer�̍쐬�Ɛݒ�
        LvSorter141F = New ListViewItemComparer
        'listViewItemSorter.ColumnModes = _
        '    New ListViewItemComparer.ComparerMode() _
        '    {ListViewItemComparer.ComparerMode.String, _
        '    ListViewItemComparer.ComparerMode.Integer}
        'ListViewItemSorter���w�肷��
        lvwMEISAI.ListViewItemSorter = LvSorter141F
        '2019/04/16 ADD E N D

        '//��ʏ�����
        If Not HKKET141M.Set_Initialize Then
            '//�I������
            Call Ctr_END()
        End If
        txtTODAY.Text = VB6.Format(gvstrUNYDT, "@@@@/@@/@@")

        '2019/04/24 ADD START
        Call SetBar(Me)
        '2019/04/24 ADD E N D
        'add start test 20190925 kuwa ���X�g�r���[���N�����ɕ\������Ă��Ȃ������̂ŁA�C���B
        lvwMEISAI.Enabled = True
        'add end 20190925 kuwa


    End Sub

    '// 2007/02/24 �� ADD STR
    Private Sub HKKET141F_Paint(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        'UPGRADE_WARNING: �I�u�W�F�N�g gvvntLeft �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
        'UPGRADE_WARNING: �I�u�W�F�N�g gvvntTop �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gvvntTop = VB6.PixelsToTwipsY(Me.Top)
    End Sub
    '// 2007/02/24 �� ADD STR

    '2019/04/11 CHG START
    'Private Sub lvwMEISAI_ColumnClick(ByVal ColumnHeader As MSComctlLib.ColumnHeader)
    '	Dim MSComctlLib As Object
    '	Dim wIndex As Integer
    '	'UPGRADE_WARNING: �I�u�W�F�N�g ColumnHeader.Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	wIndex = ColumnHeader.Index - 1
    '	'UPGRADE_WARNING: �I�u�W�F�N�g Me.lvwMEISAI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	Call SortLv((Me.lvwMEISAI), wIndex)

    '   End Sub
    Private Sub lvwMEISAI_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvwMEISAI.ColumnClick
        Call SortLv(lvwMEISAI, e.Column, LvSorter141F, False)
    End Sub
    '2019/04/11 CHG E N D

    'UPGRADE_WARNING: �C�x���g optCARRIES_OFF.CheckedChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub optCARRIES_OFF_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optCARRIES_OFF.CheckedChanged
        If eventSender.Checked Then
            fraSTOCK.Enabled = False
            txtSAFTY_STOCK.Enabled = True
        End If
    End Sub

    'UPGRADE_WARNING: �C�x���g optCARRIES_ON.CheckedChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub optCARRIES_ON_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optCARRIES_ON.CheckedChanged
        If eventSender.Checked Then
            fraSTOCK.Enabled = True
        End If
    End Sub

    'UPGRADE_WARNING: �C�x���g optORDER_OMISSION.CheckedChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub optORDER_OMISSION_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optORDER_OMISSION.CheckedChanged
        If eventSender.Checked Then
            txtSAFTY_STOCK.Enabled = False
            txtSTOCK.Enabled = False
            txtSTOCK_MONTH.Enabled = False
            txtORDER_OMISSION.Enabled = True
        End If
    End Sub

    'UPGRADE_WARNING: �C�x���g optSAFTY_STOCK.CheckedChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub optSAFTY_STOCK_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optSAFTY_STOCK.CheckedChanged
        If eventSender.Checked Then
            txtSAFTY_STOCK.Enabled = True
            txtSTOCK.Enabled = False
            txtSTOCK_MONTH.Enabled = False
            txtORDER_OMISSION.Enabled = False
        End If
    End Sub

    'UPGRADE_WARNING: �C�x���g optSTOCK.CheckedChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub optSTOCK_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optSTOCK.CheckedChanged
        If eventSender.Checked Then
            txtSAFTY_STOCK.Enabled = False
            txtSTOCK.Enabled = True
            txtSTOCK_MONTH.Enabled = False
            txtORDER_OMISSION.Enabled = False
        End If
    End Sub

    'UPGRADE_WARNING: �C�x���g optSTOCK_MONTH.CheckedChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub optSTOCK_MONTH_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optSTOCK_MONTH.CheckedChanged
        If eventSender.Checked Then
            txtSAFTY_STOCK.Enabled = False
            txtSTOCK.Enabled = False
            txtSTOCK_MONTH.Enabled = True
            txtORDER_OMISSION.Enabled = False
        End If
    End Sub

    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    txtHINCD
    '//*
    '//* <�߂�l>
    '//*
    '//* <��  ��>     ���ږ�              I/O      ���e
    '//*
    '//* <��  ��>
    '//*    txtHINCD EVENT
    '//*****************************************************************************************
    Private Sub txtHINCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtHINCD.Enter

        '//̫�ϯĕϊ�
        Call ChgObjectFormat("N", txtHINCD, 1)
        '//GotFocus����
        Call Set_ObjectGotFocus(txtHINCD)

    End Sub
    Private Sub txtHINCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtHINCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        '//���͉\�L�[�̐ݒ�
        '//    Select Case KeyAscii
        '//           Case vbKey0 To vbKey9
        '//           Case vbKeyA To vbKeyZ
        '//           Case vbKeyA + vbKeySpace To vbKeyZ + vbKeySpace
        '//           Case vbKeyBack
        '//           Case vbKeyReturn
        '//           Case Else
        '//                KeyAscii = 0
        '//    End Select
        '//���͉\�L�[�̐ݒ�
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Return
                Call txtHINCD_Validating(txtHINCD, New System.ComponentModel.CancelEventArgs(False))
            Case Else
        End Select

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtHINCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtHINCD.Leave
        '//̫�ϯĕϊ�
        Call ChgObjectFormat("N", txtHINCD, 2)
    End Sub

    Private Sub txtHINCD_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtHINCD.Validating
        Dim Cancel As Boolean = eventArgs.Cancel

        'UPGRADE_WARNING: TextBox �v���p�e�B txtHINCD.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        txtHINCD.Text = UCase(D0.Ctr_AnsiLeftB(txtHINCD.Text, txtHINCD.MaxLength))

        '//20081117 START
        Dim i As Object
        Dim s As Object

        For i = 1 To Len(txtHINCD.Text)
            'UPGRADE_WARNING: �I�u�W�F�N�g i �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Select Case Asc(Mid(txtHINCD.Text, i, 1))
                Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
                    'UPGRADE_WARNING: �I�u�W�F�N�g i �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g s �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    s = s & Mid(txtHINCD.Text, i, 1)
                Case System.Windows.Forms.Keys.A To System.Windows.Forms.Keys.Z
                    'UPGRADE_WARNING: �I�u�W�F�N�g i �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g s �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    s = s & Mid(txtHINCD.Text, i, 1)
                Case System.Windows.Forms.Keys.Space
                    'UPGRADE_WARNING: �I�u�W�F�N�g i �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g s �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    s = s & Mid(txtHINCD.Text, i, 1)
                Case System.Windows.Forms.Keys.A + System.Windows.Forms.Keys.Space To System.Windows.Forms.Keys.Z + System.Windows.Forms.Keys.Space
                    'UPGRADE_WARNING: �I�u�W�F�N�g i �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g s �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    s = s & Mid(txtHINCD.Text, i, 1)
                Case Else
            End Select
        Next i

        'UPGRADE_WARNING: �I�u�W�F�N�g s �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        txtHINCD.Text = s
        '//20081117�@END

        eventArgs.Cancel = Cancel
    End Sub

    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    txtHINGRP
    '//*
    '//* <�߂�l>
    '//*
    '//* <��  ��>     ���ږ�              I/O      ���e
    '//*
    '//* <��  ��>
    '//*    txtHINGRP EVENT
    '//*****************************************************************************************
    Private Sub txtHINGRP_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtHINGRP.Enter
        Dim Index As Short = txtHINGRP.GetIndex(eventSender)

        '//GotFocus����
        Call Set_ObjectGotFocus(txtHINGRP(Index), Index)

    End Sub

    Private Sub txtHINGRP_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtHINGRP.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = txtHINGRP.GetIndex(eventSender)
        '//���͉\�L�[�̐ݒ�
        '//    Select Case KeyAscii
        '//           Case vbKey0 To vbKey9
        '//           Case vbKeyA To vbKeyZ
        '//           Case vbKeyA + vbKeySpace To vbKeyZ + vbKeySpace
        '//           Case vbKeyBack
        '//           Case vbKeyReturn
        '//           Case Else
        '//                KeyAscii = 0
        '//    End Select
        '//���͉\�L�[�̐ݒ�
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Return
                '2019/04/11 CHG START
                'Call txtHINGRP_Validating(txtHINGRP.Item(Index), New System.ComponentModel.CancelEventArgs(Index, False))
                Call txtHINGRP_Validating(eventSender, New System.ComponentModel.CancelEventArgs())
                '2019/04/11 CHG E N D
            Case Else
        End Select

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtHINGRP_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtHINGRP.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim Index As Short = txtHINGRP.GetIndex(eventSender)
        'UPGRADE_WARNING: TextBox �v���p�e�B txtHINGRP.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        txtHINGRP(Index).Text = UCase(D0.Ctr_AnsiLeftB(txtHINGRP(Index).Text, txtHINGRP(Index).MaxLength))

        eventArgs.Cancel = Cancel
    End Sub

    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    txtHINNMA
    '//*
    '//* <�߂�l>
    '//*
    '//* <��  ��>     ���ږ�              I/O      ���e
    '//*
    '//* <��  ��>
    '//*    txtHINNMA EVENT
    '//*****************************************************************************************
    Private Sub txtHINNMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtHINNMA.Enter

        '//GotFocus����
        Call Set_ObjectGotFocus(txtHINNMA)

    End Sub

    Private Sub txtHINNMA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtHINNMA.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        '//���͉\�L�[�̐ݒ�
        '//    Select Case KeyAscii
        '//           Case vbKey0 To vbKey9
        '//           Case vbKeyA To vbKeyZ
        '//           Case vbKeyA + vbKeySpace To vbKeyZ + vbKeySpace
        '//           Case vbKeyBack
        '//           Case vbKeyReturn
        '//           Case Else
        '//                KeyAscii = 0
        '//    End Select
        '//���͉\�L�[�̐ݒ�
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Return
                Call txtHINNMA_Validating(txtHINNMA, New System.ComponentModel.CancelEventArgs(False))
            Case Else
        End Select

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtHINNMA_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtHINNMA.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        'UPGRADE_WARNING: TextBox �v���p�e�B txtHINNMA.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        txtHINNMA.Text = UCase(D0.Ctr_AnsiLeftB(txtHINNMA.Text, txtHINNMA.MaxLength))

        eventArgs.Cancel = Cancel
    End Sub


    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    txtMNFDD
    '//*
    '//* <�߂�l>
    '//*
    '//* <��  ��>     ���ږ�              I/O      ���e
    '//*
    '//* <��  ��>
    '//*    txtMNFDD EVENT
    '//*****************************************************************************************
    Private Sub txtMNFDD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMNFDD.Enter

        '//̫�ϯĕϊ�
        Call ChgObjectFormat("N", txtMNFDD, 1)
        '//GotFocus����
        Call Set_ObjectGotFocus(txtMNFDD)

    End Sub
    Private Sub txtMNFDD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtMNFDD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        '//���͉\�L�[�̐ݒ�
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
            Case System.Windows.Forms.Keys.Delete
            Case System.Windows.Forms.Keys.Back
            Case System.Windows.Forms.Keys.Return
            Case System.Windows.Forms.Keys.Space
            Case 1 To 26
            Case Else
                KeyAscii = 0
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtMNFDD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMNFDD.Leave
        '//̫�ϯĕϊ�
        Call ChgObjectFormat("N", txtMNFDD, 2)
    End Sub

    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    txtZAIRNK
    '//*
    '//* <�߂�l>
    '//*
    '//* <��  ��>     ���ږ�              I/O      ���e
    '//*
    '//* <��  ��>
    '//*    txtZAIRNK EVENT
    '//*****************************************************************************************
    Private Sub txtZAIRNK_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtZAIRNK.Enter
        Dim Index As Short = txtZAIRNK.GetIndex(eventSender)

        '//GotFocus����
        Call Set_ObjectGotFocus(txtZAIRNK(Index), Index)

    End Sub

    Private Sub txtZAIRNK_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtZAIRNK.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = txtZAIRNK.GetIndex(eventSender)
        '//���͉\�L�[�̐ݒ�
        '//    Select Case KeyAscii
        '//           Case vbKey0 To vbKey9
        '//           Case vbKeyA To vbKeyZ
        '//           Case vbKeyA + vbKeySpace To vbKeyZ + vbKeySpace
        '//           Case vbKeyBack
        '//           Case vbKeyReturn
        '//           Case Else
        '//                KeyAscii = 0
        '//    End Select
        '//���͉\�L�[�̐ݒ�
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Return
                '2019/04/11 CHG START
                'Call txtZAIRNK_Validating(txtZAIRNK.Item(Index), New System.ComponentModel.CancelEventArgs(Index, False))
                Call txtZAIRNK_Validating(eventSender, New System.ComponentModel.CancelEventArgs())
                '2019/04/11 CHG E N D
            Case Else
        End Select

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    txtSAFTY_STOCK
    '//*
    '//* <�߂�l>
    '//*
    '//* <��  ��>     ���ږ�              I/O      ���e
    '//*
    '//* <��  ��>
    '//*    txtSAFTY_STOCK EVENT
    '//*****************************************************************************************
    Private Sub txtSAFTY_STOCK_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSAFTY_STOCK.Enter

        '//̫�ϯĕϊ�
        Call ChgObjectFormat("N", txtSAFTY_STOCK, 1)
        '//GotFocus����
        Call Set_ObjectGotFocus(txtSAFTY_STOCK)

    End Sub
    Private Sub txtSAFTY_STOCK_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSAFTY_STOCK.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        '//���͉\�L�[�̐ݒ�
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
            Case System.Windows.Forms.Keys.Delete
            Case System.Windows.Forms.Keys.Back
            Case System.Windows.Forms.Keys.Return
            Case 1 To 26
            Case Else
                KeyAscii = 0
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtSAFTY_STOCK_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSAFTY_STOCK.Leave
        '//̫�ϯĕϊ�
        Call ChgObjectFormat("N", txtSAFTY_STOCK, 2)
    End Sub
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    txtSTOCK
    '//*
    '//* <�߂�l>
    '//*
    '//* <��  ��>     ���ږ�              I/O      ���e
    '//*
    '//* <��  ��>
    '//*    txtSTOCK EVENT
    '//*****************************************************************************************
    Private Sub txtSTOCK_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSTOCK.Enter

        '//̫�ϯĕϊ�
        Call ChgObjectFormat("N", txtSTOCK, 1)
        '//GotFocus����
        Call Set_ObjectGotFocus(txtSTOCK)

    End Sub
    Private Sub txtSTOCK_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSTOCK.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        '//���͉\�L�[�̐ݒ�
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
            Case System.Windows.Forms.Keys.Delete
            Case System.Windows.Forms.Keys.Back
            Case System.Windows.Forms.Keys.Return
            Case 1 To 26
            Case Else
                KeyAscii = 0
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtSTOCK_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSTOCK.Leave
        '//̫�ϯĕϊ�
        Call ChgObjectFormat("N", txtSTOCK, 2)
    End Sub
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    txtSTOCK_MONTH
    '//*
    '//* <�߂�l>
    '//*
    '//* <��  ��>     ���ږ�              I/O      ���e
    '//*
    '//* <��  ��>
    '//*    txtSTOCK_MONTH EVENT
    '//*****************************************************************************************
    Private Sub txtSTOCK_MONTH_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSTOCK_MONTH.Enter

        '//̫�ϯĕϊ�
        Call ChgObjectFormat("N", txtSTOCK_MONTH, 1)
        '//GotFocus����
        Call Set_ObjectGotFocus(txtSTOCK_MONTH)

    End Sub
    Private Sub txtSTOCK_MONTH_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSTOCK_MONTH.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        '//���͉\�L�[�̐ݒ�
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
            Case System.Windows.Forms.Keys.Back
            Case System.Windows.Forms.Keys.Delete
            Case System.Windows.Forms.Keys.Return
            Case 1 To 26
            Case Else
                KeyAscii = 0
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtSTOCK_MONTH_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSTOCK_MONTH.Leave
        '//̫�ϯĕϊ�
        Call ChgObjectFormat("N", txtSTOCK_MONTH, 2)
    End Sub
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    txtORDER_OMISSION
    '//*
    '//* <�߂�l>
    '//*
    '//* <��  ��>     ���ږ�              I/O      ���e
    '//*
    '//* <��  ��>
    '//*    txtORDER_OMISSION EVENT
    '//*****************************************************************************************
    Private Sub txtORDER_OMISSION_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtORDER_OMISSION.Enter

        '//̫�ϯĕϊ�
        Call ChgObjectFormat("N", txtORDER_OMISSION, 1)
        '//GotFocus����
        Call Set_ObjectGotFocus(txtORDER_OMISSION)

    End Sub
    Private Sub txtORDER_OMISSION_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtORDER_OMISSION.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        '//���͉\�L�[�̐ݒ�
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
            Case System.Windows.Forms.Keys.Back
            Case System.Windows.Forms.Keys.Delete
            Case System.Windows.Forms.Keys.Return
            Case 1 To 26
            Case Else
                KeyAscii = 0
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtORDER_OMISSION_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtORDER_OMISSION.Leave
        '//̫�ϯĕϊ�
        Call ChgObjectFormat("N", txtORDER_OMISSION, 2)
    End Sub
    Private Sub HKKET141F_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        '//�I�����b�Z�[�W
        If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "120") = MsgBoxResult.Yes Then
            '//�̔��v��v�폜
            Call DelHKKWTA()
            '//��ʕ\�����X�V
            'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/15�@��
            'Call SavLvFormat("E01", (Me.lvwMEISAI))
            '2019/04/15�@��
            '//�I������
            Call Ctr_END()
        Else
            Cancel = True
        End If
        eventArgs.Cancel = Cancel
    End Sub

    Private Sub txtZAIRNK_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtZAIRNK.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim Index As Short = txtZAIRNK.GetIndex(eventSender)
        'UPGRADE_WARNING: TextBox �v���p�e�B txtZAIRNK.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        txtZAIRNK(Index).Text = UCase(D0.Ctr_AnsiLeftB(txtZAIRNK(Index).Text, txtZAIRNK(Index).MaxLength))

        eventArgs.Cancel = Cancel
    End Sub

End Class