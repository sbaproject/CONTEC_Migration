Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
	'UPGRADE_WARNING: 配列を New で宣言することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC9D3AE5-6B95-4B43-91C7-28276302A5E8"' をクリックしてください。
	'UPGRADE_ISSUE: Toolbox オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
	Dim objim1(1) As New Toolbox
	'UPGRADE_WARNING: 構造体 pm_All の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Dim pm_All As Cls_All
	Dim bolStop_flg As Boolean
	Const mc_lngRunMode_Web As Integer = 2
	
	Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click
		MN_EndCm_Click(MN_EndCm, New System.EventArgs())
	End Sub
	
	Private Sub CM_EndCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'UPGRADE_ISSUE: P_Mes オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim objp_msg As New P_Mes
		'UPGRADE_WARNING: オブジェクト objp_msg.Dsp_Message_Prompt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CF_Set_Prompt(objp_msg.Dsp_Message_Prompt(gc_strMsgHINFP62_I_007), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black), pm_All)
		'UPGRADE_NOTE: オブジェクト objp_msg をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		objp_msg = Nothing
	End Sub
	
	Private Sub CM_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Execute.Click
		MN_EXECUTE_Click(MN_EXECUTE, New System.EventArgs())
	End Sub
	
	Private Sub CM_Execute_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'UPGRADE_ISSUE: P_Mes オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim objp_msg As New P_Mes
		'UPGRADE_WARNING: オブジェクト objp_msg.Dsp_Message_Prompt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CF_Set_Prompt(objp_msg.Dsp_Message_Prompt(gc_strMsgHINFP62_I_006), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black), pm_All)
		'UPGRADE_NOTE: オブジェクト objp_msg をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		objp_msg = Nothing
	End Sub
	
	Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		Dim I As Short
		If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP62_I_002, pm_All) = MsgBoxResult.No Then
			Cancel = 1
		Else
			CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
			For I = 0 To UBound(objim1)
				'UPGRADE_NOTE: オブジェクト objim1() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
				objim1(I) = Nothing
			Next 
		End If
		eventArgs.Cancel = Cancel
	End Sub
	
	
	Private Sub HD_IN_TANCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.Enter
		System.Windows.Forms.SendKeys.Send("{Tab}")
	End Sub
	
	Private Sub HD_IN_TANNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.Enter
		System.Windows.Forms.SendKeys.Send("{Tab}")
	End Sub
	
	Private Sub HD_TFPATH_B_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TFPATH_B.Enter
		System.Windows.Forms.SendKeys.Send("{Tab}")
	End Sub
	
	Private Sub Image1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		CF_Clr_Prompt(pm_All)
	End Sub
	
	Private Sub CS_TFPATH_B_Click()
		On Error GoTo err_CS_TFPATH_B_Click
		With CMDialogL
			'UPGRADE_WARNING: オブジェクト CMDialogL.CancelError の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CancelError = True
			'UPGRADE_WARNING: オブジェクト CMDialogL.DefaultExt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.DefaultExt = gv_strOUT_TYPE
			'UPGRADE_WARNING: オブジェクト CMDialogL.Filter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Filter = "*" & gv_strOUT_TYPE & "|*" & gv_strOUT_TYPE & "|*.*|*.*"
			'UPGRADE_WARNING: オブジェクト CMDialogL.ShowOpen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ShowOpen()
			'UPGRADE_WARNING: オブジェクト CMDialogL.FileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			HD_TFPATH_B.Text = .FileName
		End With
		Exit Sub
