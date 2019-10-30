<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class WLSFDN
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
	Public WithEvents LST1 As System.Windows.Forms.ListBox
	Public WithEvents KEYBAK As System.Windows.Forms.ListBox
	Public WithEvents WLSLABEL As SSPanel5
	Public WithEvents LST As System.Windows.Forms.ListBox
	Public WithEvents WLSOK As System.Windows.Forms.Button
	Public WithEvents WLSCANCEL As System.Windows.Forms.Button
	Public WithEvents HD_WRKNM As System.Windows.Forms.TextBox
	Public WithEvents HD_FDNDT As System.Windows.Forms.TextBox
	Public WithEvents Panel3D4 As SSPanel5
	Public WithEvents SSPanel51 As SSPanel5
	Public WithEvents Frame1 As System.Windows.Forms.Panel
	Public WithEvents HD_WRKKB As System.Windows.Forms.TextBox
	Public WithEvents COM_SOUCD As System.Windows.Forms.Button
	Public WithEvents WLSSOUCD As System.Windows.Forms.TextBox
	Public WithEvents WLSHINNMA As System.Windows.Forms.TextBox
	Public WithEvents WLSHINCD As System.Windows.Forms.TextBox
	Public WithEvents WLSTOKCD As System.Windows.Forms.TextBox
	Public WithEvents COM_TOKCD As System.Windows.Forms.Button
	Public WithEvents COM_HINCD As System.Windows.Forms.Button
	Public WithEvents SSPanel52 As SSPanel5
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Panel3D1 As SSPanel5
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
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WLSFDN))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.LST1 = New System.Windows.Forms.ListBox
		Me.KEYBAK = New System.Windows.Forms.ListBox
		Me.WLSLABEL = New SSPanel5
		Me.LST = New System.Windows.Forms.ListBox
		Me.WLSOK = New System.Windows.Forms.Button
		Me.WLSCANCEL = New System.Windows.Forms.Button
		Me.Panel3D1 = New SSPanel5
		Me.Frame1 = New System.Windows.Forms.Panel
		Me.HD_WRKNM = New System.Windows.Forms.TextBox
		Me.HD_FDNDT = New System.Windows.Forms.TextBox
		Me.Panel3D4 = New SSPanel5
		Me.SSPanel51 = New SSPanel5
		Me.HD_WRKKB = New System.Windows.Forms.TextBox
		Me.COM_SOUCD = New System.Windows.Forms.Button
		Me.WLSSOUCD = New System.Windows.Forms.TextBox
		Me.WLSHINNMA = New System.Windows.Forms.TextBox
		Me.WLSHINCD = New System.Windows.Forms.TextBox
		Me.WLSTOKCD = New System.Windows.Forms.TextBox
		Me.COM_TOKCD = New System.Windows.Forms.Button
		Me.COM_HINCD = New System.Windows.Forms.Button
		Me.SSPanel52 = New SSPanel5
		Me.Label1 = New System.Windows.Forms.Label
		Me._IM_MAE_1 = New System.Windows.Forms.PictureBox
		Me._IM_ATO_1 = New System.Windows.Forms.PictureBox
		Me._IM_ATO_0 = New System.Windows.Forms.PictureBox
		Me._IM_MAE_0 = New System.Windows.Forms.PictureBox
		Me.WLSMAE = New System.Windows.Forms.PictureBox
		Me.WLSATO = New System.Windows.Forms.PictureBox
		Me.IM_ATO = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_MAE = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.Panel3D1.SuspendLayout()
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "出荷指示対象検索"
		Me.ClientSize = New System.Drawing.Size(955, 427)
		Me.Location = New System.Drawing.Point(154, 113)
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
		Me.Name = "WLSFDN"
		Me.LST1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LST1.Size = New System.Drawing.Size(94, 245)
		Me.LST1.Location = New System.Drawing.Point(959, 120)
		Me.LST1.TabIndex = 21
		Me.LST1.BackColor = System.Drawing.SystemColors.Window
		Me.LST1.CausesValidation = True
		Me.LST1.Enabled = True
		Me.LST1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.LST1.IntegralHeight = True
		Me.LST1.Cursor = System.Windows.Forms.Cursors.Default
		Me.LST1.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.LST1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.LST1.Sorted = False
		Me.LST1.TabStop = True
		Me.LST1.Visible = True
		Me.LST1.MultiColumn = False
		Me.LST1.Name = "LST1"
		Me.KEYBAK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.KEYBAK.Size = New System.Drawing.Size(181, 341)
		Me.KEYBAK.Location = New System.Drawing.Point(960, 96)
		Me.KEYBAK.TabIndex = 9
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
		Me.WLSLABEL.Size = New System.Drawing.Size(941, 25)
		Me.WLSLABEL.Location = New System.Drawing.Point(6, 96)
		Me.WLSLABEL.TabIndex = 8
		Me.WLSLABEL.BackColor = 12632256
		Me.WLSLABEL.ForeColor = 0
		Me.WLSLABEL.Alignment = 1
		Me.WLSLABEL.BevelOuter = 1
		Me.WLSLABEL.Caption = "WLSLABEL"
		Me.WLSLABEL.OutLine = -1
		Me.WLSLABEL.RoundedCorners = 0
		Me.WLSLABEL.Name = "WLSLABEL"
		Me.LST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LST.Size = New System.Drawing.Size(941, 245)
		Me.LST.Location = New System.Drawing.Point(6, 120)
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
		Me.WLSOK.Location = New System.Drawing.Point(408, 386)
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
		Me.WLSCANCEL.Location = New System.Drawing.Point(483, 386)
		Me.WLSCANCEL.TabIndex = 6
		Me.WLSCANCEL.CausesValidation = True
		Me.WLSCANCEL.Enabled = True
		Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
		Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSCANCEL.TabStop = True
		Me.WLSCANCEL.Name = "WLSCANCEL"
		Me.Panel3D1.Size = New System.Drawing.Size(959, 82)
		Me.Panel3D1.Location = New System.Drawing.Point(0, -1)
		Me.Panel3D1.TabIndex = 7
		Me.Panel3D1.BackColor = 12632256
		Me.Panel3D1.ForeColor = 0
		Me.Panel3D1.OutLine = -1
		Me.Panel3D1.Name = "Panel3D1"
		Me.Frame1.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.Frame1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Frame1.Text = "Frame1"
		Me.Frame1.Enabled = False
		Me.Frame1.Size = New System.Drawing.Size(394, 35)
		Me.Frame1.Location = New System.Drawing.Point(8, 5)
		Me.Frame1.TabIndex = 16
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Name = "Frame1"
		Me.HD_WRKNM.AutoSize = False
		Me.HD_WRKNM.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.HD_WRKNM.Size = New System.Drawing.Size(93, 25)
		Me.HD_WRKNM.Location = New System.Drawing.Point(82, 0)
		Me.HD_WRKNM.ReadOnly = True
		Me.HD_WRKNM.TabIndex = 18
		Me.HD_WRKNM.Text = "XXXXXXXXX1"
		Me.HD_WRKNM.AcceptsReturn = True
		Me.HD_WRKNM.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_WRKNM.CausesValidation = True
		Me.HD_WRKNM.Enabled = True
		Me.HD_WRKNM.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_WRKNM.HideSelection = True
		Me.HD_WRKNM.Maxlength = 0
		Me.HD_WRKNM.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_WRKNM.MultiLine = False
		Me.HD_WRKNM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_WRKNM.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_WRKNM.TabStop = True
		Me.HD_WRKNM.Visible = True
		Me.HD_WRKNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_WRKNM.Name = "HD_WRKNM"
		Me.HD_FDNDT.AutoSize = False
		Me.HD_FDNDT.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.HD_FDNDT.Size = New System.Drawing.Size(93, 25)
		Me.HD_FDNDT.Location = New System.Drawing.Point(290, 1)
		Me.HD_FDNDT.ReadOnly = True
		Me.HD_FDNDT.TabIndex = 17
		Me.HD_FDNDT.Text = "9999/99/99"
		Me.HD_FDNDT.AcceptsReturn = True
		Me.HD_FDNDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_FDNDT.CausesValidation = True
		Me.HD_FDNDT.Enabled = True
		Me.HD_FDNDT.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_FDNDT.HideSelection = True
		Me.HD_FDNDT.Maxlength = 0
		Me.HD_FDNDT.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_FDNDT.MultiLine = False
		Me.HD_FDNDT.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_FDNDT.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_FDNDT.TabStop = True
		Me.HD_FDNDT.Visible = True
		Me.HD_FDNDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_FDNDT.Name = "HD_FDNDT"
		Me.Panel3D4.Size = New System.Drawing.Size(85, 25)
		Me.Panel3D4.Location = New System.Drawing.Point(0, 0)
		Me.Panel3D4.TabIndex = 19
		Me.Panel3D4.BackColor = 12632256
		Me.Panel3D4.ForeColor = 0
		Me.Panel3D4.BevelOuter = 1
		Me.Panel3D4.Caption = "処理区分"
		Me.Panel3D4.OutLine = -1
		Me.Panel3D4.RoundedCorners = 0
		Me.Panel3D4.Name = "Panel3D4"
		Me.SSPanel51.Size = New System.Drawing.Size(85, 25)
		Me.SSPanel51.Location = New System.Drawing.Point(208, 1)
		Me.SSPanel51.TabIndex = 20
		Me.SSPanel51.BackColor = 12632256
		Me.SSPanel51.ForeColor = 0
		Me.SSPanel51.BevelOuter = 1
		Me.SSPanel51.Caption = "対象日"
		Me.SSPanel51.OutLine = -1
		Me.SSPanel51.RoundedCorners = 0
		Me.SSPanel51.Name = "SSPanel51"
		Me.HD_WRKKB.AutoSize = False
		Me.HD_WRKKB.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.HD_WRKKB.Enabled = False
		Me.HD_WRKKB.Size = New System.Drawing.Size(93, 25)
		Me.HD_WRKKB.Location = New System.Drawing.Point(720, 16)
		Me.HD_WRKKB.TabIndex = 15
		Me.HD_WRKKB.Text = "X"
		Me.HD_WRKKB.Visible = False
		Me.HD_WRKKB.AcceptsReturn = True
		Me.HD_WRKKB.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_WRKKB.CausesValidation = True
		Me.HD_WRKKB.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_WRKKB.HideSelection = True
		Me.HD_WRKKB.ReadOnly = False
		Me.HD_WRKKB.Maxlength = 0
		Me.HD_WRKKB.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_WRKKB.MultiLine = False
		Me.HD_WRKKB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_WRKKB.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_WRKKB.TabStop = True
		Me.HD_WRKKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_WRKKB.Name = "HD_WRKKB"
		Me.COM_SOUCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.COM_SOUCD.BackColor = System.Drawing.SystemColors.Control
		Me.COM_SOUCD.Text = "倉庫"
		Me.COM_SOUCD.Size = New System.Drawing.Size(70, 25)
		Me.COM_SOUCD.Location = New System.Drawing.Point(565, 8)
		Me.COM_SOUCD.TabIndex = 14
		Me.COM_SOUCD.TabStop = False
		Me.COM_SOUCD.CausesValidation = True
		Me.COM_SOUCD.Enabled = True
		Me.COM_SOUCD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.COM_SOUCD.Cursor = System.Windows.Forms.Cursors.Default
		Me.COM_SOUCD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.COM_SOUCD.Name = "COM_SOUCD"
		Me.WLSSOUCD.AutoSize = False
		Me.WLSSOUCD.Size = New System.Drawing.Size(61, 25)
		Me.WLSSOUCD.Location = New System.Drawing.Point(634, 8)
		Me.WLSSOUCD.TabIndex = 1
		Me.WLSSOUCD.Text = "XXXX5"
		Me.WLSSOUCD.AcceptsReturn = True
		Me.WLSSOUCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.WLSSOUCD.BackColor = System.Drawing.SystemColors.Window
		Me.WLSSOUCD.CausesValidation = True
		Me.WLSSOUCD.Enabled = True
		Me.WLSSOUCD.ForeColor = System.Drawing.SystemColors.WindowText
		Me.WLSSOUCD.HideSelection = True
		Me.WLSSOUCD.ReadOnly = False
		Me.WLSSOUCD.Maxlength = 0
		Me.WLSSOUCD.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.WLSSOUCD.MultiLine = False
		Me.WLSSOUCD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSSOUCD.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.WLSSOUCD.TabStop = True
		Me.WLSSOUCD.Visible = True
		Me.WLSSOUCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.WLSSOUCD.Name = "WLSSOUCD"
		Me.WLSHINNMA.AutoSize = False
		Me.WLSHINNMA.Size = New System.Drawing.Size(249, 25)
		Me.WLSHINNMA.Location = New System.Drawing.Point(296, 40)
		Me.WLSHINNMA.TabIndex = 3
		Me.WLSHINNMA.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3"
		Me.WLSHINNMA.AcceptsReturn = True
		Me.WLSHINNMA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.WLSHINNMA.BackColor = System.Drawing.SystemColors.Window
		Me.WLSHINNMA.CausesValidation = True
		Me.WLSHINNMA.Enabled = True
		Me.WLSHINNMA.ForeColor = System.Drawing.SystemColors.WindowText
		Me.WLSHINNMA.HideSelection = True
		Me.WLSHINNMA.ReadOnly = False
		Me.WLSHINNMA.Maxlength = 0
		Me.WLSHINNMA.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.WLSHINNMA.MultiLine = False
		Me.WLSHINNMA.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSHINNMA.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.WLSHINNMA.TabStop = True
		Me.WLSHINNMA.Visible = True
		Me.WLSHINNMA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.WLSHINNMA.Name = "WLSHINNMA"
		Me.WLSHINCD.AutoSize = False
		Me.WLSHINCD.Size = New System.Drawing.Size(93, 25)
		Me.WLSHINCD.Location = New System.Drawing.Point(90, 40)
		Me.WLSHINCD.Maxlength = 10
		Me.WLSHINCD.TabIndex = 2
		Me.WLSHINCD.Text = "XXXXXXXX10"
		Me.WLSHINCD.AcceptsReturn = True
		Me.WLSHINCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.WLSHINCD.BackColor = System.Drawing.SystemColors.Window
		Me.WLSHINCD.CausesValidation = True
		Me.WLSHINCD.Enabled = True
		Me.WLSHINCD.ForeColor = System.Drawing.SystemColors.WindowText
		Me.WLSHINCD.HideSelection = True
		Me.WLSHINCD.ReadOnly = False
		Me.WLSHINCD.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.WLSHINCD.MultiLine = False
		Me.WLSHINCD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSHINCD.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.WLSHINCD.TabStop = True
		Me.WLSHINCD.Visible = True
		Me.WLSHINCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.WLSHINCD.Name = "WLSHINCD"
		Me.WLSTOKCD.AutoSize = False
		Me.WLSTOKCD.Size = New System.Drawing.Size(61, 25)
		Me.WLSTOKCD.Location = New System.Drawing.Point(634, 40)
		Me.WLSTOKCD.TabIndex = 4
		Me.WLSTOKCD.Text = "XXXX5"
		Me.WLSTOKCD.AcceptsReturn = True
		Me.WLSTOKCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.WLSTOKCD.BackColor = System.Drawing.SystemColors.Window
		Me.WLSTOKCD.CausesValidation = True
		Me.WLSTOKCD.Enabled = True
		Me.WLSTOKCD.ForeColor = System.Drawing.SystemColors.WindowText
		Me.WLSTOKCD.HideSelection = True
		Me.WLSTOKCD.ReadOnly = False
		Me.WLSTOKCD.Maxlength = 0
		Me.WLSTOKCD.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.WLSTOKCD.MultiLine = False
		Me.WLSTOKCD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSTOKCD.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.WLSTOKCD.TabStop = True
		Me.WLSTOKCD.Visible = True
		Me.WLSTOKCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.WLSTOKCD.Name = "WLSTOKCD"
		Me.COM_TOKCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.COM_TOKCD.BackColor = System.Drawing.SystemColors.Control
		Me.COM_TOKCD.Text = "得意先"
		Me.COM_TOKCD.Size = New System.Drawing.Size(70, 25)
		Me.COM_TOKCD.Location = New System.Drawing.Point(565, 40)
		Me.COM_TOKCD.TabIndex = 10
		Me.COM_TOKCD.TabStop = False
		Me.COM_TOKCD.CausesValidation = True
		Me.COM_TOKCD.Enabled = True
		Me.COM_TOKCD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.COM_TOKCD.Cursor = System.Windows.Forms.Cursors.Default
		Me.COM_TOKCD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.COM_TOKCD.Name = "COM_TOKCD"
		Me.COM_HINCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.COM_HINCD.BackColor = System.Drawing.SystemColors.Control
		Me.COM_HINCD.Text = "製品ｺｰﾄﾞ"
		Me.COM_HINCD.Size = New System.Drawing.Size(85, 25)
		Me.COM_HINCD.Location = New System.Drawing.Point(8, 40)
		Me.COM_HINCD.TabIndex = 11
		Me.COM_HINCD.TabStop = False
		Me.COM_HINCD.CausesValidation = True
		Me.COM_HINCD.Enabled = True
		Me.COM_HINCD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.COM_HINCD.Cursor = System.Windows.Forms.Cursors.Default
		Me.COM_HINCD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.COM_HINCD.Name = "COM_HINCD"
		Me.SSPanel52.Size = New System.Drawing.Size(85, 25)
		Me.SSPanel52.Location = New System.Drawing.Point(216, 40)
		Me.SSPanel52.TabIndex = 13
		Me.SSPanel52.BackColor = 12632256
		Me.SSPanel52.ForeColor = 0
		Me.SSPanel52.BevelOuter = 1
		Me.SSPanel52.Caption = "型式"
		Me.SSPanel52.OutLine = -1
		Me.SSPanel52.RoundedCorners = 0
		Me.SSPanel52.Name = "SSPanel52"
		Me.Label1.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.Label1.Text = "迄"
		Me.Label1.Size = New System.Drawing.Size(17, 17)
		Me.Label1.Location = New System.Drawing.Point(405, 11)
		Me.Label1.TabIndex = 12
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me._IM_MAE_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_MAE_1.Location = New System.Drawing.Point(456, 546)
		Me._IM_MAE_1.Image = CType(resources.GetObject("_IM_MAE_1.Image"), System.Drawing.Image)
		Me._IM_MAE_1.Visible = False
		Me._IM_MAE_1.Enabled = True
		Me._IM_MAE_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_MAE_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_MAE_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_MAE_1.Name = "_IM_MAE_1"
		Me._IM_ATO_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_ATO_1.Location = New System.Drawing.Point(516, 546)
		Me._IM_ATO_1.Image = CType(resources.GetObject("_IM_ATO_1.Image"), System.Drawing.Image)
		Me._IM_ATO_1.Visible = False
		Me._IM_ATO_1.Enabled = True
		Me._IM_ATO_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_ATO_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_ATO_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_ATO_1.Name = "_IM_ATO_1"
		Me._IM_ATO_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_ATO_0.Location = New System.Drawing.Point(489, 546)
		Me._IM_ATO_0.Image = CType(resources.GetObject("_IM_ATO_0.Image"), System.Drawing.Image)
		Me._IM_ATO_0.Visible = False
		Me._IM_ATO_0.Enabled = True
		Me._IM_ATO_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_ATO_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_ATO_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_ATO_0.Name = "_IM_ATO_0"
		Me._IM_MAE_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_MAE_0.Location = New System.Drawing.Point(429, 546)
		Me._IM_MAE_0.Image = CType(resources.GetObject("_IM_MAE_0.Image"), System.Drawing.Image)
		Me._IM_MAE_0.Visible = False
		Me._IM_MAE_0.Enabled = True
		Me._IM_MAE_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_MAE_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_MAE_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_MAE_0.Name = "_IM_MAE_0"
		Me.WLSMAE.Size = New System.Drawing.Size(24, 22)
		Me.WLSMAE.Location = New System.Drawing.Point(375, 386)
		Me.WLSMAE.Image = CType(resources.GetObject("WLSMAE.Image"), System.Drawing.Image)
		Me.WLSMAE.Enabled = True
		Me.WLSMAE.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSMAE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.WLSMAE.Visible = True
		Me.WLSMAE.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.WLSMAE.Name = "WLSMAE"
		Me.WLSATO.Size = New System.Drawing.Size(24, 22)
		Me.WLSATO.Location = New System.Drawing.Point(564, 386)
		Me.WLSATO.Image = CType(resources.GetObject("WLSATO.Image"), System.Drawing.Image)
		Me.WLSATO.Enabled = True
		Me.WLSATO.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSATO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.WLSATO.Visible = True
		Me.WLSATO.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.WLSATO.Name = "WLSATO"
		Me.Controls.Add(LST1)
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
		Me.Panel3D1.Controls.Add(Frame1)
		Me.Panel3D1.Controls.Add(HD_WRKKB)
		Me.Panel3D1.Controls.Add(COM_SOUCD)
		Me.Panel3D1.Controls.Add(WLSSOUCD)
		Me.Panel3D1.Controls.Add(WLSHINNMA)
		Me.Panel3D1.Controls.Add(WLSHINCD)
		Me.Panel3D1.Controls.Add(WLSTOKCD)
		Me.Panel3D1.Controls.Add(COM_TOKCD)
		Me.Panel3D1.Controls.Add(COM_HINCD)
		Me.Panel3D1.Controls.Add(SSPanel52)
		Me.Panel3D1.Controls.Add(Label1)
		Me.Frame1.Controls.Add(HD_WRKNM)
		Me.Frame1.Controls.Add(HD_FDNDT)
		Me.Frame1.Controls.Add(Panel3D4)
		Me.Frame1.Controls.Add(SSPanel51)
		Me.IM_ATO.SetIndex(_IM_ATO_1, CType(1, Short))
		Me.IM_ATO.SetIndex(_IM_ATO_0, CType(0, Short))
		Me.IM_MAE.SetIndex(_IM_MAE_1, CType(1, Short))
		Me.IM_MAE.SetIndex(_IM_MAE_0, CType(0, Short))
		CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel3D1.ResumeLayout(False)
		Me.Frame1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class