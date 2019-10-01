Imports CrystalDecisions.Shared
Imports VB = Microsoft.VisualBasic
Public Class FrmReport
    Inherits System.Windows.Forms.Form

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub

    ' Form は dispose をオーバーライドしてコンポーネント一覧を消去します。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャは、Windows フォーム デザイナで必要です。
    ' Windows フォーム デザイナを使って変更してください。  
    ' コード エディタは使用しないでください。
    Friend WithEvents B_PrtOrientChg As System.Windows.Forms.Button
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    '2019.04.10 del start 仮
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    '2019.04.10 del end
    Friend WithEvents CSV As System.Windows.Forms.Button
    Friend WithEvents B_Prt As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReport))
        Me.B_PrtOrientChg = New System.Windows.Forms.Button()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        '2019.04.10 del start 仮
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        '2019.04.10 del end
        Me.CSV = New System.Windows.Forms.Button()
        Me.B_Prt = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'B_PrtOrientChg
        '
        Me.B_PrtOrientChg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_PrtOrientChg.ForeColor = System.Drawing.SystemColors.Control
        Me.B_PrtOrientChg.Image = CType(resources.GetObject("B_PrtOrientChg.Image"), System.Drawing.Image)
        Me.B_PrtOrientChg.Location = New System.Drawing.Point(350, 2)
        Me.B_PrtOrientChg.Name = "B_PrtOrientChg"
        Me.B_PrtOrientChg.Size = New System.Drawing.Size(25, 25)
        Me.B_PrtOrientChg.TabIndex = 2
        '
        'CrystalReportViewer1
        '
        '2019.04.10 del start 仮
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.ForeColor = System.Drawing.SystemColors.Control
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        '2019.04.10 del end
        'Me.CrystalReportViewer1.SelectionFormula = ""
        '2019.04.10 del start 仮
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowCopyButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowParameterPanelButton = False
        Me.CrystalReportViewer1.ShowPrintButton = False
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(992, 373)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '2019.04.10 del end
        'Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'CSV
        '
        Me.CSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CSV.ForeColor = System.Drawing.SystemColors.Control
        Me.CSV.Image = CType(resources.GetObject("CSV.Image"), System.Drawing.Image)
        Me.CSV.Location = New System.Drawing.Point(380, 2)
        Me.CSV.Name = "CSV"
        Me.CSV.Size = New System.Drawing.Size(25, 25)
        Me.CSV.TabIndex = 3
        '
        'B_Prt
        '
        Me.B_Prt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Prt.ForeColor = System.Drawing.SystemColors.Control
        Me.B_Prt.Image = CType(resources.GetObject("B_Prt.Image"), System.Drawing.Image)
        Me.B_Prt.Location = New System.Drawing.Point(410, 2)
        Me.B_Prt.Name = "B_Prt"
        Me.B_Prt.Size = New System.Drawing.Size(25, 25)
        Me.B_Prt.TabIndex = 1
        '
        'FrmReport
        '
        Me.ClientSize = New System.Drawing.Size(992, 373)
        Me.Controls.Add(Me.B_Prt)
        Me.Controls.Add(Me.CSV)
        Me.Controls.Add(Me.B_PrtOrientChg)
        '2019.04.10 del start 仮
        'Me.Controls.Add(Me.CrystalReportViewer1)
        '2019.04.10 del end
        Me.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Name = "FrmReport"
        Me.Text = "Crystal Report Form"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private FrmDynaset As Object
    Private FrmTableName As String
    Private CsvPath As String
    Private PrinterName As String
    '
    Private PrinterOrient As String
    '
    Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Integer, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Public CRReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Public CrstlRpt As CrstlRpt
    Private Sub FrmReport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        FrmDynaset = Nothing
        CrstlRpt.ReleaseCRReport()
        CRReport.Dispose()
        CRReport = Nothing
        '2019.04.10 del start 仮
        CrystalReportViewer1.Dispose()
        CrystalReportViewer1 = Nothing
        '2019.04.10 del end
        GC.Collect()
    End Sub
    
    Private Sub FrmReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Str1 As String
        Dim Str2 As String
        Dim Str3 As String
        Dim Font1 As String
        Dim Font2 As String
        Dim Font3 As String
        Dim FSize1 As Integer
        Dim FSize2 As Integer
        Dim FSize3 As Integer
        Dim Fep1 As Integer
        Dim Fep2 As Integer
        Dim Fep3 As Integer

        Me.Refresh()

        '2019.04.10 del start 仮
        'GETDSPSTR("PrtOrientChg", Str1, Font1, FSize1, Fep1, "FrmReport.txt")
        'GETDSPSTR("Export", Str2, Font2, FSize2, Fep2, "FrmReport.txt")
        'GETDSPSTR("CSV", Str3, Font3, FSize3, Fep3, "FrmReport.txt")
        CrystalReportViewer1.ShowPrintButton = False
        '2019.04.10 del end
        B_Prt.Visible = True
        '2019.04.10 del start 仮
        CrystalReportViewer1.EnableDrillDown = False
        '2019.04.10 del end
    End Sub

    Private Sub B_PrtOrientChg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_PrtOrientChg.Click

        Try
            '2019.04.10 del start 仮
            CRReport = CrystalReportViewer1.ReportSource()
            If CRReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait Then
                CRReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape
                Me.CrystalReportViewer1.ReportSource = CRReport
            Else
                CRReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait
                Me.CrystalReportViewer1.ReportSource = CRReport
            End If
            '2019.04.10 del end
        Catch
            MsgBox(Err.Description, MsgBoxStyle.Information)
		End Try
	End Sub

	Private Sub B_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
		Dim str As String

        Try
            '2019.04.10 del start 仮
            CRReport = CrystalReportViewer1.ReportSource
            CRReport.PrintOptions.PrinterName = PrintDialog1.PrinterSettings.PrinterName()
            '2019.04.10 del end
            CRReport.PrintToPrinter(1, True, 1, CrstlRpt.MaxPrint)
        Catch
            MsgBox(Err.Description, MsgBoxStyle.Information)
		End Try

	End Sub

    Private Sub Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '2019.04.10 del start 仮
        Me.CrystalReportViewer1.ExportReport()
        '2019.04.10 del end
        ChDir(VB6.GetPath)
        If Mid(VB6.GetPath, 1, 1) <> "\" Then
            ChDrive(Mid(VB6.GetPath, 1, 1))
        End If
    End Sub
    Public Sub GetCsvTable(ByVal DSet As Object, ByVal TableName As String)
		FrmDynaset = DSet
		FrmTableName = TableName
	End Sub

	Public Sub SetPrinterName(ByVal PrtName As String, ByVal PrtOrient As String)

		PrinterName = PrtName
		PrinterOrient = PrtOrient

	End Sub

	Private Sub CSV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CSV.Click
		Dim ClmCnt As Integer
		Dim RowCnt As Integer
		Dim i, j As Integer
		Dim FileNo As Integer
		Dim wFileName As String
		Dim iRet As Integer
		
		ClmCnt = FrmDynaset.Fields.Count
		FrmDynaset.MoveFirst()
		Call GetCsvPathReport()

		If Len(Trim(CsvPath)) = 0 Then
			CsvPath = Environ("temp")
		End If
		If Len(Trim(Dir(CsvPath, FileAttribute.Directory))) = 0 Then
			CsvPath = Environ("temp")
		End If
        If (Len(CsvPath) < 1) Then
            '2019.04.10 del start 仮
            'MsgBox(GetMsgDesc(10686), MsgBoxStyle.Critical)
            '2019.04.10 del end
            GoTo EndLabel
        Else
            wFileName = VB6.Format(Year(Today), "0000") & VB6.Format(Month(Today), "00") & VB6.Format(VB.Day(Today), "00") & VB6.Format(Hour(TimeOfDay), "00") & VB6.Format(Minute(TimeOfDay), "00") & VB6.Format(Second(TimeOfDay), "00")
			wFileName = Trim(CsvPath) & "\" & wFileName & ".csv"
		End If

		FileNo = FreeFile()
		FileOpen(FileNo, wFileName, OpenMode.Output)
		For i = 0 To ClmCnt - 1
			If i <> 0 Then
				Print(FileNo, ",")
			End If
			Print(FileNo, """")
			Print(FileNo, FrmDynaset.FieldName(i))
			Print(FileNo, """")
			If i = ClmCnt - 1 Then
				Print(FileNo, Chr(13))
			End If
		Next
		Do Until FrmDynaset.EOF
			For j = 0 To ClmCnt - 1
				If j <> 0 Then
					Print(FileNo, ",")
				End If
				Print(FileNo, """")
                Try
                    If String.IsNullOrEmpty(FrmDynaset.Fields(j).Value) Then
                        Print(FileNo, Space(1))
                    Else
                        Print(FileNo, FrmDynaset.Fields(j).Value)
                    End If
                Catch ex As Exception
                    Print(FileNo, "")
                End Try
                Print(FileNo, """")
				If j = ClmCnt - 1 Then
					Print(FileNo, Chr(13))
				End If
			Next
			FrmDynaset.MoveNext()
		Loop
		FileClose(FileNo)
		iRet = ShellExecute(sender.Handle.ToInt32, vbNullString, wFileName, vbNullString, CsvPath, 1)
EndLabel:

	End Sub

	Public Sub GetCsvPathReport()
        Dim TempDynaset As Object
        '2019.04.10 del start 仮
        'On Error GoTo ErrorHandler

        'INV_FLG = " "

        '        EmpQuery = "select * from T_TERM_MS "
        '        EmpQuery = EmpQuery &" where I_LOGIN_ID = '"  & Trim(Sav_Login_ID) &"'"  

        '		TempDynaset = OraDatabase.DbCreateDynaset(EmpQuery, ORADYN_NO_BLANKSTRIP + ORADYN_READONLY) 

        '		TempDynaset.DbMoveFirst()
        '		If TempDynaset.EOF = True Then
        '            INV_FLG ="INV"  
        '			Exit Sub
        '		End If

        '		CsvPath = Trim(TempDynaset.Fields("I_SYSTEM9").Value)

        '		On Error GoTo 0		  
        '		Exit Sub		  
        'ErrorHandler:  
        '		Select Case Err.Number		  
        '			Case Else
        '				MSG = Trim(GetMsgDesc(10024)) & " = " & Str(Err.Number) & vbCrLf & Trim(GetMsgDesc(10025)) & " = " & Err.Source
        '				MSG = MSG & vbCrLf & Trim(GetMsgDesc(10026)) & vbCrLf & Err.Description
        '				MsgBox(MSG, MsgBoxStyle.Critical)
        '		End Select
        '		Err.Clear()		  
        '		On Error GoTo 0		  
        '        INV_FLG ="INV"
        '2019.04.10 del end
    End Sub

    Private Sub B_Prt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Prt.Click
        '2019.04.10 del start 仮
        Dim FrmPrt As FrmPrtReport
        FrmPrt = New FrmPrtReport()
        FrmPrt.SetRptPrinter(PrinterName, CrystalReportViewer1.ReportSource)
        FrmPrt.ShowDialog()
        '2019.04.10 del end
    End Sub
    Private Function getIniProfile(ByVal Ini_FName As String, ByVal Ini_Section As String, ByVal Ini_Key As String) As String
		Dim sRet As String
		Dim lRet As Integer
		Dim sRetWk As String 

        lRet = GetPrivateProfileString(Ini_Section, Ini_Key, "", sRetWk, 256, Ini_FName)

        If Trim(sRetWk) <>""  Then 
            sRet = Mid(sRetWk, 1, InStr(1, sRetWk, vbNullChar) - 1) 
		End If

		getIniProfile = sRet

	End Function

End Class
