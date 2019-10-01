<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FR_SSSMAIN
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
    Public WithEvents HD_IN_TANNM As System.Windows.Forms.TextBox
	Public WithEvents HD_IN_TANCD As System.Windows.Forms.TextBox
	Public WithEvents HD_OEMKB As System.Windows.Forms.TextBox
	Public WithEvents HD_OPENKB As System.Windows.Forms.TextBox
	Public WithEvents HD_CTLGKB As System.Windows.Forms.TextBox
	Public WithEvents HD_MLOKB As System.Windows.Forms.TextBox
	Public WithEvents HD_BTOKB As System.Windows.Forms.TextBox
	Public WithEvents HD_ZAIKB As System.Windows.Forms.TextBox
	Public WithEvents HD_HINKB As System.Windows.Forms.TextBox
	Public WithEvents Label15 As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame3D1 As System.Windows.Forms.GroupBox
	Public WithEvents TM_StartUp As System.Windows.Forms.Timer
	Public WithEvents TX_CursorRest As System.Windows.Forms.TextBox
	Public WithEvents cmd_Cancel As System.Windows.Forms.Button
    Public WithEvents SYSDT As Label
    Public WithEvents _FM_Panel3D1_2 As Label
    Public WithEvents FM_Panel3D1 As VB6.PanelArray
	Public WithEvents IM_Denkyu As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_EndCm As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_Execute As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更できます。
    'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_SSSMAIN))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.HD_IN_TANNM = New System.Windows.Forms.TextBox()
        Me.HD_IN_TANCD = New System.Windows.Forms.TextBox()
        Me.Frame3D1 = New System.Windows.Forms.GroupBox()
        Me.HD_OEMKB = New System.Windows.Forms.TextBox()
        Me.HD_OPENKB = New System.Windows.Forms.TextBox()
        Me.HD_CTLGKB = New System.Windows.Forms.TextBox()
        Me.HD_MLOKB = New System.Windows.Forms.TextBox()
        Me.HD_BTOKB = New System.Windows.Forms.TextBox()
        Me.HD_ZAIKB = New System.Windows.Forms.TextBox()
        Me.HD_HINKB = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TM_StartUp = New System.Windows.Forms.Timer(Me.components)
        Me.TX_CursorRest = New System.Windows.Forms.TextBox()
        Me.cmd_Cancel = New System.Windows.Forms.Button()
        Me.SYSDT = New System.Windows.Forms.Label()
        Me.CMDialogL = New System.Windows.Forms.OpenFileDialog()
        Me._FM_Panel3D1_2 = New System.Windows.Forms.Label()
        Me.FM_Panel3D1 = New Microsoft.VisualBasic.Compatibility.VB6.PanelArray(Me.components)
        Me.IM_Denkyu = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_EndCm = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_Execute = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Frame3D1.SuspendLayout()
        CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_Denkyu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_EndCm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_Execute, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'HD_IN_TANNM
        '
        Me.HD_IN_TANNM.AcceptsReturn = True
        Me.HD_IN_TANNM.BackColor = System.Drawing.SystemColors.Control
        Me.HD_IN_TANNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_IN_TANNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_IN_TANNM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_IN_TANNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_IN_TANNM.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_IN_TANNM.Location = New System.Drawing.Point(768, 48)
        Me.HD_IN_TANNM.MaxLength = 24
        Me.HD_IN_TANNM.Name = "HD_IN_TANNM"
        Me.HD_IN_TANNM.ReadOnly = True
        Me.HD_IN_TANNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_IN_TANNM.Size = New System.Drawing.Size(147, 19)
        Me.HD_IN_TANNM.TabIndex = 2
        Me.HD_IN_TANNM.TabStop = False
        Me.HD_IN_TANNM.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'HD_IN_TANCD
        '
        Me.HD_IN_TANCD.AcceptsReturn = True
        Me.HD_IN_TANCD.BackColor = System.Drawing.SystemColors.Control
        Me.HD_IN_TANCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_IN_TANCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_IN_TANCD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_IN_TANCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_IN_TANCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_IN_TANCD.Location = New System.Drawing.Point(722, 48)
        Me.HD_IN_TANCD.MaxLength = 10
        Me.HD_IN_TANCD.Name = "HD_IN_TANCD"
        Me.HD_IN_TANCD.ReadOnly = True
        Me.HD_IN_TANCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_IN_TANCD.Size = New System.Drawing.Size(53, 19)
        Me.HD_IN_TANCD.TabIndex = 1
        Me.HD_IN_TANCD.TabStop = False
        Me.HD_IN_TANCD.Text = "XXXXX6"
        '
        'Frame3D1
        '
        Me.Frame3D1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3D1.Controls.Add(Me.HD_OEMKB)
        Me.Frame3D1.Controls.Add(Me.HD_OPENKB)
        Me.Frame3D1.Controls.Add(Me.HD_CTLGKB)
        Me.Frame3D1.Controls.Add(Me.HD_MLOKB)
        Me.Frame3D1.Controls.Add(Me.HD_BTOKB)
        Me.Frame3D1.Controls.Add(Me.HD_ZAIKB)
        Me.Frame3D1.Controls.Add(Me.HD_HINKB)
        Me.Frame3D1.Controls.Add(Me.Label15)
        Me.Frame3D1.Controls.Add(Me.Label14)
        Me.Frame3D1.Controls.Add(Me.Label13)
        Me.Frame3D1.Controls.Add(Me.Label12)
        Me.Frame3D1.Controls.Add(Me.Label11)
        Me.Frame3D1.Controls.Add(Me.Label10)
        Me.Frame3D1.Controls.Add(Me.Label9)
        Me.Frame3D1.Controls.Add(Me.Label8)
        Me.Frame3D1.Controls.Add(Me.Label7)
        Me.Frame3D1.Controls.Add(Me.Label6)
        Me.Frame3D1.Controls.Add(Me.Label5)
        Me.Frame3D1.Controls.Add(Me.Label4)
        Me.Frame3D1.Controls.Add(Me.Label3)
        Me.Frame3D1.Controls.Add(Me.Label2)
        Me.Frame3D1.Controls.Add(Me.Label1)
        Me.Frame3D1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Frame3D1.ForeColor = System.Drawing.Color.Black
        Me.Frame3D1.Location = New System.Drawing.Point(19, 81)
        Me.Frame3D1.Name = "Frame3D1"
        Me.Frame3D1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3D1.Size = New System.Drawing.Size(903, 256)
        Me.Frame3D1.TabIndex = 14
        Me.Frame3D1.TabStop = False
        Me.Frame3D1.Text = "条件指定"
        '
        'HD_OEMKB
        '
        Me.HD_OEMKB.AcceptsReturn = True
        Me.HD_OEMKB.BackColor = System.Drawing.SystemColors.Window
        Me.HD_OEMKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_OEMKB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_OEMKB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_OEMKB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.HD_OEMKB.Location = New System.Drawing.Point(120, 224)
        Me.HD_OEMKB.MaxLength = 1
        Me.HD_OEMKB.Name = "HD_OEMKB"
        Me.HD_OEMKB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_OEMKB.Size = New System.Drawing.Size(17, 19)
        Me.HD_OEMKB.TabIndex = 9
        Me.HD_OEMKB.Text = "0"
        '
        'HD_OPENKB
        '
        Me.HD_OPENKB.AcceptsReturn = True
        Me.HD_OPENKB.BackColor = System.Drawing.SystemColors.Window
        Me.HD_OPENKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_OPENKB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_OPENKB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_OPENKB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.HD_OPENKB.Location = New System.Drawing.Point(120, 200)
        Me.HD_OPENKB.MaxLength = 1
        Me.HD_OPENKB.Name = "HD_OPENKB"
        Me.HD_OPENKB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_OPENKB.Size = New System.Drawing.Size(17, 19)
        Me.HD_OPENKB.TabIndex = 8
        Me.HD_OPENKB.Text = "0"
        '
        'HD_CTLGKB
        '
        Me.HD_CTLGKB.AcceptsReturn = True
        Me.HD_CTLGKB.BackColor = System.Drawing.SystemColors.Window
        Me.HD_CTLGKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_CTLGKB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_CTLGKB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_CTLGKB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.HD_CTLGKB.Location = New System.Drawing.Point(120, 168)
        Me.HD_CTLGKB.MaxLength = 1
        Me.HD_CTLGKB.Name = "HD_CTLGKB"
        Me.HD_CTLGKB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_CTLGKB.Size = New System.Drawing.Size(17, 19)
        Me.HD_CTLGKB.TabIndex = 7
        Me.HD_CTLGKB.Text = "0"
        '
        'HD_MLOKB
        '
        Me.HD_MLOKB.AcceptsReturn = True
        Me.HD_MLOKB.BackColor = System.Drawing.SystemColors.Window
        Me.HD_MLOKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_MLOKB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_MLOKB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_MLOKB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.HD_MLOKB.Location = New System.Drawing.Point(120, 136)
        Me.HD_MLOKB.MaxLength = 1
        Me.HD_MLOKB.Name = "HD_MLOKB"
        Me.HD_MLOKB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_MLOKB.Size = New System.Drawing.Size(17, 19)
        Me.HD_MLOKB.TabIndex = 6
        Me.HD_MLOKB.Text = "0"
        '
        'HD_BTOKB
        '
        Me.HD_BTOKB.AcceptsReturn = True
        Me.HD_BTOKB.BackColor = System.Drawing.SystemColors.Window
        Me.HD_BTOKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_BTOKB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_BTOKB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_BTOKB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.HD_BTOKB.Location = New System.Drawing.Point(120, 104)
        Me.HD_BTOKB.MaxLength = 1
        Me.HD_BTOKB.Name = "HD_BTOKB"
        Me.HD_BTOKB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_BTOKB.Size = New System.Drawing.Size(17, 19)
        Me.HD_BTOKB.TabIndex = 5
        Me.HD_BTOKB.Text = "0"
        '
        'HD_ZAIKB
        '
        Me.HD_ZAIKB.AcceptsReturn = True
        Me.HD_ZAIKB.BackColor = System.Drawing.SystemColors.Window
        Me.HD_ZAIKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_ZAIKB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_ZAIKB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_ZAIKB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.HD_ZAIKB.Location = New System.Drawing.Point(120, 72)
        Me.HD_ZAIKB.MaxLength = 1
        Me.HD_ZAIKB.Name = "HD_ZAIKB"
        Me.HD_ZAIKB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_ZAIKB.Size = New System.Drawing.Size(17, 19)
        Me.HD_ZAIKB.TabIndex = 4
        Me.HD_ZAIKB.Text = "1"
        '
        'HD_HINKB
        '
        Me.HD_HINKB.AcceptsReturn = True
        Me.HD_HINKB.BackColor = System.Drawing.SystemColors.Window
        Me.HD_HINKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_HINKB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_HINKB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_HINKB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.HD_HINKB.Location = New System.Drawing.Point(120, 24)
        Me.HD_HINKB.MaxLength = 1
        Me.HD_HINKB.Name = "HD_HINKB"
        Me.HD_HINKB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_HINKB.Size = New System.Drawing.Size(17, 19)
        Me.HD_HINKB.TabIndex = 3
        Me.HD_HINKB.Text = "1"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(152, 224)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(120, 12)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "1:対象 9:対象外 0:全て"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(62, 224)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(35, 12)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "ＯＥＭ"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(152, 200)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(128, 12)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "1:対象 9:オープン 0:全て"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(48, 200)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(53, 12)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "価格区分"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(152, 168)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(120, 12)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "1:対象 9:対象外 0:全て"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(34, 168)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "仕切表対象"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(152, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(120, 12)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "1:対象 9:対象外 0:全て"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(48, 136)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(53, 12)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "通販対象"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(152, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(120, 12)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "1:提供 9:非提供 0:全て"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(76, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "区分"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(152, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(120, 12)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "1:対象 9:対象外 0:全て"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(48, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "在庫管理"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(152, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(168, 12)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "4 : 加工品 5 : 半製品 9 : その他"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(152, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(161, 12)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "1 : 製品　 2 : 商品　 3 : 市販品"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(48, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "商品区分"
        '
        'TM_StartUp
        '
        Me.TM_StartUp.Interval = 1
        '
        'TX_CursorRest
        '
        Me.TX_CursorRest.AcceptsReturn = True
        Me.TX_CursorRest.BackColor = System.Drawing.SystemColors.Window
        Me.TX_CursorRest.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TX_CursorRest.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TX_CursorRest.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TX_CursorRest.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TX_CursorRest.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TX_CursorRest.Location = New System.Drawing.Point(2460, 2457)
        Me.TX_CursorRest.MaxLength = 0
        Me.TX_CursorRest.Name = "TX_CursorRest"
        Me.TX_CursorRest.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_CursorRest.Size = New System.Drawing.Size(19, 12)
        Me.TX_CursorRest.TabIndex = 11
        Me.TX_CursorRest.TabStop = False
        '
        'cmd_Cancel
        '
        Me.cmd_Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_Cancel.Enabled = False
        Me.cmd_Cancel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmd_Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_Cancel.Location = New System.Drawing.Point(429, 556)
        Me.cmd_Cancel.Name = "cmd_Cancel"
        Me.cmd_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_Cancel.Size = New System.Drawing.Size(81, 25)
        Me.cmd_Cancel.TabIndex = 12
        Me.cmd_Cancel.Text = "中止"
        Me.cmd_Cancel.UseVisualStyleBackColor = False
        '
        'SYSDT
        '
        Me.SYSDT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SYSDT.Location = New System.Drawing.Point(828, 9)
        Me.SYSDT.Name = "SYSDT"
        Me.SYSDT.Size = New System.Drawing.Size(94, 19)
        Me.SYSDT.TabIndex = 16
        Me.SYSDT.Text = "YYYY/MM/DD"
        '
        '_FM_Panel3D1_2
        '
        Me._FM_Panel3D1_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._FM_Panel3D1_2.Location = New System.Drawing.Point(626, 48)
        Me._FM_Panel3D1_2.Name = "_FM_Panel3D1_2"
        Me._FM_Panel3D1_2.Size = New System.Drawing.Size(97, 19)
        Me._FM_Panel3D1_2.TabIndex = 0
        Me._FM_Panel3D1_2.Text = " 入力担当者"
        Me._FM_Panel3D1_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button12
        '
        Me.Button12.CausesValidation = False
        Me.Button12.Location = New System.Drawing.Point(853, 596)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(75, 39)
        Me.Button12.TabIndex = 92
        Me.Button12.Text = "(F12)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(780, 596)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(75, 39)
        Me.Button11.TabIndex = 91
        Me.Button11.Text = "(F11)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " CSV出力"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.CausesValidation = False
        Me.Button10.Location = New System.Drawing.Point(707, 596)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 39)
        Me.Button10.TabIndex = 90
        Me.Button10.Text = "(F10)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.CausesValidation = False
        Me.Button9.Location = New System.Drawing.Point(634, 596)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 39)
        Me.Button9.TabIndex = 89
        Me.Button9.Text = "(F9)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "クリア"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(544, 596)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 39)
        Me.Button8.TabIndex = 88
        Me.Button8.Text = "(F8)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  "
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(471, 596)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 39)
        Me.Button7.TabIndex = 87
        Me.Button7.Text = "(F7)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(398, 596)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 39)
        Me.Button6.TabIndex = 86
        Me.Button6.Text = "(F6)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  "
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(325, 596)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 39)
        Me.Button5.TabIndex = 85
        Me.Button5.Text = "(F5)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(236, 596)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 39)
        Me.Button4.TabIndex = 84
        Me.Button4.Text = "(F4)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(163, 596)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 39)
        Me.Button3.TabIndex = 83
        Me.Button3.Text = "(F3)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "　　"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(90, 596)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 39)
        Me.Button2.TabIndex = 82
        Me.Button2.Text = "(F2)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  "
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(17, 596)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 39)
        Me.Button1.TabIndex = 81
        Me.Button1.Text = "(F1)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        Me.Button1.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 639)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(944, 22)
        Me.StatusStrip1.TabIndex = 93
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(185, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "YYYY/MM/DD"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(185, 17)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "端末ID"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(185, 17)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Text = "ログインID"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(185, 17)
        Me.ToolStripStatusLabel4.Spring = True
        Me.ToolStripStatusLabel4.Text = "XXXXXXX"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(185, 17)
        Me.ToolStripStatusLabel5.Spring = True
        Me.ToolStripStatusLabel5.Text = "Ver.1.00"
        '
        'FR_SSSMAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(944, 661)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.SYSDT)
        Me.Controls.Add(Me.HD_IN_TANNM)
        Me.Controls.Add(Me.HD_IN_TANCD)
        Me.Controls.Add(Me.Frame3D1)
        Me.Controls.Add(Me.TX_CursorRest)
        Me.Controls.Add(Me.cmd_Cancel)
        Me.Controls.Add(Me._FM_Panel3D1_2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(11, 49)
        Me.Name = "FR_SSSMAIN"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "商品マスタ一括抽出"
        Me.Frame3D1.ResumeLayout(False)
        Me.Frame3D1.PerformLayout()
        CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_Denkyu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_EndCm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_Execute, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents CMDialogL As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
#End Region 
End Class