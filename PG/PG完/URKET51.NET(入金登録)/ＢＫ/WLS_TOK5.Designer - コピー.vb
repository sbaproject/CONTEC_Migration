<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class WLSTOK5
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
	Public WithEvents COM_TOKCD As System.Windows.Forms.Button
    Public WithEvents WLSLABEL As System.Windows.Forms.Label
	Public WithEvents LST As System.Windows.Forms.ListBox
	Public WithEvents WLSOK As System.Windows.Forms.Button
	Public WithEvents WLSCANCEL As System.Windows.Forms.Button
	Public WithEvents HD_NAME As System.Windows.Forms.TextBox
	Public WithEvents HD_CODE As System.Windows.Forms.TextBox
    Public WithEvents SSPanel51 As System.Windows.Forms.Label
	Public WithEvents Panel3D1 As System.Windows.Forms.Label
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
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WLSTOK5))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.COM_TOKCD = New System.Windows.Forms.Button
        Me.WLSLABEL = New System.Windows.Forms.Label
		Me.LST = New System.Windows.Forms.ListBox
		Me.WLSOK = New System.Windows.Forms.Button
		Me.WLSCANCEL = New System.Windows.Forms.Button
        Me.Panel3D1 = New System.Windows.Forms.Label
		Me.HD_NAME = New System.Windows.Forms.TextBox
		Me.HD_CODE = New System.Windows.Forms.TextBox
        Me.SSPanel51 = New System.Windows.Forms.Label
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
		Me.Text = "請求先検索"
		Me.ClientSize = New System.Drawing.Size(954, 348)
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
		Me.Name = "WLSTOK5"
		Me.COM_TOKCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.COM_TOKCD.BackColor = System.Drawing.SystemColors.Control
		Me.COM_TOKCD.Text = "得意先 "
		Me.COM_TOKCD.Size = New System.Drawing.Size(98, 25)
		Me.COM_TOKCD.Location = New System.Drawing.Point(3, 7)
		Me.COM_TOKCD.TabIndex = 8
		Me.COM_TOKCD.TabStop = False
		Me.COM_TOKCD.CausesValidation = True
		Me.COM_TOKCD.Enabled = True
		Me.COM_TOKCD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.COM_TOKCD.Cursor = System.Windows.Forms.Cursors.Default
		Me.COM_TOKCD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.COM_TOKCD.Name = "COM_TOKCD"
		Me.WLSLABEL.Size = New System.Drawing.Size(945, 25)
		Me.WLSLABEL.Location = New System.Drawing.Point(3, 40)
		Me.WLSLABEL.TabIndex = 6
        'Me.WLSLABEL.BackColor = 12632256
        'Me.WLSLABEL.ForeColor = 0
        'Me.WLSLABEL.Alignment = 1
        'Me.WLSLABEL.BevelOuter = 1
        Me.WLSLABEL.Text = "請求先ｺｰﾄﾞ      請求略称名                                    得意先ｺｰﾄﾞ  得意先略称名"
        'Me.WLSLABEL.OutLine = -1
        'Me.WLSLABEL.RoundedCorners = 0
		Me.WLSLABEL.Name = "WLSLABEL"
		Me.LST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LST.Size = New System.Drawing.Size(945, 245)
		Me.LST.Location = New System.Drawing.Point(3, 64)
		Me.LST.Items.AddRange(New Object(){"XXXXXXXXX1      MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4      XXXXXXXXX1  MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"})
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
		Me.WLSOK.Location = New System.Drawing.Point(415, 316)
		Me.WLSOK.TabIndex = 3
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
		Me.WLSCANCEL.Location = New System.Drawing.Point(478, 316)
		Me.WLSCANCEL.TabIndex = 4
		Me.WLSCANCEL.CausesValidation = True
		Me.WLSCANCEL.Enabled = True
		Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
		Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WLSCANCEL.TabStop = True
		Me.WLSCANCEL.Name = "WLSCANCEL"
		Me.Panel3D1.Size = New System.Drawing.Size(954, 37)
		Me.Panel3D1.Location = New System.Drawing.Point(0, 0)
		Me.Panel3D1.TabIndex = 5
        'Me.Panel3D1.BackColor = 12632256
        'Me.Panel3D1.ForeColor = 0
        'Me.Panel3D1.OutLine = -1
		Me.Panel3D1.Name = "Panel3D1"
		Me.HD_NAME.AutoSize = False
		Me.HD_NAME.Size = New System.Drawing.Size(340, 25)
		Me.HD_NAME.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_NAME.Location = New System.Drawing.Point(265, 6)
		Me.HD_NAME.Maxlength = 40
		Me.HD_NAME.TabIndex = 2
		Me.HD_NAME.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
		Me.HD_NAME.AcceptsReturn = True
		Me.HD_NAME.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.HD_NAME.BackColor = System.Drawing.SystemColors.Window
		Me.HD_NAME.CausesValidation = True
		Me.HD_NAME.Enabled = True
		Me.HD_NAME.ForeColor = System.Drawing.SystemColors.WindowText
		Me.HD_NAME.HideSelection = True
		Me.HD_NAME.ReadOnly = False
		Me.HD_NAME.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.HD_NAME.MultiLine = False
		Me.HD_NAME.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HD_NAME.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.HD_NAME.TabStop = True
		Me.HD_NAME.Visible = True
		Me.HD_NAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.HD_NAME.Name = "HD_NAME"
		Me.HD_CODE.AutoSize = False
		Me.HD_CODE.Size = New System.Drawing.Size(59, 25)
		Me.HD_CODE.IMEMode = System.Windows.Forms.ImeMode.Off
		Me.HD_CODE.Location = New System.Drawing.Point(100, 6)
		Me.HD_CODE.Maxlength = 5
		Me.HD_CODE.TabIndex = 1
		Me.HD_CODE.Text = "XXXXX"
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
		Me.SSPanel51.Size = New System.Drawing.Size(109, 25)
		Me.SSPanel51.Location = New System.Drawing.Point(157, 6)
		Me.SSPanel51.TabIndex = 7
        'Me.SSPanel51.BackColor = 12632256
        'Me.SSPanel51.ForeColor = 0
        'Me.SSPanel51.BevelOuter = 1
        Me.SSPanel51.Text = "得意先略称"
        'Me.SSPanel51.OutLine = -1
        'Me.SSPanel51.RoundedCorners = 0
		Me.SSPanel51.Name = "SSPanel51"
		Me._IM_MAE_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_MAE_0.Location = New System.Drawing.Point(351, 408)
		Me._IM_MAE_0.Image = CType(resources.GetObject("_IM_MAE_0.Image"), System.Drawing.Image)
		Me._IM_MAE_0.Visible = False
		Me._IM_MAE_0.Enabled = True
		Me._IM_MAE_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_MAE_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_MAE_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_MAE_0.Name = "_IM_MAE_0"
		Me._IM_ATO_0.Size = New System.Drawing.Size(24, 22)
		Me._IM_ATO_0.Location = New System.Drawing.Point(411, 408)
		Me._IM_ATO_0.Image = CType(resources.GetObject("_IM_ATO_0.Image"), System.Drawing.Image)
		Me._IM_ATO_0.Visible = False
		Me._IM_ATO_0.Enabled = True
		Me._IM_ATO_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_ATO_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_ATO_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_ATO_0.Name = "_IM_ATO_0"
		Me._IM_ATO_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_ATO_1.Location = New System.Drawing.Point(438, 408)
		Me._IM_ATO_1.Image = CType(resources.GetObject("_IM_ATO_1.Image"), System.Drawing.Image)
		Me._IM_ATO_1.Visible = False
		Me._IM_ATO_1.Enabled = True
		Me._IM_ATO_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_ATO_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_ATO_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_ATO_1.Name = "_IM_ATO_1"
		Me._IM_MAE_1.Size = New System.Drawing.Size(24, 22)
		Me._IM_MAE_1.Location = New System.Drawing.Point(378, 408)
		Me._IM_MAE_1.Image = CType(resources.GetObject("_IM_MAE_1.Image"), System.Drawing.Image)
		Me._IM_MAE_1.Visible = False
		Me._IM_MAE_1.Enabled = True
		Me._IM_MAE_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._IM_MAE_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._IM_MAE_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._IM_MAE_1.Name = "_IM_MAE_1"
		Me.WLSMAE.Size = New System.Drawing.Size(24, 22)
		Me.WLSMAE.Location = New System.Drawing.Point(382, 316)
		Me.WLSMAE.Image = CType(resources.GetObject("WLSMAE.Image"), System.Drawing.Image)
		Me.WLSMAE.Enabled = True
		Me.WLSMAE.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSMAE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.WLSMAE.Visible = True
		Me.WLSMAE.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.WLSMAE.Name = "WLSMAE"
		Me.WLSATO.Size = New System.Drawing.Size(24, 22)
		Me.WLSATO.Location = New System.Drawing.Point(547, 316)
		Me.WLSATO.Image = CType(resources.GetObject("WLSATO.Image"), System.Drawing.Image)
		Me.WLSATO.Enabled = True
		Me.WLSATO.Cursor = System.Windows.Forms.Cursors.Default
		Me.WLSATO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.WLSATO.Visible = True
		Me.WLSATO.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.WLSATO.Name = "WLSATO"
		Me.Controls.Add(COM_TOKCD)
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
		Me.Panel3D1.Controls.Add(HD_NAME)
		Me.Panel3D1.Controls.Add(HD_CODE)
		Me.Panel3D1.Controls.Add(SSPanel51)
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