err_CS_TFPATH_B_Click: 
		HD_TFPATH_B.Text = ""
	End Sub
	
	Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim I As Short
		Dim objctrl As System.Windows.Forms.Control
		Dim pot_Inp_Inf As Cmn_Inp_Inf
		Dim bolRet As Boolean
		Dim strMsgCd As String
		Dim bolTrans As Boolean
		'UPGRADE_ISSUE: Gage オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim objgage As New Gage
		'DB接続
		Call CF_Ora_USR1_Open() 'USR1
		
		'共通初期化処理
		Call CF_Init()
		pm_All.Dsp_Base.FormCtl = Me
		pm_All.Dsp_IM_Denkyu = IM_Denkyu(0)
		pm_All.On_IM_Denkyu = IM_Denkyu(2)
		pm_All.Off_IM_Denkyu = IM_Denkyu(1)
		pm_All.Dsp_TX_Message = TX_Message
		TX_Message.Tag = 1
		ReDim pm_All.Dsp_Sub_Inf(1)
		pm_All.Dsp_Sub_Inf(1).Ctl = TX_Message
		'
		CF_Clr_Prompt(pm_All)
		'UPGRADE_WARNING: オブジェクト objgage.setGage の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		objgage.setGage(Gage, Cmd_cancel)
		'UPGRADE_WARNING: オブジェクト objgage.ShowGauge の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		objgage.ShowGauge(False)
		'UPGRADE_NOTE: オブジェクト objgage をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		objgage = Nothing
		HD_TFPATH_B.Text = vbNullString
		
		'    '画面情報設定
		'    For Each objctrl In Me.Controls
		'        ReDim Preserve objctrl1(I)
		'        objctrl1(I).bind objctrl
		'        I = I + 1
		'    Next
		'UPGRADE_WARNING: オブジェクト objim1().bind の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		objim1(0).bind(CM_EndCm, IM_EndCm(0), IM_EndCm(1))
		'UPGRADE_WARNING: オブジェクト objim1().bind の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		objim1(1).bind(CM_Execute, IM_Execute(0), IM_Execute(1))
		gv_strTAB_CHAR = vbTab
		gv_strOUT_TYPE = ".TXT"
		'画面内容初期化
		'UPGRADE_ISSUE: Form プロパティ FR_SSSMAIN.ScaleTop はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
		Me.ScaleTop = (VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.ClientRectangle.Height)) / 2
		'UPGRADE_ISSUE: Form プロパティ FR_SSSMAIN.ScaleLeft はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
		Me.ScaleLeft = (VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.ClientRectangle.Width)) / 2
		Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
		Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
		'UPGRADE_WARNING: オブジェクト SYSDT.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SYSDT.Caption = VB6.Format(GV_UNYDate, "@@@@/@@/@@")
		HD_IN_TANCD.Text = Inp_Inf.InpTanCd
		HD_IN_TANNM.Text = Inp_Inf.InpTanNm
		Exit Sub
