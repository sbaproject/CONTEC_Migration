<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class WLS_ANID
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
	Public WithEvents WLSOK As System.Windows.Forms.Button
	Public WithEvents WLSCANCEL As System.Windows.Forms.Button
	Public WithEvents HD_OAKNID As System.Windows.Forms.TextBox
	Public WithEvents HD_JDNYTDT As System.Windows.Forms.TextBox
	Public WithEvents HD_TANNM As System.Windows.Forms.TextBox
	Public WithEvents HD_TANCD As System.Windows.Forms.TextBox
    Public WithEvents CS_TANCD As System.Windows.Forms.Button
    Public WithEvents CS_JDNYTDT As System.Windows.Forms.Button
    Public WithEvents _FM_Panel3D1_0 As System.Windows.Forms.Label
    Public WithEvents Panel3D1 As System.Windows.Forms.Panel
    Public WithEvents _FM_Panel3D1_1 As System.Windows.Forms.Label
	Public WithEvents LST As System.Windows.Forms.ListBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _IM_PrevCm_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_NextCm_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_NextCm_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_PrevCm_1 As System.Windows.Forms.PictureBox
	Public WithEvents CM_PrevCm As System.Windows.Forms.PictureBox
	Public WithEvents CM_NextCm As System.Windows.Forms.PictureBox
    Public WithEvents FM_Panel3D1 As Microsoft.VisualBasic.Compatibility.VB6.PanelArray
	Public WithEvents IM_NextCm As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents IM_PrevCm As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WLS_ANID))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.WLSOK = New System.Windows.Forms.Button()
        Me.WLSCANCEL = New System.Windows.Forms.Button()
        Me.Panel3D1 = New System.Windows.Forms.Panel()
        Me.HD_OAKNID = New System.Windows.Forms.TextBox()
        Me.HD_JDNYTDT = New System.Windows.Forms.TextBox()
        Me.HD_TANNM = New System.Windows.Forms.TextBox()
        Me.HD_TANCD = New System.Windows.Forms.TextBox()
        Me.CS_TANCD = New System.Windows.Forms.Button()
        Me.CS_JDNYTDT = New System.Windows.Forms.Button()
        Me._FM_Panel3D1_0 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_1 = New System.Windows.Forms.Label()
        Me.LST = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me._IM_PrevCm_0 = New System.Windows.Forms.PictureBox()
        Me._IM_NextCm_0 = New System.Windows.Forms.PictureBox()
        Me._IM_NextCm_1 = New System.Windows.Forms.PictureBox()
        Me._IM_PrevCm_1 = New System.Windows.Forms.PictureBox()
        Me.CM_PrevCm = New System.Windows.Forms.PictureBox()
        Me.CM_NextCm = New System.Windows.Forms.PictureBox()
        Me.FM_Panel3D1 = New Microsoft.VisualBasic.Compatibility.VB6.PanelArray(Me.components)
        Me.IM_NextCm = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_PrevCm = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.btnF2 = New System.Windows.Forms.Button()
        Me.btnF1 = New System.Windows.Forms.Button()
        Me.btnF8 = New System.Windows.Forms.Button()
        Me.btnF7 = New System.Windows.Forms.Button()
        Me.btnF9 = New System.Windows.Forms.Button()
        Me.btnF12 = New System.Windows.Forms.Button()
        Me.Panel3D1.SuspendLayout()
        CType(Me._IM_PrevCm_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_NextCm_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_NextCm_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_PrevCm_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_PrevCm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_NextCm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_NextCm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_PrevCm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WLSOK
        '
        Me.WLSOK.BackColor = System.Drawing.SystemColors.Control
        Me.WLSOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WLSOK.Location = New System.Drawing.Point(447, 229)
        Me.WLSOK.Name = "WLSOK"
        Me.WLSOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSOK.Size = New System.Drawing.Size(61, 22)
        Me.WLSOK.TabIndex = 1
        Me.WLSOK.Text = "OK"
        Me.WLSOK.UseVisualStyleBackColor = False
        Me.WLSOK.Visible = False
        '
        'WLSCANCEL
        '
        Me.WLSCANCEL.BackColor = System.Drawing.SystemColors.Control
        Me.WLSCANCEL.Cursor = System.Windows.Forms.Cursors.Default
        Me.WLSCANCEL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WLSCANCEL.Location = New System.Drawing.Point(510, 229)
        Me.WLSCANCEL.Name = "WLSCANCEL"
        Me.WLSCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WLSCANCEL.Size = New System.Drawing.Size(61, 22)
        Me.WLSCANCEL.TabIndex = 2
        Me.WLSCANCEL.Text = "ｷｬﾝｾﾙ"
        Me.WLSCANCEL.UseVisualStyleBackColor = False
        Me.WLSCANCEL.Visible = False
        '
        'Panel3D1
        '
        Me.Panel3D1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel3D1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3D1.Controls.Add(Me.HD_OAKNID)
        Me.Panel3D1.Controls.Add(Me.HD_JDNYTDT)
        Me.Panel3D1.Controls.Add(Me.HD_TANNM)
        Me.Panel3D1.Controls.Add(Me.HD_TANCD)
        Me.Panel3D1.Controls.Add(Me.CS_TANCD)
        Me.Panel3D1.Controls.Add(Me.CS_JDNYTDT)
        Me.Panel3D1.Controls.Add(Me._FM_Panel3D1_0)
        Me.Panel3D1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panel3D1.ForeColor = System.Drawing.Color.Black
        Me.Panel3D1.Location = New System.Drawing.Point(-3, -1)
        Me.Panel3D1.Name = "Panel3D1"
        Me.Panel3D1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Panel3D1.Size = New System.Drawing.Size(1017, 37)
        Me.Panel3D1.TabIndex = 0
        '
        'HD_OAKNID
        '
        Me.HD_OAKNID.AcceptsReturn = True
        Me.HD_OAKNID.BackColor = System.Drawing.SystemColors.Window
        Me.HD_OAKNID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_OAKNID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_OAKNID.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_OAKNID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_OAKNID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_OAKNID.Location = New System.Drawing.Point(733, 6)
        Me.HD_OAKNID.MaxLength = 10
        Me.HD_OAKNID.Name = "HD_OAKNID"
        Me.HD_OAKNID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_OAKNID.Size = New System.Drawing.Size(83, 25)
        Me.HD_OAKNID.TabIndex = 10
        Me.HD_OAKNID.Text = "99999999"
        Me.HD_OAKNID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'HD_JDNYTDT
        '
        Me.HD_JDNYTDT.AcceptsReturn = True
        Me.HD_JDNYTDT.BackColor = System.Drawing.SystemColors.Window
        Me.HD_JDNYTDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_JDNYTDT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_JDNYTDT.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_JDNYTDT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_JDNYTDT.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_JDNYTDT.Location = New System.Drawing.Point(550, 6)
        Me.HD_JDNYTDT.MaxLength = 10
        Me.HD_JDNYTDT.Name = "HD_JDNYTDT"
        Me.HD_JDNYTDT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_JDNYTDT.Size = New System.Drawing.Size(83, 25)
        Me.HD_JDNYTDT.TabIndex = 8
        Me.HD_JDNYTDT.Text = "9999/99/99"
        '
        'HD_TANNM
        '
        Me.HD_TANNM.AcceptsReturn = True
        Me.HD_TANNM.BackColor = System.Drawing.SystemColors.Control
        Me.HD_TANNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TANNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TANNM.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_TANNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TANNM.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_TANNM.Location = New System.Drawing.Point(160, 6)
        Me.HD_TANNM.MaxLength = 40
        Me.HD_TANNM.Name = "HD_TANNM"
        Me.HD_TANNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TANNM.Size = New System.Drawing.Size(294, 25)
        Me.HD_TANNM.TabIndex = 5
        Me.HD_TANNM.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
        '
        'HD_TANCD
        '
        Me.HD_TANCD.AcceptsReturn = True
        Me.HD_TANCD.BackColor = System.Drawing.SystemColors.Window
        Me.HD_TANCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TANCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TANCD.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_TANCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TANCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_TANCD.Location = New System.Drawing.Point(99, 6)
        Me.HD_TANCD.MaxLength = 13
        Me.HD_TANCD.Name = "HD_TANCD"
        Me.HD_TANCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TANCD.Size = New System.Drawing.Size(63, 25)
        Me.HD_TANCD.TabIndex = 3
        Me.HD_TANCD.Text = "XXXXX6"
        '
        'CS_TANCD
        '
        Me.CS_TANCD.Location = New System.Drawing.Point(5, 6)
        Me.CS_TANCD.Name = "CS_TANCD"
        Me.CS_TANCD.Size = New System.Drawing.Size(95, 25)
        Me.CS_TANCD.TabIndex = 7
        Me.CS_TANCD.TabStop = False
        Me.CS_TANCD.Text = " 担当者ｺｰﾄﾞ  "
        '
        'CS_JDNYTDT
        '
        Me.CS_JDNYTDT.Location = New System.Drawing.Point(456, 6)
        Me.CS_JDNYTDT.Name = "CS_JDNYTDT"
        Me.CS_JDNYTDT.Size = New System.Drawing.Size(95, 25)
        Me.CS_JDNYTDT.TabIndex = 9
        Me.CS_JDNYTDT.TabStop = False
        Me.CS_JDNYTDT.Text = " 受注予定日  "
        '
        '_FM_Panel3D1_0
        '
        Me._FM_Panel3D1_0.Location = New System.Drawing.Point(635, 6)
        Me._FM_Panel3D1_0.Name = "_FM_Panel3D1_0"
        Me._FM_Panel3D1_0.Size = New System.Drawing.Size(99, 25)
        Me._FM_Panel3D1_0.TabIndex = 11
        Me._FM_Panel3D1_0.Text = " 親案件番号"
        '
        '_FM_Panel3D1_1
        '
        Me._FM_Panel3D1_1.Location = New System.Drawing.Point(1, 39)
        Me._FM_Panel3D1_1.Name = "_FM_Panel3D1_1"
        Me._FM_Panel3D1_1.Size = New System.Drawing.Size(1013, 25)
        Me._FM_Panel3D1_1.TabIndex = 6
        Me._FM_Panel3D1_1.Text = "担当者 件名                                     得意先名                             代表型式 " &
    "                    受注予定日 案件番号 親案件番号"
        '
        'LST
        '
        Me.LST.BackColor = System.Drawing.SystemColors.Window
        Me.LST.Cursor = System.Windows.Forms.Cursors.Default
        Me.LST.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LST.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LST.Items.AddRange(New Object() {"MMMMM6 MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4 MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMM" &
                "M36 XXXXXXXXX1XXXXXXXXX2XXXXXX28 9999/99/99 99999999 99999999"})
        Me.LST.Location = New System.Drawing.Point(1, 62)
        Me.LST.Name = "LST"
        Me.LST.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LST.Size = New System.Drawing.Size(1013, 199)
        Me.LST.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.HighlightText
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(5, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(1009, 1)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "MMMMM6 MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4 MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMM" &
    "M36 XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3 9999/99/99 99999999 99999999"
        '
        '_IM_PrevCm_0
        '
        Me._IM_PrevCm_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_PrevCm_0.Image = CType(resources.GetObject("_IM_PrevCm_0.Image"), System.Drawing.Image)
        Me.IM_PrevCm.SetIndex(Me._IM_PrevCm_0, CType(0, Short))
        Me._IM_PrevCm_0.Location = New System.Drawing.Point(257, 408)
        Me._IM_PrevCm_0.Name = "_IM_PrevCm_0"
        Me._IM_PrevCm_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_PrevCm_0.TabIndex = 13
        Me._IM_PrevCm_0.TabStop = False
        Me._IM_PrevCm_0.Visible = False
        '
        '_IM_NextCm_0
        '
        Me._IM_NextCm_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_NextCm_0.Image = CType(resources.GetObject("_IM_NextCm_0.Image"), System.Drawing.Image)
        Me.IM_NextCm.SetIndex(Me._IM_NextCm_0, CType(0, Short))
        Me._IM_NextCm_0.Location = New System.Drawing.Point(317, 408)
        Me._IM_NextCm_0.Name = "_IM_NextCm_0"
        Me._IM_NextCm_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_NextCm_0.TabIndex = 14
        Me._IM_NextCm_0.TabStop = False
        Me._IM_NextCm_0.Visible = False
        '
        '_IM_NextCm_1
        '
        Me._IM_NextCm_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_NextCm_1.Image = CType(resources.GetObject("_IM_NextCm_1.Image"), System.Drawing.Image)
        Me.IM_NextCm.SetIndex(Me._IM_NextCm_1, CType(1, Short))
        Me._IM_NextCm_1.Location = New System.Drawing.Point(344, 408)
        Me._IM_NextCm_1.Name = "_IM_NextCm_1"
        Me._IM_NextCm_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_NextCm_1.TabIndex = 15
        Me._IM_NextCm_1.TabStop = False
        Me._IM_NextCm_1.Visible = False
        '
        '_IM_PrevCm_1
        '
        Me._IM_PrevCm_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_PrevCm_1.Image = CType(resources.GetObject("_IM_PrevCm_1.Image"), System.Drawing.Image)
        Me.IM_PrevCm.SetIndex(Me._IM_PrevCm_1, CType(1, Short))
        Me._IM_PrevCm_1.Location = New System.Drawing.Point(284, 408)
        Me._IM_PrevCm_1.Name = "_IM_PrevCm_1"
        Me._IM_PrevCm_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_PrevCm_1.TabIndex = 16
        Me._IM_PrevCm_1.TabStop = False
        Me._IM_PrevCm_1.Visible = False
        '
        'CM_PrevCm
        '
        Me.CM_PrevCm.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_PrevCm.Image = CType(resources.GetObject("CM_PrevCm.Image"), System.Drawing.Image)
        Me.CM_PrevCm.Location = New System.Drawing.Point(414, 229)
        Me.CM_PrevCm.Name = "CM_PrevCm"
        Me.CM_PrevCm.Size = New System.Drawing.Size(24, 22)
        Me.CM_PrevCm.TabIndex = 17
        Me.CM_PrevCm.TabStop = False
        Me.CM_PrevCm.Visible = False
        '
        'CM_NextCm
        '
        Me.CM_NextCm.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_NextCm.Image = CType(resources.GetObject("CM_NextCm.Image"), System.Drawing.Image)
        Me.CM_NextCm.Location = New System.Drawing.Point(579, 229)
        Me.CM_NextCm.Name = "CM_NextCm"
        Me.CM_NextCm.Size = New System.Drawing.Size(24, 22)
        Me.CM_NextCm.TabIndex = 18
        Me.CM_NextCm.TabStop = False
        Me.CM_NextCm.Visible = False
        '
        'btnF2
        '
        Me.btnF2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF2.Location = New System.Drawing.Point(92, 267)
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(75, 39)
        Me.btnF2.TabIndex = 44
        Me.btnF2.Text = "(F2)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "検索"
        Me.btnF2.UseVisualStyleBackColor = True
        '
        'btnF1
        '
        Me.btnF1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF1.Location = New System.Drawing.Point(12, 267)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(75, 39)
        Me.btnF1.TabIndex = 43
        Me.btnF1.Text = "(F1)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "確定"
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'btnF8
        '
        Me.btnF8.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF8.Location = New System.Drawing.Point(510, 267)
        Me.btnF8.Name = "btnF8"
        Me.btnF8.Size = New System.Drawing.Size(75, 39)
        Me.btnF8.TabIndex = 46
        Me.btnF8.Text = "(F8)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "次頁"
        Me.btnF8.UseVisualStyleBackColor = True
        '
        'btnF7
        '
        Me.btnF7.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF7.Location = New System.Drawing.Point(430, 267)
        Me.btnF7.Name = "btnF7"
        Me.btnF7.Size = New System.Drawing.Size(75, 39)
        Me.btnF7.TabIndex = 45
        Me.btnF7.Text = "(F7)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "前頁"
        Me.btnF7.UseVisualStyleBackColor = True
        '
        'btnF9
        '
        Me.btnF9.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF9.Location = New System.Drawing.Point(848, 267)
        Me.btnF9.Name = "btnF9"
        Me.btnF9.Size = New System.Drawing.Size(75, 39)
        Me.btnF9.TabIndex = 47
        Me.btnF9.Text = "(F9)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "クリア"
        Me.btnF9.UseVisualStyleBackColor = True
        '
        'btnF12
        '
        Me.btnF12.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF12.Location = New System.Drawing.Point(928, 267)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(75, 39)
        Me.btnF12.TabIndex = 48
        Me.btnF12.Text = "(F12)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'WLS_ANID
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1015, 319)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnF9)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.btnF2)
        Me.Controls.Add(Me.btnF1)
        Me.Controls.Add(Me.btnF8)
        Me.Controls.Add(Me.btnF7)
        Me.Controls.Add(Me.Panel3D1)
        Me.Controls.Add(Me._FM_Panel3D1_1)
        Me.Controls.Add(Me.LST)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._IM_PrevCm_0)
        Me.Controls.Add(Me._IM_NextCm_0)
        Me.Controls.Add(Me._IM_NextCm_1)
        Me.Controls.Add(Me._IM_PrevCm_1)
        Me.Controls.Add(Me.WLSOK)
        Me.Controls.Add(Me.WLSCANCEL)
        Me.Controls.Add(Me.CM_PrevCm)
        Me.Controls.Add(Me.CM_NextCm)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(4, 214)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WLS_ANID"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "案件情報検索"
        Me.Panel3D1.ResumeLayout(False)
        CType(Me._IM_PrevCm_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_NextCm_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_NextCm_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_PrevCm_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_PrevCm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_NextCm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_NextCm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_PrevCm, System.ComponentModel.ISupportInitialize).EndInit()
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