Option Strict Off
Option Explicit On
Friend Class FR_SSSMAIN
    Inherits System.Windows.Forms.Form
    'UPGRADE_WARNING: 配列を New で宣言することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC9D3AE5-6B95-4B43-91C7-28276302A5E8"' をクリックしてください。
    'UPGRADE_ISSUE: ctrl オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    '2019.04.05 DEL START
    'Dim objctrl1() As New ctrl
    'UPGRADE_WARNING: 配列を New で宣言することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC9D3AE5-6B95-4B43-91C7-28276302A5E8"' をクリックしてください。
    'UPGRADE_ISSUE: Toolbox オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    'Dim objim1(1) As New Toolbox
    '2019.04.05 DEL END
    'UPGRADE_WARNING: 構造体 pm_All の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    Dim pm_All As Cls_All
    Dim bolStop_flg As Boolean

    '2019.04.26 add start
    Dim clearTag As Integer
    '2019.04.26 add end

    'ツールボックスの終了ボタン
    Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        '2019.04.22 del start
        'MN_EndCm_Click(MN_EndCm, New System.EventArgs())
        '2019.04.22 del end
    End Sub

    Private Sub CM_EndCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        'UPGRADE_ISSUE: P_Mes オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019.04.05 DEL START
        'Dim objp_msg As New P_Mes
        'UPGRADE_WARNING: オブジェクト objp_msg.Dsp_Message_Prompt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'CF_Set_Prompt(objp_msg.Dsp_Message_Prompt(gc_strMsgHINFP61_I_007), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black), pm_All)
        ''UPGRADE_NOTE: オブジェクト objp_msg をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        'objp_msg = Nothing
        '2019.04.05 DEL END
    End Sub

    'ツールボックスの実行ボタン
    Private Sub CM_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        gv_objctrl = gv_obja_ctrl
        '2019.04.22 del start
        'MN_EXECUTE_Click(MN_EXECUTE, New System.EventArgs())
        '2019.04.22 del end
    End Sub

    Private Sub CM_Execute_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        'UPGRADE_ISSUE: P_Mes オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019.04.05 DEL START
        'Dim objp_msg As New P_Mes
        'UPGRADE_WARNING: オブジェクト objp_msg.Dsp_Message_Prompt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'CF_Set_Prompt(objp_msg.Dsp_Message_Prompt(gc_strMsgHINFP61_I_006), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black), pm_All)
        ''UPGRADE_NOTE: オブジェクト objp_msg をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        'objp_msg = Nothing
        '2019.04.05 DEL END
    End Sub

    Private Sub cmd_Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmd_Cancel.Click
        'ファイル出力中、中止のときの処理
        bolStop_flg = True
    End Sub

    Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim I As Short
        Dim objctrl As System.Windows.Forms.Control
        Dim pot_Inp_Inf As Cmn_Inp_Inf
        Dim bolRet As Boolean
        Dim strMsgCd As String
        Dim bolTrans As Boolean
        'UPGRADE_ISSUE: Gage オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019.04.05 DEL START
        'Dim objgage As New Gage
        '2019.04.05 DEL END
        '2019.04.02 ADD START
        Dim Index_Wk As Short = 0
        '2019.04.02 ADD END 

        'DB接続
        Call CF_Ora_USR1_Open() 'USR1

        '共通初期化処理
        Call CF_Init()
        pm_All.Dsp_Base.FormCtl = Me
        '2019.04.22 del start
        'pm_All.Dsp_IM_Denkyu = IM_Denkyu(0)
        'pm_All.On_IM_Denkyu = IM_Denkyu(2)
        'pm_All.Off_IM_Denkyu = IM_Denkyu(1)
        'pm_All.Dsp_TX_Message = TX_Message
        'TX_Message.Tag = 1
        'ReDim pm_All.Dsp_Sub_Inf(1)
        'pm_All.Dsp_Sub_Inf(1).Ctl = TX_Message
        '2019.04.05 DEL END

        '2019.04.22 del start 仮
        'CF_Clr_Prompt(pm_All)
        '2019.04.22 del end
        '2019.04.05 DEL START
        'UPGRADE_WARNING: オブジェクト objgage.setGage の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'objgage.setGage(Gage, cmd_Cancel)
        ''UPGRADE_WARNING: オブジェクト objgage.ShowGauge の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'objgage.ShowGauge(False)
        ''UPGRADE_NOTE: オブジェクト objgage をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        'objgage = Nothing
        '2019.04.05 DEL END

        '    '画面情報設定
        For Each objctrl In Me.Controls
            '2019.04.05 DEL START
            'ReDim Preserve objctrl1(I)
            ''UPGRADE_WARNING: オブジェクト objctrl1().bind の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'objctrl1(I).bind(objctrl)
            '2019.04.05 DEL END
            I = I + 1
        Next objctrl
        'UPGRADE_WARNING: オブジェクト objim1().bind の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019.04.05 DEL START
        'objim1(0).bind(CM_EndCm, IM_EndCm(0), IM_EndCm(1))
        ''UPGRADE_WARNING: オブジェクト objim1().bind の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'objim1(1).bind(CM_Execute, IM_Execute(0), IM_Execute(1))
        '2019.04.05 DEL END
        gv_strTAB_CHAR = vbTab
        gv_strOUT_TYPE = ".TXT"
        '画面内容初期化
        'UPGRADE_ISSUE: Form プロパティ FR_SSSMAIN.ScaleTop はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        '2019.04.05 DEL START
        'Me.ScaleTop = (VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.ClientRectangle.Height)) / 2
        ''UPGRADE_ISSUE: Form プロパティ FR_SSSMAIN.ScaleLeft はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        'Me.ScaleLeft = (VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.ClientRectangle.Width)) / 2
        '2019.04.05 DEL END
        Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
        Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
        'UPGRADE_WARNING: オブジェクト SYSDT.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019.04.05 CHG START
        'SYSDT.Caption = VB6.Format(GV_UNYDate, "@@@@/@@/@@")
        SYSDT.Text = VB6.Format(GV_UNYDate, "@@@@/@@/@@")
        '2019.04.05 CHG END
        HD_IN_TANCD.Text = Inp_Inf.InpTanCd
        HD_IN_TANNM.Text = Inp_Inf.InpTanNm
        '2019.04.05 ADD START
        cmd_Cancel.Visible = False
        '2019.04.05 ADD END
        '2019.04.02 ADD START
        set_enable(True)
        SetBar(Me)
        'ファンクションキーのインデックスの設定
        Index_Wk += 1
        HD_HINKB.Tag = Index_Wk
        Index_Wk += 1
        HD_ZAIKB.Tag = Index_Wk
        Index_Wk += 1
        HD_BTOKB.Tag = Index_Wk
        Index_Wk += 1
        HD_MLOKB.Tag = Index_Wk
        Index_Wk += 1
        HD_CTLGKB.Tag = Index_Wk
        Index_Wk += 1
        HD_OPENKB.Tag = Index_Wk
        Index_Wk += 1
        HD_OEMKB.Tag = Index_Wk
        Index_Wk += 1
        'change 20190830 start hou
        'Button1.Tag = Index_Wk
        Button11.Tag = Index_Wk
        'change 20190830 end hou
        Index_Wk += 1
        Button9.Tag = Index_Wk
        Index_Wk += 1
        Button12.Tag = Index_Wk
        '2019.04.02 ADD END
        Exit Sub
