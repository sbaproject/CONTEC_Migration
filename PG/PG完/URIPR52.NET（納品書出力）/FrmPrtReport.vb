Public Class FrmPrtReport
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
    Friend WithEvents L_PRTNAME As System.Windows.Forms.Label
    Friend WithEvents C_PRTNAME As System.Windows.Forms.ComboBox
    Friend WithEvents G_PRTRANGE As System.Windows.Forms.GroupBox
    Friend WithEvents ALL As System.Windows.Forms.RadioButton
    Friend WithEvents SPACIFY As System.Windows.Forms.RadioButton
    Friend WithEvents L_START As System.Windows.Forms.Label
    Friend WithEvents L_END As System.Windows.Forms.Label
    Friend WithEvents I_QTY As System.Windows.Forms.TextBox
    Friend WithEvents L_QTY As System.Windows.Forms.Label
    Friend WithEvents I_END As System.Windows.Forms.TextBox
    Friend WithEvents I_START As System.Windows.Forms.TextBox
    Friend WithEvents B_PRT As System.Windows.Forms.Button
    Friend WithEvents B_CAN As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.L_PRTNAME = New System.Windows.Forms.Label
        Me.C_PRTNAME = New System.Windows.Forms.ComboBox
        Me.G_PRTRANGE = New System.Windows.Forms.GroupBox
        Me.L_END = New System.Windows.Forms.Label
        Me.L_START = New System.Windows.Forms.Label
        Me.I_END = New System.Windows.Forms.TextBox
        Me.I_START = New System.Windows.Forms.TextBox
        Me.SPACIFY = New System.Windows.Forms.RadioButton
        Me.ALL = New System.Windows.Forms.RadioButton
        Me.B_PRT = New System.Windows.Forms.Button
        Me.B_CAN = New System.Windows.Forms.Button
        Me.I_QTY = New System.Windows.Forms.TextBox
        Me.L_QTY = New System.Windows.Forms.Label
        Me.G_PRTRANGE.SuspendLayout()
        Me.SuspendLayout()
        '
        'L_PRTNAME
        '
        Me.L_PRTNAME.BackColor = System.Drawing.SystemColors.Control
        Me.L_PRTNAME.Location = New System.Drawing.Point(2, 12)
        Me.L_PRTNAME.Name = "L_PRTNAME"
        Me.L_PRTNAME.Size = New System.Drawing.Size(136, 20)
        Me.L_PRTNAME.TabIndex = 0
        Me.L_PRTNAME.Text = "L_PRTNAME"
        Me.L_PRTNAME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'C_PRTNAME
        '
        Me.C_PRTNAME.Location = New System.Drawing.Point(140, 12)
        Me.C_PRTNAME.Name = "C_PRTNAME"
        Me.C_PRTNAME.Size = New System.Drawing.Size(250, 20)
        Me.C_PRTNAME.TabIndex = 1
        '
        'G_PRTRANGE
        '
        Me.G_PRTRANGE.Controls.Add(Me.L_END)
        Me.G_PRTRANGE.Controls.Add(Me.L_START)
        Me.G_PRTRANGE.Controls.Add(Me.I_END)
        Me.G_PRTRANGE.Controls.Add(Me.I_START)
        Me.G_PRTRANGE.Controls.Add(Me.SPACIFY)
        Me.G_PRTRANGE.Controls.Add(Me.ALL)
        Me.G_PRTRANGE.Location = New System.Drawing.Point(12, 54)
        Me.G_PRTRANGE.Name = "G_PRTRANGE"
        Me.G_PRTRANGE.Size = New System.Drawing.Size(258, 114)
        Me.G_PRTRANGE.TabIndex = 2
        Me.G_PRTRANGE.TabStop = False
        Me.G_PRTRANGE.Text = "G_PRTRANGE"
        '
        'L_END
        '
        Me.L_END.BackColor = System.Drawing.SystemColors.Control
        Me.L_END.Location = New System.Drawing.Point(128, 77)
        Me.L_END.Name = "L_END"
        Me.L_END.Size = New System.Drawing.Size(58, 20)
        Me.L_END.TabIndex = 110
        Me.L_END.Text = "L_END"
        Me.L_END.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'L_START
        '
        Me.L_START.BackColor = System.Drawing.SystemColors.Control
        Me.L_START.Location = New System.Drawing.Point(16, 77)
        Me.L_START.Name = "L_START"
        Me.L_START.Size = New System.Drawing.Size(58, 20)
        Me.L_START.TabIndex = 100
        Me.L_START.Text = "L_START"
        Me.L_START.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'I_END
        '
        Me.I_END.Location = New System.Drawing.Point(188, 78)
        Me.I_END.MaxLength = 4
        Me.I_END.Name = "I_END"
        Me.I_END.Size = New System.Drawing.Size(50, 19)
        Me.I_END.TabIndex = 6
        Me.I_END.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'I_START
        '
        Me.I_START.Location = New System.Drawing.Point(76, 78)
        Me.I_START.MaxLength = 4
        Me.I_START.Name = "I_START"
        Me.I_START.Size = New System.Drawing.Size(50, 19)
        Me.I_START.TabIndex = 5
        Me.I_START.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'SPACIFY
        '
        Me.SPACIFY.Location = New System.Drawing.Point(16, 46)
        Me.SPACIFY.Name = "SPACIFY"
        Me.SPACIFY.Size = New System.Drawing.Size(134, 20)
        Me.SPACIFY.TabIndex = 4
        Me.SPACIFY.Text = "SPACIFY"
        '
        'ALL
        '
        Me.ALL.Location = New System.Drawing.Point(16, 20)
        Me.ALL.Name = "ALL"
        Me.ALL.Size = New System.Drawing.Size(134, 20)
        Me.ALL.TabIndex = 3
        Me.ALL.Text = "ALL"
        '
        'B_PRT
        '
        Me.B_PRT.Location = New System.Drawing.Point(300, 108)
        Me.B_PRT.Name = "B_PRT"
        Me.B_PRT.Size = New System.Drawing.Size(84, 26)
        Me.B_PRT.TabIndex = 4
        Me.B_PRT.Text = "B_PRT"
        '
        'B_CAN
        '
        Me.B_CAN.Location = New System.Drawing.Point(300, 136)
        Me.B_CAN.Name = "B_CAN"
        Me.B_CAN.Size = New System.Drawing.Size(84, 26)
        Me.B_CAN.TabIndex = 5
        Me.B_CAN.Text = "B_CAN"
        '
        'I_QTY
        '
        Me.I_QTY.Location = New System.Drawing.Point(341, 66)
        Me.I_QTY.MaxLength = 4
        Me.I_QTY.Name = "I_QTY"
        Me.I_QTY.Size = New System.Drawing.Size(46, 19)
        Me.I_QTY.TabIndex = 3
        Me.I_QTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'L_QTY
        '
        Me.L_QTY.BackColor = System.Drawing.SystemColors.Control
        Me.L_QTY.Location = New System.Drawing.Point(276, 65)
        Me.L_QTY.Name = "L_QTY"
        Me.L_QTY.Size = New System.Drawing.Size(63, 20)
        Me.L_QTY.TabIndex = 6
        Me.L_QTY.Text = "L_QTY"
        Me.L_QTY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmPrtReport
        '
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(410, 200)
        Me.Controls.Add(Me.L_QTY)
        Me.Controls.Add(Me.I_QTY)
        Me.Controls.Add(Me.B_CAN)
        Me.Controls.Add(Me.B_PRT)
        Me.Controls.Add(Me.G_PRTRANGE)
        Me.Controls.Add(Me.C_PRTNAME)
        Me.Controls.Add(Me.L_PRTNAME)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HelpButton = True
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(418, 208)
        Me.Name = "FrmPrtReport"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FrmPrtReport"
        Me.G_PRTRANGE.ResumeLayout(False)
        Me.G_PRTRANGE.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim RptPrt As String
    Dim PrtType As Integer
    Dim RptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument

    Private Sub FrmPrtReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer

        'CHG START FKS)MORI [For GS]
        'Call Atr_PrtReport()
        '2019.04.10 del start 仮2
        'If IsNothing(OraDatabase) Then
        '    ORA_CHECK()
        'End If
        'Dim SetAtr As New SetAtr.SetAtr
        'SetAtr.SetAtr(Me, "FrmPrtReport.txt", User_Lang, OraDatabase)
        '2019.04.10 del end

        'CHG E N D FKS)MORI [For GS]

        C_PRTNAME.Items.Add("-----------------------------------")
        '2019.04.10 chg start 仮2
        'For Each PrinterName In Printing.PrinterSettings.InstalledPrinters
        '    C_PRTNAME.Items.Add(PrinterName)
        'Next
        For Each PrinterName As String In Printing.PrinterSettings.InstalledPrinters
            C_PRTNAME.Items.Add(PrinterName)
        Next
        '2019.04.10 chg end
        For i = 0 To C_PRTNAME.Items.Count - 1
            If C_PRTNAME.Items(i) = RptPrt Then
                C_PRTNAME.SelectedIndex = i
                GoTo EndLabel
            End If
        Next
        C_PRTNAME.SelectedIndex = 0
