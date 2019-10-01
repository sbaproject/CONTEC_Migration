<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRptViewer
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
    '2019/05/13 CHG START
    'Public WithEvents CmDlg As CommonDialog
    Public WithEvents CmDlg As System.Windows.Forms.OpenFileDialog
    '2019/05/13 CHG E N D
	Public WithEvents cmdCSV As System.Windows.Forms.Button
    Public WithEvents cmdPrt As System.Windows.Forms.Button
    '2019/05\13 CHG START
    'Public WithEvents CRViewer91 As CRViewer9
    Public WithEvents CRViewer91 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    '2019/05/13 CHG E N D
    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更できます。
    'コード エディタを使用して、変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRptViewer))
		Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
        '2019/05/13 CHG START
        'Me.CmDlg = New CommonDialog
        Me.CmDlg = New System.Windows.Forms.OpenFileDialog()
        '2019/05/13 CHG E N D
		Me.cmdCSV = New System.Windows.Forms.Button
        Me.cmdPrt = New System.Windows.Forms.Button
        '2019/05/13 CHG START
        'Me.CRViewer91 = New CRViewer9
        Me.CRViewer91 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        '2019/05/13 CHG E N D 
        Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "帳票タイトル"
		Me.ClientSize = New System.Drawing.Size(801, 568)
		Me.Location = New System.Drawing.Point(4, 30)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "frmRptViewer"
        '2019/05.13 CHG START
        'Me.CmDlg.Name = "CmDlg"
        '2019/05/13 CHG E N D
		Me.cmdCSV.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdCSV.Size = New System.Drawing.Size(24, 20)
		Me.cmdCSV.Location = New System.Drawing.Point(504, 0)
		Me.cmdCSV.Image = CType(resources.GetObject("cmdCSV.Image"), System.Drawing.Image)
		Me.cmdCSV.TabIndex = 2
		Me.cmdCSV.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCSV.CausesValidation = True
		Me.cmdCSV.Enabled = True
		Me.cmdCSV.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCSV.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCSV.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCSV.TabStop = True
		Me.cmdCSV.Name = "cmdCSV"
		Me.cmdPrt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdPrt.Size = New System.Drawing.Size(24, 20)
		Me.cmdPrt.Location = New System.Drawing.Point(464, 0)
		Me.cmdPrt.Image = CType(resources.GetObject("cmdPrt.Image"), System.Drawing.Image)
		Me.cmdPrt.TabIndex = 1
		Me.cmdPrt.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrt.CausesValidation = True
		Me.cmdPrt.Enabled = True
		Me.cmdPrt.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrt.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrt.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrt.TabStop = True
		Me.cmdPrt.Name = "cmdPrt"
        'Me.CRViewer91.CausesValidation = 0
        'Me.CRViewer91.Size = New System.Drawing.Size(779, 539)
        'Me.CRViewer91.Location = New System.Drawing.Point(0, 8)
        'Me.CRViewer91.TabIndex = 0
        'Me.CRViewer91.lastProp = 500
        'Me.CRViewer91._cx = 20611
        'Me.CRViewer91._cy = 14261
        'Me.CRViewer91.DisplayGroupTree = 0
        'Me.CRViewer91.DisplayToolbar = -1
        'Me.CRViewer91.EnableGroupTree = 0
        'Me.CRViewer91.EnableNavigationControls = -1
        'Me.CRViewer91.EnableStopButton = -1
        'Me.CRViewer91.EnablePrintButton = 0
        'Me.CRViewer91.EnableZoomControl = -1
        'Me.CRViewer91.EnableCloseButton = 0
        'Me.CRViewer91.EnableProgressControl = -1
        'Me.CRViewer91.EnableSearchControl = -1
        'Me.CRViewer91.EnableRefreshButton = 0
        'Me.CRViewer91.EnableDrillDown = 0
        'Me.CRViewer91.EnableAnimationControl = 0
        'Me.CRViewer91.EnableSelectExpertButton = 0
        'Me.CRViewer91.EnableToolbar = -1
        'Me.CRViewer91.DisplayBorder = 0
        'Me.CRViewer91.DisplayTabs = 0
        'Me.CRViewer91.DisplayBackgroundEdge = 0
        'Me.CRViewer91.SelectionFormula = ""
        'Me.CRViewer91.EnablePopupMenu = 0
        'Me.CRViewer91.EnableExportButton = -1
        'Me.CRViewer91.EnableSearchExpertButton = 0
        'Me.CRViewer91.EnableHelpButton = 0
        'Me.CRViewer91.LaunchHTTPHyperlinksInNewBrowser = -1
        'Me.CRViewer91.Name = "CRViewer91"
        Me.CRViewer91.ActiveViewIndex = -1
        Me.CRViewer91.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRViewer91.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRViewer91.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRViewer91.ForeColor = System.Drawing.SystemColors.Control
        Me.CRViewer91.Location = New System.Drawing.Point(0, 0)
        Me.CRViewer91.Name = "CRViewer91"
        Me.CRViewer91.ShowCloseButton = False
        Me.CRViewer91.ShowCopyButton = False
        Me.CRViewer91.ShowGroupTreeButton = False
        Me.CRViewer91.ShowParameterPanelButton = False
        Me.CRViewer91.ShowPrintButton = False
        Me.CRViewer91.ShowRefreshButton = False
        Me.CRViewer91.Size = New System.Drawing.Size(992, 373)
        Me.CRViewer91.TabIndex = 0
        Me.CRViewer91.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

        'Me.Controls.Add(CmDlg)
        Me.Controls.Add(cmdCSV)
		Me.Controls.Add(cmdPrt)
		Me.Controls.Add(CRViewer91)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class