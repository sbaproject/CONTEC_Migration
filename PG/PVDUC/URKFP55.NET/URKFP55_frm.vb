Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
'2019/10/14 ADD START
Imports Oracle.DataAccess.Client
Imports PronesDbAccess
'2019/10/14 ADD END
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
    'UPGRADE_WARNING: 配列を New で宣言することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC9D3AE5-6B95-4B43-91C7-28276302A5E8"' をクリックしてください。
    'UPGRADE_ISSUE: Toolbox オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    '2019/10/14 DEL START
    'Dim objim1(1) As New Toolbox
    '2019/10/14 DEL END
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
        '2019/10/14 DEL START
        '      'UPGRADE_ISSUE: P_Mes オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '      Dim objp_msg As New P_Mes
        ''UPGRADE_WARNING: オブジェクト objp_msg.Dsp_Message_Prompt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'CF_Set_Prompt(objp_msg.Dsp_Message_Prompt(gc_strMsgURKFP55_I_007), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black), pm_All)
        '      'UPGRADE_NOTE: オブジェクト objp_msg をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '      objp_msg = Nothing
        '2019/10/14 DEL END
    End Sub
	
	Private Sub CM_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Execute.Click
		MN_EXECUTE_Click(MN_EXECUTE, New System.EventArgs())
	End Sub
	
	Private Sub CM_Execute_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        '2019/10/14 DEL START
        '      'UPGRADE_ISSUE: P_Mes オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '      Dim objp_msg As New P_Mes
        ''UPGRADE_WARNING: オブジェクト objp_msg.Dsp_Message_Prompt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'CF_Set_Prompt(objp_msg.Dsp_Message_Prompt(gc_strMsgURKFP55_I_006), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black), pm_All)
        '      'UPGRADE_NOTE: オブジェクト objp_msg をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '      objp_msg = Nothing
        '2019/10/14 DEL END
    End Sub
	
	Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		Dim I As Short
        If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_I_002, pm_All) = MsgBoxResult.No Then
            Cancel = 1
        Else
            '2019/10/14 DEL START
            'CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
            'For I = 0 To UBound(objim1)
            '    'UPGRADE_NOTE: オブジェクト objim1() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
            '    objim1(I) = Nothing
            'Next
            '2019/10/14 DEL END
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
            '2019/10/14 DEL START
            '.CancelError = True
            '2019/10/14 DEL END
            'UPGRADE_WARNING: オブジェクト CMDialogL.DefaultExt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DefaultExt = gv_strOUT_TYPE
			'UPGRADE_WARNING: オブジェクト CMDialogL.Filter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Filter = "*" & gv_strOUT_TYPE & "|*" & gv_strOUT_TYPE & "|*.*|*.*"
            'UPGRADE_WARNING: オブジェクト CMDialogL.ShowOpen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/10/14 CHG START
            '.ShowOpen()
            .ShowDialog()
            '2019/10/14 CHG END
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
        '2019/10/14 DEL START
        'Dim objgage As New Gage
        '2019/10/14 DEL END
        'DB接続
        Call CF_Ora_USR1_Open() 'USR1
		
		'共通初期化処理
		Call CF_Init()
		pm_All.Dsp_Base.FormCtl = Me
        '2019/10/14 DEL START
        '      pm_All.Dsp_IM_Denkyu = IM_Denkyu(0)
        '      pm_All.On_IM_Denkyu = IM_Denkyu(2)
        'pm_All.Off_IM_Denkyu = IM_Denkyu(1)
        'pm_All.Dsp_TX_Message = TX_Message
        'TX_Message.Tag = 1
        'ReDim pm_All.Dsp_Sub_Inf(1)
        'pm_All.Dsp_Sub_Inf(1).Ctl = TX_Message
        ''
        'CF_Clr_Prompt(pm_All)
        ''UPGRADE_WARNING: オブジェクト objgage.setGage の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'objgage.setGage(Gage, Cmd_cancel)
        ''UPGRADE_WARNING: オブジェクト objgage.ShowGauge の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'objgage.ShowGauge(False)
        ''UPGRADE_NOTE: オブジェクト objgage をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        'objgage = Nothing
        '2019/10/14 DEL END
        HD_TFPATH_B.Text = vbNullString

        '    '画面情報設定
        '    For Each objctrl In Me.Controls
        '        ReDim Preserve objctrl1(I)
        '        objctrl1(I).bind objctrl
        '        I = I + 1
        '    Next
        'UPGRADE_WARNING: オブジェクト objim1().bind の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/10/14 DEL START
        'objim1(0).bind(CM_EndCm, IM_EndCm(0), IM_EndCm(1))
        ''UPGRADE_WARNING: オブジェクト objim1().bind の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'objim1(1).bind(CM_Execute, IM_Execute(0), IM_Execute(1))
        '2019/10/14 DEL END
        gv_strTAB_CHAR = vbTab
		gv_strOUT_TYPE = ".TXT"
        '画面内容初期化
        'UPGRADE_ISSUE: Form プロパティ FR_SSSMAIN.ScaleTop はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        '2019/10/14 DEL START
        'Me.ScaleTop = (VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.ClientRectangle.Height)) / 2
        ''UPGRADE_ISSUE: Form プロパティ FR_SSSMAIN.ScaleLeft はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        'Me.ScaleLeft = (VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.ClientRectangle.Width)) / 2
        '2019/10/14 DEL END
        Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
		Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
        'UPGRADE_WARNING: オブジェクト SYSDT.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/10/14 CHG START
        'SYSDT.Caption = VB6.Format(GV_UNYDate, "@@@@/@@/@@")
        SYSDT.Text = VB6.Format(GV_UNYDate, "@@@@/@@/@@")
        '2019/10/14 CHG END
        HD_IN_TANCD.Text = Inp_Inf.InpTanCd
        HD_IN_TANNM.Text = Inp_Inf.InpTanNm

        '2019/10/14 ADD START
        SetBar(Me)
        '2019/10/14 ADD END

        Exit Sub
