<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class WLSSOU
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
    Public WithEvents WLSLABEL As System.Windows.Forms.Label
    Public WithEvents LST As System.Windows.Forms.ListBox
    Public WithEvents WLSOK As System.Windows.Forms.Button
    Public WithEvents WLSCANCEL As System.Windows.Forms.Button
    Public WithEvents HD_NAME As System.Windows.Forms.TextBox
    Public WithEvents HD_CODE As System.Windows.Forms.TextBox
    Public WithEvents Panel3D4 As System.Windows.Forms.Label
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WLSSOU))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.WLSLABEL = New System.Windows.Forms.Label()
        Me.LST = New System.Windows.Forms.ListBox()
        Me.WLSOK = New System.Windows.Forms.Button()
        Me.WLSCANCEL = New System.Windows.Forms.Button()
        Me.Panel3D1 = New System.Windows.Forms.Label()
        Me.HD_NAME = New System.Windows.Forms.TextBox()
        Me.HD_CODE = New System.Windows.Forms.TextBox()
        Me.Panel3D4 = New System.Windows.Forms.Label()
        Me.SSPanel51 = New System.Windows.Forms.Label()
        Me._IM_MAE_0 = New System.Windows.Forms.PictureBox()
        Me._IM_ATO_0 = New System.Windows.Forms.PictureBox()
        Me._IM_ATO_1 = New System.Windows.Forms.PictureBox()
        Me._IM_MAE_1 = New System.Windows.Forms.PictureBox()
        Me.WLSMAE = New System.Windows.Forms.PictureBox()
        Me.WLSATO = New System.Windows.Forms.PictureBox()
        Me.IM_ATO = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_MAE = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.btnF2 = New System.Windows.Forms.Button()
        Me.btnF1 = New System.Windows.Forms.Button()
        Me.btnF8 = New System.Windows.Forms.Button()
        Me.btnF7 = New System.Windows.Forms.Button()
        Me.btnF9 = New System.Windows.Forms.Button()
        Me.btnF12 = New System.Windows.Forms.Button()
        Me.Panel3D1.SuspendLayout()
        CType(Me._IM_MAE_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_ATO_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_ATO_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_MAE_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WLSMAE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WLSATO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WLSLABEL
        '
        Me.WLSLABEL.Location = New System.Drawing.Point(3, 61)
        Me.WLSLABEL.Name = "WLSLABEL"
        Me.WLSLABEL.Size = New System.Drawing.Size(496, 25)
        Me.WLSLABEL.TabIndex = 0
        Me.WLSLABEL.Text = "倉庫ｺｰﾄﾞ  倉庫名                   場所"
        '
        'LST
        '
        Me.LST.BackColor = System.Drawing.SystemColors.Window
        Me.LST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST.Cursor = System.Windows.Forms.Cursors.Default
        Me.LST.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LST.ItemHeight = 16
        Me.LST.Items.AddRange(New Object() {"123       MMMMMMMMM1MMMMMMMMM2     MMMMMMMMM1MMMMMMMMM2"})
        Me.LST.Location = New System.Drawing.Point(3, 85)
        Me.LST.Name = "LST"
        Me.LST.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LST.Size = New System.Drawing.Size(496, 242)
        Me.LST.TabIndex = 1
        '
        'WLSOK
        '
        Me.WLSOK.BackColor = System.Drawing.SystemColors.Control
        Me.WLSOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WLSOK.Location = New System.Drawing.Point(188, 292)
        Me.WLSOK.Name = "WLSOK"
        Me.WLSOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSOK.Size = New System.Drawing.Size(61, 22)
        Me.WLSOK.TabIndex = 27
        Me.WLSOK.Text = "OK"
        Me.WLSOK.UseVisualStyleBackColor = False
        Me.WLSOK.Visible = False
        '
        'WLSCANCEL
        '
        Me.WLSCANCEL.BackColor = System.Drawing.SystemColors.Control
        Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WLSCANCEL.Location = New System.Drawing.Point(251, 292)
        Me.WLSCANCEL.Name = "WLSCANCEL"
        Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSCANCEL.Size = New System.Drawing.Size(61, 22)
        Me.WLSCANCEL.TabIndex = 28
        Me.WLSCANCEL.Text = "ｷｬﾝｾﾙ"
        Me.WLSCANCEL.UseVisualStyleBackColor = False
        Me.WLSCANCEL.Visible = False
        '
        'Panel3D1
        '
        Me.Panel3D1.Controls.Add(Me.HD_NAME)
        Me.Panel3D1.Controls.Add(Me.HD_CODE)
        Me.Panel3D1.Controls.Add(Me.Panel3D4)
        Me.Panel3D1.Controls.Add(Me.SSPanel51)
        Me.Panel3D1.Location = New System.Drawing.Point(0, 0)
        Me.Panel3D1.Name = "Panel3D1"
        Me.Panel3D1.Size = New System.Drawing.Size(725, 41)
        Me.Panel3D1.TabIndex = 0
        '
        'HD_NAME
        '
        Me.HD_NAME.AcceptsReturn = True
        Me.HD_NAME.BackColor = System.Drawing.SystemColors.Window
        Me.HD_NAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_NAME.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_NAME.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_NAME.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_NAME.Location = New System.Drawing.Point(179, 6)
        Me.HD_NAME.MaxLength = 20
        Me.HD_NAME.Name = "HD_NAME"
        Me.HD_NAME.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_NAME.Size = New System.Drawing.Size(171, 23)
        Me.HD_NAME.TabIndex = 7
        Me.HD_NAME.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'HD_CODE
        '
        Me.HD_CODE.AcceptsReturn = True
        Me.HD_CODE.BackColor = System.Drawing.SystemColors.Window
        Me.HD_CODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_CODE.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_CODE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_CODE.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_CODE.Location = New System.Drawing.Point(78, 6)
        Me.HD_CODE.MaxLength = 3
        Me.HD_CODE.Name = "HD_CODE"
        Me.HD_CODE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_CODE.Size = New System.Drawing.Size(35, 23)
        Me.HD_CODE.TabIndex = 4
        Me.HD_CODE.Text = "XX3"
        '
        'Panel3D4
        '
        Me.Panel3D4.Location = New System.Drawing.Point(6, 6)
        Me.Panel3D4.Name = "Panel3D4"
        Me.Panel3D4.Size = New System.Drawing.Size(73, 25)
        Me.Panel3D4.TabIndex = 5
        Me.Panel3D4.Text = "開始ｺｰﾄﾞ"
        '
        'SSPanel51
        '
        Me.SSPanel51.Location = New System.Drawing.Point(117, 6)
        Me.SSPanel51.Name = "SSPanel51"
        Me.SSPanel51.Size = New System.Drawing.Size(63, 25)
        Me.SSPanel51.TabIndex = 8
        Me.SSPanel51.Text = "倉庫名"
        '
        '_IM_MAE_0
        '
        Me._IM_MAE_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_MAE_0.Image = CType(resources.GetObject("_IM_MAE_0.Image"), System.Drawing.Image)
        Me.IM_MAE.SetIndex(Me._IM_MAE_0, CType(0, Short))
        Me._IM_MAE_0.Location = New System.Drawing.Point(255, 411)
        Me._IM_MAE_0.Name = "_IM_MAE_0"
        Me._IM_MAE_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_MAE_0.TabIndex = 4
        Me._IM_MAE_0.TabStop = False
        Me._IM_MAE_0.Visible = False
        '
        '_IM_ATO_0
        '
        Me._IM_ATO_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_ATO_0.Image = CType(resources.GetObject("_IM_ATO_0.Image"), System.Drawing.Image)
        Me.IM_ATO.SetIndex(Me._IM_ATO_0, CType(0, Short))
        Me._IM_ATO_0.Location = New System.Drawing.Point(315, 411)
        Me._IM_ATO_0.Name = "_IM_ATO_0"
        Me._IM_ATO_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_ATO_0.TabIndex = 5
        Me._IM_ATO_0.TabStop = False
        Me._IM_ATO_0.Visible = False
        '
        '_IM_ATO_1
        '
        Me._IM_ATO_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_ATO_1.Image = CType(resources.GetObject("_IM_ATO_1.Image"), System.Drawing.Image)
        Me.IM_ATO.SetIndex(Me._IM_ATO_1, CType(1, Short))
        Me._IM_ATO_1.Location = New System.Drawing.Point(342, 411)
        Me._IM_ATO_1.Name = "_IM_ATO_1"
        Me._IM_ATO_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_ATO_1.TabIndex = 6
        Me._IM_ATO_1.TabStop = False
        Me._IM_ATO_1.Visible = False
        '
        '_IM_MAE_1
        '
        Me._IM_MAE_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_MAE_1.Image = CType(resources.GetObject("_IM_MAE_1.Image"), System.Drawing.Image)
        Me.IM_MAE.SetIndex(Me._IM_MAE_1, CType(1, Short))
        Me._IM_MAE_1.Location = New System.Drawing.Point(282, 411)
        Me._IM_MAE_1.Name = "_IM_MAE_1"
        Me._IM_MAE_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_MAE_1.TabIndex = 7
        Me._IM_MAE_1.TabStop = False
        Me._IM_MAE_1.Visible = False
        '
        'WLSMAE
        '
        Me.WLSMAE.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSMAE.Image = CType(resources.GetObject("WLSMAE.Image"), System.Drawing.Image)
        Me.WLSMAE.Location = New System.Drawing.Point(153, 292)
        Me.WLSMAE.Name = "WLSMAE"
        Me.WLSMAE.Size = New System.Drawing.Size(24, 22)
        Me.WLSMAE.TabIndex = 8
        Me.WLSMAE.TabStop = False
        Me.WLSMAE.Visible = False
        '
        'WLSATO
        '
        Me.WLSATO.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSATO.Image = CType(resources.GetObject("WLSATO.Image"), System.Drawing.Image)
        Me.WLSATO.Location = New System.Drawing.Point(324, 292)
        Me.WLSATO.Name = "WLSATO"
        Me.WLSATO.Size = New System.Drawing.Size(24, 22)
        Me.WLSATO.TabIndex = 9
        Me.WLSATO.TabStop = False
        Me.WLSATO.Visible = False
        '
        'btnF2
        '
        Me.btnF2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF2.Location = New System.Drawing.Point(92, 333)
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(75, 39)
        Me.btnF2.TabIndex = 22
        Me.btnF2.Text = "(F2)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "検索"
        Me.btnF2.UseVisualStyleBackColor = True
        '
        'btnF1
        '
        Me.btnF1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF1.Location = New System.Drawing.Point(12, 333)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(75, 39)
        Me.btnF1.TabIndex = 21
        Me.btnF1.Text = "(F1)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "確定"
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'btnF8
        '
        Me.btnF8.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF8.Location = New System.Drawing.Point(252, 333)
        Me.btnF8.Name = "btnF8"
        Me.btnF8.Size = New System.Drawing.Size(75, 39)
        Me.btnF8.TabIndex = 24
        Me.btnF8.Text = "(F8)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "次頁"
        Me.btnF8.UseVisualStyleBackColor = True
        '
        'btnF7
        '
        Me.btnF7.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF7.Location = New System.Drawing.Point(172, 333)
        Me.btnF7.Name = "btnF7"
        Me.btnF7.Size = New System.Drawing.Size(75, 39)
        Me.btnF7.TabIndex = 23
        Me.btnF7.Text = "(F7)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "前頁"
        Me.btnF7.UseVisualStyleBackColor = True
        '
        'btnF9
        '
        Me.btnF9.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF9.Location = New System.Drawing.Point(332, 333)
        Me.btnF9.Name = "btnF9"
        Me.btnF9.Size = New System.Drawing.Size(75, 39)
        Me.btnF9.TabIndex = 25
        Me.btnF9.Text = "(F9)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "クリア"
        Me.btnF9.UseVisualStyleBackColor = True
        '
        'btnF12
        '
        Me.btnF12.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF12.Location = New System.Drawing.Point(412, 333)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(75, 39)
        Me.btnF12.TabIndex = 26
        Me.btnF12.Text = "(F12)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'WLSSOU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(500, 381)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnF9)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.btnF2)
        Me.Controls.Add(Me.btnF1)
        Me.Controls.Add(Me.btnF8)
        Me.Controls.Add(Me.btnF7)
        Me.Controls.Add(Me.WLSLABEL)
        Me.Controls.Add(Me.WLSOK)
        Me.Controls.Add(Me.WLSCANCEL)
        Me.Controls.Add(Me.Panel3D1)
        Me.Controls.Add(Me._IM_MAE_0)
        Me.Controls.Add(Me._IM_ATO_0)
        Me.Controls.Add(Me._IM_ATO_1)
        Me.Controls.Add(Me._IM_MAE_1)
        Me.Controls.Add(Me.WLSMAE)
        Me.Controls.Add(Me.WLSATO)
        Me.Controls.Add(Me.LST)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(111, 220)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WLSSOU"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "倉庫検索"
        Me.Panel3D1.ResumeLayout(False)
        Me.Panel3D1.PerformLayout()
        CType(Me._IM_MAE_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_ATO_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_ATO_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_MAE_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WLSMAE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WLSATO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnF2 As Button
    Friend WithEvents btnF1 As Button
    Friend WithEvents btnF8 As Button
    Friend WithEvents btnF7 As Button
    Friend WithEvents btnF9 As Button
    Friend WithEvents btnF12 As Button
#End Region
End Class