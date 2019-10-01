Option Strict Off
Option Explicit On
Friend Class frmRptViewer
	Inherits System.Windows.Forms.Form
    '//**************************************************************************************
    '//*
    '//* <名  称>
    '//*   frmRptViewer
    '//* <概　要>
    '//*    印刷処理
    '//*
    '//*
    '//* <戻り値>     型          説明
    '//*　　なし
    '//* <引  数>     項目名             型              I/O           内容
    '//*　　　　　　　帳票PK
    '//*　　　　　　　プリント区分
    '//*　　　　　　　プレビュー区分
    '//*　　　　　　　プロネス共通引数
    '//*
    '//* <説  明>
    '//*
    '//*
    '//**************************************************************************************
    '//*変更履歴
    '//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
    '//* ---------|--------|---------------|------------------------------------------------*
    '//* 1.00     |20091127|ECHO)          |新規作成
    '//*          |20100414|ECHO)土屋      |<IT2-0005>
    '//*                                   |別環境にてプレビューが正しく表示されない障害対応
    '//**************************************************************************************


    Private Sub cmdCSV_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCSV.Click
		
		
		Dim sSql As String '抽出ＳＱＬ
		Dim sColHeader As String '列タイトル
		Dim sColHeader2 As String '列タイトル２
		Dim sRowHeader As String '行タイトル
		Dim bolRet As Boolean
		Dim li_ExeMsgRtn As Short
		
		li_ExeMsgRtn = MsgBox("CSV出力を行います。よろしいですか？", MsgBoxStyle.OKCancel + MsgBoxStyle.Information, "原価管理システム")
		If li_ExeMsgRtn = MsgBoxResult.Cancel Then
			Exit Sub
		End If
		
		'ヘッダ文・ＳＱＬ文作成
		If Get_Sql(sSql, sColHeader, sRowHeader, sColHeader2) = False Then
			Exit Sub
		End If
		
		'ＣＳＶ出力
		If CSV_OUTPUT(Me.Name, sSql, sColHeader, sRowHeader, sColHeader2) = False Then
			Exit Sub
		End If
		
	End Sub
	
	Private Sub cmdPrt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrt.Click
		
		'    Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
		Dim li_ExeMsgRtn As Short
		
		On Error GoTo ERR_END
		
		li_ExeMsgRtn = MsgBox("印刷を行います。よろしいですか？", MsgBoxStyle.OKCancel + MsgBoxStyle.Information, "原価管理システム")
		If li_ExeMsgRtn = MsgBoxResult.Cancel Then
			Exit Sub
		End If
		
		'    Report = CrystalReportViewer1.ReportSource
		'プリンタの設定
		'    Report.PrintOptions.PrinterName = PrintCommon.GetPrinterName(ps_Param2)
		'UPGRADE_WARNING: オブジェクト CRViewer91.PrintReport の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CRViewer91.PrintReport()
		
		Exit Sub
		
