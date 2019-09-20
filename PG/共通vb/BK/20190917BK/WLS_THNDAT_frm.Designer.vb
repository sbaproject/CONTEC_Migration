<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class WLS_THNDAT
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
	Public WithEvents TX_CursorRest As System.Windows.Forms.TextBox
	Public WithEvents HD_ODNYTDT_ST As System.Windows.Forms.TextBox
	Public WithEvents HD_TOKJDNNO As System.Windows.Forms.TextBox
    Public WithEvents HD_STS As System.Windows.Forms.TextBox
    Public WithEvents CS_ODNYTDT_ST As Button
    Public WithEvents HD_HINCD As System.Windows.Forms.TextBox
    Public WithEvents HD_ODNYTDT_ED As System.Windows.Forms.TextBox
    Public WithEvents HD_KSHNM As System.Windows.Forms.TextBox
    Public WithEvents HD_TOKCD As System.Windows.Forms.TextBox
    Public WithEvents CS_TOKCD As Button
    Public WithEvents CS_ODNYTDT_ED As Button
    Public WithEvents _FM_Panel3D1_0 As Label
    Public WithEvents _FM_Panel3D1_2 As Label
    Public WithEvents _FM_Panel3D1_3 As Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Panel3D1 As System.Windows.Forms.Panel
    Public WithEvents _FM_Panel3D1_1 As Label
    Public WithEvents LST As System.Windows.Forms.ListBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents _IM_PrevCm_0 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_NextCm_0 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_NextCm_1 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_PrevCm_1 As System.Windows.Forms.PictureBox
    Public WithEvents FM_Panel3D1 As VB6.PanelArray
    Public WithEvents IM_NextCm As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_PrevCm As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WLS_THNDAT))
        Me.WLSOK = New System.Windows.Forms.Button()
        Me.WLSCANCEL = New System.Windows.Forms.Button()
        Me.CM_PrevCm = New System.Windows.Forms.PictureBox()
        Me.CM_NextCm = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TX_CursorRest = New System.Windows.Forms.TextBox()
        Me.HD_ODNYTDT_ST = New System.Windows.Forms.TextBox()
        Me.HD_TOKJDNNO = New System.Windows.Forms.TextBox()
        Me.Panel3D1 = New System.Windows.Forms.Panel()
        Me.HD_STS = New System.Windows.Forms.TextBox()
        Me.CS_ODNYTDT_ST = New System.Windows.Forms.Button()
        Me.HD_HINCD = New System.Windows.Forms.TextBox()
        Me.HD_ODNYTDT_ED = New System.Windows.Forms.TextBox()
        Me.HD_KSHNM = New System.Windows.Forms.TextBox()
        Me.HD_TOKCD = New System.Windows.Forms.TextBox()
        Me.CS_TOKCD = New System.Windows.Forms.Button()
        Me.CS_ODNYTDT_ED = New System.Windows.Forms.Button()
        Me._FM_Panel3D1_0 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_2 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_1 = New System.Windows.Forms.Label()
        Me.LST = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me._IM_PrevCm_0 = New System.Windows.Forms.PictureBox()
        Me._IM_NextCm_0 = New System.Windows.Forms.PictureBox()
        Me._IM_NextCm_1 = New System.Windows.Forms.PictureBox()
        Me._IM_PrevCm_1 = New System.Windows.Forms.PictureBox()
        Me.FM_Panel3D1 = New Microsoft.VisualBasic.Compatibility.VB6.PanelArray(Me.components)
        Me.IM_NextCm = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_PrevCm = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.btnF9 = New System.Windows.Forms.Button()
        Me.btnF2 = New System.Windows.Forms.Button()
        Me.btnF1 = New System.Windows.Forms.Button()
        Me.btnF8 = New System.Windows.Forms.Button()
        Me.btnF7 = New System.Windows.Forms.Button()
        Me.btnF12 = New System.Windows.Forms.Button()
        CType(Me.CM_PrevCm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_NextCm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3D1.SuspendLayout()
        CType(Me._IM_PrevCm_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_NextCm_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_NextCm_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_PrevCm_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_NextCm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_PrevCm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WLSOK
        '
        Me.WLSOK.BackColor = System.Drawing.SystemColors.Control
        Me.WLSOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSOK.Enabled = False
        Me.WLSOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WLSOK.Location = New System.Drawing.Point(950, 283)
        Me.WLSOK.Name = "WLSOK"
        Me.WLSOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSOK.Size = New System.Drawing.Size(61, 22)
        Me.WLSOK.TabIndex = 18
        Me.WLSOK.Text = "OK"
        Me.WLSOK.UseVisualStyleBackColor = False
        Me.WLSOK.Visible = False
        '
        'WLSCANCEL
        '
        Me.WLSCANCEL.BackColor = System.Drawing.SystemColors.Control
        Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSCANCEL.Enabled = False
        Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WLSCANCEL.Location = New System.Drawing.Point(1013, 283)
        Me.WLSCANCEL.Name = "WLSCANCEL"
        Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSCANCEL.Size = New System.Drawing.Size(61, 22)
        Me.WLSCANCEL.TabIndex = 19
        Me.WLSCANCEL.Text = "ｷｬﾝｾﾙ"
        Me.WLSCANCEL.UseVisualStyleBackColor = False
        Me.WLSCANCEL.Visible = False
        '
        'CM_PrevCm
        '
        Me.CM_PrevCm.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_PrevCm.Enabled = False
        Me.CM_PrevCm.Image = CType(resources.GetObject("CM_PrevCm.Image"), System.Drawing.Image)
        Me.CM_PrevCm.Location = New System.Drawing.Point(918, 283)
        Me.CM_PrevCm.Name = "CM_PrevCm"
        Me.CM_PrevCm.Size = New System.Drawing.Size(24, 22)
        Me.CM_PrevCm.TabIndex = 26
        Me.CM_PrevCm.TabStop = False
        Me.CM_PrevCm.Visible = False
        '
        'CM_NextCm
        '
        Me.CM_NextCm.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_NextCm.Enabled = False
        Me.CM_NextCm.Image = CType(resources.GetObject("CM_NextCm.Image"), System.Drawing.Image)
        Me.CM_NextCm.Location = New System.Drawing.Point(1083, 283)
        Me.CM_NextCm.Name = "CM_NextCm"
        Me.CM_NextCm.Size = New System.Drawing.Size(24, 22)
        Me.CM_NextCm.TabIndex = 27
        Me.CM_NextCm.TabStop = False
        Me.CM_NextCm.Visible = False
        '
        'TX_CursorRest
        '
        Me.TX_CursorRest.AcceptsReturn = True
        Me.TX_CursorRest.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TX_CursorRest.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TX_CursorRest.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TX_CursorRest.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TX_CursorRest.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TX_CursorRest.Location = New System.Drawing.Point(20, 327)
        Me.TX_CursorRest.MaxLength = 0
        Me.TX_CursorRest.Name = "TX_CursorRest"
        Me.TX_CursorRest.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_CursorRest.Size = New System.Drawing.Size(22, 16)
        Me.TX_CursorRest.TabIndex = 21
        Me.TX_CursorRest.TabStop = False
        '
        'HD_ODNYTDT_ST
        '
        Me.HD_ODNYTDT_ST.AcceptsReturn = True
        Me.HD_ODNYTDT_ST.BackColor = System.Drawing.SystemColors.Window
        Me.HD_ODNYTDT_ST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_ODNYTDT_ST.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_ODNYTDT_ST.Font = New System.Drawing.Font("MS Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_ODNYTDT_ST.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_ODNYTDT_ST.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_ODNYTDT_ST.Location = New System.Drawing.Point(509, 7)
        Me.HD_ODNYTDT_ST.MaxLength = 10
        Me.HD_ODNYTDT_ST.Name = "HD_ODNYTDT_ST"
        Me.HD_ODNYTDT_ST.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_ODNYTDT_ST.Size = New System.Drawing.Size(83, 20)
        Me.HD_ODNYTDT_ST.TabIndex = 5
        Me.HD_ODNYTDT_ST.Text = "9999/99/99"
        '
        'HD_TOKJDNNO
        '
        Me.HD_TOKJDNNO.AcceptsReturn = True
        Me.HD_TOKJDNNO.BackColor = System.Drawing.SystemColors.Window
        Me.HD_TOKJDNNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TOKJDNNO.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TOKJDNNO.Font = New System.Drawing.Font("MS Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_TOKJDNNO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TOKJDNNO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_TOKJDNNO.Location = New System.Drawing.Point(682, 40)
        Me.HD_TOKJDNNO.MaxLength = 23
        Me.HD_TOKJDNNO.Name = "HD_TOKJDNNO"
        Me.HD_TOKJDNNO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TOKJDNNO.Size = New System.Drawing.Size(187, 20)
        Me.HD_TOKJDNNO.TabIndex = 15
        Me.HD_TOKJDNNO.Text = "XXXXXXXXX1XXXXXXXXX2XXX"
        '
        'Panel3D1
        '
        Me.Panel3D1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel3D1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3D1.Controls.Add(Me.HD_STS)
        Me.Panel3D1.Controls.Add(Me.CS_ODNYTDT_ST)
        Me.Panel3D1.Controls.Add(Me.HD_HINCD)
        Me.Panel3D1.Controls.Add(Me.HD_ODNYTDT_ED)
        Me.Panel3D1.Controls.Add(Me.HD_KSHNM)
        Me.Panel3D1.Controls.Add(Me.HD_TOKCD)
        Me.Panel3D1.Controls.Add(Me.CS_TOKCD)
        Me.Panel3D1.Controls.Add(Me.CS_ODNYTDT_ED)
        Me.Panel3D1.Controls.Add(Me._FM_Panel3D1_0)
        Me.Panel3D1.Controls.Add(Me._FM_Panel3D1_2)
        Me.Panel3D1.Controls.Add(Me._FM_Panel3D1_3)
        Me.Panel3D1.Controls.Add(Me.Label2)
        Me.Panel3D1.Controls.Add(Me.Label3)
        Me.Panel3D1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panel3D1.ForeColor = System.Drawing.Color.Black
        Me.Panel3D1.Location = New System.Drawing.Point(-3, -1)
        Me.Panel3D1.Name = "Panel3D1"
        Me.Panel3D1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Panel3D1.Size = New System.Drawing.Size(896, 80)
        Me.Panel3D1.TabIndex = 0
        '
        'HD_STS
        '
        Me.HD_STS.AcceptsReturn = True
        Me.HD_STS.BackColor = System.Drawing.SystemColors.Window
        Me.HD_STS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_STS.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_STS.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_STS.Location = New System.Drawing.Point(100, 6)
        Me.HD_STS.MaxLength = 1
        Me.HD_STS.Name = "HD_STS"
        Me.HD_STS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_STS.Size = New System.Drawing.Size(17, 23)
        Me.HD_STS.TabIndex = 2
        Me.HD_STS.Text = "X"
        '
        'CS_ODNYTDT_ST
        '
        Me.CS_ODNYTDT_ST.Location = New System.Drawing.Point(376, 3)
        Me.CS_ODNYTDT_ST.Name = "CS_ODNYTDT_ST"
        Me.CS_ODNYTDT_ST.Size = New System.Drawing.Size(134, 25)
        Me.CS_ODNYTDT_ST.TabIndex = 4
        Me.CS_ODNYTDT_ST.TabStop = False
        Me.CS_ODNYTDT_ST.Text = "出荷予定日(開始)"
        '
        'HD_HINCD
        '
        Me.HD_HINCD.AcceptsReturn = True
        Me.HD_HINCD.BackColor = System.Drawing.SystemColors.Window
        Me.HD_HINCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_HINCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_HINCD.Font = New System.Drawing.Font("MS Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_HINCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_HINCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_HINCD.Location = New System.Drawing.Point(475, 40)
        Me.HD_HINCD.MaxLength = 10
        Me.HD_HINCD.Name = "HD_HINCD"
        Me.HD_HINCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_HINCD.Size = New System.Drawing.Size(87, 20)
        Me.HD_HINCD.TabIndex = 13
        Me.HD_HINCD.Text = "XXXXXXX8"
        '
        'HD_ODNYTDT_ED
        '
        Me.HD_ODNYTDT_ED.AcceptsReturn = True
        Me.HD_ODNYTDT_ED.BackColor = System.Drawing.SystemColors.Window
        Me.HD_ODNYTDT_ED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_ODNYTDT_ED.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_ODNYTDT_ED.Font = New System.Drawing.Font("MS Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_ODNYTDT_ED.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_ODNYTDT_ED.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_ODNYTDT_ED.Location = New System.Drawing.Point(751, 6)
        Me.HD_ODNYTDT_ED.MaxLength = 10
        Me.HD_ODNYTDT_ED.Name = "HD_ODNYTDT_ED"
        Me.HD_ODNYTDT_ED.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_ODNYTDT_ED.Size = New System.Drawing.Size(83, 20)
        Me.HD_ODNYTDT_ED.TabIndex = 8
        Me.HD_ODNYTDT_ED.Text = "9999/99/99"
        '
        'HD_KSHNM
        '
        Me.HD_KSHNM.AcceptsReturn = True
        Me.HD_KSHNM.BackColor = System.Drawing.SystemColors.Control
        Me.HD_KSHNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_KSHNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_KSHNM.Font = New System.Drawing.Font("MS Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_KSHNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_KSHNM.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_KSHNM.Location = New System.Drawing.Point(160, 40)
        Me.HD_KSHNM.MaxLength = 40
        Me.HD_KSHNM.Name = "HD_KSHNM"
        Me.HD_KSHNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_KSHNM.Size = New System.Drawing.Size(200, 20)
        Me.HD_KSHNM.TabIndex = 11
        Me.HD_KSHNM.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'HD_TOKCD
        '
        Me.HD_TOKCD.AcceptsReturn = True
        Me.HD_TOKCD.BackColor = System.Drawing.SystemColors.Window
        Me.HD_TOKCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TOKCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TOKCD.Font = New System.Drawing.Font("MS Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_TOKCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TOKCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_TOKCD.Location = New System.Drawing.Point(99, 40)
        Me.HD_TOKCD.MaxLength = 13
        Me.HD_TOKCD.Name = "HD_TOKCD"
        Me.HD_TOKCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TOKCD.Size = New System.Drawing.Size(63, 20)
        Me.HD_TOKCD.TabIndex = 10
        Me.HD_TOKCD.Text = "XXXX5"
        '
        'CS_TOKCD
        '
        Me.CS_TOKCD.Location = New System.Drawing.Point(5, 37)
        Me.CS_TOKCD.Name = "CS_TOKCD"
        Me.CS_TOKCD.Size = New System.Drawing.Size(95, 25)
        Me.CS_TOKCD.TabIndex = 9
        Me.CS_TOKCD.TabStop = False
        Me.CS_TOKCD.Text = "決済方法"
        '
        'CS_ODNYTDT_ED
        '
        Me.CS_ODNYTDT_ED.Location = New System.Drawing.Point(618, 3)
        Me.CS_ODNYTDT_ED.Name = "CS_ODNYTDT_ED"
        Me.CS_ODNYTDT_ED.Size = New System.Drawing.Size(134, 25)
        Me.CS_ODNYTDT_ED.TabIndex = 7
        Me.CS_ODNYTDT_ED.TabStop = False
        Me.CS_ODNYTDT_ED.Text = "出荷予定日(終了)"
        '
        '_FM_Panel3D1_0
        '
        Me._FM_Panel3D1_0.Location = New System.Drawing.Point(376, 40)
        Me._FM_Panel3D1_0.Name = "_FM_Panel3D1_0"
        Me._FM_Panel3D1_0.Size = New System.Drawing.Size(99, 25)
        Me._FM_Panel3D1_0.TabIndex = 12
        Me._FM_Panel3D1_0.Text = " 製品コード"
        '
        '_FM_Panel3D1_2
        '
        Me._FM_Panel3D1_2.Location = New System.Drawing.Point(568, 40)
        Me._FM_Panel3D1_2.Name = "_FM_Panel3D1_2"
        Me._FM_Panel3D1_2.Size = New System.Drawing.Size(116, 25)
        Me._FM_Panel3D1_2.TabIndex = 14
        Me._FM_Panel3D1_2.Text = " 客先注文番号"
        '
        '_FM_Panel3D1_3
        '
        Me._FM_Panel3D1_3.Location = New System.Drawing.Point(5, 6)
        Me._FM_Panel3D1_3.Name = "_FM_Panel3D1_3"
        Me._FM_Panel3D1_3.Size = New System.Drawing.Size(97, 25)
        Me._FM_Panel3D1_3.TabIndex = 1
        Me._FM_Panel3D1_3.Text = " ステータス"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("MS Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(597, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(27, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "～"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("MS Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(120, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(267, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "1:未出荷 2:売上済 3:入金済 9:全件"
        '
        '_FM_Panel3D1_1
        '
        Me._FM_Panel3D1_1.Font = New System.Drawing.Font("MS Gothic", 10.0!)
        Me._FM_Panel3D1_1.Location = New System.Drawing.Point(1, 93)
        Me._FM_Panel3D1_1.Name = "_FM_Panel3D1_1"
        Me._FM_Panel3D1_1.Size = New System.Drawing.Size(880, 25)
        Me._FM_Panel3D1_1.TabIndex = 16
        Me._FM_Panel3D1_1.Text = "客先注文番号             受注番号 ｽﾃｰﾀｽ  出荷予定日  製品     決済方法      納入先名  "
        Me._FM_Panel3D1_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LST
        '
        Me.LST.BackColor = System.Drawing.SystemColors.Window
        Me.LST.Cursor = System.Windows.Forms.Cursors.Default
        Me.LST.Font = New System.Drawing.Font("MS Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LST.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LST.Items.AddRange(New Object() {"XXXXXXXXX1XXXXXXXXX2XXX XXXXXXX8-12 MM3 9999/99/99  XXXXXXX8    MMMMM6 MMMMMMMMM1" &
                "MMMMMMMMM2MMMMMMMMM3"})
        Me.LST.Location = New System.Drawing.Point(1, 116)
        Me.LST.Name = "LST"
        Me.LST.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LST.Size = New System.Drawing.Size(880, 199)
        Me.LST.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.HighlightText
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("MS Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(5, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(1009, 1)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "MMMMM6 MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4 MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMM" &
    "M36 XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3 9999/99/99 99999999 99999999"
        '
        '_IM_PrevCm_0
        '
        Me._IM_PrevCm_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_PrevCm_0.Image = CType(resources.GetObject("_IM_PrevCm_0.Image"), System.Drawing.Image)
        Me.IM_PrevCm.SetIndex(Me._IM_PrevCm_0, CType(0, Short))
        Me._IM_PrevCm_0.Location = New System.Drawing.Point(257, 408)
        Me._IM_PrevCm_0.Name = "_IM_PrevCm_0"
        Me._IM_PrevCm_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_PrevCm_0.TabIndex = 22
        Me._IM_PrevCm_0.TabStop = False
        Me._IM_PrevCm_0.Visible = False
        '
        '_IM_NextCm_0
        '
        Me._IM_NextCm_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_NextCm_0.Image = CType(resources.GetObject("_IM_NextCm_0.Image"), System.Drawing.Image)
        Me.IM_NextCm.SetIndex(Me._IM_NextCm_0, CType(0, Short))
        Me._IM_NextCm_0.Location = New System.Drawing.Point(317, 408)
        Me._IM_NextCm_0.Name = "_IM_NextCm_0"
        Me._IM_NextCm_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_NextCm_0.TabIndex = 23
        Me._IM_NextCm_0.TabStop = False
        Me._IM_NextCm_0.Visible = False
        '
        '_IM_NextCm_1
        '
        Me._IM_NextCm_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_NextCm_1.Image = CType(resources.GetObject("_IM_NextCm_1.Image"), System.Drawing.Image)
        Me.IM_NextCm.SetIndex(Me._IM_NextCm_1, CType(1, Short))
        Me._IM_NextCm_1.Location = New System.Drawing.Point(344, 408)
        Me._IM_NextCm_1.Name = "_IM_NextCm_1"
        Me._IM_NextCm_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_NextCm_1.TabIndex = 24
        Me._IM_NextCm_1.TabStop = False
        Me._IM_NextCm_1.Visible = False
        '
        '_IM_PrevCm_1
        '
        Me._IM_PrevCm_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_PrevCm_1.Image = CType(resources.GetObject("_IM_PrevCm_1.Image"), System.Drawing.Image)
        Me.IM_PrevCm.SetIndex(Me._IM_PrevCm_1, CType(1, Short))
        Me._IM_PrevCm_1.Location = New System.Drawing.Point(284, 408)
        Me._IM_PrevCm_1.Name = "_IM_PrevCm_1"
        Me._IM_PrevCm_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_PrevCm_1.TabIndex = 25
        Me._IM_PrevCm_1.TabStop = False
        Me._IM_PrevCm_1.Visible = False
        '
        'btnF9
        '
        Me.btnF9.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF9.Location = New System.Drawing.Point(695, 321)
        Me.btnF9.Name = "btnF9"
        Me.btnF9.Size = New System.Drawing.Size(75, 39)
        Me.btnF9.TabIndex = 32
        Me.btnF9.Text = "(F9)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "クリア"
        Me.btnF9.UseVisualStyleBackColor = True
        '
        'btnF2
        '
        Me.btnF2.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF2.Location = New System.Drawing.Point(99, 321)
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(75, 39)
        Me.btnF2.TabIndex = 29
        Me.btnF2.Text = "(F2)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "検索"
        Me.btnF2.UseVisualStyleBackColor = True
        '
        'btnF1
        '
        Me.btnF1.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF1.Location = New System.Drawing.Point(5, 321)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(75, 39)
        Me.btnF1.TabIndex = 28
        Me.btnF1.Text = "(F1)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "確定"
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'btnF8
        '
        Me.btnF8.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF8.Location = New System.Drawing.Point(421, 321)
        Me.btnF8.Name = "btnF8"
        Me.btnF8.Size = New System.Drawing.Size(75, 39)
        Me.btnF8.TabIndex = 31
        Me.btnF8.Text = "(F8)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "次頁"
        Me.btnF8.UseVisualStyleBackColor = True
        '
        'btnF7
        '
        Me.btnF7.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF7.Location = New System.Drawing.Point(329, 321)
        Me.btnF7.Name = "btnF7"
        Me.btnF7.Size = New System.Drawing.Size(75, 39)
        Me.btnF7.TabIndex = 30
        Me.btnF7.Text = "(F7)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "前頁"
        Me.btnF7.UseVisualStyleBackColor = True
        '
        'btnF12
        '
        Me.btnF12.Font = New System.Drawing.Font("MS Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF12.Location = New System.Drawing.Point(790, 321)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(75, 39)
        Me.btnF12.TabIndex = 33
        Me.btnF12.Text = "(F12)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'WLS_THNDAT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(887, 364)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnF9)
        Me.Controls.Add(Me.btnF2)
        Me.Controls.Add(Me.btnF1)
        Me.Controls.Add(Me.btnF8)
        Me.Controls.Add(Me.btnF7)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.TX_CursorRest)
        Me.Controls.Add(Me.HD_ODNYTDT_ST)
        Me.Controls.Add(Me.HD_TOKJDNNO)
        Me.Controls.Add(Me.WLSOK)
        Me.Controls.Add(Me.WLSCANCEL)
        Me.Controls.Add(Me.Panel3D1)
        Me.Controls.Add(Me._FM_Panel3D1_1)
        Me.Controls.Add(Me.LST)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._IM_PrevCm_0)
        Me.Controls.Add(Me._IM_NextCm_0)
        Me.Controls.Add(Me._IM_NextCm_1)
        Me.Controls.Add(Me._IM_PrevCm_1)
        Me.Controls.Add(Me.CM_PrevCm)
        Me.Controls.Add(Me.CM_NextCm)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("MS Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(4, 214)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WLS_THNDAT"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "通販データ検索"
        CType(Me.CM_PrevCm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_NextCm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3D1.ResumeLayout(False)
        Me.Panel3D1.PerformLayout()
        CType(Me._IM_PrevCm_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_NextCm_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_NextCm_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_PrevCm_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_NextCm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_PrevCm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnF9 As Button
    Friend WithEvents btnF2 As Button
    Friend WithEvents btnF1 As Button
    Friend WithEvents btnF8 As Button
    Friend WithEvents btnF7 As Button
    Friend WithEvents btnF12 As Button
    Friend WithEvents WLSOK As Button
    Friend WithEvents WLSCANCEL As Button
    Friend WithEvents CM_PrevCm As PictureBox
    Friend WithEvents CM_NextCm As PictureBox
#End Region
End Class