Error_Handler: 
		'ロールバック
		If bolTrans Then
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		bolTrans = False
		
		
		
	End Sub
	'画面初期設定
	Public Sub MN_APPENDC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_APPENDC.Click
		HD_TFPATH_B.Text = vbNullString
	End Sub
	'画面終了
	Public Sub MN_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EndCm.Click
		Me.Close()
	End Sub
	'データ取り込み実行
	Public Sub MN_EXECUTE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EXECUTE.Click
		Dim objfso As New Scripting.FileSystemObject
		Dim objFile As Scripting.File
		Dim strfile As String 'コピー先ファイル名
		'PL/SQL呼び出し用
		Dim strSQL As String
		Dim lngParam1 As Integer
		Dim strParam2 As String
		Dim strParam3 As String
		Dim strParam4 As String
		Dim strParam5 As String
		Dim strParam6 As String
		Dim strParam7 As String
		Dim strParam8 As String
		Dim strParam9 As String
		Dim lngParam10 As Integer
		Dim strParam11 As New VB6.FixedLengthString(3000)
		'UPGRADE_ISSUE: OraParameter オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim param(13) As OraParameter 'PL/SQLのバインド変数
		Dim bolRet As Boolean
		Dim intret As Short
		Dim intCursor As Short
		Dim Err_Cd As Integer
		Dim strlogfile As String 'ログファイル名
		Dim strSVfolder As String
		Dim strERR_CODE As String
		Dim strLocalPath As String 'サーバ側のローカルパス変数
		On Error GoTo err_MN_EXECUTE_Click
		If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP62_I_001, pm_All) = MsgBoxResult.No Then
			AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP62_I_004, pm_All)
			Exit Sub
		End If
		'ファイルの存在可否
		If objfso.FileExists(HD_TFPATH_B.Text) Then
		Else
			'存在しないとき終了する。
			AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP62_I_008, pm_All)
			Exit Sub
		End If
		'更新権限がない場合は処理を行わない
		'    If Inp_Inf.InpJDNUPDKB <> gc_strJDNUPDKB_OK Then
		'        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODFP51_E_NOUPDKNG, pm_All)
		'        Exit Sub: Inp_Inf.InpFILEAUTH
		'    End If
		'カーソル退避
		intCursor = Me.Cursor
		Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
		
		objFile = objfso.GetFile(HD_TFPATH_B.Text)
		Select Case F_Ctl_CopyFiles(objFile.NAME, strfile)
			Case 0
				'正常
			Case 8
				'INIファイルが読み込めない
				AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP62_E_066, pm_All)
				Exit Sub
			Case 9
				'コピーができない
				AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP62_E_067, pm_All)
				Exit Sub
		End Select
		'サーバのローカルパスを取得する。
		If Get_INIFile_String(My.Application.Info.DirectoryPath & IIf(VB.Right(My.Application.Info.DirectoryPath, 1) = "\", "", "\") & SSS_PrgId & ".INI", "PATH", "ServerLocalLOG", strLocalPath) Then
		Else
			AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP62_E_066, pm_All)
			Exit Sub
		End If
		'PL/SQLに引数を渡す。
		'ファイルパス
		'ファイル名
		'
		'実行日時の取得
		Call CF_Get_SysDt()
		
		'運用日付の取得
		Call CF_Get_UnyDt()
		
		'引数設定
		lngParam1 = mc_lngRunMode_Web
		strParam2 = strLocalPath
		strParam3 = objfso.GetFile(strfile).ParentFolder.Path
		strParam4 = objfso.GetFileName(strfile)
		strParam5 = SSS_CLTID.Value
		strParam6 = SSS_OPEID.Value
		strParam7 = GV_SysDate
		strParam8 = GV_SysTime
		strParam9 = GV_UNYDate
		lngParam10 = 0
		strParam11.Value = ""
		'PL/SQLを実行する。
		'パラメータの初期設定を行う（バインド変数）
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P1", lngParam1, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P2", strParam2, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P3", strParam3, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P4", strParam4, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P5", strParam5, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P6", strParam6, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P7", strParam7, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P8", strParam8, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P9", strParam9, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P10", lngParam10, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P11", strParam11.Value, ORAPARM_OUTPUT)
		
		'データ型をオブジェクトにセット
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(3) = gv_Odb_USR1.Parameters("P3")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(4) = gv_Odb_USR1.Parameters("P4")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(5) = gv_Odb_USR1.Parameters("P5")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(6) = gv_Odb_USR1.Parameters("P6")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(7) = gv_Odb_USR1.Parameters("P7")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(8) = gv_Odb_USR1.Parameters("P8")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(9) = gv_Odb_USR1.Parameters("P9")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(10) = gv_Odb_USR1.Parameters("P10")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(11) = gv_Odb_USR1.Parameters("P11")
		
		'各オブジェクトのデータ型を設定
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(1).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(2).serverType = ORATYPE_VARCHAR2
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(3).serverType = ORATYPE_VARCHAR2
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(4).serverType = ORATYPE_VARCHAR2
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(5).serverType = ORATYPE_VARCHAR2
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(6).serverType = ORATYPE_VARCHAR2
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(7).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(8).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(9).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(10).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(11).serverType = ORATYPE_VARCHAR2
		'PL/SQL呼び出しSQL
		strSQL = "BEGIN HINFP62.MAIN_SUB(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11); End;"
		
		'DBアクセス
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo Ctl_MN_Execute_Click_END
		End If
		
		'エラー情報取得
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngParam10 = param(10).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If Not IsDbNull(param(11).Value) Then
			'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strParam11.Value = param(11).Value
		Else
			strParam11.Value = ""
		End If
		
		Err_Cd = lngParam10
		
		If InStr(strParam11.Value, ":") <> 0 Then
			strlogfile = Trim(Mid(strParam11.Value, InStr(strParam11.Value, ":") + 1))
			strERR_CODE = VB.Left(strParam11.Value, InStr(strParam11.Value, ":") - 1)
		Else
			strERR_CODE = strParam11.Value
		End If
		If lngParam10 = 0 Then
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP62_I_003, pm_All)
		Else
			'ログファイルをサーバから取得する。
			Select Case F_Ctl_CopyFiles2(strlogfile, objFile.ParentFolder.Path)
				Case 0
					'正常
					'ログファイルの削除
					Call F_Ctl_DeleteFiles(strlogfile)
				Case 8
					'INIファイル取得ミス
					strERR_CODE = gc_strMsgHINFP62_E_066
				Case 9
					'コピーができない。
					strERR_CODE = gc_strMsgHINFP62_E_067
			End Select
			If InStr(strERR_CODE, "HINFP62") <> 0 Then
				Call AE_CmnMsgLibrary(SSS_PrgNm, strERR_CODE, pm_All)
			Else
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP62_I_009, pm_All)
			End If
		End If
		
Ctl_MN_Execute_Click_END: 
		'** パラメタ解消
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P4")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P5")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P6")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P7")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P8")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P9")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P10")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P11")
		
		'取込ファイルの削除
		Call F_Ctl_DeleteFiles(strfile)
		
Ctl_MN_Execute_Click_END2: 
		
		'カーソル戻す
		'UPGRADE_ISSUE: Form プロパティ FR_SSSMAIN.MousePointer はカスタム マウスポインタをサポートしません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' をクリックしてください。
		Me.Cursor = intCursor
		
		Exit Sub
err_MN_EXECUTE_Click: 
		'PL/SQLエラー
		AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP62_E_064, pm_All) 'DBエラーがありました。
		'取込ファイルの削除
		Call F_Ctl_DeleteFiles(strfile)
		'カーソル戻す
		'UPGRADE_ISSUE: Form プロパティ FR_SSSMAIN.MousePointer はカスタム マウスポインタをサポートしません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' をクリックしてください。
		Me.Cursor = intCursor
	End Sub
	
	Private Sub TX_Message_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Enter
		System.Windows.Forms.SendKeys.Send("{Tab}")
	End Sub
End Class