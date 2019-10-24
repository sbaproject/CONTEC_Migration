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
    Public WithEvents WLSLABEL As Label
    Public WithEvents LST As System.Windows.Forms.ListBox
	Public WithEvents WLSOK As System.Windows.Forms.Button
	Public WithEvents WLSCANCEL As System.Windows.Forms.Button
	Public WithEvents COM_HINKB As System.Windows.Forms.Button
	Public WithEvents WLSHINKB As System.Windows.Forms.TextBox
	Public WithEvents WLSKANA As System.Windows.Forms.ComboBox
	Public WithEvents HD_Kana As System.Windows.Forms.TextBox
	Public WithEvents HD_NMA As System.Windows.Forms.TextBox
	Public WithEvents HD_TEXT As System.Windows.Forms.TextBox
    Public WithEvents Panel3D4 As Label
    Public WithEvents SSPanel51 As Label
    Public WithEvents _PNL_USENM_3 As Label
    Public WithEvents WLSHINKBNM As System.Windows.Forms.Label
    Public WithEvents Panel3D1 As Label
    Public WithEvents _IM_MAE_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_ATO_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_ATO_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_MAE_1 As System.Windows.Forms.PictureBox
	Public WithEvents WLSMAE As System.Windows.Forms.PictureBox
	Public WithEvents WLSATO As System.Windows.Forms.PictureBox
	Public WithEvents IM_ATO As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_MAE As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    Public WithEvents PNL_USENM As VB6.PanelArray
    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更できます。
    'コード エディタを使用して、変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WLSHIN))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
        Me.WLSLABEL = New Label
        Me.LST = New System.Windows.Forms.ListBox
		Me.WLSOK = New System.Windows.Forms.Button
		Me.WLSCANCEL = New System.Windows.Forms.Button
        Me.Panel3D1 = New Label
        Me.COM_HINKB = New System.Windows.Forms.Button
		Me.WLSHINKB = New System.Windows.Forms.TextBox
		Me.WLSKANA = New System.Windows.Forms.ComboBox
		Me.HD_Kana = New System.Windows.Forms.TextBox
		Me.HD_NMA = New System.Windows.Forms.TextBox
		Me.HD_TEXT = New System.Windows.Forms.TextBox
        Me.Panel3D4 = New Label
        Me.SSPanel51 = New Label
        Me._PNL_USENM_3 = New Label
        Me.WLSHINKBNM = New System.Windows.Forms.Label
		Me._IM_MAE_0 = New System.Windows.Forms.PictureBox
		Me._IM_ATO_0 = New System.Windows.Forms.PictureBox
		Me._IM_ATO_1 = New System.Windows.Forms.PictureBox
		Me._IM_MAE_1 = New System.Windows.Forms.PictureBox
		Me.WLSMAE = New System.Windows.Forms.PictureBox
		Me.WLSATO = New System.Windows.Forms.PictureBox
		Me.IM_ATO = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.IM_MAE = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
        Me.PNL_USENM = New VB6.PanelArray(components)
        Me.Panel3D1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PNL_USENM, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "製品一覧ウィンドウ"
		Me.ClientSize = New System.Drawing.Size(767, 408)
		Me.Location = New System.Drawing.Point(25, 207)
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
		Me.WLSLABEL.Size = New System.Drawing.Size(753, 25)
		Me.WLSLABEL.Location = New System.Drawing.Point(3, 80)
		Me.WLSLABEL.TabIndex = 9
        'Me.WLSLABEL.BackColor = 12632256
        Me.WLSLABEL.ForeColor = Color.Empty
        'Me.WLSLABEL.Alignment = 1
        'Me.WLSLABEL.BevelOuter = 1
        Me.WLSLABEL.Text = "WLSLABEL"
        'Me.WLSLABEL.OutLine = -1
        'Me.WLSLABEL.RoundedCorners = 0
        Me.WLSLABEL.Name = "WLSLABEL"
		Me.LST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LST.Size = New System.Drawing.Size(753, 245)
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
		Me.WLSOK.Location = New System.Drawing.Point(282, 367)
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
		Me.WLSCANCEL.Location = New System.Drawing.Point(345, 367)
		Me.WLSCANCEL.TabIndex = 6
		Me.WLSCANCEL.CausesValidation = True
		Me.WLSCANCEL.Enabled = True
		Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
		Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSCANCEL.TabStop = True
		Me.WLSCANCEL.Name = "WLSCANCEL"
		Me.Panel3D1.Size = New System.Drawing.Size(769, 75)
		Me.Panel3D1.Location = New System.Drawing.Point(0, 0)
		Me.Panel3D1.TabIndex = 7
        'Me.Panel3D1.BackColor = 12632256
        Me.Panel3D1.ForeColor = Color.Empty
        'Me.Panel3D1.OutLine = -1
        Me.Panel3D1.Name = "Panel3D1"
		Me.COM_HINKB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.COM_HINKB.BackColor = System.Drawing.SystemColors.Control
		Me.COM_HINKB.Text = "商品区分"
		Me.COM_HINKB.Size = New System.Drawing.Size(86, 25)
		Me.COM_HINKB.Location = New System.Drawing.Point(8, 8)
		Me.COM_HINKB.TabIndex = 13
		Me.COM_HINKB.TabStop = False
		Me.COM_HINKB.CausesValidation = True
		Me.COM_HINKB.Enabled = True
		Me.COM_HINKB.ForeColor = System.Drawing.SystemColors.ControlText
		Me.COM_HINKB.Cursor = System.Windows.Forms.Cursors.Default
		Me.COM_HINKB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.COM_HINKB.Name = "COM_HINKB"
		Me.WLSHINKB.AutoSize = False
		Me.WLSHINKB.Size = New System.Drawing.Size(29, 25)
		Me.WLSHINKB.Location = New System.Drawing.Point(92, 8)
		Me.WLSHINKB.Maxlength = 2
		Me.WLSHINKB.TabIndex = 1
		Me.WLSHINKB.AcceptsReturn = True
		Me.WLSHINKB.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.WLSHINKB.BackColor = System.Drawing.SystemColors.Window
		Me.WLSHINKB.CausesValidation = True
		Me.WLSHINKB.Enabled = True
		Me.WLSHINKB.ForeColor = System.Drawing.SystemColors.WindowText
		Me.WLSHINKB.HideSelection = True
		Me.WLSHINKB.ReadOnly = False
		Me.WLSHINKB.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.WLSHINKB.MultiLine = False
		Me.WLSHINKB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSHINKB.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.WLSHINKB.TabStop = True
		Me.WLSHINKB.Visible = True
		Me.WLSHINKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.WLSHINKB.Name = "WLSHINKB"
		Me.WLSKANA.Size = New System.Drawing.Size(82, 24)
		Me.WLSKANA.Location = New System.Drawing.Point(675, 8)
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
		Me.HD_Kana.AutoSize = False
		Me.HD_Kana.Size = New System.Drawing.Size(49, 25)
		Me.HD_Kana.IMEMode = System.Windows.Forms.ImeMode.KatakanaHalf
		Me.HD_Kana.Location = New System.Drawing.Point(624, 8)
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
		Me.HD_NMA.AutoSize = False
		Me.HD_NMA.Size = New System.Drawing.Size(253, 25)
		Me.HD_NMA.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_NMA.Location = New System.Drawing.Point(323, 8)
		Me.HD_NMA.Maxlength = 30
		Me.HD_NMA.TabIndex = 2
		Me.HD_NMA.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
		Me.HD_NMA.AcceptsReturn = True
		Me.HD_NMA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_NMA.BackColor = System.Drawing.SystemColors.Window
		Me.HD_NMA.CausesValidation = True
		Me.HD_NMA.Enabled = True
		Me.HD_NMA.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_NMA.HideSelection = True
		Me.HD_NMA.ReadOnly = False
		Me.HD_NMA.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_NMA.MultiLine = False
		Me.HD_NMA.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_NMA.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_NMA.TabStop = True
		Me.HD_NMA.Visible = True
		Me.HD_NMA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_NMA.Name = "HD_NMA"
		Me.HD_TEXT.AutoSize = False
		Me.HD_TEXT.Size = New System.Drawing.Size(77, 25)
		Me.HD_TEXT.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_TEXT.Location = New System.Drawing.Point(113, 40)
		Me.HD_TEXT.Maxlength = 10
		Me.HD_TEXT.TabIndex = 4
		Me.HD_TEXT.Text = "XXXXXXXX"
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
		Me.Panel3D4.Size = New System.Drawing.Size(108, 25)
		Me.Panel3D4.Location = New System.Drawing.Point(8, 40)
		Me.Panel3D4.TabIndex = 8
        'Me.Panel3D4.BackColor = 12632256
        Me.Panel3D4.ForeColor = Color.Empty
        'Me.Panel3D4.BevelOuter = 1
        Me.Panel3D4.Text = "開始製品ｺｰﾄﾞ"
        'Me.Panel3D4.OutLine = -1
        'Me.Panel3D4.RoundedCorners = 0
        Me.Panel3D4.Name = "Panel3D4"
		Me.SSPanel51.Size = New System.Drawing.Size(52, 25)
		Me.SSPanel51.Location = New System.Drawing.Point(272, 8)
		Me.SSPanel51.TabIndex = 10
        'Me.SSPanel51.BackColor = 12632256
        Me.SSPanel51.ForeColor = Color.Empty
        'Me.SSPanel51.BevelOuter = 1
        Me.SSPanel51.Text = "型式"
        'Me.SSPanel51.OutLine = -1
        'Me.SSPanel51.RoundedCorners = 0
        Me.SSPanel51.Name = "SSPanel51"
		Me._PNL_USENM_3.Size = New System.Drawing.Size(82, 25)
		Me._PNL_USENM_3.Location = New System.Drawing.Point(592, 8)
		Me._PNL_USENM_3.TabIndex = 12
        'Me._PNL_USENM_3.BackColor = 12632256
        Me._PNL_USENM_3.ForeColor = Color.Empty
        'Me._PNL_USENM_3.BevelOuter = 1
        Me._PNL_USENM_3.Text = "カナ検索"
        'Me._PNL_USENM_3.OutLine = -1
        'Me._PNL_USENM_3.RoundedCorners = 0
        Me._PNL_USENM_3.Name = "_PNL_USENM_3"
		Me.WLSHINKBNM.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.WLSHINKBNM.ForeColor = System.Drawing.SystemColors.WindowText
		Me.WLSHINKBNM.Size = New System.Drawing.Size(137, 25)
		Me.WLSHINKBNM.Location = New System.Drawing.Point(120, 8)
		Me.WLSHINKBNM.TabIndex = 14
		Me.WLSHINKBNM.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.WLSHINKBNM.Enabled = True
		Me.WLSHINKBNM.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSHINKBNM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSHINKBNM.UseMnemonic = True
		Me.WLSHINKBNM.Visible = True
		Me.WLSHINKBNM.AutoSize = False
		Me.WLSHINKBNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.WLSHINKBNM.Name = "WLSHINKBNM"
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
		Me.WLSMAE.Location = New System.Drawing.Point(249, 367)
		Me.WLSMAE.Image = CType(resources.GetObject("WLSMAE.Image"), System.Drawing.Image)
		Me.WLSMAE.Enabled = True
		Me.WLSMAE.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSMAE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.WLSMAE.Visible = True
		Me.WLSMAE.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.WLSMAE.Name = "WLSMAE"
		Me.WLSATO.Size = New System.Drawing.Size(24, 22)
		Me.WLSATO.Location = New System.Drawing.Point(414, 367)
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
		Me.Panel3D1.Controls.Add(COM_HINKB)
		Me.Panel3D1.Controls.Add(WLSHINKB)
		Me.Panel3D1.Controls.Add(WLSKANA)
		Me.Panel3D1.Controls.Add(HD_Kana)
		Me.Panel3D1.Controls.Add(HD_NMA)
		Me.Panel3D1.Controls.Add(HD_TEXT)
		Me.Panel3D1.Controls.Add(Panel3D4)
		Me.Panel3D1.Controls.Add(SSPanel51)
		Me.Panel3D1.Controls.Add(_PNL_USENM_3)
		Me.Panel3D1.Controls.Add(WLSHINKBNM)
		Me.IM_ATO.SetIndex(_IM_ATO_0, CType(0, Short))
		Me.IM_ATO.SetIndex(_IM_ATO_1, CType(1, Short))
		Me.IM_MAE.SetIndex(_IM_MAE_0, CType(0, Short))
		Me.IM_MAE.SetIndex(_IM_MAE_1, CType(1, Short))
        'Me.PNL_USENM.SetIndex(_PNL_USENM_3, CType(3, Short))
        CType(Me.PNL_USENM, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel3D1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class