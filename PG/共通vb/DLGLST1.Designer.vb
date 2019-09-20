<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class DLGLST1
#Region "Windows フォーム デザイナによって生成されたコード "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'この呼び出しは、Windows フォーム デザイナで必要です。
		InitializeComponent()
	End Sub
	'Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Windows フォーム デザイナで必要です。
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents _CMD_SELECT_3 As System.Windows.Forms.Button
	Public WithEvents _CMD_SELECT_2 As System.Windows.Forms.Button
	Public WithEvents _CMD_SELECT_1 As System.Windows.Forms.Button
	Public WithEvents _CMD_SELECT_0 As System.Windows.Forms.Button
	Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents CMD_SELECT As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更できます。
    'コード エディタを使用して、変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._CMD_SELECT_3 = New System.Windows.Forms.Button()
        Me._CMD_SELECT_2 = New System.Windows.Forms.Button()
        Me._CMD_SELECT_1 = New System.Windows.Forms.Button()
        Me._CMD_SELECT_0 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CMD_SELECT = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        CType(Me.CMD_SELECT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_CMD_SELECT_3
        '
        Me._CMD_SELECT_3.BackColor = System.Drawing.SystemColors.Control
        Me._CMD_SELECT_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._CMD_SELECT_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CMD_SELECT.SetIndex(Me._CMD_SELECT_3, CType(3, Short))
        Me._CMD_SELECT_3.Location = New System.Drawing.Point(185, 51)
        Me._CMD_SELECT_3.Name = "_CMD_SELECT_3"
        Me._CMD_SELECT_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._CMD_SELECT_3.Size = New System.Drawing.Size(78, 22)
        Me._CMD_SELECT_3.TabIndex = 4
        Me._CMD_SELECT_3.Text = "戻　る"
        Me._CMD_SELECT_3.UseVisualStyleBackColor = False
        '
        '_CMD_SELECT_2
        '
        Me._CMD_SELECT_2.BackColor = System.Drawing.SystemColors.Control
        Me._CMD_SELECT_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._CMD_SELECT_2.Enabled = False
        Me._CMD_SELECT_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CMD_SELECT.SetIndex(Me._CMD_SELECT_2, CType(2, Short))
        Me._CMD_SELECT_2.Location = New System.Drawing.Point(367, 52)
        Me._CMD_SELECT_2.Name = "_CMD_SELECT_2"
        Me._CMD_SELECT_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._CMD_SELECT_2.Size = New System.Drawing.Size(78, 22)
        Me._CMD_SELECT_2.TabIndex = 3
        Me._CMD_SELECT_2.Text = "ﾌｧｲﾙ出力"
        Me._CMD_SELECT_2.UseVisualStyleBackColor = False
        Me._CMD_SELECT_2.Visible = False
        '
        '_CMD_SELECT_1
        '
        Me._CMD_SELECT_1.BackColor = System.Drawing.SystemColors.Control
        Me._CMD_SELECT_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._CMD_SELECT_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CMD_SELECT.SetIndex(Me._CMD_SELECT_1, CType(1, Short))
        Me._CMD_SELECT_1.Location = New System.Drawing.Point(102, 51)
        Me._CMD_SELECT_1.Name = "_CMD_SELECT_1"
        Me._CMD_SELECT_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._CMD_SELECT_1.Size = New System.Drawing.Size(78, 22)
        Me._CMD_SELECT_1.TabIndex = 2
        Me._CMD_SELECT_1.Text = "画面表示"
        Me._CMD_SELECT_1.UseVisualStyleBackColor = False
        '
        '_CMD_SELECT_0
        '
        Me._CMD_SELECT_0.BackColor = System.Drawing.SystemColors.Control
        Me._CMD_SELECT_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._CMD_SELECT_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CMD_SELECT.SetIndex(Me._CMD_SELECT_0, CType(0, Short))
        Me._CMD_SELECT_0.Location = New System.Drawing.Point(18, 51)
        Me._CMD_SELECT_0.Name = "_CMD_SELECT_0"
        Me._CMD_SELECT_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._CMD_SELECT_0.Size = New System.Drawing.Size(78, 22)
        Me._CMD_SELECT_0.TabIndex = 1
        Me._CMD_SELECT_0.Text = "印　刷"
        Me._CMD_SELECT_0.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(18, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(243, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "処理を選択してください。"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CMD_SELECT
        '
        '
        'DLGLST1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(279, 83)
        Me.ControlBox = False
        Me.Controls.Add(Me._CMD_SELECT_3)
        Me.Controls.Add(Me._CMD_SELECT_2)
        Me.Controls.Add(Me._CMD_SELECT_1)
        Me.Controls.Add(Me._CMD_SELECT_0)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(287, 386)
        Me.Name = "DLGLST1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "確認ボックス"
        CType(Me.CMD_SELECT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class