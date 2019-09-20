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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WLS_HCP))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Picture1 = New System.Windows.Forms.PictureBox()
        Me.Frame3 = New System.Windows.Forms.GroupBox()
        Me._OptOrient_1 = New System.Windows.Forms.RadioButton()
        Me._OptOrient_0 = New System.Windows.Forms.RadioButton()
        Me.ImgOrient = New System.Windows.Forms.PictureBox()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.CmbFormDefault = New System.Windows.Forms.ComboBox()
        Me.CmbForm = New System.Windows.Forms.ComboBox()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.CHK_DEFAULT_PRN = New System.Windows.Forms.CheckBox()
        Me.CmbPrn = New System.Windows.Forms.ComboBox()
        Me.WLSOK = New System.Windows.Forms.Button()
        Me.WLSCANCEL = New System.Windows.Forms.Button()
        Me._ImgLib_0 = New System.Windows.Forms.PictureBox()
        Me._ImgLib_1 = New System.Windows.Forms.PictureBox()
        Me.ImgLib = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.OptOrient = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(Me.components)
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame3.SuspendLayout()
        CType(Me.ImgOrient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        CType(Me._ImgLib_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._ImgLib_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLib, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptOrient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Control
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.Location = New System.Drawing.Point(120, 291)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(34, 28)
        Me.Picture1.TabIndex = 9
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me._OptOrient_1)
        Me.Frame3.Controls.Add(Me._OptOrient_0)
        Me.Frame3.Controls.Add(Me.ImgOrient)
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(204, 102)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(145, 82)
        Me.Frame3.TabIndex = 5
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "印刷の向き"
        '
        '_OptOrient_1
        '
        Me._OptOrient_1.BackColor = System.Drawing.SystemColors.Control
        Me._OptOrient_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._OptOrient_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OptOrient.SetIndex(Me._OptOrient_1, CType(1, Short))
        Me._OptOrient_1.Location = New System.Drawing.Point(81, 48)
        Me._OptOrient_1.Name = "_OptOrient_1"
        Me._OptOrient_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._OptOrient_1.Size = New System.Drawing.Size(49, 25)
        Me._OptOrient_1.TabIndex = 8
        Me._OptOrient_1.Text = "横"
        Me._OptOrient_1.UseVisualStyleBackColor = False
        '
        '_OptOrient_0
        '
        Me._OptOrient_0.BackColor = System.Drawing.SystemColors.Control
        Me._OptOrient_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._OptOrient_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OptOrient.SetIndex(Me._OptOrient_0, CType(0, Short))
        Me._OptOrient_0.Location = New System.Drawing.Point(81, 18)
        Me._OptOrient_0.Name = "_OptOrient_0"
        Me._OptOrient_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._OptOrient_0.Size = New System.Drawing.Size(49, 25)
        Me._OptOrient_0.TabIndex = 7
        Me._OptOrient_0.Text = "縦"
        Me._OptOrient_0.UseVisualStyleBackColor = False
        '
        'ImgOrient
        '
        Me.ImgOrient.Cursor = System.Windows.Forms.Cursors.Default
        Me.ImgOrient.Location = New System.Drawing.Point(18, 30)
        Me.ImgOrient.Name = "ImgOrient"
        Me.ImgOrient.Size = New System.Drawing.Size(31, 31)
        Me.ImgOrient.TabIndex = 9
        Me.ImgOrient.TabStop = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.CmbFormDefault)
        Me.Frame2.Controls.Add(Me.CmbForm)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(6, 102)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(193, 82)
        Me.Frame2.TabIndex = 4
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "用紙のサイズ"
        '
        'CmbFormDefault
        '
        Me.CmbFormDefault.BackColor = System.Drawing.SystemColors.Window
        Me.CmbFormDefault.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmbFormDefault.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmbFormDefault.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbFormDefault.Items.AddRange(New Object() {"ﾃﾞﾌｫﾙﾄ用紙"})
        Me.CmbFormDefault.Location = New System.Drawing.Point(15, 30)
        Me.CmbFormDefault.Name = "CmbFormDefault"
        Me.CmbFormDefault.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmbFormDefault.Size = New System.Drawing.Size(160, 26)
        Me.CmbFormDefault.TabIndex = 11
        Me.CmbFormDefault.Text = "ﾃﾞﾌｫﾙﾄ用紙サイズ"
        '
        'CmbForm
        '
        Me.CmbForm.BackColor = System.Drawing.SystemColors.Window
        Me.CmbForm.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmbForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbForm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmbForm.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbForm.Items.AddRange(New Object() {"A3 297x420 mm", "A4 210x297 mm", "A5 148x210 mm", "B4 257x364 mm", "B5 182x257 mm"})
        Me.CmbForm.Location = New System.Drawing.Point(15, 30)
        Me.CmbForm.Name = "CmbForm"
        Me.CmbForm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmbForm.Size = New System.Drawing.Size(160, 26)
        Me.CmbForm.TabIndex = 6
        Me.CmbForm.TabStop = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.CHK_DEFAULT_PRN)
        Me.Frame1.Controls.Add(Me.CmbPrn)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(6, 9)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(436, 82)
        Me.Frame1.TabIndex = 2
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "ﾌﾟﾘﾝﾀ"
        '
        'CHK_DEFAULT_PRN
        '
        Me.CHK_DEFAULT_PRN.BackColor = System.Drawing.SystemColors.Control
        Me.CHK_DEFAULT_PRN.Cursor = System.Windows.Forms.Cursors.Default
        Me.CHK_DEFAULT_PRN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHK_DEFAULT_PRN.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CHK_DEFAULT_PRN.Location = New System.Drawing.Point(225, 51)
        Me.CHK_DEFAULT_PRN.Name = "CHK_DEFAULT_PRN"
        Me.CHK_DEFAULT_PRN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CHK_DEFAULT_PRN.Size = New System.Drawing.Size(202, 19)
        Me.CHK_DEFAULT_PRN.TabIndex = 10
        Me.CHK_DEFAULT_PRN.Text = "ﾃﾞﾌｫﾙﾄﾌﾟﾘﾝﾀのﾃﾞﾌｫﾙﾄ用紙を使う"
        Me.CHK_DEFAULT_PRN.UseVisualStyleBackColor = False
        '
        'CmbPrn
        '
        Me.CmbPrn.BackColor = System.Drawing.SystemColors.Window
        Me.CmbPrn.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmbPrn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPrn.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmbPrn.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbPrn.Location = New System.Drawing.Point(15, 24)
        Me.CmbPrn.Name = "CmbPrn"
        Me.CmbPrn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmbPrn.Size = New System.Drawing.Size(409, 26)
        Me.CmbPrn.TabIndex = 3
        Me.CmbPrn.TabStop = False
        '
        'WLSOK
        '
        Me.WLSOK.BackColor = System.Drawing.SystemColors.Control
        Me.WLSOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WLSOK.Location = New System.Drawing.Point(366, 109)
        Me.WLSOK.Name = "WLSOK"
        Me.WLSOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSOK.Size = New System.Drawing.Size(69, 28)
        Me.WLSOK.TabIndex = 0
        Me.WLSOK.Text = "印刷"
        Me.WLSOK.UseVisualStyleBackColor = False
        '
        'WLSCANCEL
        '
        Me.WLSCANCEL.BackColor = System.Drawing.SystemColors.Control
        Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WLSCANCEL.Location = New System.Drawing.Point(366, 153)
        Me.WLSCANCEL.Name = "WLSCANCEL"
        Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSCANCEL.Size = New System.Drawing.Size(69, 28)
        Me.WLSCANCEL.TabIndex = 1
        Me.WLSCANCEL.Text = "ｷｬﾝｾﾙ"
        Me.WLSCANCEL.UseVisualStyleBackColor = False
        '
        '_ImgLib_0
        '
        Me._ImgLib_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._ImgLib_0.Image = CType(resources.GetObject("_ImgLib_0.Image"), System.Drawing.Image)
        Me.ImgLib.SetIndex(Me._ImgLib_0, CType(0, Short))
        Me._ImgLib_0.Location = New System.Drawing.Point(24, 288)
        Me._ImgLib_0.Name = "_ImgLib_0"
        Me._ImgLib_0.Size = New System.Drawing.Size(28, 31)
        Me._ImgLib_0.TabIndex = 10
        Me._ImgLib_0.TabStop = False
        '
        '_ImgLib_1
        '
        Me._ImgLib_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._ImgLib_1.Image = CType(resources.GetObject("_ImgLib_1.Image"), System.Drawing.Image)
        Me.ImgLib.SetIndex(Me._ImgLib_1, CType(1, Short))
        Me._ImgLib_1.Location = New System.Drawing.Point(63, 288)
        Me._ImgLib_1.Name = "_ImgLib_1"
        Me._ImgLib_1.Size = New System.Drawing.Size(31, 27)
        Me._ImgLib_1.TabIndex = 11
        Me._ImgLib_1.TabStop = False
        '
        'OptOrient
        '
        '
        'WLS_HCP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(456, 200)
        Me.ControlBox = False
        Me.Controls.Add(Me.Picture1)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.WLSOK)
        Me.Controls.Add(Me.WLSCANCEL)
        Me.Controls.Add(Me._ImgLib_0)
        Me.Controls.Add(Me._ImgLib_1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(107, 214)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WLS_HCP"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "メイン画面印刷"
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame3.ResumeLayout(False)
        CType(Me.ImgOrient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        CType(Me._ImgLib_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._ImgLib_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgLib, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OptOrient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class