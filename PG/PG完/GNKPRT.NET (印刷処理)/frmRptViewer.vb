Option Strict Off
Option Explicit On
Friend Class frmRptViewer
	Inherits System.Windows.Forms.Form
    '//**************************************************************************************
    '//*
    '//* <��  ��>
    '//*   frmRptViewer
    '//* <�T�@�v>
    '//*    �������
    '//*
    '//*
    '//* <�߂�l>     �^          ����
    '//*�@�@�Ȃ�
    '//* <��  ��>     ���ږ�             �^              I/O           ���e
    '//*�@�@�@�@�@�@�@���[PK
    '//*�@�@�@�@�@�@�@�v�����g�敪
    '//*�@�@�@�@�@�@�@�v���r���[�敪
    '//*�@�@�@�@�@�@�@�v���l�X���ʈ���
    '//*
    '//* <��  ��>
    '//*
    '//*
    '//**************************************************************************************
    '//*�ύX����
    '//* �ް�ޮ�  |  ���t  | �X�V��        |���e
    '//* ---------|--------|---------------|------------------------------------------------*
    '//* 1.00     |20091127|ECHO)          |�V�K�쐬
    '//*          |20100414|ECHO)�y��      |<IT2-0005>
    '//*                                   |�ʊ��ɂăv���r���[���������\������Ȃ���Q�Ή�
    '//**************************************************************************************


    Private Sub cmdCSV_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCSV.Click
		
		
		Dim sSql As String '���o�r�p�k
		Dim sColHeader As String '��^�C�g��
		Dim sColHeader2 As String '��^�C�g���Q
		Dim sRowHeader As String '�s�^�C�g��
		Dim bolRet As Boolean
		Dim li_ExeMsgRtn As Short
		
		li_ExeMsgRtn = MsgBox("CSV�o�͂��s���܂��B��낵���ł����H", MsgBoxStyle.OKCancel + MsgBoxStyle.Information, "�����Ǘ��V�X�e��")
		If li_ExeMsgRtn = MsgBoxResult.Cancel Then
			Exit Sub
		End If
		
		'�w�b�_���E�r�p�k���쐬
		If Get_Sql(sSql, sColHeader, sRowHeader, sColHeader2) = False Then
			Exit Sub
		End If
		
		'�b�r�u�o��
		If CSV_OUTPUT(Me.Name, sSql, sColHeader, sRowHeader, sColHeader2) = False Then
			Exit Sub
		End If
		
	End Sub
	
	Private Sub cmdPrt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrt.Click
		
		'    Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
		Dim li_ExeMsgRtn As Short
		
		On Error GoTo ERR_END
		
		li_ExeMsgRtn = MsgBox("������s���܂��B��낵���ł����H", MsgBoxStyle.OKCancel + MsgBoxStyle.Information, "�����Ǘ��V�X�e��")
		If li_ExeMsgRtn = MsgBoxResult.Cancel Then
			Exit Sub
		End If
		
		'    Report = CrystalReportViewer1.ReportSource
		'�v�����^�̐ݒ�
		'    Report.PrintOptions.PrinterName = PrintCommon.GetPrinterName(ps_Param2)
		'UPGRADE_WARNING: �I�u�W�F�N�g CRViewer91.PrintReport �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CRViewer91.PrintReport()
		
		Exit Sub
		
