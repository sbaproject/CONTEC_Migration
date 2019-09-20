Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module FORM_CMN

    '2019/04/19 ADD START
    Public Sub SetBar(ByRef pForm As Form)

        Try
            DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel1").Text = DB_NullReplace(CNV_DATE(DB_UNYMTA.UNYDT), Format(Now(), "yyyy/MM/dd"))
            DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel2").Text = DB_NullReplace(DB_UNYMTA.TERMNO, "")
            DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel3").Text = DB_NullReplace(SSS_OPEID.Value, "")
            DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel4").Text = My.Application.Info.AssemblyName
        Catch ex As Exception
            MsgBox("ﾀｲﾄﾙﾊﾞｰ,ｽﾃｰﾀｽﾊﾞｰ設定関数エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Sub
    '2019/04/19 ADD E N D

End Module