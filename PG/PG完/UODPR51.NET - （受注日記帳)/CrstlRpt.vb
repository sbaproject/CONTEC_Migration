Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Text
Imports VB = Microsoft.VisualBasic

Public Class CrstlRpt

    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    Declare Function SetEnvironmentVariable Lib "kernel32" Alias "SetEnvironmentVariableA" (ByVal lpName As String, ByVal lpValue As String) As Integer
    
    Public Const MaxPrint As Integer = 9999
    
    Friend Frm As FrmReport
    Friend CsvData As Object
    Friend CsvTable As String

    Friend CRReport() As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Friend i As Integer
    Public Function NewCRReport() As CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReDim Preserve CRReport(i)
        CRReport(i) = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        NewCRReport = CRReport(i)
        i = i + 1
    End Function
    Public Sub ReleaseCRReport()
        Dim Cnt As Integer = 0
        For Cnt = 0 To i - 1
            CRReport(Cnt).Close()
            CRReport(Cnt).Dispose()
        Next Cnt
        CRReport = Nothing
        CsvData = Nothing
        Frm.Dispose()
        'delete start 20190826 kuwa
        'GC.Collect()
        'delete end 20190826 kuwa
    End Sub
    
    Public Sub New()

        Dim li_MsgRtn As Integer

        Try

            Frm = New FrmReport
            '2019.04.10 del start 仮
            'Dim SQL As String, wDynaset As Object
            'On Error GoTo ErrorHandler
            'SQL = "select * from T_COMPANY_CONDITION_MS where I_CONDITION_CD = '000001'"

            'wDynaset = OraDatabase.DbCreateDynaset(SQL, 0)
            'wDynaset.DbMoveFirst()
            'If wDynaset.EOF = True Then
            '    MsgBox("T_COMPANY_CONDITION_MS not found.")
            'Else
            '    Nat_Lang_Cls = wDynaset.Fields("I_NAT_LANG_CLS").Value
            '    Select Case Nat_Lang_Cls
            '        Case "00"
            '            Nat_Lang_Cls = "JA"
            '        Case "01"
            '            Nat_Lang_Cls = "US"
            '        Case "02"
            '            Nat_Lang_Cls = "CN"
            '        Case "03"
            '            Nat_Lang_Cls = "TW"
            '        Case "04"
            '            Nat_Lang_Cls = "KO"
            '    End Select
            'End If

            'wDynaset = Nothing

            'Dim Reader As StreamReader
            'Dim LangCodePath, TextLine, inputbuff(10) As String, iFont As Integer = 0, FieldCount As Integer
            'Reader = New StreamReader(New FileStream(VB6.GetPath & "\Env\FontTable.dat", FileMode.Open, FileAccess.Read, FileShare.Read), System.Text.Encoding.GetEncoding("Unicode"))
            'Do
            '    TextLine = Reader.ReadLine()
            '    If TextLine = Nothing Then Exit Do
            '    If (Left(TextLine, 1) = "#") Then GoTo NextLoop
            '    Call CSVInput(TextLine, inputbuff, FieldCount, ",")
            '    iFont += 1

            'FontTable(iFont, 1) = Trim(inputbuff(1))
            'FontTable(iFont, 2) = Trim(inputbuff(2))
            'FontTable(iFont, 3) = Trim(inputbuff(3))
            'FontTable(iFont, 4) = Trim(inputbuff(4))
            'FontTable(iFont, 5) = Trim(inputbuff(5))
            '2019.04.10 del end
            'NextLoop:
            '            Loop

            'EndLabel:
            '            Reader.Close()

            '            ChDir(VB6.GetPath)
            '2019.04.10 del end
            Exit Sub
            'ErrorHandler:
            '            Select Case Err.Number
            '                Case Else
            '                    '2019.04.10 del start 仮
            '                    'Msg = Trim(GetMsgDesc(10024)) & " = " & Str(Err.Number) & vbCrLf & Trim(GetMsgDesc(10025)) & " = " & Err.Source
            '                    'MSG = MSG & vbCrLf & Trim(GetMsgDesc(10026)) & vbCrLf & Err.Description
            '                    'MsgBox(Msg, MsgBoxStyle.Critical)
            '                    '2019.04.10 del end
            '            End Select
            'Err.Clear()
            'On Error GoTo 0
        Catch ex As Exception
            li_MsgRtn = MsgBox("New" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        Finally

        End Try
    End Sub
    Private Sub CSVInput(ByRef TextLine As String, ByRef inputbuff() As String, ByRef FieldCount As Integer, ByRef DELIMITER As String)

        Dim i As Integer
        Dim wChar As String 
        Dim wStr As String
        Dim InField As Boolean
        Dim InQuate As Boolean
        Dim NextIgnore As Boolean

        Const QUATE As String = """"

        FieldCount = 0
        inputbuff(1) = ""
        InField = False
        InQuate = False
        NextIgnore = False

        For i = 1 To Len(TextLine)
            If (NextIgnore) Then NextIgnore = False : GoTo NextChar

            wChar = Mid(TextLine, i, 1) 

            If (InField = False) Then
                If (i = 1) Then FieldCount = FieldCount + 1 : inputbuff(FieldCount) = ""
                If (wChar = DELIMITER) Then 
                    FieldCount = FieldCount + 1 : inputbuff(FieldCount) = "" : InField = True : InQuate = False
                ElseIf (wChar = QUATE) Then 
                    InField = True : InQuate = True
                Else
                    inputbuff(FieldCount) = wChar : InField = True : InQuate = False 
                End If
            Else
                If (wChar = DELIMITER And InQuate) Then 
                    inputbuff(FieldCount) = inputbuff(FieldCount) & wChar 
                ElseIf (wChar = DELIMITER And (Not InQuate)) Then 
                    InField = True
                    FieldCount = FieldCount + 1 : inputbuff(FieldCount) = ""
                ElseIf (wChar = QUATE And (Not InQuate)) Then 
                    If (Len(inputbuff(FieldCount)) > 0) Then
                        MsgBox("Delimiter appear in data string", MsgBoxStyle.Critical)
                    Else
                        InQuate = True
                    End If
                ElseIf (wChar = QUATE And InQuate) Then 
                    If (i < Len(TextLine)) Then
                        If (Mid(TextLine, i + 1, 1) = QUATE) Then
                            inputbuff(FieldCount) = inputbuff(FieldCount) & wChar 
                            NextIgnore = True
                        Else
                            InField = False
                        End If
                    End If
                Else
                    inputbuff(FieldCount) = inputbuff(FieldCount) & wChar 
                End If
            End If

NextChar:
        Next

        GoTo EndLabel
EndLabel:
    End Sub

    '2019.04.10 chg start
    'Public Sub SetDatabase(ByVal Server As String, ByVal Password As String, ByVal username As String, _
    '    ByVal Query As String, ByVal TableName As String, ByVal Dataset As DataSet, ByVal CRReport As ReportDocument)
    Public Sub SetDatabase(ByVal Server As String, ByVal Password As String, ByVal username As String,
        ByVal Query As String, ByVal TableName As String, ByVal CRReport As ReportDocument)
        '2019.04.10 end

        Dim li_MsgRtn As Integer

        Try
            Dim tempDynaset As Object
            'On Error GoTo ENDLABEL
            Dim logOnInfo As New TableLogOnInfo
            logOnInfo = CRReport.Database.Tables.Item(TableName).LogOnInfo

            Dim crDatabase As Database
            Dim crTables As Tables
            Dim crTable As Table

            Dim connectionInfo As New ConnectionInfo
            crDatabase = CRReport.Database
            crTables = crDatabase.Tables
            connectionInfo = CRReport.Database.Tables.Item(TableName).LogOnInfo.ConnectionInfo
            connectionInfo.DatabaseName = Server
            connectionInfo.ServerName = "CNJ_ODBC" 'Server 
            connectionInfo.Password = Password
            connectionInfo.UserID = username
            For Each crTable In crTables
                logOnInfo = crTable.LogOnInfo
                logOnInfo.ConnectionInfo = connectionInfo
                crTable.ApplyLogOnInfo(logOnInfo)
                CRReport.Database.Tables.Item(crTable.Name).Location = username & "." & crTable.Location
            Next
            '            Exit Sub
            'ENDLABEL:

        Catch ex As Exception
            li_MsgRtn = MsgBox("SetDatabase" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        Finally

        End Try
    End Sub

    Private Function IndexOfLang(ByVal LangCode As String) As Integer

        Select Case LangCode
            Case "JA"
                IndexOfLang = 1
            Case "US"
                IndexOfLang = 2
            Case "CN"
                IndexOfLang = 3
            Case "TW"
                IndexOfLang = 4
            Case "KO"
                IndexOfLang = 5
            Case Else
                IndexOfLang = 0
        End Select

    End Function
    Public Sub ReportAction(ByVal CRReport As ReportDocument, ByVal ActKbn As Integer, ByVal PrinterIndex As Integer, ByVal Query As String)
        '2019.04.10 del start 仮
        'gPrintError = 0

        'If ActKbn = 1 Then
        '    ReportPrint(CRReport, PrinterIndex)
        'Else
        '    ReportDisplay(CRReport, PrinterIndex, Query)
        'End If

        'Dim jrcode As Integer, PgID As String
        'Dim wPath As String = Application.ExecutablePath
        'Dim wPtr = InStrRev(wPath, "\")
        'PgID = Mid(wPath, wPtr + 1)
        'PgID = Trim(StrConv(PgID, VbStrConv.Uppercase))

        'OraSession.DbBeginTrans()
        'Call PutPrintAudit(OraDatabase, Sav_Login_ID, P_FactoryInCode, PgID, jrcode)
        'If (jrcode = 0) Then
        '    OraSession.DbCommitTrans()
        'Else
        '    OraSession.DBRollback()
        'End If
        '2019.04.10 del end
    End Sub
    Private Sub PutPrintAudit(ByVal inOraDataBase As Object, ByVal inUser As String, ByVal inFacCd As String, ByVal inPgId As String, ByRef ircode As Integer)

        Try
            Dim SQL As String
            Dim DateTime As String = GetDBDateTime(inOraDataBase)
            ircode = 0

            SQL = "insert into T_PRINT_AUDIT(I_FAC_CD,I_PRCS_CLS,I_TERM_NO,I_TERM_NAME,I_OPERATOR_CD,I_OPERATOR_DESC,I_PRCS_DATE,I_PRCS_TIME,I_EXE_NAME,I_EXE_CAPTION) "
            SQL += "values ("
            SQL += "'" & inFacCd & "',"
            SQL += "'01',"
            SQL += GetTermNo(inOraDataBase, inUser) & ","
            SQL += "'" & System.Net.Dns.GetHostName & "',"
            SQL += "'" & inUser & "',"
            SQL += "'" & GetUserName(inOraDataBase, inUser) & "',"
            SQL += "TO_DATE('" & Mid(DateTime, 1, 8) & "','YYYYMMDD'),"
            SQL += "'" & Mid(DateTime, 9, 2) & ":" & Mid(DateTime, 11, 2) & ":" & Mid(DateTime, 13, 2) & "',"
            SQL += "'" & inPgId & "',"
            SQL += "'" & GetPGCaption(inOraDataBase, inPgId) & "'"
            SQL += ")"

            inOraDataBase.DbExecuteSQL(SQL)

        Catch ex As Exception
            ircode = 1
        End Try

    End Sub
    Public Function GetUserName(ByVal OraDataBase As Object, ByVal USERID As String) As String

        Dim SQL As String, wDynaset As Object

        SQL = "select /*+FIRST_ROWS ORDERED */ ps.I_PERSON_DESC I_PERSON_DESC from t_id_ctrl_ms id,t_person_ms ps where id.I_PERSON_CD=ps.I_PERSON_CD and id.I_USER_ID='" & USERID & "'"
        wDynaset = OraDataBase.DbCreateDynaset(SQL, 0)
        wDynaset.DbMoveFirst()

        If wDynaset.EOF = True Then
            GetUserName = "No Name"
        Else
            GetUserName = wDynaset.Fields("I_PERSON_DESC").Value
        End If
        wDynaset = Nothing

    End Function

    Public Function GetTermNo(ByVal OraDataBase As Object, ByVal USERID As String) As Integer

        Dim SQL As String, wDynaset As Object

        SQL = "select I_TERM_NO from t_term_ms where I_LOGIN_ID='" & USERID & "'"
        wDynaset = OraDataBase.DbCreateDynaset(SQL, 0)
        wDynaset.DbMoveFirst()

        If wDynaset.EOF = True Then
            GetTermNo = 0
        Else
            GetTermNo = wDynaset.Fields("I_TERM_NO").Value
        End If
        wDynaset = Nothing

    End Function
    Public Function GetDBDateTime(ByVal OraDataBase As Object) As String

        Dim SQL As String, wDynaset As Object

        SQL = "select to_char(sysdate,'YYYYMMDDHH24MISS') DATETIME from dual"
        wDynaset = OraDataBase.DbCreateDynaset(SQL, 0)
        wDynaset.DbMoveFirst()
        GetDBDateTime = wDynaset.Fields("DATETIME").Value
        wDynaset = Nothing

    End Function
    Public Function GetPGCaption(ByVal OraDataBase As Object, ByVal inPgId As String) As String
        Try

            Dim TextLine, TextFilePath, ExePath As String
            Dim Reader As StreamReader
            Dim DELIMITER As String = ","
            Dim FieldCount As Integer
            Dim InputBuff(20) As String

            '2019.04.10 del start 仮
            'TextFilePath = VB6.GetPath & "\LANG\" & User_Lang & "\PronesButtonAE.inf"
            '2019.04.10 del end
            Reader = New StreamReader(New FileStream(TextFilePath, FileMode.Open, FileAccess.Read), _
             System.Text.Encoding.GetEncoding("Unicode"))
            TextLine = Reader.ReadLine()
            Do
                TextLine = Reader.ReadLine()
                If TextLine = Nothing Then Exit Do
                Call CSVInputO(TextLine, InputBuff, FieldCount, DELIMITER)
                ExePath = StrConv(InputBuff(4), VbStrConv.Uppercase)
                If (InStr(ExePath, StrConv(inPgId, VbStrConv.Uppercase)) <> 0) Then
                    GetPGCaption = InputBuff(3)
                    Reader.Close()
                    GoTo EndLabel
                End If
            Loop
            Reader.Close()
            GetPGCaption = "No Name"

        Catch
            GetPGCaption = "No Name"
        End Try
EndLabel:
    End Function

    Private Sub CSVInputO(ByRef TextLine As String, ByRef inputbuff() As String, ByRef FieldCount As Integer, ByRef DELIMITER As String)
        Dim i As Integer
        Dim wChar As String
        Dim InField As Boolean
        Dim InQuate As Boolean
        Dim NextIgnore As Boolean

        Const QUATE As String = """"

        FieldCount = 0
        inputbuff(1) = ""
        InField = False
        InQuate = False
        NextIgnore = False

        For i = 1 To Len(TextLine)
            If (NextIgnore) Then NextIgnore = False : GoTo NextChar

            wChar = Mid(TextLine, i, 1)

            If (InField = False) Then
                If (i = 1) Then FieldCount = FieldCount + 1 : inputbuff(FieldCount) = ""
                If (wChar = DELIMITER) Then
                    FieldCount = FieldCount + 1 : inputbuff(FieldCount) = "" : InField = True : InQuate = False
                ElseIf (wChar = QUATE) Then
                    InField = True : InQuate = True
                Else
                    inputbuff(FieldCount) = wChar : InField = True : InQuate = False
                End If
            Else
                If (wChar = DELIMITER And InQuate) Then
                    inputbuff(FieldCount) = inputbuff(FieldCount) & wChar
                ElseIf (wChar = DELIMITER And (Not InQuate)) Then
                    InField = True
                    FieldCount = FieldCount + 1 : inputbuff(FieldCount) = ""
                ElseIf (wChar = QUATE And (Not InQuate)) Then
                    If (Len(inputbuff(FieldCount)) > 0) Then
                        MsgBox("Delimiter appear in data string", MsgBoxStyle.Critical)
                    Else
                        InQuate = True
                    End If
                ElseIf (wChar = QUATE And InQuate) Then
                    If (i < Len(TextLine)) Then
                        If (Mid(TextLine, i + 1, 1) = QUATE) Then
                            inputbuff(FieldCount) = inputbuff(FieldCount) & wChar
                            NextIgnore = True
                        Else
                            InField = False
                        End If
                    End If
                Else
                    inputbuff(FieldCount) = inputbuff(FieldCount) & wChar
                End If
            End If

NextChar:
        Next

        GoTo EndLabel

EndLabel:
    End Sub

    Private Sub ReportPrint(ByVal CRReport As ReportDocument, ByVal inTYPE As Integer)

        On Error GoTo ErrorHandler
        
        Dim PrinterName As String
        Dim PrinterOrient As String
        Dim i As Integer
        Dim prDIALOG As New PrintDialog
        Dim prDOCU As New Drawing.Printing.PrintDocument
        
        Dim printerSettings As New Printing.PrinterSettings
        Dim reportPaperSource As System.Drawing.Printing.PaperSource
        Dim printerSource As System.Drawing.Printing.PaperSource

        '2019.04.10 del start 仮
        'If Trim(GetPrinterName(inTYPE)) = "" Then
        '    PrinterName = prDOCU.PrinterSettings.PrinterName
        'Else
        '    PrinterName = GetPrinterName(inTYPE)
        'End If

        'PrinterOrient = GetPrinterOrient(inTYPE)
        '2019.04.10 del end
        If PrinterOrient = "00" Then
            CRReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait
        Else
            CRReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape
        End If

        prDOCU.PrinterSettings.PrinterName = PrinterName
        prDIALOG.Document = prDOCU
        CRReport.PrintOptions.PrinterName = prDOCU.PrinterSettings.PrinterName
        
        For Each printerSource In prDOCU.PrinterSettings.PaperSources
            If printerSource.SourceName.ToString = prDOCU.DefaultPageSettings.PaperSource.SourceName.ToString Then
                reportPaperSource = printerSource
                Exit For
            End If
        Next

        If reportPaperSource Is Nothing Then
            reportPaperSource = prDOCU.DefaultPageSettings.PaperSource
        End If

        CRReport.PrintOptions.CustomPaperSource = reportPaperSource
        
        CRReport.PrintOptions.PaperSize = prDOCU.DefaultPageSettings.PaperSize.Kind

        Dim wPrintFlg As String
        Dim wPrintPath As String
        Dim wFileName As String
        Dim wPGID As String

        wPGID = UCase(VB6.GetEXEName)

        '2019.04.10 del start 仮
        'wPrintFlg = GetPrintCondition(P_FactoryCode, wPGID, "PDFPRINT")
        '2019.04.10 del end
        If wPrintFlg = "01" Then
            '2019.04.10 del start 仮
            'wPrintPath = GetPrintCondition(P_FactoryCode, wPGID, "PDFPATH")
            '2019.04.10 del end
            If Not Directory.Exists(Trim$(wPrintPath)) Then
                wPrintPath = Environ("temp")
            End If
            wPrintPath = IIf(Mid(wPrintPath, Len(wPrintPath) - 1) = "\", wPrintPath, wPrintPath & "\")
            wFileName = wPGID _
                        & "_" & VB6.Format(Year(Today), "0000") & VB6.Format(Month(Today), "00") & VB6.Format(VB.Day(Today), "00") _
                        & "_" & VB6.Format(Hour(TimeOfDay), "00") & VB6.Format(Minute(TimeOfDay), "00") & VB6.Format(Second(TimeOfDay), "00") _
                        & ".pdf"

            Dim wDialog As New SaveFileDialog
            wDialog.InitialDirectory = wPrintPath
            wDialog.FileName = wFileName
            wDialog.Filter = "Adobe Acrobat(*.pdf)|*.pdf|All Files(*.*)|*.*"

            If wDialog.ShowDialog <> DialogResult.Cancel Then
                If wDialog.FileName <> "" Then
                    wFileName = wDialog.FileName
                Else
                    wFileName = wPrintPath & wFileName
                End If
            Else
                wFileName = wPrintPath & wFileName
            End If

            Dim crExportOptions As CrystalDecisions.Shared.ExportOptions = New CrystalDecisions.Shared.ExportOptions()
            Dim DiskOpts As CrystalDecisions.Shared.DiskFileDestinationOptions = New CrystalDecisions.Shared.DiskFileDestinationOptions()
            DiskOpts.DiskFileName = wFileName

            With crExportOptions
                .DestinationOptions = DiskOpts
                '出力先
                .ExportDestinationType = ExportDestinationType.DiskFile
                'エクスポート形式
                .ExportFormatType = ExportFormatType.PortableDocFormat
            End With

            CRReport.Export(crExportOptions)
        Else
            CRReport.PrintToPrinter(1, True, 1, MaxPrint)
        End If
        
        GoTo ExitLabel
ErrorHandler:'2019.04.10 del start 仮
        'gPrintError = 12
        '2019.04.10 del end
        MsgBox(Err.Description, MsgBoxStyle.Critical)
ExitLabel:
    End Sub

    Private Sub ReportDisplay(ByVal CRReport As ReportDocument, ByVal inTYPE As Integer, ByVal Query As String)
        Dim tempDynaset As Object    
        Dim PrinterName As String
        Dim PrinterOrient As String
        Try
            '2019.04.10 del start 仮
            'PrinterName = GetPrinterName(inTYPE)
            'PrinterOrient = GetPrinterOrient(inTYPE)
            'Frm.SetPrinterName(PrinterName, PrinterOrient)
            'If PrinterOrient = "00" Then
            '    CRReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait
            'Else
            '    CRReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape
            'End If
            'If CRReport.RecordSelectionFormula.Trim.Length = 0 Then
            '    Frm.CrystalReportViewer1.SelectionFormula = QueryToSelectionFormula(Query)
            'Else
            '    Frm.CrystalReportViewer1.SelectionFormula = CRReport.RecordSelectionFormula
            'End If
            'Frm.CrystalReportViewer1.ReportSource = CRReport
            'Frm.CrstlRpt = Me
            'Frm.Show()
            'tempDynaset = OraDatabase.DBCreateDynaset(Query, 2)
            'Frm.GetCsvTable(tempDynaset, "")
            '2019.04.10 del end
        Catch
            MsgBox(Err.Description, MsgBoxStyle.Information)
        End Try
    End Sub

    '2019.04.10 add start
    ''' <summary>
    ''' 帳票を画面表示する
    ''' </summary>
    ''' <param name="CRReport">レポートファイルの情報</param>
    ''' <param name="Query">表示したいデータを取得するSQL</param>
    ''' <param name="PrinterOrient">画面表示方向→縦:"00" 横:"01"</param>
    Public Sub ReportPreview(ByVal CRReport As ReportDocument, ByVal Query As String, ByVal PrinterOrient As String)
        Try
            If PrinterOrient = "00" Then
                CRReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait
            Else
                CRReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape
            End If
            If CRReport.RecordSelectionFormula.Trim.Length = 0 Then
                Frm.CrystalReportViewer1.SelectionFormula = QueryToSelectionFormula(Query)
            Else
                Frm.CrystalReportViewer1.SelectionFormula = CRReport.RecordSelectionFormula
            End If
            Frm.CrystalReportViewer1.ReportSource = CRReport
            Frm.Show()
        Catch
            MsgBox(Err.Description, MsgBoxStyle.Information)
        End Try
    End Sub
    '2019.04.10 add end

    Private Function QueryToSelectionFormula(ByVal Query As String) As String
        Dim SelectionFormula As String
        Try
            '大文字に変換
            Query = Query.ToUpper
            'TAB を 半角空白に変換
            Query = Query.Replace(vbTab, " ")
            '文字列編集処理
            SelectionFormula = GetSelectionFormula(Query)

            Return SelectionFormula

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function GetSelectionFormula(ByVal Query As String) As String
        Dim SelectionFormula As String
        Dim TableName As String
        Try
            'テーブル名の取得
            TableName = GetTableName(Query)

            Dim StrTemp As String = String.Empty

            Select Case TableName
                Case "PLP3791_PRT,PLP3792_PRT"
                    'PLP378:支給伝票
                    '2019.04.10 del start 仮
                    'StrTemp = "{PLP3791_PRT.I_TERM_NO} = " & Sav_WSNO & " AND {PLP3791_PRT.I_WS_FAC_CD} = '" & Trim(P_FactoryStrCode) & "'"
                    '2019.04.10 del end
                Case "TMP2190_PRT,TMP2191_PRT"
                    'TMP2190:充填指示書
                    '2019.04.10 del start 仮
                    'StrTemp = "{TMP2190_PRT.I_TERM_NO} = " & Sav_WSNO & " AND {TMP2190_PRT.I_WS_FAC_CD} = '" & Trim(P_FactoryStrCode) & "'"
                    '2019.04.10 del end
                Case "T_BANK_MS"
                    'PLP656:銀行情報一覧
                    ' "SELECT * FROM T_BANK_MS WHERE I_BANK_CD  BETWEEN 'WSBANKNO' AND 'WEBANKNO'"
                    '     ↓
                    ' "I_BANK_CD  BETWEEN 'WSBANKNO' AND 'WEBANKNO'"
                    'CHG START FWEST)NISHIBAYASHI 20160513-01
                    'Dim int_WHERE As Integer = Query.IndexOf(" WHERE ")
                    'Dim int_ORDER As Integer = Query.IndexOf(" ORDER ")
                    Dim int_WHERE As Integer = Query.IndexOf("WHERE ")
                    Dim int_ORDER As Integer = Query.IndexOf("ORDER ")
                    'CHG E N D FWEST)NISHIBAYASHI 20160513-01
                    If int_ORDER > -1 Then
                        Query = Query.Substring(int_WHERE + 5 + 1, int_ORDER - (int_WHERE + 5 + 1)).Trim
                    Else
                        Query = Query.Substring(int_WHERE + 5 + 1, Query.Length - (int_WHERE + 5 + 1)).Trim
                    End If

                    Dim int2 As Integer = Query.IndexOf("BETWEEN ")
                    If int2 > -1 Then
                        '  "{T_BANK_MS.I_BANK_CD} IN "
                        StrTemp = StrTemp & "{" & TableName & "." & Query.Substring(0, int2).Trim & "}" & " IN "
                        ' "I_BANK_CD  BETWEEN 'WSBANKNO' AND 'WEBANKNO'"
                        '     ↓
                        ' "'WSBANKNO' AND 'WEBANKNO'"
                        Query = Query.Substring(int2 + 8, Query.Length - (int2 + 8)).Trim
                    End If
                    Dim int3 As Integer = Query.IndexOf("AND ")
                    If int3 > -1 Then
                        '  "{T_BANK_MS.I_BANK_CD} IN "
                        '     ↓
                        '  "{T_BANK_MS.I_BANK_CD} IN 'WSBANKNO' TO "
                        'CHG START FWEST)NISHIBAYASHI 20160513-01
                        'StrTemp = StrTemp & Query.Substring(0, int3 - 1).Trim & " TO "
                        StrTemp = StrTemp & Query.Substring(0, int3).Trim & " TO "
                        'CHG E N D FWEST)NISHIBAYASHI 20160513-01
                        ' "'WSBANKNO' AND 'WEBANKNO'"
                        '     ↓
                        ' "'WEBANKNO'"
                        Query = Query.Substring(int3 + 4, Query.Length - (int3 + 4)).Trim
                        '  "{T_BANK_MS.I_BANK_CD} IN 'WSBANKNO' TO "
                        '     ↓
                        '  "{T_BANK_MS.I_BANK_CD} IN 'WSBANKNO' TO 'WEBANKNO'"
                        StrTemp = StrTemp & Query
                    End If
                Case Else
                    ' "SELECT * FROM テーブル名 WHERE I_WS_FAC_CD = 'FAC01' AND I_WS_TERM_NO = 1 ORDER BY A,B,C"
                    '     ↓
                    ' "I_WS_FAC_CD = 'FAC01' AND I_WS_TERM_NO = 1"
                    'CHG START FWEST)NISHIBAYASHI 20160513-01
                    'Dim int_WHERE As Integer = Query.IndexOf(" WHERE ")
                    'Dim int_ORDER As Integer = Query.IndexOf(" ORDER ")
                    Dim int_WHERE As Integer = Query.IndexOf("WHERE ")
                    Dim int_ORDER As Integer = Query.IndexOf("ORDER ")
                    'CHG E N D FWEST)NISHIBAYASHI 20160513-01
                    If int_ORDER > -1 Then
                        Query = Query.Substring(int_WHERE + 5 + 1, int_ORDER - (int_WHERE + 5 + 1)).Trim
                    Else
                        Query = Query.Substring(int_WHERE + 5 + 1, Query.Length - (int_WHERE + 5 + 1)).Trim
                    End If

                    For i As Integer = 0 To Query.Length - 1
                        Dim int2 As Integer = Query.IndexOf("=")
                        If int2 > -1 Then
                            ' i = 0
                            '  {テーブル名.I_WS_FAC_CD} = 
                            ' i = 1
                            '  {テーブル名.I_WS_FAC_CD} = 'FAC01' AND {テーブル名.I_WS_FAC_CD} = 
                            If Query.Substring(0, 1) = "(" Then
                                StrTemp = StrTemp & "({" & TableName & "." & Query.Substring(1, int2 - 1).Trim & "}" & " = "
                            Else
                                StrTemp = StrTemp & "{" & TableName & "." & Query.Substring(0, int2).Trim & "}" & " = "
                            End If
                            ' i = 0
                            ' "I_WS_FAC_CD = 'FAC01' AND I_WS_TERM_NO = 1"
                            '     ↓
                            ' "'FAC01' AND I_WS_TERM_NO = 1"
                            ' i = 1
                            ' "I_WS_TERM_NO = 1"
                            '     ↓
                            ' "1"
                            Query = Query.Substring(int2 + 1, Query.Length - (int2 + 1)).Trim
                        Else
                            'RLF10201.vb,RLF11201.vbのみ対象の処理です。
                            If TableName = "RLP102_PRT" Or TableName = "RLP112_PRT" Then
                                Dim int3 As Integer = Query.IndexOf("<>")
                                If int3 > -1 Then
                                    StrTemp = StrTemp & "{" & TableName & "." & Query.Substring(0, int3).Trim & "}" & " <> "
                                    Query = Query.Substring(int3 + 2, Query.Length - (int3 + 2)).Trim
                                End If
                            End If
                        End If

                        Dim int4 As Integer = Query.IndexOf("AND ")
                        Dim int5 As Integer = Query.IndexOf("OR ")
                        If int4 > -1 Then
                            ' i = 0
                            '  {テーブル名.I_WS_FAC_CD} = 'FAC01' AND 
                            'CHG START FWEST)NISHIBAYASHI 20160513-01
                            'StrTemp = StrTemp & Query.Substring(0, int4 - 1).Trim & " AND "
                            StrTemp = StrTemp & Query.Substring(0, int4).Trim & " AND "
                            'CHG E N D FWEST)NISHIBAYASHI 20160513-01
                            ' i = 0
                            ' "'FAC01' AND I_WS_TERM_NO = 1"
                            '     ↓
                            ' "I_WS_TERM_NO = 1"
                            Query = Query.Substring(int4 + 3 + 1, Query.Length - (int4 + 3 + 1)).Trim
                        ElseIf int5 > -1 Then
                            'CHG START FWEST)NISHIBAYASHI 20160513-01
                            'StrTemp = StrTemp & Query.Substring(0, int5 - 1).Trim & " OR "
                            StrTemp = StrTemp & Query.Substring(0, int5).Trim & " OR "
                            'CHG E N D FWEST)NISHIBAYASHI 20160513-01
                            Query = Query.Substring(int5 + 2 + 1, Query.Length - (int5 + 2 + 1)).Trim
                        Else
                            ' i = 1
                            '  {テーブル名.I_WS_FAC_CD} = 'FAC01' AND {テーブル名.I_WS_FAC_CD} = 1
                            StrTemp = StrTemp & Query.Substring(0, Query.Length).Trim
                            Exit For
                        End If
                    Next
            End Select

            SelectionFormula = StrTemp

            Return SelectionFormula

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function GetTableName(ByVal Query As String) As String
        Dim TableName As String = String.Empty
        Try
            'テーブル名の取得
            Dim intStart As Integer = Query.IndexOf("FROM")
            If intStart > -1 Then
                Dim intEnd As Integer = Query.IndexOf("WHERE", intStart)
                If intEnd = -1 Then
                    intEnd = Query.IndexOf("""", intStart)
                    If intEnd = -1 Then
                        intEnd = Query.Length
                    End If
                End If
                TableName = Query.Substring(intStart + 4 + 1, intEnd - (intStart + 4 + 1)).Trim
            End If

            Return TableName

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Sub SetParameters(ByVal TxtRptName As String, ByVal CRReport As ReportDocument)
        Dim ParamField As New ParameterField
        Dim discreteVal As New ParameterDiscreteValue
        Dim rangeVal As New ParameterRangeValue
        Dim LineTemp As String
        Dim str1, str2 As String
        Dim LangTxtRptName As String

        On Error GoTo EndLabel
        '2019.04.10 del start 仮
        'LangTxtRptName = "LANG\" & Rpt_Lang & "\" & TxtRptName
        '2019.04.10 del end
        Dim fs As New System.IO.FileStream(VB6.GetPath & "\" & LangTxtRptName, System.IO.FileMode.Open, IO.FileAccess.Read)
        Dim sr As New System.IO.StreamReader(fs, System.Text.Encoding.GetEncoding("Unicode"))

        Do While sr.Peek > -1
            LineTemp = sr.ReadLine()

            'パラメータフィールド名をテキストファイルより取得
            str1 = Mid(LineTemp, 1, InStr(LineTemp, Chr(9)) - 1)
            LineTemp = Mid(LineTemp, Len(str1) + 2)
            'パラメータフィールド値をテキストファイルより取得
            If InStr(LineTemp, Chr(9)) <> 0 Then
                str2 = Mid(LineTemp, 1, InStr(LineTemp, Chr(9)) - 1)
            Else
                str2 = Trim(LineTemp)
            End If

            On Error Resume Next
            'パラメータフィールド名、値をを挿入
            If Trim(str1) = "L_FONT" Then
                ' 
                Dim FontName As String
                '2019.04.10 del start 仮
                'FontName = FontTable(IndexOfLang(Nat_Lang_Cls), IndexOfLang(Rpt_Lang))
                '2019.04.10 del end
                If (StrConv(FontName, VbStrConv.Uppercase) <> "DEFAULT") Then
                    str2 = FontName
                End If

                Dim ffs As FontFamily() = FontFamily.Families
                Dim ff As FontFamily
                Dim FONT_FLG As Boolean = False

                For Each ff In ffs
                    If Trim(str2) = Trim(ff.Name) Then
                        str2 = ff.Name
                        FONT_FLG = True
                        Exit For
                    End If
                Next ff

                If FONT_FLG = False Then
                    '2019.04.10 del start 仮
                    'If (Nat_Lang_Cls = "CN" Or Rpt_Lang = "CN") Then

                    '    str2 = "SimSun"
                    'Else
                    '    Select Case Nat_Lang_Cls
                    '        Case "JA"
                    '            str2 = "MS UI Gothic"
                    '        Case "US"
                    '            str2 = "Times New Roman"
                    '        Case "CN"
                    '            str2 = "SimSun"
                    '        Case "TW"
                    '            str2 = "MingLiU"
                    '        Case "KO"
                    '            str2 = "BatangChe"
                    '    End Select
                    'End If
                    '2019.04.10 del end
                End If

            End If

            ParamField.ParameterFieldName = str1
            discreteVal.Value = str2
            ParamField.CurrentValues.Add(discreteVal)

            CRReport.DataDefinition.ParameterFields(str1).ApplyCurrentValues(ParamField.CurrentValues)

            On Error GoTo EndLabel2
            ParamField = New ParameterField
            discreteVal = New ParameterDiscreteValue
        Loop
        sr.Close()

        Exit Sub
EndLabel2:
        sr.Close()
EndLabel:
        MsgBox("Error occured in SetParameters. " & vbCr & "TextFileName : " & TxtRptName & vbCr & Err.Description & vbCr & "FieldName : " & str1, MsgBoxStyle.Critical)
    End Sub

    Public Sub SetParameter(ByVal ParaField As String, ByVal Para As String, ByRef CRReport As ReportDocument)
        Dim ParamField As New ParameterField
        Dim discreteVal As New ParameterDiscreteValue
        Dim rangeVal As New ParameterRangeValue
        Dim str1, str2 As String

        str1 = ParaField
        str2 = Para

        ParamField.ParameterFieldName = str1
        discreteVal.Value = str2

        ParamField.CurrentValues.Add(discreteVal)
        CRReport.DataDefinition.ParameterFields(str1).ApplyCurrentValues(ParamField.CurrentValues)
    End Sub

    Public Sub SetNlsLangUTF(ByVal DefaultLang As String)

        Dim NlsLang As String

        If (DefaultLang = "CN") Then
            'NlsLang = "SIMPLIFIED CHINESE_CHINA.ZHS16GBK"
            NlsLang = "SIMPLIFIED CHINESE_CHINA.UTF8"
        ElseIf (DefaultLang = "JA") Then
            'NlsLang = "JAPANESE_JAPAN.JA16SJIS"
            NlsLang = "JAPANESE_JAPAN.UTF8"
        ElseIf (DefaultLang = "KO") Then
            'NlsLang = "KOREAN_KOREA.KO16MSWIN949"
            NlsLang = "KOREAN_KOREA.UTF8"
        ElseIf (DefaultLang = "TW") Then
            'NlsLang = "TRADITIONAL CHINESE_TAIWAN.ZHT16MSWIN950"
            NlsLang = "TRADITIONAL CHINESE_TAIWAN.UTF8"
        ElseIf (DefaultLang = "US") Then
            'NlsLang = "AMERICAN_AMERICA.WE8MSWIN1252"
            NlsLang = "AMERICAN_AMERICA.UTF8"
        Else
            MsgBox("Language is ignore. LANG=" & DefaultLang, MsgBoxStyle.Critical)
        End If

        SetEnvironmentVariable("NLS_LANG", NlsLang)

    End Sub

    Public Sub SetParameters_SubReport(ByVal TxtRptName As String, ByVal CRReport As ReportDocument, ByVal SubRptName As String)
        Dim ParamField As New ParameterField
        Dim discreteVal As New ParameterDiscreteValue
        Dim rangeVal As New ParameterRangeValue
        Dim LineTemp As String
        Dim str1, str2 As String
        Dim LangTxtRptName As String

        On Error GoTo EndLabel

        '2019.04.10 del start 仮
        'LangTxtRptName = "LANG\" & Rpt_Lang & "\" & TxtRptName
        '2019.04.10 del end

        Dim fs As New System.IO.FileStream(VB6.GetPath & "\" & LangTxtRptName, System.IO.FileMode.Open, IO.FileAccess.Read)
        Dim sr As New System.IO.StreamReader(fs, System.Text.Encoding.GetEncoding("Unicode"))

        Do While sr.Peek > -1
            LineTemp = sr.ReadLine()

            str1 = Mid(LineTemp, 1, InStr(LineTemp, Chr(9)) - 1)
            LineTemp = Mid(LineTemp, Len(str1) + 2)

            If InStr(LineTemp, Chr(9)) <> 0 Then
                str2 = Mid(LineTemp, 1, InStr(LineTemp, Chr(9)) - 1)
            Else
                str2 = Trim(LineTemp)
            End If

            On Error Resume Next

            If Trim(str1) = "L_FONT" Then
                ' 
                Dim FontName As String
                '2019.04.10 del start 仮
                'FontName = FontTable(IndexOfLang(Nat_Lang_Cls), IndexOfLang(Rpt_Lang))
                '2019.04.10 del end
                If (StrConv(FontName, VbStrConv.Uppercase) <> "DEFAULT") Then
                    str2 = FontName
                End If

                Dim ffs As FontFamily() = FontFamily.Families
                Dim ff As FontFamily
                Dim FONT_FLG As Boolean = False

                For Each ff In ffs
                    If Trim(str2) = Trim(ff.Name) Then
                        str2 = ff.Name
                        FONT_FLG = True
                        Exit For
                    End If
                Next ff

                If FONT_FLG = False Then
                    '2019.04.10 del start 仮
                    'If (Nat_Lang_Cls = "CN" Or Rpt_Lang = "CN") Then
                    '    str2 = "SimSun"
                    'Else
                    '    Select Case Nat_Lang_Cls
                    '        Case "JA"
                    '            str2 = "MS UI Gothic"
                    '        Case "US"
                    '            str2 = "Times New Roman"
                    '        Case "CN"
                    '            str2 = "SimSun"
                    '        Case "TW"
                    '            str2 = "MingLiU"
                    '        Case "KO"
                    '            str2 = "BatangChe"
                    '    End Select
                    'End If
                    '2019.04.10 del end

                End If

            End If


            ParamField.ParameterFieldName = str1
            discreteVal.Value = str2

            ParamField.CurrentValues.Add(discreteVal)

            CRReport.DataDefinition.ParameterFields(str1, SubRptName).ApplyCurrentValues(ParamField.CurrentValues)

            On Error GoTo EndLabel2

            ParamField = New ParameterField
            discreteVal = New ParameterDiscreteValue
        Loop
        sr.Close()

        Exit Sub
EndLabel2:
        sr.Close()
EndLabel:
        MsgBox("Error occured in SetParameters. " & vbCr & "TextFileName : " & TxtRptName & vbCr & Err.Description & vbCr & "FieldName : " & str1, MsgBoxStyle.Critical)
    End Sub

    Public Function GetPrintCondition(ByVal Faccd As String, ByVal Pgid As String, ByVal Flg As String) As Object
        Dim WkDynaset As Object
        Dim WkQuery As String

        WkQuery = "SELECT * FROM T_BASE_MS "
        WkQuery = WkQuery & "WHERE "
        WkQuery = WkQuery & " I_FAC_CD = '" & Faccd & "'"
        WkQuery = WkQuery & " AND I_BASE_FM = '" & Pgid & "'"
        WkQuery = WkQuery & " AND I_BASE_CD = '" & Flg & "'"
        '2019.04.10 del start 仮
        'WkDynaset = OraDatabase.DbCreateDynaset(WkQuery, 2)
        '2019.04.10 del end
        If WkDynaset.EOF = True Then
            GetPrintCondition = "00"
            Exit Function
        End If
        WkDynaset.MoveFirst()

        If Flg = "PDFPRINT" Then
            GetPrintCondition = IIf(IsDBNull(WkDynaset.Fields("I_BASE_ST").Value), "00", Trim(WkDynaset.Fields("I_BASE_ST").Value))
        ElseIf Flg = "PDFPATH" Then
            GetPrintCondition = IIf(IsDBNull(WkDynaset.Fields("I_BASE_ST").Value), "00", Trim(WkDynaset.Fields("I_BASE_ST").Value))
        Else
            GetPrintCondition = "00"
        End If
    End Function

    Public Sub SetParametersFromLang(ByVal TextFileName As String, ByRef CRReport As CrystalDecisions.CrystalReports.Engine.ReportDocument)

        Dim i, wLen As Integer, FormulaFieldName, ItemDesc As String, Found As Boolean

        For i = 0 To CRReport.DataDefinition.FormulaFields.Count - 1
            FormulaFieldName = StrConv(CRReport.DataDefinition.FormulaFields.Item(i).Name, VbStrConv.Uppercase)
            wLen = Len(FormulaFieldName) - 3
            Found = False
            If (FormulaFieldName Like "*_JA") Then
                Call GetTitleLang(Left(FormulaFieldName, wLen), TextFileName, ItemDesc, "JA")
                Found = True
            ElseIf (FormulaFieldName Like "*_US") Then
                Call GetTitleLang(Left(FormulaFieldName, wLen), TextFileName, ItemDesc, "US")
                Found = True
            ElseIf (FormulaFieldName Like "*_KO") Then
                Call GetTitleLang(Left(FormulaFieldName, wLen), TextFileName, ItemDesc, "KO")
                Found = True
            ElseIf (FormulaFieldName Like "*_TW") Then
                Call GetTitleLang(Left(FormulaFieldName, wLen), TextFileName, ItemDesc, "TW")
                Found = True
            ElseIf (FormulaFieldName Like "*_CN") Then
                Call GetTitleLang(Left(FormulaFieldName, wLen), TextFileName, ItemDesc, "CN")
                Found = True
            End If
            If (Found) Then CRReport.DataDefinition.FormulaFields.Item(FormulaFieldName).Text = "'" & ItemDesc & "'"
        Next
    End Sub

    Public Sub GetTitleLang(ByRef ItemID As String, ByVal FileID As String, ByRef ItemName As String, ByVal Lang As String)
        '2019.04.10 del start 仮
        'Dim wRpt_Lang As String = Rpt_Lang

        'Rpt_Lang = Lang

        'Call GetTitle(ItemID, FileID, ItemName)

        'Rpt_Lang = wRpt_Lang
        '2019.04.10 del end
EndLabel:
    End Sub

End Class
