<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.ComponentModel.ToolboxItem(True)> _
Partial Class Template3
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
        Dim Border1 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle3 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border2 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle4 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border3 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle5 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border4 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle1 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim CellStyle2 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Me.columnHeaderSection1 = New GrapeCity.Win.MultiRow.ColumnHeaderSection()
        Me.columnHeaderCell1 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.columnHeaderCell2 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.columnHeaderCell3 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.columnHeaderCell4 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.columnHeaderCell5 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.textBoxCell3 = New GrapeCity.Win.MultiRow.TextBoxCell()
        Me.textBoxCell4 = New GrapeCity.Win.MultiRow.TextBoxCell()
        Me.GcTextBoxCell1 = New GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell(False)
        Me.GcTextBoxCell2 = New GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell(False)
        Me.CheckBoxCell1 = New GrapeCity.Win.MultiRow.CheckBoxCell()
        '
        'Row
        '
        Border1.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        Me.Row.Border = Border1
        Me.Row.Cells.Add(Me.textBoxCell3)
        Me.Row.Cells.Add(Me.textBoxCell4)
        Me.Row.Cells.Add(Me.GcTextBoxCell1)
        Me.Row.Cells.Add(Me.GcTextBoxCell2)
        Me.Row.Cells.Add(Me.CheckBoxCell1)
        Me.Row.Height = 21
        Me.Row.Width = 196
        '
        'columnHeaderSection1
        '
        Me.columnHeaderSection1.Cells.Add(Me.columnHeaderCell1)
        Me.columnHeaderSection1.Cells.Add(Me.columnHeaderCell2)
        Me.columnHeaderSection1.Cells.Add(Me.columnHeaderCell3)
        Me.columnHeaderSection1.Cells.Add(Me.columnHeaderCell4)
        Me.columnHeaderSection1.Cells.Add(Me.columnHeaderCell5)
        Me.columnHeaderSection1.Height = 20
        Me.columnHeaderSection1.Name = "columnHeaderSection1"
        Me.columnHeaderSection1.Width = 196
        '
        'columnHeaderCell1
        '
        Me.columnHeaderCell1.HoverDirection = GrapeCity.Win.MultiRow.HoverDirection.None
        Me.columnHeaderCell1.Location = New System.Drawing.Point(36, 0)
        Me.columnHeaderCell1.Name = "columnHeaderCell1"
        Border2.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle3.Border = Border2
        CellStyle3.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleCenter
        Me.columnHeaderCell1.Style = CellStyle3
        Me.columnHeaderCell1.TabIndex = 0
        Me.columnHeaderCell1.Value = "№"
        '
        'columnHeaderCell2
        '
        Me.columnHeaderCell2.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.columnHeaderCell2.FlatAppearance.BorderSize = 1
        Me.columnHeaderCell2.HoverDirection = GrapeCity.Win.MultiRow.HoverDirection.None
        Me.columnHeaderCell2.Location = New System.Drawing.Point(116, 0)
        Me.columnHeaderCell2.Name = "columnHeaderCell2"
        Border3.Bottom = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        Border3.Right = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        Border3.Top = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle4.Border = Border3
        CellStyle4.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleCenter
        Me.columnHeaderCell2.Style = CellStyle4
        Me.columnHeaderCell2.TabIndex = 1
        Me.columnHeaderCell2.Value = "シリアル№"
        '
        'columnHeaderCell3
        '
        Me.columnHeaderCell3.Location = New System.Drawing.Point(36, 20)
        Me.columnHeaderCell3.Name = "columnHeaderCell3"
        Me.columnHeaderCell3.TabIndex = 2
        '
        'columnHeaderCell4
        '
        Me.columnHeaderCell4.Location = New System.Drawing.Point(116, 20)
        Me.columnHeaderCell4.Name = "columnHeaderCell4"
        Me.columnHeaderCell4.TabIndex = 3
        '
        'columnHeaderCell5
        '
        Me.columnHeaderCell5.HoverDirection = GrapeCity.Win.MultiRow.HoverDirection.None
        Me.columnHeaderCell5.Location = New System.Drawing.Point(0, 0)
        Me.columnHeaderCell5.Name = "columnHeaderCell5"
        Me.columnHeaderCell5.ResizeMode = GrapeCity.Win.MultiRow.ResizeMode.None
        Me.columnHeaderCell5.SelectionMode = GrapeCity.Win.MultiRow.MultiRowSelectionMode.AllRows
        Me.columnHeaderCell5.Size = New System.Drawing.Size(36, 20)
        Border4.Bottom = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        Border4.Left = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        Border4.Right = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        Border4.Top = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle5.Border = Border4
        Me.columnHeaderCell5.Style = CellStyle5
        Me.columnHeaderCell5.TabIndex = 4
        '
        'textBoxCell3
        '
        Me.textBoxCell3.Location = New System.Drawing.Point(36, 21)
        Me.textBoxCell3.Name = "textBoxCell3"
        Me.textBoxCell3.TabIndex = 2
        '
        'textBoxCell4
        '
        Me.textBoxCell4.Location = New System.Drawing.Point(116, 21)
        Me.textBoxCell4.Name = "textBoxCell4"
        Me.textBoxCell4.TabIndex = 3
        '
        'GcTextBoxCell1
        '
        Me.GcTextBoxCell1.Location = New System.Drawing.Point(36, 0)
        Me.GcTextBoxCell1.Name = "GcTextBoxCell1"
        Me.GcTextBoxCell1.ShortcutKeys.AddRange(New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry() {New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")})
        CellStyle1.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleLeft
        Me.GcTextBoxCell1.Style = CellStyle1
        Me.GcTextBoxCell1.TabIndex = 5
        '
        'GcTextBoxCell2
        '
        Me.GcTextBoxCell2.Location = New System.Drawing.Point(116, 0)
        Me.GcTextBoxCell2.Name = "GcTextBoxCell2"
        Me.GcTextBoxCell2.ShortcutKeys.AddRange(New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry() {New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")})
        CellStyle2.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleLeft
        Me.GcTextBoxCell2.Style = CellStyle2
        Me.GcTextBoxCell2.TabIndex = 6
        '
        'CheckBoxCell1
        '
        Me.CheckBoxCell1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxCell1.Location = New System.Drawing.Point(0, 0)
        Me.CheckBoxCell1.Name = "CheckBoxCell1"
        Me.CheckBoxCell1.Size = New System.Drawing.Size(36, 21)
        Me.CheckBoxCell1.TabIndex = 7
        '
        'Template3
        '
        Me.ColumnHeaders.AddRange(New GrapeCity.Win.MultiRow.ColumnHeaderSection() {Me.columnHeaderSection1})
        Me.Height = 41
        Me.Width = 196

    End Sub


    Private columnHeaderSection1 As GrapeCity.Win.MultiRow.ColumnHeaderSection
    Private columnHeaderCell1 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Private columnHeaderCell2 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Private columnHeaderCell3 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Private columnHeaderCell4 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Private columnHeaderCell5 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Private textBoxCell3 As GrapeCity.Win.MultiRow.TextBoxCell
    Private textBoxCell4 As GrapeCity.Win.MultiRow.TextBoxCell
    Friend WithEvents GcTextBoxCell1 As GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell

    Friend WithEvents GcTextBoxCell2 As GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell
    Friend WithEvents CheckBoxCell1 As GrapeCity.Win.MultiRow.CheckBoxCell
End Class
