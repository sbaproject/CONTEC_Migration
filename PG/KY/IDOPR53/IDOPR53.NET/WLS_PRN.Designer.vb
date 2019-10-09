<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class WLS_PRN
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
	Public WithEvents PNL_DefSize As SSPanel5
	Public WithEvents PNL_DefOrient As SSPanel5
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Frame4 As System.Windows.Forms.GroupBox
	Public WithEvents LstKyusi As System.Windows.Forms.ListBox
	Public WithEvents LstForm As System.Windows.Forms.ListBox
	Public WithEvents _OptOrient_1 As System.Windows.Forms.RadioButton
	Public WithEvents _OptOrient_0 As System.Windows.Forms.RadioButton
	Public WithEvents ImgOrient As System.Windows.Forms.PictureBox
	Public WithEvents Frame3 As System.Windows.Forms.GroupBox
	Public WithEvents CmbKyusi As System.Windows.Forms.ComboBox
	Public WithEvents CmbForm As System.Windows.Forms.ComboBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents CmbPrn As System.Windows.Forms.ComboBox
	Public WithEvents CmdProper As System.Windows.Forms.Button
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents WLSOK As System.Windows.Forms.Button
	Public WithEvents WLSCANCEL As System.Windows.Forms.Button
	Public WithEvents _ImgLib_1 As System.Windows.Forms.PictureBox
	Public WithEvents _ImgLib_0 As System.Windows.Forms.PictureBox
	Public WithEvents ImgLib As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents OptOrient As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WLS_PRN))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Frame4 = New System.Windows.Forms.GroupBox
		Me.PNL_DefSize = New SSPanel5
		Me.PNL_DefOrient = New SSPanel5
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.LstKyusi = New System.Windows.Forms.ListBox
		Me.LstForm = New System.Windows.Forms.ListBox
		Me.Frame3 = New System.Windows.Forms.GroupBox
		Me._OptOrient_1 = New System.Windows.Forms.RadioButton
		Me._OptOrient_0 = New System.Windows.Forms.RadioButton
		Me.ImgOrient = New System.Windows.Forms.PictureBox
		Me.Frame2 = New System.Windows.Forms.GroupBox
		Me.CmbKyusi = New System.Windows.Forms.ComboBox
		Me.CmbForm = New System.Windows.Forms.ComboBox
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.CmbPrn = New System.Windows.Forms.ComboBox
		Me.CmdProper = New System.Windows.Forms.Button
		Me.Label1 = New System.Windows.Forms.Label
		Me.WLSOK = New System.Windows.Forms.Button
		Me.WLSCANCEL = New System.Windows.Forms.Button
		Me._ImgLib_1 = New System.Windows.Forms.PictureBox
		Me._ImgLib_0 = New System.Windows.Forms.PictureBox
		Me.ImgLib = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.OptOrient = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.Frame4.SuspendLayout()
		Me.Frame3.SuspendLayout()
		Me.Frame2.SuspendLayout()
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.ImgLib, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.OptOrient, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "帳票毎のプリンタの設定と記録"
		Me.ClientSize = New System.Drawing.Size(553, 248)
		Me.Location = New System.Drawing.Point(195, 307)
		Me.ControlBox = False
		Me.ForeColor = System.Drawing.SystemColors.WindowText
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "WLS_PRN"
		Me.Frame4.Text = "標準用紙サイズと印刷の向き"
		Me.Frame4.Size = New System.Drawing.Size(297, 57)
		Me.Frame4.Location = New System.Drawing.Point(8, 168)
		Me.Frame4.TabIndex = 16
		Me.Frame4.BackColor = System.Drawing.SystemColors.Control
		Me.Frame4.Enabled = True
		Me.Frame4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame4.Visible = True
		Me.Frame4.Name = "Frame4"
		Me.PNL_DefSize.Size = New System.Drawing.Size(153, 20)
		Me.PNL_DefSize.Location = New System.Drawing.Point(48, 20)
		Me.PNL_DefSize.TabIndex = 20
		Me.PNL_DefSize.BackColor = 12632256
		Me.PNL_DefSize.ForeColor = -2147483640
		Me.PNL_DefSize.BevelOuter = 1
		Me.PNL_DefSize.Caption = "A4"
		Me.PNL_DefSize.Name = "PNL_DefSize"
		Me.PNL_DefOrient.Size = New System.Drawing.Size(33, 20)
		Me.PNL_DefOrient.Location = New System.Drawing.Point(248, 20)
		Me.PNL_DefOrient.TabIndex = 19
		Me.PNL_DefOrient.BackColor = 12632256
		Me.PNL_DefOrient.ForeColor = -2147483640
		Me.PNL_DefOrient.BevelOuter = 1
		Me.PNL_DefOrient.Caption = "縦"
		Me.PNL_DefOrient.Name = "PNL_DefOrient"
		Me.Label5.Text = "向き"
		Me.Label5.Size = New System.Drawing.Size(25, 17)
		Me.Label5.Location = New System.Drawing.Point(224, 24)
		Me.Label5.TabIndex = 18
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.SystemColors.Control
		Me.Label5.Enabled = True
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.Text = "ｻｲｽﾞ"
		Me.Label4.Size = New System.Drawing.Size(33, 17)
		Me.Label4.Location = New System.Drawing.Point(16, 24)
		Me.Label4.TabIndex = 17
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.LstKyusi.Size = New System.Drawing.Size(55, 31)
		Me.LstKyusi.Location = New System.Drawing.Point(87, 318)
		Me.LstKyusi.TabIndex = 15
		Me.LstKyusi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.LstKyusi.BackColor = System.Drawing.SystemColors.Window
		Me.LstKyusi.CausesValidation = True
		Me.LstKyusi.Enabled = True
		Me.LstKyusi.ForeColor = System.Drawing.SystemColors.WindowText
		Me.LstKyusi.IntegralHeight = True
		Me.LstKyusi.Cursor = System.Windows.Forms.Cursors.Default
		Me.LstKyusi.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.LstKyusi.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.LstKyusi.Sorted = False
		Me.LstKyusi.TabStop = True
		Me.LstKyusi.Visible = True
		Me.LstKyusi.MultiColumn = False
		Me.LstKyusi.Name = "LstKyusi"
		Me.LstForm.Size = New System.Drawing.Size(55, 31)
		Me.LstForm.Location = New System.Drawing.Point(9, 318)
		Me.LstForm.TabIndex = 10
		Me.LstForm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.LstForm.BackColor = System.Drawing.SystemColors.Window
		Me.LstForm.CausesValidation = True
		Me.LstForm.Enabled = True
		Me.LstForm.ForeColor = System.Drawing.SystemColors.WindowText
		Me.LstForm.IntegralHeight = True
		Me.LstForm.Cursor = System.Windows.Forms.Cursors.Default
		Me.LstForm.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.LstForm.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.LstForm.Sorted = False
		Me.LstForm.TabStop = True
		Me.LstForm.Visible = True
		Me.LstForm.MultiColumn = False
		Me.LstForm.Name = "LstForm"
		Me.Frame3.Text = "印刷の向き"
		Me.Frame3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Frame3.Size = New System.Drawing.Size(142, 79)
		Me.Frame3.Location = New System.Drawing.Point(345, 78)
		Me.Frame3.TabIndex = 8
		Me.Frame3.BackColor = System.Drawing.SystemColors.Control
		Me.Frame3.Enabled = True
		Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame3.Visible = True
		Me.Frame3.Name = "Frame3"
		Me._OptOrient_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._OptOrient_1.Text = "横"
		Me._OptOrient_1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me._OptOrient_1.Size = New System.Drawing.Size(49, 25)
		Me._OptOrient_1.Location = New System.Drawing.Point(87, 48)
		Me._OptOrient_1.TabIndex = 12
		Me._OptOrient_1.TabStop = False
		Me._OptOrient_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._OptOrient_1.BackColor = System.Drawing.SystemColors.Control
		Me._OptOrient_1.CausesValidation = True
		Me._OptOrient_1.Enabled = True
		Me._OptOrient_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._OptOrient_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._OptOrient_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._OptOrient_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._OptOrient_1.Checked = False
		Me._OptOrient_1.Visible = True
		Me._OptOrient_1.Name = "_OptOrient_1"
		Me._OptOrient_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._OptOrient_0.Text = "縦"
		Me._OptOrient_0.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me._OptOrient_0.Size = New System.Drawing.Size(49, 25)
		Me._OptOrient_0.Location = New System.Drawing.Point(87, 18)
		Me._OptOrient_0.TabIndex = 11
		Me._OptOrient_0.TabStop = False
		Me._OptOrient_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._OptOrient_0.BackColor = System.Drawing.SystemColors.Control
		Me._OptOrient_0.CausesValidation = True
		Me._OptOrient_0.Enabled = True
		Me._OptOrient_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._OptOrient_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._OptOrient_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._OptOrient_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._OptOrient_0.Checked = False
		Me._OptOrient_0.Visible = True
		Me._OptOrient_0.Name = "_OptOrient_0"
		Me.ImgOrient.Size = New System.Drawing.Size(31, 31)
		Me.ImgOrient.Location = New System.Drawing.Point(27, 30)
		Me.ImgOrient.Enabled = True
		Me.ImgOrient.Cursor = System.Windows.Forms.Cursors.Default
		Me.ImgOrient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.ImgOrient.Visible = True
		Me.ImgOrient.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.ImgOrient.Name = "ImgOrient"
		Me.Frame2.Text = "用紙"
		Me.Frame2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Frame2.Size = New System.Drawing.Size(331, 79)
		Me.Frame2.Location = New System.Drawing.Point(6, 78)
		Me.Frame2.TabIndex = 6
		Me.Frame2.BackColor = System.Drawing.SystemColors.Control
		Me.Frame2.Enabled = True
		Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame2.Visible = True
		Me.Frame2.Name = "Frame2"
		Me.CmbKyusi.Size = New System.Drawing.Size(256, 20)
		Me.CmbKyusi.Location = New System.Drawing.Point(63, 48)
		Me.CmbKyusi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CmbKyusi.TabIndex = 13
		Me.CmbKyusi.TabStop = False
		Me.CmbKyusi.BackColor = System.Drawing.SystemColors.Window
		Me.CmbKyusi.CausesValidation = True
		Me.CmbKyusi.Enabled = True
		Me.CmbKyusi.ForeColor = System.Drawing.SystemColors.WindowText
		Me.CmbKyusi.IntegralHeight = True
		Me.CmbKyusi.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmbKyusi.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmbKyusi.Sorted = False
		Me.CmbKyusi.Visible = True
		Me.CmbKyusi.Name = "CmbKyusi"
		Me.CmbForm.Size = New System.Drawing.Size(256, 20)
		Me.CmbForm.Location = New System.Drawing.Point(63, 18)
		Me.CmbForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CmbForm.TabIndex = 9
		Me.CmbForm.TabStop = False
		Me.CmbForm.BackColor = System.Drawing.SystemColors.Window
		Me.CmbForm.CausesValidation = True
		Me.CmbForm.Enabled = True
		Me.CmbForm.ForeColor = System.Drawing.SystemColors.WindowText
		Me.CmbForm.IntegralHeight = True
		Me.CmbForm.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmbForm.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmbForm.Sorted = False
		Me.CmbForm.Visible = True
		Me.CmbForm.Name = "CmbForm"
		Me.Label3.Text = "給紙方法"
		Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label3.Size = New System.Drawing.Size(52, 16)
		Me.Label3.Location = New System.Drawing.Point(9, 51)
		Me.Label3.TabIndex = 14
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "ｻｲｽﾞ"
		Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label2.Size = New System.Drawing.Size(37, 16)
		Me.Label2.Location = New System.Drawing.Point(9, 21)
		Me.Label2.TabIndex = 7
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Frame1.Text = "ﾌﾟﾘﾝﾀ"
		Me.Frame1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Frame1.Size = New System.Drawing.Size(541, 61)
		Me.Frame1.Location = New System.Drawing.Point(6, 9)
		Me.Frame1.TabIndex = 3
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Name = "Frame1"
		Me.CmbPrn.Size = New System.Drawing.Size(406, 20)
		Me.CmbPrn.Location = New System.Drawing.Point(66, 21)
		Me.CmbPrn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CmbPrn.TabIndex = 4
		Me.CmbPrn.TabStop = False
		Me.CmbPrn.BackColor = System.Drawing.SystemColors.Window
		Me.CmbPrn.CausesValidation = True
		Me.CmbPrn.Enabled = True
		Me.CmbPrn.ForeColor = System.Drawing.SystemColors.WindowText
		Me.CmbPrn.IntegralHeight = True
		Me.CmbPrn.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmbPrn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmbPrn.Sorted = False
		Me.CmbPrn.Visible = True
		Me.CmbPrn.Name = "CmbPrn"
		Me.CmdProper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdProper.Text = "ﾌﾟﾛﾊﾟﾃｨ"
		Me.CmdProper.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.CmdProper.Size = New System.Drawing.Size(67, 19)
		Me.CmdProper.Location = New System.Drawing.Point(468, 21)
		Me.CmdProper.TabIndex = 2
		Me.CmdProper.BackColor = System.Drawing.SystemColors.Control
		Me.CmdProper.CausesValidation = True
		Me.CmdProper.Enabled = True
		Me.CmdProper.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdProper.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdProper.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdProper.TabStop = True
		Me.CmdProper.Name = "CmdProper"
		Me.Label1.Text = "ﾌﾟﾘﾝﾀ名"
		Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label1.Size = New System.Drawing.Size(52, 16)
		Me.Label1.Location = New System.Drawing.Point(9, 24)
		Me.Label1.TabIndex = 5
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.WLSOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.WLSOK.BackColor = System.Drawing.SystemColors.Control
		Me.WLSOK.Text = "OK"
		Me.WLSOK.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.WLSOK.Size = New System.Drawing.Size(66, 27)
		Me.WLSOK.Location = New System.Drawing.Point(351, 187)
		Me.WLSOK.TabIndex = 0
		Me.WLSOK.CausesValidation = True
		Me.WLSOK.Enabled = True
		Me.WLSOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.WLSOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSOK.TabStop = True
		Me.WLSOK.Name = "WLSOK"
		Me.WLSCANCEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.WLSCANCEL.BackColor = System.Drawing.SystemColors.Control
		Me.WLSCANCEL.Text = "ｷｬﾝｾﾙ"
		Me.WLSCANCEL.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.WLSCANCEL.Size = New System.Drawing.Size(66, 28)
		Me.WLSCANCEL.Location = New System.Drawing.Point(443, 187)
		Me.WLSCANCEL.TabIndex = 1
		Me.WLSCANCEL.CausesValidation = True
		Me.WLSCANCEL.Enabled = True
		Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
		Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSCANCEL.TabStop = True
		Me.WLSCANCEL.Name = "WLSCANCEL"
		Me._ImgLib_1.Size = New System.Drawing.Size(31, 27)
		Me._ImgLib_1.Location = New System.Drawing.Point(195, 315)
		Me._ImgLib_1.Image = CType(resources.GetObject("_ImgLib_1.Image"), System.Drawing.Image)
		Me._ImgLib_1.Enabled = True
		Me._ImgLib_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._ImgLib_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._ImgLib_1.Visible = True
		Me._ImgLib_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._ImgLib_1.Name = "_ImgLib_1"
		Me._ImgLib_0.Size = New System.Drawing.Size(28, 31)
		Me._ImgLib_0.Location = New System.Drawing.Point(156, 315)
		Me._ImgLib_0.Image = CType(resources.GetObject("_ImgLib_0.Image"), System.Drawing.Image)
		Me._ImgLib_0.Enabled = True
		Me._ImgLib_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._ImgLib_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._ImgLib_0.Visible = True
		Me._ImgLib_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._ImgLib_0.Name = "_ImgLib_0"
		Me.Controls.Add(Frame4)
		Me.Controls.Add(LstKyusi)
		Me.Controls.Add(LstForm)
		Me.Controls.Add(Frame3)
		Me.Controls.Add(Frame2)
		Me.Controls.Add(Frame1)
		Me.Controls.Add(WLSOK)
		Me.Controls.Add(WLSCANCEL)
		Me.Controls.Add(_ImgLib_1)
		Me.Controls.Add(_ImgLib_0)
		Me.Frame4.Controls.Add(PNL_DefSize)
		Me.Frame4.Controls.Add(PNL_DefOrient)
		Me.Frame4.Controls.Add(Label5)
		Me.Frame4.Controls.Add(Label4)
		Me.Frame3.Controls.Add(_OptOrient_1)
		Me.Frame3.Controls.Add(_OptOrient_0)
		Me.Frame3.Controls.Add(ImgOrient)
		Me.Frame2.Controls.Add(CmbKyusi)
		Me.Frame2.Controls.Add(CmbForm)
		Me.Frame2.Controls.Add(Label3)
		Me.Frame2.Controls.Add(Label2)
		Me.Frame1.Controls.Add(CmbPrn)
		Me.Frame1.Controls.Add(CmdProper)
		Me.Frame1.Controls.Add(Label1)
		Me.ImgLib.SetIndex(_ImgLib_1, CType(1, Short))
		Me.ImgLib.SetIndex(_ImgLib_0, CType(0, Short))
		Me.OptOrient.SetIndex(_OptOrient_1, CType(1, Short))
		Me.OptOrient.SetIndex(_OptOrient_0, CType(0, Short))
		CType(Me.OptOrient, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ImgLib, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Frame4.ResumeLayout(False)
		Me.Frame3.ResumeLayout(False)
		Me.Frame2.ResumeLayout(False)
		Me.Frame1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class