ERR_END: 
		li_ExeMsgRtn = MsgBox("��������ŃG���[���������܂����B", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "�G���[")
		
		
	End Sub

    '2019/05/16 CHG START
    'Private Sub frmRptViewer_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
    '	Dim CRAXDRT As Object
    '	'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
    '	System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

    '       Dim CRAPP As CRAXDRT.Application
    '       'UPGRADE_ISSUE: CRAXDRT.Report �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
    '       Dim Report As CRAXDRT.Report
    '       'UPGRADE_ISSUE: CRAXDRT.ConnectionProperty �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
    '       Dim ConnectProperty As CRAXDRT.ConnectionProperty


    '       Dim iPaperOrnt As Short
    '	Dim iPaperSize As Short
    '	Dim i As Short

    '	'�t�H�[���^�C�g���ύX
    '	Me.Text = SSS_PrgNm

    '	'�w�b�_�[���w��
    '	Select Case SSS_PrtID
    '		'�I�D�A�H���W�v�����\�A�������z���͕\��CSV�o�̓{�^����\�����Ȃ�
    '		'*D*Case ps_rptid_GENPR10, ps_rptid_GENPR12, ps_rptid_GENPR13
    '		'<2014/10/22 RS)ishimoto CHG>
    '		'Case ps_rptid_GNKPR10, ps_rptid_GNKPR12
    '		'�H���W�v�����\��CSV�o�̓{�^����\�����Ȃ�
    '		Case ps_rptid_GNKPR12
    '			cmdCSV.Visible = False
    '			'��L�ȊO��CSV�o�̓{�^����\������
    '		Case Else
    '			cmdCSV.Visible = True
    '	End Select

    '       '���|�[�g�t�@�C���w��
    '       CRAPP = CreateObject("Crystalruntime.Application")
    '       'UPGRADE_WARNING: �I�u�W�F�N�g CRAPP.OpenReport �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '       Report = CRAPP.OpenReport(SSS_RPT_DIR & "\" & SSS_PrtID & ".RPT")

    '	'�p�����@�ޔ�
    '	'UPGRADE_WARNING: �I�u�W�F�N�g Report.PaperOrientation �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	iPaperOrnt = Report.PaperOrientation
    '	'UPGRADE_WARNING: �I�u�W�F�N�g Report.PaperSize �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	iPaperSize = Report.PaperSize

    '	'�c�a�ڑ�
    '	'UPGRADE_WARNING: �I�u�W�F�N�g Report.Database �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	For i = 1 To Report.Database.Tables.Count

    '		'IT2-0005 UPD STR
    '		'*D*        Set ConnectProperty = Report.Database.Tables.Item(i).ConnectionProperties.Item("Server")
    '		'*D*        ConnectProperty.Value = ps_DatabaseName
    '		'*D*        Set ConnectProperty = Report.Database.Tables.Item(i).ConnectionProperties.Item("User ID")
    '		'*D*        ConnectProperty.Value = ps_UserName
    '		'*D*        Set ConnectProperty = Report.Database.Tables.Item(i).ConnectionProperties.Item("Password")
    '		'*D*        ConnectProperty.Value = ps_Password
    '		'SID
    '		'UPGRADE_WARNING: �I�u�W�F�N�g Report.Database �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		Report.Database.Tables(i).ConnectionProperties.Item("Server") = ps_DatabaseName
    '		'հ��
    '		'UPGRADE_WARNING: �I�u�W�F�N�g Report.Database �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		Report.Database.Tables(i).ConnectionProperties.Item("User ID") = ps_UserName
    '		'�߽ܰ��
    '		'UPGRADE_WARNING: �I�u�W�F�N�g Report.Database �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		Report.Database.Tables(i).ConnectionProperties.Item("Password") = ps_Password
    '		'۹���݁@��հ�ނ�啶���ϊ����Ȃ��Ɛ������v���r���[����Ȃ�
    '		'UPGRADE_WARNING: �I�u�W�F�N�g Report.Database �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		Report.Database.Tables(i).Location = UCase(ps_UserName) & "." & SSS_TblID
    '		'IT2-0005 UPD END

    '	Next i

    '	'���o�����w��
    '	'UPGRADE_WARNING: �I�u�W�F�N�g Report.RecordSelectionFormula �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	If Trim(Report.RecordSelectionFormula) <> "" Then
    '		'UPGRADE_WARNING: �I�u�W�F�N�g Report.RecordSelectionFormula �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		Report.RecordSelectionFormula = Report.RecordSelectionFormula & " AND {" & SSS_TblID & ".C_PRT_PK_NO} = '" & ps_prtPmKey & "' " & Chr(0)
    '	Else
    '		'UPGRADE_WARNING: �I�u�W�F�N�g Report.RecordSelectionFormula �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		Report.RecordSelectionFormula = "{" & SSS_TblID & ".C_PRT_PK_NO} = '" & ps_prtPmKey & "' " & Chr(0)
    '	End If




    '	'�v�����^�w��
    '	Dim PrinterName As String
    '	Dim UniDevice() As Byte
    '	Dim UniDriver() As Byte
    '	Dim UniPort() As Byte
    '	Dim DriverName As String
    '	Dim PortName As String
    '	Dim buf As New VB6.FixedLengthString(128)
    '	'    Dim DriverHandle As Long
    '	'    Dim DriverLength As Integer
    '	'    Dim PrinterHandle As Long
    '	Dim PrinterLength As Short
    '	Dim PortHandle As Integer
    '	Dim PortLength As Short
    '	Dim result As Short
    '	Dim Mode As Integer
    '	'    Dim dmOutBuf() As Byte
    '	Dim iret As Short

    '	PrinterName = SSS_PRINTER_NM

    '	'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() ���g�����߂ɃR�[�h���A�b�v�O���[�h����܂������A���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' ���N���b�N���Ă��������B
    '	UniDriver = System.Text.UnicodeEncoding.Unicode.GetBytes("winspool" & Chr(0))
    '	'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() ���g�����߂ɃR�[�h���A�b�v�O���[�h����܂������A���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' ���N���b�N���Ă��������B
    '	UniPort = System.Text.UnicodeEncoding.Unicode.GetBytes(Chr(0))
    '       'UPGRADE_ISSUE: Printers ���\�b�h Printers.Count �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
    '       For i = 0 To Printers.Count - 1
    '           'UPGRADE_ISSUE: Printer �v���p�e�B Printers.DeviceName �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
    '           If Printers(i).DeviceName = PrinterName Then
    '               'UPGRADE_ISSUE: Printer �v���p�e�B Printers.DriverName �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
    '               'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() ���g�����߂ɃR�[�h���A�b�v�O���[�h����܂������A���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' ���N���b�N���Ă��������B
    '               UniDriver = System.Text.UnicodeEncoding.Unicode.GetBytes(Printers(i).DriverName & Chr(0))
    '               'UPGRADE_ISSUE: Printer �v���p�e�B Printers.Port �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
    '               'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() ���g�����߂ɃR�[�h���A�b�v�O���[�h����܂������A���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' ���N���b�N���Ă��������B
    '               UniPort = System.Text.UnicodeEncoding.Unicode.GetBytes(Printers(i).Port & Chr(0))
    '               Exit For
    '           End If
    '       Next

    '       'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() ���g�����߂ɃR�[�h���A�b�v�O���[�h����܂������A���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' ���N���b�N���Ă��������B
    '       UniDevice = System.Text.UnicodeEncoding.Unicode.GetBytes(PrinterName & Chr(0))

    '	'�v�����^�w��
    '	'UPGRADE_WARNING: �I�u�W�F�N�g Report.SelectPrinter �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	Call Report.SelectPrinter(UniDriver(0), UniDevice, UniPort(0))

    '	'�p���ݒ�
    '	'UPGRADE_WARNING: �I�u�W�F�N�g Report.PaperOrientation �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	Report.PaperOrientation = iPaperOrnt
    '	'UPGRADE_WARNING: �I�u�W�F�N�g Report.PaperSize �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	Report.PaperSize = iPaperSize

    '       '�v���r���[
    '       'UPGRADE_WARNING: �I�u�W�F�N�g CRViewer91.ReportSource �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '       'UPGRADE_WARNING: �I�u�W�F�N�g Report �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B

    '       CRViewer91.ReportSource = Report
    '       'UPGRADE_WARNING: �I�u�W�F�N�g CRViewer91.ViewReport �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '       CRViewer91.ViewReport()
    '       'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
    '       System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default




    '   End Sub
    Private Sub frmRptViewer_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim CRAXDRT As Object
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Dim CR As New CrstlRpt
        Dim Report = CR.NewCRReport()
        Dim CRAPP As Object

        Dim iPaperOrnt As Short
        Dim iPaperSize As Short
        Dim i As Short

        '�t�H�[���^�C�g���ύX
        Me.Text = SSS_PrgNm

        '�w�b�_�[���w��
        Select Case SSS_PrtID
            '�I�D�A�H���W�v�����\�A�������z���͕\��CSV�o�̓{�^����\�����Ȃ�
            '*D*Case ps_rptid_GENPR10, ps_rptid_GENPR12, ps_rptid_GENPR13
            '<2014/10/22 RS)ishimoto CHG>
            'Case ps_rptid_GNKPR10, ps_rptid_GNKPR12
            '�H���W�v�����\��CSV�o�̓{�^����\�����Ȃ�
            Case ps_rptid_GNKPR12
                cmdCSV.Visible = False
                '��L�ȊO��CSV�o�̓{�^����\������
            Case Else
                cmdCSV.Visible = True
        End Select

        '���|�[�g�t�@�C���w��
        Report.Load(SSS_RPT_DIR & "\" & SSS_PrtID & ".rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByDefault)

        '�p�����@�ޔ�
        iPaperOrnt = Report.PrintOptions.PaperOrientation
        iPaperSize = Report.PrintOptions.PaperSize


        Dim sSql As String '���o�r�p�k
        Dim sColHeader As String '��^�C�g��
        Dim sColHeader2 As String '��^�C�g���Q
        Dim sRowHeader As String '�s�^�C�g��

        If Get_Sql(sSql, sColHeader, sRowHeader, sColHeader2) = False Then
            Exit Sub
        End If

        '���o�����w��
        'UPGRADE_WARNING: �I�u�W�F�N�g Report.RecordSelectionFormula �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(Report.RecordSelectionFormula) <> "" Then
            'UPGRADE_WARNING: �I�u�W�F�N�g Report.RecordSelectionFormula �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Report.RecordSelectionFormula = Report.RecordSelectionFormula & " AND {" & SSS_TblID & ".C_PRT_PK_NO} = '" & ps_prtPmKey & "' " & Chr(0)
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g Report.RecordSelectionFormula �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Report.RecordSelectionFormula = "{" & SSS_TblID & ".C_PRT_PK_NO} = '" & ps_prtPmKey & "' " & Chr(0)
        End If

        '�v�����^�w��
        Dim PrinterName As String
        Dim UniDevice() As Byte
        Dim UniDriver() As Byte
        Dim UniPort() As Byte
        'Dim DriverName As String
        'Dim PortName As String
        Dim buf As New VB6.FixedLengthString(128)
        'Dim PrinterLength As Short
        'Dim PortHandle As Integer
        'Dim PortLength As Short
        'Dim result As Short
        'Dim Mode As Integer
        'Dim iret As Short

        PrinterName = SSS_PRINTER_NM

        UniDriver = System.Text.UnicodeEncoding.Unicode.GetBytes("winspool" & Chr(0))
        UniPort = System.Text.UnicodeEncoding.Unicode.GetBytes(Chr(0))

        UniDevice = System.Text.UnicodeEncoding.Unicode.GetBytes(PrinterName & Chr(0))

        '�v�����^�w��
        'Call Report.SelectPrinter(UniDriver(0), UniDevice, UniPort(0))

        '�p���ݒ�
        Report.PrintOptions.PaperOrientation = iPaperOrnt
        Report.PrintOptions.PaperSize = iPaperSize

        '���|�[�g���ڑ�����c�a�����Z�b�g
        'Report.SetDatabaseLogon("", "")
        Report.SetDatabaseLogon("GENKA_USR1", "GENKA_USR1")
        '�v���r���[
        CRViewer91.ReportSource = Report
        '�{����S�̂ɐݒ�
        CRViewer91.Zoom(2)
        '��ʕ\��
        CRViewer91.Show()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub
    '2019/05/16 CHG E N D



    'UPGRADE_WARNING: �C�x���g frmRptViewer.Resize �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub frmRptViewer_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		'UPGRADE_WARNING: �I�u�W�F�N�g CRViewer91.Top �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CRViewer91.Top = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g CRViewer91.Left �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CRViewer91.Left = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g CRViewer91.Height �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CRViewer91.Height = VB6.PixelsToTwipsY(ClientRectangle.Height)
		'UPGRADE_WARNING: �I�u�W�F�N�g CRViewer91.Width �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CRViewer91.Width = VB6.PixelsToTwipsX(ClientRectangle.Width)
		
	End Sub
End Class