EndLabel:
        I_QTY.Text = 1
        ALL.Checked = True
        False_Range()
        C_PRTNAME.Focus()
    End Sub

    Private Sub SPACIFY_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SPACIFY.MouseDown
        SPACIFY.Checked = True
        True_Range()
        I_START.Focus()
    End Sub

    Private Sub ALL_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ALL.MouseDown
        ALL.Checked = True
        False_Range()
        B_PRT.Focus()
    End Sub

    Private Sub I_START_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles I_START.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)

        Select Case KeyAscii
            Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
            Case System.Windows.Forms.Keys.Back
            Case System.Windows.Forms.Keys.Return
                'ADD START FKS)OGAWA V102009062503
                If Not IsNumeric(Trim(I_START.Text)) Then
                    I_START.Text = 1
                End If
                'ADD E N D FKS)OGAWA V102009062503
                If Len(Trim(I_START.Text)) = 0 Then
                    I_START.Text = 1
                ElseIf CInt(I_START.Text) = 0 Then
                    I_START.Text = 1
                End If
                I_END.Focus()
            Case Else
                KeyAscii = 0
        End Select

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub I_END_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles I_END.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)

        Select Case KeyAscii
            Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
            Case System.Windows.Forms.Keys.Back
            Case System.Windows.Forms.Keys.Return
                'ADD START FKS)OGAWA V102009062503
                If Not IsNumeric(Trim(I_START.Text)) Then
                    I_START.Text = 1
                End If
                If Not IsNumeric(Trim(I_END.Text)) Then
                    I_END.Text = 1
                End If
                If Len(Trim(I_START.Text)) = 0 Then
                    I_START.Text = 1
                ElseIf CInt(I_START.Text) = 0 Then
                    I_START.Text = 1
                End If
                'ADD E N D FKS)OGAWA V102009062503
                If Len(Trim(I_END.Text)) = 0 Then
                    I_END.Text = 9999
                ElseIf CInt(I_END.Text) = 0 Then
                    I_END.Text = 9999
                End If
                If CInt(I_END.Text) - CInt(I_START.Text) < 0 Then
                    '2019.04.10 del start 仮2
                    'Msg_Code = 2228
                    'Set_ErrMsg()
                    '2019.04.10 del end
                    I_END.Focus()
                    I_END.SelectAll()
                    Exit Sub
                End If
                B_PRT.Focus()
            Case Else
                KeyAscii = 0
        End Select

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub I_QTY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles I_QTY.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)

        Select Case KeyAscii
            Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
            Case System.Windows.Forms.Keys.Back
            Case System.Windows.Forms.Keys.Return
                'ADD START FKS)OGAWA V102009062503
                If Not IsNumeric(Trim(I_QTY.Text)) Then
                    I_QTY.Text = 1
                End If
                'ADD E N D FKS)OGAWA V102009062503
                B_PRT.Focus()
            Case Else
                KeyAscii = 0
        End Select

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub C_PRTNAME_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles C_PRTNAME.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)

        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Return
                B_PRT.Focus()
        End Select
    End Sub

    Private Sub B_CAN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_CAN.Click
        Me.Close()
    End Sub

    Private Sub B_PRT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_PRT.Click
        Dim InsatsuBusu As Integer
        Dim StrPage As Integer
        Dim EndPage As Integer

        'V10L11 ADD START FKS)NISHIBAYASHI 20040709
        B_PRT.Enabled = False
        'V10L11 ADD E N D FKS)NISHIBAYASHI 20040709

        'ADD START FKS)OGAWA V102009062503
        If Not IsNumeric(Trim(I_QTY.Text)) Then
            I_QTY.Text = 1
        End If
        'ADD E N D FKS)OGAWA V102009062503
        InsatsuBusu = Me.I_QTY.Text
        If ALL.Checked Then
            StrPage = 1
            EndPage = 9999
        Else
            'ADD START FKS)OGAWA V102009062503
            If Not IsNumeric(Trim(I_START.Text)) Then
                I_START.Text = 1
            End If
            If Not IsNumeric(Trim(I_END.Text)) Then
                I_END.Text = 1
            End If
            'ADD E N D FKS)OGAWA V102009062503
            If Len(Trim(I_START.Text)) = 0 Then
                I_START.Text = 1
            ElseIf CInt(I_START.Text) = 0 Then
                I_START.Text = 1
            End If
            If Len(Trim(I_END.Text)) = 0 Then
                I_END.Text = 9999
            ElseIf CInt(I_END.Text) = 0 Then
                I_END.Text = 9999
            End If
            If CInt(I_END.Text) - CInt(I_START.Text) < 0 Then
                '2019.04.10 del start
                'Msg_Code = 2228
                'Set_ErrMsg()
                '2019.04.10 del end
                I_END.Focus()
                I_END.SelectAll()
                Exit Sub
            End If
            StrPage = CInt(Me.I_START.Text)
            EndPage = CInt(Me.I_END.Text)
        End If
        'CHG START BFS)XIU V102008101603
        'If C_PRTNAME.SelectedItem <> "-----------------------------------" Then
        If C_PRTNAME.SelectedItem = "-----------------------------------" Or C_PRTNAME.SelectedItem = "" Then
            '2019.04.10 del start
            'Msg_Code = 22563
            'Set_ErrMsg()
            '2019.04.10 del end
            C_PRTNAME.Focus()
            B_PRT.Enabled = True
            Dim i As Integer
            For i = 0 To C_PRTNAME.Items.Count - 1
                If C_PRTNAME.Items(i) = RptPrt Then
                    C_PRTNAME.SelectedIndex = i
                End If
            Next
            C_PRTNAME.Focus()
            Exit Sub
        Else
            'CHG E N D BFS)XIU V102008101603
            'CHG START FKS)KAMATA V102004022301
            'On Error Resume Next
            'RptDoc.PrintOptions.PrinterName = C_PRTNAME.SelectedItem
            Dim prDIALOG As New PrintDialog()
            Dim prDOCU As New Drawing.Printing.PrintDocument
            'ADD START FKS)UEDA V102004121201
            Dim printerSettings As New Printing.PrinterSettings
            Dim reportPaperSource As System.Drawing.Printing.PaperSource
            Dim printerSource As System.Drawing.Printing.PaperSource
            'ADD E N D FKS)UEDA V102004121201

            'CHG START FKS)KAMATA V102004022006
            'On Error Resume Next
            On Error GoTo ErrorHandler
            'CHG E N D FKS)KAMATA V102004022006
            prDOCU.PrinterSettings.PrinterName = C_PRTNAME.SelectedItem
            prDIALOG.Document = prDOCU
            RptDoc.PrintOptions.PrinterName = prDOCU.PrinterSettings.PrinterName
            'CHG START FKS)UEDA V102004121201
            'RptDoc.PrintOptions.PaperSource = prDOCU.DefaultPageSettings.PaperSource.Kind

            'CHG START FKS)NISHIBAYASHI V102005052901
            'For Each printerSource In printerSettings.PaperSources
            '    If printerSource.Kind.ToString = prDOCU.DefaultPageSettings.PaperSource.Kind.ToString Then
            '        reportPaperSource = printerSource
            '        Exit For
            '    End If
            'Next
            For Each printerSource In prDOCU.PrinterSettings.PaperSources
                If printerSource.SourceName.ToString = prDOCU.DefaultPageSettings.PaperSource.SourceName.ToString Then
                    reportPaperSource = printerSource
                    Exit For
                End If
            Next

            If reportPaperSource Is Nothing Then
                'V11L30 CHG START FKS)KAMATA 2006/03/27
                'MessageBox.Show("ReportPaperSource Is Nothing", "Err Msg", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'B_PRT.Enabled = True
                'Exit Sub
                reportPaperSource = prDOCU.DefaultPageSettings.PaperSource
                'V11L30 CHG E N D FKS)KAMATA 2006/03/27
            End If
            'CHG E N D FKS)NISHIBAYASHI V102005052901

            RptDoc.PrintOptions.CustomPaperSource = reportPaperSource
            'CHG E N D FKS)UEDA V102004121201

            RptDoc.PrintOptions.PaperSize = prDOCU.DefaultPageSettings.PaperSize.Kind

            'CHG E N D FKS)KAMATA V102004022301
            RptDoc.PrintToPrinter(InsatsuBusu, True, StrPage, EndPage)

            On Error Resume Next
        End If

        'V10L11 ADD START FKS)NISHIBAYASHI 20040709
        B_PRT.Enabled = True
        'V10L11 ADD E N D FKS)NISHIBAYASHI 20040709

        Me.Close()
        'ADD START FKS)KAMATA V102004022006
        Exit Sub
