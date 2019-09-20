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
    Public WithEvents Panel3D4 As Label
    Public WithEvents SSPanel51 As Label
    Public WithEvents _PNL_USENM_3 As Label
    Public WithEvents CS_HINKB As Button
    Public WithEvents WLSLABEL As Label
    Public WithEvents LST As System.Windows.Forms.ListBox
	Public WithEvents WLSOK As System.Windows.Forms.Button
	Public WithEvents WLSCANCEL As System.Windows.Forms.Button
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WLSHIN))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.HD_HINKB = New System.Windows.Forms.TextBox()
        Me.HD_CODE = New System.Windows.Forms.TextBox()
        Me.HD_KATA = New System.Windows.Forms.TextBox()
        Me.WLSKANA = New System.Windows.Forms.ComboBox()
        Me.HD_HINKBNM = New System.Windows.Forms.TextBox()
        Me.Panel3D4 = New System.Windows.Forms.Label()
        Me.SSPanel51 = New System.Windows.Forms.Label()
        Me._PNL_USENM_3 = New System.Windows.Forms.Label()
        Me.CS_HINKB = New System.Windows.Forms.Button()
        Me.WLSLABEL = New System.Windows.Forms.Label()
        Me.LST = New System.Windows.Forms.ListBox()
        Me.WLSOK = New System.Windows.Forms.Button()
        Me.WLSCANCEL = New System.Windows.Forms.Button()
        Me.Panel3D1 = New System.Windows.Forms.Label()
        Me._IM_MAE_0 = New System.Windows.Forms.PictureBox()
        Me._IM_ATO_0 = New System.Windows.Forms.PictureBox()
        Me._IM_ATO_1 = New System.Windows.Forms.PictureBox()
        Me._IM_MAE_1 = New System.Windows.Forms.PictureBox()
        Me.WLSMAE = New System.Windows.Forms.PictureBox()
        Me.WLSATO = New System.Windows.Forms.PictureBox()
        Me.IM_ATO = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_MAE = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.PNL_USENM = New Microsoft.VisualBasic.Compatibility.VB6.PanelArray(Me.components)
        Me.btnF2 = New System.Windows.Forms.Button()
        Me.btnF1 = New System.Windows.Forms.Button()
        Me.btnF8 = New System.Windows.Forms.Button()
        Me.btnF7 = New System.Windows.Forms.Button()
        Me.btnF9 = New System.Windows.Forms.Button()
        Me.btnF12 = New System.Windows.Forms.Button()
        CType(Me._IM_MAE_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_ATO_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_ATO_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_MAE_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WLSMAE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WLSATO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PNL_USENM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HD_HINKB
        '
        Me.HD_HINKB.AcceptsReturn = True
        Me.HD_HINKB.BackColor = System.Drawing.SystemColors.Window
        Me.HD_HINKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_HINKB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_HINKB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_HINKB.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_HINKB.Location = New System.Drawing.Point(113, 7)
        Me.HD_HINKB.MaxLength = 1
        Me.HD_HINKB.Name = "HD_HINKB"
        Me.HD_HINKB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_HINKB.Size = New System.Drawing.Size(18, 25)
        Me.HD_HINKB.TabIndex = 2
        Me.HD_HINKB.Text = "9"
        '
        'HD_CODE
        '
        Me.HD_CODE.AcceptsReturn = True
        Me.HD_CODE.BackColor = System.Drawing.SystemColors.Window
        Me.HD_CODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_CODE.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_CODE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_CODE.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_CODE.Location = New System.Drawing.Point(112, 36)
        Me.HD_CODE.MaxLength = 10
        Me.HD_CODE.Name = "HD_CODE"
        Me.HD_CODE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_CODE.Size = New System.Drawing.Size(87, 25)
        Me.HD_CODE.TabIndex = 9
        Me.HD_CODE.Text = "XXXXXXXX10"
        '
        'HD_KATA
        '
        Me.HD_KATA.AcceptsReturn = True
        Me.HD_KATA.BackColor = System.Drawing.SystemColors.Window
        Me.HD_KATA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_KATA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_KATA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_KATA.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_KATA.Location = New System.Drawing.Point(328, 7)
        Me.HD_KATA.MaxLength = 30
        Me.HD_KATA.Name = "HD_KATA"
        Me.HD_KATA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_KATA.Size = New System.Drawing.Size(246, 25)
        Me.HD_KATA.TabIndex = 5
        Me.HD_KATA.Text = "XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3"
        '
        'WLSKANA
        '
        Me.WLSKANA.BackColor = System.Drawing.SystemColors.Window
        Me.WLSKANA.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSKANA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.WLSKANA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WLSKANA.Location = New System.Drawing.Point(670, 7)
        Me.WLSKANA.Name = "WLSKANA"
        Me.WLSKANA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSKANA.Size = New System.Drawing.Size(82, 24)
        Me.WLSKANA.TabIndex = 7
        '
        'HD_HINKBNM
        '
        Me.HD_HINKBNM.AcceptsReturn = True
        Me.HD_HINKBNM.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.HD_HINKBNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_HINKBNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_HINKBNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_HINKBNM.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_HINKBNM.Location = New System.Drawing.Point(130, 7)
        Me.HD_HINKBNM.MaxLength = 16
        Me.HD_HINKBNM.Name = "HD_HINKBNM"
        Me.HD_HINKBNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_HINKBNM.Size = New System.Drawing.Size(128, 25)
        Me.HD_HINKBNM.TabIndex = 3
        Me.HD_HINKBNM.TabStop = False
        Me.HD_HINKBNM.Text = "MMMMMMMM1MMMM16"
        '
        'Panel3D4
        '
        Me.Panel3D4.Location = New System.Drawing.Point(7, 36)
        Me.Panel3D4.Name = "Panel3D4"
        Me.Panel3D4.Size = New System.Drawing.Size(106, 25)
        Me.Panel3D4.TabIndex = 8
        Me.Panel3D4.Text = "開始製品ｺｰﾄﾞ"
        '
        'SSPanel51
        '
        Me.SSPanel51.Location = New System.Drawing.Point(274, 7)
        Me.SSPanel51.Name = "SSPanel51"
        Me.SSPanel51.Size = New System.Drawing.Size(55, 25)
        Me.SSPanel51.TabIndex = 4
        Me.SSPanel51.Text = "型式"
        '
        '_PNL_USENM_3
        '
        Me._PNL_USENM_3.Location = New System.Drawing.Point(588, 7)
        Me._PNL_USENM_3.Name = "_PNL_USENM_3"
        Me._PNL_USENM_3.Size = New System.Drawing.Size(82, 25)
        Me._PNL_USENM_3.TabIndex = 6
        Me._PNL_USENM_3.Text = "カナ検索"
        '
        'CS_HINKB
        '
        Me.CS_HINKB.Location = New System.Drawing.Point(7, 7)
        Me.CS_HINKB.Name = "CS_HINKB"
        Me.CS_HINKB.Size = New System.Drawing.Size(106, 25)
        Me.CS_HINKB.TabIndex = 1
        Me.CS_HINKB.TabStop = False
        Me.CS_HINKB.Text = "商品区分   "
        '
        'WLSLABEL
        '
        Me.WLSLABEL.Location = New System.Drawing.Point(3, 96)
        Me.WLSLABEL.Name = "WLSLABEL"
        Me.WLSLABEL.Size = New System.Drawing.Size(748, 25)
        Me.WLSLABEL.TabIndex = 10
        Me.WLSLABEL.Text = "製品ｺｰﾄﾞ   型    式                       品    名"
        '
        'LST
        '
        Me.LST.BackColor = System.Drawing.SystemColors.Window
        Me.LST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST.Cursor = System.Windows.Forms.Cursors.Default
        Me.LST.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LST.ItemHeight = 16
        Me.LST.Items.AddRange(New Object() {"XXXXXXXX10 XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3 MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM" &
                "4MMMMMMMMM5"})
        Me.LST.Location = New System.Drawing.Point(3, 120)
        Me.LST.Name = "LST"
        Me.LST.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LST.Size = New System.Drawing.Size(748, 242)
        Me.LST.TabIndex = 11
        '
        'WLSOK
        '
        Me.WLSOK.BackColor = System.Drawing.SystemColors.Control
        Me.WLSOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WLSOK.Location = New System.Drawing.Point(316, 326)
        Me.WLSOK.Name = "WLSOK"
        Me.WLSOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSOK.Size = New System.Drawing.Size(61, 22)
        Me.WLSOK.TabIndex = 12
        Me.WLSOK.Text = "OK"
        Me.WLSOK.UseVisualStyleBackColor = False
        Me.WLSOK.Visible = False
        '
        'WLSCANCEL
        '
        Me.WLSCANCEL.BackColor = System.Drawing.SystemColors.Control
        Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WLSCANCEL.Location = New System.Drawing.Point(378, 326)
        Me.WLSCANCEL.Name = "WLSCANCEL"
        Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSCANCEL.Size = New System.Drawing.Size(61, 22)
        Me.WLSCANCEL.TabIndex = 13
        Me.WLSCANCEL.Text = "ｷｬﾝｾﾙ"
        Me.WLSCANCEL.UseVisualStyleBackColor = False
        Me.WLSCANCEL.Visible = False
        '
        'Panel3D1
        '
        Me.Panel3D1.Location = New System.Drawing.Point(0, 0)
        Me.Panel3D1.Name = "Panel3D1"
        Me.Panel3D1.Size = New System.Drawing.Size(767, 67)
        Me.Panel3D1.TabIndex = 0
        '
        '_IM_MAE_0
        '
        Me._IM_MAE_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_MAE_0.Image = CType(resources.GetObject("_IM_MAE_0.Image"), System.Drawing.Image)
        Me.IM_MAE.SetIndex(Me._IM_MAE_0, CType(0, Short))
        Me._IM_MAE_0.Location = New System.Drawing.Point(297, 420)
        Me._IM_MAE_0.Name = "_IM_MAE_0"
        Me._IM_MAE_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_MAE_0.TabIndex = 14
        Me._IM_MAE_0.TabStop = False
        Me._IM_MAE_0.Visible = False
        '
        '_IM_ATO_0
        '
        Me._IM_ATO_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_ATO_0.Image = CType(resources.GetObject("_IM_ATO_0.Image"), System.Drawing.Image)
        Me.IM_ATO.SetIndex(Me._IM_ATO_0, CType(0, Short))
        Me._IM_ATO_0.Location = New System.Drawing.Point(357, 420)
        Me._IM_ATO_0.Name = "_IM_ATO_0"
        Me._IM_ATO_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_ATO_0.TabIndex = 15
        Me._IM_ATO_0.TabStop = False
        Me._IM_ATO_0.Visible = False
        '
        '_IM_ATO_1
        '
        Me._IM_ATO_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_ATO_1.Image = CType(resources.GetObject("_IM_ATO_1.Image"), System.Drawing.Image)
        Me.IM_ATO.SetIndex(Me._IM_ATO_1, CType(1, Short))
        Me._IM_ATO_1.Location = New System.Drawing.Point(384, 420)
        Me._IM_ATO_1.Name = "_IM_ATO_1"
        Me._IM_ATO_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_ATO_1.TabIndex = 16
        Me._IM_ATO_1.TabStop = False
        Me._IM_ATO_1.Visible = False
        '
        '_IM_MAE_1
        '
        Me._IM_MAE_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_MAE_1.Image = CType(resources.GetObject("_IM_MAE_1.Image"), System.Drawing.Image)
        Me.IM_MAE.SetIndex(Me._IM_MAE_1, CType(1, Short))
        Me._IM_MAE_1.Location = New System.Drawing.Point(324, 420)
        Me._IM_MAE_1.Name = "_IM_MAE_1"
        Me._IM_MAE_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_MAE_1.TabIndex = 17
        Me._IM_MAE_1.TabStop = False
        Me._IM_MAE_1.Visible = False
        '
        'WLSMAE
        '
        Me.WLSMAE.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSMAE.Image = CType(resources.GetObject("WLSMAE.Image"), System.Drawing.Image)
        Me.WLSMAE.Location = New System.Drawing.Point(283, 326)
        Me.WLSMAE.Name = "WLSMAE"
        Me.WLSMAE.Size = New System.Drawing.Size(24, 22)
        Me.WLSMAE.TabIndex = 18
        Me.WLSMAE.TabStop = False
        Me.WLSMAE.Visible = False
        '
        'WLSATO
        '
        Me.WLSATO.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSATO.Image = CType(resources.GetObject("WLSATO.Image"), System.Drawing.Image)
        Me.WLSATO.Location = New System.Drawing.Point(448, 326)
        Me.WLSATO.Name = "WLSATO"
        Me.WLSATO.Size = New System.Drawing.Size(24, 22)
        Me.WLSATO.TabIndex = 19
        Me.WLSATO.TabStop = False
        Me.WLSATO.Visible = False
        '
        'btnF2
        '
        Me.btnF2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF2.Location = New System.Drawing.Point(93, 368)
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(75, 39)
        Me.btnF2.TabIndex = 25
        Me.btnF2.Text = "(F2)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "検索"
        Me.btnF2.UseVisualStyleBackColor = True
        '
        'btnF1
        '
        Me.btnF1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF1.Location = New System.Drawing.Point(12, 368)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(75, 39)
        Me.btnF1.TabIndex = 24
        Me.btnF1.Text = "(F1)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "確定"
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'btnF8
        '
        Me.btnF8.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF8.Location = New System.Drawing.Point(379, 368)
        Me.btnF8.Name = "btnF8"
        Me.btnF8.Size = New System.Drawing.Size(75, 39)
        Me.btnF8.TabIndex = 27
        Me.btnF8.Text = "(F8)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "次頁"
        Me.btnF8.UseVisualStyleBackColor = True
        '
        'btnF7
        '
        Me.btnF7.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF7.Location = New System.Drawing.Point(300, 368)
        Me.btnF7.Name = "btnF7"
        Me.btnF7.Size = New System.Drawing.Size(75, 39)
        Me.btnF7.TabIndex = 26
        Me.btnF7.Text = "(F7)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "前頁"
        Me.btnF7.UseVisualStyleBackColor = True
        '
        'btnF9
        '
        Me.btnF9.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF9.Location = New System.Drawing.Point(586, 368)
        Me.btnF9.Name = "btnF9"
        Me.btnF9.Size = New System.Drawing.Size(75, 39)
        Me.btnF9.TabIndex = 28
        Me.btnF9.Text = "(F9)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "クリア"
        Me.btnF9.UseVisualStyleBackColor = True
        '
        'btnF12
        '
        Me.btnF12.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF12.Location = New System.Drawing.Point(667, 368)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(75, 39)
        Me.btnF12.TabIndex = 29
        Me.btnF12.Text = "(F12)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'WLSHIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(754, 415)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnF9)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.btnF2)
        Me.Controls.Add(Me.btnF1)
        Me.Controls.Add(Me.btnF8)
        Me.Controls.Add(Me.btnF7)
        Me.Controls.Add(Me.HD_HINKB)
        Me.Controls.Add(Me.HD_CODE)
        Me.Controls.Add(Me.HD_KATA)
        Me.Controls.Add(Me.WLSKANA)
        Me.Controls.Add(Me.HD_HINKBNM)
        Me.Controls.Add(Me.Panel3D4)
        Me.Controls.Add(Me.SSPanel51)
        Me.Controls.Add(Me._PNL_USENM_3)
        Me.Controls.Add(Me.CS_HINKB)
        Me.Controls.Add(Me.WLSLABEL)
        Me.Controls.Add(Me.LST)
        Me.Controls.Add(Me.WLSOK)
        Me.Controls.Add(Me.WLSCANCEL)
        Me.Controls.Add(Me.Panel3D1)
        Me.Controls.Add(Me._IM_MAE_0)
        Me.Controls.Add(Me._IM_ATO_0)
        Me.Controls.Add(Me._IM_ATO_1)
        Me.Controls.Add(Me._IM_MAE_1)
        Me.Controls.Add(Me.WLSMAE)
        Me.Controls.Add(Me.WLSATO)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(128, 158)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WLSHIN"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "製品検索"
        CType(Me._IM_MAE_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_ATO_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_ATO_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_MAE_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WLSMAE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WLSATO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_ATO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_MAE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PNL_USENM, System.ComponentModel.ISupportInitialize).EndInit()
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