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
    '2019/06/20 CHG START
    'Public WithEvents CS_UODSU As SSCommand5
    Public WithEvents CS_UODSU As Button
    '2019/06/20 CHG END
    Public WithEvents HD_NHSZIPCD As System.Windows.Forms.TextBox
    Public WithEvents HD_NHSTL As System.Windows.Forms.TextBox
	Public WithEvents HD_NHSFAX As System.Windows.Forms.TextBox
	Public WithEvents HD_BINNM As System.Windows.Forms.TextBox
	Public WithEvents HD_BINCD As System.Windows.Forms.TextBox
	Public WithEvents HD_DENDT As System.Windows.Forms.TextBox
	Public WithEvents HD_NHSADC As System.Windows.Forms.TextBox
	Public WithEvents HD_NHSADB As System.Windows.Forms.TextBox
    Public WithEvents HD_NHSADA As System.Windows.Forms.TextBox
    '2019/06/20 CHG START
    '   Public WithEvents CS_HINCD As SSCommand5
    'Public WithEvents _FM_Panel3D1_14 As SSPanel5
    Public WithEvents CS_HINCD As Button
    Public WithEvents _FM_Panel3D1_14 As Label
    '2019/06/20 CHG END
    Public WithEvents TL_KKOUT As System.Windows.Forms.CheckBox
	Public WithEvents _BD_UODSU_0 As System.Windows.Forms.TextBox
	Public WithEvents _BD_HINNMA_0 As System.Windows.Forms.TextBox
	Public WithEvents _BD_HINNMB_0 As System.Windows.Forms.TextBox
	Public WithEvents _BD_UNTNM_0 As System.Windows.Forms.TextBox
	Public WithEvents _BD_HINCD_0 As System.Windows.Forms.TextBox
	Public WithEvents _BD_LINCMB_0 As System.Windows.Forms.TextBox
	Public WithEvents _BD_LINCMA_0 As System.Windows.Forms.TextBox
	Public WithEvents HD_NHSNMB As System.Windows.Forms.TextBox
	Public WithEvents HD_NHSNMA As System.Windows.Forms.TextBox
	Public WithEvents HD_NHSCD As System.Windows.Forms.TextBox
	Public WithEvents HD_TANCD As System.Windows.Forms.TextBox
	Public WithEvents HD_BUMCD As System.Windows.Forms.TextBox
	Public WithEvents HD_TANNM As System.Windows.Forms.TextBox
	Public WithEvents HD_BUMNM As System.Windows.Forms.TextBox
	Public WithEvents HD_OUTRYCD As System.Windows.Forms.TextBox
	Public WithEvents HD_OUTRYNM As System.Windows.Forms.TextBox
	Public WithEvents HD_TOKCD As System.Windows.Forms.TextBox
	Public WithEvents HD_TOKRN As System.Windows.Forms.TextBox
	Public WithEvents HD_SBNNO As System.Windows.Forms.TextBox
	Public WithEvents HD_URIKJNNM As System.Windows.Forms.TextBox
	Public WithEvents HD_SOUCD As System.Windows.Forms.TextBox
	Public WithEvents HD_SOUNM As System.Windows.Forms.TextBox
	Public WithEvents HD_IN_TANNM As System.Windows.Forms.TextBox
	Public WithEvents HD_IN_TANCD As System.Windows.Forms.TextBox
	Public WithEvents HD_JDNNO As System.Windows.Forms.TextBox
	Public WithEvents TM_StartUp As System.Windows.Forms.Timer
    Public WithEvents TX_CursorRest As System.Windows.Forms.TextBox
    '2019/06/20 CHG START
    '   Public WithEvents _FM_Panel3D1_19 As SSPanel5
    'Public WithEvents CS_REF_JDNNO As SSCommand5
    'Public WithEvents CS_SOUCD As SSCommand5
    'Public WithEvents _FM_Panel3D1_3 As SSPanel5
    'Public WithEvents _FM_Panel3D1_2 As SSPanel5
    'Public WithEvents CS_TOKCD As SSCommand5
    'Public WithEvents CS_OUTRY As SSCommand5
    'Public WithEvents _FM_Panel3D1_24 As SSPanel5
    'Public WithEvents _FM_Panel3D1_25 As SSPanel5
    'Public WithEvents _FM_Panel3D1_26 As SSPanel5
    'Public WithEvents CS_BUMCD As SSCommand5
    'Public WithEvents CS_TANCD As SSCommand5
    'Public WithEvents _FM_Panel3D1_1 As SSPanel5
    'Public WithEvents CS_NHSCD As SSCommand5
    'Public WithEvents _FM_Panel3D1_17 As SSPanel5
    'Public WithEvents _FM_Panel3D1_16 As SSPanel5
    'Public WithEvents _FM_Panel3D1_18 As SSPanel5
    'Public WithEvents _FM_Panel3D1_10 As SSPanel5
    'Public WithEvents _FM_Panel3D1_4 As SSPanel5
    'Public WithEvents _FM_Panel3D1_9 As SSPanel5
    'Public WithEvents _FM_Panel3D1_6 As SSPanel5
    'Public WithEvents _FM_Panel3D1_7 As SSPanel5
    'Public WithEvents _FM_Panel3D1_12 As SSPanel5
    'Public WithEvents _FM_Panel3D1_11 As SSPanel5
    'Public WithEvents _FM_Panel3D1_13 As SSPanel5
    'Public WithEvents _FM_Panel3D1_5 As SSPanel5
    'Public WithEvents _FM_Panel3D1_22 As SSPanel5
    'Public WithEvents _FM_Panel3D1_21 As SSPanel5
    'Public WithEvents _FM_Panel3D1_23 As SSPanel5
    'Public WithEvents _FM_Panel3D1_20 As SSPanel5
    'Public WithEvents SYSDT As SSPanel5
    Public WithEvents _FM_Panel3D1_19 As Label
    Public WithEvents CS_REF_JDNNO As Button
    Public WithEvents CS_SOUCD As Button
    Public WithEvents _FM_Panel3D1_3 As Label
    Public WithEvents _FM_Panel3D1_2 As Label
    Public WithEvents CS_TOKCD As Button
    Public WithEvents CS_OUTRY As Button
    Public WithEvents _FM_Panel3D1_24 As Label
    Public WithEvents _FM_Panel3D1_25 As Label
    Public WithEvents _FM_Panel3D1_26 As Label
    Public WithEvents CS_BUMCD As Button
    Public WithEvents CS_TANCD As Button
    Public WithEvents _FM_Panel3D1_1 As Label
    Public WithEvents CS_NHSCD As Button
    Public WithEvents _FM_Panel3D1_17 As Label
    Public WithEvents _FM_Panel3D1_16 As Label
    Public WithEvents _FM_Panel3D1_18 As Label
    Public WithEvents _FM_Panel3D1_10 As Label
    Public WithEvents _FM_Panel3D1_4 As Label
    Public WithEvents _FM_Panel3D1_9 As Label
    Public WithEvents _FM_Panel3D1_6 As Label
    Public WithEvents _FM_Panel3D1_7 As Label
    Public WithEvents _FM_Panel3D1_12 As Label
    Public WithEvents _FM_Panel3D1_11 As Label
    Public WithEvents _FM_Panel3D1_13 As Label
    Public WithEvents _FM_Panel3D1_5 As Label
    Public WithEvents _FM_Panel3D1_22 As Label
    Public WithEvents _FM_Panel3D1_21 As Label
    Public WithEvents _FM_Panel3D1_23 As Label
    Public WithEvents _FM_Panel3D1_20 As Label
    Public WithEvents SYSDT As Label
    '2019/06/20 CHG END
    Public WithEvents CM_EndCm As System.Windows.Forms.PictureBox
	Public WithEvents CM_SLIST As System.Windows.Forms.PictureBox
	Public WithEvents CM_INSERTDE As System.Windows.Forms.PictureBox
	Public WithEvents CM_DELETEDE As System.Windows.Forms.PictureBox
	Public WithEvents CM_Execute As System.Windows.Forms.PictureBox
    Public WithEvents Image1 As System.Windows.Forms.PictureBox
    '2019/06/20 CHG START
    '   Public WithEvents _FM_Panel3D1_0 As SSPanel5
    'Public WithEvents _Line1_0 As System.Windows.Forms.Label
    'Public WithEvents _FM_Panel3D1_15 As SSPanel5
    'Public WithEvents _FM_Panel3D1_30 As SSPanel5
    'Public WithEvents CS_JDNDT As SSCommand5
    'Public WithEvents CS_REF_SBN As SSCommand5
    'Public WithEvents TX_Message As System.Windows.Forms.TextBox
    'Public WithEvents _FM_Panel3D1_27 As SSPanel5
    'Public WithEvents _IM_Denkyu_0 As System.Windows.Forms.PictureBox
    'Public WithEvents _FM_Panel3D1_28 As SSPanel5
    Public WithEvents _FM_Panel3D1_0 As Label
    Public WithEvents _Line1_0 As System.Windows.Forms.Label
    Public WithEvents _FM_Panel3D1_15 As Label
    Public WithEvents _FM_Panel3D1_30 As Label
    Public WithEvents CS_JDNDT As Button
    Public WithEvents CS_REF_SBN As Button
    Public WithEvents TX_Message As System.Windows.Forms.TextBox
    Public WithEvents _FM_Panel3D1_27 As Label
    Public WithEvents _IM_Denkyu_0 As System.Windows.Forms.PictureBox
    Public WithEvents _FM_Panel3D1_28 As Label
    '2019/06/20 CHG END
    Public WithEvents TX_Mode As System.Windows.Forms.TextBox
	Public WithEvents _IM_Execute_1_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Execute_1_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Hardcopy_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Slist_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_EndCm_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_EndCm_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Slist_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Hardcopy_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_PREV_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_PREV_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_NEXTCM_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_NEXTCM_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_INSERTDE_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_INSERTDE_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_DELETEDE_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_DELETEDE_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Denkyu_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Denkyu_2 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_LCONFIG_1 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_LCONFIG_0 As System.Windows.Forms.PictureBox
	Public WithEvents _IM_Execute_0 As System.Windows.Forms.PictureBox
    Public WithEvents _IM_Execute_2 As System.Windows.Forms.PictureBox
    '2019/06/20 CHG START
    '   Public WithEvents _FM_Panel3D1_29 As SSPanel5
    'Public WithEvents TL_Cursol_Wk_2 As System.Windows.Forms.TextBox
    'Public WithEvents HD_Cursol_Wk_1 As System.Windows.Forms.TextBox
    'Public WithEvents CS_BINCD As SSCommand5
    'Public WithEvents HD_Cursol_Wk_2 As System.Windows.Forms.TextBox
    'Public WithEvents HD_Cursol_Wk_3 As System.Windows.Forms.TextBox
    'Public WithEvents _FM_Panel3D1_31 As SSPanel5
    Public WithEvents _FM_Panel3D1_29 As Label
    Public WithEvents TL_Cursol_Wk_2 As System.Windows.Forms.TextBox
    Public WithEvents HD_Cursol_Wk_1 As System.Windows.Forms.TextBox
    Public WithEvents CS_BINCD As Button
    Public WithEvents HD_Cursol_Wk_2 As System.Windows.Forms.TextBox
    Public WithEvents HD_Cursol_Wk_3 As System.Windows.Forms.TextBox
    Public WithEvents _FM_Panel3D1_31 As Label
    '2019/06/20 CHG END
    Public WithEvents HD_OPT3 As System.Windows.Forms.RadioButton
	Public WithEvents HD_OPT2 As System.Windows.Forms.RadioButton
    Public WithEvents HD_OPT1 As System.Windows.Forms.RadioButton
    '2019/06/21 CHG START
    '   Public WithEvents _FM_Panel3D1_32 As SSPanel5
    'Public WithEvents _FM_Panel3D1_33 As SSPanel5
    'Public WithEvents _FM_Panel3D1_34 As SSPanel5
    'Public WithEvents _FM_Panel3D1_8 As SSPanel5
    'Public WithEvents _FM_Panel3D1_35 As SSPanel5
    'Public WithEvents _FM_Panel3D1_36 As SSPanel5
    'Public WithEvents _FM_Panel3D1_37 As SSPanel5
    'Public WithEvents _FM_Panel3D1_38 As SSPanel5
    'Public WithEvents _FM_Panel3D1_39 As SSPanel5
    'Public WithEvents _FM_Panel3D1_40 As SSPanel5
    'Public WithEvents _FM_Panel3D1_41 As SSPanel5
    'Public WithEvents _FM_Panel3D1_42 As SSPanel5
    'Public WithEvents _FM_Panel3D1_43 As SSPanel5
    'Public WithEvents _FM_Panel3D1_44 As SSPanel5

    Public WithEvents _FM_Panel3D1_32 As Label
    Public WithEvents _FM_Panel3D1_33 As Label
    Public WithEvents _FM_Panel3D1_34 As Label
    Public WithEvents _FM_Panel3D1_8 As Label
    Public WithEvents _FM_Panel3D1_35 As Label
    Public WithEvents _FM_Panel3D1_36 As Label
    Public WithEvents _FM_Panel3D1_37 As Label
    Public WithEvents _FM_Panel3D1_38 As Label
    Public WithEvents _FM_Panel3D1_39 As Label
    Public WithEvents _FM_Panel3D1_40 As Label
    Public WithEvents _FM_Panel3D1_41 As Label
    Public WithEvents _FM_Panel3D1_42 As Label
    Public WithEvents _FM_Panel3D1_43 As Label
    Public WithEvents _FM_Panel3D1_44 As Label
    '2019/06/20 CHG END
    Public WithEvents BD_HINCD As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents BD_HINNMA As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents BD_HINNMB As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents BD_LINCMA As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents BD_LINCMB As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents BD_UNTNM As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents BD_UODSU As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    '2019/06/20 CHG START
    'Public WithEvents FM_Panel3D1 As SSPanel5Array
    Public WithEvents FM_Panel3D1 As VB6.LabelArray
    '2019/06/20 CHG END
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
    Public WithEvents Line1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    '2019/06/20 CHG START
    '   Public WithEvents MN_Execute As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_DeleteCM As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_HARDCOPY As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents bar11 As System.Windows.Forms.ToolStripSeparator
    'Public WithEvents MN_EndCm As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Ctrl As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_APPENDC As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_ClearItm As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_UnDoItem As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_ClearDE As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_DeleteDE As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_InsertDE As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_UnDoDe As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents Bar21 As System.Windows.Forms.ToolStripSeparator
    'Public WithEvents MN_Cut As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Copy As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Paste As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_EditMn As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Slist As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents MN_Oprt As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents SM_AllCopy As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents SM_FullPast As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents SM_Esc As System.Windows.Forms.ToolStripMenuItem
    'Public WithEvents SM_ShortCut As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MN_Execute As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_DeleteCM As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_HARDCOPY As System.Windows.Forms.ContextMenuStrip
    Public WithEvents bar11 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents MN_EndCm As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_Ctrl As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_APPENDC As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_ClearItm As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_UnDoItem As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_ClearDE As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_DeleteDE As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_InsertDE As System.Windows.Forms.ContextMenuStrip
    Public WithEvents MN_UnDoDe As System.Windows.Forms.ContextMenuStrip
    Public WithEvents Bar21 As System.Windows.Forms.ToolStripSeparator
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
    '2019/06/20 CHG END
    Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_SSSMAIN))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CS_UODSU = New System.Windows.Forms.Button()
        Me.HD_NHSZIPCD = New System.Windows.Forms.TextBox()
        Me.HD_NHSTL = New System.Windows.Forms.TextBox()
        Me.HD_NHSFAX = New System.Windows.Forms.TextBox()
        Me.HD_BINNM = New System.Windows.Forms.TextBox()
        Me.HD_BINCD = New System.Windows.Forms.TextBox()
        Me.HD_DENDT = New System.Windows.Forms.TextBox()
        Me.HD_NHSADC = New System.Windows.Forms.TextBox()
        Me.HD_NHSADB = New System.Windows.Forms.TextBox()
        Me.HD_NHSADA = New System.Windows.Forms.TextBox()
        Me.CS_HINCD = New System.Windows.Forms.Button()
        Me._FM_Panel3D1_14 = New System.Windows.Forms.Label()
        Me.TL_KKOUT = New System.Windows.Forms.CheckBox()
        Me._BD_UODSU_0 = New System.Windows.Forms.TextBox()
        Me._BD_HINNMA_0 = New System.Windows.Forms.TextBox()
        Me._BD_HINNMB_0 = New System.Windows.Forms.TextBox()
        Me._BD_UNTNM_0 = New System.Windows.Forms.TextBox()
        Me._BD_HINCD_0 = New System.Windows.Forms.TextBox()
        Me._BD_LINCMB_0 = New System.Windows.Forms.TextBox()
        Me._BD_LINCMA_0 = New System.Windows.Forms.TextBox()
        Me.HD_NHSNMB = New System.Windows.Forms.TextBox()
        Me.HD_NHSNMA = New System.Windows.Forms.TextBox()
        Me.HD_NHSCD = New System.Windows.Forms.TextBox()
        Me.HD_TANCD = New System.Windows.Forms.TextBox()
        Me.HD_BUMCD = New System.Windows.Forms.TextBox()
        Me.HD_TANNM = New System.Windows.Forms.TextBox()
        Me.HD_BUMNM = New System.Windows.Forms.TextBox()
        Me.HD_OUTRYCD = New System.Windows.Forms.TextBox()
        Me.HD_OUTRYNM = New System.Windows.Forms.TextBox()
        Me.HD_TOKCD = New System.Windows.Forms.TextBox()
        Me.HD_TOKRN = New System.Windows.Forms.TextBox()
        Me.HD_SBNNO = New System.Windows.Forms.TextBox()
        Me.HD_URIKJNNM = New System.Windows.Forms.TextBox()
        Me.HD_SOUCD = New System.Windows.Forms.TextBox()
        Me.HD_SOUNM = New System.Windows.Forms.TextBox()
        Me.HD_IN_TANNM = New System.Windows.Forms.TextBox()
        Me.HD_IN_TANCD = New System.Windows.Forms.TextBox()
        Me.HD_JDNNO = New System.Windows.Forms.TextBox()
        Me.TM_StartUp = New System.Windows.Forms.Timer(Me.components)
        Me.TX_CursorRest = New System.Windows.Forms.TextBox()
        Me._FM_Panel3D1_19 = New System.Windows.Forms.Label()
        Me.CS_REF_JDNNO = New System.Windows.Forms.Button()
        Me.CS_SOUCD = New System.Windows.Forms.Button()
        Me._FM_Panel3D1_3 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_2 = New System.Windows.Forms.Label()
        Me.CS_TOKCD = New System.Windows.Forms.Button()
        Me.CS_OUTRY = New System.Windows.Forms.Button()
        Me._FM_Panel3D1_24 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_25 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_26 = New System.Windows.Forms.Label()
        Me.CS_BUMCD = New System.Windows.Forms.Button()
        Me.CS_TANCD = New System.Windows.Forms.Button()
        Me._FM_Panel3D1_1 = New System.Windows.Forms.Label()
        Me.CS_NHSCD = New System.Windows.Forms.Button()
        Me._FM_Panel3D1_17 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_16 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_18 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_10 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_4 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_9 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_6 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_7 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_12 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_11 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_13 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_5 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_22 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_21 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_23 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_20 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_0 = New System.Windows.Forms.Label()
        Me.SYSDT = New System.Windows.Forms.Label()
        Me.CM_EndCm = New System.Windows.Forms.PictureBox()
        Me.CM_SLIST = New System.Windows.Forms.PictureBox()
        Me.CM_INSERTDE = New System.Windows.Forms.PictureBox()
        Me.CM_DELETEDE = New System.Windows.Forms.PictureBox()
        Me.CM_Execute = New System.Windows.Forms.PictureBox()
        Me.Image1 = New System.Windows.Forms.PictureBox()
        Me._FM_Panel3D1_15 = New System.Windows.Forms.Label()
        Me._Line1_0 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_30 = New System.Windows.Forms.Label()
        Me.CS_JDNDT = New System.Windows.Forms.Button()
        Me.CS_REF_SBN = New System.Windows.Forms.Button()
        Me._FM_Panel3D1_28 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_27 = New System.Windows.Forms.Label()
        Me.TX_Message = New System.Windows.Forms.TextBox()
        Me._IM_Denkyu_0 = New System.Windows.Forms.PictureBox()
        Me._FM_Panel3D1_29 = New System.Windows.Forms.Label()
        Me.TX_Mode = New System.Windows.Forms.TextBox()
        Me._IM_Execute_1_1 = New System.Windows.Forms.PictureBox()
        Me._IM_Execute_1_0 = New System.Windows.Forms.PictureBox()
        Me._IM_Hardcopy_1 = New System.Windows.Forms.PictureBox()
        Me._IM_Slist_1 = New System.Windows.Forms.PictureBox()
        Me._IM_EndCm_0 = New System.Windows.Forms.PictureBox()
        Me._IM_EndCm_1 = New System.Windows.Forms.PictureBox()
        Me._IM_Slist_0 = New System.Windows.Forms.PictureBox()
        Me._IM_Hardcopy_0 = New System.Windows.Forms.PictureBox()
        Me._IM_PREV_1 = New System.Windows.Forms.PictureBox()
        Me._IM_PREV_0 = New System.Windows.Forms.PictureBox()
        Me._IM_NEXTCM_0 = New System.Windows.Forms.PictureBox()
        Me._IM_NEXTCM_1 = New System.Windows.Forms.PictureBox()
        Me._IM_INSERTDE_0 = New System.Windows.Forms.PictureBox()
        Me._IM_INSERTDE_1 = New System.Windows.Forms.PictureBox()
        Me._IM_DELETEDE_0 = New System.Windows.Forms.PictureBox()
        Me._IM_DELETEDE_1 = New System.Windows.Forms.PictureBox()
        Me._IM_Denkyu_1 = New System.Windows.Forms.PictureBox()
        Me._IM_Denkyu_2 = New System.Windows.Forms.PictureBox()
        Me._IM_LCONFIG_1 = New System.Windows.Forms.PictureBox()
        Me._IM_LCONFIG_0 = New System.Windows.Forms.PictureBox()
        Me._IM_Execute_0 = New System.Windows.Forms.PictureBox()
        Me._IM_Execute_2 = New System.Windows.Forms.PictureBox()
        Me.TL_Cursol_Wk_2 = New System.Windows.Forms.TextBox()
        Me.HD_Cursol_Wk_1 = New System.Windows.Forms.TextBox()
        Me.CS_BINCD = New System.Windows.Forms.Button()
        Me.HD_Cursol_Wk_2 = New System.Windows.Forms.TextBox()
        Me.HD_Cursol_Wk_3 = New System.Windows.Forms.TextBox()
        Me._FM_Panel3D1_31 = New System.Windows.Forms.Label()
        Me.HD_OPT3 = New System.Windows.Forms.RadioButton()
        Me.HD_OPT2 = New System.Windows.Forms.RadioButton()
        Me.HD_OPT1 = New System.Windows.Forms.RadioButton()
        Me._FM_Panel3D1_32 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_33 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_34 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_8 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_35 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_36 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_37 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_38 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_39 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_40 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_41 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_42 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_43 = New System.Windows.Forms.Label()
        Me._FM_Panel3D1_44 = New System.Windows.Forms.Label()
        Me.BD_HINCD = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_HINNMA = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_HINNMB = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_LINCMA = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_LINCMB = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_UNTNM = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.BD_UODSU = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
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
        Me.Line1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.MN_Ctrl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_Execute = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_DeleteCM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MN_HARDCOPY = New System.Windows.Forms.ContextMenuStrip(Me.components)
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._FM_Panel3D1_0.SuspendLayout()
        CType(Me.CM_EndCm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_SLIST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_INSERTDE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_DELETEDE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CM_Execute, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._FM_Panel3D1_15.SuspendLayout()
        Me._FM_Panel3D1_28.SuspendLayout()
        Me._FM_Panel3D1_27.SuspendLayout()
        CType(Me._IM_Denkyu_0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._FM_Panel3D1_29.SuspendLayout()
        CType(Me._IM_Execute_1_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Execute_1_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Hardcopy_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Slist_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_EndCm_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_EndCm_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Slist_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Hardcopy_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_PREV_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_PREV_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_NEXTCM_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_NEXTCM_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_INSERTDE_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_INSERTDE_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_DELETEDE_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_DELETEDE_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Denkyu_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Denkyu_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_LCONFIG_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_LCONFIG_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Execute_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._IM_Execute_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_HINCD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_HINNMA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_HINNMB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_LINCMA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_LINCMB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_UNTNM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD_UODSU, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.Line1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Label1.SuspendLayout()
        Me.Label2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CS_UODSU
        '
        Me.CS_UODSU.CausesValidation = False
        Me.CS_UODSU.Location = New System.Drawing.Point(449, 395)
        Me.CS_UODSU.Name = "CS_UODSU"
        Me.CS_UODSU.Size = New System.Drawing.Size(65, 47)
        Me.CS_UODSU.TabIndex = 92
        Me.CS_UODSU.TabStop = False
        Me.CS_UODSU.Text = " 数　量"
        '
        'HD_NHSZIPCD
        '
        Me.HD_NHSZIPCD.AcceptsReturn = True
        Me.HD_NHSZIPCD.BackColor = System.Drawing.Color.White
        Me.HD_NHSZIPCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_NHSZIPCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_NHSZIPCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_NHSZIPCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_NHSZIPCD.Location = New System.Drawing.Point(677, 259)
        Me.HD_NHSZIPCD.MaxLength = 40
        Me.HD_NHSZIPCD.Multiline = True
        Me.HD_NHSZIPCD.Name = "HD_NHSZIPCD"
        Me.HD_NHSZIPCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_NHSZIPCD.Size = New System.Drawing.Size(79, 45)
        Me.HD_NHSZIPCD.TabIndex = 88
        Me.HD_NHSZIPCD.Text = "XXXXXXX2"
        '
        'HD_NHSTL
        '
        Me.HD_NHSTL.AcceptsReturn = True
        Me.HD_NHSTL.BackColor = System.Drawing.Color.White
        Me.HD_NHSTL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_NHSTL.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_NHSTL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_NHSTL.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_NHSTL.Location = New System.Drawing.Point(439, 261)
        Me.HD_NHSTL.MaxLength = 20
        Me.HD_NHSTL.Name = "HD_NHSTL"
        Me.HD_NHSTL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_NHSTL.Size = New System.Drawing.Size(150, 20)
        Me.HD_NHSTL.TabIndex = 87
        Me.HD_NHSTL.Text = "XXXXXXXXX1XXXXXXXXX2"
        '
        'HD_NHSFAX
        '
        Me.HD_NHSFAX.AcceptsReturn = True
        Me.HD_NHSFAX.BackColor = System.Drawing.Color.White
        Me.HD_NHSFAX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_NHSFAX.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_NHSFAX.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_NHSFAX.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_NHSFAX.Location = New System.Drawing.Point(439, 284)
        Me.HD_NHSFAX.MaxLength = 20
        Me.HD_NHSFAX.Name = "HD_NHSFAX"
        Me.HD_NHSFAX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_NHSFAX.Size = New System.Drawing.Size(150, 20)
        Me.HD_NHSFAX.TabIndex = 86
        Me.HD_NHSFAX.Text = "XXXXXXXXX1XXXXXXXXX2"
        '
        'HD_BINNM
        '
        Me.HD_BINNM.AcceptsReturn = True
        Me.HD_BINNM.BackColor = System.Drawing.SystemColors.Control
        Me.HD_BINNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_BINNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_BINNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_BINNM.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_BINNM.Location = New System.Drawing.Point(461, 371)
        Me.HD_BINNM.MaxLength = 30
        Me.HD_BINNM.Name = "HD_BINNM"
        Me.HD_BINNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_BINNM.Size = New System.Drawing.Size(75, 20)
        Me.HD_BINNM.TabIndex = 79
        Me.HD_BINNM.Text = "MMMMMMMMM1"
        '
        'HD_BINCD
        '
        Me.HD_BINCD.AcceptsReturn = True
        Me.HD_BINCD.BackColor = System.Drawing.Color.White
        Me.HD_BINCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_BINCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_BINCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_BINCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_BINCD.Location = New System.Drawing.Point(439, 371)
        Me.HD_BINCD.MaxLength = 10
        Me.HD_BINCD.Name = "HD_BINCD"
        Me.HD_BINCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_BINCD.Size = New System.Drawing.Size(22, 20)
        Me.HD_BINCD.TabIndex = 78
        Me.HD_BINCD.Text = "12"
        '
        'HD_DENDT
        '
        Me.HD_DENDT.AcceptsReturn = True
        Me.HD_DENDT.BackColor = System.Drawing.Color.White
        Me.HD_DENDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_DENDT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_DENDT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_DENDT.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.HD_DENDT.Location = New System.Drawing.Point(137, 71)
        Me.HD_DENDT.MaxLength = 14
        Me.HD_DENDT.Name = "HD_DENDT"
        Me.HD_DENDT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_DENDT.Size = New System.Drawing.Size(98, 20)
        Me.HD_DENDT.TabIndex = 74
        Me.HD_DENDT.Text = "9999/99/99"
        '
        'HD_NHSADC
        '
        Me.HD_NHSADC.AcceptsReturn = True
        Me.HD_NHSADC.BackColor = System.Drawing.Color.White
        Me.HD_NHSADC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_NHSADC.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_NHSADC.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_NHSADC.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_NHSADC.Location = New System.Drawing.Point(439, 350)
        Me.HD_NHSADC.MaxLength = 60
        Me.HD_NHSADC.Name = "HD_NHSADC"
        Me.HD_NHSADC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_NHSADC.Size = New System.Drawing.Size(368, 20)
        Me.HD_NHSADC.TabIndex = 72
        Me.HD_NHSADC.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5"
        '
        'HD_NHSADB
        '
        Me.HD_NHSADB.AcceptsReturn = True
        Me.HD_NHSADB.BackColor = System.Drawing.Color.White
        Me.HD_NHSADB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_NHSADB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_NHSADB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_NHSADB.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_NHSADB.Location = New System.Drawing.Point(439, 329)
        Me.HD_NHSADB.MaxLength = 60
        Me.HD_NHSADB.Name = "HD_NHSADB"
        Me.HD_NHSADB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_NHSADB.Size = New System.Drawing.Size(368, 20)
        Me.HD_NHSADB.TabIndex = 71
        Me.HD_NHSADB.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5"
        '
        'HD_NHSADA
        '
        Me.HD_NHSADA.AcceptsReturn = True
        Me.HD_NHSADA.BackColor = System.Drawing.Color.White
        Me.HD_NHSADA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_NHSADA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_NHSADA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_NHSADA.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_NHSADA.Location = New System.Drawing.Point(439, 308)
        Me.HD_NHSADA.MaxLength = 60
        Me.HD_NHSADA.Name = "HD_NHSADA"
        Me.HD_NHSADA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_NHSADA.Size = New System.Drawing.Size(368, 20)
        Me.HD_NHSADA.TabIndex = 70
        Me.HD_NHSADA.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5"
        '
        'CS_HINCD
        '
        Me.CS_HINCD.Location = New System.Drawing.Point(135, 242)
        Me.CS_HINCD.Name = "CS_HINCD"
        Me.CS_HINCD.Size = New System.Drawing.Size(91, 45)
        Me.CS_HINCD.TabIndex = 49
        Me.CS_HINCD.TabStop = False
        Me.CS_HINCD.Text = " 製品ｺｰﾄﾞ"
        Me.CS_HINCD.Visible = False
        '
        '_FM_Panel3D1_14
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_14, CType(14, Short))
        Me._FM_Panel3D1_14.Location = New System.Drawing.Point(254, 585)
        Me._FM_Panel3D1_14.Name = "_FM_Panel3D1_14"
        Me._FM_Panel3D1_14.Size = New System.Drawing.Size(67, 24)
        Me._FM_Panel3D1_14.TabIndex = 55
        Me._FM_Panel3D1_14.Text = "(仕切差)"
        '
        'TL_KKOUT
        '
        Me.TL_KKOUT.BackColor = System.Drawing.SystemColors.Control
        Me.TL_KKOUT.Cursor = System.Windows.Forms.Cursors.Default
        Me.TL_KKOUT.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TL_KKOUT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TL_KKOUT.Location = New System.Drawing.Point(357, 129)
        Me.TL_KKOUT.Name = "TL_KKOUT"
        Me.TL_KKOUT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TL_KKOUT.Size = New System.Drawing.Size(101, 24)
        Me.TL_KKOUT.TabIndex = 69
        Me.TL_KKOUT.TabStop = False
        Me.TL_KKOUT.Text = "緊急出庫"
        Me.TL_KKOUT.UseVisualStyleBackColor = False
        '
        '_BD_UODSU_0
        '
        Me._BD_UODSU_0.AcceptsReturn = True
        Me._BD_UODSU_0.BackColor = System.Drawing.Color.White
        Me._BD_UODSU_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_UODSU_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_UODSU_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._BD_UODSU_0.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.BD_UODSU.SetIndex(Me._BD_UODSU_0, CType(0, Short))
        Me._BD_UODSU_0.Location = New System.Drawing.Point(450, 440)
        Me._BD_UODSU_0.MaxLength = 8
        Me._BD_UODSU_0.Name = "_BD_UODSU_0"
        Me._BD_UODSU_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_UODSU_0.Size = New System.Drawing.Size(64, 20)
        Me._BD_UODSU_0.TabIndex = 42
        Me._BD_UODSU_0.Text = "-999,999"
        Me._BD_UODSU_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_BD_HINNMA_0
        '
        Me._BD_HINNMA_0.AcceptsReturn = True
        Me._BD_HINNMA_0.BackColor = System.Drawing.SystemColors.Control
        Me._BD_HINNMA_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_HINNMA_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_HINNMA_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._BD_HINNMA_0.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.BD_HINNMA.SetIndex(Me._BD_HINNMA_0, CType(0, Short))
        Me._BD_HINNMA_0.Location = New System.Drawing.Point(117, 440)
        Me._BD_HINNMA_0.MaxLength = 30
        Me._BD_HINNMA_0.Name = "_BD_HINNMA_0"
        Me._BD_HINNMA_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_HINNMA_0.Size = New System.Drawing.Size(333, 20)
        Me._BD_HINNMA_0.TabIndex = 41
        Me._BD_HINNMA_0.Text = "XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3"
        '
        '_BD_HINNMB_0
        '
        Me._BD_HINNMB_0.AcceptsReturn = True
        Me._BD_HINNMB_0.BackColor = System.Drawing.SystemColors.Control
        Me._BD_HINNMB_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_HINNMB_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_HINNMB_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._BD_HINNMB_0.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.BD_HINNMB.SetIndex(Me._BD_HINNMB_0, CType(0, Short))
        Me._BD_HINNMB_0.Location = New System.Drawing.Point(117, 462)
        Me._BD_HINNMB_0.MaxLength = 30
        Me._BD_HINNMB_0.Name = "_BD_HINNMB_0"
        Me._BD_HINNMB_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_HINNMB_0.Size = New System.Drawing.Size(333, 20)
        Me._BD_HINNMB_0.TabIndex = 40
        Me._BD_HINNMB_0.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3"
        '
        '_BD_UNTNM_0
        '
        Me._BD_UNTNM_0.AcceptsReturn = True
        Me._BD_UNTNM_0.BackColor = System.Drawing.SystemColors.Control
        Me._BD_UNTNM_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_UNTNM_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_UNTNM_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._BD_UNTNM_0.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.BD_UNTNM.SetIndex(Me._BD_UNTNM_0, CType(0, Short))
        Me._BD_UNTNM_0.Location = New System.Drawing.Point(514, 440)
        Me._BD_UNTNM_0.MaxLength = 8
        Me._BD_UNTNM_0.Name = "_BD_UNTNM_0"
        Me._BD_UNTNM_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_UNTNM_0.Size = New System.Drawing.Size(38, 20)
        Me._BD_UNTNM_0.TabIndex = 39
        Me._BD_UNTNM_0.Text = "MMM4"
        '
        '_BD_HINCD_0
        '
        Me._BD_HINCD_0.AcceptsReturn = True
        Me._BD_HINCD_0.BackColor = System.Drawing.Color.White
        Me._BD_HINCD_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._BD_HINCD_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._BD_HINCD_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._BD_HINCD_0.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.BD_HINCD.SetIndex(Me._BD_HINCD_0, CType(0, Short))
        Me._BD_HINCD_0.Location = New System.Drawing.Point(26, 440)
        Me._BD_HINCD_0.MaxLength = 17
        Me._BD_HINCD_0.Name = "_BD_HINCD_0"
        Me._BD_HINCD_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_HINCD_0.Size = New System.Drawing.Size(91, 20)
        Me._BD_HINCD_0.TabIndex = 38
        Me._BD_HINCD_0.Text = "XXXXXXXX10"
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
        Me._BD_LINCMB_0.Location = New System.Drawing.Point(551, 462)
        Me._BD_LINCMB_0.MaxLength = 24
        Me._BD_LINCMB_0.Name = "_BD_LINCMB_0"
        Me._BD_LINCMB_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_LINCMB_0.Size = New System.Drawing.Size(151, 20)
        Me._BD_LINCMB_0.TabIndex = 37
        Me._BD_LINCMB_0.Text = "MMMMMMMMM1MMMMMMMMM2"
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
        Me._BD_LINCMA_0.Location = New System.Drawing.Point(551, 440)
        Me._BD_LINCMA_0.MaxLength = 24
        Me._BD_LINCMA_0.Name = "_BD_LINCMA_0"
        Me._BD_LINCMA_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BD_LINCMA_0.Size = New System.Drawing.Size(151, 20)
        Me._BD_LINCMA_0.TabIndex = 36
        Me._BD_LINCMA_0.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'HD_NHSNMB
        '
        Me.HD_NHSNMB.AcceptsReturn = True
        Me.HD_NHSNMB.BackColor = System.Drawing.SystemColors.Control
        Me.HD_NHSNMB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_NHSNMB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_NHSNMB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_NHSNMB.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_NHSNMB.Location = New System.Drawing.Point(518, 237)
        Me.HD_NHSNMB.MaxLength = 40
        Me.HD_NHSNMB.Name = "HD_NHSNMB"
        Me.HD_NHSNMB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_NHSNMB.Size = New System.Drawing.Size(290, 20)
        Me.HD_NHSNMB.TabIndex = 31
        Me.HD_NHSNMB.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
        '
        'HD_NHSNMA
        '
        Me.HD_NHSNMA.AcceptsReturn = True
        Me.HD_NHSNMA.BackColor = System.Drawing.SystemColors.Control
        Me.HD_NHSNMA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_NHSNMA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_NHSNMA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_NHSNMA.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_NHSNMA.Location = New System.Drawing.Point(518, 215)
        Me.HD_NHSNMA.MaxLength = 40
        Me.HD_NHSNMA.Name = "HD_NHSNMA"
        Me.HD_NHSNMA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_NHSNMA.Size = New System.Drawing.Size(290, 20)
        Me.HD_NHSNMA.TabIndex = 30
        Me.HD_NHSNMA.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
        '
        'HD_NHSCD
        '
        Me.HD_NHSCD.AcceptsReturn = True
        Me.HD_NHSCD.BackColor = System.Drawing.Color.White
        Me.HD_NHSCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_NHSCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_NHSCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_NHSCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_NHSCD.Location = New System.Drawing.Point(439, 214)
        Me.HD_NHSCD.MaxLength = 9
        Me.HD_NHSCD.Multiline = True
        Me.HD_NHSCD.Name = "HD_NHSCD"
        Me.HD_NHSCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_NHSCD.Size = New System.Drawing.Size(79, 45)
        Me.HD_NHSCD.TabIndex = 29
        Me.HD_NHSCD.Text = "XXXXXXXX9"
        '
        'HD_TANCD
        '
        Me.HD_TANCD.AcceptsReturn = True
        Me.HD_TANCD.BackColor = System.Drawing.Color.White
        Me.HD_TANCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TANCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TANCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TANCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_TANCD.Location = New System.Drawing.Point(136, 192)
        Me.HD_TANCD.MaxLength = 6
        Me.HD_TANCD.Name = "HD_TANCD"
        Me.HD_TANCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TANCD.Size = New System.Drawing.Size(48, 20)
        Me.HD_TANCD.TabIndex = 25
        Me.HD_TANCD.Text = "XXXXX6"
        '
        'HD_BUMCD
        '
        Me.HD_BUMCD.AcceptsReturn = True
        Me.HD_BUMCD.BackColor = System.Drawing.Color.White
        Me.HD_BUMCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_BUMCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_BUMCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_BUMCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_BUMCD.Location = New System.Drawing.Point(136, 217)
        Me.HD_BUMCD.MaxLength = 6
        Me.HD_BUMCD.Name = "HD_BUMCD"
        Me.HD_BUMCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_BUMCD.Size = New System.Drawing.Size(48, 20)
        Me.HD_BUMCD.TabIndex = 24
        Me.HD_BUMCD.Text = "XXXXX6"
        '
        'HD_TANNM
        '
        Me.HD_TANNM.AcceptsReturn = True
        Me.HD_TANNM.BackColor = System.Drawing.SystemColors.Control
        Me.HD_TANNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TANNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TANNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TANNM.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_TANNM.Location = New System.Drawing.Point(183, 192)
        Me.HD_TANNM.MaxLength = 20
        Me.HD_TANNM.Name = "HD_TANNM"
        Me.HD_TANNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TANNM.Size = New System.Drawing.Size(158, 20)
        Me.HD_TANNM.TabIndex = 23
        Me.HD_TANNM.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'HD_BUMNM
        '
        Me.HD_BUMNM.AcceptsReturn = True
        Me.HD_BUMNM.BackColor = System.Drawing.SystemColors.Control
        Me.HD_BUMNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_BUMNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_BUMNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_BUMNM.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_BUMNM.Location = New System.Drawing.Point(183, 217)
        Me.HD_BUMNM.MaxLength = 20
        Me.HD_BUMNM.Name = "HD_BUMNM"
        Me.HD_BUMNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_BUMNM.Size = New System.Drawing.Size(158, 20)
        Me.HD_BUMNM.TabIndex = 22
        Me.HD_BUMNM.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'HD_OUTRYCD
        '
        Me.HD_OUTRYCD.AcceptsReturn = True
        Me.HD_OUTRYCD.BackColor = System.Drawing.Color.White
        Me.HD_OUTRYCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_OUTRYCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_OUTRYCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_OUTRYCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_OUTRYCD.Location = New System.Drawing.Point(137, 96)
        Me.HD_OUTRYCD.MaxLength = 2
        Me.HD_OUTRYCD.Name = "HD_OUTRYCD"
        Me.HD_OUTRYCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_OUTRYCD.Size = New System.Drawing.Size(28, 20)
        Me.HD_OUTRYCD.TabIndex = 0
        Me.HD_OUTRYCD.Text = "12"
        '
        'HD_OUTRYNM
        '
        Me.HD_OUTRYNM.AcceptsReturn = True
        Me.HD_OUTRYNM.BackColor = System.Drawing.SystemColors.Control
        Me.HD_OUTRYNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_OUTRYNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_OUTRYNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_OUTRYNM.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_OUTRYNM.Location = New System.Drawing.Point(164, 96)
        Me.HD_OUTRYNM.MaxLength = 20
        Me.HD_OUTRYNM.Name = "HD_OUTRYNM"
        Me.HD_OUTRYNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_OUTRYNM.Size = New System.Drawing.Size(147, 20)
        Me.HD_OUTRYNM.TabIndex = 17
        Me.HD_OUTRYNM.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'HD_TOKCD
        '
        Me.HD_TOKCD.AcceptsReturn = True
        Me.HD_TOKCD.BackColor = System.Drawing.Color.White
        Me.HD_TOKCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TOKCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TOKCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TOKCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_TOKCD.Location = New System.Drawing.Point(439, 191)
        Me.HD_TOKCD.MaxLength = 7
        Me.HD_TOKCD.Name = "HD_TOKCD"
        Me.HD_TOKCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TOKCD.Size = New System.Drawing.Size(79, 20)
        Me.HD_TOKCD.TabIndex = 15
        Me.HD_TOKCD.Text = "XXXX5"
        '
        'HD_TOKRN
        '
        Me.HD_TOKRN.AcceptsReturn = True
        Me.HD_TOKRN.BackColor = System.Drawing.SystemColors.Control
        Me.HD_TOKRN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_TOKRN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_TOKRN.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_TOKRN.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_TOKRN.Location = New System.Drawing.Point(518, 191)
        Me.HD_TOKRN.MaxLength = 40
        Me.HD_TOKRN.Name = "HD_TOKRN"
        Me.HD_TOKRN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_TOKRN.Size = New System.Drawing.Size(290, 20)
        Me.HD_TOKRN.TabIndex = 14
        Me.HD_TOKRN.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
        '
        'HD_SBNNO
        '
        Me.HD_SBNNO.AcceptsReturn = True
        Me.HD_SBNNO.BackColor = System.Drawing.Color.White
        Me.HD_SBNNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_SBNNO.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_SBNNO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_SBNNO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_SBNNO.Location = New System.Drawing.Point(137, 143)
        Me.HD_SBNNO.MaxLength = 10
        Me.HD_SBNNO.Name = "HD_SBNNO"
        Me.HD_SBNNO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_SBNNO.Size = New System.Drawing.Size(81, 20)
        Me.HD_SBNNO.TabIndex = 11
        Me.HD_SBNNO.Text = "XXXXXXXXX1"
        '
        'HD_URIKJNNM
        '
        Me.HD_URIKJNNM.AcceptsReturn = True
        Me.HD_URIKJNNM.BackColor = System.Drawing.SystemColors.Control
        Me.HD_URIKJNNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_URIKJNNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_URIKJNNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_URIKJNNM.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_URIKJNNM.Location = New System.Drawing.Point(1036, 338)
        Me.HD_URIKJNNM.MaxLength = 20
        Me.HD_URIKJNNM.Name = "HD_URIKJNNM"
        Me.HD_URIKJNNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_URIKJNNM.Size = New System.Drawing.Size(158, 20)
        Me.HD_URIKJNNM.TabIndex = 10
        Me.HD_URIKJNNM.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'HD_SOUCD
        '
        Me.HD_SOUCD.AcceptsReturn = True
        Me.HD_SOUCD.BackColor = System.Drawing.Color.White
        Me.HD_SOUCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_SOUCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_SOUCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_SOUCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_SOUCD.Location = New System.Drawing.Point(137, 168)
        Me.HD_SOUCD.MaxLength = 3
        Me.HD_SOUCD.Name = "HD_SOUCD"
        Me.HD_SOUCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_SOUCD.Size = New System.Drawing.Size(48, 20)
        Me.HD_SOUCD.TabIndex = 8
        Me.HD_SOUCD.Text = "123"
        '
        'HD_SOUNM
        '
        Me.HD_SOUNM.AcceptsReturn = True
        Me.HD_SOUNM.BackColor = System.Drawing.SystemColors.Control
        Me.HD_SOUNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_SOUNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_SOUNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_SOUNM.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_SOUNM.Location = New System.Drawing.Point(184, 168)
        Me.HD_SOUNM.MaxLength = 20
        Me.HD_SOUNM.Name = "HD_SOUNM"
        Me.HD_SOUNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_SOUNM.Size = New System.Drawing.Size(158, 20)
        Me.HD_SOUNM.TabIndex = 7
        Me.HD_SOUNM.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'HD_IN_TANNM
        '
        Me.HD_IN_TANNM.AcceptsReturn = True
        Me.HD_IN_TANNM.BackColor = System.Drawing.SystemColors.Control
        Me.HD_IN_TANNM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_IN_TANNM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_IN_TANNM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_IN_TANNM.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.HD_IN_TANNM.Location = New System.Drawing.Point(613, 68)
        Me.HD_IN_TANNM.MaxLength = 30
        Me.HD_IN_TANNM.Name = "HD_IN_TANNM"
        Me.HD_IN_TANNM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_IN_TANNM.Size = New System.Drawing.Size(147, 20)
        Me.HD_IN_TANNM.TabIndex = 6
        Me.HD_IN_TANNM.Text = "MMMMMMMMM1MMMMMMMMM2"
        '
        'HD_IN_TANCD
        '
        Me.HD_IN_TANCD.AcceptsReturn = True
        Me.HD_IN_TANCD.BackColor = System.Drawing.SystemColors.Control
        Me.HD_IN_TANCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_IN_TANCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_IN_TANCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_IN_TANCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_IN_TANCD.Location = New System.Drawing.Point(566, 68)
        Me.HD_IN_TANCD.MaxLength = 10
        Me.HD_IN_TANCD.Name = "HD_IN_TANCD"
        Me.HD_IN_TANCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_IN_TANCD.Size = New System.Drawing.Size(48, 20)
        Me.HD_IN_TANCD.TabIndex = 5
        Me.HD_IN_TANCD.Text = "XXXXX6"
        '
        'HD_JDNNO
        '
        Me.HD_JDNNO.AcceptsReturn = True
        Me.HD_JDNNO.BackColor = System.Drawing.Color.White
        Me.HD_JDNNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_JDNNO.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_JDNNO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_JDNNO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_JDNNO.Location = New System.Drawing.Point(137, 120)
        Me.HD_JDNNO.MaxLength = 8
        Me.HD_JDNNO.Name = "HD_JDNNO"
        Me.HD_JDNNO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_JDNNO.Size = New System.Drawing.Size(81, 20)
        Me.HD_JDNNO.TabIndex = 3
        Me.HD_JDNNO.TabStop = False
        Me.HD_JDNNO.Text = "XXXXXXX8"
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
        Me.TX_CursorRest.Location = New System.Drawing.Point(2810, 299)
        Me.TX_CursorRest.MaxLength = 0
        Me.TX_CursorRest.Name = "TX_CursorRest"
        Me.TX_CursorRest.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_CursorRest.Size = New System.Drawing.Size(22, 13)
        Me.TX_CursorRest.TabIndex = 2
        '
        '_FM_Panel3D1_19
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_19, CType(19, Short))
        Me._FM_Panel3D1_19.Location = New System.Drawing.Point(158, 643)
        Me._FM_Panel3D1_19.Name = "_FM_Panel3D1_19"
        Me._FM_Panel3D1_19.Size = New System.Drawing.Size(104, 23)
        Me._FM_Panel3D1_19.TabIndex = 1
        Me._FM_Panel3D1_19.Text = " 備考"
        '
        'CS_REF_JDNNO
        '
        Me.CS_REF_JDNNO.Location = New System.Drawing.Point(15, 286)
        Me.CS_REF_JDNNO.Name = "CS_REF_JDNNO"
        Me.CS_REF_JDNNO.Size = New System.Drawing.Size(120, 23)
        Me.CS_REF_JDNNO.TabIndex = 4
        Me.CS_REF_JDNNO.TabStop = False
        Me.CS_REF_JDNNO.Text = "  参照受注番号  "
        Me.CS_REF_JDNNO.Visible = False
        '
        'CS_SOUCD
        '
        Me.CS_SOUCD.Location = New System.Drawing.Point(199, 289)
        Me.CS_SOUCD.Name = "CS_SOUCD"
        Me.CS_SOUCD.Size = New System.Drawing.Size(120, 23)
        Me.CS_SOUCD.TabIndex = 9
        Me.CS_SOUCD.TabStop = False
        Me.CS_SOUCD.Text = "倉庫コード　"
        Me.CS_SOUCD.Visible = False
        '
        '_FM_Panel3D1_3
        '
        Me._FM_Panel3D1_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_3, CType(3, Short))
        Me._FM_Panel3D1_3.Location = New System.Drawing.Point(17, 143)
        Me._FM_Panel3D1_3.Name = "_FM_Panel3D1_3"
        Me._FM_Panel3D1_3.Size = New System.Drawing.Size(120, 23)
        Me._FM_Panel3D1_3.TabIndex = 12
        Me._FM_Panel3D1_3.Text = "  製　番"
        '
        '_FM_Panel3D1_2
        '
        Me._FM_Panel3D1_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_2, CType(2, Short))
        Me._FM_Panel3D1_2.Location = New System.Drawing.Point(467, 68)
        Me._FM_Panel3D1_2.Name = "_FM_Panel3D1_2"
        Me._FM_Panel3D1_2.Size = New System.Drawing.Size(99, 20)
        Me._FM_Panel3D1_2.TabIndex = 13
        Me._FM_Panel3D1_2.Text = " 入力担当者"
        '
        'CS_TOKCD
        '
        Me.CS_TOKCD.Location = New System.Drawing.Point(199, 312)
        Me.CS_TOKCD.Name = "CS_TOKCD"
        Me.CS_TOKCD.Size = New System.Drawing.Size(86, 23)
        Me.CS_TOKCD.TabIndex = 16
        Me.CS_TOKCD.TabStop = False
        Me.CS_TOKCD.Text = "  得意先    "
        Me.CS_TOKCD.Visible = False
        '
        'CS_OUTRY
        '
        Me.CS_OUTRY.Location = New System.Drawing.Point(15, 263)
        Me.CS_OUTRY.Name = "CS_OUTRY"
        Me.CS_OUTRY.Size = New System.Drawing.Size(120, 23)
        Me.CS_OUTRY.TabIndex = 18
        Me.CS_OUTRY.TabStop = False
        Me.CS_OUTRY.Text = "  処理理由　   "
        Me.CS_OUTRY.Visible = False
        '
        '_FM_Panel3D1_24
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_24, CType(24, Short))
        Me._FM_Panel3D1_24.Location = New System.Drawing.Point(496, 561)
        Me._FM_Panel3D1_24.Name = "_FM_Panel3D1_24"
        Me._FM_Panel3D1_24.Size = New System.Drawing.Size(106, 23)
        Me._FM_Panel3D1_24.TabIndex = 19
        Me._FM_Panel3D1_24.Text = " 与信限度額"
        '
        '_FM_Panel3D1_25
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_25, CType(25, Short))
        Me._FM_Panel3D1_25.Location = New System.Drawing.Point(499, 588)
        Me._FM_Panel3D1_25.Name = "_FM_Panel3D1_25"
        Me._FM_Panel3D1_25.Size = New System.Drawing.Size(106, 23)
        Me._FM_Panel3D1_25.TabIndex = 20
        Me._FM_Panel3D1_25.Text = " 受注残ほか"
        '
        '_FM_Panel3D1_26
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_26, CType(26, Short))
        Me._FM_Panel3D1_26.Location = New System.Drawing.Point(501, 613)
        Me._FM_Panel3D1_26.Name = "_FM_Panel3D1_26"
        Me._FM_Panel3D1_26.Size = New System.Drawing.Size(106, 23)
        Me._FM_Panel3D1_26.TabIndex = 21
        Me._FM_Panel3D1_26.Text = " 受注可能額"
        '
        'CS_BUMCD
        '
        Me.CS_BUMCD.Location = New System.Drawing.Point(14, 332)
        Me.CS_BUMCD.Name = "CS_BUMCD"
        Me.CS_BUMCD.Size = New System.Drawing.Size(120, 23)
        Me.CS_BUMCD.TabIndex = 26
        Me.CS_BUMCD.TabStop = False
        Me.CS_BUMCD.Text = " 送り先部門  "
        Me.CS_BUMCD.Visible = False
        '
        'CS_TANCD
        '
        Me.CS_TANCD.Location = New System.Drawing.Point(14, 310)
        Me.CS_TANCD.Name = "CS_TANCD"
        Me.CS_TANCD.Size = New System.Drawing.Size(120, 23)
        Me.CS_TANCD.TabIndex = 27
        Me.CS_TANCD.TabStop = False
        Me.CS_TANCD.Text = " 送り先担当者"
        Me.CS_TANCD.Visible = False
        '
        '_FM_Panel3D1_1
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_1, CType(1, Short))
        Me._FM_Panel3D1_1.Location = New System.Drawing.Point(296, 559)
        Me._FM_Panel3D1_1.Name = "_FM_Panel3D1_1"
        Me._FM_Panel3D1_1.Size = New System.Drawing.Size(83, 23)
        Me._FM_Panel3D1_1.TabIndex = 28
        Me._FM_Panel3D1_1.Text = " 分類型式"
        '
        'CS_NHSCD
        '
        Me.CS_NHSCD.Location = New System.Drawing.Point(227, 242)
        Me.CS_NHSCD.Name = "CS_NHSCD"
        Me.CS_NHSCD.Size = New System.Drawing.Size(86, 45)
        Me.CS_NHSCD.TabIndex = 32
        Me.CS_NHSCD.TabStop = False
        Me.CS_NHSCD.Text = "  納入先    "
        Me.CS_NHSCD.Visible = False
        '
        '_FM_Panel3D1_17
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_17, CType(17, Short))
        Me._FM_Panel3D1_17.Location = New System.Drawing.Point(79, 583)
        Me._FM_Panel3D1_17.Name = "_FM_Panel3D1_17"
        Me._FM_Panel3D1_17.Size = New System.Drawing.Size(67, 67)
        Me._FM_Panel3D1_17.TabIndex = 33
        Me._FM_Panel3D1_17.Text = " 住所   "
        '
        '_FM_Panel3D1_16
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_16, CType(16, Short))
        Me._FM_Panel3D1_16.Location = New System.Drawing.Point(2, 608)
        Me._FM_Panel3D1_16.Name = "_FM_Panel3D1_16"
        Me._FM_Panel3D1_16.Size = New System.Drawing.Size(67, 45)
        Me._FM_Panel3D1_16.TabIndex = 34
        Me._FM_Panel3D1_16.Text = " 件名"
        '
        '_FM_Panel3D1_18
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_18, CType(18, Short))
        Me._FM_Panel3D1_18.Location = New System.Drawing.Point(374, 622)
        Me._FM_Panel3D1_18.Name = "_FM_Panel3D1_18"
        Me._FM_Panel3D1_18.Size = New System.Drawing.Size(104, 23)
        Me._FM_Panel3D1_18.TabIndex = 35
        Me._FM_Panel3D1_18.Text = " ﾀﾞｲﾌｸ受注番号"
        '
        '_FM_Panel3D1_10
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_10, CType(10, Short))
        Me._FM_Panel3D1_10.Location = New System.Drawing.Point(127, 555)
        Me._FM_Panel3D1_10.Name = "_FM_Panel3D1_10"
        Me._FM_Panel3D1_10.Size = New System.Drawing.Size(88, 24)
        Me._FM_Panel3D1_10.TabIndex = 43
        Me._FM_Panel3D1_10.Text = "営業仕切"
        '
        '_FM_Panel3D1_4
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_4, CType(4, Short))
        Me._FM_Panel3D1_4.Location = New System.Drawing.Point(4, 559)
        Me._FM_Panel3D1_4.Name = "_FM_Panel3D1_4"
        Me._FM_Panel3D1_4.Size = New System.Drawing.Size(27, 46)
        Me._FM_Panel3D1_4.TabIndex = 44
        Me._FM_Panel3D1_4.Text = "No"
        '
        '_FM_Panel3D1_9
        '
        Me._FM_Panel3D1_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_9, CType(9, Short))
        Me._FM_Panel3D1_9.Location = New System.Drawing.Point(513, 395)
        Me._FM_Panel3D1_9.Name = "_FM_Panel3D1_9"
        Me._FM_Panel3D1_9.Size = New System.Drawing.Size(39, 46)
        Me._FM_Panel3D1_9.TabIndex = 46
        Me._FM_Panel3D1_9.Text = "単位"
        '
        '_FM_Panel3D1_6
        '
        Me._FM_Panel3D1_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_6, CType(6, Short))
        Me._FM_Panel3D1_6.Location = New System.Drawing.Point(117, 395)
        Me._FM_Panel3D1_6.Name = "_FM_Panel3D1_6"
        Me._FM_Panel3D1_6.Size = New System.Drawing.Size(333, 24)
        Me._FM_Panel3D1_6.TabIndex = 47
        Me._FM_Panel3D1_6.Text = "　　　　　　　　　型　　式"
        '
        '_FM_Panel3D1_7
        '
        Me._FM_Panel3D1_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_7, CType(7, Short))
        Me._FM_Panel3D1_7.Location = New System.Drawing.Point(117, 417)
        Me._FM_Panel3D1_7.Name = "_FM_Panel3D1_7"
        Me._FM_Panel3D1_7.Size = New System.Drawing.Size(333, 24)
        Me._FM_Panel3D1_7.TabIndex = 48
        Me._FM_Panel3D1_7.Text = "　　　　　　　　　品　　名"
        '
        '_FM_Panel3D1_12
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_12, CType(12, Short))
        Me._FM_Panel3D1_12.Location = New System.Drawing.Point(156, 611)
        Me._FM_Panel3D1_12.Name = "_FM_Panel3D1_12"
        Me._FM_Panel3D1_12.Size = New System.Drawing.Size(93, 24)
        Me._FM_Panel3D1_12.TabIndex = 51
        Me._FM_Panel3D1_12.Text = "本体価格"
        '
        '_FM_Panel3D1_11
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_11, CType(11, Short))
        Me._FM_Panel3D1_11.Location = New System.Drawing.Point(156, 582)
        Me._FM_Panel3D1_11.Name = "_FM_Panel3D1_11"
        Me._FM_Panel3D1_11.Size = New System.Drawing.Size(93, 24)
        Me._FM_Panel3D1_11.TabIndex = 52
        Me._FM_Panel3D1_11.Text = "受注金額"
        '
        '_FM_Panel3D1_13
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_13, CType(13, Short))
        Me._FM_Panel3D1_13.Location = New System.Drawing.Point(221, 557)
        Me._FM_Panel3D1_13.Name = "_FM_Panel3D1_13"
        Me._FM_Panel3D1_13.Size = New System.Drawing.Size(67, 24)
        Me._FM_Panel3D1_13.TabIndex = 53
        Me._FM_Panel3D1_13.Text = "仕切率"
        '
        '_FM_Panel3D1_5
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_5, CType(5, Short))
        Me._FM_Panel3D1_5.Location = New System.Drawing.Point(33, 555)
        Me._FM_Panel3D1_5.Name = "_FM_Panel3D1_5"
        Me._FM_Panel3D1_5.Size = New System.Drawing.Size(92, 24)
        Me._FM_Panel3D1_5.TabIndex = 54
        Me._FM_Panel3D1_5.Text = "客先注文番号"
        '
        '_FM_Panel3D1_22
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_22, CType(22, Short))
        Me._FM_Panel3D1_22.Location = New System.Drawing.Point(331, 588)
        Me._FM_Panel3D1_22.Name = "_FM_Panel3D1_22"
        Me._FM_Panel3D1_22.Size = New System.Drawing.Size(105, 23)
        Me._FM_Panel3D1_22.TabIndex = 56
        Me._FM_Panel3D1_22.Text = "消費税額"
        '
        '_FM_Panel3D1_21
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_21, CType(21, Short))
        Me._FM_Panel3D1_21.Location = New System.Drawing.Point(263, 615)
        Me._FM_Panel3D1_21.Name = "_FM_Panel3D1_21"
        Me._FM_Panel3D1_21.Size = New System.Drawing.Size(105, 23)
        Me._FM_Panel3D1_21.TabIndex = 57
        Me._FM_Panel3D1_21.Text = "本体合計金額"
        '
        '_FM_Panel3D1_23
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_23, CType(23, Short))
        Me._FM_Panel3D1_23.Location = New System.Drawing.Point(384, 560)
        Me._FM_Panel3D1_23.Name = "_FM_Panel3D1_23"
        Me._FM_Panel3D1_23.Size = New System.Drawing.Size(105, 23)
        Me._FM_Panel3D1_23.TabIndex = 58
        Me._FM_Panel3D1_23.Text = "伝票合計金額"
        '
        '_FM_Panel3D1_20
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_20, CType(20, Short))
        Me._FM_Panel3D1_20.Location = New System.Drawing.Point(6, 532)
        Me._FM_Panel3D1_20.Name = "_FM_Panel3D1_20"
        Me._FM_Panel3D1_20.Size = New System.Drawing.Size(660, 23)
        Me._FM_Panel3D1_20.TabIndex = 59
        Me._FM_Panel3D1_20.Text = "下のパネルはコントロール配列になっており、不要だけども削除すると欠番となるのでそのままにしてある"
        '
        '_FM_Panel3D1_0
        '
        Me._FM_Panel3D1_0.Controls.Add(Me.SYSDT)
        Me._FM_Panel3D1_0.Controls.Add(Me.CM_EndCm)
        Me._FM_Panel3D1_0.Controls.Add(Me.CM_SLIST)
        Me._FM_Panel3D1_0.Controls.Add(Me.CM_INSERTDE)
        Me._FM_Panel3D1_0.Controls.Add(Me.CM_DELETEDE)
        Me._FM_Panel3D1_0.Controls.Add(Me.CM_Execute)
        Me._FM_Panel3D1_0.Controls.Add(Me.Image1)
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_0, CType(0, Short))
        Me._FM_Panel3D1_0.Location = New System.Drawing.Point(-3, 1)
        Me._FM_Panel3D1_0.Name = "_FM_Panel3D1_0"
        Me._FM_Panel3D1_0.Size = New System.Drawing.Size(1024, 37)
        Me._FM_Panel3D1_0.TabIndex = 60
        '
        'SYSDT
        '
        Me.SYSDT.Location = New System.Drawing.Point(633, 6)
        Me.SYSDT.Name = "SYSDT"
        Me.SYSDT.Size = New System.Drawing.Size(110, 22)
        Me.SYSDT.TabIndex = 61
        Me.SYSDT.Text = "YYYY/MM/DD"
        '
        'CM_EndCm
        '
        Me.CM_EndCm.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_EndCm.Image = CType(resources.GetObject("CM_EndCm.Image"), System.Drawing.Image)
        Me.CM_EndCm.Location = New System.Drawing.Point(14, 6)
        Me.CM_EndCm.Name = "CM_EndCm"
        Me.CM_EndCm.Size = New System.Drawing.Size(24, 22)
        Me.CM_EndCm.TabIndex = 62
        Me.CM_EndCm.TabStop = False
        Me.CM_EndCm.Visible = False
        '
        'CM_SLIST
        '
        Me.CM_SLIST.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_SLIST.Image = CType(resources.GetObject("CM_SLIST.Image"), System.Drawing.Image)
        Me.CM_SLIST.Location = New System.Drawing.Point(60, 6)
        Me.CM_SLIST.Name = "CM_SLIST"
        Me.CM_SLIST.Size = New System.Drawing.Size(24, 22)
        Me.CM_SLIST.TabIndex = 63
        Me.CM_SLIST.TabStop = False
        Me.CM_SLIST.Visible = False
        '
        'CM_INSERTDE
        '
        Me.CM_INSERTDE.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_INSERTDE.Image = CType(resources.GetObject("CM_INSERTDE.Image"), System.Drawing.Image)
        Me.CM_INSERTDE.Location = New System.Drawing.Point(374, 59)
        Me.CM_INSERTDE.Name = "CM_INSERTDE"
        Me.CM_INSERTDE.Size = New System.Drawing.Size(24, 22)
        Me.CM_INSERTDE.TabIndex = 64
        Me.CM_INSERTDE.TabStop = False
        '
        'CM_DELETEDE
        '
        Me.CM_DELETEDE.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_DELETEDE.Image = CType(resources.GetObject("CM_DELETEDE.Image"), System.Drawing.Image)
        Me.CM_DELETEDE.Location = New System.Drawing.Point(415, 69)
        Me.CM_DELETEDE.Name = "CM_DELETEDE"
        Me.CM_DELETEDE.Size = New System.Drawing.Size(24, 22)
        Me.CM_DELETEDE.TabIndex = 65
        Me.CM_DELETEDE.TabStop = False
        '
        'CM_Execute
        '
        Me.CM_Execute.Cursor = System.Windows.Forms.Cursors.Default
        Me.CM_Execute.Enabled = False
        Me.CM_Execute.Image = CType(resources.GetObject("CM_Execute.Image"), System.Drawing.Image)
        Me.CM_Execute.Location = New System.Drawing.Point(37, 6)
        Me.CM_Execute.Name = "CM_Execute"
        Me.CM_Execute.Size = New System.Drawing.Size(24, 22)
        Me.CM_Execute.TabIndex = 66
        Me.CM_Execute.TabStop = False
        Me.CM_Execute.Visible = False
        '
        'Image1
        '
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Location = New System.Drawing.Point(0, 0)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(422, 34)
        Me.Image1.TabIndex = 67
        Me.Image1.TabStop = False
        '
        '_FM_Panel3D1_15
        '
        Me._FM_Panel3D1_15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._FM_Panel3D1_15.Controls.Add(Me._Line1_0)
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_15, CType(15, Short))
        Me._FM_Panel3D1_15.Location = New System.Drawing.Point(551, 395)
        Me._FM_Panel3D1_15.Name = "_FM_Panel3D1_15"
        Me._FM_Panel3D1_15.Size = New System.Drawing.Size(151, 46)
        Me._FM_Panel3D1_15.TabIndex = 45
        Me._FM_Panel3D1_15.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "　　　　備 考"
        '
        '_Line1_0
        '
        Me._Line1_0.BackColor = System.Drawing.Color.White
        Me.Line1.SetIndex(Me._Line1_0, CType(0, Short))
        Me._Line1_0.Location = New System.Drawing.Point(-1, 6)
        Me._Line1_0.Name = "_Line1_0"
        Me._Line1_0.Size = New System.Drawing.Size(1, 11)
        Me._Line1_0.TabIndex = 0
        '
        '_FM_Panel3D1_30
        '
        Me._FM_Panel3D1_30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_30, CType(30, Short))
        Me._FM_Panel3D1_30.Location = New System.Drawing.Point(354, 307)
        Me._FM_Panel3D1_30.Name = "_FM_Panel3D1_30"
        Me._FM_Panel3D1_30.Size = New System.Drawing.Size(86, 63)
        Me._FM_Panel3D1_30.TabIndex = 73
        Me._FM_Panel3D1_30.Text = "   " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "　　" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "　 住　所"
        '
        'CS_JDNDT
        '
        Me.CS_JDNDT.Location = New System.Drawing.Point(15, 240)
        Me.CS_JDNDT.Name = "CS_JDNDT"
        Me.CS_JDNDT.Size = New System.Drawing.Size(120, 23)
        Me.CS_JDNDT.TabIndex = 75
        Me.CS_JDNDT.TabStop = False
        Me.CS_JDNDT.Text = "  出庫日       "
        Me.CS_JDNDT.Visible = False
        '
        'CS_REF_SBN
        '
        Me.CS_REF_SBN.Location = New System.Drawing.Point(17, 48)
        Me.CS_REF_SBN.Name = "CS_REF_SBN"
        Me.CS_REF_SBN.Size = New System.Drawing.Size(106, 23)
        Me.CS_REF_SBN.TabIndex = 76
        Me.CS_REF_SBN.TabStop = False
        Me.CS_REF_SBN.Text = " *出庫訂正対象  "
        '
        '_FM_Panel3D1_28
        '
        Me._FM_Panel3D1_28.Controls.Add(Me._FM_Panel3D1_27)
        Me._FM_Panel3D1_28.Controls.Add(Me._IM_Denkyu_0)
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_28, CType(28, Short))
        Me._FM_Panel3D1_28.Location = New System.Drawing.Point(-2, 487)
        Me._FM_Panel3D1_28.Name = "_FM_Panel3D1_28"
        Me._FM_Panel3D1_28.Size = New System.Drawing.Size(888, 40)
        Me._FM_Panel3D1_28.TabIndex = 62
        '
        '_FM_Panel3D1_27
        '
        Me._FM_Panel3D1_27.Controls.Add(Me.TX_Message)
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_27, CType(27, Short))
        Me._FM_Panel3D1_27.Location = New System.Drawing.Point(50, 4)
        Me._FM_Panel3D1_27.Name = "_FM_Panel3D1_27"
        Me._FM_Panel3D1_27.Size = New System.Drawing.Size(750, 31)
        Me._FM_Panel3D1_27.TabIndex = 63
        '
        'TX_Message
        '
        Me.TX_Message.AcceptsReturn = True
        Me.TX_Message.BackColor = System.Drawing.SystemColors.Control
        Me.TX_Message.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TX_Message.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TX_Message.ForeColor = System.Drawing.Color.Black
        Me.TX_Message.Location = New System.Drawing.Point(7, 8)
        Me.TX_Message.MaxLength = 0
        Me.TX_Message.Multiline = True
        Me.TX_Message.Name = "TX_Message"
        Me.TX_Message.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_Message.Size = New System.Drawing.Size(667, 16)
        Me.TX_Message.TabIndex = 64
        Me.TX_Message.Text = "エラーやプロンプトのメッセージが出力されるところです。"
        Me.TX_Message.Visible = False
        '
        '_IM_Denkyu_0
        '
        Me._IM_Denkyu_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_0.Image = CType(resources.GetObject("_IM_Denkyu_0.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_0, CType(0, Short))
        Me._IM_Denkyu_0.Location = New System.Drawing.Point(26, 8)
        Me._IM_Denkyu_0.Name = "_IM_Denkyu_0"
        Me._IM_Denkyu_0.Size = New System.Drawing.Size(20, 22)
        Me._IM_Denkyu_0.TabIndex = 64
        Me._IM_Denkyu_0.TabStop = False
        Me._IM_Denkyu_0.Visible = False
        '
        '_FM_Panel3D1_29
        '
        Me._FM_Panel3D1_29.Controls.Add(Me.TX_Mode)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_Execute_1_1)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_Execute_1_0)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_Hardcopy_1)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_Slist_1)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_EndCm_0)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_EndCm_1)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_Slist_0)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_Hardcopy_0)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_PREV_1)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_PREV_0)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_NEXTCM_0)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_NEXTCM_1)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_INSERTDE_0)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_INSERTDE_1)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_DELETEDE_0)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_DELETEDE_1)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_Denkyu_1)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_Denkyu_2)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_LCONFIG_1)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_LCONFIG_0)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_Execute_0)
        Me._FM_Panel3D1_29.Controls.Add(Me._IM_Execute_2)
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_29, CType(29, Short))
        Me._FM_Panel3D1_29.Location = New System.Drawing.Point(-1, 557)
        Me._FM_Panel3D1_29.Name = "_FM_Panel3D1_29"
        Me._FM_Panel3D1_29.Size = New System.Drawing.Size(807, 25)
        Me._FM_Panel3D1_29.TabIndex = 65
        '
        'TX_Mode
        '
        Me.TX_Mode.AcceptsReturn = True
        Me.TX_Mode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TX_Mode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TX_Mode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TX_Mode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TX_Mode.Location = New System.Drawing.Point(585, 3)
        Me.TX_Mode.MaxLength = 0
        Me.TX_Mode.Name = "TX_Mode"
        Me.TX_Mode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TX_Mode.Size = New System.Drawing.Size(58, 20)
        Me.TX_Mode.TabIndex = 66
        Me.TX_Mode.Text = "ﾓｰﾄﾞ"
        '
        '_IM_Execute_1_1
        '
        Me._IM_Execute_1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Execute_1_1.Image = CType(resources.GetObject("_IM_Execute_1_1.Image"), System.Drawing.Image)
        Me.IM_Execute_1.SetIndex(Me._IM_Execute_1_1, CType(1, Short))
        Me._IM_Execute_1_1.Location = New System.Drawing.Point(81, 3)
        Me._IM_Execute_1_1.Name = "_IM_Execute_1_1"
        Me._IM_Execute_1_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_Execute_1_1.TabIndex = 67
        Me._IM_Execute_1_1.TabStop = False
        Me._IM_Execute_1_1.Visible = False
        '
        '_IM_Execute_1_0
        '
        Me._IM_Execute_1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Execute_1_0.Image = CType(resources.GetObject("_IM_Execute_1_0.Image"), System.Drawing.Image)
        Me.IM_Execute_1.SetIndex(Me._IM_Execute_1_0, CType(0, Short))
        Me._IM_Execute_1_0.Location = New System.Drawing.Point(57, 3)
        Me._IM_Execute_1_0.Name = "_IM_Execute_1_0"
        Me._IM_Execute_1_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_Execute_1_0.TabIndex = 68
        Me._IM_Execute_1_0.TabStop = False
        Me._IM_Execute_1_0.Visible = False
        '
        '_IM_Hardcopy_1
        '
        Me._IM_Hardcopy_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Hardcopy_1.Image = CType(resources.GetObject("_IM_Hardcopy_1.Image"), System.Drawing.Image)
        Me.IM_Hardcopy.SetIndex(Me._IM_Hardcopy_1, CType(1, Short))
        Me._IM_Hardcopy_1.Location = New System.Drawing.Point(126, 3)
        Me._IM_Hardcopy_1.Name = "_IM_Hardcopy_1"
        Me._IM_Hardcopy_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_Hardcopy_1.TabIndex = 69
        Me._IM_Hardcopy_1.TabStop = False
        Me._IM_Hardcopy_1.Visible = False
        '
        '_IM_Slist_1
        '
        Me._IM_Slist_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Slist_1.Image = CType(resources.GetObject("_IM_Slist_1.Image"), System.Drawing.Image)
        Me.IM_Slist.SetIndex(Me._IM_Slist_1, CType(1, Short))
        Me._IM_Slist_1.Location = New System.Drawing.Point(285, 3)
        Me._IM_Slist_1.Name = "_IM_Slist_1"
        Me._IM_Slist_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_Slist_1.TabIndex = 70
        Me._IM_Slist_1.TabStop = False
        Me._IM_Slist_1.Visible = False
        '
        '_IM_EndCm_0
        '
        Me._IM_EndCm_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_EndCm_0.Image = CType(resources.GetObject("_IM_EndCm_0.Image"), System.Drawing.Image)
        Me.IM_EndCm.SetIndex(Me._IM_EndCm_0, CType(0, Short))
        Me._IM_EndCm_0.Location = New System.Drawing.Point(9, 3)
        Me._IM_EndCm_0.Name = "_IM_EndCm_0"
        Me._IM_EndCm_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_EndCm_0.TabIndex = 71
        Me._IM_EndCm_0.TabStop = False
        Me._IM_EndCm_0.Visible = False
        '
        '_IM_EndCm_1
        '
        Me._IM_EndCm_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_EndCm_1.Image = CType(resources.GetObject("_IM_EndCm_1.Image"), System.Drawing.Image)
        Me.IM_EndCm.SetIndex(Me._IM_EndCm_1, CType(1, Short))
        Me._IM_EndCm_1.Location = New System.Drawing.Point(33, 3)
        Me._IM_EndCm_1.Name = "_IM_EndCm_1"
        Me._IM_EndCm_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_EndCm_1.TabIndex = 72
        Me._IM_EndCm_1.TabStop = False
        Me._IM_EndCm_1.Visible = False
        '
        '_IM_Slist_0
        '
        Me._IM_Slist_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Slist_0.Image = CType(resources.GetObject("_IM_Slist_0.Image"), System.Drawing.Image)
        Me.IM_Slist.SetIndex(Me._IM_Slist_0, CType(0, Short))
        Me._IM_Slist_0.Location = New System.Drawing.Point(261, 2)
        Me._IM_Slist_0.Name = "_IM_Slist_0"
        Me._IM_Slist_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_Slist_0.TabIndex = 73
        Me._IM_Slist_0.TabStop = False
        Me._IM_Slist_0.Visible = False
        '
        '_IM_Hardcopy_0
        '
        Me._IM_Hardcopy_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Hardcopy_0.Image = CType(resources.GetObject("_IM_Hardcopy_0.Image"), System.Drawing.Image)
        Me.IM_Hardcopy.SetIndex(Me._IM_Hardcopy_0, CType(0, Short))
        Me._IM_Hardcopy_0.Location = New System.Drawing.Point(102, 3)
        Me._IM_Hardcopy_0.Name = "_IM_Hardcopy_0"
        Me._IM_Hardcopy_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_Hardcopy_0.TabIndex = 74
        Me._IM_Hardcopy_0.TabStop = False
        Me._IM_Hardcopy_0.Visible = False
        '
        '_IM_PREV_1
        '
        Me._IM_PREV_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_PREV_1.Image = CType(resources.GetObject("_IM_PREV_1.Image"), System.Drawing.Image)
        Me.IM_PREV.SetIndex(Me._IM_PREV_1, CType(1, Short))
        Me._IM_PREV_1.Location = New System.Drawing.Point(342, 3)
        Me._IM_PREV_1.Name = "_IM_PREV_1"
        Me._IM_PREV_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_PREV_1.TabIndex = 75
        Me._IM_PREV_1.TabStop = False
        Me._IM_PREV_1.Visible = False
        '
        '_IM_PREV_0
        '
        Me._IM_PREV_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_PREV_0.Image = CType(resources.GetObject("_IM_PREV_0.Image"), System.Drawing.Image)
        Me.IM_PREV.SetIndex(Me._IM_PREV_0, CType(0, Short))
        Me._IM_PREV_0.Location = New System.Drawing.Point(318, 2)
        Me._IM_PREV_0.Name = "_IM_PREV_0"
        Me._IM_PREV_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_PREV_0.TabIndex = 76
        Me._IM_PREV_0.TabStop = False
        Me._IM_PREV_0.Visible = False
        '
        '_IM_NEXTCM_0
        '
        Me._IM_NEXTCM_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_NEXTCM_0.Image = CType(resources.GetObject("_IM_NEXTCM_0.Image"), System.Drawing.Image)
        Me.IM_NEXTCM.SetIndex(Me._IM_NEXTCM_0, CType(0, Short))
        Me._IM_NEXTCM_0.Location = New System.Drawing.Point(366, 3)
        Me._IM_NEXTCM_0.Name = "_IM_NEXTCM_0"
        Me._IM_NEXTCM_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_NEXTCM_0.TabIndex = 77
        Me._IM_NEXTCM_0.TabStop = False
        Me._IM_NEXTCM_0.Visible = False
        '
        '_IM_NEXTCM_1
        '
        Me._IM_NEXTCM_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_NEXTCM_1.Image = CType(resources.GetObject("_IM_NEXTCM_1.Image"), System.Drawing.Image)
        Me.IM_NEXTCM.SetIndex(Me._IM_NEXTCM_1, CType(1, Short))
        Me._IM_NEXTCM_1.Location = New System.Drawing.Point(390, 3)
        Me._IM_NEXTCM_1.Name = "_IM_NEXTCM_1"
        Me._IM_NEXTCM_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_NEXTCM_1.TabIndex = 78
        Me._IM_NEXTCM_1.TabStop = False
        Me._IM_NEXTCM_1.Visible = False
        '
        '_IM_INSERTDE_0
        '
        Me._IM_INSERTDE_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_INSERTDE_0.Image = CType(resources.GetObject("_IM_INSERTDE_0.Image"), System.Drawing.Image)
        Me.IM_INSERTDE.SetIndex(Me._IM_INSERTDE_0, CType(0, Short))
        Me._IM_INSERTDE_0.Location = New System.Drawing.Point(159, 3)
        Me._IM_INSERTDE_0.Name = "_IM_INSERTDE_0"
        Me._IM_INSERTDE_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_INSERTDE_0.TabIndex = 79
        Me._IM_INSERTDE_0.TabStop = False
        '
        '_IM_INSERTDE_1
        '
        Me._IM_INSERTDE_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_INSERTDE_1.Image = CType(resources.GetObject("_IM_INSERTDE_1.Image"), System.Drawing.Image)
        Me.IM_INSERTDE.SetIndex(Me._IM_INSERTDE_1, CType(1, Short))
        Me._IM_INSERTDE_1.Location = New System.Drawing.Point(183, 3)
        Me._IM_INSERTDE_1.Name = "_IM_INSERTDE_1"
        Me._IM_INSERTDE_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_INSERTDE_1.TabIndex = 80
        Me._IM_INSERTDE_1.TabStop = False
        '
        '_IM_DELETEDE_0
        '
        Me._IM_DELETEDE_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_DELETEDE_0.Image = CType(resources.GetObject("_IM_DELETEDE_0.Image"), System.Drawing.Image)
        Me.IM_DELETEDE.SetIndex(Me._IM_DELETEDE_0, CType(0, Short))
        Me._IM_DELETEDE_0.Location = New System.Drawing.Point(207, 3)
        Me._IM_DELETEDE_0.Name = "_IM_DELETEDE_0"
        Me._IM_DELETEDE_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_DELETEDE_0.TabIndex = 81
        Me._IM_DELETEDE_0.TabStop = False
        '
        '_IM_DELETEDE_1
        '
        Me._IM_DELETEDE_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_DELETEDE_1.Image = CType(resources.GetObject("_IM_DELETEDE_1.Image"), System.Drawing.Image)
        Me.IM_DELETEDE.SetIndex(Me._IM_DELETEDE_1, CType(1, Short))
        Me._IM_DELETEDE_1.Location = New System.Drawing.Point(231, 3)
        Me._IM_DELETEDE_1.Name = "_IM_DELETEDE_1"
        Me._IM_DELETEDE_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_DELETEDE_1.TabIndex = 82
        Me._IM_DELETEDE_1.TabStop = False
        '
        '_IM_Denkyu_1
        '
        Me._IM_Denkyu_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_1.Image = CType(resources.GetObject("_IM_Denkyu_1.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_1, CType(1, Short))
        Me._IM_Denkyu_1.Location = New System.Drawing.Point(484, 4)
        Me._IM_Denkyu_1.Name = "_IM_Denkyu_1"
        Me._IM_Denkyu_1.Size = New System.Drawing.Size(20, 22)
        Me._IM_Denkyu_1.TabIndex = 83
        Me._IM_Denkyu_1.TabStop = False
        '
        '_IM_Denkyu_2
        '
        Me._IM_Denkyu_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Denkyu_2.Image = CType(resources.GetObject("_IM_Denkyu_2.Image"), System.Drawing.Image)
        Me.IM_Denkyu.SetIndex(Me._IM_Denkyu_2, CType(2, Short))
        Me._IM_Denkyu_2.Location = New System.Drawing.Point(506, 3)
        Me._IM_Denkyu_2.Name = "_IM_Denkyu_2"
        Me._IM_Denkyu_2.Size = New System.Drawing.Size(20, 22)
        Me._IM_Denkyu_2.TabIndex = 84
        Me._IM_Denkyu_2.TabStop = False
        '
        '_IM_LCONFIG_1
        '
        Me._IM_LCONFIG_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_LCONFIG_1.Image = CType(resources.GetObject("_IM_LCONFIG_1.Image"), System.Drawing.Image)
        Me.IM_LCONFIG.SetIndex(Me._IM_LCONFIG_1, CType(1, Short))
        Me._IM_LCONFIG_1.Location = New System.Drawing.Point(447, 3)
        Me._IM_LCONFIG_1.Name = "_IM_LCONFIG_1"
        Me._IM_LCONFIG_1.Size = New System.Drawing.Size(24, 22)
        Me._IM_LCONFIG_1.TabIndex = 85
        Me._IM_LCONFIG_1.TabStop = False
        '
        '_IM_LCONFIG_0
        '
        Me._IM_LCONFIG_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_LCONFIG_0.Image = CType(resources.GetObject("_IM_LCONFIG_0.Image"), System.Drawing.Image)
        Me.IM_LCONFIG.SetIndex(Me._IM_LCONFIG_0, CType(0, Short))
        Me._IM_LCONFIG_0.Location = New System.Drawing.Point(423, 3)
        Me._IM_LCONFIG_0.Name = "_IM_LCONFIG_0"
        Me._IM_LCONFIG_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_LCONFIG_0.TabIndex = 86
        Me._IM_LCONFIG_0.TabStop = False
        '
        '_IM_Execute_0
        '
        Me._IM_Execute_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._IM_Execute_0.Image = CType(resources.GetObject("_IM_Execute_0.Image"), System.Drawing.Image)
        Me.IM_Execute.SetIndex(Me._IM_Execute_0, CType(0, Short))
        Me._IM_Execute_0.Location = New System.Drawing.Point(528, 4)
        Me._IM_Execute_0.Name = "_IM_Execute_0"
        Me._IM_Execute_0.Size = New System.Drawing.Size(24, 22)
        Me._IM_Execute_0.TabIndex = 87
        Me._IM_Execute_0.TabStop = False
        Me._IM_Execute_0.Visible = False
        '
        '_IM_Execute_2
        '
        Me._IM_Execute_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.IM_Execute.SetIndex(Me._IM_Execute_2, CType(1, Short))
        Me._IM_Execute_2.Location = New System.Drawing.Point(552, 4)
        Me._IM_Execute_2.Name = "_IM_Execute_2"
        Me._IM_Execute_2.Size = New System.Drawing.Size(24, 22)
        Me._IM_Execute_2.TabIndex = 88
        Me._IM_Execute_2.TabStop = False
        Me._IM_Execute_2.Visible = False
        '
        'TL_Cursol_Wk_2
        '
        Me.TL_Cursol_Wk_2.AcceptsReturn = True
        Me.TL_Cursol_Wk_2.BackColor = System.Drawing.Color.White
        Me.TL_Cursol_Wk_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TL_Cursol_Wk_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TL_Cursol_Wk_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TL_Cursol_Wk_2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TL_Cursol_Wk_2.Location = New System.Drawing.Point(701, 502)
        Me.TL_Cursol_Wk_2.MaxLength = 0
        Me.TL_Cursol_Wk_2.Name = "TL_Cursol_Wk_2"
        Me.TL_Cursol_Wk_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TL_Cursol_Wk_2.Size = New System.Drawing.Size(37, 20)
        Me.TL_Cursol_Wk_2.TabIndex = 68
        Me.TL_Cursol_Wk_2.Text = "HD_Cursol_Wk_2"
        '
        'HD_Cursol_Wk_1
        '
        Me.HD_Cursol_Wk_1.AcceptsReturn = True
        Me.HD_Cursol_Wk_1.BackColor = System.Drawing.Color.White
        Me.HD_Cursol_Wk_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_Cursol_Wk_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_Cursol_Wk_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_Cursol_Wk_1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.HD_Cursol_Wk_1.Location = New System.Drawing.Point(654, 502)
        Me.HD_Cursol_Wk_1.MaxLength = 0
        Me.HD_Cursol_Wk_1.Name = "HD_Cursol_Wk_1"
        Me.HD_Cursol_Wk_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_Cursol_Wk_1.Size = New System.Drawing.Size(46, 20)
        Me.HD_Cursol_Wk_1.TabIndex = 67
        Me.HD_Cursol_Wk_1.Text = "HD_Cursol_Wk_1"
        '
        'CS_BINCD
        '
        Me.CS_BINCD.CausesValidation = False
        Me.CS_BINCD.Location = New System.Drawing.Point(134, 336)
        Me.CS_BINCD.Name = "CS_BINCD"
        Me.CS_BINCD.Size = New System.Drawing.Size(86, 23)
        Me.CS_BINCD.TabIndex = 77
        Me.CS_BINCD.TabStop = False
        Me.CS_BINCD.Text = "　　　 便  名         "
        Me.CS_BINCD.Visible = False
        '
        'HD_Cursol_Wk_2
        '
        Me.HD_Cursol_Wk_2.AcceptsReturn = True
        Me.HD_Cursol_Wk_2.BackColor = System.Drawing.SystemColors.Window
        Me.HD_Cursol_Wk_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_Cursol_Wk_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_Cursol_Wk_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_Cursol_Wk_2.Location = New System.Drawing.Point(617, 497)
        Me.HD_Cursol_Wk_2.MaxLength = 0
        Me.HD_Cursol_Wk_2.Name = "HD_Cursol_Wk_2"
        Me.HD_Cursol_Wk_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_Cursol_Wk_2.Size = New System.Drawing.Size(102, 20)
        Me.HD_Cursol_Wk_2.TabIndex = 84
        Me.HD_Cursol_Wk_2.Text = "Text1"
        '
        'HD_Cursol_Wk_3
        '
        Me.HD_Cursol_Wk_3.AcceptsReturn = True
        Me.HD_Cursol_Wk_3.BackColor = System.Drawing.SystemColors.Window
        Me.HD_Cursol_Wk_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HD_Cursol_Wk_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HD_Cursol_Wk_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HD_Cursol_Wk_3.Location = New System.Drawing.Point(703, 498)
        Me.HD_Cursol_Wk_3.MaxLength = 0
        Me.HD_Cursol_Wk_3.Name = "HD_Cursol_Wk_3"
        Me.HD_Cursol_Wk_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_Cursol_Wk_3.Size = New System.Drawing.Size(102, 20)
        Me.HD_Cursol_Wk_3.TabIndex = 85
        Me.HD_Cursol_Wk_3.Text = "Text1"
        '
        '_FM_Panel3D1_31
        '
        Me._FM_Panel3D1_31.Enabled = False
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_31, CType(31, Short))
        Me._FM_Panel3D1_31.Location = New System.Drawing.Point(414, 534)
        Me._FM_Panel3D1_31.Name = "_FM_Panel3D1_31"
        Me._FM_Panel3D1_31.Size = New System.Drawing.Size(120, 23)
        Me._FM_Panel3D1_31.TabIndex = 83
        Me._FM_Panel3D1_31.Text = "　出庫種別(戻し)"
        Me._FM_Panel3D1_31.Visible = False
        '
        'HD_OPT3
        '
        Me.HD_OPT3.BackColor = System.Drawing.SystemColors.Control
        Me.HD_OPT3.Cursor = System.Windows.Forms.Cursors.Default
        Me.HD_OPT3.Enabled = False
        Me.HD_OPT3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HD_OPT3.Location = New System.Drawing.Point(706, 454)
        Me.HD_OPT3.Name = "HD_OPT3"
        Me.HD_OPT3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_OPT3.Size = New System.Drawing.Size(86, 21)
        Me.HD_OPT3.TabIndex = 80
        Me.HD_OPT3.TabStop = True
        Me.HD_OPT3.Text = "受注"
        Me.HD_OPT3.UseVisualStyleBackColor = False
        Me.HD_OPT3.Visible = False
        '
        'HD_OPT2
        '
        Me.HD_OPT2.BackColor = System.Drawing.SystemColors.Control
        Me.HD_OPT2.Cursor = System.Windows.Forms.Cursors.Default
        Me.HD_OPT2.Enabled = False
        Me.HD_OPT2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HD_OPT2.Location = New System.Drawing.Point(706, 432)
        Me.HD_OPT2.Name = "HD_OPT2"
        Me.HD_OPT2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_OPT2.Size = New System.Drawing.Size(86, 21)
        Me.HD_OPT2.TabIndex = 81
        Me.HD_OPT2.TabStop = True
        Me.HD_OPT2.Text = "支給出庫"
        Me.HD_OPT2.UseVisualStyleBackColor = False
        Me.HD_OPT2.Visible = False
        '
        'HD_OPT1
        '
        Me.HD_OPT1.BackColor = System.Drawing.SystemColors.Control
        Me.HD_OPT1.Cursor = System.Windows.Forms.Cursors.Default
        Me.HD_OPT1.Enabled = False
        Me.HD_OPT1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HD_OPT1.Location = New System.Drawing.Point(705, 410)
        Me.HD_OPT1.Name = "HD_OPT1"
        Me.HD_OPT1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HD_OPT1.Size = New System.Drawing.Size(86, 21)
        Me.HD_OPT1.TabIndex = 82
        Me.HD_OPT1.TabStop = True
        Me.HD_OPT1.Text = "製番出庫"
        Me.HD_OPT1.UseVisualStyleBackColor = False
        Me.HD_OPT1.Visible = False
        '
        '_FM_Panel3D1_32
        '
        Me._FM_Panel3D1_32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_32, CType(32, Short))
        Me._FM_Panel3D1_32.Location = New System.Drawing.Point(590, 260)
        Me._FM_Panel3D1_32.Name = "_FM_Panel3D1_32"
        Me._FM_Panel3D1_32.Size = New System.Drawing.Size(86, 44)
        Me._FM_Panel3D1_32.TabIndex = 89
        Me._FM_Panel3D1_32.Text = "　" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "　郵便番号"
        '
        '_FM_Panel3D1_33
        '
        Me._FM_Panel3D1_33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_33, CType(33, Short))
        Me._FM_Panel3D1_33.Location = New System.Drawing.Point(354, 260)
        Me._FM_Panel3D1_33.Name = "_FM_Panel3D1_33"
        Me._FM_Panel3D1_33.Size = New System.Drawing.Size(86, 23)
        Me._FM_Panel3D1_33.TabIndex = 90
        Me._FM_Panel3D1_33.Text = "  電話番号"
        '
        '_FM_Panel3D1_34
        '
        Me._FM_Panel3D1_34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_34, CType(34, Short))
        Me._FM_Panel3D1_34.Location = New System.Drawing.Point(354, 284)
        Me._FM_Panel3D1_34.Name = "_FM_Panel3D1_34"
        Me._FM_Panel3D1_34.Size = New System.Drawing.Size(86, 22)
        Me._FM_Panel3D1_34.TabIndex = 91
        Me._FM_Panel3D1_34.Text = "　Ｆ Ａ Ｘ  "
        '
        '_FM_Panel3D1_8
        '
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_8, CType(8, Short))
        Me._FM_Panel3D1_8.Location = New System.Drawing.Point(450, 395)
        Me._FM_Panel3D1_8.Name = "_FM_Panel3D1_8"
        Me._FM_Panel3D1_8.Size = New System.Drawing.Size(64, 46)
        Me._FM_Panel3D1_8.TabIndex = 50
        Me._FM_Panel3D1_8.Text = " 数 量"
        '
        '_FM_Panel3D1_35
        '
        Me._FM_Panel3D1_35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_35, CType(35, Short))
        Me._FM_Panel3D1_35.Location = New System.Drawing.Point(354, 191)
        Me._FM_Panel3D1_35.Name = "_FM_Panel3D1_35"
        Me._FM_Panel3D1_35.Size = New System.Drawing.Size(86, 22)
        Me._FM_Panel3D1_35.TabIndex = 93
        Me._FM_Panel3D1_35.Text = "  得 意 先"
        '
        '_FM_Panel3D1_36
        '
        Me._FM_Panel3D1_36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_36, CType(36, Short))
        Me._FM_Panel3D1_36.Location = New System.Drawing.Point(354, 214)
        Me._FM_Panel3D1_36.Name = "_FM_Panel3D1_36"
        Me._FM_Panel3D1_36.Size = New System.Drawing.Size(86, 45)
        Me._FM_Panel3D1_36.TabIndex = 94
        Me._FM_Panel3D1_36.Text = "  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  納 入 先"
        '
        '_FM_Panel3D1_37
        '
        Me._FM_Panel3D1_37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_37, CType(37, Short))
        Me._FM_Panel3D1_37.Location = New System.Drawing.Point(354, 371)
        Me._FM_Panel3D1_37.Name = "_FM_Panel3D1_37"
        Me._FM_Panel3D1_37.Size = New System.Drawing.Size(86, 20)
        Me._FM_Panel3D1_37.TabIndex = 95
        Me._FM_Panel3D1_37.Text = "   便　名"
        '
        '_FM_Panel3D1_38
        '
        Me._FM_Panel3D1_38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_38, CType(38, Short))
        Me._FM_Panel3D1_38.Location = New System.Drawing.Point(26, 394)
        Me._FM_Panel3D1_38.Name = "_FM_Panel3D1_38"
        Me._FM_Panel3D1_38.Size = New System.Drawing.Size(91, 47)
        Me._FM_Panel3D1_38.TabIndex = 96
        Me._FM_Panel3D1_38.Text = " " & Global.Microsoft.VisualBasic.ChrW(13) & " 製品コード"
        '
        '_FM_Panel3D1_39
        '
        Me._FM_Panel3D1_39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_39, CType(39, Short))
        Me._FM_Panel3D1_39.Location = New System.Drawing.Point(17, 71)
        Me._FM_Panel3D1_39.Name = "_FM_Panel3D1_39"
        Me._FM_Panel3D1_39.Size = New System.Drawing.Size(120, 23)
        Me._FM_Panel3D1_39.TabIndex = 97
        Me._FM_Panel3D1_39.Text = "  出 庫 日"
        '
        '_FM_Panel3D1_40
        '
        Me._FM_Panel3D1_40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_40, CType(40, Short))
        Me._FM_Panel3D1_40.Location = New System.Drawing.Point(17, 95)
        Me._FM_Panel3D1_40.Name = "_FM_Panel3D1_40"
        Me._FM_Panel3D1_40.Size = New System.Drawing.Size(120, 23)
        Me._FM_Panel3D1_40.TabIndex = 98
        Me._FM_Panel3D1_40.Text = "  処 理 理 由"
        '
        '_FM_Panel3D1_41
        '
        Me._FM_Panel3D1_41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_41, CType(41, Short))
        Me._FM_Panel3D1_41.Location = New System.Drawing.Point(17, 119)
        Me._FM_Panel3D1_41.Name = "_FM_Panel3D1_41"
        Me._FM_Panel3D1_41.Size = New System.Drawing.Size(120, 23)
        Me._FM_Panel3D1_41.TabIndex = 99
        Me._FM_Panel3D1_41.Text = "  参照受注番号"
        '
        '_FM_Panel3D1_42
        '
        Me._FM_Panel3D1_42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_42, CType(42, Short))
        Me._FM_Panel3D1_42.Location = New System.Drawing.Point(17, 167)
        Me._FM_Panel3D1_42.Name = "_FM_Panel3D1_42"
        Me._FM_Panel3D1_42.Size = New System.Drawing.Size(120, 23)
        Me._FM_Panel3D1_42.TabIndex = 100
        Me._FM_Panel3D1_42.Text = "  倉庫コード"
        '
        '_FM_Panel3D1_43
        '
        Me._FM_Panel3D1_43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_43, CType(43, Short))
        Me._FM_Panel3D1_43.Location = New System.Drawing.Point(17, 191)
        Me._FM_Panel3D1_43.Name = "_FM_Panel3D1_43"
        Me._FM_Panel3D1_43.Size = New System.Drawing.Size(120, 23)
        Me._FM_Panel3D1_43.TabIndex = 101
        Me._FM_Panel3D1_43.Text = "  送り先担当者"
        '
        '_FM_Panel3D1_44
        '
        Me._FM_Panel3D1_44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FM_Panel3D1.SetIndex(Me._FM_Panel3D1_44, CType(44, Short))
        Me._FM_Panel3D1_44.Location = New System.Drawing.Point(17, 216)
        Me._FM_Panel3D1_44.Name = "_FM_Panel3D1_44"
        Me._FM_Panel3D1_44.Size = New System.Drawing.Size(120, 22)
        Me._FM_Panel3D1_44.TabIndex = 102
        Me._FM_Panel3D1_44.Text = "  送り先部門"
        '
        'BD_HINCD
        '
        '
        'BD_HINNMA
        '
        '
        'BD_HINNMB
        '
        '
        'BD_LINCMA
        '
        '
        'BD_LINCMB
        '
        '
        'BD_UNTNM
        '
        '
        'BD_UODSU
        '
        '
        'MainMenu1
        '
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(980, 24)
        Me.MainMenu1.TabIndex = 103
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
        'btnF12
        '
        Me.btnF12.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF12.Location = New System.Drawing.Point(897, 488)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(75, 37)
        Me.btnF12.TabIndex = 261
        Me.btnF12.Text = "(F12)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "終了"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'btnF11
        '
        Me.btnF11.Enabled = False
        Me.btnF11.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF11.Location = New System.Drawing.Point(820, 488)
        Me.btnF11.Name = "btnF11"
        Me.btnF11.Size = New System.Drawing.Size(75, 37)
        Me.btnF11.TabIndex = 260
        Me.btnF11.Text = "(F11)"
        Me.btnF11.UseVisualStyleBackColor = True
        '
        'btnF10
        '
        Me.btnF10.Enabled = False
        Me.btnF10.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF10.Location = New System.Drawing.Point(742, 488)
        Me.btnF10.Name = "btnF10"
        Me.btnF10.Size = New System.Drawing.Size(75, 37)
        Me.btnF10.TabIndex = 259
        Me.btnF10.Text = "(F10)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF10.UseVisualStyleBackColor = True
        '
        'btnF9
        '
        Me.btnF9.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF9.Location = New System.Drawing.Point(665, 488)
        Me.btnF9.Name = "btnF9"
        Me.btnF9.Size = New System.Drawing.Size(75, 37)
        Me.btnF9.TabIndex = 258
        Me.btnF9.Text = "(F9)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "クリア"
        Me.btnF9.UseVisualStyleBackColor = True
        '
        'btnF8
        '
        Me.btnF8.Enabled = False
        Me.btnF8.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF8.Location = New System.Drawing.Point(571, 488)
        Me.btnF8.Name = "btnF8"
        Me.btnF8.Size = New System.Drawing.Size(75, 37)
        Me.btnF8.TabIndex = 257
        Me.btnF8.Text = "(F8)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF8.UseVisualStyleBackColor = True
        '
        'btnF7
        '
        Me.btnF7.Enabled = False
        Me.btnF7.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF7.Location = New System.Drawing.Point(493, 488)
        Me.btnF7.Name = "btnF7"
        Me.btnF7.Size = New System.Drawing.Size(75, 37)
        Me.btnF7.TabIndex = 256
        Me.btnF7.Text = "(F7)"
        Me.btnF7.UseVisualStyleBackColor = True
        '
        'btnF6
        '
        Me.btnF6.Enabled = False
        Me.btnF6.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF6.Location = New System.Drawing.Point(415, 488)
        Me.btnF6.Name = "btnF6"
        Me.btnF6.Size = New System.Drawing.Size(75, 37)
        Me.btnF6.TabIndex = 255
        Me.btnF6.Text = "(F6)"
        Me.btnF6.UseVisualStyleBackColor = True
        '
        'btnF5
        '
        Me.btnF5.Enabled = False
        Me.btnF5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF5.Location = New System.Drawing.Point(337, 488)
        Me.btnF5.Name = "btnF5"
        Me.btnF5.Size = New System.Drawing.Size(75, 37)
        Me.btnF5.TabIndex = 254
        Me.btnF5.Text = "(F5)"
        Me.btnF5.UseVisualStyleBackColor = True
        '
        'btnF4
        '
        Me.btnF4.Enabled = False
        Me.btnF4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF4.Location = New System.Drawing.Point(243, 488)
        Me.btnF4.Name = "btnF4"
        Me.btnF4.Size = New System.Drawing.Size(75, 37)
        Me.btnF4.TabIndex = 253
        Me.btnF4.Text = "(F4)"
        Me.btnF4.UseVisualStyleBackColor = True
        '
        'btnF3
        '
        Me.btnF3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF3.Location = New System.Drawing.Point(164, 488)
        Me.btnF3.Name = "btnF3"
        Me.btnF3.Size = New System.Drawing.Size(75, 37)
        Me.btnF3.TabIndex = 252
        Me.btnF3.Text = "(F3)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "削除"
        Me.btnF3.UseVisualStyleBackColor = True
        '
        'btnF2
        '
        Me.btnF2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF2.Location = New System.Drawing.Point(85, 488)
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(75, 35)
        Me.btnF2.TabIndex = 251
        Me.btnF2.Text = "(F2)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "検索"
        Me.btnF2.UseVisualStyleBackColor = True
        '
        'btnF1
        '
        Me.btnF1.Enabled = False
        Me.btnF1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnF1.Location = New System.Drawing.Point(6, 488)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(75, 35)
        Me.btnF1.TabIndex = 250
        Me.btnF1.Text = "(F1)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.AcceptsReturn = True
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox1.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TextBox1.Location = New System.Drawing.Point(590, 107)
        Me.TextBox1.MaxLength = 30
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox1.Size = New System.Drawing.Size(334, 20)
        Me.TextBox1.TabIndex = 242
        Me.TextBox1.Text = "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3"
        Me.TextBox1.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.AcceptsReturn = True
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox2.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TextBox2.Location = New System.Drawing.Point(590, 133)
        Me.TextBox2.MaxLength = 24
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox2.Size = New System.Drawing.Size(151, 20)
        Me.TextBox2.TabIndex = 241
        Me.TextBox2.Text = "MMMMMMMMM1MMMMMMMMM2"
        Me.TextBox2.Visible = False
        '
        'Label1
        '
        Me.Label1.Controls.Add(Me.Label2)
        Me.Label1.Controls.Add(Me.PictureBox1)
        Me.Label1.Location = New System.Drawing.Point(-2, 490)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(888, 40)
        Me.Label1.TabIndex = 243
        '
        'Label2
        '
        Me.Label2.Controls.Add(Me.TextBox3)
        Me.Label2.Location = New System.Drawing.Point(50, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(750, 31)
        Me.Label2.TabIndex = 63
        '
        'TextBox3
        '
        Me.TextBox3.AcceptsReturn = True
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox3.ForeColor = System.Drawing.Color.Black
        Me.TextBox3.Location = New System.Drawing.Point(7, 8)
        Me.TextBox3.MaxLength = 0
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox3.Size = New System.Drawing.Size(667, 16)
        Me.TextBox3.TabIndex = 64
        Me.TextBox3.Text = "エラーやプロンプトのメッセージが出力されるところです。"
        Me.TextBox3.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(26, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 22)
        Me.PictureBox1.TabIndex = 64
        Me.PictureBox1.TabStop = False
        '
        'TextBox4
        '
        Me.TextBox4.AcceptsReturn = True
        Me.TextBox4.BackColor = System.Drawing.Color.White
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox4.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox4.Location = New System.Drawing.Point(701, 500)
        Me.TextBox4.MaxLength = 0
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox4.Size = New System.Drawing.Size(37, 20)
        Me.TextBox4.TabIndex = 245
        Me.TextBox4.Text = "HD_Cursol_Wk_2"
        '
        'TextBox5
        '
        Me.TextBox5.AcceptsReturn = True
        Me.TextBox5.BackColor = System.Drawing.Color.White
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox5.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox5.Location = New System.Drawing.Point(654, 500)
        Me.TextBox5.MaxLength = 0
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox5.Size = New System.Drawing.Size(46, 20)
        Me.TextBox5.TabIndex = 244
        Me.TextBox5.Text = "TextBox5"
        '
        'TextBox6
        '
        Me.TextBox6.AcceptsReturn = True
        Me.TextBox6.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox6.Location = New System.Drawing.Point(617, 495)
        Me.TextBox6.MaxLength = 0
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox6.Size = New System.Drawing.Size(102, 20)
        Me.TextBox6.TabIndex = 248
        Me.TextBox6.Text = "Text1"
        '
        'TextBox7
        '
        Me.TextBox7.AcceptsReturn = True
        Me.TextBox7.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox7.Location = New System.Drawing.Point(703, 496)
        Me.TextBox7.MaxLength = 0
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox7.Size = New System.Drawing.Size(102, 20)
        Me.TextBox7.TabIndex = 249
        Me.TextBox7.Text = "Text1"
        '
        'RadioButton1
        '
        Me.RadioButton1.BackColor = System.Drawing.SystemColors.Control
        Me.RadioButton1.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadioButton1.Enabled = False
        Me.RadioButton1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioButton1.Location = New System.Drawing.Point(706, 501)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadioButton1.Size = New System.Drawing.Size(86, 21)
        Me.RadioButton1.TabIndex = 246
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "受注"
        Me.RadioButton1.UseVisualStyleBackColor = False
        Me.RadioButton1.Visible = False
        '
        'RadioButton2
        '
        Me.RadioButton2.BackColor = System.Drawing.SystemColors.Control
        Me.RadioButton2.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadioButton2.Enabled = False
        Me.RadioButton2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioButton2.Location = New System.Drawing.Point(620, 498)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadioButton2.Size = New System.Drawing.Size(86, 21)
        Me.RadioButton2.TabIndex = 247
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "支給出庫"
        Me.RadioButton2.UseVisualStyleBackColor = False
        Me.RadioButton2.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 528)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(980, 23)
        Me.StatusStrip1.TabIndex = 262
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
        'FR_SSSMAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(980, 551)
        Me.Controls.Add(Me.StatusStrip1)
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
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.CS_UODSU)
        Me.Controls.Add(Me.HD_NHSZIPCD)
        Me.Controls.Add(Me.HD_NHSTL)
        Me.Controls.Add(Me.HD_NHSFAX)
        Me.Controls.Add(Me.HD_BINNM)
        Me.Controls.Add(Me.HD_BINCD)
        Me.Controls.Add(Me.HD_DENDT)
        Me.Controls.Add(Me.HD_NHSADC)
        Me.Controls.Add(Me.HD_NHSADB)
        Me.Controls.Add(Me.HD_NHSADA)
        Me.Controls.Add(Me.CS_HINCD)
        Me.Controls.Add(Me._FM_Panel3D1_14)
        Me.Controls.Add(Me.TL_KKOUT)
        Me.Controls.Add(Me._BD_UODSU_0)
        Me.Controls.Add(Me._BD_HINNMA_0)
        Me.Controls.Add(Me._BD_HINNMB_0)
        Me.Controls.Add(Me._BD_UNTNM_0)
        Me.Controls.Add(Me._BD_HINCD_0)
        Me.Controls.Add(Me._BD_LINCMB_0)
        Me.Controls.Add(Me._BD_LINCMA_0)
        Me.Controls.Add(Me.HD_NHSNMB)
        Me.Controls.Add(Me.HD_NHSNMA)
        Me.Controls.Add(Me.HD_NHSCD)
        Me.Controls.Add(Me.HD_TANCD)
        Me.Controls.Add(Me.HD_BUMCD)
        Me.Controls.Add(Me.HD_TANNM)
        Me.Controls.Add(Me.HD_BUMNM)
        Me.Controls.Add(Me.HD_OUTRYCD)
        Me.Controls.Add(Me.HD_OUTRYNM)
        Me.Controls.Add(Me.HD_TOKCD)
        Me.Controls.Add(Me.HD_TOKRN)
        Me.Controls.Add(Me.HD_SBNNO)
        Me.Controls.Add(Me.HD_URIKJNNM)
        Me.Controls.Add(Me.HD_SOUCD)
        Me.Controls.Add(Me.HD_SOUNM)
        Me.Controls.Add(Me.HD_IN_TANNM)
        Me.Controls.Add(Me.HD_IN_TANCD)
        Me.Controls.Add(Me.HD_JDNNO)
        Me.Controls.Add(Me.TX_CursorRest)
        Me.Controls.Add(Me._FM_Panel3D1_19)
        Me.Controls.Add(Me.CS_REF_JDNNO)
        Me.Controls.Add(Me.CS_SOUCD)
        Me.Controls.Add(Me._FM_Panel3D1_3)
        Me.Controls.Add(Me._FM_Panel3D1_2)
        Me.Controls.Add(Me.CS_TOKCD)
        Me.Controls.Add(Me.CS_OUTRY)
        Me.Controls.Add(Me._FM_Panel3D1_24)
        Me.Controls.Add(Me._FM_Panel3D1_25)
        Me.Controls.Add(Me._FM_Panel3D1_26)
        Me.Controls.Add(Me.CS_BUMCD)
        Me.Controls.Add(Me.CS_TANCD)
        Me.Controls.Add(Me._FM_Panel3D1_1)
        Me.Controls.Add(Me.CS_NHSCD)
        Me.Controls.Add(Me._FM_Panel3D1_17)
        Me.Controls.Add(Me._FM_Panel3D1_16)
        Me.Controls.Add(Me._FM_Panel3D1_18)
        Me.Controls.Add(Me._FM_Panel3D1_10)
        Me.Controls.Add(Me._FM_Panel3D1_4)
        Me.Controls.Add(Me._FM_Panel3D1_9)
        Me.Controls.Add(Me._FM_Panel3D1_6)
        Me.Controls.Add(Me._FM_Panel3D1_7)
        Me.Controls.Add(Me._FM_Panel3D1_12)
        Me.Controls.Add(Me._FM_Panel3D1_11)
        Me.Controls.Add(Me._FM_Panel3D1_13)
        Me.Controls.Add(Me._FM_Panel3D1_5)
        Me.Controls.Add(Me._FM_Panel3D1_22)
        Me.Controls.Add(Me._FM_Panel3D1_21)
        Me.Controls.Add(Me._FM_Panel3D1_23)
        Me.Controls.Add(Me._FM_Panel3D1_20)
        Me.Controls.Add(Me._FM_Panel3D1_0)
        Me.Controls.Add(Me._FM_Panel3D1_15)
        Me.Controls.Add(Me._FM_Panel3D1_30)
        Me.Controls.Add(Me.CS_JDNDT)
        Me.Controls.Add(Me.CS_REF_SBN)
        Me.Controls.Add(Me._FM_Panel3D1_28)
        Me.Controls.Add(Me._FM_Panel3D1_29)
        Me.Controls.Add(Me.TL_Cursol_Wk_2)
        Me.Controls.Add(Me.HD_Cursol_Wk_1)
        Me.Controls.Add(Me.CS_BINCD)
        Me.Controls.Add(Me.HD_Cursol_Wk_2)
        Me.Controls.Add(Me.HD_Cursol_Wk_3)
        Me.Controls.Add(Me._FM_Panel3D1_31)
        Me.Controls.Add(Me.HD_OPT3)
        Me.Controls.Add(Me.HD_OPT2)
        Me.Controls.Add(Me.HD_OPT1)
        Me.Controls.Add(Me._FM_Panel3D1_32)
        Me.Controls.Add(Me._FM_Panel3D1_33)
        Me.Controls.Add(Me._FM_Panel3D1_34)
        Me.Controls.Add(Me._FM_Panel3D1_8)
        Me.Controls.Add(Me._FM_Panel3D1_35)
        Me.Controls.Add(Me._FM_Panel3D1_36)
        Me.Controls.Add(Me._FM_Panel3D1_37)
        Me.Controls.Add(Me._FM_Panel3D1_38)
        Me.Controls.Add(Me._FM_Panel3D1_39)
        Me.Controls.Add(Me._FM_Panel3D1_40)
        Me.Controls.Add(Me._FM_Panel3D1_41)
        Me.Controls.Add(Me._FM_Panel3D1_42)
        Me.Controls.Add(Me._FM_Panel3D1_43)
        Me.Controls.Add(Me._FM_Panel3D1_44)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 108)
        Me.MaximizeBox = False
        Me.Name = "FR_SSSMAIN"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "製番出庫戻し取消 "
        Me._FM_Panel3D1_0.ResumeLayout(False)
        CType(Me.CM_EndCm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_SLIST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_INSERTDE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_DELETEDE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CM_Execute, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        Me._FM_Panel3D1_15.ResumeLayout(False)
        Me._FM_Panel3D1_28.ResumeLayout(False)
        Me._FM_Panel3D1_27.ResumeLayout(False)
        Me._FM_Panel3D1_27.PerformLayout()
        CType(Me._IM_Denkyu_0, System.ComponentModel.ISupportInitialize).EndInit()
        Me._FM_Panel3D1_29.ResumeLayout(False)
        Me._FM_Panel3D1_29.PerformLayout()
        CType(Me._IM_Execute_1_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Execute_1_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Hardcopy_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Slist_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_EndCm_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_EndCm_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Slist_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Hardcopy_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_PREV_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_PREV_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_NEXTCM_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_NEXTCM_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_INSERTDE_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_INSERTDE_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_DELETEDE_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_DELETEDE_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Denkyu_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Denkyu_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_LCONFIG_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_LCONFIG_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Execute_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._IM_Execute_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_HINCD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_HINNMA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_HINNMB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_LINCMA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_LINCMB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_UNTNM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD_UODSU, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.Line1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Label1.ResumeLayout(False)
        Me.Label2.ResumeLayout(False)
        Me.Label2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnF12 As Button
    Friend WithEvents btnF11 As Button
    Friend WithEvents btnF10 As Button
    Friend WithEvents btnF9 As Button
    Friend WithEvents btnF8 As Button
    Friend WithEvents btnF7 As Button
    Friend WithEvents btnF6 As Button
    Friend WithEvents btnF5 As Button
    Friend WithEvents btnF4 As Button
    Friend WithEvents btnF3 As Button
    Friend WithEvents btnF2 As Button
    Friend WithEvents btnF1 As Button
    Public WithEvents TextBox1 As TextBox
    Public WithEvents TextBox2 As TextBox
    Public WithEvents Label1 As Label
    Public WithEvents Label2 As Label
    Public WithEvents TextBox3 As TextBox
    Public WithEvents PictureBox1 As PictureBox
    Public WithEvents TextBox4 As TextBox
    Public WithEvents TextBox5 As TextBox
    Public WithEvents TextBox6 As TextBox
    Public WithEvents TextBox7 As TextBox
    Public WithEvents RadioButton1 As RadioButton
    Public WithEvents RadioButton2 As RadioButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
#End Region
End Class