Error_Handler:
        'ロールバック
        If bolTrans Then
            '2019/10/14 DEL START
            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
            '2019/10/14 DEL END
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
		Dim strParam2 As New VB6.FixedLengthString(2)
		Dim strParam3 As String
		Dim strParam4 As String
		Dim strParam5 As String
		Dim strParam6 As String
		Dim strParam7 As String
		Dim strParam8 As String
		Dim strParam9 As String
		Dim strParam10 As String
		Dim lngParam11 As Integer
		Dim strParam12 As New VB6.FixedLengthString(3000)
		'UPGRADE_ISSUE: OraParameter オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim param(13) As OraParameter 'PL/SQLのバインド変数
		Dim bolRet As Boolean
        Dim intret As Short
        '2019/10/14 CHG START
        'Dim intCursor As Short
        Dim intCursor As Cursor
        '2019/10/14 CHG END
        Dim Err_Cd As Integer
		Dim strlogfile As String 'ログファイル名
		Dim strSVfolder As String
		Dim strERR_CODE As String
		Dim strLocalPath As String 'サーバ側のローカルパス変数
		Dim strNYUKINKB As New VB6.FixedLengthString(2)

        '2019/10/14 DEL START
        'On Error GoTo err_MN_EXECUTE_Click
        '2019/10/14 DEL END

        '2019/10/14 ADD START
        Try
            '2019/10/14 ADD END

            If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_I_001, pm_All) = MsgBoxResult.No Then
                AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_I_004, pm_All)
                Exit Sub
            End If
            'ファイルの存在可否
            If objfso.FileExists(HD_TFPATH_B.Text) Then
            Else
                '存在しないとき終了する。
                AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_I_008, pm_All)
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
                    AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_E_022, pm_All)
                    Exit Sub
                Case 9
                    'コピーができない
                    AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_E_023, pm_All)
                    Exit Sub
            End Select
            'サーバのローカルパスを取得する。
            If Get_INIFile_String(My.Application.Info.DirectoryPath & IIf(VB.Right(My.Application.Info.DirectoryPath, 1) = "\", "", "\") & SSS_PrgId & ".INI", "PATH", "ServerLocalLOG", strLocalPath) Then
            Else
                AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_E_022, pm_All)
                Exit Sub
            End If
            '=== 20110517 === INSERT S TOM)Morimoto
            '入金種別を取得する。
            If Get_INIFile_String(My.Application.Info.DirectoryPath & IIf(VB.Right(My.Application.Info.DirectoryPath, 1) = "\", "", "\") & SSS_PrgId & ".INI", "PROPERTY", "入金種別", strNYUKINKB.Value) Then
            Else
                AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_E_022, pm_All)
                Exit Sub
            End If
            '=== 20110517 === INSERT E
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
            strParam2.Value = strNYUKINKB.Value
            strParam3 = strLocalPath
            strParam4 = objfso.GetFile(strfile).ParentFolder.Path
            strParam5 = objfso.GetFileName(strfile)
            strParam6 = SSS_CLTID.Value
            strParam7 = SSS_OPEID.Value
            strParam8 = GV_SysDate
            strParam9 = GV_SysTime
            strParam10 = GV_UNYDate
            lngParam11 = 0
            strParam12.Value = ""

            '2019/10/14 ADD START

            Dim cmd As New OracleCommand

            cmd.Connection = CON

            cmd.CommandType = CommandType.StoredProcedure

            '2019/10/14 ADD END

            '2019/10/14 CHG START

            '      'PL/SQLを実行する。
            '      'パラメータの初期設定を行う（バインド変数）
            '      'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '      gv_Odb_USR1.Parameters.Add("P1", lngParam1, ORAPARM_INPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P2", strParam2.Value, ORAPARM_INPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P3", strParam3, ORAPARM_INPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P4", strParam4, ORAPARM_INPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P5", strParam5, ORAPARM_INPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P6", strParam6, ORAPARM_INPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P7", strParam7, ORAPARM_INPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P8", strParam8, ORAPARM_INPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P9", strParam9, ORAPARM_INPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P10", strParam10, ORAPARM_INPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P11", lngParam11, ORAPARM_OUTPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P12", strParam12.Value, ORAPARM_OUTPUT)

            ''データ型をオブジェクトにセット
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(1) = gv_Odb_USR1.Parameters("P1")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(2) = gv_Odb_USR1.Parameters("P2")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(3) = gv_Odb_USR1.Parameters("P3")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(4) = gv_Odb_USR1.Parameters("P4")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(5) = gv_Odb_USR1.Parameters("P5")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(6) = gv_Odb_USR1.Parameters("P6")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(7) = gv_Odb_USR1.Parameters("P7")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(8) = gv_Odb_USR1.Parameters("P8")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(9) = gv_Odb_USR1.Parameters("P9")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(10) = gv_Odb_USR1.Parameters("P10")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(11) = gv_Odb_USR1.Parameters("P11")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(12) = gv_Odb_USR1.Parameters("P12")

            ''各オブジェクトのデータ型を設定
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(1).serverType = ORATYPE_NUMBER
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(2).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(3).serverType = ORATYPE_VARCHAR2
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(4).serverType = ORATYPE_VARCHAR2
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(5).serverType = ORATYPE_VARCHAR2
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(6).serverType = ORATYPE_VARCHAR2
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(7).serverType = ORATYPE_VARCHAR2
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(8).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(9).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(10).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(11).serverType = ORATYPE_NUMBER
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(12).serverType = ORATYPE_VARCHAR2
            '      'PL/SQL呼び出しSQL
            '      strSQL = "BEGIN " & SSS_PrgId & ".MAIN_SUB(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11,:P12); End;"


            Dim inP1 As OracleParameter = New OracleParameter
            inP1.ParameterName = "P1"
            inP1.Direction = ParameterDirection.Input
            inP1.Value = lngParam1
            cmd.Parameters.Add(inP1)

            Dim inP2 As OracleParameter = New OracleParameter
            inP2.ParameterName = "P2"
            inP2.Direction = ParameterDirection.Input
            inP2.Value = strParam2.Value
            cmd.Parameters.Add(inP2)

            Dim inP3 As OracleParameter = New OracleParameter
            inP3.ParameterName = "P3"
            inP3.Direction = ParameterDirection.Input
            inP3.Value = strParam3
            cmd.Parameters.Add(inP3)

            Dim inP4 As OracleParameter = New OracleParameter
            inP4.ParameterName = "P4"
            inP4.Direction = ParameterDirection.Input
            inP4.Value = strParam4
            cmd.Parameters.Add(inP4)

            Dim inP5 As OracleParameter = New OracleParameter
            inP5.ParameterName = "P5"
            inP5.Direction = ParameterDirection.Input
            inP5.Value = strParam5
            cmd.Parameters.Add(inP5)

            Dim inP6 As OracleParameter = New OracleParameter
            inP6.ParameterName = "P6"
            inP6.Direction = ParameterDirection.Input
            inP6.Value = strParam6
            cmd.Parameters.Add(inP6)

            Dim inP7 As OracleParameter = New OracleParameter
            inP7.ParameterName = "P7"
            inP7.Direction = ParameterDirection.Input
            inP7.Value = strParam7
            cmd.Parameters.Add(inP7)

            Dim inP8 As OracleParameter = New OracleParameter
            inP8.ParameterName = "P8"
            inP8.Direction = ParameterDirection.Input
            inP8.Value = strParam8
            cmd.Parameters.Add(inP8)

            Dim inP9 As OracleParameter = New OracleParameter
            inP9.ParameterName = "P9"
            inP9.Direction = ParameterDirection.Input
            inP9.Value = strParam9
            cmd.Parameters.Add(inP9)

            Dim inP10 As OracleParameter = New OracleParameter
            inP10.ParameterName = "P10"
            inP10.Direction = ParameterDirection.Input
            inP10.Value = strParam10
            cmd.Parameters.Add(inP10)

            Dim outP11 As OracleParameter = New OracleParameter
            outP11.ParameterName = "P11"
            outP11.Direction = ParameterDirection.Output
            outP11.Value = lngParam11
            cmd.Parameters.Add(outP11)

            Dim outP12 As OracleParameter = New OracleParameter
            outP12.ParameterName = "P12"
            outP12.Direction = ParameterDirection.Output
            outP12.Value = strParam12.Value
            cmd.Parameters.Add(outP12)

            inP1.OracleDbType = OracleDbType.Decimal
            inP2.OracleDbType = OracleDbType.Char
            inP3.OracleDbType = OracleDbType.Varchar2
            inP4.OracleDbType = OracleDbType.Varchar2
            inP5.OracleDbType = OracleDbType.Varchar2
            inP6.OracleDbType = OracleDbType.Varchar2
            inP7.OracleDbType = OracleDbType.Varchar2
            inP8.OracleDbType = OracleDbType.Char
            inP9.OracleDbType = OracleDbType.Char
            inP10.OracleDbType = OracleDbType.Char
            outP11.OracleDbType = OracleDbType.Decimal
            outP12.OracleDbType = OracleDbType.Varchar2

            cmd.CommandText = SSS_PrgId & ".MAIN_SUB"

            '2019/10/14 CHG END


            '2019/10/14 CHG START
            'DBアクセス
            'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
            'If bolRet = False Then
            '    GoTo Ctl_MN_Execute_Click_END
            'End If
            cmd.ExecuteNonQuery()
            '2019/10/14 CHG END

            '2019/10/14 CHG START
            'エラー情報取得
            'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'lngParam11 = param(11).Value
            ''UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'If Not IsDbNull(param(12).Value) Then
            '    'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    strParam12.Value = param(12).Value
            'Else
            '    strParam12.Value = ""
            'End If

            lngParam11 = outP11.Value.ToString()

            If Not IsDBNull(outP12.Value.ToString()) Then
                strParam12.Value = outP12.Value.ToString()
            Else
                strParam12.Value = ""
            End If

            '2019/10/14 CHG END

            Err_Cd = lngParam11

            If InStr(strParam12.Value, ":") <> 0 Then
                strlogfile = Trim(Mid(strParam12.Value, InStr(strParam12.Value, ":") + 1))
                strERR_CODE = VB.Left(strParam12.Value, InStr(strParam12.Value, ":") - 1)
                'ログファイルをサーバから取得する。
                Select Case F_Ctl_CopyFiles2(strlogfile, objFile.ParentFolder.Path)
                    Case 0
                        '正常
                        'ログファイルの削除
                        Call F_Ctl_DeleteFiles(strlogfile)
                        If lngParam11 = 0 Then
                            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_I_003, pm_All)
                        Else
                            If InStr(strERR_CODE, SSS_PrgId) <> 0 Then
                                Call AE_CmnMsgLibrary(SSS_PrgNm, strERR_CODE, pm_All)
                            Else
                                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_I_009, pm_All)
                            End If
                        End If
                    Case 8
                        'INIファイル取得ミス
                        strERR_CODE = gc_strMsgURKFP55_E_022
                    Case 9
                        'コピーができない。
                        strERR_CODE = gc_strMsgURKFP55_E_023
                End Select
            Else
                strERR_CODE = strParam12.Value
                If lngParam11 = 0 Then
                    Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_I_003, pm_All)
                Else
                    If InStr(strERR_CODE, SSS_PrgId) <> 0 Then
                        Call AE_CmnMsgLibrary(SSS_PrgNm, strERR_CODE, pm_All)
                    Else
                        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_I_009, pm_All)
                    End If
                End If
            End If

            '2019/10/14 CHG START

            'Ctl_MN_Execute_Click_END: 
            '		'** パラメタ解消
            '		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		gv_Odb_USR1.Parameters.Remove("P1")
            '		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		gv_Odb_USR1.Parameters.Remove("P2")
            '		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		gv_Odb_USR1.Parameters.Remove("P3")
            '		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		gv_Odb_USR1.Parameters.Remove("P4")
            '		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		gv_Odb_USR1.Parameters.Remove("P5")
            '		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		gv_Odb_USR1.Parameters.Remove("P6")
            '		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		gv_Odb_USR1.Parameters.Remove("P7")
            '		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		gv_Odb_USR1.Parameters.Remove("P8")
            '		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		gv_Odb_USR1.Parameters.Remove("P9")
            '		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		gv_Odb_USR1.Parameters.Remove("P10")
            '		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		gv_Odb_USR1.Parameters.Remove("P11")
            '		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		gv_Odb_USR1.Parameters.Remove("P12")

            cmd.Parameters.Clear()

            '2019/10/14 CHG END

            '取込ファイルの削除
            Call F_Ctl_DeleteFiles(strfile)

            '2019/10/14 CHG START

            'Ctl_MN_Execute_Click_END2: 

            '		'カーソル戻す
            '		'UPGRADE_ISSUE: Form プロパティ FR_SSSMAIN.MousePointer はカスタム マウスポインタをサポートしません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' をクリックしてください。
            '		Me.Cursor = intCursor

            '		Exit Sub
            'err_MN_EXECUTE_Click: 
            '		'PL/SQLエラー
            '		AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_E_019, pm_All) 'DBエラーがありました。
            '		'取込ファイルの削除
            '		Call F_Ctl_DeleteFiles(strfile)
            '		'カーソル戻す
            '		'UPGRADE_ISSUE: Form プロパティ FR_SSSMAIN.MousePointer はカスタム マウスポインタをサポートしません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' をクリックしてください。
            '		Me.Cursor = intCursor

            Me.Cursor = intCursor

        Catch ex As Exception

            AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_E_019, pm_All) 'DBエラーがありました。

            Call F_Ctl_DeleteFiles(strfile)

            'カーソル戻す
            Me.Cursor = intCursor
        End Try

        '2019/10/14 CHG END
    End Sub
	
	Private Sub TX_Message_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Enter
		System.Windows.Forms.SendKeys.Send("{Tab}")
	End Sub

    '2019/10/14 ADD START
    Private Sub btnF1_Click(sender As Object, e As EventArgs) Handles btnF1.Click
        MN_EXECUTE_Click(MN_EXECUTE, New System.EventArgs())
    End Sub

    Private Sub btnF9_Click(sender As Object, e As EventArgs) Handles btnF9.Click
        Call MN_APPENDC_Click(MN_EndCm, New System.EventArgs())
    End Sub

    Private Sub btnF12_Click(sender As Object, e As EventArgs) Handles btnF12.Click
        Call MN_EndCm_Click(MN_EndCm, New System.EventArgs())
    End Sub

    Private Sub FR_SSSMAIN_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F1
                    '更新
                    Me.btnF1.PerformClick()

                Case Keys.F9
                    'クリア
                    Me.btnF9.PerformClick()

                Case Keys.F12
                    '終了
                    Me.btnF12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("フォームKeyDownエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub

    Private Sub CS_TFPATH_B_Click(sender As Object, e As EventArgs) Handles CS_TFPATH_B.Click
        Call CS_TFPATH_B_Click()
    End Sub

    Private Sub Cmd_cancel_Click(sender As Object, e As EventArgs) Handles Cmd_cancel.Click

    End Sub

    '2019/10/14 ADD END
End Class