ERR_END: 
		li_ExeMsgRtn = MsgBox("印刷処理でエラーが発生しました。", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "エラー")
		
		
	End Sub

    '2019/05/16 CHG START
    'Private Sub frmRptViewer_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
    '	Dim CRAXDRT As Object
    '	'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
    '	System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

    '       Dim CRAPP As CRAXDRT.Application
    '       'UPGRADE_ISSUE: CRAXDRT.Report オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    '       Dim Report As CRAXDRT.Report
    '       'UPGRADE_ISSUE: CRAXDRT.ConnectionProperty オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    '       Dim ConnectProperty As CRAXDRT.ConnectionProperty


    '       Dim iPaperOrnt As Short
    '	Dim iPaperSize As Short
    '	Dim i As Short

    '	'フォームタイトル変更
    '	Me.Text = SSS_PrgNm

    '	'ヘッダー情報指定
    '	Select Case SSS_PrtID
    '		'棚札、工数集計総括表、原価差額分析表はCSV出力ボタンを表示しない
    '		'*D*Case ps_rptid_GENPR10, ps_rptid_GENPR12, ps_rptid_GENPR13
    '		'<2014/10/22 RS)ishimoto CHG>
    '		'Case ps_rptid_GNKPR10, ps_rptid_GNKPR12
    '		'工数集計総括表はCSV出力ボタンを表示しない
    '		Case ps_rptid_GNKPR12
    '			cmdCSV.Visible = False
    '			'上記以外はCSV出力ボタンを表示する
    '		Case Else
    '			cmdCSV.Visible = True
    '	End Select

    '       'レポートファイル指定
    '       CRAPP = CreateObject("Crystalruntime.Application")
    '       'UPGRADE_WARNING: オブジェクト CRAPP.OpenReport の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       Report = CRAPP.OpenReport(SSS_RPT_DIR & "\" & SSS_PrtID & ".RPT")

    '	'用紙情報　退避
    '	'UPGRADE_WARNING: オブジェクト Report.PaperOrientation の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	iPaperOrnt = Report.PaperOrientation
    '	'UPGRADE_WARNING: オブジェクト Report.PaperSize の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	iPaperSize = Report.PaperSize

    '	'ＤＢ接続
    '	'UPGRADE_WARNING: オブジェクト Report.Database の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	For i = 1 To Report.Database.Tables.Count

    '		'IT2-0005 UPD STR
    '		'*D*        Set ConnectProperty = Report.Database.Tables.Item(i).ConnectionProperties.Item("Server")
    '		'*D*        ConnectProperty.Value = ps_DatabaseName
    '		'*D*        Set ConnectProperty = Report.Database.Tables.Item(i).ConnectionProperties.Item("User ID")
    '		'*D*        ConnectProperty.Value = ps_UserName
    '		'*D*        Set ConnectProperty = Report.Database.Tables.Item(i).ConnectionProperties.Item("Password")
    '		'*D*        ConnectProperty.Value = ps_Password
    '		'SID
    '		'UPGRADE_WARNING: オブジェクト Report.Database の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		Report.Database.Tables(i).ConnectionProperties.Item("Server") = ps_DatabaseName
    '		'ﾕｰｻﾞ
    '		'UPGRADE_WARNING: オブジェクト Report.Database の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		Report.Database.Tables(i).ConnectionProperties.Item("User ID") = ps_UserName
    '		'ﾊﾟｽﾜｰﾄﾞ
    '		'UPGRADE_WARNING: オブジェクト Report.Database の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		Report.Database.Tables(i).ConnectionProperties.Item("Password") = ps_Password
    '		'ﾛｹｰｼｮﾝ　※ﾕｰｻﾞを大文字変換しないと正しくプレビューされない
    '		'UPGRADE_WARNING: オブジェクト Report.Database の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		Report.Database.Tables(i).Location = UCase(ps_UserName) & "." & SSS_TblID
    '		'IT2-0005 UPD END

    '	Next i

    '	'抽出条件指定
    '	'UPGRADE_WARNING: オブジェクト Report.RecordSelectionFormula の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	If Trim(Report.RecordSelectionFormula) <> "" Then
    '		'UPGRADE_WARNING: オブジェクト Report.RecordSelectionFormula の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		Report.RecordSelectionFormula = Report.RecordSelectionFormula & " AND {" & SSS_TblID & ".C_PRT_PK_NO} = '" & ps_prtPmKey & "' " & Chr(0)
    '	Else
    '		'UPGRADE_WARNING: オブジェクト Report.RecordSelectionFormula の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		Report.RecordSelectionFormula = "{" & SSS_TblID & ".C_PRT_PK_NO} = '" & ps_prtPmKey & "' " & Chr(0)
    '	End If




    '	'プリンタ指定
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

    '	'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() を使うためにコードがアップグレードされましたが、動作が異なる可能性があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' をクリックしてください。
    '	UniDriver = System.Text.UnicodeEncoding.Unicode.GetBytes("winspool" & Chr(0))
    '	'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() を使うためにコードがアップグレードされましたが、動作が異なる可能性があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' をクリックしてください。
    '	UniPort = System.Text.UnicodeEncoding.Unicode.GetBytes(Chr(0))
    '       'UPGRADE_ISSUE: Printers メソッド Printers.Count はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
    '       For i = 0 To Printers.Count - 1
    '           'UPGRADE_ISSUE: Printer プロパティ Printers.DeviceName はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
    '           If Printers(i).DeviceName = PrinterName Then
    '               'UPGRADE_ISSUE: Printer プロパティ Printers.DriverName はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
    '               'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() を使うためにコードがアップグレードされましたが、動作が異なる可能性があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' をクリックしてください。
    '               UniDriver = System.Text.UnicodeEncoding.Unicode.GetBytes(Printers(i).DriverName & Chr(0))
    '               'UPGRADE_ISSUE: Printer プロパティ Printers.Port はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
    '               'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() を使うためにコードがアップグレードされましたが、動作が異なる可能性があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' をクリックしてください。
    '               UniPort = System.Text.UnicodeEncoding.Unicode.GetBytes(Printers(i).Port & Chr(0))
    '               Exit For
    '           End If
    '       Next

    '       'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() を使うためにコードがアップグレードされましたが、動作が異なる可能性があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' をクリックしてください。
    '       UniDevice = System.Text.UnicodeEncoding.Unicode.GetBytes(PrinterName & Chr(0))

    '	'プリンタ指定
    '	'UPGRADE_WARNING: オブジェクト Report.SelectPrinter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	Call Report.SelectPrinter(UniDriver(0), UniDevice, UniPort(0))

    '	'用紙設定
    '	'UPGRADE_WARNING: オブジェクト Report.PaperOrientation の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	Report.PaperOrientation = iPaperOrnt
    '	'UPGRADE_WARNING: オブジェクト Report.PaperSize の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	Report.PaperSize = iPaperSize

    '       'プレビュー
    '       'UPGRADE_WARNING: オブジェクト CRViewer91.ReportSource の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       'UPGRADE_WARNING: オブジェクト Report の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

    '       CRViewer91.ReportSource = Report
    '       'UPGRADE_WARNING: オブジェクト CRViewer91.ViewReport の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       CRViewer91.ViewReport()
    '       'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
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

        'フォームタイトル変更
        Me.Text = SSS_PrgNm

        'ヘッダー情報指定
        Select Case SSS_PrtID
            '棚札、工数集計総括表、原価差額分析表はCSV出力ボタンを表示しない
            '*D*Case ps_rptid_GENPR10, ps_rptid_GENPR12, ps_rptid_GENPR13
            '<2014/10/22 RS)ishimoto CHG>
            'Case ps_rptid_GNKPR10, ps_rptid_GNKPR12
            '工数集計総括表はCSV出力ボタンを表示しない
            Case ps_rptid_GNKPR12
                cmdCSV.Visible = False
                '上記以外はCSV出力ボタンを表示する
            Case Else
                cmdCSV.Visible = True
        End Select

        'レポートファイル指定
        Report.Load(SSS_RPT_DIR & "\" & SSS_PrtID & ".rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByDefault)

        '用紙情報　退避
        iPaperOrnt = Report.PrintOptions.PaperOrientation
        iPaperSize = Report.PrintOptions.PaperSize


        Dim sSql As String '抽出ＳＱＬ
        Dim sColHeader As String '列タイトル
        Dim sColHeader2 As String '列タイトル２
        Dim sRowHeader As String '行タイトル

        If Get_Sql(sSql, sColHeader, sRowHeader, sColHeader2) = False Then
            Exit Sub
        End If

        '抽出条件指定
        'UPGRADE_WARNING: オブジェクト Report.RecordSelectionFormula の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(Report.RecordSelectionFormula) <> "" Then
            'UPGRADE_WARNING: オブジェクト Report.RecordSelectionFormula の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Report.RecordSelectionFormula = Report.RecordSelectionFormula & " AND {" & SSS_TblID & ".C_PRT_PK_NO} = '" & ps_prtPmKey & "' " & Chr(0)
        Else
            'UPGRADE_WARNING: オブジェクト Report.RecordSelectionFormula の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Report.RecordSelectionFormula = "{" & SSS_TblID & ".C_PRT_PK_NO} = '" & ps_prtPmKey & "' " & Chr(0)
        End If

        'プリンタ指定
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

        'プリンタ指定
        'Call Report.SelectPrinter(UniDriver(0), UniDevice, UniPort(0))

        '用紙設定
        Report.PrintOptions.PaperOrientation = iPaperOrnt
        Report.PrintOptions.PaperSize = iPaperSize

        'レポートが接続するＤＢ情報をセット
        'Report.SetDatabaseLogon("", "")
        Report.SetDatabaseLogon("GENKA_USR1", "GENKA_USR1")
        'プレビュー
        CRViewer91.ReportSource = Report
        '倍率を全体に設定
        CRViewer91.Zoom(2)
        '画面表示
        CRViewer91.Show()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub
    '2019/05/16 CHG E N D



    'UPGRADE_WARNING: イベント frmRptViewer.Resize は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub frmRptViewer_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		'UPGRADE_WARNING: オブジェクト CRViewer91.Top の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CRViewer91.Top = 0
		'UPGRADE_WARNING: オブジェクト CRViewer91.Left の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CRViewer91.Left = 0
		'UPGRADE_WARNING: オブジェクト CRViewer91.Height の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CRViewer91.Height = VB6.PixelsToTwipsY(ClientRectangle.Height)
		'UPGRADE_WARNING: オブジェクト CRViewer91.Width の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CRViewer91.Width = VB6.PixelsToTwipsX(ClientRectangle.Width)
		
	End Sub
End Class