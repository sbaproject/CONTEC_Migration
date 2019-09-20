<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class WLSTNK
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
    Public WithEvents WLSLABEL As System.Windows.Forms.Label
	Public WithEvents LST As System.Windows.Forms.ListBox
	Public WithEvents WLSOK As System.Windows.Forms.Button
	Public WithEvents WLSCANCEL As System.Windows.Forms.Button
	Public WithEvents HD_HINNMB As System.Windows.Forms.TextBox
	Public WithEvents HD_HINNMA As System.Windows.Forms.TextBox
	Public WithEvents HD_TOKRN As System.Windows.Forms.TextBox
    Public WithEvents Panel3D4 As System.Windows.Forms.Label
    Public WithEvents SSPanel51 As System.Windows.Forms.Label
    Public WithEvents SSPanel52 As System.Windows.Forms.Label
    Public WithEvents Panel3D1 As System.Windows.Forms.Label
	Public WithEvents _IM_MAE_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_ATO_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_ATO_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_MAE_1 As System.Windows.Forms.PictureBox
	Public WithEvents IM_ATO As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_MAE As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WLSTNK))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
        Me.WLSLABEL = New Label
		Me.LST = New System.Windows.Forms.ListBox
		Me.WLSOK = New System.Windows.Forms.Button
		Me.WLSCANCEL = New System.Windows.Forms.Button
        Me.Panel3D1 = New Label
		Me.HD_HINNMB = New System.Windows.Forms.TextBox
		Me.HD_HINNMA = New System.Windows.Forms.TextBox
		Me.HD_TOKRN = New System.Windows.Forms.TextBox
        Me.Panel3D4 = New Label
        Me.SSPanel51 = New Label
        Me.SSPanel52 = New Label
		Me._IM_MAE_0 = New System.Windows.Forms.PictureBox
		Me._IM_ATO_0 = New System.Windows.Forms.PictureBox
		Me._IM_ATO_1 = New System.Windows.Forms.PictureBox
		Me._IM_MAE_1 = New System.Windows.Forms.PictureBox
		Me.IM_ATO = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_MAE = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.Panel3D1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "単価履歴検索"
		Me.ClientSize = New System.Drawing.Size(418, 281)
		Me.Location = New System.Drawing.Point(111, 220)
		Me.ControlBox = False
		Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.ForeColor = System.Drawing.SystemColors.WindowText
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "WLSTNK"
		Me.WLSLABEL.Size = New System.Drawing.Size(413, 25)
		Me.WLSLABEL.Location = New System.Drawing.Point(3, 128)
		Me.WLSLABEL.TabIndex = 6
        'Me.WLSLABEL.ForeColor = 0
        'Me.WLSLABEL.Alignment = 1
        'Me.WLSLABEL.BevelOuter = 1
        Me.WLSLABEL.Text = "        単価設定日付            履歴単価"
        'Me.WLSLABEL.OutLine = -1
        'Me.WLSLABEL.RoundedCorners = 0
		Me.WLSLABEL.Name = "WLSLABEL"
		Me.LST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LST.Size = New System.Drawing.Size(413, 101)
		Me.LST.Location = New System.Drawing.Point(3, 152)
		Me.LST.Items.AddRange(New Object(){"        9999/99/99           999,999,999.9999"})
		Me.LST.TabIndex = 1
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
		Me.WLSOK.Size = New System.Drawing.Size(61, 22)
		Me.WLSOK.Location = New System.Drawing.Point(147, 255)
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
		Me.WLSCANCEL.Size = New System.Drawing.Size(61, 22)
		Me.WLSCANCEL.Location = New System.Drawing.Point(210, 255)
		Me.WLSCANCEL.TabIndex = 3
		Me.WLSCANCEL.CausesValidation = True
		Me.WLSCANCEL.Enabled = True
		Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
		Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSCANCEL.TabStop = True
		Me.WLSCANCEL.Name = "WLSCANCEL"
		Me.Panel3D1.Size = New System.Drawing.Size(725, 102)
		Me.Panel3D1.Location = New System.Drawing.Point(0, 0)
		Me.Panel3D1.TabIndex = 0
        'Me.Panel3D1.ForeColor = 0
        'Me.Panel3D1.OutLine = -1
		Me.Panel3D1.Name = "Panel3D1"
		Me.HD_HINNMB.AutoSize = False
		Me.HD_HINNMB.BackColor = System.Drawing.SystemColors.Control
		Me.HD_HINNMB.Size = New System.Drawing.Size(327, 25)
		Me.HD_HINNMB.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_HINNMB.Location = New System.Drawing.Point(86, 58)
		Me.HD_HINNMB.Maxlength = 50
		Me.HD_HINNMB.TabIndex = 9
		Me.HD_HINNMB.TabStop = False
		Me.HD_HINNMB.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
		Me.HD_HINNMB.AcceptsReturn = True
		Me.HD_HINNMB.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_HINNMB.CausesValidation = True
		Me.HD_HINNMB.Enabled = True
		Me.HD_HINNMB.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_HINNMB.HideSelection = True
		Me.HD_HINNMB.ReadOnly = False
		Me.HD_HINNMB.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_HINNMB.MultiLine = False
		Me.HD_HINNMB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_HINNMB.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_HINNMB.Visible = True
		Me.HD_HINNMB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_HINNMB.Name = "HD_HINNMB"
		Me.HD_HINNMA.AutoSize = False
		Me.HD_HINNMA.BackColor = System.Drawing.SystemColors.Control
		Me.HD_HINNMA.Size = New System.Drawing.Size(327, 25)
		Me.HD_HINNMA.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_HINNMA.Location = New System.Drawing.Point(86, 35)
		Me.HD_HINNMA.Maxlength = 40
		Me.HD_HINNMA.TabIndex = 7
		Me.HD_HINNMA.TabStop = False
		Me.HD_HINNMA.Text = "XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3"
		Me.HD_HINNMA.AcceptsReturn = True
		Me.HD_HINNMA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_HINNMA.CausesValidation = True
		Me.HD_HINNMA.Enabled = True
		Me.HD_HINNMA.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_HINNMA.HideSelection = True
		Me.HD_HINNMA.ReadOnly = False
		Me.HD_HINNMA.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_HINNMA.MultiLine = False
		Me.HD_HINNMA.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_HINNMA.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_HINNMA.Visible = True
		Me.HD_HINNMA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_HINNMA.Name = "HD_HINNMA"
		Me.HD_TOKRN.AutoSize = False
		Me.HD_TOKRN.BackColor = System.Drawing.SystemColors.Control
		Me.HD_TOKRN.Size = New System.Drawing.Size(327, 25)
		Me.HD_TOKRN.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_TOKRN.Location = New System.Drawing.Point(86, 6)
		Me.HD_TOKRN.Maxlength = 40
		Me.HD_TOKRN.TabIndex = 4
		Me.HD_TOKRN.TabStop = False
		Me.HD_TOKRN.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
		Me.HD_TOKRN.AcceptsReturn = True
		Me.HD_TOKRN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_TOKRN.CausesValidation = True
		Me.HD_TOKRN.Enabled = True
		Me.HD_TOKRN.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_TOKRN.HideSelection = True
		Me.HD_TOKRN.ReadOnly = False
		Me.HD_TOKRN.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_TOKRN.MultiLine = False
		Me.HD_TOKRN.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_TOKRN.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_TOKRN.Visible = True
		Me.HD_TOKRN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_TOKRN.Name = "HD_TOKRN"
		Me.Panel3D4.Size = New System.Drawing.Size(81, 25)
		Me.Panel3D4.Location = New System.Drawing.Point(6, 6)
		Me.Panel3D4.TabIndex = 5
        'Me.Panel3D4.ForeColor = 0
        'Me.Panel3D4.Alignment = 1
        'Me.Panel3D4.BevelOuter = 1
        Me.Panel3D4.Text = " 得意先名"
        'Me.Panel3D4.OutLine = -1
        'Me.Panel3D4.RoundedCorners = 0
		Me.Panel3D4.Name = "Panel3D4"
		Me.SSPanel51.Size = New System.Drawing.Size(81, 25)
		Me.SSPanel51.Location = New System.Drawing.Point(6, 35)
		Me.SSPanel51.TabIndex = 8
        'Me.SSPanel51.ForeColor = 0
        'Me.SSPanel51.Alignment = 1
        'Me.SSPanel51.BevelOuter = 1
        Me.SSPanel51.Text = " 型式"
        'Me.SSPanel51.OutLine = -1
        'Me.SSPanel51.RoundedCorners = 0
		Me.SSPanel51.Name = "SSPanel51"
		Me.SSPanel52.Size = New System.Drawing.Size(81, 25)
		Me.SSPanel52.Location = New System.Drawing.Point(6, 58)
		Me.SSPanel52.TabIndex = 10
        'Me.SSPanel52.ForeColor = 0
        'Me.SSPanel52.Alignment = 1
        'Me.SSPanel52.BevelOuter = 1
        Me.SSPanel52.Text = " 品名"
        'Me.SSPanel52.OutLine = -1
        'Me.SSPanel52.RoundedCorners = 0
		Me.SSPanel52.Name = "SSPanel52"
		Me._IM_MAE_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_MAE_0.Location = New System.Drawing.Point(255, 411)
		Me._IM_MAE_0.Image = CType(resources.GetObject("_IM_MAE_0.Image"), System.Drawing.Image)
		Me._IM_MAE_0.Visible = False
		Me._IM_MAE_0.Enabled = True
		Me._IM_MAE_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_MAE_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_MAE_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_MAE_0.Name = "_IM_MAE_0"
		Me._IM_ATO_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_ATO_0.Location = New System.Drawing.Point(315, 411)
		Me._IM_ATO_0.Image = CType(resources.GetObject("_IM_ATO_0.Image"), System.Drawing.Image)
		Me._IM_ATO_0.Visible = False
		Me._IM_ATO_0.Enabled = True
		Me._IM_ATO_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_ATO_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_ATO_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_ATO_0.Name = "_IM_ATO_0"
		Me._IM_ATO_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_ATO_1.Location = New System.Drawing.Point(342, 411)
		Me._IM_ATO_1.Image = CType(resources.GetObject("_IM_ATO_1.Image"), System.Drawing.Image)
		Me._IM_ATO_1.Visible = False
		Me._IM_ATO_1.Enabled = True
		Me._IM_ATO_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_ATO_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_ATO_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_ATO_1.Name = "_IM_ATO_1"
		Me._IM_MAE_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_MAE_1.Location = New System.Drawing.Point(282, 411)
		Me._IM_MAE_1.Image = CType(resources.GetObject("_IM_MAE_1.Image"), System.Drawing.Image)
		Me._IM_MAE_1.Visible = False
		Me._IM_MAE_1.Enabled = True
		Me._IM_MAE_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_MAE_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_MAE_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_MAE_1.Name = "_IM_MAE_1"
		Me.Controls.Add(WLSLABEL)
		Me.Controls.Add(LST)
		Me.Controls.Add(WLSOK)
		Me.Controls.Add(WLSCANCEL)
		Me.Controls.Add(Panel3D1)
		Me.Controls.Add(_IM_MAE_0)
		Me.Controls.Add(_IM_ATO_0)
		Me.Controls.Add(_IM_ATO_1)
		Me.Controls.Add(_IM_MAE_1)
		Me.Panel3D1.Controls.Add(HD_HINNMB)
		Me.Panel3D1.Controls.Add(HD_HINNMA)
		Me.Panel3D1.Controls.Add(HD_TOKRN)
		Me.Panel3D1.Controls.Add(Panel3D4)
		Me.Panel3D1.Controls.Add(SSPanel51)
		Me.Panel3D1.Controls.Add(SSPanel52)
		Me.IM_ATO.SetIndex(_IM_ATO_0, CType(0, Short))
		Me.IM_ATO.SetIndex(_IM_ATO_1, CType(1, Short))
		Me.IM_MAE.SetIndex(_IM_MAE_0, CType(0, Short))
		Me.IM_MAE.SetIndex(_IM_MAE_1, CType(1, Short))
		CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel3D1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class