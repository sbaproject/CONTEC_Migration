<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class WLS_THS1
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
	Public WithEvents WLSLABEL As SSPanel5
	Public WithEvents LST As System.Windows.Forms.ListBox
	Public WithEvents WLSOK As System.Windows.Forms.Button
	Public WithEvents WLSCANCEL As System.Windows.Forms.Button
	Public WithEvents HD_BUNRUI As System.Windows.Forms.TextBox
	Public WithEvents WLSKANA As System.Windows.Forms.ComboBox
	Public WithEvents HD_Kana As System.Windows.Forms.TextBox
	Public WithEvents HD_RN As System.Windows.Forms.TextBox
	Public WithEvents HD_TEXT As System.Windows.Forms.TextBox
	Public WithEvents Panel3D4 As SSPanel5
	Public WithEvents SSPanel51 As SSPanel5
	Public WithEvents _PNL_USENM_3 As SSPanel5
	Public WithEvents _SSPanel52_0 As SSPanel5
	Public WithEvents _SSPanel52_1 As SSPanel5
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
	Public WithEvents SSPanel52 As SSPanel5Array
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WLS_THS1))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.WLSLABEL = New SSPanel5
		Me.LST = New System.Windows.Forms.ListBox
		Me.WLSOK = New System.Windows.Forms.Button
		Me.WLSCANCEL = New System.Windows.Forms.Button
		Me.Panel3D1 = New SSPanel5
		Me.HD_BUNRUI = New System.Windows.Forms.TextBox
		Me.WLSKANA = New System.Windows.Forms.ComboBox
		Me.HD_Kana = New System.Windows.Forms.TextBox
		Me.HD_RN = New System.Windows.Forms.TextBox
		Me.HD_TEXT = New System.Windows.Forms.TextBox
		Me.Panel3D4 = New SSPanel5
		Me.SSPanel51 = New SSPanel5
		Me._PNL_USENM_3 = New SSPanel5
		Me._SSPanel52_0 = New SSPanel5
		Me._SSPanel52_1 = New SSPanel5
		Me._IM_MAE_0 = New System.Windows.Forms.PictureBox
		Me._IM_ATO_0 = New System.Windows.Forms.PictureBox
		Me._IM_ATO_1 = New System.Windows.Forms.PictureBox
		Me._IM_MAE_1 = New System.Windows.Forms.PictureBox
		Me.WLSMAE = New System.Windows.Forms.PictureBox
		Me.WLSATO = New System.Windows.Forms.PictureBox
		Me.IM_ATO = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_MAE = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.PNL_USENM = New SSPanel5Array(components)
		Me.SSPanel52 = New SSPanel5Array(components)
		Me.Panel3D1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PNL_USENM, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.SSPanel52, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "取引先検索"
		Me.ClientSize = New System.Drawing.Size(774, 368)
		Me.Location = New System.Drawing.Point(184, 158)
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
		Me.Name = "WLS_THS1"
		Me.WLSLABEL.Size = New System.Drawing.Size(755, 25)
		Me.WLSLABEL.Location = New System.Drawing.Point(3, 80)
		Me.WLSLABEL.TabIndex = 9
		Me.WLSLABEL.BackColor = 12632256
		Me.WLSLABEL.ForeColor = 0
		Me.WLSLABEL.Alignment = 1
		Me.WLSLABEL.BevelOuter = 1
		Me.WLSLABEL.Caption = "WLSLABEL"
		Me.WLSLABEL.OutLine = -1
		Me.WLSLABEL.RoundedCorners = 0
		Me.WLSLABEL.Name = "WLSLABEL"
		Me.LST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LST.Size = New System.Drawing.Size(755, 213)
		Me.LST.Location = New System.Drawing.Point(3, 104)
		Me.LST.TabIndex = 0
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
		Me.WLSOK.Location = New System.Drawing.Point(276, 332)
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
		Me.WLSCANCEL.Location = New System.Drawing.Point(339, 332)
		Me.WLSCANCEL.TabIndex = 6
		Me.WLSCANCEL.CausesValidation = True
		Me.WLSCANCEL.Enabled = True
		Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
		Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSCANCEL.TabStop = True
		Me.WLSCANCEL.Name = "WLSCANCEL"
		Me.Panel3D1.Size = New System.Drawing.Size(755, 77)
		Me.Panel3D1.Location = New System.Drawing.Point(0, 0)
		Me.Panel3D1.TabIndex = 7
		Me.Panel3D1.BackColor = 12632256
		Me.Panel3D1.ForeColor = 0
		Me.Panel3D1.OutLine = -1
		Me.Panel3D1.Name = "Panel3D1"
		Me.HD_BUNRUI.AutoSize = False
		Me.HD_BUNRUI.Size = New System.Drawing.Size(19, 25)
		Me.HD_BUNRUI.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_BUNRUI.Location = New System.Drawing.Point(144, 8)
		Me.HD_BUNRUI.Maxlength = 1
		Me.HD_BUNRUI.TabIndex = 1
		Me.HD_BUNRUI.Text = "X"
		Me.HD_BUNRUI.AcceptsReturn = True
		Me.HD_BUNRUI.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_BUNRUI.BackColor = System.Drawing.SystemColors.Window
		Me.HD_BUNRUI.CausesValidation = True
		Me.HD_BUNRUI.Enabled = True
		Me.HD_BUNRUI.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_BUNRUI.HideSelection = True
		Me.HD_BUNRUI.ReadOnly = False
		Me.HD_BUNRUI.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_BUNRUI.MultiLine = False
		Me.HD_BUNRUI.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_BUNRUI.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_BUNRUI.TabStop = True
		Me.HD_BUNRUI.Visible = True
		Me.HD_BUNRUI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_BUNRUI.Name = "HD_BUNRUI"
		Me.WLSKANA.Size = New System.Drawing.Size(82, 24)
		Me.WLSKANA.Location = New System.Drawing.Point(667, 40)
		Me.WLSKANA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.WLSKANA.TabIndex = 4
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
		Me.HD_Kana.AutoSize = False
		Me.HD_Kana.Size = New System.Drawing.Size(46, 25)
		Me.HD_Kana.IMEMode = System.Windows.Forms.ImeMode.KatakanaHalf
		Me.HD_Kana.Location = New System.Drawing.Point(627, 40)
		Me.HD_Kana.TabIndex = 11
		Me.HD_Kana.Text = "ｱｲｳｴｵ"
		Me.HD_Kana.Visible = False
		Me.HD_Kana.AcceptsReturn = True
		Me.HD_Kana.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_Kana.BackColor = System.Drawing.SystemColors.Window
		Me.HD_Kana.CausesValidation = True
		Me.HD_Kana.Enabled = True
		Me.HD_Kana.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_Kana.HideSelection = True
		Me.HD_Kana.ReadOnly = False
		Me.HD_Kana.Maxlength = 0
		Me.HD_Kana.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_Kana.MultiLine = False
		Me.HD_Kana.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_Kana.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_Kana.TabStop = True
		Me.HD_Kana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.HD_Kana.Name = "HD_Kana"
		Me.HD_RN.AutoSize = False
		Me.HD_RN.Size = New System.Drawing.Size(268, 25)
		Me.HD_RN.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_RN.Location = New System.Drawing.Point(288, 40)
		Me.HD_RN.Maxlength = 40
		Me.HD_RN.TabIndex = 3
		Me.HD_RN.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
		Me.HD_RN.AcceptsReturn = True
		Me.HD_RN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_RN.BackColor = System.Drawing.SystemColors.Window
		Me.HD_RN.CausesValidation = True
		Me.HD_RN.Enabled = True
		Me.HD_RN.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_RN.HideSelection = True
		Me.HD_RN.ReadOnly = False
		Me.HD_RN.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_RN.MultiLine = False
		Me.HD_RN.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_RN.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_RN.TabStop = True
		Me.HD_RN.Visible = True
		Me.HD_RN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_RN.Name = "HD_RN"
		Me.HD_TEXT.AutoSize = False
		Me.HD_TEXT.Size = New System.Drawing.Size(67, 25)
		Me.HD_TEXT.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_TEXT.Location = New System.Drawing.Point(80, 40)
		Me.HD_TEXT.Maxlength = 13
		Me.HD_TEXT.TabIndex = 2
		Me.HD_TEXT.Text = "XXXXX"
		Me.HD_TEXT.AcceptsReturn = True
		Me.HD_TEXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_TEXT.BackColor = System.Drawing.SystemColors.Window
		Me.HD_TEXT.CausesValidation = True
		Me.HD_TEXT.Enabled = True
		Me.HD_TEXT.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_TEXT.HideSelection = True
		Me.HD_TEXT.ReadOnly = False
		Me.HD_TEXT.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_TEXT.MultiLine = False
		Me.HD_TEXT.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_TEXT.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_TEXT.TabStop = True
		Me.HD_TEXT.Visible = True
		Me.HD_TEXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_TEXT.Name = "HD_TEXT"
		Me.Panel3D4.Size = New System.Drawing.Size(73, 25)
		Me.Panel3D4.Location = New System.Drawing.Point(6, 40)
		Me.Panel3D4.TabIndex = 8
		Me.Panel3D4.BackColor = 12632256
		Me.Panel3D4.ForeColor = 0
		Me.Panel3D4.BevelOuter = 1
		Me.Panel3D4.Caption = "開始ｺｰﾄﾞ"
		Me.Panel3D4.OutLine = -1
		Me.Panel3D4.RoundedCorners = 0
		Me.Panel3D4.Name = "Panel3D4"
		Me.SSPanel51.Size = New System.Drawing.Size(113, 25)
		Me.SSPanel51.Location = New System.Drawing.Point(176, 40)
		Me.SSPanel51.TabIndex = 10
		Me.SSPanel51.BackColor = 12632256
		Me.SSPanel51.ForeColor = 0
		Me.SSPanel51.BevelOuter = 1
		Me.SSPanel51.Caption = "得意先略称"
		Me.SSPanel51.OutLine = -1
		Me.SSPanel51.RoundedCorners = 0
		Me.SSPanel51.Name = "SSPanel51"
		Me._PNL_USENM_3.Size = New System.Drawing.Size(82, 25)
		Me._PNL_USENM_3.Location = New System.Drawing.Point(584, 40)
		Me._PNL_USENM_3.TabIndex = 12
		Me._PNL_USENM_3.BackColor = 12632256
		Me._PNL_USENM_3.ForeColor = 0
		Me._PNL_USENM_3.BevelOuter = 1
		Me._PNL_USENM_3.Caption = "カナ検索"
		Me._PNL_USENM_3.OutLine = -1
		Me._PNL_USENM_3.RoundedCorners = 0
		Me._PNL_USENM_3.Name = "_PNL_USENM_3"
		Me._SSPanel52_0.Size = New System.Drawing.Size(139, 25)
		Me._SSPanel52_0.Location = New System.Drawing.Point(8, 8)
		Me._SSPanel52_0.TabIndex = 13
		Me._SSPanel52_0.BackColor = 12632256
		Me._SSPanel52_0.ForeColor = 0
		Me._SSPanel52_0.Alignment = 1
		Me._SSPanel52_0.BevelOuter = 1
		Me._SSPanel52_0.Caption = "*取引先分類"
		Me._SSPanel52_0.OutLine = -1
		Me._SSPanel52_0.RoundedCorners = 0
		Me._SSPanel52_0.Name = "_SSPanel52_0"
		Me._SSPanel52_1.Size = New System.Drawing.Size(275, 25)
		Me._SSPanel52_1.Location = New System.Drawing.Point(162, 8)
		Me._SSPanel52_1.TabIndex = 14
		Me._SSPanel52_1.BackColor = 12632256
		Me._SSPanel52_1.ForeColor = 0
		Me._SSPanel52_1.Alignment = 1
		Me._SSPanel52_1.BevelOuter = 1
		Me._SSPanel52_1.Caption = "1:得意先 2:仕入先"
		Me._SSPanel52_1.OutLine = -1
		Me._SSPanel52_1.RoundedCorners = 0
		Me._SSPanel52_1.Name = "_SSPanel52_1"
		Me._IM_MAE_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_MAE_0.Location = New System.Drawing.Point(255, 408)
		Me._IM_MAE_0.Image = CType(resources.GetObject("_IM_MAE_0.Image"), System.Drawing.Image)
		Me._IM_MAE_0.Visible = False
		Me._IM_MAE_0.Enabled = True
		Me._IM_MAE_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_MAE_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_MAE_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_MAE_0.Name = "_IM_MAE_0"
		Me._IM_ATO_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_ATO_0.Location = New System.Drawing.Point(315, 408)
		Me._IM_ATO_0.Image = CType(resources.GetObject("_IM_ATO_0.Image"), System.Drawing.Image)
		Me._IM_ATO_0.Visible = False
		Me._IM_ATO_0.Enabled = True
		Me._IM_ATO_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_ATO_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_ATO_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_ATO_0.Name = "_IM_ATO_0"
		Me._IM_ATO_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_ATO_1.Location = New System.Drawing.Point(342, 408)
		Me._IM_ATO_1.Image = CType(resources.GetObject("_IM_ATO_1.Image"), System.Drawing.Image)
		Me._IM_ATO_1.Visible = False
		Me._IM_ATO_1.Enabled = True
		Me._IM_ATO_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_ATO_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_ATO_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_ATO_1.Name = "_IM_ATO_1"
		Me._IM_MAE_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_MAE_1.Location = New System.Drawing.Point(282, 408)
		Me._IM_MAE_1.Image = CType(resources.GetObject("_IM_MAE_1.Image"), System.Drawing.Image)
		Me._IM_MAE_1.Visible = False
		Me._IM_MAE_1.Enabled = True
		Me._IM_MAE_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_MAE_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_MAE_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_MAE_1.Name = "_IM_MAE_1"
		Me.WLSMAE.Size = New System.Drawing.Size(24, 22)
		Me.WLSMAE.Location = New System.Drawing.Point(243, 332)
		Me.WLSMAE.Image = CType(resources.GetObject("WLSMAE.Image"), System.Drawing.Image)
		Me.WLSMAE.Enabled = True
		Me.WLSMAE.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSMAE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.WLSMAE.Visible = True
		Me.WLSMAE.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.WLSMAE.Name = "WLSMAE"
		Me.WLSATO.Size = New System.Drawing.Size(24, 22)
		Me.WLSATO.Location = New System.Drawing.Point(408, 332)
		Me.WLSATO.Image = CType(resources.GetObject("WLSATO.Image"), System.Drawing.Image)
		Me.WLSATO.Enabled = True
		Me.WLSATO.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSATO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.WLSATO.Visible = True
		Me.WLSATO.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.WLSATO.Name = "WLSATO"
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
		Me.Panel3D1.Controls.Add(HD_BUNRUI)
		Me.Panel3D1.Controls.Add(WLSKANA)
		Me.Panel3D1.Controls.Add(HD_Kana)
		Me.Panel3D1.Controls.Add(HD_RN)
		Me.Panel3D1.Controls.Add(HD_TEXT)
		Me.Panel3D1.Controls.Add(Panel3D4)
		Me.Panel3D1.Controls.Add(SSPanel51)
		Me.Panel3D1.Controls.Add(_PNL_USENM_3)
		Me.Panel3D1.Controls.Add(_SSPanel52_0)
		Me.Panel3D1.Controls.Add(_SSPanel52_1)
		Me.IM_ATO.SetIndex(_IM_ATO_0, CType(0, Short))
		Me.IM_ATO.SetIndex(_IM_ATO_1, CType(1, Short))
		Me.IM_MAE.SetIndex(_IM_MAE_0, CType(0, Short))
		Me.IM_MAE.SetIndex(_IM_MAE_1, CType(1, Short))
		Me.PNL_USENM.SetIndex(_PNL_USENM_3, CType(3, Short))
		Me.SSPanel52.SetIndex(_SSPanel52_0, CType(0, Short))
		Me.SSPanel52.SetIndex(_SSPanel52_1, CType(1, Short))
		CType(Me.SSPanel52, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PNL_USENM, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel3D1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class