<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class WLS_HCP
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
	Public WithEvents Picture1 As System.Windows.Forms.PictureBox
	Public WithEvents _OptOrient_1 As System.Windows.Forms.RadioButton
	Public WithEvents _OptOrient_0 As System.Windows.Forms.RadioButton
	Public WithEvents ImgOrient As System.Windows.Forms.PictureBox
	Public WithEvents Frame3 As System.Windows.Forms.GroupBox
	Public WithEvents CmbFormDefault As System.Windows.Forms.ComboBox
	Public WithEvents CmbForm As System.Windows.Forms.ComboBox
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents CHK_DEFAULT_PRN As System.Windows.Forms.CheckBox
	Public WithEvents CmbPrn As System.Windows.Forms.ComboBox
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents WLSOK As System.Windows.Forms.Button
	Public WithEvents WLSCANCEL As System.Windows.Forms.Button
	Public WithEvents _ImgLib_0 As System.Windows.Forms.PictureBox
	Public WithEvents _ImgLib_1 As System.Windows.Forms.PictureBox
	Public WithEvents ImgLib As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents OptOrient As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WLS_HCP))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Picture1 = New System.Windows.Forms.PictureBox
		Me.Frame3 = New System.Windows.Forms.GroupBox
		Me._OptOrient_1 = New System.Windows.Forms.RadioButton
		Me._OptOrient_0 = New System.Windows.Forms.RadioButton
		Me.ImgOrient = New System.Windows.Forms.PictureBox
		Me.Frame2 = New System.Windows.Forms.GroupBox
		Me.CmbFormDefault = New System.Windows.Forms.ComboBox
		Me.CmbForm = New System.Windows.Forms.ComboBox
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.CHK_DEFAULT_PRN = New System.Windows.Forms.CheckBox
		Me.CmbPrn = New System.Windows.Forms.ComboBox
		Me.WLSOK = New System.Windows.Forms.Button
		Me.WLSCANCEL = New System.Windows.Forms.Button
		Me._ImgLib_0 = New System.Windows.Forms.PictureBox
		Me._ImgLib_1 = New System.Windows.Forms.PictureBox
		Me.ImgLib = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.OptOrient = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.Frame3.SuspendLayout()
		Me.Frame2.SuspendLayout()
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.ImgLib, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.OptOrient, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "メイン画面印刷"
		Me.ClientSize = New System.Drawing.Size(450, 200)
		Me.Location = New System.Drawing.Point(107, 214)
		Me.ControlBox = False
		Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Icon = CType(resources.GetObject("WLS_HCP.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "WLS_HCP"
		Me.Picture1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Picture1.Size = New System.Drawing.Size(34, 28)
		Me.Picture1.Location = New System.Drawing.Point(120, 291)
		Me.Picture1.TabIndex = 9
		Me.Picture1.Dock = System.Windows.Forms.DockStyle.None
		Me.Picture1.BackColor = System.Drawing.SystemColors.Control
		Me.Picture1.CausesValidation = True
		Me.Picture1.Enabled = True
		Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture1.TabStop = True
		Me.Picture1.Visible = True
		Me.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Picture1.Name = "Picture1"
		Me.Frame3.Text = "印刷の向き"
		Me.Frame3.Size = New System.Drawing.Size(145, 82)
		Me.Frame3.Location = New System.Drawing.Point(204, 102)
		Me.Frame3.TabIndex = 5
		Me.Frame3.BackColor = System.Drawing.SystemColors.Control
		Me.Frame3.Enabled = True
		Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame3.Visible = True
		Me.Frame3.Name = "Frame3"
		Me._OptOrient_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._OptOrient_1.Text = "横"
		Me._OptOrient_1.Size = New System.Drawing.Size(49, 25)
		Me._OptOrient_1.Location = New System.Drawing.Point(81, 48)
		Me._OptOrient_1.TabIndex = 8
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
		Me._OptOrient_0.Size = New System.Drawing.Size(49, 25)
		Me._OptOrient_0.Location = New System.Drawing.Point(81, 18)
		Me._OptOrient_0.TabIndex = 7
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
		Me.ImgOrient.Location = New System.Drawing.Point(18, 30)
		Me.ImgOrient.Enabled = True
		Me.ImgOrient.Cursor = System.Windows.Forms.Cursors.Default
		Me.ImgOrient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.ImgOrient.Visible = True
		Me.ImgOrient.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.ImgOrient.Name = "ImgOrient"
		Me.Frame2.Text = "用紙のサイズ"
		Me.Frame2.Size = New System.Drawing.Size(193, 82)
		Me.Frame2.Location = New System.Drawing.Point(6, 102)
		Me.Frame2.TabIndex = 4
		Me.Frame2.BackColor = System.Drawing.SystemColors.Control
		Me.Frame2.Enabled = True
		Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame2.Visible = True
		Me.Frame2.Name = "Frame2"
		Me.CmbFormDefault.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.CmbFormDefault.Size = New System.Drawing.Size(160, 20)
		Me.CmbFormDefault.Location = New System.Drawing.Point(15, 30)
		Me.CmbFormDefault.Items.AddRange(New Object(){"ﾃﾞﾌｫﾙﾄ用紙"})
		Me.CmbFormDefault.TabIndex = 11
		Me.CmbFormDefault.Text = "ﾃﾞﾌｫﾙﾄ用紙サイズ"
		Me.CmbFormDefault.BackColor = System.Drawing.SystemColors.Window
		Me.CmbFormDefault.CausesValidation = True
		Me.CmbFormDefault.Enabled = True
		Me.CmbFormDefault.ForeColor = System.Drawing.SystemColors.WindowText
		Me.CmbFormDefault.IntegralHeight = True
		Me.CmbFormDefault.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmbFormDefault.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmbFormDefault.Sorted = False
		Me.CmbFormDefault.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.CmbFormDefault.TabStop = True
		Me.CmbFormDefault.Visible = True
		Me.CmbFormDefault.Name = "CmbFormDefault"
		Me.CmbForm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.CmbForm.Size = New System.Drawing.Size(160, 20)
		Me.CmbForm.Location = New System.Drawing.Point(15, 30)
		Me.CmbForm.Items.AddRange(New Object(){"A3 297x420 mm", "A4 210x297 mm", "A5 148x210 mm", "B4 257x364 mm", "B5 182x257 mm"})
		Me.CmbForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CmbForm.TabIndex = 6
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
		Me.Frame1.Text = "ﾌﾟﾘﾝﾀ"
		Me.Frame1.Size = New System.Drawing.Size(436, 82)
		Me.Frame1.Location = New System.Drawing.Point(6, 9)
		Me.Frame1.TabIndex = 2
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Name = "Frame1"
		Me.CHK_DEFAULT_PRN.Text = "ﾃﾞﾌｫﾙﾄﾌﾟﾘﾝﾀのﾃﾞﾌｫﾙﾄ用紙を使う"
		Me.CHK_DEFAULT_PRN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.CHK_DEFAULT_PRN.Size = New System.Drawing.Size(202, 19)
		Me.CHK_DEFAULT_PRN.Location = New System.Drawing.Point(225, 51)
		Me.CHK_DEFAULT_PRN.TabIndex = 10
		Me.CHK_DEFAULT_PRN.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.CHK_DEFAULT_PRN.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.CHK_DEFAULT_PRN.BackColor = System.Drawing.SystemColors.Control
		Me.CHK_DEFAULT_PRN.CausesValidation = True
		Me.CHK_DEFAULT_PRN.Enabled = True
		Me.CHK_DEFAULT_PRN.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CHK_DEFAULT_PRN.Cursor = System.Windows.Forms.Cursors.Default
		Me.CHK_DEFAULT_PRN.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CHK_DEFAULT_PRN.Appearance = System.Windows.Forms.Appearance.Normal
		Me.CHK_DEFAULT_PRN.TabStop = True
		Me.CHK_DEFAULT_PRN.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.CHK_DEFAULT_PRN.Visible = True
		Me.CHK_DEFAULT_PRN.Name = "CHK_DEFAULT_PRN"
		Me.CmbPrn.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.CmbPrn.Size = New System.Drawing.Size(409, 20)
		Me.CmbPrn.Location = New System.Drawing.Point(15, 24)
		Me.CmbPrn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CmbPrn.TabIndex = 3
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
		Me.WLSOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.WLSOK.BackColor = System.Drawing.SystemColors.Control
		Me.WLSOK.Text = "印刷"
		Me.WLSOK.Size = New System.Drawing.Size(69, 28)
		Me.WLSOK.Location = New System.Drawing.Point(366, 109)
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
		Me.WLSCANCEL.Size = New System.Drawing.Size(69, 28)
		Me.WLSCANCEL.Location = New System.Drawing.Point(366, 153)
		Me.WLSCANCEL.TabIndex = 1
		Me.WLSCANCEL.CausesValidation = True
		Me.WLSCANCEL.Enabled = True
		Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
		Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSCANCEL.TabStop = True
		Me.WLSCANCEL.Name = "WLSCANCEL"
		Me._ImgLib_0.Size = New System.Drawing.Size(28, 31)
		Me._ImgLib_0.Location = New System.Drawing.Point(24, 288)
		Me._ImgLib_0.Image = CType(resources.GetObject("_ImgLib_0.Image"), System.Drawing.Image)
		Me._ImgLib_0.Enabled = True
		Me._ImgLib_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._ImgLib_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._ImgLib_0.Visible = True
		Me._ImgLib_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._ImgLib_0.Name = "_ImgLib_0"
		Me._ImgLib_1.Size = New System.Drawing.Size(31, 27)
		Me._ImgLib_1.Location = New System.Drawing.Point(63, 288)
		Me._ImgLib_1.Image = CType(resources.GetObject("_ImgLib_1.Image"), System.Drawing.Image)
		Me._ImgLib_1.Enabled = True
		Me._ImgLib_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._ImgLib_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._ImgLib_1.Visible = True
		Me._ImgLib_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._ImgLib_1.Name = "_ImgLib_1"
		Me.Controls.Add(Picture1)
		Me.Controls.Add(Frame3)
		Me.Controls.Add(Frame2)
		Me.Controls.Add(Frame1)
		Me.Controls.Add(WLSOK)
		Me.Controls.Add(WLSCANCEL)
		Me.Controls.Add(_ImgLib_0)
		Me.Controls.Add(_ImgLib_1)
		Me.Frame3.Controls.Add(_OptOrient_1)
		Me.Frame3.Controls.Add(_OptOrient_0)
		Me.Frame3.Controls.Add(ImgOrient)
		Me.Frame2.Controls.Add(CmbFormDefault)
		Me.Frame2.Controls.Add(CmbForm)
		Me.Frame1.Controls.Add(CHK_DEFAULT_PRN)
		Me.Frame1.Controls.Add(CmbPrn)
		Me.ImgLib.SetIndex(_ImgLib_0, CType(0, Short))
		Me.ImgLib.SetIndex(_ImgLib_1, CType(1, Short))
		Me.OptOrient.SetIndex(_OptOrient_1, CType(1, Short))
		Me.OptOrient.SetIndex(_OptOrient_0, CType(0, Short))
		CType(Me.OptOrient, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ImgLib, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Frame3.ResumeLayout(False)
		Me.Frame2.ResumeLayout(False)
		Me.Frame1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class