Error_Handler:
        'ロールバック
        If bolTrans Then
            '2019.04.05 DEL START
            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
            '2019.04.05 DEL END
        End If
        bolTrans = False


    End Sub

    Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        Dim I As Short
        If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_I_002, pm_All) = MsgBoxResult.No Then
            Cancel = 1
        Else
            '2019.04.05 DEL START
            'CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
            ''        For I = 0 To UBound(objctrl1)
            ''            Set objctrl1(I) = Nothing
            ''        Next
            'For I = 0 To UBound(objim1)
            '    'UPGRADE_NOTE: オブジェクト objim1() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
            '    objim1(I) = Nothing
            'Next
            '2019.04.05 DEL END
        End If
        eventArgs.Cancel = Cancel
    End Sub

    '提供区分のチェック
    Private Sub HD_BTOKB_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles HD_BTOKB.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        'UPGRADE_ISSUE: P_Mes オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019.04.05 DEL START
        'Dim objp_msg As New P_Mes
        '2019.04.05 DEL END
        With HD_BTOKB
            Select Case .Text
                Case "1", "9", "0"
                    .ForeColor = System.Drawing.Color.Black
                    '2019.04.22 del start
                    'CF_Clr_Prompt(pm_All)
                    '2019.04.22 del end
                Case Else
                    .BackColor = System.Drawing.Color.White
                    .ForeColor = System.Drawing.Color.Red
                    'UPGRADE_WARNING: オブジェクト objp_msg.Dsp_Message_Prompt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019.04.05 DEL START
                    'CF_Set_Prompt(objp_msg.Dsp_Message_Prompt(gc_strMsgHINFP61_E_008), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red), pm_All)
                    '2019.04.05 DEL END
                    '2019.04.26 add start
                    showMessage(gc_strMsgHINFP61_E_008, 0)
                    '2019.04.26 add end
                    .SelectionStart = 0
                    .SelectionLength = Len(.Text)
                    Cancel = True
            End Select
        End With
        'UPGRADE_NOTE: オブジェクト objp_msg をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '2019.04.05 DEL START
        'objp_msg = Nothing
        '2019.04.05 DEL END
        eventArgs.Cancel = Cancel
    End Sub

    'カタログ対象のチェック
    Private Sub HD_CTLGKB_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles HD_CTLGKB.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        'UPGRADE_ISSUE: P_Mes オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019.04.05 DEL START
        'Dim objp_msg As New P_Mes
        '2019.04.05 DEL END
        With HD_CTLGKB
            Select Case .Text
                Case "1", "9", "0"
                    .ForeColor = System.Drawing.Color.Black
                    '2019.04.22 del start
                    'CF_Clr_Prompt(pm_All)
                    '2019.04.22 del end
                Case Else
                    .BackColor = System.Drawing.Color.White
                    .ForeColor = System.Drawing.Color.Red
                    'UPGRADE_WARNING: オブジェクト objp_msg.Dsp_Message_Prompt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019.04.05 DEL START
                    'CF_Set_Prompt(objp_msg.Dsp_Message_Prompt(gc_strMsgHINFP61_E_008), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red), pm_All)
                    '2019.04.05 DEL END
                    '2019.04.26 add start
                    showMessage(gc_strMsgHINFP61_E_008, 0)
                    '2019.04.26 add end
                    .SelectionStart = 0
                    .SelectionLength = Len(.Text)
                    Cancel = True
            End Select
        End With
        'UPGRADE_NOTE: オブジェクト objp_msg をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '2019.04.05 DEL START
        'objp_msg = Nothing
        '2019.04.05 DEL END
        eventArgs.Cancel = Cancel
    End Sub

    '商品区分のチェック
    Private Sub HD_HINKB_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles HD_HINKB.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        'UPGRADE_ISSUE: P_Mes オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019.04.05 DEL START
        'Dim objp_msg As New P_Mes
        '2019.04.05 DEL END
        With HD_HINKB
            Select Case .Text
                Case "1", "9", "5", "2", "3", "4"
                    .ForeColor = System.Drawing.Color.Black
                    '2019.04.22 del start
                    'CF_Clr_Prompt(pm_All)
                    '2019.04.22 del end
                Case Else
                    .BackColor = System.Drawing.Color.White
                    .ForeColor = System.Drawing.Color.Red
                    'UPGRADE_WARNING: オブジェクト objp_msg.Dsp_Message_Prompt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019.04.05 DEL START
                    'CF_Set_Prompt(objp_msg.Dsp_Message_Prompt(gc_strMsgHINFP61_E_008), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red), pm_All)
                    '2019.04.05 DEL END
                    '2019.04.26 add start
                    showMessage(gc_strMsgHINFP61_E_008, 0)
                    '2019.04.26 add end
                    .SelectionStart = 0
                    .SelectionLength = Len(.Text)
                    Cancel = True
            End Select
        End With
        'UPGRADE_NOTE: オブジェクト objp_msg をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '2019.04.05 DEL START
        'objp_msg = Nothing
        '2019.04.05 DEL END
        eventArgs.Cancel = Cancel
    End Sub

    '通販対象のチェック
    Private Sub HD_MLOKB_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles HD_MLOKB.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        'UPGRADE_ISSUE: P_Mes オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019.04.05 DEL START
        'Dim objp_msg As New P_Mes
        '2019.04.05 DEL END
        With HD_MLOKB
            Select Case .Text
                Case "1", "9", "0"
                    .ForeColor = System.Drawing.Color.Black
                    '2019.04.22 del start
                    'CF_Clr_Prompt(pm_All)
                    '2019.04.22 del end
                Case Else
                    .BackColor = System.Drawing.Color.White
                    .ForeColor = System.Drawing.Color.Red
                    'UPGRADE_WARNING: オブジェクト objp_msg.Dsp_Message_Prompt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019.04.05 DEL START
                    'CF_Set_Prompt(objp_msg.Dsp_Message_Prompt(gc_strMsgHINFP61_E_008), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red), pm_All)
                    '2019.04.05 DEL END
                    '2019.04.26 add start
                    showMessage(gc_strMsgHINFP61_E_008, 0)
                    '2019.04.26 add end
                    .SelectionStart = 0
                    .SelectionLength = Len(.Text)
                    Cancel = True
            End Select
        End With
        'UPGRADE_NOTE: オブジェクト objp_msg をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '2019.04.05 DEL START
        'objp_msg = Nothing
        '2019.04.05 DEL END
        eventArgs.Cancel = Cancel
    End Sub

    'OEM区分のチェック
    Private Sub HD_OEMKB_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles HD_OEMKB.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        'UPGRADE_ISSUE: P_Mes オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019.04.05 DEL START
        'Dim objp_msg As New P_Mes
        '2019.04.05 DEL END
        With HD_OEMKB
            Select Case .Text
                Case "1", "9", "0"
                    .ForeColor = System.Drawing.Color.Black
                    '2019.04.22 del start
                    'CF_Clr_Prompt(pm_All)
                    '2019.04.22 del end
                Case Else
                    .BackColor = System.Drawing.Color.White
                    .ForeColor = System.Drawing.Color.Red
                    'UPGRADE_WARNING: オブジェクト objp_msg.Dsp_Message_Prompt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019.04.05 DEL START
                    'CF_Set_Prompt(objp_msg.Dsp_Message_Prompt(gc_strMsgHINFP61_E_008), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red), pm_All)
                    '2019.04.05 DEL END
                    '2019.04.26 add start
                    showMessage(gc_strMsgHINFP61_E_008, 0)
                    '2019.04.26 add end
                    .SelectionStart = 0
                    .SelectionLength = Len(.Text)
                    Cancel = True
            End Select
        End With
        'UPGRADE_NOTE: オブジェクト objp_msg をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '2019.04.05 DEL START
        'objp_msg = Nothing
        '2019.04.05 DEL END
        eventArgs.Cancel = Cancel
    End Sub

    '価格区分のチェック
    Private Sub HD_OPENKB_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles HD_OPENKB.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        'UPGRADE_ISSUE: P_Mes オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019.04.05 DEL START
        'Dim objp_msg As New P_Mes
        '2019.04.05 DEL END
        With HD_OPENKB
            Select Case .Text
                Case "1", "9", "0"
                    .ForeColor = System.Drawing.Color.Black
                    '2019.04.22 del start
                    'CF_Clr_Prompt(pm_All)
                    '2019.04.22 del end
                Case Else
                    .BackColor = System.Drawing.Color.White
                    .ForeColor = System.Drawing.Color.Red
                    'UPGRADE_WARNING: オブジェクト objp_msg.Dsp_Message_Prompt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019.04.05 DEL START
                    'CF_Set_Prompt(objp_msg.Dsp_Message_Prompt(gc_strMsgHINFP61_E_008), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red), pm_All)
                    '2019.04.05 DEL END
                    '2019.04.26 add start
                    showMessage(gc_strMsgHINFP61_E_008, 0)
                    '2019.04.26 add end
                    .SelectionStart = 0
                    .SelectionLength = Len(.Text)
                    Cancel = True
            End Select
        End With
        'UPGRADE_NOTE: オブジェクト objp_msg をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '2019.04.05 DEL START
        'objp_msg = Nothing
        '2019.04.05 DEL END
        eventArgs.Cancel = Cancel
    End Sub

    '在庫区分のチェック
    Private Sub HD_ZAIKB_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles HD_ZAIKB.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        'UPGRADE_ISSUE: P_Mes オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019.04.05 DEL START
        'Dim objp_msg As New P_Mes
        '2019.04.05 DEL END
        With HD_ZAIKB
            Select Case .Text
                Case "1", "9", "0"
                    .ForeColor = System.Drawing.Color.Black
                    '2019.04.22 del start
                    'CF_Clr_Prompt(pm_All)
                    '2019.04.22 del end
                Case Else
                    .BackColor = System.Drawing.Color.White
                    .ForeColor = System.Drawing.Color.Red
                    'UPGRADE_WARNING: オブジェクト objp_msg.Dsp_Message_Prompt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019.04.05 DEL START
                    'CF_Set_Prompt(objp_msg.Dsp_Message_Prompt(gc_strMsgHINFP61_E_008), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red), pm_All)
                    '2019.04.05 DEL END
                    '2019.04.26 add start
                    showMessage(gc_strMsgHINFP61_E_008, 0)
                    '2019.04.26 add end
                    .SelectionStart = 0
                    .SelectionLength = Len(.Text)
                    Cancel = True
            End Select
        End With
        'UPGRADE_NOTE: オブジェクト objp_msg をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '2019.04.05 DEL START
        'objp_msg = Nothing
        '2019.04.05 DEL END
        eventArgs.Cancel = Cancel
    End Sub

    Private Sub Image1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        '2019.04.22 del start
        'CF_Clr_Prompt(pm_All)
        '2019.04.22 del end
    End Sub

    '初期設定
    Public Sub MN_APPENDC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'UPGRADE_ISSUE: P_Mes オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019.04.05 DEL START
        'Dim objp_msg As New P_Mes
        '2019.04.05 DEL END
        Dim objtxt As System.Windows.Forms.Control
        Dim strName As String
        For Each objtxt In Me.Controls
            'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            If TypeOf objtxt Is System.Windows.Forms.TextBox Then
                If System.Drawing.ColorTranslator.ToOle(HD_HINKB.BackColor) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow) Or System.Drawing.ColorTranslator.ToOle(HD_HINKB.ForeColor) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red) Then
                    strName = objtxt.Name
                End If
                Select Case objtxt.Name
                    Case "HD_IN_TANCD"
                    Case "HD_IN_TANNM"
                    Case "TX_Message"
                    Case "HD_HINKB", "HD_ZAIKB"
                        With objtxt
                            .Text = "1"
                            .BackColor = System.Drawing.Color.White
                            .ForeColor = System.Drawing.Color.Black
                        End With
                    Case Else
                        With objtxt
                            .Text = "0"
                            .BackColor = System.Drawing.Color.White
                            .ForeColor = System.Drawing.Color.Black
                        End With
                End Select
            End If
        Next objtxt
        If strName = "HD_HINKB" Then
            TX_CursorRest.Focus()
        End If
        HD_HINKB.Focus()
    End Sub

    '処理終了
    Public Sub MN_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Me.Close()
    End Sub

    '処理実行
    Public Sub MN_EXECUTE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim strSQL As String
        Dim strSQL2 As String
        'UPGRADE_WARNING: 構造体 objUdy の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim objUdy As U_Ody
        'UPGRADE_WARNING: 構造体 objUdy1 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim objUdy1 As U_Ody
        Dim I As Short
        Dim strdmy() As String
        Dim j As Integer
        Dim objfso As New Scripting.FileSystemObject
        Dim objstream As Scripting.TextStream
        Dim strf_name As String
        'UPGRADE_ISSUE: Gage オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019.04.05 DEL START
        'Dim objgage As Gage
        '2019.04.05 DEL END
        Dim recordcount As Integer
        On Error GoTo err_MN_EXECUTE_Click
        If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_I_001, pm_All) = MsgBoxResult.No Then
            gv_objctrl.Focus()
            Exit Sub
        End If
        'UPGRADE_WARNING: オブジェクト CMDialogL.DefaultExt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019.04.05 DEL START
        '      CMDialogL.DefaultExt = gv_strOUT_TYPE 'ファイル拡張子の既定値
        ''UPGRADE_WARNING: オブジェクト CMDialogL.Filter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'CMDialogL.Filter = "*" & gv_strOUT_TYPE & "|*" & gv_strOUT_TYPE & "|*.*|*.*"
        ''UPGRADE_WARNING: オブジェクト CMDialogL.CancelError の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'CMDialogL.CancelError = True
        ''UPGRADE_WARNING: オブジェクト CMDialogL.ShowSave の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'CMDialogL.ShowSave()
        ''UPGRADE_WARNING: オブジェクト CMDialogL.FileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'strf_name = CMDialogL.FileName
        '2019.04.05 DEL END
        If Len(strf_name) = 0 Then
            gv_objctrl.Focus()
            AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_I_004, pm_All)
            Exit Sub
        Else
        End If
        If objfso.FileExists(strf_name) = True Then
            If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_I_005, pm_All) = MsgBoxResult.No Then
                gv_objctrl.Focus()
                AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_I_004, pm_All)
                Exit Sub
            End If
        End If
        '2019.04.05 DEL START
        'CM_Execute.Visible = False
        'objgage = New Gage
        'UPGRADE_WARNING: オブジェクト objgage.setGage の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'objgage.setGage(Gage, cmd_Cancel)
        'UPGRADE_WARNING: オブジェクト objgage.ShowGauge の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'objgage.ShowGauge(True)
        ''UPGRADE_WARNING: オブジェクト objgage.InitGauge の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'objgage.InitGauge()
        '2019.04.05 DEL END
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        cmd_Cancel.Enabled = True
        cmd_Cancel.Focus()
        set_enable(False)
        strSQL2 = vbNullString
        strSQL2 = strSQL2 & " select "
        strSQL2 = strSQL2 & "DATKB        as  ""未使用01"" ,"
        strSQL2 = strSQL2 & "HINMSTKB     as  ""未使用02"" ,"
        strSQL2 = strSQL2 & "HINCD        as  ""製品コード"" ,"
        strSQL2 = strSQL2 & "HINNMA       as  ""型式"" ,"
        strSQL2 = strSQL2 & "HINNMB       as  ""＊品名１"" ,"
        strSQL2 = strSQL2 & "HINNMC       as  ""未使用03"" ,"
        strSQL2 = strSQL2 & "HINNK        as  ""品名カナ"" ,"
        strSQL2 = strSQL2 & "HINNMD       as  ""シリーズ商品名（半角）"" ,"
        strSQL2 = strSQL2 & "HINNME       as  ""シリーズ商品名（全角）"" ,"
        strSQL2 = strSQL2 & "UNTCD        as  ""＊単位コード"" ,"
        strSQL2 = strSQL2 & "UNTNM        as  ""単位名"" ,"
        strSQL2 = strSQL2 & "HINKB        as  ""商品区分"" ,"
        strSQL2 = strSQL2 & "HINID        as  ""商品種別"" ,"
        strSQL2 = strSQL2 & "HINCLAKB     as  ""未使用04"" ,"
        strSQL2 = strSQL2 & "HINCLBKB     as  ""未使用05"" ,"
        strSQL2 = strSQL2 & "HINCLCKB     as  ""未使用06"" ,"
        strSQL2 = strSQL2 & "HINCLAID     as  ""未使用07"" ,"
        strSQL2 = strSQL2 & "HINCLBID     as  ""未使用08"" ,"
        strSQL2 = strSQL2 & "HINCLCID     as  ""未使用09"" ,"
        strSQL2 = strSQL2 & "HINCLANM     as  ""再開予定日"" ,"
        strSQL2 = strSQL2 & "HINCLBNM     as  ""未使用10"" ,"
        strSQL2 = strSQL2 & "HINCLCNM     as  ""未使用11"" ,"
        strSQL2 = strSQL2 & "DSPKB        as  ""検索表示区分"" ,"
        strSQL2 = strSQL2 & "ZAIKB        as  ""在庫管理区分"" ,"
        strSQL2 = strSQL2 & "HINZEIKB     as  ""商品消費税区分"" ,"
        strSQL2 = strSQL2 & "ZEIRNKKB     as  ""消費税ランク"" ,"
        strSQL2 = strSQL2 & "ZEIRT        as  ""消費税率"" ,"
        strSQL2 = strSQL2 & "HINJUNKB     as  ""未使用12"" ,"
        strSQL2 = strSQL2 & "MAKCD        as  ""未使用13"" ,"
        strSQL2 = strSQL2 & "HINCMA       as  ""＊商品備考Ａ"" ,"
        strSQL2 = strSQL2 & "HINCMB       as  ""＊商品備考Ｂ"" ,"
        strSQL2 = strSQL2 & "HINCMC       as  ""＊商品備考Ｃ"" ,"
        strSQL2 = strSQL2 & "HINCMD       as  ""＊商品備考Ｄ"" ,"
        strSQL2 = strSQL2 & "HINCME       as  ""＊商品備考Ｅ"" ,"
        strSQL2 = strSQL2 & "TEIKATK      as  ""定価"" ,"
        strSQL2 = strSQL2 & "ZNKURITK     as  ""税抜販売単価"" ,"
        strSQL2 = strSQL2 & "ZKMURITK     as  ""未使用14"" ,"
        strSQL2 = strSQL2 & "ZNKSRETK     as  ""未使用15"" ,"
        strSQL2 = strSQL2 & "ZKMSRETK     as  ""未使用16"" ,"
        ' 2017/07/03_UPD_品目マスタ連携処理改修 FJ)頃安 START
        '    strSQL2 = strSQL2 & "GNKTK        as  ""原価単価"" ,"
        strSQL2 = strSQL2 & "GNKTK        as  ""仕切単価"" ,"
        ' 2017/07/03_UPD_品目マスタ連携処理改修 FJ)頃安 END
        strSQL2 = strSQL2 & "PLANTK       as  ""計画単価"" ,"
        ' 2017/07/03_UPD_品目マスタ連携処理改修 FJ)頃安 START
        '    strSQL2 = strSQL2 & "OLDGNKTK     as  ""旧原価単価"" ,"
        '    strSQL2 = strSQL2 & "GNKTKDT      as  ""適用日(原価単価)"" ,"
        strSQL2 = strSQL2 & "OLDGNKTK     as  ""旧仕切単価"" ,"
        strSQL2 = strSQL2 & "GNKTKDT      as  ""適用日(仕切単価)"" ,"
        ' 2017/07/03_UPD_品目マスタ連携処理改修 FJ)頃安 END
        strSQL2 = strSQL2 & "OLDPLNTK     as  ""旧計画単価"" ,"
        strSQL2 = strSQL2 & "PLNTKDT      as  ""適用日（機種分類)"" ,"
        strSQL2 = strSQL2 & "SODUNTSU     as  ""未使用17"" ,"
        strSQL2 = strSQL2 & "TEKZAISU     as  ""未使用18"" ,"
        strSQL2 = strSQL2 & "ANZZAISU     as  ""＊安全在庫数"","
        ' 2017/07/03_UPD_品目マスタ連携処理改修 FJ)頃安 START
        '    strSQL2 = strSQL2 & "HRTDD        as  ""発注リードタイム"" ,"
        strSQL2 = strSQL2 & "HRTDD        as  ""発注LT"" ,"
        ' 2017/07/03_UPD_品目マスタ連携処理改修 FJ)頃安 END
        strSQL2 = strSQL2 & "ORTDD        as  ""未使用19"" ,"
        ' 2017/07/03_UPD_品目マスタ連携処理改修 FJ)頃安 START
        '    strSQL2 = strSQL2 & "PRCDD        as  ""調達リードタイム"" ,"
        '    strSQL2 = strSQL2 & "MNFDD        as  ""製造リードタイム"" ,"
        strSQL2 = strSQL2 & "PRCDD        as  ""調達LT"" ,"
        strSQL2 = strSQL2 & "MNFDD        as  ""製造LT"" ,"
        ' 2017/07/03_UPD_品目マスタ連携処理改修 FJ)頃安 END
        strSQL2 = strSQL2 & "HINSIRCD     as  ""商品仕入先コード"" ,"
        strSQL2 = strSQL2 & "HINSIRRN     as  ""商品仕入先名称"" ,"
        strSQL2 = strSQL2 & "TNACM        as  ""＊倉庫"" ,"
        strSQL2 = strSQL2 & "HINNMMKB     as  ""名称ﾏﾆｭｱﾙ入力区分(商品)"" ,"
        strSQL2 = strSQL2 & "JANCD        as  ""ＪＡＮコード"" ,"
        strSQL2 = strSQL2 & "HINFRNNM     as  ""商品名海外表記"" ,"
        ' 2017/07/03_UPD_品目マスタ連携処理改修 FJ)頃安 START
        '    strSQL2 = strSQL2 & "ZAIRNK       as  ""＊在庫ランク"" ,"
        strSQL2 = strSQL2 & "ZAIRNK       as  ""在庫ランク"" ,"
        ' 2017/07/03_UPD_品目マスタ連携処理改修 FJ)頃安 END
        strSQL2 = strSQL2 & "GNKCD        as  ""原価管理コード"" ,"
        ' 2017/07/03_UPD_品目マスタ連携処理改修 FJ)頃安 START
        '    strSQL2 = strSQL2 & "MINSODSU     as  ""＊最小発注数"" ,"
        '    strSQL2 = strSQL2 & "SODADDSU     as  ""＊発注増加数"" ,"
        strSQL2 = strSQL2 & "MINSODSU     as  ""＊MOQ"" ,"
        strSQL2 = strSQL2 & "SODADDSU     as  ""＊SPQ"" ,"
        ' 2017/07/03_UPD_品目マスタ連携処理改修 FJ)頃安 END
        strSQL2 = strSQL2 & "JODHIKKB     as  ""受注引当区分"" ,"
        strSQL2 = strSQL2 & "ORTSTPKB     as  ""出荷停止"" ,"
        strSQL2 = strSQL2 & "ORTSTPDT     as  ""出荷停止日"" ,"
        strSQL2 = strSQL2 & "ORTKJDT      as  ""出荷停止解除日"" ,"
        strSQL2 = strSQL2 & "ORTSTYDT     as  ""出荷開始予定日"" ,"
        ' 2017/07/03_UPD_品目マスタ連携処理改修 FJ)頃安 START
        '    strSQL2 = strSQL2 & "CTLGKB       as  ""カタログ品対象"" ,"
        strSQL2 = strSQL2 & "CTLGKB       as  ""仕切表対象"" ,"
        ' 2017/07/03_UPD_品目マスタ連携処理改修 FJ)頃安 END
        strSQL2 = strSQL2 & "MLOKB        as  ""通販対象"" ,"
        '''' ADD 2014/01/24  FKS) T.Yamamoto    Start
        '    strSQL2 = strSQL2 & "MLOHINID     as  ""通販製品ＩＤ"" ,"
        strSQL2 = strSQL2 & "MLOHINID     as  ""アカデミックフラグ"" ,"
        '''' ADD 2014/01/24  FKS) T.Yamamoto    End
        strSQL2 = strSQL2 & "MLOIDORT     as  ""通販移動比率"" ,"
        strSQL2 = strSQL2 & "MLOLMTSU     as  ""通販移動限度数"" ,"
        strSQL2 = strSQL2 & "PRDENDKB     as  ""＊手配終了"" ,"
        strSQL2 = strSQL2 & "PRDENDDT     as  ""＊手配終了日付"" ,"
        strSQL2 = strSQL2 & "SLENDKB      as  ""＊販売完了"" ,"
        strSQL2 = strSQL2 & "SLENDDT      as  ""＊販売完了日付"" ,"
        strSQL2 = strSQL2 & "JODSTPKB     as  ""＊受注停止"" ,"
        strSQL2 = strSQL2 & "JODSTPDT     as  ""＊受注停止日付"" ,"
        strSQL2 = strSQL2 & "MNTENDKB     as  ""＊修理受付"" ,"
        strSQL2 = strSQL2 & "MNTENDDT     as  ""＊修理受付日付"" ,"
        strSQL2 = strSQL2 & "ABODT        as  ""廃止日"" ,"
        strSQL2 = strSQL2 & "ORTKB        as  ""出荷区分"" ,"
        strSQL2 = strSQL2 & "SERIKB       as  ""シリアル管理区分"" ,"
        ' 2017/07/03_UPD_品目マスタ連携処理改修 FJ)頃安 START
        '    strSQL2 = strSQL2 & "MAKNM        as  ""＊メーカー名"" ,"
        strSQL2 = strSQL2 & "MAKNM        as  ""＊原産国"" ,"
        ' 2017/07/03_UPD_品目マスタ連携処理改修 FJ)頃安 END
        strSQL2 = strSQL2 & "NXTMDL       as  ""＊後継機種"" ,"
        strSQL2 = strSQL2 & "JODSTDT      as  ""受注開始日"" ,"
        strSQL2 = strSQL2 & "ORTSTDT      as  ""出荷開始日"" ,"
        strSQL2 = strSQL2 & "KOUZA        as  ""口座"" ,"
        strSQL2 = strSQL2 & "MDLCL        as  ""機種分類"" ,"
        strSQL2 = strSQL2 & "OLDMDLCL     as  ""旧機種分類"" ,"
        strSQL2 = strSQL2 & "HINGRP       as  ""商品群"" ,"
        strSQL2 = strSQL2 & "SKHINGRP     as  ""仕切用商品群"" ,"
        strSQL2 = strSQL2 & "OEMKB        as  ""ＯＥＭ"" ,"
        strSQL2 = strSQL2 & "OEMTOKRN     as  ""ＯＥＭ得意先"" ,"
        strSQL2 = strSQL2 & "OPENKB       as  ""＊オープン価格区分"" ,"
        strSQL2 = strSQL2 & "STRMATKB     as  ""戦略物資区分"" ,"
        strSQL2 = strSQL2 & "TITNM1       as  ""題目１"" ,"
        strSQL2 = strSQL2 & "TITNM2       as  ""題目２"" ,"
        strSQL2 = strSQL2 & "TITNM3       as  ""題目３"" ,"
        strSQL2 = strSQL2 & "CATSPCNM     as  ""カタログスペック"" ,"
        strSQL2 = strSQL2 & "HINURLNM     as  ""商品URL"" ,"
        strSQL2 = strSQL2 & "CHARANM      as  ""特徴"" ,"
        strSQL2 = strSQL2 & "VSNNM        as  ""バージョン"" ,"
        strSQL2 = strSQL2 & "EDIHINSY     as  ""EDI商品種別"" ,"
        ' 2017/07/03_UPD_品目マスタ連携処理改修 FJ)頃安 START
        '    strSQL2 = strSQL2 & "BTOKB        as  ""＊提供区分"" ,"
        strSQL2 = strSQL2 & "BTOKB        as  ""＊EDI区分"" ,"
        ' 2017/07/03_UPD_品目マスタ連携処理改修 FJ)頃安 END
        strSQL2 = strSQL2 & "KONPOP       as  ""梱包ポイント"" ,"
        strSQL2 = strSQL2 & "LOTSEQNO     as  ""ロット連番"" ,"
        strSQL2 = strSQL2 & "KHNKB        as  ""仮本区分""  "
        strSQL = vbNullString
        strSQL = strSQL & " from HINMTA"
        '伝票削除区分
        strSQL = strSQL & " where DATKB='1'"
        '商品区分
        strSQL = strSQL & " AND HINKB='" & HD_HINKB.Text & "'"
        '    strSQL = strSQL & " where HINKB='" & HD_HINKB.Text & "'"
        '在庫管理
        Select Case HD_ZAIKB.Text
            Case "0"
            Case Else
                strSQL = strSQL & " and ZAIKB='" & HD_ZAIKB.Text & "'"
        End Select
        '提供区分
        Select Case HD_BTOKB.Text
            Case "0"
            Case Else
                strSQL = strSQL & " and BTOKB='" & IIf(HD_BTOKB.Text = "1", "2", "0") & "'"
        End Select
        '通販区分
        Select Case HD_MLOKB.Text
            Case "0"
            Case Else
                strSQL = strSQL & " and MLOKB='" & HD_MLOKB.Text & "'"
        End Select
        'カタログ対象
        Select Case HD_CTLGKB.Text
            Case "0"
            Case Else
                strSQL = strSQL & " and CTLGKB='" & HD_CTLGKB.Text & "'"
        End Select
        '価格区分
        Select Case HD_OPENKB.Text
            Case "0"
            Case Else
                strSQL = strSQL & " and OPENKB='" & IIf(HD_OPENKB.Text = "1", "1", "2") & "'"
        End Select
        'ＯＥＭ
        Select Case HD_OEMKB.Text
            Case "0"
            Case Else
                strSQL = strSQL & " and OEMKB='" & HD_OEMKB.Text & "'"
        End Select
        If CF_Ora_CreateDyn(gv_Odb_USR1, objUdy1, "select count(HINCD) " & strSQL) Then
            'UPGRADE_WARNING: オブジェクト objUdy1.Obj_Flds(0).Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If objUdy1.Obj_Flds(0).Value = 0 Then
                Err.Raise(6003, "0件エラー")
            End If
        Else
            Err.Raise(6002, "DBエラー")
        End If
        'UPGRADE_WARNING: オブジェクト objUdy1.Obj_Flds().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        recordcount = objUdy1.Obj_Flds(0).Value
        CF_Ora_CloseDyn(objUdy1)
        If CF_Ora_CreateDyn(gv_Odb_USR1, objUdy, strSQL2 & strSQL & " order by HINCD") Then
        Else
            Err.Raise(6002, "DBエラー")
        End If
        'ファイルオープン
        objstream = objfso.OpenTextFile(strf_name, Scripting.IOMode.ForWriting, True)
        ReDim strdmy(objUdy.Lng_FldCnt - 1)
        For I = 0 To objUdy.Lng_FldCnt - 1
            'UPGRADE_WARNING: オブジェクト objUdy.Obj_Flds().NAME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strdmy(I) = objUdy.Obj_Flds(I).NAME
        Next
        '項目書き込み
        objstream.WriteLine(Join(strdmy, gv_strTAB_CHAR))
        j = 1
        While Not CF_Ora_EOF(objUdy)
            For I = 0 To objUdy.Lng_FldCnt - 1
                'UPGRADE_WARNING: オブジェクト objUdy.Obj_Flds().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                If IsDBNull(objUdy.Obj_Flds(I).Value) Then
                    strdmy(I) = ""
                Else
                    'UPGRADE_WARNING: オブジェクト objUdy.Obj_Flds().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strdmy(I) = objUdy.Obj_Flds(I).Value
                End If
                strdmy(I) = Replace(strdmy(I), vbCr, "")
                strdmy(I) = Replace(strdmy(I), vbLf, "")
                ' === 20110221 === UPDATE S TOM)Morimoto
                '            strdmy(I) = Replace(strdmy(I), vbTab, "")
                strdmy(I) = Trim(Replace(strdmy(I), vbTab, ""))
                ' === 20110221 === UPDATE E
            Next
            'データ書き込み
            objstream.WriteLine(Join(strdmy, gv_strTAB_CHAR))
            CF_Ora_MoveNext(objUdy)
            'UPGRADE_WARNING: オブジェクト objgage.RefreshGauge の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019.04.05 DEL START
            'objgage.RefreshGauge(recordcount, j)
            '2019.04.05 DEL END
            System.Windows.Forms.Application.DoEvents()
            If bolStop_flg = True Then
                bolStop_flg = False
                '途中終了のときの処理
                cmd_Cancel.Enabled = False
                objstream.Close()
                'UPGRADE_NOTE: オブジェクト objstream をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
                objstream = Nothing
                If objfso.FileExists(strf_name) Then
                    objfso.DeleteFile(strf_name)
                End If
                'UPGRADE_NOTE: オブジェクト objfso をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
                objfso = Nothing
                '2019.04.05 DEL START
                'If objgage Is Nothing Then
                'Else
                '	'UPGRADE_WARNING: オブジェクト objgage.InitGauge の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	objgage.InitGauge()
                '	'UPGRADE_WARNING: オブジェクト objgage.ShowGauge の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	objgage.ShowGauge(False)
                '	'UPGRADE_NOTE: オブジェクト objgage をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
                '	objgage = Nothing
                'End If
                '2019.04.05 DEL END
                set_enable(True)
                '2019.04.05 DEL START
                'CM_Execute.Visible = True
                '2019.04.05 DEL END
                Cursor = System.Windows.Forms.Cursors.Default
                AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_I_004, pm_All)
                Exit Sub
            End If
            j = j + 1
        End While

        objstream.Close()
        cmd_Cancel.Enabled = False
        'UPGRADE_WARNING: オブジェクト objgage.InitGauge の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019.04.05 DEL START
        'objgage.InitGauge()
        ''UPGRADE_WARNING: オブジェクト objgage.ShowGauge の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'objgage.ShowGauge(False)
        ''UPGRADE_NOTE: オブジェクト objgage をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        'objgage = Nothing
        '2019.04.05 DEL END
        Cursor = System.Windows.Forms.Cursors.Default
        AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_I_003, pm_All)
        set_enable(True)
        '2019.04.05 DEL START
        'CM_Execute.Visible = True
        '2019.04.05 DEL END
        Exit Sub

