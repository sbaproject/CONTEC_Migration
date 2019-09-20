<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class WLSNDN
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
	Public WithEvents LST1 As System.Windows.Forms.ListBox
    '2019/05/21 CHG START
    'Public WithEvents _FM_Panel3D2_7 As SSPanel5
    Public WithEvents _FM_Panel3D2_7 As Label
    '2019/05/21 CHG END
	Public WithEvents KEYBAK As System.Windows.Forms.ListBox
    '2019/05/21 CHG START
    'Public WithEvents WLSLABEL As SSPanel5
    Public WithEvents WLSLABEL As Label
    '2019/05/21 CHG END
	Public WithEvents LST As System.Windows.Forms.ListBox
	Public WithEvents WLSOK As System.Windows.Forms.Button
	Public WithEvents WLSCANCEL As System.Windows.Forms.Button
	Public WithEvents WLSNYUCD As System.Windows.Forms.TextBox
	Public WithEvents WLSNDNDT As System.Windows.Forms.TextBox
	Public WithEvents COM_UDNDT As System.Windows.Forms.Button
	Public WithEvents COM_TANCD As System.Windows.Forms.Button
	Public WithEvents WLSTANCD As System.Windows.Forms.TextBox
	Public WithEvents WLSTOKCD As System.Windows.Forms.TextBox
	Public WithEvents COM_TOKCD As System.Windows.Forms.Button
	Public WithEvents WLSJDNTRNM As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents WLSTANNM As System.Windows.Forms.Label
	Public WithEvents WLSTOKRN As System.Windows.Forms.Label
    '2019/05/21CHG START
    'Public WithEvents Panel3D1 As SSPanel5
    Public WithEvents Panel3D1 As Label
    '2019/05/21 CHG END
	Public WithEvents _IM_MAE_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_ATO_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_ATO_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_MAE_0 As System.Windows.Forms.PictureBox
	Public WithEvents WLSMAE As System.Windows.Forms.PictureBox
	Public WithEvents WLSATO As System.Windows.Forms.PictureBox
    '2019/05/21 CHG START
    'Public WithEvents FM_Panel3D2 As SSPanel5Array
    Public WithEvents FM_Panel3D2 As VB6.PanelArray
    '2019/05/21 CHG END
	Public WithEvents IM_ATO As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_MAE As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WLSNDN))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LST1 = New System.Windows.Forms.ListBox()
        Me._FM_Panel3D2_7 = New System.Windows.Forms.Label()
        Me.KEYBAK = New System.Windows.Forms.ListBox()
        Me.WLSLABEL = New System.Windows.Forms.Label()
        Me.LST = New System.Windows.Forms.ListBox()
        Me.WLSOK = New System.Windows.Forms.Button()
        Me.WLSCANCEL = New System.Windows.Forms.Button()
        Me.Panel3D1 = New System.Windows.Forms.Label()
        Me.WLSNYUCD = New System.Windows.Forms.TextBox()
        Me.WLSNDNDT = New System.Windows.Forms.TextBox()
        Me.COM_UDNDT = New System.Windows.Forms.Button()
        Me.COM_TANCD = New System.Windows.Forms.Button()
        Me.WLSTANCD = New System.Windows.Forms.TextBox()
        Me.WLSTOKCD = New System.Windows.Forms.TextBox()
        Me.COM_TOKCD = New System.Windows.Forms.Button()
        Me.WLSJDNTRNM = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.WLSTANNM = New System.Windows.Forms.Label()
        Me.WLSTOKRN = New System.Windows.Forms.Label()
        Me._IM_MAE_1 = New System.Windows.Forms.PictureBox()
        Me._IM_ATO_1 = New System.Windows.Forms.PictureBox()
        Me._IM_ATO_0 = New System.Windows.Forms.PictureBox()
        Me._IM_MAE_0 = New System.Windows.Forms.PictureBox()
        Me.WLSMAE = New System.Windows.Forms.PictureBox()
        Me.WLSATO = New System.Windows.Forms.PictureBox()
        Me.FM_Panel3D2 = New Microsoft.VisualBasic.Compatibility.VB6.PanelArray(Me.components)
        Me.IM_ATO = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_MAE = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.btnF9 = New System.Windows.Forms.Button()
        Me.btnF2 = New System.Windows.Forms.Button()
        Me.btnF1 = New System.Windows.Forms.Button()
        Me.btnF8 = New System.Windows.Forms.Button()
        Me.btnF7 = New System.Windows.Forms.Button()
        Me.btnF12 = New System.Windows.Forms.Button()
        Me.Panel3D1.SuspendLayout()
        CType(Me._IM_MAE_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_ATO_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_ATO_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_MAE_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WLSMAE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WLSATO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FM_Panel3D2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LST1
        '
        Me.LST1.BackColor = System.Drawing.SystemColors.Window
        Me.LST1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST1.Cursor = System.Windows.Forms.Cursors.Default
        Me.LST1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LST1.ItemHeight = 16
        Me.LST1.Location = New System.Drawing.Point(867, 104)
        Me.LST1.Name = "LST1"
        Me.LST1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LST1.Size = New System.Drawing.Size(93, 290)
        Me.LST1.TabIndex = 18
        Me.LST1.TabStop = False
        '
        '_FM_Panel3D2_7
        '
        Me._FM_Panel3D2_7.Location = New System.Drawing.Point(352, 8)
        Me._FM_Panel3D2_7.Name = "_FM_Panel3D2_7"
        Me._FM_Panel3D2_7.Size = New System.Drawing.Size(86, 25)
        Me._FM_Panel3D2_7.TabIndex = 5
        Me._FM_Panel3D2_7.Text = "*入金区分"
        '
        'KEYBAK
        '
        Me.KEYBAK.BackColor = System.Drawing.SystemColors.Window
        Me.KEYBAK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.KEYBAK.Cursor = System.Windows.Forms.Cursors.Default
        Me.KEYBAK.ForeColor = System.Drawing.SystemColors.WindowText
        Me.KEYBAK.ItemHeight = 16
        Me.KEYBAK.Location = New System.Drawing.Point(864, 104)
        Me.KEYBAK.Name = "KEYBAK"
        Me.KEYBAK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.KEYBAK.Size = New System.Drawing.Size(61, 290)
        Me.KEYBAK.TabIndex = 1
        Me.KEYBAK.Visible = False
        '
        'WLSLABEL
        '
        Me.WLSLABEL.Location = New System.Drawing.Point(3, 80)
        Me.WLSLABEL.Name = "WLSLABEL"
        Me.WLSLABEL.Size = New System.Drawing.Size(845, 25)
        Me.WLSLABEL.TabIndex = 14
        Me.WLSLABEL.Text = "WLSLABEL"
        '
        'LST
        '
        Me.LST.BackColor = System.Drawing.SystemColors.Window
        Me.LST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST.Cursor = System.Windows.Forms.Cursors.Default
        Me.LST.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LST.ItemHeight = 16
        Me.LST.Location = New System.Drawing.Point(3, 104)
        Me.LST.Name = "LST"
        Me.LST.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LST.Size = New System.Drawing.Size(845, 290)
        Me.LST.TabIndex = 15
        '
        'WLSOK
        '
        Me.WLSOK.BackColor = System.Drawing.SystemColors.Control
        Me.WLSOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WLSOK.Location = New System.Drawing.Point(356, 340)
        Me.WLSOK.Name = "WLSOK"
        Me.WLSOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSOK.Size = New System.Drawing.Size(73, 22)
        Me.WLSOK.TabIndex = 16
        Me.WLSOK.Text = "OK"
        Me.WLSOK.UseVisualStyleBackColor = False
        Me.WLSOK.Visible = False
        '
        'WLSCANCEL
        '
        Me.WLSCANCEL.BackColor = System.Drawing.SystemColors.Control
        Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WLSCANCEL.Location = New System.Drawing.Point(428, 340)
        Me.WLSCANCEL.Name = "WLSCANCEL"
        Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSCANCEL.Size = New System.Drawing.Size(73, 22)
        Me.WLSCANCEL.TabIndex = 17
        Me.WLSCANCEL.Text = "ｷｬﾝｾﾙ"
        Me.WLSCANCEL.UseVisualStyleBackColor = False
        Me.WLSCANCEL.Visible = False
        '
        'Panel3D1
        '
        Me.Panel3D1.Controls.Add(Me.WLSNYUCD)
        Me.Panel3D1.Controls.Add(Me.WLSNDNDT)
        Me.Panel3D1.Controls.Add(Me.COM_UDNDT)
        Me.Panel3D1.Controls.Add(Me.COM_TANCD)
        Me.Panel3D1.Controls.Add(Me.WLSTANCD)
        Me.Panel3D1.Controls.Add(Me.WLSTOKCD)
        Me.Panel3D1.Controls.Add(Me.COM_TOKCD)
        Me.Panel3D1.Controls.Add(Me.WLSJDNTRNM)
        Me.Panel3D1.Controls.Add(Me.Label1)
        Me.Panel3D1.Controls.Add(Me.WLSTANNM)
        Me.Panel3D1.Controls.Add(Me.WLSTOKRN)
        Me.Panel3D1.Location = New System.Drawing.Point(0, -1)
        Me.Panel3D1.Name = "Panel3D1"
        Me.Panel3D1.Size = New System.Drawing.Size(855, 72)
        Me.Panel3D1.TabIndex = 0
        '
        'WLSNYUCD
        '
        Me.WLSNYUCD.AcceptsReturn = True
        Me.WLSNYUCD.BackColor = System.Drawing.SystemColors.Window
        Me.WLSNYUCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WLSNYUCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.WLSNYUCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WLSNYUCD.Location = New System.Drawing.Point(436, 8)
        Me.WLSNYUCD.MaxLength = 1
        Me.WLSNYUCD.Name = "WLSNYUCD"
        Me.WLSNYUCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSNYUCD.Size = New System.Drawing.Size(25, 23)
        Me.WLSNYUCD.TabIndex = 6
        Me.WLSNYUCD.Text = "X"
        '
        'WLSNDNDT
        '
        Me.WLSNDNDT.AcceptsReturn = True
        Me.WLSNDNDT.BackColor = System.Drawing.SystemColors.Window
        Me.WLSNDNDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WLSNDNDT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.WLSNDNDT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WLSNDNDT.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.WLSNDNDT.Location = New System.Drawing.Point(104, 40)
        Me.WLSNDNDT.MaxLength = 10
        Me.WLSNDNDT.Name = "WLSNDNDT"
        Me.WLSNDNDT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSNDNDT.Size = New System.Drawing.Size(92, 23)
        Me.WLSNDNDT.TabIndex = 9
        Me.WLSNDNDT.Text = "9999/99/99"
        '
        'COM_UDNDT
        '
        Me.COM_UDNDT.BackColor = System.Drawing.SystemColors.Control
        Me.COM_UDNDT.Cursor = System.Windows.Forms.Cursors.Default
        Me.COM_UDNDT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.COM_UDNDT.Location = New System.Drawing.Point(8, 40)
        Me.COM_UDNDT.Name = "COM_UDNDT"
        Me.COM_UDNDT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.COM_UDNDT.Size = New System.Drawing.Size(97, 25)
        Me.COM_UDNDT.TabIndex = 8
        Me.COM_UDNDT.TabStop = False
        Me.COM_UDNDT.Text = "入金日"
        Me.COM_UDNDT.UseVisualStyleBackColor = False
        '
        'COM_TANCD
        '
        Me.COM_TANCD.BackColor = System.Drawing.SystemColors.Control
        Me.COM_TANCD.Cursor = System.Windows.Forms.Cursors.Default
        Me.COM_TANCD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.COM_TANCD.Location = New System.Drawing.Point(8, 8)
        Me.COM_TANCD.Name = "COM_TANCD"
        Me.COM_TANCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.COM_TANCD.Size = New System.Drawing.Size(97, 25)
        Me.COM_TANCD.TabIndex = 2
        Me.COM_TANCD.TabStop = False
        Me.COM_TANCD.Text = "*入力担当者"
        Me.COM_TANCD.UseVisualStyleBackColor = False
        '
        'WLSTANCD
        '
        Me.WLSTANCD.AcceptsReturn = True
        Me.WLSTANCD.BackColor = System.Drawing.SystemColors.Window
        Me.WLSTANCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WLSTANCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.WLSTANCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WLSTANCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.WLSTANCD.Location = New System.Drawing.Point(104, 8)
        Me.WLSTANCD.MaxLength = 6
        Me.WLSTANCD.Name = "WLSTANCD"
        Me.WLSTANCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSTANCD.Size = New System.Drawing.Size(60, 23)
        Me.WLSTANCD.TabIndex = 3
        Me.WLSTANCD.Text = "XXXXX6"
        '
        'WLSTOKCD
        '
        Me.WLSTOKCD.AcceptsReturn = True
        Me.WLSTOKCD.BackColor = System.Drawing.SystemColors.Window
        Me.WLSTOKCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WLSTOKCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.WLSTOKCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WLSTOKCD.Location = New System.Drawing.Point(436, 40)
        Me.WLSTOKCD.MaxLength = 5
        Me.WLSTOKCD.Name = "WLSTOKCD"
        Me.WLSTOKCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSTOKCD.Size = New System.Drawing.Size(61, 23)
        Me.WLSTOKCD.TabIndex = 12
        Me.WLSTOKCD.Text = "XXXX5"
        '
        'COM_TOKCD
        '
        Me.COM_TOKCD.BackColor = System.Drawing.SystemColors.Control
        Me.COM_TOKCD.Cursor = System.Windows.Forms.Cursors.Default
        Me.COM_TOKCD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.COM_TOKCD.Location = New System.Drawing.Point(352, 40)
        Me.COM_TOKCD.Name = "COM_TOKCD"
        Me.COM_TOKCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.COM_TOKCD.Size = New System.Drawing.Size(86, 25)
        Me.COM_TOKCD.TabIndex = 11
        Me.COM_TOKCD.TabStop = False
        Me.COM_TOKCD.Text = "得意先"
        Me.COM_TOKCD.UseVisualStyleBackColor = False
        '
        'WLSJDNTRNM
        '
        Me.WLSJDNTRNM.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.WLSJDNTRNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WLSJDNTRNM.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSJDNTRNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WLSJDNTRNM.Location = New System.Drawing.Point(458, 8)
        Me.WLSJDNTRNM.Name = "WLSJDNTRNM"
        Me.WLSJDNTRNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSJDNTRNM.Size = New System.Drawing.Size(211, 25)
        Me.WLSJDNTRNM.TabIndex = 7
        Me.WLSJDNTRNM.Text = "１：入金 ２：前受入金"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(203, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(41, 25)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "以降"
        '
        'WLSTANNM
        '
        Me.WLSTANNM.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.WLSTANNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WLSTANNM.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSTANNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WLSTANNM.Location = New System.Drawing.Point(162, 8)
        Me.WLSTANNM.Name = "WLSTANNM"
        Me.WLSTANNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSTANNM.Size = New System.Drawing.Size(178, 25)
        Me.WLSTANNM.TabIndex = 4
        Me.WLSTANNM.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'WLSTOKRN
        '
        Me.WLSTOKRN.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.WLSTOKRN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WLSTOKRN.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSTOKRN.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WLSTOKRN.Location = New System.Drawing.Point(496, 40)
        Me.WLSTOKRN.Name = "WLSTOKRN"
        Me.WLSTOKRN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSTOKRN.Size = New System.Drawing.Size(329, 25)
        Me.WLSTOKRN.TabIndex = 13
        Me.WLSTOKRN.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_IM_MAE_1
        '
        Me._IM_MAE_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_MAE_1.Image = CType(resources.GetObject("_IM_MAE_1.Image"), System.Drawing.Image)
        Me.IM_MAE.SetIndex(Me._IM_MAE_1, CType(1, Short))
        Me._IM_MAE_1.Location = New System.Drawing.Point(363, 462)
        Me._IM_MAE_1.Name = "_IM_MAE_1"
        Me._IM_MAE_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_MAE_1.TabIndex = 19
        Me._IM_MAE_1.TabStop = False
        Me._IM_MAE_1.Visible = False
        '
        '_IM_ATO_1
        '
        Me._IM_ATO_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_ATO_1.Image = CType(resources.GetObject("_IM_ATO_1.Image"), System.Drawing.Image)
        Me.IM_ATO.SetIndex(Me._IM_ATO_1, CType(1, Short))
        Me._IM_ATO_1.Location = New System.Drawing.Point(423, 462)
        Me._IM_ATO_1.Name = "_IM_ATO_1"
        Me._IM_ATO_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_ATO_1.TabIndex = 20
        Me._IM_ATO_1.TabStop = False
        Me._IM_ATO_1.Visible = False
        '
        '_IM_ATO_0
        '
        Me._IM_ATO_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_ATO_0.Image = CType(resources.GetObject("_IM_ATO_0.Image"), System.Drawing.Image)
        Me.IM_ATO.SetIndex(Me._IM_ATO_0, CType(0, Short))
        Me._IM_ATO_0.Location = New System.Drawing.Point(396, 462)
        Me._IM_ATO_0.Name = "_IM_ATO_0"
        Me._IM_ATO_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_ATO_0.TabIndex = 21
        Me._IM_ATO_0.TabStop = False
        Me._IM_ATO_0.Visible = False
        '
        '_IM_MAE_0
        '
        Me._IM_MAE_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_MAE_0.Image = CType(resources.GetObject("_IM_MAE_0.Image"), System.Drawing.Image)
        Me.IM_MAE.SetIndex(Me._IM_MAE_0, CType(0, Short))
        Me._IM_MAE_0.Location = New System.Drawing.Point(336, 462)
        Me._IM_MAE_0.Name = "_IM_MAE_0"
        Me._IM_MAE_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_MAE_0.TabIndex = 22
        Me._IM_MAE_0.TabStop = False
        Me._IM_MAE_0.Visible = False
        '
        'WLSMAE
        '
        Me.WLSMAE.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSMAE.Image = CType(resources.GetObject("WLSMAE.Image"), System.Drawing.Image)
        Me.WLSMAE.Location = New System.Drawing.Point(320, 340)
        Me.WLSMAE.Name = "WLSMAE"
        Me.WLSMAE.Size = New System.Drawing.Size(24, 22)
        Me.WLSMAE.TabIndex = 23
        Me.WLSMAE.TabStop = False
        Me.WLSMAE.Visible = False
        '
        'WLSATO
        '
        Me.WLSATO.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSATO.Image = CType(resources.GetObject("WLSATO.Image"), System.Drawing.Image)
        Me.WLSATO.Location = New System.Drawing.Point(512, 340)
        Me.WLSATO.Name = "WLSATO"
        Me.WLSATO.Size = New System.Drawing.Size(24, 22)
        Me.WLSATO.TabIndex = 24
        Me.WLSATO.TabStop = False
        Me.WLSATO.Visible = False
        '
        'btnF9
        '
        Me.btnF9.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF9.Location = New System.Drawing.Point(684, 400)
        Me.btnF9.Name = "btnF9"
        Me.btnF9.Size = New System.Drawing.Size(75, 39)
        Me.btnF9.TabIndex = 29
        Me.btnF9.Text = "(F9)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "クリア"
        Me.btnF9.UseVisualStyleBackColor = True
        '
        'btnF2
        '
        Me.btnF2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF2.Location = New System.Drawing.Point(93, 400)
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(75, 39)
        Me.btnF2.TabIndex = 26
        Me.btnF2.Text = "(F2)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "検索"
        Me.btnF2.UseVisualStyleBackColor = True
        '
        'btnF1
        '
        Me.btnF1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF1.Location = New System.Drawing.Point(12, 400)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(75, 39)
        Me.btnF1.TabIndex = 25
        Me.btnF1.Text = "(F1)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "確定"
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'btnF8
        '
        Me.btnF8.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF8.Location = New System.Drawing.Point(428, 400)
        Me.btnF8.Name = "btnF8"
        Me.btnF8.Size = New System.Drawing.Size(75, 39)
        Me.btnF8.TabIndex = 28
        Me.btnF8.Text = "(F8)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "次頁"
        Me.btnF8.UseVisualStyleBackColor = True
        '
        'btnF7
        '
        Me.btnF7.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF7.Location = New System.Drawing.Point(349, 400)
        Me.btnF7.Name = "btnF7"
        Me.btnF7.Size = New System.Drawing.Size(75, 39)
        Me.btnF7.TabIndex = 27
        Me.btnF7.Text = "(F7)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "前頁"
        Me.btnF7.UseVisualStyleBackColor = True
        '
        'btnF12
        '
        Me.btnF12.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF12.Location = New System.Drawing.Point(765, 400)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(75, 39)
        Me.btnF12.TabIndex = 30
        Me.btnF12.Text = "(F12)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'WLSNDN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(852, 449)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnF9)
        Me.Controls.Add(Me.btnF2)
        Me.Controls.Add(Me.btnF1)
        Me.Controls.Add(Me.btnF8)
        Me.Controls.Add(Me.btnF7)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.LST1)
        Me.Controls.Add(Me._FM_Panel3D2_7)
        Me.Controls.Add(Me.KEYBAK)
        Me.Controls.Add(Me.WLSLABEL)
        Me.Controls.Add(Me.LST)
        Me.Controls.Add(Me.WLSOK)
        Me.Controls.Add(Me.WLSCANCEL)
        Me.Controls.Add(Me.Panel3D1)
        Me.Controls.Add(Me._IM_MAE_1)
        Me.Controls.Add(Me._IM_ATO_1)
        Me.Controls.Add(Me._IM_ATO_0)
        Me.Controls.Add(Me._IM_MAE_0)
        Me.Controls.Add(Me.WLSMAE)
        Me.Controls.Add(Me.WLSATO)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(9, 103)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WLSNDN"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "入金No一覧ウィンドウ"
        Me.Panel3D1.ResumeLayout(False)
        Me.Panel3D1.PerformLayout()
        CType(Me._IM_MAE_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_ATO_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_ATO_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_MAE_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WLSMAE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WLSATO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FM_Panel3D2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnF9 As Button
    Friend WithEvents btnF2 As Button
    Friend WithEvents btnF1 As Button
    Friend WithEvents btnF8 As Button
    Friend WithEvents btnF7 As Button
    Friend WithEvents btnF12 As Button
#End Region
End Class