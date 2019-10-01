<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class DLGMSG01_ACE
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
	Public WithEvents CMD_OK As System.Windows.Forms.Button
	Public WithEvents HD_DSPNO As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DLGMSG01_ACE))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.CMD_OK = New System.Windows.Forms.Button
		Me.HD_DSPNO = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "確認ボックス"
		Me.ClientSize = New System.Drawing.Size(290, 83)
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
		Me.Name = "DLGMSG01_ACE"
		Me.CMD_OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CMD_OK.BackColor = System.Drawing.SystemColors.Control
		Me.CMD_OK.Text = "ＯＫ"
		Me.CMD_OK.Size = New System.Drawing.Size(78, 22)
		Me.CMD_OK.Location = New System.Drawing.Point(105, 53)
		Me.CMD_OK.TabIndex = 1
		Me.CMD_OK.CausesValidation = True
		Me.CMD_OK.Enabled = True
		Me.CMD_OK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CMD_OK.Cursor = System.Windows.Forms.Cursors.Default
		Me.CMD_OK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CMD_OK.TabStop = True
		Me.CMD_OK.Name = "CMD_OK"
		Me.HD_DSPNO.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.HD_DSPNO.BackColor = System.Drawing.Color.White
		Me.HD_DSPNO.Text = "見積番号：XXXXXXXXXX"
		Me.HD_DSPNO.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_DSPNO.Size = New System.Drawing.Size(251, 22)
		Me.HD_DSPNO.Location = New System.Drawing.Point(18, 25)
		Me.HD_DSPNO.TabIndex = 2
		Me.HD_DSPNO.Enabled = True
		Me.HD_DSPNO.Cursor = System.Windows.Forms.Cursors.Default
		Me.HD_DSPNO.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_DSPNO.UseMnemonic = True
		Me.HD_DSPNO.Visible = True
		Me.HD_DSPNO.AutoSize = False
		Me.HD_DSPNO.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.HD_DSPNO.Name = "HD_DSPNO"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label1.BackColor = System.Drawing.Color.White
		Me.Label1.Text = "登録終了"
		Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Label1.Size = New System.Drawing.Size(251, 22)
		Me.Label1.Location = New System.Drawing.Point(18, 4)
		Me.Label1.TabIndex = 0
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Label3.Text = "Label3"
		Me.Label3.Size = New System.Drawing.Size(255, 45)
		Me.Label3.Location = New System.Drawing.Point(15, 3)
		Me.Label3.TabIndex = 3
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Label3.Name = "Label3"
		Me.Controls.Add(CMD_OK)
		Me.Controls.Add(HD_DSPNO)
		Me.Controls.Add(Label1)
		Me.Controls.Add(Label3)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class