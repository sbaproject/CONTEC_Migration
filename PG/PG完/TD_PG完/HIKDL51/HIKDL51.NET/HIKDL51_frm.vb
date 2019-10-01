Option Strict Off
Option Explicit On
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
	
	Public gv_bolKeyFlg As Boolean

    Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        '二重起動ﾁｪｯｸ
        'UPGRADE_ISSUE: App プロパティ App.PrevInstance はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
        '20190703 DELL START
        'If App.PrevInstance Then
        '    MsgBox("【" & Trim(SSS_PrgNm) & "】は既に起動中です。重複して起動する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
        '    End
        'End If
        '20190703 DELL END

        ' "しばらくお待ちください" ウィンドウ表示
        'UPGRADE_ISSUE: Load ステートメント はサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' をクリックしてください。
        '20190703 CHG START
        'Load(ICN_ICON)
        'ICN_ICON.ShowDialog()
        '20190703 CHG END
        'DB接続
        '20190703 CHG START
        'Call CF_Ora_USR1_Open()
        Call DB_START()
        '20190703 CHG END


        '共通初期化処理
        Call CF_Init()


        '引当状況照会呼出し処理
        Call F_DSP_TNADL71C()


        '20190703 DELL START
        '      ' "しばらくお待ちください" ウィンドウ消去
        '      ICN_ICON.Close()

        ''画面終了
        'Me.Close()
        '20190703 DELL END
        '20190703 ADD START
        SetBar(Me)
        '20190703 ADD END

    End Sub

    '20190703 ADD START
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
    '20190703 ADD END

    Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason

        'UPGRADE_NOTE: オブジェクト FR_SSSMAIN をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '20190703 DELL START
        'Me = Nothing
        '20190703 DELL END

        'DB接続解除
        '20190703 CHG START
        'Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
        Call DB_CLOSE(CON)
        '20190703 CHG END

        eventArgs.Cancel = Cancel
    End Sub

    Private Sub btnF12_Click(sender As Object, e As EventArgs) Handles btnF12.Click

    End Sub
    '20190703 ADD START
    'Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
    '    Call Ctl_Item_Click(btnF1)
    'End Sub

    'Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
    '    Call Ctl_Item_Click(btnF2)
    'End Sub

    'Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
    '    Call Ctl_Item_Click(btnF3)
    'End Sub

    'Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
    '    Call Ctl_Item_Click(btnF4)
    'End Sub

    'Private Sub btnF5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF5.Click
    '    Call Ctl_Item_Click(btnF5)
    'End Sub

    'Private Sub btnF6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF6.Click
    '    Call Ctl_Item_Click(btnF6)
    'End Sub

    'Private Sub btnF7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF7.Click
    '    Call Ctl_Item_Click(btnF7)
    'End Sub

    'Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
    '    Call Ctl_Item_Click(btnF8)
    'End Sub

    'Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
    '    Call Ctl_Item_Click(btnF9)
    'End Sub

    'Private Sub btnF10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF10.Click
    '    Call Ctl_Item_Click(btnF10)
    'End Sub

    'Private Sub btnF11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF11.Click
    '    Call Ctl_Item_Click(btnF11)
    'End Sub

    'Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
    '    Call Ctl_Item_Click(btnF12)
    'End Sub
    '20190703 ADD END
End Class