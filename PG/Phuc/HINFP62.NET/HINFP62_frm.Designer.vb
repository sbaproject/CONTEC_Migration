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
    Public WithEvents Gage As Label
    Public WithEvents Cmd_cancel As System.Windows.Forms.Button
	Public WithEvents TX_CursorRest As System.Windows.Forms.TextBox
	Public WithEvents TM_StartUp As System.Windows.Forms.Timer
	Public WithEvents HD_TFPATH_B As System.Windows.Forms.TextBox
    Public WithEvents CS_TFPATH_B As Button
    Public WithEvents Frame3D1 As System.Windows.Forms.GroupBox
	Public WithEvents HD_IN_TANCD As System.Windows.Forms.TextBox
	Public WithEvents HD_IN_TANNM As System.Windows.Forms.TextBox
    Public WithEvents SYSDT As Label
    Public WithEvents CM_Execute As System.Windows.Forms.PictureBox
	Public WithEvents CM_EndCm As System.Windows.Forms.PictureBox
	Public WithEvents Image1 As System.Windows.Forms.PictureBox
    Public WithEvents _FM_Panel3D1_1 As Label
    Public WithEvents TX_Message As System.Windows.Forms.TextBox
    Public WithEvents _FM_Panel3D1_4 As Label
    Public WithEvents _IM_Denkyu_0 As System.Windows.Forms.PictureBox
    Public WithEvents _FM_Panel3D1_3 As Label
    Public WithEvents TX_Mode As System.Windows.Forms.TextBox
    Public WithEvents CMDialogL As OpenFileDialog
    Public WithEvents _IM_EndCm_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_EndCm_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Denkyu_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Denkyu_2 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Execute_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Execute_1 As System.Windows.Forms.PictureBox
    Public WithEvents _FM_Panel3D1_0 As Label
    Public WithEvents _FM_Panel3D1_2 As Label
    Public WithEvents FM_Panel3D1 As VB6.PanelArray
    Public WithEvents IM_Denkyu As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_EndCm As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_Execute As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents MN_EXECUTE As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents bar11 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents MN_EndCm As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_Ctrl As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_APPENDC As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_EditMn As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_SSSMAIN))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Gage = New System.Windows.Forms.Label()
        Me.Cmd_cancel = New System.Windows.Forms.Button()
        Me.TX_CursorRest = New System.Windows.Forms.TextBox()
        Me.TM_StartUp = New System.Windows.Forms.Timer(Me.components)
        Me.Frame3D1 = New System.Windows.Forms.GroupBox()
        Me.HD_TFPATH_B = New System.Windows.Forms.TextBox()
        Me.CS_TFPATH_B = New System.Windows.Forms.Button()
        Me.HD_IN_TANCD = New System.Windows.Forms.TextBox()
        Me.HD_IN_TANNM = New System.Windows.Forms.TextBox()
        Me._FM_Panel3D1_1 = New System.Windows.Forms.Label()
        Me.CM_Execute = New System.Windows.Forms.PictureBox()
        Me.CM_EndCm = New System.Windows.Forms.PictureBox()
        Me.Image1 = New System.Windows.Forms.PictureBox()
        Me.SYSDT = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_3 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_4 = New System.Windows.Forms.Label()
        Me.TX_Message = New System.Windows.Forms.TextBox()
        Me._IM_Denkyu_0 = New System.Windows.Forms.PictureBox()
        Me._FM_Panel3D1_0 = New System.Windows.Forms.Label()
        Me.TX_Mode = New System.Windows.Forms.TextBox()
        Me._IM_EndCm_1 = New System.Windows.Forms.PictureBox()
        Me._IM_EndCm_0 = New System.Windows.Forms.PictureBox()
        Me._IM_Denkyu_1 = New System.Windows.Forms.PictureBox()
        Me._IM_Denkyu_2 = New System.Windows.Forms.PictureBox()
        Me._IM_Execute_0 = New System.Windows.Forms.PictureBox()
        Me._IM_Execute_1 = New System.Windows.Forms.PictureBox()
        Me.CMDialogL = New System.Windows.Forms.OpenFileDialog()
        Me._FM_Panel3D1_2 = New System.Windows.Forms.Label()
        Me.FM_Panel3D1 = New Microsoft.VisualBasic.Compatibility.VB6.PanelArray(Me.components)
        Me.IM_Denkyu = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_EndCm = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_Execute = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.MN_Ctrl = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_EXECUTE = New System.Windows.Forms.ToolStripMenuItem()
        Me.bar11 = New System.Windows.Forms.ToolStripSeparator()
        Me.MN_EndCm = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_EditMn = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_APPENDC = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnF12 = New System.Windows.Forms.Button()
        Me.btnF11 = New System.Windows.Forms.Button()
        Me.btnF10 = New System.Windows.Forms.Button()
        Me.btnF9 = New System.Windows.Forms.Button()
        Me.btnF8 = New System.Windows.Forms.Button()
        Me.btnF7 = New System.Windows.Forms.Button()
        Me.btnF6 = New System.Windows.Forms.Button()
        Me.btnF5 = New System.Windows.Forms.Button()
        Me.btnF4 = New System.Windows.Forms.Button()
        Me.btnF3 = New System.Windows.Forms.Button()
        Me.btnF2 = New System.Windows.Forms.Button()
        Me.btnF1 = New System.Windows.Forms.Button()
        Me.Frame3D1.SuspendLayout()
        Me._FM_Panel3D1_1.SuspendLayout()
        CType(Me.CM_Execute, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_EndCm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._FM_Panel3D1_3.SuspendLayout()
        Me._FM_Panel3D1_4.SuspendLayout()
        CType(Me._IM_Denkyu_0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._FM_Panel3D1_0.SuspendLayout()
        CType(Me._IM_EndCm_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_EndCm_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Denkyu_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Denkyu_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Execute_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Execute_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_Denkyu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_EndCm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_Execute, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainMenu1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Gage
        '
        Me.Gage.AutoSize = True
        Me.Gage.Location = New System.Drawing.Point(56, 155)
        Me.Gage.Name = "Gage"
        Me.Gage.Size = New System.Drawing.Size(59, 12)
        Me.Gage.TabIndex = 15
        Me.Gage.Text = "SSPanel51"
        Me.Gage.Visible = False
        '
        'Cmd_cancel
        '
        Me.Cmd_cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cmd_cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cmd_cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_cancel.Location = New System.Drawing.Point(216, 199)
        Me.Cmd_cancel.Name = "Cmd_cancel"
        Me.Cmd_cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cmd_cancel.Size = New System.Drawing.Size(81, 23)
        Me.Cmd_cancel.TabIndex = 14
        Me.Cmd_cancel.Text = "中止"
        Me.Cmd_cancel.UseVisualStyleBackColor = False
        Me.Cmd_cancel.Visible = False
        '
        'TX_CursorRest
        '
        Me.TX_CursorRest.AcceptsReturn = True
        Me.TX_CursorRest.BackColor = System.Drawing.SystemColors.Window
        Me.TX_CursorRest.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TX_CursorRest.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TX_CursorRest.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TX_CursorRest.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TX_CursorRest.Location = New System.Drawing.Point(2460, 2268)
        Me.TX_CursorRest.MaxLength = 0
        Me.TX_CursorRest.Name = "TX_CursorRest"
        Me.TX_CursorRest.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_CursorRest.Size = New System.Drawing.Size(19, 12)
        Me.TX_CursorRest.TabIndex = 12
        '
        'TM_StartUp
        '
        Me.TM_StartUp.Interval = 1
        '
        'Frame3D1
        '
        Me.Frame3D1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3D1.Controls.Add(Me.HD_TFPATH_B)
        Me.Frame3D1.Controls.Add(Me.CS_TFPATH_B)
        Me.Frame3D1.ForeColor = System.Drawing.Color.Black
        Me.Frame3D1.Location = New System.Drawing.Point(19, 75)
        Me.Frame3D1.Name = "Frame3D1"
        Me.Frame3D1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3D1.Size = New System.Drawing.Size(524, 66)
        Me.Frame3D1.TabIndex = 7
        Me.Frame3D1.TabStop = False
        Me.Frame3D1.Text = "条件指定"
        '
        'HD_TFPATH_B
        '
        Me.HD_TFPATH_B.AcceptsReturn = True
        Me.HD_TFPATH_B.BackColor = System.Drawing.SystemColors.Control
        Me.HD_TFPATH_B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TFPATH_B.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TFPATH_B.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TFPATH_B.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_TFPATH_B.Location = New System.Drawing.Point(152, 22)
        Me.HD_TFPATH_B.MaxLength = 0
        Me.HD_TFPATH_B.Name = "HD_TFPATH_B"
        Me.HD_TFPATH_B.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TFPATH_B.Size = New System.Drawing.Size(357, 19)
        Me.HD_TFPATH_B.TabIndex = 8
        Me.HD_TFPATH_B.TabStop = False
        Me.HD_TFPATH_B.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5"
        '
        'CS_TFPATH_B
        '
        Me.CS_TFPATH_B.Location = New System.Drawing.Point(10, 22)
        Me.CS_TFPATH_B.Name = "CS_TFPATH_B"
        Me.CS_TFPATH_B.Size = New System.Drawing.Size(143, 21)
        Me.CS_TFPATH_B.TabIndex = 9
        Me.CS_TFPATH_B.TabStop = False
        Me.CS_TFPATH_B.Text = "更新用ファイル名"
        '
        'HD_IN_TANCD
        '
        Me.HD_IN_TANCD.AcceptsReturn = True
        Me.HD_IN_TANCD.BackColor = System.Drawing.SystemColors.Control
        Me.HD_IN_TANCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_IN_TANCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_IN_TANCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_IN_TANCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_IN_TANCD.Location = New System.Drawing.Point(782, 37)
        Me.HD_IN_TANCD.MaxLength = 10
        Me.HD_IN_TANCD.Name = "HD_IN_TANCD"
        Me.HD_IN_TANCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_IN_TANCD.Size = New System.Drawing.Size(53, 19)
        Me.HD_IN_TANCD.TabIndex = 1
        Me.HD_IN_TANCD.TabStop = False
        Me.HD_IN_TANCD.Text = "XXXXX6"
        '
        'HD_IN_TANNM
        '
        Me.HD_IN_TANNM.AcceptsReturn = True
        Me.HD_IN_TANNM.BackColor = System.Drawing.SystemColors.Control
        Me.HD_IN_TANNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_IN_TANNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_IN_TANNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_IN_TANNM.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_IN_TANNM.Location = New System.Drawing.Point(834, 37)
        Me.HD_IN_TANNM.MaxLength = 24
        Me.HD_IN_TANNM.Name = "HD_IN_TANNM"
        Me.HD_IN_TANNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_IN_TANNM.Size = New System.Drawing.Size(147, 19)
        Me.HD_IN_TANNM.TabIndex = 0
        Me.HD_IN_TANNM.TabStop = False
        Me.HD_IN_TANNM.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        '_FM_Panel3D1_1
        '
        Me._FM_Panel3D1_1.Controls.Add(Me.CM_Execute)
        Me._FM_Panel3D1_1.Controls.Add(Me.CM_EndCm)
        Me._FM_Panel3D1_1.Controls.Add(Me.Image1)
        Me._FM_Panel3D1_1.Location = New System.Drawing.Point(0, 0)
        Me._FM_Panel3D1_1.Name = "_FM_Panel3D1_1"
        Me._FM_Panel3D1_1.Size = New System.Drawing.Size(1086, 34)
        Me._FM_Panel3D1_1.TabIndex = 2
        '
        'CM_Execute
        '
        Me.CM_Execute.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_Execute.Image = CType(resources.GetObject("CM_Execute.Image"), System.Drawing.Image)
        Me.CM_Execute.Location = New System.Drawing.Point(40, 6)
        Me.CM_Execute.Name = "CM_Execute"
        Me.CM_Execute.Size = New System.Drawing.Size(24, 20)
        Me.CM_Execute.TabIndex = 4
        Me.CM_Execute.TabStop = False
        Me.CM_Execute.Visible = False
        '
        'CM_EndCm
        '
        Me.CM_EndCm.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_EndCm.Image = CType(resources.GetObject("CM_EndCm.Image"), System.Drawing.Image)
        Me.CM_EndCm.Location = New System.Drawing.Point(16, 6)
        Me.CM_EndCm.Name = "CM_EndCm"
        Me.CM_EndCm.Size = New System.Drawing.Size(24, 20)
        Me.CM_EndCm.TabIndex = 5
        Me.CM_EndCm.TabStop = False
        Me.CM_EndCm.Visible = False
        '
        'Image1
        '
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Location = New System.Drawing.Point(0, 0)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(413, 31)
        Me.Image1.TabIndex = 6
        Me.Image1.TabStop = False
        '
        'SYSDT
        '
        Me.SYSDT.Location = New System.Drawing.Point(887, 9)
        Me.SYSDT.Name = "SYSDT"
        Me.SYSDT.Size = New System.Drawing.Size(94, 18)
        Me.SYSDT.TabIndex = 3
        Me.SYSDT.Text = "YYYY/MM/DD"
        '
        '_FM_Panel3D1_3
        '
        Me._FM_Panel3D1_3.Controls.Add(Me._FM_Panel3D1_4)
        Me._FM_Panel3D1_3.Controls.Add(Me._IM_Denkyu_0)
        Me._FM_Panel3D1_3.Location = New System.Drawing.Point(0, 229)
        Me._FM_Panel3D1_3.Name = "_FM_Panel3D1_3"
        Me._FM_Panel3D1_3.Size = New System.Drawing.Size(565, 40)
        Me._FM_Panel3D1_3.TabIndex = 4
        '
        '_FM_Panel3D1_4
        '
        Me._FM_Panel3D1_4.Controls.Add(Me.TX_Message)
        Me._FM_Panel3D1_4.Location = New System.Drawing.Point(39, 8)
        Me._FM_Panel3D1_4.Name = "_FM_Panel3D1_4"
        Me._FM_Panel3D1_4.Size = New System.Drawing.Size(504, 23)
        Me._FM_Panel3D1_4.TabIndex = 5
        '
        'TX_Message
        '
        Me.TX_Message.AcceptsReturn = True
        Me.TX_Message.BackColor = System.Drawing.SystemColors.Control
        Me.TX_Message.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TX_Message.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TX_Message.ForeColor = System.Drawing.Color.Black
        Me.TX_Message.Location = New System.Drawing.Point(6, 6)
        Me.TX_Message.MaxLength = 0
        Me.TX_Message.Multiline = True
        Me.TX_Message.Name = "TX_Message"
        Me.TX_Message.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_Message.Size = New System.Drawing.Size(397, 15)
        Me.TX_Message.TabIndex = 6
        Me.TX_Message.TabStop = False
        Me.TX_Message.Text = "エラーやプロンプトのメッセージが出力されるところです。"
        '
        '_IM_Denkyu_0
        '
        Me._IM_Denkyu_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_0.Image = CType(resources.GetObject("_IM_Denkyu_0.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_0, CType(0, Short))
        Me._IM_Denkyu_0.Location = New System.Drawing.Point(12, 8)
        Me._IM_Denkyu_0.Name = "_IM_Denkyu_0"
        Me._IM_Denkyu_0.Size = New System.Drawing.Size(20, 20)
        Me._IM_Denkyu_0.TabIndex = 6
        Me._IM_Denkyu_0.TabStop = False
        Me._IM_Denkyu_0.Visible = False
        '
        '_FM_Panel3D1_0
        '
        Me._FM_Panel3D1_0.Controls.Add(Me.TX_Mode)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_EndCm_1)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_EndCm_0)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_Denkyu_1)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_Denkyu_2)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_Execute_0)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_Execute_1)
        Me._FM_Panel3D1_0.Location = New System.Drawing.Point(3, 273)
        Me._FM_Panel3D1_0.Name = "_FM_Panel3D1_0"
        Me._FM_Panel3D1_0.Size = New System.Drawing.Size(553, 87)
        Me._FM_Panel3D1_0.TabIndex = 10
        Me._FM_Panel3D1_0.Visible = False
        '
        'TX_Mode
        '
        Me.TX_Mode.AcceptsReturn = True
        Me.TX_Mode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TX_Mode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TX_Mode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TX_Mode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TX_Mode.Location = New System.Drawing.Point(105, 39)
        Me.TX_Mode.MaxLength = 0
        Me.TX_Mode.Name = "TX_Mode"
        Me.TX_Mode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_Mode.Size = New System.Drawing.Size(49, 19)
        Me.TX_Mode.TabIndex = 11
        Me.TX_Mode.Text = "ﾓｰﾄﾞ"
        '
        '_IM_EndCm_1
        '
        Me._IM_EndCm_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_EndCm_1.Image = CType(resources.GetObject("_IM_EndCm_1.Image"), System.Drawing.Image)
        Me.IM_EndCm.SetIndex(Me._IM_EndCm_1, CType(1, Short))
        Me._IM_EndCm_1.Location = New System.Drawing.Point(36, 3)
        Me._IM_EndCm_1.Name = "_IM_EndCm_1"
        Me._IM_EndCm_1.Size = New System.Drawing.Size(24, 20)
        Me._IM_EndCm_1.TabIndex = 12
        Me._IM_EndCm_1.TabStop = False
        Me._IM_EndCm_1.Visible = False
        '
        '_IM_EndCm_0
        '
        Me._IM_EndCm_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_EndCm_0.Image = CType(resources.GetObject("_IM_EndCm_0.Image"), System.Drawing.Image)
        Me.IM_EndCm.SetIndex(Me._IM_EndCm_0, CType(0, Short))
        Me._IM_EndCm_0.Location = New System.Drawing.Point(12, 3)
        Me._IM_EndCm_0.Name = "_IM_EndCm_0"
        Me._IM_EndCm_0.Size = New System.Drawing.Size(24, 20)
        Me._IM_EndCm_0.TabIndex = 13
        Me._IM_EndCm_0.TabStop = False
        Me._IM_EndCm_0.Visible = False
        '
        '_IM_Denkyu_1
        '
        Me._IM_Denkyu_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_1.Image = CType(resources.GetObject("_IM_Denkyu_1.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_1, CType(1, Short))
        Me._IM_Denkyu_1.Location = New System.Drawing.Point(135, 30)
        Me._IM_Denkyu_1.Name = "_IM_Denkyu_1"
        Me._IM_Denkyu_1.Size = New System.Drawing.Size(20, 20)
        Me._IM_Denkyu_1.TabIndex = 14
        Me._IM_Denkyu_1.TabStop = False
        '
        '_IM_Denkyu_2
        '
        Me._IM_Denkyu_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_2.Image = CType(resources.GetObject("_IM_Denkyu_2.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_2, CType(2, Short))
        Me._IM_Denkyu_2.Location = New System.Drawing.Point(162, 30)
        Me._IM_Denkyu_2.Name = "_IM_Denkyu_2"
        Me._IM_Denkyu_2.Size = New System.Drawing.Size(20, 20)
        Me._IM_Denkyu_2.TabIndex = 15
        Me._IM_Denkyu_2.TabStop = False
        '
        '_IM_Execute_0
        '
        Me._IM_Execute_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Execute_0.Image = CType(resources.GetObject("_IM_Execute_0.Image"), System.Drawing.Image)
        Me.IM_Execute.SetIndex(Me._IM_Execute_0, CType(0, Short))
        Me._IM_Execute_0.Location = New System.Drawing.Point(69, 3)
        Me._IM_Execute_0.Name = "_IM_Execute_0"
        Me._IM_Execute_0.Size = New System.Drawing.Size(24, 20)
        Me._IM_Execute_0.TabIndex = 16
        Me._IM_Execute_0.TabStop = False
        Me._IM_Execute_0.Visible = False
        '
        '_IM_Execute_1
        '
        Me._IM_Execute_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Execute_1.Image = CType(resources.GetObject("_IM_Execute_1.Image"), System.Drawing.Image)
        Me.IM_Execute.SetIndex(Me._IM_Execute_1, CType(1, Short))
        Me._IM_Execute_1.Location = New System.Drawing.Point(95, 3)
        Me._IM_Execute_1.Name = "_IM_Execute_1"
        Me._IM_Execute_1.Size = New System.Drawing.Size(24, 20)
        Me._IM_Execute_1.TabIndex = 17
        Me._IM_Execute_1.TabStop = False
        Me._IM_Execute_1.Visible = False
        '
        'CMDialogL
        '
        Me.CMDialogL.Title = "CMDialogL"
        '
        '_FM_Panel3D1_2
        '
        Me._FM_Panel3D1_2.Location = New System.Drawing.Point(699, 37)
        Me._FM_Panel3D1_2.Name = "_FM_Panel3D1_2"
        Me._FM_Panel3D1_2.Size = New System.Drawing.Size(84, 21)
        Me._FM_Panel3D1_2.TabIndex = 13
        Me._FM_Panel3D1_2.Text = " 入力担当者"
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MN_Ctrl, Me.MN_EditMn})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(997, 24)
        Me.MainMenu1.TabIndex = 16
        '
        'MN_Ctrl
        '
        Me.MN_Ctrl.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MN_EXECUTE, Me.bar11, Me.MN_EndCm})
        Me.MN_Ctrl.Name = "MN_Ctrl"
        Me.MN_Ctrl.Size = New System.Drawing.Size(60, 20)
        Me.MN_Ctrl.Text = "処理 (&1)"
        '
        'MN_EXECUTE
        '
        Me.MN_EXECUTE.Name = "MN_EXECUTE"
        Me.MN_EXECUTE.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.MN_EXECUTE.Size = New System.Drawing.Size(153, 22)
        Me.MN_EXECUTE.Text = "実行(&R)"
        '
        'bar11
        '
        Me.bar11.Name = "bar11"
        Me.bar11.Size = New System.Drawing.Size(150, 6)
        '
        'MN_EndCm
        '
        Me.MN_EndCm.Name = "MN_EndCm"
        Me.MN_EndCm.Size = New System.Drawing.Size(153, 22)
        Me.MN_EndCm.Text = "終了(&X)"
        '
        'MN_EditMn
        '
        Me.MN_EditMn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MN_APPENDC})
        Me.MN_EditMn.Name = "MN_EditMn"
        Me.MN_EditMn.Size = New System.Drawing.Size(60, 20)
        Me.MN_EditMn.Text = "編集 (&2)"
        '
        'MN_APPENDC
        '
        Me.MN_APPENDC.Name = "MN_APPENDC"
        Me.MN_APPENDC.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.MN_APPENDC.Size = New System.Drawing.Size(187, 22)
        Me.MN_APPENDC.Text = "画面初期化(&S)"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 307)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(997, 22)
        Me.StatusStrip1.TabIndex = 94
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(196, 17)
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(196, 17)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "端末ID"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(196, 17)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Text = "ログインID"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(196, 17)
        Me.ToolStripStatusLabel4.Spring = True
        Me.ToolStripStatusLabel4.Text = "XXXXXXX"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(196, 17)
        Me.ToolStripStatusLabel5.Spring = True
        Me.ToolStripStatusLabel5.Text = "Ver.1.00"
        '
        'btnF12
        '
        Me.btnF12.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF12.Location = New System.Drawing.Point(906, 264)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(75, 35)
        Me.btnF12.TabIndex = 281
        Me.btnF12.Text = "(F12)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'btnF11
        '
        Me.btnF11.Enabled = False
        Me.btnF11.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF11.Location = New System.Drawing.Point(829, 264)
        Me.btnF11.Name = "btnF11"
        Me.btnF11.Size = New System.Drawing.Size(75, 35)
        Me.btnF11.TabIndex = 280
        Me.btnF11.Text = "(F11)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF11.UseVisualStyleBackColor = True
        '
        'btnF10
        '
        Me.btnF10.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF10.Location = New System.Drawing.Point(751, 264)
        Me.btnF10.Name = "btnF10"
        Me.btnF10.Size = New System.Drawing.Size(75, 35)
        Me.btnF10.TabIndex = 279
        Me.btnF10.Text = "(F10)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CSV取込"
        Me.btnF10.UseVisualStyleBackColor = True
        '
        'btnF9
        '
        Me.btnF9.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF9.Location = New System.Drawing.Point(674, 264)
        Me.btnF9.Name = "btnF9"
        Me.btnF9.Size = New System.Drawing.Size(75, 35)
        Me.btnF9.TabIndex = 278
        Me.btnF9.Text = "(F9)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "クリア"
        Me.btnF9.UseVisualStyleBackColor = True
        '
        'btnF8
        '
        Me.btnF8.Enabled = False
        Me.btnF8.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF8.Location = New System.Drawing.Point(580, 264)
        Me.btnF8.Name = "btnF8"
        Me.btnF8.Size = New System.Drawing.Size(75, 35)
        Me.btnF8.TabIndex = 277
        Me.btnF8.Text = "(F8)" & Global.Microsoft.VisualBasic.ChrW(13)
        Me.btnF8.UseVisualStyleBackColor = True
        '
        'btnF7
        '
        Me.btnF7.Enabled = False
        Me.btnF7.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF7.Location = New System.Drawing.Point(502, 264)
        Me.btnF7.Name = "btnF7"
        Me.btnF7.Size = New System.Drawing.Size(75, 35)
        Me.btnF7.TabIndex = 276
        Me.btnF7.Text = "(F7)" & Global.Microsoft.VisualBasic.ChrW(13)
        Me.btnF7.UseVisualStyleBackColor = True
        '
        'btnF6
        '
        Me.btnF6.Enabled = False
        Me.btnF6.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF6.Location = New System.Drawing.Point(424, 264)
        Me.btnF6.Name = "btnF6"
        Me.btnF6.Size = New System.Drawing.Size(75, 35)
        Me.btnF6.TabIndex = 275
        Me.btnF6.Text = "(F6)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF6.UseVisualStyleBackColor = True
        '
        'btnF5
        '
        Me.btnF5.Enabled = False
        Me.btnF5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF5.Location = New System.Drawing.Point(346, 264)
        Me.btnF5.Name = "btnF5"
        Me.btnF5.Size = New System.Drawing.Size(75, 35)
        Me.btnF5.TabIndex = 274
        Me.btnF5.Text = "(F5)" & Global.Microsoft.VisualBasic.ChrW(13)
        Me.btnF5.UseVisualStyleBackColor = True
        '
        'btnF4
        '
        Me.btnF4.Enabled = False
        Me.btnF4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF4.Location = New System.Drawing.Point(252, 264)
        Me.btnF4.Name = "btnF4"
        Me.btnF4.Size = New System.Drawing.Size(75, 35)
        Me.btnF4.TabIndex = 273
        Me.btnF4.Text = "(F4)" & Global.Microsoft.VisualBasic.ChrW(13)
        Me.btnF4.UseVisualStyleBackColor = True
        '
        'btnF3
        '
        Me.btnF3.Enabled = False
        Me.btnF3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF3.Location = New System.Drawing.Point(173, 264)
        Me.btnF3.Name = "btnF3"
        Me.btnF3.Size = New System.Drawing.Size(75, 35)
        Me.btnF3.TabIndex = 272
        Me.btnF3.Text = "(F3)" & Global.Microsoft.VisualBasic.ChrW(13)
        Me.btnF3.UseVisualStyleBackColor = True
        '
        'btnF2
        '
        Me.btnF2.Enabled = False
        Me.btnF2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF2.Location = New System.Drawing.Point(94, 264)
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(75, 35)
        Me.btnF2.TabIndex = 271
        Me.btnF2.Text = "(F2)" & Global.Microsoft.VisualBasic.ChrW(13)
        Me.btnF2.UseVisualStyleBackColor = True
        '
        'btnF1
        '
        Me.btnF1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF1.Location = New System.Drawing.Point(15, 264)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(75, 35)
        Me.btnF1.TabIndex = 270
        Me.btnF1.Text = "(F1)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "更新"
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'FR_SSSMAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(997, 329)
        Me.Controls.Add(Me.SYSDT)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.btnF11)
        Me.Controls.Add(Me.btnF10)
        Me.Controls.Add(Me.btnF9)
        Me.Controls.Add(Me.btnF8)
        Me.Controls.Add(Me.btnF7)
        Me.Controls.Add(Me.btnF6)
        Me.Controls.Add(Me.btnF5)
        Me.Controls.Add(Me.btnF4)
        Me.Controls.Add(Me.btnF3)
        Me.Controls.Add(Me.btnF2)
        Me.Controls.Add(Me.btnF1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Gage)
        Me.Controls.Add(Me.Cmd_cancel)
        Me.Controls.Add(Me.TX_CursorRest)
        Me.Controls.Add(Me.Frame3D1)
        Me.Controls.Add(Me.HD_IN_TANCD)
        Me.Controls.Add(Me.HD_IN_TANNM)
        Me.Controls.Add(Me._FM_Panel3D1_1)
        Me.Controls.Add(Me._FM_Panel3D1_3)
        Me.Controls.Add(Me._FM_Panel3D1_0)
        Me.Controls.Add(Me._FM_Panel3D1_2)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(10, 56)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FR_SSSMAIN"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "商品マスタ一括更新"
        Me.Frame3D1.ResumeLayout(False)
        Me.Frame3D1.PerformLayout()
        Me._FM_Panel3D1_1.ResumeLayout(False)
        CType(Me.CM_Execute, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_EndCm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        Me._FM_Panel3D1_3.ResumeLayout(False)
        Me._FM_Panel3D1_4.ResumeLayout(False)
        Me._FM_Panel3D1_4.PerformLayout()
        CType(Me._IM_Denkyu_0, System.ComponentModel.ISupportInitialize).EndInit()
        Me._FM_Panel3D1_0.ResumeLayout(False)
        Me._FM_Panel3D1_0.PerformLayout()
        CType(Me._IM_EndCm_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_EndCm_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Denkyu_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Denkyu_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Execute_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Execute_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_Denkyu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_EndCm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_Execute, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents btnF12 As Button
    Friend WithEvents btnF11 As Button
    Friend WithEvents btnF10 As Button
    Friend WithEvents btnF9 As Button
    Friend WithEvents btnF8 As Button
    Friend WithEvents btnF7 As Button
    Friend WithEvents btnF6 As Button
    Friend WithEvents btnF5 As Button
    Friend WithEvents btnF4 As Button
    Friend WithEvents btnF3 As Button
    Friend WithEvents btnF2 As Button
    Friend WithEvents btnF1 As Button
#End Region
End Class