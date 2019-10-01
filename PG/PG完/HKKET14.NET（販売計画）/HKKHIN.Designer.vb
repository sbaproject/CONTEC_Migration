<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class HKKHIN
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
	Public WithEvents LST As System.Windows.Forms.ListBox
	Public WithEvents WLSOK As System.Windows.Forms.Button
	Public WithEvents WLSCANCEL As System.Windows.Forms.Button
	Public WithEvents WLSKANA As System.Windows.Forms.ComboBox
	Public WithEvents HD_KATA As System.Windows.Forms.TextBox
	Public WithEvents HD_CODE As System.Windows.Forms.TextBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents lblNO As System.Windows.Forms.Label
	Public WithEvents Panel3D1 As System.Windows.Forms.Panel
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents _IM_MAE_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_ATO_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_ATO_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_MAE_1 As System.Windows.Forms.PictureBox
	Public WithEvents WLSMAE As System.Windows.Forms.PictureBox
	Public WithEvents WLSATO As System.Windows.Forms.PictureBox
	Public WithEvents IM_ATO As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_MAE As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(HKKHIN))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.LST = New System.Windows.Forms.ListBox
		Me.WLSOK = New System.Windows.Forms.Button
		Me.WLSCANCEL = New System.Windows.Forms.Button
		Me.Panel3D1 = New System.Windows.Forms.Panel
		Me.WLSKANA = New System.Windows.Forms.ComboBox
		Me.HD_KATA = New System.Windows.Forms.TextBox
		Me.HD_CODE = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.lblNO = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me._IM_MAE_0 = New System.Windows.Forms.PictureBox
		Me._IM_ATO_0 = New System.Windows.Forms.PictureBox
		Me._IM_ATO_1 = New System.Windows.Forms.PictureBox
		Me._IM_MAE_1 = New System.Windows.Forms.PictureBox
		Me.WLSMAE = New System.Windows.Forms.PictureBox
		Me.WLSATO = New System.Windows.Forms.PictureBox
		Me.IM_ATO = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_MAE = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.Panel3D1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "製品検索"
		Me.ClientSize = New System.Drawing.Size(767, 360)
		Me.Location = New System.Drawing.Point(128, 158)
		Me.ControlBox = False
		Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.ForeColor = System.Drawing.SystemColors.WindowText
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "HKKHIN"
		Me.LST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LST.Size = New System.Drawing.Size(759, 245)
		Me.LST.Location = New System.Drawing.Point(3, 81)
		Me.LST.Items.AddRange(New Object(){"XXXXXXX8  XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3  MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5"})
		Me.LST.TabIndex = 4
		Me.LST.BackColor = System.Drawing.SystemColors.Window
		Me.LST.CausesValidation = True
		Me.LST.Enabled = True
		Me.LST.ForeColor = System.Drawing.SystemColors.WindowText
		Me.LST.IntegralHeight = True
		Me.LST.Cursor = System.Windows.Forms.Cursors.Default
		Me.LST.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.LST.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.LST.Sorted = False
		Me.LST.TabStop = True
		Me.LST.Visible = True
		Me.LST.MultiColumn = False
		Me.LST.Name = "LST"
		Me.WLSOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.WLSOK.BackColor = System.Drawing.SystemColors.Control
		Me.WLSOK.Text = "OK"
		Me.WLSOK.Size = New System.Drawing.Size(61, 22)
		Me.WLSOK.Location = New System.Drawing.Point(316, 330)
		Me.WLSOK.TabIndex = 5
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
		Me.WLSCANCEL.Size = New System.Drawing.Size(61, 22)
		Me.WLSCANCEL.Location = New System.Drawing.Point(378, 330)
		Me.WLSCANCEL.TabIndex = 6
		Me.WLSCANCEL.CausesValidation = True
		Me.WLSCANCEL.Enabled = True
		Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
		Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSCANCEL.TabStop = True
		Me.WLSCANCEL.Name = "WLSCANCEL"
		Me.Panel3D1.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.Panel3D1.ForeColor = System.Drawing.Color.Black
		Me.Panel3D1.Size = New System.Drawing.Size(767, 37)
		Me.Panel3D1.Location = New System.Drawing.Point(0, 0)
		Me.Panel3D1.TabIndex = 0
		Me.Panel3D1.Dock = System.Windows.Forms.DockStyle.None
		Me.Panel3D1.CausesValidation = True
		Me.Panel3D1.Enabled = True
		Me.Panel3D1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Panel3D1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Panel3D1.TabStop = True
		Me.Panel3D1.Visible = True
		Me.Panel3D1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Panel3D1.Name = "Panel3D1"
		Me.WLSKANA.Size = New System.Drawing.Size(82, 24)
		Me.WLSKANA.Location = New System.Drawing.Point(668, 5)
		Me.WLSKANA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.WLSKANA.TabIndex = 3
		Me.WLSKANA.BackColor = System.Drawing.SystemColors.Window
		Me.WLSKANA.CausesValidation = True
		Me.WLSKANA.Enabled = True
		Me.WLSKANA.ForeColor = System.Drawing.SystemColors.WindowText
		Me.WLSKANA.IntegralHeight = True
		Me.WLSKANA.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSKANA.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSKANA.Sorted = False
		Me.WLSKANA.TabStop = True
		Me.WLSKANA.Visible = True
		Me.WLSKANA.Name = "WLSKANA"
		Me.HD_KATA.AutoSize = False
		Me.HD_KATA.Size = New System.Drawing.Size(246, 25)
		Me.HD_KATA.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_KATA.Location = New System.Drawing.Point(57, 5)
		Me.HD_KATA.Maxlength = 30
		Me.HD_KATA.TabIndex = 1
		Me.HD_KATA.Text = "XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3"
		Me.HD_KATA.AcceptsReturn = True
		Me.HD_KATA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_KATA.BackColor = System.Drawing.SystemColors.Window
		Me.HD_KATA.CausesValidation = True
		Me.HD_KATA.Enabled = True
		Me.HD_KATA.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_KATA.HideSelection = True
		Me.HD_KATA.ReadOnly = False
		Me.HD_KATA.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_KATA.MultiLine = False
		Me.HD_KATA.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_KATA.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_KATA.TabStop = True
		Me.HD_KATA.Visible = True
		Me.HD_KATA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_KATA.Name = "HD_KATA"
		Me.HD_CODE.AutoSize = False
		Me.HD_CODE.Size = New System.Drawing.Size(86, 25)
		Me.HD_CODE.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_CODE.Location = New System.Drawing.Point(413, 5)
		Me.HD_CODE.Maxlength = 10
		Me.HD_CODE.TabIndex = 2
		Me.HD_CODE.Text = "XXXXXXXX10"
		Me.HD_CODE.AcceptsReturn = True
		Me.HD_CODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_CODE.BackColor = System.Drawing.SystemColors.Window
		Me.HD_CODE.CausesValidation = True
		Me.HD_CODE.Enabled = True
		Me.HD_CODE.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_CODE.HideSelection = True
		Me.HD_CODE.ReadOnly = False
		Me.HD_CODE.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_CODE.MultiLine = False
		Me.HD_CODE.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_CODE.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_CODE.TabStop = True
		Me.HD_CODE.Visible = True
		Me.HD_CODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_CODE.Name = "HD_CODE"
		Me.Label1.Text = "商品名カナ"
		Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label1.Size = New System.Drawing.Size(70, 13)
		Me.Label1.Location = New System.Drawing.Point(592, 10)
		Me.Label1.TabIndex = 9
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = True
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Label2.Text = "製品コード"
		Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label2.Size = New System.Drawing.Size(70, 13)
		Me.Label2.Location = New System.Drawing.Point(336, 10)
		Me.Label2.TabIndex = 8
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = True
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.lblNO.Text = "型式"
		Me.lblNO.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.lblNO.Size = New System.Drawing.Size(28, 13)
		Me.lblNO.Location = New System.Drawing.Point(22, 10)
		Me.lblNO.TabIndex = 7
		Me.lblNO.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblNO.BackColor = System.Drawing.SystemColors.Control
		Me.lblNO.Enabled = True
		Me.lblNO.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblNO.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblNO.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblNO.UseMnemonic = True
		Me.lblNO.Visible = True
		Me.lblNO.AutoSize = True
		Me.lblNO.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblNO.Name = "lblNO"
		Me.Label5.Text = "商品名"
		Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label5.Size = New System.Drawing.Size(42, 13)
		Me.Label5.Location = New System.Drawing.Point(357, 64)
		Me.Label5.TabIndex = 12
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.SystemColors.Control
		Me.Label5.Enabled = True
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = True
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.Text = "型式"
		Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label4.Size = New System.Drawing.Size(28, 13)
		Me.Label4.Location = New System.Drawing.Point(101, 64)
		Me.Label4.TabIndex = 11
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = True
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.Text = "製品コード"
		Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label3.Size = New System.Drawing.Size(70, 13)
		Me.Label3.Location = New System.Drawing.Point(4, 64)
		Me.Label3.TabIndex = 10
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = True
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me._IM_MAE_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_MAE_0.Location = New System.Drawing.Point(297, 420)
		Me._IM_MAE_0.Image = CType(resources.GetObject("_IM_MAE_0.Image"), System.Drawing.Image)
		Me._IM_MAE_0.Visible = False
		Me._IM_MAE_0.Enabled = True
		Me._IM_MAE_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_MAE_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_MAE_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_MAE_0.Name = "_IM_MAE_0"
		Me._IM_ATO_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_ATO_0.Location = New System.Drawing.Point(357, 420)
		Me._IM_ATO_0.Image = CType(resources.GetObject("_IM_ATO_0.Image"), System.Drawing.Image)
		Me._IM_ATO_0.Visible = False
		Me._IM_ATO_0.Enabled = True
		Me._IM_ATO_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_ATO_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_ATO_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_ATO_0.Name = "_IM_ATO_0"
		Me._IM_ATO_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_ATO_1.Location = New System.Drawing.Point(384, 420)
		Me._IM_ATO_1.Image = CType(resources.GetObject("_IM_ATO_1.Image"), System.Drawing.Image)
		Me._IM_ATO_1.Visible = False
		Me._IM_ATO_1.Enabled = True
		Me._IM_ATO_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_ATO_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_ATO_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_ATO_1.Name = "_IM_ATO_1"
		Me._IM_MAE_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_MAE_1.Location = New System.Drawing.Point(324, 420)
		Me._IM_MAE_1.Image = CType(resources.GetObject("_IM_MAE_1.Image"), System.Drawing.Image)
		Me._IM_MAE_1.Visible = False
		Me._IM_MAE_1.Enabled = True
		Me._IM_MAE_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_MAE_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_MAE_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_MAE_1.Name = "_IM_MAE_1"
		Me.WLSMAE.Size = New System.Drawing.Size(24, 22)
		Me.WLSMAE.Location = New System.Drawing.Point(283, 330)
		Me.WLSMAE.Image = CType(resources.GetObject("WLSMAE.Image"), System.Drawing.Image)
		Me.WLSMAE.Enabled = True
		Me.WLSMAE.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSMAE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.WLSMAE.Visible = True
		Me.WLSMAE.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.WLSMAE.Name = "WLSMAE"
		Me.WLSATO.Size = New System.Drawing.Size(24, 22)
		Me.WLSATO.Location = New System.Drawing.Point(448, 330)
		Me.WLSATO.Image = CType(resources.GetObject("WLSATO.Image"), System.Drawing.Image)
		Me.WLSATO.Enabled = True
		Me.WLSATO.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSATO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.WLSATO.Visible = True
		Me.WLSATO.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.WLSATO.Name = "WLSATO"
		Me.Controls.Add(LST)
		Me.Controls.Add(WLSOK)
		Me.Controls.Add(WLSCANCEL)
		Me.Controls.Add(Panel3D1)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(_IM_MAE_0)
		Me.Controls.Add(_IM_ATO_0)
		Me.Controls.Add(_IM_ATO_1)
		Me.Controls.Add(_IM_MAE_1)
		Me.Controls.Add(WLSMAE)
		Me.Controls.Add(WLSATO)
		Me.Panel3D1.Controls.Add(WLSKANA)
		Me.Panel3D1.Controls.Add(HD_KATA)
		Me.Panel3D1.Controls.Add(HD_CODE)
		Me.Panel3D1.Controls.Add(Label1)
		Me.Panel3D1.Controls.Add(Label2)
		Me.Panel3D1.Controls.Add(lblNO)
		Me.IM_ATO.SetIndex(_IM_ATO_0, CType(0, Short))
		Me.IM_ATO.SetIndex(_IM_ATO_1, CType(1, Short))
		Me.IM_MAE.SetIndex(_IM_MAE_0, CType(0, Short))
		Me.IM_MAE.SetIndex(_IM_MAE_1, CType(1, Short))
		CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel3D1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class