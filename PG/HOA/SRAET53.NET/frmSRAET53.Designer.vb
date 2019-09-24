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
	Public WithEvents txtDummy As System.Windows.Forms.TextBox
	Public WithEvents _IM_Denkyu_2 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Denkyu_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Execute_2 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Execute_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_EndCm_2 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_EndCm_1 As System.Windows.Forms.PictureBox
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents SSPanel52 As Label
    Public WithEvents SSPanel51 As Label
    Public WithEvents vaData As GrapeCity.Win.MultiRow.GcMultiRow
    Public WithEvents TX_Message As System.Windows.Forms.TextBox
    Public WithEvents _FM_Panel3D2_2 As Label
    Public WithEvents _IM_Denkyu_0 As System.Windows.Forms.PictureBox
    Public WithEvents _FM_Panel3D15_0 As Label
    Public WithEvents CM_Execute As System.Windows.Forms.PictureBox
	Public WithEvents CM_EndCm As System.Windows.Forms.PictureBox
	Public WithEvents Image1 As System.Windows.Forms.PictureBox
    Public WithEvents SSPanel53 As Label
    Public WithEvents Image2 As System.Windows.Forms.PictureBox
	Public WithEvents lblDUMMY As System.Windows.Forms.Label
	Public WithEvents lblURISU As System.Windows.Forms.Label
	Public WithEvents lblHIN2 As System.Windows.Forms.Label
	Public WithEvents lblHIN1 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents FM_Panel3D15 As VB6.PanelArray
    Public WithEvents FM_Panel3D2 As VB6.PanelArray
    Public WithEvents IM_Denkyu As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_EndCm As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_Execute As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents MN_Execute As System.Windows.Forms.ToolStripMenuItem
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
        Me.txtDummy = New System.Windows.Forms.TextBox()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me._IM_Denkyu_2 = New System.Windows.Forms.PictureBox()
        Me._IM_Denkyu_1 = New System.Windows.Forms.PictureBox()
        Me._IM_Execute_2 = New System.Windows.Forms.PictureBox()
        Me._IM_Execute_1 = New System.Windows.Forms.PictureBox()
        Me._IM_EndCm_2 = New System.Windows.Forms.PictureBox()
        Me._IM_EndCm_1 = New System.Windows.Forms.PictureBox()
        Me.SSPanel52 = New System.Windows.Forms.Label()
        Me.SSPanel51 = New System.Windows.Forms.Label()
        Me._FM_Panel3D15_0 = New System.Windows.Forms.Label()
        Me._FM_Panel3D2_2 = New System.Windows.Forms.Label()
        Me.TX_Message = New System.Windows.Forms.TextBox()
        Me._IM_Denkyu_0 = New System.Windows.Forms.PictureBox()
        Me.SSPanel53 = New System.Windows.Forms.Label()
        Me.CM_Execute = New System.Windows.Forms.PictureBox()
        Me.CM_EndCm = New System.Windows.Forms.PictureBox()
        Me.Image1 = New System.Windows.Forms.PictureBox()
        Me.Image2 = New System.Windows.Forms.PictureBox()
        Me.lblDUMMY = New System.Windows.Forms.Label()
        Me.lblURISU = New System.Windows.Forms.Label()
        Me.lblHIN2 = New System.Windows.Forms.Label()
        Me.lblHIN1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.FM_Panel3D15 = New Microsoft.VisualBasic.Compatibility.VB6.PanelArray(Me.components)
        Me.FM_Panel3D2 = New Microsoft.VisualBasic.Compatibility.VB6.PanelArray(Me.components)
        Me.IM_Denkyu = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_EndCm = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_Execute = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.MN_Ctrl = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_Execute = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.Frame1.SuspendLayout()
        CType(Me._IM_Denkyu_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Denkyu_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Execute_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Execute_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_EndCm_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_EndCm_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._FM_Panel3D15_0.SuspendLayout()
        CType(Me._IM_Denkyu_0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SSPanel53.SuspendLayout()
        CType(Me.CM_Execute, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_EndCm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FM_Panel3D15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FM_Panel3D2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_Denkyu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_EndCm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_Execute, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainMenu1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDummy
        '
        Me.txtDummy.AcceptsReturn = True
        Me.txtDummy.BackColor = System.Drawing.SystemColors.Window
        Me.txtDummy.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDummy.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDummy.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDummy.Location = New System.Drawing.Point(320, 320)
        Me.txtDummy.MaxLength = 0
        Me.txtDummy.Name = "txtDummy"
        Me.txtDummy.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDummy.Size = New System.Drawing.Size(1, 13)
        Me.txtDummy.TabIndex = 15
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me._IM_Denkyu_2)
        Me.Frame1.Controls.Add(Me._IM_Denkyu_1)
        Me.Frame1.Controls.Add(Me._IM_Execute_2)
        Me.Frame1.Controls.Add(Me._IM_Execute_1)
        Me.Frame1.Controls.Add(Me._IM_EndCm_2)
        Me.Frame1.Controls.Add(Me._IM_EndCm_1)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(32, 389)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(273, 49)
        Me.Frame1.TabIndex = 9
        Me.Frame1.TabStop = False
        '
        '_IM_Denkyu_2
        '
        Me._IM_Denkyu_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_2.Image = CType(resources.GetObject("_IM_Denkyu_2.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_2, CType(2, Short))
        Me._IM_Denkyu_2.Location = New System.Drawing.Point(160, 16)
        Me._IM_Denkyu_2.Name = "_IM_Denkyu_2"
        Me._IM_Denkyu_2.Size = New System.Drawing.Size(20, 22)
        Me._IM_Denkyu_2.TabIndex = 0
        Me._IM_Denkyu_2.TabStop = False
        '
        '_IM_Denkyu_1
        '
        Me._IM_Denkyu_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_1.Image = CType(resources.GetObject("_IM_Denkyu_1.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_1, CType(1, Short))
        Me._IM_Denkyu_1.Location = New System.Drawing.Point(128, 16)
        Me._IM_Denkyu_1.Name = "_IM_Denkyu_1"
        Me._IM_Denkyu_1.Size = New System.Drawing.Size(20, 22)
        Me._IM_Denkyu_1.TabIndex = 1
        Me._IM_Denkyu_1.TabStop = False
        '
        '_IM_Execute_2
        '
        Me._IM_Execute_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Execute_2.Image = CType(resources.GetObject("_IM_Execute_2.Image"), System.Drawing.Image)
        Me.IM_Execute.SetIndex(Me._IM_Execute_2, CType(2, Short))
        Me._IM_Execute_2.Location = New System.Drawing.Point(96, 16)
        Me._IM_Execute_2.Name = "_IM_Execute_2"
        Me._IM_Execute_2.Size = New System.Drawing.Size(24, 22)
        Me._IM_Execute_2.TabIndex = 2
        Me._IM_Execute_2.TabStop = False
        '
        '_IM_Execute_1
        '
        Me._IM_Execute_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Execute_1.Image = CType(resources.GetObject("_IM_Execute_1.Image"), System.Drawing.Image)
        Me.IM_Execute.SetIndex(Me._IM_Execute_1, CType(1, Short))
        Me._IM_Execute_1.Location = New System.Drawing.Point(72, 16)
        Me._IM_Execute_1.Name = "_IM_Execute_1"
        Me._IM_Execute_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_Execute_1.TabIndex = 3
        Me._IM_Execute_1.TabStop = False
        '
        '_IM_EndCm_2
        '
        Me._IM_EndCm_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_EndCm_2.Image = CType(resources.GetObject("_IM_EndCm_2.Image"), System.Drawing.Image)
        Me.IM_EndCm.SetIndex(Me._IM_EndCm_2, CType(2, Short))
        Me._IM_EndCm_2.Location = New System.Drawing.Point(40, 16)
        Me._IM_EndCm_2.Name = "_IM_EndCm_2"
        Me._IM_EndCm_2.Size = New System.Drawing.Size(24, 22)
        Me._IM_EndCm_2.TabIndex = 4
        Me._IM_EndCm_2.TabStop = False
        '
        '_IM_EndCm_1
        '
        Me._IM_EndCm_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_EndCm_1.Image = CType(resources.GetObject("_IM_EndCm_1.Image"), System.Drawing.Image)
        Me.IM_EndCm.SetIndex(Me._IM_EndCm_1, CType(1, Short))
        Me._IM_EndCm_1.Location = New System.Drawing.Point(16, 16)
        Me._IM_EndCm_1.Name = "_IM_EndCm_1"
        Me._IM_EndCm_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_EndCm_1.TabIndex = 5
        Me._IM_EndCm_1.TabStop = False
        '
        'SSPanel52
        '
        Me.SSPanel52.Location = New System.Drawing.Point(48, 99)
        Me.SSPanel52.Name = "SSPanel52"
        Me.SSPanel52.Size = New System.Drawing.Size(60, 22)
        Me.SSPanel52.TabIndex = 8
        Me.SSPanel52.Text = "数 量"
        '
        'SSPanel51
        '
        Me.SSPanel51.Location = New System.Drawing.Point(48, 50)
        Me.SSPanel51.Name = "SSPanel51"
        Me.SSPanel51.Size = New System.Drawing.Size(60, 43)
        Me.SSPanel51.TabIndex = 7
        Me.SSPanel51.Text = "製 品"
        '
        '_FM_Panel3D15_0
        '
        Me._FM_Panel3D15_0.Controls.Add(Me._FM_Panel3D2_2)
        Me._FM_Panel3D15_0.Location = New System.Drawing.Point(0, 352)
        Me._FM_Panel3D15_0.Name = "_FM_Panel3D15_0"
        Me._FM_Panel3D15_0.Size = New System.Drawing.Size(377, 43)
        Me._FM_Panel3D15_0.TabIndex = 10
        '
        '_FM_Panel3D2_2
        '
        Me._FM_Panel3D2_2.Location = New System.Drawing.Point(39, 9)
        Me._FM_Panel3D2_2.Name = "_FM_Panel3D2_2"
        Me._FM_Panel3D2_2.Size = New System.Drawing.Size(330, 25)
        Me._FM_Panel3D2_2.TabIndex = 11
        '
        'TX_Message
        '
        Me.TX_Message.AcceptsReturn = True
        Me.TX_Message.BackColor = System.Drawing.SystemColors.Control
        Me.TX_Message.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TX_Message.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TX_Message.ForeColor = System.Drawing.Color.Black
        Me.TX_Message.Location = New System.Drawing.Point(42, 364)
        Me.TX_Message.MaxLength = 0
        Me.TX_Message.Multiline = True
        Me.TX_Message.Name = "TX_Message"
        Me.TX_Message.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_Message.Size = New System.Drawing.Size(397, 19)
        Me.TX_Message.TabIndex = 12
        Me.TX_Message.Text = "エラーやプロンプトのメッセージが出力されるところです。"
        '
        '_IM_Denkyu_0
        '
        Me._IM_Denkyu_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_0.Image = CType(resources.GetObject("_IM_Denkyu_0.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_0, CType(0, Short))
        Me._IM_Denkyu_0.Location = New System.Drawing.Point(13, 361)
        Me._IM_Denkyu_0.Name = "_IM_Denkyu_0"
        Me._IM_Denkyu_0.Size = New System.Drawing.Size(20, 22)
        Me._IM_Denkyu_0.TabIndex = 12
        Me._IM_Denkyu_0.TabStop = False
        '
        'SSPanel53
        '
        Me.SSPanel53.Controls.Add(Me.CM_Execute)
        Me.SSPanel53.Controls.Add(Me.CM_EndCm)
        Me.SSPanel53.Controls.Add(Me.Image1)
        Me.SSPanel53.Location = New System.Drawing.Point(0, 0)
        Me.SSPanel53.Name = "SSPanel53"
        Me.SSPanel53.Size = New System.Drawing.Size(377, 41)
        Me.SSPanel53.TabIndex = 13
        '
        'CM_Execute
        '
        Me.CM_Execute.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_Execute.Image = CType(resources.GetObject("CM_Execute.Image"), System.Drawing.Image)
        Me.CM_Execute.Location = New System.Drawing.Point(32, 8)
        Me.CM_Execute.Name = "CM_Execute"
        Me.CM_Execute.Size = New System.Drawing.Size(24, 22)
        Me.CM_Execute.TabIndex = 0
        Me.CM_Execute.TabStop = False
        '
        'CM_EndCm
        '
        Me.CM_EndCm.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_EndCm.Image = CType(resources.GetObject("CM_EndCm.Image"), System.Drawing.Image)
        Me.CM_EndCm.Location = New System.Drawing.Point(8, 8)
        Me.CM_EndCm.Name = "CM_EndCm"
        Me.CM_EndCm.Size = New System.Drawing.Size(24, 22)
        Me.CM_EndCm.TabIndex = 1
        Me.CM_EndCm.TabStop = False
        '
        'Image1
        '
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Location = New System.Drawing.Point(0, 0)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(205, 37)
        Me.Image1.TabIndex = 2
        Me.Image1.TabStop = False
        '
        'Image2
        '
        Me.Image2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Image2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image2.Location = New System.Drawing.Point(40, 120)
        Me.Image2.Name = "Image2"
        Me.Image2.Size = New System.Drawing.Size(233, 225)
        Me.Image2.TabIndex = 16
        Me.Image2.TabStop = False
        '
        'lblDUMMY
        '
        Me.lblDUMMY.BackColor = System.Drawing.SystemColors.Control
        Me.lblDUMMY.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDUMMY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDUMMY.Location = New System.Drawing.Point(0, 0)
        Me.lblDUMMY.Name = "lblDUMMY"
        Me.lblDUMMY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDUMMY.Size = New System.Drawing.Size(9, 25)
        Me.lblDUMMY.TabIndex = 14
        '
        'lblURISU
        '
        Me.lblURISU.BackColor = System.Drawing.Color.Transparent
        Me.lblURISU.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblURISU.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblURISU.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblURISU.Location = New System.Drawing.Point(117, 104)
        Me.lblURISU.Name = "lblURISU"
        Me.lblURISU.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblURISU.Size = New System.Drawing.Size(51, 15)
        Me.lblURISU.TabIndex = 3
        Me.lblURISU.Text = "-999,999"
        Me.lblURISU.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblHIN2
        '
        Me.lblHIN2.BackColor = System.Drawing.Color.Transparent
        Me.lblHIN2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHIN2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHIN2.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblHIN2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblHIN2.Location = New System.Drawing.Point(113, 76)
        Me.lblHIN2.Name = "lblHIN2"
        Me.lblHIN2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHIN2.Size = New System.Drawing.Size(212, 16)
        Me.lblHIN2.TabIndex = 2
        Me.lblHIN2.Text = "XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3"
        '
        'lblHIN1
        '
        Me.lblHIN1.BackColor = System.Drawing.Color.Transparent
        Me.lblHIN1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHIN1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHIN1.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblHIN1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblHIN1.Location = New System.Drawing.Point(112, 55)
        Me.lblHIN1.Name = "lblHIN1"
        Me.lblHIN1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHIN1.Size = New System.Drawing.Size(62, 15)
        Me.lblHIN1.TabIndex = 1
        Me.lblHIN1.Text = "XXXXXXXX"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label8.Location = New System.Drawing.Point(107, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(68, 22)
        Me.Label8.TabIndex = 6
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label6.Location = New System.Drawing.Point(107, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(71, 22)
        Me.Label6.TabIndex = 4
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label7.Location = New System.Drawing.Point(107, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(238, 22)
        Me.Label7.TabIndex = 5
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MN_Ctrl, Me.MN_EditMn})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(1027, 24)
        Me.MainMenu1.TabIndex = 17
        '
        'MN_Ctrl
        '
        Me.MN_Ctrl.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MN_Execute, Me.bar11, Me.MN_EndCm})
        Me.MN_Ctrl.Name = "MN_Ctrl"
        Me.MN_Ctrl.Size = New System.Drawing.Size(77, 20)
        Me.MN_Ctrl.Text = "処理（&1）"
        '
        'MN_Execute
        '
        Me.MN_Execute.Name = "MN_Execute"
        Me.MN_Execute.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.MN_Execute.Size = New System.Drawing.Size(174, 22)
        Me.MN_Execute.Text = "登録（&R）"
        '
        'bar11
        '
        Me.bar11.Name = "bar11"
        Me.bar11.Size = New System.Drawing.Size(171, 6)
        '
        'MN_EndCm
        '
        Me.MN_EndCm.Name = "MN_EndCm"
        Me.MN_EndCm.Size = New System.Drawing.Size(174, 22)
        Me.MN_EndCm.Text = "終了（&X）"
        '
        'MN_EditMn
        '
        Me.MN_EditMn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MN_APPENDC})
        Me.MN_EditMn.Name = "MN_EditMn"
        Me.MN_EditMn.Size = New System.Drawing.Size(77, 20)
        Me.MN_EditMn.Text = "編集（&2）"
        '
        'MN_APPENDC
        '
        Me.MN_APPENDC.Name = "MN_APPENDC"
        Me.MN_APPENDC.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.MN_APPENDC.Size = New System.Drawing.Size(211, 22)
        Me.MN_APPENDC.Text = "画面初期化（&S）"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 486)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1027, 23)
        Me.StatusStrip1.TabIndex = 245
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(202, 18)
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(202, 18)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "端末ID"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(202, 18)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Text = "ログインID"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(202, 18)
        Me.ToolStripStatusLabel4.Spring = True
        Me.ToolStripStatusLabel4.Text = "XXXXXXX"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(202, 18)
        Me.ToolStripStatusLabel5.Spring = True
        Me.ToolStripStatusLabel5.Text = "Ver.1.00"
        '
        'btnF12
        '
        Me.btnF12.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF12.Location = New System.Drawing.Point(911, 444)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(75, 35)
        Me.btnF12.TabIndex = 268
        Me.btnF12.Text = "(F12)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.btnF12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'btnF11
        '
        Me.btnF11.Enabled = False
        Me.btnF11.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF11.Location = New System.Drawing.Point(834, 444)
        Me.btnF11.Name = "btnF11"
        Me.btnF11.Size = New System.Drawing.Size(75, 35)
        Me.btnF11.TabIndex = 267
        Me.btnF11.Text = "(F11)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnF11.UseVisualStyleBackColor = True
        '
        'btnF10
        '
        Me.btnF10.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF10.Location = New System.Drawing.Point(756, 444)
        Me.btnF10.Name = "btnF10"
        Me.btnF10.Size = New System.Drawing.Size(75, 35)
        Me.btnF10.TabIndex = 266
        Me.btnF10.Text = "(F10)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnF10.UseVisualStyleBackColor = True
        '
        'btnF9
        '
        Me.btnF9.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF9.Location = New System.Drawing.Point(679, 444)
        Me.btnF9.Name = "btnF9"
        Me.btnF9.Size = New System.Drawing.Size(75, 35)
        Me.btnF9.TabIndex = 265
        Me.btnF9.Text = "(F9)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "クリア"
        Me.btnF9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnF9.UseVisualStyleBackColor = True
        '
        'btnF8
        '
        Me.btnF8.Enabled = False
        Me.btnF8.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF8.Location = New System.Drawing.Point(585, 444)
        Me.btnF8.Name = "btnF8"
        Me.btnF8.Size = New System.Drawing.Size(75, 35)
        Me.btnF8.TabIndex = 264
        Me.btnF8.Text = "(F8)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnF8.UseVisualStyleBackColor = True
        '
        'btnF7
        '
        Me.btnF7.Enabled = False
        Me.btnF7.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF7.Location = New System.Drawing.Point(507, 444)
        Me.btnF7.Name = "btnF7"
        Me.btnF7.Size = New System.Drawing.Size(75, 35)
        Me.btnF7.TabIndex = 263
        Me.btnF7.Text = "(F7)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnF7.UseVisualStyleBackColor = True
        '
        'btnF6
        '
        Me.btnF6.Enabled = False
        Me.btnF6.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF6.Location = New System.Drawing.Point(429, 444)
        Me.btnF6.Name = "btnF6"
        Me.btnF6.Size = New System.Drawing.Size(75, 35)
        Me.btnF6.TabIndex = 262
        Me.btnF6.Text = "(F6)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnF6.UseVisualStyleBackColor = True
        '
        'btnF5
        '
        Me.btnF5.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF5.Location = New System.Drawing.Point(351, 444)
        Me.btnF5.Name = "btnF5"
        Me.btnF5.Size = New System.Drawing.Size(75, 35)
        Me.btnF5.TabIndex = 261
        Me.btnF5.Text = "(F5)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnF5.UseVisualStyleBackColor = True
        '
        'btnF4
        '
        Me.btnF4.Enabled = False
        Me.btnF4.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF4.Location = New System.Drawing.Point(257, 444)
        Me.btnF4.Name = "btnF4"
        Me.btnF4.Size = New System.Drawing.Size(75, 35)
        Me.btnF4.TabIndex = 260
        Me.btnF4.Text = "(F4)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnF4.UseVisualStyleBackColor = True
        '
        'btnF3
        '
        Me.btnF3.Enabled = False
        Me.btnF3.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF3.Location = New System.Drawing.Point(178, 444)
        Me.btnF3.Name = "btnF3"
        Me.btnF3.Size = New System.Drawing.Size(75, 35)
        Me.btnF3.TabIndex = 259
        Me.btnF3.Text = "(F3)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnF3.UseVisualStyleBackColor = True
        '
        'btnF2
        '
        Me.btnF2.Enabled = False
        Me.btnF2.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF2.Location = New System.Drawing.Point(99, 444)
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(75, 35)
        Me.btnF2.TabIndex = 258
        Me.btnF2.Text = "(F2)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF2.UseVisualStyleBackColor = True
        '
        'btnF1
        '
        Me.btnF1.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF1.Location = New System.Drawing.Point(20, 444)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(75, 35)
        Me.btnF1.TabIndex = 257
        Me.btnF1.Text = "(F1)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "更新"
        Me.btnF1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'FR_SSSMAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1027, 509)
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
        Me.Controls.Add(Me.TX_Message)
        Me.Controls.Add(Me.txtDummy)
        Me.Controls.Add(Me._IM_Denkyu_0)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.SSPanel52)
        Me.Controls.Add(Me.SSPanel51)
        Me.Controls.Add(Me._FM_Panel3D15_0)
        Me.Controls.Add(Me.SSPanel53)
        Me.Controls.Add(Me.Image2)
        Me.Controls.Add(Me.lblDUMMY)
        Me.Controls.Add(Me.lblURISU)
        Me.Controls.Add(Me.lblHIN2)
        Me.Controls.Add(Me.lblHIN1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(10, 56)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FR_SSSMAIN"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "シリアル№登録"
        Me.Frame1.ResumeLayout(False)
        CType(Me._IM_Denkyu_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Denkyu_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Execute_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Execute_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_EndCm_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_EndCm_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me._FM_Panel3D15_0.ResumeLayout(False)
        CType(Me._IM_Denkyu_0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SSPanel53.ResumeLayout(False)
        CType(Me.CM_Execute, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_EndCm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FM_Panel3D15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FM_Panel3D2, System.ComponentModel.ISupportInitialize).EndInit()
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