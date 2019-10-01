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
    Public WithEvents TX_Message As System.Windows.Forms.TextBox
    '20190703 CHG SART
    '   Public WithEvents _FM_Panel3D1_22 As SSPanel5
    'Public WithEvents _IM_Denkyu_0 As System.Windows.Forms.PictureBox
    'Public WithEvents _FM_Panel3D1_23 As SSPanel5
    Public WithEvents _FM_Panel3D1_22 As Label
    Public WithEvents _FM_Panel3D1_23 As Label
    '20190703 CHG END
    Public WithEvents TX_Mode As System.Windows.Forms.TextBox
	Public WithEvents _IM_Execute_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Execute_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_SELECTCM_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_SELECTCM_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Denkyu_2 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Denkyu_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_NEXTCM_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_NEXTCM_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_PREV_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_PREV_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Hardcopy_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Slist_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_EndCm_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_EndCm_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Slist_1 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_Hardcopy_1 As System.Windows.Forms.PictureBox
    '20190703 CHG START
    '   Public WithEvents _FM_Panel3D4_1 As SSPanel5
    'Public WithEvents SYSDT As SSPanel5
    Public WithEvents _FM_Panel3D4_1 As Label
    Public WithEvents SYSDT As Label
    '20190703 CHG END
    Public WithEvents CM_Execute As System.Windows.Forms.PictureBox
	Public WithEvents CM_SLIST As System.Windows.Forms.PictureBox
	Public WithEvents CM_EndCm As System.Windows.Forms.PictureBox
	Public WithEvents CM_NEXTCM As System.Windows.Forms.PictureBox
	Public WithEvents CM_PREV As System.Windows.Forms.PictureBox
	Public WithEvents CM_SELECTCM As System.Windows.Forms.PictureBox
    Public WithEvents Image1 As System.Windows.Forms.PictureBox
    '20190703 CHG START
    '   Public WithEvents _FM_Panel3D1_21 As SSPanel5
    'Public WithEvents TM_StartUp As System.Windows.Forms.Timer
    'Public WithEvents TX_CursorRest As System.Windows.Forms.TextBox
    'Public WithEvents _FM_Panel3D1_0 As SSPanel5
    Public WithEvents _FM_Panel3D1_21 As Label
    Public WithEvents TM_StartUp As System.Windows.Forms.Timer
    Public WithEvents TX_CursorRest As System.Windows.Forms.TextBox
    Public WithEvents _FM_Panel3D1_0 As Label
    '20190703 CHG END
    Public WithEvents _IM_Opt_1 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_Opt_0 As System.Windows.Forms.PictureBox
    '20190703 CHG START
    '   Public WithEvents FM_Panel3D1 As SSPanel5Array
    'Public WithEvents FM_Panel3D4 As SSPanel5Array
    Public WithEvents FM_Panel3D1 As VB6.LabelArray
    Public WithEvents FM_Panel3D4 As VB6.LabelArray
    '20190703 CHG END
    Public WithEvents IM_Denkyu As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_EndCm As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_Execute As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_Hardcopy As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_NEXTCM As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_Opt As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_PREV As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_SELECTCM As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    Public WithEvents IM_Slist As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    '20190703 CHG START
    '   Public WithEvents MN_Execute As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_HARDCOPY As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents Bar11 As System.Windows.Forms.ToolStripSeparator
    'Public WithEvents MN_EndCm As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Ctrl As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_ClearItm As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_UnDoItem As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents Bar21 As System.Windows.Forms.ToolStripSeparator
    'Public WithEvents MN_Cut As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Copy As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Paste As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_EditMn As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_SELECTCM As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_PREV As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_NEXTCM As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents Bar31 As System.Windows.Forms.ToolStripSeparator
    'Public WithEvents MN_Slist As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Oprt As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents SM_AllCopy As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents SM_FullPast As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents SM_Esc As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents SM_ShortCut As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MN_Execute As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_HARDCOPY As System.Windows.Forms.ContextMenuStrip
    Public WithEvents Bar11 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents MN_EndCm As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Ctrl As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_ClearItm As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_UnDoItem As System.Windows.Forms.ContextMenuStrip
    Public WithEvents Bar21 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents MN_Cut As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Copy As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Paste As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_EditMn As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_SELECTCM As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_PREV As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_NEXTCM As System.Windows.Forms.ContextMenuStrip
    Public WithEvents Bar31 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents MN_Slist As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Oprt As System.Windows.Forms.ContextMenuStrip
    Public WithEvents SM_AllCopy As System.Windows.Forms.ContextMenuStrip
    Public WithEvents SM_FullPast As System.Windows.Forms.ContextMenuStrip
    Public WithEvents SM_Esc As System.Windows.Forms.ContextMenuStrip
    Public WithEvents SM_ShortCut As System.Windows.Forms.ContextMenuStrip
    '20190703 CHG END
    Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_SSSMAIN))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.HD_IN_TANNM = New System.Windows.Forms.TextBox()
        Me.HD_IN_TANCD = New System.Windows.Forms.TextBox()
        Me._FM_Panel3D1_23 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_22 = New System.Windows.Forms.Label()
        Me.TX_Message = New System.Windows.Forms.TextBox()
        Me._FM_Panel3D4_1 = New System.Windows.Forms.Label()
        Me.TX_Mode = New System.Windows.Forms.TextBox()
        Me._IM_Execute_1 = New System.Windows.Forms.PictureBox()
        Me._IM_Execute_0 = New System.Windows.Forms.PictureBox()
        Me._IM_SELECTCM_1 = New System.Windows.Forms.PictureBox()
        Me._IM_SELECTCM_0 = New System.Windows.Forms.PictureBox()
        Me._IM_Denkyu_2 = New System.Windows.Forms.PictureBox()
        Me._IM_Denkyu_1 = New System.Windows.Forms.PictureBox()
        Me._IM_NEXTCM_1 = New System.Windows.Forms.PictureBox()
        Me._IM_NEXTCM_0 = New System.Windows.Forms.PictureBox()
        Me._IM_PREV_0 = New System.Windows.Forms.PictureBox()
        Me._IM_PREV_1 = New System.Windows.Forms.PictureBox()
        Me._IM_Hardcopy_0 = New System.Windows.Forms.PictureBox()
        Me._IM_Slist_0 = New System.Windows.Forms.PictureBox()
        Me._IM_EndCm_1 = New System.Windows.Forms.PictureBox()
        Me._IM_EndCm_0 = New System.Windows.Forms.PictureBox()
        Me._IM_Slist_1 = New System.Windows.Forms.PictureBox()
        Me._IM_Hardcopy_1 = New System.Windows.Forms.PictureBox()
        Me._FM_Panel3D1_21 = New System.Windows.Forms.Label()
        Me.SYSDT = New System.Windows.Forms.Label()
        Me.CM_Execute = New System.Windows.Forms.PictureBox()
        Me.CM_SLIST = New System.Windows.Forms.PictureBox()
        Me.CM_EndCm = New System.Windows.Forms.PictureBox()
        Me.CM_NEXTCM = New System.Windows.Forms.PictureBox()
        Me.CM_PREV = New System.Windows.Forms.PictureBox()
        Me.CM_SELECTCM = New System.Windows.Forms.PictureBox()
        Me.Image1 = New System.Windows.Forms.PictureBox()
        Me.TM_StartUp = New System.Windows.Forms.Timer(Me.components)
        Me.TX_CursorRest = New System.Windows.Forms.TextBox()
        Me._FM_Panel3D1_0 = New System.Windows.Forms.Label()
        Me._IM_Opt_1 = New System.Windows.Forms.PictureBox()
        Me._IM_Opt_0 = New System.Windows.Forms.PictureBox()
        Me.FM_Panel3D1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.FM_Panel3D4 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.IM_Denkyu = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_EndCm = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_Execute = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_Hardcopy = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_NEXTCM = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_Opt = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_PREV = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_SELECTCM = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_Slist = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.MN_Ctrl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Execute = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_HARDCOPY = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Bar11 = New System.Windows.Forms.ToolStripSeparator()
        Me.MN_EndCm = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_EditMn = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_ClearItm = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_UnDoItem = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Bar21 = New System.Windows.Forms.ToolStripSeparator()
        Me.MN_Cut = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Copy = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Paste = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Oprt = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_SELECTCM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_PREV = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_NEXTCM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Bar31 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me._FM_Panel3D1_28 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_27 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TL_Cursol_Wk_2 = New System.Windows.Forms.TextBox()
        Me.HD_Cursol_Wk_1 = New System.Windows.Forms.TextBox()
        Me.HD_Cursol_Wk_2 = New System.Windows.Forms.TextBox()
        Me.HD_Cursol_Wk_3 = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._FM_Panel3D1_23.SuspendLayout()
        Me._FM_Panel3D1_22.SuspendLayout()
        Me._FM_Panel3D4_1.SuspendLayout()
        CType(Me._IM_Execute_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Execute_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_SELECTCM_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_SELECTCM_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Denkyu_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Denkyu_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_NEXTCM_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_NEXTCM_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_PREV_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_PREV_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Hardcopy_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Slist_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_EndCm_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_EndCm_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Slist_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Hardcopy_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._FM_Panel3D1_21.SuspendLayout()
        CType(Me.CM_Execute, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_SLIST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_EndCm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_NEXTCM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_PREV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_SELECTCM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Opt_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Opt_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FM_Panel3D4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_Denkyu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_EndCm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_Execute, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_Hardcopy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_NEXTCM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_Opt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_PREV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_SELECTCM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_Slist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Label1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._FM_Panel3D1_28.SuspendLayout()
        Me._FM_Panel3D1_27.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'HD_IN_TANNM
        '
        Me.HD_IN_TANNM.AcceptsReturn = True
        Me.HD_IN_TANNM.BackColor = System.Drawing.SystemColors.Control
        Me.HD_IN_TANNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_IN_TANNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_IN_TANNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_IN_TANNM.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_IN_TANNM.Location = New System.Drawing.Point(860, 43)
        Me.HD_IN_TANNM.MaxLength = 24
        Me.HD_IN_TANNM.Name = "HD_IN_TANNM"
        Me.HD_IN_TANNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_IN_TANNM.Size = New System.Drawing.Size(151, 20)
        Me.HD_IN_TANNM.TabIndex = 9
        Me.HD_IN_TANNM.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'HD_IN_TANCD
        '
        Me.HD_IN_TANCD.AcceptsReturn = True
        Me.HD_IN_TANCD.BackColor = System.Drawing.SystemColors.Control
        Me.HD_IN_TANCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_IN_TANCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_IN_TANCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_IN_TANCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_IN_TANCD.Location = New System.Drawing.Point(806, 43)
        Me.HD_IN_TANCD.MaxLength = 10
        Me.HD_IN_TANCD.Name = "HD_IN_TANCD"
        Me.HD_IN_TANCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_IN_TANCD.Size = New System.Drawing.Size(56, 20)
        Me.HD_IN_TANCD.TabIndex = 8
        Me.HD_IN_TANCD.Text = "XXXXX6"
        '
        '_FM_Panel3D1_23
        '
        Me._FM_Panel3D1_23.Controls.Add(Me._FM_Panel3D1_22)
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_23, CType(23, Short))
        Me._FM_Panel3D1_23.Location = New System.Drawing.Point(-3, 615)
        Me._FM_Panel3D1_23.Name = "_FM_Panel3D1_23"
        Me._FM_Panel3D1_23.Size = New System.Drawing.Size(1022, 49)
        Me._FM_Panel3D1_23.TabIndex = 5
        '
        '_FM_Panel3D1_22
        '
        Me._FM_Panel3D1_22.Controls.Add(Me.TX_Message)
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_22, CType(22, Short))
        Me._FM_Panel3D1_22.Location = New System.Drawing.Point(45, 9)
        Me._FM_Panel3D1_22.Name = "_FM_Panel3D1_22"
        Me._FM_Panel3D1_22.Size = New System.Drawing.Size(961, 31)
        Me._FM_Panel3D1_22.TabIndex = 6
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
        Me.TX_Message.Size = New System.Drawing.Size(484, 16)
        Me.TX_Message.TabIndex = 7
        Me.TX_Message.Text = "エラーやプロンプトのメッセージが出力されるところです。"
        Me.TX_Message.Visible = False
        '
        '_FM_Panel3D4_1
        '
        Me._FM_Panel3D4_1.Controls.Add(Me.TX_Mode)
        Me._FM_Panel3D4_1.Controls.Add(Me._IM_Execute_1)
        Me._FM_Panel3D4_1.Controls.Add(Me._IM_Execute_0)
        Me._FM_Panel3D4_1.Controls.Add(Me._IM_SELECTCM_1)
        Me._FM_Panel3D4_1.Controls.Add(Me._IM_SELECTCM_0)
        Me._FM_Panel3D4_1.Controls.Add(Me._IM_Denkyu_2)
        Me._FM_Panel3D4_1.Controls.Add(Me._IM_Denkyu_1)
        Me._FM_Panel3D4_1.Controls.Add(Me._IM_NEXTCM_1)
        Me._FM_Panel3D4_1.Controls.Add(Me._IM_NEXTCM_0)
        Me._FM_Panel3D4_1.Controls.Add(Me._IM_PREV_0)
        Me._FM_Panel3D4_1.Controls.Add(Me._IM_PREV_1)
        Me._FM_Panel3D4_1.Controls.Add(Me._IM_Hardcopy_0)
        Me._FM_Panel3D4_1.Controls.Add(Me._IM_Slist_0)
        Me._FM_Panel3D4_1.Controls.Add(Me._IM_EndCm_1)
        Me._FM_Panel3D4_1.Controls.Add(Me._IM_EndCm_0)
        Me._FM_Panel3D4_1.Controls.Add(Me._IM_Slist_1)
        Me._FM_Panel3D4_1.Controls.Add(Me._IM_Hardcopy_1)
        Me.FM_Panel3D4.SetIndex(Me._FM_Panel3D4_1, CType(1, Short))
        Me._FM_Panel3D4_1.Location = New System.Drawing.Point(7, 749)
        Me._FM_Panel3D4_1.Name = "_FM_Panel3D4_1"
        Me._FM_Panel3D4_1.Size = New System.Drawing.Size(841, 58)
        Me._FM_Panel3D4_1.TabIndex = 3
        '
        'TX_Mode
        '
        Me.TX_Mode.AcceptsReturn = True
        Me.TX_Mode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TX_Mode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TX_Mode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TX_Mode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TX_Mode.Location = New System.Drawing.Point(813, 3)
        Me.TX_Mode.MaxLength = 0
        Me.TX_Mode.Name = "TX_Mode"
        Me.TX_Mode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_Mode.Size = New System.Drawing.Size(58, 20)
        Me.TX_Mode.TabIndex = 4
        Me.TX_Mode.Text = "ﾓｰﾄﾞ"
        '
        '_IM_Execute_1
        '
        Me._IM_Execute_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Execute_1.Image = CType(resources.GetObject("_IM_Execute_1.Image"), System.Drawing.Image)
        Me.IM_Execute.SetIndex(Me._IM_Execute_1, CType(1, Short))
        Me._IM_Execute_1.Location = New System.Drawing.Point(441, 12)
        Me._IM_Execute_1.Name = "_IM_Execute_1"
        Me._IM_Execute_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_Execute_1.TabIndex = 5
        Me._IM_Execute_1.TabStop = False
        '
        '_IM_Execute_0
        '
        Me._IM_Execute_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Execute_0.Image = CType(resources.GetObject("_IM_Execute_0.Image"), System.Drawing.Image)
        Me.IM_Execute.SetIndex(Me._IM_Execute_0, CType(0, Short))
        Me._IM_Execute_0.Location = New System.Drawing.Point(420, 12)
        Me._IM_Execute_0.Name = "_IM_Execute_0"
        Me._IM_Execute_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_Execute_0.TabIndex = 6
        Me._IM_Execute_0.TabStop = False
        '
        '_IM_SELECTCM_1
        '
        Me._IM_SELECTCM_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_SELECTCM_1.Image = CType(resources.GetObject("_IM_SELECTCM_1.Image"), System.Drawing.Image)
        Me.IM_SELECTCM.SetIndex(Me._IM_SELECTCM_1, CType(1, Short))
        Me._IM_SELECTCM_1.Location = New System.Drawing.Point(195, 3)
        Me._IM_SELECTCM_1.Name = "_IM_SELECTCM_1"
        Me._IM_SELECTCM_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_SELECTCM_1.TabIndex = 7
        Me._IM_SELECTCM_1.TabStop = False
        '
        '_IM_SELECTCM_0
        '
        Me._IM_SELECTCM_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_SELECTCM_0.Image = CType(resources.GetObject("_IM_SELECTCM_0.Image"), System.Drawing.Image)
        Me.IM_SELECTCM.SetIndex(Me._IM_SELECTCM_0, CType(0, Short))
        Me._IM_SELECTCM_0.Location = New System.Drawing.Point(171, 3)
        Me._IM_SELECTCM_0.Name = "_IM_SELECTCM_0"
        Me._IM_SELECTCM_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_SELECTCM_0.TabIndex = 8
        Me._IM_SELECTCM_0.TabStop = False
        '
        '_IM_Denkyu_2
        '
        Me._IM_Denkyu_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_2.Image = CType(resources.GetObject("_IM_Denkyu_2.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_2, CType(2, Short))
        Me._IM_Denkyu_2.Location = New System.Drawing.Point(498, 3)
        Me._IM_Denkyu_2.Name = "_IM_Denkyu_2"
        Me._IM_Denkyu_2.Size = New System.Drawing.Size(20, 22)
        Me._IM_Denkyu_2.TabIndex = 9
        Me._IM_Denkyu_2.TabStop = False
        '
        '_IM_Denkyu_1
        '
        Me._IM_Denkyu_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_1.Image = CType(resources.GetObject("_IM_Denkyu_1.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_1, CType(1, Short))
        Me._IM_Denkyu_1.Location = New System.Drawing.Point(477, 3)
        Me._IM_Denkyu_1.Name = "_IM_Denkyu_1"
        Me._IM_Denkyu_1.Size = New System.Drawing.Size(20, 22)
        Me._IM_Denkyu_1.TabIndex = 10
        Me._IM_Denkyu_1.TabStop = False
        '
        '_IM_NEXTCM_1
        '
        Me._IM_NEXTCM_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_NEXTCM_1.Image = CType(resources.GetObject("_IM_NEXTCM_1.Image"), System.Drawing.Image)
        Me.IM_NEXTCM.SetIndex(Me._IM_NEXTCM_1, CType(1, Short))
        Me._IM_NEXTCM_1.Location = New System.Drawing.Point(390, 3)
        Me._IM_NEXTCM_1.Name = "_IM_NEXTCM_1"
        Me._IM_NEXTCM_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_NEXTCM_1.TabIndex = 11
        Me._IM_NEXTCM_1.TabStop = False
        Me._IM_NEXTCM_1.Visible = False
        '
        '_IM_NEXTCM_0
        '
        Me._IM_NEXTCM_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_NEXTCM_0.Image = CType(resources.GetObject("_IM_NEXTCM_0.Image"), System.Drawing.Image)
        Me.IM_NEXTCM.SetIndex(Me._IM_NEXTCM_0, CType(0, Short))
        Me._IM_NEXTCM_0.Location = New System.Drawing.Point(366, 3)
        Me._IM_NEXTCM_0.Name = "_IM_NEXTCM_0"
        Me._IM_NEXTCM_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_NEXTCM_0.TabIndex = 12
        Me._IM_NEXTCM_0.TabStop = False
        Me._IM_NEXTCM_0.Visible = False
        '
        '_IM_PREV_0
        '
        Me._IM_PREV_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_PREV_0.Image = CType(resources.GetObject("_IM_PREV_0.Image"), System.Drawing.Image)
        Me.IM_PREV.SetIndex(Me._IM_PREV_0, CType(0, Short))
        Me._IM_PREV_0.Location = New System.Drawing.Point(318, 3)
        Me._IM_PREV_0.Name = "_IM_PREV_0"
        Me._IM_PREV_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_PREV_0.TabIndex = 13
        Me._IM_PREV_0.TabStop = False
        Me._IM_PREV_0.Visible = False
        '
        '_IM_PREV_1
        '
        Me._IM_PREV_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_PREV_1.Image = CType(resources.GetObject("_IM_PREV_1.Image"), System.Drawing.Image)
        Me.IM_PREV.SetIndex(Me._IM_PREV_1, CType(1, Short))
        Me._IM_PREV_1.Location = New System.Drawing.Point(342, 3)
        Me._IM_PREV_1.Name = "_IM_PREV_1"
        Me._IM_PREV_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_PREV_1.TabIndex = 14
        Me._IM_PREV_1.TabStop = False
        Me._IM_PREV_1.Visible = False
        '
        '_IM_Hardcopy_0
        '
        Me._IM_Hardcopy_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Hardcopy_0.Image = CType(resources.GetObject("_IM_Hardcopy_0.Image"), System.Drawing.Image)
        Me.IM_Hardcopy.SetIndex(Me._IM_Hardcopy_0, CType(0, Short))
        Me._IM_Hardcopy_0.Location = New System.Drawing.Point(102, 3)
        Me._IM_Hardcopy_0.Name = "_IM_Hardcopy_0"
        Me._IM_Hardcopy_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_Hardcopy_0.TabIndex = 15
        Me._IM_Hardcopy_0.TabStop = False
        Me._IM_Hardcopy_0.Visible = False
        '
        '_IM_Slist_0
        '
        Me._IM_Slist_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Slist_0.Image = CType(resources.GetObject("_IM_Slist_0.Image"), System.Drawing.Image)
        Me.IM_Slist.SetIndex(Me._IM_Slist_0, CType(0, Short))
        Me._IM_Slist_0.Location = New System.Drawing.Point(261, 3)
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
        Me._IM_EndCm_1.Location = New System.Drawing.Point(33, 3)
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
        Me._IM_EndCm_0.Location = New System.Drawing.Point(9, 3)
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
        Me._IM_Slist_1.Location = New System.Drawing.Point(285, 3)
        Me._IM_Slist_1.Name = "_IM_Slist_1"
        Me._IM_Slist_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_Slist_1.TabIndex = 19
        Me._IM_Slist_1.TabStop = False
        Me._IM_Slist_1.Visible = False
        '
        '_IM_Hardcopy_1
        '
        Me._IM_Hardcopy_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Hardcopy_1.Image = CType(resources.GetObject("_IM_Hardcopy_1.Image"), System.Drawing.Image)
        Me.IM_Hardcopy.SetIndex(Me._IM_Hardcopy_1, CType(1, Short))
        Me._IM_Hardcopy_1.Location = New System.Drawing.Point(126, 3)
        Me._IM_Hardcopy_1.Name = "_IM_Hardcopy_1"
        Me._IM_Hardcopy_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_Hardcopy_1.TabIndex = 20
        Me._IM_Hardcopy_1.TabStop = False
        Me._IM_Hardcopy_1.Visible = False
        '
        '_FM_Panel3D1_21
        '
        Me._FM_Panel3D1_21.Controls.Add(Me.SYSDT)
        Me._FM_Panel3D1_21.Controls.Add(Me.CM_Execute)
        Me._FM_Panel3D1_21.Controls.Add(Me.CM_SLIST)
        Me._FM_Panel3D1_21.Controls.Add(Me.CM_EndCm)
        Me._FM_Panel3D1_21.Controls.Add(Me.CM_NEXTCM)
        Me._FM_Panel3D1_21.Controls.Add(Me.CM_PREV)
        Me._FM_Panel3D1_21.Controls.Add(Me.CM_SELECTCM)
        Me._FM_Panel3D1_21.Controls.Add(Me.Image1)
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_21, CType(21, Short))
        Me._FM_Panel3D1_21.Location = New System.Drawing.Point(-4, 0)
        Me._FM_Panel3D1_21.Name = "_FM_Panel3D1_21"
        Me._FM_Panel3D1_21.Size = New System.Drawing.Size(1028, 37)
        Me._FM_Panel3D1_21.TabIndex = 1
        '
        'SYSDT
        '
        Me.SYSDT.Location = New System.Drawing.Point(902, 7)
        Me.SYSDT.Name = "SYSDT"
        Me.SYSDT.Size = New System.Drawing.Size(110, 22)
        Me.SYSDT.TabIndex = 2
        Me.SYSDT.Text = "YYYY/MM/DD"
        '
        'CM_Execute
        '
        Me.CM_Execute.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_Execute.Image = CType(resources.GetObject("CM_Execute.Image"), System.Drawing.Image)
        Me.CM_Execute.Location = New System.Drawing.Point(40, 6)
        Me.CM_Execute.Name = "CM_Execute"
        Me.CM_Execute.Size = New System.Drawing.Size(24, 22)
        Me.CM_Execute.TabIndex = 3
        Me.CM_Execute.TabStop = False
        Me.CM_Execute.Visible = False
        '
        'CM_SLIST
        '
        Me.CM_SLIST.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_SLIST.Image = CType(resources.GetObject("CM_SLIST.Image"), System.Drawing.Image)
        Me.CM_SLIST.Location = New System.Drawing.Point(64, 6)
        Me.CM_SLIST.Name = "CM_SLIST"
        Me.CM_SLIST.Size = New System.Drawing.Size(24, 22)
        Me.CM_SLIST.TabIndex = 4
        Me.CM_SLIST.TabStop = False
        Me.CM_SLIST.Visible = False
        '
        'CM_EndCm
        '
        Me.CM_EndCm.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_EndCm.Image = CType(resources.GetObject("CM_EndCm.Image"), System.Drawing.Image)
        Me.CM_EndCm.Location = New System.Drawing.Point(16, 6)
        Me.CM_EndCm.Name = "CM_EndCm"
        Me.CM_EndCm.Size = New System.Drawing.Size(24, 22)
        Me.CM_EndCm.TabIndex = 5
        Me.CM_EndCm.TabStop = False
        Me.CM_EndCm.Visible = False
        '
        'CM_NEXTCM
        '
        Me.CM_NEXTCM.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_NEXTCM.Image = CType(resources.GetObject("CM_NEXTCM.Image"), System.Drawing.Image)
        Me.CM_NEXTCM.Location = New System.Drawing.Point(155, 6)
        Me.CM_NEXTCM.Name = "CM_NEXTCM"
        Me.CM_NEXTCM.Size = New System.Drawing.Size(24, 22)
        Me.CM_NEXTCM.TabIndex = 6
        Me.CM_NEXTCM.TabStop = False
        Me.CM_NEXTCM.Visible = False
        '
        'CM_PREV
        '
        Me.CM_PREV.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_PREV.Image = CType(resources.GetObject("CM_PREV.Image"), System.Drawing.Image)
        Me.CM_PREV.Location = New System.Drawing.Point(131, 6)
        Me.CM_PREV.Name = "CM_PREV"
        Me.CM_PREV.Size = New System.Drawing.Size(24, 22)
        Me.CM_PREV.TabIndex = 7
        Me.CM_PREV.TabStop = False
        Me.CM_PREV.Visible = False
        '
        'CM_SELECTCM
        '
        Me.CM_SELECTCM.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_SELECTCM.Image = CType(resources.GetObject("CM_SELECTCM.Image"), System.Drawing.Image)
        Me.CM_SELECTCM.Location = New System.Drawing.Point(98, 6)
        Me.CM_SELECTCM.Name = "CM_SELECTCM"
        Me.CM_SELECTCM.Size = New System.Drawing.Size(24, 22)
        Me.CM_SELECTCM.TabIndex = 8
        Me.CM_SELECTCM.TabStop = False
        Me.CM_SELECTCM.Visible = False
        '
        'Image1
        '
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Location = New System.Drawing.Point(0, -1)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(1026, 37)
        Me.Image1.TabIndex = 9
        Me.Image1.TabStop = False
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
        Me.TX_CursorRest.Location = New System.Drawing.Point(2892, 2892)
        Me.TX_CursorRest.MaxLength = 0
        Me.TX_CursorRest.Name = "TX_CursorRest"
        Me.TX_CursorRest.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_CursorRest.Size = New System.Drawing.Size(22, 13)
        Me.TX_CursorRest.TabIndex = 0
        '
        '_FM_Panel3D1_0
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_0, CType(0, Short))
        Me._FM_Panel3D1_0.Location = New System.Drawing.Point(723, 43)
        Me._FM_Panel3D1_0.Name = "_FM_Panel3D1_0"
        Me._FM_Panel3D1_0.Size = New System.Drawing.Size(85, 23)
        Me._FM_Panel3D1_0.TabIndex = 10
        Me._FM_Panel3D1_0.Text = "  照会者名"
        '
        '_IM_Opt_1
        '
        Me._IM_Opt_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Opt_1.Image = CType(resources.GetObject("_IM_Opt_1.Image"), System.Drawing.Image)
        Me.IM_Opt.SetIndex(Me._IM_Opt_1, CType(1, Short))
        Me._IM_Opt_1.Location = New System.Drawing.Point(168, 1059)
        Me._IM_Opt_1.Name = "_IM_Opt_1"
        Me._IM_Opt_1.Size = New System.Drawing.Size(18, 18)
        Me._IM_Opt_1.TabIndex = 19
        Me._IM_Opt_1.TabStop = False
        '
        '_IM_Opt_0
        '
        Me._IM_Opt_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Opt_0.Image = CType(resources.GetObject("_IM_Opt_0.Image"), System.Drawing.Image)
        Me.IM_Opt.SetIndex(Me._IM_Opt_0, CType(0, Short))
        Me._IM_Opt_0.Location = New System.Drawing.Point(112, 1059)
        Me._IM_Opt_0.Name = "_IM_Opt_0"
        Me._IM_Opt_0.Size = New System.Drawing.Size(18, 19)
        Me._IM_Opt_0.TabIndex = 20
        Me._IM_Opt_0.TabStop = False
        '
        'MainMenu1
        '
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(1018, 24)
        Me.MainMenu1.TabIndex = 21
        '
        'MN_Ctrl
        '
        Me.MN_Ctrl.Name = "MN_Ctrl"
        Me.MN_Ctrl.Size = New System.Drawing.Size(61, 4)
        Me.MN_Ctrl.Text = "処理(&1)"
        '
        'MN_Execute
        '
        Me.MN_Execute.Name = "MN_Execute"
        Me.MN_Execute.Size = New System.Drawing.Size(61, 4)
        Me.MN_Execute.Text = "実行(&R)"
        '
        'MN_HARDCOPY
        '
        Me.MN_HARDCOPY.Enabled = False
        Me.MN_HARDCOPY.Name = "MN_HARDCOPY"
        Me.MN_HARDCOPY.Size = New System.Drawing.Size(61, 4)
        Me.MN_HARDCOPY.Text = "画面印刷"
        '
        'Bar11
        '
        Me.Bar11.Name = "Bar11"
        Me.Bar11.Size = New System.Drawing.Size(6, 6)
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
        Me.MN_Cut.Text = "切り取り(&T)"
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
        Me.MN_Paste.Text = "貼り付け(&P)"
        '
        'MN_Oprt
        '
        Me.MN_Oprt.Name = "MN_Oprt"
        Me.MN_Oprt.Size = New System.Drawing.Size(61, 4)
        Me.MN_Oprt.Text = "操作(&3)"
        '
        'MN_SELECTCM
        '
        Me.MN_SELECTCM.Name = "MN_SELECTCM"
        Me.MN_SELECTCM.Size = New System.Drawing.Size(61, 4)
        Me.MN_SELECTCM.Text = "選択"
        '
        'MN_PREV
        '
        Me.MN_PREV.Name = "MN_PREV"
        Me.MN_PREV.Size = New System.Drawing.Size(61, 4)
        Me.MN_PREV.Text = "前頁"
        '
        'MN_NEXTCM
        '
        Me.MN_NEXTCM.Name = "MN_NEXTCM"
        Me.MN_NEXTCM.Size = New System.Drawing.Size(61, 4)
        Me.MN_NEXTCM.Text = "次頁"
        '
        'Bar31
        '
        Me.Bar31.Name = "Bar31"
        Me.Bar31.Size = New System.Drawing.Size(6, 6)
        '
        'MN_Slist
        '
        Me.MN_Slist.Name = "MN_Slist"
        Me.MN_Slist.Size = New System.Drawing.Size(61, 4)
        Me.MN_Slist.Text = "候補の一覧(&L&ﾆ)..."
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
        Me.btnF12.Enabled = False
        Me.btnF12.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF12.Location = New System.Drawing.Point(918, 618)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(75, 37)
        Me.btnF12.TabIndex = 285
        Me.btnF12.Text = "(F12)"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'btnF11
        '
        Me.btnF11.Enabled = False
        Me.btnF11.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF11.Location = New System.Drawing.Point(841, 618)
        Me.btnF11.Name = "btnF11"
        Me.btnF11.Size = New System.Drawing.Size(75, 37)
        Me.btnF11.TabIndex = 284
        Me.btnF11.Text = "(F11)"
        Me.btnF11.UseVisualStyleBackColor = True
        '
        'btnF10
        '
        Me.btnF10.Enabled = False
        Me.btnF10.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF10.Location = New System.Drawing.Point(763, 618)
        Me.btnF10.Name = "btnF10"
        Me.btnF10.Size = New System.Drawing.Size(75, 37)
        Me.btnF10.TabIndex = 283
        Me.btnF10.Text = "(F10)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF10.UseVisualStyleBackColor = True
        '
        'btnF9
        '
        Me.btnF9.Enabled = False
        Me.btnF9.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF9.Location = New System.Drawing.Point(686, 618)
        Me.btnF9.Name = "btnF9"
        Me.btnF9.Size = New System.Drawing.Size(75, 37)
        Me.btnF9.TabIndex = 282
        Me.btnF9.Text = "(F9)"
        Me.btnF9.UseVisualStyleBackColor = True
        '
        'btnF8
        '
        Me.btnF8.Enabled = False
        Me.btnF8.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF8.Location = New System.Drawing.Point(592, 618)
        Me.btnF8.Name = "btnF8"
        Me.btnF8.Size = New System.Drawing.Size(75, 37)
        Me.btnF8.TabIndex = 281
        Me.btnF8.Text = "(F8)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF8.UseVisualStyleBackColor = True
        '
        'btnF7
        '
        Me.btnF7.Enabled = False
        Me.btnF7.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF7.Location = New System.Drawing.Point(514, 618)
        Me.btnF7.Name = "btnF7"
        Me.btnF7.Size = New System.Drawing.Size(75, 37)
        Me.btnF7.TabIndex = 280
        Me.btnF7.Text = "(F7)"
        Me.btnF7.UseVisualStyleBackColor = True
        '
        'btnF6
        '
        Me.btnF6.Enabled = False
        Me.btnF6.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF6.Location = New System.Drawing.Point(436, 618)
        Me.btnF6.Name = "btnF6"
        Me.btnF6.Size = New System.Drawing.Size(75, 37)
        Me.btnF6.TabIndex = 279
        Me.btnF6.Text = "(F6)"
        Me.btnF6.UseVisualStyleBackColor = True
        '
        'btnF5
        '
        Me.btnF5.Enabled = False
        Me.btnF5.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF5.Location = New System.Drawing.Point(358, 618)
        Me.btnF5.Name = "btnF5"
        Me.btnF5.Size = New System.Drawing.Size(75, 37)
        Me.btnF5.TabIndex = 278
        Me.btnF5.Text = "(F5)"
        Me.btnF5.UseVisualStyleBackColor = True
        '
        'btnF4
        '
        Me.btnF4.Enabled = False
        Me.btnF4.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF4.Location = New System.Drawing.Point(264, 618)
        Me.btnF4.Name = "btnF4"
        Me.btnF4.Size = New System.Drawing.Size(75, 37)
        Me.btnF4.TabIndex = 277
        Me.btnF4.Text = "(F4)"
        Me.btnF4.UseVisualStyleBackColor = True
        '
        'btnF3
        '
        Me.btnF3.Enabled = False
        Me.btnF3.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF3.Location = New System.Drawing.Point(185, 618)
        Me.btnF3.Name = "btnF3"
        Me.btnF3.Size = New System.Drawing.Size(75, 37)
        Me.btnF3.TabIndex = 276
        Me.btnF3.Text = "(F3)"
        Me.btnF3.UseVisualStyleBackColor = True
        '
        'btnF2
        '
        Me.btnF2.Enabled = False
        Me.btnF2.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF2.Location = New System.Drawing.Point(106, 618)
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(75, 35)
        Me.btnF2.TabIndex = 275
        Me.btnF2.Text = "(F2)"
        Me.btnF2.UseVisualStyleBackColor = True
        '
        'btnF1
        '
        Me.btnF1.Enabled = False
        Me.btnF1.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF1.Location = New System.Drawing.Point(27, 618)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(75, 35)
        Me.btnF1.TabIndex = 274
        Me.btnF1.Text = "(F1)"
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Controls.Add(Me.Label2)
        Me.Label1.Controls.Add(Me.PictureBox1)
        Me.Label1.Location = New System.Drawing.Point(19, 620)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(888, 40)
        Me.Label1.TabIndex = 267
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(50, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(750, 31)
        Me.Label2.TabIndex = 63
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(26, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 22)
        Me.PictureBox1.TabIndex = 64
        Me.PictureBox1.TabStop = False
        '
        'TextBox4
        '
        Me.TextBox4.AcceptsReturn = True
        Me.TextBox4.BackColor = System.Drawing.Color.White
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox4.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox4.Location = New System.Drawing.Point(722, 630)
        Me.TextBox4.MaxLength = 0
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox4.Size = New System.Drawing.Size(37, 20)
        Me.TextBox4.TabIndex = 269
        Me.TextBox4.Text = "HD_Cursol_Wk_2"
        '
        'TextBox5
        '
        Me.TextBox5.AcceptsReturn = True
        Me.TextBox5.BackColor = System.Drawing.Color.White
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox5.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox5.Location = New System.Drawing.Point(675, 630)
        Me.TextBox5.MaxLength = 0
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox5.Size = New System.Drawing.Size(46, 20)
        Me.TextBox5.TabIndex = 268
        Me.TextBox5.Text = "TextBox5"
        '
        'TextBox6
        '
        Me.TextBox6.AcceptsReturn = True
        Me.TextBox6.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox6.Location = New System.Drawing.Point(638, 625)
        Me.TextBox6.MaxLength = 0
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox6.Size = New System.Drawing.Size(102, 20)
        Me.TextBox6.TabIndex = 272
        Me.TextBox6.Text = "Text1"
        '
        'TextBox7
        '
        Me.TextBox7.AcceptsReturn = True
        Me.TextBox7.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox7.Location = New System.Drawing.Point(724, 626)
        Me.TextBox7.MaxLength = 0
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox7.Size = New System.Drawing.Size(102, 20)
        Me.TextBox7.TabIndex = 273
        Me.TextBox7.Text = "Text1"
        '
        'RadioButton1
        '
        Me.RadioButton1.BackColor = System.Drawing.SystemColors.Control
        Me.RadioButton1.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadioButton1.Enabled = False
        Me.RadioButton1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioButton1.Location = New System.Drawing.Point(727, 631)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadioButton1.Size = New System.Drawing.Size(86, 21)
        Me.RadioButton1.TabIndex = 270
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "受注"
        Me.RadioButton1.UseVisualStyleBackColor = False
        Me.RadioButton1.Visible = False
        '
        'RadioButton2
        '
        Me.RadioButton2.BackColor = System.Drawing.SystemColors.Control
        Me.RadioButton2.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadioButton2.Enabled = False
        Me.RadioButton2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioButton2.Location = New System.Drawing.Point(641, 628)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadioButton2.Size = New System.Drawing.Size(86, 21)
        Me.RadioButton2.TabIndex = 271
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "支給出庫"
        Me.RadioButton2.UseVisualStyleBackColor = False
        Me.RadioButton2.Visible = False
        '
        '_FM_Panel3D1_28
        '
        Me._FM_Panel3D1_28.Controls.Add(Me._FM_Panel3D1_27)
        Me._FM_Panel3D1_28.Controls.Add(Me.PictureBox2)
        Me._FM_Panel3D1_28.Location = New System.Drawing.Point(19, 617)
        Me._FM_Panel3D1_28.Name = "_FM_Panel3D1_28"
        Me._FM_Panel3D1_28.Size = New System.Drawing.Size(888, 40)
        Me._FM_Panel3D1_28.TabIndex = 262
        '
        '_FM_Panel3D1_27
        '
        Me._FM_Panel3D1_27.Controls.Add(Me.TextBox1)
        Me._FM_Panel3D1_27.Location = New System.Drawing.Point(50, 4)
        Me._FM_Panel3D1_27.Name = "_FM_Panel3D1_27"
        Me._FM_Panel3D1_27.Size = New System.Drawing.Size(750, 31)
        Me._FM_Panel3D1_27.TabIndex = 63
        '
        'TextBox1
        '
        Me.TextBox1.AcceptsReturn = True
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(7, 8)
        Me.TextBox1.MaxLength = 0
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox1.Size = New System.Drawing.Size(667, 16)
        Me.TextBox1.TabIndex = 64
        Me.TextBox1.Text = "エラーやプロンプトのメッセージが出力されるところです。"
        Me.TextBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(26, 8)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(20, 22)
        Me.PictureBox2.TabIndex = 64
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TL_Cursol_Wk_2
        '
        Me.TL_Cursol_Wk_2.AcceptsReturn = True
        Me.TL_Cursol_Wk_2.BackColor = System.Drawing.Color.White
        Me.TL_Cursol_Wk_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TL_Cursol_Wk_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TL_Cursol_Wk_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TL_Cursol_Wk_2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TL_Cursol_Wk_2.Location = New System.Drawing.Point(722, 632)
        Me.TL_Cursol_Wk_2.MaxLength = 0
        Me.TL_Cursol_Wk_2.Name = "TL_Cursol_Wk_2"
        Me.TL_Cursol_Wk_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TL_Cursol_Wk_2.Size = New System.Drawing.Size(37, 20)
        Me.TL_Cursol_Wk_2.TabIndex = 264
        Me.TL_Cursol_Wk_2.Text = "HD_Cursol_Wk_2"
        '
        'HD_Cursol_Wk_1
        '
        Me.HD_Cursol_Wk_1.AcceptsReturn = True
        Me.HD_Cursol_Wk_1.BackColor = System.Drawing.Color.White
        Me.HD_Cursol_Wk_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_Cursol_Wk_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_Cursol_Wk_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_Cursol_Wk_1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_Cursol_Wk_1.Location = New System.Drawing.Point(675, 632)
        Me.HD_Cursol_Wk_1.MaxLength = 0
        Me.HD_Cursol_Wk_1.Name = "HD_Cursol_Wk_1"
        Me.HD_Cursol_Wk_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_Cursol_Wk_1.Size = New System.Drawing.Size(46, 20)
        Me.HD_Cursol_Wk_1.TabIndex = 263
        Me.HD_Cursol_Wk_1.Text = "HD_Cursol_Wk_1"
        '
        'HD_Cursol_Wk_2
        '
        Me.HD_Cursol_Wk_2.AcceptsReturn = True
        Me.HD_Cursol_Wk_2.BackColor = System.Drawing.SystemColors.Window
        Me.HD_Cursol_Wk_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_Cursol_Wk_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_Cursol_Wk_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_Cursol_Wk_2.Location = New System.Drawing.Point(638, 627)
        Me.HD_Cursol_Wk_2.MaxLength = 0
        Me.HD_Cursol_Wk_2.Name = "HD_Cursol_Wk_2"
        Me.HD_Cursol_Wk_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_Cursol_Wk_2.Size = New System.Drawing.Size(102, 20)
        Me.HD_Cursol_Wk_2.TabIndex = 265
        Me.HD_Cursol_Wk_2.Text = "Text1"
        '
        'HD_Cursol_Wk_3
        '
        Me.HD_Cursol_Wk_3.AcceptsReturn = True
        Me.HD_Cursol_Wk_3.BackColor = System.Drawing.SystemColors.Window
        Me.HD_Cursol_Wk_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_Cursol_Wk_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_Cursol_Wk_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_Cursol_Wk_3.Location = New System.Drawing.Point(724, 628)
        Me.HD_Cursol_Wk_3.MaxLength = 0
        Me.HD_Cursol_Wk_3.Name = "HD_Cursol_Wk_3"
        Me.HD_Cursol_Wk_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_Cursol_Wk_3.Size = New System.Drawing.Size(102, 20)
        Me.HD_Cursol_Wk_3.TabIndex = 266
        Me.HD_Cursol_Wk_3.Text = "Text1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 662)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1018, 23)
        Me.StatusStrip1.TabIndex = 286
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(200, 18)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "YYYY/MM/DD"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(200, 18)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "端末ID"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(200, 18)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Text = "ログインID"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(200, 18)
        Me.ToolStripStatusLabel4.Spring = True
        Me.ToolStripStatusLabel4.Text = "XXXXXXX"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(200, 18)
        Me.ToolStripStatusLabel5.Spring = True
        Me.ToolStripStatusLabel5.Text = "Ver.1.00"
        '
        'FR_SSSMAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1018, 685)
        Me.Controls.Add(Me.StatusStrip1)
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
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me._FM_Panel3D1_28)
        Me.Controls.Add(Me.TL_Cursol_Wk_2)
        Me.Controls.Add(Me.HD_Cursol_Wk_1)
        Me.Controls.Add(Me.HD_Cursol_Wk_2)
        Me.Controls.Add(Me.HD_Cursol_Wk_3)
        Me.Controls.Add(Me.HD_IN_TANNM)
        Me.Controls.Add(Me.HD_IN_TANCD)
        Me.Controls.Add(Me._FM_Panel3D1_23)
        Me.Controls.Add(Me._FM_Panel3D4_1)
        Me.Controls.Add(Me._FM_Panel3D1_21)
        Me.Controls.Add(Me.TX_CursorRest)
        Me.Controls.Add(Me._FM_Panel3D1_0)
        Me.Controls.Add(Me._IM_Opt_1)
        Me.Controls.Add(Me._IM_Opt_0)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("MS Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(31, 140)
        Me.MaximizeBox = False
        Me.Name = "FR_SSSMAIN"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "推定在庫照会"
        Me._FM_Panel3D1_23.ResumeLayout(False)
        Me._FM_Panel3D1_22.ResumeLayout(False)
        Me._FM_Panel3D1_22.PerformLayout()
        Me._FM_Panel3D4_1.ResumeLayout(False)
        Me._FM_Panel3D4_1.PerformLayout()
        CType(Me._IM_Execute_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Execute_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_SELECTCM_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_SELECTCM_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Denkyu_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Denkyu_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_NEXTCM_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_NEXTCM_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_PREV_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_PREV_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Hardcopy_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Slist_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_EndCm_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_EndCm_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Slist_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Hardcopy_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me._FM_Panel3D1_21.ResumeLayout(False)
        CType(Me.CM_Execute, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_SLIST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_EndCm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_NEXTCM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_PREV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_SELECTCM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Opt_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Opt_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FM_Panel3D4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_Denkyu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_EndCm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_Execute, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_Hardcopy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_NEXTCM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_Opt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_PREV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_SELECTCM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_Slist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Label1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me._FM_Panel3D1_28.ResumeLayout(False)
        Me._FM_Panel3D1_27.ResumeLayout(False)
        Me._FM_Panel3D1_27.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Public WithEvents Label1 As Label
    Public WithEvents Label2 As Label
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents TextBox4 As TextBox
    Public WithEvents TextBox5 As TextBox
    Public WithEvents TextBox6 As TextBox
    Public WithEvents TextBox7 As TextBox
    Public WithEvents RadioButton1 As RadioButton
    Public WithEvents RadioButton2 As RadioButton
    Public WithEvents _FM_Panel3D1_28 As Label
    Public WithEvents _FM_Panel3D1_27 As Label
    Public WithEvents TextBox1 As TextBox
    Public WithEvents PictureBox2 As PictureBox
    Public WithEvents TL_Cursol_Wk_2 As TextBox
    Public WithEvents HD_Cursol_Wk_1 As TextBox
    Public WithEvents HD_Cursol_Wk_2 As TextBox
    Public WithEvents HD_Cursol_Wk_3 As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
#End Region
End Class