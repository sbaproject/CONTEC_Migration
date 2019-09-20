Option Strict Off
Option Explicit On
Friend Class DLGLST1
    Inherits System.Windows.Forms.Form

    Private Sub CMD_SELECT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CMD_SELECT.Click
        Dim Index As Short = CMD_SELECT.GetIndex(eventSender)
        'UPGRADE_WARNING: オブジェクト SSS_RTNWIN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        SSS_RTNWIN = Index
        Me.Close()
    End Sub

    Private Sub DLGLST1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Text = FR_SSSMAIN.Text
        '2019.04.11 DEL START
        'Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(FR_SSSMAIN.Top) + VB6.PixelsToTwipsY(FR_SSSMAIN.Height) - VB6.PixelsToTwipsY(Height))
        'Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(FR_SSSMAIN.Left) + VB6.PixelsToTwipsX(FR_SSSMAIN.Width) - VB6.PixelsToTwipsX(Width))
        '2019.04.11 DEL END

        '2019.04.11 CHG START
        'CHG START FKS)INABA 2006/11/15******************************************************************
        '先に取得した権限により、Preview画面の印刷ボタン、プリンタ設定ボタン、ファイル出力ボタンを制御する
        '実行権限の取得
        'Call Get_Authority(DB_UNYMTA.UNYDT)

        ''先に取得した権限により、Preview画面の印刷ボタン、プリンタ設定ボタン、ファイル出力ボタンを制御する
        'If gs_PRTAUTH = "1" Then '印刷権限有り
        '	CMD_SELECT(0).Enabled = True
        '	CMD_SELECT(1).Enabled = True
        'Else
        '	CMD_SELECT(0).Enabled = False
        '	CMD_SELECT(1).Enabled = True
        'End If
        'If gs_FILEAUTH = "1" Then 'ファイル出力権限有り
        '	CMD_SELECT(1).Enabled = True
        '	CMD_SELECT(2).Enabled = True
        'Else
        '	CMD_SELECT(1).Enabled = True
        '	CMD_SELECT(2).Enabled = False
        'End If
        'CHG  END  FKS)INABA 2006/11/15******************************************************************

        '      
        CMD_SELECT(0).Enabled = True
        CMD_SELECT(1).Enabled = True
        CMD_SELECT(1).Enabled = True
        CMD_SELECT(2).Enabled = True
        '2019.04.11 CHG END

    End Sub
End Class