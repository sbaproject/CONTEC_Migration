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
    '20190625 CHG START
    '   Public WithEvents _FM_Panel3D1_0 As SSPanel5
    'Public WithEvents TX_Message As System.Windows.Forms.TextBox
    'Public WithEvents _FM_Panel3D1_4 As SSPanel5
    'Public WithEvents _IM_Denkyu_0 As System.Windows.Forms.PictureBox
    'Public WithEvents _FM_Panel3D1_3 As SSPanel5
    'Public WithEvents SYSDT As SSPanel5
    Public WithEvents _FM_Panel3D1_0 As Label
    Public WithEvents TX_Message As System.Windows.Forms.TextBox
    Public WithEvents _FM_Panel3D1_4 As Label
    Public WithEvents _IM_Denkyu_0 As System.Windows.Forms.PictureBox
    Public WithEvents _FM_Panel3D1_3 As Label
    Public WithEvents SYSDT As Label
    '20190625 CHG END
    Public WithEvents CM_LCONFIG As System.Windows.Forms.PictureBox
	Public WithEvents CM_VSTART As System.Windows.Forms.PictureBox
	Public WithEvents CM_SLIST As System.Windows.Forms.PictureBox
	Public WithEvents CM_EndCm As System.Windows.Forms.PictureBox
	Public WithEvents CM_LSTART As System.Windows.Forms.PictureBox
    Public WithEvents Image1 As System.Windows.Forms.PictureBox
    '20190625 CHG START
    '   Public WithEvents _FM_Panel3D1_1 As SSPanel5
    'Public WithEvents GAUGE As SSPanel5
    Public WithEvents _FM_Panel3D1_1 As Label
    Public WithEvents GAUGE As Label
    '20190625 CHG END
    Public WithEvents HD_SOUBSNM As System.Windows.Forms.TextBox
    Public WithEvents HD_SOUBSCD As System.Windows.Forms.TextBox
	Public WithEvents HD_SOUCD As System.Windows.Forms.TextBox
	Public WithEvents HD_SOUNM As System.Windows.Forms.TextBox
	Public WithEvents HD_TEISYOYM As System.Windows.Forms.TextBox
	Public WithEvents HD_Cursol_Wk2 As System.Windows.Forms.TextBox
	Public WithEvents HD_Cursol_Wk As System.Windows.Forms.TextBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Frame3D1 As System.Windows.Forms.GroupBox
	Public WithEvents TM_StartUp As System.Windows.Forms.Timer
    Public WithEvents TX_CursorRest As System.Windows.Forms.TextBox
    '20190625 CHG START
    '   Public WithEvents CM_LCANCEL As SSCommand5
    'Public WithEvents _FM_Panel3D1_2 As SSPanel5
    'Public WithEvents FM_Panel3D1 As SSPanel5Array
    Public WithEvents CM_LCANCEL As Button
    Public WithEvents _FM_Panel3D1_2 As Label
    Public WithEvents FM_Panel3D1 As VB6.LabelArray
    '20190625 CHG END
    Public WithEvents IM_Denkyu As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_EndCm As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_FSTART As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_LCONFIG As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_LSTART As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_Slist As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    Public WithEvents IM_VSTART As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    '20190625 CHG START
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
    'Public WithEvents SM_ShortCut As System.Windows.Forms.ToolStripMenuItem
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
        Me.CM_LCONFIG = New System.Windows.Forms.PictureBox()
        Me.CM_VSTART = New System.Windows.Forms.PictureBox()
        Me.CM_SLIST = New System.Windows.Forms.PictureBox()
        Me.CM_EndCm = New System.Windows.Forms.PictureBox()
        Me.CM_LSTART = New System.Windows.Forms.PictureBox()
        Me.Image1 = New System.Windows.Forms.PictureBox()
        Me.GAUGE = New System.Windows.Forms.Label()
        Me.Frame3D1 = New System.Windows.Forms.GroupBox()
        Me.HD_SOUBSNM = New System.Windows.Forms.TextBox()
        Me.HD_SOUBSCD = New System.Windows.Forms.TextBox()
        Me.HD_SOUCD = New System.Windows.Forms.TextBox()
        Me.HD_SOUNM = New System.Windows.Forms.TextBox()
        Me.HD_TEISYOYM = New System.Windows.Forms.TextBox()
        Me.HD_Cursol_Wk2 = New System.Windows.Forms.TextBox()
        Me.HD_Cursol_Wk = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
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
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
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
        CType(Me.CM_LCONFIG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_VSTART, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_SLIST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_EndCm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_LSTART, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label4.SuspendLayout()
        Me.Label5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._FM_Panel3D1_28.SuspendLayout()
        Me._FM_Panel3D1_27.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.HD_IN_TANCD.TabIndex = 19
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
        Me.HD_IN_TANNM.TabIndex = 18
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
        Me._FM_Panel3D1_0.TabIndex = 11
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
        Me.CS_ENDDENDT.TabIndex = 17
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
        Me.CS_STTDENDT.TabIndex = 16
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
        Me.TX_Mode.TabIndex = 14
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
        Me.CS_STTTOKCD.TabIndex = 13
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
        Me.CS_ENDTOKCD.TabIndex = 12
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
        Me._IM_LSTART_0.TabIndex = 18
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
        Me._IM_Slist_0.TabIndex = 19
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
        Me._IM_EndCm_1.TabIndex = 20
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
        Me._IM_EndCm_0.TabIndex = 21
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
        Me._IM_Slist_1.TabIndex = 22
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
        Me._IM_LSTART_1.TabIndex = 23
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
        Me._IM_VSTART_0.TabIndex = 24
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
        Me._IM_VSTART_1.TabIndex = 25
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
        Me._IM_FSTART_0.TabIndex = 26
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
        Me._IM_FSTART_1.TabIndex = 27
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
        Me._IM_LCONFIG_0.TabIndex = 28
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
        Me._IM_LCONFIG_1.TabIndex = 29
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
        Me._IM_Denkyu_1.TabIndex = 30
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
        Me._IM_Denkyu_2.TabIndex = 31
        Me._IM_Denkyu_2.TabStop = False
        '
        '_FM_Panel3D1_3
        '
        Me._FM_Panel3D1_3.Controls.Add(Me._FM_Panel3D1_4)
        Me._FM_Panel3D1_3.Controls.Add(Me._IM_Denkyu_0)
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_3, CType(3, Short))
        Me._FM_Panel3D1_3.Location = New System.Drawing.Point(-2, 330)
        Me._FM_Panel3D1_3.Name = "_FM_Panel3D1_3"
        Me._FM_Panel3D1_3.Size = New System.Drawing.Size(663, 51)
        Me._FM_Panel3D1_3.TabIndex = 8
        '
        '_FM_Panel3D1_4
        '
        Me._FM_Panel3D1_4.Controls.Add(Me.TX_Message)
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_4, CType(4, Short))
        Me._FM_Panel3D1_4.Location = New System.Drawing.Point(45, 9)
        Me._FM_Panel3D1_4.Name = "_FM_Panel3D1_4"
        Me._FM_Panel3D1_4.Size = New System.Drawing.Size(608, 31)
        Me._FM_Panel3D1_4.TabIndex = 9
        '
        'TX_Message
        '
        Me.TX_Message.AcceptsReturn = True
        Me.TX_Message.BackColor = System.Drawing.SystemColors.Control
        Me.TX_Message.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TX_Message.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TX_Message.ForeColor = System.Drawing.Color.Black
        Me.TX_Message.Location = New System.Drawing.Point(3, 6)
        Me.TX_Message.MaxLength = 0
        Me.TX_Message.Multiline = True
        Me.TX_Message.Name = "TX_Message"
        Me.TX_Message.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_Message.Size = New System.Drawing.Size(394, 13)
        Me.TX_Message.TabIndex = 10
        Me.TX_Message.Text = "エラーやプロンプトのメッセージが出力されるところです。"
        Me.TX_Message.Visible = False
        '
        '_IM_Denkyu_0
        '
        Me._IM_Denkyu_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_0.Enabled = False
        Me._IM_Denkyu_0.Image = CType(resources.GetObject("_IM_Denkyu_0.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_0, CType(0, Short))
        Me._IM_Denkyu_0.Location = New System.Drawing.Point(12, 9)
        Me._IM_Denkyu_0.Name = "_IM_Denkyu_0"
        Me._IM_Denkyu_0.Size = New System.Drawing.Size(20, 22)
        Me._IM_Denkyu_0.TabIndex = 10
        Me._IM_Denkyu_0.TabStop = False
        Me._IM_Denkyu_0.Visible = False
        '
        '_FM_Panel3D1_1
        '
        Me._FM_Panel3D1_1.Controls.Add(Me.SYSDT)
        Me._FM_Panel3D1_1.Controls.Add(Me.CM_LCONFIG)
        Me._FM_Panel3D1_1.Controls.Add(Me.CM_VSTART)
        Me._FM_Panel3D1_1.Controls.Add(Me.CM_SLIST)
        Me._FM_Panel3D1_1.Controls.Add(Me.CM_EndCm)
        Me._FM_Panel3D1_1.Controls.Add(Me.CM_LSTART)
        Me._FM_Panel3D1_1.Controls.Add(Me.Image1)
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_1, CType(1, Short))
        Me._FM_Panel3D1_1.Location = New System.Drawing.Point(-3, 0)
        Me._FM_Panel3D1_1.Name = "_FM_Panel3D1_1"
        Me._FM_Panel3D1_1.Size = New System.Drawing.Size(663, 37)
        Me._FM_Panel3D1_1.TabIndex = 6
        '
        'SYSDT
        '
        Me.SYSDT.Location = New System.Drawing.Point(557, 9)
        Me.SYSDT.Name = "SYSDT"
        Me.SYSDT.Size = New System.Drawing.Size(94, 19)
        Me.SYSDT.TabIndex = 7
        Me.SYSDT.Text = "YYYY/MM/DD"
        '
        'CM_LCONFIG
        '
        Me.CM_LCONFIG.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_LCONFIG.Image = CType(resources.GetObject("CM_LCONFIG.Image"), System.Drawing.Image)
        Me.CM_LCONFIG.Location = New System.Drawing.Point(87, 6)
        Me.CM_LCONFIG.Name = "CM_LCONFIG"
        Me.CM_LCONFIG.Size = New System.Drawing.Size(24, 22)
        Me.CM_LCONFIG.TabIndex = 8
        Me.CM_LCONFIG.TabStop = False
        '
        'CM_VSTART
        '
        Me.CM_VSTART.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_VSTART.Image = CType(resources.GetObject("CM_VSTART.Image"), System.Drawing.Image)
        Me.CM_VSTART.Location = New System.Drawing.Point(63, 6)
        Me.CM_VSTART.Name = "CM_VSTART"
        Me.CM_VSTART.Size = New System.Drawing.Size(24, 22)
        Me.CM_VSTART.TabIndex = 9
        Me.CM_VSTART.TabStop = False
        '
        'CM_SLIST
        '
        Me.CM_SLIST.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_SLIST.Image = CType(resources.GetObject("CM_SLIST.Image"), System.Drawing.Image)
        Me.CM_SLIST.Location = New System.Drawing.Point(111, 6)
        Me.CM_SLIST.Name = "CM_SLIST"
        Me.CM_SLIST.Size = New System.Drawing.Size(24, 22)
        Me.CM_SLIST.TabIndex = 10
        Me.CM_SLIST.TabStop = False
        '
        'CM_EndCm
        '
        Me.CM_EndCm.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_EndCm.Image = CType(resources.GetObject("CM_EndCm.Image"), System.Drawing.Image)
        Me.CM_EndCm.Location = New System.Drawing.Point(15, 6)
        Me.CM_EndCm.Name = "CM_EndCm"
        Me.CM_EndCm.Size = New System.Drawing.Size(24, 22)
        Me.CM_EndCm.TabIndex = 11
        Me.CM_EndCm.TabStop = False
        '
        'CM_LSTART
        '
        Me.CM_LSTART.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_LSTART.Image = CType(resources.GetObject("CM_LSTART.Image"), System.Drawing.Image)
        Me.CM_LSTART.Location = New System.Drawing.Point(39, 6)
        Me.CM_LSTART.Name = "CM_LSTART"
        Me.CM_LSTART.Size = New System.Drawing.Size(24, 22)
        Me.CM_LSTART.TabIndex = 12
        Me.CM_LSTART.TabStop = False
        '
        'Image1
        '
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Location = New System.Drawing.Point(0, 0)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(302, 34)
        Me.Image1.TabIndex = 13
        Me.Image1.TabStop = False
        '
        'GAUGE
        '
        Me.GAUGE.Location = New System.Drawing.Point(84, 244)
        Me.GAUGE.Name = "GAUGE"
        Me.GAUGE.Size = New System.Drawing.Size(491, 28)
        Me.GAUGE.TabIndex = 5
        Me.GAUGE.Text = "Panel3D2"
        Me.GAUGE.Visible = False
        '
        'Frame3D1
        '
        Me.Frame3D1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3D1.Controls.Add(Me.HD_SOUBSNM)
        Me.Frame3D1.Controls.Add(Me.HD_SOUBSCD)
        Me.Frame3D1.Controls.Add(Me.HD_SOUCD)
        Me.Frame3D1.Controls.Add(Me.HD_SOUNM)
        Me.Frame3D1.Controls.Add(Me.HD_TEISYOYM)
        Me.Frame3D1.Controls.Add(Me.HD_Cursol_Wk2)
        Me.Frame3D1.Controls.Add(Me.HD_Cursol_Wk)
        Me.Frame3D1.Controls.Add(Me.Label1)
        Me.Frame3D1.Controls.Add(Me.Label2)
        Me.Frame3D1.Controls.Add(Me.Label3)
        Me.Frame3D1.ForeColor = System.Drawing.Color.Black
        Me.Frame3D1.Location = New System.Drawing.Point(85, 96)
        Me.Frame3D1.Name = "Frame3D1"
        Me.Frame3D1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3D1.Size = New System.Drawing.Size(491, 134)
        Me.Frame3D1.TabIndex = 0
        Me.Frame3D1.TabStop = False
        Me.Frame3D1.Text = "条件指定"
        '
        'HD_SOUBSNM
        '
        Me.HD_SOUBSNM.AcceptsReturn = True
        Me.HD_SOUBSNM.BackColor = System.Drawing.SystemColors.Control
        Me.HD_SOUBSNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_SOUBSNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_SOUBSNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_SOUBSNM.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_SOUBSNM.Location = New System.Drawing.Point(143, 54)
        Me.HD_SOUBSNM.MaxLength = 20
        Me.HD_SOUBSNM.Name = "HD_SOUBSNM"
        Me.HD_SOUBSNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_SOUBSNM.Size = New System.Drawing.Size(149, 20)
        Me.HD_SOUBSNM.TabIndex = 26
        Me.HD_SOUBSNM.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'HD_SOUBSCD
        '
        Me.HD_SOUBSCD.AcceptsReturn = True
        Me.HD_SOUBSCD.BackColor = System.Drawing.Color.White
        Me.HD_SOUBSCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_SOUBSCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_SOUBSCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_SOUBSCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_SOUBSCD.Location = New System.Drawing.Point(115, 54)
        Me.HD_SOUBSCD.MaxLength = 7
        Me.HD_SOUBSCD.Name = "HD_SOUBSCD"
        Me.HD_SOUBSCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_SOUBSCD.Size = New System.Drawing.Size(29, 20)
        Me.HD_SOUBSCD.TabIndex = 2
        Me.HD_SOUBSCD.Text = "XXX"
        '
        'HD_SOUCD
        '
        Me.HD_SOUCD.AcceptsReturn = True
        Me.HD_SOUCD.BackColor = System.Drawing.Color.White
        Me.HD_SOUCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_SOUCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_SOUCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_SOUCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_SOUCD.Location = New System.Drawing.Point(115, 81)
        Me.HD_SOUCD.MaxLength = 7
        Me.HD_SOUCD.Name = "HD_SOUCD"
        Me.HD_SOUCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_SOUCD.Size = New System.Drawing.Size(29, 20)
        Me.HD_SOUCD.TabIndex = 3
        Me.HD_SOUCD.Text = "XXX"
        '
        'HD_SOUNM
        '
        Me.HD_SOUNM.AcceptsReturn = True
        Me.HD_SOUNM.BackColor = System.Drawing.SystemColors.Control
        Me.HD_SOUNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_SOUNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_SOUNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_SOUNM.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_SOUNM.Location = New System.Drawing.Point(143, 81)
        Me.HD_SOUNM.MaxLength = 20
        Me.HD_SOUNM.Name = "HD_SOUNM"
        Me.HD_SOUNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_SOUNM.Size = New System.Drawing.Size(149, 20)
        Me.HD_SOUNM.TabIndex = 24
        Me.HD_SOUNM.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'HD_TEISYOYM
        '
        Me.HD_TEISYOYM.AcceptsReturn = True
        Me.HD_TEISYOYM.BackColor = System.Drawing.Color.White
        Me.HD_TEISYOYM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TEISYOYM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TEISYOYM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TEISYOYM.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_TEISYOYM.Location = New System.Drawing.Point(115, 27)
        Me.HD_TEISYOYM.MaxLength = 14
        Me.HD_TEISYOYM.Name = "HD_TEISYOYM"
        Me.HD_TEISYOYM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TEISYOYM.Size = New System.Drawing.Size(79, 20)
        Me.HD_TEISYOYM.TabIndex = 1
        Me.HD_TEISYOYM.Text = "9999/99/99"
        '
        'HD_Cursol_Wk2
        '
        Me.HD_Cursol_Wk2.AcceptsReturn = True
        Me.HD_Cursol_Wk2.BackColor = System.Drawing.Color.White
        Me.HD_Cursol_Wk2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_Cursol_Wk2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_Cursol_Wk2.Font = New System.Drawing.Font("MS Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_Cursol_Wk2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_Cursol_Wk2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_Cursol_Wk2.Location = New System.Drawing.Point(121, 30)
        Me.HD_Cursol_Wk2.MaxLength = 0
        Me.HD_Cursol_Wk2.Name = "HD_Cursol_Wk2"
        Me.HD_Cursol_Wk2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_Cursol_Wk2.Size = New System.Drawing.Size(29, 15)
        Me.HD_Cursol_Wk2.TabIndex = 22
        Me.HD_Cursol_Wk2.Text = "HD_Cursol_Wk_1"
        '
        'HD_Cursol_Wk
        '
        Me.HD_Cursol_Wk.AcceptsReturn = True
        Me.HD_Cursol_Wk.BackColor = System.Drawing.Color.White
        Me.HD_Cursol_Wk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_Cursol_Wk.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_Cursol_Wk.Font = New System.Drawing.Font("MS Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_Cursol_Wk.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_Cursol_Wk.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_Cursol_Wk.Location = New System.Drawing.Point(149, 30)
        Me.HD_Cursol_Wk.MaxLength = 0
        Me.HD_Cursol_Wk.Name = "HD_Cursol_Wk"
        Me.HD_Cursol_Wk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_Cursol_Wk.Size = New System.Drawing.Size(29, 15)
        Me.HD_Cursol_Wk.TabIndex = 21
        Me.HD_Cursol_Wk.Text = "HD_Cursol_Wk_1"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(31, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(78, 22)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "場所"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(31, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(78, 22)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "倉庫"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(31, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(78, 16)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "*経理締日付"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        Me.TX_CursorRest.TabIndex = 4
        '
        'CM_LCANCEL
        '
        Me.CM_LCANCEL.Location = New System.Drawing.Point(291, 297)
        Me.CM_LCANCEL.Name = "CM_LCANCEL"
        Me.CM_LCANCEL.Size = New System.Drawing.Size(76, 19)
        Me.CM_LCANCEL.TabIndex = 15
        Me.CM_LCANCEL.TabStop = False
        Me.CM_LCANCEL.Text = "中 止"
        '
        '_FM_Panel3D1_2
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_2, CType(2, Short))
        Me._FM_Panel3D1_2.Location = New System.Drawing.Point(342, 43)
        Me._FM_Panel3D1_2.Name = "_FM_Panel3D1_2"
        Me._FM_Panel3D1_2.Size = New System.Drawing.Size(111, 23)
        Me._FM_Panel3D1_2.TabIndex = 20
        Me._FM_Panel3D1_2.Text = " 入力担当者"
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
        Me.btnF12.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF12.Location = New System.Drawing.Point(899, 333)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(75, 37)
        Me.btnF12.TabIndex = 285
        Me.btnF12.Text = "(F12)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'btnF11
        '
        Me.btnF11.Enabled = False
        Me.btnF11.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF11.Location = New System.Drawing.Point(822, 333)
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
        Me.btnF10.Location = New System.Drawing.Point(744, 333)
        Me.btnF10.Name = "btnF10"
        Me.btnF10.Size = New System.Drawing.Size(75, 37)
        Me.btnF10.TabIndex = 283
        Me.btnF10.Text = "(F10)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF10.UseVisualStyleBackColor = True
        '
        'btnF9
        '
        Me.btnF9.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF9.Location = New System.Drawing.Point(667, 333)
        Me.btnF9.Name = "btnF9"
        Me.btnF9.Size = New System.Drawing.Size(75, 37)
        Me.btnF9.TabIndex = 282
        Me.btnF9.Text = "(F9)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "クリア"
        Me.btnF9.UseVisualStyleBackColor = True
        '
        'btnF8
        '
        Me.btnF8.Enabled = False
        Me.btnF8.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF8.Location = New System.Drawing.Point(573, 333)
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
        Me.btnF7.Location = New System.Drawing.Point(495, 333)
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
        Me.btnF6.Location = New System.Drawing.Point(417, 333)
        Me.btnF6.Name = "btnF6"
        Me.btnF6.Size = New System.Drawing.Size(75, 37)
        Me.btnF6.TabIndex = 279
        Me.btnF6.Text = "(F6)"
        Me.btnF6.UseVisualStyleBackColor = True
        '
        'btnF5
        '
        Me.btnF5.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF5.Location = New System.Drawing.Point(339, 333)
        Me.btnF5.Name = "btnF5"
        Me.btnF5.Size = New System.Drawing.Size(75, 37)
        Me.btnF5.TabIndex = 278
        Me.btnF5.Text = "(F5)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ヘルプ"
        Me.btnF5.UseVisualStyleBackColor = True
        '
        'btnF4
        '
        Me.btnF4.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF4.Location = New System.Drawing.Point(245, 333)
        Me.btnF4.Name = "btnF4"
        Me.btnF4.Size = New System.Drawing.Size(75, 37)
        Me.btnF4.TabIndex = 277
        Me.btnF4.Text = "(F4)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "印刷"
        Me.btnF4.UseVisualStyleBackColor = True
        '
        'btnF3
        '
        Me.btnF3.Enabled = False
        Me.btnF3.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF3.Location = New System.Drawing.Point(166, 333)
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
        Me.btnF2.Location = New System.Drawing.Point(87, 333)
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
        Me.btnF1.Location = New System.Drawing.Point(8, 333)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(75, 35)
        Me.btnF1.TabIndex = 274
        Me.btnF1.Text = "(F1)"
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Controls.Add(Me.Label5)
        Me.Label4.Controls.Add(Me.PictureBox1)
        Me.Label4.Location = New System.Drawing.Point(0, 335)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(888, 40)
        Me.Label4.TabIndex = 267
        '
        'Label5
        '
        Me.Label5.Controls.Add(Me.TextBox3)
        Me.Label5.Location = New System.Drawing.Point(50, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(750, 31)
        Me.Label5.TabIndex = 63
        '
        'TextBox3
        '
        Me.TextBox3.AcceptsReturn = True
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox3.ForeColor = System.Drawing.Color.Black
        Me.TextBox3.Location = New System.Drawing.Point(7, 8)
        Me.TextBox3.MaxLength = 0
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox3.Size = New System.Drawing.Size(667, 16)
        Me.TextBox3.TabIndex = 64
        Me.TextBox3.Text = "エラーやプロンプトのメッセージが出力されるところです。"
        Me.TextBox3.Visible = False
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
        Me.TextBox4.Location = New System.Drawing.Point(703, 345)
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
        Me.TextBox5.Location = New System.Drawing.Point(656, 345)
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
        Me.TextBox6.Location = New System.Drawing.Point(619, 340)
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
        Me.TextBox7.Location = New System.Drawing.Point(705, 341)
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
        Me.RadioButton1.Location = New System.Drawing.Point(708, 346)
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
        Me.RadioButton2.Location = New System.Drawing.Point(622, 343)
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
        Me._FM_Panel3D1_28.Location = New System.Drawing.Point(0, 332)
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
        Me.TL_Cursol_Wk_2.Location = New System.Drawing.Point(703, 347)
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
        Me.HD_Cursol_Wk_1.Location = New System.Drawing.Point(656, 347)
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
        Me.HD_Cursol_Wk_2.Location = New System.Drawing.Point(619, 342)
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
        Me.HD_Cursol_Wk_3.Location = New System.Drawing.Point(705, 343)
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 378)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(980, 23)
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
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(193, 18)
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(193, 18)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "端末ID"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(193, 18)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Text = "ログインID"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(193, 18)
        Me.ToolStripStatusLabel4.Spring = True
        Me.ToolStripStatusLabel4.Text = "XXXXXXX"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(193, 18)
        Me.ToolStripStatusLabel5.Spring = True
        Me.ToolStripStatusLabel5.Text = "Ver.1.00"
        '
        'MainMenu1
        '
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(980, 24)
        Me.MainMenu1.TabIndex = 21
        Me.MainMenu1.Visible = False
        '
        'FR_SSSMAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(980, 401)
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
        Me.Controls.Add(Me.Label4)
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
        Me.Font = New System.Drawing.Font("MS Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(153, 212)
        Me.MaximizeBox = False
        Me.Name = "FR_SSSMAIN"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "棚卸結果表出力"
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
        CType(Me.CM_LCONFIG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_VSTART, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_SLIST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_EndCm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_LSTART, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.Label4.ResumeLayout(False)
        Me.Label5.ResumeLayout(False)
        Me.Label5.PerformLayout()
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
    Public WithEvents Label4 As Label
    Public WithEvents Label5 As Label
    Public WithEvents TextBox3 As TextBox
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
    Public WithEvents MainMenu1 As MenuStrip
#End Region
End Class