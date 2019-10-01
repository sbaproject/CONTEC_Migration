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
    '2019/05/21 CHG START
    'Public WithEvents CS_DATNO As SSCommand5
    Public WithEvents CS_DATNO As System.Windows.Forms.Button
    '2019/05/21 CHG END
    Public WithEvents VS_Scrl As System.Windows.Forms.VScrollBar
	Public WithEvents _BD_JDNNO_0 As System.Windows.Forms.TextBox
	Public WithEvents _BD_LINNO_0 As System.Windows.Forms.TextBox
	Public WithEvents TL_SBANYUKN As System.Windows.Forms.TextBox
	Public WithEvents HD_TOKCD As System.Windows.Forms.TextBox
	Public WithEvents _BD_NYUKN_0 As System.Windows.Forms.TextBox
	Public WithEvents _BD_LINCMA_0 As System.Windows.Forms.TextBox
    Public WithEvents _BD_TEGDT_0 As System.Windows.Forms.TextBox
    Public WithEvents _BD_BNKNM_0 As System.Windows.Forms.TextBox
    Public WithEvents _BD_BNKCD_0 As System.Windows.Forms.TextBox
    Public WithEvents _BD_DKBID_0 As System.Windows.Forms.TextBox
    Public WithEvents _BD_LINCMB_0 As System.Windows.Forms.TextBox
    Public WithEvents HD_NYUDT As System.Windows.Forms.TextBox
    Public WithEvents HD_TOKRN As System.Windows.Forms.TextBox
    Public WithEvents _BD_DKBNM_0 As System.Windows.Forms.TextBox
    Public WithEvents HD_TUKKB As System.Windows.Forms.TextBox
    Public WithEvents HD_NYUKB As System.Windows.Forms.TextBox
    Public WithEvents HD_IN_TANCD As System.Windows.Forms.TextBox
    Public WithEvents HD_IN_TANNM As System.Windows.Forms.TextBox
    Public WithEvents _BD_FNYUKN_0 As System.Windows.Forms.TextBox
    Public WithEvents _BD_STNNM_0 As System.Windows.Forms.TextBox
    'add 20190729 START hou
    Public WithEvents _BD_DKBID_0_ As System.Windows.Forms.TextBox
    'add 20190729 END hou
    Public WithEvents TL_SBAFRNKN As System.Windows.Forms.TextBox
    Public WithEvents HD_KNJKOZ As System.Windows.Forms.TextBox
    Public WithEvents _BD_KANKOZ_0 As System.Windows.Forms.TextBox
    Public WithEvents TX_Message As System.Windows.Forms.TextBox
    '2019/05/21 CHG START
    'Public WithEvents _FM_Panel3D1_14 As SSPanel5
    Public WithEvents _FM_Panel3D1_14 As Label
    '2019/05/21 CHG END
    Public WithEvents _IM_Denkyu_0 As System.Windows.Forms.PictureBox
    '2019/05/21 CHG START
    'Public WithEvents _FM_Panel3D1_13 As SSPanel5
    Public WithEvents _FM_Panel3D1_13 As Label
    '2019/05/21 CHG END
    Public WithEvents TM_StartUp As System.Windows.Forms.Timer
    Public WithEvents TX_CursorRest As System.Windows.Forms.TextBox
    Public WithEvents TX_Mode As System.Windows.Forms.TextBox
    'Public WithEvents _IM_Execute_1 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_Execute_0 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_LCONFIG_0 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_LCONFIG_1 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_Denkyu_2 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_Denkyu_1 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_DELETEDE_1 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_DELETEDE_0 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_INSERTDE_1 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_INSERTDE_0 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_NEXTCM_1 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_NEXTCM_0 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_PREV_0 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_PREV_1 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_Hardcopy_0 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_Slist_0 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_EndCm_1 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_EndCm_0 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_Slist_1 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_Hardcopy_1 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_Execute_1_0 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_Execute_1_1 As System.Windows.Forms.PictureBox
    '2019/05/21 CHG START
    'Public WithEvents _FM_Panel3D1_15 As SSPanel5
    'Public WithEvents SYSDT As SSPanel5
    Public WithEvents _FM_Panel3D1_15 As Label
    Public WithEvents SYSDT As Label
    '2019/05/21 CHG END
    Public WithEvents CM_LCONFIG As System.Windows.Forms.PictureBox
    Public WithEvents CM_Execute As System.Windows.Forms.PictureBox
    Public WithEvents CM_DELETEDE As System.Windows.Forms.PictureBox
    Public WithEvents CM_INSERTDE As System.Windows.Forms.PictureBox
    Public WithEvents CM_SLIST As System.Windows.Forms.PictureBox
    'Public WithEvents CM_EndCm As System.Windows.Forms.PictureBox
    Public WithEvents Image1 As System.Windows.Forms.PictureBox
    '2019/05/21 CHG START
    '   Public WithEvents _FM_Panel3D1_0 As SSPanel5
    'Public WithEvents _FM_Panel3D1_6 As SSPanel5
    'Public WithEvents _FM_Panel3D1_10 As SSPanel5
    'Public WithEvents _FM_Panel3D1_9 As SSPanel5
    'Public WithEvents _FM_Panel3D1_4 As SSPanel5
    'Public WithEvents _FM_Panel3D1_11 As SSPanel5
    'Public WithEvents _FM_Panel3D1_3 As SSPanel5
    Public WithEvents _FM_Panel3D1_0 As Label
    Public WithEvents _FM_Panel3D1_6 As Label
    Public WithEvents _FM_Panel3D1_10 As Label
    Public WithEvents _FM_Panel3D1_9 As Label
    Public WithEvents _FM_Panel3D1_4 As Label
    Public WithEvents _FM_Panel3D1_11 As Label
    Public WithEvents _FM_Panel3D1_3 As Label
    'Public WithEvents CS_NYUDT As SSCommand5
    'Public WithEvents CS_DKBID As SSCommand5
    Public WithEvents CS_NYUDT As System.Windows.Forms.Button
    Public WithEvents CS_DKBID As System.Windows.Forms.Button
    'Public WithEvents _FM_Panel3D1_2 As SSPanel5
    'Public WithEvents _FM_Panel3D1_5 As SSPanel5
    'Public WithEvents _FM_Panel3D1_8 As SSPanel5
    'Public WithEvents _FM_Panel3D1_7 As SSPanel5
    'Public WithEvents _FM_Panel3D1_12 As SSPanel5
    'Public WithEvents _FM_Panel3D1_1 As SSPanel5
    Public WithEvents _FM_Panel3D1_2 As Label
    Public WithEvents _FM_Panel3D1_5 As Label
    Public WithEvents _FM_Panel3D1_8 As Label
    Public WithEvents _FM_Panel3D1_7 As Label
    Public WithEvents _FM_Panel3D1_12 As Label
    Public WithEvents _FM_Panel3D1_1 As Label
    '   Public WithEvents CS_BNKCD As SSCommand5
    'Public WithEvents CS_KNJKOZ As SSCommand5
    'Public WithEvents CS_TEGDT As SSCommand5
    '   Public WithEvents CS_KANKOZ As SSCommand5
    Public WithEvents CS_BNKCD As System.Windows.Forms.Button
    Public WithEvents CS_KNJKOZ As System.Windows.Forms.Button
    Public WithEvents CS_TEGDT As System.Windows.Forms.Button
    Public WithEvents CS_KANKOZ As System.Windows.Forms.Button
    '2019/05/21 CHG END
    Public WithEvents HD_DATNO As System.Windows.Forms.TextBox
    '2019/05/21 CHG START
    'Public WithEvents _FM_Panel3D1_16 As SSPanel5
    'Public WithEvents _FM_Panel3D1_17 As SSPanel5
    Public WithEvents _FM_Panel3D1_16 As Label
    Public WithEvents _FM_Panel3D1_17 As Label
    '2019/05/21 CHG END
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents BD_BNKCD As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents BD_BNKNM As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents BD_DKBID As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents BD_DKBNM As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents BD_FNYUKN As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents BD_JDNNO As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents BD_KANKOZ As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents BD_LINCMA As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents BD_LINCMB As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents BD_LINNO As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents BD_NYUKN As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents BD_STNNM As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents BD_TEGDT As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents BD_TEGNO As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    '2019/05/21 CHG START
    'Public WithEvents FM_Panel3D1 As SSPanel5Array
    Public WithEvents FM_Panel3D1 As VB6.LabelArray
    '2019/05/21 CHG END
    Public WithEvents IM_DELETEDE As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    Public WithEvents IM_Denkyu As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    Public WithEvents IM_EndCm As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    Public WithEvents IM_Execute As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    Public WithEvents IM_Execute_1 As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    Public WithEvents IM_Hardcopy As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    Public WithEvents IM_INSERTDE As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    Public WithEvents IM_LCONFIG As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    Public WithEvents IM_NEXTCM As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    Public WithEvents IM_PREV As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    Public WithEvents IM_Slist As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    '2019/05/21 CHG START
    '   Public WithEvents MN_Execute As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_DeleteCM As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_HARDCOPY As System.Windows.Forms.ToolStripMenuItem
    '   Public WithEvents MN_LCONFIG As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MN_Execute As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_DeleteCM As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_HARDCOPY As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_LCONFIG As System.Windows.Forms.ContextMenuStrip
    '2019/05/21 CHG END
    Public WithEvents bar11 As System.Windows.Forms.ToolStripSeparator
    '2019/05/21 CHG START
    '   Public WithEvents MN_EndCm As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Ctrl As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_APPENDC As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_ClearItm As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_UnDoItem As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_ClearDE As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_DeleteDE As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_InsertDE As System.Windows.Forms.ToolStripMenuItem
    '   Public WithEvents MN_UnDoDe As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MN_EndCm As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Ctrl As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_APPENDC As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_ClearItm As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_UnDoItem As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_ClearDE As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_DeleteDE As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_InsertDE As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_UnDoDe As System.Windows.Forms.ContextMenuStrip
    '2019/05/21 CHG END
    Public WithEvents Bar21 As System.Windows.Forms.ToolStripSeparator
    '2019/05/21 CHG START
    '   Public WithEvents MN_Cut As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Copy As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Paste As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_EditMn As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Slist As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Oprt As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents SM_AllCopy As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents SM_FullPast As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents SM_Esc As System.Windows.Forms.ToolStripMenuItem
    '   Public WithEvents SM_ShortCut As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MN_Cut As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Copy As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Paste As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_EditMn As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Slist As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Oprt As System.Windows.Forms.ContextMenuStrip
    Public WithEvents SM_AllCopy As System.Windows.Forms.ContextMenuStrip
    Public WithEvents SM_FullPast As System.Windows.Forms.ContextMenuStrip
    Public WithEvents SM_Esc As System.Windows.Forms.ContextMenuStrip
    Public WithEvents SM_ShortCut As System.Windows.Forms.ContextMenuStrip
    '2019/05/21 CHG END
    Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更できます。
    'コード エディタを使用して、変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_SSSMAIN))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CS_DATNO = New System.Windows.Forms.Button()
        Me.VS_Scrl = New System.Windows.Forms.VScrollBar()
        Me._BD_JDNNO_0 = New System.Windows.Forms.TextBox()
        Me._BD_LINNO_0 = New System.Windows.Forms.TextBox()
        Me.TL_SBANYUKN = New System.Windows.Forms.TextBox()
        Me.HD_TOKCD = New System.Windows.Forms.TextBox()
        Me._BD_NYUKN_0 = New System.Windows.Forms.TextBox()
        Me._BD_LINCMA_0 = New System.Windows.Forms.TextBox()
        Me._BD_TEGNO_0 = New System.Windows.Forms.TextBox()
        Me._BD_TEGDT_0 = New System.Windows.Forms.TextBox()
        Me._BD_BNKNM_0 = New System.Windows.Forms.TextBox()
        Me._BD_BNKCD_0 = New System.Windows.Forms.TextBox()
        Me._BD_DKBID_0 = New System.Windows.Forms.TextBox()
        Me._BD_LINCMB_0 = New System.Windows.Forms.TextBox()
        Me.HD_NYUDT = New System.Windows.Forms.TextBox()
        Me.HD_TOKRN = New System.Windows.Forms.TextBox()
        Me._BD_DKBNM_0 = New System.Windows.Forms.TextBox()
        Me.HD_TUKKB = New System.Windows.Forms.TextBox()
        Me.HD_NYUKB = New System.Windows.Forms.TextBox()
        Me.HD_IN_TANCD = New System.Windows.Forms.TextBox()
        Me.HD_IN_TANNM = New System.Windows.Forms.TextBox()
        Me._BD_FNYUKN_0 = New System.Windows.Forms.TextBox()
        Me._BD_STNNM_0 = New System.Windows.Forms.TextBox()
        Me.TL_SBAFRNKN = New System.Windows.Forms.TextBox()
        Me.HD_KNJKOZ = New System.Windows.Forms.TextBox()
        Me._BD_KANKOZ_0 = New System.Windows.Forms.TextBox()
        Me._FM_Panel3D1_13 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_14 = New System.Windows.Forms.Label()
        Me.TX_Message = New System.Windows.Forms.TextBox()
        Me._IM_Denkyu_0 = New System.Windows.Forms.PictureBox()
        Me.TM_StartUp = New System.Windows.Forms.Timer(Me.components)
        Me.TX_CursorRest = New System.Windows.Forms.TextBox()
        Me._FM_Panel3D1_15 = New System.Windows.Forms.Label()
        Me.TX_Mode = New System.Windows.Forms.TextBox()
        Me._IM_Execute_0 = New System.Windows.Forms.PictureBox()
        Me._IM_LCONFIG_0 = New System.Windows.Forms.PictureBox()
        Me._IM_LCONFIG_1 = New System.Windows.Forms.PictureBox()
        Me._IM_Denkyu_2 = New System.Windows.Forms.PictureBox()
        Me._IM_Denkyu_1 = New System.Windows.Forms.PictureBox()
        Me._IM_DELETEDE_1 = New System.Windows.Forms.PictureBox()
        Me._IM_DELETEDE_0 = New System.Windows.Forms.PictureBox()
        Me._IM_INSERTDE_1 = New System.Windows.Forms.PictureBox()
        Me._IM_INSERTDE_0 = New System.Windows.Forms.PictureBox()
        Me._IM_NEXTCM_1 = New System.Windows.Forms.PictureBox()
        Me._IM_NEXTCM_0 = New System.Windows.Forms.PictureBox()
        Me._IM_PREV_0 = New System.Windows.Forms.PictureBox()
        Me._IM_PREV_1 = New System.Windows.Forms.PictureBox()
        Me._IM_Hardcopy_0 = New System.Windows.Forms.PictureBox()
        Me._IM_Slist_0 = New System.Windows.Forms.PictureBox()
        Me._IM_EndCm_1 = New System.Windows.Forms.PictureBox()
        Me._IM_EndCm_0 = New System.Windows.Forms.PictureBox()
        Me._IM_Slist_1 = New System.Windows.Forms.PictureBox()
        Me._IM_Hardcopy_1 = New System.Windows.Forms.PictureBox()
        Me._IM_Execute_1_0 = New System.Windows.Forms.PictureBox()
        Me._IM_Execute_1_1 = New System.Windows.Forms.PictureBox()
        Me._FM_Panel3D1_0 = New System.Windows.Forms.Label()
        Me.SYSDT = New System.Windows.Forms.Label()
        Me.CM_LCONFIG = New System.Windows.Forms.PictureBox()
        Me.CM_DELETEDE = New System.Windows.Forms.PictureBox()
        Me.CM_INSERTDE = New System.Windows.Forms.PictureBox()
        Me.CM_SLIST = New System.Windows.Forms.PictureBox()
        Me.Image1 = New System.Windows.Forms.PictureBox()
        Me._FM_Panel3D1_6 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_10 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_9 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_4 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_11 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_3 = New System.Windows.Forms.Label()
        Me.CS_NYUDT = New System.Windows.Forms.Button()
        Me.CS_DKBID = New System.Windows.Forms.Button()
        Me._FM_Panel3D1_2 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_5 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_8 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_7 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_12 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_1 = New System.Windows.Forms.Label()
        Me.CS_BNKCD = New System.Windows.Forms.Button()
        Me.CS_KNJKOZ = New System.Windows.Forms.Button()
        Me.CS_TEGDT = New System.Windows.Forms.Button()
        Me.CS_KANKOZ = New System.Windows.Forms.Button()
        Me.HD_DATNO = New System.Windows.Forms.TextBox()
        Me._FM_Panel3D1_16 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_17 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.BD_BNKCD = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_BNKNM = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_DKBID = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_DKBNM = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_FNYUKN = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_JDNNO = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_KANKOZ = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_LINCMA = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_LINCMB = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_LINNO = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_NYUKN = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_STNNM = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_TEGDT = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_TEGNO = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.FM_Panel3D1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.IM_DELETEDE = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_Denkyu = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_EndCm = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_Execute = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_Execute_1 = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_Hardcopy = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_INSERTDE = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_LCONFIG = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_NEXTCM = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_PREV = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.IM_Slist = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.MN_Ctrl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Execute = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_DeleteCM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_HARDCOPY = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_LCONFIG = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.bar11 = New System.Windows.Forms.ToolStripSeparator()
        Me.MN_EndCm = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_EditMn = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_APPENDC = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_ClearItm = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_UnDoItem = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_ClearDE = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_DeleteDE = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_InsertDE = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_UnDoDe = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Bar21 = New System.Windows.Forms.ToolStripSeparator()
        Me.MN_Cut = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Copy = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Paste = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Oprt = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Slist = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SM_ShortCut = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SM_AllCopy = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SM_FullPast = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SM_Esc = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dummyCtl = New System.Windows.Forms.Label()
        Me.btnF12 = New System.Windows.Forms.Button()
        Me.btnF11 = New System.Windows.Forms.Button()
        Me.btnF10 = New System.Windows.Forms.Button()
        Me.btnF9 = New System.Windows.Forms.Button()
        Me.btnF8 = New System.Windows.Forms.Button()
        Me.btnF7 = New System.Windows.Forms.Button()
        Me.btnF6 = New System.Windows.Forms.Button()
        Me.btnF5 = New System.Windows.Forms.Button()
        Me.btnF4 = New System.Windows.Forms.Button()
        Me.btnF3 = New System.Windows.Forms.Button()
        Me.btnF2 = New System.Windows.Forms.Button()
        Me.btnF1 = New System.Windows.Forms.Button()
        Me._FM_Panel3D1_13.SuspendLayout()
        CType(Me._IM_Denkyu_0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._FM_Panel3D1_15.SuspendLayout()
        CType(Me._IM_Execute_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_LCONFIG_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_LCONFIG_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Denkyu_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Denkyu_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_DELETEDE_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_DELETEDE_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_INSERTDE_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_INSERTDE_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_NEXTCM_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_NEXTCM_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_PREV_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_PREV_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Hardcopy_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Slist_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_EndCm_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_EndCm_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Slist_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Hardcopy_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Execute_1_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Execute_1_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._FM_Panel3D1_0.SuspendLayout()
        CType(Me.CM_LCONFIG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_DELETEDE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_INSERTDE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_SLIST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_BNKCD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_BNKNM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_DKBID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_DKBNM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_FNYUKN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_JDNNO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_KANKOZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_LINCMA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_LINCMB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_LINNO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_NYUKN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_STNNM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_TEGDT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_TEGNO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_DELETEDE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_Denkyu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_EndCm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_Execute, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_Execute_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_Hardcopy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_INSERTDE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_LCONFIG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_NEXTCM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_PREV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IM_Slist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CS_DATNO
        '
        Me.CS_DATNO.Location = New System.Drawing.Point(18, 49)
        Me.CS_DATNO.Name = "CS_DATNO"
        Me.CS_DATNO.Size = New System.Drawing.Size(119, 22)
        Me.CS_DATNO.TabIndex = 53
        Me.CS_DATNO.TabStop = False
        Me.CS_DATNO.Text = "*入金訂正対象"
        '
        'VS_Scrl
        '
        Me.VS_Scrl.Cursor = System.Windows.Forms.Cursors.Default
        Me.VS_Scrl.LargeChange = 1
        Me.VS_Scrl.Location = New System.Drawing.Point(947, 159)
        Me.VS_Scrl.Maximum = 32767
        Me.VS_Scrl.Name = "VS_Scrl"
        Me.VS_Scrl.Size = New System.Drawing.Size(17, 26)
        Me.VS_Scrl.TabIndex = 51
        Me.VS_Scrl.TabStop = True
        Me.VS_Scrl.Visible = False
        '
        '_BD_JDNNO_0
        '
        Me._BD_JDNNO_0.AcceptsReturn = True
        Me._BD_JDNNO_0.BackColor = System.Drawing.Color.White
        Me._BD_JDNNO_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_JDNNO_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_JDNNO_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._BD_JDNNO_0.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.BD_JDNNO.SetIndex(Me._BD_JDNNO_0, CType(0, Short))
        Me._BD_JDNNO_0.Location = New System.Drawing.Point(474, 222)
        Me._BD_JDNNO_0.MaxLength = 24
        Me._BD_JDNNO_0.Name = "_BD_JDNNO_0"
        Me._BD_JDNNO_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_JDNNO_0.Size = New System.Drawing.Size(148, 20)
        Me._BD_JDNNO_0.TabIndex = 48
        Me._BD_JDNNO_0.Text = "XXXXXXXX10"
        '
        '_BD_LINNO_0
        '
        Me._BD_LINNO_0.AcceptsReturn = True
        Me._BD_LINNO_0.BackColor = System.Drawing.SystemColors.Window
        Me._BD_LINNO_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_LINNO_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_LINNO_0.ForeColor = System.Drawing.Color.Black
        Me._BD_LINNO_0.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.BD_LINNO.SetIndex(Me._BD_LINNO_0, CType(0, Short))
        Me._BD_LINNO_0.Location = New System.Drawing.Point(28, 222)
        Me._BD_LINNO_0.MaxLength = 7
        Me._BD_LINNO_0.Multiline = True
        Me._BD_LINNO_0.Name = "_BD_LINNO_0"
        Me._BD_LINNO_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_LINNO_0.Size = New System.Drawing.Size(37, 41)
        Me._BD_LINNO_0.TabIndex = 36
        Me._BD_LINNO_0.Text = "999"
        Me._BD_LINNO_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TL_SBANYUKN
        '
        Me.TL_SBANYUKN.AcceptsReturn = True
        Me.TL_SBANYUKN.BackColor = System.Drawing.Color.White
        Me.TL_SBANYUKN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TL_SBANYUKN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TL_SBANYUKN.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TL_SBANYUKN.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TL_SBANYUKN.Location = New System.Drawing.Point(121, 492)
        Me.TL_SBANYUKN.MaxLength = 18
        Me.TL_SBANYUKN.Name = "TL_SBANYUKN"
        Me.TL_SBANYUKN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TL_SBANYUKN.Size = New System.Drawing.Size(132, 20)
        Me.TL_SBANYUKN.TabIndex = 34
        Me.TL_SBANYUKN.Text = "-99,999,999,999"
        Me.TL_SBANYUKN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'HD_TOKCD
        '
        Me.HD_TOKCD.AcceptsReturn = True
        Me.HD_TOKCD.BackColor = System.Drawing.Color.White
        Me.HD_TOKCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TOKCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TOKCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TOKCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_TOKCD.Location = New System.Drawing.Point(105, 120)
        Me.HD_TOKCD.MaxLength = 9
        Me.HD_TOKCD.Name = "HD_TOKCD"
        Me.HD_TOKCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TOKCD.Size = New System.Drawing.Size(49, 20)
        Me.HD_TOKCD.TabIndex = 33
        Me.HD_TOKCD.TabStop = False
        Me.HD_TOKCD.Text = "XXXX5"
        '
        '_BD_NYUKN_0
        '
        Me._BD_NYUKN_0.AcceptsReturn = True
        Me._BD_NYUKN_0.BackColor = System.Drawing.Color.White
        Me._BD_NYUKN_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_NYUKN_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_NYUKN_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._BD_NYUKN_0.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.BD_NYUKN.SetIndex(Me._BD_NYUKN_0, CType(0, Short))
        Me._BD_NYUKN_0.Location = New System.Drawing.Point(209, 222)
        Me._BD_NYUKN_0.MaxLength = 18
        Me._BD_NYUKN_0.Name = "_BD_NYUKN_0"
        Me._BD_NYUKN_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_NYUKN_0.Size = New System.Drawing.Size(119, 20)
        Me._BD_NYUKN_0.TabIndex = 32
        Me._BD_NYUKN_0.Text = "-9,999,999,999"
        Me._BD_NYUKN_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_BD_LINCMA_0
        '
        Me._BD_LINCMA_0.AcceptsReturn = True
        Me._BD_LINCMA_0.BackColor = System.Drawing.Color.White
        Me._BD_LINCMA_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_LINCMA_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_LINCMA_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._BD_LINCMA_0.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.BD_LINCMA.SetIndex(Me._BD_LINCMA_0, CType(0, Short))
        Me._BD_LINCMA_0.Location = New System.Drawing.Point(793, 222)
        Me._BD_LINCMA_0.MaxLength = 24
        Me._BD_LINCMA_0.Name = "_BD_LINCMA_0"
        Me._BD_LINCMA_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_LINCMA_0.Size = New System.Drawing.Size(151, 20)
        Me._BD_LINCMA_0.TabIndex = 31
        Me._BD_LINCMA_0.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        '_BD_TEGNO_0
        '
        Me._BD_TEGNO_0.AcceptsReturn = True
        Me._BD_TEGNO_0.BackColor = System.Drawing.Color.White
        Me._BD_TEGNO_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_TEGNO_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_TEGNO_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._BD_TEGNO_0.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.BD_TEGNO.SetIndex(Me._BD_TEGNO_0, CType(0, Short))
        Me._BD_TEGNO_0.Location = New System.Drawing.Point(702, 222)
        Me._BD_TEGNO_0.MaxLength = 14
        Me._BD_TEGNO_0.Multiline = True
        Me._BD_TEGNO_0.Name = "_BD_TEGNO_0"
        Me._BD_TEGNO_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_TEGNO_0.Size = New System.Drawing.Size(92, 41)
        Me._BD_TEGNO_0.TabIndex = 30
        Me._BD_TEGNO_0.Text = "XXXXXXXXX1"
        '
        '_BD_TEGDT_0
        '
        Me._BD_TEGDT_0.AcceptsReturn = True
        Me._BD_TEGDT_0.BackColor = System.Drawing.Color.White
        Me._BD_TEGDT_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_TEGDT_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_TEGDT_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._BD_TEGDT_0.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.BD_TEGDT.SetIndex(Me._BD_TEGDT_0, CType(0, Short))
        Me._BD_TEGDT_0.Location = New System.Drawing.Point(621, 222)
        Me._BD_TEGDT_0.MaxLength = 14
        Me._BD_TEGDT_0.Multiline = True
        Me._BD_TEGDT_0.Name = "_BD_TEGDT_0"
        Me._BD_TEGDT_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_TEGDT_0.Size = New System.Drawing.Size(82, 41)
        Me._BD_TEGDT_0.TabIndex = 29
        Me._BD_TEGDT_0.Text = "9999/99/99"
        '
        '_BD_BNKNM_0
        '
        Me._BD_BNKNM_0.AcceptsReturn = True
        Me._BD_BNKNM_0.BackColor = System.Drawing.Color.White
        Me._BD_BNKNM_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_BNKNM_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_BNKNM_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._BD_BNKNM_0.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.BD_BNKNM.SetIndex(Me._BD_BNKNM_0, CType(0, Short))
        Me._BD_BNKNM_0.Location = New System.Drawing.Point(327, 243)
        Me._BD_BNKNM_0.MaxLength = 24
        Me._BD_BNKNM_0.Name = "_BD_BNKNM_0"
        Me._BD_BNKNM_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_BNKNM_0.Size = New System.Drawing.Size(148, 20)
        Me._BD_BNKNM_0.TabIndex = 28
        Me._BD_BNKNM_0.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        '_BD_BNKCD_0
        '
        Me._BD_BNKCD_0.AcceptsReturn = True
        Me._BD_BNKCD_0.BackColor = System.Drawing.Color.White
        Me._BD_BNKCD_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_BNKCD_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_BNKCD_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._BD_BNKCD_0.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.BD_BNKCD.SetIndex(Me._BD_BNKCD_0, CType(0, Short))
        Me._BD_BNKCD_0.Location = New System.Drawing.Point(327, 222)
        Me._BD_BNKCD_0.MaxLength = 11
        Me._BD_BNKCD_0.Name = "_BD_BNKCD_0"
        Me._BD_BNKCD_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_BNKCD_0.Size = New System.Drawing.Size(148, 20)
        Me._BD_BNKCD_0.TabIndex = 27
        Me._BD_BNKCD_0.Text = "XXXXXX7"
        '
        '_BD_DKBID_0
        '
        Me._BD_DKBID_0.AcceptsReturn = True
        Me._BD_DKBID_0.BackColor = System.Drawing.Color.White
        Me._BD_DKBID_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_DKBID_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_DKBID_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._BD_DKBID_0.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.BD_DKBID.SetIndex(Me._BD_DKBID_0, CType(0, Short))
        Me._BD_DKBID_0.Location = New System.Drawing.Point(64, 222)
        Me._BD_DKBID_0.MaxLength = 6
        Me._BD_DKBID_0.Name = "_BD_DKBID_0"
        Me._BD_DKBID_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_DKBID_0.Size = New System.Drawing.Size(71, 20)
        Me._BD_DKBID_0.TabIndex = 26
        Me._BD_DKBID_0.Text = "12"
        '
        '_BD_LINCMB_0
        '
        Me._BD_LINCMB_0.AcceptsReturn = True
        Me._BD_LINCMB_0.BackColor = System.Drawing.Color.White
        Me._BD_LINCMB_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_LINCMB_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_LINCMB_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._BD_LINCMB_0.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.BD_LINCMB.SetIndex(Me._BD_LINCMB_0, CType(0, Short))
        Me._BD_LINCMB_0.Location = New System.Drawing.Point(793, 243)
        Me._BD_LINCMB_0.MaxLength = 24
        Me._BD_LINCMB_0.Name = "_BD_LINCMB_0"
        Me._BD_LINCMB_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_LINCMB_0.Size = New System.Drawing.Size(151, 20)
        Me._BD_LINCMB_0.TabIndex = 25
        Me._BD_LINCMB_0.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'HD_NYUDT
        '
        Me.HD_NYUDT.AcceptsReturn = True
        Me.HD_NYUDT.BackColor = System.Drawing.Color.White
        Me.HD_NYUDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_NYUDT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_NYUDT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_NYUDT.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_NYUDT.Location = New System.Drawing.Point(105, 99)
        Me.HD_NYUDT.MaxLength = 14
        Me.HD_NYUDT.Name = "HD_NYUDT"
        Me.HD_NYUDT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_NYUDT.Size = New System.Drawing.Size(79, 20)
        Me.HD_NYUDT.TabIndex = 23
        Me.HD_NYUDT.Text = "9999/99/99"
        '
        'HD_TOKRN
        '
        Me.HD_TOKRN.AcceptsReturn = True
        Me.HD_TOKRN.BackColor = System.Drawing.SystemColors.Window
        Me.HD_TOKRN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TOKRN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TOKRN.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TOKRN.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_TOKRN.Location = New System.Drawing.Point(154, 120)
        Me.HD_TOKRN.MaxLength = 44
        Me.HD_TOKRN.Name = "HD_TOKRN"
        Me.HD_TOKRN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TOKRN.Size = New System.Drawing.Size(285, 20)
        Me.HD_TOKRN.TabIndex = 22
        Me.HD_TOKRN.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
        '
        '_BD_DKBNM_0
        '
        Me._BD_DKBNM_0.AcceptsReturn = True
        Me._BD_DKBNM_0.BackColor = System.Drawing.Color.White
        Me._BD_DKBNM_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_DKBNM_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_DKBNM_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._BD_DKBNM_0.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.BD_DKBNM.SetIndex(Me._BD_DKBNM_0, CType(0, Short))
        Me._BD_DKBNM_0.Location = New System.Drawing.Point(64, 243)
        Me._BD_DKBNM_0.MaxLength = 10
        Me._BD_DKBNM_0.Name = "_BD_DKBNM_0"
        Me._BD_DKBNM_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_DKBNM_0.Size = New System.Drawing.Size(71, 20)
        Me._BD_DKBNM_0.TabIndex = 21
        Me._BD_DKBNM_0.Text = "MMMMM6"
        '
        'HD_TUKKB
        '
        Me.HD_TUKKB.AcceptsReturn = True
        Me.HD_TUKKB.BackColor = System.Drawing.Color.White
        Me.HD_TUKKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TUKKB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TUKKB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TUKKB.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_TUKKB.Location = New System.Drawing.Point(481, 120)
        Me.HD_TUKKB.MaxLength = 7
        Me.HD_TUKKB.Name = "HD_TUKKB"
        Me.HD_TUKKB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TUKKB.Size = New System.Drawing.Size(29, 20)
        Me.HD_TUKKB.TabIndex = 16
        Me.HD_TUKKB.Text = "XX3"
        '
        'HD_NYUKB
        '
        Me.HD_NYUKB.AcceptsReturn = True
        Me.HD_NYUKB.BackColor = System.Drawing.Color.White
        Me.HD_NYUKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_NYUKB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_NYUKB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_NYUKB.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_NYUKB.Location = New System.Drawing.Point(104, 78)
        Me.HD_NYUKB.MaxLength = 5
        Me.HD_NYUKB.Name = "HD_NYUKB"
        Me.HD_NYUKB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_NYUKB.Size = New System.Drawing.Size(19, 20)
        Me.HD_NYUKB.TabIndex = 15
        Me.HD_NYUKB.Text = "X"
        '
        'HD_IN_TANCD
        '
        Me.HD_IN_TANCD.AcceptsReturn = True
        Me.HD_IN_TANCD.BackColor = System.Drawing.Color.White
        Me.HD_IN_TANCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_IN_TANCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_IN_TANCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_IN_TANCD.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_IN_TANCD.Location = New System.Drawing.Point(709, 48)
        Me.HD_IN_TANCD.MaxLength = 10
        Me.HD_IN_TANCD.Name = "HD_IN_TANCD"
        Me.HD_IN_TANCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_IN_TANCD.Size = New System.Drawing.Size(51, 20)
        Me.HD_IN_TANCD.TabIndex = 14
        Me.HD_IN_TANCD.Text = "XXXXX6"
        '
        'HD_IN_TANNM
        '
        Me.HD_IN_TANNM.AcceptsReturn = True
        Me.HD_IN_TANNM.BackColor = System.Drawing.Color.White
        Me.HD_IN_TANNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_IN_TANNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_IN_TANNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_IN_TANNM.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_IN_TANNM.Location = New System.Drawing.Point(759, 48)
        Me.HD_IN_TANNM.MaxLength = 24
        Me.HD_IN_TANNM.Name = "HD_IN_TANNM"
        Me.HD_IN_TANNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_IN_TANNM.Size = New System.Drawing.Size(152, 20)
        Me.HD_IN_TANNM.TabIndex = 13
        Me.HD_IN_TANNM.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        '_BD_FNYUKN_0
        '
        Me._BD_FNYUKN_0.AcceptsReturn = True
        Me._BD_FNYUKN_0.BackColor = System.Drawing.Color.White
        Me._BD_FNYUKN_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_FNYUKN_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_FNYUKN_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._BD_FNYUKN_0.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.BD_FNYUKN.SetIndex(Me._BD_FNYUKN_0, CType(0, Short))
        Me._BD_FNYUKN_0.Location = New System.Drawing.Point(209, 243)
        Me._BD_FNYUKN_0.MaxLength = 20
        Me._BD_FNYUKN_0.Name = "_BD_FNYUKN_0"
        Me._BD_FNYUKN_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_FNYUKN_0.Size = New System.Drawing.Size(119, 20)
        Me._BD_FNYUKN_0.TabIndex = 12
        Me._BD_FNYUKN_0.Text = "-99,999,999.9999"
        Me._BD_FNYUKN_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_BD_STNNM_0
        '
        Me._BD_STNNM_0.AcceptsReturn = True
        Me._BD_STNNM_0.BackColor = System.Drawing.Color.White
        Me._BD_STNNM_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_STNNM_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_STNNM_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._BD_STNNM_0.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.BD_STNNM.SetIndex(Me._BD_STNNM_0, CType(0, Short))
        Me._BD_STNNM_0.Location = New System.Drawing.Point(474, 243)
        Me._BD_STNNM_0.MaxLength = 24
        Me._BD_STNNM_0.Name = "_BD_STNNM_0"
        Me._BD_STNNM_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_STNNM_0.Size = New System.Drawing.Size(148, 20)
        Me._BD_STNNM_0.TabIndex = 11
        Me._BD_STNNM_0.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'TL_SBAFRNKN
        '
        Me.TL_SBAFRNKN.AcceptsReturn = True
        Me.TL_SBAFRNKN.BackColor = System.Drawing.Color.White
        Me.TL_SBAFRNKN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TL_SBAFRNKN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TL_SBAFRNKN.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TL_SBAFRNKN.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TL_SBAFRNKN.Location = New System.Drawing.Point(121, 518)
        Me.TL_SBAFRNKN.MaxLength = 20
        Me.TL_SBAFRNKN.Name = "TL_SBAFRNKN"
        Me.TL_SBAFRNKN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TL_SBAFRNKN.Size = New System.Drawing.Size(132, 20)
        Me.TL_SBAFRNKN.TabIndex = 10
        Me.TL_SBAFRNKN.Text = "-999,999,999.9999"
        Me.TL_SBAFRNKN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'HD_KNJKOZ
        '
        Me.HD_KNJKOZ.AcceptsReturn = True
        Me.HD_KNJKOZ.BackColor = System.Drawing.Color.White
        Me.HD_KNJKOZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_KNJKOZ.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_KNJKOZ.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_KNJKOZ.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_KNJKOZ.Location = New System.Drawing.Point(105, 142)
        Me.HD_KNJKOZ.MaxLength = 14
        Me.HD_KNJKOZ.Name = "HD_KNJKOZ"
        Me.HD_KNJKOZ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_KNJKOZ.Size = New System.Drawing.Size(79, 20)
        Me.HD_KNJKOZ.TabIndex = 9
        Me.HD_KNJKOZ.TabStop = False
        Me.HD_KNJKOZ.Text = "X123123123"
        '
        '_BD_KANKOZ_0
        '
        Me._BD_KANKOZ_0.AcceptsReturn = True
        Me._BD_KANKOZ_0.BackColor = System.Drawing.Color.White
        Me._BD_KANKOZ_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_KANKOZ_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_KANKOZ_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._BD_KANKOZ_0.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.BD_KANKOZ.SetIndex(Me._BD_KANKOZ_0, CType(0, Short))
        Me._BD_KANKOZ_0.Location = New System.Drawing.Point(134, 222)
        Me._BD_KANKOZ_0.MaxLength = 14
        Me._BD_KANKOZ_0.Multiline = True
        Me._BD_KANKOZ_0.Name = "_BD_KANKOZ_0"
        Me._BD_KANKOZ_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_KANKOZ_0.Size = New System.Drawing.Size(76, 41)
        Me._BD_KANKOZ_0.TabIndex = 8
        Me._BD_KANKOZ_0.Text = "X123123123"
        '
        '_FM_Panel3D1_13
        '
        Me._FM_Panel3D1_13.Controls.Add(Me._FM_Panel3D1_14)
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_13, CType(13, Short))
        Me._FM_Panel3D1_13.Location = New System.Drawing.Point(0, 551)
        Me._FM_Panel3D1_13.Name = "_FM_Panel3D1_13"
        Me._FM_Panel3D1_13.Size = New System.Drawing.Size(928, 49)
        Me._FM_Panel3D1_13.TabIndex = 1
        '
        '_FM_Panel3D1_14
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_14, CType(14, Short))
        Me._FM_Panel3D1_14.Location = New System.Drawing.Point(45, 9)
        Me._FM_Panel3D1_14.Name = "_FM_Panel3D1_14"
        Me._FM_Panel3D1_14.Size = New System.Drawing.Size(865, 31)
        Me._FM_Panel3D1_14.TabIndex = 2
        '
        'TX_Message
        '
        Me.TX_Message.AcceptsReturn = True
        Me.TX_Message.BackColor = System.Drawing.SystemColors.Control
        Me.TX_Message.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TX_Message.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TX_Message.ForeColor = System.Drawing.Color.Black
        Me.TX_Message.Location = New System.Drawing.Point(61, 581)
        Me.TX_Message.MaxLength = 0
        Me.TX_Message.Multiline = True
        Me.TX_Message.Name = "TX_Message"
        Me.TX_Message.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_Message.Size = New System.Drawing.Size(667, 16)
        Me.TX_Message.TabIndex = 3
        Me.TX_Message.Text = "エラーやプロンプトのメッセージが出力されるところです。"
        Me.TX_Message.Visible = False
        '
        '_IM_Denkyu_0
        '
        Me._IM_Denkyu_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_0.Image = CType(resources.GetObject("_IM_Denkyu_0.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_0, CType(0, Short))
        Me._IM_Denkyu_0.Location = New System.Drawing.Point(35, 575)
        Me._IM_Denkyu_0.Name = "_IM_Denkyu_0"
        Me._IM_Denkyu_0.Size = New System.Drawing.Size(20, 22)
        Me._IM_Denkyu_0.TabIndex = 3
        Me._IM_Denkyu_0.TabStop = False
        Me._IM_Denkyu_0.Visible = False
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
        Me.TX_CursorRest.Location = New System.Drawing.Point(2892, 2892)
        Me.TX_CursorRest.MaxLength = 0
        Me.TX_CursorRest.Name = "TX_CursorRest"
        Me.TX_CursorRest.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_CursorRest.Size = New System.Drawing.Size(22, 13)
        Me.TX_CursorRest.TabIndex = 0
        '
        '_FM_Panel3D1_15
        '
        Me._FM_Panel3D1_15.Controls.Add(Me.TX_Mode)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_Execute_0)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_LCONFIG_0)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_LCONFIG_1)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_Denkyu_2)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_Denkyu_1)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_DELETEDE_1)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_DELETEDE_0)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_INSERTDE_1)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_INSERTDE_0)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_NEXTCM_1)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_NEXTCM_0)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_PREV_0)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_PREV_1)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_Hardcopy_0)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_Slist_0)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_EndCm_1)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_EndCm_0)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_Slist_1)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_Hardcopy_1)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_Execute_1_0)
        Me._FM_Panel3D1_15.Controls.Add(Me._IM_Execute_1_1)
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_15, CType(15, Short))
        Me._FM_Panel3D1_15.Location = New System.Drawing.Point(0, 705)
        Me._FM_Panel3D1_15.Name = "_FM_Panel3D1_15"
        Me._FM_Panel3D1_15.Size = New System.Drawing.Size(907, 58)
        Me._FM_Panel3D1_15.TabIndex = 6
        '
        'TX_Mode
        '
        Me.TX_Mode.AcceptsReturn = True
        Me.TX_Mode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TX_Mode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TX_Mode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TX_Mode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TX_Mode.Location = New System.Drawing.Point(813, 3)
        Me.TX_Mode.MaxLength = 0
        Me.TX_Mode.Name = "TX_Mode"
        Me.TX_Mode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_Mode.Size = New System.Drawing.Size(58, 20)
        Me.TX_Mode.TabIndex = 7
        Me.TX_Mode.Text = "ﾓｰﾄﾞ"
        '
        '_IM_Execute_0
        '
        Me._IM_Execute_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Execute_0.Image = CType(resources.GetObject("_IM_Execute_0.Image"), System.Drawing.Image)
        Me.IM_Execute.SetIndex(Me._IM_Execute_0, CType(0, Short))
        Me._IM_Execute_0.Location = New System.Drawing.Point(528, 4)
        Me._IM_Execute_0.Name = "_IM_Execute_0"
        Me._IM_Execute_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_Execute_0.TabIndex = 8
        Me._IM_Execute_0.TabStop = False
        Me._IM_Execute_0.Visible = False
        '
        '_IM_LCONFIG_0
        '
        Me._IM_LCONFIG_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_LCONFIG_0.Image = CType(resources.GetObject("_IM_LCONFIG_0.Image"), System.Drawing.Image)
        Me.IM_LCONFIG.SetIndex(Me._IM_LCONFIG_0, CType(0, Short))
        Me._IM_LCONFIG_0.Location = New System.Drawing.Point(423, 3)
        Me._IM_LCONFIG_0.Name = "_IM_LCONFIG_0"
        Me._IM_LCONFIG_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_LCONFIG_0.TabIndex = 9
        Me._IM_LCONFIG_0.TabStop = False
        '
        '_IM_LCONFIG_1
        '
        Me._IM_LCONFIG_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_LCONFIG_1.Image = CType(resources.GetObject("_IM_LCONFIG_1.Image"), System.Drawing.Image)
        Me.IM_LCONFIG.SetIndex(Me._IM_LCONFIG_1, CType(1, Short))
        Me._IM_LCONFIG_1.Location = New System.Drawing.Point(447, 3)
        Me._IM_LCONFIG_1.Name = "_IM_LCONFIG_1"
        Me._IM_LCONFIG_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_LCONFIG_1.TabIndex = 10
        Me._IM_LCONFIG_1.TabStop = False
        '
        '_IM_Denkyu_2
        '
        Me._IM_Denkyu_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_2.Image = CType(resources.GetObject("_IM_Denkyu_2.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_2, CType(2, Short))
        Me._IM_Denkyu_2.Location = New System.Drawing.Point(506, 3)
        Me._IM_Denkyu_2.Name = "_IM_Denkyu_2"
        Me._IM_Denkyu_2.Size = New System.Drawing.Size(20, 22)
        Me._IM_Denkyu_2.TabIndex = 11
        Me._IM_Denkyu_2.TabStop = False
        '
        '_IM_Denkyu_1
        '
        Me._IM_Denkyu_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_1.Image = CType(resources.GetObject("_IM_Denkyu_1.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_1, CType(1, Short))
        Me._IM_Denkyu_1.Location = New System.Drawing.Point(484, 4)
        Me._IM_Denkyu_1.Name = "_IM_Denkyu_1"
        Me._IM_Denkyu_1.Size = New System.Drawing.Size(20, 22)
        Me._IM_Denkyu_1.TabIndex = 12
        Me._IM_Denkyu_1.TabStop = False
        '
        '_IM_DELETEDE_1
        '
        Me._IM_DELETEDE_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_DELETEDE_1.Image = CType(resources.GetObject("_IM_DELETEDE_1.Image"), System.Drawing.Image)
        Me.IM_DELETEDE.SetIndex(Me._IM_DELETEDE_1, CType(1, Short))
        Me._IM_DELETEDE_1.Location = New System.Drawing.Point(231, 3)
        Me._IM_DELETEDE_1.Name = "_IM_DELETEDE_1"
        Me._IM_DELETEDE_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_DELETEDE_1.TabIndex = 13
        Me._IM_DELETEDE_1.TabStop = False
        '
        '_IM_DELETEDE_0
        '
        Me._IM_DELETEDE_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_DELETEDE_0.Image = CType(resources.GetObject("_IM_DELETEDE_0.Image"), System.Drawing.Image)
        Me.IM_DELETEDE.SetIndex(Me._IM_DELETEDE_0, CType(0, Short))
        Me._IM_DELETEDE_0.Location = New System.Drawing.Point(207, 3)
        Me._IM_DELETEDE_0.Name = "_IM_DELETEDE_0"
        Me._IM_DELETEDE_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_DELETEDE_0.TabIndex = 14
        Me._IM_DELETEDE_0.TabStop = False
        '
        '_IM_INSERTDE_1
        '
        Me._IM_INSERTDE_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_INSERTDE_1.Image = CType(resources.GetObject("_IM_INSERTDE_1.Image"), System.Drawing.Image)
        Me.IM_INSERTDE.SetIndex(Me._IM_INSERTDE_1, CType(1, Short))
        Me._IM_INSERTDE_1.Location = New System.Drawing.Point(183, 3)
        Me._IM_INSERTDE_1.Name = "_IM_INSERTDE_1"
        Me._IM_INSERTDE_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_INSERTDE_1.TabIndex = 15
        Me._IM_INSERTDE_1.TabStop = False
        '
        '_IM_INSERTDE_0
        '
        Me._IM_INSERTDE_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_INSERTDE_0.Image = CType(resources.GetObject("_IM_INSERTDE_0.Image"), System.Drawing.Image)
        Me.IM_INSERTDE.SetIndex(Me._IM_INSERTDE_0, CType(0, Short))
        Me._IM_INSERTDE_0.Location = New System.Drawing.Point(159, 3)
        Me._IM_INSERTDE_0.Name = "_IM_INSERTDE_0"
        Me._IM_INSERTDE_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_INSERTDE_0.TabIndex = 16
        Me._IM_INSERTDE_0.TabStop = False
        '
        '_IM_NEXTCM_1
        '
        Me._IM_NEXTCM_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_NEXTCM_1.Image = CType(resources.GetObject("_IM_NEXTCM_1.Image"), System.Drawing.Image)
        Me.IM_NEXTCM.SetIndex(Me._IM_NEXTCM_1, CType(1, Short))
        Me._IM_NEXTCM_1.Location = New System.Drawing.Point(390, 3)
        Me._IM_NEXTCM_1.Name = "_IM_NEXTCM_1"
        Me._IM_NEXTCM_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_NEXTCM_1.TabIndex = 17
        Me._IM_NEXTCM_1.TabStop = False
        Me._IM_NEXTCM_1.Visible = False
        '
        '_IM_NEXTCM_0
        '
        Me._IM_NEXTCM_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_NEXTCM_0.Image = CType(resources.GetObject("_IM_NEXTCM_0.Image"), System.Drawing.Image)
        Me.IM_NEXTCM.SetIndex(Me._IM_NEXTCM_0, CType(0, Short))
        Me._IM_NEXTCM_0.Location = New System.Drawing.Point(366, 3)
        Me._IM_NEXTCM_0.Name = "_IM_NEXTCM_0"
        Me._IM_NEXTCM_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_NEXTCM_0.TabIndex = 18
        Me._IM_NEXTCM_0.TabStop = False
        Me._IM_NEXTCM_0.Visible = False
        '
        '_IM_PREV_0
        '
        Me._IM_PREV_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_PREV_0.Image = CType(resources.GetObject("_IM_PREV_0.Image"), System.Drawing.Image)
        Me.IM_PREV.SetIndex(Me._IM_PREV_0, CType(0, Short))
        Me._IM_PREV_0.Location = New System.Drawing.Point(318, 2)
        Me._IM_PREV_0.Name = "_IM_PREV_0"
        Me._IM_PREV_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_PREV_0.TabIndex = 19
        Me._IM_PREV_0.TabStop = False
        Me._IM_PREV_0.Visible = False
        '
        '_IM_PREV_1
        '
        Me._IM_PREV_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_PREV_1.Image = CType(resources.GetObject("_IM_PREV_1.Image"), System.Drawing.Image)
        Me.IM_PREV.SetIndex(Me._IM_PREV_1, CType(1, Short))
        Me._IM_PREV_1.Location = New System.Drawing.Point(342, 3)
        Me._IM_PREV_1.Name = "_IM_PREV_1"
        Me._IM_PREV_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_PREV_1.TabIndex = 20
        Me._IM_PREV_1.TabStop = False
        Me._IM_PREV_1.Visible = False
        '
        '_IM_Hardcopy_0
        '
        Me._IM_Hardcopy_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Hardcopy_0.Image = CType(resources.GetObject("_IM_Hardcopy_0.Image"), System.Drawing.Image)
        Me.IM_Hardcopy.SetIndex(Me._IM_Hardcopy_0, CType(0, Short))
        Me._IM_Hardcopy_0.Location = New System.Drawing.Point(102, 3)
        Me._IM_Hardcopy_0.Name = "_IM_Hardcopy_0"
        Me._IM_Hardcopy_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_Hardcopy_0.TabIndex = 21
        Me._IM_Hardcopy_0.TabStop = False
        Me._IM_Hardcopy_0.Visible = False
        '
        '_IM_Slist_0
        '
        Me._IM_Slist_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Slist_0.Image = CType(resources.GetObject("_IM_Slist_0.Image"), System.Drawing.Image)
        Me.IM_Slist.SetIndex(Me._IM_Slist_0, CType(0, Short))
        Me._IM_Slist_0.Location = New System.Drawing.Point(261, 2)
        Me._IM_Slist_0.Name = "_IM_Slist_0"
        Me._IM_Slist_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_Slist_0.TabIndex = 22
        Me._IM_Slist_0.TabStop = False
        Me._IM_Slist_0.Visible = False
        '
        '_IM_EndCm_1
        '
        Me._IM_EndCm_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_EndCm_1.Image = CType(resources.GetObject("_IM_EndCm_1.Image"), System.Drawing.Image)
        Me.IM_EndCm.SetIndex(Me._IM_EndCm_1, CType(1, Short))
        Me._IM_EndCm_1.Location = New System.Drawing.Point(33, 3)
        Me._IM_EndCm_1.Name = "_IM_EndCm_1"
        Me._IM_EndCm_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_EndCm_1.TabIndex = 23
        Me._IM_EndCm_1.TabStop = False
        Me._IM_EndCm_1.Visible = False
        '
        '_IM_EndCm_0
        '
        Me._IM_EndCm_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_EndCm_0.Image = CType(resources.GetObject("_IM_EndCm_0.Image"), System.Drawing.Image)
        Me.IM_EndCm.SetIndex(Me._IM_EndCm_0, CType(0, Short))
        Me._IM_EndCm_0.Location = New System.Drawing.Point(9, 3)
        Me._IM_EndCm_0.Name = "_IM_EndCm_0"
        Me._IM_EndCm_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_EndCm_0.TabIndex = 24
        Me._IM_EndCm_0.TabStop = False
        Me._IM_EndCm_0.Visible = False
        '
        '_IM_Slist_1
        '
        Me._IM_Slist_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Slist_1.Image = CType(resources.GetObject("_IM_Slist_1.Image"), System.Drawing.Image)
        Me.IM_Slist.SetIndex(Me._IM_Slist_1, CType(1, Short))
        Me._IM_Slist_1.Location = New System.Drawing.Point(285, 3)
        Me._IM_Slist_1.Name = "_IM_Slist_1"
        Me._IM_Slist_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_Slist_1.TabIndex = 25
        Me._IM_Slist_1.TabStop = False
        Me._IM_Slist_1.Visible = False
        '
        '_IM_Hardcopy_1
        '
        Me._IM_Hardcopy_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Hardcopy_1.Image = CType(resources.GetObject("_IM_Hardcopy_1.Image"), System.Drawing.Image)
        Me.IM_Hardcopy.SetIndex(Me._IM_Hardcopy_1, CType(1, Short))
        Me._IM_Hardcopy_1.Location = New System.Drawing.Point(126, 3)
        Me._IM_Hardcopy_1.Name = "_IM_Hardcopy_1"
        Me._IM_Hardcopy_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_Hardcopy_1.TabIndex = 26
        Me._IM_Hardcopy_1.TabStop = False
        Me._IM_Hardcopy_1.Visible = False
        '
        '_IM_Execute_1_0
        '
        Me._IM_Execute_1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Execute_1_0.Image = CType(resources.GetObject("_IM_Execute_1_0.Image"), System.Drawing.Image)
        Me.IM_Execute_1.SetIndex(Me._IM_Execute_1_0, CType(0, Short))
        Me._IM_Execute_1_0.Location = New System.Drawing.Point(57, 3)
        Me._IM_Execute_1_0.Name = "_IM_Execute_1_0"
        Me._IM_Execute_1_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_Execute_1_0.TabIndex = 27
        Me._IM_Execute_1_0.TabStop = False
        Me._IM_Execute_1_0.Visible = False
        '
        '_IM_Execute_1_1
        '
        Me._IM_Execute_1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Execute_1_1.Image = CType(resources.GetObject("_IM_Execute_1_1.Image"), System.Drawing.Image)
        Me.IM_Execute_1.SetIndex(Me._IM_Execute_1_1, CType(1, Short))
        Me._IM_Execute_1_1.Location = New System.Drawing.Point(81, 3)
        Me._IM_Execute_1_1.Name = "_IM_Execute_1_1"
        Me._IM_Execute_1_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_Execute_1_1.TabIndex = 28
        Me._IM_Execute_1_1.TabStop = False
        Me._IM_Execute_1_1.Visible = False
        '
        '_FM_Panel3D1_0
        '
        Me._FM_Panel3D1_0.Controls.Add(Me.SYSDT)
        Me._FM_Panel3D1_0.Controls.Add(Me.CM_LCONFIG)
        Me._FM_Panel3D1_0.Controls.Add(Me.CM_DELETEDE)
        Me._FM_Panel3D1_0.Controls.Add(Me.CM_INSERTDE)
        Me._FM_Panel3D1_0.Controls.Add(Me.CM_SLIST)
        Me._FM_Panel3D1_0.Controls.Add(Me.Image1)
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_0, CType(0, Short))
        Me._FM_Panel3D1_0.Location = New System.Drawing.Point(-3, 0)
        Me._FM_Panel3D1_0.Name = "_FM_Panel3D1_0"
        Me._FM_Panel3D1_0.Size = New System.Drawing.Size(928, 37)
        Me._FM_Panel3D1_0.TabIndex = 4
        '
        'SYSDT
        '
        Me.SYSDT.Location = New System.Drawing.Point(800, 9)
        Me.SYSDT.Name = "SYSDT"
        Me.SYSDT.Size = New System.Drawing.Size(112, 22)
        Me.SYSDT.TabIndex = 5
        Me.SYSDT.Text = "YYYY/MM/DD"
        '
        'CM_LCONFIG
        '
        Me.CM_LCONFIG.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_LCONFIG.Image = CType(resources.GetObject("CM_LCONFIG.Image"), System.Drawing.Image)
        Me.CM_LCONFIG.Location = New System.Drawing.Point(128, 6)
        Me.CM_LCONFIG.Name = "CM_LCONFIG"
        Me.CM_LCONFIG.Size = New System.Drawing.Size(24, 22)
        Me.CM_LCONFIG.TabIndex = 6
        Me.CM_LCONFIG.TabStop = False
        Me.CM_LCONFIG.Visible = False
        '
        'CM_DELETEDE
        '
        Me.CM_DELETEDE.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_DELETEDE.Image = CType(resources.GetObject("CM_DELETEDE.Image"), System.Drawing.Image)
        Me.CM_DELETEDE.Location = New System.Drawing.Point(82, 6)
        Me.CM_DELETEDE.Name = "CM_DELETEDE"
        Me.CM_DELETEDE.Size = New System.Drawing.Size(24, 22)
        Me.CM_DELETEDE.TabIndex = 8
        Me.CM_DELETEDE.TabStop = False
        Me.CM_DELETEDE.Visible = False
        '
        'CM_INSERTDE
        '
        Me.CM_INSERTDE.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_INSERTDE.Image = CType(resources.GetObject("CM_INSERTDE.Image"), System.Drawing.Image)
        Me.CM_INSERTDE.Location = New System.Drawing.Point(59, 6)
        Me.CM_INSERTDE.Name = "CM_INSERTDE"
        Me.CM_INSERTDE.Size = New System.Drawing.Size(24, 22)
        Me.CM_INSERTDE.TabIndex = 9
        Me.CM_INSERTDE.TabStop = False
        Me.CM_INSERTDE.Visible = False
        '
        'CM_SLIST
        '
        Me.CM_SLIST.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_SLIST.Image = CType(resources.GetObject("CM_SLIST.Image"), System.Drawing.Image)
        Me.CM_SLIST.Location = New System.Drawing.Point(105, 6)
        Me.CM_SLIST.Name = "CM_SLIST"
        Me.CM_SLIST.Size = New System.Drawing.Size(24, 22)
        Me.CM_SLIST.TabIndex = 10
        Me.CM_SLIST.TabStop = False
        Me.CM_SLIST.Visible = False
        '
        'Image1
        '
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Location = New System.Drawing.Point(2, 0)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(421, 34)
        Me.Image1.TabIndex = 12
        Me.Image1.TabStop = False
        '
        '_FM_Panel3D1_6
        '
        Me._FM_Panel3D1_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_6, CType(6, Short))
        Me._FM_Panel3D1_6.Location = New System.Drawing.Point(327, 202)
        Me._FM_Panel3D1_6.Name = "_FM_Panel3D1_6"
        Me._FM_Panel3D1_6.Size = New System.Drawing.Size(148, 21)
        Me._FM_Panel3D1_6.TabIndex = 17
        Me._FM_Panel3D1_6.Text = "銀行名称"
        Me._FM_Panel3D1_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_FM_Panel3D1_10
        '
        Me._FM_Panel3D1_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_10, CType(10, Short))
        Me._FM_Panel3D1_10.Location = New System.Drawing.Point(793, 180)
        Me._FM_Panel3D1_10.Name = "_FM_Panel3D1_10"
        Me._FM_Panel3D1_10.Size = New System.Drawing.Size(151, 43)
        Me._FM_Panel3D1_10.TabIndex = 18
        Me._FM_Panel3D1_10.Text = "備　考"
        Me._FM_Panel3D1_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_FM_Panel3D1_9
        '
        Me._FM_Panel3D1_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_9, CType(9, Short))
        Me._FM_Panel3D1_9.Location = New System.Drawing.Point(702, 180)
        Me._FM_Panel3D1_9.Name = "_FM_Panel3D1_9"
        Me._FM_Panel3D1_9.Size = New System.Drawing.Size(92, 43)
        Me._FM_Panel3D1_9.TabIndex = 19
        Me._FM_Panel3D1_9.Text = "手形番号"
        Me._FM_Panel3D1_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_FM_Panel3D1_4
        '
        Me._FM_Panel3D1_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_4, CType(4, Short))
        Me._FM_Panel3D1_4.Location = New System.Drawing.Point(209, 180)
        Me._FM_Panel3D1_4.Name = "_FM_Panel3D1_4"
        Me._FM_Panel3D1_4.Size = New System.Drawing.Size(119, 23)
        Me._FM_Panel3D1_4.TabIndex = 20
        Me._FM_Panel3D1_4.Text = "入金額（円）"
        Me._FM_Panel3D1_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_FM_Panel3D1_11
        '
        Me._FM_Panel3D1_11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_11, CType(11, Short))
        Me._FM_Panel3D1_11.Location = New System.Drawing.Point(29, 492)
        Me._FM_Panel3D1_11.Name = "_FM_Panel3D1_11"
        Me._FM_Panel3D1_11.Size = New System.Drawing.Size(86, 20)
        Me._FM_Panel3D1_11.TabIndex = 24
        Me._FM_Panel3D1_11.Text = "合計（円）"
        Me._FM_Panel3D1_11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_FM_Panel3D1_3
        '
        Me._FM_Panel3D1_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_3, CType(3, Short))
        Me._FM_Panel3D1_3.Location = New System.Drawing.Point(28, 180)
        Me._FM_Panel3D1_3.Name = "_FM_Panel3D1_3"
        Me._FM_Panel3D1_3.Size = New System.Drawing.Size(37, 43)
        Me._FM_Panel3D1_3.TabIndex = 35
        Me._FM_Panel3D1_3.Text = "No"
        Me._FM_Panel3D1_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CS_NYUDT
        '
        Me.CS_NYUDT.Location = New System.Drawing.Point(18, 99)
        Me.CS_NYUDT.Name = "CS_NYUDT"
        Me.CS_NYUDT.Size = New System.Drawing.Size(87, 22)
        Me.CS_NYUDT.TabIndex = 37
        Me.CS_NYUDT.TabStop = False
        Me.CS_NYUDT.Text = "*入金日   "
        Me.CS_NYUDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CS_DKBID
        '
        Me.CS_DKBID.Location = New System.Drawing.Point(64, 180)
        Me.CS_DKBID.Name = "CS_DKBID"
        Me.CS_DKBID.Size = New System.Drawing.Size(71, 43)
        Me.CS_DKBID.TabIndex = 38
        Me.CS_DKBID.TabStop = False
        Me.CS_DKBID.Text = "*入金種別"
        '
        '_FM_Panel3D1_2
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_2, CType(2, Short))
        Me._FM_Panel3D1_2.Location = New System.Drawing.Point(628, 50)
        Me._FM_Panel3D1_2.Name = "_FM_Panel3D1_2"
        Me._FM_Panel3D1_2.Size = New System.Drawing.Size(82, 22)
        Me._FM_Panel3D1_2.TabIndex = 39
        Me._FM_Panel3D1_2.Text = "入力担当者"
        '
        '_FM_Panel3D1_5
        '
        Me._FM_Panel3D1_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_5, CType(5, Short))
        Me._FM_Panel3D1_5.Location = New System.Drawing.Point(209, 202)
        Me._FM_Panel3D1_5.Name = "_FM_Panel3D1_5"
        Me._FM_Panel3D1_5.Size = New System.Drawing.Size(119, 21)
        Me._FM_Panel3D1_5.TabIndex = 40
        Me._FM_Panel3D1_5.Text = "入金額（外貨）"
        Me._FM_Panel3D1_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_FM_Panel3D1_8
        '
        Me._FM_Panel3D1_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_8, CType(8, Short))
        Me._FM_Panel3D1_8.Location = New System.Drawing.Point(474, 202)
        Me._FM_Panel3D1_8.Name = "_FM_Panel3D1_8"
        Me._FM_Panel3D1_8.Size = New System.Drawing.Size(148, 21)
        Me._FM_Panel3D1_8.TabIndex = 41
        Me._FM_Panel3D1_8.Text = "支店名称"
        Me._FM_Panel3D1_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_FM_Panel3D1_7
        '
        Me._FM_Panel3D1_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_7, CType(7, Short))
        Me._FM_Panel3D1_7.Location = New System.Drawing.Point(474, 180)
        Me._FM_Panel3D1_7.Name = "_FM_Panel3D1_7"
        Me._FM_Panel3D1_7.Size = New System.Drawing.Size(148, 23)
        Me._FM_Panel3D1_7.TabIndex = 42
        Me._FM_Panel3D1_7.Text = "受注番号"
        Me._FM_Panel3D1_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_FM_Panel3D1_12
        '
        Me._FM_Panel3D1_12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_12, CType(12, Short))
        Me._FM_Panel3D1_12.Location = New System.Drawing.Point(29, 516)
        Me._FM_Panel3D1_12.Name = "_FM_Panel3D1_12"
        Me._FM_Panel3D1_12.Size = New System.Drawing.Size(86, 22)
        Me._FM_Panel3D1_12.TabIndex = 43
        Me._FM_Panel3D1_12.Text = "合計(外貨)"
        Me._FM_Panel3D1_12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_FM_Panel3D1_1
        '
        Me._FM_Panel3D1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_1, CType(1, Short))
        Me._FM_Panel3D1_1.Location = New System.Drawing.Point(18, 78)
        Me._FM_Panel3D1_1.Name = "_FM_Panel3D1_1"
        Me._FM_Panel3D1_1.Size = New System.Drawing.Size(87, 22)
        Me._FM_Panel3D1_1.TabIndex = 44
        Me._FM_Panel3D1_1.Text = "入金区分"
        Me._FM_Panel3D1_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CS_BNKCD
        '
        Me.CS_BNKCD.Location = New System.Drawing.Point(327, 180)
        Me.CS_BNKCD.Name = "CS_BNKCD"
        Me.CS_BNKCD.Size = New System.Drawing.Size(148, 23)
        Me.CS_BNKCD.TabIndex = 45
        Me.CS_BNKCD.TabStop = False
        Me.CS_BNKCD.Text = "銀行コード"
        '
        'CS_KNJKOZ
        '
        Me.CS_KNJKOZ.Location = New System.Drawing.Point(18, 142)
        Me.CS_KNJKOZ.Name = "CS_KNJKOZ"
        Me.CS_KNJKOZ.Size = New System.Drawing.Size(87, 22)
        Me.CS_KNJKOZ.TabIndex = 46
        Me.CS_KNJKOZ.TabStop = False
        Me.CS_KNJKOZ.Text = "勘定口座"
        Me.CS_KNJKOZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CS_TEGDT
        '
        Me.CS_TEGDT.Location = New System.Drawing.Point(621, 180)
        Me.CS_TEGDT.Name = "CS_TEGDT"
        Me.CS_TEGDT.Size = New System.Drawing.Size(82, 43)
        Me.CS_TEGDT.TabIndex = 49
        Me.CS_TEGDT.TabStop = False
        Me.CS_TEGDT.Text = "決済日"
        '
        'CS_KANKOZ
        '
        Me.CS_KANKOZ.Location = New System.Drawing.Point(134, 180)
        Me.CS_KANKOZ.Name = "CS_KANKOZ"
        Me.CS_KANKOZ.Size = New System.Drawing.Size(76, 43)
        Me.CS_KANKOZ.TabIndex = 50
        Me.CS_KANKOZ.TabStop = False
        Me.CS_KANKOZ.Text = "*勘定口座"
        '
        'HD_DATNO
        '
        Me.HD_DATNO.AcceptsReturn = True
        Me.HD_DATNO.BackColor = System.Drawing.Color.White
        Me.HD_DATNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_DATNO.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_DATNO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_DATNO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_DATNO.Location = New System.Drawing.Point(32, 50)
        Me.HD_DATNO.MaxLength = 10
        Me.HD_DATNO.Name = "HD_DATNO"
        Me.HD_DATNO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_DATNO.Size = New System.Drawing.Size(83, 20)
        Me.HD_DATNO.TabIndex = 52
        Me.HD_DATNO.Text = "1234567890"
        '
        '_FM_Panel3D1_16
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_16, CType(16, Short))
        Me._FM_Panel3D1_16.Location = New System.Drawing.Point(442, 125)
        Me._FM_Panel3D1_16.Name = "_FM_Panel3D1_16"
        Me._FM_Panel3D1_16.Size = New System.Drawing.Size(44, 22)
        Me._FM_Panel3D1_16.TabIndex = 54
        Me._FM_Panel3D1_16.Text = "通貨"
        '
        '_FM_Panel3D1_17
        '
        Me._FM_Panel3D1_17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_17, CType(17, Short))
        Me._FM_Panel3D1_17.Location = New System.Drawing.Point(18, 119)
        Me._FM_Panel3D1_17.Name = "_FM_Panel3D1_17"
        Me._FM_Panel3D1_17.Size = New System.Drawing.Size(87, 23)
        Me._FM_Panel3D1_17.TabIndex = 55
        Me._FM_Panel3D1_17.Text = " 請求先   "
        Me._FM_Panel3D1_17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(140, 81)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(152, 20)
        Me.Label19.TabIndex = 47
        Me.Label19.Text = "1:入金　2:前受入金"
        '
        'BD_BNKCD
        '
        '
        'BD_BNKNM
        '
        '
        'BD_DKBID
        '
        '
        'BD_DKBNM
        '
        '
        'BD_FNYUKN
        '
        '
        'BD_JDNNO
        '
        '
        'BD_KANKOZ
        '
        '
        'BD_LINCMA
        '
        '
        'BD_LINCMB
        '
        '
        'BD_LINNO
        '
        '
        'BD_NYUKN
        '
        '
        'BD_STNNM
        '
        '
        'BD_TEGDT
        '
        '
        'BD_TEGNO
        '
        '
        'MainMenu1
        '
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(980, 24)
        Me.MainMenu1.TabIndex = 56
        '
        'MN_Ctrl
        '
        Me.MN_Ctrl.Name = "MN_Ctrl"
        Me.MN_Ctrl.Size = New System.Drawing.Size(61, 4)
        Me.MN_Ctrl.Text = "処理(&1)"
        '
        'MN_Execute
        '
        Me.MN_Execute.Name = "MN_Execute"
        Me.MN_Execute.Size = New System.Drawing.Size(61, 4)
        Me.MN_Execute.Text = "登録(&R)"
        '
        'MN_DeleteCM
        '
        Me.MN_DeleteCM.Name = "MN_DeleteCM"
        Me.MN_DeleteCM.Size = New System.Drawing.Size(61, 4)
        Me.MN_DeleteCM.Text = "削除(&D)"
        '
        'MN_HARDCOPY
        '
        Me.MN_HARDCOPY.Name = "MN_HARDCOPY"
        Me.MN_HARDCOPY.Size = New System.Drawing.Size(61, 4)
        Me.MN_HARDCOPY.Text = "画面印刷"
        '
        'MN_LCONFIG
        '
        Me.MN_LCONFIG.Name = "MN_LCONFIG"
        Me.MN_LCONFIG.Size = New System.Drawing.Size(61, 4)
        Me.MN_LCONFIG.Text = "印刷設定(&I)..."
        '
        'bar11
        '
        Me.bar11.Name = "bar11"
        Me.bar11.Size = New System.Drawing.Size(6, 6)
        '
        'MN_EndCm
        '
        Me.MN_EndCm.Name = "MN_EndCm"
        Me.MN_EndCm.Size = New System.Drawing.Size(61, 4)
        Me.MN_EndCm.Text = "終了(&X)"
        '
        'MN_EditMn
        '
        Me.MN_EditMn.Name = "MN_EditMn"
        Me.MN_EditMn.Size = New System.Drawing.Size(61, 4)
        Me.MN_EditMn.Text = "編集(&2)"
        '
        'MN_APPENDC
        '
        Me.MN_APPENDC.Name = "MN_APPENDC"
        Me.MN_APPENDC.Size = New System.Drawing.Size(61, 4)
        Me.MN_APPENDC.Text = "画面初期化(&S)"
        '
        'MN_ClearItm
        '
        Me.MN_ClearItm.Name = "MN_ClearItm"
        Me.MN_ClearItm.Size = New System.Drawing.Size(61, 4)
        Me.MN_ClearItm.Text = "項目初期化"
        '
        'MN_UnDoItem
        '
        Me.MN_UnDoItem.Name = "MN_UnDoItem"
        Me.MN_UnDoItem.Size = New System.Drawing.Size(61, 4)
        Me.MN_UnDoItem.Text = "項目復元"
        '
        'MN_ClearDE
        '
        Me.MN_ClearDE.Name = "MN_ClearDE"
        Me.MN_ClearDE.Size = New System.Drawing.Size(61, 4)
        Me.MN_ClearDE.Text = "明細行初期化"
        '
        'MN_DeleteDE
        '
        Me.MN_DeleteDE.Name = "MN_DeleteDE"
        Me.MN_DeleteDE.Size = New System.Drawing.Size(61, 4)
        Me.MN_DeleteDE.Text = "明細行削除(&T)"
        '
        'MN_InsertDE
        '
        Me.MN_InsertDE.Name = "MN_InsertDE"
        Me.MN_InsertDE.Size = New System.Drawing.Size(61, 4)
        Me.MN_InsertDE.Text = "明細行挿入(&I)"
        '
        'MN_UnDoDe
        '
        Me.MN_UnDoDe.Name = "MN_UnDoDe"
        Me.MN_UnDoDe.Size = New System.Drawing.Size(61, 4)
        Me.MN_UnDoDe.Text = "明細行復元"
        '
        'Bar21
        '
        Me.Bar21.Name = "Bar21"
        Me.Bar21.Size = New System.Drawing.Size(6, 6)
        '
        'MN_Cut
        '
        Me.MN_Cut.Name = "MN_Cut"
        Me.MN_Cut.Size = New System.Drawing.Size(61, 4)
        Me.MN_Cut.Text = "切り取り(&X)"
        '
        'MN_Copy
        '
        Me.MN_Copy.Name = "MN_Copy"
        Me.MN_Copy.Size = New System.Drawing.Size(61, 4)
        Me.MN_Copy.Text = "コピー(&C)"
        '
        'MN_Paste
        '
        Me.MN_Paste.Name = "MN_Paste"
        Me.MN_Paste.Size = New System.Drawing.Size(61, 4)
        Me.MN_Paste.Text = "貼り付け(&V)"
        '
        'MN_Oprt
        '
        Me.MN_Oprt.Name = "MN_Oprt"
        Me.MN_Oprt.Size = New System.Drawing.Size(61, 4)
        Me.MN_Oprt.Text = "操作(&3)"
        '
        'MN_Slist
        '
        Me.MN_Slist.Name = "MN_Slist"
        Me.MN_Slist.Size = New System.Drawing.Size(61, 4)
        Me.MN_Slist.Text = "候補の一覧(&L&ﾆ)..."
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
        Me.SM_AllCopy.Size = New System.Drawing.Size(61, 4)
        Me.SM_AllCopy.Text = "項目内容コピー(&C)"
        '
        'SM_FullPast
        '
        Me.SM_FullPast.Name = "SM_FullPast"
        Me.SM_FullPast.Size = New System.Drawing.Size(61, 4)
        Me.SM_FullPast.Text = "項目に貼り付け(&P)"
        '
        'SM_Esc
        '
        Me.SM_Esc.Name = "SM_Esc"
        Me.SM_Esc.Size = New System.Drawing.Size(61, 4)
        Me.SM_Esc.Text = "取消し(Esc)"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 648)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(980, 23)
        Me.StatusStrip1.TabIndex = 231
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(193, 18)
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(193, 18)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "端末ID"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(193, 18)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Text = "ログインID"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(193, 18)
        Me.ToolStripStatusLabel4.Spring = True
        Me.ToolStripStatusLabel4.Text = "XXXXXXX"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(193, 18)
        Me.ToolStripStatusLabel5.Spring = True
        Me.ToolStripStatusLabel5.Text = "Ver.1.00"
        '
        'dummyCtl
        '
        Me.dummyCtl.AutoSize = True
        Me.dummyCtl.Location = New System.Drawing.Point(728, 119)
        Me.dummyCtl.Name = "dummyCtl"
        Me.dummyCtl.Size = New System.Drawing.Size(63, 13)
        Me.dummyCtl.TabIndex = 216
        Me.dummyCtl.Text = "dummyCtl"
        Me.dummyCtl.Visible = False
        '
        'btnF12
        '
        Me.btnF12.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF12.Location = New System.Drawing.Point(897, 610)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(75, 35)
        Me.btnF12.TabIndex = 243
        Me.btnF12.Text = "(F12)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'btnF11
        '
        Me.btnF11.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF11.Location = New System.Drawing.Point(820, 610)
        Me.btnF11.Name = "btnF11"
        Me.btnF11.Size = New System.Drawing.Size(75, 35)
        Me.btnF11.TabIndex = 242
        Me.btnF11.Text = "(F11)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF11.UseVisualStyleBackColor = True
        '
        'btnF10
        '
        Me.btnF10.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF10.Location = New System.Drawing.Point(742, 610)
        Me.btnF10.Name = "btnF10"
        Me.btnF10.Size = New System.Drawing.Size(75, 35)
        Me.btnF10.TabIndex = 241
        Me.btnF10.Text = "(F10)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF10.UseVisualStyleBackColor = True
        '
        'btnF9
        '
        Me.btnF9.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF9.Location = New System.Drawing.Point(665, 610)
        Me.btnF9.Name = "btnF9"
        Me.btnF9.Size = New System.Drawing.Size(75, 35)
        Me.btnF9.TabIndex = 240
        Me.btnF9.Text = "(F9)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "クリア"
        Me.btnF9.UseVisualStyleBackColor = True
        '
        'btnF8
        '
        Me.btnF8.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF8.Location = New System.Drawing.Point(571, 610)
        Me.btnF8.Name = "btnF8"
        Me.btnF8.Size = New System.Drawing.Size(75, 35)
        Me.btnF8.TabIndex = 239
        Me.btnF8.Text = "(F8)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "行削除"
        Me.btnF8.UseVisualStyleBackColor = True
        '
        'btnF7
        '
        Me.btnF7.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF7.Location = New System.Drawing.Point(493, 610)
        Me.btnF7.Name = "btnF7"
        Me.btnF7.Size = New System.Drawing.Size(75, 35)
        Me.btnF7.TabIndex = 238
        Me.btnF7.Text = "(F7)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "行追加"
        Me.btnF7.UseVisualStyleBackColor = True
        '
        'btnF6
        '
        Me.btnF6.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF6.Location = New System.Drawing.Point(415, 610)
        Me.btnF6.Name = "btnF6"
        Me.btnF6.Size = New System.Drawing.Size(75, 35)
        Me.btnF6.TabIndex = 237
        Me.btnF6.Text = "(F6)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF6.UseVisualStyleBackColor = True
        '
        'btnF5
        '
        Me.btnF5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF5.Location = New System.Drawing.Point(337, 610)
        Me.btnF5.Name = "btnF5"
        Me.btnF5.Size = New System.Drawing.Size(75, 35)
        Me.btnF5.TabIndex = 236
        Me.btnF5.Text = "(F5)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "参照"
        Me.btnF5.UseVisualStyleBackColor = True
        '
        'btnF4
        '
        Me.btnF4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF4.Location = New System.Drawing.Point(243, 610)
        Me.btnF4.Name = "btnF4"
        Me.btnF4.Size = New System.Drawing.Size(75, 35)
        Me.btnF4.TabIndex = 235
        Me.btnF4.Text = "(F4)"
        Me.btnF4.UseVisualStyleBackColor = True
        '
        'btnF3
        '
        Me.btnF3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF3.Location = New System.Drawing.Point(164, 610)
        Me.btnF3.Name = "btnF3"
        Me.btnF3.Size = New System.Drawing.Size(75, 35)
        Me.btnF3.TabIndex = 234
        Me.btnF3.Text = "(F3)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "削除"
        Me.btnF3.UseVisualStyleBackColor = True
        '
        'btnF2
        '
        Me.btnF2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF2.Location = New System.Drawing.Point(85, 610)
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(75, 35)
        Me.btnF2.TabIndex = 233
        Me.btnF2.Text = "(F2)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "検索"
        Me.btnF2.UseVisualStyleBackColor = True
        '
        'btnF1
        '
        Me.btnF1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF1.Location = New System.Drawing.Point(6, 610)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(75, 35)
        Me.btnF1.TabIndex = 232
        Me.btnF1.Text = "(F1)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "更新"
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'FR_SSSMAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(980, 671)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.btnF11)
        Me.Controls.Add(Me.btnF10)
        Me.Controls.Add(Me.btnF9)
        Me.Controls.Add(Me.btnF8)
        Me.Controls.Add(Me.btnF7)
        Me.Controls.Add(Me.btnF6)
        Me.Controls.Add(Me.btnF5)
        Me.Controls.Add(Me.btnF4)
        Me.Controls.Add(Me.btnF3)
        Me.Controls.Add(Me.btnF2)
        Me.Controls.Add(Me.btnF1)
        Me.Controls.Add(Me.dummyCtl)
        Me.Controls.Add(Me.TX_Message)
        Me.Controls.Add(Me._IM_Denkyu_0)
        Me.Controls.Add(Me.CS_DATNO)
        Me.Controls.Add(Me.VS_Scrl)
        Me.Controls.Add(Me._BD_JDNNO_0)
        Me.Controls.Add(Me._BD_LINNO_0)
        Me.Controls.Add(Me.TL_SBANYUKN)
        Me.Controls.Add(Me.HD_TOKCD)
        Me.Controls.Add(Me._BD_NYUKN_0)
        Me.Controls.Add(Me._BD_LINCMA_0)
        Me.Controls.Add(Me._BD_TEGNO_0)
        Me.Controls.Add(Me._BD_TEGDT_0)
        Me.Controls.Add(Me._BD_BNKNM_0)
        Me.Controls.Add(Me._BD_BNKCD_0)
        Me.Controls.Add(Me._BD_DKBID_0)
        Me.Controls.Add(Me._BD_LINCMB_0)
        Me.Controls.Add(Me.HD_NYUDT)
        Me.Controls.Add(Me.HD_TOKRN)
        Me.Controls.Add(Me._BD_DKBNM_0)
        Me.Controls.Add(Me.HD_TUKKB)
        Me.Controls.Add(Me.HD_NYUKB)
        Me.Controls.Add(Me.HD_IN_TANCD)
        Me.Controls.Add(Me.HD_IN_TANNM)
        Me.Controls.Add(Me._BD_FNYUKN_0)
        Me.Controls.Add(Me._BD_STNNM_0)
        Me.Controls.Add(Me.TL_SBAFRNKN)
        Me.Controls.Add(Me.HD_KNJKOZ)
        Me.Controls.Add(Me._BD_KANKOZ_0)
        Me.Controls.Add(Me._FM_Panel3D1_13)
        Me.Controls.Add(Me.TX_CursorRest)
        Me.Controls.Add(Me._FM_Panel3D1_15)
        Me.Controls.Add(Me._FM_Panel3D1_0)
        Me.Controls.Add(Me._FM_Panel3D1_6)
        Me.Controls.Add(Me._FM_Panel3D1_10)
        Me.Controls.Add(Me._FM_Panel3D1_9)
        Me.Controls.Add(Me._FM_Panel3D1_4)
        Me.Controls.Add(Me._FM_Panel3D1_11)
        Me.Controls.Add(Me._FM_Panel3D1_3)
        Me.Controls.Add(Me.CS_NYUDT)
        Me.Controls.Add(Me.CS_DKBID)
        Me.Controls.Add(Me._FM_Panel3D1_2)
        Me.Controls.Add(Me._FM_Panel3D1_5)
        Me.Controls.Add(Me._FM_Panel3D1_8)
        Me.Controls.Add(Me._FM_Panel3D1_7)
        Me.Controls.Add(Me._FM_Panel3D1_12)
        Me.Controls.Add(Me._FM_Panel3D1_1)
        Me.Controls.Add(Me.CS_BNKCD)
        Me.Controls.Add(Me.CS_KNJKOZ)
        Me.Controls.Add(Me.CS_TEGDT)
        Me.Controls.Add(Me.CS_KANKOZ)
        Me.Controls.Add(Me.HD_DATNO)
        Me.Controls.Add(Me._FM_Panel3D1_16)
        Me.Controls.Add(Me._FM_Panel3D1_17)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.MainMenu1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(53, 171)
        Me.MaximizeBox = False
        Me.Name = "FR_SSSMAIN"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "入金訂正"
        Me._FM_Panel3D1_13.ResumeLayout(False)
        CType(Me._IM_Denkyu_0, System.ComponentModel.ISupportInitialize).EndInit()
        Me._FM_Panel3D1_15.ResumeLayout(False)
        Me._FM_Panel3D1_15.PerformLayout()
        CType(Me._IM_Execute_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_LCONFIG_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_LCONFIG_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Denkyu_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Denkyu_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_DELETEDE_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_DELETEDE_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_INSERTDE_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_INSERTDE_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_NEXTCM_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_NEXTCM_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_PREV_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_PREV_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Hardcopy_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Slist_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_EndCm_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_EndCm_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Slist_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Hardcopy_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Execute_1_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Execute_1_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me._FM_Panel3D1_0.ResumeLayout(False)
        CType(Me.CM_LCONFIG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_DELETEDE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_INSERTDE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_SLIST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_BNKCD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_BNKNM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_DKBID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_DKBNM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_FNYUKN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_JDNNO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_KANKOZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_LINCMA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_LINCMB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_LINNO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_NYUKN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_STNNM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_TEGDT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_TEGNO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FM_Panel3D1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_DELETEDE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_Denkyu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_EndCm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_Execute, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_Execute_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_Hardcopy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_INSERTDE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_LCONFIG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_NEXTCM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_PREV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IM_Slist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    '2019/06/05 ADD START
    Friend WithEvents dummyCtl As System.Windows.Forms.Label
    '2019/06/05 ADD END
    Friend WithEvents btnF12 As System.Windows.Forms.Button
    Friend WithEvents btnF11 As System.Windows.Forms.Button
    Friend WithEvents btnF10 As System.Windows.Forms.Button
    Friend WithEvents btnF9 As System.Windows.Forms.Button
    Friend WithEvents btnF8 As System.Windows.Forms.Button
    Friend WithEvents btnF7 As System.Windows.Forms.Button
    Friend WithEvents btnF6 As System.Windows.Forms.Button
    Friend WithEvents btnF5 As System.Windows.Forms.Button
    Friend WithEvents btnF4 As System.Windows.Forms.Button
    Friend WithEvents btnF3 As System.Windows.Forms.Button
    Friend WithEvents btnF2 As System.Windows.Forms.Button
    Friend WithEvents btnF1 As System.Windows.Forms.Button
    Public WithEvents _BD_TEGNO_0 As TextBox
#End Region
End Class