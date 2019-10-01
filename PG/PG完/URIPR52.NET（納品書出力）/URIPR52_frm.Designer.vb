<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FR_SSSMAIN
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
	Public WithEvents HD_OPENM As System.Windows.Forms.TextBox
	Public WithEvents HD_OPEID As System.Windows.Forms.TextBox
    Public WithEvents HD_HAKKOU As System.Windows.Forms.TextBox
	Public WithEvents HD_JDNTRNM As System.Windows.Forms.TextBox
	Public WithEvents HD_BMNNM As System.Windows.Forms.TextBox
	Public WithEvents HD_TOKRN As System.Windows.Forms.TextBox
	Public WithEvents HD_TANNM As System.Windows.Forms.TextBox
	Public WithEvents HD_PRTKB As System.Windows.Forms.TextBox
	Public WithEvents HD_JDNTRKB As System.Windows.Forms.TextBox
	Public WithEvents HD_TOKCD As System.Windows.Forms.TextBox
	Public WithEvents HD_JDNNO As System.Windows.Forms.TextBox
	Public WithEvents HD_KINKYU As System.Windows.Forms.TextBox
	Public WithEvents HD_DENDT As System.Windows.Forms.TextBox
	Public WithEvents HD_TANCD As System.Windows.Forms.TextBox
	Public WithEvents HD_BMNCD As System.Windows.Forms.TextBox
	Public WithEvents Label15 As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Frame3D1 As System.Windows.Forms.GroupBox
	Public WithEvents TM_StartUp As System.Windows.Forms.Timer
	Public WithEvents TX_CursorRest As System.Windows.Forms.TextBox
    Public WithEvents CM_LCANCEL As Button
    'Public WithEvents _FM_Panel3D4_12 As Label
    'Public WithEvents FM_Panel3D15 As VB6.PanelArray
    'Public WithEvents FM_Panel3D2 As VB6.PanelArray
    'Public WithEvents FM_Panel3D4 As VB6.PanelArray
    'Public WithEvents IM_Denkyu As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    'Public WithEvents IM_EndCm As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    'Public WithEvents IM_FSTART As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    'Public WithEvents IM_LCONFIG As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    'Public WithEvents IM_LSTART As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    'Public WithEvents IM_Slist As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    'Public WithEvents IM_VSTART As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    Public WithEvents MN_LSTART As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_VSTART As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_LCONFIG As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents bar11 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents MN_EndCm As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_Ctrl As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_APPENDC As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_ClearItm As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_UnDoItem As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Bar21 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents MN_Cut As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_Copy As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_Paste As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_EditMn As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_Slist As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MN_Oprt As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents SM_AllCopy As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents SM_FullPast As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents SM_Esc As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents SM_ShortCut As System.Windows.Forms.ContextMenuStrip
    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更できます。
    'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.HD_OPENM = New System.Windows.Forms.TextBox()
        Me.HD_OPEID = New System.Windows.Forms.TextBox()
        Me.SYSDT = New System.Windows.Forms.Label()
        Me.CMDialogL = New System.Windows.Forms.OpenFileDialog()
        Me.Frame3D1 = New System.Windows.Forms.GroupBox()
        Me.HD_HAKKOU = New System.Windows.Forms.TextBox()
        Me.HD_JDNTRNM = New System.Windows.Forms.TextBox()
        Me.HD_BMNNM = New System.Windows.Forms.TextBox()
        Me.HD_TOKRN = New System.Windows.Forms.TextBox()
        Me.HD_TANNM = New System.Windows.Forms.TextBox()
        Me.HD_PRTKB = New System.Windows.Forms.TextBox()
        Me.HD_JDNTRKB = New System.Windows.Forms.TextBox()
        Me.HD_TOKCD = New System.Windows.Forms.TextBox()
        Me.HD_JDNNO = New System.Windows.Forms.TextBox()
        Me.HD_KINKYU = New System.Windows.Forms.TextBox()
        Me.HD_DENDT = New System.Windows.Forms.TextBox()
        Me.HD_TANCD = New System.Windows.Forms.TextBox()
        Me.HD_BMNCD = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TM_StartUp = New System.Windows.Forms.Timer(Me.components)
        Me.TX_CursorRest = New System.Windows.Forms.TextBox()
        Me.CM_LCANCEL = New System.Windows.Forms.Button()
        Me.MN_Ctrl = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_LSTART = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_VSTART = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_LCONFIG = New System.Windows.Forms.ToolStripMenuItem()
        Me.bar11 = New System.Windows.Forms.ToolStripSeparator()
        Me.MN_EndCm = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_EditMn = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_APPENDC = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_ClearItm = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_UnDoItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Bar21 = New System.Windows.Forms.ToolStripSeparator()
        Me.MN_Cut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_Copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_Paste = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_Oprt = New System.Windows.Forms.ToolStripMenuItem()
        Me.MN_Slist = New System.Windows.Forms.ToolStripMenuItem()
        Me.SM_ShortCut = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SM_AllCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.SM_FullPast = New System.Windows.Forms.ToolStripMenuItem()
        Me.SM_Esc = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._FM_Panel3D1_2 = New System.Windows.Forms.Label()
        Me.Frame3D1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'HD_OPENM
        '
        Me.HD_OPENM.AcceptsReturn = True
        Me.HD_OPENM.BackColor = System.Drawing.SystemColors.Control
        Me.HD_OPENM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_OPENM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_OPENM.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_OPENM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_OPENM.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_OPENM.Location = New System.Drawing.Point(768, 48)
        Me.HD_OPENM.MaxLength = 24
        Me.HD_OPENM.Name = "HD_OPENM"
        Me.HD_OPENM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_OPENM.Size = New System.Drawing.Size(151, 19)
        Me.HD_OPENM.TabIndex = 37
        Me.HD_OPENM.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'HD_OPEID
        '
        Me.HD_OPEID.AcceptsReturn = True
        Me.HD_OPEID.BackColor = System.Drawing.SystemColors.Control
        Me.HD_OPEID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_OPEID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_OPEID.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_OPEID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_OPEID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_OPEID.Location = New System.Drawing.Point(722, 48)
        Me.HD_OPEID.MaxLength = 10
        Me.HD_OPEID.Name = "HD_OPEID"
        Me.HD_OPEID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_OPEID.Size = New System.Drawing.Size(47, 19)
        Me.HD_OPEID.TabIndex = 36
        Me.HD_OPEID.Text = "XXXXX6"
        '
        'SYSDT
        '
        Me.SYSDT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SYSDT.Location = New System.Drawing.Point(828, 9)
        Me.SYSDT.Name = "SYSDT"
        Me.SYSDT.Size = New System.Drawing.Size(94, 19)
        Me.SYSDT.TabIndex = 12
        Me.SYSDT.Text = "YYYY/MM/DD"
        '
        'Frame3D1
        '
        Me.Frame3D1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3D1.Controls.Add(Me.HD_HAKKOU)
        Me.Frame3D1.Controls.Add(Me.HD_JDNTRNM)
        Me.Frame3D1.Controls.Add(Me.HD_BMNNM)
        Me.Frame3D1.Controls.Add(Me.HD_TOKRN)
        Me.Frame3D1.Controls.Add(Me.HD_TANNM)
        Me.Frame3D1.Controls.Add(Me.HD_PRTKB)
        Me.Frame3D1.Controls.Add(Me.HD_JDNTRKB)
        Me.Frame3D1.Controls.Add(Me.HD_TOKCD)
        Me.Frame3D1.Controls.Add(Me.HD_JDNNO)
        Me.Frame3D1.Controls.Add(Me.HD_KINKYU)
        Me.Frame3D1.Controls.Add(Me.HD_DENDT)
        Me.Frame3D1.Controls.Add(Me.HD_TANCD)
        Me.Frame3D1.Controls.Add(Me.HD_BMNCD)
        Me.Frame3D1.Controls.Add(Me.Label15)
        Me.Frame3D1.Controls.Add(Me.Label14)
        Me.Frame3D1.Controls.Add(Me.Label13)
        Me.Frame3D1.Controls.Add(Me.Label12)
        Me.Frame3D1.Controls.Add(Me.Label6)
        Me.Frame3D1.Controls.Add(Me.Label5)
        Me.Frame3D1.Controls.Add(Me.Label1)
        Me.Frame3D1.Controls.Add(Me.Label11)
        Me.Frame3D1.Controls.Add(Me.Label10)
        Me.Frame3D1.Controls.Add(Me.Label9)
        Me.Frame3D1.Controls.Add(Me.Label8)
        Me.Frame3D1.Controls.Add(Me.Label7)
        Me.Frame3D1.Controls.Add(Me.Label4)
        Me.Frame3D1.Controls.Add(Me.Label3)
        Me.Frame3D1.Controls.Add(Me.Label2)
        Me.Frame3D1.ForeColor = System.Drawing.Color.Black
        Me.Frame3D1.Location = New System.Drawing.Point(36, 81)
        Me.Frame3D1.Name = "Frame3D1"
        Me.Frame3D1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3D1.Size = New System.Drawing.Size(883, 315)
        Me.Frame3D1.TabIndex = 1
        Me.Frame3D1.TabStop = False
        Me.Frame3D1.Text = "条件指定"
        '
        'HD_HAKKOU
        '
        Me.HD_HAKKOU.AcceptsReturn = True
        Me.HD_HAKKOU.BackColor = System.Drawing.Color.White
        Me.HD_HAKKOU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_HAKKOU.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_HAKKOU.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_HAKKOU.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_HAKKOU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_HAKKOU.Location = New System.Drawing.Point(141, 21)
        Me.HD_HAKKOU.MaxLength = 5
        Me.HD_HAKKOU.Name = "HD_HAKKOU"
        Me.HD_HAKKOU.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_HAKKOU.Size = New System.Drawing.Size(20, 19)
        Me.HD_HAKKOU.TabIndex = 39
        Me.HD_HAKKOU.Text = "9"
        '
        'HD_JDNTRNM
        '
        Me.HD_JDNTRNM.AcceptsReturn = True
        Me.HD_JDNTRNM.BackColor = System.Drawing.Color.White
        Me.HD_JDNTRNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_JDNTRNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_JDNTRNM.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_JDNTRNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_JDNTRNM.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_JDNTRNM.Location = New System.Drawing.Point(160, 248)
        Me.HD_JDNTRNM.MaxLength = 14
        Me.HD_JDNTRNM.Name = "HD_JDNTRNM"
        Me.HD_JDNTRNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_JDNTRNM.Size = New System.Drawing.Size(77, 19)
        Me.HD_JDNTRNM.TabIndex = 35
        Me.HD_JDNTRNM.Text = "MMMMMMMMM1"
        '
        'HD_BMNNM
        '
        Me.HD_BMNNM.AcceptsReturn = True
        Me.HD_BMNNM.BackColor = System.Drawing.Color.White
        Me.HD_BMNNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_BMNNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_BMNNM.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_BMNNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_BMNNM.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_BMNNM.Location = New System.Drawing.Point(190, 118)
        Me.HD_BMNNM.MaxLength = 44
        Me.HD_BMNNM.Name = "HD_BMNNM"
        Me.HD_BMNNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_BMNNM.Size = New System.Drawing.Size(288, 19)
        Me.HD_BMNNM.TabIndex = 34
        Me.HD_BMNNM.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
        '
        'HD_TOKRN
        '
        Me.HD_TOKRN.AcceptsReturn = True
        Me.HD_TOKRN.BackColor = System.Drawing.Color.White
        Me.HD_TOKRN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TOKRN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TOKRN.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_TOKRN.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TOKRN.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_TOKRN.Location = New System.Drawing.Point(190, 216)
        Me.HD_TOKRN.MaxLength = 44
        Me.HD_TOKRN.Name = "HD_TOKRN"
        Me.HD_TOKRN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TOKRN.Size = New System.Drawing.Size(288, 19)
        Me.HD_TOKRN.TabIndex = 33
        Me.HD_TOKRN.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
        '
        'HD_TANNM
        '
        Me.HD_TANNM.AcceptsReturn = True
        Me.HD_TANNM.BackColor = System.Drawing.Color.White
        Me.HD_TANNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TANNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TANNM.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_TANNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TANNM.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_TANNM.Location = New System.Drawing.Point(190, 85)
        Me.HD_TANNM.MaxLength = 24
        Me.HD_TANNM.Name = "HD_TANNM"
        Me.HD_TANNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TANNM.Size = New System.Drawing.Size(147, 19)
        Me.HD_TANNM.TabIndex = 32
        Me.HD_TANNM.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'HD_PRTKB
        '
        Me.HD_PRTKB.AcceptsReturn = True
        Me.HD_PRTKB.BackColor = System.Drawing.Color.White
        Me.HD_PRTKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_PRTKB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_PRTKB.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_PRTKB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_PRTKB.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_PRTKB.Location = New System.Drawing.Point(141, 280)
        Me.HD_PRTKB.MaxLength = 5
        Me.HD_PRTKB.Name = "HD_PRTKB"
        Me.HD_PRTKB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_PRTKB.Size = New System.Drawing.Size(20, 19)
        Me.HD_PRTKB.TabIndex = 26
        Me.HD_PRTKB.Text = "9"
        '
        'HD_JDNTRKB
        '
        Me.HD_JDNTRKB.AcceptsReturn = True
        Me.HD_JDNTRKB.BackColor = System.Drawing.Color.White
        Me.HD_JDNTRKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_JDNTRKB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_JDNTRKB.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_JDNTRKB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_JDNTRKB.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_JDNTRKB.Location = New System.Drawing.Point(141, 248)
        Me.HD_JDNTRKB.MaxLength = 6
        Me.HD_JDNTRKB.Name = "HD_JDNTRKB"
        Me.HD_JDNTRKB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_JDNTRKB.Size = New System.Drawing.Size(20, 19)
        Me.HD_JDNTRKB.TabIndex = 25
        Me.HD_JDNTRKB.Text = "X2"
        '
        'HD_TOKCD
        '
        Me.HD_TOKCD.AcceptsReturn = True
        Me.HD_TOKCD.BackColor = System.Drawing.Color.White
        Me.HD_TOKCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TOKCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TOKCD.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_TOKCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TOKCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_TOKCD.Location = New System.Drawing.Point(141, 216)
        Me.HD_TOKCD.MaxLength = 9
        Me.HD_TOKCD.Name = "HD_TOKCD"
        Me.HD_TOKCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TOKCD.Size = New System.Drawing.Size(49, 19)
        Me.HD_TOKCD.TabIndex = 24
        Me.HD_TOKCD.Text = "XXXX5"
        '
        'HD_JDNNO
        '
        Me.HD_JDNNO.AcceptsReturn = True
        Me.HD_JDNNO.BackColor = System.Drawing.Color.White
        Me.HD_JDNNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_JDNNO.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_JDNNO.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_JDNNO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_JDNNO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_JDNNO.Location = New System.Drawing.Point(141, 184)
        Me.HD_JDNNO.MaxLength = 10
        Me.HD_JDNNO.Name = "HD_JDNNO"
        Me.HD_JDNNO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_JDNNO.Size = New System.Drawing.Size(49, 19)
        Me.HD_JDNNO.TabIndex = 23
        Me.HD_JDNNO.Text = "XXXXX6"
        '
        'HD_KINKYU
        '
        Me.HD_KINKYU.AcceptsReturn = True
        Me.HD_KINKYU.BackColor = System.Drawing.Color.White
        Me.HD_KINKYU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_KINKYU.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_KINKYU.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_KINKYU.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_KINKYU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_KINKYU.Location = New System.Drawing.Point(141, 54)
        Me.HD_KINKYU.MaxLength = 5
        Me.HD_KINKYU.Name = "HD_KINKYU"
        Me.HD_KINKYU.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_KINKYU.Size = New System.Drawing.Size(20, 19)
        Me.HD_KINKYU.TabIndex = 9
        Me.HD_KINKYU.Text = "9"
        '
        'HD_DENDT
        '
        Me.HD_DENDT.AcceptsReturn = True
        Me.HD_DENDT.BackColor = System.Drawing.Color.White
        Me.HD_DENDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_DENDT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_DENDT.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_DENDT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_DENDT.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_DENDT.Location = New System.Drawing.Point(141, 152)
        Me.HD_DENDT.MaxLength = 14
        Me.HD_DENDT.Name = "HD_DENDT"
        Me.HD_DENDT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_DENDT.Size = New System.Drawing.Size(79, 19)
        Me.HD_DENDT.TabIndex = 8
        Me.HD_DENDT.Text = "9999/99/99"
        '
        'HD_TANCD
        '
        Me.HD_TANCD.AcceptsReturn = True
        Me.HD_TANCD.BackColor = System.Drawing.Color.White
        Me.HD_TANCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TANCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TANCD.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_TANCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TANCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_TANCD.Location = New System.Drawing.Point(141, 85)
        Me.HD_TANCD.MaxLength = 10
        Me.HD_TANCD.Name = "HD_TANCD"
        Me.HD_TANCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TANCD.Size = New System.Drawing.Size(49, 19)
        Me.HD_TANCD.TabIndex = 7
        Me.HD_TANCD.Text = "XXXXX6"
        '
        'HD_BMNCD
        '
        Me.HD_BMNCD.AcceptsReturn = True
        Me.HD_BMNCD.BackColor = System.Drawing.Color.White
        Me.HD_BMNCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_BMNCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_BMNCD.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HD_BMNCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_BMNCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_BMNCD.Location = New System.Drawing.Point(141, 118)
        Me.HD_BMNCD.MaxLength = 10
        Me.HD_BMNCD.Name = "HD_BMNCD"
        Me.HD_BMNCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_BMNCD.Size = New System.Drawing.Size(49, 19)
        Me.HD_BMNCD.TabIndex = 2
        Me.HD_BMNCD.Text = "123456"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label15.Location = New System.Drawing.Point(24, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(97, 22)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "発行区分"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label14.Location = New System.Drawing.Point(168, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(97, 22)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "0:通常 1:指定"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label13.Location = New System.Drawing.Point(168, 291)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(161, 19)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "9:発行失敗時"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label12.Location = New System.Drawing.Point(168, 275)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(161, 19)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "0:未発行　1:再発行"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label6.Location = New System.Drawing.Point(232, 163)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(257, 19)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "　再発行は指定日のみ出力対象とする"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label5.Location = New System.Drawing.Point(232, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(161, 19)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "※未発行は指定日以前、"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(168, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(97, 22)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "1:通常 2:緊急"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label11.Location = New System.Drawing.Point(24, 283)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(106, 22)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "出力フラグ"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label10.Location = New System.Drawing.Point(24, 251)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(106, 22)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "受注取引区分"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label9.Location = New System.Drawing.Point(24, 219)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(106, 22)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "得意先"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label8.Location = New System.Drawing.Point(24, 187)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(106, 22)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "受注番号"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label7.Location = New System.Drawing.Point(24, 155)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(106, 22)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "売上日"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.Location = New System.Drawing.Point(24, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(97, 22)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "営業担当者"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(24, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(97, 22)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "緊急出荷"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(24, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(106, 22)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "営業部門"
        '
        'TM_StartUp
        '
        Me.TM_StartUp.Interval = 1
        '
        'TX_CursorRest
        '
        Me.TX_CursorRest.AcceptsReturn = True
        Me.TX_CursorRest.BackColor = System.Drawing.SystemColors.Window
        Me.TX_CursorRest.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TX_CursorRest.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TX_CursorRest.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TX_CursorRest.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TX_CursorRest.Location = New System.Drawing.Point(2457, 2457)
        Me.TX_CursorRest.MaxLength = 0
        Me.TX_CursorRest.Name = "TX_CursorRest"
        Me.TX_CursorRest.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_CursorRest.Size = New System.Drawing.Size(19, 13)
        Me.TX_CursorRest.TabIndex = 0
        '
        'CM_LCANCEL
        '
        Me.CM_LCANCEL.Location = New System.Drawing.Point(431, 556)
        Me.CM_LCANCEL.Name = "CM_LCANCEL"
        Me.CM_LCANCEL.Size = New System.Drawing.Size(76, 22)
        Me.CM_LCANCEL.TabIndex = 10
        Me.CM_LCANCEL.TabStop = False
        Me.CM_LCANCEL.Text = "中 止"
        '
        'MN_Ctrl
        '
        Me.MN_Ctrl.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MN_LSTART, Me.MN_VSTART, Me.MN_LCONFIG, Me.bar11, Me.MN_EndCm})
        Me.MN_Ctrl.Name = "MN_Ctrl"
        Me.MN_Ctrl.Size = New System.Drawing.Size(32, 19)
        Me.MN_Ctrl.Text = "処理(&1)"
        '
        'MN_LSTART
        '
        Me.MN_LSTART.Name = "MN_LSTART"
        Me.MN_LSTART.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.MN_LSTART.Size = New System.Drawing.Size(160, 22)
        Me.MN_LSTART.Text = "印刷(&P)"
        '
        'MN_VSTART
        '
        Me.MN_VSTART.Name = "MN_VSTART"
        Me.MN_VSTART.Size = New System.Drawing.Size(160, 22)
        Me.MN_VSTART.Text = "画面表示"
        '
        'MN_LCONFIG
        '
        Me.MN_LCONFIG.Name = "MN_LCONFIG"
        Me.MN_LCONFIG.Size = New System.Drawing.Size(160, 22)
        Me.MN_LCONFIG.Text = "印刷設定(&I)..."
        '
        'bar11
        '
        Me.bar11.Name = "bar11"
        Me.bar11.Size = New System.Drawing.Size(157, 6)
        '
        'MN_EndCm
        '
        Me.MN_EndCm.Name = "MN_EndCm"
        Me.MN_EndCm.Size = New System.Drawing.Size(160, 22)
        Me.MN_EndCm.Text = "終了(&X)"
        '
        'MN_EditMn
        '
        Me.MN_EditMn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MN_APPENDC, Me.MN_ClearItm, Me.MN_UnDoItem, Me.Bar21, Me.MN_Cut, Me.MN_Copy, Me.MN_Paste})
        Me.MN_EditMn.Name = "MN_EditMn"
        Me.MN_EditMn.Size = New System.Drawing.Size(32, 19)
        Me.MN_EditMn.Text = "編集(&2)"
        '
        'MN_APPENDC
        '
        Me.MN_APPENDC.Name = "MN_APPENDC"
        Me.MN_APPENDC.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.MN_APPENDC.Size = New System.Drawing.Size(198, 22)
        Me.MN_APPENDC.Text = "画面初期化(&S)"
        '
        'MN_ClearItm
        '
        Me.MN_ClearItm.Name = "MN_ClearItm"
        Me.MN_ClearItm.Size = New System.Drawing.Size(198, 22)
        Me.MN_ClearItm.Text = "項目初期化"
        '
        'MN_UnDoItem
        '
        Me.MN_UnDoItem.Name = "MN_UnDoItem"
        Me.MN_UnDoItem.Size = New System.Drawing.Size(198, 22)
        Me.MN_UnDoItem.Text = "項目復元"
        '
        'Bar21
        '
        Me.Bar21.Name = "Bar21"
        Me.Bar21.Size = New System.Drawing.Size(195, 6)
        '
        'MN_Cut
        '
        Me.MN_Cut.Name = "MN_Cut"
        Me.MN_Cut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.MN_Cut.Size = New System.Drawing.Size(198, 22)
        Me.MN_Cut.Text = "切り取り(&X)"
        '
        'MN_Copy
        '
        Me.MN_Copy.Name = "MN_Copy"
        Me.MN_Copy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.MN_Copy.Size = New System.Drawing.Size(198, 22)
        Me.MN_Copy.Text = "コピー(&C)"
        '
        'MN_Paste
        '
        Me.MN_Paste.Name = "MN_Paste"
        Me.MN_Paste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.MN_Paste.Size = New System.Drawing.Size(198, 22)
        Me.MN_Paste.Text = "貼り付け(&V)"
        '
        'MN_Oprt
        '
        Me.MN_Oprt.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MN_Slist})
        Me.MN_Oprt.Name = "MN_Oprt"
        Me.MN_Oprt.Size = New System.Drawing.Size(32, 19)
        Me.MN_Oprt.Text = "補助(&3)"
        '
        'MN_Slist
        '
        Me.MN_Slist.Name = "MN_Slist"
        Me.MN_Slist.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.MN_Slist.Size = New System.Drawing.Size(180, 22)
        Me.MN_Slist.Text = "ウインドウ表示(&L)"
        '
        'SM_ShortCut
        '
        Me.SM_ShortCut.Name = "SM_ShortCut"
        Me.SM_ShortCut.Size = New System.Drawing.Size(61, 4)
        Me.SM_ShortCut.Text = "ShortCut"
        '
        'SM_AllCopy
        '
        Me.SM_AllCopy.Name = "SM_AllCopy"
        Me.SM_AllCopy.Size = New System.Drawing.Size(32, 19)
        Me.SM_AllCopy.Text = "項目内容コピー(&C)"
        '
        'SM_FullPast
        '
        Me.SM_FullPast.Name = "SM_FullPast"
        Me.SM_FullPast.Size = New System.Drawing.Size(32, 19)
        Me.SM_FullPast.Text = "項目に貼り付け(&P)"
        '
        'SM_Esc
        '
        Me.SM_Esc.Name = "SM_Esc"
        Me.SM_Esc.Size = New System.Drawing.Size(32, 19)
        Me.SM_Esc.Text = "取消し(Esc)"
        '
        'Button12
        '
        Me.Button12.CausesValidation = False
        Me.Button12.Location = New System.Drawing.Point(851, 595)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(75, 39)
        Me.Button12.TabIndex = 92
        Me.Button12.Text = "(F12)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(778, 595)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(75, 39)
        Me.Button11.TabIndex = 91
        Me.Button11.Text = "(F11)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.CausesValidation = False
        Me.Button10.Location = New System.Drawing.Point(706, 595)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 39)
        Me.Button10.TabIndex = 90
        Me.Button10.Text = "(F10)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.CausesValidation = False
        Me.Button9.Location = New System.Drawing.Point(634, 595)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 39)
        Me.Button9.TabIndex = 89
        Me.Button9.Text = "(F9)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "クリア"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(545, 595)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 39)
        Me.Button8.TabIndex = 88
        Me.Button8.Text = "(F8)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  "
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(472, 595)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 39)
        Me.Button7.TabIndex = 87
        Me.Button7.Text = "(F7)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(399, 595)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 39)
        Me.Button6.TabIndex = 86
        Me.Button6.Text = "(F6)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  "
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(326, 595)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 39)
        Me.Button5.TabIndex = 85
        Me.Button5.Text = "(F5)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ヘルプ"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(239, 595)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 39)
        Me.Button4.TabIndex = 84
        Me.Button4.Text = "(F4)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "印刷"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(166, 595)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 39)
        Me.Button3.TabIndex = 83
        Me.Button3.Text = "(F3)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "　　"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(93, 595)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 39)
        Me.Button2.TabIndex = 82
        Me.Button2.Text = "(F2)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  "
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(20, 595)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 39)
        Me.Button1.TabIndex = 81
        Me.Button1.Text = "(F1)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Button1.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 639)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(944, 22)
        Me.StatusStrip1.TabIndex = 93
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(185, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "YYYY/MM/DD"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(185, 17)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "端末ID"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(185, 17)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Text = "ログインID"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(185, 17)
        Me.ToolStripStatusLabel4.Spring = True
        Me.ToolStripStatusLabel4.Text = "XXXXXXX"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(185, 17)
        Me.ToolStripStatusLabel5.Spring = True
        Me.ToolStripStatusLabel5.Text = "Ver.1.00"
        '
        '_FM_Panel3D1_2
        '
        Me._FM_Panel3D1_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._FM_Panel3D1_2.Location = New System.Drawing.Point(629, 48)
        Me._FM_Panel3D1_2.Name = "_FM_Panel3D1_2"
        Me._FM_Panel3D1_2.Size = New System.Drawing.Size(94, 19)
        Me._FM_Panel3D1_2.TabIndex = 94
        Me._FM_Panel3D1_2.Text = " 入力担当者"
        Me._FM_Panel3D1_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FR_SSSMAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(944, 661)
        Me.Controls.Add(Me._FM_Panel3D1_2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.HD_OPENM)
        Me.Controls.Add(Me.HD_OPEID)
        Me.Controls.Add(Me.SYSDT)
        Me.Controls.Add(Me.Frame3D1)
        Me.Controls.Add(Me.TX_CursorRest)
        Me.Controls.Add(Me.CM_LCANCEL)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(141, 146)
        Me.MaximizeBox = False
        Me.Name = "FR_SSSMAIN"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "納品書"
        Me.Frame3D1.ResumeLayout(False)
        Me.Frame3D1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents CMDialogL As System.Windows.Forms.OpenFileDialog
    Public WithEvents SYSDT As System.Windows.Forms.Label
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents _FM_Panel3D1_2 As Label
#End Region
End Class