err_MN_EXECUTE_Click:
        If Err.Number = 32755 Then
            AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_I_004, pm_All)
            Exit Sub
        End If
        If Err.Number = 6002 Then
            AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_E_010, pm_All) 'DBエラーがありました。
        ElseIf Err.Number = 6003 Then
            AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_E_009, pm_All) '0件エラー
        Else
            AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_E_011, pm_All) 'ファイル作成中にエラーがありました。
        End If
        If objstream Is Nothing Then
        Else
            objstream.Close()
            'UPGRADE_NOTE: オブジェクト objstream をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
            objstream = Nothing
        End If
        cmd_Cancel.Enabled = False
        '2019.04.05 DEL START
        'If objgage Is Nothing Then
        'Else
        '	UPGRADE_WARNING: オブジェクト objgage.InitGauge の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'objgage.InitGauge()
        '          'UPGRADE_WARNING: オブジェクト objgage.ShowGauge の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '          objgage.ShowGauge(False)
        '          'UPGRADE_NOTE: オブジェクト objgage をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '          objgage = Nothing
        '      End If
        '2019.04.05 DEL END
        Cursor = System.Windows.Forms.Cursors.Default
        set_enable(True)
        '2019.04.05 DEL START
        'CM_Execute.Visible = True
        '2019.04.05 DEL END
    End Sub

    Private Sub set_enable(ByRef flag As Boolean)
        Dim objctrl As System.Windows.Forms.Control
        On Error Resume Next
        For Each objctrl In Me.Controls
            objctrl.Enabled = flag
        Next objctrl
        cmd_Cancel.Enabled = Not flag

        '2019.04.25 add start
        cmd_Cancel.Visible = Not flag

        '常に使わないFkey
        'add 20190830 start hou
        Button1.Enabled = False
        'add 20190830 end hou
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button10.Enabled = False
        'delte 20190830 start hou
        'Button11.Enabled = False
        'delete 20190830 end hou
        '2019.04.25 add end
    End Sub


    Private Sub TX_Mode_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.F15 Then
            '2019.04.22 del start
            'MN_EXECUTE_Click(MN_EXECUTE, New System.EventArgs())
            '2019.04.22 del end
        ElseIf KeyCode = System.Windows.Forms.Keys.F16 Then
            gv_objctrl.Focus()
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub

    '2019.04.09 add start
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Call Ctl_Item_Click(Button9)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Call Ctl_Item_Click(Button12)
    End Sub

    Private Function Ctl_Item_Click(ByRef pm_Ctl As System.Windows.Forms.Control) As Short

        Dim Act_Index As Short

        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If

        'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
        Act_Index = CShort(pm_Ctl.Tag)

        Select Case Act_Index

            'delete 20190830 start hou
            'Case CShort(Button1.Tag)
            '    '実行
            '    Output()
            'delete 20190830 end hou

            'add 20190830 start hou
            Case CShort(Button11.Tag)
                '実行
                Output()
            'add 20190830 end hou

            Case CShort(Button9.Tag)
                'クリア
                Clear()

            Case CShort(Button12.Tag)
                '終了
                Me.Close()

        End Select

    End Function

    Public Function SetBar(ByRef po_Form As Form) As Boolean

        '--------------------------------------------------------------------------
        '変数の定義
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Integer    'MsgBoxの戻り値

        '--------------------------------------------------------------------------
        'エラートラップ宣言
        '--------------------------------------------------------------------------
        Try
            '--------------------------------------------------------------------------
            '処理開始
            '--------------------------------------------------------------------------
            '---戻り値設定---'
            SetBar = False

            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel1").Text = DB_NullReplace(CNV_DATE(DB_UNYMTA.UNYDT), Format(Now(), "yyyy/MM/dd"))
            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel2").Text = DB_NullReplace(DB_UNYMTA.TERMNO, "")
            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel3").Text = DB_NullReplace(SSS_OPEID.Value, "")
            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel4").Text = SSS_PrgId

            '---戻り値設定---'
            SetBar = True

            '--------------------------------------------------------------------------
            'エラートラップルーチン
            '--------------------------------------------------------------------------
        Catch ex As Exception
            li_MsgRtn = MsgBox("ﾀｲﾄﾙﾊﾞｰ,ｽﾃｰﾀｽﾊﾞｰ設定関数エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function

    Private Sub FKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)

        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                'change 20190830 start hou
                'Case Keys.F1
                '    Me.Button1.PerformClick()
                Case Keys.F11
                    Me.Button11.PerformClick()
                    'change 20190830 end hou

                Case Keys.F9
                    clearTag = Me.ActiveControl.Tag
                    Me.Button9.PerformClick()

                Case Keys.F12
                    Me.Button12.PerformClick()

                Case Keys.Up
                    If Me.ActiveControl.Tag = HD_HINKB.Tag Then
                        HD_OEMKB.Focus()
                    Else
                        Me.SelectNextControl(Me.ActiveControl, False, True, True, True)
                    End If

                Case Keys.Down
                    If Me.ActiveControl.Tag = HD_OEMKB.Tag Then
                        HD_HINKB.Focus()
                    Else
                        Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                    End If

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("フォームKeyDownエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Sub

    Private Sub FR_SSSMAIN_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        FKeyDown(sender, e)
    End Sub
    'change 20190802 START hou
    'Private Sub Button9_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Button9.KeyDown, Button1.KeyDown
    Private Sub Button9_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Button9.KeyDown
        'change 20190802 END hou
        FKeyDown(sender, e)
    End Sub

    Private Sub Button12_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Button12.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call Ctl_Item_Click(Button1)
    End Sub
    'change 20190802 START hou
    'Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs)
    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) Handles Button1.KeyDown
        'change 2090802 END hou
        FKeyDown(sender, e)
    End Sub

    Public Sub Output()
        Dim strSQL As String
        Dim strSQL2 As String
        Dim strdmy() As String
        Dim objfso As New Scripting.FileSystemObject
        Dim objstream As Scripting.TextStream
        Dim strf_name As String
        Dim wColumns As String()
        Dim sfd As New SaveFileDialog

        On Error GoTo err_F1_EXECUTE
        If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_I_001, pm_All) = MsgBoxResult.No Then
            'gv_objctrl.Focus()
            'change 20190830 start hou
            'Button1.Focus()
            Button11.Focus()
            'change 20190830 end hou
            Exit Sub
        End If

        'ファイル拡張子の既定値
        sfd.DefaultExt = gv_strOUT_TYPE
        'ファイルの種類に表示される選択しを指定する
        sfd.Filter = "*" & gv_strOUT_TYPE & "|*" & gv_strOUT_TYPE & "|*.*|*.*"
        'タイトル
        sfd.Title = "名前をつけて保存"
        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        sfd.RestoreDirectory = True
        '既に存在するファイル名を指定したとき警告する(デフォルトでTrueなので指定する必要はない)
        sfd.OverwritePrompt = True
        '存在しないパスが指定されたとき警告を表示する(デフォルトでTrueなので指定する必要はない)
        sfd.CheckPathExists = True
        'ダイアログを表示する
        If sfd.ShowDialog() = DialogResult.OK Then
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Console.WriteLine(sfd.FileName)
        End If

        strf_name = sfd.FileName

        If Len(strf_name) = 0 Then
            gv_objctrl.Focus()
            AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_I_004, pm_All)
            Exit Sub
        Else
        End If

        Cursor = System.Windows.Forms.Cursors.WaitCursor
        set_enable(False)
        cmd_Cancel.Focus()
        strSQL2 = vbNullString
        strSQL2 = strSQL2 & " select "
        strSQL2 = strSQL2 & "DATKB        as  ""未使用01"" ,"
        strSQL2 = strSQL2 & "HINMSTKB     as  ""未使用02"" ,"
        strSQL2 = strSQL2 & "HINCD        as  ""製品コード"" ,"
        strSQL2 = strSQL2 & "HINNMA       as  ""型式"" ,"
        strSQL2 = strSQL2 & "HINNMB       as  ""＊品名１"" ,"
        strSQL2 = strSQL2 & "HINNMC       as  ""未使用03"" ,"
        strSQL2 = strSQL2 & "HINNK        as  ""品名カナ"" ,"
        strSQL2 = strSQL2 & "HINNMD       as  ""シリーズ商品名（半角）"" ,"
        strSQL2 = strSQL2 & "HINNME       as  ""シリーズ商品名（全角）"" ,"
        strSQL2 = strSQL2 & "UNTCD        as  ""＊単位コード"" ,"
        strSQL2 = strSQL2 & "UNTNM        as  ""単位名"" ,"
        strSQL2 = strSQL2 & "HINKB        as  ""商品区分"" ,"
        strSQL2 = strSQL2 & "HINID        as  ""商品種別"" ,"
        strSQL2 = strSQL2 & "HINCLAKB     as  ""未使用04"" ,"
        strSQL2 = strSQL2 & "HINCLBKB     as  ""未使用05"" ,"
        strSQL2 = strSQL2 & "HINCLCKB     as  ""未使用06"" ,"
        strSQL2 = strSQL2 & "HINCLAID     as  ""未使用07"" ,"
        strSQL2 = strSQL2 & "HINCLBID     as  ""未使用08"" ,"
        strSQL2 = strSQL2 & "HINCLCID     as  ""未使用09"" ,"
        strSQL2 = strSQL2 & "HINCLANM     as  ""再開予定日"" ,"
        strSQL2 = strSQL2 & "HINCLBNM     as  ""未使用10"" ,"
        strSQL2 = strSQL2 & "HINCLCNM     as  ""未使用11"" ,"
        strSQL2 = strSQL2 & "DSPKB        as  ""検索表示区分"" ,"
        strSQL2 = strSQL2 & "ZAIKB        as  ""在庫管理区分"" ,"
        strSQL2 = strSQL2 & "HINZEIKB     as  ""商品消費税区分"" ,"
        strSQL2 = strSQL2 & "ZEIRNKKB     as  ""消費税ランク"" ,"
        strSQL2 = strSQL2 & "ZEIRT        as  ""消費税率"" ,"
        strSQL2 = strSQL2 & "HINJUNKB     as  ""未使用12"" ,"
        strSQL2 = strSQL2 & "MAKCD        as  ""未使用13"" ,"
        strSQL2 = strSQL2 & "HINCMA       as  ""＊商品備考Ａ"" ,"
        strSQL2 = strSQL2 & "HINCMB       as  ""＊商品備考Ｂ"" ,"
        strSQL2 = strSQL2 & "HINCMC       as  ""＊商品備考Ｃ"" ,"
        strSQL2 = strSQL2 & "HINCMD       as  ""＊商品備考Ｄ"" ,"
        strSQL2 = strSQL2 & "HINCME       as  ""＊商品備考Ｅ"" ,"
        strSQL2 = strSQL2 & "TEIKATK      as  ""定価"" ,"
        strSQL2 = strSQL2 & "ZNKURITK     as  ""税抜販売単価"" ,"
        strSQL2 = strSQL2 & "ZKMURITK     as  ""未使用14"" ,"
        strSQL2 = strSQL2 & "ZNKSRETK     as  ""未使用15"" ,"
        strSQL2 = strSQL2 & "ZKMSRETK     as  ""未使用16"" ,"
        strSQL2 = strSQL2 & "GNKTK        as  ""仕切単価"" ,"
        strSQL2 = strSQL2 & "PLANTK       as  ""計画単価"" ,"
        strSQL2 = strSQL2 & "OLDGNKTK     as  ""旧仕切単価"" ,"
        strSQL2 = strSQL2 & "GNKTKDT      as  ""適用日(仕切単価)"" ,"
        strSQL2 = strSQL2 & "OLDPLNTK     as  ""旧計画単価"" ,"
        strSQL2 = strSQL2 & "PLNTKDT      as  ""適用日（機種分類)"" ,"
        strSQL2 = strSQL2 & "SODUNTSU     as  ""未使用17"" ,"
        strSQL2 = strSQL2 & "TEKZAISU     as  ""未使用18"" ,"
        strSQL2 = strSQL2 & "ANZZAISU     as  ""＊安全在庫数"","
        strSQL2 = strSQL2 & "HRTDD        as  ""発注LT"" ,"
        strSQL2 = strSQL2 & "ORTDD        as  ""未使用19"" ,"
        strSQL2 = strSQL2 & "PRCDD        as  ""調達LT"" ,"
        strSQL2 = strSQL2 & "MNFDD        as  ""製造LT"" ,"
        strSQL2 = strSQL2 & "HINSIRCD     as  ""商品仕入先コード"" ,"
        strSQL2 = strSQL2 & "HINSIRRN     as  ""商品仕入先名称"" ,"
        strSQL2 = strSQL2 & "TNACM        as  ""＊倉庫"" ,"
        strSQL2 = strSQL2 & "HINNMMKB     as  ""名称ﾏﾆｭｱﾙ入力区分(商品)"" ,"
        strSQL2 = strSQL2 & "JANCD        as  ""ＪＡＮコード"" ,"
        strSQL2 = strSQL2 & "HINFRNNM     as  ""商品名海外表記"" ,"
        strSQL2 = strSQL2 & "ZAIRNK       as  ""在庫ランク"" ,"
        strSQL2 = strSQL2 & "GNKCD        as  ""原価管理コード"" ,"
        strSQL2 = strSQL2 & "MINSODSU     as  ""＊MOQ"" ,"
        strSQL2 = strSQL2 & "SODADDSU     as  ""＊SPQ"" ,"
        strSQL2 = strSQL2 & "JODHIKKB     as  ""受注引当区分"" ,"
        strSQL2 = strSQL2 & "ORTSTPKB     as  ""出荷停止"" ,"
        strSQL2 = strSQL2 & "ORTSTPDT     as  ""出荷停止日"" ,"
        strSQL2 = strSQL2 & "ORTKJDT      as  ""出荷停止解除日"" ,"
        strSQL2 = strSQL2 & "ORTSTYDT     as  ""出荷開始予定日"" ,"
        strSQL2 = strSQL2 & "CTLGKB       as  ""仕切表対象"" ,"
        strSQL2 = strSQL2 & "MLOKB        as  ""通販対象"" ,"
        strSQL2 = strSQL2 & "MLOHINID     as  ""アカデミックフラグ"" ,"
        strSQL2 = strSQL2 & "MLOIDORT     as  ""通販移動比率"" ,"
        strSQL2 = strSQL2 & "MLOLMTSU     as  ""通販移動限度数"" ,"
        strSQL2 = strSQL2 & "PRDENDKB     as  ""＊手配終了"" ,"
        strSQL2 = strSQL2 & "PRDENDDT     as  ""＊手配終了日付"" ,"
        strSQL2 = strSQL2 & "SLENDKB      as  ""＊販売完了"" ,"
        strSQL2 = strSQL2 & "SLENDDT      as  ""＊販売完了日付"" ,"
        strSQL2 = strSQL2 & "JODSTPKB     as  ""＊受注停止"" ,"
        strSQL2 = strSQL2 & "JODSTPDT     as  ""＊受注停止日付"" ,"
        strSQL2 = strSQL2 & "MNTENDKB     as  ""＊修理受付"" ,"
        strSQL2 = strSQL2 & "MNTENDDT     as  ""＊修理受付日付"" ,"
        strSQL2 = strSQL2 & "ABODT        as  ""廃止日"" ,"
        strSQL2 = strSQL2 & "ORTKB        as  ""出荷区分"" ,"
        strSQL2 = strSQL2 & "SERIKB       as  ""シリアル管理区分"" ,"
        strSQL2 = strSQL2 & "MAKNM        as  ""＊原産国"" ,"
        strSQL2 = strSQL2 & "NXTMDL       as  ""＊後継機種"" ,"
        strSQL2 = strSQL2 & "JODSTDT      as  ""受注開始日"" ,"
        strSQL2 = strSQL2 & "ORTSTDT      as  ""出荷開始日"" ,"
        strSQL2 = strSQL2 & "KOUZA        as  ""口座"" ,"
        strSQL2 = strSQL2 & "MDLCL        as  ""機種分類"" ,"
        strSQL2 = strSQL2 & "OLDMDLCL     as  ""旧機種分類"" ,"
        strSQL2 = strSQL2 & "HINGRP       as  ""商品群"" ,"
        strSQL2 = strSQL2 & "SKHINGRP     as  ""仕切用商品群"" ,"
        strSQL2 = strSQL2 & "OEMKB        as  ""ＯＥＭ"" ,"
        strSQL2 = strSQL2 & "OEMTOKRN     as  ""ＯＥＭ得意先"" ,"
        strSQL2 = strSQL2 & "OPENKB       as  ""＊オープン価格区分"" ,"
        strSQL2 = strSQL2 & "STRMATKB     as  ""戦略物資区分"" ,"
        strSQL2 = strSQL2 & "TITNM1       as  ""題目１"" ,"
        strSQL2 = strSQL2 & "TITNM2       as  ""題目２"" ,"
        strSQL2 = strSQL2 & "TITNM3       as  ""題目３"" ,"
        strSQL2 = strSQL2 & "CATSPCNM     as  ""カタログスペック"" ,"
        strSQL2 = strSQL2 & "HINURLNM     as  ""商品URL"" ,"
        strSQL2 = strSQL2 & "CHARANM      as  ""特徴"" ,"
        strSQL2 = strSQL2 & "VSNNM        as  ""バージョン"" ,"
        strSQL2 = strSQL2 & "EDIHINSY     as  ""EDI商品種別"" ,"
        strSQL2 = strSQL2 & "BTOKB        as  ""＊EDI区分"" ,"
        strSQL2 = strSQL2 & "KONPOP       as  ""梱包ポイント"" ,"
        strSQL2 = strSQL2 & "LOTSEQNO     as  ""ロット連番"" ,"
        strSQL2 = strSQL2 & "KHNKB        as  ""仮本区分""  "
        strSQL = vbNullString
        strSQL = strSQL & " from HINMTA"
        '伝票削除区分
        strSQL = strSQL & " where DATKB='1'"
        '商品区分
        strSQL = strSQL & " AND HINKB='" & HD_HINKB.Text & "'"
        '在庫管理
        Select Case HD_ZAIKB.Text
            Case "0"
            Case Else
                strSQL = strSQL & " and ZAIKB='" & HD_ZAIKB.Text & "'"
        End Select
        '提供区分
        Select Case HD_BTOKB.Text
            Case "0"
            Case Else
                strSQL = strSQL & " and BTOKB='" & IIf(HD_BTOKB.Text = "1", "2", "0") & "'"
        End Select
        '通販区分
        Select Case HD_MLOKB.Text
            Case "0"
            Case Else
                strSQL = strSQL & " and MLOKB='" & HD_MLOKB.Text & "'"
        End Select
        'カタログ対象
        Select Case HD_CTLGKB.Text
            Case "0"
            Case Else
                strSQL = strSQL & " and CTLGKB='" & HD_CTLGKB.Text & "'"
        End Select
        '価格区分
        Select Case HD_OPENKB.Text
            Case "0"
            Case Else
                strSQL = strSQL & " and OPENKB='" & IIf(HD_OPENKB.Text = "1", "1", "2") & "'"
        End Select
        'ＯＥＭ
        Select Case HD_OEMKB.Text
            Case "0"
            Case Else
                strSQL = strSQL & " and OEMKB='" & HD_OEMKB.Text & "'"
        End Select

        Dim dt As DataTable = DB_GetTable("select count(HINCD) AS COUNT" & strSQL)
        If dt Is Nothing OrElse dt.Rows(0).Item("COUNT") <= 0 Then
            Err.Raise(6003, "0件エラー")
        End If

        dt = Nothing
        dt = DB_GetTable(strSQL2 & strSQL & " order by HINCD")

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            Err.Raise(6002, "DBエラー")
        End If

        'ファイルオープン
        objstream = objfso.OpenTextFile(strf_name, Scripting.IOMode.ForWriting, True)
        For I As Integer = 0 To dt.Columns.Count - 1
            ReDim Preserve wColumns(I)
            wColumns(I) = dt.Columns(I).ColumnName
        Next

        '項目書き込み
        objstream.WriteLine(Join(wColumns, gv_strTAB_CHAR))
        For I As Integer = 0 To dt.Rows.Count - 1
            For J As Integer = 0 To wColumns.Length - 1
                ReDim Preserve strdmy(J)
                If IsDBNull(dt.Rows(I).Item(wColumns(J))) Then
                    strdmy(J) = ""
                Else
                    strdmy(J) = dt.Rows(I).Item(wColumns(J))
                End If
                strdmy(J) = Replace(strdmy(J), vbCr, "")
                strdmy(J) = Replace(strdmy(J), vbLf, "")
                strdmy(J) = Trim(Replace(strdmy(J), vbTab, ""))
            Next
            'データ書き込み
            objstream.WriteLine(Join(strdmy, gv_strTAB_CHAR))

            System.Windows.Forms.Application.DoEvents()
            If bolStop_flg = True Then
                bolStop_flg = False
                '途中終了のときの処理
                cmd_Cancel.Enabled = False
                objstream.Close()
                objstream = Nothing
                If objfso.FileExists(strf_name) Then
                    objfso.DeleteFile(strf_name)
                End If
                objfso = Nothing
                set_enable(True)
                Cursor = System.Windows.Forms.Cursors.Default
                AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_I_004, pm_All)
                Exit Sub
            End If

        Next

        objstream.Close()
        cmd_Cancel.Enabled = False
        cmd_Cancel.Visible = False
        Cursor = System.Windows.Forms.Cursors.Default
        AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_I_003, pm_All)
        set_enable(True)
        initializeForm()
        Exit Sub

