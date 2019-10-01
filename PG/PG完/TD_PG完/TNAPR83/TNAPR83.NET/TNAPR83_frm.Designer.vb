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
	Public WithEvents HD_IN_TANCD As System.Windows.Forms.TextBox
	Public WithEvents HD_IN_TANNM As System.Windows.Forms.TextBox
	Public WithEvents CS_ENDDENDT As System.Windows.Forms.Button
	Public WithEvents CS_STTDENDT As System.Windows.Forms.Button
	Public WithEvents TX_Mode As System.Windows.Forms.TextBox
	Public WithEvents CS_STTTOKCD As System.Windows.Forms.Button
	Public WithEvents CS_ENDTOKCD As System.Windows.Forms.Button
    '20190625 CHG START
    'Public WithEvents CMDialogL As CommonDialog
    Public WithEvents CMDialogL As OpenFileDialog
    '20190625 CHG END
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
    '20190627 CHG START
    '   Public WithEvents _FM_Panel3D1_0 As SSPanel5
    'Public WithEvents TX_Message As System.Windows.Forms.TextBox
    'Public WithEvents _FM_Panel3D1_4 As SSPanel5
    'Public WithEvents _IM_Denkyu_0 As System.Windows.Forms.PictureBox
    'Public WithEvents _FM_Panel3D1_3 As SSPanel5
    '   Public WithEvents SYSDT As SSPanel5
    Public WithEvents _FM_Panel3D1_0 As Label
    Public WithEvents TX_Message As System.Windows.Forms.TextBox
    Public WithEvents _FM_Panel3D1_4 As Label
    Public WithEvents _IM_Denkyu_0 As System.Windows.Forms.PictureBox
    Public WithEvents _FM_Panel3D1_3 As Label
    Public WithEvents SYSDT As Label
    Public WithEvents Image1 As System.Windows.Forms.PictureBox
    '20190627 CHG START
    'Public WithEvents _FM_Panel3D1_1 As SSPanel5
    'Public WithEvents GAUGE As SSPanel5
    Public WithEvents _FM_Panel3D1_1 As Label
    Public WithEvents GAUGE As Label
    '20190627 CHG END
    Public WithEvents HD_ZAIOUT As System.Windows.Forms.TextBox
	Public WithEvents HD_SOUNM As System.Windows.Forms.TextBox
	Public WithEvents HD_SOUCD As System.Windows.Forms.TextBox
	Public WithEvents HD_Cursol_Wk2 As System.Windows.Forms.TextBox
	Public WithEvents HD_Cursol_Wk As System.Windows.Forms.TextBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Frame3D1 As System.Windows.Forms.GroupBox
	Public WithEvents TM_StartUp As System.Windows.Forms.Timer
	Public WithEvents TX_CursorRest As System.Windows.Forms.TextBox
    '20190627 CHG START
    'Public WithEvents CM_LCANCEL As SSCommand5
    'Public WithEvents _FM_Panel3D1_2 As SSPanel5
    'Public WithEvents FM_Panel3D1 As SSPanel5Array
    Public WithEvents CM_LCANCEL As Button
    Public WithEvents _FM_Panel3D1_2 As Label
    Public WithEvents FM_Panel3D1 As VB6.LabelArray
    '20190627 CHG END
    Public WithEvents IM_Denkyu As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_EndCm As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_FSTART As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_LCONFIG As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_LSTART As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_Slist As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    Public WithEvents IM_VSTART As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    '20190627 CHG START
    '   Public WithEvents MN_LSTART As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_VSTART As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_FSTART As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_LCONFIG As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents bar11 As System.Windows.Forms.ToolStripSeparator
    'Public WithEvents MN_EndCm As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Ctrl As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_APPENDC As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_ClearItm As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_UnDoItem As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents Bar21 As System.Windows.Forms.ToolStripSeparator
    'Public WithEvents MN_Cut As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Copy As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Paste As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_EditMn As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Slist As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Oprt As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents SM_AllCopy As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents SM_FullPast As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents SM_Esc As System.Windows.Forms.ToolStripMenuItem
    '   Public WithEvents SM_ShortCut As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MN_LSTART As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_VSTART As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_FSTART As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_LCONFIG As System.Windows.Forms.ContextMenuStrip
    Public WithEvents bar11 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents MN_EndCm As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Ctrl As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_APPENDC As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_ClearItm As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_UnDoItem As System.Windows.Forms.ContextMenuStrip
    Public WithEvents Bar21 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents MN_Cut As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Copy As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Paste As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_EditMn As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Slist As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Oprt As System.Windows.Forms.ContextMenuStrip
    Public WithEvents SM_AllCopy As System.Windows.Forms.ContextMenuStrip
    Public WithEvents SM_FullPast As System.Windows.Forms.ContextMenuStrip
    Public WithEvents SM_Esc As System.Windows.Forms.ContextMenuStrip
    Public WithEvents SM_ShortCut As System.Windows.Forms.ContextMenuStrip
    '20190627 CHG END
    Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_SSSMAIN))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.HD_IN_TANCD = New System.Windows.Forms.TextBox()
        Me.HD_IN_TANNM = New System.Windows.Forms.TextBox()
        Me._FM_Panel3D1_0 = New System.Windows.Forms.Label()
        Me.CS_ENDDENDT = New System.Windows.Forms.Button()
        Me.CS_STTDENDT = New System.Windows.Forms.Button()
        Me.TX_Mode = New System.Windows.Forms.TextBox()
        Me.CS_STTTOKCD = New System.Windows.Forms.Button()
        Me.CS_ENDTOKCD = New System.Windows.Forms.Button()
        Me._IM_LSTART_0 = New System.Windows.Forms.PictureBox()
        Me._IM_Slist_0 = New System.Windows.Forms.PictureBox()
        Me._IM_EndCm_1 = New System.Windows.Forms.PictureBox()
        Me._IM_EndCm_0 = New System.Windows.Forms.PictureBox()
        Me._IM_Slist_1 = New System.Windows.Forms.PictureBox()
        Me._IM_LSTART_1 = New System.Windows.Forms.PictureBox()
        Me._IM_VSTART_0 = New System.Windows.Forms.PictureBox()
        Me._IM_VSTART_1 = New System.Windows.Forms.PictureBox()
        Me._IM_FSTART_0 = New System.Windows.Forms.PictureBox()
        Me._IM_FSTART_1 = New System.Windows.Forms.PictureBox()
        Me._IM_LCONFIG_0 = New System.Windows.Forms.PictureBox()
        Me._IM_LCONFIG_1 = New System.Windows.Forms.PictureBox()
        Me._IM_Denkyu_1 = New System.Windows.Forms.PictureBox()
        Me._IM_Denkyu_2 = New System.Windows.Forms.PictureBox()
        Me.CMDialogL = New System.Windows.Forms.OpenFileDialog()
        Me._FM_Panel3D1_3 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_4 = New System.Windows.Forms.Label()
        Me.TX_Message = New System.Windows.Forms.TextBox()
        Me._IM_Denkyu_0 = New System.Windows.Forms.PictureBox()
        Me._FM_Panel3D1_1 = New System.Windows.Forms.Label()
        Me.SYSDT = New System.Windows.Forms.Label()
        Me.Image1 = New System.Windows.Forms.PictureBox()
        Me.GAUGE = New System.Windows.Forms.Label()
        Me.Frame3D1 = New System.Windows.Forms.GroupBox()
        Me.HD_ZAIOUT = New System.Windows.Forms.TextBox()
        Me.HD_SOUNM = New System.Windows.Forms.TextBox()
        Me.HD_SOUCD = New System.Windows.Forms.TextBox()
        Me.HD_Cursol_Wk2 = New System.Windows.Forms.TextBox()
        Me.HD_Cursol_Wk = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TM_StartUp = New System.Windows.Forms.Timer(Me.components)
        Me.TX_CursorRest = New System.Windows.Forms.TextBox()
        Me.CM_LCANCEL = New System.Windows.Forms.Button()
        Me._FM_Panel3D1_2 = New System.Windows.Forms.Label()
        Me.FM_Panel3D1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.IM_Denkyu = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_EndCm = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_FSTART = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_LCONFIG = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_LSTART = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_Slist = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_VSTART = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.MN_Ctrl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_LSTART = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_VSTART = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_FSTART = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_LCONFIG = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.bar11 = New System.Windows.Forms.ToolStripSeparator()
        Me.MN_EndCm = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_EditMn = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_APPENDC = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_ClearItm = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_UnDoItem = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Bar21 = New System.Windows.Forms.ToolStripSeparator()
        Me.MN_Cut = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Copy = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Paste = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Oprt = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Slist = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SM_ShortCut = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SM_AllCopy = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SM_FullPast = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SM_Esc = New System.Windows.Forms.ContextMenuStrip(Me.components)
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._FM_Panel3D1_0.SuspendLayout()
        CType(Me._IM_LSTART_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Slist_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_EndCm_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_EndCm_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Slist_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_LSTART_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_VSTART_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_VSTART_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_FSTART_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_FSTART_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_LCONFIG_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_LCONFIG_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Denkyu_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Denkyu_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._FM_Panel3D1_3.SuspendLayout()
        Me._FM_Panel3D1_4.SuspendLayout()
        CType(Me._IM_Denkyu_0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._FM_Panel3D1_1.SuspendLayout()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame3D1.SuspendLayout()
        CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_Denkyu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_EndCm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_FSTART, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_LCONFIG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_LSTART, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_Slist, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_VSTART, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'HD_IN_TANCD
        '
        Me.HD_IN_TANCD.AcceptsReturn = True
        Me.HD_IN_TANCD.BackColor = System.Drawing.SystemColors.Control
        Me.HD_IN_TANCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_IN_TANCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_IN_TANCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_IN_TANCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_IN_TANCD.Location = New System.Drawing.Point(451, 43)
        Me.HD_IN_TANCD.MaxLength = 10
        Me.HD_IN_TANCD.Name = "HD_IN_TANCD"
        Me.HD_IN_TANCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_IN_TANCD.Size = New System.Drawing.Size(48, 20)
        Me.HD_IN_TANCD.TabIndex = 16
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
        Me.HD_IN_TANNM.Location = New System.Drawing.Point(498, 43)
        Me.HD_IN_TANNM.MaxLength = 24
        Me.HD_IN_TANNM.Name = "HD_IN_TANNM"
        Me.HD_IN_TANNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_IN_TANNM.Size = New System.Drawing.Size(150, 20)
        Me.HD_IN_TANNM.TabIndex = 15
        Me.HD_IN_TANNM.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        '_FM_Panel3D1_0
        '
        Me._FM_Panel3D1_0.Controls.Add(Me.CS_ENDDENDT)
        Me._FM_Panel3D1_0.Controls.Add(Me.CS_STTDENDT)
        Me._FM_Panel3D1_0.Controls.Add(Me.TX_Mode)
        Me._FM_Panel3D1_0.Controls.Add(Me.CS_STTTOKCD)
        Me._FM_Panel3D1_0.Controls.Add(Me.CS_ENDTOKCD)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_LSTART_0)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_Slist_0)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_EndCm_1)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_EndCm_0)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_Slist_1)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_LSTART_1)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_VSTART_0)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_VSTART_1)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_FSTART_0)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_FSTART_1)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_LCONFIG_0)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_LCONFIG_1)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_Denkyu_1)
        Me._FM_Panel3D1_0.Controls.Add(Me._IM_Denkyu_2)
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_0, CType(0, Short))
        Me._FM_Panel3D1_0.Location = New System.Drawing.Point(0, 471)
        Me._FM_Panel3D1_0.Name = "_FM_Panel3D1_0"
        Me._FM_Panel3D1_0.Size = New System.Drawing.Size(553, 94)
        Me._FM_Panel3D1_0.TabIndex = 8
        '
        'CS_ENDDENDT
        '
        Me.CS_ENDDENDT.BackColor = System.Drawing.SystemColors.Control
        Me.CS_ENDDENDT.Cursor = System.Windows.Forms.Cursors.Default
        Me.CS_ENDDENDT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CS_ENDDENDT.Location = New System.Drawing.Point(261, 42)
        Me.CS_ENDDENDT.Name = "CS_ENDDENDT"
        Me.CS_ENDDENDT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CS_ENDDENDT.Size = New System.Drawing.Size(22, 22)
        Me.CS_ENDDENDT.TabIndex = 14
        Me.CS_ENDDENDT.TabStop = False
        Me.CS_ENDDENDT.Text = "D"
        Me.CS_ENDDENDT.UseVisualStyleBackColor = False
        '
        'CS_STTDENDT
        '
        Me.CS_STTDENDT.BackColor = System.Drawing.SystemColors.Control
        Me.CS_STTDENDT.Cursor = System.Windows.Forms.Cursors.Default
        Me.CS_STTDENDT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CS_STTDENDT.Location = New System.Drawing.Point(234, 42)
        Me.CS_STTDENDT.Name = "CS_STTDENDT"
        Me.CS_STTDENDT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CS_STTDENDT.Size = New System.Drawing.Size(22, 22)
        Me.CS_STTDENDT.TabIndex = 13
        Me.CS_STTDENDT.TabStop = False
        Me.CS_STTDENDT.Text = "D"
        Me.CS_STTDENDT.UseVisualStyleBackColor = False
        '
        'TX_Mode
        '
        Me.TX_Mode.AcceptsReturn = True
        Me.TX_Mode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TX_Mode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TX_Mode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TX_Mode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TX_Mode.Location = New System.Drawing.Point(105, 42)
        Me.TX_Mode.MaxLength = 0
        Me.TX_Mode.Name = "TX_Mode"
        Me.TX_Mode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_Mode.Size = New System.Drawing.Size(49, 20)
        Me.TX_Mode.TabIndex = 11
        Me.TX_Mode.Text = "ﾓｰﾄﾞ"
        '
        'CS_STTTOKCD
        '
        Me.CS_STTTOKCD.BackColor = System.Drawing.SystemColors.Control
        Me.CS_STTTOKCD.Cursor = System.Windows.Forms.Cursors.Default
        Me.CS_STTTOKCD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CS_STTTOKCD.Location = New System.Drawing.Point(48, 42)
        Me.CS_STTTOKCD.Name = "CS_STTTOKCD"
        Me.CS_STTTOKCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CS_STTTOKCD.Size = New System.Drawing.Size(22, 22)
        Me.CS_STTTOKCD.TabIndex = 10
        Me.CS_STTTOKCD.TabStop = False
        Me.CS_STTTOKCD.Text = "T"
        Me.CS_STTTOKCD.UseVisualStyleBackColor = False
        '
        'CS_ENDTOKCD
        '
        Me.CS_ENDTOKCD.BackColor = System.Drawing.SystemColors.Control
        Me.CS_ENDTOKCD.Cursor = System.Windows.Forms.Cursors.Default
        Me.CS_ENDTOKCD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CS_ENDTOKCD.Location = New System.Drawing.Point(78, 42)
        Me.CS_ENDTOKCD.Name = "CS_ENDTOKCD"
        Me.CS_ENDTOKCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CS_ENDTOKCD.Size = New System.Drawing.Size(22, 22)
        Me.CS_ENDTOKCD.TabIndex = 9
        Me.CS_ENDTOKCD.TabStop = False
        Me.CS_ENDTOKCD.Text = "T"
        Me.CS_ENDTOKCD.UseVisualStyleBackColor = False
        '
        '_IM_LSTART_0
        '
        Me._IM_LSTART_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_LSTART_0.Image = CType(resources.GetObject("_IM_LSTART_0.Image"), System.Drawing.Image)
        Me.IM_LSTART.SetIndex(Me._IM_LSTART_0, CType(0, Short))
        Me._IM_LSTART_0.Location = New System.Drawing.Point(123, 3)
        Me._IM_LSTART_0.Name = "_IM_LSTART_0"
        Me._IM_LSTART_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_LSTART_0.TabIndex = 15
        Me._IM_LSTART_0.TabStop = False
        Me._IM_LSTART_0.Visible = False
        '
        '_IM_Slist_0
        '
        Me._IM_Slist_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Slist_0.Image = CType(resources.GetObject("_IM_Slist_0.Image"), System.Drawing.Image)
        Me.IM_Slist.SetIndex(Me._IM_Slist_0, CType(0, Short))
        Me._IM_Slist_0.Location = New System.Drawing.Point(66, 3)
        Me._IM_Slist_0.Name = "_IM_Slist_0"
        Me._IM_Slist_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_Slist_0.TabIndex = 16
        Me._IM_Slist_0.TabStop = False
        Me._IM_Slist_0.Visible = False
        '
        '_IM_EndCm_1
        '
        Me._IM_EndCm_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_EndCm_1.Image = CType(resources.GetObject("_IM_EndCm_1.Image"), System.Drawing.Image)
        Me.IM_EndCm.SetIndex(Me._IM_EndCm_1, CType(1, Short))
        Me._IM_EndCm_1.Location = New System.Drawing.Point(36, 3)
        Me._IM_EndCm_1.Name = "_IM_EndCm_1"
        Me._IM_EndCm_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_EndCm_1.TabIndex = 17
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
        Me._IM_EndCm_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_EndCm_0.TabIndex = 18
        Me._IM_EndCm_0.TabStop = False
        Me._IM_EndCm_0.Visible = False
        '
        '_IM_Slist_1
        '
        Me._IM_Slist_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Slist_1.Image = CType(resources.GetObject("_IM_Slist_1.Image"), System.Drawing.Image)
        Me.IM_Slist.SetIndex(Me._IM_Slist_1, CType(1, Short))
        Me._IM_Slist_1.Location = New System.Drawing.Point(93, 3)
        Me._IM_Slist_1.Name = "_IM_Slist_1"
        Me._IM_Slist_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_Slist_1.TabIndex = 19
        Me._IM_Slist_1.TabStop = False
        Me._IM_Slist_1.Visible = False
        '
        '_IM_LSTART_1
        '
        Me._IM_LSTART_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_LSTART_1.Image = CType(resources.GetObject("_IM_LSTART_1.Image"), System.Drawing.Image)
        Me.IM_LSTART.SetIndex(Me._IM_LSTART_1, CType(1, Short))
        Me._IM_LSTART_1.Location = New System.Drawing.Point(144, 3)
        Me._IM_LSTART_1.Name = "_IM_LSTART_1"
        Me._IM_LSTART_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_LSTART_1.TabIndex = 20
        Me._IM_LSTART_1.TabStop = False
        Me._IM_LSTART_1.Visible = False
        '
        '_IM_VSTART_0
        '
        Me._IM_VSTART_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_VSTART_0.Image = CType(resources.GetObject("_IM_VSTART_0.Image"), System.Drawing.Image)
        Me.IM_VSTART.SetIndex(Me._IM_VSTART_0, CType(0, Short))
        Me._IM_VSTART_0.Location = New System.Drawing.Point(168, 3)
        Me._IM_VSTART_0.Name = "_IM_VSTART_0"
        Me._IM_VSTART_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_VSTART_0.TabIndex = 21
        Me._IM_VSTART_0.TabStop = False
        '
        '_IM_VSTART_1
        '
        Me._IM_VSTART_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_VSTART_1.Image = CType(resources.GetObject("_IM_VSTART_1.Image"), System.Drawing.Image)
        Me.IM_VSTART.SetIndex(Me._IM_VSTART_1, CType(1, Short))
        Me._IM_VSTART_1.Location = New System.Drawing.Point(192, 3)
        Me._IM_VSTART_1.Name = "_IM_VSTART_1"
        Me._IM_VSTART_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_VSTART_1.TabIndex = 22
        Me._IM_VSTART_1.TabStop = False
        '
        '_IM_FSTART_0
        '
        Me._IM_FSTART_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_FSTART_0.Image = CType(resources.GetObject("_IM_FSTART_0.Image"), System.Drawing.Image)
        Me.IM_FSTART.SetIndex(Me._IM_FSTART_0, CType(0, Short))
        Me._IM_FSTART_0.Location = New System.Drawing.Point(216, 3)
        Me._IM_FSTART_0.Name = "_IM_FSTART_0"
        Me._IM_FSTART_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_FSTART_0.TabIndex = 23
        Me._IM_FSTART_0.TabStop = False
        '
        '_IM_FSTART_1
        '
        Me._IM_FSTART_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_FSTART_1.Image = CType(resources.GetObject("_IM_FSTART_1.Image"), System.Drawing.Image)
        Me.IM_FSTART.SetIndex(Me._IM_FSTART_1, CType(1, Short))
        Me._IM_FSTART_1.Location = New System.Drawing.Point(240, 3)
        Me._IM_FSTART_1.Name = "_IM_FSTART_1"
        Me._IM_FSTART_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_FSTART_1.TabIndex = 24
        Me._IM_FSTART_1.TabStop = False
        '
        '_IM_LCONFIG_0
        '
        Me._IM_LCONFIG_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_LCONFIG_0.Image = CType(resources.GetObject("_IM_LCONFIG_0.Image"), System.Drawing.Image)
        Me.IM_LCONFIG.SetIndex(Me._IM_LCONFIG_0, CType(0, Short))
        Me._IM_LCONFIG_0.Location = New System.Drawing.Point(264, 3)
        Me._IM_LCONFIG_0.Name = "_IM_LCONFIG_0"
        Me._IM_LCONFIG_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_LCONFIG_0.TabIndex = 25
        Me._IM_LCONFIG_0.TabStop = False
        '
        '_IM_LCONFIG_1
        '
        Me._IM_LCONFIG_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_LCONFIG_1.Image = CType(resources.GetObject("_IM_LCONFIG_1.Image"), System.Drawing.Image)
        Me.IM_LCONFIG.SetIndex(Me._IM_LCONFIG_1, CType(1, Short))
        Me._IM_LCONFIG_1.Location = New System.Drawing.Point(288, 3)
        Me._IM_LCONFIG_1.Name = "_IM_LCONFIG_1"
        Me._IM_LCONFIG_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_LCONFIG_1.TabIndex = 26
        Me._IM_LCONFIG_1.TabStop = False
        '
        '_IM_Denkyu_1
        '
        Me._IM_Denkyu_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_1.Image = CType(resources.GetObject("_IM_Denkyu_1.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_1, CType(1, Short))
        Me._IM_Denkyu_1.Location = New System.Drawing.Point(135, 33)
        Me._IM_Denkyu_1.Name = "_IM_Denkyu_1"
        Me._IM_Denkyu_1.Size = New System.Drawing.Size(20, 22)
        Me._IM_Denkyu_1.TabIndex = 27
        Me._IM_Denkyu_1.TabStop = False
        '
        '_IM_Denkyu_2
        '
        Me._IM_Denkyu_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_2.Image = CType(resources.GetObject("_IM_Denkyu_2.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_2, CType(2, Short))
        Me._IM_Denkyu_2.Location = New System.Drawing.Point(162, 33)
        Me._IM_Denkyu_2.Name = "_IM_Denkyu_2"
        Me._IM_Denkyu_2.Size = New System.Drawing.Size(20, 22)
        Me._IM_Denkyu_2.TabIndex = 28
        Me._IM_Denkyu_2.TabStop = False
        '
        'CMDialogL
        '
        Me.CMDialogL.Title = "CMDialogL"
        '
        '_FM_Panel3D1_3
        '
        Me._FM_Panel3D1_3.Controls.Add(Me._FM_Panel3D1_4)
        Me._FM_Panel3D1_3.Controls.Add(Me._IM_Denkyu_0)
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_3, CType(3, Short))
        Me._FM_Panel3D1_3.Location = New System.Drawing.Point(-2, 330)
        Me._FM_Panel3D1_3.Name = "_FM_Panel3D1_3"
        Me._FM_Panel3D1_3.Size = New System.Drawing.Size(663, 51)
        Me._FM_Panel3D1_3.TabIndex = 5
        '
        '_FM_Panel3D1_4
        '
        Me._FM_Panel3D1_4.Controls.Add(Me.TX_Message)
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_4, CType(4, Short))
        Me._FM_Panel3D1_4.Location = New System.Drawing.Point(45, 9)
        Me._FM_Panel3D1_4.Name = "_FM_Panel3D1_4"
        Me._FM_Panel3D1_4.Size = New System.Drawing.Size(608, 31)
        Me._FM_Panel3D1_4.TabIndex = 6
        '
        'TX_Message
        '
        Me.TX_Message.AcceptsReturn = True
        Me.TX_Message.BackColor = System.Drawing.SystemColors.Control
        Me.TX_Message.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TX_Message.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TX_Message.Enabled = False
        Me.TX_Message.ForeColor = System.Drawing.Color.Black
        Me.TX_Message.Location = New System.Drawing.Point(3, 27)
        Me.TX_Message.MaxLength = 0
        Me.TX_Message.Multiline = True
        Me.TX_Message.Name = "TX_Message"
        Me.TX_Message.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_Message.Size = New System.Drawing.Size(394, 13)
        Me.TX_Message.TabIndex = 7
        Me.TX_Message.Text = "エラーやプロンプトのメッセージが出力されるところです。"
        Me.TX_Message.Visible = False
        '
        '_IM_Denkyu_0
        '
        Me._IM_Denkyu_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_0.Enabled = False
        Me._IM_Denkyu_0.Image = CType(resources.GetObject("_IM_Denkyu_0.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_0, CType(0, Short))
        Me._IM_Denkyu_0.Location = New System.Drawing.Point(12, 30)
        Me._IM_Denkyu_0.Name = "_IM_Denkyu_0"
        Me._IM_Denkyu_0.Size = New System.Drawing.Size(20, 22)
        Me._IM_Denkyu_0.TabIndex = 7
        Me._IM_Denkyu_0.TabStop = False
        Me._IM_Denkyu_0.Visible = False
        '
        '_FM_Panel3D1_1
        '
        Me._FM_Panel3D1_1.Controls.Add(Me.SYSDT)
        Me._FM_Panel3D1_1.Controls.Add(Me.Image1)
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_1, CType(1, Short))
        Me._FM_Panel3D1_1.Location = New System.Drawing.Point(-3, 0)
        Me._FM_Panel3D1_1.Name = "_FM_Panel3D1_1"
        Me._FM_Panel3D1_1.Size = New System.Drawing.Size(663, 37)
        Me._FM_Panel3D1_1.TabIndex = 3
        '
        'SYSDT
        '
        Me.SYSDT.Location = New System.Drawing.Point(557, 9)
        Me.SYSDT.Name = "SYSDT"
        Me.SYSDT.Size = New System.Drawing.Size(94, 19)
        Me.SYSDT.TabIndex = 4
        Me.SYSDT.Text = "YYYY/MM/DD"
        '
        'Image1
        '
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Location = New System.Drawing.Point(0, 0)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(302, 34)
        Me.Image1.TabIndex = 10
        Me.Image1.TabStop = False
        '
        'GAUGE
        '
        Me.GAUGE.Location = New System.Drawing.Point(84, 242)
        Me.GAUGE.Name = "GAUGE"
        Me.GAUGE.Size = New System.Drawing.Size(491, 28)
        Me.GAUGE.TabIndex = 2
        Me.GAUGE.Text = "Panel3D2"
        '
        'Frame3D1
        '
        Me.Frame3D1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3D1.Controls.Add(Me.HD_ZAIOUT)
        Me.Frame3D1.Controls.Add(Me.HD_SOUNM)
        Me.Frame3D1.Controls.Add(Me.HD_SOUCD)
        Me.Frame3D1.Controls.Add(Me.HD_Cursol_Wk2)
        Me.Frame3D1.Controls.Add(Me.HD_Cursol_Wk)
        Me.Frame3D1.Controls.Add(Me.Label3)
        Me.Frame3D1.Controls.Add(Me.Label1)
        Me.Frame3D1.Controls.Add(Me.Label2)
        Me.Frame3D1.ForeColor = System.Drawing.Color.Black
        Me.Frame3D1.Location = New System.Drawing.Point(84, 95)
        Me.Frame3D1.Name = "Frame3D1"
        Me.Frame3D1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3D1.Size = New System.Drawing.Size(491, 134)
        Me.Frame3D1.TabIndex = 1
        Me.Frame3D1.TabStop = False
        Me.Frame3D1.Text = "条件指定"
        '
        'HD_ZAIOUT
        '
        Me.HD_ZAIOUT.AcceptsReturn = True
        Me.HD_ZAIOUT.BackColor = System.Drawing.Color.White
        Me.HD_ZAIOUT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_ZAIOUT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_ZAIOUT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_ZAIOUT.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_ZAIOUT.Location = New System.Drawing.Point(120, 81)
        Me.HD_ZAIOUT.MaxLength = 7
        Me.HD_ZAIOUT.Name = "HD_ZAIOUT"
        Me.HD_ZAIOUT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_ZAIOUT.Size = New System.Drawing.Size(17, 20)
        Me.HD_ZAIOUT.TabIndex = 22
        Me.HD_ZAIOUT.Text = "X"
        '
        'HD_SOUNM
        '
        Me.HD_SOUNM.AcceptsReturn = True
        Me.HD_SOUNM.BackColor = System.Drawing.SystemColors.Control
        Me.HD_SOUNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_SOUNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_SOUNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_SOUNM.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_SOUNM.Location = New System.Drawing.Point(147, 54)
        Me.HD_SOUNM.MaxLength = 20
        Me.HD_SOUNM.Name = "HD_SOUNM"
        Me.HD_SOUNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_SOUNM.Size = New System.Drawing.Size(149, 20)
        Me.HD_SOUNM.TabIndex = 21
        Me.HD_SOUNM.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'HD_SOUCD
        '
        Me.HD_SOUCD.AcceptsReturn = True
        Me.HD_SOUCD.BackColor = System.Drawing.Color.White
        Me.HD_SOUCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_SOUCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_SOUCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_SOUCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_SOUCD.Location = New System.Drawing.Point(119, 54)
        Me.HD_SOUCD.MaxLength = 7
        Me.HD_SOUCD.Name = "HD_SOUCD"
        Me.HD_SOUCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_SOUCD.Size = New System.Drawing.Size(29, 20)
        Me.HD_SOUCD.TabIndex = 20
        Me.HD_SOUCD.Text = "XX6"
        '
        'HD_Cursol_Wk2
        '
        Me.HD_Cursol_Wk2.AcceptsReturn = True
        Me.HD_Cursol_Wk2.BackColor = System.Drawing.Color.White
        Me.HD_Cursol_Wk2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_Cursol_Wk2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_Cursol_Wk2.Font = New System.Drawing.Font("ＭＳ ゴシック", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_Cursol_Wk2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_Cursol_Wk2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_Cursol_Wk2.Location = New System.Drawing.Point(123, 57)
        Me.HD_Cursol_Wk2.MaxLength = 0
        Me.HD_Cursol_Wk2.Name = "HD_Cursol_Wk2"
        Me.HD_Cursol_Wk2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_Cursol_Wk2.Size = New System.Drawing.Size(29, 15)
        Me.HD_Cursol_Wk2.TabIndex = 19
        Me.HD_Cursol_Wk2.Text = "HD_Cursol_Wk_1"
        '
        'HD_Cursol_Wk
        '
        Me.HD_Cursol_Wk.AcceptsReturn = True
        Me.HD_Cursol_Wk.BackColor = System.Drawing.Color.White
        Me.HD_Cursol_Wk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_Cursol_Wk.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_Cursol_Wk.Font = New System.Drawing.Font("ＭＳ ゴシック", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_Cursol_Wk.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_Cursol_Wk.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_Cursol_Wk.Location = New System.Drawing.Point(151, 57)
        Me.HD_Cursol_Wk.MaxLength = 0
        Me.HD_Cursol_Wk.Name = "HD_Cursol_Wk"
        Me.HD_Cursol_Wk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_Cursol_Wk.Size = New System.Drawing.Size(29, 15)
        Me.HD_Cursol_Wk.TabIndex = 18
        Me.HD_Cursol_Wk.Text = "HD_Cursol_Wk_1"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(139, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(198, 17)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "1:出力する　9:出力しない"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(45, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(71, 22)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "在庫数出力"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(45, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(71, 22)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "倉庫"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        Me.TX_CursorRest.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TX_CursorRest.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TX_CursorRest.Location = New System.Drawing.Point(2457, 2457)
        Me.TX_CursorRest.MaxLength = 0
        Me.TX_CursorRest.Name = "TX_CursorRest"
        Me.TX_CursorRest.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_CursorRest.Size = New System.Drawing.Size(19, 13)
        Me.TX_CursorRest.TabIndex = 0
        '
        'CM_LCANCEL
        '
        Me.CM_LCANCEL.Location = New System.Drawing.Point(291, 297)
        Me.CM_LCANCEL.Name = "CM_LCANCEL"
        Me.CM_LCANCEL.Size = New System.Drawing.Size(76, 19)
        Me.CM_LCANCEL.TabIndex = 12
        Me.CM_LCANCEL.TabStop = False
        Me.CM_LCANCEL.Text = "中 止"
        '
        '_FM_Panel3D1_2
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_2, CType(2, Short))
        Me._FM_Panel3D1_2.Location = New System.Drawing.Point(342, 43)
        Me._FM_Panel3D1_2.Name = "_FM_Panel3D1_2"
        Me._FM_Panel3D1_2.Size = New System.Drawing.Size(111, 23)
        Me._FM_Panel3D1_2.TabIndex = 17
        Me._FM_Panel3D1_2.Text = " 入力担当者"
        '
        'MainMenu1
        '
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(980, 24)
        Me.MainMenu1.TabIndex = 19
        '
        'MN_Ctrl
        '
        Me.MN_Ctrl.Name = "MN_Ctrl"
        Me.MN_Ctrl.Size = New System.Drawing.Size(61, 4)
        Me.MN_Ctrl.Text = "処理(&1)"
        '
        'MN_LSTART
        '
        Me.MN_LSTART.Name = "MN_LSTART"
        Me.MN_LSTART.Size = New System.Drawing.Size(61, 4)
        Me.MN_LSTART.Text = "印刷(&P)"
        '
        'MN_VSTART
        '
        Me.MN_VSTART.Name = "MN_VSTART"
        Me.MN_VSTART.Size = New System.Drawing.Size(61, 4)
        Me.MN_VSTART.Text = "画面表示"
        '
        'MN_FSTART
        '
        Me.MN_FSTART.Name = "MN_FSTART"
        Me.MN_FSTART.Size = New System.Drawing.Size(61, 4)
        Me.MN_FSTART.Text = "ファイル出力"
        '
        'MN_LCONFIG
        '
        Me.MN_LCONFIG.Name = "MN_LCONFIG"
        Me.MN_LCONFIG.Size = New System.Drawing.Size(61, 4)
        Me.MN_LCONFIG.Text = "印刷設定(&I)..."
        '
        'bar11
        '
        Me.bar11.Name = "bar11"
        Me.bar11.Size = New System.Drawing.Size(6, 6)
        '
        'MN_EndCm
        '
        Me.MN_EndCm.Name = "MN_EndCm"
        Me.MN_EndCm.Size = New System.Drawing.Size(61, 4)
        Me.MN_EndCm.Text = "終了(&X)"
        '
        'MN_EditMn
        '
        Me.MN_EditMn.Name = "MN_EditMn"
        Me.MN_EditMn.Size = New System.Drawing.Size(61, 4)
        Me.MN_EditMn.Text = "編集(&2)"
        '
        'MN_APPENDC
        '
        Me.MN_APPENDC.Name = "MN_APPENDC"
        Me.MN_APPENDC.Size = New System.Drawing.Size(61, 4)
        Me.MN_APPENDC.Text = "画面初期化(&S)"
        '
        'MN_ClearItm
        '
        Me.MN_ClearItm.Name = "MN_ClearItm"
        Me.MN_ClearItm.Size = New System.Drawing.Size(61, 4)
        Me.MN_ClearItm.Text = "項目初期化"
        '
        'MN_UnDoItem
        '
        Me.MN_UnDoItem.Name = "MN_UnDoItem"
        Me.MN_UnDoItem.Size = New System.Drawing.Size(61, 4)
        Me.MN_UnDoItem.Text = "項目復元"
        '
        'Bar21
        '
        Me.Bar21.Name = "Bar21"
        Me.Bar21.Size = New System.Drawing.Size(6, 6)
        '
        'MN_Cut
        '
        Me.MN_Cut.Name = "MN_Cut"
        Me.MN_Cut.Size = New System.Drawing.Size(61, 4)
        Me.MN_Cut.Text = "切り取り(&X)"
        '
        'MN_Copy
        '
        Me.MN_Copy.Name = "MN_Copy"
        Me.MN_Copy.Size = New System.Drawing.Size(61, 4)
        Me.MN_Copy.Text = "コピー(&C)"
        '
        'MN_Paste
        '
        Me.MN_Paste.Name = "MN_Paste"
        Me.MN_Paste.Size = New System.Drawing.Size(61, 4)
        Me.MN_Paste.Text = "貼り付け(&V)"
        '
        'MN_Oprt
        '
        Me.MN_Oprt.Name = "MN_Oprt"
        Me.MN_Oprt.Size = New System.Drawing.Size(61, 4)
        Me.MN_Oprt.Text = "補助(&3)"
        '
        'MN_Slist
        '
        Me.MN_Slist.Name = "MN_Slist"
        Me.MN_Slist.Size = New System.Drawing.Size(61, 4)
        Me.MN_Slist.Text = "ウインドウ表示(&L)"
        '
        'SM_ShortCut
        '
        Me.SM_ShortCut.Name = "SM_ShortCut"
        Me.SM_ShortCut.Size = New System.Drawing.Size(61, 4)
        Me.SM_ShortCut.Text = "ShortCut"
        '
        'SM_AllCopy
        '
        Me.SM_AllCopy.Name = "SM_AllCopy"
        Me.SM_AllCopy.Size = New System.Drawing.Size(61, 4)
        Me.SM_AllCopy.Text = "項目内容コピー(&C)"
        '
        'SM_FullPast
        '
        Me.SM_FullPast.Name = "SM_FullPast"
        Me.SM_FullPast.Size = New System.Drawing.Size(61, 4)
        Me.SM_FullPast.Text = "項目に貼り付け(&P)"
        '
        'SM_Esc
        '
        Me.SM_Esc.Name = "SM_Esc"
        Me.SM_Esc.Size = New System.Drawing.Size(61, 4)
        Me.SM_Esc.Text = "取消し(Esc)"
        '
        'btnF12
        '
        Me.btnF12.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF12.Location = New System.Drawing.Point(898, 337)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(75, 37)
        Me.btnF12.TabIndex = 337
        Me.btnF12.Text = "(F12)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'btnF11
        '
        Me.btnF11.Enabled = False
        Me.btnF11.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF11.Location = New System.Drawing.Point(821, 337)
        Me.btnF11.Name = "btnF11"
        Me.btnF11.Size = New System.Drawing.Size(75, 37)
        Me.btnF11.TabIndex = 336
        Me.btnF11.Text = "(F11)"
        Me.btnF11.UseVisualStyleBackColor = True
        '
        'btnF10
        '
        Me.btnF10.Enabled = False
        Me.btnF10.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF10.Location = New System.Drawing.Point(743, 337)
        Me.btnF10.Name = "btnF10"
        Me.btnF10.Size = New System.Drawing.Size(75, 37)
        Me.btnF10.TabIndex = 335
        Me.btnF10.Text = "(F10)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF10.UseVisualStyleBackColor = True
        '
        'btnF9
        '
        Me.btnF9.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF9.Location = New System.Drawing.Point(666, 337)
        Me.btnF9.Name = "btnF9"
        Me.btnF9.Size = New System.Drawing.Size(75, 37)
        Me.btnF9.TabIndex = 334
        Me.btnF9.Text = "(F9)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "クリア"
        Me.btnF9.UseVisualStyleBackColor = True
        '
        'btnF8
        '
        Me.btnF8.Enabled = False
        Me.btnF8.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF8.Location = New System.Drawing.Point(572, 337)
        Me.btnF8.Name = "btnF8"
        Me.btnF8.Size = New System.Drawing.Size(75, 37)
        Me.btnF8.TabIndex = 333
        Me.btnF8.Text = "(F8)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF8.UseVisualStyleBackColor = True
        '
        'btnF7
        '
        Me.btnF7.Enabled = False
        Me.btnF7.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF7.Location = New System.Drawing.Point(494, 337)
        Me.btnF7.Name = "btnF7"
        Me.btnF7.Size = New System.Drawing.Size(75, 37)
        Me.btnF7.TabIndex = 332
        Me.btnF7.Text = "(F7)"
        Me.btnF7.UseVisualStyleBackColor = True
        '
        'btnF6
        '
        Me.btnF6.Enabled = False
        Me.btnF6.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF6.Location = New System.Drawing.Point(416, 337)
        Me.btnF6.Name = "btnF6"
        Me.btnF6.Size = New System.Drawing.Size(75, 37)
        Me.btnF6.TabIndex = 331
        Me.btnF6.Text = "(F6)"
        Me.btnF6.UseVisualStyleBackColor = True
        '
        'btnF5
        '
        Me.btnF5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF5.Location = New System.Drawing.Point(338, 337)
        Me.btnF5.Name = "btnF5"
        Me.btnF5.Size = New System.Drawing.Size(75, 37)
        Me.btnF5.TabIndex = 330
        Me.btnF5.Text = "(F5)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ヘルプ"
        Me.btnF5.UseVisualStyleBackColor = True
        '
        'btnF4
        '
        Me.btnF4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF4.Location = New System.Drawing.Point(244, 337)
        Me.btnF4.Name = "btnF4"
        Me.btnF4.Size = New System.Drawing.Size(75, 37)
        Me.btnF4.TabIndex = 329
        Me.btnF4.Text = "(F4)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "印刷"
        Me.btnF4.UseVisualStyleBackColor = True
        '
        'btnF3
        '
        Me.btnF3.Enabled = False
        Me.btnF3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF3.Location = New System.Drawing.Point(165, 337)
        Me.btnF3.Name = "btnF3"
        Me.btnF3.Size = New System.Drawing.Size(75, 37)
        Me.btnF3.TabIndex = 328
        Me.btnF3.Text = "(F3)"
        Me.btnF3.UseVisualStyleBackColor = True
        '
        'btnF2
        '
        Me.btnF2.Enabled = False
        Me.btnF2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF2.Location = New System.Drawing.Point(86, 337)
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(75, 35)
        Me.btnF2.TabIndex = 327
        Me.btnF2.Text = "(F2)"
        Me.btnF2.UseVisualStyleBackColor = True
        '
        'btnF1
        '
        Me.btnF1.Enabled = False
        Me.btnF1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF1.Location = New System.Drawing.Point(7, 337)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(75, 35)
        Me.btnF1.TabIndex = 326
        Me.btnF1.Text = "(F1)"
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 378)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(980, 23)
        Me.StatusStrip1.TabIndex = 325
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(193, 18)
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(193, 18)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "端末ID"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(193, 18)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Text = "ログインID"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(193, 18)
        Me.ToolStripStatusLabel4.Spring = True
        Me.ToolStripStatusLabel4.Text = "XXXXXXX"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(193, 18)
        Me.ToolStripStatusLabel5.Spring = True
        Me.ToolStripStatusLabel5.Text = "Ver.1.00"
        '
        'FR_SSSMAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(980, 401)
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
        Me.Controls.Add(Me.HD_IN_TANCD)
        Me.Controls.Add(Me.HD_IN_TANNM)
        Me.Controls.Add(Me._FM_Panel3D1_0)
        Me.Controls.Add(Me._FM_Panel3D1_3)
        Me.Controls.Add(Me._FM_Panel3D1_1)
        Me.Controls.Add(Me.GAUGE)
        Me.Controls.Add(Me.Frame3D1)
        Me.Controls.Add(Me.TX_CursorRest)
        Me.Controls.Add(Me.CM_LCANCEL)
        Me.Controls.Add(Me._FM_Panel3D1_2)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(153, 212)
        Me.MaximizeBox = False
        Me.Name = "FR_SSSMAIN"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "棚卸調査表出力"
        Me._FM_Panel3D1_0.ResumeLayout(False)
        Me._FM_Panel3D1_0.PerformLayout()
        CType(Me._IM_LSTART_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Slist_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_EndCm_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_EndCm_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Slist_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_LSTART_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_VSTART_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_VSTART_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_FSTART_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_FSTART_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_LCONFIG_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_LCONFIG_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Denkyu_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Denkyu_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me._FM_Panel3D1_3.ResumeLayout(False)
        Me._FM_Panel3D1_4.ResumeLayout(False)
        Me._FM_Panel3D1_4.PerformLayout()
        CType(Me._IM_Denkyu_0, System.ComponentModel.ISupportInitialize).EndInit()
        Me._FM_Panel3D1_1.ResumeLayout(False)
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame3D1.ResumeLayout(False)
        Me.Frame3D1.PerformLayout()
        CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_Denkyu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_EndCm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_FSTART, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_LCONFIG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_LSTART, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_Slist, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_VSTART, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

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
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
#End Region
End Class