ErrorHandler:
        MsgBox(Err.Description)
        'CHG START FKS)NISHIBAYASHI V102005052901
        B_PRT.Enabled = True
        'CHG E N D FKS)NISHIBAYASHI V102005052901
        'ADD E N D FKS)KAMATA V102004022006
    End Sub

    Private Sub Atr_PrtReport()
        Dim Str1 As String
        Dim Str2 As String
        Dim Str3 As String
        Dim Str4 As String
        Dim Str5 As String
        Dim Str6 As String
        Dim Str7 As String
        Dim Str8 As String
        Dim Str9 As String
        Dim Str10 As String
        Dim Str11 As String
        Dim Str12 As String
        Dim Str13 As String
        Dim Str14 As String
        Dim Font1 As String
        Dim Font2 As String
        Dim Font3 As String
        Dim Font4 As String
        Dim Font5 As String
        Dim Font6 As String
        Dim Font7 As String
        Dim Font8 As String
        Dim Font9 As String
        Dim Font10 As String
        Dim Font11 As String
        Dim Font12 As String
        Dim Font13 As String
        Dim Font14 As String
        Dim FSize1 As Integer
        Dim FSize2 As Integer
        Dim FSize3 As Integer
        Dim FSize4 As Integer
        Dim FSize5 As Integer
        Dim FSize6 As Integer
        Dim FSize7 As Integer
        Dim FSize8 As Integer
        Dim FSize9 As Integer
        Dim FSize10 As Integer
        Dim FSize11 As Integer
        Dim FSize12 As Integer
        Dim FSize13 As Integer
        Dim FSize14 As Integer
        Dim Fep1 As Integer
        Dim Fep2 As Integer
        Dim Fep3 As Integer
        Dim Fep4 As Integer
        Dim Fep5 As Integer
        Dim Fep6 As Integer
        Dim Fep7 As Integer
        Dim Fep8 As Integer
        Dim Fep9 As Integer
        Dim Fep10 As Integer
        Dim Fep11 As Integer
        Dim Fep12 As Integer
        Dim Fep13 As Integer
        Dim Fep14 As Integer

        '2019.04.10 del start 仮2
        'GETDSPSTR("L_PRTNAME", Str1, Font1, FSize1, Fep1, "FrmPrtReport.txt")
        'GETDSPSTR("C_PRTNAME", Str2, Font2, FSize2, Fep2, "FrmPrtReport.txt")
        'GETDSPSTR("ALL", Str3, Font3, FSize3, Fep3, "FrmPrtReport.txt")
        'GETDSPSTR("SPACIFY", Str4, Font4, FSize4, Fep4, "FrmPrtReport.txt")
        'GETDSPSTR("L_START", Str5, Font5, FSize5, Fep5, "FrmPrtReport.txt")
        'GETDSPSTR("I_START", Str6, Font6, FSize6, Fep6, "FrmPrtReport.txt")
        'GETDSPSTR("L_END", Str7, Font7, FSize7, Fep7, "FrmPrtReport.txt")
        'GETDSPSTR("I_END", Str8, Font8, FSize8, Fep8, "FrmPrtReport.txt")
        'GETDSPSTR("L_QTY", Str9, Font9, FSize9, Fep9, "FrmPrtReport.txt")
        'GETDSPSTR("I_QTY", Str10, Font10, FSize10, Fep10, "FrmPrtReport.txt")
        'GETDSPSTR("B_PRT", Str11, Font11, FSize11, Fep11, "FrmPrtReport.txt")
        'GETDSPSTR("B_CAN", Str12, Font12, FSize12, Fep12, "FrmPrtReport.txt")
        'GETDSPSTR("FrmPrtReport", Str13, Font13, FSize13, Fep13, "FrmPrtReport.txt")
        'GETDSPSTR("G_PRTRANGE", Str14, Font14, FSize14, Fep14, "FrmPrtReport.txt")
        '2019.04.10 del end

        L_PRTNAME.Text = Str1
        If Len(Trim(Font1)) <> 0 Then
            L_PRTNAME.Font = VB6.FontChangeName(L_PRTNAME.Font, Font1)
            L_PRTNAME.Font = VB6.FontChangeSize(L_PRTNAME.Font, FSize1)
        End If
        If Len(Trim(Font2)) <> 0 Then
            C_PRTNAME.Font = VB6.FontChangeName(C_PRTNAME.Font, Font2)
            C_PRTNAME.Font = VB6.FontChangeSize(C_PRTNAME.Font, FSize2)
        End If
        ALL.Text = Str3
        If Len(Trim(Font3)) <> 0 Then
            ALL.Font = VB6.FontChangeName(ALL.Font, Font3)
            ALL.Font = VB6.FontChangeSize(ALL.Font, FSize3)
        End If
        SPACIFY.Text = Str4
        If Len(Trim(Font4)) <> 0 Then
            SPACIFY.Font = VB6.FontChangeName(SPACIFY.Font, Font4)
            SPACIFY.Font = VB6.FontChangeSize(SPACIFY.Font, FSize4)
        End If
        L_START.Text = Str5
        If Len(Trim(Font5)) <> 0 Then
            L_START.Font = VB6.FontChangeName(L_START.Font, Font5)
            L_START.Font = VB6.FontChangeSize(L_START.Font, FSize5)
        End If
        I_START.Text = Str6
        If Len(Trim(Font6)) <> 0 Then
            I_START.Font = VB6.FontChangeName(I_START.Font, Font6)
            I_START.Font = VB6.FontChangeSize(I_START.Font, FSize6)
        End If
        L_END.Text = Str7
        If Len(Trim(Font7)) <> 0 Then
            L_END.Font = VB6.FontChangeName(L_END.Font, Font7)
            L_END.Font = VB6.FontChangeSize(L_END.Font, FSize7)
        End If
        I_END.Text = Str8
        If Len(Trim(Font8)) <> 0 Then
            I_END.Font = VB6.FontChangeName(I_END.Font, Font8)
            I_END.Font = VB6.FontChangeSize(I_END.Font, FSize8)
        End If
        L_QTY.Text = Str9
        If Len(Trim(Font9)) <> 0 Then
            L_QTY.Font = VB6.FontChangeName(L_QTY.Font, Font9)
            L_QTY.Font = VB6.FontChangeSize(L_QTY.Font, FSize9)
        End If
        I_QTY.Text = Str10
        If Len(Trim(Font10)) <> 0 Then
            I_QTY.Font = VB6.FontChangeName(I_QTY.Font, Font10)
            I_QTY.Font = VB6.FontChangeSize(I_QTY.Font, FSize10)
        End If
        B_PRT.Text = Str11
        If Len(Trim(Font11)) <> 0 Then
            B_PRT.Font = VB6.FontChangeName(B_PRT.Font, Font11)
            B_PRT.Font = VB6.FontChangeSize(B_PRT.Font, FSize11)
        End If
        B_CAN.Text = Str12
        If Len(Trim(Font12)) <> 0 Then
            B_CAN.Font = VB6.FontChangeName(B_CAN.Font, Font12)
            B_CAN.Font = VB6.FontChangeSize(B_CAN.Font, FSize12)
        End If
        G_PRTRANGE.Text = Str14
        If Len(Trim(Font14)) <> 0 Then
            G_PRTRANGE.Font = VB6.FontChangeName(G_PRTRANGE.Font, Font14)
            G_PRTRANGE.Font = VB6.FontChangeSize(G_PRTRANGE.Font, FSize14)
        End If
        Me.Text = Str13
    End Sub

    Public Sub SetRptPrinter(ByVal PrtName As String, ByVal Rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        RptPrt = PrtName
        RptDoc = Rpt
    End Sub

    Private Sub ALL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ALL.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)

        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Return
                False_Range()
                B_PRT.Focus()
        End Select
    End Sub

    Private Sub SPACIFY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles SPACIFY.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)

        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Return
                True_Range()
                I_START.Focus()
        End Select
    End Sub

    Private Sub True_Range()
        I_START.Enabled = True
        I_END.Enabled = True
    End Sub

    Private Sub False_Range()
        I_START.Enabled = False
        I_END.Enabled = False
    End Sub
    'ADD START FKS)MORI 2009/02/10 SST0001
    '2019.04.10 del start 仮2
    'Private Sub I_QTY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles I_QTY.TextChanged
    '        I_QTY.Text = CHK_MAXLength(I_QTY)
    'End Sub
    'Private Sub I_END_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles I_END.TextChanged
    '        I_END.Text = CHK_MAXLength(I_END)
    'End Sub
    'Private Sub I_START_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles I_START.TextChanged
    '        I_START.Text = CHK_MAXLength(I_START)
    'End Sub
    '2019.04.10 del end
    'ADD E N D FKS)MORI 2009/02/10 SST0001
End Class
