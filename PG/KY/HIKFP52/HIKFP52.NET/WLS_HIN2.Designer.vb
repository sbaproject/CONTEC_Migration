<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class WLSHIN
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
	Public WithEvents HD_HINKB As System.Windows.Forms.TextBox
	Public WithEvents HD_CODE As System.Windows.Forms.TextBox
	Public WithEvents HD_KATA As System.Windows.Forms.TextBox
	Public WithEvents WLSKANA As System.Windows.Forms.ComboBox
	Public WithEvents HD_HINKBNM As System.Windows.Forms.TextBox
	Public WithEvents Panel3D4 As SSPanel5
	Public WithEvents SSPanel51 As SSPanel5
	Public WithEvents _PNL_USENM_3 As SSPanel5
	Public WithEvents CS_HINKB As SSCommand5
	Public WithEvents WLSLABEL As SSPanel5
	Public WithEvents LST As System.Windows.Forms.ListBox
	Public WithEvents WLSOK As System.Windows.Forms.Button
	Public WithEvents WLSCANCEL As System.Windows.Forms.Button
	Public WithEvents Panel3D1 As SSPanel5
	Public WithEvents _IM_MAE_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_ATO_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_ATO_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_MAE_1 As System.Windows.Forms.PictureBox
	Public WithEvents WLSMAE As System.Windows.Forms.PictureBox
	Public WithEvents WLSATO As System.Windows.Forms.PictureBox
	Public WithEvents IM_ATO As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_MAE As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents PNL_USENM As SSPanel5Array
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WLSHIN))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.HD_HINKB = New System.Windows.Forms.TextBox
		Me.HD_CODE = New System.Windows.Forms.TextBox
		Me.HD_KATA = New System.Windows.Forms.TextBox
		Me.WLSKANA = New System.Windows.Forms.ComboBox
		Me.HD_HINKBNM = New System.Windows.Forms.TextBox
		Me.Panel3D4 = New SSPanel5
		Me.SSPanel51 = New SSPanel5
		Me._PNL_USENM_3 = New SSPanel5
		Me.CS_HINKB = New SSCommand5
		Me.WLSLABEL = New SSPanel5
		Me.LST = New System.Windows.Forms.ListBox
		Me.WLSOK = New System.Windows.Forms.Button
		Me.WLSCANCEL = New System.Windows.Forms.Button
		Me.Panel3D1 = New SSPanel5
		Me._IM_MAE_0 = New System.Windows.Forms.PictureBox
		Me._IM_ATO_0 = New System.Windows.Forms.PictureBox
		Me._IM_ATO_1 = New System.Windows.Forms.PictureBox
		Me._IM_MAE_1 = New System.Windows.Forms.PictureBox
		Me.WLSMAE = New System.Windows.Forms.PictureBox
		Me.WLSATO = New System.Windows.Forms.PictureBox
		Me.IM_ATO = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_MAE = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.PNL_USENM = New SSPanel5Array(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PNL_USENM, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "製品検索"
		Me.ClientSize = New System.Drawing.Size(754, 402)
		Me.Location = New System.Drawing.Point(128, 158)
		Me.ControlBox = False
		Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
		Me.Name = "WLSHIN"
		Me.HD_HINKB.AutoSize = False
		Me.HD_HINKB.Size = New System.Drawing.Size(18, 25)
		Me.HD_HINKB.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_HINKB.Location = New System.Drawing.Point(113, 7)
		Me.HD_HINKB.Maxlength = 1
		Me.HD_HINKB.TabIndex = 2
		Me.HD_HINKB.Text = "9"
		Me.HD_HINKB.AcceptsReturn = True
		Me.HD_HINKB.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_HINKB.BackColor = System.Drawing.SystemColors.Window
		Me.HD_HINKB.CausesValidation = True
		Me.HD_HINKB.Enabled = True
		Me.HD_HINKB.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_HINKB.HideSelection = True
		Me.HD_HINKB.ReadOnly = False
		Me.HD_HINKB.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_HINKB.MultiLine = False
		Me.HD_HINKB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_HINKB.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_HINKB.TabStop = True
		Me.HD_HINKB.Visible = True
		Me.HD_HINKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_HINKB.Name = "HD_HINKB"
		Me.HD_CODE.AutoSize = False
		Me.HD_CODE.Size = New System.Drawing.Size(79, 25)
		Me.HD_CODE.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_CODE.Location = New System.Drawing.Point(112, 36)
		Me.HD_CODE.Maxlength = 8
		Me.HD_CODE.TabIndex = 9
		Me.HD_CODE.Text = "XXXXXXX8"
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
		Me.HD_KATA.AutoSize = False
		Me.HD_KATA.Size = New System.Drawing.Size(246, 25)
		Me.HD_KATA.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_KATA.Location = New System.Drawing.Point(328, 7)
		Me.HD_KATA.Maxlength = 30
		Me.HD_KATA.TabIndex = 5
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
		Me.WLSKANA.Size = New System.Drawing.Size(82, 24)
		Me.WLSKANA.Location = New System.Drawing.Point(670, 7)
		Me.WLSKANA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.WLSKANA.TabIndex = 7
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
		Me.HD_HINKBNM.AutoSize = False
		Me.HD_HINKBNM.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.HD_HINKBNM.Size = New System.Drawing.Size(128, 25)
		Me.HD_HINKBNM.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_HINKBNM.Location = New System.Drawing.Point(130, 7)
		Me.HD_HINKBNM.Maxlength = 16
		Me.HD_HINKBNM.TabIndex = 3
		Me.HD_HINKBNM.TabStop = False
		Me.HD_HINKBNM.Text = "MMMMMMMM1MMMM16"
		Me.HD_HINKBNM.AcceptsReturn = True
		Me.HD_HINKBNM.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_HINKBNM.CausesValidation = True
		Me.HD_HINKBNM.Enabled = True
		Me.HD_HINKBNM.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_HINKBNM.HideSelection = True
		Me.HD_HINKBNM.ReadOnly = False
		Me.HD_HINKBNM.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_HINKBNM.MultiLine = False
		Me.HD_HINKBNM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_HINKBNM.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_HINKBNM.Visible = True
		Me.HD_HINKBNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_HINKBNM.Name = "HD_HINKBNM"
		Me.Panel3D4.Size = New System.Drawing.Size(106, 25)
		Me.Panel3D4.Location = New System.Drawing.Point(7, 36)
		Me.Panel3D4.TabIndex = 8
		Me.Panel3D4.BackColor = 12632256
		Me.Panel3D4.ForeColor = 0
		Me.Panel3D4.BevelOuter = 1
		Me.Panel3D4.Caption = "開始製品ｺｰﾄﾞ"
		Me.Panel3D4.OutLine = -1
		Me.Panel3D4.RoundedCorners = 0
		Me.Panel3D4.Name = "Panel3D4"
		Me.SSPanel51.Size = New System.Drawing.Size(55, 25)
		Me.SSPanel51.Location = New System.Drawing.Point(274, 7)
		Me.SSPanel51.TabIndex = 4
		Me.SSPanel51.BackColor = 12632256
		Me.SSPanel51.ForeColor = 0
		Me.SSPanel51.BevelOuter = 1
		Me.SSPanel51.Caption = "型式"
		Me.SSPanel51.OutLine = -1
		Me.SSPanel51.RoundedCorners = 0
		Me.SSPanel51.Name = "SSPanel51"
		Me._PNL_USENM_3.Size = New System.Drawing.Size(82, 25)
		Me._PNL_USENM_3.Location = New System.Drawing.Point(588, 7)
		Me._PNL_USENM_3.TabIndex = 6
		Me._PNL_USENM_3.BackColor = 12632256
		Me._PNL_USENM_3.ForeColor = 0
		Me._PNL_USENM_3.BevelOuter = 1
		Me._PNL_USENM_3.Caption = "カナ検索"
		Me._PNL_USENM_3.OutLine = -1
		Me._PNL_USENM_3.RoundedCorners = 0
		Me._PNL_USENM_3.Name = "_PNL_USENM_3"
		Me.CS_HINKB.Size = New System.Drawing.Size(106, 25)
		Me.CS_HINKB.Location = New System.Drawing.Point(7, 7)
		Me.CS_HINKB.TabIndex = 1
		Me.CS_HINKB.TabStop = 0
		Me.CS_HINKB.BackColor = 12632256
		Me.CS_HINKB.ForeColor = 0
		Me.CS_HINKB.Caption = "商品区分   "
		Me.CS_HINKB.BevelWidth = 1
		Me.CS_HINKB.RoundedCorners = 0
		Me.CS_HINKB.Name = "CS_HINKB"
		Me.WLSLABEL.Size = New System.Drawing.Size(748, 25)
		Me.WLSLABEL.Location = New System.Drawing.Point(3, 96)
		Me.WLSLABEL.TabIndex = 10
		Me.WLSLABEL.BackColor = 12632256
		Me.WLSLABEL.ForeColor = 0
		Me.WLSLABEL.Alignment = 1
		Me.WLSLABEL.BevelOuter = 1
		Me.WLSLABEL.Caption = "製品ｺｰﾄﾞ  型    式                        品    名"
		Me.WLSLABEL.OutLine = -1
		Me.WLSLABEL.RoundedCorners = 0
		Me.WLSLABEL.Name = "WLSLABEL"
		Me.LST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LST.Size = New System.Drawing.Size(748, 245)
		Me.LST.Location = New System.Drawing.Point(3, 120)
		Me.LST.Items.AddRange(New Object(){"XXXXXXX8  XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3  MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5"})
		Me.LST.TabIndex = 11
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
		Me.WLSOK.Location = New System.Drawing.Point(316, 369)
		Me.WLSOK.TabIndex = 12
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
		Me.WLSCANCEL.Location = New System.Drawing.Point(378, 369)
		Me.WLSCANCEL.TabIndex = 13
		Me.WLSCANCEL.CausesValidation = True
		Me.WLSCANCEL.Enabled = True
		Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
		Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSCANCEL.TabStop = True
		Me.WLSCANCEL.Name = "WLSCANCEL"
		Me.Panel3D1.Size = New System.Drawing.Size(767, 67)
		Me.Panel3D1.Location = New System.Drawing.Point(0, 0)
		Me.Panel3D1.TabIndex = 0
		Me.Panel3D1.BackColor = 12632256
		Me.Panel3D1.ForeColor = 0
		Me.Panel3D1.OutLine = -1
		Me.Panel3D1.Name = "Panel3D1"
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
		Me.WLSMAE.Location = New System.Drawing.Point(283, 369)
		Me.WLSMAE.Image = CType(resources.GetObject("WLSMAE.Image"), System.Drawing.Image)
		Me.WLSMAE.Enabled = True
		Me.WLSMAE.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSMAE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.WLSMAE.Visible = True
		Me.WLSMAE.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.WLSMAE.Name = "WLSMAE"
		Me.WLSATO.Size = New System.Drawing.Size(24, 22)
		Me.WLSATO.Location = New System.Drawing.Point(448, 369)
		Me.WLSATO.Image = CType(resources.GetObject("WLSATO.Image"), System.Drawing.Image)
		Me.WLSATO.Enabled = True
		Me.WLSATO.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSATO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.WLSATO.Visible = True
		Me.WLSATO.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.WLSATO.Name = "WLSATO"
		Me.Controls.Add(HD_HINKB)
		Me.Controls.Add(HD_CODE)
		Me.Controls.Add(HD_KATA)
		Me.Controls.Add(WLSKANA)
		Me.Controls.Add(HD_HINKBNM)
		Me.Controls.Add(Panel3D4)
		Me.Controls.Add(SSPanel51)
		Me.Controls.Add(_PNL_USENM_3)
		Me.Controls.Add(CS_HINKB)
		Me.Controls.Add(WLSLABEL)
		Me.Controls.Add(LST)
		Me.Controls.Add(WLSOK)
		Me.Controls.Add(WLSCANCEL)
		Me.Controls.Add(Panel3D1)
		Me.Controls.Add(_IM_MAE_0)
		Me.Controls.Add(_IM_ATO_0)
		Me.Controls.Add(_IM_ATO_1)
		Me.Controls.Add(_IM_MAE_1)
		Me.Controls.Add(WLSMAE)
		Me.Controls.Add(WLSATO)
		Me.IM_ATO.SetIndex(_IM_ATO_0, CType(0, Short))
		Me.IM_ATO.SetIndex(_IM_ATO_1, CType(1, Short))
		Me.IM_MAE.SetIndex(_IM_MAE_0, CType(0, Short))
		Me.IM_MAE.SetIndex(_IM_MAE_1, CType(1, Short))
		Me.PNL_USENM.SetIndex(_PNL_USENM_3, CType(3, Short))
		CType(Me.PNL_USENM, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class