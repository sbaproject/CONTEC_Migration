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
	Public WithEvents HD_OPENM As System.Windows.Forms.TextBox
	Public WithEvents HD_OPEID As System.Windows.Forms.TextBox
	Public WithEvents HD_ENDNHSNM As System.Windows.Forms.TextBox
	Public WithEvents HD_STTNHSNM As System.Windows.Forms.TextBox
	Public WithEvents HD_ENDNHSCD As System.Windows.Forms.TextBox
	Public WithEvents HD_STTNHSCD As System.Windows.Forms.TextBox
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame3D1 As System.Windows.Forms.GroupBox
	Public WithEvents TX_Mode As System.Windows.Forms.TextBox
	Public WithEvents CMDialogL As CommonDialog
	Public WithEvents _IM_LSTART_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Slist_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_EndCm_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_EndCm_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Slist_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_LSTART_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_VSTART_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_VSTART_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_FSTART_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_FSTART_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_LCONFIG_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_LCONFIG_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Denkyu_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Denkyu_2 As System.Windows.Forms.PictureBox
    Public WithEvents FM_Panel3D1 As Label
    Public WithEvents SYSDT As Label
    Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents CM_SLIST As System.Windows.Forms.PictureBox
	Public WithEvents CM_EndCm As System.Windows.Forms.PictureBox
	Public WithEvents CM_LSTART As System.Windows.Forms.PictureBox
	Public WithEvents CM_LCONFIG As System.Windows.Forms.PictureBox
	Public WithEvents CM_VSTART As System.Windows.Forms.PictureBox
	Public WithEvents CM_FSTART As System.Windows.Forms.PictureBox
	Public WithEvents Image1 As System.Windows.Forms.PictureBox
    Public WithEvents FM_Panel3D14 As Label
    Public WithEvents TM_StartUp As System.Windows.Forms.Timer
	Public WithEvents TX_CursorRest As System.Windows.Forms.TextBox
	Public WithEvents TX_Message As System.Windows.Forms.TextBox
    Public WithEvents _FM_Panel3D2_2 As Label
    Public WithEvents _IM_Denkyu_0 As System.Windows.Forms.PictureBox
    Public WithEvents _FM_Panel3D15_0 As Label
    Public WithEvents GAUGE As Label
    Public WithEvents CM_LCANCEL As Button
    Public WithEvents _FM_Panel3D4_4 As Label
    Public WithEvents FM_Panel3D15 As VB6.PanelArray
    Public WithEvents FM_Panel3D2 As VB6.PanelArray
    Public WithEvents FM_Panel3D4 As VB6.PanelArray
    Public WithEvents IM_Denkyu As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_EndCm As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_FSTART As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_LCONFIG As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_LSTART As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_Slist As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_VSTART As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents MN_LSTART As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_VSTART As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_FSTART As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_LCONFIG As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents bar11 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents MN_EndCm As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_Ctrl As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_APPENDC As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_ClearItm As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_UnDoItem As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Bar21 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents MN_Cut As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_Copy As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_Paste As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_EditMn As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_Slist As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_Oprt As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents SM_AllCopy As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents SM_FullPast As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents SM_Esc As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents SM_ShortCut As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FR_SSSMAIN))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.HD_OPENM = New System.Windows.Forms.TextBox
		Me.HD_OPEID = New System.Windows.Forms.TextBox
		Me.Frame3D1 = New System.Windows.Forms.GroupBox
		Me.HD_ENDNHSNM = New System.Windows.Forms.TextBox
		Me.HD_STTNHSNM = New System.Windows.Forms.TextBox
		Me.HD_ENDNHSCD = New System.Windows.Forms.TextBox
		Me.HD_STTNHSCD = New System.Windows.Forms.TextBox
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
        Me.FM_Panel3D1 = New Label
        Me.TX_Mode = New System.Windows.Forms.TextBox
        '2019/10/14 DEL START
        'Me.CMDialogL = New CommonDialog
        '2019/10/14 DEL E N D
        Me._IM_LSTART_0 = New System.Windows.Forms.PictureBox
		Me._IM_Slist_0 = New System.Windows.Forms.PictureBox
		Me._IM_EndCm_1 = New System.Windows.Forms.PictureBox
		Me._IM_EndCm_0 = New System.Windows.Forms.PictureBox
		Me._IM_Slist_1 = New System.Windows.Forms.PictureBox
		Me._IM_LSTART_1 = New System.Windows.Forms.PictureBox
		Me._IM_VSTART_0 = New System.Windows.Forms.PictureBox
		Me._IM_VSTART_1 = New System.Windows.Forms.PictureBox
		Me._IM_FSTART_0 = New System.Windows.Forms.PictureBox
		Me._IM_FSTART_1 = New System.Windows.Forms.PictureBox
		Me._IM_LCONFIG_0 = New System.Windows.Forms.PictureBox
		Me._IM_LCONFIG_1 = New System.Windows.Forms.PictureBox
		Me._IM_Denkyu_1 = New System.Windows.Forms.PictureBox
		Me._IM_Denkyu_2 = New System.Windows.Forms.PictureBox
        Me.FM_Panel3D14 = New Label
        Me.SYSDT = New Label
        Me.Label3 = New System.Windows.Forms.Label
		Me.CM_SLIST = New System.Windows.Forms.PictureBox
		Me.CM_EndCm = New System.Windows.Forms.PictureBox
		Me.CM_LSTART = New System.Windows.Forms.PictureBox
		Me.CM_LCONFIG = New System.Windows.Forms.PictureBox
		Me.CM_VSTART = New System.Windows.Forms.PictureBox
		Me.CM_FSTART = New System.Windows.Forms.PictureBox
		Me.Image1 = New System.Windows.Forms.PictureBox
		Me.TM_StartUp = New System.Windows.Forms.Timer(components)
		Me.TX_CursorRest = New System.Windows.Forms.TextBox
        Me._FM_Panel3D15_0 = New Label
        Me._FM_Panel3D2_2 = New Label
        Me.TX_Message = New System.Windows.Forms.TextBox
		Me._IM_Denkyu_0 = New System.Windows.Forms.PictureBox
        Me.GAUGE = New Label
        Me.CM_LCANCEL = New Button
        Me._FM_Panel3D4_4 = New Label
        Me.FM_Panel3D15 = New VB6.PanelArray(components)
        Me.FM_Panel3D2 = New VB6.PanelArray(components)
        Me.FM_Panel3D4 = New VB6.PanelArray(components)
        Me.IM_Denkyu = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_EndCm = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_FSTART = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_LCONFIG = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_LSTART = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_Slist = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_VSTART = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.MainMenu1 = New System.Windows.Forms.MenuStrip
		Me.MN_Ctrl = New System.Windows.Forms.ToolStripMenuItem
		Me.MN_LSTART = New System.Windows.Forms.ToolStripMenuItem
		Me.MN_VSTART = New System.Windows.Forms.ToolStripMenuItem
		Me.MN_FSTART = New System.Windows.Forms.ToolStripMenuItem
		Me.MN_LCONFIG = New System.Windows.Forms.ToolStripMenuItem
		Me.bar11 = New System.Windows.Forms.ToolStripSeparator
		Me.MN_EndCm = New System.Windows.Forms.ToolStripMenuItem
		Me.MN_EditMn = New System.Windows.Forms.ToolStripMenuItem
		Me.MN_APPENDC = New System.Windows.Forms.ToolStripMenuItem
		Me.MN_ClearItm = New System.Windows.Forms.ToolStripMenuItem
		Me.MN_UnDoItem = New System.Windows.Forms.ToolStripMenuItem
		Me.Bar21 = New System.Windows.Forms.ToolStripSeparator
		Me.MN_Cut = New System.Windows.Forms.ToolStripMenuItem
		Me.MN_Copy = New System.Windows.Forms.ToolStripMenuItem
		Me.MN_Paste = New System.Windows.Forms.ToolStripMenuItem
		Me.MN_Oprt = New System.Windows.Forms.ToolStripMenuItem
		Me.MN_Slist = New System.Windows.Forms.ToolStripMenuItem
		Me.SM_ShortCut = New System.Windows.Forms.ToolStripMenuItem
		Me.SM_AllCopy = New System.Windows.Forms.ToolStripMenuItem
		Me.SM_FullPast = New System.Windows.Forms.ToolStripMenuItem
		Me.SM_Esc = New System.Windows.Forms.ToolStripMenuItem
		Me.Frame3D1.SuspendLayout()
		Me.FM_Panel3D1.SuspendLayout()
		Me.FM_Panel3D14.SuspendLayout()
		Me._FM_Panel3D15_0.SuspendLayout()
		Me._FM_Panel3D2_2.SuspendLayout()
		Me.MainMenu1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.FM_Panel3D15, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.FM_Panel3D2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.FM_Panel3D4, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_Denkyu, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_EndCm, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_FSTART, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_LCONFIG, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_LSTART, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_Slist, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_VSTART, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "納入先一覧マスタリスト"
		Me.ClientSize = New System.Drawing.Size(575, 369)
		Me.Location = New System.Drawing.Point(129, 264)
		Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.ForeColor = System.Drawing.SystemColors.WindowText
		Me.MaximizeBox = False
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "FR_SSSMAIN"
		Me.HD_OPENM.AutoSize = False
		Me.HD_OPENM.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_OPENM.Font = VB6.FontChangeName(Me.HD_OPENM.Font, "ＭＳ ゴシック")
		Me.HD_OPENM.Size = New System.Drawing.Size(151, 22)
		Me.HD_OPENM.IMEMode = System.Windows.Forms.ImeMode.Hiragana
		Me.HD_OPENM.Location = New System.Drawing.Point(396, 48)
		Me.HD_OPENM.Maxlength = 24
		Me.HD_OPENM.TabIndex = 17
		Me.HD_OPENM.Text = "MMMMMMMMM1MMMMMMMMM2"
		Me.HD_OPENM.AcceptsReturn = True
		Me.HD_OPENM.BackColor = System.Drawing.SystemColors.Window
		Me.HD_OPENM.CausesValidation = True
		Me.HD_OPENM.Enabled = True
		Me.HD_OPENM.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_OPENM.HideSelection = True
		Me.HD_OPENM.ReadOnly = False
		Me.HD_OPENM.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_OPENM.MultiLine = False
		Me.HD_OPENM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_OPENM.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_OPENM.TabStop = True
		Me.HD_OPENM.Visible = True
		Me.HD_OPENM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_OPENM.Name = "HD_OPENM"
		Me.HD_OPEID.AutoSize = False
		Me.HD_OPEID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_OPEID.Font = VB6.FontChangeName(Me.HD_OPEID.Font, "ＭＳ ゴシック")
		Me.HD_OPEID.Size = New System.Drawing.Size(47, 22)
		Me.HD_OPEID.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_OPEID.Location = New System.Drawing.Point(350, 48)
		Me.HD_OPEID.Maxlength = 10
		Me.HD_OPEID.TabIndex = 16
		Me.HD_OPEID.Text = "XXXXX6"
		Me.HD_OPEID.AcceptsReturn = True
		Me.HD_OPEID.BackColor = System.Drawing.SystemColors.Window
		Me.HD_OPEID.CausesValidation = True
		Me.HD_OPEID.Enabled = True
		Me.HD_OPEID.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_OPEID.HideSelection = True
		Me.HD_OPEID.ReadOnly = False
		Me.HD_OPEID.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_OPEID.MultiLine = False
		Me.HD_OPEID.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_OPEID.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_OPEID.TabStop = True
		Me.HD_OPEID.Visible = True
		Me.HD_OPEID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_OPEID.Name = "HD_OPEID"
		Me.Frame3D1.Text = "条件指定"
		Me.Frame3D1.ForeColor = System.Drawing.Color.Black
		Me.Frame3D1.Size = New System.Drawing.Size(523, 119)
		Me.Frame3D1.Location = New System.Drawing.Point(24, 104)
		Me.Frame3D1.TabIndex = 5
		Me.Frame3D1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame3D1.Enabled = True
		Me.Frame3D1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame3D1.Visible = True
		Me.Frame3D1.Name = "Frame3D1"
		Me.HD_ENDNHSNM.AutoSize = False
		Me.HD_ENDNHSNM.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_ENDNHSNM.Font = VB6.FontChangeName(Me.HD_ENDNHSNM.Font, "ＭＳ ゴシック")
		Me.HD_ENDNHSNM.Size = New System.Drawing.Size(289, 19)
		Me.HD_ENDNHSNM.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_ENDNHSNM.Location = New System.Drawing.Point(184, 64)
		Me.HD_ENDNHSNM.Maxlength = 44
		Me.HD_ENDNHSNM.TabIndex = 20
		Me.HD_ENDNHSNM.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
		Me.HD_ENDNHSNM.AcceptsReturn = True
		Me.HD_ENDNHSNM.BackColor = System.Drawing.SystemColors.Window
		Me.HD_ENDNHSNM.CausesValidation = True
		Me.HD_ENDNHSNM.Enabled = True
		Me.HD_ENDNHSNM.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_ENDNHSNM.HideSelection = True
		Me.HD_ENDNHSNM.ReadOnly = False
		Me.HD_ENDNHSNM.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_ENDNHSNM.MultiLine = False
		Me.HD_ENDNHSNM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_ENDNHSNM.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_ENDNHSNM.TabStop = True
		Me.HD_ENDNHSNM.Visible = True
		Me.HD_ENDNHSNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_ENDNHSNM.Name = "HD_ENDNHSNM"
		Me.HD_STTNHSNM.AutoSize = False
		Me.HD_STTNHSNM.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_STTNHSNM.Font = VB6.FontChangeName(Me.HD_STTNHSNM.Font, "ＭＳ ゴシック")
		Me.HD_STTNHSNM.Size = New System.Drawing.Size(289, 19)
		Me.HD_STTNHSNM.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_STTNHSNM.Location = New System.Drawing.Point(184, 32)
		Me.HD_STTNHSNM.Maxlength = 44
		Me.HD_STTNHSNM.TabIndex = 19
		Me.HD_STTNHSNM.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
		Me.HD_STTNHSNM.AcceptsReturn = True
		Me.HD_STTNHSNM.BackColor = System.Drawing.SystemColors.Window
		Me.HD_STTNHSNM.CausesValidation = True
		Me.HD_STTNHSNM.Enabled = True
		Me.HD_STTNHSNM.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_STTNHSNM.HideSelection = True
		Me.HD_STTNHSNM.ReadOnly = False
		Me.HD_STTNHSNM.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_STTNHSNM.MultiLine = False
		Me.HD_STTNHSNM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_STTNHSNM.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_STTNHSNM.TabStop = True
		Me.HD_STTNHSNM.Visible = True
		Me.HD_STTNHSNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_STTNHSNM.Name = "HD_STTNHSNM"
		Me.HD_ENDNHSCD.AutoSize = False
		Me.HD_ENDNHSCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_ENDNHSCD.BackColor = System.Drawing.Color.White
		Me.HD_ENDNHSCD.Font = VB6.FontChangeName(Me.HD_ENDNHSCD.Font, "ＭＳ ゴシック")
		Me.HD_ENDNHSCD.Size = New System.Drawing.Size(76, 19)
		Me.HD_ENDNHSCD.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_ENDNHSCD.Location = New System.Drawing.Point(112, 64)
		Me.HD_ENDNHSCD.Maxlength = 13
		Me.HD_ENDNHSCD.TabIndex = 7
		Me.HD_ENDNHSCD.Text = "XXXXXXXX9"
		Me.HD_ENDNHSCD.AcceptsReturn = True
		Me.HD_ENDNHSCD.CausesValidation = True
		Me.HD_ENDNHSCD.Enabled = True
		Me.HD_ENDNHSCD.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_ENDNHSCD.HideSelection = True
		Me.HD_ENDNHSCD.ReadOnly = False
		Me.HD_ENDNHSCD.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_ENDNHSCD.MultiLine = False
		Me.HD_ENDNHSCD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_ENDNHSCD.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_ENDNHSCD.TabStop = True
		Me.HD_ENDNHSCD.Visible = True
		Me.HD_ENDNHSCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_ENDNHSCD.Name = "HD_ENDNHSCD"
		Me.HD_STTNHSCD.AutoSize = False
		Me.HD_STTNHSCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_STTNHSCD.BackColor = System.Drawing.Color.White
		Me.HD_STTNHSCD.Font = VB6.FontChangeName(Me.HD_STTNHSCD.Font, "ＭＳ ゴシック")
		Me.HD_STTNHSCD.Size = New System.Drawing.Size(76, 19)
		Me.HD_STTNHSCD.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_STTNHSCD.Location = New System.Drawing.Point(112, 32)
		Me.HD_STTNHSCD.Maxlength = 13
		Me.HD_STTNHSCD.TabIndex = 6
		Me.HD_STTNHSCD.Text = "XXXXXXXX9"
		Me.HD_STTNHSCD.AcceptsReturn = True
		Me.HD_STTNHSCD.CausesValidation = True
		Me.HD_STTNHSCD.Enabled = True
		Me.HD_STTNHSCD.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_STTNHSCD.HideSelection = True
		Me.HD_STTNHSCD.ReadOnly = False
		Me.HD_STTNHSCD.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_STTNHSCD.MultiLine = False
		Me.HD_STTNHSCD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_STTNHSCD.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_STTNHSCD.TabStop = True
		Me.HD_STTNHSCD.Visible = True
		Me.HD_STTNHSCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_STTNHSCD.Name = "HD_STTNHSCD"
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Text = "納入先"
		Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Label2.Size = New System.Drawing.Size(44, 25)
		Me.Label2.Location = New System.Drawing.Point(49, 36)
		Me.Label2.TabIndex = 9
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.Enabled = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "～"
		Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Label1.Size = New System.Drawing.Size(25, 25)
		Me.Label1.Location = New System.Drawing.Point(96, 64)
		Me.Label1.TabIndex = 8
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.FM_Panel3D1.Size = New System.Drawing.Size(553, 94)
		Me.FM_Panel3D1.Location = New System.Drawing.Point(18, 384)
		Me.FM_Panel3D1.TabIndex = 3
        Me.FM_Panel3D1.ForeColor = Color.Empty
        'Me.FM_Panel3D1.OutLine = -1
        Me.FM_Panel3D1.Name = "FM_Panel3D1"
		Me.TX_Mode.AutoSize = False
		Me.TX_Mode.BackColor = System.Drawing.Color.FromARGB(255, 192, 255)
		Me.TX_Mode.Size = New System.Drawing.Size(49, 22)
		Me.TX_Mode.Location = New System.Drawing.Point(105, 42)
		Me.TX_Mode.TabIndex = 4
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
        'Me.CMDialogL.Name = "CMDialogL"
        Me._IM_LSTART_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_LSTART_0.Location = New System.Drawing.Point(123, 3)
		Me._IM_LSTART_0.Image = CType(resources.GetObject("_IM_LSTART_0.Image"), System.Drawing.Image)
		Me._IM_LSTART_0.Visible = False
		Me._IM_LSTART_0.Enabled = True
		Me._IM_LSTART_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_LSTART_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_LSTART_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_LSTART_0.Name = "_IM_LSTART_0"
		Me._IM_Slist_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_Slist_0.Location = New System.Drawing.Point(66, 3)
		Me._IM_Slist_0.Image = CType(resources.GetObject("_IM_Slist_0.Image"), System.Drawing.Image)
		Me._IM_Slist_0.Visible = False
		Me._IM_Slist_0.Enabled = True
		Me._IM_Slist_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_Slist_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_Slist_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_Slist_0.Name = "_IM_Slist_0"
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
		Me._IM_Slist_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_Slist_1.Location = New System.Drawing.Point(93, 3)
		Me._IM_Slist_1.Image = CType(resources.GetObject("_IM_Slist_1.Image"), System.Drawing.Image)
		Me._IM_Slist_1.Visible = False
		Me._IM_Slist_1.Enabled = True
		Me._IM_Slist_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_Slist_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_Slist_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_Slist_1.Name = "_IM_Slist_1"
		Me._IM_LSTART_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_LSTART_1.Location = New System.Drawing.Point(144, 3)
		Me._IM_LSTART_1.Image = CType(resources.GetObject("_IM_LSTART_1.Image"), System.Drawing.Image)
		Me._IM_LSTART_1.Visible = False
		Me._IM_LSTART_1.Enabled = True
		Me._IM_LSTART_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_LSTART_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_LSTART_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_LSTART_1.Name = "_IM_LSTART_1"
		Me._IM_VSTART_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_VSTART_0.Location = New System.Drawing.Point(168, 3)
		Me._IM_VSTART_0.Image = CType(resources.GetObject("_IM_VSTART_0.Image"), System.Drawing.Image)
		Me._IM_VSTART_0.Enabled = True
		Me._IM_VSTART_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_VSTART_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_VSTART_0.Visible = True
		Me._IM_VSTART_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_VSTART_0.Name = "_IM_VSTART_0"
		Me._IM_VSTART_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_VSTART_1.Location = New System.Drawing.Point(192, 3)
		Me._IM_VSTART_1.Image = CType(resources.GetObject("_IM_VSTART_1.Image"), System.Drawing.Image)
		Me._IM_VSTART_1.Enabled = True
		Me._IM_VSTART_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_VSTART_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_VSTART_1.Visible = True
		Me._IM_VSTART_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_VSTART_1.Name = "_IM_VSTART_1"
		Me._IM_FSTART_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_FSTART_0.Location = New System.Drawing.Point(216, 3)
		Me._IM_FSTART_0.Image = CType(resources.GetObject("_IM_FSTART_0.Image"), System.Drawing.Image)
		Me._IM_FSTART_0.Enabled = True
		Me._IM_FSTART_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_FSTART_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_FSTART_0.Visible = True
		Me._IM_FSTART_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_FSTART_0.Name = "_IM_FSTART_0"
		Me._IM_FSTART_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_FSTART_1.Location = New System.Drawing.Point(240, 3)
		Me._IM_FSTART_1.Image = CType(resources.GetObject("_IM_FSTART_1.Image"), System.Drawing.Image)
		Me._IM_FSTART_1.Enabled = True
		Me._IM_FSTART_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_FSTART_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_FSTART_1.Visible = True
		Me._IM_FSTART_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_FSTART_1.Name = "_IM_FSTART_1"
		Me._IM_LCONFIG_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_LCONFIG_0.Location = New System.Drawing.Point(264, 3)
		Me._IM_LCONFIG_0.Image = CType(resources.GetObject("_IM_LCONFIG_0.Image"), System.Drawing.Image)
		Me._IM_LCONFIG_0.Enabled = True
		Me._IM_LCONFIG_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_LCONFIG_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_LCONFIG_0.Visible = True
		Me._IM_LCONFIG_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_LCONFIG_0.Name = "_IM_LCONFIG_0"
		Me._IM_LCONFIG_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_LCONFIG_1.Location = New System.Drawing.Point(288, 3)
		Me._IM_LCONFIG_1.Image = CType(resources.GetObject("_IM_LCONFIG_1.Image"), System.Drawing.Image)
		Me._IM_LCONFIG_1.Enabled = True
		Me._IM_LCONFIG_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_LCONFIG_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_LCONFIG_1.Visible = True
		Me._IM_LCONFIG_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_LCONFIG_1.Name = "_IM_LCONFIG_1"
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
		Me.FM_Panel3D14.Size = New System.Drawing.Size(580, 37)
		Me.FM_Panel3D14.Location = New System.Drawing.Point(-3, 0)
		Me.FM_Panel3D14.TabIndex = 1
        Me.FM_Panel3D14.ForeColor = Color.Empty
        'Me.FM_Panel3D14.OutLine = -1
        Me.FM_Panel3D14.Name = "FM_Panel3D14"
		Me.SYSDT.Size = New System.Drawing.Size(94, 19)
		Me.SYSDT.Location = New System.Drawing.Point(438, 9)
		Me.SYSDT.TabIndex = 2
        Me.SYSDT.ForeColor = Color.Empty
        'Me.SYSDT.BevelOuter = 1
        Me.SYSDT.Text = "YYYY/MM/DD"
        Me.SYSDT.Name = "SYSDT"
		Me.Label3.Text = "　"
		Me.Label3.Size = New System.Drawing.Size(57, 33)
		Me.Label3.Location = New System.Drawing.Point(312, 0)
		Me.Label3.TabIndex = 15
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.CM_SLIST.Size = New System.Drawing.Size(24, 22)
		Me.CM_SLIST.Location = New System.Drawing.Point(112, 6)
		Me.CM_SLIST.Image = CType(resources.GetObject("CM_SLIST.Image"), System.Drawing.Image)
		Me.CM_SLIST.Enabled = True
		Me.CM_SLIST.Cursor = System.Windows.Forms.Cursors.Default
		Me.CM_SLIST.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.CM_SLIST.Visible = True
		Me.CM_SLIST.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.CM_SLIST.Name = "CM_SLIST"
		Me.CM_EndCm.Size = New System.Drawing.Size(24, 22)
		Me.CM_EndCm.Location = New System.Drawing.Point(15, 6)
		Me.CM_EndCm.Image = CType(resources.GetObject("CM_EndCm.Image"), System.Drawing.Image)
		Me.CM_EndCm.Enabled = True
		Me.CM_EndCm.Cursor = System.Windows.Forms.Cursors.Default
		Me.CM_EndCm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.CM_EndCm.Visible = True
		Me.CM_EndCm.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.CM_EndCm.Name = "CM_EndCm"
		Me.CM_LSTART.Size = New System.Drawing.Size(24, 22)
		Me.CM_LSTART.Location = New System.Drawing.Point(39, 6)
		Me.CM_LSTART.Image = CType(resources.GetObject("CM_LSTART.Image"), System.Drawing.Image)
		Me.CM_LSTART.Enabled = True
		Me.CM_LSTART.Cursor = System.Windows.Forms.Cursors.Default
		Me.CM_LSTART.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.CM_LSTART.Visible = True
		Me.CM_LSTART.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.CM_LSTART.Name = "CM_LSTART"
		Me.CM_LCONFIG.Size = New System.Drawing.Size(24, 22)
		Me.CM_LCONFIG.Location = New System.Drawing.Point(88, 6)
		Me.CM_LCONFIG.Image = CType(resources.GetObject("CM_LCONFIG.Image"), System.Drawing.Image)
		Me.CM_LCONFIG.Enabled = True
		Me.CM_LCONFIG.Cursor = System.Windows.Forms.Cursors.Default
		Me.CM_LCONFIG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.CM_LCONFIG.Visible = True
		Me.CM_LCONFIG.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.CM_LCONFIG.Name = "CM_LCONFIG"
		Me.CM_VSTART.Size = New System.Drawing.Size(24, 22)
		Me.CM_VSTART.Location = New System.Drawing.Point(63, 6)
		Me.CM_VSTART.Image = CType(resources.GetObject("CM_VSTART.Image"), System.Drawing.Image)
		Me.CM_VSTART.Enabled = True
		Me.CM_VSTART.Cursor = System.Windows.Forms.Cursors.Default
		Me.CM_VSTART.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.CM_VSTART.Visible = True
		Me.CM_VSTART.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.CM_VSTART.Name = "CM_VSTART"
		Me.CM_FSTART.Size = New System.Drawing.Size(24, 22)
		Me.CM_FSTART.Location = New System.Drawing.Point(328, 6)
		Me.CM_FSTART.Image = CType(resources.GetObject("CM_FSTART.Image"), System.Drawing.Image)
		Me.CM_FSTART.Enabled = True
		Me.CM_FSTART.Cursor = System.Windows.Forms.Cursors.Default
		Me.CM_FSTART.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.CM_FSTART.Visible = True
		Me.CM_FSTART.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.CM_FSTART.Name = "CM_FSTART"
		Me.Image1.Size = New System.Drawing.Size(301, 34)
		Me.Image1.Location = New System.Drawing.Point(0, 0)
		Me.Image1.Enabled = True
		Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Image1.Visible = True
		Me.Image1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Image1.Name = "Image1"
		Me.TM_StartUp.Enabled = False
		Me.TM_StartUp.Interval = 1
		Me.TX_CursorRest.AutoSize = False
		Me.TX_CursorRest.Size = New System.Drawing.Size(19, 22)
		Me.TX_CursorRest.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.TX_CursorRest.Location = New System.Drawing.Point(2457, 2457)
		Me.TX_CursorRest.TabIndex = 0
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
		Me._FM_Panel3D15_0.Size = New System.Drawing.Size(580, 43)
		Me._FM_Panel3D15_0.Location = New System.Drawing.Point(-3, 330)
		Me._FM_Panel3D15_0.TabIndex = 10
        Me._FM_Panel3D15_0.ForeColor = Color.Empty
        'Me._FM_Panel3D15_0.OutLine = -1
        Me._FM_Panel3D15_0.Name = "_FM_Panel3D15_0"
		Me._FM_Panel3D2_2.Size = New System.Drawing.Size(526, 25)
		Me._FM_Panel3D2_2.Location = New System.Drawing.Point(39, 9)
		Me._FM_Panel3D2_2.TabIndex = 11
        Me._FM_Panel3D2_2.ForeColor = Color.Empty
        'Me._FM_Panel3D2_2.BevelOuter = 1
        Me._FM_Panel3D2_2.Name = "_FM_Panel3D2_2"
		Me.TX_Message.AutoSize = False
		Me.TX_Message.BackColor = System.Drawing.SystemColors.Control
		Me.TX_Message.ForeColor = System.Drawing.Color.Black
		Me.TX_Message.Size = New System.Drawing.Size(349, 13)
		Me.TX_Message.Location = New System.Drawing.Point(6, 6)
		Me.TX_Message.MultiLine = True
		Me.TX_Message.TabIndex = 12
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
		Me.TX_Message.TabStop = True
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
		Me.GAUGE.Size = New System.Drawing.Size(523, 28)
		Me.GAUGE.Location = New System.Drawing.Point(22, 234)
		Me.GAUGE.TabIndex = 13
        Me.GAUGE.ForeColor = Color.Empty
        'Me.GAUGE.BevelOuter = 1
        Me.GAUGE.Text = "Panel3D2"
        'Me.GAUGE.FloodType = 1
        'Me.GAUGE.OutLine = -1
        Me.GAUGE.Name = "GAUGE"
		Me.CM_LCANCEL.Size = New System.Drawing.Size(76, 19)
		Me.CM_LCANCEL.Location = New System.Drawing.Point(246, 276)
		Me.CM_LCANCEL.TabIndex = 14
		Me.CM_LCANCEL.TabStop = 0
        Me.CM_LCANCEL.ForeColor = Color.Empty
        Me.CM_LCANCEL.Text = "中 止"
        'Me.CM_LCANCEL.OutLine = 0
        Me.CM_LCANCEL.Name = "CM_LCANCEL"
		Me._FM_Panel3D4_4.Size = New System.Drawing.Size(79, 22)
		Me._FM_Panel3D4_4.Location = New System.Drawing.Point(272, 48)
		Me._FM_Panel3D4_4.TabIndex = 18
        Me._FM_Panel3D4_4.ForeColor = Color.Empty
        'Me._FM_Panel3D4_4.BevelOuter = 1
        Me._FM_Panel3D4_4.Text = "入力担当者"
        'Me._FM_Panel3D4_4.OutLine = -1
        Me._FM_Panel3D4_4.Name = "_FM_Panel3D4_4"
		Me.MN_Ctrl.Name = "MN_Ctrl"
		Me.MN_Ctrl.Text = "処理(&1)"
		Me.MN_Ctrl.Checked = False
		Me.MN_Ctrl.Enabled = True
		Me.MN_Ctrl.Visible = True
		Me.MN_LSTART.Name = "MN_LSTART"
		Me.MN_LSTART.Text = "印刷(&P)"
		Me.MN_LSTART.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.P, System.Windows.Forms.Keys)
		Me.MN_LSTART.Checked = False
		Me.MN_LSTART.Enabled = True
		Me.MN_LSTART.Visible = True
		Me.MN_VSTART.Name = "MN_VSTART"
		Me.MN_VSTART.Text = "画面表示"
		Me.MN_VSTART.Checked = False
		Me.MN_VSTART.Enabled = True
		Me.MN_VSTART.Visible = True
		Me.MN_FSTART.Name = "MN_FSTART"
		Me.MN_FSTART.Text = "ファイル出力"
		Me.MN_FSTART.Checked = False
		Me.MN_FSTART.Enabled = True
		Me.MN_FSTART.Visible = True
		Me.MN_LCONFIG.Name = "MN_LCONFIG"
		Me.MN_LCONFIG.Text = "印刷設定(&I)..."
		Me.MN_LCONFIG.Checked = False
		Me.MN_LCONFIG.Enabled = True
		Me.MN_LCONFIG.Visible = True
		Me.bar11.Enabled = True
		Me.bar11.Visible = True
		Me.bar11.Name = "bar11"
		Me.MN_EndCm.Name = "MN_EndCm"
		Me.MN_EndCm.Text = "終了(&X)"
		Me.MN_EndCm.Checked = False
		Me.MN_EndCm.Enabled = True
		Me.MN_EndCm.Visible = True
		Me.MN_EditMn.Name = "MN_EditMn"
		Me.MN_EditMn.Text = "編集(&2)"
		Me.MN_EditMn.Checked = False
		Me.MN_EditMn.Enabled = True
		Me.MN_EditMn.Visible = True
		Me.MN_APPENDC.Name = "MN_APPENDC"
		Me.MN_APPENDC.Text = "画面初期化(&S)"
		Me.MN_APPENDC.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.S, System.Windows.Forms.Keys)
		Me.MN_APPENDC.Checked = False
		Me.MN_APPENDC.Enabled = True
		Me.MN_APPENDC.Visible = True
		Me.MN_ClearItm.Name = "MN_ClearItm"
		Me.MN_ClearItm.Text = "項目初期化"
		Me.MN_ClearItm.Checked = False
		Me.MN_ClearItm.Enabled = True
		Me.MN_ClearItm.Visible = True
		Me.MN_UnDoItem.Name = "MN_UnDoItem"
		Me.MN_UnDoItem.Text = "項目復元"
		Me.MN_UnDoItem.Checked = False
		Me.MN_UnDoItem.Enabled = True
		Me.MN_UnDoItem.Visible = True
		Me.Bar21.Enabled = True
		Me.Bar21.Visible = True
		Me.Bar21.Name = "Bar21"
		Me.MN_Cut.Name = "MN_Cut"
		Me.MN_Cut.Text = "切り取り(&X)"
		Me.MN_Cut.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.X, System.Windows.Forms.Keys)
		Me.MN_Cut.Checked = False
		Me.MN_Cut.Enabled = True
		Me.MN_Cut.Visible = True
		Me.MN_Copy.Name = "MN_Copy"
		Me.MN_Copy.Text = "コピー(&C)"
		Me.MN_Copy.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.C, System.Windows.Forms.Keys)
		Me.MN_Copy.Checked = False
		Me.MN_Copy.Enabled = True
		Me.MN_Copy.Visible = True
		Me.MN_Paste.Name = "MN_Paste"
		Me.MN_Paste.Text = "貼り付け(&V)"
		Me.MN_Paste.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.V, System.Windows.Forms.Keys)
		Me.MN_Paste.Checked = False
		Me.MN_Paste.Enabled = True
		Me.MN_Paste.Visible = True
		Me.MN_Oprt.Name = "MN_Oprt"
		Me.MN_Oprt.Text = "補助(&3)"
		Me.MN_Oprt.Checked = False
		Me.MN_Oprt.Enabled = True
		Me.MN_Oprt.Visible = True
		Me.MN_Slist.Name = "MN_Slist"
		Me.MN_Slist.Text = "ウインドウ表示(&L)"
		Me.MN_Slist.ShortcutKeys = CType(System.Windows.Forms.Keys.F5, System.Windows.Forms.Keys)
		Me.MN_Slist.Checked = False
		Me.MN_Slist.Enabled = True
		Me.MN_Slist.Visible = True
		Me.SM_ShortCut.Name = "SM_ShortCut"
		Me.SM_ShortCut.Text = "ShortCut"
		Me.SM_ShortCut.Visible = False
		Me.SM_ShortCut.Checked = False
		Me.SM_ShortCut.Enabled = True
		Me.SM_AllCopy.Name = "SM_AllCopy"
		Me.SM_AllCopy.Text = "項目内容コピー(&C)"
		Me.SM_AllCopy.Checked = False
		Me.SM_AllCopy.Enabled = True
		Me.SM_AllCopy.Visible = True
		Me.SM_FullPast.Name = "SM_FullPast"
		Me.SM_FullPast.Text = "項目に貼り付け(&P)"
		Me.SM_FullPast.Checked = False
		Me.SM_FullPast.Enabled = True
		Me.SM_FullPast.Visible = True
		Me.SM_Esc.Name = "SM_Esc"
		Me.SM_Esc.Text = "取消し(Esc)"
		Me.SM_Esc.Checked = False
		Me.SM_Esc.Enabled = True
		Me.SM_Esc.Visible = True
		Me.Controls.Add(HD_OPENM)
		Me.Controls.Add(HD_OPEID)
		Me.Controls.Add(Frame3D1)
		Me.Controls.Add(FM_Panel3D1)
		Me.Controls.Add(FM_Panel3D14)
		Me.Controls.Add(TX_CursorRest)
		Me.Controls.Add(_FM_Panel3D15_0)
		Me.Controls.Add(GAUGE)
		Me.Controls.Add(CM_LCANCEL)
		Me.Controls.Add(_FM_Panel3D4_4)
		Me.Frame3D1.Controls.Add(HD_ENDNHSNM)
		Me.Frame3D1.Controls.Add(HD_STTNHSNM)
		Me.Frame3D1.Controls.Add(HD_ENDNHSCD)
		Me.Frame3D1.Controls.Add(HD_STTNHSCD)
		Me.Frame3D1.Controls.Add(Label2)
		Me.Frame3D1.Controls.Add(Label1)
		Me.FM_Panel3D1.Controls.Add(TX_Mode)
        'Me.FM_Panel3D1.Controls.Add(CMDialogL)
        Me.FM_Panel3D1.Controls.Add(_IM_LSTART_0)
		Me.FM_Panel3D1.Controls.Add(_IM_Slist_0)
		Me.FM_Panel3D1.Controls.Add(_IM_EndCm_1)
		Me.FM_Panel3D1.Controls.Add(_IM_EndCm_0)
		Me.FM_Panel3D1.Controls.Add(_IM_Slist_1)
		Me.FM_Panel3D1.Controls.Add(_IM_LSTART_1)
		Me.FM_Panel3D1.Controls.Add(_IM_VSTART_0)
		Me.FM_Panel3D1.Controls.Add(_IM_VSTART_1)
		Me.FM_Panel3D1.Controls.Add(_IM_FSTART_0)
		Me.FM_Panel3D1.Controls.Add(_IM_FSTART_1)
		Me.FM_Panel3D1.Controls.Add(_IM_LCONFIG_0)
		Me.FM_Panel3D1.Controls.Add(_IM_LCONFIG_1)
		Me.FM_Panel3D1.Controls.Add(_IM_Denkyu_1)
		Me.FM_Panel3D1.Controls.Add(_IM_Denkyu_2)
		Me.FM_Panel3D14.Controls.Add(SYSDT)
		Me.FM_Panel3D14.Controls.Add(Label3)
		Me.FM_Panel3D14.Controls.Add(CM_SLIST)
		Me.FM_Panel3D14.Controls.Add(CM_EndCm)
		Me.FM_Panel3D14.Controls.Add(CM_LSTART)
		Me.FM_Panel3D14.Controls.Add(CM_LCONFIG)
		Me.FM_Panel3D14.Controls.Add(CM_VSTART)
		Me.FM_Panel3D14.Controls.Add(CM_FSTART)
		Me.FM_Panel3D14.Controls.Add(Image1)
		Me._FM_Panel3D15_0.Controls.Add(_FM_Panel3D2_2)
		Me._FM_Panel3D15_0.Controls.Add(_IM_Denkyu_0)
		Me._FM_Panel3D2_2.Controls.Add(TX_Message)
        'Me.FM_Panel3D15.SetIndex(_FM_Panel3D15_0, CType(0, Short))
        'Me.FM_Panel3D2.SetIndex(_FM_Panel3D2_2, CType(2, Short))
        'Me.FM_Panel3D4.SetIndex(_FM_Panel3D4_4, CType(4, Short))
        Me.IM_Denkyu.SetIndex(_IM_Denkyu_1, CType(1, Short))
		Me.IM_Denkyu.SetIndex(_IM_Denkyu_2, CType(2, Short))
		Me.IM_Denkyu.SetIndex(_IM_Denkyu_0, CType(0, Short))
		Me.IM_EndCm.SetIndex(_IM_EndCm_1, CType(1, Short))
		Me.IM_EndCm.SetIndex(_IM_EndCm_0, CType(0, Short))
		Me.IM_FSTART.SetIndex(_IM_FSTART_0, CType(0, Short))
		Me.IM_FSTART.SetIndex(_IM_FSTART_1, CType(1, Short))
		Me.IM_LCONFIG.SetIndex(_IM_LCONFIG_0, CType(0, Short))
		Me.IM_LCONFIG.SetIndex(_IM_LCONFIG_1, CType(1, Short))
		Me.IM_LSTART.SetIndex(_IM_LSTART_0, CType(0, Short))
		Me.IM_LSTART.SetIndex(_IM_LSTART_1, CType(1, Short))
		Me.IM_Slist.SetIndex(_IM_Slist_0, CType(0, Short))
		Me.IM_Slist.SetIndex(_IM_Slist_1, CType(1, Short))
		Me.IM_VSTART.SetIndex(_IM_VSTART_0, CType(0, Short))
		Me.IM_VSTART.SetIndex(_IM_VSTART_1, CType(1, Short))
		CType(Me.IM_VSTART, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_Slist, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_LSTART, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_LCONFIG, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_FSTART, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_EndCm, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_Denkyu, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.FM_Panel3D4, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.FM_Panel3D2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.FM_Panel3D15, System.ComponentModel.ISupportInitialize).EndInit()
		MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me.MN_Ctrl, Me.MN_EditMn, Me.MN_Oprt, Me.SM_ShortCut})
		MN_Ctrl.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.MN_LSTART, Me.MN_VSTART, Me.MN_FSTART, Me.MN_LCONFIG, Me.bar11, Me.MN_EndCm})
		MN_EditMn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.MN_APPENDC, Me.MN_ClearItm, Me.MN_UnDoItem, Me.Bar21, Me.MN_Cut, Me.MN_Copy, Me.MN_Paste})
		MN_Oprt.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.MN_Slist})
		SM_ShortCut.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.SM_AllCopy, Me.SM_FullPast, Me.SM_Esc})
		Me.Controls.Add(MainMenu1)
		Me.Frame3D1.ResumeLayout(False)
		Me.FM_Panel3D1.ResumeLayout(False)
		Me.FM_Panel3D14.ResumeLayout(False)
		Me._FM_Panel3D15_0.ResumeLayout(False)
		Me._FM_Panel3D2_2.ResumeLayout(False)
		Me.MainMenu1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class