err_F1_EXECUTE:
        If Err.Number = 32755 Then
            AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_I_004, pm_All)
            Exit Sub
        End If
        If Err.Number = 6002 Then
            AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_E_010, pm_All) 'DBエラーがありました。
        ElseIf Err.Number = 6003 Then
            AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_E_009, pm_All) '0件エラー
        Else
            AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHINFP61_E_011, pm_All) 'ファイル作成中にエラーがありました。
        End If
        If objstream Is Nothing Then
        Else
            objstream.Close()
            objstream = Nothing
        End If
        cmd_Cancel.Enabled = False
        Cursor = System.Windows.Forms.Cursors.Default
        set_enable(True)
    End Sub

    'delete 20190802 START hou
    'Private Sub HD_HINKB_KeyDown(sender As Object, e As KeyEventArgs) Handles HD_HINKB.KeyDown
    '    FKeyDown(sender, e)
    '    If (e.KeyCode = Keys.Enter) AndAlso Not e.Alt AndAlso Not e.Control Then
    '        'あたかもTabキーが押されたかのようにする
    '        'Shiftが押されている時は前のコントロールのフォーカスを移動
    '        Me.ProcessTabKey(Not e.Shift)
    '        e.Handled = True
    '        e.SuppressKeyPress = True
    '    End If
    'End Sub
    'delete 20190802 END hou

    Private Sub HD_ZAIKB_KeyDown(sender As Object, e As KeyEventArgs) Handles HD_ZAIKB.KeyDown
        FKeyDown(sender, e)
        If (e.KeyCode = Keys.Enter) AndAlso Not e.Alt AndAlso Not e.Control Then
            'あたかもTabキーが押されたかのようにする
            'Shiftが押されている時は前のコントロールのフォーカスを移動
            Me.ProcessTabKey(Not e.Shift)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub HD_BTOKB_KeyDown(sender As Object, e As KeyEventArgs) Handles HD_BTOKB.KeyDown
        FKeyDown(sender, e)
        If (e.KeyCode = Keys.Enter) AndAlso Not e.Alt AndAlso Not e.Control Then
            'あたかもTabキーが押されたかのようにする
            'Shiftが押されている時は前のコントロールのフォーカスを移動
            Me.ProcessTabKey(Not e.Shift)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub HD_MLOKB_KeyDown(sender As Object, e As KeyEventArgs) Handles HD_MLOKB.KeyDown
        FKeyDown(sender, e)
        If (e.KeyCode = Keys.Enter) AndAlso Not e.Alt AndAlso Not e.Control Then
            'あたかもTabキーが押されたかのようにする
            'Shiftが押されている時は前のコントロールのフォーカスを移動
            Me.ProcessTabKey(Not e.Shift)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub HD_CTLGKB_KeyDown(sender As Object, e As KeyEventArgs) Handles HD_CTLGKB.KeyDown
        FKeyDown(sender, e)
        If (e.KeyCode = Keys.Enter) AndAlso Not e.Alt AndAlso Not e.Control Then
            'あたかもTabキーが押されたかのようにする
            'Shiftが押されている時は前のコントロールのフォーカスを移動
            Me.ProcessTabKey(Not e.Shift)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub HD_OPENKB_KeyDown(sender As Object, e As KeyEventArgs) Handles HD_OPENKB.KeyDown
        FKeyDown(sender, e)
        If (e.KeyCode = Keys.Enter) AndAlso Not e.Alt AndAlso Not e.Control Then
            'あたかもTabキーが押されたかのようにする
            'Shiftが押されている時は前のコントロールのフォーカスを移動
            Me.ProcessTabKey(Not e.Shift)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub HD_OEMKB_KeyDown(sender As Object, e As KeyEventArgs) Handles HD_OEMKB.KeyDown
        FKeyDown(sender, e)
        If (e.KeyCode = Keys.Enter) AndAlso Not e.Alt AndAlso Not e.Control Then
            'あたかもTabキーが押されたかのようにする
            'Shiftが押されている時は前のコントロールのフォーカスを移動
            Me.ProcessTabKey(Not e.Shift)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub Clear()
        Dim objtxt As System.Windows.Forms.Control
        objtxt = getTag(clearTag)
        With objtxt
            Select Case clearTag
                Case 0
                Case HD_HINKB.Tag, HD_ZAIKB.Tag
                    .Text = "1"
                    .BackColor = System.Drawing.Color.Yellow
                    .ForeColor = System.Drawing.Color.Black
                Case Else
                    .Text = "0"
                    .BackColor = System.Drawing.Color.White
                    .ForeColor = System.Drawing.Color.Black
            End Select
        End With
        clearTag = 0
    End Sub

    Private Sub HD_HINKB_Leave(sender As Object, e As EventArgs) Handles HD_HINKB.Leave
        clearTag = HD_HINKB.Tag
        setFocus(HD_HINKB, False)
    End Sub

    Private Sub HD_ZAIKB_Leave(sender As Object, e As EventArgs) Handles HD_ZAIKB.Leave
        clearTag = HD_ZAIKB.Tag
        setFocus(HD_ZAIKB, False)
    End Sub

    Private Sub HD_BTOKB_Leave(sender As Object, e As EventArgs) Handles HD_BTOKB.Leave
        clearTag = HD_BTOKB.Tag
        setFocus(HD_BTOKB, False)
    End Sub

    Private Sub HD_MLOKB_Leave(sender As Object, e As EventArgs) Handles HD_MLOKB.Leave
        clearTag = HD_MLOKB.Tag
        setFocus(HD_MLOKB, False)
    End Sub

    Private Sub HD_CTLGKB_Leave(sender As Object, e As EventArgs) Handles HD_CTLGKB.Leave
        clearTag = HD_CTLGKB.Tag
        setFocus(HD_CTLGKB, False)
    End Sub

    Private Sub HD_OPENKB_Leave(sender As Object, e As EventArgs) Handles HD_OPENKB.Leave
        clearTag = HD_OPENKB.Tag
        setFocus(HD_OPENKB, False)
    End Sub

    Private Sub HD_OEMKB_Leave(sender As Object, e As EventArgs) Handles HD_OEMKB.Leave
        clearTag = HD_OEMKB.Tag
        setFocus(HD_OEMKB, False)
    End Sub

    Private Sub Button1_Leave(sender As Object, e As EventArgs) Handles Button1.Leave
        clearTag = 0
    End Sub

    Private Sub Button12_Leave(sender As Object, e As EventArgs) Handles Button12.Leave
        clearTag = 0
    End Sub

    Private Sub cmd_Cancel_Leave(sender As Object, e As EventArgs) Handles cmd_Cancel.Leave
        clearTag = 0
    End Sub

    Private Sub HD_HINKB_Enter(sender As Object, e As EventArgs) Handles HD_HINKB.Enter
        setFocus(HD_HINKB, True)
    End Sub
    Private Sub HD_ZAIKB_Enter(sender As Object, e As EventArgs) Handles HD_ZAIKB.Enter
        setFocus(HD_ZAIKB, True)
    End Sub
    Private Sub HD_BTOKB_Enter(sender As Object, e As EventArgs) Handles HD_BTOKB.Enter
        setFocus(HD_BTOKB, True)
    End Sub
    Private Sub HD_MLOKB_Enter(sender As Object, e As EventArgs) Handles HD_MLOKB.Enter
        setFocus(HD_MLOKB, True)
    End Sub
    Private Sub HD_CTLGKB_Enter(sender As Object, e As EventArgs) Handles HD_CTLGKB.Enter
        setFocus(HD_CTLGKB, True)
    End Sub
    Private Sub HD_OPENKB_Enter(sender As Object, e As EventArgs) Handles HD_OPENKB.Enter
        setFocus(HD_OPENKB, True)
    End Sub
    Private Sub HD_OEMKB_Enter(sender As Object, e As EventArgs) Handles HD_OEMKB.Enter
        setFocus(HD_OEMKB, True)
    End Sub

    Private Function getTag(ByVal checkTag As Integer) As System.Windows.Forms.Control
        Select Case checkTag
            Case HD_HINKB.Tag
                Return HD_HINKB
            Case HD_ZAIKB.Tag
                Return HD_ZAIKB
            Case HD_BTOKB.Tag
                Return HD_BTOKB
            Case HD_MLOKB.Tag
                Return HD_MLOKB
            Case HD_CTLGKB.Tag
                Return HD_CTLGKB
            Case HD_OPENKB.Tag
                Return HD_OPENKB
            Case HD_OEMKB.Tag
                Return HD_OEMKB
        End Select
    End Function

    Private Sub initializeForm()
        With HD_HINKB
            .Text = "1"
            .BackColor = System.Drawing.Color.White
            .ForeColor = System.Drawing.Color.Black
        End With
        With HD_ZAIKB
            .Text = "1"
            .BackColor = System.Drawing.Color.White
            .ForeColor = System.Drawing.Color.Black
        End With
        With HD_BTOKB
            .Text = "0"
            .BackColor = System.Drawing.Color.White
            .ForeColor = System.Drawing.Color.Black
        End With
        With HD_MLOKB
            .Text = "0"
            .BackColor = System.Drawing.Color.White
            .ForeColor = System.Drawing.Color.Black
        End With
        With HD_CTLGKB
            .Text = "0"
            .BackColor = System.Drawing.Color.White
            .ForeColor = System.Drawing.Color.Black
        End With
        With HD_OPENKB
            .Text = "0"
            .BackColor = System.Drawing.Color.White
            .ForeColor = System.Drawing.Color.Black
        End With
        With HD_OEMKB
            .Text = "0"
            .BackColor = System.Drawing.Color.White
            .ForeColor = System.Drawing.Color.Black
        End With
        HD_HINKB.Focus()
        clearTag = 0
    End Sub

    Private Sub showMessage(ByVal msgKbNm As String, ByVal msgSq As Integer)
        Dim wMsgKb As Integer = Integer.Parse(msgKbNm.Substring(0, 1))
        Dim wMsgNm As String = msgKbNm.Substring(1)

        '20190712 CHG START
        'SYSTBH_GetFirst(wMsgKb, wMsgNm, msgSq)

        Dim tableCond As String = ""

        If DB_NullReplace(wMsgNm, "") = "" Then
            tableCond = " where MSGKB = '" & wMsgKb & "'"
        Else
            If Len(Trim(msgSq)) = 0 Then
                tableCond = " where MSGKB = '" & wMsgKb & "'" & " and MSGNM = '" & wMsgNm & "'"
            Else
                tableCond = " where MSGKB = '" & wMsgKb & "'" & " and MSGNM = '" & wMsgNm & "'" & " and MSGSQ = '" & msgSq & "'"
            End If
        End If

        GetRowsCommon("SYSTBH", tableCond)

        If DBSTAT = 0 Then
            MsgBox(DB_SYSTBH.MSGCM, MsgBoxStyle.Critical, "エラー")
        Else
            MsgBox("showMessageエラー", MsgBoxStyle.Critical, "エラー")
        End If

    End Sub

    Private Sub setFocus(ByVal wControl As System.Windows.Forms.TextBox, ByVal wEnterFlg As Boolean)
        With wControl
            If wEnterFlg = True Then
                .SelectAll()
                .BackColor = Color.Yellow
            Else
                .SelectionStart = .TextLength
                .BackColor = Color.White
            End If
        End With
    End Sub
    '2019.04.09 add end

    'add 20190830 start hou
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Call Ctl_Item_Click(Button11)
    End Sub

    Private Sub Button11_KeyDown(sender As Object, e As KeyEventArgs) Handles Button11.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub Button11_Leave(sender As Object, e As EventArgs) Handles Button11.Leave
        clearTag = 0
    End Sub
    'add 20190830 end hou

End Class