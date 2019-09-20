<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class WLSUDN
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
    Public WithEvents KEYBAK As System.Windows.Forms.ListBox
    '2019/06/04 CHG START
    'Public WithEvents WLSLABEL As SSPanel5
    Public WithEvents WLSLABEL As Label
    '2091/06/04 CHG END
    Public WithEvents LST As System.Windows.Forms.ListBox
	Public WithEvents WLSOK As System.Windows.Forms.Button
	Public WithEvents WLSCANCEL As System.Windows.Forms.Button
	Public WithEvents WLSJDNTRKB As System.Windows.Forms.TextBox
	Public WithEvents COM_JDNTRKB As System.Windows.Forms.Button
	Public WithEvents HD_TEXT As System.Windows.Forms.TextBox
	Public WithEvents WLSTANCD As System.Windows.Forms.TextBox
	Public WithEvents COM_TANCD As System.Windows.Forms.Button
	Public WithEvents COM_TOKCD As System.Windows.Forms.Button
	Public WithEvents WLSTOKCD As System.Windows.Forms.TextBox
	Public WithEvents COM_UDNDT As System.Windows.Forms.Button
	Public WithEvents WLSUDNDT As System.Windows.Forms.TextBox
    '2091/06/04 CHG START
    'Public WithEvents _FM_Panel3D2_1 As SSPanel5
    Public WithEvents _FM_Panel3D2_1 As Label
    '2019/06/04 CHG END
    Public WithEvents WLSJDNTRNM As System.Windows.Forms.Label
	Public WithEvents WLSTOKNM As System.Windows.Forms.Label
	Public WithEvents WLSTANNM As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
    '2019/06/04 CHG START
    'Public WithEvents Panel3D1 As SSPanel5
    Public WithEvents Panel3D1 As Label
    '2019/06/04 CHG END
    Public WithEvents Lst1 As System.Windows.Forms.ListBox
	Public WithEvents _IM_MAE_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_ATO_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_ATO_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_MAE_1 As System.Windows.Forms.PictureBox
	Public WithEvents WLSMAE As System.Windows.Forms.PictureBox
	Public WithEvents WLSATO As System.Windows.Forms.PictureBox
    '2019/06/04 CHG START
    'Public WithEvents FM_Panel3D2 As SSPanel5Array
    Public WithEvents FM_Panel3D2 As VB6.LabelArray
    '2019/06/04 CHG END
    Public WithEvents IM_ATO As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_MAE As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WLSUDN))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.KEYBAK = New System.Windows.Forms.ListBox()
        Me.WLSLABEL = New System.Windows.Forms.Label()
        Me.LST = New System.Windows.Forms.ListBox()
        Me.WLSOK = New System.Windows.Forms.Button()
        Me.WLSCANCEL = New System.Windows.Forms.Button()
        Me.Panel3D1 = New System.Windows.Forms.Label()
        Me.WLSJDNTRKB = New System.Windows.Forms.TextBox()
        Me.COM_JDNTRKB = New System.Windows.Forms.Button()
        Me.HD_TEXT = New System.Windows.Forms.TextBox()
        Me.WLSTANCD = New System.Windows.Forms.TextBox()
        Me.COM_TANCD = New System.Windows.Forms.Button()
        Me.COM_TOKCD = New System.Windows.Forms.Button()
        Me.WLSTOKCD = New System.Windows.Forms.TextBox()
        Me.COM_UDNDT = New System.Windows.Forms.Button()
        Me.WLSUDNDT = New System.Windows.Forms.TextBox()
        Me._FM_Panel3D2_1 = New System.Windows.Forms.Label()
        Me.WLSJDNTRNM = New System.Windows.Forms.Label()
        Me.WLSTOKNM = New System.Windows.Forms.Label()
        Me.WLSTANNM = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lst1 = New System.Windows.Forms.ListBox()
        Me._IM_MAE_0 = New System.Windows.Forms.PictureBox()
        Me._IM_ATO_0 = New System.Windows.Forms.PictureBox()
        Me._IM_ATO_1 = New System.Windows.Forms.PictureBox()
        Me._IM_MAE_1 = New System.Windows.Forms.PictureBox()
        Me.WLSMAE = New System.Windows.Forms.PictureBox()
        Me.WLSATO = New System.Windows.Forms.PictureBox()
        Me.FM_Panel3D2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.IM_ATO = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_MAE = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.btnF2 = New System.Windows.Forms.Button()
        Me.btnF1 = New System.Windows.Forms.Button()
        Me.btnF8 = New System.Windows.Forms.Button()
        Me.btnF7 = New System.Windows.Forms.Button()
        Me.btnF9 = New System.Windows.Forms.Button()
        Me.btnF12 = New System.Windows.Forms.Button()
        Me.Panel3D1.SuspendLayout()
        CType(Me._IM_MAE_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_ATO_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_ATO_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_MAE_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WLSMAE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WLSATO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FM_Panel3D2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KEYBAK
        '
        Me.KEYBAK.BackColor = System.Drawing.SystemColors.Window
        Me.KEYBAK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.KEYBAK.Cursor = System.Windows.Forms.Cursors.Default
        Me.KEYBAK.ForeColor = System.Drawing.SystemColors.WindowText
        Me.KEYBAK.ItemHeight = 16
        Me.KEYBAK.Location = New System.Drawing.Point(1024, 96)
        Me.KEYBAK.Name = "KEYBAK"
        Me.KEYBAK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.KEYBAK.Size = New System.Drawing.Size(93, 338)
        Me.KEYBAK.TabIndex = 19
        Me.KEYBAK.Visible = False
        '
        'WLSLABEL
        '
        Me.WLSLABEL.Location = New System.Drawing.Point(3, 96)
        Me.WLSLABEL.Name = "WLSLABEL"
        Me.WLSLABEL.Size = New System.Drawing.Size(1002, 25)
        Me.WLSLABEL.TabIndex = 9
        Me.WLSLABEL.Text = "WLSLABEL"
        '
        'LST
        '
        Me.LST.BackColor = System.Drawing.SystemColors.Window
        Me.LST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST.Cursor = System.Windows.Forms.Cursors.Default
        Me.LST.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LST.ItemHeight = 16
        Me.LST.Location = New System.Drawing.Point(3, 120)
        Me.LST.Name = "LST"
        Me.LST.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LST.Size = New System.Drawing.Size(1002, 306)
        Me.LST.TabIndex = 0
        '
        'WLSOK
        '
        Me.WLSOK.BackColor = System.Drawing.SystemColors.Control
        Me.WLSOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WLSOK.Location = New System.Drawing.Point(396, 382)
        Me.WLSOK.Name = "WLSOK"
        Me.WLSOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSOK.Size = New System.Drawing.Size(61, 22)
        Me.WLSOK.TabIndex = 6
        Me.WLSOK.Text = "OK"
        Me.WLSOK.UseVisualStyleBackColor = False
        Me.WLSOK.Visible = False
        '
        'WLSCANCEL
        '
        Me.WLSCANCEL.BackColor = System.Drawing.SystemColors.Control
        Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WLSCANCEL.Location = New System.Drawing.Point(459, 382)
        Me.WLSCANCEL.Name = "WLSCANCEL"
        Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSCANCEL.Size = New System.Drawing.Size(61, 22)
        Me.WLSCANCEL.TabIndex = 7
        Me.WLSCANCEL.Text = "ｷｬﾝｾﾙ"
        Me.WLSCANCEL.UseVisualStyleBackColor = False
        Me.WLSCANCEL.Visible = False
        '
        'Panel3D1
        '
        Me.Panel3D1.Controls.Add(Me.WLSJDNTRKB)
        Me.Panel3D1.Controls.Add(Me.COM_JDNTRKB)
        Me.Panel3D1.Controls.Add(Me.HD_TEXT)
        Me.Panel3D1.Controls.Add(Me.WLSTANCD)
        Me.Panel3D1.Controls.Add(Me.COM_TANCD)
        Me.Panel3D1.Controls.Add(Me.COM_TOKCD)
        Me.Panel3D1.Controls.Add(Me.WLSTOKCD)
        Me.Panel3D1.Controls.Add(Me.COM_UDNDT)
        Me.Panel3D1.Controls.Add(Me.WLSUDNDT)
        Me.Panel3D1.Controls.Add(Me._FM_Panel3D2_1)
        Me.Panel3D1.Controls.Add(Me.WLSJDNTRNM)
        Me.Panel3D1.Controls.Add(Me.WLSTOKNM)
        Me.Panel3D1.Controls.Add(Me.WLSTANNM)
        Me.Panel3D1.Controls.Add(Me.Label1)
        Me.Panel3D1.Location = New System.Drawing.Point(0, 0)
        Me.Panel3D1.Name = "Panel3D1"
        Me.Panel3D1.Size = New System.Drawing.Size(1013, 77)
        Me.Panel3D1.TabIndex = 8
        '
        'WLSJDNTRKB
        '
        Me.WLSJDNTRKB.AcceptsReturn = True
        Me.WLSJDNTRKB.BackColor = System.Drawing.SystemColors.Window
        Me.WLSJDNTRKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WLSJDNTRKB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.WLSJDNTRKB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WLSJDNTRKB.Location = New System.Drawing.Point(646, 8)
        Me.WLSJDNTRKB.MaxLength = 2
        Me.WLSJDNTRKB.Name = "WLSJDNTRKB"
        Me.WLSJDNTRKB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSJDNTRKB.Size = New System.Drawing.Size(29, 23)
        Me.WLSJDNTRKB.TabIndex = 3
        '
        'COM_JDNTRKB
        '
        Me.COM_JDNTRKB.BackColor = System.Drawing.SystemColors.Control
        Me.COM_JDNTRKB.Cursor = System.Windows.Forms.Cursors.Default
        Me.COM_JDNTRKB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.COM_JDNTRKB.Location = New System.Drawing.Point(560, 8)
        Me.COM_JDNTRKB.Name = "COM_JDNTRKB"
        Me.COM_JDNTRKB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.COM_JDNTRKB.Size = New System.Drawing.Size(88, 25)
        Me.COM_JDNTRKB.TabIndex = 17
        Me.COM_JDNTRKB.TabStop = False
        Me.COM_JDNTRKB.Text = "受注取区"
        Me.COM_JDNTRKB.UseVisualStyleBackColor = False
        '
        'HD_TEXT
        '
        Me.HD_TEXT.AcceptsReturn = True
        Me.HD_TEXT.BackColor = System.Drawing.SystemColors.Window
        Me.HD_TEXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TEXT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TEXT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TEXT.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_TEXT.Location = New System.Drawing.Point(456, 8)
        Me.HD_TEXT.MaxLength = 6
        Me.HD_TEXT.Name = "HD_TEXT"
        Me.HD_TEXT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TEXT.Size = New System.Drawing.Size(84, 23)
        Me.HD_TEXT.TabIndex = 2
        '
        'WLSTANCD
        '
        Me.WLSTANCD.AcceptsReturn = True
        Me.WLSTANCD.BackColor = System.Drawing.SystemColors.Window
        Me.WLSTANCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WLSTANCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.WLSTANCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WLSTANCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.WLSTANCD.Location = New System.Drawing.Point(102, 8)
        Me.WLSTANCD.MaxLength = 6
        Me.WLSTANCD.Name = "WLSTANCD"
        Me.WLSTANCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSTANCD.Size = New System.Drawing.Size(52, 23)
        Me.WLSTANCD.TabIndex = 1
        '
        'COM_TANCD
        '
        Me.COM_TANCD.BackColor = System.Drawing.SystemColors.Control
        Me.COM_TANCD.Cursor = System.Windows.Forms.Cursors.Default
        Me.COM_TANCD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.COM_TANCD.Location = New System.Drawing.Point(6, 8)
        Me.COM_TANCD.Name = "COM_TANCD"
        Me.COM_TANCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.COM_TANCD.Size = New System.Drawing.Size(97, 25)
        Me.COM_TANCD.TabIndex = 13
        Me.COM_TANCD.Text = "営業担当者"
        Me.COM_TANCD.UseVisualStyleBackColor = False
        '
        'COM_TOKCD
        '
        Me.COM_TOKCD.BackColor = System.Drawing.SystemColors.Control
        Me.COM_TOKCD.Cursor = System.Windows.Forms.Cursors.Default
        Me.COM_TOKCD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.COM_TOKCD.Location = New System.Drawing.Point(352, 40)
        Me.COM_TOKCD.Name = "COM_TOKCD"
        Me.COM_TOKCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.COM_TOKCD.Size = New System.Drawing.Size(105, 25)
        Me.COM_TOKCD.TabIndex = 12
        Me.COM_TOKCD.Text = "得意先      "
        Me.COM_TOKCD.UseVisualStyleBackColor = False
        '
        'WLSTOKCD
        '
        Me.WLSTOKCD.AcceptsReturn = True
        Me.WLSTOKCD.BackColor = System.Drawing.SystemColors.Window
        Me.WLSTOKCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WLSTOKCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.WLSTOKCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WLSTOKCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.WLSTOKCD.Location = New System.Drawing.Point(456, 40)
        Me.WLSTOKCD.MaxLength = 10
        Me.WLSTOKCD.Name = "WLSTOKCD"
        Me.WLSTOKCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSTOKCD.Size = New System.Drawing.Size(84, 23)
        Me.WLSTOKCD.TabIndex = 5
        '
        'COM_UDNDT
        '
        Me.COM_UDNDT.BackColor = System.Drawing.SystemColors.Control
        Me.COM_UDNDT.Cursor = System.Windows.Forms.Cursors.Default
        Me.COM_UDNDT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.COM_UDNDT.Location = New System.Drawing.Point(6, 40)
        Me.COM_UDNDT.Name = "COM_UDNDT"
        Me.COM_UDNDT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.COM_UDNDT.Size = New System.Drawing.Size(97, 25)
        Me.COM_UDNDT.TabIndex = 10
        Me.COM_UDNDT.Text = "売上日    "
        Me.COM_UDNDT.UseVisualStyleBackColor = False
        '
        'WLSUDNDT
        '
        Me.WLSUDNDT.AcceptsReturn = True
        Me.WLSUDNDT.BackColor = System.Drawing.SystemColors.Window
        Me.WLSUDNDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WLSUDNDT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.WLSUDNDT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WLSUDNDT.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.WLSUDNDT.Location = New System.Drawing.Point(102, 40)
        Me.WLSUDNDT.MaxLength = 10
        Me.WLSUDNDT.Name = "WLSUDNDT"
        Me.WLSUDNDT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSUDNDT.Size = New System.Drawing.Size(84, 23)
        Me.WLSUDNDT.TabIndex = 4
        '
        '_FM_Panel3D2_1
        '
        Me.FM_Panel3D2.SetIndex(Me._FM_Panel3D2_1, CType(1, Short))
        Me._FM_Panel3D2_1.Location = New System.Drawing.Point(352, 8)
        Me._FM_Panel3D2_1.Name = "_FM_Panel3D2_1"
        Me._FM_Panel3D2_1.Size = New System.Drawing.Size(105, 25)
        Me._FM_Panel3D2_1.TabIndex = 14
        Me._FM_Panel3D2_1.Text = "開始受注番号"
        '
        'WLSJDNTRNM
        '
        Me.WLSJDNTRNM.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.WLSJDNTRNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WLSJDNTRNM.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSJDNTRNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WLSJDNTRNM.Location = New System.Drawing.Point(674, 8)
        Me.WLSJDNTRNM.Name = "WLSJDNTRNM"
        Me.WLSJDNTRNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSJDNTRNM.Size = New System.Drawing.Size(115, 25)
        Me.WLSJDNTRNM.TabIndex = 18
        Me.WLSJDNTRNM.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'WLSTOKNM
        '
        Me.WLSTOKNM.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.WLSTOKNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WLSTOKNM.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSTOKNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WLSTOKNM.Location = New System.Drawing.Point(540, 40)
        Me.WLSTOKNM.Name = "WLSTOKNM"
        Me.WLSTOKNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSTOKNM.Size = New System.Drawing.Size(379, 25)
        Me.WLSTOKNM.TabIndex = 16
        Me.WLSTOKNM.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'WLSTANNM
        '
        Me.WLSTANNM.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.WLSTANNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WLSTANNM.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSTANNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WLSTANNM.Location = New System.Drawing.Point(152, 8)
        Me.WLSTANNM.Name = "WLSTANNM"
        Me.WLSTANNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSTANNM.Size = New System.Drawing.Size(187, 25)
        Me.WLSTANNM.TabIndex = 15
        Me.WLSTANNM.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(192, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(41, 25)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "以降"
        '
        'Lst1
        '
        Me.Lst1.BackColor = System.Drawing.SystemColors.Window
        Me.Lst1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lst1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Lst1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Lst1.ItemHeight = 16
        Me.Lst1.Location = New System.Drawing.Point(968, 120)
        Me.Lst1.Name = "Lst1"
        Me.Lst1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Lst1.Size = New System.Drawing.Size(41, 306)
        Me.Lst1.TabIndex = 20
        Me.Lst1.Visible = False
        '
        '_IM_MAE_0
        '
        Me._IM_MAE_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_MAE_0.Image = CType(resources.GetObject("_IM_MAE_0.Image"), System.Drawing.Image)
        Me.IM_MAE.SetIndex(Me._IM_MAE_0, CType(0, Short))
        Me._IM_MAE_0.Location = New System.Drawing.Point(399, 528)
        Me._IM_MAE_0.Name = "_IM_MAE_0"
        Me._IM_MAE_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_MAE_0.TabIndex = 21
        Me._IM_MAE_0.TabStop = False
        Me._IM_MAE_0.Visible = False
        '
        '_IM_ATO_0
        '
        Me._IM_ATO_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_ATO_0.Image = CType(resources.GetObject("_IM_ATO_0.Image"), System.Drawing.Image)
        Me.IM_ATO.SetIndex(Me._IM_ATO_0, CType(0, Short))
        Me._IM_ATO_0.Location = New System.Drawing.Point(459, 528)
        Me._IM_ATO_0.Name = "_IM_ATO_0"
        Me._IM_ATO_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_ATO_0.TabIndex = 22
        Me._IM_ATO_0.TabStop = False
        Me._IM_ATO_0.Visible = False
        '
        '_IM_ATO_1
        '
        Me._IM_ATO_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_ATO_1.Image = CType(resources.GetObject("_IM_ATO_1.Image"), System.Drawing.Image)
        Me.IM_ATO.SetIndex(Me._IM_ATO_1, CType(1, Short))
        Me._IM_ATO_1.Location = New System.Drawing.Point(486, 528)
        Me._IM_ATO_1.Name = "_IM_ATO_1"
        Me._IM_ATO_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_ATO_1.TabIndex = 23
        Me._IM_ATO_1.TabStop = False
        Me._IM_ATO_1.Visible = False
        '
        '_IM_MAE_1
        '
        Me._IM_MAE_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_MAE_1.Image = CType(resources.GetObject("_IM_MAE_1.Image"), System.Drawing.Image)
        Me.IM_MAE.SetIndex(Me._IM_MAE_1, CType(1, Short))
        Me._IM_MAE_1.Location = New System.Drawing.Point(426, 528)
        Me._IM_MAE_1.Name = "_IM_MAE_1"
        Me._IM_MAE_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_MAE_1.TabIndex = 24
        Me._IM_MAE_1.TabStop = False
        Me._IM_MAE_1.Visible = False
        '
        'WLSMAE
        '
        Me.WLSMAE.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSMAE.Image = CType(resources.GetObject("WLSMAE.Image"), System.Drawing.Image)
        Me.WLSMAE.Location = New System.Drawing.Point(363, 382)
        Me.WLSMAE.Name = "WLSMAE"
        Me.WLSMAE.Size = New System.Drawing.Size(24, 22)
        Me.WLSMAE.TabIndex = 25
        Me.WLSMAE.TabStop = False
        Me.WLSMAE.Visible = False
        '
        'WLSATO
        '
        Me.WLSATO.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSATO.Image = CType(resources.GetObject("WLSATO.Image"), System.Drawing.Image)
        Me.WLSATO.Location = New System.Drawing.Point(528, 382)
        Me.WLSATO.Name = "WLSATO"
        Me.WLSATO.Size = New System.Drawing.Size(24, 22)
        Me.WLSATO.TabIndex = 26
        Me.WLSATO.TabStop = False
        Me.WLSATO.Visible = False
        '
        'btnF2
        '
        Me.btnF2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF2.Location = New System.Drawing.Point(93, 441)
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(75, 39)
        Me.btnF2.TabIndex = 33
        Me.btnF2.Text = "(F2)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "検索"
        Me.btnF2.UseVisualStyleBackColor = True
        '
        'btnF1
        '
        Me.btnF1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF1.Location = New System.Drawing.Point(12, 441)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(75, 39)
        Me.btnF1.TabIndex = 32
        Me.btnF1.Text = "(F1)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "確定"
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'btnF8
        '
        Me.btnF8.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF8.Location = New System.Drawing.Point(481, 441)
        Me.btnF8.Name = "btnF8"
        Me.btnF8.Size = New System.Drawing.Size(75, 39)
        Me.btnF8.TabIndex = 35
        Me.btnF8.Text = "(F8)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "次頁"
        Me.btnF8.UseVisualStyleBackColor = True
        '
        'btnF7
        '
        Me.btnF7.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF7.Location = New System.Drawing.Point(401, 441)
        Me.btnF7.Name = "btnF7"
        Me.btnF7.Size = New System.Drawing.Size(75, 39)
        Me.btnF7.TabIndex = 34
        Me.btnF7.Text = "(F7)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "前頁"
        Me.btnF7.UseVisualStyleBackColor = True
        '
        'btnF9
        '
        Me.btnF9.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF9.Location = New System.Drawing.Point(789, 441)
        Me.btnF9.Name = "btnF9"
        Me.btnF9.Size = New System.Drawing.Size(75, 39)
        Me.btnF9.TabIndex = 36
        Me.btnF9.Text = "(F9)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "クリア"
        Me.btnF9.UseVisualStyleBackColor = True
        '
        'btnF12
        '
        Me.btnF12.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF12.Location = New System.Drawing.Point(870, 441)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(75, 39)
        Me.btnF12.TabIndex = 37
        Me.btnF12.Text = "(F12)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'WLSUDN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(957, 492)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnF9)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.btnF2)
        Me.Controls.Add(Me.btnF1)
        Me.Controls.Add(Me.btnF8)
        Me.Controls.Add(Me.btnF7)
        Me.Controls.Add(Me.KEYBAK)
        Me.Controls.Add(Me.WLSLABEL)
        Me.Controls.Add(Me.LST)
        Me.Controls.Add(Me.WLSOK)
        Me.Controls.Add(Me.WLSCANCEL)
        Me.Controls.Add(Me.Panel3D1)
        Me.Controls.Add(Me.Lst1)
        Me.Controls.Add(Me._IM_MAE_0)
        Me.Controls.Add(Me._IM_ATO_0)
        Me.Controls.Add(Me._IM_ATO_1)
        Me.Controls.Add(Me._IM_MAE_1)
        Me.Controls.Add(Me.WLSMAE)
        Me.Controls.Add(Me.WLSATO)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(184, 158)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WLSUDN"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "売上伝票検索"
        Me.Panel3D1.ResumeLayout(False)
        Me.Panel3D1.PerformLayout()
        CType(Me._IM_MAE_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_ATO_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_ATO_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_MAE_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WLSMAE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WLSATO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FM_Panel3D2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnF2 As Button
    Friend WithEvents btnF1 As Button
    Friend WithEvents btnF8 As Button
    Friend WithEvents btnF7 As Button
    Friend WithEvents btnF9 As Button
    Friend WithEvents btnF12 As Button
#End Region
End Class