Option Strict Off
Option Explicit On
Friend Class DLGLST3
	Inherits System.Windows.Forms.Form
	
	Private Sub CMD_SELECT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CMD_SELECT.Click
		Dim Index As Short = CMD_SELECT.GetIndex(eventSender)
		'UPGRADE_WARNING: オブジェクト SSS_RTNWIN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSS_RTNWIN = Index
		Me.Close()
	End Sub
	
	Private Sub DLGLST3_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Text = FR_SSSMAIN.Text
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
	End Sub
End Class