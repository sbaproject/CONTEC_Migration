<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.ComponentModel.ToolboxItem(True)> _
Partial Class Template1
    Inherits GrapeCity.Win.MultiRow.Template

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'MultiRow テンプレート デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは MultiRow テンプレート デザイナで必要です。
    'MultiRow テンプレート デザイナを使用して変更できます。 
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim CellStyle4 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border4 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle5 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border5 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle6 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border6 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Me.ColumnHeaderSection1 = New GrapeCity.Win.MultiRow.ColumnHeaderSection()
        Me.ColumnHeaderCell1 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.ColumnHeaderCell2 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.ColumnHeaderCell3 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.GcTextBoxCell1 = New GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell(False)
        Me.GcTextBoxCell2 = New GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell(False)
        Me.GcTextBoxCell3 = New GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell(False)
        '
        'Row
        '
        Me.Row.Cells.Add(Me.GcTextBoxCell1)
        Me.Row.Cells.Add(Me.GcTextBoxCell2)
        Me.Row.Cells.Add(Me.GcTextBoxCell3)
        Me.Row.Height = 21
        Me.Row.Width = 262
        '
        'ColumnHeaderSection1
        '
        Me.ColumnHeaderSection1.Cells.Add(Me.ColumnHeaderCell1)
        Me.ColumnHeaderSection1.Cells.Add(Me.ColumnHeaderCell2)
        Me.ColumnHeaderSection1.Cells.Add(Me.ColumnHeaderCell3)
        Me.ColumnHeaderSection1.Height = 20
        Me.ColumnHeaderSection1.Name = "ColumnHeaderSection1"
        Me.ColumnHeaderSection1.Width = 262
        '
        'ColumnHeaderCell1
        '
        Me.ColumnHeaderCell1.Location = New System.Drawing.Point(0, 0)
        Me.ColumnHeaderCell1.Name = "ColumnHeaderCell1"
        Me.ColumnHeaderCell1.Size = New System.Drawing.Size(45, 20)
        Border4.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle4.Border = Border4
        CellStyle4.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleCenter
        Me.ColumnHeaderCell1.Style = CellStyle4
        Me.ColumnHeaderCell1.TabIndex = 0
        Me.ColumnHeaderCell1.Value = "№"
        '
        'ColumnHeaderCell2
        '
        Me.ColumnHeaderCell2.Location = New System.Drawing.Point(45, 0)
        Me.ColumnHeaderCell2.Name = "ColumnHeaderCell2"
        Me.ColumnHeaderCell2.Size = New System.Drawing.Size(140, 20)
        Border5.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle5.Border = Border5
        CellStyle5.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleCenter
        Me.ColumnHeaderCell2.Style = CellStyle5
        Me.ColumnHeaderCell2.TabIndex = 1
        Me.ColumnHeaderCell2.Value = "シリアル№"
        '
        'ColumnHeaderCell3
        '
        Me.ColumnHeaderCell3.Location = New System.Drawing.Point(185, 0)
        Me.ColumnHeaderCell3.Name = "ColumnHeaderCell3"
        Me.ColumnHeaderCell3.Size = New System.Drawing.Size(77, 20)
        Border6.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle6.Border = Border6
        CellStyle6.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleCenter
        Me.ColumnHeaderCell3.Style = CellStyle6
        Me.ColumnHeaderCell3.TabIndex = 2
        Me.ColumnHeaderCell3.Value = "棚番"
        '
        'GcTextBoxCell1
        '
        Me.GcTextBoxCell1.Location = New System.Drawing.Point(0, 0)
        Me.GcTextBoxCell1.Name = "GcTextBoxCell1"
        Me.GcTextBoxCell1.ShortcutKeys.AddRange(New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry() {New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")})
        Me.GcTextBoxCell1.Size = New System.Drawing.Size(45, 21)
        Me.GcTextBoxCell1.TabIndex = 0
        '
        'GcTextBoxCell2
        '
        Me.GcTextBoxCell2.Location = New System.Drawing.Point(45, 0)
        Me.GcTextBoxCell2.MaxLength = 13
        Me.GcTextBoxCell2.Name = "GcTextBoxCell2"
        Me.GcTextBoxCell2.ShortcutKeys.AddRange(New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry() {New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")})
        Me.GcTextBoxCell2.Size = New System.Drawing.Size(140, 21)
        Me.GcTextBoxCell2.TabIndex = 1
        '
        'GcTextBoxCell3
        '
        Me.GcTextBoxCell3.Location = New System.Drawing.Point(185, 0)
        Me.GcTextBoxCell3.MaxLength = 9
        Me.GcTextBoxCell3.Name = "GcTextBoxCell3"
        Me.GcTextBoxCell3.ShortcutKeys.AddRange(New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry() {New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")})
        Me.GcTextBoxCell3.Size = New System.Drawing.Size(77, 21)
        Me.GcTextBoxCell3.TabIndex = 2
        '
        'Template1
        '
        Me.ColumnHeaders.AddRange(New GrapeCity.Win.MultiRow.ColumnHeaderSection() {Me.ColumnHeaderSection1})
        Me.Height = 41
        Me.Width = 262

    End Sub
    Friend WithEvents ColumnHeaderSection1 As GrapeCity.Win.MultiRow.ColumnHeaderSection
    Friend WithEvents GcTextBoxCell1 As GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell
    Friend WithEvents GcTextBoxCell2 As GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell
    Friend WithEvents GcTextBoxCell3 As GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell
    Friend WithEvents ColumnHeaderCell1 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Friend WithEvents ColumnHeaderCell2 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Friend WithEvents ColumnHeaderCell3 As GrapeCity.Win.MultiRow.ColumnHeaderCell
End Class
