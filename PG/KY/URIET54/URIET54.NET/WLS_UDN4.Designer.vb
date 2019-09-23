<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class WLSUDN
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
	Public WithEvents WLSURIKB As System.Windows.Forms.TextBox
	Public WithEvents WLSUDNDT As System.Windows.Forms.TextBox
	Public WithEvents COM_UDNDT As System.Windows.Forms.Button
	Public WithEvents HD_TEXT As System.Windows.Forms.TextBox
	Public WithEvents WLSJDNTRKB As System.Windows.Forms.TextBox
	Public WithEvents COM_JDNTRKB As System.Windows.Forms.Button
	Public WithEvents HD_TOKJDNNO As System.Windows.Forms.TextBox
	Public WithEvents WLSNHSCD As System.Windows.Forms.TextBox
	Public WithEvents WLSTOKCD As System.Windows.Forms.TextBox
	Public WithEvents COM_TOKCD As System.Windows.Forms.Button
	Public WithEvents COM_NHSCD As System.Windows.Forms.Button
	Public WithEvents _SSPanel52_0 As SSPanel5
	Public WithEvents Panel3D4 As SSPanel5
	Public WithEvents _SSPanel52_1 As SSPanel5
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents WLSJDNTRNM As System.Windows.Forms.Label
	Public WithEvents Panel3D1 As SSPanel5
	Public WithEvents _IM_MAE_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_ATO_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_ATO_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_MAE_0 As System.Windows.Forms.PictureBox
	Public WithEvents WLSMAE As System.Windows.Forms.PictureBox
	Public WithEvents WLSATO As System.Windows.Forms.PictureBox
	Public WithEvents IM_ATO As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_MAE As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents SSPanel52 As SSPanel5Array
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WLSUDN))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.LST1 = New System.Windows.Forms.ListBox
		Me.KEYBAK = New System.Windows.Forms.ListBox
		Me.WLSLABEL = New SSPanel5
		Me.LST = New System.Windows.Forms.ListBox
		Me.WLSOK = New System.Windows.Forms.Button
		Me.WLSCANCEL = New System.Windows.Forms.Button
		Me.Panel3D1 = New SSPanel5
		Me.WLSURIKB = New System.Windows.Forms.TextBox
		Me.WLSUDNDT = New System.Windows.Forms.TextBox
		Me.COM_UDNDT = New System.Windows.Forms.Button
		Me.HD_TEXT = New System.Windows.Forms.TextBox
		Me.WLSJDNTRKB = New System.Windows.Forms.TextBox
		Me.COM_JDNTRKB = New System.Windows.Forms.Button
		Me.HD_TOKJDNNO = New System.Windows.Forms.TextBox
		Me.WLSNHSCD = New System.Windows.Forms.TextBox
		Me.WLSTOKCD = New System.Windows.Forms.TextBox
		Me.COM_TOKCD = New System.Windows.Forms.Button
		Me.COM_NHSCD = New System.Windows.Forms.Button
		Me._SSPanel52_0 = New SSPanel5
		Me.Panel3D4 = New SSPanel5
		Me._SSPanel52_1 = New SSPanel5
		Me.Label1 = New System.Windows.Forms.Label
		Me.WLSJDNTRNM = New System.Windows.Forms.Label
		Me._IM_MAE_1 = New System.Windows.Forms.PictureBox
		Me._IM_ATO_1 = New System.Windows.Forms.PictureBox
		Me._IM_ATO_0 = New System.Windows.Forms.PictureBox
		Me._IM_MAE_0 = New System.Windows.Forms.PictureBox
		Me.WLSMAE = New System.Windows.Forms.PictureBox
		Me.WLSATO = New System.Windows.Forms.PictureBox
		Me.IM_ATO = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_MAE = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.SSPanel52 = New SSPanel5Array(components)
		Me.Panel3D1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.SSPanel52, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "売上明細検索"
		Me.ClientSize = New System.Drawing.Size(1002, 424)
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
		Me.Name = "WLSUDN"
		Me.LST1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LST1.Size = New System.Drawing.Size(125, 245)
		Me.LST1.Location = New System.Drawing.Point(1005, 120)
		Me.LST1.Items.AddRange(New Object(){"LST1"})
		Me.LST1.TabIndex = 19
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
		Me.KEYBAK.Location = New System.Drawing.Point(1005, 96)
		Me.KEYBAK.TabIndex = 12
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
		Me.WLSLABEL.Size = New System.Drawing.Size(992, 25)
		Me.WLSLABEL.Location = New System.Drawing.Point(0, 88)
		Me.WLSLABEL.TabIndex = 11
		Me.WLSLABEL.BackColor = 12632256
		Me.WLSLABEL.ForeColor = 0
		Me.WLSLABEL.Alignment = 1
		Me.WLSLABEL.BevelOuter = 1
		Me.WLSLABEL.Caption = "WLSLABEL"
		Me.WLSLABEL.OutLine = -1
		Me.WLSLABEL.RoundedCorners = 0
		Me.WLSLABEL.Name = "WLSLABEL"
		Me.LST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LST.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.LST.Size = New System.Drawing.Size(992, 239)
		Me.LST.Location = New System.Drawing.Point(0, 112)
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
		Me.WLSOK.TabIndex = 8
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
		Me.WLSCANCEL.TabIndex = 10
		Me.WLSCANCEL.CausesValidation = True
		Me.WLSCANCEL.Enabled = True
		Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
		Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSCANCEL.TabStop = True
		Me.WLSCANCEL.Name = "WLSCANCEL"
		Me.Panel3D1.Size = New System.Drawing.Size(1002, 82)
		Me.Panel3D1.Location = New System.Drawing.Point(0, 0)
		Me.Panel3D1.TabIndex = 9
		Me.Panel3D1.BackColor = 12632256
		Me.Panel3D1.ForeColor = 0
		Me.Panel3D1.OutLine = -1
		Me.Panel3D1.Name = "Panel3D1"
		Me.WLSURIKB.AutoSize = False
		Me.WLSURIKB.Size = New System.Drawing.Size(19, 25)
		Me.WLSURIKB.Location = New System.Drawing.Point(668, 40)
		Me.WLSURIKB.Maxlength = 1
		Me.WLSURIKB.TabIndex = 7
		Me.WLSURIKB.AcceptsReturn = True
		Me.WLSURIKB.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.WLSURIKB.BackColor = System.Drawing.SystemColors.Window
		Me.WLSURIKB.CausesValidation = True
		Me.WLSURIKB.Enabled = True
		Me.WLSURIKB.ForeColor = System.Drawing.SystemColors.WindowText
		Me.WLSURIKB.HideSelection = True
		Me.WLSURIKB.ReadOnly = False
		Me.WLSURIKB.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.WLSURIKB.MultiLine = False
		Me.WLSURIKB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSURIKB.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.WLSURIKB.TabStop = True
		Me.WLSURIKB.Visible = True
		Me.WLSURIKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.WLSURIKB.Name = "WLSURIKB"
		Me.WLSUDNDT.AutoSize = False
		Me.WLSUDNDT.Size = New System.Drawing.Size(84, 25)
		Me.WLSUDNDT.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.WLSUDNDT.Location = New System.Drawing.Point(764, 8)
		Me.WLSUDNDT.Maxlength = 10
		Me.WLSUDNDT.TabIndex = 3
		Me.WLSUDNDT.AcceptsReturn = True
		Me.WLSUDNDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.WLSUDNDT.BackColor = System.Drawing.SystemColors.Window
		Me.WLSUDNDT.CausesValidation = True
		Me.WLSUDNDT.Enabled = True
		Me.WLSUDNDT.ForeColor = System.Drawing.SystemColors.WindowText
		Me.WLSUDNDT.HideSelection = True
		Me.WLSUDNDT.ReadOnly = False
		Me.WLSUDNDT.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.WLSUDNDT.MultiLine = False
		Me.WLSUDNDT.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSUDNDT.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.WLSUDNDT.TabStop = True
		Me.WLSUDNDT.Visible = True
		Me.WLSUDNDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.WLSUDNDT.Name = "WLSUDNDT"
		Me.COM_UDNDT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.COM_UDNDT.BackColor = System.Drawing.SystemColors.Control
		Me.COM_UDNDT.Text = "売上日付"
		Me.COM_UDNDT.Size = New System.Drawing.Size(97, 25)
		Me.COM_UDNDT.Location = New System.Drawing.Point(668, 8)
		Me.COM_UDNDT.TabIndex = 20
		Me.COM_UDNDT.TabStop = False
		Me.COM_UDNDT.CausesValidation = True
		Me.COM_UDNDT.Enabled = True
		Me.COM_UDNDT.ForeColor = System.Drawing.SystemColors.ControlText
		Me.COM_UDNDT.Cursor = System.Windows.Forms.Cursors.Default
		Me.COM_UDNDT.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.COM_UDNDT.Name = "COM_UDNDT"
		Me.HD_TEXT.AutoSize = False
		Me.HD_TEXT.Size = New System.Drawing.Size(77, 25)
		Me.HD_TEXT.Location = New System.Drawing.Point(571, 40)
		Me.HD_TEXT.Maxlength = 6
		Me.HD_TEXT.TabIndex = 6
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
		Me.WLSJDNTRKB.AutoSize = False
		Me.WLSJDNTRKB.Size = New System.Drawing.Size(29, 25)
		Me.WLSJDNTRKB.Location = New System.Drawing.Point(92, 8)
		Me.WLSJDNTRKB.Maxlength = 2
		Me.WLSJDNTRKB.TabIndex = 1
		Me.WLSJDNTRKB.AcceptsReturn = True
		Me.WLSJDNTRKB.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.WLSJDNTRKB.BackColor = System.Drawing.SystemColors.Window
		Me.WLSJDNTRKB.CausesValidation = True
		Me.WLSJDNTRKB.Enabled = True
		Me.WLSJDNTRKB.ForeColor = System.Drawing.SystemColors.WindowText
		Me.WLSJDNTRKB.HideSelection = True
		Me.WLSJDNTRKB.ReadOnly = False
		Me.WLSJDNTRKB.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.WLSJDNTRKB.MultiLine = False
		Me.WLSJDNTRKB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSJDNTRKB.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.WLSJDNTRKB.TabStop = True
		Me.WLSJDNTRKB.Visible = True
		Me.WLSJDNTRKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.WLSJDNTRKB.Name = "WLSJDNTRKB"
		Me.COM_JDNTRKB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.COM_JDNTRKB.BackColor = System.Drawing.SystemColors.Control
		Me.COM_JDNTRKB.Text = "受注取区"
		Me.COM_JDNTRKB.Size = New System.Drawing.Size(86, 25)
		Me.COM_JDNTRKB.Location = New System.Drawing.Point(8, 8)
		Me.COM_JDNTRKB.TabIndex = 16
		Me.COM_JDNTRKB.TabStop = False
		Me.COM_JDNTRKB.CausesValidation = True
		Me.COM_JDNTRKB.Enabled = True
		Me.COM_JDNTRKB.ForeColor = System.Drawing.SystemColors.ControlText
		Me.COM_JDNTRKB.Cursor = System.Windows.Forms.Cursors.Default
		Me.COM_JDNTRKB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.COM_JDNTRKB.Name = "COM_JDNTRKB"
		Me.HD_TOKJDNNO.AutoSize = False
		Me.HD_TOKJDNNO.Size = New System.Drawing.Size(281, 25)
		Me.HD_TOKJDNNO.Location = New System.Drawing.Point(368, 8)
		Me.HD_TOKJDNNO.TabIndex = 2
		Me.HD_TOKJDNNO.Text = "XXXXXXXXX1XXXXXXXXX2XXX"
		Me.HD_TOKJDNNO.AcceptsReturn = True
		Me.HD_TOKJDNNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_TOKJDNNO.BackColor = System.Drawing.SystemColors.Window
		Me.HD_TOKJDNNO.CausesValidation = True
		Me.HD_TOKJDNNO.Enabled = True
		Me.HD_TOKJDNNO.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_TOKJDNNO.HideSelection = True
		Me.HD_TOKJDNNO.ReadOnly = False
		Me.HD_TOKJDNNO.Maxlength = 0
		Me.HD_TOKJDNNO.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_TOKJDNNO.MultiLine = False
		Me.HD_TOKJDNNO.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_TOKJDNNO.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_TOKJDNNO.TabStop = True
		Me.HD_TOKJDNNO.Visible = True
		Me.HD_TOKJDNNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_TOKJDNNO.Name = "HD_TOKJDNNO"
		Me.WLSNHSCD.AutoSize = False
		Me.WLSNHSCD.Size = New System.Drawing.Size(93, 25)
		Me.WLSNHSCD.Location = New System.Drawing.Point(328, 40)
		Me.WLSNHSCD.Maxlength = 9
		Me.WLSNHSCD.TabIndex = 5
		Me.WLSNHSCD.Text = "XXXXXXXX9"
		Me.WLSNHSCD.AcceptsReturn = True
		Me.WLSNHSCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.WLSNHSCD.BackColor = System.Drawing.SystemColors.Window
		Me.WLSNHSCD.CausesValidation = True
		Me.WLSNHSCD.Enabled = True
		Me.WLSNHSCD.ForeColor = System.Drawing.SystemColors.WindowText
		Me.WLSNHSCD.HideSelection = True
		Me.WLSNHSCD.ReadOnly = False
		Me.WLSNHSCD.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.WLSNHSCD.MultiLine = False
		Me.WLSNHSCD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSNHSCD.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.WLSNHSCD.TabStop = True
		Me.WLSNHSCD.Visible = True
		Me.WLSNHSCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.WLSNHSCD.Name = "WLSNHSCD"
		Me.WLSTOKCD.AutoSize = False
		Me.WLSTOKCD.Size = New System.Drawing.Size(61, 25)
		Me.WLSTOKCD.Location = New System.Drawing.Point(92, 40)
		Me.WLSTOKCD.Maxlength = 5
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
		Me.COM_TOKCD.Text = "得意先 "
		Me.COM_TOKCD.Size = New System.Drawing.Size(86, 25)
		Me.COM_TOKCD.Location = New System.Drawing.Point(8, 40)
		Me.COM_TOKCD.TabIndex = 13
		Me.COM_TOKCD.TabStop = False
		Me.COM_TOKCD.CausesValidation = True
		Me.COM_TOKCD.Enabled = True
		Me.COM_TOKCD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.COM_TOKCD.Cursor = System.Windows.Forms.Cursors.Default
		Me.COM_TOKCD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.COM_TOKCD.Name = "COM_TOKCD"
		Me.COM_NHSCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.COM_NHSCD.BackColor = System.Drawing.SystemColors.Control
		Me.COM_NHSCD.Text = "納入先 "
		Me.COM_NHSCD.Size = New System.Drawing.Size(77, 25)
		Me.COM_NHSCD.Location = New System.Drawing.Point(256, 40)
		Me.COM_NHSCD.TabIndex = 14
		Me.COM_NHSCD.TabStop = False
		Me.COM_NHSCD.CausesValidation = True
		Me.COM_NHSCD.Enabled = True
		Me.COM_NHSCD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.COM_NHSCD.Cursor = System.Windows.Forms.Cursors.Default
		Me.COM_NHSCD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.COM_NHSCD.Name = "COM_NHSCD"
		Me._SSPanel52_0.Size = New System.Drawing.Size(117, 25)
		Me._SSPanel52_0.Location = New System.Drawing.Point(256, 8)
		Me._SSPanel52_0.TabIndex = 15
		Me._SSPanel52_0.BackColor = 12632256
		Me._SSPanel52_0.ForeColor = 0
		Me._SSPanel52_0.BevelOuter = 1
		Me._SSPanel52_0.Caption = "客先注文番号"
		Me._SSPanel52_0.OutLine = -1
		Me._SSPanel52_0.RoundedCorners = 0
		Me._SSPanel52_0.Name = "_SSPanel52_0"
		Me.Panel3D4.Size = New System.Drawing.Size(109, 25)
		Me.Panel3D4.Location = New System.Drawing.Point(464, 40)
		Me.Panel3D4.TabIndex = 18
		Me.Panel3D4.BackColor = 12632256
		Me.Panel3D4.ForeColor = 0
		Me.Panel3D4.BevelOuter = 1
		Me.Panel3D4.Caption = "受注番号"
		Me.Panel3D4.OutLine = -1
		Me.Panel3D4.RoundedCorners = 0
		Me.Panel3D4.Name = "Panel3D4"
		Me._SSPanel52_1.Size = New System.Drawing.Size(203, 25)
		Me._SSPanel52_1.Location = New System.Drawing.Point(686, 40)
		Me._SSPanel52_1.TabIndex = 22
		Me._SSPanel52_1.BackColor = 12632256
		Me._SSPanel52_1.ForeColor = 0
		Me._SSPanel52_1.Alignment = 1
		Me._SSPanel52_1.BevelOuter = 1
		Me._SSPanel52_1.Caption = "1:売上済 2:未売上"
		Me._SSPanel52_1.OutLine = -1
		Me._SSPanel52_1.RoundedCorners = 0
		Me._SSPanel52_1.Name = "_SSPanel52_1"
		Me.Label1.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.Label1.Text = "以降"
		Me.Label1.Size = New System.Drawing.Size(41, 25)
		Me.Label1.Location = New System.Drawing.Point(855, 16)
		Me.Label1.TabIndex = 21
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
		Me.WLSJDNTRNM.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.WLSJDNTRNM.BackColor = System.Drawing.SystemColors.Window
		Me.WLSJDNTRNM.ForeColor = System.Drawing.SystemColors.WindowText
		Me.WLSJDNTRNM.Size = New System.Drawing.Size(115, 25)
		Me.WLSJDNTRNM.Location = New System.Drawing.Point(120, 8)
		Me.WLSJDNTRNM.TabIndex = 17
		Me.WLSJDNTRNM.Enabled = True
		Me.WLSJDNTRNM.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSJDNTRNM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSJDNTRNM.UseMnemonic = True
		Me.WLSJDNTRNM.Visible = True
		Me.WLSJDNTRNM.AutoSize = False
		Me.WLSJDNTRNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.WLSJDNTRNM.Name = "WLSJDNTRNM"
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
		Me.WLSMAE.Location = New System.Drawing.Point(368, 384)
		Me.WLSMAE.Image = CType(resources.GetObject("WLSMAE.Image"), System.Drawing.Image)
		Me.WLSMAE.Enabled = True
		Me.WLSMAE.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSMAE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.WLSMAE.Visible = True
		Me.WLSMAE.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.WLSMAE.Name = "WLSMAE"
		Me.WLSATO.Size = New System.Drawing.Size(24, 22)
		Me.WLSATO.Location = New System.Drawing.Point(568, 384)
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
		Me.Panel3D1.Controls.Add(WLSURIKB)
		Me.Panel3D1.Controls.Add(WLSUDNDT)
		Me.Panel3D1.Controls.Add(COM_UDNDT)
		Me.Panel3D1.Controls.Add(HD_TEXT)
		Me.Panel3D1.Controls.Add(WLSJDNTRKB)
		Me.Panel3D1.Controls.Add(COM_JDNTRKB)
		Me.Panel3D1.Controls.Add(HD_TOKJDNNO)
		Me.Panel3D1.Controls.Add(WLSNHSCD)
		Me.Panel3D1.Controls.Add(WLSTOKCD)
		Me.Panel3D1.Controls.Add(COM_TOKCD)
		Me.Panel3D1.Controls.Add(COM_NHSCD)
		Me.Panel3D1.Controls.Add(_SSPanel52_0)
		Me.Panel3D1.Controls.Add(Panel3D4)
		Me.Panel3D1.Controls.Add(_SSPanel52_1)
		Me.Panel3D1.Controls.Add(Label1)
		Me.Panel3D1.Controls.Add(WLSJDNTRNM)
		Me.IM_ATO.SetIndex(_IM_ATO_1, CType(1, Short))
		Me.IM_ATO.SetIndex(_IM_ATO_0, CType(0, Short))
		Me.IM_MAE.SetIndex(_IM_MAE_1, CType(1, Short))
		Me.IM_MAE.SetIndex(_IM_MAE_0, CType(0, Short))
		Me.SSPanel52.SetIndex(_SSPanel52_0, CType(0, Short))
		Me.SSPanel52.SetIndex(_SSPanel52_1, CType(1, Short))
		CType(Me.SSPanel52, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel3D1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class