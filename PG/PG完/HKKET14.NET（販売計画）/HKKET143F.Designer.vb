<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class HKKET143F
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
	Public WithEvents txtMKOUTQTY As System.Windows.Forms.TextBox
	Public WithEvents txtESTIMATE As System.Windows.Forms.TextBox
	Public WithEvents txtISSUE As System.Windows.Forms.TextBox
	Public WithEvents txtSKYQTY As System.Windows.Forms.TextBox
	Public WithEvents txtOUTQTY As System.Windows.Forms.TextBox
	Public WithEvents txtINQTY As System.Windows.Forms.TextBox
	Public WithEvents txtHINCD As System.Windows.Forms.TextBox
	Public WithEvents txtHINNMA As System.Windows.Forms.TextBox
	Public WithEvents txtHINNMB As System.Windows.Forms.TextBox
	Public WithEvents txtZAIRNK As System.Windows.Forms.TextBox
	Public WithEvents cmdRETURN As System.Windows.Forms.Button
	Public WithEvents txtTODAY As System.Windows.Forms.TextBox
	Public WithEvents txtMONTH As System.Windows.Forms.TextBox
	Public WithEvents txtYEAR As System.Windows.Forms.TextBox
	Public WithEvents txtTERM As System.Windows.Forms.TextBox
    'Public WithEvents _lvwMEISAI_ColumnHeader_1 As ColumnHeader
    'Public WithEvents _lvwMEISAI_ColumnHeader_2 As ColumnHeader
    'Public WithEvents _lvwMEISAI_ColumnHeader_3 As ColumnHeader
    'Public WithEvents _lvwMEISAI_ColumnHeader_4 As ColumnHeader
    'Public WithEvents _lvwMEISAI_ColumnHeader_5 As ColumnHeader
    'Public WithEvents _lvwMEISAI_ColumnHeader_6 As ColumnHeader
    'Public WithEvents _lvwMEISAI_ColumnHeader_7 As ColumnHeader
    'Public WithEvents _lvwMEISAI_ColumnHeader_8 As ColumnHeader
    'Public WithEvents _lvwMEISAI_ColumnHeader_9 As ColumnHeader
    'Public WithEvents _lvwMEISAI_ColumnHeader_10 As ColumnHeader
    'Public WithEvents _lvwMEISAI_ColumnHeader_11 As ColumnHeader
    'Public WithEvents _lvwMEISAI_ColumnHeader_12 As ColumnHeader
    'Public WithEvents _lvwMEISAI_ColumnHeader_13 As ColumnHeader
    'Public WithEvents _lvwMEISAI_ColumnHeader_14 As ColumnHeader
	Public WithEvents lvwMEISAI As ListView
	Public WithEvents Line1 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HKKET143F))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtMKOUTQTY = New System.Windows.Forms.TextBox()
        Me.txtESTIMATE = New System.Windows.Forms.TextBox()
        Me.txtISSUE = New System.Windows.Forms.TextBox()
        Me.txtSKYQTY = New System.Windows.Forms.TextBox()
        Me.txtOUTQTY = New System.Windows.Forms.TextBox()
        Me.txtINQTY = New System.Windows.Forms.TextBox()
        Me.txtHINCD = New System.Windows.Forms.TextBox()
        Me.txtHINNMA = New System.Windows.Forms.TextBox()
        Me.txtHINNMB = New System.Windows.Forms.TextBox()
        Me.txtZAIRNK = New System.Windows.Forms.TextBox()
        Me.cmdRETURN = New System.Windows.Forms.Button()
        Me.txtTODAY = New System.Windows.Forms.TextBox()
        Me.txtMONTH = New System.Windows.Forms.TextBox()
        Me.txtYEAR = New System.Windows.Forms.TextBox()
        Me.txtTERM = New System.Windows.Forms.TextBox()
        Me.lvwMEISAI = New System.Windows.Forms.ListView()
        Me.SBCD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DATKB = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HKKSU = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HKKINFA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MITNO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TANNM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HKKINFC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HKKINFD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HKKINFE = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HKKINFF = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PHINCD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PHINKTA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ORDSCLNM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.KHIKKB = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Line1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtMKOUTQTY
        '
        Me.txtMKOUTQTY.AcceptsReturn = True
        Me.txtMKOUTQTY.BackColor = System.Drawing.SystemColors.Control
        Me.txtMKOUTQTY.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtMKOUTQTY.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtMKOUTQTY.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMKOUTQTY.Location = New System.Drawing.Point(672, 640)
        Me.txtMKOUTQTY.MaxLength = 0
        Me.txtMKOUTQTY.Name = "txtMKOUTQTY"
        Me.txtMKOUTQTY.ReadOnly = True
        Me.txtMKOUTQTY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMKOUTQTY.Size = New System.Drawing.Size(49, 20)
        Me.txtMKOUTQTY.TabIndex = 28
        Me.txtMKOUTQTY.TabStop = False
        Me.txtMKOUTQTY.Text = "99999"
        Me.txtMKOUTQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtESTIMATE
        '
        Me.txtESTIMATE.AcceptsReturn = True
        Me.txtESTIMATE.BackColor = System.Drawing.SystemColors.Control
        Me.txtESTIMATE.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtESTIMATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtESTIMATE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtESTIMATE.Location = New System.Drawing.Point(520, 640)
        Me.txtESTIMATE.MaxLength = 0
        Me.txtESTIMATE.Name = "txtESTIMATE"
        Me.txtESTIMATE.ReadOnly = True
        Me.txtESTIMATE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtESTIMATE.Size = New System.Drawing.Size(49, 20)
        Me.txtESTIMATE.TabIndex = 27
        Me.txtESTIMATE.TabStop = False
        Me.txtESTIMATE.Text = "99999"
        Me.txtESTIMATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtISSUE
        '
        Me.txtISSUE.AcceptsReturn = True
        Me.txtISSUE.BackColor = System.Drawing.SystemColors.Control
        Me.txtISSUE.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtISSUE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtISSUE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtISSUE.Location = New System.Drawing.Point(416, 640)
        Me.txtISSUE.MaxLength = 0
        Me.txtISSUE.Name = "txtISSUE"
        Me.txtISSUE.ReadOnly = True
        Me.txtISSUE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtISSUE.Size = New System.Drawing.Size(49, 20)
        Me.txtISSUE.TabIndex = 26
        Me.txtISSUE.TabStop = False
        Me.txtISSUE.Text = "99999"
        Me.txtISSUE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSKYQTY
        '
        Me.txtSKYQTY.AcceptsReturn = True
        Me.txtSKYQTY.BackColor = System.Drawing.SystemColors.Control
        Me.txtSKYQTY.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtSKYQTY.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSKYQTY.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSKYQTY.Location = New System.Drawing.Point(320, 640)
        Me.txtSKYQTY.MaxLength = 0
        Me.txtSKYQTY.Name = "txtSKYQTY"
        Me.txtSKYQTY.ReadOnly = True
        Me.txtSKYQTY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSKYQTY.Size = New System.Drawing.Size(49, 20)
        Me.txtSKYQTY.TabIndex = 25
        Me.txtSKYQTY.TabStop = False
        Me.txtSKYQTY.Text = "99999"
        Me.txtSKYQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOUTQTY
        '
        Me.txtOUTQTY.AcceptsReturn = True
        Me.txtOUTQTY.BackColor = System.Drawing.SystemColors.Control
        Me.txtOUTQTY.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtOUTQTY.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtOUTQTY.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOUTQTY.Location = New System.Drawing.Point(192, 640)
        Me.txtOUTQTY.MaxLength = 0
        Me.txtOUTQTY.Name = "txtOUTQTY"
        Me.txtOUTQTY.ReadOnly = True
        Me.txtOUTQTY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOUTQTY.Size = New System.Drawing.Size(49, 20)
        Me.txtOUTQTY.TabIndex = 24
        Me.txtOUTQTY.TabStop = False
        Me.txtOUTQTY.Text = "99999"
        Me.txtOUTQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtINQTY
        '
        Me.txtINQTY.AcceptsReturn = True
        Me.txtINQTY.BackColor = System.Drawing.SystemColors.Control
        Me.txtINQTY.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtINQTY.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtINQTY.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtINQTY.Location = New System.Drawing.Point(72, 640)
        Me.txtINQTY.MaxLength = 0
        Me.txtINQTY.Name = "txtINQTY"
        Me.txtINQTY.ReadOnly = True
        Me.txtINQTY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtINQTY.Size = New System.Drawing.Size(49, 20)
        Me.txtINQTY.TabIndex = 23
        Me.txtINQTY.TabStop = False
        Me.txtINQTY.Text = "99999"
        Me.txtINQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHINCD
        '
        Me.txtHINCD.AcceptsReturn = True
        Me.txtHINCD.BackColor = System.Drawing.SystemColors.Control
        Me.txtHINCD.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtHINCD.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtHINCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHINCD.Location = New System.Drawing.Point(79, 32)
        Me.txtHINCD.MaxLength = 0
        Me.txtHINCD.Name = "txtHINCD"
        Me.txtHINCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHINCD.Size = New System.Drawing.Size(66, 19)
        Me.txtHINCD.TabIndex = 12
        Me.txtHINCD.TabStop = False
        Me.txtHINCD.Text = "XXXXXXX8"
        '
        'txtHINNMA
        '
        Me.txtHINNMA.AcceptsReturn = True
        Me.txtHINNMA.BackColor = System.Drawing.SystemColors.Control
        Me.txtHINNMA.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtHINNMA.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtHINNMA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHINNMA.Location = New System.Drawing.Point(186, 32)
        Me.txtHINNMA.MaxLength = 0
        Me.txtHINNMA.Name = "txtHINNMA"
        Me.txtHINNMA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHINNMA.Size = New System.Drawing.Size(216, 19)
        Me.txtHINNMA.TabIndex = 11
        Me.txtHINNMA.TabStop = False
        Me.txtHINNMA.Text = "XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3"
        '
        'txtHINNMB
        '
        Me.txtHINNMB.AcceptsReturn = True
        Me.txtHINNMB.BackColor = System.Drawing.SystemColors.Control
        Me.txtHINNMB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtHINNMB.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtHINNMB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHINNMB.Location = New System.Drawing.Point(435, 32)
        Me.txtHINNMB.MaxLength = 0
        Me.txtHINNMB.Name = "txtHINNMB"
        Me.txtHINNMB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHINNMB.Size = New System.Drawing.Size(447, 19)
        Me.txtHINNMB.TabIndex = 10
        Me.txtHINNMB.TabStop = False
        Me.txtHINNMB.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5"
        '
        'txtZAIRNK
        '
        Me.txtZAIRNK.AcceptsReturn = True
        Me.txtZAIRNK.BackColor = System.Drawing.SystemColors.Control
        Me.txtZAIRNK.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtZAIRNK.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtZAIRNK.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtZAIRNK.Location = New System.Drawing.Point(940, 32)
        Me.txtZAIRNK.MaxLength = 0
        Me.txtZAIRNK.Name = "txtZAIRNK"
        Me.txtZAIRNK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtZAIRNK.Size = New System.Drawing.Size(36, 19)
        Me.txtZAIRNK.TabIndex = 9
        Me.txtZAIRNK.TabStop = False
        Me.txtZAIRNK.Text = "XXXX"
        '
        'cmdRETURN
        '
        Me.cmdRETURN.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRETURN.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRETURN.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdRETURN.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRETURN.Location = New System.Drawing.Point(915, 642)
        Me.cmdRETURN.Name = "cmdRETURN"
        Me.cmdRETURN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRETURN.Size = New System.Drawing.Size(77, 25)
        Me.cmdRETURN.TabIndex = 8
        Me.cmdRETURN.Text = "戻る"
        Me.cmdRETURN.UseVisualStyleBackColor = False
        '
        'txtTODAY
        '
        Me.txtTODAY.AcceptsReturn = True
        Me.txtTODAY.BackColor = System.Drawing.SystemColors.Control
        Me.txtTODAY.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTODAY.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTODAY.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTODAY.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtTODAY.Location = New System.Drawing.Point(932, 8)
        Me.txtTODAY.MaxLength = 0
        Me.txtTODAY.Name = "txtTODAY"
        Me.txtTODAY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTODAY.Size = New System.Drawing.Size(81, 12)
        Me.txtTODAY.TabIndex = 7
        Me.txtTODAY.TabStop = False
        Me.txtTODAY.Text = "YYYY/MM/DD"
        '
        'txtMONTH
        '
        Me.txtMONTH.AcceptsReturn = True
        Me.txtMONTH.BackColor = System.Drawing.SystemColors.Control
        Me.txtMONTH.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtMONTH.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtMONTH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMONTH.Location = New System.Drawing.Point(136, 8)
        Me.txtMONTH.MaxLength = 0
        Me.txtMONTH.Name = "txtMONTH"
        Me.txtMONTH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMONTH.Size = New System.Drawing.Size(25, 19)
        Me.txtMONTH.TabIndex = 6
        Me.txtMONTH.TabStop = False
        Me.txtMONTH.Text = "99"
        Me.txtMONTH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtYEAR
        '
        Me.txtYEAR.AcceptsReturn = True
        Me.txtYEAR.BackColor = System.Drawing.SystemColors.Control
        Me.txtYEAR.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtYEAR.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtYEAR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtYEAR.Location = New System.Drawing.Point(64, 7)
        Me.txtYEAR.MaxLength = 0
        Me.txtYEAR.Name = "txtYEAR"
        Me.txtYEAR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtYEAR.Size = New System.Drawing.Size(41, 19)
        Me.txtYEAR.TabIndex = 3
        Me.txtYEAR.TabStop = False
        Me.txtYEAR.Text = "YYYY"
        Me.txtYEAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTERM
        '
        Me.txtTERM.AcceptsReturn = True
        Me.txtTERM.BackColor = System.Drawing.SystemColors.Control
        Me.txtTERM.CausesValidation = False
        Me.txtTERM.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTERM.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTERM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTERM.Location = New System.Drawing.Point(8, 8)
        Me.txtTERM.MaxLength = 0
        Me.txtTERM.Name = "txtTERM"
        Me.txtTERM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTERM.Size = New System.Drawing.Size(25, 19)
        Me.txtTERM.TabIndex = 2
        Me.txtTERM.TabStop = False
        Me.txtTERM.Text = "99"
        Me.txtTERM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lvwMEISAI
        '
        Me.lvwMEISAI.BackColor = System.Drawing.SystemColors.Window
        Me.lvwMEISAI.CausesValidation = False
        Me.lvwMEISAI.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.SBCD, Me.DATKB, Me.HKKSU, Me.HKKINFA, Me.MITNO, Me.TANNM, Me.HKKINFC, Me.HKKINFD, Me.HKKINFE, Me.HKKINFF, Me.PHINCD, Me.PHINKTA, Me.ORDSCLNM, Me.KHIKKB})
        Me.lvwMEISAI.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lvwMEISAI.FullRowSelect = True
        Me.lvwMEISAI.GridLines = True
        Me.lvwMEISAI.LabelEdit = True
        Me.lvwMEISAI.LabelWrap = False
        Me.lvwMEISAI.Location = New System.Drawing.Point(8, 64)
        Me.lvwMEISAI.Name = "lvwMEISAI"
        Me.lvwMEISAI.Size = New System.Drawing.Size(993, 569)
        Me.lvwMEISAI.TabIndex = 0
        Me.lvwMEISAI.UseCompatibleStateImageBehavior = False
        Me.lvwMEISAI.View = System.Windows.Forms.View.Details
        '
        'SBCD
        '
        Me.SBCD.Name = "SBCD"
        Me.SBCD.Text = "種別"
        '
        'DATKB
        '
        Me.DATKB.Name = "DATKB"
        Me.DATKB.Text = "区分"
        '
        'HKKSU
        '
        Me.HKKSU.Name = "HKKSU"
        Me.HKKSU.Tag = "NUMBER"
        Me.HKKSU.Text = "数量"
        Me.HKKSU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'HKKINFA
        '
        Me.HKKINFA.Name = "HKKINFA"
        Me.HKKINFA.Text = "受注番号等"
        Me.HKKINFA.Width = 120
        '
        'MITNO
        '
        Me.MITNO.Name = "MITNO"
        Me.MITNO.Text = "見積番号"
        Me.MITNO.Width = 120
        '
        'TANNM
        '
        Me.TANNM.Name = "TANNM"
        Me.TANNM.Text = "担当者"
        Me.TANNM.Width = 120
        '
        'HKKINFC
        '
        Me.HKKINFC.Name = "HKKINFC"
        Me.HKKINFC.Tag = "DATE"
        Me.HKKINFC.Text = "受注日等"
        Me.HKKINFC.Width = 120
        '
        'HKKINFD
        '
        Me.HKKINFD.Name = "HKKINFD"
        Me.HKKINFD.Tag = "DATE"
        Me.HKKINFD.Text = "出荷日等"
        Me.HKKINFD.Width = 120
        '
        'HKKINFE
        '
        Me.HKKINFE.Name = "HKKINFE"
        Me.HKKINFE.Text = "件名"
        Me.HKKINFE.Width = 180
        '
        'HKKINFF
        '
        Me.HKKINFF.Name = "HKKINFF"
        Me.HKKINFF.Text = "得意先名等"
        Me.HKKINFF.Width = 180
        '
        'PHINCD
        '
        Me.PHINCD.Name = "PHINCD"
        Me.PHINCD.Text = "親－製品番号"
        Me.PHINCD.Width = 120
        '
        'PHINKTA
        '
        Me.PHINKTA.Name = "PHINKTA"
        Me.PHINKTA.Text = "親－型式"
        Me.PHINKTA.Width = 120
        '
        'ORDSCLNM
        '
        Me.ORDSCLNM.Name = "ORDSCLNM"
        Me.ORDSCLNM.Text = "受注確度"
        '
        'KHIKKB
        '
        Me.KHIKKB.Name = "KHIKKB"
        Me.KHIKKB.Text = "引当区分"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Location = New System.Drawing.Point(8, 56)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(984, 1)
        Me.Line1.TabIndex = 29
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label8.Location = New System.Drawing.Point(10, 644)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "入庫予定"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label9.Location = New System.Drawing.Point(140, 644)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "出庫予定"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label11.Location = New System.Drawing.Point(378, 644)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(37, 12)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "案　件"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label12.Location = New System.Drawing.Point(482, 644)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(37, 12)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "見　積"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label10.Location = New System.Drawing.Point(258, 644)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "支給品出庫"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label13.Location = New System.Drawing.Point(592, 644)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(77, 12)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "見込出庫予定"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(23, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(52, 12)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "製品ｺｰﾄﾞ"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(153, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "型式"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(407, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "品名"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(889, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(49, 12)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "在庫ﾗﾝｸ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(168, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "月"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(112, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "年"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(40, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "期"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 674)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1016, 22)
        Me.StatusStrip1.TabIndex = 247
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(194, 17)
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(194, 17)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "端末ID"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(194, 17)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Text = "ログインID"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(194, 17)
        Me.ToolStripStatusLabel4.Spring = True
        Me.ToolStripStatusLabel4.Text = "XXXXXXX"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(194, 17)
        Me.ToolStripStatusLabel5.Spring = True
        Me.ToolStripStatusLabel5.Text = "Ver.1.00"
        '
        'HKKET143F
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1016, 696)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txtMKOUTQTY)
        Me.Controls.Add(Me.txtESTIMATE)
        Me.Controls.Add(Me.txtISSUE)
        Me.Controls.Add(Me.txtSKYQTY)
        Me.Controls.Add(Me.txtOUTQTY)
        Me.Controls.Add(Me.txtINQTY)
        Me.Controls.Add(Me.txtHINCD)
        Me.Controls.Add(Me.txtHINNMA)
        Me.Controls.Add(Me.txtHINNMB)
        Me.Controls.Add(Me.txtZAIRNK)
        Me.Controls.Add(Me.cmdRETURN)
        Me.Controls.Add(Me.txtTODAY)
        Me.Controls.Add(Me.txtMONTH)
        Me.Controls.Add(Me.txtYEAR)
        Me.Controls.Add(Me.txtTERM)
        Me.Controls.Add(Me.lvwMEISAI)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 36)
        Me.MaximizeBox = False
        Me.Name = "HKKET143F"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "販売計画(月別詳細)"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents lvColSBCD As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColDATKB As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColHKKSU As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColHKKINFA As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColMITNO As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColTANNM As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColHKKINFC As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColHKKINFD As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColHKKINFE As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColHKKINFF As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColPHINCD As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColPHINKTA As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColORDSCLNM As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColKHIKKB As System.Windows.Forms.ColumnHeader
    Public WithEvents SBCD As System.Windows.Forms.ColumnHeader
    Public WithEvents DATKB As System.Windows.Forms.ColumnHeader
    Public WithEvents HKKSU As System.Windows.Forms.ColumnHeader
    Public WithEvents HKKINFA As System.Windows.Forms.ColumnHeader
    Public WithEvents MITNO As System.Windows.Forms.ColumnHeader
    Public WithEvents TANNM As System.Windows.Forms.ColumnHeader
    Public WithEvents HKKINFC As System.Windows.Forms.ColumnHeader
    Public WithEvents HKKINFD As System.Windows.Forms.ColumnHeader
    Public WithEvents HKKINFE As System.Windows.Forms.ColumnHeader
    Public WithEvents HKKINFF As System.Windows.Forms.ColumnHeader
    Public WithEvents PHINCD As System.Windows.Forms.ColumnHeader
    Public WithEvents PHINKTA As System.Windows.Forms.ColumnHeader
    Public WithEvents ORDSCLNM As System.Windows.Forms.ColumnHeader
    Public WithEvents KHIKKB As System.Windows.Forms.ColumnHeader
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
#End Region
End Class