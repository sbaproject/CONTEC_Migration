Option Strict Off
Option Explicit On

Friend Class HKKET143F
	Inherits System.Windows.Forms.Form

    '2019/04/11 ADD START
    Private ClsMessage As New ClsMessage
    '2019/04/11 ADD E N D

    '2019/04/16 ADD START
    'ListViewItemSorter�Ɏw�肷��t�B�[���h
    Public lvSorter143F As ListViewItemComparer
    '2019/04/16 ADD E N D

    '// 2007/02/24 �� ADD STR
    'UPGRADE_WARNING: Form �C�x���g HKKET143F.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub HKKET143F_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		Call SetFormInitOrg(Me, 1)
	End Sub
	'// 2007/02/24 �� ADD STR
	
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
	Private Sub HKKET143F_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		gvstrDisplayID = "E03"

        '2019/04/16 ADD START
        'ListViewItemComparer�̍쐬�Ɛݒ�
        lvSorter143F = New ListViewItemComparer
        'listViewItemSorter.ColumnModes = _
        '    New ListViewItemComparer.ComparerMode() _
        '    {ListViewItemComparer.ComparerMode.String, _
        '    ListViewItemComparer.ComparerMode.Integer}
        lvSorter143F.Order = SortOrder.None
        'ListViewItemSorter���w�肷��
        lvwMEISAI.ListViewItemSorter = lvSorter143F
        '2019/04/16 ADD E N D

		'// 2007/02/24 �� ADD STR
		'UPGRADE_WARNING: �I�u�W�F�N�g gvvntTop �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Me.Top = VB6.TwipsToPixelsY(gvvntTop)
		'UPGRADE_WARNING: �I�u�W�F�N�g gvvntLeft �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Me.Left = VB6.TwipsToPixelsX(gvvntLeft)
        '// 2007/02/24 �� ADD STR

        '//��ʏ�����
        If Not HKKET143M.Set_Initialize() Then
            '//�I������
            Me.Close()
        End If

        '2019/04/24 ADD START
        Call SetBar(Me)
        '2019/04/24 ADD E N D

    End Sub
	
	'// 2007/02/24 �� ADD STR
	Private Sub HKKET143F_Paint(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
		'UPGRADE_WARNING: �I�u�W�F�N�g gvvntLeft �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
		'UPGRADE_WARNING: �I�u�W�F�N�g gvvntTop �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gvvntTop = VB6.PixelsToTwipsY(Me.Top)
	End Sub
	'// 2007/02/24 �� ADD STR
	
	Private Sub HKKET143F_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
		If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "301") = MsgBoxResult.Yes Then
			'//��ʕ\�����X�V
			'UPGRADE_WARNING: �I�u�W�F�N�g HKKET143F.lvwMEISAI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/15�@��
            'Call SavLvFormat("E03", (Me.lvwMEISAI))
            '2019/04/15�@��
        Else
            '2019/04/15 CHG START
            'Cancel = True
            eventArgs.Cancel = True
            '2019/04/15 CHG E N D
            Exit Sub
		End If
        '//V1.10 2006/09/20  ADD START  RISE)
        HKKET142F.Visible = True
		'//V1.10 2006/09/20  ADD E N D  RISE)
        '2019/04/15 CHG START
        'eventArgs.Cancel = Cancel
        eventArgs.Cancel = False
        '2019/04/15 CHG E N D
    End Sub
	Private Sub cmdRETURN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRETURN.Click
		'// 2007/02/24 �� ADD STR
		'UPGRADE_WARNING: �I�u�W�F�N�g gvvntTop �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gvvntTop = VB6.PixelsToTwipsY(Me.Top)
		'UPGRADE_WARNING: �I�u�W�F�N�g gvvntLeft �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
		'// 2007/02/24 �� ADD STR
		'//�I������
		Me.Close()
		
	End Sub
    '2019/04/11 CHG START 
    'Private Sub lvwMEISAI_ColumnClick(ByVal ColumnHeader As MSComctlLib.ColumnHeader)
    '    Dim MSComctlLib As Object
    '    Dim wIndex As Integer
    '    'UPGRADE_WARNING: �I�u�W�F�N�g ColumnHeader.Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    wIndex = ColumnHeader.Index - 1
    '    'UPGRADE_WARNING: �I�u�W�F�N�g Me.lvwMEISAI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call SortLv((Me.lvwMEISAI), wIndex)

    'End Sub
    Private Sub lvwMEISAI_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvwMEISAI.ColumnClick
        ''�N���b�N���ꂽ���ݒ�
        'listViewItemSorter.Column = e.Column
        ''���ёւ���
        'lvwMEISAI.Sort()
        Call SortLv(lvwMEISAI, e.Column, lvSorter143F, False)
    End Sub
    '2019/04/11 CHG E N D 
End Class