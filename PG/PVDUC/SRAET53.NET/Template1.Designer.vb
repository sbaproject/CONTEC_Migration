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
        Dim CellStyle2 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim CellStyle3 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim CellStyle4 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim CellStyle1 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Me.ColumnHeaderSection1 = New GrapeCity.Win.MultiRow.ColumnHeaderSection()
        Me.ColumnHeaderCell2 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.ColumnHeaderCell3 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.ColumnHeaderCell1 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.ColumnHeaderCell4 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.ColumnHeaderCell5 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.ColumnHeaderCell6 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.ColumnHeaderCell7 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.CheckBoxCell1 = New GrapeCity.Win.MultiRow.CheckBoxCell()
        Me.GcTextBoxCell1 = New GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell(False)
        Me.GcTextBoxCell2 = New GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell(False)
        Me.GcTextBoxCell3 = New GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell(False)
        Me.GcTextBoxCell4 = New GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell(False)
        Me.GcTextBoxCell5 = New GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell(False)
        Me.GcTextBoxCell6 = New GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell(False)
        '
        'Row
        '
        Me.Row.Cells.Add(Me.CheckBoxCell1)
        Me.Row.Cells.Add(Me.GcTextBoxCell1)
        Me.Row.Cells.Add(Me.GcTextBoxCell2)
        Me.Row.Cells.Add(Me.GcTextBoxCell3)
        Me.Row.Cells.Add(Me.GcTextBoxCell4)
        Me.Row.Cells.Add(Me.GcTextBoxCell5)
        Me.Row.Cells.Add(Me.GcTextBoxCell6)
        Me.Row.Height = 21
        Me.Row.Width = 189
        '
        'ColumnHeaderSection1
        '
        Me.ColumnHeaderSection1.Cells.Add(Me.ColumnHeaderCell2)
        Me.ColumnHeaderSection1.Cells.Add(Me.ColumnHeaderCell3)
        Me.ColumnHeaderSection1.Cells.Add(Me.ColumnHeaderCell1)
        Me.ColumnHeaderSection1.Cells.Add(Me.ColumnHeaderCell4)
        Me.ColumnHeaderSection1.Cells.Add(Me.ColumnHeaderCell5)
        Me.ColumnHeaderSection1.Cells.Add(Me.ColumnHeaderCell6)
        Me.ColumnHeaderSection1.Cells.Add(Me.ColumnHeaderCell7)
        Me.ColumnHeaderSection1.Height = 20
        Me.ColumnHeaderSection1.Name = "ColumnHeaderSection1"
        Me.ColumnHeaderSection1.Width = 189
        '
        'ColumnHeaderCell2
        '
        Me.ColumnHeaderCell2.HoverDirection = GrapeCity.Win.MultiRow.HoverDirection.None
        Me.ColumnHeaderCell2.Location = New System.Drawing.Point(24, 0)
        Me.ColumnHeaderCell2.Name = "ColumnHeaderCell2"
        Me.ColumnHeaderCell2.Size = New System.Drawing.Size(47, 20)
        CellStyle2.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleCenter
        Me.ColumnHeaderCell2.Style = CellStyle2
        Me.ColumnHeaderCell2.TabIndex = 0
        Me.ColumnHeaderCell2.Value = "№"
        '
        'ColumnHeaderCell3
        '
        Me.ColumnHeaderCell3.HoverDirection = GrapeCity.Win.MultiRow.HoverDirection.None
        Me.ColumnHeaderCell3.Location = New System.Drawing.Point(71, 0)
        Me.ColumnHeaderCell3.Name = "ColumnHeaderCell3"
        Me.ColumnHeaderCell3.Size = New System.Drawing.Size(118, 20)
        CellStyle3.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleCenter
        Me.ColumnHeaderCell3.Style = CellStyle3
        Me.ColumnHeaderCell3.TabIndex = 1
        Me.ColumnHeaderCell3.Value = "シリアル№"
        '
        'ColumnHeaderCell1
        '
        Me.ColumnHeaderCell1.HoverDirection = GrapeCity.Win.MultiRow.HoverDirection.None
        Me.ColumnHeaderCell1.Location = New System.Drawing.Point(-2, 0)
        Me.ColumnHeaderCell1.Name = "ColumnHeaderCell1"
        Me.ColumnHeaderCell1.Size = New System.Drawing.Size(26, 20)
        CellStyle4.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleCenter
        Me.ColumnHeaderCell1.Style = CellStyle4
        Me.ColumnHeaderCell1.TabIndex = 2
        '
        'ColumnHeaderCell4
        '
        Me.ColumnHeaderCell4.Location = New System.Drawing.Point(189, 0)
        Me.ColumnHeaderCell4.Name = "ColumnHeaderCell4"
        Me.ColumnHeaderCell4.Size = New System.Drawing.Size(27, 20)
        Me.ColumnHeaderCell4.TabIndex = 3
        Me.ColumnHeaderCell4.Visible = False
        '
        'ColumnHeaderCell5
        '
        Me.ColumnHeaderCell5.Location = New System.Drawing.Point(216, 0)
        Me.ColumnHeaderCell5.Name = "ColumnHeaderCell5"
        Me.ColumnHeaderCell5.Size = New System.Drawing.Size(27, 20)
        Me.ColumnHeaderCell5.TabIndex = 4
        Me.ColumnHeaderCell5.Visible = False
        '
        'ColumnHeaderCell6
        '
        Me.ColumnHeaderCell6.Location = New System.Drawing.Point(243, 0)
        Me.ColumnHeaderCell6.Name = "ColumnHeaderCell6"
        Me.ColumnHeaderCell6.Size = New System.Drawing.Size(27, 20)
        Me.ColumnHeaderCell6.TabIndex = 5
        Me.ColumnHeaderCell6.Visible = False
        '
        'ColumnHeaderCell7
        '
        Me.ColumnHeaderCell7.Location = New System.Drawing.Point(270, 0)
        Me.ColumnHeaderCell7.Name = "ColumnHeaderCell7"
        Me.ColumnHeaderCell7.Size = New System.Drawing.Size(27, 20)
        Me.ColumnHeaderCell7.TabIndex = 6
        Me.ColumnHeaderCell7.Visible = False
        '
        'CheckBoxCell1
        '
        Me.CheckBoxCell1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxCell1.Location = New System.Drawing.Point(0, 0)
        Me.CheckBoxCell1.Name = "CheckBoxCell1"
        Me.CheckBoxCell1.Size = New System.Drawing.Size(24, 21)
        CellStyle1.ImeMode = System.Windows.Forms.ImeMode.Off
        CellStyle1.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleCenter
        Me.CheckBoxCell1.Style = CellStyle1
        Me.CheckBoxCell1.TabIndex = 0
        '
        'GcTextBoxCell1
        '
        Me.GcTextBoxCell1.Location = New System.Drawing.Point(24, 0)
        Me.GcTextBoxCell1.Name = "GcTextBoxCell1"
        Me.GcTextBoxCell1.ShortcutKeys.AddRange(New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry() {New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")})
        Me.GcTextBoxCell1.Size = New System.Drawing.Size(47, 21)
        Me.GcTextBoxCell1.TabIndex = 1
        '
        'GcTextBoxCell2
        '
        Me.GcTextBoxCell2.Location = New System.Drawing.Point(71, 0)
        Me.GcTextBoxCell2.MaxLength = 13
        Me.GcTextBoxCell2.Name = "GcTextBoxCell2"
        Me.GcTextBoxCell2.ShortcutKeys.AddRange(New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry() {New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")})
        Me.GcTextBoxCell2.Size = New System.Drawing.Size(118, 21)
        Me.GcTextBoxCell2.TabIndex = 2
        '
        'GcTextBoxCell3
        '
        Me.GcTextBoxCell3.Location = New System.Drawing.Point(189, 0)
        Me.GcTextBoxCell3.MaxLength = 13
        Me.GcTextBoxCell3.Name = "GcTextBoxCell3"
        Me.GcTextBoxCell3.ShortcutKeys.AddRange(New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry() {New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")})
        Me.GcTextBoxCell3.Size = New System.Drawing.Size(27, 21)
        Me.GcTextBoxCell3.TabIndex = 3
        Me.GcTextBoxCell3.Visible = False
        '
        'GcTextBoxCell4
        '
        Me.GcTextBoxCell4.Location = New System.Drawing.Point(216, 0)
        Me.GcTextBoxCell4.MaxLength = 13
        Me.GcTextBoxCell4.Name = "GcTextBoxCell4"
        Me.GcTextBoxCell4.ShortcutKeys.AddRange(New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry() {New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")})
        Me.GcTextBoxCell4.Size = New System.Drawing.Size(27, 21)
        Me.GcTextBoxCell4.TabIndex = 4
        Me.GcTextBoxCell4.Visible = False
        '
        'GcTextBoxCell5
        '
        Me.GcTextBoxCell5.Location = New System.Drawing.Point(243, 0)
        Me.GcTextBoxCell5.MaxLength = 13
        Me.GcTextBoxCell5.Name = "GcTextBoxCell5"
        Me.GcTextBoxCell5.ShortcutKeys.AddRange(New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry() {New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")})
        Me.GcTextBoxCell5.Size = New System.Drawing.Size(27, 21)
        Me.GcTextBoxCell5.TabIndex = 5
        Me.GcTextBoxCell5.Visible = False
        '
        'GcTextBoxCell6
        '
        Me.GcTextBoxCell6.Location = New System.Drawing.Point(270, 0)
        Me.GcTextBoxCell6.MaxLength = 13
        Me.GcTextBoxCell6.Name = "GcTextBoxCell6"
        Me.GcTextBoxCell6.ShortcutKeys.AddRange(New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry() {New GrapeCity.Win.MultiRow.InputMan.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")})
        Me.GcTextBoxCell6.Size = New System.Drawing.Size(27, 21)
        Me.GcTextBoxCell6.TabIndex = 6
        Me.GcTextBoxCell6.Visible = False
        '
        'Template1
        '
        Me.ColumnHeaders.AddRange(New GrapeCity.Win.MultiRow.ColumnHeaderSection() {Me.ColumnHeaderSection1})
        Me.Height = 41
        Me.Width = 189

    End Sub
    Friend WithEvents ColumnHeaderSection1 As GrapeCity.Win.MultiRow.ColumnHeaderSection
    Friend WithEvents CheckBoxCell1 As GrapeCity.Win.MultiRow.CheckBoxCell
    Friend WithEvents GcTextBoxCell1 As GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell
    Friend WithEvents GcTextBoxCell2 As GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell
    Private WithEvents ColumnHeaderCell2 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Private WithEvents ColumnHeaderCell3 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Private WithEvents ColumnHeaderCell1 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Friend WithEvents GcTextBoxCell3 As GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell
    Friend WithEvents GcTextBoxCell4 As GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell
    Friend WithEvents GcTextBoxCell5 As GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell
    Friend WithEvents GcTextBoxCell6 As GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell
    Friend WithEvents ColumnHeaderCell4 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Friend WithEvents ColumnHeaderCell5 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Friend WithEvents ColumnHeaderCell6 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Friend WithEvents ColumnHeaderCell7 As GrapeCity.Win.MultiRow.ColumnHeaderCell
End Class
