<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class HKKET141F
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
    'Public WithEvents cdl_SAVE1 As CommonDialog
    Public WithEvents cdl_SAVE1 As OpenFileDialog
	Public WithEvents txtCount As System.Windows.Forms.TextBox
	Public WithEvents txtTODAY As System.Windows.Forms.TextBox
	Public WithEvents cmdALL_SELECT As System.Windows.Forms.Button
	Public WithEvents cmdALL_RELEASE As System.Windows.Forms.Button
	Public WithEvents cmdINPUT As System.Windows.Forms.Button
	Public WithEvents cmdOUTPUT As System.Windows.Forms.Button
	Public WithEvents frmSTY As System.Windows.Forms.GroupBox
	Public WithEvents _lvwMEISAI_ColumnHeader_1 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_2 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_3 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_4 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_5 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_6 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_7 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_8 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_9 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_10 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_11 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_12 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_13 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_14 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_15 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_16 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_17 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_18 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_19 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_20 As ColumnHeader
	Public WithEvents _lvwMEISAI_ColumnHeader_21 As ColumnHeader
	Public WithEvents lvwMEISAI As ListView
	Public WithEvents cmdCSVOUT As System.Windows.Forms.Button
	Public WithEvents cmdSERCH As System.Windows.Forms.Button
	Public WithEvents optVERSION As System.Windows.Forms.RadioButton
	Public WithEvents optONLY As System.Windows.Forms.RadioButton
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents frmGROUP As System.Windows.Forms.GroupBox
	Public WithEvents optORDER_ON As System.Windows.Forms.RadioButton
	Public WithEvents optORDER_OFF As System.Windows.Forms.RadioButton
	Public WithEvents fraORDER As System.Windows.Forms.GroupBox
	Public WithEvents _txtHINGRP_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtHINGRP_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtHINGRP_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtHINGRP_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtHINGRP_4 As System.Windows.Forms.TextBox
	Public WithEvents _txtHINGRP_5 As System.Windows.Forms.TextBox
	Public WithEvents txtMNFDD As System.Windows.Forms.TextBox
	Public WithEvents _txtZAIRNK_7 As System.Windows.Forms.TextBox
	Public WithEvents _txtZAIRNK_6 As System.Windows.Forms.TextBox
	Public WithEvents _txtZAIRNK_5 As System.Windows.Forms.TextBox
	Public WithEvents _txtZAIRNK_4 As System.Windows.Forms.TextBox
	Public WithEvents _txtZAIRNK_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtZAIRNK_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtZAIRNK_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtZAIRNK_0 As System.Windows.Forms.TextBox
	Public WithEvents txtHINNMA As System.Windows.Forms.TextBox
	Public WithEvents txtHINCD As System.Windows.Forms.TextBox
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents lblLT As System.Windows.Forms.Label
	Public WithEvents lblRANK As System.Windows.Forms.Label
	Public WithEvents lblMODEL As System.Windows.Forms.Label
	Public WithEvents lblHINGRP As System.Windows.Forms.Label
	Public WithEvents lblHINCD As System.Windows.Forms.Label
	Public WithEvents frmDISPLAY As System.Windows.Forms.GroupBox
	Public WithEvents txtORDER_OMISSION As System.Windows.Forms.TextBox
	Public WithEvents txtSTOCK_MONTH As System.Windows.Forms.TextBox
	Public WithEvents txtSTOCK As System.Windows.Forms.TextBox
	Public WithEvents txtSAFTY_STOCK As System.Windows.Forms.TextBox
	Public WithEvents optORDER_OMISSION As System.Windows.Forms.RadioButton
	Public WithEvents optSTOCK_MONTH As System.Windows.Forms.RadioButton
	Public WithEvents optSAFTY_STOCK As System.Windows.Forms.RadioButton
	Public WithEvents optSTOCK As System.Windows.Forms.RadioButton
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents fraSTOCK As System.Windows.Forms.GroupBox
	Public WithEvents optCARRIES_ON As System.Windows.Forms.RadioButton
	Public WithEvents optCARRIES_OFF As System.Windows.Forms.RadioButton
	Public WithEvents fraCARRIES As System.Windows.Forms.GroupBox
	Public WithEvents fraWARNING As System.Windows.Forms.GroupBox
	Public WithEvents cmdEND As System.Windows.Forms.Button
	Public WithEvents cmdDISPLAY As System.Windows.Forms.Button
	Public WithEvents lbl処理中 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents lblCount As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Line1 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents txtHINGRP As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents txtZAIRNK As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HKKET141F))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cdl_SAVE1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtCount = New System.Windows.Forms.TextBox()
        Me.txtTODAY = New System.Windows.Forms.TextBox()
        Me.cmdALL_SELECT = New System.Windows.Forms.Button()
        Me.cmdALL_RELEASE = New System.Windows.Forms.Button()
        Me.frmSTY = New System.Windows.Forms.GroupBox()
        Me.cmdINPUT = New System.Windows.Forms.Button()
        Me.cmdOUTPUT = New System.Windows.Forms.Button()
        Me.lvwMEISAI = New System.Windows.Forms.ListView()
        Me.SEL = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.WARNING = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HINCD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HINKTA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.JIGKB = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ZAIRNK = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PRDENDKB = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SLSTPKB = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TOUZAISU = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.JYCYUSU = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MKMZAISU = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MKMJYCYUSU = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LMAZKT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LMAAVTS = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LMZZAISA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LMZAZM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LMZZKM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LMADAYS = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LMSKYDT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MNFDD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HINGRP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdCSVOUT = New System.Windows.Forms.Button()
        Me.cmdSERCH = New System.Windows.Forms.Button()
        Me.frmGROUP = New System.Windows.Forms.GroupBox()
        Me.optVERSION = New System.Windows.Forms.RadioButton()
        Me.optONLY = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.fraORDER = New System.Windows.Forms.GroupBox()
        Me.optORDER_ON = New System.Windows.Forms.RadioButton()
        Me.optORDER_OFF = New System.Windows.Forms.RadioButton()
        Me.frmDISPLAY = New System.Windows.Forms.GroupBox()
        Me._txtHINGRP_0 = New System.Windows.Forms.TextBox()
        Me._txtHINGRP_1 = New System.Windows.Forms.TextBox()
        Me._txtHINGRP_2 = New System.Windows.Forms.TextBox()
        Me._txtHINGRP_3 = New System.Windows.Forms.TextBox()
        Me._txtHINGRP_4 = New System.Windows.Forms.TextBox()
        Me._txtHINGRP_5 = New System.Windows.Forms.TextBox()
        Me.txtMNFDD = New System.Windows.Forms.TextBox()
        Me._txtZAIRNK_7 = New System.Windows.Forms.TextBox()
        Me._txtZAIRNK_6 = New System.Windows.Forms.TextBox()
        Me._txtZAIRNK_5 = New System.Windows.Forms.TextBox()
        Me._txtZAIRNK_4 = New System.Windows.Forms.TextBox()
        Me._txtZAIRNK_3 = New System.Windows.Forms.TextBox()
        Me._txtZAIRNK_2 = New System.Windows.Forms.TextBox()
        Me._txtZAIRNK_1 = New System.Windows.Forms.TextBox()
        Me._txtZAIRNK_0 = New System.Windows.Forms.TextBox()
        Me.txtHINNMA = New System.Windows.Forms.TextBox()
        Me.txtHINCD = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblLT = New System.Windows.Forms.Label()
        Me.lblRANK = New System.Windows.Forms.Label()
        Me.lblMODEL = New System.Windows.Forms.Label()
        Me.lblHINGRP = New System.Windows.Forms.Label()
        Me.lblHINCD = New System.Windows.Forms.Label()
        Me.fraWARNING = New System.Windows.Forms.GroupBox()
        Me.fraSTOCK = New System.Windows.Forms.GroupBox()
        Me.txtORDER_OMISSION = New System.Windows.Forms.TextBox()
        Me.txtSTOCK_MONTH = New System.Windows.Forms.TextBox()
        Me.txtSTOCK = New System.Windows.Forms.TextBox()
        Me.txtSAFTY_STOCK = New System.Windows.Forms.TextBox()
        Me.optORDER_OMISSION = New System.Windows.Forms.RadioButton()
        Me.optSTOCK_MONTH = New System.Windows.Forms.RadioButton()
        Me.optSAFTY_STOCK = New System.Windows.Forms.RadioButton()
        Me.optSTOCK = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fraCARRIES = New System.Windows.Forms.GroupBox()
        Me.optCARRIES_ON = New System.Windows.Forms.RadioButton()
        Me.optCARRIES_OFF = New System.Windows.Forms.RadioButton()
        Me.cmdEND = New System.Windows.Forms.Button()
        Me.cmdDISPLAY = New System.Windows.Forms.Button()
        Me.lbl処理中 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Line1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHINGRP = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.txtZAIRNK = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.frmSTY.SuspendLayout()
        Me.frmGROUP.SuspendLayout()
        Me.fraORDER.SuspendLayout()
        Me.frmDISPLAY.SuspendLayout()
        Me.fraWARNING.SuspendLayout()
        Me.fraSTOCK.SuspendLayout()
        Me.fraCARRIES.SuspendLayout()
        CType(Me.txtHINGRP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtZAIRNK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCount
        '
        Me.txtCount.AcceptsReturn = True
        Me.txtCount.BackColor = System.Drawing.SystemColors.Control
        Me.txtCount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCount.Location = New System.Drawing.Point(880, 136)
        Me.txtCount.MaxLength = 0
        Me.txtCount.Name = "txtCount"
        Me.txtCount.ReadOnly = True
        Me.txtCount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCount.Size = New System.Drawing.Size(55, 19)
        Me.txtCount.TabIndex = 59
        Me.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTODAY
        '
        Me.txtTODAY.AcceptsReturn = True
        Me.txtTODAY.BackColor = System.Drawing.SystemColors.Control
        Me.txtTODAY.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTODAY.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTODAY.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtTODAY.Location = New System.Drawing.Point(924, 12)
        Me.txtTODAY.MaxLength = 0
        Me.txtTODAY.Name = "txtTODAY"
        Me.txtTODAY.ReadOnly = True
        Me.txtTODAY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTODAY.Size = New System.Drawing.Size(79, 12)
        Me.txtTODAY.TabIndex = 58
        Me.txtTODAY.Text = "YYYY/MM/DD"
        Me.txtTODAY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdALL_SELECT
        '
        Me.cmdALL_SELECT.BackColor = System.Drawing.SystemColors.Control
        Me.cmdALL_SELECT.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdALL_SELECT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdALL_SELECT.Location = New System.Drawing.Point(96, 196)
        Me.cmdALL_SELECT.Name = "cmdALL_SELECT"
        Me.cmdALL_SELECT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdALL_SELECT.Size = New System.Drawing.Size(69, 23)
        Me.cmdALL_SELECT.TabIndex = 33
        Me.cmdALL_SELECT.Text = "全選択"
        Me.cmdALL_SELECT.UseVisualStyleBackColor = False
        '
        'cmdALL_RELEASE
        '
        Me.cmdALL_RELEASE.BackColor = System.Drawing.SystemColors.Control
        Me.cmdALL_RELEASE.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdALL_RELEASE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdALL_RELEASE.Location = New System.Drawing.Point(165, 196)
        Me.cmdALL_RELEASE.Name = "cmdALL_RELEASE"
        Me.cmdALL_RELEASE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdALL_RELEASE.Size = New System.Drawing.Size(69, 23)
        Me.cmdALL_RELEASE.TabIndex = 34
        Me.cmdALL_RELEASE.Text = "全解除"
        Me.cmdALL_RELEASE.UseVisualStyleBackColor = False
        '
        'frmSTY
        '
        Me.frmSTY.BackColor = System.Drawing.SystemColors.Control
        Me.frmSTY.Controls.Add(Me.cmdINPUT)
        Me.frmSTY.Controls.Add(Me.cmdOUTPUT)
        Me.frmSTY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmSTY.Location = New System.Drawing.Point(132, 627)
        Me.frmSTY.Name = "frmSTY"
        Me.frmSTY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmSTY.Size = New System.Drawing.Size(89, 37)
        Me.frmSTY.TabIndex = 57
        Me.frmSTY.TabStop = False
        Me.frmSTY.Text = "年初CSV"
        '
        'cmdINPUT
        '
        Me.cmdINPUT.BackColor = System.Drawing.SystemColors.Control
        Me.cmdINPUT.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdINPUT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdINPUT.Location = New System.Drawing.Point(45, 15)
        Me.cmdINPUT.Name = "cmdINPUT"
        Me.cmdINPUT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdINPUT.Size = New System.Drawing.Size(43, 20)
        Me.cmdINPUT.TabIndex = 54
        Me.cmdINPUT.Text = "取込"
        Me.cmdINPUT.UseVisualStyleBackColor = False
        '
        'cmdOUTPUT
        '
        Me.cmdOUTPUT.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOUTPUT.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOUTPUT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOUTPUT.Location = New System.Drawing.Point(3, 15)
        Me.cmdOUTPUT.Name = "cmdOUTPUT"
        Me.cmdOUTPUT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOUTPUT.Size = New System.Drawing.Size(43, 20)
        Me.cmdOUTPUT.TabIndex = 53
        Me.cmdOUTPUT.Text = "出力"
        Me.cmdOUTPUT.UseVisualStyleBackColor = False
        '
        'lvwMEISAI
        '
        Me.lvwMEISAI.BackColor = System.Drawing.SystemColors.Window
        Me.lvwMEISAI.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.SEL, Me.WARNING, Me.HINCD, Me.HINKTA, Me.JIGKB, Me.ZAIRNK, Me.PRDENDKB, Me.SLSTPKB, Me.TOUZAISU, Me.JYCYUSU, Me.MKMZAISU, Me.MKMJYCYUSU, Me.LMAZKT, Me.LMAAVTS, Me.LMZZAISA, Me.LMZAZM, Me.LMZZKM, Me.LMADAYS, Me.LMSKYDT, Me.MNFDD, Me.HINGRP})
        Me.lvwMEISAI.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lvwMEISAI.GridLines = True
        Me.lvwMEISAI.LabelEdit = True
        Me.lvwMEISAI.LabelWrap = False
        Me.lvwMEISAI.Location = New System.Drawing.Point(16, 224)
        Me.lvwMEISAI.Name = "lvwMEISAI"
        Me.lvwMEISAI.Size = New System.Drawing.Size(984, 395)
        Me.lvwMEISAI.TabIndex = 35
        Me.lvwMEISAI.UseCompatibleStateImageBehavior = False
        Me.lvwMEISAI.View = System.Windows.Forms.View.Details
        '
        'SEL
        '
        Me.SEL.Name = "SEL"
        Me.SEL.Tag = "112"
        Me.SEL.Text = "選"
        Me.SEL.Width = 30
        '
        'WARNING
        '
        Me.WARNING.Name = "WARNING"
        Me.WARNING.Text = "警告年月"
        '
        'HINCD
        '
        Me.HINCD.Name = "HINCD"
        Me.HINCD.Text = "製品ｺｰﾄﾞ"
        '
        'HINKTA
        '
        Me.HINKTA.Name = "HINKTA"
        Me.HINKTA.Text = "型　　　式"
        '
        'JIGKB
        '
        Me.JIGKB.Name = "JIGKB"
        Me.JIGKB.Text = "事業区分"
        '
        'ZAIRNK
        '
        Me.ZAIRNK.Name = "ZAIRNK"
        Me.ZAIRNK.Text = "在庫ﾗﾝｸ"
        '
        'PRDENDKB
        '
        Me.PRDENDKB.Name = "PRDENDKB"
        Me.PRDENDKB.Text = "生産中止"
        Me.PRDENDKB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SLSTPKB
        '
        Me.SLSTPKB.Name = "SLSTPKB"
        Me.SLSTPKB.Text = "販売停止"
        Me.SLSTPKB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TOUZAISU
        '
        Me.TOUZAISU.Name = "TOUZAISU"
        Me.TOUZAISU.Tag = "NUMBER"
        Me.TOUZAISU.Text = "現在庫数"
        Me.TOUZAISU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'JYCYUSU
        '
        Me.JYCYUSU.Name = "JYCYUSU"
        Me.JYCYUSU.Tag = "NUMBER"
        Me.JYCYUSU.Text = "現受注数"
        Me.JYCYUSU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MKMZAISU
        '
        Me.MKMZAISU.Name = "MKMZAISU"
        Me.MKMZAISU.Tag = "NUMBER"
        Me.MKMZAISU.Text = "見込現在庫数"
        Me.MKMZAISU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MKMJYCYUSU
        '
        Me.MKMJYCYUSU.Name = "MKMJYCYUSU"
        Me.MKMJYCYUSU.Tag = "NUMBER"
        Me.MKMJYCYUSU.Text = "見込出庫予定数"
        Me.MKMJYCYUSU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LMAZKT
        '
        Me.LMAZKT.Name = "LMAZKT"
        Me.LMAZKT.Tag = "NUMBER"
        Me.LMAZKT.Text = "在庫月数"
        Me.LMAZKT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LMAAVTS
        '
        Me.LMAAVTS.Name = "LMAAVTS"
        Me.LMAAVTS.Tag = "NUMBER"
        Me.LMAAVTS.Text = "平均出庫数"
        Me.LMAAVTS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LMZZAISA
        '
        Me.LMZZAISA.Name = "LMZZAISA"
        Me.LMZZAISA.Tag = "NUMBER"
        Me.LMZZAISA.Text = "在庫数"
        Me.LMZZAISA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LMZAZM
        '
        Me.LMZAZM.Name = "LMZAZM"
        Me.LMZAZM.Tag = "NUMBER"
        Me.LMZAZM.Text = "安全在庫切れ"
        Me.LMZAZM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LMZZKM
        '
        Me.LMZZKM.Name = "LMZZKM"
        Me.LMZZKM.Tag = "NUMBER"
        Me.LMZZKM.Text = "在庫切れ"
        Me.LMZZKM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LMADAYS
        '
        Me.LMADAYS.Name = "LMADAYS"
        Me.LMADAYS.Tag = "NUMBER"
        Me.LMADAYS.Text = "発注予定数"
        Me.LMADAYS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LMSKYDT
        '
        Me.LMSKYDT.Name = "LMSKYDT"
        Me.LMSKYDT.Tag = "NUMBER"
        Me.LMSKYDT.Text = "締切余日数"
        Me.LMSKYDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MNFDD
        '
        Me.MNFDD.Name = "MNFDD"
        Me.MNFDD.Tag = "NUMBER"
        Me.MNFDD.Text = "発注Ｌ/Ｔ"
        Me.MNFDD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'HINGRP
        '
        Me.HINGRP.Name = "HINGRP"
        Me.HINGRP.Text = "商品群"
        '
        'cmdCSVOUT
        '
        Me.cmdCSVOUT.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCSVOUT.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCSVOUT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCSVOUT.Location = New System.Drawing.Point(16, 625)
        Me.cmdCSVOUT.Name = "cmdCSVOUT"
        Me.cmdCSVOUT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCSVOUT.Size = New System.Drawing.Size(89, 37)
        Me.cmdCSVOUT.TabIndex = 52
        Me.cmdCSVOUT.Text = "検索結果CSV出力"
        Me.cmdCSVOUT.UseVisualStyleBackColor = False
        '
        'cmdSERCH
        '
        Me.cmdSERCH.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSERCH.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSERCH.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSERCH.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSERCH.Location = New System.Drawing.Point(858, 62)
        Me.cmdSERCH.Name = "cmdSERCH"
        Me.cmdSERCH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSERCH.Size = New System.Drawing.Size(137, 67)
        Me.cmdSERCH.TabIndex = 32
        Me.cmdSERCH.Text = "検 索 開 始"
        Me.cmdSERCH.UseVisualStyleBackColor = False
        '
        'frmGROUP
        '
        Me.frmGROUP.BackColor = System.Drawing.SystemColors.Control
        Me.frmGROUP.Controls.Add(Me.optVERSION)
        Me.frmGROUP.Controls.Add(Me.optONLY)
        Me.frmGROUP.Controls.Add(Me.Label5)
        Me.frmGROUP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmGROUP.Location = New System.Drawing.Point(628, 70)
        Me.frmGROUP.Name = "frmGROUP"
        Me.frmGROUP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmGROUP.Size = New System.Drawing.Size(177, 107)
        Me.frmGROUP.TabIndex = 48
        Me.frmGROUP.TabStop = False
        Me.frmGROUP.Text = "グループ"
        '
        'optVERSION
        '
        Me.optVERSION.BackColor = System.Drawing.SystemColors.Control
        Me.optVERSION.Checked = True
        Me.optVERSION.Cursor = System.Windows.Forms.Cursors.Default
        Me.optVERSION.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optVERSION.Location = New System.Drawing.Point(12, 46)
        Me.optVERSION.Name = "optVERSION"
        Me.optVERSION.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optVERSION.Size = New System.Drawing.Size(137, 23)
        Me.optVERSION.TabIndex = 31
        Me.optVERSION.TabStop = True
        Me.optVERSION.Text = "ﾊﾞｰｼﾞｮﾝを集計"
        Me.optVERSION.UseVisualStyleBackColor = False
        '
        'optONLY
        '
        Me.optONLY.BackColor = System.Drawing.SystemColors.Control
        Me.optONLY.Cursor = System.Windows.Forms.Cursors.Default
        Me.optONLY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optONLY.Location = New System.Drawing.Point(12, 20)
        Me.optONLY.Name = "optONLY"
        Me.optONLY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optONLY.Size = New System.Drawing.Size(55, 23)
        Me.optONLY.TabIndex = 30
        Me.optONLY.TabStop = True
        Me.optONLY.Text = "個別"
        Me.optONLY.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(34, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(127, 17)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "(製品ｺｰﾄﾞ指定時限定)"
        '
        'fraORDER
        '
        Me.fraORDER.BackColor = System.Drawing.SystemColors.Control
        Me.fraORDER.Controls.Add(Me.optORDER_ON)
        Me.fraORDER.Controls.Add(Me.optORDER_OFF)
        Me.fraORDER.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraORDER.Location = New System.Drawing.Point(628, 8)
        Me.fraORDER.Name = "fraORDER"
        Me.fraORDER.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraORDER.Size = New System.Drawing.Size(177, 57)
        Me.fraORDER.TabIndex = 47
        Me.fraORDER.TabStop = False
        Me.fraORDER.Text = "受注見込"
        '
        'optORDER_ON
        '
        Me.optORDER_ON.Appearance = System.Windows.Forms.Appearance.Button
        Me.optORDER_ON.BackColor = System.Drawing.SystemColors.Control
        Me.optORDER_ON.Checked = True
        Me.optORDER_ON.Cursor = System.Windows.Forms.Cursors.Default
        Me.optORDER_ON.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optORDER_ON.Location = New System.Drawing.Point(27, 22)
        Me.optORDER_ON.Name = "optORDER_ON"
        Me.optORDER_ON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optORDER_ON.Size = New System.Drawing.Size(67, 23)
        Me.optORDER_ON.TabIndex = 28
        Me.optORDER_ON.TabStop = True
        Me.optORDER_ON.Text = "含む"
        Me.optORDER_ON.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optORDER_ON.UseVisualStyleBackColor = False
        '
        'optORDER_OFF
        '
        Me.optORDER_OFF.Appearance = System.Windows.Forms.Appearance.Button
        Me.optORDER_OFF.BackColor = System.Drawing.SystemColors.Control
        Me.optORDER_OFF.Cursor = System.Windows.Forms.Cursors.Default
        Me.optORDER_OFF.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optORDER_OFF.Location = New System.Drawing.Point(100, 22)
        Me.optORDER_OFF.Name = "optORDER_OFF"
        Me.optORDER_OFF.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optORDER_OFF.Size = New System.Drawing.Size(67, 23)
        Me.optORDER_OFF.TabIndex = 29
        Me.optORDER_OFF.TabStop = True
        Me.optORDER_OFF.Text = "含まない"
        Me.optORDER_OFF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optORDER_OFF.UseVisualStyleBackColor = False
        '
        'frmDISPLAY
        '
        Me.frmDISPLAY.BackColor = System.Drawing.SystemColors.Control
        Me.frmDISPLAY.Controls.Add(Me._txtHINGRP_0)
        Me.frmDISPLAY.Controls.Add(Me._txtHINGRP_1)
        Me.frmDISPLAY.Controls.Add(Me._txtHINGRP_2)
        Me.frmDISPLAY.Controls.Add(Me._txtHINGRP_3)
        Me.frmDISPLAY.Controls.Add(Me._txtHINGRP_4)
        Me.frmDISPLAY.Controls.Add(Me._txtHINGRP_5)
        Me.frmDISPLAY.Controls.Add(Me.txtMNFDD)
        Me.frmDISPLAY.Controls.Add(Me._txtZAIRNK_7)
        Me.frmDISPLAY.Controls.Add(Me._txtZAIRNK_6)
        Me.frmDISPLAY.Controls.Add(Me._txtZAIRNK_5)
        Me.frmDISPLAY.Controls.Add(Me._txtZAIRNK_4)
        Me.frmDISPLAY.Controls.Add(Me._txtZAIRNK_3)
        Me.frmDISPLAY.Controls.Add(Me._txtZAIRNK_2)
        Me.frmDISPLAY.Controls.Add(Me._txtZAIRNK_1)
        Me.frmDISPLAY.Controls.Add(Me._txtZAIRNK_0)
        Me.frmDISPLAY.Controls.Add(Me.txtHINNMA)
        Me.frmDISPLAY.Controls.Add(Me.txtHINCD)
        Me.frmDISPLAY.Controls.Add(Me.Label9)
        Me.frmDISPLAY.Controls.Add(Me.lblLT)
        Me.frmDISPLAY.Controls.Add(Me.lblRANK)
        Me.frmDISPLAY.Controls.Add(Me.lblMODEL)
        Me.frmDISPLAY.Controls.Add(Me.lblHINGRP)
        Me.frmDISPLAY.Controls.Add(Me.lblHINCD)
        Me.frmDISPLAY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmDISPLAY.Location = New System.Drawing.Point(284, 8)
        Me.frmDISPLAY.Name = "frmDISPLAY"
        Me.frmDISPLAY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmDISPLAY.Size = New System.Drawing.Size(337, 171)
        Me.frmDISPLAY.TabIndex = 42
        Me.frmDISPLAY.TabStop = False
        Me.frmDISPLAY.Text = "表示条件"
        '
        '_txtHINGRP_0
        '
        Me._txtHINGRP_0.AcceptsReturn = True
        Me._txtHINGRP_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtHINGRP_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtHINGRP_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHINGRP.SetIndex(Me._txtHINGRP_0, CType(0, Short))
        Me._txtHINGRP_0.Location = New System.Drawing.Point(86, 48)
        Me._txtHINGRP_0.MaxLength = 4
        Me._txtHINGRP_0.Name = "_txtHINGRP_0"
        Me._txtHINGRP_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtHINGRP_0.Size = New System.Drawing.Size(37, 19)
        Me._txtHINGRP_0.TabIndex = 12
        Me._txtHINGRP_0.Text = "XXXX"
        '
        '_txtHINGRP_1
        '
        Me._txtHINGRP_1.AcceptsReturn = True
        Me._txtHINGRP_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtHINGRP_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtHINGRP_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHINGRP.SetIndex(Me._txtHINGRP_1, CType(1, Short))
        Me._txtHINGRP_1.Location = New System.Drawing.Point(126, 48)
        Me._txtHINGRP_1.MaxLength = 4
        Me._txtHINGRP_1.Name = "_txtHINGRP_1"
        Me._txtHINGRP_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtHINGRP_1.Size = New System.Drawing.Size(37, 19)
        Me._txtHINGRP_1.TabIndex = 13
        Me._txtHINGRP_1.Text = "XXXX"
        '
        '_txtHINGRP_2
        '
        Me._txtHINGRP_2.AcceptsReturn = True
        Me._txtHINGRP_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtHINGRP_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtHINGRP_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHINGRP.SetIndex(Me._txtHINGRP_2, CType(2, Short))
        Me._txtHINGRP_2.Location = New System.Drawing.Point(165, 48)
        Me._txtHINGRP_2.MaxLength = 4
        Me._txtHINGRP_2.Name = "_txtHINGRP_2"
        Me._txtHINGRP_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtHINGRP_2.Size = New System.Drawing.Size(37, 19)
        Me._txtHINGRP_2.TabIndex = 14
        Me._txtHINGRP_2.Text = "XXXX"
        '
        '_txtHINGRP_3
        '
        Me._txtHINGRP_3.AcceptsReturn = True
        Me._txtHINGRP_3.BackColor = System.Drawing.SystemColors.Window
        Me._txtHINGRP_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtHINGRP_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHINGRP.SetIndex(Me._txtHINGRP_3, CType(3, Short))
        Me._txtHINGRP_3.Location = New System.Drawing.Point(205, 48)
        Me._txtHINGRP_3.MaxLength = 4
        Me._txtHINGRP_3.Name = "_txtHINGRP_3"
        Me._txtHINGRP_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtHINGRP_3.Size = New System.Drawing.Size(37, 19)
        Me._txtHINGRP_3.TabIndex = 15
        Me._txtHINGRP_3.Text = "XXXX"
        '
        '_txtHINGRP_4
        '
        Me._txtHINGRP_4.AcceptsReturn = True
        Me._txtHINGRP_4.BackColor = System.Drawing.SystemColors.Window
        Me._txtHINGRP_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtHINGRP_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHINGRP.SetIndex(Me._txtHINGRP_4, CType(4, Short))
        Me._txtHINGRP_4.Location = New System.Drawing.Point(244, 48)
        Me._txtHINGRP_4.MaxLength = 4
        Me._txtHINGRP_4.Name = "_txtHINGRP_4"
        Me._txtHINGRP_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtHINGRP_4.Size = New System.Drawing.Size(37, 19)
        Me._txtHINGRP_4.TabIndex = 16
        Me._txtHINGRP_4.Text = "XXXX"
        '
        '_txtHINGRP_5
        '
        Me._txtHINGRP_5.AcceptsReturn = True
        Me._txtHINGRP_5.BackColor = System.Drawing.SystemColors.Window
        Me._txtHINGRP_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtHINGRP_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHINGRP.SetIndex(Me._txtHINGRP_5, CType(5, Short))
        Me._txtHINGRP_5.Location = New System.Drawing.Point(283, 48)
        Me._txtHINGRP_5.MaxLength = 4
        Me._txtHINGRP_5.Name = "_txtHINGRP_5"
        Me._txtHINGRP_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtHINGRP_5.Size = New System.Drawing.Size(37, 19)
        Me._txtHINGRP_5.TabIndex = 17
        Me._txtHINGRP_5.Text = "XXXX"
        '
        'txtMNFDD
        '
        Me.txtMNFDD.AcceptsReturn = True
        Me.txtMNFDD.BackColor = System.Drawing.SystemColors.Window
        Me.txtMNFDD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMNFDD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMNFDD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMNFDD.Location = New System.Drawing.Point(86, 144)
        Me.txtMNFDD.MaxLength = 2
        Me.txtMNFDD.Name = "txtMNFDD"
        Me.txtMNFDD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMNFDD.Size = New System.Drawing.Size(25, 19)
        Me.txtMNFDD.TabIndex = 27
        Me.txtMNFDD.Text = "99"
        Me.txtMNFDD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtZAIRNK_7
        '
        Me._txtZAIRNK_7.AcceptsReturn = True
        Me._txtZAIRNK_7.BackColor = System.Drawing.SystemColors.Window
        Me._txtZAIRNK_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtZAIRNK_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtZAIRNK.SetIndex(Me._txtZAIRNK_7, CType(7, Short))
        Me._txtZAIRNK_7.Location = New System.Drawing.Point(207, 112)
        Me._txtZAIRNK_7.MaxLength = 1
        Me._txtZAIRNK_7.Name = "_txtZAIRNK_7"
        Me._txtZAIRNK_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtZAIRNK_7.Size = New System.Drawing.Size(17, 19)
        Me._txtZAIRNK_7.TabIndex = 26
        Me._txtZAIRNK_7.Text = "X"
        '
        '_txtZAIRNK_6
        '
        Me._txtZAIRNK_6.AcceptsReturn = True
        Me._txtZAIRNK_6.BackColor = System.Drawing.SystemColors.Window
        Me._txtZAIRNK_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtZAIRNK_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtZAIRNK.SetIndex(Me._txtZAIRNK_6, CType(6, Short))
        Me._txtZAIRNK_6.Location = New System.Drawing.Point(189, 112)
        Me._txtZAIRNK_6.MaxLength = 1
        Me._txtZAIRNK_6.Name = "_txtZAIRNK_6"
        Me._txtZAIRNK_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtZAIRNK_6.Size = New System.Drawing.Size(17, 19)
        Me._txtZAIRNK_6.TabIndex = 25
        Me._txtZAIRNK_6.Text = "X"
        '
        '_txtZAIRNK_5
        '
        Me._txtZAIRNK_5.AcceptsReturn = True
        Me._txtZAIRNK_5.BackColor = System.Drawing.SystemColors.Window
        Me._txtZAIRNK_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtZAIRNK_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtZAIRNK.SetIndex(Me._txtZAIRNK_5, CType(5, Short))
        Me._txtZAIRNK_5.Location = New System.Drawing.Point(171, 112)
        Me._txtZAIRNK_5.MaxLength = 1
        Me._txtZAIRNK_5.Name = "_txtZAIRNK_5"
        Me._txtZAIRNK_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtZAIRNK_5.Size = New System.Drawing.Size(17, 19)
        Me._txtZAIRNK_5.TabIndex = 24
        Me._txtZAIRNK_5.Text = "X"
        '
        '_txtZAIRNK_4
        '
        Me._txtZAIRNK_4.AcceptsReturn = True
        Me._txtZAIRNK_4.BackColor = System.Drawing.SystemColors.Window
        Me._txtZAIRNK_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtZAIRNK_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtZAIRNK.SetIndex(Me._txtZAIRNK_4, CType(4, Short))
        Me._txtZAIRNK_4.Location = New System.Drawing.Point(154, 112)
        Me._txtZAIRNK_4.MaxLength = 1
        Me._txtZAIRNK_4.Name = "_txtZAIRNK_4"
        Me._txtZAIRNK_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtZAIRNK_4.Size = New System.Drawing.Size(17, 19)
        Me._txtZAIRNK_4.TabIndex = 23
        Me._txtZAIRNK_4.Text = "X"
        '
        '_txtZAIRNK_3
        '
        Me._txtZAIRNK_3.AcceptsReturn = True
        Me._txtZAIRNK_3.BackColor = System.Drawing.SystemColors.Window
        Me._txtZAIRNK_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtZAIRNK_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtZAIRNK.SetIndex(Me._txtZAIRNK_3, CType(3, Short))
        Me._txtZAIRNK_3.Location = New System.Drawing.Point(137, 112)
        Me._txtZAIRNK_3.MaxLength = 1
        Me._txtZAIRNK_3.Name = "_txtZAIRNK_3"
        Me._txtZAIRNK_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtZAIRNK_3.Size = New System.Drawing.Size(17, 19)
        Me._txtZAIRNK_3.TabIndex = 22
        Me._txtZAIRNK_3.Text = "X"
        '
        '_txtZAIRNK_2
        '
        Me._txtZAIRNK_2.AcceptsReturn = True
        Me._txtZAIRNK_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtZAIRNK_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtZAIRNK_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtZAIRNK.SetIndex(Me._txtZAIRNK_2, CType(2, Short))
        Me._txtZAIRNK_2.Location = New System.Drawing.Point(120, 112)
        Me._txtZAIRNK_2.MaxLength = 1
        Me._txtZAIRNK_2.Name = "_txtZAIRNK_2"
        Me._txtZAIRNK_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtZAIRNK_2.Size = New System.Drawing.Size(17, 19)
        Me._txtZAIRNK_2.TabIndex = 21
        Me._txtZAIRNK_2.Text = "X"
        '
        '_txtZAIRNK_1
        '
        Me._txtZAIRNK_1.AcceptsReturn = True
        Me._txtZAIRNK_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtZAIRNK_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtZAIRNK_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtZAIRNK.SetIndex(Me._txtZAIRNK_1, CType(1, Short))
        Me._txtZAIRNK_1.Location = New System.Drawing.Point(103, 112)
        Me._txtZAIRNK_1.MaxLength = 1
        Me._txtZAIRNK_1.Name = "_txtZAIRNK_1"
        Me._txtZAIRNK_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtZAIRNK_1.Size = New System.Drawing.Size(17, 19)
        Me._txtZAIRNK_1.TabIndex = 20
        Me._txtZAIRNK_1.Text = "X"
        '
        '_txtZAIRNK_0
        '
        Me._txtZAIRNK_0.AcceptsReturn = True
        Me._txtZAIRNK_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtZAIRNK_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtZAIRNK_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtZAIRNK.SetIndex(Me._txtZAIRNK_0, CType(0, Short))
        Me._txtZAIRNK_0.Location = New System.Drawing.Point(86, 112)
        Me._txtZAIRNK_0.MaxLength = 1
        Me._txtZAIRNK_0.Name = "_txtZAIRNK_0"
        Me._txtZAIRNK_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtZAIRNK_0.Size = New System.Drawing.Size(17, 19)
        Me._txtZAIRNK_0.TabIndex = 19
        Me._txtZAIRNK_0.Text = "X"
        '
        'txtHINNMA
        '
        Me.txtHINNMA.AcceptsReturn = True
        Me.txtHINNMA.BackColor = System.Drawing.SystemColors.Window
        Me.txtHINNMA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHINNMA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHINNMA.Location = New System.Drawing.Point(86, 81)
        Me.txtHINNMA.MaxLength = 30
        Me.txtHINNMA.Name = "txtHINNMA"
        Me.txtHINNMA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHINNMA.Size = New System.Drawing.Size(217, 19)
        Me.txtHINNMA.TabIndex = 18
        Me.txtHINNMA.Text = "XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3"
        '
        'txtHINCD
        '
        Me.txtHINCD.AcceptsReturn = True
        Me.txtHINCD.BackColor = System.Drawing.SystemColors.Window
        Me.txtHINCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHINCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHINCD.Location = New System.Drawing.Point(86, 18)
        Me.txtHINCD.MaxLength = 10
        Me.txtHINCD.Name = "txtHINCD"
        Me.txtHINCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHINCD.Size = New System.Drawing.Size(89, 19)
        Me.txtHINCD.TabIndex = 11
        Me.txtHINCD.Text = "XXXXXXX8"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(120, 148)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(63, 17)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "週以上"
        '
        'lblLT
        '
        Me.lblLT.BackColor = System.Drawing.SystemColors.Control
        Me.lblLT.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLT.Location = New System.Drawing.Point(7, 148)
        Me.lblLT.Name = "lblLT"
        Me.lblLT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLT.Size = New System.Drawing.Size(74, 17)
        Me.lblLT.TabIndex = 62
        Me.lblLT.Text = "発注Ｌ／Ｔ"
        Me.lblLT.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblRANK
        '
        Me.lblRANK.BackColor = System.Drawing.SystemColors.Control
        Me.lblRANK.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblRANK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRANK.Location = New System.Drawing.Point(18, 115)
        Me.lblRANK.Name = "lblRANK"
        Me.lblRANK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblRANK.Size = New System.Drawing.Size(63, 17)
        Me.lblRANK.TabIndex = 46
        Me.lblRANK.Text = "在庫ランク"
        Me.lblRANK.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMODEL
        '
        Me.lblMODEL.BackColor = System.Drawing.SystemColors.Control
        Me.lblMODEL.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMODEL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMODEL.Location = New System.Drawing.Point(18, 84)
        Me.lblMODEL.Name = "lblMODEL"
        Me.lblMODEL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMODEL.Size = New System.Drawing.Size(63, 17)
        Me.lblMODEL.TabIndex = 45
        Me.lblMODEL.Text = "型式"
        Me.lblMODEL.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblHINGRP
        '
        Me.lblHINGRP.BackColor = System.Drawing.SystemColors.Control
        Me.lblHINGRP.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHINGRP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHINGRP.Location = New System.Drawing.Point(34, 52)
        Me.lblHINGRP.Name = "lblHINGRP"
        Me.lblHINGRP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHINGRP.Size = New System.Drawing.Size(45, 17)
        Me.lblHINGRP.TabIndex = 44
        Me.lblHINGRP.Text = "商品群"
        Me.lblHINGRP.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblHINCD
        '
        Me.lblHINCD.BackColor = System.Drawing.SystemColors.Control
        Me.lblHINCD.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHINCD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHINCD.Location = New System.Drawing.Point(20, 22)
        Me.lblHINCD.Name = "lblHINCD"
        Me.lblHINCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHINCD.Size = New System.Drawing.Size(61, 17)
        Me.lblHINCD.TabIndex = 43
        Me.lblHINCD.Text = "製品コード"
        Me.lblHINCD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'fraWARNING
        '
        Me.fraWARNING.BackColor = System.Drawing.SystemColors.Control
        Me.fraWARNING.Controls.Add(Me.fraSTOCK)
        Me.fraWARNING.Controls.Add(Me.fraCARRIES)
        Me.fraWARNING.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraWARNING.Location = New System.Drawing.Point(4, 8)
        Me.fraWARNING.Name = "fraWARNING"
        Me.fraWARNING.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraWARNING.Size = New System.Drawing.Size(271, 171)
        Me.fraWARNING.TabIndex = 36
        Me.fraWARNING.TabStop = False
        Me.fraWARNING.Text = "警告抽出"
        '
        'fraSTOCK
        '
        Me.fraSTOCK.BackColor = System.Drawing.SystemColors.Control
        Me.fraSTOCK.Controls.Add(Me.txtORDER_OMISSION)
        Me.fraSTOCK.Controls.Add(Me.txtSTOCK_MONTH)
        Me.fraSTOCK.Controls.Add(Me.txtSTOCK)
        Me.fraSTOCK.Controls.Add(Me.txtSAFTY_STOCK)
        Me.fraSTOCK.Controls.Add(Me.optORDER_OMISSION)
        Me.fraSTOCK.Controls.Add(Me.optSTOCK_MONTH)
        Me.fraSTOCK.Controls.Add(Me.optSAFTY_STOCK)
        Me.fraSTOCK.Controls.Add(Me.optSTOCK)
        Me.fraSTOCK.Controls.Add(Me.Label4)
        Me.fraSTOCK.Controls.Add(Me.Label3)
        Me.fraSTOCK.Controls.Add(Me.Label2)
        Me.fraSTOCK.Controls.Add(Me.Label1)
        Me.fraSTOCK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraSTOCK.Location = New System.Drawing.Point(16, 50)
        Me.fraSTOCK.Name = "fraSTOCK"
        Me.fraSTOCK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraSTOCK.Size = New System.Drawing.Size(237, 111)
        Me.fraSTOCK.TabIndex = 6
        Me.fraSTOCK.TabStop = False
        '
        'txtORDER_OMISSION
        '
        Me.txtORDER_OMISSION.AcceptsReturn = True
        Me.txtORDER_OMISSION.BackColor = System.Drawing.SystemColors.Window
        Me.txtORDER_OMISSION.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtORDER_OMISSION.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtORDER_OMISSION.Location = New System.Drawing.Point(134, 83)
        Me.txtORDER_OMISSION.MaxLength = 2
        Me.txtORDER_OMISSION.Name = "txtORDER_OMISSION"
        Me.txtORDER_OMISSION.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtORDER_OMISSION.Size = New System.Drawing.Size(37, 19)
        Me.txtORDER_OMISSION.TabIndex = 10
        Me.txtORDER_OMISSION.Tag = "####0;##,##0"
        Me.txtORDER_OMISSION.Text = "99"
        Me.txtORDER_OMISSION.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSTOCK_MONTH
        '
        Me.txtSTOCK_MONTH.AcceptsReturn = True
        Me.txtSTOCK_MONTH.BackColor = System.Drawing.SystemColors.Window
        Me.txtSTOCK_MONTH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSTOCK_MONTH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSTOCK_MONTH.Location = New System.Drawing.Point(134, 60)
        Me.txtSTOCK_MONTH.MaxLength = 4
        Me.txtSTOCK_MONTH.Name = "txtSTOCK_MONTH"
        Me.txtSTOCK_MONTH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSTOCK_MONTH.Size = New System.Drawing.Size(37, 19)
        Me.txtSTOCK_MONTH.TabIndex = 9
        Me.txtSTOCK_MONTH.Tag = "####0;##,##0"
        Me.txtSTOCK_MONTH.Text = "99.9"
        Me.txtSTOCK_MONTH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSTOCK
        '
        Me.txtSTOCK.AcceptsReturn = True
        Me.txtSTOCK.BackColor = System.Drawing.SystemColors.Window
        Me.txtSTOCK.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSTOCK.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSTOCK.Location = New System.Drawing.Point(134, 36)
        Me.txtSTOCK.MaxLength = 2
        Me.txtSTOCK.Name = "txtSTOCK"
        Me.txtSTOCK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSTOCK.Size = New System.Drawing.Size(37, 19)
        Me.txtSTOCK.TabIndex = 8
        Me.txtSTOCK.Tag = "####0;##,##0"
        Me.txtSTOCK.Text = "99"
        Me.txtSTOCK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSAFTY_STOCK
        '
        Me.txtSAFTY_STOCK.AcceptsReturn = True
        Me.txtSAFTY_STOCK.BackColor = System.Drawing.SystemColors.Window
        Me.txtSAFTY_STOCK.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSAFTY_STOCK.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSAFTY_STOCK.Location = New System.Drawing.Point(134, 12)
        Me.txtSAFTY_STOCK.MaxLength = 2
        Me.txtSAFTY_STOCK.Name = "txtSAFTY_STOCK"
        Me.txtSAFTY_STOCK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSAFTY_STOCK.Size = New System.Drawing.Size(37, 19)
        Me.txtSAFTY_STOCK.TabIndex = 7
        Me.txtSAFTY_STOCK.Tag = "####0;##,##0"
        Me.txtSAFTY_STOCK.Text = "99"
        Me.txtSAFTY_STOCK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'optORDER_OMISSION
        '
        Me.optORDER_OMISSION.BackColor = System.Drawing.SystemColors.Control
        Me.optORDER_OMISSION.Cursor = System.Windows.Forms.Cursors.Default
        Me.optORDER_OMISSION.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optORDER_OMISSION.Location = New System.Drawing.Point(18, 84)
        Me.optORDER_OMISSION.Name = "optORDER_OMISSION"
        Me.optORDER_OMISSION.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optORDER_OMISSION.Size = New System.Drawing.Size(99, 15)
        Me.optORDER_OMISSION.TabIndex = 5
        Me.optORDER_OMISSION.TabStop = True
        Me.optORDER_OMISSION.Text = "発注漏れ"
        Me.optORDER_OMISSION.UseVisualStyleBackColor = False
        '
        'optSTOCK_MONTH
        '
        Me.optSTOCK_MONTH.BackColor = System.Drawing.SystemColors.Control
        Me.optSTOCK_MONTH.Cursor = System.Windows.Forms.Cursors.Default
        Me.optSTOCK_MONTH.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optSTOCK_MONTH.Location = New System.Drawing.Point(18, 61)
        Me.optSTOCK_MONTH.Name = "optSTOCK_MONTH"
        Me.optSTOCK_MONTH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optSTOCK_MONTH.Size = New System.Drawing.Size(99, 15)
        Me.optSTOCK_MONTH.TabIndex = 4
        Me.optSTOCK_MONTH.TabStop = True
        Me.optSTOCK_MONTH.Text = "在庫月数"
        Me.optSTOCK_MONTH.UseVisualStyleBackColor = False
        '
        'optSAFTY_STOCK
        '
        Me.optSAFTY_STOCK.BackColor = System.Drawing.SystemColors.Control
        Me.optSAFTY_STOCK.Checked = True
        Me.optSAFTY_STOCK.Cursor = System.Windows.Forms.Cursors.Default
        Me.optSAFTY_STOCK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optSAFTY_STOCK.Location = New System.Drawing.Point(18, 14)
        Me.optSAFTY_STOCK.Name = "optSAFTY_STOCK"
        Me.optSAFTY_STOCK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optSAFTY_STOCK.Size = New System.Drawing.Size(99, 15)
        Me.optSAFTY_STOCK.TabIndex = 2
        Me.optSAFTY_STOCK.TabStop = True
        Me.optSAFTY_STOCK.Text = "安全在庫切れ"
        Me.optSAFTY_STOCK.UseVisualStyleBackColor = False
        '
        'optSTOCK
        '
        Me.optSTOCK.BackColor = System.Drawing.SystemColors.Control
        Me.optSTOCK.Cursor = System.Windows.Forms.Cursors.Default
        Me.optSTOCK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optSTOCK.Location = New System.Drawing.Point(18, 37)
        Me.optSTOCK.Name = "optSTOCK"
        Me.optSTOCK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optSTOCK.Size = New System.Drawing.Size(99, 15)
        Me.optSTOCK.TabIndex = 3
        Me.optSTOCK.TabStop = True
        Me.optSTOCK.Text = "在庫切れ"
        Me.optSTOCK.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(180, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(51, 16)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "日前"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(180, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(51, 14)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "ヶ月以上"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(180, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(51, 14)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "ヶ月以前"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(180, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(51, 14)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "ヶ月以前"
        '
        'fraCARRIES
        '
        Me.fraCARRIES.BackColor = System.Drawing.SystemColors.Control
        Me.fraCARRIES.Controls.Add(Me.optCARRIES_ON)
        Me.fraCARRIES.Controls.Add(Me.optCARRIES_OFF)
        Me.fraCARRIES.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraCARRIES.Location = New System.Drawing.Point(18, 14)
        Me.fraCARRIES.Name = "fraCARRIES"
        Me.fraCARRIES.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraCARRIES.Size = New System.Drawing.Size(163, 35)
        Me.fraCARRIES.TabIndex = 37
        Me.fraCARRIES.TabStop = False
        '
        'optCARRIES_ON
        '
        Me.optCARRIES_ON.Appearance = System.Windows.Forms.Appearance.Button
        Me.optCARRIES_ON.BackColor = System.Drawing.SystemColors.Control
        Me.optCARRIES_ON.Checked = True
        Me.optCARRIES_ON.Cursor = System.Windows.Forms.Cursors.Default
        Me.optCARRIES_ON.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optCARRIES_ON.Location = New System.Drawing.Point(2, 8)
        Me.optCARRIES_ON.Name = "optCARRIES_ON"
        Me.optCARRIES_ON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optCARRIES_ON.Size = New System.Drawing.Size(75, 24)
        Me.optCARRIES_ON.TabIndex = 0
        Me.optCARRIES_ON.TabStop = True
        Me.optCARRIES_ON.Text = "する"
        Me.optCARRIES_ON.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optCARRIES_ON.UseVisualStyleBackColor = False
        '
        'optCARRIES_OFF
        '
        Me.optCARRIES_OFF.Appearance = System.Windows.Forms.Appearance.Button
        Me.optCARRIES_OFF.BackColor = System.Drawing.SystemColors.Control
        Me.optCARRIES_OFF.Cursor = System.Windows.Forms.Cursors.Default
        Me.optCARRIES_OFF.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optCARRIES_OFF.Location = New System.Drawing.Point(88, 8)
        Me.optCARRIES_OFF.Name = "optCARRIES_OFF"
        Me.optCARRIES_OFF.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optCARRIES_OFF.Size = New System.Drawing.Size(75, 24)
        Me.optCARRIES_OFF.TabIndex = 1
        Me.optCARRIES_OFF.TabStop = True
        Me.optCARRIES_OFF.Text = "しない"
        Me.optCARRIES_OFF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optCARRIES_OFF.UseVisualStyleBackColor = False
        '
        'cmdEND
        '
        Me.cmdEND.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEND.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEND.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEND.Location = New System.Drawing.Point(919, 629)
        Me.cmdEND.Name = "cmdEND"
        Me.cmdEND.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEND.Size = New System.Drawing.Size(81, 33)
        Me.cmdEND.TabIndex = 56
        Me.cmdEND.Text = "終了"
        Me.cmdEND.UseVisualStyleBackColor = False
        '
        'cmdDISPLAY
        '
        Me.cmdDISPLAY.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDISPLAY.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDISPLAY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDISPLAY.Location = New System.Drawing.Point(828, 629)
        Me.cmdDISPLAY.Name = "cmdDISPLAY"
        Me.cmdDISPLAY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDISPLAY.Size = New System.Drawing.Size(81, 33)
        Me.cmdDISPLAY.TabIndex = 55
        Me.cmdDISPLAY.Text = "表示"
        Me.cmdDISPLAY.UseVisualStyleBackColor = False
        '
        'lbl処理中
        '
        Me.lbl処理中.AutoSize = True
        Me.lbl処理中.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lbl処理中.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl処理中.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl処理中.ForeColor = System.Drawing.Color.Red
        Me.lbl処理中.Location = New System.Drawing.Point(288, 633)
        Me.lbl処理中.Name = "lbl処理中"
        Me.lbl処理中.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl処理中.Size = New System.Drawing.Size(444, 27)
        Me.lbl処理中.TabIndex = 64
        Me.lbl処理中.Text = "処理中です。 しばらくお待ち下さい。"
        Me.lbl処理中.Visible = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(820, 142)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(55, 17)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "対象件数"
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.SystemColors.Control
        Me.lblCount.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCount.Location = New System.Drawing.Point(944, 144)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCount.Size = New System.Drawing.Size(17, 17)
        Me.lblCount.TabIndex = 60
        Me.lblCount.Text = "件"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(11, 200)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(67, 19)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "検 索 結 果"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Location = New System.Drawing.Point(2, 186)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(1008, 1)
        Me.Line1.TabIndex = 65
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label6.Location = New System.Drawing.Point(880, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(45, 19)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "当日"
        '
        'txtHINGRP
        '
        '
        'txtZAIRNK
        '
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 671)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1014, 22)
        Me.StatusStrip1.TabIndex = 216
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(199, 17)
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(199, 17)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "端末ID"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(199, 17)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Text = "ログインID"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(199, 17)
        Me.ToolStripStatusLabel4.Spring = True
        Me.ToolStripStatusLabel4.Text = "XXXXXXX"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(199, 17)
        Me.ToolStripStatusLabel5.Spring = True
        Me.ToolStripStatusLabel5.Text = "Ver.1.00"
        '
        'HKKET141F
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1014, 693)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txtCount)
        Me.Controls.Add(Me.txtTODAY)
        Me.Controls.Add(Me.cmdALL_SELECT)
        Me.Controls.Add(Me.cmdALL_RELEASE)
        Me.Controls.Add(Me.frmSTY)
        Me.Controls.Add(Me.lvwMEISAI)
        Me.Controls.Add(Me.cmdCSVOUT)
        Me.Controls.Add(Me.cmdSERCH)
        Me.Controls.Add(Me.frmGROUP)
        Me.Controls.Add(Me.fraORDER)
        Me.Controls.Add(Me.frmDISPLAY)
        Me.Controls.Add(Me.fraWARNING)
        Me.Controls.Add(Me.cmdEND)
        Me.Controls.Add(Me.cmdDISPLAY)
        Me.Controls.Add(Me.lbl処理中)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.Label6)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.Name = "HKKET141F"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "販売計画(表示条件)"
        Me.frmSTY.ResumeLayout(False)
        Me.frmGROUP.ResumeLayout(False)
        Me.fraORDER.ResumeLayout(False)
        Me.frmDISPLAY.ResumeLayout(False)
        Me.frmDISPLAY.PerformLayout()
        Me.fraWARNING.ResumeLayout(False)
        Me.fraSTOCK.ResumeLayout(False)
        Me.fraSTOCK.PerformLayout()
        Me.fraCARRIES.ResumeLayout(False)
        CType(Me.txtHINGRP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtZAIRNK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents lvColSEL As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColWARNING As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColHINCD As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColHINKTA As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColJIGKB As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColZAIRNK As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColPRDENDKB As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColSLSTPKB As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColTOUZAISU As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColJYCYUSU As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColMKMZAISU As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColMKMJYCYUSU As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColLMAZKT As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColLMAAVTS As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColLMZZAISA As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColLMZAZM As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColLMZZKM As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColLMADAYS As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColLMSKYDT As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColMNFDD As System.Windows.Forms.ColumnHeader
    Public WithEvents lvColHINGRP As System.Windows.Forms.ColumnHeader
    Public WithEvents SEL As System.Windows.Forms.ColumnHeader
    Public WithEvents WARNING As System.Windows.Forms.ColumnHeader
    Public WithEvents HINCD As System.Windows.Forms.ColumnHeader
    Public WithEvents HINKTA As System.Windows.Forms.ColumnHeader
    Public WithEvents JIGKB As System.Windows.Forms.ColumnHeader
    Public WithEvents ZAIRNK As System.Windows.Forms.ColumnHeader
    Public WithEvents PRDENDKB As System.Windows.Forms.ColumnHeader
    Public WithEvents SLSTPKB As System.Windows.Forms.ColumnHeader
    Public WithEvents TOUZAISU As System.Windows.Forms.ColumnHeader
    Public WithEvents JYCYUSU As System.Windows.Forms.ColumnHeader
    Public WithEvents MKMZAISU As System.Windows.Forms.ColumnHeader
    Public WithEvents MKMJYCYUSU As System.Windows.Forms.ColumnHeader
    Public WithEvents LMAZKT As System.Windows.Forms.ColumnHeader
    Public WithEvents LMAAVTS As System.Windows.Forms.ColumnHeader
    Public WithEvents LMZZAISA As System.Windows.Forms.ColumnHeader
    Public WithEvents LMZAZM As System.Windows.Forms.ColumnHeader
    Public WithEvents LMZZKM As System.Windows.Forms.ColumnHeader
    Public WithEvents LMADAYS As System.Windows.Forms.ColumnHeader
    Public WithEvents LMSKYDT As System.Windows.Forms.ColumnHeader
    Public WithEvents MNFDD As System.Windows.Forms.ColumnHeader
    Public WithEvents HINGRP As System.Windows.Forms.ColumnHeader
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
#End Region
End Class