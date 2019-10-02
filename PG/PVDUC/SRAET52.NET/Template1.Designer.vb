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
        Dim CellStyle1 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim CellStyle4 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim CellStyle5 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim CellStyle6 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim CellStyle2 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim CellStyle3 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Me.ColumnHeaderSection1 = New GrapeCity.Win.MultiRow.ColumnHeaderSection()
        Me.CheckBoxCell1 = New GrapeCity.Win.MultiRow.CheckBoxCell()
        Me.ColumnHeaderCell2 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.ColumnHeaderCell3 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.ColumnHeaderCell1 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.GcTextBoxCell1 = New GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell(False)
        Me.GcTextBoxCell2 = New GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell(False)
        '
        'Row
        '
        Me.Row.Cells.Add(Me.CheckBoxCell1)
        Me.Row.Cells.Add(Me.GcTextBoxCell1)
        Me.Row.Cells.Add(Me.GcTextBoxCell2)
        Me.Row.Height = 21
        Me.Row.Width = 213
        '
        'ColumnHeaderSection1
        '
        Me.ColumnHeaderSection1.Cells.Add(Me.ColumnHeaderCell2)
        Me.ColumnHeaderSection1.Cells.Add(Me.ColumnHeaderCell3)
        Me.ColumnHeaderSection1.Cells.Add(Me.ColumnHeaderCell1)
        Me.ColumnHeaderSection1.Height = 20
        Me.ColumnHeaderSection1.Name = "ColumnHeaderSection1"
        Me.ColumnHeaderSection1.Width = 213
        '
        'CheckBoxCell1
        '
        Me.CheckBoxCell1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxCell1.Location = New System.Drawing.Point(0, 0)
        Me.CheckBoxCell1.Name = "CheckBoxCell1"
        Me.CheckBoxCell1.Size = New System.Drawing.Size(26, 21)
        CellStyle1.ImeMode = System.Windows.Forms.ImeMode.Off
        CellStyle1.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleCenter
        Me.CheckBoxCell1.Style = CellStyle1
        Me.CheckBoxCell1.TabIndex = 0
        '
        'ColumnHeaderCell2
        '
        Me.ColumnHeaderCell2.HoverDirection = GrapeCity.Win.MultiRow.HoverDirection.None
        Me.ColumnHeaderCell2.Location = New System.Drawing.Point(26, 0)
        Me.ColumnHeaderCell2.Name = "ColumnHeaderCell2"
        Me.ColumnHeaderCell2.Size = New System.Drawing.Size(47, 20)
        CellStyle4.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleCenter
        Me.ColumnHeaderCell2.Style = CellStyle4
        Me.ColumnHeaderCell2.TabIndex = 3
        Me.ColumnHeaderCell2.Value = "№"
        '
        'ColumnHeaderCell3
        '
        Me.ColumnHeaderCell3.HoverDirection = GrapeCity.Win.MultiRow.HoverDirection.None
        Me.ColumnHeaderCell3.Location = New System.Drawing.Point(73, 0)
        Me.ColumnHeaderCell3.Name = "ColumnHeaderCell3"
        Me.ColumnHeaderCell3.Size = New System.Drawing.Size(140, 20)
        CellStyle5.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleCenter
        Me.ColumnHeaderCell3.Style = CellStyle5
        Me.ColumnHeaderCell3.TabIndex = 4
        Me.ColumnHeaderCell3.Value = "シリアル№"
        '
        'ColumnHeaderCell1
        '
        Me.ColumnHeaderCell1.HoverDirection = GrapeCity.Win.MultiRow.HoverDirection.None
        Me.ColumnHeaderCell1.Location = New System.Drawing.Point(0, 0)
        Me.ColumnHeaderCell1.Name = "ColumnHeaderCell1"
        Me.ColumnHeaderCell1.Size = New System.Drawing.Size(26, 20)
        CellStyle6.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleCenter
        Me.ColumnHeaderCell1.Style = CellStyle6
        Me.ColumnHeaderCell1.TabIndex = 5
        '
        'GcTextBoxCell1
        '
        Me.GcTextBoxCell1.Location = New System.Drawing.Point(26, 0)
        Me.GcTextBoxCell1.Name = "GcTextBoxCell1"
        Me.GcTextBoxCell1.ShortcutKeys.AddRange(New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry() {New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")})
        Me.GcTextBoxCell1.Size = New System.Drawing.Size(47, 21)
        CellStyle2.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleLeft
        Me.GcTextBoxCell1.Style = CellStyle2
        Me.GcTextBoxCell1.TabIndex = 1
        '
        'GcTextBoxCell2
        '
        Me.GcTextBoxCell2.Location = New System.Drawing.Point(73, 0)
        Me.GcTextBoxCell2.MaxLength = 22
        Me.GcTextBoxCell2.Name = "GcTextBoxCell2"
        Me.GcTextBoxCell2.ShortcutKeys.AddRange(New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry() {New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")})
        Me.GcTextBoxCell2.Size = New System.Drawing.Size(140, 21)
        CellStyle3.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleLeft
        Me.GcTextBoxCell2.Style = CellStyle3
        Me.GcTextBoxCell2.TabIndex = 2
        '
        'Template1
        '
        Me.ColumnHeaders.AddRange(New GrapeCity.Win.MultiRow.ColumnHeaderSection() {Me.ColumnHeaderSection1})
        Me.Height = 41
        Me.Width = 213

    End Sub
    Friend WithEvents ColumnHeaderSection1 As GrapeCity.Win.MultiRow.ColumnHeaderSection
    Friend WithEvents CheckBoxCell1 As GrapeCity.Win.MultiRow.CheckBoxCell
    Private WithEvents ColumnHeaderCell2 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Private WithEvents ColumnHeaderCell3 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Private WithEvents ColumnHeaderCell1 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Friend WithEvents GcTextBoxCell1 As GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell
    Friend WithEvents GcTextBoxCell2 As GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell
End Class
