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
	Public WithEvents Gage As SSPanel5
	Public WithEvents Cmd_cancel As System.Windows.Forms.Button
	Public WithEvents TX_CursorRest As System.Windows.Forms.TextBox
	Public WithEvents TM_StartUp As System.Windows.Forms.Timer
	Public WithEvents HD_TFPATH_B As System.Windows.Forms.TextBox
	Public WithEvents CS_TFPATH_B As SSCommand5
	Public WithEvents Frame3D1 As System.Windows.Forms.GroupBox
	Public WithEvents HD_IN_TANCD As System.Windows.Forms.TextBox
	Public WithEvents HD_IN_TANNM As System.Windows.Forms.TextBox
	Public WithEvents SYSDT As SSPanel5
	Public WithEvents CM_Execute As System.Windows.Forms.PictureBox
	Public WithEvents CM_EndCm As System.Windows.Forms.PictureBox
	Public WithEvents Image1 As System.Windows.Forms.PictureBox
	Public WithEvents _FM_Panel3D1_1 As SSPanel5
	Public WithEvents TX_Message As System.Windows.Forms.TextBox
	Public WithEvents _FM_Panel3D1_4 As SSPanel5
	Public WithEvents _IM_Denkyu_0 As System.Windows.Forms.PictureBox
	Public WithEvents _FM_Panel3D1_3 As SSPanel5
	Public WithEvents TX_Mode As System.Windows.Forms.TextBox
	Public WithEvents CMDialogL As CommonDialog
	Public WithEvents _IM_EndCm_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_EndCm_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Denkyu_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Denkyu_2 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Execute_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Execute_1 As System.Windows.Forms.PictureBox
	Public WithEvents _FM_Panel3D1_0 As SSPanel5
	Public WithEvents _FM_Panel3D1_2 As SSPanel5
	Public WithEvents FM_Panel3D1 As SSPanel5Array
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
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FR_SSSMAIN))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Gage = New SSPanel5
		Me.Cmd_cancel = New System.Windows.Forms.Button
		Me.TX_CursorRest = New System.Windows.Forms.TextBox
		Me.TM_StartUp = New System.Windows.Forms.Timer(components)
		Me.Frame3D1 = New System.Windows.Forms.GroupBox
		Me.HD_TFPATH_B = New System.Windows.Forms.TextBox
		Me.CS_TFPATH_B = New SSCommand5
		Me.HD_IN_TANCD = New System.Windows.Forms.TextBox
		Me.HD_IN_TANNM = New System.Windows.Forms.TextBox
		Me._FM_Panel3D1_1 = New SSPanel5
		Me.SYSDT = New SSPanel5
		Me.CM_Execute = New System.Windows.Forms.PictureBox
		Me.CM_EndCm = New System.Windows.Forms.PictureBox
		Me.Image1 = New System.Windows.Forms.PictureBox
		Me._FM_Panel3D1_3 = New SSPanel5
		Me._FM_Panel3D1_4 = New SSPanel5
		Me.TX_Message = New System.Windows.Forms.TextBox
		Me._IM_Denkyu_0 = New System.Windows.Forms.PictureBox
		Me._FM_Panel3D1_0 = New SSPanel5
		Me.TX_Mode = New System.Windows.Forms.TextBox
		Me.CMDialogL = New CommonDialog
		Me._IM_EndCm_1 = New System.Windows.Forms.PictureBox
		Me._IM_EndCm_0 = New System.Windows.Forms.PictureBox
		Me._IM_Denkyu_1 = New System.Windows.Forms.PictureBox
		Me._IM_Denkyu_2 = New System.Windows.Forms.PictureBox
		Me._IM_Execute_0 = New System.Windows.Forms.PictureBox
		Me._IM_Execute_1 = New System.Windows.Forms.PictureBox
		Me._FM_Panel3D1_2 = New SSPanel5
		Me.FM_Panel3D1 = New SSPanel5Array(components)
		Me.IM_Denkyu = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_EndCm = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_Execute = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.MainMenu1 = New System.Windows.Forms.MenuStrip
		Me.MN_Ctrl = New System.Windows.Forms.ToolStripMenuItem
		Me.MN_EXECUTE = New System.Windows.Forms.ToolStripMenuItem
		Me.bar11 = New System.Windows.Forms.ToolStripSeparator
		Me.MN_EndCm = New System.Windows.Forms.ToolStripMenuItem
		Me.MN_EditMn = New System.Windows.Forms.ToolStripMenuItem
		Me.MN_APPENDC = New System.Windows.Forms.ToolStripMenuItem
		Me.Frame3D1.SuspendLayout()
		Me._FM_Panel3D1_1.SuspendLayout()
		Me._FM_Panel3D1_3.SuspendLayout()
		Me._FM_Panel3D1_4.SuspendLayout()
		Me._FM_Panel3D1_0.SuspendLayout()
		Me.MainMenu1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_Denkyu, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_EndCm, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_Execute, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "商品マスタ一括更新"
		Me.ClientSize = New System.Drawing.Size(563, 289)
		Me.Location = New System.Drawing.Point(10, 56)
		Me.Icon = CType(resources.GetObject("FR_SSSMAIN.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "FR_SSSMAIN"
		Me.Gage.Size = New System.Drawing.Size(465, 33)
		Me.Gage.Location = New System.Drawing.Point(56, 168)
		Me.Gage.TabIndex = 15
		Me.Gage.BevelOuter = 1
		Me.Gage.Caption = "SSPanel51"
		Me.Gage.FloodType = 1
		Me.Gage.AutoSize = 3
		Me.Gage.Name = "Gage"
		Me.Cmd_cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Cmd_cancel.Text = "中止"
		Me.Cmd_cancel.Size = New System.Drawing.Size(81, 25)
		Me.Cmd_cancel.Location = New System.Drawing.Point(216, 216)
		Me.Cmd_cancel.TabIndex = 14
		Me.Cmd_cancel.BackColor = System.Drawing.SystemColors.Control
		Me.Cmd_cancel.CausesValidation = True
		Me.Cmd_cancel.Enabled = True
		Me.Cmd_cancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Cmd_cancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.Cmd_cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Cmd_cancel.TabStop = True
		Me.Cmd_cancel.Name = "Cmd_cancel"
		Me.TX_CursorRest.AutoSize = False
		Me.TX_CursorRest.Size = New System.Drawing.Size(19, 22)
		Me.TX_CursorRest.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.TX_CursorRest.Location = New System.Drawing.Point(2460, 2457)
		Me.TX_CursorRest.TabIndex = 12
		Me.TX_CursorRest.AcceptsReturn = True
		Me.TX_CursorRest.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TX_CursorRest.BackColor = System.Drawing.SystemColors.Window
		Me.TX_CursorRest.CausesValidation = True
		Me.TX_CursorRest.Enabled = True
		Me.TX_CursorRest.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TX_CursorRest.HideSelection = True
		Me.TX_CursorRest.ReadOnly = False
		Me.TX_CursorRest.Maxlength = 0
		Me.TX_CursorRest.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TX_CursorRest.MultiLine = False
		Me.TX_CursorRest.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TX_CursorRest.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TX_CursorRest.TabStop = True
		Me.TX_CursorRest.Visible = True
		Me.TX_CursorRest.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.TX_CursorRest.Name = "TX_CursorRest"
		Me.TM_StartUp.Enabled = False
		Me.TM_StartUp.Interval = 1
		Me.Frame3D1.Text = "条件指定"
		Me.Frame3D1.ForeColor = System.Drawing.Color.Black
		Me.Frame3D1.Size = New System.Drawing.Size(524, 72)
		Me.Frame3D1.Location = New System.Drawing.Point(19, 81)
		Me.Frame3D1.TabIndex = 7
		Me.Frame3D1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame3D1.Enabled = True
		Me.Frame3D1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame3D1.Visible = True
		Me.Frame3D1.Name = "Frame3D1"
		Me.HD_TFPATH_B.AutoSize = False
		Me.HD_TFPATH_B.BackColor = System.Drawing.SystemColors.Control
		Me.HD_TFPATH_B.Size = New System.Drawing.Size(357, 23)
		Me.HD_TFPATH_B.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_TFPATH_B.Location = New System.Drawing.Point(152, 24)
		Me.HD_TFPATH_B.TabIndex = 8
		Me.HD_TFPATH_B.TabStop = False
		Me.HD_TFPATH_B.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5"
		Me.HD_TFPATH_B.AcceptsReturn = True
		Me.HD_TFPATH_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_TFPATH_B.CausesValidation = True
		Me.HD_TFPATH_B.Enabled = True
		Me.HD_TFPATH_B.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_TFPATH_B.HideSelection = True
		Me.HD_TFPATH_B.ReadOnly = False
		Me.HD_TFPATH_B.Maxlength = 0
		Me.HD_TFPATH_B.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_TFPATH_B.MultiLine = False
		Me.HD_TFPATH_B.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_TFPATH_B.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_TFPATH_B.Visible = True
		Me.HD_TFPATH_B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_TFPATH_B.Name = "HD_TFPATH_B"
		Me.CS_TFPATH_B.Size = New System.Drawing.Size(143, 23)
		Me.CS_TFPATH_B.Location = New System.Drawing.Point(10, 24)
		Me.CS_TFPATH_B.TabIndex = 9
		Me.CS_TFPATH_B.TabStop = 0
		Me.CS_TFPATH_B.ForeColor = 0
		Me.CS_TFPATH_B.Caption = "更新用ファイル名"
		Me.CS_TFPATH_B.BevelWidth = 1
		Me.CS_TFPATH_B.RoundedCorners = 0
		Me.CS_TFPATH_B.Name = "CS_TFPATH_B"
		Me.HD_IN_TANCD.AutoSize = False
		Me.HD_IN_TANCD.BackColor = System.Drawing.SystemColors.Control
		Me.HD_IN_TANCD.Size = New System.Drawing.Size(53, 23)
		Me.HD_IN_TANCD.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_IN_TANCD.Location = New System.Drawing.Point(343, 43)
		Me.HD_IN_TANCD.Maxlength = 10
		Me.HD_IN_TANCD.TabIndex = 1
		Me.HD_IN_TANCD.TabStop = False
		Me.HD_IN_TANCD.Text = "XXXXX6"
		Me.HD_IN_TANCD.AcceptsReturn = True
		Me.HD_IN_TANCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_IN_TANCD.CausesValidation = True
		Me.HD_IN_TANCD.Enabled = True
		Me.HD_IN_TANCD.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_IN_TANCD.HideSelection = True
		Me.HD_IN_TANCD.ReadOnly = False
		Me.HD_IN_TANCD.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_IN_TANCD.MultiLine = False
		Me.HD_IN_TANCD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_IN_TANCD.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_IN_TANCD.Visible = True
		Me.HD_IN_TANCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_IN_TANCD.Name = "HD_IN_TANCD"
		Me.HD_IN_TANNM.AutoSize = False
		Me.HD_IN_TANNM.BackColor = System.Drawing.SystemColors.Control
		Me.HD_IN_TANNM.Size = New System.Drawing.Size(147, 23)
		Me.HD_IN_TANNM.IMEMode = System.Windows.Forms.ImeMode.Hiragana
		Me.HD_IN_TANNM.Location = New System.Drawing.Point(395, 43)
		Me.HD_IN_TANNM.Maxlength = 24
		Me.HD_IN_TANNM.TabIndex = 0
		Me.HD_IN_TANNM.TabStop = False
		Me.HD_IN_TANNM.Text = "MMMMMMMMM1MMMMMMMMM2"
		Me.HD_IN_TANNM.AcceptsReturn = True
		Me.HD_IN_TANNM.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_IN_TANNM.CausesValidation = True
		Me.HD_IN_TANNM.Enabled = True
		Me.HD_IN_TANNM.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_IN_TANNM.HideSelection = True
		Me.HD_IN_TANNM.ReadOnly = False
		Me.HD_IN_TANNM.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_IN_TANNM.MultiLine = False
		Me.HD_IN_TANNM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_IN_TANNM.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_IN_TANNM.Visible = True
		Me.HD_IN_TANNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_IN_TANNM.Name = "HD_IN_TANNM"
		Me._FM_Panel3D1_1.Size = New System.Drawing.Size(565, 37)
		Me._FM_Panel3D1_1.Location = New System.Drawing.Point(0, 0)
		Me._FM_Panel3D1_1.TabIndex = 2
		Me._FM_Panel3D1_1.ForeColor = 0
		Me._FM_Panel3D1_1.OutLine = -1
		Me._FM_Panel3D1_1.Name = "_FM_Panel3D1_1"
		Me.SYSDT.Size = New System.Drawing.Size(94, 19)
		Me.SYSDT.Location = New System.Drawing.Point(447, 9)
		Me.SYSDT.TabIndex = 3
		Me.SYSDT.ForeColor = 0
		Me.SYSDT.BevelOuter = 1
		Me.SYSDT.Caption = "YYYY/MM/DD"
		Me.SYSDT.Name = "SYSDT"
		Me.CM_Execute.Size = New System.Drawing.Size(24, 22)
		Me.CM_Execute.Location = New System.Drawing.Point(40, 6)
		Me.CM_Execute.Image = CType(resources.GetObject("CM_Execute.Image"), System.Drawing.Image)
		Me.CM_Execute.Enabled = True
		Me.CM_Execute.Cursor = System.Windows.Forms.Cursors.Default
		Me.CM_Execute.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.CM_Execute.Visible = True
		Me.CM_Execute.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.CM_Execute.Name = "CM_Execute"
		Me.CM_EndCm.Size = New System.Drawing.Size(24, 22)
		Me.CM_EndCm.Location = New System.Drawing.Point(16, 6)
		Me.CM_EndCm.Image = CType(resources.GetObject("CM_EndCm.Image"), System.Drawing.Image)
		Me.CM_EndCm.Enabled = True
		Me.CM_EndCm.Cursor = System.Windows.Forms.Cursors.Default
		Me.CM_EndCm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.CM_EndCm.Visible = True
		Me.CM_EndCm.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.CM_EndCm.Name = "CM_EndCm"
		Me.Image1.Size = New System.Drawing.Size(413, 34)
		Me.Image1.Location = New System.Drawing.Point(0, 0)
		Me.Image1.Enabled = True
		Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Image1.Visible = True
		Me.Image1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Image1.Name = "Image1"
		Me._FM_Panel3D1_3.Size = New System.Drawing.Size(565, 43)
		Me._FM_Panel3D1_3.Location = New System.Drawing.Point(0, 248)
		Me._FM_Panel3D1_3.TabIndex = 4
		Me._FM_Panel3D1_3.ForeColor = 0
		Me._FM_Panel3D1_3.OutLine = -1
		Me._FM_Panel3D1_3.Name = "_FM_Panel3D1_3"
		Me._FM_Panel3D1_4.Size = New System.Drawing.Size(504, 25)
		Me._FM_Panel3D1_4.Location = New System.Drawing.Point(39, 9)
		Me._FM_Panel3D1_4.TabIndex = 5
		Me._FM_Panel3D1_4.ForeColor = 0
		Me._FM_Panel3D1_4.BevelOuter = 1
		Me._FM_Panel3D1_4.Name = "_FM_Panel3D1_4"
		Me.TX_Message.AutoSize = False
		Me.TX_Message.BackColor = System.Drawing.SystemColors.Control
		Me.TX_Message.ForeColor = System.Drawing.Color.Black
		Me.TX_Message.Size = New System.Drawing.Size(397, 16)
		Me.TX_Message.Location = New System.Drawing.Point(6, 6)
		Me.TX_Message.MultiLine = True
		Me.TX_Message.TabIndex = 6
		Me.TX_Message.TabStop = False
		Me.TX_Message.Text = "エラーやプロンプトのメッセージが出力されるところです。"
		Me.TX_Message.AcceptsReturn = True
		Me.TX_Message.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TX_Message.CausesValidation = True
		Me.TX_Message.Enabled = True
		Me.TX_Message.HideSelection = True
		Me.TX_Message.ReadOnly = False
		Me.TX_Message.Maxlength = 0
		Me.TX_Message.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TX_Message.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TX_Message.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TX_Message.Visible = True
		Me.TX_Message.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.TX_Message.Name = "TX_Message"
		Me._IM_Denkyu_0.Size = New System.Drawing.Size(20, 22)
		Me._IM_Denkyu_0.Location = New System.Drawing.Point(12, 9)
		Me._IM_Denkyu_0.Image = CType(resources.GetObject("_IM_Denkyu_0.Image"), System.Drawing.Image)
		Me._IM_Denkyu_0.Enabled = True
		Me._IM_Denkyu_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_Denkyu_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_Denkyu_0.Visible = True
		Me._IM_Denkyu_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_Denkyu_0.Name = "_IM_Denkyu_0"
		Me._FM_Panel3D1_0.Size = New System.Drawing.Size(553, 94)
		Me._FM_Panel3D1_0.Location = New System.Drawing.Point(3, 296)
		Me._FM_Panel3D1_0.TabIndex = 10
		Me._FM_Panel3D1_0.ForeColor = 0
		Me._FM_Panel3D1_0.OutLine = -1
		Me._FM_Panel3D1_0.Name = "_FM_Panel3D1_0"
		Me.TX_Mode.AutoSize = False
		Me.TX_Mode.BackColor = System.Drawing.Color.FromARGB(255, 192, 255)
		Me.TX_Mode.Size = New System.Drawing.Size(49, 22)
		Me.TX_Mode.Location = New System.Drawing.Point(105, 42)
		Me.TX_Mode.TabIndex = 11
		Me.TX_Mode.Text = "ﾓｰﾄﾞ"
		Me.TX_Mode.AcceptsReturn = True
		Me.TX_Mode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TX_Mode.CausesValidation = True
		Me.TX_Mode.Enabled = True
		Me.TX_Mode.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TX_Mode.HideSelection = True
		Me.TX_Mode.ReadOnly = False
		Me.TX_Mode.Maxlength = 0
		Me.TX_Mode.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TX_Mode.MultiLine = False
		Me.TX_Mode.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TX_Mode.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TX_Mode.TabStop = True
		Me.TX_Mode.Visible = True
		Me.TX_Mode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.TX_Mode.Name = "TX_Mode"
		Me.CMDialogL.Name = "CMDialogL"
		Me._IM_EndCm_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_EndCm_1.Location = New System.Drawing.Point(36, 3)
		Me._IM_EndCm_1.Image = CType(resources.GetObject("_IM_EndCm_1.Image"), System.Drawing.Image)
		Me._IM_EndCm_1.Visible = False
		Me._IM_EndCm_1.Enabled = True
		Me._IM_EndCm_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_EndCm_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_EndCm_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_EndCm_1.Name = "_IM_EndCm_1"
		Me._IM_EndCm_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_EndCm_0.Location = New System.Drawing.Point(12, 3)
		Me._IM_EndCm_0.Image = CType(resources.GetObject("_IM_EndCm_0.Image"), System.Drawing.Image)
		Me._IM_EndCm_0.Visible = False
		Me._IM_EndCm_0.Enabled = True
		Me._IM_EndCm_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_EndCm_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_EndCm_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_EndCm_0.Name = "_IM_EndCm_0"
		Me._IM_Denkyu_1.Size = New System.Drawing.Size(20, 22)
		Me._IM_Denkyu_1.Location = New System.Drawing.Point(135, 33)
		Me._IM_Denkyu_1.Image = CType(resources.GetObject("_IM_Denkyu_1.Image"), System.Drawing.Image)
		Me._IM_Denkyu_1.Enabled = True
		Me._IM_Denkyu_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_Denkyu_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_Denkyu_1.Visible = True
		Me._IM_Denkyu_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_Denkyu_1.Name = "_IM_Denkyu_1"
		Me._IM_Denkyu_2.Size = New System.Drawing.Size(20, 22)
		Me._IM_Denkyu_2.Location = New System.Drawing.Point(162, 33)
		Me._IM_Denkyu_2.Image = CType(resources.GetObject("_IM_Denkyu_2.Image"), System.Drawing.Image)
		Me._IM_Denkyu_2.Enabled = True
		Me._IM_Denkyu_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_Denkyu_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_Denkyu_2.Visible = True
		Me._IM_Denkyu_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_Denkyu_2.Name = "_IM_Denkyu_2"
		Me._IM_Execute_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_Execute_0.Location = New System.Drawing.Point(69, 3)
		Me._IM_Execute_0.Image = CType(resources.GetObject("_IM_Execute_0.Image"), System.Drawing.Image)
		Me._IM_Execute_0.Visible = False
		Me._IM_Execute_0.Enabled = True
		Me._IM_Execute_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_Execute_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_Execute_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_Execute_0.Name = "_IM_Execute_0"
		Me._IM_Execute_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_Execute_1.Location = New System.Drawing.Point(95, 3)
		Me._IM_Execute_1.Image = CType(resources.GetObject("_IM_Execute_1.Image"), System.Drawing.Image)
		Me._IM_Execute_1.Visible = False
		Me._IM_Execute_1.Enabled = True
		Me._IM_Execute_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_Execute_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_Execute_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_Execute_1.Name = "_IM_Execute_1"
		Me._FM_Panel3D1_2.Size = New System.Drawing.Size(84, 23)
		Me._FM_Panel3D1_2.Location = New System.Drawing.Point(260, 43)
		Me._FM_Panel3D1_2.TabIndex = 13
		Me._FM_Panel3D1_2.ForeColor = 0
		Me._FM_Panel3D1_2.Alignment = 1
		Me._FM_Panel3D1_2.BevelOuter = 1
		Me._FM_Panel3D1_2.Caption = " 入力担当者"
		Me._FM_Panel3D1_2.OutLine = -1
		Me._FM_Panel3D1_2.Name = "_FM_Panel3D1_2"
		Me.MN_Ctrl.Name = "MN_Ctrl"
		Me.MN_Ctrl.Text = "処理 (&1)"
		Me.MN_Ctrl.Checked = False
		Me.MN_Ctrl.Enabled = True
		Me.MN_Ctrl.Visible = True
		Me.MN_EXECUTE.Name = "MN_EXECUTE"
		Me.MN_EXECUTE.Text = "実行(&R)"
		Me.MN_EXECUTE.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.R, System.Windows.Forms.Keys)
		Me.MN_EXECUTE.Checked = False
		Me.MN_EXECUTE.Enabled = True
		Me.MN_EXECUTE.Visible = True
		Me.bar11.Enabled = True
		Me.bar11.Visible = True
		Me.bar11.Name = "bar11"
		Me.MN_EndCm.Name = "MN_EndCm"
		Me.MN_EndCm.Text = "終了(&X)"
		Me.MN_EndCm.Checked = False
		Me.MN_EndCm.Enabled = True
		Me.MN_EndCm.Visible = True
		Me.MN_EditMn.Name = "MN_EditMn"
		Me.MN_EditMn.Text = "編集 (&2)"
		Me.MN_EditMn.Checked = False
		Me.MN_EditMn.Enabled = True
		Me.MN_EditMn.Visible = True
		Me.MN_APPENDC.Name = "MN_APPENDC"
		Me.MN_APPENDC.Text = "画面初期化(&S)"
		Me.MN_APPENDC.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.S, System.Windows.Forms.Keys)
		Me.MN_APPENDC.Checked = False
		Me.MN_APPENDC.Enabled = True
		Me.MN_APPENDC.Visible = True
		Me.Controls.Add(Gage)
		Me.Controls.Add(Cmd_cancel)
		Me.Controls.Add(TX_CursorRest)
		Me.Controls.Add(Frame3D1)
		Me.Controls.Add(HD_IN_TANCD)
		Me.Controls.Add(HD_IN_TANNM)
		Me.Controls.Add(_FM_Panel3D1_1)
		Me.Controls.Add(_FM_Panel3D1_3)
		Me.Controls.Add(_FM_Panel3D1_0)
		Me.Controls.Add(_FM_Panel3D1_2)
		Me.Frame3D1.Controls.Add(HD_TFPATH_B)
		Me.Frame3D1.Controls.Add(CS_TFPATH_B)
		Me._FM_Panel3D1_1.Controls.Add(SYSDT)
		Me._FM_Panel3D1_1.Controls.Add(CM_Execute)
		Me._FM_Panel3D1_1.Controls.Add(CM_EndCm)
		Me._FM_Panel3D1_1.Controls.Add(Image1)
		Me._FM_Panel3D1_3.Controls.Add(_FM_Panel3D1_4)
		Me._FM_Panel3D1_3.Controls.Add(_IM_Denkyu_0)
		Me._FM_Panel3D1_4.Controls.Add(TX_Message)
		Me._FM_Panel3D1_0.Controls.Add(TX_Mode)
		Me._FM_Panel3D1_0.Controls.Add(CMDialogL)
		Me._FM_Panel3D1_0.Controls.Add(_IM_EndCm_1)
		Me._FM_Panel3D1_0.Controls.Add(_IM_EndCm_0)
		Me._FM_Panel3D1_0.Controls.Add(_IM_Denkyu_1)
		Me._FM_Panel3D1_0.Controls.Add(_IM_Denkyu_2)
		Me._FM_Panel3D1_0.Controls.Add(_IM_Execute_0)
		Me._FM_Panel3D1_0.Controls.Add(_IM_Execute_1)
		Me.FM_Panel3D1.SetIndex(_FM_Panel3D1_1, CType(1, Short))
		Me.FM_Panel3D1.SetIndex(_FM_Panel3D1_4, CType(4, Short))
		Me.FM_Panel3D1.SetIndex(_FM_Panel3D1_3, CType(3, Short))
		Me.FM_Panel3D1.SetIndex(_FM_Panel3D1_0, CType(0, Short))
		Me.FM_Panel3D1.SetIndex(_FM_Panel3D1_2, CType(2, Short))
		Me.IM_Denkyu.SetIndex(_IM_Denkyu_0, CType(0, Short))
		Me.IM_Denkyu.SetIndex(_IM_Denkyu_1, CType(1, Short))
		Me.IM_Denkyu.SetIndex(_IM_Denkyu_2, CType(2, Short))
		Me.IM_EndCm.SetIndex(_IM_EndCm_1, CType(1, Short))
		Me.IM_EndCm.SetIndex(_IM_EndCm_0, CType(0, Short))
		Me.IM_Execute.SetIndex(_IM_Execute_0, CType(0, Short))
		Me.IM_Execute.SetIndex(_IM_Execute_1, CType(1, Short))
		CType(Me.IM_Execute, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_EndCm, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_Denkyu, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).EndInit()
		MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me.MN_Ctrl, Me.MN_EditMn})
		MN_Ctrl.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.MN_EXECUTE, Me.bar11, Me.MN_EndCm})
		MN_EditMn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.MN_APPENDC})
		Me.Controls.Add(MainMenu1)
		Me.Frame3D1.ResumeLayout(False)
		Me._FM_Panel3D1_1.ResumeLayout(False)
		Me._FM_Panel3D1_3.ResumeLayout(False)
		Me._FM_Panel3D1_4.ResumeLayout(False)
		Me._FM_Panel3D1_0.ResumeLayout(False)
		Me.MainMenu1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class