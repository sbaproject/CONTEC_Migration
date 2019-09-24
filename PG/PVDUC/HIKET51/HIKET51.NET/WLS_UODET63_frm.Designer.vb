<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class WLS_UODET63
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
	Public WithEvents WLSLABEL As SSPanel5
	Public WithEvents LST As System.Windows.Forms.ListBox
	Public WithEvents KEYBAK As System.Windows.Forms.ListBox
	Public WithEvents WLSOK As System.Windows.Forms.Button
	Public WithEvents WLSCANCEL As System.Windows.Forms.Button
	Public WithEvents HD_JDNTRKBNM As System.Windows.Forms.TextBox
	Public WithEvents HD_TANNM As System.Windows.Forms.TextBox
	Public WithEvents HD_JDNTRKB As System.Windows.Forms.TextBox
	Public WithEvents HD_JDNDT As System.Windows.Forms.TextBox
	Public WithEvents HD_KENNMA As System.Windows.Forms.TextBox
	Public WithEvents HD_TOKCD As System.Windows.Forms.TextBox
	Public WithEvents HD_TANCD As System.Windows.Forms.TextBox
	Public WithEvents HD_JDNNO As System.Windows.Forms.TextBox
	Public WithEvents _FM_Panel3D1_0 As SSPanel5
	Public WithEvents _FM_Panel3D1_1 As SSPanel5
	Public WithEvents CS_TANCD As SSCommand5
	Public WithEvents CS_JDNDT As SSCommand5
	Public WithEvents CS_TOKCD As SSCommand5
	Public WithEvents CS_JDNTRKB As SSCommand5
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Panel3D1 As SSPanel5
	Public WithEvents _IM_PrevCm_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_NextCm_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_NextCm_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_PrevCm_1 As System.Windows.Forms.PictureBox
	Public WithEvents CM_PrevCm As System.Windows.Forms.PictureBox
	Public WithEvents CM_NextCm As System.Windows.Forms.PictureBox
	Public WithEvents FM_Panel3D1 As SSPanel5Array
	Public WithEvents IM_NextCm As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_PrevCm As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WLS_UODET63))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.WLSLABEL = New SSPanel5
		Me.LST = New System.Windows.Forms.ListBox
		Me.KEYBAK = New System.Windows.Forms.ListBox
		Me.WLSOK = New System.Windows.Forms.Button
		Me.WLSCANCEL = New System.Windows.Forms.Button
		Me.Panel3D1 = New SSPanel5
		Me.HD_JDNTRKBNM = New System.Windows.Forms.TextBox
		Me.HD_TANNM = New System.Windows.Forms.TextBox
		Me.HD_JDNTRKB = New System.Windows.Forms.TextBox
		Me.HD_JDNDT = New System.Windows.Forms.TextBox
		Me.HD_KENNMA = New System.Windows.Forms.TextBox
		Me.HD_TOKCD = New System.Windows.Forms.TextBox
		Me.HD_TANCD = New System.Windows.Forms.TextBox
		Me.HD_JDNNO = New System.Windows.Forms.TextBox
		Me._FM_Panel3D1_0 = New SSPanel5
		Me._FM_Panel3D1_1 = New SSPanel5
		Me.CS_TANCD = New SSCommand5
		Me.CS_JDNDT = New SSCommand5
		Me.CS_TOKCD = New SSCommand5
		Me.CS_JDNTRKB = New SSCommand5
		Me.Label2 = New System.Windows.Forms.Label
		Me._IM_PrevCm_0 = New System.Windows.Forms.PictureBox
		Me._IM_NextCm_0 = New System.Windows.Forms.PictureBox
		Me._IM_NextCm_1 = New System.Windows.Forms.PictureBox
		Me._IM_PrevCm_1 = New System.Windows.Forms.PictureBox
		Me.CM_PrevCm = New System.Windows.Forms.PictureBox
		Me.CM_NextCm = New System.Windows.Forms.PictureBox
		Me.FM_Panel3D1 = New SSPanel5Array(components)
		Me.IM_NextCm = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_PrevCm = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.Panel3D1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_NextCm, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_PrevCm, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "受注伝票検索"
		Me.ClientSize = New System.Drawing.Size(913, 385)
		Me.Location = New System.Drawing.Point(11, 157)
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
		Me.Name = "WLS_UODET63"
		Me.WLSLABEL.Size = New System.Drawing.Size(906, 22)
		Me.WLSLABEL.Location = New System.Drawing.Point(3, 79)
		Me.WLSLABEL.TabIndex = 16
		Me.WLSLABEL.ForeColor = 0
		Me.WLSLABEL.Alignment = 1
		Me.WLSLABEL.BevelOuter = 1
		Me.WLSLABEL.Caption = "受注番号  受注取区  受注日付   得意先                                   件名"
		Me.WLSLABEL.OutLine = -1
		Me.WLSLABEL.RoundedCorners = 0
		Me.WLSLABEL.Name = "WLSLABEL"
		Me.LST.Size = New System.Drawing.Size(905, 247)
		Me.LST.Location = New System.Drawing.Point(3, 99)
		Me.LST.Items.AddRange(New Object(){"XXXXXXX8-12 MMMMMMMMM1 9999/99/99 MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3 MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4 MMMMM6", "１", "２", "３", "４", "５", "６", "７", "８", "９", "１０", "１１", "１２", "１３", "１４", "１５", "１６", "１７", "１８", "１９", "２０"})
		Me.LST.TabIndex = 17
		Me.LST.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
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
		Me.KEYBAK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.KEYBAK.Size = New System.Drawing.Size(20, 341)
		Me.KEYBAK.Location = New System.Drawing.Point(980, 48)
		Me.KEYBAK.TabIndex = 19
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
		Me.WLSOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.WLSOK.BackColor = System.Drawing.SystemColors.Control
		Me.WLSOK.Text = "OK"
		Me.WLSOK.Size = New System.Drawing.Size(73, 22)
		Me.WLSOK.Location = New System.Drawing.Point(388, 354)
		Me.WLSOK.TabIndex = 18
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
		Me.WLSCANCEL.Location = New System.Drawing.Point(460, 354)
		Me.WLSCANCEL.TabIndex = 20
		Me.WLSCANCEL.CausesValidation = True
		Me.WLSCANCEL.Enabled = True
		Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
		Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSCANCEL.TabStop = True
		Me.WLSCANCEL.Name = "WLSCANCEL"
		Me.Panel3D1.Size = New System.Drawing.Size(914, 68)
		Me.Panel3D1.Location = New System.Drawing.Point(0, 0)
		Me.Panel3D1.TabIndex = 0
		Me.Panel3D1.ForeColor = 0
		Me.Panel3D1.OutLine = -1
		Me.Panel3D1.Name = "Panel3D1"
		Me.HD_JDNTRKBNM.AutoSize = False
		Me.HD_JDNTRKBNM.BackColor = System.Drawing.SystemColors.Control
		Me.HD_JDNTRKBNM.Size = New System.Drawing.Size(89, 25)
		Me.HD_JDNTRKBNM.Location = New System.Drawing.Point(650, 4)
		Me.HD_JDNTRKBNM.TabIndex = 8
		Me.HD_JDNTRKBNM.Text = "MMMMMMMMM1"
		Me.HD_JDNTRKBNM.AcceptsReturn = True
		Me.HD_JDNTRKBNM.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_JDNTRKBNM.CausesValidation = True
		Me.HD_JDNTRKBNM.Enabled = True
		Me.HD_JDNTRKBNM.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_JDNTRKBNM.HideSelection = True
		Me.HD_JDNTRKBNM.ReadOnly = False
		Me.HD_JDNTRKBNM.Maxlength = 0
		Me.HD_JDNTRKBNM.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_JDNTRKBNM.MultiLine = False
		Me.HD_JDNTRKBNM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_JDNTRKBNM.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_JDNTRKBNM.TabStop = True
		Me.HD_JDNTRKBNM.Visible = True
		Me.HD_JDNTRKBNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_JDNTRKBNM.Name = "HD_JDNTRKBNM"
		Me.HD_TANNM.AutoSize = False
		Me.HD_TANNM.BackColor = System.Drawing.SystemColors.Control
		Me.HD_TANNM.Size = New System.Drawing.Size(166, 25)
		Me.HD_TANNM.Location = New System.Drawing.Point(161, 4)
		Me.HD_TANNM.TabIndex = 3
		Me.HD_TANNM.Text = "MMMMMMMMM1MMMMMMMMM2"
		Me.HD_TANNM.AcceptsReturn = True
		Me.HD_TANNM.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_TANNM.CausesValidation = True
		Me.HD_TANNM.Enabled = True
		Me.HD_TANNM.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_TANNM.HideSelection = True
		Me.HD_TANNM.ReadOnly = False
		Me.HD_TANNM.Maxlength = 0
		Me.HD_TANNM.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_TANNM.MultiLine = False
		Me.HD_TANNM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_TANNM.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_TANNM.TabStop = True
		Me.HD_TANNM.Visible = True
		Me.HD_TANNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_TANNM.Name = "HD_TANNM"
		Me.HD_JDNTRKB.AutoSize = False
		Me.HD_JDNTRKB.Size = New System.Drawing.Size(24, 25)
		Me.HD_JDNTRKB.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.HD_JDNTRKB.Location = New System.Drawing.Point(627, 4)
		Me.HD_JDNTRKB.TabIndex = 7
		Me.HD_JDNTRKB.Text = "99"
		Me.HD_JDNTRKB.AcceptsReturn = True
		Me.HD_JDNTRKB.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_JDNTRKB.BackColor = System.Drawing.SystemColors.Window
		Me.HD_JDNTRKB.CausesValidation = True
		Me.HD_JDNTRKB.Enabled = True
		Me.HD_JDNTRKB.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_JDNTRKB.HideSelection = True
		Me.HD_JDNTRKB.ReadOnly = False
		Me.HD_JDNTRKB.Maxlength = 0
		Me.HD_JDNTRKB.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_JDNTRKB.MultiLine = False
		Me.HD_JDNTRKB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_JDNTRKB.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_JDNTRKB.TabStop = True
		Me.HD_JDNTRKB.Visible = True
		Me.HD_JDNTRKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_JDNTRKB.Name = "HD_JDNTRKB"
		Me.HD_JDNDT.AutoSize = False
		Me.HD_JDNDT.Size = New System.Drawing.Size(87, 25)
		Me.HD_JDNDT.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.HD_JDNDT.Location = New System.Drawing.Point(107, 36)
		Me.HD_JDNDT.TabIndex = 10
		Me.HD_JDNDT.Text = "9999/99/99"
		Me.HD_JDNDT.AcceptsReturn = True
		Me.HD_JDNDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_JDNDT.BackColor = System.Drawing.SystemColors.Window
		Me.HD_JDNDT.CausesValidation = True
		Me.HD_JDNDT.Enabled = True
		Me.HD_JDNDT.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_JDNDT.HideSelection = True
		Me.HD_JDNDT.ReadOnly = False
		Me.HD_JDNDT.Maxlength = 0
		Me.HD_JDNDT.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_JDNDT.MultiLine = False
		Me.HD_JDNDT.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_JDNDT.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_JDNDT.TabStop = True
		Me.HD_JDNDT.Visible = True
		Me.HD_JDNDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_JDNDT.Name = "HD_JDNDT"
		Me.HD_KENNMA.AutoSize = False
		Me.HD_KENNMA.Size = New System.Drawing.Size(279, 25)
		Me.HD_KENNMA.IMEMode = System.Windows.Forms.ImeMode.Hiragana
		Me.HD_KENNMA.Location = New System.Drawing.Point(627, 36)
		Me.HD_KENNMA.TabIndex = 15
		Me.HD_KENNMA.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM4"
		Me.HD_KENNMA.AcceptsReturn = True
		Me.HD_KENNMA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_KENNMA.BackColor = System.Drawing.SystemColors.Window
		Me.HD_KENNMA.CausesValidation = True
		Me.HD_KENNMA.Enabled = True
		Me.HD_KENNMA.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_KENNMA.HideSelection = True
		Me.HD_KENNMA.ReadOnly = False
		Me.HD_KENNMA.Maxlength = 0
		Me.HD_KENNMA.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_KENNMA.MultiLine = False
		Me.HD_KENNMA.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_KENNMA.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_KENNMA.TabStop = True
		Me.HD_KENNMA.Visible = True
		Me.HD_KENNMA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_KENNMA.Name = "HD_KENNMA"
		Me.HD_TOKCD.AutoSize = False
		Me.HD_TOKCD.Size = New System.Drawing.Size(47, 25)
		Me.HD_TOKCD.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_TOKCD.Location = New System.Drawing.Point(456, 36)
		Me.HD_TOKCD.TabIndex = 13
		Me.HD_TOKCD.Text = "XXXX5"
		Me.HD_TOKCD.AcceptsReturn = True
		Me.HD_TOKCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_TOKCD.BackColor = System.Drawing.SystemColors.Window
		Me.HD_TOKCD.CausesValidation = True
		Me.HD_TOKCD.Enabled = True
		Me.HD_TOKCD.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_TOKCD.HideSelection = True
		Me.HD_TOKCD.ReadOnly = False
		Me.HD_TOKCD.Maxlength = 0
		Me.HD_TOKCD.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_TOKCD.MultiLine = False
		Me.HD_TOKCD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_TOKCD.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_TOKCD.TabStop = True
		Me.HD_TOKCD.Visible = True
		Me.HD_TOKCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_TOKCD.Name = "HD_TOKCD"
		Me.HD_TANCD.AutoSize = False
		Me.HD_TANCD.Size = New System.Drawing.Size(55, 25)
		Me.HD_TANCD.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.HD_TANCD.Location = New System.Drawing.Point(107, 4)
		Me.HD_TANCD.TabIndex = 2
		Me.HD_TANCD.Text = "XXXXX6"
		Me.HD_TANCD.AcceptsReturn = True
		Me.HD_TANCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_TANCD.BackColor = System.Drawing.SystemColors.Window
		Me.HD_TANCD.CausesValidation = True
		Me.HD_TANCD.Enabled = True
		Me.HD_TANCD.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_TANCD.HideSelection = True
		Me.HD_TANCD.ReadOnly = False
		Me.HD_TANCD.Maxlength = 0
		Me.HD_TANCD.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_TANCD.MultiLine = False
		Me.HD_TANCD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_TANCD.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_TANCD.TabStop = True
		Me.HD_TANCD.Visible = True
		Me.HD_TANCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_TANCD.Name = "HD_TANCD"
		Me.HD_JDNNO.AutoSize = False
		Me.HD_JDNNO.Size = New System.Drawing.Size(70, 25)
		Me.HD_JDNNO.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.HD_JDNNO.Location = New System.Drawing.Point(456, 4)
		Me.HD_JDNNO.TabIndex = 5
		Me.HD_JDNNO.Text = "XXXXXXX8"
		Me.HD_JDNNO.AcceptsReturn = True
		Me.HD_JDNNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_JDNNO.BackColor = System.Drawing.SystemColors.Window
		Me.HD_JDNNO.CausesValidation = True
		Me.HD_JDNNO.Enabled = True
		Me.HD_JDNNO.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_JDNNO.HideSelection = True
		Me.HD_JDNNO.ReadOnly = False
		Me.HD_JDNNO.Maxlength = 0
		Me.HD_JDNNO.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_JDNNO.MultiLine = False
		Me.HD_JDNNO.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_JDNNO.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_JDNNO.TabStop = True
		Me.HD_JDNNO.Visible = True
		Me.HD_JDNNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_JDNNO.Name = "HD_JDNNO"
		Me._FM_Panel3D1_0.Size = New System.Drawing.Size(106, 25)
		Me._FM_Panel3D1_0.Location = New System.Drawing.Point(351, 4)
		Me._FM_Panel3D1_0.TabIndex = 4
		Me._FM_Panel3D1_0.ForeColor = 0
		Me._FM_Panel3D1_0.BevelOuter = 1
		Me._FM_Panel3D1_0.Caption = "開始受注番号"
		Me._FM_Panel3D1_0.OutLine = -1
		Me._FM_Panel3D1_0.RoundedCorners = 0
		Me._FM_Panel3D1_0.Name = "_FM_Panel3D1_0"
		Me._FM_Panel3D1_1.Size = New System.Drawing.Size(77, 25)
		Me._FM_Panel3D1_1.Location = New System.Drawing.Point(551, 36)
		Me._FM_Panel3D1_1.TabIndex = 14
		Me._FM_Panel3D1_1.ForeColor = 0
		Me._FM_Panel3D1_1.BevelOuter = 1
		Me._FM_Panel3D1_1.Caption = "件名　　"
		Me._FM_Panel3D1_1.OutLine = -1
		Me._FM_Panel3D1_1.RoundedCorners = 0
		Me._FM_Panel3D1_1.Name = "_FM_Panel3D1_1"
		Me.CS_TANCD.Size = New System.Drawing.Size(99, 25)
		Me.CS_TANCD.Location = New System.Drawing.Point(9, 4)
		Me.CS_TANCD.TabIndex = 1
		Me.CS_TANCD.TabStop = 0
		Me.CS_TANCD.ForeColor = 0
		Me.CS_TANCD.Caption = "営業担当者"
		Me.CS_TANCD.BevelWidth = 1
		Me.CS_TANCD.RoundedCorners = 0
		Me.CS_TANCD.Name = "CS_TANCD"
		Me.CS_JDNDT.Size = New System.Drawing.Size(99, 25)
		Me.CS_JDNDT.Location = New System.Drawing.Point(9, 36)
		Me.CS_JDNDT.TabIndex = 9
		Me.CS_JDNDT.TabStop = 0
		Me.CS_JDNDT.ForeColor = 0
		Me.CS_JDNDT.Caption = "受注日付   "
		Me.CS_JDNDT.BevelWidth = 1
		Me.CS_JDNDT.RoundedCorners = 0
		Me.CS_JDNDT.Name = "CS_JDNDT"
		Me.CS_TOKCD.Size = New System.Drawing.Size(106, 25)
		Me.CS_TOKCD.Location = New System.Drawing.Point(351, 36)
		Me.CS_TOKCD.TabIndex = 12
		Me.CS_TOKCD.TabStop = 0
		Me.CS_TOKCD.ForeColor = 0
		Me.CS_TOKCD.Caption = "得意先       "
		Me.CS_TOKCD.BevelWidth = 1
		Me.CS_TOKCD.RoundedCorners = 0
		Me.CS_TOKCD.Name = "CS_TOKCD"
		Me.CS_JDNTRKB.Size = New System.Drawing.Size(78, 25)
		Me.CS_JDNTRKB.Location = New System.Drawing.Point(550, 4)
		Me.CS_JDNTRKB.TabIndex = 6
		Me.CS_JDNTRKB.TabStop = 0
		Me.CS_JDNTRKB.ForeColor = 0
		Me.CS_JDNTRKB.Caption = "受注取区"
		Me.CS_JDNTRKB.BevelWidth = 1
		Me.CS_JDNTRKB.RoundedCorners = 0
		Me.CS_JDNTRKB.Name = "CS_JDNTRKB"
		Me.Label2.Text = "以降"
		Me.Label2.Size = New System.Drawing.Size(43, 20)
		Me.Label2.Location = New System.Drawing.Point(198, 40)
		Me.Label2.TabIndex = 11
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me._IM_PrevCm_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_PrevCm_0.Location = New System.Drawing.Point(394, 500)
		Me._IM_PrevCm_0.Image = CType(resources.GetObject("_IM_PrevCm_0.Image"), System.Drawing.Image)
		Me._IM_PrevCm_0.Visible = False
		Me._IM_PrevCm_0.Enabled = True
		Me._IM_PrevCm_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_PrevCm_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_PrevCm_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_PrevCm_0.Name = "_IM_PrevCm_0"
		Me._IM_NextCm_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_NextCm_0.Location = New System.Drawing.Point(454, 500)
		Me._IM_NextCm_0.Image = CType(resources.GetObject("_IM_NextCm_0.Image"), System.Drawing.Image)
		Me._IM_NextCm_0.Visible = False
		Me._IM_NextCm_0.Enabled = True
		Me._IM_NextCm_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_NextCm_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_NextCm_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_NextCm_0.Name = "_IM_NextCm_0"
		Me._IM_NextCm_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_NextCm_1.Location = New System.Drawing.Point(481, 500)
		Me._IM_NextCm_1.Image = CType(resources.GetObject("_IM_NextCm_1.Image"), System.Drawing.Image)
		Me._IM_NextCm_1.Visible = False
		Me._IM_NextCm_1.Enabled = True
		Me._IM_NextCm_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_NextCm_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_NextCm_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_NextCm_1.Name = "_IM_NextCm_1"
		Me._IM_PrevCm_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_PrevCm_1.Location = New System.Drawing.Point(421, 500)
		Me._IM_PrevCm_1.Image = CType(resources.GetObject("_IM_PrevCm_1.Image"), System.Drawing.Image)
		Me._IM_PrevCm_1.Visible = False
		Me._IM_PrevCm_1.Enabled = True
		Me._IM_PrevCm_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_PrevCm_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_PrevCm_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_PrevCm_1.Name = "_IM_PrevCm_1"
		Me.CM_PrevCm.Size = New System.Drawing.Size(24, 22)
		Me.CM_PrevCm.Location = New System.Drawing.Point(352, 354)
		Me.CM_PrevCm.Image = CType(resources.GetObject("CM_PrevCm.Image"), System.Drawing.Image)
		Me.CM_PrevCm.Enabled = True
		Me.CM_PrevCm.Cursor = System.Windows.Forms.Cursors.Default
		Me.CM_PrevCm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.CM_PrevCm.Visible = True
		Me.CM_PrevCm.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.CM_PrevCm.Name = "CM_PrevCm"
		Me.CM_NextCm.Size = New System.Drawing.Size(24, 22)
		Me.CM_NextCm.Location = New System.Drawing.Point(544, 354)
		Me.CM_NextCm.Image = CType(resources.GetObject("CM_NextCm.Image"), System.Drawing.Image)
		Me.CM_NextCm.Enabled = True
		Me.CM_NextCm.Cursor = System.Windows.Forms.Cursors.Default
		Me.CM_NextCm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.CM_NextCm.Visible = True
		Me.CM_NextCm.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.CM_NextCm.Name = "CM_NextCm"
		Me.Controls.Add(WLSLABEL)
		Me.Controls.Add(LST)
		Me.Controls.Add(KEYBAK)
		Me.Controls.Add(WLSOK)
		Me.Controls.Add(WLSCANCEL)
		Me.Controls.Add(Panel3D1)
		Me.Controls.Add(_IM_PrevCm_0)
		Me.Controls.Add(_IM_NextCm_0)
		Me.Controls.Add(_IM_NextCm_1)
		Me.Controls.Add(_IM_PrevCm_1)
		Me.Controls.Add(CM_PrevCm)
		Me.Controls.Add(CM_NextCm)
		Me.Panel3D1.Controls.Add(HD_JDNTRKBNM)
		Me.Panel3D1.Controls.Add(HD_TANNM)
		Me.Panel3D1.Controls.Add(HD_JDNTRKB)
		Me.Panel3D1.Controls.Add(HD_JDNDT)
		Me.Panel3D1.Controls.Add(HD_KENNMA)
		Me.Panel3D1.Controls.Add(HD_TOKCD)
		Me.Panel3D1.Controls.Add(HD_TANCD)
		Me.Panel3D1.Controls.Add(HD_JDNNO)
		Me.Panel3D1.Controls.Add(_FM_Panel3D1_0)
		Me.Panel3D1.Controls.Add(_FM_Panel3D1_1)
		Me.Panel3D1.Controls.Add(CS_TANCD)
		Me.Panel3D1.Controls.Add(CS_JDNDT)
		Me.Panel3D1.Controls.Add(CS_TOKCD)
		Me.Panel3D1.Controls.Add(CS_JDNTRKB)
		Me.Panel3D1.Controls.Add(Label2)
		Me.FM_Panel3D1.SetIndex(_FM_Panel3D1_0, CType(0, Short))
		Me.FM_Panel3D1.SetIndex(_FM_Panel3D1_1, CType(1, Short))
		Me.IM_NextCm.SetIndex(_IM_NextCm_0, CType(0, Short))
		Me.IM_NextCm.SetIndex(_IM_NextCm_1, CType(1, Short))
		Me.IM_PrevCm.SetIndex(_IM_PrevCm_0, CType(0, Short))
		Me.IM_PrevCm.SetIndex(_IM_PrevCm_1, CType(1, Short))
		CType(Me.IM_PrevCm, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_NextCm, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel3D1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class