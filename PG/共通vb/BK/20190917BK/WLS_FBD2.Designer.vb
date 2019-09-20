<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class WLSFBD2
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
	Public WithEvents KEYBAK As System.Windows.Forms.ListBox
    Public WithEvents WLSLABEL As System.Windows.Forms.Label
	Public WithEvents LST As System.Windows.Forms.ListBox
	Public WithEvents WLSOK As System.Windows.Forms.Button
	Public WithEvents WLSCANCEL As System.Windows.Forms.Button
	Public WithEvents WLSNM2 As System.Windows.Forms.TextBox
	Public WithEvents WLSNM1 As System.Windows.Forms.TextBox
	Public WithEvents WLSCD As System.Windows.Forms.TextBox
	Public WithEvents HD_TEXT As System.Windows.Forms.TextBox
    Public WithEvents Panel3D4 As System.Windows.Forms.Label
    Public WithEvents SSPanel51 As System.Windows.Forms.Label
    Public WithEvents SSPanel52 As System.Windows.Forms.Label
    Public WithEvents SSPanel53 As System.Windows.Forms.Label
    Public WithEvents Panel3D1 As System.Windows.Forms.Label
	Public WithEvents _IM_MAE_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_ATO_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_ATO_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_MAE_0 As System.Windows.Forms.PictureBox
	Public WithEvents WLSMAE As System.Windows.Forms.PictureBox
	Public WithEvents WLSATO As System.Windows.Forms.PictureBox
	Public WithEvents IM_ATO As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_MAE As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WLSFBD2))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.KEYBAK = New System.Windows.Forms.ListBox
        Me.WLSLABEL = New System.Windows.Forms.Label
		Me.LST = New System.Windows.Forms.ListBox
		Me.WLSOK = New System.Windows.Forms.Button
		Me.WLSCANCEL = New System.Windows.Forms.Button
        Me.Panel3D1 = New System.Windows.Forms.Label
		Me.WLSNM2 = New System.Windows.Forms.TextBox
		Me.WLSNM1 = New System.Windows.Forms.TextBox
		Me.WLSCD = New System.Windows.Forms.TextBox
		Me.HD_TEXT = New System.Windows.Forms.TextBox
        Me.Panel3D4 = New System.Windows.Forms.Label
        Me.SSPanel51 = New System.Windows.Forms.Label
        Me.SSPanel52 = New System.Windows.Forms.Label
        Me.SSPanel53 = New System.Windows.Forms.Label
		Me._IM_MAE_1 = New System.Windows.Forms.PictureBox
		Me._IM_ATO_1 = New System.Windows.Forms.PictureBox
		Me._IM_ATO_0 = New System.Windows.Forms.PictureBox
		Me._IM_MAE_0 = New System.Windows.Forms.PictureBox
		Me.WLSMAE = New System.Windows.Forms.PictureBox
		Me.WLSATO = New System.Windows.Forms.PictureBox
		Me.IM_ATO = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_MAE = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.Panel3D1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "FBデータ一覧ウィンドウ"
		Me.ClientSize = New System.Drawing.Size(737, 462)
		Me.Location = New System.Drawing.Point(81, 138)
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
		Me.Name = "WLSFBD2"
		Me.KEYBAK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.KEYBAK.Size = New System.Drawing.Size(181, 341)
		Me.KEYBAK.Location = New System.Drawing.Point(762, 51)
		Me.KEYBAK.TabIndex = 10
		Me.KEYBAK.Visible = False
		Me.KEYBAK.BackColor = System.Drawing.SystemColors.Window
		Me.KEYBAK.CausesValidation = True
		Me.KEYBAK.Enabled = True
		Me.KEYBAK.ForeColor = System.Drawing.SystemColors.WindowText
		Me.KEYBAK.IntegralHeight = True
		Me.KEYBAK.Cursor = System.Windows.Forms.Cursors.Default
		Me.KEYBAK.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.KEYBAK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.KEYBAK.Sorted = False
		Me.KEYBAK.TabStop = True
		Me.KEYBAK.MultiColumn = False
		Me.KEYBAK.Name = "KEYBAK"
		Me.WLSLABEL.Size = New System.Drawing.Size(732, 25)
		Me.WLSLABEL.Location = New System.Drawing.Point(2, 70)
		Me.WLSLABEL.TabIndex = 9
        'Me.WLSLABEL.BackColor = 12632256
        'Me.WLSLABEL.ForeColor = 0
        'Me.WLSLABEL.Alignment = 1
        'Me.WLSLABEL.BevelOuter = 1
        Me.WLSLABEL.Text = "ﾊﾞｰﾁｬﾙ口座 得意先名                                         銀行ｶﾅ名称      支店ｶﾅ名称     "
        'Me.WLSLABEL.OutLine = -1
        'Me.WLSLABEL.RoundedCorners = 0
		Me.WLSLABEL.Name = "WLSLABEL"
		Me.LST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LST.Size = New System.Drawing.Size(732, 309)
		Me.LST.Location = New System.Drawing.Point(2, 94)
		Me.LST.Items.AddRange(New Object(){"XXXXXXXXX1 XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3XXXXXXXXX4XXXXXX48 XXXXXXXXX1XXXX5 XXXXXXXXX1XXXX5 XXXXXX7"})
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
		Me.WLSOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.WLSOK.BackColor = System.Drawing.SystemColors.Control
		Me.WLSOK.Text = "OK"
		Me.WLSOK.Size = New System.Drawing.Size(73, 22)
		Me.WLSOK.Location = New System.Drawing.Point(295, 421)
		Me.WLSOK.TabIndex = 5
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
		Me.WLSCANCEL.Location = New System.Drawing.Point(370, 421)
		Me.WLSCANCEL.TabIndex = 7
		Me.WLSCANCEL.CausesValidation = True
		Me.WLSCANCEL.Enabled = True
		Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
		Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSCANCEL.TabStop = True
		Me.WLSCANCEL.Name = "WLSCANCEL"
		Me.Panel3D1.Size = New System.Drawing.Size(746, 67)
		Me.Panel3D1.Location = New System.Drawing.Point(-1, -1)
		Me.Panel3D1.TabIndex = 6
        'Me.Panel3D1.BackColor = 12632256
        'Me.Panel3D1.ForeColor = 0
        'Me.Panel3D1.OutLine = -1
		Me.Panel3D1.Name = "Panel3D1"
		Me.WLSNM2.AutoSize = False
		Me.WLSNM2.Size = New System.Drawing.Size(128, 25)
		Me.WLSNM2.Location = New System.Drawing.Point(549, 36)
		Me.WLSNM2.Maxlength = 15
		Me.WLSNM2.TabIndex = 4
		Me.WLSNM2.Text = "MMMMMMMMM1MMMMM"
		Me.WLSNM2.AcceptsReturn = True
		Me.WLSNM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.WLSNM2.BackColor = System.Drawing.SystemColors.Window
		Me.WLSNM2.CausesValidation = True
		Me.WLSNM2.Enabled = True
		Me.WLSNM2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.WLSNM2.HideSelection = True
		Me.WLSNM2.ReadOnly = False
		Me.WLSNM2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.WLSNM2.MultiLine = False
		Me.WLSNM2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSNM2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.WLSNM2.TabStop = True
		Me.WLSNM2.Visible = True
		Me.WLSNM2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.WLSNM2.Name = "WLSNM2"
		Me.WLSNM1.AutoSize = False
		Me.WLSNM1.Size = New System.Drawing.Size(128, 25)
		Me.WLSNM1.Location = New System.Drawing.Point(283, 36)
		Me.WLSNM1.Maxlength = 15
		Me.WLSNM1.TabIndex = 3
		Me.WLSNM1.Text = "MMMMMMMMM1MMMMM"
		Me.WLSNM1.AcceptsReturn = True
		Me.WLSNM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.WLSNM1.BackColor = System.Drawing.SystemColors.Window
		Me.WLSNM1.CausesValidation = True
		Me.WLSNM1.Enabled = True
		Me.WLSNM1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.WLSNM1.HideSelection = True
		Me.WLSNM1.ReadOnly = False
		Me.WLSNM1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.WLSNM1.MultiLine = False
		Me.WLSNM1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSNM1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.WLSNM1.TabStop = True
		Me.WLSNM1.Visible = True
		Me.WLSNM1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.WLSNM1.Name = "WLSNM1"
		Me.WLSCD.AutoSize = False
		Me.WLSCD.Size = New System.Drawing.Size(394, 25)
		Me.WLSCD.Location = New System.Drawing.Point(283, 6)
		Me.WLSCD.Maxlength = 40
		Me.WLSCD.TabIndex = 2
		Me.WLSCD.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
		Me.WLSCD.AcceptsReturn = True
		Me.WLSCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.WLSCD.BackColor = System.Drawing.SystemColors.Window
		Me.WLSCD.CausesValidation = True
		Me.WLSCD.Enabled = True
		Me.WLSCD.ForeColor = System.Drawing.SystemColors.WindowText
		Me.WLSCD.HideSelection = True
		Me.WLSCD.ReadOnly = False
		Me.WLSCD.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.WLSCD.MultiLine = False
		Me.WLSCD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSCD.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.WLSCD.TabStop = True
		Me.WLSCD.Visible = True
		Me.WLSCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.WLSCD.Name = "WLSCD"
		Me.HD_TEXT.AutoSize = False
		Me.HD_TEXT.Size = New System.Drawing.Size(61, 25)
		Me.HD_TEXT.Location = New System.Drawing.Point(96, 6)
		Me.HD_TEXT.Maxlength = 7
		Me.HD_TEXT.TabIndex = 1
		Me.HD_TEXT.Text = "XXXXXX7"
		Me.HD_TEXT.AcceptsReturn = True
		Me.HD_TEXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_TEXT.BackColor = System.Drawing.SystemColors.Window
		Me.HD_TEXT.CausesValidation = True
		Me.HD_TEXT.Enabled = True
		Me.HD_TEXT.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_TEXT.HideSelection = True
		Me.HD_TEXT.ReadOnly = False
		Me.HD_TEXT.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_TEXT.MultiLine = False
		Me.HD_TEXT.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_TEXT.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_TEXT.TabStop = True
		Me.HD_TEXT.Visible = True
		Me.HD_TEXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_TEXT.Name = "HD_TEXT"
		Me.Panel3D4.Size = New System.Drawing.Size(91, 25)
		Me.Panel3D4.Location = New System.Drawing.Point(6, 6)
		Me.Panel3D4.TabIndex = 8
        'Me.Panel3D4.BackColor = 12632256
        'Me.Panel3D4.ForeColor = 0
        'Me.Panel3D4.BevelOuter = 1
        Me.Panel3D4.Text = "ﾊﾞｰﾁｬﾙ口座"
        'Me.Panel3D4.OutLine = -1
        'Me.Panel3D4.RoundedCorners = 0
		Me.Panel3D4.Name = "Panel3D4"
		Me.SSPanel51.Size = New System.Drawing.Size(91, 25)
		Me.SSPanel51.Location = New System.Drawing.Point(193, 6)
		Me.SSPanel51.TabIndex = 11
        'Me.SSPanel51.BackColor = 12632256
        'Me.SSPanel51.ForeColor = 0
        'Me.SSPanel51.BevelOuter = 1
        Me.SSPanel51.Text = "得意先名"
        'Me.SSPanel51.OutLine = -1
        'Me.SSPanel51.RoundedCorners = 0
		Me.SSPanel51.Name = "SSPanel51"
		Me.SSPanel52.Size = New System.Drawing.Size(91, 25)
		Me.SSPanel52.Location = New System.Drawing.Point(193, 36)
		Me.SSPanel52.TabIndex = 12
        'Me.SSPanel52.BackColor = 12632256
        'Me.SSPanel52.ForeColor = 0
        'Me.SSPanel52.BevelOuter = 1
        Me.SSPanel52.Text = "銀行ｶﾅ名称"
        'Me.SSPanel52.OutLine = -1
        'Me.SSPanel52.RoundedCorners = 0
		Me.SSPanel52.Name = "SSPanel52"
		Me.SSPanel53.Size = New System.Drawing.Size(91, 25)
		Me.SSPanel53.Location = New System.Drawing.Point(459, 36)
		Me.SSPanel53.TabIndex = 13
        'Me.SSPanel53.BackColor = 12632256
        'Me.SSPanel53.ForeColor = 0
        'Me.SSPanel53.BevelOuter = 1
        Me.SSPanel53.Text = "支店ｶﾅ名称"
        'Me.SSPanel53.OutLine = -1
        'Me.SSPanel53.RoundedCorners = 0
		Me.SSPanel53.Name = "SSPanel53"
		Me._IM_MAE_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_MAE_1.Location = New System.Drawing.Point(339, 480)
		Me._IM_MAE_1.Image = CType(resources.GetObject("_IM_MAE_1.Image"), System.Drawing.Image)
		Me._IM_MAE_1.Visible = False
		Me._IM_MAE_1.Enabled = True
		Me._IM_MAE_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_MAE_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_MAE_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_MAE_1.Name = "_IM_MAE_1"
		Me._IM_ATO_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_ATO_1.Location = New System.Drawing.Point(399, 480)
		Me._IM_ATO_1.Image = CType(resources.GetObject("_IM_ATO_1.Image"), System.Drawing.Image)
		Me._IM_ATO_1.Visible = False
		Me._IM_ATO_1.Enabled = True
		Me._IM_ATO_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_ATO_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_ATO_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_ATO_1.Name = "_IM_ATO_1"
		Me._IM_ATO_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_ATO_0.Location = New System.Drawing.Point(372, 480)
		Me._IM_ATO_0.Image = CType(resources.GetObject("_IM_ATO_0.Image"), System.Drawing.Image)
		Me._IM_ATO_0.Visible = False
		Me._IM_ATO_0.Enabled = True
		Me._IM_ATO_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_ATO_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_ATO_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_ATO_0.Name = "_IM_ATO_0"
		Me._IM_MAE_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_MAE_0.Location = New System.Drawing.Point(312, 480)
		Me._IM_MAE_0.Image = CType(resources.GetObject("_IM_MAE_0.Image"), System.Drawing.Image)
		Me._IM_MAE_0.Visible = False
		Me._IM_MAE_0.Enabled = True
		Me._IM_MAE_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_MAE_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_MAE_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_MAE_0.Name = "_IM_MAE_0"
		Me.WLSMAE.Size = New System.Drawing.Size(24, 22)
		Me.WLSMAE.Location = New System.Drawing.Point(262, 421)
		Me.WLSMAE.Image = CType(resources.GetObject("WLSMAE.Image"), System.Drawing.Image)
		Me.WLSMAE.Enabled = True
		Me.WLSMAE.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSMAE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.WLSMAE.Visible = True
		Me.WLSMAE.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.WLSMAE.Name = "WLSMAE"
		Me.WLSATO.Size = New System.Drawing.Size(24, 22)
		Me.WLSATO.Location = New System.Drawing.Point(451, 421)
		Me.WLSATO.Image = CType(resources.GetObject("WLSATO.Image"), System.Drawing.Image)
		Me.WLSATO.Enabled = True
		Me.WLSATO.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSATO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.WLSATO.Visible = True
		Me.WLSATO.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.WLSATO.Name = "WLSATO"
		Me.Controls.Add(KEYBAK)
		Me.Controls.Add(WLSLABEL)
		Me.Controls.Add(LST)
		Me.Controls.Add(WLSOK)
		Me.Controls.Add(WLSCANCEL)
		Me.Controls.Add(Panel3D1)
		Me.Controls.Add(_IM_MAE_1)
		Me.Controls.Add(_IM_ATO_1)
		Me.Controls.Add(_IM_ATO_0)
		Me.Controls.Add(_IM_MAE_0)
		Me.Controls.Add(WLSMAE)
		Me.Controls.Add(WLSATO)
		Me.Panel3D1.Controls.Add(WLSNM2)
		Me.Panel3D1.Controls.Add(WLSNM1)
		Me.Panel3D1.Controls.Add(WLSCD)
		Me.Panel3D1.Controls.Add(HD_TEXT)
		Me.Panel3D1.Controls.Add(Panel3D4)
		Me.Panel3D1.Controls.Add(SSPanel51)
		Me.Panel3D1.Controls.Add(SSPanel52)
		Me.Panel3D1.Controls.Add(SSPanel53)
		Me.IM_ATO.SetIndex(_IM_ATO_1, CType(1, Short))
		Me.IM_ATO.SetIndex(_IM_ATO_0, CType(0, Short))
		Me.IM_MAE.SetIndex(_IM_MAE_1, CType(1, Short))
		Me.IM_MAE.SetIndex(_IM_MAE_0, CType(0, Short))
		CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel3D1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class