<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class DLGLST3
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
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DLGLST3))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me._CMD_SELECT_3 = New System.Windows.Forms.Button
		Me._CMD_SELECT_2 = New System.Windows.Forms.Button
		Me._CMD_SELECT_1 = New System.Windows.Forms.Button
		Me._CMD_SELECT_0 = New System.Windows.Forms.Button
		Me.Label1 = New System.Windows.Forms.Label
		Me.CMD_SELECT = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.CMD_SELECT, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "確認ボックス"
		Me.ClientSize = New System.Drawing.Size(360, 83)
		Me.Location = New System.Drawing.Point(349, 424)
		Me.ControlBox = False
		Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.ForeColor = System.Drawing.SystemColors.WindowText
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "DLGLST3"
		Me._CMD_SELECT_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._CMD_SELECT_3.BackColor = System.Drawing.SystemColors.Control
		Me._CMD_SELECT_3.Text = "戻　る"
		Me._CMD_SELECT_3.Size = New System.Drawing.Size(78, 22)
		Me._CMD_SELECT_3.Location = New System.Drawing.Point(273, 51)
		Me._CMD_SELECT_3.TabIndex = 4
		Me._CMD_SELECT_3.CausesValidation = True
		Me._CMD_SELECT_3.Enabled = True
		Me._CMD_SELECT_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._CMD_SELECT_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._CMD_SELECT_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._CMD_SELECT_3.TabStop = True
		Me._CMD_SELECT_3.Name = "_CMD_SELECT_3"
		Me._CMD_SELECT_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._CMD_SELECT_2.BackColor = System.Drawing.SystemColors.Control
		Me._CMD_SELECT_2.Text = "発行のみ"
		Me._CMD_SELECT_2.Size = New System.Drawing.Size(78, 22)
		Me._CMD_SELECT_2.Location = New System.Drawing.Point(189, 51)
		Me._CMD_SELECT_2.TabIndex = 3
		Me._CMD_SELECT_2.CausesValidation = True
		Me._CMD_SELECT_2.Enabled = True
		Me._CMD_SELECT_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._CMD_SELECT_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._CMD_SELECT_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._CMD_SELECT_2.TabStop = True
		Me._CMD_SELECT_2.Name = "_CMD_SELECT_2"
		Me._CMD_SELECT_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._CMD_SELECT_1.BackColor = System.Drawing.SystemColors.Control
		Me._CMD_SELECT_1.Text = "計上のみ"
		Me._CMD_SELECT_1.Size = New System.Drawing.Size(78, 22)
		Me._CMD_SELECT_1.Location = New System.Drawing.Point(105, 51)
		Me._CMD_SELECT_1.TabIndex = 2
		Me._CMD_SELECT_1.CausesValidation = True
		Me._CMD_SELECT_1.Enabled = True
		Me._CMD_SELECT_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._CMD_SELECT_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._CMD_SELECT_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._CMD_SELECT_1.TabStop = True
		Me._CMD_SELECT_1.Name = "_CMD_SELECT_1"
		Me._CMD_SELECT_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._CMD_SELECT_0.BackColor = System.Drawing.SystemColors.Control
		Me._CMD_SELECT_0.Text = "計上し発行"
		Me._CMD_SELECT_0.Size = New System.Drawing.Size(84, 22)
		Me._CMD_SELECT_0.Location = New System.Drawing.Point(15, 51)
		Me._CMD_SELECT_0.TabIndex = 1
		Me._CMD_SELECT_0.CausesValidation = True
		Me._CMD_SELECT_0.Enabled = True
		Me._CMD_SELECT_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._CMD_SELECT_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._CMD_SELECT_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._CMD_SELECT_0.TabStop = True
		Me._CMD_SELECT_0.Name = "_CMD_SELECT_0"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label1.BackColor = System.Drawing.Color.White
		Me.Label1.Text = "処理を選択してください。"
		Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Label1.Size = New System.Drawing.Size(328, 22)
		Me.Label1.Location = New System.Drawing.Point(18, 12)
		Me.Label1.TabIndex = 0
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(_CMD_SELECT_3)
		Me.Controls.Add(_CMD_SELECT_2)
		Me.Controls.Add(_CMD_SELECT_1)
		Me.Controls.Add(_CMD_SELECT_0)
		Me.Controls.Add(Label1)
		Me.CMD_SELECT.SetIndex(_CMD_SELECT_3, CType(3, Short))
		Me.CMD_SELECT.SetIndex(_CMD_SELECT_2, CType(2, Short))
		Me.CMD_SELECT.SetIndex(_CMD_SELECT_1, CType(1, Short))
		Me.CMD_SELECT.SetIndex(_CMD_SELECT_0, CType(0, Short))
		CType(Me.CMD_SELECT, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class