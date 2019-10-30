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
	Public WithEvents HD_HINNMB As System.Windows.Forms.TextBox
    Public WithEvents SYSDT As Label
    Public WithEvents CM_Slist As System.Windows.Forms.PictureBox
	Public WithEvents CM_EndCm As System.Windows.Forms.PictureBox
	Public WithEvents CM_Execute As System.Windows.Forms.PictureBox
	Public WithEvents Image1 As System.Windows.Forms.PictureBox
    Public WithEvents _FM_Panel3D1_0 As Label
    Public WithEvents TX_Message As System.Windows.Forms.TextBox
    Public WithEvents _FM_Panel3D1_3 As Label
    Public WithEvents _IM_Denkyu_0 As System.Windows.Forms.PictureBox
    Public WithEvents _FM_Panel3D1_2 As Label
    Public WithEvents HD_HINNMA As System.Windows.Forms.TextBox
	Public WithEvents HD_HINCD As System.Windows.Forms.TextBox
	Public WithEvents CS_HINCD As System.Windows.Forms.Label
	Public WithEvents Frm_Main As System.Windows.Forms.GroupBox
	Public WithEvents TX_Mode As System.Windows.Forms.TextBox
	Public WithEvents _IM_Denkyu_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Denkyu_2 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_LCONFIG_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_LCONFIG_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_FSTART_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_FSTART_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_VSTART_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_VSTART_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_LSTART_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Slist_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_EndCm_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_EndCm_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Slist_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_LSTART_0 As System.Windows.Forms.PictureBox
    Public WithEvents _FM_Panel3D2_0 As Label
    Public WithEvents TM_StartUp As System.Windows.Forms.Timer
	Public WithEvents TX_CursorRest As System.Windows.Forms.TextBox
    Public WithEvents _FM_Panel3D1_1 As Label
    Public WithEvents TX_Dummy As System.Windows.Forms.TextBox
	Public WithEvents _IM_Execute_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Execute_0 As System.Windows.Forms.PictureBox
    Public WithEvents FM_Panel3D1 As VB6.PanelArray
    Public WithEvents FM_Panel3D2 As VB6.PanelArray
    Public WithEvents IM_Denkyu As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_EndCm As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_Execute As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_FSTART As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_LCONFIG As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_LSTART As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_Slist As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_VSTART As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray



    Public WithEvents bar11 As System.Windows.Forms.ToolStripSeparator

    '2019/10/24 CHG START
    'Public WithEvents MN_Ctrl As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Execute As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_DeleteCM As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_HARDCOPY As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_EndCm As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_EditMn As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_APPENDC As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_ClearItm As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_UnDoItem As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_ClearDE As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_DeleteDE As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_InsertDE As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_UnDoDe As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Cut As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Copy As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Paste As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Oprt As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Slist As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents SM_AllCopy As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents SM_Esc As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents SM_FullPast As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents SM_FullPast As System.Windows.Forms.ContextMenuStrip
    Public WithEvents SM_Esc As System.Windows.Forms.ContextMenuStrip
    Public WithEvents SM_AllCopy As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Slist As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Oprt As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Paste As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Copy As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Cut As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_UnDoDe As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_InsertDE As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_DeleteDE As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_ClearDE As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_UnDoItem As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_ClearItm As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_APPENDC As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_EditMn As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_EndCm As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_HARDCOPY As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_DeleteCM As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Execute As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Ctrl As System.Windows.Forms.ContextMenuStrip
    '2019/10/24 CHG E N D
    Public WithEvents Bar21 As System.Windows.Forms.ToolStripSeparator





    Public WithEvents SM_ShortCut As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FR_SSSMAIN))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.HD_IN_TANNM = New System.Windows.Forms.TextBox
		Me.HD_IN_TANCD = New System.Windows.Forms.TextBox
		Me.HD_HINNMB = New System.Windows.Forms.TextBox
        Me._FM_Panel3D1_0 = New Label
        Me.SYSDT = New Label
        Me.CM_Slist = New System.Windows.Forms.PictureBox
		Me.CM_EndCm = New System.Windows.Forms.PictureBox
		Me.CM_Execute = New System.Windows.Forms.PictureBox
		Me.Image1 = New System.Windows.Forms.PictureBox
        Me._FM_Panel3D1_2 = New Label
        Me._FM_Panel3D1_3 = New Label
        Me.TX_Message = New System.Windows.Forms.TextBox
        Me._IM_Denkyu_0 = New System.Windows.Forms.PictureBox
		Me.Frm_Main = New System.Windows.Forms.GroupBox
		Me.HD_HINNMA = New System.Windows.Forms.TextBox
		Me.HD_HINCD = New System.Windows.Forms.TextBox
		Me.CS_HINCD = New System.Windows.Forms.Label
        Me._FM_Panel3D2_0 = New Label
        Me.TX_Mode = New System.Windows.Forms.TextBox
		Me._IM_Denkyu_1 = New System.Windows.Forms.PictureBox
		Me._IM_Denkyu_2 = New System.Windows.Forms.PictureBox
		Me._IM_LCONFIG_1 = New System.Windows.Forms.PictureBox
		Me._IM_LCONFIG_0 = New System.Windows.Forms.PictureBox
		Me._IM_FSTART_1 = New System.Windows.Forms.PictureBox
		Me._IM_FSTART_0 = New System.Windows.Forms.PictureBox
		Me._IM_VSTART_1 = New System.Windows.Forms.PictureBox
		Me._IM_VSTART_0 = New System.Windows.Forms.PictureBox
		Me._IM_LSTART_1 = New System.Windows.Forms.PictureBox
		Me._IM_Slist_1 = New System.Windows.Forms.PictureBox
		Me._IM_EndCm_0 = New System.Windows.Forms.PictureBox
		Me._IM_EndCm_1 = New System.Windows.Forms.PictureBox
		Me._IM_Slist_0 = New System.Windows.Forms.PictureBox
		Me._IM_LSTART_0 = New System.Windows.Forms.PictureBox
		Me.TM_StartUp = New System.Windows.Forms.Timer(components)
		Me.TX_CursorRest = New System.Windows.Forms.TextBox
        Me._FM_Panel3D1_1 = New Label
        Me.TX_Dummy = New System.Windows.Forms.TextBox
		Me._IM_Execute_1 = New System.Windows.Forms.PictureBox
		Me._IM_Execute_0 = New System.Windows.Forms.PictureBox
        Me.FM_Panel3D1 = New VB6.PanelArray(components)
        Me.FM_Panel3D2 = New VB6.PanelArray(components)
        Me.IM_Denkyu = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_EndCm = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_Execute = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_FSTART = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_LCONFIG = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_LSTART = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_Slist = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_VSTART = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip


        '2019/10/24 CHG START
        'Me.MN_Ctrl = New System.Windows.Forms.ToolStripMenuItem
        'Me.MN_Execute = New System.Windows.Forms.ToolStripMenuItem
        'Me.MN_DeleteCM = New System.Windows.Forms.ToolStripMenuItem
        'Me.MN_HARDCOPY = New System.Windows.Forms.ToolStripMenuItem
        'Me.MN_EndCm = New System.Windows.Forms.ToolStripMenuItem
        'Me.MN_EditMn = New System.Windows.Forms.ToolStripMenuItem
        'Me.MN_APPENDC = New System.Windows.Forms.ToolStripMenuItem
        'Me.MN_ClearItm = New System.Windows.Forms.ToolStripMenuItem
        'Me.MN_UnDoItem = New System.Windows.Forms.ToolStripMenuItem
        'Me.MN_ClearDE = New System.Windows.Forms.ToolStripMenuItem
        'Me.MN_DeleteDE = New System.Windows.Forms.ToolStripMenuItem
        'Me.MN_InsertDE = New System.Windows.Forms.ToolStripMenuItem
        'Me.MN_UnDoDe = New System.Windows.Forms.ToolStripMenuItem
        'Me.MN_Cut = New System.Windows.Forms.ToolStripMenuItem
        'Me.MN_Copy = New System.Windows.Forms.ToolStripMenuItem
        'Me.MN_Paste = New System.Windows.Forms.ToolStripMenuItem
        'Me.MN_Oprt = New System.Windows.Forms.ToolStripMenuItem
        'Me.MN_Slist = New System.Windows.Forms.ToolStripMenuItem
        'Me.SM_AllCopy = New System.Windows.Forms.ToolStripMenuItem
        'Me.SM_Esc = New System.Windows.Forms.ToolStripMenuItem
        'Me.SM_FullPast = New System.Windows.Forms.ToolStripMenuItem
        Me.SM_FullPast = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SM_Esc = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SM_AllCopy = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Slist = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Oprt = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Paste = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Copy = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Cut = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_UnDoDe = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_InsertDE = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_DeleteDE = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_ClearDE = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_UnDoItem = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_ClearItm = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_APPENDC = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_EditMn = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_EndCm = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_HARDCOPY = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_DeleteCM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Execute = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Ctrl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        '2019/10/24 CHG E N D
        Me.bar11 = New System.Windows.Forms.ToolStripSeparator

        Me.Bar21 = New System.Windows.Forms.ToolStripSeparator
        Me.SM_ShortCut = New System.Windows.Forms.ToolStripMenuItem



        Me._FM_Panel3D1_0.SuspendLayout()
		Me._FM_Panel3D1_2.SuspendLayout()
		Me._FM_Panel3D1_3.SuspendLayout()
		Me.Frm_Main.SuspendLayout()
		Me._FM_Panel3D2_0.SuspendLayout()
		Me.MainMenu1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.FM_Panel3D2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_Denkyu, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_EndCm, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_Execute, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_FSTART, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_LCONFIG, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_LSTART, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_Slist, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_VSTART, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "在庫引当一括解除処理"
		Me.ClientSize = New System.Drawing.Size(561, 259)
		Me.Location = New System.Drawing.Point(85, 231)
		Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Icon = CType(resources.GetObject("FR_SSSMAIN.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("FR_SSSMAIN.BackgroundImage"), System.Drawing.Image)
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
		Me.HD_IN_TANNM.AutoSize = False
		Me.HD_IN_TANNM.BackColor = System.Drawing.SystemColors.Control
		Me.HD_IN_TANNM.Size = New System.Drawing.Size(147, 23)
		Me.HD_IN_TANNM.IMEMode = System.Windows.Forms.ImeMode.Hiragana
		Me.HD_IN_TANNM.Location = New System.Drawing.Point(391, 43)
		Me.HD_IN_TANNM.Maxlength = 24
		Me.HD_IN_TANNM.TabIndex = 14
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
		Me.HD_IN_TANNM.TabStop = True
		Me.HD_IN_TANNM.Visible = True
		Me.HD_IN_TANNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_IN_TANNM.Name = "HD_IN_TANNM"
		Me.HD_IN_TANCD.AutoSize = False
		Me.HD_IN_TANCD.BackColor = System.Drawing.SystemColors.Control
		Me.HD_IN_TANCD.Size = New System.Drawing.Size(53, 23)
		Me.HD_IN_TANCD.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_IN_TANCD.Location = New System.Drawing.Point(339, 43)
		Me.HD_IN_TANCD.Maxlength = 10
		Me.HD_IN_TANCD.TabIndex = 13
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
		Me.HD_IN_TANCD.TabStop = True
		Me.HD_IN_TANCD.Visible = True
		Me.HD_IN_TANCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_IN_TANCD.Name = "HD_IN_TANCD"
		Me.HD_HINNMB.AutoSize = False
		Me.HD_HINNMB.BackColor = System.Drawing.SystemColors.Control
		Me.HD_HINNMB.Size = New System.Drawing.Size(219, 21)
		Me.HD_HINNMB.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_HINNMB.Location = New System.Drawing.Point(241, 137)
		Me.HD_HINNMB.Maxlength = 30
		Me.HD_HINNMB.TabIndex = 12
		Me.HD_HINNMB.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMM3"
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
		Me.HD_HINNMB.TabStop = True
		Me.HD_HINNMB.Visible = True
		Me.HD_HINNMB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_HINNMB.Name = "HD_HINNMB"
		Me._FM_Panel3D1_0.Size = New System.Drawing.Size(566, 37)
		Me._FM_Panel3D1_0.Location = New System.Drawing.Point(-3, 0)
		Me._FM_Panel3D1_0.TabIndex = 9
        Me._FM_Panel3D1_0.ForeColor = Color.Empty
        'Me._FM_Panel3D1_0.OutLine = -1
        Me._FM_Panel3D1_0.Name = "_FM_Panel3D1_0"
		Me.SYSDT.Size = New System.Drawing.Size(112, 22)
		Me.SYSDT.Location = New System.Drawing.Point(428, 6)
		Me.SYSDT.TabIndex = 10
        Me.SYSDT.ForeColor = Color.Empty
        'Me.SYSDT.BevelOuter = 1
        Me.SYSDT.Text = "YYYY/MM/DD"
        Me.SYSDT.Name = "SYSDT"
		Me.CM_Slist.Size = New System.Drawing.Size(24, 22)
		Me.CM_Slist.Location = New System.Drawing.Point(68, 6)
		Me.CM_Slist.Image = CType(resources.GetObject("CM_Slist.Image"), System.Drawing.Image)
		Me.CM_Slist.Enabled = True
		Me.CM_Slist.Cursor = System.Windows.Forms.Cursors.Default
		Me.CM_Slist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.CM_Slist.Visible = True
		Me.CM_Slist.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.CM_Slist.Name = "CM_Slist"
		Me.CM_EndCm.Size = New System.Drawing.Size(24, 22)
		Me.CM_EndCm.Location = New System.Drawing.Point(20, 6)
		Me.CM_EndCm.Image = CType(resources.GetObject("CM_EndCm.Image"), System.Drawing.Image)
		Me.CM_EndCm.Enabled = True
		Me.CM_EndCm.Cursor = System.Windows.Forms.Cursors.Default
		Me.CM_EndCm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.CM_EndCm.Visible = True
		Me.CM_EndCm.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.CM_EndCm.Name = "CM_EndCm"
		Me.CM_Execute.Size = New System.Drawing.Size(24, 22)
		Me.CM_Execute.Location = New System.Drawing.Point(44, 6)
		Me.CM_Execute.Image = CType(resources.GetObject("CM_Execute.Image"), System.Drawing.Image)
		Me.CM_Execute.Enabled = True
		Me.CM_Execute.Cursor = System.Windows.Forms.Cursors.Default
		Me.CM_Execute.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.CM_Execute.Visible = True
		Me.CM_Execute.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.CM_Execute.Name = "CM_Execute"
		Me.Image1.Size = New System.Drawing.Size(566, 38)
		Me.Image1.Location = New System.Drawing.Point(0, 0)
		Me.Image1.Enabled = True
		Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Image1.Visible = True
		Me.Image1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Image1.Name = "Image1"
		Me._FM_Panel3D1_2.Size = New System.Drawing.Size(566, 51)
		Me._FM_Panel3D1_2.Location = New System.Drawing.Point(-1, 211)
		Me._FM_Panel3D1_2.TabIndex = 6
        Me._FM_Panel3D1_2.ForeColor = Color.Empty
        'Me._FM_Panel3D1_2.OutLine = -1
        Me._FM_Panel3D1_2.Name = "_FM_Panel3D1_2"
		Me._FM_Panel3D1_3.Size = New System.Drawing.Size(502, 31)
		Me._FM_Panel3D1_3.Location = New System.Drawing.Point(45, 9)
		Me._FM_Panel3D1_3.TabIndex = 7
        Me._FM_Panel3D1_3.ForeColor = Color.Empty
        'Me._FM_Panel3D1_3.BevelOuter = 1
        Me._FM_Panel3D1_3.Name = "_FM_Panel3D1_3"
		Me.TX_Message.AutoSize = False
		Me.TX_Message.BackColor = System.Drawing.SystemColors.Control
		Me.TX_Message.ForeColor = System.Drawing.Color.Black
		Me.TX_Message.Size = New System.Drawing.Size(484, 16)
		Me.TX_Message.Location = New System.Drawing.Point(6, 8)
		Me.TX_Message.MultiLine = True
		Me.TX_Message.TabIndex = 8
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
		Me.Frm_Main.Text = "条件指定"
		Me.Frm_Main.ForeColor = System.Drawing.Color.Black
		Me.Frm_Main.Size = New System.Drawing.Size(409, 109)
		Me.Frm_Main.Location = New System.Drawing.Point(76, 80)
		Me.Frm_Main.TabIndex = 3
		Me.Frm_Main.BackColor = System.Drawing.SystemColors.Control
		Me.Frm_Main.Enabled = True
		Me.Frm_Main.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frm_Main.Visible = True
		Me.Frm_Main.Name = "Frm_Main"
		Me.HD_HINNMA.AutoSize = False
		Me.HD_HINNMA.BackColor = System.Drawing.SystemColors.Control
		Me.HD_HINNMA.Size = New System.Drawing.Size(219, 21)
		Me.HD_HINNMA.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_HINNMA.Location = New System.Drawing.Point(165, 34)
		Me.HD_HINNMA.Maxlength = 30
		Me.HD_HINNMA.TabIndex = 11
		Me.HD_HINNMA.Text = "XXXXXXXXX1XXXXXXXXX2XXXXXXXX3"
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
		Me.HD_HINNMA.TabStop = True
		Me.HD_HINNMA.Visible = True
		Me.HD_HINNMA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_HINNMA.Name = "HD_HINNMA"
		Me.HD_HINCD.AutoSize = False
		Me.HD_HINCD.BackColor = System.Drawing.Color.White
		Me.HD_HINCD.Size = New System.Drawing.Size(67, 21)
		Me.HD_HINCD.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_HINCD.Location = New System.Drawing.Point(99, 34)
		Me.HD_HINCD.Maxlength = 17
		Me.HD_HINCD.TabIndex = 4
		Me.HD_HINCD.Text = "XXXXXXX8"
		Me.HD_HINCD.AcceptsReturn = True
		Me.HD_HINCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_HINCD.CausesValidation = True
		Me.HD_HINCD.Enabled = True
		Me.HD_HINCD.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_HINCD.HideSelection = True
		Me.HD_HINCD.ReadOnly = False
		Me.HD_HINCD.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_HINCD.MultiLine = False
		Me.HD_HINCD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_HINCD.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_HINCD.TabStop = True
		Me.HD_HINCD.Visible = True
		Me.HD_HINCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_HINCD.Name = "HD_HINCD"
		Me.CS_HINCD.BackColor = System.Drawing.Color.Transparent
		Me.CS_HINCD.Text = "*製品ｺｰﾄﾞ"
		Me.CS_HINCD.ForeColor = System.Drawing.SystemColors.WindowText
		Me.CS_HINCD.Size = New System.Drawing.Size(94, 22)
		Me.CS_HINCD.Location = New System.Drawing.Point(25, 36)
		Me.CS_HINCD.TabIndex = 5
		Me.CS_HINCD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.CS_HINCD.Enabled = True
		Me.CS_HINCD.Cursor = System.Windows.Forms.Cursors.Default
		Me.CS_HINCD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CS_HINCD.UseMnemonic = True
		Me.CS_HINCD.Visible = True
		Me.CS_HINCD.AutoSize = False
		Me.CS_HINCD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.CS_HINCD.Name = "CS_HINCD"
		Me._FM_Panel3D2_0.Size = New System.Drawing.Size(553, 94)
		Me._FM_Panel3D2_0.Location = New System.Drawing.Point(0, 520)
		Me._FM_Panel3D2_0.TabIndex = 1
        Me._FM_Panel3D2_0.ForeColor = Color.Empty
        'Me._FM_Panel3D2_0.OutLine = -1
        Me._FM_Panel3D2_0.Name = "_FM_Panel3D2_0"
		Me.TX_Mode.AutoSize = False
		Me.TX_Mode.BackColor = System.Drawing.Color.FromARGB(255, 192, 255)
		Me.TX_Mode.Size = New System.Drawing.Size(49, 22)
		Me.TX_Mode.Location = New System.Drawing.Point(105, 42)
		Me.TX_Mode.TabIndex = 2
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
		Me._IM_Denkyu_1.Size = New System.Drawing.Size(20, 22)
		Me._IM_Denkyu_1.Location = New System.Drawing.Point(162, 33)
		Me._IM_Denkyu_1.Image = CType(resources.GetObject("_IM_Denkyu_1.Image"), System.Drawing.Image)
		Me._IM_Denkyu_1.Enabled = True
		Me._IM_Denkyu_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_Denkyu_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_Denkyu_1.Visible = True
		Me._IM_Denkyu_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_Denkyu_1.Name = "_IM_Denkyu_1"
		Me._IM_Denkyu_2.Size = New System.Drawing.Size(20, 22)
		Me._IM_Denkyu_2.Location = New System.Drawing.Point(135, 33)
		Me._IM_Denkyu_2.Image = CType(resources.GetObject("_IM_Denkyu_2.Image"), System.Drawing.Image)
		Me._IM_Denkyu_2.Enabled = True
		Me._IM_Denkyu_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_Denkyu_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_Denkyu_2.Visible = True
		Me._IM_Denkyu_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_Denkyu_2.Name = "_IM_Denkyu_2"
		Me._IM_LCONFIG_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_LCONFIG_1.Location = New System.Drawing.Point(288, 3)
		Me._IM_LCONFIG_1.Image = CType(resources.GetObject("_IM_LCONFIG_1.Image"), System.Drawing.Image)
		Me._IM_LCONFIG_1.Enabled = True
		Me._IM_LCONFIG_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_LCONFIG_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_LCONFIG_1.Visible = True
		Me._IM_LCONFIG_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_LCONFIG_1.Name = "_IM_LCONFIG_1"
		Me._IM_LCONFIG_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_LCONFIG_0.Location = New System.Drawing.Point(264, 3)
		Me._IM_LCONFIG_0.Image = CType(resources.GetObject("_IM_LCONFIG_0.Image"), System.Drawing.Image)
		Me._IM_LCONFIG_0.Enabled = True
		Me._IM_LCONFIG_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_LCONFIG_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_LCONFIG_0.Visible = True
		Me._IM_LCONFIG_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_LCONFIG_0.Name = "_IM_LCONFIG_0"
		Me._IM_FSTART_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_FSTART_1.Location = New System.Drawing.Point(240, 3)
		Me._IM_FSTART_1.Image = CType(resources.GetObject("_IM_FSTART_1.Image"), System.Drawing.Image)
		Me._IM_FSTART_1.Enabled = True
		Me._IM_FSTART_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_FSTART_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_FSTART_1.Visible = True
		Me._IM_FSTART_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_FSTART_1.Name = "_IM_FSTART_1"
		Me._IM_FSTART_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_FSTART_0.Location = New System.Drawing.Point(216, 3)
		Me._IM_FSTART_0.Image = CType(resources.GetObject("_IM_FSTART_0.Image"), System.Drawing.Image)
		Me._IM_FSTART_0.Enabled = True
		Me._IM_FSTART_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_FSTART_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_FSTART_0.Visible = True
		Me._IM_FSTART_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_FSTART_0.Name = "_IM_FSTART_0"
		Me._IM_VSTART_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_VSTART_1.Location = New System.Drawing.Point(192, 3)
		Me._IM_VSTART_1.Image = CType(resources.GetObject("_IM_VSTART_1.Image"), System.Drawing.Image)
		Me._IM_VSTART_1.Enabled = True
		Me._IM_VSTART_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_VSTART_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_VSTART_1.Visible = True
		Me._IM_VSTART_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_VSTART_1.Name = "_IM_VSTART_1"
		Me._IM_VSTART_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_VSTART_0.Location = New System.Drawing.Point(168, 3)
		Me._IM_VSTART_0.Image = CType(resources.GetObject("_IM_VSTART_0.Image"), System.Drawing.Image)
		Me._IM_VSTART_0.Enabled = True
		Me._IM_VSTART_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_VSTART_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_VSTART_0.Visible = True
		Me._IM_VSTART_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_VSTART_0.Name = "_IM_VSTART_0"
		Me._IM_LSTART_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_LSTART_1.Location = New System.Drawing.Point(144, 3)
		Me._IM_LSTART_1.Image = CType(resources.GetObject("_IM_LSTART_1.Image"), System.Drawing.Image)
		Me._IM_LSTART_1.Visible = False
		Me._IM_LSTART_1.Enabled = True
		Me._IM_LSTART_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_LSTART_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_LSTART_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_LSTART_1.Name = "_IM_LSTART_1"
		Me._IM_Slist_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_Slist_1.Location = New System.Drawing.Point(93, 3)
		Me._IM_Slist_1.Image = CType(resources.GetObject("_IM_Slist_1.Image"), System.Drawing.Image)
		Me._IM_Slist_1.Visible = False
		Me._IM_Slist_1.Enabled = True
		Me._IM_Slist_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_Slist_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_Slist_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_Slist_1.Name = "_IM_Slist_1"
		Me._IM_EndCm_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_EndCm_0.Location = New System.Drawing.Point(12, 3)
		Me._IM_EndCm_0.Image = CType(resources.GetObject("_IM_EndCm_0.Image"), System.Drawing.Image)
		Me._IM_EndCm_0.Visible = False
		Me._IM_EndCm_0.Enabled = True
		Me._IM_EndCm_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_EndCm_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_EndCm_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_EndCm_0.Name = "_IM_EndCm_0"
		Me._IM_EndCm_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_EndCm_1.Location = New System.Drawing.Point(36, 3)
		Me._IM_EndCm_1.Image = CType(resources.GetObject("_IM_EndCm_1.Image"), System.Drawing.Image)
		Me._IM_EndCm_1.Visible = False
		Me._IM_EndCm_1.Enabled = True
		Me._IM_EndCm_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_EndCm_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_EndCm_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_EndCm_1.Name = "_IM_EndCm_1"
		Me._IM_Slist_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_Slist_0.Location = New System.Drawing.Point(66, 3)
		Me._IM_Slist_0.Image = CType(resources.GetObject("_IM_Slist_0.Image"), System.Drawing.Image)
		Me._IM_Slist_0.Visible = False
		Me._IM_Slist_0.Enabled = True
		Me._IM_Slist_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_Slist_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_Slist_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_Slist_0.Name = "_IM_Slist_0"
		Me._IM_LSTART_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_LSTART_0.Location = New System.Drawing.Point(123, 3)
		Me._IM_LSTART_0.Image = CType(resources.GetObject("_IM_LSTART_0.Image"), System.Drawing.Image)
		Me._IM_LSTART_0.Visible = False
		Me._IM_LSTART_0.Enabled = True
		Me._IM_LSTART_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_LSTART_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_LSTART_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_LSTART_0.Name = "_IM_LSTART_0"
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
		Me._FM_Panel3D1_1.Size = New System.Drawing.Size(84, 23)
		Me._FM_Panel3D1_1.Location = New System.Drawing.Point(256, 43)
		Me._FM_Panel3D1_1.TabIndex = 15
        Me._FM_Panel3D1_1.ForeColor = Color.Empty
        'Me._FM_Panel3D1_1.Alignment = 1
        'Me._FM_Panel3D1_1.BevelOuter = 1
        Me._FM_Panel3D1_1.Text = " 入力担当者"
        'Me._FM_Panel3D1_1.OutLine = -1
        Me._FM_Panel3D1_1.Name = "_FM_Panel3D1_1"
		Me.TX_Dummy.AutoSize = False
		Me.TX_Dummy.Size = New System.Drawing.Size(14, 19)
		Me.TX_Dummy.Location = New System.Drawing.Point(246, 224)
		Me.TX_Dummy.TabIndex = 16
		Me.TX_Dummy.AcceptsReturn = True
		Me.TX_Dummy.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TX_Dummy.BackColor = System.Drawing.SystemColors.Window
		Me.TX_Dummy.CausesValidation = True
		Me.TX_Dummy.Enabled = True
		Me.TX_Dummy.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TX_Dummy.HideSelection = True
		Me.TX_Dummy.ReadOnly = False
		Me.TX_Dummy.Maxlength = 0
		Me.TX_Dummy.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TX_Dummy.MultiLine = False
		Me.TX_Dummy.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TX_Dummy.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TX_Dummy.TabStop = True
		Me.TX_Dummy.Visible = True
		Me.TX_Dummy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TX_Dummy.Name = "TX_Dummy"
		Me._IM_Execute_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_Execute_1.Location = New System.Drawing.Point(0, 0)
		Me._IM_Execute_1.Image = CType(resources.GetObject("_IM_Execute_1.Image"), System.Drawing.Image)
		Me._IM_Execute_1.Enabled = True
		Me._IM_Execute_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_Execute_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_Execute_1.Visible = True
		Me._IM_Execute_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_Execute_1.Name = "_IM_Execute_1"
		Me._IM_Execute_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_Execute_0.Location = New System.Drawing.Point(0, 2)
		Me._IM_Execute_0.Image = CType(resources.GetObject("_IM_Execute_0.Image"), System.Drawing.Image)
		Me._IM_Execute_0.Enabled = True
		Me._IM_Execute_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_Execute_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_Execute_0.Visible = True
		Me._IM_Execute_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_Execute_0.Name = "_IM_Execute_0"
		Me.MN_Ctrl.Name = "MN_Ctrl"
		Me.MN_Ctrl.Text = "処理(&1)"
        'Me.MN_Ctrl.Checked = False
        Me.MN_Ctrl.Enabled = True
		Me.MN_Ctrl.Visible = True
		Me.MN_Execute.Name = "MN_Execute"
		Me.MN_Execute.Text = "実行(&R)"
        'Me.MN_Execute.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.R, System.Windows.Forms.Keys)
        'Me.MN_Execute.Checked = False
        Me.MN_Execute.Enabled = True
		Me.MN_Execute.Visible = True
		Me.MN_DeleteCM.Name = "MN_DeleteCM"
		Me.MN_DeleteCM.Text = "削除(&D)"
        'Me.MN_DeleteCM.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.D, System.Windows.Forms.Keys)
        Me.MN_DeleteCM.Visible = False
        'Me.MN_DeleteCM.Checked = False
        Me.MN_DeleteCM.Enabled = True
		Me.MN_HARDCOPY.Name = "MN_HARDCOPY"
		Me.MN_HARDCOPY.Text = "画面印刷"
		Me.MN_HARDCOPY.Visible = False
        'Me.MN_HARDCOPY.Checked = False
        Me.MN_HARDCOPY.Enabled = True
        Me.bar11.Enabled = True
		Me.bar11.Visible = True
		Me.bar11.Name = "bar11"
		Me.MN_EndCm.Name = "MN_EndCm"
		Me.MN_EndCm.Text = "終了(&X)"
        'Me.MN_EndCm.Checked = False
        Me.MN_EndCm.Enabled = True
		Me.MN_EndCm.Visible = True
		Me.MN_EditMn.Name = "MN_EditMn"
		Me.MN_EditMn.Text = "編集(&2)"
        'Me.MN_EditMn.Checked = False
        Me.MN_EditMn.Enabled = True
		Me.MN_EditMn.Visible = True
		Me.MN_APPENDC.Name = "MN_APPENDC"
		Me.MN_APPENDC.Text = "画面初期化(&S)"
        'Me.MN_APPENDC.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.S, System.Windows.Forms.Keys)
        Me.MN_APPENDC.Visible = False
        'Me.MN_APPENDC.Checked = False
        Me.MN_APPENDC.Enabled = True
		Me.MN_ClearItm.Name = "MN_ClearItm"
		Me.MN_ClearItm.Text = "項目初期化"
        'Me.MN_ClearItm.Checked = False
        Me.MN_ClearItm.Enabled = True
		Me.MN_ClearItm.Visible = True
		Me.MN_UnDoItem.Name = "MN_UnDoItem"
		Me.MN_UnDoItem.Text = "項目復元"
        'Me.MN_UnDoItem.Checked = False
        Me.MN_UnDoItem.Enabled = True
		Me.MN_UnDoItem.Visible = True
		Me.MN_ClearDE.Name = "MN_ClearDE"
		Me.MN_ClearDE.Text = "明細行初期化"
		Me.MN_ClearDE.Visible = False
        'Me.MN_ClearDE.Checked = False
        Me.MN_ClearDE.Enabled = True
		Me.MN_DeleteDE.Name = "MN_DeleteDE"
		Me.MN_DeleteDE.Text = "明細行削除(&T)"
        'Me.MN_DeleteDE.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.T, System.Windows.Forms.Keys)
        Me.MN_DeleteDE.Visible = False
        'Me.MN_DeleteDE.Checked = False
        Me.MN_DeleteDE.Enabled = True
		Me.MN_InsertDE.Name = "MN_InsertDE"
		Me.MN_InsertDE.Text = "明細行挿入(&I)"
        'Me.MN_InsertDE.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.I, System.Windows.Forms.Keys)
        Me.MN_InsertDE.Visible = False
        'Me.MN_InsertDE.Checked = False
        Me.MN_InsertDE.Enabled = True
		Me.MN_UnDoDe.Name = "MN_UnDoDe"
		Me.MN_UnDoDe.Text = "明細行復元"
		Me.MN_UnDoDe.Visible = False
        'Me.MN_UnDoDe.Checked = False
        Me.MN_UnDoDe.Enabled = True
		Me.Bar21.Enabled = True
		Me.Bar21.Visible = True
		Me.Bar21.Name = "Bar21"
		Me.MN_Cut.Name = "MN_Cut"
		Me.MN_Cut.Text = "切り取り(&X)"
        'Me.MN_Cut.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.X, System.Windows.Forms.Keys)
        'Me.MN_Cut.Checked = False
        Me.MN_Cut.Enabled = True
		Me.MN_Cut.Visible = True
		Me.MN_Copy.Name = "MN_Copy"
		Me.MN_Copy.Text = "コピー(&C)"
        'Me.MN_Copy.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.C, System.Windows.Forms.Keys)
        'Me.MN_Copy.Checked = False
        Me.MN_Copy.Enabled = True
		Me.MN_Copy.Visible = True
		Me.MN_Paste.Name = "MN_Paste"
		Me.MN_Paste.Text = "貼り付け(&V)"
        'Me.MN_Paste.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.V, System.Windows.Forms.Keys)
        'Me.MN_Paste.Checked = False
        Me.MN_Paste.Enabled = True
		Me.MN_Paste.Visible = True
		Me.MN_Oprt.Name = "MN_Oprt"
		Me.MN_Oprt.Text = "補助(&3)"
        'Me.MN_Oprt.Checked = False
        Me.MN_Oprt.Enabled = True
		Me.MN_Oprt.Visible = True
		Me.MN_Slist.Name = "MN_Slist"
		Me.MN_Slist.Text = "候補の一覧(&L&ﾆ)..."
        'Me.MN_Slist.ShortcutKeys = CType(System.Windows.Forms.Keys.F5, System.Windows.Forms.Keys)
        'Me.MN_Slist.Checked = False
        Me.MN_Slist.Enabled = True
		Me.MN_Slist.Visible = True
		Me.SM_ShortCut.Name = "SM_ShortCut"
		Me.SM_ShortCut.Text = "ShortCut"
		Me.SM_ShortCut.Visible = False
		Me.SM_ShortCut.Checked = False
		Me.SM_ShortCut.Enabled = True
		Me.SM_AllCopy.Name = "SM_AllCopy"
		Me.SM_AllCopy.Text = "項目内容コピー(&C)"
        'Me.SM_AllCopy.Checked = False
        Me.SM_AllCopy.Enabled = True
		Me.SM_AllCopy.Visible = True
		Me.SM_FullPast.Name = "SM_FullPast"
		Me.SM_FullPast.Text = "項目に貼り付け(&P)"
        'Me.SM_FullPast.Checked = False
        Me.SM_FullPast.Enabled = True
		Me.SM_FullPast.Visible = True
		Me.SM_Esc.Name = "SM_Esc"
		Me.SM_Esc.Text = "取消し(Esc)"
        'Me.SM_Esc.Checked = False
        Me.SM_Esc.Enabled = True
		Me.SM_Esc.Visible = True
		Me.Controls.Add(HD_IN_TANNM)
		Me.Controls.Add(HD_IN_TANCD)
		Me.Controls.Add(HD_HINNMB)
		Me.Controls.Add(_FM_Panel3D1_0)
		Me.Controls.Add(_FM_Panel3D1_2)
		Me.Controls.Add(Frm_Main)
		Me.Controls.Add(_FM_Panel3D2_0)
		Me.Controls.Add(TX_CursorRest)
		Me.Controls.Add(_FM_Panel3D1_1)
		Me.Controls.Add(TX_Dummy)
		Me.Controls.Add(_IM_Execute_1)
		Me.Controls.Add(_IM_Execute_0)
		Me._FM_Panel3D1_0.Controls.Add(SYSDT)
		Me._FM_Panel3D1_0.Controls.Add(CM_Slist)
		Me._FM_Panel3D1_0.Controls.Add(CM_EndCm)
		Me._FM_Panel3D1_0.Controls.Add(CM_Execute)
		Me._FM_Panel3D1_0.Controls.Add(Image1)
		Me._FM_Panel3D1_2.Controls.Add(_FM_Panel3D1_3)
		Me._FM_Panel3D1_2.Controls.Add(_IM_Denkyu_0)
		Me._FM_Panel3D1_3.Controls.Add(TX_Message)
		Me.Frm_Main.Controls.Add(HD_HINNMA)
		Me.Frm_Main.Controls.Add(HD_HINCD)
		Me.Frm_Main.Controls.Add(CS_HINCD)
		Me._FM_Panel3D2_0.Controls.Add(TX_Mode)
		Me._FM_Panel3D2_0.Controls.Add(_IM_Denkyu_1)
		Me._FM_Panel3D2_0.Controls.Add(_IM_Denkyu_2)
		Me._FM_Panel3D2_0.Controls.Add(_IM_LCONFIG_1)
		Me._FM_Panel3D2_0.Controls.Add(_IM_LCONFIG_0)
		Me._FM_Panel3D2_0.Controls.Add(_IM_FSTART_1)
		Me._FM_Panel3D2_0.Controls.Add(_IM_FSTART_0)
		Me._FM_Panel3D2_0.Controls.Add(_IM_VSTART_1)
		Me._FM_Panel3D2_0.Controls.Add(_IM_VSTART_0)
		Me._FM_Panel3D2_0.Controls.Add(_IM_LSTART_1)
		Me._FM_Panel3D2_0.Controls.Add(_IM_Slist_1)
		Me._FM_Panel3D2_0.Controls.Add(_IM_EndCm_0)
		Me._FM_Panel3D2_0.Controls.Add(_IM_EndCm_1)
		Me._FM_Panel3D2_0.Controls.Add(_IM_Slist_0)
		Me._FM_Panel3D2_0.Controls.Add(_IM_LSTART_0)
        'Me.FM_Panel3D1.SetIndex(_FM_Panel3D1_0, CType(0, Short))
        'Me.FM_Panel3D1.SetIndex(_FM_Panel3D1_3, CType(3, Short))
        'Me.FM_Panel3D1.SetIndex(_FM_Panel3D1_2, CType(2, Short))
        'Me.FM_Panel3D1.SetIndex(_FM_Panel3D1_1, CType(1, Short))
        'Me.FM_Panel3D2.SetIndex(_FM_Panel3D2_0, CType(0, Short))
        Me.IM_Denkyu.SetIndex(_IM_Denkyu_0, CType(0, Short))
		Me.IM_Denkyu.SetIndex(_IM_Denkyu_1, CType(1, Short))
		Me.IM_Denkyu.SetIndex(_IM_Denkyu_2, CType(2, Short))
		Me.IM_EndCm.SetIndex(_IM_EndCm_0, CType(0, Short))
		Me.IM_EndCm.SetIndex(_IM_EndCm_1, CType(1, Short))
		Me.IM_Execute.SetIndex(_IM_Execute_1, CType(1, Short))
		Me.IM_Execute.SetIndex(_IM_Execute_0, CType(0, Short))
		Me.IM_FSTART.SetIndex(_IM_FSTART_1, CType(1, Short))
		Me.IM_FSTART.SetIndex(_IM_FSTART_0, CType(0, Short))
		Me.IM_LCONFIG.SetIndex(_IM_LCONFIG_1, CType(1, Short))
		Me.IM_LCONFIG.SetIndex(_IM_LCONFIG_0, CType(0, Short))
		Me.IM_LSTART.SetIndex(_IM_LSTART_1, CType(1, Short))
		Me.IM_LSTART.SetIndex(_IM_LSTART_0, CType(0, Short))
		Me.IM_Slist.SetIndex(_IM_Slist_1, CType(1, Short))
		Me.IM_Slist.SetIndex(_IM_Slist_0, CType(0, Short))
		Me.IM_VSTART.SetIndex(_IM_VSTART_1, CType(1, Short))
		Me.IM_VSTART.SetIndex(_IM_VSTART_0, CType(0, Short))
		CType(Me.IM_VSTART, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_Slist, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_LSTART, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_LCONFIG, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_FSTART, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_Execute, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_EndCm, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_Denkyu, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.FM_Panel3D2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).EndInit()
        'MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me.MN_Ctrl, Me.MN_EditMn, Me.MN_Oprt, Me.SM_ShortCut})
        'MN_Ctrl.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.MN_Execute, Me.MN_DeleteCM, Me.MN_HARDCOPY, Me.bar11, Me.MN_EndCm})
        'MN_EditMn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.MN_APPENDC, Me.MN_ClearItm, Me.MN_UnDoItem, Me.MN_ClearDE, Me.MN_DeleteDE, Me.MN_InsertDE, Me.MN_UnDoDe, Me.Bar21, Me.MN_Cut, Me.MN_Copy, Me.MN_Paste})
        'MN_Oprt.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.MN_Slist})
        'SM_ShortCut.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.SM_AllCopy, Me.SM_FullPast, Me.SM_Esc})
        Me.Controls.Add(MainMenu1)
		Me._FM_Panel3D1_0.ResumeLayout(False)
		Me._FM_Panel3D1_2.ResumeLayout(False)
		Me._FM_Panel3D1_3.ResumeLayout(False)
		Me.Frm_Main.ResumeLayout(False)
		Me._FM_Panel3D2_0.ResumeLayout(False)
		Me.MainMenu1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class