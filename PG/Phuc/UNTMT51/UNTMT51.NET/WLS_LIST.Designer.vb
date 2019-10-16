<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class WLS_LIST
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
	Public WithEvents PNL As SSPanel5
	Public WithEvents WLSOK As System.Windows.Forms.Button
	Public WithEvents WLSCANCEL As System.Windows.Forms.Button
	Public WithEvents LST As System.Windows.Forms.ListBox
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WLS_LIST))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.PNL = New SSPanel5
		Me.WLSOK = New System.Windows.Forms.Button
		Me.WLSCANCEL = New System.Windows.Forms.Button
		Me.LST = New System.Windows.Forms.ListBox
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "分類"
		Me.ClientSize = New System.Drawing.Size(278, 283)
		Me.Location = New System.Drawing.Point(350, 239)
		Me.ControlBox = False
		Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.ForeColor = System.Drawing.SystemColors.WindowText
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "WLS_LIST"
		Me.PNL.Size = New System.Drawing.Size(277, 25)
		Me.PNL.Location = New System.Drawing.Point(0, 285)
		Me.PNL.TabIndex = 3
		Me.PNL.BackColor = 12632256
		Me.PNL.ForeColor = 0
		Me.PNL.Alignment = 1
		Me.PNL.BevelOuter = 1
		Me.PNL.OutLine = -1
		Me.PNL.RoundedCorners = 0
		Me.PNL.Name = "PNL"
		Me.WLSOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.WLSOK.BackColor = System.Drawing.SystemColors.Control
		Me.WLSOK.Text = "OK"
		Me.WLSOK.Size = New System.Drawing.Size(73, 22)
		Me.WLSOK.Location = New System.Drawing.Point(66, 252)
		Me.WLSOK.TabIndex = 2
		Me.WLSOK.CausesValidation = True
		Me.WLSOK.Enabled = True
		Me.WLSOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.WLSOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSOK.TabStop = True
		Me.WLSOK.Name = "WLSOK"
		Me.WLSCANCEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.WLSCANCEL.BackColor = System.Drawing.SystemColors.Control
		Me.WLSCANCEL.Text = "ｷｬﾝｾﾙ"
		Me.WLSCANCEL.Size = New System.Drawing.Size(73, 22)
		Me.WLSCANCEL.Location = New System.Drawing.Point(144, 252)
		Me.WLSCANCEL.TabIndex = 1
		Me.WLSCANCEL.CausesValidation = True
		Me.WLSCANCEL.Enabled = True
		Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
		Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSCANCEL.TabStop = True
		Me.WLSCANCEL.Name = "WLSCANCEL"
		Me.LST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LST.Size = New System.Drawing.Size(277, 245)
		Me.LST.Location = New System.Drawing.Point(0, 0)
		Me.LST.TabIndex = 0
		Me.LST.BackColor = System.Drawing.SystemColors.Window
		Me.LST.CausesValidation = True
		Me.LST.Enabled = True
		Me.LST.ForeColor = System.Drawing.SystemColors.WindowText
		Me.LST.IntegralHeight = True
		Me.LST.Cursor = System.Windows.Forms.Cursors.Default
		Me.LST.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.LST.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.LST.Sorted = False
		Me.LST.TabStop = True
		Me.LST.Visible = True
		Me.LST.MultiColumn = False
		Me.LST.Name = "LST"
		Me.Controls.Add(PNL)
		Me.Controls.Add(WLSOK)
		Me.Controls.Add(WLSCANCEL)
		Me.Controls.Add(LST)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class