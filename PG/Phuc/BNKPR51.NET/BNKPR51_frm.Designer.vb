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
	Public WithEvents HD_ENDBNKNM As System.Windows.Forms.TextBox
	Public WithEvents HD_STTBNKNM As System.Windows.Forms.TextBox
	Public WithEvents HD_ENDBNKCD As System.Windows.Forms.TextBox
	Public WithEvents HD_STTBNKCD As System.Windows.Forms.TextBox
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame3D1 As System.Windows.Forms.GroupBox
	Public WithEvents TX_Mode As System.Windows.Forms.TextBox
    Public WithEvents CMDialogL As System.Windows.Forms.OpenFileDialog
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_SSSMAIN))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.HD_OPENM = New System.Windows.Forms.TextBox()
        Me.HD_OPEID = New System.Windows.Forms.TextBox()
        Me.Frame3D1 = New System.Windows.Forms.GroupBox()
        Me.HD_ENDBNKNM = New System.Windows.Forms.TextBox()
        Me.HD_STTBNKNM = New System.Windows.Forms.TextBox()
        Me.HD_ENDBNKCD = New System.Windows.Forms.TextBox()
        Me.HD_STTBNKCD = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FM_Panel3D1 = New System.Windows.Forms.Label()
        Me.TX_Mode = New System.Windows.Forms.TextBox()
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
        Me.FM_Panel3D14 = New System.Windows.Forms.Label()
        Me.SYSDT = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CM_SLIST = New System.Windows.Forms.PictureBox()
        Me.CM_EndCm = New System.Windows.Forms.PictureBox()
        Me.CM_LSTART = New System.Windows.Forms.PictureBox()
        Me.CM_LCONFIG = New System.Windows.Forms.PictureBox()
        Me.CM_VSTART = New System.Windows.Forms.PictureBox()
        Me.CM_FSTART = New System.Windows.Forms.PictureBox()
        Me.Image1 = New System.Windows.Forms.PictureBox()
        Me.TM_StartUp = New System.Windows.Forms.Timer(Me.components)
        Me.TX_CursorRest = New System.Windows.Forms.TextBox()
        Me._FM_Panel3D15_0 = New System.Windows.Forms.Label()
        Me._FM_Panel3D2_2 = New System.Windows.Forms.Label()
        Me.TX_Message = New System.Windows.Forms.TextBox()
        Me._IM_Denkyu_0 = New System.Windows.Forms.PictureBox()
        Me.GAUGE = New System.Windows.Forms.Label()
        Me.CM_LCANCEL = New System.Windows.Forms.Button()
        Me._FM_Panel3D4_4 = New System.Windows.Forms.Label()
        Me.FM_Panel3D15 = New Microsoft.VisualBasic.Compatibility.VB6.PanelArray(Me.components)
        Me.FM_Panel3D2 = New Microsoft.VisualBasic.Compatibility.VB6.PanelArray(Me.components)
        Me.FM_Panel3D4 = New Microsoft.VisualBasic.Compatibility.VB6.PanelArray(Me.components)
        Me.IM_Denkyu = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_EndCm = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_FSTART = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_LCONFIG = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_LSTART = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_Slist = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_VSTART = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.MN_Ctrl = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_LSTART = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_VSTART = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_FSTART = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_LCONFIG = New System.Windows.Forms.ToolStripMenuItem()
        Me.bar11 = New System.Windows.Forms.ToolStripSeparator()
        Me.MN_EndCm = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_EditMn = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_APPENDC = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_ClearItm = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_UnDoItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Bar21 = New System.Windows.Forms.ToolStripSeparator()
        Me.MN_Cut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_Copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_Paste = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_Oprt = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_Slist = New System.Windows.Forms.ToolStripMenuItem()
        Me.SM_ShortCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.SM_AllCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.SM_FullPast = New System.Windows.Forms.ToolStripMenuItem()
        Me.SM_Esc = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.FM_Panel3D1.SuspendLayout()
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
        Me.FM_Panel3D14.SuspendLayout()
        CType(Me.CM_SLIST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_EndCm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_LSTART, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_LCONFIG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_VSTART, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_FSTART, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._FM_Panel3D15_0.SuspendLayout()
        Me._FM_Panel3D2_2.SuspendLayout()
        CType(Me._IM_Denkyu_0, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.MainMenu1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'HD_OPENM
        '
        Me.HD_OPENM.AcceptsReturn = True
        Me.HD_OPENM.BackColor = System.Drawing.SystemColors.Window
        Me.HD_OPENM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_OPENM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_OPENM.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_OPENM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_OPENM.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_OPENM.Location = New System.Drawing.Point(396, 48)
        Me.HD_OPENM.MaxLength = 24
        Me.HD_OPENM.Name = "HD_OPENM"
        Me.HD_OPENM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_OPENM.Size = New System.Drawing.Size(151, 19)
        Me.HD_OPENM.TabIndex = 17
        Me.HD_OPENM.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'HD_OPEID
        '
        Me.HD_OPEID.AcceptsReturn = True
        Me.HD_OPEID.BackColor = System.Drawing.SystemColors.Window
        Me.HD_OPEID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_OPEID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_OPEID.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_OPEID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_OPEID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_OPEID.Location = New System.Drawing.Point(350, 48)
        Me.HD_OPEID.MaxLength = 10
        Me.HD_OPEID.Name = "HD_OPEID"
        Me.HD_OPEID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_OPEID.Size = New System.Drawing.Size(47, 19)
        Me.HD_OPEID.TabIndex = 16
        Me.HD_OPEID.Text = "XXXXX6"
        '
        'Frame3D1
        '
        Me.Frame3D1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3D1.Controls.Add(Me.HD_ENDBNKNM)
        Me.Frame3D1.Controls.Add(Me.HD_STTBNKNM)
        Me.Frame3D1.Controls.Add(Me.HD_ENDBNKCD)
        Me.Frame3D1.Controls.Add(Me.HD_STTBNKCD)
        Me.Frame3D1.Controls.Add(Me.Label2)
        Me.Frame3D1.Controls.Add(Me.Label1)
        Me.Frame3D1.ForeColor = System.Drawing.Color.Black
        Me.Frame3D1.Location = New System.Drawing.Point(24, 104)
        Me.Frame3D1.Name = "Frame3D1"
        Me.Frame3D1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3D1.Size = New System.Drawing.Size(523, 119)
        Me.Frame3D1.TabIndex = 5
        Me.Frame3D1.TabStop = False
        Me.Frame3D1.Text = "条件指定"
        '
        'HD_ENDBNKNM
        '
        Me.HD_ENDBNKNM.AcceptsReturn = True
        Me.HD_ENDBNKNM.BackColor = System.Drawing.SystemColors.Window
        Me.HD_ENDBNKNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_ENDBNKNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_ENDBNKNM.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_ENDBNKNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_ENDBNKNM.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_ENDBNKNM.Location = New System.Drawing.Point(140, 64)
        Me.HD_ENDBNKNM.MaxLength = 54
        Me.HD_ENDBNKNM.Name = "HD_ENDBNKNM"
        Me.HD_ENDBNKNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_ENDBNKNM.Size = New System.Drawing.Size(361, 19)
        Me.HD_ENDBNKNM.TabIndex = 20
        Me.HD_ENDBNKNM.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5"
        '
        'HD_STTBNKNM
        '
        Me.HD_STTBNKNM.AcceptsReturn = True
        Me.HD_STTBNKNM.BackColor = System.Drawing.SystemColors.Window
        Me.HD_STTBNKNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_STTBNKNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_STTBNKNM.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_STTBNKNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_STTBNKNM.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_STTBNKNM.Location = New System.Drawing.Point(140, 32)
        Me.HD_STTBNKNM.MaxLength = 54
        Me.HD_STTBNKNM.Name = "HD_STTBNKNM"
        Me.HD_STTBNKNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_STTBNKNM.Size = New System.Drawing.Size(361, 19)
        Me.HD_STTBNKNM.TabIndex = 19
        Me.HD_STTBNKNM.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5"
        '
        'HD_ENDBNKCD
        '
        Me.HD_ENDBNKCD.AcceptsReturn = True
        Me.HD_ENDBNKCD.BackColor = System.Drawing.Color.White
        Me.HD_ENDBNKCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_ENDBNKCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_ENDBNKCD.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_ENDBNKCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_ENDBNKCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_ENDBNKCD.Location = New System.Drawing.Point(80, 64)
        Me.HD_ENDBNKCD.MaxLength = 11
        Me.HD_ENDBNKCD.Name = "HD_ENDBNKCD"
        Me.HD_ENDBNKCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_ENDBNKCD.Size = New System.Drawing.Size(60, 19)
        Me.HD_ENDBNKCD.TabIndex = 7
        Me.HD_ENDBNKCD.Text = "XXXXXX7"
        '
        'HD_STTBNKCD
        '
        Me.HD_STTBNKCD.AcceptsReturn = True
        Me.HD_STTBNKCD.BackColor = System.Drawing.Color.White
        Me.HD_STTBNKCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_STTBNKCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_STTBNKCD.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_STTBNKCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_STTBNKCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_STTBNKCD.Location = New System.Drawing.Point(80, 32)
        Me.HD_STTBNKCD.MaxLength = 11
        Me.HD_STTBNKCD.Name = "HD_STTBNKCD"
        Me.HD_STTBNKCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_STTBNKCD.Size = New System.Drawing.Size(60, 19)
        Me.HD_STTBNKCD.TabIndex = 6
        Me.HD_STTBNKCD.Text = "XXXXXX7"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(33, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(44, 25)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "銀行"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(56, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(25, 25)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "〜"
        '
        'FM_Panel3D1
        '
        Me.FM_Panel3D1.Controls.Add(Me.TX_Mode)
        Me.FM_Panel3D1.Controls.Add(Me._IM_LSTART_0)
        Me.FM_Panel3D1.Controls.Add(Me._IM_Slist_0)
        Me.FM_Panel3D1.Controls.Add(Me._IM_EndCm_1)
        Me.FM_Panel3D1.Controls.Add(Me._IM_EndCm_0)
        Me.FM_Panel3D1.Controls.Add(Me._IM_Slist_1)
        Me.FM_Panel3D1.Controls.Add(Me._IM_LSTART_1)
        Me.FM_Panel3D1.Controls.Add(Me._IM_VSTART_0)
        Me.FM_Panel3D1.Controls.Add(Me._IM_VSTART_1)
        Me.FM_Panel3D1.Controls.Add(Me._IM_FSTART_0)
        Me.FM_Panel3D1.Controls.Add(Me._IM_FSTART_1)
        Me.FM_Panel3D1.Controls.Add(Me._IM_LCONFIG_0)
        Me.FM_Panel3D1.Controls.Add(Me._IM_LCONFIG_1)
        Me.FM_Panel3D1.Controls.Add(Me._IM_Denkyu_1)
        Me.FM_Panel3D1.Controls.Add(Me._IM_Denkyu_2)
        Me.FM_Panel3D1.Location = New System.Drawing.Point(18, 384)
        Me.FM_Panel3D1.Name = "FM_Panel3D1"
        Me.FM_Panel3D1.Size = New System.Drawing.Size(553, 94)
        Me.FM_Panel3D1.TabIndex = 3
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
        Me.TX_Mode.TabIndex = 4
        Me.TX_Mode.Text = "ﾓｰﾄﾞ"
        '
        '_IM_LSTART_0
        '
        Me._IM_LSTART_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_LSTART_0.Image = CType(resources.GetObject("_IM_LSTART_0.Image"), System.Drawing.Image)
        Me.IM_LSTART.SetIndex(Me._IM_LSTART_0, CType(0, Short))
        Me._IM_LSTART_0.Location = New System.Drawing.Point(123, 3)
        Me._IM_LSTART_0.Name = "_IM_LSTART_0"
        Me._IM_LSTART_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_LSTART_0.TabIndex = 5
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
        Me._IM_Slist_0.TabIndex = 6
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
        Me._IM_EndCm_1.TabIndex = 7
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
        Me._IM_EndCm_0.TabIndex = 8
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
        Me._IM_Slist_1.TabIndex = 9
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
        Me._IM_LSTART_1.TabIndex = 10
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
        Me._IM_VSTART_0.TabIndex = 11
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
        Me._IM_VSTART_1.TabIndex = 12
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
        Me._IM_FSTART_0.TabIndex = 13
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
        Me._IM_FSTART_1.TabIndex = 14
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
        Me._IM_LCONFIG_0.TabIndex = 15
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
        Me._IM_LCONFIG_1.TabIndex = 16
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
        Me._IM_Denkyu_1.TabIndex = 17
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
        Me._IM_Denkyu_2.TabIndex = 18
        Me._IM_Denkyu_2.TabStop = False
        '
        'CMDialogL
        '
        Me.CMDialogL.Title = "CMDialogL"
        '
        'FM_Panel3D14
        '
        'Me.FM_Panel3D14.Controls.Add(Me.SYSDT)
        Me.FM_Panel3D14.Controls.Add(Me.Label3)
        Me.FM_Panel3D14.Controls.Add(Me.CM_SLIST)
        Me.FM_Panel3D14.Controls.Add(Me.CM_EndCm)
        Me.FM_Panel3D14.Controls.Add(Me.CM_LCONFIG)
        Me.FM_Panel3D14.Controls.Add(Me.CM_FSTART)
        Me.FM_Panel3D14.Controls.Add(Me.Image1)
        Me.FM_Panel3D14.Location = New System.Drawing.Point(-3, 0)
        Me.FM_Panel3D14.Name = "FM_Panel3D14"
        Me.FM_Panel3D14.Size = New System.Drawing.Size(580, 37)
        Me.FM_Panel3D14.TabIndex = 1
        '
        'SYSDT
        '
        Me.SYSDT.Location = New System.Drawing.Point(438, 9)
        Me.SYSDT.Name = "SYSDT"
        Me.SYSDT.Size = New System.Drawing.Size(94, 19)
        Me.SYSDT.TabIndex = 2
        Me.SYSDT.Text = "YYYY/MM/DD"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(312, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(57, 33)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "　"
        '
        'CM_SLIST
        '
        Me.CM_SLIST.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_SLIST.Image = CType(resources.GetObject("CM_SLIST.Image"), System.Drawing.Image)
        Me.CM_SLIST.Location = New System.Drawing.Point(112, 6)
        Me.CM_SLIST.Name = "CM_SLIST"
        Me.CM_SLIST.Size = New System.Drawing.Size(24, 22)
        Me.CM_SLIST.TabIndex = 16
        Me.CM_SLIST.TabStop = False
        '
        'CM_EndCm
        '
        Me.CM_EndCm.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_EndCm.Image = CType(resources.GetObject("CM_EndCm.Image"), System.Drawing.Image)
        Me.CM_EndCm.Location = New System.Drawing.Point(15, 6)
        Me.CM_EndCm.Name = "CM_EndCm"
        Me.CM_EndCm.Size = New System.Drawing.Size(24, 22)
        Me.CM_EndCm.TabIndex = 17
        Me.CM_EndCm.TabStop = False
        '
        'CM_LSTART
        '
        Me.CM_LSTART.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_LSTART.Image = CType(resources.GetObject("CM_LSTART.Image"), System.Drawing.Image)
        Me.CM_LSTART.Location = New System.Drawing.Point(39, 6)
        Me.CM_LSTART.Name = "CM_LSTART"
        Me.CM_LSTART.Size = New System.Drawing.Size(24, 22)
        Me.CM_LSTART.TabIndex = 18
        Me.CM_LSTART.TabStop = False
        '
        'CM_LCONFIG
        '
        Me.CM_LCONFIG.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_LCONFIG.Image = CType(resources.GetObject("CM_LCONFIG.Image"), System.Drawing.Image)
        Me.CM_LCONFIG.Location = New System.Drawing.Point(88, 6)
        Me.CM_LCONFIG.Name = "CM_LCONFIG"
        Me.CM_LCONFIG.Size = New System.Drawing.Size(24, 22)
        Me.CM_LCONFIG.TabIndex = 19
        Me.CM_LCONFIG.TabStop = False
        '
        'CM_VSTART
        '
        Me.CM_VSTART.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_VSTART.Image = CType(resources.GetObject("CM_VSTART.Image"), System.Drawing.Image)
        Me.CM_VSTART.Location = New System.Drawing.Point(63, 6)
        Me.CM_VSTART.Name = "CM_VSTART"
        Me.CM_VSTART.Size = New System.Drawing.Size(24, 22)
        Me.CM_VSTART.TabIndex = 20
        Me.CM_VSTART.TabStop = False
        '
        'CM_FSTART
        '
        Me.CM_FSTART.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_FSTART.Image = CType(resources.GetObject("CM_FSTART.Image"), System.Drawing.Image)
        Me.CM_FSTART.Location = New System.Drawing.Point(328, 6)
        Me.CM_FSTART.Name = "CM_FSTART"
        Me.CM_FSTART.Size = New System.Drawing.Size(24, 22)
        Me.CM_FSTART.TabIndex = 21
        Me.CM_FSTART.TabStop = False
        '
        'Image1
        '
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Location = New System.Drawing.Point(0, 0)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(301, 34)
        Me.Image1.TabIndex = 22
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
        Me.TX_CursorRest.Location = New System.Drawing.Point(2457, 2457)
        Me.TX_CursorRest.MaxLength = 0
        Me.TX_CursorRest.Name = "TX_CursorRest"
        Me.TX_CursorRest.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_CursorRest.Size = New System.Drawing.Size(19, 13)
        Me.TX_CursorRest.TabIndex = 0
        '
        '_FM_Panel3D15_0
        '
        Me._FM_Panel3D15_0.Controls.Add(Me._FM_Panel3D2_2)
        Me._FM_Panel3D15_0.Controls.Add(Me._IM_Denkyu_0)
        Me._FM_Panel3D15_0.Location = New System.Drawing.Point(-3, 330)
        Me._FM_Panel3D15_0.Name = "_FM_Panel3D15_0"
        Me._FM_Panel3D15_0.Size = New System.Drawing.Size(580, 43)
        Me._FM_Panel3D15_0.TabIndex = 10
        '
        '_FM_Panel3D2_2
        '
        Me._FM_Panel3D2_2.Controls.Add(Me.TX_Message)
        Me._FM_Panel3D2_2.Location = New System.Drawing.Point(39, 9)
        Me._FM_Panel3D2_2.Name = "_FM_Panel3D2_2"
        Me._FM_Panel3D2_2.Size = New System.Drawing.Size(526, 25)
        Me._FM_Panel3D2_2.TabIndex = 11
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
        Me.TX_Message.Size = New System.Drawing.Size(349, 13)
        Me.TX_Message.TabIndex = 12
        Me.TX_Message.Text = "エラーやプロンプトのメッセージが出力されるところです。"
        Me.TX_Message.Visible = False
        '
        '_IM_Denkyu_0
        '
        Me._IM_Denkyu_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_0.Image = CType(resources.GetObject("_IM_Denkyu_0.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_0, CType(0, Short))
        Me._IM_Denkyu_0.Location = New System.Drawing.Point(12, 9)
        Me._IM_Denkyu_0.Name = "_IM_Denkyu_0"
        Me._IM_Denkyu_0.Size = New System.Drawing.Size(20, 22)
        Me._IM_Denkyu_0.TabIndex = 12
        Me._IM_Denkyu_0.TabStop = False
        Me._IM_Denkyu_0.Visible = False
        '
        'GAUGE
        '
        Me.GAUGE.Location = New System.Drawing.Point(30, 234)
        Me.GAUGE.Name = "GAUGE"
        Me.GAUGE.Size = New System.Drawing.Size(507, 28)
        Me.GAUGE.TabIndex = 13
        Me.GAUGE.Text = "Panel3D2"
        '
        'CM_LCANCEL
        '
        Me.CM_LCANCEL.Location = New System.Drawing.Point(246, 276)
        Me.CM_LCANCEL.Name = "CM_LCANCEL"
        Me.CM_LCANCEL.Size = New System.Drawing.Size(76, 19)
        Me.CM_LCANCEL.TabIndex = 14
        Me.CM_LCANCEL.TabStop = False
        Me.CM_LCANCEL.Text = "中 止"
        '
        '_FM_Panel3D4_4
        '
        Me._FM_Panel3D4_4.Location = New System.Drawing.Point(272, 48)
        Me._FM_Panel3D4_4.Name = "_FM_Panel3D4_4"
        Me._FM_Panel3D4_4.Size = New System.Drawing.Size(79, 22)
        Me._FM_Panel3D4_4.TabIndex = 18
        Me._FM_Panel3D4_4.Text = "入力担当者"
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MN_Ctrl, Me.MN_EditMn, Me.MN_Oprt, Me.SM_ShortCut})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(998, 24)
        Me.MainMenu1.TabIndex = 19
        '
        'MN_Ctrl
        '
        Me.MN_Ctrl.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MN_LSTART, Me.MN_VSTART, Me.MN_FSTART, Me.MN_LCONFIG, Me.bar11, Me.MN_EndCm})
        Me.MN_Ctrl.Name = "MN_Ctrl"
        Me.MN_Ctrl.Size = New System.Drawing.Size(57, 20)
        Me.MN_Ctrl.Text = "処理(&1)"
        '
        'MN_LSTART
        '
        Me.MN_LSTART.Name = "MN_LSTART"
        Me.MN_LSTART.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.MN_LSTART.Size = New System.Drawing.Size(153, 22)
        Me.MN_LSTART.Text = "印刷(&P)"
        '
        'MN_VSTART
        '
        Me.MN_VSTART.Name = "MN_VSTART"
        Me.MN_VSTART.Size = New System.Drawing.Size(153, 22)
        Me.MN_VSTART.Text = "画面表示"
        '
        'MN_FSTART
        '
        Me.MN_FSTART.Name = "MN_FSTART"
        Me.MN_FSTART.Size = New System.Drawing.Size(153, 22)
        Me.MN_FSTART.Text = "ファイル出力"
        '
        'MN_LCONFIG
        '
        Me.MN_LCONFIG.Name = "MN_LCONFIG"
        Me.MN_LCONFIG.Size = New System.Drawing.Size(153, 22)
        Me.MN_LCONFIG.Text = "印刷設定(&I)..."
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
        Me.MN_EditMn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MN_APPENDC, Me.MN_ClearItm, Me.MN_UnDoItem, Me.Bar21, Me.MN_Cut, Me.MN_Copy, Me.MN_Paste})
        Me.MN_EditMn.Name = "MN_EditMn"
        Me.MN_EditMn.Size = New System.Drawing.Size(57, 20)
        Me.MN_EditMn.Text = "編集(&2)"
        '
        'MN_APPENDC
        '
        Me.MN_APPENDC.Name = "MN_APPENDC"
        Me.MN_APPENDC.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.MN_APPENDC.Size = New System.Drawing.Size(187, 22)
        Me.MN_APPENDC.Text = "画面初期化(&S)"
        '
        'MN_ClearItm
        '
        Me.MN_ClearItm.Name = "MN_ClearItm"
        Me.MN_ClearItm.Size = New System.Drawing.Size(187, 22)
        Me.MN_ClearItm.Text = "項目初期化"
        '
        'MN_UnDoItem
        '
        Me.MN_UnDoItem.Name = "MN_UnDoItem"
        Me.MN_UnDoItem.Size = New System.Drawing.Size(187, 22)
        Me.MN_UnDoItem.Text = "項目復元"
        '
        'Bar21
        '
        Me.Bar21.Name = "Bar21"
        Me.Bar21.Size = New System.Drawing.Size(184, 6)
        '
        'MN_Cut
        '
        Me.MN_Cut.Name = "MN_Cut"
        Me.MN_Cut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.MN_Cut.Size = New System.Drawing.Size(187, 22)
        Me.MN_Cut.Text = "切り取り(&X)"
        '
        'MN_Copy
        '
        Me.MN_Copy.Name = "MN_Copy"
        Me.MN_Copy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.MN_Copy.Size = New System.Drawing.Size(187, 22)
        Me.MN_Copy.Text = "コピー(&C)"
        '
        'MN_Paste
        '
        Me.MN_Paste.Name = "MN_Paste"
        Me.MN_Paste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.MN_Paste.Size = New System.Drawing.Size(187, 22)
        Me.MN_Paste.Text = "貼り付け(&V)"
        '
        'MN_Oprt
        '
        Me.MN_Oprt.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MN_Slist})
        Me.MN_Oprt.Name = "MN_Oprt"
        Me.MN_Oprt.Size = New System.Drawing.Size(57, 20)
        Me.MN_Oprt.Text = "補助(&3)"
        '
        'MN_Slist
        '
        Me.MN_Slist.Name = "MN_Slist"
        Me.MN_Slist.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.MN_Slist.Size = New System.Drawing.Size(175, 22)
        Me.MN_Slist.Text = "ウインドウ表示(&L)"
        '
        'SM_ShortCut
        '
        Me.SM_ShortCut.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SM_AllCopy, Me.SM_FullPast, Me.SM_Esc})
        Me.SM_ShortCut.Name = "SM_ShortCut"
        Me.SM_ShortCut.Size = New System.Drawing.Size(65, 20)
        Me.SM_ShortCut.Text = "ShortCut"
        Me.SM_ShortCut.Visible = False
        '
        'SM_AllCopy
        '
        Me.SM_AllCopy.Name = "SM_AllCopy"
        Me.SM_AllCopy.Size = New System.Drawing.Size(163, 22)
        Me.SM_AllCopy.Text = "項目内容コピー(&C)"
        '
        'SM_FullPast
        '
        Me.SM_FullPast.Name = "SM_FullPast"
        Me.SM_FullPast.Size = New System.Drawing.Size(163, 22)
        Me.SM_FullPast.Text = "項目に貼り付け(&P)"
        '
        'SM_Esc
        '
        Me.SM_Esc.Name = "SM_Esc"
        Me.SM_Esc.Size = New System.Drawing.Size(163, 22)
        Me.SM_Esc.Text = "取消し(Esc)"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 438)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(998, 23)
        Me.StatusStrip1.TabIndex = 257
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(196, 18)
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(196, 18)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "端末ID"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(196, 18)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Text = "ログインID"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(196, 18)
        Me.ToolStripStatusLabel4.Spring = True
        Me.ToolStripStatusLabel4.Text = "XXXXXXX"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(196, 18)
        Me.ToolStripStatusLabel5.Spring = True
        Me.ToolStripStatusLabel5.Text = "Ver.1.00"
        '
        'btnF12
        '
        Me.btnF12.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF12.Location = New System.Drawing.Point(902, 301)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(75, 35)
        Me.btnF12.TabIndex = 269
        Me.btnF12.Text = "(F12)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'btnF11
        '
        Me.btnF11.Enabled = False
        Me.btnF11.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF11.Location = New System.Drawing.Point(825, 301)
        Me.btnF11.Name = "btnF11"
        Me.btnF11.Size = New System.Drawing.Size(75, 35)
        Me.btnF11.TabIndex = 268
        Me.btnF11.Text = "(F11)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF11.UseVisualStyleBackColor = True
        '
        'btnF10
        '
        Me.btnF10.Enabled = False
        Me.btnF10.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF10.Location = New System.Drawing.Point(747, 301)
        Me.btnF10.Name = "btnF10"
        Me.btnF10.Size = New System.Drawing.Size(75, 35)
        Me.btnF10.TabIndex = 267
        Me.btnF10.Text = "(F10)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF10.UseVisualStyleBackColor = True
        '
        'btnF9
        '
        Me.btnF9.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF9.Location = New System.Drawing.Point(670, 301)
        Me.btnF9.Name = "btnF9"
        Me.btnF9.Size = New System.Drawing.Size(75, 35)
        Me.btnF9.TabIndex = 266
        Me.btnF9.Text = "(F9)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "クリア"
        Me.btnF9.UseVisualStyleBackColor = True
        '
        'btnF8
        '
        Me.btnF8.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF8.Location = New System.Drawing.Point(576, 301)
        Me.btnF8.Name = "btnF8"
        Me.btnF8.Size = New System.Drawing.Size(75, 35)
        Me.btnF8.TabIndex = 265
        Me.btnF8.Text = "(F8)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "行削除"
        Me.btnF8.UseVisualStyleBackColor = True
        '
        'btnF7
        '
        Me.btnF7.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF7.Location = New System.Drawing.Point(498, 301)
        Me.btnF7.Name = "btnF7"
        Me.btnF7.Size = New System.Drawing.Size(75, 35)
        Me.btnF7.TabIndex = 264
        Me.btnF7.Text = "(F7)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "行追加"
        Me.btnF7.UseVisualStyleBackColor = True
        '
        'btnF6
        '
        Me.btnF6.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF6.Location = New System.Drawing.Point(420, 301)
        Me.btnF6.Name = "btnF6"
        Me.btnF6.Size = New System.Drawing.Size(75, 35)
        Me.btnF6.TabIndex = 263
        Me.btnF6.Text = "(F6)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "モード"
        Me.btnF6.UseVisualStyleBackColor = True
        '
        'btnF5
        '
        Me.btnF5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF5.Location = New System.Drawing.Point(342, 301)
        Me.btnF5.Name = "btnF5"
        Me.btnF5.Size = New System.Drawing.Size(75, 35)
        Me.btnF5.TabIndex = 262
        Me.btnF5.Text = "(F5)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "参照"
        Me.btnF5.UseVisualStyleBackColor = True
        '
        'btnF4
        '
        Me.btnF4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF4.Location = New System.Drawing.Point(248, 301)
        Me.btnF4.Name = "btnF4"
        Me.btnF4.Size = New System.Drawing.Size(75, 35)
        Me.btnF4.TabIndex = 261
        Me.btnF4.Text = "(F4)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "次頁"
        Me.btnF4.UseVisualStyleBackColor = True
        '
        'btnF3
        '
        Me.btnF3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF3.Location = New System.Drawing.Point(169, 301)
        Me.btnF3.Name = "btnF3"
        Me.btnF3.Size = New System.Drawing.Size(75, 35)
        Me.btnF3.TabIndex = 260
        Me.btnF3.Text = "(F3)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "削除"
        Me.btnF3.UseVisualStyleBackColor = True
        '
        'btnF2
        '
        Me.btnF2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF2.Location = New System.Drawing.Point(90, 301)
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(75, 35)
        Me.btnF2.TabIndex = 259
        Me.btnF2.Text = "(F2)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "検索"
        Me.btnF2.UseVisualStyleBackColor = True
        '
        'btnF1
        '
        Me.btnF1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF1.Location = New System.Drawing.Point(11, 301)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(75, 35)
        Me.btnF1.TabIndex = 258
        Me.btnF1.Text = "(F1)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "更新"
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'FR_SSSMAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(998, 461)
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
        Me.Controls.Add(Me.SYSDT)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.HD_OPENM)
        Me.Controls.Add(Me.HD_OPEID)
        Me.Controls.Add(Me.Frame3D1)
        Me.Controls.Add(Me.FM_Panel3D1)
        Me.Controls.Add(Me.FM_Panel3D14)
        Me.Controls.Add(Me.TX_CursorRest)
        Me.Controls.Add(Me._FM_Panel3D15_0)
        Me.Controls.Add(Me.GAUGE)
        Me.Controls.Add(Me.CM_LCANCEL)
        Me.Controls.Add(Me.CM_LSTART)
        Me.Controls.Add(Me.CM_VSTART)
        Me.Controls.Add(Me.CM_FSTART)
        'Me.Controls.Add(Me.MN_VSTART)
        'Me.Controls.Add(Me.MN_LSTART)
        Me.Controls.Add(Me._FM_Panel3D4_4)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(129, 264)
        Me.MaximizeBox = False
        Me.Name = "FR_SSSMAIN"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "銀行一覧マスタリスト"
        Me.Frame3D1.ResumeLayout(False)
        Me.Frame3D1.PerformLayout()
        Me.FM_Panel3D1.ResumeLayout(False)
        Me.FM_Panel3D1.PerformLayout()
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
        Me.FM_Panel3D14.ResumeLayout(False)
        CType(Me.CM_SLIST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_EndCm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_LSTART, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_LCONFIG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_VSTART, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_FSTART, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        Me._FM_Panel3D15_0.ResumeLayout(False)
        Me._FM_Panel3D2_2.ResumeLayout(False)
        Me._FM_Panel3D2_2.PerformLayout()
        CType(Me._IM_Denkyu_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FM_Panel3D15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FM_Panel3D2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FM_Panel3D4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_Denkyu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_EndCm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_FSTART, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_LCONFIG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_LSTART, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_Slist, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_VSTART, System.ComponentModel.ISupportInitialize).EndInit()
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