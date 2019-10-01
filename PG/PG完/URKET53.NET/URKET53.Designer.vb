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
    Public WithEvents cmd_csvout As System.Windows.Forms.Button
    Public WithEvents _img_bklight_1 As System.Windows.Forms.PictureBox
    Public WithEvents _img_bklight_0 As System.Windows.Forms.PictureBox
    'Public WithEvents spd_body As vaSpread
    Public WithEvents cmd_kesidt As System.Windows.Forms.Button
    Public WithEvents CommonDialog1 As OpenFileDialog
    Public WithEvents img_light As System.Windows.Forms.PictureBox
    Public WithEvents txt_message As System.Windows.Forms.TextBox
    Public WithEvents pnl_msg As System.Windows.Forms.Label
    Public WithEvents pnl_tail As System.Windows.Forms.Label
    Public WithEvents cmd_tokseicd As System.Windows.Forms.Button
    Public WithEvents cmd_kaidt_From As System.Windows.Forms.Button
    Public WithEvents cmd_fridt As System.Windows.Forms.Button
    Public WithEvents cmd_tesuryo As System.Windows.Forms.Button
    Public WithEvents cmd_syohi As System.Windows.Forms.Button
    Public WithEvents cmd_zenkesi As System.Windows.Forms.Button
    Public WithEvents cmd_zenkaijo As System.Windows.Forms.Button
    Public WithEvents cmd_saihyoji As System.Windows.Forms.Button
    Public WithEvents pnl_unydt As System.Windows.Forms.Label
    Public WithEvents txt_opeid As System.Windows.Forms.TextBox
    Public WithEvents txt_openm As System.Windows.Forms.TextBox
	Public WithEvents Picture2 As System.Windows.Forms.Panel
	Public WithEvents _opt_sort_2 As System.Windows.Forms.RadioButton
	Public WithEvents _opt_sort_0 As System.Windows.Forms.RadioButton
	Public WithEvents _opt_sort_1 As System.Windows.Forms.RadioButton
	Public WithEvents frm_opt1 As System.Windows.Forms.GroupBox
	Public WithEvents txt_kaidt_To As System.Windows.Forms.TextBox
	Public WithEvents txt_kesikb As System.Windows.Forms.TextBox
	Public WithEvents txt_kesidt As System.Windows.Forms.TextBox
	Public WithEvents txt_tokseicd As System.Windows.Forms.TextBox
	Public WithEvents txt_kaidt_From As System.Windows.Forms.TextBox
	Public WithEvents txt_fridt As System.Windows.Forms.TextBox
    Public WithEvents pnl_kesikb As System.Windows.Forms.Label
    Public WithEvents pnl_condition2 As System.Windows.Forms.Label
    Public WithEvents cmd_kaidt_To As System.Windows.Forms.Button
    Public WithEvents pnl_opeid As System.Windows.Forms.Label
    Public WithEvents txt_tokseinma As System.Windows.Forms.TextBox
    Public WithEvents Picture1 As System.Windows.Forms.Panel
    Public WithEvents _lbl_hytokkesdd_1 As System.Windows.Forms.Label
    Public WithEvents _lbl_hytokkesdd_0 As System.Windows.Forms.Label
    Public WithEvents _lbl_shakbnm_1 As System.Windows.Forms.Label
    Public WithEvents _lbl_shakbnm_0 As System.Windows.Forms.Label
    Public WithEvents lbl_b As System.Windows.Forms.Label
    Public WithEvents pnl_condition1 As System.Windows.Forms.Label
    Public WithEvents txt_urigoukei As System.Windows.Forms.TextBox
    Public WithEvents txt_nyukin As System.Windows.Forms.TextBox
    Public WithEvents txt_nyugoukei As System.Windows.Forms.TextBox
    Public WithEvents txt_kesizan As System.Windows.Forms.TextBox
    Public WithEvents txt_tesuryo As System.Windows.Forms.TextBox
    Public WithEvents txt_syohi As System.Windows.Forms.TextBox
    Public WithEvents pnl_urigoukei As System.Windows.Forms.Label
    Public WithEvents pnl_nyukin As System.Windows.Forms.Label
    Public WithEvents pnl_nyugoukei As System.Windows.Forms.Label
    Public WithEvents pnl_kesizan As System.Windows.Forms.Label
    Public WithEvents lbl_c As System.Windows.Forms.Label
    Public WithEvents pnl_hihyoji As System.Windows.Forms.Label
    Public WithEvents _img_bkunlock_0 As System.Windows.Forms.PictureBox
	Public WithEvents _img_bkunlock_1 As System.Windows.Forms.PictureBox
	Public WithEvents _img_bkshowwnd_1 As System.Windows.Forms.PictureBox
	Public WithEvents _img_bkshowwnd_0 As System.Windows.Forms.PictureBox
	Public WithEvents _img_bkexit_1 As System.Windows.Forms.PictureBox
	Public WithEvents _img_bkexit_0 As System.Windows.Forms.PictureBox
	Public WithEvents _img_bkresist_1 As System.Windows.Forms.PictureBox
	Public WithEvents _img_bkresist_0 As System.Windows.Forms.PictureBox
	Public WithEvents img_bkexit As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents img_bklight As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents img_bkresist As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents img_bkshowwnd As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents img_bkunlock As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents lbl_hytokkesdd As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lbl_shakbnm As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents opt_sort As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更できます。
    'コード エディタを使用して、変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_SSSMAIN))
        Dim Border1 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmd_csvout = New System.Windows.Forms.Button()
        Me._img_bklight_1 = New System.Windows.Forms.PictureBox()
        Me._img_bklight_0 = New System.Windows.Forms.PictureBox()
        Me.cmd_kesidt = New System.Windows.Forms.Button()
        Me.pnl_tail = New System.Windows.Forms.Label()
        Me.img_light = New System.Windows.Forms.PictureBox()
        Me.pnl_msg = New System.Windows.Forms.Label()
        Me.txt_message = New System.Windows.Forms.TextBox()
        Me.CommonDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.cmd_tokseicd = New System.Windows.Forms.Button()
        Me.cmd_kaidt_From = New System.Windows.Forms.Button()
        Me.cmd_fridt = New System.Windows.Forms.Button()
        Me.cmd_tesuryo = New System.Windows.Forms.Button()
        Me.cmd_syohi = New System.Windows.Forms.Button()
        Me.cmd_zenkesi = New System.Windows.Forms.Button()
        Me.cmd_zenkaijo = New System.Windows.Forms.Button()
        Me.cmd_saihyoji = New System.Windows.Forms.Button()
        Me.pnl_unydt = New System.Windows.Forms.Label()
        Me.pnl_condition1 = New System.Windows.Forms.Label()
        Me.Picture2 = New System.Windows.Forms.Panel()
        Me.txt_opeid = New System.Windows.Forms.TextBox()
        Me.txt_openm = New System.Windows.Forms.TextBox()
        Me.frm_opt1 = New System.Windows.Forms.GroupBox()
        Me._opt_sort_2 = New System.Windows.Forms.RadioButton()
        Me._opt_sort_0 = New System.Windows.Forms.RadioButton()
        Me._opt_sort_1 = New System.Windows.Forms.RadioButton()
        Me.txt_kaidt_To = New System.Windows.Forms.TextBox()
        Me.txt_kesikb = New System.Windows.Forms.TextBox()
        Me.txt_kesidt = New System.Windows.Forms.TextBox()
        Me.txt_tokseicd = New System.Windows.Forms.TextBox()
        Me.txt_kaidt_From = New System.Windows.Forms.TextBox()
        Me.txt_fridt = New System.Windows.Forms.TextBox()
        Me.pnl_kesikb = New System.Windows.Forms.Label()
        Me.pnl_condition2 = New System.Windows.Forms.Label()
        Me.cmd_kaidt_To = New System.Windows.Forms.Button()
        Me.pnl_opeid = New System.Windows.Forms.Label()
        Me.Picture1 = New System.Windows.Forms.Panel()
        Me.txt_tokseinma = New System.Windows.Forms.TextBox()
        Me._lbl_hytokkesdd_1 = New System.Windows.Forms.Label()
        Me._lbl_hytokkesdd_0 = New System.Windows.Forms.Label()
        Me._lbl_shakbnm_1 = New System.Windows.Forms.Label()
        Me._lbl_shakbnm_0 = New System.Windows.Forms.Label()
        Me.lbl_b = New System.Windows.Forms.Label()
        Me.pnl_hihyoji = New System.Windows.Forms.Label()
        Me.txt_urigoukei = New System.Windows.Forms.TextBox()
        Me.txt_nyukin = New System.Windows.Forms.TextBox()
        Me.txt_nyugoukei = New System.Windows.Forms.TextBox()
        Me.txt_kesizan = New System.Windows.Forms.TextBox()
        Me.txt_tesuryo = New System.Windows.Forms.TextBox()
        Me.txt_syohi = New System.Windows.Forms.TextBox()
        Me.pnl_urigoukei = New System.Windows.Forms.Label()
        Me.pnl_nyukin = New System.Windows.Forms.Label()
        Me.pnl_nyugoukei = New System.Windows.Forms.Label()
        Me.pnl_kesizan = New System.Windows.Forms.Label()
        Me.lbl_c = New System.Windows.Forms.Label()
        Me._img_bkunlock_0 = New System.Windows.Forms.PictureBox()
        Me._img_bkunlock_1 = New System.Windows.Forms.PictureBox()
        Me._img_bkshowwnd_1 = New System.Windows.Forms.PictureBox()
        Me._img_bkshowwnd_0 = New System.Windows.Forms.PictureBox()
        Me._img_bkexit_1 = New System.Windows.Forms.PictureBox()
        Me._img_bkexit_0 = New System.Windows.Forms.PictureBox()
        Me._img_bkresist_1 = New System.Windows.Forms.PictureBox()
        Me._img_bkresist_0 = New System.Windows.Forms.PictureBox()
        Me.img_bkexit = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.img_bklight = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.img_bkresist = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.img_bkshowwnd = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.img_bkunlock = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.lbl_hytokkesdd = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lbl_shakbnm = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.opt_sort = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(Me.components)
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.spd_body = New GrapeCity.Win.MultiRow.GcMultiRow()
        Me.Template11 = New URKET53.Template1()
        CType(Me._img_bklight_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._img_bklight_0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_tail.SuspendLayout()
        CType(Me.img_light, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_msg.SuspendLayout()
        Me.pnl_condition1.SuspendLayout()
        Me.Picture2.SuspendLayout()
        Me.frm_opt1.SuspendLayout()
        Me.Picture1.SuspendLayout()
        Me.pnl_hihyoji.SuspendLayout()
        CType(Me._img_bkunlock_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._img_bkunlock_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._img_bkshowwnd_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._img_bkshowwnd_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._img_bkexit_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._img_bkexit_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._img_bkresist_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._img_bkresist_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.img_bkexit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.img_bklight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.img_bkresist, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.img_bkshowwnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.img_bkunlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_hytokkesdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_shakbnm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.opt_sort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.spd_body, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmd_csvout
        '
        Me.cmd_csvout.Location = New System.Drawing.Point(857, 201)
        Me.cmd_csvout.Name = "cmd_csvout"
        Me.cmd_csvout.Size = New System.Drawing.Size(88, 25)
        Me.cmd_csvout.TabIndex = 55
        Me.cmd_csvout.TabStop = False
        Me.cmd_csvout.Text = "CSV出力"
        '
        '_img_bklight_1
        '
        Me._img_bklight_1.BackColor = System.Drawing.SystemColors.Control
        Me._img_bklight_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._img_bklight_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._img_bklight_1.Image = CType(resources.GetObject("_img_bklight_1.Image"), System.Drawing.Image)
        Me.img_bklight.SetIndex(Me._img_bklight_1, CType(1, Short))
        Me._img_bklight_1.Location = New System.Drawing.Point(39, 676)
        Me._img_bklight_1.Name = "_img_bklight_1"
        Me._img_bklight_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._img_bklight_1.Size = New System.Drawing.Size(20, 22)
        Me._img_bklight_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me._img_bklight_1.TabIndex = 38
        Me._img_bklight_1.TabStop = False
        '
        '_img_bklight_0
        '
        Me._img_bklight_0.BackColor = System.Drawing.SystemColors.Control
        Me._img_bklight_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._img_bklight_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._img_bklight_0.Image = CType(resources.GetObject("_img_bklight_0.Image"), System.Drawing.Image)
        Me.img_bklight.SetIndex(Me._img_bklight_0, CType(0, Short))
        Me._img_bklight_0.Location = New System.Drawing.Point(15, 676)
        Me._img_bklight_0.Name = "_img_bklight_0"
        Me._img_bklight_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._img_bklight_0.Size = New System.Drawing.Size(20, 22)
        Me._img_bklight_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me._img_bklight_0.TabIndex = 37
        Me._img_bklight_0.TabStop = False
        '
        'cmd_kesidt
        '
        Me.cmd_kesidt.Location = New System.Drawing.Point(21, 43)
        Me.cmd_kesidt.Name = "cmd_kesidt"
        Me.cmd_kesidt.Size = New System.Drawing.Size(113, 22)
        Me.cmd_kesidt.TabIndex = 10
        Me.cmd_kesidt.TabStop = False
        Me.cmd_kesidt.Text = "*消込日    "
        '
        'pnl_tail
        '
        Me.pnl_tail.Controls.Add(Me.img_light)
        Me.pnl_tail.Controls.Add(Me.pnl_msg)
        Me.pnl_tail.Location = New System.Drawing.Point(0, 622)
        Me.pnl_tail.Name = "pnl_tail"
        Me.pnl_tail.Size = New System.Drawing.Size(969, 49)
        Me.pnl_tail.TabIndex = 8
        '
        'img_light
        '
        Me.img_light.BackColor = System.Drawing.SystemColors.Control
        Me.img_light.Cursor = System.Windows.Forms.Cursors.Default
        Me.img_light.ForeColor = System.Drawing.SystemColors.ControlText
        Me.img_light.Image = CType(resources.GetObject("img_light.Image"), System.Drawing.Image)
        Me.img_light.Location = New System.Drawing.Point(10, 9)
        Me.img_light.Name = "img_light"
        Me.img_light.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.img_light.Size = New System.Drawing.Size(20, 22)
        Me.img_light.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.img_light.TabIndex = 23
        Me.img_light.TabStop = False
        Me.img_light.Visible = False
        '
        'pnl_msg
        '
        Me.pnl_msg.Controls.Add(Me.txt_message)
        Me.pnl_msg.Enabled = False
        Me.pnl_msg.Location = New System.Drawing.Point(40, 9)
        Me.pnl_msg.Name = "pnl_msg"
        Me.pnl_msg.Size = New System.Drawing.Size(832, 31)
        Me.pnl_msg.TabIndex = 22
        '
        'txt_message
        '
        Me.txt_message.AcceptsReturn = True
        Me.txt_message.BackColor = System.Drawing.SystemColors.Control
        Me.txt_message.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_message.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_message.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_message.Location = New System.Drawing.Point(7, 6)
        Me.txt_message.MaxLength = 0
        Me.txt_message.Name = "txt_message"
        Me.txt_message.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_message.Size = New System.Drawing.Size(812, 13)
        Me.txt_message.TabIndex = 24
        Me.txt_message.TabStop = False
        Me.txt_message.Text = "エラーやプロンプトのメッセージが出力されるところです。"
        Me.txt_message.Visible = False
        '
        'cmd_tokseicd
        '
        Me.cmd_tokseicd.Location = New System.Drawing.Point(21, 64)
        Me.cmd_tokseicd.Name = "cmd_tokseicd"
        Me.cmd_tokseicd.Size = New System.Drawing.Size(113, 22)
        Me.cmd_tokseicd.TabIndex = 12
        Me.cmd_tokseicd.TabStop = False
        Me.cmd_tokseicd.Text = "*請求先    "
        '
        'cmd_kaidt_From
        '
        Me.cmd_kaidt_From.Location = New System.Drawing.Point(21, 85)
        Me.cmd_kaidt_From.Name = "cmd_kaidt_From"
        Me.cmd_kaidt_From.Size = New System.Drawing.Size(113, 22)
        Me.cmd_kaidt_From.TabIndex = 13
        Me.cmd_kaidt_From.TabStop = False
        Me.cmd_kaidt_From.Text = " 売上日(開始)"
        '
        'cmd_fridt
        '
        Me.cmd_fridt.Location = New System.Drawing.Point(21, 134)
        Me.cmd_fridt.Name = "cmd_fridt"
        Me.cmd_fridt.Size = New System.Drawing.Size(113, 22)
        Me.cmd_fridt.TabIndex = 14
        Me.cmd_fridt.TabStop = False
        Me.cmd_fridt.Text = "振込期日 "
        '
        'cmd_tesuryo
        '
        Me.cmd_tesuryo.Location = New System.Drawing.Point(239, 178)
        Me.cmd_tesuryo.Name = "cmd_tesuryo"
        Me.cmd_tesuryo.Size = New System.Drawing.Size(94, 22)
        Me.cmd_tesuryo.TabIndex = 15
        Me.cmd_tesuryo.TabStop = False
        Me.cmd_tesuryo.Text = "手数料"
        '
        'cmd_syohi
        '
        Me.cmd_syohi.Location = New System.Drawing.Point(332, 178)
        Me.cmd_syohi.Name = "cmd_syohi"
        Me.cmd_syohi.Size = New System.Drawing.Size(94, 22)
        Me.cmd_syohi.TabIndex = 16
        Me.cmd_syohi.TabStop = False
        Me.cmd_syohi.Text = "消費税差額"
        '
        'cmd_zenkesi
        '
        Me.cmd_zenkesi.Location = New System.Drawing.Point(755, 178)
        Me.cmd_zenkesi.Name = "cmd_zenkesi"
        Me.cmd_zenkesi.Size = New System.Drawing.Size(88, 22)
        Me.cmd_zenkesi.TabIndex = 17
        Me.cmd_zenkesi.TabStop = False
        Me.cmd_zenkesi.Text = "全消込"
        '
        'cmd_zenkaijo
        '
        Me.cmd_zenkaijo.Location = New System.Drawing.Point(662, 178)
        Me.cmd_zenkaijo.Name = "cmd_zenkaijo"
        Me.cmd_zenkaijo.Size = New System.Drawing.Size(88, 22)
        Me.cmd_zenkaijo.TabIndex = 18
        Me.cmd_zenkaijo.TabStop = False
        Me.cmd_zenkaijo.Text = "全解除"
        '
        'cmd_saihyoji
        '
        Me.cmd_saihyoji.Location = New System.Drawing.Point(857, 178)
        Me.cmd_saihyoji.Name = "cmd_saihyoji"
        Me.cmd_saihyoji.Size = New System.Drawing.Size(88, 22)
        Me.cmd_saihyoji.TabIndex = 19
        Me.cmd_saihyoji.TabStop = False
        Me.cmd_saihyoji.Text = "再表示"
        '
        'pnl_unydt
        '
        Me.pnl_unydt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_unydt.Location = New System.Drawing.Point(835, 7)
        Me.pnl_unydt.Name = "pnl_unydt"
        Me.pnl_unydt.Size = New System.Drawing.Size(112, 22)
        Me.pnl_unydt.TabIndex = 21
        Me.pnl_unydt.Text = "YYYY/MM/DD"
        Me.pnl_unydt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnl_condition1
        '
        Me.pnl_condition1.Controls.Add(Me.Picture2)
        Me.pnl_condition1.Controls.Add(Me.frm_opt1)
        Me.pnl_condition1.Controls.Add(Me.txt_kaidt_To)
        Me.pnl_condition1.Controls.Add(Me.txt_kesikb)
        Me.pnl_condition1.Controls.Add(Me.txt_kesidt)
        Me.pnl_condition1.Controls.Add(Me.txt_tokseicd)
        Me.pnl_condition1.Controls.Add(Me.txt_kaidt_From)
        Me.pnl_condition1.Controls.Add(Me.txt_fridt)
        Me.pnl_condition1.Controls.Add(Me.pnl_kesikb)
        Me.pnl_condition1.Controls.Add(Me.pnl_condition2)
        Me.pnl_condition1.Controls.Add(Me.cmd_kaidt_To)
        Me.pnl_condition1.Controls.Add(Me.pnl_opeid)
        Me.pnl_condition1.Controls.Add(Me.Picture1)
        Me.pnl_condition1.Controls.Add(Me._lbl_hytokkesdd_1)
        Me.pnl_condition1.Controls.Add(Me._lbl_hytokkesdd_0)
        Me.pnl_condition1.Controls.Add(Me._lbl_shakbnm_1)
        Me.pnl_condition1.Controls.Add(Me._lbl_shakbnm_0)
        Me.pnl_condition1.Controls.Add(Me.lbl_b)
        Me.pnl_condition1.Location = New System.Drawing.Point(4, 38)
        Me.pnl_condition1.Name = "pnl_condition1"
        Me.pnl_condition1.Size = New System.Drawing.Size(954, 124)
        Me.pnl_condition1.TabIndex = 39
        Me.pnl_condition1.Text = "条件用１"
        '
        'Picture2
        '
        Me.Picture2.BackColor = System.Drawing.SystemColors.Control
        Me.Picture2.Controls.Add(Me.txt_opeid)
        Me.Picture2.Controls.Add(Me.txt_openm)
        Me.Picture2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture2.Enabled = False
        Me.Picture2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture2.Location = New System.Drawing.Point(737, 5)
        Me.Picture2.Name = "Picture2"
        Me.Picture2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture2.Size = New System.Drawing.Size(212, 27)
        Me.Picture2.TabIndex = 52
        Me.Picture2.TabStop = True
        '
        'txt_opeid
        '
        Me.txt_opeid.AcceptsReturn = True
        Me.txt_opeid.BackColor = System.Drawing.SystemColors.Control
        Me.txt_opeid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_opeid.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_opeid.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_opeid.Location = New System.Drawing.Point(0, 0)
        Me.txt_opeid.MaxLength = 0
        Me.txt_opeid.Name = "txt_opeid"
        Me.txt_opeid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_opeid.Size = New System.Drawing.Size(61, 20)
        Me.txt_opeid.TabIndex = 54
        Me.txt_opeid.TabStop = False
        Me.txt_opeid.Text = "XXXXXXX8"
        '
        'txt_openm
        '
        Me.txt_openm.AcceptsReturn = True
        Me.txt_openm.BackColor = System.Drawing.SystemColors.Control
        Me.txt_openm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_openm.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_openm.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_openm.Location = New System.Drawing.Point(60, 0)
        Me.txt_openm.MaxLength = 0
        Me.txt_openm.Name = "txt_openm"
        Me.txt_openm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_openm.Size = New System.Drawing.Size(148, 20)
        Me.txt_openm.TabIndex = 53
        Me.txt_openm.TabStop = False
        Me.txt_openm.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'frm_opt1
        '
        Me.frm_opt1.BackColor = System.Drawing.SystemColors.Control
        Me.frm_opt1.Controls.Add(Me._opt_sort_2)
        Me.frm_opt1.Controls.Add(Me._opt_sort_0)
        Me.frm_opt1.Controls.Add(Me._opt_sort_1)
        Me.frm_opt1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frm_opt1.Location = New System.Drawing.Point(646, 41)
        Me.frm_opt1.Name = "frm_opt1"
        Me.frm_opt1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frm_opt1.Size = New System.Drawing.Size(304, 44)
        Me.frm_opt1.TabIndex = 44
        Me.frm_opt1.TabStop = False
        Me.frm_opt1.Text = "ｿｰﾄ条件"
        '
        '_opt_sort_2
        '
        Me._opt_sort_2.BackColor = System.Drawing.SystemColors.Control
        Me._opt_sort_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._opt_sort_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.opt_sort.SetIndex(Me._opt_sort_2, CType(2, Short))
        Me._opt_sort_2.Location = New System.Drawing.Point(186, 17)
        Me._opt_sort_2.Name = "_opt_sort_2"
        Me._opt_sort_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._opt_sort_2.Size = New System.Drawing.Size(106, 18)
        Me._opt_sort_2.TabIndex = 11
        Me._opt_sort_2.Text = "客先注文番号"
        Me._opt_sort_2.UseVisualStyleBackColor = False
        '
        '_opt_sort_0
        '
        Me._opt_sort_0.BackColor = System.Drawing.SystemColors.Control
        Me._opt_sort_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._opt_sort_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.opt_sort.SetIndex(Me._opt_sort_0, CType(0, Short))
        Me._opt_sort_0.Location = New System.Drawing.Point(17, 17)
        Me._opt_sort_0.Name = "_opt_sort_0"
        Me._opt_sort_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._opt_sort_0.Size = New System.Drawing.Size(80, 18)
        Me._opt_sort_0.TabIndex = 7
        Me._opt_sort_0.Text = "売上日"
        Me._opt_sort_0.UseVisualStyleBackColor = False
        '
        '_opt_sort_1
        '
        Me._opt_sort_1.BackColor = System.Drawing.SystemColors.Control
        Me._opt_sort_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._opt_sort_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.opt_sort.SetIndex(Me._opt_sort_1, CType(1, Short))
        Me._opt_sort_1.Location = New System.Drawing.Point(99, 17)
        Me._opt_sort_1.Name = "_opt_sort_1"
        Me._opt_sort_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._opt_sort_1.Size = New System.Drawing.Size(84, 18)
        Me._opt_sort_1.TabIndex = 9
        Me._opt_sort_1.Text = "受注番号"
        Me._opt_sort_1.UseVisualStyleBackColor = False
        '
        'txt_kaidt_To
        '
        Me.txt_kaidt_To.AcceptsReturn = True
        Me.txt_kaidt_To.BackColor = System.Drawing.SystemColors.Window
        Me.txt_kaidt_To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_kaidt_To.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_kaidt_To.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_kaidt_To.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_kaidt_To.Location = New System.Drawing.Point(326, 48)
        Me.txt_kaidt_To.MaxLength = 10
        Me.txt_kaidt_To.Name = "txt_kaidt_To"
        Me.txt_kaidt_To.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_kaidt_To.Size = New System.Drawing.Size(81, 20)
        Me.txt_kaidt_To.TabIndex = 3
        Me.txt_kaidt_To.Text = "YYYY/MM/DD"
        '
        'txt_kesikb
        '
        Me.txt_kesikb.AcceptsReturn = True
        Me.txt_kesikb.BackColor = System.Drawing.SystemColors.Window
        Me.txt_kesikb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_kesikb.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_kesikb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_kesikb.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_kesikb.Location = New System.Drawing.Point(132, 70)
        Me.txt_kesikb.MaxLength = 1
        Me.txt_kesikb.Name = "txt_kesikb"
        Me.txt_kesikb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_kesikb.Size = New System.Drawing.Size(19, 20)
        Me.txt_kesikb.TabIndex = 4
        Me.txt_kesikb.Text = "9"
        '
        'txt_kesidt
        '
        Me.txt_kesidt.AcceptsReturn = True
        Me.txt_kesidt.BackColor = System.Drawing.SystemColors.Window
        Me.txt_kesidt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_kesidt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_kesidt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_kesidt.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_kesidt.Location = New System.Drawing.Point(130, 6)
        Me.txt_kesidt.MaxLength = 10
        Me.txt_kesidt.Name = "txt_kesidt"
        Me.txt_kesidt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_kesidt.Size = New System.Drawing.Size(81, 20)
        Me.txt_kesidt.TabIndex = 0
        Me.txt_kesidt.Text = "YYYY/MM/DD"
        '
        'txt_tokseicd
        '
        Me.txt_tokseicd.AcceptsReturn = True
        Me.txt_tokseicd.BackColor = System.Drawing.SystemColors.Window
        Me.txt_tokseicd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tokseicd.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_tokseicd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_tokseicd.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_tokseicd.Location = New System.Drawing.Point(130, 27)
        Me.txt_tokseicd.MaxLength = 5
        Me.txt_tokseicd.Name = "txt_tokseicd"
        Me.txt_tokseicd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_tokseicd.Size = New System.Drawing.Size(81, 20)
        Me.txt_tokseicd.TabIndex = 1
        Me.txt_tokseicd.Text = "XXXX5"
        '
        'txt_kaidt_From
        '
        Me.txt_kaidt_From.AcceptsReturn = True
        Me.txt_kaidt_From.BackColor = System.Drawing.SystemColors.Window
        Me.txt_kaidt_From.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_kaidt_From.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_kaidt_From.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_kaidt_From.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_kaidt_From.Location = New System.Drawing.Point(130, 48)
        Me.txt_kaidt_From.MaxLength = 10
        Me.txt_kaidt_From.Name = "txt_kaidt_From"
        Me.txt_kaidt_From.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_kaidt_From.Size = New System.Drawing.Size(81, 20)
        Me.txt_kaidt_From.TabIndex = 2
        Me.txt_kaidt_From.Text = "YYYY/MM/DD"
        '
        'txt_fridt
        '
        Me.txt_fridt.AcceptsReturn = True
        Me.txt_fridt.BackColor = System.Drawing.SystemColors.Window
        Me.txt_fridt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fridt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_fridt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_fridt.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_fridt.Location = New System.Drawing.Point(131, 97)
        Me.txt_fridt.MaxLength = 10
        Me.txt_fridt.Name = "txt_fridt"
        Me.txt_fridt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_fridt.Size = New System.Drawing.Size(81, 20)
        Me.txt_fridt.TabIndex = 5
        Me.txt_fridt.Text = "YYYY/MM/DD"
        '
        'pnl_kesikb
        '
        Me.pnl_kesikb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_kesikb.Location = New System.Drawing.Point(18, 69)
        Me.pnl_kesikb.Name = "pnl_kesikb"
        Me.pnl_kesikb.Size = New System.Drawing.Size(113, 22)
        Me.pnl_kesikb.TabIndex = 40
        Me.pnl_kesikb.Text = "消込済ﾃﾞｰﾀ表示"
        Me.pnl_kesikb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnl_condition2
        '
        Me.pnl_condition2.Location = New System.Drawing.Point(128, 68)
        Me.pnl_condition2.Name = "pnl_condition2"
        Me.pnl_condition2.Size = New System.Drawing.Size(30, 32)
        Me.pnl_condition2.TabIndex = 41
        Me.pnl_condition2.Text = "条件用２"
        '
        'cmd_kaidt_To
        '
        Me.cmd_kaidt_To.Location = New System.Drawing.Point(212, 47)
        Me.cmd_kaidt_To.Name = "cmd_kaidt_To"
        Me.cmd_kaidt_To.Size = New System.Drawing.Size(113, 22)
        Me.cmd_kaidt_To.TabIndex = 43
        Me.cmd_kaidt_To.TabStop = False
        Me.cmd_kaidt_To.Text = "*売上日(終了)"
        '
        'pnl_opeid
        '
        Me.pnl_opeid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_opeid.Location = New System.Drawing.Point(654, 5)
        Me.pnl_opeid.Name = "pnl_opeid"
        Me.pnl_opeid.Size = New System.Drawing.Size(84, 20)
        Me.pnl_opeid.TabIndex = 45
        Me.pnl_opeid.Text = "入力担当者"
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Control
        Me.Picture1.Controls.Add(Me.txt_tokseinma)
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.Enabled = False
        Me.Picture1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture1.Location = New System.Drawing.Point(209, 26)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(436, 27)
        Me.Picture1.TabIndex = 50
        Me.Picture1.TabStop = True
        '
        'txt_tokseinma
        '
        Me.txt_tokseinma.AcceptsReturn = True
        Me.txt_tokseinma.BackColor = System.Drawing.SystemColors.Control
        Me.txt_tokseinma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tokseinma.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_tokseinma.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_tokseinma.Location = New System.Drawing.Point(3, 1)
        Me.txt_tokseinma.MaxLength = 0
        Me.txt_tokseinma.Name = "txt_tokseinma"
        Me.txt_tokseinma.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_tokseinma.Size = New System.Drawing.Size(431, 20)
        Me.txt_tokseinma.TabIndex = 51
        Me.txt_tokseinma.TabStop = False
        Me.txt_tokseinma.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5MMMMMMMMM6"
        '
        '_lbl_hytokkesdd_1
        '
        Me._lbl_hytokkesdd_1.BackColor = System.Drawing.Color.Transparent
        Me._lbl_hytokkesdd_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_hytokkesdd_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_hytokkesdd.SetIndex(Me._lbl_hytokkesdd_1, CType(1, Short))
        Me._lbl_hytokkesdd_1.Location = New System.Drawing.Point(751, 109)
        Me._lbl_hytokkesdd_1.Name = "_lbl_hytokkesdd_1"
        Me._lbl_hytokkesdd_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_hytokkesdd_1.Size = New System.Drawing.Size(133, 28)
        Me._lbl_hytokkesdd_1.TabIndex = 49
        Me._lbl_hytokkesdd_1.Text = "末日"
        '
        '_lbl_hytokkesdd_0
        '
        Me._lbl_hytokkesdd_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl_hytokkesdd_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_hytokkesdd_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_hytokkesdd.SetIndex(Me._lbl_hytokkesdd_0, CType(0, Short))
        Me._lbl_hytokkesdd_0.Location = New System.Drawing.Point(684, 110)
        Me._lbl_hytokkesdd_0.Name = "_lbl_hytokkesdd_0"
        Me._lbl_hytokkesdd_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_hytokkesdd_0.Size = New System.Drawing.Size(133, 28)
        Me._lbl_hytokkesdd_0.TabIndex = 48
        Me._lbl_hytokkesdd_0.Text = "回収日  :"
        '
        '_lbl_shakbnm_1
        '
        Me._lbl_shakbnm_1.BackColor = System.Drawing.Color.Transparent
        Me._lbl_shakbnm_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_shakbnm_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_shakbnm.SetIndex(Me._lbl_shakbnm_1, CType(1, Short))
        Me._lbl_shakbnm_1.Location = New System.Drawing.Point(750, 92)
        Me._lbl_shakbnm_1.Name = "_lbl_shakbnm_1"
        Me._lbl_shakbnm_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_shakbnm_1.Size = New System.Drawing.Size(200, 28)
        Me._lbl_shakbnm_1.TabIndex = 47
        Me._lbl_shakbnm_1.Text = "振込または手形"
        '
        '_lbl_shakbnm_0
        '
        Me._lbl_shakbnm_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl_shakbnm_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_shakbnm_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_shakbnm.SetIndex(Me._lbl_shakbnm_0, CType(0, Short))
        Me._lbl_shakbnm_0.Location = New System.Drawing.Point(684, 92)
        Me._lbl_shakbnm_0.Name = "_lbl_shakbnm_0"
        Me._lbl_shakbnm_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_shakbnm_0.Size = New System.Drawing.Size(200, 28)
        Me._lbl_shakbnm_0.TabIndex = 46
        Me._lbl_shakbnm_0.Text = "支払条件:"
        '
        'lbl_b
        '
        Me.lbl_b.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_b.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_b.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_b.Location = New System.Drawing.Point(157, 73)
        Me.lbl_b.Name = "lbl_b"
        Me.lbl_b.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_b.Size = New System.Drawing.Size(190, 20)
        Me.lbl_b.TabIndex = 42
        Me.lbl_b.Text = "1:表示しない  9:表示する"
        '
        'pnl_hihyoji
        '
        Me.pnl_hihyoji.Controls.Add(Me.txt_urigoukei)
        Me.pnl_hihyoji.Controls.Add(Me.txt_nyukin)
        Me.pnl_hihyoji.Controls.Add(Me.txt_nyugoukei)
        Me.pnl_hihyoji.Controls.Add(Me.txt_kesizan)
        Me.pnl_hihyoji.Controls.Add(Me.txt_tesuryo)
        Me.pnl_hihyoji.Controls.Add(Me.txt_syohi)
        Me.pnl_hihyoji.Controls.Add(Me.pnl_urigoukei)
        Me.pnl_hihyoji.Controls.Add(Me.pnl_nyukin)
        Me.pnl_hihyoji.Controls.Add(Me.pnl_nyugoukei)
        Me.pnl_hihyoji.Controls.Add(Me.pnl_kesizan)
        Me.pnl_hihyoji.Controls.Add(Me.lbl_c)
        Me.pnl_hihyoji.Enabled = False
        Me.pnl_hihyoji.Location = New System.Drawing.Point(10, 38)
        Me.pnl_hihyoji.Name = "pnl_hihyoji"
        Me.pnl_hihyoji.Size = New System.Drawing.Size(951, 187)
        Me.pnl_hihyoji.TabIndex = 25
        Me.pnl_hihyoji.Text = "表示限定テキストボックス設定用パネル"
        '
        'txt_urigoukei
        '
        Me.txt_urigoukei.AcceptsReturn = True
        Me.txt_urigoukei.BackColor = System.Drawing.SystemColors.Control
        Me.txt_urigoukei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_urigoukei.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_urigoukei.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_urigoukei.Location = New System.Drawing.Point(11, 161)
        Me.txt_urigoukei.MaxLength = 0
        Me.txt_urigoukei.Name = "txt_urigoukei"
        Me.txt_urigoukei.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_urigoukei.Size = New System.Drawing.Size(110, 20)
        Me.txt_urigoukei.TabIndex = 31
        Me.txt_urigoukei.TabStop = False
        Me.txt_urigoukei.Text = "-9,999,999,999"
        Me.txt_urigoukei.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_nyukin
        '
        Me.txt_nyukin.AcceptsReturn = True
        Me.txt_nyukin.BackColor = System.Drawing.SystemColors.Control
        Me.txt_nyukin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nyukin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_nyukin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_nyukin.Location = New System.Drawing.Point(120, 161)
        Me.txt_nyukin.MaxLength = 0
        Me.txt_nyukin.Name = "txt_nyukin"
        Me.txt_nyukin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_nyukin.Size = New System.Drawing.Size(110, 20)
        Me.txt_nyukin.TabIndex = 30
        Me.txt_nyukin.TabStop = False
        Me.txt_nyukin.Text = "-9,999,999,999"
        Me.txt_nyukin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_nyugoukei
        '
        Me.txt_nyugoukei.AcceptsReturn = True
        Me.txt_nyugoukei.BackColor = System.Drawing.SystemColors.Control
        Me.txt_nyugoukei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nyugoukei.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_nyugoukei.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_nyugoukei.Location = New System.Drawing.Point(415, 161)
        Me.txt_nyugoukei.MaxLength = 0
        Me.txt_nyugoukei.Name = "txt_nyugoukei"
        Me.txt_nyugoukei.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_nyugoukei.Size = New System.Drawing.Size(110, 20)
        Me.txt_nyugoukei.TabIndex = 29
        Me.txt_nyugoukei.TabStop = False
        Me.txt_nyugoukei.Text = "-9,999,999,999"
        Me.txt_nyugoukei.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_kesizan
        '
        Me.txt_kesizan.AcceptsReturn = True
        Me.txt_kesizan.BackColor = System.Drawing.SystemColors.Control
        Me.txt_kesizan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_kesizan.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_kesizan.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_kesizan.Location = New System.Drawing.Point(524, 161)
        Me.txt_kesizan.MaxLength = 0
        Me.txt_kesizan.Name = "txt_kesizan"
        Me.txt_kesizan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_kesizan.Size = New System.Drawing.Size(110, 20)
        Me.txt_kesizan.TabIndex = 28
        Me.txt_kesizan.TabStop = False
        Me.txt_kesizan.Text = "-9,999,999,999"
        Me.txt_kesizan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_tesuryo
        '
        Me.txt_tesuryo.AcceptsReturn = True
        Me.txt_tesuryo.BackColor = System.Drawing.SystemColors.Control
        Me.txt_tesuryo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tesuryo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_tesuryo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_tesuryo.Location = New System.Drawing.Point(229, 161)
        Me.txt_tesuryo.MaxLength = 0
        Me.txt_tesuryo.Name = "txt_tesuryo"
        Me.txt_tesuryo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_tesuryo.Size = New System.Drawing.Size(94, 20)
        Me.txt_tesuryo.TabIndex = 27
        Me.txt_tesuryo.TabStop = False
        Me.txt_tesuryo.Text = "-999,999"
        Me.txt_tesuryo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_syohi
        '
        Me.txt_syohi.AcceptsReturn = True
        Me.txt_syohi.BackColor = System.Drawing.SystemColors.Control
        Me.txt_syohi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_syohi.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_syohi.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_syohi.Location = New System.Drawing.Point(322, 161)
        Me.txt_syohi.MaxLength = 0
        Me.txt_syohi.Name = "txt_syohi"
        Me.txt_syohi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_syohi.Size = New System.Drawing.Size(94, 20)
        Me.txt_syohi.TabIndex = 26
        Me.txt_syohi.TabStop = False
        Me.txt_syohi.Text = "-999,999"
        Me.txt_syohi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnl_urigoukei
        '
        Me.pnl_urigoukei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_urigoukei.Location = New System.Drawing.Point(11, 140)
        Me.pnl_urigoukei.Name = "pnl_urigoukei"
        Me.pnl_urigoukei.Size = New System.Drawing.Size(110, 22)
        Me.pnl_urigoukei.TabIndex = 32
        Me.pnl_urigoukei.Text = "　　売上合計"
        '
        'pnl_nyukin
        '
        Me.pnl_nyukin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_nyukin.Location = New System.Drawing.Point(120, 140)
        Me.pnl_nyukin.Name = "pnl_nyukin"
        Me.pnl_nyukin.Size = New System.Drawing.Size(110, 22)
        Me.pnl_nyukin.TabIndex = 33
        Me.pnl_nyukin.Text = "　　入金額"
        '
        'pnl_nyugoukei
        '
        Me.pnl_nyugoukei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_nyugoukei.Location = New System.Drawing.Point(415, 140)
        Me.pnl_nyugoukei.Name = "pnl_nyugoukei"
        Me.pnl_nyugoukei.Size = New System.Drawing.Size(110, 22)
        Me.pnl_nyugoukei.TabIndex = 34
        Me.pnl_nyugoukei.Text = "　  入金合計"
        '
        'pnl_kesizan
        '
        Me.pnl_kesizan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_kesizan.Location = New System.Drawing.Point(524, 140)
        Me.pnl_kesizan.Name = "pnl_kesizan"
        Me.pnl_kesizan.Size = New System.Drawing.Size(110, 22)
        Me.pnl_kesizan.TabIndex = 35
        Me.pnl_kesizan.Text = "　 消込残額"
        '
        'lbl_c
        '
        Me.lbl_c.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_c.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_c.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_c.Location = New System.Drawing.Point(0, 124)
        Me.lbl_c.Name = "lbl_c"
        Me.lbl_c.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_c.Size = New System.Drawing.Size(97, 20)
        Me.lbl_c.TabIndex = 36
        Me.lbl_c.Text = "＜消込情報＞"
        '
        '_img_bkunlock_0
        '
        Me._img_bkunlock_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._img_bkunlock_0.Image = CType(resources.GetObject("_img_bkunlock_0.Image"), System.Drawing.Image)
        Me.img_bkunlock.SetIndex(Me._img_bkunlock_0, CType(0, Short))
        Me._img_bkunlock_0.Location = New System.Drawing.Point(233, 676)
        Me._img_bkunlock_0.Name = "_img_bkunlock_0"
        Me._img_bkunlock_0.Size = New System.Drawing.Size(24, 22)
        Me._img_bkunlock_0.TabIndex = 56
        Me._img_bkunlock_0.TabStop = False
        '
        '_img_bkunlock_1
        '
        Me._img_bkunlock_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._img_bkunlock_1.Image = CType(resources.GetObject("_img_bkunlock_1.Image"), System.Drawing.Image)
        Me.img_bkunlock.SetIndex(Me._img_bkunlock_1, CType(1, Short))
        Me._img_bkunlock_1.Location = New System.Drawing.Point(261, 676)
        Me._img_bkunlock_1.Name = "_img_bkunlock_1"
        Me._img_bkunlock_1.Size = New System.Drawing.Size(24, 22)
        Me._img_bkunlock_1.TabIndex = 57
        Me._img_bkunlock_1.TabStop = False
        '
        '_img_bkshowwnd_1
        '
        Me._img_bkshowwnd_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._img_bkshowwnd_1.Image = CType(resources.GetObject("_img_bkshowwnd_1.Image"), System.Drawing.Image)
        Me.img_bkshowwnd.SetIndex(Me._img_bkshowwnd_1, CType(1, Short))
        Me._img_bkshowwnd_1.Location = New System.Drawing.Point(205, 676)
        Me._img_bkshowwnd_1.Name = "_img_bkshowwnd_1"
        Me._img_bkshowwnd_1.Size = New System.Drawing.Size(24, 22)
        Me._img_bkshowwnd_1.TabIndex = 58
        Me._img_bkshowwnd_1.TabStop = False
        '
        '_img_bkshowwnd_0
        '
        Me._img_bkshowwnd_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._img_bkshowwnd_0.Image = CType(resources.GetObject("_img_bkshowwnd_0.Image"), System.Drawing.Image)
        Me.img_bkshowwnd.SetIndex(Me._img_bkshowwnd_0, CType(0, Short))
        Me._img_bkshowwnd_0.Location = New System.Drawing.Point(177, 676)
        Me._img_bkshowwnd_0.Name = "_img_bkshowwnd_0"
        Me._img_bkshowwnd_0.Size = New System.Drawing.Size(24, 22)
        Me._img_bkshowwnd_0.TabIndex = 59
        Me._img_bkshowwnd_0.TabStop = False
        '
        '_img_bkexit_1
        '
        Me._img_bkexit_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._img_bkexit_1.Image = CType(resources.GetObject("_img_bkexit_1.Image"), System.Drawing.Image)
        Me.img_bkexit.SetIndex(Me._img_bkexit_1, CType(1, Short))
        Me._img_bkexit_1.Location = New System.Drawing.Point(92, 676)
        Me._img_bkexit_1.Name = "_img_bkexit_1"
        Me._img_bkexit_1.Size = New System.Drawing.Size(24, 22)
        Me._img_bkexit_1.TabIndex = 60
        Me._img_bkexit_1.TabStop = False
        '
        '_img_bkexit_0
        '
        Me._img_bkexit_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._img_bkexit_0.Image = CType(resources.GetObject("_img_bkexit_0.Image"), System.Drawing.Image)
        Me.img_bkexit.SetIndex(Me._img_bkexit_0, CType(0, Short))
        Me._img_bkexit_0.Location = New System.Drawing.Point(64, 676)
        Me._img_bkexit_0.Name = "_img_bkexit_0"
        Me._img_bkexit_0.Size = New System.Drawing.Size(24, 22)
        Me._img_bkexit_0.TabIndex = 61
        Me._img_bkexit_0.TabStop = False
        '
        '_img_bkresist_1
        '
        Me._img_bkresist_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._img_bkresist_1.Image = CType(resources.GetObject("_img_bkresist_1.Image"), System.Drawing.Image)
        Me.img_bkresist.SetIndex(Me._img_bkresist_1, CType(1, Short))
        Me._img_bkresist_1.Location = New System.Drawing.Point(148, 676)
        Me._img_bkresist_1.Name = "_img_bkresist_1"
        Me._img_bkresist_1.Size = New System.Drawing.Size(24, 22)
        Me._img_bkresist_1.TabIndex = 62
        Me._img_bkresist_1.TabStop = False
        '
        '_img_bkresist_0
        '
        Me._img_bkresist_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._img_bkresist_0.Image = CType(resources.GetObject("_img_bkresist_0.Image"), System.Drawing.Image)
        Me.img_bkresist.SetIndex(Me._img_bkresist_0, CType(0, Short))
        Me._img_bkresist_0.Location = New System.Drawing.Point(120, 676)
        Me._img_bkresist_0.Name = "_img_bkresist_0"
        Me._img_bkresist_0.Size = New System.Drawing.Size(24, 22)
        Me._img_bkresist_0.TabIndex = 63
        Me._img_bkresist_0.TabStop = False
        '
        'opt_sort
        '
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(193, 17)
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(193, 17)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "端末ID"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(193, 17)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Text = "ログインID"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(193, 17)
        Me.ToolStripStatusLabel4.Spring = True
        Me.ToolStripStatusLabel4.Text = "XXXXXXX"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(193, 17)
        Me.ToolStripStatusLabel5.Spring = True
        Me.ToolStripStatusLabel5.Text = "Ver.1.00"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 648)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(983, 22)
        Me.StatusStrip1.TabIndex = 82
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Button12
        '
        Me.Button12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button12.CausesValidation = False
        Me.Button12.Location = New System.Drawing.Point(900, 605)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(75, 39)
        Me.Button12.TabIndex = 94
        Me.Button12.Text = "(F12)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button11.Enabled = False
        Me.Button11.Location = New System.Drawing.Point(824, 605)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(75, 39)
        Me.Button11.TabIndex = 93
        Me.Button11.Text = "(F11)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button10.CausesValidation = False
        Me.Button10.Enabled = False
        Me.Button10.Location = New System.Drawing.Point(748, 605)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 39)
        Me.Button10.TabIndex = 92
        Me.Button10.Text = "(F10)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button9.CausesValidation = False
        Me.Button9.Location = New System.Drawing.Point(672, 605)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 39)
        Me.Button9.TabIndex = 91
        Me.Button9.Text = "(F9)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "クリア"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button8.Enabled = False
        Me.Button8.Location = New System.Drawing.Point(567, 605)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 39)
        Me.Button8.TabIndex = 90
        Me.Button8.Text = "(F8)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  "
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button7.Enabled = False
        Me.Button7.Location = New System.Drawing.Point(491, 605)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 39)
        Me.Button7.TabIndex = 89
        Me.Button7.Text = "(F7)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button6.Enabled = False
        Me.Button6.Location = New System.Drawing.Point(415, 605)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 39)
        Me.Button6.TabIndex = 88
        Me.Button6.Text = "(F6)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  "
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button5.Location = New System.Drawing.Point(339, 605)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 39)
        Me.Button5.TabIndex = 87
        Me.Button5.Text = "(F5)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "参照"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button4.Enabled = False
        Me.Button4.Location = New System.Drawing.Point(233, 605)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 39)
        Me.Button4.TabIndex = 86
        Me.Button4.Text = "(F4)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(157, 605)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 39)
        Me.Button3.TabIndex = 85
        Me.Button3.Text = "(F3)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "　　"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(81, 605)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 39)
        Me.Button2.TabIndex = 84
        Me.Button2.Text = "(F2)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  "
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(5, 605)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 39)
        Me.Button1.TabIndex = 83
        Me.Button1.Text = "(F1)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "更新"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'spd_body
        '
        Me.spd_body.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spd_body.Location = New System.Drawing.Point(3, 232)
        Me.spd_body.Name = "spd_body"
        Me.spd_body.Size = New System.Drawing.Size(980, 368)
        Me.spd_body.TabIndex = 65
        Me.spd_body.Template = Me.Template11
        '
        'Template11
        '
        Me.Template11.Height = 41
        '
        '
        '
        Border1.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        Me.Template11.Row.Border = Border1
        Me.Template11.Row.Height = 21
        Me.Template11.Row.Width = 986
        Me.Template11.Width = 986
        '
        'FR_SSSMAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(983, 670)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.pnl_unydt)
        Me.Controls.Add(Me.cmd_csvout)
        Me.Controls.Add(Me.cmd_kesidt)
        Me.Controls.Add(Me.cmd_tokseicd)
        Me.Controls.Add(Me.cmd_kaidt_From)
        Me.Controls.Add(Me.cmd_fridt)
        Me.Controls.Add(Me.cmd_tesuryo)
        Me.Controls.Add(Me.cmd_syohi)
        Me.Controls.Add(Me.cmd_zenkesi)
        Me.Controls.Add(Me.cmd_zenkaijo)
        Me.Controls.Add(Me.cmd_saihyoji)
        Me.Controls.Add(Me.pnl_condition1)
        Me.Controls.Add(Me.pnl_hihyoji)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.spd_body)
        Me.Controls.Add(Me._img_bklight_1)
        Me.Controls.Add(Me._img_bklight_0)
        Me.Controls.Add(Me.pnl_tail)
        Me.Controls.Add(Me._img_bkunlock_0)
        Me.Controls.Add(Me._img_bkunlock_1)
        Me.Controls.Add(Me._img_bkshowwnd_1)
        Me.Controls.Add(Me._img_bkshowwnd_0)
        Me.Controls.Add(Me._img_bkexit_1)
        Me.Controls.Add(Me._img_bkexit_0)
        Me.Controls.Add(Me._img_bkresist_1)
        Me.Controls.Add(Me._img_bkresist_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(97, 53)
        Me.Name = "FR_SSSMAIN"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "入金消込（個別/全体）"
        CType(Me._img_bklight_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._img_bklight_0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_tail.ResumeLayout(False)
        Me.pnl_tail.PerformLayout()
        CType(Me.img_light, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_msg.ResumeLayout(False)
        Me.pnl_msg.PerformLayout()
        Me.pnl_condition1.ResumeLayout(False)
        Me.pnl_condition1.PerformLayout()
        Me.Picture2.ResumeLayout(False)
        Me.Picture2.PerformLayout()
        Me.frm_opt1.ResumeLayout(False)
        Me.Picture1.ResumeLayout(False)
        Me.Picture1.PerformLayout()
        Me.pnl_hihyoji.ResumeLayout(False)
        Me.pnl_hihyoji.PerformLayout()
        CType(Me._img_bkunlock_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._img_bkunlock_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._img_bkshowwnd_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._img_bkshowwnd_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._img_bkexit_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._img_bkexit_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._img_bkresist_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._img_bkresist_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.img_bkexit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.img_bklight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.img_bkresist, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.img_bkshowwnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.img_bkunlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_hytokkesdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_shakbnm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.opt_sort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.spd_body, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GcMultiRow1 As GrapeCity.Win.MultiRow.GcMultiRow
    Private Template11 As Template1
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Button12 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents spd_body As GrapeCity.Win.MultiRow.GcMultiRow
    'Private WithEvents Template12 As URKET53.RcpRecTmp
#End Region
End Class