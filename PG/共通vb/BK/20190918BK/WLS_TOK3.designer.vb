<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class WLSTOK3
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
    Public WithEvents WLSLABEL As label
    Public WithEvents LST As System.Windows.Forms.ListBox
    Public WithEvents WLSOK As System.Windows.Forms.Button
    Public WithEvents WLSCANCEL As System.Windows.Forms.Button
    Public WithEvents WLSKANA As System.Windows.Forms.ComboBox
    Public WithEvents HD_Kana As System.Windows.Forms.TextBox
    Public WithEvents HD_RN As System.Windows.Forms.TextBox
    Public WithEvents HD_TEXT As System.Windows.Forms.TextBox
    Public WithEvents Panel3D4 As label
    Public WithEvents Label1 As label
    Public WithEvents _PNL_USENM_3 As label
    Public WithEvents Panel3D1 As label
    Public WithEvents _IM_MAE_0 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_ATO_0 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_ATO_1 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_MAE_1 As System.Windows.Forms.PictureBox
    Public WithEvents WLSMAE As System.Windows.Forms.PictureBox
    Public WithEvents WLSATO As System.Windows.Forms.PictureBox
    Public WithEvents IM_ATO As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    Public WithEvents IM_MAE As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    'Public WithEvents PNL_USENM As VB6.PanelArray
    Public WithEvents PNL_USENM As VB6.PanelArray
    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更できます。
    'コード エディタを使用して、変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WLSTOK3))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.WLSLABEL = New System.Windows.Forms.Label()
        Me.LST = New System.Windows.Forms.ListBox()
        Me.WLSOK = New System.Windows.Forms.Button()
        Me.WLSCANCEL = New System.Windows.Forms.Button()
        Me.Panel3D1 = New System.Windows.Forms.Label()
        Me.WLSKANA = New System.Windows.Forms.ComboBox()
        Me.HD_Kana = New System.Windows.Forms.TextBox()
        Me.HD_RN = New System.Windows.Forms.TextBox()
        Me.HD_TEXT = New System.Windows.Forms.TextBox()
        Me.Panel3D4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me._PNL_USENM_3 = New System.Windows.Forms.Label()
        Me._IM_MAE_0 = New System.Windows.Forms.PictureBox()
        Me._IM_ATO_0 = New System.Windows.Forms.PictureBox()
        Me._IM_ATO_1 = New System.Windows.Forms.PictureBox()
        Me._IM_MAE_1 = New System.Windows.Forms.PictureBox()
        Me.WLSMAE = New System.Windows.Forms.PictureBox()
        Me.WLSATO = New System.Windows.Forms.PictureBox()
        Me.IM_ATO = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_MAE = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.PNL_USENM = New Microsoft.VisualBasic.Compatibility.VB6.PanelArray(Me.components)
        Me.btnF9 = New System.Windows.Forms.Button()
        Me.btnF12 = New System.Windows.Forms.Button()
        Me.btnF2 = New System.Windows.Forms.Button()
        Me.btnF1 = New System.Windows.Forms.Button()
        Me.btnF8 = New System.Windows.Forms.Button()
        Me.btnF7 = New System.Windows.Forms.Button()
        Me.Panel3D1.SuspendLayout()
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
        'WLSLABEL
        '
        Me.WLSLABEL.Location = New System.Drawing.Point(3, 56)
        Me.WLSLABEL.Name = "WLSLABEL"
        Me.WLSLABEL.Size = New System.Drawing.Size(858, 25)
        Me.WLSLABEL.TabIndex = 8
        Me.WLSLABEL.Text = "WLSLABEL"
        '
        'LST
        '
        Me.LST.BackColor = System.Drawing.SystemColors.Window
        Me.LST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST.Cursor = System.Windows.Forms.Cursors.Default
        Me.LST.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LST.ItemHeight = 16
        Me.LST.Location = New System.Drawing.Point(3, 80)
        Me.LST.Name = "LST"
        Me.LST.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LST.Size = New System.Drawing.Size(858, 242)
        Me.LST.TabIndex = 0
        '
        'WLSOK
        '
        Me.WLSOK.BackColor = System.Drawing.SystemColors.Control
        Me.WLSOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WLSOK.Location = New System.Drawing.Point(364, 288)
        Me.WLSOK.Name = "WLSOK"
        Me.WLSOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSOK.Size = New System.Drawing.Size(61, 22)
        Me.WLSOK.TabIndex = 4
        Me.WLSOK.Text = "OK"
        Me.WLSOK.UseVisualStyleBackColor = False
        Me.WLSOK.Visible = False
        '
        'WLSCANCEL
        '
        Me.WLSCANCEL.BackColor = System.Drawing.SystemColors.Control
        Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WLSCANCEL.Location = New System.Drawing.Point(427, 288)
        Me.WLSCANCEL.Name = "WLSCANCEL"
        Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSCANCEL.Size = New System.Drawing.Size(61, 22)
        Me.WLSCANCEL.TabIndex = 5
        Me.WLSCANCEL.Text = "ｷｬﾝｾﾙ"
        Me.WLSCANCEL.UseVisualStyleBackColor = False
        Me.WLSCANCEL.Visible = False
        '
        'Panel3D1
        '
        Me.Panel3D1.Controls.Add(Me.WLSKANA)
        Me.Panel3D1.Controls.Add(Me.HD_Kana)
        Me.Panel3D1.Controls.Add(Me.HD_RN)
        Me.Panel3D1.Controls.Add(Me.HD_TEXT)
        Me.Panel3D1.Controls.Add(Me.Panel3D4)
        Me.Panel3D1.Controls.Add(Me.Label1)
        Me.Panel3D1.Controls.Add(Me._PNL_USENM_3)
        Me.Panel3D1.Location = New System.Drawing.Point(0, 0)
        Me.Panel3D1.Name = "Panel3D1"
        Me.Panel3D1.Size = New System.Drawing.Size(861, 37)
        Me.Panel3D1.TabIndex = 6
        '
        'WLSKANA
        '
        Me.WLSKANA.BackColor = System.Drawing.SystemColors.Window
        Me.WLSKANA.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSKANA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.WLSKANA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WLSKANA.Location = New System.Drawing.Point(778, 6)
        Me.WLSKANA.Name = "WLSKANA"
        Me.WLSKANA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSKANA.Size = New System.Drawing.Size(74, 24)
        Me.WLSKANA.TabIndex = 3
        '
        'HD_Kana
        '
        Me.HD_Kana.AcceptsReturn = True
        Me.HD_Kana.BackColor = System.Drawing.SystemColors.Window
        Me.HD_Kana.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_Kana.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_Kana.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.HD_Kana.Location = New System.Drawing.Point(712, 8)
        Me.HD_Kana.MaxLength = 0
        Me.HD_Kana.Name = "HD_Kana"
        Me.HD_Kana.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_Kana.Size = New System.Drawing.Size(38, 23)
        Me.HD_Kana.TabIndex = 10
        Me.HD_Kana.Text = "ｱｲｳｴｵ"
        Me.HD_Kana.Visible = False
        '
        'HD_RN
        '
        Me.HD_RN.AcceptsReturn = True
        Me.HD_RN.BackColor = System.Drawing.SystemColors.Window
        Me.HD_RN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_RN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_RN.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_RN.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_RN.Location = New System.Drawing.Point(336, 6)
        Me.HD_RN.MaxLength = 40
        Me.HD_RN.Name = "HD_RN"
        Me.HD_RN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_RN.Size = New System.Drawing.Size(244, 23)
        Me.HD_RN.TabIndex = 2
        Me.HD_RN.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
        '
        'HD_TEXT
        '
        Me.HD_TEXT.AcceptsReturn = True
        Me.HD_TEXT.BackColor = System.Drawing.SystemColors.Window
        Me.HD_TEXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TEXT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TEXT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TEXT.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_TEXT.Location = New System.Drawing.Point(78, 6)
        Me.HD_TEXT.MaxLength = 13
        Me.HD_TEXT.Name = "HD_TEXT"
        Me.HD_TEXT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TEXT.Size = New System.Drawing.Size(52, 23)
        Me.HD_TEXT.TabIndex = 1
        Me.HD_TEXT.Text = "XXXXX"
        '
        'Panel3D4
        '
        Me.Panel3D4.Location = New System.Drawing.Point(6, 6)
        Me.Panel3D4.Name = "Panel3D4"
        Me.Panel3D4.Size = New System.Drawing.Size(73, 25)
        Me.Panel3D4.TabIndex = 7
        Me.Panel3D4.Text = "開始ｺｰﾄﾞ"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(248, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 25)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "得意先略称"
        '
        '_PNL_USENM_3
        '
        Me._PNL_USENM_3.Location = New System.Drawing.Point(704, 6)
        Me._PNL_USENM_3.Name = "_PNL_USENM_3"
        Me._PNL_USENM_3.Size = New System.Drawing.Size(74, 25)
        Me._PNL_USENM_3.TabIndex = 11
        Me._PNL_USENM_3.Text = "カナ検索"
        '
        '_IM_MAE_0
        '
        Me._IM_MAE_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_MAE_0.Image = CType(resources.GetObject("_IM_MAE_0.Image"), System.Drawing.Image)
        Me.IM_MAE.SetIndex(Me._IM_MAE_0, CType(0, Short))
        Me._IM_MAE_0.Location = New System.Drawing.Point(351, 408)
        Me._IM_MAE_0.Name = "_IM_MAE_0"
        Me._IM_MAE_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_MAE_0.TabIndex = 9
        Me._IM_MAE_0.TabStop = False
        Me._IM_MAE_0.Visible = False
        '
        '_IM_ATO_0
        '
        Me._IM_ATO_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_ATO_0.Image = CType(resources.GetObject("_IM_ATO_0.Image"), System.Drawing.Image)
        Me.IM_ATO.SetIndex(Me._IM_ATO_0, CType(0, Short))
        Me._IM_ATO_0.Location = New System.Drawing.Point(411, 408)
        Me._IM_ATO_0.Name = "_IM_ATO_0"
        Me._IM_ATO_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_ATO_0.TabIndex = 10
        Me._IM_ATO_0.TabStop = False
        Me._IM_ATO_0.Visible = False
        '
        '_IM_ATO_1
        '
        Me._IM_ATO_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_ATO_1.Image = CType(resources.GetObject("_IM_ATO_1.Image"), System.Drawing.Image)
        Me.IM_ATO.SetIndex(Me._IM_ATO_1, CType(1, Short))
        Me._IM_ATO_1.Location = New System.Drawing.Point(438, 408)
        Me._IM_ATO_1.Name = "_IM_ATO_1"
        Me._IM_ATO_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_ATO_1.TabIndex = 11
        Me._IM_ATO_1.TabStop = False
        Me._IM_ATO_1.Visible = False
        '
        '_IM_MAE_1
        '
        Me._IM_MAE_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_MAE_1.Image = CType(resources.GetObject("_IM_MAE_1.Image"), System.Drawing.Image)
        Me.IM_MAE.SetIndex(Me._IM_MAE_1, CType(1, Short))
        Me._IM_MAE_1.Location = New System.Drawing.Point(378, 408)
        Me._IM_MAE_1.Name = "_IM_MAE_1"
        Me._IM_MAE_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_MAE_1.TabIndex = 12
        Me._IM_MAE_1.TabStop = False
        Me._IM_MAE_1.Visible = False
        '
        'WLSMAE
        '
        Me.WLSMAE.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSMAE.Image = CType(resources.GetObject("WLSMAE.Image"), System.Drawing.Image)
        Me.WLSMAE.Location = New System.Drawing.Point(331, 288)
        Me.WLSMAE.Name = "WLSMAE"
        Me.WLSMAE.Size = New System.Drawing.Size(24, 22)
        Me.WLSMAE.TabIndex = 13
        Me.WLSMAE.TabStop = False
        Me.WLSMAE.Visible = False
        '
        'WLSATO
        '
        Me.WLSATO.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSATO.Image = CType(resources.GetObject("WLSATO.Image"), System.Drawing.Image)
        Me.WLSATO.Location = New System.Drawing.Point(496, 288)
        Me.WLSATO.Name = "WLSATO"
        Me.WLSATO.Size = New System.Drawing.Size(24, 22)
        Me.WLSATO.TabIndex = 14
        Me.WLSATO.TabStop = False
        Me.WLSATO.Visible = False
        '
        'btnF9
        '
        Me.btnF9.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF9.Location = New System.Drawing.Point(700, 331)
        Me.btnF9.Name = "btnF9"
        Me.btnF9.Size = New System.Drawing.Size(75, 39)
        Me.btnF9.TabIndex = 43
        Me.btnF9.Text = "(F9)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "クリア"
        Me.btnF9.UseVisualStyleBackColor = True
        '
        'btnF12
        '
        Me.btnF12.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF12.Location = New System.Drawing.Point(780, 331)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(75, 39)
        Me.btnF12.TabIndex = 44
        Me.btnF12.Text = "(F12)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'btnF2
        '
        Me.btnF2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF2.Location = New System.Drawing.Point(92, 331)
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(75, 39)
        Me.btnF2.TabIndex = 40
        Me.btnF2.Text = "(F2)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "検索"
        Me.btnF2.UseVisualStyleBackColor = True
        '
        'btnF1
        '
        Me.btnF1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF1.Location = New System.Drawing.Point(12, 331)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(75, 39)
        Me.btnF1.TabIndex = 39
        Me.btnF1.Text = "(F1)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "確定"
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'btnF8
        '
        Me.btnF8.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF8.Location = New System.Drawing.Point(436, 331)
        Me.btnF8.Name = "btnF8"
        Me.btnF8.Size = New System.Drawing.Size(75, 39)
        Me.btnF8.TabIndex = 42
        Me.btnF8.Text = "(F8)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "次頁"
        Me.btnF8.UseVisualStyleBackColor = True
        '
        'btnF7
        '
        Me.btnF7.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF7.Location = New System.Drawing.Point(357, 331)
        Me.btnF7.Name = "btnF7"
        Me.btnF7.Size = New System.Drawing.Size(75, 39)
        Me.btnF7.TabIndex = 41
        Me.btnF7.Text = "(F7)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "前頁"
        Me.btnF7.UseVisualStyleBackColor = True
        '
        'WLSTOK3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(867, 382)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnF9)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.btnF2)
        Me.Controls.Add(Me.btnF1)
        Me.Controls.Add(Me.btnF8)
        Me.Controls.Add(Me.btnF7)
        Me.Controls.Add(Me.WLSLABEL)
        Me.Controls.Add(Me.Panel3D1)
        Me.Controls.Add(Me._IM_MAE_0)
        Me.Controls.Add(Me._IM_ATO_0)
        Me.Controls.Add(Me._IM_ATO_1)
        Me.Controls.Add(Me._IM_MAE_1)
        Me.Controls.Add(Me.LST)
        Me.Controls.Add(Me.WLSOK)
        Me.Controls.Add(Me.WLSCANCEL)
        Me.Controls.Add(Me.WLSMAE)
        Me.Controls.Add(Me.WLSATO)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(184, 158)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WLSTOK3"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "得意先一覧ウィンドウ"
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
        CType(Me.PNL_USENM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnF9 As Button
    Friend WithEvents btnF12 As Button
    Friend WithEvents btnF2 As Button
    Friend WithEvents btnF1 As Button
    Friend WithEvents btnF8 As Button
    Friend WithEvents btnF7 As Button
#End Region
End Class